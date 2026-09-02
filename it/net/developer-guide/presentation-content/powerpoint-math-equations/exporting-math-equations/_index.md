---
title: Esporta equazioni matematiche dalle presentazioni in .NET
linktitle: Esporta equazioni
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

Aspose.Slides per .NET consente di esportare equazioni matematiche dalle presentazioni. Ad esempio, potresti aver bisogno di estrarre le equazioni matematiche dalle diapositive (da una presentazione specifica) e usarle in un altro programma o piattaforma. 

{{% alert color="primary" %}} 
Puoi esportare le equazioni direttamente in LaTeX o in MathML, uno standard popolare per contenuti matematici utilizzato sul web e in molte applicazioni. 
{{% /alert %}}

## **Esporta equazioni matematiche in LaTeX**

Aspose.Slides può convertire una equazione matematica di PowerPoint direttamente in LaTeX; non è necessario un file intermedio MathML né un convertitore esterno. Una equazione matematica è archiviata in un riquadro di testo come una [MathPortion](https://reference.aspose.com/slides/it/net/aspose.slides.mathtext/mathportion/). Usa [MathPortion.MathParagraph](https://reference.aspose.com/slides/it/net/aspose.slides.mathtext/mathportion/mathparagraph/) per ottenere un [IMathParagraph](https://reference.aspose.com/slides/it/net/aspose.slides.mathtext/imathparagraph/), e poi chiama [IMathParagraph.ToLatex](https://reference.aspose.com/slides/it/net/aspose.slides.mathtext/imathparagraph/tolatex/). Il metodo restituisce una stringa che puoi salvare, visualizzare, inviare a un'altra applicazione o elaborare ulteriormente. 

L’esempio seguente esamina ogni riquadro di testo su ogni diapositiva, trova tutte le porzioni matematiche e scrive ciascuna equazione in un file `.tex` separato:

```csharp
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

[SlideUtil.GetAllTextBoxes](https://reference.aspose.com/slides/it/net/aspose.slides.util/slideutil/getalltextboxes/) restituisce tutti i riquadri di testo trovati su una diapositiva. Il check del tipo [MathPortion](https://reference.aspose.com/slides/it/net/aspose.slides.mathtext/mathportion/) separa le vere equazioni modificabili dal testo ordinario e dalle immagini. 

I motori LaTeX e i modelli di documento non supportano tutti gli stessi comandi, pacchetti o caratteri Unicode. Prova la stringa restituita con il motore LaTeX usato dalla tua applicazione. Se un simbolo o un elemento Office Math non ha una rappresentazione adeguata in quell’ambiente, sostituiscilo nella stringa restituita con un comando specifico del progetto oppure ignora l’equazione e registra il problema per una revisione. 

## **Salva equazioni matematiche come MathML**

Mentre gli esseri umani scrivono facilmente il codice per alcuni formati di equazione come LaTeX, faticano a scrivere il codice per MathML perché quest’ultimo è destinato a essere generato automaticamente dalle app. I programmi leggono e analizzano MathML facilmente perché il suo codice è in XML, quindi MathML è comunemente usato come formato di output e stampa in molti settori. 

Questo esempio di codice ti mostra come esportare una equazione matematica da una presentazione a MathML:

```c#
using (Presentation pres = new Presentation())
        {
            var autoShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);
            var mathParagraph = ((MathPortion)autoShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            mathParagraph.Add(new MathematicalText("a").SetSuperscript("2").Join("+").Join(new MathematicalText("b").SetSuperscript("2")).Join("=").Join(new MathematicalText("c").SetSuperscript("2")));

       using (Stream stream = new FileStream("mathml.xml", FileMode.Create))
                mathParagraph.WriteAsMathMl(stream);
        }
```

## **FAQ**

**Cosa viene esattamente esportato in MathML: un paragrafo o un blocco di formula individuale?**

Puoi esportare sia un intero paragrafo matematico ([MathParagraph](https://reference.aspose.com/slides/it/net/aspose.slides.mathtext/mathparagraph/)) sia un singolo blocco ([MathBlock](https://reference.aspose.com/slides/it/net/aspose.slides.mathtext/mathblock/)) in MathML. Entrambi i tipi forniscono un metodo per scrivere in MathML. 

**Come posso capire se un oggetto su una diapositiva è una formula matematica piuttosto che testo normale o un'immagine?**

Una formula vive in una [MathPortion](https://reference.aspose.com/slides/it/net/aspose.slides.mathtext/mathportion/) e ha una [MathParagraph](https://reference.aspose.com/slides/it/net/aspose.slides.mathtext/mathparagraph/). Le immagini e le porzioni di testo normale senza una [MathParagraph](https://reference.aspose.com/slides/it/net/aspose.slides.mathtext/mathparagraph/) non sono formule esportabili. 

**Da dove proviene il MathML in una presentazione: è specifico di PowerPoint o è uno standard?**

L’esportazione punta a MathML standard (XML). Aspose utilizza Presentation MathML—il sottoinsieme di presentazione dello standard—che è ampiamente usato in molte applicazioni e sul web. 

**L'esportazione di formule all'interno di tabelle, SmartArt, gruppi, ecc. è supportata?**

Sì, se quegli oggetti contengono porzioni di testo con una [MathParagraph](https://reference.aspose.com/slides/it/net/aspose.slides.mathtext/mathparagraph/) (cioè vere formule PowerPoint), vengono esportate. Se una formula è incorporata come immagine, non lo è. 

**L'esportazione in MathML modifica la presentazione originale?**

No. Scrivere MathML è una serializzazione del contenuto della formula; non modifica il file della presentazione.