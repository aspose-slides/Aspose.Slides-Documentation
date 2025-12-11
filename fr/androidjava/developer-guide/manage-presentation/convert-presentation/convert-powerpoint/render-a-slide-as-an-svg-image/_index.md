---
title: Rendu des diapositives de présentation en images SVG sur Android
linktitle: Diapositive en SVG
type: docs
weight: 50
url: /fr/androidjava/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint en SVG
- présentation en SVG
- diapositive en SVG
- PPT en SVG
- PPTX en SVG
- enregistrer PPT en SVG
- enregistrer PPTX en SVG
- exporter PPT en SVG
- exporter PPTX en SVG
- rendre diapositive
- convertir diapositive
- exporter diapositive
- image vectorielle
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Apprenez à rendre les diapositives PowerPoint en images SVG à l'aide d'Aspose.Slides pour Android. Des visuels de haute qualité avec des exemples de code Java simples."
---

## **Format SVG**

SVG—acronyme de Scalable Vector Graphics—est un type ou format d'images standard utilisé pour rendre des images bidimensionnelles. SVG stocke les images sous forme de vecteurs en XML avec des détails qui définissent leur comportement ou leur apparence. 

SVG est l’un des rares formats d'images qui répond à des exigences très élevées en matière de : évolutivité, interactivité, performances, accessibilité, programmabilité, et d’autres critères. Pour ces raisons, il est couramment utilisé dans le développement web. 

Vous pouvez choisir les fichiers SVG lorsque vous avez besoin de

- **imprimer votre présentation dans un *format très grand*.** Les images SVG peuvent être agrandies à n'importe quelle résolution ou niveau. Vous pouvez redimensionner les images SVG autant de fois que nécessaire sans sacrifier la qualité.
- **utiliser les graphiques et diagrammes de vos diapositives dans *différents supports ou plateformes*.** La plupart des lecteurs peuvent interpréter les fichiers SVG. 
- **utiliser les *tailles d'image les plus petites possibles*.** Les fichiers SVG sont généralement plus petits que leurs équivalents haute résolution dans d'autres formats, en particulier ceux basés sur le bitmap (JPEG ou PNG).

## **Rendre une diapositive en image SVG**

Aspose.Slides for Android via Java vous permet d’exporter les diapositives de vos présentations en images SVG. Suivez ces étapes pour générer des images SVG :

1. Créez une instance de la classe Presentation.
2. Parcourez toutes les diapositives de la présentation.
3. Écrivez chaque diapositive dans son propre fichier SVG via FileOutputStream.

{{% alert color="primary" %}} 

Vous pouvez essayer notre [application web gratuite](https://products.aspose.app/slides/conversion/ppt-to-svg) dans laquelle nous avons implémenté la fonction de conversion PPT vers SVG d’Aspose.Slides for Android via Java.

{{% /alert %}} 

Ce code d’exemple en Java montre comment convertir un PPT en SVG avec Aspose.Slides :
``` java
Presentation pres = new Presentation("pres.pptx");
try {
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);

        FileOutputStream fileStream = new FileOutputStream("slide-" + index + ".svg");
        try {
            slide.writeAsSvg(fileStream);
        } finally {
            fileStream.close();
        }
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Pourquoi le SVG généré peut-il apparaître différemment selon les navigateurs ?**

Le support de certaines fonctionnalités SVG est implémenté différemment par les moteurs de navigateur. Les paramètres [SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/) aident à atténuer les incompatibilités.

**Est‑il possible d’exporter non seulement des diapositives mais aussi des formes individuelles en SVG ?**

Oui. Toute [shape can be saved as a separate SVG](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-), ce qui est pratique pour les icônes, pictogrammes et la réutilisation de graphiques.

**Peut‑on combiner plusieurs diapositives en un seul SVG (strip/document) ?**

Le scénario standard est une diapositive → un SVG. Combiner plusieurs diapositives dans un même canevas SVG est une étape de post‑traitement effectuée au niveau de l’application.