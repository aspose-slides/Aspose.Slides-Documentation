---
title: Incrustar fuentes en presentaciones usando Java
linktitle: Incrustar fuente
type: docs
weight: 40
url: /es/java/embedded-font/
keywords:
- agregar fuente
- incrustar fuente
- incrustación de fuentes
- obtener fuente incrustada
- agregar fuente incrustada
- eliminar fuente incrustada
- comprimir fuente incrustada
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Incrustar fuentes TrueType en presentaciones PowerPoint y OpenDocument con Aspose.Slides para Java, garantizando una representación precisa en todas las plataformas."
---

**Fuentes incrustadas en PowerPoint** son útiles cuando deseas que tu presentación se visualice correctamente en cualquier sistema o dispositivo. Si utilizaste una fuente de terceros o no estándar porque te pusiste creativo con tu trabajo, tienes aún más razones para incrustar la fuente. De lo contrario (sin fuentes incrustadas), los textos o números en tus diapositivas, el diseño, el estilo, etc., pueden cambiar o convertirse en rectángulos confusos. 

La clase [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager), la clase [FontData](https://reference.aspose.com/slides/java/com.aspose.slides/fontdata/) , la clase [Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/) y sus interfaces contienen la mayoría de las propiedades y métodos que necesitas para trabajar con fuentes incrustadas en presentaciones de PowerPoint. 

## **Obtener y eliminar fuentes incrustadas**

Aspose.Slides proporciona el método [getEmbeddedFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) (expuesto por la clase [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager)) para permitirte obtener (o descubrir) las fuentes incrustadas en una presentación. Para eliminar fuentes, se utiliza el método [removeEmbeddedFont](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) (expuesto por la misma clase).

Este código Java te muestra cómo obtener y eliminar fuentes incrustadas de una presentación:
```java
// Instancia un objeto Presentation que representa un archivo de presentación
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // Renderiza una diapositiva que contiene un marco de texto que usa la fuente incrustada "FunSized"
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

    // Busca la fuente "Calibri"
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

    // Renderiza la presentación; la fuente "Calibri" se reemplaza por una existente
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


## **Agregar fuentes incrustadas**

Utilizando el enumerado [EmbedFontCharacters](https://reference.aspose.com/slides/java/com.aspose.slides/embedfontcharacters/) y dos sobrecargas del método [addEmbeddedFont](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-), puedes seleccionar la regla de incrustación que prefieras para incrustar las fuentes en una presentación. Este código Java te muestra cómo incrustar y agregar fuentes a una presentación:
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

Para permitirte comprimir las fuentes incrustadas en una presentación y reducir su tamaño de archivo, Aspose.Slides ofrece el método [compressEmbeddedFonts](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) (expuesto por la clase [Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/)).

Este código Java te muestra cómo comprimir fuentes de PowerPoint incrustadas:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Preguntas frecuentes**

**¿Cómo puedo saber si una fuente específica en la presentación aún será sustituida durante la renderización a pesar de estar incrustada?**

Consulta la [substitution information](/slides/es/java/font-substitution/) en el gestor de fuentes y las [fallback/substitution rules](/slides/es/java/fallback-font/): si la fuente no está disponible o está restringida, se utilizará una alternativa.

**¿Vale la pena incrustar fuentes “del sistema” como Arial/Calibri?**

Normalmente no, ya que casi siempre están disponibles. Pero para una portabilidad total en entornos “delgados” (Docker, un servidor Linux sin fuentes preinstaladas), incrustar fuentes del sistema puede eliminar el riesgo de sustituciones inesperadas.