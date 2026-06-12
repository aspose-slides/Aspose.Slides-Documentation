---
title: Converti ODP in PPTX in PHP
linktitle: ODP in PPTX
type: docs
weight: 10
url: /it/php-java/convert-odp-to-pptx/
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
- PHP
- Aspose.Slides
description: "Converti ODP in PPTX con Aspose.Slides per PHP via Java. Esempi di codice puliti, consigli per batch e risultati di alta qualità—non è necessario PowerPoint."
---
## **Panoramica**

Questo articolo spiega come convertire una presentazione ODP in formato PPTX utilizzando Aspose.Slides.

## **Converti ODP in Presentazione PPTX/PPT**
Aspose.Slides per PHP via Java offre la classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation) che rappresenta un file di presentazione. La classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation) può ora accedere anche a ODP tramite il costruttore [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation#Presentation-java.lang.String-) quando l'oggetto viene istanziato. L'esempio seguente mostra come convertire una presentazione ODP in una presentazione PPTX.

```php
// Apri il file ODP
  $pres = new Presentation("AccessOpenDoc.odp");
  try {
  } finally {
  }
  # Salvataggio della presentazione ODP in formato PPTX
  $pres->save("AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```

## **Esempio Live**
Puoi visitare l'app web [**Aspose.Slides Conversion**](https://products.aspose.app/slides/it/conversion/) costruita con **Aspose.Slides API.** L'app dimostra come la conversione da ODP a PPTX può essere implementata con Aspose.Slides API.

## **FAQ**

**Devo installare Microsoft PowerPoint o LibreOffice per convertire ODP in PPTX?**

No. Aspose.Slides funziona in modo indipendente e non richiede applicazioni di terze parti per leggere o scrivere ODP/PPTX.

**Le diapositive master, i layout e i temi sono preservati durante la conversione?**

Sì. La libreria utilizza un modello completo di oggetti di presentazione e mantiene la struttura, incluse le diapositive master e i layout, in modo che il design rimanga corretto dopo la conversione.

**Posso convertire file ODP protetti da password?**

Sì. Aspose.Slides supporta il rilevamento della protezione, l'apertura e la gestione di [presentazioni protette](/slides/it/php-java/password-protected-presentation/) (incluse ODP) quando fornisci la password, oltre a configurare la crittografia e l'accesso alle proprietà del documento.

**Aspose.Slides è adatto per servizi di conversione basati su cloud o REST?**

Sì. Puoi utilizzare la libreria locale nel tuo backend o [Aspose.Slides Cloud](https://products.aspose.cloud/slides/it/family/) (REST API); entrambe le opzioni supportano la conversione ODP → PPTX.