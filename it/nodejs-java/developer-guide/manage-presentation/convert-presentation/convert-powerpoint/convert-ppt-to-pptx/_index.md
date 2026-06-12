---
title: Converti PPT in PPTX con JavaScript
linktitle: PPT in PPTX
type: docs
weight: 20
url: /it/nodejs-java/convert-ppt-to-pptx/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Converti rapidamente le presentazioni PPT legacy in moderni PPTX con Aspose.Slides per Node.js — tutorial chiaro, esempi di codice gratuiti, senza dipendenza da Microsoft Office."
---
## **Panoramica**

Questo articolo spiega come convertire una presentazione PowerPoint in formato PPT in PPTX usando JavaScript e un'app di conversione online da PPT a PPTX. Vengono trattati i seguenti argomenti.

- Converti PPT in PPTX con JavaScript

## **Java Convert PPT to PPTX**

Per il codice di esempio JavaScript per convertire PPT in PPTX, vedere la sezione sottostante ovvero [Converti PPT in PPTX](#convert-ppt-to-pptx). Il codice carica semplicemente il file PPT e lo salva in formato PPTX. Specificando formati di salvataggio diversi, è anche possibile salvare il file PPT in molti altri formati come PDF, XPS, ODP, HTML ecc. come discusso in questi articoli.

- [Converti PPT in PDF in JavaScript](/slides/it/nodejs-java/convert-powerpoint-to-pdf/)
- [Converti PPT in XPS in JavaScript](/slides/it/nodejs-java/convert-powerpoint-to-xps/)
- [Converti PPT in HTML in JavaScript](/slides/it/nodejs-java/convert-powerpoint-to-html/)
- [Converti PPT in ODP in JavaScript](/slides/it/nodejs-java/save-presentation/)
- [Converti PPT in PNG in JavaScript](/slides/it/nodejs-java/convert-powerpoint-to-png/)

## **Informazioni sulla conversione da PPT a PPTX**
Converti il vecchio formato PPT in PPTX con Aspose.Slides API. Se devi convertire migliaia di presentazioni PPT in formato PPTX, la soluzione migliore è farlo programmaticamente. Con Aspose.Slides API è possibile farlo in poche righe di codice. L'API supporta la piena compatibilità per convertire presentazioni PPT in PPTX ed è possibile:

- Convertire strutture complesse di master, layout e diapositive.
- Convertire presentazioni con grafici.
- Convertire presentazioni con forme raggruppate, forme automatiche (come rettangoli ed ellissi), forme con geometria personalizzata.
- Convertire presentazioni con trame e stili di riempimento di immagini per le forme automatiche.
- Convertire presentazioni con segnaposto, riquadri di testo e contenitori di testo.

{{% alert color="primary" %}} 

Dai un'occhiata all'[**Conversione PPT in PPTX di Aspose.Slides**](https://products.aspose.app/slides/it/conversion/ppt-to-pptx) app:

[](https://products.aspose.app/slides/it/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/it/conversion/ppt-to-pptx)

Questa app è basata su [**Aspose.Slides API**](https://products.aspose.com/slides/it/nodejs-java/), quindi puoi vedere un esempio funzionante delle capacità base di conversione da PPT a PPTX. Aspose.Slides Conversion è un'app web che consente di trascinare un file di presentazione in formato PPT e scaricarlo convertito in PPTX.

Trova altri esempi live di [**Aspose.Slides Conversion**](https://products.aspose.app/slides/it/conversion/) .
{{% /alert %}} 

## **Converti PPT in PPTX**
Aspose.Slides per Node.js via Java ora consente agli sviluppatori di accedere al PPT usando la classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation) e convertirlo nel relativo formato [PPTX](https://docs.fileformat.com/presentation/pptx/). Attualmente, supporta la conversione parziale da [PPT](https://docs.fileformat.com/presentation/ppt/) a PPTX.

Aspose.Slides per Node.js via Java offre la classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation) che rappresenta un file di presentazione **PPTX**. La classe Presentation può ora accedere anche a **PPT** tramite Presentation quando l'oggetto viene istanziato. L'esempio seguente mostra come convertire una presentazione PPT in una presentazione PPTX.

```javascript
// Istanziare un oggetto Presentation che rappresenta un file PPTX
var pres = new aspose.slides.Presentation("Aspose.ppt");
try {
    // Salvataggio della presentazione PPTX nel formato PPTX
    pres.save("ConvertedAspose.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
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

PPT è il vecchio formato binario utilizzato da Microsoft PowerPoint, mentre PPTX è il nuovo formato basato su XML introdotto con Microsoft Office 2007. I file PPTX offrono migliori prestazioni, dimensioni ridotte e un recupero dati più efficace.

**Aspose.Slides supporta la conversione batch di più file PPT in PPTX?**

Sì, è possibile utilizzare Aspose.Slides in un ciclo per convertire più file PPT in PPTX in modo programmatico, rendendolo adatto a scenari di conversione batch.

**Il contenuto e la formattazione verranno preservati dopo la conversione?**

Aspose.Slides mantiene un'alta fedeltà nella conversione delle presentazioni. Layout delle diapositive, animazioni, forme, grafici e altri elementi di design vengono preservati durante la conversione da PPT a PPTX.

**Posso convertire altri formati come PDF o HTML dai file PPT?**

Sì, Aspose.Slides supporta la conversione dei file PPT in più formati, tra cui PDF, XPS, HTML, ODP e formati immagine come PNG e JPEG.

**È possibile convertire PPT in PPTX senza avere Microsoft PowerPoint installato?**

Sì, Aspose.Slides è un'API indipendente e non richiede Microsoft PowerPoint né software di terze parti per eseguire la conversione.

**Esiste uno strumento online per la conversione da PPT a PPTX?**

Sì, puoi utilizzare l'app web gratuita [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/it/conversion/ppt-to-pptx) per eseguire la conversione direttamente nel browser senza scrivere codice.