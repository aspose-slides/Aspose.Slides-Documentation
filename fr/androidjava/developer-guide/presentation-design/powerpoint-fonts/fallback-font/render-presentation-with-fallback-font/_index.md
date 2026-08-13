---
title: Rendu des présentations avec des polices de secours sur Android
linktitle: Rendu des présentations
type: docs
weight: 30
url: /fr/androidjava/render-presentation-with-fallback-font/
keywords:
- police de secours
- rendu PowerPoint
- rendu de présentation
- rendu de diapositive
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Rendu des présentations avec des polices de secours dans Aspose.Slides pour Android – conservez la cohérence du texte entre PPT, PPTX et ODP grâce à des exemples de code Java détaillés."
---
## **Vue d'ensemble**

Aspose.Slides vous permet de rendre des présentations en utilisant des règles de police de secours. Cet article montre comment créer une collection de règles de police de secours, modifier ses règles en supprimant ou en ajoutant des polices de secours, et affecter la collection à l'aide de la méthode `FontsManager.setFontFallBackRulesCollection`.

Une fois la collection de règles de police de secours affectée au `FontsManager` de la présentation, les règles sont appliquées lors d'opérations telles que l'enregistrement, le rendu et la conversion de la présentation. L'exemple montre comment utiliser les règles configurées lors du rendu d'une miniature de diapositive et de son enregistrement au format image JPEG.

## **Rendre une diapositive en utilisant des règles de police de secours**

1. Nous [créons une collection de règles de police de secours](/slides/fr/androidjava/create-fallback-fonts-collection/).
2. [Supprimer](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) une règle de police de secours et [addFallBackFonts](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) à une autre règle.
3. Définissez la collection de règles à l'aide de la méthode [getFontsManager](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--).
4. Avec la méthode [Presentation.save](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) nous pouvons enregistrer la présentation dans le même format, ou l'enregistrer dans un autre. Après que la collection de règles de police de secours soit affectée au [FontsManager](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/FontsManager), ces règles sont appliquées lors de toute opération sur la présentation : enregistrement, rendu, conversion, etc.

```java
import com.aspose.slides.*;

// Créez une nouvelle instance d'une collection de règles
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// créer un certain nombre de règles
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    //Essayer de supprimer la police de secours "Tahoma" des règles chargées
    fallBackRule.remove("Tahoma");

    //Et mettre à jour les règles pour la plage spécifiée
    if ((fallBackRule.getRangeEndIndex() >= 0x400) && (fallBackRule.getRangeStartIndex() < 0x500))
        fallBackRule.addFallBackFonts("Verdana");
}

//Nous pouvons également supprimer toutes les règles existantes de la liste, en gardant au moins une règle pour le rendu avec
if (rulesList.size() > 1)
    rulesList.remove(rulesList.get_Item(1));

Presentation pres = new Presentation("input.pptx");
try {
    //Attribuer une liste de règles préparée pour l'utilisation
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Rendu d'une vignette en utilisant la collection de règles initialisée et en l'enregistrant au format JPEG
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

{{% alert color="info" %}} 
En savoir plus sur [Convertir PPT et PPTX en JPG sur Android](/slides/fr/androidjava/convert-powerpoint-to-jpg/).
{{% /alert %}}