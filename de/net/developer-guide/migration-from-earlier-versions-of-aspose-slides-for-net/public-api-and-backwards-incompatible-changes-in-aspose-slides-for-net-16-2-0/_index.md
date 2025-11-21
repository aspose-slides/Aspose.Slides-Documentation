---
title: Öffentliche API- und rückwärtsinkompatible Änderungen in Aspose.Slides für .NET 16.2.0
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
description: "Überblick über öffentliche API-Updates und kritische Änderungen in Aspose.Slides für .NET, um Ihre PowerPoint‑PPT-, PPTX‑ und ODP‑Präsentationslösungen reibungslos zu migrieren."
---

{{% alert color="primary" %}} 
Diese Seite listet alle [hinzugefügt](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) oder [entfernt](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) Klassen, Methoden, Eigenschaften usw. sowie weitere Änderungen, die mit der Aspose.Slides for .NET 16.2.0 API eingeführt wurden.
{{% /alert %}} 
## **Öffentliche API-Änderungen**
#### **Properties UpdateDateTimeFields und UpdateSlideNumberFields wurden entfernt**
Die Eigenschaften UpdateDateTimeFields und UpdateSlideNumberFields wurden aus der Klasse Aspose.Slides.Presentation und aus dem Interface Aspose.Slides.IPresentation entfernt.
Die Text‑Eigenschaft von Aspose.Slides.TextFrame, Paragraph, Portion sowie den Interfaces Aspose.Slides.ITextFrame, IParagraph, IPortion gibt Text mit aktualisierten „datetime“-Feldern zurück.
Außerdem sind die Eigenschaften Presentation.DocumentProperties.CreatedTime, LastSavedTime und LastPrinted jetzt schreibgeschützt.
#### **Enum Slides.Charts.CategoryAxisType ist jetzt öffentlich**
Wird in den Eigenschaften IAxis.CategoryAxisType und Axis.CategoryAxisType verwendet, um den Typ der Kategorienachse zu bestimmen.
CategoryAxisType.Auto – Der Typ der Kategorienachse wird automatisch während der Serialisierung ermittelt (dieses Verhalten ist derzeit nicht implementiert)  
CategoryAxisType.Text – Der Typ der Kategorienachse ist Text  
CategoryAxisType.Date – Der Typ der Kategorienachse ist DateTime
#### **Schnelle Textextraktion**
Die neue statische Methode GetPresentationText wurde zur Klasse Presentation hinzugefügt. Es gibt zwei Überladungen dieser Methode:

``` csharp
 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)
``` 

Das Enum‑Argument ExtractionMode gibt an, wie das Ergebnis‑Text‑Output organisiert wird und kann folgende Werte annehmen:
Unarranged – Der Rohtext ohne Rücksicht auf die Position auf der Folie  
Arranged – Der Text ist in derselben Reihenfolge wie auf der Folie angeordnet

Der Modus Unarranged kann verwendet werden, wenn Geschwindigkeit entscheidend ist; er ist schneller als der Modus Arranged.

PresentationText repräsentiert den aus der Präsentation extrahierten Rohtext. Es enthält die Eigenschaft SlidesText aus dem Namespace Aspose.Slides.Util, die ein Array von ISlideText‑Objekten zurückgibt. Jedes Objekt repräsentiert den Text der jeweiligen Folie. Das ISlideText‑Objekt hat folgende Eigenschaften:

ISlideText.Text – Der Text der Formen auf der Folie  
ISlideText.MasterText – Der Text der Formen auf der Master‑Seite für diese Folie  
ISlideText.LayoutText – Der Text der Formen auf der Layout‑Seite für diese Folie  
ISlideText.NotesText – Der Text der Formen auf der Notizseite für diese Folie

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
#### **ILegacyDiagram‑Interface und LegacyDiagram‑Klasse wurden hinzugefügt**
Das Interface Aspose.Slides.ILegacyDiagram und die Klasse Aspose.Slides.LegacyDiagram wurden hinzugefügt, um Legacy‑Diagramm‑Objekte zu repräsentieren. Legacy‑Diagramme sind alte Diagrammformate aus PowerPoint 97‑2003.
Die neue Klasse bietet Methoden, um ein Legacy‑Diagramm in ein modernes, editierbares SmartArt‑Objekt oder in ein editierbares GroupShape zu konvertieren.
#### **Neues Aspose.Slides.TextAlignment‑Enum‑Mitglied hinzugefügt (JustifyLow)**
Ein neues Mitglied des Enums TextAlignment wurde hinzugefügt:
JustifyLow – Kashida‑Justierung niedrig.
#### **Neue Eigenschaften für Aspose.Slides.IOleObjectFrame und OleObjectFrame**
Neue Eigenschaften wurden dem Interface IOleObjectFrame und der Klasse OleObjectFrame, die dieses Interface implementiert, hinzugefügt. Diese Eigenschaften dienen dazu, Informationen über ein in die Präsentation eingebettetes Objekt bereitzustellen:
EmbeddedFileExtension – Gibt die Dateierweiterung des aktuellen eingebetteten Objekts zurück oder einen leeren String, wenn das Objekt kein Link ist  
EmbeddedFileLabel – Gibt den Dateinamen des eingebetteten OLE‑Objekts zurück  
EmbeddedFileName – Gibt den Pfad des eingebetteten OLE‑Objekts zurück
#### **Neue Eigenschaft CategoryAxisType wurde zu IAxis‑ und Axis‑Klassen hinzugefügt**
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
Die Eigenschaft ShowLabelAsDataCallout bestimmt, ob das Datenbeschriftungs‑Label eines Diagramms als Daten‑Callout oder als Daten‑Label angezeigt wird.

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
Die boolesche Eigenschaft DrawSlidesFrame wurde zu den Interfaces Aspose.Slides.Export.IPdfOptions, Aspose.Slides.Export.IXpsOptions sowie zu den zugehörigen Klassen Aspose.Slides.Export.PdfOptions und Aspose.Slides.Export.XpsOptions hinzugefügt.
Der schwarze Rahmen um jede Folie wird gezeichnet, wenn diese Eigenschaft auf „true“ gesetzt ist.

``` csharp
 using (Presentation pres = new Presentation("input.pptx"))
{
    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });
}
```