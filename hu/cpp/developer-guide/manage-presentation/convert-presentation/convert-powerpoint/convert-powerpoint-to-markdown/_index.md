---
title: PowerPoint prezentációk konvertálása Markdown formátumba C++-ban
linktitle: PowerPoint a Markdownba
type: docs
weight: 140
url: /hu/cpp/convert-powerpoint-to-markdown/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- dia konvertálása
- PPT konvertálása
- PPTX konvertálása
- PowerPoint MD-be
- prezentáció MD-be
- dia MD-be
- PPT MD-be
- PPTX MD-be
- PowerPoint mentése Markdownként
- prezentáció mentése Markdownként
- dia mentése Markdownként
- PPT mentése MD-ként
- PPTX mentése MD-ként
- PPT exportálása MD-be
- PPTX exportálása MD-be
- Markdown kép exportálás
- CDN kép hivatkozások
- PowerPoint
- prezentáció
- Markdown
- C++
- Aspose.Slides
description: "PPT és PPTX prezentációk konvertálása Markdownba C++-ban, valamint a exportált bitmap, metafájl és SVG képek mentési helyének és hivatkozásának szabályozása."
---
## **Áttekintés**

Az Aspose.Slides for C++ képes PPT és PPTX prezentációkat Markdown formátumba konvertálni dokumentáció, statikus weboldal, tartalom-migráció és verziókezelési munkafolyamatok céljából. Kiválaszthatja a Markdown változatot, szabályozhatja, hogyan jelenjen meg a dia tartalma, és meghatározhatja, hogy az exportált képek hol kerülnek tárolásra, illetve a generált Markdown hogyan hivatkozik rájuk.

Alapértelmezés szerint a Markdown export szöveg‑only kimenetet használ. A vizuális tartalom exportálásához állítsa a [MarkdownSaveOptions::set_ExportType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/markdownsaveoptions/set_exporttype/) metódust a [MarkdownExportType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/markdownexporttype/) enumeráció `Sequential` vagy `Visual` értékére. A `Sequential` a dia elemeit külön‑külön és sorrendben jeleníti meg, míg a `Visual` csoportosított elemeket egyben tartja, hogy megőrizze a vizuális kapcsolatot. A `TextOnly` érték nem generál kép erőforrásokat, ezért ebben a módban a kép‑mentés események nem kerülnek meghívásra.

## **Prezentáció konvertálása Markdown‑ba**

Töltsük be a forrásfájlt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztállyal, majd hívjuk meg a [Presentation::Save](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/save/) metódust a [SaveFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/saveformat/) enumeráció `Md` értékével.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.md", SaveFormat::Md);
```

## **Markdown változat kiválasztása**

A [MarkdownSaveOptions::set_Flavor](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/markdownsaveoptions/set_flavor/) metódus szabályozza a kimenetben használt Markdown specifikációt. A [Flavor](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/flavor/) enumeráció tartalmazza a CommonMark, a GitHub Flavored Markdown és egyéb támogatott változatokat.

Az alábbi példa CommonMark‑ként exportál egy prezentációt:

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

## **Képek exportálása az alapértelmezett helyi mentési viselkedéssel**

A [MarkdownSaveOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/markdownsaveoptions/) osztály két módszert biztosít a helyileg mentett képek konfigurálásához:

- [set_BasePath](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) megadja a Markdown dokumentum és erőforrásai alapkönyvtárát.
- [set_ImagesSaveFolderName](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/) megadja a képek alkönyvtárát. Alapértelmezett értéke `Images`.

Az alábbi példa vizuális tartalmat renderel, a képeket a `output/assets` könyvtárba írja, és relatív kép hivatkozásokat hoz létre a Markdown dokumentumban:

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

Ez a viselkedés a visszalépési megoldásként is szolgál, ha egy egyéni kép‑mentő kezelő `false`‑t ad vissza.

## **Kép mentés és Markdown hivatkozások testreszabása**

Használja a `MarkdownSaveOptions::ImageSaving` eseményt a Markdown export során keletkező nem‑SVG bitmap és metafájl erőforrásokhoz. A [MarkdownImageSavingHandler](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/markdownsaveoptions/markdownimagesavinghandler/) delegált megkapja az [IImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iimage/) objektumot, annak [ImageFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imageformat/) értékét, valamint a generált Markdown hivatkozást `System::String&` paraméterként. Mentse vagy töltse fel a képet a kapott formátummal, és cserélje le a `link`‑et a Markdown kimenetben megjelenő hivatkozással.

Az SVG formátumban keletkező erőforrások külön kerülnek kezelésre. Iratkozzon fel a `MarkdownSaveOptions::SvgImageSaving` eseményre, amelynek [MarkdownSvgImageSavingHandler](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/markdownsaveoptions/markdownsvgimagesavinghandler/) delegáltja egy [ISvgImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isvgimage/) objektumot és a `System::String& link` paramétert kapja. Az SVG‑nek nincs `ImageFormat` argumentuma; írja vagy töltse fel XML adatát az [ISvgImage::get_SvgData](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isvgimage/get_svgdata/) metódussal. Az export módjától és a vizuális csoportosítástól függően egy forrás‑presentációban lévő SVG rasterizálódhat vagy más tartalommal kombinálódhat; a keletkezett nem‑SVG erőforrást ezután a `ImageSaving` kapja. Iratkozzon fel mindkét eseményre, ha minden exportált vizuális erőforrás egyedi feldolgozást igényel.

A kezelő visszatérési értéke meghatározza, ki dolgozza fel a képet:

- `true`‑t adjon vissza, ha a kezelő elmentette, feltöltötte, átalakította vagy egyéb módon feldolgozta a képet, és érvényes értéket rendelt a `link`‑hez. Az Aspose.Slides ezt az értéket írja a Markdown dokumentumba, és nem hajtja végre az alapértelmezett helyi mentést.
- `false`‑t adjon vissza, ha szeretné, hogy az Aspose.Slides helyben mentse a képet, és a hivatkozást a [MarkdownSaveOptions::set_BasePath](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) és [MarkdownSaveOptions::set_ImagesSaveFolderName](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/) alapján generálja.

{{% alert color="warning" title="Fontos" %}}

Egy `true`‑t visszaadó kezelő felelősséget vállal a képért. Ha `true`‑t ad vissza anélkül, hogy érvényes, nem üres hivatkozást rendelne a `link`‑hez, az export `InvalidOperationException` hibával leáll.

{{% /alert %}}

### **Képek mentése CDN eredeti könyvtárba és külső URL használata**

Az alábbi példa a `cdn-origin/presentations/quarterly-report` könyvtárat egy csatlakoztatott vagy szinkronizált CDN eredeti könyvtárként kezeli. Minden kezelő kinyeri a generált fájlnevet, elmenti a képet a saját könyvtárba, és a helyi hivatkozást egy nyilvános CDN URL‑re cseréli. A minta önmagában nem hajt végre hálózati feltöltést: az URL csak akkor válik érvényessé, ha a könyvtár CDN eredetként van csatlakoztatva vagy fájljai közzétételre kerülnek. Objektumtárolás esetén a fájlrendszeri írást cserélje le a tároló SDK feltöltési műveletére, és csak a feltöltés sikerét követően állítsa be a `link`‑et.

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

A bitmap kezelő szándékosan `false`‑t ad vissza 128 × 128 pixelnél kisebb képek esetén, így az Aspose.Slides ezeket a képeket a `output/fallback-images` könyvtárba menti az alapértelmezett viselkedés szerint. Nagyobb bitmap és metafájl erőforrások, valamint az SVG erőforrások a saját kóddal kerülnek feldolgozásra. Például egy generált helyi hivatkozás, mint a `fallback-images/image1.png`, `https://cdn.example.com/presentations/quarterly-report/image1.png` lesz. A kezelők csak fájlrendszeri útvonalakat használnak íráskor; a Markdown‑ba írt hivatkozások perjelesztett (`/`) és URL‑kódolt fájlneveket tartalmaznak. Ugyanezt a szabályt alkalmazza relatív hivatkozások építésekor: használjon `/`‑t, ne a platform‑specifikus könyvtárelválasztót.

## **GYIK**

**Egy kezelő képes mind raster, mind SVG képeket feldolgozni?**

Nem. Használja a `MarkdownSaveOptions::ImageSaving`‑t a bitmap és metafájl erőforrásokhoz, a `MarkdownSaveOptions::SvgImageSaving`‑t pedig az SVG‑ként exportált erőforrásokhoz. Az előbbi egy [IImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iimage/) objektumot és egy [ImageFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imageformat/) értéket biztosít; az utóbbi egy [ISvgImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isvgimage/) objektumot, amelynek SVG adata a [ISvgImage::get_SvgData](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isvgimage/get_svgdata/)‑val olvasható. Egy forrás‑SVG, amely rasterizálódik az export során, a `ImageSaving`‑nek kerül feldolgozásra.

**Mi történik, ha egy kép‑mentő kezelő `false`‑t ad vissza?**

Az Aspose.Slides az alapértelmezett helyi mentési viselkedést alkalmazza. A kép helyét és a generált hivatkozást a [MarkdownSaveOptions::set_BasePath](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) és [MarkdownSaveOptions::set_ImagesSaveFolderName](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/) szabályozza.

**Egy kezelő megadhat URL‑t anélkül, hogy lokálisan mentené a képet?**

Igen. A kezelő feltöltheti a képet objektumtárolóba vagy továbbíthatja egy másik szolgáltatásnak, beállíthatja a kapott URL‑t a `link`‑ben, és `true`‑t ad vissza. A kezelőnek saját maga kell befejeznie a feldolgozást; `true` visszaadása megakadályozza az alapértelmezett helyi mentést.

**Miért dob `InvalidOperationException` kivételt a Markdown export egy kezelőből?**

Ez a kivétel akkor fordul elő, ha a kezelő `true`‑t ad vissza, de nem biztosít érvényes hivatkozást. Adja meg a relatív útvonalat vagy külső URL‑t, amelyet a Markdown‑ba kell írni, mielőtt `true`‑t visszaadna.

**Milyen útvonalelválasztót használjon a kép‑hivatkozásoknál?**

Használjon perjelesztett (`/`) elválasztót a Markdown hivatkozásokban és URL‑ekben. A fájlrendszeri utakhoz csak a `Path::Combine`‑t alkalmazza, majd a Markdown hivatkozást külön normalizálja.

**Megmaradnak a hiperhivatkozások a Markdown export során?**

Igen. A szöveges [hiperhivatkozások](/slides/hu/cpp/manage-hyperlinks/) megmaradnak szabványos Markdown linkekként. A diák [átmenetei](/slides/hu/cpp/slide-transition/) és [animációi](/slides/hu/cpp/powerpoint-animation/) nem kerülnek konvertálásra.

**Konvertálhatóak a prezentációk párhuzamosan Markdown‑ba?**

Különböző prezentációs fájlok párhuzamosan feldolgozhatók, de ne ossza meg ugyanazt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) példányt szálak között. Kövesse a [multithreading guidelines](/slides/hu/cpp/multithreading/) útmutatót, és minden fájlhoz használjon külön példányt.