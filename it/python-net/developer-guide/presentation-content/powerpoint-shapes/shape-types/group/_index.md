---
title: Forme di presentazione di gruppo con Python
linktitle: Gruppo di forme
type: docs
weight: 40
url: /it/python-net/group/
keywords:
- gruppo di forme
- gruppo di forme
- aggiungi gruppo
- testo alternativo
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Impara a raggruppare e separare forme in PowerPoint e deck OpenDocument usando Aspose.Slides per Python—guida rapida, passo passo con codice gratuito."
---
## **Panoramica**

Questo articolo spiega come lavorare con i gruppi di forme in Aspose.Slides. Mostra come aggiungere un gruppo di forme a una diapositiva, inserire forme al suo interno e salvare la presentazione aggiornata. Dimostra anche come accedere alle forme memorizzate all'interno di un gruppo e leggere i loro valori `alternative_text`. Inoltre, l'articolo presenta brevemente le funzionalità correlate ai gruppi di forme, come gruppi nidificati, ordine Z e opzioni di blocco.

## **Aggiungere gruppi di forme**

Aspose.Slides supporta la lavorazione con gruppi di forme su una diapositiva. Questa funzionalità consente di creare presentazioni più ricche trattando più forme come un unico oggetto. È possibile aggiungere nuovi gruppi di forme, accedere a quelli esistenti, popolarli con forme figlio e leggere o modificare qualsiasi loro proprietà. Per aggiungere un gruppo di forme a una diapositiva:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Ottenere un riferimento a una diapositiva per indice.
3. Aggiungere un [GroupShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/groupshape/) alla diapositiva.
4. Aggiungere forme al nuovo gruppo di forme.
5. Salvare la presentazione modificata come file PPTX.

L'esempio seguente mostra come aggiungere un gruppo di forme a una diapositiva.

```py
import aspose.slides as slides

# Istanziare la classe Presentation.
with slides.Presentation() as presentation:
    # Ottieni la prima diapositiva.
    slide = presentation.slides[0]

    # Aggiungi un gruppo di forme alla diapositiva.
    group_shape = slide.shapes.add_group_shape()

    # Aggiungi forme all'interno del gruppo di forme.
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 300, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 300, 100, 100)

    # Scrivi il file PPTX su disco.
    presentation.save("group_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **Accedere alla proprietà Alt Text**

Questa sezione spiega come leggere il testo alternativo (Alt Text) delle forme contenute in un gruppo di forme su una diapositiva usando Aspose.Slides. Per accedere al testo alternativo delle forme:

1. Istanziare la classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) per rappresentare un file PPTX.
2. Ottenere un riferimento alla diapositiva per indice.
3. Accedere alla collezione di forme della diapositiva.
4. Accedere al [GroupShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/groupshape/).
5. Leggere la proprietà Alt Text.

L'esempio seguente recupera il testo alternativo delle forme contenute nei gruppi di forme.

```py
import aspose.slides as slides

# Istanziare la classe Presentation per aprire il file PPTX.
with slides.Presentation("group_shape.pptx") as presentation:
    # Ottieni la prima diapositiva.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.GroupShape):
            # Accedi al gruppo di forme.
            for child_shape in shape.shapes:
                # Accedi alla proprietà Alt Text.
                print(child_shape.alternative_text)
```

## **FAQ**

**Il raggruppamento nidificato (un gruppo dentro un altro gruppo) è supportato?**

Sì. [GroupShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/groupshape/) ha una proprietà [parent_group](https://reference.aspose.com/slides/it/python-net/aspose.slides/groupshape/parent_group/) che indica direttamente il supporto alla gerarchia (un gruppo può essere figlio di un altro gruppo).

**Come posso controllare l'ordine Z del gruppo rispetto ad altri oggetti nella diapositiva?**

Usa la proprietà [z_order_position](https://reference.aspose.com/slides/it/python-net/aspose.slides/groupshape/z_order_position/) del [GroupShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/groupshape/) per ispezionare la sua posizione nello stack di visualizzazione.

**Posso impedire lo spostamento, la modifica o il separare il raggruppamento?**

Sì. La sezione di blocco del gruppo è esposta tramite [group_shape_lock](https://reference.aspose.com/slides/it/python-net/aspose.slides/groupshape/group_shape_lock/), che consente di limitare le operazioni sull'oggetto.