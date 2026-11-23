---
title: Limita le modifiche alla presentazione con blocchi di forma in Python
linktitle: Limita le modifiche alla presentazione
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

Un uso comune di Aspose.Slides per Python via .NET è creare, aggiornare e salvare presentazioni PowerPoint (PPTX) come parte di un flusso di lavoro automatizzato. Quando gli utenti ricevono queste presentazioni, limitare le modifiche alle forme può contribuire a preservare il layout e il contenuto previsto.

Questo articolo spiega come le forme sono organizzate nelle diapositive e come applicare e rimuovere i blocchi delle forme in una presentazione PPTX. Questi blocchi consentono di limitare operazioni di modifica specifiche su forme individuali.

## **Composizione di una diapositiva**

Una diapositiva di una presentazione è composta da componenti come autoshape, tabelle, oggetti OLE, forme raggruppate, riquadri immagine, riquadri video, connettori e altri elementi utilizzati per costruire una presentazione. In Aspose.Slides per Python via .NET, ogni elemento su una diapositiva è rappresentato da un oggetto che eredita dalla classe [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) .

I diversi tipi di forma espongono opzioni di blocco differenti. La classe [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) è la classe base per i blocchi delle forme. Aspose.Slides per Python via .NET fornisce le seguenti classi di blocco:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) blocca le autoshape.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) blocca le forme connettore.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) blocca gli oggetti grafici.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) blocca le forme di gruppo.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) blocca i riquadri immagine.  

Per applicare i blocchi a una [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), iterare attraverso le sue diapositive e impostare i blocchi appropriati su ogni forma supportata.

## **Applica e rimuovi la protezione**

Gli editor di presentazioni compatibili utilizzano i blocchi delle forme per limitare operazioni di modifica individuali. La crittografia dei file e la protezione di scrittura a livello di documento sono impostazioni di [impostazioni di protezione della presentazione](/slides/it/python-net/password-protected-presentation/) separate.

### **Applica protezione alle forme PPTX**

Aspose.Slides per Python via .NET fornisce la classe [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) per lavorare con le forme su una diapositiva.

L'esempio imposta [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/), [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/) e [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) su `True` per le autoshape, con blocchi equivalenti per le forme di gruppo, i connettori e i riquadri immagine. I connettori utilizzano [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) per lo spostamento; i gruppi utilizzano anche [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) per limitare il raggruppamento.

L'esempio carica una presentazione PPTX esistente, controlla le forme nella collezione di forme di ogni diapositiva e salva una copia con queste restrizioni applicate. Le forme al di fuori dei quattro tipi gestiti rimangono invariate. Il ciclo non attraversa le forme figlio all'interno di un gruppo.

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

### **Rimuovi protezione**

Per rimuovere un blocco di forma, impostare il suo valore su `False`. L'esempio seguente carica una presentazione con blocchi di forma e cancella le restrizioni di selezione, spostamento e ridimensionamento tramite [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) e [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/). Cancella inoltre [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) e salva una copia della presentazione. Altre impostazioni di blocco rimangono invariate.

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

### **Preserva un ritaglio immagine**

Posizionare una foto denominata `photo.jpg` nella directory di lavoro. L'esempio ritaglia il 12 % a sinistra e l'8 % a destra, quindi imposta [crop_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/crop_locked/) sul riquadro immagine per preservare il ritaglio.

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

`PictureLocked.pptx` memorizza il blocco di ritaglio come `True`. In PowerPoint, il comando **Crop** è disabilitato quando la foto è selezionata.

### **Mantieni un diagramma raggruppato**

L'esempio raggruppa un rettangolo e una freccia, quindi imposta [ungrouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/ungrouping_locked/) sul gruppo stesso per mantenere i componenti del diagramma insieme. Altre modifiche, come lo spostamento del gruppo o la modifica del riempimento di un componente, rimangono disponibili.

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

`DiagramLocked.pptx` memorizza il blocco di separazione come `True`. In PowerPoint, il comando **Ungroup** è disabilitato quando l'intero diagramma è selezionato.

### **Conclusione**

Aspose.Slides per Python via .NET consente di limitare operazioni di modifica specifiche su forme individuali o di applicare le stesse restrizioni su più diapositive. Scegli i blocchi supportati da ogni tipo di forma e imposta i loro valori su `False` quando è necessario rimuovere tali restrizioni.

## **FAQ**

**Posso combinare i blocchi delle forme e la protezione con password nella stessa presentazione?**

Sì. I blocchi delle forme limitano operazioni di modifica specifiche, mentre la [protezione con password](/slides/it/python-net/password-protected-presentation/) può limitare l'apertura o la modifica della presentazione. È possibile utilizzare entrambi nello stesso file.

**Posso limitare la modifica su diapositive specifiche senza influire sulle altre?**

Sì. Applica i blocchi solo alle forme delle diapositive selezionate. Questo non modifica le impostazioni di blocco delle altre diapositive.

**Come posso applicare i blocchi a forme individuali all'interno di un gruppo?**

Itera attraverso la collezione di [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) del gruppo e applica i blocchi appropriati a ogni forma figlia. Ripeti l'operazione per eventuali gruppi nidificati. Gli esempi sopra elaborano solo la collezione di forme della diapositiva, quindi non impostano blocchi sui membri individuali del gruppo.