---
title: Esporta equazioni matematiche dalle presentazioni in JavaScript
linktitle: Esporta Equazioni
type: docs
weight: 30
url: /it/nodejs-java/exporting-math-equations/
keywords:
- esporta equazioni matematiche
- esporta equazioni in LaTeX
- PowerPoint in LaTeX
- MathML
- LaTeX
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Esporta equazioni matematiche da presentazioni PowerPoint in LaTeX o MathML direttamente con Aspose.Slides per Node.js tramite Java."
---
## **Introduzione**

Aspose.Slides consente di esportare le equazioni matematiche dalle presentazioni. Ad esempio, potresti aver bisogno di estrarre le equazioni matematiche dalle diapositive (da una presentazione specifica) e usarle in un altro programma o piattaforma. 

{{% alert color="primary" %}} 
Puoi esportare le equazioni direttamente in LaTeX o in MathML, uno standard popolare per contenuti matematici utilizzato sul Web e in molte applicazioni.
{{% /alert %}}

## **Esporta Equazioni Matematiche in LaTeX**

Aspose.Slides può convertire un'equazione matematica di PowerPoint direttamente in LaTeX; non è necessario un file MathML intermedio né un convertitore esterno. Un'equazione matematica è memorizzata in un riquadro di testo come [MathPortion](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/mathportion/). Usa [MathPortion.getMathParagraph](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/mathportion/#getMathParagraph--) per ottenere un [MathParagraph](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/mathparagraph/), quindi chiama [MathParagraph.toLatex](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/mathparagraph/#toLatex--). Il metodo restituisce una stringa che puoi salvare, visualizzare, inviare a un'altra applicazione o elaborare ulteriormente.

L'esempio seguente esamina ogni riquadro di testo su ogni diapositiva, trova tutte le porzioni matematiche e scrive ciascuna equazione in un file `.tex` separato:

```javascript
const presentation = new aspose.slides.Presentation("equations.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const slideNumber = slideIndex + 1;
        let equationNumber = 1;
        const textFrames = aspose.slides.SlideUtil.getAllTextBoxes(slide);

        for (const textFrame of textFrames) {
            const paragraphCount = textFrame.getParagraphs().getCount();
            for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
                const portionCount = paragraph.getPortions().getCount();
                for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    if (!java.instanceOf(portion, "com.aspose.slides.MathPortion")) {
                        continue;
                    }

                    const mathParagraph = portion.getMathParagraph();
                    const latexFileName = `slide_${slideNumber}_equation_${equationNumber}.tex`;

                    const latexText = mathParagraph.toLatex();
                    fileSystem.writeFileSync(latexFileName, latexText, "utf8");
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slideutil/#getAllTextBoxes-aspose.slides.IBaseSlide-) restituisce tutti i riquadri di testo trovati su una diapositiva. Il controllo del tipo [MathPortion](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/mathportion/) separa le vere equazioni modificabili dal testo ordinario e dalle immagini.

I motori LaTeX e i modelli di documento non supportano tutti gli stessi comandi, pacchetti o caratteri Unicode. Testa la stringa restituita con il motore LaTeX usato dalla tua applicazione. Se un simbolo o un elemento Office Math non ha una rappresentazione adeguata in quell'ambiente, sostituiscilo nella stringa restituita con un comando specifico del progetto oppure ignora l'equazione e registra il problema per una revisione.

## **Salva Equazioni Matematiche come MathML**

Mentre gli esseri umani scrivono facilmente il codice per alcuni formati di equazioni come LaTeX, faticano a scrivere il codice per MathML perché quest'ultimo è destinato a essere generato automaticamente dalle app. I programmi leggono e analizzano MathML facilmente perché il suo codice è XML, quindi MathML è comunemente usato come formato di output e stampa in molti settori. 

Questo esempio di codice mostra come esportare un'equazione matematica da una presentazione a MathML:

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

**Che cosa viene esattamente esportato in MathML—un paragrafo o un singolo blocco di formula?**

Puoi esportare sia un intero paragrafo matematico ([MathParagraph](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/mathparagraph/)) sia un singolo blocco ([MathBlock](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/mathblock/)) in MathML. Entrambi i tipi forniscono un metodo per scrivere in MathML.

**Come posso capire se un oggetto su una diapositiva è una formula matematica anziché testo normale o un'immagine?**

Una formula si trova in una [MathPortion](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/mathportion/) e ha un [MathParagraph](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/mathparagraph/). Immagini e porzioni di testo regolari senza un [MathParagraph](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/mathparagraph/) non sono formule esportabili.

**Da dove proviene il MathML in una presentazione—è specifico di PowerPoint o è uno standard?**

L'esportazione punta a MathML standard (XML). Aspose utilizza Presentation MathML, il sottoinsieme di presentazione dello standard, ampiamente usato in applicazioni e sul Web.

**L'esportazione di formule all'interno di tabelle, SmartArt, gruppi, ecc. è supportata?**

Sì, se quegli oggetti contengono porzioni di testo con un [MathParagraph](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/mathparagraph/) (cioè vere formule PowerPoint), vengono esportate. Se una formula è incorporata come immagine, non lo è.

**L'esportazione in MathML modifica la presentazione originale?**

No. Scrivere MathML è una serializzazione del contenuto della formula; non modifica il file della presentazione.