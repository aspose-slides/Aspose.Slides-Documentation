---
title: Substitution de police - API C# PowerPoint
linktitle: Substitution de police
type: docs
weight: 70
url: /fr/net/font-substitution/
keywords: 
- police
- police de substitution
- PowerPoint
- présentation
- C#
- Csharp
- Aspose.Slides pour .NET
description: L'API C# PowerPoint vous permet de substituer des polices dans les présentations
---

## **Obtenir la substitution de police**

Pour vous permettre de découvrir les polices de la présentation qui sont substituées lors du processus de rendu de la présentation, Aspose.Slides fournit la méthode [GetSubstitution](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/) de l'interface [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/).

Le code C# vous montre comment obtenir toutes les substitutions de police qui sont effectuées lors du rendu d'une présentation :
```c#
using (Presentation pres = new Presentation(@"Presentation.pptx"))
{
    foreach (var fontSubstitution in pres.FontsManager.GetSubstitutions())
    {
        Console.WriteLine("{0} -> {1}", fontSubstitution.OriginalFontName, fontSubstitution.SubstitutedFontName);
    }
}
```


## **Définir des règles de substitution de police**

Aspose.Slides vous permet de définir des règles pour les polices qui déterminent ce qui doit être fait dans certaines conditions (par exemple, lorsqu'une police ne peut pas être accédée) de la manière suivante :

1. Charger la présentation pertinente.
2. Charger la police qui sera remplacée.
3. Charger la nouvelle police.
4. Ajouter une règle pour le remplacement.
5. Ajouter la règle à la collection de règles de remplacement de police de la présentation.
6. Générer l'image de la diapositive pour observer l'effet.

Ce code C# démontre le processus de substitution de police :

```c#
// Charge une présentation
Presentation presentation = new Presentation("Fonts.pptx");

// Charge la police source qui sera remplacée
IFontData sourceFont = new FontData("SomeRareFont");

// Charge la nouvelle police
IFontData destFont = new FontData("Arial");

// Ajoute une règle de police pour le remplacement de police
IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

// Ajoute la règle à la collection des règles de substitution de police
IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
fontSubstRuleCollection.Add(fontSubstRule);

// Ajoute la collection de règles de police à la liste des règles
presentation.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

using (IImage image = presentation.Slides[0].GetImage(1f, 1f))
{
    // Sauvegarde l'image sur le disque au format JPEG
    image.Save("Thumbnail_out.jpg", ImageFormat.Jpeg);
}
```

{{%  alert title="NOTE"  color="warning"   %}} 

Vous voudrez peut-être voir [**Remplacement de police**](/slides/fr/net/font-replacement/). 

{{% /alert %}}