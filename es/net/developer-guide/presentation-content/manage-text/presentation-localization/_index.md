---
title: Localización de Presentaciones
type: docs
weight: 100
url: /net/presentation-localization/
keywords: "Cambiar idioma, Revisa ortografía, Comprobar ortografía, Corrector ortográfico, Presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Cambiar o verificar el idioma en una presentación de PowerPoint. Comprobar ortografía en C# o .NET"
---
## **Cambiar Idioma para el Texto de la Presentación y de las Formas**
- Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Obtener la referencia de una diapositiva utilizando su índice.
- Agregar una AutoShape de tipo Rectángulo a la diapositiva.
- Agregar algún texto al TextFrame.
- Establecer el Id de Idioma al texto.
- Escribir la presentación como un archivo PPTX.

La implementación de los pasos anteriores se demuestra a continuación en un ejemplo.

```c#
using (Presentation pres = new Presentation("test0.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.AddTextFrame("Texto para aplicar el idioma del corrector ortográfico");
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId = "en-EN";

    pres.Save("test1.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```