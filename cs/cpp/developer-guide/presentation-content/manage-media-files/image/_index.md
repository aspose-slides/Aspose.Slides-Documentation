---
title: Optimalizace správy obrázků v prezentacích pomocí C++
linktitle: Správa obrázků
type: docs
weight: 10
url: /cs/cpp/image/
keywords:
- přidat obrázek
- přidat obrázek
- přidat bitmapu
- nahradit obrázek
- nahradit obrázek
- z webu
- pozadí
- přidat PNG
- přidat JPG
- přidat SVG
- externí SVG zdroje
- SVG řešitel
- propojené SVG obrázky
- SVG fonty
- přidat EMF
- přidat WMF
- přidat TIFF
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Zjednodušte správu obrázků v PowerPointu a OpenDocument pomocí Aspose.Slides pro C++, optimalizujte výkon a automatizujte svůj pracovní postup."
---
## **Úvod**

Obrázky činí prezentace poutavějšími a vizuálně atraktivnějšími. V Microsoft PowerPoint můžete vkládat obrázky na snímky ze souborů, internetu nebo jiných zdrojů. Podobně Aspose.Slides umožňuje přidávat obrázky do snímků prezentace několika způsoby. 

{{% alert title="Tip" color="primary" %}} 

Aspose poskytuje bezplatné převodníky—[JPEG to PowerPoint](https://products.aspose.app/slides/cs/import/jpg-to-ppt) a [PNG to PowerPoint](https://products.aspose.app/slides/cs/import/png-to-ppt)—které vám umožní rychle vytvořit prezentace z obrázků. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Pokud chcete přidat obrázek jako rámeček obrázku—zejména pokud ho plánujete měnit velikost, aplikovat efekty nebo použít jiné standardní možnosti formátování—viz [Picture Frame](/slides/cs/cpp/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Můžete převádět obrázky z jednoho formátu do druhého. Viz následující stránky: převod [image to JPG](https://products.aspose.com/slides/cs/cpp/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/cs/cpp/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/cs/cpp/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/cs/cpp/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/cs/cpp/conversion/png-to-svg/), a [SVG to PNG](https://products.aspose.com/slides/cs/cpp/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides podporuje obrázky v populárních formátech, jako jsou JPEG, PNG, BMP, GIF a další. 

## **Přidání místně uložených obrázků na snímky**

Můžete přidat jeden nebo více obrázků uložených ve vašem počítači na snímek prezentace. Následující ukázkový kód v C++ ukazuje, jak přidat obrázek na snímek:

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



## **Přidání obrázků z webu na snímky**

Pokud obrázek, který chcete přidat na snímek, není uložen ve vašem počítači, můžete jej přidat přímo z webu. 

Následující ukázkový kód v C++ ukazuje, jak přidat obrázek z webu na snímek:

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

Master snímku ukládá a řídí informace, jako jsou motiv a rozvržení snímků, které jej používají. Když přidáte obrázek do hlavního snímku, obrázek se zobrazí na každém snímku založeném na tomto masteru. 

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

Můžete použít obrázek jako pozadí jednoho nebo více snímků. Podrobnosti najdete v *[Nastavení obrázků jako pozadí snímků](/slides/cs/cpp/presentation-background/#setting-images-as-background-for-slides)*.

## **Přidání SVG do prezentací**

Obsah SVG lze přidat do prezentace pomocí třídy [SvgImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/svgimage/) . Výsledný objekt [ISvgImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isvgimage/) může být následně přidán do kolekce obrázků prezentace a použit k vytvoření rámce obrázku.

Následující příklad v C++ importuje samostatný řetězec SVG. Všechny obrázky, styly a další zdroje použité v tomto SVG jsou přímo vloženy do obsahu SVG.

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

## **Importování SVG obsahu s externími zdroji**

SVG soubory exportované z nástrojů pro návrh, diagramové editory, ikony a webové pipelines mohou odkazovat na zdroje, které jsou uloženy mimo dokument SVG. Například SVG může obsahovat odkaz na obrázek jako `images/photo.png`, hodnotu CSS `url(...)` nebo URL písma.

Aby bylo možné takový SVG obsah importovat, vytvořte implementaci [IExternalResourceResolver](https://reference.aspose.com/slides/cs/cpp/aspose.slides.import/iexternalresourceresolver/) a předáte ji spolu se základní URI do vhodného konstruktoru `SvgImage`. Základní URI určuje umístění dokumentu SVG a slouží k řešení relativních odkazů.

Rozhraní [ISvgImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isvgimage/) poskytuje přístup k informacím o importovaném SVG:

- `get_SvgContent()` vrací SVG markup jako řetězec.  
- `get_SvgData()` vrací obsah SVG jako pole bajtů.  
- `get_BaseUri()` vrací základní URI použité pro relativní odkazy.  
- `get_ExternalResourceResolver()` vrací řešitel přiřazený k SVG obrázku.  

### **Implementace externího řešitele zdrojů**

Řešitel má dvě metody:

- [ResolveUri](https://reference.aspose.com/slides/cs/cpp/aspose.slides.import/iexternalresourceresolver/resolveuri/) kombinuje základní URI a relativní odkaz na zdroj a vrací absolutní URI. Vraťte prázdný řetězec, když odkaz nelze vyřešit nebo není povolen.  
- [GetEntity](https://reference.aspose.com/slides/cs/cpp/aspose.slides.import/iexternalresourceresolver/getentity/) vrací čitelný stream pro absolutní URI zdroje. Vraťte `nullptr`, když je zdroj chybějící, blokovaný nebo nedostupný. Náhradní stream může být také vrácen, když je to vhodné.  

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

        // Tento řešitel úmyslně povoluje pouze místní soubory.
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

        // Použít náhradní řešení pouze pro obrazové zdroje. Vrácení proudu obrazu
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

### **Řešení odkazovaných zdrojů během importu SVG**

Předpokládejme, že `assets/diagram.svg` obsahuje relativní odkaz jako:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Následující ukázkový kód v C++ předá URI souboru SVG jako základní URI a poskytne vlastní řešitel. Řešitel převede relativní odkaz na obrázek na absolutní URI a vrátí stream obsahující odkazovaný zdroj, zatímco Aspose.Slides zpracovává SVG.

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

// Základní URI představuje umístění SVG dokumentu.
auto baseUri = MakeObject<Uri>(svgFilePath)->get_AbsoluteUri();

auto fallbackImageData = ArrayPtr<uint8_t>();
auto fallbackImagePath = Path::Combine(assetDirectory, u"fallback.png");
if (File::Exists(fallbackImagePath))
{
    fallbackImageData = File::ReadAllBytes(fallbackImagePath);
}

auto resolver = MakeObject<LocalSvgResourceResolver>(assetDirectory, fallbackImageData);
auto svgImage = MakeObject<SvgImage>(svgContent, resolver, baseUri);

// ISvgImage vystavuje zdrojový obsah, binární data, základní URI a řešitel.
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

Třída `SvgImage` také poskytuje přetížení, která přijímají SVG data jako pole bajtů nebo stream, spolu s externím řešitelem zdrojů a základním URI.

{{% alert title="Important" color="warning" %}}

Řešitel zdrojů zpřístupňuje externí zdroje během zpracování a vykreslování SVG knihovnou Aspose.Slides. Nemodifikuje originální SVG markup ani automaticky nevestavuje vyřešené zdroje do něj.

Když je `ISvgImage` přidán do kolekce obrázků prezentace, soubor PPTX může obsahovat jak originální SVG reprezentaci, tak rastrový záložní obrázek. Odkazovaný zdroj může být zahrnut v generovaném záložním obrázku, zatímco relativní odkaz jako `images/photo.png` zůstane nezměněn v uloženém SVG. Aplikace, která vykresluje nativní SVG reprezentaci, může proto vynechat odkazovaný obsah, pokud není původní externí zdroj dostupný.

{{% /alert %}}

### **Vytvoření přenosného SVG obrázku**

Pro vytvoření SVG obrázku, který nezávisí na externích souborech, udělejte SVG samostatný před vytvořením `SvgImage`. Například nahraďte odkazy na obrázky URL typu `data:`, které obsahují data obrázku:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Po vložení všech potřebných zdrojů do obsahu SVG vytvořte `SvgImage`, přidejte jej do kolekce obrázků prezentace a vložte jej do rámce obrázku, jak je ukázáno v předchozím příkladu.

### **Zpracování chybějících nebo blokovaných zdrojů**

Vraťte prázdný řetězec z `ResolveUri`, když je URI zdroje neplatné, zakázané nebo jej nelze vyřešit. Vraťte `nullptr` z `GetEntity`, když není možné zdroj přečíst. Aspose.Slides pokračuje ve zpracování SVG bez tohoto zdroje, pokud je to možné.

Náhradní stream může být vrácen pro chybějící zdroj, ale jeho obsah musí být kompatibilní s požadovaným typem zdroje. Například vracejte stream s obrázkem pouze pro chybějící obrázek, ne pro písmo nebo stylový list.

{{% alert title="Security" color="warning" %}}

Nevyřešujte libovolné souborové cesty ani neomezené síťové URL z nedůvěryhodných SVG souborů. Omezte povolené schémata, adresáře a hostitele. Pro síťové zdroje také aplikujte časové limity připojení, limity velikosti odpovědi a validaci obsahu.

{{% /alert %}}

## **Převod SVG na sadu tvarů**
Aspose.Slides může převést SVG na sadu tvarů, podobně jako odpovídající funkčnost v PowerPointu:

![Nabídka v PowerPointu](img_01_01.png)

Tato funkce je poskytována přetížením metody [AddGroupShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapecollection/) rozhraní [IShapeCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapecollection/), která jako první argument přijímá objekt [ISvgImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isvgimage/) .

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

// Vytvořte novou prezentaci
auto presentation = System::MakeObject<Presentation>();

// Přečtěte obsah SVG souboru
auto svgContent = File::ReadAllText(svgFileName);

// Vytvořte objekt SvgImage
auto svgImage = System::MakeObject<SvgImage>(svgContent);

// Získejte velikost snímku
auto slideSize = presentation->get_SlideSize()->get_Size();

// Převeďte SVG obrázek na skupinu tvarů a upravte jeho velikost na velikost snímku
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// Uložte prezentaci ve formátu PPTX
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **Přidání obrázků jako EMF na snímky**
Aspose.Slides for C++ umožňuje generovat EMF obrázky z Excelových listů pomocí Aspose.Cells a přidávat je do snímků prezentace. 

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

// Aspose.Cells pro C++ musí být spuštěn před použitím jakýchkoli jeho typů.
Aspose::Cells::Startup();

auto workbook = Aspose::Cells::Workbook(u"chart.xls");
auto sheet = workbook.GetWorksheets().Get(0);

// Vykreslete list jako EMF.
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

Aspose.Slides vám umožňuje nahradit obrázky uložené v kolekci obrázků prezentace, včetně obrázků použitého tvary na snímcích. Tato sekce popisuje několik způsobů, jak aktualizovat obrázky v kolekci. Můžete nahradit obrázek pomocí surových bajtových dat, instance [IImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iimage/) nebo jiného obrázku, který již v kolekci existuje.

1. Načtěte soubor prezentace, který obsahuje obrázky, pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).  
2. Načtěte nový obrázek ze souboru do pole bajtů.  
3. Nahraďte cílový obrázek novým obrázkem pomocí pole bajtů.  
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

**Zůstává původní rozlišení obrázku po vložení nedotčeno?**

Ano. Původní pixely jsou zachovány, ale konečný vzhled závisí na tom, jak je [picture](/slides/cs/cpp/picture-frame/) na snímku škálován a jaká komprese je použita při uložení.

**Jaký je nejlepší způsob, jak najednou nahradit stejné logo na desítkách snímků?**

Umístěte logo na master snímek nebo rozvržení a nahraďte jej v kolekci obrázků prezentace – aktualizace se promítnou do všech prvků, které tento zdroj používají.

**Lze vložený SVG převést na editovatelné tvary?**

Ano. SVG lze převést na skupinu tvarů, po čemž se jednotlivé části stanou editovatelnými pomocí standardních vlastností tvarů.

**Jak mohu najednou nastavit obrázek jako pozadí pro více snímků?**

[Přiřaďte obrázek jako pozadí](/slides/cs/cpp/presentation-background/) na master snímku nebo příslušném rozvržení – všechny snímky používající tento master/rozvržení zdědí pozadí.

**Jak zabránit tomu, aby se prezentace kvůli mnoha obrázkům stala příliš velkou?**

Opakovaně používejte jediný zdroj obrázku místo duplikátů, zvolte rozumná rozlišení, při ukládání použijte kompresi a opakující se grafiku umístěte na master snímek, kde je to vhodné.