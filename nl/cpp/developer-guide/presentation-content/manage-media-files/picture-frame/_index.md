---
title: Beheer foto‑frames in presentaties met C++
linktitle: Foto‑frame
type: docs
weight: 10
url: /nl/cpp/picture-frame/
keywords:
- foto‑frame
- foto‑frame toevoegen
- foto‑frame maken
- ingesloten afbeelding
- gekoppelde afbeelding
- afbeelding extraheren
- raster‑afbeelding
- SVG‑afbeelding
- afbeelding bijsnijden
- bijgesneden gebieden verwijderen
- afbeelding comprimeren
- StretchOffset
- foto‑frame opmaak
- relatieve schaal
- afbeeldingseffect
- aspectratio
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Maak, formatteer, link, bijsnijd, extraheer en comprimeer foto‑frames in presentaties met Aspose.Slides voor C++."
---
## **Overzicht**

Een foto‑frame is een dia‑vorm die een afbeelding weergeeft. In Aspose.Slides zijn de afbeelding‑resource en de vorm die deze weergeeft afzonderlijke objecten: een [Presentatie](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) bezit ingesloten afbeelding‑resources via zijn [afbeeldingsverzameling](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_images/), terwijl een [IPictureFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipictureframe/) de positie, grootte, lijnopmaak, rotatie, bijsnijden, foto‑effecten en andere frame‑niveau instellingen van de afbeelding regelt.

Deze scheiding is handig wanneer dezelfde afbeelding meer dan eens wordt getoond. Voeg de afbeelding één keer toe aan de presentatie, bewaar de geretourneerde [IPPImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/), en gebruik die afbeelding‑resource bij het maken van foto‑frames.

Foto‑frames kunnen raster‑afbeeldingen zoals PNG of JPEG en vector‑SVG‑afbeeldingen bevatten. Ze kunnen ook verwijzen naar gekoppelde afbeeldingen in plaats van de afbeeldingsbytes in de presentatie op te slaan. De keuze beïnvloedt draagbaarheid, bestandsgrootte, extractie en exportgedrag, dus het is verstandig om te bepalen hoe de afbeelding moet worden opgeslagen voordat je opmaak of optimalisatie toepast.

## **Een Ingesloten Afbeelding Toevoegen en Opmaken**

Voor een ingesloten afbeelding voeg je de afbeeldingsdata toe aan de presentatie en maak je een foto‑frame met [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shapecollection/addpictureframe/). De afbeelding wordt deel van het presentatiepakket, zodat de presentatie zelfvoorzienend blijft wanneer deze naar een andere computer wordt verplaatst.

Het volgende voorbeeld voegt een JPEG‑afbeelding toe, maakt een frame aan met de originele afmetingen van de afbeelding, en past lijnopmaak en rotatie toe:

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

Het foto‑frame bepaalt de weergegeven geometrie; het wijzigen van de frame‑grootte verandert de oorspronkelijke pixel‑afmetingen die in de ingesloten afbeelding‑resource zijn opgeslagen. Dit onderscheid wordt belangrijk bij latere bijsnijden of compressie van een afbeelding.

## **Relatieve Schaling Gebruiken**

[IPictureFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipictureframe/) biedt relatieve breedte‑ en hoogte‑schaling voor het frame. Een waarde van `1.0` komt overeen met 100 % van de originele afbeeldingsgrootte. Relatieve schaal is handig wanneer een workflow de verhouding tot de bronafbeeldingsgrootte moet behouden in plaats van handmatig de eindafmetingen te berekenen.

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

Relatieve schaal wijzigt de schaalinstellingen van het frame; het resamplet of comprimeert de ingesloten afbeelding niet.

## **Ingesloten en Gekoppelde Afbeeldingen**

Een ingesloten foto slaat afbeeldingsdata op binnen de presentatie en is daarom de veiligste keuze voor draagbaarheid en voorspelbare weergave. Een gekoppelde foto slaat via het [ISlidesPicture](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidespicture/)‑koppelpads een externe locatie op in plaats van de afbeeldingsdata in dezelfde structuur in te sluiten.

Gekoppelde afbeeldingen kunnen de hoeveelheid afbeelding‑data in de PPTX verminderen, maar brengen een externe afhankelijkheid met zich mee. Het gekoppelde bestand moet toegankelijk blijven voor de applicatie die de presentatie opent of rendert. Als het pad verandert, het bestand wordt verplaatst, of de bron onbereikbaar is, wordt de gekoppelde foto mogelijk niet zoals verwacht weergegeven. Voor presentaties die per e‑mail moeten worden verzonden, gearchiveerd of gerenderd in geïsoleerde omgevingen, zijn ingesloten afbeeldingen doorgaans betrouwbaarder.

### **Een Gekoppelde Afbeelding Toevoegen**

Het volgende voorbeeld maakt een foto‑frame aan en laat dit wijzen naar een lokaal afbeeldingsbestand. Het behandelt alleen afbeeldingskoppelingen; video‑koppelingen zijn een apart mediaproces en worden opzettelijk niet in dit voorbeeld gemengd.

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

Gebruik koppelingen wanneer extern bestandsbeheer opzettelijk is. Gebruik ze niet louter als vervanging voor compressie: een kleine PPTX met kapotte afbeeldingsafhankelijkheden is meestal minder bruikbaar dan een grotere, zelfvoorzienende presentatie.

## **Afbeeldingen Uit Foto‑Frames Extracten**

Controleer alvorens een afbeelding uit een bestaande presentatie te extraheren of een vorm daadwerkelijk een [IPictureFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipictureframe/) is en dat deze een ingesloten afbeelding bevat. Gekoppelde foto‑frames bevatten mogelijk geen afbeeldingsbytes die op dezelfde manier geëxtraheerd kunnen worden.

### **Een Raster‑Afbeelding Extracten**

De moderne afbeelding‑API gebruikt direct [IImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iimage/). Het volgende voorbeeld vindt de eerste ingesloten raster‑foto op een dia en slaat deze op als PNG:

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

Opslaan via [IImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iimage/) converteert de geëxtraheerde afbeelding naar het gevraagde uitvoerformaat. Als je de gecodeerde bytes wilt die in de presentatie zijn opgeslagen in plaats van een geconverteerd raster‑bestand, gebruik dan de binaire data van de afbeelding‑resource.

### **Een SVG‑Afbeelding Extracten**

Voor een SVG‑foto stelt de [IPPImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/) een [ISvgImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isvgimage/)‑object beschikbaar. Dit laat je de SVG‑data direct ophalen in plaats van de foto eerst te rasteren.

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

Het SVG‑inhoud als SVG behouden bewaart de vector‑bron binnen de presentatie. Raster‑exports zoals PNG of JPEG renderen die vectorinhoud noodzakelijkerwijs naar pixels. PDF‑ of SVG‑dia‑export is eveneens een renderoperatie, dus de geëxporteerde graphics moeten niet worden gezien als een bit‑voor‑bit kopie van de oorspronkelijke ingesloten SVG; gebruik de ingesloten [ISvgImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isvgimage/)‑data wanneer de originele vector‑resource zelf vereist is.

## **Een Afbeelding Bijsnijden**

Bijsnijden verandert welk deel van een afbeelding zichtbaar is binnen het frame. De bijsnijwaarden op [IPictureFillFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipicturefillformat/) zijn percentages van de bron‑afbeeldingsafmetingen. Bijsnijden verwijdert de verborgen pixels niet meteen uit de ingesloten afbeelding; het wijzigt alleen het zichtbare gebied.

Het volgende voorbeeld vindt veilig een foto‑frame en past bijsnijwaarden toe:

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

Omdat de verborgene afbeeldingsdata nog steeds aanwezig is, kan de bijsnijding later worden aangepast zonder verlies van de originele pixels. Als de bestandsgrootte belangrijker is dan de mogelijkheid tot terugdraaien, kunnen de bijgesneden gebieden fysiek worden verwijderd zoals beschreven in de volgende sectie.

## **Bijsneden Afbeeldingsdata Verwijderen**

[IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) verwijdert afbeeldingsdata buiten het huidige bijsnijdrechthoek en geeft de resulterende afbeelding‑resource terug. Dit kan de bestandsgrootte verkleinen, maar is een destructieve optimalisatie: na het opslaan van de presentatie zijn de verwijderde pixels niet meer beschikbaar voor een latere on‑bijsnijd‑bewerking.

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

De methode kan een nieuwe afbeelding‑resource aan de presentatie toevoegen. Als de oorspronkelijke afbeelding ook door andere foto‑frames wordt gebruikt, hebben die frames nog steeds hun bestaande resource nodig, waardoor het verwijderen van bijgesneden gebieden niet per se het totale aantal afbeeldingen vermindert. Het bijsnijden van WMF‑ of EMF‑content met deze methode rastert het bijgesneden resultaat naar PNG.

## **Raster‑Afbeeldingen Comprimeren**

[IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipicturefillformat/compressimage/) vermindert de raster‑resolutie ten opzichte van de grootte waarop de foto wordt weergegeven. Het kan tevens bijgesneden gebieden in dezelfde bewerking verwijderen. De methode retourneert `true` wanneer de afbeelding is verkleind of bijgesneden en `false` wanneer geen wijziging nodig was.

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

Een aangepaste positieve DPI‑waarde kan worden meegegeven in plaats van een enum‑waarde wanneer een specifieke doelwaarde vereist is.

Compressie is bedoeld voor raster‑afbeeldingen. SVG‑ en meta‑file‑content worden niet gereduceerd door deze raster‑compressieworkflow. Houd er ook rekening mee dat een lagere resolutie en verwijderde bijgesneden gebieden niet kunnen worden hersteld uit de geoptimaliseerde presentatie. Kies een doelresolutie gebaseerd op de grootste weergave‑ of exportgrootte van de afbeelding in plaats van wereldwijd de laagste DPI toe te passen.

## **Afbeelding‑Transformatie‑Effecten Beheren**

Voor een volledige workflow die helderheid, contrast, kleurtransformaties, onscherpte, alfa‑effecten, geordende ketens, inspectie, verwijdering en round‑trip‑verificatie omvat, zie [Image Transform Effects](/slides/nl/cpp/image-transform-effects/).

## **Geometrie van Foto‑Frame Vergrendelen**

De instellingen van [IPictureFrameLock](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipictureframelock/) bepalen welke bewerkingsacties uitgeschakeld zijn voor een foto‑frame. Bijvoorbeeld, de [aspect‑ratio‑vergrendeling](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) behoudt de verhoudingen van de vorm tijdens het schalen.

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

De vergrendeling geldt voor de foto‑frame‑vorm. Het dwingt de bronafbeelding niet om te worden geresampled of permanent te worden aangepast aan dezelfde beeldverhouding.

## **De StretchOffset‑Waarden Aanpassen**

Wanneer de vulling‑modus van de foto op stretch staat, definiëren de stretch‑offset‑waarden op [IPictureFillFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipicturefillformat/) het vullingsrechthoek ten opzichte van de begrenzende box van het foto‑frame. Positieve percentages creëren een insnijding vanaf een rand, terwijl negatieve percentages een uitsteeksel vormen.

Dit verschilt van bijsnijden. Bijsnijwaarden bepalen welk deel van de bron‑afbeelding zichtbaar is; stretch‑offsets wijzigen het rechthoek waarin de zichtbare foto‑vulling wordt uitgerekt.

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

Gebruik stretch‑offsets voor het plaatsen van de vulling. Gebruik bijsnijd‑eigenschappen wanneer het doel is om randen van de bron‑afbeelding te verbergen.

## **Opslag, Bestandsgrootte en Exportoverwegingen**

De belangrijkste afwegingen zijn makkelijker te beheren wanneer afbeeldingsopslag en foto‑frame‑opmaak apart worden behandeld:

- **Ingesloten afbeeldingen** maken de presentatie zelfvoorzienend en zijn het betrouwbaarst voor delen en server‑side rendering, maar grote raster‑afbeeldingen vergroten de PPTX‑grootte en het geheugenverbruik.
- **Gekoppelde afbeeldingen** kunnen het pakket kleiner houden, maar de presentatie hangt af van externe bestanden die beschikbaar blijven op de opgeslagen paden of locaties.
- **Bijsnijden** is aanvankelijk niet‑destructief. De verborgen pixels blijven ingesloten totdat bijgesneden gebieden expliciet worden verwijderd of tijdens compressie.
- **Compressie** kan de bestandsgrootte aanzienlijk verkleinen voor te grote raster‑afbeeldingen, maar doet een compromis met de bronresolutie. Het moet worden toegepast nadat de uiteindelijke weergavemaat op de dia bekend is.
- **SVG‑afbeeldingen** moeten als SVG worden behouden wanneer vectorbehoud belangrijk is. Extract de ingesloten SVG rechtstreeks wanneer je de vector‑resource zelf nodig hebt. Raster‑dia‑exports converteren altijd de gerenderde dia naar pixels.
- **Meerdere keren gebruikte afbeeldingen** dienen een bestaande [IPPImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/)‑resource te hergebruiken wanneer mogelijk in plaats van herhaaldelijk hetzelfde bestand in de presentatieworkflow te laden.

Voor grote presentaties is beeldoptimalisatie meestal het effectiefst wanneer selectief wordt toegepast: houd logo’s en diagrammen als vector‑content, comprimeer foto’s volgens hun werkelijke weergavemaat, verwijder bijgesneden pixels alleen wanneer latere bewerking niet vereist is, en vermijd externe koppelingen tenzij afhankelijkheidsbeheer deel uitmaakt van het implementatie‑ontwerp.

## **FAQ**

**Wat is het verschil tussen een foto‑frame en een afbeelding‑resource?**

Een [IPPImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/) vertegenwoordigt een afbeelding‑resource die aan de presentatie is gekoppeld. Een [IPictureFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipictureframe/) is een vorm op een dia die een afbeelding weergeeft en frame‑niveau geometrie en opmaak opslaat zoals grootte, rotatie, bijsnijdwaarden, effecten en vergrendelingen.

**Moet ik afbeeldingen insluiten of koppelen?**

Sluit afbeeldingen in wanneer de presentatie draagbaar, gearchiveerd of gerenderd moet worden zonder externe bronnen. Koppel afbeeldingen alleen wanneer het doelbewust is om afbeeldingsbestanden buiten de PPTX te houden en de externe locaties betrouwbaar kunnen worden beheerd.

**Vermindert bijsnijden de PPTX‑bestandsgrootte?**

Niet op zichzelf. Normale bijsnijdinstellingen verbergen delen van de bron‑afbeelding maar behouden de onderliggende pixels. Gebruik [IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) of afbeelding‑compressie met verwijdering van bijgesneden gebieden wanneer die pixels permanent kunnen worden verwijderd.

**Kan ik de afbeeldingskwaliteit herstellen na compressie?**

Nee. Compressie kan de opgeslagen raster‑resolutie verminderen, en het verwijderen van bijgesneden gebieden gooit afbeeldingsdata weg. Bewaar de originele bronafbeelding buiten de presentatie als later bewerken op hoge resolutie vereist kan zijn.

**Hoe moeten SVG‑afbeeldingen worden behandeld?**

Behoud SVG‑content als SVG wanneer vector‑fidelity van belang is. De ingesloten [ISvgImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isvgimage/) kan rechtstreeks worden geëxtraheerd. Het renderen van een dia naar een rasterformaat zoals PNG of JPEG rastert de SVG als onderdeel van de dia‑afbeelding.

**Hoe kan ik onveilige casts vermijden bij het lezen van bestaande dia’s?**

Controleer het vormtype voordat je foto‑frame‑specifieke leden gebruikt. Test de vorm met [IPictureFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipictureframe/) vóór een runtime‑cast, en wijs het cast‑resultaat toe aan een lokale variabele voordat je foto‑frame‑specifieke leden benadert.