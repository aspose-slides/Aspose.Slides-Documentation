---
title: Configurer les collections de polices de secours en С++
linktitle: Collection de police de secours
type: docs
weight: 20
url: /fr/cpp/create-fallback-fonts-collection/
keywords:
- police de secours
- règle de secours
- collection de polices
- configurer la police
- installer la police
- PowerPoint
- OpenDocument
- présentation
- С++
- Aspose.Slides
description: "Configurer une collection de polices de secours dans Aspose.Slides pour С++ afin de garder le texte cohérent et net dans les présentations PowerPoint et OpenDocument."
---

## **Appliquer les règles de secours**

Des instances de [FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule) class peuvent être organisées dans [FontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rules_collection), qui implémente l’interface [IFontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_font_fall_back_rules_collection). Il est possible d’ajouter ou de supprimer des règles de la collection.

Cette collection peut ensuite être passée à la [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/cpp/class/aspose.slides.fonts_manager#a375fc71abd64891a39673751d127d924) méthode de la classe [FontsManager](https://reference.aspose.com/slides/cpp/class/aspose.slides.fonts_manager). FontsManager contrôle les polices dans l’ensemble de la présentation. En savoir plus [À propos de FontsManager et FontsLoader](/slides/fr/cpp/about-fontsmanager-and-fontsloader/).

Chaque [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) possède une [get_FontsManager()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#acee582a9c243cbd63e30634c9714514a) méthode avec sa propre instance de la classe FontsManager.

Voici un exemple de création d’une collection de règles de polices de secours et de son affectation au FontsManager d’une présentation donnée :  
``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```


Après l’initialisation de FontsManager avec la collection de polices de secours, les polices de secours sont appliquées lors du rendu de la présentation.

{{% alert color="primary" %}} 
En savoir plus sur la façon de [Render Presentation with Fallback Font](/slides/fr/cpp/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Mes règles de secours seront‑elles intégrées dans le fichier PPTX et visibles dans PowerPoint après l’enregistrement ?**

Non. Les règles de secours sont des paramètres de rendu d’exécution ; elles ne sont pas sérialisées dans le PPTX et n’apparaîtront pas dans l’interface de PowerPoint.

**La fonctionnalité de secours s’applique‑t‑elle au texte à l’intérieur de SmartArt, WordArt, des graphiques et des tableaux ?**

Oui. Le même mécanisme de substitution de glyphes est utilisé pour tout texte dans ces objets.

**Aspose distribue‑t‑il des polices avec la bibliothèque ?**

Non. Vous ajoutez et utilisez les polices de votre côté, sous votre propre responsabilité.

**Le remplacement/substitution des polices manquantes et le secours pour les glyphes manquants peuvent‑ils être utilisés simultanément ?**

Oui. Ce sont des étapes indépendantes du même pipeline de résolution des polices : d’abord le moteur résout la disponibilité des polices ([replacement](/slides/fr/cpp/font-replacement/)/[substitution](/slides/fr/cpp/font-substitution/)), puis le secours comble les lacunes des glyphes manquants dans les polices disponibles.