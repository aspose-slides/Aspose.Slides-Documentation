---
title: Valuta Aspose.Slides
type: docs
weight: 120
url: /it/net/evaluate-aspose-slides/
keywords:
- valuta Aspose.Slides
- valutazione Aspose.Slides
- versione di valutazione
- funzionalità completa
- filigrana di valutazione
- acquista Aspose.Slides
- limitazione
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Valuta Aspose.Slides per .NET ed esplora le funzionalità dell'API per presentazioni PowerPoint (PPT, PPTX) e OpenDocument (ODP) — inizia la tua prova gratuita."
---
## **Valutazione di Aspose.Slides**

È possibile scaricare facilmente Aspose.Slides per la valutazione. Il pacchetto di valutazione è identico a quello acquistato. La versione di valutazione diventa semplicemente con licenza dopo aver aggiunto alcune righe di codice per applicare la licenza. 

La versione di valutazione di Aspose.Slides (senza una licenza specificata) fornisce tutta la funzionalità del prodotto, ma inserisce una filigrana di valutazione nella parte superiore del documento all'apertura e al salvataggio. Inoltre, è limitato a una diapositiva quando si estraggono testi dalle diapositive della presentazione.

![todo:image_alt_text](evaluate-aspose-slides_1.png)

{{% alert color="info" %}} 

Se desideri testare Aspose.Slides senza le limitazioni della versione di valutazione, puoi richiedere una **Licenza Temporanea di 30 Giorni**. Consulta [Come ottenere una licenza temporanea?](https://purchase.aspose.com/temporary-license) per ulteriori informazioni.

{{% /alert %}}

## **Installa il pacchetto di valutazione**

```bash
dotnet add package Aspose.Slides.NET
```

## **Applica una licenza**

Queste sono le "poche righe di codice" che trasformano il pacchetto di valutazione in uno con licenza. Applica la licenza una sola volta all'avvio dell'applicazione, prima che venga creato qualsiasi oggetto `Presentation` — una presentazione creata in precedenza conserva la filigrana di valutazione.

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense` accetta anche uno `Stream`, che è l'opzione migliore quando la licenza viene fornita come risorsa incorporata anziché come file su disco. Se il percorso è errato o il file è scaduto la chiamata genera un'eccezione, quindi i fallimenti si manifestano immediatamente all'avvio invece di tornare silenziosamente alla modalità di valutazione.

Una volta applicata la licenza, la filigrana scompare e il limite di estrazione del testo a una sola diapositiva viene rimosso.

## **FAQ**

### Posso testare più presentazioni in parallelo su thread diversi in modalità di valutazione?

Sì. Puoi elaborare documenti diversi in parallelo; non dovresti condividere lo stesso oggetto presentazione [across threads](/slides/it/net/multithreading/). La modalità di valutazione non influisce su questo.

### Devo installare Microsoft PowerPoint per valutare la libreria su un server o in CI?

No. Aspose.Slides è un motore autonomo e non richiede l'installazione di PowerPoint né per la valutazione né per la produzione.

### Posso testare completamente la conversione di PPT/PPTX in PDF e immagini in modalità di valutazione?

Sì. I [converters](/slides/it/net/convert-presentation/) funzionano; l'output includerà una filigrana.

### Posso usare una licenza temporanea per i test di carico senza filigrana?

Sì. Una licenza temporanea di 30 giorni rimuove le limitazioni della modalità di valutazione e consente di eseguire i test senza filigrana.