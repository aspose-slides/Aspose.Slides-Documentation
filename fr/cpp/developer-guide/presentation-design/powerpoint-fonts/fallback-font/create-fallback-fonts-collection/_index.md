---
title: Créer une Collection de Polices de Repli
type: docs
weight: 20
url: /cpp/create-fallback-fonts-collection/
---

Les instances de la classe [FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule) peuvent être organisées en [FontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rules_collection), qui implémente l'interface [IFontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_font_fall_back_rules_collection). Il est possible d'ajouter ou de supprimer des règles de la collection.

Ensuite, cette collection peut être transmise à la méthode [set_FontFallBackRulesCollection() ](https://reference.aspose.com/slides/cpp/class/aspose.slides.fonts_manager#a375fc71abd64891a39673751d127d924)de la classe [FontsManager](https://reference.aspose.com/slides/cpp/class/aspose.slides.fonts_manager). FontsManager contrôle les polices dans la présentation. Lisez-en plus [À propos de FontsManager et FontsLoader](/slides/cpp/about-fontsmanager-and-fontsloader/).

Chaque [Presentation ](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)a une méthode [get_FontsManager() ](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#acee582a9c243cbd63e30634c9714514a)avec sa propre instance de la classe FontsManager.

Voici un exemple de création d'une collection de règles de polices de repli et de l'assigner au FontsManager d'une présentation donnée :  

``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

Après que le FontsManager ait été initialisé avec la collection de polices de repli, les polices de repli sont appliquées lors du rendu de la présentation.

{{% alert color="primary" %}} 
Lisez-en plus sur [Rendre la Présentation avec une Police de Repli](/slides/cpp/render-presentation-with-fallback-font/).
{{% /alert %}}