---
title: Esporta le equazioni matematiche dalle presentazioni in .NET
linktitle: Esporta Equazioni
type: docs
weight: 30
url: /it/net/exporting-math-equations/
keywords:
- esporta equazioni matematiche
- MathML
- LaTeX
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Sblocca l'esportazione fluida delle equazioni matematiche da PowerPoint a MathML con Aspose.Slides per .NET—conserva la formattazione e migliora la compatibilità."
---
## **Introduzione**

Aspose.Slides per .NET consente di esportare equazioni matematiche da presentazioni. Ad esempio, potresti dover estrarre le equazioni matematiche dalle diapositive (da una presentazione specifica) e usarle in un altro programma o piattaforma. 

{{% alert color="primary" %}} 

Puoi esportare le equazioni in MathML, un formato o standard popolare per le equazioni matematiche e contenuti simili visualizzati sul web e in molte applicazioni. 

{{% /alert %}}

## **Salva le equazioni matematiche come MathML**

Mentre gli esseri umani scrivono facilmente il codice per alcuni formati di equazioni come LaTeX, faticano a scrivere il codice per MathML poiché quest’ultimo è destinato a essere generato automaticamente dalle applicazioni. I programmi leggono e analizzano MathML facilmente perché il suo codice è in XML, quindi MathML è comunemente usato come formato di output e stampa in molti settori. 

Questo esempio di codice mostra come esportare un’equazione matematica da una presentazione a MathML:

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

**Cosa viene esattamente esportato in MathML—un paragrafo o un blocco di formula individuale?**

Puoi esportare sia un intero paragrafo matematico ([MathParagraph](https://reference.aspose.com/slides/it/net/aspose.slides.mathtext/mathparagraph/)) sia un blocco individuale ([MathBlock](https://reference.aspose.com/slides/it/net/aspose.slides.mathtext/mathblock/)) in MathML. Entrambi i tipi forniscono un metodo per scrivere in MathML.

**Come posso capire se un oggetto su una diapositiva è una formula matematica piuttosto che testo normale o un'immagine?**

Una formula è contenuta in un [MathPortion](https://reference.aspose.com/slides/it/net/aspose.slides.mathtext/mathportion/) e ha un [MathParagraph](https://reference.aspose.com/slides/it/net/aspose.slides.mathtext/mathparagraph/). Le immagini e le porzioni di testo normale senza un [MathParagraph](https://reference.aspose.com/slides/it/net/aspose.slides.mathtext/mathparagraph/) non sono formule esportabili.

**Da dove proviene il MathML in una presentazione—è specifico di PowerPoint o è uno standard?**

L’esportazione mira allo standard MathML (XML). Aspose utilizza Presentation MathML—il sottoinsieme di presentazione dello standard—che è ampiamente usato in molte applicazioni e sul web.

**L'esportazione di formule all'interno di tabelle, SmartArt, gruppi, ecc., è supportata?**

Sì, se quegli oggetti contengono porzioni di testo con un [MathParagraph](https://reference.aspose.com/slides/it/net/aspose.slides.mathtext/mathparagraph/) (cioè vere formule PowerPoint), vengono esportati. Se una formula è incorporata come immagine, non lo è.

**L'esportazione in MathML modifica la presentazione originale?**

No. Scrivere MathML è una serializzazione del contenuto della formula; non modifica il file della presentazione.