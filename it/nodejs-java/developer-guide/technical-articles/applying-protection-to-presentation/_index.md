---
title: Limita le modifiche alla presentazione con i blocchi di forma in Node.js
linktitle: Limita le modifiche alla presentazione
type: docs
weight: 60
url: /it/nodejs-java/applying-protection-to-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri come bloccare e sbloccare le forme nelle presentazioni PPTX con Aspose.Slides per Node.js via Java per limitare la selezione, lo spostamento, il ridimensionamento e il raggruppamento."
---
## **Panoramica**

Un uso comune di Aspose.Slides per Node.js via Java è creare, aggiornare e salvare presentazioni PowerPoint (PPTX) come parte di un flusso di lavoro automatizzato. Quando gli utenti ricevono queste presentazioni, limitare le modifiche alle forme può aiutare a preservare il layout e il contenuto previsti.

Questo articolo spiega come le forme sono organizzate nelle diapositive e come applicare e rimuovere i blocchi di forma in una presentazione PPTX. Questi blocchi consentono di limitare operazioni di modifica specifiche su singole forme.

## **Composizione di una diapositiva**

Una diapositiva di una presentazione è composta da componenti come forme automatiche, tabelle, oggetti OLE, forme raggruppate, riquadri immagine, riquadri video, connettori e altri elementi usati per costruire una presentazione. In Aspose.Slides per Node.js via Java, ogni elemento su una diapositiva è rappresentato da un oggetto che eredita dalla classe [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/).

Tipi di forma diversi espongono opzioni di blocco differenti. La classe [BaseShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/) è la classe base per i blocchi di forma. Aspose.Slides per Node.js via Java fornisce le seguenti classi di blocco:

- [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/) blocca le forme automatiche.  
- [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) blocca le forme di collegamento.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) blocca gli oggetti grafici.  
- [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/) blocca le forme di gruppo.  
- [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) blocca i riquadri immagine.  

Per applicare i blocchi su un'intera [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/), itera attraverso le sue diapositive e imposta i blocchi appropriati su ogni forma supportata.

## **Applica e rimuovi la protezione**

Gli editor di presentazioni compatibili usano i blocchi di forma per limitare operazioni di modifica individuali. La crittografia dei file e la protezione della scrittura a livello di documento sono impostazioni di [presentation protection settings](/slides/it/nodejs-java/password-protected-presentation/) separate.

### **Apply Protection to PPTX Shapes**

Aspose.Slides per Node.js via Java fornisce la classe [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) per lavorare con le forme su una diapositiva.

L'esempio chiama [setSelectLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setPositionLocked) e [setSizeLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSizeLocked) con `true` per le forme automatiche, con blocchi equivalenti per forme di gruppo, connettori e riquadri immagine. I connettori usano [setPositionMove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/#setPositionMove) per il movimento; i gruppi usano anche [setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) per limitare il raggruppamento.

L'esempio carica una presentazione PPTX esistente, controlla le forme nella collezione di forme di ogni diapositiva e salva una copia con queste restrizioni applicate. Le forme al di fuori dei quattro tipi gestiti rimangono inalterate. Il ciclo non attraversa le forme figlie all'interno di un gruppo.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const autoShapeLock = shape.getShapeLock();
                autoShapeLock.setPositionLocked(true);
                autoShapeLock.setSelectLocked(true);
                autoShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                const groupShapeLock = shape.getShapeLock();
                groupShapeLock.setGroupingLocked(true);
                groupShapeLock.setPositionLocked(true);
                groupShapeLock.setSelectLocked(true);
                groupShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IConnector")) {
                const connectorShapeLock = shape.getShapeLock();
                connectorShapeLock.setPositionMove(true);
                connectorShapeLock.setSelectLocked(true);
                connectorShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                const pictureFrameLock = shape.getShapeLock();
                pictureFrameLock.setPositionLocked(true);
                pictureFrameLock.setSelectLocked(true);
                pictureFrameLock.setSizeLocked(true);
            }
        }
    }

    presentation.save("ProtectedSample.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Rimuovere la protezione**

Per rimuovere un blocco di forma, imposta il suo valore su `false`. L'esempio seguente carica una presentazione con blocchi di forma e cancella le restrizioni di selezione, movimento e ridimensionamento tramite [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) e [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/). Rimuove inoltre la restrizione di raggruppamento passando `false` a [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) e salva una copia della presentazione. Altri blocchi rimangono invariati.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("ProtectedSample.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const autoShapeLock = shape.getShapeLock();
                autoShapeLock.setPositionLocked(false);
                autoShapeLock.setSelectLocked(false);
                autoShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                const groupShapeLock = shape.getShapeLock();
                groupShapeLock.setGroupingLocked(false);
                groupShapeLock.setPositionLocked(false);
                groupShapeLock.setSelectLocked(false);
                groupShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IConnector")) {
                const connectorShapeLock = shape.getShapeLock();
                connectorShapeLock.setPositionMove(false);
                connectorShapeLock.setSelectLocked(false);
                connectorShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                const pictureFrameLock = shape.getShapeLock();
                pictureFrameLock.setPositionLocked(false);
                pictureFrameLock.setSelectLocked(false);
                pictureFrameLock.setSizeLocked(false);
            }
        }
    }

    presentation.save("RemovedProtectionSample.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Preservare il ritaglio dell'immagine**

Posiziona una foto denominata `photo.jpg` nella directory di lavoro. L'esempio ritaglia il 12 % a sinistra e l'8 % a destra, poi chiama [setCropLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/#setCropLocked) sul blocco del riquadro immagine. Impostare `true` limita ulteriori ritagli e preserva il ritaglio esistente.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const photoStream = java.newInstanceSync("java.io.FileInputStream", "photo.jpg");
    let photo;
    try {
        photo = presentation.getImages().addImage(photoStream);
    } finally {
        photoStream.close();
    }

    const pictureFrame = shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 30, 270, 160, photo);
    pictureFrame.getPictureFormat().setCropLeft(12);
    pictureFrame.getPictureFormat().setCropRight(8);

    const pictureFrameLock = pictureFrame.getPictureFrameLock();
    pictureFrameLock.setAspectRatioLocked(false);
    pictureFrameLock.setCropLocked(true);

    presentation.save("PictureLocked.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`PictureLocked.pptx` memorizza il blocco del ritaglio come `true`. In PowerPoint, il comando **Crop** è disabilitato quando la foto è selezionata.

### **Mantenere un diagramma raggruppato**

L'esempio raggruppa un rettangolo e una freccia, poi chiama [setUngroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setUngroupingLocked) sul blocco del gruppo per mantenere insieme i componenti del diagramma. Altre modifiche, come lo spostamento del gruppo o la modifica del riempimento di un componente, rimangono disponibili.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    
    const groupShape = shapes.addGroupShape();
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 70, 90, 50);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.RightArrow, 190, 80, 60, 30);
    groupShape.getGroupShapeLock().setUngroupingLocked(true);

    presentation.save("DiagramLocked.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`DiagramLocked.pptx` memorizza il blocco di annullamento del raggruppamento come `true`. In PowerPoint, il comando **Ungroup** è disabilitato quando l'intero diagramma è selezionato.

### **Segnalare i blocchi di forma esistenti**

Per esaminare un modello, aprilo e leggi l'oggetto di blocco per ogni forma. Il metodo [getNoLocks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/#getNoLocks) restituisce `true` quando tutte le bandiere di quell'oggetto sono disattivate e `false` quando almeno una è attiva. Un gruppo e i suoi figli hanno oggetti di blocco separati, quindi ispeziona i figli anche quando il gruppo non ha blocchi.

Questo esempio verifica il movimento per forme automatiche, riquadri immagine e gruppi. Controlla inoltre il ritaglio per le immagini e l'annullamento del raggruppamento per i gruppi. Il rapporto elenca le bandiere abilitate che riconosce e segnala i tipi di forma che non ispeziona.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function inspectShapes(shapes, slideNumber, prefix) {
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const path = prefix + shape.getName();
        const type = shape.getClass().getSimpleName();
        const label = `Slide ${slideNumber} | ${path} | ${type}`;
        const flags = [];
        const isGroup = java.instanceOf(shape, "com.aspose.slides.IGroupShape");
        let shapeLock;

        if (isGroup) {
            shapeLock = shape.getGroupShapeLock();
            if (shapeLock.getUngroupingLocked()) flags.push("UngroupingLocked");
        } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            shapeLock = shape.getPictureFrameLock();
            if (shapeLock.getCropLocked()) flags.push("CropLocked");
        } else if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            shapeLock = shape.getAutoShapeLock();
        } else {
            console.log(`${label} | Uninspected`);
            continue;
        }

        if (!shapeLock.getNoLocks()) {
            if (shapeLock.getPositionLocked()) flags.push("PositionLocked");
            const restrictions = flags.length ? flags.join(", ") : "Active flag not identified";
            console.log(`${label} | ${restrictions}`);
        }

        if (isGroup) {
            inspectShapes(shape.getShapes(), slideNumber, path + "/");
        }
    }
}

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    const slides = presentation.getSlides();
    for (let i = 0; i < slides.size(); i++) {
        const slide = slides.get_Item(i);
        inspectShapes(slide.getShapes(), slide.getSlideNumber(), "");
    }
} finally {
    presentation.dispose();
}
```

Supponiamo che la diapositiva 1 di `Sample.pptx` contenga un gruppo chiamato `Layout` con l'annullamento del raggruppamento bloccato, una foto chiamata `Photo` all'interno con il ritaglio bloccato e un rettangolo sbloccato chiamato `Free`. Il rapporto salta `Free` e stampa queste due righe:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Il rapporto legge le bandiere di modifica a livello di forma memorizzate senza modificarle né salvare la presentazione. La protezione della scrittura a livello di documento è un'impostazione separata, e l'applicazione di ciascuna bandiera dipende dall'editor.

### **Conclusione**

Aspose.Slides per Node.js via Java ti consente di limitare operazioni di modifica specifiche su singole forme o di applicare le stesse restrizioni su più diapositive. Scegli i blocchi supportati da ciascun tipo di forma e imposta i loro valori su `false` quando è necessario rimuovere tali restrizioni.

## **FAQ**

**Posso combinare i blocchi di forma e la protezione con password nella stessa presentazione?**

Sì. I blocchi di forma limitano operazioni di modifica specifiche, mentre la [protezione con password](/slides/it/nodejs-java/password-protected-presentation/) può limitare l'apertura o la modifica della presentazione. È possibile utilizzare entrambi nello stesso file.

**Posso limitare la modifica su diapositive specifiche senza influenzare le altre?**

Sì. Applica i blocchi solo alle forme sulle diapositive selezionate. Questo non cambia le impostazioni di blocco sulle altre diapositive.

**Come posso applicare i blocchi a forme individuali all'interno di un gruppo?**

Itera attraverso la collezione restituita dal metodo [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) del gruppo e applica i blocchi appropriati a ciascuna forma figlia. Ripeti questo per eventuali gruppi nidificati, seguendo il percorso di attraversamento nell'esempio di segnalazione.