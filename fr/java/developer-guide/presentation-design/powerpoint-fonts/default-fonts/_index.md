---
title: Spécifier les polices par défaut pour les présentations en Java
linktitle: Police par défaut
type: docs
weight: 30
url: /fr/java/default-font/
keywords:
- police par défaut
- police normale
- police normale
- police asiatique
- export PDF
- export XPS
- export d'images
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Définir les polices par défaut dans Aspose.Slides pour Java afin d'assurer une conversion correcte de PowerPoint (PPT, PPTX) et OpenDocument (ODP) vers PDF, XPS et images."
---

## **Utiliser les polices par défaut pour le rendu d’une présentation**
Aspose.Slides vous permet de définir la police par défaut pour le rendu de la présentation en PDF, XPS ou en miniatures. Cet article montre comment définir DefaultRegularFont et DefaultAsianFont pour les utiliser comme polices par défaut. Veuillez suivre les étapes ci‑dessous pour charger des polices depuis des répertoires externes en utilisant l’API Aspose.Slides pour Java :

1. Créez une instance de [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/LoadOptions).
1. [Set the DefaultRegularFont](https://reference.aspose.com/slides/java/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) à la police souhaitée. Dans l’exemple suivant, j’ai utilisé Wingdings.
1. [Set the DefaultAsianFont](https://reference.aspose.com/slides/java/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) à la police souhaitée. J’ai utilisé Wingdings dans l’exemple suivant.
1. Chargez la présentation en utilisant Presentation et en définissant les options de chargement.
1. Maintenant, générez la miniature de la diapositive, le PDF et le XPS pour vérifier le résultat.

L’implémentation ci‑dessus est fournie ci‑dessous.
```java
// Utilisez les options de chargement pour définir les polices régulières et asiatiques par défaut
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");

// Load the presentation
Presentation pres = new Presentation("DefaultFonts.pptx", loadOptions);
try {
    // Générer la miniature de la diapositive
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

**Qu’est‑ce que DefaultRegularFont et DefaultAsianFont influencent exactement — uniquement l’exportation ou également les miniatures, PDF, XPS, HTML et SVG ?**

Ils participent à la chaîne de rendu pour toutes les sorties prises en charge. Cela inclut les miniatures de diapositives, [PDF](/slides/fr/java/convert-powerpoint-to-pdf/), [XPS](/slides/fr/java/convert-powerpoint-to-xps/), [images raster](/slides/fr/java/convert-powerpoint-to-png/), [HTML](/slides/fr/java/convert-powerpoint-to-html/), et [SVG](/slides/fr/java/render-a-slide-as-an-svg-image/), car Aspose.Slides utilise la même logique de mise en page et de résolution des glyphes pour ces cibles.

**Les polices par défaut sont‑elles appliquées lors d’une simple lecture et sauvegarde d’un PPTX sans aucun rendu ?**

Non. Les polices par défaut ne sont prises en compte que lorsque le texte doit être mesuré et dessiné. Une simple ouverture‑et‑sauvegarde d’une présentation ne modifie pas les run de police stockés ni la structure du fichier. Les polices par défaut interviennent lors des opérations qui rendent ou reformattent le texte.

**Si j’ajoute mes propres dossiers de polices ou fournis des polices en mémoire, seront‑ils pris en compte lors du choix des polices par défaut ?**

Oui. [Custom font sources](/slides/fr/java/custom-font/) élargissent le catalogue des familles et glyphes disponibles que le moteur peut utiliser. Les polices par défaut et les [règles de secours](/slides/fr/java/fallback-font/) seront résolues d’abord contre ces sources, offrant une couverture plus fiable sur les serveurs et dans les conteneurs.

**Les polices par défaut affecteront‑elles les métriques du texte (crénage, avances) et donc les retours à la ligne et le wrapping ?**

Oui. Modifier la police change les métriques des glyphes et peut altérer les coupures de ligne, le wrapping et la pagination pendant le rendu. Pour une stabilité de mise en page, [intégrez les polices d’origine](/slides/fr/java/embedded-font/) ou choisissez des familles par défaut et de secours métriquement compatibles.

**Y a‑t‑il un intérêt à définir des polices par défaut si toutes les polices utilisées dans la présentation sont incorporées ?**

Souvent, ce n’est pas nécessaire, car les [polices incorporées](/slides/fr/java/embedded-font/) assurent déjà une apparence cohérente. Les polices par défaut restent toutefois utiles comme filet de sécurité pour les caractères non couverts par le sous‑ensemble incorporé ou lorsqu’un fichier mélange du texte incorporé et non incorporé.