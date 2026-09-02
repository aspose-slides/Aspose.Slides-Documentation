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
- färgbyte
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

Aspose.Slides representerar bildjusteringar som en ordnad samling av bildtransformationsoperationer. För en bildram, börja med ramens [ISlidesPicture](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidespicture/) och få åtkomst till [ISlidesPicture::get_ImageTransform](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidespicture/get_imagetransform/). Den returnerade [IImageTransformOperationCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides.effects/iimagetransformoperationcollection/) låter dig lägga till, enumerera, inspektera, ta bort och rensa effekter utan att skriva om de ursprungliga bildbytarna.

Denna artikel visar ett komplett arbetsflöde för ljusstyrka och kontrast, färgtransformeringar, oskärpa, transparens, ordnade effektkedjor, effektiva värden, borttagning och PPTX‑rundresaverifiering.

## **Förstå effektägarskap och bildåteranvändning**

En bildresurs och bilden som visar den är olika objekt:

- [IPPImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ippimage/) lagrar eller refererar källbilddata som ägs av presentationen.
- [ISlidesPicture](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidespicture/) tillhör en bildfyllning och refererar en bildresurs samtidigt som den lagrar samlingen av bildtransformeringar.
- [IPictureFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipictureframe/) är bildformen på bilden som äger den relevanta bildfyllningen, geometri, beskärningsinställningar och annan ram‑nivåformatering.

Därför modifierar bildtransformationsoperationer inte bytarna i [IPPImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ippimage/). När samma `IPPImage` skickas till [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishapecollection/addpictureframe/) mer än en gång, får varje ny bildram sin egen `ISlidesPicture` och sin egen transform‑samling. Att applicera gråskala på en ram gör inte de andra ramarna gråskalade, även om alla återanvänder samma inbäddade bildresurs.

Samma `ISlidesPicture::get_ImageTransform`‑modell används också av andra bildfyllningar, såsom en form eller bildbakgrund. Exemplen nedan fokuserar på bildramar.

## **Använd giltiga parameterintervall och enheter**

De demonstrerade metoderna använder följande semantiska intervall och enheter. Håll värdena inom dessa intervall även om en viss version av biblioteket inte avvisar varje värde utanför intervallet omedelbart; målformatet för presentationen kan normalisera, utelämna eller avvisa ogiltiga data vid sparning eller när PowerPoint öppnar filen.

| Operation | Parametrar | Giltigt intervall och enhet |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` till `100`, procent; `0` lämnar komponenten oförändrad. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | None | Inga numeriska parametrar. Alfa förblir oförändrad. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Två färger för mörka respektive ljusa pixlar. RGB‑ och alkanaler i `System::Drawing::Color` använder `0` till `255`. |
| [AddTintEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Nyans är `0` inkl. till `360` exkl., i grader; mängd är `-100` till `100`, procent. |
| [AddHSLEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Nyans är `0` inkl. till `360` exkl., i grader; mättnad och luminans är `-100` till `100`, procent. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | Ersättningsfärgen använder kanalvärden från `0` till `255`. Existerande alfavärden förblir oförändrade. |
| [AddBlurEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Radie är icke‑negativ och mäts i punkter; `grow` styr om suddigt innehåll får sträcka sig utanför de ursprungliga gränserna. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Icke‑negativ procent. Använd `0` till `100` för vanlig opacitets­skalning: `0` är helt transparent och `100` bevarar befintlig alfa. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` till `100`, procent opacitet. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` till `100`, procent alfa‑tröskel. Värden under blir transparenta; värden på eller över blir opaiga. |

För fast alfa‑modulering är transparens och opacitet komplementära. Till exempel motsvarar 35 % transparens en alfa‑moduleringsmängd på 65 %.

## **Applicera ljusstyrka och kontrast**

[IImageTransformOperationCollection::AddBrightnessContrastEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) returnerar en [IBrightnessContrast](https://reference.aspose.com/slides/sv/cpp/aspose.slides.effects/ibrightnesscontrast/)‑operation. Dess skalära inställningar anges när operationen skapas. Metoden `IBrightnessContrast::GetEffective` returnerar beräknade skrivskyddade värden som kan inspekteras eller loggas.

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

[BrightnessContrast](https://reference.aspose.com/slides/sv/cpp/aspose.slides.effects/brightnesscontrast/) är en Office 2010‑bild‑effektutökning och är mindre portabel än standard‑DrawingML‑luminanseffekten. När ljusstyrka och kontrast måste förbli redigerbara efter en PPTX‑rundresa, använd [IImageTransformOperationCollection::AddLuminanceEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) och verifiera resultatet efter att filen öppnats igen. Avsnittet om formatbegränsningar förklarar detta mer i detalj.

## **Applicera färgtransformeringar**

Färg‑effekter kan appliceras oberoende på olika bildramar som återanvänder en bildresurs. Följande exempel skapar fem ramar och applicerar gråskala, duoton, nyans, HSL‑justering och färgbyte.

[IDuotone](https://reference.aspose.com/slides/sv/cpp/aspose.slides.effects/iduotone/) innehåller två oberoende redigerbara färgparametrar: `get_Color1` mappar mörka pixlar, medan `get_Color2` mappar ljusa pixlar. Detta gör den till ett användbart exempel på en effekt vars inställningar är mer komplexa än ett enda skalärt värde.

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

[AddColorReplaceEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) ersätter varje pixels färg med en fast färg samtidigt som alfa bevaras. Den skiljer sig från [AddColorChangeEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/), som mappar en källfärg till en annan och exponerar både käll‑ och målformat för färg.

## **Lägg till oskärpa, transparens och alfa‑effekter**

[AddBlurEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) påverkar alla färgkanaler, inklusive alfa. Sätt `grow` till `true` när den suddiga kanten kan sträcka sig utanför den ursprungliga bildens gränser.

För enhetlig transparens, använd [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/). Den multiplicerar varje befintligt alfavärde, så delvis transparenta pixlar förblir proportionellt olika. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) tilldelar istället ett alfavärde till alla pixlar. [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) konverterar alfa till två nivåer baserat på en tröskel.

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

Andra alfa‑operationer utan parametrar inkluderar [AddAlphaCeilingEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/), som gör varje icke‑noll alfa helt opak; [AddAlphaFloorEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/), som gör varje alfa under 100 % helt transparent; och [AddAlphaInverseEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/), som ändrar alfa till `100% - alpha`.

## **Bygg en ordnad effektkedja**

Varje `Add...Effect`‑metod lägger till en ny operation i slutet av samlingen. Renderaren använder samlingen som en ordnad pipeline: utdata från operation 0 blir indata till operation 1 och så vidare. Följaktligen kan samma operationer i en annan ordning ge ett annat resultat.

Till exempel tar gråskala följt av nyans först bort kromatisk information och färglägger sedan luminansresultatet. Nyans följt av gråskala tar bort nyansen igen. På liknande sätt kan alfa‑ersättning åsidosätta alfavärden beräknade av tidigare operationer, medan alfa‑modulering bevarar deras relativa skillnader.

Följande exempel bygger en kedja med fyra operationer, sparar den som PPTX, öppnar presentationen igen, kontrollerar både operationstyper och deras ordning, och renderar det återöppnade resultatet:

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

Samlingen påtvingar ingen kompatibilitetsmatris som begränsar färg‑, alfa‑ och oskärpeoperationer till separata kedjor. De kan kombineras, men kombinationerna är inte alltid användbara. En fast färgbyte tar bort RGB‑variation som skapats av tidigare färgeffekter; gråskala efter duoton tar bort de två valda färgerna; och alfa‑tak, golv, ersättning eller bi‑nivå‑operationer kan kasta bort alfa‑detalj som skapats tidigare. Bygg kedjan enligt den önskade pixel‑bearbetningssekvensen snarare än att behandla dess element som oordnade formateringsflaggor.

## **Inspektera redigerbara och effektiva värden**

En redigerbar operation är objektet lagrat i `ISlidesPicture::get_ImageTransform`. Beroende på effekten kan den exponera skrivbara medlemmar direkt. Till exempel exponerar [IBlur](https://reference.aspose.com/slides/sv/cpp/aspose.slides.effects/iblur/) `set_Radius` och `set_Grow`, [IAlphaModulateFixed](https://reference.aspose.com/slides/sv/cpp/aspose.slides.effects/ialphamodulatefixed/) exponerar `set_Amount`, och [IAlphaBiLevel](https://reference.aspose.com/slides/sv/cpp/aspose.slides.effects/ialphabilevel/) exponerar `set_Threshold`. Färg‑effekter som [IDuotone](https://reference.aspose.com/slides/sv/cpp/aspose.slides.effects/iduotone/) exponerar muterbara [IColorFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/icolorformat/)‑objekt.

Vissa operations‑gränssnitt, inklusive [IBrightnessContrast](https://reference.aspose.com/slides/sv/cpp/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/sv/cpp/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/sv/cpp/aspose.slides.effects/itint/), och [IAlphaReplace](https://reference.aspose.com/slides/sv/cpp/aspose.slides.effects/ialphareplace/), exponerar inte sina skapande‑skalärer som skrivbara egenskaper. För att ändra dessa inställningar, ta bort operationen och lägg till en ersättare på rätt position.

Effektiva data som returneras av `GetEffective()` är beräknade och skrivskyddade. De är användbara för att lösa temaberoende färger och läsa de normaliserade värden som renderaren använder, men de utgör inte en ny redigeringsyta. Följande exempel enumererar kedjan och inspekterar effektiva värden för flera vanliga operationer:

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

Parameterfria effekter såsom gråskala, alfa‑tak och alfa‑invers har fortfarande ett effekt‑datobjekt, men det finns inga skalära inställningar att skriva ut. Deras förekomst och position i samlingen är den viktiga informationen.

## **Ta bort eller rensa bildtransformeringar**

Använd [IImageTransformOperationCollection::RemoveAt](https://reference.aspose.com/slides/sv/cpp/aspose.slides.effects/iimagetransformoperationcollection/removeat/) för att ta bort en operation med index. Eftersom indexen skiftar efter borttagning, sök först efter målet och ta sedan bort det efter enumeration. Använd `Clear()` för att ta bort hela kedjan.

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

Att ta bort eller rensa transformeringar ändrar endast bildformateringen. Det raderar inte, recomprimerar eller på annat sätt ändrar den återanvända [IPPImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ippimage/)‑resursen.

## **Betrakta presentationsformat och exportmål**

Bildtransformeringar har sitt ursprung i DrawingML, så PPTX är det föredragna redigerbara formatet för effektkedjor. Även med PPTX har inte varje operation identisk portabilitet:

- Standard‑DrawingML‑operationer såsom luminans, gråskala, duoton, nyans, HSL, oskärpa och vanliga alfa‑operationer har störst chans att överleva en PPTX‑rundresa. Öppna alltid den genererade filen igen och inspektera samlingen när bevarande är ett krav.
- [BrightnessContrast](https://reference.aspose.com/slides/sv/cpp/aspose.slides.effects/brightnesscontrast/) är en Office 2010‑utökning snarare än standard‑DrawingML‑luminanseffekten. Den kan användas för rendering i minnet, men det är inte garanterat att den förblir en redigerbar [IBrightnessContrast](https://reference.aspose.com/slides/sv/cpp/aspose.slides.effects/ibrightnesscontrast/) efter att PPTX sparats och öppnats igen. Föredra [AddLuminanceEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) för bestående justeringar av ljusstyrka och kontrast.
- Det binära PPT‑formatet föregår hela DrawingML‑effektmodellen. Sparas till PPT kan operationer som inte stöds utelämnas, kedjan reduceras till ett stödt delmängd, eller utseendet approximeras. Använd inte PPT som verifieringsformat för en komplex redigerbar kedja.
- Rendering till PNG, JPEG, TIFF, PDF, SVG, HTML eller andra visuella utdata applicerar den stödda kedjan på den renderade bilden. Dessa utdata innehåller ingen redigerbar `IImageTransformOperationCollection`; rasterformat plattar ut resultatet till pixlar, och dokument‑ eller vektor‑exporter lagrar sin egen renderingsrepresentation.
- Effekter gör inte en länkad bild självständig. Rendering av en länkad bild är fortfarande beroende av att den länkade resursen är tillgänglig när presentationen laddas.

Olika presentationskonsumenter kan rendera kantfall olika, särskilt när flera alfa‑ eller färg‑kvantisering‑operationer kombineras. För kritisk output, testa både den redigerbara rundresan och det slutliga exportformatet med samma Aspose.Slides‑version som används i produktion.

## **FAQ**

**Modifierar bildtransform‑effekter de inbäddade bilddata?**

Nej. Operationerna tillhör den `ISlidesPicture` som används av bildfyllningen. De underliggande `IPPImage`‑bytarna förblir oförändrade.

**Kommer två bildramar som återanvänder samma bild dela sina effekter?**

Nej. Återanvändning av en `IPPImage` undviker duplicerad bilddata, men varje bildram har normalt en separat `ISlidesPicture` och bildtransform‑samling.

**Kan färg-, oskärpa‑ och alfa‑effekter kombineras?**

Ja. Samlingen accepterar dem i en enda ordnad kedja. Tänk på vad varje operation gör med föregående operationens utdata eftersom ersättnings‑ och tröskel‑operationer kan kasta bort tidigare färg‑ eller alfadetaljer.

**Varför är effektiva värden skrivskyddade?**

Effektiva data representerar beräknade värden som används för rendering, inklusive lösta färger. Redigera operationen som ligger i transform‑samlingen där skrivbara medlemmar finns; annars ta bort den och lägg till en ersättare med nya skapande‑parametrar.

**Vilket format ska jag använda för att bevara en transform‑kedja?**

Använd PPTX och verifiera filen genom att öppna den igen. Äldre PPT kan inte representera hela DrawingML‑effektmodellen, och renderade exportformat bevarar bara utseendet snarare än redigerbara transform‑operationer.