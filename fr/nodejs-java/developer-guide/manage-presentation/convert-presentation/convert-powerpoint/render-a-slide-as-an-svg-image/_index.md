---
title: Rendre une diapositive en image SVG
type: docs
weight: 50
url: /fr/nodejs-java/render-a-slide-as-an-svg-image/
---

## **Format SVG**

SVG, acronyme de Scalable Vector Graphics, est un type ou format graphique standard utilisé pour rendre des images bidimensionnelles. SVG stocke les images sous forme de vecteurs dans du XML avec des détails qui définissent leur comportement ou leur apparence. 

SVG est l’un des rares formats d’image qui répond à des exigences très élevées en matière de : évolutivité, interactivité, performances, accessibilité, programmabilité, etc. Pour ces raisons, il est couramment utilisé dans le développement Web. 

Vous pouvez souhaiter utiliser des fichiers SVG lorsque vous devez

- **imprimer votre présentation dans un *format très grand*.** Les images SVG peuvent être agrandies à n’importe quelle résolution. Vous pouvez redimensionner les images SVG autant de fois que nécessaire sans perdre en qualité.
- **utiliser des graphiques et diagrammes de vos diapositives sur *différents supports ou plateformes*.** La plupart des lecteurs peuvent interpréter les fichiers SVG. 
- **utiliser les *tailles d'image les plus petites possibles*.** Les fichiers SVG sont généralement plus petits que leurs équivalents haute résolution dans d’autres formats, notamment ceux basés sur le bitmap (JPEG ou PNG).

## **Rendre les diapositives en images SVG**

Aspose.Slides for Node.js via Java vous permet d’exporter les diapositives de vos présentations au format SVG. Suivez ces étapes pour générer des images SVG :

1. Créez une instance de la classe Presentation.
2. Parcourez toutes les diapositives de la présentation.
3. Écrivez chaque diapositive dans son propre fichier SVG à l'aide de FileOutputStream.

{{% alert color="primary" %}} 

Vous pouvez essayer notre [free web application](https://products.aspose.app/slides/conversion/ppt-to-svg) dans lequel nous avons implémenté la fonction de conversion PPT vers SVG d’Aspose.Slides for Node.js via Java.

{{% /alert %}} 

Ce code d’exemple en JavaScript vous montre comment convertir un PPT en SVG à l’aide d’Aspose.Slides :
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var fileStream = java.newInstanceSync("java.io.FileOutputStream", ("slide-" + index) + ".svg");
        try {
            slide.writeAsSvg(fileStream);
        } finally {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Pourquoi le SVG résultant peut-il apparaître différemment selon les navigateurs ?**  
Le support de certaines fonctionnalités SVG est implémenté différemment par les moteurs de navigation. Les paramètres [SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) aident à lisser les incompatibilités.

**Est‑il possible d’exporter non seulement les diapositives mais aussi des formes individuelles au format SVG ?**  
Oui. Toute [forme peut être enregistrée en tant que SVG distinct](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/), ce qui est pratique pour les icônes, pictogrammes et la réutilisation de graphiques.

**Peut‑on combiner plusieurs diapositives en un seul SVG (bande/document) ?**  
Le scénario standard est une diapositive → un SVG. Combiner plusieurs diapositives dans un même canevas SVG constitue une étape de post‑traitement réalisée au niveau de l’application.