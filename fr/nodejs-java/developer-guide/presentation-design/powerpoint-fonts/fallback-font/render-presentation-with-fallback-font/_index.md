---
title: Rendu des présentations avec des polices de secours en JavaScript
linktitle: Rendu des présentations
type: docs
weight: 30
url: /fr/nodejs-java/render-presentation-with-fallback-font/
keywords:
- police de secours
- rendu PowerPoint
- rendu de présentation
- rendu de diapositive
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Rendre les présentations avec des polices de secours dans Aspose.Slides pour Node.js – garder le texte cohérent entre PPT, PPTX et ODP avec des exemples de code JavaScript étape par étape."
---

L'exemple suivant comprend ces étapes :

1. Nous [créons une collection de règles de polices de secours](/slides/fr/nodejs-java/create-fallback-fonts-collection/).
1. [Supprimez](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) une règle de police de secours et [addFallBackFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) à une autre règle.
1. Définissez la collection de règles sur [getFontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--) méthode.
1. Avec la méthode [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) nous pouvons enregistrer la présentation au même format, ou l'enregistrer dans un autre. Après que la collection de règles de police de secours soit définie sur [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager), ces règles sont appliquées lors de toute opération sur la présentation : enregistrer, rendre, convertir, etc.
```javascript
// Créer une nouvelle instance d'une collection de règles
var rulesList = new aspose.slides.FontFallBackRulesCollection();
// Créer un certain nombre de règles
rulesList.add(new aspose.slides.FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
for (let i = 0; i < rulesList.size(); i++) {
    let fallBackRule = rulesList.get_Item(0);
    // Tentative de suppression de la police de secours "Tahoma" des règles chargées
    fallBackRule.remove("Tahoma");
    // Et mettre à jour les règles pour la plage spécifiée
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000)) {
        fallBackRule.addFallBackFonts("Verdana");
    }
}
// Nous pouvons également supprimer toutes les règles existantes de la liste
if (rulesList.size() > 0) {
    rulesList.remove(rulesList.get_Item(0));
}
var pres = new aspose.slides.Presentation("input.pptx");
try {
    // Assignation d'une liste de règles préparée pour l'utilisation
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);
    // Rendu de la miniature en utilisant la collection de règles initialisée et en l'enregistrant au format JPEG
    var slideImage = pres.getSlides().get_Item(0).getImage(1.0, 1.0);
    // Enregistrer l'image sur le disque au format JPEG
    try {
        slideImage.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" %}} 
En savoir plus sur la façon de [Convertir PPT et PPTX en JPG avec JavaScript](/slides/fr/nodejs-java/convert-powerpoint-to-jpg/).
{{% /alert %}}