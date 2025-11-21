---
title: Automatizar la localización de presentaciones en .NET
linktitle: Localización de presentaciones
type: docs
weight: 100
url: /es/net/presentation-localization/
keywords:
- cambiar idioma
- revisión ortográfica
- identificador de idioma
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Automatice la localización de diapositivas de PowerPoint y OpenDocument en .NET con Aspose.Slides, usando ejemplos de código C# prácticos y consejos para un despliegue global más rápido."
---

## **Cambiar el idioma para la presentación y el texto de la forma**
- Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Obtener la referencia de una diapositiva usando su índice.
- Agregar un AutoShape de tipo Rectangle a la diapositiva.
- Agregar texto al TextFrame.
- Establecer Language Id en el texto.
- Guardar la presentación como archivo PPTX.

La implementación de los pasos anteriores se muestra a continuación en un ejemplo.
```c#
using (Presentation pres = new Presentation("test0.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.AddTextFrame("Text to apply spellcheck language");
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId = "en-EN";

    pres.Save("test1.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Preguntas frecuentes**

**¿El Language Id activa la traducción automática del texto?**

No. [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) en Aspose.Slides almacena el idioma para la corrección ortográfica y la revisión gramatical, pero no traduce ni cambia el contenido del texto. Es metadatos que PowerPoint entiende para la revisión.

**¿El Language Id afecta la hyphenation y los saltos de línea durante el renderizado?**

En Aspose.Slides, [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) es para la revisión. La calidad de la hyphenation y el ajuste de línea dependen principalmente de la disponibilidad de [proper fonts](/slides/es/net/powerpoint-fonts/) y de la configuración de diseño/salto de línea para el sistema de escritura. Para garantizar un renderizado correcto, haga que las fuentes requeridas estén disponibles, configure [font substitution rules](/slides/es/net/font-substitution/), y/o [embed fonts](/slides/es/net/embedded-font/) en la presentación.

**¿Puedo establecer diferentes idiomas dentro de un solo párrafo?**

Sí. [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) se aplica a nivel de porción de texto, por lo que un solo párrafo puede mezclar varios idiomas con configuraciones de revisión distintas.