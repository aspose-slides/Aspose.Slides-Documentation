---
title: "Configurer les polices de repli en Python"
linktitle: "Configurer les polices de repli"
type: docs
weight: 20
url: /fr/python-net/create-fallback-fonts-collection/
keywords:
- "police de repli"
- "règle de repli"
- "collection de polices"
- "configurer police"
- "installer police"
- "PowerPoint"
- "OpenDocument"
- "présentation"
- "Python"
- "Aspose.Slides"
description: "Configurez une collection de polices de repli dans Aspose.Slides pour Python via .NET afin de maintenir le texte cohérent et net dans les présentations PowerPoint et OpenDocument."
---

## **Appliquer les règles de repli**

Les instances de la classe [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) peuvent être organisées en [FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/), qui implémente l'interface [IFontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ifontfallbackrulescollection/). Il est possible d'ajouter ou de supprimer des règles de la collection.

Ensuite, cette collection peut être affectée à la propriété [FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) de la classe [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/). FontsManager contrôle les polices dans l'ensemble de la présentation. En savoir plus [À propos de FontsManager et FontsLoader](/slides/fr/python-net/about-fontsmanager-and-fontsloader/).

Chaque [Présentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) possède une propriété [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) avec sa propre instance de la classe FontsManager.

Voici un exemple montrant comment créer une collection de règles de polices de repli et l'assigner au FontsManager d'une présentation donnée :
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    userRulesList = slides.FontFallBackRulesCollection()

    userRulesList.add(slides.FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"))
    userRulesList.add(slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"))

    presentation.fonts_manager.font_fall_back_rules_collection = userRulesList
```


Après que FontsManager a été initialisé avec la collection de polices de repli, les polices de repli sont appliquées lors du rendu de la présentation.

{{% alert color="primary" %}} 
En savoir plus sur la façon de [Rendre la présentation avec une police de repli](/slides/fr/python-net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Mes règles de repli seront-elles intégrées dans le fichier PPTX et visibles dans PowerPoint après l'enregistrement ?**

Non. Les règles de repli sont des paramètres de rendu à l'exécution ; elles ne sont pas sérialisées dans le PPTX et n'apparaîtront pas dans l'interface de PowerPoint.

**Le repli s'applique-t-il au texte à l'intérieur des SmartArt, WordArt, graphiques et tableaux ?**

Oui. Le même mécanisme de substitution de glyphes est utilisé pour tout texte dans ces objets.

**Aspose fournit‑il des polices avec la bibliothèque ?**

Non. Vous ajoutez et utilisez les polices de votre côté, sous votre propre responsabilité.

**Le remplacement/substitution des polices manquantes et le repli pour les glyphes manquants peuvent-ils être utilisés conjointement ?**

Oui. Ce sont des étapes indépendantes du même pipeline de résolution des polices : d'abord le moteur résout la disponibilité des polices ([remplacement](/slides/fr/python-net/font-replacement/)/[substitution](/slides/fr/python-net/font-substitution/)), puis le repli comble les lacunes des glyphes manquants dans les polices disponibles.