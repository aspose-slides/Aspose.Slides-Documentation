---
title: Gestire i picture frame nelle presentazioni in .NET
linktitle: Frame immagine
type: docs
weight: 10
url: /it/net/picture-frame/
keywords:
- frame immagine
- aggiungi frame immagine
- crea frame immagine
- immagine incorporata
- immagine collegata
- estrai immagine
- immagine raster
- immagine SVG
- ritaglia immagine
- elimina aree ritagliate
- comprimi immagine
- StretchOffset
- formattazione frame immagine
- scala relativa
- effetto immagine
- rapporto d'aspetto
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Crea, formatta, collega, ritaglia, estrae e comprime i picture frame nelle presentazioni con Aspose.Slides per .NET."
---
## **Panoramica**

Un picture frame è una forma di diapositiva che visualizza un'immagine. In Aspose.Slides, la risorsa immagine e la forma che la visualizza sono oggetti separati: una [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) possiede le risorse immagine incorporate tramite la sua collezione [Images](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/images/), mentre un [IPictureFrame](https://reference.aspose.com/slides/it/net/aspose.slides/ipictureframe/) controlla la posizione, le dimensioni, la formattazione delle linee, la rotazione, il ritaglio, gli effetti immagine e altre impostazioni a livello di frame.

Questa separazione è utile quando la stessa immagine viene mostrata più di una volta. Aggiungi l'immagine alla presentazione una volta, conserva l'oggetto [IPPImage](https://reference.aspose.com/slides/it/net/aspose.slides/ippimage/) restituito e utilizza quella risorsa immagine quando crei i picture frame.

I picture frame possono contenere immagini raster come PNG o JPEG e immagini vettoriali SVG. Possono anche fare riferimento a immagini collegate anziché memorizzare i byte dell'immagine nella presentazione. La scelta influenza la portabilità, la dimensione del file, l'estrazione e il comportamento di esportazione, perciò è utile decidere come l'immagine debba essere archiviata prima di applicare formattazioni o ottimizzazioni.

## **Aggiungere e formattare un'immagine incorporata**

Per un'immagine incorporata, aggiungi i dati dell'immagine alla presentazione e crea un picture frame con [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/it/net/aspose.slides/ishapecollection/addpictureframe/). L'immagine diventa parte del pacchetto della presentazione, così la presentazione rimane autonoma quando viene spostata su un altro computer.

L'esempio seguente aggiunge un'immagine JPEG, crea un frame con le dimensioni native dell'immagine e applica la formattazione della linea e la rotazione:

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 100, image.Width, image.Height, image);
pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
pictureFrame.LineFormat.Width = 3;
pictureFrame.Rotation = 15;

presentation.Save("picture-frame.pptx", SaveFormat.Pptx);
```

Il picture frame controlla la geometria visualizzata; modificare le dimensioni del frame non cambia le dimensioni pixel originali memorizzate nella risorsa immagine incorporata. Questa distinzione diventa importante quando si ritaglia o si comprime un'immagine in seguito.

## **Usare scala relativa**

[IPictureFrame](https://reference.aspose.com/slides/it/net/aspose.slides/ipictureframe/) espone la scalatura relativa di larghezza e altezza per il frame. Un valore di `1.0` corrisponde al 100 % della dimensione originale dell'immagine. La scala relativa è utile quando un flusso di lavoro deve mantenere una relazione con le dimensioni dell'immagine sorgente invece di calcolare manualmente le dimensioni finali.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);
pictureFrame.RelativeScaleWidth = 1.35f;
pictureFrame.RelativeScaleHeight = 0.8f;

presentation.Save("relative-scale.pptx", SaveFormat.Pptx);
```

La scala relativa modifica le impostazioni di scala del frame; non ricampiona né comprime l'immagine incorporata.

## **Immagini incorporate e collegate**

Un'immagine incorporata memorizza i dati dell'immagine all'interno della presentazione ed è quindi la scelta più sicura per la portabilità e la resa prevedibile. Un'immagine collegata memorizza un percorso esterno attraverso il percorso di collegamento [ISlidesPicture](https://reference.aspose.com/slides/it/net/aspose.slides/islidespicture/) invece di incorporare i dati dell'immagine nello stesso modo.

Le immagini collegate possono ridurre la quantità di dati immagine memorizzati nel PPTX, ma introducono una dipendenza esterna. Il file collegato deve rimanere accessibile all'applicazione che apre o rende la presentazione. Se il percorso cambia, il file viene spostato o la risorsa non è disponibile, il picture frame collegato potrebbe non essere visualizzato come previsto. Per presentazioni che devono essere inviate via e‑mail, archiviate o renderizzate in ambienti isolati, le immagini incorporate sono solitamente più affidabili.

### **Aggiungere un'immagine collegata**

L'esempio seguente crea un picture frame e lo punta a un file immagine locale. Gestisce solo il collegamento dell'immagine; il collegamento di video è un flusso di lavoro multimediale separato e non è intenzionalmente mescolato in questo esempio.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, null);
pictureFrame.PictureFormat.Picture.LinkPathLong = Path.GetFullPath("linked-image.jpg");

presentation.Save("linked-image.pptx", SaveFormat.Pptx);
```

Utilizza i collegamenti quando la gestione di file esterni è intenzionale. Non usarli semplicemente come sostituto della compressione: un PPTX piccolo con dipendenze immagine rotte è solitamente meno utile di una presentazione più grande e autonoma.

## **Estrarre immagini da picture frame**

Prima di estrarre un'immagine da una presentazione esistente, verifica che una forma sia davvero un [IPictureFrame](https://reference.aspose.com/slides/it/net/aspose.slides/ipictureframe/) e che contenga un'immagine incorporata. I picture frame collegati potrebbero non contenere byte dell'immagine estraibili allo stesso modo.

### **Estrarre un'immagine raster**

L'API immagine moderna utilizza direttamente [IImage](https://reference.aspose.com/slides/it/net/aspose.slides/iimage/) e non richiede il wrapper di sistema più vecchio. L'esempio seguente individua la prima immagine raster incorporata su una diapositiva e la salva come PNG:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IPictureFrame pictureFrame)
    {
        continue;
    }

    var embeddedImage = pictureFrame.PictureFormat.Picture.Image;
    if (embeddedImage == null || embeddedImage.SvgImage != null)
    {
        continue;
    }

    using var rasterImage = embeddedImage.Image;
    rasterImage.Save("extracted-image.png", Aspose.Slides.ImageFormat.Png);
    break;
}
```

Il salvataggio tramite [IImage](https://reference.aspose.com/slides/it/net/aspose.slides/iimage/) converte l'immagine estratta nel formato di output richiesto. Se ti servono i byte codificati memorizzati nella presentazione anziché un file raster convertito, usa i dati binari della risorsa immagine.

### **Estrarre un'immagine SVG**

Per un'immagine SVG, l'oggetto [IPPImage](https://reference.aspose.com/slides/it/net/aspose.slides/ippimage/) espone un oggetto [ISvgImage](https://reference.aspose.com/slides/it/net/aspose.slides/isvgimage/). Questo consente di recuperare direttamente i dati SVG invece di rasterizzare prima l'immagine.

```csharp
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IPictureFrame pictureFrame)
    {
        continue;
    }

    var embeddedImage = pictureFrame.PictureFormat.Picture.Image;
    var svgImage = embeddedImage?.SvgImage;
    if (svgImage == null)
    {
        continue;
    }

    File.WriteAllBytes("extracted-image.svg", svgImage.SvgData);
    break;
}
```

Mantenere il contenuto SVG come SVG conserva la sorgente vettoriale all'interno della presentazione. Le esportazioni raster come PNG o JPEG rendono necessariamente quel contenuto vettoriale in pixel. L'esportazione di diapositive in PDF o SVG è anch'essa un'operazione di rendering, quindi la grafica esportata non deve essere trattata come una copia byte‑per‑byte dell'SVG incorporato; usa i dati dell'[ISvgImage](https://reference.aspose.com/slides/it/net/aspose.slides/isvgimage/) incorporato quando è richiesto il vettoriale originale.

## **Ritagliare un'immagine**

Il ritaglio cambia quale parte di un'immagine è visibile all'interno del frame. I valori di ritaglio su [IPictureFillFormat](https://reference.aspose.com/slides/it/net/aspose.slides/ipicturefillformat/) sono percentuali delle dimensioni dell'immagine sorgente. Il ritaglio non elimina inizialmente i pixel nascosti dall'immagine incorporata; modifica solo la regione visibile.

L'esempio seguente individua in modo sicuro un picture frame e applica i valori di ritaglio:

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    pictureFrame.PictureFormat.CropLeft = 23.6f;
    pictureFrame.PictureFormat.CropRight = 21.5f;
    pictureFrame.PictureFormat.CropTop = 3f;
    pictureFrame.PictureFormat.CropBottom = 31f;
    presentation.Save("cropped-image.pptx", SaveFormat.Pptx);
}
```

Poiché i dati dell'immagine nascosti sono ancora presenti, il ritaglio può essere modificato in seguito senza perdere i pixel originali. Se la dimensione del file è più importante della reversibilità, le aree ritagliate possono essere rimosse fisicamente come descritto nella sezione successiva.

## **Rimuovere i dati dell'immagine ritagliata**

[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/it/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) rimuove i dati immagine al di fuori del rettangolo di ritaglio corrente e restituisce la risorsa immagine risultante. Questo può ridurre la dimensione del file, ma è un'ottimizzazione distruttiva: dopo il salvataggio della presentazione, i pixel rimossi non sono più disponibili per un'operazione di "un‑crop".

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("cropped-image.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var croppedImage = pictureFrame.PictureFormat.DeletePictureCroppedAreas();
    if (croppedImage != null)
    {
        presentation.Save("cropped-data-removed.pptx", SaveFormat.Pptx);
    }
}
```

Il metodo può aggiungere una nuova risorsa immagine alla presentazione. Se l'immagine originale è usata anche da altri picture frame, quei frame mantengono comunque la loro risorsa esistente, quindi eliminare le aree ritagliate non riduce necessariamente il numero totale di immagini. Il ritaglio di contenuti WMF o EMF con questo metodo rasterizza il risultato ritagliato in PNG.

## **Comprimere immagini raster**

[IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/it/net/aspose.slides/ipicturefillformat/compressimage/) riduce la risoluzione dell'immagine raster rispetto alla dimensione con cui l'immagine è visualizzata. Può anche rimuovere le aree ritagliate nella stessa operazione. Il metodo restituisce `true` quando l'immagine è stata ridimensionata o ritagliata e `false` quando non è stato necessario alcun cambiamento.

Usa un valore predefinito di [PicturesCompression](https://reference.aspose.com/slides/it/net/aspose.slides.export/picturescompression/) quando una risoluzione target standard è sufficiente:

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var compressed = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);
    Console.WriteLine(compressed ? "The image was compressed." : "No compression was necessary.");
    presentation.Save("compressed-image.pptx", SaveFormat.Pptx);
}
```

È possibile passare un valore DPI positivo personalizzato al posto di un valore enum quando è richiesto un target specifico.

La compressione è destinata alle immagini raster. Il contenuto SVG e metafile non viene ridotto da questo flusso di lavoro di compressione raster. Ricorda inoltre che una risoluzione più bassa e le regioni ritagliate eliminate non possono essere recuperate dalla presentazione ottimizzata. Scegli una risoluzione target basata sulla dimensione più grande con cui l'immagine sarà effettivamente visualizzata o esportata, anziché applicare il DPI più basso a livello globale.

## **Gestire gli effetti di trasformazione dell'immagine**

Per un flusso di lavoro completo che copra luminosità, contrasto, trasformazioni di colore, sfocatura, effetti alfa, catene ordinate, ispezione, rimozione e verifica round‑trip, vedere [Image Transform Effects](/slides/it/net/image-transform-effects/).

## **Bloccare la geometria del picture frame**

Le impostazioni di [IPictureFrameLock](https://reference.aspose.com/slides/it/net/aspose.slides/ipictureframelock/) controllano quali operazioni di modifica sono disabilitate per un picture frame. Ad esempio, il blocco del rapporto d’aspetto conserva le proporzioni della forma durante il ridimensionamento.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 100, image.Width, image.Height, image);
pictureFrame.PictureFrameLock.AspectRatioLocked = true;

presentation.Save("locked-picture-frame.pptx", SaveFormat.Pptx);
```

Il blocco si applica alla forma del picture frame. Non costringe l'immagine sorgente a essere ricampionata o modificata permanentemente per aderire allo stesso rapporto d’aspetto.

## **Regolare i valori StretchOffset**

Quando la modalità di riempimento dell'immagine è stretch, i valori stretch‑offset su [IPictureFillFormat](https://reference.aspose.com/slides/it/net/aspose.slides/ipicturefillformat/) definiscono il rettangolo di riempimento relativo al riquadro delimitante del picture frame. Percentuali positive creano un'inset da un bordo, mentre percentuali negative creano un outset.

Questo è diverso dal ritaglio. I valori di ritaglio selezionano quale parte dell'immagine sorgente è visibile; gli offset di stretch modificano il rettangolo in cui il riempimento immagine visibile viene allungato.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image);
pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
pictureFrame.PictureFormat.StretchOffsetLeft = 12f;
pictureFrame.PictureFormat.StretchOffsetRight = 12f;
pictureFrame.PictureFormat.StretchOffsetTop = 8f;
pictureFrame.PictureFormat.StretchOffsetBottom = 8f;

presentation.Save("stretch-offsets.pptx", SaveFormat.Pptx);
```

Usa gli offset di stretch per il posizionamento del riempimento. Usa le proprietà di ritaglio quando l’obiettivo è nascondere i bordi dell’immagine sorgente.

## **Considerazioni su archiviazione, dimensione file ed esportazione**

I principali compromessi sono più facili da gestire quando l'archiviazione delle immagini e la formattazione dei picture frame vengono trattati separatamente:

- **Immagini incorporate** rendono la presentazione autonoma e sono le più affidabili per la condivisione e il rendering lato server, ma le grandi immagini raster aumentano la dimensione del PPTX e l'uso della memoria.
- **Immagini collegate** possono mantenere il pacchetto più piccolo, ma la presentazione dipende dal fatto che i file esterni rimangano disponibili nei percorsi o nelle posizioni memorizzate.
- **Ritaglio** è inizialmente non distruttivo. I pixel nascosti rimangono incorporati finché le aree ritagliate non vengono esplicitamente eliminate o rimosse durante la compressione.
- **Compressione** può ridurre notevolmente la dimensione del file per immagini raster sovradimensionate, ma sacrifica la risoluzione sorgente. Deve essere applicata dopo aver definito la dimensione finale desiderata sulla diapositiva.
- **Immagini SVG** dovrebbero rimanere SVG quando la conservazione del vettoriale è importante. Estrai l'SVG incorporato direttamente quando ti serve la risorsa vettoriale stessa. Le esportazioni raster di diapositive convertono sempre la diapositiva resa in pixel.
- **Immagini ripetute** dovrebbero riutilizzare una risorsa [IPPImage](https://reference.aspose.com/slides/it/net/aspose.slides/ippimage/) esistente quando possibile, invece di caricare ripetutamente lo stesso file nel flusso di lavoro della presentazione.

Per presentazioni di grandi dimensioni, l'ottimizzazione delle immagini è solitamente più efficace quando effettuata in modo selettivo: mantieni loghi e diagrammi come contenuto vettoriale, comprimi le foto in base alla loro reale dimensione di visualizzazione, rimuovi i pixel ritagliati solo quando non è più necessario un successivo editing e evita i collegamenti esterni a meno che la gestione delle dipendenze non faccia parte del design di distribuzione.

## **FAQ**

**Qual è la differenza tra un picture frame e una risorsa immagine?**

Un [IPPImage](https://reference.aspose.com/slides/it/net/aspose.slides/ippimage/) rappresenta una risorsa immagine associata alla presentazione. Un [IPictureFrame](https://reference.aspose.com/slides/it/net/aspose.slides/ipictureframe/) è una forma su una diapositiva che visualizza un'immagine e memorizza geometria e formattazione a livello di frame, come dimensioni, rotazione, valori di ritaglio, effetti e blocchi.

**Devo incorporare o collegare le immagini?**

Incorpora le immagini quando la presentazione deve essere portabile, archiviata o renderizzata senza accesso a risorse esterne. Collega le immagini solo quando è intenzionale tenere i file immagine fuori dal PPTX e le posizioni esterne possono essere mantenute in modo affidabile.

**Il ritaglio riduce la dimensione del file PPTX?**

Non di per sé. Le impostazioni di ritaglio normale nascondono parti dell’immagine sorgente ma mantengono i pixel sottostanti. Usa [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/it/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) o la compressione dell’immagine con rimozione delle aree ritagliate quando quei pixel possono essere eliminati definitivamente.

**Posso ripristinare la qualità dell’immagine dopo la compressione?**

No. La compressione può ridurre la risoluzione raster memorizzata e la rimozione delle aree ritagliate elimina i dati immagine. Conserva l’immagine sorgente originale al di fuori della presentazione se in seguito potrebbe essere necessario un editing ad alta risoluzione.

**Come devo gestire le immagini SVG?**

Mantieni il contenuto SVG come SVG quando la fedeltà vettoriale è importante. L’[ISvgImage](https://reference.aspose.com/slides/it/net/aspose.slides/isvgimage/) incorporato può essere estratto direttamente. Renderizzare una diapositiva in un formato raster come PNG o JPEG rasterizza l’SVG come parte dell’immagine della diapositiva.

**Come posso evitare cast non sicuri durante la lettura di diapositive esistenti?**

Verifica il tipo di forma prima di utilizzare membri specifici del picture frame. Il pattern matching con [IPictureFrame](https://reference.aspose.com/slides/it/net/aspose.slides/ipictureframe/) o il filtrare la collezione delle forme per quell’interfaccia evita cast invalidi e consente al codice di gestire le diapositive che non contengono picture frame.