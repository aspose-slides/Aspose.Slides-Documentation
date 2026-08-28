---
title: Convertir les diapositives de présentation en images en Java
linktitle: Diapositive vers image
type: docs
weight: 35
url: /fr/java/convert-slide/
keywords:
- convertir diapositive
- exporter diapositive
- diapositive en image
- enregistrer diapositive comme image
- diapositive en EMF
- diapositive en PNG
- diapositive en JPEG
- diapositive en bitmap
- diapositive en TIFF
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Convertissez les diapositives des présentations PPT, PPTX et ODP en PNG, JPEG, GIF, TIFF, EMF et autres formats d'image en Java avec Aspose.Slides."
---
## **Introduction**

Aspose.Slides for Java peut rendre les diapositives individuelles des présentations PowerPoint et OpenDocument au format PNG, JPEG, GIF, TIFF et d'autres formats d'image.

Pour convertir une diapositive en image, suivez les étapes suivantes :

1. Chargez la présentation avec la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/).
2. Sélectionnez la diapositive que vous souhaitez rendre.
3. Si nécessaire, configurez le rendu avec la classe [RenderingOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/renderingoptions/) ou [TiffOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/tiffoptions/).
4. Appelez la méthode [ISlide.getImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/islide/#getImage--) . Elle renvoie un objet [IImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iimage/).
5. Appelez la méthode [IImage.save](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iimage/#save-java.lang.String-int-) et spécifiez le format de sortie avec une valeur [ImageFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imageformat/).

## **Convertir une diapositive en image PNG**

La conversion la plus simple utilise les paramètres de rendu par défaut. L'objet [IImage] résultant peut être traité en mémoire ou enregistré dans un fichier.

L'exemple Java suivant rend la première diapositive et l'enregistre au format PNG :

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage();
    try {
        image.save("Slide_0.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Convertir des diapositives en images avec des tailles personnalisées**

Utilisez la surcharge [ISlide.getImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) qui accepte une valeur [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) pour rendre une diapositive avec des dimensions en pixels précises.

L'exemple suivant crée une image JPEG de 1820 × 1040 :

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import java.awt.Dimension;

Dimension imageSize = new Dimension(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(imageSize);
    try {
        image.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Convertir des diapositives avec notes et commentaires en images**

Par défaut, les images des diapositives n'incluent pas les notes ni les commentaires. Transmettez un objet [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/notescommentslayoutingoptions/) à la méthode [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/renderingoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) pour contrôler l'emplacement des notes et des commentaires.

L'exemple suivant place les notes tronquées sous la diapositive et les commentaires à sa droite :

```java
import com.aspose.slides.CommentsPositions;
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.NotesCommentsLayoutingOptions;
import com.aspose.slides.NotesPositions;
import com.aspose.slides.Presentation;
import com.aspose.slides.RenderingOptions;
import java.awt.Color;

float scaleX = 2f;
float scaleY = scaleX;

Color commentsAreaColor = new Color(250, 235, 215);

NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
layoutOptions.setNotesPosition(NotesPositions.BottomTruncated);
layoutOptions.setCommentsPosition(CommentsPositions.Right);
layoutOptions.setCommentsAreaWidth(500);
layoutOptions.setCommentsAreaColor(commentsAreaColor);

RenderingOptions renderingOptions = new RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutOptions);

Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(renderingOptions, scaleX, scaleY);
    try {
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}
Pour la conversion diapositive‑vers‑image, ne passez pas [BottomFull](https://reference.aspose.com/slides/fr/java/com.aspose.slides/notespositions/) à la méthode [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/fr/java/com.aspose.slides/notescommentslayoutingoptions/#setNotesPosition-int-). Les notes peuvent contenir plus de texte que la taille d'image fixe ne peut accueillir. Utilisez plutôt [BottomTruncated](https://reference.aspose.com/slides/fr/java/com.aspose.slides/notespositions/).
{{% /alert %}}

## **Convertir des diapositives en images en utilisant les options TIFF**

La classe [TiffOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/tiffoptions/) vous permet de contrôler la taille, la résolution et d'autres propriétés de l'image TIFF rendue.

L'exemple suivant rend la première diapositive en une image TIFF de 2160 × 2880 à 300 DPI :

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import com.aspose.slides.TiffOptions;
import java.awt.Dimension;

Dimension imageSize = new Dimension(2160, 2880);

TiffOptions tiffOptions = new TiffOptions();
tiffOptions.setImageSize(imageSize);
tiffOptions.setDpiX(300);
tiffOptions.setDpiY(300);

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(tiffOptions);
    try {
        image.save("output.tiff", ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}
La prise en charge du format TIFF n'est pas garantie dans les versions Java antérieures à JDK 9.
{{% /alert %}}

## **Convertir toutes les diapositives en images**

Parcourez la collection de diapositives pour convertir l'ensemble de la présentation en une série d'images. Les diapositives masquées sont incluses sauf si vous les ignorez explicitement.

L'exemple suivant rend chaque diapositive en une image JPEG avec des facteurs d'échelle horizontaux et verticaux de 2 :

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

float scaleX = 2f;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(scaleX, scaleY);
        try {
            image.save("Slide_" + index + ".jpg", ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Créer une sortie Enhanced Metafile**

Enhanced Metafile (EMF) est utile lorsque des graphiques vectoriels doivent être échangés avec Microsoft Office ou d'autres applications Windows qui prennent en charge les métadonnées Windows. Contrairement à une image basée sur des pixels, un EMF peut conserver les opérations de dessin vectoriel qui s'échelonnent sans perte de netteté. Cependant, l'EMF est principalement un format de compatibilité pour les applications disposant d'un support des métadonnées Windows, et non un format d'échange universel. De plus, le contenu complexe d'une diapositive, tel que les images bitmap et certains effets, peut être stocké sous forme d'éléments rasterisés à l'intérieur du conteneur de métadonnées vectorielles.

### **Exporter une diapositive au format EMF**

La méthode [ISlide.writeAsEmf](https://reference.aspose.com/slides/fr/java/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) écrit un [ISlide](https://reference.aspose.com/slides/fr/java/com.aspose.slides/islide/) dans un flux cible au format EMF. L'exemple suivant charge une présentation, sélectionne la première diapositive et l'écrit dans un flux de fichier EMF :

```java
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    FileOutputStream emfStream = new FileOutputStream("Slide_0.emf");
    try {
        slide.writeAsEmf(emfStream);
    } finally {
        emfStream.close();
    }
} finally {
    presentation.dispose();
}
```

L'appelant possède le flux transmis à [ISlide.writeAsEmf](https://reference.aspose.com/slides/fr/java/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) et est responsable de le fermer, comme indiqué ci‑dessus.

### **Convertir une image SVG en EMF et l'ajouter à une présentation**

Utilisez [ISvgImage.writeAsEmf](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) pour convertir du contenu SVG en EMF. Les octets résultants peuvent être ajoutés à la présentation via [IImageCollection.addImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iimagecollection/#addImage-byte:A-) et placés sur une diapositive avec [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-).

L'exemple suivant crée un [SvgImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/svgimage/) à partir de balises SVG, le convertit en EMF en mémoire, insère le métafile sur la première diapositive et enregistre la présentation :

```java
import com.aspose.slides.IPPImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ISvgImage;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import com.aspose.slides.SvgImage;
import java.io.ByteArrayOutputStream;

String svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
ISvgImage svgImage = new SvgImage(svgContent);

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ByteArrayOutputStream emfStream = new ByteArrayOutputStream();
    try {
        svgImage.writeAsEmf(emfStream);

        byte[] emfData = emfStream.toByteArray();
        IPPImage image = presentation.getImages().addImage(emfData);
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image);
    } finally {
        emfStream.close();
    }

    presentation.save("Presentation_with_emf.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[ISvgImage.writeAsEmf](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) ne prend pas la possession du flux de destination. Un [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) stocke toutes les données générées en mémoire, il n'est donc pas nécessaire de réinitialiser la position avant d'appeler `toByteArray`. Le tableau d'octets retourné reste valide après la fermeture du flux.

La génération d'EMF est disponible sur les systèmes d'exploitation pris en charge par la configuration sélectionnée d'Aspose.Slides for Java et du JDK, mais le rendu peut différer selon les plateformes lorsque les polices ou les dépendances graphiques sont indisponibles. Installez les polices utilisées par le contenu source ou configurez des substituts appropriés, suivez les [exigences de plateforme](/slides/fr/java/system-requirements/) pour Aspose.Slides for Java et validez le résultat dans l'application cible consommant les EMF. Les applications Linux et macOS offrent souvent un support limité ou incohérent pour l'affichage et la modification des métadonnées Windows.

## **Rendu des emojis couleur**

{{% alert title="Note" color="info" %}}
Pour rendre correctement les emojis couleur lors de la conversion de diapositives de présentation en images, les polices d'emoji utilisées dans la présentation doivent être installées et disponibles sur le système effectuant la conversion. Par exemple, si la présentation utilise **Segoe UI Emoji** et que cette police est absente, les emojis peuvent apparaître en monochrome dans les images résultantes.
{{% /alert %}}

## **FAQ**

**Aspose.Slides prend‑il en charge le rendu des diapositives avec des animations ?**

Non. La méthode [ISlide.getImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/islide/#getImage--) rend une image statique de la diapositive et n'exporte pas les animations.

**Les diapositives masquées peuvent‑elles être exportées en images ?**

Oui. Les diapositives masquées peuvent être rendues comme des diapositives normales. Incluez‑les dans la boucle de traitement, comme indiqué dans l'exemple ci‑dessus.

**Les ombres et d’autres effets sont‑ils conservés dans les images des diapositives ?**

Oui. Aspose.Slides rend les ombres, la transparence et les autres effets graphiques pris en charge dans les images des diapositives.