---
title: Gestisci gli sfondi della presentazione in .NET
linktitle: Sfondo della diapositiva
type: docs
weight: 20
url: /it/net/presentation-background/
keywords:
- sfondo della presentazione
- sfondo della diapositiva
- colore solido
- colore a gradiente
- sfondo immagine
- trasparenza dello sfondo
- proprietà dello sfondo
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come impostare sfondi dinamici nei file PowerPoint e OpenDocument utilizzando Aspose.Slides per .NET, con consigli di codice per migliorare le tue presentazioni."
---
## **Introduzione**

I colori solidi, i gradienti e le immagini sono comunemente usati come sfondi delle diapositive. È possibile impostare lo sfondo per una **diapositiva normale** (una singola diapositiva) o per una **diapositiva master** (vale per più diapositive contemporaneamente).

![PowerPoint background](powerpoint-background.png)

## **Imposta uno sfondo a colore solido per una diapositiva normale**

Aspose.Slides consente di impostare un colore solido come sfondo per una diapositiva specifica in una presentazione, anche se la presentazione utilizza una diapositiva master. La modifica si applica solo alla diapositiva selezionata.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).
2. Imposta il [BackgroundType](https://reference.aspose.com/slides/it/net/aspose.slides/backgroundtype/) della diapositiva su `OwnBackground`.
3. Imposta il [FillType](https://reference.aspose.com/slides/it/net/aspose.slides/filltype/) dello sfondo della diapositiva su `Solid`.
4. Utilizza la proprietà [SolidFillColor](https://reference.aspose.com/slides/it/net/aspose.slides/fillformat/solidfillcolor/) su [FillFormat](https://reference.aspose.com/slides/it/net/aspose.slides/fillformat/) per specificare il colore solido dello sfondo.
5. Salva la presentazione modificata.

Il seguente esempio C# mostra come impostare un colore solido blu come sfondo per una diapositiva normale:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Crea un'istanza della classe Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Imposta il colore di sfondo della diapositiva su blu.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Blue;

    // Salva la presentazione su disco.
    presentation.Save("SolidColorBackground.pptx", SaveFormat.Pptx);
}
```

## **Imposta uno sfondo a colore solido per una diapositiva master**

Aspose.Slides consente di impostare un colore solido come sfondo per la diapositiva master in una presentazione. La diapositiva master funge da modello che controlla la formattazione di tutte le diapositive, quindi quando scegli un colore solido per lo sfondo della diapositiva master, questo viene applicato a ogni diapositiva.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).
2. Imponi il [BackgroundType](https://reference.aspose.com/slides/it/net/aspose.slides/backgroundtype/) della diapositiva master (tramite `masters`) su `OwnBackground`.
3. Imposta il [FillType](https://reference.aspose.com/slides/it/net/aspose.slides/filltype/) dello sfondo della diapositiva master su `Solid`.
4. Utilizza la proprietà [SolidFillColor](https://reference.aspose.com/slides/it/net/aspose.slides/fillformat/solidfillcolor/) per specificare il colore solido dello sfondo.
5. Salva la presentazione modificata.

Il seguente esempio C# mostra come impostare un colore solido (verde foresta) come sfondo per una diapositiva master:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Crea un'istanza della classe Presentation.
using (Presentation presentation = new Presentation())
{
    IMasterSlide masterSlide = presentation.Masters[0];

    // Imposta il colore di sfondo per la diapositiva Master su Verde foresta.
    masterSlide.Background.Type = BackgroundType.OwnBackground;
    masterSlide.Background.FillFormat.FillType = FillType.Solid;
    masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

    // Salva la presentazione su disco.
    presentation.Save("MasterSlideBackground.pptx", SaveFormat.Pptx);
}
```

## **Imposta uno sfondo a gradiente per una diapositiva**

Un gradiente è un effetto grafico creato da un cambiamento graduale del colore. Quando usato come sfondo di una diapositiva, i gradienti possono rendere le presentazioni più artistiche e professionali. Aspose.Slides consente di impostare un colore a gradiente come sfondo per le diapositive.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).
2. Imposta il [BackgroundType](https://reference.aspose.com/slides/it/net/aspose.slides/backgroundtype/) della diapositiva su `OwnBackground`.
3. Imposta il [FillType](https://reference.aspose.com/slides/it/net/aspose.slides/filltype/) dello sfondo della diapositiva su `Gradient`.
4. Utilizza la proprietà [GradientFormat](https://reference.aspose.com/slides/it/net/aspose.slides/fillformat/gradientformat/) su [FillFormat](https://reference.aspose.com/slides/it/net/aspose.slides/fillformat/) per configurare le impostazioni del gradiente desiderate.
5. Salva la presentazione modificata.

Il seguente esempio C# mostra come impostare un colore a gradiente come sfondo per una diapositiva:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Crea un'istanza della classe Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Applica un effetto a gradiente allo sfondo.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Gradient;
    slide.Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;

    // Salva la presentazione su disco.
    presentation.Save("GradientBackground.pptx", SaveFormat.Pptx);
}
```

## **Imposta un'immagine come sfondo della diapositiva**

Oltre a riempimenti solidi e a gradiente, Aspose.Slides consente di utilizzare immagini come sfondi delle diapositive.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).
2. Imposta il [BackgroundType](https://reference.aspose.com/slides/it/net/aspose.slides/backgroundtype/) della diapositiva su `OwnBackground`.
3. Imposta il [FillType](https://reference.aspose.com/slides/it/net/aspose.slides/filltype/) dello sfondo della diapositiva su `Picture`.
4. Carica l'immagine da usare come sfondo della diapositiva.
5. Aggiungi l'immagine alla raccolta di immagini della presentazione.
6. Utilizza la proprietà [PictureFillFormat](https://reference.aspose.com/slides/it/net/aspose.slides/fillformat/picturefillformat/) su [FillFormat](https://reference.aspose.com/slides/it/net/aspose.slides/fillformat/) per assegnare l'immagine come sfondo.
7. Salva la presentazione modificata.

Il seguente esempio C# mostra come impostare un'immagine come sfondo per una diapositiva:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Crea un'istanza della classe Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Imposta le proprietà dell'immagine di sfondo.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Picture;
    slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

    // Carica l'immagine.
    IImage image = Images.FromFile("Tulips.jpg");
    // Aggiungi l'immagine alla raccolta di immagini della presentazione.
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    slide.Background.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // Salva la presentazione su disco.
    presentation.Save("ImageAsBackground.pptx", SaveFormat.Pptx);
}
```

Il seguente esempio di codice mostra come impostare il tipo di riempimento dello sfondo su un'immagine mosaico e modificare le proprietà di piastrellatura:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide firstSlide = presentation.Slides[0];

    IBackground background = firstSlide.Background;

    background.Type = BackgroundType.OwnBackground;
    background.FillFormat.FillType = FillType.Picture;

    IPPImage ppImage;
    using (IImage newImage = Aspose.Slides.Images.FromFile("image.png"))
        ppImage = presentation.Images.AddImage(newImage);

    // Imposta l'immagine usata per il riempimento di sfondo.
    IPictureFillFormat backPictureFillFormat = background.FillFormat.PictureFillFormat;
    backPictureFillFormat.Picture.Image = ppImage;

    // Imposta la modalità di riempimento immagine su Tile e regola le proprietà della piastrella.
    backPictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    backPictureFillFormat.TileOffsetX = 15f;
    backPictureFillFormat.TileOffsetY = 15f;
    backPictureFillFormat.TileScaleX = 46f;
    backPictureFillFormat.TileScaleY = 87f;
    backPictureFillFormat.TileAlignment = RectangleAlignment.Center;
    backPictureFillFormat.TileFlip = TileFlip.FlipY;

    presentation.Save("TileBackground.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}}
Leggi di più: [**Tile Picture As Texture**](/slides/it/net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Modifica la trasparenza dell'immagine di sfondo**

Potresti voler regolare la trasparenza dell'immagine di sfondo di una diapositiva per far risaltare i contenuti della diapositiva. Il seguente codice C# mostra come modificare la trasparenza dell'immagine di sfondo di una diapositiva:

```cs
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

var transparencyValue = 30; // Ad esempio.

using (Presentation presentation = new Presentation("ImageAsBackground.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Ottieni la raccolta delle operazioni di trasformazione dell'immagine.
    var imageTransform = slide.Background.FillFormat.PictureFillFormat.Picture.ImageTransform;

    // Trova un effetto di trasparenza a percentuale fissa esistente.
    var transparencyOperation = null as IAlphaModulateFixed;
    foreach (var operation in imageTransform)
    {
        if (operation is IAlphaModulateFixed alphaModulateFixed)
        {
            transparencyOperation = alphaModulateFixed;
            break;
        }
    }

    // Imposta il nuovo valore di trasparenza.
    if (transparencyOperation == null)
    {
        imageTransform.AddAlphaModulateFixedEffect(100 - transparencyValue);
    }
    else
    {
        transparencyOperation.Amount = (100 - transparencyValue);
    }

    presentation.Save("ImageBackgroundTransparency.pptx", SaveFormat.Pptx);
}
```

## **Ottieni il valore dello sfondo della diapositiva**

Aspose.Slides fornisce l'interfaccia [IBackgroundEffectiveData](https://reference.aspose.com/slides/it/net/aspose.slides/ibackgroundeffectivedata/) per recuperare i valori effettivi dello sfondo di una diapositiva. Questa interfaccia espone il [FillFormat](https://reference.aspose.com/slides/it/net/aspose.slides/ibackgroundeffectivedata/fillformat/) e l'[EffectFormat](https://reference.aspose.com/slides/it/net/aspose.slides/ibackgroundeffectivedata/effectformat/) effettivi.

Utilizzando la proprietà `background` della classe [BaseSlide](https://reference.aspose.com/slides/it/net/aspose.slides/baseslide/), è possibile ottenere lo sfondo efficace per una diapositiva.

Il seguente esempio C# mostra come ottenere il valore effettivo dello sfondo di una diapositiva:

```cs
using Aspose.Slides;

// Crea un'istanza della classe Presentation.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    ISlide slide = presentation.Slides[0];  

    // Recupera lo sfondo efficace, tenendo conto di master, layout e tema.
    IBackgroundEffectiveData effBackground = slide.Background.GetEffective();

    if (effBackground.FillFormat.FillType == FillType.Solid)
        Console.WriteLine("Fill color: " + effBackground.FillFormat.SolidFillColor);
    else
        Console.WriteLine("Fill type: " + effBackground.FillFormat.FillType);
}
```

## **FAQ**

### **Posso ripristinare uno sfondo personalizzato e recuperare lo sfondo del tema/layout?**

Sì. Rimuovi il riempimento personalizzato della diapositiva e lo sfondo verrà nuovamente ereditato dalla diapositiva [layout](/slides/it/net/slide-layout/)/[master](/slides/it/net/slide-master/) corrispondente (cioè dallo [sfondo del tema](/slides/it/net/presentation-theme/)).

### **Cosa succede allo sfondo se cambio successivamente il tema della presentazione?**

Se una diapositiva ha un proprio riempimento, rimarrà invariato. Se lo sfondo è ereditato dal [layout](/slides/it/net/slide-layout/)/[master](/slides/it/net/slide-master/), verrà aggiornato per corrispondere al [nuovo tema](/slides/it/net/presentation-theme/).