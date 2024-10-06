---
title: Convertir PowerPoint en TIFF
type: docs
weight: 90
url: /java/convert-powerpoint-to-tiff/
keywords: "Convertir présentation PowerPoint, PowerPoint en TIFF, PPT en TIFF, PPTX en TIFF, Java, Aspose.Slides"
description: "Convertir une présentation PowerPoint en TIFF en Java"

---

**TIFF** (Tagged Image File Format) est un format d'image raster sans perte et de haute qualité. Les professionnels utilisent TIFF pour leur design, photographie et publication assistée par ordinateur. Par exemple, si vous souhaitez préserver les couches et les paramètres de votre design ou image, vous voudrez peut-être enregistrer votre travail en tant que fichier image TIFF.

Aspose.Slides vous permet de convertir les diapositives de PowerPoint directement en TIFF.

{{% alert title="Astuces" color="primary" %}}

Vous voudrez peut-être consulter le [convertisseur gratuit PowerPoint en poster](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) d'Aspose.

{{% /alert %}}

## **Convertir PowerPoint en TIFF**

En utilisant la méthode [Save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) exposée par la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/), vous pouvez rapidement convertir l'ensemble d'une présentation PowerPoint en TIFF. Les images TIFF résultantes correspondent à la taille par défaut des diapositives.

Ce code Java vous montre comment convertir PowerPoint en TIFF :

```java
// Instancie un objet Presentation qui représente un fichier de présentation
Presentation pres = new Presentation("presentation.pptx");
try {
    // Enregistre la présentation en tant que TIFF
    pres.save("tiff-image.tiff", SaveFormat.Tiff);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Convertir PowerPoint en TIFF Noir et Blanc**

Dans Aspose.Slides 23.10, Aspose.Slides a ajouté une nouvelle propriété ([BwConversionMode](https://reference.aspose.com/slides/java/com.aspose.slides/tiffoptions/#setBwConversionMode-int-)) à la classe [TiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/tiffoptions/) pour vous permettre de spécifier l'algorithme suivi lors de la conversion d'une diapositive ou d'une image colorée en TIFF noir et blanc. Notez que ce paramètre n'est appliqué que lorsque la propriété [CompressionType](https://reference.aspose.com/slides/java/com.aspose.slides/tiffoptions/#setCompressionType-int-) est définie sur `CCITT4` ou `CCITT3`.

Ce code Java vous montre comment convertir une diapositive ou une image colorée en TIFF noir et blanc :

```java
TiffOptions tiffOptions = new TiffOptions();
tiffOptions.setCompressionType(TiffCompressionTypes.CCITT4);
tiffOptions.setBwConversionMode(BlackWhiteConversionMode.Dithering);

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Convertir PowerPoint en TIFF avec Taille Personnalisée**

Si vous avez besoin d'une image TIFF avec des dimensions définies, vous pouvez définir vos dimensions préférées à travers les propriétés fournies sous [TiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/tiffoptions/). En utilisant la propriété [ImageSize](https://reference.aspose.com/slides/java/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-), par exemple, vous pouvez définir une taille pour l'image résultante.

Ce code Java vous montre comment convertir PowerPoint en images TIFF avec une taille personnalisée :

```java
// Instancie un objet Presentation qui représente un fichier de Présentation
Presentation pres = new Presentation("presentation.pptx");
try {
    // Instancie la classe TiffOptions
    TiffOptions opts = new TiffOptions();
    
    // Définit le type de compression
    // Les valeurs possibles sont :
    // Default - Spécifie le schéma de compression par défaut (LZW).
    // None - Spécifie aucune compression.
    // CCITT3
    // CCITT4
    // LZW
    // RLE
    opts.setCompressionType(TiffCompressionTypes.Default);
    
    // Depth – dépend du type de compression et ne peut pas être défini manuellement.
    
    // Définit la DPI de l'image
    opts.setDpiX(200);
    opts.setDpiY(100);
    
    // Définit la Taille de l'Image
    opts.setImageSize(new java.awt.Dimension(1728, 1078));
    
    INotesCommentsLayoutingOptions options = opts.getNotesCommentsLayouting();
    options.setNotesPosition(NotesPositions.BottomFull);
    // Enregistre la présentation en TIFF avec la taille spécifiée
    pres.save("tiff-ImageSize.tiff", SaveFormat.Tiff, opts);
} finally {
    if (pres != null) pres.dispose();
}    
```

## **Convertir PowerPoint en TIFF avec Format de Pixel d'Image Personnalisé**

En utilisant la propriété [PixelFormat](https://reference.aspose.com/slides/java/com.aspose.slides/tiffoptions/#setPixelFormat-int-) sous la classe [TiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/tiffoptions/), vous pouvez spécifier votre format de pixel préféré pour l'image TIFF résultante.

Ce code Java vous montre comment convertir PowerPoint en image TIFF avec un format de pixel personnalisé :

```java
// Instancie un objet Presentation qui représente un fichier de Présentation
Presentation pres = new Presentation("presentation.pptx");
try {
    TiffOptions options = new TiffOptions();
    options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    
    /*
     * ImagePixelFormat contient les valeurs suivantes (comme indiqué dans la documentation) :
     * Format1bppIndexed; // 1 bits par pixel, indexé.
     * Format4bppIndexed; // 4 bits par pixel, indexé.
     * Format8bppIndexed; // 8 bits par pixel, indexé.
     * Format24bppRgb;    // 24 bits par pixel, RVB.
     * Format32bppArgb;   // 32 bits par pixel, ARGB.
     */
    
    // Enregistre la présentation en TIFF avec la taille d'image spécifiée
    pres.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, options);
} finally {
    if (pres != null) pres.dispose();
}
```