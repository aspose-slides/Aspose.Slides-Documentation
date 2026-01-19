---
title: Añadir imagen en celda de tabla
type: docs
weight: 10
url: /es/net/add-image-in-table-cell/
---

## **VSTO**
A continuación se muestra el código para añadir una imagen en una celda de tabla:

``` csharp

    //Open Prsentation class that contains the table

   string FileName = "Adding Image in Table Cell.pptx";

   string ImageFile = "AsposeLogo.jpg";

   Presentation pres = Application.Presentations.Open(FileName);

   //Get the first slide

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
Aspose.Slides para .NET ha proporcionado la API más sencilla para crear tablas de la manera más fácil. Para añadir una imagen en una celda de tabla al crear una tabla nueva, siga los pasos a continuación:

- Crear una instancia de la clase Presentation
- Obtener la referencia de una diapositiva usando su índice
- Definir una matriz de columnas con ancho
- Definir una matriz de filas con altura
- Añadir una tabla a la diapositiva usando el método AddTable expuesto por el objeto IShapes
- Crear un objeto Bitmap para contener el archivo de imagen
- Añadir la imagen Bitmap al objeto IPPImage
- Establecer el formato de relleno de la celda de tabla como Imagen
- Añadir la imagen a la primera celda de la tabla
- Guardar la presentación modificada como archivo PPTX

``` csharp

   string FileName = "Adding Image in Table Cell.pptx";

  string ImageFile = "AsposeLogo.jpg";

  Presentation MyPresentation = new Presentation(FileName);

  //Get First Slide

  ISlide sld = MyPresentation.Slides[0];

  //Creating a Bitmap Image object to hold the image file

  using IImage image = Images.FromFile(ImageFile);

  //Create an IPPImage object using the bitmap object

  IPPImage imgx1 = MyPresentation.Images.AddImage(image);

  foreach (IShape shp in sld.Shapes)

  if (shp is ITable)

  {

     ITable tbl = (ITable)shp;

     //Add image to first table cell

     tbl[0, 0].FillFormat.FillType = FillType.Picture;

     tbl[0, 0].FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

     tbl[0, 0].FillFormat.PictureFillFormat.Picture.Image = imgx1;

   }

  //Save PPTX to Disk

  MyPresentation.Save(FileName, Export.SaveFormat.Pptx);


``` 
## **Descargar código en ejecución**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Descargar código de ejemplo**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20image%20in%20table%20cell)