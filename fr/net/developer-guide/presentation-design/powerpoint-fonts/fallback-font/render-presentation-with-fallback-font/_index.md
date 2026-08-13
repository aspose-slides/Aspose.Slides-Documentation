---
title: Rendu de présentations avec des polices de secours en .NET
linktitle: Rendu de présentations
type: docs
weight: 30
url: /fr/net/render-presentation-with-fallback-font/
keywords:
- police de secours
- rendu PowerPoint
- rendu de présentation
- rendu de diapositive
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Rendre des présentations avec des polices de secours dans Aspose.Slides pour .NET – garder le texte cohérent entre PPT, PPTX et ODP avec des exemples de code C# étape par étape."
---
## **Vue d'ensemble**

Aspose.Slides vous permet de rendre des présentations en utilisant des règles de police de secours. Cet article montre comment créer une collection de règles de police de secours, modifier ses règles en supprimant ou en ajoutant des polices de secours, et affecter la collection à la propriété `FontsManager.FontFallBackRulesCollection`.

Une fois la collection de règles de police de secours affectée au `FontsManager` de la présentation, les règles sont appliquées lors d'opérations telles que l'enregistrement, le rendu et la conversion de la présentation. L'exemple montre comment utiliser les règles configurées lors du rendu d'une vignette de diapositive et de son enregistrement au format PNG.

## **Rendre une diapositive en utilisant des règles de police de secours**

L'exemple suivant comprend ces étapes :

1. Nous [créons une collection de règles de police de secours](/slides/fr/net/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/fr/net/aspose.slides/fontfallbackrule/methods/remove) une règle de police de secours et [AddFallBackFonts()](https://reference.aspose.com/slides/fr/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) à une autre règle.
1. Affecter la collection de règles à la propriété [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/fr/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection).
1. Avec la méthode [Presentation.Save()](https://reference.aspose.com/slides/fr/net/aspose.slides.presentation/save/methods/4) nous pouvons enregistrer la présentation dans le même format, ou l’enregistrer dans un autre. Après que la collection de règles de police de secours soit définie dans FontsManager, ces règles sont appliquées lors de toute opération sur la présentation : enregistrement, rendu, conversion, etc.

```c#
using Aspose.Slides;

// Créer une nouvelle instance d'une collection de règles
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// créer plusieurs règles
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.Add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	// Essayer de supprimer la police de secours "Tahoma" des règles chargées
	fallBackRule.Remove("Tahoma");

	// Et mettre à jour les règles pour la plage spécifiée
	if ((fallBackRule.RangeEndIndex >= 0x400) && (fallBackRule.RangeStartIndex < 0x500))
		fallBackRule.AddFallBackFonts("Verdana");
}

// Nous pouvons également supprimer toutes les règles existantes de la liste, en conservant au moins une règle pour le rendu
if (rulesList.Count > 1)
	rulesList.Remove(rulesList[1]);

using (Presentation pres = new Presentation("input.pptx"))
{
    // Affecter une liste de règles préparée pour l'utilisation
    pres.FontsManager.FontFallBackRulesCollection = rulesList;

    // Rendu de la vignette en utilisant la collection de règles initialisée et en l'enregistrant au format PNG
    using (IImage image = pres.Slides[0].GetImage(1f, 1f))
    {
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

{{% alert color="info" %}} 
En savoir plus sur [Enregistrement et conversion dans Presentation](/slides/fr/net/convert-powerpoint-to-png/).
{{% /alert %}}