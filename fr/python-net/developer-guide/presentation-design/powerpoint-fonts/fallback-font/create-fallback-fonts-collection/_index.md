---
title: Configurer les collections de polices de secours en Python
linktitle: Collection de polices de secours
type: docs
weight: 20
url: /fr/python-net/create-fallback-fonts-collection/
keywords:
- police de secours
- règle de secours
- collection de polices
- configurer la police
- mettre en place la police
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Configurer une collection de polices de secours dans Aspose.Slides pour Python via .NET afin de garder le texte cohérent et net dans les présentations PowerPoint et OpenDocument."
---

## **Appliquer les règles de secours**

Les instances de la classe [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) peuvent être organisées dans la [FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/). Il est possible d'ajouter ou de supprimer des règles de la collection.

Cette collection peut ensuite être assignée à la propriété [font_fall_back_rules_collection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/font_fall_back_rules_collection/) de la classe [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/). FontsManager contrôle les polices sur l’ensemble de la présentation. En savoir plus [À propos de FontsManager et FontsLoader](/slides/fr/python-net/about-fontsmanager-and-fontsloader/).

Chaque [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) possède une propriété [fonts_manager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/fonts_manager/) avec sa propre instance de la classe FontsManager.

Voici un exemple de création d’une collection de règles de polices de secours et de son assignation au FontsManager d’une présentation donnée :
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
	userRulesList = slides.FontFallBackRulesCollection()

	userRulesList.add(slides.FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"))
	userRulesList.add(slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"))

	presentation.fonts_manager.font_fall_back_rules_collection = userRulesList
```


Après que FontsManager est initialisé avec la collection de polices de secours, les polices de secours sont appliquées lors du rendu de la présentation.

{{% alert color="primary" %}} 
En savoir plus sur la façon de [Rendu de la présentation avec une police de secours](/slides/fr/python-net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Mes règles de secours seront‑elles incorporées dans le fichier PPTX et visibles dans PowerPoint après enregistrement ?**

Non. Les règles de secours sont des paramètres de rendu à l'exécution ; elles ne sont pas sérialisées dans le PPTX et n'apparaîtront pas dans l'interface de PowerPoint.

**Le secours s'applique‑t‑il au texte à l'intérieur de SmartArt, WordArt, graphiques et tableaux ?**

Oui. Le même mécanisme de substitution de glyphes est utilisé pour tout texte dans ces objets.

**Aspose distribue‑t‑il des polices avec la bibliothèque ?**

Non. Vous ajoutez et utilisez les polices de votre côté, sous votre propre responsabilité.

**Le remplacement/substitution des polices manquantes et le secours pour les glyphes manquants peuvent‑ils être utilisés ensemble ?**

Oui. Ils sont des étapes indépendantes du même pipeline de résolution de police : d'abord le moteur résout la disponibilité des polices ([replacement](/slides/fr/python-net/font-replacement/)/[substitution](/slides/fr/python-net/font-substitution/)), puis le secours comble les lacunes des glyphes manquants dans les polices disponibles.