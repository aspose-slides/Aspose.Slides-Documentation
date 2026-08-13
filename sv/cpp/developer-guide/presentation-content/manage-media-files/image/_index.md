---
title: Optimera bildhantering i presentationer med C++
linktitle: Hantera bilder
type: docs
weight: 10
url: /sv/cpp/image/
keywords:
- lägga till bild
- lägga till bild
- lägga till bitmap
- ersätta bild
- ersätta bild
- från webben
- bakgrund
- lägga till PNG
- lägga till JPG
- lägga till SVG
- externa SVG-resurser
- SVG-resolver
- länkade SVG-bilder
- SVG-teckensnitt
- lägga till EMF
- lägga till WMF
- lägga till TIFF
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Effektivisera bildhantering i PowerPoint och OpenDocument med Aspose.Slides för C++, optimera prestanda och automatisera ditt arbetsflöde."
---
## **Introduktion**

Bilder gör presentationer mer engagerande och visuellt tilltalande. I Microsoft PowerPoint kan du infoga bilder på bilderna från filer, internet eller andra källor. På samma sätt låter Aspose.Slides dig lägga till bilder i presentationsbilder på flera sätt. 

{{% alert title="Tip" color="info" %}} 
Aspose erbjuder gratis konverterare—[JPEG till PowerPoint](https://products.aspose.app/slides/sv/import/jpg-to-ppt) och [PNG till PowerPoint](https://products.aspose.app/slides/sv/import/png-to-ppt)—som låter dig snabbt skapa presentationer från bilder. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
Om du vill lägga till en bild som en bildram—särskilt om du planerar att ändra storlek, applicera effekter eller använda andra standardformateringsalternativ—se [Picture Frame](/slides/sv/cpp/picture-frame/). 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
Du kan konvertera bilder från ett format till ett annat. Se följande sidor: konvertera [image to JPG](https://products.aspose.com/slides/sv/cpp/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/sv/cpp/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/sv/cpp/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/sv/cpp/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/sv/cpp/conversion/png-to-svg/), och [SVG to PNG](https://products.aspose.com/slides/sv/cpp/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides stöder bilder i populära format som JPEG, PNG, BMP, GIF och andra. 

## **Lägg till bilder som lagras lokalt till bilder**

Du kan lägga till en eller flera bilder som lagras på din dator till en presentationsbild. Följande C++-exempelkod visar hur du lägger till en bild på en bild:

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

## **Lägg till bilder från webben till bilder**

Om bilden du vill lägga till på en bild inte lagras på din dator kan du lägga till den direkt från webben. 

Följande C++-exempelkod visar hur du lägger till en bild från webben till en bild:

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

## **Lägg till bilder till bildmästaren**

En bildmästare lagrar och styr information såsom tema och layout för de bilder som använder den. När du lägger till en bild i en bildmästare visas bilden på varje bild som baseras på den mästaren. 

Följande C++-exempelkod visar hur du lägger till en bild i en bildmästare:

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

## **Lägg till bilder som bildbakgrunder**

Du kan använda en bild som bakgrund för en eller flera bilder. För detaljer, se *[Setting Images as Backgrounds for Slides](/slides/sv/cpp/presentation-background/#setting-images-as-background-for-slides)*.

## **Lägg till SVG till presentationer**

SVG-innehåll kan läggas till i en presentation med klassen [SvgImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/svgimage/). Det resulterande [ISvgImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isvgimage/)-objektet kan sedan läggas till i presentationens bildsamling och användas för att skapa en bildram. 

Följande C++-exempel importerar en självständig SVG-sträng. Alla bilder, stilar och andra resurser som används av denna SVG är inbäddade direkt i SVG-innehållet.

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

## **Importera SVG-innehåll med externa resurser**

SVG-filer som exporteras från designverktyg, diagramredigerare, ikonsystem och webb-pipelines kan referera till resurser som lagras utanför SVG-dokumentet. Till exempel kan en SVG innehålla en bildlänk som `images/photo.png`, ett CSS `url(...)`-värde eller en teckensnitt-URL. 

För att importera sådant SVG-innehåll, skapa en implementation av [IExternalResourceResolver](https://reference.aspose.com/slides/sv/cpp/aspose.slides.import/iexternalresourceresolver/) och skicka den, tillsammans med en bas-URI, till en lämplig `SvgImage`-konstruktor. Bas-URI:n identifierar platsen för SVG-dokumentet och används för att lösa relativa länkar. 

Gränssnittet [ISvgImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isvgimage/) ger åtkomst till information om den importerade SVG:n: 

- `get_SvgContent()` returnerar SVG-markupen som en sträng. 
- `get_SvgData()` returnerar SVG-innehållet som en bytearray. 
- `get_BaseUri()` returnerar bas-URI:n som används för relativa länkar. 
- `get_ExternalResourceResolver()` returnerar resolvern som tilldelats SVG-bilden. 

### **Implementera en extern resurshanterare**

Resolvern har två metoder: 

- [ResolveUri](https://reference.aspose.com/slides/sv/cpp/aspose.slides.import/iexternalresourceresolver/resolveuri/) kombinerar bas-URI:n och en relativ resurslänk och returnerar en absolut URI. Returnera en null-sträng när länken inte kan lösas eller inte är tillåten. 
- [GetEntity](https://reference.aspose.com/slides/sv/cpp/aspose.slides.import/iexternalresourceresolver/getentity/) returnerar en läsbar ström för en absolut resurs-URI. Returnera `nullptr` när resursen saknas, blockeras eller är otillgänglig. En reservström kan också returneras när det är lämpligt. 

Följande resolver laddar länkade resurser endast från en tillåten lokal katalog. Nätverksresurser och sökvägar utanför den tillåtna katalogen blockeras. En valfri reservbild returneras för olösta bildlänkar.

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

        // Denna resolver tillåter avsiktligt endast lokala filer.
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

        // Använd en reserv endast för bildresurser. Att returnera en bildström
        // för ett saknat teckensnitt eller en stilmall skulle inte vara giltigt.
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

### **Lös upp länkade resurser under SVG-import**

Anta att `assets/diagram.svg` innehåller en relativ referens såsom: 

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Följande C++-exempel skickar SVG-filens URI som bas-URI och tillhandahåller en anpassad resolver. Resovlern konverterar den relativa bildlänken till en absolut URI och returnerar en ström som innehåller den länkade resursen medan Aspose.Slides bearbetar SVG:n. 

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

// Bas-URI:n representerar platsen för SVG-dokumentet.
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

`SvgImage`-klassen erbjuder också överlagrade konstruktorer som accepterar SVG-data som en bytearray eller en ström, tillsammans med en extern resurshanterare och en bas-URI. 

{{% alert title="Important" color="warning" %}}
Resurshanteraren gör externa resurser tillgängliga medan Aspose.Slides bearbetar och renderar SVG:n. Den ändrar inte original‑SVG‑markupen eller bäddar automatiskt in de lösta resurserna i den. 

När ett `ISvgImage` läggs till i presentationens bildsamling kan PPTX-filen innehålla både den ursprungliga SVG-representationen och en rasterreservbild. En länkad resurs kan visas i den genererade reservbilden medan en relativ länk som `images/photo.png` förblir oförändrad i den lagrade SVG:n. En applikation som renderar den inhemska SVG-representationen kan därför utelämna det länkade innehållet när den ursprungliga externa resursen är otillgänglig. 
{{% /alert %}}

### **Skapa en portabel SVG-bild**

För att skapa en SVG-bild som inte är beroende av externa filer, gör SVG:n självständig innan du skapar `SvgImage`. Till exempel, ersätt länkade bild‑URL:er med `data:`‑URI:er som innehåller bilddata: 

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Efter att alla nödvändiga resurser har bäddats in i SVG-innehållet, skapa `SvgImage`, lägg till det i presentationens bildsamling och infoga det i en bildram som visas i föregående exempel. 

### **Hantera saknade eller blockerade resurser**

Returnera en null-sträng från `ResolveUri` när en resurs‑URI är ogiltig, förbjuden eller inte kan lösas. Returnera `nullptr` från `GetEntity` när resursen inte kan läsas. Aspose.Slides fortsätter att bearbeta SVG:n utan den resursen när det är möjligt. 

En reservström kan returneras för en saknad resurs, men dess innehåll måste vara kompatibelt med den begärda resurstypen. Till exempel, returnera en bildström endast för en saknad bild, inte för ett teckensnitt eller en stilmall. 

{{% alert title="Security" color="warning" %}}
Lös inte godtyckliga filsökvägar eller obegränsade nätverks‑URL:er från opålitliga SVG-filer. Begränsa tillåtna scheman, kataloger och värdar. För nätverksresurser, tillämpa även anslutningstidsgränser, svarsstorleksbegränsningar och innehållsvalidering. 
{{% /alert %}}

## **Konvertera SVG till en mängd former**
Aspose.Slides kan konvertera en SVG till en mängd former, liknande motsvarande funktionalitet i PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

Denna funktionalitet tillhandahålls av en överlagring av metoden [AddGroupShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishapecollection/) i gränssnittet [IShapeCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishapecollection/) som tar ett [ISvgImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isvgimage/)‑objekt som sitt första argument. 

Följande C++-exempelkod visar hur du använder denna metod för att konvertera en SVG-fil till en mängd former:

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

// Käll SVG-filnamn
auto svgFileName = System::String(u"sample.svg");

// Utdata presentationsfilnamn
auto outPptxPath = System::String(u"presentation.pptx");

// Skapa en ny presentation
auto presentation = System::MakeObject<Presentation>();

// Läs SVG-filens innehåll
auto svgContent = File::ReadAllText(svgFileName);

// Skapa ett SvgImage-objekt
auto svgImage = System::MakeObject<SvgImage>(svgContent);

// Hämta bildens storlek
auto slideSize = presentation->get_SlideSize()->get_Size();

// Konvertera SVG-bilden till en grupp former och skala den till bildens storlek
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// Spara presentationen i PPTX-format
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **Lägg till bilder som EMF till bilder**
Aspose.Slides för C++ låter dig generera EMF‑bilder från Excel‑arbetsblad med Aspose.Cells och lägga till dem i presentationsbilder. 

Följande C++-exempelkod visar hur du gör detta:

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

// Aspose.Cells för C++ måste startas innan någon av dess typer används.
Aspose::Cells::Startup();

auto workbook = Aspose::Cells::Workbook(u"chart.xls");
auto sheet = workbook.GetWorksheets().Get(0);

// Rendera kalkylbladet som EMF.
auto options = Aspose::Cells::ImageOrPrintOptions();
options.SetHorizontalResolution(200);
options.SetVerticalResolution(200);
options.SetImageType(Aspose::Cells::Drawing::ImageType::Emf);

auto sheetRender = Aspose::Cells::SheetRender(sheet, options);

auto presentation = System::MakeObject<Presentation>();
presentation->get_Slides()->RemoveAt(0);

for (auto pageIndex = 0; pageIndex < sheetRender.GetPageCount(); pageIndex++)
{
    // Aspose.Cells returnerar den renderade sidan som en buffer, som Aspose.Slides lägger till som en bild.
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

## **Byt ut bilder i bildsamlingen**
Aspose.Slides låter dig ersätta bilder som lagras i en presentations bildsamling, inklusive bilder som används av bildformer. Detta avsnitt beskriver flera sätt att uppdatera bilder i samlingen. Du kan ersätta en bild med rå byte‑data, en [IImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iimage/)‑instans eller en annan bild som redan finns i samlingen. 

1. Läs in presentationsfilen som innehåller bilder med klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/). 
1. Läs in en ny bild från en fil till en bytearray. 
1. Ersätt målbilden med den nya bilden med bytearrayen. 
1. I det andra tillvägagångssättet, läs in bilden i ett [IImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iimage/)-objekt och ersätt målbilden med det objektet. 
1. I det tredje tillvägagångssättet, ersätt målbilden med en bild som redan finns i presentationens bildsamling. 
1. Skriv den modifierade presentationen som en PPTX-fil. 

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

// Instansiera Presentation-klassen som representerar en presentationsfil.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Det första sättet.
auto imageData = File::ReadAllBytes(u"image0.jpeg");
auto oldImage = presentation->get_Image(0);
oldImage->ReplaceImage(imageData);

// Det andra sättet.
auto newImage = Images::FromFile(u"image1.png");
oldImage = presentation->get_Image(1);
oldImage->ReplaceImage(newImage);
newImage->Dispose();

// Det tredje sättet.
oldImage = presentation->get_Image(2);
oldImage->ReplaceImage(presentation->get_Image(3));

// Spara presentationen till en fil.
presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Med Asposes gratis [Text to GIF](https://products.aspose.app/slides/sv/text-to-gif)-konverterare kan du enkelt animera text och skapa GIF‑ar från text. 
{{% /alert %}}

## **FAQ**

**Behåller den ursprungliga bildupplösningen sin integritet efter infogning?**

Ja. Källpixlarna bevaras, men det slutgiltiga utseendet beror på hur [picture](/slides/sv/cpp/picture-frame/) skalas på bilden och eventuell kompression som tillämpas vid sparande.

**Vad är det bästa sättet att ersätta samma logotyp på dussintals bilder på en gång?**

Placera logotypen på mästarsliden eller en layout och ersätt den i presentationens bildsamling—uppdateringar sprids till alla element som använder den resursen.

**Kan en infogad SVG konverteras till redigerbara former?**

Ja. Du kan konvertera en SVG till en grupp av former, varpå enskilda delar blir redigerbara med standardformsegenskaper.

**Hur kan jag sätta en bild som bakgrund för flera bilder på en gång?**

[Tilldela bilden som bakgrund](/slides/sv/cpp/presentation-background/) på mästarsliden eller den relevanta layouten—alla bilder som använder den mästaren/layouten kommer att ärva bakgrunden.

**Hur förhindrar jag att en presentation blir för stor på grund av många bilder?**

Återanvänd en enda bildresurs istället för dubbletter, välj rimliga upplösningar, använd kompression vid sparande och håll återkommande grafik på mästaren där det är lämpligt.