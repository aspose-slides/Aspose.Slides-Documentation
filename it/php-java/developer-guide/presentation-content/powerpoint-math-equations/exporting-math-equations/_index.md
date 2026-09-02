---
title: Esporta Equazioni Matematiche dalle Presentazioni in PHP
linktitle: Esporta Equazioni
type: docs
weight: 30
url: /it/php-java/exporting-math-equations/
keywords:
- esporta equazioni matematiche
- esporta equazioni in LaTeX
- PowerPoint in LaTeX
- MathML
- LaTeX
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Esporta equazioni matematiche dalle presentazioni PowerPoint in LaTeX o MathML direttamente con Aspose.Slides per PHP via Java."
---
## **Introduzione**

Aspose.Slides for PHP via Java consente di esportare equazioni matematiche dalle presentazioni. Ad esempio, potresti dover estrarre le equazioni matematiche dalle diapositive (da una presentazione specifica) e usarle in un altro programma o piattaforma.

{{% alert color="primary" %}} 
Puoi esportare le equazioni direttamente in LaTeX o in MathML, un popolare standard per contenuti matematici usato sul web e in molte applicazioni.
{{% /alert %}}

## **Esporta equazioni matematiche in LaTeX**

Aspose.Slides può convertire un'equazione matematica di PowerPoint direttamente in LaTeX; non è necessario un file MathML intermedio né un convertitore esterno. Un'equazione matematica è memorizzata in una casella di testo come un [MathPortion](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathportion/). Usa [MathPortion::getMathParagraph](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathportion/#getMathParagraph) per ottenere un [MathParagraph](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathparagraph/), e poi chiama [MathParagraph::toLatex](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathparagraph/#toLatex). Il metodo restituisce una stringa che puoi salvare, visualizzare, inviare a un'altra applicazione o elaborare ulteriormente.

Il seguente esempio esamina ogni casella di testo in ogni diapositiva, trova tutte le porzioni matematiche e scrive ogni equazione in un file `.tex` separato:

```php
$presentation = new Presentation("equations.pptx");
$arrayClass = new JavaClass("java.lang.reflect.Array");
$mathPortionClass = new JavaClass("com.aspose.slides.MathPortion");

try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = $slideIndex + 1;
        $equationNumber = 1;
        $textFrames = SlideUtil::getAllTextBoxes($slide);
        $textFrameCount = java_values($arrayClass->getLength($textFrames));

        for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
            $textFrame = $textFrames[$textFrameIndex];
            $paragraphCount = java_values($textFrame->getParagraphs()->getCount());
            for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
                $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                $portionCount = java_values($paragraph->getPortions()->getCount());
                for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    if (!java_instanceof($portion, $mathPortionClass)) {
                        continue;
                    }

                    $mathParagraph = $portion->getMathParagraph();
                    $latexFileName = "slide_" . $slideNumber . "_equation_" . $equationNumber . ".tex";

                    $latexText = java_values($mathParagraph->toLatex());
                    file_put_contents($latexFileName, $latexText);
                    $equationNumber++;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

[SlideUtil::getAllTextBoxes](https://reference.aspose.com/slides/it/php-java/aspose.slides/slideutil/#getAllTextBoxes) restituisce tutte le caselle di testo trovate su una diapositiva. Il controllo di tipo [MathPortion](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathportion/) separa le vere equazioni modificabili da testo e immagini ordinari.

I motori LaTeX e i modelli di documento non supportano tutti gli stessi comandi, pacchetti o caratteri Unicode. Prova la stringa restituita con il motore LaTeX usato dalla tua applicazione. Se un simbolo o un elemento Office Math non ha una rappresentazione adeguata in quell'ambiente, sostituiscilo nella stringa restituita con un comando specifico del progetto oppure ignora l'equazione e registra il problema per una revisione.

## **Salva le equazioni matematiche come MathML**

Mentre gli esseri umani scrivono facilmente il codice per alcuni formati di equazione come LaTeX, faticano a scrivere il codice per MathML perché quest'ultimo è destinato a essere generato automaticamente dalle app. I programmi leggono e analizzano MathML facilmente perché il suo codice è in XML, quindi MathML è comunemente usato come formato di output e di stampa in molti settori.

Questo codice di esempio mostra come esportare un'equazione matematica da una presentazione a MathML:

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

**Cosa viene esportato esattamente in MathML—un paragrafo o un blocco di formula individuale?**  
Puoi esportare sia un intero paragrafo matematico ([MathParagraph](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathparagraph/)) sia un blocco individuale ([MathBlock](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathblock/)) in MathML. Entrambi i tipi forniscono un metodo per scrivere in MathML.

**Come posso capire se un oggetto su una diapositiva è una formula matematica anziché testo ordinario o un'immagine?**  
Una formula risiede in un [MathPortion](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathportion/) e ha un [MathParagraph](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathparagraph/). Immagini e porzioni di testo regolari senza un [MathParagraph](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathparagraph/) non sono formule esportabili.

**Da dove proviene il MathML in una presentazione—è specifico di PowerPoint o è uno standard?**  
L'esportazione utilizza MathML standard (XML). Aspose usa Presentation MathML—il sottoinsieme di presentazione dello standard—che è ampiamente utilizzato in applicazioni e sul web.

**È supportata l'esportazione di formule all'interno di tabelle, SmartArt, gruppi, ecc.?**  
Sì, se quegli oggetti contengono porzioni di testo con un [MathParagraph](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathparagraph/) (cioè vere formule PowerPoint), vengono esportati. Se una formula è incorporata come immagine, non lo è.

**L'esportazione in MathML modifica la presentazione originale?**  
No. Scrivere MathML è una serializzazione del contenuto della formula; non altera il file della presentazione.