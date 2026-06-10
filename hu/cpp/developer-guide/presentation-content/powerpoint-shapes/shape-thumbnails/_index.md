---
title: "Diák formáinak bélyegképeinek létrehozása C++-ban"
linktitle: "Forma bélyegképek"
type: docs
weight: 70
url: /hu/cpp/shape-thumbnails/
keywords:
- forma bélyegkép
- forma kép
- forma renderelés
- forma renderelése
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Készítsen nagy felbontású forma bélyegképeket a PowerPoint diákból az Aspose.Slides for C++ segítségével – egyszerűen hozhatja létre és exportálhatja a prezentáció bélyegképeit."
---
## **Bevezetés**

Az Aspose.Slides-et prezentációs fájlok létrehozására használják, ahol minden oldal egy diát jelent. Ezeket a diákat a Microsoft PowerPoint segítségével megnyitott prezentációs fájlokból tekinthetik meg. Néha a fejlesztőknek külön képnél meg kell tekinteniük a formák képeit egy képnézegetőben. Ilyen esetben az Aspose.Slides segít a diaformák bélyegképének generálásában. Ennek a funkciónak a használatát ebben a cikkben ismertetjük.
Ez a cikk bemutatja, hogyan lehet különféle módokon diabélyegképeket generálni:

- Formabélyegkép generálása egy dián belül.
- Formabélyegkép generálása egy diáformához felhasználó által megadott méretekkel.
- Formabélyegkép generálása a forma megjelenésének határain belül.

## **Formabélyegkép generálása diáról**
Az Aspose.Slides for C++ használatával egy tetszőleges diáról formabélyegképet generálni a következőképpen:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Szerezze be egy tetszőleges dia hivatkozását az azonosítója vagy indexe alapján.
1. Szerezze meg a hivatkozott dia formabélyegképét az alapértelmezett méretben.
1. Mentse a bélyegképet a kívánt képfájl-formátumba.

Az alábbi példa egy formabélyegképet generál.

```cpp
auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage();
image->Save(u"Shape_thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Felhasználó által meghatározott méretezési tényezővel rendelkező bélyegkép generálása**
Az Aspose.Slides for C++ használatával egy tetszőleges diaformáról formabélyegképet generálni a következőképpen:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Szerezze be egy tetszőleges dia hivatkozását az azonosítója vagy indexe alapján.
1. Szerezze meg a hivatkozott dia bélyegképét a forma határaival.
1. Mentse a bélyegképet a kívánt képfájl-formátumba.

Az alábbi példa egy bélyegképet generál a felhasználó által meghatározott méretezési tényezővel.

```cpp
auto bounds = ShapeThumbnailBounds::Shape;
auto scale = 1; // Skálázás X és Y tengelyek mentén.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Scaling Factor Thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Határon alapuló forma-megjelenési bélyegkép létrehozása**
Ez a forma bélyegképek létrehozására szolgáló módszer lehetővé teszi a fejlesztők számára, hogy a forma megjelenésének határain belül képeket generáljanak. Figyelembe veszi a forma összes hatását. A generált forma bélyegkép a dia határai által korlátozott. Bármely diaforma megjelenésének határain belüli bélyegkép generálásához használja az alábbi minta kódot:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Szerezze be egy tetszőleges dia hivatkozását az azonosítója vagy indexe alapján.
1. Szerezze meg a hivatkozott dia bélyegképét a forma határai megjelenésként.
1. Mentse a bélyegképet a kívánt képfájl-formátumba.

Az alábbi példa egy bélyegképet hoz létre a forma megjelenésének határai alapján.

```cpp
auto bounds = ShapeThumbnailBounds::Appearance;
auto scale = 1; // Skálázás X és Y tengelyek mentén.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Shape_thumbnail_Bound_Shape_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **FAQ**

**Milyen képfájl-formátumok használhatók a forma bélyegképeinek mentésekor?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imageformat/), és egyebek. A formák [exportálhatók vektor SVG-ként](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shape/writeassvg/) a forma tartalmának SVG-ként való mentésével.

**Mi a különbség a Shape és az Appearance határok között bélyegkép renderelésekor?**

`Shape` a forma geometriáját használja; `Appearance` a [vizuális hatásokat](/slides/hu/cpp/shape-effect/) (árnyékok, ragyogások stb.) veszi figyelembe.

**Mi történik, ha egy forma rejtettnek van jelölve? Még mindig megjelenik bélyegképként?**

A rejtett forma továbbra is része a modellnek és renderelhető; a rejtett jelző a diavetítés megjelenítését befolyásolja, de nem akadályozza meg a forma képének generálását.

**Támogatottak a csoportos formák, diagramok, SmartArt és egyéb összetett objektumok?**

Igen. Bármely objektum, amely [Shape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shape/)ként van ábrázolva (beleértve a [GroupShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/groupshape/), a [Chart](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/chart/), és a [SmartArt](https://reference.aspose.com/slides/hu/cpp/aspose.slides.smartart/smartart/)) menthető bélyegképként vagy SVG-ként.

**A rendszerben telepített betűtípusok befolyásolják a szövegformák bélyegképének minőségét?**

Igen. Ajánlott [megadni a szükséges betűtípusokat](/slides/hu/cpp/custom-font/) (vagy [konfigurálni a betűtípus-helyettesítéseket](/slides/hu/cpp/font-substitution/)) a nem kívánt helyettesítések és szövegújraelrendezés elkerülése érdekében.