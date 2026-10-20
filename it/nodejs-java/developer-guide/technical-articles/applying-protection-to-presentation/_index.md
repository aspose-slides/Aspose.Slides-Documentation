---
title: Limita le modifiche alla presentazione con blocchi di forma in Node.js
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

Un uso comune di Aspose.Slides per Node.js via Java è creare, aggiornare e salvare presentazioni PowerPoint (PPTX) come parte di un flusso di lavoro automatizzato. Quando gli utenti ricevono queste presentazioni, limitare le modifiche alle forme può aiutare a preservare il layout e il contenuto desiderati.

Questo articolo spiega come le forme sono organizzate nelle diapositive e come applicare e rimuovere i blocchi delle forme in una presentazione PPTX. Questi blocchi consentono di limitare operazioni di modifica specifiche su forme individuali.

## **Composizione di una diapositiva**

Una diapositiva di una presentazione è composta da componenti come autoshape, tabelle, oggetti OLE, forme raggruppate, riquadri immagine, riquadri video, connettori e altri elementi utilizzati per creare una presentazione. In Aspose.Slides per Node.js via Java, ogni elemento su una diapositiva è rappresentato da un oggetto che eredita dalla classe [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) .

Diversi tipi di forma espongono diverse opzioni di blocco. La classe [BaseShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/) è la classe base per i blocchi delle forme. Aspose.Slides per Node.js via Java fornisce le seguenti classi di blocco:

- [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/) blocca le autoshape.  
- [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) blocca le forme connettore.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) blocca gli oggetti grafici.  
- [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/) blocca le forme raggruppate.  
- [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) blocca i riquadri immagine.  

Per applicare i blocchi a una [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) , iterare attraverso le sue diapositive e impostare i blocchi appropriati su ogni forma supportata.

## **Applica e rimuovi protezione**

I blocchi delle forme limitano operazioni come la selezione, lo spostamento e il ridimensionamento delle forme. Non rendono l'intera presentazione non modificabile.

### **Applica protezione alle forme PPTX**

Aspose.Slides per Node.js via Java fornisce la classe [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) per lavorare con le forme su una diapositiva.

L'esempio chiama [setSelectLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setPositionLocked) e [setSizeLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSizeLocked) con `true` per le autoshape, con blocchi equivalenti per le forme raggruppate, i connettori e i riquadri immagine. I connettori usano [setPositionMove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/#setPositionMove) per il movimento; i gruppi usano anche [setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) per limitare il raggruppamento.

L'esempio carica una presentazione PPTX esistente, controlla le forme nella collezione di forme di ogni diapositiva e salva una copia con queste restrizioni applicate. Le forme al di fuori dei quattro tipi gestiti rimangono inalterate. Il ciclo non attraversa le forme figlio all'interno di un gruppo.

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

### **Rimuovi protezione**

Per rimuovere un blocco di forma, impostare il suo valore a `false`. Il seguente esempio carica una presentazione con blocchi di forma e cancella le restrizioni di selezione, movimento e ridimensionamento tramite [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) e [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/). Rimuove inoltre la restrizione di raggruppamento passando `false` a [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) e salva una copia della presentazione. Le altre impostazioni di blocco rimangono inalterate.

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

### **Conclusione**

Aspose.Slides per Node.js via Java consente di limitare operazioni di modifica specifiche su forme individuali o applicare le stesse restrizioni su più diapositive. Scegli i blocchi supportati da ciascun tipo di forma e imposta i loro valori a `false` quando è necessario rimuovere tali restrizioni.

## **FAQ**

**Posso combinare i blocchi di forma e la protezione con password nella stessa presentazione?**

Sì. I blocchi di forma limitano operazioni di modifica specifiche, mentre la [protezione con password](/slides/it/nodejs-java/password-protected-presentation/) può limitare l'apertura o la modifica della presentazione. È possibile utilizzare entrambi nello stesso file.

**Posso limitare la modifica su diapositive specifiche senza influenzare le altre?**

Sì. Applica i blocchi solo alle forme nelle diapositive selezionate. Questo non modifica le impostazioni di blocco delle altre diapositive.

**Come posso applicare blocchi a forme individuali all'interno di un gruppo?**

Itera attraverso la collezione restituita dal metodo [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) del gruppo e applica i blocchi appropriati a ciascuna forma figlia. Ripeti l'operazione per eventuali gruppi nidificati. Gli esempi sopra elaborano solo la collezione di forme della diapositiva, quindi non impostano blocchi sui singoli membri del gruppo.