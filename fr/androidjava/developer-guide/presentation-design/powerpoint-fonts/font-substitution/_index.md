---
title: Substitution de police - API Java PowerPoint
linktitle: Substitution de police
type: docs
weight: 70
url: /fr/androidjava/font-substitution/
keywords: "Police, police de substitution, présentation PowerPoint, Java, Aspose.Slides pour Android via Java"
description: "Substituer une police dans PowerPoint en Java"
---

Aspose.Slides vous permet de définir des règles pour les polices qui déterminent ce qui doit être fait dans certaines conditions (par exemple, lorsqu'une police ne peut pas être accessible) de cette manière :

1. Chargez la présentation pertinente.
2. Chargez la police qui sera remplacée.
3. Chargez la nouvelle police.
4. Ajoutez une règle pour le remplacement.
5. Ajoutez la règle à la collection de règles de remplacement de police de la présentation.
6. Générez l'image de la diapositive pour observer l'effet.

Ce code Java démontre le processus de substitution de police :

```java
// Charge une présentation
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Charge la police source qui sera remplacée
    IFontData sourceFont = new FontData("SomeRareFont");
    
    // Charge la nouvelle police
    IFontData destFont = new FontData("Arial");
    
    // Ajoute une règle de police pour le remplacement de police
    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);
    
    // Ajoute la règle à la collection de règles de substitution de police
    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    
    // Ajoute une collection de règles de police à la liste des règles
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    
    // La police Arial sera utilisée à la place de SomeRareFont lorsque cette dernière est inaccessible
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);
    
    // Sauvegarde l'image sur le disque au format JPEG
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert title="NOTE"  color="warning"   %}} 

Vous voudrez peut-être voir [**Remplacement de police**](/slides/fr/androidjava/font-replacement/).

{{% /alert %}}