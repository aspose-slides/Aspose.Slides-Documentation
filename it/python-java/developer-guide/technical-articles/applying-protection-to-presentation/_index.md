---
title: Impedire le modifiche alla presentazione con blocchi di forma
linktitle: Impedire le modifiche alla presentazione
type: docs
weight: 60
url: /it/python-java/applying-protection-to-presentation/
keywords:
- impedire modifiche
- proteggere dalla modifica
- bloccare forma
- bloccare posizione
- bloccare selezione
- bloccare dimensione
- bloccare raggruppamento
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Scopri come Aspose.Slides per Python tramite Java blocca o sblocca le forme nei file PPT, PPTX e ODP, proteggendo le presentazioni consentendo modifiche controllate e una consegna più rapida."
---
## **Contesto**

Un uso comune di Aspose.Slides è creare, aggiornare e salvare presentazioni Microsoft PowerPoint (PPTX) all'interno di un flusso di lavoro automatizzato. Gli utenti di applicazioni che impiegano Aspose.Slides in questo modo hanno accesso alle presentazioni generate, quindi proteggerle dalla modifica è una preoccupazione frequente. È importante che le presentazioni generate automaticamente mantengano la formattazione e il contenuto originali.

Questo articolo spiega come sono strutturate le presentazioni e le diapositive e come Aspose.Slides per Python tramite Java possa applicare una protezione a una presentazione e successivamente rimuoverla. Fornisce agli sviluppatori un modo per controllare come le presentazioni generate dalle loro applicazioni vengano utilizzate.

## **Composizione di una diapositiva**

Una diapositiva di una presentazione è composta da componenti come forme automatiche, tabelle, oggetti OLE, forme raggruppate, riquadri immagine, riquadri video, connettori e altri elementi usati per costruire una presentazione. In Aspose.Slides per Python tramite Java, ogni elemento su una diapositiva è rappresentato da un oggetto che eredita dalla classe [Shape](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/).

La struttura del PPTX è complessa, quindi a differenza del PPT, dove è possibile utilizzare un blocco generico per tutti i tipi di forme, i diversi tipi di forma richiedono blocchi differenti. La classe [BaseShapeLock](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseshapelock/) è la classe di blocco generica per PPTX. I seguenti tipi di blocchi sono supportati in Aspose.Slides per Python tramite Java per PPTX:

- [AutoShapeLock](https://reference.aspose.com/slides/it/python-java/aspose.slides/autoshapelock/) blocca le forme automatiche.  
- [ConnectorLock](https://reference.aspose.com/slides/it/python-java/aspose.slides/connectorlock/) blocca le forme connettore.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/it/python-java/aspose.slides/graphicalobjectlock/) blocca gli oggetti grafici.  
- [GroupShapeLock](https://reference.aspose.com/slides/it/python-java/aspose.slides/groupshapelock/) blocca le forme raggruppate.  
- [PictureFrameLock](https://reference.aspose.com/slides/it/python-java/aspose.slides/pictureframelock/) blocca i riquadri immagine.  

Qualsiasi azione eseguita su tutti gli oggetti forma in un oggetto [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) è applicata all'intera presentazione.

## **Applicare e rimuovere la protezione**

Applicare la protezione garantisce che una presentazione non possa essere modificata. È una tecnica utile per proteggere il contenuto della presentazione.

### **Applicare la protezione alle forme PPTX**

Aspose.Slides per Python tramite Java fornisce la classe [Shape](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/) per lavorare con le forme su una diapositiva.

Come accennato in precedenza, ogni classe forma ha una classe di blocco forma associata per la protezione. Questo articolo si concentra sui blocchi NoSelect, NoMove e NoResize. Questi blocchi garantiscono che le forme non possano essere selezionate (tramite clic del mouse o altri metodi di selezione) e che non possano essere spostate o ridimensionate.

Il campione di codice che segue applica la protezione a tutti i tipi di forma in una presentazione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

# Istanziare la classe Presentation che rappresenta un file PPTX.
presentation = Presentation("Sample.pptx")
try:
    # Scorrere tutte le diapositive nella presentazione.
    for slide in presentation.getSlides():
        # Scorrere tutte le forme nella diapositiva.
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

    # Salvare il file della presentazione.
    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Rimuovere la protezione**

Per sbloccare una forma, impostare il valore del blocco applicato su `False`. Il seguente campione di codice mostra come sbloccare le forme in una presentazione bloccata.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

# Istanziare la classe Presentation che rappresenta un file PPTX.
presentation = Presentation("ProtectedSample.pptx")
try:
    # Scorrere tutte le diapositive nella presentazione.
    for slide in presentation.getSlides():
        # Scorrere tutte le forme nella diapositiva.
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

    # Salvare il file della presentazione.
    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Conclusione**

Aspose.Slides offre diverse opzioni per proteggere le forme in una presentazione. È possibile bloccare una singola forma o iterare attraverso tutte le forme in una presentazione e bloccare ciascuna per proteggere efficacemente l'intero file. È possibile rimuovere la protezione impostando il valore del blocco su `False`.

## **FAQ**

**Posso combinare i blocchi di forma e la protezione con password nella stessa presentazione?**

Sì. I blocchi limitano la modifica degli oggetti all'interno del file, mentre la [protezione con password](/slides/it/python-java/password-protected-presentation/) controlla l'accesso all'apertura e/o al salvataggio delle modifiche. Questi meccanismi si completano a vicenda e funzionano insieme.

**Posso limitare la modifica su diapositive specifiche senza influenzare le altre?**

Sì. Applica i blocchi alle forme sulle diapositive selezionate; le diapositive rimanenti rimarranno modificabili.

**I blocchi di forma si applicano a oggetti raggruppati e connettori?**

Sì. Sono supportati tipi di blocco dedicati per gruppi, connettori, oggetti grafici e altri tipi di forma.