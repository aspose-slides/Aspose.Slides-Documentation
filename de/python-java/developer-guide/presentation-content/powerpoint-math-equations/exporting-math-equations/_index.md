---
title: Mathematische Gleichungen aus Präsentationen in Python exportieren
linktitle: Gleichungen exportieren
type: docs
weight: 30
url: /de/python-java/exporting-math-equations/
keywords:
- mathematische Gleichungen exportieren
- Gleichungen nach LaTeX exportieren
- PowerPoint nach LaTeX
- MathML
- LaTeX
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Exportieren Sie mathematische Gleichungen aus PowerPoint‑Präsentationen direkt nach LaTeX oder MathML mit Aspose.Slides für Python über Java."
---
## **Einleitung**

Aspose.Slides ermöglicht das Exportieren mathematischer Gleichungen aus Präsentationen. Beispielsweise müssen Sie möglicherweise die mathematischen Gleichungen auf Folien (aus einer bestimmten Präsentation) extrahieren und in einem anderen Programm oder einer anderen Plattform verwenden. 

{{% alert color="info" title="Note" %}} 
Sie können Gleichungen direkt nach LaTeX oder nach MathML exportieren, einem weit verbreiteten Standard für mathematische Inhalte, der im Web und in vielen Anwendungen genutzt wird.
{{% /alert %}}

## **Mathgleichungen nach LaTeX exportieren**

Aspose.Slides kann eine PowerPoint‑Math‑Gleichung direkt nach LaTeX konvertieren; eine Zwischen‑MathML‑Datei und ein externer Konverter sind nicht erforderlich. Eine Math‑Gleichung wird in einem Textfeld als [MathPortion](https://reference.aspose.com/slides/de/python-java/aspose.slides/mathportion/) gespeichert. Verwenden Sie [MathPortion.getMathParagraph](https://reference.aspose.com/slides/de/python-java/aspose.slides/mathportion/#getMathParagraph), um ein [MathParagraph](https://reference.aspose.com/slides/de/python-java/aspose.slides/mathparagraph/) zu erhalten, und rufen Sie dann [MathParagraph.toLatex](https://reference.aspose.com/slides/de/python-java/aspose.slides/mathparagraph/#toLatex) auf. Die Methode gibt einen String zurück, den Sie speichern, anzeigen, an eine andere Anwendung senden oder weiterverarbeiten können.

Das folgende Beispiel durchsucht jedes Textfeld jeder Folie, findet alle Math‑Portionen und schreibt jede Gleichung in eine separate `.tex`‑Datei:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathPortion, Presentation, SlideUtil

presentation = Presentation("equations.pptx")
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide_index + 1
        equation_number = 1
        text_frames = SlideUtil.getAllTextBoxes(slide)

        for text_frame in text_frames:
            for paragraph in text_frame.getParagraphs():
                for portion in paragraph.getPortions():
                    if not isinstance(portion, MathPortion):
                        continue

                    math_paragraph = portion.getMathParagraph()
                    latex_file_name = f"slide_{slide_number}_equation_{equation_number}.tex"
                    latex_text = math_paragraph.toLatex()
                    latex_path = Path(latex_file_name)
                    latex_path.write_text(str(latex_text), encoding="utf-8")
                    equation_number += 1
finally:
    presentation.dispose()
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideutil/#getAllTextBoxes) gibt alle auf einer Folie gefundenen Textfelder zurück. Der Typ‑Check von [MathPortion](https://reference.aspose.com/slides/de/python-java/aspose.slides/mathportion/) trennt echte editierbare Gleichungen von gewöhnlichem Text und Bildern.

LaTeX‑Engines und Dokumentvorlagen unterstützen nicht alle dieselben Befehle, Pakete oder Unicode‑Zeichen. Testen Sie den zurückgegebenen String mit der LaTeX‑Engine, die Ihre Anwendung verwendet. Wenn ein Symbol oder ein Office‑Math‑Element in dieser Umgebung keine geeignete Darstellung hat, ersetzen Sie es im zurückgegebenen String durch einen projektspezifischen Befehl oder überspringen Sie die Gleichung und protokollieren Sie das Problem zur späteren Prüfung.

## **Mathgleichungen als MathML speichern**

Während man Code für einige Gleichungsformate, wie LaTeX, leicht schreiben kann, ist MathML schwer von Hand zu erstellen, weil es dafür konzipiert ist, automatisch von Anwendungen generiert zu werden. Programme können MathML leicht lesen und verarbeiten, da es XML‑basiert ist; daher wird MathML in vielen Bereichen häufig als Ausgabe‑ und Druckformat verwendet. 

Dieses Beispiel zeigt, wie Sie eine Math‑Gleichung aus einer Präsentation nach MathML exportieren:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText, Presentation
from java.io import FileOutputStream

presentation = Presentation()
try:
    math_shape = presentation.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50)
    math_portion = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    math_paragraph = math_portion.getMathParagraph()

    a_squared = MathematicalText("a").setSuperscript("2")
    b_squared = MathematicalText("b").setSuperscript("2")
    c_squared = MathematicalText("c").setSuperscript("2")
    equation = a_squared.join("+").join(b_squared).join("=").join(c_squared)
    math_paragraph.add(equation)

    stream = FileOutputStream("mathml.xml")
    try:
        math_paragraph.writeAsMathMl(stream)
    finally:
        stream.close()
finally:
    presentation.dispose()
```

## **FAQ**

**Was genau wird nach MathML exportiert – ein Absatz oder ein einzelner Formelb​lock?**  
Sie können entweder einen gesamten Math‑Absatz ([MathParagraph](https://reference.aspose.com/slides/de/python-java/aspose.slides/mathparagraph/)) oder einen einzelnen Block ([MathBlock](https://reference.aspose.com/slides/de/python-java/aspose.slides/mathblock/)) nach MathML exportieren. Beide Typen bieten eine Methode zum Schreiben nach MathML.

**Wie erkenne ich, ob ein Objekt auf einer Folie eine mathematische Formel und kein normaler Text oder Bild ist?**  
Eine Formel befindet sich in einer [MathPortion](https://reference.aspose.com/slides/de/python-java/aspose.slides/mathportion/) und besitzt ein [MathParagraph](https://reference.aspose.com/slides/de/python-java/aspose.slides/mathparagraph/). Bilder und reguläre Textportionen ohne ein [MathParagraph](https://reference.aspose.com/slides/de/python-java/aspose.slides/mathparagraph/) können nicht als Formeln exportiert werden.

**Woher stammt das MathML in einer Präsentation – ist es PowerPoint‑spezifisch oder ein Standard?**  
Der Export zielt auf standardmäßiges MathML (XML). Aspose verwendet Presentation MathML – den Präsentations‑Teilstandard des MathML‑Standards –, der in vielen Anwendungen und im Web weit verbreitet ist.

**Werden Formeln in Tabellen, SmartArt, Gruppen usw. unterstützt?**  
Ja, wenn diese Objekte Text‑Portionen mit einem [MathParagraph](https://reference.aspose.com/slides/de/python-java/aspose.slides/mathparagraph/) enthalten (also echte PowerPoint‑Formeln), werden sie exportiert. Wenn eine Formel als Bild eingebettet ist, wird sie nicht exportiert.

**Verändert das Exportieren nach MathML die ursprüngliche Präsentation?**  
Nein. Das Schreiben von MathML ist eine Serialisierung des Inhalts der Formel; sie ändert die Präsentationsdatei nicht.