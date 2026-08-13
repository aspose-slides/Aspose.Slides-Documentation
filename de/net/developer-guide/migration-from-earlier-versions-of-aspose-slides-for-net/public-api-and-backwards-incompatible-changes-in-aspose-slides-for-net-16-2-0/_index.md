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
description: "Überblick über öffentliche API-Updates und inkompatible Änderungen in Aspose.Slides für .NET, um Ihre PowerPoint-PPT, PPTX und ODP-Präsentationslösungen reibungslos zu migrieren."
---
{{% alert color="info" %}} 

Diese Seite listet alle [hinzugefügt](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) oder [entfernt](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) Klassen, Methoden, Eigenschaften usw. sowie weitere Änderungen, die mit der Aspose.Slides for .NET 16.2.0 API eingeführt wurden.

{{% /alert %}} 
## **Öffentliche API-Änderungen**
#### **Eigenschaften UpdateDateTimeFields und UpdateSlideNumberFields wurden entfernt**
Die Eigenschaften UpdateDateTimeFields und UpdateSlideNumberFields wurden aus der Klasse Aspose.Slides.Presentation und aus dem Interface Aspose.Slides.IPresentation entfernt.
Die Text‑Eigenschaft der Klassen Aspose.Slides.TextFrame, Paragraph, Portion sowie der Interfaces Aspose.Slides.ITextFrame, IParagraph, IPortion gibt Text mit aktualisierten „datetime“-Feldern zurück.
Außerdem wurden die Eigenschaften Presentation.DocumentProperties.CreatedTime, LastSavedTime und LastPrinted schreibgeschützt.

#### **Enum Slides.Charts.CategoryAxisType wurde öffentlich gemacht**
Wird in den Eigenschaften IAxis.CategoryAxisType und Axis.CategoryAxisType verwendet, um den Typ der Kategorienachse zu bestimmen.
CategoryAxisType.Auto - Der Typ der Kategorienachse wird während der Serialisierung automatisch bestimmt (dieses Verhalten ist derzeit nicht implementiert)  
CategoryAxisType.Text - Der Typ der Kategorienachse ist Text  
CategoryAxisType.Date - Der Typ der Kategorienachse ist DateTime

#### **Schnelle Textextraktion**
Die neue statische Methode GetPresentationText wurde zur Klasse Presentation hinzugefügt. Es gibt zwei Überladungen für diese Methode:

``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 

Das Enumeration-Argument ExtractionMode gibt den Modus an, in dem das Text Ergebnis organisiert wird, und kann auf die folgenden Werte gesetzt werden:
Unarranged - Der Rohtext ohne Berücksichtigung der Position auf der Folie  
Arranged - Der Text ist in derselben Reihenfolge wie auf der Folie angeordnet

Der Unarranged-Modus kann verwendet werden, wenn Geschwindigkeit entscheidend ist; er ist schneller als der Arranged-Modus.

PresentationText repräsentiert den Rohtext, der aus der Präsentation extrahiert wurde. Sie enthält eine SlidesText‑Eigenschaft aus dem Namespace Aspose.Slides.Util, die ein Array von ISlideText‑Objekten zurückgibt. Jedes Objekt stellt den Text auf der entsprechenden Folie dar. ISlideText‑Objekte haben die folgenden Eigenschaften:
ISlideText.Text - Der Text auf den Formen der Folie  
ISlideText.MasterText - Der Text auf den Formen der Master‑Seite für diese Folie  
ISlideText.LayoutText - Der Text auf den Formen der Layout‑Seite für diese Folie  
ISlideText.NotesText - Der Text auf den Formen der Notizenseite für diese Folie

Es gibt außerdem eine SlideText‑Klasse, die das ISlideText‑Interface implementiert.

Die neue API kann wie folgt verwendet werden:

``` csharp
using System;
using Aspose.Slides;

// Extrahiere den Text ohne Rücksicht auf seine Position auf der Folie (der schnellste Modus).
IPresentationText text1 = PresentationFactory.Instance.GetPresentationText(
    "presentation.ppt", TextExtractionArrangingMode.Unarranged);

Console.WriteLine(text1.SlidesText[0].Text);
Console.WriteLine(text1.SlidesText[0].LayoutText);
Console.WriteLine(text1.SlidesText[0].MasterText);
Console.WriteLine(text1.SlidesText[0].NotesText);

// Extrahiere den Text in derselben Reihenfolge wie auf der Folie.
IPresentationText text2 = PresentationFactory.Instance.GetPresentationText(
    "presentation.pptx", TextExtractionArrangingMode.Arranged);

Console.WriteLine(text2.SlidesText[0].Text);
``` 

#### **ILegacyDiagram Interface und LegacyDiagram Klasse wurden hinzugefügt**
Das Interface Aspose.Slides.ILegacyDiagram und die Klasse Aspose.Slides.LegacyDiagram wurden hinzugefügt, um ein Legacy‑Diagrammobjekt zu repräsentieren. Ein Legacy‑Diagrammobjekt ist ein altes Diagrammformat aus PowerPoint 97‑2003.
Die neue Klasse stellt Methoden bereit, um ein Legacy‑Diagramm in ein modernes editierbares SmartArt‑Objekt oder in ein editierbares GroupShape zu konvertieren.

#### **Neues Aspose.Slides.TextAlignment‑Enum‑Member hinzugefügt (JustifyLow)**
Ein neues Mitglied des TextAlignment‑Enums wurde hinzugefügt: JustifyLow – Kashida‑Justierung niedrig.

#### **Neue Eigenschaften für Aspose.Slides.IOleObjectFrame und OleObjectFrame**
Neue Eigenschaften wurden dem Interface IOleObjectFrame und der Klasse OleObjectFrame, die dieses Interface implementieren, hinzugefügt. Diese Eigenschaften werden verwendet, um Informationen über ein in die Präsentation eingebettetes Objekt bereitzustellen:
EmbeddedFileExtension - Gibt die Dateierweiterung des aktuellen eingebetteten Objekts zurück oder einen leeren String, wenn das Objekt kein Link ist  
EmbeddedFileLabel - Gibt den Dateinamen des eingebetteten OLE‑Objekts zurück  
EmbeddedFileName - Gibt den Pfad des eingebetteten OLE‑Objekts zurück

#### **Neue Eigenschaft CategoryAxisType wurde zu IAxis‑ und Axis‑Klassen hinzugefügt**
Die Eigenschaft CategoryAxisType gibt den Typ der Kategorienachse an.

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
#### **Neue Eigenschaft ShowLabelAsDataCallout wurde zur DataLabelFormat‑Klasse und zum IDataLabelFormat‑Interface hinzugefügt**
Die Eigenschaft ShowLabelAsDataCallout bestimmt, ob das Datenbeschriftungselement eines angegebenen Diagramms als Datencallout oder als Datenbeschriftung angezeigt wird.

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
#### **Eigenschaft DrawSlidesFrame wurde zu PdfOptions und XpsOptions hinzugefügt**
Die boolesche Eigenschaft DrawSlidesFrame wurde zu den Interfaces Aspose.Slides.Export.IPdfOptions, Aspose.Slides.Export.IXpsOptions sowie zu den zugehörigen Klassen Aspose.Slides.Export.PdfOptions und Aspose.Slides.Export.XpsOptions hinzugefügt. Der schwarze Rahmen um jede Folie wird gezeichnet, wenn diese Eigenschaft auf „true“ gesetzt ist.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


 using (Presentation pres = new Presentation("input.pptx"))

{

    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });

}
```