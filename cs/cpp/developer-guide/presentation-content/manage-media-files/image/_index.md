---
title: "Optimalizace správy obrázků v prezentacích pomocí C++"
linktitle: "Správa obrázků"
type: docs
weight: 10
url: /cs/cpp/image/
keywords:
  - "přidat obrázek"
  - "přidat fotografii"
  - "přidat bitmapu"
  - "nahradit obrázek"
  - "nahradit fotografii"
  - "z webu"
  - "pozadí"
  - "přidat PNG"
  - "přidat JPG"
  - "přidat SVG"
  - "externí SVG zdroje"
  - "SVG řešič"
  - "propojené SVG obrázky"
  - "SVG fonty"
  - "přidat EMF"
  - "přidat WMF"
  - "přidat TIFF"
  - "PowerPoint"
  - "OpenDocument"
  - "prezentace"
  - "C++"
  - "Aspose.Slides"
description: "Zefektivněte správu obrázků v PowerPointu a OpenDocument pomocí Aspose.Slides pro C++, optimalizujte výkon a automatizujte svůj pracovní postup."
---
## **Úvod**

Obrázky činí prezentace poutavějšími a vizuálně atraktivnějšími. V Microsoft PowerPoint můžete vkládat obrázky na snímky ze souborů, internetu nebo jiných zdrojů. Podobně Aspose.Slides umožňuje přidávat obrázky do snímků prezentace několika způsoby. 

{{% alert title="Tip" color="info" %}} 

Aspose poskytuje bezplatné převodníky—[JPEG do PowerPointu](https://products.aspose.app/slides/cs/import/jpg-to-ppt) a [PNG do PowerPointu](https://products.aspose.app/slides/cs/import/png-to-ppt)—které vám umožní rychle vytvořit prezentace z obrázků. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Pokud chcete přidat obrázek jako rámeček obrázku—zejména pokud jej plánujete změnit velikost, použít efekty nebo jiné standardní možnosti formátování—viz [Rámeček obrázku](/slides/cs/cpp/picture-frame/). 

{{% /alert %}} 

{{% alert title="Poznámka" color="warning" %}}

Můžete převádět obrázky z jednoho formátu do druhého. Viz následující stránky: převod [obrázku na JPG](https://products.aspose.com/slides/cs/cpp/conversion/image-to-jpg/), [JPG na obrázek](https://products.aspose.com/slides/cs/cpp/conversion/jpg-to-image/), [JPG na PNG](https://products.aspose.com/slides/cs/cpp/conversion/jpg-to-png/), [PNG na JPG](https://products.aspose.com/slides/cs/cpp/conversion/png-to-jpg/), [PNG na SVG](https://products.aspose.com/slides/cs/cpp/conversion/png-to-svg/), a [SVG na PNG](https://products.aspose.com/slides/cs/cpp/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides podporuje obrázky v populárních formátech, jako jsou JPEG, PNG, BMP, GIF a další. 

## **Přidání obrázků uložených lokálně do snímků**

Můžete přidat jeden nebo více obrázků uložených ve vašem počítači do snímku prezentace. Následující ukázkový kód v C++ ukazuje, jak přidat obrázek do snímku:

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



## **Přidání obrázků z webu do snímků**

Není-li obrázek, který chcete přidat do snímku, uložen ve vašem počítači, můžete jej přidat přímo z webu. 

Následující ukázkový kód v C++ ukazuje, jak přidat obrázek z webu do snímku:

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

## **Přidání obrázků do hlavních snímků**

Hlavní snímek (slide master) ukládá a řídí informace, jako jsou motiv a rozvržení snímků, které jej používají. Když přidáte obrázek do hlavního snímku, obrázek se objeví na každém snímku založeném na tomto hlavním snímku. 

Následující ukázkový kód v C++ ukazuje, jak přidat obrázek do hlavního snímku:

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

## **Přidání obrázků jako pozadí snímků**

Můžete použít obrázek jako pozadí pro jeden nebo více snímků. Podrobnosti najdete v *[Nastavení obrázků jako pozadí snímků](/slides/cs/cpp/presentation-background/#setting-images-as-background-for-slides)*.

## **Přidání SVG do prezentací**

Obsah SVG lze přidat do prezentace pomocí třídy [SvgImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/svgimage/). Výsledný objekt [ISvgImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isvgimage/) může být následně přidán do kolekce obrázků prezentace a použit k vytvoření rámečku obrázku.

Následující příklad v C++ importuje samostatný řetězec SVG. Všechny obrázky, styly a další zdroje použité v tomto SVG jsou vloženy přímo do obsahu SVG.

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

## **Import SVG obsahu s externími zdroji**

SVG soubory exportované z nástrojů pro návrh, diagramových editorů, ikonových systémů a webových pipeline mohou odkazovat na zdroje, které jsou uloženy mimo dokument SVG. Například SVG může obsahovat odkaz na obrázek jako `images/photo.png`, CSS hodnotu `url(...)` nebo URL písma.

Aby bylo možné importovat takový SVG obsah, vytvořte implementaci rozhraní [IExternalResourceResolver](https://reference.aspose.com/slides/cs/cpp/aspose.slides.import/iexternalresourceresolver/) a předávejte ji společně se základním URI do vhodného konstruktoru `SvgImage`. Základní URI identifikuje umístění dokumentu SVG a používá se k řešení relativních odkazů.

Rozhraní [ISvgImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isvgimage/) poskytuje přístup k informacím o importovaném SVG:

- `get_SvgContent()` vrací značkování SVG jako řetězec.  
- `get_SvgData()` vrací obsah SVG jako pole bytů.  
- `get_BaseUri()` vrací základní URI použité pro relativní odkazy.  
- `get_ExternalResourceResolver()` vrací řešič přiřazený k obrázku SVG.  

### **Implementace externího řešiče zdrojů**

Řešič má dvě metody:

- [ResolveUri](https://reference.aspose.com/slides/cs/cpp/aspose.slides.import/iexternalresourceresolver/resolveuri/) kombinuje základní URI a relativní odkaz na zdroj a vrací absolutní URI. Vrátí prázdný řetězec, když nelze odkaz vyřešit nebo není povolen.  
- [GetEntity](https://reference.aspose.com/slides/cs/cpp/aspose.slides.import/iexternalresourceresolver/getentity/) vrací čitelný stream pro absolutní URI zdroje. Vrátí `nullptr`, když je zdroj chybějící, blokovaný nebo nedostupný. Vhodně může být také vrácen náhradní stream.  

Následující řešič načítá propojené zdroje jen z povoleného lokálního adresáře. Síťové zdroje a cesty mimo povolený adresář jsou blokovány. Nepovinný náhradní obrázek je vrácen pro nevyřešené odkazy na obrázky.

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

        // Tento řešič úmyslně povoluje jen místní soubory.
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

        // Použijte náhradní pouze pro obrazové zdroje. Vrácení proudu obrázku
        // pro chybějící písmo nebo stylopis by nebylo platné.
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

### **Řešení propojených zdrojů během importu SVG**

Předpokládejme, že `assets/diagram.svg` obsahuje relativní odkaz jako:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Následující příklad v C++ předává URI souboru SVG jako základní URI a poskytuje vlastní řešič. Řešič převádí relativní odkaz na obrázek na absolutní URI a vrací stream obsahující propojený zdroj, zatímco Aspose.Slides zpracovává SVG.

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

// Základní URI představuje umístění dokumentu SVG.
auto baseUri = MakeObject<Uri>(svgFilePath)->get_AbsoluteUri();

auto fallbackImageData = ArrayPtr<uint8_t>();
auto fallbackImagePath = Path::Combine(assetDirectory, u"fallback.png");
if (File::Exists(fallbackImagePath))
{
    fallbackImageData = File::ReadAllBytes(fallbackImagePath);
}

auto resolver = MakeObject<LocalSvgResourceResolver>(assetDirectory, fallbackImageData);
auto svgImage = MakeObject<SvgImage>(svgContent, resolver, baseUri);

// ISvgImage poskytuje zdrojový obsah, binární data, základní URI a řešič.
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

Třída `SvgImage` také poskytuje přetížení, která přijímají data SVG jako pole bytů nebo stream, spolu s externím řešičem zdrojů a základním URI.

{{% alert title="Důležité" color="warning" %}}

Řešič zdrojů zpřístupňuje externí zdroje během zpracování a vykreslování SVG v Aspose.Slides. Nemění původní značkování SVG ani automaticky nevloží vyřešené zdroje do něj.

Při přidání `ISvgImage` do kolekce obrázků prezentace může soubor PPTX obsahovat jak původní SVG reprezentaci, tak rastrový náhradní obrázek. Propojený zdroj se může objevit v generovaném náhradním obrázku, zatímco relativní odkaz jako `images/photo.png` zůstane nezměněn v uloženém SVG. Aplikace, která vykresluje nativní SVG reprezentaci, může proto vynechat propojený obsah, pokud původní externí zdroj není k dispozici.

{{% /alert %}}

### **Vytvoření přenosného SVG obrázku**

Aby byl SVG obrázek nezávislý na externích souborech, vytvořte samostatné SVG před vytvořením `SvgImage`. Například nahraďte propojené URL obrázků pomocí `data:` URI, které obsahují data obrázku:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Po vložení všech potřebných zdrojů do obsahu SVG vytvořte `SvgImage`, přidejte jej do kolekce obrázků prezentace a vložte jej do rámečku obrázku, jak je ukázáno v předchozím příkladu.

### **Zpracování chybějících nebo blokovaných zdrojů**

Vraťte prázdný řetězec z `ResolveUri`, když je URI zdroje neplatné, zakázané nebo jej nelze vyřešit. Vraťte `nullptr` z `GetEntity`, když zdroj nelze přečíst. Aspose.Slides pokračuje ve zpracování SVG bez tohoto zdroje, pokud je to možné.

Náhradní stream může být vrácen pro chybějící zdroj, ale jeho obsah musí být kompatibilní s požadovaným typem zdroje. Například vraťte stream obrázku jen pro chybějící obrázek, ne pro písmo nebo stylopis.

{{% alert title="Bezpečnost" color="warning" %}}

Nevyřešujte libovolné cesty k souborům ani neomezené síťové URL z nedůvěryhodných SVG souborů. Omezte povolené schémata, adresáře a hostitele. Pro síťové zdroje také použijte časové limity připojení, omezení velikosti odpovědi a validaci obsahu.

{{% /alert %}}

## **Převod SVG na sadu tvarů**
Aspose.Slides dokáže převést SVG na sadu tvarů, podobně jako odpovídající funkce v PowerPointu:

![PowerPoint Popup Menu](img_01_01.png)

Tato funkce je poskytována přetížením metody [AddGroupShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapecollection/) rozhraní [IShapeCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapecollection/), která přijímá objekt [ISvgImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isvgimage/) jako první argument.

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

// Název zdrojového SVG souboru
auto svgFileName = System::String(u"sample.svg");

// Název výstupního souboru prezentace
auto outPptxPath = System::String(u"presentation.pptx");

// Vytvořit novou prezentaci
auto presentation = System::MakeObject<Presentation>();

// Přečíst obsah SVG souboru
auto svgContent = File::ReadAllText(svgFileName);

// Vytvořit objekt SvgImage
auto svgImage = System::MakeObject<SvgImage>(svgContent);

// Získat velikost snímku
auto slideSize = presentation->get_SlideSize()->get_Size();

// Převést SVG obrázek na skupinu tvarů a přizpůsobit jej velikosti snímku
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// Uložit prezentaci ve formátu PPTX
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **Přidání obrázků jako EMF do snímků**
Aspose.Slides pro C++ umožňuje generovat EMF obrázky z listů Excelu pomocí Aspose.Cells a přidávat je do snímků prezentace. 

Následující ukázkový kód v C++ ukazuje, jak to provést:

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

// Aspose.Cells pro C++ musí být spuštěno před použitím jakýchkoli jeho typů.
Aspose::Cells::Startup();

auto workbook = Aspose::Cells::Workbook(u"chart.xls");
auto sheet = workbook.GetWorksheets().Get(0);

// Render the worksheet as EMF.
auto options = Aspose::Cells::ImageOrPrintOptions();
options.SetHorizontalResolution(200);
options.SetVerticalResolution(200);
options.SetImageType(Aspose::Cells::Drawing::ImageType::Emf);

auto sheetRender = Aspose::Cells::SheetRender(sheet, options);

auto presentation = System::MakeObject<Presentation>();
presentation->get_Slides()->RemoveAt(0);

for (auto pageIndex = 0; pageIndex < sheetRender.GetPageCount(); pageIndex++)
{
    // Aspose.Cells vrací vykreslenou stránku jako buffer, který Aspose.Slides přidá jako obrázek.
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

## **Nahrazení obrázků v kolekci obrázků**

Aspose.Slides vám umožňuje nahradit obrázky uložené v kolekci obrázků prezentace, včetně obrázků použitých ve tvarech snímků. Tento oddíl popisuje několik způsobů, jak aktualizovat obrázky v kolekci. Můžete nahradit obrázek pomocí surových bytových dat, instance [IImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iimage/) nebo jiného obrázku, který již v kolekci existuje.

Postupujte podle následujících kroků:

1. Načtěte soubor prezentace, který obsahuje obrázky, pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).  
2. Načtěte nový obrázek ze souboru do pole bytů.  
3. Nahraďte cílový obrázek novým obrázkem pomocí pole bytů.  
4. Ve druhém přístupu načtěte obrázek do objektu [IImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iimage/) a nahraďte cílový obrázek tímto objektem.  
5. Ve třetím přístupu nahraďte cílový obrázek obrázkem, který již v kolekci obrázků prezentace existuje.  
6. Zapište upravenou prezentaci jako soubor PPTX.  

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

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// První způsob.
auto imageData = File::ReadAllBytes(u"image0.jpeg");
auto oldImage = presentation->get_Image(0);
oldImage->ReplaceImage(imageData);

// Druhý způsob.
auto newImage = Images::FromFile(u"image1.png");
oldImage = presentation->get_Image(1);
oldImage->ReplaceImage(newImage);
newImage->Dispose();

// Třetí způsob.
oldImage = presentation->get_Image(2);
oldImage->ReplaceImage(presentation->get_Image(3));

// Uložte prezentaci do souboru.
presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}

S bezplatným konvertorem [Text to GIF](https://products.aspose.app/slides/cs/text-to-gif) od Aspose můžete snadno animovat text a vytvářet GIFy z textu. 

{{% /alert %}}

## **Často kladené otázky**

**Zůstane původní rozlišení obrázku po vložení zachováno?**

Ano. Původní pixely jsou zachovány, ale konečný vzhled závisí na tom, jak je [obrázek](/slides/cs/cpp/picture-frame/) na snímku škálován a na případné kompresi při ukládání.

**Jaký je nejlepší způsob, jak nahradit stejné logo napříč desítkami snímků najednou?**

Umístěte logo na hlavní snímek nebo rozvržení a nahraďte jej v kolekci obrázků prezentace – aktualizace se projeví ve všech prvcích, které tento zdroj používají.

**Lze vložené SVG převést na editovatelné tvary?**

Ano. SVG lze převést na skupinu tvarů, po čemž se jednotlivé části stanou editovatelnými pomocí standardních vlastností tvarů.

**Jak mohu nastavit obrázek jako pozadí pro více snímků najednou?**

Přiřaďte obrázek jako pozadí na hlavní snímek nebo příslušné rozvržení – všechny snímky používající tento hlavní/rozvržení zdědí pozadí.

**Jak zabránit tomu, aby se prezentace kvůli mnoha obrázkům stala příliš velkou?**

Znovu použijte jeden zdroj obrázku místo duplicit, zvolte rozumná rozlišení, aplikujte kompresi při ukládání a opakující se grafiku umístěte na hlavní snímek, kde je to vhodné.