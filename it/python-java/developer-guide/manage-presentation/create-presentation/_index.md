---
title: Crea presentazioni in Python tramite Java
linktitle: Crea presentazione
type: docs
weight: 10
url: /it/python-java/create-presentation/
keywords:
- crea presentazione
- nuova presentazione
- crea PPT
- nuovo PPT
- crea PPTX
- nuovo PPTX
- crea ODP
- nuovo ODP
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Crea presentazioni in Python tramite Java con Aspose.Slides—produci file PPT, PPTX e ODP, beneficia del supporto OpenDocument e salvali programmaticamente per risultati affidabili."
---
## **Panoramica**

Questo articolo mostra come creare una presentazione con Aspose.Slides per Python via Java, aggiungere una forma con testo alla prima diapositiva e salvare il risultato come file PPTX. La FAQ copre formati di output, modelli, dimensionamento delle diapositive, utilizzo della memoria, thread, licenze, firme digitali e supporto VBA.

Prima di iniziare, installa Python, un JDK, JPype e Aspose.Slides per Python via Java. Vedi [Installazione](/slides/it/python-java/installation/) per i passaggi su Windows, Linux e macOS.

## **Creare una Presentazione**

Creare un file PowerPoint da zero in Aspose.Slides per Python via Java è semplice quanto istanziare la classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/). Il costruttore fornisce automaticamente un mazzo vuoto con una singola diapositiva, offrendoti una tela immediata per forme, testo, grafici o qualsiasi altro contenuto necessario alla tua applicazione. Dopo aver modificato quella diapositiva—or aggiunto nuove—puoi persistere il risultato in PPTX, PPT legacy o anche formati OpenDocument. Il breve esempio di codice sottostante illustra questo flusso aggiungendo una semplice forma sulla prima diapositiva.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).  
1. Ottieni la prima diapositiva tramite il suo indice, 0.  
1. Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/autoshape/) di tipo [ShapeType.Cloud](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapetype/#Cloud) usando [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapecollection/#addAutoShape).  
1. Imposta il testo della forma tramite [TextFrame.setText](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframe/#setText).  
1. Salva la presentazione con [Presentation.save](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#save) usando [SaveFormat.Pptx](https://reference.aspose.com/slides/it/python-java/aspose.slides/saveformat/#Pptx).

L'esempio seguente avvia la Java Virtual Machine (JVM) se non è già in esecuzione, aggiunge una forma a nuvola con testo sulla prima diapositiva e salva la presentazione. Salvalo come *create_presentation.py*:

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

Esegui lo script nell'ambiente in cui hai installato i pacchetti:

```sh
python create_presentation.py
```

L'angolo in alto a sinistra della nuvola è a 20 punti dai bordi sinistro e superiore della diapositiva, ed è larga 200 punti e alta 80 punti. Lo script salva *new_presentation.pptx* nella directory di lavoro corrente, con una diapositiva che contiene la nuvola e il suo testo. La JVM rimane in esecuzione fino a quando il processo Python non termina; vedi [Limitations and API Differences](/slides/it/python-java/limitations-and-api-differences/#import-the-library). Senza licenza, Aspose.Slides aggiunge anche una casella di testo con filigrana di valutazione a ogni diapositiva salvata; vedi [Licensing](/slides/it/python-java/licensing/).

Il risultato:

![La nuova presentazione](new_presentation.png)

## **FAQ**

**In quali formati posso salvare una nuova presentazione?**

Puoi salvare in [PPTX, PPT e ODP](/slides/it/python-java/save-presentation/), e esportare in [PDF](/slides/it/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/it/python-java/convert-powerpoint-to-xps/), [HTML](/slides/it/python-java/convert-powerpoint-to-html/), [SVG](/slides/it/python-java/render-a-slide-as-an-svg-image/) e [immagini](/slides/it/python-java/convert-powerpoint-to-png/), tra gli altri.

**Posso partire da un modello (POTX/POTM) e salvare come un PPTX normale?**

Sì. Carica il modello e salva nel formato desiderato; i formati POTX/POTM/PPTM e simili [sono supportati](/slides/it/python-java/supported-file-formats/).

**Come controllo la dimensione/rapporto d'aspetto della diapositiva quando creo una presentazione?**

Imposta la [slide size](/slides/it/python-java/slide-size/) (inclusi preset come 4:3 e 16:9 o dimensioni personalizzate) e scegli come il contenuto deve scalare.

**In quali unità sono misurati dimensioni e coordinate?**

In punti: 1 pollice equivale a 72 unità.

**Come gestire presentazioni molto grandi (con molti file multimediali) per ridurre l'uso della memoria?**

Usa le [BLOB management strategies](/slides/it/python-java/manage-blob/), limita l'archiviazione in memoria sfruttando file temporanei e preferisci flussi basati su file rispetto a stream interamente in memoria.

**Posso creare/salvare presentazioni in parallelo?**

Non è possibile operare sulla stessa istanza di [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) da [multiple threads](/slides/it/python-java/multithreading/). Esegui istanze separate e isolate per thread o processo.

**Come rimuovere la filigrana di prova e le limitazioni?**

[Applica una licenza](/slides/it/python-java/licensing/) una volta per processo. L'XML della licenza deve rimanere invariato e la configurazione della licenza dovrebbe essere sincronizzata se più thread sono coinvolti.

**Posso firmare digitalmente il PPTX che creo?**

Sì. Le [digital signatures](/slides/it/python-java/digital-signature-in-powerpoint/) (aggiunta e verifica) sono supportate per le presentazioni.

**Le macro (VBA) sono supportate nelle presentazioni create?**

Sì. Puoi [create/edit VBA projects](/slides/it/python-java/presentation-via-vba/) e salvare file abilitati alle macro come PPTM/PPSM.