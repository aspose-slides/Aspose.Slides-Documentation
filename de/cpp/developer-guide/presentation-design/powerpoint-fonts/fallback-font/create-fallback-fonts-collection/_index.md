---
title: Fallback-Schriftartsammlungen in С++ konfigurieren
linktitle: Fallback-Schriftartsammlung
type: docs
weight: 20
url: /de/cpp/create-fallback-fonts-collection/
keywords:
- Fallback-Schriftart
- Fallback-Regel
- Schriftartsammlung
- Schriftart konfigurieren
- Schriftart einrichten
- PowerPoint
- OpenDocument
- Präsentation
- С++
- Aspose.Slides
description: "Richten Sie eine Fallback-Schriftartsammlung in Aspose.Slides für С++ ein, um Text in PowerPoint- und OpenDocument-Präsentationen konsistent und klar zu halten."
---

## **Fallback-Regeln anwenden**

Instanzen der [FontFallBackRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrule/) Klasse können in einer [FontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrulescollection/) organisiert werden, die das [IFontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ifontfallbackrulescollection/) Interface implementiert. Es ist möglich, Regeln zur Sammlung hinzuzufügen oder zu entfernen.

Anschließend kann diese Sammlung an die [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) Methode der [FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/) Klasse übergeben werden. FontsManager steuert Fonts über die gesamte Präsentation hinweg.

Jede [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) verfügt über eine [get_FontsManager()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_fontsmanager/) Methode mit einer eigenen Instanz der FontsManager‑Klasse.

Hier ein Beispiel, wie eine Sammlung von Fallback‑Font‑Regeln erstellt und dem FontsManager einer bestimmten Präsentation zugewiesen wird:  
``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```


Nachdem der FontsManager mit der Fallback‑Font‑Sammlung initialisiert wurde, werden die Fallback‑Fonts beim Rendering der Präsentation angewendet.

{{% alert color="primary" %}} 
Erfahren Sie mehr darüber, wie Sie eine [Render Presentation with Fallback Font](/slides/de/cpp/render-presentation-with-fallback-font/) durchführen.
{{% /alert %}}

## **FAQ**

**Werden meine Fallback‑Regeln in die PPTX‑Datei eingebettet und nach dem Speichern in PowerPoint sichtbar sein?**

Nein. Fallback‑Regeln sind Laufzeit‑Rendering‑Einstellungen; sie werden nicht in die PPTX‑Datei serialisiert und erscheinen nicht in der PowerPoint‑Benutzeroberfläche.

**Wird der Fallback auf Text in SmartArt, WordArt, Diagrammen und Tabellen angewendet?**

Ja. Der gleiche Glyph‑Substitutions‑Mechanismus wird für Text in allen diesen Objekten verwendet.

**Verteilt Aspose irgendwelche Fonts mit der Bibliothek?**

Nein. Sie fügen Fonts selbst hinzu und verwenden sie auf eigene Verantwortung.

**Können Ersatz/Substitution für fehlende Fonts und Fallback für fehlende Glyphen zusammen verwendet werden?**

Ja. Sie sind unabhängige Stufen derselben Font‑Auflösungs‑Pipeline: Zuerst löst die Engine die Verfügbarkeit von Fonts ([replacement](/slides/de/cpp/font-replacement/)/[substitution](/slides/de/cpp/font-substitution/)) und anschließend füllt der Fallback Lücken für fehlende Glyphen in verfügbaren Fonts.