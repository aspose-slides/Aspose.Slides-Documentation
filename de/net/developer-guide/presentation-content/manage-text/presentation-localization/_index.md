---
title: Präsentationslokalisierung
type: docs
weight: 100
url: /de/net/presentation-localization/
keywords: "Sprache ändern, Rechtschreibprüfung, Rechtschreibprüfung, Rechtschreibprüfer, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Sprache in PowerPoint-Präsentationen ändern oder überprüfen. Rechtschreibung in C# oder .NET prüfen"
---
## **Sprache für Präsentation und Text von Formen ändern**
- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
- Erhalten Sie die Referenz zu einer Folie, indem Sie ihren Index verwenden.
- Fügen Sie der Folie eine AutoShape vom Typ Rechteck hinzu.
- Fügen Sie dem TextFrame etwas Text hinzu.
- Setzen Sie die Sprach-ID für den Text.
- Schreiben Sie die Präsentation als PPTX-Datei.

Die Implementierung der oben genannten Schritte wird unten in einem Beispiel demonstriert.

```c#
using (Presentation pres = new Presentation("test0.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.AddTextFrame("Text zur Anwendung der Rechtschreibprüfung Sprache");
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId = "en-EN";

    pres.Save("test1.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```