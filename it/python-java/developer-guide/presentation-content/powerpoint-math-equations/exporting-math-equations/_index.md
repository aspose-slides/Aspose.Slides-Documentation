---
title: Esporta equazioni matematiche dalle presentazioni in Python
linktitle: Esporta equazioni
type: docs
weight: 30
url: /it/python-java/exporting-math-equations/
keywords:
- esporta equazioni matematiche
- esporta equazioni in LaTeX
- PowerPoint in LaTeX
- MathML
- LaTeX
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Esporta equazioni matematiche dalle presentazioni PowerPoint in LaTeX o MathML direttamente con Aspose.Slides per Python tramite Java."
---
## **Introduzione**

Aspose.Slides consente di esportare equazioni matematiche dalle presentazioni. Ad esempio, potresti dover estrarre le equazioni matematiche dalle slide (da una presentazione specifica) e usarle in un altro programma o piattaforma. 

{{% alert color="info" title="Note" %}} 
Puoi esportare le equazioni direttamente in LaTeX o in MathML, uno standard popolare per i contenuti matematici utilizzato sul web e in molte applicazioni.
{{% /alert %}}

## **Esporta equazioni matematiche in LaTeX**

Aspose.Slides può convertire un’equazione matematica di PowerPoint direttamente in LaTeX; non è necessario un file intermedio MathML né un convertitore esterno. Un’equazione matematica è memorizzata in una casella di testo come un [MathPortion](https://reference.aspose.com/slides/it/python-java/aspose.slides/mathportion/). Usa [MathPortion.getMathParagraph](https://reference.aspose.com/slides/it/python-java/aspose.slides/mathportion/#getMathParagraph) per ottenere un [MathParagraph](https://reference.aspose.com/slides/it/python-java/aspose.slides/mathparagraph/), e poi chiama [MathParagraph.toLatex](https://reference.aspose.com/slides/it/python-java/aspose.slides/mathparagraph/#toLatex). Il metodo restituisce una stringa che puoi salvare, visualizzare, inviare a un’altra applicazione o elaborare ulteriormente.

L’esempio seguente esamina ogni casella di testo in ogni slide, individua tutte le porzioni matematiche e scrive ciascuna equazione in un file `.tex` separato:

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

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/it/python-java/aspose.slides/slideutil/#getAllTextBoxes) restituisce tutte le caselle di testo trovate in una slide. Il controllo di tipo [MathPortion](https://reference.aspose.com/slides/it/python-java/aspose.slides/mathportion/) separa le vere equazioni modificabili dal testo e dalle immagini ordinari.

I motori LaTeX e i modelli di documento non supportano tutti gli stessi comandi, pacchetti o caratteri Unicode. Verifica la stringa restituita con il motore LaTeX usato dalla tua applicazione. Se un simbolo o un elemento Office Math non ha una rappresentazione adeguata in quell’ambiente, sostituiscilo nella stringa restituita con un comando specifico del progetto oppure ignora l’equazione e registra il problema per una revisione.

## **Salva le equazioni matematiche come MathML**

Mentre è facile per le persone scrivere codice per alcuni formati di equazioni, come LaTeX, MathML è più difficile da scrivere a mano perché è progettato per essere generato automaticamente dalle applicazioni. I programmi possono leggere e analizzare facilmente MathML poiché è basato su XML, perciò MathML è comunemente usato come formato di output e di stampa in molti settori. 

Questo esempio di codice mostra come esportare un’equazione matematica da una presentazione a MathML:

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

**Che cosa viene esportato esattamente in MathML—un paragrafo o un blocco di formula individuale?**

Puoi esportare sia un intero paragrafo matematico ([MathParagraph](https://reference.aspose.com/slides/it/python-java/aspose.slides/mathparagraph/)) sia un blocco individuale ([MathBlock](https://reference.aspose.com/slides/it/python-java/aspose.slides/mathblock/)) in MathML. Entrambi i tipi forniscono un metodo per scrivere in MathML.

**Come posso capire se un oggetto su una slide è una formula matematica anziché testo o immagine normale?**

Una formula si trova in un [MathPortion](https://reference.aspose.com/slides/it/python-java/aspose.slides/mathportion/) e dispone di un [MathParagraph](https://reference.aspose.com/slides/it/python-java/aspose.slides/mathparagraph/). Le immagini e le porzioni di testo normale senza un [MathParagraph](https://reference.aspose.com/slides/it/python-java/aspose.slides/mathparagraph/) non sono formule esportabili.

**Da dove proviene il MathML in una presentazione—è specifico di PowerPoint o è uno standard?**

L’esportazione punta al MathML standard (XML). Aspose utilizza Presentation MathML—il sottoinsieme di presentazione dello standard—che è ampiamente usato in molte applicazioni e sul web.

**L’esportazione di formule all’interno di tabelle, SmartArt, gruppi, ecc. è supportata?**

Sì, se quegli oggetti contengono porzioni di testo con un [MathParagraph](https://reference.aspose.com/slides/it/python-java/aspose.slides/mathparagraph/) (cioè vere formule PowerPoint), vengono esportate. Se una formula è incorporata come immagine, non lo è.

**L’esportazione in MathML modifica la presentazione originale?**

No. Scrivere MathML è una serializzazione del contenuto della formula; non modifica il file della presentazione.