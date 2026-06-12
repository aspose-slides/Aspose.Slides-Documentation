---
title: Ottimizzare la gestione delle immagini nelle presentazioni su Android
linktitle: Gestire le immagini
type: docs
weight: 10
url: /it/androidjava/image/
keywords:
- aggiungi immagine
- aggiungi foto
- aggiungi bitmap
- sostituisci immagine
- sostituisci foto
- dal web
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
- Android
- Java
- Aspose.Slides
description: "Ottimizza la gestione delle immagini in PowerPoint e OpenDocument con Aspose.Slides per Android via Java, migliorando le prestazioni e automatizzando il flusso di lavoro."
---
## **Introduzione**

Le immagini rendono le presentazioni più coinvolgenti e interessanti. In Microsoft PowerPoint, è possibile inserire immagini da un file, da Internet o da altre posizioni nelle diapositive. Allo stesso modo, Aspose.Slides consente di aggiungere immagini alle diapositive nelle proprie presentazioni attraverso diverse procedure. 

{{% alert  title="Tip" color="primary" %}} 

Aspose fornisce convertitori gratuiti—[JPEG to PowerPoint](https://products.aspose.app/slides/it/import/jpg-to-ppt) e [PNG to PowerPoint](https://products.aspose.app/slides/it/import/png-to-ppt)—che consentono di creare presentazioni rapidamente a partire dalle immagini. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Se desideri aggiungere un'immagine come oggetto frame—soprattutto se prevedi di utilizzare le opzioni di formattazione standard per modificarne le dimensioni, aggiungere effetti, ecc.—vedi [Picture Frame](https://docs.aspose.com/slides/it/androidjava/picture-frame/). 

{{% /alert %}} 

Aspose.Slides supporta operazioni con immagini in questi formati popolari: JPEG, PNG, GIF e altri. 

## **Aggiungere immagini memorizzate localmente alle diapositive**

Puoi aggiungere una o più immagini dal tuo computer a una diapositiva in una presentazione. Questo esempio di codice in Java mostra come aggiungere un'immagine a una diapositiva:

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

Se l'immagine che desideri aggiungere a una diapositiva non è disponibile sul tuo computer, puoi aggiungere l'immagine direttamente dal Web. 

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

Un master della diapositiva è la diapositiva principale che memorizza e controlla le informazioni (tema, layout, ecc.) su tutte le diapositive sottostanti. Pertanto, quando aggiungi un'immagine a un master della diapositiva, quell'immagine appare su ogni diapositiva sotto quel master. 

Questo esempio di codice Java mostra come aggiungere un'immagine a un master della diapositiva:

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

Potresti decidere di utilizzare un'immagine come sfondo per una diapositiva specifica o per più diapositive. In tal caso, devi consultare *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/it/androidjava/presentation-background/#setting-images-as-background-for-slides)*.

## **Aggiungere SVG alle presentazioni**
Puoi aggiungere o inserire qualsiasi immagine in una presentazione utilizzando il metodo [addPictureFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) appartenente all'interfaccia [IShapeCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IShapeCollection).

Per creare un oggetto immagine basato su un'immagine SVG, puoi procedere in questo modo:

1. Creare un oggetto SvgImage da inserire in ImageShapeCollection
2. Creare un oggetto PPImage da ISvgImage
3. Creare un oggetto PictureFrame utilizzando l'interfaccia IPPImage

Questo esempio di codice mostra come implementare i passaggi precedenti per aggiungere un'immagine SVG in una presentazione:

```java 
// Istanziamento della classe Presentation che rappresenta un file PPTX
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

La funzionalità è fornita da una delle overload del metodo [addGroupShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) dell'interfaccia [IShapeCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IShapeCollection) che accetta un oggetto [ISvgImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISvgImage) come primo argomento.

Questo esempio di codice mostra come utilizzare il metodo descritto per convertire un file SVG in un insieme di forme:

```java 
// Crea una nuova presentazione
IPresentation presentation = new Presentation();
try {
    // Leggi il contenuto del file SVG
    byte[] svgContent = Files.readAllBytes(Paths.get("image.svg"));

    // Crea l'oggetto SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Ottieni le dimensioni della diapositiva
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // Converti l'immagine SVG in un gruppo di forme scalandola alle dimensioni della diapositiva
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
Aspose.Slides per Android tramite Java consente di generare immagini EMF da fogli Excel e aggiungere le immagini come EMF nelle diapositive con Aspose.Cells. 

Questo esempio di codice mostra come eseguire l'operazione descritta:

```java 
Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);
ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

//Salva la cartella di lavoro nello stream
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

## **Sostituire immagini nella collezione di immagini**

Aspose.Slides consente di sostituire le immagini archiviate nella collezione di immagini di una presentazione (incluse quelle utilizzate dalle forme delle diapositive). Questa sezione mostra diversi approcci per aggiornare le immagini nella collezione. L'API fornisce metodi semplici per sostituire un'immagine usando dati byte grezzi, un'istanza [IImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iimage/) o un'altra immagine già presente nella collezione.

Segui i passaggi seguenti:

1. Carica il file di presentazione che contiene le immagini utilizzando la classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
1. Carica una nuova immagine da un file in un array di byte.
1. Sostituisci l'immagine di destinazione con la nuova immagine usando l'array di byte.
1. Nel secondo approccio, carica l'immagine in un oggetto [IImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iimage/) e sostituisci l'immagine di destinazione con tale oggetto.
1. Nel terzo approccio, sostituisci l'immagine di destinazione con un'immagine già presente nella collezione di immagini della presentazione.
1. Salva la presentazione modificata come file PPTX.

```java
// Istanziamento della classe Presentation che rappresenta un file di presentazione.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Il primo metodo.
    IImage imageData = Images.fromStream(new FileInputStream("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // Il secondo metodo.
    IImage newImage = Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
    // Il terzo metodo.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));
    
    // Salva la presentazione in un file.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

Utilizzando il convertitore GRATUITO Aspose [Text to GIF](https://products.aspose.app/slides/it/text-to-gif), è possibile animare facilmente i testi, creare GIF dai testi, ecc. 

{{% /alert %}}

## **FAQ**

**La risoluzione originale dell'immagine rimane intatta dopo l'inserimento?**

Sì. I pixel originali vengono preservati, ma l'aspetto finale dipende da come l*[picture](/slides/it/androidjava/picture-frame/)* è scalato nella diapositiva e da eventuali compressioni applicate al salvataggio.

**Qual è il modo migliore per sostituire lo stesso logo su decine di diapositive contemporaneamente?**

Posiziona il logo sul master della diapositiva o su un layout e sostituiscilo nella collezione di immagini della presentazione: gli aggiornamenti si propagheranno a tutti gli elementi che utilizzano quella risorsa.

**Un SVG inserito può essere convertito in forme modificabili?**

Sì. È possibile convertire un SVG in un gruppo di forme, dopodiché le parti singole diventano modificabili con le proprietà standard delle forme.

**Come posso impostare un'immagine come sfondo per più diapositive contemporaneamente?**

*[Assegna l'immagine come sfondo](/slides/it/androidjava/presentation-background/)* sul master della diapositiva o sul layout pertinente: tutte le diapositive che utilizzano quel master/layout erediteranno lo sfondo.

**Come posso evitare che la presentazione "gonfi" di dimensioni a causa di troppe immagini?**

Riutilizza una singola risorsa immagine anziché duplicati, scegli risoluzioni ragionevoli, applica la compressione al salvataggio e mantieni le grafiche ripetute sul master dove opportuno.