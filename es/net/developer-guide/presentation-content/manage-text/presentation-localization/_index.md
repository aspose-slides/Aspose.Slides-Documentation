---
title: Localización de la presentación
type: docs
weight: 100
url: /es/net/presentation-localization/
keywords: "Cambiar idioma, Corrector ortográfico, Revisión ortográfica, Corrector de ortografía, Presentación PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Cambiar o comprobar el idioma en una presentación PowerPoint. Corrector ortográfico de texto en C# o .NET"
---

## **Cambiar el idioma del texto de la presentación y de la forma**
- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Obtenga la referencia de una diapositiva usando su índice.
- Agregue una AutoShape de tipo Rectángulo a la diapositiva.
- Añada texto al TextFrame.
- Establezca el Language Id al texto.
- Guarde la presentación como un archivo PPTX.

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

**¿language_id activa la traducción automática de texto?**

No. [language_id](https://reference.aspose.com/slides/net/aspose.slides/portionformat/languageid/) en Aspose.Slides almacena el idioma para la corrección ortográfica y la revisión gramatical, pero no traduce ni cambia el contenido del texto. Es metadatos que PowerPoint reconoce para la revisión.

**¿language_id afecta la hyphenation y los saltos de línea durante la renderización?**

En Aspose.Slides, [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) se utiliza para la revisión. La calidad de la hyphenation y el ajuste de líneas dependen principalmente de la disponibilidad de [proper fonts](/slides/es/net/powerpoint-fonts/) y de la configuración de diseño/saltos de línea para el sistema de escritura. Para garantizar una renderización correcta, haga que las fuentes requeridas estén disponibles, configure las [font substitution rules](/slides/es/net/font-substitution/) y/o [embed fonts](/slides/es/net/embedded-font/) en la presentación.

**¿Puedo establecer diferentes idiomas dentro de un solo párrafo?**

Sí. [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) se aplica a nivel de porción de texto, por lo que un solo párrafo puede mezclar varios idiomas con configuraciones de revisión distintas.