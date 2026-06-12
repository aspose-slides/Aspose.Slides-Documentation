---
title: Converti PPT in PPTX in Java
linktitle: PPT in PPTX
type: docs
weight: 20
url: /it/java/convert-ppt-to-pptx/
keywords:
- convertire PowerPoint
- convertire presentazione
- convertire diapositiva
- convertire PPT
- PPT in PPTX
- salvare PPT come PPTX
- esportare PPT in PPTX
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Conversione rapida di presentazioni PPT legacy in PPTX moderni in Java con Aspose.Slides — tutorial chiaro, esempi di codice gratuiti, senza dipendenza da Microsoft Office."
---
## **Panoramica**

Questo articolo spiega come convertire una presentazione PowerPoint in formato PPT in PPTX usando Java e l’app di conversione online PPT a PPTX. Gli argomenti seguenti sono trattati.

- Convertire PPT in PPTX in Java

## **Convertire PPT in PPTX in Java**

Per il codice di esempio Java per convertire PPT in PPTX, vedere la sezione sotto, ovvero [Convert PPT to PPTX](#convert-ppt-to-pptx). Carica semplicemente il file PPT e lo salva in formato PPTX. Specificando diversi formati di salvataggio, è possibile salvare il file PPT in molti altri formati come PDF, XPS, ODP, HTML ecc., come discusso in questi articoli.

- [Convertire PPT in PDF in Java](/slides/it/java/convert-powerpoint-to-pdf/)
- [Convertire PPT in XPS in Java](/slides/it/java/convert-powerpoint-to-xps/)
- [Convertire PPT in HTML in Java](/slides/it/java/convert-powerpoint-to-html/)
- [Convertire PPT in ODP in Java](/slides/it/java/save-presentation/)
- [Convertire PPT in PNG in Java](/slides/it/java/convert-powerpoint-to-png/)

## **Informazioni sulla conversione PPT a PPTX**
Convertire il vecchio formato PPT in PPTX con l’API Aspose.Slides. Se è necessario convertire migliaia di presentazioni PPT in formato PPTX, la soluzione migliore è farlo programmaticamente. Con l’API Aspose.Slides è possibile farlo con poche righe di codice. L’API supporta la piena compatibilità per convertire una presentazione PPT in PPTX ed è possibile:

- Convertire strutture complesse di master, layout e diapositive.
- Convertire presentazioni con grafici.
- Convertire presentazioni con forme di gruppo, forme automatiche (come rettangoli ed ellissi), forme con geometria personalizzata.
- Convertire presentazioni con riempimenti di texture e immagini per le forme automatiche.
- Convertire presentazioni con segnaposti, caselle di testo e contenitori di testo.

{{% alert color="primary" %}} 

Dai un’occhiata all’app [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/it/conversion/ppt-to-pptx):

[](https://products.aspose.app/slides/it/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/it/conversion/ppt-to-pptx)

Questa app è basata su [**Aspose.Slides API**](https://products.aspose.com/slides/it/java/), quindi è possibile vedere un esempio vivo delle capacità di conversione base da PPT a PPTX. Aspose.Slides Conversion è un’app web, che consente di trascinare un file di presentazione in formato PPT e scaricarlo convertito in PPTX.

Trova altri esempi live di [**Aspose.Slides Conversion**](https://products.aspose.app/slides/it/conversion/).
{{% /alert %}} 

## **Convertire PPT in PPTX**
Aspose.Slides per Java ora consente agli sviluppatori di accedere al PPT tramite l’istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation) e di convertirlo nel rispettivo formato [PPTX](https://docs.fileformat.com/presentation/pptx/). Attualmente, supporta la conversione parziale da [PPT](https://docs.fileformat.com/presentation/ppt/) a PPTX. Per ulteriori dettagli su quali funzionalità sono supportate o meno nella conversione PPT a PPTX, consultare questa documentazione [link](/slides/it/java/ppt-to-pptx-conversion/).

Aspose.Slides per Java offre la classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation) che rappresenta un file di presentazione **PPTX**. La classe Presentation può ora accedere anche a **PPT** quando l’oggetto è istanziato. L’esempio seguente mostra come convertire una presentazione PPT in una presentazione PPTX.

```java
// Istanziare un oggetto Presentation che rappresenta un file PPTX
Presentation pres = new Presentation("Aspose.ppt");
try {
// Salvataggio della presentazione PPTX in formato PPTX
    pres.save("ConvertedAspose.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
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

PPT è il vecchio formato binario usato da Microsoft PowerPoint, mentre PPTX è il nuovo formato basato su XML introdotto con Microsoft Office 2007. I file PPTX offrono migliori prestazioni, dimensioni ridotte e migliore recupero dei dati.

**Aspose.Slides supporta la conversione batch di più file PPT in PPTX?**

Sì, è possibile utilizzare Aspose.Slides in un ciclo per convertire più file PPT in PPTX programmaticamente, rendendolo adatto a scenari di conversione batch.

**Il contenuto e la formattazione saranno preservati dopo la conversione?**

Aspose.Slides mantiene alta fedeltà nella conversione delle presentazioni. Layout delle diapositive, animazioni, forme, grafici e altri elementi di design sono preservati durante la conversione da PPT a PPTX.

**Posso convertire altri formati come PDF o HTML da file PPT?**

Sì, Aspose.Slides supporta la conversione dei file PPT in [molti formati](https://reference.aspose.com/slides/it/java/com.aspose.slides/saveformat/), inclusi PDF, XPS, HTML, ODP e formati immagine come PNG e JPEG.

**È possibile convertire PPT in PPTX senza avere Microsoft PowerPoint installato?**

Sì, Aspose.Slides è un’API autonoma e non richiede Microsoft PowerPoint né software di terze parti per eseguire la conversione.

**Esiste uno strumento online per la conversione PPT a PPTX?**

Sì, è possibile utilizzare l’app web gratuita [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/it/conversion/ppt-to-pptx) per eseguire la conversione direttamente nel browser senza scrivere codice.