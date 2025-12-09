---
title: Wie man Hello-World-Präsentationen in .NET erstellt
linktitle: Hello-World-Präsentation
type: docs
weight: 10
url: /de/net/how-to-create-hello-world-presentation-document/
keywords:
- Migration
- Hallo Welt
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
- description: "Erstellen Sie eine Hello-World-PowerPoint-PPT, PPTX- und ODP-Präsentation in .NET mit Aspose.Slides, indem Sie sowohl die Legacy- als auch die modernen APIs in einem einfachen Leitfaden nutzen."
---

{{% alert color="primary" %}} 

Eine neue [Aspose.Slides for .NET API](/slides/de/net/) wurde veröffentlicht und dieses einzelne Produkt unterstützt nun die Möglichkeit, PowerPoint-Dokumente von Grund auf zu erstellen und bestehende zu bearbeiten.

{{% /alert %}} 
## **Unterstützung für Legacy-Code**
Um den mit Aspose.Slides for .NET entwickelten Legacy-Code zu verwenden, der für Versionen vor 13.x erstellt wurde, müssen Sie einige geringfügige Änderungen an Ihrem Code vornehmen, damit er wie zuvor funktioniert. Alle Klassen, die im alten Aspose.Slides for .NET unter den Namespaces Aspose.Slide und Aspose.Slides.Pptx vorhanden waren, sind jetzt in einem einzigen Aspose.Slides-Namespace zusammengeführt. Bitte sehen Sie sich das folgende einfache Code-Snippet zur Erstellung eines Hello-World-Präsentationsdokuments im Legacy-Aspose.Slides-API an und folgen Sie den Schritten, die die Migration zum neuen zusammengeführten API beschreiben.
## **Legacy Aspose.Slides for .NET Ansatz**
```c#
 //Instanziieren Sie ein Presentation-Objekt, das eine PPT-Datei darstellt
 Presentation pres = new Presentation();

 //Erstellen Sie ein Lizenzobjekt
 License license = new License();

 //Setzen Sie die Lizenz von Aspose.Slides für .NET, um die Evaluierungsbeschränkungen zu vermeiden
 license.SetLicense("Aspose.Slides.lic");

 //Hinzufügen einer leeren Folie zur Präsentation und Abrufen der Referenz von
 //dieser leeren Folie
 Slide slide = pres.AddEmptySlide();

 //Hinzufügen eines Rechtecks (X=2400, Y=1800, Breite=1000 & Höhe=500) zur Folie
 Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

 //Ausblenden der Linien des Rechtecks
 rect.LineFormat.ShowLines = false;

 //Hinzufügen eines Textfeldes zum Rechteck mit "Hello World" als Standardtext
 rect.AddTextFrame("Hello World");

 //Entfernen der ersten Folie der Präsentation, die immer von
 //Aspose.Slides für .NET standardmäßig beim Erstellen der Präsentation hinzugefügt wird
 pres.Slides.RemoveAt(0);

 //Schreiben der Präsentation als PPT-Datei
 pres.Write("C:\\hello.ppt");
```


## **Neuer Aspose.Slides for .NET 13.x Ansatz**
```c#
 // Instanziieren einer Präsentation
Presentation pres = new Presentation();

 // Erste Folie abrufen
ISlide sld = (ISlide)pres.Slides[0];

 // Ein AutoShape vom Typ Rechteck hinzufügen
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

 // ITextFrame zum Rechteck hinzufügen
ashp.AddTextFrame("Hello World");

 // Textfarbe zu Schwarz ändern (standardmäßig ist sie Weiß)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

 // Linienfarbe des Rechtecks zu Weiß ändern
ashp.ShapeStyle.LineColor.Color = Color.White;

 // Füllformatierung der Form entfernen
ashp.FillFormat.FillType = FillType.NoFill;

 // Präsentation auf Festplatte speichern
pres.Save("D:\\data\\HelloWorld.pptx", SaveFormat.Pptx);
```
