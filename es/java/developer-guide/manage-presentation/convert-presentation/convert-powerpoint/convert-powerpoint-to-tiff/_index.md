---
title: Convertir PowerPoint a TIFF
type: docs
weight: 90
url: /java/convert-powerpoint-to-tiff/
keywords: "Convertir presentación de PowerPoint, PowerPoint a TIFF, PPT a TIFF, PPTX a TIFF, Java, Aspose.Slides"
description: "Convertir presentación de PowerPoint a TIFF en Java"

---

**TIFF** (Formato de archivo de imagen etiquetado) es un formato de imagen rasterizada sin pérdida y de alta calidad. Los profesionales utilizan TIFF para sus propósitos de diseño, fotografía y publicación en escritorio. Por ejemplo, si desea preservar capas y configuraciones en su diseño o imagen, puede querer guardar su trabajo como un archivo de imagen TIFF.

Aspose.Slides le permite convertir las diapositivas en PowerPoint directamente a TIFF.

{{% alert title="Consejo" color="primary" %}}

Puede querer echar un vistazo al [convertidor GRATUITO de PowerPoint a cartel de Aspose](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **Convertir PowerPoint a TIFF**

Usando el método [Save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) expuesto por la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/), puede convertir rápidamente una presentación de PowerPoint completa a TIFF. Las imágenes TIFF resultantes corresponden al tamaño predeterminado de las diapositivas.

Este código en Java le muestra cómo convertir PowerPoint a TIFF:

```java
// Instanciar un objeto Presentation que representa un archivo de presentación
Presentation pres = new Presentation("presentation.pptx");
try {
    // Guarda la presentación como TIFF
    pres.save("tiff-image.tiff", SaveFormat.Tiff);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Convertir PowerPoint a TIFF en blanco y negro**

En Aspose.Slides 23.10, Aspose.Slides añadió una nueva propiedad ([BwConversionMode](https://reference.aspose.com/slides/java/com.aspose.slides/tiffoptions/#setBwConversionMode-int-)) a la clase [TiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/tiffoptions/) para permitirle especificar el algoritmo que se sigue cuando una diapositiva o imagen en color se convierte a un TIFF en blanco y negro. Tenga en cuenta que esta configuración se aplica solo cuando la propiedad [CompressionType](https://reference.aspose.com/slides/java/com.aspose.slides/tiffoptions/#setCompressionType-int-) está configurada en `CCITT4` o `CCITT3`.

Este código en Java le muestra cómo convertir una diapositiva o imagen en color a TIFF en blanco y negro:

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

## **Convertir PowerPoint a TIFF con tamaño personalizado**

Si necesita una imagen TIFF con dimensiones definidas, puede definir sus figuras preferidas a través de las propiedades proporcionadas bajo [TiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/tiffoptions/). Usando la propiedad [ImageSize](https://reference.aspose.com/slides/java/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-), por ejemplo, puede establecer un tamaño para la imagen resultante.

Este código en Java le muestra cómo convertir PowerPoint a imágenes TIFF con tamaño personalizado:

```java
// Instanciar un objeto Presentation que representa un archivo de presentación
Presentation pres = new Presentation("presentation.pptx");
try {
    // Instanciar la clase TiffOptions
    TiffOptions opts = new TiffOptions();
    
    // Establece el tipo de compresión
    // Los valores posibles son:
    // Default - Especifica el esquema de compresión predeterminado (LZW).
    // None - Especifica sin compresión.
    // CCITT3
    // CCITT4
    // LZW
    // RLE
    opts.setCompressionType(TiffCompressionTypes.Default);
    
    // Depth – depende del tipo de compresión y no se puede establecer manualmente.
    
    // Establece la DPI de la imagen
    opts.setDpiX(200);
    opts.setDpiY(100);
    
    // Establece el tamaño de la imagen
    opts.setImageSize(new java.awt.Dimension(1728, 1078));
    
    INotesCommentsLayoutingOptions options = opts.getNotesCommentsLayouting();
    options.setNotesPosition(NotesPositions.BottomFull);
    // Guarda la presentación en TIFF con tamaño especificado
    pres.save("tiff-ImageSize.tiff", SaveFormat.Tiff, opts);
} finally {
    if (pres != null) pres.dispose();
}    
```

## **Convertir PowerPoint a TIFF con formato de píxel de imagen personalizado**

Usando la propiedad [PixelFormat](https://reference.aspose.com/slides/java/com.aspose.slides/tiffoptions/#setPixelFormat-int-) bajo la clase [TiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/tiffoptions/), puede especificar su formato de píxel preferido para la imagen TIFF resultante.

Este código en Java le muestra cómo convertir PowerPoint a una imagen TIFF con formato de píxel personalizado:

```java
// Instanciar un objeto Presentation que representa un archivo de presentación
Presentation pres = new Presentation("presentation.pptx");
try {
    TiffOptions options = new TiffOptions();
    options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    
    /*
     * ImagePixelFormat contiene los siguientes valores (como se indica en la documentación):
     * Format1bppIndexed; // 1 bits por píxel, indexado.
     * Format4bppIndexed; // 4 bits por píxel, indexado.
     * Format8bppIndexed; // 8 bits por píxel, indexado.
     * Format24bppRgb;    // 24 bits por píxel, RGB.
     * Format32bppArgb;   // 32 bits por píxel, ARGB.
     */
    
    // Guarda la presentación en TIFF con el tamaño de imagen especificado
    pres.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, options);
} finally {
    if (pres != null) pres.dispose();
}
```