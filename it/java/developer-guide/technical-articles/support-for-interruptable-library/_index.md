---
title: Supporto per la libreria interruttibile
type: docs
weight: 120
url: /it/java/support-for-interruptable-library/
keywords:
- libreria interruttibile
- token di interruzione
- token di cancellazione
- attività a lunga durata
- interrompere l'attività
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Rendi le attività a lunga durata annullabili con Aspose.Slides per Java. Interrompi in modo sicuro il rendering e le conversioni per PowerPoint e OpenDocument, con esempi."
---
## **Panoramica**

Aspose.Slides fornisce un meccanismo di elaborazione interrompibile per operazioni di presentazione a lunga durata, come deserializzazione, serializzazione e rendering. Questo meccanismo si basa sulle classi `InterruptionToken` e `InterruptionTokenSource`.

Un `InterruptionToken` può essere assegnato a `LoadOptions` e passato al costruttore `Presentation`. Quando viene chiamato `InterruptionTokenSource.interrupt()`, l'operazione a lunga durata associata viene interrotta.

## **Libreria interruttibile**

In [Aspose.Slides 18.4](https://releases.aspose.com/slides/it/java/release-notes/2018/aspose-slides-for-java-18-4-release-notes/), abbiamo introdotto le classi [InterruptionToken](https://reference.aspose.com/slides/it/java/com.aspose.slides/interruptiontoken/) e [InterruptionTokenSource](https://reference.aspose.com/slides/it/java/com.aspose.slides/interruptiontokensource/). Esse consentono di interrompere operazioni a lunga durata come deserializzazione, serializzazione e rendering.

- [InterruptionTokenSource](https://reference.aspose.com/slides/it/java/com.aspose.slides/interruptiontokensource/) è la sorgente del token(i) passato a [ILoadOptions.setInterruptionToken](https://reference.aspose.com/slides/it/java/com.aspose.slides/iloadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-).
- Quando [ILoadOptions.setInterruptionToken](https://reference.aspose.com/slides/it/java/com.aspose.slides/iloadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-) è impostato e l'istanza [LoadOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/loadoptions/) viene passata al costruttore [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/), l'invocazione di [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/it/java/com.aspose.slides/interruptiontokensource/#interrupt--) interrompe qualsiasi operazione a lunga durata associata a quella [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/).

Il seguente frammento di codice dimostra l'interruzione di un'operazione in corso:

```java
final InterruptionTokenSource tokenSource = new InterruptionTokenSource();

Runnable interruption = new Runnable() {
    public void run() {
        LoadOptions loadOptions = new LoadOptions();
        loadOptions.setInterruptionToken(tokenSource.getToken());

        Presentation presentation = new Presentation("sample.pptx", loadOptions);
        try{
            presentation.save("sample.ppt", SaveFormat.Ppt);
        }
        finally {
            presentation.dispose();
        }
    }
};

Thread thread = new Thread(interruption);
thread.start();          // esegui l'azione in un thread separato
Thread.sleep(10000);     // tempo di attesa
tokenSource.interrupt(); // interrompi la conversione
```

## **FAQ**

**Qual è lo scopo della libreria di interruzione di Aspose.Slides?**

Fornisce un meccanismo per interrompere operazioni a lunga durata—come il caricamento, il salvataggio o il rendering di presentazioni—prima che terminino. È utile quando il tempo di elaborazione deve essere limitato o l'operazione non è più necessaria.

**Qual è la differenza tra [InterruptionToken](https://reference.aspose.com/slides/it/java/com.aspose.slides/interruptiontoken/) e [InterruptionTokenSource](https://reference.aspose.com/slides/it/java/com.aspose.slides/interruptiontokensource/)?**

- `InterruptionToken` viene passato all'API Aspose.Slides e verificato durante le operazioni a lunga durata.
- `InterruptionTokenSource` viene utilizzato nel tuo codice per creare token e attivare interruzioni chiamando `Interrupt()`.

**Quali attività possono essere interrotte?**

Qualsiasi attività Aspose.Slides che accetta un [InterruptionToken](https://reference.aspose.com/slides/it/java/com.aspose.slides/interruptiontoken/)—come il caricamento di una presentazione con `Presentation(path, loadOptions)` o il salvataggio con `Presentation.save(...)`—può essere interrotta.

**L'interruzione avviene immediatamente?**

No. L'interruzione è cooperativa: l'operazione controlla periodicamente il token e si arresta non appena rileva che [Interrupt()](https://reference.aspose.com/slides/it/java/com.aspose.slides/interruptiontokensource/#interrupt--) è stato chiamato.

**Cosa succede se chiamo [Interrupt()](https://reference.aspose.com/slides/it/java/com.aspose.slides/interruptiontokensource/#interrupt--) dopo che un'operazione è già terminata?**

Niente—la chiamata non ha effetto se l'operazione corrispondente è già terminata.

**Posso riutilizzare lo stesso [InterruptionTokenSource](https://reference.aspose.com/slides/it/java/com.aspose.slides/interruptiontokensource/) per più attività?**

Sì—ma dopo aver chiamato [Interrupt()](https://reference.aspose.com/slides/it/java/com.aspose.slides/interruptiontokensource/#interrupt--) su quella sorgente, tutte le attività che usano i suoi token verranno interrotte. Usa sorgenti di token separate per gestire le attività in modo indipendente.