---
title: Superíndice y Subíndice
type: docs
weight: 80
url: /es/net/superscript-and-subscript/
keywords: "Superíndice, Subíndice, Agregar texto en superíndice, Agregar texto en subíndice, Presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Agregar texto en superíndice y subíndice a presentaciones de PowerPoint en C# o .NET"
---

## **Gestionar Texto en Superíndice y Subíndice**
Puedes agregar texto en superíndice y subíndice dentro de cualquier porción de un párrafo. Para agregar texto en superíndice o subíndice en el marco de texto de Aspose.Slides, se deben utilizar las propiedades **de Escapement** de la clase PortionFormat.

Esta propiedad devuelve o establece el texto en superíndice o subíndice (valor de -100% (subíndice) a 100% (superíndice). Por ejemplo:

- Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Obtener la referencia de una diapositiva utilizando su índice.
- Agregar una IAutoShape de tipo Rectángulo a la diapositiva.
- Acceder al ITextFrame asociado con el IAutoShape.
- Limpiar los párrafos existentes.
- Crear un nuevo objeto de párrafo para contener el texto en superíndice y agregarlo a la colección IParagraphs del ITextFrame.
- Crear un nuevo objeto de porción.
- Establecer la propiedad Escapement para la porción entre 0 y 100 para agregar superíndice. (0 significa sin superíndice).
- Establecer algún texto para la Porción y luego agregarlo a la colección de porciones del párrafo.
- Crear un nuevo objeto de párrafo para contener el texto en subíndice y agregarlo a la colección IParagraphs del ITextFrame.
- Crear un nuevo objeto de porción.
- Establecer la propiedad Escapement para la porción entre 0 y -100 para agregar subíndice. (0 significa sin subíndice).
- Establecer algún texto para la Porción y luego agregarlo a la colección de porciones del párrafo.
- Guardar la presentación como un archivo PPTX.

La implementación de los pasos anteriores se da a continuación.

```c#
using (Presentation presentation = new Presentation("test.pptx"))
{
    // Obtener diapositiva
    ISlide slide = presentation.Slides[0];

    // Crear cuadro de texto
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.TextFrame;
    textFrame.Paragraphs.Clear();

    // Crear párrafo para texto en superíndice
    IParagraph superPar = new Paragraph();

    // Crear porción con texto normal
    IPortion portion1 = new Portion();
    portion1.Text = "SlideTitle";
    superPar.Portions.Add(portion1);

    // Crear porción con texto en superíndice
    IPortion superPortion = new Portion();
    superPortion.PortionFormat.Escapement = 30;
    superPortion.Text = "TM";
    superPar.Portions.Add(superPortion);

    // Crear párrafo para texto en subíndice
    IParagraph paragraph2 = new Paragraph();

    // Crear porción con texto normal
    IPortion portion2 = new Portion();
    portion2.Text = "a";
    paragraph2.Portions.Add(portion2);

    // Crear porción con texto en subíndice
    IPortion subPortion = new Portion();
    subPortion.PortionFormat.Escapement = -25;
    subPortion.Text = "i";
    paragraph2.Portions.Add(subPortion);

    // Agregar párrafos al cuadro de texto
    textFrame.Paragraphs.Add(superPar);
    textFrame.Paragraphs.Add(paragraph2);

    presentation.Save("TestOut.pptx", SaveFormat.Pptx);
    System.Diagnostics.Process.Start("TestOut.pptx");
 } 
```