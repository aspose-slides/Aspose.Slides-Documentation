---
title: Exportar ecuaciones matemáticas desde presentaciones en .NET
linktitle: Exportar ecuaciones
type: docs
weight: 30
url: /es/net/exporting-math-equations/
keywords:
- exportar ecuaciones matemáticas
- MathML
- LaTeX
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Desbloquee la exportación sin problemas de ecuaciones matemáticas de PowerPoint a MathML con Aspose.Slides para .NET: preserve el formato y mejore la compatibilidad."
---

## **Introducción**

Aspose.Slides for .NET le permite exportar ecuaciones matemáticas desde presentaciones. Por ejemplo, puede necesitar extraer las ecuaciones matemáticas en las diapositivas (de una presentación específica) y utilizarlas en otro programa o plataforma. 

{{% alert color="primary" %}} 
Puede exportar ecuaciones a MathML, un formato o estándar popular para ecuaciones matemáticas y contenido similar que se ve en la web y en muchas aplicaciones. 
{{% /alert %}}

## **Guardar ecuaciones matemáticas como MathML**

Aunque los humanos escriben fácilmente el código para algunos formatos de ecuación como LaTeX, les cuesta escribir el código para MathML porque este último está pensado para ser generado automáticamente por aplicaciones. Los programas leen y analizan MathML fácilmente porque su código está en XML, por lo que MathML se usa comúnmente como formato de salida e impresión en muchos campos. 

Este fragmento de código muestra cómo exportar una ecuación matemática desde una presentación a MathML:
```c#
using (Presentation pres = new Presentation())
        {
            var autoShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);
            var mathParagraph = ((MathPortion)autoShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            mathParagraph.Add(new MathematicalText("a").SetSuperscript("2").Join("+").Join(new MathematicalText("b").SetSuperscript("2")).Join("=").Join(new MathematicalText("c").SetSuperscript("2")));

       using (Stream stream = new FileStream("mathml.xml", FileMode.Create))
                mathParagraph.WriteAsMathMl(stream);
        }
```


## **FAQ**

**¿Qué se exporta exactamente a MathML: un párrafo o un bloque de fórmula individual?**

Puede exportar ya sea un párrafo matemático completo ([MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/)) o un bloque individual ([MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock/)) a MathML. Ambos tipos proporcionan un método para escribir a MathML.

**¿Cómo puedo saber si un objeto en una diapositiva es una fórmula matemática en lugar de texto regular o una imagen?**

Una fórmula se encuentra en una [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) y tiene un [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/). Las imágenes y las porciones de texto regular sin un [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) no son fórmulas exportables.

**¿De dónde proviene el MathML en una presentación: es específico de PowerPoint o es un estándar?**

La exportación tiene como objetivo MathML estándar (XML). Aspose usa Presentation MathML, el subconjunto de presentación del estándar, que se utiliza ampliamente en aplicaciones y en la web.

**¿Se admite la exportación de fórmulas dentro de tablas, SmartArt, grupos, etc.?**

Sí, si esos objetos contienen porciones de texto con un [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) (es decir, fórmulas auténticas de PowerPoint), se exportan. Si una fórmula está incrustada como una imagen, no lo está.

**¿La exportación a MathML modifica la presentación original?**

No. Escribir MathML es una serialización del contenido de la fórmula; no modifica el archivo de la presentación.