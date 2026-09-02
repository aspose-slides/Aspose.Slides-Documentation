---
title: Formátování tvarů PowerPointu v C++
linktitle: Formátování tvarů
type: docs
weight: 20
url: /cs/cpp/shape-formatting/
keywords:
- formátování tvaru
- formátování čáry
- skicový efekt
- skicová čára tvaru
- formátování stylu spojení
- gradientní výplň
- vzorová výplň
- výplň obrázkem
- výplň texturou
- výplň plnou barvou
- průhlednost tvaru
- černobílé vykreslování tvaru
- stupňování šedi tvaru
- otáčení tvaru
- 3D cýlový efekt
- 3D otáčecí efekt
- resetování formátování
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Naučte se, jak formátovat tvary PowerPointu v C++ pomocí Aspose.Slides — nastavte styly výplně, čáry a efektů pro soubory PPT, PPTX a ODP s přesností a úplnou kontrolou."
---
## **Úvod**

V PowerPointu můžete do snímků přidávat tvary. Protože tvary jsou složeny z čar, můžete je formátovat úpravou nebo použitím efektů na jejich obrysech. Navíc můžete tvary formátovat nastavením, která určují, jak bude vyplněn jejich vnitřek.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for C++ poskytuje rozhraní a metody, které vám umožňují formátovat tvary pomocí stejných možností, jaké jsou k dispozici v PowerPointu.

## **Formátování čar**

Pomocí Aspose.Slides můžete pro tvar určit vlastní styl čáry. Následující kroky popisují postup:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek objekt [IAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/).
1. Nastavte [line style](https://reference.aspose.com/slides/cs/cpp/aspose.slides/linestyle/) tvaru.
1. Nastavte šířku čáry.
1. Nastavte [dash style](https://reference.aspose.com/slides/cs/cpp/aspose.slides/linedashstyle/) čáry.
1. Nastavte barvu čáry pro tvar.
1. Uložte upravenou prezentaci jako soubor PPTX.

Níže je ukázka kódu, která formátuje obdélník `AutoShape`:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/LineDashStyle.h>
#include <DOM/LineStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
auto presentation = MakeObject<Presentation>();

// Získejte první snímek.
auto slide = presentation->get_Slide(0);

// Přidejte automatický tvar typu Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// Nastavte barvu výplně pro tvar obdélníku.
shape->get_FillFormat()->set_FillType(FillType::NoFill);

// Použijte formátování na čáry obdélníku.
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

Výsledek:

![The formatted lines in the presentation](formatted-lines.png)

## **Použití skicových efektů na čáry tvarů**

Skicový efekt dává čáře tvaru vzhled ručně kreslené. Použijte [IShape::get_LineFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/get_lineformat/) pro přístup k nastavení čáry, [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ilineformat/get_sketchformat/) pro přístup k nastavení skicu a [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isketchformat/set_sketchtype/) pro výběr hodnoty z výčtu [LineSketchType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/linesketchtype/).

Níže je C++ kód, který ukazuje, jak použít efekt [LineSketchType::Curved](https://reference.aspose.com/slides/cs/cpp/aspose.slides/linesketchtype/), přečíst explicitně přiřazenou hodnotu a odstranit efekt pomocí [LineSketchType::None](https://reference.aspose.com/slides/cs/cpp/aspose.slides/linesketchtype/):

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

* Round
* Miter
* Bevel

Ve výchozím nastavení, když PowerPoint spojuje dvě čáry pod úhlem (například v rohu tvaru), používá nastavení **Round**. Pokud však kreslíte tvar s ostrými úhly, můžete upřednostnit možnost **Miter**.

![The join style in the presentation](join-style-powerpoint.png)

Níže je C++ kód, který demonstruje, jak byly vytvořeny tři obdélníky (jak je vidět na obrázku výše) pomocí nastavení spojení Miter, Bevel a Round:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LineJoinStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

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

// Nastavte barvu čáry pro každý obdélník.
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

## **Gradient Fill**

V PowerPointu je Gradient Fill formátovací možnost, která umožňuje aplikovat plynulé prolínání barev na tvar. Například můžete použít dvě nebo více barev tak, aby se jedna postupně měnila na druhou.

Zde je postup, jak aplikovat gradientní výplň na tvar pomocí Aspose.Slides:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek objekt [IAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/).
1. Nastavte [FillType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/filltype/) tvaru na `Gradient`.
1. Přidejte své dvě preferované barvy s definovanými pozicemi pomocí metod `Add` kolekce gradientových zastávek, kterou poskytuje rozhraní [IGradientFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/igradientformat/).
1. Uložte upravenou prezentaci jako soubor PPTX.

Níže je C++ kód, který ukazuje, jak aplikovat gradientní výplň na elipsu:

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientDirection.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/PresetColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

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

Výsledek:

![The ellipse with gradient fill](gradient-fill.png)

## **Pattern Fill**

V PowerPointu je Pattern Fill formátovací možnost, která vám umožňuje aplikovat dvoubarevný vzor – například tečky, pruhy, křížové šrafování nebo šachovnici – na tvar. Můžete si zvolit vlastní barvy pro popředí a pozadí vzoru.

Aspose.Slides poskytuje více než 45 předdefinovaných stylů vzorů, které můžete aplikovat na tvary a zvýšit tak vizuální přitažlivost svých prezentací. I po výběru předdefinovaného vzoru můžete stále určit přesné barvy, které má použít.

Postup aplikace pattern fill na tvar pomocí Aspose.Slides:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek objekt [IAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/).
1. Nastavte [FillType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/filltype/) tvaru na `Pattern`.
1. Vyberte styl vzoru z předdefinovaných možností.
1. Nastavte [Background Color](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipatternformat/get_backcolor/) vzoru.
1. Nastavte [Foreground Color](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipatternformat/get_forecolor/) vzoru.
1. Uložte upravenou prezentaci jako soubor PPTX.

Níže je C++ kód, který ukazuje, jak aplikovat pattern fill na obdélník:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPatternFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

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

Výsledek:

![The rectangle with pattern fill](pattern-fill.png)

## **Picture Fill**

V PowerPointu je Picture Fill formátovací možnost, která vám umožňuje vložit obrázek dovnitř tvaru – efektivně použít obrázek jako pozadí tvaru.

Zde je postup, jak pomocí Aspose.Slides aplikovat picture fill na tvar:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek objekt [IAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/).
1. Nastavte [FillType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/filltype/) tvaru na `Picture`.
1. Nastavte režim picture fill na `Tile` (nebo jiný preferovaný režim).
1. Vytvořte objekt [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/) z obrázku, který chcete použít.
1. Předávejte obrázek metodě `ISlidesPicture.set_Image`.
1. Uložte upravenou prezentaci jako soubor PPTX.

Například máme soubor „lotus.png“ s následujícím obrázkem:

![The lotus picture](lotus.png)

Níže je C++ kód, který ukazuje, jak naplnit tvar obrázkem:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
auto presentation = MakeObject<Presentation>();

// Získejte první snímek.
auto slide = presentation->get_Slide(0);

// Přidejte automatický tvar typu Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// Nastavte typ výplně na Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Nastavte režim výplně obrázkem.
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// Načtěte obrázek a přidejte jej do prostředků prezentace.
auto image = Images::FromFile(u"lotus.png");
auto picture = presentation->get_Images()->AddImage(image);
image->Dispose();

// Nastavte obrázek.
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(picture);

// Uložte soubor PPTX na disk.
presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek:

![The shape with picture fill](picture-fill.png)

### **Tile Picture As Texture**

Pokud chcete nastavit dlaždicový obrázek jako texturu a přizpůsobit chování dlaždic, můžete použít následující metody rozhraní [IPictureFillFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipicturefillformat/) a třídy [PictureFillFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/picturefillformat/):

- [set_PictureFillMode](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): Nastaví režim výplně obrázkem – `Tile` nebo `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): Určuje zarovnání dlaždic uvnitř tvaru.
- [set_TileFlip](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipicturefillformat/set_tileflip/): Řídí, zda je dlaždice převrácena horizontálně, vertikálně nebo obojí.
- [set_TileOffsetX](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): Nastaví horizontální posun dlaždice (v bodech) od počátku tvaru.
- [set_TileOffsetY](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): Nastaví vertikální posun dlaždice (v bodech) od počátku tvaru.
- [set_TileScaleX](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): Definuje horizontální měřítko dlaždice v procentech.
- [set_TileScaleY](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): Definuje vertikální měřítko dlaždice v procentech.

Níže je ukázka kódu, jak přidat obdélníkový tvar s dlaždicovou výplní obrázkem a nakonfigurovat možnosti dlaždic:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
auto presentation = MakeObject<Presentation>();

// Získejte první snímek.
auto firstSlide = presentation->get_Slide(0);

// Přidejte automatický obdélníkový tvar.
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// Nastavte typ výplně tvaru na Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Načtěte obrázek a přidejte jej do prostředků prezentace.
auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

// Přiřaďte obrázek k tvaru.
auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);

// Nakonfigurujte režim výplně obrázkem a vlastnosti dlaždicování.
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

Výsledek:

![The tile options](tile-options.png)

## **Solid Color Fill**

V PowerPointu je Solid Color Fill formátovací možnost, která vyplní tvar jednou jednotnou barvou. Toto jednoduché pozadí se použije bez jakýchkoli gradientů, textur nebo vzorů.

Chcete‑li použít plnou barvu na tvar pomocí Aspose.Slides, postupujte takto:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek objekt [IAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/).
1. Nastavte [FillType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/filltype/) tvaru na `Solid`.
1. Přiřaďte požadovanou barvu výplně tvaru.
1. Uložte upravenou prezentaci jako soubor PPTX.

Níže je C++ kód, který ukazuje, jak aplikovat solid color fill na obdélník v PowerPoint snímku:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

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

Výsledek:

![The shape with solid color fill](solid-color-fill.png)

## **Nastavení průhlednosti**

V PowerPointu můžete při použití solid color, gradient, picture nebo texture fill nastavit úroveň průhlednosti, čímž řídíte neprůhlednost výplně. Vyšší hodnota průhlednosti způsobí, že bude tvar více prostupný a podklad či podkladové objekty budou částečně viditelné.

Aspose.Slides umožňuje nastavit úroveň průhlednosti úpravou alfa komponenty barvy použité pro výplň. Postup:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek objekt [IAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/).
1. Nastavte [FillType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/filltype/) na `Solid`.
1. Použijte `Color` k definování barvy s průhledností (komponenta `alpha` řídí průhlednost).
1. Uložte prezentaci.

Níže je C++ kód, který ukazuje, jak aplikovat průhlednou výplň na obdélník:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
auto presentation = MakeObject<Presentation>();

// Získejte první snímek.
auto slide = presentation->get_Slide(0);

// Přidejte automatický obdélník s plnou výplní.
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Přidejte průhledný obdélníkový automatický tvar nad plným tvarem.
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// Uložte soubor PPTX na disk.
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


Výsledek:

![The transparent shape](shape-transparency.png)

## **Otáčení tvarů**

Aspose.Slides umožňuje otáčet tvary v PowerPoint prezentacích. To může být užitečné při umisťování vizuálních prvků s konkrétním zarovnáním nebo designovým požadavkem.

Pro otočení tvaru na snímku postupujte takto:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek objekt [IAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/).
1. Nastavte vlastnost otáčení tvaru na požadovaný úhel.
1. Uložte prezentaci.

Níže je C++ kód, který ukazuje, jak otočit tvar o 5 stupňů:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

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

Výsledek:

![The shape rotation](shape-rotation.png)

## **Přidání 3D efekty cýly**

Aspose.Slides umožňuje aplikovat 3D cýlové efekty na tvary konfigurací jejich vlastností [ThreeDFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/threedformat/).

Pro přidání 3D cýlových efektů na tvar postupujte takto:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek objekt [IAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/).
1. Nakonfigurujte [ThreeDFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/threedformat/) tvaru pro definici nastavení cýly.
1. Uložte prezentaci.

Níže je C++ kód, který ukazuje, jak aplikovat 3D cýlové efekty na tvar:

```cpp
#include <DOM/BevelPresetType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeBevel.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

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

Výsledek:

![The 3D bevel effect](3D-bevel-effect.png)

## **Přidání 3D otáčecích efektů**

Aspose.Slides umožňuje aplikovat 3D otáčecí efekty na tvary konfigurací jejich vlastností [ThreeDFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/threedformat/).

Pro aplikaci 3D otáčení na tvar:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek objekt [IAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/).
1. Použijte [set_CameraType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icamera/set_cameratype/) a [set_LightType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ilightrig/set_lighttype/) pro definici 3D otáčení.
1. Uložte prezentaci.

Níže je C++ kód, který ukazuje, jak aplikovat 3D otáčecí efekty na tvar:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/ILightRig.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

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

Výsledek:

![The 3D rotation effect](3D-rotation-effect.png)

## **Řízení černobílého vykreslování pro tvary**

Metoda [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/set_blackwhitemode/) určuje, jak je jednotlivý tvar vykreslen, když je prezentace zobrazována nebo zpracovávána v černobílém režimu. Neaktivuje černobílý režim sama o sobě a nemění výplň, čáru ani jiné formátování tvaru v normálním barevném režimu.

Použijte hodnotu z výčtu [BlackWhiteMode](https://reference.aspose.com/slides/cs/cpp/aspose.slides/blackwhitemode/) k výběru požadovaného chování. Například `Automatic` nechá aplikaci zvolit konverzi, `Gray` a `LightGray` používají šedé zbarvení, `BlackWhite` používá pouze černou a bílou, `Black` a `White` vynutí jedinou barvu, `Color` zachová normální barvu a `Hidden` v černobílém režimu tvar vynechá. `NotDefined` znamená, že nebyl přiřazen žádný režim na úrovni tvaru.

Níže je C++ kód, který vytvoří barevný tvar a způsobí, že se v černobílém zobrazení zobrazí jako šedý:

```cpp
#include <DOM/BlackWhiteMode.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());

// Zachovejte oranžovou výplň v barevném režimu, ale vykreslete tvar se šedým zbarvením v černobílém režimu.
shape->set_BlackWhiteMode(BlackWhiteMode::Gray);

presentation->Save(u"shape_black_white_mode.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

V normálním barevném režimu si obdélník zachová oranžovou výplň. V pracovním postupu černobílého zobrazení používá šedé zbarvení, protože jeho režim je nastaven na `Gray`. To vám umožní zachovat plnobarevný snímek a zároveň definovat odlišný vzhled pro tisk, náhled nebo jiné procesy, které respektují nastavení černobílého zobrazení prezentace.

## **Resetování formátování**

Níže je C++ kód, který ukazuje, jak resetovat formátování snímku a vrátit pozici, velikost a formátování všech tvarů se zástupci na [LayoutSlide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/layoutslide/) na jejich výchozí nastavení:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    // Resetujte každý tvar na snímku, který má zástupce v rozložení.
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Často kladené otázky**

**Ovlivňuje formátování tvarů velikost výsledného souboru prezentace?**

Pouze minimálně. Vložené obrázky a média zabírají většinu prostoru souboru, zatímco parametry tvarů jako barvy, efekty a gradienty jsou uloženy jako metadata a prakticky nepřidávají žádnou extra velikost.

**Jak mohu detekovat tvary na snímku, které mají identické formátování, abych je mohl seskupit?**

Porovnejte klíčové vlastnosti formátování každého tvaru – výplň, čáru a nastavení efektů. Pokud se všechny odpovídající hodnoty shodují, považujte jejich styl za identický a logicky je seskupte, což usnadní následnou správu stylů.

**Mohu uložit sadu vlastních stylů tvarů do samostatného souboru pro opakované použití v jiných prezentacích?**

Ano. Uložte vzorové tvary s požadovanými styly do šablony prezentace nebo souboru .POTX. Při vytváření nové prezentace otevřete šablonu, naklonujte potřebné stylované tvary a znovu aplikujte jejich formátování tam, kde je to potřeba.