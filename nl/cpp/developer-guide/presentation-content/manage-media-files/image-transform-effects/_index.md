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
- grijswaarde
- duotoon
- tint
- HSL
- kleurvervanging
- vervaging
- transparantie
- alfa-effect
- effectketen
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Toepassen, combineren, inspecteren, verwijderen en verifiëren van beeldtransformatie-effecten voor afbeeldingskaders met Aspose.Slides voor C++."
---
## **Overzicht**

Aspose.Slides vertegenwoordigt beeldaanpassingen als een geordende collectie van beeldtransformatie‑bewerkingen. Voor een afbeeldingskader begin je met de kader‑[ISlidesPicture](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidespicture/) en benader je [ISlidesPicture::get_ImageTransform](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidespicture/get_imagetransform/). De geretourneerde [IImageTransformOperationCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides.effects/iimagetransformoperationcollection/) laat je bewerkingen toevoegen, opsommen, inspecteren, verwijderen en wissen zonder de oorspronkelijke afbeeldingsbytes opnieuw te schrijven.

Dit artikel toont een volledige workflow voor helderheid en contrast, kleuraanpassingen, vervaging, transparantie, geordende effectketens, effectieve waarden, verwijdering en PPTX round‑trip‑verificatie.

## **Begrijp eigendom van effecten en hergebruik van afbeeldingen**

Een afbeeldingsbron en de afbeelding die deze weergeeft zijn verschillende objecten:

- [IPPImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/) slaat de bronbeeldgegevens op of verwijst ernaar en is eigendom van de presentatie.
- [ISlidesPicture](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidespicture/) hoort bij een afbeeldingsvulling en verwijst naar een afbeeldingsbron terwijl hij de beeldtransformatie‑collectie opslaat.
- [IPictureFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipictureframe/) is de dia‑shape die de bijbehorende afbeeldingsvulling, geometrie, uitsnijd‑instellingen en andere kader‑niveau opmaak bezit.

Daarom wijzigen beeldtransformatie‑bewerkingen de bytes in [IPPImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/) niet. Wanneer dezelfde `IPPImage` meer dan één keer wordt doorgegeven aan [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapecollection/addpictureframe/), krijgt elk nieuw afbeeldingskader zijn eigen `ISlidesPicture` en zijn eigen transformatie‑collectie. Het toepassen van grijswaarde op één kader maakt de andere kadrten niet grijs, hoewel ze allemaal dezelfde ingesloten afbeeldingsbron hergebruiken.

Hetzelfde `ISlidesPicture::get_ImageTransform`‑model wordt ook gebruikt door andere afbeeldingsvullingen, zoals een shape of dia‑achtergrond. De onderstaande voorbeelden focussen op afbeeldingskaders.

## **Gebruik geldige parameterbereiken en eenheden**

De getoonde methoden gebruiken de volgende semantische bereiken en eenheden. Houd de waarden binnen deze bereiken, ook al weigert een bepaalde bibliotheekversie niet elke out‑of‑range‑waarde meteen; het doel‑presentatieformaat kan ongeldige gegevens normaliseren, weglaten of weigeren tijdens het opslaan of wanneer PowerPoint het bestand opent.

| Operatie | Parameters | Geldig bereik en eenheid |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` tot `100`, procent; `0` laat de component ongewijzigd. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | Geen | Geen numerieke parameters. Alfa blijft ongewijzigd. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Twee kleuren voor donkere en lichte pixels. RGB‑ en alfachannelen in `System::Drawing::Color` gebruiken `0` tot `255`. |
| [AddTintEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Tintwaarde (`hue`) is `0` inclusief tot `360` exclusief, in graden; hoeveelheid (`amount`) is `-100` tot `100`, procent. |
| [AddHSLEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Tintwaarde (`hue`) is `0` inclusief tot `360` exclusief, in graden; verzadiging en luminantie zijn `-100` tot `100`, procent. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | De vervangingskleur gebruikt kanaalwaarden van `0` tot `255`. Bestaande alfabedragen blijven ongewijzigd. |
| [AddBlurEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Straal is niet‑negatief en wordt gemeten in points; `grow` bepaalt of vervaagde inhoud buiten de oorspronkelijke grenzen mag uitbreiden. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Niet‑negatief procent. Gebruik `0` tot `100` voor gewone ondoorzichtigheids‑schaling: `0` is volledig transparant en `100` behoudt de bestaande alfa. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` tot `100`, procent ondoorzichtigheid. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` tot `100`, procent alfabedrag. Waarden onder de drempel worden transparant; waarden gelijk aan of boven de drempel worden ondoorzichtig. |

Voor een vaste alfa‑modulatie zijn transparantie en ondoorzichtigheid complementair. Bijvoorbeeld, 35 % transparantie komt overeen met een alfa‑modulatie‑waarde van 65 %.

## **Pas helderheid en contrast toe**

[IImageTransformOperationCollection::AddBrightnessContrastEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) retourneert een [IBrightnessContrast](https://reference.aspose.com/slides/nl/cpp/aspose.slides.effects/ibrightnesscontrast/)‑bewerking. De schaalinstellingen worden meegegeven bij het aanmaken van de bewerking. De methode `IBrightnessContrast::GetEffective` levert berekende alleen‑lezen‑waarden die geïnspecteerd of gelogd kunnen worden.

Het volgende voorbeeld verhoogt de helderheid met 15 % en het contrast met 20 %, waarna een voorbeeld wordt gerenderd zonder de ingesloten afbeelding te wijzigen:

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

[BrightnessContrast](https://reference.aspose.com/slides/nl/cpp/aspose.slides.effects/brightnesscontrast/) is een Office 2010‑afbeeldingseffect‑extensie en minder portabel dan het standaard DrawingML‑luminantie‑effect. Wanneer helderheid en contrast bewerkbaar moeten blijven na een PPTX‑round‑trip, gebruik dan [IImageTransformOperationCollection::AddLuminanceEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) en controleer het resultaat na het heropenen van het bestand. De sectie over formaatbeperkingen legt dit onderscheid uitgebreider uit.

## **Pas kleuraanpassingen toe**

Kleur‑effecten kunnen onafhankelijk op verschillende afbeeldingskaders worden toegepast die één afbeeldingsbron hergebruiken. Het volgende voorbeeld maakt vijf kaders en past grijswaarde, duotoon, tint, HSL‑aanpassing en kleurvervanging toe.

[IDuotone](https://reference.aspose.com/slides/nl/cpp/aspose.slides.effects/iduotone/) bevat twee onafhankelijk bewerkbare kleurparameters: `get_Color1` mappt donkere pixels, terwijl `get_Color2` lichte pixels mappt. Dit maakt het een nuttig voorbeeld van een effect waarvan de instellingen complexer zijn dan een enkele schaalwaarde.

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

[AddColorReplaceEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) vervangt elke pixel‑kleur door één vaste kleur, waarbij alfa behouden blijft. Het verschilt van [AddColorChangeEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/), dat één bronkleur naar een andere mappt en zowel bron‑ als doelkleuropties blootstelt.

## **Voeg vervaging, transparantie en alfa‑effecten toe**

[AddBlurEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) heeft invloed op alle kleurkanalen, inclusief alfa. Stel `grow` in op `true` wanneer de vervaagde rand buiten de oorspronkelijke afbeeldingsgrenzen mag uitsteken.

Voor uniforme transparantie, gebruik [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/). Het vermenigvuldigt elke bestaande alfabedrag, zodat gedeeltelijk transparante pixels proportioneel verschillend blijven. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) wijst daarentegen één alfabedrag toe aan alle pixels. [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) zet alfa om naar twee niveaus op basis van een drempel.

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

Andere alfa‑bewerkingen zonder parameters zijn onder meer [AddAlphaCeilingEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/), dat elke niet‑nul alfa volledig ondoorzichtig maakt; [AddAlphaFloorEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/), dat elke alfa onder 100 % volledig transparant maakt; en [AddAlphaInverseEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/), dat alfa wijzigt naar `100% - alpha`.

## **Bouw een geordende effectketen**

Elke `Add...Effect`‑methode voegt een nieuwe bewerking toe aan het einde van de collectie. De renderer gebruikt de collectie als een geordende pijplijn: de uitvoer van bewerking 0 wordt de invoer van bewerking 1, enzovoort. Daardoor kan dezelfde set bewerkingen in een andere volgorde een ander beeld opleveren.

Bijvoorbeeld, grijswaarde gevolgd door tint verwijdert eerst chromatische informatie en kleurt daarna het luminantie‑resultaat opnieuw. Tint gevolgd door grijswaarde haalt de tint weer weg. Evenzo kan alfa‑vervanging alfa‑waarden die door eerdere bewerkingen zijn berekend overschrijven, terwijl alfa‑modulatie hun relatieve verschillen behoudt.

Het volgende voorbeeld bouwt een keten van vier bewerkingen, slaat deze op als PPTX, opent de presentatie opnieuw, controleert zowel de bewerkingstypen als hun volgorde, en rendert het heropenende resultaat:

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

De collectie legt geen compatibiliteitsmatrix op die kleur‑, alfa‑ en vervaging‑bewerkingen tot afzonderlijke ketens beperkt. Ze kunnen gecombineerd worden, maar combinaties zijn niet altijd zinvol. Een vaste kleurvervanging verwijdert RGB‑variatie die door eerdere kleureffecten is geproduceerd; grijswaarde na duotoon verwijdert de twee geselecteerde kleuren; en alfa‑ceiling, floor, replacement of bi‑level‑bewerkingen kunnen al eerder gecreëerde alfadeeltjes weggooien. Bouw de keten op volgens de gewenste pixelverwerkingsvolgorde in plaats van de items als ongeordende opmaak‑vlaggen te beschouwen.

## **Inspecteer bewerkbare en effectieve waarden**

Een bewerkbare bewerking is het object dat is opgeslagen in `ISlidesPicture::get_ImageTransform`. Afhankelijk van het effect kan het rechtstreeks schrijfbare leden blootstellen. Bijvoorbeeld, [IBlur](https://reference.aspose.com/slides/nl/cpp/aspose.slides.effects/iblur/) exposeert `set_Radius` en `set_Grow`, [IAlphaModulateFixed](https://reference.aspose.com/slides/nl/cpp/aspose.slides.effects/ialphamodulatefixed/) exposeert `set_Amount`, en [IAlphaBiLevel](https://reference.aspose.com/slides/nl/cpp/aspose.slides.effects/ialphabilevel/) exposeert `set_Threshold`. Kleur‑effecten zoals [IDuotone](https://reference.aspose.com/slides/nl/cpp/aspose.slides.effects/iduotone/) exposeerbare [IColorFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icolorformat/)‑objecten.

Sommige bewerkings‑interfaces, waaronder [IBrightnessContrast](https://reference.aspose.com/slides/nl/cpp/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/nl/cpp/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/nl/cpp/aspose.slides.effects/itint/), en [IAlphaReplace](https://reference.aspose.com/slides/nl/cpp/aspose.slides.effects/ialphareplace/), exposeert hun creatieschaalwaarden niet als schrijfbare eigenschappen. Om die instellingen te wijzigen, verwijder je de bewerking en voeg je een vervanging toe op de gewenste positie.

Effectieve data geretourneerd door `GetEffective()` wordt berekend en is alleen‑lezen. Het is nuttig voor het oplossen van themagerelateerde kleuren en het lezen van de genormaliseerde waarden die de renderer gebruikt, maar het is geen extra bewerkingslaag. Het volgende voorbeeld somt de keten op en inspecteert effectieve waarden voor verschillende veelvoorkomende bewerkingen:

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

Parameter‑vrije effecten zoals grijswaarde, alfa‑ceiling en alfa‑inverse hebben nog steeds een effectieve‑datobject, maar er zijn geen schaalinstellingen om af te drukken. Hun aanwezigheid en positie in de collectie zijn de belangrijke informatie.

## **Verwijder of wis beeldtransformaties**

Gebruik [IImageTransformOperationCollection::RemoveAt](https://reference.aspose.com/slides/nl/cpp/aspose.slides.effects/iimagetransformoperationcollection/removeat/) om één bewerking op index te verwijderen. Omdat indexen verschuiven na verwijdering, zoek eerst het doel en verwijder het daarna na het opsommen. Gebruik `Clear()` om de volledige keten te verwijderen.

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

Het verwijderen of wissen van transformaties wijzigt alleen de afbeeldingsopmaak. Het verwijdert, recomprimeert of wijzigt de hergebruikte [IPPImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/) bron niet.

## **Overweeg presentatieformaten en exportdoelen**

Beeldtransformaties ontstaan in DrawingML, dus PPTX is het voorkeurs‑bewerkbare formaat voor effectketens. Zelfs met PPTX heeft niet elke bewerking identieke portabiliteit:

- Standaard DrawingML‑bewerkingen zoals luminantie, grijswaarde, duotoon, tint, HSL, vervaging en gangbare alfa‑bewerkingen hebben de beste kans om een PPTX‑round‑trip te overleven. Open altijd het gegenereerde bestand opnieuw en inspecteer de collectie wanneer behoud een vereiste is.
- [BrightnessContrast](https://reference.aspose.com/slides/nl/cpp/aspose.slides.effects/brightnesscontrast/) is een Office 2010‑extensie in plaats van de standaard DrawingML‑luminantie‑bewerking. Het kan worden gebruikt voor in‑memory rendering, maar het is niet gegarandeerd dat het bewaard blijft als een bewerkbare [IBrightnessContrast](https://reference.aspose.com/slides/nl/cpp/aspose.slides.effects/ibrightnesscontrast/) na opslaan en opnieuw openen van PPTX. Geef de voorkeur aan [AddLuminanceEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) voor blijvende helderheids‑ en contrastaanpassingen.
- Het binaire PPT‑formaat bestaat vóór het volledige DrawingML‑effectmodel. Opslaan naar PPT kan niet‑ondersteunde bewerkingen weglaten, een keten reduceren tot een ondersteunde subset, of het uiterlijk benaderen. Gebruik PPT niet als verificatieformaat voor een complexe bewerkbare keten.
- Rendering naar PNG, JPEG, TIFF, PDF, SVG, HTML of andere visuele uitvoer past de ondersteunde keten toe op het gerenderde uiterlijk. Deze uitvoer bevat geen bewerkbare `IImageTransformOperationCollection`; rasterformaten flatten het resultaat naar pixels, en document‑ of vector‑exports slaan hun eigen weergaverepresentatie op.
- Effecten maken een gelinkte afbeelding niet zelf‑voorzienend. Het renderen van een gelinkte afbeelding blijft afhankelijk van de beschikbaarheid van de gelinkte bron wanneer de presentatie wordt geladen.

Verschillende presentatie‑consumenten kunnen randgevallen anders renderen, vooral wanneer meerdere alfa‑ of kleur‑kwantisering‑bewerkingen worden gecombineerd. Voor kritieke output, test zowel de bewerkbare round‑trip als het uiteindelijke exportformaat met dezelfde Aspose.Slides‑versie die in productie wordt gebruikt.

## **FAQ**

**Wijzigen beeldtransformatie‑effecten de ingesloten afbeeldingsgegevens?**

Nee. De bewerkingen behoren tot de `ISlidesPicture` die door de afbeeldingsvulling wordt gebruikt. De onderliggende `IPPImage`‑bytes blijven ongewijzigd.

**Delen twee afbeeldingskaders die dezelfde afbeelding hergebruiken hun effectinstellingen?**

Nee. Het hergebruiken van een `IPPImage` voorkomt dubbele afbeeldingsgegevens, maar elk afbeeldingskader heeft normaal gezien een eigen `ISlidesPicture` en eigen beeldtransformatie‑collectie.

**Kunnen kleur‑, vervaging‑ en alfa‑effecten worden gecombineerd?**

Ja. De collectie accepteert ze in één geordende keten. Houd rekening met wat elke bewerking doet met de uitvoer van de vorige, want vervangings‑ en drempel‑bewerkingen kunnen eerder kleur‑ of alfadeel van de afbeelding verwijderen.

**Waarom zijn effectieve waarden alleen‑lezen?**

Effectieve data vertegenwoordigt berekende waarden die voor rendering worden gebruikt, inclusief opgeloste kleuren. Bewerk de bewerking die in de transformatie‑collectie is opgeslagen waar schrijfbare leden bestaan; anders verwijder je deze en voeg je een vervanging toe met nieuwe creatie‑parameters.

**Welk formaat moet ik gebruiken om een transformatie‑keten te behouden?**

Gebruik PPTX en verifieer het bestand door het opnieuw te openen. Het oudere PPT‑formaat kan het volledige DrawingML‑effectmodel niet weergeven, en gerenderde exportformaten behouden alleen het uiterlijk, niet de bewerkbare transformatie‑bewerkingen.