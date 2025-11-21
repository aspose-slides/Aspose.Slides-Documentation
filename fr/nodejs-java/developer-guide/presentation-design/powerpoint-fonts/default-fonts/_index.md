---
title: Polices par défaut - API JavaScript PowerPoint
linktitle: Polices par défaut
type: docs
weight: 30
url: /fr/nodejs-java/default-font/
description: L'API JavaScript PowerPoint vous permet de définir la police par défaut pour le rendu de la présentation en PDF, XPS ou vignettes. Cet article montre comment définir DefaultRegular Font et DefaultAsian Font pour les utiliser comme polices par défaut.
---

## **Utilisation des polices par défaut pour le rendu de la présentation**
Aspose.Slides vous permet de définir la police par défaut pour le rendu de la présentation en PDF, XPS ou vignettes. Cet article montre comment définir DefaultRegularFont et DefaultAsianFont pour les utiliser comme polices par défaut. Veuillez suivre les étapes ci‑dessous pour charger des polices à partir de répertoires externes en utilisant Aspose.Slides pour Node.js via l’API Java :

1. Créez une instance de [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions).
1. [Définir le DefaultRegularFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) à la police souhaitée. Dans l’exemple suivant, j’ai utilisé Wingdings.
1. [Définir le DefaultAsianFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) à la police souhaitée. J’ai utilisé Wingdings dans l’exemple suivant.
1. Chargez la présentation en utilisant Presentation et en définissant les options de chargement.
1. Maintenant, générez la vignette de la diapositive, le PDF et le XPS pour vérifier les résultats.

L’implémentation ci‑dessus est fournie ci‑après.
```javascript
// Utilisez les options de chargement pour définir les polices par défaut régulières et asiatiques
var loadOptions = new aspose.slides.LoadOptions(aspose.slides.LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");
// Charger la présentation
var pres = new aspose.slides.Presentation("DefaultFonts.pptx", loadOptions);
try {
    // Générer la vignette de la diapositive
    var slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
        // enregistrer l'image sur le disque.
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    // Générer le PDF
    pres.save("output_out.pdf", aspose.slides.SaveFormat.Pdf);
    // Générer le XPS
    pres.save("output_out.xps", aspose.slides.SaveFormat.Xps);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Que affectent exactement DefaultRegularFont et DefaultAsianFont — uniquement l’exportation ou également les vignettes, PDF, XPS, HTML et SVG ?**

Ils font partie du pipeline de rendu pour toutes les sorties prises en charge. Cela inclut les vignettes de diapositive, [PDF](/slides/fr/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/fr/nodejs-java/convert-powerpoint-to-xps/), [images raster](/slides/fr/nodejs-java/convert-powerpoint-to-png/), [HTML](/slides/fr/nodejs-java/convert-powerpoint-to-html/), et [SVG](/slides/fr/nodejs-java/render-a-slide-as-an-svg-image/), car Aspose.Slides utilise la même logique de mise en page et de résolution de glyphes pour ces cibles.

**Les polices par défaut sont‑elles appliquées lors d’une simple lecture et sauvegarde d’un PPTX sans aucun rendu ?**

Non. Les polices par défaut sont importantes lorsque le texte doit être mesuré et dessiné. Un simple enregistrement ouvert‑fermé d’une présentation ne modifie pas les portions de police stockées ni la structure du fichier. Les polices par défaut interviennent lors d’opérations qui rendent ou réagencent le texte.

**Si j’ajoute mes propres dossiers de polices ou fournis des polices depuis la mémoire, seront‑elles prises en compte lors du choix des polices par défaut ?**

Oui. [Sources de polices personnalisées](/slides/fr/nodejs-java/custom-font/) élargissent le catalogue des familles et glyphes disponibles que le moteur peut utiliser. Les polices par défaut et toute [règles de secours](/slides/fr/nodejs-java/fallback-font/) seront résolues à partir de ces sources en premier, offrant une couverture plus fiable sur les serveurs et dans les conteneurs.

**Les polices par défaut affecteront‑elles les métriques du texte (crénage, avances) et donc les sauts de ligne et le retour à la ligne ?**

Oui. Modifier la police change les métriques des glyphes et peut modifier les sauts de ligne, le retour à la ligne et la pagination lors du rendu. Pour la stabilité de la mise en page, [intégrer les polices originales](/slides/fr/nodejs-java/embedded-font/) ou choisissez des familles par défaut et de secours métriquement compatibles.

**Y a‑t‑il un intérêt à définir des polices par défaut si toutes les polices utilisées dans la présentation sont intégrées ?**

Souvent ce n’est pas nécessaire, car les [polices intégrées](/slides/fr/nodejs-java/embedded-font/) assurent déjà une apparence cohérente. Les polices par défaut restent utiles comme filet de sécurité pour les caractères non couverts par le sous‑ensemble intégré ou lorsqu’un fichier mélange du texte intégré et non intégré.