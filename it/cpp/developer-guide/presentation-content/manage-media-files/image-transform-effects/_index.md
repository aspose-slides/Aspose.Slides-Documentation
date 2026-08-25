---
title: "Gestire gli effetti di trasformazione dell'immagine nelle presentazioni con C++"
linktitle: "Effetti di trasformazione dell'immagine"
type: docs
weight: 11
url: /it/cpp/image-transform-effects/
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
- C++
- Aspose.Slides
description: "Applicare, concatenare, ispezionare, rimuovere e verificare gli effetti di trasformazione dell'immagine per i fotogrammi immagine con Aspose.Slides per C++."
---
## **Panoramica**

Aspose.Slides rappresenta le regolazioni dell'immagine come una collezione ordinata di operazioni di trasformazione dell'immagine. Per un fotogramma immagine, inizia con il frame's [ISlidesPicture](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidespicture/) e accedi a [ISlidesPicture::get_ImageTransform](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidespicture/get_imagetransform/). La [IImageTransformOperationCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides.effects/iimagetransformoperationcollection/) restituita ti consente di aggiungere, enumerare, ispezionare, rimuovere e cancellare gli effetti senza riscrivere i byte originali dell'immagine.

Questo articolo dimostra un flusso di lavoro completo per luminosità e contrasto, trasformazioni di colore, sfocatura, trasparenza, catene di effetti ordinate, valori effettivi, rimozione e verifica di round‑trip PPTX.

## **Comprendere la proprietà degli effetti e il riutilizzo dell'immagine**

Una risorsa immagine e l'immagine che la visualizza sono oggetti diversi:

- [IPPImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/ippimage/) memorizza o fa riferimento ai dati immagine sorgente di proprietà della presentazione.
- [ISlidesPicture](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidespicture/) appartiene a un riempimento immagine e si riferisce a una risorsa immagine conservando la collezione di trasformazioni dell'immagine.
- [IPictureFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipictureframe/) è la forma della diapositiva che possiede il riempimento immagine pertinente, la geometria, le impostazioni di ritaglio e altre formattazioni a livello di frame.

Pertanto, le operazioni di trasformazione dell'immagine non modificano i byte in [IPPImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/ippimage/). Quando lo stesso `IPPImage` viene passato a [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishapecollection/addpictureframe/) più di una volta, ogni nuovo fotogramma immagine riceve il proprio `ISlidesPicture` e la propria collezione di trasformazioni. Applicare la scala di grigi a un frame non rende gli altri frame in scala di grigi, anche se tutti riutilizzano la stessa risorsa immagine incorporata.

Lo stesso modello `ISlidesPicture::get_ImageTransform` è anche usato da altri riempimenti immagine, come una forma o lo sfondo della diapositiva. Gli esempi seguenti si focalizzano sui fotogrammi immagine.

## **Utilizzare intervalli di parametri e unità validi**

I metodi dimostrati usano i seguenti intervalli semantici e unità. Mantieni i valori in questi intervalli anche se una versione specifica della libreria non rifiuta immediatamente ogni valore fuori intervallo; il formato di destinazione della presentazione può normalizzare, omettere o rifiutare dati non validi durante il salvataggio o quando PowerPoint apre il file.

| Operazione | Parametri | Intervallo valido e unità |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` attraverso `100`, percentuale; `0` lascia il componente invariato. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | Nessuno | Nessun parametro numerico. L'alpha rimane invariato. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Due colori per pixel scuri e chiari. I canali RGB e alpha in `System::Drawing::Color` usano valori da `0` a `255`. |
| [AddTintEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Hue è compreso tra `0` (incluso) e `360` (escluso), in gradi; amount è `-100` attraverso `100`, percentuale. |
| [AddHSLEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Hue è `0` inclusivo fino a `360` esclusivo, in gradi; saturazione e luminanza sono `-100` attraverso `100`, percentuale. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | Il colore di sostituzione usa valori di canale da `0` a `255`. I valori alpha esistenti rimangono invariati. |
| [AddBlurEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Radius è non negativo e misurato in punti; `grow` controlla se il contenuto sfocato può estendersi oltre i limiti originali. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Percentuale non negativa. Usa `0` attraverso `100` per una normale scala di opacità: `0` è completamente trasparente e `100` preserva l'alpha esistente. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` attraverso `100`, percentuale di opacità. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` attraverso `100`, percentuale di soglia alpha. I valori al di sotto diventano trasparenti; i valori pari o superiori diventano opachi. |

Per la modulazione alpha fissa, trasparenza e opacità sono complementari. Per esempio, 35 % di trasparenza corrisponde a una modulazione alpha del 65 %.

## **Applicare luminosità e contrasto**

[IImageTransformOperationCollection::AddBrightnessContrastEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) restituisce un'operazione [IBrightnessContrast](https://reference.aspose.com/slides/it/cpp/aspose.slides.effects/ibrightnesscontrast/). Le impostazioni scalari sono fornite quando l'operazione è creata. Il metodo `IBrightnessContrast::GetEffective` restituisce valori calcolati in sola lettura che possono essere ispezionati o registrati.

L'esempio seguente aumenta la luminosità del 15 % e il contrasto del 20 %, quindi rende un'anteprima senza modificare l'immagine incorporata:

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

[BrightnessContrast](https://reference.aspose.com/slides/it/cpp/aspose.slides.effects/brightnesscontrast/) è un'estensione di effetto immagine Office 2010 e è meno portabile dell'effetto luminanza standard DrawingML. Quando luminosità e contrasto devono rimanere modificabili dopo un round‑trip PPTX, usa [IImageTransformOperationCollection::AddLuminanceEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) e verifica il risultato dopo aver riaperto il file. La sezione limitazioni del formato spiega questa distinzione in maggiore dettaglio.

## **Applicare trasformazioni di colore**

Gli effetti colore possono essere applicati indipendentemente a differenti fotogrammi immagine che riutilizzano una stessa risorsa immagine. L'esempio seguente crea cinque frame e applica scala di grigi, duotone, tinta, aggiustamento HSL e sostituzione colore.

[IDuotone](https://reference.aspose.com/slides/it/cpp/aspose.slides.effects/iduotone/) contiene due parametri colore modificabili indipendentemente: `get_Color1` mappa i pixel scuri, mentre `get_Color2` mappa i pixel chiari. Questo lo rende un esempio utile di effetto le cui impostazioni sono più complesse di un singolo valore scalare.

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

[AddColorReplaceEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) sostituisce il colore di ogni pixel con un colore fisso preservando l'alpha. È diverso da [AddColorChangeEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/), che mappa un colore sorgente a un altro e espone entrambi i formati colore sorgente e destinazione.

## **Aggiungere sfocatura, trasparenza e effetti alpha**

[AddBlurEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) influisce su tutti i canali colore, incluso l'alpha. Imposta `grow` a `true` quando il bordo sfocato può estendersi oltre i limiti originali dell'immagine.

Per trasparenza uniforme, usa [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/). Moltiplica ogni valore alpha esistente, quindi i pixel parzialmente trasparenti rimangono proporzionalmente diversi. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) invece assegna un unico valore alpha a tutti i pixel. [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) converte l'alpha in due livelli basati su una soglia.

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

Altre operazioni alpha senza parametri includono [AddAlphaCeilingEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/), che rende ogni alpha diverso da zero completamente opaco; [AddAlphaFloorEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/), che rende ogni alpha inferiore al 100 % completamente trasparente; e [AddAlphaInverseEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/), che cambia l'alpha in `100% - alpha`.

## **Costruire una catena di effetti ordinata**

Ogni metodo `Add...Effect` aggiunge una nuova operazione alla fine della collezione. Il renderer usa la collezione come pipeline ordinata: l'output dell'operazione 0 diventa l'input dell'operazione 1, e così via. Di conseguenza, le stesse operazioni in un ordine diverso possono produrre un'immagine diversa.

Ad esempio, scala di grigi seguita da tinta rimuove prima le informazioni cromatiche e poi ricolorizza il risultato di luminanza. Tinta seguita da scala di grigi rimuove nuovamente la tinta. Allo stesso modo, la sostituzione alpha può sovrascrivere i valori alpha calcolati da operazioni precedenti, mentre la modulazione alpha preserva le loro differenze relative.

L'esempio seguente costruisce una catena di quattro operazioni, la salva come PPTX, riapre la presentazione, verifica sia i tipi di operazione sia il loro ordine, e rende il risultato riaperto:

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

La collezione non impone una matrice di compatibilità che limiti operazioni colore, alpha e sfocatura a catene separate. Possono essere combinate, ma le combinazioni non sono sempre utili. Una sostituzione colore fissa elimina la variazione RGB prodotta da effetti colore precedenti; la scala di grigi dopo duotone elimina i due colori selezionati; e le operazioni alpha ceiling, floor, replacement o bi‑level possono scartare dettagli alpha creati in precedenza. Costruisci la catena secondo la sequenza di elaborazione pixel desiderata anziché trattare i suoi elementi come flag di formattazione non ordinati.

## **Ispezionare valori modificabili ed effettivi**

Un'operazione modificabile è l'oggetto memorizzato in `ISlidesPicture::get_ImageTransform`. A seconda dell'effetto, può esporre membri scrivibili direttamente. Per esempio, [IBlur](https://reference.aspose.com/slides/it/cpp/aspose.slides.effects/iblur/) espone `set_Radius` e `set_Grow`, [IAlphaModulateFixed](https://reference.aspose.com/slides/it/cpp/aspose.slides.effects/ialphamodulatefixed/) espone `set_Amount`, e [IAlphaBiLevel](https://reference.aspose.com/slides/it/cpp/aspose.slides.effects/ialphabilevel/) espone `set_Threshold`. Gli effetti colore come [IDuotone](https://reference.aspose.com/slides/it/cpp/aspose.slides.effects/iduotone/) espongono oggetti [IColorFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/icolorformat/) mutabili.

Alcune interfacce operative, incluse [IBrightnessContrast](https://reference.aspose.com/slides/it/cpp/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/it/cpp/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/it/cpp/aspose.slides.effects/itint/), e [IAlphaReplace](https://reference.aspose.com/slides/it/cpp/aspose.slides.effects/ialphareplace/), non espongono i loro scalari di creazione come proprietà scrivibili. Per cambiare tali impostazioni, rimuovi l'operazione e aggiungi una sostituzione nella posizione richiesta.

I dati effettivi restituiti da `GetEffective()` sono calcolati e in sola lettura. Sono utili per risolvere colori dipendenti dal tema e leggere i valori normalizzati usati dal renderer, ma non costituiscono un ulteriore livello di editing. L'esempio seguente enumera la catena e ispeziona i valori effettivi per diverse operazioni comuni:

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

Gli effetti senza parametri come scala di grigi, alpha ceiling e alpha inverse hanno comunque un oggetto di dati effettivi, ma non vi sono impostazioni scalari da stampare. La loro presenza e posizione nella collezione sono le informazioni importanti.

## **Rimuovere o cancellare le trasformazioni immagine**

Usa [IImageTransformOperationCollection::RemoveAt](https://reference.aspose.com/slides/it/cpp/aspose.slides.effects/iimagetransformoperationcollection/removeat/) per rimuovere un'operazione per indice. Poiché gli indici si spostano dopo una rimozione, cerca prima il bersaglio e rimuovilo dopo l'enumerazione. Usa `Clear()` per rimuovere l'intera catena.

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

Rimuovere o cancellare le trasformazioni cambia solo la formattazione dell'immagine. Non elimina, ricomprime o altera in altro modo la risorsa [IPPImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/ippimage/) riutilizzata.

## **Considerare i formati di presentazione e i target di esportazione**

Le trasformazioni immagine originano da DrawingML, quindi PPTX è il formato modificabile preferito per le catene di effetti. Anche con PPTX, non ogni operazione ha la stessa portabilità:

- Le operazioni DrawingML standard come luminanza, scala di grigi, duotone, tinta, HSL, sfocatura e operazioni alpha comuni hanno la migliore probabilità di sopravvivere a un round‑trip PPTX. Riapri sempre il file generato e ispeziona la collezione quando la conservazione è un requisito.
- [BrightnessContrast](https://reference.aspose.com/slides/it/cpp/aspose.slides.effects/brightnesscontrast/) è un'estensione Office 2010 piuttosto che l'operazione luminanza standard DrawingML. Può essere usata per il rendering in memoria, ma non è garantito che rimanga un [IBrightnessContrast](https://reference.aspose.com/slides/it/cpp/aspose.slides.effects/ibrightnesscontrast/) modificabile dopo aver salvato e riaperto il PPTX. Preferisci [AddLuminanceEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) per aggiustamenti di luminosità e contrasto persistenti.
- Il formato binario PPT precede il modello completo di effetti DrawingML. Il salvataggio in PPT può omettere operazioni non supportate, ridurre una catena a un sottoinsieme supportato o approssimare l'aspetto. Non usare PPT come formato di verifica per una catena complessa modificabile.
- Il rendering in PNG, JPEG, TIFF, PDF, SVG, HTML o altri output visivi applica la catena supportata all'aspetto renderizzato. Quei output non contengono una `IImageTransformOperationCollection` modificabile; i formati raster appiattiscono il risultato in pixel, e le esportazioni documentali o vettoriali memorizzano la propria rappresentazione di rendering.
- Gli effetti non rendono un'immagine collegata autonoma. Il rendering di un'immagine collegata dipende ancora dalla disponibilità della risorsa collegata quando la presentazione viene caricata.

Diversi consumatori di presentazioni possono renderizzare casi limite diversamente, specialmente quando più operazioni alpha o di quantizzazione colore sono combinate. Per output critici, testa sia il round‑trip modificabile sia il formato di esportazione finale con la stessa versione di Aspose.Slides usata in produzione.

## **FAQ**

**Le trasformazioni immagine modificano i dati immagine incorporati?**

No. Le operazioni appartengono al `ISlidesPicture` usato dal riempimento immagine. I byte sottostanti di `IPPImage` rimangono invariati.

**Due fotogrammi immagine che riutilizzano la stessa immagine condividono i loro effetti?**

No. Riutilizzare un `IPPImage` evita dati immagine duplicati, ma ogni fotogramma immagine normalmente ha un proprio `ISlidesPicture` e una propria collezione di trasformazioni.

**I colori, la sfocatura e gli effetti alpha possono essere combinati?**

Sì. La collezione li accetta in un'unica catena ordinata. Considera ciò che ogni operazione fa sull'output della precedente, perché le operazioni di sostituzione e soglia possono scartare dettagli colore o alpha precedenti.

**Perché i valori effettivi sono in sola lettura?**

I dati effettivi rappresentano valori calcolati usati per il rendering, inclusi i colori risolti. Modifica l'operazione memorizzata nella collezione di trasformazioni dove esistono membri scrivibili; altrimenti rimuovila e aggiungi una sostituzione con nuovi parametri di creazione.

**Quale formato devo usare per preservare una catena di trasformazioni?**

Usa PPTX e verifica il file riaprendolo. Il vecchio PPT non può rappresentare il modello completo di effetti DrawingML, e i formati di esportazione renderizzati preservano solo l'aspetto anziché le operazioni di trasformazione modificabili.