---
title: Esporta equazioni matematiche dalle presentazioni in Python
linktitle: Esporta equazioni
type: docs
weight: 30
url: /it/python-net/exporting-math-equations/
keywords:
- esportare equazioni matematiche
- MathML
- LaTeX
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Sblocca l'esportazione senza interruzioni di equazioni matematiche da PowerPoint a MathML usando Aspose.Slides per Python via .NET—preserva la formattazione e aumenta la compatibilità."
---
## **Introduzione**

Aspose.Slides for Python via .NET ti consente di esportare equazioni matematiche dalle presentazioni. Ad esempio, potresti aver bisogno di estrarre le equazioni da diapositive specifiche e riutilizzarle in un altro programma o piattaforma.

{{% alert color="primary" %}}
Puoi esportare le equazioni in MathML, uno standard ampiamente utilizzato per rappresentare contenuti matematici sul web e in molte applicazioni.
{{% /alert %}}

## **Salvare le equazioni matematiche come MathML**

Sebbene gli esseri umani possano scrivere LaTeX facilmente, MathML è tipicamente generato automaticamente dalle applicazioni. Poiché MathML è basato su XML, i programmi possono leggerlo e analizzarlo in modo affidabile, quindi è comunemente usato come formato di output e stampa in molti settori.

Il codice di esempio seguente mostra come esportare un'equazione matematica da una presentazione a MathML:

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

**Cosa viene esportato esattamente in MathML—un paragrafo o un blocco di formula individuale?**

Puoi esportare sia un intero paragrafo matematico ([MathParagraph](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/mathparagraph/)) sia un blocco individuale ([MathBlock](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/mathblock/)) in MathML. Entrambi i tipi forniscono un metodo per scrivere in MathML.

**Come posso capire se un oggetto in una diapositiva è una formula matematica piuttosto che del testo normale o un'immagine?**

Una formula risiede in una [MathPortion](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/mathportion/) e ha un [MathParagraph](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/mathparagraph/). Le immagini e le porzioni di testo normale senza un [MathParagraph](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/mathparagraph/) non sono formule esportabili.

**Da dove proviene il MathML in una presentazione—è specifico di PowerPoint o è uno standard?**

L'esportazione mira a MathML standard (XML). Aspose utilizza Presentation MathML—il sottoinsieme di presentazione dello standard—che è ampiamente usato in molte applicazioni e sul web.

**L'esportazione di formule all'interno di tabelle, SmartArt, gruppi, ecc., è supportata?**

Sì, se quegli oggetti contengono porzioni di testo con un [MathParagraph](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/mathparagraph/) (cioè vere formule PowerPoint), vengono esportati. Se una formula è incorporata come immagine, non lo è.

**L'esportazione in MathML modifica la presentazione originale?**

No. Scrivere MathML è una serializzazione del contenuto della formula; non modifica il file della presentazione.