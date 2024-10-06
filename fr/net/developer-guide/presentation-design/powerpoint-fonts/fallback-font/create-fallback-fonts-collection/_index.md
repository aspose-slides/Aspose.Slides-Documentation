---
title: Créer une collection de polices de secours
type: docs
weight: 20
url: /net/create-fallback-fonts-collection/
keywords: "Collection de polices de secours, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Collection de polices de secours dans PowerPoint en C# ou .NET"
---

Les instances de [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) peuvent être organisées en [FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection), qui implémente l'interface [IFontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontfallbackrulescollection). Il est possible d'ajouter ou de supprimer des règles de la collection.

Ensuite, cette collection peut être assignée à la propriété [FontFallBackRulesCollection ](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection)de la classe [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager). FontsManager contrôle les polices à travers la présentation. En savoir plus [À propos de FontsManager et FontsLoader](/slides/net/about-fontsmanager-and-fontsloader/).

Chaque [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)a une propriété [FontsManager ](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/fontsmanager)avec sa propre instance de la classe FontsManager.

Voici un exemple de création d'une collection de règles de polices de secours et son assignation au FontsManager d'une certaine présentation :  

```c#
using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```

Après que le FontsManager a été initialisé avec la collection de polices de secours, les polices de secours sont appliquées lors du rendu de la présentation.

{{% alert color="primary" %}} 
En savoir plus sur [Le rendu de la présentation avec une police de secours](/slides/net/render-presentation-with-fallback-font/).
{{% /alert %}}