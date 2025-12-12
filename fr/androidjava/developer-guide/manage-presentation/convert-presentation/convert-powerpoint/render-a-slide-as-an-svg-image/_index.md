---
title: Rendu des diapositives de présentation en images SVG sur Android
linktitle: Diapositive vers SVG
type: docs
weight: 50
url: /fr/androidjava/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint vers SVG
- présentation en SVG
- diapositive en SVG
- PPT en SVG
- PPTX en SVG
- enregistrer PPT en SVG
- enregistrer PPTX en SVG
- exporter PPT en SVG
- exporter PPTX en SVG
- rendre la diapositive
- convertir la diapositive
- exporter la diapositive
- image vectorielle
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Apprenez comment rendre les diapositives PowerPoint en images SVG à l'aide d'Aspose.Slides pour Android. Des visuels de haute qualité avec des exemples de code Java simples."
---

## **Format SVG**

SVG—un acronyme pour Scalable Vector Graphics—est un type ou un format graphique standard utilisé pour rendre des images bidimensionnelles. SVG stocke les images sous forme de vecteurs en XML avec des détails qui définissent leur comportement ou leur apparence.

SVG est l'un des rares formats d'images qui répond à des exigences très élevées dans ces domaines : évolutivité, interactivité, performances, accessibilité, programmabilité, et d'autres. Pour ces raisons, il est couramment utilisé dans le développement web.

Vous pouvez souhaiter utiliser les fichiers SVG lorsque vous devez

- **imprimer votre présentation dans un *format très grand*.** Les images SVG peuvent être agrandies à n'importe quelle résolution ou niveau. Vous pouvez redimensionner les images SVG autant de fois que nécessaire sans sacrifier la qualité.
- **utiliser les graphiques et diagrammes de vos diapositives sur *différents médias ou plates‑formes*.** La plupart des lecteurs peuvent interpréter les fichiers SVG.
- **utiliser les *tailles les plus petites possibles d'images*.** Les fichiers SVG sont généralement plus petits que leurs équivalents haute résolution dans d'autres formats, en particulier les formats basés sur le bitmap (JPEG ou PNG).

## **Rendre une diapositive en tant qu'image SVG**

Aspose.Slides for Android via Java vous permet d'exporter les diapositives de vos présentations sous forme d'images SVG. Suivez ces étapes pour générer des images SVG :

1. Créez une instance de la classe Presentation.
2. Parcourez toutes les diapositives de la présentation.
3. Écrivez chaque diapositive dans son propre fichier SVG à l'aide de FileOutputStream.

{{% alert color="primary" %}} 
Vous pouvez essayer notre [application web gratuite](https://products.aspose.app/slides/conversion/ppt-to-svg) dans laquelle nous avons implémenté la fonction de conversion PPT vers SVG d'Aspose.Slides for Android via Java.
{{% /alert %}} 

Ce code d'exemple en Java montre comment convertir un PPT en SVG en utilisant Aspose.Slides:
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

**Pourquoi le SVG résultant peut-il apparaître différemment selon les navigateurs ?**

La prise en charge de certaines fonctionnalités SVG est implémentée différemment par les moteurs de navigation. Les paramètres [SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/) aident à atténuer les incompatibilités.

**Est‑il possible d'exporter non seulement les diapositives mais aussi des formes individuelles en SVG ?**

Oui. Toute [forme peut être enregistrée en tant que SVG distinct](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) , ce qui est pratique pour les icônes, pictogrammes et la réutilisation de graphiques.

**Les diapositives multiples peuvent‑elles être combinées en un seul SVG (bande/document) ?**

Le scénario standard est une diapositive → un SVG. Combiner plusieurs diapositives en un seul canevas SVG est une étape de post‑traitement effectuée au niveau de l'application.