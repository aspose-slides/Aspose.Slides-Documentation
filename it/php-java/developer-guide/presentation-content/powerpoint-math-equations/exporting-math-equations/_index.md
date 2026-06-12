---
title: "Esporta Equazioni Matematiche dalle Presentazioni in PHP"
linktitle: "Esporta Equazioni"
type: docs
weight: 30
url: /it/php-java/exporting-math-equations/
keywords:
  - "esporta equazioni matematiche"
  - "MathML"
  - "LaTeX"
  - "PowerPoint"
  - "presentazione"
  - "PHP"
  - "Aspose.Slides"
description: "Sblocca l'esportazione senza soluzione di continuità delle equazioni matematiche da PowerPoint a MathML usando Aspose.Slides per PHP via Java — conserva la formattazione e migliora la compatibilità."
---
## **Introduzione**

Aspose.Slides per PHP via Java consente di esportare le equazioni matematiche dalle presentazioni. Ad esempio, potresti aver bisogno di estrarre le equazioni matematiche dalle diapositive (da una presentazione specifica) e usarle in un altro programma o piattaforma.

{{% alert color="primary" %}} 

Puoi esportare le equazioni in MathML, un formato o standard popolare per equazioni matematiche e contenuti simili visualizzati sul web e in molte applicazioni. 

{{% /alert %}}

## **Salva le equazioni matematiche come MathML**

Mentre gli esseri umani scrivono facilmente il codice per alcuni formati di equazioni come LaTeX, faticano a scrivere il codice per MathML perché quest’ultimo è destinato a essere generato automaticamente dalle app. I programmi leggono e analizzano MathML facilmente perché il suo codice è in XML, quindi MathML è comunemente usato come formato di output e stampa in molti settori. 

Questo esempio di codice mostra come esportare un’equazione matematica da una presentazione in MathML:

```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addMathShape(0, 0, 500, 50);
    $mathParagraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();
    $mathParagraph->add(new MathematicalText("a")->setSuperscript("2")->join("+")->join(new MathematicalText("b")->setSuperscript("2"))->join("=")->join(new MathematicalText("c")->setSuperscript("2")));
    $stream = new Java("java.io.FileOutputStream", "mathml.xml");
    $mathParagraph->writeAsMathMl($stream);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Cosa viene esportato esattamente in MathML—un paragrafo o un singolo blocco di formula?**

Puoi esportare un intero paragrafo matematico ([MathParagraph](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathparagraph/)) o un singolo blocco ([MathBlock](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathblock/)) in MathML. Entrambi i tipi forniscono un metodo per scrivere in MathML.

**Come posso capire se un oggetto su una diapositiva è una formula matematica piuttosto che testo normale o un’immagine?**

Una formula risiede in una [MathPortion](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathportion/) e ha un [MathParagraph](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathparagraph/). Le immagini e le porzioni di testo normale senza un [MathParagraph](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathparagraph/) non sono formule esportabili.

**Da dove proviene il MathML in una presentazione—è specifico di PowerPoint o è uno standard?**

L’esportazione mira a MathML standard (XML). Aspose utilizza Presentation MathML—il sottoinsieme di presentazione dello standard—che è ampiamente usato nelle applicazioni e sul web.

**È supportata l’esportazione di formule all’interno di tabelle, SmartArt, gruppi, ecc.?**

Sì, se quegli oggetti contengono porzioni di testo con un [MathParagraph](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathparagraph/) (cioè vere formule PowerPoint), vengono esportate. Se una formula è incorporata come immagine, non lo è.

**L’esportazione in MathML modifica la presentazione originale?**

No. Scrivere MathML è una serializzazione del contenuto della formula; non modifica il file della presentazione.