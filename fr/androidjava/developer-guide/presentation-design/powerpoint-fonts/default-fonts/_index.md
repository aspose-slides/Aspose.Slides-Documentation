---
title: Spécifier les polices par défaut de la présentation sur Android
linktitle: Police par défaut
type: docs
weight: 30
url: /fr/androidjava/default-font/
keywords:
- police par défaut
- police régulière
- police normale
- police asiatique
- exportation PDF
- exportation XPS
- exportation d'images
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Définir les polices par défaut dans Aspose.Slides pour Android via Java afin d'assurer une conversion correcte de PowerPoint (PPT, PPTX) et OpenDocument (ODP) vers PDF, XPS et images."
---

## **Utiliser les polices par défaut pour le rendu d’une présentation**
Aspose.Slides vous permet de définir la police par défaut pour le rendu de la présentation au format PDF, XPS ou vignettes. Cet article montre comment définir DefaultRegularFont et DefaultAsianFont pour les utiliser comme polices par défaut. Veuillez suivre les étapes ci‑dessous pour charger des polices depuis des répertoires externes en utilisant Aspose.Slides pour Android via l’API Java :

1. Créez une instance de [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LoadOptions).
2. [Définissez le DefaultRegularFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) à la police souhaitée. Dans l’exemple suivant, j’ai utilisé Wingdings.
3. [Définissez le DefaultAsianFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) à la police souhaitée. J’ai utilisé Wingdings dans l’exemple suivant.
4. Chargez la présentation en utilisant Presentation et en définissant les options de chargement.
5. Maintenant, générez la vignette de la diapositive, le PDF et le XPS pour vérifier les résultats.

L’implémentation ci‑dessus est fournie ci‑après.
```java
// Utilisez les options de chargement pour définir les polices par défaut régulières et asiatiques
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");

// Charger la présentation
Presentation pres = new Presentation("DefaultFonts.pptx", loadOptions);
try {
    // Générer la vignette de diapositive
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


## **FAQ**

**Que affectent exactement DefaultRegularFont et DefaultAsianFont — seulement l’exportation ou également les vignettes, le PDF, le XPS, le HTML et le SVG ?**

Ils participent à la chaîne de rendu pour toutes les sorties prises en charge. Cela inclut les vignettes de diapositive, [PDF](/slides/fr/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/fr/androidjava/convert-powerpoint-to-xps/), [images raster](/slides/fr/androidjava/convert-powerpoint-to-png/), [HTML](/slides/fr/androidjava/convert-powerpoint-to-html/), et [SVG](/slides/fr/androidjava/render-a-slide-as-an-svg-image/), car Aspose.Slides utilise la même logique de mise en page et de résolution des glyphes pour ces cibles.

**Les polices par défaut sont‑elles appliquées lors d’une simple lecture et sauvegarde d’un PPTX sans aucun rendu ?**

Non. Les polices par défaut sont importantes lorsque le texte doit être mesuré et dessiné. Un simple enregistrement sans modification ne change pas les runs de police stockés ni la structure du fichier. Les polices par défaut interviennent lors des opérations qui rendent ou re‑flow le texte.

**Si j’ajoute mes propres dossiers de polices ou fournis des polices depuis la mémoire, seront‑ils pris en compte lors du choix des polices par défaut ?**

Oui. [Sources de polices personnalisées](/slides/fr/androidjava/custom-font/) élargissent le catalogue des familles et glyphes disponibles que le moteur peut utiliser. Les polices par défaut et toutes les [règles de secours](/slides/fr/androidjava/fallback-font/) seront résolues d’abord contre ces sources, offrant une couverture plus fiable sur les serveurs et dans les conteneurs.

**Les polices par défaut affecteront‑elles les métriques du texte (crénage, avances) et donc les sauts de ligne et le retour à la ligne ?**

Oui. Modifier la police change les métriques des glyphes et peut modifier les sauts de ligne, le retour à la ligne et la pagination lors du rendu. Pour la stabilité de la mise en page, [intégrez les polices d’origine](/slides/fr/androidjava/embedded-font/) ou choisissez des familles par défaut et de secours compatibles métriquement.

**Y a‑t‑il un intérêt à définir des polices par défaut si toutes les polices utilisées dans la présentation sont intégrées ?**

Souvent ce n’est pas nécessaire, car les [polices intégrées](/slides/fr/androidjava/embedded-font/) assurent déjà une apparence cohérente. Les polices par défaut restent utiles comme filet de sécurité pour les caractères non couverts par le sous‑ensemble intégré ou lorsqu’un fichier mélange du texte intégré et non intégré.