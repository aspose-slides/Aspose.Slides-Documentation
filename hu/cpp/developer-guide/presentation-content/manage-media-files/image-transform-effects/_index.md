---
title: Képtranszformációs effektusok kezelése prezentációkban C++-ban
linktitle: Képtranszformációs effektusok
type: docs
weight: 11
url: /hu/cpp/image-transform-effects/
keywords:
- képtranszformáció
- képeffektus
- fényerő
- kontraszt
- szürkeárnyalat
- kétárnyalatos
- színárnyalat
- HSL
- színhelyettesítés
- elmosás
- átlátszóság
- alfaeffektus
- effektlánc
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Alkalmazzon, láncoljon, ellenőrizzen, távolítson el és ellenőrizze a képtranszformációs effektusokat képkockákhoz az Aspose.Slides for C++ segítségével."
---
## **Áttekintés**

Az Aspose.Slides a képek módosításait egy rendezett gyűjteményként kezeli, amely képektől függő transzformációs műveleteket tartalmaz. Képkeret esetén a keret [ISlidesPicture](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/) segítségével kezdjünk, és érjük el a [ISlidesPicture::get_ImageTransform](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/get_imagetransform/) metódust. A visszakapott [IImageTransformOperationCollection](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/) lehetővé teszi műveletek hozzáadását, felsorolását, ellenőrzését, eltávolítását és törlését anélkül, hogy az eredeti kép bájtjait újraírná.

Ez a cikk egy komplett munkafolyamatot mutat be a fényerő és kontraszt, színtranszformációk, elmosás, átlátszóság, rendezett effektláncok, effektív értékek, eltávolítás és PPTX körutazás ellenőrzése témakörökben.

## **Értse meg az effekt tulajdonjogát és a képek újrafelhasználását**

A képernyőforrás és a megjelenítő kép különböző objektumok:

- [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) tárolja vagy hivatkozik a bemutató által birtokolt forráskép adataira.
- [ISlidesPicture](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/) egy képkitöltéshez tartozik, és egy képernyőforrást hivatkozik, miközben a képtranszformációk gyűjteményét tárolja.
- [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/) a dián lévő alakzat, amely a megfelelő képkitöltést, geometriát, vágási beállításokat és egyéb keretszintű formázásokat birtokolja.

Ezért a képtranszformációs műveletek nem módosítják a [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) bájtjait. Amikor ugyanazt az `IPPImage`-et több alkalommal adjuk át a [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addpictureframe/) metódusnak, minden új képkeret saját `ISlidesPicture`-et és saját transzformációs gyűjteményt kap. A szürkeárnyalatos átalakítás egy keretre való alkalmazása nem teszi a többi keretet szürkeárnyalatosra, még ha mindegyik ugyanazt a beágyazott képernyőforrást használja is.

Ugyanezt a `ISlidesPicture::get_ImageTransform` modellt más képkitöltések, például alakzat vagy diaháttér is használja. Az alábbi példák a képkeretekre koncentrálnak.

## **Használjon érvényes paramétertartományokat és egységeket**

A bemutatott módszerek a következő szemantikai tartományokat és egységeket alkalmazzák. Tartsa a értékeket ezen tartományokban még akkor is, ha egy adott könyvtárverzió nem utasítja el azonnal a hatótávolságon kívüli értékeket; a célprezentáció formátuma normalizálhat, elhagyhat vagy visszautasíthat érvénytelen adatokat a mentéskor vagy a PowerPoint fájl megnyitásakor.

| Művelet | Paraméterek | Érvényes tartomány és egység |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` és `100` között, százalék; `0` változatlan komponens. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | Nincs | Nincs numerikus paraméter. Az alfa változatlan marad. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Két szín a sötét és a világos pixelekhez. Az `System::Drawing::Color` RGB és alfa csatornái `0`‑tól `255`‑ig terjednek. |
| [AddTintEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | `hue` `0` (inkl.) és `360` (exkl.) fok között; `amount` `-100` és `100` között, százalék. |
| [AddHSLEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | `hue` `0`‑tól `360`‑ig fokban; `saturation` és `luminance` `-100`‑tól `100`‑ig, százalék. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | A helyettesítő szín csatornaértékei `0`‑tól `255`‑ig. A meglévő alfa értékek változatlanok. |
| [AddBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | `radius` nemnegatív, pontban mérve; `grow` határozza meg, hogy az elmosódott tartalom kiterjeszthető‑e az eredeti határokon kívülre. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Nemnegatív százalék. A szokásos átlátszóság skálázáshoz használja a `0`‑tól `100`‑ig terjedő értékeket: `0` teljesen átlátszó, `100` megőrzi a meglévő alfat. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0`‑tól `100`‑ig, százalékos átlátszóság. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0`‑tól `100`‑ig, százalékos alfa küszöb. Az alatta lévő értékek átlátszóvá válnak; a küszöbön vagy felette lévők átlátszatlanok. |

A fix alfa moduláció esetén az átlátszóság és az opacitás kiegészítik egymást. Például a 35 % átlátszóság egy 65 % alfa-modulációs értéknek felel meg.

## **Fényerő és kontraszt alkalmazása**

[IImageTransformOperationCollection::AddBrightnessContrastEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) egy [IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/) műveletet ad vissza. Skaláris beállításait a művelet létrehozásakor adjuk meg. Az `IBrightnessContrast::GetEffective` metódus számított, csak‑olvasható értékeket ad, amelyeket ellenőrizhet vagy naplózhat.

Az alábbi példában a fényerőt 15 %-kal, a kontrasztot pedig 20 %-kal növeljük, majd előnézetet renderelünk anélkül, hogy módosítanánk a beágyazott képet:

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

[BrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/brightnesscontrast/) egy Office 2010 kép‑effekt kiterjesztés, amely kevésbé hordozható, mint a szabványos DrawingML luminancia‑effekt. Amikor a fényerő és kontraszt szerkeszthető kell maradjon egy PPTX körutazás után, használja a [IImageTransformOperationCollection::AddLuminanceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) metódust, és ellenőrizze az eredményt a fájl újranyitása után. A formátumkorlátozások részben részletesebben ismertetik ezt a különbséget.

## **Színtranszformációk alkalmazása**

A szín‑effekteket függetlenül alkalmazhatja különböző képkeretekre, amelyek ugyanazt a képforrást használják. Az alábbi példa öt keretet hoz létre, és szürkeárnyalat, duotone, színárnyalat, HSL‑korrekció és színhelyettesítés effektusokat alkalmaz.

[IDuotone](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iduotone/) két önállóan szerkeszthető színparamétert tartalmaz: a `get_Color1` a sötét pixeleket, a `get_Color2` a világos pixeleket térképezi. Ez egy jó példa arra az effektusra, amelynek beállításai bonyolultabbak egyetlen skalárértéknél.

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

[AddColorReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) minden pixel színét egy állandó színre cseréli, miközben megőrzi az alfat. Ez különbözik a [AddColorChangeEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/)‑tól, amely egy forrás‑színt egy másikra képezi át, és mind a forrás, mind a cél színformátumát ki is téri.

### **Luminancia‑küszöb alkalmazása**

A luminancia‑küszöb segíthet a beolvasott oldalakon lévő halvány jeleket elkülöníteni a háttértől. A [AddGrayScaleEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) megőrzi a köztes szürkeárnyalatokat. A [AddBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbileveleffect/) a luminanciát feketére vagy fehérre képezi, míg a [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) az átlátszóságra alkalmaz küszöböt.

A luminancia‑küszöb 0 % és 100 % között terjed, mindkét határérték beleértve. A küszöb alatti pixelek feketék, a küszövnél vagy fölötte lévők pedig fehérek. A küszöb emelése több árnyalatot tesz feketévé, mert több pixel esik a határ alá.

Töltse le a [grayscale-swatches.png](grayscale-swatches.png) fájlt a munkakönyvtárba. Minden címke az eredeti szürke szintet mutatja 0‑tól 255‑ig terjedő skálán. A példa az eredetit két másolattal helyezi el, és minden másolat küszöbét a prezentációba menti.

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

Nyissa meg a kimeneti prezentációt a PowerPointban a három keret összehasonlításához. A 96‑os mintát körülbelül 38 % luminanciával (96/255) jelöli. 20 % küszöbön fehér, 60 % küszöbön pedig fekete lesz.

![Eredeti szürkeárnyalatos minták a fekete‑fehér eredményekkel a 20 % és 60 % luminancia‑küszöbök mellett](luminance-threshold.png)

## **Elmosás, átlátszóság és alfa‑effektek hozzáadása**

[AddBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) az összes színcsatornát, köztük az alfat is érinti. Állítsa a `grow`‑t `true`‑ra, ha az elmosódott él túlnyúlhat az eredeti kép határain.

Egységes átlátszóság esetén használja a [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/)‑et. Ez minden meglévő alfa‑értéket szorzásával módosít, így a részben átlátszó pixelek arányosan eltérnek. A [AddAlphaReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) egyetlen alfa‑értéket rendel minden pixelhez. A [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) a küszöb alapján két alfa‑szintre konvertál.

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

Más, paraméter nélküli alfa‑műveletek közé tartozik a [AddAlphaCeilingEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/), amely minden nem‑nulla alfat teljesen átlátszatlanná teszi; a [AddAlphaFloorEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/), amely minden 100 % alatti alfat teljesen átlátszóvá alakít; valamint a [AddAlphaInverseEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/), amely az alfat `100 % - alfa`‑ra változtatja.

## **Rendezett effektlánc felépítése**

Minden `Add...Effect` metódus egy új műveletet fűz a gyűjtemény végéhez. A renderelő a gyűjteményt rendezett csővezetéknek tekinti: a 0‑ás művelet kimenete az 1‑es bemenete, stb. Ennek következtében a műveletek különböző sorrendje eltérő képet eredményezhet.

Például a szürkeárnyalat előbb, majd a színárnyalat után először eltávolítja a kromatikus információt, majd a luminancia‑eredményt színezi át. A színárnyalat előbb, majd a szürkeárnyalat után a színárnyalat újbóli eltávolításához vezet. Hasonlóképpen az alfa‑helyettesítés felülírhatja a korábbi műveletek által kiszámított alfa‑értékeket, míg az alfa‑moduláció megőrzi azok relatív különbségeit.

Az alábbi példában egy négy műveletből álló láncot hozunk létre, PPTX‑ként mentjük, újra megnyitjuk a bemutatót, ellenőrizzük a művelettípusokat és sorrendet, majd a megnyitott eredményt rendereljük:

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

A gyűjtemény nem kényszerít kompatibilitási mátrixot, amely a szín‑, alfa‑ és elmosás‑effekteket külön láncokra korlátozná. Kombinálhatók, de a kombinációk nem mindig hasznosak. Egy fix színhelyettesítés eltávolítja a korábbi szín‑effektek által előállított RGB‑variációt; a szürkeárnyalat duotone után eltávolítja a két kiválasztott színt; az alfa‑ceil, floor, replace vagy bi‑level műveletek eldobhatják a korábban keletkezett alfa‑részleteket. Építse a láncot a kívánt pixel‑feldolgozási sorrend szerint, ne pedig rendezetlen formázási jelzők halmazaként kezelje.

<!-- visual-explanation:image-transform-effects:start -->
[![Ugyanaz a kép először szürkeárnyalatos, majd színárnyalat, illetve fordítva. A két végső szürkeárnyalatos kép eltérő tónusú.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*Ebben a példában az Aspose.Slides for .NET 26.11 renderje mutatja, hogy egy 220°‑es színárnyalat 25 %-nál a szürkeárnyalatos képet változatlanul hagyja. Ugyanaz a színárnyalat a szürkeárnyalat előtt alkalmazva más tónusokat eredményez.*
<!-- visual-explanation:image-transform-effects:end -->

## **Szerkeszthető és effektív értékek megtekintése**

Egy szerkeszthető művelet az `ISlidesPicture::get_ImageTransform`‑ben tárolt objektum. Az effektustól függően közvetlenül elérhetők a módosítható tagok. Például a [IBlur](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iblur/) a `set_Radius`‑t és `set_Grow`‑t teszi közzé, az [IAlphaModulateFixed](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphamodulatefixed/) a `set_Amount`‑t, az [IAlphaBiLevel](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphabilevel/) pedig a `set_Threshold`‑t. A [IDuotone](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iduotone/) szín‑effektjei módosítható [IColorFormat](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/) objektumokat adnak.

Néhány művelet‑interfész, például a [IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/), az [IHSL](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ihsl/), az [ITint](https://reference.aspose.com/slides/cpp/aspose.slides.effects/itint/) és az [IAlphaReplace](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphareplace/) nem teszi közzé a létrehozási skalárokat írható tulajdonságként. Az ilyen beállítások módosításához távolítsa el a műveletet, és adjon hozzá egy újat a kívánt pozícióban.

A `GetEffective()`‑vel visszaadott effektív adat számított és csak‑olvasható. Hasznos a téma‑függő színek feloldásához és a renderelő által használt normalizált értékek olvasásához, de nem egy újabb szerkesztési felület. Az alábbi példa felsorolja a láncot, és több gyakori művelethez is megvizsgálja az effektív értékeket:

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

A paraméter nélküli effektusok, mint a szürkeárnyalat, alfa‑ceil vagy alfa‑inverse, szintén rendelkeznek effektív‑adat objektummal, de nincs kiírható skalárbeállításuk. A jelenlétük és pozíciójuk a gyűjteményben a fontos információ.

## **Képtranszformációk eltávolítása vagy törlése**

Használja a [IImageTransformOperationCollection::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/removeat/) metódust egy művelet index szerinti eltávolításához. Mivel az indexek az eltávolítás után eltolódnak, előbb keresse meg a célt, majd a felsorolás után távolítsa el. A `Clear()`‑tel az egész láncot törölheti.

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

A transzformációk eltávolítása vagy törlése csak a képformázást érinti. Nem törli, nem tömöríti újra, és nem módosítja a újrahasznált [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) forrást.

## **Prezentációs formátumok és exportcélok figyelembevétele**

A képtranszformációk a DrawingML‑ből erednek, ezért a PPTX a leginkább szerkeszthető formátum az effektláncokhoz. Még PPTX‑ben sem minden művelet rendelkezik azonos hordozhatósággal:

- A szabványos DrawingML műveletek, mint a luminancia, szürkeárnyalat, duotone, színárnyalat, HSL, elmosás és a gyakori alfa‑operációk, a legnagyobb eséllyel maradnak meg egy PPTX körutazás után. Mindig nyissa meg újra a generált fájlt, és ellenőrizze a gyűjteményt, ha a megőrzés követelmény.
- A [BrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/brightnesscontrast/) egy Office 2010 kiterjesztés, nem a szabványos DrawingML luminancia‑operáció. Memóriabeli renderelésre használható, de nem garantált, hogy a mentés és újranyitás után szerkeszthető [IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/) marad. Tartós fényerő‑ és kontraszt‑állításokhoz részesítse előnyben a [AddLuminanceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/)‑et.
- A bináris PPT formátum a teljes DrawingML effektmodel előtt létezik. PPT‑re mentéskor a nem támogatott műveleteket elhagyhatja, a láncot egy támogatott részhalmazra csökkentheti, vagy közelítheti a megjelenést. Ne használja a PPT‑t ellenőrző formátumként összetett szerkeszthető láncokhoz.
- PNG, JPEG, TIFF, PDF, SVG, HTML vagy más vizuális kimenetek esetén a támogatott lánc a renderelt megjelenésre kerül alkalmazásra. Ezek a kimenetek nem tartalmaznak szerkeszthető `IImageTransformOperationCollection`‑t; a raszteres formátumok az eredményt pixelekre lapítják, a dokumentum‑ vagy vektorgenerálás saját renderelési reprezentációt tárol.
- Az effektusok nem teszik önállóvá a hivatkozott képet. A hivatkozott kép renderelése továbbra is a hivatkozott forrás elérhetőségétől függ a prezentáció betöltésekor.

A különböző prezentációs fogyasztók esetleg eltérően renderelhetnek határeseteket, különösen ha több alfa‑ vagy szín‑kvantálási műveletet kombinálnak. Kritikus kimenet esetén tesztelje mind a szerkeszthető körutazást, mind a végső exportformátumot ugyanazzal az Aspose.Slides verzióval, amely a termelésben használatos.

## **GYIK**

**Módosítják a képtranszformációs effektusok a beágyazott kép adatokat?**

Nem. A műveletek a képkitöltéshez használt `ISlidesPicture`‑hez tartoznak. Az alapul szolgáló `IPPImage` bájtjai változatlanok maradnak.

**Két képkeret, amely ugyanazt a képet használja, megosztja-e az effektusokat?**

Nem. Az `IPPImage` újrafelhasználása megakadályozza a képadat duplikálását, de minden képkeretnek általában saját `ISlidesPicture` és saját képtranszformációs gyűjteménye van.

**Kombinálhatók a szín, elmosás és alfa effektusok?**

Igen. A gyűjtemény egy rendezett láncban fogadja őket. Vegye figyelembe, hogy az egyes műveletek hogyan hatnak az előző kimenetére, mivel a helyettesítő és küszöb‑operációk eldobhatják a korábbi szín‑ vagy alfa‑részleteket.

**Miért csak‑olvashatóak az effektív értékek?**

Az effektív adatok a rendereléshez használt számított értékeket képviselik, beleértve a feloldott színeket is. Szerkessze a transzformációs gyűjteményben tárolt műveletet, ahol írási jogosultságú tagok léteznek; ellenkező esetben távolítsa el, és adjon hozzá egy újat a kívánt létrehozási paraméterekkel.

**Melyik formátumot használjam a transformációs lánc megőrzéséhez?**

Használja a PPTX‑et, és ellenőrizze a fájlt újranyitással. Az örökölt PPT nem képes a teljes DrawingML effektmodellt ábrázolni, míint a renderelt exportformátumok csak a megjelenést, nem pedig a szerkeszthető transzformációs műveleteket őrzik meg.