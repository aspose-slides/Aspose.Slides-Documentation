---
title: Esporta Equazioni Matematiche dalle Presentazioni su Android
linktitle: Esporta Equazioni
type: docs
weight: 30
url: /it/androidjava/exporting-math-equations/
keywords:
- esporta equazioni matematiche
- MathML
- LaTeX
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Sblocca l'esportazione fluida delle equazioni matematiche da PowerPoint a MathML usando Aspose.Slides per Android via Java—preserva la formattazione e aumenta la compatibilità."
---
## **Introduzione**

Aspose.Slides per Android via Java consente di esportare le equazioni matematiche dalle presentazioni. Ad esempio, potresti dover estrarre le equazioni matematiche dalle diapositive (da una presentazione specifica) e utilizzarle in un altro programma o piattaforma.

{{% alert color="primary" %}} 
Puoi esportare le equazioni in MathML, un formato o standard popolare per le equazioni matematiche e contenuti simili visualizzati sul web e in molte applicazioni. 
{{% /alert %}}

## **Esporta Equazioni Matematiche dalle Presentazioni**

Mentre gli esseri umani scrivono facilmente il codice per alcuni formati di equazioni come LaTeX, faticano a scrivere il codice per MathML perché quest'ultimo è destinato a essere generato automaticamente dalle app. I programmi leggono e analizzano MathML facilmente perché il suo codice è in XML, quindi MathML è comunemente usato come formato di output e stampa in molti settori. 

Questo esempio di codice mostra come esportare un'equazione matematica da una presentazione a MathML:

```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50);
    IMathParagraph mathParagraph = ((MathPortion)autoShape.getTextFrame().getParagraphs().get_Item(0).
            getPortions().get_Item(0)).getMathParagraph();

    mathParagraph.add(new MathematicalText("a").
            setSuperscript("2").
            join("+").
            join(new MathematicalText("b").setSuperscript("2")).
            join("=").
            join(new MathematicalText("c").setSuperscript("2")));

    FileOutputStream stream = new FileOutputStream("mathml.xml");
    mathParagraph.writeAsMathMl(stream);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Che cosa viene esportato esattamente in MathML—un paragrafo o un singolo blocco di formula?**

Puoi esportare sia un intero paragrafo matematico ([MathParagraph](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/mathparagraph/)) sia un singolo blocco ([MathBlock](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/mathblock/)) in MathML. Entrambi i tipi forniscono un metodo per scrivere in MathML.

**Come posso capire se un oggetto su una diapositiva è una formula matematica anziché testo normale o un'immagine?**

Una formula risiede in una [MathPortion](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/mathportion/) e ha un [MathParagraph](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/mathparagraph/). Le immagini e le porzioni di testo normali senza un [MathParagraph](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/mathparagraph/) non sono formule esportabili.

**Da dove proviene il MathML in una presentazione—è specifico di PowerPoint o è uno standard?**

L'esportazione mira a MathML standard (XML). Aspose utilizza Presentation MathML—il sottoinsieme di presentazione dello standard—che è ampiamente utilizzato in applicazioni e sul web.

**L'esportazione di formule all'interno di tabelle, SmartArt, gruppi, ecc. è supportata?**

Sì, se quegli oggetti contengono porzioni di testo con un [MathParagraph](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/mathparagraph/) (cioè vere formule PowerPoint), vengono esportati. Se una formula è incorporata come immagine, non lo è.

**L'esportazione in MathML modifica la presentazione originale?**

No. Scrivere MathML è una serializzazione del contenuto della formula; non modifica il file della presentazione.