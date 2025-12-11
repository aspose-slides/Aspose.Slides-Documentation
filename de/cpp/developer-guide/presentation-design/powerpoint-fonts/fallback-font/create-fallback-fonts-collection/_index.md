---
title: Fallback-Schriftart‑Sammlungen in С++ konfigurieren
linktitle: Fallback‑Schriftartsammlung
type: docs
weight: 20
url: /de/cpp/create-fallback-fonts-collection/
keywords:
- Fallback‑Schriftart
- Fallback‑Regel
- Schriftartsammlung
- Schriftart konfigurieren
- Schriftart einrichten
- PowerPoint
- OpenDocument
- Präsentation
- С++
- Aspose.Slides
description: "Richten Sie eine Fallback‑Schriftartsammlung in Aspose.Slides für С++ ein, um Text in PowerPoint‑ und OpenDocument‑Präsentationen konsistent und klar zu halten."
---

## **Fallback-Regeln anwenden**

Instanzen der [FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule)-Klasse können in [FontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rules_collection)-Sammlung organisiert werden, die das [IFontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_font_fall_back_rules_collection)-Interface implementiert. Es ist möglich, Regeln aus der Sammlung hinzuzufügen oder zu entfernen.

Anschließend kann diese Sammlung an die [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/cpp/class/aspose.slides.fonts_manager#a375fc71abd64891a39673751d127d924)-Methode der [FontsManager](https://reference.aspose.com/slides/cpp/class/aspose.slides.fonts_manager)-Klasse übergeben werden. FontsManager steuert die Schriften in der gesamten Präsentation. Weiterlesen [Über FontsManager und FontsLoader](/slides/de/cpp/about-fontsmanager-and-fontsloader/).

Jede [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)-Klasse hat eine [get_FontsManager()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#acee582a9c243cbd63e30634c9714514a)-Methode mit ihrer eigenen Instanz der FontsManager‑Klasse.

Hier ist ein Beispiel, wie man eine Sammlung von Fallback‑Schriftarten‑Regeln erstellt und sie dem FontsManager einer bestimmten Präsentation zuweist:   ``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```


Nachdem der FontsManager mit einer Fallback‑Schriftarten‑Sammlung initialisiert wurde, werden die Fallback‑Schriften während der Präsentationsdarstellung angewendet.

{{% alert color="primary" %}} 
Erfahren Sie mehr, wie Sie eine [Präsentation mit Fallback‑Schrift rendern](/slides/de/cpp/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Werden meine Fallback‑Regeln in die PPTX‑Datei eingebettet und nach dem Speichern in PowerPoint sichtbar sein?**

Nein. Fallback‑Regeln sind Laufzeit‑Rendering‑Einstellungen; sie werden nicht in die PPTX serialisiert und erscheinen nicht in der PowerPoint‑Benutzeroberfläche.

**Wird Fallback auf Text innerhalb von SmartArt, WordArt, Diagrammen und Tabellen angewendet?**

Ja. Der gleiche Glyph‑Substitutions‑Mechanismus wird für jeden Text in diesen Objekten verwendet.

**Liefert Aspose Schriftarten mit der Bibliothek aus?**

Nein. Sie fügen Schriftarten selbst hinzu und nutzen sie auf eigene Verantwortung.

**Können Ersatz/Substitution für fehlende Schriftarten und Fallback für fehlende Glyphen zusammen verwendet werden?**

Ja. Sie sind unabhängige Stufen derselben Schrift‑Auflösungs‑Pipeline: Zunächst löst die Engine die Verfügbarkeit von Schriftarten ([replacement](/slides/de/cpp/font-replacement/)/[substitution](/slides/de/cpp/font-substitution/)) auf, anschließend füllt Fallback Lücken für fehlende Glyphen in verfügbaren Schriftarten.