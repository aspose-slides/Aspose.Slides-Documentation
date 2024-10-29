---
title: Rendre une présentation avec une police de remplacement
type: docs
weight: 30
url: /fr/net/render-presentation-with-fallback-font/
keywords: 
- police de remplacement
- rendre PowerPoint
- PowerPoint
- présentation
- C#
- Csharp
- Aspose.Slides pour .NET
description: "Rendre PowerPoint avec une police de remplacement en C# ou .NET"
---

L'exemple suivant comprend ces étapes :

1. Nous [créons une collection de règles de police de remplacement](/slides/fr/net/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/remove) une règle de police de remplacement et [AddFallBackFonts()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) à une autre règle.
1. Définir la collection de règles à la propriété [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection).
1. Avec la méthode [Presentation.Save()](https://reference.aspose.com/slides/net/aspose.slides.presentation/save/methods/4), nous pouvons enregistrer la présentation dans le même format ou l'enregistrer dans un autre. Après que la collection de règles de police de remplacement est définie pour FontsManager, ces règles sont appliquées lors de toute opération sur la présentation : sauvegarde, rendu, conversion, etc.

```c#
// Créer une nouvelle instance d'une collection de règles
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// créer un certain nombre de règles
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	//Essayer de retirer la police de remplacement "Tahoma" des règles chargées
	fallBackRule.Remove("Tahoma");

	//Et mettre à jour les règles pour la plage spécifiée
	if ((fallBackRule.RangeEndIndex >= 0x4000) && (fallBackRule.RangeStartIndex < 0x5000))
		fallBackRule.AddFallBackFonts("Verdana");
}

//Nous pouvons également retirer toutes les règles existantes de la liste
if (rulesList.Count > 0)
	rulesList.Remove(rulesList[0]);

using (Presentation pres = new Presentation("input.pptx"))
{
    //Affectation d'une liste de règles préparée à utiliser
    pres.FontsManager.FontFallBackRulesCollection = rulesList;

    // Rendu de la miniature en utilisant la collection de règles initialisée et sauvegarde au format PNG
    using (IImage image = pres.Slides[0].GetImage(1f, 1f))
    {
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

{{% alert color="primary" %}} 
Lisez-en plus sur [Sauvegarde et conversion dans la présentation](/slides/fr/net/creating-saving-and-converting-a-presentation/).
{{% /alert %}}