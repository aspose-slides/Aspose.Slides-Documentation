---
title: Afbeeldingsbeheer optimaliseren in presentaties met C++
linktitle: Afbeeldingen beheren
type: docs
weight: 10
url: /nl/cpp/image/
keywords:
- afbeelding toevoegen
- foto toevoegen
- bitmap toevoegen
- afbeelding vervangen
- foto vervangen
- van web
- achtergrond
- PNG toevoegen
- JPG toevoegen
- SVG toevoegen
- externe SVG-bronnen
- SVG-resolver
- gekoppelde SVG-afbeeldingen
- SVG-lettertypen
- EMF toevoegen
- WMF toevoegen
- TIFF toevoegen
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Vereenvoudig het beheer van afbeeldingen in PowerPoint en OpenDocument met Aspose.Slides voor C++, optimaliseer de prestaties en automatiseer je werkstroom."
---
## **Introductie**

Afbeeldingen maken presentaties boeiender en visueel aantrekkelijker. In Microsoft PowerPoint kun je afbeeldingen op dia's invoegen vanuit bestanden, internet of andere bronnen. Op dezelfde manier stelt Aspose.Slides je in staat om afbeeldingen op presentatiedia's toe te voegen op verschillende manieren.

{{% alert title="Tip" color="info" %}} 
Aspose biedt gratis converters—[JPEG naar PowerPoint](https://products.aspose.app/slides/nl/import/jpg-to-ppt) en [PNG naar PowerPoint](https://products.aspose.app/slides/nl/import/png-to-ppt)—die je snel presentaties uit afbeeldingen kunt laten maken. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
Wil je een afbeelding toevoegen als afbeeldingselement—vooral als je van plan bent de grootte aan te passen, effecten toe te passen of andere standaard opmaakopties te gebruiken—zie dan [Afbeeldingselement](/slides/nl/cpp/picture-frame/). 
{{% /alert %}} 

{{% alert title="Opmerking" color="warning" %}}
Je kunt afbeeldingen van het ene formaat naar het andere converteren. Zie de volgende pagina's: converteer [afbeelding naar JPG](https://products.aspose.com/slides/nl/cpp/conversion/image-to-jpg/), [JPG naar afbeelding](https://products.aspose.com/slides/nl/cpp/conversion/jpg-to-image/), [JPG naar PNG](https://products.aspose.com/slides/nl/cpp/conversion/jpg-to-png/), [PNG naar JPG](https://products.aspose.com/slides/nl/cpp/conversion/png-to-jpg/), [PNG naar SVG](https://products.aspose.com/slides/nl/cpp/conversion/png-to-svg/), en [SVG naar PNG](https://products.aspose.com/slides/nl/cpp/conversion/svg-to-png/). 
{{% /alert %}}

Aspose.Slides ondersteunt afbeeldingen in populaire formaten zoals JPEG, PNG, BMP, GIF en andere.

## **Afbeeldingen die lokaal zijn opgeslagen toevoegen aan dia's**

Je kunt één of meerdere afbeeldingen die op je computer staan toevoegen aan een presentatiedia. De volgende C++-voorbeeldcode laat zien hoe je een afbeelding aan een dia toevoegt:

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

De volgende C++-voorbeeldcode laat zien hoe je een afbeelding van het web aan een dia toevoegt:

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

## **Afbeeldingen toevoegen aan dia‑meesters**

Een dia‑master slaat informatie op en regelt zaken zoals het thema en de lay-out voor de dia's die er gebruik van maken. Wanneer je een afbeelding toevoegt aan een dia‑master, verschijnt de afbeelding op elke dia die gebaseerd is op die master.

De volgende C++-voorbeeldcode laat zien hoe je een afbeelding toevoegt aan een dia‑master:

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

## **Afbeeldingen toevoegen als dia‑achtergronden**

Je kunt een afbeelding gebruiken als achtergrond voor één of meerdere dia's. Zie voor details *[Afbeeldingen instellen als achtergrond voor dia's](/slides/nl/cpp/presentation-background/#setting-images-as-background-for-slides)*.

## **SVG toevoegen aan presentaties**

SVG‑inhoud kan aan een presentatie worden toegevoegd met de [SvgImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/svgimage/)‑klasse. Het resulterende [ISvgImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isvgimage/)‑object kan vervolgens worden toegevoegd aan de afbeeldingsverzameling van de presentatie en worden gebruikt om een afbeeldingselement te maken.

De volgende C++‑voorbeeldcode importeert een zelf‑containende SVG‑string. Alle afbeeldingen, stijlen en andere bronnen die door deze SVG worden gebruikt, zijn rechtstreeks in de SVG‑inhoud ingebed.

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

## **SVG‑inhoud met externe bronnen importeren**

SVG‑bestanden die geëxporteerd zijn vanuit ontwerptools, diagrameditors, icoonsystemen en web‑pijplijnen kunnen verwijzen naar bronnen die buiten het SVG‑document zijn opgeslagen. Zo kan een SVG een afbeeldingskoppeling bevatten zoals `images/photo.png`, een CSS `url(...)`‑waarde of een lettertype‑URL.

Om dergelijke SVG‑inhoud te importeren, maak je een [IExternalResourceResolver](https://reference.aspose.com/slides/nl/cpp/aspose.slides.import/iexternalresourceresolver/)‑implementatie en geef je deze, samen met een basis‑URI, door aan een geschikte `SvgImage`‑constructor. De basis‑URI identificeert de locatie van het SVG‑document en wordt gebruikt om relatieve koppelingen op te lossen.

De [ISvgImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isvgimage/)‑interface biedt toegang tot informatie over de geïmporteerde SVG:

- `get_SvgContent()` retourneert de SVG‑markering als een string.
- `get_SvgData()` retourneert de SVG‑inhoud als een byte‑array.
- `get_BaseUri()` retourneert de basis‑URI die wordt gebruikt voor relatieve koppelingen.
- `get_ExternalResourceResolver()` retourneert de resolver die aan de SVG‑afbeelding is toegewezen.

### **Een externe resource‑resolver implementeren**

De resolver heeft twee methoden:

- [ResolveUri](https://reference.aspose.com/slides/nl/cpp/aspose.slides.import/iexternalresourceresolver/resolveuri/) combineert de basis‑URI en een relatieve resource‑koppeling en retourneert een absolute URI. Retourneer een lege string wanneer de koppeling niet kan worden opgelost of niet is toegestaan.
- [GetEntity](https://reference.aspose.com/slides/nl/cpp/aspose.slides.import/iexternalresourceresolver/getentity/) retourneert een leesbare stream voor een absolute resource‑URI. Retourneer `nullptr` wanneer de resource ontbreekt, geblokkeerd is of niet beschikbaar is. Een fallback‑stream kan eveneens worden geretourneerd wanneer dat passend is.

De volgende resolver laadt gekoppelde resources alleen vanuit een toegestane lokale map. Netwerk‑resources en paden buiten de toegestane map worden geblokkeerd. Een optionele fallback‑afbeelding wordt geretourneerd voor niet‑opgeloste afbeeldingskoppelingen.

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

        // Deze resolver staat bewust alleen lokale bestanden toe.
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

### **Gekoppelde resources oplossen tijdens SVG‑import**

Stel dat `assets/diagram.svg` een relatieve referentie bevat zoals:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

De volgende C++‑voorbeeldcode geeft de SVG‑bestand‑URI door als basis‑URI en levert een aangepaste resolver. De resolver zet de relatieve afbeeldingskoppeling om in een absolute URI en retourneert een stream met de gekoppelde resource terwijl Aspose.Slides de SVG verwerkt.

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

De `SvgImage`‑klasse biedt ook overladen methoden die SVG‑gegevens accepteren als een byte‑array of een stream, samen met een externe resource‑resolver en een basis‑URI.

{{% alert title="Belangrijk" color="warning" %}}
De resource‑resolver maakt externe resources beschikbaar terwijl Aspose.Slides de SVG verwerkt en rendert. Hij wijzigt niet de originele SVG‑markering en embedde de opgeloste resources niet automatisch erin.

Wanneer een `ISvgImage` wordt toegevoegd aan de afbeeldingsverzameling van de presentatie, kan het PPTX‑bestand zowel de oorspronkelijke SVG‑representatie als een raster‑fallback‑afbeelding bevatten. Een gekoppelde resource kan in de gegenereerde fallback‑afbeelding verschijnen, terwijl een relatieve koppeling zoals `images/photo.png` onveranderd blijft in de opgeslagen SVG. Een applicatie die de native SVG‑representatie rendert, kan daarom de gekoppelde inhoud weglaten wanneer de originele externe resource niet beschikbaar is.
{{% /alert %}}

### **Een draagbare SVG‑afbeelding maken**

Om een SVG‑afbeelding te maken die niet afhankelijk is van externe bestanden, maak je de SVG zelf‑containend voordat je de `SvgImage` creëert. Vervang bijvoorbeeld gekoppelde afbeeldings‑URL's door `data:`‑URI's die de afbeeldingsgegevens bevatten:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Nadat alle vereiste resources in de SVG‑inhoud zijn ingebed, maak je de `SvgImage`, voeg je deze toe aan de afbeeldingsverzameling van de presentatie en plaats je deze in een afbeeldingselement zoals in het vorige voorbeeld.

### **Ontbrekende of geblokkeerde resources afhandelen**

Retourneer een lege string vanuit `ResolveUri` wanneer een resource‑URI ongeldig, verboden of niet op te lossen is. Retourneer `nullptr` vanuit `GetEntity` wanneer de resource niet gelezen kan worden. Aspose.Slides gaat door met het verwerken van de SVG zonder die resource waar mogelijk.

Een fallback‑stream kan worden geretourneerd voor een ontbrekende resource, maar de inhoud moet compatibel zijn met het gevraagde resource‑type. Bijvoorbeeld, retourneer alleen een afbeeldings‑stream voor een ontbrekende afbeelding, niet voor een lettertype of stylesheet.

{{% alert title="Beveiliging" color="warning" %}}
Los geen willekeurige bestandspaden of onbeperkte netwerk‑URL's op uit onbetrouwbare SVG‑bestanden. Beperk toegestane schema's, mappen en hosts. Pas voor netwerk‑resources ook time‑outs, limieten op respons‑grootte en content‑validatie toe.
{{% /alert %}}

## **SVG converteren naar een set van vormen**
Aspose.Slides kan een SVG converteren naar een set van vormen, vergelijkbaar met de overeenkomstige functionaliteit in PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

Deze functionaliteit wordt geleverd door een overload van de [AddGroupShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapecollection/)‑methode van de [IShapeCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapecollection/)‑interface die een [ISvgImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isvgimage/)‑object als eerste argument accepteert.

De volgende C++‑voorbeeldcode laat zien hoe deze methode te gebruiken om een SVG‑bestand te converteren naar een set van vormen:

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

// Nieuwe presentatie aanmaken
auto presentation = System::MakeObject<Presentation>();

// Inhoud van het SVG-bestand lezen
auto svgContent = File::ReadAllText(svgFileName);

// SvgImage-object aanmaken
auto svgImage = System::MakeObject<SvgImage>(svgContent);

// Diaformaat ophalen
auto slideSize = presentation->get_SlideSize()->get_Size();

// Converteer de SVG-afbeelding naar een groep vormen en schaal deze naar de dia-afmeting
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// Presentatie opslaan in PPTX-formaat
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **Afbeeldingen toevoegen als EMF aan dia's**
Aspose.Slides voor C++ stelt je in staat om EMF‑afbeeldingen te genereren vanuit Excel‑werkbladen met Aspose.Cells en deze toe te voegen aan presentatiedia's.

De volgende C++‑voorbeeldcode laat zien hoe dit te doen:

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

// Aspose.Cells voor C++ moet worden gestart voordat een van zijn types wordt gebruikt.
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

## **Afbeeldingen vervangen in de afbeeldingsverzameling**

Aspose.Slides laat je afbeeldingen die in de afbeeldingsverzameling van een presentatie zijn opgeslagen vervangen, inclusief afbeeldingen die door dia‑vormen worden gebruikt. Deze sectie beschrijft verschillende manieren om afbeeldingen in de verzameling bij te werken. Je kunt een afbeelding vervangen met ruwe byte‑gegevens, een [IImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iimage/)‑instance, of een andere afbeelding die al bestaat in de verzameling.

Volg de onderstaande stappen:

1. Laad het presentatie‑bestand dat afbeeldingen bevat met de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse.  
2. Laad een nieuwe afbeelding vanuit een bestand in een byte‑array.  
3. Vervang de doel‑afbeelding door de nieuwe afbeelding met behulp van de byte‑array.  
4. In de tweede aanpak laad je de afbeelding in een [IImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iimage/)‑object en vervang je de doel‑afbeelding door dat object.  
5. In de derde aanpak vervang je de doel‑afbeelding door een afbeelding die al bestaat in de afbeeldingsverzameling van de presentatie.  
6. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

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
Met Aspose's gratis [Text to GIF](https://products.aspose.app/slides/nl/text-to-gif)‑converter kun je eenvoudig tekst animeren en GIF's uit tekst maken. 
{{% /alert %}}

## **FAQ**

**Blijft de oorspronkelijke resolutie van de afbeelding behouden na invoegen?**

Ja. De bron‑pixels worden behouden, maar het uiteindelijke uiterlijk hangt af van hoe het [afbeeldingselement](/slides/nl/cpp/picture-frame/) wordt geschaald op de dia en van eventuele compressie bij het opslaan.

**Wat is de beste manier om hetzelfde logo in tientallen dia's tegelijk te vervangen?**

Plaats het logo op de master‑dia of een lay‑out en vervang het in de afbeeldingsverzameling van de presentatie — de wijzigingen worden doorgevoerd naar alle elementen die die bron gebruiken.

**Kan een ingevoegde SVG worden omgezet in bewerkbare vormen?**

Ja. Je kunt een SVG converteren naar een groep vormen; daarna worden individuele delen bewerkbaar met de standaard vorm‑eigenschappen.

**Hoe stel ik een afbeelding in als achtergrond voor meerdere dia's tegelijk?**

[Wijs de afbeelding toe als achtergrond](/slides/nl/cpp/presentation-background/) op de master‑dia of de betreffende lay‑out — alle dia's die die master/lay‑out gebruiken, erven de achtergrond.

**Hoe voorkom ik dat een presentatie te groot wordt door veel afbeeldingen?**

Herbruik één enkele afbeeldingsbron in plaats van duplicaten, kies redelijke resoluties, pas compressie toe bij het opslaan, en beheer herhaalde grafische elementen op de master waar passend.