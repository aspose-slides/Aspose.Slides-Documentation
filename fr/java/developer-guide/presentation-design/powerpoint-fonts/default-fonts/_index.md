---
title: Polices par défaut - API Java PowerPoint
linktitle: Polices par défaut
type: docs
weight: 30
url: /java/default-font/
description: L'API Java PowerPoint vous permet de définir la police par défaut pour le rendu de la présentation en PDF, XPS ou en vignettes. Cet article montre comment définir la police DefaultRegular et la police DefaultAsian à utiliser comme polices par défaut.
---


## **Utiliser les polices par défaut pour le rendu de la présentation**
Aspose.Slides vous permet de définir la police par défaut pour le rendu de la présentation en PDF, XPS ou en vignettes. Cet article montre comment définir la police DefaultRegular et la police DefaultAsian à utiliser comme polices par défaut. Veuillez suivre les étapes ci-dessous pour charger des polices à partir de répertoires externes en utilisant l'API Aspose.Slides pour Java :

1. Créez une instance de [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/LoadOptions).
1. [Définissez la DefaultRegularFont](https://reference.aspose.com/slides/java/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) à votre police souhaitée. Dans l'exemple suivant, j'ai utilisé Wingdings.
1. [Définissez la DefaultAsianFont](https://reference.aspose.com/slides/java/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) à votre police souhaitée. J'ai utilisé Wingdings dans l'exemple suivant.
1. Chargez la présentation en utilisant Presentation et en réglant les options de chargement.
1. Maintenant, générez la vignette de la diapositive, le PDF et le XPS pour vérifier les résultats.

L'implémentation ci-dessus est donnée ci-dessous.

```java
// Utilisez les options de chargement pour définir les polices régulières et asiatiques par défaut
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");

// Charger la présentation
Presentation pres = new Presentation("DefaultFonts.pptx", loadOptions);
try {
    // Générer la vignette de la diapositive
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
         // sauver l'image sur le disque.
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