---
title: Automatisierte Präsentationslokalisierung in .NET
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
description: "Automatisieren Sie die Lokalisierung von PowerPoint- und OpenDocument-Folien in .NET mit Aspose.Slides, mithilfe praktischer C#-Codebeispiele und Tipps für eine schnellere globale Bereitstellung."
---

## **Sprache für Präsentation und Text von Formen ändern**
- Eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse erstellen.
- Die Referenz einer Folie über deren Index erhalten.
- Ein AutoShape vom Typ Rechteck zur Folie hinzufügen.
- Etwas Text zum TextFrame hinzufügen.
- Sprach‑Id für den Text festlegen.
- Die Präsentation als PPTX‑Datei speichern.

Die Umsetzung der oben genannten Schritte wird unten in einem Beispiel gezeigt.
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

**Löst die Sprach‑Id eine automatische Textübersetzung aus?**

Nein. [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) in Aspose.Slides speichert die Sprache für Rechtschreib‑ und Grammatikprüfung, übersetzt jedoch nicht den Textinhalt und ändert ihn nicht. Es handelt sich um Metadaten, die PowerPoint für die Prüfung versteht.

**Beeinflusst die Sprach‑Id die Silbentrennung und den Zeilenumbruch bei der Darstellung?**

In Aspose.Slides dient [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) der Prüfung. Die Qualität der Silbentrennung und des Zeilenumbruchs hängt hauptsächlich von der Verfügbarkeit geeigneter [proper fonts](/slides/de/net/powerpoint-fonts/) sowie von Layout‑/Zeilenumbruch‑Einstellungen für das Schriftsystem ab. Stellen Sie sicher, dass die benötigten Schriftarten verfügbar sind, konfigurieren Sie [font substitution rules](/slides/de/net/font-substitution/) und/oder betten Sie [embed fonts](/slides/de/net/embedded-font/) in die Präsentation ein.

**Kann ich verschiedene Sprachen innerhalb eines einzigen Absatzes festlegen?**

Ja. [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) wird auf Ebene des Textabschnitts angewendet, sodass ein einzelner Absatz mehrere Sprachen mit unterschiedlichen Prüf­einstellungen mischen kann.