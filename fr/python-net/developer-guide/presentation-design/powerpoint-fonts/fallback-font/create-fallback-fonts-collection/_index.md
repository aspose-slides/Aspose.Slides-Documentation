---
title: Créer une collection de polices de repli
type: docs
weight: 20
url: /python-net/create-fallback-fonts-collection/
keywords: "Collection de polices de repli, présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Collection de polices de repli dans PowerPoint en Python"
---

Les instances de la classe [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) peuvent être organisées en [FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/), qui implémente l'interface [IFontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ifontfallbackrulescollection/). Il est possible d'ajouter ou de supprimer des règles de la collection.

Ensuite, cette collection peut être assignée à la propriété [FontFallBackRulesCollection ](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/)du [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) classe. FontsManager contrôle les polices dans l'ensemble de la présentation. En savoir plus [À propos de FontsManager et FontsLoader](/slides/python-net/about-fontsmanager-and-fontsloader/).

Chaque [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)a une propriété [FontsManager ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)avec sa propre instance de la classe FontsManager.

Voici un exemple de la façon de créer une collection de règles de polices de repli et de l'assigner dans le FontsManager d'une certaine présentation :  

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
	userRulesList = slides.FontFallBackRulesCollection()

	userRulesList.add(slides.FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"))
	userRulesList.add(slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"))

	presentation.fonts_manager.font_fall_back_rules_collection = userRulesList
```

Après que le FontsManager ait été initialisé avec la collection de polices de repli, les polices de repli sont appliquées lors du rendu de la présentation.

{{% alert color="primary" %}} 
En savoir plus sur la façon de [Rendre une présentation avec une police de repli](/slides/python-net/render-presentation-with-fallback-font/).
{{% /alert %}}