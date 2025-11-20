---
title: Mathematische Gleichungen aus Präsentationen in Python exportieren
linktitle: Gleichungen exportieren
type: docs
weight: 30
url: /de/python-net/exporting-math-equations/
keywords:
- Mathematische Gleichungen exportieren
- MathML
- LaTeX
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Ermöglichen Sie den nahtlosen Export mathematischer Gleichungen von PowerPoint nach MathML mit Aspose.Slides für Python via .NET - erhalten Sie die Formatierung und steigern Sie die Kompatibilität."
---

## **Einführung**

Aspose.Slides for Python via .NET ermöglicht das Exportieren mathematischer Gleichungen aus Präsentationen. Beispielsweise müssen Sie Gleichungen aus bestimmten Folien extrahieren und in einem anderen Programm oder einer anderen Plattform wiederverwenden.

{{% alert color="primary" %}}
Sie können Gleichungen in MathML exportieren, einen weit verbreiteten Standard zur Darstellung mathematischer Inhalte im Web und in vielen Anwendungen.
{{% /alert %}}

## **Math‑Gleichungen als MathML speichern**

Obwohl Menschen LaTeX leicht schreiben können, wird MathML in der Regel automatisch von Anwendungen erzeugt. Da MathML XML‑basiert ist, können Programme es zuverlässig lesen und analysieren; deshalb wird es in vielen Bereichen als Ausgabe‑ und Druckformat verwendet.

Der folgende Beispielcode zeigt, wie eine mathematische Gleichung aus einer Präsentation in MathML exportiert wird:
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


## **FAQ**

**Was genau wird nach MathML exportiert – ein Absatz oder ein einzelner Formelblock?**

Sie können entweder einen gesamten mathematischen Absatz ([MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/)) oder einen einzelnen Block ([MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)) nach MathML exportieren. Beide Typen bieten eine Methode zum Schreiben nach MathML.

**Wie erkenne ich, dass ein Objekt auf einer Folie eine mathematische Formel und kein normaler Text oder Bild ist?**

Eine Formel befindet sich in einem [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) und besitzt einen [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/). Bilder und normale Textbereiche ohne einen [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) sind keine exportierbaren Formeln.

**Woher stammt das MathML in einer Präsentation – ist es PowerPoint‑spezifisch oder ein Standard?**

Der Export richtet sich an das standardisierte MathML (XML). Aspose verwendet Presentation MathML – die Präsentations‑Teilmenge des Standards –, die in vielen Anwendungen und im Web verbreitet ist.

**Wird das Exportieren von Formeln in Tabellen, SmartArt, Gruppen usw. unterstützt?**

Ja, wenn diese Objekte Textbereiche mit einem [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) enthalten (also echte PowerPoint‑Formeln), werden sie exportiert. Ist eine Formel als Bild eingebettet, wird sie nicht exportiert.

**Verändert das Exportieren nach MathML die ursprüngliche Präsentation?**

Nein. Das Schreiben von MathML ist eine Serialisierung des Inhalts der Formel; sie verändert die Präsentationsdatei nicht.