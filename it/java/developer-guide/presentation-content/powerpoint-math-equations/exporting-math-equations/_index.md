---
title: Esporta Equazioni Matematiche dalle Presentazioni in Java
linktitle: Esporta Equazioni
type: docs
weight: 30
url: /it/java/exporting-math-equations/
keywords:
- esporta equazioni matematiche
- esporta equazioni in LaTeX
- PowerPoint a LaTeX
- MathML
- LaTeX
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Esporta le equazioni matematiche dalle presentazioni PowerPoint in LaTeX o MathML direttamente con Aspose.Slides per Java."
---
## **Introduzione**

Aspose.Slides consente di esportare le equazioni matematiche dalle presentazioni. Ad esempio, potresti dover estrarre le equazioni matematiche dalle diapositive (da una presentazione specifica) e usarle in un altro programma o piattaforma.

{{% alert color="info" %}} 

Puoi esportare le equazioni direttamente in LaTeX o in MathML, uno standard molto diffuso per i contenuti matematici utilizzato sul web e in molte applicazioni.

{{% /alert %}}

## **Esporta Equazioni Matematiche in LaTeX**

Aspose.Slides può convertire un’equazione matematica di PowerPoint direttamente in LaTeX; non sono necessari file MathML intermedi né un convertitore esterno. Un’equazione matematica è memorizzata in una casella di testo come un [IMathPortion](https://reference.aspose.com/slides/it/java/com.aspose.slides/imathportion/). Usa [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/it/java/com.aspose.slides/imathportion/#getMathParagraph--) per ottenere un [IMathParagraph](https://reference.aspose.com/slides/it/java/com.aspose.slides/imathparagraph/), quindi chiama [IMathParagraph.toLatex](https://reference.aspose.com/slides/it/java/com.aspose.slides/imathparagraph/#toLatex--). Il metodo restituisce una stringa che puoi salvare, visualizzare, inviare a un’altra applicazione o elaborare ulteriormente.

L’esempio seguente analizza ogni casella di testo di ogni diapositiva, trova tutte le parti matematiche e scrive ciascuna equazione in un file `.tex` separato:

```java
Presentation presentation = new Presentation("equations.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slideIndex + 1;
        int equationNumber = 1;
        ITextFrame[] textFrames = SlideUtil.getAllTextBoxes(slide);

        for (ITextFrame textFrame : textFrames) {
            for (IParagraph paragraph : textFrame.getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    if (!(portion instanceof IMathPortion))
                        continue;

                    IMathPortion mathPortion = (IMathPortion) portion;
                    IMathParagraph mathParagraph = mathPortion.getMathParagraph();
                    String latexFileName = "slide_" + slideNumber + "_equation_" + equationNumber + ".tex";

                    String latexText = mathParagraph.toLatex();
                    Path latexPath = Paths.get(latexFileName);
                    byte[] latexBytes = latexText.getBytes(StandardCharsets.UTF_8);
                    Files.write(latexPath, latexBytes);
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/it/java/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) restituisce tutte le caselle di testo trovate su una diapositiva. Il controllo del tipo [IMathPortion](https://reference.aspose.com/slides/it/java/com.aspose.slides/imathportion/) separa le vere equazioni modificabili dal testo ordinario e dalle immagini.

I motori LaTeX e i modelli di documento non supportano tutti gli stessi comandi, pacchetti o caratteri Unicode. Verifica la stringa restituita con il motore LaTeX utilizzato dalla tua applicazione. Se un simbolo o un elemento Office Math non ha una rappresentazione adeguata in quell’ambiente, sostituiscilo nella stringa restituita con un comando specifico del progetto oppure ignora l’equazione e registra il problema per una revisione.

## **Salva Equazioni Matematiche come MathML**

Mentre gli esseri umani scrivono facilmente il codice per alcuni formati di equazioni come LaTeX, faticano a scrivere il codice per MathML perché quest’ultimo è pensato per essere generato automaticamente dalle app. I programmi leggono e analizzano MathML facilmente perché il suo codice è in XML, quindi MathML è comunemente usato come formato di output e di stampa in molti settori.

Questo esempio di codice mostra come esportare un’equazione matematica da una presentazione a MathML:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

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

**Cosa viene esattamente esportato in MathML—un paragrafo o un singolo blocco di formula?**

Puoi esportare sia un intero paragrafo matematico ([MathParagraph](https://reference.aspose.com/slides/it/java/com.aspose.slides/mathparagraph/)) sia un singolo blocco ([MathBlock](https://reference.aspose.com/slides/it/java/com.aspose.slides/mathblock/)) in MathML. Entrambi i tipi forniscono un metodo per scrivere in MathML.

**Come posso capire se un oggetto su una diapositiva è una formula matematica anziché testo normale o un’immagine?**

Una formula risiede in un [MathPortion](https://reference.aspose.com/slides/it/java/com.aspose.slides/mathportion/) e ha un [MathParagraph](https://reference.aspose.com/slides/it/java/com.aspose.slides/mathparagraph/). Immagini e porzioni di testo regolari senza un [MathParagraph](https://reference.aspose.com/slides/it/java/com.aspose.slides/mathparagraph/) non sono formule esportabili.

**Da dove proviene il MathML in una presentazione—è specifico di PowerPoint o è uno standard?**

L’esportazione mira a MathML standard (XML). Aspose utilizza Presentation MathML—il sottoinsieme di presentazione dello standard—che è ampiamente adottato in applicazioni e sul web.

**È supportata l’esportazione di formule all’interno di tabelle, SmartArt, raggruppamenti, ecc.?**

Sì, se quegli oggetti contengono porzioni di testo con un [MathParagraph](https://reference.aspose.com/slides/it/java/com.aspose.slides/mathparagraph/) (cioè vere formule PowerPoint), vengono esportate. Se una formula è incorporata come immagine, non lo è.

**L’esportazione in MathML modifica la presentazione originale?**

No. Scrivere MathML è una serializzazione del contenuto della formula; non modifica il file della presentazione.