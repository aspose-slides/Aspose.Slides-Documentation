---
title: Konvertera PowerPoint-presentationer till Markdown i C++
linktitle: PowerPoint till Markdown
type: docs
weight: 140
url: /sv/cpp/convert-powerpoint-to-markdown/
keywords:
- konvertera PowerPoint
- konvertera presentation
- konvertera bild
- konvertera PPT
- konvertera PPTX
- PowerPoint till MD
- presentation till MD
- bild till MD
- PPT till MD
- PPTX till MD
- spara PowerPoint som Markdown
- spara presentation som Markdown
- spara bild som Markdown
- spara PPT som MD
- spara PPTX som MD
- exportera PPT till MD
- exportera PPTX till MD
- Markdown bildexport
- CDN bildlänkar
- PowerPoint
- presentation
- Markdown
- C++
- Aspose.Slides
description: "Konvertera PPT- och PPTX-presentationer till Markdown i C++ och kontrollera var exporterade bitmap-, metafil- och SVG-bilder sparas och refereras."
---
## **Översikt**

Aspose.Slides för C++ kan konvertera PPT- och PPTX-presentationer till Markdown för dokumentation, statiska webbplatser, innehållsmigrering och versionskontrollarbetsflöden. Du kan välja en Markdown‑variant, kontrollera hur bildinnehåll renderas och bestämma var exporterade bilder sparas och hur den genererade Markdown‑referensen pekar på dem.

Som standard använder Markdown‑export text‑endast utdata. För att exportera visuellt innehåll, ställ in metoden [MarkdownSaveOptions::set_ExportType](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/markdownsaveoptions/set_exporttype/) till värdet `Sequential` eller `Visual` från uppräkningen [MarkdownExportType](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/markdownexporttype/). `Sequential` renderar bildobjekt separat och i ordning, medan `Visual` behåller grupperade objekt tillsammans för att bevara deras visuella relation. Värdet `TextOnly` avger inte bildresurser, så bild‑spar‑händelserna anropas inte i det läget.

## **Konvertera en presentation till Markdown**

Läs in källfilen med klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) och anropa sedan metoden [Presentation::Save](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/save/) med värdet `Md` från uppräkningen [SaveFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/saveformat/).

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.md", SaveFormat::Md);
```

## **Välj en Markdown‑variant**

[MarkdownSaveOptions::set_Flavor](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/markdownsaveoptions/set_flavor/)‑metoden styr vilken Markdown‑specifikation som används för utdata. Uppräkningen [Flavor](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/flavor/) innehåller CommonMark, GitHub Flavored Markdown och andra stödda varianter.

Följande exempel exporterar en presentation som CommonMark:

```cpp
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/Flavor.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_Flavor(Flavor::CommonMark);

presentation->Save(u"presentation.md", SaveFormat::Md, options);
```

## **Exportera bilder med standardbeteende för lokalt sparande**

Klassen [MarkdownSaveOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/markdownsaveoptions/) tillhandahåller två metoder för att konfigurera lokalt sparade bilder:

- [set_BasePath](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) anger baskatalogen för Markdown‑dokumentet och dess resurser.
- [set_ImagesSaveFolderName](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/) anger bildens underkatalog. Standardvärdet är `Images`.

Följande exempel renderar visuellt innehåll, skriver bilder till `output/assets` och skapar relativa bildreferenser i Markdown‑dokumentet:

```cpp
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/MarkdownExportType.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>
#include <system/io/directory.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

const System::String outputDirectory = u"output";
Directory::CreateDirectory_(outputDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_ExportType(MarkdownExportType::Visual);
options->set_BasePath(outputDirectory);
options->set_ImagesSaveFolderName(u"assets");

auto markdownPath = Path::Combine(outputDirectory, u"presentation.md");
presentation->Save(markdownPath, SaveFormat::Md, options);
```

Detta beteende fungerar också som reserv när en anpassad bild‑spar‑hanterare returnerar `false`.

## **Anpassa bildsparande och Markdown‑länkar**

Använd händelsen `MarkdownSaveOptions::ImageSaving` för bitmap‑ och metafilresurser som inte är SVG och som avges under Markdown‑export. Dess delegat [MarkdownImageSavingHandler](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/markdownsaveoptions/markdownimagesavinghandler/) får objektet [IImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iimage/) , dess [ImageFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imageformat/) och den genererade Markdown‑länken som en `System::String&`‑parameter. Spara eller ladda upp bilden med det angivna formatet och ersätt `link` med den referens som ska finnas i Markdown‑utdata.

Resurser som avges i SVG‑format hanteras separat. Prenumerera på händelsen `MarkdownSaveOptions::SvgImageSaving`, vars delegat [MarkdownSvgImageSavingHandler](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/markdownsaveoptions/markdownsvgimagesavinghandler/) får ett [ISvgImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isvgimage/)‑objekt och parametern `System::String& link`. En SVG har inget `ImageFormat`‑argument; skriv eller ladda upp dess XML‑data via metoden [ISvgImage::get_SvgData](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isvgimage/get_svgdata/) istället. Beroende på exportläge och visuell gruppering kan en SVG i källpresentationen rasteriseras eller kombineras med annat innehåll; den resulterande icke‑SVG‑resursen skickas sedan till `ImageSaving`. Prenumerera på båda händelserna när varje exporterad visuell resurs kräver anpassad bearbetning.

Handlerns returvärde bestämmer vem som bearbetar bilden:

- Returnera `true` efter att handlern har sparat, laddat upp, transformerat eller på annat sätt bearbetat bilden och tilldelat ett giltigt värde till `link`. Aspose.Slides skriver det värdet till Markdown‑dokumentet och utför inte den förvalda lokala sparningen.
- Returnera `false` för att låta Aspose.Slides spara bilden lokalt och generera dess länk enligt [MarkdownSaveOptions::set_BasePath](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) och [MarkdownSaveOptions::set_ImagesSaveFolderName](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/).

{{% alert color="warning" title="Important" %}}
En handler som returnerar `true` tar ansvar för bilden. Om den returnerar `true` utan att tilldela en giltig, icke‑tom länk, misslyckas exporten med ett `InvalidOperationException`.
{{% /alert %}}

### **Spara bilder till en CDN‑ursprungs katalog och använd externa URL:er**

Följande exempel behandlar `cdn-origin/presentations/quarterly-report` som en monterad eller synkroniserad CDN‑ursprungs katalog. Varje handler extraherar det genererade filnamnet, sparar bilden till den anpassade katalogen och ersätter den genererade lokala referensen med en publik CDN‑URL. Exemplet utför ingen nätverksuppladdning: URL:en blir giltig först när katalogen är monterad som CDN‑ursprung eller dess filer publiceras till CDN. För objektlagring, ersätt fil‑system‑skrivningen med lagrings‑SDK:ns uppladdningsoperation och tilldela `link` först efter att uppladdningen lyckats.

```cpp
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/MarkdownExportType.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <functional>
#include <system/io/directory.h>
#include <system/io/file.h>
#include <system/io/path.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

const System::String outputDirectory = u"output";
const System::String publicBaseUrl = u"https://cdn.example.com/presentations/quarterly-report";
const System::String storageDirectory = Path::Combine(u"cdn-origin", u"presentations", u"quarterly-report");
Directory::CreateDirectory_(outputDirectory);
Directory::CreateDirectory_(storageDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_ExportType(MarkdownExportType::Visual);
options->set_BasePath(outputDirectory);
options->set_ImagesSaveFolderName(u"fallback-images");

options->ImageSaving.connect(std::function<bool(System::SharedPtr<IImage>, ImageFormat, System::String&)>([storageDirectory, publicBaseUrl](System::SharedPtr<IImage> image, ImageFormat format, System::String& link) -> bool
{
    if (image->get_Width() < 128 || image->get_Height() < 128)
    {
        return false;
    }

    auto urlCompatibleLink = link.Replace(u"\\", u"/");
    auto fileName = urlCompatibleLink.Substring(urlCompatibleLink.LastIndexOf(u'/') + 1);
    auto storagePath = Path::Combine(storageDirectory, fileName);
    image->Save(storagePath, format);
    link = publicBaseUrl + u"/" + System::Uri::EscapeDataString(fileName);
    return true;
}));

options->SvgImageSaving.connect(std::function<bool(System::SharedPtr<ISvgImage>, System::String&)>([storageDirectory, publicBaseUrl](System::SharedPtr<ISvgImage> svgImage, System::String& link) -> bool
{
    auto urlCompatibleLink = link.Replace(u"\\", u"/");
    auto fileName = urlCompatibleLink.Substring(urlCompatibleLink.LastIndexOf(u'/') + 1);
    auto storagePath = Path::Combine(storageDirectory, fileName);
    File::WriteAllBytes(storagePath, svgImage->get_SvgData());
    link = publicBaseUrl + u"/" + System::Uri::EscapeDataString(fileName);
    return true;
}));

auto markdownPath = Path::Combine(outputDirectory, u"presentation.md");
presentation->Save(markdownPath, SaveFormat::Md, options);
```

Bitmap‑handlern returnerar avsiktligt `false` för bilder mindre än 128 × 128 pixlar, så Aspose.Slides sparar dessa bilder till `output/fallback-images` med standardbeteendet. Större bitmap‑ och metafilresurser, liksom SVG‑resurser, hanteras av den anpassade koden. Till exempel blir en genererad lokal referens som `fallback-images/image1.png` `https://cdn.example.com/presentations/quarterly-report/image1.png`. Handlers använder operativsystemets sökvägar endast när de skriver filer; länkar som skrivs till Markdown använder snedstreck och URL‑kodade filnamn. Tillämpa samma regel när du bygger relativa länkar: använd `/`, inte plattforms‑specifika katalogseparatorer.

## **FAQ**

**Kan en handler bearbeta både raster‑bilder och SVG‑bilder?**

Nej. Använd `MarkdownSaveOptions::ImageSaving` för bitmap‑ och metafilresurser som avges och `MarkdownSaveOptions::SvgImageSaving` för resurser som avges som SVG. Den förstnämnda ger ett [IImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iimage/)‑objekt och ett [ImageFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imageformat/); den senare ger ett [ISvgImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isvgimage/)‑objekt vars SVG‑data kan läsas med [ISvgImage::get_SvgData](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isvgimage/get_svgdata/). En käll‑SVG som rasteriseras under export bearbetas av `ImageSaving` istället.

**Vad händer när en bild‑spar‑handler returnerar `false`?**

Aspose.Slides använder sitt förvalda lokala sparbeteende. Bildens plats och den genererade referensen styrs av [MarkdownSaveOptions::set_BasePath](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) och [MarkdownSaveOptions::set_ImagesSaveFolderName](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/).

**Kan en handler tillhandahålla en URL utan att spara bilden lokalt?**

Ja. Handlern kan ladda upp bilden till objektlagring eller skicka den till en annan tjänst, tilldela den resulterande URL:en till `link` och returnera `true`. Handlern måste slutföra bearbetningen själv; att returnera `true` förhindrar den förvalda lokala sparningen.

**Varför kastar Markdown‑export ett `InvalidOperationException` från en handler?**

Detta undantag uppstår när handlern returnerar `true` men inte tillhandahåller en giltig länk. Tilldela den relativa sökvägen eller externa URL:en som ska skrivas till Markdown innan du returnerar `true`.

**Vilken sökvägsseparator bör bildlänkar använda?**

Använd snedstreck (`/`) i Markdown‑länkar och URL:er. Använd `Path::Combine` endast för filsystemssökvägar och bygg eller normalisera Markdown‑referensen separat.

**Behålls hyperlänkar vid Markdown‑export?**

Ja. Text‑[hyperlinks](/slides/sv/cpp/manage-hyperlinks/) bevaras som standard‑Markdown‑länkar. Bild‑[transitions](/slides/sv/cpp/slide-transition/) och [animations](/slides/sv/cpp/powerpoint-animation/) konverteras inte.

**Kan presentationer konverteras till Markdown parallellt?**

Du kan bearbeta olika presentationsfiler parallellt, men dela inte samma [Presentation]‑instans mellan trådar. Följ [multithreading guidelines](/slides/sv/cpp/multithreading/) och använd en separat instans för varje fil.