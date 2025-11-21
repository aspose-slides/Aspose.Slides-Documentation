---
title: Rendre les présentations avec des polices de secours dans .NET
linktitle: Rendre les présentations
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
description: "Rendre les présentations avec des polices de secours dans Aspose.Slides pour .NET – maintenir le texte cohérent entre PPT, PPTX et ODP avec des exemples de code C# étape par étape."
---

L'exemple suivant comprend ces étapes :

1. Nous [créer une collection de règles de polices de secours](/slides/fr/net/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/remove) une règle de police de secours et [AddFallBackFonts()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) à une autre règle.
1. Définissez la collection de règles sur la propriété [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection).
1. Avec la méthode [Presentation.Save()](https://reference.aspose.com/slides/net/aspose.slides.presentation/save/methods/4) nous pouvons enregistrer la présentation au même format, ou l'enregistrer dans un autre. Après que la collection de règles de polices de secours soit définie dans FontsManager, ces règles sont appliquées lors de toute opération sur la présentation : enregistrement, rendu, conversion, etc.
```c#
// Créer une nouvelle instance d'une collection de règles
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// créer un certain nombre de règles
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	//Essayer de supprimer la police de secours "Tahoma" des règles chargées
	fallBackRule.Remove("Tahoma");

	//Et mettre à jour les règles pour la plage spécifiée
	if ((fallBackRule.RangeEndIndex >= 0x4000) && (fallBackRule.RangeStartIndex < 0x5000))
		fallBackRule.AddFallBackFonts("Verdana");
}

//Nous pouvons également supprimer toutes les règles existantes de la liste
if (rulesList.Count > 0)
	rulesList.Remove(rulesList[0]);

using (Presentation pres = new Presentation("input.pptx"))
{
    //Attribuer une liste de règles préparée pour l'utilisation
    pres.FontsManager.FontFallBackRulesCollection = rulesList;

    // Rendu de la miniature en utilisant la collection de règles initialisée et en l'enregistrant au format PNG
    using (IImage image = pres.Slides[0].GetImage(1f, 1f))
    {
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```



{{% alert color="primary" %}} 
En savoir plus sur [Enregistrement et Conversion dans une Présentation](/slides/fr/net/creating-saving-and-converting-a-presentation/).
{{% /alert %}}