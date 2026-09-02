---
title: Správa efektů transformace obrázku v prezentacích s C++
linktitle: Efekty transformace obrázku
type: docs
weight: 11
url: /cs/cpp/image-transform-effects/
keywords:
- transformace obrázku
- efekt obrázku
- jas
- kontrast
- odstín šedé
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
description: "Používejte, řetězte, kontrolujte, odstraňujte a ověřujte efekty transformace obrázku pro rámy obrázků s Aspose.Slides pro C++."
---
## **Přehled**

Aspose.Slides představuje úpravy obrázků jako uspořádanou kolekci operací transformace obrázku. Pro objekt picture frame začněte s [ISlidesPicture](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidespicture/) a přistupte k [ISlidesPicture::get_ImageTransform](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidespicture/get_imagetransform/). Vrácená [IImageTransformOperationCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides.effects/iimagetransformoperationcollection/) vám umožní přidávat, procházet, kontrolovat, odstraňovat a vymazávat efekty bez přepisování původních bajtů obrázku.

Tento článek demonstruje kompletní pracovní postup pro nastavení jasu a kontrastu, barevné transformace, rozostření, průhlednost, řazené řetězce efektů, výpočetní hodnoty, odstraňování a ověření PPTX round‑trip.

## **Pochopení vlastnictví efektu a opětovného použití obrázku**

Obrázkový zdroj a obrázek, který jej zobrazuje, jsou různé objekty:

- [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/) uchovává nebo odkazuje na zdrojová data obrázku vlastněná prezentací.
- [ISlidesPicture](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidespicture/) patří výplni obrázku a odkazuje na obrázkový zdroj při zachování kolekce transformací obrázku.
- [IPictureFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipictureframe/) je tvar slidu, který vlastní příslušnou výplň obrázku, geometrii, nastavení ořezu a další formátování na úrovni rámce.

Proto operace transformace obrázku nemodifikují bajty v [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/). Když je stejný `IPPImage` předán [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapecollection/addpictureframe/) vícekrát, každý nový picture frame získá vlastní `ISlidesPicture` a vlastní kolekci transformací. Použití odstínu šedé na jednom rámci neovlivní ostatní rámce, i když všechny používají stejný vložený obrázkový zdroj.

Stejný model `ISlidesPicture::get_ImageTransform` používají i jiné výplně obrázků, například tvar nebo pozadí slidu. Níže uvedené příklady se zaměřují na picture frames.

## **Používejte platné rozsahy parametrů a jednotky**

Ukázané metody používají následující sémantické rozsahy a jednotky. Držte se těchto rozsahů, i když konkrétní verze knihovny okamžitě neodmítne každou hodnotu mimo rozsah; cílový formát prezentace může během uložení nebo při otevření souboru v PowerPointu normalizovat, vynechat nebo odmítnout neplatná data.

| Operace | Parametry | Platný rozsah a jednotka |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` až `100`, procent; `0` ponechá komponentu nezměněnou. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | Žádné | Žádné číselné parametry. Alfa zůstává nezměněna. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Dvě barvy pro tmavé a světlé pixely. Kanály RGB a alfa v `System::Drawing::Color` používají hodnoty `0` až `255`. |
| [AddTintEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Hue je od `0` (včetně) do `360` (exkluzivně), ve stupních; amount je `-100` až `100`, procent. |
| [AddHSLEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Hue je od `0` (včetně) do `360` (exkluzivně), ve stupních; saturation a luminance jsou `-100` až `100`, procent. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | Nahrazující barva používá hodnoty kanálů od `0` do `255`. Existující alfa hodnoty zůstávají nezměněny. |
| [AddBlurEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Poloměr je nezáporný a měří se v bodech; `grow` určuje, zda rozostřený obsah může vystupovat mimo původní hranice. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Nezáporné procento. Použijte `0` až `100` pro obyčejné škálování neprůhlednosti: `0` je plně průhledná a `100` zachovává existující alfu. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` až `100`, procent neprůhlednosti. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` až `100`, procent alfa prahu. Hodnoty pod prahem se stávají průhlednými; hodnoty na nebo nad prahem se stávají neprůhlednými. |

Pro pevnou modulaci alfy jsou průhlednost a neprůhlednost komplementární. Například 35 % průhlednosti odpovídá modulaci alfy ve výši 65 %.

## **Použití jasu a kontrastu**

[IImageTransformOperationCollection::AddBrightnessContrastEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) vrací operaci [IBrightnessContrast](https://reference.aspose.com/slides/cs/cpp/aspose.slides.effects/ibrightnesscontrast/). Její skalární nastavení se předává při vytvoření operace. Metoda `IBrightnessContrast::GetEffective` vrací vypočítané pouze ke čtení hodnoty, které lze prohlédnout nebo zalogovat.

Následující příklad zvýší jas o 15 % a kontrast o 20 %, poté vykreslí náhled bez úpravy vloženého obrázku:

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

[BrightnessContrast](https://reference.aspose.com/slides/cs/cpp/aspose.slides.effects/brightnesscontrast/) je rozšíření Office 2010 pro picture‑effect a není tak přenosné jako standardní efekt luminance v DrawingML. Když je potřeba, aby jas a kontrast zůstaly po PPTX round‑trip editovatelné, použijte [IImageTransformOperationCollection::AddLuminanceEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) a ověřte výsledek po opětovném otevření souboru. Část o omezeních formátu podrobněji vysvětluje tento rozdíl.

## **Použití barevných transformací**

Barevné efekty lze aplikovat nezávisle na různých picture framech, které sdílejí jeden obrázkový zdroj. Následující příklad vytvoří pět rámců a použije odstín šedé, duotone, tint, úpravu HSL a nahrazení barvy.

[IDuotone](https://reference.aspose.com/slides/cs/cpp/aspose.slides.effects/iduotone/) obsahuje dva nezávisle editovatelné barevné parametry: `get_Color1` mapuje tmavé pixely, zatímco `get_Color2` mapuje světlé pixely. To z něj dělá užitečný příklad efektu, jehož nastavení jsou složitější než jednorozměrná skalární hodnota.

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

[AddColorReplaceEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) nahrazuje barvu každého pixelu jednou pevnou barvou při zachování alfy. Liší se od [AddColorChangeEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/), který mapuje jednu zdrojovou barvu na jinou a odhaluje oba formáty zdrojové i cílové barvy.

## **Přidání rozostření, průhlednosti a alfa efektů**

[AddBlurEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) ovlivňuje všechny barevné kanály, včetně alfy. Nastavte `grow` na `true`, když může rozostřený okraj přesáhnout původní hranice obrázku.

Pro jednotnou průhlednost použijte [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/). Násobí každou existující hodnotu alfy, takže částečně průhledné pixely zůstávají proporcionálně odlišné. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) naopak přiřadí jednu alfa hodnotu všem pixelům. [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) převádí alfu na dvě úrovně na základě prahu.

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

Další alfa operace bez parametrů zahrnují [AddAlphaCeilingEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/), který nastaví každou nenulovou alfu na plnou neprůhlednost; [AddAlphaFloorEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/), který nastaví každou alfu pod 100 % na plně průhlednou; a [AddAlphaInverseEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/), který mění alfu na `100% - alpha`.

## **Sestavení uspořádaného řetězce efektů**

Každá metoda `Add...Effect` přidá novou operaci na konec kolekce. Renderer používá kolekci jako uspořádaný pipeline: výstup operace 0 se stává vstupem operace 1 a tak dále. Proto může stejná sada operací v jiném pořadí vytvořit odlišný obrázek.

Například odstín šedé následovaný tintou nejprve odstraní chromatické informace a potom obarví výsledek luminance. Tint následovaná odstínem šedé odstraní tintu zpět. Podobně může nahrazení alfy přepsat alfa hodnoty vypočítané dřívějšími operacemi, zatímco modulace alfy zachová jejich relativní rozdíly.

Následující příklad sestaví řetězec čtyř operací, uloží jej jako PPTX, znovu otevře prezentaci, zkontroluje typy operací i jejich pořadí a vykreslí znovuotevřený výsledek:

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

Kolekce nevnucuje matici kompatibility, která by omezovala barevné, alfa a rozostřovací operace na oddělené řetězce. Lze je kombinovat, ale ne vždy je kombinace užitečná. Pevná náhrada barvy odstraní RGB variaci vytvořenou předchozími barevnými efekty; odstín šedé po duotone odstraní dvě vybrané barvy; a operace alfa‑ceiling, floor, replacement nebo bi‑level mohou zrušit alfa detaily vytvořené dříve. Sestavujte řetězec podle požadované posloupnosti zpracování pixelů, nikoli jako neuspořádanou sadu formátovacích příznaků.

## **Kontrola editovatelných a výpočetních hodnot**

Editovatelná operace je objekt uložený v `ISlidesPicture::get_ImageTransform`. V závislosti na efektu může přímo odhalovat zapisovatelné členy. Například [IBlur](https://reference.aspose.com/slides/cs/cpp/aspose.slides.effects/iblur/) odhaluje `set_Radius` a `set_Grow`, [IAlphaModulateFixed](https://reference.aspose.com/slides/cs/cpp/aspose.slides.effects/ialphamodulatefixed/) odhaluje `set_Amount` a [IAlphaBiLevel](https://reference.aspose.com/slides/cs/cpp/aspose.slides.effects/ialphabilevel/) odhaluje `set_Threshold`. Barevné efekty jako [IDuotone](https://reference.aspose.com/slides/cs/cpp/aspose.slides.effects/iduotone/) odhalují mutovatelné objekty [IColorFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icolorformat/).

Některé rozhraní operací, včetně [IBrightnessContrast](https://reference.aspose.com/slides/cs/cpp/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/cs/cpp/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/cs/cpp/aspose.slides.effects/itint/) a [IAlphaReplace](https://reference.aspose.com/slides/cs/cpp/aspose.slides.effects/ialphareplace/), neodhalují své výchozí skalární parametry jako zapisovatelné vlastnosti. Pro změnu těchto nastavení odstraňte operaci a přidejte náhradu na požadovanou pozici.

Výpočetní data vrácená metodou `GetEffective()` jsou vypočítaná a jen pro čtení. Hodí se pro rozlišení barev závislých na tématu a pro čtení normalizovaných hodnot, které renderer používá, ale nejsou dalším editačním rozhraním. Následující příklad projde řetězec a kontroluje výpočetní hodnoty pro několik běžných operací:

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

Efekty bez parametrů, jako odstín šedé, alfa‑ceiling a alfa‑inverse, mají stále objekt výpočetních dat, ale není co vypisovat jako skalární nastavení. Jejich přítomnost a pozice v kolekci jsou důležité informace.

## **Odstranění nebo vymazání transformací obrázku**

Použijte [IImageTransformOperationCollection::RemoveAt](https://reference.aspose.com/slides/cs/cpp/aspose.slides.effects/iimagetransformoperationcollection/removeat/) pro odebrání jedné operace podle indexu. Protože se indexy po odebrání posunou, nejprve najděte cílovou operaci a pak ji odstraňte po jejím procházení. Použijte `Clear()` k odebrání celého řetězce.

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

Odstranění nebo vymazání transformací mění jen formátování obrázku. Nepřepisuje, nekomprimuje ani jinak nemění opětovně použité zdrojové [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/) .

## **Zvažování formátů prezentací a exportních cílů**

Transformace obrázku vznikají v DrawingML, takže PPTX je preferovaný editovatelný formát pro řetězce efektů. I v PPTX však ne každá operace má stejnou přenositelnost:

- Standardní operace DrawingML jako luminance, odstín šedé, duotone, tint, HSL, rozostření a běžné alfa operace mají největší šanci přežít PPTX round‑trip. Vždy znovu otevřete vygenerovaný soubor a zkontrolujte kolekci, pokud je zachování požadováno.
- [BrightnessContrast](https://reference.aspose.com/slides/cs/cpp/aspose.slides.effects/brightnesscontrast/) je rozšíření Office 2010 místo standardního operace luminance v DrawingML. Lze jej použít pro renderování v paměti, ale není zaručeno, že po uložení a opětovném otevření PPTX zůstane editovatelný [IBrightnessContrast](https://reference.aspose.com/slides/cs/cpp/aspose.slides.effects/ibrightnesscontrast/). Upřednostněte [AddLuminanceEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) pro trvalé nastavení jasu a kontrastu.
- Binární formát PPT předchází kompletnímu modelu efektů DrawingML. Uložení do PPT může vynechat nepodporované operace, snížit řetězec na podporovaný podmnožinu nebo aproximovat vzhled. Nepoužívejte PPT jako ověřovací formát pro složitý editovatelný řetězec.
- Renderování do PNG, JPEG, TIFF, PDF, SVG, HTML nebo jiných vizuálních výstupů aplikuje podporovaný řetězec na výsledný vzhled. Tyto výstupy neobsahují editovatelnou `IImageTransformOperationCollection`; rastrové formáty výsledek zploští do pixelů a dokumentové či vektorové exporty ukládají vlastní reprezentaci renderování.
- Efekty nečiní propojený obrázek samostatným. Renderování propojeného obrázku stále závisí na dostupnosti propojeného zdroje při načítání prezentace.

Různí spotřebitelé prezentací mohou renderovat okrajové případy odlišně, zejména když je kombinováno několik alfa nebo barevných kvantizačních operací. Pro kritické výstupy testujte jak editovatelný round‑trip, tak finální exportní formát se stejnou verzí Aspose.Slides používanou ve výrobě.

## **Často kladené otázky**

**Mění efekty transformace obrázku vložená data obrázku?**

Ne. Operace patří k `ISlidesPicture` používanému výplní obrázku. Podkladové bajty `IPPImage` zůstávají nezměněny.

**Sdílejí dva picture framey, které používají stejný obrázek, své efekty?**

Ne. Opětovné použití `IPPImage` eliminuje duplicitní data obrázku, ale každý picture frame má obvykle svůj vlastní `ISlidesPicture` a kolekci transformací obrázku.

**Lze kombinovat barevné, rozostřovací a alfa efekty?**

Ano. Kolekce je přijme v jednom uspořádaném řetězci. Zvažte, co každá operace dělá s výstupem předchozí, protože operace nahrazení a prahování mohou zrušit dřívější barevné nebo alfa detaily.

**Proč jsou výpočetní hodnoty pouze ke čtení?**

Výpočetní data představují vypočítané hodnoty použité pro renderování, včetně rozlišených barev. Upravit můžete operaci uloženou v kolekci transformací, kde existují zapisovatelné členy; jinak ji odstraňte a přidejte náhradu s novými parametry vytvoření.

**Který formát použít pro zachování řetězce transformací?**

Použijte PPTX a ověřte soubor jeho opětovným otevřením. Starší PPT nedokáže reprezentovat kompletní model efektů DrawingML a výstupní formáty zachovávají pouze vzhled, nikoli editovatelné operace transformace.