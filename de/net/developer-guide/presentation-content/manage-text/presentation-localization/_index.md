---
title: Automatisierung der Präsentationslokalisierung in .NET
linktitle: Präsentationslokalisierung
type: docs
weight: 100
url: /de/net/presentation-localization/
keywords:
- Sprache ändern
- Rechtschreibprüfung
- Sprach-ID
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Automatisieren Sie die Lokalisierung von PowerPoint- und OpenDocument‑Folien in .NET mit Aspose.Slides, indem Sie praktische C#‑Codebeispiele und Tipps für eine schnellere globale Bereitstellung nutzen."
---

## **Sprache für eine Präsentation und Formtext ändern**
- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
- Holen Sie die Referenz einer Folie, indem Sie deren Index verwenden.
- Fügen Sie der Folie eine AutoShape vom Typ Rechteck hinzu.
- Fügen Sie dem TextFrame etwas Text hinzu.
- Setzen Sie die Language Id für den Text.
- Schreiben Sie die Präsentation als PPTX‑Datei.

Die Implementierung der obigen Schritte wird im Folgenden anhand eines Beispiels gezeigt.
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

**Wird die Sprach‑ID eine automatische Textübersetzung auslösen?**

Nein. [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) in Aspose.Slides speichert die Sprache für Rechtschreib‑ und Grammatikprüfung, übersetzt den Text jedoch nicht und ändert den Inhalt nicht. Es handelt sich um Metadaten, die PowerPoint für die Prüfung versteht.

**Beeinflusst die Sprach‑ID die Silbentrennung und Zeilenumbrüche beim Rendern?**

In Aspose.Slides dient die [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) der Rechtschreibprüfung. Die Qualität der Silbentrennung und das Zeilenumbruchverhalten hängen hauptsächlich von der Verfügbarkeit geeigneter Schriften ([proper fonts](/slides/de/net/powerpoint-fonts/)) sowie von Layout‑ und Zeilenumbruch‑Einstellungen für das Schriftsystem ab. Stellen Sie die erforderlichen Schriften bereit, konfigurieren Sie [font substitution rules](/slides/de/net/font-substitution/), und/oder [embed fonts](/slides/de/net/embedded-font/) in die Präsentation, um korrektes Rendering sicherzustellen.

**Kann ich verschiedene Sprachen innerhalb eines einzelnen Absatzes festlegen?**

Ja. Die [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) wird auf Textebene (Portion) angewendet, sodass ein einzelner Absatz mehrere Sprachen mit unterschiedlichen Prüf‑Einstellungen mischen kann.