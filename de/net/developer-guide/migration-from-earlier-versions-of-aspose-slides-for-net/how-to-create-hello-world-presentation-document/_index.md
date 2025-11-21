---
title: So erstellen Sie Hello-World-Präsentationen in .NET
linktitle: Hello-World-Präsentation
type: docs
weight: 10
url: /de/net/how-to-create-hello-world-presentation-document/
keywords:
- Migration
- Hallo Welt
- Legacy-Code
- Moderne Code
- Legacy-Ansatz
- Moderne Ansatz
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
- description: "Erstellen Sie eine Hello-World PowerPoint-Präsentation im PPT-, PPTX- und ODP-Format in .NET mit Aspose.Slides, wobei sowohl Legacy- als auch moderne APIs verwendet werden, in einer einfachen Anleitung."
---

{{% alert color="primary" %}} 
Eine neue [Aspose.Slides for .NET API](/slides/de/net/) wurde veröffentlicht und unterstützt nun die Möglichkeit, PowerPoint-Dokumente von Grund auf zu erzeugen und vorhandene zu bearbeiten.
{{% /alert %}} 
## **Unterstützung für Legacy-Code**
Um den mit Aspose.Slides for .NET entwickelten Legacy-Code aus Versionen vor 13.x zu verwenden, müssen Sie einige kleine Änderungen an Ihrem Code vornehmen, damit er wie zuvor funktioniert. Alle Klassen, die in alten Aspose.Slides for .NET unter den Namespaces Aspose.Slide und Aspose.Slides.Pptx vorhanden waren, sind nun in einem einzigen Aspose.Slides-Namespace zusammengeführt. Bitte schauen Sie sich das folgende einfache Code-Snippet zur Erstellung eines Hello-World-Präsentationsdokuments im Legacy Aspose.Slides API an und folgen Sie den Schritten, die beschreiben, wie Sie zum neuen zusammengeführten API migrieren.
## **Legacy Aspose.Slides for .NET Ansatz**
```c#
//Instanziieren Sie ein Presentation-Objekt, das eine PPT-Datei darstellt
Presentation pres = new Presentation();

//Erstellen Sie ein License-Objekt
License license = new License();

//Setzen Sie die Lizenz von Aspose.Slides für .NET, um die Evaluierungsbeschränkungen zu vermeiden
license.SetLicense("Aspose.Slides.lic");

//Fügen Sie der Präsentation eine leere Folie hinzu und erhalten Sie die Referenz von
//dieser leeren Folie
Slide slide = pres.AddEmptySlide();

//Fügen Sie der Folie ein Rechteck (X=2400, Y=1800, Breite=1000 & Höhe=500) hinzu
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//Verstecken der Linien des Rechtecks
rect.LineFormat.ShowLines = false;

//Fügen Sie dem Rechteck einen Textrahmen mit "Hello World" als Standardtext hinzu
rect.AddTextFrame("Hello World");

//Entfernen der ersten Folie der Präsentation, die immer von
//Aspose.Slides für .NET standardmäßig beim Erstellen der Präsentation hinzugefügt wird
pres.Slides.RemoveAt(0);

//Schreiben der Präsentation als PPT-Datei
pres.Write("C:\\hello.ppt");
```


## **Neuer Aspose.Slides for .NET 13.x Ansatz**
```c#
// Presentation instanziieren
Presentation pres = new Presentation();

// Erste Folie abrufen
ISlide sld = (ISlide)pres.Slides[0];

// AutoShape vom Typ Rechteck hinzufügen
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// ITextFrame zum Rechteck hinzufügen
ashp.AddTextFrame("Hello World");

// Ändere die Textfarbe zu Schwarz (standardmäßig ist sie Weiß)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Ändere die Linienfarbe des Rechtecks zu Weiß
ashp.ShapeStyle.LineColor.Color = Color.White;

// Entferne jede Füllformatierung in der Form
ashp.FillFormat.FillType = FillType.NoFill;

// Präsentation auf Festplatte speichern
pres.Save("D:\\data\\HelloWorld.pptx", SaveFormat.Pptx);
```
