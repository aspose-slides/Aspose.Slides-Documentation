---
title: Estrazione avanzata di testo dalle presentazioni in PHP
linktitle: Estrai testo
type: docs
weight: 90
url: /it/php-java/extract-text-from-presentation/
keywords:
- estrarre testo
- estrarre testo dalla diapositiva
- estrarre testo dalla presentazione
- estrarre testo da PowerPoint
- estrarre testo da OpenDocument
- estrarre testo da PPT
- estrarre testo da PPTX
- estrarre testo da ODP
- recuperare testo
- recuperare testo dalla diapositiva
- recuperare testo dalla presentazione
- recuperare testo da PowerPoint
- recuperare testo da OpenDocument
- recuperare testo da PPT
- recuperare testo da PPTX
- recuperare testo da ODP
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Estrai rapidamente testo da presentazioni PowerPoint e OpenDocument usando Aspose.Slides per PHP via Java. Segui la nostra guida semplice, passo dopo passo, per risparmiare tempo."
---
## **Panoramica**

L'estrazione di testo dalle presentazioni è un compito comune ma essenziale per gli sviluppatori che lavorano con contenuti delle diapositive. Che tu stia gestendo file Microsoft PowerPoint in formato PPT o PPTX, o presentazioni OpenDocument (ODP), accedere e recuperare i dati testuali può essere fondamentale per analisi, automazione, indicizzazione o migrazione di contenuti.

Questo articolo fornisce una guida completa su come estrarre in modo efficiente testo da vari formati di presentazione, inclusi PPT, PPTX e ODP, utilizzando Aspose.Slides per PHP via Java. Imparerai come iterare sistematicamente attraverso gli elementi della presentazione per recuperare con precisione il contenuto testuale di cui hai bisogno.

## **Estrarre testo da una diapositiva**

Aspose.Slides per PHP via Java fornisce la classe [SlideUtil](https://reference.aspose.com/slides/it/php-java/aspose.slides/slideutil/). Questa classe espone diversi metodi statici sovraccarichi per estrarre tutto il testo da una presentazione o da una diapositiva. Per estrarre testo da una diapositiva in una presentazione, usa il metodo [getAllTextBoxes](https://reference.aspose.com/slides/it/php-java/aspose.slides/slideutil/#getAllTextBoxes). Questo metodo accetta un oggetto di tipo [BaseSlide](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseslide/) come parametro. Quando viene eseguito, il metodo scansione l'intera diapositiva alla ricerca di testo e restituisce un array di oggetti di tipo [TextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/), preservando qualsiasi formattazione del testo.

Il frammento di codice seguente estrae tutto il testo dalla prima diapositiva della presentazione:

```php
$slideIndex = 0;

$presentation = new Presentation("demo.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $slide = $presentation->getSlides()->get_Item($slideIndex);

    $textFrames = SlideUtil::getAllTextBoxes($slide);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        foreach ($textFrames[$textFrameIndex]->getParagraphs() as $paragraph) {
            foreach ($paragraph->getPortions() as $portion) {
                $portionText = $portion->getText();
                echo($portionText);

                $portionFormat = $portion->getPortionFormat();
                $fontHeight = $portionFormat->getFontHeight();
                echo($fontHeight);

                $latinFont = $portionFormat->getLatinFont();
                if (!java_is_null($latinFont)) {
                    $fontName = $latinFont->getFontName();
                    echo($fontName);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Estrarre testo da una presentazione**

Per scansionare il testo dall'intera presentazione, usa il metodo statico [getAllTextFrames](https://reference.aspose.com/slides/it/php-java/aspose.slides/slideutil/#getAllTextFrames) esposto dalla classe [SlideUtil](https://reference.aspose.com/slides/it/php-java/aspose.slides/slideutil/). Accetta due parametri:

1. Prima, un oggetto [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) che rappresenta una presentazione PowerPoint o OpenDocument da cui verrà estratto il testo.
1. Secondo, un valore `boolean` che indica se includere le diapositive master durante la scansione del testo dalla presentazione.

Il metodo restituisce un array di oggetti di tipo [TextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/), includendo le informazioni di formattazione del testo. Il codice sottostante scansiona il testo e i dettagli di formattazione da una presentazione, incluse le diapositive master.

```php
$presentation = new Presentation("demo.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $includeMasterSlides = true;
    $textFrames = SlideUtil::getAllTextFrames($presentation, $includeMasterSlides);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        foreach ($textFrames[$textFrameIndex]->getParagraphs() as $paragraph) {
            foreach ($paragraph->getPortions() as $portion) {
                $portionText = $portion->getText();
                echo($portionText);

                $portionFormat = $portion->getPortionFormat();
                $fontHeight = $portionFormat->getFontHeight();
                echo($fontHeight);

                $latinFont = $portionFormat->getLatinFont();
                if (!java_is_null($latinFont)) {
                    $fontName = $latinFont->getFontName();
                    echo($fontName);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Estrazione di testo categorizzata e rapida**

La classe [PresentationFactory](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationfactory/) fornisce anche metodi per estrarre tutto il testo dalle presentazioni:

```php
PresentationText getPresentationText(String, int);
PresentationText getPresentationText(InputStream, int);
PresentationText getPresentationText(InputStream, int, LoadOptions);
```

L'argomento enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/it/php-java/aspose.slides/textextractionarrangingmode/) indica la modalità per organizzare il risultato dell'estrazione del testo e può essere impostato sui seguenti valori:
- `Unarranged` - Il testo grezzo senza considerare la sua posizione sulla diapositiva.
- `Arranged` - Il testo è disposto nello stesso ordine della diapositiva.

La modalità non organizzata può essere usata quando la velocità è critica; è più veloce della modalità organizzata.

[PresentationText](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationtext/) rappresenta il testo grezzo estratto dalla presentazione. Il suo metodo `getSlidesText` restituisce un array di oggetti in cui ogni oggetto rappresenta il testo della diapositiva corrispondente. Ogni oggetto restituito dispone dei seguenti metodi:

- `getText` - Il testo all'interno delle forme della diapositiva.
- `getMasterText` - Il testo all'interno delle forme della diapositiva master associate a questa diapositiva.
- `getLayoutText` - Il testo all'interno delle forme della diapositiva layout associate a questa diapositiva.
- `getNotesText` - Il testo all'interno delle forme della diapositiva note associate a questa diapositiva.
- `getCommentsText` - Il testo all'interno dei commenti associati a questa diapositiva.

```php
$presentationPath = "presentation.ppt";
$arrangingMode = TextExtractionArrangingMode::Unarranged;
$presentationText = PresentationFactory::getInstance()->getPresentationText($presentationPath, $arrangingMode);
$slidesText = $presentationText->getSlidesText();
$firstSlideText = $slidesText[0];

echo($firstSlideText->getText());
echo($firstSlideText->getLayoutText());
echo($firstSlideText->getMasterText());
echo($firstSlideText->getNotesText());
echo($firstSlideText->getCommentsText());
```

## **FAQ**

**Quanto velocemente Aspose.Slides elabora grandi presentazioni durante l'estrazione del testo?**

Aspose.Slides è ottimizzato per alte prestazioni e può elaborare anche [presentazioni di grandi dimensioni](/slides/it/php-java/open-presentation/), rendendolo adatto a scenari di elaborazione in tempo reale o batch.

**Aspose.Slides può estrarre testo da tabelle e grafici all'interno delle presentazioni?**

Sì. Aspose.Slides può estrarre testo da molti elementi della diapositiva, incluse tabelle e oggetti correlati ai grafici, così da poter accedere e analizzare il contenuto testuale nelle strutture di presentazione più comuni.

**È necessaria una licenza speciale di Aspose.Slides per estrarre testo dalle presentazioni?**

Puoi estrarre testo utilizzando la versione di prova gratuita di Aspose.Slides, sebbene abbia [alcune limitazioni](/slides/it/php-java/licensing/), come l'elaborazione di un numero limitato di diapositive. Per un utilizzo senza restrizioni e per gestire presentazioni più grandi, è consigliato acquistare una licenza completa.