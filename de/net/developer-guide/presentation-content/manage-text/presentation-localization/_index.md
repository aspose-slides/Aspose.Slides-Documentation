---
title: Präsentationslokalisierung
type: docs
weight: 100
url: /de/net/presentation-localization/
keywords: "Sprache ändern, Rechtschreibprüfung, Rechtschreibprüfung, Rechtschreibprüfer, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides for .NET"
description: "Sprache in einer PowerPoint-Präsentation ändern oder prüfen. Text in C# oder .NET rechtschreibprüfen."
---

## **Sprache für Präsentation und Text von Formen ändern**
- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
- Rufen Sie die Referenz einer Folie über ihren Index ab.
- Fügen Sie der Folie eine AutoShape vom Typ Rechteck hinzu.
- Fügen Sie dem TextFrame etwas Text hinzu.
- Legen Sie die LanguageId für den Text fest.
- Speichern Sie die Präsentation als PPTX-Datei.

Die Implementierung der obigen Schritte wird unten in einem Beispiel gezeigt.
```c#
using (Presentation pres = new Presentation("test0.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.AddTextFrame("Text to apply spellcheck language");
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId = "en-EN";

    pres.Save("test1.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **FAQ**

**Löst language_id eine automatische Textübersetzung aus?**

Nein. [language_id](https://reference.aspose.com/slides/net/aspose.slides/portionformat/languageid/) in Aspose.Slides speichert die Sprache für Rechtschreib- und Grammatikprüfung, übersetzt jedoch den Text nicht und ändert ihn nicht. Es handelt sich um Metadaten, die PowerPoint für die Prüfung versteht.

**Beeinflusst language_id die Silbentrennung und den Zeilenumbruch beim Rendern?**

In Aspose.Slides ist [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) für die Prüfung vorgesehen. Die Qualität der Silbentrennung und des Zeilenumbruchs hängt hauptsächlich von der Verfügbarkeit [proper fonts](/slides/de/net/powerpoint-fonts/) sowie von Layout‑/Zeilenumbruch‑Einstellungen für das Schriftsystem ab. Um ein korrektes Rendering sicherzustellen, stellen Sie die erforderlichen Schriften bereit, konfigurieren Sie [font substitution rules](/slides/de/net/font-substitution/) und/oder [embed fonts](/slides/de/net/embedded-font/) in die Präsentation.

**Kann ich innerhalb eines einzelnen Absatzes verschiedene Sprachen festlegen?**

Ja. [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) wird auf Ebene des Textabschnitts angewendet, sodass ein einzelner Absatz mehrere Sprachen mit unterschiedlichen Prüfungseinstellungen mischen kann.