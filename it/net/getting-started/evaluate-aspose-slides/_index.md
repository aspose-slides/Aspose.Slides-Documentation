---
title: Valuta Aspose.Slides
type: docs
weight: 120
url: /it/net/evaluate-aspose-slides/
keywords:
- Valuta Aspose.Slides
- Valutazione Aspose.Slides
- Versione di valutazione
- Funzionalità completa
- Filigrana di valutazione
- Acquista Aspose.Slides
- Limitazione
- PowerPoint
- OpenDocument
- Presentazione
- .NET
- C#
- Aspose.Slides
description: "Valuta Aspose.Slides per .NET ed esplora le funzionalità API per presentazioni PowerPoint (PPT, PPTX) e OpenDocument (ODP) — inizia la tua prova gratuita."
---
## **Valutazione di Aspose.Slides**

Puoi scaricare Aspose.Slides per la valutazione. Il pacchetto di valutazione è identico a quello acquistato; diventa con licenza dopo aver aggiunto alcune righe di codice per applicare la licenza.

Senza licenza, Aspose.Slides fornisce tutte le funzionalità in modalità valutazione, con due limitazioni: aggiunge una casella di testo con filigrana di valutazione a ogni diapositiva di ciascuna presentazione salvata, e il testo che il tuo codice legge da una presentazione è troncato ai primi caratteri, seguito da un avviso sulla limitazione di valutazione. Il testo che il tuo codice scrive viene salvato per intero.

![Una diapositiva con la filigrana di valutazione](evaluate-aspose-slides_1.png)

{{% alert color="info" title="Note" %}}
Se desideri testare Aspose.Slides senza le limitazioni della versione di valutazione, puoi richiedere una **Licenza Temporanea di 30 giorni**. Consulta [How to get a Temporary License?](https://purchase.aspose.com/temporary-license) per ulteriori informazioni.
{{% /alert %}}

## **Installa il Pacchetto di Valutazione**

```bash
dotnet add package Aspose.Slides.NET
```

Su Linux e macOS, puoi utilizzare il pacchetto Aspose.Slides.NET6.CrossPlatform; vedi [Installation](/slides/it/net/installation/).

## **Applica una Licenza**

Queste sono le “poche righe di codice” che trasformano il pacchetto di valutazione in uno con licenza. Applica la licenza una sola volta all’avvio dell’applicazione, prima che venga creato qualsiasi oggetto `Presentation` — una presentazione costruita in precedenza mantiene la filigrana di valutazione.

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense` accetta anche uno `Stream`, che è l’opzione migliore quando la licenza è fornita come risorsa incorporata anziché come file su disco. Se il percorso è errato o il file è scaduto la chiamata genera un’eccezione, quindi i fallimenti si manifestano immediatamente all’avvio invece di tornare silenziosamente alla modalità di valutazione.

Una volta applicata la licenza, le presentazioni salvate non includono più la filigrana e il testo viene letto per intero.

## **FAQ**

### Posso testare più presentazioni in parallelo su thread diversi in modalità valutazione?

Sì. Puoi elaborare documenti diversi in parallelo; non dovresti condividere lo stesso oggetto di presentazione [across threads](/slides/it/net/multithreading/). La modalità valutazione non influisce su questo.

### Devo installare Microsoft PowerPoint per valutare la libreria su un server o in CI?

No. Aspose.Slides è un motore autonomo e non richiede l’installazione di PowerPoint né per la valutazione né per la produzione.

### Posso testare completamente la conversione di PPT/PPTX in PDF e immagini in modalità valutazione?

Sì. I [converters](/slides/it/net/convert-presentation/) funzionano; l’output includerà una filigrana.

### Posso utilizzare una licenza temporanea per i test di carico senza filigrana?

Sì. Una licenza temporanea di 30 giorni rimuove le limitazioni della modalità di valutazione e consente di testare senza filigrana.