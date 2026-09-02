---
title: PowerPoint‑presentaties converteren naar Markdown in C++
linktitle: PowerPoint naar Markdown
type: docs
weight: 140
url: /nl/cpp/convert-powerpoint-to-markdown/
keywords:
- PowerPoint converteren
- presentatie converteren
- slide converteren
- PPT converteren
- PPTX converteren
- PowerPoint naar MD
- presentatie naar MD
- slide naar MD
- PPT naar MD
- PPTX naar MD
- PowerPoint opslaan als Markdown
- presentatie opslaan als Markdown
- slide opslaan als Markdown
- PPT opslaan als MD
- PPTX opslaan als MD
- PPT exporteren naar MD
- PPTX exporteren naar MD
- Markdown‑afbeeldingsexport
- CDN‑afbeeldingslinks
- PowerPoint
- presentatie
- Markdown
- C++
- Aspose.Slides
description: "Convert PPT en PPTX presentaties naar Markdown in C++ en bepaal waar geëxporteerde bitmap-, metafile- en SVG‑afbeeldingen worden opgeslagen en naar verwezen."
---
## **Overzicht**

Aspose.Slides voor C++ kan PPT‑ en PPTX‑presentaties naar Markdown converteren voor documentatie, statische sites, content‑migratie en versie‑beheerworkflows. Je kunt een Markdown‑variant kiezen, bepalen hoe de slide‑inhoud wordt gerenderd en besluiten waar geëxporteerde afbeeldingen worden opgeslagen en hoe de gegenereerde Markdown ernaar verwijst.

Standaard gebruikt de Markdown‑export alleen tekstoutput. Om visuele inhoud te exporteren, stel je de [MarkdownSaveOptions::set_ExportType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/markdownsaveoptions/set_exporttype/)‑methode in op de `Sequential`‑ of `Visual`‑waarde uit de [MarkdownExportType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/markdownexporttype/)‑enumeratie. `Sequential` rendert slide‑items afzonderlijk en in volgorde, terwijl `Visual` gegroepeerde items samenhoudt om hun visuele relatie te behouden. De `TextOnly`‑waarde geeft geen afbeeldingsbronnen weer, zodat de afbeelding‑opslaanevenementen in die modus niet worden aangeroepen.

## **Een presentatie naar Markdown converteren**

Laad het bronbestand met de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse en roep vervolgens de [Presentation::Save](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/save/)‑methode aan met de `Md`‑waarde uit de [SaveFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/saveformat/)‑enumeratie.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.md", SaveFormat::Md);
```

## **Selecteer een Markdown‑variant**

De [MarkdownSaveOptions::set_Flavor](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/markdownsaveoptions/set_flavor/)‑methode bepaalt de Markdown‑specificatie die voor de output wordt gebruikt. De [Flavor](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/flavor/)‑enumeratie omvat CommonMark, GitHub Flavored Markdown en andere ondersteunde varianten.

Het volgende voorbeeld exporteert een presentatie als CommonMark:

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

## **Afbeeldingen exporteren met het standaard lokaal‑opslaan‑gedrag**

De [MarkdownSaveOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/markdownsaveoptions/)‑klasse biedt twee methoden om lokaal opgeslagen afbeeldingen te configureren:

- [set_BasePath](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) specificeert de basisdirectory voor het Markdown‑document en de bijbehorende resources.
- [set_ImagesSaveFolderName](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/) specificeert de subdirectory voor afbeeldingen. De standaardwaarde is `Images`.

Het volgende voorbeeld rendert visuele inhoud, schrijft afbeeldingen naar `output/assets` en maakt relatieve afbeeldingsverwijzingen aan in het Markdown‑document:

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

Dit gedrag dient ook als fallback wanneer een aangepaste afbeelding‑opslaanevent `false` retourneert.

## **Afbeeldingsopslag en Markdown‑links aanpassen**

Gebruik het `MarkdownSaveOptions::ImageSaving`‑event voor niet‑SVG‑bitmap‑ en metafile‑resources die tijdens de Markdown‑export worden uitgegeven. Zijn [MarkdownImageSavingHandler](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/markdownsaveoptions/markdownimagesavinghandler/)‑delegate ontvangt het [IImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iimage/)‑object, zijn [ImageFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imageformat/) en de gegenereerde Markdown‑link als een `System::String&`‑parameter. Sla de afbeelding op of upload deze met het opgegeven formaat, en vervang `link` door de referentie die in de Markdown‑output moet verschijnen.

Resources die in SVG‑formaat worden uitgegeven worden apart behandeld. Abonneer je op het `MarkdownSaveOptions::SvgImageSaving`‑event, waarvan de [MarkdownSvgImageSavingHandler](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/markdownsaveoptions/markdownsvgimagesavinghandler/)‑delegate een [ISvgImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isvgimage/)‑object en de `System::String& link`‑parameter ontvangt. Een SVG heeft geen `ImageFormat`‑argument; schrijf of upload in plaats daarvan de XML‑gegevens via de [ISvgImage::get_SvgData](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isvgimage/get_svgdata/)‑methode. Afhankelijk van de exportmodus en visuele groepering kan een SVG in de bronpresentatie gerasterd of gecombineerd met andere inhoud worden; de resulterende niet‑SVG‑resource wordt vervolgens doorgegeven aan `ImageSaving`. Abonneer je op beide events wanneer elke geëxporteerde visuele resource aangepaste verwerking vereist.

De retourwaarde van de handler bepaalt wie de afbeelding verwerkt:

- Retourneer `true` nadat de handler de afbeelding heeft opgeslagen, geüpload, getransformeerd of anderszins verwerkt en een geldige waarde aan `link` heeft toegekend. Aspose.Slides schrijft die waarde naar het Markdown‑document en voert de standaard lokale opslag niet uit.
- Retourneer `false` om Aspose.Slides de afbeelding lokaal te laten opslaan en de link te genereren op basis van [MarkdownSaveOptions::set_BasePath](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) en [MarkdownSaveOptions::set_ImagesSaveFolderName](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/).

{{% alert color="warning" title="Important" %}}
Een handler die `true` retourneert, neemt de verantwoordelijkheid voor de afbeelding op zich. Als deze `true` retourneert zonder een geldige, niet‑lege link toe te wijzen, faalt de export met een `InvalidOperationException`.
{{% /alert %}}

### **Afbeeldingen opslaan in een CDN‑origin‑directory en externe URL’s gebruiken**

Het volgende voorbeeld beschouwt `cdn-origin/presentations/quarterly-report` als een aangekoppelde of gesynchroniseerde CDN‑origin‑directory. Elke handler haalt de gegenereerde bestandsnaam op, slaat de afbeelding op in die aangepaste directory en vervangt de gegenereerde lokale referentie door een openbare CDN‑URL. Het voorbeeld voert zelf geen netwerkupload uit: de URL wordt pas geldig nadat de directory is aangekoppeld als CDN‑origin of de bestanden zijn gepubliceerd naar het CDN. Voor object‑opslag vervang je het schrijven naar het bestandssysteem door de upload‑operatie van de opslag‑SDK en ken je `link` pas toe nadat de upload is geslaagd.

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

De bitmap‑handler retourneert opzettelijk `false` voor afbeeldingen kleiner dan 128 × 128 pixels, zodat Aspose.Slides die afbeeldingen opslaat in `output/fallback-images` met het standaardgedrag. Grotere bitmap‑ en metafile‑resources, evenals SVG‑resources, worden afgehandeld door de aangepaste code. Bijvoorbeeld, een gegenereerde lokale referentie zoals `fallback-images/image1.png` wordt `https://cdn.example.com/presentations/quarterly-report/image1.png`. De handlers gebruiken besturingssysteem‑paths alleen bij het schrijven van bestanden; links die naar Markdown worden geschreven gebruiken schuine strepen en URL‑geëscapte bestandsnamen. Pas dezelfde regel toe bij het bouwen van relatieve links: gebruik `/`, niet de platform‑specifieke scheidingsteken.

## **FAQ**

**Kan één handler zowel raster‑afbeeldingen als SVG‑afbeeldingen verwerken?**

Nee. Gebruik `MarkdownSaveOptions::ImageSaving` voor uitgegeven bitmap‑ en metafile‑resources en `MarkdownSaveOptions::SvgImageSaving` voor resources die als SVG worden uitgegeven. De eerste levert een [IImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iimage/)‑object en een [ImageFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imageformat/); de tweede levert een [ISvgImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isvgimage/)‑object waarvan de SVG‑data kan worden gelezen via [ISvgImage::get_SvgData](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isvgimage/get_svgdata/). Een bron‑SVG die tijdens export wordt gerasterd, wordt in plaats daarvan door `ImageSaving` verwerkt.

**Wat gebeurt er wanneer een afbeelding‑opslaanevent `false` retourneert?**

Aspose.Slides gebruikt zijn standaard lokaal‑opslaan‑gedrag. De locatie van de afbeelding en de gegenereerde referentie worden bepaald door [MarkdownSaveOptions::set_BasePath](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) en [MarkdownSaveOptions::set_ImagesSaveFolderName](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/).

**Kan een handler een URL geven zonder de afbeelding lokaal op te slaan?**

Ja. De handler kan de afbeelding uploaden naar object‑opslag of doorgeven aan een andere service, de resulterende URL aan `link` toewijzen en `true` retourneren. De handler moet de verwerking zelf voltooien; `true` retourneren voorkomt de standaard lokale opslag.

**Waarom gooit de Markdown‑export een `InvalidOperationException` vanuit een handler?**

Deze uitzondering treedt op wanneer de handler `true` retourneert maar geen geldige link opgeeft. Ken het relatieve pad of de externe URL toe die in Markdown moet worden geschreven voordat je `true` retourneert.

**Welke pad‑separator moeten afbeeldings‑links gebruiken?**

Gebruik schuine strepen (`/`) in Markdown‑links en URL’s. Gebruik `Path::Combine` alleen voor bestandssysteem‑paden en construeer of normaliseer de Markdown‑referentie apart.

**Worden hyperlinks behouden tijdens de Markdown‑export?**

Ja. Tekst-[hyperlinks](/slides/nl/cpp/manage-hyperlinks/) blijven behouden als standaard Markdown‑links. Slide-[overgangen](/slides/nl/cpp/slide-transition/) en -[animaties](/slides/nl/cpp/powerpoint-animation/) worden niet geconverteerd.

**Kunnen presentaties parallel naar Markdown worden geconverteerd?**

Je kunt verschillende presentatiebestanden parallel verwerken, maar deel dezelfde [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑instantie niet tussen threads. Volg de [multithreading‑richtlijnen](/slides/nl/cpp/multithreading/) en gebruik een aparte instantie voor elk bestand.