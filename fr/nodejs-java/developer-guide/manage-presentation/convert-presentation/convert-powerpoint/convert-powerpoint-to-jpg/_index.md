---
title: Convertir Powerpoint en JPG
type: docs
weight: 60
url: /fr/nodejs-java/convert-powerpoint-to-jpg/
keywords: "Convertir PowerPoint en JPG, PPTX en JPEG, PPT en JPEG"
description: "Convertir PowerPoint en JPG : PPT en JPG, PPTX en JPG en JavaScript"
---

## **À propos de la conversion PowerPoint en JPG**
Avec [**Aspose.Slides API**](https://products.aspose.com/slides/nodejs-java/) vous pouvez convertir une présentation PowerPoint PPT ou PPTX en image JPG. Il est également possible de convertir PPT/PPTX en JPEG, PNG ou SVG. Avec ces fonctionnalités il est facile de mettre en œuvre votre propre visualiseur de présentation, de créer la miniature de chaque diapositive. Cela peut être utile si vous souhaitez protéger les diapositives de la présentation contre la copie, ou présenter la présentation en mode lecture seule. Aspose.Slides permet de convertir l’ensemble de la présentation ou une diapositive spécifique en formats image.

{{% alert color="primary" %}} 
Pour voir comment Aspose.Slides convertit PowerPoint en images JPG, vous pouvez essayer ces convertisseurs en ligne gratuits : PowerPoint [PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) et [PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 
{{% /alert %}} 

![todo:image_alt_text](ppt-to-jpg.png)

## **Convertir PowerPoint PPT/PPTX en JPG**
Voici les étapes pour convertir PPT/PPTX en JPG :

1. Créer une instance du type [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Obtenir l’objet slide du type [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) à partir de la collection [Presentation.getSlides()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--).
3. Créer la miniature de chaque diapositive puis la convertir en JPG. La méthode [**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getImage-float-float-) est utilisée pour obtenir une miniature d’une diapositive, elle renvoie un objet [Imagess](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Images) en résultat. La méthode [getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getImage-aspose.slides.IRenderingOptions-float-float-) doit être appelée depuis la diapositive souhaitée du type [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide), les valeurs d’échelle de la miniature résultante sont passées à la méthode.
4. Après avoir obtenu la miniature de la diapositive, appelez la méthode [**Image.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Image#save(String formatName, int imageFormat)) à partir de l’objet miniature. Transmettez le nom de fichier résultant et le format d’image.

{{% alert color="primary" %}}

**Note** : la conversion PPT/PPTX en JPG diffère de la conversion vers d’autres types dans l’API Aspose.Slides. Pour d’autres types, vous utilisez généralement la méthode [**Presentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-), mais ici vous devez utiliser la méthode [**Image.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Image#save(String formatName, int imageFormat)). 

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
Pour modifier la dimension de la miniature et de l’image JPG résultantes, vous pouvez définir les valeurs *ScaleX* et *ScaleY* en les transmettant aux méthodes [**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getImage-float-float-).

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
Aspose.Slides for Node.js via Java offre une fonctionnalité qui vous permet de rendre les commentaires dans les diapositives d’une présentation lors de la conversion de ces diapositives en images. Ce code JavaScript montre le fonctionnement :

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

Aspose propose une [application Web COLLAGE GRATUITE](https://products.aspose.app/slides/collage). En utilisant ce service en ligne, vous pouvez fusionner des images [JPG en JPG](https://products.aspose.app/slides/collage/jpg) ou PNG en PNG, créer des [grilles de photos](https://products.aspose.app/slides/collage/photo-grid), etc.

En appliquant les mêmes principes décrits dans cet article, vous pouvez convertir des images d’un format à un autre. Pour plus d’informations, consultez ces pages : convertir [image en JPG](https://products.aspose.com/slides/nodejs-java/conversion/image-to-jpg/); convertir [JPG en image](https://products.aspose.com/slides/nodejs-java/conversion/jpg-to-image/); convertir [JPG en PNG](https://products.aspose.com/slides/nodejs-java/conversion/jpg-to-png/), convertir [PNG en JPG](https://products.aspose.com/slides/nodejs-java/conversion/png-to-jpg/); convertir [PNG en SVG](https://products.aspose.com/slides/nodejs-java/conversion/png-to-svg/), convertir [SVG en PNG](https://products.aspose.com/slides/nodejs-java/conversion/svg-to-png/).

{{% /alert %}}

## **Voir aussi**

Voir d’autres options pour convertir PPT/PPTX en image, comme :

- [Conversion PPT/PPTX en SVG](/slides/fr/nodejs-java/render-a-slide-as-an-svg-image/).

## **FAQ**

**Cette méthode prend‑elle en charge la conversion par lots ?**

Oui, Aspose.Slides permet la conversion par lots de plusieurs diapositives en JPG en une seule opération.

**La conversion prend‑elle en charge SmartArt, les graphiques et d’autres objets complexes ?**

Oui, Aspose.Slides rend tout le contenu, y compris SmartArt, les graphiques, les tableaux, les formes, etc. Cependant, la précision du rendu peut varier légèrement par rapport à PowerPoint, surtout lorsqu’on utilise des polices personnalisées ou manquantes.

**Existe‑t‑il des limites au nombre de diapositives pouvant être traitées ?**

Aspose.Slides n’impose aucune limite stricte au nombre de diapositives que vous pouvez traiter. Cependant, vous pouvez rencontrer une erreur de manque de mémoire lors du traitement de présentations volumineuses ou d’images haute résolution.