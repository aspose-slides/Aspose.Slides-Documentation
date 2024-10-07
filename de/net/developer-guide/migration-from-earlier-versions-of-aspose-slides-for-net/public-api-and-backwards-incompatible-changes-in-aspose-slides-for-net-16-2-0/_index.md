---
title: Öffentliche API und nicht rückwärtskompatible Änderungen in Aspose.Slides für .NET 16.2.0
type: docs
weight: 230
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) oder [entfernten](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) Klassen, Methoden, Eigenschaften usw. und andere Änderungen auf, die mit der Aspose.Slides für .NET 16.2.0 API eingeführt wurden.

{{% /alert %}} 
## **Änderungen der öffentlichen API**
#### **Die Eigenschaften UpdateDateTimeFields und UpdateSlideNumberFields wurden entfernt**
Die Eigenschaften UpdateDateTimeFields und UpdateSlideNumberFields wurden aus der Klasse Aspose.Slides.Presentation und aus dem Interface Aspose.Slides.IPresentation entfernt. 
Die Text-Eigenschaft von Aspose.Slides.TextFrame, Paragraph, Portion Klassen und Aspose.Slides.ITextFrame, IParagraph, IPortion Interfaces gibt Text mit aktualisierten "datetime" Feldern zurück.
Außerdem wurden die Eigenschaften Presentation.DocumentProperties.CreatedTime, LastSavedTime und LastPrinted schreibgeschützt.
#### **Enum Slides.Charts.CategoryAxisType wurde auf öffentlich umgeschaltet**
Verwendet in den Eigenschaften IAxis.CategoryAxisType und Axis.CategoryAxisType zur Bestimmung des Typs der Kategoriekurve. 
CategoryAxisType.Auto - Der Typ der Kategoriekurve wird während der Serialisierung automatisch bestimmt (dieses Verhalten ist jetzt nicht implementiert). 
CategoryAxisType.Text - Der Typ der Kategoriekurve ist Text. 
CategoryAxisType.Date - Der Typ der Kategoriekurve ist DateTime. 
#### **Schnelle Textextraktion**
Die neue statische Methode GetPresentationText wurde zur Präsentations klasse hinzugefügt. Es gibt zwei Überladungen für diese Methode:

``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 

Das Argument des ExtractionMode-Enums gibt den Modus an, um das Ausgabeergebnis des Textes zu organisieren und kann auf folgende Werte gesetzt werden: 
Unarranged - Der rohe Text ohne Berücksichtigung der Position auf der Folie. 
Arranged - Der Text wird in der gleichen Reihenfolge wie auf der Folie positioniert.

Der Unarranged-Modus kann verwendet werden, wenn Geschwindigkeit entscheidend ist, er ist schneller als der Arranged-Modus.

PresentationText stellt den rohen Text dar, der aus der Präsentation extrahiert wird. Sie enthält eine SlidesText-Eigenschaft aus dem Aspose.Slides.Util-Namespace, die ein Array von ISlideText-Objekten zurückgibt. Jedes Objekt repräsentiert den Text auf der entsprechenden Folie. Das ISlideText-Objekt hat die folgenden Eigenschaften:

ISlideText.Text - Der Text auf den Formen der Folie. 
ISlideText.MasterText - Der Text auf den Formen der Masterseite für diese Folie. 
ISlideText.LayoutText - Der Text auf den Formen der Layoutseite für diese Folie. 
ISlideText.NotesText - Der Text auf den Formen der Notizenseite für diese Folie. 

Es gibt auch eine SlideText-Klasse, die das ISlideText-Interface implementiert.

Die neue API kann wie folgt verwendet werden:

``` csharp

 PresentationText text1 = Presentation.GetPresentationText("presentation.ppt");

Console.WriteLine(text1.SlidesText[0].Text);

Console.WriteLine(text1.SlidesText[0].LayoutText);

Console.WriteLine(text1.SlidesText[0].MasterText);

Console.WriteLine(text1.SlidesText[0].NotesText);

PresentationText text2 = Presentation.GetPresentationText("presentation.pptx", ExtractionMode.Unarranged)

``` 
#### **Das ILegacyDiagram-Interface und die LegacyDiagram-Klasse wurden hinzugefügt**
Das Interface Aspose.Slides.ILegacyDiagram und die Klasse Aspose.Slides.LegacyDiagram wurden hinzugefügt, um das Legacy-Diagrammobjekt darzustellen. Das Legacy-Diagrammobjekt ist ein altes Format von Diagrammen aus PowerPoint 97-2003. 
Die neue Klasse bietet Methoden zur Konvertierung des Legacy-Diagramms in ein modernes bearbeitbares SmartArt-Objekt oder in ein bearbeitbares GroupShape. 
#### **Neues Mitglied des Aspose.Slides.TextAlignment-Enums hinzugefügt (JustifyLow)**
Ein neues Mitglied des TextAlignment-Enums wurde hinzugefügt: 
JustifyLow - Kashida-Textausrichtung niedrig.  
#### **Neue Eigenschaften für Aspose.Slides.IOleObjectFrame und OleObjectFrame**
Eine neue Eigenschaft wurde zum IOleObjectFrame-Interface und zur OleObjectFrame-Klasse hinzugefügt, die dieses Interface implementiert. Diese Eigenschaften werden verwendet, um Informationen über ein in die Präsentation eingebettetes Objekt bereitzustellen: 
EmbeddedFileExtension - Gibt die Dateierweiterung für das aktuelle eingebettete Objekt zurück oder einen leeren String, wenn das Objekt kein Link ist. 
EmbeddedFileLabel - Gibt den Dateinamen des eingebetteten OLE-Objekts zurück. 
EmbeddedFileName - Gibt den Pfad des eingebetteten OLE-Objekts zurück.  
#### **Neue Eigenschaft CategoryAxisType wurde zu den IAxis- und Axis-Klassen hinzugefügt**
Die Eigenschaft CategoryAxisType gibt den Typ der Kategoriekurve an.

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
Die Eigenschaft ShowLabelAsDataCallout bestimmt, ob das angegebene Datenlabel des Diagramms als Datenaufruf oder als Datenlabel angezeigt wird.

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
#### **Die Eigenschaft DrawSlidesFrame wurde zu PdfOptions und XpsOptions hinzugefügt**
Die boolesche Eigenschaft DrawSlidesFrame wurde zu den Schnittstellen Aspose.Slides.Export.IPdfOptions, Aspose.Slides.Export.IXpsOptions und zu den zugehörigen Klassen Aspose.Slides.Export.PdfOptions, Aspose.Slides.Export.XpsOptions hinzugefügt. 
Der schwarze Rahmen um jede Folie wird gezeichnet, wenn diese Eigenschaft auf 'true' gesetzt wird.

``` csharp

 using (Presentation pres = new Presentation("input.pptx"))

{

    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });

}

``` 