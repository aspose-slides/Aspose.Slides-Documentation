---
title: "Ottimizzare la Gestione delle Immagini nelle Presentazioni in .NET"
linktitle: "Gestire le Immagini"
type: docs
weight: 10
url: /it/net/image/
keywords:
- aggiungere immagine
- aggiungere foto
- aggiungere bitmap
- sostituire immagine
- sostituire foto
- dal web
- sfondo
- aggiungere PNG
- aggiungere JPG
- aggiungere SVG
- risorse SVG esterne
- risolutore SVG
- immagini SVG collegate
- font SVG
- aggiungere EMF
- aggiungere WMF
- aggiungere TIFF
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Snellire la gestione delle immagini in PowerPoint e OpenDocument con Aspose.Slides per .NET, ottimizzando le prestazioni e automatizzando il tuo flusso di lavoro."
---
## **Introduzione**

Le immagini rendono le presentazioni più coinvolgenti e visivamente accattivanti. In Microsoft PowerPoint, è possibile inserire immagini nelle diapositive da file, da internet o da altre fonti. Allo stesso modo, Aspose.Slides consente di aggiungere immagini alle diapositive di una presentazione in diversi modi.

{{% alert title="Suggerimento" color="primary" %}} 
Aspose fornisce convertitori gratuiti—[JPEG a PowerPoint](https://products.aspose.app/slides/it/import/jpg-to-ppt) e [PNG a PowerPoint](https://products.aspose.app/slides/it/import/png-to-ppt)—che consentono di creare rapidamente presentazioni a partire dalle immagini. 
{{% /alert %}} 

{{% alert title="Informazioni" color="info" %}}
Se desideri aggiungere un’immagine come cornice—specialmente se prevedi di ridimensionarla, applicare effetti o utilizzare altre opzioni di formattazione standard—vedi [Cornice Immagine](/slides/it/net/picture-frame/). 
{{% /alert %}} 

{{% alert title="Nota" color="warning" %}}
È possibile convertire le immagini da un formato all’altro. Vedi le seguenti pagine: convertire [immagine in JPG](https://products.aspose.com/slides/it/net/conversion/image-to-jpg/), [JPG a immagine](https://products.aspose.com/slides/it/net/conversion/jpg-to-image/), [JPG a PNG](https://products.aspose.com/slides/it/net/conversion/jpg-to-png/), [PNG a JPG](https://products.aspose.com/slides/it/net/conversion/png-to-jpg/), [PNG a SVG](https://products.aspose.com/slides/it/net/conversion/png-to-svg/), e [SVG a PNG](https://products.aspose.com/slides/it/net/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides supporta immagini nei formati più diffusi come JPEG, PNG, BMP, GIF e altri. 

## **Aggiungere Immagini Salvate Localmente alle Diapositive**

È possibile aggiungere una o più immagini salvate sul proprio computer a una diapositiva della presentazione. Il seguente codice di esempio C# mostra come aggiungere un’immagine a una diapositiva:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Aggiungere Immagini dal Web alle Diapositive**

Se l’immagine che desideri aggiungere a una diapositiva non è salvata sul tuo computer, puoi aggiungerla direttamente dal web. 

Il seguente codice di esempio C# mostra come aggiungere un’immagine dal web a una diapositiva:

```c#
using System.Net;
using Aspose.Slides;
using Aspose.Slides.Export;

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

Un master di diapositiva memorizza e controlla informazioni come il tema e il layout per le diapositive che lo utilizzano. Quando aggiungi un’immagine a un master di diapositiva, l’immagine appare su ogni diapositiva basata su quel master. 

Il seguente codice di esempio C# mostra come aggiungere un’immagine a un master di diapositiva:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

Puoi utilizzare un’immagine come sfondo per una o più diapositive. Per i dettagli, vedi *[Impostare Immagini come Sfondi per le Diapositive](/slides/it/net/presentation-background/#setting-images-as-background-for-slides)*.

## **Aggiungere SVG alle Presentazioni**

Il contenuto SVG può essere aggiunto a una presentazione utilizzando la classe [SvgImage](https://reference.aspose.com/slides/it/net/aspose.slides/svgimage/). L’oggetto [ISvgImage](https://reference.aspose.com/slides/it/net/aspose.slides/isvgimage/) risultante può quindi essere aggiunto alla collezione di immagini della presentazione e utilizzato per creare una cornice immagine.

Il seguente esempio C# importa una stringa SVG autonoma. Tutte le immagini, gli stili e le altre risorse utilizzate da questo SVG sono incorporati direttamente nel contenuto SVG.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string svgContent = @"
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>";

using (Presentation presentation = new Presentation())
{
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage image = presentation.Images.AddImage(svgImage);

    presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 20, 20, image.Width, image.Height, image);

    presentation.Save("self-contained-svg.pptx", SaveFormat.Pptx);
}
```

## **Importare Contenuto SVG con Risorse Esterne**

I file SVG esportati da strumenti di progettazione, editor di diagrammi, sistemi di icone e pipeline web possono fare riferimento a risorse archiviate al di fuori del documento SVG. Per esempio, un SVG può contenere un collegamento a immagine come `images/photo.png`, un valore CSS `url(...)` o un URL di font.

Per importare tale contenuto SVG, crea un’implementazione di [IExternalResourceResolver](https://reference.aspose.com/slides/it/net/aspose.slides.import/iexternalresourceresolver/) e passala, insieme a un URI di base, a un costruttore appropriato di `SvgImage`. L’URI di base identifica la posizione del documento SVG ed è usato per risolvere i collegamenti relativi.

L’interfaccia [ISvgImage](https://reference.aspose.com/slides/it/net/aspose.slides/isvgimage/) fornisce l’accesso alle informazioni sull’SVG importato:

- `SvgContent` restituisce il markup SVG come stringa.
- `SvgData` restituisce il contenuto SVG come array di byte.
- `BaseUri` restituisce l’URI di base utilizzato per i collegamenti relativi.
- `ExternalResourceResolver` restituisce il resolver assegnato all’immagine SVG.

### **Implementare un Resolver di Risorse Esterne**

Il resolver dispone di due metodi:

- [ResolveUri](https://reference.aspose.com/slides/it/net/aspose.slides.import/iexternalresourceresolver/resolveuri/) combina l’URI di base e un collegamento a risorsa relativo e restituisce un URI assoluto. Restituisci `null` quando il collegamento non può essere risolto o non è consentito.
- [GetEntity](https://reference.aspose.com/slides/it/net/aspose.slides.import/iexternalresourceresolver/getentity/) restituisce un flusso leggibile per un URI di risorsa assoluto. Restituisci `null` quando la risorsa è mancante, bloccata o non disponibile. È possibile restituire anche un flusso di fallback quando appropriato.

Il seguente resolver carica le risorse collegate solo da una directory locale consentita. Le risorse di rete e i percorsi al di fuori della directory consentita sono bloccati. Un’immagine di fallback opzionale è restituita per i collegamenti a immagini non risolti.

```csharp
using System;
using System.IO;
using Aspose.Slides.Import;

internal sealed class LocalSvgResourceResolver : IExternalResourceResolver
{
    private readonly string _allowedRoot;
    private readonly byte[] _fallbackImageData;

    public LocalSvgResourceResolver(string allowedRoot, byte[] fallbackImageData = null)
    {
        _allowedRoot = Path.GetFullPath(allowedRoot);
        _fallbackImageData = fallbackImageData;
    }

    public string ResolveUri(string baseUri, string relativeUri)
    {
        if (string.IsNullOrWhiteSpace(baseUri) ||
            string.IsNullOrWhiteSpace(relativeUri))
        {
            return null;
        }

        if (!Uri.TryCreate(baseUri, UriKind.Absolute, out Uri baseAddress) ||
            !Uri.TryCreate(baseAddress, relativeUri, out Uri absoluteAddress))
        {
            return null;
        }

        // Questo resolver consente intenzionalmente solo file locali.
        if (!absoluteAddress.IsFile)
        {
            return null;
        }

        string resourcePath = Path.GetFullPath(absoluteAddress.LocalPath);
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return null;
        }

        return absoluteAddress.AbsoluteUri;
    }

    public Stream GetEntity(string absoluteUri)
    {
        if (!Uri.TryCreate(absoluteUri, UriKind.Absolute, out Uri resourceUri) ||
            !resourceUri.IsFile)
        {
            return null;
        }

        string resourcePath = Path.GetFullPath(resourceUri.LocalPath);
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return null;
        }

        if (File.Exists(resourcePath))
        {
            return File.OpenRead(resourcePath);
        }

        // Utilizza un fallback solo per risorse immagine. Restituire un flusso immagine
        // per un font o foglio di stile mancante non sarebbe valido.
        if (_fallbackImageData != null && IsImageFile(resourcePath))
        {
            return new MemoryStream(_fallbackImageData, writable: false);
        }

        return null;
    }

    private bool IsInsideAllowedRoot(string resourcePath)
    {
        string normalizedRoot = _allowedRoot.TrimEnd(
            Path.DirectorySeparatorChar,
            Path.AltDirectorySeparatorChar) + Path.DirectorySeparatorChar;

        string normalizedPath = Path.GetFullPath(resourcePath);
        StringComparison comparison = Path.DirectorySeparatorChar == '\\'
            ? StringComparison.OrdinalIgnoreCase
            : StringComparison.Ordinal;

        return normalizedPath.StartsWith(normalizedRoot, comparison) ||
               string.Equals(normalizedPath, _allowedRoot, comparison);
    }

    private static bool IsImageFile(string path)
    {
        string extension = Path.GetExtension(path);

        return extension.Equals(".png", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".gif", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".bmp", StringComparison.OrdinalIgnoreCase);
    }
}
```

### **Risoluzione delle Risorse Collegate durante l'Importazione SVG**

Supponi che `assets/diagram.svg` contenga un riferimento relativo come:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Il seguente esempio C# passa l’URI del file SVG come URI di base e fornisce un resolver personalizzato. Il resolver converte il collegamento a immagine relativo in un URI assoluto e restituisce un flusso contenente la risorsa collegata mentre Aspose.Slides elabora l’SVG.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Import;

string svgFilePath = Path.GetFullPath(Path.Combine("assets", "diagram.svg"));
string assetDirectory = Path.GetDirectoryName(svgFilePath) ?? Directory.GetCurrentDirectory();
string svgContent = File.ReadAllText(svgFilePath);

// L'URI di base rappresenta la posizione del documento SVG.
string baseUri = new Uri(svgFilePath).AbsoluteUri;

byte[] fallbackImageData = null;
string fallbackImagePath = Path.Combine(assetDirectory, "fallback.png");
if (File.Exists(fallbackImagePath))
{
    fallbackImageData = File.ReadAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory, fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage espone il contenuto sorgente, i dati binari, l'URI di base e il resolver.
string importedContent = svgImage.SvgContent;
byte[] importedData = svgImage.SvgData;
string importedBaseUri = svgImage.BaseUri;
IExternalResourceResolver importedResolver = svgImage.ExternalResourceResolver;

using (Presentation presentation = new Presentation())
{
    IPPImage image = presentation.Images.AddImage(svgImage);

    presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 20, 20, image.Width, image.Height, image);

    presentation.Save("svg-with-linked-resources.pptx", SaveFormat.Pptx);
}
```

La classe `SvgImage` fornisce anche overload che accettano dati SVG come array di byte o flusso, insieme a un resolver di risorse esterne e a un URI di base.

{{% alert title="Importante" color="warning" %}}
Il resolver di risorse rende disponibili le risorse esterne mentre Aspose.Slides elabora e renderizza l’SVG. Non modifica il markup SVG originale né incorpora automaticamente le risorse risolte al suo interno.

Quando un `ISvgImage` viene aggiunto alla collezione di immagini della presentazione, il file PPTX può contenere sia la rappresentazione SVG originale sia un’immagine raster di fallback. Una risorsa collegata può apparire nell’immagine di fallback generata mentre un collegamento relativo come `images/photo.png` rimane invariato nello SVG memorizzato. Un’applicazione che rende la rappresentazione SVG nativa può quindi omettere il contenuto collegato quando la risorsa esterna originale non è disponibile.
{{% /alert %}}

### **Creare un'Immagine SVG Portabile**

Per creare un’immagine SVG che non dipenda da file esterni, rendi l’SVG autonomo prima di creare il `SvgImage`. Ad esempio, sostituisci gli URL di immagini collegate con URI `data:` che contengono i dati dell’immagine:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Dopo che tutte le risorse necessarie sono state incorporate nel contenuto SVG, crea il `SvgImage`, aggiungilo alla collezione di immagini della presentazione e inseriscilo in una cornice immagine come mostrato nell’esempio precedente.

### **Gestire Risorse Mancanti o Bloccate**

Restituisci `null` da `ResolveUri` quando un URI di risorsa è non valido, proibito o non può essere risolto. Restituisci `null` da `GetEntity` quando la risorsa non può essere letta. Aspose.Slides continua l’elaborazione dell’SVG senza quella risorsa quando possibile.

È possibile restituire un flusso di fallback per una risorsa mancante, ma il suo contenuto deve essere compatibile con il tipo di risorsa richiesto. Per esempio, restituisci un flusso immagine solo per un’immagine mancante, non per un font o un foglio di stile.

{{% alert title="Sicurezza" color="warning" %}}
Non risolvere percorsi di file arbitrari o URL di rete non limitati da file SVG non attendibili. Limita gli schemi, le directory e gli host consentiti. Per le risorse di rete, applica anche timeout di connessione, limiti di dimensione della risposta e convalida del contenuto.
{{% /alert %}}

## **Convertire SVG in un Set di Forme**
Aspose.Slides può convertire un SVG in un insieme di forme, simile alla funzionalità corrispondente in PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

Questa funzionalità è fornita da un overload del metodo [AddGroupShape](https://reference.aspose.com/slides/it/net/aspose.slides.ishapecollection/addgroupshape/methods/1) dell’interfaccia [IShapeCollection](https://reference.aspose.com/slides/it/net/aspose.slides/ishapecollection) che accetta un oggetto [ISvgImage](https://reference.aspose.com/slides/it/net/aspose.slides/isvgimage) come primo argomento.

Il seguente codice di esempio C# mostra come utilizzare questo metodo per convertire un file SVG in un set di forme:

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Nome file SVG di origine
string svgFileName = "sample.svg";

// Nome file della presentazione di output
string outPptxPath = "presentation.pptx";

// Creare una nuova presentazione
using (IPresentation presentation = new Presentation())
{
    // Leggere il contenuto del file SVG
    string svgContent = File.ReadAllText(svgFileName);

    // Creare un oggetto SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Ottenere le dimensioni della diapositiva
    SizeF slideSize = presentation.SlideSize.Size;

    // Convertire l'immagine SVG in un gruppo di forme e scalarla alle dimensioni della diapositiva
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // Salvare la presentazione in formato PPTX
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Aggiungere Immagini come EMF alle Diapositive**
Aspose.Slides per .NET consente di generare immagini EMF da fogli Excel con Aspose.Cells e aggiungerle alle diapositive della presentazione.

Il seguente codice di esempio C# mostra come fare ciò:

``` csharp
using Aspose.Slides;
using Aspose.Cells;
using Aspose.Cells.Rendering;


using (Workbook book = new Workbook("chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageType = Aspose.Cells.Drawing.ImageType.Emf;

    // Salva la cartella di lavoro in un flusso
    SheetRender sr = new SheetRender(sheet, options);
    using (Presentation pres = new Presentation())
    {
        pres.Slides.RemoveAt(0);

        String EmfSheetName = "";
        for (int j = 0; j < sr.PageCount; j++)
        {
            EmfSheetName = "test" + sheet.Name + " Page" + (j + 1) + ".out.emf";
            sr.ToImage(j, EmfSheetName);

            var bytes = File.ReadAllBytes(EmfSheetName);
            var emfImage = pres.Images.AddImage(bytes);
            ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(SlideLayoutType.Blank));
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height, emfImage);
        }

        pres.Save("Saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
```

## **Sostituire Immagini nella Collezione di Immagini**

Aspose.Slides consente di sostituire le immagini memorizzate nella collezione di immagini di una presentazione, incluse le immagini usate dalle forme delle diapositive. Questa sezione descrive diversi modi per aggiornare le immagini nella collezione. È possibile sostituire un’immagine usando dati byte grezzi, un’istanza di [IImage](https://reference.aspose.com/slides/it/net/aspose.slides/iimage/) o un’altra immagine già presente nella collezione.

Segui i passaggi seguenti:

1. Carica il file di presentazione che contiene le immagini utilizzando la classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).
1. Carica una nuova immagine da un file in un array di byte.
1. Sostituisci l’immagine target con la nuova immagine usando l’array di byte.
1. Nel secondo approccio, carica l’immagine in un oggetto [IImage](https://reference.aspose.com/slides/it/net/aspose.slides/iimage/) e sostituisci l’immagine target con quell’oggetto.
1. Nel terzo approccio, sostituisci l’immagine target con un’immagine già presente nella collezione di immagini della presentazione.
1. Scrivi la presentazione modificata come file PPTX.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Istanziare la classe Presentation che rappresenta un file di presentazione.
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

// Salvare la presentazione in un file.
presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert title="Info" color="info" %}}
Con il convertitore gratuito di Aspose [Text to GIF](https://products.aspose.app/slides/it/text-to-gif), puoi animare facilmente del testo e creare GIF dal testo. 
{{% /alert %}}

## **FAQ**

**La risoluzione originale dell’immagine rimane intatta dopo l’inserimento?**

Sì. I pixel di origine sono conservati, ma l’aspetto finale dipende da come il [picture](/slides/it/net/picture-frame/) è scalato sulla diapositiva e da eventuali compressioni applicate al salvataggio.

**Qual è il modo migliore per sostituire lo stesso logo su decine di diapositive contemporaneamente?**

Posiziona il logo sul master della diapositiva o su un layout e sostituiscilo nella collezione di immagini della presentazione—gli aggiornamenti si propagheranno a tutti gli elementi che utilizzano quella risorsa.

**Un SVG inserito può essere convertito in forme modificabili?**

Sì. È possibile convertire un SVG in un gruppo di forme, dopodiché le singole parti diventano modificabili con le proprietà standard delle forme.

**Come posso impostare un’immagine come sfondo per più diapositive contemporaneamente?**

[Assegna l’immagine come sfondo](/slides/it/net/presentation-background/) sul master della diapositiva o sul layout pertinente—tutte le diapositive che usano quel master/layout erediteranno lo sfondo.

**Come evito che una presentazione diventi troppo grande a causa di troppe immagini?**

Riutilizza una singola risorsa immagine anziché duplicati, scegli risoluzioni ragionevoli, applica compressione al salvataggio e mantieni le grafiche ripetute sul master quando opportuno.