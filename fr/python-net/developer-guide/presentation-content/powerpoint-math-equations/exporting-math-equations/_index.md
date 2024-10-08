---
title: Exportation d'équations mathématiques
type: docs
weight: 30
url: /fr/python-net/exporting-math-equations/
keywords: "Exporter des équations mathématiques, présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Exporter des équations mathématiques PowerPoint en Python"
---

Aspose.Slides pour Python via .NET vous permet d'exporter des équations mathématiques à partir de présentations. Par exemple, vous pourriez avoir besoin d'extraire les équations mathématiques sur les diapositives (d'une présentation spécifique) et de les utiliser dans un autre programme ou plateforme.

{{% alert color="primary" %}} 

Vous pouvez exporter des équations au format MathML, un format ou standard populaire pour les équations mathématiques et un contenu similaire que l'on trouve sur le web et dans de nombreuses applications.

{{% /alert %}}

Bien que les humains écrivent facilement le code pour certains formats d'équations comme LaTeX, ils ont du mal à écrire le code pour MathML car ce dernier est destiné à être généré automatiquement par des applications. Les programmes lisent et analysent facilement MathML car son code est en XML, donc MathML est couramment utilisé comme format de sortie et d'impression dans de nombreux domaines.

Ce code d'exemple vous montre comment exporter une équation mathématique d'une présentation vers MathML :

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