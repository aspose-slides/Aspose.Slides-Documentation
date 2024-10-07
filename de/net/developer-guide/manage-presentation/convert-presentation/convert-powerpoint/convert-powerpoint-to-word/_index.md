---
title: PowerPoint in Word konvertieren
type: docs
weight: 110
url: /net/convert-powerpoint-to-word/
keywords:
- PowerPoint konvertieren
- PPT
- PPTX
- Präsentation
- Word
- DOCX
- DOC
- PPTX in DOCX
- PPT in DOC
- PPTX in DOC
- PPT in DOCX
- C#
- Csharp
- .NET
- Aspose.Slides
description: "Konvertieren Sie PowerPoint-Präsentationen in Word in C# oder .NET."
---

Wenn Sie planen, Textinhalte oder Informationen aus einer Präsentation (PPT oder PPTX) auf neue Weise zu verwenden, profitieren Sie möglicherweise davon, die Präsentation in Word (DOC oder DOCX) zu konvertieren. 

* Im Vergleich zu Microsoft PowerPoint ist die Microsoft Word-App besser mit Werkzeugen oder Funktionen für Inhalte ausgestattet. 
* Neben den Bearbeitungsfunktionen in Word profitieren Sie möglicherweise auch von verbesserten Kollaboration-, Druck- und Freigabefunktionen. 

{{% alert color="primary" %}} 

Sie sollten unseren [**Präsentation zu Word Online-Konverter**](https://products.aspose.app/slides/conversion/ppt-to-word) ausprobieren, um zu sehen, was Sie aus der Arbeit mit Textinhalten aus Folien gewinnen könnten. 

{{% /alert %}} 

### **Aspose.Slides und Aspose.Words**

Um eine PowerPoint-Datei (PPTX oder PPT) in Word (DOCX oder DOC) zu konvertieren, benötigen Sie sowohl [Aspose.Slides für .NET](https://products.aspose.com/slides/net/) als auch [Aspose.Words für .NET](https://products.aspose.com/words/net/).

Als eigenständige API bietet [Aspose.Slides](https://products.aspose.app/slides) für .NET Funktionen, die es Ihnen ermöglichen, Texte aus Präsentationen zu extrahieren. 

[Aspose.Words](https://docs.aspose.com/words/net/) ist eine fortschrittliche Dokumentenverarbeitungs-API, die es Anwendungen ermöglicht, Dateien zu generieren, zu ändern, zu konvertieren, zu rendern, zu drucken und andere Aufgaben mit Dokumenten durchzuführen, ohne Microsoft Word zu verwenden.

## **PowerPoint in Word konvertieren**

1. Fügen Sie diese Namespaces zu Ihrer program.cs-Datei hinzu:

```c#
using Aspose.Slides;
using Aspose.Words;
using System.IO;
```

2. Verwenden Sie diesen Codeausschnitt, um PowerPoint in Word zu konvertieren:

```c#
using var presentation = new Presentation("sample.pptx");

var doc = new Document();
var builder = new DocumentBuilder(doc);

foreach (var slide in presentation.Slides)
{
    // generiert ein Folienbild und speichert es in einem Speicherstream
    using var image = slide.GetImage(1, 1);
    using var imageStream = new MemoryStream();
    image.Save(imageStream, ImageFormat.Png);

    imageStream.Seek(0, SeekOrigin.Begin);
    builder.InsertImage(imageStream.ToArray());

    // fügt den Text der Folien ein
    foreach (var shape in slide.Shapes)
    {
        if (shape is AutoShape autoShape)
        {
            builder.Writeln(autoShape.TextFrame.Text);
        }
    }

    builder.InsertBreak(BreakType.PageBreak);
}

doc.Save("output.docx");
```