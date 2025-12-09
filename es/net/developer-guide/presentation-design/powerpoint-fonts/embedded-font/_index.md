---
title: Incrustar fuentes en presentaciones en .NET
linktitle: Incrustar fuente
type: docs
weight: 40
url: /es/net/embedded-font/
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
- .NET
- C#
- Aspose.Slides
description: "Incruste fuentes TrueType en presentaciones PowerPoint y OpenDocument con Aspose.Slides para .NET, garantizando una renderización precisa en todas las plataformas."
---

**Incorporar fuentes en PowerPoint** garantiza que su presentación mantenga su apariencia prevista en diferentes sistemas. Ya sea que utilice fuentes únicas por creatividad o fuentes estándar, incrustar fuentes evita la alteración del texto y el diseño.

Si utilizó una fuente de terceros o no estándar porque quiso ser creativo con su trabajo, entonces tiene aún más motivos para incrustar la fuente. De lo contrario (sin fuentes incrustadas), los textos o números en sus diapositivas, el diseño, el estilo, etc., pueden cambiar o convertirse en rectángulos confusos.

Utilice las clases FontsManager, FontData y Compress para gestionar las fuentes incrustadas.

## **Obtener y eliminar fuentes incrustadas**

Recupere o elimine fuentes incrustadas de una presentación sin esfuerzo con los métodos GetEmbeddedFonts y RemoveEmbeddedFont.

Este código C# le muestra cómo obtener y eliminar fuentes incrustadas de una presentación:
```c#
using (Presentation presentation = new Presentation("EmbeddedFonts.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Renderiza una diapositiva que contiene un marco de texto que usa la fuente incrustada "FunSized"
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture1_out.png", ImageFormat.Png);
    }

    IFontsManager fontsManager = presentation.FontsManager;

    IFontData[] embeddedFonts = fontsManager.GetEmbeddedFonts();

    // Busca la fuente "Calibri"
    IFontData funSizedEmbeddedFont = Array.Find(embeddedFonts, delegate (IFontData data)
    {
        return data.FontName == "Calibri";
    });

    // Elimina la fuente "Calibri"
    fontsManager.RemoveEmbeddedFont(funSizedEmbeddedFont);

    // Renderiza la presentación; la fuente "Calibri" se reemplaza por una existente
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture2_out.png", ImageFormat.Png);
    }

    // Guarda la presentación sin la fuente "Calibri" incrustada en disco
    presentation.Save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
}
```


## **Agregar fuentes incrustadas**

Usando el enum EmbedFontCharacters y dos sobrecargas del método AddEmbeddedFont, puede seleccionar la regla de (incrustación) que prefiera para incrustar las fuentes en una presentación. Este código C# le muestra cómo incrustar y agregar fuentes a una presentación:
```c#
// Carga la presentación
Presentation presentation = new Presentation("Fonts.pptx");

IFontData[] allFonts = presentation.FontsManager.GetFonts();
IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();
foreach (IFontData font in allFonts)
{
    if (!embeddedFonts.Contains(font))
    {
        presentation.FontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
    }
}

// Guarda la presentación en disco
presentation.Save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
```


## **Comprimir fuentes incrustadas**

Optimice el tamaño del archivo comprimiendo las fuentes incrustadas mediante CompressEmbeddedFonts.

Ejemplo de código para la compresión:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.CompressEmbeddedFonts(pres);
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **Preguntas frecuentes**

**¿Cómo puedo saber que una fuente específica en la presentación seguirá siendo sustituida durante la renderización a pesar de estar incrustada?**

Consulte la [substitution information](/slides/es/net/font-substitution/) en el gestor de fuentes y las [fallback/substitution rules](/slides/es/net/fallback-font/): si la fuente no está disponible o está restringida, se utilizará una alternativa.

**¿Vale la pena incrustar fuentes “del sistema” como Arial/Calibri?**

Normalmente no, ya que casi siempre están disponibles. Pero para una portabilidad total en entornos “delgados” (Docker, un servidor Linux sin fuentes preinstaladas), incrustar fuentes del sistema puede eliminar el riesgo de sustituciones inesperadas.