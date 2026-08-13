---
title: Esporta Equazioni Matematiche dalle Presentazioni in .NET
linktitle: Esporta Equazioni
type: docs
weight: 30
url: /it/net/exporting-math-equations/
keywords:
- esporta equazioni matematiche
- esporta equazioni in LaTeX
- PowerPoint in LaTeX
- MathML
- LaTeX
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Esporta equazioni matematiche dalle presentazioni PowerPoint in LaTeX o MathML direttamente con Aspose.Slides per .NET."
---
## **Introduzione**

Aspose.Slides for .NET ti consente di esportare equazioni matematiche dalle presentazioni. Ad esempio, potresti aver bisogno di estrarre le equazioni matematiche dalle diapositive (da una presentazione specifica) e usarle in un altro programma o piattaforma. 

{{% alert color="info" %}} 

Puoi esportare le equazioni direttamente in LaTeX o in MathML, uno standard popolare per i contenuti matematici usato sul web e in molte applicazioni.

{{% /alert %}}

## **Esporta Equazioni Matematiche in LaTeX**

Aspose.Slides può convertire un'equazione matematica di PowerPoint direttamente in LaTeX; non è necessario un file MathML intermedio né un convertitore esterno. Un'equazione matematica è memorizzata in una casella di testo come un [MathPortion](https://reference.aspose.com/slides/it/net/aspose.slides.mathtext/mathportion/). Usa [MathPortion.MathParagraph](https://reference.aspose.com/slides/it/net/aspose.slides.mathtext/mathportion/mathparagraph/) per ottenere un [IMathParagraph](https://reference.aspose.com/slides/it/net/aspose.slides.mathtext/imathparagraph/), e quindi chiama [IMathParagraph.ToLatex](https://reference.aspose.com/slides/it/net/aspose.slides.mathtext/imathparagraph/tolatex/). Il metodo restituisce una stringa che puoi salvare, visualizzare, inviare a un'altra applicazione o elaborare ulteriormente.

L'esempio seguente esamina ogni casella di testo in ogni diapositiva, individua tutte le porzioni matematiche e scrive ogni equazione in un file `.tex` separato:

```csharp
using Aspose.Slides;
using Aspose.Slides.MathText;
using Aspose.Slides.Util;

using var presentation = new Presentation("equations.pptx");

for (var slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];
    var slideNumber = slideIndex + 1;
    var equationNumber = 1;
    var textFrames = SlideUtil.GetAllTextBoxes(slide);

    foreach (var textFrame in textFrames)
    {
        foreach (var paragraph in textFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                if (portion is not MathPortion mathPortion)
                    continue;

                IMathParagraph mathParagraph = mathPortion.MathParagraph;
                var latexPath = $"slide_{slideNumber}_equation_{equationNumber}.tex";

                var latexText = mathParagraph.ToLatex();
                File.WriteAllText(latexPath, latexText);
                equationNumber++;
            }
        }
    }
}
```

[SlideUtil.GetAllTextBoxes](https://reference.aspose.com/slides/it/net/aspose.slides.util/slideutil/getalltextboxes/) restituisce tutte le caselle di testo trovate su una diapositiva. Il controllo di tipo [MathPortion](https://reference.aspose.com/slides/it/net/aspose.slides.mathtext/mathportion/) separa le vere equazioni modificabili dal testo e dalle immagini ordinari.

I motori LaTeX e i modelli di documento non supportano tutti gli stessi comandi, pacchetti o caratteri Unicode. Verifica la stringa restituita con il motore LaTeX utilizzato dalla tua applicazione. Se un simbolo o un elemento Office Math non ha una rappresentazione adeguata in quell'ambiente, sostituiscilo nella stringa restituita con un comando specifico del progetto o ignora l'equazione e registra il problema per una revisione.

## **Salva Equazioni Matematiche come MathML**

Mentre gli esseri umani scrivono facilmente il codice per alcuni formati di equazioni come LaTeX, hanno difficoltà a scrivere il codice per MathML perché quest'ultimo è destinato a essere generato automaticamente dalle applicazioni. I programmi leggono e analizzano MathML facilmente poiché il suo codice è in XML, quindi MathML è comunemente usato come formato di output e stampa in molti settori. 

Questo codice di esempio mostra come esportare un'equazione matematica da una presentazione a MathML:

```c#
using Aspose.Slides;
using Aspose.Slides.MathText;

using (Presentation pres = new Presentation())
        {
            var autoShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);
            var mathParagraph = ((MathPortion)autoShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            mathParagraph.Add(new MathematicalText("a").SetSuperscript("2").Join("+").Join(new MathematicalText("b").SetSuperscript("2")).Join("=").Join(new MathematicalText("c").SetSuperscript("2")));

       using (Stream stream = new FileStream("mathml.xml", FileMode.Create))
                mathParagraph.WriteAsMathMl(stream);
        }
```

## **Domande frequenti**

**Cosa viene esportato esattamente in MathML—un paragrafo o un blocco formula individuale?**

Puoi esportare sia un intero paragrafo matematico ([MathParagraph](https://reference.aspose.com/slides/it/net/aspose.slides.mathtext/mathparagraph/)) sia un blocco individuale ([MathBlock](https://reference.aspose.com/slides/it/net/aspose.slides.mathtext/mathblock/)) in MathML. Entrambi i tipi forniscono un metodo per scrivere in MathML.

**Come posso capire se un oggetto su una diapositiva è una formula matematica piuttosto che testo normale o un'immagine?**

Una formula risiede in una [MathPortion](https://reference.aspose.com/slides/it/net/aspose.slides.mathtext/mathportion/) e ha un [MathParagraph](https://reference.aspose.com/slides/it/net/aspose.slides.mathtext/mathparagraph/). Le immagini e le porzioni di testo normale senza un [MathParagraph](https://reference.aspose.com/slides/it/net/aspose.slides.mathtext/mathparagraph/) non sono formule esportabili.

**Da dove proviene il MathML in una presentazione—è specifico di PowerPoint o è uno standard?**

L'esportazione mira a MathML standard (XML). Aspose utilizza Presentation MathML—il sottoinsieme di presentazione dello standard—che è ampiamente usato in molte applicazioni e sul web.

**L'esportazione di formule all'interno di tabelle, SmartArt, gruppi, ecc., è supportata?**

Sì, se tali oggetti contengono porzioni di testo con un [MathParagraph](https://reference.aspose.com/slides/it/net/aspose.slides.mathtext/mathparagraph/) (cioè vere formule PowerPoint), vengono esportati. Se una formula è incorporata come immagine, non lo è.

**L'esportazione in MathML modifica la presentazione originale?**

No. Scrivere MathML è una serializzazione del contenuto della formula; non modifica il file della presentazione.