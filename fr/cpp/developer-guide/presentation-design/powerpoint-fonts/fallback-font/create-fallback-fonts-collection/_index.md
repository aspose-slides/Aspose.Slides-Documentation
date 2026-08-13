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
- C++
- Aspose.Slides
description: "Configurez une collection de polices de secours dans Aspose.Slides pour C++ afin de garder le texte cohérent et net dans les présentations PowerPoint et OpenDocument."
---
## **Vue d'ensemble**

Aspose.Slides vous permet de configurer une collection de règles de police de secours pour une présentation. Chaque règle de secours est représentée par la classe `FontFallBackRule` et peut être ajoutée à une `FontFallBackRulesCollection`, qui implémente l'interface `IFontFallBackRulesCollection`.

Après avoir créé la collection, vous pouvez l'assigner à l'aide de la méthode `set_FontFallBackRulesCollection` du `FontsManager` de la présentation. Le `FontsManager` contrôle les polices dans toute la présentation, et chaque instance de `Presentation` possède son propre `FontsManager`.

Une fois le `FontsManager` initialisé avec la collection de polices de secours, les polices de secours spécifiées sont appliquées lors du rendu de la présentation.

## **Appliquer des règles de secours**

Des instances de la classe [FontFallBackRule](https://reference.aspose.com/slides/fr/cpp/aspose.slides/fontfallbackrule/) peuvent être organisées dans une [FontFallBackRulesCollection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/fontfallbackrulescollection/), qui implémente l'interface [IFontFallBackRulesCollection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ifontfallbackrulescollection/). Il est possible d'ajouter ou de supprimer des règles de la collection.

Ensuite, cette collection peut être passée à la méthode [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) de la classe [FontsManager](https://reference.aspose.com/slides/fr/cpp/aspose.slides/fontsmanager/). Le FontsManager contrôle les polices dans toute la présentation.

Chaque [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) possède une méthode [get_FontsManager()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/get_fontsmanager/) avec sa propre instance de la classe FontsManager.

Voici un exemple de création d'une collection de règles de polices de secours et de son affectation au FontsManager d'une présentation donnée :

``` cpp
#include <DOM/Fonts/FontFallBackRule.h>
#include <DOM/Fonts/FontFallBackRulesCollection.h>
#include <DOM/IFontFallBackRule.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

Après que le FontsManager ait été initialisé avec la collection de polices de secours, les polices de secours sont appliquées lors du rendu de la présentation.

{{% alert color="info" %}} 
En savoir plus sur la façon de [Rendre une présentation avec une police de secours](/slides/fr/cpp/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

### Mes règles de secours seront-elles intégrées dans le fichier PPTX et visibles dans PowerPoint après l'enregistrement ?

Non. Les règles de secours sont des paramètres de rendu à l'exécution ; elles ne sont pas sérialisées dans le PPTX et n'apparaîtront pas dans l'interface de PowerPoint.

### Le secours s'applique-t-il au texte à l'intérieur de SmartArt, WordArt, graphiques et tableaux ?

Oui. Le même mécanisme de substitution de glyphes est utilisé pour tout texte dans ces objets.

### Aspose distribue-t-il des polices avec la bibliothèque ?

Non. Vous ajoutez et utilisez les polices de votre côté et sous votre propre responsabilité.

### Le remplacement / la substitution des polices manquantes et le secours des glyphes manquants peuvent-ils être utilisés ensemble ?

Oui. Ce sont des étapes indépendantes du même pipeline de résolution de police : d'abord le moteur résout la disponibilité des polices ([replacement](/slides/fr/cpp/font-replacement/)/[substitution](/slides/fr/cpp/font-substitution/)), puis le secours comble les lacunes des glyphes manquants dans les polices disponibles.