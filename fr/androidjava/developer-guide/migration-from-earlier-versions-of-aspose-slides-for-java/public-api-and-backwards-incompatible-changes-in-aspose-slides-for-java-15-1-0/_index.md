---
title: API public et modifications incompatibles dans Aspose.Slides pour Java 15.1.0
type: docs
weight: 100
url: /androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
---

{{% alert color="primary" %}} 

Cette page liste toutes les [ajouts](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) de classes, méthodes, propriétés, etc., toutes les nouvelles restrictions et autres [modifications](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) introduites avec l'API Aspose.Slides pour Java 15.1.0.

{{% /alert %}} {{% alert color="primary" %}} 

Il y a des problèmes connus avec certains puces d'image et objets WordArt qui seront corrigés dans Aspose.Slides pour Java 15.2.0.

{{% /alert %}} 
## **Modifications de l'API publique**
### **Fonctionnalité de substitution de polices ajoutée**
La possibilité de remplacer des polices mondialement dans la présentation et temporairement pour le rendu a été ajoutée.

Le nouveau méthode getFontsManager() de la classe Presentation a été introduite. La classe FontsManager a les membres suivants :

**IFontSubstRuleCollection getFontSubstRuleList**() méthode

Ceci est la collection d'instances IFontSubstRule utilisées pour substituer des polices lors du rendu. IFontSubstRule a les méthodes getSourceFont() et getDestFont() implémentant l'interface IFontData et la méthode getReplaceFontCondition() permettant de choisir la condition de remplacement ("WhenInaccessible" ou "Always").

**IFontData[] getFonts()** méthode peut être utilisé pour récupérer toutes les polices utilisées dans la présentation actuelle.

Les méthodes **replaceFont(...)** peuvent être utilisées pour remplacer de manière persistante une police dans une présentation.

L'exemple suivant montre comment remplacer une police dans une présentation :

``` java

 Presentation pres = new Presentation("PresContainsArialFont.pptx");

IFontData sourceFont = new FontData("Arial");

IFontData destFont = new FontData("Times New Roman");

pres.getFontsManager().replaceFont(sourceFont, destFont);

pres.save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

```

Un autre exemple montre la substitution de police pour le rendu lorsqu'elle est inaccessible :

``` java



Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

IFontData sourceFont = new FontData("SomeRareFont");

IFontData destFont = new FontData("Arial");

IFontSubstRule fontSubstRule = new FontSubstRule(

sourceFont, destFont, FontSubstCondition.WhenInaccessible);

IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

fontSubstRuleCollection.add(fontSubstRule);

pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);

// La police Arial sera utilisée à la place de SomeRareFont lorsqu'elle est inaccessible

pres.getSlides().get_Item(0).getThumbnail(1, 1);

```