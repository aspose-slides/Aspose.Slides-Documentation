---
title: Präsentationen mit Fallback‑Schriftarten in Python über Java rendern
linktitle: Präsentationen rendern
type: docs
weight: 30
url: /de/python-java/render-presentation-with-fallback-font/
keywords:
- Fallback‑Schriftart
- PowerPoint rendern
- Präsentation rendern
- Folie rendern
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Rendern Sie Präsentationen mit Fallback‑Schriftarten in Aspose.Slides für Python über Java – halten Sie Text konsistent über PPT, PPTX und ODP hinweg mit schrittweisen Python‑Code‑Beispielen."
---
## **Übersicht**

Aspose.Slides ermöglicht das Rendern von Präsentationen mit Fallback‑Schriftartenregeln. Dieser Artikel zeigt, wie man eine Sammlung von Fallback‑Schriftartenregeln erstellt, deren Regeln durch Entfernen oder Hinzufügen von Fallback‑Schriftarten ändert und die Sammlung mithilfe der FontsManager.setFontFallBackRulesCollection‑Methode zuweist.

Nachdem die Sammlung von Fallback‑Schriftartenregeln dem FontsManager der Präsentation zugewiesen wurde, werden die Regeln bei Vorgängen wie dem Speichern, Rendern und Konvertieren der Präsentation angewendet. Das Beispiel demonstriert, wie die konfigurierten Regeln beim Rendern einer Folien‑Miniatur und beim Speichern als JPEG‑Bild verwendet werden.

## **Rendern einer Folie mit Fallback‑Schriftartenregeln**

Die folgenden Schritte werden im Beispiel durchgeführt:

1. [Erstelle eine Sammlung von Fallback‑Schriftartenregeln](/slides/de/python-java/create-fallback-fonts-collection/).
2. [Entfernen](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontfallbackrule/#remove) einer Fallback‑Schriftart aus einer Regel und [Fallback‑Schriftarten hinzufügen](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontfallbackrule/#addFallBackFonts) zu einer anderen Regel.
3. Weise die Regelsammlung mit [setFontFallBackRulesCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) auf dem Font‑Manager zu, der von [getFontsManager](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getFontsManager) zurückgegeben wird.
4. Verwende die [Presentation.save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save)-Methode, um die Präsentation im selben Format oder in einem anderen Format zu speichern. Nachdem die Sammlung von Fallback‑Schriftartenregeln dem [FontsManager](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsmanager/) zugewiesen wurde, werden diese Regeln bei Vorgängen auf der Präsentation angewendet: Speichern, Rendern, Konvertieren usw.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule, FontFallBackRulesCollection, ImageFormat, Presentation

# Neue Regelsammlung erstellen.
fallback_rules = FontFallBackRulesCollection()

# Mehrere Regeln erstellen.
cyrillic_rule = FontFallBackRule(0x400, 0x4FF, "Times New Roman")
fallback_rules.add(cyrillic_rule)
arabic_rule = FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial")
fallback_rules.add(arabic_rule)

for fallback_rule in fallback_rules:
    # Versuchen Sie, die Fallback‑Schriftart "Tahoma" aus den Regeln zu entfernen.
    fallback_rule.remove("Tahoma")

    # Aktualisieren Sie die Regeln für den angegebenen Bereich.
    if fallback_rule.getRangeEndIndex() >= 0x400 and fallback_rule.getRangeStartIndex() < 0x500:
        fallback_rule.addFallBackFonts("Verdana")

# Entfernen Sie eine vorhandene Regel, wobei mindestens eine Regel zum Rendern erhalten bleibt.
if fallback_rules.size() > 1:
    rule_to_remove = fallback_rules.get_Item(1)
    fallback_rules.remove(rule_to_remove)

presentation = Presentation("input.pptx")
try:
    # Weisen Sie die vorbereitete Regelsammlung zu.
    presentation.getFontsManager().setFontFallBackRulesCollection(fallback_rules)

    # Rendern Sie eine Miniatur mithilfe der konfigurierten Regelsammlung.
    slide_image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        # Speichern Sie das Bild auf der Festplatte im JPEG‑Format.
        slide_image.save("Slide_0.jpg", ImageFormat.Jpeg)
    finally:
        slide_image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Erfahren Sie mehr darüber, wie Sie PPT und PPTX in Python über Java in JPG konvertieren.
{{% /alert %}}