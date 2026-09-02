---
title: Formatera PowerPoint-former i C++
linktitle: Formatering av former
type: docs
weight: 20
url: /sv/cpp/shape-formatting/
keywords:
- formatera form
- formatera linje
- skiss‑effekt
- skisslinje för form
- formatera fogstil
- gradientfyllning
- mönsterfyllning
- bildfyllning
- texturfyllning
- solid färgfyllning
- formens transparens
- rotera form
- 3D‑fasadeffekt
- 3D‑roteringseffekt
- återställ formatering
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Lär dig hur du formaterar PowerPoint‑former i C++ med Aspose.Slides—ställ in fyllnings‑, linje‑ och effektstilar för PPT-, PPTX‑ och ODP‑filer med precision och full kontroll."
---
## **Introduktion**

I PowerPoint kan du lägga till former på bilder. Eftersom former består av linjer kan du formatera dem genom att ändra eller tillämpa effekter på deras konturer. Dessutom kan du formatera former genom att ange inställningar som styr hur deras inre fylls.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides för C++ tillhandahåller gränssnitt och metoder som låter dig formatera former med samma alternativ som finns i PowerPoint.

## **Formatera linjer**

Med Aspose.Slides kan du ange en anpassad linjestil för en form. Följande steg beskriver proceduren:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)-klassen.
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/) på bilden.
1. Ange [linjestil](https://reference.aspose.com/slides/sv/cpp/aspose.slides/linestyle/) för formen.
1. Ange linjebredden.
1. Ange [streckstil](https://reference.aspose.com/slides/sv/cpp/aspose.slides/linedashstyle/) för linjen.
1. Ange linjefärgen för formen.
1. Spara den modifierade presentationen som en PPTX-fil.

Följande kod visar hur man formaterar en rektangel `AutoShape`:

```cpp
// Skapa en instans av Presentation-klassen som representerar en presentationsfil.
auto presentation = MakeObject<Presentation>();

// Hämta den första bilden.
auto slide = presentation->get_Slide(0);

// Lägg till en autoshape av typen Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// Ange fyllningsfärgen för rektangelformen.
shape->get_FillFormat()->set_FillType(FillType::NoFill);

// Applicera formatering på rektangelns linjer.
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);

// Ange färgen för rektangelns linje.
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Spara PPTX-filen till disk.
presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Resultatet:

![De formaterade linjerna i presentationen](formatted-lines.png)

## **Applicera skiss‑effekter på formens linjer**

En skisseffekt får en formlinje att se handritad ut. Använd [IShape::get_LineFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/get_lineformat/) för att komma åt linjeinställningarna, [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ilineformat/get_sketchformat/) för att komma åt skissinställningarna och [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isketchformat/set_sketchtype/) för att välja ett värde från uppräkningen [LineSketchType](https://reference.aspose.com/slides/sv/cpp/aspose.slides/linesketchtype/).

Följande C++‑kod visar hur man tillämpar en [LineSketchType::Curved](https://reference.aspose.com/slides/sv/cpp/aspose.slides/linesketchtype/)-effekt, läser det explicit tilldelade värdet och tar bort effekten med [LineSketchType::None](https://reference.aspose.com/slides/sv/cpp/aspose.slides/linesketchtype/):

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

Värdet som returneras av [ISketchFormat::get_SketchType](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isketchformat/get_sketchtype/) representerar den inställning som tilldelats direkt till formen. Om linjeformateringen kan ärvas från ett tema, en huvudsida eller en layout‑bild, använd [ILineFormat::GetEffective](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ilineformat/geteffective/), åtkomst [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/), och läs [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/). Det effektiva värdet speglar den formatering som faktiskt tillämpas efter att arv har lösts:

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

## **Formatera fogstilar**

Här är de tre fogtypalternativen:

* Rund
* Miter
* Fas

Som standard, när PowerPoint förenar två linjer i en vinkel (t.ex. vid en forms hörn), använder den **Rund**‑inställningen. Men om du ritar en form med skarpa vinklar kan du föredra **Miter**‑alternativet.

![Fogstilen i presentationen](join-style-powerpoint.png)

Följande C++‑kod visar hur tre rektanglar (som visas i bilden ovan) skapades med Miter‑, Fas‑ och Rund‑fogtypinställningarna:

```cpp
// Instansiera Presentation-klassen som representerar en presentationsfil.
auto presentation = MakeObject<Presentation>();

// Hämta den första bilden.
auto slide = presentation->get_Slide(0);

// Lägg till tre autoshapes av typen Rectangle.
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

// Ange fogstilen.
shape1->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
shape2->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
shape3->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

// Lägg till text i varje rektangel.
shape1->get_TextFrame()->set_Text(u"Miter Join Style");
shape2->get_TextFrame()->set_Text(u"Bevel Join Style");
shape3->get_TextFrame()->set_Text(u"Round Join Style");

// Spara PPTX-filen till disk.
presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Gradientfyllning**

I PowerPoint är Gradientfyllning ett formateringsalternativ som låter dig applicera en kontinuerlig färgblandning på en form. Till exempel kan du använda två eller fler färger på ett sätt där den ena gradvis tonas in i den andra.

Så här applicerar du en gradientfyllning på en form med Aspose.Slides:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)-klassen.
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/) på bilden.
1. Ange formens [FillType](https://reference.aspose.com/slides/sv/cpp/aspose.slides/filltype/) till `Gradient`.
1. Lägg till dina två föredragna färger med definierade positioner med hjälp av `Add`‑metoderna i gradientstopp‑samlingen som exponeras av gränssnittet [IGradientFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/igradientformat/).
1. Spara den modifierade presentationen som en PPTX-fil.

```cpp
// Instansiera Presentation-klassen som representerar en presentationsfil.
auto presentation = MakeObject<Presentation>();

// Hämta den första bilden.
auto slide = presentation->get_Slide(0);

// Lägg till en autoshape av typen Ellipse.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// Applicera gradientformatering på ellipsen.
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// Ange gradientens riktning.
shape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// Lägg till två gradientstopp.
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// Spara PPTX-filen till disk.
presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Resultatet:

![Ellipsen med gradientfyllning](gradient-fill.png)

## **Mönsterfyllning**

I PowerPoint är Mönsterfyllning ett formateringsalternativ som låter dig applicera en tvåfärgsdesign—såsom prickar, ränder, korslinjer eller rutmönster—på en form. Du kan välja anpassade färger för mönstrets förgrund och bakgrund.

Aspose.Slides erbjuder mer än 45 fördefinierade mönsterstilar som du kan applicera på former för att förbättra det visuella intrycket av dina presentationer. Även efter att ha valt ett fördefinierat mönster kan du fortfarande ange exakt vilka färger som ska användas.

Så här applicerar du en mönsterfyllning på en form med Aspose.Slides:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)-klassen.
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/) på bilden.
1. Ange formens [FillType](https://reference.aspose.com/slides/sv/cpp/aspose.slides/filltype/) till `Pattern`.
1. Välj en mönsterstil från de fördefinierade alternativen.
1. Ange [Background Color](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipatternformat/get_backcolor/) för mönstret.
1. Ange [Foreground Color](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipatternformat/get_forecolor/) för mönstret.
1. Spara den modifierade presentationen som en PPTX-fil.

```cpp
// Instansiera Presentation-klassen som representerar en presentationsfil.
auto presentation = MakeObject<Presentation>();

// Hämta den första bilden.
auto slide = presentation->get_Slide(0);

// Lägg till en autoshape av typen Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Ange fyllningstypen till Pattern.
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// Ange mönsterstil.
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// Ange mönstrets bakgrunds- och förgrundsfärger.
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// Spara PPTX-filen till disk.
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Resultatet:

![Rektangeln med mönsterfyllning](pattern-fill.png)

## **Bildfyllning**

I PowerPoint är Bildfyllning ett formateringsalternativ som låter dig infoga en bild i en form—effektivt använda bilden som formens bakgrund.

Så här använder du Aspose.Slides för att applicera en bildfyllning på en form:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)-klassen.
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/) på bilden.
1. Ange formens [FillType](https://reference.aspose.com/slides/sv/cpp/aspose.slides/filltype/) till `Picture`.
1. Ange bildfyllningsläget till `Tile` (eller ett annat föredraget läge).
1. Skapa ett [IPPImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ippimage/)-objekt från den bild du vill använda.
1. Skicka bilden till metoden `ISlidesPicture.set_Image`.
1. Spara den modifierade presentationen som en PPTX-fil.

Anta att vi har en fil "lotus.png" med följande bild:

![Lotus‑bilden](lotus.png)

```cpp
// Instansiera Presentation‑klassen som representerar en presentationsfil.
auto presentation = MakeObject<Presentation>();

// Hämta den första bilden.
auto slide = presentation->get_Slide(0);

// Lägg till en autoshape av typen Rectangle.
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

// Spara PPTX-filen till disk.
presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Resultatet:

![Formen med bildfyllning](picture-fill.png)

### **Tile‑bild som textur**

Om du vill ange en tilad bild som en textur och anpassa tilningsbeteendet kan du använda följande metoder i gränssnittet [IPictureFillFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipicturefillformat/) och klassen [PictureFillFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/picturefillformat/):

- [set_PictureFillMode](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): Anger bildfyllningsläget—antingen `Tile` eller `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): Specificerar justeringen av plattorna inom formen.
- [set_TileFlip](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipicturefillformat/set_tileflip/): Styr om plattan vänds horisontellt, vertikalt eller båda.
- [set_TileOffsetX](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): Anger den horisontella förskjutningen av plattan (i punkter) från formens ursprung.
- [set_TileOffsetY](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): Anger den vertikala förskjutningen av plattan (i punkter) från formens ursprung.
- [set_TileScaleX](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): Definierar den horisontella skalan av plattan i procent.
- [set_TileScaleY](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): Definierar den vertikala skalan av plattan i procent.

Följande kodexempel visar hur man lägger till en rektangel med tilad bildfyllning och konfigurerar plattalternativen:

```cpp
// Instansiera Presentation-klassen som representerar en presentationsfil.
auto presentation = MakeObject<Presentation>();

// Hämta den första bilden.
auto firstSlide = presentation->get_Slide(0);

// Lägg till en rektangel autoshape.
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

// Konfigurera bildfyllningsläget och tilningsegenskaperna.
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

![Plattalternativen](tile-options.png)

## **Solid färgfyllning**

I PowerPoint är Solid Color Fill ett formateringsalternativ som fyller en form med en enda, jämn färg. Denna enkla bakgrundsfärg appliceras utan några gradienter, texturer eller mönster.

För att applicera en solid färgfyllning på en form med Aspose.Slides, följ dessa steg:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)-klassen.
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/) på bilden.
1. Ange formens [FillType](https://reference.aspose.com/slides/sv/cpp/aspose.slides/filltype/) till `Solid`.
1. Tilldela din föredragna fyllningsfärg till formen.
1. Spara den modifierade presentationen som en PPTX-fil.

```cpp
// Instansiera Presentation-klassen som representerar en presentationsfil.
auto presentation = MakeObject<Presentation>();

// Hämta den första bilden.
auto slide = presentation->get_Slide(0);

// Lägg till en autoshape av typen Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Ställ in fyllningstypen till Solid.
shape->get_FillFormat()->set_FillType(FillType::Solid);

// Ställ in fyllningsfärgen.
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// Spara PPTX-filen till disk.
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Resultatet:

![Formen med solid färgfyllning](solid-color-fill.png)

## **Ange transparens**

I PowerPoint, när du applicerar en solid färg, gradient, bild eller texturfyllning på former kan du också ange en transparensnivå för att kontrollera fyllningens opacitet. Ett högre transparensvärde gör formen mer genomskinlig, så att bakgrunden eller underliggande objekt delvis syns.

Aspose.Slides låter dig ange transparensnivån genom att justera alfavärdet i färgen som används för fyllningen. Så här gör du:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)-klassen.
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/) på bilden.
1. Ange [FillType](https://reference.aspose.com/slides/sv/cpp/aspose.slides/filltype/) till `Solid`.
1. Använd `Color` för att definiera en färg med transparens (komponenten `alpha` styr transparensen).
1. Spara presentationen.

```cpp
// Instansiera Presentation-klassen som representerar en presentationsfil.
auto presentation = MakeObject<Presentation>();

// Hämta den första bilden.
auto slide = presentation->get_Slide(0);

// Lägg till en solid rektangel autoshape.
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Lägg till en transparent rektangel autoshape ovanpå den solida formen.
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// Spara PPTX-filen till disk.
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Resultatet:

![Den transparenta formen](shape-transparency.png)

## **Rotera former**

Aspose.Slides låter dig rotera former i PowerPoint‑presentationer. Detta kan vara användbart när du placerar visuella element med specifika justerings‑ eller designbehov.

För att rotera en form på en bild, följ dessa steg:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)-klassen.
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/) på bilden.
1. Ange formens roterings‑egenskap till önskad vinkel.
1. Spara presentationen.

```cpp
// Instansiera Presentation-klassen som representerar en presentationsfil.
auto presentation = MakeObject<Presentation>();

// Hämta den första bilden.
auto slide = presentation->get_Slide(0);

// Lägg till en autoshape av typen Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Rotera formen med 5 grader.
shape->set_Rotation(5);

// Spara PPTX-filen till disk.
presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Resultatet:

![Formens rotation](shape-rotation.png)

## **Lägg till 3D-fasadseffekter**

Aspose.Slides låter dig applicera 3D‑fasadseffekter på former genom att konfigurera deras [ThreeDFormat]-egenskaper.

För att lägga till 3D‑fasadseffekter på en form, följ dessa steg:

1. Instansiera [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)-klassen.
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/) på bilden.
1. Konfigurera formens [ThreeDFormat] för att definiera fasadinställningar.
1. Spara presentationen.

```cpp
// Skapa en instans av Presentation-klassen.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Lägg till en form på bilden.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);

// Ange formens ThreeDFormat‑egenskaper.
shape->get_ThreeDFormat()->set_Depth(4.0);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

// Spara presentationen som en PPTX-fil.
presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Resultatet:

![3D‑fasadeffekten](3D-bevel-effect.png)

## **Lägg till 3D-rotations‑effekter**

Aspose.Slides låter dig applicera 3D‑rotations‑effekter på former genom att konfigurera deras [ThreeDFormat]-egenskaper.

För att applicera 3D‑rotation på en form:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)-klassen.
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/) på bilden.
1. Använd [set_CameraType](https://reference.aspose.com/slides/sv/cpp/aspose.slides/icamera/set_cameratype/) och [set_LightType](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ilightrig/set_lighttype/) för att definiera 3D‑rotationen.
1. Spara presentationen.

```cpp
// Skapa en instans av Presentation-klassen.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_TextFrame()->set_Text(u"Hello, Aspose!");

shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// Spara presentationen som en PPTX-fil.
presentation->Save(u"3D_rotation_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Resultatet:

![3D‑rotations‑effekten](3D-rotation-effect.png)

## **Återställ formatering**

Följande C++‑kod visar hur man återställer formateringen av en bild och återställer position, storlek och formatering för alla former med platshållare på [LayoutSlide] till dess standardinställningar:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // Återställ varje form på bilden som har en platshållare på layouten.
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Påverkar formatering av former den slutliga presentationsfilens storlek?**

Endast marginellt. Inbäddade bilder och media upptar större delen av filstorleken, medan formparametrar som färger, effekter och gradienter lagras som metadata och tillför i praktiken ingen extra storlek.

**Hur kan jag upptäcka former på en bild som har identisk formatering så att jag kan gruppera dem?**

Jämför varje forms viktigaste formateringsegenskaper—fyllning, linje och effektinställningar. Om alla motsvarande värden matchar, behandla deras stilar som identiska och gruppera logiskt dessa former, vilket förenklar senare stilhantering.

**Kan jag spara en uppsättning anpassade formstilar i en separat fil för återanvändning i andra presentationer?**

Ja. Spara exempelformer med önskade stilar i en mall‑bildspelsuppsättning eller en .POTX‑mallfil. När du skapar en ny presentation, öppna mallen, klona de former du behöver och återapplicera deras formatering där det behövs.