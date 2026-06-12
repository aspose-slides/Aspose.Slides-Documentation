---
title: Converti PPT in PPTX con PHP
linktitle: PPT a PPTX
type: docs
weight: 20
url: /it/php-java/convert-ppt-to-pptx/
keywords:
- converti PowerPoint
- converti presentazione
- converti diapositiva
- converti PPT
- PPT in PPTX
- salva PPT come PPTX
- esporta PPT in PPTX
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Converti le presentazioni PPT legacy in moderne PPTX rapidamente con Aspose.Slides per PHP via Java — tutorial chiaro, esempi di codice gratuiti, senza dipendenza da Microsoft Office."
---
## **Panoramica**

Questo articolo spiega come convertire una presentazione PowerPoint in formato PPT in formato PPTX utilizzando PHP e l'app di conversione online da PPT a PPTX. Gli argomenti seguenti sono trattati.

- Converti PPT in PPTX

## **Converti PPT in PPTX con PHP**

Per il codice di esempio Java per convertire PPT in PPTX, vedere la sezione seguente, cioè [Convert PPT to PPTX](#convert-ppt-to-pptx). Carica semplicemente il file PPT e lo salva in formato PPTX. Specificando diversi formati di salvataggio, è anche possibile salvare il file PPT in molti altri formati come PDF, XPS, ODP, HTML, ecc., come discusso in questi articoli.

- [Converti PPT in PDF con PHP](/slides/it/php-java/convert-powerpoint-to-pdf/)
- [Converti PPT in XPS con PHP](/slides/it/php-java/convert-powerpoint-to-xps/)
- [Converti PPT in HTML con PHP](/slides/it/php-java/convert-powerpoint-to-html/)
- [Converti PPT in ODP con PHP](/slides/it/php-java/save-presentation/)
- [Converti PPT in PNG con PHP](/slides/it/php-java/convert-powerpoint-to-png/)

## **Informazioni sulla conversione da PPT a PPTX**

Converti il vecchio formato PPT in PPTX con Aspose.Slides API. Se devi convertire migliaia di presentazioni PPT in formato PPTX, la soluzione migliore è farlo programmaticamente. Con Aspose.Slides API è possibile farlo con poche righe di codice. L'API supporta piena compatibilità per convertire una presentazione PPT in PPTX ed è possibile:

- Convertire strutture complesse di master, layout e diapositive.
- Convertire presentazioni con grafici.
- Convertire presentazioni con gruppi di forme, autoforme (come rettangoli ed ellissi), forme con geometria personalizzata.
- Convertire presentazioni con trame e stili di riempimento di immagini per le autoforme.
- Convertire presentazioni con segnaposti, riquadri di testo e contenitori di testo.

{{% alert color="primary" %}} 

Dai un'occhiata all'app [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/it/conversion/ppt-to-pptx) :

[](https://products.aspose.app/slides/it/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/it/conversion/ppt-to-pptx)

Questa app è basata su [**Aspose.Slides API**](https://products.aspose.com/slides/it/php-java/), quindi è possibile vedere un esempio funzionante delle capacità di conversione base da PPT a PPTX. Aspose.Slides Conversion è un'app web, che consente di trascinare un file di presentazione in formato PPT e scaricarlo convertito in PPTX.

Trova altri esempi live di [**Aspose.Slides Conversion**](https://products.aspose.app/slides/it/conversion/) .

{{% /alert %}} 

## **Converti PPT in PPTX**

Aspose.Slides for PHP via Java ora facilita gli sviluppatori nell'accedere al PPT usando l'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation) e convertirla nel rispettivo formato [PPTX](https://docs.fileformat.com/presentation/pptx/). Attualmente supporta la conversione parziale da [PPT](https://docs.fileformat.com/presentation/ppt/) a PPTX. Per maggiori dettagli su quali funzionalità sono supportate o meno nella conversione da PPT a PPTX, procedi a questa documentazione [collegamento](/slides/it/php-java/ppt-to-pptx-conversion/).

Aspose.Slides for PHP via Java offre la classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation) che rappresenta un file di presentazione **PPTX**. La classe Presentation può ora accedere anche a **PPT** attraverso Presentation quando l'oggetto è istanziato. L'esempio seguente mostra come convertire una presentazione PPT in una presentazione PPTX.

```php
  # Istanzia un oggetto Presentation che rappresenta un file PPTX
  $pres = new Presentation("Aspose.ppt");
  try {
    # Salva la presentazione PPTX nel formato PPTX
    $pres->save("ConvertedAspose.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Figura : Presentazione PPT di origine**|

Il frammento di codice sopra genera la seguente presentazione PPTX dopo la conversione

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Figura: Presentazione PPTX generata dopo la conversione**|

## **FAQ**

**Qual è la differenza tra i formati PPT e PPTX?**

PPT è il vecchio formato binario utilizzato da Microsoft PowerPoint, mentre PPTX è il nuovo formato basato su XML introdotto con Microsoft Office 2007. I file PPTX offrono migliori prestazioni, dimensioni ridotte e recupero dati più efficace.

**Aspose.Slides supporta la conversione batch di più file PPT in PPTX?**

Sì, è possibile utilizzare Aspose.Slides in un ciclo per convertire più file PPT in PPTX programmaticamente, rendendolo adatto a scenari di conversione batch.

**Il contenuto e la formattazione verranno preservati dopo la conversione?**

Aspose.Slides mantiene un'elevata fedeltà nella conversione delle presentazioni. Layout delle diapositive, animazioni, forme, grafici e altri elementi di design sono preservati durante la conversione da PPT a PPTX.

**Posso convertire altri formati come PDF o HTML da file PPT?**

Sì, Aspose.Slides supporta la conversione dei file PPT in [multiple formats](https://reference.aspose.com/slides/it/php-java/aspose.slides/saveformat/), inclusi PDF, XPS, HTML, ODP e formati immagine come PNG e JPEG.

**È possibile convertire PPT in PPTX senza Microsoft PowerPoint installato?**

Sì, Aspose.Slides è un'API autonoma e non richiede Microsoft PowerPoint o alcun software di terze parti per eseguire la conversione.

**Esiste uno strumento online disponibile per la conversione da PPT a PPTX?**

Sì, è possibile utilizzare la gratuita applicazione web [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/it/conversion/ppt-to-pptx) per eseguire la conversione direttamente nel browser senza scrivere codice.