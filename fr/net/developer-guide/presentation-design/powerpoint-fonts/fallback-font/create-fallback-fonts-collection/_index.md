---
title: Configurer des collections de polices de secours dans .NET
linktitle: Collection de polices de secours
type: docs
weight: 20
url: /fr/net/create-fallback-fonts-collection/
keywords:
- police de secours
- règle de secours
- collection de polices
- configurer la police
- installer la police
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Configurez une collection de polices de secours dans Aspose.Slides pour .NET afin de garder le texte cohérent et net dans les présentations PowerPoint et OpenDocument."
---

## **Appliquer les règles de secours**

Les instances de la classe [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) peuvent être organisées dans la [FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection), qui implémente l'interface [IFontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontfallbackrulescollection). Il est possible d'ajouter ou de supprimer des règles de la collection.

Ensuite, cette collection peut être affectée à la propriété [FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) de la classe [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager). FontsManager gère les polices dans l'ensemble de la présentation.

Chaque [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) possède une propriété [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/fontsmanager) contenant sa propre instance de la classe FontsManager.

Voici un exemple de création d'une collection de règles de polices de secours et de son affectation au FontsManager d'une présentation donnée :
```c#
using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```


Après que FontsManager est initialisé avec la collection de polices de secours, les polices de secours sont appliquées lors du rendu de la présentation.

{{% alert color="primary" %}} 
En savoir plus sur la façon de [Rendre la présentation avec une police de secours](/slides/fr/net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Mes règles de secours seront‑elles intégrées au fichier PPTX et visibles dans PowerPoint après enregistrement ?**

**Non.** Les règles de secours sont des paramètres de rendu à l'exécution ; elles ne sont pas sérialisées dans le PPTX et ne apparaîtront pas dans l'interface de PowerPoint.

**Le secours s'applique‑t‑il au texte à l'intérieur de SmartArt, WordArt, graphiques et tableaux ?**

**Oui.** Le même mécanisme de substitution de glyphes est utilisé pour tout texte dans ces objets.

**Aspose distribue‑t‑il des polices avec la bibliothèque ?**

**Non.** Vous ajoutez et utilisez les polices de votre côté, sous votre propre responsabilité.

**Le remplacement/substitution des polices manquantes et le secours des glyphes manquants peuvent‑ils être utilisés conjointement ?**

**Oui.** Ce sont des étapes indépendantes du même pipeline de résolution des polices : d'abord le moteur résout la disponibilité des polices ([replacement](/slides/fr/net/font-replacement/)/[substitution](/slides/fr/net/font-substitution/)), puis le secours comble les lacunes des glyphes manquants dans les polices disponibles.