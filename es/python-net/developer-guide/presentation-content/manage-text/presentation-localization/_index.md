---
title: Automatizar la localización de presentaciones con Python
linktitle: Localización de presentaciones
type: docs
weight: 100
url: /es/python-net/presentation-localization/
keywords:
- cambiar idioma
- corrector ortográfico
- identificador de idioma
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Automatiza la localización de diapositivas PowerPoint y OpenDocument en Python con Aspose.Slides, utilizando ejemplos de código prácticos y consejos para un despliegue global más rápido."
---

## **Cambiar el idioma del texto de la presentación y de la forma**
- Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
- Obtener la referencia de una diapositiva usando su Índice.
- Añadir un AutoShape de tipo Rectángulo a la diapositiva.
- Añadir texto al TextFrame.
- Establecer el Language Id en el texto.
- Guardar la presentación como archivo PPTX.

La implementación de los pasos anteriores se muestra a continuación en un ejemplo.
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)
    shape.add_text_frame("Text to apply spellcheck language")
    shape.text_frame.paragraphs[0].portions[0].portion_format.language_id = "en-EN"

    pres.save("test1.pptx", slides.export.SaveFormat.PPTX)
```


## **Preguntas frecuentes**

**¿El Language ID activa la traducción automática del texto?**

No. [language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) en Aspose.Slides almacena el idioma para la corrección ortográfica y la prueba gramatical, pero no traduce ni modifica el contenido del texto. Es metadatos que PowerPoint entiende para la revisión.

**¿Afecta el Language ID a la separación silábica y los saltos de línea durante el renderizado?**

En Aspose.Slides, [language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) se utiliza para la revisión. La calidad de la separación silábica y el ajuste de líneas dependen principalmente de la disponibilidad de [fuentes adecuadas](/slides/es/python-net/powerpoint-fonts/) y de la configuración de diseño/saltos de línea para el sistema de escritura. Para garantizar un renderizado correcto, asegúrese de que las fuentes necesarias estén disponibles, configure [reglas de sustitución de fuentes](/slides/es/python-net/font-substitution/) y/o [incorpore fuentes](/slides/es/python-net/embedded-font/) en la presentación.

**¿Puedo establecer diferentes idiomas dentro de un mismo párrafo?**

Sí. [language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) se aplica a nivel de porción de texto, por lo que un solo párrafo puede combinar varios idiomas con configuraciones de revisión distintas.