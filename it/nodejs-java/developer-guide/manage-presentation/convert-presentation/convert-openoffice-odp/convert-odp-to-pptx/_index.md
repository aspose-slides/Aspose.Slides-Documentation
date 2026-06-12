---
title: Converti ODP in PPTX con JavaScript
linktitle: ODP in PPTX
type: docs
weight: 10
url: /it/nodejs-java/convert-odp-to-pptx/
keywords:
- converti OpenDocument
- converti presentazione
- converti diapositiva
- converti ODP
- OpenDocument in PPTX
- ODP in PPTX
- salva ODP come PPTX
- esporta ODP in PPTX
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Converti ODP in PPTX con Aspose.Slides per Node.js. Esempi di codice JavaScript puliti, suggerimenti per batch e risultati di alta qualità—nessun PowerPoint necessario."
---
## **Panoramica**

Questo articolo spiega come convertire una presentazione ODP in formato PPTX utilizzando Aspose.Slides.

## **Converti ODP in Presentazione PPTX/PPT**
Aspose.Slides per Node.js tramite Java offre la classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation) che rappresenta un file di presentazione. La classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation) può ora accedere anche a ODP tramite il costruttore [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation#Presentation-java.lang.String-) quando l'oggetto viene istanziato. L'esempio seguente mostra come convertire una presentazione ODP in una presentazione PPTX.

```javascript
// Apri il file ODP
var pres = new aspose.slides.Presentation("AccessOpenDoc.odp");
// Salvataggio della presentazione ODP in formato PPTX
pres.save("AccessOpenDoc_out.pptx", aspose.slides.SaveFormat.Pptx);
```

## **Esempio Live**
Puoi visitare l'app web [**Aspose.Slides Conversion**](https://products.aspose.app/slides/it/conversion/) costruita con **Aspose.Slides API**. L'app dimostra come la conversione da ODP a PPTX può essere implementata con Aspose.Slides API.

## **FAQ**

**Devo installare Microsoft PowerPoint o LibreOffice per convertire ODP in PPTX?**

No. Aspose.Slides funziona in modalità standalone e non richiede applicazioni di terze parti per leggere o scrivere ODP/PPTX.

**Le diapositive master, i layout e i temi vengono conservati durante la conversione?**

Sì. La libreria utilizza un modello di oggetto di presentazione completo e mantiene la struttura, incluse le diapositive master e i layout, in modo che il design rimanga corretto dopo la conversione.

**Posso convertire file ODP protetti da password?**

Sì. Aspose.Slides supporta il rilevamento della protezione, l'apertura e la gestione di [presentazioni protette](/slides/it/nodejs-java/password-protected-presentation/) (inclusi ODP) quando fornisci la password, oltre a configurare la crittografia e l'accesso alle proprietà del documento.

**Aspose.Slides è adatto per servizi di conversione basati su cloud o REST?**

Sì. Puoi utilizzare la libreria locale nel tuo backend o [Aspose.Slides Cloud](https://products.aspose.cloud/slides/it/family/) (REST API); entrambe le opzioni supportano la conversione ODP → PPTX.