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

## **Vous cherchez un convertisseur PPT en ligne vers JPG ?**

Avant de plonger dans le code Java, si vous avez besoin d’un **outil en ligne rapide** pour convertir PowerPoint (PPT, PPTX) en JPG **sans coder**, consultez notre convertisseur en ligne :  
[Aspose PPT to JPG Converter](https://products.aspose.app/slides/conversion/ppt-to-jpg)

Si vous êtes un **développeur à la recherche d’une solution programmatique**, continuez la lecture pour apprendre comment convertir les diapositives PowerPoint en JPG en utilisant **Aspose.Slides for Java**.

## **À propos de la conversion PowerPoint en JPG**

Grâce à l[**Aspose.Slides API**](https://products.aspose.com/slides/java/) vous pouvez convertir une présentation PowerPoint PPT ou PPTX en image JPG. Il est également possible de convertir PPT/PPTX en JPEG, PNG ou SVG. Avec ces fonctionnalités, il est facile de mettre en œuvre votre propre visionneuse de présentations, de créer la vignette de chaque diapositive. Cela peut être utile si vous souhaitez protéger les diapositives contre la copie, ou présenter la présentation en mode lecture seule. Aspose.Slides permet de convertir l’ensemble de la présentation ou une diapositive spécifique en formats d’image.  

{{% alert color="primary" %}} 

Pour voir comment Aspose.Slides convertit PowerPoint en images JPG, vous pouvez essayer ces convertisseurs en ligne gratuits : PowerPoint [PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) et [PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 

{{% /alert %}} 

![todo:image_alt_text](ppt-to-jpg.png)

## **Convertir PowerPoint PPT/PPTX en JPG**

Voici les étapes pour convertir PPT/PPTX en JPG :

1. Créer une instance du type [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtenir l’objet diapositive du type [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide) à partir de la collection [Presentation.getSlides()](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) .
3. Créer la vignette de chaque diapositive puis la convertir en JPG. La méthode [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-float-float-) est utilisée pour obtenir une vignette d’une diapositive, elle renvoie un objet [Images](https://reference.aspose.com/slides/java/com.aspose.slides/Images). La méthode [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) doit être appelée depuis la diapositive souhaitée du type [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide), les échelles de la vignette résultante sont passées à la méthode.
4. Après avoir obtenu la vignette de la diapositive, appelez la méthode [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) à partir de l’objet vignette. Passez le nom de fichier résultant et le format d’image.  

{{% alert color="primary" %}}

**Remarque** : la conversion PPT/PPTX en JPG diffère de la conversion vers d’autres types dans l’API Aspose.Slides. Pour d’autres types, vous utilisez généralement la méthode [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-), mais ici vous devez utiliser la méthode [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)).  

{{% /alert %}} 
```java
Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    for (ISlide sld : pres.getSlides()) {
        // Crée une image à l'échelle complète
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


## **Convertir PowerPoint PPT/PPTX en JPG avec des dimensions personnalisées**

Pour modifier la dimension de la vignette et de l’image JPG résultantes, vous pouvez définir les valeurs *ScaleX* et *ScaleY* en les transmettant aux méthodes [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-float-float-) :  
```java
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
        // Crée une image à l'échelle complète
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


## **Rendre les commentaires lors de l’enregistrement des diapositives en images**

Aspose.Slides for Java fournit une fonctionnalité qui vous permet de rendre les commentaires des diapositives d’une présentation lorsque vous convertissez ces diapositives en images. Ce code Java illustre l’opération :  
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
             slideImage.save(String.format("Slide_%d.png", sld.getSlideNumber()));
        } finally {
                     if (slideImage != null) slideImage.dispose();
                }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert title="Tip" color="primary" %}}

Aspose propose une [application web GRATUITE de collage](https://products.aspose.app/slides/collage). En utilisant ce service en ligne, vous pouvez fusionner des images [JPG to JPG](https://products.aspose.app/slides/collage/jpg) ou PNG to PNG, créer des [photo grids](https://products.aspose.app/slides/collage/photo-grid), et ainsi de suite. 

En appliquant les mêmes principes décrits dans cet article, vous pouvez convertir des images d’un format à un autre. Pour plus d’informations, consultez ces pages : convertir [image to JPG](https://products.aspose.com/slides/java/conversion/image-to-jpg/); convertir [JPG to image](https://products.aspose.com/slides/java/conversion/jpg-to-image/); convertir [JPG to PNG](https://products.aspose.com/slides/java/conversion/jpg-to-png/), convertir [PNG to JPG](https://products.aspose.com/slides/java/conversion/png-to-jpg/); convertir [PNG to SVG](https://products.aspose.com/slides/java/conversion/png-to-svg/), convertir [SVG to PNG](https://products.aspose.com/slides/java/conversion/svg-to-png/).  

{{% /alert %}}

## **FAQ**

**Cette méthode prend-elle en charge la conversion par lots ?**  

Oui, Aspose.Slides permet la conversion par lots de plusieurs diapositives en JPG en une seule opération.

**La conversion prend-elle en charge SmartArt, les graphiques et d’autres objets complexes ?**  

Oui, Aspose.Slides rend tout le contenu, y compris SmartArt, graphiques, tableaux, formes, et plus encore. Cependant, la précision du rendu peut légèrement différer de PowerPoint, surtout avec des polices personnalisées ou manquantes.

**Existe-t-il des limites au nombre de diapositives pouvant être traitées ?**  

Aspose.Slides n’impose pas de limites strictes au nombre de diapositives que vous pouvez traiter. Cependant, vous pouvez rencontrer une erreur de mémoire insuffisante lorsque vous travaillez avec de grandes présentations ou des images haute résolution.

## **Voir aussi**

Voir d’autres options pour convertir PPT/PPTX en image comme :

- [Conversion PPT/PPTX en SVG](/slides/fr/java/render-a-slide-as-an-svg-image/).