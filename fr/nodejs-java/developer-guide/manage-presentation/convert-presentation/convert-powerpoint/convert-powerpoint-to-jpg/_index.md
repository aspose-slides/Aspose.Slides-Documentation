---
title: Convertir PPT et PPTX en JPG en JavaScript
linktitle: PowerPoint en JPG
type: docs
weight: 60
url: /fr/nodejs-java/convert-powerpoint-to-jpg/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPT
- convertir PPTX
- PowerPoint en JPG
- présentation en JPG
- diapositive en JPG
- PPT en JPG
- PPTX en JPG
- enregistrer PowerPoint en JPG
- enregistrer présentation en JPG
- enregistrer diapositive en JPG
- enregistrer PPT en JPG
- enregistrer PPTX en JPG
- exporter PPT en JPG
- exporter PPTX en JPG
- Node.js
- JavaScript
- Aspose.Slides
description: "Convertir les diapositives PowerPoint (PPT, PPTX) en images JPG de haute qualité en JavaScript avec Aspose.Slides pour Node.js via Java en utilisant des exemples de code rapides et fiables."
---

## **À propos de la conversion PowerPoint en JPG**
Grâce à [**Aspose.Slides API**](https://products.aspose.com/slides/nodejs-java/) vous pouvez convertir une présentation PowerPoint PPT ou PPTX en image JPG. Il est également possible de convertir PPT/PPTX en JPEG, PNG ou SVG. Avec ces fonctionnalités, il est facile de mettre en œuvre votre propre visualiseur de présentations, créer la vignette de chaque diapositive. Cela peut être utile si vous souhaitez protéger les diapositives de la présentation contre la copie, ou présenter la diapositive en mode lecture seule. Aspose.Slides permet de convertir l’ensemble de la présentation ou une diapositive précise en formats d’image.

{{% alert color="primary" %}} 
Pour voir comment Aspose.Slides convertit les fichiers PowerPoint en images JPG, vous pouvez essayer ces convertisseurs en ligne gratuits : PowerPoint [PPTX en JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) et [PPT en JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 
{{% /alert %}} 

![todo:image_alt_text](ppt-to-jpg.png)

## **Convertir PowerPoint PPT/PPTX en JPG**
Voici les étapes pour convertir PPT/PPTX en JPG :

1. Créez une instance du type [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Récupérez l’objet diapositive du type [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) depuis la collection [Presentation.getSlides()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--).
3. Créez la vignette de chaque diapositive puis convertissez‑la en JPG. La méthode [**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getImage-float-float-) est utilisée pour obtenir une vignette d’une diapositive, elle renvoie un objet [Imagess](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Images) en résultat. La méthode [getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getImage-aspose.slides.IRenderingOptions-float-float-) doit être appelée depuis la diapositive souhaitée du type [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide), les échelles de la vignette résultante sont passées à la méthode.
4. Après avoir récupéré la vignette de la diapositive, appelez la méthode [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) sur l’objet vignette. Passez le nom de fichier résultant et le format d’image à cette méthode.

{{% alert color="primary" %}}

**Remarque** : La conversion PPT/PPTX en JPG diffère de la conversion vers d’autres types dans l’API Aspose.Slides. Pour d’autres types, vous utilisez généralement la méthode [**Presentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-), mais ici vous avez besoin de la méthode [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save).

{{% /alert %}} 
```javascript
var pres = new aspose.slides.Presentation("PowerPoint-Presentation.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        // Crée une image à pleine échelle
        var slideImage = sld.getImage(1.0, 1.0);
        // Enregistre l'image sur le disque au format JPEG
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.jpg", sld.getSlideNumber()), aspose.slides.ImageFormat.Jpeg);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Convertir PowerPoint PPT/PPTX en JPG avec des dimensions personnalisées**
Pour modifier la dimension de la vignette et de l’image JPG résultantes, vous pouvez définir les valeurs *ScaleX* et *ScaleY* en les transmettant aux méthodes [**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getImage-float-float-) :

```javascript
var pres = new aspose.slides.Presentation("PowerPoint-Presentation.pptx");
try {
    // Définit les dimensions
    var desiredX = 1200;
    var desiredY = 800;
    // Obtient les valeurs mises à l'échelle de X et Y
    var ScaleX = 1.0 / pres.getSlideSize().getSize().getWidth() * desiredX;
    var ScaleY = 1.0 / pres.getSlideSize().getSize().getHeight() * desiredY;
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        // Crée une image à pleine échelle
        var slideImage = sld.getImage(ScaleX, ScaleY);
        // Enregistre l'image sur le disque au format JPEG
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.jpg", sld.getSlideNumber()), aspose.slides.ImageFormat.Jpeg);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Rendre les commentaires lors de l’enregistrement de la présentation en image**
Aspose.Slides pour Node.js via Java offre une fonctionnalité qui vous permet de rendre les commentaires dans les diapositives d’une présentation lorsque vous convertissez ces diapositives en images. Ce code JavaScript montre le fonctionnement :

```javascript
var pres = new aspose.slides.Presentation("presentation.pptx");
try {
    var notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);
    var opts = new aspose.slides.RenderingOptions();
    opts.setSlidesLayoutOptions(notesOptions);
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        var slideImage = sld.getImage(opts, java.newInstanceSync("java.awt.Dimension", 740, 960));
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.png", sld.getSlideNumber()));
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert title="Tip" color="primary" %}}

Aspose propose une [application Web Collage GRATUITE](https://products.aspose.app/slides/collage). En utilisant ce service en ligne, vous pouvez fusionner des images [JPG en JPG](https://products.aspose.app/slides/collage/jpg) ou PNG en PNG, créer des [grilles de photos](https://products.aspose.app/slides/collage/photo-grid), etc. 

{{% /alert %}}

## **Voir aussi**

Voir d’autres options pour convertir PPT/PPTX en image, telles que :

- [Conversion PPT/PPTX en SVG](/slides/fr/nodejs-java/render-a-slide-as-an-svg-image/).

## **FAQ**

**Cette méthode prend‑t‑elle en charge la conversion par lots ?**

Oui, Aspose.Slides permet la conversion par lots de plusieurs diapositives en JPG en une seule opération.

**La conversion prend‑t‑elle en charge SmartArt, les graphiques et autres objets complexes ?**

Oui, Aspose.Slides rend tout le contenu, y compris SmartArt, les graphiques, les tableaux, les formes, etc. Cependant, la précision du rendu peut varier légèrement par rapport à PowerPoint, surtout lors de l’utilisation de polices personnalisées ou manquantes.

**Y a‑t‑il des limites au nombre de diapositives pouvant être traitées ?**

Aspose.Slides ne fixe aucune limite stricte au nombre de diapositives que vous pouvez traiter. Cependant, vous pouvez rencontrer une erreur de manque de mémoire lorsque vous travaillez avec de grandes présentations ou des images à haute résolution.