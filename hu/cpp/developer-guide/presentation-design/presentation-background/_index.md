---
title: Prezentáció hátterek kezelése C++-ban
linktitle: Dia háttér
type: docs
weight: 20
url: /hu/cpp/presentation-background/
keywords:
- prezentáció háttér
- dia háttér
- egyszínű szín
- színátmenetes szín
- kép háttér
- háttér átlátszóság
- háttér tulajdonságok
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan állíthat be dinamikus háttereket PowerPoint és OpenDocument fájlokban az Aspose.Slides for C++ segítségével, kódtippekkel, amelyek fokozzák prezentációit."
---
## **Bevezetés**

Az egyszínű színek, a színátmenetek és a képek gyakran használtak a diák háttérképeként. Beállíthatja a háttérszínt egy **normál diára** (egyetlen dia) vagy egy **mesterdiára** (több diára egyszerre alkalmazva).

![PowerPoint background](powerpoint-background.png)

## **Egyszínű háttér beállítása normál diára**

Az Aspose.Slides lehetővé teszi, hogy egy adott diához egyszínű hátteret állítson be – akkor is, ha a prezentáció mesterdiai sablont használ. A módosítás csak a kiválasztott diára vonatkozik.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2. Állítsa be a dia [BackgroundType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/backgroundtype/) értékét `OwnBackground`‑ra.
3. Állítsa be a dia háttér [FillType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/filltype/) értékét `Solid`‑ra.
4. Használja a [get_SolidFillColor](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fillformat/get_solidfillcolor/) metódust a [FillFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fillformat/) osztályon a háttérszín megadásához.
5. Mentse el a módosított prezentációt.

Az alábbi C++ példa bemutatja, hogyan állíthat be kék egyszínű hátteret egy normál diára:

```cpp
// Hozzon létre egy példányt a Presentation osztályból.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Állítsa be a dia háttérszínét kékre.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Mentse a prezentációt a lemezre.
presentation->Save(u"SolidColorBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Egyszínű háttér beállítása mesterdiára**

Az Aspose.Slides lehetővé teszi, hogy egy egyszínű hátteret állítson be a prezentáció mesterdiájára. A mesterdia sablonként működik, amely a formázást a minden diára kiterjeszti, így az egyszínű háttér minden diára érvényes lesz.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2. Állítsa be a mesterdia [BackgroundType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/backgroundtype/) értékét (a `get_Masters`‑on keresztül) `OwnBackground`‑ra.
3. Állítsa be a mesterdia háttér [FillType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/filltype/) értékét `Solid`‑ra.
4. Használja a [get_SolidFillColor](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fillformat/get_solidfillcolor/) metódust a háttér színének megadásához.
5. Mentse el a módosított prezentációt.

Az alábbi C++ példa bemutatja, hogyan állíthat be erdei zöld színt a mesterdia háttérként:

```cpp
// Hozzon létre egy példányt a Presentation osztályból.
auto presentation = MakeObject<Presentation>();

auto masterSlide = presentation->get_Master(0);

// Állítsa be a mesterdia háttérszínét erdei zöldre.
masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

// Mentse a prezentációt a lemezre.
presentation->Save(u"MasterSlideBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Színátmenetes háttér beállítása diára**

A színátmenet egy fokozatos színváltozással létrehozott grafikai hatás. Diakép háttérként használva a színátmenetek művészibbé és professzionálisabbá tehetik a prezentációkat. Az Aspose.Slides lehetővé teszi, hogy színátmenetes színt állítson be a diák háttérként.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2. Állítsa be a dia [BackgroundType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/backgroundtype/) értékét `OwnBackground`‑ra.
3. Állítsa be a dia háttér [FillType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/filltype/) értékét `Gradient`‑ra.
4. Használja a [get_GradientFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fillformat/get_gradientformat/) metódust a [FillFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fillformat/) osztályon a kívánt színátmenet beállításához.
5. Mentse el a módosított prezentációt.

Az alábbi C++ példa bemutatja, hogyan állíthat be színátmenetes hátteret egy diára:

```cpp
// Hozzon létre egy példányt a Presentation osztályból.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Alkalmazzon színátmenetes hatást a háttérre.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Gradient);
slide->get_Background()->get_FillFormat()->get_GradientFormat()->set_TileFlip(TileFlip::FlipBoth);

// Mentse a prezentációt a lemezre.
presentation->Save(u"GradientBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Kép beállítása diakép háttérként**

Az egyszínű és színátmenetes kitöltések mellett az Aspose.Slides lehetővé teszi képek használatát diakép háttérként.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2. Állítsa be a dia [BackgroundType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/backgroundtype/) értékét `OwnBackground`‑ra.
3. Állítsa be a dia háttér [FillType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/filltype/) értékét `Picture`‑ra.
4. Töltse be a kívánt képet, amelyet a dia háttérként szeretne használni.
5. Adja hozzá a képet a prezentáció képkészletéhez.
6. Használja a [get_PictureFillFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fillformat/get_picturefillformat/) metódust a [FillFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fillformat/) osztályon a kép háttérként történő hozzárendeléséhez.
7. Mentse el a módosított prezentációt.

Az alábbi C++ példa bemutatja, hogyan állíthat be képet diakép háttérként:

```cpp
// Hozzon létre egy példányt a Presentation osztályból.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Állítsa be a háttérkép tulajdonságait.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

// Töltse be a képet.
auto image = Images::FromFile(u"Tulips.jpg");
// Adja hozzá a képet a prezentáció képkészletéhez.
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(ppImage);

// Mentse a prezentációt a lemezre.
presentation->Save(u"ImageAsBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az alábbi kódrészlet bemutatja, hogyan állíthatja be a háttér kitöltést csempézett képre, és módosíthatja a csempézés tulajdonságait:

```cpp
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

{{% alert color="primary" %}}
Olvassa tovább: [**Kép csempézése textúraként**](/slides/hu/cpp/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **A háttérkép átlátszóságának módosítása**

Lehet, hogy szabályozni szeretné egy diakép háttér átlátszóságát, hogy a dia tartalma jobban kiemelkedjen. Az alábbi C++ kód bemutatja, hogyan változtatható a diakép háttér átlátszósága:

```cpp
auto transparencyValue = 30; // Például.

// A képtranszformációs műveletek gyűjteményének lekérése.
auto imageTransform = slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_ImageTransform();

// Keressen egy meglévő fix százalékos átlátszósági hatást.
SharedPtr<IAlphaModulateFixed> transparencyOperation;
for (auto&& operation : imageTransform)
{
    if (ObjectExt::Is<IAlphaModulateFixed>(operation))
    {
        transparencyOperation = ExplicitCast<IAlphaModulateFixed>(operation);
        break;
    }
}

// Állítsa be az új átlátszósági értéket.
if (transparencyOperation == nullptr)
{
    imageTransform->AddAlphaModulateFixedEffect(100.0f - transparencyValue);
}
else
{
    transparencyOperation->set_Amount(100.0f - transparencyValue);
}
```

## **A dia háttér értékének lekérdezése**

Az Aspose.Slides biztosítja az [IBackgroundEffectiveData](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibackgroundeffectivedata/) interfészt a dia hatékony háttérértékeinek lekéréséhez. Ez az interfész a hatékony [FillFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibackgroundeffectivedata/get_fillformat/) és [EffectFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibackgroundeffectivedata/get_effectformat/) elemeket teszi elérhetővé.

A [BaseSlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/baseslide/) osztály `get_Background` metódusával kaphatja meg a dia hatékony háttérjét.

Az alábbi C++ példa bemutatja, hogyan kérdezhető le egy dia hatékony háttérértéke:

```cpp
// Hozzon létre egy példányt a Presentation osztályból.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto slide = presentation->get_Slide(0);

// Retrieve the effective background, taking into account master, layout, and theme.
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

**Vissza tudom állítani az egyedi hátteret, és visszakapni a téma/layouthátteret?**

Igen. Távolítsa el a dia egyedi kitöltését, és a háttér újra az adott [layout](/slides/hu/cpp/slide-layout/)/[master](/slides/hu/cpp/slide-master/) diához (azaz a [theme background](/slides/hu/cpp/presentation-theme/)) tartozó háttérből lesz örökölt.

**Mi történik a háttérrel, ha később megváltoztatom a prezentáció témáját?**

Ha egy diának saját kitöltése van, az változatlan marad. Ha a háttér a [layout](/slides/hu/cpp/slide-layout/)/[master](/slides/hu/cpp/slide-master/) diához van örökölve, akkor frissül az új [theme](/slides/hu/cpp/presentation-theme/) szerint.