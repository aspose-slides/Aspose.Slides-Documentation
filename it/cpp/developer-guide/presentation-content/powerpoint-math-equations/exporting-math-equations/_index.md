---
title: Esporta equazioni matematiche dalle presentazioni in C++
linktitle: Esporta Equazioni
type: docs
weight: 30
url: /it/cpp/exporting-math-equations/
keywords:
- esporta equazioni matematiche
- MathML
- LaTeX
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Sblocca l'esportazione senza soluzione di continuità delle equazioni matematiche da PowerPoint a MathML con Aspose.Slides per C++ — conserva la formattazione e aumenta la compatibilità."
---
## **Introduzione**

Aspose.Slides for C++ ti consente di esportare equazioni matematiche dalle presentazioni. Ad esempio, potresti dover estrarre le equazioni matematiche dalle diapositive (da una presentazione specifica) e usarle in un altro programma o piattaforma. 

{{% alert color="primary" %}} 

Puoi esportare le equazioni in MathML, un formato o standard popolare per le equazioni matematiche e contenuti simili visualizzati sul web e in molte applicazioni. 

{{% /alert %}}

## **Salva le equazioni matematiche come MathML**

Mentre gli esseri umani scrivono facilmente il codice per alcuni formati di equazioni come LaTeX, faticano a scrivere il codice per MathML perché quest'ultimo è destinato a essere generato automaticamente dalle applicazioni. I programmi leggono e analizzano MathML facilmente perché il suo codice è in XML, quindi MathML è comunemente usato come formato di output e stampa in molti settori. 

Questo esempio di codice mostra come esportare un'equazione matematica da una presentazione a MathML:

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

auto autoShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddMathShape(0.0f, 0.0f, 500.0f, 50.0f);
auto mathPortion = System::ExplicitCast<IMathPortion>(autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0));
auto mathParagraph = mathPortion->get_MathParagraph();

mathParagraph->Add(System::MakeObject<MathematicalText>(u"a")
        - >SetSuperscript(u"2")
        - >Join(u"+")
        - >Join(System::MakeObject<MathematicalText>(u"b")
                - >SetSuperscript(u"2"))
        - >Join(u"=")
        - >Join(System::MakeObject<MathematicalText>(u"c")
                - >SetSuperscript(u"2")));

SharedPtr<Stream> stream = System::MakeObject<FileStream>(u"mathml.xml", FileMode::Create);

mathParagraph->WriteAsMathMl(stream);
```

## **FAQ**

**Cosa viene esportato esattamente in MathML—un paragrafo o un singolo blocco di formula?**

Puoi esportare sia un intero paragrafo matematico ([MathParagraph](https://reference.aspose.com/slides/it/cpp/aspose.slides.mathtext/mathparagraph/)) sia un singolo blocco ([MathBlock](https://reference.aspose.com/slides/it/cpp/aspose.slides.mathtext/mathblock/)) in MathML. Entrambi i tipi forniscono un metodo per scrivere in MathML.

**Come posso capire se un oggetto su una diapositiva è una formula matematica anziché testo normale o un'immagine?**

Una formula si trova in una [MathPortion](https://reference.aspose.com/slides/it/cpp/aspose.slides.mathtext/mathportion/) e ha un [MathParagraph](https://reference.aspose.com/slides/it/cpp/aspose.slides.mathtext/mathparagraph/). Le immagini e le porzioni di testo normale senza un [MathParagraph](https://reference.aspose.com/slides/it/cpp/aspose.slides.mathtext/mathparagraph/) non sono formule esportabili.

**Da dove proviene MathML in una presentazione—è specifico di PowerPoint o è uno standard?**

L'esportazione è rivolta a MathML standard (XML). Aspose utilizza Presentation MathML—il sottoinsieme di presentazione dello standard—che è ampiamente usato in applicazioni e sul web.

**L'esportazione di formule all'interno di tabelle, SmartArt, gruppi, ecc., è supportata?**

Sì, se quegli oggetti contengono porzioni di testo con un [MathParagraph](https://reference.aspose.com/slides/it/cpp/aspose.slides.mathtext/mathparagraph/) (cioè vere formule di PowerPoint), vengono esportati. Se una formula è incorporata come immagine, non lo è.

**L'esportazione in MathML modifica la presentazione originale?**

No. Scrivere MathML è una serializzazione del contenuto della formula; non modifica il file della presentazione.