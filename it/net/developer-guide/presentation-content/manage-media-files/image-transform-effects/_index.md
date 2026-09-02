---
title: Gestire gli effetti di trasformazione immagine nelle presentazioni con .NET
linktitle: Effetti di trasformazione immagine
type: docs
weight: 11
url: /it/net/image-transform-effects/
keywords:
- trasformazione immagine
- effetto immagine
- luminosità
- contrasto
- scala di grigi
- duotono
- tinta
- HSL
- sostituzione colore
- sfocatura
- trasparenza
- effetto alpha
- catena di effetti
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Applica, concatena, ispeziona, rimuovi e verifica gli effetti di trasformazione immagine per i fotogrammi immagine con Aspose.Slides per .NET."
---
## **Panoramica**

Aspose.Slides rappresenta le regolazioni di immagine come una collezione ordinata di operazioni di trasformazione dell’immagine. Per un fotogramma immagine, partire dall’[ISlidesPicture](https://reference.aspose.com/slides/it/net/aspose.slides/islidespicture/) del fotogramma e accedere a [ISlidesPicture.ImageTransform](https://reference.aspose.com/slides/it/net/aspose.slides/islidespicture/imagetransform/). La [IImageTransformOperationCollection](https://reference.aspose.com/slides/it/net/aspose.slides.effects/iimagetransformoperationcollection/) restituita consente di aggiungere, enumerare, ispezionare, rimuovere e cancellare effetti senza riscrivere i byte dell’immagine originale.

Questo articolo mostra un flusso di lavoro completo per luminosità e contrasto, trasformazioni colore, sfocatura, trasparenza, catene di effetti ordinate, valori effettivi, rimozione e verifica round‑trip PPTX.

## **Comprendere la proprietà degli effetti e il riutilizzo dell’immagine**

Una risorsa immagine e l’immagine che la visualizza sono oggetti diversi:

- [IPPImage](https://reference.aspose.com/slides/it/net/aspose.slides/ippimage/) memorizza o fa riferimento ai dati immagine di origine appartenenti alla presentazione.
- [ISlidesPicture](https://reference.aspose.com/slides/it/net/aspose.slides/islidespicture/) appartiene a un riempimento immagine e fa riferimento a una risorsa immagine conservando la collezione di trasformazioni immagine.
- [IPictureFrame](https://reference.aspose.com/slides/it/net/aspose.slides/ipictureframe/) è la forma della diapositiva che possiede il relativo riempimento immagine, la geometria, le impostazioni di ritaglio e altre formattazioni a livello di fotogramma.

Perciò le operazioni di trasformazione immagine non modificano i byte in [IPPImage](https://reference.aspose.com/slides/it/net/aspose.slides/ippimage/). Quando lo stesso `IPPImage` viene passato a [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/it/net/aspose.slides/ishapecollection/addpictureframe/) più di una volta, ogni nuovo fotogramma immagine riceve il proprio `ISlidesPicture` e la propria collezione di trasformazioni. Applicare la scala di grigi a un fotogramma non rende gli altri fotogrammi in scala di grigi, anche se tutti riutilizzano la stessa risorsa immagine incorporata.

Il modello `ISlidesPicture.ImageTransform` è usato anche da altri riempimenti immagine, come una forma o lo sfondo della diapositiva. Gli esempi seguenti si concentrano sui fotogrammi immagine.

## **Usare intervalli di parametri validi e unità**

I metodi dimostrati usano i seguenti intervalli semantici e unità. Mantenere i valori in questi intervalli anche se una particolare versione della libreria non rifiuta immediatamente ogni valore fuori intervallo; il formato di destinazione della presentazione può normalizzare, omettere o rifiutare dati non validi durante il salvataggio o quando PowerPoint apre il file.

| Operazione | Parametri | Intervallo valido e unità |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/it/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | da `-100` a `100`, percentuale; `0` lascia il componente invariato. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/it/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | Nessuno | Nessun parametro numerico. Alpha rimane invariato. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/it/net/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Due colori per pixel scuri e chiari. I canali RGB e alpha in `System.Drawing.Color` usano valori da `0` a `255`. |
| [AddTintEffect](https://reference.aspose.com/slides/it/net/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Hue è compreso tra `0` (incluso) e `360` (escluso), in gradi; amount è da `-100` a `100`, percentuale. |
| [AddHSLEffect](https://reference.aspose.com/slides/it/net/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Hue è compreso tra `0` (incluso) e `360` (escluso), in gradi; saturation e luminance sono da `-100` a `100`, percentuale. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/it/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | Il colore di sostituzione usa valori di canale da `0` a `255`. I valori alpha esistenti rimangono invariati. |
| [AddBlurEffect](https://reference.aspose.com/slides/it/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Radius è non negativo e misurato in punti; `grow` è un Boolean che indica se il contenuto sfocato può estendersi oltre i limiti originali. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/it/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Percentuale non negativa. Usare `0`‑`100` per la normale scala di opacità: `0` è completamente trasparente e `100` preserva l’alpha esistente. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/it/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | Da `0` a `100`, percentuale di opacità. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/it/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | Da `0` a `100`, percentuale di soglia alpha. I valori inferiori diventano trasparenti; i valori uguali o superiori diventano opachi. |

Per la modulazione alpha fissa, trasparenza e opacità sono complementari. Per esempio, il 35 % di trasparenza corrisponde a una modulazione alpha del 65 %.

## **Applicare luminosità e contrasto**

[IImageTransformOperationCollection.AddBrightnessContrastEffect](https://reference.aspose.com/slides/it/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) restituisce un’operazione [IBrightnessContrast](https://reference.aspose.com/slides/it/net/aspose.slides.effects/ibrightnesscontrast/). Le impostazioni scalari sono fornite al momento della creazione dell’operazione. [IBrightnessContrast.GetEffective](https://reference.aspose.com/slides/it/net/aspose.slides.effects/brightnesscontrast/geteffective/) restituisce valori calcolati di sola lettura che possono essere ispezionati o registrati.

L’esempio seguente aumenta la luminosità del 15 % e il contrasto del 20 %, poi genera un’anteprima senza modificare l’immagine incorporata:

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
IBrightnessContrast brightnessContrast = imageTransform.AddBrightnessContrastEffect(15f, 20f);

var effectiveValues = brightnessContrast.GetEffective();
Console.WriteLine("Brightness: " + effectiveValues.Brightness + "%");
Console.WriteLine("Contrast: " + effectiveValues.Contrast + "%");

using var preview = slide.GetImage();
preview.Save("brightness-contrast-preview.png", ImageFormat.Png);
```

[BrightnessContrast](https://reference.aspose.com/slides/it/net/aspose.slides.effects/brightnesscontrast/) è un’estensione di effetto immagine Office 2010 e è meno portabile dell’effetto luminanza standard DrawingML. Quando luminosità e contrasto devono rimanere modificabili dopo un round‑trip PPTX, usare [IImageTransformOperationCollection.AddLuminanceEffect](https://reference.aspose.com/slides/it/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) e verificare il risultato dopo aver riaperto il file. La sezione sulle limitazioni di formato spiega questa distinzione in dettaglio.

## **Applicare trasformazioni colore**

Gli effetti colore possono essere applicati indipendentemente a diversi fotogrammi immagine che riutilizzano la stessa risorsa immagine. L’esempio seguente crea cinque fotogrammi e applica scala di grigi, duotono, tinta, regolazione HSL e sostituzione colore.

[IDuotone](https://reference.aspose.com/slides/it/net/aspose.slides.effects/iduotone/) contiene due parametri colore modificabili indipendentemente: `Color1` mappa i pixel scuri, mentre `Color2` mappa i pixel chiari. Questo lo rende un esempio utile di effetto le cui impostazioni sono più complesse di un singolo valore scalare.

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var grayFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
grayFrame.PictureFormat.Picture.ImageTransform.AddGrayScaleEffect();

var duotoneFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
var duotone = duotoneFrame.PictureFormat.Picture.ImageTransform.AddDuotoneEffect();
duotone.Color1.Color = Color.Navy;
duotone.Color2.Color = Color.Gold;

var tintFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
tintFrame.PictureFormat.Picture.ImageTransform.AddTintEffect(210f, 35f);

var hslFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
hslFrame.PictureFormat.Picture.ImageTransform.AddHSLEffect(30f, 20f, -10f);

var replacementFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
var colorReplacement = replacementFrame.PictureFormat.Picture.ImageTransform.AddColorReplaceEffect();
colorReplacement.Color.Color = Color.CornflowerBlue;

presentation.Save("color-transformations.pptx", SaveFormat.Pptx);
```

[AddColorReplaceEffect](https://reference.aspose.com/slides/it/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) sostituisce il colore di ogni pixel con un colore fisso preservando l’alpha. È diverso da [AddColorChangeEffect](https://reference.aspose.com/slides/it/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/), che mappa un colore sorgente a un altro e espone entrambi i formati colore sorgente e destinazione.

## **Aggiungere sfocatura, trasparenza ed effetti alpha**

[AddBlurEffect](https://reference.aspose.com/slides/it/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) interessa tutti i canali colore, incluso l’alpha. Impostare `grow` su `true` quando il bordo sfocato può estendersi oltre i limiti originali dell’immagine.

Per una trasparenza uniforme, usare [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/it/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/). Moltiplica ogni valore alpha esistente, quindi i pixel parzialmente trasparenti rimangono proporzionalmente diversi. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/it/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) assegna invece un unico valore alpha a tutti i pixel. [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/it/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) converte l’alpha in due livelli basati su una soglia.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var blurredFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image);
var blur = blurredFrame.PictureFormat.Picture.ImageTransform.AddBlurEffect(4.5, true);
blur.Radius = 5;

var transparentFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image);
var alphaModulate = transparentFrame.PictureFormat.Picture.ImageTransform.AddAlphaModulateFixedEffect(65f);
alphaModulate.Amount = 60f;

var uniformAlphaFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image);
uniformAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaReplaceEffect(55f);

var binaryAlphaFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image);
var alphaBiLevel = binaryAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaBiLevelEffect(50f);
alphaBiLevel.Threshold = 45f;
binaryAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaInverseEffect();

presentation.Save("blur-and-alpha-effects.pptx", SaveFormat.Pptx);
```

Altre operazioni alpha senza parametri includono [AddAlphaCeilingEffect](https://reference.aspose.com/slides/it/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/), che rende ogni alpha non zero completamente opaco; [AddAlphaFloorEffect](https://reference.aspose.com/slides/it/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/), che rende ogni alpha inferiore al 100 % completamente trasparente; e [AddAlphaInverseEffect](https://reference.aspose.com/slides/it/net/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/), che trasforma l’alpha in `100% - alpha`.

## **Costruire una catena di effetti ordinata**

Ogni metodo `Add...Effect` aggiunge una nuova operazione alla fine della collezione. Il renderer utilizza la collezione come una pipeline ordinata: l’output dell’operazione 0 diventa l’input dell’operazione 1 e così via. Di conseguenza, le stesse operazioni in ordine diverso possono produrre un’immagine diversa.

Ad esempio, scala di grigi seguita da tinta rimuove prima le informazioni cromatiche e poi ricola il risultato di luminanza. Tinta seguita da scala di grigi rimuove nuovamente la tinta. Analogamente, la sostituzione alpha può sovrascrivere i valori alpha calcolati dalle operazioni precedenti, mentre la modulazione alpha preserva le loro differenze relative.

L’esempio seguente crea una catena di quattro operazioni, la salva come PPTX, riapre la presentazione, verifica sia i tipi di operazione che il loro ordine e rende il risultato riaperto:

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
imageTransform.AddGrayScaleEffect();
imageTransform.AddTintEffect(220f, 25f);
imageTransform.AddBlurEffect(2.5, false);
imageTransform.AddAlphaModulateFixedEffect(80f);

presentation.Save("image-transform-chain.pptx", SaveFormat.Pptx);

using var reopenedPresentation = new Presentation("image-transform-chain.pptx");
var reopenedShape = reopenedPresentation.Slides[0].Shapes[0];

if (reopenedShape is IPictureFrame reopenedFrame)
{
    var reopenedTransform = reopenedFrame.PictureFormat.Picture.ImageTransform;
    var orderIsPreserved = reopenedTransform.Count == 4 && 
            reopenedTransform[0] is IGrayScale && 
            reopenedTransform[1] is ITint && 
            reopenedTransform[2] is IBlur && 
            reopenedTransform[3] is IAlphaModulateFixed;
    Console.WriteLine(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

    using var renderedSlide = reopenedPresentation.Slides[0].GetImage();
    renderedSlide.Save("reopened-effect-chain.png", ImageFormat.Png);
}
else
{
    Console.WriteLine("The reopened shape is not a picture frame.");
}
```

La collezione non impone una matrice di compatibilità che limiti operazioni colore, alpha e sfocatura a catene separate. Possono essere combinate, ma le combinazioni non sono sempre utili. Una sostituzione colore fissa elimina la variazione RGB prodotta da effetti colore precedenti; la scala di grigi dopo duotono elimina i due colori selezionati; e le operazioni alpha ceiling, floor, replacement o bi‑level possono scartare i dettagli alpha creati in precedenza. Costruire la catena secondo la sequenza di elaborazione dei pixel desiderata piuttosto che trattare gli elementi come flag di formattazione non ordinati.

## **Ispezionare valori modificabili ed efficaci**

Un’operazione modificabile è l’oggetto memorizzato in `ISlidesPicture.ImageTransform`. A seconda dell’effetto, può esporre membri scrivibili direttamente. Per esempio, [IBlur](https://reference.aspose.com/slides/it/net/aspose.slides.effects/iblur/) espone `Radius` e `Grow` scrivibili, [IAlphaModulateFixed](https://reference.aspose.com/slides/it/net/aspose.slides.effects/ialphamodulatefixed/) espone `Amount` scrivibile, e [IAlphaBiLevel](https://reference.aspose.com/slides/it/net/aspose.slides.effects/ialphabilevel/) espone `Threshold` scrivibile. Gli effetti colore come [IDuotone](https://reference.aspose.com/slides/it/net/aspose.slides.effects/iduotone/) espongono oggetti [IColorFormat](https://reference.aspose.com/slides/it/net/aspose.slides/icolorformat/) mutabili.

Alcune interfacce operazione, incluse [IBrightnessContrast](https://reference.aspose.com/slides/it/net/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/it/net/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/it/net/aspose.slides.effects/itint/), e [IAlphaReplace](https://reference.aspose.com/slides/it/net/aspose.slides.effects/ialphareplace/), non espongono i loro scalari di creazione come proprietà scrivibili. Per modificarli, rimuovere l’operazione e aggiungere una sostituzione nella posizione necessaria.

I dati effettivi restituiti da `GetEffective()` sono calcolati e di sola lettura. Sono utili per risolvere colori dipendenti dal tema e leggere i valori normalizzati che il renderer utilizza, ma non costituiscono un’altra superficie di modifica. L’esempio seguente enumera la catena e ispeziona i valori efficaci dove l’API corrispondente li fornisce:

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation("image-transform-chain.pptx");
var pictureFrame = presentation.Slides[0].Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;

    for (var index = 0; index < imageTransform.Count; index++)
    {
        var operation = imageTransform[index];
        Console.WriteLine(index + ": " + operation.GetType().Name);

        switch (operation)
        {
            case IBrightnessContrast brightnessContrast:
                var brightnessContrastData = brightnessContrast.GetEffective();
                Console.WriteLine("  Brightness: " + brightnessContrastData.Brightness);
                Console.WriteLine("  Contrast: " + brightnessContrastData.Contrast);
                break;
            case ILuminance luminance:
                var luminanceData = luminance.GetEffective();
                Console.WriteLine("  Brightness: " + luminanceData.Brightness);
                Console.WriteLine("  Contrast: " + luminanceData.Contrast);
                break;
            case IDuotone duotone:
                var duotoneData = duotone.GetEffective();
                Console.WriteLine("  Dark color: " + duotoneData.Color1);
                Console.WriteLine("  Light color: " + duotoneData.Color2);
                break;
            case IColorReplace colorReplace:
                var colorReplaceData = colorReplace.GetEffective();
                Console.WriteLine("  Replacement color: " + colorReplaceData.Color);
                break;
            case IHSL hsl:
                var hslData = hsl.GetEffective();
                Console.WriteLine("  HSL: " + hslData.Hue + ", " + hslData.Saturation + ", " + hslData.Luminance);
                break;
            case ITint tint:
                var tintData = tint.GetEffective();
                Console.WriteLine("  Tint: " + tintData.Hue + ", " + tintData.Amount);
                break;
            case IBlur blur:
                var blurData = blur.GetEffective();
                Console.WriteLine("  Blur radius: " + blurData.Radius + " pt");
                break;
            case IAlphaModulateFixed alphaModulate:
                var alphaData = alphaModulate.GetEffective();
                Console.WriteLine("  Alpha amount: " + alphaData.Amount + "%");
                break;
            case IAlphaReplace alphaReplace:
                var alphaReplaceData = alphaReplace.GetEffective();
                Console.WriteLine("  Replacement alpha: " + alphaReplaceData.Alpha + "%");
                break;
            case IAlphaBiLevel alphaBiLevel:
                var alphaBiLevelData = alphaBiLevel.GetEffective();
                Console.WriteLine("  Alpha threshold: " + alphaBiLevelData.Threshold + "%");
                break;
        }
    }
}
```

Gli effetti senza parametri come scala di grigi, alpha ceiling e alpha inverse hanno comunque un oggetto di dati efficaci, ma non ci sono impostazioni scalari da stampare. La loro presenza e posizione nella collezione sono le informazioni importanti.

## **Rimuovere o cancellare le trasformazioni immagine**

Usare [IImageTransformOperationCollection.RemoveAt](https://reference.aspose.com/slides/it/net/aspose.slides.effects/iimagetransformoperationcollection/removeat/) per rimuovere un’operazione per indice. Poiché gli indici cambiano dopo la rimozione, cercare prima il bersaglio e rimuoverlo dopo l’enumerazione. Usare `Clear()` per rimuovere l’intera catena.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

using var presentation = new Presentation("image-transform-chain.pptx");
var pictureFrame = presentation.Slides[0].Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    var blurIndex = -1;

    for (var index = 0; index < imageTransform.Count; index++)
    {
        if (imageTransform[index] is IBlur)
        {
            blurIndex = index;
            break;
        }
    }

    if (blurIndex >= 0)
    {
        imageTransform.RemoveAt(blurIndex);
        Console.WriteLine("The blur operation was removed.");
    }

    imageTransform.Clear();
    Console.WriteLine("Remaining operations: " + imageTransform.Count);
    presentation.Save("image-transforms-cleared.pptx", SaveFormat.Pptx);
}
```

Rimuovere o cancellare le trasformazioni modifica solo la formattazione dell’immagine. Non elimina, ricomprime o altera in altro modo la risorsa [IPPImage](https://reference.aspose.com/slides/it/net/aspose.slides/ippimage/) riutilizzata.

## **Considerare i formati di presentazione e le destinazioni di esportazione**

Le trasformazioni immagine hanno origine in DrawingML, quindi PPTX è il formato modificabile preferito per le catene di effetti. Anche con PPTX, non ogni operazione ha la stessa portabilità:

- Le operazioni DrawingML standard come luminanza, scala di grigi, duotono, tinta, HSL, sfocatura e operazioni alpha comuni hanno la migliore probabilità di sopravvivere a un round‑trip PPTX. Ri‑aprire sempre il file generato e ispezionare la collezione quando la conservazione è un requisito.
- [BrightnessContrast](https://reference.aspose.com/slides/it/net/aspose.slides.effects/brightnesscontrast/) è un’estensione Office 2010 piuttosto che l’operazione luminanza DrawingML standard. Può essere usata per il rendering in memoria, ma non è garantito che rimanga un [IBrightnessContrast](https://reference.aspose.com/slides/it/net/aspose.slides.effects/ibrightnesscontrast/) modificabile dopo il salvataggio e la riapertura di PPTX. Preferire [AddLuminanceEffect](https://reference.aspose.com/slides/it/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) per regolazioni di luminosità e contrasto persistenti.
- Il formato PPT binario precede il modello completo di effetti DrawingML. Il salvataggio in PPT può omettere operazioni non supportate, ridurre una catena a un sotto‑insieme supportato o approssimare l’aspetto. Non usare PPT come formato di verifica per una catena modificabile complessa.
- Il rendering in PNG, JPEG, TIFF, PDF, SVG, HTML o altri output visuali applica la catena supportata all’aspetto renderizzato. Questi output non contengono una collezione `IImageTransformOperationCollection` modificabile; i formati raster appiattiscono il risultato in pixel e le esportazioni documento/vettoriale memorizzano la loro propria rappresentazione di rendering.
- Gli effetti non rendono un’immagine collegata autonoma. Il rendering di un’immagine collegata dipende ancora dalla disponibilità della risorsa collegata al momento del caricamento della presentazione.

Diversi consumatori di presentazioni possono renderizzare casi limite in modo diverso, specialmente quando più operazioni alpha o di quantizzazione colore sono combinate. Per output critici, testare sia il round‑trip modificabile sia il formato di esportazione finale con la stessa versione di Aspose.Slides usata in produzione.

## **FAQ**

**Le trasformazioni immagine modificano i dati dell’immagine incorporata?**

No. Le operazioni appartengono al `ISlidesPicture` usato dal riempimento immagine. I byte sottostanti di `IPPImage` rimangono invariati.

**Due fotogrammi immagine che riutilizzano la stessa immagine condividono i loro effetti?**

No. Riutilizzare un `IPPImage` evita dati immagine duplicati, ma ogni fotogramma immagine ha normalmente un `ISlidesPicture` e una collezione di trasformazioni immagine separati.

**È possibile combinare effetti colore, sfocatura e alpha?**

Sì. La collezione li accetta in un’unica catena ordinata. Considerare cosa fa ogni operazione all’output della precedente perché le operazioni di sostituzione e soglia possono scartare dettagli colore o alpha precedenti.

**Perché i valori efficaci sono di sola lettura?**

I dati efficaci rappresentano i valori calcolati usati per il rendering, inclusi i colori risolti. Modificare l’operazione memorizzata nella collezione di trasformazioni dove esistono membri scrivibili; altrimenti rimuoverla e aggiungere una sostituzione con nuovi parametri di creazione.

**Quale formato usare per preservare una catena di trasformazioni?**

Usare PPTX e verificare il file ri‑aprendo. Il vecchio PPT non può rappresentare l’intero modello di effetti DrawingML, e i formati di esportazione renderizzati conservano solo l’aspetto, non le operazioni di trasformazione modificabili.