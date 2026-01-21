---
title: Rendu des présentations avec des polices de secours en Java
linktitle: Rendu des présentations
type: docs
weight: 30
url: /fr/java/render-presentation-with-fallback-font/
keywords:
- police de secours
- rendu PowerPoint
- rendu de présentation
- rendu de diapositive
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Rendez les présentations avec des polices de secours dans Aspose.Slides pour Java – maintenez le texte cohérent entre PPT, PPTX et ODP avec des exemples de code Java étape par étape."
---

L'exemple suivant comprend ces étapes :

1. Nous [create fallback font rules collection](/slides/fr/java/create-fallback-fonts-collection/).
2. [Remove](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) une règle de police de secours et [addFallBackFonts](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) à une autre règle.
3. Définissez la collection de règles sur la méthode [getFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) .
4. Avec la méthode [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-) nous pouvons enregistrer la présentation dans le même format ou la sauvegarder dans un autre. Après que la collection de règles de police de secours soit définie sur [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager), ces règles sont appliquées lors de toutes les opérations sur la présentation : enregistrement, rendu, conversion, etc.
```java
// Crée une nouvelle instance d'une collection de règles
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    //Essayer de supprimer la police de secours "Tahoma" des règles chargées
    fallBackRule.remove("Tahoma");

    //Et mettre à jour les règles pour la plage spécifiée
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000))
        fallBackRule.addFallBackFonts("Verdana");
}

//Nous pouvons également supprimer toutes les règles existantes de la liste
if (rulesList.size() > 0)
    rulesList.remove(rulesList.get_Item(0));

Presentation pres = new Presentation("input.pptx");
try {
    //Affectation d'une liste de règles préparée à utiliser
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    //Rendu de la miniature en utilisant la collection de règles initialisée et en enregistrant au format JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   //Enregistrer l'image sur le disque au format JPEG
   try {
         slideImage.save("Slide_0.jpg", ImageFormat.Jpeg);
   } finally {
        if (slideImage != null) slideImage.dispose();
   }
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" %}} 
En savoir plus sur la façon de [Convert PPT and PPTX to JPG in Java](/slides/fr/java/convert-powerpoint-to-jpg/).
{{% /alert %}}