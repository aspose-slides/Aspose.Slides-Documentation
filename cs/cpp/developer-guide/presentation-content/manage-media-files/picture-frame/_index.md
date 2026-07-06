---
title: Spravujte rámy obrázků v prezentacích pomocí C++
linktitle: Rám obrázku
type: docs
weight: 10
url: /cs/cpp/picture-frame/
keywords:
- rám obrázku
- přidat rám obrázku
- vytvořit rám obrázku
- přidat obrázek
- vytvořit obrázek
- extrahovat obrázek
- rastrovaný obrázek
- vektorový obrázek
- oříznout obrázek
- oříznutá oblast
- vlastnost StretchOff
- formátování rámu obrázku
- vlastnosti rámu obrázku
- relativní měřítko
- efekt obrázku
- poměr stran
- průhlednost obrázku
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Přidejte rámy obrázků do prezentací PowerPoint a OpenDocument pomocí Aspose.Slides pro C++. Zefektivněte svůj pracovní proces a vylepšete návrhy snímků."
---
## **Úvod**

Rám obrazu je tvar, který obsahuje obrázek – je to jako obrázek v rámečku.  

Obrázek můžete do snímku přidat prostřednictvím rámu obrazu. Tímto způsobem můžete formátovat obrázek formátováním rámu.

{{% alert  title="Tip" color="primary" %}} 
Aspose poskytuje bezplatné konvertory – [JPEG do PowerPointu](https://products.aspose.app/slides/cs/import/jpg-to-ppt) a [PNG do PowerPointu](https://products.aspose.app/slides/cs/import/png-to-ppt) – které umožňují rychle vytvářet prezentace z obrázků. 
{{% /alert %}} 

## **Vytvoření rámu obrazu**

1. Vytvořte instanci třídy [Presentation class](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation).
2. Získejte referenci na snímek podle jeho indexu. 
3. Vytvořte objekt [IPPImage](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_p_p_image) přidáním obrázku do [IImagescollection](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_image_collection), který je přidružen k objektu prezentace a bude použit k vyplnění tvaru.
4. Určete šířku a výšku obrázku.
5. Vytvořte [PictureFrame](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.picture_frame) založený na šířce a výšce obrázku pomocí metody `AddPictureFrame` vystavené objektem tvaru přidruženým k referencovanému snímku.
6. Přidejte rám obrazu (obsahující obrázek) na snímek.
7. Uložte upravenou prezentaci jako soubor PPTX.

Tento C++ kód ukazuje, jak vytvořit rám obrazu:

```c++
// Cesta k adresáři dokumentů.
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Načtěte požadovanou prezentaci
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Přistupuje k prvnímu snímku
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Načte obrázek, který bude přidán do kolekce obrázků prezentace
// Získá obrázek
auto image = Images::FromFile(filePath);

// Přidá obrázek do kolekce obrázků prezentace
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Přidá rám obrázku na snímek
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Nastaví relativní měřítko šířky a výšky
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// Aplikuje určité formátování na rám obrázku
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

//Zapíše soubor PPTX na disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="warning" %}} 
Rám obrazu vám umožňuje rychle vytvářet snímky prezentace na základě obrázků. Když zkombinujete rám obrazu s možnostmi ukládání Aspose.Slides, můžete manipulovat s operacemi vstupu/výstupu pro konverzi obrázků z jednoho formátu do druhého. Můžete se podívat na tyto stránky: převod [obrázku do JPG](https://products.aspose.com/slides/cs/cpp/conversion/image-to-jpg/); převod [JPG do obrázku](https://products.aspose.com/slides/cs/cpp/conversion/jpg-to-image/); převod [JPG do PNG](https://products.aspose.com/slides/cs/cpp/conversion/jpg-to-png/), převod [PNG do JPG](https://products.aspose.com/slides/cs/cpp/conversion/png-to-jpg/); převod [PNG do SVG](https://products.aspose.com/slides/cs/cpp/conversion/png-to-svg/), převod [SVG do PNG](https://products.aspose.com/slides/cs/cpp/conversion/svg-to-png/). 
{{% /alert %}}

## **Vytvoření rámu obrazu s relativním měřítkem**

Úpravou relativního měřítka obrázku můžete vytvořit složitější rám obrazu. 

1. Vytvořte instanci třídy [Presentation class](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation).
2. Získejte referenci na snímek podle jeho indexu. 
3. Přidejte obrázek do kolekce obrázků prezentace.
4. Vytvořte objekt [IPPImage](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_p_p_image) přidáním obrázku do [IImagescollection](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_image_collection) přidružené k objektu prezentace, který bude použit k vyplnění tvaru.
5. Určete relativní šířku a výšku obrázku v rámu obrazu.
6. Uložte upravenou prezentaci jako soubor PPTX.

Tento C++ kód ukazuje, jak vytvořit rám obrazu s relativním měřítkem:

```c++
// Cesta k adresáři dokumentů.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Načte požadovanou prezentaci
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Přistupuje k prvnímu snímku
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Načte obrázek, který bude přidán do kolekce obrázků prezentace
// Získá obrázek
auto image = Images::FromFile(filePath);

// Přidá obrázek do kolekce obrázků prezentace
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Přidá rám obrázku na snímek
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Nastaví relativní měřítko šířky a výšky
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

//Zapíše soubor PPTX na disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Extrahování rastrových obrázků z rámů obrazu**

Můžete extrahovat rastrové obrázky z objektů [PictureFrame](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.picture_frame) a uložit je ve formátech PNG, JPG a dalších. Níže uvedený příklad kódu ukazuje, jak extrahovat obrázek ze souboru „sample.pptx“ a uložit jej ve formátu PNG.

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

## **Extrahování SVG obrázků z rámů obrazu**

Když prezentace obsahuje SVG grafiku umístěnou uvnitř tvarů [PictureFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/pictureframe/), Aspose.Slides pro C++ umožňuje získat původní vektorové obrázky s plnou věrností. Procházením kolekce tvarů snímku můžete identifikovat každý [PictureFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/pictureframe/), zkontrolovat, zda podkladový [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/) obsahuje SVG obsah, a následně tento obrázek uložit na disk nebo do proudu v jeho nativním SVG formátu.

Následující příklad kódu ukazuje, jak extrahovat SVG obrázek z rámu obrazu:

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

Aspose.Slides umožňuje získat efekt průhlednosti aplikovaný na obrázek. Tento C++ kód demonstruje operaci:

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
Všechny efekty aplikované na obrázky lze najít v [Aspose::Slides::Effects](https://reference.aspose.com/slides/cs/cpp/aspose.slides.effects/). 
{{% /alert %}}

## **Získání jasu a kontrastu obrázku**

Aspose.Slides umožňuje získat efekt jasu a kontrastu aplikovaný na obrázek. Rozhraní [ILuminance](https://reference.aspose.com/slides/cs/cpp/aspose.slides.effects/iluminance/) představuje tento transformační efekt obrázku.

Tento C++ kód ukazuje, jak získat nastavení jasu a kontrastu z rámu obrazu:

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

## **Formátování rámu obrazu**

Aspose.Slides poskytuje mnoho možností formátování, které lze aplikovat na rám obrazu. Pomocí těchto možností můžete upravit rám obrazu tak, aby splňoval konkrétní požadavky.

1. Vytvořte instanci třídy [Presentation class](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation).
2. Získejte referenci na snímek podle jeho indexu. 
3. Vytvořte objekt [IPPImage](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_p_p_image) přidáním obrázku do [IImagescollection](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_image_collection) přidružené k objektu prezentace, který bude použit k vyplnění tvaru.
4. Určete šířku a výšku obrázku.
5. Vytvořte `PictureFrame` na základě šířky a výšky obrázku pomocí metody [AddPictureFrame](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) vystavené objektu [IShapes](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_shape_collection) přidruženému k referencovanému snímku.
6. Přidejte rám obrazu (obsahující obrázek) na snímek.
7. Nastavte barvu čáry rámu obrazu.
8. Nastavte šířku čáry rámu obrazu.
9. Otočte rám obrazu zadáním kladné nebo záporné hodnoty.  
   * Kladná hodnota otáčí obrázek po směru hodinových ručiček.  
   * Záporná hodnota otáčí obrázek proti směru hodinových ručiček.
10. Přidejte rám obrazu (obsahující obrázek) na snímek.
11. Uložte upravenou prezentaci jako soubor PPTX.

Tento C++ kód demonstruje proces formátování rámu obrazu:

```c++
// Cesta k adresáři dokumentů.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Načte požadovanou prezentaci
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Přistupuje k prvnímu snímku
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Načte obrázek, který bude přidán do kolekce obrázků prezentace
// Získá obrázek
auto image = Images::FromFile(filePath);

// Přidá obrázek do kolekce obrázků prezentace
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Přidá rám obrázku na snímek
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Nastaví relativní měřítko šířky a výšky
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

//Zapíše soubor PPTX na disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert title="Tip" color="primary" %}} 
Aspose nedávno vyvinulo [bezplatný Collage Maker](https://products.aspose.app/slides/cs/collage). Pokud potřebujete spojit JPG/JPEG nebo PNG obrázky, vytvořit mřížky z fotografií, můžete tento službu využít. 
{{% /alert %}}

## **Přidání obrázku jako odkazu**

Aby se předešlo velkým velikostem prezentací, můžete obrázky (nebo videa) přidávat pomocí odkazů místo vkládání souborů přímo do prezentace. Tento C++ kód ukazuje, jak přidat obrázek a video do zástupce:

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

// Přidá rám obrázku na snímek
auto picFrame = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 100.0f, 100.0f, 420.0f, 250.0f, newImage);

// Ořeže obrázek (procentuální hodnoty)
picFrame->get_PictureFormat()->set_CropLeft(23.6f);
picFrame->get_PictureFormat()->set_CropRight(21.5f);
picFrame->get_PictureFormat()->set_CropTop(3.0f);
picFrame->get_PictureFormat()->set_CropBottom(31.0f);

// Uloží výsledek
presentation->Save(outPptxFile, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Odstranění oříznutých oblastí obrázku**

Pokud chcete odstranit oříznuté oblasti obrázku obsaženého v rámečku, můžete použít metodu [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/). Tato metoda vrací oříznutý obrázek nebo původní obrázek, pokud ořez není potřeba.

Tento C++ kód demonstruje operaci: 

```c++
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"PictureFrameCrop.pptx");
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Získá PictureFrame z prvního snímku
System::SharedPtr<IPictureFrame> picFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Odstraní oříznuté oblasti obrázku v PictureFrame a vrátí oříznutý obrázek
System::SharedPtr<IPPImage> croppedImage = picFrame->get_PictureFormat()->DeletePictureCroppedAreas();

// Uloží výsledek
presentation->Save(u"PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
```

{{% alert title="NOTE" color="warning" %}} 
Metoda [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) přidává oříznutý obrázek do kolekce obrázků prezentace. Pokud je obrázek použit pouze v upraveném [PictureFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/pictureframe/), může tato konfigurace snížit velikost prezentace. V opačném případě se počet obrázků ve výsledné prezentaci zvýší.  

Metoda při operaci ořezávání konvertuje WMF/EMF metafily na rastrový PNG obrázek. 
{{% /alert %}}

## **Komprese obrázků**

Obrázek v prezentaci můžete komprimovat pomocí metody [IPictureFillFormat::CompressImage()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipicturefillformat/compressimage/). Tato metoda komprimuje obrázek snížením jeho velikosti na základě velikosti tvaru a zadaného rozlišení, s možností odstranit oříznuté oblasti.

Přizpůsobuje velikost a rozlišení obrázku podobně jako funkce PowerPointu **Formát obrázku → Komprimovat obrázky → Rozlišení**.

Následující příklady v C++ ukazují, jak komprimovat obrázek v prezentaci zadáním cílového rozlišení a volitelně odstraněním oříznutých oblastí:

```c++
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Zkomprimuje obrázek na cílové rozlišení 150 DPI (webové rozlišení) a odstraní oříznuté oblasti.
bool result = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);

// Zkontrolujte výsledek komprese.
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

Nebo pomocí přímého zadání vlastního DPI:

```c++
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Zkomprimuje obrázek na 150 DPI (webové rozlišení), odstraní oříznuté oblasti.
pictureFrame->get_PictureFormat()->CompressImage(true, 150.0f);

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}} 
Metoda konvertuje obrázek na nižší rozlišení na základě velikosti tvaru a zadaného DPI. Oříznuté oblasti lze také odstranit pro optimalizaci velikosti souboru.  
Pokud je obrázek metafile (WMF/EMF) nebo SVG, komprese se nepoužije. Kvalita JPEG se zachová nebo mírně sníží podle rozlišení, podobně jako PowerPoint zachází s JPEG ve vysokém rozlišení. 
{{% /alert %}}

## **Uzamčení poměru stran**

Pokud chcete, aby tvar obsahující obrázek zachoval poměr stran i po změně rozměrů obrázku, můžete použít metodu [set_AspectRatioLocked()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) k nastavení vlastnosti *Lock Aspect Ratio*. 

Tento C++ kód ukazuje, jak uzamknout poměr stran tvaru:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ILayoutSlide> layout = pres->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
System::SharedPtr<ISlide> emptySlide = pres->get_Slides()->AddEmptySlide(layout);

System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
System::SharedPtr<IPPImage> presImage = pres->get_Images()->AddImage(image);

System::SharedPtr<IPictureFrame> pictureFrame = emptySlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 150.0f, static_cast<float>(presImage->get_Width()), static_cast<float>(presImage->get_Height()), presImage);

// nastavit tvar tak, aby zachovával poměr stran při změně velikosti
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);
```

{{% alert title="NOTE" color="warning" %}} 
Nastavení *Lock Aspect Ratio* zachovává pouze poměr stran tvaru, nikoli obrázek, který obsahuje. 
{{% /alert %}}

## **Použití vlastnosti StretchOff**

Pomocí vlastností [StretchOffsetLeft](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471), [StretchOffsetTop](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a), [StretchOffsetRight](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) a [StretchOffsetBottom](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) z rozhraní [IPictureFillFormat](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_picture_fill_format) a třídy [PictureFillFormat](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.picture_fill_format) můžete určit výplňový obdélník.  

Při specifikaci natažení obrázku se zdrojový obdélník škáluje tak, aby zaplnil zadaný výplňový obdélník. Každý okraj výplňového obdélníku je definován procentuálním posunem od odpovídajícího okraje ohraničujícího rámečku tvaru. Kladné procento určuje posun dovnitř, záporné procento posun ven.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation).
2. Získejte referenci na snímek podle jeho indexu.
3. Přidejte obdélník `AutoShape`. 
4. Vytvořte obrázek.
5. Nastavte typ výplně tvaru.
6. Nastavte režim výplně obrázkem tvaru.
7. Přidejte nastavený obrázek k výplni tvaru.
8. Určete posuny obrázku od odpovídajícího okraje ohraničujícího rámečku tvaru.
9. Uložte upravenou prezentaci jako soubor PPTX.

Tento C++ kód demonstruje proces, ve kterém je použita vlastnost StretchOff:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto ppImage = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
auto slide = pres->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 400.0f, 400.0f, ppImage);

// Nastaví obrázek natažený z každé strany v těle tvaru
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_PictureFillMode(PictureFillMode::Stretch);
pictureFormat->set_StretchOffsetLeft(24.0f);
pictureFormat->set_StretchOffsetRight(24.0f);
pictureFormat->set_StretchOffsetTop(24.0f);
pictureFormat->set_StretchOffsetBottom(24.0f);

pres->Save(u"imageStretch.pptx", SaveFormat::Pptx);
```

## **Často kladené dotazy**

**Jak zjistím, které formáty obrázků jsou podporovány pro PictureFrame?**

Aspose.Slides podporuje jak rastrové obrázky (PNG, JPEG, BMP, GIF atd.), tak vektorové obrázky (například SVG) prostřednictvím objektu obrázku přiřazeného k [PictureFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/pictureframe/). Seznam podporovaných formátů obecně překrývá schopnosti enginu pro konverzi snímků a obrázků.

**Jaký dopad má přidání desítek velkých obrázků na velikost a výkon PPTX?**

Vkládání velkých obrázků zvyšuje velikost souboru a spotřebu paměti; propojení obrázků pomáhá udržet velikost prezentace nízkou, ale vyžaduje, aby externí soubory zůstaly přístupné. Aspose.Slides umožňuje přidávat obrázky jako odkazy k redukci velikosti souboru.

**Jak mohu zamknout objekt obrázku před nechtěným přesouváním/změnou velikosti?**

Použijte [zámky tvarů](https://reference.aspose.com/slides/cs/cpp/aspose.slides/pictureframe/get_pictureframelock/) pro [PictureFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/pictureframe/) (například zakázání přesunu nebo změny velikosti). Mechanismus zamykání je popsán pro tvary v samostatném [článku o ochraně](/slides/cs/cpp/applying-protection-to-presentation/) a je podporován pro různé typy tvarů, včetně [PictureFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/pictureframe/).

**Zůstane vektorová věrnost SVG zachována při exportu prezentace do PDF/obrázků?**

Aspose.Slides umožňuje extrahovat SVG z [PictureFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/pictureframe/) jako původní vektor. Při [exportu do PDF](/slides/cs/cpp/convert-powerpoint-to-pdf/) nebo [rastrovatých formátů](/slides/cs/cpp/convert-powerpoint-to-png/) může být výsledek rasterizován v závislosti na nastavení exportu; fakt, že originální SVG je uložen jako vektor, je potvrzen chováním extrakce.