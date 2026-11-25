---
title: Limita le modifiche alla presentazione con blocchi di forma in Python
linktitle: Limita le modifiche alla presentazione
type: docs
weight: 60
url: /it/python-java/applying-protection-to-presentation/
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
- Java
- Aspose.Slides
description: "Scopri come bloccare e sbloccare le forme nelle presentazioni PPTX con Aspose.Slides per Python via Java per limitare selezione, spostamento, ridimensionamento e raggruppamento."
---
## **Contesto**

Un uso comune di Aspose.Slides per Python via Java è creare, aggiornare e salvare presentazioni PowerPoint (PPTX) come parte di un flusso di lavoro automatizzato. Quando gli utenti ricevono queste presentazioni, limitare le modifiche alle forme può aiutare a preservare il layout e i contenuti desiderati.

Questo articolo spiega come le forme sono organizzate nelle diapositive e come applicare e rimuovere i blocchi delle forme in una presentazione PPTX. Questi blocchi consentono di limitare operazioni di editing specifiche su singole forme.

## **Composizione di una diapositiva**

Una diapositiva di presentazione è composta da componenti come autoshape, tabelle, oggetti OLE, forme raggruppate, cornici immagine, cornici video, connettori e altri elementi usati per costruire una presentazione. In Aspose.Slides per Python via Java, ogni elemento su una diapositiva è rappresentato da un oggetto che eredita dalla classe [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/).

Diversi tipi di forma espongono diverse opzioni di blocco. La classe [BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/) è la classe base per i blocchi delle forme. Aspose.Slides per Python via Java fornisce le seguenti classi di blocco:

- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) blocca le forme automatiche.  
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) blocca le forme dei connettori.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) blocca gli oggetti grafici.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) blocca le forme raggruppate.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) blocca le cornici immagine.  

Per applicare i blocchi su un’intera [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/), iterare attraverso le sue diapositive e impostare i blocchi appropriati su ogni forma supportata.

## **Applica e rimuovi la protezione**

Gli editor di presentazioni compatibili usano i blocchi delle forme per limitare operazioni di editing individuali. La crittografia dei file e la protezione in scrittura a livello di documento sono impostazioni separate di [impostazioni di protezione della presentazione](/slides/it/python-java/password-protected-presentation/).

### **Applica protezione alle forme PPTX**

Aspose.Slides per Python via Java fornisce la classe [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) per lavorare con le forme su una diapositiva.

L’esempio chiama [setSelectLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setPositionLocked) e [setSizeLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSizeLocked) con `True` per le forme automatiche, con blocchi equivalenti per le forme di gruppo, i connettori e le cornici immagine. I connettori usano [setPositionMove](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/#setPositionMove) per lo spostamento; i gruppi usano anche [setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) per limitare il raggruppamento.

L’esempio carica una presentazione PPTX esistente, controlla le forme nella collezione di forme di ciascuna diapositiva e salva una copia con queste restrizioni applicate. Le forme al di fuori dei quattro tipi gestiti rimangono inalterate. Il ciclo non attraversa le forme figlie all’interno di un gruppo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                auto_shape_lock = shape.getShapeLock()
                auto_shape_lock.setPositionLocked(True)
                auto_shape_lock.setSelectLocked(True)
                auto_shape_lock.setSizeLocked(True)
            elif isinstance(shape, GroupShape):
                group_shape_lock = shape.getShapeLock()
                group_shape_lock.setGroupingLocked(True)
                group_shape_lock.setPositionLocked(True)
                group_shape_lock.setSelectLocked(True)
                group_shape_lock.setSizeLocked(True)
            elif isinstance(shape, Connector):
                connector_shape_lock = shape.getShapeLock()
                connector_shape_lock.setPositionMove(True)
                connector_shape_lock.setSelectLocked(True)
                connector_shape_lock.setSizeLocked(True)
            elif isinstance(shape, PictureFrame):
                picture_frame_lock = shape.getShapeLock()
                picture_frame_lock.setPositionLocked(True)
                picture_frame_lock.setSelectLocked(True)
                picture_frame_lock.setSizeLocked(True)

    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Rimuovi protezione**

Per rimuovere un blocco di forma, impostarne il valore su `False`. Il seguente esempio carica una presentazione con blocchi di forma e cancella le restrizioni di selezione, spostamento e ridimensionamento tramite [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) e [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/). Rimuove inoltre la restrizione di raggruppamento passando `False` a [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) e salva una copia della presentazione. Altre impostazioni di blocco rimangono inalterate.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

presentation = Presentation("ProtectedSample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                auto_shape_lock = shape.getShapeLock()
                auto_shape_lock.setPositionLocked(False)
                auto_shape_lock.setSelectLocked(False)
                auto_shape_lock.setSizeLocked(False)
            elif isinstance(shape, GroupShape):
                group_shape_lock = shape.getShapeLock()
                group_shape_lock.setGroupingLocked(False)
                group_shape_lock.setPositionLocked(False)
                group_shape_lock.setSelectLocked(False)
                group_shape_lock.setSizeLocked(False)
            elif isinstance(shape, Connector):
                connector_shape_lock = shape.getShapeLock()
                connector_shape_lock.setPositionMove(False)
                connector_shape_lock.setSelectLocked(False)
                connector_shape_lock.setSizeLocked(False)
            elif isinstance(shape, PictureFrame):
                picture_frame_lock = shape.getShapeLock()
                picture_frame_lock.setPositionLocked(False)
                picture_frame_lock.setSelectLocked(False)
                picture_frame_lock.setSizeLocked(False)

    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Conserva il ritaglio di un’immagine**

Posiziona una foto denominata `photo.jpg` nella directory di lavoro. L’esempio ritaglia il 12 % a sinistra e l’8 % a destra, quindi chiama [setCropLocked](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/#setCropLocked) con `True` per conservare il ritaglio.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()

    photo_bytes = Path("photo.jpg").read_bytes()
    photo = presentation.getImages().addImage(photo_bytes)
    
    picture_frame = shapes.addPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo)
    picture_frame.getPictureFormat().setCropLeft(12)
    picture_frame.getPictureFormat().setCropRight(8)

    picture_lock = picture_frame.getPictureFrameLock()
    picture_lock.setAspectRatioLocked(False)
    picture_lock.setCropLocked(True)

    presentation.save("PictureLocked.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

In `PictureLocked.pptx`, PowerPoint disabilita il comando **Crop** quando selezioni la foto.

### **Mantieni un diagramma raggruppato**

L’esempio raggruppa un rettangolo e una freccia, quindi chiama [setUngroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setUngroupingLocked) con `True` per tenere insieme le due forme. Puoi comunque spostare il gruppo o modificare il riempimento di un componente.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()

    group = shapes.addGroupShape()
    group.getShapes().addAutoShape(ShapeType.Rectangle, 100, 70, 90, 50)
    group.getShapes().addAutoShape(ShapeType.RightArrow, 190, 80, 60, 30)
    group.getGroupShapeLock().setUngroupingLocked(True)

    presentation.save("DiagramLocked.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

In `DiagramLocked.pptx`, PowerPoint disabilita il comando **Ungroup** quando selezioni l’intero diagramma.

### **Riporta i blocchi di forma esistenti**

Per revisionare un modello, aprilo e leggi l’oggetto di blocco per ogni forma. Il metodo [getNoLocks](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/#getNoLocks) restituisce `True` quando tutte le bandiere di quell’oggetto sono disattivate e `False` quando almeno una è attiva. Un gruppo e i suoi figli hanno oggetti di blocco separati, quindi ispeziona i figli anche quando il gruppo non ha blocchi.

Questo esempio controlla lo spostamento per autoshape, cornici immagine e gruppi. Controlla inoltre il ritaglio per le immagini e lo sblocco per i gruppi. Il rapporto elenca le bandiere abilitate che riconosce e contrassegna i tipi di forma che non ispeziona.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, GroupShape, PictureFrame, Presentation


def inspect_shapes(shapes, slide_number, prefix=""):
    for shape in shapes:
        path = f"{prefix}{shape.getName()}"
        label = f"Slide {slide_number} | {path} | {shape.getClass().getSimpleName()}"
        flags = []

        if isinstance(shape, GroupShape):
            shape_lock = shape.getGroupShapeLock()
            if shape_lock.getUngroupingLocked():
                flags.append("UngroupingLocked")
        elif isinstance(shape, PictureFrame):
            shape_lock = shape.getPictureFrameLock()
            if shape_lock.getCropLocked():
                flags.append("CropLocked")
        elif isinstance(shape, AutoShape):
            shape_lock = shape.getAutoShapeLock()
        else:
            print(f"{label} | Uninspected")
            continue

        if shape_lock.getPositionLocked():
            flags.append("PositionLocked")
        if not shape_lock.getNoLocks():
            restrictions = ", ".join(flags) if flags else "Active flag not identified"
            print(f"{label} | {restrictions}")

        if isinstance(shape, GroupShape):
            inspect_shapes(shape.getShapes(), slide_number, f"{path}/")


presentation = Presentation("Sample.pptx")
try:
    for slide in presentation.getSlides():
        inspect_shapes(slide.getShapes(), slide.getSlideNumber())
finally:
    presentation.dispose()
```

Supponiamo che la diapositiva 1 di `Sample.pptx` contenga un gruppo chiamato `Layout` con sblocco del raggruppamento, un’immagine chiamata `Photo` al suo interno con ritaglio bloccato, e un rettangolo sbloccato chiamato `Free`. Il rapporto salta `Free` e stampa queste due righe:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Il rapporto legge le flag di editing a livello di forma memorizzate senza modificarle né salvare la presentazione. La protezione in scrittura a livello di documento è un’impostazione separata, e l’applicazione di ciascuna bandiera dipende dall’editor.

### **Conclusione**

Aspose.Slides per Python via Java ti consente di limitare operazioni di editing specifiche su singole forme o di applicare le stesse restrizioni su più diapositive. Scegli i blocchi supportati da ciascun tipo di forma e imposta i loro valori su `False` quando è necessario rimuovere tali restrizioni.

## **FAQ**

**Posso combinare blocchi di forma e protezione con password nella stessa presentazione?**

Sì. I blocchi di forma limitano operazioni di editing specifiche, mentre la [password protection](/slides/it/python-java/password-protected-presentation/) può limitare l’apertura o la modifica della presentazione. Puoi usare entrambi nello stesso file.

**Posso limitare l’editing su diapositive specifiche senza influire sulle altre?**

Sì. Applica i blocchi solo alle forme delle diapositive selezionate. Questo non modifica le impostazioni di blocco delle altre diapositive.

**Come posso applicare blocchi a forme individuali all’interno di un gruppo?**

Itera attraverso la collezione restituita dal metodo [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) del gruppo e applica i blocchi appropriati a ogni forma figlia. Ripeti l’operazione per eventuali gruppi annidati, seguendo il percorso di traversa mostrato nell’esempio di reporting.