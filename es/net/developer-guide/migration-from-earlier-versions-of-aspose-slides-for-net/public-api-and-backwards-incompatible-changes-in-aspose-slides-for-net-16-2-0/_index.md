---
title: API pública y cambios incompatibles hacia atrás en Aspose.Slides para .NET 16.2.0
type: docs
weight: 230
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/
---

{{% alert color="primary" %}} 

Esta página lista todas las clases, métodos, propiedades, etc. [añadidos](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) o [eliminados](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) y otros cambios introducidos con la API de Aspose.Slides para .NET 16.2.0.

{{% /alert %}} 
## **Cambios en la API pública**
#### **Se han eliminado las propiedades UpdateDateTimeFields y UpdateSlideNumberFields**
Las propiedades UpdateDateTimeFields y UpdateSlideNumberFields se han eliminado de la clase Aspose.Slides.Presentation y de la interfaz Aspose.Slides.IPresentation.
La propiedad Text de las clases Aspose.Slides.TextFrame, Paragraph, Portion y las interfaces Aspose.Slides.ITextFrame, IParagraph, IPortion devuelve texto con campos "datetime" actualizados.
Además, las propiedades Presentation.DocumentProperties.CreatedTime, LastSavedTime y LastPrinted se convirtieron en solo lectura.
#### **El enum Slides.Charts.CategoryAxisType ha sido convertido a público**
Utilizado en las propiedades IAxis.CategoryAxisType y Axis.CategoryAxisType para determinar el tipo de eje de categoría.
CategoryAxisType.Auto - el tipo de eje de categoría será determinado automáticamente durante la serialización (comportamiento no implementado actualmente)
CategoryAxisType.Text - el tipo de eje de categoría es Texto
CategoryAxisType.Date - el tipo de eje de categoría es DateTime
#### **Extracción rápida de texto**
Se ha añadido el nuevo método estático GetPresentationText a la clase Presentation. Hay dos sobrecargas para este método:

``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 

El argumento del enum ExtractionMode indica el modo para organizar el resultado de texto y puede establecerse en los siguientes valores:
No organizado - El texto sin organización respecto a la posición en la diapositiva
Organizado - El texto está posicionado en el mismo orden que en la diapositiva

El modo no organizado puede usarse cuando la velocidad es crítica, es más rápido que el modo organizado.

PresentationText representa el texto en bruto extraído de la presentación. Contiene una propiedad SlidesText del espacio de nombres Aspose.Slides.Util que devuelve un array de objetos ISlideText. Cada objeto representa el texto en la diapositiva correspondiente. El objeto ISlideText tiene las siguientes propiedades:

ISlideText.Text - El texto en las formas de la diapositiva
ISlideText.MasterText - El texto en las formas de la página maestra para esta diapositiva
ISlideText.LayoutText - El texto en las formas de la página de diseño para esta diapositiva
ISlideText.NotesText - El texto en las formas de la página de notas para esta diapositiva

También hay una clase SlideText que implementa la interfaz ISlideText.

La nueva API se puede usar de la siguiente manera:

``` csharp

 PresentationText text1 = Presentation.GetPresentationText("presentation.ppt");

Console.WriteLine(text1.SlidesText[0].Text);

Console.WriteLine(text1.SlidesText[0].LayoutText);

Console.WriteLine(text1.SlidesText[0].MasterText);

Console.WriteLine(text1.SlidesText[0].NotesText);

PresentationText text2 = Presentation.GetPresentationText("presentation.pptx", ExtractionMode.Unarranged)

``` 
#### **Se ha añadido la interfaz ILegacyDiagram y la clase LegacyDiagram**
Se han añadido la interfaz Aspose.Slides.ILegacyDiagram y la clase Aspose.Slides.LegacyDiagram para representar el objeto de diagrama legado. El objeto de diagrama legado es un formato antiguo de diagramas de PowerPoint 97-2003.
La nueva clase proporciona métodos para convertir diagramas heredados a objetos SmartArt editables o a GroupShape editables.
#### **Nuevo miembro añadido al enum Aspose.Slides.TextAlignment (JustifyLow)**
Se ha añadido un nuevo miembro al enum TextAlignment:
JustifyLow - Justificación Kashida baja.
#### **Nuevas propiedades para Aspose.Slides.IOleObjectFrame y OleObjectFrame**
Se han añadido nuevas propiedades a la interfaz IOleObjectFrame y a la clase OleObjectFrame que implementa esta interfaz. Estas propiedades se utilizan para proporcionar información sobre un objeto incrustado en la presentación:
EmbeddedFileExtension - Devuelve la extensión del archivo para el objeto incrustado actual o una cadena vacía si el objeto no es un enlace
EmbeddedFileLabel - Devuelve el nombre del archivo del objeto OLE incrustado
EmbeddedFileName - Devuelve la ruta del objeto OLE incrustado
#### **Se ha añadido una nueva propiedad CategoryAxisType a las clases IAxis y Axis**
La propiedad CategoryAxisType especifica el tipo de eje de categoría.

``` csharp

 using (Presentation pres = new Presentation(sourcePptxFileName))

{

   IChart chart = pres.Slides[0].Shapes[0] as IChart;

   chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;

   chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;

   chart.Axes.HorizontalAxis.MajorUnit = 1;

   chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;

   pres.Save(pptxOutPath, SaveFormat.Pptx);

}

``` 
#### **Se ha añadido una nueva propiedad ShowLabelAsDataCallout a la clase DataLabelFormat y a la interfaz IDataLabelFormat**
La propiedad ShowLabelAsDataCallout determina si la etiqueta de datos del gráfico especificado se mostrará como un llamado de datos o como una etiqueta de datos.

``` csharp

 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 500, 400);

   chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

   chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

   chart.ChartData.Series[0].Labels[2].DataLabelFormat.ShowLabelAsDataCallout = false;

   pres.Save(pptxFileName, SaveFormat.Pptx);

}

``` 
#### **Se ha añadido la propiedad DrawSlidesFrame a PdfOptions y XpsOptions**
Se ha añadido la propiedad booleana DrawSlidesFrame a las interfaces Aspose.Slides.Export.IPdfOptions, Aspose.Slides.Export.IXpsOptions y a las clases relacionadas Aspose.Slides.Export.PdfOptions, Aspose.Slides.Export.XpsOptions.
El marco negro alrededor de cada diapositiva se dibujará si esta propiedad se establece en 'true'.

``` csharp

 using (Presentation pres = new Presentation("input.pptx"))

{

    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });

}

``` 