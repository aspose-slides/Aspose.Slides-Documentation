---
title: Converti PPTX in PPT con JavaScript
linktitle: PPTX a PPT
type: docs
weight: 21
url: /it/nodejs-java/convert-pptx-to-ppt/
keywords:
- converti PowerPoint
- converti presentazione
- converti diapositiva
- converti PPTX
- PPTX a PPT
- salva PPTX come PPT
- esporta PPTX in PPT
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Converti facilmente PPTX in PPT con Aspose.Slides—garantisce una compatibilità senza interruzioni con i formati PowerPoint mantenendo la struttura e la qualità della tua presentazione."
---
## **Panoramica**

Questo articolo spiega come convertire una presentazione PowerPoint in formato PPTX in formato PPT utilizzando JavaScript. È trattato il seguente argomento.

- Converti PPTX in PPT con JavaScript

## **Java Converti PPTX in PPT**

Per il codice di esempio JavaScript per convertire PPTX in PPT, consultare la sezione seguente, ovvero [Convert PPTX to PPT](#convert-pptx-to-ppt). Carica semplicemente il file PPTX e lo salva in formato PPT. Specificando formati di salvataggio diversi, è possibile salvare il file PPTX anche in molti altri formati come PDF, XPS, ODP, HTML, ecc., come discusso in questi articoli. 

- [Converti PPTX in PDF con JavaScript](/slides/it/nodejs-java/convert-powerpoint-to-pdf/)
- [Converti PPTX in XPS con JavaScript](/slides/it/nodejs-java/convert-powerpoint-to-xps/)
- [Converti PPTX in HTML con JavaScript](/slides/it/nodejs-java/convert-powerpoint-to-html/)
- [Converti PPTX in ODP con JavaScript](/slides/it/nodejs-java/save-presentation/)
- [Converti PPTX in PNG con JavaScript](/slides/it/nodejs-java/convert-powerpoint-to-png/)

## **Converti PPTX in PPT**

Per convertire un PPTX in PPT basta passare il nome del file e il formato di salvataggio al metodo **Save** della classe [**Presentation**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation). Il codice di esempio JavaScript qui sotto converte una Presentation da PPTX a PPT usando le opzioni predefinite.

```javascript
// instanzia un oggetto Presentation che rappresenta un file PPTX
var presentation = new aspose.slides.Presentation("template.pptx");
// salva la presentazione come PPT
presentation.save("output.ppt", aspose.slides.SaveFormat.Ppt);
```

## **FAQ**

**Tutti gli effetti e le funzionalità di PPTX vengono mantenuti quando si salva nel formato legacy PPT (97–2003)?**

Non sempre. Il formato PPT non supporta alcune capacità più recenti (ad esempio, determinati effetti, oggetti e comportamenti), quindi le funzionalità potrebbero essere semplificate o rasterizzate durante la conversione.

**Posso convertire solo le diapositive selezionate in PPT invece dell'intera presentazione?**

Il salvataggio diretto riguarda l'intera presentazione. Per convertire diapositive specifiche, creare una nuova presentazione contenente solo quelle diapositive e salvarla come PPT; in alternativa, utilizzare un servizio/API che supporta parametri di conversione per diapositiva.

**Le presentazioni protette da password sono supportate?**

Sì. È possibile rilevare se un file è protetto, aprirlo con una password e anche [configurare le impostazioni di protezione/cifratura](/slides/it/nodejs-java/password-protected-presentation/) per il PPT salvato.