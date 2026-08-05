---
title: Mathematische Gleichungen aus Präsentationen in Python exportieren
linktitle: Gleichungen exportieren
type: docs
weight: 30
url: /de/python-net/exporting-math-equations/
keywords:
- Mathematische Gleichungen exportieren
- Gleichungen nach LaTeX exportieren
- PowerPoint nach LaTeX
- MathML
- LaTeX
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Exportieren Sie mathematische Gleichungen aus PowerPoint‑Präsentationen direkt nach LaTeX oder MathML mit Aspose.Slides für Python via .NET."
---
## **Einleitung**

Aspose.Slides for Python via .NET ermöglicht das Exportieren mathematischer Gleichungen aus Präsentationen. Beispielsweise müssen Sie Gleichungen aus bestimmten Folien extrahieren und in einem anderen Programm oder einer anderen Plattform wiederverwenden.

{{% alert color="primary" %}}
Sie können Gleichungen direkt nach LaTeX oder nach MathML exportieren, einem beliebten Standard für mathematischen Inhalt, der im Web und in vielen Anwendungen verwendet wird.
{{% /alert %}}

## **Mathegleichungen nach LaTeX exportieren**

Aspose.Slides kann eine PowerPoint‑Mathematikgleichung direkt nach LaTeX konvertieren; eine Zwischendatei im MathML‑Format und ein externer Konverter sind nicht erforderlich. Eine mathematische Gleichung wird in einem Textfeld als [MathPortion](https://reference.aspose.com/slides/de/python-net/aspose.slides.mathtext/mathportion/) gespeichert. Verwenden Sie [MathPortion.math_paragraph](https://reference.aspose.com/slides/de/python-net/aspose.slides.mathtext/mathportion/math_paragraph/), um ein [MathParagraph](https://reference.aspose.com/slides/de/python-net/aspose.slides.mathtext/mathparagraph/) zu erhalten, und rufen Sie anschließend [MathParagraph.to_latex](https://reference.aspose.com/slides/de/python-net/aspose.slides.mathtext/mathparagraph/to_latex/) auf. Die Methode gibt einen String zurück, den Sie speichern, anzeigen, an eine andere Anwendung senden oder weiterverarbeiten können.

Das folgende Beispiel untersucht jedes Textfeld auf jeder Folie, findet alle MathPortion‑Objekte und schreibt jede Gleichung in eine separate `.tex`‑Datei:

```py
import aspose.slides as slides

with slides.Presentation("equations.pptx") as presentation:
    for slide_number, slide in enumerate(presentation.slides, start=1):
        equation_number = 1
        text_frames = slides.util.SlideUtil.get_all_text_boxes(slide)

        for text_frame in text_frames:
            for paragraph in text_frame.paragraphs:
                for portion in paragraph.portions:
                    if not isinstance(portion, slides.mathtext.MathPortion):
                        continue

                    math_paragraph = portion.math_paragraph
                    latex_path = f"slide_{slide_number}_equation_{equation_number}.tex"

                    latex_text = math_paragraph.to_latex()
                    with open(latex_path, "w", encoding="utf-8") as latex_file:
                        latex_file.write(latex_text)
                    equation_number += 1
```

[SlideUtil.get_all_text_boxes](https://reference.aspose.com/slides/de/python-net/aspose.slides.util/slideutil/get_all_text_boxes/) gibt alle auf einer Folie gefundenen Textfelder zurück. Der Typ‑Check mit [MathPortion](https://reference.aspose.com/slides/de/python-net/aspose.slides.mathtext/mathportion/) trennt echte bearbeitbare Gleichungen von gewöhnlichem Text und Bildern.

LaTeX‑Engines und Dokumentvorlagen unterstützen nicht alle dieselben Befehle, Pakete oder Unicode‑Zeichen. Testen Sie den zurückgegebenen String mit der LaTeX‑Engine, die Ihre Anwendung verwendet. Wenn ein Symbol oder ein Office‑Math‑Element in dieser Umgebung keine geeignete Darstellung hat, ersetzen Sie es im zurückgegebenen String durch einen projektspezifischen Befehl oder überspringen Sie die Gleichung und protokollieren Sie das Problem zur späteren Überprüfung.

## **Mathegleichungen als MathML speichern**

Obwohl Menschen LaTeX leicht schreiben können, wird MathML typischerweise automatisch von Anwendungen erzeugt. Da MathML XML‑basiert ist, können Programme es zuverlässig lesen und analysieren; daher wird es häufig als Ausgabe‑ und Druckformat in vielen Bereichen verwendet.

Der folgende Beispielcode zeigt, wie Sie eine mathematische Gleichung aus einer Präsentation nach MathML exportieren:

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

Sie können entweder einen gesamten mathematischen Absatz ([MathParagraph](https://reference.aspose.com/slides/de/python-net/aspose.slides.mathtext/mathparagraph/)) oder einen einzelnen Block ([MathBlock](https://reference.aspose.com/slides/de/python-net/aspose.slides.mathtext/mathblock/)) nach MathML exportieren. Beide Typen stellen eine Methode zum Schreiben nach MathML bereit.

**Wie kann ich erkennen, dass ein Objekt auf einer Folie eine mathematische Formel und kein normaler Text oder Bild ist?**

Eine Formel befindet sich in einem [MathPortion](https://reference.aspose.com/slides/de/python-net/aspose.slides.mathtext/mathportion/) und hat ein [MathParagraph](https://reference.aspose.com/slides/de/python-net/aspose.slides.mathtext/mathparagraph/). Bilder und reguläre Textteile ohne einen [MathParagraph](https://reference.aspose.com/slides/de/python-net/aspose.slides.mathtext/mathparagraph/) sind nicht exportierbare Formeln.

**Woher stammt das MathML in einer Präsentation – ist es PowerPoint‑spezifisch oder ein Standard?**

Der Export zielt auf standardmäßiges MathML (XML) ab. Aspose verwendet Presentation MathML – den Präsentations‑Subset des Standards –, das in vielen Anwendungen und im Web verbreitet ist.

**Wird der Export von Formeln in Tabellen, SmartArt, Gruppen usw. unterstützt?**

Ja, wenn diese Objekte Textteile mit einem [MathParagraph](https://reference.aspose.com/slides/de/python-net/aspose.slides.mathtext/mathparagraph/) enthalten (d.h. echte PowerPoint‑Formeln), werden sie exportiert. Ist eine Formel als Bild eingebettet, geschieht dies nicht.

**Verändert das Exportieren nach MathML die ursprüngliche Präsentation?**

Nein. Das Schreiben von MathML ist eine Serialisierung des Formel‑Inhalts; sie ändert die Präsentationsdatei nicht.