---
title: Blocco della presentazione
type: docs
weight: 110
url: /it/net/presentation-locking/
---
## **Blocco della presentazione**
Un utilizzo comune di **Aspose.Slides** è creare, aggiornare e salvare presentazioni Microsoft PowerPoint 2007 (PPTX) all'interno di un flusso di lavoro automatizzato. Gli utenti dell'applicazione che utilizza Aspose.Slides in questo modo ottengono l'accesso alle presentazioni generate. La protezione di queste da modifiche è una preoccupazione comune. È importante che le presentazioni generate automaticamente mantengano la formattazione e il contenuto originali.

Qui viene spiegato come sono costruite le presentazioni e le diapositive e come Aspose.Slides per .NET può applicare una protezione a una presentazione e poi rimuoverla. Questa funzionalità è esclusiva di Aspose.Slides e, al momento della stesura, non è disponibile in Microsoft PowerPoint. Consente agli sviluppatori di controllare come vengono utilizzate le presentazioni create dalle loro applicazioni.

## **Composizione di una diapositiva**
Una diapositiva PPTX è composta da diversi componenti come forme automatiche, tabelle, oggetti OLE, forme raggruppate, fotogrammi immagine, fotogrammi video, connettori e gli altri elementi disponibili per costruire una presentazione.

In Aspose.Slides per .NET, ogni elemento su una diapositiva viene trasformato in un oggetto Shape. In altre parole, ogni elemento della diapositiva è un oggetto Shape o un oggetto derivato da Shape.

La struttura di PPTX è complessa, quindi a differenza di PPT, dove è possibile utilizzare un blocco generico per tutti i tipi di forme, esistono diversi tipi di blocchi per i diversi tipi di forma. La classe BaseShapeLock è la classe generica di blocco per PPTX. I seguenti tipi di blocchi sono supportati in Aspose.Slides per .NET per PPTX.

- AutoShapeLock blocca le forme automatiche.  
- ConnectorLock blocca le forme di connettore.  
- GraphicalObjectLock blocca gli oggetti grafici.  
- GroupshapeLock blocca le forme raggruppate.  
- PictureFrameLock blocca i fotogrammi immagine.

Qualsiasi azione eseguita su tutti gli oggetti Shape in un oggetto Presentation viene applicata all'intera presentazione.

## **Applicare e rimuovere la protezione**
L'applicazione della protezione garantisce che una presentazione non possa essere modificata. È una tecnica utile per proteggere il contenuto di una presentazione.

**Applicazione della protezione alle forme PPTX**

Aspose.Slides per .NET fornisce la classe Shape per gestire una forma sulla diapositiva.

Come accennato in precedenza, ogni classe di forma ha una classe di blocco associata per la protezione. Questo articolo si concentra sui blocchi NoSelect, NoMove e NoResize. Questi blocchi garantiscono che le forme non possano essere selezionate (tramite clic del mouse o altri metodi di selezione) e non possano essere spostate o ridimensionate.

I campioni di codice che seguono applicano la protezione a tutti i tipi di forme in una presentazione.

``` csharp

 //Instanzia la classe Presentation che rappresenta un file PPTX

PresentationEx pTemplate = new PresentationEx("Applying Protection.pptx");//Instanzia la classe Presentation che rappresenta un file PPTX


//Oggetto ISlide per accedere alle diapositive nella presentazione

SlideEx slide = pTemplate.Slides[0];

//Oggetto IShape per contenere forme temporanee

ShapeEx shape;

//Scorrendo tutte le diapositive nella presentazione

for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)

{

	slide = pTemplate.Slides[slideCount];

		//Scorrendo tutte le forme nelle diapositive

	for (int count = 0; count < slide.Shapes.Count; count++)

	{

		shape = slide.Shapes[count];

		//se la forma è autoshape

		if (shape is AutoShapeEx)

		{

			//Conversione di tipo a forma Auto e ottenimento del blocco della forma Auto

			AutoShapeEx Ashp = shape as AutoShapeEx;

			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;

			//Applicazione dei blocchi alle forme

			AutoShapeLock.PositionLocked = true;

			AutoShapeLock.SelectLocked = true;

			AutoShapeLock.SizeLocked = true;

		}

		//se la forma è group shape

		else if (shape is GroupShapeEx)

		{

			//Conversione di tipo a forma di gruppo e ottenimento del blocco della forma di gruppo

			GroupShapeEx Group = shape as GroupShapeEx;

			GroupShapeLockEx groupShapeLock = Group.ShapeLock;

			//Applicazione dei blocchi alle forme

			groupShapeLock.GroupingLocked = true;

			groupShapeLock.PositionLocked = true;

			groupShapeLock.SelectLocked = true;

			groupShapeLock.SizeLocked = true;

		}

		//se la forma è un connector

		else if (shape is ConnectorEx)

		{

			//Conversione di tipo a forma di connettore e ottenimento del blocco della forma di connettore

			ConnectorEx Conn = shape as ConnectorEx;

			ConnectorLockEx ConnLock = Conn.ShapeLock;

			//Applicazione dei blocchi alle forme

			ConnLock.PositionMove = true;

			ConnLock.SelectLocked = true;

			ConnLock.SizeLocked = true;

		}

		//se la forma è picture frame

		else if (shape is PictureFrameEx)

		{

			//Conversione di tipo a forma di fotogramma immagine e ottenimento del blocco della forma di fotogramma immagine

			PictureFrameEx Pic = shape as PictureFrameEx;

			PictureFrameLockEx PicLock = Pic.ShapeLock;

			//Applicazione dei blocchi alle forme

			PicLock.PositionLocked = true;

			PicLock.SelectLocked = true;

			PicLock.SizeLocked = true;

		}

	}

}

//Salvataggio del file della presentazione

pTemplate.Save("ProtectedSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
``` 

**Rimozione della protezione**

La protezione applicata con Aspose.Slides per .NET può essere rimossa solo con Aspose.Slides per .NET. Per sbloccare una forma, impostare il valore del blocco applicato su false. Il campione di codice che segue mostra come sbloccare le forme in una presentazione bloccata.

``` csharp

 //Apri la presentazione desiderata
PresentationEx pTemplate = new PresentationEx("ProtectedSample.pptx");

//Oggetto ISlide per accedere alle diapositive nella presentazione
SlideEx slide = pTemplate.Slides[0];

//Oggetto IShape per contenere forme temporanee
ShapeEx shape;

//Scorrendo tutte le diapositive nella presentazione
for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)
{
	slide = pTemplate.Slides[slideCount];
		//Scorrendo tutte le forme nelle diapositive
	for (int count = 0; count < slide.Shapes.Count; count++)
	{
		shape = slide.Shapes[count];
		//se la forma è autoshape
		if (shape is AutoShapeEx)
		{
			//Conversione di tipo a forma Auto e ottenimento del blocco della forma Auto
			AutoShapeEx Ashp = shape as AutoShapeEx;
			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;
			//Applicazione dei blocchi alle forme
			AutoShapeLock.PositionLocked = false;
			AutoShapeLock.SelectLocked = false;
			AutoShapeLock.SizeLocked = false;
		}
		//se la forma è group shape
		else if (shape is GroupShapeEx)
		{
			//Conversione di tipo a forma di gruppo e ottenimento del blocco della forma di gruppo
			GroupShapeEx Group = shape as GroupShapeEx;
			GroupShapeLockEx groupShapeLock = Group.ShapeLock;
			//Applicazione dei blocchi alle forme
			groupShapeLock.GroupingLocked = false;
			groupShapeLock.PositionLocked = false;
			groupShapeLock.SelectLocked = false;
			groupShapeLock.SizeLocked = false;
		}
		//se la forma è Connector shape
		else if (shape is ConnectorEx)
		{
			//Conversione di tipo a forma di connettore e ottenimento del blocco della forma di connettore
			ConnectorEx Conn = shape as ConnectorEx;
			ConnectorLockEx ConnLock = Conn.ShapeLock;
			//Applicazione dei blocchi alle forme
			ConnLock.PositionMove = false;
			ConnLock.SelectLocked = false;
			ConnLock.SizeLocked = false;
		}
		//se la forma è picture frame
		else if (shape is PictureFrameEx)
		{
			//Conversione di tipo a forma picture frame e ottenimento del blocco della forma picture frame
			PictureFrameEx Pic = shape as PictureFrameEx;
			PictureFrameLockEx PicLock = Pic.ShapeLock;
			//Applicazione dei blocchi alle forme
			PicLock.PositionLocked = false;
			PicLock.SelectLocked = false;
			PicLock.SizeLocked = false;
		}
	}
}

//Salvataggio del file della presentazione
pTemplate.Save("RemoveProtectionSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
``` 
## **Scarica il codice di esempio**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Presentation%20Locking%20%28Aspose.Slides%29.zip)