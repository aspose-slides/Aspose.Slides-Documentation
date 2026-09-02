---
title: Képkeretek kezelése prezentációkban C++ használatával
linktitle: Képkeret
type: docs
weight: 10
url: /hu/cpp/picture-frame/
keywords:
- képkeret
- képkeret hozzáadása
- képkeret létrehozása
- beágyazott kép
- összekapcsolt kép
- kép kinyerése
- raszteres kép
- SVG kép
- kép vágása
- vágott területek törlése
- kép tömörítése
- StretchOffset
- képkeret formázása
- relatív méretezés
- kép hatás
- oldalarány
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Képkeretek létrehozása, formázása, összekapcsolása, vágása, kinyerése és tömörítése prezentációkban az Aspose.Slides for C++ segítségével."
---
## **Áttekintés**

A képkeret egy diára helyezett alakzat, amely képet jelenít meg. Az Aspose.Slides‑ben a kép erőforrás és a megjelenítő alakzat külön objektumok: a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) beágyazott képernyüröket tárol a [képgyűjtemény](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_images/) segítségével, míg egy [IPictureFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipictureframe/) szabályozza a kép pozícióját, méretét, vonalformázását, forgatását, vágását, képhatásait és egyéb keretszintű beállításait.

Ez a szétválasztás akkor hasznos, ha ugyanaz a kép többször jelenik meg. A képet egyszer adjuk hozzá a prezentációhoz, tartsuk meg a visszaadott [IPPImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ippimage/) objektumot, és használjuk ezt a kép erőforrást a képkeretek létrehozásakor.

A képkeretek raszteres képeket (például PNG vagy JPEG) és vektorgrafikus SVG képeket is tartalmazhatnak. Emellett hivatkozhatnak összekapcsolt képekre is a kép bájtjainak prezentációba ágyazása helyett. A választás hat a hordozhatóságra, fájlméretre, kinyerésre és exportálásra, ezért célszerű eldönteni, hogyan kell a képet tárolni a formázás vagy optimalizálás alkalmazása előtt.

## **Beágyazott kép hozzáadása és formázása**

Beágyazott kép esetén adjuk hozzá a képadatokat a prezentációhoz, és hozzunk létre egy képkeretet az [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shapecollection/addpictureframe/) metódussal. A kép a prezentáció csomag része lesz, így a prezentáció önálló marad, amikor egy másik számítógépre kerül.

Az alábbi példa JPEG képet ad hozzá, a kép natív méreteire hoz létre egy keretet, és vonalformázást valamint forgatást alkalmaz:

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

A képkeret szabályozza a megjelenített geometriát; a keret méretének módosítása nem változtatja meg az eredeti, a beágyazott kép erőforrásban tárolt pixelméreteket. Ez a különbség későbbi vágás vagy tömörítés során fontos lehet.

## **Relatív méretezés használata**

[IPictureFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipictureframe/) lehetővé teszi a keret relatív szélesség‑ és magasság‑méretezését. Az `1.0` érték az eredeti kép 100 %-ának felel meg. A relatív méretezés akkor hasznos, ha egy munkafolyamatnak meg kell őriznie a kapcsolatot a forráskép méretével, a végleges méretek kézi számítása nélkül.

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

A relatív méretezés módosítja a keret méretbeállításait; nem mintavételezi vagy tömöríti a beágyazott képet.

## **Beágyazott és összekapcsolt képek**

A beágyazott kép a képadatokat a prezentáción belül tárolja, ezért a hordozhatóság és a kiszámítható megjelenítés szempontjából a legbiztonságosabb választás. Egy összekapcsolt kép a [ISlidesPicture](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidespicture/) hivatkozási útvonalán keresztül tárol egy külső helyet, a képadatokat nem ágyazza be ugyanígy.

Az összekapcsolt képek csökkenthetik a PPTX‑ben tárolt képadatok mennyiségét, de külső függőséget vezetnek be. A hivatkozott fájlnak elérhetőnek kell maradnia a prezentációt megnyitó vagy renderelő alkalmazás számára. Ha az útvonal megváltozik, a fájl átkerül, vagy az erőforrás nem érhető el, az összekapcsolt kép nem jelenik meg a várt módon. Azoknál a prezentációknál, amelyeket e‑mailben, archívumban vagy elszigetelt környezetben kell megjeleníteni, a beágyazott képek általában megbízhatóbbak.

### **Összekapcsolt kép hozzáadása**

Az alábbi példa egy képkeretet hoz létre, és egy helyi képfájlra mutat. Csak a kép összekapcsolásával foglalkozik; a videó összekapcsolása egy külön média‑munkafolyamat, és szándékosan nincs belekeverve ebbe a példába.

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

Használjunk összekapcsolásokat, ha a külső fájlkezelés szándékos. Ne használjuk őket csak a tömörítés helyettesítésére: egy kis PPTX, amelyben a képfüggőségek töröttek, általában kevésbé hasznos, mint egy nagyobb, önálló prezentáció.

## **Képek kinyerése képkeretekből**

Mielőtt képet nyernénk ki egy meglévő prezentációból, ellenőrizzük, hogy az alakzat valóban egy [IPictureFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipictureframe/), és tartalmaz-e beágyazott képet. Az összekapcsolt képkeretek nem feltétlenül tartalmaznak olyan kép‑bájtokat, amelyeket ugyanúgy ki lehetne nyerni.

### **Raszteres kép kinyerése**

A modern kép‑API közvetlenül a [IImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iimage/) használatával működik. Az alábbi példa megtalálja az első beágyazott raszteres képet a dián, és PNG‑ként menti el:

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

A [IImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iimage/) használatával a kinyert képet a kért kimeneti formátumra konvertáljuk. Ha a prezentációban tárolt kódolt bájtokra van szükség, a konvertált raszteres fájl helyett a kép erőforrás bináris adatait kell felhasználni.

### **SVG kép kinyerése**

SVG kép esetén a [IPPImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ippimage/) egy [ISvgImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isvgimage/) objektumot biztosít. Ennek segítségével közvetlenül lekérhető az SVG adat anélkül, hogy előbb rasterizálnánk a képet.

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

Az SVG tartalom SVG‑ként való megtartása megőrzi a vektoros forrást a prezentáción belül. A PNG vagy JPEG‑hez hasonló raszteres exportok kötelezően a vektoros tartalmat pixelekre konvertálják. A PDF vagy SVG diakivitel szintén egy renderelési művelet, ezért a exportált grafika nem tekinthető az eredeti beágyazott SVG‑nek bit‑pontos másolatának; használjuk a beágyazott [ISvgImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isvgimage/) adatot, ha a vektoros erőforrásra van szükség.

## **Kép vágása**

A vágás megváltoztatja, hogy a kép mely része látható a kereten belül. A [IPictureFillFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipicturefillformat/) vágási értékei a forráskép méreteinek százalékában vannak megadva. A vágás kezdetben nem törli a rejtett pixeleket a beágyazott képből; csak a látható területet módosítja.

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

Mivel a rejtett képadat továbbra is jelen van, a vágás később megváltoztatható az eredeti pixelek elvesztése nélkül. Ha a fájlméret fontosabb a visszavonhatóságnál, a vágott területeket a következő szakaszban leírtnak megfelelően fizikailag eltávolíthatjuk.

## **Vágott képadatok eltávolítása**

[IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) eltávolítja a képadatokat a jelenlegi vágási téglalapon kívül, és visszaadja a keletkezett kép erőforrást. Ez csökkentheti a fájlméretet, de destruktív optimalizáció: a prezentáció mentése után a eltávolított pixelek már nem állnak rendelkezésre egy későbbi „un‑crop” művelethez.

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

A metódus új kép erőforrást adhat a prezentációhoz. Ha az eredeti képet más képkeretek is használják, azoknak továbbra is a meglévő erőforrásra van szükségük, így a vágott területek törlése nem feltétlenül csökkenti a képek összes számát. WMF vagy EMF tartalom vágása ezzel a módszerrel a vágott eredményt PNG‑be rasterizálja.

## **Raszteres képek tömörítése**

[IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipicturefillformat/compressimage/) csökkenti a raszteres kép felbontását a megjelenítési mérethez képest. Ugyanebben a műveletben eltávolíthatók a vágott területek is. A metódus `true`‑t ad vissza, ha a képet átméretezték vagy levágták, és `false`‑t, ha nem volt szükség változtatásra.

Használjunk előre definiált [PicturesCompression](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/picturescompression/) értéket, ha egy szabványos célfelbontás elegendő:

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

Egy egyéni, pozitív DPI érték is megadható enum érték helyett, ha egy konkrét cél szükséges.

A tömörítés raszteres képekre szánt. SVG és metafájl tartalom nem csökken ezen raszteres tömörítési munkafolyamat során. Emellett ne feledjük, hogy a kisebb felbontás és a törölt vágott területek nem állíthatók helyre az optimalizált prezentációból. Válasszunk célfelbontást a legnagyobb megjelenítési vagy exportálási méret alapján, nem pedig a legalacsonyabb DPI‑t globálisan alkalmazva.

## **Kép‑transzformációs hatások kezelése**

A fényerő, kontraszt, színátalakítások, elmosás, alfa‑hatások, sorozatos láncok, ellenőrzés, eltávolítás és körkörös ellenőrzés teljes munkafolyamatához lásd a [Image Transform Effects](/slides/hu/cpp/image-transform-effects/) oldalt.

## **Képkeret geometria zárolása**

Az [IPictureFrameLock](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipictureframelock/) beállítások szabályozzák, hogy mely szerkesztési műveletek legyenek letiltva egy képkeretnél. Például a [aspect‑ratio lock](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) megtartja az alakzat arányait átméretezés közben.

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

A zár a képkeret alakzatra vonatkozik. Nem kényszeríti a forrásképet, hogy újramintavételezve vagy véglegesen ugyanazzal az oldalaránnyal rendelkezzen.

## **StretchOffset értékek módosítása**

Ha a kép kitöltési mód a nyújtás, akkor az [IPictureFillFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipicturefillformat/) stretch‑offset értékei a kitöltés téglalapját határozzák meg a képkeret határoló dobozához képest. A pozitív százalékok a szél felől belső eltolást hoznak létre, míg a negatív százalékok a külső eltolást.

Ez eltér a vágástól. A vágási értékek azt határozzák meg, hogy a forráskép mely része látható; a stretch‑offsetok a látható képkitöltés téglalapját módosítják.

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

Használjuk a stretch‑offsetokat a kitöltés elhelyezéséhez. A vágási tulajdonságokat akkor alkalmazzuk, ha a cél a forráskép széleinek elrejtése.

## **Tárolás, fájlméret és exportálási megfontolások**

A fő kompromisszumok könnyebben kezelhetők, ha a képtárolást és a képkeret‑formázást külön kezeljük:

- **Beágyazott képek** önállóvá teszik a prezentációt, és a megosztás valamint a szerver‑oldali renderelés során a legmegbízhatóbbak, de a nagy raszteres képek növelik a PPTX méretét és memóriaigényét.
- **Összekapcsolt képek** kisebb csomagméretet biztosíthatnak, de a prezentáció függ a külső fájlok elérhetőségétől a tárolt útvonalakon vagy helyeken.
- **Vágás** kezdetben nem destruktív. A rejtett pixelek a vágott területek explicite törléséig vagy tömörítés során maradnak beágyazva.
- **Tömörítés** jelentősen csökkentheti a fájlméretet a túlméretezett raszteres képeknél, de a forrásfelbontást feláldozza. A várt dián‑méret ismerete után kell alkalmazni.
- **SVG képek** esetén maradjanak SVG‑ként, ha a vektor megőrzése fontos. A beágyazott SVG közvetlen kinyerése szükség esetén a vektor‑erőforrást adja. A raszteres diakivitelek mindig pixelekre konvertálják a renderelt diát.
- **Ismétlődő képek** esetén használjunk már létező [IPPImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ippimage/) erőforrást, ahelyett, hogy ugyanazt a fájlt többször betöltenénk a munkafolyamatba.

Nagy prezentációknál a képoptimalizálás általában akkor a leghatékonyabb, ha szelektíven történik: a logókat és diagramokat vektoros tartalomként tartsuk, a fényképeket a valós megjelenítési méret szerint tömörítsük, a vágott pixeleket csak akkor távolítsuk el, ha későbbi szerkesztés nem szükséges, és kerüljük a külső hivatkozásokat, hacsak a függőség‑kezelés nem része a kiépítési tervezésnek.

## **GYIK**

**Mi a különbség egy képkeret és egy kép erőforrás között?**

Az [IPPImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ippimage/) egy a prezentációhoz társított kép erőforrást képviseli. Az [IPictureFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipictureframe/) egy dián elhelyezett alakzat, amely képet jelenít meg, és tárolja a keretszintű geometriát és formázást, például méretet, forgatást, vágási értékeket, hatásokat és zárolásokat.

**Beágyazzam vagy összekapcsoljam a képeket?**

Beágyazzuk a képeket, ha a prezentációnak hordozhatónak, archiváltnak vagy külső erőforrások nélkül renderelhetőnek kell lennie. Összekapcsoljuk a képeket csak akkor, ha szándékosan szeretnénk a képfájlokat a PPTX‑en kívül tartani, és a külső helyek megbízhatóan karbantarthatók.

**Csökkenti-e a vágás a PPTX fájlméretét?**

Nem önmagában. A normál vágási beállítások elrejtik a forráskép részeit, de a pixeleket megtartják. Használjuk a [IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) vagy a képtömörítést vágott‑terület‑eltávolítással, ha ezek a pixelek véglegesen eldobhatók.

**Visszaállítható a képminőség a tömörítés után?**

Nem. A tömörítés csökkentheti a tárolt raszteres felbontást, és a vágott területek eltávolítása törli a képadatot. Tartsa meg az eredeti forrásképet a prezentáción kívül, ha később magas felbontású szerkesztésre lehet szükség.

**Hogyan kell kezelni az SVG képeket?**

Tartsa meg az SVG tartalmat SVG‑ként, ha a vektoros pontosság fontos. A beágyazott [ISvgImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isvgimage/) közvetlenül kinyerhető. A diát PNG vagy JPEG formátumba exportálni rasterizálja az SVG‑t a diakép részeként.

**Hogyan kerülhető el a veszélyes cast használata meglévő diák olvasásakor?**

Ellenőrizzük az alakzat típusát, mielőtt képkeret‑specifikus tagokat használunk. Teszteljük az alakzatot [IPictureFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipictureframe/)‑vel, mielőtt futásidejű castet végeznénk, és a cast eredményét helyi változóba rendeljük a képkeret‑specifikus tagok elérése előtt.