---
title: Fuente incrustada - API de Java para PowerPoint
linktitle: Fuente incrustada
type: docs
weight: 40
url: /java/embedded-font/
keywords: "Fuentes, fuentes incrustadas, añadir fuentes, presentación de PowerPoint, Java, Aspose.Slides para Java"
description: "Usa fuentes incrustadas en la presentación de PowerPoint en Java"

---

**Las fuentes incrustadas en PowerPoint** son útiles cuando deseas que tu presentación se muestre correctamente al abrirse en cualquier sistema o dispositivo. Si utilizaste una fuente de terceros o no estándar porque te volviste creativo con tu trabajo, entonces tienes aún más razones para incrustar tu fuente. De lo contrario (sin fuentes incrustadas), los textos o números en tus diapositivas, el diseño, el estilo, etc. pueden cambiar o convertirse en rectángulos confusos.

La clase [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager), la clase [FontData](https://reference.aspose.com/slides/java/com.aspose.slides/fontdata/), la clase [Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/) y sus interfaces contienen la mayoría de las propiedades y métodos que necesitas para trabajar con fuentes incrustadas en presentaciones de PowerPoint.

## **Obtener o eliminar fuentes incrustadas de la presentación**

Aspose.Slides proporciona el método [getEmbeddedFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) (expuesto por la clase [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager)) para permitirte obtener (o averiguar) las fuentes incrustadas en una presentación. Para eliminar fuentes, se utiliza el método [removeEmbeddedFont](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) (expuesto por la misma clase).

Este código en Java te muestra cómo obtener y eliminar fuentes incrustadas de una presentación:

```java
// Instancia un objeto Presentation que representa un archivo de presentación
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // Renderiza una diapositiva que contiene un marco de texto que usa "FunSized" incrustado
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    // Guarda la imagen en disco en formato JPEG
    try {
        slideImage.save("picture1_out.jpg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }

    IFontsManager fontsManager = pres.getFontsManager();

    // Obtiene todas las fuentes incrustadas
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    // Encuentra la fuente "Calibri"
    IFontData calibriEmbeddedFont = null;
    for (int i = 0; i < embeddedFonts.length; i++) {
        System.out.println(""+ embeddedFonts[i].getFontName());
        if ("Calibri".equals(embeddedFonts[i].getFontName())) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }

    // Elimina la fuente "Calibri"
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);

    // Renderiza la presentación; la fuente "Calibri" se reemplaza con una existente
     slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

     // Guarda la imagen en disco en formato JPEG
     try {
         slideImage.save("picture2_out.jpg", ImageFormat.Jpeg);
     } finally {
         if (slideImage != null) slideImage.dispose();
     }

    // Guarda la presentación sin la fuente "Calibri" incrustada en disco
    pres.save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Añadir fuentes incrustadas a la presentación**

Usando el enumerador [EmbedFontCharacters](https://reference.aspose.com/slides/java/com.aspose.slides/embedfontcharacters/) y dos sobrecargas del método [addEmbeddedFont](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-), puedes seleccionar tu regla preferida (de incrustación) para incrustar las fuentes en una presentación. Este código en Java te muestra cómo incrustar y añadir fuentes a una presentación:

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

## **Comprimir fuentes incrustadas**

Para permitirte comprimir las fuentes incrustadas en una presentación y reducir su tamaño de archivo, Aspose.Slides proporciona el método [compressEmbeddedFonts](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) (expuesto por la clase [Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/)).

Este código en Java te muestra cómo comprimir las fuentes incrustadas de PowerPoint:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```