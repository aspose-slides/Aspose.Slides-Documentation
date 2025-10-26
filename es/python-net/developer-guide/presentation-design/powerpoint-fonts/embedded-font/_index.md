---
title: Incorporar fuentes en presentaciones con Python
linktitle: Incorporación de fuente
type: docs
weight: 40
url: /es/python-net/developer-guide/presentation-design/powerpoint-fonts/embedded-font/
keywords:
- añadir fuente
- incrustar fuente
- incrustación de fuente
- obtener fuente incrustada
- añadir fuente incrustada
- eliminar fuente incrustada
- comprimir fuente incrustada
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Incruste fuentes TrueType en presentaciones de PowerPoint y OpenDocument con Aspose.Slides para Python a través de .NET, garantizando una renderización precisa en todas las plataformas."
---

## **Descripción general**

**Incrustar fuentes en PowerPoint** asegura que su presentación mantenga su apariencia prevista en diferentes sistemas. Ya sea que utilice fuentes únicas por creatividad o fuentes estándar, la incrustación evita la alteración del texto y el diseño.

Si utilizó una fuente de terceros o no estándar porque se volvió creativo con su trabajo, entonces tiene aún más razones para incrustar esa fuente. De lo contrario (sin fuentes incrustadas), los textos o números en sus diapositivas, el diseño, el estilo, etc., pueden cambiar o convertirse en rectángulos confusos.

Utilice las clases [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/), [FontData](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/) y [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) para administrar fuentes incrustadas.

## **Obtener y eliminar fuentes incrustadas**

Recupere o elimine fuentes incrustadas de una presentación de forma sencilla con los métodos [get_embedded_fonts](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) y [remove_embedded_font](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/remove_embedded_font/).

Este código Python le muestra cómo obtener y eliminar fuentes incrustadas de una presentación:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanciar la clase Presentation que representa un archivo de presentación.
with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slide = presentation.slides[0]

    # Renderizar la diapositiva que contiene un marco de texto que usa la fuente incrustada 'FunSized'.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture1_out.png", slides.ImageFormat.PNG)

    fonts_manager = presentation.fonts_manager

    # Obtener todas las fuentes incrustadas.
    embedded_fonts = fonts_manager.get_embedded_fonts()

    # Encontrar la fuente 'Calibri'.
    font_data = list(filter(lambda data : data.font_name == "Calibri", embedded_fonts))[0]

    # Eliminar la fuente 'Calibri'.
    fonts_manager.remove_embedded_font(font_data)

    # Renderizar la diapositiva; la fuente 'Calibri' será reemplazada por una existente.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture2_out.png", slides.ImageFormat.PNG)

    # Guardar la presentación sin la fuente incrustada 'Calibri' en disco.
    presentation.save("WithoutEmbeddedFonts.ppt", slides.export.SaveFormat.PPT)
```

## **Añadir fuentes incrustadas**

Utilizando el enumerado [EmbedFontCharacters](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedfontcharacters/) y dos sobrecargas del método [add_embedded_font](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/add_embedded_font/), puede seleccionar la regla (de incrustación) que prefiera para incrustar fuentes en una presentación. Este código Python le muestra cómo incrustar y añadir fuentes a una presentación:

```python
import aspose.slides as slides

# Cargar una presentación.
with slides.Presentation("Fonts.pptx") as presentation:
    all_fonts = presentation.fonts_manager.get_fonts()
    embedded_fonts = presentation.fonts_manager.get_embedded_fonts()

    for font in all_fonts:
        if font not in embedded_fonts:
            presentation.fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)

    # Guardar la presentación en disco.
    presentation.save("AddEmbeddedFont.pptx", slides.export.SaveFormat.PPTX)
```

## **Comprimir fuentes incrustadas**

Optimice el tamaño del archivo comprimiendo fuentes incrustadas mediante [compress_embedded_fonts](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/).

Ejemplo de código para la compresión:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Preguntas frecuentes**

**¿Cómo puedo saber si una fuente específica en la presentación será sustituida durante la renderización a pesar de estar incrustada?**

Consulte la [información de sustitución](/slides/es/python-net/font-substitution/) en el administrador de fuentes y las [reglas de reserva/sustitución](/slides/es/python-net/fallback-font/): si la fuente no está disponible o está restringida, se utilizará una fuente de reserva.

**¿Vale la pena incrustar fuentes “del sistema” como Arial/Calibri?**

Normalmente no, ya que casi siempre están disponibles. Pero para una portabilidad total en entornos “ligeros” (Docker, un servidor Linux sin fuentes preinstaladas), incrustar fuentes del sistema puede eliminar el riesgo de sustituciones inesperadas.