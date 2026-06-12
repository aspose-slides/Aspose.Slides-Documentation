---
title: Converti ODP in PPTX in Python
linktitle: ODP in PPTX
type: docs
weight: 10
url: /it/python-net/convert-odp-to-pptx/
keywords:
- converti OpenDocument
- converti ODP
- OpenDocument in PPTX
- ODP in PPTX
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Converti ODP in PPTX con Aspose.Slides per Python tramite .NET. Esempi di codice puliti, suggerimenti per batch e risultati di alta qualità—nessun PowerPoint necessario."
---
## **Panoramica**

Questo articolo spiega come convertire una presentazione ODP nel formato PPTX utilizzando Aspose.Slides.

## **Esporta ODP in PPTX**

Aspose.Slides per Python tramite .NET offre la classe Presentation che rappresenta un file di presentazione. [**Presentation**](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) può ora accedere anche a ODP tramite il costruttore Presentation quando l'oggetto viene istanziato. L'esempio seguente mostra come convertire una presentazione ODP in una presentazione PPTX.

```py
# Importa il modulo Aspose.Slides per Python tramite .NET
import aspose.slides as slides

# Apri il file ODP
pres = slides.Presentation("AccessOpenDoc.odp")

# Salva la presentazione ODP nel formato PPTX
pres.save("AccessOpenDoc_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Esempio live**

Puoi visitare l'app web [**Aspose.Slides Conversion**](https://products.aspose.app/slides/it/conversion/), che è realizzata con **Aspose.Slides API.** L'app dimostra come la conversione da ODP a PPTX possa essere implementata con Aspose.Slides API.

## **FAQ**

**Devo installare Microsoft PowerPoint o LibreOffice per convertire ODP in PPTX?**

No. Aspose.Slides funziona in modo autonomo e non richiede applicazioni di terze parti per leggere o scrivere ODP/PPTX.

**Le diapositive master, i layout e i temi vengono preservati durante la conversione?**

Sì. La libreria utilizza un modello completo di oggetti di presentazione e mantiene la struttura, comprese le diapositive master e i layout, in modo che il design rimanga corretto dopo la conversione.

**Posso convertire file ODP protetti da password?**

Sì. Aspose.Slides supporta il rilevamento della protezione, l'apertura e la gestione di [presentazioni protette](/slides/it/python-net/password-protected-presentation/) (inclusi ODP) quando fornisci la password, oltre a configurare la crittografia e l'accesso alle proprietà del documento.

**Aspose.Slides è adatto per servizi di conversione cloud o basati su REST?**

Sì. Puoi utilizzare la libreria locale nel tuo backend o [Aspose.Slides Cloud](https://products.aspose.cloud/slides/it/family/) (REST API); entrambe le opzioni supportano la conversione ODP → PPTX.