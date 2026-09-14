---
title: Festlegen von Ersatzschriftarten für Präsentationen in Python über Java
linktitle: Ersatzschriftart
type: docs
weight: 10
url: /de/python-java/create-fallback-font/
keywords:
- Ersatzschriftart
- Ersatzregel
- Schriftart anwenden
- Schriftart ersetzen
- Unicode-Bereich
- fehlende Glyphe
- richtige Glyphe
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Beherrschen Sie Aspose.Slides für Python via Java, um Ersatzschriftarten in PPT-, PPTX- und ODP-Dateien festzulegen und damit eine konsistente Textdarstellung auf jedem Gerät oder Betriebssystem zu gewährleisten."
---
## **Übersicht**

Aspose.Slides ermöglicht das Angeben von Ersatzschriftarten für das Rendern und den Export von Präsentationen. Ersatzschriftarten werden verwendet, wenn die primäre Schriftart keine Glyphen für bestimmte Zeichen enthält.

Das Verhalten von Ersatzschriftarten wird über Ersatzregeln konfiguriert. Jede Regel verknüpft einen Unicode-Bereich mit einer oder mehreren Schriftarten, die die erforderlichen Glyphen enthalten können. Sie können Regeln für verschiedene Zeichenbereiche definieren, Ersatzschriftarten zu vorhandenen Regeln hinzufügen oder entfernen und mehrere Regeln in einer Sammlung von Ersatzschriftarten‑Regeln organisieren.

Ersatzregeln sind Laufzeit-Render-Einstellungen. Sie ändern die Präsentationsdatei selbst nicht und werden nicht innerhalb der PPTX-Datei gespeichert.

## **Ersatzregeln**

Aspose.Slides stellt die Klasse [FontFallBackRule](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontfallbackrule/) bereit, um Regeln für die Anwendung von Ersatzschriftarten festzulegen. Diese Klasse stellt eine Zuordnung zwischen einem Unicode-Bereich, der zur Suche nach fehlenden Glyphen verwendet wird, und einer Liste von Schriftarten dar, die die erforderlichen Glyphen enthalten können:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule

start_unicode_index = 0x0B80
end_unicode_index = 0x0BFF

first_rule = FontFallBackRule(start_unicode_index, end_unicode_index, "Vijaya")
second_rule = FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

# Verwenden Sie mehrere Wege, um eine Liste von Schriftarten anzugeben.
font_names = jpype.JArray(jpype.JString)(["Segoe UI Emoji, Segoe UI Symbol", "Arial"])

third_rule = FontFallBackRule(0x1F300, 0x1F64F, font_names)
```

Sie können auch eine Ersatzschriftart mit [remove](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontfallbackrule/#remove) entfernen oder Ersatzschriftarten mit [addFallBackFonts](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontfallbackrule/#addFallBackFonts) zu einem bestehenden [FontFallBackRule](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontfallbackrule/)-Objekt hinzufügen.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontfallbackrulescollection/) kann eine Liste von [FontFallBackRule](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontfallbackrule/)-Objekten organisieren, wenn Sie Ersatzschriftart‑Ersetzungsregeln für mehrere Unicode‑Bereiche angeben müssen.

{{% alert color="info" title="Siehe auch" %}} 
- [Ersatzschriftarten‑Sammlung erstellen](/slides/de/python-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Was ist der Unterschied zwischen einer Ersatzschriftart, einer Schriftart‑Substitution und dem Einbetten von Schriftarten?**

Eine Ersatzschriftart wird nur für Zeichen verwendet, die in der primären Schriftart fehlen. [Font substitution](/slides/de/python-java/font-substitution/) ersetzt die gesamte angegebene Schriftart durch eine andere Schriftart. [Font embedding](/slides/de/python-java/embedded-font/) packt die Schriftarten in die Ausgabedatei, sodass Empfänger den Text wie vorgesehen sehen können.

**Werden Ersatzschriftarten bei Exporten wie PDF, PNG oder SVG angewendet oder nur beim Rendern auf dem Bildschirm?**

Ja. Ersatzschriftarten beeinflussen alle [Render‑ und Export‑Operationen](/slides/de/python-java/convert-presentation/), bei denen Zeichen gezeichnet werden müssen, aber in der Quellschriftart fehlen.

**Ändert das Konfigurieren von Ersatzschriftarten die Präsentationsdatei selbst, und bleibt die Einstellung bei zukünftigen Öffnungen erhalten?**

Nein. Ersatzregeln sind Laufzeit-Render-Einstellungen in Ihrem Code; sie werden nicht in der .pptx gespeichert und erscheinen nicht in PowerPoint.

**Beeinflussen das Betriebssystem (Windows/Linux/macOS) und die Menge der Schriftverzeichnisse die Auswahl von Ersatzschriftarten?**

Ja. Die Engine löst Schriftarten aus den verfügbaren Systemordnern und allen von Ihnen angegebenen [zusätzlichen Pfaden](/slides/de/python-java/custom-font/) auf. Wenn eine Schriftart nicht physisch verfügbar ist, kann eine Regel, die sich darauf bezieht, nicht wirksam werden.

**Funktionieren Ersatzschriftarten für WordArt, SmartArt und Diagramme?**

Ja. Wenn diese Objekte Text enthalten, wird derselbe Glyph‑Substitutions‑Mechanismus angewendet, um fehlende Zeichen zu rendern.