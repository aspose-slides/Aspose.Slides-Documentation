---
title: Estrazione avanzata di testo dalle presentazioni su Android
linktitle: Estrai testo
type: docs
weight: 90
url: /it/androidjava/extract-text-from-presentation/
keywords:
- estrarre testo
- estrarre testo da diapositiva
- estrarre testo da presentazione
- estrarre testo da PowerPoint
- estrarre testo da OpenDocument
- estrarre testo da PPT
- estrarre testo da PPTX
- estrarre testo da ODP
- recuperare testo
- recuperare testo da diapositiva
- recuperare testo da presentazione
- recuperare testo da PowerPoint
- recuperare testo da OpenDocument
- recuperare testo da PPT
- recuperare testo da PPTX
- recuperare testo da ODP
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Estrai rapidamente testo da presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per Android via Java. Segui la nostra semplice guida passo passo per risparmiare tempo."
---
## **Panoramica**

L'estrazione del testo dalle presentazioni è un compito comune ma fondamentale per gli sviluppatori che lavorano con contenuti delle diapositive. Che tu stia gestendo file Microsoft PowerPoint in formato PPT o PPTX, o presentazioni OpenDocument (ODP), accedere e recuperare i dati testuali può essere fondamentale per analisi, automazione, indicizzazione o migrazione dei contenuti.

Questo articolo fornisce una guida completa su come estrarre in modo efficiente il testo da vari formati di presentazione, inclusi PPT, PPTX e ODP, utilizzando Aspose.Slides per Android via Java. Imparerai come iterare sistematicamente gli elementi della presentazione per recuperare accuratamente il contenuto testuale di cui hai bisogno.

## **Estrarre testo da una diapositiva**

Aspose.Slides per Android via Java fornisce la classe [SlideUtil](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slideutil/) . Questa classe espone diversi metodi statici sovraccaricati per estrarre tutto il testo da una presentazione o da una diapositiva. Per estrarre il testo da una diapositiva in una presentazione, usa il metodo [getAllTextBoxes](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) . Questo metodo accetta un oggetto di tipo [IBaseSlide](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ibaseslide/) come parametro. Quando eseguito, il metodo analizza l'intera diapositiva alla ricerca di testo e restituisce un array di oggetti di tipo [ITextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/), preservando qualsiasi formattazione del testo.

Il seguente frammento di codice estrae tutto il testo dalla prima diapositiva della presentazione:

```java
int slideIndex = 0;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(slideIndex);

    ITextFrame[] textFrames = SlideUtil.getAllTextBoxes(slide);

    for (ITextFrame textFrame : textFrames) {
        for (IParagraph paragraph : textFrame.getParagraphs()) {
            for (IPortion portion : paragraph.getPortions()) {
                String portionText = portion.getText();
                System.out.println(portionText);

                IPortionFormat portionFormat = portion.getPortionFormat();
                float fontHeight = portionFormat.getFontHeight();
                System.out.println(fontHeight);

                IFontData latinFont = portionFormat.getLatinFont();
                if (latinFont != null) {
                    String fontName = latinFont.getFontName();
                    System.out.println(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Estrarre testo da una presentazione**

Per analizzare il testo dell'intera presentazione, usa il metodo statico [getAllTextFrames](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) esposto dalla classe [SlideUtil](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slideutil/) . Accetta due parametri:

1. In primo luogo, un oggetto [IPresentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentation/) che rappresenta una presentazione PowerPoint o OpenDocument da cui verrà estratto il testo.
1. In secondo luogo, un valore `boolean` che indica se le diapositive master devono essere incluse durante l'analisi del testo della presentazione.

Il metodo restituisce un array di oggetti di tipo [ITextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/), includendo le informazioni di formattazione del testo. Il codice seguente analizza il testo e i dettagli di formattazione da una presentazione, incluse le diapositive master.

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    boolean includeMasterSlides = true;
    ITextFrame[] textFrames = SlideUtil.getAllTextFrames(presentation, includeMasterSlides);

    for (ITextFrame textFrame : textFrames) {
        for (IParagraph paragraph : textFrame.getParagraphs()) {
            for (IPortion portion : paragraph.getPortions()) {
                String portionText = portion.getText();
                System.out.println(portionText);

                IPortionFormat portionFormat = portion.getPortionFormat();
                float fontHeight = portionFormat.getFontHeight();
                System.out.println(fontHeight);

                IFontData latinFont = portionFormat.getLatinFont();
                if (latinFont != null) {
                    String fontName = latinFont.getFontName();
                    System.out.println(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Estrazione di testo categorizzata e veloce**

La classe [PresentationFactory](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentationfactory/) fornisce anche metodi per estrarre tutto il testo dalle presentazioni:

```text
IPresentationText getPresentationText(String file, int mode);
IPresentationText getPresentationText(InputStream stream, int mode);
IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
```

L'argomento enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/textextractionarrangingmode/) indica la modalità per organizzare il risultato dell'estrazione del testo e può essere impostato sui seguenti valori:
- `Unarranged` - Il testo grezzo senza considerare la sua posizione nella diapositiva.
- `Arranged` - Il testo è organizzato nello stesso ordine della diapositiva.

La modalità non organizzata può essere usata quando la velocità è fondamentale; è più veloce della modalità organizzata.

[IPresentationText](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentationtext/) rappresenta il testo grezzo estratto dalla presentazione. Il suo metodo `getSlidesText` restituisce un array di oggetti di tipo [ISlideText](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islidetext/) . Ogni oggetto rappresenta il testo della diapositiva corrispondente. L'oggetto di tipo [ISlideText](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islidetext/) ha i seguenti metodi:

- `getText` - Il testo all'interno delle forme della diapositiva.
- `getMasterText` - Il testo all'interno delle forme della diapositiva master associate a questa diapositiva.
- `getLayoutText` - Il testo all'interno delle forme della diapositiva layout associate a questa diapositiva.
- `getNotesText` - Il testo all'interno delle forme della diapositiva note associate a questa diapositiva.
- `getCommentsText` - Il testo all'interno dei commenti associati a questa diapositiva.

```java
String presentationPath = "presentation.pptx";
int arrangingMode = TextExtractionArrangingMode.Unarranged;
IPresentationText presentationText = PresentationFactory.getInstance().getPresentationText(presentationPath, arrangingMode);
ISlideText firstSlideText = presentationText.getSlidesText()[0];

System.out.println(firstSlideText.getText());
System.out.println(firstSlideText.getLayoutText());
System.out.println(firstSlideText.getMasterText());
System.out.println(firstSlideText.getNotesText());
System.out.println(firstSlideText.getCommentsText());
```

## **FAQ**

**Quanto velocemente Aspose.Slides elabora grandi presentazioni durante l'estrazione del testo?**

Aspose.Slides è ottimizzato per alte prestazioni e può elaborare anche [presentazioni di grandi dimensioni](/slides/it/androidjava/open-presentation/), rendendolo adatto a scenari di elaborazione in tempo reale o in blocco.

**Aspose.Slides può estrarre testo da tabelle e grafici all'interno delle presentazioni?**

Sì. Aspose.Slides può estrarre testo da molti elementi della diapositiva, incluse tabelle e oggetti relativi a grafici, così da poter accedere e analizzare il contenuto testuale nelle strutture tipiche delle presentazioni.

**È necessaria una licenza speciale di Aspose.Slides per estrarre testo dalle presentazioni?**

Puoi estrarre testo utilizzando la versione di prova gratuita di Aspose.Slides, sebbene essa presenti [alcune limitazioni](/slides/it/androidjava/licensing/), come l'elaborazione di un numero limitato di diapositive. Per un utilizzo illimitato e per gestire presentazioni più grandi, si consiglia di acquistare una licenza completa.