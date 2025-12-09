---
title: Öffentliche API und rückwärtsinkompatible Änderungen in Aspose.Slides für .NET 16.2.0
linktitle: Aspose.Slides für .NET 16.2.0
type: docs
weight: 230
url: /de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/
keywords:
- Migration
- Legacy-Code
- Moderner Code
- Legacy-Ansatz
- Moderner Ansatz
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Überblick über öffentliche API-Updates und breaking changes in Aspose.Slides für .NET, um Ihre PowerPoint PPT, PPTX und ODP Präsentationslösungen reibungslos zu migrieren."
---

{{% alert color="primary" %}} 

This page lists all [hinzugefügt](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) or [entfernt](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) classes, methods, properties and so on, and other changes introduced with the Aspose.Slides for .NET 16.2.0 API.

{{% /alert %}} 
## **Öffentliche API-Änderungen**
#### **Eigenschaften UpdateDateTimeFields und UpdateSlideNumberFields wurden entfernt**
Eigenschaften UpdateDateTimeFields und UpdateSlideNumberFields wurden aus der Aspose.Slides.Presentation-Klasse und aus dem Aspose.Slides.IPresentation-Interface entfernt.
Die Text-Eigenschaft von Aspose.Slides.TextFrame, Paragraph, Portion Klassen und Aspose.Slides.ITextFrame, IParagraph, IPortion Schnittstellen gibt Text mit aktualisierten "datetime"-Feldern zurück.
Auch die Eigenschaften Presentation.DocumentProperties.CreatedTime, LastSavedTime und LastPrinted wurden schreibgeschützt.
#### **Enum Slides.Charts.CategoryAxisType ist jetzt öffentlich**
Wird in den Eigenschaften IAxis.CategoryAxisType und Axis.CategoryAxisType verwendet, um den Typ der Kategorie-Achse zu bestimmen.
CategoryAxisType.Auto - Der Typ der Kategorie-Achse wird während der Serialisierung automatisch ermittelt (dieses Verhalten ist derzeit nicht implementiert)
CategoryAxisType.Text - Der Typ der Kategorie-Achse ist Text
CategoryAxisType.Date - Der Typ der Kategorie-Achse ist DateTime
#### **Schnelle Textextraktion**
Die neue statische Methode GetPresentationText wurde zur Presentation-Klasse hinzugefügt. Es gibt zwei Überladungen für diese Methode:

``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 

Das ExtractionMode-Enum-Argument gibt den Modus zur Anordnung des Textergebnisses an und kann auf folgende Werte gesetzt werden:
Unarranged - Der Rohtext ohne Berücksichtigung der Position auf der Folie
Arranged - Der Text ist in derselben Reihenfolge wie auf der Folie positioniert

Der Unarranged-Modus kann verwendet werden, wenn Geschwindigkeit entscheidend ist; er ist schneller als der Arranged-Modus.

PresentationText repräsentiert den aus der Präsentation extrahierten Rohtext. Es enthält eine SlidesText-Eigenschaft aus dem Namespace Aspose.Slides.Util, die ein Array von ISlideText-Objekten zurückgibt. Jedes Objekt stellt den Text der entsprechenden Folie dar. Das ISlideText-Objekt besitzt die folgenden Eigenschaften:

ISlideText.Text - Der Text der Formen auf der Folie
ISlideText.MasterText - Der Text der Formen auf der Master-Seite für diese Folie
ISlideText.LayoutText - Der Text der Formen auf der Layout-Seite für diese Folie
ISlideText.NotesText - Der Text der Formen auf der Notiz-Seite für diese Folie

Es gibt außerdem eine SlideText-Klasse, die das ISlideText-Interface implementiert.

Die neue API kann wie folgt verwendet werden:

``` csharp

 PresentationText text1 = Presentation.GetPresentationText("presentation.ppt");

Console.WriteLine(text1.SlidesText[0].Text);

Console.WriteLine(text1.SlidesText[0].LayoutText);

Console.WriteLine(text1.SlidesText[0].MasterText);

Console.WriteLine(text1.SlidesText[0].NotesText);

PresentationText text2 = Presentation.GetPresentationText("presentation.pptx", ExtractionMode.Unarranged)

``` 
#### **Interface ILegacyDiagram und Klasse LegacyDiagram wurden hinzugefügt**
Das Interface Aspose.Slides.ILegacyDiagram und die Klasse Aspose.Slides.LegacyDiagram wurden hinzugefügt, um ein Legacy-Diagrammobjekt zu repräsentieren. Das Legacy-Diagrammobjekt ist ein altes Format von Diagrammen aus PowerPoint 97-2003.
Die neue Klasse bietet Methoden zum Konvertieren des Legacy-Diagramms in ein modernes, editierbares SmartArt-Objekt oder in ein editierbares GroupShape.
#### **Neues Aspose.Slides.TextAlignment-Enum-Mitglied hinzugefügt (JustifyLow)**
Ein neues Mitglied des TextAlignment-Enums wurde hinzugefügt:
JustifyLow - Kashida-Justierung niedrig.
#### **Neue Eigenschaften für Aspose.Slides.IOleObjectFrame und OleObjectFrame**
Neue Eigenschaften wurden zum Interface IOleObjectFrame und zur Klasse OleObjectFrame, die dieses Interface implementiert, hinzugefügt. Diese Eigenschaften werden verwendet, um Informationen über ein in die Präsentation eingebettetes Objekt bereitzustellen:
EmbeddedFileExtension - Gibt die Dateierweiterung des aktuellen eingebetteten Objekts zurück oder einen leeren String, wenn das Objekt kein Link ist
EmbeddedFileLabel - Gibt den Dateinamen des eingebetteten OLE-Objekts zurück
EmbeddedFileName - Gibt den Pfad des eingebetteten OLE-Objekts zurück
#### **Neue Eigenschaft CategoryAxisType wurde zu IAxis- und Axis-Klassen hinzugefügt**
Die Eigenschaft CategoryAxisType gibt den Typ der Kategorie-Achse an.

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
#### **Neue Eigenschaft ShowLabelAsDataCallout wurde zur DataLabelFormat-Klasse und zum IDataLabelFormat-Interface hinzugefügt**
Die Eigenschaft ShowLabelAsDataCallout bestimmt, ob das Datenbeschriftungs-Label eines Diagramms als Daten-Callout oder als Daten-Label angezeigt wird.

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
#### **Eigenschaft DrawSlidesFrame wurde zu PdfOptions und XpsOptions hinzugefügt**
Die boolesche Eigenschaft DrawSlidesFrame wurde zu den Interfaces Aspose.Slides.Export.IPdfOptions, Aspose.Slides.Export.IXpsOptions und zu den zugehörigen Klassen Aspose.Slides.Export.PdfOptions, Aspose.Slides.Export.XpsOptions hinzugefügt.
Der schwarze Rahmen um jede Folie wird gezeichnet, wenn diese Eigenschaft auf "true" gesetzt ist.

``` csharp

 using (Presentation pres = new Presentation("input.pptx"))

{

    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });

}

```