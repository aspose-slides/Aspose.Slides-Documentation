---
title: Convertir PowerPoint en JPG
type: docs
weight: 60
url: /fr/androidjava/convert-powerpoint-to-jpg/
keywords:
- Convertir présentation PowerPoint
- JPG
- JPEG
- PowerPoint en JPG
- PowerPoint en JPEG
- PPT en JPG
- PPTX en JPG
- PPT en JPEG
- PPTX en JPEG
- Android
- Aspose.Slides
description: "Convertir PowerPoint en JPG : PPT en JPG, PPTX en JPG en Java"
---


## **À propos de la conversion PowerPoint en JPG**
Avec l'[**API Aspose.Slides**](https://products.aspose.com/slides/androidjava/) vous pouvez convertir une présentation PowerPoint PPT ou PPTX en image JPG. Il est également possible de convertir PPT/PPTX en JPEG, PNG ou SVG. Avec ces fonctionnalités, il est facile de mettre en œuvre votre propre visualiseur de présentation, de créer la miniature pour chaque diapositive. Cela peut être utile si vous souhaitez protéger les diapositives de présentation contre le droit d'auteur, démontrer la présentation en mode lecture seule. Aspose.Slides permet de convertir l'ensemble de la présentation ou une certaine diapositive en formats d'image. 

{{% alert color="primary" %}} 

Pour voir comment Aspose.Slides convertit PowerPoint en images JPG, vous voudrez peut-être essayer ces convertisseurs en ligne gratuits : PowerPoint [PPTX en JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) et [PPT en JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 

{{% /alert %}} 

![todo:image_alt_text](ppt-to-jpg.png)

## **Convertir PowerPoint PPT/PPTX en JPG**
Voici les étapes pour convertir PPT/PPTX en JPG :

1. Créez une instance de type [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtenez l'objet diapositive de type [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide) de la collection [Presentation.getSlides()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--).
3. Créez la miniature de chaque diapositive puis convertissez-la en JPG. La méthode [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getImage-float-float-) est utilisée pour obtenir une miniature d'une diapositive, elle retourne un objet [Images](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Images) en résultat. La méthode [getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) doit être appelée depuis la diapositive nécessaire de type [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide), les échelles de la miniature résultante sont passées dans la méthode.
4. Après avoir obtenu la miniature de la diapositive, appelez la méthode [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImage#save(String formatName, int imageFormat)) de l'objet miniature. Passez le nom de fichier résultant et le format d'image dans cette méthode. 

{{% alert color="primary" %}}

**Remarque** : La conversion PPT/PPTX en JPG diffère de la conversion vers d'autres types dans l'API Aspose.Slides. Pour d'autres types, vous utilisez généralement la méthode [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-), mais ici vous devez utiliser la méthode [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImage#save(String formatName, int imageFormat)). 

{{% /alert %}} 

```java
Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    for (ISlide sld : pres.getSlides()) {
        // Crée une image à pleine échelle
        IImage slideImage = sld.getImage(1f, 1f);

        // Sauvegarde l'image sur le disque au format JPEG
        try {
              slideImage.save(String.format("Diapositive_%d.jpg", sld.getSlideNumber()), ImageFormat.Jpeg);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Convertir PowerPoint PPT/PPTX en JPG avec des dimensions personnalisées**
Pour changer la dimension de la miniature résultante et de l'image JPG, vous pouvez définir les valeurs *ScaleX* et *ScaleY* en les passant dans les méthodes [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getImage-float-float-) :

```java
Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    // Définit les dimensions
    int desiredX = 1200;
    int desiredY = 800;
    // Obtient les valeurs échelonnées de X et Y
    float ScaleX = (float) (1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float) (1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;

    for (ISlide sld : pres.getSlides())
    {
        // Crée une image à pleine échelle
        IImage slideImage = sld.getImage(ScaleX, ScaleY);

        // Sauvegarde l'image sur le disque au format JPEG
        try {
              slideImage.save(String.format("Diapositive_%d.jpg", sld.getSlideNumber()), ImageFormat.Jpeg);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Rendre les commentaires lors de la sauvegarde de la présentation en image**
Aspose.Slides pour Android via Java fournit une fonctionnalité qui vous permet de rendre les commentaires dans les diapositives d'une présentation lorsque vous convertissez ces diapositives en images. Ce code Java démontre l'opération :

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomTruncated);

    IRenderingOptions opts = new RenderingOptions();
    opts.setSlidesLayoutOptions(notesOptions);

    for (ISlide sld : pres.getSlides()) {
        IImage slideImage = sld.getImage(opts, new Dimension(740, 960));
        try {
             slideImage.save(String.format("Diapositive_%d.png", sld.getSlideNumber()));
        } finally {
                     if (slideImage != null) slideImage.dispose();
                }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Conseil" color="primary" %}}

Aspose propose une [application web Collage GRATUITE](https://products.aspose.app/slides/collage). En utilisant ce service en ligne, vous pouvez fusionner [JPG en JPG](https://products.aspose.app/slides/collage/jpg) ou des images PNG en PNG, créer des [grilles photo](https://products.aspose.app/slides/collage/photo-grid), et ainsi de suite. 

En utilisant les mêmes principes décrits dans cet article, vous pouvez convertir des images d'un format à un autre. Pour plus d'informations, consultez ces pages : convertir [image en JPG](https://products.aspose.com/slides/androidjava/conversion/image-to-jpg/) ; convertir [JPG en image](https://products.aspose.com/slides/androidjava/conversion/jpg-to-image/) ; convertir [JPG en PNG](https://products.aspose.com/slides/androidjava/conversion/jpg-to-png/), convertir [PNG en JPG](https://products.aspose.com/slides/androidjava/conversion/png-to-jpg/) ; convertir [PNG en SVG](https://products.aspose.com/slides/androidjava/conversion/png-to-svg/), convertir [SVG en PNG](https://products.aspose.com/slides/androidjava/conversion/svg-to-png/).

{{% /alert %}}

## **Voir aussi**

Voir d'autres options pour convertir PPT/PPTX en image comme :

- [Conversion PPT/PPTX en SVG](/slides/fr/androidjava/render-a-slide-as-an-svg-image/).