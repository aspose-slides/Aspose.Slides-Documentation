---
title: Gestire gli effetti di trasformazione immagini nelle presentazioni con C++
linktitle: Effetti di trasformazione immagini
type: docs
weight: 11
url: /it/cpp/image-transform-effects/
keywords:
- trasformazione immagine
- effetto immagine
- luminosità
- contrasto
- scala di grigi
- duotone
- tinta
- HSL
- sostituzione colore
- sfocatura
- trasparenza
- effetto alfa
- catena di effetti
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Applica, concatena, ispeziona, rimuovi e verifica gli effetti di trasformazione immagine per i riquadri immagine con Aspose.Slides per C++."
---
## **Panoramica**

Aspose.Slides rappresenta le regolazioni dell’immagine come una collezione ordinata di operazioni di trasformazione dell’immagine. Per un riquadro immagine, inizi con il [ISlidesPicture](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/) e accedi a [ISlidesPicture::get_ImageTransform](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/get_imagetransform/). La [IImageTransformOperationCollection](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/) restituita consente di aggiungere, enumerare, ispezionare, rimuovere e cancellare gli effetti senza riscrivere i byte dell’immagine originale.

Questo articolo dimostra un flusso di lavoro completo per luminosità e contrasto, trasformazioni di colore, sfocatura, trasparenza, catene di effetti ordinate, valori effettivi, rimozione e verifica del round‑trip PPTX.

## **Comprendere la proprietà degli effetti e il riutilizzo delle immagini**

- [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) memorizza o fa riferimento ai dati immagine sorgente di proprietà della presentazione.  
- [ISlidesPicture](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/) appartiene a un riempimento immagine e si riferisce a una risorsa immagine mentre memorizza la collezione di trasformazioni dell’immagine.  
- [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/) è la forma della diapositiva che possiede il relativo riempimento immagine, la geometria, le impostazioni di ritaglio e altre formattazioni a livello di riquadro.  

Quindi, le operazioni di trasformazione dell’immagine non modificano i byte in [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/). Quando lo stesso `IPPImage` viene passato a [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addpictureframe/) più di una volta, ogni nuovo riquadro immagine riceve il proprio `ISlidesPicture` e la propria collezione di trasformazioni. Applicare la scala di grigi a un riquadro non rende gli altri riquadri in scala di grigi, anche se tutti riutilizzano la stessa risorsa immagine incorporata.

Lo stesso modello `ISlidesPicture::get_ImageTransform` è utilizzato anche da altri riempimenti immagine, come una forma o lo sfondo della diapositiva. Gli esempi seguenti si concentrano sui riquadri immagine.

## **Utilizzare intervalli di parametri e unità validi**

| Operazione | Parametri | Intervallo valido e unità |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` through `100`, percent; `0` leaves the component unchanged. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | Nessuno | No numeric parameters. Alpha is unchanged. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Two colors for dark and light pixels. RGB and alpha channels in `System::Drawing::Color` use `0` through `255`. |
| [AddTintEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Hue is `0` inclusive through `360` exclusive, in degrees; amount is `-100` through `100`, percent. |
| [AddHSLEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Hue is `0` inclusive through `360` exclusive, in degrees; saturation and luminance are `-100` through `100`, percent. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | The replacement color uses channel values from `0` through `255`. Existing alpha values are unchanged. |
| [AddBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Radius is nonnegative and is measured in points; `grow` controls whether blurred content may extend outside the original bounds. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Nonnegative percent. Use `0` through `100` for ordinary opacity scaling: `0` is fully transparent and `100` preserves the existing alpha. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` through `100`, percent opacity. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` through `100`, percent alpha threshold. Values below it become transparent; values at or above it become opaque. |

Per la modulazione alfa fissa, trasparenza e opacità sono complementari. Ad esempio, il 35% di trasparenza corrisponde a un valore di modulazione alfa del 65%.

## **Applicare luminosità e contrasto**

[IImageTransformOperationCollection::AddBrightnessContrastEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) restituisce un'operazione [IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/). Le impostazioni scalar vengono fornite al momento della creazione dell'operazione. Il metodo `IBrightnessContrast::GetEffective` restituisce valori calcolati di sola lettura che possono essere ispezionati o registrati.

L'esempio seguente aumenta la luminosità del 15% e il contrasto del 20%, quindi genera un'anteprima senza modificare l'immagine incorporata:

```cpp
#include <DOM/Effects/IBrightnessContrast.h>
#include <DOM/Effects/IBrightnessContrastEffectiveData.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 50.0f, 400.0f, 260.0f, image);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
auto brightnessContrast = imageTransform->AddBrightnessContrastEffect(15.0f, 20.0f);

auto effectiveValues = brightnessContrast->GetEffective();
Console::WriteLine(u"Brightness: {0}%", effectiveValues->get_Brightness());
Console::WriteLine(u"Contrast: {0}%", effectiveValues->get_Contrast());

auto preview = slide->GetImage();
preview->Save(u"brightness-contrast-preview.png", ImageFormat::Png);

presentation->Dispose();
```

[BrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/brightnesscontrast/) è un’estensione di effetto immagine di Office 2010 ed è meno portabile dell’effetto luminanza standard di DrawingML. Quando luminosità e contrasto devono rimanere modificabili dopo un round‑trip PPTX, utilizzare [IImageTransformOperationCollection::AddLuminanceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) e verificare il risultato dopo aver riaperto il file. La sezione limitazioni del formato spiega questa distinzione più in dettaglio.

## **Applicare trasformazioni di colore**

Gli effetti di colore possono essere applicati in modo indipendente a diversi riquadri immagine che riutilizzano una risorsa immagine. L'esempio seguente crea cinque riquadri e applica scala di grigi, duotone, tinta, regolazione HSL e sostituzione colore.

[IDuotone](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iduotone/) contiene due parametri colore modificabili indipendentemente: `get_Color1` mappa i pixel scuri, mentre `get_Color2` mappa i pixel chiari. Questo lo rende un esempio utile di effetto le cui impostazioni sono più complesse di un singolo valore scalare.

```cpp
#include <DOM/Effects/IColorReplace.h>
#include <DOM/Effects/IDuotone.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IColorFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto grayFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 180.0f, 120.0f, image);
grayFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddGrayScaleEffect();

auto duotoneFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 220.0f, 20.0f, 180.0f, 120.0f, image);
auto duotone = duotoneFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddDuotoneEffect();
duotone->get_Color1()->set_Color(Color::get_Navy());
duotone->get_Color2()->set_Color(Color::get_Gold());

auto tintFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 420.0f, 20.0f, 180.0f, 120.0f, image);
tintFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddTintEffect(210.0f, 35.0f);

auto hslFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 120.0f, 170.0f, 180.0f, 120.0f, image);
hslFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddHSLEffect(30.0f, 20.0f, -10.0f);

auto replacementFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 320.0f, 170.0f, 180.0f, 120.0f, image);
auto colorReplacement = replacementFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddColorReplaceEffect();
colorReplacement->get_Color()->set_Color(Color::get_CornflowerBlue());

presentation->Save(u"color-transformations.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

[AddColorReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) sostituisce il colore di ogni pixel con un colore fisso mantenendo l'alpha. È diverso da [AddColorChangeEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/), che mappa un colore sorgente a un altro e espone entrambi i formati colore sorgente e destinazione.

### **Applicare una soglia di luminanza**

Una soglia di luminanza può rendere più facili da distinguere i segni deboli su una pagina scansionata dallo sfondo. [AddGrayScaleEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) conserva le sfumature intermedie di grigio. [AddBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbileveleffect/) mappa la luminanza a nero o bianco, mentre [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) applica una soglia all'opacità.

La soglia di luminanza varia dallo 0% al 100%, inclusi. I pixel sotto la soglia diventano neri. I pixel uguali o sopra la soglia diventano bianchi. Incrementare la soglia rende più sfumature nere perché più di esse ricadono sotto il limite.

Scarica [grayscale-swatches.png](grayscale-swatches.png) nella directory di lavoro. Ogni etichetta indica il livello di grigio originale su una scala da 0 a 255. L’esempio posiziona l’originale accanto a due copie e salva la soglia di ciascuna copia nella presentazione.

```cpp
#include <DOM/Effects/IBiLevel.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 150, SlideSizeScaleType::DoNotScale);
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto imageData = File::ReadAllBytes(u"grayscale-swatches.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto addFrame = [&](float x, const String& caption)
{
    auto label = shapes->AddAutoShape(ShapeType::Rectangle, x, 12, 216, 36);
    label->get_TextFrame()->set_Text(caption);
    return shapes->AddPictureFrame(ShapeType::Rectangle, x, 60, 216, 72, image);
};

addFrame(12, u"Original");

auto lowThreshold = addFrame(252, u"Threshold 20%");
lowThreshold->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddBiLevelEffect(20.0f);

auto highThreshold = addFrame(492, u"Threshold 60%");
highThreshold->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddBiLevelEffect(60.0f);

presentation->Save(u"luminance-threshold.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Apri la presentazione di output in PowerPoint per confrontare i tre riquadri. Il campione etichettato 96 ha circa il 38% di luminanza (96 su 255). Diventa bianco alla soglia del 20% e nero alla soglia del 60%.

![Campioni di scala di grigi originali accanto ai risultati in bianco‑nero alle soglie di luminanza del 20% e del 60%](luminance-threshold.png)

## **Aggiungere sfocatura, trasparenza e effetti alfa**

[AddBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) influisce su tutti i canali colore, compreso alfa. Imposta `grow` a `true` quando il bordo sfocato può estendersi oltre i limiti dell’immagine originale.

Per una trasparenza uniforme, utilizzare [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/). Moltiplica ogni valore alfa esistente, così i pixel parzialmente trasparenti rimangono proporzionalmente diversi. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) assegna invece un unico valore alfa a tutti i pixel. [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) converte l’alfa in due livelli basati su una soglia.

```cpp
#include <DOM/Effects/IAlphaBiLevel.h>
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto blurredFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 200.0f, 140.0f, image);
auto blur = blurredFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddBlurEffect(4.5, true);
blur->set_Radius(5.0);

auto transparentFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 240.0f, 20.0f, 200.0f, 140.0f, image);
auto alphaModulate = transparentFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddAlphaModulateFixedEffect(65.0f);
alphaModulate->set_Amount(60.0f);

auto uniformAlphaFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 180.0f, 200.0f, 140.0f, image);
uniformAlphaFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddAlphaReplaceEffect(55.0f);

auto binaryAlphaFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 240.0f, 180.0f, 200.0f, 140.0f, image);
auto binaryAlphaTransform = binaryAlphaFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
auto alphaBiLevel = binaryAlphaTransform->AddAlphaBiLevelEffect(50.0f);
alphaBiLevel->set_Threshold(45.0f);
binaryAlphaTransform->AddAlphaInverseEffect();

presentation->Save(u"blur-and-alpha-effects.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Altre operazioni alfa senza parametri includono [AddAlphaCeilingEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/), che rende ogni alfa diverso da zero completamente opaco; [AddAlphaFloorEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/), che rende ogni alfa inferiore al 100% completamente trasparente; e [AddAlphaInverseEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/), che cambia l’alfa in `100% - alpha`.

## **Costruire una catena di effetti ordinata**

Ogni metodo `Add...Effect` aggiunge una nuova operazione alla fine della collezione. Il renderer utilizza la collezione come una pipeline ordinata: l'output dell'operazione 0 diventa l'input dell'operazione 1, e così via. Di conseguenza, le stesse operazioni in un ordine diverso possono produrre un’immagine diversa.

Ad esempio, la scala di grigi seguita da tinta rimuove prima le informazioni cromatiche e poi ricolia il risultato di luminanza. La tinta seguita da scala di grigi rimuove nuovamente la tinta. Analogamente, la sostituzione alfa può sovrascrivere i valori alfa calcolati dalle operazioni precedenti, mentre la modulazione alfa ne preserva le differenze relative.

L’esempio seguente costruisce una catena di quattro operazioni, la salva come PPTX, riapre la presentazione, verifica sia i tipi di operazione sia il loro ordine, e renderizza il risultato riaperto:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IGrayScale.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ITint.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 50.0f, 400.0f, 260.0f, image);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
imageTransform->AddGrayScaleEffect();
imageTransform->AddTintEffect(220.0f, 25.0f);
imageTransform->AddBlurEffect(2.5, false);
imageTransform->AddAlphaModulateFixedEffect(80.0f);

presentation->Save(u"image-transform-chain.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopenedPresentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
auto reopenedShape = reopenedPresentation->get_Slide(0)->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(reopenedShape))
{
    auto reopenedFrame = ExplicitCast<IPictureFrame>(reopenedShape);
    auto reopenedTransform = reopenedFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
    auto orderIsPreserved = reopenedTransform->get_Count() == 4 && 
            ObjectExt::Is<IGrayScale>(reopenedTransform->idx_get(0)) && 
            ObjectExt::Is<ITint>(reopenedTransform->idx_get(1)) && 
            ObjectExt::Is<IBlur>(reopenedTransform->idx_get(2)) && 
            ObjectExt::Is<IAlphaModulateFixed>(reopenedTransform->idx_get(3));
    Console::WriteLine(orderIsPreserved ? u"The effect chain was preserved." : u"The effect chain changed during the round trip.");

    auto renderedSlide = reopenedPresentation->get_Slide(0)->GetImage();
    renderedSlide->Save(u"reopened-effect-chain.png", ImageFormat::Png);
}
else
{
    Console::WriteLine(u"The reopened shape is not a picture frame.");
}

reopenedPresentation->Dispose();
```

La collezione non impone una matrice di compatibilità che limiti le operazioni di colore, alfa e sfocatura a catene separate. Possono essere combinate, ma le combinazioni non sono sempre utili. Una sostituzione colore fissa rimuove la variazione RGB prodotta da effetti di colore precedenti; la scala di grigi dopo duotone rimuove i due colori selezionati; e le operazioni alfa ceiling, floor, replacement o bi‑level possono scartare i dettagli alfa creati in precedenza. Costruisci la catena in base alla sequenza di elaborazione pixel desiderata invece di trattare gli elementi come flag di formattazione non ordinati.

<!-- visual-explanation:image-transform-effects:start -->
[![La stessa immagine passa prima attraverso la scala di grigi e poi la tinta, e la tinta prima della scala di grigi. Le due immagini finali in scala di grigi hanno tonalità diverse.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*In questo rendering illustrativo di Aspose.Slides per .NET 26.11, una tinta di 220° al 25% lascia invariata l’immagine in scala di grigi. Applicare la stessa tinta prima della scala di grigi produce tonalità diverse.*
<!-- visual-explanation:image-transform-effects:end -->

## **Ispezionare valori modificabili ed effettivi**

Un’operazione modificabile è l’oggetto memorizzato in `ISlidesPicture::get_ImageTransform`. A seconda dell’effetto, può esporre direttamente membri scrivibili. Ad esempio, [IBlur](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iblur/) espone `set_Radius` e `set_Grow`, [IAlphaModulateFixed](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphamodulatefixed/) espone `set_Amount`, e [IAlphaBiLevel](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphabilevel/) espone `set_Threshold`. Gli effetti di colore come [IDuotone](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iduotone/) espongono oggetti [IColorFormat](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/) modificabili.

Alcune interfacce operazione, inclusi [IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/cpp/aspose.slides.effects/itint/), e [IAlphaReplace](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphareplace/), non espongono i loro scalari di creazione come proprietà scrivibili. Per modificare tali impostazioni, rimuovere l’operazione e aggiungere una sostituzione nella posizione richiesta.

I dati effettivi restituiti da `GetEffective()` sono calcolati e di sola lettura. Sono utili per risolvere i colori dipendenti dal tema e leggere i valori normalizzati che il renderer utilizza, ma non costituiscono un’ulteriore superficie di modifica. L’esempio seguente enumera la catena e ispeziona i valori effettivi per diverse operazioni comuni:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IAlphaModulateFixedEffectiveData.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IBlurEffectiveData.h>
#include <DOM/Effects/IBrightnessContrast.h>
#include <DOM/Effects/IBrightnessContrastEffectiveData.h>
#include <DOM/Effects/IDuotone.h>
#include <DOM/Effects/IDuotoneEffectiveData.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ILuminance.h>
#include <DOM/Effects/ILuminanceEffectiveData.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;

auto presentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();

    for (auto&& operation : imageTransform)
    {
        if (ObjectExt::Is<IBrightnessContrast>(operation))
        {
            auto brightnessContrast = ExplicitCast<IBrightnessContrast>(operation);
            auto data = brightnessContrast->GetEffective();
            Console::WriteLine(u"Brightness: {0}; contrast: {1}", data->get_Brightness(), data->get_Contrast());
        }
        else if (ObjectExt::Is<ILuminance>(operation))
        {
            auto luminance = ExplicitCast<ILuminance>(operation);
            auto data = luminance->GetEffective();
            Console::WriteLine(u"Brightness: {0}; contrast: {1}", data->get_Brightness(), data->get_Contrast());
        }
        else if (ObjectExt::Is<IDuotone>(operation))
        {
            auto duotone = ExplicitCast<IDuotone>(operation);
            auto data = duotone->GetEffective();
            Console::WriteLine(u"Dark color: {0}; light color: {1}", data->get_Color1(), data->get_Color2());
        }
        else if (ObjectExt::Is<IBlur>(operation))
        {
            auto blur = ExplicitCast<IBlur>(operation);
            auto data = blur->GetEffective();
            Console::WriteLine(u"Blur radius: {0} pt", data->get_Radius());
        }
        else if (ObjectExt::Is<IAlphaModulateFixed>(operation))
        {
            auto alphaModulate = ExplicitCast<IAlphaModulateFixed>(operation);
            auto data = alphaModulate->GetEffective();
            Console::WriteLine(u"Alpha amount: {0}%", data->get_Amount());
        }
    }
}

presentation->Dispose();
```

Gli effetti senza parametri come scala di grigi, alpha ceiling e alpha inverse hanno comunque un oggetto di dati effettivi, ma non ci sono impostazioni scalari da stampare. La loro presenza e posizione nella collezione sono le informazioni importanti.

## **Rimuovere o cancellare le trasformazioni immagine**

Usare [IImageTransformOperationCollection::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/removeat/) per rimuovere un’operazione per indice. Poiché gli indici cambiano dopo la rimozione, cercare prima il bersaglio e rimuoverlo dopo l’enumerazione. Usare `Clear()` per rimuovere l’intera catena.

```cpp
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
    auto blurIndex = -1;

    for (auto index = 0; index < imageTransform->get_Count(); ++index)
    {
        if (ObjectExt::Is<IBlur>(imageTransform->idx_get(index)))
        {
            blurIndex = index;
            break;
        }
    }

    if (blurIndex >= 0)
    {
        imageTransform->RemoveAt(blurIndex);
        Console::WriteLine(u"The blur operation was removed.");
    }

    imageTransform->Clear();
    Console::WriteLine(u"Remaining operations: {0}", imageTransform->get_Count());
    presentation->Save(u"image-transforms-cleared.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

Rimuovere o cancellare le trasformazioni modifica solo la formattazione dell’immagine. Non elimina, ricomprime o altera in altro modo la risorsa [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) riutilizzata.

## **Considerare i formati di presentazione e le destinazioni di esportazione**

Le trasformazioni immagine hanno origine in DrawingML, quindi PPTX è il formato modificabile preferito per le catene di effetti. Anche con PPTX, non tutte le operazioni hanno la stessa portabilità:

- Le operazioni standard di DrawingML come luminanza, scala di grigi, duotone, tinta, HSL, sfocatura e le operazioni alfa comuni hanno la migliore possibilità di sopravvivere a un round‑trip PPTX. Riaprire sempre il file generato e ispezionare la collezione quando la conservazione è un requisito.  
- [BrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/brightnesscontrast/) è un’estensione di Office 2010 piuttosto che l’operazione standard di luminanza di DrawingML. Può essere usata per il rendering in memoria, ma non è garantito che rimanga un [IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/) modificabile dopo aver salvato e riaperto PPTX. Preferire [AddLuminanceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) per modifiche persistenti di luminosità e contrasto.  
- Il formato binario PPT è precedente al modello completo di effetti DrawingML. Salvare in PPT può omettere operazioni non supportate, ridurre una catena a un sottoinsieme supportato o approssimare l’aspetto. Non usare PPT come formato di verifica per una catena modificabile complessa.  
- Il rendering in PNG, JPEG, TIFF, PDF, SVG, HTML o altri output visivi applica la catena supportata all’aspetto renderizzato. Questi output non contengono un `IImageTransformOperationCollection` modificabile; i formati raster appiattiscono il risultato in pixel, e le esportazioni di documenti o vettoriali memorizzano la propria rappresentazione di rendering.  
- Gli effetti non rendono un’immagine collegata autonoma. Il rendering di un’immagine collegata dipende ancora dalla disponibilità della risorsa collegata al momento del caricamento della presentazione.  

Diversi consumatori di presentazioni possono renderizzare casi limiti in modo diverso, soprattutto quando più operazioni alfa o di quantizzazione colore sono combinate. Per output critici, testare sia il round‑trip modificabile sia il formato di esportazione finale con la stessa versione di Aspose.Slides usata in produzione.

## **FAQ**

**Le trasformazioni immagine modificano i dati dell’immagine incorporata?**

No. Le operazioni appartengono all’`ISlidesPicture` usato dal riempimento immagine. I byte sottostanti di `IPPImage` rimangono invariati.

**Due riquadri immagine che riutilizzano la stessa immagine condivideranno i loro effetti?**

No. Riutilizzare un `IPPImage` evita dati immagine duplicati, ma ogni riquadro immagine ha normalmente un proprio `ISlidesPicture` e una propria collezione di trasformazioni immagine.

**È possibile combinare effetti di colore, sfocatura e alfa?**

Sì. La collezione li accetta in una catena ordinata. Considerare cosa fa ciascuna operazione sull’output della precedente, poiché le operazioni di sostituzione e soglia possono scartare dettagli di colore o alfa precedenti.

**Perché i valori effettivi sono di sola lettura?**

I dati effettivi rappresentano valori calcolati usati per il rendering, inclusi i colori risolti. Modificare l’operazione memorizzata nella collezione di trasformazioni dove esistono membri scrivibili; altrimenti rimuoverla e aggiungere una sostituzione con nuovi parametri di creazione.

**Quale formato devo usare per preservare una catena di trasformazioni?**

Utilizzare PPTX e verificare il file riaprendolo. Il vecchio PPT non può rappresentare il modello completo di effetti DrawingML, e i formati di esportazione renderizzati preservano l’aspetto piuttosto che le operazioni di trasformazione modificabili.