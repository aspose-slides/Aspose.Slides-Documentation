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
- effetto alfa
- catena di effetti
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Applica, concatena, ispeziona, rimuovi e verifica gli effetti di trasformazione immagine per i fotogrammi immagine con Aspose.Slides per .NET."
---
## **Panoramica**

Aspose.Slides rappresenta le regolazioni delle immagini come una raccolta ordinata di operazioni di trasformazione dell’immagine. Per un fotogramma immagine, inizi con il [ISlidesPicture](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/) del fotogramma e accedi a [ISlidesPicture.ImageTransform](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/imagetransform/). La [IImageTransformOperationCollection](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/) restituita consente di aggiungere, enumerare, ispezionare, rimuovere e cancellare gli effetti senza riscrivere i byte dell’immagine originale.

Questo articolo mostra un flusso di lavoro completo per luminosità e contrasto, trasformazioni di colore, sfocatura, trasparenza, catene di effetti ordinate, valori effettivi, rimozione e verifica del round‑trip PPTX.

## **Comprendere la Proprietà degli Effetti e il Riutilizzo delle Immagini**

- [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) memorizza o fa riferimento ai dati dell’immagine sorgente di proprietà della presentazione.  
- [ISlidesPicture](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/) appartiene a un riempimento immagine e fa riferimento a una risorsa immagine conservando la raccolta di trasformazioni dell’immagine.  
- [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/) è la forma della diapositiva che possiede il riempimento immagine pertinente, la geometria, le impostazioni di ritaglio e altri formati a livello di fotogramma.

Pertanto, le operazioni di trasformazione dell’immagine non modificano i byte in [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/). Quando lo stesso `IPPImage` viene passato a [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addpictureframe/) più di una volta, ogni nuovo fotogramma immagine riceve il proprio `ISlidesPicture` e la propria raccolta di trasformazioni. Applicare la scala di grigi a un fotogramma non rende gli altri fotogrammi in scala di grigi, anche se tutti riutilizzano la stessa risorsa immagine incorporata.

Lo stesso modello `ISlidesPicture.ImageTransform` è utilizzato anche da altri riempimenti immagine, come una forma o lo sfondo di una diapositiva. Gli esempi seguenti si concentrano sui fotogrammi immagine.

## **Usare Intervalli e Unità di Parametro Valide**

Le metodologie dimostrate usano i seguenti intervalli semantici e unità. Mantieni i valori in questi intervalli anche se una versione specifica della libreria non rifiuta immediatamente ogni valore fuori intervallo; il formato di destinazione della presentazione può normalizzare, omettere o rifiutare dati non validi durante il salvataggio o quando PowerPoint apre il file.

| Operazione | Parametri | Intervallo valido e unità |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` fino a `100`, percentuale; `0` lascia il componente invariato. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | Nessuno | Nessun parametro numerico. Alpha rimane invariato. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Due colori per pixel scuri e chiari. I canali RGB e alfa in `System.Drawing.Color` usano valori da `0` a `255`. |
| [AddTintEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | La tonalità (`hue`) è da `0` (incluso) a `360` (escluso), in gradi; l’intensità (`amount`) è da `-100` a `100`, percentuale. |
| [AddHSLEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | La tonalità è da `0` (incluso) a `360` (escluso), in gradi; saturazione e luminanza sono da `-100` a `100`, percentuale. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | Il colore di sostituzione utilizza valori di canale da `0` a `255`. I valori alfa esistenti rimangono invariati. |
| [AddBlurEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Il raggio è non negativo e viene misurato in punti; `grow` è un Booleano che controlla se il contenuto sfocato può estendersi al di fuori dei bordi originali. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Percentuale non negativa. Usa `0` a `100` per la scalatura abituale dell’opacità: `0` è completamente trasparente e `100` preserva l’alfa esistente. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` a `100`, percentuale di opacità. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` a `100`, percentuale di soglia alfa. I valori al di sotto diventano trasparenti; i valori uguali o superiori diventano opachi. |

Per la modulazione alfa fissa, trasparenza e opacità sono complementari. Per esempio, il 35 % di trasparenza corrisponde a un valore di modulazione alfa del 65 %.

## **Applicare Luminosità e Contrasto**

[IImageTransformOperationCollection.AddBrightnessContrastEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) restituisce un’operazione [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/). Le impostazioni scalari vengono fornite al momento della creazione dell’operazione. [IBrightnessContrast.GetEffective](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/geteffective/) restituisce valori calcolati in sola lettura che possono essere ispezionati o registrati.

L’esempio seguente aumenta la luminosità del 15 % e il contrasto del 20 %, quindi rende un’anteprima senza modificare l’immagine incorporata:

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

[BrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/) è un’estensione di effetto immagine di Office 2010 e risulta meno portabile dell’effetto luminanza standard di DrawingML. Quando luminosità e contrasto devono rimanere modificabili dopo un round‑trip PPTX, usa [IImageTransformOperationCollection.AddLuminanceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) e verifica il risultato dopo aver riaperto il file. La sezione sulle limitazioni del formato spiega questa distinzione in maggiore dettaglio.

## **Applicare Trasformazioni di Colore**

Gli effetti di colore possono essere applicati in modo indipendente a diversi fotogrammi immagine che riutilizzano una singola risorsa immagine. L’esempio seguente crea cinque fotogrammi e applica scala di grigi, duotono, tinta, aggiustamento HSL e sostituzione colore.

[IDuotone](https://reference.aspose.com/slides/net/aspose.slides.effects/iduotone/) contiene due parametri di colore modificabili indipendentemente: `Color1` mappa i pixel scuri, mentre `Color2` mappa i pixel chiari. Questo lo rende un esempio utile di effetto le cui impostazioni sono più complesse di un singolo valore scalare.

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

[AddColorReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) sostituisce il colore di ogni pixel con un colore fisso preservando l’alfa. È diverso da [AddColorChangeEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/), che mappa un colore sorgente a un altro e espone entrambi i formati colore sorgente e destinazione.

### **Applicare una Soglia di Luminanza**

Una soglia di luminanza può rendere più distinguibili i segni deboli su una pagina scansionata rispetto allo sfondo. [AddGrayScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) conserva le sfumature intermedie di grigio. [AddBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbileveleffect/) mappa la luminanza a nero o bianco, mentre [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) applica una soglia all’opacità.

La soglia di luminanza varia dallo 0 % al 100 %, inclusi. I pixel sotto la soglia diventano neri. I pixel uguali o superiori alla soglia diventano bianchi. Aumentare la soglia rende più sfumature nere perché più valori cadono sotto il limite.

Scarica [grayscale-swatches.png](grayscale-swatches.png) nella directory di lavoro. Ogni etichetta indica il livello di grigio originale su una scala da 0 a 255. L’esempio posiziona l’originale accanto a due copie e salva la soglia di ciascuna copia nella presentazione.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 150, SlideSizeScaleType.DoNotScale);
var shapes = presentation.Slides[0].Shapes;

var imageData = File.ReadAllBytes("grayscale-swatches.png");
var image = presentation.Images.AddImage(imageData);

IPictureFrame AddFrame(float x, string caption)
{
    shapes.AddAutoShape(ShapeType.Rectangle, x, 12, 216, 36).TextFrame.Text = caption;
    return shapes.AddPictureFrame(ShapeType.Rectangle, x, 60, 216, 72, image);
}

AddFrame(12, "Original");

var lowThreshold = AddFrame(252, "Threshold 20%");
lowThreshold.PictureFormat.Picture.ImageTransform.AddBiLevelEffect(20f);

var highThreshold = AddFrame(492, "Threshold 60%");
highThreshold.PictureFormat.Picture.ImageTransform.AddBiLevelEffect(60f);

presentation.Save("luminance-threshold.pptx", SaveFormat.Pptx);
```

Apri la presentazione di output in PowerPoint per confrontare i tre fotogrammi. Il campione etichettato 96 ha circa il 38 % di luminanza (96 su 255). Diventa bianco alla soglia del 20 % e nero alla soglia del 60 %.

![Campioni di scala di grigi originale accanto ai risultati in bianco‑nero alle soglie di luminanza del 20 % e del 60 %](luminance-threshold.png)

## **Aggiungere Effetti di Sfocatura, Trasparenza e Alfa**

[AddBlurEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) influisce su tutti i canali colore, incluso l’alfa. Imposta `grow` su `true` quando il bordo sfocato può estendersi oltre i limiti originali dell’immagine.

Per una trasparenza uniforme, usa [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/). Moltiplica ogni valore alfa esistente, così i pixel parzialmente trasparenti rimangono proporzionalmente diversi. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) invece assegna un unico valore alfa a tutti i pixel. [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) converte l’alfa a due livelli basati su una soglia.

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

Altre operazioni alfa senza parametri includono [AddAlphaCeilingEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/), che rende ogni alfa non zero completamente opaco; [AddAlphaFloorEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/), che rende ogni alfa inferiore al 100 % completamente trasparente; e [AddAlphaInverseEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/), che inverte l’alfa in `100 % - alpha`.

## **Costruire una Catena di Effetti Ordinata**

Ogni metodo `Add...Effect` aggiunge una nuova operazione alla fine della raccolta. Il renderer utilizza la raccolta come una pipeline ordinata: l’output dell’operazione 0 diventa l’input dell’operazione 1, e così via. Di conseguenza, le stesse operazioni in un ordine diverso possono produrre un’immagine differente.

Ad esempio, scala di grigi seguita da tinta rimuove prima le informazioni cromatiche e poi ricolia il risultato di luminanza. Tinta seguita da scala di grigi rimuove nuovamente la tinta. Analogamente, la sostituzione alfa può sovrascrivere i valori alfa calcolati dalle operazioni precedenti, mentre la modulazione alfa preserva le loro differenze relative.

L’esempio seguente costruisce una catena di quattro operazioni, la salva come PPTX, riapre la presentazione, verifica sia i tipi di operazione sia il loro ordine e rende il risultato riaperto:

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

La raccolta non impone una matrice di compatibilità che limiti operazioni colore, alfa e sfocatura a catene separate. Possono essere combinate, ma le combinazioni non sono sempre utili. Una sostituzione colore fissa rimuove la variazione RGB prodotta da effetti colore precedenti; la scala di grigi dopo duotono elimina i due colori selezionati; e le operazioni alfa ceiling, floor, replacement o bi‑level possono scartare i dettagli alfa creati in precedenza. Costruisci la catena secondo la sequenza di elaborazione pixel desiderata, piuttosto che trattare i singoli elementi come flag di formattazione non ordinati.

<!-- visual-explanation:image-transform-effects:start -->
[![La stessa immagine passa prima per scala di grigi poi per tinta, e viceversa. Le due immagini finali in scala di grigi hanno tonalità diverse.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*In questa illustrazione di Aspose.Slides for .NET 26.11, una tinta di 220° al 25 % lascia invariata l’immagine in scala di grigi. Applicare la stessa tinta prima della scala di grigi produce tonalità diverse.*
<!-- visual-explanation:image-transform-effects:end -->

## **Ispezionare Valori Modificabili ed Effettivi**

Un’operazione modificabile è l’oggetto memorizzato in `ISlidesPicture.ImageTransform`. A seconda dell’effetto, può esporre membri scrivibili direttamente. Per esempio, [IBlur](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/) espone `Radius` e `Grow` scrivibili, [IAlphaModulateFixed](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphamodulatefixed/) espone `Amount` scrivibile, e [IAlphaBiLevel](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphabilevel/) espone `Threshold` scrivibile. Gli effetti colore come [IDuotone](https://reference.aspose.com/slides/net/aspose.slides.effects/iduotone/) espongono oggetti [IColorFormat](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/) modificabili.

Alcune interfacce operazione, inclusi [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/net/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/net/aspose.slides.effects/itint/), e [IAlphaReplace](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphareplace/), non espongono i loro scalari di creazione come proprietà scrivibili. Per modificare tali impostazioni, rimuovi l’operazione e aggiungi una sostituzione nella posizione richiesta.

I dati effettivi restituiti da `GetEffective()` sono calcolati e di sola lettura. Sono utili per risolvere i colori dipendenti dal tema e per leggere i valori normalizzati usati dal renderer, ma non costituiscono un’altra superficie di modifica. L’esempio seguente enumera la catena e ispeziona i valori effettivi dove l’API corrispondente li fornisce:

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

Gli effetti senza parametri come scala di grigi, alpha ceiling e alpha inverse hanno comunque un oggetto dati effettivi, ma non esistono impostazioni scalari da stampare. La loro presenza e posizione nella raccolta sono le informazioni importanti.

## **Rimuovere o Cancellare le Trasformazioni dell'Immagine**

Usa [IImageTransformOperationCollection.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/removeat/) per rimuovere un’operazione per indice. Poiché gli indici cambiano dopo la rimozione, cerca prima il bersaglio e rimuovilo dopo l’enumerazione. Usa `Clear()` per rimuovere l’intera catena.

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

Rimuovere o cancellare le trasformazioni modifica solo la formattazione dell’immagine. Non elimina, ricomprime o altera in altro modo la risorsa [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) riutilizzata.

## **Considerare i Formati di Presentazione e i Target di Esportazione**

Le trasformazioni immagine originano in DrawingML, quindi PPTX è il formato modificabile preferito per le catene di effetti. Anche con PPTX, non tutte le operazioni hanno la stessa portabilità:

- Le operazioni standard di DrawingML come luminanza, scala di grigi, duotono, tinta, HSL, sfocatura e le comuni operazioni alfa hanno la migliore possibilità di sopravvivere a un round‑trip PPTX. Riapri sempre il file generato e ispeziona la raccolta quando la conservazione è un requisito.
- [BrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/) è un’estensione di Office 2010 anziché l’operazione luminanza standard di DrawingML. Può essere usata per il rendering in memoria, ma non è garantito che rimanga un [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/) modificabile dopo il salvataggio e la riapertura di PPTX. Preferisci [AddLuminanceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) per aggiustamenti di luminosità e contrasto persistenti.
- Il formato binario PPT precede il modello completo degli effetti DrawingML. Il salvataggio in PPT può omettere operazioni non supportate, ridurre una catena a un sottoinsieme supportato o approssimare l’aspetto. Non usare PPT come formato di verifica per una catena complessa e modificabile.
- Il rendering in PNG, JPEG, TIFF, PDF, SVG, HTML o altri output visivi applica la catena supportata all’aspetto renderizzato. tali output non contengono una `IImageTransformOperationCollection` modificabile; i formati raster appiattiscono il risultato in pixel, e le esportazioni documento/vettoriali memorizzano la propria rappresentazione di rendering.
- Gli effetti non rendono un’immagine collegata autonoma. Il rendering di un’immagine collegata dipende comunque dalla disponibilità della risorsa collegata al momento del caricamento della presentazione.

Diversi consumatori di presentazioni possono renderizzare i casi limite in modo diverso, specialmente quando più operazioni alfa o di quantizzazione colore sono combinate. Per output critici, testa sia il round‑trip modificabile sia il formato di esportazione finale con la stessa versione di Aspose.Slides usata in produzione.

## **FAQ**

**Le trasformazioni immagine modificano i dati dell’immagine incorporata?**

No. Le operazioni appartengono al `ISlidesPicture` usato dal riempimento immagine. I byte sottostanti di `IPPImage` rimangono invariati.

**Due fotogrammi immagine che riutilizzano la stessa immagine condivideranno i loro effetti?**

No. Riutilizzare un `IPPImage` evita dati immagine duplicati, ma ogni fotogramma immagine ha normalmente un proprio `ISlidesPicture` e una propria raccolta di trasformazioni dell’immagine.

**È possibile combinare effetti colore, sfocatura e alfa?**

Sì. La raccolta li accetta in una singola catena ordinata. Considera ciò che ogni operazione fa all’output della precedente, perché le operazioni di sostituzione e soglia possono scartare dettagli colore o alfa precedenti.

**Perché i valori effettivi sono di sola lettura?**

I dati effettivi rappresentano i valori calcolati usati per il rendering, inclusi i colori risolti. Modifica l’operazione memorizzata nella raccolta di trasformazioni dove esistono membri scrivibili; altrimenti rimuovila e aggiungi una sostituzione con nuovi parametri di creazione.

**Quale formato devo usare per preservare una catena di trasformazioni?**

Usa PPTX e verifica il file riaprendolo. Il vecchio PPT non può rappresentare l’intero modello di effetti DrawingML, e i formati di esportazione renderizzati preservano solo l’aspetto, non le operazioni di trasformazione modificabili.