---
title: Limita le modifiche alla presentazione con i blocchi di forma in Java
linktitle: Limita le modifiche alla presentazione
type: docs
weight: 60
url: /it/java/applying-protection-to-presentation/
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
- Java
- Aspose.Slides
description: "Scopri come bloccare e sbloccare le forme nelle presentazioni PPTX con Aspose.Slides per Java per limitare la selezione, lo spostamento, il ridimensionamento e il raggruppamento."
---
## **Contesto**

Un uso comune di Aspose.Slides per Java è creare, aggiornare e salvare presentazioni PowerPoint (PPTX) nell'ambito di un flusso di lavoro automatizzato. Quando gli utenti ricevono queste presentazioni, limitare le modifiche alle forme può aiutare a preservare il layout e il contenuto previsto.

Questo articolo spiega come le forme sono organizzate nelle diapositive e come applicare e rimuovere i blocchi delle forme in una presentazione PPTX. Questi blocchi consentono di limitare operazioni di modifica specifiche su singole forme.

## **Composizione di una diapositiva**

Una diapositiva di presentazione è composta da componenti come forme automatiche, tabelle, oggetti OLE, forme raggruppate, cornici immagine, cornici video, connettori e altri elementi utilizzati per creare una presentazione. In Aspose.Slides per Java, ogni elemento su una diapositiva è rappresentato da un oggetto che implementa l'interfaccia [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) o eredita da una classe che lo fa.

I diversi tipi di forma espongono diverse opzioni di blocco. L'interfaccia [IBaseShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/) è l'interfaccia di base per i blocchi delle forme. Aspose.Slides per Java fornisce le seguenti interfacce di blocco:

- [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/) blocca le forme automatiche.  
- [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) blocca le forme connettore.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/) blocca gli oggetti grafici.  
- [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/) blocca le forme di gruppo.  
- [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) blocca le cornici immagine.  

Per applicare i blocchi a una [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/), iterare le sue diapositive e impostare i blocchi appropriati su ogni forma supportata.

## **Applicare e rimuovere la protezione**

I blocchi delle forme limitano operazioni come selezionare, spostare e ridimensionare le forme. Non rendono l'intera presentazione non modificabile.

### **Applicare la protezione alle forme PPTX**

Aspose.Slides per Java fornisce l'interfaccia [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) per lavorare con le forme su una diapositiva.

L'esempio chiama [setSelectLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-), [setPositionLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-), e [setSizeLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) con `true` per le forme automatiche, con blocchi equivalenti per le forme di gruppo, i connettori e le cornici immagine. I connettori usano [setPositionMove](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) per lo spostamento; i gruppi usano anche [setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) per limitare il raggruppamento.

L'esempio carica una presentazione PPTX esistente, verifica le forme nella collezione di forme di ogni diapositiva e salva una copia con queste restrizioni applicate. Le forme al di fuori dei quattro tipi gestiti rimangono invariate. Il ciclo non attraversa le forme figlie all'interno di un gruppo.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();
                autoShapeLock.setPositionLocked(true);
                autoShapeLock.setSelectLocked(true);
                autoShapeLock.setSizeLocked(true);
            } else if (shape instanceof IGroupShape) {
                IGroupShape groupShape = (IGroupShape) shape;
                IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();
                groupShapeLock.setGroupingLocked(true);
                groupShapeLock.setPositionLocked(true);
                groupShapeLock.setSelectLocked(true);
                groupShapeLock.setSizeLocked(true);
            } else if (shape instanceof IConnector) {
                IConnector connectorShape = (IConnector) shape;
                IConnectorLock connectorShapeLock = connectorShape.getShapeLock();
                connectorShapeLock.setPositionMove(true);
                connectorShapeLock.setSelectLocked(true);
                connectorShapeLock.setSizeLocked(true);
            } else if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();
                pictureFrameLock.setPositionLocked(true);
                pictureFrameLock.setSelectLocked(true);
                pictureFrameLock.setSizeLocked(true);
            }
        }
    }

    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Rimuovere la protezione**

Per rimuovere un blocco di forma, impostare il suo valore a `false`. Il seguente esempio carica una presentazione con blocchi di forma e cancella le restrizioni di selezione, spostamento e ridimensionamento tramite [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/), e [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/). Rimuove inoltre la restrizione di raggruppamento passando `false` a [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) e salva una copia della presentazione. Le altre impostazioni di blocco rimangono invariate.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ProtectedSample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();
                autoShapeLock.setPositionLocked(false);
                autoShapeLock.setSelectLocked(false);
                autoShapeLock.setSizeLocked(false);
            } else if (shape instanceof IGroupShape) {
                IGroupShape groupShape = (IGroupShape) shape;
                IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();
                groupShapeLock.setGroupingLocked(false);
                groupShapeLock.setPositionLocked(false);
                groupShapeLock.setSelectLocked(false);
                groupShapeLock.setSizeLocked(false);
            } else if (shape instanceof IConnector) {
                IConnector connectorShape = (IConnector) shape;
                IConnectorLock connectorShapeLock = connectorShape.getShapeLock();
                connectorShapeLock.setPositionMove(false);
                connectorShapeLock.setSelectLocked(false);
                connectorShapeLock.setSizeLocked(false);
            } else if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();
                pictureFrameLock.setPositionLocked(false);
                pictureFrameLock.setSelectLocked(false);
                pictureFrameLock.setSizeLocked(false);
            }
        }
    }

    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Conclusione**

Aspose.Slides per Java consente di limitare operazioni di modifica specifiche su singole forme o di applicare le stesse restrizioni su più diapositive. Scegli i blocchi supportati da ciascun tipo di forma e imposta i loro valori a `false` quando è necessario rimuovere tali restrizioni.

## **FAQ**

**Posso combinare i blocchi delle forme e la protezione con password nella stessa presentazione?**

Sì. I blocchi delle forme limitano operazioni di modifica specifiche, mentre la [protezione con password](/slides/it/java/password-protected-presentation/) può limitare l'apertura o la modifica della presentazione. È possibile utilizzare entrambi nello stesso file.

**Posso limitare la modifica su diapositive specifiche senza influire sulle altre?**

Sì. Applica i blocchi solo alle forme delle diapositive selezionate. Questo non cambia le impostazioni di blocco delle altre diapositive.

**Come posso applicare i blocchi a forme individuali all'interno di un gruppo?**

Iterare la collezione restituita dal metodo [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) del gruppo e applicare i blocchi appropriati a ciascuna forma figlia. Ripetere l'operazione per eventuali gruppi nidificati. Gli esempi sopra elaborano solo la collezione di forme della diapositiva, quindi non impostano blocchi sui membri individuali del gruppo.