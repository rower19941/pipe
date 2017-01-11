
namespace pipe
{
    using System.Windows.Media;
    using System.Windows.Media.Media3D;
    using HelixToolkit.Wpf;

    /// <summary>
    /// Provides a ViewModel for the Main window.
    /// </summary>
    public class Create_main_model
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Create_main_model"/> class.
        /// </summary>
        public void Create_box(double diameter, MeshBuilder mesh_builder_name)
        {
            if (diameter > 1)
            {
                mesh_builder_name.AddBox(new Point3D(1.2 * diameter, 0, 0), 1, 1, 1);
            }
            else
            {
                mesh_builder_name.AddBox(new Point3D(3 * diameter, 0, 0), 1, 1, 1);
            }
        }

        public Create_main_model(double main_diameter)
        {
            
            // Create a model group
            var modelGroup = new Model3DGroup();
            var hVp3D = new HelixViewport3D();
            var meshBuilder = new MeshBuilder(false, false);
         
            meshBuilder.AddPipe(new Point3D(0, 0, 0), new Point3D(0, 0, -2.25 * main_diameter), main_diameter, main_diameter * 1.05, 64);//цилиндрическая часть
            meshBuilder.AddCone(new Point3D(0, 0, -2.25 * main_diameter), new Point3D(0, 0, -4.75 * main_diameter), main_diameter / 2, false, 64);
            meshBuilder.AddCone(new Point3D(0, 0, -2.25 * main_diameter), new Point3D(0, 0, -4.75 * main_diameter), 1.05*main_diameter / 2, false, 64);
            meshBuilder.AddPipe(new Point3D(0, 0, 0), new Point3D(0, 0, -0.05), 0.6 * main_diameter, main_diameter * 1.05, 64);//крышка корпуса
            meshBuilder.AddPipe(new Point3D(0, 0, -1.15 * main_diameter), new Point3D(0, 0, 0.5 * main_diameter), main_diameter * 0.55, 0.6 * main_diameter,64);//выхлопная труба
            meshBuilder.AddPipe(new Point3D(0, 0.33 * main_diameter, -0.2 * main_diameter), new Point3D(-0.7 * main_diameter, 0.33 * main_diameter, -0.2 * main_diameter), 0.67 * main_diameter / 2, 0.72 * main_diameter / 2, 64);//патрубок
            //meshBuilder.AddPipe(new Point3D(0, 0.33 * main_diameter, -0.3 * main_diameter), new Point3D(-0.7 * main_diameter, 0.33 * main_diameter, -0.3 * main_diameter), 0.67 * main_diameter / 2, 0.72 * main_diameter / 2, 64);//патрубок

            //для наглядности добавим коробку метр на метр
            Create_box(main_diameter, meshBuilder);
            // Create a mesh from the builder (and freeze it)
            var mesh = meshBuilder.ToMesh(true);

            // Create some materials
            var insideMaterial = MaterialHelper.CreateMaterial(Colors.Yellow);
            var outsideMaterial = MaterialHelper.CreateMaterial(Colors.SeaShell);
            //SteelBlue

            // Add 6 models to the group (using the same mesh, that's why we had to freeze it)
            modelGroup.Children.Add(new GeometryModel3D { Geometry = mesh, Material = outsideMaterial, BackMaterial = insideMaterial });
            
            // Set the property, which will be bound to the Content property of the ModelVisual3D (see MainWindow.xaml)
            this.Model = modelGroup;
            
        }

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        /// <value>The model.</value>
        public Model3D Model { get; set; }
       
    }
}