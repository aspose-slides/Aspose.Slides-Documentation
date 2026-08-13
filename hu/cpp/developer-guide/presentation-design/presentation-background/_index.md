---
title: Prezentációháttér kezelése C++-ban
linktitle: Dia háttér
type: docs
weight: 20
url: /hu/cpp/presentation-background/
keywords:
- prezentációháttér
- dia háttér
- egyszínű szín
- átmenetes szín
- képes háttér
- háttér átlátszóság
- háttér tulajdonságok
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Tudja meg, hogyan állíthat be dinamikus háttereket PowerPoint és OpenDocument fájlokban az Aspose.Slides for C++ segítségével, kódtippekkel a prezentációk fokozásához."
---
## **Bevezetés**

Az egyszínű színek, átmenetek és képek gyakran használatosak a dia hátterekhez. Beállíthatja a hátteret egy **normál diára** (egyetlen dia) vagy egy **mesterdiára** (egyszerre több diához alkalmazva).

![PowerPoint háttér](powerpoint-background.png)

## **Egyszínű Háttér Beállítása Normál Diára**

Az Aspose.Slides lehetővé teszi, hogy egy adott diára egyszínű hátteret állítson be a bemutatóban – még ha a bemutató mesterdiát is használ. A módosítás csak a kiválasztott diára vonatkozik.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2. Állítsa be a dia [BackgroundType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/backgroundtype/) értékét `OwnBackground`‑ra.
3. Állítsa be a dia háttér [FillType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/filltype/) értékét `Solid`‑ra.
4. Használja a [get_SolidFillColor](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fillformat/get_solidfillcolor/) metódust a [FillFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fillformat/)‑on a háttér színének megadásához.
5. Mentse el a módosított bemutatót.

Az alábbi C++ példa azt mutatja, hogyan állíthat be kék, egyszínű hátteret egy normál diára:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Hozzon létre egy példányt a Presentation osztályból.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Set the background color of the slide to blue.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Save the presentation to disk.
presentation->Save(u"SolidColorBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Egyszínű Háttér Beállítása Mesterdiára**

Az Aspose.Slides lehetővé teszi, hogy egy egyszínű hátteret állítson be a bemutató mesterdiájára. A mesterdia sablonként működik, amely az összes dia formázását vezérli, így a mesterdia háttér színének beállítása minden diára érvényes lesz.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2. Állítsa be a mesterdia [BackgroundType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/backgroundtype/) értékét (a `get_Masters`‑on keresztül) `OwnBackground`‑ra.
3. Állítsa be a mesterdia háttér [FillType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/filltype/) értékét `Solid`‑ra.
4. Használja a [get_SolidFillColor](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fillformat/get_solidfillcolor/) metódust a háttér színének megadásához.
5. Mentse el a módosított bemutatót.

Az alábbi C++ példa azt mutatja, hogyan állíthat be erdei zöld színű egyszínű hátteret egy mesterdiára:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Hozzon létre egy példányt a Presentation osztályból.
auto presentation = MakeObject<Presentation>();

auto masterSlide = presentation->get_Master(0);

// Állítsa be a Mesterdia háttérszínét erdei zöldre.
masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

// Mentse a bemutatót a lemezen.
presentation->Save(u"MasterSlideBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Átmenetes Háttér Beállítása Diára**

Az átmenet egy grafikai effekt, amely fokozatos színváltozással jön létre. Diaháttereként használva az átmenetek művészibbé és professzionálisabbá tehetik a bemutatót. Az Aspose.Slides lehetővé teszi, hogy átmenetes színt állítson be a diák háttereként.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2. Állítsa be a dia [BackgroundType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/backgroundtype/) értékét `OwnBackground`‑ra.
3. Állítsa be a dia háttér [FillType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/filltype/) értékét `Gradient`‑ra.
4. Használja a [get_GradientFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fillformat/get_gradientformat/) metódust a [FillFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fillformat/)‑on a kívánt átmenet beállításához.
5. Mentse el a módosított bemutatót.

Az alábbi C++ példa azt mutatja, hogyan állíthat be átmenetes színt diaháttérként:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Hozzon létre egy példányt a Presentation osztályból.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Alkalmazzon átmenet hatást a háttérre.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Gradient);
slide->get_Background()->get_FillFormat()->get_GradientFormat()->set_TileFlip(TileFlip::FlipBoth);

// Mentse a bemutatót a lemezen.
presentation->Save(u"GradientBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Kép Beállítása Diaháttérként**

Az egyszínű és átmenetes kitöltések mellett az Aspose.Slides lehetővé teszi, hogy képeket használjon diahátterekhez.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2. Állítsa be a dia [BackgroundType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/backgroundtype/) értékét `OwnBackground`‑ra.
3. Állítsa be a dia háttér [FillType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/filltype/) értékét `Picture`‑ra.
4. Töltse be a háttérként használni kívánt képet.
5. Adja hozzá a képet a bemutató képgyűjteményéhez.
6. Használja a [get_PictureFillFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fillformat/get_picturefillformat/) metódust a [FillFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fillformat/)‑on a kép háttérként történő hozzárendeléséhez.
7. Mentse el a módosított bemutatót.

Az alábbi C++ példa azt mutatja, hogyan állíthat be egy képet diaháttérként:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Hozzon létre egy példányt a Presentation osztályból.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Állítsa be a háttérkép tulajdonságait.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

// Töltse be a képet.
auto image = Images::FromFile(u"Tulips.jpg");
// Adja hozzá a képet a bemutató képgyűjteményéhez.
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(ppImage);

// Mentse a bemutatót a lemezen.
presentation->Save(u"ImageAsBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az alábbi kódrészlet azt mutatja, hogyan állítható be a háttér kitöltési típusa csempézett képre, valamint a csempézés tulajdonságainak módosítása:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);

auto background = firstSlide->get_Background();

background->set_Type(BackgroundType::OwnBackground);
background->get_FillFormat()->set_FillType(FillType::Picture);

auto newImage = Images::FromFile(u"image.png");
auto ppImage = presentation->get_Images()->AddImage(newImage);
newImage->Dispose();

// Set the image used for the background fill.
auto backPictureFillFormat = background->get_FillFormat()->get_PictureFillFormat();
backPictureFillFormat->get_Picture()->set_Image(ppImage);

// Set the picture fill mode to Tile and adjust the tile properties.
backPictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
backPictureFillFormat->set_TileOffsetX(15.0);
backPictureFillFormat->set_TileOffsetY(15.0);
backPictureFillFormat->set_TileScaleX(46.0);
backPictureFillFormat->set_TileScaleY(87.0);
backPictureFillFormat->set_TileAlignment(RectangleAlignment::Center);
backPictureFillFormat->set_TileFlip(TileFlip::FlipY);

presentation->Save(u"TileBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="info" %}}
Olvasson tovább: [**Tile Picture As Texture**](/slides/hu/cpp/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **A Háttérkép Átlátszóságának Módosítása**

Előfordulhat, hogy a dia háttérkép átlátszóságát szeretné módosítani, hogy a dia tartalma jobban kiemelkedjen. Az alábbi C++ kód megmutatja, hogyan változtatható meg egy dia háttérkép átlátszósága:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;

auto transparencyValue = 30; // Például.

// Hozzon létre egy példányt a Presentation osztályból.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto slide = presentation->get_Slide(0);

// Get the collection of picture transform operations.
auto imageTransform = slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_ImageTransform();

// Find an existing fixed-percentage transparency effect.
SharedPtr<IAlphaModulateFixed> transparencyOperation;
for (auto&& operation : imageTransform)
{
    if (ObjectExt::Is<IAlphaModulateFixed>(operation))
    {
        transparencyOperation = ExplicitCast<IAlphaModulateFixed>(operation);
        break;
    }
}

// Set the new transparency value.
if (transparencyOperation == nullptr)
{
    imageTransform->AddAlphaModulateFixedEffect(100.0f - transparencyValue);
}
else
{
    transparencyOperation->set_Amount(100.0f - transparencyValue);
}

// Save the presentation to disk.
presentation->Save(u"TransparentBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Dia Háttérértékének Lekérdezése**

Az Aspose.Slides biztosítja az [IBackgroundEffectiveData](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibackgroundeffectivedata/) interfészt a dia hatékony háttérértékeinek lekéréséhez. Ez az interfész a hatékony [FillFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibackgroundeffectivedata/get_fillformat/) és [EffectFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibackgroundeffectivedata/get_effectformat/) objektumokat teszi elérhetővé.

A [BaseSlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/baseslide/) osztály `get_Background` metódusával lekérheti a dia hatékony hátterét.

Az alábbi C++ példa azt mutatja, hogyan lehet lekérni egy dia hatékony háttérértékét:

```cpp
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IBackgroundEffectiveData.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

// Hozzon létre egy példányt a Presentation osztályból.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto slide = presentation->get_Slide(0);

// Lekérdezi a hatékony hátteret, figyelembe véve a mester-, elrendezés- és témabeállításokat.
auto effBackground = slide->get_Background()->GetEffective();

if (effBackground->get_FillFormat()->get_FillType() == FillType::Solid)
{
    Console::WriteLine(u"Fill color: {0}", effBackground->get_FillFormat()->get_SolidFillColor());
}
else
{
    Console::WriteLine(u"Fill type: {0}", ObjectExt::ToString(effBackground->get_FillFormat()->get_FillType()));
}
```

## **GYIK**

### Vissza tudom állítani a testreszabott hátteret, és visszakapni a téma/ülés háttérét?

Igen. Távolítsa el a dia egyéni kitöltését, és a háttér újra az adott [layout](/slides/hu/cpp/slide-layout/)/[master](/slides/hu/cpp/slide-master/) diához (azaz a [theme background](/slides/hu/cpp/presentation-theme/)) tartozó háttérből öröklődik.

### Mi történik a háttérrel, ha később megváltoztatom a bemutató témáját?

Ha egy diának saját kitöltése van, az változatlan marad. Ha a háttér az [layout](/slides/hu/cpp/slide-layout/)/[master](/slides/hu/cpp/slide-master/) diához öröklődik, akkor frissül az új [theme](/slides/hu/cpp/presentation-theme/) szerinti háttérre.