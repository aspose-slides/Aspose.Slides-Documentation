---
title: Exportieren von mathematischen Gleichungen aus Präsentationen in Python
linktitle: Gleichungen exportieren
type: docs
weight: 30
url: /de/python-net/exporting-math-equations/
keywords:
- mathematische Gleichungen exportieren
- MathML
- LaTeX
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Ermöglichen Sie einen nahtlosen Export mathematischer Gleichungen von PowerPoint nach MathML mit Aspose.Slides für Python via .NET – erhalten Sie die Formatierung und steigern Sie die Kompatibilität."
---

## **Einleitung**

Aspose.Slides für Python via .NET ermöglicht das Exportieren mathematischer Gleichungen aus Präsentationen. Beispielsweise müssen Sie möglicherweise Gleichungen aus bestimmten Folien extrahieren und in einem anderen Programm oder einer anderen Plattform wiederverwenden.

{{% alert color="primary" %}}

Sie können Gleichungen nach MathML exportieren, einem weit verbreiteten Standard zur Darstellung mathematischer Inhalte im Web und in vielen Anwendungen.

{{% /alert %}}

## **Mathematische Gleichungen als MathML speichern**

Obwohl Menschen LaTeX leicht schreiben können, wird MathML in der Regel automatisch von Anwendungen erzeugt. Da MathML XML-basiert ist, können Programme es zuverlässig lesen und parsen, weshalb es in vielen Bereichen häufig als Ausgab- und Druckformat verwendet wird.

Der folgende Beispielcode zeigt, wie eine mathematische Gleichung aus einer Präsentation nach MathML exportiert wird:

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

**Wie kann ich erkennen, ob ein Objekt auf einer Folie eine mathematische Formel und nicht normaler Text oder ein Bild ist?**

Eine Formel befindet sich in einer [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) und hat einen [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/). Bilder und reguläre Textabschnitte ohne einen [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) sind keine exportierbaren Formeln.

**Woher stammt das MathML in einer Präsentation – ist es PowerPoint-spezifisch oder ein Standard?**

Der Export richtet sich nach dem Standard‑MathML (XML). Aspose verwendet Presentation MathML – den präsentationsbezogenen Teil des Standards –, der in vielen Anwendungen und im Web weit verbreitet ist.

**Wird das Exportieren von Formeln in Tabellen, SmartArt, Gruppen usw. unterstützt?**

Ja, wenn diese Objekte Textabschnitte mit einem [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) enthalten (d. h. echte PowerPoint‑Formeln), werden sie exportiert. Wird eine Formel als Bild eingebettet, wird sie nicht exportiert.

**Verändert das Exportieren nach MathML die Originalpräsentation?**

Nein. Das Schreiben von MathML ist eine Serialisierung des Inhalts der Formel; sie ändert die Präsentationsdatei nicht.