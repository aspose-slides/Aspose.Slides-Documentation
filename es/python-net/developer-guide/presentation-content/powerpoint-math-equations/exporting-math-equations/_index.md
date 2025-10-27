---
title: Export Math Equations from Presentations in Python
linktitle: Export Equations
type: docs
weight: 30
url: /es/python-net/exporting-math-equations/
keywords:
- export math equations
- MathML
- LaTeX
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Unlock seamless export of math equations from PowerPoint to MathML using Aspose.Slides for Python via .NET—preserve formatting and boost compatibility."
---

## **Introducción**

Aspose.Slides for Python via .NET permite exportar ecuaciones matemáticas de presentaciones. Por ejemplo, puede necesitar extraer ecuaciones de diapositivas específicas y reutilizarlas en otro programa o plataforma.

{{% alert color="primary" %}}

Puede exportar ecuaciones a MathML, un estándar ampliamente usado para representar contenido matemático en la web y en muchas aplicaciones.

{{% /alert %}}

## **Guardar ecuaciones matemáticas como MathML**

Aunque los seres humanos pueden escribir LaTeX con facilidad, MathML suele generarse automáticamente por aplicaciones. Dado que MathML está basado en XML, los programas pueden leerlo y analizarlo de forma fiable, por lo que se usa comúnmente como formato de salida e impresión en numerosos campos.

El siguiente código de ejemplo muestra cómo exportar una ecuación matemática de una presentación a MathML:

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

**¿Qué se exporta exactamente a MathML: un párrafo o un bloque de fórmula individual?**

Puede exportar tanto un párrafo matemático completo ([MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/)) como un bloque individual ([MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)) a MathML. Ambos tipos proporcionan un método para escribir en MathML.

**¿Cómo puedo identificar que un objeto en una diapositiva es una fórmula matemática y no texto normal o una imagen?**

Una fórmula reside en un [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) y tiene un [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/). Las imágenes y los fragmentos de texto normales sin un [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) no son fórmulas exportables.

**¿De dónde proviene el MathML en una presentación, es específico de PowerPoint o es un estándar?**

La exportación se dirige al MathML estándar (XML). Aspose utiliza Presentation MathML, el subconjunto de presentación del estándar, que está ampliamente usado en aplicaciones y en la web.

**¿Se admite la exportación de fórmulas dentro de tablas, SmartArt, grupos, etc.?**

Sí, si esos objetos contienen fragmentos de texto con un [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) (es decir, fórmulas reales de PowerPoint), se exportan. Si una fórmula está incrustada como imagen, no se exporta.

**¿La exportación a MathML modifica la presentación original?**

No. Escribir MathML es una serialización del contenido de la fórmula; no modifica el archivo de la presentación.