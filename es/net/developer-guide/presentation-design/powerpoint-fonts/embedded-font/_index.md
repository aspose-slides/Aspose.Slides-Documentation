---
title: Incorporar fuentes en presentaciones en .NET
linktitle: Incorporar fuente
type: docs
weight: 40
url: /es/net/embedded-font/
keywords:
  - agregar fuente
  - incorporar fuente
  - incorporación de fuentes
  - obtener fuente incorporada
  - agregar fuente incorporada
  - eliminar fuente incorporada
  - comprimir fuente incorporada
  - PowerPoint
  - OpenDocument
  - presentación
  - .NET
  - C#
  - Aspose.Slides
description: "Incorpore fuentes TrueType en presentaciones de PowerPoint y OpenDocument con Aspose.Slides para .NET, garantizando una representación precisa en todas las plataformas."
---

**Incorporar fuentes en PowerPoint** garantiza que su presentación mantenga su apariencia prevista en diferentes sistemas. Ya sea que utilice fuentes únicas por creatividad o fuentes estándar, incorporar fuentes evita la alteración del texto y el diseño.

Si utilizó una fuente de terceros o no estándar porque se volvió creativo con su trabajo, entonces tiene aún más motivos para incorporar su fuente. De lo contrario (sin fuentes incorporadas), los textos o números en sus diapositivas, el diseño, el estilo, etc., pueden cambiar o convertirse en rectángulos confusos. 

Utilice las clases [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/), [FontData](https://reference.aspose.com/slides/net/aspose.slides/fontdata/), y [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) para administrar fuentes incorporadas.

## **Obtener y eliminar fuentes incorporadas**

Recupere o elimine fuentes incorporadas de una presentación sin esfuerzo con los métodos [GetEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts) y [RemoveEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/removeembeddedfont).

Este código C# le muestra cómo obtener y eliminar fuentes incorporadas de una presentación:
```c#
using (Presentation presentation = new Presentation("EmbeddedFonts.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Renderiza una diapositiva que contiene un cuadro de texto que usa la fuente incrustada "FunSized"
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture1_out.png", ImageFormat.Png);
    }

    IFontsManager fontsManager = presentation.FontsManager;

    IFontData[] embeddedFonts = fontsManager.GetEmbeddedFonts();

    // Encuentra la fuente "Calibri"
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

    // Guarda la presentación sin la fuente incrustada "Calibri" en disco
    presentation.Save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
}
```


## **Agregar fuentes incorporadas**

Utilizando el enumerado [EmbedFontCharacters](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) y dos sobrecargas del método [AddEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/addembeddedfont/), puede seleccionar la regla de (incorporación) que prefiera para incorporar las fuentes en una presentación. Este código C# le muestra cómo incorporar y añadir fuentes a una presentación:
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


## **Comprimir fuentes incorporadas**

Optimice el tamaño del archivo comprimiendo las fuentes incorporadas mediante [CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/).

Código de ejemplo para la compresión:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.CompressEmbeddedFonts(pres);
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **Preguntas frecuentes**

**¿Cómo puedo saber si una fuente específica en la presentación seguirá siendo sustituida durante la renderización a pesar de estar incorporada?**

Consulte la [información de sustitución](/slides/es/net/font-substitution/) en el administrador de fuentes y las [reglas de sustitución/reemplazo](/slides/es/net/fallback-font/): si la fuente no está disponible o está restringida, se utilizará una alternativa.

**¿Vale la pena incorporar fuentes del "sistema" como Arial/Calibri?**

Por lo general, no—casi siempre están disponibles. Pero para una portabilidad total en entornos "delgados" (Docker, un servidor Linux sin fuentes preinstaladas), incorporar fuentes del sistema puede eliminar el riesgo de sustituciones inesperadas.