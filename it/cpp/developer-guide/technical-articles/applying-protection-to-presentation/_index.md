---
title: Impedisci modifiche alla presentazione con blocchi di forma
linktitle: Impedisci modifiche alla presentazione
type: docs
weight: 10
url: /it/cpp/applying-protection-to-presentation/
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
- C++
- Aspose.Slides
description: "Scopri come Aspose.Slides per C++ blocca o sblocca le forme nei file PPT, PPTX e ODP, proteggendo le presentazioni consentendo modifiche controllate e una consegna più rapida."
---
## **Contesto**

Un uso comune di Aspose.Slides è creare, aggiornare e salvare presentazioni Microsoft PowerPoint (PPTX) come parte di un flusso di lavoro automatizzato. Gli utenti di applicazioni che impiegano Aspose.Slides in questo modo hanno accesso alle presentazioni generate, quindi proteggerle dalla modifica è una preoccupazione comune. È importante che le presentazioni generate automaticamente mantengano la formattazione e il contenuto originali.

Questo articolo spiega come sono strutturate le presentazioni e le diapositive e come Aspose.Slides per C++ può applicare una protezione a una presentazione e successivamente rimuoverla. Fornisce agli sviluppatori un modo per controllare come le presentazioni generate dalle loro applicazioni vengono utilizzate.

## **Composizione di una diapositiva**

Una diapositiva di una presentazione è composta da componenti come forme automatiche, tabelle, oggetti OLE, forme raggruppate, cornici immagine, cornici video, connettori e altri elementi utilizzati per costruire una presentazione. In Aspose.Slides per C++, ogni elemento su una diapositiva è rappresentato da un oggetto che implementa l'interfaccia [IShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/) o eredita da una classe che lo fa.

La struttura di PPTX è complessa, quindi a differenza di PPT, dove è possibile utilizzare un blocco generico per tutti i tipi di forme, i diversi tipi di forma richiedono blocchi diversi. L'interfaccia [IBaseShapeLock](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibaseshapelock/) è la classe di blocco generica per PPTX. Sono supportati i seguenti tipi di blocchi in Aspose.Slides per C++ per PPTX:

- [IAutoShapeLock](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshapelock/) blocca le forme automatiche.  
- [IConnectorLock](https://reference.aspose.com/slides/it/cpp/aspose.slides/iconnectorlock/) blocca le forme connettore.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/it/cpp/aspose.slides/igraphicalobjectlock/) blocca gli oggetti grafici.  
- [IGroupShapeLock](https://reference.aspose.com/slides/it/cpp/aspose.slides/igroupshapelock/) blocca le forme raggruppate.  
- [IPictureFrameLock](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipictureframelock/) blocca le cornici immagine.   

Qualsiasi azione eseguita su tutti gli oggetti forma in un oggetto [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) viene applicata all'intera presentazione.

## **Applicare e rimuovere la protezione**

Applicare una protezione garantisce che una presentazione non possa essere modificata. È una tecnica utile per proteggere il contenuto della presentazione.

### **Applicare protezione alle forme PPTX**

Aspose.Slides per C++ fornisce l'interfaccia [IShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/) per lavorare con le forme su una diapositiva.

Come accennato in precedenza, ogni classe di forma dispone di una classe di blocco associata per la protezione. Questo articolo si concentra sui blocchi NoSelect, NoMove e NoResize. Questi blocchi garantiscono che le forme non possano essere selezionate (tramite clic del mouse o altri metodi di selezione) e che non possano essere spostate o ridimensionate.

Il campione di codice che segue applica la protezione a tutti i tipi di forma in una presentazione.

```cpp
// Istanzia la classe Presentation che rappresenta un file PPTX.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Scorrendo tutte le diapositive nella presentazione.
for (auto&& slide : presentation->get_Slides())	{

	// Scorrendo tutte le forme nella diapositiva.
	for (auto&& shape : slide->get_Shapes()) {

		if (ObjectExt::Is<IAutoShape>(shape)) {
			// Effettua il cast della forma a autoshape e ottiene il blocco della forma.
			auto autoShape = ExplicitCast<IAutoShape>(shape);
			auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

			autoShapeLock->set_PositionLocked(true);
			autoShapeLock->set_SelectLocked(true);
			autoShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IGroupShape>(shape)) {
			// Effettua il cast della forma a forma raggruppata e ottiene il blocco della forma.
			auto groupShape = ExplicitCast<IGroupShape>(shape);
			auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

			groupShapeLock->set_GroupingLocked(true);
			groupShapeLock->set_PositionLocked(true);
			groupShapeLock->set_SelectLocked(true);
			groupShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IConnector>(shape)) {
			// Effettua il cast della forma a forma connettore e ottiene il blocco della forma.
			auto connectorShape = ExplicitCast<IConnector>(shape);
			auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());
			
			connectorShapeLock->set_PositionMove(true);
			connectorShapeLock->set_SelectLocked(true);
			connectorShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IPictureFrame>(shape)) {
			// Effettua il cast della forma a cornice immagine e ottiene il blocco della forma.
			auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
			auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());
		
			pictureFrameLock->set_PositionLocked(true);
			pictureFrameLock->set_SelectLocked(true);
			pictureFrameLock->set_SizeLocked(true);
		}
	}
}

// Salvataggio del file di presentazione.
presentation->Save(u"ProtectedSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Rimuovere la protezione**

Per sbloccare una forma, impostare il valore del blocco applicato su `false`. Il seguente campione di codice mostra come sbloccare le forme in una presentazione bloccata.

```cpp
// Istanzia la classe Presentation che rappresenta un file PPTX.
auto presentation = MakeObject<Presentation>(u"ProtectedSample.pptx");

// Scorrendo tutte le diapositive nella presentazione.
for (auto&& slide : presentation->get_Slides())	{

	// Scorrendo tutte le forme nella diapositiva.
	for (auto&& shape : slide->get_Shapes()) {

		if (ObjectExt::Is<IAutoShape>(shape)) {
			// Effettua il cast della forma a autoshape e ottiene il blocco della forma.
			auto autoShape = ExplicitCast<IAutoShape>(shape);
			auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

			autoShapeLock->set_PositionLocked(false);
			autoShapeLock->set_SelectLocked(false);
			autoShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IGroupShape>(shape)) {
			// Effettua il cast della forma a forma raggruppata e ottiene il blocco della forma.
			auto groupShape = ExplicitCast<IGroupShape>(shape);
			auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

			groupShapeLock->set_GroupingLocked(false);
			groupShapeLock->set_PositionLocked(false);
			groupShapeLock->set_SelectLocked(false);
			groupShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IConnector>(shape)) {
			// Effettua il cast della forma a forma connettore e ottiene il blocco della forma.
			auto connectorShape = ExplicitCast<IConnector>(shape);
			auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());
			
			connectorShapeLock->set_PositionMove(false);
			connectorShapeLock->set_SelectLocked(false);
			connectorShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IPictureFrame>(shape)) {
			// Effettua il cast della forma a cornice immagine e ottiene il blocco della forma.
			auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
			auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());
		
			pictureFrameLock->set_PositionLocked(false);
			pictureFrameLock->set_SelectLocked(false);
			pictureFrameLock->set_SizeLocked(false);
		}
	}
}

// Salvataggio del file di presentazione.
presentation->Save(u"RemovedProtectionSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Conclusione**

Aspose.Slides offre diverse opzioni per proteggere le forme in una presentazione. È possibile bloccare una singola forma oppure iterare su tutte le forme di una presentazione e bloccarle una per una per mettere in sicurezza l'intero file. È possibile rimuovere la protezione impostando il valore del blocco su `false`.

## **FAQ**

**Posso combinare i blocchi delle forme con la protezione tramite password nella stessa presentazione?**

Sì. I blocchi limitano la modifica degli oggetti all'interno del file, mentre la [protezione con password](/slides/it/cpp/password-protected-presentation/) controlla l'accesso all'apertura e/o al salvataggio delle modifiche. Questi meccanismi si completano a vicenda e funzionano insieme.

**Posso limitare la modifica su diapositive specifiche senza influenzare le altre?**

Sì. Applica i blocchi alle forme delle diapositive selezionate; le diapositive rimanenti resteranno modificabili.

**I blocchi delle forme si applicano a oggetti raggruppati e connettori?**

Sì. Sono supportati tipi di blocco dedicati per gruppi, connettori, oggetti grafici e altri tipi di forma.