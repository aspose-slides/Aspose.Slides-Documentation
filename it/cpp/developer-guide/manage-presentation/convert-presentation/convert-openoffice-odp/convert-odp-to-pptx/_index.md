---
title: Converti ODP in PPTX in C++
linktitle: ODP in PPTX
type: docs
weight: 10
url: /it/cpp/convert-odp-to-pptx/
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
- C++
- Aspose.Slides
description: "Converti ODP in PPTX con Aspose.Slides per C++. Esempi di codice chiari, suggerimenti per il batch e risultati di alta qualità—non è necessario PowerPoint."
---
## **Panoramica**

Questo articolo spiega come convertire una presentazione ODP in formato PPTX usando Aspose.Slides.

## **Conversione ODP in PPTX**

Aspose.Slides per .NET offre la classe Presentation che rappresenta un file di presentazione. La classe [**Presentation**](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation) può ora accedere anche a ODP tramite il costruttore Presentation quando l'oggetto viene istanziato. L'esempio seguente mostra come convertire una presentazione ODP in una presentazione PPTX.

``` cpp
// Il percorso alla directory dei documenti.
String dataDir = GetDataPath();

// Apri il file ODP
auto pres = System::MakeObject<Presentation>(dataDir + u"AccessOpenDoc.odp");

// Salvataggio della presentazione ODP in formato PPTX
pres->Save(dataDir + u"AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```

## **Esempio live**

Puoi visitare l'app web [**Aspose.Slides Conversion**](https://products.aspose.app/slides/it/conversion/) costruita con **Aspose.Slides API**. L'app dimostra come la conversione ODP in PPTX possa essere implementata con Aspose.Slides API.

## **FAQ**

**Devo installare Microsoft PowerPoint o LibreOffice per convertire ODP in PPTX?**

No. Aspose.Slides funziona in modalità standalone e non richiede applicazioni di terze parti per leggere o scrivere ODP/PPTX.

**Le slide master, i layout e i temi vengono preservati durante la conversione?**

Sì. La libreria utilizza un modello completo di oggetti di presentazione e conserva la struttura, includendo slide master e layout, così il design rimane corretto dopo la conversione.

**Posso convertire file ODP protetti da password?**

Sì. Aspose.Slides supporta il rilevamento della protezione, l'apertura e la gestione di [presentazioni protette](/slides/it/cpp/password-protected-presentation/) (inclusi ODP) quando fornisci la password, nonché la configurazione della crittografia e l'accesso alle proprietà del documento.

**Aspose.Slides è adatto per servizi di conversione cloud o basati su REST?**

Sì. Puoi utilizzare la libreria locale nel tuo backend o [Aspose.Slides Cloud](https://products.aspose.cloud/slides/it/family/) (REST API); entrambe le opzioni supportano la conversione ODP → PPTX.