---
title: Polices par défaut - API Java PowerPoint
linktitle: Polices par défaut
type: docs
weight: 30
url: /fr/androidjava/default-font/
description: L'API Java PowerPoint vous permet de définir la police par défaut pour le rendu de la présentation au format PDF, XPS ou vignettes. Cet article montre comment définir DefaultRegular Font et DefaultAsian Font comme polices par défaut.
---


## **Utilisation des Polices par Défaut pour le Rendu de la Présentation**
Aspose.Slides vous permet de définir la police par défaut pour le rendu de la présentation au format PDF, XPS ou vignettes. Cet article montre comment définir DefaultRegular Font et DefaultAsian Font comme polices par défaut. Veuillez suivre les étapes ci-dessous pour charger des polices depuis des répertoires externes en utilisant Aspose.Slides pour Android via l'API Java :

1. Créez une instance de [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LoadOptions).
1. [Définissez la DefaultRegularFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) sur la police de votre choix. Dans l'exemple suivant, j'ai utilisé Wingdings.
1. [Définissez la DefaultAsianFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) sur la police de votre choix. J'ai utilisé Wingdings dans l'exemple suivant.
1. Chargez la présentation en utilisant Presentation et en définissant les options de chargement.
1. Maintenant, générez la vignette de la diapositive, le PDF et le XPS pour vérifier les résultats.

L'implémentation de ce qui précède est donnée ci-dessous.

```java
// Utilisez les options de chargement pour définir les polices régulières et asiatiques par défaut
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");

// Chargez la présentation
Presentation pres = new Presentation("DefaultFonts.pptx", loadOptions);
try {
    // Générer la vignette de la diapositive
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
         // enregistrer l'image sur le disque.
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }

    // Générer le PDF
    pres.save("output_out.pdf", SaveFormat.Pdf);

    // Générer le XPS
    pres.save("output_out.xps", SaveFormat.Xps);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```