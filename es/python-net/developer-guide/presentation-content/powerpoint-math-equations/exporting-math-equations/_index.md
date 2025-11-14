---
title: Exportando Ecuaciones Matemáticas
type: docs
weight: 30
url: /es/python-net/exporting-math-equations/
keywords: "Exportar ecuaciones matemáticas, presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Exportar ecuaciones matemáticas de PowerPoint en Python"
---

Aspose.Slides para Python a través de .NET te permite exportar ecuaciones matemáticas de presentaciones. Por ejemplo, puede que necesites extraer las ecuaciones matemáticas de las diapositivas (de una presentación específica) y utilizarlas en otro programa o plataforma.

{{% alert color="primary" %}} 

Puedes exportar ecuaciones a MathML, un formato o estándar popular para ecuaciones matemáticas y contenido similar visto en la web y en muchas aplicaciones. 

{{% /alert %}}

Mientras que los humanos escriben fácilmente el código para algunos formatos de ecuaciones como LaTeX, les cuesta escribir el código para MathML porque este último está destinado a ser generado automáticamente por aplicaciones. Los programas leen y analizan MathML fácilmente porque su código está en XML, por lo que MathML se utiliza comúnmente como un formato de salida e impresión en muchos campos.

Este código de ejemplo te muestra cómo exportar una ecuación matemática de una presentación a MathML:

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as pres:
    autoShape = pres.slides[0].shapes.add_math_shape(0, 0, 500, 50)
    mathParagraph = autoShape.text_frame.paragraphs[0].portions[0].math_paragraph

    mathParagraph.add(
        math.MathematicalText("a").
            set_superscript("2").
            join("+").
            join(math.MathematicalText("b").set_superscript("2")).
            join("=").
            join(math.MathematicalText("c").set_superscript("2")))

    with open("mathml.xml", "wb") as stream:
        mathParagraph.write_as_math_ml(stream)
```