---
title: Präsentationslokalisierung
type: docs
weight: 100
url: /de/net/presentation-localization/
keywords: "Sprache ändern, Rechtschreibprüfung, Rechtschreibung prüfen, Rechtschreibprüfer, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Sprache in PowerPoint-Präsentation ändern oder prüfen. Text in C# oder .NET rechtschreibprüfen"
---

## **Sprache für Präsentation und Text von Shape ändern**
- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
- Holen Sie sich die Referenz einer Folie, indem Sie deren Index verwenden.
- Fügen Sie der Folie eine AutoShape vom Typ Rechteck hinzu.
- Fügen Sie dem TextFrame etwas Text hinzu.
- Legen Sie die LanguageId für den Text fest.
- Speichern Sie die Präsentation als PPTX-Datei.

Die Implementierung der obigen Schritte wird im folgenden Beispiel gezeigt.
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

**Löst die LanguageId eine automatische Textübersetzung aus?**

Nein. [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) in Aspose.Slides speichert die Sprache für Rechtschreib- und Grammatikprüfung, übersetzt jedoch nicht den Textinhalt noch ändert ihn. Es handelt sich um Metadaten, die PowerPoint für die Korrektur versteht.

**Beeinflusst die LanguageId die Silbentrennung und Zeilenumbrüche beim Rendern?**

In Aspose.Slides dient [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) der Korrektur. Die Qualität der Silbentrennung und der Zeilenumbruch hängen hauptsächlich von der Verfügbarkeit geeigneter Schriftarten und den Layout-/Zeilenumbruch‑Einstellungen für das Schriftsystem ab. Um ein korrektes Rendering sicherzustellen, stellen Sie die benötigten Schriftarten bereit, konfigurieren Sie [Schriftarten‑Substitutionsregeln](/slides/de/net/font-substitution/) und/oder [betten Sie Schriftarten ein](/slides/de/net/embedded-font/) in die Präsentation ein.

**Kann ich innerhalb eines einzelnen Absatzes verschiedene Sprachen festlegen?**

Ja. [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) wird auf Ebene des Textabschnitts angewendet, sodass ein einzelner Absatz mehrere Sprachen mit unterschiedlichen Korrektureinstellungen mischen kann.
