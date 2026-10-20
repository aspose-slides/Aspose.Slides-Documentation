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
description: "Scopri come bloccare e sbloccare le forme nelle presentazioni PPTX con Aspose.Slides per Python tramite Java per limitare la selezione, lo spostamento, il ridimensionamento e il raggruppamento."
---
## **Contesto**

Un uso comune di Aspose.Slides per Python tramite Java è creare, aggiornare e salvare presentazioni PowerPoint (PPTX) come parte di un flusso di lavoro automatizzato. Quando gli utenti ricevono queste presentazioni, limitare le modifiche alle forme può aiutare a preservare il layout e il contenuto previsto.

Questo articolo spiega come le forme sono organizzate nelle diapositive e come applicare e rimuovere i blocchi delle forme in una presentazione PPTX. Questi blocchi consentono di limitare operazioni di modifica specifiche su forme individuali.

## **Composizione di una diapositiva**

Una diapositiva di presentazione è composta da componenti come autoshapes, tabelle, oggetti OLE, forme raggruppate, cornici immagine, cornici video, connettori e altri elementi usati per costruire una presentazione. In Aspose.Slides per Python tramite Java, ogni elemento su una diapositiva è rappresentato da un oggetto che eredita dalla classe [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/).

Diversi tipi di forma espongono diverse opzioni di blocco. La classe [BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/) è la classe base per i blocchi delle forme. Aspose.Slides per Python tramite Java fornisce le seguenti classi di blocco:

- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) blocca le autoshapes.  
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) blocca le forme connettore.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) blocca gli oggetti grafici.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) blocca le forme di gruppo.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) blocca le cornici immagine.  

Per applicare i blocchi a una [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/), scorrere le sue diapositive e impostare i blocchi appropriati su ogni forma supportata.

## **Applicare e rimuovere la protezione**

I blocchi delle forme limitano operazioni come la selezione, lo spostamento e il ridimensionamento delle forme. Non rendono l'intera presentazione non modificabile.

### **Applicare la protezione alle forme PPTX**

Aspose.Slides per Python tramite Java fornisce la classe [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) per lavorare con le forme su una diapositiva.

L'esempio chiama [setSelectLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setPositionLocked) e [setSizeLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSizeLocked) con `True` per le autoshapes, con blocchi equivalenti per le forme di gruppo, i connettori e le cornici immagine. I connettori usano [setPositionMove](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/#setPositionMove) per lo spostamento; i gruppi usano anche [setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) per limitare il raggruppamento.

L'esempio carica una presentazione PPTX esistente, verifica le forme nella collezione di forme di ciascuna diapositiva e salva una copia con queste restrizioni applicate. Le forme al di fuori dei quattro tipi gestiti rimangono invariate. Il ciclo non attraversa le forme figlio all'interno di un gruppo.

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

### **Rimuovere la protezione**

Per rimuovere un blocco di forma, impostare il suo valore su `False`. L'esempio seguente carica una presentazione con blocchi sulle forme e cancella le restrizioni di selezione, movimento e ridimensionamento tramite [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) e [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/). Rimuove inoltre la restrizione di raggruppamento passando `False` a [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) e salva una copia della presentazione. Le altre impostazioni di blocco rimangono invariate.

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

### **Conclusione**

Aspose.Slides per Python tramite Java consente di limitare operazioni di modifica specifiche su forme individuali o di applicare le stesse restrizioni a più diapositive. Scegli i blocchi supportati da ciascun tipo di forma e imposta i loro valori su `False` quando è necessario rimuovere tali restrizioni.

## **FAQ**

**Posso combinare i blocchi delle forme e la protezione con password nella stessa presentazione?**

Sì. I blocchi delle forme limitano operazioni di modifica specifiche, mentre la [protezione con password](/slides/it/python-java/password-protected-presentation/) può limitare l'apertura o la modifica della presentazione. È possibile utilizzare entrambi nello stesso file.

**Posso limitare la modifica su diapositive specifiche senza influire su altre?**

Sì. Applica i blocchi solo alle forme delle diapositive selezionate. Questo non modifica le impostazioni di blocco delle altre diapositive.

**Come posso applicare i blocchi a forme individuali all'interno di un gruppo?**

Scorri la collezione restituita dal metodo [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) del gruppo e applica i blocchi appropriati a ogni forma figlio. Ripeti l'operazione per eventuali gruppi annidati. Gli esempi sopra elaborano solo la collezione di forme della diapositiva, quindi non impostano blocchi sui singoli membri del gruppo.