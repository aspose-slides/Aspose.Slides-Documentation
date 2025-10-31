---
title: "Mathegleichungen aus Präsentationen in Python exportieren"
linktitle: "Gleichungen exportieren"
type: docs
weight: 30
url: /de/python-net/exporting-math-equations/
keywords:
- "Mathegleichungen exportieren"
- MathML
- LaTeX
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Ermöglichen Sie einen nahtlosen Export von mathematischen Formeln aus PowerPoint nach MathML mit Aspose.Slides für Python via .NET – bewahren Sie die Formatierung und verbessern Sie die Kompatibilität."
---

## **Einleitung**

Aspose.Slides für Python via .NET ermöglicht das Exportieren von mathematischen Gleichungen aus Präsentationen. Beispielsweise müssen Sie möglicherweise Gleichungen aus bestimmten Folien extrahieren und in einem anderen Programm oder einer anderen Plattform wiederverwenden.

{{% alert color="primary" %}}
Sie können Gleichungen nach MathML exportieren, einem weit verbreiteten Standard zur Darstellung mathematischer Inhalte im Web und in vielen Anwendungen.
{{% /alert %}}

## **Mathegleichungen als MathML speichern**

Obwohl Menschen LaTeX leicht schreiben können, wird MathML in der Regel automatisch von Anwendungen erzeugt. Da MathML XML‑basiert ist, können Programme es zuverlässig lesen und verarbeiten, weshalb es häufig als Ausgabe‑ und Druckformat in vielen Bereichen verwendet wird.

Der folgende Beispielcode zeigt, wie man eine mathematische Gleichung aus einer Präsentation nach MathML exportiert:

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

**Wie kann ich erkennen, ob ein Objekt auf einer Folie eine mathematische Formel und nicht normaler Text oder ein Bild ist?**

Eine Formel ist in einem [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) enthalten und besitzt einen [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/). Bilder und reguläre Textanteile ohne einen [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) sind nicht exportierbare Formeln.

**Woher stammt das MathML in einer Präsentation – ist es PowerPoint-spezifisch oder ein Standard?**

Der Export zielt auf das standardisierte MathML (XML) ab. Aspose verwendet Presentation MathML – die Präsentationsuntermenge des Standards – die in vielen Anwendungen und im Web weit verbreitet ist.

**Wird das Exportieren von Formeln innerhalb von Tabellen, SmartArt, Gruppen usw. unterstützt?**

Ja, wenn diese Objekte Textanteile mit einem [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) enthalten (d. h. echte PowerPoint‑Formeln), werden sie exportiert. Ist eine Formel als Bild eingebettet, wird sie nicht exportiert.

**Verändert das Exportieren nach MathML die originale Präsentation?**

Nein. Das Schreiben von MathML ist eine Serialisierung des Inhalts der Formel; es verändert die Präsentationsdatei nicht.