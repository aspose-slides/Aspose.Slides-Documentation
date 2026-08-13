---
title: Wie man Hello‑World‑Präsentationen in .NET erstellt
linktitle: Hello‑World‑Präsentation
type: docs
weight: 10
url: /de/net/how-to-create-hello-world-presentation-document/
keywords:
- Migration
- Hallo Welt
- Legacy‑Code
- Moderner Code
- Legacy‑Ansatz
- Moderner Ansatz
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
- description: "Erstellen Sie eine Hello‑World‑PowerPoint‑PPT, PPTX und ODP‑Präsentation in .NET mit Aspose.Slides unter Verwendung sowohl des Legacy‑ als auch des modernen APIs in einer einfachen Anleitung."
---
{{% alert color="info" %}} 

Eine neue [Aspose.Slides for .NET API](/slides/de/net/) wurde veröffentlicht und jetzt unterstützt dieses einzelne Produkt die Möglichkeit, PowerPoint‑Dokumente von Grund auf zu erstellen und bestehende zu bearbeiten.

{{% /alert %}} 
## **Support für Legacy‑Code**
Um den mit älteren Aspose.Slides for .NET‑Versionen (vor 13.x) entwickelten Legacy‑Code zu verwenden, müssen Sie einige kleine Änderungen an Ihrem Code vornehmen, damit er wie zuvor funktioniert. Alle Klassen, die in der alten Aspose.Slides for .NET‑Bibliothek unter den Namespaces Aspose.Slide und Aspose.Slides.Pptx vorhanden waren, sind nun in einem einzigen Aspose.Slides‑Namespace zusammengeführt. Bitte schauen Sie sich das folgende einfache Code‑Snippet an, das ein Hello‑World‑Präsentationsdokument im Legacy‑Aspose.Slides‑API erstellt, und folgen Sie den Schritten, die beschreiben, wie Sie zur neuen, zusammengeführten API migrieren.
## **Legacy‑Ansatz für Aspose.Slides for .NET**
```c#
using System.Drawing;
using Aspose.Slides;

//Instanziiert ein Presentation-Objekt, das eine PPT-Datei darstellt
Presentation pres = new Presentation();

//Erstellt ein Lizenz-Objekt
License license = new License();

//Setzt die Lizenz von Aspose.Slides für .NET, um die Evaluationsbeschränkungen zu vermeiden
license.SetLicense("Aspose.Slides.lic");

//Fügt der Präsentation eine leere Folie hinzu und erhält die Referenz von
//dieser leeren Folie
Slide slide = pres.AddEmptySlide();

//Fügt der Folie ein Rechteck (X=2400, Y=1800, Breite=1000 & Höhe=500) hinzu
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//Versteckt die Linien des Rechtecks
rect.LineFormat.ShowLines = false;

//Fügt dem Rechteck einen Textbereich mit "Hello World" als Standardtext hinzu
rect.AddTextFrame("Hello World");

//Entfernt die erste Folie der Präsentation, die stets von
//Aspose.Slides für .NET standardmäßig beim Erstellen der Präsentation hinzugefügt wird
pres.Slides.RemoveAt(0);

//Schreibt die Präsentation als PPT-Datei
pres.Write("C:\\hello.ppt");
```



## **Neuer Ansatz für Aspose.Slides for .NET 13.x**
```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instantiate Presentation
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
pres.Save("HelloWorld.pptx", SaveFormat.Pptx);
```