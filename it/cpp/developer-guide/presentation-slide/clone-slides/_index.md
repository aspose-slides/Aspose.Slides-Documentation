---
title: "Clona le diapositive della presentazione in C++"
linktitle: "Clona diapositive"
type: docs
weight: 40
url: /it/cpp/clone-slides/
keywords:
- "clona diapositiva"
- "copia diapositiva"
- "salva diapositiva"
- "PowerPoint"
- "OpenDocument"
- "presentazione"
- "C++"
- "Aspose.Slides"
description: "Duplica rapidamente le diapositive PowerPoint con Aspose.Slides per C++. Segui i nostri chiari esempi di codice per automatizzare la creazione di PPT in pochi secondi ed eliminare il lavoro manuale."
---
## **Introduzione**

Il clonaggio è il processo di creare una copia esatta o una replica di qualcosa. Aspose.Slides per C++ consente anche di creare una copia o un clone di qualsiasi diapositiva e quindi inserire quella diapositiva clonata nella presentazione corrente o in qualsiasi altra presentazione aperta. Il processo di clonazione delle diapositive crea una nuova diapositiva che può essere modificata dagli sviluppatori senza alterare la diapositiva originale. Esistono diversi modi per clonare una diapositiva:

- Clona alla fine all'interno di una presentazione.
- Clona in un'altra posizione all'interno della presentazione.
- Clona alla fine in un'altra presentazione.
- Clona in un'altra posizione in un'altra presentazione.
- Clona in una posizione specifica in un'altra presentazione.

In Aspose.Slides per C++, (una collezione di [ISlide](https://reference.aspose.com/slides/it/cpp/aspose.slides/islide/) objects) esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) fornisce i metodi [AddClone](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/addclone/) e [InsertClone](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/insertclone/) per eseguire i tipi di clonazione diapositive sopra descritti

## **Clona una diapositiva alla fine di una presentazione**
Se vuoi clonare una diapositiva e poi utilizzarla all'interno dello stesso file di presentazione alla fine delle diapositive esistenti, usa il metodo [AddClone](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/addclone/) seguendo i passaggi elencati di seguito:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) .
1. Istanzia la classe [ISlideCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/) facendo riferimento alla collezione Slides esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) .
1. Chiama il metodo [AddClone](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/addclone/) esposto dall'oggetto [ISlideCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/) e passa la diapositiva da clonare come parametro al metodo [AddClone](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/addclone/) .
1. Scrivi il file della presentazione modificata.

Nell'esempio mostrato di seguito, abbiamo clonato una diapositiva (situata nella prima posizione – indice zero – della presentazione) alla fine della presentazione.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}

## **Clona una diapositiva in un'altra posizione all'interno di una presentazione**
Se vuoi clonare una diapositiva e poi utilizzarla all'interno dello stesso file di presentazione ma in una posizione diversa, usa il metodo [InsertClone](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/insertclone/) :

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) .
1. Istanzia la classe facendo riferimento alla collezione **Slides** esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) .
1. Chiama il metodo [InsertClone](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/insertclone/) esposto dall'oggetto [ISlideCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/) e passa la diapositiva da clonare insieme all'indice della nuova posizione come parametro al metodo [InsertClone](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/insertclone/) .
1. Scrivi la presentazione modificata come file PPTX.

Nell'esempio mostrato di seguito, abbiamo clonato una diapositiva (situata all'indice zero – posizione 1 – della presentazione) all'indice 1 – Posizione 2 – della presentazione.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}

## **Clona una diapositiva alla fine di un'altra presentazione**
Se devi clonare una diapositiva da una presentazione e usarla in un altro file di presentazione, alla fine delle diapositive esistenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) contenente la presentazione da cui la diapositiva sarà clonata.
1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) contenente la presentazione di destinazione a cui la diapositiva sarà aggiunta.
1. Istanzia la classe [ISlideCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/) facendo riferimento alla collezione **Slides** esposta dall'oggetto Presentation della presentazione di destinazione.
1. Chiama il metodo [AddClone](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/addclone/) esposto dall'oggetto [ISlideCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/) e passa la diapositiva della presentazione di origine come parametro al metodo [AddClone](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/addclone/) .
1. Scrivi il file della presentazione di destinazione modificata.

Nell'esempio mostrato di seguito, abbiamo clonato una diapositiva (dal primo indice della presentazione di origine) alla fine della presentazione di destinazione.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Clona una diapositiva in un'altra posizione in un'altra presentazione**
Se devi clonare una diapositiva da una presentazione e usarla in un altro file di presentazione, in una posizione specifica:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) contenente la presentazione di origine da cui la diapositiva sarà clonata.
1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) contenente la presentazione a cui la diapositiva sarà aggiunta.
1. Istanzia la classe [ISlideCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/) facendo riferimento alla collezione Slides esposta dall'oggetto Presentation della presentazione di destinazione.
1. Chiama il metodo [InsertClone](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/insertclone/) esposto dall'oggetto [ISlideCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/) e passa la diapositiva della presentazione di origine insieme alla posizione desiderata come parametro al metodo [InsertClone](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/insertclone/) .
1. Scrivi il file della presentazione di destinazione modificata.

Nell'esempio mostrato di seguito, abbiamo clonato una diapositiva (dal indice zero della presentazione di origine) all'indice 1 (posizione 2) della presentazione di destinazione.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Clona una diapositiva in una posizione specifica in un'altra presentazione**
Se devi clonare una diapositiva con diapositiva master da una presentazione e usarla in un'altra presentazione, è necessario prima clonare la diapositiva master desiderata dalla presentazione di origine a quella di destinazione. Successivamente devi utilizzare quella master per clonare la diapositiva con master. Il metodo **AddClone(ISlide, IMasterSlide)** si aspetta la diapositiva master dalla presentazione di destinazione piuttosto che da quella di origine. Per clonare la diapositiva con master, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) contenente la presentazione di origine da cui la diapositiva sarà clonata.
1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) contenente la presentazione di destinazione a cui la diapositiva sarà clonata.
1. Accedi alla diapositiva da clonare insieme alla diapositiva master.
1. Istanzia la classe [IMasterSlideCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/imasterslidecollection/) facendo riferimento alla collezione Masters esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) della presentazione di destinazione.
1. Chiama il metodo [AddClone](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/addclone/) esposto dall'oggetto [IMasterSlideCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/imasterslidecollection/) e passa il master del PPTX di origine da clonare come parametro al metodo [AddClone](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/addclone/) .
1. Istanzia la classe [ISlideCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/) impostando il riferimento alla collezione Slides esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) della presentazione di destinazione.
1. Chiama il metodo [AddClone](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/addclone/) esposto dall'oggetto [ISlideCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/) e passa la diapositiva della presentazione di origine da clonare insieme alla diapositiva master come parametro al metodo [AddClone](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/addclone/) .
1. Scrivi il file della presentazione di destinazione modificata.

Nell'esempio mostrato di seguito, abbiamo clonato una diapositiva con master (situata all'indice zero della presentazione di origine) alla fine della presentazione di destinazione usando il master della diapositiva di origine.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}

## **Clona una diapositiva alla fine di una sezione specificata**
Se vuoi clonare una diapositiva e poi usarla all'interno dello stesso file di presentazione ma in una sezione diversa, usa il metodo [**AddClone()**](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/addclone/) esposto dall'interfaccia [**ISlideCollection**](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/) . Aspose.Slides per C++ consente di clonare una diapositiva dalla prima sezione e poi inserire quella diapositiva clonata nella seconda sezione della stessa presentazione.

Il frammento di codice seguente mostra come clonare una diapositiva e inserire la diapositiva clonata in una sezione specificata.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}

## **Assicurati che le dimensioni della diapositiva corrispondano**

Quando cloni diapositive in un'altra presentazione, assicurati che la presentazione di destinazione abbia le stesse dimensioni della diapositiva della presentazione di origine. Se le dimensioni delle diapositive differiscono, Aspose.Slides non ridimensiona automaticamente le forme clonate: le loro coordinate e dimensioni originali vengono mantenute, il che può far sì che il contenuto appaia disallineato o si estenda oltre i bordi della diapositiva.

Puoi impostare le dimensioni della diapositiva della presentazione di destinazione in modo che corrispondano a quelle della sorgente prima di clonare il master e la diapositiva:

```cpp
auto sourceSize = sourcePresentation->get_SlideSize()->get_Size();

targetPresentation->get_SlideSize()->SetSize(
    sourceSize.get_Width(), sourceSize.get_Height(), SlideSizeScaleType::DoNotScale);
```

Esegui questo prima di clonare il master e la diapositiva.

## **FAQ**

**Le note dello speaker e i commenti dei revisori vengono clonati?**

Sì. La pagina delle note e i commenti di revisione sono inclusi nella copia. Se non li desideri, [rimuovili](/slides/it/cpp/presentation-notes/) dopo l'inserimento.

**Come vengono gestiti i grafici e le loro fonti dati?**

L'oggetto grafico, la formattazione e i dati incorporati vengono copiati. Se il grafico era collegato a una fonte esterna (ad esempio, una cartella di lavoro OLE incorporata), quel collegamento è preservato come un [oggetto OLE](/slides/it/cpp/manage-ole/). Dopo lo spostamento tra file, verifica la disponibilità dei dati e il comportamento di aggiornamento.

**Posso controllare la posizione di inserimento e le sezioni per il clone?**

Sì. Puoi inserire il clone a un indice di diapositiva specifico e posizionarlo in una [sezione](/slides/it/cpp/slide-section/) scelta. Se la sezione di destinazione non esiste, creala prima e poi sposta la diapositiva al suo interno.