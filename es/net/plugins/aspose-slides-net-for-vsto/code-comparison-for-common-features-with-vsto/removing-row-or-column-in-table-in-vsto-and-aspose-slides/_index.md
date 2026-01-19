---
title: Eliminar fila o columna en tabla en VSTO y Aspose.Slides
type: docs
weight: 130
url: /es/net/removing-row-or-column-in-table-in-vsto-and-aspose-slides/
---

## **VSTO**
A continuación se muestra el código para eliminar filas o columnas de una tabla usando VSTO Presentation:

``` csharp

    string FileName = "Removing Row Or Column in Table.pptx";

   Presentation pres = Application.Presentations.Open(FileName);

   //Get the first slide

   Slide sld = pres.Slides[1];

   foreach (Shape shp in sld.Shapes)

   {

      if (shp.HasTable == Microsoft.Office.Core.MsoTriState.msoTrue)

      {

          shp.Table.Rows[1].Delete();

      }

   }

``` 
## **Aspose.Slides**
Aspose.Slides para .NET ha proporcionado la API más sencilla para crear tablas de la forma más fácil. Para crear una tabla en una diapositiva y realizar algunas operaciones básicas sobre la tabla, siga los pasos a continuación:

- Cree una instancia de la clase Presentation
- Obtenga la referencia de una diapositiva mediante su índice
- Defina una matriz de columnas con ancho
- Defina una matriz de filas con altura
- Añada una tabla a la diapositiva usando el método AddTable expuesto por el objeto IShapes
- Elimine una fila de la tabla
- Elimine una columna de la tabla
- Guarde la presentación modificada como un archivo PPTX

``` csharp

   string FileName = "Removing Row Or Column in Table.pptx";

  Presentation MyPresentation = new Presentation(FileName);

  //Get First Slide

  ISlide sld = MyPresentation.Slides[0];

  foreach (IShape shp in sld.Shapes)

  if (shp is ITable)

  {

     ITable tbl = (ITable)shp;

     tbl.Rows.RemoveAt(0, false);

  }

  MyPresentation.Save(FileName,Export.SaveFormat.Pptx);


``` 
## **Download Running Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Removing%20Row%20Or%20Column%20in%20Table)