---
title: Visionneuse de Présentation
type: docs
weight: 50
url: /java/presentation-viewer/
keywords: "Visionneuse PPT PowerPoint"
description: "Visionneuse PPT PowerPoint en Java"
---

{{% alert color="primary" %}} 

Aspose.Slides pour Java est utilisé pour créer des fichiers de présentation, complets avec des diapositives. Ces diapositives peuvent être visualisées en ouvrant des présentations avec Microsoft PowerPoint. Mais parfois, les développeurs peuvent également avoir besoin de visualiser des diapositives en tant qu'images dans leur visionneuse d'images préférée ou de créer leur propre visionneuse de présentations. Dans de tels cas, Aspose.Slides pour Java vous permet d'exporter une diapositive individuelle en tant qu'image. Cet article décrit comment le faire.

{{% /alert %}} 

## **Exemple en Direct**
Vous pouvez essayer l'application gratuite [**Visionneuse Aspose.Slides**](https://products.aspose.app/slides/viewer/) pour voir ce que vous pouvez mettre en œuvre avec l'API Aspose.Slides :

[](https://products.aspose.app/slides/viewer/)

[![todo:image_alt_text](slides-viewer.png)](https://products.aspose.app/slides/viewer/)

## **Générer une Image SVG à partir d'une Diapositive**
Pour générer une image SVG à partir de n'importe quelle diapositive désirée avec Aspose.Slides pour Java, veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Obtenez la référence de la diapositive désirée en utilisant son ID ou son index.
- Obtenez l'image SVG dans un flux mémoire.
- Enregistrez le flux mémoire dans un fichier.

```java
// Instancier une classe Presentation qui représente le fichier de présentation
Presentation pres = new Presentation("CreateSlidesSVGImage.pptx");
try {
    // Accéder à la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Créer un objet de flux mémoire
    FileOutputStream svgStream = new FileOutputStream("Aspose_out.svg");

    // Générer l'image SVG de la diapositive et l'enregistrer dans le flux mémoire
    sld.writeAsSvg(svgStream);

    svgStream.close();
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

## **Générer un SVG avec des Identifiants de Forme Personnalisés**
Aspose.Slides pour Java peut être utilisé pour générer [SVG](https://docs.fileformat.com/page-description-language/svg/) à partir d'une diapositive avec des identifiants de forme personnalisés. Pour cela, utilisez la propriété ID de [ISvgShape](https://reference.aspose.com/slides/java/com.aspose.slides/ISvgShape), qui représente l'ID personnalisé des formes dans l'SVG généré. CustomSvgShapeFormattingController peut être utilisé pour définir l'ID de la forme.

```java
Presentation pres = new Presentation("pptxFileName.pptx");
try {
    FileOutputStream stream = new FileOutputStream("Aspose_out.svg");
    try {
        SVGOptions svgOptions = new SVGOptions();
        svgOptions.setShapeFormattingController(new CustomSvgShapeFormattingController());

        pres.getSlides().get_Item(0).writeAsSvg(stream, svgOptions);
    } finally {
        if (stream != null) stream.close();
    }
} catch (IOException e) {
} finally {
    pres.dispose();
}
```
```java
class CustomSvgShapeFormattingController implements ISvgShapeFormattingController
{
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController()
    {
        m_shapeIndex = 0;
    }
    
    public CustomSvgShapeFormattingController(int shapeStartIndex)
    {
        m_shapeIndex = shapeStartIndex;
    }

    public void formatShape(ISvgShape svgShape, IShape shape)
    {
        svgShape.setId(String.format("shape-%d", m_shapeIndex++));
    }
}
```

## **Créer une Image Vignette de Diapositive**
Aspose.Slides pour Java vous aide à générer des images vignettes des diapositives. Pour générer la vignette de n'importe quelle diapositive désirée en utilisant Aspose.Slides pour Java :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Obtenez la référence de n'importe quelle diapositive désirée en utilisant son ID ou son index.
1. Obtenez l'image vignette de la diapositive référencée à une échelle spécifiée.
1. Enregistrez l'image vignette dans n'importe quel format d'image désiré.

```java
// Instancier une classe Presentation qui représente le fichier de présentation
Presentation pres = new Presentation("ThumbnailFromSlide.pptx");
try {
    // Accéder à la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Créer une image à pleine échelle
    IImage slideImage = sld.getImage(1f, 1f);

    // Enregistrer l'image sur le disque au format JPEG
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    pres.dispose();
}
```

## **Créer une Vignette avec des Dimensions Définies par l'Utilisateur**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Obtenez la référence de n'importe quelle diapositive désirée en utilisant son ID ou son index.
1. Obtenez l'image vignette de la diapositive référencée à une échelle spécifiée.
1. Enregistrez l'image vignette dans n'importe quel format d'image désiré.

```java
// Instancier une classe Presentation qui représente le fichier de présentation
Presentation pres = new Presentation("ThumbnailWithUserDefinedDimensions.pptx");
try {
    // Accéder à la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Dimension définie par l'utilisateur
    int desiredX = 1200;
    int desiredY = 800;

    // Obtenir la valeur mise à l'échelle de X et Y
    float ScaleX = (float)(1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float)(1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;
    
    // Créer une image à pleine échelle
    IImage slideImage = sld.getImage(ScaleX, ScaleY);

    // Enregistrer l'image sur le disque au format JPEG
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    pres.dispose();
}
```

## **Créer une Vignette à partir d'une Diapositive dans la Vue des Notes**
Pour générer la vignette de n'importe quelle diapositive désirée dans la vue des notes à l'aide d'Aspose.Slides pour Java :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Obtenez la référence de n'importe quelle diapositive désirée en utilisant son ID ou son index.
1. Obtenez l'image vignette de la diapositive référencée à une échelle spécifiée dans la vue des notes.
1. Enregistrez l'image vignette dans n'importe quel format d'image désiré.

Le code ci-dessous produit une vignette de la première diapositive d'une présentation dans la vue des notes.

```java
// Instancier une classe Presentation qui représente le fichier de présentation
Presentation pres = new Presentation("ThumbnailWithUserDefinedDimensions.pptx");
try {
    // Accéder à la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Dimension définie par l'utilisateur
    int desiredX = 1200;
    int desiredY = 800;

    // Obtenir la valeur mise à l'échelle de X et Y
    float ScaleX = (float)(1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float)(1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;

    RenderingOptions opts = new RenderingOptions();
    opts.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomTruncated);
    
    // Créer une image à pleine échelle
    IImage slideImage = sld.getImage(opts, ScaleX, ScaleY);

    // Enregistrer l'image sur le disque au format JPEG
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    pres.dispose();
}
```