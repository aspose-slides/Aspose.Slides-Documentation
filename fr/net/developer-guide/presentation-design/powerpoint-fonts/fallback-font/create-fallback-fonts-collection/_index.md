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
description: "Configurez une collection de polices de secours dans Aspose.Slides pour .NET afin de maintenir le texte cohérent et net dans les présentations PowerPoint et OpenDocument."
---
## **Vue d'ensemble**

Aspose.Slides vous permet de configurer une collection de règles de police de secours pour une présentation. Chaque règle de secours est représentée par la classe `FontFallBackRule` et peut être ajoutée à une `FontFallBackRulesCollection`, qui implémente l'interface `IFontFallBackRulesCollection`.

Après avoir créé la collection, vous pouvez l'assigner à la propriété `FontFallBackRulesCollection` du `FontsManager` de la présentation. Le `FontsManager` gère les polices à travers la présentation, et chaque instance de `Presentation` possède son propre `FontsManager`.

Une fois le `FontsManager` initialisé avec la collection de polices de secours, les polices de secours spécifiées sont appliquées lors du rendu de la présentation.

## **Appliquer les règles de secours**

Des instances de la classe [FontFallBackRule](https://reference.aspose.com/slides/fr/net/aspose.slides/FontFallBackRule) peuvent être organisées dans une [FontFallBackRulesCollection](https://reference.aspose.com/slides/fr/net/aspose.slides/fontfallbackrulescollection), qui implémente l'interface [IFontFallBackRulesCollection](https://reference.aspose.com/slides/fr/net/aspose.slides/ifontfallbackrulescollection). Il est possible d'ajouter ou de supprimer des règles de la collection.

Ensuite, cette collection peut être assignée à la propriété [FontFallBackRulesCollection](https://reference.aspose.com/slides/fr/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) du [FontsManager](https://reference.aspose.com/slides/fr/net/aspose.slides/fontsmanager). Le FontsManager contrôle les polices à travers la présentation.

Chaque [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation) possède une propriété [FontsManager](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/properties/fontsmanager) avec sa propre instance de la classe FontsManager.

Voici un exemple de création d'une collection de règles de polices de secours et de son assignation au FontsManager d'une présentation donnée :

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```

Après que le FontsManager soit initialisé avec la collection de polices de secours, les polices de secours sont appliquées lors du rendu de la présentation.

{{% alert color="info" %}} 
Lisez-en plus sur la façon de [Rendre une présentation avec une police de secours](/slides/fr/net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

### Mes règles de secours seront‑elles intégrées dans le fichier PPTX et visibles dans PowerPoint après l’enregistrement ?

Non. Les règles de secours sont des paramètres de rendu à l'exécution ; elles ne sont pas sérialisées dans le PPTX et n'apparaîtront pas dans l'interface de PowerPoint.

### Le secours s'applique‑t‑il au texte à l'intérieur des objets SmartArt, WordArt, des graphiques et des tableaux ?

Oui. Le même mécanisme de substitution de glyphes est utilisé pour tout texte dans ces objets.

### Aspose distribue‑t‑il des polices avec la bibliothèque ?

Non. Vous ajoutez et utilisez les polices de votre côté, sous votre propre responsabilité.

### Le remplacement/substitution des polices manquantes et le secours pour les glyphes manquants peuvent‑ils être utilisés conjointement ?

Oui. Ce sont des étapes indépendantes du même pipeline de résolution de polices : d'abord le moteur résout la disponibilité des polices ([replacement](/slides/fr/net/font-replacement/)/[substitution](/slides/fr/net/font-substitution/)), puis le secours comble les lacunes des glyphes manquants dans les polices disponibles.