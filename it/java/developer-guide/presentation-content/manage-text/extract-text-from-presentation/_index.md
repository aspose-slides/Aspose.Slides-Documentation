---
title: Estrazione avanzata di testo dalle presentazioni in Java
linktitle: Estrai testo
type: docs
weight: 90
url: /it/java/extract-text-from-presentation/
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
- Java
- Aspose.Slides
description: "Estrai rapidamente testo da presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per Java. Segui la nostra guida semplice, passo dopo passo, per risparmiare tempo."
---
## **Panoramica**

Estrazione del testo dalle presentazioni è un compito comune ma essenziale per gli sviluppatori che lavorano con i contenuti delle diapositive. Che tu stia gestendo file Microsoft PowerPoint in formato PPT o PPTX, o presentazioni OpenDocument (ODP), accedere e recuperare i dati testuali può essere fondamentale per analisi, automazione, indicizzazione o migrazione di contenuti.

Questo articolo fornisce una guida completa su come estrarre efficacemente il testo da vari formati di presentazione, inclusi PPT, PPTX e ODP, utilizzando Aspose.Slides for Java. Imparerai come iterare sistematicamente gli elementi della presentazione per recuperare con precisione il contenuto testuale di cui hai bisogno.

## **Estrarre testo da una diapositiva**

Aspose.Slides for Java fornisce la classe [SlideUtil](https://reference.aspose.com/slides/it/java/com.aspose.slides/slideutil/). Questa classe espone diversi metodi statici sovraccaricati per estrarre tutto il testo da una presentazione o da una diapositiva. Per estrarre il testo da una diapositiva in una presentazione, utilizza il metodo [SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/it/java/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-). Questo metodo accetta come parametro un oggetto di tipo [IBaseSlide](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibaseslide/). Quando viene eseguito, il metodo esamina l'intera diapositiva alla ricerca di testo e restituisce un array di oggetti di tipo [ITextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/), preservando qualsiasi formattazione del testo.

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

Per esaminare il testo dell'intera presentazione, utilizza il metodo statico [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/it/java/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) esposto dalla classe [SlideUtil](https://reference.aspose.com/slides/it/java/com.aspose.slides/slideutil/). Accetta due parametri:

1. Primo, un oggetto [IPresentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentation/) che rappresenta una presentazione PowerPoint o OpenDocument da cui verrà estratto il testo.
2. Secondo, un valore `boolean` che indica se le diapositive master devono essere incluse durante la scansione del testo della presentazione.

Il metodo restituisce un array di oggetti di tipo [ITextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/), includendo le informazioni di formattazione del testo. Il codice sottostante esamina il testo e i dettagli della formattazione da una presentazione, includendo le diapositive master.

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

## **Estrazione testuale categorizzata e rapida**

La classe [PresentationFactory](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentationfactory/) fornisce anche metodi per estrarre tutto il testo dalle presentazioni:

```java
IPresentationText getPresentationText(String file, int mode);
IPresentationText getPresentationText(InputStream stream, int mode);
IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
```

Il parametro enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/it/java/com.aspose.slides/textextractionarrangingmode/) indica la modalità di organizzazione del risultato dell'estrazione del testo e può essere impostato sui seguenti valori:

- `Unarranged` - Il testo grezzo senza considerare la sua posizione sulla diapositiva.
- `Arranged` - Il testo è organizzato nello stesso ordine della diapositiva.

La modalità `Unarranged` può essere utilizzata quando la velocità è fondamentale; è più veloce della modalità `Arranged`.

La [IPresentationText](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentationtext/) rappresenta il testo grezzo estratto dalla presentazione. Il suo metodo `getSlidesText` restituisce un array di oggetti di tipo [ISlideText](https://reference.aspose.com/slides/it/java/com.aspose.slides/islidetext/). Ogni oggetto rappresenta il testo sulla diapositiva corrispondente. L'oggetto di tipo [ISlideText](https://reference.aspose.com/slides/it/java/com.aspose.slides/islidetext/) dispone dei seguenti metodi:

- `getText` - Il testo all'interno delle forme della diapositiva.
- `getMasterText` - Il testo all'interno delle forme della diapositiva master associate a questa diapositiva.
- `getLayoutText` - Il testo all'interno delle forme della diapositiva layout associate a questa diapositiva.
- `getNotesText` - Il testo all'interno delle forme della diapositiva note associate a questa diapositiva.
- `getCommentsText` - Il testo all'interno dei commenti associati a questa diapositiva.

```java
String presentationPath = "presentation.ppt";
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

Aspose.Slides è ottimizzato per alte prestazioni e può elaborare anche [grandi presentazioni](/slides/it/java/open-presentation/), rendendolo adatto a scenari di elaborazione in tempo reale o su larga scala.

**Aspose.Slides può estrarre testo da tabelle e grafici all'interno delle presentazioni?**

Sì. Aspose.Slides può estrarre testo da molti elementi della diapositiva, incluse tabelle e oggetti correlati a grafici, così da poter accedere e analizzare il contenuto testuale nelle strutture di presentazione comuni.

**È necessaria una licenza speciale di Aspose.Slides per estrarre testo dalle presentazioni?**

È possibile estrarre testo utilizzando la versione di prova gratuita di Aspose.Slides, sebbene presenti [alcune limitazioni](/slides/it/java/licensing/), come l'elaborazione di un numero limitato di diapositive. Per un uso illimitato e per gestire presentazioni più grandi, si consiglia l'acquisto di una licenza completa.