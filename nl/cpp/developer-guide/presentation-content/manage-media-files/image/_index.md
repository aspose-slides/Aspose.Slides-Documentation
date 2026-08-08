---
title: "Optimaliseer afbeeldingbeheer in presentaties met C++"
linktitle: "Beheer afbeeldingen"
type: docs
weight: 10
url: /nl/cpp/image/
keywords:
- afbeelding toevoegen
- foto toevoegen
- bitmap toevoegen
- afbeelding vervangen
- foto vervangen
- van het web
- achtergrond
- PNG toevoegen
- JPG toevoegen
- SVG toevoegen
- externe SVG‑bronnen
- SVG‑resolver
- gelinkte SVG‑afbeeldingen
- SVG‑lettertypen
- EMF toevoegen
- WMF toevoegen
- TIFF toevoegen
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Stroomlijn het beheer van afbeeldingen in PowerPoint en OpenDocument met Aspose.Slides voor C++, optimaliseer de prestaties en automatiseer je workflow."
---
## **Introductie**

Afbeeldingen maken presentaties boeiender en visueel aantrekkelijker. In Microsoft PowerPoint kun je afbeeldingen op dia's invoegen vanuit bestanden, het internet of andere bronnen. Op dezelfde manier stelt Aspose.Slides je in staat om afbeeldingen aan presentatiedia's toe te voegen op verschillende manieren. 

{{% alert title="Tip" color="primary" %}} 

Aspose biedt gratis converters—[JPEG naar PowerPoint](https://products.aspose.app/slides/nl/import/jpg-to-ppt) en [PNG naar PowerPoint](https://products.aspose.app/slides/nl/import/png-to-ppt)—die je snel presentaties laten maken van afbeeldingen. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Wil je een afbeelding invoegen als een fotokader—vooral als je van plan bent de grootte aan te passen, effecten toe te passen of andere standaard opmaakopties te gebruiken—zie dan [Fotokader](/slides/nl/cpp/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Je kunt afbeeldingen van het ene formaat naar het andere converteren. Zie de volgende pagina's: converteren [afbeelding naar JPG](https://products.aspose.com/slides/nl/cpp/conversion/image-to-jpg/), [JPG naar afbeelding](https://products.aspose.com/slides/nl/cpp/conversion/jpg-to-image/), [JPG naar PNG](https://products.aspose.com/slides/nl/cpp/conversion/jpg-to-png/), [PNG naar JPG](https://products.aspose.com/slides/nl/cpp/conversion/png-to-jpg/), [PNG naar SVG](https://products.aspose.com/slides/nl/cpp/conversion/png-to-svg/), en [SVG naar PNG](https://products.aspose.com/slides/nl/cpp/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides ondersteunt afbeeldingen in populaire formaten zoals JPEG, PNG, BMP, GIF en andere. 

## **Afbeeldingen lokaal toevoegen aan dia's**

Je kunt één of meer afbeeldingen die op je computer zijn opgeslagen toevoegen aan een presentatiedia. De volgende C++‑voorbeeldcode laat zien hoe je een afbeelding aan een dia toevoegt:

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```



## **Afbeeldingen van het web toevoegen aan dia's**

Als de afbeelding die je aan een dia wilt toevoegen niet op je computer staat, kun je deze direct van het web toevoegen. 

De volgende C++‑voorbeeldcode laat zien hoe je een afbeelding van het web aan een dia toevoegt:

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <net/web_client.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);

auto webClient = System::MakeObject<System::Net::WebClient>();
auto imageData = webClient->DownloadData(System::MakeObject<Uri>(u"[REPLACE WITH URL]"));

auto image = pres->get_Images()->AddImage(imageData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Afbeeldingen toevoegen aan dia‑masters**

Een dia‑master slaat informatie op en beheert zaken zoals het thema en de lay‑out voor de dia's die het gebruiken. Wanneer je een afbeelding aan een dia‑master toevoegt, verschijnt de afbeelding op elke dia die op die master is gebaseerd. 

De volgende C++‑voorbeeldcode laat zien hoe je een afbeelding aan een dia‑master toevoegt:

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto masterSlide = slide->get_LayoutSlide()->get_MasterSlide();

auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
masterSlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Afbeeldingen gebruiken als dia‑achtergronden**

Je kunt een afbeelding gebruiken als achtergrond voor één of meer dia's. Zie voor details *[Afbeeldingen instellen als achtergronden voor dia's](/slides/nl/cpp/presentation-background/#setting-images-as-background-for-slides)*.

## **SVG toevoegen aan presentaties**

SVG‑inhoud kan worden toegevoegd aan een presentatie met de klasse [SvgImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/svgimage/). Het resulterende [ISvgImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isvgimage/)‑object kan vervolgens aan de presentatie‑afbeeldingscollectie worden toegevoegd en worden gebruikt om een fotokader te maken.

De volgende C++‑voorbeeldcode importeert een zelfstandige SVG‑string. Alle afbeeldingen, stijlen en andere bronnen die door deze SVG worden gebruikt, zijn direct in de SVG‑inhoud ingebed.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto svgContent = String(uR"(
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>)");

auto presentation = MakeObject<Presentation>();
auto svgImage = MakeObject<SvgImage>(svgContent);
auto image = presentation->get_Images()->AddImage(svgImage);

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle, 20.0f, 20.0f,
    static_cast<float>(image->get_Width()),
    static_cast<float>(image->get_Height()),
    image);

presentation->Save(u"self-contained-svg.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **SVG‑inhoud importeren met externe bronnen**

SVG‑bestanden die vanuit ontwerptools, diagrameditors, icoonsystemen en web‑pijplijnen worden geëxporteerd, kunnen verwijzen naar bronnen die buiten het SVG‑document zijn opgeslagen. Bijvoorbeeld, een SVG kan een afbeeldingslink bevatten zoals `images/photo.png`, een CSS‑`url(...)`‑waarde of een lettertype‑URL.

Om zulke SVG‑inhoud te importeren, maak je een implementatie van [IExternalResourceResolver](https://reference.aspose.com/slides/nl/cpp/aspose.slides.import/iexternalresourceresolver/) en geef je deze, samen met een basis‑URI, mee aan een geschikte `SvgImage`‑constructor. De basis‑URI identificeert de locatie van het SVG‑document en wordt gebruikt om relatieve links op te lossen.

De interface [ISvgImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isvgimage/) biedt toegang tot informatie over de geïmporteerde SVG:

- `get_SvgContent()` retourneert de SVG‑markup als string.
- `get_SvgData()` retourneert de SVG‑inhoud als byte‑array.
- `get_BaseUri()` retourneert de basis‑URI die wordt gebruikt voor relatieve links.
- `get_ExternalResourceResolver()` retourneert de resolver die aan de SVG‑afbeelding is toegewezen.

### **Een externe bronresolver implementeren**

De resolver heeft twee methoden:

- [ResolveUri](https://reference.aspose.com/slides/nl/cpp/aspose.slides.import/iexternalresourceresolver/resolveuri/) combineert de basis‑URI en een relatieve bronlink en retourneert een absolute URI. Geef een lege string terug wanneer de link niet kan worden opgelost of niet is toegestaan.
- [GetEntity](https://reference.aspose.com/slides/nl/cpp/aspose.slides.import/iexternalresourceresolver/getentity/) retourneert een leesbare stream voor een absolute bron‑URI. Geef `nullptr` terug wanneer de bron ontbreekt, geblokkeerd is of niet beschikbaar is. Een fallback‑stream kan ook worden teruggegeven wanneer dat passend is.

De volgende resolver laadt gekoppelde bronnen alleen vanuit een toegestane lokale map. Netwerkbronnen en paden buiten de toegestane map worden geblokkeerd. Een optionele fallback‑afbeelding wordt teruggegeven voor niet‑opgeloste afbeeldingslinks.

```cpp
#include <Import/IExternalResourceResolver.h>
#include <system/array.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>
#include <system/io/path.h>
#include <system/io/stream.h>
#include <system/string.h>
#include <system/smart_ptr.h>
#include <system/string_comparison.h>
#include <system/uri.h>

using namespace Aspose::Slides::Import;
using namespace System;
using namespace System::IO;

class LocalSvgResourceResolver : public IExternalResourceResolver
{
public:
    LocalSvgResourceResolver(String allowedRoot, ArrayPtr<uint8_t> fallbackImageData = nullptr)
        : _allowedRoot(Path::GetFullPath(allowedRoot)),
          _fallbackImageData(fallbackImageData)
    {
    }

    String ResolveUri(String baseUri, String relativeUri) override
    {
        if (String::IsNullOrWhiteSpace(baseUri) ||
            String::IsNullOrWhiteSpace(relativeUri))
        {
            return String::Null;
        }

        auto baseAddress = SharedPtr<Uri>();
        auto absoluteAddress = SharedPtr<Uri>();
        if (!Uri::TryCreate(baseUri, UriKind::Absolute, baseAddress) ||
            !Uri::TryCreate(baseAddress, relativeUri, absoluteAddress))
        {
            return String::Null;
        }

        // Deze resolver staat opzettelijk alleen lokale bestanden toe.
        if (!absoluteAddress->get_IsFile())
        {
            return String::Null;
        }

        auto resourcePath = Path::GetFullPath(absoluteAddress->get_LocalPath());
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return String::Null;
        }

        return absoluteAddress->get_AbsoluteUri();
    }

    SharedPtr<Stream> GetEntity(String absoluteUri) override
    {
        auto resourceUri = SharedPtr<Uri>();
        if (!Uri::TryCreate(absoluteUri, UriKind::Absolute, resourceUri) ||
            !resourceUri->get_IsFile())
        {
            return nullptr;
        }

        auto resourcePath = Path::GetFullPath(resourceUri->get_LocalPath());
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return nullptr;
        }

        if (File::Exists(resourcePath))
        {
            return File::OpenRead(resourcePath);
        }

        // Gebruik alleen een fallback voor afbeeldingsbronnen. Het retourneren van een afbeeldingsstream
        // voor een ontbrekend lettertype of stylesheet zou niet geldig zijn.
        if (_fallbackImageData != nullptr && IsImageFile(resourcePath))
        {
            return MakeObject<MemoryStream>(_fallbackImageData, false);
        }

        return nullptr;
    }

private:
    String _allowedRoot;
    ArrayPtr<uint8_t> _fallbackImageData;

    bool IsInsideAllowedRoot(String resourcePath)
    {
        auto normalizedRoot = _allowedRoot;
        auto directorySeparator = String(Path::DirectorySeparatorChar, 1);
        if (!normalizedRoot.EndsWith(directorySeparator))
        {
            normalizedRoot += directorySeparator;
        }

        auto normalizedPath = Path::GetFullPath(resourcePath);
        auto comparison = Path::DirectorySeparatorChar == u'\\'
            ? StringComparison::OrdinalIgnoreCase
            : StringComparison::Ordinal;

        return normalizedPath.StartsWith(normalizedRoot, comparison) ||
               String::Equals(normalizedPath, _allowedRoot, comparison);
    }

    static bool IsImageFile(String path)
    {
        auto extension = Path::GetExtension(path);

        return String::Equals(extension, u".png", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".jpg", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".jpeg", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".gif", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".bmp", StringComparison::OrdinalIgnoreCase);
    }
};
```

### **Gekoppelde bronnen oplossen tijdens SVG‑import**

Stel dat `assets/diagram.svg` een relatieve verwijzing bevat zoals:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

De volgende C++‑voorbeeldcode geeft de SVG‑bestand‑URI door als basis‑URI en levert een aangepaste resolver. De resolver zet de relatieve afbeeldingslink om naar een absolute URI en retourneert een stream met de gekoppelde bron terwijl Aspose.Slides de SVG verwerkt.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <Import/IExternalResourceResolver.h>
#include <system/array.h>
#include <system/environment.h>
#include <system/io/file.h>
#include <system/io/path.h>
#include <system/string.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Import;
using namespace System;
using namespace System::IO;

auto svgFilePath = Path::GetFullPath(Path::Combine(u"assets", u"diagram.svg"));
auto assetDirectory = Path::GetDirectoryName(svgFilePath);
if (String::IsNullOrEmpty(assetDirectory))
{
    assetDirectory = Environment::get_CurrentDirectory();
}

auto svgContent = File::ReadAllText(svgFilePath);

// De basis-URI vertegenwoordigt de locatie van het SVG-document.
auto baseUri = MakeObject<Uri>(svgFilePath)->get_AbsoluteUri();

auto fallbackImageData = ArrayPtr<uint8_t>();
auto fallbackImagePath = Path::Combine(assetDirectory, u"fallback.png");
if (File::Exists(fallbackImagePath))
{
    fallbackImageData = File::ReadAllBytes(fallbackImagePath);
}

auto resolver = MakeObject<LocalSvgResourceResolver>(assetDirectory, fallbackImageData);
auto svgImage = MakeObject<SvgImage>(svgContent, resolver, baseUri);

// ISvgImage exposes the source content, binary data, base URI, and resolver.
auto importedContent = svgImage->get_SvgContent();
auto importedData = svgImage->get_SvgData();
auto importedBaseUri = svgImage->get_BaseUri();
auto importedResolver = svgImage->get_ExternalResourceResolver();

auto presentation = MakeObject<Presentation>();
auto image = presentation->get_Images()->AddImage(svgImage);

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle, 20.0f, 20.0f,
    static_cast<float>(image->get_Width()),
    static_cast<float>(image->get_Height()),
    image);

presentation->Save(u"svg-with-linked-resources.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

De klasse `SvgImage` biedt ook overloads die SVG‑data accepteren als byte‑array of stream, samen met een externe bronresolver en een basis‑URI.

{{% alert title="Important" color="warning" %}}

De bronresolver maakt externe bronnen beschikbaar terwijl Aspose.Slides de SVG verwerkt en rendert. Het wijzigt de oorspronkelijke SVG‑markup niet en embedt de opgeloste bronnen niet automatisch.

Wanneer een `ISvgImage` wordt toegevoegd aan de presentatie‑afbeeldingscollectie, kan het PPTX‑bestand zowel de originele SVG‑representatie als een raster‑fallback‑afbeelding bevatten. Een gekoppelde bron kan verschijnen in de gegenereerde fallback‑afbeelding, terwijl een relatieve link zoals `images/photo.png` ongewijzigd blijft in de opgeslagen SVG. Een applicatie die de native SVG‑representatie rendert, kan daarom de gekoppelde inhoud weglaten wanneer de oorspronkelijke externe bron niet beschikbaar is.

{{% /alert %}}

### **Een draagbare SVG‑afbeelding maken**

Om een SVG‑afbeelding te maken die niet afhankelijk is van externe bestanden, maak je de SVG zelfstandig voordat je de `SvgImage` aanmaakt. Vervang bijvoorbeeld gekoppelde afbeeldings‑URL's door `data:`‑URI's die de afbeeldingsdata bevatten:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Nadat alle benodigde bronnen in de SVG‑inhoud zijn ingebed, maak je de `SvgImage`, voeg je deze toe aan de presentatie‑afbeeldingscollectie en plaats je hem in een fotokader zoals in het vorige voorbeeld.

### **Omgaan met missende of geblokkeerde bronnen**

Retourneer een lege string vanuit `ResolveUri` wanneer een bron‑URI ongeldig, verboden of niet oplosbaar is. Retourneer `nullptr` vanuit `GetEntity` wanneer de bron niet kan worden gelezen. Aspose.Slides blijft de SVG verwerken zonder die bron wanneer dat mogelijk is.

Een fallback‑stream kan worden teruggegeven voor een missende bron, maar de inhoud moet compatibel zijn met het opgevraagde bron‑type. Bijvoorbeeld, retourneer alleen een afbeeldings‑stream voor een missende afbeelding, niet voor een lettertype of stylesheet.

{{% alert title="Security" color="warning" %}}

Los geen willekeurige bestands‑paden of onbeperkte netwerk‑URL's op uit onbetrouwbare SVG‑bestanden. Beperk toegestane schema’s, mappen en hosts. Pas voor netwerkbronnen ook time‑outs, limieten op respons‑grootte en inhouds‑validatie toe.

{{% /alert %}}

## **SVG omzetten naar een verzameling vormen**
Aspose.Slides kan een SVG omzetten naar een verzameling vormen, vergelijkbaar met de overeenkomstige functionaliteit in PowerPoint:


![PowerPoint Popup Menu](img_01_01.png)

Deze functionaliteit wordt geleverd door een overload van de [AddGroupShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapecollection/)‑methode van de [IShapeCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapecollection/)‑interface die een [ISvgImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isvgimage/)‑object als eerste argument neemt.

De volgende C++‑voorbeeldcode laat zien hoe je deze methode gebruikt om een SVG‑bestand om te zetten naar een verzameling vormen:

``` cpp 
#include <DOM/IPresentation.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

// Bron SVG bestandsnaam
auto svgFileName = System::String(u"sample.svg");

// Uitvoerpresentatie bestandsnaam
auto outPptxPath = System::String(u"presentation.pptx");

// Nieuwe presentatie maken
auto presentation = System::MakeObject<Presentation>();

// SVG-bestandsinhoud lezen
auto svgContent = File::ReadAllText(svgFileName);

// Een SvgImage-object maken
auto svgImage = System::MakeObject<SvgImage>(svgContent);

// Diaformaat ophalen
auto slideSize = presentation->get_SlideSize()->get_Size();

// Converteer de SVG-afbeelding naar een groep vormen en schaal deze naar het diaformaat
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// De presentatie opslaan in PPTX-formaat
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **Afbeeldingen als EMF aan dia's toevoegen**
Aspose.Slides voor C++ stelt je in staat EMF‑afbeeldingen te genereren vanuit Excel‑werkbladen met Aspose.Cells en deze toe te voegen aan presentatiedia's. 

De volgende C++‑voorbeeldcode laat zien hoe je dit doet:

``` cpp 
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Aspose.Cells for C++ moet gestart worden voordat een van zijn types wordt gebruikt.
Aspose::Cells::Startup();

auto workbook = Aspose::Cells::Workbook(u"chart.xls");
auto sheet = workbook.GetWorksheets().Get(0);

// Render het werkblad als EMF.
auto options = Aspose::Cells::ImageOrPrintOptions();
options.SetHorizontalResolution(200);
options.SetVerticalResolution(200);
options.SetImageType(Aspose::Cells::Drawing::ImageType::Emf);

auto sheetRender = Aspose::Cells::SheetRender(sheet, options);

auto presentation = System::MakeObject<Presentation>();
presentation->get_Slides()->RemoveAt(0);

for (auto pageIndex = 0; pageIndex < sheetRender.GetPageCount(); pageIndex++)
{
    // Aspose.Cells retourneert de gerenderde pagina als een buffer, die Aspose.Slides toevoegt als een afbeelding.
    auto emfData = sheetRender.ToImage(pageIndex);
    auto emfBytes = System::MakeArray<uint8_t>(emfData.GetLength(), emfData.GetData());
    auto emfImage = presentation->get_Images()->AddImage(emfBytes);

    auto slide = presentation->get_Slides()->AddEmptySlide(
        presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank));
    auto slideSize = presentation->get_SlideSize()->get_Size();
    slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height(), emfImage);
}

presentation->Save(u"Saved.pptx", SaveFormat::Pptx);
presentation->Dispose();
workbook.Dispose();

Aspose::Cells::Cleanup();
```

## **Afbeeldingen vervangen in de afbeeldingscollectie**

Aspose.Slides laat je afbeeldingen in de afbeeldingscollectie van een presentatie vervangen, inclusief afbeeldingen die door dia‑vormen worden gebruikt. Deze sectie beschrijft verschillende manieren om afbeeldingen in de collectie bij te werken. Je kunt een afbeelding vervangen met ruwe byte‑data, een [IImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iimage/)‑instantie, of een andere afbeelding die al in de collectie bestaat.

Volg de onderstaande stappen:

1. Laad het presentatie‑bestand dat afbeeldingen bevat met de klasse [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/).
1. Laad een nieuwe afbeelding vanuit een bestand in een byte‑array.
1. Vervang de doelafbeelding door de nieuwe afbeelding met behulp van de byte‑array.
1. Bij de tweede aanpak laad je de afbeelding in een [IImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iimage/)‑object en vervang je de doelafbeelding door dat object.
1. Bij de derde aanpak vervang je de doelafbeelding door een afbeelding die al in de afbeeldingscollectie van de presentatie aanwezig is.
1. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// De eerste manier.
auto imageData = File::ReadAllBytes(u"image0.jpeg");
auto oldImage = presentation->get_Image(0);
oldImage->ReplaceImage(imageData);

// De tweede manier.
auto newImage = Images::FromFile(u"image1.png");
oldImage = presentation->get_Image(1);
oldImage->ReplaceImage(newImage);
newImage->Dispose();

// De derde manier.
oldImage = presentation->get_Image(2);
oldImage->ReplaceImage(presentation->get_Image(3));

// Sla de presentatie op in een bestand.
presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}

Met Aspose's gratis [Text to GIF](https://products.aspose.app/slides/nl/text-to-gif) converter kun je eenvoudig tekst animeren en GIF‑bestanden van tekst maken. 

{{% /alert %}}

## **FAQ**

**Blijft de oorspronkelijke resolutie van de afbeelding behouden na invoegen?**

Ja. De bron‑pixels worden behouden, maar het uiteindelijke uiterlijk hangt af van hoe het [picture](/slides/nl/cpp/picture-frame/) wordt geschaald op de dia en eventuele compressie bij opslaan.

**Wat is de beste manier om hetzelfde logo in tientallen dia's tegelijk te vervangen?**

Plaats het logo op de master‑dia of een lay‑out en vervang het in de afbeeldingscollectie van de presentatie—updates worden doorgevoerd naar alle elementen die die bron gebruiken.

**Kan een ingevoegde SVG worden omgezet naar bewerkbare vormen?**

Ja. Je kunt een SVG omzetten naar een groep vormen, waarna individuele delen bewerkbaar zijn met standaard vorm‑eigenschappen.

**Hoe kan ik één afbeelding als achtergrond voor meerdere dia's tegelijk instellen?**

[Wijs de afbeelding toe als achtergrond](/slides/nl/cpp/presentation-background/) op de master‑dia of de betreffende lay‑out—alle dia's die die master/lay‑out gebruiken, erven de achtergrond.

**Hoe voorkom ik dat een presentatie te groot wordt door veel afbeeldingen?**

Herbruik één enkele afbeeldingsbron in plaats van duplicaten, kies redelijke resoluties, pas compressie toe bij opslaan, en houd herhaalde grafieken op de master waar passend.