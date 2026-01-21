---
title: Configurer les collections de polices de secours en C++
linktitle: Collection de polices de secours
type: docs
weight: 20
url: /fr/cpp/create-fallback-fonts-collection/
keywords:
- police de secours
- règle de secours
- collection de polices
- configurer la police
- mettre en place la police
- PowerPoint
- OpenDocument
- présentation
- С++
- Aspose.Slides
description: "Mettre en place une collection de polices de secours dans Aspose.Slides pour C++ afin de maintenir le texte cohérent et net dans les présentations PowerPoint et OpenDocument."
---

## **Appliquer les règles de secours**

Les instances de la classe [FontFallBackRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrule/) peuvent être organisées dans la [FontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrulescollection/), qui implémente l'interface [IFontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ifontfallbackrulescollection/). Il est possible d'ajouter ou de supprimer des règles de la collection.

Ensuite cette collection peut être passée à la méthode [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) de la classe [FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/). Le FontsManager contrôle les polices à travers la présentation.

Chaque [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) possède une méthode [get_FontsManager()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_fontsmanager/) avec sa propre instance de la classe FontsManager.

Voici un exemple de création d'une collection de règles de polices de secours et de son affectation au FontsManager d'une présentation donnée :
``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```


Après que le FontsManager est initialisé avec la collection de polices de secours, les polices de secours sont appliquées lors du rendu de la présentation.

{{% alert color="primary" %}} 
En savoir plus sur la façon de [Render Presentation with Fallback Font](/slides/fr/cpp/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Will my fallback rules be embedded into the PPTX file and visible in PowerPoint after saving?**  
Non. Les règles de secours sont des paramètres de rendu à l'exécution ; elles ne sont pas sérialisées dans le PPTX et n'apparaîtront pas dans l'interface de PowerPoint.

**Does fallback apply to text inside SmartArt, WordArt, charts, and tables?**  
Oui. Le même mécanisme de substitution de glyphes est utilisé pour tout texte dans ces objets.

**Does Aspose distribute any fonts with the library?**  
Non. Vous ajoutez et utilisez les polices de votre côté et sous votre propre responsabilité.

**Can replacement/substitution for missing fonts and fallback for missing glyphs be used together?**  
Oui. Ce sont des étapes indépendantes du même pipeline de résolution des polices : d'abord le moteur résout la disponibilité des polices ([replacement](/slides/fr/cpp/font-replacement/)/[substitution](/slides/fr/cpp/font-substitution/)), puis le secours comble les lacunes des glyphes manquants dans les polices disponibles.