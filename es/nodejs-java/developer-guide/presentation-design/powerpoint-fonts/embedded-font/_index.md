---
title: "Fuente incrustada - API de JavaScript para PowerPoint"
linktitle: "Fuente incrustada"
type: docs
weight: 40
url: /es/nodejs-java/embedded-font/
keywords: "Fuentes, fuentes incrustadas, agregar fuentes, presentación PowerPoint, Java, Aspose.Slides para Node.js vía Java"
description: "Utilice fuentes incrustadas en presentaciones PowerPoint con JavaScript"
---

**Fuentes incrustadas en PowerPoint** son útiles cuando desea que su presentación se vea correctamente al abrirse en cualquier sistema o dispositivo. Si utilizó una fuente de terceros o no estándar porque se volvió creativo con su trabajo, entonces tiene aún más razones para incrustar su fuente. De lo contrario (sin fuentes incrustadas), los textos o números en sus diapositivas, el diseño, el estilo, etc., pueden cambiar o convertirse en rectángulos confusos. 

La clase [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager), la clase [FontData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontdata/), la clase [Compress](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/) y sus clases contienen la mayoría de las propiedades y métodos que necesita para trabajar con fuentes incrustadas en presentaciones de PowerPoint.

## **Obtener o eliminar fuentes incrustadas de la presentación**

Aspose.Slides proporciona el método [getEmbeddedFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) (expuesto por la clase [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager)) para permitirle obtener (o averiguar) las fuentes incrustadas en una presentación. Para eliminar fuentes, se utiliza el método [removeEmbeddedFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/#removeEmbeddedFont-aspose.slides.IFontData-) (expuesto por la misma clase).

Este código JavaScript le muestra cómo obtener y eliminar fuentes incrustadas de una presentación:
```javascript
// Instancia un objeto Presentation que representa un archivo de presentación
var pres = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    // Renderiza una diapositiva que contiene un marco de texto que usa la fuente incrustada "FunSized"
    var slideImage = pres.getSlides().get_Item(0).getImage(java.newInstanceSync("java.awt.Dimension", 960, 720));
    // Guarda la imagen en disco en formato JPEG
    try {
        slideImage.save("picture1_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    var fontsManager = pres.getFontsManager();
    // Obtiene todas las fuentes incrustadas
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    // Busca la fuente "Calibri"
    var calibriEmbeddedFont = null;
    for (var i = 0; i < embeddedFonts.length; i++) {
        console.log("" + embeddedFonts[i].getFontName());
        if ("Calibri" == embeddedFonts[i].getFontName()) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }
    // Elimina la fuente "Calibri"
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);
    // Renderiza la presentación; la fuente "Calibri" se reemplaza por una existente
    slideImage = pres.getSlides().get_Item(0).getImage(java.newInstanceSync("java.awt.Dimension", 960, 720));
    // Guarda la imagen en disco en formato JPEG
    try {
        slideImage.save("picture2_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    // Guarda la presentación sin la fuente incrustada "Calibri" en disco
    pres.save("WithoutManageEmbeddedFonts_out.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Agregar fuentes incrustadas a la presentación**

Utilizando el enumerado [EmbedFontCharacters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/embedfontcharacters/) y dos sobrecargas del método [addEmbeddedFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/#addEmbeddedFont-aspose.slides.IFontData-int-), puede seleccionar la regla de incrustación que prefiera para incrustar las fuentes en una presentación. Este código JavaScript le muestra cómo incrustar y agregar fuentes a una presentación:
```javascript
// Carga la presentación
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    var allFonts = pres.getFontsManager().getFonts();
    var embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
    allFonts.forEach(font => {
        var embeddedFontsContainsFont = false;
        for (var i = 0; i < embeddedFonts.length; i++) {
            if (embeddedFonts[i].equals(font)) {
                embeddedFontsContainsFont = true;
                break;
            }
        }
        if (!embeddedFontsContainsFont) {
            pres.getFontsManager().addEmbeddedFont(font, aspose.slides.EmbedFontCharacters.All);
            embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
        }
    });
    // Guarda la presentación en disco
    pres.save("AddEmbeddedFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Comprimir fuentes incrustadas**

Para permitirle comprimir las fuentes incrustadas en una presentación y reducir su tamaño de archivo, Aspose.Slides proporciona el método [compressEmbeddedFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts-aspose.slides.Presentation-) (expuesto por la clase [Compress](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/)).

Este código JavaScript le muestra cómo comprimir fuentes incrustadas de PowerPoint:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Preguntas frecuentes**

**¿Cómo puedo saber si una fuente específica en la presentación seguirá siendo sustituida durante la renderización a pesar de estar incrustada?**

Consulte la [información de sustitución](/slides/es/nodejs-java/font-substitution/) en el administrador de fuentes y las [reglas de respaldo/sustitución](/slides/es/nodejs-java/fallback-font/): si la fuente no está disponible o está restringida, se utilizará una fuente de respaldo.

**¿Vale la pena incrustar fuentes "del sistema" como Arial/Calibri?**

Normalmente no, ya que casi siempre están disponibles. Pero para una portabilidad total en entornos "delgados" (Docker, un servidor Linux sin fuentes preinstaladas), incrustar fuentes del sistema puede eliminar el riesgo de sustituciones inesperadas.