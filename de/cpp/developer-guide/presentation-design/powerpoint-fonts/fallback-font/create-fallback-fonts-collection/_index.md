---
title: Erstellen einer Sammlung von Fallback-Schriften
type: docs
weight: 20
url: /cpp/create-fallback-fonts-collection/
---

Instanzen der [FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule) Klasse können in einer [FontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rules_collection) organisiert werden, die das [IFontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_font_fall_back_rules_collection) Interface implementiert. Es ist möglich, Regeln zur Sammlung hinzuzufügen oder zu entfernen.

Diese Sammlung kann dann an die [set_FontFallBackRulesCollection() ](https://reference.aspose.com/slides/cpp/class/aspose.slides.fonts_manager#a375fc71abd64891a39673751d127d924)Methode der [FontsManager](https://reference.aspose.com/slides/cpp/class/aspose.slides.fonts_manager) Klasse übergeben werden. FontsManager steuert die Schriften in der Präsentation. Erfahren Sie mehr [Über FontsManager und FontsLoader](/slides/cpp/about-fontsmanager-and-fontsloader/).

Jede [Presentation ](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)hat eine [get_FontsManager() ](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#acee582a9c243cbd63e30634c9714514a)Methode mit ihrer eigenen Instanz der FontsManager-Klasse.

Hier ist ein Beispiel, wie man eine Sammlung von Fallback-Schriftregeln erstellt und diese dem FontsManager einer bestimmten Präsentation zuweist:

``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

Nachdem der FontsManager mit der Sammlung von Fallback-Schriften initialisiert wurde, werden die Fallback-Schriften während des Renderns der Präsentation angewendet.

{{% alert color="primary" %}} 
Erfahren Sie mehr darüber, wie man eine [Präsentation mit Fallback-Schrift rendern](/slides/cpp/render-presentation-with-fallback-font/).
{{% /alert %}}