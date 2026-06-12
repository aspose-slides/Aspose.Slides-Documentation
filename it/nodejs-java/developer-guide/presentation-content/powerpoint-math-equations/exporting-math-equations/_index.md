---
title: Esporta equazioni matematiche dalle presentazioni in JavaScript
linktitle: Esporta equazioni
type: docs
weight: 30
url: /it/nodejs-java/exporting-math-equations/
keywords:
- esporta equazioni matematiche
- MathML
- LaTeX
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Sblocca l'esportazione fluida di equazioni matematiche da PowerPoint a MathML usando JavaScript e Aspose.Slides per Node.js—preserva la formattazione e migliora la compatibilità."
---
## **Introduzione**

Aspose.Slides consente di esportare equazioni matematiche dalle presentazioni. Ad esempio, potresti dover estrarre le equazioni matematiche dalle diapositive (da una presentazione specifica) e usarle in un altro programma o piattaforma. 

{{% alert color="primary" %}} 

Puoi esportare le equazioni in MathML, un formato o standard popolare per le equazioni matematiche e contenuti simili visualizzati sul web e in molte applicazioni. 

{{% /alert %}}

## **Salva le equazioni matematiche in MathML**

Mentre gli esseri umani scrivono facilmente il codice per alcuni formati di equazioni come LaTeX, faticano a scrivere il codice per MathML perché quest'ultimo è destinato a essere generato automaticamente dalle app. I programmi leggono e analizzano MathML facilmente perché il suo codice è in XML, quindi MathML è comunemente usato come formato di output e stampa in molti settori. 

Questo esempio di codice mostra come esportare un'equazione matematica da una presentazione in MathML:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50);
    var mathParagraph = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
    mathParagraph.add(new aspose.slides.MathematicalText("a").setSuperscript("2").join("+").join(new aspose.slides.MathematicalText("b").setSuperscript("2")).join("=").join(new aspose.slides.MathematicalText("c").setSuperscript("2")));
    var stream = null;
    mathParagraph.writeAsMathMl(stream);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Cosa viene esportato esattamente in MathML: un paragrafo o un blocco di formula individuale?**

Puoi esportare un intero paragrafo matematico ([MathParagraph](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/mathparagraph/)) o un blocco individuale ([MathBlock](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/mathblock/)) in MathML. Entrambi i tipi forniscono un metodo per scrivere in MathML.

**Come posso capire se un oggetto su una diapositiva è una formula matematica anziché testo normale o un'immagine?**

Una formula si trova in una [MathPortion](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/mathportion/) e ha un [MathParagraph](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/mathparagraph/). Le immagini e le porzioni di testo normale senza un [MathParagraph](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/mathparagraph/) non sono formule esportabili.

**Da dove proviene il MathML in una presentazione: è specifico di PowerPoint o è uno standard?**

L'esportazione utilizza MathML standard (XML). Aspose usa Presentation MathML—il sottoinsieme di presentazione dello standard—che è ampiamente usato nelle applicazioni e sul web.

**L'esportazione di formule all'interno di tabelle, SmartArt, gruppi, ecc., è supportata?**

Sì, se quegli oggetti contengono porzioni di testo con un [MathParagraph](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/mathparagraph/) (cioè vere formule PowerPoint), vengono esportati. Se una formula è incorporata come immagine, non lo è.

**L'esportazione in MathML modifica la presentazione originale?**

No. Scrivere MathML è una serializzazione del contenuto della formula; non modifica il file della presentazione.