---
title: Limitare le modifiche alla presentazione con i lock delle forme in Python
linktitle: Limitare le modifiche alla presentazione
type: docs
weight: 70
url: /it/python-net/applying-protection-to-presentation/
keywords:
- impedire modifiche
- proteggere dalla modifica
- bloccare forma
- bloccare posizione
- bloccare selezione
- bloccare ridimensionamento
- bloccare raggruppamento
- PowerPoint
- PPTX
- presentazione
- Python
- Aspose.Slides
description: "Scopri come bloccare e sbloccare le forme nelle presentazioni PPTX con Aspose.Slides per Python via .NET per limitare la selezione, lo spostamento, il ridimensionamento e il raggruppamento."
---
## **Contesto**

Un uso comune di Aspose.Slides per Python via .NET è creare, aggiornare e salvare presentazioni PowerPoint (PPTX) come parte di un flusso di lavoro automatizzato. Quando gli utenti ricevono queste presentazioni, limitare le modifiche alle forme può aiutare a preservare il layout e il contenuto previsti.

Questo articolo spiega come le forme sono organizzate nelle diapositive e come applicare e rimuovere i lock delle forme in una presentazione PPTX. Questi lock consentono di limitare operazioni di modifica specifiche su forme individuali.

## **Composizione di una diapositiva**

Una diapositiva di presentazione è composta da componenti come autoshape, tabelle, oggetti OLE, forme raggruppate, riquadri immagine, riquadri video, connettori e altri elementi usati per costruire una presentazione. In Aspose.Slides per Python via .NET, ogni elemento su una diapositiva è rappresentato da un oggetto che eredita dalla classe [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/).

Tipi diversi di forme espongono opzioni di lock differenti. La classe [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) è la classe base per i lock delle forme. Aspose.Slides per Python via .NET fornisce le seguenti classi di lock:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) blocca le autoshape.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) blocca le forme connettore.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) blocca gli oggetti grafici.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) blocca le forme raggruppate.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) blocca i riquadri immagine.  

Per applicare i lock a una [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), scorrere le sue diapositive e impostare i lock appropriati su ciascuna forma supportata.

## **Applicare e rimuovere la protezione**

Gli editor di presentazioni compatibili usano i lock delle forme per limitare operazioni di modifica individuali. La crittografia dei file e la protezione in scrittura a livello di documento sono impostazioni separate di [presentation protection settings](/slides/it/python-net/password-protected-presentation/).

### **Applicare la protezione alle forme PPTX**

Aspose.Slides per Python via .NET fornisce la classe [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) per lavorare con le forme su una diapositiva.

L'esempio imposta [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/), [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/) e [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) su `True` per le autoshape, con lock equivalenti per le forme raggruppate, i connettori e i riquadri immagine. I connettori usano [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) per lo spostamento; i gruppi usano inoltre [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) per limitare il raggruppamento.

L'esempio carica una presentazione PPTX esistente, controlla le forme nella collezione di forme di ciascuna diapositiva e salva una copia con queste restrizioni applicate. Le forme al di fuori dei quattro tipi gestiti rimangono inalterate. Il ciclo non attraversa le forme figlio all'interno di un gruppo.

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.GroupShape):
                shape.shape_lock.grouping_locked = True
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.Connector):
                shape.shape_lock.position_move = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.PictureFrame):
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True

    presentation.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Rimuovere la protezione**

Per rimuovere un lock di forma, impostarne il valore su `False`. L'esempio seguente carica una presentazione con lock di forma e cancella le restrizioni di selezione, movimento e ridimensionamento tramite [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) e [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/). Cancella inoltre [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) e salva una copia della presentazione. Altre impostazioni di lock rimangono inalterate.

```python
import aspose.slides as slides

with slides.Presentation("ProtectedSample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.GroupShape):
                shape.shape_lock.grouping_locked = False
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.Connector):
                shape.shape_lock.position_move = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.PictureFrame):
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False

    presentation.save("RemovedProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Preservare il ritaglio di un'immagine**

Posizionare una foto chiamata `photo.jpg` nella directory di lavoro. L'esempio ritaglia il 12 % a sinistra e l'8 % a destra, quindi imposta [crop_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/crop_locked/) sul riquadro immagine. Questa flag limita ulteriori ritagli e preserva il ritaglio esistente.

```python
from pathlib import Path

import aspose.slides as slides

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes

    photo_bytes = Path("photo.jpg").read_bytes()
    photo = presentation.images.add_image(photo_bytes)

    picture_frame = shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 30, 270, 160, photo)
    picture_frame.picture_format.crop_left = 12
    picture_frame.picture_format.crop_right = 8
    picture_frame.shape_lock.aspect_ratio_locked = False
    picture_frame.shape_lock.crop_locked = True

    presentation.save("PictureLocked.pptx", slides.export.SaveFormat.PPTX)
```

`PictureLocked.pptx` memorizza il lock di ritaglio come `True`. In PowerPoint, il comando **Crop** è disabilitato quando la foto è selezionata.

### **Mantenere un diagramma raggruppato**

L'esempio raggruppa un rettangolo e una freccia, quindi imposta [ungrouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/ungrouping_locked/) sul gruppo stesso per tenere insieme i componenti del diagramma. Altre modifiche, come lo spostamento del gruppo o la variazione del riempimento di un componente, rimangono disponibili.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes
    
    group_shape = shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 70, 90, 50)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RIGHT_ARROW, 190, 80, 60, 30)
    group_shape.shape_lock.ungrouping_locked = True

    presentation.save("DiagramLocked.pptx", slides.export.SaveFormat.PPTX)
```

`DiagramLocked.pptx` memorizza il lock di separazione come `True`. In PowerPoint, il comando **Ungroup** è disabilitato quando l'intero diagramma è selezionato.

### **Segnalare i lock di forma esistenti**

Per esaminare un modello, aprirlo e leggere l'oggetto lock per ciascuna forma. [no_locks](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/no_locks/) è `True` quando tutte le flag su quell'oggetto sono disabilitate e `False` quando almeno una è abilitata. Un gruppo e i suoi figli hanno oggetti lock separati, quindi è necessario ispezionare i figli anche quando il gruppo non ha lock.

Questo esempio verifica il movimento per autoshape, riquadri immagine e gruppi, il ritaglio per le immagini e la separazione per i gruppi. Segnala le flag riconosciute e contrassegna i tipi di forma che non ispeziona.

```python
import aspose.slides as slides


def inspect_shapes(shapes, slide_number, prefix=""):
    for shape in shapes:
        path = prefix + shape.name
        label = f"Slide {slide_number} | {path} | {type(shape).__name__}"
        if not isinstance(shape, (slides.GroupShape, slides.PictureFrame, slides.AutoShape)):
            print(f"{label} | Uninspected")
            continue

        shape_lock = shape.shape_lock
        if not shape_lock.no_locks:
            flags = []
            if isinstance(shape, slides.GroupShape) and shape_lock.ungrouping_locked:
                flags.append("ungrouping_locked")
            if isinstance(shape, slides.PictureFrame) and shape_lock.crop_locked:
                flags.append("crop_locked")
            if shape_lock.position_locked:
                flags.append("position_locked")
            restrictions = ", ".join(flags) if flags else "Active flag not identified"
            print(f"{label} | {restrictions}")

        if isinstance(shape, slides.GroupShape):
            inspect_shapes(shape.shapes, slide_number, path + "/")


with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        inspect_shapes(slide.shapes, slide.slide_number)
```

Supponiamo che la diapositiva 1 di `Sample.pptx` contenga un gruppo chiamato `Layout` con lock di separazione, un'immagine chiamata `Photo` al suo interno con lock di ritaglio e un rettangolo sbloccato chiamato `Free`. Il report ignora `Free` e stampa queste due righe:

```text
Slide 1 | Layout | GroupShape | ungrouping_locked
Slide 1 | Layout/Photo | PictureFrame | crop_locked
```

Il report legge le flag di modifica a livello di forma memorizzate senza modificarle né salvare la presentazione. La protezione in scrittura a livello di documento è un'impostazione separata, e l'applicazione di ciascuna flag dipende dall'editor.

### **Conclusione**

Aspose.Slides per Python via .NET consente di limitare operazioni di modifica specifiche su forme individuali o di applicare le stesse restrizioni su più diapositive. Scegli i lock supportati da ciascun tipo di forma e imposta i loro valori su `False` quando è necessario rimuovere tali restrizioni.

## **FAQ**

**Posso combinare i lock di forma e la protezione con password nella stessa presentazione?**

Sì. I lock di forma limitano operazioni di modifica specifiche, mentre la [password protection](/slides/it/python-net/password-protected-presentation/) può limitare l'apertura o la modifica della presentazione. È possibile utilizzare entrambi nello stesso file.

**Posso limitare la modifica su diapositive specifiche senza influenzare le altre?**

Sì. Applica i lock solo alle forme delle diapositive selezionate. Questo non modifica le impostazioni di lock sulle altre diapositive.

**Come posso applicare i lock a forme individuali all'interno di un gruppo?**

Itera attraverso la collezione di [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) del gruppo e applica i lock appropriati a ciascuna forma figlia. Ripeti l'operazione per tutti i gruppi annidati, seguendo il percorso di attraversamento mostrato nell'esempio di report.