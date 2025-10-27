---
title: Mathegleichungen aus Präsentationen in Python exportieren
linktitle: Gleichungen exportieren
type: docs
weight: 30
url: /de/python-net/exporting-math-equations/
keywords:
- Mathegleichungen exportieren
- MathML
- LaTeX
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Ermöglichen Sie den nahtlosen Export von Mathegleichungen von PowerPoint nach MathML mit Aspose.Slides für Python via .NET – bewahren Sie die Formatierung und erhöhen Sie die Kompatibilität."
---

## **Einführung**

Aspose.Slides für Python via .NET ermöglicht Ihnen den Export von Mathegleichungen aus Präsentationen. Beispielsweise müssen Sie Gleichungen aus bestimmten Folien extrahieren und in einem anderen Programm oder einer anderen Plattform wiederverwenden.

{{% alert color="primary" %}}
Sie können Gleichungen nach MathML exportieren, einem weit verbreiteten Standard zur Darstellung mathematischer Inhalte im Web und in vielen Anwendungen.
{{% /alert %}}

## **Mathegleichungen als MathML speichern**

Obwohl Menschen LaTeX leicht schreiben können, wird MathML typischerweise automatisch von Anwendungen erzeugt. Da MathML XML‑basiert ist, können Programme es zuverlässig lesen und parsen, weshalb es in vielen Bereichen als Ausgabe‑ und Druckformat verwendet wird.

Der folgende Beispielcode zeigt, wie eine Mathegleichung aus einer Präsentation nach MathML exportiert wird:

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

Sie können entweder einen gesamten Matheabsatz ([MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/)) oder einen einzelnen Block ([MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)) nach MathML exportieren. Beide Typen bieten eine Methode zum Schreiben nach MathML.

**Wie erkenne ich, dass ein Objekt auf einer Folie eine mathematische Formel und kein normaler Text oder Bild ist?**

Eine Formel befindet sich in einem [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) und besitzt einen [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/). Bilder und normale Textabschnitte ohne einen [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) können nicht als Formeln exportiert werden.

**Woher stammt das MathML in einer Präsentation – ist es PowerPoint‑spezifisch oder ein Standard?**

Der Export richtet sich nach dem Standard‑MathML (XML). Aspose verwendet Presentation MathML – den Präsentations‑Subset des Standards –, der in vielen Anwendungen und im Web verbreitet ist.

**Wird der Export von Formeln innerhalb von Tabellen, SmartArt, Gruppen usw. unterstützt?**

Ja, wenn diese Objekte Textabschnitte mit einem [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) enthalten (also echte PowerPoint‑Formeln), werden sie exportiert. Wenn eine Formel als Bild eingebettet ist, wird sie nicht exportiert.

**Ändert der Export nach MathML die ursprüngliche Präsentation?**

Nein. Das Schreiben von MathML ist eine Serialisierung des Inhalts der Formel; es verändert die Präsentationsdatei nicht.