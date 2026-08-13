---
title: Convertir PPT et PPTX en JPG en Java
linktitle: PowerPoint en JPG
type: docs
weight: 60
url: /fr/java/convert-powerpoint-to-jpg/
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
- Java
- Aspose.Slides
description: "Convertir les diapositives PowerPoint (PPT, PPTX) en images JPG de haute qualité en Java avec Aspose.Slides for Java en utilisant des exemples de code rapides et fiables."
---
## **Introduction**

Convertir les présentations PowerPoint et OpenDocument en images JPG facilite le partage des diapositives, optimise les performances et permet d’intégrer le contenu dans des sites Web ou des applications. Aspose.Slides vous permet de transformer les fichiers PPTX, PPT et ODP en images JPEG de haute qualité. Ce guide explique les différentes méthodes de conversion.

Avec ces fonctionnalités, il est facile de mettre en œuvre votre propre visionneur de présentations et de créer une miniature pour chaque diapositive. Cela peut être utile si vous souhaitez protéger les diapositives contre la copie ou présenter la présentation en mode lecture seule. Aspose.Slides vous permet de convertir l’ensemble de la présentation ou une diapositive spécifique en formats d’image.

## **Convert PowerPoint PPT/PPTX to JPG**

Voici les étapes pour convertir PPT/PPTX en JPG :

1. Créez une instance du type [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation).
2. Récupérez l’objet diapositive du type [ISlide](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISlide) à partir de la collection [Presentation.getSlides()](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation#getSlides--).
3. Créez la miniature de chaque diapositive, puis convertissez‑la en JPG. La méthode [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISlide#getImage-float-float-) est utilisée pour obtenir une miniature d’une diapositive ; elle renvoie un objet [Images](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Images). La méthode [getImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) doit être appelée sur la diapositive requise du type [ISlide](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISlide), les échelles de la miniature résultante étant passées à la méthode.
4. Après avoir obtenu la miniature de la diapositive, appelez la méthode [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) depuis l’objet miniature. Transmettez le nom de fichier résultant et le format d’image.

{{% alert color="info" %}}

**Note** : La conversion PPT/PPTX en JPG diffère de la conversion vers d’autres types dans l’API Aspose.Slides. Pour d’autres types, vous utilisez généralement la méthode [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-), mais ici vous devez utiliser la méthode [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)).

{{% /alert %}} 

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    for (ISlide sld : pres.getSlides()) {
        // Crée une image à pleine échelle
        IImage slideImage = sld.getImage(1f, 1f);

        // Enregistre l'image sur le disque au format JPEG
        try {
              slideImage.save(String.format("Slide_%d.jpg", sld.getSlideNumber()), ImageFormat.Jpeg);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Convert PowerPoint PPT/PPTX to JPG with Customized Dimensions**

Pour modifier les dimensions de la miniature et de l’image JPG résultantes, vous pouvez définir les valeurs *ScaleX* et *ScaleY* en les passant aux méthodes [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISlide#getImage-float-float-):

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    // Définit les dimensions
    int desiredX = 1200;
    int desiredY = 800;
    // Obtient les valeurs mises à l'échelle de X et Y
    float ScaleX = (float) (1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float) (1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;

    for (ISlide sld : pres.getSlides())
    {
        // Crée une image à pleine échelle
        IImage slideImage = sld.getImage(ScaleX, ScaleY);

        // Enregistre l'image sur le disque au format JPEG
        try {
              slideImage.save(String.format("Slide_%d.jpg", sld.getSlideNumber()), ImageFormat.Jpeg);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Render Comments When Saving Slides as Images**

Aspose.Slides for Java offre une fonctionnalité qui vous permet de rendre les commentaires dans les diapositives d’une présentation lors de leur conversion en images. Ce code Java montre l’opération :

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation pres = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomTruncated);
    notesOptions.setCommentsPosition(CommentsPositions.Right);
    notesOptions.setCommentsAreaWidth(200);

    IRenderingOptions opts = new RenderingOptions();
    opts.setSlidesLayoutOptions(notesOptions);

    for (ISlide sld : pres.getSlides()) {
        IImage slideImage = sld.getImage(opts, new Dimension(740, 960));
        try {
             slideImage.save(String.format("Slide_%d.png", sld.getSlideNumber()));
        } finally {
                     if (slideImage != null) slideImage.dispose();
                }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Tip" color="info" %}}

Aspose propose une application Web Collage GRATUITE. Avec ce service en ligne, vous pouvez fusionner des images [JPG to JPG](https://products.aspose.app/slides/fr/collage/jpg) ou PNG to PNG, créer des [photo grids](https://products.aspose.app/slides/fr/collage/photo-grid), etc. 

En utilisant les mêmes principes décrits dans cet article, vous pouvez convertir des images d’un format à un autre. Pour plus d’informations, consultez ces pages : convertir [image to JPG](https://products.aspose.com/slides/fr/java/conversion/image-to-jpg/); convertir [JPG to image](https://products.aspose.com/slides/fr/java/conversion/jpg-to-image/); convertir [JPG to PNG](https://products.aspose.com/slides/fr/java/conversion/jpg-to-png/); convertir [PNG to JPG](https://products.aspose.com/slides/fr/java/conversion/png-to-jpg/); convertir [PNG to SVG](https://products.aspose.com/slides/fr/java/conversion/png-to-svg/); convertir [SVG to PNG](https://products.aspose.com/slides/fr/java/conversion/svg-to-png/).

{{% /alert %}}

## **FAQ**

### Cette méthode prend‑elle en charge la conversion par lots ?

Oui, Aspose.Slides permet la conversion par lots de plusieurs diapositives en JPG en une seule opération.

### La conversion prend‑elle en charge SmartArt, les graphiques et d’autres objets complexes ?

Oui, Aspose.Slides rend tout le contenu, y compris SmartArt, les graphiques, les tableaux, les formes, etc. Cependant, la précision du rendu peut varier légèrement par rapport à PowerPoint, surtout lorsqu’on utilise des polices personnalisées ou manquantes.

### Existe‑t‑il des limitations concernant le nombre de diapositives pouvant être traitées ?

Aspose.Slides n’impose aucune limitation stricte au nombre de diapositives que vous pouvez traiter. Cependant, vous pouvez rencontrer une erreur de mémoire insuffisante lors du traitement de présentations volumineuses ou d’images haute résolution.

## **Voir aussi**

Voir d’autres options pour convertir PPT/PPTX en image, telles que :

- [Conversion PPT/PPTX en SVG](/slides/fr/java/render-a-slide-as-an-svg-image/).