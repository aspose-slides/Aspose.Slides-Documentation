---
title: Clona le diapositive PowerPoint in Python
linktitle: Clona diapositive
type: docs
weight: 40
url: /it/python-net/clone-slides/
keywords:
- clonare diapositiva
- copia diapositiva
- salva diapositiva
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Clona o duplica rapidamente le diapositive PowerPoint con Aspose.Slides per Python tramite .NET. Segui i nostri esempi di codice chiari e consigli per automatizzare la creazione di PPT in pochi secondi, aumentare la produttività e eliminare il lavoro manuale."
---
## **Introduzione**

Il cloning è il processo di creare una copia esatta o una replica di qualcosa. Aspose.Slides consente anche di copiare (clonare) qualsiasi diapositiva e quindi inserire la diapositiva clonata nella presentazione corrente o in qualsiasi altra presentazione aperta. Il clonaggio delle diapositive crea una nuova diapositiva che gli sviluppatori possono modificare senza influire sulla diapositiva originale. Esistono diversi modi per clonare una diapositiva:

- Clonare alla fine di una presentazione.
- Clonare in un'altra posizione all'interno di una presentazione.
- Clonare alla fine di un'altra presentazione.
- Clonare in un'altra posizione in un'altra presentazione.
- Clonare in una posizione specifica in un'altra presentazione.

In Aspose.Slides per Python via .NET, la [collezione di diapositive](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidecollection/) esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) fornisce i metodi `add_clone` e `insert_clone` per eseguire questi tipi di clonazione diapositive.

## **Installazione**

```bash
pip install aspose.slides
```

## **Clona alla Fine nella Stessa Presentazione**

Se desideri clonare una diapositiva all'interno della stessa presentazione e aggiungerla alla fine delle diapositive esistenti, usa il metodo `add_clone`. Segui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Ottieni la collezione di diapositive dall'oggetto [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Chiama il metodo `add_clone` sulla [SlideCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidecollection/), passando la diapositiva da clonare.
1. Salva la presentazione modificata.

Nell'esempio sotto, la prima diapositiva (indice 0) viene clonata e aggiunta alla fine della presentazione.

```py
import aspose.slides as slides

# Istanziare la classe Presentation per rappresentare il file di presentazione.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # Clonare la diapositiva desiderata alla fine della collezione di diapositive nella stessa presentazione.
    presentation.slides.add_clone(presentation.slides[0])
    # Salvare la presentazione modificata su disco.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Clona in una Posizione Specifica nella Stessa Presentazione**

Se desideri clonare una diapositiva all'interno della stessa presentazione e posizionarla in una posizione diversa, usa il metodo `insert_clone`:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Ottieni la collezione di diapositive dall'oggetto [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Chiama il metodo `insert_clone` sulla [SlideCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidecollection/), passando la diapositiva da clonare e l'indice di destinazione per la sua nuova posizione.
1. Salva la presentazione modificata.

Nell'esempio sotto, la diapositiva all'indice 1 (posizione 2) viene clonata all'indice 2 (posizione 3) all'interno della stessa presentazione.

```py
import aspose.slides as slides

# Istanziare la classe Presentation per rappresentare il file di presentazione.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # Clonare la diapositiva desiderata nella posizione (indice) specificata all'interno della stessa presentazione.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # Salvare la presentazione modificata su disco.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Clona alla Fine di un'Altra Presentazione**

Se hai bisogno di clonare una diapositiva da una presentazione e aggiungerla alla fine di un'altra presentazione:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) per la presentazione di origine (quella che contiene la diapositiva da clonare).
1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) per la presentazione di destinazione (dove la diapositiva verrà aggiunta).
1. Ottieni la collezione di diapositive dalla presentazione di destinazione.
1. Chiama `add_clone` sulla [SlideCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidecollection/) di destinazione, passando la diapositiva dalla presentazione di origine.
1. Salva la presentazione di destinazione modificata.

Nell'esempio sotto, la diapositiva all'indice 0 nella presentazione di origine è clonata alla fine della presentazione di destinazione.

```py
import aspose.slides as slides

# Istanziare la classe Presentation per rappresentare il file di presentazione di origine.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Istanziare la classe Presentation per il PPTX di destinazione (dove la diapositiva sarà clonata).
    with slides.Presentation() as target_presentation:
        # Clonare la diapositiva desiderata dalla presentazione di origine alla fine della collezione di diapositive nella presentazione di destinazione.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # Salvare la presentazione di destinazione su disco.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Clona in una Posizione Specifica in un'Altra Presentazione**

Se hai bisogno di clonare una diapositiva da una presentazione e inserirla in un'altra presentazione in una posizione specifica:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) per la presentazione di origine (quella che contiene la diapositiva da clonare).
1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) per la presentazione di destinazione (dove la diapositiva verrà aggiunta).
1. Ottieni la collezione di diapositive dalla presentazione di destinazione.
1. Chiama il metodo `insert_clone` sulla [SlideCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidecollection/) di destinazione, passando la diapositiva dalla presentazione di origine e l'indice di destinazione desiderato.
1. Salva la presentazione di destinazione modificata.

Nell'esempio sotto, la diapositiva all'indice 0 nella presentazione di origine è clonata all'indice 2 (posizione 3) nella presentazione di destinazione.

```py
import aspose.slides as slides

# Istanziare la classe Presentation per rappresentare il file di presentazione di origine.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Istanziare la classe Presentation per il PPTX di destinazione (dove la diapositiva deve essere clonata).
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # Inserire un clone della prima diapositiva dalla presentazione di origine all'indice 2 nella presentazione di destinazione.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # Salvare la presentazione di destinazione su disco.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Clona una Diapositiva con la Sua Diapositiva Master in un'Altra Presentazione**

Se hai bisogno di clonare una diapositiva **con il suo master** da una presentazione e usarla in un'altra, prima clona il master slide necessario dalla presentazione di origine nella presentazione di destinazione. Quindi utilizza quel master di destinazione quando cloni la diapositiva. Il metodo `add_clone(Slide, MasterSlide)` richiede un **master slide dalla presentazione di destinazione**, non da quella di origine.

Per clonare una diapositiva con il suo master, segui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) per la presentazione di origine (quella che contiene la diapositiva da clonare).
1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) per la presentazione di destinazione.
1. Accedi alla diapositiva di origine da clonare e alla sua diapositiva master.
1. Ottieni la [MasterSlideCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/masterslidecollection/) dalla collezione master della presentazione di destinazione.
1. Chiama `add_clone` sulla [MasterSlideCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/masterslidecollection/) di destinazione, passando il master di origine per clonarlo nella destinazione.
1. Ottieni la [SlideCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidecollection/) dalla collezione di diapositive della presentazione di destinazione.
1. Chiama `add_clone` sulla [SlideCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidecollection/) di destinazione, passando la diapositiva di origine e il master di destinazione clonato.
1. Salva la presentazione di destinazione modificata.

Nell'esempio sotto, la diapositiva all'indice 0 nella presentazione di origine è clonata alla fine della presentazione di destinazione usando il master clonato dalla presentazione di origine.

```py
import aspose.slides as slides

# Istanziare la classe Presentation per rappresentare il file di presentazione di origine.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # Istanziare la classe Presentation per la presentazione di destinazione dove la diapositiva sarà clonata.
    with slides.Presentation() as target_presentation:
        # Ottenere la prima diapositiva dalla presentazione di origine.
        source_slide = source_presentation.slides[0]
        # Ottenere la diapositiva master usata dalla prima diapositiva.
        source_master = source_slide.layout_slide.master_slide
        # Clonare la diapositiva master nella collezione master della presentazione di destinazione.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # Clonare la diapositiva dalla presentazione di origine alla fine della presentazione di destinazione usando il master clonato.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # Salvare la presentazione di destinazione su disco.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Clonare alla fine in una sezione specificata**

Con Aspose.Slides per Python via .NET, è possibile clonare una diapositiva da una sezione di una presentazione e inserirla in un'altra sezione all'interno della stessa presentazione. Per farlo, utilizza il metodo `add_clone(Slide, Section)` della classe [SlideCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidecollection/).

Il seguente esempio Python mostra come clonare una diapositiva e inserire il clone in una sezione specificata:

```py
import aspose.slides as slides

# Creare una nuova presentazione vuota.
with slides.Presentation() as presentation:
    # Aggiungere una diapositiva vuota basata sul layout della prima diapositiva.
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Aggiungere una forma ellisse alla nuova diapositiva; questa diapositiva sarà clonata in seguito.
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # Aggiungere un'altra diapositiva vuota basata sul layout della prima diapositiva.
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Creare una sezione chiamata "Section2" che inizia da slide2.
    section = presentation.sections.add_section("Section2", slide2)
    # Clonare la diapositiva creata in precedenza nella sezione "Section2".
    presentation.slides.add_clone(slide, section)
    # Salvare la presentazione come file PPTX.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Assicurati che le Dimensioni delle Diapositive Corrispondano**

Quando cloni diapositive in un'altra presentazione, assicurati che la presentazione di destinazione abbia le stesse dimensioni della diapositiva dell'origine. Se le dimensioni delle diapositive differiscono, Aspose.Slides non ridimensiona automaticamente le forme clonate: le loro coordinate e dimensioni originali vengono preservate, il che può far apparire il contenuto disallineato o estendersi oltre i bordi della diapositiva.

Puoi impostare le dimensioni della diapositiva della presentazione di destinazione per farle corrispondere a quelle dell'origine prima di clonare il master e la diapositiva:

```py
source_size = source_presentation.slide_size.size

target_presentation.slide_size.set_size(
    source_size.width, source_size.height, slides.SlideSizeScaleType.DO_NOT_SCALE)
```

Esegui questa operazione prima di clonare il master e la diapositiva.

## **FAQ**

**Le note del relatore e i commenti dei revisori vengono clonati?**

Sì. La pagina delle note e i commenti di revisione sono inclusi nel clone. Se non li desideri, [rimuovili](/slides/it/python-net/presentation-notes/) dopo l'inserimento.

**Come vengono gestiti i grafici e le loro origini dati?**

L'oggetto grafico, la formattazione e i dati incorporati vengono copiati. Se il grafico era collegato a una fonte esterna (ad esempio, una cartella di lavoro OLE incorporata), quel collegamento viene mantenuto come un [oggetto OLE](/slides/it/python-net/manage-ole/). Dopo lo spostamento tra file, verifica la disponibilità dei dati e il comportamento di aggiornamento.

**Posso controllare la posizione di inserimento e le sezioni per il clone?**

Sì. Puoi inserire il clone in un indice di diapositiva specifico e posizionarlo in una [sezione](/slides/it/python-net/slide-section/) scelta. Se la sezione di destinazione non esiste, creala prima e poi sposta la diapositiva al suo interno.
