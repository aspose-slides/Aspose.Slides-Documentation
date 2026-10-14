---
title: Formatera PowerPoint‑former i C++
linktitle: Formatering av former
type: docs
weight: 20
url: /sv/cpp/shape-formatting/
keywords:
- formatera form
- formatera linje
- skiss‑effekt
- skissformslinje
- formatera anslutningsstil
- gradientfyllning
- mönsterfyllning
- bildfyllning
- texturfyllning
- solid färgfyllning
- formtransparens
- svart‑vit formrendering
- gråskala formrendering
- rotera form
- 3D‑fasadeffekt
- 3D‑roteringseffekt
- återställ formatering
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Lär dig hur du formaterar PowerPoint‑former i C++ med Aspose.Slides — ställ in fyllnings‑, linje‑ och effektstilar för PPT, PPTX och ODP‑filer med precision och full kontroll."
---
## **Introduktion**

I PowerPoint kan du lägga till former på bilder. Eftersom former består av linjer kan du formatera dem genom att ändra eller tillämpa effekter på deras konturer. Dessutom kan du formatera former genom att ange inställningar som styr hur deras innerväggar fylls.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides för C++ tillhandahåller gränssnitt och metoder som låter dig formatera former med samma alternativ som finns i PowerPoint.

## **Formatera linjer**

Med Aspose.Slides kan du ange en anpassad linjestil för en form. Följande steg beskriver proceduren:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till ett [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) på bilden.
1. Ange [linjestil](https://reference.aspose.com/slides/cpp/aspose.slides/linestyle/) för formen.
1. Ange linjebredden.
1. Ange [streckstil](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/) för linjen.
1. Ange linjefärgen för formen.
1. Spara den ändrade presentationen som en PPTX‑fil.

Följande kod demonstrerar hur man formaterar en rektangel `AutoShape`:

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

// Instansiera Presentation‑klassen som representerar en presentationsfil.
auto presentation = MakeObject<Presentation>();

// Hämta den första bilden.
auto slide = presentation->get_Slide(0);

// Lägg till en autoform av typen Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// Ange fyllningsfärgen för rektangelformen.
shape->get_FillFormat()->set_FillType(FillType::NoFill);

// Tillämpa formatering på rektangelns linjer.
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);

// Ange färgen för rektangelns linje.
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Spara PPTX‑filen till disk.
presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Resultatet:

![De formaterade linjerna i presentationen](formatted-lines.png)

## **Tillämpa skiss‑effekter på formens linjer**

En skisseffekt gör att en formlinje ser handritad ut. Använd [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) för att komma åt linjeinställningarna, [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/get_sketchformat/) för att komma åt skissinställningarna och [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/set_sketchtype/) för att välja ett värde från uppräkningen [LineSketchType](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/).

Följande C++‑kod visar hur man tillämpar en [LineSketchType::Curved](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/)‑effekt, läser det uttryckligen tilldelade värdet och tar bort effekten med [LineSketchType::None](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/):

```cpp
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

// Åtkomst till formens linjeformat och skissformat.
auto sketchFormat = shape->get_LineFormat()->get_SketchFormat();

// Tillämpa en skiss‑effekt.
sketchFormat->set_SketchType(LineSketchType::Curved);

// Läs den skiss‑effekt som tilldelats direkt till formen.
auto explicitSketchType = sketchFormat->get_SketchType();
Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);

// Ta bort skiss‑effekten.
sketchFormat->set_SketchType(LineSketchType::None);

presentation->Dispose();
```

Värdet som returneras av [ISketchFormat::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/get_sketchtype/) representerar den inställning som tilldelats direkt till formen. Om linjeformatering kan ärvas från ett tema, en master‑bild eller en layout‑bild, använd [ILineFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/geteffective/), få åtkomst till [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/), och läs [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/). Det effektiva värdet återspeglar den formatering som faktiskt tillämpas efter att arv har lösts:

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

## **Formatera anslutningsstilar**

Här är de tre alternativ för anslutningstyp:

* Rund
* Sned
* Fas

Som standard, när PowerPoint förenar två linjer i en vinkel (t.ex. vid en formens hörn), använder den inställningen **Rund**. Om du däremot ritar en form med skarpa vinklar kan du föredra alternativet **Sned**.

![Ansamlingsstilen i presentationen](join-style-powerpoint.png)

Följande C++‑kod demonstrerar hur tre rektanglar (som visas på bilden ovan) skapades med Miter‑, Bevel‑ och Round‑anslutningstypinställningarna:

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

// Instansiera Presentation‑klassen som representerar en presentationsfil.
auto presentation = MakeObject<Presentation>();

// Hämta den första bilden.
auto slide = presentation->get_Slide(0);

// Lägg till tre autoformer av typen Rectangle.
auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

// Ange fyllningsfärgen för varje rektangelform.
shape1->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape2->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape3->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// Ange linjebredden.
shape1->get_LineFormat()->set_Width(15);
shape2->get_LineFormat()->set_Width(15);
shape3->get_LineFormat()->set_Width(15);

// Ange färgen för varje rektangels linje.
shape1->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape3->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Ange anslutningsstilen.
shape1->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
shape2->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
shape3->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

// Lägg till text i varje rektangel.
shape1->get_TextFrame()->set_Text(u"Miter Join Style");
shape2->get_TextFrame()->set_Text(u"Bevel Join Style");
shape3->get_TextFrame()->set_Text(u"Round Join Style");

// Spara PPTX‑filen till disk.
presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Gradientfyllning**

I PowerPoint är Gradientfyllning ett formateringsalternativ som låter dig applicera en kontinuerlig färgblandning på en form. Du kan till exempel använda två eller fler färger så att den ena gradvis tonas in i den andra.

Så här applicerar du en gradientfyllning på en form med Aspose.Slides:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till ett [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) på bilden.
1. Ange formens [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) till `Gradient`.
1. Lägg till dina två föredragna färger med definierade positioner med hjälp av `Add`‑metoderna i gradientstopp‑samlingen som exponeras av gränssnittet [IGradientFormat](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/).
1. Spara den ändrade presentationen som en PPTX‑fil.

```cpp
// Instansiera Presentation‑klassen som representerar en presentationsfil.
auto presentation = MakeObject<Presentation>();

// Hämta den första bilden.
auto slide = presentation->get_Slide(0);

// Lägg till en autoform av typen Ellipse.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// Tillämpa gradientformatering på ellipsen.
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// Ställ in gradientens riktning.
shape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// Lägg till två gradientstopp.
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// Spara PPTX‑filen till disk.
presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Resultatet:

![Ellipsen med gradientfyllning](gradient-fill.png)

Om en gradient ser annorlunda ut i en exporterad bild än i PowerPoint, se [Choose a Gradient Rendering Style](/slides/sv/cpp/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Du kan välja en rendering‑stil utan att ändra gradientfyllningen som lagras i presentationen.

## **Mönsterfyllning**

I PowerPoint är Mönsterfyllning ett formateringsalternativ som låter dig applicera en tvåfärgsdesign — såsom prickar, ränder, korsningar eller rutmönster — på en form. Du kan välja egna färger för mönstrets förgrund och bakgrund.

Aspose.Slides erbjuder mer än 45 fördefinierade mönsterstilar som du kan applicera på former för att förbättra det visuella intrycket i dina presentationer. Även efter att ha valt ett fördefinierat mönster kan du fortfarande ange de exakt färger som ska användas.

Så här applicerar du en mönsterfyllning på en form med Aspose.Slides:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till ett [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) på bilden.
1. Ange formens [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) till `Pattern`.
1. Välj en mönsterstil från de fördefinierade alternativen.
1. Ange [Background Color](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_backcolor/) för mönstret.
1. Ange [Foreground Color](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_forecolor/) för mönstret.
1. Spara den ändrade presentationen som en PPTX‑fil.

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

// Instansiera Presentation‑klassen som representerar en presentationsfil.
auto presentation = MakeObject<Presentation>();

// Hämta den första bilden.
auto slide = presentation->get_Slide(0);

// Lägg till en autoform av typen Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Ange fyllningstypen till Pattern.
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// Ange mönsterstilen.
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// Ange mönstrets bakgrunds- och förgrundsfärger.
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// Spara PPTX‑filen till disk.
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Resultatet:

![Rektangeln med mönsterfyllning](pattern-fill.png)

## **Bildfyllning**

I PowerPoint är Bildfyllning ett formateringsalternativ som låter dig infoga en bild i en form — effektivt använder bilden som formens bakgrund.

Så här använder du Aspose.Slides för att applicera en bildfyllning på en form:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till ett [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) på bilden.
1. Ange formens [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) till `Picture`.
1. Ange bildfyllningsläget till `Tile` (eller ett annat föredraget läge).
1. Skapa ett [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/)‑objekt från den bild du vill använda.
1. Skicka bilden till metoden `ISlidesPicture.set_Image`.
1. Spara den ändrade presentationen som en PPTX‑fil.

Anta att vi har en "lotus.png"-fil med följande bild:

![Lotus‑bilden](lotus.png)

Följande C++‑kod demonstrerar hur man fyller en form med bilden:

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

// Instansiera Presentation‑klassen som representerar en presentationsfil.
auto presentation = MakeObject<Presentation>();

// Hämta den första bilden.
auto slide = presentation->get_Slide(0);

// Lägg till en autoform av typen Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// Ange fyllningstypen till Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Ange bildfyllningsläget.
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// Läs in en bild och lägg till den i presentationens resurser.
auto image = Images::FromFile(u"lotus.png");
auto picture = presentation->get_Images()->AddImage(image);
image->Dispose();

// Ange bilden.
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(picture);

// Spara PPTX‑filen till disk.
presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Resultatet:

![Formen med bildfyllning](picture-fill.png)

### **Tile picture som textur**

Om du vill sätta en tiled bild som en textur och anpassa tiling‑beteendet kan du använda följande metoder i gränssnittet [IPictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/) och klassen [PictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/):

- [set_PictureFillMode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): Anger bildfyllningsläget — antingen `Tile` eller `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): Anger justeringen av plattorna inom formen.
- [set_TileFlip](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileflip/): Styr om plattan vänds horisontellt, vertikalt eller båda.
- [set_TileOffsetX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): Anger den horisontella offseten för plattan (i punkter) från formens ursprung.
- [set_TileOffsetY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): Anger den vertikala offseten för plattan (i punkter) från formens ursprung.
- [set_TileScaleX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): Definierar den horisontella skalningen av plattan i procent.
- [set_TileScaleY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): Definierar den vertikala skalningen av plattan i procent.

Följande kodexempel visar hur man lägger till en rektangel med en tiled bildfyllning och konfigurerar tile‑alternativen:

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

// Instansiera Presentation-klassen som representerar en presentationsfil.
auto presentation = MakeObject<Presentation>();

// Hämta den första bilden.
auto firstSlide = presentation->get_Slide(0);

// Lägg till en rektangel-autoform.
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// Ange fyllningstypen för formen till Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Läs in bilden och lägg till den i presentationens resurser.
auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

// Tilldela bilden till formen.
auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);

// Konfigurera bildfyllningsläget och tile-egenskaperna.
pictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
pictureFillFormat->set_TileOffsetX(-32);
pictureFillFormat->set_TileOffsetY(-32);
pictureFillFormat->set_TileScaleX(50);
pictureFillFormat->set_TileScaleY(50);
pictureFillFormat->set_TileAlignment(RectangleAlignment::BottomRight);
pictureFillFormat->set_TileFlip(TileFlip::FlipBoth);

// Spara PPTX-filen till disk.
presentation->Save(u"tile.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Resultatet:

![Tile‑alternativen](tile-options.png)

## **Solid färgfyllning**

I PowerPoint är Solid Color Fill ett formateringsalternativ som fyller en form med en enda, enhetlig färg. Denna enkla bakgrundsfärg appliceras utan några gradienter, texturer eller mönster.

Så här applicerar du en solid färgfyllning på en form med Aspose.Slides:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till ett [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) på bilden.
1. Ange formens [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) till `Solid`.
1. Tilldela den föredragna fyllnadsfärgen till formen.
1. Spara den ändrade presentationen som en PPTX‑fil.

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

// Instansiera Presentation-klassen som representerar en presentationsfil.
auto presentation = MakeObject<Presentation>();

// Hämta den första bilden.
auto slide = presentation->get_Slide(0);

// Lägg till en autoform av typen Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Ange fyllningstypen till Solid.
shape->get_FillFormat()->set_FillType(FillType::Solid);

// Ange fyllningsfärgen.
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// Spara PPTX-filen till disk.
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Resultatet:

![Formen med solid färgfyllning](solid-color-fill.png)

## **Ställ in transparens**

I PowerPoint, när du applicerar en solid färg, gradient, bild eller texturfyllning på former kan du även ange en transparensnivå för att styra fyllningens opacitet. Ett högre transparensvärde gör formen mer genomskinlig, så att bakgrunden eller underliggande objekt delvis syns.

Aspose.Slides låter dig ange transparensnivån genom att justera alfavärdet i den färg som används för fyllningen. Så här gör du:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till ett [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) på bilden.
1. Ange [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) till `Solid`.
1. Använd `Color` för att definiera en färg med transparens (komponenten `alpha` styr transparensen).
1. Spara presentationen.

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

// Instansiera Presentation‑klassen som representerar en presentationsfil.
auto presentation = MakeObject<Presentation>();

// Hämta den första bilden.
auto slide = presentation->get_Slide(0);

// Lägg till en solid rektangel‑autoform.
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Lägg till en transparent rektangel‑autoform ovanpå den solida formen.
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// Spara PPTX‑filen till disk.
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Resultatet:

![Den transparenta formen](shape-transparency.png)

## **Rotera former**

Aspose.Slides låter dig rotera former i PowerPoint‑presentationer. Detta kan vara användbart vid placering av visuella element med specifika justerings‑ eller designbehov.

För att rotera en form på en bild, följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till ett [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) på bilden.
1. Ange formens roterings‑egenskap till önskad vinkel.
1. Spara presentationen.

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

// Instansiera Presentation‑klassen som representerar en presentationsfil.
auto presentation = MakeObject<Presentation>();

// Hämta den första bilden.
auto slide = presentation->get_Slide(0);

// Lägg till en autoform av typen Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Rotera formen med 5 grader.
shape->set_Rotation(5);

// Spara PPTX‑filen till disk.
presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Resultatet:

![Formens rotation](shape-rotation.png)

## **Lägg till 3D‑fasade effekter**

Aspose.Slides låter dig tillämpa 3D‑fasade effekter på former genom att konfigurera deras egenskaper i [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/)‑egenskaper.

För att lägga till 3D‑fasade effekter på en form, följ dessa steg:

1. Instansiera klassen [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till ett [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) på bilden.
1. Konfigurera formens [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/) för att definiera fasinställningarna.
1. Spara presentationen.

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

// Skapa en instans av Presentation‑klassen.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Lägg till en form på bilden.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);

// Ställ in formens ThreeDFormat‑egenskaper.
shape->get_ThreeDFormat()->set_Depth(4.0);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

// Spara presentationen som en PPTX‑fil.
presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Resultatet:

![3D‑fasadeffekten](3D-bevel-effect.png)

## **Lägg till 3D‑roterings‑effekter**

Aspose.Slides låter dig tillämpa 3D‑roterings‑effekter på former genom att konfigurera deras [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/)‑egenskaper.

För att applicera 3D‑rotation på en form:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till ett [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) på bilden.
1. Använd [set_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/set_cameratype/) och [set_LightType](https://reference.aspose.com/slides/cpp/aspose.slides/ilightrig/set_lighttype/) för att definiera 3D‑rotationen.
1. Spara presentationen.

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

// Skapa en instans av Presentation‑klassen.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_TextFrame()->set_Text(u"Hello, Aspose!");

shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// Spara presentationen som en PPTX‑fil.
presentation->Save(u"3D_rotation_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Resultatet:

![3D‑roteringseffekten](3D-rotation-effect.png)

## **Styr svart‑vit rendering för former**

Metoden [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_blackwhitemode/) specificerar hur en enskild form renderas när en presentation visas eller bearbetas i svart‑vit‑läge. Den aktiverar inte svart‑vit‑visning i sig och ändrar inte formens fyllning, linje eller annan formatering i normalt färgläge.

Använd ett värde från uppräkningen [BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/blackwhitemode/) för att välja önskat beteende. Till exempel låter `Automatic` renderingsprogrammet välja konverteringen, `Gray` och `LightGray` använder grå färgning, `BlackWhite` använder bara svart och vitt, `Black` och `White` tvingar en enda färg, `Color` bevarar normal färgning och `Hidden` utesluter formen i svart‑vit‑läge. `NotDefined` betyder att inget mode har tilldelats på formnivå.

Följande C++‑kod skapar en färgad form och får den att visas grå i svart‑vit‑visningsläge:

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

// Behåll den orange fyllningen i färgläge, men rendera formen med grå färgning i svart‑vit läge.
shape->set_BlackWhiteMode(BlackWhiteMode::Gray);

presentation->Save(u"shape_black_white_mode.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

I normalt färgläge behåller rektangeln sin orange fyllning. I ett arbetsflöde med svart‑vit visning använder den grå färgning eftersom dess läge är satt till `Gray`. Detta låter dig bevara en fullfärgs‑bild samtidigt som du definierar ett särskilt utseende för utskrift, förhandsgranskning eller andra arbetsflöden som hedrar presentationens svart‑vita displayinställningar.

## **Återställ formatering**

Följande C++‑kod visar hur du återställer formateringen av en bild och återställer position, storlek och formatering för alla former med platshållare på [LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/layoutslide/) till deras standardinställningar:

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
    // Återställ varje form på bilden som har en platshållare på layouten.
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Påverkar formatering av former den slutgiltiga presentationsfilens storlek?**

Endast i liten grad. Inbäddade bilder och media tar upp största delen av filstorleken, medan formparametrar som färger, effekter och gradienter lagras som metadata och adderar i praktiskt taget ingen extra storlek.

**Hur kan jag upptäcka former på en bild som delar identisk formatering så att jag kan gruppera dem?**

Jämför varje forms nyckelformaterings‑egenskaper — fyllning, linje och effektinställningar. Om alla motsvarande värden matchar, behandla deras stilar som identiska och gruppera logiskt dessa former, vilket förenklar senare stilhantering.

**Kan jag spara en uppsättning anpassade formstilar i en separat fil för återanvändning i andra presentationer?**

Ja. Spara exempelformer med önskade stilar i en mall‑bildsamling eller en .POTX‑mallfil. När du skapar en ny presentation, öppna mallen, klona de stiliserade former du behöver och återapplicera deras formatering där det krävs.