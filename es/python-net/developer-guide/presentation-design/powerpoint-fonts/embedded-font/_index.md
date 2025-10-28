---
title: Incrustar fuentes en presentaciones con Python
linktitle: Incrustar fuente
type: docs
weight: 40
url: /es/python-net/embedded-font/
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
- Python
- Aspose.Slides
description: "Incruste fuentes TrueType en presentaciones de PowerPoint y OpenDocument con Aspose.Slides para Python a través de .NET, garantizando una representación exacta en todas las plataformas."
---

## **Descripción general**

**Incrustar fuentes en PowerPoint** garantiza que tu presentación mantenga su apariencia prevista en diferentes sistemas. Ya sea que uses fuentes únicas por creatividad o fuentes estándar, incrustar fuentes evita la alteración del texto y el diseño.

Si utilizaste una fuente de terceros o no estándar porque te pusiste creativo con tu trabajo, entonces tienes aún más razones para incrustar tu fuente. De lo contrario (sin fuentes incrustadas), los textos o números en tus diapositivas, el diseño, el estilo, etc., pueden cambiar o convertirse en rectángulos confusos.

Utilice las clases [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/), [FontData](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/), y [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) para gestionar fuentes incrustadas.

## **Obtener y eliminar fuentes incrustadas**

Recupere o elimine fuentes incrustadas de una presentación de forma sencilla con los métodos [get_embedded_fonts](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) y [remove_embedded_font](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/remove_embedded_font/).

Este código Python muestra cómo obtener y eliminar fuentes incrustadas de una presentación:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate the Presentation class that represents a presentation file.
with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slide = presentation.slides[0]

    # Render the slide containing a text frame that uses the embedded 'FunSized' font.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture1_out.png", slides.ImageFormat.PNG)

    fonts_manager = presentation.fonts_manager

    # Get all embedded fonts.
    embedded_fonts = fonts_manager.get_embedded_fonts()

    # Find the 'Calibri' font.
    font_data = list(filter(lambda data : data.font_name == "Calibri", embedded_fonts))[0]

    # Remove the 'Calibri' font.
    fonts_manager.remove_embedded_font(font_data)

    # Render the slide; the 'Calibri' font will be replaced with an existing one.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture2_out.png", slides.ImageFormat.PNG)

    # Save the presentation without the embedded 'Calibri' font to disk.
    presentation.save("WithoutEmbeddedFonts.ppt", slides.export.SaveFormat.PPT)
```

## **Agregar fuentes incrustadas**

Usando el enumerado [EmbedFontCharacters](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedfontcharacters/) y dos sobrecargas del método [add_embedded_font](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/add_embedded_font/), puedes seleccionar la regla de incrustación que prefieras para agregar fuentes a una presentación. Este código Python muestra cómo incrustar y añadir fuentes a una presentación:

```python
import aspose.slides as slides

# Load a presentation.
with slides.Presentation("Fonts.pptx") as presentation:
    all_fonts = presentation.fonts_manager.get_fonts()
    embedded_fonts = presentation.fonts_manager.get_embedded_fonts()

    for font in all_fonts:
        if font not in embedded_fonts:
            presentation.fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)

    # Save the presentation to disk.
    presentation.save("AddEmbeddedFont.pptx", slides.export.SaveFormat.PPTX)
```

## **Comprimir fuentes incrustadas**

Optimiza el tamaño del archivo comprimiendo las fuentes incrustadas mediante [compress_embedded_fonts](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/).

Ejemplo de código para compresión:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Preguntas frecuentes**

**¿Cómo puedo saber si una fuente específica en la presentación seguirá siendo sustituida durante la renderización a pesar de estar incrustada?**

Consulte la [información de sustitución](/slides/es/python-net/font-substitution/) en el gestor de fuentes y las [reglas de reserva/sustitución](/slides/es/python-net/fallback-font/): si la fuente no está disponible o está restringida, se usará una alternativa.

**¿Vale la pena incrustar fuentes del "sistema" como Arial/Calibri?**

Normalmente no; casi siempre están disponibles. Pero para lograr una portabilidad total en entornos "ligeros" (Docker, un servidor Linux sin fuentes preinstaladas), incrustar fuentes del sistema puede eliminar el riesgo de sustituciones inesperadas.