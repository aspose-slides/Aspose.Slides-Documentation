---
title: Impedire modifiche alla presentazione con blocchi di forma
linktitle: Impedire modifiche alla presentazione
type: docs
weight: 60
url: /it/java/applying-protection-to-presentation/
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
- Java
- Aspose.Slides
description: "Scopri come Aspose.Slides per Java blocca o sblocca le forme nei file PPT, PPTX e ODP, proteggendo le presentazioni consentendo modifiche controllate e una consegna più rapida."
---
## **Contesto**

Un uso comune di Aspose.Slides è creare, aggiornare e salvare presentazioni Microsoft PowerPoint (PPTX) come parte di un flusso di lavoro automatizzato. Gli utenti delle applicazioni che utilizzano Aspose.Slides in questo modo hanno accesso alle presentazioni generate, quindi proteggerle dalla modifica è una preoccupazione comune. È importante che le presentazioni generate automaticamente mantengano la formattazione e il contenuto originali.

Questo articolo spiega come sono strutturate le presentazioni e le diapositive e come Aspose.Slides per Java possa applicare la protezione a una presentazione e rimuoverla successivamente. Fornisce agli sviluppatori un modo per controllare come le presentazioni generate dalle loro applicazioni vengano utilizzate.

## **Composizione di una diapositiva**

Una diapositiva di una presentazione è composta da componenti quali autoshape, tabelle, oggetti OLE, forme raggruppate, cornici immagine, cornici video, connettori e altri elementi utilizzati per creare una presentazione. In Aspose.Slides per Java, ogni elemento su una diapositiva è rappresentato da un oggetto che implementa l'interfaccia [IShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/) o eredita da una classe che lo fa.

La struttura di PPTX è complessa, quindi a differenza di PPT, dove è possibile utilizzare un blocco generico per tutti i tipi di forme, tipi diversi di forme richiedono blocchi diversi. L'interfaccia [IBaseShapeLock](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibaseshapelock/) è la classe di blocco generica per PPTX. I seguenti tipi di blocchi sono supportati in Aspose.Slides per Java per PPTX:

- [IAutoShapeLock](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshapelock/) blocca le autoshape.  
- [IConnectorLock](https://reference.aspose.com/slides/it/java/com.aspose.slides/iconnectorlock/) blocca le forme connettore.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/it/java/com.aspose.slides/igraphicalobjectlock/) blocca gli oggetti grafici.  
- [IGroupShapeLock](https://reference.aspose.com/slides/it/java/com.aspose.slides/igroupshapelock/) blocca le forme di gruppo.  
- [IPictureFrameLock](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipictureframelock/) blocca le cornici immagine.  

Qualsiasi azione eseguita su tutti gli oggetti forma in un oggetto [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/) viene applicata all'intera presentazione.

## **Applicare e rimuovere la protezione**

L'applicazione della protezione assicura che una presentazione non possa essere modificata. È una tecnica utile per proteggere il contenuto della presentazione.

### **Applicare la protezione alle forme PPTX**

Aspose.Slides per Java fornisce l'interfaccia [IShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/) per lavorare con le forme su una diapositiva.

Come accennato in precedenza, ogni classe di forma ha una classe di blocco forma associata per la protezione. Questo articolo si concentra sui blocchi NoSelect, NoMove e NoResize. Questi blocchi garantiscono che le forme non possano essere selezionate (tramite clic del mouse o altri metodi di selezione) e che non possano essere spostate o ridimensionate.

Il campione di codice che segue applica la protezione a tutti i tipi di forma in una presentazione.

```java
// Istanziare la classe Presentation che rappresenta un file PPTX.
Presentation presentation = new Presentation("Sample.pptx");

// Scorrere tutte le diapositive nella presentazione.
for (ISlide slide : presentation.getSlides()) {

    // Scorrere tutte le forme nella diapositiva.
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAutoShape) {
            // Conversione del tipo della forma a un autoshape e ottenimento del relativo blocco forma.
            IAutoShape autoShape = (IAutoShape) shape;
            IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();

            autoShapeLock.setPositionLocked(true);
            autoShapeLock.setSelectLocked(true);
            autoShapeLock.setSizeLocked(true);
        } else if (shape instanceof IGroupShape) {
            // Conversione del tipo della forma a una forma di gruppo e ottenimento del relativo blocco forma.
            IGroupShape groupShape = (IGroupShape) shape;
            IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();

            groupShapeLock.setGroupingLocked(true);
            groupShapeLock.setPositionLocked(true);
            groupShapeLock.setSelectLocked(true);
            groupShapeLock.setSizeLocked(true);
        } else if (shape instanceof IConnector) {
            // Conversione del tipo della forma a una forma connettore e ottenimento del relativo blocco forma.
            IConnector connectorShape = (IConnector) shape;
            IConnectorLock connectorShapeLock = connectorShape.getShapeLock();

            connectorShapeLock.setPositionMove(true);
            connectorShapeLock.setSelectLocked(true);
            connectorShapeLock.setSizeLocked(true);
        } else if (shape instanceof IPictureFrame) {
            // Conversione del tipo della forma a una cornice immagine e ottenimento del relativo blocco forma.
            IPictureFrame pictureFrame = (IPictureFrame) shape;
            IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();

            pictureFrameLock.setPositionLocked(true);
            pictureFrameLock.setSelectLocked(true);
            pictureFrameLock.setSizeLocked(true);
        }
    }
}

// Salvataggio del file di presentazione.
presentation.save("ProtectedSample.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Rimuovere la protezione**

Per sbloccare una forma, impostare il valore del blocco applicato su `false`. Il campione di codice seguente mostra come sbloccare le forme in una presentazione bloccata.

```java
// Istanziare la classe Presentation che rappresenta un file PPTX.
Presentation presentation = new Presentation("ProtectedSample.pptx");

// Scorrere tutte le diapositive nella presentazione.
for (ISlide slide : presentation.getSlides()) {

    // Scorrere tutte le forme nella diapositiva.
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAutoShape) {
            // Conversione del tipo della forma a un autoshape e ottenimento del relativo blocco forma.
            IAutoShape autoShape = (IAutoShape) shape;
            IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();

            autoShapeLock.setPositionLocked(false);
            autoShapeLock.setSelectLocked(false);
            autoShapeLock.setSizeLocked(false);
        } else if (shape instanceof IGroupShape) {
            // Conversione del tipo della forma a una forma di gruppo e ottenimento del relativo blocco forma.
            IGroupShape groupShape = (IGroupShape) shape;
            IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();

            groupShapeLock.setGroupingLocked(false);
            groupShapeLock.setPositionLocked(false);
            groupShapeLock.setSelectLocked(false);
            groupShapeLock.setSizeLocked(false);
        } else if (shape instanceof IConnector) {
            // Conversione del tipo della forma a una forma connettore e ottenimento del relativo blocco forma.
            IConnector connectorShape = (IConnector) shape;
            IConnectorLock connectorShapeLock = connectorShape.getShapeLock();

            connectorShapeLock.setPositionMove(false);
            connectorShapeLock.setSelectLocked(false);
            connectorShapeLock.setSizeLocked(false);
        } else if (shape instanceof IPictureFrame) {
            // Conversione del tipo della forma a una cornice immagine e ottenimento del relativo blocco forma.
            IPictureFrame pictureFrame = (IPictureFrame) shape;
            IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();

            pictureFrameLock.setPositionLocked(false);
            pictureFrameLock.setSelectLocked(false);
            pictureFrameLock.setSizeLocked(false);
        }
    }
}

// Salvataggio del file di presentazione.
presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Conclusione**

Aspose.Slides offre diverse opzioni per proteggere le forme in una presentazione. È possibile bloccare una singola forma o scorrere tutte le forme in una presentazione e bloccarle una per una per proteggere efficacemente l'intero file. È possibile rimuovere la protezione impostando il valore del blocco su `false`.

## **FAQ**

**Posso combinare i blocchi di forma e la protezione con password nella stessa presentazione?**

Sì. I blocchi limitano la modifica degli oggetti all'interno del file, mentre la [protezione con password](/slides/it/java/password-protected-presentation/) controlla l'accesso all'apertura e/o al salvataggio delle modifiche. questi meccanismi si completano a vicenda e funzionano insieme.

**Posso limitare la modifica di diapositive specifiche senza influenzare le altre?**

Sì. Applica i blocchi alle forme delle diapositive selezionate; le diapositive rimanenti rimarranno modificabili.

**I blocchi di forma si applicano a oggetti raggruppati e connettori?**

Sì. Sono supportati tipi di blocco dedicati per gruppi, connettori, oggetti grafici e altri tipi di forma.