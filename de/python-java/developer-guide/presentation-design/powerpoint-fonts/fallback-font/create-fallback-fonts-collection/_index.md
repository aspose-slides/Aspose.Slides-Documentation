---
title: Fallback-Schriftartensammlung in Python über Java konfigurieren
linktitle: Fallback-Schriftartensammlung
type: docs
weight: 20
url: /de/python-java/create-fallback-fonts-collection/
keywords:
- Fallback-Schriftart
- Fallback-Regel
- Schriftartensammlung
- Schriftart konfigurieren
- Schriftart einrichten
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Richten Sie eine Fallback-Schriftartensammlung in Aspose.Slides für Python über Java ein, um Text in PowerPoint- und OpenDocument-Präsentationen konsistent und scharf zu halten."
---
## **Übersicht**

Aspose.Slides ermöglicht das Konfigurieren einer Sammlung von Fallback‑Schriftartenregeln für eine Präsentation. Jede Fallback‑Regel wird durch die Klasse [FontFallBackRule](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontfallbackrule/) dargestellt und kann zu einer [FontFallBackRulesCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontfallbackrulescollection/) hinzugefügt werden.

Nachdem Sie die Sammlung erstellt haben, können Sie sie mithilfe der Methode [setFontFallBackRulesCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) des [FontsManager](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsmanager/) der Präsentation zuweisen. Der [FontsManager](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsmanager/) steuert die Schriften in der gesamten Präsentation, und jede [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)-Instanz verfügt über einen eigenen [FontsManager](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsmanager/).

Sobald der [FontsManager](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsmanager/) mit der Fallback‑Schriftarten‑Sammlung initialisiert ist, werden die angegebenen Fallback‑Schriften während der Renderung der Präsentation angewendet.

## **Fallback‑Regeln anwenden**

Instanzen der Klasse [FontFallBackRule](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontfallbackrule/) können in einer [FontFallBackRulesCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontfallbackrulescollection/) organisiert werden. Sie können Regeln zur Sammlung hinzufügen oder daraus entfernen.

Diese Sammlung kann anschließend mithilfe der Methode [setFontFallBackRulesCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) der Klasse [FontsManager](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsmanager/) zugewiesen werden, die die Schriften in der gesamten Präsentation steuert.

Jede [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) verfügt über eine Methode [getFontsManager](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getFontsManager), die ihre eigene Instanz der Klasse [FontsManager](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsmanager/) zurückgibt.

Das folgende Beispiel zeigt, wie Sie eine Sammlung von Fallback‑Schriftartenregeln erstellen und sie dem [FontsManager](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsmanager/) einer Präsentation zuweisen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule, FontFallBackRulesCollection, Presentation

presentation = Presentation()
try:
    fallback_rules = FontFallBackRulesCollection()

    tamil_rule = FontFallBackRule(0x0B80, 0x0BFF, "Vijaya")
    fallback_rules.add(tamil_rule)
    hiragana_rule = FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")
    fallback_rules.add(hiragana_rule)

    presentation.getFontsManager().setFontFallBackRulesCollection(fallback_rules)
finally:
    presentation.dispose()
```

Nachdem der [FontsManager](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsmanager/) mit der Fallback‑Schriftarten‑Sammlung initialisiert wurde, werden die Fallback‑Schriften während der Renderung der Präsentation angewendet.

{{% alert color="info" title="Hinweis" %}}
Lesen Sie mehr darüber, wie man eine Präsentation mit einer Fallback‑Schriftart [rendern](/slides/de/python-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Werden meine Fallback‑Regeln in die PPTX‑Datei eingebettet und nach dem Speichern in PowerPoint sichtbar sein?**

Nein. Fallback‑Regeln sind Laufzeit‑Render‑Einstellungen; sie werden nicht in die PPTX serialisiert und erscheinen nicht in der PowerPoint‑Benutzeroberfläche.

**Wird Fallback auf Text in SmartArt, WordArt, Diagrammen und Tabellen angewendet?**

Ja. Der gleiche Glyph‑Substitutions‑Mechanismus wird für jeden Text in diesen Objekten verwendet.

**Stellt Aspose Schriftarten mit der Bibliothek zur Verfügung?**

Nein. Sie fügen Schriftarten selbst hinzu und verwenden sie auf eigene Verantwortung.

**Können Ersatz/Substitution für fehlende Schriftarten und Fallback für fehlende Glyphen zusammen verwendet werden?**

Ja. Sie sind unabhängige Stufen derselben Schriftauflösungs‑Pipeline: Zuerst ermittelt die Engine die Verfügbarkeit von Schriftarten ([replacement](/slides/de/python-java/font-replacement/)/[substitution](/slides/de/python-java/font-substitution/)), dann füllt Fallback Lücken für fehlende Glyphen in verfügbaren Schriftarten.