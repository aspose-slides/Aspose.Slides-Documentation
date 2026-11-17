---
title: Beheer beeldtransformatie-effecten in presentaties met C++
linktitle: Beeldtransformatie-effecten
type: docs
weight: 11
url: /nl/cpp/image-transform-effects/
keywords:
- beeldtransformatie
- afbeeldingseffect
- helderheid
- contrast
- grijswaarden
- duotoon
- tint
- HSL
- kleurenvervanging
- vervaging
- transparantie
- alpha-effect
- effectketen
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Pas beeldtransformatie-effecten toe, combineer, inspecteer, verwijder en verifieer ze voor afbeeldingsframes met Aspose.Slides voor C++."
---
## **Overzicht**

Aspose.Slides vertegenwoordigt afbeeldingaanpassingen als een geordende verzameling bewerkingen voor beeldtransformatie. Voor een afbeeldingsframe begint u met de frame‑[ISlidesPicture](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/) en krijgt u toegang tot [ISlidesPicture::get_ImageTransform](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/get_imagetransform/). De geretourneerde [IImageTransformOperationCollection](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/) laat u effecten toevoegen, opsommen, inspecteren, verwijderen en wissen zonder de oorspronkelijke afbeeldingsbytes opnieuw te schrijven.

Dit artikel demonstreert een volledige workflow voor helderheid en contrast, kleurtransformaties, vervaging, transparantie, geordende effectketens, effectieve waarden, verwijdering en PPTX‑round‑trip‑verificatie.

## **Begrijp eigendom van effecten en hergebruik van afbeeldingen**

Een afbeeldingsbron en de afbeelding die deze weergeeft zijn verschillende objecten:

- [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) slaat de bronafbeeldingsgegevens op of verwijst ernaar en behoort tot de presentatie.
- [ISlidesPicture](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/) hoort bij een opvulafbeelding en verwijst naar een afbeeldingsbron terwijl het de collectie voor beeldtransformatie opslaat.
- [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/) is de dia‑vorm die de bijbehorende opvulafbeelding, geometrie, bijsnijdinstellingen en andere frame‑specifieke opmaak bezit.

Daarom wijzigen beeldtransformatie‑bewerkingen de bytes in [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) niet. Wanneer dezelfde `IPPImage` meer dan één keer wordt doorgegeven aan [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addpictureframe/), krijgt elk nieuw afbeeldingsframe zijn eigen `ISlidesPicture` en eigen transformatie‑collectie. Het toepassen van grijswaarden op één frame maakt de andere frames niet grijs, hoewel alle frames dezelfde ingesloten afbeeldingsbron hergebruiken.

Hetzelfde `ISlidesPicture::get_ImageTransform`‑model wordt ook gebruikt door andere opvulafbeeldingen, zoals een vorm of dia‑achtergrond. De voorbeelden hieronder richten zich op afbeeldingsframes.

## **Gebruik geldige parameterbereiken en eenheden**

De getoonde methoden gebruiken de volgende semantische bereiken en eenheden. Houd waarden binnen deze bereiken, zelfs als een bepaalde bibliotheekversie niet meteen elke out‑of‑range‑waarde afwijst; het doel‑presentatieformaat kan ongeldige gegevens normaliseren, weglaten of afwijzen tijdens het opslaan of wanneer PowerPoint het bestand opent.

| Operatie | Parameters | Geldig bereik en eenheid |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` through `100`, percent; `0` leaves the component unchanged. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | None | No numeric parameters. Alpha is unchanged. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Two colors for dark and light pixels. RGB and alpha channels in `System::Drawing::Color` use `0` through `255`. |
| [AddTintEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Hue is `0` inclusive through `360` exclusive, in degrees; amount is `-100` through `100`, percent. |
| [AddHSLEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Hue is `0` inclusive through `360` exclusive, in degrees; saturation and luminance are `-100` through `100`, percent. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | The replacement color uses channel values from `0` through `255`. Existing alpha values are unchanged. |
| [AddBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Radius is nonnegative and is measured in points; `grow` controls whether blurred content may extend outside the original bounds. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Nonnegative percent. Use `0` through `100` for ordinary opacity scaling: `0` is fully transparent and `100` preserves the existing alpha. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` through `100`, percent opacity. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` through `100`, percent alpha threshold. Values below it become transparent; values at or above it become opaque. |

Voor vaste alphamodulatie zijn transparantie en opaciteit complementair. Bijvoorbeeld, 35 % transparantie komt overeen met een alphamodulatie‑bedrag van 65 %.

## **Pas helderheid en contrast toe**

[IImageTransformOperationCollection::AddBrightnessContrastEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) retourneert een [IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/)‑bewerking. De scalare instellingen worden meegegeven wanneer de bewerking wordt aangemaakt. De methode `IBrightnessContrast::GetEffective` retourneert berekende alleen‑lezen waarden die kunnen worden geïnspecteerd of gelogd.

Het volgende voorbeeld verhoogt de helderheid met 15 % en het contrast met 20 %, en rendert vervolgens een preview zonder de ingesloten afbeelding te wijzigen:

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

[BrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/brightnesscontrast/) is een Office 2010‑afbeeldingseffect‑extensie en is minder draagbaar dan het standaard DrawingML‑luminantie‑effect. Wanneer helderheid en contrast bewerkbaar moeten blijven na een PPTX‑round‑trip, gebruik dan [IImageTransformOperationCollection::AddLuminanceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) en verifieer het resultaat na het heropenen van het bestand. De sectie over formate‑beperkingen legt dit onderscheid uitgebreider uit.

## **Pas kleurtransformaties toe**

Kleureffecten kunnen onafhankelijk worden toegepast op verschillende afbeeldingsframes die één afbeeldingsbron hergebruiken. Het volgende voorbeeld maakt vijf frames en past grijswaarden, duotoon, tint, HSL‑aanpassing en kleureenreplace toe.

[IDuotone](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iduotone/) bevat twee onafhankelijk bewerkbare kleurparameters: `get_Color1` mappt donkere pixels, terwijl `get_Color2` lichte pixels mappt. Dit maakt het een bruikbaar voorbeeld van een effect waarvan de instellingen complexer zijn dan een enkele scalare waarde.

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

[AddColorReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) vervangt elke pixelkleur door één vaste kleur terwijl de alpha behouden blijft. Het verschilt van [AddColorChangeEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/), die één bronkleur naar een andere mappeert en zowel bron‑ als doelformaten blootlegt.

### **Pas een luminantiedrempel toe**

Een luminantiedrempel kan vage strepen op een gescande pagina beter onderscheiden van de achtergrond. [AddGrayScaleEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) behoudt tussenliggende grijstinten. [AddBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbileveleffect/) mappt luminantie naar zwart of wit, terwijl [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) een drempel op opaciteit toepast.

De luminantiedrempel varieert van 0 % tot 100 %, inclusief. Pixels onder de drempel worden zwart. Pixels op of boven de drempel worden wit. Het verhogen van de drempel maakt meer tinten zwart omdat meer ervan onder de cut‑off vallen.

Download [grayscale-swatches.png](grayscale-swatches.png) naar de werkmap. Elk label geeft het originele grijsniveau op een schaal van 0 tot 255 weer. Het voorbeeld plaatst het origineel naast twee kopieën en slaat de drempel van elke kopie op in de presentatie.

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

Open de uitvoer‑presentatie in PowerPoint om de drie frames te vergelijken. Het swatch‑label 96 heeft ongeveer 38 % luminantie (96 van 255). Het wordt wit bij een drempel van 20 % en zwart bij een drempel van 60 %.

![Originele grijstinten‑swatches naast de zwart‑wit‑resultaten bij luminantiedrempels van 20 % en 60 %](luminance-threshold.png)

## **Voeg vervaging, transparantie en alfa‑effecten toe**

[AddBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) beïnvloedt alle kleurkanalen, inclusief alpha. Stel `grow` in op `true` wanneer de vervaagde rand buiten de oorspronkelijke afbeeldingsgrenzen kan uitsteken.

Voor uniforme transparantie, gebruik [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/). Het vermenigvuldigt elke bestaande alfadewaarde, zodat gedeeltelijk transparante pixels proportioneel verschillend blijven. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) wijst in plaats daarvan één alfadewaarde toe aan alle pixels. [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) converteert alpha naar twee niveaus op basis van een drempel.

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

Andere parameter‑vrije alfa‑bewerkingen omvatten [AddAlphaCeilingEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/), dat elke niet‑nul alpha volledig ondoorzichtig maakt; [AddAlphaFloorEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/), dat elke alpha onder 100 % volledig transparant maakt; en [AddAlphaInverseEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/), dat alpha verandert naar `100% - alpha`.

## **Bouw een geordende effectketen**

Elke `Add...Effect`‑methode voegt een nieuwe bewerking toe aan het einde van de collectie. De renderer gebruikt de collectie als een geordende pijplijn: de output van bewerking 0 wordt de input van bewerking 1, enzovoort. Hierdoor kan dezelfde set bewerkingen in een andere volgorde een ander beeld opleveren.

Bijvoorbeeld, grijswaarden gevolgd door tint verwijdert eerst chromatische informatie en kleurt vervolgens het luminantie‑resultaat. Tint gevolgd door grijswaarden verwijdert de tint opnieuw. Evenzo kan alfareplace eerdere alfa‑berekeningen overschrijven, terwijl alphamodulatie hun relatieve verschillen behoudt.

Het volgende voorbeeld bouwt een keten van vier bewerkingen, slaat deze op als PPTX, opent de presentatie opnieuw, controleert zowel de bewerkingstypen als hun volgorde, en rendert het heropende resultaat:

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

De collectie legt geen compatibiliteitsmatrix op die kleur‑, alpha‑ en vervagingsbewerkingen tot afzonderlijke ketens beperkt. Ze kunnen gecombineerd worden, maar combinaties zijn niet altijd nuttig. Een vaste kleureenreplace verwijdert RGB‑variatie die door eerdere kleureffecten werd gecreëerd; grijswaarden na duotoon verwijdert de twee geselecteerde kleuren; en alpha‑ceiling, floor, replace of bi‑level‑bewerkingen kunnen alfa‑details die eerder zijn gecreëerd weggooien. Bouw de keten volgens de gewenste pixel‑verwerkende volgorde in plaats van de items te beschouwen als ongeordende opmaak‑vlaggen.

<!-- visual-explanation:image-transform-effects:start -->
[![Dezelfde afbeelding gaat eerst door grijswaarden dan tint, en daarna door tint dan grijswaarden. De twee uiteindelijke grijswaarden‑afbeeldingen hebben verschillende tinten.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*In deze illustratieve Aspose.Slides for .NET 26.11‑rendering laat een tint van 220° op 25 % de grijswaarden‑afbeelding ongewijzigd. Het toepassen van dezelfde tint vóór grijswaarden produceert verschillende tinten.*
<!-- visual-explanation:image-transform-effects:end -->

## **Inspecteer bewerkbare en effectieve waarden**

Een bewerkbare bewerking is het object opgeslagen in `ISlidesPicture::get_ImageTransform`. Afhankelijk van het effect kan het direct schrijfbare leden blootstellen. Bijvoorbeeld, [IBlur](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iblur/) toont `set_Radius` en `set_Grow`, [IAlphaModulateFixed](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphamodulatefixed/) toont `set_Amount`, en [IAlphaBiLevel](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphabilevel/) toont `set_Threshold`. Kleur‑effecten zoals [IDuotone](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iduotone/) tonen wijzigbare [IColorFormat](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/)‑objecten.

Sommige bewerkingsinterfaces, waaronder [IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/cpp/aspose.slides.effects/itint/), en [IAlphaReplace](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphareplace/), exposeren hun creatiescalaren niet als schrijfbare eigenschappen. Om die instellingen te wijzigen, verwijdert u de bewerking en voegt u een vervanging toe op de gewenste positie.

Effectieve gegevens die door `GetEffective()` worden geretourneerd, zijn berekend en alleen‑lezen. Ze zijn nuttig voor het oplossen van themagerelateerde kleuren en het lezen van de genormaliseerde waarden die de renderer gebruikt, maar vormen geen extra bewerkingsoppervlak. Het volgende voorbeeld loopt de keten door en inspecteert effectieve waarden voor verschillende veelvoorkomende bewerkingen:

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

Parameter‑vrije effecten zoals grijswaarden, alpha‑ceiling en alpha‑inverse hebben nog steeds een effectieve‑databject, maar er zijn geen scalare instellingen om af te drukken. Hun aanwezigheid en positie in de collectie zijn de belangrijke informatie.

## **Verwijder of wist beeldtransformaties**

Gebruik [IImageTransformOperationCollection::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/removeat/) om één bewerking te verwijderen op basis van index. Omdat indexen na verwijdering verschuiven, zoekt u eerst het doel en verwijdert u het na het opsommen. Gebruik `Clear()` om de hele keten te verwijderen.

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

Het verwijderen of wissen van transformaties verandert alleen de afbeelding‑opmaak. Het verwijdert, comprimeert of wijzigt de hergebruikte [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/)‑bron niet.

## **Overweeg presentatie‑formaten en export‑doelen**

Beeldtransformaties ontstaan in DrawingML, waardoor PPTX het voorkeurs‑bewerkbare formaat is voor effectketens. Zelfs met PPTX heeft niet elke bewerking identieke draagbaarheid:

- Standaard DrawingML‑bewerkingen zoals luminantie, grijswaarden, duotoon, tint, HSL, vervaging en gangbare alpha‑bewerkingen hebben de grootste kans om een PPTX‑round‑trip te overleven. Open altijd het gegenereerde bestand opnieuw en inspecteer de collectie wanneer behoud een vereiste is.
- [BrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/brightnesscontrast/) is een Office 2010‑extensie in plaats van de standaard DrawingML‑luminantie‑bewerking. Het kan voor in‑memory‑rendering worden gebruikt, maar het is niet gegarandeerd dat het na opslaan en heropenen van PPTX bewerkbaar blijft als een [IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/). Geef de voorkeur aan [AddLuminanceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) voor blijvende helderheids‑ en contrast‑aanpassingen.
- Het binaire PPT‑formaat bestaat vóór het volledige DrawingML‑effectmodel. Opslaan naar PPT kan niet‑ondersteunde bewerkingen weglaten, een keten reduceren tot een ondersteund subset, of de weergave benaderen. Gebruik PPT niet als verificatie‑formaat voor een complexe bewerkbare keten.
- Renderen naar PNG, JPEG, TIFF, PDF, SVG, HTML of andere visuele uitvoerpast de ondersteunde keten toe op het gerenderde uiterlijk. Die uitvoer bevat geen bewerkbare `IImageTransformOperationCollection`; rasterformaten vlakken het resultaat tot pixels, en document‑ of vector‑exports slaan hun eigen renderings‑representatie op.
- Effecten maken een gekoppelde afbeelding niet zelf‑containend. Het renderen van een gekoppelde afbeelding blijft afhankelijk van de beschikbaarheid van de gekoppelde bron wanneer de presentatie wordt geladen.

Verschillende presentatie‑consumenten kunnen randgevallen anders renderen, vooral wanneer meerdere alpha‑ of kleur‑kwantiserende bewerkingen worden gecombineerd. Voor kritieke uitvoer test zowel de bewerkbare round‑trip als het uiteindelijke export‑formaat met dezelfde Aspose.Slides‑versie die in productie wordt gebruikt.

## **FAQ**

**Modifieren beeldtransform‑effecten de ingesloten afbeeldingen?**

Nee. De bewerkingen behoren tot de `ISlidesPicture` die door de opvulafbeelding wordt gebruikt. De onderliggende `IPPImage`‑bytes blijven ongewijzigd.

**Delen twee afbeeldingsframes die dezelfde afbeelding hergebruiken hun effectinstellingen?**

Nee. Het hergebruiken van een `IPPImage` voorkomt dubbele afbeeldingsdata, maar elk afbeeldingsframe heeft normaal gesproken een aparte `ISlidesPicture` en beeldtransform‑collectie.

**Kunnen kleur‑, vervagings‑ en alpha‑effecten gecombineerd worden?**

Ja. De collectie accepteert ze in één geordende keten. Overweeg wat elke bewerking doet met de output van de vorige, omdat vervang‑ en drempel‑bewerkingen eerdere kleur‑ of alfade‑details kunnen verwijderen.

**Waarom zijn effectieve waarden alleen‑lezen?**

Effectieve gegevens vertegenwoordigen berekende waarden die voor rendering worden gebruikt, inclusief opgeloste kleuren. Bewerk de bewerking die in de transformatie‑collectie is opgeslagen waar schrijfbare leden bestaan; verwijder anders de bewerking en voeg een vervanging toe met nieuwe creatie‑parameters.

**Welk formaat moet ik gebruiken om een transform‑keten te behouden?**

Gebruik PPTX en verifieer het bestand door het opnieuw te openen. Legacy PPT kan het volledige DrawingML‑effectmodel niet weergeven, en gerenderde export‑formaten bewaren alleen het uiterlijk in plaats van bewerkbare transform‑bewerkingen.