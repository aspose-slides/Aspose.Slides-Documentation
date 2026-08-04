---
title: Esporta equazioni matematiche dalle presentazioni in Python
linktitle: Esporta Equazioni
type: docs
weight: 30
url: /it/python-net/exporting-math-equations/
keywords:
- esporta equazioni matematiche
- esporta equazioni in LaTeX
- PowerPoint in LaTeX
- MathML
- LaTeX
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Esporta equazioni matematiche dalle presentazioni PowerPoint in LaTeX o MathML direttamente con Aspose.Slides per Python tramite .NET."
---
## **Introduzione**

Aspose.Slides per Python tramite .NET consente di esportare equazioni matematiche dalle presentazioni. Ad esempio, potresti dover estrarre le equazioni da diapositive specifiche e riutilizzarle in un altro programma o piattaforma.

{{% alert color="primary" %}}
È possibile esportare le equazioni direttamente in LaTeX o in MathML, uno standard popolare per i contenuti matematici utilizzato sul web e in molte applicazioni.
{{% /alert %}}

## **Esporta equazioni matematiche in LaTeX**

Aspose.Slides può convertire direttamente un’equazione matematica di PowerPoint in LaTeX; non è necessario un file MathML intermedio né un convertitore esterno. Un’equazione matematica è memorizzata in una casella di testo come [MathPortion](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/mathportion/). Utilizza [MathPortion.math_paragraph](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) per ottenere un [MathParagraph](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/mathparagraph/), e poi chiama [MathParagraph.to_latex](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/mathparagraph/to_latex/). Il metodo restituisce una stringa che è possibile salvare, visualizzare, inviare a un’altra applicazione o elaborare ulteriormente.

Il seguente esempio esamina tutte le caselle di testo in ogni diapositiva, individua tutte le porzioni matematiche e scrive ogni equazione in un file `.tex` separato:

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

[SlideUtil.get_all_text_boxes](https://reference.aspose.com/slides/it/python-net/aspose.slides.util/slideutil/get_all_text_boxes/) restituisce tutte le caselle di testo trovate in una diapositiva. Il controllo del tipo [MathPortion](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/mathportion/) separa le vere equazioni modificabili dal testo e dalle immagini ordinarie.

I motori LaTeX e i modelli di documento non supportano tutti gli stessi comandi, pacchetti o caratteri Unicode. Verifica la stringa restituita con il motore LaTeX utilizzato dalla tua applicazione. Se un simbolo o un elemento Office Math non ha una rappresentazione adeguata in quell’ambiente, sostituiscilo nella stringa restituita con un comando specifico del progetto oppure ignora l’equazione e registra il problema per la revisione.

## **Salva le equazioni matematiche come MathML**

Sebbene gli esseri umani possano scrivere LaTeX con facilità, MathML viene normalmente generato automaticamente dalle applicazioni. Poiché MathML è basato su XML, i programmi possono leggerlo e analizzarlo in modo affidabile, perciò è comunemente usato come formato di output e stampa in molti settori.

Il seguente esempio di codice mostra come esportare un’equazione matematica da una presentazione a MathML:

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

**Cosa viene esattamente esportato in MathML—un paragrafo o un blocco formula individuale?**

È possibile esportare sia un intero paragrafo matematico ([MathParagraph](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/mathparagraph/)) sia un blocco individuale ([MathBlock](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/mathblock/)) in MathML. Entrambi i tipi forniscono un metodo per scrivere in MathML.

**Come posso capire se un oggetto su una diapositiva è una formula matematica anziché testo normale o un’immagine?**

Una formula risiede in una [MathPortion](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/mathportion/) e possiede un [MathParagraph](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/mathparagraph/). Le immagini e le porzioni di testo normali senza un [MathParagraph](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/mathparagraph/) non sono formule esportabili.

**Da dove proviene il MathML in una presentazione—è specifico di PowerPoint o è uno standard?**

L’esportazione punta al MathML standard (XML). Aspose utilizza il Presentation MathML—il sottoinsieme di presentazione dello standard—che è ampiamente usato in molte applicazioni e sul web.

**L’esportazione di formule all’interno di tabelle, SmartArt, gruppi, ecc. è supportata?**

Sì, se quegli oggetti contengono porzioni di testo con un [MathParagraph](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/mathparagraph/) (cioè vere formule PowerPoint), vengono esportati. Se una formula è incorporata come immagine, non lo è.

**L’esportazione in MathML modifica la presentazione originale?**

No. La scrittura del MathML è una serializzazione del contenuto della formula; non modifica il file della presentazione.