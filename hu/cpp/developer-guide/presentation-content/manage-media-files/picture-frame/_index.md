---
title: Képkeretek kezelése prezentációkban C++ segítségével
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
- kép vágása
- vágott terület
- StretchOff tulajdonság
- képkeret formázása
- képkeret tulajdonságok
- relatív méretezés
- kép effektus
- oldalarány
- kép átlátszóság
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Képkeretek hozzáadása PowerPoint és OpenDocument prezentációkhoz az Aspose.Slides for C++ segítségével. Egyszerűsítse a munkafolyamatot és javítsa a diaterveket."
---
## **Bevezetés**

A képkeret egy olyan alakzat, amely képet tartalmaz – ez olyan, mint egy kép egy keretben.  

Képet adhat hozzá egy diára egy képkereten keresztül. Így a képet a képkeret formázásával formázhatja.  

{{% alert  title="Tip" color="primary" %}} 
Az Aspose ingyenes konvertereket biztosít – [JPEG to PowerPoint](https://products.aspose.app/slides/hu/import/jpg-to-ppt) és [PNG to PowerPoint](https://products.aspose.app/slides/hu/import/png-to-ppt) –, amelyek lehetővé teszik, hogy gyorsan prezentációkat hozzanak létre képekből.  
{{% /alert %}} 

## **Képkeret létrehozása**

1. Hozzon létre egy példányt a [Presentation class](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.  
2. Szerezze meg a dia hivatkozását az indexe alapján.  
3. Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_p_p_image) objektumot úgy, hogy képet ad hozzá a [IImagescollection](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_image_collection) gyűjteményhez, amely a prezentáció objektumhoz kapcsolódik, és a forma kitöltésére lesz használva.  
4. Adja meg a kép szélességét és magasságát.  
5. Hozzon létre egy [PictureFrame](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.picture_frame) objektumot a kép szélessége és magassága alapján az `AddPictureFrame` metódus használatával, amely a hivatkozott diához kapcsolódó alakzat objektumnál érhető el.  
6. Adjon hozzá egy képkeretet (amely a képet tartalmazza) a diához.  
7. Írja ki a módosított prezentációt PPTX fájlként.  

```c++
// A dokumentumok könyvtárának elérési útja.
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Betölti a kívánt prezentációt.
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Az első diát eléri.
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Betölti a képet, amely a prezentáció képgyűjteményéhez lesz hozzáadva.
// Lekéri a képet.
auto image = Images::FromFile(filePath);

// Képet ad a prezentáció képgyűjteményéhez.
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Képkeretet ad a diához.
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Beállítja a relatív méretezés szélességét és magasságát.
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// Formáz néhány beállítást a képkeretre.
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

// A PPTX fájlt lemezre írja.
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="warning" %}} 
A képkeretek lehetővé teszik, hogy gyorsan előállítsunk prezentációs diákat képek alapján. Ha a képkeretet kombinálja az Aspose.Slides mentési beállításaival, kezelheti a bemeneti/kimeneti műveleteket a képek formátumok közötti átalakításához. Érdemes megnézni ezeket az oldalakat: konvertálás [image to JPG](https://products.aspose.com/slides/hu/cpp/conversion/image-to-jpg/); konvertálás [JPG to image](https://products.aspose.com/slides/hu/cpp/conversion/jpg-to-image/); konvertálás [JPG to PNG](https://products.aspose.com/slides/hu/cpp/conversion/jpg-to-png/), konvertálás [PNG to JPG](https://products.aspose.com/slides/hu/cpp/conversion/png-to-jpg/); konvertálás [PNG to SVG](https://products.aspose.com/slides/hu/cpp/conversion/png-to-svg/), konvertálás [SVG to PNG](https://products.aspose.com/slides/hu/cpp/conversion/svg-to-png/).  
{{% /alert %}}

## **Képkeret létrehozása relatív méretezéssel**

A kép relatív méretezésének módosításával összetettebb képkeretet hozhat létre.  

1. Hozzon létre egy példányt a [Presentation class](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.  
2. Szerezze meg a dia hivatkozását az indexe alapján.  
3. Adjon hozzá egy képet a prezentáció képgyűjteményéhez.  
4. Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_p_p_image) objektumot úgy, hogy képet ad hozzá a [IImagescollection](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_image_collection) gyűjteményhez, amely a prezentáció objektumhoz kapcsolódik, és a forma kitöltésére lesz használva.  
5. Adja meg a kép relatív szélességét és magasságát a képkeretben.  
6. Írja ki a módosított prezentációt PPTX fájlként.  

```c++
// A dokumentumok könyvtárának elérési útja.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Betölti a kívánt prezentációt.
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Eléri az első diát.
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Betölti a képet, amely a prezentáció képgyűjteményéhez lesz hozzáadva.
// Lekéri a képet.
auto image = Images::FromFile(filePath);

// Képet ad a prezentáció képgyűjteményéhez.
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Képkeretet ad a diához.
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Beállítja a relatív méretezés szélességét és magasságát.
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// A PPTX fájlt lemezre írja.
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Raszteres képek kinyerése képkeretekből**

Raszteres képeket nyerhet ki a [PictureFrame](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.picture_frame) objektumokból, és elmentheti őket PNG, JPG és más formátumokban. Az alábbi kódrészlet bemutatja, hogyan nyerhet ki egy képet a "sample.pptx" dokumentumból, és mentheti PNG formátumban.  

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

Amikor egy prezentáció SVG grafikákat tartalmaz, amelyek a [PictureFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/pictureframe/) alakzatokban vannak elhelyezve, az Aspose.Slides for C++ lehetővé teszi, hogy a teljes pontossággal visszanyerje az eredeti vektorképeket. A dia alakzatgyűjteményének bejárásával azonosíthatja minden egyes [PictureFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/pictureframe/), ellenőrizheti, hogy az alá tartozó [IPPImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ippimage/) tartalmaz-e SVG tartalmat, majd mentheti a képet a lemezre vagy egy adatfolyamra natív SVG formátumban.  

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

## **Kép átlátszóságának lekérése**

Az Aspose.Slides lehetővé teszi, hogy lekérje egy képre alkalmazott átlátszósági effektust. Ez a C++ kód bemutatja a műveletet:  

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
Minden képre alkalmazott effektus megtalálható a [Aspose::Slides::Effects](https://reference.aspose.com/slides/hu/cpp/aspose.slides.effects/) címen.  
{{% /alert %}}

## **Kép fényerősségének és kontrasztjának lekérése**

Az Aspose.Slides lehetővé teszi, hogy lekérje egy képre alkalmazott fényerő és kontraszt effektust. A [ILuminance](https://reference.aspose.com/slides/hu/cpp/aspose.slides.effects/iluminance/) interfész képzi ezt a képtranszformációs effektust.  

Ez a C++ kód bemutatja, hogyan lehet lekérni a fényerő és kontraszt beállításait egy képkeretből:  

```c++
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

## **Képkeret formázása**

Az Aspose.Slides számos formázási lehetőséget kínál, amelyeket egy képkeretre lehet alkalmazni. Ezekkel a beállításokkal a képkeretet a specifikus követelményekhez igazíthatja.  

1. Hozzon létre egy példányt a [Presentation class](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.  
2. Szerezze meg a dia hivatkozását az indexe alapján.  
3. Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_p_p_image) objektumot úgy, hogy képet ad hozzá a [IImagescollection](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_image_collection) gyűjteményhez, amely a prezentáció objektumhoz kapcsolódik, és a forma kitöltésére lesz használva.  
4. Adja meg a kép szélességét és magasságát.  
5. Hozzon létre egy `PictureFrame`-et a kép szélessége és magassága alapján a [AddPictureFrame](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) metódus használatával, amely a hivatkozott diához kapcsolódó [IShapes](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_shape_collection) objektumnál érhető el.  
6. Adjon hozzá a képkeretet (amely a képet tartalmazza) a diához.  
7. Állítsa be a képkeret vonalszínét.  
8. Állítsa be a képkeret vonalvastagságát.  
9. Forgassa el a képkeretet pozitív vagy negatív érték megadásával.  
   * A pozitív érték az óramutató járásával megegyező irányban forgatja a képet.  
   * A negatív érték az óramutató járásával ellentétes irányban forgatja a képet.  
10. Adjon hozzá a képkeretet (amely a képet tartalmazza) a diához.  
11. Írja ki a módosított prezentációt PPTX fájlként.  

```c++
// A dokumentumok könyvtárának elérési útja.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Betölti a kívánt prezentációt.
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Az első diát eléri.
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Betölti a képet, amely a prezentáció képgyűjteményéhez lesz hozzáadva.
// Lekéri a képet.
auto image = Images::FromFile(filePath);

// Képet ad a prezentáció képgyűjteményéhez.
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Képkeretet ad a diához.
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Beállítja a relatív méretezés szélességét és magasságát.
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// A PPTX fájlt lemezre írja.
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert title="Tip" color="primary" %}} 
Az Aspose nemrég fejlesztett egy [ingyenes Collage Maker](https://products.aspose.app/slides/hu/collage) szolgáltatást. Ha valaha meg kellene [összevonni JPG/JPEG](https://products.aspose.app/slides/hu/collage/jpg) vagy PNG képeket, vagy [rácsokat kellene készíteni fényképekből](https://products.aspose.app/slides/hu/collage/photo-grid), használhatja ezt a szolgáltatást.  
{{% /alert %}}

## **Kép hozzáadása linkként**

A nagy méretű prezentációk elkerülése érdekében képeket (vagy videókat) is hozzáadhat linkeken keresztül, ahelyett, hogy a fájlokat közvetlenül beágyazná a prezentációba. Ez a C++ kód bemutatja, hogyan adjon hozzá egy képet és videót egy helyőrzőhöz:  

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

## **Képek vágása**

Ez a C++ kód bemutatja, hogyan vághat le egy meglévő képet egy dián:  

``` CPP
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;
    
auto presentation = System::MakeObject<Presentation>();
// Új képobjektumot hoz létre
auto newImage = presentation->get_Images()->AddImage(Images::FromFile(imagePath));

// Képkeretet ad egy diához
auto picFrame = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 100.0f, 100.0f, 420.0f, 250.0f, newImage);

// Levágja a képet (százalékos értékek)
picFrame->get_PictureFormat()->set_CropLeft(23.6f);
picFrame->get_PictureFormat()->set_CropRight(21.5f);
picFrame->get_PictureFormat()->set_CropTop(3.0f);
picFrame->get_PictureFormat()->set_CropBottom(31.0f);

// Elmenti az eredményt
presentation->Save(outPptxFile, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Kép vágott területeinek törlése**

Ha törölni szeretné egy keretben lévő kép vágott területeit, használhatja az [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) metódust. Ez a metódus visszaadja a vágott képet, vagy az eredeti képet, ha a vágás nem szükséges.  

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

{{% alert title="NOTE" color="warning" %}} 
Az [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) metódus a vágott képet hozzáadja a prezentáció képgyűjteményéhez. Ha a képet csak a feldolgozott [PictureFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/pictureframe/) használja, ez a beállítás csökkentheti a prezentáció méretét. Ellenkező esetben a keletkező prezentációban lévő képek száma nő.  

Ez a metódus a vágási művelet során WMF/EMF metafájlokat raszteres PNG képpé konvertál.  
{{% /alert %}}

## **Képek tömörítése**

A prezentációban lévő képet a [IPictureFillFormat::CompressImage()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipicturefillformat/compressimage/) metódussal lehet tömöríteni.  
Ez a metódus a képet a forma mérete és a megadott felbontás alapján csökkenti, lehetőséget adva a vágott területek törlésére is.  

A kép méretét és felbontását úgy állítja be, mint a PowerPoint **Picture Format -> Compress Pictures -> Resolution** funkciója.  

Az alábbi C++ példák bemutatják, hogyan lehet tömöríteni egy képet a prezentációban célfelbontás megadásával és opcionálisan a vágott területek eltávolításával:  

```c++
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Tömöríti a képet 150 DPI (web felbontás) célfelbontással, és eltávolítja a vágott területeket.
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

Vagy közvetlenül egy egyéni DPI érték használatával:  

```c++
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// A képet 150 DPI-re (web felbontás) tömöríti, a vágott területeket eltávolítva.
pictureFrame->get_PictureFormat()->CompressImage(true, 150.0f);

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}} 
A metódus a képet alacsonyabb felbontásra konvertálja a forma mérete és a megadott DPI alapján. A vágott területek is törölhetők a fájlméret optimalizálása érdekében.  
Ha a kép metafájl (WMF/EMF) vagy SVG, a tömörítés nem lesz alkalmazva. Emellett a JPEG minőség megmarad vagy enyhén csökken a felbontás függvényében, hasonlóan ahhoz, ahogyan a PowerPoint kezeli a magas felbontású JPEG-eket.  
{{% /alert %}}

## **Oldalarány zárolása**

Ha egy képet tartalmazó alakzatot szeretne megtartani az oldalarányát a kép méretének módosítása után is, használhatja a [set_AspectRatioLocked()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) metódust a *Lock Aspect Ratio* beállítás aktiválásához.  

Ez a C++ kód bemutatja, hogyan zárolható egy alakzat oldalaránya:  

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ILayoutSlide> layout = pres->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
System::SharedPtr<ISlide> emptySlide = pres->get_Slides()->AddEmptySlide(layout);

System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
System::SharedPtr<IPPImage> presImage = pres->get_Images()->AddImage(image);

System::SharedPtr<IPictureFrame> pictureFrame = emptySlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 150.0f, static_cast<float>(presImage->get_Width()), static_cast<float>(presImage->get_Height()), presImage);

// Állítsa be az alakzatot, hogy átméretezéskor megőrizze az oldalarányt
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);
```

{{% alert title="NOTE" color="warning" %}} 
Ez a *Lock Aspect Ratio* beállítás csak az alakzat oldalarányát őrzi meg, nem a benne lévő képét.  
{{% /alert %}}

## **StretchOff tulajdonság használata**

A [StretchOffsetLeft](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471), [StretchOffsetTop](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a), [StretchOffsetRight](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) és [StretchOffsetBottom](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) tulajdonságok használatával az [IPictureFillFormat](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_picture_fill_format) interfészből és a [PictureFillFormat](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.picture_fill_format) osztályból megadhat egy kitöltő téglalapot.  

Ha a kép nyújtása meg van adva, a forrástéglalapot a megadott kitöltő téglalaphoz méretezi át. A kitöltő téglalap minden éle egy százalékos eltolással van meghatározva az alakzat határoló dobozának megfelelő élétől. A pozitív százalék egy behúzást jelent, a negatív százalék pedig egy kitágulást.  

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.  
2. Szerezze meg a dia hivatkozását az indexe alapján.  
3. Adjon hozzá egy `AutoShape` téglalapot.  
4. Hozzon létre egy képet.  
5. Állítsa be az alakzat kitöltéstípusát.  
6. Állítsa be az alakzat képkitöltési módját.  
7. Adjon hozzá egy beállított képet az alakzat kitöltéséhez.  
8. Adja meg a kép eltolásait a alakzat határoló dobozának megfelelő élétől.  
9. Írja ki a módosított prezentációt PPTX fájlként.  

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

**Hogyan tudom megtudni, hogy mely képformátumok támogatottak a PictureFrame esetén?**  
Az Aspose.Slides támogatja mind a raszteres képeket (PNG, JPEG, BMP, GIF stb.), mind a vektorképeket (például SVG) a [PictureFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/pictureframe/)‑hez rendelt képobjektumon keresztül. A támogatott formátumok listája általában átfedésben van a dia és a képkonverziós motor képességeivel.  

**Hogyan befolyásolja a PPTX méretét és teljesítményét a tucatnyi nagy kép hozzáadása?**  
A nagy képek beágyazása növeli a fájlméretet és a memóriahasználatot; a képek linkként való hozzáadása segít csökkenteni a prezentáció méretét, de az külső fájloknak elérhetőnek kell maradniuk. Az Aspose.Slides lehetőséget biztosít a képek linkkel történő hozzáadására a fájlméret csökkentése érdekében.  

**Hogyan tudom zárolni egy képobjektumot a véletlen mozgatás/átméretezés ellen?**  
Használjon [shape locks](https://reference.aspose.com/slides/hu/cpp/aspose.slides/pictureframe/get_pictureframelock/) egy [PictureFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/pictureframe/) esetén (például a mozgatás vagy átméretezés letiltásával). A zárolási mechanizmus a formákra vonatkozóan egy külön [protection article](/slides/hu/cpp/applying-protection-to-presentation/) leírásban található, és különféle forma típusok, köztük a [PictureFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/pictureframe/) számára támogatott.  

**Megmarad-e az SVG vektor pontossága, amikor egy prezentációt PDF-re/képre exportálunk?**  
Az Aspose.Slides lehetővé teszi az SVG kinyerését egy [PictureFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/pictureframe/)‑ből eredeti vektorként. Amikor [PDF-re exportálunk](/slides/hu/cpp/convert-powerpoint-to-pdf/) vagy [raszteres formátumokra](/slides/hu/cpp/convert-powerpoint-to-png/), az eredmény a export beállításaitól függően rasterizálódhat; a kinyerési viselkedés megerősíti, hogy az eredeti SVG vektor formában van tárolva.