---
title: Fuente incrustada - API de PowerPoint C#
linktitle: Fuente incrustada
type: docs
weight: 40
url: /es/net/embedded-font/
keywords:
- fuentes
- fuentes incrustadas
- agregar fuentes
- PowerPoint
- presentación
- C#
- Csharp
- Aspose.Slides para .NET
description: "Utiliza fuentes incrustadas en presentaciones de PowerPoint en C# o .NET"
---

**Las fuentes incrustadas en PowerPoint** son útiles cuando deseas que tu presentación se vea correctamente al abrirse en cualquier sistema o dispositivo. Si usaste una fuente de terceros o no estándar porque te inspiraste con tu trabajo, entonces tienes aún más razones para incrustar tu fuente. De lo contrario (sin fuentes incrustadas), los textos o números en tus diapositivas, el diseño, el estilo, etc. pueden cambiar o convertirse en rectángulos confusos.

La clase [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/), la clase [FontData](https://reference.aspose.com/slides/net/aspose.slides/fontdata/), la clase [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) y sus interfaces contienen la mayoría de las propiedades y métodos que necesitas para trabajar con fuentes incrustadas en presentaciones de PowerPoint.

## **Obtener o eliminar fuentes incrustadas de una presentación**

Aspose.Slides proporciona el método [GetEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts) (expuesto por la clase [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/)) para permitirte obtener (o averiguar) las fuentes incrustadas en una presentación. Para eliminar fuentes, se utiliza el método [RemoveEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/removeembeddedfont) (expuesto por la misma clase).

Este código C# te muestra cómo obtener y eliminar fuentes incrustadas de una presentación:

```c#
using (Presentation presentation = new Presentation("EmbeddedFonts.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Renderiza una diapositiva que contiene un marco de texto que utiliza "FunSized" incrustado
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

    // Renderiza la presentación; la fuente "Calibri" es reemplazada por una existente
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture2_out.png", ImageFormat.Png);
    }

    // Guarda la presentación sin la fuente incrustada "Calibri" en el disco
    presentation.Save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
}
```

## **Agregar fuentes incrustadas a la presentación**
Usando el enum [EmbedFontCharacters](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) y dos sobrecargas del método [AddEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/addembeddedfont/), puedes seleccionar tu regla de preferencia (incrustación) para incrustar las fuentes en una presentación. Este código C# te muestra cómo incrustar y agregar fuentes a una presentación:

```c#
// Carga la presentación
Presentation presentation = new Presentation("Fonts.pptx");

// Carga la fuente fuente que se va a reemplazar
IFontData sourceFont = new FontData("Arial");

IFontData[] allFonts = presentation.FontsManager.GetFonts();
IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();
foreach (IFontData font in allFonts)
{
    if (!embeddedFonts.Contains(font))
    {
        presentation.FontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
    }
}

// Guarda la presentación en el disco
presentation.Save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
```

## **Comprimir fuentes incrustadas**

Para permitirte comprimir las fuentes incrustadas en una presentación y reducir su tamaño de archivo, Aspose.Slides proporciona el método [CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/) (expuesto por la clase [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/)).

Este código C# te muestra cómo comprimir fuentes incrustadas de PowerPoint:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.CompressEmbeddedFonts(pres);
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```