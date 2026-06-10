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
- kép hozzáadása
- kép létrehozása
- kép kinyerése
- raszteres kép
- vektorkép
- kép levágása
- vágott terület
- StretchOff tulajdonság
- képkeret formázása
- képkeret tulajdonságai
- relatív méretezés
- kép effektus
- méretarány
- kép átlátszóság
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Képkeretek hozzáadása PowerPoint és OpenDocument prezentációkhoz az Aspose.Slides for C++ segítségével. Egyszerűsítse a munkafolyamatot és javítsa a diaterveket."
---
## **Bevezetés**

A képkeret egy olyan alakzat, amely egy képet tartalmaz—olyan, mint egy kép a keretben.

Képet egy diára egy képkereten keresztül adhat hozzá. Így a képet a képkeret formázásával formázhatja.

{{% alert title="Tipp" color="primary" %}} 
Az Aspose ingyenes átalakítókat biztosít — [JPEG to PowerPoint](https://products.aspose.app/slides/hu/import/jpg-to-ppt) és [PNG to PowerPoint](https://products.aspose.app/slides/hu/import/png-to-ppt) — amelyek lehetővé teszik a felhasználók számára, hogy gyorsan prezentációkat hozzanak létre képekből. 
{{% /alert %}} 

## **Képkeret létrehozása**

1. Hozzon létre egy példányt a [Presentation class](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.  
2. Szerezzen be egy diára mutató referenciát az indexe alapján.  
3. Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_p_p_image) objektumot úgy, hogy képet ad hozzá a prezentáció objektumhoz kapcsolódó [IImagescollection](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_image_collection) gyűjteményhez, amelyet az alakzat kitöltéséhez használnak.  
4. Adja meg a kép szélességét és magasságát.  
5. Hozzon létre egy [PictureFrame](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.picture_frame) objektumot a kép szélessége és magassága alapján a `AddPictureFrame` metódussal, amely a hivatkozott diához tartozó alakzatobjektumon keresztül érhető el.  
6. Adjon egy képkeretet (a képet tartalmazó) a diához.  
7. Mentse a módosított prezentációt PPTX fájlként.  

Ez a C++ kód bemutatja, hogyan hozhat létre képkeretet:

```c++
// A dokumentumok könyvtárának útvonala.
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// A kívánt prezentáció betöltése
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Első dia elérése
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Betölti a képet, amely a prezentáció képgyűjteményéhez lesz hozzáadva
// Lekéri a képet
auto image = Images::FromFile(filePath);

// Képet ad a prezentáció képgyűjteményéhez
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Képkeretet ad a diára
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Relatív méretezés szélességét és magasságát állítja be
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// Formázás alkalmazása a képkeretre
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

// PPTX fájl mentése lemezre
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="warning" %}} 
A képkeretek lehetővé teszik, hogy gyorsan prezentációs diák készüljenek képek alapján. Ha a képkeretet kombinálja az Aspose.Slides mentési beállításaival, kezelheti a bemeneti/kimeneti műveleteket a képek egyik formátumból a másikba történő átalakításához. Érdemes lehet megnézni ezeket az oldalakat: convert [kép JPG-re](https://products.aspose.com/slides/hu/cpp/conversion/image-to-jpg/); convert [JPG képre](https://products.aspose.com/slides/hu/cpp/conversion/jpg-to-image/); convert [JPG PNG-re](https://products.aspose.com/slides/hu/cpp/conversion/jpg-to-png/), convert [PNG JPG-re](https://products.aspose.com/slides/hu/cpp/conversion/png-to-jpg/); convert [PNG SVG-re](https://products.aspose.com/slides/hu/cpp/conversion/png-to-svg/), convert [SVG PNG-re](https://products.aspose.com/slides/hu/cpp/conversion/svg-to-png/). 
{{% /alert %}}

## **Képkeret létrehozása relatív méretezéssel**

A kép relatív méretezésének módosításával összetettebb képkeretet hozhat létre. 

1. Hozzon létre egy példányt a [Presentation class](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.  
2. Szerezzen be egy diára mutató referenciát az indexe alapján.  
3. Adjon egy képet a prezentáció képgyűjteményéhez.  
4. Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_p_p_image) objektumot úgy, hogy képet ad hozzá a prezentáció objektumhoz kapcsolódó [IImagescollection](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_image_collection) gyűjteményhez, amelyet az alakzat kitöltéséhez használnak.  
5. Adja meg a kép relatív szélességét és magasságát a képkeretben.  
6. Mentse a módosított prezentációt PPTX fájlként.  

Ez a C++ kód bemutatja, hogyan hozhat létre képkeretet relatív méretezéssel:

```c++
// A dokumentumok könyvtárának útvonala.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// A kívánt prezentáció betöltése
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Az első dia elérése
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Betölti a képet, amely a prezentáció képgyűjteményéhez lesz hozzáadva
// Lekéri a képet
auto image = Images::FromFile(filePath);

// Képet ad a prezentáció képgyűjteményéhez
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Képkeretet ad a diára
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Relatív méretezés szélességét és magasságát állítja be
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

//PPTX fájlt ment a lemezre
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Rasterképek kinyerése képkeretekből**

Rasterképeket nyerhet ki a [PictureFrame](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.picture_frame) objektumokból, és PNG, JPG vagy más formátumokban mentheti el. Az alábbi kódrészlet bemutatja, hogyan nyerhet ki egy képet a "sample.pptx" dokumentumból, és mentheti PNG formátumban.

```c++
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstSlide = presentation->get_Slide(0);
auto firstShape = firstSlide->get_Shape(0);
    
if (ObjectExt::Is<IPictureFrame>(firstShape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(firstShape);
    auto image = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_SystemImage();

    image->Save(u"slide_1_shape_1.png", ImageFormat::get_Png());
}

presentation->Dispose();
```

## **SVG képek kinyerése képkeretekből**

Amikor egy prezentáció SVG grafikákat tartalmaz, melyek [PictureFrame] alakzatokba vannak helyezve, az Aspose.Slides for C++ lehetővé teszi az eredeti vektorképek teljes pontosságú lekérdezését. A dia alakzatgyűjteményének bejárásával azonosíthatja az egyes [PictureFrame] objektumokat, ellenőrizheti, hogy a kapcsolódó [IPPImage] SVG tartalmat tartalmaz-e, majd elmentheti azt a lemezre vagy egy adatfolyamra a natív SVG formátumban.

A következő kódrészlet bemutatja, hogyan nyerhet ki egy SVG képet egy képkeretből:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(shape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto svgImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_SvgImage();
    if (svgImage != nullptr)
    {
        File::WriteAllText(u"output.svg", svgImage->get_SvgContent());
    }
}

presentation->Dispose();
```

## **Kép átlátszóságának lekérdezése**

Az Aspose.Slides lehetővé teszi, hogy lekérdezze a képre alkalmazott átlátszósági effektet. Ez a C++ kód bemutatja a műveletet:

```c++
auto presentation = System::MakeObject<Presentation>(u"Test.pptx");
auto pictureFrame = System::ExplicitCast<IPictureFrame>(presentation->get_Slide(0)->get_Shape(0));
auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
for (auto&& effect : imageTransform)
{
    if (System::ObjectExt::Is<IAlphaModulateFixed>(effect))
    {
        float transparencyValue = 100.0f - (System::ExplicitCast<IAlphaModulateFixed>(effect))->get_Amount();
        System::Console::WriteLine(System::String(u"Picture transparency: ") + transparencyValue);
    }
}
```

{{% alert color="primary" %}} 
Az összes képre alkalmazott effektus megtalálható a [Aspose::Slides::Effects](https://reference.aspose.com/slides/hu/cpp/aspose.slides.effects/) oldalon. 
{{% /alert %}}

## **Képkeret formázása**

Az Aspose.Slides számos formázási lehetőséget kínál, amelyeket egy képkeretre lehet alkalmazni. Ezekkel a beállításokkal módosíthatja a képkeretet, hogy megfeleljen a specifikus követelményeknek.

1. Hozzon létre egy példányt a [Presentation class](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.  
2. Szerezzen be egy diára mutató referenciát az indexe alapján.  
3. Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_p_p_image) objektumot úgy, hogy képet ad hozzá a prezentáció objektumhoz kapcsolódó [IImagescollection](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_image_collection) gyűjteményhez, amelyet az alakzat kitöltéséhez használnak.  
4. Adja meg a kép szélességét és magasságát.  
5. Hozzon létre egy `PictureFrame`-et a kép szélessége és magassága alapján a [AddPictureFrame](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) metódussal, amely a hivatkozott diához tartozó [IShapes](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_shape_collection) objektumon keresztül érhető el.  
6. Adja hozzá a képkeretet (a képet tartalmazó) a diához.  
7. Állítsa be a képkeret vonalszínét.  
8. Állítsa be a képkeret vonalszélességét.  
9. Forgassa el a képkeretet pozitív vagy negatív érték megadásával.  
   * A pozitív érték az képet óramutató járásával megegyező irányban forgatja.  
   * A negatív érték az képet óramutató járásával ellentétes irányban forgatja.  
10. Adja hozzá a képkeretet (a képet tartalmazó) a diához.  
11. Mentse a módosított prezentációt PPTX fájlként.  

Ez a C++ kód bemutatja a képkeret formázási folyamatát:

```c++
// A dokumentumok könyvtárának útvonala.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// A kívánt prezentáció betöltése
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Az első dia elérése
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Betölti a képet, amely a prezentáció képgyűjteményéhez lesz hozzáadva
// Lekéri a képet
auto image = Images::FromFile(filePath);

// Képet ad a prezentáció képgyűjteményéhez
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Képkeretet ad a diára
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Relatív méretezés szélességét és magasságát állítja be
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// PPTX fájlt ment a lemezre
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert title="Tipp" color="primary" %}} 
Az Aspose nemrég fejlesztett egy [Ingyenes Kollázskészítő](https://products.aspose.app/slides/hu/collage) szolgáltatást. Ha JPG/JPEG vagy PNG képeket szeretne egyesíteni, vagy fotókból rácsokat létrehozni, használhatja ezt a szolgáltatást. 
{{% /alert %}}

## **Kép hozzáadása linkként**

Az nagy méretű prezentációk elkerülése érdekében képeket (vagy videókat) linkeken keresztül adhat hozzá ahelyett, hogy a fájlokat közvetlenül a prezentációba ágyazzák. Ez a C++ kód bemutatja, hogyan adhat képet és videót egy helyőrzőbe:

```cpp
auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto shapesToRemove = System::MakeObject<System::Collections::Generic::List<System::SharedPtr<IShape>>>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

for (auto& autoShape : shapes)
{
    if (autoShape->get_Placeholder() == nullptr)
        continue;

    switch (autoShape->get_Placeholder()->get_Type())
    {
        case Aspose::Slides::PlaceholderType::Picture:
        {
            auto pictureFrame = shapes->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, autoShape->get_X(), autoShape->get_Y(), autoShape->get_Width(), autoShape->get_Height(), nullptr);
            pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
            shapesToRemove->Add(autoShape);
            break;
        }

        case Aspose::Slides::PlaceholderType::Media:
        {
            auto videoFrame = shapes->AddVideoFrame(autoShape->get_X(), autoShape->get_Y(), autoShape->get_Width(), autoShape->get_Height(), u"");
            videoFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
            videoFrame->set_LinkPathLong(u"https://youtu.be/t_1LYZ102RA");
            shapesToRemove->Add(autoShape);
            break;
        }
    }
}

for (auto& shape : shapesToRemove)
{
    shapes->Remove(shape);
}

presentation->Save(u"output.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Képek levágása**

Ez a C++ kód bemutatja, hogyan vághat le egy meglévő képet egy dián: 

```CPP
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;
    
auto presentation = System::MakeObject<Presentation>();
// Új képobjektum létrehozása
auto newImage = presentation->get_Images()->AddImage(Images::FromFile(imagePath));

// Képkeret hozzáadása egy diához
auto picFrame = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 100.0f, 100.0f, 420.0f, 250.0f, newImage);

// A kép levágása (százalékos értékek)
picFrame->get_PictureFormat()->set_CropLeft(23.6f);
picFrame->get_PictureFormat()->set_CropRight(21.5f);
picFrame->get_PictureFormat()->set_CropTop(3.0f);
picFrame->get_PictureFormat()->set_CropBottom(31.0f);

// Az eredmény mentése
presentation->Save(outPptxFile, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Kép vágott részeinek törlése**

Ha törölni szeretné egy keretben lévő kép vágott részeit, használhatja az [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) metódust. Ez a metódus visszaadja a levágott képet, vagy az eredeti képet, ha a vágás nem szükséges.

Ez a C++ kód bemutatja a műveletet: 

```c++
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"PictureFrameCrop.pptx");
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Gets the PictureFrame from the first slide
System::SharedPtr<IPictureFrame> picFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Deletes cropped areas of the PictureFrame image and returns the cropped image
System::SharedPtr<IPPImage> croppedImage = picFrame->get_PictureFormat()->DeletePictureCroppedAreas();

// Saves the result
presentation->Save(u"PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
```

{{% alert title="MEGJEGYZÉS" color="warning" %}} 
[IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) metódus hozzáadja a vágott képet a prezentáció képgyűjteményéhez. Ha a kép csak a feldolgozott [PictureFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/pictureframe/) objektumban van használva, ez a beállítás csökkentheti a prezentáció méretét. Ellenkező esetben a létrehozott prezentációban lévő képek száma növekedni fog.  

Ez a metódus a vágási művelet során WMF/EMF metafájlokat raster PNG képpé konvertál. 
{{% /alert %}}

## **Képek tömörítése**

A prezentációban lévő képet az [IPictureFillFormat::CompressImage()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipicturefillformat/compressimage/) metódus használatával tömörítheti.  

Ez a metódus a kép méretét a alakzat mérete és a megadott felbontás alapján csökkentve tömöríti a képet, a vágott területek törlésének lehetőségével.  

A kép méretét és felbontását a PowerPoint **Picture Format -> Compress Pictures -> Resolution** funkciójához hasonlóan állítja be.  

Az alábbi C++ példák bemutatják, hogyan lehet egy képet tömöríteni a prezentációban egy célfelbontás megadásával, és opcionálisan a vágott területek eltávolításával:

```c++
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Compress the image with a target resolution of 150 DPI (Web resolution) and remove cropped areas.
bool result = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);

// Check the result of the compression.
if (result)
{
    System::Console::WriteLine(u"Image successfully compressed.");
}
else
{
    System::Console::WriteLine(u"Image compression failed or no changes were necessary.");
}

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Vagy közvetlenül egy egyedi DPI érték használatával:

```c++
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// A kép tömörítése 150 DPI-re (web felbontás), a levágott területek eltávolításával.
pictureFrame->get_PictureFormat()->CompressImage(true, 150.0f);

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="MEGJEGYZÉS" color="warning" %}} 
A metódus az alakzat mérete és a megadott DPI alapján alacsonyabb felbontásra konvertálja a képet. A vágott területek törlése is elvégezhető a fájlméret optimalizálása érdekében.  
Ha a kép metafájl (WMF/EMF) vagy SVG, a tömörítés nem lesz alkalmazva. Ezenkívül a JPEG minőség megmarad vagy enyhén csökken a felbontástól függően, hasonlóan ahhoz, ahogy a PowerPoint kezeli a nagy felbontású JPEG-eket. 
{{% /alert %}}

## **Arány zárolása**

Ha azt szeretné, hogy egy képet tartalmazó alakzat megtartsa az arányát még a kép méretének megváltoztatása után is, használhatja a [set_AspectRatioLocked()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) metódust az *Arány zárolása* beállítás beállításához.  

Ez a C++ kód bemutatja, hogyan zárolhatja egy alakzat arányát:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ILayoutSlide> layout = pres->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
System::SharedPtr<ISlide> emptySlide = pres->get_Slides()->AddEmptySlide(layout);

System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
System::SharedPtr<IPPImage> presImage = pres->get_Images()->AddImage(image);

System::SharedPtr<IPictureFrame> pictureFrame = emptySlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 150.0f, static_cast<float>(presImage->get_Width()), static_cast<float>(presImage->get_Height()), presImage);

// Állítsa be, hogy az alakzat a méretezéskor megőrizze az arányt
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);
```

{{% alert title="MEGJEGYZÉS" color="warning" %}} 
Ez az *Arány zárolása* beállítás csak az alakzat arányát őrzi meg, nem a benne lévő képet. 
{{% /alert %}}

## **A StretchOff tulajdonság használata**

A [StretchOffsetLeft](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471), [StretchOffsetTop](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a), [StretchOffsetRight](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) és [StretchOffsetBottom](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) tulajdonságok használatával a [IPictureFillFormat](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_picture_fill_format) interfészből és a [PictureFillFormat](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.picture_fill_format) osztályból megadhat egy kitöltési téglalapot.  

Ha egy kép nyújtását adjuk meg, egy forrás téglalap a megadott kitöltési téglalaphoz lesz skálázva. A kitöltési téglalap minden éle egy százalékos eltolással van definiálva az alakzat határoló dobozának megfelelő élétől. A pozitív százalék egy belső eltolást jelöl. A negatív százalék egy külső eltolást jelöl.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.  
2. Szerezzen be egy diára mutató referenciát az indexe alapján.  
3. Adjon hozzá egy `AutoShape` téglalapot.  
4. Hozzon létre egy képet.  
5. Állítsa be az alakzat kitöltésének típusát.  
6. Állítsa be az alakzat képkitöltési módját.  
7. Adjon hozzá egy beállított képet az alakzat kitöltéséhez.  
8. Adja meg a kép eltolásait a alakzat határoló dobozának megfelelő élétől  
9. Mentse a módosított prezentációt PPTX fájlként.  

Ez a C++ kód bemutatja, hogyan használható a StretchOff tulajdonság:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto ppImage = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
auto slide = pres->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 400.0f, 400.0f, ppImage);

// Beállítja a képet, hogy minden oldalról nyújtva legyen az alakzat testében
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_PictureFillMode(PictureFillMode::Stretch);
pictureFormat->set_StretchOffsetLeft(24.0f);
pictureFormat->set_StretchOffsetRight(24.0f);
pictureFormat->set_StretchOffsetTop(24.0f);
pictureFormat->set_StretchOffsetBottom(24.0f);

pres->Save(u"imageStretch.pptx", SaveFormat::Pptx);
```

## **GYIK**

**Hogyan deríthetem ki, hogy mely képformátumok támogatottak a PictureFrame számára?**

Aspose.Slides támogatja mind a raszteres képeket (PNG, JPEG, BMP, GIF stb.), mind a vektorképeket (például SVG) a [PictureFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/pictureframe/) objektumhoz rendelt képtárgyon keresztül. A támogatott formátumok listája általában átfedi a dia- és képátalakító motor képességeit.

**Hogyan befolyásolja a PPTX méretét és a teljesítményt több tucat nagy kép hozzáadása?**

A nagy képek beágyazása növeli a fájlméretet és a memóriahasználatot; a képek linkeléssel segíthet kisebb méretű prezentációt tartani, de a külső fájloknak elérhetőnek kell maradniuk. Az Aspose.Slides lehetőséget biztosít a képek linkként való hozzáadására a fájlméret csökkentése érdekében.

**Hogyan zárolhatom a képobjektumot a véletlen mozgatás/átméretezés ellen?**

Használja a [shape locks] (alakzat-zárolások) funkciót egy [PictureFrame] esetén (például a mozgatás vagy átméretezés letiltása). A zárolási mechanizmus a formákra vonatkozó külön [protection article](/slides/hu/cpp/applying-protection-to-presentation/) részben van leírva, és különböző alakzat típusoknál támogatott, beleértve a [PictureFrame]‑t is.

**Megmarad-e az SVG vektor pontossága, amikor a prezentációt PDF/ képek formátumba exportáljuk?**

Az Aspose.Slides lehetővé teszi az SVG kinyerését egy [PictureFrame]‑ből eredeti vektorként. Amikor [PDF‑re exportálás](/slides/hu/cpp/convert-powerpoint-to-pdf/) vagy [raszteres formátumok](/slides/hu/cpp/convert-powerpoint-to-png/) célra exportál, az eredmény a export beállításaitól függően rasterizálódhat; a kinyerési viselkedés megerősíti, hogy az eredeti SVG vektor formátumban van tárolva.