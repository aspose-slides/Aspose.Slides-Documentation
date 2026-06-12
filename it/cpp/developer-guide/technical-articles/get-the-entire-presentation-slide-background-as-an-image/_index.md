---
title: Ottieni l'intero sfondo della diapositiva da una presentazione come immagine
linktitle: Intero sfondo della diapositiva
type: docs
weight: 95
url: /it/cpp/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- sfondo diapositiva
- sfondo finale
- estrarre lo sfondo
- sfondo completo
- sfondo in immagine
- sfondo PPT
- sfondo PPTX
- sfondo ODP
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Estrai i sfondi completi delle diapositive come immagini da presentazioni PowerPoint e OpenDocument usando Aspose.Slides per C++, semplificando i flussi di lavoro visuali."
---
## **Panoramica**

Nelle presentazioni PowerPoint, lo sfondo delle diapositive può essere composto da più elementi, includendo l'immagine di sfondo della diapositiva, il tema della presentazione, lo schema di colori e gli oggetti posizionati sulla diapositiva master o sulla diapositiva layout. Questo articolo mostra come estrarre l'intero sfondo della diapositiva come immagine usando Aspose.Slides. Poiché non esiste un metodo unico per questa operazione, l'approccio consiste nel clonare la diapositiva selezionata in una presentazione temporanea, rimuovere le forme della diapositiva e quindi convertire lo sfondo risultante in un'immagine.

## **Ottenere l'intero sfondo della diapositiva**

Aspose.Slides per C++ non fornisce un metodo semplice per estrarre l'intero sfondo della diapositiva della presentazione come immagine, ma è possibile seguire i passaggi seguenti per farlo:
1. Carica la presentazione usando la classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
1. Ottieni le dimensioni della diapositiva dalla presentazione.
1. Seleziona una diapositiva.
1. Crea una presentazione temporanea.
1. Imposta le stesse dimensioni della diapositiva nella presentazione temporanea.
1. Clona la diapositiva selezionata nella presentazione temporanea.
1. Elimina le forme dalla diapositiva clonata.
1. Converti la diapositiva clonata in un'immagine.

Il seguente esempio di codice estrae l'intero sfondo della diapositiva della presentazione come immagine.
```cpp
auto slideIndex = 0;
auto imageScale = 1;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slides()->idx_get(slideIndex);

auto tempPresentation = System::MakeObject<Presentation>();

auto slideWidth = slideSize.get_Width();
auto slideHeight = slideSize.get_Height();
tempPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::DoNotScale);

auto clonedSlide = tempPresentation->get_Slides()->AddClone(slide);
clonedSlide->get_Shapes()->Clear();

auto background = clonedSlide->GetImage(imageScale, imageScale);
background->Save(u"output.png", ImageFormat::Png);

tempPresentation->Dispose();
presentation->Dispose();
```

## **FAQ**

**I gradienti complessi, le trame o i riempimenti immagine da una diapositiva master verranno preservati nell'immagine di sfondo risultante?**

Sì. Aspose.Slides renderizza i riempimenti gradienti, immagine e texture definiti sulla diapositiva, sul layout o sul master. Se è necessario isolare l'aspetto dai master ereditati, [imposta uno sfondo proprio](/slides/it/cpp/presentation-background/) sulla diapositiva corrente prima dell'esportazione.

**Posso aggiungere una filigrana all'immagine di sfondo risultante prima di salvarla?**

Sì. È possibile [aggiungere una filigrana](/slides/it/cpp/watermark/) come forma o immagine su una [copia di lavoro della diapositiva](/slides/it/cpp/clone-slides/) (posizionata dietro gli altri contenuti) e quindi esportare. Questo consente di generare un'immagine di sfondo con la filigrana incorporata.

**Posso ottenere lo sfondo per un layout o un master specifico senza associarlo a una diapositiva esistente?**

Sì. Accedi al master o layout desiderato, applicalo a una [diapositiva temporanea](/slides/it/cpp/clone-slides/) con le dimensioni richieste e esporta quella diapositiva per ottenere lo sfondo derivato da quel layout o master.

**Ci sono limitazioni di licenza che influiscono sull'esportazione delle immagini?**

Le funzionalità di rendering sono completamente disponibili con una [licenza valida](/slides/it/cpp/licensing/). In modalità di valutazione, l'output può includere limitazioni come una filigrana. Attiva la licenza una volta per processo prima di eseguire esportazioni batch.