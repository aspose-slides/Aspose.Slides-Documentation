---
title: Recupera e Aggiorna le Proprietà di Visualizzazione della Presentazione in Python
linktitle: Proprietà di Visualizzazione
type: docs
weight: 80
url: /it/python-net/presentation-view-properties/
keywords:
- proprietà di visualizzazione
- visualizzazione normale
- contenuto della struttura
- icone della struttura
- aggancia divisore verticale
- visualizzazione singola
- stato della barra
- dimensione
- regolazione automatica
- zoom predefinito
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Scopri le proprietà di visualizzazione di Aspose.Slides per Python via .NET per personalizzare i formati PPT, PPTX e ODP delle diapositive—regola layout, livelli di zoom e impostazioni di visualizzazione."
---
## **Introduzione**

La visualizzazione normale è composta da tre regioni di contenuto: la diapositiva stessa, una regione laterale di contenuto e una regione di contenuto inferiore. Proprietà relative al posizionamento delle diverse regioni di contenuto. Queste informazioni consentono all'applicazione di salvare lo stato della visualizzazione nel file, in modo che, quando viene riaperta, la visualizzazione sia nello stesso stato in cui è stata salvata l'ultima volta la presentazione.

È stata aggiunta la proprietà [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/it/python-net/aspose.slides/viewproperties/normal_view_properties/) per fornire l'accesso alle proprietà della visualizzazione normale della presentazione.

Sono state aggiunte le classi [NormalViewProperties](https://reference.aspose.com/slides/it/python-net/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/it/python-net/aspose.slides/normalviewrestoredproperties/) e i loro discendenti, nonché l'enumerazione [SplitterBarStateType](https://reference.aspose.com/slides/it/python-net/aspose.slides/splitterbarstatetype/).

## **Informazioni su INormalViewProperties**

Rappresenta le proprietà della visualizzazione normale.

La proprietà **ShowOutlineIcons** specifica se l'applicazione deve mostrare le icone quando visualizza il contenuto della struttura in una delle regioni di contenuto della modalità visualizzazione normale.

La proprietà **SnapVerticalSplitter** specifica se il divisore verticale deve bloccare lo stato ridotto quando la regione laterale è sufficientemente piccola.

La proprietà **PreferSingleView** specifica se l'utente preferisce vedere un'unica regione di contenuto a finestra intera rispetto alla visualizzazione normale standard con tre regioni di contenuto. Se abilitato, l'applicazione può scegliere di visualizzare una delle regioni di contenuto nell'intera finestra.

Le proprietà **VerticalBarState** e **HorizontalBarState** specificano lo stato in cui deve essere mostrata la barra divisore verticale o orizzontale. Una barra divisore orizzontale separa la diapositiva dalla regione di contenuto sotto la diapositiva, mentre una barra divisore verticale separa la diapositiva dalla regione laterale di contenuto. I valori possibili sono: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** e **SplitterBarStateType.Restored**.

Le proprietà **RestoredLeft** e **RestoredTop** specificano le dimensioni della regione superiore o laterale della diapositiva nella visualizzazione normale, quando per **VerticalBarState** e **HorizontalBarState** è stato applicato il valore **SplitterBarStateType.Restored**.

## **Informazioni sul ripristino di INormalViewProperties**

Specifica le dimensioni della regione della diapositiva (larghezza quando è figlia di RestoredTop, altezza quando è figlia di RestoredLeft) nella visualizzazione normale, quando la regione ha una dimensione variabile ripristinata (né ridotta né massimizzata).

La proprietà **DimensionSize** specifica la dimensione della regione della diapositiva (larghezza quando è figlia di RestoredTop, altezza quando è figlia di RestoredLeft).

La proprietà **AutoAdjust** specifica se la dimensione della regione laterale di contenuto deve compensare la nuova dimensione quando si ridimensiona la finestra contenente la visualizzazione nell'applicazione.

Un esempio è riportato di seguito per mostrare come accedere alle proprietà **ViewProperties.NormalViewProperties** di una presentazione.

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # Ripristina le proprietà di visualizzazione della presentazione
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **Imposta valore di zoom predefinito**

Aspose.Slides for Python via .NET ora supporta l'impostazione del valore di zoom predefinito per la presentazione, in modo che quando la presentazione viene aperta lo zoom sia già impostato. Ciò può essere fatto impostando le [view_properties](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/view_properties/) di una presentazione. Le proprietà della visualizzazione della diapositiva così come le [notes_view_properties](https://reference.aspose.com/slides/it/python-net/aspose.slides/viewproperties/notes_view_properties/) possono essere impostate programmaticamente. In questo argomento vedremo, con un esempio, come impostare le proprietà di visualizzazione di una presentazione in Aspose.Slides.

Per impostare le proprietà di visualizzazione, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/)
1. Imposta le [view properties](https://reference.aspose.com/slides/it/python-net/aspose.slides/viewproperties/) della presentazione
1. Scrivi la presentazione in un file PPTX

Nell'esempio riportato di seguito, abbiamo impostato il valore di zoom per la visualizzazione della diapositiva così come per la visualizzazione delle note.

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Impostare le proprietà di visualizzazione della presentazione
    presentation.view_properties.slide_view_properties.scale = 100 # Valore di zoom in percentuale per la visualizzazione della diapositiva
    presentation.view_properties.notes_view_properties.scale = 100 # Valore di zoom in percentuale per la visualizzazione delle note 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Can I set different view settings for different sections of a presentation?**

[View settings](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/view_properties/) sono definiti a livello di presentazione ([Normal View](https://reference.aspose.com/slides/it/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/it/python-net/aspose.slides/viewproperties/slide_view_properties/)), non per sezione, quindi un unico set di parametri si applica all'intero documento quando viene aperto.

**Can I predefine different view states for different users?**

No. Le impostazioni sono memorizzate nel file e sono condivise. Le applicazioni di visualizzazione possono rispettare le preferenze dell'utente, ma il file stesso contiene un unico set di proprietà di visualizzazione.

**Can I prepare a template with predefined View Properties so new presentations open the same way?**

Sì. Poiché le [view properties](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/view_properties/) sono memorizzate a livello di presentazione, puoi includerle in un modello e creare nuovi documenti da esso con la stessa configurazione iniziale della visualizzazione.