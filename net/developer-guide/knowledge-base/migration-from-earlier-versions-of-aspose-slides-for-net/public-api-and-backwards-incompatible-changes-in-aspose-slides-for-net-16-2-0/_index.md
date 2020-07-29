---
title: Public API and Backwards Incompatible Changes in Aspose.Slides for .NET 16.2.0
type: docs
weight: 230
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/
---

{{% alert color="primary" %}} 

This page lists all [added](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) or [removed](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) classes, methods, properties and so on, and other changes introduced with the Aspose.Slides for .NET 16.2.0 API.

{{% /alert %}} 
## **Public API Changes**
#### **Properties UpdateDateTimeFields and UpdateSlideNumberFields have been removed**
Properties UpdateDateTimeFields and UpdateSlideNumberFields have been removed from Aspose.Slides.Presentation class and from Aspose.Slides.IPresentation interface.
The Text property of Aspose.Slides.TextFrame, Paragraph, Portion classes and Aspose.Slides.ITextFrame, IParagraph, IPortion interfaces returns text with updated "datetime" fields.
Also properties Presentation.DocumentProperties.CreatedTime, LastSavedTime and LastPrinted became read-only.
#### **Enum Slides.Charts.CategoryAxisType has been switched to public**
Used in IAxis.CategoryAxisType and Axis.CategoryAxisType properties to determine category axis type.
CategoryAxisType.Auto - category axis type will be determined automatically during serialization (this behavior is not implemented now)
CategoryAxisType.Text - category axis type is Text
CategoryAxisType.Date - category axis type is DateTime
#### **Fast text extraction**
The new static method GetPresentationText has been added to Presentation class. There're two overloads for this method:

{{< highlight java >}}

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

{{< /highlight >}}

The ExtractionMode enum argument indicates the mode to organize the output of text result and can be set to the following values:
Unarranged - The raw text with no respect to position on the slide
Arranged - The text is positioned in the same order as on the slide

Unarranged mode can be used when speed is critical, it's faster than Arranged mode.

PresentationText represents the raw text extracted from the presentation. It contains a SlidesText property from Aspose.Slides.Util namespace which returns an array of ISlideText objects. Every object represent the text on the corresponding slide. ISlideText object have the following properties:

ISlideText.Text - The text on the slide's shapes
ISlideText.MasterText - The text on the master page's shapes for this slide
ISlideText.LayoutText - The text on the layout page's shapes for this slide
ISlideText.NotesText - The text on the notes page's shapes for this slide

There's also a SlideText class which implements the ISlideText interface.

The new API can be used like this:

{{< highlight java >}}

 PresentationText text1 = Presentation.GetPresentationText("presentation.ppt");

Console.WriteLine(text1.SlidesText[0].Text);

Console.WriteLine(text1.SlidesText[0].LayoutText);

Console.WriteLine(text1.SlidesText[0].MasterText);

Console.WriteLine(text1.SlidesText[0].NotesText);

PresentationText text2 = Presentation.GetPresentationText("presentation.pptx", ExtractionMode.Unarranged)

{{< /highlight >}}
#### **ILegacyDiagram interface and LegacyDiagram class have been added**
Interface Aspose.Slides.ILegacyDiagram and class Aspose.Slides.LegacyDiagram have added to represent legacy diagram object. Legacy diagram object is an old format of diagrams from PowerPoint 97-2003.
New class provides methods to convert legacy diagram to modern editable SmartArt object or to editable GroupShape.
#### **New Aspose.Slides.TextAlignment enum membed added (JustifyLow)**
A new member of TextAlignment enum member has been added:
JustifyLow - Kashida justify low.
#### **New properties for Aspose.Slides.IOleObjectFrame and OleObjectFrame**
A new properties has been added to IOleObjectFrame interface and OleObjectFrame class implementing this interface. These properties using to provide information about an object embedded into the presentation:
EmbeddedFileExtension - Returns the file extension for the current embedded object or empty string if object is not a link
EmbeddedFileLabel - Returns the file name of embedded OLE object
EmbeddedFileName - Returns the path of embedded OLE object
#### **New property CategoryAxisType has been added to IAxis and Axis classes**
Property CategoryAxisType specifies type of category axis.

{{< highlight java >}}

 using (Presentation pres = new Presentation(sourcePptxFileName))

{

   IChart chart = pres.Slides[0].Shapes[0] as IChart;

   chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;

   chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;

   chart.Axes.HorizontalAxis.MajorUnit = 1;

   chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;

   pres.Save(pptxOutPath, SaveFormat.Pptx);

}

{{< /highlight >}}
#### **New property ShowLabelAsDataCallout has been added to DataLabelFormat class and IDataLabelFormat interface**
Property ShowLabelAsDataCallout determines either specified chart's data label will be displayed as data callout or as data label.

{{< highlight java >}}

 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 500, 400);

   chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

   chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

   chart.ChartData.Series[0].Labels[2].DataLabelFormat.ShowLabelAsDataCallout = false;

   pres.Save(pptxFileName, SaveFormat.Pptx);

}

{{< /highlight >}}
#### **Property DrawSlidesFrame has been added to PdfOptions and XpsOptions**
Boolean property DrawSlidesFrame has been added to interfaces Aspose.Slides.Export.IPdfOptions, Aspose.Slides.Export.IXpsOptions and to related classes Aspose.Slides.Export.PdfOptions, Aspose.Slides.Export.XpsOptions.
The black frame around each slide will be drawn if this property set 'true'.

{{< highlight java >}}

 using (Presentation pres = new Presentation("input.pptx"))

{

    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });

}

{{< /highlight >}}
