---
title: Převést prezentace PowerPoint do Markdownu v C++
linktitle: PowerPoint do Markdownu
type: docs
weight: 140
url: /cs/cpp/convert-powerpoint-to-markdown/
keywords:
- převést PowerPoint
- převést prezentaci
- převést snímek
- převést PPT
- převést PPTX
- PowerPoint na MD
- prezentace na MD
- snímek na MD
- PPT na MD
- PPTX na MD
- uložit PowerPoint jako Markdown
- uložit prezentaci jako Markdown
- uložit snímek jako Markdown
- uložit PPT jako MD
- uložit PPTX jako MD
- exportovat PPT do MD
- exportovat PPTX do MD
- export obrázků do Markdownu
- CDN odkazy na obrázky
- PowerPoint
- prezentace
- Markdown
- C++
- Aspose.Slides
description: "Převést prezentace PPT a PPTX do Markdownu v C++ a ovládat, kde jsou exportované bitmapové, metafile a SVG obrázky uloženy a na ně odkazováno."
---
## **Přehled**

Aspose.Slides pro C++ může převádět prezentace PPT a PPTX do Markdownu pro dokumentaci, statické weby, migraci obsahu a pracovní postupy správy verzí. Můžete si vybrat variantu Markdownu, řídit, jak je vykreslen obsah snímků, a rozhodnout, kde budou exportované obrázky uloženy a jak je generovaný Markdown na ně odkazuje.

Ve výchozím nastavení export do Markdownu používá výstup pouze s textem. Chcete-li exportovat vizuální obsah, nastavte metodu [MarkdownSaveOptions::set_ExportType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/markdownsaveoptions/set_exporttype/) na hodnotu `Sequential` nebo `Visual` z výčtu [MarkdownExportType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/markdownexporttype/). `Sequential` vykresluje položky snímků odděleně a v pořadí, zatímco `Visual` zachovává seskupené položky dohromady, aby se uchoval jejich vizuální vztah. Hodnota `TextOnly` nevydává obrazové zdroje, takže události ukládání obrázků nejsou v tomto režimu vyvolány.

## **Převést prezentaci do Markdownu**

Načtěte zdrojový soubor pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/), a poté zavolejte metodu [Presentation::Save](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/save/) s hodnotou `Md` z výčtu [SaveFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/saveformat/).

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.md", SaveFormat::Md);
```

## **Vybrat variantu Markdownu**

Metoda [MarkdownSaveOptions::set_Flavor](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/markdownsaveoptions/set_flavor/) řídí specifikaci Markdownu používanou pro výstup. Výčet [Flavor](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/flavor/) zahrnuje CommonMark, GitHub Flavored Markdown a další podporované varianty.

Následující příklad exportuje prezentaci ve formátu CommonMark:

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

## **Exportovat obrázky pomocí výchozího místního ukládání**

Třída [MarkdownSaveOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/markdownsaveoptions/) poskytuje dvě metody pro konfiguraci lokálně uložených obrázků:

- [set_BasePath](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) určuje základní adresář pro dokument Markdown a jeho zdroje.
- [set_ImagesSaveFolderName](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/) určuje podadresář pro obrázky. Jeho výchozí hodnota je `Images`.

Následující příklad vykreslí vizuální obsah, zapíše obrázky do `output/assets` a vytvoří relativní odkazy na obrázky v dokumentu Markdown:

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

Toto chování také slouží jako náhradní řešení, když vlastní obslužná rutina ukládání obrázků vrátí `false`.

## **Přizpůsobit ukládání obrázků a odkazy v Markdownu**

Použijte událost `MarkdownSaveOptions::ImageSaving` pro ne‑SVG bitmapové a metafile zdroje generované během exportu do Markdownu. Její delegát [MarkdownImageSavingHandler](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/markdownsaveoptions/markdownimagesavinghandler/) přijímá objekt [IImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iimage/), jeho [ImageFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imageformat/), a vygenerovaný Markdown odkaz jako parametr typu `System::String&`. Uložte nebo nahrajte obrázek s poskytnutým formátem a nahraďte `link` odkazem, který má být v Markdown výstupu.

Zdroje vydávané ve formátu SVG jsou zpracovávány odděleně. Přihlaste se k události `MarkdownSaveOptions::SvgImageSaving`, jejíž delegát [MarkdownSvgImageSavingHandler](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/markdownsaveoptions/markdownsvgimagesavinghandler/) přijímá objekt [ISvgImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isvgimage/) a parametr `System::String& link`. SVG nemá argument `ImageFormat`; místo toho zapište nebo nahrajte jeho XML data metodou [ISvgImage::get_SvgData](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isvgimage/get_svgdata/). V závislosti na režimu exportu a vizuálním seskupení může být SVG v původní prezentaci rasterizováno nebo kombinováno s jiným obsahem; výsledný ne‑SVG zdroj je pak předán do `ImageSaving`. Přihlaste se k oběma událostem, když každý exportovaný vizuální zdroj vyžaduje vlastní zpracování.

Návratová hodnota obslužní rutiny určuje, kdo obrázek zpracuje:

- Vraťte `true` poté, co obslužná rutina obrázek uložila, nahrála, transformovala nebo jinak zpracovala a přiřadila platnou hodnotu do `link`. Aspose.Slides zapíše tuto hodnotu do dokumentu Markdown a neprovede výchozí lokální uložení.
- Vraťte `false`, aby Aspose.Slides obrázek uložil lokálně a vygeneroval odkaz podle [MarkdownSaveOptions::set_BasePath](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) a [MarkdownSaveOptions::set_ImagesSaveFolderName](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/).

{{% alert color="warning" title="Important" %}}
Obslužná rutina, která vrátí `true`, přebírá odpovědnost za obrázek. Pokud vrátí `true` bez přiřazení platného, ne‑prázdného odkazu, export selže s výjimkou `InvalidOperationException`.
{{% /alert %}}

### **Uložit obrázky do adresáře CDN původu a používat externí URL**

Následující příklad považuje `cdn-origin/presentations/quarterly-report` za připojený nebo synchronizovaný CDN původní adresář. Každá obslužná rutina získá vygenerovaný název souboru, uloží obrázek do tohoto vlastního adresáře a nahradí vygenerovaný lokální odkaz veřejnou CDN URL. Vzorek sám neprovádí žádné síťové nahrávání: URL bude platná až po připojení adresáře jako CDN původu nebo po publikování jeho souborů do CDN. Pro objektové úložiště nahraďte zápis do souborového systému operací nahrání SDK úložiště a přiřaďte `link` až po úspěšném nahrání.

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

Bitmapová obslužná rutina úmyslně vrací `false` pro obrázky menší než 128 × 128 pixelů, takže Aspose.Slides tyto obrázky uloží do `output/fallback-images` pomocí výchozího chování. Větší bitmapové a metafile zdroje, stejně jako SVG zdroje, jsou zpracovány vlastním kódem. Například vygenerovaný lokální odkaz `fallback-images/image1.png` se změní na `https://cdn.example.com/presentations/quarterly-report/image1.png`. Obslužné rutiny používají systémové cesty pouze při zápisu souborů; odkazy zapisované do Markdownu používají lomítka a URL‑kódované názvy souborů. Použijte stejný postup i při vytváření relativních odkazů: používejte `/`, ne platformově specifický oddělovač adresářů.

## **Časté otázky**

**Může jeden obslužný program zpracovávat jak rastrové obrázky, tak SVG obrázky?**

Ne. Použijte `MarkdownSaveOptions::ImageSaving` pro bitmapové a metafile zdroje a `MarkdownSaveOptions::SvgImageSaving` pro zdroje vydávané jako SVG. První poskytuje objekt [IImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iimage/) a [ImageFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imageformat/); druhý poskytuje objekt [ISvgImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isvgimage/) jehož SVG data lze číst metodou [ISvgImage::get_SvgData](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isvgimage/get_svgdata/). SVG zdroj, který je během exportu rasterizován, je místo toho zpracován `ImageSaving`.

**Co se stane, když obslužná rutina ukládání obrázku vrátí `false`?**

Aspose.Slides použije své výchozí lokální ukládání. Umístění obrázku a vygenerovaný odkaz jsou řízeny podle [MarkdownSaveOptions::set_BasePath](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) a [MarkdownSaveOptions::set_ImagesSaveFolderName](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/).

**Může obslužná rutina poskytnout URL bez lokálního uložení obrázku?**

Ano. Obslužná rutina může obrázek nahrát do objektového úložiště nebo předat jinému servisu, přiřadit výslednou URL do `link` a vrátit `true`. Rutina musí zpracování dokončit sama; vrácení `true` zabrání výchozímu lokálnímu uložení.

**Proč export do Markdownu vyvolá výjimku `InvalidOperationException` z obslužné rutiny?**

Tato výjimka nastane, když obslužná rutina vrátí `true`, ale neposkytne platný odkaz. Při vrácení `true` přiřaďte relativní cestu nebo externí URL, která má být zapsána do Markdownu.

**Jaký oddělovač cesty by měly odkazy na obrázky používat?**

V odkazech a URL v Markdownu používejte lomítka. Pro cesty v souborovém systému používejte `Path::Combine` a poté vytvořte nebo normalizujte odkaz v Markdownu samostatně.

**Jsou hypertextové odkazy během exportu do Markdownu zachovány?**

Ano. Textové [hyperlinky](/slides/cs/cpp/manage-hyperlinks/) jsou zachovány jako standardní odkazy Markdown. [Přechody snímků](/slides/cs/cpp/slide-transition/) a [animace](/slides/cs/cpp/powerpoint-animation/) nejsou konvertovány.

**Lze prezentace převádět do Markdownu paralelně?**

Můžete zpracovávat různé soubory prezentací paralelně, ale nesdílejte stejnou instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) mezi vlákny. Řiďte se [pokyny pro multithreading](/slides/cs/cpp/multithreading/) a použijte oddělenou instanci pro každý soubor.