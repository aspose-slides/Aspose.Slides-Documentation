---
title: Renderizzare le diapositive di presentazione come immagini SVG su Android
linktitle: Diapositiva a SVG
type: docs
weight: 50
url: /it/androidjava/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint in SVG
- presentazione in SVG
- diapositiva in SVG
- PPT in SVG
- PPTX in SVG
- salva PPT come SVG
- salva PPTX come SVG
- esporta PPT in SVG
- esporta PPTX in SVG
- renderizza diapositiva
- converti diapositiva
- esporta diapositiva
- immagine vettoriale
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Scopri come renderizzare le diapositive PowerPoint come immagini SVG utilizzando Aspose.Slides per Android. Visuali di alta qualità con semplici esempi di codice Java."
---
## **Panoramica**

Questo articolo spiega come renderizzare le diapositive di una presentazione come immagini SVG utilizzando Aspose.Slides. Descrive il formato SVG e i suoi vantaggi, tra cui scalabilità, accessibilità e idoneità per lo sviluppo web.

Imparerai come caricare un file di presentazione, iterare le sue diapositive e salvare ogni diapositiva come file SVG separato. L'articolo copre i formati di presentazione PowerPoint e OpenDocument, inclusi PPT, PPTX, ODP e PPS, e mostra come eseguire la conversione programmaticamente con la classe `Presentation` e il metodo `writeAsSvg`.

## **Formato SVG**

SVG—acronimo di Scalable Vector Graphics—è un tipo o formato grafico standard utilizzato per renderizzare immagini bidimensionali. SVG memorizza le immagini come vettori in XML con dettagli che ne definiscono il comportamento o l'aspetto.

SVG è uno dei pochi formati di immagine che soddisfa standard molto elevati in questi aspetti: scalabilità, interattività, prestazioni, accessibilità, programmabilità e altri. Per questi motivi è comunemente utilizzato nello sviluppo web.

Potresti voler usare file SVG quando devi

- **stampa la tua presentazione in un *formato molto grande*.** Le immagini SVG possono scalare a qualsiasi risoluzione o livello. Puoi ridimensionare le immagini SVG quante volte è necessario senza sacrificare la qualità.
- **usa grafici e diagrammi dalle tue diapositive in *diversi supporti o piattaforme*.** La maggior parte dei visualizzatori può interpretare i file SVG.
- **usa le *dimensioni più piccole possibili per le immagini***. I file SVG sono generalmente più piccoli rispetto alle loro controparti ad alta risoluzione in altri formati, specialmente quelli basati su bitmap (JPEG o PNG).

## **Renderizzare una diapositiva come immagine SVG**

Aspose.Slides for Android via Java consente di esportare le diapositive delle tue presentazioni come immagini SVG. Segui questi passaggi per generare immagini SVG:

1. Crea un'istanza della classe `Presentation`.
2. Itera attraverso tutte le diapositive della presentazione.
3. Scrivi ogni diapositiva in un proprio file SVG tramite `FileOutputStream`.

{{% alert color="primary" %}} 
Potresti provare la nostra [applicazione web gratuita](https://products.aspose.app/slides/it/conversion/ppt-to-svg) in cui abbiamo implementato la funzione di conversione da PPT a SVG di Aspose.Slides per Android via Java.
{{% /alert %}} 

Questo codice di esempio in Java mostra come convertire PPT in SVG utilizzando Aspose.Slides:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);

        FileOutputStream fileStream = new FileOutputStream("slide-" + index + ".svg");
        try {
            slide.writeAsSvg(fileStream);
        } finally {
            fileStream.close();
        }
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Perché il risultato SVG potrebbe apparire diverso tra i browser?**

Il supporto per specifiche funzionalità SVG è implementato diversamente nei motori dei browser. I parametri [SVGOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/svgoptions/) aiutano a ridurre le incompatibilità.

**È possibile esportare non solo le diapositive ma anche forme individuali in SVG?**

Sì. Qualsiasi [forma può essere salvata come SVG separato](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-), cosa comoda per icone, pittogrammi e riutilizzo di grafica.

**È possibile combinare più diapositive in un unico SVG (striscia/documento)?**

Lo scenario standard è una diapositiva → un SVG. Combinare più diapositive in un unico canvas SVG è un'operazione di post‑elaborazione eseguita a livello di applicazione.