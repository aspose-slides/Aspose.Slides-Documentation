---
title: Exportieren von mathematischen Gleichungen
type: docs
weight: 30
url: /python-net/exporting-math-equations/
keywords: "Mathematische Gleichungen exportieren, PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Exportieren von PowerPoint mathematischen Gleichungen in Python"
---

Aspose.Slides für Python über .NET ermöglicht es Ihnen, mathematische Gleichungen aus Präsentationen zu exportieren. Beispielsweise müssen Sie möglicherweise die mathematischen Gleichungen auf Folien (aus einer bestimmten Präsentation) extrahieren und in einem anderen Programm oder auf einer anderen Plattform verwenden. 

{{% alert color="primary" %}} 

Sie können Gleichungen nach MathML exportieren, einem beliebten Format oder Standard für mathematische Gleichungen und ähnliche Inhalte, die im Internet und in vielen Anwendungen zu sehen sind. 

{{% /alert %}}

Während Menschen den Code für einige Gleichungsformate wie LaTeX leicht schreiben, haben sie Schwierigkeiten, den Code für MathML zu schreiben, da letzteres automatisch von Apps generiert werden soll. Programme lesen und parsen MathML leicht, da der Code in XML vorliegt, weshalb MathML häufig als Ausgabe- und Druckformat in vielen Bereichen verwendet wird. 

Dieser Beispielcode zeigt Ihnen, wie Sie eine mathematische Gleichung aus einer Präsentation nach MathML exportieren:

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