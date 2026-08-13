---
title: Gestire i Frame Immagine nelle Presentazioni in .NET
linktitle: Frame Immagine
type: docs
weight: 10
url: /it/net/picture-frame/
keywords:
- frame immagine
- aggiungi frame immagine
- crea frame immagine
- aggiungi immagine
- crea immagine
- estrai immagine
- immagine raster
- immagine vettoriale
- ritaglia immagine
- area ritagliata
- proprietà StretchOff
- formattazione frame immagine
- proprietà frame immagine
- scala relativa
- effetto immagine
- rapporto d'aspetto
- trasparenza immagine
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Aggiungi frame immagine a presentazioni PowerPoint e OpenDocument con Aspose.Slides per .NET. Semplifica il tuo flusso di lavoro e migliora il design delle diapositive."
---
## **Introduzione**

Un frame immagine è una forma che contiene un’immagine—è come una foto incorniciata.

È possibile aggiungere un’immagine a una diapositiva tramite un frame immagine. In questo modo si formatta l’immagine formattando il frame immagine.

{{% alert title="Suggerimento" color="info" %}} 
Aspose fornisce convertitori gratuiti—[JPEG to PowerPoint](https://products.aspose.app/slides/it/import/jpg-to-ppt) e [PNG to PowerPoint](https://products.aspose.app/slides/it/import/png-to-ppt)—che consentono di creare presentazioni rapidamente a partire da immagini. 
{{% /alert %}} 

## **Creare un Frame Immagine**

1. Creare un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation). 
2. Ottenere il riferimento a una diapositiva tramite il suo indice. 
3. Creare un oggetto [IPPImage](https://reference.aspose.com/slides/it/net/aspose.slides/ippimage) aggiungendo un’immagine alla [IImagescollection](https://reference.aspose.com/slides/it/net/aspose.slides/iimagecollection) associata all’oggetto presentation che verrà usata per riempire la forma.  
4. Specificare la larghezza e l’altezza dell’immagine.  
5. Creare un [PictureFrame](https://reference.aspose.com/slides/it/net/aspose.slides/pictureframe) basato sulla larghezza e altezza dell’immagine tramite il metodo `AddPictureFrame` esposto dall’oggetto shape associato alla diapositiva di riferimento.  
6. Aggiungere un frame immagine (contenente l’immagine) alla diapositiva.  
7. Scrivere la presentazione modificata come file PPTX.  

Questo codice C# mostra come creare un frame immagine:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Istanzia la classe Presentation che rappresenta un file PPTX
using (Presentation pres = new Presentation())
{
    // Ottiene la prima diapositiva
    ISlide slide = pres.Slides[0];

    // Carica un'immagine e la aggiunge alla collezione di immagini della presentazione
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Aggiunge un frame immagine con la stessa altezza e larghezza
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Applica alcune formattazioni al frame immagine
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Scrive la presentazione in un file PPTX
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" %}} 
I frame immagine consentono di creare rapidamente diapositive basate su immagini. Quando si combina il frame immagine con le opzioni di salvataggio di Aspose.Slides, è possibile manipolare le operazioni di input/output per convertire le immagini da un formato all’altro. Potresti voler consultare queste pagine: convertire [image to JPG](https://products.aspose.com/slides/it/net/conversion/image-to-jpg/); convertire [JPG to image](https://products.aspose.com/slides/it/net/conversion/jpg-to-image/); convertire [JPG to PNG](https://products.aspose.com/slides/it/net/conversion/jpg-to-png/), convertire [PNG to JPG](https://products.aspose.com/slides/it/net/conversion/png-to-jpg/); convertire [PNG to SVG](https://products.aspose.com/slides/it/net/conversion/png-to-svg/), convertire [SVG to PNG](https://products.aspose.com/slides/it/net/conversion/svg-to-png/). 
{{% /alert %}}

## **Creare un Frame Immagine con Scala Relativa**

Modificando la scala relativa di un’immagine, è possibile creare un frame immagine più complesso. 

1. Creare un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).  
2. Ottenere il riferimento a una diapositiva tramite il suo indice.  
3. Aggiungere un’immagine alla collezione di immagini della presentazione.  
4. Creare un oggetto [IPPImage](https://reference.aspose.com/slides/it/net/aspose.slides/ippimage) aggiungendo un’immagine alla [IImagescollection](https://reference.aspose.com/slides/it/net/aspose.slides/iimagecollection) associata all’oggetto presentation che verrà usata per riempire la forma.  
5. Specificare la larghezza e l’altezza relative dell’immagine nel frame.  
6. Scrivere la presentazione modificata come file PPTX.  

Questo codice C# mostra come creare un frame immagine con scala relativa:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Istanzia la classe Presentation che rappresenta un file PPTX
using (Presentation presentation = new Presentation())
{
    // Carica un'immagine e la aggiunge alla collezione di immagini della presentazione
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Aggiunge un frame immagine alla diapositiva
    IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Imposta la larghezza e l'altezza della scala relativa
    pictureFrame.RelativeScaleHeight = 0.8f;
    pictureFrame.RelativeScaleWidth = 1.35f;

    // Salva la presentazione
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```

## **Estrarre Immagini Raster da Frame Immagine**

È possibile estrarre immagini raster da oggetti [PictureFrame](https://reference.aspose.com/slides/it/net/aspose.slides/pictureframe) e salvarle in PNG, JPG e altri formati. L’esempio di codice sottostante dimostra come estrarre un’immagine dal documento “sample.pptx” e salvarla in formato PNG.

```c#
using Aspose.Slides;

using (var presentation = new Presentation("sample.pptx"))
{
    var firstSlide = presentation.Slides[0];
    var firstShape = firstSlide.Shapes[0];

    if (firstShape is IPictureFrame pictureFrame)
    {
        var ppImage = pictureFrame.PictureFormat.Picture.Image;
        ppImage.Image.Save("slide_1_shape_1.png", ImageFormat.Png);
    }
}
```

## **Estrarre Immagini SVG da Frame Immagine**

Quando una presentazione contiene grafica SVG inserita in forme [PictureFrame](https://reference.aspose.com/slides/it/net/aspose.slides/pictureframe/), Aspose.Slides per .NET consente di recuperare le immagini vettoriali originali con piena fedeltà. Scorrendo la collezione di forme della diapositiva, è possibile identificare ogni [PictureFrame](https://reference.aspose.com/slides/it/net/aspose.slides/pictureframe/), verificare se l’[IPPImage](https://reference.aspose.com/slides/it/net/aspose.slides/ippimage/) sottostante contiene contenuto SVG e quindi salvare quell’immagine su disco o in uno stream nel suo formato SVG nativo.

Il seguente esempio di codice dimostra come estrarre un’immagine SVG da un frame immagine:

```cs
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

if (shape is IPictureFrame pictureFrame)
{
    var svgImage = pictureFrame.PictureFormat.Picture.Image.SvgImage;
    if (svgImage != null)
    {
        File.WriteAllText("output.svg", svgImage.SvgContent);
    }
}
```

## **Ottenere la Trasparenza di un’Immagine**

Aspose.Slides consente di ottenere l’effetto di trasparenza applicato a un’immagine. Questo codice C# dimostra l’operazione:

```c#
using Aspose.Slides;
using Aspose.Slides.Effects;

using (var presentation = new Presentation("Test.pptx"))
{
    var pictureFrame = (IPictureFrame)presentation.Slides[0].Shapes[0];
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    foreach (var effect in imageTransform)
    {
        if (effect is IAlphaModulateFixed alphaModulateFixed)
        {
            var transparencyValue = 100 - alphaModulateFixed.Amount;
            Console.WriteLine("Picture transparency: " + transparencyValue);
        }
    }
}
```

## **Ottenere Luminosità e Contrasto di un’Immagine**

Aspose.Slides consente di ottenere l’effetto di luminosità e contrasto applicato a un’immagine. L’interfaccia [ILuminance](https://reference.aspose.com/slides/it/net/aspose.slides.effects/iluminance/) rappresenta questo effetto di trasformazione dell’immagine.

Questo codice C# dimostra come ottenere le impostazioni di luminosità e contrasto da un frame immagine:

```csharp
using Aspose.Slides;
using Aspose.Slides.Effects;

using (var presentation = new Presentation("sample.pptx"))
{
    var slide = presentation.Slides[0];
    var shape = slide.Shapes[0];
    var pictureFrame = (IPictureFrame)shape;

    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    foreach (var effect in imageTransform)
    {
        if (effect is ILuminance luminanceEffect)
        {
            var luminance = luminanceEffect.GetEffective();
            var brightness = luminance.Brightness;
            var contrast = luminance.Contrast;

            Console.WriteLine("Brightness: " + brightness);
            Console.WriteLine("Contrast: " + contrast);
        }
    }
}
```

{{% alert color="info" %}} 
Tutti gli effetti applicati alle immagini sono disponibili in [Aspose.Slides.Effects](https://reference.aspose.com/slides/it/net/aspose.slides.effects/). 
{{% /alert %}}

## **Formattazione del Frame Immagine**

Aspose.Slides fornisce molte opzioni di formattazione che possono essere applicate a un frame immagine. Utilizzando queste opzioni, è possibile modificare un frame immagine per farlo corrispondere a requisiti specifici.

1. Creare un’istanza della classe [Presentation](http://www.aspose.com/api/net/slides/it/aspose.slides/).  
2. Ottenere il riferimento a una diapositiva tramite il suo indice.  
3. Creare un oggetto [IPPImage](https://reference.aspose.com/slides/it/net/aspose.slides/ippimage) aggiungendo un’immagine alla [IImagescollection](https://reference.aspose.com/slides/it/net/aspose.slides/iimagecollection) associata all’oggetto presentation che verrà usata per riempire la forma.  
4. Specificare la larghezza e l’altezza dell’immagine.  
5. Creare un `PictureFrame` basato sulla larghezza e altezza dell’immagine tramite il metodo [AddPictureFrame](http://www.aspose.com/api/net/slides/it/aspose.slides/ishapecollection/methods/addpictureframe) esposto dall’oggetto [IShapes](http://www.aspose.com/api/net/slides/it/aspose.slides/ishapecollection) associato alla diapositiva di riferimento.  
6. Aggiungere il frame immagine (contenente la foto) alla diapositiva.  
7. Impostare il colore del bordo del frame immagine.  
8. Impostare lo spessore del bordo del frame immagine.  
9. Ruotare il frame immagine fornendo un valore positivo o negativo.  
   * Un valore positivo ruota l’immagine in senso orario.  
   * Un valore negativo ruota l’immagine in senso antiorario.  
10. Aggiungere nuovamente il frame immagine (contenente la foto) alla diapositiva.  
11. Scrivere la presentazione modificata come file PPTX.  

Questo codice C# dimostra il processo di formattazione del frame immagine:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Istanzia la classe Presentation che rappresenta un file PPTX
using (Presentation presentation = new Presentation())
{
    // Ottiene la prima diapositiva
    ISlide slide = presentation.Slides[0];

    // Carica un'immagine e la aggiunge alla collezione di immagini della presentazione
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Aggiunge un frame immagine con l'altezza e larghezza equivalenti dell'immagine
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Applica alcune formattazioni al frame immagine
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Scrive la presentazione in un file PPTX
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}} 
Aspose ha recentemente sviluppato un [Collage Maker gratuito](https://products.aspose.app/slides/it/collage). Se devi [unire JPG/JPEG](https://products.aspose.app/slides/it/collage/jpg) o immagini PNG, [creare griglie da foto](https://products.aspose.app/slides/it/collage/photo-grid), puoi utilizzare questo servizio. 
{{% /alert %}}

## **Aggiungere un’Immagine come Link**

Per ridurre le dimensioni di una presentazione, è possibile aggiungere immagini (o video) tramite link anziché incorporare i file direttamente. Questo codice C# mostra come aggiungere un’immagine e un video in un segnaposto:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("input.pptx"))
{
    var shapesToRemove = new List<IShape>();
    int shapesCount = presentation.Slides[0].Shapes.Count;

    for (var i = 0; i < shapesCount; i++)
    {
        var autoShape = presentation.Slides[0].Shapes[i];

        if (autoShape.Placeholder == null)
        {
            continue;
        }

        switch (autoShape.Placeholder.Type)
        {
            case PlaceholderType.Picture:
                var pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle,
                        autoShape.X, autoShape.Y, autoShape.Width, autoShape.Height, null);

                pictureFrame.PictureFormat.Picture.LinkPathLong =
                    "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg";

                shapesToRemove.Add(autoShape);
                break;

            case PlaceholderType.Media:
                var videoFrame = presentation.Slides[0].Shapes.AddVideoFrame(
                    autoShape.X, autoShape.Y, autoShape.Width, autoShape.Height, "");

                videoFrame.PictureFormat.Picture.LinkPathLong =
                    "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg";

                videoFrame.LinkPathLong = "https://youtu.be/t_1LYZ102RA";

                shapesToRemove.Add(autoShape);
                break;
        }
    }

    foreach (var shape in shapesToRemove)
    {
        presentation.Slides[0].Shapes.Remove(shape);
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Ritagliare Immagini**

Questo codice C# mostra come ritagliare un’immagine esistente su una diapositiva:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    // Crea un nuovo oggetto immagine
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage newImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Aggiunge un PictureFrame a una diapositiva
    IPictureFrame picFrame = presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 100, 100, 420, 250, newImage);

    // Ritaglia l'immagine (valori percentuali)
    picFrame.PictureFormat.CropLeft = 23.6f;
    picFrame.PictureFormat.CropRight = 21.5f;
    picFrame.PictureFormat.CropTop = 3;
    picFrame.PictureFormat.CropBottom = 31;

    // Salva il risultato
    presentation.Save("PictureFrameCrop.pptx", SaveFormat.Pptx);
}
```

## **Eliminare le Aree Ritagliate di un Frame**

Se vuoi eliminare le aree ritagliate di un’immagine contenuta in un frame, puoi utilizzare il metodo [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/it/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/). Questo metodo restituisce l’immagine ritagliata o l’immagine originale se il ritaglio non è necessario.

Questo codice C# dimostra l’operazione:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Ottiene il PictureFrame dalla prima diapositiva
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // Elimina le aree ritagliate dell'immagine del PictureFrame e restituisce l'immagine ritagliata
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // Salva il risultato
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTA" color="warning" %}} 
Il metodo [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/it/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) aggiunge l’immagine ritagliata alla collezione di immagini della presentazione. Se l’immagine è utilizzata solo nel [PictureFrame](https://reference.aspose.com/slides/it/net/aspose.slides/pictureframe/) elaborato, questa impostazione può ridurre la dimensione della presentazione. Altrimenti, il numero di immagini nella presentazione risultante aumenterà.

Questo metodo converte i metafili WMF/EMF in immagini PNG raster durante l’operazione di ritaglio. 
{{% /alert %}}

## **Comprimere Immagini**

È possibile comprimere un’immagine in una presentazione utilizzando il metodo [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/it/net/aspose.slides/ipicturefillformat/compressimage/). Questo metodo comprime un’immagine riducendone le dimensioni in base alle dimensioni della forma e alla risoluzione specificata, con l’opzione di eliminare le aree ritagliate. 

Regola le dimensioni e la risoluzione dell’immagine in modo simile alla funzione di PowerPoint **Formato immagine → Comprime immagini → Risoluzione**.

I seguenti esempi C# mostrano come comprimere un’immagine in una presentazione specificando una risoluzione target e, facoltativamente, rimuovendo le aree ritagliate:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // Comprimi l'immagine con una risoluzione target di 150 DPI (risoluzione Web) e rimuovi le aree ritagliate.
    bool result = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);

    // Verifica il risultato della compressione.
    if (result)
    {
        Console.WriteLine("Image successfully compressed.");
    }
    else
    {
        Console.WriteLine("Image compression failed or no changes were necessary.");
    }

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

Oppure utilizzare direttamente un valore DPI personalizzato:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // Comprimi l'immagine a 150 DPI (risoluzione web), rimuovendo le aree ritagliate.
    pictureFrame.PictureFormat.CompressImage(true, 150f);

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTA" color="warning" %}} 
Il metodo converte l’immagine a una risoluzione inferiore in base alle dimensioni della forma e al DPI fornito. Le regioni ritagliate possono anche essere eliminate per ottimizzare la dimensione del file.  
Se l’immagine è un metafile (WMF/EMF) o SVG, la compressione non verrà applicata. Inoltre, la qualità JPEG viene preservata o leggermente ridotta in base alla risoluzione, come avviene in PowerPoint con JPEG ad alta risoluzione. 
{{% /alert %}}

## **Bloccare il Rapporto d’Aspetto**

Se vuoi che una forma contenente un’immagine mantenga il suo rapporto d’aspetto anche dopo aver modificato le dimensioni dell’immagine, puoi usare la proprietà [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/it/net/aspose.slides/ipictureframelock/aspectratiolocked/) per impostare l’opzione *Blocca rapporto d’aspetto*. 

Questo codice C# mostra come bloccare il rapporto d’aspetto di una forma:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // Imposta la forma per preservare il rapporto d'aspetto durante il ridimensionamento
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```

{{% alert title="NOTA" color="warning" %}} 
Questa impostazione *Blocca rapporto d’aspetto* preserva solo il rapporto d’aspetto della forma, non quello dell’immagine contenuta. 
{{% /alert %}}

## **Utilizzare la Proprietà StretchOff**

Usando le proprietà [StretchOffsetLeft](https://reference.aspose.com/slides/it/net/aspose.slides/picturefillformat/properties/stretchoffsetleft), [StretchOffsetTop](https://reference.aspose.com/slides/it/net/aspose.slides/picturefillformat/properties/stretchoffsettop), [StretchOffsetRight](https://reference.aspose.com/slides/it/net/aspose.slides/picturefillformat/properties/stretchoffsetright) e [StretchOffsetBottom](https://reference.aspose.com/slides/it/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) dell’interfaccia [IPictureFillFormat](https://reference.aspose.com/slides/it/net/aspose.slides/ipicturefillformat) e della classe [PictureFillFormat](https://reference.aspose.com/slides/it/net/aspose.slides/picturefillformat), è possibile specificare un rettangolo di riempimento. 

Quando è specificato lo stretching per un’immagine, un rettangolo di origine viene scalato per adattarsi al rettangolo di riempimento specificato. Ogni bordo del rettangolo di riempimento è definito da uno spostamento percentuale dal corrispondente bordo del riquadro della forma. Una percentuale positiva indica un rientro, una percentuale negativa un’estensione.  

1. Creare un’istanza della classe [Presentation](http://www.aspose.com/api/net/slides/it/aspose.slides/).  
2. Ottenere il riferimento a una diapositiva tramite il suo indice.  
3. Aggiungere un rettangolo `AutoShape`.  
4. Creare un’immagine.  
5. Impostare il tipo di riempimento della forma.  
6. Impostare la modalità di riempimento immagine della forma.  
7. Aggiungere l’immagine di riempimento alla forma.  
8. Specificare gli offset dell’immagine rispetto al corrispondente bordo del riquadro della forma.  
9. Scrivere la presentazione modificata come file PPTX.  

Questo codice C# dimostra un processo in cui viene utilizzata la proprietà StretchOff:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // Imposta l'immagine stirata da ciascun lato nel corpo della forma
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

### Come posso scoprire quali formati immagine sono supportati per PictureFrame?

Aspose.Slides supporta sia immagini raster (PNG, JPEG, BMP, GIF, ecc.) sia immagini vettoriali (ad esempio SVG) tramite l’oggetto immagine assegnato a un [PictureFrame](https://reference.aspose.com/slides/it/net/aspose.slides/pictureframe/). L’elenco dei formati supportati si sovrappone generalmente alle capacità del motore di conversione di diapositive e immagini.

### Come influiranno l’aggiunta di decine di immagini di grandi dimensioni sulla dimensione e sulle prestazioni del PPTX?

L’incorporamento di immagini grandi aumenta la dimensione del file e l’utilizzo di memoria; il collegamento delle immagini aiuta a mantenere ridotte le dimensioni della presentazione ma richiede che i file esterni rimangano accessibili. Aspose.Slides consente di aggiungere immagini tramite link per ridurre la dimensione del file.

### Come posso bloccare un oggetto immagine per evitare spostamenti o ridimensionamenti accidentali?

Usa i [bloccaggi forma](https://reference.aspose.com/slides/it/net/aspose.slides/pictureframe/pictureframelock/) per un [PictureFrame](https://reference.aspose.com/slides/it/net/aspose.slides/pictureframe/) (ad es., disabilitare lo spostamento o il ridimensionamento). Il meccanismo di blocco è descritto per le forme in un [articolo sulla protezione](/slides/it/net/applying-protection-to-presentation/) ed è supportato per vari tipi di forma, inclusi i [PictureFrame](https://reference.aspose.com/slides/it/net/aspose.slides/pictureframe/).

### La fedeltà vettoriale SVG è preservata quando si esporta una presentazione in PDF/immagini?

Aspose.Slides consente di estrarre un SVG da un [PictureFrame](https://reference.aspose.com/slides/it/net/aspose.slides/pictureframe/) come vettore originale. Quando si [esporta in PDF](/slides/it/net/convert-powerpoint-to-pdf/) o in [formati raster](/slides/it/net/convert-powerpoint-to-png/), il risultato può essere rasterizzato a seconda delle impostazioni di esportazione; il fatto che l’SVG originale sia memorizzato come vettore è confermato dal comportamento di estrazione.