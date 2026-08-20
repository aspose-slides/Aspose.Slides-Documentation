---
title: Beheer foto-frames in presentaties met C++
linktitle: Foto-frame
type: docs
weight: 10
url: /nl/cpp/picture-frame/
keywords:
- foto-frame
- foto-frame toevoegen
- foto-frame maken
- ingebedde afbeelding
- gekoppelde afbeelding
- afbeelding extraheren
- rasterafbeelding
- SVG-afbeelding
- afbeelding bijsnijden
- bijgesneden gebieden verwijderen
- afbeelding comprimeren
- StretchOffset
- opmaak van foto-frame
- relatieve schaal
- afbeeldingseffect
- beeldverhouding
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Maak, formatteer, link, bijsnijd, extraheer en comprimeer foto-frames in presentaties met Aspose.Slides voor C++."
---
## **Overzicht**

Een foto‑frame is een dia‑vorm die een afbeelding weergeeft. In Aspose.Slides zijn de afbeeldingsresource en de vorm die deze weergeeft afzonderlijke objecten: een [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) bezit ingebedde afbeeldingsresources via zijn [image collection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_images/), terwijl een [IPictureFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipictureframe/) de positie, grootte, lijnopmaak, rotatie, bijsnijden, foto‑effecten en andere instellingen op frame‑niveau regelt.

Deze scheiding is handig wanneer dezelfde afbeelding meer dan één keer wordt weergegeven. Voeg de afbeelding één keer toe aan de presentatie, bewaar de geretourneerde [IPPImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/), en gebruik die afbeeldingsresource bij het maken van foto‑frames.

Foto‑frames kunnen raster‑afbeeldingen zoals PNG of JPEG en vector‑SVG‑afbeeldingen bevatten. Ze kunnen ook verwijzen naar gekoppelde afbeeldingen in plaats van de afbeeldingsbytes in de presentatie op te slaan. De keuze beïnvloedt draagbaarheid, bestandsgrootte, extractie en exportgedrag, dus het is verstandig om te bepalen hoe de afbeelding moet worden opgeslagen voordat formatteer‑ of optimalisatie‑stappen worden toegepast.

## **Een ingebedde afbeelding toevoegen en opmaken**

Voor een ingebedde afbeelding voeg je de afbeeldingsdata toe aan de presentatie en maak je een foto‑frame met [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shapecollection/addpictureframe/). De afbeelding wordt onderdeel van het presentatiepakket, waardoor de presentatie zelf‑voorzienend blijft wanneer deze naar een andere computer wordt verplaatst.

Het volgende voorbeeld voegt een JPEG‑afbeelding toe, maakt een frame met de oorspronkelijke afmetingen van de afbeelding, en past lijnopmaak en rotatie toe:

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 100, image->get_Width(), image->get_Height(), image);
pictureFrame->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pictureFrame->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pictureFrame->get_LineFormat()->set_Width(3.0);
pictureFrame->set_Rotation(15.0f);

presentation->Save(u"picture-frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het foto‑frame regelt de weergegeven geometrie; het wijzigen van de framemaat verandert de oorspronkelijke pixelafmetingen die in de ingebedde afbeeldingsresource zijn opgeslagen. Deze onderscheiding wordt belangrijk bij later bijsnijden of comprimeren van een afbeelding.

## **Relatieve schaal gebruiken**

[IPictureFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipictureframe/) biedt relatieve breedte‑ en hoogteschaling voor het frame. Een waarde van `1.0` komt overeen met 100 % van de oorspronkelijke afbeeldinggrootte. Relatieve schaal is nuttig wanneer een workflow de relatie tot de bronafbeeldingsgrootte moet behouden in plaats van handmatig de uiteindelijke afmetingen te berekenen.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, image);
pictureFrame->set_RelativeScaleWidth(1.35f);
pictureFrame->set_RelativeScaleHeight(0.8f);

presentation->Save(u"relative-scale.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Relatieve schaal wijzigt de schaalinstellingen van het frame; het herschaalt of comprimeert de ingebedde afbeelding niet.

## **Ingebedde en gekoppelde afbeeldingen**

Een ingebedde foto slaat afbeeldingsdata op binnen de presentatie en is daardoor de veiligste keuze voor draagbaarheid en voorspelbare weergave. Een gekoppelde foto slaat een externe locatie op via het [ISlidesPicture](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidespicture/)‑koppelingspad in plaats van de afbeeldingsdata op dezelfde manier in te sluiten.

Gekoppelde afbeeldingen kunnen de hoeveelheid afbeeldingsdata in de PPTX verminderen, maar ze introduceren een externe afhankelijkheid. Het gekoppelde bestand moet toegankelijk blijven voor de applicatie die de presentatie opent of rendert. Als het pad wijzigt, het bestand wordt verplaatst, of de bron niet beschikbaar is, wordt de gekoppelde foto mogelijk niet weergegeven zoals verwacht. Voor presentaties die moeten worden gemaild, gearchiveerd of gerenderd in geïsoleerde omgevingen, zijn ingebedde afbeeldingen meestal betrouwbaarder.

### **Een gekoppelde afbeelding toevoegen**

Het volgende voorbeeld maakt een foto‑frame en verwijst het naar een lokaal afbeeldingsbestand. Het behandelt alleen afbeelding‑koppeling; videokoppeling is een aparte mediastream en wordt bewust niet gemengd in dit voorbeeld.

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 320, 180, nullptr);
auto linkPath = Path::GetFullPath(u"linked-image.jpg");
pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(linkPath);

presentation->Save(u"linked-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Gebruik koppelingen wanneer extern bestandsbeheer opzettelijk is. Gebruik ze niet enkel als vervanging voor compressie: een klein PPTX‑bestand met kapotte afbeeldingsafhankelijkheden is meestal minder bruikbaar dan een grotere, zelf‑voorzienende presentatie.

## **Afbeeldingen uit foto‑frames extraheren**

Controleer vóór het extraheren van een afbeelding uit een bestaande presentatie of een vorm werkelijk een [IPictureFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipictureframe/) is en of deze een ingebedde afbeelding bevat. Gekoppelde foto‑frames bevatten mogelijk niet de afbeeldingsbytes die op dezelfde manier kunnen worden geëxtraheerd.

### **Een raster‑afbeelding extraheren**

De moderne afbeeldings‑API gebruikt rechtstreeks [IImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iimage/). Het volgende voorbeeld zoekt de eerste ingebedde rasterfoto op een dia en slaat deze op als PNG:

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IPictureFrame>(shape))
    {
        continue;
    }

    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto embeddedImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image();
    if (embeddedImage == nullptr || embeddedImage->get_SvgImage() != nullptr)
    {
        continue;
    }

    auto rasterImage = embeddedImage->get_Image();
    rasterImage->Save(u"extracted-image.png", ImageFormat::Png);
    break;
}

presentation->Dispose();
```

Opslaan via [IImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iimage/) converteert de geëxtraheerde afbeelding naar het gevraagde uitvoerformaat. Als je de gecodeerde bytes die in de presentatie zijn opgeslagen nodig hebt in plaats van een geconverteerd rasterbestand, gebruik dan de binaire data van de afbeeldingsresource.

### **Een SVG‑afbeelding extraheren**

Voor een SVG‑foto biedt de [IPPImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/) een [ISvgImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isvgimage/)-object. Hiermee kun je de SVG‑data direct ophalen in plaats van de foto eerst te rasteren.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IPictureFrame>(shape))
    {
        continue;
    }

    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto embeddedImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image();
    if (embeddedImage == nullptr)
    {
        continue;
    }

    auto svgImage = embeddedImage->get_SvgImage();
    if (svgImage == nullptr)
    {
        continue;
    }

    File::WriteAllBytes(u"extracted-image.svg", svgImage->get_SvgData());
    break;
}

presentation->Dispose();
```

SVG‑inhoud als SVG behouden houdt de vectorbron binnen de presentatie behouden. Raster‑exporten zoals PNG of JPEG renderen die vectorinhoud noodzakelijkerwijs naar pixels. PDF‑ of SVG‑dia‑export is eveneens een render­operatie, dus de geëxporteerde grafieken moeten niet worden behandeld als een exacte byte‑voor‑byte kopie van de oorspronkelijke ingebedde SVG; gebruik de ingebedde [ISvgImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isvgimage/)‑data wanneer de originele vectorresource zelf vereist is.

## **Een afbeelding bijsnijden**

Bijsnijden verandert welk deel van een afbeelding zichtbaar is binnen het frame. De bijsnijdwaarden op [IPictureFillFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipicturefillformat/) zijn percentages van de bronafbeeldingsafmetingen. Bijsnijden verwijdert de verborgen pixels niet onmiddellijk uit de ingebedde afbeelding; het wijzigt alleen het zichtbare gebied.

Het volgende voorbeeld vindt een foto‑frame veilig en past bijsnijdwaarden toe:

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
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
    pictureFrame->get_PictureFormat()->set_CropLeft(23.6f);
    pictureFrame->get_PictureFormat()->set_CropRight(21.5f);
    pictureFrame->get_PictureFormat()->set_CropTop(3.0f);
    pictureFrame->get_PictureFormat()->set_CropBottom(31.0f);
    presentation->Save(u"cropped-image.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

Aangezien de verborgen afbeeldingsdata nog aanwezig is, kan de bijsnijding later worden aangepast zonder de originele pixels te verliezen. Als bestandsgrootte belangrijker is dan omkeerbaarheid, kunnen de bijgesneden gebieden fysiek worden verwijderd zoals beschreven in de volgende sectie.

## **Bijsneden afbeeldingsdata verwijderen**

[IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) verwijdert afbeeldingsdata buiten het huidige bijsnijdrechthoek en retourneert de resulterende afbeeldingsresource. Dit kan de bestandsgrootte verkleinen, maar het is een destructieve optimalisatie: nadat de presentatie is opgeslagen, zijn de verwijderde pixels niet meer beschikbaar voor een latere onbijsnijd‑operatie.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"cropped-image.pptx");
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
    auto croppedImage = pictureFrame->get_PictureFormat()->DeletePictureCroppedAreas();
    if (croppedImage != nullptr)
    {
        presentation->Save(u"cropped-data-removed.pptx", SaveFormat::Pptx);
    }
}

presentation->Dispose();
```

De methode kan een nieuwe afbeeldingsresource aan de presentatie toevoegen. Als de originele afbeelding ook door andere foto‑frames wordt gebruikt, hebben die frames nog steeds hun bestaande resource, zodat het verwijderen van bijgesneden gebieden niet per se het totale aantal afbeeldingen vermindert. Het bijsnijden van WMF‑ of EMF‑inhoud met deze methode rastert het bijgesneden resultaat naar PNG.

## **Rasterafbeeldingen comprimeren**

[IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipicturefillformat/compressimage/) vermindert de resolutie van raster‑afbeeldingen ten opzichte van de grootte waarop de foto wordt weergegeven. Het kan tevens bijgesneden gebieden verwijderen in dezelfde bewerking. De methode retourneert `true` wanneer de afbeelding is geschaald of bijgesneden en `false` wanneer er geen wijziging nodig was.

Gebruik een vooraf gedefinieerde [PicturesCompression](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/picturescompression/)‑waarde wanneer een standaard doelresolutie voldoende is:

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
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
    auto compressed = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);
    Console::WriteLine(compressed ? String(u"The image was compressed.") : String(u"No compression was necessary."));
    presentation->Save(u"compressed-image.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

Een aangepaste positieve DPI‑waarde kan worden doorgegeven in plaats van een enum‑waarde wanneer een specifiek doel vereist is.

Compressie is bedoeld voor raster‑afbeeldingen. SVG‑ en meta‑file‑inhoud worden niet verkleind door deze raster‑compressieworkflow. Houd er ook rekening mee dat lagere resolutie en verwijderde bijgesneden gebieden niet kunnen worden hersteld vanuit de geoptimaliseerde presentatie. Kies een doelresolutie op basis van de grootste weergave‑ of exportgrootte waarvoor de afbeelding daadwerkelijk zal worden bekeken, in plaats van wereldwijd de laagste DPI toe te passen.

## **Afbeeldingseffecten inspecteren**

Foto‑effecten worden opgeslagen op de foto die door het frame wordt gebruikt. De transformatiescollectie van de afbeelding kan effect­lagen bevatten, zoals vaste alfa‑modulatie voor transparantie en luminantie voor helderheid en contrast. Het onderstaande voorbeeld leest veilig beide soorten effecten van het eerste foto‑frame op een dia:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
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

auto presentation = MakeObject<Presentation>(u"sample.pptx");
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

    for (auto&& effect : imageTransform)
    {
        if (ObjectExt::Is<IAlphaModulateFixed>(effect))
        {
            auto alphaModulateFixed = ExplicitCast<IAlphaModulateFixed>(effect);
            auto transparency = 100.0f - alphaModulateFixed->get_Amount();
            Console::WriteLine(String(u"Transparency: ") + transparency);
        }

        if (ObjectExt::Is<ILuminance>(effect))
        {
            auto luminanceEffect = ExplicitCast<ILuminance>(effect);
            auto luminance = luminanceEffect->GetEffective();
            Console::WriteLine(String(u"Brightness: ") + luminance->get_Brightness());
            Console::WriteLine(String(u"Contrast: ") + luminance->get_Contrast());
        }
    }
}

presentation->Dispose();
```

Deze effecten veranderen hoe de afbeelding in het frame wordt gerenderd; ze herschrijven niet de oorspronkelijke ingebedde afbeeldingsbytes.

## **Geometrie van foto‑frame vergrendelen**

De [IPictureFrameLock](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipictureframelock/)‑instellingen bepalen welke bewerkingsacties zijn uitgeschakeld voor een foto‑frame. Bijvoorbeeld, de [aspect‑ratio lock](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) behoudt de verhoudingen van de vorm tijdens het schalen.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 100, image->get_Width(), image->get_Height(), image);
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);

presentation->Save(u"locked-picture-frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

De vergrendeling geldt voor de vorm van het foto‑frame. Het dwingt de bronafbeelding niet om te worden gereshampled of permanent te worden aangepast aan dezelfde aspect‑ratio.

## **De StretchOffset‑waarden aanpassen**

Wanneer de opvulmodus van de foto “stretch” is, definiëren de stretch‑offset‑waarden op [IPictureFillFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipicturefillformat/) het opvulrechthoek ten opzichte van de omtrek van het foto‑frame. Positieve percentages creëren een inset vanaf een rand, terwijl negatieve percentages een outset creëren.

Dit verschilt van bijsnijden. Bijsnijdwaarden bepalen welk deel van de bronafbeelding zichtbaar is; stretch‑offsets wijzigen het rechthoek waarin de zichtbare foto‑vulling wordt uitgerekt.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.png");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10, 10, 400, 300, image);
pictureFrame->get_PictureFormat()->set_PictureFillMode(PictureFillMode::Stretch);
pictureFrame->get_PictureFormat()->set_StretchOffsetLeft(12.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetRight(12.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetTop(8.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetBottom(8.0f);

presentation->Save(u"stretch-offsets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Gebruik stretch‑offsets voor plaatsing van de vulling. Gebruik bijsnijd‑eigenschappen wanneer het doel is om randen van de bronafbeelding te verbergen.

## **Opslag, bestandsgrootte en exportoverwegingen**

De belangrijkste afwegingen zijn makkelijker te beheren wanneer afbeelding‑opslag en foto‑frame‑formattering apart worden behandeld:

- **Ingebedde afbeeldingen** maken de presentatie zelf‑voorzienend en zijn het betrouwbaarst voor delen en server‑side rendering, maar grote raster‑afbeeldingen vergroten de PPTX‑grootte en het geheugenverbruik.
- **Gekoppelde afbeeldingen** kunnen het pakket kleiner houden, maar de presentatie is afhankelijk van externe bestanden die op de opgeslagen paden of locaties beschikbaar blijven.
- **Bijsnijden** is aanvankelijk niet‑destructief. De verborgen pixels blijven ingebed tot bijgesneden gebieden expliciet worden verwijderd of tijdens compressie.
- **Compressie** kan de bestandsgrootte aanzienlijk verkleinen voor te grote raster‑afbeeldingen, maar gaat ten koste van de bronresolutie. Toepassen nadat de beoogde weergave‑grootte op de dia bekend is.
- **SVG‑afbeeldingen** moeten behouden blijven als SVG wanneer vectorbehoud belangrijk is. Extraheer de ingebedde SVG direct wanneer je de vectorresource zelf nodig hebt. Raster‑dia‑exporten converteren altijd de gerenderde dia naar pixels.
- **Herhaalde afbeeldingen** moeten bij voorkeur een bestaande [IPPImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/)‑resource hergebruiken in plaats van steeds opnieuw hetzelfde bestand in de presentatie‑workflow te laden.

Voor grote presentaties is afbeelding‑optimalisatie meestal het effectiefst wanneer deze selectief wordt uitgevoerd: houd logo’s en diagrammen als vectorinhoud, comprimeer foto’s volgens hun daadwerkelijke weergavegrootte, verwijder bijgesneden pixels alleen wanneer latere bewerking niet vereist is, en vermijd externe koppelingen tenzij afhankelijkheidsbeheer deel uitmaakt van het implementatie‑ontwerp.

## **FAQ**

**Wat is het verschil tussen een foto‑frame en een afbeeldingsresource?**

Een [IPPImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/) vertegenwoordigt een afbeeldingsresource die aan de presentatie is gekoppeld. Een [IPictureFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipictureframe/) is een vorm op een dia die een afbeelding weergeeft en frame‑specifieke geometrie en opmaak zoals grootte, rotatie, bijsnijdwaarden, effecten en vergrendelingen opslaat.

**Moet ik afbeeldingen insluiten of linken?**

Sluit afbeeldingen in wanneer de presentatie draagbaar, gearchiveerd of gerenderd moet kunnen worden zonder toegang tot externe bronnen. Link afbeeldingen alleen wanneer het opzettelijk is om afbeeldingsbestanden buiten de PPTX te houden en de externe locaties betrouwbaar beheerd kunnen worden.

**Vermindert bijsnijden de bestandsgrootte van een PPTX?**

Niet op zichzelf. Normale bijsnijdinstellingen verbergen delen van de bronafbeelding maar behouden de onderliggende pixels. Gebruik [IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) of afbeelding‑compressie met verwijdering van bijgesneden zones wanneer die pixels permanent kunnen worden verwijderd.

**Kan ik de beeldkwaliteit herstellen na compressie?**

Nee. Compressie kan de opgeslagen raster‑resolutie verlagen, en het verwijderen van bijgesneden gebieden wist afbeeldingsdata. Bewaar de originele bronafbeelding buiten de presentatie als later bewerken in hoge resolutie vereist kan zijn.

**Hoe moeten SVG‑afbeeldingen worden behandeld?**

Behoud SVG‑inhoud als SVG wanneer vector‑fidelity belangrijk is. De ingebedde [ISvgImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isvgimage/) kan direct worden geëxtraheerd. Het renderen van een dia naar een rasterformaat zoals PNG of JPEG rastert de SVG als onderdeel van de dia‑afbeelding.

**Hoe kan ik onveilige casts vermijden bij het lezen van bestaande dia's?**

Controleer het vormtype voordat je foto‑frame‑specifieke leden gebruikt. Test de vorm met [IPictureFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipictureframe/) voordat je een runtime‑cast uitvoert, en wijs het cast‑resultaat toe aan een lokale variabele voordat je foto‑frame‑specifieke leden benadert.