---
title: API publique et modifications incompatibles rétroactives dans Aspose.Slides pour .NET 15.1.0
linktitle: Aspose.Slides pour .NET 15.1.0
type: docs
weight: 130
url: /fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/
keywords:
- migration
- code hérité
- code moderne
- approche héritée
- approche moderne
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Examinez les mises à jour de l'API publique et les changements majeurs dans Aspose.Slides pour .NET afin de migrer en douceur vos solutions de présentations PowerPoint PPT, PPTX et ODP."
---

{{% alert color="primary" %}} 
Cette page répertorie toutes les [ajoutées](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) ou [supprimées](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) classes, méthodes, propriétés, etc., et d'autres modifications introduites avec l'API Aspose.Slides for .NET 15.1.0.
{{% /alert %}} 
## **Modifications de l'API publique**
#### **La fonctionnalité de substitution de polices a été ajoutée**
La possibilité de remplacer une police globalement dans la présentation et temporairement pour le rendu a été ajoutée.

La nouvelle propriété "FontsManager" de la classe Presentation a été introduite. La classe FontsManager possède les membres suivants :

**IFontSubstRuleCollection FontSubstRuleList** Propriété

Cette collection d'instances IFontSubstRule est utilisée pour substituer les polices lors du rendu. IFontSubstRule possède les propriétés SourceFont et DestFont qui implémentent l'interface IFontData ainsi que la propriété ReplaceFontCondition permettant de choisir la condition de remplacement ("WhenInaccessible" ou "Always").

**IFontData[] GetFonts()** Méthode

Utilisée pour récupérer toutes les polices utilisées dans la présentation actuelle.

**ReplaceFont** Méthodes

Utilisée pour remplacer de façon persistante une police dans la présentation.  

L'exemple suivant montre comment remplacer une police dans la présentation :

``` csharp

             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);


``` 

Un autre exemple montre la substitution de police pour le rendu lorsqu'elle est inaccessible :

``` csharp

             Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

            IFontData sourceFont = new FontData("SomeRareFont");

            IFontData destFont = new FontData("Arial");

            IFontSubstRule fontSubstRule = new FontSubstRule(

                sourceFont, destFont, FontSubstCondition.WhenInaccessible);

            IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

            fontSubstRuleCollection.Add(fontSubstRule);

            pres.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

            // Arial font will be used instead of SomeRareFont when inaccessible

            pres.Slides[0].GetThumbnail();

```