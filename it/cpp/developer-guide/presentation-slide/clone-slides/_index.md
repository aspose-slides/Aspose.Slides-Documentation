---
title: Clona diapositive di presentazione in C++
linktitle: Clona Diapositive
type: docs
weight: 40
url: /it/cpp/clone-slides/
keywords:
- clona diapositiva
- copia diapositiva
- salva diapositiva
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Duplica rapidamente le diapositive PowerPoint con Aspose.Slides per C++. Segui i nostri chiari esempi di codice per automatizzare la creazione di PPT in pochi secondi ed eliminare il lavoro manuale."
---
## **Introduzione**

Il cloning è il processo di creazione di una copia esatta o replica di qualcosa. Aspose.Slides per C++ rende possibile creare una copia o clonare qualsiasi diapositiva e quindi inserire quella diapositiva clonata nella presentazione corrente o in qualsiasi altra presentazione aperta. Il processo di clonazione della diapositiva crea una nuova diapositiva che gli sviluppatori possono modificare senza alterare la diapositiva originale. Esistono diversi modi per clonare una diapositiva:

- Clona alla fine all'interno di una presentazione.
- Clona in un'altra posizione all'interno della presentazione.
- Clona alla fine in un'altra presentazione.
- Clona in un'altra posizione in un'altra presentazione.
- Clona in una posizione specifica in un'altra presentazione.

In Aspose.Slides per C++, (una raccolta di [ISlide](https://reference.aspose.com/slides/it/cpp/aspose.slides/islide/) oggetti) esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) fornisce i metodi [AddClone](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/addclone/) e [InsertClone](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/insertclone/) per eseguire i tipi di clonazione descritti sopra.

## **Clona una diapositiva alla fine di una presentazione**
Se desideri clonare una diapositiva e poi utilizzarla nello stesso file di presentazione alla fine delle diapositive esistenti, usa il metodo [AddClone](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/addclone/) secondo i passaggi elencati di seguito:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
1. Istanziare la classe [ISlideCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/) facendo riferimento alla collezione Slides esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
1. Chiamare il metodo [AddClone](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/addclone/) esposto dall'oggetto [ISlideCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/) e passare la diapositiva da clonare come parametro al metodo [AddClone](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/addclone/).
1. Scrivere il file della presentazione modificata.

Nell'esempio mostrato di seguito, abbiamo clonato una diapositiva (situata nella prima posizione – indice zero – della presentazione) alla fine della presentazione.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}

## **Clona una diapositiva in un'altra posizione all'interno di una presentazione**
 in Presentazione**
Se desideri clonare una diapositiva e poi utilizzarla nello stesso file di presentazione ma in una posizione diversa, usa il metodo [InsertClone](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/insertclone/):

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
1. Istanziare la classe facendo riferimento alla collezione **Slides** esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
1. Chiamare il metodo [InsertClone](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/insertclone/) esposto dall'oggetto [ISlideCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/) e passare la diapositiva da clonare insieme all'indice per la nuova posizione come parametro al metodo [InsertClone](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/insertclone/).
1. Scrivere la presentazione modificata come file PPTX.

Nell'esempio mostrato di seguito, abbiamo clonato una diapositiva (situata all'indice zero – posizione 1 – della presentazione) all'indice 1 – Posizione 2 – della presentazione.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}

## **Clona una diapositiva alla fine di un'altra presentazione**
Se devi clonare una diapositiva da una presentazione e usarla in un'altra presentazione, alla fine delle diapositive esistenti:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) contenente la presentazione da cui la diapositiva sarà clonata.
1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) contenente la presentazione di destinazione a cui la diapositiva sarà aggiunta.
1. Istanziare la classe [ISlideCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/) facendo riferimento alla collezione **Slides** esposta dall'oggetto Presentation della presentazione di destinazione.
1. Chiamare il metodo [AddClone](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/addclone/) esposto dall'oggetto [ISlideCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/) e passare la diapositiva dalla presentazione sorgente come parametro al metodo [AddClone](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/addclone/).
1. Scrivere il file della presentazione di destinazione modificato.

Nell'esempio mostrato di seguito, abbiamo clonato una diapositiva (dal primo indice della presentazione sorgente) alla fine della presentazione di destinazione.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Clona una diapositiva in un'altra posizione in un'altra presentazione**
Se devi clonare una diapositiva da una presentazione e usarla in un'altra presentazione, in una posizione specifica:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) contenente la presentazione sorgente da cui la diapositiva sarà clonata.
1. Creare un'istanzia della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) contenente la presentazione a cui la diapositiva sarà aggiunta.
1. Istanziare la classe [ISlideCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/) facendo riferimento alla collezione Slides dell'oggetto Presentation della presentazione di destinazione.
1. Chiamare il metodo [InsertClone](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/insertclone/) esposto dall'oggetto [ISlideCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/) e passare la diapositiva dalla presentazione sorgente insieme alla posizione desiderata come parametro al metodo [InsertClone](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/insertclone/).
1. Scrivere il file della presentazione di destinazione modificato.

Nell'esempio mostrato di seguito, abbiamo clonato una diapositiva (dal indice zero della presentazione sorgente) all'indice 1 (posizione 2) della presentazione di destinazione.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Clona una diapositiva in una posizione specifica in un'altra presentazione**
Se devi clonare una diapositiva con master slide da una presentazione e usarla in un'altra presentazione, devi prima clonare il master slide desiderato dalla presentazione sorgente a quella di destinazione. Successivamente devi utilizzare quel master slide per clonare la diapositiva con master. Il metodo **AddClone(ISlide, IMasterSlide)** si aspetta il master slide della presentazione di destinazione anziché quello della presentazione sorgente. Per clonare la diapositiva con master, segui i passaggi qui sotto:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) contenente la presentazione sorgente da cui la diapositiva sarà clonata.
1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) contenente la presentazione di destinazione a cui la diapositiva sarà clonata.
1. Accedere alla diapositiva da clonare insieme al master slide.
1. Istanziare la classe [IMasterSlideCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/imasterslidecollection/) facendo riferimento alla collezione Masters esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) della presentazione di destinazione.
1. Chiamare il metodo [AddClone](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/addclone/) esposto dall'oggetto [IMasterSlideCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/imasterslidecollection/) e passare il master dalla presentazione PPTX sorgente da clonare come parametro al metodo [AddClone](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/addclone/).
1. Istanziare la classe [ISlideCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/) impostando il riferimento alla collezione Slides esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) della presentazione di destinazione.
1. Chiamare il metodo [AddClone](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/addclone/) esposto dall'oggetto [ISlideCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/) e passare la diapositiva dalla presentazione sorgente da clonare e il master slide come parametro al metodo [AddClone](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/addclone/).
1. Scrivere il file della presentazione di destinazione modificato.

Nell'esempio mostrato di seguito, abbiamo clonato una diapositiva con master (situata all'indice zero della presentazione sorgente) alla fine della presentazione di destinazione usando il master della diapositiva sorgente.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}

## **Clona una diapositiva alla fine di una sezione specificata**
Se desideri clonare una diapositiva e poi usarla nello stesso file di presentazione ma in una sezione diversa, utilizza il metodo [**AddClone()**](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/addclone/) esposto dall'interfaccia [**ISlideCollection**](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/). Aspose.Slides per C++ consente di clonare una diapositiva dalla prima sezione e poi inserire quella diapositiva clonata nella seconda sezione della stessa presentazione.

Il frammento di codice seguente mostra come clonare una diapositiva e inserire la diapositiva clonata in una sezione specificata.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}

## **FAQ**

**Le note del relatore e i commenti del revisore vengono clonati?**

Sì. La pagina delle note e i commenti di revisione sono inclusi nella copia. Se non li desideri, [rimuovili](/slides/it/cpp/presentation-notes/) dopo l'inserimento.

**Come vengono gestiti i grafici e le loro fonti dati?**

L'oggetto grafico, la formattazione e i dati incorporati vengono copiati. Se il grafico era collegato a una fonte esterna (ad es., una cartella di lavoro OLE incorporata), quel collegamento è conservato come un [OLE object](/slides/it/cpp/manage-ole/). Dopo lo spostamento tra file, verifica la disponibilità dei dati e il comportamento di aggiornamento.

**Posso controllare la posizione di inserimento e le sezioni della copia?**

Sì. Puoi inserire la copia in un indice di diapositiva specifico e posizionarla in una [section](/slides/it/cpp/slide-section/) scelta. Se la sezione di destinazione non esiste, creala prima e poi sposta la diapositiva al suo interno.