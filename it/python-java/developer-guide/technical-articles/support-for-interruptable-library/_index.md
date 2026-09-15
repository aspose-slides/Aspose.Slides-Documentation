---
title: Supporto per una libreria interrompibile
type: docs
weight: 120
url: /it/python-java/support-for-interruptable-library/
keywords:
- libreria interrompibile
- token di interruzione
- token di cancellazione
- operazione a lungo termine
- interruzione attività
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Rendi le operazioni a lungo termine annullabili con Aspose.Slides per Python tramite Java. Interrompi in modo sicuro il rendering e le conversioni per PowerPoint e OpenDocument, con esempi."
---
## **Panoramica**

Aspose.Slides fornisce un meccanismo di elaborazione interrompibile per attività di presentazione a lungo termine, come deserializzazione, serializzazione e rendering. Questo meccanismo si basa sulle classi [InterruptionToken](https://reference.aspose.com/slides/it/python-java/aspose.slides/interruptiontoken/) e [InterruptionTokenSource](https://reference.aspose.com/slides/it/python-java/aspose.slides/interruptiontokensource/).

Un [InterruptionToken](https://reference.aspose.com/slides/it/python-java/aspose.slides/interruptiontoken/) può essere assegnato a [LoadOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/loadoptions/) e passato al costruttore di [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/). Quando viene chiamato [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/it/python-java/aspose.slides/interruptiontokensource/#interrupt), l'attività a lungo termine associata viene interrotta.

## **Libreria Interrompibile**

Aspose.Slides per Python tramite Java fornisce le classi [InterruptionToken](https://reference.aspose.com/slides/it/python-java/aspose.slides/interruptiontoken/) e [InterruptionTokenSource](https://reference.aspose.com/slides/it/python-java/aspose.slides/interruptiontokensource/). Consentono di interrompere attività a lungo termine come deserializzazione, serializzazione e rendering.

- [InterruptionTokenSource](https://reference.aspose.com/slides/it/python-java/aspose.slides/interruptiontokensource/) è la sorgente del token(i) passato a [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/it/python-java/aspose.slides/loadoptions/#setInterruptionToken).
- Quando [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/it/python-java/aspose.slides/loadoptions/#setInterruptionToken) viene chiamato e l'istanza di [LoadOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/loadoptions/) è passata al costruttore di [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/), l'invocazione di [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/it/python-java/aspose.slides/interruptiontokensource/#interrupt) interrompe qualsiasi attività a lungo termine associata a quella [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).

Il seguente frammento di codice dimostra come interrompere un'attività in esecuzione:

```python
from concurrent.futures import ThreadPoolExecutor
import time

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat


token_source = InterruptionTokenSource()


def convert_presentation():
    load_options = LoadOptions()
    load_options.setInterruptionToken(token_source.getToken())

    presentation = Presentation("sample.pptx", load_options)
    try:
        presentation.save("sample.ppt", SaveFormat.Ppt)
    finally:
        presentation.dispose()


with ThreadPoolExecutor(max_workers=1) as executor:
    conversion_task = executor.submit(convert_presentation)  # Esegui l'azione in un thread separato.
    time.sleep(10)  # Tempo scaduto.
    token_source.interrupt()  # Interrompi la conversione.
    conversion_task.result()
```

## **FAQ**

**Qual è lo scopo della libreria di interruzione di Aspose.Slides?**

Fornisce un meccanismo per interrompere operazioni a lungo termine — come il caricamento, il salvataggio o il rendering di presentazioni — prima che vengano completate. È utile quando il tempo di elaborazione deve essere limitato o l'attività non è più necessaria.

**Qual è la differenza tra [InterruptionToken](https://reference.aspose.com/slides/it/python-java/aspose.slides/interruptiontoken/) e [InterruptionTokenSource](https://reference.aspose.com/slides/it/python-java/aspose.slides/interruptiontokensource/)?**

- [InterruptionToken](https://reference.aspose.com/slides/it/python-java/aspose.slides/interruptiontoken/) viene passato all'API di Aspose.Slides e controllato durante le operazioni a lungo termine.
- [InterruptionTokenSource](https://reference.aspose.com/slides/it/python-java/aspose.slides/interruptiontokensource/) viene utilizzato nel tuo codice per creare token e attivare interruzioni chiamando [interrupt](https://reference.aspose.com/slides/it/python-java/aspose.slides/interruptiontokensource/#interrupt).

**Quali attività possono essere interrotte?**

Qualsiasi attività di Aspose.Slides che accetta un [InterruptionToken](https://reference.aspose.com/slides/it/python-java/aspose.slides/interruptiontoken/) — ad esempio il caricamento di una presentazione con [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) o il salvataggio con [Presentation.save](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#save) — può essere interrotta.

**L'interruzione avviene immediatamente?**

No. L'interruzione è cooperativa: l'operazione verifica periodicamente il token e si arresta non appena rileva che [interrupt](https://reference.aspose.com/slides/it/python-java/aspose.slides/interruptiontokensource/#interrupt) è stato chiamato.

**Cosa succede se chiamo [interrupt](https://reference.aspose.com/slides/it/python-java/aspose.slides/interruptiontokensource/#interrupt) dopo che un'attività è già terminata?**

Niente — la chiamata non ha effetto se l'attività corrispondente è già completata.

**Posso riutilizzare lo stesso [InterruptionTokenSource](https://reference.aspose.com/slides/it/python-java/aspose.slides/interruptiontokensource/) per più attività?**

Sì — ma dopo aver chiamato [interrupt](https://reference.aspose.com/slides/it/python-java/aspose.slides/interruptiontokensource/#interrupt) su quella sorgente, tutte le attività che usano i suoi token verranno interrotte. Utilizza sorgenti di token separate per gestire le attività in modo indipendente.