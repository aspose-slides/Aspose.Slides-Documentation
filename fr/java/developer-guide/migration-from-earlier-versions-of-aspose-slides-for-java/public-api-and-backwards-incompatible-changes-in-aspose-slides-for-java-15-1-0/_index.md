---
title: API publique et changements incompatibles rétroactifs dans Aspose.Slides for Java 15.1.0
linktitle: Aspose.Slides for Java 15.1.0
type: docs
weight: 100
url: /fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
keywords:
- migration
- code hérité
- code moderne
- approche héritée
- approche moderne
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Passez en revue les mises à jour de l'API publique et les changements incompatibles dans Aspose.Slides for Java afin de migrer en douceur vos solutions de présentations PowerPoint PPT, PPTX et ODP."
---
{{% alert color="info" %}} 
Cette page répertorie toutes les [ajoutées](/slides/fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) classes, méthodes, propriétés, etc., ainsi que les nouvelles restrictions et les autres [modifications](/slides/fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) introduites avec l'API Aspose.Slides for Java 15.1.0.
{{% /alert %}} {{% alert color="info" %}} 
Il existe des problèmes connus avec certaines puces d'image et les objets WordArt qui seront corrigés dans Aspose.Slides for Java 15.2.0.
{{% /alert %}} 
## **Modifications de l'API publique**
### **La fonctionnalité de substitution de polices a été ajoutée**
La possibilité de remplacer les polices globalement dans toute la présentation et temporairement pour le rendu a été ajoutée.

Une nouvelle méthode getFontsManager() de la classe Presentation a été introduite. La classe FontsManager possède les membres suivants :

**IFontSubstRuleCollection getFontSubstRuleList**() method  
Il s'agit de la collection d'instances IFontSubstRule utilisées pour substituer les polices lors du rendu. IFontSubstRule possède les méthodes getSourceFont() et getDestFont() implémentant l'interface IFontData ainsi que la méthode getReplaceFontCondition() permettant de choisir la condition de remplacement (« WhenInaccessible » ou « Always »).

**IFontData[] getFonts()** method can be used to retrieve all fonts used in the current presentation.  
La méthode **IFontData[] getFonts()** peut être utilisée pour récupérer toutes les polices utilisées dans la présentation actuelle.

**replaceFont(...)** methods can be used to persistently replace a font in a presentation.  
Les méthodes **replaceFont(...)** peuvent être utilisées pour remplacer de façon permanente une police dans une présentation.  

L'exemple suivant montre comment remplacer une police dans une présentation :

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("PresContainsArialFont.pptx");

IFontData sourceFont = new FontData("Arial");

IFontData destFont = new FontData("Times New Roman");

pres.getFontsManager().replaceFont(sourceFont, destFont);

pres.save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

```

Un autre exemple montre la substitution de police lors du rendu lorsqu'elle est inaccessible :

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");
try {
    IFontData sourceFont = new FontData("SomeRareFont");
    IFontData destFont = new FontData("Arial");

    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);

    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);

    // La police Arial sera utilisée à la place de SomeRareFont lorsqu'elle est inaccessible.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    slideImage.dispose();
} finally {
    if (pres != null) pres.dispose();
}
```