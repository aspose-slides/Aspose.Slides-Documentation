---
title: Wie man Hello World Präsentationen in .NET erstellt
linktitle: Hello World Präsentation
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
description: "Erstellen Sie eine Hello World PowerPoint PPT, PPTX und ODP Präsentation in .NET mit Aspose.Slides unter Verwendung sowohl der Legacy- als auch der modernen APIs in einem einfachen Leitfaden."
---

{{% alert color="primary" %}} 

Eine neue [Aspose.Slides for .NET API](/slides/de/net/) wurde veröffentlicht und jetzt unterstützt dieses einzelne Produkt die Möglichkeit, PowerPoint-Dokumente von Grund auf zu erstellen und bestehende zu bearbeiten.

{{% /alert %}} 
## **Unterstützung für Legacy-Code**
Um den mit Aspose.Slides für .NET entwickelten Legacy-Code aus Versionen vor 13.x zu verwenden, müssen Sie einige kleine Änderungen an Ihrem Code vornehmen, und der Code funktioniert dann wie zuvor. Alle Klassen, die in der alten Aspose.Slides für .NET unter den Namespaces Aspose.Slide und Aspose.Slides.Pptx vorhanden waren, sind jetzt in einem einzigen Aspose.Slides-Namespace zusammengeführt. Bitte sehen Sie sich das folgende einfache Code-Snippet zur Erstellung eines Hello-World-Präsentationsdokuments in der Legacy-Aspose.Slides-API an und folgen Sie den Schritten, die beschreiben, wie Sie zur neuen zusammengeführten API migrieren.
## **Legacy Aspose.Slides for .NET approach**
```c#
//Instanziiert ein Presentation-Objekt, das eine PPT-Datei darstellt
//Erstellt ein License-Objekt
//Setzt die Lizenz von Aspose.Slides für .NET, um die Evaluationsbeschränkungen zu vermeiden
//Fügt der Präsentation eine leere Folie hinzu und holt die Referenz der
//leeren Folie
//Fügt der Folie ein Rechteck (X=2400, Y=1800, Breite=1000 & Höhe=500) hinzu
//Versteckt die Linien des Rechtecks
//Fügt dem Rechteck einen Textrahmen mit "Hello World" als Standardtext hinzu
//Entfernt die erste Folie der Präsentation, die immer von
//Aspose.Slides für .NET standardmäßig beim Erstellen der Präsentation hinzugefügt wird
//Schreibt die Präsentation als PPT-Datei
Presentation pres = new Presentation();
License license = new License();
license.SetLicense("Aspose.Slides.lic");
Slide slide = pres.AddEmptySlide();
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);
rect.LineFormat.ShowLines = false;
rect.AddTextFrame("Hello World");
pres.Slides.RemoveAt(0);
pres.Write("C:\\hello.ppt");
```




## **New Aspose.Slides for .NET 13.x approach**
```c#
// Instanziere eine Presentation
// Hole die erste Folie
// Füge eine AutoShape vom Typ Rechteck hinzu
// Füge ITextFrame zum Rechteck hinzu
// Ändere die Textfarbe zu Schwarz (standardmäßig ist sie Weiß)
Presentation pres = new Presentation();

// Get the first slide
ISlide sld = (ISlide)pres.Slides[0];

// Add an AutoShape of Rectangle type
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// Add ITextFrame to the Rectangle
ashp.AddTextFrame("Hello World");

// Change the text color to Black (which is White by default)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Change the line color of the rectangle to White
ashp.ShapeStyle.LineColor.Color = Color.White;

// Remove any fill formatting in the shape
ashp.FillFormat.FillType = FillType.NoFill;

// Save the presentation to disk
pres.Save("D:\\data\\HelloWorld.pptx", SaveFormat.Pptx);
```
