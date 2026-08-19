---
title: Ottimizzare la gestione delle immagini nelle presentazioni in .NET
linktitle: Gestire le immagini
type: docs
weight: 10
url: /it/net/image/
keywords:
- aggiungere immagine
- aggiungere foto
- sostituire immagine
- collezione immagini
- riquadro immagine
- immagine collegata
- sfondo
- aggiungere PNG
- aggiungere JPG
- aggiungere SVG
- SVG in forme
- risorse SVG esterne
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Impara come aggiungere, riutilizzare, collegare, sostituire e gestire immagini raster e SVG nelle presentazioni PowerPoint e OpenDocument con Aspose.Slides per .NET."
---
## **Introduzione**

Aspose.Slides per .NET offre diversi modi per lavorare con le immagini, e ciascuno serve a uno scopo diverso. È possibile memorizzare un'immagine in una presentazione, visualizzarla in un riquadro immagine, usarla come sfondo diapositive, collegarla a un'immagine esterna, sostituire una risorsa immagine condivisa o convertire contenuti SVG in forme modificabili.

Questo articolo si concentra sulle risorse immagine e su come vengono utilizzate in una presentazione. Per il ritaglio, la trasparenza, gli effetti, lo stiramento e altre formattazioni applicate a un singolo riquadro immagine, vedere [Picture Frame](/slides/it/net/picture-frame/).

## **Comprendere il modello immagine**

I seguenti concetti API sono strettamente correlati ma non intercambiabili:

- La [presentation image collection](https://reference.aspose.com/slides/it/net/aspose.slides/iimagecollection/) memorizza le risorse immagine utilizzate dalla presentazione. Utilizzare [ImageCollection.AddImage](https://reference.aspose.com/slides/it/net/aspose.slides/imagecollection/addimage/) per aggiungere dati immagine e ottenere una risorsa [IPPImage](https://reference.aspose.com/slides/it/net/aspose.slides/ippimage/).
- Un [picture frame](https://reference.aspose.com/slides/it/net/aspose.slides/ipictureframe/) è una forma che visualizza un'immagine su una diapositiva, layout o master. Utilizzare [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/it/net/aspose.slides/ishapecollection/addpictureframe/) per posizionare una risorsa immagine su una diapositiva.
- Uno sfondo diapositiva utilizza un'immagine come parte del riempimento della diapositiva anziché come forma. Pertanto non si comporta come un riquadro immagine.
- [IPPImage.ReplaceImage](https://reference.aspose.com/slides/it/net/aspose.slides/ippimage/replaceimage/) sostituisce una risorsa immagine. Se diversi elementi della presentazione utilizzano quella risorsa, tutti utilizzano la sostituzione.
- Convertire un SVG in forme crea forme diapositiva modificabili. Dopo la conversione, il contenuto non è più gestito come una singola risorsa immagine.

Un tipico flusso di lavoro è quindi: aggiungere dati immagine alla collezione immagini, ricevere un [IPPImage](https://reference.aspose.com/slides/it/net/aspose.slides/ippimage/), quindi utilizzare quella risorsa in uno o più riquadri immagine o riempimenti.

## **Aggiungere un'immagine incorporata**

Per inserire un'immagine locale, leggere il file, aggiungere i suoi dati alla collezione immagini e creare un riquadro immagine che utilizzi l'`IPPImage` restituito.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

L'immagine aggiunta in questo modo è incorporata nella presentazione, quindi il file risultante non dipende dal file immagine originale.

### **Aggiungere un'immagine dal Web**

Quando un'immagine è disponibile tramite HTTP o HTTPS, scaricare i byte con `HttpClient`, aggiungerli alla collezione immagini della presentazione e utilizzare la risorsa immagine restituita allo stesso modo di un'immagine locale.

```csharp
using System;
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;

var imageUri = new Uri("https://example.com/image.png");
using var httpClient = new HttpClient();
var imageData = await httpClient.GetByteArrayAsync(imageUri);

using var presentation = new Presentation();

var image = presentation.Images.AddImage(imageData);
var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

presentation.Save("presentation-from-web.pptx", SaveFormat.Pptx);
```

In applicazioni a lungo termine, riutilizzare `HttpClient` anziché creare una nuova istanza per ogni richiesta. Convalidare inoltre gli URL remoti, le dimensioni della risposta e i tipi di contenuto quando la sorgente non è attendibile.

## **Riutilizzare le immagini tra le diapositive**

Se la stessa immagine è necessaria più di una volta, aggiungerla alla presentazione una sola volta e riutilizzare l'[IPPImage](https://reference.aspose.com/slides/it/net/aspose.slides/ippimage/) restituito quando si creano riquadri immagine aggiuntivi. Ciò evita di caricare ripetutamente gli stessi dati sorgente e rende esplicita la relazione tra la risorsa immagine condivisa e i suoi utilizzi.

Per grafica che deve comparire automaticamente su molte diapositive, ad esempio un logo aziendale, considerare di posizionare il riquadro immagine su uno [slide master](/slides/it/net/slide-master/) o layout anziché aggiungere una forma equivalente a ogni diapositiva.

## **Usare un'immagine come sfondo della diapositiva**

Un'immagine di sfondo è assegnata al riempimento della diapositiva; non viene aggiunta come forma di riquadro immagine. Questo è utile quando l'immagine deve coprire lo sfondo della diapositiva e non deve essere manipolata come un normale oggetto di diapositiva.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("background.jpg");
var image = presentation.Images.AddImage(imageData);
slide.Background.Type = BackgroundType.OwnBackground;
slide.Background.FillFormat.FillType = FillType.Picture;
slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
slide.Background.FillFormat.PictureFillFormat.Picture.Image = image;

presentation.Save("background-image.pptx", SaveFormat.Pptx);
```

Per ulteriori opzioni di sfondo, inclusi sfondi di master e layout, vedere [Presentation Background](/slides/it/net/presentation-background/).

## **Immagini incorporate e immagini collegate**

Le immagini incorporate e le immagini collegate hanno diversi compromessi di portabilità e dimensione del file:

- **Immagine incorporata:** i dati immagine sono memorizzati all'interno della presentazione. La presentazione è autonoma, ma la dimensione del file include i dati immagine.
- **Immagine collegata:** la presentazione memorizza un percorso o URL a un'immagine esterna. Questo può ridurre la dimensione della presentazione, ma la risorsa esterna deve rimanere accessibile quando la presentazione viene aperta o resa.

Un'immagine collegata può essere creata assegnando il percorso o l'URL esterno tramite [ISlidesPicture.LinkPathLong](https://reference.aspose.com/slides/it/net/aspose.slides/islidespicture/linkpathlong/) anziché incorporare i dati immagine.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, null);
pictureFrame.PictureFormat.Picture.LinkPathLong = "https://example.com/image.png";

presentation.Save("linked-image.pptx", SaveFormat.Pptx);
```

Utilizzare immagini collegate solo quando l'ambiente di distribuzione può accedere in modo affidabile alla risorsa esterna. Per presentazioni che devono funzionare offline o essere spostate tra sistemi, le immagini incorporate sono generalmente più sicure.

## **Lavorare con immagini SVG**

SVG è un formato vettoriale, quindi può essere utile per icone, diagrammi e altre grafiche che devono scalare senza la stessa perdita di dettaglio delle immagini raster. Aspose.Slides supporta SVG sia come risorsa immagine sia come sorgente per forme diapositiva modificabili.

### **Aggiungere un SVG come immagine**

Creare un [SvgImage](https://reference.aspose.com/slides/it/net/aspose.slides/svgimage/), aggiungerlo alla collezione immagini e posizionare la risorsa immagine risultante in un riquadro immagine.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = File.ReadAllText("icon.svg");
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();

var image = presentation.Images.AddImage(svgImage);
var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image);

presentation.Save("svg-image.pptx", SaveFormat.Pptx);
```

### **File SVG con risorse esterne**

Un SVG può fare riferimento a immagini, fogli di stile o caratteri esterni. Per questi casi, [SvgImage](https://reference.aspose.com/slides/it/net/aspose.slides/svgimage/) fornisce costruttori che accettano un [IExternalResourceResolver](https://reference.aspose.com/slides/it/net/aspose.slides.import/iexternalresourceresolver/) e un URI base. Il risolutore può mappare un URI relativo a un URI assoluto consentito e restituire uno stream per la risorsa richiesta.

Il risolutore rende disponibili le risorse esterne mentre Aspose.Slides elabora l'SVG, ma non riscrive l'SVG in un documento autonomo. Se l'SVG deve rimanere portabile, incorporare le risorse necessarie direttamente nell'SVG, ad esempio usando URI `data:` per le immagini collegate.

Quando i file SVG provengono da fonti non attendibili, limitare gli schemi, le posizioni dei file e gli host a cui il risolutore può accedere. I risolutori di rete dovrebbero inoltre applicare timeout, limiti di dimensione della risposta e convalida dei contenuti.

### **Convertire SVG in forme modificabili**

Aspose.Slides può convertire un SVG in un gruppo di forme diapositiva modificabili, simile al comando corrispondente di PowerPoint.

![PowerPoint Popup Menu](img_01_01.png)

Utilizzare la sovraccarico di [IShapeCollection.AddGroupShape](https://reference.aspose.com/slides/it/net/aspose.slides/ishapecollection/addgroupshape/) che accetta un [ISvgImage](https://reference.aspose.com/slides/it/net/aspose.slides/isvgimage/) per eseguire la conversione.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = File.ReadAllText("diagram.svg");
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var slide = presentation.Slides[0];
slide.Shapes.AddGroupShape(svgImage, 0, 0, slideSize.Width, slideSize.Height);

presentation.Save("editable-svg-shapes.pptx", SaveFormat.Pptx);
```

Usare la conversione SVG‑to‑shapes quando gli elementi vettoriali individuali devono essere modificati come forme PowerPoint. Se l'SVG deve solo essere visualizzato, mantenerlo come immagine è più semplice e evita di creare molte forme separate.

## **Sostituire una risorsa immagine esistente**

Utilizzare [IPPImage.ReplaceImage](https://reference.aspose.com/slides/it/net/aspose.slides/ippimage/replaceimage/) quando si desidera sostituire una risorsa immagine esistente. Questo è particolarmente utile per grafiche condivise come loghi.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var imageToReplace = presentation.Images[0];
imageToReplace.ReplaceImage(File.ReadAllBytes("new-logo.png"));

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Se più riquadri immagine, sfondi, master o layout utilizzano la stessa risorsa immagine, la sostituzione di quella risorsa aggiorna tutti quegli utilizzi. Se deve cambiare solo un riquadro immagine, assegnare un'immagine diversa a quel riquadro anziché sostituire la risorsa condivisa.

`ReplaceImage` fornisce anche sovraccarichi che accettano un [IImage](https://reference.aspose.com/slides/it/net/aspose.slides/iimage/) o un altro [IPPImage](https://reference.aspose.com/slides/it/net/aspose.slides/ippimage/).

## **Indicazioni pratiche per la gestione delle immagini**

### **Controllare le dimensioni della presentazione**

Le immagini raster di grandi dimensioni possono rendere una presentazione inutilmente pesante. Utilizzare immagini sorgente con dimensioni appropriate per la visualizzazione prevista, riutilizzare risorse immagine condivise quando possibile e evitare di incorporare copie duplicate della stessa grafica ad alta risoluzione.

Per immagini raster già inserite in riquadri immagine, [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/it/net/aspose.slides/ipicturefillformat/compressimage/) può ridurre i dati immagine in base alla risoluzione selezionata e alle impostazioni di ritaglio. Questo è un processo di riquadro immagine, non di gestione della collezione immagini, quindi consultare [Picture Frame](/slides/it/net/picture-frame/) per operazioni di formattazione correlate.

### **Scegliere tra contenuto incorporato e collegato**

L'incorporamento rende la presentazione portabile perché tutti i dati immagine necessari viaggiano con il file. Il collegamento può ridurre la dimensione del file, ma introduce una dipendenza esterna. Utilizzare collegamenti solo quando tale dipendenza è accettabile e stabile.

### **Riutilizzare il branding condiviso**

Per loghi, filigrane o grafiche decorative ripetute, utilizzare una singola risorsa immagine e riutilizzarla. Se la grafica appartiene al design della presentazione piuttosto che al contenuto delle diapositive, posizionarla su un master o layout affinché venga ereditata dalle diapositive appropriate.

### **Mantenere le risorse SVG portabili**

Un SVG autonomo è più facile da spostare e rendere in modo coerente rispetto a un SVG che dipende da file esterni o risorse di rete. Quando possibile, incorporare le risorse necessarie prima di importare l'SVG. Convertire l'SVG in forme solo quando gli elementi vettoriali individuali devono essere modificati.

### **Utilizzare l'API immagine moderna multipiattaforma**

Per nuovo codice .NET, utilizzare le API Aspose.Slides [IImage](https://reference.aspose.com/slides/it/net/aspose.slides/iimage/) e [Images](https://reference.aspose.com/slides/it/net/aspose.slides/images/) invece di fare affidamento su `System.Drawing.Image` o `Bitmap`. Vedere [Modern API](/slides/it/net/modern-api/) per le linee guida di migrazione.

WMF ed EMF richiedono considerazioni speciali. Quando questi formati vengono passati attraverso un [IImage](https://reference.aspose.com/slides/it/net/aspose.slides/iimage/), [ImageCollection.AddImage](https://reference.aspose.com/slides/it/net/aspose.slides/imagecollection/addimage/) converte il metafile in una rappresentazione PNG raster prima dell'inserimento. Se è importante preservare i dati del metafile, utilizzare la sovraccarico basata su stream di [ImageCollection.AddImage](https://reference.aspose.com/slides/it/net/aspose.slides/imagecollection/addimage/). Generare contenuti EMF da fogli di calcolo o altri prodotti è un flusso di integrazione separato ed è al di fuori dell'ambito di questo articolo.

## **FAQ**

**Qual è la differenza tra la collezione immagini e un riquadro immagine?**

La collezione immagini memorizza risorse immagine riutilizzabili. Un riquadro immagine è una forma della diapositiva che visualizza una di quelle risorse e fornisce formattazioni specifiche per l'immagine, come ritaglio ed effetti.

**Qual è il modo migliore per sostituire lo stesso logo ovunque?**

Se il logo è già condiviso come una singola risorsa immagine, sostituire quella risorsa con [IPPImage.ReplaceImage](https://reference.aspose.com/slides/it/net/aspose.slides/ippimage/replaceimage/). Per il branding a livello di presentazione, posizionare il logo su un master o layout può anche ridurre il contenuto duplicato delle diapositive.

**Perché un'immagine collegata scompare su un altro computer?**

Un'immagine collegata dipende dal file o URL esterno. Se quella risorsa non è raggiungibile dall'altro computer, l'immagine collegata può non essere disponibile. Incorporare l'immagine quando la presentazione deve essere autonoma.

**Un SVG inserito può essere modificato come forme PowerPoint?**

Sì. Convertire l'SVG con [IShapeCollection.AddGroupShape](https://reference.aspose.com/slides/it/net/aspose.slides/ishapecollection/addgroupshape/); il gruppo risultante contiene forme diapositiva modificabili anziché un'unica immagine SVG.

**Come posso mantenere le presentazioni con molte immagini più leggere?**

Riutilizzare le risorse immagine condivise, evitare sorgenti raster inutilmente grandi, comprimere le immagini raster appropriate quando opportuno, tenere il branding ripetuto su master o layout e utilizzare immagini collegate solo quando una dipendenza esterna è accettabile.