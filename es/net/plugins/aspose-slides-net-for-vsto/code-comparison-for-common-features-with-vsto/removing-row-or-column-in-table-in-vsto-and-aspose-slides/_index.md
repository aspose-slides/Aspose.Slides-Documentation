---
title: Eliminación de fila o columna en la tabla en VSTO y Aspose.Slides
type: docs
weight: 130
url: /net/removing-row-or-column-in-table-in-vsto-and-aspose-slides/
---

## **VSTO**
A continuación, se muestra el código para eliminar filas o columnas de una tabla usando la presentación de VSTO:

``` csharp

    string FileName = "Eliminación de fila o columna en la tabla.pptx";

   Presentation pres = Application.Presentations.Open(FileName);

   //Obtener la primera diapositiva

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
Aspose.Slides para .NET ha proporcionado la API más simple para crear tablas de la manera más sencilla. Para crear una tabla en una diapositiva y realizar algunas operaciones básicas en la tabla, siga los pasos a continuación:

- Cree una instancia de la clase Presentation
- Obtenga la referencia de una diapositiva utilizando su índice
- Defina un arreglo de columnas con ancho
- Defina un arreglo de filas con altura
- Agregue una tabla a la diapositiva utilizando el método AddTable expuesto por el objeto IShapes
- Eliminar fila de la tabla
- Eliminar columna de la tabla
- Escriba la presentación modificada como un archivo PPTX

``` csharp

   string FileName = "Eliminación de fila o columna en la tabla.pptx";

   Presentation MyPresentation = new Presentation(FileName);

   //Obtener la primera diapositiva

   ISlide sld = MyPresentation.Slides[0];

   foreach (IShape shp in sld.Shapes)

   if (shp is ITable)

   {

      ITable tbl = (ITable)shp;

      tbl.Rows.RemoveAt(0, false);

   }

   MyPresentation.Save(FileName,Export.SaveFormat.Pptx);

``` 
## **Descargar Código en Ejecución**
- [Codeplex](https://asposevsto.codeplex.com/releases/view/616670)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Descargar Código de Ejemplo**
- [Codeplex](https://asposevsto.codeplex.com/SourceControl/latest#Aspose.Slides Vs VSTO Slides/Eliminación de fila o columna en la tabla/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Eliminación%20de%20fila%20o%20columna%20en%20la%20tabla)