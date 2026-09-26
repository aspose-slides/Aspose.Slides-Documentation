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
description: "Erstellen Sie eine Hello-World-PowerPoint-PPT, PPTX und ODP-Präsentation in .NET mit Aspose.Slides, indem Sie sowohl die Legacy- als auch die moderne API in einer einfachen Anleitung verwenden."
---
{{% alert color="info" %}}

Eine neue [Aspose.Slides for .NET API](/slides/de/net/) wurde veröffentlicht und unterstützt nun die Möglichkeit, PowerPoint‑Dokumente von Grund auf zu erzeugen und vorhandene zu bearbeiten.

{{% /alert %}} 
## **Unterstützung für Legacy-Code**
Um den mit älteren Versionen von Aspose.Slides for .NET (vor 13.x) entwickelten Legacy‑Code zu verwenden, müssen Sie nur kleine Änderungen an Ihrem Code vornehmen, und er wird wie zuvor funktionieren. Alle Klassen, die in der alten Aspose.Slides for .NET unter den Namespaces Aspose.Slide und Aspose.Slides.Pptx vorhanden waren, wurden jetzt in einen einzigen Aspose.Slides‑Namespace zusammengeführt. Bitte sehen Sie sich das folgende einfache Code‑Snippet zur Erstellung eines Hello‑World‑Präsentationsdokuments mit der Legacy‑Aspose.Slides‑API an und folgen Sie den Schritten, die beschreiben, wie man zur neuen zusammengeführten API migriert.
## **Legacy‑Ansatz von Aspose.Slides für .NET**
```c#
using System.Drawing;
using Aspose.Slides;

//Instanziieren Sie ein Presentation-Objekt, das eine PPT-Datei repräsentiert
Presentation pres = new Presentation();

//Erstellen Sie ein License-Objekt
License license = new License();

//Setzen Sie die Lizenz von Aspose.Slides für .NET, um die Evaluierungsbeschränkungen zu vermeiden
license.SetLicense("Aspose.Slides.lic");

//Hinzufügen einer leeren Folie zur Präsentation und Abrufen der Referenz auf
//diese leere Folie
Slide slide = pres.AddEmptySlide();

//Hinzufügen eines Rechtecks (X=2400, Y=1800, Breite=1000 & Höhe=500) zur Folie
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//Ausblenden der Linien des Rechtecks
rect.LineFormat.ShowLines = false;

//Hinzufügen eines Textfelds zum Rechteck mit "Hello World" als Standardtext
rect.AddTextFrame("Hello World");

//Entfernen der ersten Folie der Präsentation, die immer von
//Aspose.Slides für .NET standardmäßig beim Erstellen der Präsentation hinzugefügt wird
pres.Slides.RemoveAt(0);

//Schreiben der Präsentation als PPT-Datei
pres.Write("C:\\hello.ppt");
```



## **Neuer Ansatz von Aspose.Slides für .NET 13.x**
```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanzieren Sie die Präsentation
Presentation pres = new Presentation();

// Erhalten Sie die erste Folie
ISlide sld = (ISlide)pres.Slides[0];

// Fügen Sie eine AutoShape vom Typ Rechteck hinzu
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// Fügen Sie dem Rechteck ein ITextFrame hinzu
ashp.AddTextFrame("Hello World");

// Ändern Sie die Textfarbe zu Schwarz (standardmäßig ist sie Weiß)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Ändern Sie die Linienfarbe des Rechtecks zu Weiß
ashp.ShapeStyle.LineColor.Color = Color.White;

// Entfernen Sie alle Füllformatierungen in der Form
ashp.FillFormat.FillType = FillType.NoFill;

// Speichern Sie die Präsentation auf der Festplatte
pres.Save("HelloWorld.pptx", SaveFormat.Pptx);
```