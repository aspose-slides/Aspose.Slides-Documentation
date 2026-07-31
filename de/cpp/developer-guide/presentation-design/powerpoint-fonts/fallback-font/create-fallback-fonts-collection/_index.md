---
title: Konfigurieren von Fallback-Schriftartsammlungen in C++
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
- C++
- Aspose.Slides
description: "Richten Sie eine Fallback-Schriftartsammlung in Aspose.Slides für C++ ein, um Text in PowerPoint- und OpenDocument-Präsentationen konsistent und klar darzustellen."
---
## **Übersicht**

Aspose.Slides ermöglicht es Ihnen, eine Sammlung von Fallback‑Schriftartregeln für eine Präsentation zu konfigurieren. Jede Fallback‑Regel wird durch die Klasse `FontFallBackRule` dargestellt und kann zu einer `FontFallBackRulesCollection` hinzugefügt werden, die das Interface `IFontFallBackRulesCollection` implementiert.

Nachdem Sie die Sammlung erstellt haben, können Sie sie mit der Methode `set_FontFallBackRulesCollection` des `FontsManager` der Präsentation zuweisen. Der `FontsManager` steuert die Schriftarten in der gesamten Präsentation, und jede `Presentation`‑Instanz verfügt über ihren eigenen `FontsManager`.

Sobald der `FontsManager` mit der Fallback‑Schriftartsammlung initialisiert ist, werden die angegebenen Fallback‑Schriftarten bei der Darstellung der Präsentation angewendet.

## **Fallback‑Regeln anwenden**

Instanzen der Klasse [FontFallBackRule](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontfallbackrule/) können in einer [FontFallBackRulesCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontfallbackrulescollection/) organisiert werden, die das Interface [IFontFallBackRulesCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/ifontfallbackrulescollection/) implementiert. Es ist möglich, Regeln aus der Sammlung hinzuzufügen oder zu entfernen.

Anschließend kann diese Sammlung an die Methode [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) der Klasse [FontsManager](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontsmanager/) übergeben werden. Der FontsManager steuert die Schriftarten in der gesamten Präsentation.

Jede [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) besitzt eine Methode [get_FontsManager()](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_fontsmanager/), die ihre eigene Instanz der FontsManager‑Klasse zurückgibt.

Im Folgenden finden Sie ein Beispiel, wie Sie eine Sammlung von Fallback‑Schriftartregeln erstellen und in den FontsManager einer bestimmten Präsentation zuweisen:  

``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

Nachdem der FontsManager mit der Fallback‑Schriftartsammlung initialisiert wurde, werden die Fallback‑Schriftarten bei der Darstellung der Präsentation angewendet.

{{% alert color="primary" %}} 
Erfahren Sie mehr, wie Sie die [Präsentation mit Fallback‑Schriftart rendern](/slides/de/cpp/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Werden meine Fallback‑Regeln in die PPTX‑Datei eingebettet und nach dem Speichern in PowerPoint sichtbar?**

Nein. Fallback‑Regeln sind Laufzeit‑Rendering‑Einstellungen; sie werden nicht in die PPTX serialisiert und erscheinen nicht in der PowerPoint‑Benutzeroberfläche.

**Wird Fallback auf Text in SmartArt, WordArt, Diagrammen und Tabellen angewendet?**

Ja. Der gleiche Glyph‑Substitutionsmechanismus wird für jeglichen Text in diesen Objekten verwendet.

**Stellt Aspose Schriftarten mit der Bibliothek bereit?**

Nein. Sie fügen Schriftarten selbst hinzu und verwenden sie auf eigene Verantwortung.

**Können Ersatz‑/Substitution für fehlende Schriftarten und Fallback für fehlende Glyphen zusammen verwendet werden?**

Ja. Sie sind unabhängige Stufen derselben Schriftauflösungs‑Pipeline: Zuerst löst die Engine die Verfügbarkeit von Schriftarten ([replacement](/slides/de/cpp/font-replacement/)/[substitution](/slides/de/cpp/font-substitution/)) auf, danach füllt Fallback Lücken für fehlende Glyphen in den verfügbaren Schriftarten.