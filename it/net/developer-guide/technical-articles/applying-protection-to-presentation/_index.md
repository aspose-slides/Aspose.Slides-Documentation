---
title: Impedisci modifiche alla presentazione con i blocchi forma in .NET
linktitle: Impedisci modifiche alla presentazione
type: docs
weight: 70
url: /it/net/applying-protection-to-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Scopri come Aspose.Slides per .NET blocca o sblocca le forme in file PPT, PPTX e ODP, proteggendo le presentazioni consentendo modifiche controllate."
---
## **Contesto**

Un uso comune di Aspose.Slides è creare, aggiornare e salvare presentazioni Microsoft PowerPoint (PPTX) come parte di un flusso di lavoro automatizzato. Gli utenti delle applicazioni che utilizzano Aspose.Slides in questo modo hanno accesso alle presentazioni generate, quindi proteggerle dalla modifica è una preoccupazione comune. È importante che le presentazioni generate automaticamente mantengano la formattazione e il contenuto originali.

Questo articolo spiega come sono strutturate le presentazioni e le diapositive e come Aspose.Slides per .NET possa applicare la protezione a una presentazione e successivamente rimuoverla. Fornisce agli sviluppatori un modo per controllare l'uso delle presentazioni generate dalle loro applicazioni.

## **Composizione di una diapositiva**

Una diapositiva di presentazione è composta da componenti come forme automatiche, tabelle, oggetti OLE, forme raggruppate, cornici immagine, cornici video, connettori e altri elementi utilizzati per costruire una presentazione. In Aspose.Slides per .NET, ogni elemento su una diapositiva è rappresentato da un oggetto che implementa l'interfaccia [IShape](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/) o eredita da una classe che lo fa.

La struttura di PPTX è complessa, quindi a differenza di PPT, dove è possibile usare un blocco generico per tutti i tipi di forme, diversi tipi di forme richiedono blocchi differenti. L'interfaccia [IBaseShapeLock](https://reference.aspose.com/slides/it/net/aspose.slides/ibaseshapelock/) è la classe di blocco generica per PPTX. I seguenti tipi di blocchi sono supportati in Aspose.Slides per .NET per PPTX:

- [IAutoShapeLock](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshapelock/) blocca le forme automatiche.  
- [IConnectorLock](https://reference.aspose.com/slides/it/net/aspose.slides/iconnectorlock/) blocca le forme connettore.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/it/net/aspose.slides/igraphicalobjectlock/) blocca gli oggetti grafici.  
- [IGroupShapeLock](https://reference.aspose.com/slides/it/net/aspose.slides/igroupshapelock/) blocca le forme di gruppo.  
- [IPictureFrameLock](https://reference.aspose.com/slides/it/net/aspose.slides/ipictureframelock/) blocca le cornici immagine.  

Qualsiasi azione eseguita su tutti gli oggetti forma in un oggetto [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) viene applicata all'intera presentazione.

## **Applica e rimuovi la protezione**

Applicare la protezione garantisce che una presentazione non possa essere modificata. È una tecnica utile per proteggere il contenuto della presentazione.

### **Applica protezione alle forme PPTX**

Aspose.Slides per .NET fornisce l'interfaccia [IShape](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/) per lavorare con le forme su una diapositiva.

Come accennato in precedenza, ogni classe di forma ha una classe di blocco forma associata per la protezione. Questo articolo si concentra sui blocchi NoSelect, NoMove e NoResize. Questi blocchi garantiscono che le forme non possano essere selezionate (tramite clic del mouse o altri metodi di selezione) e che non possano essere spostate o ridimensionate.

Il campione di codice che segue applica la protezione a tutti i tipi di forma in una presentazione.

```cs
// Instanzia la classe Presentation che rappresenta un file PPTX.
using Presentation presentation = new Presentation("Sample.pptx");

// Scorrendo tutte le diapositive nella presentazione.
foreach (ISlide slide in presentation.Slides)
{
    // Scorrendo tutte le forme nella diapositiva.
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = true;
            autoShape.ShapeLock.SelectLocked = true;
            autoShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = true;
            groupShape.ShapeLock.PositionLocked = true;
            groupShape.ShapeLock.SelectLocked = true;
            groupShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = true;
            connectorShape.ShapeLock.SelectLocked = true;
            connectorShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = true;
            pictureFrame.ShapeLock.SelectLocked = true;
            pictureFrame.ShapeLock.SizeLocked = true;
        }
    }
}

// Salvataggio del file di presentazione.
presentation.Save("ProtectedSample.pptx", SaveFormat.Pptx);
```

### **Rimuovi protezione**

Per sbloccare una forma, impostare il valore del blocco applicato a `false`. Il seguente esempio di codice mostra come sbloccare le forme in una presentazione bloccata.

```cs
// Instanzia la classe Presentation che rappresenta un file PPTX.
using Presentation presentation = new Presentation("ProtectedSample.pptx");

// Scorrendo tutte le diapositive nella presentazione.
foreach (ISlide slide in presentation.Slides)
{
    // Scorrendo tutte le forme nella diapositiva.
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = false;
            autoShape.ShapeLock.SelectLocked = false;
            autoShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = false;
            groupShape.ShapeLock.PositionLocked = false;
            groupShape.ShapeLock.SelectLocked = false;
            groupShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = false;
            connectorShape.ShapeLock.SelectLocked = false;
            connectorShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = false;
            pictureFrame.ShapeLock.SelectLocked = false;
            pictureFrame.ShapeLock.SizeLocked = false;
        }
    }
}

// Salvataggio del file di presentazione.
presentation.Save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
```

### **Conclusione**

Aspose.Slides offre diverse opzioni per proteggere le forme in una presentazione. È possibile bloccare una singola forma o iterare attraverso tutte le forme di una presentazione e bloccare ciascuna per proteggere efficacemente l'intero file. È possibile rimuovere la protezione impostando il valore del blocco a `false`.

## **FAQ**

**Posso combinare i blocchi di forma e la protezione con password nella stessa presentazione?**

Sì. I blocchi limitano la modifica degli oggetti all'interno del file, mentre la [protezione con password](/slides/it/net/password-protected-presentation/) controlla l'accesso all'apertura e/o al salvataggio delle modifiche. questi meccanismi si completano a vicenda e funzionano insieme.

**Posso limitare la modifica su diapositive specifiche senza influenzare le altre?**

Sì. Applica i blocchi alle forme sulle diapositive selezionate; le diapositive rimanenti rimarranno modificabili.

**I blocchi di forma si applicano a oggetti raggruppati e connettori?**

Sì. Sono supportati tipi di blocco dedicati per gruppi, connettori, oggetti grafici e altri tipi di forma.