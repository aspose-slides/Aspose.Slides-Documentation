---
title: Creare presentazioni in Python via Java
linktitle: Crea presentazione
type: docs
weight: 10
url: /it/python-java/create-presentation/
keywords:
- creare presentazione
- nuova presentazione
- creare PPT
- nuovo PPT
- creare PPTX
- nuovo PPTX
- creare ODP
- nuovo ODP
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Crea presentazioni in Python via Java con Aspose.Slides—produci file PPT, PPTX e ODP, sfrutta il supporto OpenDocument e salvali programmaticamente per risultati affidabili."
---
## **Panoramica**

Questo articolo mostra come creare una presentazione con Aspose.Slides per Python via Java, aggiungere una forma con testo alla prima diapositiva e salvare il risultato come file PPTX. La FAQ copre i formati di output, i modelli, le dimensioni delle diapositive, l'utilizzo della memoria, il threading, le licenze, le firme digitali e il supporto VBA.

## **Creare una presentazione**

Creare un file PowerPoint da zero in Aspose.Slides per Python via Java è semplice come istanziare la classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/). Il costruttore fornisce automaticamente un deck vuoto con una singola diapositiva, offrendoti una tela immediata per forme, testo, grafici o qualsiasi altro contenuto di cui la tua applicazione ha bisogno. Una volta modificata quella diapositiva — o aggiunte nuove — puoi persistere il risultato in formato PPTX, PPT legacy o anche OpenDocument. Il breve esempio di codice qui sotto illustra questo flusso di lavoro aggiungendo una semplice forma alla prima diapositiva.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
1. Recupera la prima diapositiva per indice.
1. Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/autoshape/) di tipo [ShapeType.Cloud](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapetype/#Cloud) utilizzando [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapecollection/#addAutoShape).
1. Imposta il testo della forma usando [TextFrame.setText](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframe/#setText).
1. Salva la presentazione usando [Presentation.save](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#save) con [SaveFormat.Pptx](https://reference.aspose.com/slides/it/python-java/aspose.slides/saveformat/#Pptx).

L'esempio seguente richiede Aspose.Slides per Python via Java e un runtime Java compatibile. Avvia la JVM se non è già in esecuzione, aggiunge una forma a nuvola alla prima diapositiva e salva la presentazione:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Crea una presentazione con una diapositiva vuota.
presentation = Presentation()
try:
    # Ottieni la prima diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Aggiungi una forma a nuvola e imposta il suo testo.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # Salva la presentazione come file PPTX.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![The new presentation](new_presentation.png)

## **FAQ**

**In quali formati posso salvare una nuova presentazione?**

Puoi salvare in [PPTX, PPT e ODP](/slides/it/python-java/save-presentation/), e esportare in [PDF](/slides/it/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/it/python-java/convert-powerpoint-to-xps/), [HTML](/slides/it/python-java/convert-powerpoint-to-html/), [SVG](/slides/it/python-java/render-slide-as-svg/), e [immagini](/slides/it/python-java/convert-powerpoint-to-png/), tra gli altri.

**Posso partire da un modello (POTX/POTM) e salvarlo come un PPTX normale?**

Sì. Carica il modello e salvalo nel formato desiderato; i formati POTX/POTM/PPTM e simili [sono supportati](/slides/it/python-java/supported-file-formats/).

**Come controllo la dimensione/rapporto d'aspetto della diapositiva quando creo una presentazione?**

Imposta la [dimensione della diapositiva](/slides/it/python-java/slide-size/) (incluse le impostazioni predefinite come 4:3 e 16:9 o dimensioni personalizzate) e scegli come scalare il contenuto.

**In quali unità sono misurate le dimensioni e le coordinate?**

In punti: 1 pollice corrisponde a 72 unità.

**Come gestisco presentazioni molto grandi (con molti file multimediali) per ridurre l'uso della memoria?**

Usa le [strategie di gestione BLOB](/slides/it/python-java/manage-blob/), limita l'archiviazione in memoria sfruttando file temporanei e preferisci flussi di lavoro basati su file piuttosto che stream puramente in memoria.

**Posso creare/salvare presentazioni in parallelo?**

Non è possibile operare sulla stessa istanza di [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) da [thread multipli](/slides/it/python-java/multithreading/). Avvia istanze separate e isolate per thread o processo.

**Come rimuovo la filigrana di prova e le limitazioni?**

[Applica una licenza](/slides/it/python-java/licensing/) una volta per processo. L'XML della licenza deve rimanere non modificato e la configurazione della licenza deve essere sincronizzata se più thread sono coinvolti.

**Posso firmare digitalmente il PPTX che creo?**

Sì. Le [firme digitali](/slides/it/python-java/digital-signature-in-powerpoint/) (aggiunta e verifica) sono supportate per le presentazioni.

**Le macro (VBA) sono supportate nelle presentazioni create?**

Sì. Puoi [creare/modificare progetti VBA](/slides/it/python-java/presentation-via-vba/) e salvare file abilitati alle macro come PPTM/PPSM.