---
title: Clona diapositive PowerPoint in Python
linktitle: Clona diapositive
type: docs
weight: 40
url: /it/python-net/clone-slides/
keywords:
- clona diapositiva
- copia diapositiva
- salva diapositiva
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Clona rapidamente le diapositive PowerPoint con Aspose.Slides per Python via .NET. Segui i nostri chiari esempi di codice e consigli per automatizzare la creazione di PPT in pochi secondi, aumentare la produttività ed eliminare il lavoro manuale."
---
## **Introduzione**

Il cloning è il processo di creare una copia esatta o una replica di qualcosa. Aspose.Slides permette anche di copiare (clonare) qualsiasi diapositiva e quindi inserire la diapositiva clonata nella presentazione corrente o in un\'altra presentazione aperta. Il cloning della diapositiva crea una nuova diapositiva che gli sviluppatori possono modificare senza influire sulla diapositiva originale. Esistono diversi modi per clonare una diapositiva:

- Clonare alla fine di una presentazione.
- Clonare in un\'altra posizione all\'interno di una presentazione.
- Clonare alla fine di un\'altra presentazione.
- Clonare in un\'altra posizione in un\'altra presentazione.
- Clonare in una posizione specifica in un\'altra presentazione.

In Aspose.Slides per Python via .NET, la [collezione di diapositive](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidecollection/) esposta dall\'oggetto [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) fornisce i metodi `add_clone` e `insert_clone` per eseguire questi tipi di clonazione della diapositiva.

## **Installazione**

```bash
pip install aspose.slides
```

## **Clonare alla fine nella stessa presentazione**

Se vuoi clonare una diapositiva all\'interno della stessa presentazione e aggiungerla alla fine delle diapositive esistenti, usa il metodo `add_clone`. Segui questi passaggi:

1. Crea un\'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Ottieni la collezione di diapositive dall\'oggetto [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Chiama il metodo `add_clone` sulla [SlideCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidecollection/), passando la diapositiva da clonare.
1. Salva la presentazione modificata.

Nell\'esempio sottostante, la prima diapositiva (indice 0) viene clonata e aggiunta alla fine della presentazione.

```py
import aspose.slides as slides

# Istanziare la classe Presentation per rappresentare il file della presentazione.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # Clona la diapositiva desiderata alla fine della collezione di diapositive nella stessa presentazione.
    presentation.slides.add_clone(presentation.slides[0])
    # Salva la presentazione modificata su disco.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Clonare in una posizione specifica nella stessa presentazione**

Se vuoi clonare una diapositiva all\'interno della stessa presentazione e posizionarla in una posizione diversa, usa il metodo `insert_clone`:

1. Crea un\'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Ottieni la collezione di diapositive dall\'oggetto [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Chiama il metodo `insert_clone` sulla [SlideCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidecollection/), passando la diapositiva da clonare e l\'indice di destinazione per la sua nuova posizione.
1. Salva la presentazione modificata.

Nell\'esempio sottostante, la diapositiva all\'indice 1 (posizione 2) viene clonata all\'indice 2 (posizione 3) nella stessa presentazione.

```py
import aspose.slides as slides

# Istanziare la classe Presentation per rappresentare il file della presentazione.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # Clona la diapositiva desiderata nella posizione (indice) specificata all'interno della stessa presentazione.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # Salva la presentazione modificata su disco.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Clonare alla fine di un\'altra presentazione**

Se è necessario clonare una diapositiva da una presentazione e aggiungerla alla fine di un\'altra presentazione:

1. Crea un\'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) per la presentazione di origine (quella che contiene la diapositiva da clonare).
1. Crea un\'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) per la presentazione di destinazione (dove la diapositiva verrà aggiunta).
1. Ottieni la collezione di diapositive dalla presentazione di destinazione.
1. Chiama `add_clone` sulla [SlideCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidecollection/) di destinazione, passando la diapositiva dalla presentazione di origine.
1. Salva la presentazione di destinazione modificata.

Nell\'esempio sottostante, la diapositiva all\'indice 0 nella presentazione di origine viene clonata alla fine della presentazione di destinazione.

```py
import aspose.slides as slides

# Istanziare la classe Presentation per rappresentare il file della presentazione di origine.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Istanziare la classe Presentation per il file PPTX di destinazione (dove la diapositiva sarà clonata).
    with slides.Presentation() as target_presentation:
        # Clona la diapositiva desiderata dalla presentazione di origine alla fine della collezione di diapositive nella presentazione di destinazione.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # Salva la presentazione di destinazione su disco.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Clonare in una posizione specifica in un\'altra presentazione**

Se è necessario clonare una diapositiva da una presentazione e inserirla in un\'altra presentazione in una posizione specifica:

1. Crea un\'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) per la presentazione di origine (quella che contiene la diapositiva da clonare).
1. Crea un\'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) per la presentazione di destinazione (dove la diapositiva verrà aggiunta).
1. Ottieni la collezione di diapositive dalla presentazione di destinazione.
1. Chiama il metodo `insert_clone` sulla [SlideCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidecollection/) di destinazione, passando la diapositiva dalla presentazione di origine e l\'indice di destinazione desiderato.
1. Salva la presentazione di destinazione modificata.

Nell\'esempio sottostante, la diapositiva all\'indice 0 nella presentazione di origine viene clonata all\'indice 2 (posizione 3) nella presentazione di destinazione.

```py
import aspose.slides as slides

# Istanziare la classe Presentation per rappresentare il file della presentazione di origine.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Istanziare la classe Presentation per il file PPTX di destinazione (dove la diapositiva deve essere clonata).
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # Inserire una copia della prima diapositiva dalla sorgente all'indice 2 nella presentazione di destinazione.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # Salvare la presentazione di destinazione su disco.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Clonare una diapositiva con il suo master in un\'altra presentazione**

Se è necessario clonare una diapositiva **con il suo master** da una presentazione e usarla in un\'altra, prima clona il master necessario dalla presentazione di origine nella presentazione di destinazione. Quindi utilizza quel master di destinazione quando cloni la diapositiva. Il metodo `add_clone(Slide, MasterSlide)` si aspetta un **master slide della presentazione di destinazione**, non di origine.

Per clonare una diapositiva con il suo master, segui questi passaggi:

1. Crea un\'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) per la presentazione di origine.
1. Crea un\'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) per la presentazione di destinazione.
1. Accedi alla diapositiva di origine da clonare e al suo master slide.
1. Ottieni la [MasterSlideCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/masterslidecollection/) dalla collezione master della presentazione di destinazione.
1. Chiama `add_clone` sulla [MasterSlideCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/masterslidecollection/) di destinazione, passando il master di origine per clonarlo nella destinazione.
1. Ottieni la [SlideCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidecollection/) dalla collezione di diapositive della presentazione di destinazione.
1. Chiama `add_clone` sulla [SlideCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidecollection/) di destinazione, passando la diapositiva di origine e il master clonato di destinazione.
1. Salva la presentazione di destinazione modificata.

Nell\'esempio sottostante, la diapositiva all\'indice 0 nella presentazione di origine viene clonata alla fine della presentazione di destinazione utilizzando il master clonato dalla sorgente.

```py
import aspose.slides as slides

# Istanziare la classe Presentation per rappresentare il file della presentazione di origine.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # Istanziare la classe Presentation per la presentazione di destinazione dove la diapositiva sarà clonata.
    with slides.Presentation() as target_presentation:
        # Ottenere la prima diapositiva dalla presentazione di origine.
        source_slide = source_presentation.slides[0]
        # Ottenere il master slide utilizzato dalla prima diapositiva.
        source_master = source_slide.layout_slide.master_slide
        # Clonare il master slide nella collezione master della presentazione di destinazione.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # Clonare la diapositiva dalla presentazione di origine alla fine della presentazione di destinazione usando il master clonato.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # Salvare la presentazione di destinazione su disco.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Clonare alla fine in una sezione specificata**

Con Aspose.Slides per Python via .NET, è possibile clonare una diapositiva da una sezione di una presentazione e inserirla in un\'altra sezione all\'interno della stessa presentazione. Per fare ciò, utilizza il metodo `add_clone(Slide, Section)` della classe [SlideCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidecollection/).

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

## **FAQ**

### Le note del relatore e i commenti dei revisori vengono clonati?

Sì. La pagina delle note e i commenti di revisione sono inclusi nel clone. Se non li vuoi, [rimuovili](/slides/it/python-net/presentation-notes/) dopo l\'inserimento.

### Come vengono gestiti i grafici e le loro origini dati?

L\'oggetto grafico, la formattazione e i dati incorporati vengono copiati. Se il grafico era collegato a una fonte esterna (ad esempio un workbook OLE incorporato), quel collegamento viene mantenuto come un [oggetto OLE](/slides/it/python-net/manage-ole/). Dopo lo spostamento tra file, verifica la disponibilità dei dati e il comportamento di aggiornamento. 

### Posso controllare la posizione di inserimento e le sezioni per il clone?

Sì. Puoi inserire il clone a un indice di diapositiva specifico e posizionarlo in una [sezione](/slides/it/python-net/slide-section/) scelta. Se la sezione di destinazione non esiste, creala prima e poi sposta la diapositiva al suo interno.