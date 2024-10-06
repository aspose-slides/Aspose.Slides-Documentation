---
title: API public et changements incompatibles avec les versions précédentes dans Aspose.Slides pour .NET 15.1.0
type: docs
weight: 130
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/
---

{{% alert color="primary" %}} 

Cette page liste toutes les classes, méthodes, propriétés, etc., [ajoutées](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) ou [supprimées](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) et les autres changements introduits avec l'API Aspose.Slides pour .NET 15.1.0.

{{% /alert %}} 
## **Changements de l'API publique**
#### **La fonctionnalité de substitution des polices a été ajoutée**
La possibilité de remplacer une police globalement dans la présentation et temporairement pour le rendu a été ajoutée.

Une nouvelle propriété "FontsManager" de la classe Presentation a été introduite. La classe FontsManager a les membres suivants :

**IFontSubstRuleCollection FontSubstRuleList** Propriété

Cette collection d'instances IFontSubstRule est utilisée pour substituer les polices lors du rendu. IFontSubstRule a les propriétés SourceFont et DestFont implémentant l'interface IFontData et la propriété ReplaceFontCondition permettant de choisir la condition de remplacement ("WhenInaccessible" ou "Always").

**IFontData[] GetFonts()** Méthode

Utilisée pour récupérer toutes les polices utilisées dans la présentation actuelle.

**ReplaceFont** Méthodes

Utilisée pour remplacer de manière persistante une police dans la présentation.

L'exemple suivant montre comment remplacer une police dans la présentation :

``` csharp

             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);


``` 

Un autre exemple démontre la substitution de police pour le rendu lorsqu'elle est inaccessible :

``` csharp

             Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

            IFontData sourceFont = new FontData("SomeRareFont");

            IFontData destFont = new FontData("Arial");

            IFontSubstRule fontSubstRule = new FontSubstRule(

                sourceFont, destFont, FontSubstCondition.WhenInaccessible);

            IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

            fontSubstRuleCollection.Add(fontSubstRule);

            pres.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

            // La police Arial sera utilisée à la place de SomeRareFont lorsqu'elle est inaccessible

            pres.Slides[0].GetThumbnail();

```