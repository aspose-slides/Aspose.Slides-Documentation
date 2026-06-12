---
title: Správa rámečků obrázku v prezentacích pomocí C++
linktitle: Rámeček obrázku
type: docs
weight: 10
url: /cs/cpp/picture-frame/
keywords:
- rámeček obrázku
- přidat rámeček obrázku
- vytvořit rámeček obrázku
- přidat obrázek
- vytvořit obrázek
- extrahovat obrázek
- rastrový obrázek
- vektorový obrázek
- oříznout obrázek
- ořezaná oblast
- vlastnost StretchOff
- formátování rámečku obrázku
- vlastnosti rámečku obrázku
- relativní měřítko
- efekt obrázku
- poměr stran
- průhlednost obrázku
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Přidejte rámečky obrázků do prezentací PowerPoint a OpenDocument pomocí Aspose.Slides pro C++. Zjednodušte svůj pracovní tok a vylepšete návrh snímků."
---
## **Úvod**

Rámeček obrázku je tvar, který obsahuje obrázek – je to jako obrázek v rámečku.  

Můžete přidat obrázek na snímek pomocí rámečku obrázku. Tímto způsobem můžete obrázek formátovat úpravou rámečku obrázku.

{{% alert  title="Tip" color="primary" %}} 
Aspose poskytuje zdarma převodníky –[JPEG do PowerPointu](https://products.aspose.app/slides/cs/import/jpg-to-ppt) a [PNG do PowerPointu](https://products.aspose.app/slides/cs/import/png-to-ppt) – které umožňují rychle vytvářet prezentace z obrázků. 
{{% /alert %}} 

## **Vytvoření rámečku obrázku**

1. Vytvořte instanci [Presentation class](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation).
2. Získejte odkaz na snímek pomocí jeho indexu. 
3. Vytvořte objekt [IPPImage](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_p_p_image) přidáním obrázku do [IImagescollection](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_image_collection), která je součástí objektu prezentace a bude použita k vyplnění tvaru.
4. Určete šířku a výšku obrázku.
5. Vytvořte [PictureFrame](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.picture_frame) založený na šířce a výšce obrázku pomocí metody `AddPictureFrame`, která je k dispozici u objektu tvaru spojeného s odkazovaným snímkem.
6. Přidejte rámeček obrázku (obsahující obrázek) na snímek.
7. Uložte upravenou prezentaci jako soubor PPTX.

Tento C++ kód ukazuje, jak vytvořit rámeček obrázku:

```c++
// Cesta k adresáři dokumentů.
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Načíst požadovanou prezentaci
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Získá první snímek
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Načte obrázek, který bude přidán do kolekce obrázků prezentace
// Získá obrázek
auto image = Images::FromFile(filePath);

// Přidá obrázek do kolekce obrázků prezentace
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Přidá rámeček obrázku na snímek
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Nastaví relativní měřítko šířky a výšky
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// Aplikuje určité formátování na rámeček obrázku
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

// Zapíše soubor PPTX na disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="warning" %}} 
Rámečky obrázku vám umožňují rychle vytvářet snímky prezentace založené na obrázcích. Když kombinujete rámeček obrázku s možnostmi ukládání Aspose.Slides, můžete manipulovat s operacemi vstupu/výstupu pro převod obrázků z jednoho formátu do druhého. Můžete se podívat na následující stránky: převést [obrázek do JPG](https://products.aspose.com/slides/cs/cpp/conversion/image-to-jpg/); převést [JPG na obrázek](https://products.aspose.com/slides/cs/cpp/conversion/jpg-to-image/); převést [JPG na PNG](https://products.aspose.com/slides/cs/cpp/conversion/jpg-to-png/), převést [PNG na JPG](https://products.aspose.com/slides/cs/cpp/conversion/png-to-jpg/); převést [PNG na SVG](https://products.aspose.com/slides/cs/cpp/conversion/png-to-svg/), převést [SVG na PNG](https://products.aspose.com/slides/cs/cpp/conversion/svg-to-png/). 
{{% /alert %}}

## **Vytvoření rámečku obrázku s relativním měřítkem**

Úpravou relativního měřítka obrázku můžete vytvořit složitější rámeček obrázku. 

1. Vytvořte instanci [Presentation class](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation).
2. Získejte odkaz na snímek pomocí jeho indexu. 
3. Přidejte obrázek do kolekce obrázků prezentace.
4. Vytvořte objekt [IPPImage](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_p_p_image) přidáním obrázku do [IImagescollection](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_image_collection), která je součástí objektu prezentace a bude použita k vyplnění tvaru.
5. Určete relativní šířku a výšku obrázku v rámečku obrázku.
6. Uložte upravenou prezentaci jako soubor PPTX.

Následující C++ kód ukazuje, jak vytvořit rámeček obrázku s relativním měřítkem:

```c++
// Cesta k adresáři dokumentů.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Načte požadovanou prezentaci
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Získá první snímek
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Načte obrázek, který bude přidán do kolekce obrázků prezentace
// Získá obrázek
auto image = Images::FromFile(filePath);

// Přidá obrázek do kolekce obrázků prezentace
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Přidá rámeček obrázku na snímek
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Nastaví relativní měřítko šířky a výšky
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

//Zapíše soubor PPTX na disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Extrahování rastrových obrázků z rámečků obrázku**

Můžete extrahovat rastrové obrázky z objektů [PictureFrame](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.picture_frame) a uložit je ve formátech PNG, JPG a dalších. Níže uvedený ukázkový kód demonstruje, jak extrahovat obrázek z dokumentu „sample.pptx“ a uložit jej ve formátu PNG. 

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

## **Extrahování SVG obrázků z rámečků obrázku**

Když prezentace obsahuje grafiku SVG umístěnou uvnitř tvarů [PictureFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/pictureframe/), Aspose.Slides pro C++ vám umožňuje získat původní vektorové obrázky s úplnou věrností. Procházením kolekce tvarů snímku můžete identifikovat každý [PictureFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/pictureframe/), zkontrolovat, zda podkladový [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/) obsahuje SVG obsah, a poté uložit tento obrázek na disk nebo do proudu v jeho nativním SVG formátu.

Následující ukázka kódu demonstruje, jak extrahovat SVG obrázek z rámečku obrázku:

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

## **Získání průhlednosti obrázku**

Aspose.Slides vám umožňuje získat efekt průhlednosti aplikovaný na obrázek. Tento C++ kód demonstruje operaci:

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
Všechny efekty aplikované na obrázky můžete najít v [Aspose::Slides::Effects](https://reference.aspose.com/slides/cs/cpp/aspose.slides.effects/). 
{{% /alert %}}

## **Formátování rámečku obrázku**

Aspose.Slides poskytuje mnoho možností formátování, které lze aplikovat na rámeček obrázku. Pomocí těchto možností můžete upravit rámeček obrázku tak, aby vyhovoval konkrétním požadavkům.

1. Vytvořte instanci [Presentation class](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation).
2. Získejte odkaz na snímek pomocí jeho indexu. 
3. Vytvořte objekt [IPPImage](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_p_p_image) přidáním obrázku do [IImagescollection](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_image_collection), která je součástí objektu prezentace a bude použita k vyplnění tvaru.
4. Určete šířku a výšku obrázku.
5. Vytvořte `PictureFrame` založený na šířce a výšce obrázku pomocí metody [AddPictureFrame](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9), která je k dispozici u objektu [IShapes](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_shape_collection) spojeného s odkazovaným snímkem.
6. Přidejte rámeček obrázku (obsahující obrázek) na snímek.
7. Nastavte barvu čáry rámečku obrázku.
8. Nastavte šířku čáry rámečku obrázku.
9. Otočte rámeček obrázku zadáním kladné nebo záporné hodnoty.
   * Kladná hodnota otáčí obrázek po směru hodinových ručiček. 
   * Záporná hodnota otáčí obrázek proti směru hodinových ručiček.
10. Přidejte rámeček obrázku (obsahující obrázek) na snímek.
11. Uložte upravenou prezentaci jako soubor PPTX.

Tento C++ kód demonstruje proces formátování rámečku obrázku:

```c++
// Cesta k adresáři dokumentů.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Načte požadovanou prezentaci
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Získá první snímek
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Načte obrázek, který bude přidán do kolekce obrázků prezentace
// Získá obrázek
auto image = Images::FromFile(filePath);

// Přidá obrázek do kolekce obrázků prezentace
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Přidá rámeček obrázku na snímek
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Nastaví relativní měřítko šířky a výšky
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

//Zapíše soubor PPTX na disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert title="Tip" color="primary" %}}
Aspose nedávno vyvinulo [bezplatný Collage Maker](https://products.aspose.app/slides/cs/collage). Pokud potřebujete [sloučit JPG/JPEG](https://products.aspose.app/slides/cs/collage/jpg) nebo PNG obrázky, [vytvořit mřížky z fotek](https://products.aspose.app/slides/cs/collage/photo-grid), můžete použít tuto službu. 
{{% /alert %}}

## **Přidání obrázku jako odkazu**

Aby se předešlo velkým velikostem prezentací, můžete přidávat obrázky (nebo videa) prostřednictvím odkazů místo vložení souborů přímo do prezentací. Tento C++ kód ukazuje, jak přidat obrázek a video do zástupce:

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

## **Ořezávání obrázků**

Tento C++ kód ukazuje, jak oříznout existující obrázek na snímku: 

``` CPP
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;
    
auto presentation = System::MakeObject<Presentation>();
// Vytvoří nový objekt obrázku
auto newImage = presentation->get_Images()->AddImage(Images::FromFile(imagePath));

// Přidá PictureFrame na snímek
auto picFrame = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 100.0f, 100.0f, 420.0f, 250.0f, newImage);

// Ořízne obrázek (hodnoty v procentech)
picFrame->get_PictureFormat()->set_CropLeft(23.6f);
picFrame->get_PictureFormat()->set_CropRight(21.5f);
picFrame->get_PictureFormat()->set_CropTop(3.0f);
picFrame->get_PictureFormat()->set_CropBottom(31.0f);

// Uloží výsledek
presentation->Save(outPptxFile, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Odstranění oříznutých oblastí obrázku**

Pokud chcete odstranit oříznuté oblasti obrázku obsaženého v rámečku, můžete použít metodu [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/). Tato metoda vrací oříznutý obrázek nebo původní obrázek, pokud ořez není nutný.

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
Metoda [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) přidává oříznutý obrázek do kolekce obrázků prezentace. Pokud je obrázek použit pouze ve zpracovávaném [PictureFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/pictureframe/), tato úprava může snížit velikost prezentace. V opačném případě se počet obrázků ve výsledné prezentaci zvýší.  

Tato metoda převádí WMF/EMF metafáily na rastrový PNG obrázek během ořezávání. 
{{% /alert %}}

## **Komprese obrázků**

Můžete komprimovat obrázek v prezentaci pomocí metody [IPictureFillFormat::CompressImage()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipicturefillformat/compressimage/). Tato metoda komprimuje obrázek snížením jeho velikosti na základě velikosti tvaru a zadaného rozlišení, s možností smazat oříznuté oblasti.

Upravuje velikost a rozlišení obrázku podobně jako funkce PowerPointu **Picture Format -> Compress Pictures -> Resolution**.

Následující C++ příklady ukazují, jak komprimovat obrázek v prezentaci zadáním cílového rozlišení a volitelným odstraněním oříznutých oblastí:

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

Nebo přímo použitím vlastního DPI:

```c++
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Zkomprimuje obrázek na 150 DPI (webové rozlišení) a odstraní oříznuté oblasti.
pictureFrame->get_PictureFormat()->CompressImage(true, 150.0f);

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}}
Metoda převádí obrázek na nižší rozlišení na základě velikosti tvaru a zadaného DPI. Oříznuté oblasti lze také smazat pro optimalizaci velikosti souboru.  

Pokud je obrázek metafile (WMF/EMF) nebo SVG, komprese se nepoužije. Kvalita JPEG je také zachována či mírně snížena podle rozlišení, podobně jako PowerPoint zachází s JPEG ve vysokém rozlišení. 
{{% /alert %}}

## **Uzamčení poměru stran**

Pokud chcete, aby tvar obsahující obrázek zachoval svůj poměr stran i po změně rozměrů obrázku, můžete použít metodu [set_AspectRatioLocked()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) k nastavení volby *Lock Aspect Ratio*. 

Tento C++ kód ukazuje, jak uzamknout poměr stran tvaru:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ILayoutSlide> layout = pres->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
System::SharedPtr<ISlide> emptySlide = pres->get_Slides()->AddEmptySlide(layout);

System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
System::SharedPtr<IPPImage> presImage = pres->get_Images()->AddImage(image);

System::SharedPtr<IPictureFrame> pictureFrame = emptySlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 150.0f, static_cast<float>(presImage->get_Width()), static_cast<float>(presImage->get_Height()), presImage);

// set shape to have to preserve aspect ratio on resizing
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);
```

{{% alert title="NOTE" color="warning" %}} 
Toto nastavení *Lock Aspect Ratio* zachovává pouze poměr stran tvaru, ne obrázku, který obsahuje. 
{{% /alert %}}

## **Použití vlastnosti StretchOff**

Pomocí vlastností [StretchOffsetLeft](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471), [StretchOffsetTop](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a), [StretchOffsetRight](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) a [StretchOffsetBottom](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) rozhraní [IPictureFillFormat](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_picture_fill_format) a třídy [PictureFillFormat](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.picture_fill_format) můžete zadat výplňový obdélník.  

Když je specifikováno roztahování obrázku, zdrojový obdélník se škáluje tak, aby vyplnil určený výplňový obdélník. Každý okraj výplňového obdélníku je definován procentuálním posunem od odpovídajícího okraje ohraničujícího rámečku tvaru. Kladné procento udává vnitřní odsazení. Záporné procento udává vnější rozšíření.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation).
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte obdélník `AutoShape`. 
4. Vytvořte obrázek.
5. Nastavte typ výplně tvaru.
6. Nastavte režim výplně obrázkem tvaru.
7. Přidejte nastavený obrázek pro vyplnění tvaru.
8. Určete posuny obrázku od příslušného okraje ohraničujícího rámečku tvaru
9. Uložte upravenou prezentaci jako soubor PPTX.

Tento C++ kód demonstruje proces, při kterém je použita vlastnost StretchOff:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto ppImage = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
auto slide = pres->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 400.0f, 400.0f, ppImage);

// Nastaví obrázek natažený ze všech stran v těle tvaru
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_PictureFillMode(PictureFillMode::Stretch);
pictureFormat->set_StretchOffsetLeft(24.0f);
pictureFormat->set_StretchOffsetRight(24.0f);
pictureFormat->set_StretchOffsetTop(24.0f);
pictureFormat->set_StretchOffsetBottom(24.0f);

pres->Save(u"imageStretch.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Jak zjistit, které formáty obrázků jsou podporovány pro PictureFrame?**

Aspose.Slides podporuje jak rastrové obrázky (PNG, JPEG, BMP, GIF atd.), tak vektorové obrázky (například SVG) prostřednictvím objektu obrázku přiřazeného k [PictureFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/pictureframe/). Seznam podporovaných formátů obecně překrývá schopnosti motoru pro konverzi snímků a obrázků.

**Jak přidání desítek velkých obrázků ovlivní velikost a výkon PPTX?**

Vkládání velkých obrázků zvyšuje velikost souboru a spotřebu paměti; propojování obrázků pomáhá udržet velikost prezentace menší, ale vyžaduje, aby externí soubory zůstaly dostupné. Aspose.Slides poskytuje možnost přidávat obrázky jako odkazy pro snížení velikosti souboru.

**Jak mohu uzamknout objekt obrázku před neúmyslným přesouváním/změnou velikosti?**

Použijte [shape locks](https://reference.aspose.com/slides/cs/cpp/aspose.slides/pictureframe/get_pictureframelock/) pro [PictureFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/pictureframe/) (například zakázat přesouvání nebo změnu velikosti). Mechanismus zamykání je popsán pro tvary v samostatném [protection article](/slides/cs/cpp/applying-protection-to-presentation/) a je podporován pro různé typy tvarů, včetně [PictureFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/pictureframe/).

**Je zachována vektorová věrnost SVG při exportu prezentace do PDF/obrázků?**

Aspose.Slides umožňuje extrahovat SVG z [PictureFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/pictureframe/) jako původní vektor. Při [exportu do PDF](/slides/cs/cpp/convert-powerpoint-to-pdf/) nebo [rastrových formátů](/slides/cs/cpp/convert-powerpoint-to-png/) může být výsledek rasterizován v závislosti na nastavení exportu; fakt, že původní SVG je uložen jako vektor, je potvrzen chováním při extrakci.