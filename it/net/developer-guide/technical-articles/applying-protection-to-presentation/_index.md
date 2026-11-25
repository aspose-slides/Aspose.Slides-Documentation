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
description: "Scopri come bloccare e sbloccare le forme nelle presentazioni PPTX con Aspose.Slides per .NET per limitare la selezione, lo spostamento, il ridimensionamento e il raggruppamento."
---
## **Contesto**

Un uso comune di Aspose.Slides per .NET è creare, aggiornare e salvare presentazioni PowerPoint (PPTX) come parte di un flusso di lavoro automatizzato. Quando gli utenti ricevono queste presentazioni, limitare le modifiche alle forme può aiutare a preservare il layout e il contenuto previsti.

Questo articolo spiega come le forme sono organizzate nelle diapositive e come applicare e rimuovere i blocchi delle forme in una presentazione PPTX. Questi blocchi ti consentono di limitare operazioni di modifica specifiche su singole forme.

## **Composizione di una diapositiva**

Una diapositiva di una presentazione è composta da componenti come autoshape, tabelle, oggetti OLE, forme raggruppate, cornici immagine, cornici video, connettori e altri elementi utilizzati per costruire una presentazione. In Aspose.Slides per .NET, ogni elemento su una diapositiva è rappresentato da un oggetto che implementa l'interfaccia [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) o eredita da una classe che lo fa.

I diversi tipi di forma espongono opzioni di blocco differenti. L'interfaccia [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) è l'interfaccia di base per i blocchi delle forme. Aspose.Slides per .NET fornisce le seguenti interfacce di blocco:

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) blocca le autoshape.  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) blocca le forme connettore.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) blocca gli oggetti grafici.  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) blocca le forme di gruppo.  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) blocca le cornici immagine.  

Per applicare i blocchi a un'intera [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), itera attraverso le sue diapositive e imposta i blocchi appropriati su ogni forma supportata.

## **Applicare e rimuovere la protezione**

Gli editor di presentazioni compatibili usano i blocchi delle forme per limitare operazioni di modifica individuali. La crittografia dei file e la protezione in scrittura a livello di documento sono impostazioni separate di [impostazioni di protezione della presentazione](/slides/it/net/password-protected-presentation/).

### **Applicare la protezione alle forme PPTX**

Aspose.Slides per .NET fornisce l'interfaccia [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) per lavorare con le forme su una diapositiva.

L'esempio imposta [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/) , [PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/) e [SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) su `true` per le autoshape, con blocchi equivalenti per le forme di gruppo, i connettori e le cornici immagine. I connettori usano [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) per lo spostamento; i gruppi usano anche [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) per limitare il raggruppamento.

L'esempio carica una presentazione PPTX esistente, verifica le forme nella collezione di forme di ogni diapositiva e salva una copia con queste restrizioni applicate. Le forme al di fuori dei quattro tipi gestiti rimangono inalterate. Il ciclo non attraversa le forme figlie all'interno di un gruppo.

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

### **Rimuovere la protezione**

Per rimuovere un blocco di forma, imposta il suo valore su `false`. Il seguente esempio carica una presentazione con blocchi di forma e cancella le restrizioni di selezione, spostamento e ridimensionamento tramite [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) , [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) , [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) e [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) . Cancella anche [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) e salva una copia della presentazione. Le altre impostazioni di blocco rimangono inalterate.

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

### **Preservare il ritaglio di un'immagine**

Posiziona una foto denominata `photo.jpg` nella directory di lavoro. L'esempio ritaglia il 12% a sinistra e l'8% a destra, quindi imposta [CropLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/croplocked/) sulla cornice immagine. Questa impostazione limita ulteriori ritagli e preserva il ritaglio esistente.

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var photoBytes = File.ReadAllBytes("photo.jpg");
var photo = presentation.Images.AddImage(photoBytes);

var pictureFrame = shapes.AddPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo);
pictureFrame.PictureFormat.CropLeft = 12;
pictureFrame.PictureFormat.CropRight = 8;
pictureFrame.PictureFrameLock.AspectRatioLocked = false;
pictureFrame.PictureFrameLock.CropLocked = true;

presentation.Save("PictureLocked.pptx", SaveFormat.Pptx);
```

`PictureLocked.pptx` memorizza il blocco del ritaglio come `true`. In PowerPoint, il comando **Crop** è disabilitato quando la foto è selezionata.

### **Mantenere un diagramma raggruppato**

L'esempio raggruppa un rettangolo e una freccia, quindi imposta [UngroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/ungroupinglocked/) sul gruppo stesso per mantenere i componenti del diagramma insieme. Altre modifiche, come spostare il gruppo o cambiare il riempimento di un componente, rimangono disponibili.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var groupShape = shapes.AddGroupShape();
groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 70, 90, 50);
groupShape.Shapes.AddAutoShape(ShapeType.RightArrow, 190, 80, 60, 30);
groupShape.GroupShapeLock.UngroupingLocked = true;

presentation.Save("DiagramLocked.pptx", SaveFormat.Pptx);
```

`DiagramLocked.pptx` memorizza il blocco di separazione come `true`. In PowerPoint, il comando **Ungroup** è disabilitato quando l'intero diagramma è selezionato.

### **Segnalare i blocchi di forma esistenti**

Per esaminare un modello, aprilo e leggi l'oggetto di blocco per ciascuna forma. [NoLocks](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/nolocks/) è `true` quando tutte le flag su quell'oggetto sono disabilitate e `false` quando almeno una è abilitata. Un gruppo e i suoi figli hanno oggetti di blocco separati, quindi ispeziona i figli anche quando il gruppo non ha blocchi.

Questo esempio controlla lo spostamento per le autoshape, le cornici immagine e i gruppi, il ritaglio per le immagini e la separazione per i gruppi. Segnala le flag riconosciute e contrassegna i tipi di forma che non ispeziona.

```cs
using System;
using System.Collections.Generic;
using Aspose.Slides;

using var presentation = new Presentation("Sample.pptx");
foreach (var slide in presentation.Slides)
{
    Inspect(slide.Shapes, slide.SlideNumber, "");
}

static void Inspect(IShapeCollection shapes, int slideNumber, string prefix)
{
    foreach (var shape in shapes)
    {
        var path = prefix + shape.Name;
        var label = $"Slide {slideNumber} | {path} | {shape.GetType().Name}";
        var flags = new List<string>();
        IBaseShapeLock shapeLock;

        switch (shape)
        {
            case IGroupShape group:
                shapeLock = group.ShapeLock;
                if (group.ShapeLock.UngroupingLocked) flags.Add("UngroupingLocked");
                if (group.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            case IPictureFrame picture:
                shapeLock = picture.ShapeLock;
                if (picture.ShapeLock.CropLocked) flags.Add("CropLocked");
                if (picture.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            case IAutoShape autoShape:
                shapeLock = autoShape.ShapeLock;
                if (autoShape.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            default:
                Console.WriteLine($"{label} | Uninspected");
                continue;
        }

        if (!shapeLock.NoLocks)
        {
            var restrictions = flags.Count > 0 ? string.Join(", ", flags) : "Active flag not identified";
            Console.WriteLine($"{label} | {restrictions}");
        }

        if (shape is IGroupShape parent)
            Inspect(parent.Shapes, slideNumber, path + "/");
    }
}
```

Supponiamo che la diapositiva 1 di `Sample.pptx` contenga un gruppo chiamato `Layout` con la separazione bloccata, un'immagine chiamata `Photo` al suo interno con il ritaglio bloccato, e un rettangolo sbloccato chiamato `Free`. Il report salta `Free` e stampa queste due righe:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Il report legge le flag di modifica a livello di forma memorizzate senza modificarle o salvare la presentazione. La protezione in scrittura a livello di documento è un'impostazione separata, e l'applicazione di ciascuna flag dipende dall'editor.

### **Conclusione**

Aspose.Slides per .NET ti consente di limitare operazioni di modifica specifiche su forme individuali o di applicare le stesse restrizioni su più diapositive. Scegli i blocchi supportati da ciascun tipo di forma e imposta i loro valori su `false` quando devi rimuovere tali restrizioni.

## **FAQ**

**Posso combinare i blocchi delle forme e la protezione tramite password nella stessa presentazione?**

Sì. I blocchi delle forme limitano operazioni di modifica specifiche, mentre la [protezione con password](/slides/it/net/password-protected-presentation/) può limitare l'apertura o la modifica della presentazione. È possibile usare entrambi nello stesso file.

**Posso limitare la modifica su diapositive specifiche senza influenzare le altre?**

Sì. Applica i blocchi solo alle forme sulle diapositive selezionate. Questo non modifica le impostazioni di blocco sulle altre diapositive.

**Come posso applicare i blocchi a forme individuali all'interno di un gruppo?**

Itera attraverso la collezione di [Forme](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) del gruppo e applica i blocchi appropriati a ogni forma figlia. Ripeti l'operazione per eventuali gruppi annidati, seguendo il percorso nell'esempio di segnalazione.