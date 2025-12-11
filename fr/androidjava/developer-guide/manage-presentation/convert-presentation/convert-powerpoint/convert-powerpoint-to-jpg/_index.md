---
title: Convertir PPT et PPTX en JPG sur Android
linktitle: PowerPoint en JPG
type: docs
weight: 60
url: /fr/androidjava/convert-powerpoint-to-jpg/
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
- Android
- Java
- Aspose.Slides
description: "Convertir les diapositives PowerPoint (PPT, PPTX) en images JPG de haute qualité en Java avec Aspose.Slides pour Android en utilisant des exemples de code rapides et fiables."
---

## **Aperçu**

Convertir des présentations PowerPoint et OpenDocument en images JPG facilite le partage des diapositives, l'optimisation des performances et l'intégration de contenu dans des sites Web ou des applications. Aspose.Slides for Android via Java vous permet de transformer les fichiers PPTX, PPT et ODP en images JPEG de haute qualité. Ce guide explique les différentes méthodes de conversion.

Avec ces fonctionnalités, il est facile de mettre en œuvre votre propre visionneur de présentations et de créer une miniature pour chaque diapositive. Cela peut être utile si vous souhaitez protéger les diapositives contre la copie ou présenter la présentation en mode lecture seule. Aspose.Slides vous permet de convertir la présentation entière ou une diapositive spécifique en formats d'image.

## **Convertir les diapositives de présentation en images JPG**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Récupérez l'objet diapositive de type [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) à partir de la collection renvoyée par la méthode [Presentation.getSlides()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--).
1. Créez une image de la diapositive en utilisant la méthode [ISlide.getImage(float, float)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-float-float-).
1. Appelez la méthode [IImage.save(string, ImageFormat)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) sur l'objet image. Passez le nom du fichier de sortie et le format d'image en tant qu'arguments.

{{% alert color="primary" %}} 
**Note:** La conversion PPT, PPTX ou ODP en JPG diffère de la conversion vers d'autres formats dans l'API Aspose.Slides Android via Java. Pour d'autres formats, vous utilisez généralement la méthode [IPresentation.save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-). Cependant, pour la conversion JPG, vous devez utiliser la méthode [IImage.save(string, ImageFormat)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-).
{{% /alert %}} 
```java
int scaleX = 1;
int scaleY = scaleX;

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Créez une image de diapositive à l'échelle spécifiée.
        IImage slideImage = slide.getImage(scaleX, scaleY);

        try {
            // Enregistrez l'image sur le disque au format JPEG.
            String fileName = String.format("Slide_%d.jpg", slide.getSlideNumber());
            slideImage.save(fileName, ImageFormat.Jpeg);
        } finally {
            slideImage.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```


## **Convertir les diapositives en JPG avec des dimensions personnalisées**

Pour modifier les dimensions des images JPG résultantes, vous pouvez définir la taille de l'image en la transmettant à la méthode [ISlide.getImage(Size)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-). Cela vous permet de générer des images avec des valeurs de largeur et de hauteur spécifiques, garantissant que la sortie répond à vos exigences en matière de résolution et de ratio d'aspect. Cette flexibilité est particulièrement utile lors de la génération d'images pour des applications Web, des rapports ou de la documentation, où des dimensions d'image précises sont requises.
```java
Size imageSize = new Size(1200, 800);

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Créez une image de diapositive de la taille spécifiée.
        IImage slideImage = slide.getImage(imageSize);

        try {
            // Enregistrez l'image sur le disque au format JPEG.
            String fileName = String.format("Slide_%d.jpg", slide.getSlideNumber());
            slideImage.save(fileName, ImageFormat.Jpeg);
        } finally {
            slideImage.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```


## **Rendre les commentaires lors de l'enregistrement des diapositives en images**

Aspose.Slides for Android via Java propose une fonctionnalité qui vous permet de rendre les commentaires sur les diapositives d'une présentation lors de leur conversion en images JPG. Cette fonctionnalité est particulièrement utile pour conserver les annotations, les retours ou les discussions ajoutés par les collaborateurs dans les présentations PowerPoint. En activant cette option, vous vous assurez que les commentaires sont visibles dans les images générées, facilitant ainsi la révision et le partage des retours sans avoir besoin d'ouvrir le fichier de présentation original.

Supposons que nous ayons un fichier de présentation, "sample.pptx", contenant une diapositive avec des commentaires :
![La diapositive avec commentaires](slide_with_comments.png)

Le code Java suivant convertit la diapositive en image JPG tout en conservant les commentaires :
```java
int scaleX = 2;
int scaleY = scaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    NotesCommentsLayoutingOptions commentsOptions = new NotesCommentsLayoutingOptions();
    commentsOptions.setCommentsPosition(CommentsPositions.Right);
    commentsOptions.setCommentsAreaWidth(200);
    commentsOptions.setCommentsAreaColor(Color.rgb(255, 140, 0));

    IRenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(commentsOptions);

    // Convertir la première diapositive en image.
    IImage slideImage = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);
    try {
        slideImage.save("Slide_1.jpg", ImageFormat.Jpeg);
    } finally {
        slideImage.dispose();
    }
} finally {
    presentation.dispose();
}
```


Le résultat :
![L'image JPG avec commentaires](image_with_comments.png)

## **Voir aussi**

Voir d'autres options pour convertir PPT, PPTX ou ODP en images, telles que :
- [Convertir PowerPoint en GIF](/slides/fr/androidjava/convert-powerpoint-to-animated-gif/)
- [Convertir PowerPoint en PNG](/slides/fr/androidjava/convert-powerpoint-to-png/)
- [Convertir PowerPoint en TIFF](/slides/fr/androidjava/convert-powerpoint-to-tiff/)
- [Convertir PowerPoint en SVG](/slides/fr/androidjava/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 
Pour voir comment Aspose.Slides convertit les présentations PowerPoint en images JPG, essayez ces convertisseurs en ligne gratuits : PowerPoint [PPTX en JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) et [PPT en JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 
{{% /alert %}} 

![Convertisseur PPTX en JPG en ligne gratuit](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose propose une [application Web GRATUITE de collage](https://products.aspose.app/slides/collage). En utilisant ce service en ligne, vous pouvez fusionner des images [JPG en JPG](https://products.aspose.app/slides/collage/jpg) ou PNG en PNG, créer des [grilles de photos](https://products.aspose.app/slides/collage/photo-grid), etc. 

En appliquant les mêmes principes décrits dans cet article, vous pouvez convertir des images d'un format à un autre. Pour plus d'informations, consultez ces pages : convertir [image en JPG](https://products.aspose.com/slides/java/conversion/image-to-jpg/); convertir [JPG en image](https://products.aspose.com/slides/java/conversion/jpg-to-image/); convertir [JPG en PNG](https://products.aspose.com/slides/java/conversion/jpg-to-png/); convertir [PNG en JPG](https://products.aspose.com/slides/java/conversion/png-to-jpg/); convertir [PNG en SVG](https://products.aspose.com/slides/java/conversion/png-to-svg/); convertir [SVG en PNG](https://products.aspose.com/slides/java/conversion/svg-to-png/).

{{% /alert %}}

## **FAQ**

**Cette méthode prend-elle en charge la conversion par lots ?**  
Oui, Aspose.Slides permet la conversion par lots de plusieurs diapositives en JPG en une seule opération.

**La conversion prend-elle en charge SmartArt, les graphiques et d'autres objets complexes ?**  
Oui, Aspose.Slides rend tout le contenu, y compris SmartArt, les graphiques, les tableaux, les formes, etc. Cependant, la précision du rendu peut varier légèrement par rapport à PowerPoint, notamment lorsqu'on utilise des polices personnalisées ou manquantes.

**Existe-t-il des limites au nombre de diapositives pouvant être traitées ?**  
Aspose.Slides n'impose aucune limite stricte quant au nombre de diapositives que vous pouvez traiter. Cependant, vous pouvez rencontrer des erreurs de manque de mémoire lorsque vous travaillez avec de grandes présentations ou des images haute résolution.