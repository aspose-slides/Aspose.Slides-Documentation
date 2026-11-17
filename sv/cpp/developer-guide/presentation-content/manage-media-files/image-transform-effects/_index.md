---
title: Hantera bildtransformeringseffekter i presentationer med C++
linktitle: Bildtransformeringseffekter
type: docs
weight: 11
url: /sv/cpp/image-transform-effects/
keywords:
- bildtransformering
- bildeffekt
- ljusstyrka
- kontrast
- gråskala
- duoton
- nyans
- HSL
- färguppbyte
- oskärpa
- transparens
- alfaeffekt
- effektkedja
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Applicera, kedja, inspektera, ta bort och verifiera bildtransformeringseffekter för bildramar med Aspose.Slides för C++."
---
## **Översikt**

Aspose.Slides representerar bildjusteringar som en ordnad samling av bildtransformeringsoperationer. För en bildram, börja med ramens [ISlidesPicture](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/) och få åtkomst till [ISlidesPicture::get_ImageTransform](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/get_imagetransform/). Den returnerade [IImageTransformOperationCollection](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/) låter dig lägga till, enumerera, inspektera, ta bort och rensa effekter utan att skriva om de ursprungliga bildbytena.

Denna artikel demonstrerar ett komplett arbetsflöde för ljusstyrka och kontrast, färgtransformeringar, oskärpa, transparens, ordnade effektkedjor, effektiva värden, borttagning och PPTX‑rundresa‑verifiering.

## **Förstå effektägarskap och bildåteranvändning**

En bildresurs och bilden som visar den är olika objekt:

- [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) lagrar eller refererar källdata för bilden som ägs av presentationen.
- [ISlidesPicture](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/) tillhör en bildfyllning och refererar en bildresurs samtidigt som den lagrar bildtransformeringssamlingen.
- [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/) är bildformen som äger den relevanta bildfyllningen, geometri, beskärningsinställningar och annan format på ramenivå.

Därför modifierar bildtransformeringsoperationer inte byten i [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/). När samma `IPPImage` skickas till [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addpictureframe/) mer än en gång, får varje ny bildram sin egen `ISlidesPicture` och sin egen transformeringssamling. Att applicera gråskala på en ram gör inte de andra ramarna gråskala, även om alla återanvänder samma inbäddade bildresurs.

Samma `ISlidesPicture::get_ImageTransform`‑modell används också av andra bildfyllningar, såsom en form eller bildbakgrund. Exemplen nedan fokuserar på bildramar.

## **Använd giltiga parameterintervall och enheter**

De demonstrerade metoderna använder följande semantiska intervall och enheter. Håll värden inom dessa intervall även om en specifik biblioteksversion inte omedelbart avvisar varje värde utanför intervallet; målformatet för presentationen kan normalisera, utelämna eller avvisa ogiltiga data under sparande eller när PowerPoint öppnar filen.

| Operation | Parametrar | Giltigt intervall och enhet |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` till `100`, procent; `0` lämnar komponenten oförändrad. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | Ingen | Inga numeriska parametrar. Alfa förblir oförändrad. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Två färger för mörka respektive ljusa pixlar. RGB‑ och alfakanaler i `System::Drawing::Color` använder `0` till `255`. |
| [AddTintEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Nyans är `0` inklusivt till `360` exklusivt, i grader; mängd är `-100` till `100`, procent. |
| [AddHSLEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Nyans är `0` inklusivt till `360` exklusivt, i grader; mättnad och luminans är `-100` till `100`, procent. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | Ersättningsfärgen använder kanalvärden från `0` till `255`. Befintliga alfavärden förblir oförändrade. |
| [AddBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Radie är icke‑negativ och mäts i punkt; `grow` styr huruvida oskärpad bild kan sträcka sig utanför ursprungliga gränser. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Icke‑negativ procent. Använd `0` till `100` för vanlig opacitetsskalning: `0` är helt transparent och `100` bevarar befintlig alfa. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` till `100`, procent opacitet. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` till `100`, procent alfatröskel. Värden under blir transparenta; värden på eller över blir opaka. |

För fast alfa‑modulering är transparens och opacitet komplementära. Till exempel motsvarar 35 % transparens en alfa‑moduleringsmängd på 65 %.

## **Applicera ljusstyrka och kontrast**

[IImageTransformOperationCollection::AddBrightnessContrastEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) returnerar en [IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/)‑operation. Dess skalära inställningar ges när operationen skapas. Metoden `IBrightnessContrast::GetEffective` returnerar beräknade skrivskyddade värden som kan inspekteras eller loggas.

Följande exempel ökar ljusstyrkan med 15 % och kontrasten med 20 %, och renderar sedan en förhandsvisning utan att ändra den inbäddade bilden:

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

[BrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/brightnesscontrast/) är en Office 2010‑bild‑effekt‑utökning och är mindre portabel än den standardiserade DrawingML‑luminefekten. När ljusstyrka och kontrast måste förbli redigerbara efter en PPTX‑rundresa, använd [IImageTransformOperationCollection::AddLuminanceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) och verifiera resultatet efter att filen öppnats igen. Avsnittet om formatbegränsningar förklarar detta mer i detalj.

## **Applicera färgtransformeringar**

Färgeffekter kan appliceras oberoende på olika bildramar som återanvänder samma bildresurs. Följande exempel skapar fem ramar och applicerar gråskala, duoton, nyans, HSL‑justering och färgbyte.

[IDuotone](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iduotone/) innehåller två oberoende redigerbara färgparametrar: `get_Color1` mappar mörka pixlar, medan `get_Color2` mappar ljusa pixlar. Detta gör den till ett användbart exempel på en effekt vars inställningar är mer komplexa än ett enskilt skalärt värde.

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

[AddColorReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) ersätter varje pixels färg med en fast färg samtidigt som alfa bevaras. Den skiljer sig från [AddColorChangeEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/), som mappar en källfärg till en annan och exponerar både käll- och målformat för färgen.

### **Applicera en luminanströskel**

En luminanströskel kan göra svaga märken på en skannad sida enklare att urskilja från bakgrunden. [AddGrayScaleEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) bevarar mellansteg av grått. [AddBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbileveleffect/) mappar luminans till svart eller vitt, medan [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) applicerar en tröskel på opacitet.

Luminanströskeln varierar från 0 % till 100 %, inklusive. Pixlar under tröskeln blir svarta. Pixlar på eller över blir vita. Att höja tröskeln gör fler nyanser svarta eftersom fler faller under avklippningen.

[Ladda ner grayscale-swatches.png](grayscale-swatches.png) till arbetskatalogen. Varje etikett visar den ursprungliga grånivån på en skala från 0 till 255. Exemplet placerar originalet bredvid två kopior och sparar varje kopias tröskel i presentationen.

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

Öppna den genererade presentationen i PowerPoint för att jämföra de tre ramarna. Swatch‑etiketten 96 har ungefär 38 % luminans (96 av 255). Den blir vit vid 20 %‑tröskeln och svart vid 60 %‑tröskeln.

![Original grayscale swatches beside the black-and-white results at luminance thresholds of 20% and 60%](luminance-threshold.png)

## **Lägg till oskärpa, transparens och alfa‑effekter**

[AddBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) påverkar alla färgkanaler, inklusive alfa. Sätt `grow` till `true` när den oskarpa kanten kan sträcka sig utanför den ursprungliga bildens gränser.

För jämn transparens, använd [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/). Den multiplicerar varje befintligt alfavärde, så delvis transparenta pixlar förblir proportionellt olika. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) tilldelar i stället ett alfavärde till alla pixlar. [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) konverterar alfa till två nivåer baserat på en tröskel.

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

Andra alfa‑operationer utan parametrar inkluderar [AddAlphaCeilingEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/), som gör varje icke‑noll alfa helt opak; [AddAlphaFloorEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/), som gör varje alfa under 100 % helt transparent; och [AddAlphaInverseEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/), som ändrar alfa till `100% - alpha`.

## **Bygg en ordnad effektkedja**

Varje `Add...Effect`‑metod lägger till en ny operation i slutet av samlingen. Renderaren använder samlingen som en ordnad pipeline: utdata från operation 0 blir indata till operation 1, och så vidare. Följaktligen kan samma operationer i en annan ordning producera en annan bild.

Till exempel tar gråskala följt av nyans först bort kromatiska data och färglägger sedan luminansresultatet. Nyans följt av gråskala tar bort nyansen igen. På samma sätt kan alfa‑ersättning skriva över alfa­värden beräknade av tidigare operationer, medan alfa‑modulering bevarar deras relativa skillnader.

Följande exempel byggar en kedja med fyra operationer, sparar den som PPTX, öppnar presentationen igen, kontrollerar både operationstyper och deras ordning, och renderar det återöppnade resultatet:

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

Samlingen tvingar ingen kompatibilitetsmatris som begränsar färg‑, alfa‑ och oskärpa‑operationer till separata kedjor. De kan kombineras, men kombinationerna är inte alltid meningsfulla. En fast färgbyte tar bort RGB‑variation som skapats av tidigare färgeffekter; gråskala efter duoton tar bort de två utvalda färgerna; och alfa‑ceiling, floor, replacement eller bi‑level‑operationer kan förlora alfa‑detalj som skapats tidigare. Bygg kedjan enligt den önskade pixel‑bearbetningssekvensen snarare än att betrakta dess objekt som oordnade formateringsflaggor.


<!-- visual-explanation:image-transform-effects:start -->
[![The same image passes through grayscale then tint, and tint then grayscale. The two final grayscale images have different tones.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*I denna illustrativa Aspose.Slides for .NET 26.11‑rendering lämnar en 220°‑nyans vid 25 % gråskalebilden oförändrad. Att applicera samma nyans före gråskala ger olika nyanser.*
<!-- visual-explanation:image-transform-effects:end -->

## **Inspektera redigerbara och effektiva värden**

En redigerbar operation är objektet lagrat i `ISlidesPicture::get_ImageTransform`. Beroende på effekten kan den exponera skrivbara medlemmar direkt. Till exempel exponerar [IBlur](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iblur/) `set_Radius` och `set_Grow`, [IAlphaModulateFixed](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphamodulatefixed/) `set_Amount`, och [IAlphaBiLevel](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphabilevel/) `set_Threshold`. Färgeffekter som [IDuotone](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iduotone/) exponerar muterbara [IColorFormat](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/)‑objekt.

Vissa operation‑gränssnitt, inklusive [IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/cpp/aspose.slides.effects/itint/), och [IAlphaReplace](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphareplace/), exponerar inte sina skapande‑skalärer som skrivbara egenskaper. För att ändra dessa inställningar, ta bort operationen och lägg till en ersättare på den önskade positionen.

Effektiva data som returneras av `GetEffective()` är beräknade och skrivskyddade. De är användbara för att lösa temaberoende färger och läsa de normaliserade värden som renderaren använder, men de utgör inte en ytterligare redigeringsyta. Följande exempel enumererar kedjan och inspektar effektiva värden för flera vanliga operationer:

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

Effekter utan parametrar såsom gråskala, alfa‑ceiling och alfa‑inverse har fortfarande ett effekt­datatobjekt, men det finns inga skalära inställningar att skriva ut. Deras närvaro och position i samlingen är den viktiga informationen.

## **Ta bort eller rensa bildtransformeringar**

Använd [IImageTransformOperationCollection::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/removeat/) för att ta bort en operation via index. Eftersom indexen skiftar efter borttagning, sök först efter målet och ta sedan bort det efter enumeration. Använd `Clear()` för att ta bort hela kedjan.

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

Att ta bort eller rensa transformeringar ändrar bara bildformatet. Det raderar inte, komprimerar om eller på annat sätt ändrar den återanvända [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/)‑resursen.

## **Beakta presentationsformat och exportmål**

Bildtransformeringar har sitt ursprung i DrawingML, så PPTX är det föredragna redigerbara formatet för effektkedjor. Även med PPTX har inte varje operation identisk portabilitet:

- Standard‑DrawingML‑operationer såsom luminans, gråskala, duoton, nyans, HSL, oskärpa och vanliga alfa‑operationer har störst chans att överleva en PPTX‑rundresa. Öppna alltid den genererade filen igen och inspektera samlingen när bevarande är ett krav.
- [BrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/brightnesscontrast/) är en Office 2010‑utökning snarare än den standardiserade DrawingML‑luminefekten. Den kan användas för rendering i minnet, men garanteras inte att förbli en redigerbar [IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/) efter sparande och återöppning av PPTX. Föredra [AddLuminanceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) för bestående ljusstyrke‑ och kontrastjusteringar.
- Det binära PPT‑formatet föregick den fullständiga DrawingML‑effektmodellen. Sparning till PPT kan utelämna icke‑stödda operationer, reducera en kedja till ett stöd­tsubset eller approximera utseendet. Använd inte PPT som verifieringsformat för en komplex redigerbar kedja.
- Rendering till PNG, JPEG, TIFF, PDF, SVG, HTML eller andra visuella utdata applicerar den stödjade kedjan på det renderade utseendet. Dessa utdata innehåller ingen redigerbar `IImageTransformOperationCollection`; rasterformat plattar ut resultatet till pixlar, och dokument‑ eller vektor‑exporter lagrar sin egen renderingsrepresentation.
- Effekter gör inte en länkad bild självförsörjande. Rendering av en länkad bild beror fortfarande på att den länkade resursen är tillgänglig när presentationen laddas.

Olika presentationskonsumenter kan rendera kantfall olika, särskilt när flera alfa‑ eller färg‑kvantisering‑operationer kombineras. För kritisk output, testa både den redigerbara rundresan och det slutliga exportformatet med samma Aspose.Slides‑version som används i produktion.

## **FAQ**

**Modifierar bildtransformeringseffekter den inbäddade bilddatan?**

Nej. Operationerna tillhör den `ISlidesPicture` som används av bildfyllningen. De underliggande `IPPImage`‑bytena förblir oförändrade.

**Kommer två bildramar som återanvänder samma bild att dela sina effekter?**

Nej. Återanvändning av en `IPPImage` undviker duplicerad bilddata, men varje bildram har normalt en separat `ISlidesPicture` och bildtransformeringssamling.

**Kan färg-, oskärpa‑ och alfa‑effekter kombineras?**

Ja. Samlingen accepterar dem i en ordnad kedja. Tänk på vad varje operation gör med resultatet från den föregående eftersom ersättnings‑ och tröskeloperationer kan förkasta tidigare färg‑ eller alfat detaljer.

**Varför är effektiva värden skrivskyddade?**

Effektiva data representerar beräknade värden som används för rendering, inklusive lösta färger. Redigera operationen som lagras i transform‑samlingen där skrivbara medlemmar finns; annars ta bort den och lägg till en ersättare med nya skapande‑parametrar.

**Vilket format bör jag använda för att bevara en transformkedja?**

Använd PPTX och verifiera filen genom att öppna den igen. Äldre PPT kan inte representera den fullständiga DrawingML‑effektmodellen, och renderade exportformat bevarar endast utseendet snarare än redigerbara transform‑operationer.