---
title: Ottimizzare la Gestione delle Immagini nelle Presentazioni in .NET
linktitle: Gestire le Immagini
type: docs
weight: 10
url: /it/net/image/
keywords:
- aggiungere immagine
- aggiungere foto
- aggiungere bitmap
- sostituire immagine
- sostituire foto
- da web
- sfondo
- aggiungere PNG
- aggiungere JPG
- aggiungere SVG
- aggiungere EMF
- aggiungere WMF
- aggiungere TIFF
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Semplifica la gestione delle immagini in PowerPoint e OpenDocument con Aspose.Slides per .NET, ottimizzando le prestazioni e automatizzando il tuo flusso di lavoro."
---
## **Introduzione**

Le immagini rendono le presentazioni più coinvolgenti e interessanti. In Microsoft PowerPoint, è possibile inserire immagini da un file, da Internet o da altre posizioni nelle diapositive. Allo stesso modo, Aspose.Slides consente di aggiungere immagini alle diapositive nelle proprie presentazioni tramite diverse procedure.

{{% alert  title="Tip" color="primary" %}} 

Aspose offre convertitori gratuiti—[JPEG in PowerPoint](https://products.aspose.app/slides/it/import/jpg-to-ppt) e [PNG in PowerPoint](https://products.aspose.app/slides/it/import/png-to-ppt)—che consentono di creare rapidamente presentazioni a partire dalle immagini. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Se desideri aggiungere un'immagine come oggetto fotogramma—soprattutto se intendi utilizzare le opzioni di formattazione standard per modificarne le dimensioni, aggiungere effetti e così via—consulta [Picture Frame](https://docs.aspose.com/slides/it/net/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

È possibile gestire le operazioni di input/output che coinvolgono immagini e presentazioni PowerPoint per convertire un'immagine da un formato all'altro. Vedi queste pagine: converti [immagine in JPG](https://products.aspose.com/slides/it/net/conversion/image-to-jpg/); converti [JPG in immagine](https://products.aspose.com/slides/it/net/conversion/jpg-to-image/); converti [JPG in PNG](https://products.aspose.com/slides/it/net/conversion/jpg-to-png/), converti [PNG in JPG](https://products.aspose.com/slides/it/net/conversion/png-to-jpg/); converti [PNG in SVG](https://products.aspose.com/slides/it/net/conversion/png-to-svg/), converti [SVG in PNG](https://products.aspose.com/slides/it/net/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides supporta operazioni con immagini in questi formati popolari: JPEG, PNG, BMP, GIF e altri. 

## **Aggiungere Immagini Memorizzate Localmente alle Diapositive**

È possibile aggiungere una o più immagini dal proprio computer a una diapositiva in una presentazione. Questo esempio di codice in C# mostra come aggiungere un'immagine a una diapositiva:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Aggiungere Immagini dal Web alle Diapositive**

Se l'immagine che desideri aggiungere a una diapositiva non è disponibile sul tuo computer, puoi aggiungerla direttamente dal web. 

Questo esempio di codice mostra come aggiungere un'immagine dal web a una diapositiva in C#:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] imageData;
    using (WebClient webClient = new WebClient()) 
    {
        imageData = webClient.DownloadData(new Uri("[REPLACE WITH URL]"));
    }
    
    IPPImage image = pres.Images.AddImage(imageData);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Aggiungere Immagini ai Master delle Diapositive**

Un master diapositive è la diapositiva principale che memorizza e controlla le informazioni (tema, layout, ecc.) di tutte le diapositive sottostanti. Pertanto, quando aggiungi un'immagine a un master diapositive, quell'immagine appare su ogni diapositiva sotto quel master. 

Questo esempio di codice C# mostra come aggiungere un'immagine a un master diapositive:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IMasterSlide masterSlide = slide.LayoutSlide.MasterSlide;
    
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    masterSlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Aggiungere Immagini come Sfondo delle Diapositive**

Potresti decidere di utilizzare un'immagine come sfondo per una diapositiva specifica o per più diapositive. In tal caso, consulta *[Impostare le Immagini come Sfondo per le Diapositive](https://docs.aspose.com/slides/it/net/presentation-background/#setting-images-as-background-for-slides)*.

## **Aggiungere SVG alle Presentazioni**
È possibile aggiungere o inserire qualsiasi immagine in una presentazione usando il metodo [AddPictureFrame](https://reference.aspose.com/slides/it/net/aspose.slides/ishapecollection/methods/addpictureframe) appartenente all'interfaccia [IShapeCollection](https://reference.aspose.com/slides/it/net/aspose.slides/ishapecollection).

Per creare un oggetto immagine basato su un'immagine SVG, puoi procedere in questo modo:

1. Crea un oggetto SvgImage da inserire in ImageShapeCollection
2. Crea un oggetto PPImage da ISvgImage
3. Crea un oggetto PictureFrame utilizzando l'interfaccia IPPImage

Questo esempio di codice mostra come implementare i passaggi sopra per aggiungere un'immagine SVG in una presentazione:
``` csharp 
// Il percorso della directory dei documenti
string dataDir = @"D:\Documents\";

// Nome file SVG di origine
string svgFileName = dataDir + "sample.svg";

// Nome file della presentazione di output
string outPptxPath = dataDir + "presentation.pptx";

// Crea una nuova presentazione
using (var p = new Presentation())
{
    // Leggi il contenuto del file SVG
    string svgContent = File.ReadAllText(svgFileName);

    // Crea l'oggetto SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Crea l'oggetto PPImage
    IPPImage ppImage = p.Images.AddImage(svgImage);

    // Crea un nuovo PictureFrame 
    p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 200, 100, ppImage.Width, ppImage.Height, ppImage);

    // Salva la presentazione in formato PPTX
    p.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Convertire SVG in un Insieme di Forme**
La conversione di SVG in un insieme di forme di Aspose.Slides è simile alla funzionalità di PowerPoint utilizzata per lavorare con immagini SVG:

![PowerPoint Popup Menu](img_01_01.png)

La funzionalità è fornita da una delle sovraccarichi del metodo [AddGroupShape](https://reference.aspose.com/slides/it/net/aspose.slides.ishapecollection/addgroupshape/methods/1) dell'interfaccia [IShapeCollection](https://reference.aspose.com/slides/it/net/aspose.slides/ishapecollection) che accetta un oggetto [ISvgImage](https://reference.aspose.com/slides/it/net/aspose.slides/isvgimage) come primo argomento.

Questo esempio di codice mostra come utilizzare il metodo descritto per convertire un file SVG in un insieme di forme:

``` csharp 
// Il percorso della directory dei documenti
string dataDir = @"D:\Documents\";

// Nome file SVG di origine
string svgFileName = dataDir + "sample.svg";

// Nome file della presentazione di output
string outPptxPath = dataDir + "presentation.pptx";

// Crea una nuova presentazione
using (IPresentation presentation = new Presentation())
{
    // Leggi il contenuto del file SVG
    string svgContent = File.ReadAllText(svgFileName);

    // Crea l'oggetto SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Ottieni la dimensione della diapositiva
    SizeF slideSize = presentation.SlideSize.Size;

    // Converti l'immagine SVG in un gruppo di forme scalandola alla dimensione della diapositiva
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // Salva la presentazione in formato PPTX
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Aggiungere Immagini come EMF alle Diapositive**
Aspose.Slides per .NET consente di generare immagini EMF da fogli Excel e aggiungere le immagini come EMF nelle diapositive con Aspose.Cells. 

Questo esempio di codice mostra come eseguire l'operazione descritta:

``` csharp 
using (Workbook book = new Workbook(dataDir + "chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf;

    //Salva la cartella di lavoro nello stream
    SheetRender sr = new SheetRender(sheet, options);
    using (Presentation pres = new Presentation())
    {
        pres.Slides.RemoveAt(0);

        String EmfSheetName = "";
        for (int j = 0; j < sr.PageCount; j++)
        {
            EmfSheetName = dataDir + "test" + sheet.Name + " Page" + (j + 1) + ".out.emf";
            sr.ToImage(j, EmfSheetName);

            var bytes = File.ReadAllBytes(EmfSheetName);
            var emfImage = pres.Images.AddImage(bytes);
            ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(SlideLayoutType.Blank));
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height, emfImage);
        }

        pres.Save(dataDir + "Saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
```

## **Sostituire Immagini nella Collezione Immagini**

Aspose.Slides consente di sostituire le immagini memorizzate nella collezione immagini di una presentazione (incluse quelle utilizzate dalle forme delle diapositive). Questa sezione mostra diversi approcci per aggiornare le immagini nella collezione. L'API fornisce metodi semplici per sostituire un'immagine usando dati byte grezzi, un'istanza [IImage](https://reference.aspose.com/slides/it/net/aspose.slides/iimage/), o un'altra immagine già presente nella collezione.

Segui i passaggi seguenti:

1. Carica il file di presentazione che contiene le immagini usando la classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).
2. Carica una nuova immagine da un file in un array di byte.
3. Sostituisci l'immagine di destinazione con la nuova immagine usando l'array di byte.
4. Nel secondo approccio, carica l'immagine in un oggetto [IImage](https://reference.aspose.com/slides/it/net/aspose.slides/iimage/) e sostituisci l'immagine target con quell'oggetto.
5. Nel terzo approccio, sostituisci l'immagine target con un'immagine già presente nella collezione immagini della presentazione.
6. Scrivi la presentazione modificata in un file PPTX.

```cs
// Istanzia la classe Presentation che rappresenta un file di presentazione.
using Presentation presentation = new Presentation("sample.pptx");

// Il primo modo.
byte[] imageData = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(imageData);

// Il secondo modo.
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

// Il terzo modo.
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

// Salva la presentazione in un file.
presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert title="Info" color="info" %}}

Utilizzando il convertitore gratuito Aspose [Text to GIF](https://products.aspose.app/slides/it/text-to-gif), è possibile animare facilmente testi, creare GIF da testi, ecc. 

{{% /alert %}}

## **Domande Frequenti**

**La risoluzione originale dell'immagine rimane intatta dopo l'inserimento?**

Sì. I pixel originali vengono conservati, ma l'aspetto finale dipende da come l'[immagine](/slides/it/net/picture-frame/) è scalata nella diapositiva e da eventuali compressioni applicate al salvataggio.

**Qual è il modo migliore per sostituire lo stesso logo su decine di diapositive contemporaneamente?**

Posiziona il logo sul master della diapositiva o su un layout e sostituiscilo nella collezione immagini della presentazione: gli aggiornamenti verranno propagati a tutti gli elementi che utilizzano quella risorsa.

**Un SVG inserito può essere convertito in forme modificabili?**

Sì. È possibile convertire un SVG in un gruppo di forme, dopo di che le singole parti diventano modificabili con le proprietà standard delle forme.

**Come posso impostare un'immagine come sfondo per più diapositive contemporaneamente?**

[Assegna l'immagine come sfondo](/slides/it/net/presentation-background/) sul master della diapositiva o sul layout pertinente—tutte le diapositive che utilizzano quel master/layout erediteranno lo sfondo.

**Come evito che la presentazione aumenti di dimensioni a causa di molte immagini?**

Riutilizza una singola risorsa immagine invece di duplicati, scegli risoluzioni ragionevoli, applica compressione al salvataggio e mantieni le grafiche ripetute sul master quando opportuno.