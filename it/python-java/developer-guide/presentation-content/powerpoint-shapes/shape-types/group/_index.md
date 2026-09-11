---
title: Forme di presentazione di gruppo in Python via Java
linktitle: Gruppo di forme
type: docs
weight: 40
url: /it/python-java/group/
keywords:
- forma di gruppo
- gruppo di forme
- aggiungi gruppo
- testo alternativo
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Impara a raggruppare e separare le forme nelle presentazioni PowerPoint utilizzando Aspose.Slides per Python via Java—una guida passo passo con codice Python gratuito."
---
## **Panoramica**

Questo articolo spiega come lavorare con le forme di gruppo in Aspose.Slides. Mostra come aggiungere una forma di gruppo a una diapositiva, inserire forme al suo interno e salvare la presentazione aggiornata. Dimostra inoltre come accedere alle forme memorizzate all'interno di un gruppo e leggere il loro testo alternativo utilizzando [getAlternativeText](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getAlternativeText). Inoltre, l'articolo copre brevemente le funzionalità correlate alle forme di gruppo, come gruppi nidificati, ordine Z e opzioni di blocco.

## **Aggiungere una Forma di Gruppo**

Aspose.Slides supporta la gestione delle forme di gruppo sulle diapositive. Questa funzionalità aiuta gli sviluppatori a creare presentazioni più ricche. Aspose.Slides per Python via Java supporta l'aggiunta e l'accesso alle forme di gruppo. È possibile popolare una forma di gruppo con forme o accedere alle sue proprietà. Per aggiungere una forma di gruppo a una diapositiva usando Aspose.Slides per Python via Java:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva tramite il suo indice.
1. Aggiungere una forma di gruppo alla diapositiva.
1. Aggiungere forme alla forma di gruppo.
1. Salvare la presentazione modificata come file PPTX.

L'esempio seguente aggiunge una forma di gruppo a una diapositiva:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ShapeFrame, ShapeType

# Istanziare la classe Presentation.
presentation = Presentation()
try:
    # Ottenere la prima diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Accedere alla raccolta di forme della diapositiva.
    slide_shapes = slide.getShapes()

    # Aggiungere una forma di gruppo alla diapositiva.
    group_shape = slide_shapes.addGroupShape()

    # Aggiungere forme all'interno della forma di gruppo.
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100)

    # Impostare il frame della forma di gruppo.
    group_frame = ShapeFrame(100, 300, 500, 40, NullableBool.False_, NullableBool.False_, 0)
    group_shape.setFrame(group_frame)

    # Scrivere il file PPTX su disco.
    presentation.save("GroupShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Accedere al Testo Alternativo**

Questa sezione mostra come accedere al testo alternativo delle forme all'interno di un gruppo su una diapositiva. Per accedere a questo testo utilizzando Aspose.Slides per Python via Java:

1. Istanziare la classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) che rappresenta un file PPTX.
1. Ottenere un riferimento a una diapositiva tramite il suo indice.
1. Accedere alla raccolta di forme della diapositiva.
1. Accedere alla forma di gruppo.
1. Leggere il testo alternativo delle sue forme utilizzando [getAlternativeText](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getAlternativeText).

L'esempio seguente accede al testo alternativo delle forme all'interno di un gruppo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GroupShape, Presentation

# Istanziare la classe Presentation che rappresenta il file PPTX.
presentation = Presentation("AltText.pptx")
try:
    # Ottenere la prima diapositiva.
    slide = presentation.getSlides().get_Item(0)

    for i in range(slide.getShapes().size()):
        # Accedere a una forma nella raccolta di forme della diapositiva.
        shape = slide.getShapes().get_Item(i)

        if isinstance(shape, GroupShape):
            # Accedere alle forme all'interno del gruppo.
            for j in range(shape.getShapes().size()):
                child_shape = shape.getShapes().get_Item(j)

                # Leggere il testo alternativo.
                print(child_shape.getAlternativeText())
finally:
    presentation.dispose()
```

## **FAQ**

**Il raggruppamento nidificato (un gruppo dentro un altro gruppo) è supportato?**

Sì. [GroupShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/groupshape/) ha un metodo [getParentGroup](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getParentGroup), che indica il supporto alla gerarchia: un gruppo può essere figlio di un altro gruppo.

**Come posso controllare l'ordine Z del gruppo rispetto ad altri oggetti sulla diapositiva?**

Usare il metodo [getZOrderPosition](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getZOrderPosition) dell'oggetto [GroupShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/groupshape/) per ispezionare la sua posizione nello stack di visualizzazione.

**Posso impedire lo spostamento, la modifica o il separare il gruppo?**

Sì. I blocchi del gruppo sono esposti tramite [getGroupShapeLock](https://reference.aspose.com/slides/it/python-java/aspose.slides/groupshape/#getGroupShapeLock), che consente di limitare le operazioni sull'oggetto.