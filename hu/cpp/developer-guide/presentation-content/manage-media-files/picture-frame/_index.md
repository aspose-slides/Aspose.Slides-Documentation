---
title: Képkeretek kezelése bemutatókban C++ használatával
linktitle: Képkeret
type: docs
weight: 10
url: /hu/cpp/picture-frame/
keywords:
- képkeret
- képkeret hozzáadása
- képkeret létrehozása
- beágyazott kép
- kapcsolt kép
- kép kinyerése
- raszteres kép
- SVG kép
- kép vágása
- vágott területek törlése
- kép tömörítése
- StretchOffset
- képkeret formázása
- relatív skála
- képhatás
- oldalarány
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Képkeretek létrehozása, formázása, összekapcsolása, vágása, kinyerése és tömörítése bemutatókban az Aspose.Slides for C++ segítségével."
---
## **Áttekintés**

A képkeret egy dián lévő alakzat, amely egy képet jelenít meg. Az Aspose.Slides-ben a kép erőforrás és a képet megjelenítő alakzat különálló objektumok: egy [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) beágyazott kép erőforrásokat birtokol a [image collection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_images/) segítségével, míg egy [IPictureFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipictureframe/) szabályozza a kép pozícióját, méretét, vonalformázását, forgását, vágását, képhatásait és egyéb keretszintű beállításokat.

Ez a szétválasztás hasznos, ha ugyanazt a képet többször jelenítik meg. A képet egyszer hozzáadja a bemutatóhoz, megőrzi a visszaadott [IPPImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ippimage/), és ezt a kép erőforrást használja a képkeretek létrehozásakor.

A képkeretek tartalmazhatnak raszteres képeket, például PNG vagy JPEG, valamint vektoros SVG képeket. Ezenkívül hivatkozhatnak kapcsolt képekre is, ahelyett, hogy a képadatokat a bemutatóban tárolnák. Ez a választás befolyásolja a hordozhatóságot, a fájlméretet, a kinyerést és az export viselkedését, ezért célszerű eldönteni, hogyan legyen a kép tárolva, mielőtt formázást vagy optimalizálást alkalmaznánk.

## **Beágyazott kép hozzáadása és formázása**

Beágyazott kép esetén adja hozzá a képadatokat a bemutatóhoz, és hozzon létre egy képkeretet az [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shapecollection/addpictureframe/) segítségével. A kép a bemutató csomag részévé válik, így a bemutató önálló marad, ha egy másik számítógépre kerül.

Az alábbi példa JPEG képet ad hozzá, a kép natív méretében hoz létre egy keretet, és vonalformázást és forgatást alkalmaz:

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 100, image->get_Width(), image->get_Height(), image);
pictureFrame->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pictureFrame->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pictureFrame->get_LineFormat()->set_Width(3.0);
pictureFrame->set_Rotation(15.0f);

presentation->Save(u"picture-frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

A képkeret szabályozza a megjelenített geometriai adatokat; a keret méretének módosítása nem változtatja meg az eredeti pixelméreteket, amelyek a beágyazott kép erőforrásban tárolva vannak. Ez a különbség későbbi képvágás vagy -tömörítés esetén fontos lesz.

## **Relatív skála használata**

[IPictureFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipictureframe/) relatív szélesség‑ és magasság‑skálázást biztosít a kerethez. Az `1.0` érték az eredeti kép 100 %-a. A relatív skála hasznos, ha a munkafolyamatnak a forráskép méretéhez viszonyított arányt kell megőriznie a végső méretek kézi kiszámítása helyett.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, image);
pictureFrame->set_RelativeScaleWidth(1.35f);
pictureFrame->set_RelativeScaleHeight(0.8f);

presentation->Save(u"relative-scale.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

A relatív skála módosítja a keret skála beállításait; nem resample‑eli vagy tömöríti a beágyazott képet.

## **Beágyazott és kapcsolt képek**

Egy beágyazott kép a képadatokat a bemutatóban tárolja, ezért a legbiztonságosabb választás a hordozhatóság és az előre látható renderelés szempontjából. Egy kapcsolt kép az [ISlidesPicture](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidespicture/) link útvonalán keresztül tárolja a külső helyet, ahelyett, hogy a képadatokat ugyanúgy beágyazná.

A kapcsolt képek csökkenthetik a PPTX‑ben tárolt képadatok mennyiségét, de külső függőséget vezetnek be. A kapcsolt fájlnak elérhetőnek kell maradnia az alkalmazás számára, amely megnyitja vagy rendereli a bemutatót. Ha az útvonal megváltozik, a fájl áthelyezésre kerül, vagy az erőforrás nem érhető el, a kapcsolt kép nem jelenik meg a várt módon. Azoknál a bemutatóknál, amelyeket e‑mailben kell elküldeni, archiválni vagy izolált környezetben renderelni, a beágyazott képek általában megbízhatóbbak.

### **Kapcsolt kép hozzáadása**

Az alábbi példa egy képkeretet hoz létre, és egy helyi képfájlra mutat. Csak a kép kapcsolásával foglalkozik; a videó kapcsolás egy külön médiamunkafolyamat, és szándékosan nincs keverve ebbe a példába.

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 320, 180, nullptr);
auto linkPath = Path::GetFullPath(u"linked-image.jpg");
pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(linkPath);

presentation->Save(u"linked-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Használjon linkeket, ha a külső fájlkezelés szándékos. Ne használja őket csupán tömörítés helyettesítésére: egy kis PPTX törött képfüggőségekkel általában kevésbé hasznos, mint egy nagyobb önálló bemutató.

## **Képek kinyerése képkeretekből**

Mielőtt képet nyerne ki egy meglévő bemutatóból, ellenőrizze, hogy az alakzat valóban egy [IPictureFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipictureframe/), és hogy beágyazott képet tartalmaz. A kapcsolt képkeretek esetleg nem tartalmaznak képadatokat, amelyeket ugyanígy ki lehetne nyerni.

### **Raszeres kép kinyerése**

A modern kép‑API közvetlenül a [IImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iimage/)-t használja. Az alábbi példa megtalálja az első beágyazott raszteres képet egy dián, és PNG‑ként menti el:

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IPictureFrame>(shape))
    {
        continue;
    }

    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto embeddedImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image();
    if (embeddedImage == nullptr || embeddedImage->get_SvgImage() != nullptr)
    {
        continue;
    }

    auto rasterImage = embeddedImage->get_Image();
    rasterImage->Save(u"extracted-image.png", ImageFormat::Png);
    break;
}

presentation->Dispose();
```

A [IImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iimage/) használatával mentés a kinyert képet a kért kimeneti formátumba konvertálja. Ha a bemutatóban tárolt kódolt bájtokra van szüksége egy konvertált raszteres fájl helyett, akkor a kép erőforrás bináris adatait használja.

### **SVG kép kinyerése**

SVG kép esetén a [IPPImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ippimage/) egy [ISvgImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isvgimage/) objektumot exponál. Ez lehetővé teszi, hogy közvetlenül a SVG adatot nyerje ki, a kép rasterizálása nélkül.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IPictureFrame>(shape))
    {
        continue;
    }

    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto embeddedImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image();
    if (embeddedImage == nullptr)
    {
        continue;
    }

    auto svgImage = embeddedImage->get_SvgImage();
    if (svgImage == nullptr)
    {
        continue;
    }

    File::WriteAllBytes(u"extracted-image.svg", svgImage->get_SvgData());
    break;
}

presentation->Dispose();
```

A SVG tartalom SVG‑ként tartása megőrzi a vektoros forrást a bemutatóban. A raszteres exportok, például PNG vagy JPEG, kötelezően pixelre renderelik ezt a vektort. A PDF vagy SVG diaexport is egy renderelési művelet, ezért az exportált grafika nem tekinthető az eredeti beágyazott SVG bit‑pontos másolatának; használja a beágyazott [ISvgImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isvgimage/) adatot, ha maga a vektoros erőforrás szükséges.

## **Kép vágása**

A vágás megváltoztatja, hogy a kép mely része látható a kereten belül. A [IPictureFillFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipicturefillformat/) vágási értékei a forráskép dimenzióinak százalékában vannak megadva. A vágás kezdetben nem törli a rejtett pixeleket a beágyazott képből; csak a látható régiót módosítja.

Az alábbi példa biztonságosan megtalál egy képkeretet, és alkalmazza a vágási értékeket:

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    pictureFrame->get_PictureFormat()->set_CropLeft(23.6f);
    pictureFrame->get_PictureFormat()->set_CropRight(21.5f);
    pictureFrame->get_PictureFormat()->set_CropTop(3.0f);
    pictureFrame->get_PictureFormat()->set_CropBottom(31.0f);
    presentation->Save(u"cropped-image.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

Mivel a rejtett képadatok továbbra is jelen vannak, a vágás később megváltoztatható az eredeti pixelek elvesztése nélkül. Ha a fájlméret fontosabb a visszavonhatóságnál, a vágott területek fizikailag eltávolíthatók a következő szakaszban leírtak szerint.

## **Vágott képadatok eltávolítása**

[IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) eltávolítja a képadatokat a jelenlegi vágási téglalapon kívül, és visszaadja a kapott kép erőforrást. Ez csökkentheti a fájlméretet, de destruktív optimalizáció: a bemutató mentése után a eltávolított pixelek már nem állnak rendelkezésre egy későbbi „un‑crop” művelethez.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"cropped-image.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto croppedImage = pictureFrame->get_PictureFormat()->DeletePictureCroppedAreas();
    if (croppedImage != nullptr)
    {
        presentation->Save(u"cropped-data-removed.pptx", SaveFormat::Pptx);
    }
}

presentation->Dispose();
```

A metódus új kép erőforrást adhat a bemutatóhoz. Ha az eredeti kép más képkeretek által is használva van, azoknak továbbra is szükségük van a meglévő erőforrásra, így a vágott területek törlése nem feltétlenül csökkenti a képek teljes számát. WMF vagy EMF tartalom vágása ezzel a metódussal a vágott eredményt PNG‑re rasterizálja.

## **Raszeres képek tömörítése**

[IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipicturefillformat/compressimage/) csökkenti a raszteres kép felbontását a kép megjelenítési méretéhez viszonyítva. Ugyanabban a műveletben eltávolíthatja a vágott területeket is. A metódus `true`‑t ad vissza, ha a képet átméretezte vagy levágta, és `false`‑t, ha nem volt szükség változtatásra.

Használjon előre definiált [PicturesCompression](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/picturescompression/) értéket, ha egy szabványos célfelbontás elegendő:

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto compressed = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);
    Console::WriteLine(compressed ? String(u"The image was compressed.") : String(u"No compression was necessary."));
    presentation->Save(u"compressed-image.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

Egy egyedi pozitív DPI érték átadható az enumerációs érték helyett, ha egy konkrét cél szükséges.

A tömörítés raszteres képekre vonatkozik. Az SVG és a metafájl tartalom nem csökken ezen a raszteres tömörítési munkafolyamaton. Emellett ne feledje, hogy az alacsonyabb felbontás és a törölt vágott területek nem állíthatók vissza az optimalizált bemutatóból. Válasszon célfelbontást a legnagyobb megjelenítési vagy exportálási méret alapján, nem pedig a legkisebb DPI globális alkalmazásával.

## **Képhatások ellenőrzése**

A képhatások a keret által használt képen tárolódnak. A kép‑transzformációs gyűjtemény tartalmazhat olyan hatásokat, mint a fix alfa‑moduláció az átlátszósághoz és a luminancia a fényerő és kontraszt szabályozásához. Az alábbi példa biztonságosan beolvassa mindkét hatást az első dián lévő képkeretből:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ILuminance.h>
#include <DOM/Effects/ILuminanceEffectiveData.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();

    for (auto&& effect : imageTransform)
    {
        if (ObjectExt::Is<IAlphaModulateFixed>(effect))
        {
            auto alphaModulateFixed = ExplicitCast<IAlphaModulateFixed>(effect);
            auto transparency = 100.0f - alphaModulateFixed->get_Amount();
            Console::WriteLine(String(u"Transparency: ") + transparency);
        }

        if (ObjectExt::Is<ILuminance>(effect))
        {
            auto luminanceEffect = ExplicitCast<ILuminance>(effect);
            auto luminance = luminanceEffect->GetEffective();
            Console::WriteLine(String(u"Brightness: ") + luminance->get_Brightness());
            Console::WriteLine(String(u"Contrast: ") + luminance->get_Contrast());
        }
    }
}

presentation->Dispose();
```

Ezek a hatások megváltoztatják, hogyan renderelődik a kép a keretben; nem írják felül az eredeti beágyazott kép bájtjait.

## **Képkeret geometria zárolása**

Az [IPictureFrameLock](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipictureframelock/) beállításai szabályozzák, hogy mely szerkesztési műveletek vannak letiltva egy képkeretnél. Például a [aspect-ratio lock](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) megőrzi az alakzat arányait átméretezés közben.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 100, image->get_Width(), image->get_Height(), image);
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);

presentation->Save(u"locked-picture-frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

A zárolás a képkeret alakzatra vonatkozik. Nem kényszeríti a forrásképet, hogy ugyanarra az arányra legyen resample‑elve vagy véglegesen módosítva.

## **StretchOffset értékek beállítása**

Ha a kép kitöltési módja „stretch”, a [IPictureFillFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipicturefillformat/) stretch‑offset értékei a kitöltési téglalapot határozzák meg a képkeret határoló dobozához képest. Pozitív százalékok széltől befelé hoznak, míg negatív százalékok kifelé nyújtanak.

Ez különbözik a vágástól. A vágási értékek kiválasztják, hogy a forráskép mely része legyen látható; a stretch‑offsetok pedig a téglalapot változtatják, amelybe a látható képkitöltés nyúlik.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.png");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10, 10, 400, 300, image);
pictureFrame->get_PictureFormat()->set_PictureFillMode(PictureFillMode::Stretch);
pictureFrame->get_PictureFormat()->set_StretchOffsetLeft(12.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetRight(12.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetTop(8.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetBottom(8.0f);

presentation->Save(u"stretch-offsets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Használja a stretch‑offsetokat kitöltés elhelyezéséhez. Használja a vágási tulajdonságokat, ha a cél a forráskép széleinek elrejtése.

## **Tárolás, fájlméret és exportálási megfontolások**

A fő kompromisszumok könnyebben kezelhetők, ha a kép tárolást és a képkeret formázását külön kezelik:

- **Beágyazott képek** önállóvá teszik a bemutatót, és a legmegbízhatóbbak megosztáskor és szerveroldali rendereléskor, de a nagy raszteres képek növelik a PPTX méretét és a memóriahasználatot.
- **Kapcsolt képek** kisebb csomagot tarthatnak, de a bemutató a külső fájlok elérhetőségétől függ a tárolt útvonalakon vagy helyeken.
- **Vágás** eleve nem destruktív. A rejtett pixelek beágyazva maradnak, amíg a vágott területeket explicit módon nem törlik vagy a tömörítés során nem távolítják el.
- **Tömörítés** jelentősen csökkentheti a fájlméretet túlméretezett raszteres képek esetén, de a forrás felbontást feláldozza. A dián való végső méret ismerete után kell alkalmazni.
- **SVG képek** legyenek SVG formátumban, ha a vektoros megőrzés fontos. A beágyazott SVG közvetlen kinyerése akkor hasznos, ha maga a vektoros erőforrás szükséges. A raszteres diaexportok mindig a dia renderelt képét pixelekre konvertálják.
- **Ismétlődő képek** esetén használja újra a meglévő [IPPImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ippimage/) erőforrást, ahelyett, hogy ugyanazt a fájlt többször betöltené a bemutató munkafolyamatába.

Nagy bemutatók esetén a képoptimalizálás általában a leghatékonyabb, ha szelektíven hajtják végre: tartsuk a logókat és diagramokat vektoros tartalomként, tömörítsük a fényképeket a tényleges megjelenítési méretük szerint, távolítsuk el a vágott pixeleket csak akkor, ha a későbbi szerkesztés nem szükséges, és kerüljük a külső linkeket, hacsak a függőségkezelés nem része a telepítési tervezésnek.

## **GYIK**

**Mi a különbség a képkeret és a kép erőforrás között?**

Az [IPPImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ippimage/) egy a bemutatóhoz kapcsolódó kép erőforrást képvisel. Az [IPictureFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipictureframe/) egy dián lévő alakzat, amely egy képet jelenít meg, és keretszintű geometriai és formázási adatokat tárol, mint például méret, forgatás, vágási értékek, hatások és zárolások.

**Be kellene-e ágyaznom vagy kapcsolnom a képeket?**

Ágyazza be a képeket, ha a bemutatónak hordozhatónak, archiválhatónak vagy külső erőforrások hozzáférése nélkül renderelhetőnek kell lennie. Kapcsolja csak akkor a képeket, ha a képfájlok kívül tartása szándékos, és a külső helyek megbízhatóan karbantarthatók.

**Csökkenti a vágás a PPTX fájlméretet?**

Nem önmagában. A normál vágási beállítások elrejtik a forráskép részeit, de a pixeleket a háttérben megtartják. Használja az [IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) metódust vagy a kép tömörítést vágott‑terület eltávolítással, ha ezeket a pixeleket véglegesen el lehet távolítani.

**Vissza tudom-e állítani a kép minőségét a tömörítés után?**

Nem. A tömörítés csökkentheti a tárolt raszteres felbontást, és a vágott területek eltávolítása adatvesztést eredményez. Tartsa meg az eredeti forrásképet a bemutatón kívül, ha később nagy felbontású szerkesztésre lesz szükség.

**Hogyan kell kezelni az SVG képeket?**

Tartsa a SVG tartalmat SVG‑ként, ha a vektoros hűség fontos. A beágyazott [ISvgImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isvgimage/) közvetlenül kinyerhető. A diát raster formátumra, például PNG‑re vagy JPEG‑re renderelő exportálás a SVG‑t pixelekre rasterizálja.

**Hogyan kerülhetem el a nem biztonságos cast‑okat meglévő diák olvasásakor?**

Ellenőrizze az alakzat típusát, mielőtt képkeret‑specifikus tagokhoz férne hozzá. Tesztelje az alakzatot [IPictureFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipictureframe/) használatával, mielőtt futásidejű cast‑ot végez, és a cast eredményét helyi változóba rendelje, mielelőtt a képkeret‑specifikus tagokhoz hozzáférne.