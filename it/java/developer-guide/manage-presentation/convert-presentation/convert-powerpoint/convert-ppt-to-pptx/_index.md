---
title: Converti PPT in PPTX in Java
linktitle: PPT a PPTX
type: docs
weight: 20
url: /it/java/convert-ppt-to-pptx/
keywords:
- converti PowerPoint
- converti presentazione
- converti diapositiva
- converti PPT
- PPT a PPTX
- salva PPT come PPTX
- esporta PPT in PPTX
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Converti presentazioni PPT legacy in moderni PPTX rapidamente in Java con Aspose.Slides — tutorial chiaro, esempi di codice gratuiti, senza dipendenza da Microsoft Office."
---
## **Panoramica**

Questo articolo spiega come convertire una presentazione PowerPoint in formato PPT in formato PPTX usando Java e con l'applicazione online di conversione PPT in PPTX. Gli argomenti seguenti sono trattati.

- Converti PPT in PPTX in Java

## **Converti PPT in PPTX in Java**

Per il codice di esempio Java per convertire PPT in PPTX, vedere la sezione seguente, cioè [Converti PPT in PPTX](#convert-ppt-to-pptx). Carica semplicemente il file PPT e lo salva in formato PPTX. Specificando diversi formati di salvataggio, è anche possibile salvare il file PPT in molti altri formati come PDF, XPS, ODP, HTML ecc., come discusso in questi articoli.

- [Converti PPT in PDF in Java](/slides/it/java/convert-powerpoint-to-pdf/)
- [Converti PPT in XPS in Java](/slides/it/java/convert-powerpoint-to-xps/)
- [Converti PPT in HTML in Java](/slides/it/java/convert-powerpoint-to-html/)
- [Converti PPT in ODP in Java](/slides/it/java/save-presentation/)
- [Converti PPT in PNG in Java](/slides/it/java/convert-powerpoint-to-png/)

## **Informazioni sulla conversione da PPT a PPTX**
Converti il vecchio formato PPT in PPTX con Aspose.Slides API. Se devi convertire migliaia di presentazioni PPT in formato PPTX, la soluzione migliore è farlo programmaticamente. Con Aspose.Slides API è possibile farlo con poche righe di codice. L'API supporta la piena compatibilità per convertire presentazioni PPT in PPTX ed è possibile:

- Convertire strutture complesse di master, layout e diapositive.
- Convertire presentazioni con grafici.
- Convertire presentazioni con forme di gruppo, auto‑forme (come rettangoli ed ellissi), forme con geometria personalizzata.
- Convertire presentazioni con texture e stili di riempimento di immagini per le auto‑forme.
- Convertire presentazioni con segnaposti, riquadri di testo e contenitori di testo.

{{% alert color="info" %}} 

Dai un'occhiata all’applicazione [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/it/conversion/ppt-to-pptx):

[](https://products.aspose.app/slides/it/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/it/conversion/ppt-to-pptx)

Questa app è basata su [**Aspose.Slides API**](https://products.aspose.com/slides/it/java/), quindi puoi vedere un esempio attivo delle capacità di conversione di base da PPT a PPTX. Aspose.Slides Conversion è un’app web che consente di trascinare un file di presentazione in formato PPT e scaricarlo convertito in PPTX.

Trova altri esempi live di [**Aspose.Slides Conversion**](https://products.aspose.app/slides/it/conversion/) .
{{% /alert %}} 

## **Converti PPT in PPTX**
Aspose.Slides per Java ora consente agli sviluppatori di accedere al PPT tramite la classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation) e di convertirlo nel relativo formato [PPTX](https://docs.fileformat.com/presentation/pptx/). Attualmente supporta la conversione parziale da [PPT](https://docs.fileformat.com/presentation/ppt/) a PPTX. Per ulteriori dettagli su quali funzionalità sono supportate o meno nella conversione da PPT a PPTX, consultare questa documentazione [link](/slides/it/java/ppt-to-pptx-conversion/).

Aspose.Slides per Java offre la classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation) che rappresenta un file di presentazione **PPTX**. La classe Presentation può ora accedere anche a **PPT** quando l’oggetto è istanziato. L'esempio seguente mostra come convertire una presentazione PPT in una presentazione PPTX.

```java
import com.aspose.slides.*;

// Istanzia un oggetto Presentation che rappresenta un file PPT
Presentation pres = new Presentation("Aspose.ppt");
try {
    // Salvataggio della presentazione PPT in formato PPTX
    pres.save("ConvertedAspose.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Figura : Presentazione PPT di origine**|

Il frammento di codice sopra ha generato la seguente presentazione PPTX dopo la conversione

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Figura: Presentazione PPTX generata dopo la conversione**|

## **FAQ**

### Qual è la differenza tra i formati PPT e PPTX?

PPT è il vecchio formato binario utilizzato da Microsoft PowerPoint, mentre PPTX è il nuovo formato basato su XML introdotto con Microsoft Office 2007. I file PPTX offrono prestazioni migliori, dimensioni ridotte e un recupero dati più efficace.

### Aspose.Slides supporta la conversione batch di più file PPT in PPTX?

Sì, è possibile utilizzare Aspose.Slides in un ciclo per convertire programmamente più file PPT in PPTX, rendendolo adatto a scenari di conversione batch.

### Il contenuto e la formattazione vengono conservati dopo la conversione?

Aspose.Slides mantiene un’elevata fedeltà nella conversione delle presentazioni. Layout delle diapositive, animazioni, forme, grafici e altri elementi di design vengono preservati durante la conversione da PPT a PPTX.

### Posso convertire altri formati come PDF o HTML da file PPT?

Sì, Aspose.Slides supporta la conversione dei file PPT in [molti formati](https://reference.aspose.com/slides/it/java/com.aspose.slides/saveformat/), inclusi PDF, XPS, HTML, ODP e formati immagine come PNG e JPEG.

### È possibile convertire PPT in PPTX senza Microsoft PowerPoint installato?

Sì, Aspose.Slides è un’API autonoma e non richiede Microsoft PowerPoint né alcun software di terze parti per eseguire la conversione.

### Esiste uno strumento online per la conversione da PPT a PPTX?

Sì, puoi utilizzare l’app web gratuita [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/it/conversion/ppt-to-pptx) per effettuare la conversione direttamente nel browser senza scrivere codice.