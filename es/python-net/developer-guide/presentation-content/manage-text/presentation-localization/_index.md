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
description: "Automatiza la localización de diapositivas de PowerPoint y OpenDocument en Python con Aspose.Slides, utilizando ejemplos de código prácticos y consejos para un despliegue global más rápido."
---

## **Cambiar idioma para la presentación y el texto de las formas**
- Crea una instancia de la clase[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
- Obtén la referencia de una diapositiva usando su índice.
- Agrega un AutoShape de tipo Rectángulo a la diapositiva.
- Añade texto al TextFrame.
- Estableciendo Language Id al texto.
- Guarda la presentación como un archivo PPTX.

The implementation of the above steps is demonstrated below in an example.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)
    shape.add_text_frame("Text to apply spellcheck language")
    shape.text_frame.paragraphs[0].portions[0].portion_format.language_id = "en-EN"

    pres.save("test1.pptx", slides.export.SaveFormat.PPTX)
```

## **Preguntas frecuentes**

**¿language_id activa la traducción automática del texto?**

No. [language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) en Aspose.Slides almacena el idioma para la corrección ortográfica y la revisión gramatical, pero no traduce ni modifica el contenido del texto. Es metadatos que PowerPoint entiende para la revisión.

**¿language_id afecta la separación en sílabas y los saltos de línea durante el renderizado?**

En Aspose.Slides, [language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) se utiliza para la revisión. La calidad de la separación en sílabas y el ajuste de línea dependen principalmente de la disponibilidad de [fuentes adecuadas](/slides/es/python-net/powerpoint-fonts/) y de la configuración de diseño / saltos de línea para el sistema de escritura. Para garantizar un renderizado correcto, proporciona las fuentes necesarias, configura las [reglas de sustitución de fuentes](/slides/es/python-net/font-substitution/) y/o [incorpora fuentes](/slides/es/python-net/embedded-font/) en la presentación.

**¿Puedo establecer diferentes idiomas dentro de un solo párrafo?**

Sí. [language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) se aplica a nivel de porción de texto, por lo que un solo párrafo puede mezclar varios idiomas con configuraciones de revisión distintas.