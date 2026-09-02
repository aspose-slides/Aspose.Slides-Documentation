---
title: Formátování tvarů PowerPointu v C++
linktitle: Formátování tvarů
type: docs
weight: 20
url: /cs/cpp/shape-formatting/
keywords:
- formát tvaru
- formát čáry
- efekt skicu
- skicovaná čára tvaru
- formát stylu spojení
- gradientní výplň
- výplň vzorem
- obrázková výplň
- texturová výplň
- jednobarevná výplň
- průhlednost tvaru
- otočit tvar
- 3D efekt zkosení
- 3D otočný efekt
- resetovat formátování
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Naučte se, jak v C++ formátovat tvary PowerPointu pomocí Aspose.Slides — nastavit styly výplně, čáry a efektů pro soubory PPT, PPTX a ODP s přesností a plnou kontrolou."
---
## **Úvod**

V aplikaci PowerPoint můžete do snímků přidávat tvary. Protože tvary jsou složeny z čar, můžete je formátovat úpravou nebo aplikací efektů na jejich obrysy. Navíc můžete tvary formátovat zadáním nastavení, která řídí, jak jsou vyplněny jejich vnitřky.

![formátování tvaru v PowerPointu](format-shape-powerpoint.png)

Aspose.Slides for C++ poskytuje rozhraní a metody, které vám umožňují formátovat tvary pomocí stejných možností, jaké jsou k dispozici v PowerPointu.

## **Formátování čar**

Pomocí Aspose.Slides můžete pro tvar zadat vlastní styl čáry. Následující kroky popisují postup:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek objekt [IAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/).
1. Nastavte [line style](https://reference.aspose.com/slides/cs/cpp/aspose.slides/linestyle/) tvaru.
1. Nastavte šířku čáry.
1. Nastavte [dash style](https://reference.aspose.com/slides/cs/cpp/aspose.slides/linedashstyle/) čáry.
1. Nastavte barvu čáry pro tvar.
1. Uložte upravenou prezentaci jako soubor PPTX.

Následující kód ukazuje, jak naformátovat obdélníkový `AutoShape`:

```cpp
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
auto presentation = MakeObject<Presentation>();

// Získejte první snímek.
auto slide = presentation->get_Slide(0);

// Přidejte automatický tvar typu Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// Nastavte barvu výplně pro obdélníkový tvar.
shape->get_FillFormat()->set_FillType(FillType::NoFill);

// Aplikujte formátování na čáry obdélníku.
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);

// Nastavte barvu čáry obdélníku.
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Uložte soubor PPTX na disk.
presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Naformátované čáry v prezentaci](formatted-lines.png)

## **Použití efektů skicu na čáry tvarů**

Efekt skicu způsobí, že čára tvaru vypadá ručně kresleně. Použijte [IShape::get_LineFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/get_lineformat/) k přístupu k nastavením čáry, [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ilineformat/get_sketchformat/) k přístupu k nastavením skicu a [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isketchformat/set_sketchtype/) k výběru hodnoty z výčtu [LineSketchType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/linesketchtype/).

Následující kód C++ ukazuje, jak použít efekt [LineSketchType::Curved](https://reference.aspose.com/slides/cs/cpp/aspose.slides/linesketchtype/), jak přečíst explicitně přiřazenou hodnotu a jak odebrat efekt pomocí [LineSketchType::None](https://reference.aspose.com/slides/cs/cpp/aspose.slides/linesketchtype/):

```cpp
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

// Access the shape's line format and its sketch format.
auto sketchFormat = shape->get_LineFormat()->get_SketchFormat();

// Apply a sketch effect.
sketchFormat->set_SketchType(LineSketchType::Curved);

// Read the sketch effect assigned directly to the shape.
auto explicitSketchType = sketchFormat->get_SketchType();
Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);

// Remove the sketch effect.
sketchFormat->set_SketchType(LineSketchType::None);

presentation->Dispose();
```

Hodnota vrácená metodou [ISketchFormat::get_SketchType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isketchformat/get_sketchtype/) představuje nastavení přiřazené přímo tvaru. Pokud může být formátování čáry zděděno z motivu, hlavního snímku nebo rozložení snímku, použijte [ILineFormat::GetEffective](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ilineformat/geteffective/), přistupte k [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/) a přečtěte [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/). Efektivní hodnota odráží formátování, které je skutečně použito po vyřešení dědičnosti:

```cpp
auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto lineFormat = shape->get_LineFormat();

auto explicitSketchType = lineFormat->get_SketchFormat()->get_SketchType();
auto effectiveLineFormat = lineFormat->GetEffective();
auto effectiveSketchType = effectiveLineFormat->get_SketchFormat()->get_SketchType();

Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);
Console::WriteLine(u"Effective sketch type: {0}", effectiveSketchType);

presentation->Dispose();
```

## **Formátování stylů spojení**

Zde jsou tři možnosti typu spojení:

* Oblý
* Miter
* Šikmý

Ve výchozím nastavení PowerPoint při spojování dvou čar pod úhlem (například v rohu tvaru) používá nastavení **Round**. Pokud však kreslíte tvar s ostrými úhly, můžete upřednostnit možnost **Miter**.

![Styl spojení v prezentaci](join-style-powerpoint.png)

Následující kód C++ ukazuje, jak byly vytvořeny tři obdélníky (jak je vidět na obrázku výše) pomocí nastavení typu spojení Miter, Bevel a Round:

```cpp
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
auto presentation = MakeObject<Presentation>();

// Získejte první snímek.
auto slide = presentation->get_Slide(0);

// Přidejte tři automatické tvary typu Rectangle.
auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

// Nastavte barvu výplně pro každý obdélníkový tvar.
shape1->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape2->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape3->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// Nastavte šířku čáry.
shape1->get_LineFormat()->set_Width(15);
shape2->get_LineFormat()->set_Width(15);
shape3->get_LineFormat()->set_Width(15);

// Nastavte barvu čáry každého obdélníku.
shape1->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape3->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Nastavte styl spojení.
shape1->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
shape2->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
shape3->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

// Přidejte text do každého obdélníku.
shape1->get_TextFrame()->set_Text(u"Miter Join Style");
shape2->get_TextFrame()->set_Text(u"Bevel Join Style");
shape3->get_TextFrame()->set_Text(u"Round Join Style");

// Uložte soubor PPTX na disk.
presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Gradientní výplň**

V PowerPointu je Gradient Fill formátovací možnost, která vám umožňuje aplikovat plynulé prolínání barev na tvar. Například můžete použít dvě nebo více barev tak, aby se jedna postupně přecházela v druhou.

Zde je návod, jak aplikovat gradientní výplň na tvar pomocí Aspose.Slides:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek objekt [IAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/).
1. Nastavte [FillType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/filltype/) tvaru na `Gradient`.
1. Přidejte své dvě preferované barvy s definovanými pozicemi pomocí metod `Add` kolekce gradientových zastávek, kterou vystavuje rozhraní [IGradientFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/igradientformat/).
1. Uložte upravenou prezentaci jako soubor PPTX.

```cpp
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
auto presentation = MakeObject<Presentation>();

// Získejte první snímek.
auto slide = presentation->get_Slide(0);

// Přidejte automatický tvar typu Ellipse.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// Použijte gradientní formátování na elipsu.
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// Nastavte směr gradientu.
shape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// Přidejte dva gradientové zastávky.
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// Uložte soubor PPTX na disk.
presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Elipsa s gradientní výplní](gradient-fill.png)

## **Vzorová výplň**

V PowerPointu je Pattern Fill formátovací možnost, která vám umožňuje aplikovat dvoubarevný motiv – například tečky, pruhy, křížové šrafování nebo šachovnici – na tvar. Můžete zvolit vlastní barvy popředí a pozadí vzoru.

Aspose.Slides nabízí více než 45 předdefinovaných stylů vzorů, které můžete aplikovat na tvary a zlepšit tak vizuální atraktivitu prezentací. I po výběru předdefinovaného vzoru můžete stále specifikovat přesné barvy, které má použít.

Zde je postup, jak aplikovat vzorovou výplň na tvar pomocí Aspose.Slides:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek objekt [IAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/).
1. Nastavte [FillType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/filltype/) tvaru na `Pattern`.
1. Vyberte styl vzoru z předdefinovaných možností.
1. Nastavte [Background Color](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipatternformat/get_backcolor/) vzoru.
1. Nastavte [Foreground Color](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipatternformat/get_forecolor/) vzoru.
1. Uložte upravenou prezentaci jako soubor PPTX.

```cpp
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
auto presentation = MakeObject<Presentation>();

// Získejte první snímek.
auto slide = presentation->get_Slide(0);

// Přidejte automatický tvar typu Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Nastavte typ výplně na Pattern.
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// Nastavte styl vzoru.
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// Nastavte barvy pozadí a popředí vzoru.
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// Uložte soubor PPTX na disk.
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Obdélník s vzorovou výplní](pattern-fill.png)

## **Obrázková výplň**

V PowerPointu je Picture Fill formátovací možnost, která vám umožňuje vložit obrázek do tvaru – efektivně použít obrázek jako pozadí tvaru.

Zde je návod, jak použít Aspose.Slides k aplikaci obrázkové výplně na tvar:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek objekt [IAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/).
1. Nastavte [FillType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/filltype/) tvaru na `Picture`.
1. Nastavte režim obrázkové výplně na `Tile` (nebo jiný preferovaný režim).
1. Vytvořte objekt [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/) z obrázku, který chcete použít.
1. Předáte obrázek metodě `ISlidesPicture.set_Image`.
1. Uložte upravenou prezentaci jako soubor PPTX.

![Obrázek lotosu](lotus.png)

Následující kód C++ ukazuje, jak vyplnit tvar obrázkem:

```cpp
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
auto presentation = MakeObject<Presentation>();

// Získejte první snímek.
auto slide = presentation->get_Slide(0);

// Přidejte automatický tvar typu Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// Nastavte typ výplně na Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Nastavte režim obrázkové výplně.
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// Načtěte obrázek a přidejte jej do zdrojů prezentace.
auto image = Images::FromFile(u"lotus.png");
auto picture = presentation->get_Images()->AddImage(image);
image->Dispose();

// Nastavte obrázek.
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(picture);

// Uložte soubor PPTX na disk.
presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Tvar s obrázkovou výplní](picture-fill.png)

### **Dlaždicovat obrázek jako texturu**

Pokud chcete nastavit dlaždicovaný obrázek jako texturu a přizpůsobit chování dlaždic, můžete použít následující metody rozhraní [IPictureFillFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipicturefillformat/) a třídy [PictureFillFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/picturefillformat/):

- [set_PictureFillMode](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): Nastaví režim obrázkové výplně – buď `Tile`, nebo `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): Určuje zarovnání dlaždic uvnitř tvaru.
- [set_TileFlip](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipicturefillformat/set_tileflip/): Řídí, zda je dlaždice převrácena horizontálně, vertikálně nebo obojí.
- [set_TileOffsetX](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): Nastaví vodorovný posun dlaždice (v bodech) od počátku tvaru.
- [set_TileOffsetY](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): Nastaví svislý posun dlaždice (v bodech) od počátku tvaru.
- [set_TileScaleX](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): Definuje vodorovné měřítko dlaždice v procentech.
- [set_TileScaleY](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): Definuje svislé měřítko dlaždice v procentech.

Následující ukázka kódu ukazuje, jak přidat obdélníkový tvar s dlaždicovou obrázkovou výplní a nakonfigurovat možnosti dlaždic:

```cpp
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
auto presentation = MakeObject<Presentation>();

// Získejte první snímek.
auto firstSlide = presentation->get_Slide(0);

// Přidejte automatický tvar typu Rectangle.
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// Nastavte typ výplně tvaru na Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Načtěte obrázek a přidejte jej do zdrojů prezentace.
auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

// Přiřaďte obrázek k tvaru.
auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);

// Nakonfigurujte režim obrázkové výplně a vlastnosti dlaždicování.
pictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
pictureFillFormat->set_TileOffsetX(-32);
pictureFillFormat->set_TileOffsetY(-32);
pictureFillFormat->set_TileScaleX(50);
pictureFillFormat->set_TileScaleY(50);
pictureFillFormat->set_TileAlignment(RectangleAlignment::BottomRight);
pictureFillFormat->set_TileFlip(TileFlip::FlipBoth);

// Uložte soubor PPTX na disk.
presentation->Save(u"tile.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Možnosti dlaždic](tile-options.png)

## **Jednobarevná výplň**

V PowerPointu je Solid Color Fill formátovací možnost, která vyplní tvar jednou, jednotnou barvou. Tato jednoduchá barva pozadí se aplikuje bez gradientů, textur nebo vzorů.

Pro aplikaci jednobarevné výplně na tvar pomocí Aspose.Slides postupujte takto:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek objekt [IAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/).
1. Nastavte [FillType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/filltype/) tvaru na `Solid`.
1. Přidělte požadovanou barvu výplně tvaru.
1. Uložte upravenou prezentaci jako soubor PPTX.

```cpp
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
auto presentation = MakeObject<Presentation>();

// Získejte první snímek.
auto slide = presentation->get_Slide(0);

// Přidejte automatický tvar typu Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Nastavte typ výplně na Solid.
shape->get_FillFormat()->set_FillType(FillType::Solid);

// Nastavte barvu výplně.
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// Uložte soubor PPTX na disk.
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Tvar s jednobarevnou výplní](solid-color-fill.png)

## **Nastavení průhlednosti**

V PowerPointu, když použijete jednobarevnou, gradientní, obrázkovou nebo texturovou výplň na tvary, můžete také nastavit úroveň průhlednosti, která řídí neprůhlednost výplně. Vyšší hodnota průhlednosti způsobí, že tvar bude průhlednější a umožní částečně vidět pozadí nebo podkladové objekty.

Aspose.Slides vám umožňuje nastavit úroveň průhlednosti úpravou alfa komponenty barvy použité pro výplň. Zde je postup:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek objekt [IAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/).
1. Nastavte [FillType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/filltype/) tvaru na `Solid`.
1. Použijte `Color` k definování barvy s průhledností (komponenta `alpha` řídí průhlednost).
1. Uložte prezentaci.

```cpp
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
auto presentation = MakeObject<Presentation>();

// Získejte první snímek.
auto slide = presentation->get_Slide(0);

// Přidejte automatický tvar typu Rectangle s plnou výplní.
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Přidejte průhledný automatický obdélníkový tvar nad plný tvar.
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// Uložte soubor PPTX na disk.
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Průhledný tvar](shape-transparency.png)

## **Otáčení tvarů**

Aspose.Slides vám umožňuje otáčet tvary v prezentacích PowerPoint. To může být užitečné při umisťování vizuálních prvků s konkrétním zarovnáním nebo designovými požadavky.

Postup pro otočení tvaru na snímku:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek objekt [IAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/).
1. Nastavte vlastnost rotace tvaru na požadovaný úhel.
1. Uložte prezentaci.

```cpp
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
auto presentation = MakeObject<Presentation>();

// Získejte první snímek.
auto slide = presentation->get_Slide(0);

// Přidejte automatický tvar typu Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Otočte tvar o 5 stupňů.
shape->set_Rotation(5);

// Uložte soubor PPTX na disk.
presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Otáčení tvaru](shape-rotation.png)

## **Přidání 3D efektů zkosení**

Aspose.Slides umožňuje aplikovat 3D efekty zkosení na tvary konfigurováním jejich vlastností [ThreeDFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/threedformat/).

Postup pro přidání 3D efektů zkosení:

1. Instancujte třídu [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek objekt [IAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/).
1. Nakonfigurujte [ThreeDFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/threedformat/) tvaru pro definování nastavení zkosení.
1. Uložte prezentaci.

```cpp
// Vytvořte instanci třídy Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Přidejte tvar na snímek.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);

// Nastavte vlastnosti ThreeDFormat tvaru.
shape->get_ThreeDFormat()->set_Depth(4.0);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

// Uložte prezentaci jako soubor PPTX.
presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![3D efekt zkosení](3D-bevel-effect.png)

## **Přidání 3D otočných efektů**

Aspose.Slides umožňuje aplikovat 3D otočné efekty na tvary konfigurováním jejich vlastností [ThreeDFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/threedformat/).

Postup pro aplikaci 3D otočení na tvar:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek objekt [IAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/).
1. Použijte [set_CameraType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icamera/set_cameratype/) a [set_LightType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ilightrig/set_lighttype/) k definování 3D rotace.
1. Uložte prezentaci.

```cpp
// Vytvořte instanci třídy Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_TextFrame()->set_Text(u"Hello, Aspose!");

shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// Uložte prezentaci jako soubor PPTX.
presentation->Save(u"3D_rotation_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![3D otočný efekt](3D-rotation-effect.png)

## **Resetování formátování**

Následující kód C++ ukazuje, jak resetovat formátování snímku a vrátit pozici, velikost a formátování všech tvarů se zástupci na [LayoutSlide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/layoutslide/) na jejich výchozí nastavení:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // Resetujte každý tvar na snímku, který má placeholder v rozložení.
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Ovlivňuje formátování tvarů konečnou velikost souboru prezentace?**

Pouze nepatrně. Vložené obrázky a média zabírají většinu prostoru souboru, zatímco parametry tvarů, jako jsou barvy, efekty a gradienty, jsou uloženy jako metadata a přidávají prakticky žádnou další velikost.

**Jak mohu na snímku detekovat tvary, které mají stejné formátování, abych je mohl seskupit?**

Porovnejte klíčové vlastnosti formátování každého tvaru – nastavení výplně, čáry a efektů. Pokud se všechny odpovídající hodnoty shodují, považujte jejich styly za identické a logicky seskupte tyto tvary, což usnadní pozdější správu stylů.

**Mohu uložit sadu vlastních stylů tvarů do samostatného souboru pro opětovné použití v jiných prezentacích?**

Ano. Uložte ukázkové tvary s požadovanými styly do šablony snímků nebo souboru .POTX. Při tvorbě nové prezentace otevřete šablonu, klonujte stylované tvary, které potřebujete, a znovu použijte jejich formátování tam, kde je to nutné.