---
title: Crea presentazioni in C++
linktitle: Crea presentazione
type: docs
weight: 10
url: /it/cpp/create-presentation/
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
- C++
- Aspose.Slides
description: "Crea presentazioni in C++ con Aspose.Slides—produci file PPT, PPTX e ODP, approfitta del supporto OpenDocument e salvali programmaticamente per risultati affidabili."
---
## **Panoramica**

Questo articolo mostra come creare una presentazione in Aspose.Slides, aggiungere una casella di testo alla sua prima diapositiva e salvare il risultato come file. Una breve FAQ alla fine copre le domande più comuni su formati, modelli, dimensionamento delle diapositive, unità, utilizzo della memoria, threading, licenze, firme digitali e supporto VBA.

Prima di iniziare, aggiungi Aspose.Slides al tuo progetto: da NuGet in un progetto Visual Studio su Windows, o dal pacchetto ZIP con CMake su Linux. Vedi [Installazione](/slides/it/cpp/installation/).

## **Crea una presentazione PowerPoint**

Per creare una presentazione e inserire una casella di testo nella sua prima diapositiva, segui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/). Una nuova presentazione contiene già una diapositiva vuota.
1. Recupera quella diapositiva con il metodo [Presentation::get_Slide](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_slide/) e il suo indice, 0.
1. Aggiungi un rettangolo con il metodo [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishapecollection/addautoshape/) e imposta il suo testo con il metodo [ITextFrame::set_Text](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/set_text/).
1. Salva la presentazione come file PPTX con il metodo [Presentation::Save](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/save/).

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

int main()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    shape->get_TextFrame()->set_Text(u"Hello, Aspose.Slides!");
    presentation->Save(u"hello.pptx", SaveFormat::Pptx);
    presentation->Dispose();
    return 0;
}
```

L'angolo superiore sinistro del rettangolo è a 50 punti dal bordo sinistro e a 50 punti dal bordo superiore della diapositiva, e il rettangolo è largo 400 punti e alto 100 punti. Il programma salva *hello.pptx* nella sua directory di lavoro, con una diapositiva che contiene il rettangolo e il suo testo. Senza una licenza, Aspose.Slides aggiunge anche un watermark di valutazione a ogni diapositiva salvata; vedi [Licenze](/slides/it/cpp/licensing/).

## **FAQ**

### Quali formati posso utilizzare per salvare una nuova presentazione?

Puoi salvare in [PPTX, PPT e ODP](/slides/it/cpp/save-presentation/), ed esportare in [PDF](/slides/it/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/it/cpp/convert-powerpoint-to-xps/), [HTML](/slides/it/cpp/convert-powerpoint-to-html/), [SVG](/slides/it/cpp/render-a-slide-as-an-svg-image/) e [immagini](/slides/it/cpp/convert-powerpoint-to-png/), tra gli altri.

### Posso partire da un modello (POTX/POTM) e salvare come un normale PPTX?

Sì. Carica il modello e salva nel formato desiderato; i formati POTX/POTM/PPTM e simili [sono supportati](/slides/it/cpp/supported-file-formats/).

### Come controllo la dimensione / rapporto d'aspetto della diapositiva quando creo una presentazione?

Imposta la [dimensione della diapositiva](/slides/it/cpp/slide-size/) (incluse le impostazioni predefinite come 4:3 e 16:9 o dimensioni personalizzate) e scegli come deve scalare il contenuto.

### In quali unità sono misurate le dimensioni e le coordinate?

In punti: 1 pollice corrisponde a 72 unità.

### Come gestire presentazioni molto grandi (con molti file multimediali) per ridurre l'uso della memoria?

Usa le [strategie di gestione BLOB](/slides/it/cpp/manage-blob/), limita la memorizzazione in RAM sfruttando file temporanei e preferisci flussi basati su file anziché flussi esclusivamente in memoria.

### Posso creare / salvare presentazioni in parallelo?

Non puoi operare sulla stessa istanza di [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) da [thread multipli](/slides/it/cpp/multithreading/). Esegui istanze separate e isolate per thread o processo.

### Come rimuovere il watermark di prova e le limitazioni?

[Applica una licenza](/slides/it/cpp/licensing/) una volta per processo. L'XML della licenza deve rimanere invariato e la configurazione della licenza dovrebbe essere sincronizzata se sono coinvolti più thread.

### Posso firmare digitalmente il PPTX che creo?

Sì. Le [firme digitali](/slides/it/cpp/digital-signature-in-powerpoint/) (aggiunta e verifica) sono supportate per le presentazioni.

### Le macro (VBA) sono supportate nelle presentazioni create?

Sì. Puoi [creare/modificare progetti VBA](/slides/it/cpp/presentation-via-vba/) e salvare file abilitati alle macro come PPTM/PPSM.