---
title: Ottimizza la gestione delle immagini nelle presentazioni con Java
linktitle: Gestire le immagini
type: docs
weight: 10
url: /it/java/image/
keywords:
- aggiungi immagine
- aggiungi foto
- aggiungi bitmap
- sostituisci immagine
- sostituisci foto
- da web
- sfondo
- aggiungi PNG
- aggiungi JPG
- aggiungi SVG
- aggiungi EMF
- aggiungi WMF
- aggiungi TIFF
- PowerPoint
- OpenDocument
- presentazione
- EMF
- SVG
- Java
- Aspose.Slides
description: "Ottimizza la gestione delle immagini in PowerPoint e OpenDocument con Aspose.Slides per Java, migliorando le prestazioni e automatizzando il tuo flusso di lavoro."
---
## **Introduzione**

Le immagini rendono le presentazioni più coinvolgenti e interessanti. In Microsoft PowerPoint, è possibile inserire immagini da un file, da Internet o da altre posizioni nelle diapositive. Allo stesso modo, Aspose.Slides consente di aggiungere immagini alle diapositive delle proprie presentazioni attraverso diverse procedure. 

{{% alert title="Suggerimento" color="primary" %}} 

Aspose offre convertitori gratuiti—[JPEG a PowerPoint](https://products.aspose.app/slides/it/import/jpg-to-ppt) e [PNG a PowerPoint](https://products.aspose.app/slides/it/import/png-to-ppt)—che permettono di creare rapidamente presentazioni a partire dalle immagini. 

{{% /alert %}} 

{{% alert title="Informazione" color="info" %}}

Se desideri aggiungere un'immagine come oggetto di fotogramma—soprattutto se intendi utilizzare le opzioni di formattazione standard per modificare le sue dimensioni, aggiungere effetti, ecc.—consulta la sezione [Picture Frame](https://docs.aspose.com/slides/it/java/picture-frame/). 

{{% /alert %}} 

{{% alert title="Nota" color="warning" %}}

Puoi gestire le operazioni di input/output che coinvolgono immagini e presentazioni PowerPoint per convertire un'immagine da un formato all'altro. Vedi queste pagine: converti [immagine in JPG](https://products.aspose.com/slides/it/java/conversion/image-to-jpg/); converti [JPG in immagine](https://products.aspose.com/slides/it/java/conversion/jpg-to-image/); converti [JPG in PNG](https://products.aspose.com/slides/it/java/conversion/jpg-to-png/), converti [PNG in JPG](https://products.aspose.com/slides/it/java/conversion/png-to-jpg/); converti [PNG in SVG](https://products.aspose.com/slides/it/java/conversion/png-to-svg/), converti [SVG in PNG](https://products.aspose.com/slides/it/java/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides supporta operazioni con immagini nei formati più diffusi: JPEG, PNG, GIF e altri. 

## **Aggiungere immagini archiviate localmente alle diapositive**

Puoi aggiungere una o più immagini presenti sul tuo computer a una diapositiva di una presentazione. Questo esempio di codice in Java mostra come aggiungere un'immagine a una diapositiva:

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
	slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Aggiungere immagini dal Web alle diapositive**

Se l'immagine che desideri aggiungere a una diapositiva non è disponibile sul tuo computer, puoi inserirla direttamente dal Web. 

Questo esempio di codice mostra come aggiungere un'immagine dal Web a una diapositiva in Java:

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);

	URL imageUrl = new URL("[REPLACE WITH URL]");
	URLConnection connection = imageUrl.openConnection();
	InputStream inputStream = connection.getInputStream();

	ByteArrayOutputStream outputStream = new ByteArrayOutputStream();
	try {
		byte[] buffer = new byte[1024];
		int read;

		while ((read = inputStream.read(buffer, 0, buffer.length)) != -1)
			outputStream.write(buffer, 0, read);

		outputStream.flush();

		IPPImage image = pres.getImages().addImage(outputStream.toByteArray());
		slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
	} finally {
		if (inputStream != null) inputStream.close();
		outputStream.close();
	}

	pres.save("pres.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

## **Aggiungere immagini ai master delle diapositive**

Un master di diapositiva è la diapositiva superiore che memorizza e controlla le informazioni (tema, layout, ecc.) di tutte le diapositive sottostanti. Pertanto, quando aggiungi un'immagine a un master di diapositiva, quell'immagine appare su tutte le diapositive che utilizzano quel master. 

Questo esempio di codice Java mostra come aggiungere un'immagine a un master di diapositiva:

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	IMasterSlide masterSlide = slide.getLayoutSlide().getMasterSlide();

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
	masterSlide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Aggiungere immagini come sfondo delle diapositive**

Potresti decidere di utilizzare un'immagine come sfondo per una specifica diapositiva o per più diapositive. In tal caso, consulta *[Impostare le immagini come sfondi per le diapositive](https://docs.aspose.com/slides/it/java/presentation-background/#setting-images-as-background-for-slides)*.

## **Aggiungere SVG alle presentazioni**
Puoi aggiungere o inserire qualsiasi immagine in una presentazione utilizzando il metodo [addPictureFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) appartenente all'interfaccia [IShapeCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/IShapeCollection).

Per creare un oggetto immagine basato su SVG, puoi procedere in questo modo:

1. Crea un oggetto SvgImage da inserire in ImageShapeCollection  
2. Crea un oggetto PPImage da ISvgImage  
3. Crea un oggetto PictureFrame usando l'interfaccia IPPImage  

Questo esempio di codice mostra come implementare i passaggi precedenti per aggiungere un'immagine SVG a una presentazione:
```java
// Istanzia la classe Presentation che rappresenta il file PPTX
Presentation pres = new Presentation();
try {
    String svgContent = new String(Files.readAllBytes(Paths.get("image.svg")));
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage ppImage = pres.getImages().addImage(svgImage);
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 
			ppImage.getWidth(), ppImage.getHeight(), ppImage);
    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Convertire SVG in un insieme di forme**
La conversione di SVG in un insieme di forme di Aspose.Slides è simile alla funzionalità di PowerPoint utilizzata per lavorare con immagini SVG:

![PowerPoint Popup Menu](img_01_01.png)

La funzionalità è fornita da una delle sovraccariche del metodo [addGroupShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) dell'interfaccia [IShapeCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/IShapeCollection) che accetta un oggetto [ISvgImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISvgImage) come primo argomento.

Questo esempio di codice mostra come utilizzare il metodo descritto per convertire un file SVG in un insieme di forme:

```java 
// Crea una nuova presentazione
IPresentation presentation = new Presentation();
try {
    // Leggi il contenuto del file SVG
    byte[] svgContent = Files.readAllBytes(Paths.get("image.svg"));

    // Crea l'oggetto SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Ottieni la dimensione della diapositiva
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // Converti l'immagine SVG in un gruppo di forme scalandola alla dimensione della diapositiva
    presentation.getSlides().get_Item(0).getShapes().
            addGroupShape(svgImage, 0f, 0f, (float)slideSize.getWidth(), (float)slideSize.getHeight());

    // Salva la presentazione in formato PPTX
    presentation.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Aggiungere immagini come EMF alle diapositive**
Aspose.Slides per Java consente di generare immagini EMF da fogli Excel e di aggiungere le immagini come EMF nelle diapositive con Aspose.Cells.  

Questo esempio di codice mostra come eseguire l'operazione descritta:

```java 
Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);
ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

//Salva la cartella di lavoro su stream
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);
    
    String EmfSheetName = "";
    for (int j = 0; j < sr.getPageCount(); j++)
    {
    
        EmfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, EmfSheetName);

        IPPImage picture;
        IImage image = Images.fromFile(EmfSheetName);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
        ISlide slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().getByType(SlideLayoutType.Blank));
        IShape m = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0,
					(float)pres.getSlideSize().getSize().getWidth(), 
					(float)pres.getSlideSize().getSize().getHeight(), 
					picture);
    }
    
    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Sostituire immagini nella raccolta di immagini**

Aspose.Slides permette di sostituire le immagini archiviate nella raccolta di immagini di una presentazione (incluse quelle utilizzate dalle forme delle diapositive). Questa sezione mostra diversi approcci per aggiornare le immagini nella raccolta. L'API fornisce metodi semplici per sostituire un'immagine utilizzando dati byte grezzi, un'istanza [IImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/iimage/) o un'altra immagine già presente nella raccolta.

Segui i passaggi seguenti:

1. Carica il file di presentazione che contiene le immagini tramite la classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/).  
2. Carica una nuova immagine da un file in un array di byte.  
3. Sostituisci l'immagine di destinazione con la nuova immagine utilizzando l'array di byte.  
4. Nel secondo approccio, carica l'immagine in un oggetto [IImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/iimage/) e sostituisci l'immagine di destinazione con quell'oggetto.  
5. Nel terzo approccio, sostituisci l'immagine di destinazione con un'immagine che già esiste nella raccolta di immagini della presentazione.  
6. Salva la presentazione modificata come file PPTX.  

```java
// Istanzia la classe Presentation che rappresenta un file di presentazione.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Il primo modo.
    byte[] imageData = Files.readAllBytes(Paths.get("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // Il secondo modo.
    IImage newImage = Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
    // Il terzo modo.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));
    
    // Salva la presentazione in un file.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Informazione" color="info" %}}

Utilizzando il convertitore GRATUITO Aspose [Text to GIF](https://products.aspose.app/slides/it/text-to-gif), puoi animare facilmente testi, creare GIF da testi, ecc. 

{{% /alert %}}

## **FAQ**

**La risoluzione originale dell'immagine rimane intatta dopo l'inserimento?**

Sì. I pixel originali vengono preservati, ma l'aspetto finale dipende da come l'[immagine](/slides/it/java/picture-frame/) è scalata sulla diapositiva e da eventuali compressioni applicate al salvataggio.

**Qual è il modo migliore per sostituire lo stesso logo su decine di diapositive in una sola volta?**

Posiziona il logo sul master delle diapositive o su un layout e sostituirlo nella raccolta di immagini della presentazione: le modifiche si propagheranno a tutti gli elementi che utilizzano quella risorsa.

**Un SVG inserito può essere convertito in forme modificabili?**

Sì. È possibile convertire un SVG in un gruppo di forme; successivamente le singole parti diventano modificabili con le proprietà standard delle forme.

**Come posso impostare un'immagine come sfondo per più diapositive contemporaneamente?**

[Assegna l'immagine come sfondo](/slides/it/java/presentation-background/) sul master delle diapositive o sul layout pertinente: tutte le diapositive che usano quel master/layout erediteranno lo sfondo.

**Come evito che la presentazione "gonfi" di dimensioni a causa di troppe immagini?**

Riutilizza una singola risorsa immagine invece di duplicati, scegli risoluzioni adeguate, applica compressione al salvataggio e mantieni le grafiche ricorrenti sul master quando opportuno.