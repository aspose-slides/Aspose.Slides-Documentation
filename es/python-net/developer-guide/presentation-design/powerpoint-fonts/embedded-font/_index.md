---
title: Fuente Embebida
type: docs
weight: 40
url: /es/python-net/embedded-font/
keywords: "Fuentes, fuentes embebidas, agregar fuentes, presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Usa fuentes embebidas en una presentación de PowerPoint en Python"
---

**Las fuentes embebidas en PowerPoint** son útiles cuando deseas que tu presentación aparezca correctamente al abrirse en cualquier sistema o dispositivo. Si utilizaste una fuente de un tercero o no estándar porque te inspiraste en tu trabajo, entonces tienes aún más razones para embebeder tu fuente. De lo contrario (sin fuentes embebidas), los textos o números en tus diapositivas, el diseño, el estilo, etc., pueden cambiar o convertirse en rectángulos confusos.

La clase [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/), la clase [FontData](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/), la clase [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) y sus interfaces contienen la mayoría de las propiedades y métodos que necesitas para trabajar con fuentes embebidas en presentaciones de PowerPoint.

## **Obtener o Eliminar Fuentes Embebidas de la Presentación**

Aspose.Slides proporciona el método `get_embedded_fonts()` (expuesto por la clase [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/)) para permitirte obtener (o averiguar) las fuentes embebidas en una presentación. Para eliminar fuentes, se utiliza el método `remove_embedded_font(font_data)` (expuesto por la misma clase).

Este código en Python te muestra cómo obtener y eliminar fuentes embebidas de una presentación:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Crea un objeto Presentation que representa un archivo de presentación
with slides.Presentation(path + "EmbeddedFonts.pptx") as presentation:
    # Renderiza una diapositiva que contiene un marco de texto que usa "FunSized" embebido
    with presentation.slides[0].get_image(draw.Size(960, 720)) as img:
        img.save("picture1_out.png", slides.ImageFormat.PNG)

    fontsManager = presentation.fonts_manager

    # Obtiene todas las fuentes embebidas
    embeddedFonts = fontsManager.get_embedded_fonts()

    # Encuentra la fuente "Calibri"
    
    funSizedEmbeddedFont = list(filter(lambda data : data.font_name == "Calibri", embeddedFonts))[0]

    # Elimina la fuente "Calibri"
    fontsManager.remove_embedded_font(funSizedEmbeddedFont)

    # Renderiza la presentación; la fuente "Calibri" es reemplazada por una existente
    with presentation.slides[0].get_image(draw.Size(960, 720)) as img:
        img.save("picture2_out.png", slides.ImageFormat.PNG)

    # Guarda la presentación sin la fuente "Calibri" embebida en disco
    presentation.save("WithoutManageEmbeddedFonts_out.ppt", slides.export.SaveFormat.PPT)
```

## **Agregar Fuentes Embebidas a la Presentación**

Utilizando el enum [EmbedFontCharacters](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedfontcharacters/) y dos sobrecargas del método `add_embedded_font(font_data, embed_font_rule)`, puedes seleccionar tu regla preferida (de embebido) para embebeder las fuentes en una presentación. Este código en Python te muestra cómo embebeder y agregar fuentes a una presentación:

```python
import aspose.slides as slides

# Carga la presentación
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Carga la fuente de origen que se va a reemplazar
    sourceFont = slides.FontData("Arial")

    allFonts = presentation.fonts_manager.get_fonts()
    embeddedFonts = presentation.fonts_manager.get_embedded_fonts()
    for font in allFonts:
        if font not in embeddedFonts:
            presentation.fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)

    # Guarda la presentación en disco
    presentation.save("AddEmbeddedFont_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Comprimir Fuentes Embebidas**

Para permitirte comprimir las fuentes embebidas en una presentación y reducir su tamaño de archivo, Aspose.Slides proporciona el método `compress_embedded_fonts` (expuesto por la clase [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/)).

Este código en Python te muestra cómo comprimir fuentes embebidas de PowerPoint:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:

    slides.lowcode.Compress.compress_embedded_fonts(pres)
    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```