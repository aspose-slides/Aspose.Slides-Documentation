---
title: Gestionar superíndice y subíndice en C#
linktitle: Superíndice y Subíndice
type: docs
weight: 80
url: /es/net/superscript-and-subscript/
keywords:
- superíndice
- subíndice
- agregar superíndice
- agregar subíndice
- PowerPoint
- OpenDocument
- presentación
- C#
- Csharp
- Aspose.Slides
description: "Domine el superíndice y el subíndice en Aspose.Slides para .NET y eleve sus presentaciones con un formato de texto profesional para lograr el máximo impacto."
---

## **Descripción general**

Aspose.Slides for .NET ofrece funciones para integrar texto en superíndice y subíndice en sus presentaciones de PowerPoint (PPT, PPTX) y OpenDocument (ODP). Ya sea que necesite resaltar fórmulas químicas, ecuaciones matemáticas o anotar contenido con notas al pie, estas opciones de formato especial ayudan a mantener la claridad y precisión. En este artículo, aprenderá cómo aplicar de forma fluida los estilos de superíndice y subíndice y garantizar resultados profesionales en cada diapositiva.

## **Agregar texto en superíndice y subíndice**

Puede agregar texto en superíndice y subíndice dentro de cualquier párrafo de una presentación. Para lograrlo con Aspose.Slides, debe usar la propiedad `Escapement` de la clase [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) .

Esta propiedad permite establecer texto en superíndice o subíndice, con valores que van desde -100 % (subíndice) hasta 100 % (superíndice).

Pasos de implementación:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
1. Obtener una referencia a una diapositiva mediante su índice.
1. Agregar un [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) de tipo `Rectangle` a la diapositiva.
1. Acceder al [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) asociado con el [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) .
1. Eliminar los párrafos existentes.
1. Crear un nuevo [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) para texto en superíndice y agregarlo a la colección de párrafos del [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) .
1. Crear un nuevo objeto de porción de texto.
1. Establecer la propiedad `Escapement` de la porción de texto entre 0 y 100 para aplicar superíndice (0 significa sin superíndice).
1. Asignar texto a la [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/) y agregarlo a la colección de porciones del párrafo.
1. Crear otro [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) para texto en subíndice y agregarlo a la colección de párrafos.
1. Crear un nuevo objeto de porción de texto.
1. Establecer la propiedad `Escapement` de la porción de texto entre 0 y -100 para aplicar subíndice (0 significa sin subíndice).
1. Asignar texto a la [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/) y agregarlo a la colección de porciones del párrafo.
1. Guardar la presentación como un archivo PPTX.

El siguiente código C# implementa estos pasos:
```c#
using (Presentation presentation = new Presentation())
{
    // Obtener la primera diapositiva.
    ISlide slide = presentation.Slides[0];

    // Crear un cuadro de texto.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.TextFrame;

    textFrame.Paragraphs.Clear();

    // Crear un párrafo para texto en superíndice.
    IParagraph superPar = new Paragraph();

    // Crear una porción de texto con texto normal.
    IPortion portion1 = new Portion();
    portion1.Text = "MyProduct";
    superPar.Portions.Add(portion1);

    // Crear una porción de texto con superíndice.
    IPortion superPortion = new Portion();
    superPortion.PortionFormat.Escapement = 30;
    superPortion.Text = "TM";
    superPar.Portions.Add(superPortion);

    // Crear un párrafo para texto en subíndice.
    IParagraph paragraph2 = new Paragraph();

    // Crear una porción de texto con texto normal.
    IPortion portion2 = new Portion();
    portion2.Text = "a";
    paragraph2.Portions.Add(portion2);

    // Crear una porción de texto con subíndice.
    IPortion subPortion = new Portion();
    subPortion.PortionFormat.Escapement = -25;
    subPortion.Text = "i";
    paragraph2.Portions.Add(subPortion);

    // Añadir los párrafos al cuadro de texto.
    textFrame.Paragraphs.Add(superPar);
    textFrame.Paragraphs.Add(paragraph2);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


El resultado:

![Superíndice y subíndice](superscript_and_subscript.png)

## **Preguntas frecuentes**

**¿Se conserva el superíndice y subíndice al exportar a PDF u otros formatos?**

Sí, Aspose.Slides for .NET mantiene correctamente el formato de superíndice y subíndice al exportar presentaciones a PDF, PPT/PPTX, imágenes y otros formatos compatibles. El formato especializado permanece intacto en todos los archivos de salida.

**¿Se pueden combinar el superíndice y subíndice con otros estilos de formato como negrita o cursiva?**

Sí, Aspose.Slides permite mezclar varios estilos de texto dentro de una sola porción. Puede habilitar negrita, cursiva, subrayado y, simultáneamente, aplicar superíndice o subíndice configurando las propiedades correspondientes en [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) .

**¿El formato de superíndice y subíndice funciona para texto dentro de tablas, gráficos o SmartArt?**

Sí, Aspose.Slides for .NET admite el formato dentro de la mayoría de los objetos, incluidas tablas y elementos de gráficos. Al trabajar con SmartArt, necesita acceder a los elementos apropiados (como [SmartArtNode](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartnode/)) y sus contenedores de texto, y luego configurar las propiedades de [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) de manera similar.