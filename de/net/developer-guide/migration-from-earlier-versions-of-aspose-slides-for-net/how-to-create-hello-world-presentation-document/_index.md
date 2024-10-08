---
title: So erstellen Sie ein Hello World Präsentationsdokument
type: docs
weight: 10
url: /de/net/how-to-create-hello-world-presentation-document/
---

{{% alert color="primary" %}} 

Eine neue [Aspose.Slides für .NET API](/slides/de/net/) wurde veröffentlicht und jetzt unterstützt dieses Einzelprodukt die Möglichkeit, PowerPoint-Dokumente von Grund auf zu erstellen und bestehende zu bearbeiten.

{{% /alert %}} 
## **Unterstützung für Legacy-Code**
Um den Legacy-Code zu verwenden, der mit früheren Versionen von Aspose.Slides für .NET vor 13.x entwickelt wurde, müssen Sie einige kleinere Änderungen in Ihrem Code vornehmen, und der Code wird wie zuvor funktionieren. Alle Klassen, die im alten Aspose.Slides für .NET unter den Namespaces Aspose.Slide und Aspose.Slides.Pptx vorhanden waren, sind nun im einzelnen Namespace Aspose.Slides zusammengeführt. Bitte schauen Sie sich das folgende einfache Code-Snippet zum Erstellen eines Hello World Präsentationsdokuments in der alten Aspose.Slides API an und befolgen Sie die Schritte, die beschreiben, wie Sie zur neuen zusammengeführten API migrieren können.
## **Legacy Aspose.Slides für .NET Ansatz**
```c#
//Instanziieren Sie ein Präsentationsobjekt, das eine PPT-Datei darstellt
Presentation pres = new Presentation();

//Erstellen Sie ein Lizenzobjekt
License license = new License();

//Setzen Sie die Lizenz von Aspose.Slides für .NET, um die Evalationsbeschränkungen zu vermeiden
license.SetLicense("Aspose.Slides.lic");

//Hinzufügen einer leeren Folie zur Präsentation und Abrufen des Verweises auf
//diese leere Folie
Slide slide = pres.AddEmptySlide();

//Hinzugefügt ein Rechteck (X=2400, Y=1800, Breite=1000 & Höhe=500) zur Folie
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//Die Linien des Rechtecks ausblenden
rect.LineFormat.ShowLines = false;

//Hinzufügen eines Textfeldes zum Rechteck mit "Hello World" als Standardtext
rect.AddTextFrame("Hello World");

//Entfernen der ersten Folie der Präsentation, die immer von
//Aspose.Slides für .NET standardmäßig beim Erstellen der Präsentation hinzugefügt wird
pres.Slides.RemoveAt(0);

//Schreiben der Präsentation als PPT-Datei
pres.Write("C:\\hello.ppt");
```



## **Neuer Aspose.Slides für .NET 13.x Ansatz**
```c#
// Präsentation instanziieren
Presentation pres = new Presentation();

// Erste Folie abrufen
ISlide sld = (ISlide)pres.Slides[0];

// Hinzufügen einer AutoShape vom Typ Rechteck
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// Fügen Sie ein ITextFrame zum Rechteck hinzu
ashp.AddTextFrame("Hello World");

//Ändern der Schriftfarbe auf Schwarz (was standardmäßig Weiß ist)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

//Ändern der Linienfarbe des Rechtecks auf Weiß
ashp.ShapeStyle.LineColor.Color = Color.White;

//Entfernen Sie alle Füllformatierungen im Shape
ashp.FillFormat.FillType = FillType.NoFill;

//Speichern Sie die Präsentation auf der Platte
pres.Save("D:\\data\\HelloWorld.pptx", SaveFormat.Pptx);
```