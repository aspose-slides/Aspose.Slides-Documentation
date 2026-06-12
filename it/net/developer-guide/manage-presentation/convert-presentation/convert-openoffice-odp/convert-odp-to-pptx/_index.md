---
title: Converti ODP in PPTX in .NET
linktitle: ODP in PPTX
type: docs
weight: 10
url: /it/net/convert-odp-to-pptx/
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
- .NET
- C#
- Aspose.Slides
description: "Converti ODP in PPTX con Aspose.Slides per .NET. Esempi di codice C# puliti, consigli per batch e risultati di alta qualità—senza bisogno di PowerPoint."
---
## **Panoramica**

Questo articolo spiega come convertire una presentazione ODP in formato PPTX utilizzando Aspose.Slides.

## **Conversione da ODP a PPTX**

Aspose.Slides per .NET offre la classe Presentation che rappresenta un file di presentazione. La classe [**Presentation**](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) ora può anche accedere a ODP tramite il costruttore Presentation quando l'oggetto viene istanziato. L'esempio seguente mostra come convertire una presentazione ODP in una presentazione PPTX.

<a name="csharp-odp-to-pptx" id="csharp-odp-to-pptx"><strong>Passaggi: Converti ODP in PPTX in C#</strong></a> |
<a name="csharp-odp-to-powerpoint" id="csharp-odp-to-powerpoint"><strong>Passaggi: Converti ODP in PowerPoint in C#</strong></a>

```c#
// Apri il file ODP
Presentation pres = new Presentation("AccessOpenDoc.odp");

// Salva la presentazione ODP in formato PPTX
pres.Save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
```

## **Esempio live**

Puoi visitare l'app web [**Aspose.Slides Conversion**](https://products.aspose.app/slides/it/conversion/) costruita con **Aspose.Slides API**. L'app dimostra come la conversione da ODP a PPTX possa essere implementata con Aspose.Slides API.

## **FAQ**

**Devo installare Microsoft PowerPoint o LibreOffice per convertire ODP in PPTX?**

No. Aspose.Slides funziona in modo autonomo e non richiede applicazioni di terze parti per leggere o scrivere ODP/PPTX.

**Le diapositive master, i layout e i temi vengono preservati durante la conversione?**

Sì. La libreria utilizza un modello object completo della presentazione e mantiene la struttura, incluse le diapositive master e i layout, in modo che il design rimanga corretto dopo la conversione.

**Posso convertire file ODP protetti da password?**

Sì. Aspose.Slides supporta il rilevamento della protezione, l'apertura e la gestione delle [presentazioni protette](/slides/it/net/password-protected-presentation/) (incluse ODP) quando fornisci la password, oltre a configurare la crittografia e l'accesso alle proprietà del documento.

**Aspose.Slides è adatto per servizi di conversione basati su cloud o REST?**

Sì. Puoi utilizzare la libreria locale nel tuo backend o [Aspose.Slides Cloud](https://products.aspose.cloud/slides/it/family/) (REST API); entrambe le opzioni supportano la conversione ODP → PPTX.