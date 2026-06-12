---
title: Impedire modifiche alla presentazione con blocchi forma in Python
linktitle: Impedire modifiche alla presentazione
type: docs
weight: 70
url: /it/python-net/applying-protection-to-presentation/
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
- Aspose.Slides
description: "Scopri come Aspose.Slides per Python via .NET blocca o sblocca le forme nei file PPT, PPTX e ODP, proteggendo le presentazioni consentendo modifiche controllate e una consegna più rapida."
---
## **Contesto**

Un uso comune di Aspose.Slides è creare, aggiornare e salvare presentazioni Microsoft PowerPoint (PPTX) come parte di un flusso di lavoro automatizzato. Gli utenti di applicazioni che impiegano Aspose.Slides in questo modo hanno accesso alle presentazioni generate, quindi proteggerle dalla modifica è una preoccupazione frequente. È importante che le presentazioni generate automaticamente mantengano la formattazione e il contenuto originali.

Questo articolo spiega come sono strutturate le presentazioni e le diapositive e come Aspose.Slides per Python possa applicare una protezione a una presentazione e rimuoverla in seguito. Fornisce agli sviluppatori un modo per controllare come le presentazioni generate dalle loro applicazioni vengano utilizzate.

## **Composizione di una diapositiva**

Una diapositiva di una presentazione è composta da componenti come autoshape, tabelle, oggetti OLE, forme raggruppate, cornici immagine, cornici video, connettori e altri elementi usati per costruire una presentazione. In Aspose.Slides per Python, ogni elemento su una diapositiva è rappresentato da un oggetto che eredita la classe [Shape](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/).

La struttura del PPTX è complessa, quindi a differenza del PPT, dove può essere usato un blocco generico per tutti i tipi di forme, i diversi tipi di forma richiedono blocchi differenti. La classe [BaseShapeLock](https://reference.aspose.com/slides/it/python-net/aspose.slides/baseshapelock/) è la classe di blocco generica per il PPTX. I seguenti tipi di blocchi sono supportati in Aspose.Slides per Python per il PPTX:

- [AutoShapeLock](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshapelock/) blocca le autoshape.  
- [ConnectorLock](https://reference.aspose.com/slides/it/python-net/aspose.slides/connectorlock/) blocca le forme connettore.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/it/python-net/aspose.slides/graphicalobjectlock/) blocca gli oggetti grafici.  
- [GroupShapeLock](https://reference.aspose.com/slides/it/python-net/aspose.slides/groupshapelock/) blocca le forme di gruppo.  
- [PictureFrameLock](https://reference.aspose.com/slides/it/python-net/aspose.slides/pictureframelock/) blocca le cornici immagine.  

Qualsiasi azione eseguita su tutti gli oggetti forma in un oggetto [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) viene applicata all’intera presentazione.

## **Applicare e rimuovere la protezione**

L’applicazione della protezione garantisce che una presentazione non possa essere modificata. È una tecnica utile per proteggere il contenuto della presentazione.

### **Applicare la protezione a forme PPTX**

Aspose.Slides per Python fornisce la classe [Shape](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/) per lavorare con le forme su una diapositiva.

Come accennato in precedenza, ogni classe di forma ha una classe di blocco associata per la protezione. Questo articolo si concentra sui blocchi NoSelect, NoMove e NoResize. Questi blocchi assicurano che le forme non possano essere selezionate (con clic del mouse o altri metodi di selezione) e che non possano essere spostate o ridimensionate.

Il campione di codice che segue applica la protezione a tutti i tipi di forma in una presentazione.

```py
import aspose.slides as slides

# Istanziare la classe Presentation che rappresenta un file PPTX.
with slides.Presentation("Sample.pptx") as presentation:
    # Scorrere tutte le diapositive nella presentazione.
    for slide in presentation.slides:
        # Scorrere tutte le forme nella diapositiva.
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.GroupShape:
                shape.shape_lock.grouping_locked = True
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.Connector:
                shape.shape_lock.position_move = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.PictureFrame:
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
    # Salvare il file della presentazione.
    presentation.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Rimuovere la protezione**

Per sbloccare una forma, impostare il valore del blocco applicato su `False`. Il campione di codice seguente mostra come sbloccare le forme in una presentazione bloccata.

```py
import aspose.slides as slides

# Istanziare la classe Presentation che rappresenta un file PPTX.
with slides.Presentation("ProtectedSample.pptx") as presentation:
    # Scorrere tutte le diapositive nella presentazione.
    for slide in presentation.slides:
        # Scorrere tutte le forme nella diapositiva.
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.GroupShape:
                shape.shape_lock.grouping_locked = False
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.Connector:
                shape.shape_lock.position_move = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.PictureFrame:
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
    # Salvare il file della presentazione.
    presentation.save("RemovedProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Conclusione**

Aspose.Slides offre diverse opzioni per proteggere le forme in una presentazione. È possibile bloccare una singola forma o iterare su tutte le forme in una presentazione e bloccarle una a una per proteggere efficacemente l’intero file. È possibile rimuovere la protezione impostando il valore del blocco su `False`.

## **FAQ**

**Posso combinare blocchi forma e protezione con password nella stessa presentazione?**

Sì. I blocchi limitano la modifica degli oggetti all’interno del file, mentre la [protezione con password](/slides/it/python-net/password-protected-presentation/) controlla l’accesso all’apertura e/o al salvataggio delle modifiche. questi meccanismi si completano a vicenda e funzionano insieme.

**Posso limitare la modifica su diapositive specifiche senza influire sulle altre?**

Sì. Applica i blocchi alle forme delle diapositive selezionate; le diapositive rimanenti rimarranno modificabili.

**I blocchi forma si applicano a oggetti raggruppati e connettori?**

Sì. Sono supportati tipi di blocco dedicati per gruppi, connettori, oggetti grafici e altri tipi di forma.