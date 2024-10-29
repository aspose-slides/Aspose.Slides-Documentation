---
title: Convertir PowerPoint en TIFF
type: docs
weight: 90
url: /fr/androidjava/convert-powerpoint-to-tiff/
keywords: "Convertir présentation PowerPoint, PowerPoint en TIFF, PPT en TIFF, PPTX en TIFF, Java, Aspose.Slides"
description: "Convertir la présentation PowerPoint en TIFF en Java"

---

**TIFF** (Tagged Image File Format) est un format d'image matricielle sans perte et de haute qualité. Les professionnels utilisent TIFF pour leurs besoins en design, en photographie et en publication assistée par ordinateur. Par exemple, si vous souhaitez préserver les calques et les paramètres de votre design ou de votre image, vous pouvez vouloir sauvegarder votre travail en tant que fichier image TIFF.

Aspose.Slides vous permet de convertir les diapositives de PowerPoint directement en TIFF.

{{% alert title="Astuce" color="primary" %}}

Vous pouvez consulter le [convertisseur GRATUIT de PowerPoint en poster d'Aspose](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **Convertir PowerPoint en TIFF**

En utilisant la méthode [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) exposée par la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/), vous pouvez rapidement convertir une présentation PowerPoint entière en TIFF. Les images TIFF résultantes correspondent à la taille par défaut des diapositives.

Ce code Java vous montre comment convertir PowerPoint en TIFF :

```java
// Instancie un objet Presentation qui représente un fichier de présentation
Presentation pres = new Presentation("presentation.pptx");
try {
    // Sauvegarde la présentation en tant que TIFF
    pres.save("tiff-image.tiff", SaveFormat.Tiff);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Convertir PowerPoint en TIFF noir et blanc**

Dans Aspose.Slides 23.10, Aspose.Slides a ajouté une nouvelle propriété ([BwConversionMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-)) à la classe [TiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/) pour vous permettre de spécifier l'algorithme à suivre lorsqu'une diapositive ou une image colorée est convertie en TIFF noir et blanc. Notez que ce paramètre est appliqué uniquement lorsque la propriété [CompressionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) est définie sur `CCITT4` ou `CCITT3`.

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

## **Convertir PowerPoint en TIFF avec une taille personnalisée**

Si vous avez besoin d'une image TIFF avec des dimensions définies, vous pouvez définir vos chiffres préférés grâce aux propriétés fournies sous [TiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/). En utilisant la propriété [ImageSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-), par exemple, vous pouvez définir une taille pour l'image résultante.

Ce code Java vous montre comment convertir PowerPoint en images TIFF avec une taille personnalisée :

```java
// Instancie un objet Presentation qui représente un fichier de présentation
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
    
    // Profondeur – dépend du type de compression et ne peut pas être définie manuellement.
    
    // Définit le DPI de l'image
    opts.setDpiX(200);
    opts.setDpiY(100);
    
    // Définit la taille de l'image
    opts.setImageSize(new java.awt.Dimension(1728, 1078));
    
    INotesCommentsLayoutingOptions options = opts.getNotesCommentsLayouting();
    options.setNotesPosition(NotesPositions.BottomFull);
    // Sauvegarde la présentation en TIFF avec la taille spécifiée
    pres.save("tiff-ImageSize.tiff", SaveFormat.Tiff, opts);
} finally {
    if (pres != null) pres.dispose();
}    
```

## **Convertir PowerPoint en TIFF avec un format de pixel d'image personnalisé**

En utilisant la propriété [PixelFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) sous la classe [TiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/), vous pouvez spécifier votre format de pixel préféré pour l'image TIFF résultante.

Ce code Java vous montre comment convertir PowerPoint en image TIFF avec un format de pixel personnalisé :

```java
// Instancie un objet Presentation qui représente un fichier de présentation
Presentation pres = new Presentation("presentation.pptx");
try {
    TiffOptions options = new TiffOptions();
    options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    
    /*
     * ImagePixelFormat contient les valeurs suivantes (comme indiqué dans la documentation) :
     * Format1bppIndexed; // 1 bit par pixel, indexé.
     * Format4bppIndexed; // 4 bits par pixel, indexé.
     * Format8bppIndexed; // 8 bits par pixel, indexé.
     * Format24bppRgb;    // 24 bits par pixel, RGB.
     * Format32bppArgb;   // 32 bits par pixel, ARGB.
     */
    
    // Sauvegarde la présentation en TIFF avec la taille d'image spécifiée
    pres.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, options);
} finally {
    if (pres != null) pres.dispose();
}
```