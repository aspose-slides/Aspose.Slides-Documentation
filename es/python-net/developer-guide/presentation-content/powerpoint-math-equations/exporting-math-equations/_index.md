---
title: Exportar ecuaciones matemáticas de presentaciones en Python
linktitle: Exportar ecuaciones
type: docs
weight: 30
url: /es/python-net/exporting-math-equations/
keywords:
- exportar ecuaciones matemáticas
- MathML
- LaTeX
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Desbloquee la exportación sin problemas de ecuaciones matemáticas de PowerPoint a MathML con Aspose.Slides para Python vía .NET—preserve el formato y mejore la compatibilidad."
---

## **Introducción**

Aspose.Slides for Python via .NET le permite exportar ecuaciones matemáticas de presentaciones. Por ejemplo, puede necesitar extraer ecuaciones de diapositivas específicas y reutilizarlas en otro programa o plataforma.

{{% alert color="primary" %}}
Puede exportar ecuaciones a MathML, un estándar muy utilizado para representar contenido matemático en la web y en muchas aplicaciones.
{{% /alert %}}

## **Guardar ecuaciones matemáticas como MathML**

Aunque los humanos pueden escribir LaTeX con facilidad, MathML suele generarse automáticamente por aplicaciones. Como MathML se basa en XML, los programas pueden leerlo y analizarlo de forma fiable, por lo que se usa frecuentemente como formato de salida e impresión en numerosos campos.

El siguiente ejemplo de código muestra cómo exportar una ecuación matemática de una presentación a MathML:

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_math_shape(0, 0, 500, 50)
    math_paragraph = auto_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    math_paragraph.add(
        math.MathematicalText("a").
            set_superscript("2").
            join("+").
            join(math.MathematicalText("b").set_superscript("2")).
            join("=").
            join(math.MathematicalText("c").set_superscript("2")))

    with open("mathml.xml", "wb") as file_stream:
        math_paragraph.write_as_math_ml(file_stream)
```

## **Preguntas frecuentes**

**¿Qué se exporta exactamente a MathML, un párrafo o un bloque de fórmula individual?**

Puede exportar tanto un párrafo completo de matemáticas ([MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/)) como un bloque individual ([MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)) a MathML. Ambos tipos proporcionan un método para escribir en MathML.

**¿Cómo puedo saber que un objeto en una diapositiva es una fórmula matemática y no texto regular o una imagen?**

Una fórmula reside en un [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) y tiene un [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/). Las imágenes y los fragmentos de texto regular sin un [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) no son fórmulas exportables.

**¿De dónde proviene el MathML en una presentación, es específico de PowerPoint o es un estándar?**

La exportación está dirigida al MathML estándar (XML). Aspose utiliza Presentation MathML—el subconjunto de presentación del estándar—que está ampliamente usado en aplicaciones y en la web.

**¿Se admite la exportación de fórmulas dentro de tablas, SmartArt, grupos, etc.?**

Sí, si esos objetos contienen fragmentos de texto con un [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) (es decir, fórmulas genuinas de PowerPoint), se exportan. Si una fórmula está incrustada como una imagen, no lo está.

**¿Exportar a MathML modifica la presentación original?**

No. Escribir MathML es una serialización del contenido de la fórmula; no modifica el archivo de la presentación.