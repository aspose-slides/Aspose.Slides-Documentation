---
title: Creare presentazioni in Python
linktitle: Creare presentazione
type: docs
weight: 10
url: /it/python-net/create-presentation/
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
- Python
- Aspose.Slides
description: "Crea presentazioni PowerPoint in Python con Aspose.Slides—produci file PPT, PPTX e ODP, usufrui del supporto OpenDocument e salvali programmaticamente per risultati affidabili."
---
## **Panoramica**

Aspose.Slides per Python ti consente di creare un nuovo file di presentazione interamente tramite codice. Questo articolo mostra il flusso di lavoro principale—creare un oggetto [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) , recuperare la prima diapositiva, inserire una forma semplice e salvare il risultato—così puoi vedere quanto poco sia necessario configurare per generare una presentazione senza Microsoft Office. Poiché la stessa API scrive file PPT, PPTX e ODP, puoi puntare sia ai tradizionali formati PowerPoint sia a quelli OpenDocument da un unico codice. Aspose.Slides è adatto a ambienti desktop, web o server, offrendo alla tua applicazione Python un punto di partenza efficiente per aggiungere contenuti più ricchi, come testo, immagini o grafici, una volta che il mazzo di diapositive iniziale è pronto.

## **Crea una presentazione**

Creare un file PowerPoint da zero con Aspose.Slides per Python è semplice come istanziare la classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/). Il costruttore fornisce automaticamente un mazzo vuoto con una singola diapositiva, offrendoti una tela immediata per forme, testo, grafici o qualsiasi altro contenuto di cui la tua applicazione ha bisogno. Una volta modificata quella diapositiva—o aggiunte nuove—puoi salvare il risultato in PPTX, PPT legacy o anche nei formati OpenDocument. Il breve esempio di codice qui sotto illustra questo flusso di lavoro aggiungendo una forma semplice sulla prima diapositiva.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Ottieni un riferimento alla diapositiva tramite il suo indice.
1. Aggiungi un oggetto [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) di tipo `CLOUD` usando il metodo `add_auto_shape` esposto dalla collezione `shapes`.
1. Aggiungi del testo alla forma automatica.
1. Salva la presentazione modificata come file PPTX.

Nell'esempio seguente, una forma nuvola viene aggiunta alla prima diapositiva della presentazione.

```py
import aspose.slides as slides

# Istanzia la classe Presentation che rappresenta un file di presentazione.
with slides.Presentation() as presentation:
    # Ottieni la prima diapositiva.
    slide = presentation.slides[0]

    # Aggiungi una forma automatica di tipo CLOUD.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Salva la presentazione come file PPTX.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![La nuova presentazione](new_presentation.png)

## **Domande frequenti**

**In quali formati posso salvare una nuova presentazione?**

Puoi salvare in [PPTX, PPT e ODP](/slides/it/python-net/save-presentation/), ed esportare in [PDF](/slides/it/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/it/python-net/convert-powerpoint-to-xps/), [HTML](/slides/it/python-net/convert-powerpoint-to-html/), [SVG](/slides/it/python-net/convert-powerpoint-to-png/), e [immagini](/slides/it/python-net/convert-powerpoint-to-png/), tra gli altri.

**Posso partire da un modello (POTX/POTM) e salvarlo come un PPTX normale?**

Sì. Carica il modello e salvalo nel formato desiderato; i formati POTX/POTM/PPTM e simili [sono supportati](/slides/it/python-net/supported-file-formats/).

**Come posso controllare le dimensioni/rapporto d'aspetto della diapositiva quando creo una presentazione?**

Imposta la [dimensione della diapositiva](/slides/it/python-net/slide-size/) (incluse le preimpostazioni come 4:3 e 16:9 o dimensioni personalizzate) e scegli come il contenuto deve essere scalato.

**In quali unità sono misurate le dimensioni e le coordinate?**

In punti: 1 pollice corrisponde a 72 unità.

**Come gestire presentazioni molto grandi (con molti file multimediali) per ridurre l'uso di memoria?**

Usa le [strategie di gestione BLOB](/slides/it/python-net/manage-blob/), limita la memorizzazione in memoria sfruttando file temporanei e preferisci i flussi basati su file rispetto a quelli esclusivamente in memoria.

**Posso creare/salvare presentazioni in parallelo?**

Non è possibile operare sulla stessa istanza di [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) da [più thread](/slides/it/python-net/multithreading/). Esegui istanze separate e isolate per thread o processo.

**Come rimuovere la filigrana di prova e le limitazioni?**

[Applica una licenza](/slides/it/python-net/licensing/) una volta per processo. Il file XML della licenza deve rimanere non modificato e la configurazione della licenza dovrebbe essere sincronizzata se sono coinvolti più thread.

**Posso firmare digitalmente il PPTX che creo?**

Sì. Le [firme digitali](/slides/it/python-net/digital-signature-in-powerpoint/) (aggiunta e verifica) sono supportate per le presentazioni.

**Le macro (VBA) sono supportate nelle presentazioni create?**

Sì. Puoi [creare/modificare progetti VBA](/slides/it/python-net/presentation-via-vba/) e salvare file con macro abilitata come PPTM/PPSM.