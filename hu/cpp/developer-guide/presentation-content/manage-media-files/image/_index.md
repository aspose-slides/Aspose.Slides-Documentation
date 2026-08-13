---
title: Képek kezelésének optimalizálása a bemutatókban C++ használatával
linktitle: Képek kezelése
type: docs
weight: 10
url: /hu/cpp/image/
keywords:
- kép hozzáadása
- kép hozzáadása
- bitmap hozzáadása
- kép cseréje
- kép cseréje
- webről
- háttér
- PNG hozzáadása
- JPG hozzáadása
- SVG hozzáadása
- külső SVG erőforrások
- SVG feloldó
- összekapcsolt SVG képek
- SVG betűkészletek
- EMF hozzáadása
- WMF hozzáadása
- TIFF hozzáadása
- PowerPoint
- OpenDocument
- bemutató
- C++
- Aspose.Slides
description: "Egyszerűsítse a képek kezelését PowerPointban és OpenDocumentben az Aspose.Slides for C++ segítségével, optimalizálva a teljesítményt és automatizálva a munkafolyamatát."
---
## **Bevezetés**

Képek teszik a bemutatókat élvezetesebbé és vizuálisan vonzóbbá. A Microsoft PowerPointban képeket szúrhat be a diákra fájlokból, az internetről vagy más forrásokból. Hasonlóan, az Aspose.Slides lehetővé teszi képek hozzáadását a bemutató diákhoz többféleképpen. 

{{% alert title="Tipp" color="info" %}} 

Aspose ingyenes konvertálókat biztosít—[JPEG PowerPoint-be](https://products.aspose.app/slides/hu/import/jpg-to-ppt) és [PNG PowerPoint-be](https://products.aspose.app/slides/hu/import/png-to-ppt)—amelyekkel gyorsan készíthet bemutatókat képekből. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Ha egy képet képkockaként szeretne hozzáadni – különösen, ha átméretezni, effektusokat alkalmazni vagy más szabványos formázási lehetőségeket használni kíván – tekintse meg a [Képkocka](/slides/hu/cpp/picture-frame/) oldalt. 

{{% /alert %}} 

{{% alert title="Megjegyzés" color="warning" %}}

Képeket konvertálhat az egyik formátumból a másikba. Lásd a következő oldalakat: konvertálás [kép JPG-re](https://products.aspose.com/slides/hu/cpp/conversion/image-to-jpg/), [JPG képre](https://products.aspose.com/slides/hu/cpp/conversion/jpg-to-image/), [JPG PNG-re](https://products.aspose.com/slides/hu/cpp/conversion/jpg-to-png/), [PNG JPG-re](https://products.aspose.com/slides/hu/cpp/conversion/png-to-jpg/), [PNG SVG-re](https://products.aspose.com/slides/hu/cpp/conversion/png-to-svg/), és [SVG PNG-re](https://products.aspose.com/slides/hu/cpp/conversion/svg-to-png/).

{{% /alert %}}

Az Aspose.Slides a népszerű formátumokat, például a JPEG, PNG, BMP, GIF és mások támogatja. 

## **Helyileg tárolt képek hozzáadása a diákhoz**

Egy vagy több, a számítógépén tárolt képet adhat hozzá a bemutató diához. Az alábbi C++ minta kód megmutatja, hogyan adjon képhez egy diát:

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

## **Képek hozzáadása a webről a diákhoz**

Ha a diagramhoz hozzáadni kívánt kép nincs a számítógépén, közvetlenül a webről is hozzáadhatja. 

Az alábbi C++ minta kód megmutatja, hogyan adjon képet a webről egy diához:

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

## **Képek hozzáadása diamesterekhez**

A diamester tárolja és irányítja az információkat, például a témát és az elrendezést a használói diákhoz. Amikor képet ad hozzá egy diamesterhez, a kép minden, a mesterhez tartozó dián megjelenik. 

Az alábbi C++ minta kód megmutatja, hogyan adjon képet egy diamasterhez:

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

## **Képek hozzáadása diák háttérként**

A képet háttérként használhatja egy vagy több dia esetén. Részletekért lásd a *[Képek beállítása háttérként a diákhoz](/slides/hu/cpp/presentation-background/#setting-images-as-background-for-slides)*.

## **SVG hozzáadása bemutatókhoz**

SVG tartalmat adhat hozzá egy bemutatóhoz a [SvgImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/svgimage/) osztály használatával. A kapott [ISvgImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isvgimage/) objektum ezután hozzáadható a bemutató képkollekciójához, és használható képkocka létrehozásához.

Az alábbi C++ példa egy önálló SVG karakterláncot importál. Az SVG által használt összes kép, stílus és egyéb erőforrás közvetlenül az SVG tartalomba van beágyazva.

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

## **SVG tartalom importálása külső erőforrásokkal**

A tervezőeszközök, diagramkészítők, ikonrendszerek és webes csővezetékek által exportált SVG fájlok hivatkozhatnak a SVG dokumentumon kívül tárolt erőforrásokra. Például egy SVG tartalmazhat egy képhivatkozást, például `images/photo.png`, egy CSS `url(...)` értéket vagy egy betűkészlet URL‑t.

Az ilyen SVG tartalom importálásához hozzon létre egy [IExternalResourceResolver](https://reference.aspose.com/slides/hu/cpp/aspose.slides.import/iexternalresourceresolver/) implementációt, és adja át, a bázis URI‑val együtt, egy megfelelő `SvgImage` konstruktorhoz. A bázis URI az SVG dokumentum helyét azonosítja, és a relatív hivatkozások feloldásához használják.

Az [ISvgImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isvgimage/) interfész hozzáférést biztosít az importált SVG információihoz:

- `get_SvgContent()` visszaadja az SVG jelölést karakterláncként.
- `get_SvgData()` visszaadja az SVG tartalmat bájt tömbként.
- `get_BaseUri()` visszaadja a relatív hivatkozásokhoz használt bázis URI‑t.
- `get_ExternalResourceResolver()` visszaadja az SVG képhez rendelt feloldót.

### **Külső erőforrás feloldó megvalósítása**

A feloldónak két metódusa van:

- [ResolveUri](https://reference.aspose.com/slides/hu/cpp/aspose.slides.import/iexternalresourceresolver/resolveuri/) kombinálja a bázis URI‑t és egy relatív erőforrás hivatkozást, és egy abszolút URI‑t ad vissza. Null karakterláncot adjon vissza, ha a hivatkozást nem lehet feloldani vagy nem engedélyezett.
- [GetEntity](https://reference.aspose.com/slides/hu/cpp/aspose.slides.import/iexternalresourceresolver/getentity/) visszaad egy olvasható adatfolyamot egy abszolút erőforrás URI‑hoz. `nullptr`‑t adjon vissza, ha az erőforrás hiányzik, blokkolva van vagy nem érhető el. Egy tartalék adatfolyam is visszaadható, ha megfelelő.

Az alábbi feloldó csak egy engedélyezett helyi könyvtárból tölti be a hivatkozott erőforrásokat. Hálózati erőforrások és a megengedett könyvtáron kívüli elérési utak blokkolva vannak. Egy opcionális tartalék kép visszaadásra kerül a feloldatlan képhivatkozások esetén.

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

        // Ez a feloldó szándékosan csak helyi fájlok használatát engedélyezi.
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

        // Csak képfájlokhoz használjon tartalékot.
        // Kép adatfolyam visszaadása hiányzó betűtípus vagy stíluslap esetén nem lenne érvényes.
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

### **Hivatkozott erőforrások feloldása SVG importálás közben**

Tegyük fel, hogy a `assets/diagram.svg` egy relatív hivatkozást tartalmaz, például:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Az alábbi C++ példa átadja az SVG fájl URI‑ját bázis URI‑ként, és egy egyéni feloldót biztosít. A feloldó a relatív képhivatkozást abszolút URI‑vá alakítja, és egy adatfolyamot ad vissza a hivatkozott erőforrással, miközben az Aspose.Slides feldolgozza az SVG‑t.

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

// A bázis URI a SVG dokumentum helyét jelöli.
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

A `SvgImage` osztály további túlterheléseket is kínál, amelyek SVG adatot fogadnak bájt tömbként vagy adatfolyamként, valamint egy külső erőforrás feloldót és egy bázis URI‑t.

{{% alert title="Fontos" color="warning" %}}

Az erőforrás feloldó kívülről származó erőforrásokat tesz elérhetővé, miközben az Aspose.Slides feldolgozza és rendereli az SVG‑t. Nem módosítja az eredeti SVG jelölést, és nem ágyazza be automatikusan a feloldott erőforrásokat.

Amikor egy `ISvgImage` kerül hozzáadásra a bemutató képkollekciójához, a PPTX fájl tartalmazhatja az eredeti SVG ábrázolást és egy raszteres tartalék képet is. Egy hivatkozott erőforrás megjelenhet a létrehozott tartalék képen, míg egy relatív hivatkozás, például `images/photo.png`, változatlan marad a tárolt SVG‑ben. Az alkalmazás, amely a natív SVG ábrázolást rendereli, ezért kihagyhatja a hivatkozott tartalmat, ha az eredeti külső erőforrás nem érhető el.

{{% /alert %}}

### **Hordozható SVG kép létrehozása**

Ahhoz, hogy olyan SVG képet hozzon létre, amely nem függ külső fájloktól, tegye self‑contained‑é a SVG‑t a `SvgImage` létrehozása előtt. Például cserélje le a hivatkozott kép URL‑eket `data:` URI‑kra, amelyek a kép adatokat tartalmazzák:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Miután minden szükséges erőforrás be van ágyazva az SVG tartalomba, hozza létre a `SvgImage`‑t, adja hozzá a bemutató képkollekciójához, és szúrja be egy képkockába, ahogy az előző példában.

### **Hiányzó vagy blokkolt erőforrások kezelése**

Null karakterláncot adjon vissza a `ResolveUri`‑ból, ha egy erőforrás URI érvénytelen, tiltott vagy nem oldható fel. `nullptr`‑t adjon vissza a `GetEntity`‑ből, ha az erőforrás nem olvasható. Az Aspose.Slides a lehető legjobban folytatja az SVG feldolgozását az adott erőforrás nélkül.

Egy tartalék adatfolyam visszaadható hiányzó erőforrás esetén, de annak tartalma legyen kompatibilis a kért erőforrás típusával. Például csak kép adatfolyamot adjon vissza hiányzó kép esetén, nem betűkészlet vagy stíluslap esetén.

{{% alert title="Biztonság" color="warning" %}}

Ne oldjon fel önkényes fájl útvonalakat vagy korlátlan hálózati URL‑ket megbízhatatlan SVG fájlokból. Korlátozza a megengedett sémákat, könyvtárakat és hostokat. Hálózati erőforrások esetén alkalmazzon kapcsolat időkorlátot, válaszméret korlátot és tartalom ellenőrzést.

{{% /alert %}}

## **SVG konvertálása alakzatkészletévé**
Az Aspose.Slides SVG‑t alakzatkészletté konvertálhat, hasonlóan a PowerPoint megfelelő funkciójához:


![PowerPoint Popup Menu](img_01_01.png)

Ez a funkcionalitás egy [AddGroupShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapecollection/) metódus túlterhelésével valósul meg az [IShapeCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapecollection/) interfészben, amely első argumentumként egy [ISvgImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isvgimage/) objektumot kap.

Az alábbi C++ minta kód megmutatja, hogyan használja ezt a módszert egy SVG fájl alakzatkészletté konvertálásához:

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

// Forrás SVG fájl neve
auto svgFileName = System::String(u"sample.svg");

// Kimeneti bemutató fájl neve
auto outPptxPath = System::String(u"presentation.pptx");

// Új bemutató létrehozása
auto presentation = System::MakeObject<Presentation>();

// SVG fájl tartalmának beolvasása
auto svgContent = File::ReadAllText(svgFileName);

// SvgImage objektum létrehozása
auto svgImage = System::MakeObject<SvgImage>(svgContent);

// Dia méretének lekérése
auto slideSize = presentation->get_SlideSize()->get_Size();

// Az SVG képet alakzatcsoporttá konvertálja és a dia méretéhez méretezi
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// A bemutató mentése PPTX formátumban
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **Képek hozzáadása EMF‑ként a diákhoz**
Az Aspose.Slides for C++ lehetővé teszi EMF képek generálását Excel munkalapokból az Aspose.Cells segítségével, és azok hozzáadását a bemutató diáihoz. 

Az alábbi C++ minta kód megmutatja, hogyan kell ezt megtenni:

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

// Aspose.Cells for C++-t el kell indítani, mielőtt bármely típusát használjuk.
Aspose::Cells::Startup();

auto workbook = Aspose::Cells::Workbook(u"chart.xls");
auto sheet = workbook.GetWorksheets().Get(0);

// A munkalap renderelése EMF formátumban.
auto options = Aspose::Cells::ImageOrPrintOptions();
options.SetHorizontalResolution(200);
options.SetVerticalResolution(200);
options.SetImageType(Aspose::Cells::Drawing::ImageType::Emf);

auto sheetRender = Aspose::Cells::SheetRender(sheet, options);

auto presentation = System::MakeObject<Presentation>();
presentation->get_Slides()->RemoveAt(0);

for (auto pageIndex = 0; pageIndex < sheetRender.GetPageCount(); pageIndex++)
{
    // Az Aspose.Cells a renderelt oldalt bufferként adja vissza, amit az Aspose.Slides képként ad hozzá.
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

## **Képek cseréje a képkollekcióban**

Az Aspose.Slides lehetővé teszi a bemutató képkollekciójában tárolt képek cseréjét, beleértve a diák alakzatai által használt képeket is. Ez a szakasz többféle módot ír le a kollekcióban lévő képek frissítésére. Képet cserélhet nyers bájt adatokkal, egy [IImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iimage/) példánnyal, vagy egy már a kollekcióban létező képpel.

Kövesse az alábbi lépéseket:

1. Töltse be a képeket tartalmazó bemutató fájlt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztállyal.
1. Töltsön be egy új képet egy fájlból egy bájt tömbbe.
1. Cserélje le a célképet az új képre a bájt tömb használatával.
1. A második megközelítésben töltse be a képet egy [IImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iimage/) objektumba, és cserélje le a célképet ezzel az objektummal.
1. A harmadik megközelítésben cserélje le a célképet egy már a bemutató képkollekciójában létező képpel.
1. Írja ki a módosított bemutatót PPTX fájlként.

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

// Hozzon létre egy Presentation példányt, amely egy bemutató fájlt képvisel.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Az első mód.
auto imageData = File::ReadAllBytes(u"image0.jpeg");
auto oldImage = presentation->get_Image(0);
oldImage->ReplaceImage(imageData);

// A második mód.
auto newImage = Images::FromFile(u"image1.png");
oldImage = presentation->get_Image(1);
oldImage->ReplaceImage(newImage);
newImage->Dispose();

// A harmadik mód.
oldImage = presentation->get_Image(2);
oldImage->ReplaceImage(presentation->get_Image(3));

// Mentse a bemutatót egy fájlba.
presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}

Az Aspose ingyenes [Szöveg GIF‑re](https://products.aspose.app/slides/hu/text-to-gif) konvertálója segítségével egyszerűen animálhat szöveget és hozhat létre GIF‑eket a szövegből. 

{{% /alert %}}

## **GYIK**

**Megmarad‑e az eredeti kép felbontása a beillesztés után?**

Igen. A forrás pixelek megmaradnak, de a végső megjelenés attól függ, hogy a [picture](/slides/hu/cpp/picture-frame/) hogyan skálázódik a dián és milyen tömörítést alkalmaznak mentéskor.

**Mi a legjobb módja annak, hogy egy logót egyszerre cseréljünk több tucat dián?**

Helyezze a logót a master diára vagy egy elrendezésre, és cserélje a bemutató képkollekciójában – a frissítések minden, azt az erőforrást használó elemre kiterjednek.

**Konvertálható‑e egy beillesztett SVG szerkeszthető alakzatokká?**

Igen. Az SVG konvertálható alakzatcsoporttá, amelynek egyes részei szerkeszthetők a szokásos alakzat tulajdonságokkal.

**Hogyan állíthatok be egy képet háttérként több diára egyszerre?**

[Tegye a képet háttérként](/slides/hu/cpp/presentation-background/) a master diára vagy a megfelelő elrendezésre – minden, ezt a mastert/elrendezést használó dia örökli a hátteret.

**Hogyan kerülhetem el, hogy a prezentáció túl nagy legyen a sok képek miatt?**

Használjon egyetlen kép erőforrást a másolatok helyett, válasszon megfelelő felbontást, alkalmazzon tömörítést mentéskor, és tartsa a gyakran ismétlődő grafikákat a masteren, ahol szükséges.