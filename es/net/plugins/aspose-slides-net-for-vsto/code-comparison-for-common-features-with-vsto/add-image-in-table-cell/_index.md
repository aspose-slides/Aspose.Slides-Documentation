---
title: Agregar imagen en celda de tabla
type: docs
weight: 10
url: /es/net/add-image-in-table-cell/
---

## **VSTO**
A continuación se muestra el código para agregar una imagen en una celda de tabla:

``` csharp

    //Abrir la clase Presentación que contiene la tabla

   string FileName = "Agregar Imagen en Celda de Tabla.pptx";

   string ImageFile = "AsposeLogo.jpg";

   Presentation pres = Application.Presentations.Open(FileName);

   //Obtener la primera diapositiva

   Slide sld = pres.Slides[1];

   foreach (Shape shp in sld.Shapes)

   {

      if (shp.HasTable == Microsoft.Office.Core.MsoTriState.msoTrue)

      {

          Cell cell= shp.Table.Rows[1].Cells[1];

          cell.Shape.Fill.UserPicture(ImageFile);

      }

   }


``` 
## **Aspose.Slides**
Aspose.Slides para .NET ha proporcionado la API más simple para crear tablas de la manera más fácil. Para agregar una imagen en una celda de tabla al crear una nueva tabla, siga los pasos a continuación:

- Cree una instancia de la clase Presentación
- Obtenga la referencia de una diapositiva utilizando su índice
- Defina una matriz de columnas con ancho
- Defina una matriz de filas con altura
- Agregue una tabla a la diapositiva utilizando el método AddTable expuesto por el objeto IShapes
- Cree un objeto Bitmap para mantener el archivo de imagen
- Agregue la imagen Bitmap al objeto IPPImage
- Establezca el formato de relleno de la celda de la tabla como imagen
- Agregue la imagen a la primera celda de la tabla
- Guarde la presentación modificada como un archivo PPTX

``` csharp

   string FileName = "Agregar Imagen en Celda de Tabla.pptx";

  string ImageFile = "AsposeLogo.jpg";

  Presentation MyPresentation = new Presentation(FileName);

  //Obtener primera diapositiva

  ISlide sld = MyPresentation.Slides[0];

  //Crear un objeto de imagen Bitmap para mantener el archivo de imagen

  using IImage image = Images.FromFile(ImageFile);

  //Crear un objeto IPPImage utilizando el objeto bitmap

  IPPImage imgx1 = MyPresentation.Images.AddImage(image);

  foreach (IShape shp in sld.Shapes)

  if (shp is ITable)

  {

     ITable tbl = (ITable)shp;

     //Agregar imagen a la primera celda de la tabla

     tbl[0, 0].FillFormat.FillType = FillType.Picture;

     tbl[0, 0].FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

     tbl[0, 0].FillFormat.PictureFillFormat.Picture.Image = imgx1;

   }

  //Guardar PPTX en disco

  MyPresentation.Save(FileName, Export.SaveFormat.Pptx);


``` 
## **Descargar Código en Ejecución**
- [Codeplex](https://asposevsto.codeplex.com/releases/view/616670)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Descargar Código de Ejemplo**
- [Codeplex](https://asposevsto.codeplex.com/SourceControl/latest#Aspose.Slides Vs VSTO Slides/Agregar imagen en celda de tabla/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Agregando%20imagen%20en%20celda%20de%20tabla)