---
title: Képkockák kezelése prezentációkban C++ használatával
linktitle: Képkocka
type: docs
weight: 10
url: /hu/cpp/picture-frame/
keywords:
  - képkocka
  - képkocka hozzáadása
  - képkocka létrehozása
  - kép hozzáadása
  - kép létrehozása
  - kép kinyerése
  - raszter kép
  - vektor kép
  - kép vágása
  - levágott terület
  - StretchOff tulajdonság
  - képkocka formázása
  - képkocka tulajdonságai
  - relatív méretezés
  - kép hatás
  - oldalarány
  - kép átlátszóság
  - PowerPoint
  - OpenDocument
  - prezentáció
  - C++
  - Aspose.Slides
description: "Adjon képkockákat PowerPoint és OpenDocument prezentációkhoz az Aspose.Slides for C++ segítségével. Egyszerűsítse a munkafolyamatát és javítsa a diák megjelenését."
---
## **Bevezetés**

A képkocka egy olyan alakzat, amely tartalmaz egy képet – ez olyan, mint egy kép keretben.  

Képet egy diára egy képkocka segítségével adhat hozzá. Így a képet a képkocka formázásával formázhatja.  

{{% alert  title="Tip" color="info" %}} 

Az Aspose ingyenes konvertálókat biztosít – [JPEG to PowerPoint](https://products.aspose.app/slides/hu/import/jpg-to-ppt) és [PNG to PowerPoint](https://products.aspose.app/slides/hu/import/png-to-ppt) – amelyek lehetővé teszik, hogy gyorsan elkészítsenek bemutatókat képekből.  

{{% /alert %}} 

## **Képkocka létrehozása**

1. Hozzon létre egy példányt a [Presentation class](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexén keresztül.  
3. Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_p_p_image) objektumot egy kép hozzáadásával a prezentáció objektumhoz kapcsolódó [IImagescollection](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_image_collection) gyűjteményhez, amelyet az alakzat kitöltésére használ.  
4. Adja meg a kép szélességét és magasságát.  
5. Hozzon létre egy [PictureFrame](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.picture_frame) objektumot a kép szélessége és magassága alapján a `AddPictureFrame` metódus segítségével, amelyet a hivatkozott diahoz kapcsolódó alakzatobjektum biztosít.  
6. Adjon hozzá egy képkockát (amely a képet tartalmazza) a diához.  
7. Írja ki a módosított prezentációt PPTX fájlként.  

```c++
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
#include <Util/Images.h>
#include <drawing/color.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// A dokumentumok könyvtárának elérési útja.
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// A kívánt prezentáció betöltése
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Első dia elérése
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Betölti a képet, amelyet a prezentáció képgyűjteményéhez adunk hozzá
// Lekéri a képet
auto image = Images::FromFile(filePath);

// Képet ad a prezentáció képgyűjteményéhez
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Képkockát ad a diára
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Beállítja a relatív méretezés szélességét és magasságát
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// Formázást alkalmaz a képkockára
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

// A PPTX fájlt lemezre írja
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="warning" %}} 

A képkockák lehetővé teszik, hogy gyorsan készítsen bemutató diákat képek alapján. Ha a képkockát kombinálja az Aspose.Slides mentési beállításaival, kezelheti a be- és kimeneti műveleteket a képek formátumok közötti konvertálásához. Érdemes megnézni ezeket az oldalakat: konvertálás [image to JPG](https://products.aspose.com/slides/hu/cpp/conversion/image-to-jpg/); konvertálás [JPG to image](https://products.aspose.com/slides/hu/cpp/conversion/jpg-to-image/); konvertálás [JPG to PNG](https://products.aspose.com/slides/hu/cpp/conversion/jpg-to-png/), konvertálás [PNG to JPG](https://products.aspose.com/slides/hu/cpp/conversion/png-to-jpg/); konvertálás [PNG to SVG](https://products.aspose.com/slides/hu/cpp/conversion/png-to-svg/), konvertálás [SVG to PNG](https://products.aspose.com/slides/hu/cpp/conversion/svg-to-png/).  

{{% /alert %}}

## **Képkocka létrehozása relatív méretezéssel**

1. Hozzon létre egy példányt a [Presentation class](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexén keresztül.  
3. Adjon hozzá egy képet a prezentáció képgyűjteményéhez.  
4. Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_p_p_image) objektumot egy kép hozzáadásával a prezentáció objektumhoz kapcsolódó [IImagescollection](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_image_collection) gyűjteményhez, amelyet az alakzat kitöltésére használ.  
5. Adja meg a kép relatív szélességét és magasságát a képkockában.  
6. Írja ki a módosított prezentációt PPTX fájlként.  

```c++
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// A dokumentumok könyvtárának elérési útja.
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

// Képkockát ad a diára
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Beállítja a relatív méretezés szélességét és magasságát
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

//A PPTX fájlt lemezre írja
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Raster képek kinyerése képkockákból**

Raster képeket tud kinyerni a [PictureFrame](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.picture_frame) objektumokból, és PNG, JPG vagy más formátumokban menteni.  
Az alábbi kódrészlet bemutatja, hogyan nyerhet ki egy képet a "sample.pptx" dokumentumból, és mentheti PNG formátumban.  

```c++
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstSlide = presentation->get_Slide(0);
auto firstShape = firstSlide->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(firstShape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(firstShape);
    auto image = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_Image();

    image->Save(u"slide_1_shape_1.png", ImageFormat::Png);
}

presentation->Dispose();
```

## **SVG képek kinyerése képkockákból**

Amikor egy prezentáció SVG grafikákat tartalmaz, amelyek [PictureFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/pictureframe/) alakzatokban helyezkednek el, az Aspose.Slides for C++ lehetővé teszi az eredeti vektor képek teljes hűséggel történő lekérését. A dia alakzatgyűjteményének bejárásával azonosíthatja az egyes [PictureFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/pictureframe/) objektumokat, ellenőrizheti, hogy az alatta lévő [IPPImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ippimage/) SVG tartalmat tartalmaz-e, majd elmentheti a képet a lemezen vagy egy streamben natív SVG formátumban.  

A következő kódrészlet bemutatja, hogyan nyerhet ki egy SVG képet egy képkockából:  

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
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

## **Kép átlátszóságának lekérése**

Aspose.Slides lehetővé teszi a képre alkalmazott átlátszósági hatás lekérését. Az alábbi C++ kód bemutatja a műveletet:  

```c++
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;

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

{{% alert color="info" %}} 
Minden képre alkalmazott hatás megtalálható a [Aspose::Slides::Effects](https://reference.aspose.com/slides/hu/cpp/aspose.slides.effects/).  
{{% /alert %}}

## **Kép fényerő és kontraszt lekérése**

Aspose.Slides lehetővé teszi a képre alkalmazott fényerő és kontraszt hatás lekérését. A [ILuminance](https://reference.aspose.com/slides/hu/cpp/aspose.slides.effects/iluminance/) felület ezt a képnem átalakító hatást képviseli.  

Az alábbi C++ kód bemutatja, hogyan lehet lekérni a fényerő és kontraszt beállításokat egy képkockából:  

```c++
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ILuminance.h>
#include <DOM/Effects/ILuminanceEffectiveData.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shape(0);
auto pictureFrame = System::ExplicitCast<IPictureFrame>(shape);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
for (auto&& effect : imageTransform)
{
    if (System::ObjectExt::Is<ILuminance>(effect))
    {
        auto luminance = System::ExplicitCast<ILuminance>(effect)->GetEffective();
        auto brightness = luminance->get_Brightness();
        auto contrast = luminance->get_Contrast();

        Console::WriteLine(System::String(u"Brightness: ") + brightness);
        Console::WriteLine(System::String(u"Contrast: ") + contrast);
    }
}

presentation->Dispose();
```

## **Képkocka formázása**

Aspose.Slides számos formázási lehetőséget biztosít, amelyeket egy képkockára lehet alkalmazni. Ezekkel az opciókkal módosíthatja a képkockát, hogy megfeleljen a konkrét követelményeknek.  

1. Hozzon létre egy példányt a [Presentation class](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexén keresztül.  
3. Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_p_p_image) objektumot egy kép hozzáadásával a prezentáció objektumhoz kapcsolódó [IImagescollection](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_image_collection) gyűjteményhez, amelyet az alakzat kitöltésére használ.  
4. Adja meg a kép szélességét és magasságát.  
5. Hozzon létre egy `PictureFrame` objektumot a kép szélessége és magassága alapján a [AddPictureFrame](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) metódus segítségével, amelyet a hivatkozott diához tartozó [IShapes](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_shape_collection) objektum biztosít.  
6. Adja hozzá a képkockát (amely a képet tartalmazza) a diához.  
7. Állítsa be a képkocka vonalszínét.  
8. Állítsa be a képkocka vonalszélességét.  
9. Forgassa a képkockát pozitív vagy negatív érték megadásával.  
   * A pozitív érték az alakzatot az óramutató járásával megegyező irányba forgat.  
   * A negatív érték az alakzatot az óramutató járásával ellentétes irányba forgat.  
10. Adja hozzá a képkockát (amely a képet tartalmazza) a diához.  
11. Írja ki a módosított prezentációt PPTX fájlként.  

```c++
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// A dokumentumok könyvtárának elérési útja.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// A kívánt prezentáció betöltése
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Első dia elérése
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Betölti a képet, amelyet a prezentáció képgyűjmentéhez adunk hozzá
// Lekéri a képet
auto image = Images::FromFile(filePath);

// Képet ad a prezentáció képgyűjteményéhez
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Képkockát ad a diára
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Beállítja a relatív méretezés szélességét és magasságát
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// A PPTX fájlt lemezre írja
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert title="Tip" color="info" %}}

Az Aspose nemrég fejlesztett egy [ingyenes Collage Maker](https://products.aspose.app/slides/hu/collage). Ha valaha is össze kell fűznie JPG/JPEG vagy PNG képeket, vagy [rácsokat kell készítenie fényképekből](https://products.aspose.app/slides/hu/collage/photo-grid), használhatja ezt a szolgáltatást.  

{{% /alert %}}

## **Kép hozzáadása hivatkozásként**

Az nagy prezentációs méretek elkerülése érdekében képeket (vagy videókat) hivatkozásokon keresztül adhat hozzá ahelyett, hogy a fájlokat közvetlenül beágyazná a prezentációba. Az alábbi C++ kód bemutatja, hogyan adjon képet és videót egy helyőrzőhöz:  

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/IVideoFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/collections/list.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

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

## **Képek vágása**

Az alábbi C++ kód bemutatja, hogyan vágjon le egy már meglévő képet egy dián:  

``` CPP
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
// Új képobjektum létrehozása
auto newImage = presentation->get_Images()->AddImage(Images::FromFile(u"image.png"));

// Képkocka hozzáadása egy diára
auto picFrame = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 100.0f, 100.0f, 420.0f, 250.0f, newImage);

// A kép levágása (százalékos értékek)
picFrame->get_PictureFormat()->set_CropLeft(23.6f);
picFrame->get_PictureFormat()->set_CropRight(21.5f);
picFrame->get_PictureFormat()->set_CropTop(3.0f);
picFrame->get_PictureFormat()->set_CropBottom(31.0f);

// Az eredmény mentése
presentation->Save(u"cropped.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Képkocka levágott területeinek törlése**

Ha törölni szeretné egy keretben lévő kép levágott területeit, használhatja a [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) metódust. Ez a metódus a levágott képet vagy az eredeti képet adja vissza, ha a vágás nem szükséges.  

Az alábbi C++ kód demonstrálja a műveletet:  

```c++
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"PictureFrameCrop.pptx");
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Lekéri a PictureFrame-et az első diáról
System::SharedPtr<IPictureFrame> picFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Törli a PictureFrame kép levágott területeit és visszaadja a levágott képet
System::SharedPtr<IPPImage> croppedImage = picFrame->get_PictureFormat()->DeletePictureCroppedAreas();

// Mentés az eredmény
presentation->Save(u"PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
```

{{% alert title="NOTE" color="warning" %}} 

[IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) metódus hozzáadja a levágott képet a prezentáció képgyűjteményéhez. Ha a kép csak a feldolgozott [PictureFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/pictureframe/)-ban van használva, ez a beállítás csökkentheti a prezentáció méretét. Ellenkező esetben a végső prezentációban lévő képek száma nő.  

Ez a metódus a vágási művelet során a WMF/EMF metafájlokat raster PNG képpé konvertálja.  
{{% /alert %}}

## **Képek tömörítése**

A prezentációban lévő képet a [IPictureFillFormat::CompressImage()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipicturefillformat/compressimage/) metódussal tömörítheti. Ez a metódus a kép méretét a alakzat mérete és a megadott felbontás alapján csökkenti, lehetőséggel a levágott területek törlésére.  

A kép méretét és felbontását a PowerPoint **Picture Format -> Compress Pictures -> Resolution** funkciójával hasonló módon módosítja.  

A következő C++ példák bemutatják, hogyan lehet egy képet tömöríteni egy prezentációban a célfelbontás megadásával és opcionálisan a levágott területek eltávolításával:  

```c++
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Tömöríti a képet 150 DPI (web felbontás) célfelbontással és eltávolítja a levágott területeket.
bool result = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);

// Ellenőrzi a tömörítés eredményét.
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
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// A képet 150 DPI-re (web felbontás) tömöríti, a levágott területeket eltávolítva.
pictureFrame->get_PictureFormat()->CompressImage(true, 150.0f);

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}} 

A metódus a képet a alakzat mérete és a megadott DPI alapján alacsonyabb felbontásra konvertálja. A levágott területek is törölhetők a fájlméret optimalizálása érdekében. Ha a kép metafájl (WMF/EMF) vagy SVG, a tömörítés nem kerül alkalmazásra. Emellett a JPEG minőség megmarad vagy enyhén csökken a felbontástól függően, hasonlóan a PowerPoint magas felbontású JPEG-ek kezeléséhez.  
{{% /alert %}}

## **Arányok zárolása**

Ha egy képet tartalmazó alakzatot szeretne úgy beállítani, hogy a méretezés után is megtartsa az arányait, használhatja a [set_AspectRatioLocked()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) metódust az *Arányok zárolása* beállításhoz.  

```c++
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ILayoutSlide> layout = pres->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
System::SharedPtr<ISlide> emptySlide = pres->get_Slides()->AddEmptySlide(layout);

System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
System::SharedPtr<IPPImage> presImage = pres->get_Images()->AddImage(image);

System::SharedPtr<IPictureFrame> pictureFrame = emptySlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 150.0f, static_cast<float>(presImage->get_Width()), static_cast<float>(presImage->get_Height()), presImage);

// Állítsa be, hogy az alakzat átméretezéskor megőrizze az oldalarányt.
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);
```

{{% alert title="NOTE" color="warning" %}} 

Ez az *Arányok zárolása* beállítás csak az alakzat arányát őrzi meg, a benne lévő képet nem.  
{{% /alert %}}

## **A StretchOff tulajdonság használata**

A [StretchOffsetLeft](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471), [StretchOffsetTop](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a), [StretchOffsetRight](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) és [StretchOffsetBottom](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) tulajdonságok a [IPictureFillFormat](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_picture_fill_format) interfész és a [PictureFillFormat](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.picture_fill_format) osztály segítségével lehetővé teszik, hogy egy kitöltő téglalapot határozzon meg.  

Ha a kép nyújtását megadjuk, egy forrástéglalapot méreteznek úgy, hogy illeszkedjen a megadott kitöltő téglalaphoz. A kitöltő téglalap minden oldala egy százalékos eltolással van definiálva a alakzat határolókeretének megfelelő oldalához képest. A pozitív százalék belülre tolást jelent. A negatív százalék kifelé tolást jelent.  

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexén keresztül.  
3. Adjon hozzá egy téglalap `AutoShape`-t.  
4. Hozzon létre egy képet.  
5. Állítsa be az alakzat kitöltési típusát.  
6. Állítsa be az alakzat kép kitöltési módját.  
7. Adjon hozzá egy beállított képet az alakzat kitöltéséhez.  
8. Határozza meg a kép eltolását a alakzat határolókeretének megfelelő oldalától.  
9. Írja ki a módosított prezentációt PPTX fájlként.  

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
auto ppImage = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
auto slide = pres->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 400.0f, 400.0f, ppImage);

// Beállítja, hogy a kép a forma testének minden oldaláról legyen nyújtva
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_PictureFillMode(PictureFillMode::Stretch);
pictureFormat->set_StretchOffsetLeft(24.0f);
pictureFormat->set_StretchOffsetRight(24.0f);
pictureFormat->set_StretchOffsetTop(24.0f);
pictureFormat->set_StretchOffsetBottom(24.0f);

pres->Save(u"imageStretch.pptx", SaveFormat::Pptx);
```

## **GYIK**

### Hogyan tudom megállapítani, hogy mely képformátumok támogatottak a PictureFrame-hez?

Aspose.Slides támogatja mind a raster képeket (PNG, JPEG, BMP, GIF, stb.) és a vektor képeket (például SVG) a [PictureFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/pictureframe/) objektumhoz rendelt képobjektum révén. A támogatott formátumok listája általában megegyezik a dia és a képkonverziós motor képességeivel.

### Hogyan befolyásolja a nagy számú nagy képek hozzáadása a PPTX méretét és teljesítményét?

Nagyméretű képek beágyazása növeli a fájlméretet és a memóriahasználatot; a képek hivatkozással való hozzáadása segít csökkenteni a prezentáció méretét, de a külső fájloknak elérhetőnek kell maradniuk. Az Aspose.Slides lehetővé teszi képek hivatkozásként való hozzáadását a fájlméret csökkentése érdekében.

### Hogyan zárolhatom a képtárgyat a véletlen mozgatás/bővítés elől?

Használja a [shape locks](https://reference.aspose.com/slides/hu/cpp/aspose.slides/pictureframe/get_pictureframelock/) egy [PictureFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/pictureframe/) számára (például a mozgatás vagy átméretezés letiltásához). A zárolási mechanizmus a formákra vonatkozó külön [protection article](/slides/hu/cpp/applying-protection-to-presentation/) cikkben van leírva, és különböző alakzattípusokra is vonatkozik, köztük a [PictureFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/pictureframe/) objektumra.

### Megmarad az SVG vektor hűsége, amikor egy prezentációt PDF-re/képekre exportálják?

Aspose.Slides lehetővé teszi, hogy egy [PictureFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/pictureframe/) objektumból SVG-t az eredeti vektorként kinyerjen. PDF-re vagy [raster formátumok](/slides/hu/cpp/convert-powerpoint-to-png/) exportálásakor az eredmény rasterizálódhat az export beállításaitól függően; az eredeti SVG vektorként való tárolása a kinyerési viselkedésből is megerősíthető.