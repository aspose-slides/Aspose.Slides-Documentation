---
title: Képek kezelésének optimalizálása prezentációkban C++-szal
linktitle: Képek kezelése
type: docs
weight: 10
url: /hu/cpp/image/
keywords:
- kép hozzáadása
- grafika hozzáadása
- bitmap hozzáadása
- kép cseréje
- grafika cseréje
- webről
- háttér
- PNG hozzáadása
- JPG hozzáadása
- SVG hozzáadása
- külső SVG erőforrások
- SVG feloldó
- hivatkozott SVG képek
- SVG betűtípusok
- EMF hozzáadása
- WMF hozzáadása
- TIFF hozzáadása
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Egyszerűsítse a képek kezelését PowerPointban és OpenDocumentben az Aspose.Slides for C++ segítségével, optimalizálja a teljesítményt és automatizálja a munkafolyamatát."
---
## **Bevezetés**

A képek vonzóbbá és vizuálisan szemléletesebbé teszik az előadásokat. A Microsoft PowerPointban képeket szúrhat be a diákra fájlokból, az internetről vagy egyéb forrásokból. Hasonlóan, az Aspose.Slides többféleképpen teszi lehetővé képek hozzáadását a prezentáció diáira. 

{{% alert title="Tip" color="primary" %}} 

Az Aspose ingyenes konvertereket biztosít — [JPEG to PowerPoint](https://products.aspose.app/slides/hu/import/jpg-to-ppt) és [PNG to PowerPoint](https://products.aspose.app/slides/hu/import/png-to-ppt) — amelyekkel gyorsan készíthet prezentációkat képekből. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Ha képet szeretne képkockaként hozzáadni — különösen, ha átméretezést, effektusok alkalmazását vagy egyéb szabványos formázási lehetőségeket tervez — tekintse meg a [Picture Frame](/slides/hu/cpp/picture-frame/) oldalt. 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Átalakíthatja a képeket az egyik formátumból a másikba. Lásd az alábbi oldalakat: konvertálás [image to JPG](https://products.aspose.com/slides/hu/cpp/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/hu/cpp/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/hu/cpp/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/hu/cpp/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/hu/cpp/conversion/png-to-svg/), és [SVG to PNG](https://products.aspose.com/slides/hu/cpp/conversion/svg-to-png/).

{{% /alert %}}

Az Aspose.Slides támogatja a képeket a népszerű formátumokban, mint a JPEG, PNG, BMP, GIF és egyebek. 

## **Helyi képek hozzáadása a diákhoz**

A számítógépén tárolt egy vagy több képet hozzáadhat egy prezentációs diához. Az alábbi C++ példa kód mutatja, hogyan lehet képet hozzáadni egy diához:

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

Ha a diára hozzáadni kívánt kép nincs a számítógépén, közvetlenül a webről adhatja hozzá.

Az alábbi C++ példa kód mutatja, hogyan lehet képet a webről egy diához hozzáadni:

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

## **Képek hozzáadása a Dia-mesterekhez**

A dia-mester tárolja és szabályozza a témát és elrendezést a rá épülő diák számára. Ha képet ad hozzá egy dia-mesterhez, a kép minden, az adott masterhez tartozó dián megjelenik.

Az alábbi C++ példa kód megmutatja, hogyan lehet képet hozzáadni egy dia-mesterhez:

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

## **Képek hozzáadása dia háttereként**

Képet használhat háttérként egy vagy több dián. Részletekért lásd a *[Képek beállítása dia háttérként](/slides/hu/cpp/presentation-background/#setting-images-as-background-for-slides)* oldalt.

## **SVG hozzáadása a prezentációkhoz**

Az SVG tartalmat a prezentációhoz a [SvgImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/svgimage/) osztály használatával adhatja hozzá. A keletkező [ISvgImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isvgimage/) objektum ezután hozzáadható a prezentáció képgyűjteményéhez, és felhasználható képkocka létrehozásához.

Az alábbi C++ példa egy önálló SVG karakterláncot importál. Ennek az SVG-nek minden képe, stílusa és egyéb erőforrása közvetlenül a SVG tartalomban van beágyazva.

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

A tervezőeszközök, diagram szerkesztők, ikon rendszerek és webes csővezetékek által exportált SVG fájlok hivatkozhatnak olyan erőforrásokra, amelyeket az SVG dokumentumon kívül tárolnak. Például egy SVG tartalmazhat egy képhivatkozást, mint `images/photo.png`, egy CSS `url(...)` értéket vagy egy betűtípus URL-t.

Az ilyen SVG tartalom importálásához hozzon létre egy [IExternalResourceResolver](https://reference.aspose.com/slides/hu/cpp/aspose.slides.import/iexternalresourceresolver/) megvalósítást, és adja át, a bázis‑URI‑val együtt, egy megfelelő `SvgImage` konstruktorának. A bázis‑URI az SVG dokumentum helyét azonosítja, és a relatív hivatkozások feloldásához használatos.

Az [ISvgImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isvgimage/) interfész hozzáférést biztosít az importált SVG információihoz:

- `get_SvgContent()` visszaadja az SVG jelölést karakterláncként.
- `get_SvgData()` visszaadja az SVG tartalmat bájt tömbként.
- `get_BaseUri()` visszaadja a relatív hivatkozásokhoz használt bázis‑URI‑t.
- `get_ExternalResourceResolver()` visszaadja az SVG képhez rendelt feloldót.

### **Külső erőforrás feloldó megvalósítása**

A feloldónak két metódusa van:

- [ResolveUri](https://reference.aspose.com/slides/hu/cpp/aspose.slides.import/iexternalresourceresolver/resolveuri/) összekapcsolja a bázis‑URI‑t és egy relatív erőforrás‑hivatkozást, és visszaad egy abszolút URI‑t. Ha a hivatkozást nem lehet feloldani vagy nem engedélyezett, null karakterláncot adjon vissza.
- [GetEntity](https://reference.aspose.com/slides/hu/cpp/aspose.slides.import/iexternalresourceresolver/getentity/) visszaad egy olvasható adatfolyamot egy abszolút erőforrás‑URI‑hez. Ha az erőforrás hiányzik, blokkolva van vagy nem érhető el, `nullptr`‑t adjon vissza. Szükség esetén visszaadható egy tartalék adatfolyam is.

Az alábbi feloldó csak egy engedélyezett helyi könyvtárból tölti be a hivatkozott erőforrásokat. A hálózati erőforrások és a megengedett könyvtáron kívüli útvonalak blokkolva vannak. Nem feloldott képhivatkozások esetén egy opcionális tartalék kép kerül visszaadásra.

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

        // Csak képfájlokhoz használjon tartalékot. Kép adatfolyam visszaadása
        // egy hiányzó betűtípus vagy stíluslap esetén nem lenne érvényes.
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

### **Linkelt erőforrások feloldása SVG importáláskor**

Tegyük fel, hogy az `assets/diagram.svg` egy relatív hivatkozást tartalmaz, például:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Az alábbi C++ példa a SVG fájl URI‑ját adja át bázis‑URI‑ként, és egy saját feloldót biztosít. A feloldó a relatív képhivatkozást abszolút URI‑vá alakítja, és egy adatfolyamot ad vissza, amely a hivatkozott erőforrást tartalmazza, miközben az Aspose.Slides a SVG‑t feldolgozza.

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

// Az alaptárgy (base URI) az SVG dokumentum helyét jelöli.
auto baseUri = MakeObject<Uri>(svgFilePath)->get_AbsoluteUri();

auto fallbackImageData = ArrayPtr<uint8_t>();
auto fallbackImagePath = Path::Combine(assetDirectory, u"fallback.png");
if (File::Exists(fallbackImagePath))
{
    fallbackImageData = File::ReadAllBytes(fallbackImagePath);
}

auto resolver = MakeObject<LocalSvgResourceResolver>(assetDirectory, fallbackImageData);
auto svgImage = MakeObject<SvgImage>(svgContent, resolver, baseUri);

// Az ISvgImage a forrás tartalmat, a bináris adatot, az alaptárgyhelyet és a feloldót teszi elérhetővé.
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

A `SvgImage` osztály további túlterheléseket is kínál, amelyek SVG adatot bájt tömbként vagy adatfolyamként fogadnak, valamint egy külső erőforrás‑feloldót és egy bázis‑URI‑t.

{{% alert title="Important" color="warning" %}}

Az erőforrás‑feloldó lehetővé teszi a külső erőforrások elérhetőségét, miközben az Aspose.Slides a SVG‑t feldolgozza és megjeleníti. Nem módosítja az eredeti SVG jelölést, és nem ágyazza be automatikusan a feloldott erőforrásokat.

Ha egy `ISvgImage` hozzá van adva a prezentáció képgyűjteményéhez, a PPTX fájl tartalmazhatja az eredeti SVG ábrázolást és egy raszteres tartalék képet is. Egy hivatkozott erőforrás megjelenhet a generált tartalék képen, míg egy relatív hivatkozás, például `images/photo.png`, változatlan marad a tárolt SVG‑ben. A natív SVG ábrázolást megjelenítő alkalmazás ezért kihagyhatja a hivatkozott tartalmat, ha az eredeti külső erőforrás nem érhető el.

{{% /alert %}}

### **Hordozható SVG kép létrehozása**

Egy olyan SVG képet, amely nem függ külső fájloktól, önállóvá kell tenni a `SvgImage` létrehozása előtt. Például cserélje le a hivatkozott kép‑URL‑eket `data:` URI‑kra, amelyek a kép adatot tartalmazzák:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Miután minden szükséges erőforrás be van ágyazva az SVG tartalomba, hozza létre a `SvgImage`‑t, adja hozzá a prezentáció képgyűjteményéhez, és szúrja be egy képkockába, ahogy az előző példában látható.

### **Hiányzó vagy blokkolt erőforrások kezelése**

`ResolveUri` esetén adjon vissza null karakterláncot, ha az erőforrás‑URI érvénytelen, tiltott vagy nem oldható fel. `GetEntity` esetén adjon vissza `nullptr`‑t, ha az erőforrás nem olvasható. Az Aspose.Slides lehetőség szerint a hiányzó erőforrás nélkül folytatja a SVG feldolgozását.

Tartalék adatfolyamot is vissza lehet adni hiányzó erőforrások esetén, de annak tartalma kompatibilis kell legyen a kért erőforrás típusával. Például csak képadatfolyamot adjon vissza hiányzó képhez, nem betűtípushoz vagy stíluslaphoz.

{{% alert title="Security" color="warning" %}}

Ne oldjon fel tetszőleges fájlútvonalakat vagy korlátlan hálózati URL‑ket megbízhatatlan SVG fájlokból. Szűkítse a megengedett sémákat, könyvtárakat és hostokat. Hálózati erőforrások esetén alkalmazzon kapcsolat‑időtúllépéseket, válasz‑méret korlátokat és tartalom‑validációt.

{{% /alert %}}

## **SVG átalakítása alakzatformákká**
Aspose.Slides képes egy SVG‑t alakzatcsoporttá konvertálni, hasonlóan a PowerPoint megfelelő funkciójához:

![PowerPoint Popup Menu](img_01_01.png)

Ez a funkcionalitás a [AddGroupShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapecollection/) metódus túlterhelésén keresztül érhető el az [IShapeCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapecollection/) interfészen, amely egy [ISvgImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isvgimage/) objektumot vesz első argumentumként.

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

// Kimeneti prezentáció fájl neve
auto outPptxPath = System::String(u"presentation.pptx");

// Új prezentáció létrehozása
auto presentation = System::MakeObject<Presentation>();

// SVG fájl tartalmának beolvasása
auto svgContent = File::ReadAllText(svgFileName);

// SvgImage objektum létrehozása
auto svgImage = System::MakeObject<SvgImage>(svgContent);

// Diák méretének lekérése
auto slideSize = presentation->get_SlideSize()->get_Size();

// Az SVG képet alakzatcsoporttá konvertálja és a diák méretéhez méretezze
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// A prezentáció mentése PPTX formátumban
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **Képek hozzáadása EMF formátumban a diákhoz**
Az Aspose.Slides for C++ lehetővé teszi, hogy EMF képeket generáljon Excel munkalapokból az Aspose.Cells segítségével, és ezeket a prezentáció diáihoz adja.

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

// Az Aspose.Cells for C++-et el kell indítani, mielőtt bármely típusát használjuk.
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
    // Az Aspose.Cells a renderelt oldalt bufferként adja vissza, amelyet az Aspose.Slides képként ad hozzá.
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

## **Képek cseréje a képgyűjteményben**

Az Aspose.Slides lehetővé teszi a prezentáció képgyűjteményében tárolt képek cseréjét, beleértve a diák alakzatai által használt képeket is. Ez a szakasz több módot ismertet a képek frissítésére a gyűjteményben. Egy képet nyers bájtadatokkal, egy [IImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iimage/) példánnyal vagy egy már meglévő képpel is cserélhet a gyűjteményben.

1. Töltse be a képeket tartalmazó prezentációs fájlt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztály segítségével.  
2. Töltsön be egy új képet egy fájlból egy bájt tömbbe.  
3. Cserélje le a célképet az új képre a bájt tömb segítségével.  
4. A második megközelítésben töltse be a képet egy [IImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iimage/) objektumba, és cserélje le a célképet ezzel az objektummal.  
5. A harmadik megközelítésben cserélje le a célképet egy olyan képpel, amely már létezik a prezentáció képgyűjteményében.  
6. Írja ki a módosított prezentációt PPTX fájlként.  

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

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
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

// Mentse a prezentációt egy fájlba.
presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}

Az Aspose ingyenes [Text to GIF](https://products.aspose.app/slides/hu/text-to-gif) konverterével könnyedén animálhat szöveget és GIF‑eket hozhat létre szövegből. 

{{% /alert %}}

## **GYIK**

**Megmarad az eredeti kép felbontása a beillesztés után?**

Igen. A forráspixel megmarad, de a végső megjelenés attól függ, hogy a [picture](/slides/hu/cpp/picture-frame/) hogyan van méretezve a dián, és milyen tömörítés történt a mentéskor.

**Mi a legjobb módja annak, hogy egyszerre cseréljünk ki ugyanazt a logót tucatnyi dián?**

Helyezze a logót a mester diára vagy egy elrendezésre, és cserélje ki a prezentáció képgyűjteményében — a frissítések minden olyan elemre kihatnak, amely ezt az erőforrást használja.

**Átalakítható-e egy beillesztett SVG szerkeszthető alakzatokká?**

Igen. Egy SVG-t átalakíthat egy alakzategységbe, amelynek egyes részei ezután a szokásos alakzattulajdonságokkal szerkeszthetők.

**Hogyan állíthatok be egy képet háttérként több diára egyszerre?**

[Állítsa be a képet háttérként](/slides/hu/cpp/presentation-background/) a mesterdián vagy a megfelelő elrendezésen — minden olyan dia, amely ezt a mestert/elrendezést használja, megörökli a hátteret.

**Hogyan akadályozhatom, hogy a prezentáció túl nagyra nőjen sok kép miatt?**

Használjon egyetlen képernyőforrást a duplikátumok helyett, válasszon megfelelő felbontást, alkalmazzon tömörítést mentéskor, és ismétlődő grafikákat a megfelelő esetekben helyezze a mesterdíára.