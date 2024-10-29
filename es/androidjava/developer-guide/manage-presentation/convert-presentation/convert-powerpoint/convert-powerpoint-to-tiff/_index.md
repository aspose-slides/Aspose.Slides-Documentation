---
title: Convertir PowerPoint a TIFF
type: docs
weight: 90
url: /es/androidjava/convert-powerpoint-to-tiff/
keywords: "Convertir presentación de PowerPoint, PowerPoint a TIFF, PPT a TIFF, PPTX a TIFF, Java, Aspose.Slides"
description: "Convertir presentación de PowerPoint a TIFF en Java"

---

**TIFF** (Formato de archivo de imagen etiquetada) es un formato de imagen de trama sin pérdida y de alta calidad. Los profesionales utilizan TIFF para sus propósitos de diseño, fotografía y publicación en escritorio. Por ejemplo, si deseas preservar capas y configuraciones en tu diseño o imagen, es posible que desees guardar tu trabajo como un archivo de imagen TIFF.

Aspose.Slides te permite convertir las diapositivas en PowerPoint directamente a TIFF.

{{% alert title="Consejo" color="primary" %}}

Puede que quieras echar un vistazo al [convertidor GRATUITO de PowerPoint a cartel de Aspose](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **Convertir PowerPoint a TIFF**

Usando el método [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) expuesto por la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/), puedes convertir rápidamente toda una presentación de PowerPoint a TIFF. Las imágenes TIFF resultantes corresponden al tamaño predeterminado de las diapositivas.

Este código Java te muestra cómo convertir PowerPoint a TIFF:

```java
// Instancia un objeto Presentation que representa un archivo de presentación
Presentation pres = new Presentation("presentation.pptx");
try {
    // Guarda la presentación como TIFF
    pres.save("tiff-image.tiff", SaveFormat.Tiff);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Convertir PowerPoint a TIFF en blanco y negro**

En Aspose.Slides 23.10, Aspose.Slides agregó una nueva propiedad ([BwConversionMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-)) a la clase [TiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/) para permitirte especificar el algoritmo que se sigue cuando una diapositiva o imagen en color se convierte a un TIFF en blanco y negro. Ten en cuenta que esta configuración se aplica solo cuando se establece la propiedad [CompressionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) en `CCITT4` o `CCITT3`.

Este código Java te muestra cómo convertir una diapositiva o imagen en color a TIFF en blanco y negro:

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

Si requieres una imagen TIFF con dimensiones definidas, puedes definir tus cifras preferidas a través de las propiedades proporcionadas bajo [TiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/). Usando la propiedad [ImageSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-), por ejemplo, puedes establecer un tamaño para la imagen resultante.

Este código Java te muestra cómo convertir PowerPoint a imágenes TIFF con tamaño personalizado:

```java
// Instancia un objeto Presentation que representa un archivo de presentación
Presentation pres = new Presentation("presentation.pptx");
try {
    // Instancia la clase TiffOptions
    TiffOptions opts = new TiffOptions();
    
    // Establece el tipo de compresión
    // Valores posibles son:
    // Default - Especifica el esquema de compresión predeterminado (LZW).
    // None - Especifica sin compresión.
    // CCITT3
    // CCITT4
    // LZW
    // RLE
    opts.setCompressionType(TiffCompressionTypes.Default);
    
    // Profundidad – depende del tipo de compresión y no se puede establecer manualmente.
    
    // Establece el DPI de la imagen
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

Usando la propiedad [PixelFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) bajo la clase [TiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/), puedes especificar tu formato de píxel preferido para la imagen TIFF resultante.

Este código Java te muestra cómo convertir PowerPoint a imagen TIFF con formato de píxel personalizado:

```java
// Instancia un objeto Presentation que representa un archivo de presentación
Presentation pres = new Presentation("presentation.pptx");
try {
    TiffOptions options = new TiffOptions();
    options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    
    /*
     * ImagePixelFormat contiene los siguientes valores (como se indica en la documentación):
     * Format1bppIndexed; // 1 bit por píxel, indexado.
     * Format4bppIndexed; // 4 bits por píxel, indexado.
     * Format8bppIndexed; // 8 bits por píxel, indexado.
     * Format24bppRgb;    // 24 bits por píxel, RGB.
     * Format32bppArgb;   // 32 bits por píxel, ARGB.
     */
    
    // Guarda la presentación en TIFF con tamaño de imagen especificado
    pres.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, options);
} finally {
    if (pres != null) pres.dispose();
}
```