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

Un uso comune di Aspose.Slides per Python tramite .NET è creare, aggiornare e salvare presentazioni PowerPoint (PPTX) all'interno di un flusso di lavoro automatizzato. Quando gli utenti ricevono queste presentazioni, limitare le modifiche alle forme può aiutare a preservare il layout e il contenuto desiderati.

Questo articolo spiega come le forme sono organizzate nelle diapositive e come applicare e rimuovere i blocchi di forma in una presentazione PPTX. Questi blocchi consentono di restringere operazioni di modifica specifiche su singole forme.

## **Composizione di una diapositiva**

Una diapositiva di una presentazione è composta da componenti come autoshape, tabelle, oggetti OLE, forme raggruppate, cornici immagine, cornici video, connettori e altri elementi utilizzati per costruire una presentazione. In Aspose.Slides per Python tramite .NET, ogni elemento su una diapositiva è rappresentato da un oggetto che eredita dalla classe [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/).

Tipi di forma diversi espongono opzioni di blocco diverse. La classe [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) è la classe base per i blocchi di forma. Aspose.Slides per Python tramite .NET fornisce le seguenti classi di blocco:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) blocca le autoshape.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) blocca le forme connettore.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) blocca gli oggetti grafici.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) blocca le forme raggruppate.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) blocca le cornici immagine.  

Per applicare i blocchi a una [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), iterare attraverso le sue diapositive e impostare i blocchi appropriati su ciascuna forma supportata.

## **Applicare e rimuovere la protezione**

I blocchi di forma limitano operazioni come la selezione, lo spostamento e il ridimensionamento delle forme. Non rendono l'intera presentazione non modificabile.

### **Applicare la protezione alle forme PPTX**

Aspose.Slides per Python tramite .NET fornisce la classe [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) per lavorare con le forme su una diapositiva.

L'esempio imposta [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/), [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/) e [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) su `True` per le autoshape, con blocchi equivalenti per le forme raggruppate, i connettori e le cornici immagine. I connettori usano [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) per lo spostamento; i gruppi usano anche [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) per limitare il raggruppamento.

L'esempio carica una presentazione PPTX esistente, controlla le forme nella collezione di forme di ciascuna diapositiva e salva una copia con queste restrizioni applicate. Le forme al di fuori dei quattro tipi gestiti rimangono invariate. Il ciclo non attraversa le forme figlio all'interno di un gruppo.

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

Per rimuovere un blocco di forma, impostarne il valore su `False`. L'esempio seguente carica una presentazione con blocchi di forma e cancella le restrizioni di selezione, spostamento e ridimensionamento tramite [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) e [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/). Cancella inoltre [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) e salva una copia della presentazione. Altre impostazioni di blocco rimangono invariate.

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

### **Conclusione**

Aspose.Slides per Python tramite .NET consente di limitare operazioni di modifica specifiche su forme individuali o di applicare le stesse restrizioni su più diapositive. Scegli i blocchi supportati da ciascun tipo di forma e impostane i valori su `False` quando è necessario rimuovere tali restrizioni.

## **FAQ**

**Posso combinare i blocchi di forma e la protezione con password nella stessa presentazione?**

Sì. I blocchi di forma limitano operazioni di modifica specifiche, mentre la [password protection](/slides/it/python-net/password-protected-presentation/) può limitare l'apertura o la modifica della presentazione. È possibile utilizzare entrambi nello stesso file.

**Posso limitare la modifica su diapositive specifiche senza influenzare le altre?**

Sì. Applica i blocchi solo alle forme delle diapositive selezionate. Questo non modifica le impostazioni di blocco delle altre diapositive.

**Come posso applicare i blocchi a forme individuali all'interno di un gruppo?**

Itera attraverso la collezione di [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) del gruppo e applica i blocchi appropriati a ciascuna forma figlia. Ripeti l'operazione per eventuali gruppi nidificati. Gli esempi sopra elaborano solo la collezione di forme della diapositiva, quindi non impostano blocchi sui membri individuali del gruppo.