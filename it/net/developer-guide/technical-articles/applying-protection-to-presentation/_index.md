---
title: Limita le modifiche alla presentazione con i blocchi di forma in .NET
linktitle: Limita le modifiche alla presentazione
type: docs
weight: 70
url: /it/net/applying-protection-to-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Scopri come bloccare e sbloccare le forme nelle presentazioni PPTX con Aspose.Slides per .NET per limitare selezione, spostamento, ridimensionamento e raggruppamento."
---
## **Contesto**

Un uso comune di Aspose.Slides per .NET è creare, aggiornare e salvare presentazioni PowerPoint (PPTX) come parte di un flusso di lavoro automatizzato. Quando gli utenti ricevono queste presentazioni, limitare le modifiche alle forme può aiutare a preservare il layout e il contenuto previsto.

Questo articolo spiega come le forme sono organizzate nelle diapositive e come applicare e rimuovere i blocchi delle forme in una presentazione PPTX. Questi blocchi consentono di limitare operazioni di modifica specifiche su singole forme.

## **Composizione di una diapositiva**

Una diapositiva di presentazione è composta da componenti come autoshape, tabelle, oggetti OLE, forme raggruppate, fotogrammi immagine, fotogrammi video, connettori e altri elementi usati per costruire una presentazione. In Aspose.Slides per .NET, ogni elemento su una diapositiva è rappresentato da un oggetto che implementa l'interfaccia [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) o eredita da una classe che lo fa.

Tipi di forma diversi espongono opzioni di blocco diverse. L'interfaccia [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) è l'interfaccia base per i blocchi delle forme. Aspose.Slides per .NET fornisce le seguenti interfacce di blocco:

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) blocca le autoshape.  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) blocca le forme connettore.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) blocca gli oggetti grafici.  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) blocca le forme raggruppate.  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) blocca i fotogrammi immagine.  

Per applicare i blocchi a una [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), itera attraverso le sue diapositive e imposta i blocchi appropriati su ogni forma supportata.

## **Applica e rimuovi la protezione**

I blocchi delle forme limitano operazioni come selezionare, spostare e ridimensionare le forme. Non rendono l'intera presentazione non modificabile.

### **Applica protezione alle forme PPTX**

Aspose.Slides per .NET fornisce l'interfaccia [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) per lavorare con le forme su una diapositiva.

L'esempio imposta [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/) , [PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/) e [SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) su `true` per le autoshape, con blocchi equivalenti per le forme raggruppate, i connettori e i fotogrammi immagine. I connettori usano [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) per lo spostamento; i gruppi usano anche [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) per limitare il raggruppamento.

L'esempio carica una presentazione PPTX esistente, controlla le forme nella collezione di forme di ogni diapositiva e salva una copia con queste restrizioni applicate. Le forme al di fuori dei quattro tipi gestiti rimangono inalterate. Il ciclo non attraversa le forme figlie all'interno di un gruppo.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
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

presentation.Save("ProtectedSample.pptx", SaveFormat.Pptx);
```

### **Rimuovi protezione**

Per rimuovere un blocco di forma, impostane il valore su `false`. Il seguente esempio carica una presentazione con blocchi di forma e cancella le restrizioni di selezione, spostamento e ridimensionamento tramite [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) , [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) , [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) e [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/). Cancella inoltre [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) e salva una copia della presentazione. Altre impostazioni di blocco rimangono inalterate.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ProtectedSample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
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

presentation.Save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
```

### **Conclusione**

Aspose.Slides per .NET consente di limitare operazioni di modifica specifiche su singole forme o di applicare le stesse restrizioni su più diapositive. Scegli i blocchi supportati da ciascun tipo di forma e imposta i loro valori su `false` quando è necessario rimuovere tali restrizioni.

## **FAQ**

**Posso combinare i blocchi di forma e la protezione con password nella stessa presentazione?**

Sì. I blocchi di forma limitano operazioni di modifica specifiche, mentre la [protezione con password](/slides/it/net/password-protected-presentation/) può limitare l'apertura o la modifica della presentazione. È possibile utilizzare entrambi nello stesso file.

**Posso limitare la modifica su diapositive specifiche senza influire su altre?**

Sì. Applica i blocchi solo alle forme delle diapositive selezionate. Questo non modifica le impostazioni di blocco sulle altre diapositive.

**Come posso applicare i blocchi a singole forme all'interno di un gruppo?**

Itera attraverso la collezione [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) del gruppo e applica i blocchi appropriati a ogni forma figlia. Ripeti l'operazione per eventuali gruppi nidificati. Gli esempi sopra elaborano solo la collezione di forme della diapositiva, quindi non impostano blocchi sui singoli membri del gruppo.