---
title: Öffentliche API und rückwärts inkompatible Änderungen in Aspose.Slides für .NET 16.2.0
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
description: "Überprüfen Sie die öffentlichen API-Updates und breaking changes in Aspose.Slides für .NET, um Ihre PowerPoint PPT, PPTX und ODP-Präsentationslösungen reibungslos zu migrieren."
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) oder [entfernten](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) Klassen, Methoden, Eigenschaften und so weiter sowie weitere Änderungen auf, die mit der Aspose.Slides für .NET 16.2.0 API eingeführt wurden.

{{% /alert %}} 
## **Öffentliche API-Änderungen**
#### **Die Eigenschaften UpdateDateTimeFields und UpdateSlideNumberFields wurden entfernt**
Die Eigenschaften UpdateDateTimeFields und UpdateSlideNumberFields wurden aus der Klasse Aspose.Slides.Presentation und aus dem Interface Aspose.Slides.IPresentation entfernt.
Die Eigenschaft Text der Klassen Aspose.Slides.TextFrame, Paragraph, Portion und der Interfaces Aspose.Slides.ITextFrame, IParagraph, IPortion liefert Text mit aktualisierten „datetime“-Feldern.
Auch die Eigenschaften Presentation.DocumentProperties.CreatedTime, LastSavedTime und LastPrinted wurden schreibgeschützt.
#### **Der Enum Slides.Charts.CategoryAxisType wurde öffentlich gemacht**
Wird in den Eigenschaften IAxis.CategoryAxisType und Axis.CategoryAxisType verwendet, um den Typ der Kategorienachse zu bestimmen.
CategoryAxisType.Auto - Der Typ der Kategorienachse wird während der Serialisierung automatisch bestimmt (dieses Verhalten ist derzeit nicht implementiert)
CategoryAxisType.Text - Der Typ der Kategorienachse ist Text
CategoryAxisType.Date - Der Typ der Kategorienachse ist DateTime
#### **Schnelle Textextraktion**
The new static method GetPresentationText has been added to the Presentation class. There are two overloads for this method:

``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 

Das Enum-Argument ExtractionMode gibt den Modus zur Anordnung des Textausgabeergebnisses an und kann auf die folgenden Werte gesetzt werden:
Unarranged - Der Rohtext ohne Rücksicht auf die Position auf der Folie
Arranged - Der Text ist in derselben Reihenfolge positioniert wie auf der Folie

Der Unarranged-Modus kann verwendet werden, wenn Geschwindigkeit entscheidend ist; er ist schneller als der Arranged-Modus.

PresentationText stellt den aus der Präsentation extrahierten Rohtext dar. Es enthält die Eigenschaft SlidesText aus dem Namespace Aspose.Slides.Util, die ein Array von ISlideText-Objekten zurückgibt. Jedes Objekt repräsentiert den Text der entsprechenden Folie. ISlideText-Objekte besitzen die folgenden Eigenschaften:
ISlideText.Text - Der Text der Formen auf der Folie
ISlideText.MasterText - Der Text der Formen auf der Masterseite für diese Folie
ISlideText.LayoutText - Der Text der Formen auf der Layoutseite für diese Folie
ISlideText.NotesText - Der Text der Formen auf der Notizenseite für diese Folie

Es gibt außerdem die Klasse SlideText, die das Interface ISlideText implementiert.

Die neue API kann wie folgt verwendet werden:

``` csharp

 PresentationText text1 = Presentation.GetPresentationText("presentation.ppt");

Console.WriteLine(text1.SlidesText[0].Text);

Console.WriteLine(text1.SlidesText[0].LayoutText);

Console.WriteLine(text1.SlidesText[0].MasterText);

Console.WriteLine(text1.SlidesText[0].NotesText);

PresentationText text2 = Presentation.GetPresentationText("presentation.pptx", ExtractionMode.Unarranged)

``` 
#### **Das Interface ILegacyDiagram und die Klasse LegacyDiagram wurden hinzugefügt**
Das Interface Aspose.Slides.ILegacyDiagram und die Klasse Aspose.Slides.LegacyDiagram wurden hinzugefügt, um ein Legacy-Diagrammobjekt zu repräsentieren. Das Legacy-Diagrammobjekt ist ein altes Diagrammformat aus PowerPoint 97-2003.
Die neue Klasse stellt Methoden bereit, um ein Legacy-Diagramm in ein modernes editierbares SmartArt-Objekt oder in ein editierbares GroupShape zu konvertieren.
#### **Neues Mitglied im Aspose.Slides.TextAlignment-Enum hinzugefügt (JustifyLow)**
Ein neues Mitglied des Enums TextAlignment wurde hinzugefügt: JustifyLow – Kashida-Justify low.
#### **Neue Eigenschaften für Aspose.Slides.IOleObjectFrame und OleObjectFrame**
Eine neue Eigenschaft wurde zum Interface IOleObjectFrame und zur Klasse OleObjectFrame, die dieses Interface implementiert, hinzugefügt. Diese Eigenschaften werden verwendet, um Informationen über ein in die Präsentation eingebettetes Objekt bereitzustellen:
EmbeddedFileExtension – Gibt die Dateierweiterung des aktuellen eingebetteten Objekts zurück oder einen leeren String, wenn das Objekt kein Link ist
EmbeddedFileLabel – Gibt den Dateinamen des eingebetteten OLE-Objekts zurück
EmbeddedFileName – Gibt den Pfad des eingebetteten OLE-Objekts zurück
#### **Neue Eigenschaft CategoryAxisType wurde zu den Klassen IAxis und Axis hinzugefügt**
Die Eigenschaft CategoryAxisType gibt den Typ der Kategorienachse an.

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
#### **Neue Eigenschaft ShowLabelAsDataCallout wurde zur Klasse DataLabelFormat und zum Interface IDataLabelFormat hinzugefügt**
Die Eigenschaft ShowLabelAsDataCallout bestimmt, ob das Datenbeschriftungselement des angegebenen Diagramms als Datencallout oder als Datenbeschriftung angezeigt wird.

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
Die boolesche Eigenschaft DrawSlidesFrame wurde zu den Interfaces Aspose.Slides.Export.IPdfOptions, Aspose.Slides.Export.IXpsOptions und zu den zugehörigen Klassen Aspose.Slides.Export.PdfOptions, Aspose.Slides.Export.XpsOptions hinzugefügt. Ein schwarzer Rahmen um jede Folie wird gezeichnet, wenn diese Eigenschaft auf 'true' gesetzt ist.

``` csharp

 using (Presentation pres = new Presentation("input.pptx"))

{

    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });

}

```