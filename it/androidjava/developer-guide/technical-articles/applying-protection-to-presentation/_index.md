---
title: Limitare le modifiche alla presentazione con blocchi di forma su Android
linktitle: Limitare le modifiche alla presentazione
type: docs
weight: 60
url: /it/androidjava/applying-protection-to-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Scopri come bloccare e sbloccare le forme nelle presentazioni PPTX con Aspose.Slides per Android via Java per limitare la selezione, lo spostamento, il ridimensionamento e il raggruppamento."
---
## **Panoramica**

Un uso comune di Aspose.Slides per Android via Java è creare, aggiornare e salvare presentazioni PowerPoint (PPTX) nell’ambito di un flusso di lavoro automatizzato. Quando gli utenti ricevono queste presentazioni, limitare le modifiche alle forme può aiutare a preservare il layout e il contenuto previsto.

Questo articolo spiega come le forme sono organizzate nelle diapositive e come applicare e rimuovere i blocchi di forma in una presentazione PPTX. Questi blocchi consentono di limitare operazioni di modifica specifiche su singole forme.

## **Composizione di una diapositiva**

Una diapositiva di una presentazione è composta da componenti come forme automatiche, tabelle, oggetti OLE, forme raggruppate, cornici immagine, cornici video, connettori e altri elementi utilizzati per costruire una presentazione. In Aspose.Slides per Android via Java, ogni elemento su una diapositiva è rappresentato da un oggetto che implementa l’interfaccia [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) o eredita da una classe che lo fa.

Diverse tipologie di forme espongono diverse opzioni di blocco. L’interfaccia [IBaseShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/) è l’interfaccia di base per i blocchi di forma. Aspose.Slides per Android via Java fornisce le seguenti interfacce di blocco:

- [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/) blocca le forme automatiche.  
- [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) blocca le forme connettore.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) blocca gli oggetti grafici.  
- [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/) blocca le forme di gruppo.  
- [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) blocca le cornici immagine.  

Per applicare i blocchi su un’intera [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/), iterare le sue diapositive e impostare i blocchi appropriati su ciascuna forma supportata.

## **Applicare e rimuovere la protezione**

I blocchi di forma limitano operazioni come la selezione, lo spostamento e il ridimensionamento delle forme. Non rendono l’intera presentazione non modificabile.

### **Applicare la protezione a forme PPTX**

Aspose.Slides per Android via Java fornisce l’interfaccia [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) per lavorare con le forme su una diapositiva.

La soluzione chiama [setSelectLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-), [setPositionLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-) e [setSizeLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) con `true` per le forme automatiche, con blocchi equivalenti per le forme di gruppo, i connettori e le cornici immagine. I connettori usano [setPositionMove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) per lo spostamento; i gruppi usano anche [setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) per limitare il raggruppamento.

L’esempio carica una presentazione PPTX esistente, controlla le forme nella collezione di forme di ogni diapositiva e salva una copia con queste restrizioni applicate. Le forme al di fuori dei quattro tipi gestiti rimangono inalterate. Il ciclo non attraversa le forme figlio all’interno di un gruppo.

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

Per rimuovere un blocco di forma, impostare il suo valore a `false`. Il seguente esempio carica una presentazione con blocchi di forma e cancella le restrizioni di selezione, spostamento e ridimensionamento tramite [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/), e [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/). Rimuove inoltre la restrizione di raggruppamento passando `false` a [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) e salva una copia della presentazione. Le altre impostazioni di blocco rimangono inalterate.

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

Aspose.Slides per Android via Java consente di limitare operazioni di modifica specifiche su singole forme o di applicare le stesse restrizioni su più diapositive. Scegli i blocchi supportati da ciascun tipo di forma e imposta i loro valori a `false` quando è necessario rimuovere tali restrizioni.

## **Domande frequenti**

**Posso combinare i blocchi di forma e la protezione con password nella stessa presentazione?**

Sì. I blocchi di forma limitano operazioni di modifica specifiche, mentre la [protezione con password](/slides/it/androidjava/password-protected-presentation/) può limitare l’apertura o la modifica della presentazione. È possibile utilizzare entrambi nello stesso file.

**Posso limitare la modifica su diapositive specifiche senza influenzare le altre?**

Sì. Applica i blocchi solo alle forme delle diapositive selezionate. Questo non modifica le impostazioni di blocco delle altre diapositive.

**Come posso applicare blocchi a forme individuali all’interno di un gruppo?**

Iterare la collezione restituita dal metodo [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) del gruppo e applicare i blocchi appropriati a ciascuna forma figlia. Ripetere l’operazione per eventuali gruppi annidati. Gli esempi sopra elaborano solo la collezione di forme della diapositiva, quindi non impostano blocchi sui singoli membri del gruppo.