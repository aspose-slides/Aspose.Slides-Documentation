---
title: Spravujte efekty transformace obrázku v prezentacích s C++
linktitle: Efekty transformace obrázku
type: docs
weight: 11
url: /cs/cpp/image-transform-effects/
keywords:
- transformace obrázku
- efekt obrázku
- jas
- kontrast
- stupně šedi
- duotón
- tónování
- HSL
- náhrada barvy
- rozostření
- průhlednost
- alfa efekt
- řetězec efektů
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Použijte, řaďte, kontrolujte, odstraňujte a ověřujte efekty transformace obrázku pro rámečky obrázků s Aspose.Slides pro C++."
---
## **Přehled**

Aspose.Slides představuje úpravy obrázku jako uspořádanou kolekci operací transformace obrazu. Pro rámeček obrázku začněte s rámcovým [ISlidesPicture](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/) a přistupte k [ISlidesPicture::get_ImageTransform](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/get_imagetransform/). Vrácená [IImageTransformOperationCollection](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/) vám umožní přidávat, vyjmenovávat, kontrolovat, odstraňovat a vymazávat efekty, aniž byste přepisovali původní bajty obrázku.

Tento článek ukazuje kompletní postup pro jas a kontrast, transformace barev, rozostření, průhlednost, řazené řetězce efektů, výpočetní hodnoty, odstraňování a ověření PPTX při zpětném načtení.

## **Pochopení vlastnictví efektů a opětovného použití obrázku**

Obrazový zdroj a obrázek, který jej zobrazuje, jsou různé objekty:

- [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) ukládá nebo odkazuje na zdrojová data obrázku vlastněná prezentací.
- [ISlidesPicture](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/) patří k výplni obrázku a odkazuje na obrazový zdroj, zatímco uchovává kolekci transformací obrazu.
- [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/) je tvar snímku, který vlastní příslušnou výplň obrázku, geometrii, nastavení ořezu a další formátování na úrovni rámce.

Proto operace transformace obrazu nemění bajty v [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/). Když je stejný `IPPImage` předán metodě [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addpictureframe/) více než jednou, každý nový rámeček obrázku získá svůj vlastní `ISlidesPicture` a vlastní kolekci transformací. Aplikace stupně šedi na jeden rámec neovlivní ostatní rámečky, i když všechny používají stejný vložený obrazový zdroj.

Stejný model `ISlidesPicture::get_ImageTransform` používají i jiné výplně obrázku, například tvar nebo pozadí snímku. Níže uvedené příklady se soustředí na rámečky obrázku.

## **Používejte platné rozsahy parametrů a jednotky**

Ukázané metody používají následující logické rozsahy a jednotky. Držte se těchto rozsahů, i když konkrétní verze knihovny okamžitě neodmítnou každou hodnotu mimo rozsah; cílový formát prezentace může během uložení nebo při otevření souboru v PowerPointu normalizovat, vynechat nebo odmítnout neplatná data.

| Operace | Parametry | Platný rozsah a jednotka |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` až `100`, procenta; `0` ponechává komponentu nezměněnou. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | Žádné | Žádné číselné parametry. Alfa zůstává beze změny. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Dvě barvy pro tmavé a světlé pixely. Kanály RGB a alfa v `System::Drawing::Color` používají hodnoty `0` až `255`. |
| [AddTintEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Hue je od `0` (včetně) do `360` (vyloučeno) stupňů; amount je `-100` až `100`, procenta. |
| [AddHSLEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Hue je od `0` (včetně) do `360` (vyloučeno) stupňů; saturation a luminance jsou `-100` až `100`, procenta. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | Náhradní barva používá kanálové hodnoty od `0` do `255`. Existující alfa hodnoty zůstávají beze změny. |
| [AddBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Poloměr je nezáporný a měří se v bodech; `grow` určuje, zda rozmazaný obsah může přesahovat původní hranice. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Nezáporné procento. Použijte `0` až `100` pro běžné škálování neprůhlednosti: `0` je zcela průhledné a `100` zachovává existující alfu. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` až `100`, procento neprůhlednosti. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` až `100`, procentní alfa práh. Hodnoty pod prahem se stanou průhlednými; hodnoty na prahu nebo nad ním se stanou neprůhlednými. |

U pevné modulace alfy jsou průhlednost a neprůhlednost komplementární. Například 35 % průhlednosti odpovídá alfu modulace 65 %.

## **Použít jas a kontrast**

[IImageTransformOperationCollection::AddBrightnessContrastEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) vrací operaci [IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/). Její skalární nastavení jsou zadána při vytvoření operace. Metoda `IBrightnessContrast::GetEffective` vrací vypočtené hodnoty jen ke čtení, které lze prozkoumat nebo zaznamenat.

Následující příklad zvýší jas o 15 % a kontrast o 20 %, pak zobrazí náhled bez úpravy vloženého obrázku:

```cpp
#include <DOM/Effects/IBrightnessContrast.h>
#include <DOM/Effects/IBrightnessContrastEffectiveData.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 50.0f, 400.0f, 260.0f, image);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
auto brightnessContrast = imageTransform->AddBrightnessContrastEffect(15.0f, 20.0f);

auto effectiveValues = brightnessContrast->GetEffective();
Console::WriteLine(u"Brightness: {0}%", effectiveValues->get_Brightness());
Console::WriteLine(u"Contrast: {0}%", effectiveValues->get_Contrast());

auto preview = slide->GetImage();
preview->Save(u"brightness-contrast-preview.png", ImageFormat::Png);

presentation->Dispose();
```

[BrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/brightnesscontrast/) je rozšíření efektu obrázku Office 2010 a není tak přenosné jako standardní efekt luminance DrawingML. Když musí zůstat jas a kontrast po zpětném průchodu PPTX editovatelné, použijte [IImageTransformOperationCollection::AddLuminanceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) a po opětovném otevření souboru výsledek ověřte. Část o omezeních formátu toto rozlišení podrobněji vysvětluje.

## **Použít transformace barev**

Barevné efekty lze aplikovat nezávisle na různých rámečcích obrázku, které používají stejný obrazový zdroj. Následující příklad vytvoří pět rámců a aplikuje stupně šedi, duotón, tónování, úpravu HSL a nahrazení barvy.

[IDuotone](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iduotone/) obsahuje dva samostatně editovatelné barevné parametry: `get_Color1` mapuje tmavé pixely, zatímco `get_Color2` mapuje světlé pixely. To z něj dělá užitečný příklad efektu, jehož nastavení jsou složitější než jediná skalární hodnota.

```cpp
#include <DOM/Effects/IColorReplace.h>
#include <DOM/Effects/IDuotone.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IColorFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto grayFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 180.0f, 120.0f, image);
grayFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddGrayScaleEffect();

auto duotoneFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 220.0f, 20.0f, 180.0f, 120.0f, image);
auto duotone = duotoneFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddDuotoneEffect();
duotone->get_Color1()->set_Color(Color::get_Navy());
duotone->get_Color2()->set_Color(Color::get_Gold());

auto tintFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 420.0f, 20.0f, 180.0f, 120.0f, image);
tintFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddTintEffect(210.0f, 35.0f);

auto hslFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 120.0f, 170.0f, 180.0f, 120.0f, image);
hslFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddHSLEffect(30.0f, 20.0f, -10.0f);

auto replacementFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 320.0f, 170.0f, 180.0f, 120.0f, image);
auto colorReplacement = replacementFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddColorReplaceEffect();
colorReplacement->get_Color()->set_Color(Color::get_CornflowerBlue());

presentation->Save(u"color-transformations.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

[AddColorReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) nahrazuje barvu každého pixelu jednou pevnou barvou při zachování alfy. Liší se od [AddColorChangeEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/), který mapuje jednu zdrojovou barvu na jinou a odhaluje oba formáty barvy zdroje i cíle.

### **Použít prahování luminance**

Prahování luminance může usnadnit odlišení slabých značek na naskenované stránce od pozadí. [AddGrayScaleEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) zachovává střední odstíny šedi. [AddBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbileveleffect/) mapuje luminanci na černou nebo bílou, zatímco [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) aplikuje práh na neprůhlednost.

Prahování luminance se pohybuje od 0 % do 100 %, včetně. Pixely pod prahem se stanou černými. Pixely na prahu nebo nad ním se stanou bílými. Zvyšování prahu převádí více odstínů na černou, protože více z nich spadá pod limit.

Stáhněte [grayscale-swatches.png](grayscale-swatches.png) do pracovního adresáře. Každý popisek udává původní úroveň šedi v rozsahu 0 až 255. Příklad umístí originál vedle dvou kopií a uloží práh každé kopie do prezentace.

```cpp
#include <DOM/Effects/IBiLevel.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 150, SlideSizeScaleType::DoNotScale);
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto imageData = File::ReadAllBytes(u"grayscale-swatches.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto addFrame = [&](float x, const String& caption)
{
    auto label = shapes->AddAutoShape(ShapeType::Rectangle, x, 12, 216, 36);
    label->get_TextFrame()->set_Text(caption);
    return shapes->AddPictureFrame(ShapeType::Rectangle, x, 60, 216, 72, image);
};

addFrame(12, u"Original");

auto lowThreshold = addFrame(252, u"Threshold 20%");
lowThreshold->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddBiLevelEffect(20.0f);

auto highThreshold = addFrame(492, u"Threshold 60%");
highThreshold->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddBiLevelEffect(60.0f);

presentation->Save(u"luminance-threshold.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Otevřete výstupní prezentaci v PowerPointu a porovnejte tři rámečky. Šablona označená 96 má přibližně 38 % luminance (96 z 255). Při prahu 20 % se změní na bílou a při prahu 60 % na černou.

![Původní šedé vzorníky vedle černobílých výsledků při prahování luminance 20 % a 60 %](luminance-threshold.png)

## **Přidat rozostření, průhlednost a alfa efekty**

[AddBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) ovlivňuje všechny barevné kanály, včetně alfy. Nastavte `grow` na `true`, když může rozmazaná hrana přesáhnout původní hranice obrázku.

Pro jednotnou průhlednost použijte [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/). Násobí každou existující alfu, takže částečně průhledné pixely zůstávají proporcionálně odlišné. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) naopak přiřadí jednu alfu všem pixelům. [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) převádí alfu na dvě úrovně na základě prahu.

```cpp
#include <DOM/Effects/IAlphaBiLevel.h>
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto blurredFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 200.0f, 140.0f, image);
auto blur = blurredFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddBlurEffect(4.5, true);
blur->set_Radius(5.0);

auto transparentFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 240.0f, 20.0f, 200.0f, 140.0f, image);
auto alphaModulate = transparentFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddAlphaModulateFixedEffect(65.0f);
alphaModulate->set_Amount(60.0f);

auto uniformAlphaFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 180.0f, 200.0f, 140.0f, image);
uniformAlphaFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddAlphaReplaceEffect(55.0f);

auto binaryAlphaFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 240.0f, 180.0f, 200.0f, 140.0f, image);
auto binaryAlphaTransform = binaryAlphaFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
auto alphaBiLevel = binaryAlphaTransform->AddAlphaBiLevelEffect(50.0f);
alphaBiLevel->set_Threshold(45.0f);
binaryAlphaTransform->AddAlphaInverseEffect();

presentation->Save(u"blur-and-alpha-effects.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Další alfa operace bez parametrů zahrnují [AddAlphaCeilingEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/), který nastaví každou nenulovou alfu na plně neprůhlednou; [AddAlphaFloorEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/), který nastaví každou alfu pod 100 % na plně průhlednou; a [AddAlphaInverseEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/), který mění alfu na `100% - alpha`.

## **Sestrojit řazený řetězec efektů**

Každá metoda `Add...Effect` připojí novou operaci na konec kolekce. Vykreslovač používá kolekci jako uspořádaný pipeline: výstup operace 0 se stane vstupem operace 1 a tak dále. V důsledku toho může stejná sada operací v jiném pořadí vytvořit odlišný obrázek.

Například stupně šedi následované tónováním nejprve odstraní chromatické informace a pak přebarví výsledek luminance. Tónování následované stupněm šedi odstraní tónování znovu. Podobně může nahrazení alfy přepsat alfa hodnoty vypočtené dřívějšími operacemi, zatímco modulace alfy zachová jejich relativní rozdíly.

Níže uvedený příklad vytvoří řetězec se čtyřmi operacemi, uloží jej jako PPTX, otevře prezentaci znovu, zkontroluje typy operací i jejich pořadí a vykreslí znovu otevřený výsledek:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IGrayScale.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ITint.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 50.0f, 400.0f, 260.0f, image);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
imageTransform->AddGrayScaleEffect();
imageTransform->AddTintEffect(220.0f, 25.0f);
imageTransform->AddBlurEffect(2.5, false);
imageTransform->AddAlphaModulateFixedEffect(80.0f);

presentation->Save(u"image-transform-chain.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopenedPresentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
auto reopenedShape = reopenedPresentation->get_Slide(0)->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(reopenedShape))
{
    auto reopenedFrame = ExplicitCast<IPictureFrame>(reopenedShape);
    auto reopenedTransform = reopenedFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
    auto orderIsPreserved = reopenedTransform->get_Count() == 4 && 
            ObjectExt::Is<IGrayScale>(reopenedTransform->idx_get(0)) && 
            ObjectExt::Is<ITint>(reopenedTransform->idx_get(1)) && 
            ObjectExt::Is<IBlur>(reopenedTransform->idx_get(2)) && 
            ObjectExt::Is<IAlphaModulateFixed>(reopenedTransform->idx_get(3));
    Console::WriteLine(orderIsPreserved ? u"The effect chain was preserved." : u"The effect chain changed during the round trip.");

    auto renderedSlide = reopenedPresentation->get_Slide(0)->GetImage();
    renderedSlide->Save(u"reopened-effect-chain.png", ImageFormat::Png);
}
else
{
    Console::WriteLine(u"The reopened shape is not a picture frame.");
}

reopenedPresentation->Dispose();
```

Kolekce neukládá kompatibilitní matici, která by omezovala barvu, alfu a rozostření na samostatné řetězce. Lze je kombinovat, ale kombinace nejsou vždy užitečné. Pevná náhrada barvy odstraní RGB variaci vytvořenou předchozími barevnými efekty; stupně šedi po duotónu odstraní dvě vybrané barvy; a efekty alfa strop, podlah, náhrada nebo dvojúrovňové mohou zahodit alfa detaily vytvořené dříve. Sestavte řetězec podle požadované posloupnosti zpracování pixelů místo toho, aby se položky považovaly za neuspořádané formátovací značky.


<!-- visual-explanation:image-transform-effects:start -->
[![Stejný obrázek prochází nejprve stupněm šedi a potom tónováním a naopak. Dvě výsledné stupně šedi mají odlišné tóny.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*V tomto ilustračním rendru Aspose.Slides for .NET 26.11 je 220° tónování při 25 % ponechává stupně šedi beze změny. Použití stejného tónování před stupněm šedi vytváří odlišné tóny.*
<!-- visual-explanation:image-transform-effects:end -->

## **Prozkoumat editovatelné a výpočetní hodnoty**

Editovatelná operace je objekt uložený v `ISlidesPicture::get_ImageTransform`. V závislosti na efektu může přímo odhalovat zapisovatelné členy. Například [IBlur](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iblur/) odhaluje `set_Radius` a `set_Grow`, [IAlphaModulateFixed](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphamodulatefixed/) odhaluje `set_Amount` a [IAlphaBiLevel](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphabilevel/) odhaluje `set_Threshold`. Barevné efekty jako [IDuotone](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iduotone/) odhalují mutable objekty [IColorFormat](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/).

Některé rozhraní operací, včetně [IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/cpp/aspose.slides.effects/itint/) a [IAlphaReplace](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphareplace/), neodhalují své vytvořené skaláry jako zapisovatelné vlastnosti. Pro změnu těchto nastavení odstraňte operaci a přidejte novou na požadované pozici.

Výpočetní data vrácená metodou `GetEffective()` jsou vypočtená a jen ke čtení. Jsou užitečná pro rozluštění barev závislých na motivu a čtení normalizovaných hodnot, které vykreslovač používá, ale nejsou dalším editovacím povrchem. Následující příklad vyjmenuje řetězec a prozkoumá výpočetní hodnoty několika běžných operací:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IAlphaModulateFixedEffectiveData.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IBlurEffectiveData.h>
#include <DOM/Effects/IBrightnessContrast.h>
#include <DOM/Effects/IBrightnessContrastEffectiveData.h>
#include <DOM/Effects/IDuotone.h>
#include <DOM/Effects/IDuotoneEffectiveData.h>
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

auto presentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
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

    for (auto&& operation : imageTransform)
    {
        if (ObjectExt::Is<IBrightnessContrast>(operation))
        {
            auto brightnessContrast = ExplicitCast<IBrightnessContrast>(operation);
            auto data = brightnessContrast->GetEffective();
            Console::WriteLine(u"Brightness: {0}; contrast: {1}", data->get_Brightness(), data->get_Contrast());
        }
        else if (ObjectExt::Is<ILuminance>(operation))
        {
            auto luminance = ExplicitCast<ILuminance>(operation);
            auto data = luminance->GetEffective();
            Console::WriteLine(u"Brightness: {0}; contrast: {1}", data->get_Brightness(), data->get_Contrast());
        }
        else if (ObjectExt::Is<IDuotone>(operation))
        {
            auto duotone = ExplicitCast<IDuotone>(operation);
            auto data = duotone->GetEffective();
            Console::WriteLine(u"Dark color: {0}; light color: {1}", data->get_Color1(), data->get_Color2());
        }
        else if (ObjectExt::Is<IBlur>(operation))
        {
            auto blur = ExplicitCast<IBlur>(operation);
            auto data = blur->GetEffective();
            Console::WriteLine(u"Blur radius: {0} pt", data->get_Radius());
        }
        else if (ObjectExt::Is<IAlphaModulateFixed>(operation))
        {
            auto alphaModulate = ExplicitCast<IAlphaModulateFixed>(operation);
            auto data = alphaModulate->GetEffective();
            Console::WriteLine(u"Alpha amount: {0}%", data->get_Amount());
        }
    }
}

presentation->Dispose();
```

Efekty bez parametrů, jako stupně šedi, alfa strop či alfa inverze, stále mají objekt výpočetních dat, ale neexistují žádná skalární nastavení k vytištění. Jejich existence a pozice v kolekci jsou důležité informace.

## **Odstranit nebo vyčistit transformace obrazu**

Použijte [IImageTransformOperationCollection::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/removeat/) k odebrání jedné operace podle indexu. Protože se indexy po odebrání posunou, nejprve vyhledejte cílovou operaci a poté ji po vyjmenování odeberte. Metodou `Clear()` odeberete celý řetězec.

```cpp
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
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
    auto blurIndex = -1;

    for (auto index = 0; index < imageTransform->get_Count(); ++index)
    {
        if (ObjectExt::Is<IBlur>(imageTransform->idx_get(index)))
        {
            blurIndex = index;
            break;
        }
    }

    if (blurIndex >= 0)
    {
        imageTransform->RemoveAt(blurIndex);
        Console::WriteLine(u"The blur operation was removed.");
    }

    imageTransform->Clear();
    Console::WriteLine(u"Remaining operations: {0}", imageTransform->get_Count());
    presentation->Save(u"image-transforms-cleared.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

Odstranění nebo vyčištění transformací mění jen formátování obrázku. Neodstraní, nekomprimuje ani jinak neovlivní znovu použitý zdroj [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/).

## **Zvážit formáty prezentací a cílové exporty**

Transformace obrazu vznikají v DrawingML, takže PPTX je preferovaný editovatelný formát pro řetězce efektů. I v PPTX však ne každá operace má úplnou přenositelnost:

- Standardní operace DrawingML, jako luminance, stupně šedi, duotón, tónování, HSL, rozostření a běžné alfa operace, mají největší šanci přežít zpětný průchod PPTX. Vždy po vygenerování souboru otevřete jeho kopii a zkontrolujte kolekci, pokud je zachování požadováno.
- [BrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/brightnesscontrast/) je rozšíření Office 2010, nikoli standardní operace luminance DrawingML. Lze jej použít pro renderování v paměti, ale není zaručeno, že po uložení a opětovném otevření PPTX zůstane editovatelný [IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/). Upřednostněte [AddLuminanceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) pro trvalé úpravy jasu a kontrastu.
- Binární formát PPT předchází úplnému modelu efektů DrawingML. Uložení do PPT může vynechat nepodporované operace, zkrátit řetězec na podporovanou podmnožinu nebo aproximovat vzhled. Nepoužívejte PPT jako ověřovací formát pro složitý editovatelný řetězec.
- Renderování do PNG, JPEG, TIFF, PDF, SVG, HTML nebo jiných vizuálních výstupů aplikuje podporovaný řetězec na vykreslený vzhled. Tyto výstupy neobsahují editovatelnou `IImageTransformOperationCollection`; rastrové formáty výsledek zploští do pixelů a exporty dokumentů nebo vektorů ukládají vlastní reprezentaci renderování.
- Efekty nečiní odkazovaný obrázek samostatně uzavřeným. Renderování odkazovaného obrázku stále závisí na tom, že odkazovaný zdroj je dostupný při načítání prezentace.

Různí spotřebitelé prezentací mohou vykreslovat okrajové případy odlišně, zvláště když jsou kombinovány několik alfa nebo barevných kvantizačních operací. Pro kritické výstupy testujte jak editovatelný zpětný průchod, tak konečný exportní formát se stejnou verzí Aspose.Slides používanou ve výrobě.

## **Často kladené otázky**

**Mění efekty transformace obrazu vložená data obrázku?**

Ne. Operace patří k `ISlidesPicture` použitému ve výplni obrázku. Podkladové bajty `IPPImage` zůstávají beze změny.

**Budou dva rámečky obrázku, které používají stejný obrázek, sdílet své efekty?**

Ne. Opakované použití `IPPImage` eliminuje duplicitní data obrázku, ale každý rámeček obrázku má obvykle vlastní `ISlidesPicture` a vlastní kolekci transformací obrazu.

**Lze kombinovat barevné, rozostřovací a alfa efekty?**

Ano. Kolekce je přijme v jednom uspořádaném řetězci. Zvažte, jak každá operace ovlivňuje výstup předchozí, protože operace nahrazení a prahování mohou zahodit dřívější barevné nebo alfa detaily.

**Proč jsou výpočetní hodnoty jen ke čtení?**

Výpočetní data představují vypočtené hodnoty používané při renderování, včetně rozluštěných barev. Editujte operaci uloženou v kolekci transformací, kde existují zapisovatelné členy; jinak ji odstraňte a přidejte novou s novými parametry vytvoření.

**Který formát použít k zachování řetězce transformací?**

Použijte PPTX a ověřte soubor opětovným otevřením. Starší PPT nemůže představit celý model efektů DrawingML a výstupní exportní formáty zachovávají jen vzhled, nikoli editovatelné transformace.