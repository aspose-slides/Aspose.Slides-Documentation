---
title: Automatizar la localización de presentaciones en C++
linktitle: Localización de presentaciones
type: docs
weight: 100
url: /es/cpp/presentation-localization/
keywords:
- cambiar idioma
- corrección ortográfica
- identificador de idioma
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Automatiza la localización de diapositivas PowerPoint y OpenDocument en C++ con Aspose.Slides, usando ejemplos de código prácticos y consejos para un despliegue global más rápido."
---

## **Cambiar el idioma para una presentación y texto de forma**
- Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
- Obtener la referencia de una diapositiva usando su índice.
- Agregar una AutoShape de tipo Rectángulo a la diapositiva.
- Agregar texto al TextFrame.
- Establecer Language Id en el texto.
- Guardar la presentación como archivo PPTX.

La implementación de los pasos anteriores se muestra a continuación en un ejemplo.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-TextBoxOnSlideProgram-TextBoxOnSlideProgram.cpp" >}}

## **Preguntas frecuentes**

**¿El Language ID activa la traducción automática del texto?**

No. [Language ID](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/) en Aspose.Slides almacena el idioma para la revisión ortográfica y la corrección gramatical, pero no traduce ni cambia el contenido del texto. Es metadatos que PowerPoint entiende para la revisión.

**¿El Language ID afecta la separación silábica y los saltos de línea durante la renderización?**

En Aspose.Slides, [Language ID](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/) es para la revisión. La calidad de la separación silábica y el ajuste de líneas dependen principalmente de la disponibilidad de [fuentes adecuadas](/slides/es/cpp/powerpoint-fonts/) y de la configuración de diseño/saltos de línea para el sistema de escritura. Para garantizar una renderización correcta, haga que las fuentes necesarias estén disponibles, configure las [reglas de sustitución de fuentes](/slides/es/cpp/font-substitution/) y/o [incorpore fuentes](/slides/es/cpp/embedded-font/) en la presentación.

**¿Puedo establecer diferentes idiomas dentro de un mismo párrafo?**

Sí. [Language ID](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/) se aplica a nivel de porción de texto, por lo que un solo párrafo puede combinar varios idiomas con configuraciones de revisión distintas.