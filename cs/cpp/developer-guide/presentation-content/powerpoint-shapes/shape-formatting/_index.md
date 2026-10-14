---
title: Formátování tvarů PowerPointu v C++
linktitle: Formátování tvarů
type: docs
weight: 20
url: /cs/cpp/shape-formatting/
keywords:
- formát tvaru
- formát čáry
- skicovací efekt
- skicovaná čára tvaru
- formát spojovacího stylu
- gradientová výplň
- vzorková výplň
- obrázková výplň
- texturová výplň
- jednobarevná výplň
- průhlednost tvaru
- černobílé vykreslování tvaru
- šedotónové vykreslování tvaru
- rotace tvaru
- 3D zkosený efekt
- 3D rotační efekt
- resetování formátování
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Zjistěte, jak formátovat tvary PowerPointu v C++ pomocí Aspose.Slides — nastavit výplň, čáru a styly efektů pro soubory PPT, PPTX a ODP s přesností a plnou kontrolou."
---
## **Úvod**

V PowerPointu můžete do snímků přidávat tvary. Protože tvary jsou složeny z čar, můžete je formátovat úpravou nebo použitím efektů na jejich obrysech. Navíc můžete tvary formátovat zadáním nastavení, která řídí, jak jsou vyplněny jejich vnitřní oblasti.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides pro C++ poskytuje rozhraní a metody, které vám umožňují formátovat tvary pomocí stejných možností, jaké jsou k dispozici v PowerPointu.

## **Formátování čar**

Pomocí Aspose.Slides můžete pro tvar zadat vlastní styl čáry. Následující kroky popisují postup:

1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte na snímek [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/).
4. Nastavte [styl čáry](https://reference.aspose.com/slides/cpp/aspose.slides/linestyle/) tvaru.
5. Nastavte šířku čáry.
6. Nastavte [styl čárkování](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/) čáry.
7. Nastavte barvu čáry pro tvar.
8. Uložte upravenou prezentaci jako soubor PPTX.

Následující kód ukazuje, jak naformátovat obdélníkový `AutoShape`:

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

## **Použití skicovacích efektů na čáry tvaru**

Skicovací efekt způsobí, že čára tvaru vypadá jako ručně kreslená. K přístupu k nastavením čáry použijte [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/), k přístupu k nastavením skicu [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/get_sketchformat/) a k výběru hodnoty použijte [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/set_sketchtype/) z výčtu [LineSketchType](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/).

Následující C++ kód ukazuje, jak použít efekt [LineSketchType::Curved](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/), přečíst explicitně přiřazenou hodnotu a odebrat efekt pomocí [LineSketchType::None](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/):

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

Hodnota vrácená metodou [ISketchFormat::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/get_sketchtype/) představuje nastavení přiřazené přímo tvaru. Pokud lze formátování čáry zdědit z motivu, hlavního snímku nebo rozvržení, použijte [ILineFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/geteffective/), přistupte k [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/) a přečtěte [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/). Efektivní hodnota odráží formátování, které je skutečně použito po vyřešení dědičnosti:

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

## **Formátování spojovacích stylů**

Zde jsou tři možnosti typu spojení:

* Round
* Miter
* Bevel

Ve výchozím nastavení PowerPoint při spojení dvou čar pod úhlem (například v rohu tvaru) použije nastavení **Round**. Pokud však kreslíte tvar s ostrými úhly, můžete upřednostnit možnost **Miter**.

![The join style in the presentation](join-style-powerpoint.png)

Následující C++ kód ukazuje, jak byly vytvořeny tři obdélníky (viz obrázek výše) pomocí nastavení spojení Miter, Bevel a Round:

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

// Nastavte styl spoje.
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

## **Gradientová výplň**

V PowerPointu je Gradientová výplň formátovací možnost, která umožňuje aplikovat plynulý přechod barev na tvar. Například můžete použít dvě nebo více barev tak, aby se jedna postupně měnila v druhou.

Postup, jak aplikovat gradientovou výplň na tvar pomocí Aspose.Slides:

1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte na snímek [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/).
4. Nastavte [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) tvaru na `Gradient`.
5. Přidejte své dvě preferované barvy s definovanými pozicemi pomocí metod `Add` kolekce gradientových zastávek, kterou poskytuje rozhraní [IGradientFormat](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/).
6. Uložte upravenou prezentaci jako soubor PPTX.

Následující C++ kód ukazuje, jak aplikovat gradientovou výplň na elipsu:

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

// Aplikujte gradientové formátování na elipsu.
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

Pokud gradient v exportovaném obrázku vypadá jinak než v PowerPointu, podívejte se na [Choose a Gradient Rendering Style](/slides/cs/cpp/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Můžete vybrat styl vykreslování, aniž byste měnili gradientovou výplň uloženou v prezentaci.

## **Vzorková výplň**

V PowerPointu je Vzorková výplň formátovací možnost, která vám umožňuje aplikovat dvoubarevný návrh – například tečky, pruhy, křížové šrafování nebo šachovnici – na tvar. Pro popředí i pozadí vzoru můžete zvolit vlastní barvy.

Aspose.Slides poskytuje více než 45 předdefinovaných vzorových stylů, které můžete použít na tvary pro zvýšení vizuální přitažlivosti prezentací. I po výběru předdefinovaného vzoru můžete určit přesné barvy, které se mají použít.

Postup, jak aplikovat vzorkovou výplň na tvar pomocí Aspose.Slides:

1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte na snímek [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/).
4. Nastavte [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) tvaru na `Pattern`.
5. Vyberte vzorový styl z předdefinovaných možností.
6. Nastavte [Background Color](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_backcolor/) vzoru.
7. Nastavte [Foreground Color](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_forecolor/) vzoru.
8. Uložte upravenou prezentaci jako soubor PPTX.

Následující C++ kód ukazuje, jak aplikovat vzorkovou výplň na obdélník:

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

## **Obrázková výplň**

V PowerPointu je Obrázková výplň formátovací možnost, která vám umožňuje vložit obrázek dovnitř tvaru – čímž se obrázek používá jako pozadí tvaru.

Postup, jak pomocí Aspose.Slides aplikovat obrázkovou výplň na tvar:

1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte na snímek [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/).
4. Nastavte [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) tvaru na `Picture`.
5. Nastavte režim obrázkové výplně na `Tile` (nebo jiný preferovaný režim).
6. Vytvořte objekt [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) z obrázku, který chcete použít.
7. Předávejte obrázek metodě `ISlidesPicture.set_Image`.
8. Uložte upravenou prezentaci jako soubor PPTX.

Předpokládejme, že máme soubor "lotus.png" s následujícím obrázkem:

![The lotus picture](lotus.png)

Následující C++ kód ukazuje, jak vyplnit tvar obrázkem:

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

Výsledek:

![The shape with picture fill](picture-fill.png)

### **Tile Picture As Texture**

Pokud chcete nastavit dlaždicový obrázek jako texturu a přizpůsobit chování dlaždic, můžete použít následující metody rozhraní [IPictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/) a třídy [PictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/):

- [set_PictureFillMode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): Nastavuje režim obrázkové výplně – buď `Tile`, nebo `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): Určuje zarovnání dlaždic uvnitř tvaru.
- [set_TileFlip](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileflip/): Řídí, zda je dlaždice převrácena vodorovně, svisle nebo obojí.
- [set_TileOffsetX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): Nastavuje vodorovný posun dlaždice (v bodech) od počátku tvaru.
- [set_TileOffsetY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): Nastavuje svislý posun dlaždice (v bodech) od počátku tvaru.
- [set_TileScaleX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): Definuje vodorovné měřítko dlaždice v procentech.
- [set_TileScaleY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): Definuje svislé měřítko dlaždice v procentech.

Následující ukázka kódu ukazuje, jak přidat obdélníkový tvar s dlaždicovou obrázkovou výplní a nakonfigurovat možnosti dlaždic:

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

// Načtěte obrázek a přidejte jej do zdrojů prezentace.
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

## **Jednobarevná výplň**

V PowerPointu je Jednobarevná výplň formátovací možnost, která vyplní tvar jednou, jednotnou barvou. Tento jednoduchý podklad se aplikuje bez gradientů, textur nebo vzorů.

Postup, jak aplikovat jednobarevnou výplň na tvar pomocí Aspose.Slides:

1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte na snímek [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/).
4. Nastavte [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) tvaru na `Solid`.
5. Přiřaďte preferovanou barvu výplně tvaru.
6. Uložte upravenou prezentaci jako soubor PPTX.

Následující C++ kód ukazuje, jak aplikovat jednobarevnou výplň na obdélník v PowerPoint snímku:

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

V PowerPointu můžete při aplikaci jednobarevné, gradientové, obrázkové nebo texturové výplně na tvary také nastavit úroveň průhlednosti, která řídí neprůhlednost výplně. Vyšší hodnota průhlednosti způsobí, že tvar bude více průsvitný a podklad nebo podkladové objekty budou částečně viditelné.

Aspose.Slides vám umožňuje nastavit úroveň průhlednosti úpravou alfa komponenty barvy použité pro výplň. Postup:

1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte na snímek [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/).
4. Nastavte [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) na `Solid`.
5. Použijte `Color` k definování barvy s průhledností (komponenta `alpha` řídí průhlednost).
6. Uložte prezentaci.

Následující C++ kód ukazuje, jak aplikovat průhlednou barvu výplně na obdélník:

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

// Přidejte plně vyplněný obdélníkový automatický tvar.
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Přidejte průhledný obdélníkový automatický tvar nad plný tvar.
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// Uložte soubor PPTX na disk.
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek:

![The transparent shape](shape-transparency.png)

## **Rotace tvarů**

Aspose.Slides vám umožňuje otáčet tvary v prezentacích PowerPoint. To může být užitečné při umisťování vizuálních prvků s konkrétním zarovnáním nebo designovými požadavky.

Postup pro otočení tvaru na snímku:

1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte na snímek [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/).
4. Nastavte vlastnost otáčení tvaru na požadovaný úhel.
5. Uložte prezentaci.

Následující C++ kód ukazuje, jak otočit tvar o 5 stupňů:

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

## **Přidání 3D zkosených efektů**

Aspose.Slides vám umožňuje aplikovat 3D zkosené efekty na tvary konfigurací jejich vlastností [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/).

Postup pro přidání 3D zkosených efektů na tvar:

1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte na snímek [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/).
4. Nakonfigurujte [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/) tvaru a definujte nastavení zkosení.
5. Uložte prezentaci.

Následující C++ kód ukazuje, jak aplikovat 3D zkosené efekty na tvar:

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

## **Přidání 3D rotačních efektů**

Aspose.Slides vám umožňuje aplikovat 3D rotační efekty na tvary konfigurací jejich vlastností [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/).

Postup pro aplikaci 3D rotace na tvar:

1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte na snímek [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/).
4. Pomocí [set_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/set_cameratype/) a [set_LightType](https://reference.aspose.com/slides/cpp/aspose.slides/ilightrig/set_lighttype/) definujte 3D rotaci.
5. Uložte prezentaci.

Následující C++ kód ukazuje, jak aplikovat 3D rotační efekty na tvar:

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

Metoda [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_blackwhitemode/) určuje, jak je jednotlivý tvar vykreslen, když je prezentace zobrazována nebo zpracovávána v černobílém režimu. Nezapíná černobílý režim samotný a nemění výplň, čáru ani jiné formátování tvaru v normálním barevném režimu.

Použijte hodnotu z výčtu [BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/blackwhitemode/) k výběru požadovaného chování. Například `Automatic` nechá aplikaci pro vykreslování zvolit konverzi, `Gray` a `LightGray` používají šedé zbarvení, `BlackWhite` používá jen černou a bílou, `Black` a `White` vynutí jednotnou barvu, `Color` zachová normální barvy a `Hidden` skryje tvar v černobílém režimu. `NotDefined` znamená, že není přiřazen žádný režim na úrovni tvaru.

Následující C++ kód vytvoří barevný tvar a způsobí, že se v černobílém zobrazení zobrazí šedě:

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

// Udržte oranžovou výplň v barevném režimu, ale vykreslete tvar se šedým zbarvením v černobílém režimu.
shape->set_BlackWhiteMode(BlackWhiteMode::Gray);

presentation->Save(u"shape_black_white_mode.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

V normálním barevném režimu si obdélník uchovává oranžovou výplň. V pracovním postupu černobílého zobrazení používá šedé zbarvení, protože je jeho režim nastaven na `Gray`. To vám umožní uchovat snímek v plné barvě a zároveň definovat odlišný vzhled pro tisk, náhled nebo jiné pracovní postupy, které respektují nastavení černobílého zobrazení prezentace.

## **Obnovení formátování**

Následující C++ kód ukazuje, jak obnovit formátování snímku a vrátit pozici, velikost a formátování všech tvarů se zástupci na [LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/layoutslide/) na jejich výchozí nastavení:

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
    // Resetujte každý tvar na snímku, který má zástupce v rozvržení.
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Často kladené otázky**

**Ovlivňuje formátování tvarů konečnou velikost souboru prezentace?**

Pouze minimálně. Vložené obrázky a média zabírají většinu místa v souboru, zatímco parametry tvarů jako barvy, efekty a gradienty jsou uloženy jako metadata a prakticky nepřidávají žádnou další velikost.

**Jak mohu detekovat tvary na snímku, které mají identické formátování, abych je mohl seskupit?**

Porovnejte u každého tvaru klíčové vlastnosti formátování – výplň, čáru a nastavení efektů. Pokud se všechny odpovídající hodnoty shodují, považujte jejich styly za identické a logicky je seskupte; to usnadní následnou správu stylů.

**Mohu uložit sadu vlastních stylů tvarů do samostatného souboru pro opětovné použití v jiných prezentacích?**

Ano. Uložte ukázkové tvary s požadovanými styly do šablony prezentace nebo souboru .POTX. Při vytváření nové prezentace otevřete šablonu, klonujte potřebné stylované tvary a znovu aplikujte jejich formátování tam, kde je potřeba.