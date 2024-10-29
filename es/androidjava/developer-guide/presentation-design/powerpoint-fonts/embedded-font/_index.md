---
title: Fuente embebida - API de Java para PowerPoint
linktitle: Fuente embebida
type: docs
weight: 40
url: /es/androidjava/embedded-font/
keywords: "Fuentes, fuentes embebidas, agregar fuentes, presentación de PowerPoint, Java, Aspose.Slides para Android a través de Java"
description: "Utilice fuentes embebidas en la presentación de PowerPoint en Java"

---

**Las fuentes embebidas en PowerPoint** son útiles cuando desea que su presentación se vea correctamente al abrirse en cualquier sistema o dispositivo. Si utilizó una fuente de terceros o no estándar porque se volvió creativo con su trabajo, entonces tiene aún más razones para embedir su fuente. De lo contrario (sin fuentes embebidas), los textos o números en sus diapositivas, el diseño, el estilo, etc., pueden cambiar o convertirse en rectángulos confusos.

La clase [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager), la clase [FontData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontdata/), la clase [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/) y sus interfaces contienen la mayoría de las propiedades y métodos que necesita para trabajar con fuentes embebidas en presentaciones de PowerPoint.

## **Obtener o eliminar fuentes embebidas de la presentación**

Aspose.Slides proporciona el método [getEmbeddedFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) (expuesto por la clase [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager)) para permitirle obtener (o averiguar) las fuentes embebidas en una presentación. Para eliminar fuentes, se utiliza el método [removeEmbeddedFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) (expuesto por la misma clase).

Este código en Java le muestra cómo obtener y eliminar fuentes embebidas de una presentación:

```java
// Instancia un objeto Presentation que representa un archivo de presentación
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // Renderiza una diapositiva que contiene un marco de texto que utiliza "FunSized" embebido
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    // Guarda la imagen en disco en formato JPEG
    try {
        slideImage.save("picture1_out.jpg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }

    IFontsManager fontsManager = pres.getFontsManager();

    // Obtiene todas las fuentes embebidas
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    // Encuentra la fuente "Calibri"
    IFontData calibriEmbeddedFont = null;
    for (int i = 0; i < embeddedFonts.length; i++) {
        System.out.println("" + embeddedFonts[i].getFontName());
        if ("Calibri".equals(embeddedFonts[i].getFontName())) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }

    // Elimina la fuente "Calibri"
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);

    // Renderiza la presentación; la fuente "Calibri" es reemplazada por una existente
    slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    // Guarda la imagen en disco en formato JPEG
    try {
        slideImage.save("picture2_out.jpg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }

    // Guarda la presentación sin la fuente "Calibri" embebida en disco
    pres.save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Agregar fuentes embebidas a la presentación**

Usando el enum [EmbedFontCharacters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/embedfontcharacters/) y dos sobrecargas del método [addEmbeddedFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-), puede seleccionar su regla de (embebido) preferida para embedir las fuentes en una presentación. Este código en Java le muestra cómo embedir y agregar fuentes a una presentación:

```java
// Carga la presentación
Presentation pres = new Presentation("Fonts.pptx");
try {
    IFontData[] allFonts = pres.getFontsManager().getFonts();
    IFontData[] embeddedFonts = pres.getFontsManager().getEmbeddedFonts();

    for (IFontData font : allFonts)
    {
        boolean embeddedFontsContainsFont = false;
        for (int i = 0; i < embeddedFonts.length; i++)
        {
            if (embeddedFonts[i].equals(font))
            {
                embeddedFontsContainsFont = true;
                break;
            }
        }
        if (!embeddedFontsContainsFont)
        {
            pres.getFontsManager().addEmbeddedFont(font, EmbedFontCharacters.All);

            embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
        }
    }

    // Guarda la presentación en disco
    pres.save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Comprimir fuentes embebidas**

Para permitirle comprimir las fuentes embebidas en una presentación y reducir su tamaño de archivo, Aspose.Slides proporciona el método [compressEmbeddedFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) (expuesto por la clase [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/)).

Este código en Java le muestra cómo comprimir fuentes embebidas en PowerPoint:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```