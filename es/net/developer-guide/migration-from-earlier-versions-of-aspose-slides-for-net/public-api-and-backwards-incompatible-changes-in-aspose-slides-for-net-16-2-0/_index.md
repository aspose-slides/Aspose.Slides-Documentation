---
title: Cambios en la API pública y incompatibilidades hacia atrás en Aspose.Slides para .NET 16.2.0
linktitle: Aspose.Slides para .NET 16.2.0
type: docs
weight: 230
url: /es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/
keywords:
- migración
- código heredado
- código moderno
- enfoque heredado
- enfoque moderno
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Revisa las actualizaciones de la API pública y los cambios incompatibles en Aspose.Slides para .NET para migrar sin problemas tus soluciones de presentaciones PowerPoint PPT, PPTX y ODP."
---
{{% alert color="info" %}} 

Esta página enumera todas las clases, métodos, propiedades, etc. [añadidos](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) o [eliminados](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/), y otros cambios introducidos con la API de Aspose.Slides para .NET 16.2.0.

{{% /alert %}} 
## **Cambios en la API Pública**
#### **Las propiedades UpdateDateTimeFields y UpdateSlideNumberFields han sido eliminadas**
Las propiedades UpdateDateTimeFields y UpdateSlideNumberFields se han eliminado de la clase Aspose.Slides.Presentation y de la interfaz Aspose.Slides.IPresentation.
La propiedad Text de las clases Aspose.Slides.TextFrame, Paragraph, Portion y de las interfaces Aspose.Slides.ITextFrame, IParagraph, IPortion devuelve texto con los campos "datetime" actualizados.
Además, las propiedades Presentation.DocumentProperties.CreatedTime, LastSavedTime y LastPrinted pasaron a ser de solo lectura.
#### **El enum Slides.Charts.CategoryAxisType se ha cambiado a público**
Se utiliza en las propiedades IAxis.CategoryAxisType y Axis.CategoryAxisType para determinar el tipo de eje de categorías.
CategoryAxisType.Auto - el tipo de eje de categorías se determinará automáticamente durante la serialización (este comportamiento no está implementado todavía)
CategoryAxisType.Text - el tipo de eje de categorías es Texto
CategoryAxisType.Date - el tipo de eje de categorías es DateTime
#### **Extracción Rápida de Texto**
Se ha añadido el nuevo método estático GetPresentationText a la clase Presentation. Existen dos sobrecargas de este método:

``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 

El argumento enum ExtractionMode indica el modo de organizar la salida del texto resultante y puede establecerse en los siguientes valores:
Unarranged - El texto sin formato sin respetar la posición en la diapositiva
Arranged - El texto se posiciona en el mismo orden que en la diapositiva

El modo Unarranged puede usarse cuando la velocidad es crítica, es más rápido que el modo Arranged.

PresentationText representa el texto sin formato extraído de la presentación. Contiene una propiedad SlidesText del espacio de nombres Aspose.Slides.Util que devuelve una matriz de objetos ISlideText. Cada objeto representa el texto de la diapositiva correspondiente. El objeto ISlideText tiene las siguientes propiedades:
ISlideText.Text - El texto de las formas de la diapositiva
ISlideText.MasterText - El texto de las formas de la diapositiva maestra para esta diapositiva
ISlideText.LayoutText - El texto de las formas de la diapositiva de diseño para esta diapositiva
ISlideText.NotesText - El texto de las formas de la página de notas para esta diapositiva

También existe una clase SlideText que implementa la interfaz ISlideText.

El nuevo API puede usarse así:

``` csharp
using System;
using Aspose.Slides;

// Extrae el texto sin respetar su posición en la diapositiva (el modo más rápido).
IPresentationText text1 = PresentationFactory.Instance.GetPresentationText(
    "presentation.ppt", TextExtractionArrangingMode.Unarranged);

Console.WriteLine(text1.SlidesText[0].Text);
Console.WriteLine(text1.SlidesText[0].LayoutText);
Console.WriteLine(text1.SlidesText[0].MasterText);
Console.WriteLine(text1.SlidesText[0].NotesText);

// Extrae el texto posicionado en el mismo orden que en la diapositiva.
IPresentationText text2 = PresentationFactory.Instance.GetPresentationText(
    "presentation.pptx", TextExtractionArrangingMode.Arranged);

Console.WriteLine(text2.SlidesText[0].Text);
``` 
#### **Se han añadido la interfaz ILegacyDiagram y la clase LegacyDiagram**
Se ha añadido la interfaz Aspose.Slides.ILegacyDiagram y la clase Aspose.Slides.LegacyDiagram para representar el objeto de diagrama heredado. El objeto de diagrama heredado es un formato antiguo de diagramas de PowerPoint 97-2003.
La nueva clase proporciona métodos para convertir el diagrama heredado en un objeto SmartArt moderno editable o en un GroupShape editable.
#### **Nuevo miembro del enum Aspose.Slides.TextAlignment añadido (JustifyLow)**
Se ha añadido un nuevo miembro al enum TextAlignment:
JustifyLow - Justificación baja de Kashida.
#### **Nuevas propiedades para Aspose.Slides.IOleObjectFrame y OleObjectFrame**
Se han añadido nuevas propiedades a la interfaz IOleObjectFrame y a la clase OleObjectFrame que implementa esta interfaz. Estas propiedades se utilizan para proporcionar información sobre un objeto incrustado en la presentación:
EmbeddedFileExtension - Devuelve la extensión del archivo del objeto incrustado actual o una cadena vacía si el objeto no es un enlace
EmbeddedFileLabel - Devuelve el nombre del archivo del objeto OLE incrustado
EmbeddedFileName - Devuelve la ruta del objeto OLE incrustado
#### **Se ha añadido la nueva propiedad CategoryAxisType a las clases IAxis y Axis**
La propiedad CategoryAxisType especifica el tipo de eje de categorías.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

string sourcePptxFileName = "chart.pptx";
string pptxOutPath = "chart_out.pptx";

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
#### **Se ha añadido la nueva propiedad ShowLabelAsDataCallout a la clase DataLabelFormat y a la interfaz IDataLabelFormat**
La propiedad ShowLabelAsDataCallout determina si la etiqueta de datos del gráfico especificado se mostrará como una llamada de datos o como una etiqueta de datos.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

string pptxFileName = "callout_labels.pptx";

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
using Aspose.Slides;
using Aspose.Slides.Export;


 using (Presentation pres = new Presentation("input.pptx"))

{

    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });

}
```