---
title: Lägg till vattenmärken i presentationer i C++
linktitle: Vattenmärke
type: docs
weight: 40
url: /sv/cpp/watermark/
keywords:
- vattenmärke
- textvattenmärke
- bildvattenmärke
- lägg till vattenmärke
- ändra vattenmärke
- ta bort vattenmärke
- radera vattenmärke
- lägg till vattenmärke till PPT
- lägg till vattenmärke till PPTX
- lägg till vattenmärke till ODP
- ta bort vattenmärke från PPT
- ta bort vattenmärke från PPTX
- ta bort vattenmärke från ODP
- radera vattenmärke från PPT
- radera vattenmärke från PPTX
- radera vattenmärke från ODP
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Hantera text‑ och bildvattenmärken i PowerPoint‑ och OpenDocument‑presentationer i C++ för att ange ett utkast, konfidentiell information, upphovsrätt och mer."
---
## **Introduktion**

**Ett vattenmärke** i en presentation är en text‑ eller bildstämpling som används på en bild eller på alla bilder i presentationen. Vanligtvis används ett vattenmärke för att ange att presentationen är ett utkast (t.ex. ett vattenmärke “Utkast”), att den innehåller konfidentiell information (t.ex. ett vattenmärke “Konfidentiell”), för att specificera vilket företag den tillhör (t.ex. ett vattenmärke “Företagsnamn”), för att identifiera författaren till presentationen osv. Ett vattenmärke hjälper till att förhindra upphovsrättsintrång genom att visa att presentationen inte får kopieras. Vattenmärken används i både PowerPoint‑ och OpenOffice‑format. I Aspose.Slides kan du lägga till ett vattenmärke i PowerPoint‑filerna PPT, PPTX och OpenOffice‑filformatet ODP.

I [**Aspose.Slides**](https://products.aspose.com/slides/sv/cpp/) finns det flera sätt att skapa vattenmärken i PowerPoint‑ eller OpenOffice‑dokument och att ändra deras design och beteende. Den gemensamma nämnaren är att för att lägga till textvattenmärken bör du använda gränssnittet [ITextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/), och för att lägga till bildvattenmärken använder du klassen [PictureFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/pictureframe/) eller fyller en vattenmärkesform med en bild. `PictureFrame` implementerar gränssnittet [IShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/), vilket gör att du kan använda alla flexibla inställningar för formobjektet. Eftersom `ITextFrame` inte är en form och dess inställningar är begränsade, omsluts den i ett [IShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/)-objekt.

Det finns två sätt att applicera ett vattenmärke: på en enskild bild eller på alla presentationsbilder. Slide Master används för att applicera ett vattenmärke på alla bilder — vattenmärket läggs till i Slide Master, designas helt där och appliceras på alla bilder utan att påverka möjligheten att ändra vattenmärket på enskilda bilder.

Ett vattenmärke anses vanligtvis vara otillgängligt för redigering av andra användare. För att förhindra att vattenmärket (eller snarare vattenmärket föräldraform) redigeras, erbjuder Aspose.Slides låsningsfunktion för former. En specifik form kan låsas på en normal bild eller på en Slide Master. När vattenmärkesformen låses på Slide Master låses den på alla presentationsbilder.

Du kan tilldela ett namn till vattenmärket så att du i framtiden, om du vill ta bort det, kan hitta det bland bildens former med hjälp av namnet.

Du kan designa vattenmärket på vilket sätt som helst; dock finns det vanliga egenskaper i vattenmärken, såsom centrering, rotation, placering framåt osv. Vi kommer att titta på hur man använder dessa i exemplen nedan.

## **Textvattenmärke**

### **Lägg till ett textvattenmärke på en bild**

För att lägga till ett textvattenmärke i PPT, PPTX eller ODP kan du först lägga till en form på bilden och sedan lägga till en textruta i den formen. Textrutan representeras av gränssnittet [ITextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/). Denna typ är intevsidd från [IShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/), som har ett brett urval av egenskaper för att positionera vattenmärket på ett flexibelt sätt. Därför omsluts [ITextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/)-objektet i ett [IAutoShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/)-objekt. För att lägga till vattenmärketext i formen använder du metoden [AddTextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/addtextframe/) som visas nedan.

```cpp
auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="primary" title="Se även" %}} 
- [Hur man använder TextFrame-klassen](/slides/sv/cpp/text-formatting/)
{{% /alert %}}

### **Lägg till ett textvattenmärke i en presentation**

Om du vill lägga till ett textvattenmärke i hela presentationen (dvs. alla bilder på en gång) lägger du till det i [MasterSlide](https://reference.aspose.com/slides/sv/cpp/aspose.slides/masterslide/). Resten av logiken är densamma som när du lägger till ett vattenmärke på en enskild bild — skapa ett [IAutoShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/)-objekt och lägg sedan till vattenmärket med metoden [AddTextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/addtextframe/).

```cpp
auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);

auto watermarkShape = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="primary" title="Se även" %}} 
- [Hur man använder Slide Master](/slides/sv/cpp/slide-master/)
{{% /alert %}}

### **Ställ in vattenmärkesformens transparens**

Som standard är rektangelformen stilad med fyllnings‑ och linjefärger. Följande kodrader gör formen transparent.

```cpp
watermarkShape->get_FillFormat()->set_FillType(FillType::NoFill);
watermarkShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
```

### **Ställ in teckensnittet för ett textvattenmärke**

Du kan ändra teckensnittet för textvattenmärket enligt nedan.

```cpp
auto textFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
textFormat->set_LatinFont(MakeObject<FontData>(u"Arial"));
textFormat->set_FontHeight(50);
```

### **Ställ in färgen för vattenmärketexten**

För att ange färgen på vattenmärketexten använder du följande kod:

```cpp
auto alpha = 150, red = 200, green = 200, blue = 200;

auto fillFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Solid);
fillFormat->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, red, green, blue));
```

### **Centrera ett textvattenmärke**

Det är möjligt att centrera vattenmärket på en bild, och för det kan du göra följande:

```cpp
auto slideSize = presentation->get_SlideSize()->get_Size();

auto watermarkWidth = 400;
auto watermarkHeight = 40;
auto watermarkX = (slideSize.get_Width() - watermarkWidth) / 2;
auto watermarkY = (slideSize.get_Height() - watermarkHeight) / 2;

auto watermarkShape = slide->get_Shapes()->AddAutoShape(
    ShapeType::Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);
```

Bilden nedan visar slutresultatet.

![The text watermark](text_watermark.png)

## **Bildvattenmärke**

### **Lägg till ett bildvattenmärke i en presentation**

För att lägga till ett bildvattenmärke på en presentationsbild kan du göra följande:

```cpp
auto imageStream = File::ReadAllBytes(u"watermark.png");
auto image = presentation->get_Images()->AddImage(imageStream);

watermarkShape->get_FillFormat()->set_FillType(FillType::Picture);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
```

## **Lås ett vattenmärke mot redigering**

Om det är nödvändigt att förhindra att ett vattenmärke redigeras använder du metoden [IAutoShape::get_AutoShapeLock](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/get_autoshapelock/) på formen. Med den här egenskapen kan du skydda formen från att väljas, storleksändras, flyttas, grupperas med andra element, låsa dess text mot redigering och mycket mer:

```cpp
// Lås vattenmärkesformen från att modifieras
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->SizeLocked(true);
watermarkShape->get_AutoShapeLock()->TextLocked(true);
watermarkShape->get_AutoShapeLock()->PositionLocked(true);
watermarkShape->get_AutoShapeLock()->GroupingLocked(true);
```

## **Flytta ett vattenmärke till framkant**

I Aspose.Slides kan Z‑ordningen för former ställas in via metoden [IShapeCollection::Reorder](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishapecollection/reorder/). För att göra detta måste du anropa metoden från presentationsbildlistan och skicka referensen till formen samt dess ordningsnummer till metoden. På så sätt är det möjligt att föra en form till framkant eller skicka den till bakgrunden på bilden. Denna funktion är särskilt användbar om du behöver placera ett vattenmärke framför resten av presentationen:

```cpp
auto shapeCount = slide->get_Shapes()->get_Count();
slide->get_Shapes()->Reorder(shapeCount - 1, watermarkShape);
```

## **Ställ in vattenmärkesrotation**

Här är ett kodexempel som visar hur du justerar rotationen av vattenmärket så att det placeras diagonalt över bilden:

```cpp
auto diagonalAngle = Math::Atan((slideSize.get_Height() / slideSize.get_Width())) * 180 / Math::PI;

watermarkShape->set_Rotation((float)diagonalAngle);
```

## **Tilldela ett namn till ett vattenmärke**

Aspose.Slides låter dig ange namn på en form. Genom att använda formens namn kan du i framtiden komma åt den för att ändra eller ta bort den. För att tilldela namn till vattenmärkesformen använder du metoden [IAutoShape::set_Name](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/set_name/):

```cpp
watermarkShape->set_Name(u"watermark");
```

## **Ta bort ett vattenmärke**

För att ta bort vattenmärkesformen använder du metoden [IAutoShape::get_Name](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/get_name/) för att hitta den bland bildens former. Därefter skickar du vattenmärkesformen till metoden [IShapeCollection::Remove](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishapecollection/remove/):

```cpp
auto slideShapes = slide->get_Shapes()->ToArray();
for(auto shape : slideShapes)
{
    if (String::Compare(shape->get_Name(), u"watermark", StringComparison::Ordinal) == 0)
    {
        slide->get_Shapes()->Remove(watermarkShape);
    }
}
```

## **Ett levande exempel**

Du kan vilja prova de **gratis** Aspose.Slides‑verktygen [Add Watermark](https://products.aspose.app/slides/sv/watermark) och [Remove Watermark](https://products.aspose.app/slides/sv/watermark/remove-watermark) online.

![Online tools to add and remove watermarks](online_tools.png)

## **FAQ**

**Vad är ett vattenmärke och varför ska jag använda det?**

Ett vattenmärke är ett text‑ eller bildöverlägg som appliceras på bilder och hjälper till att skydda immateriell egendom, stärka varumärkesigenkänning eller förhindra obehörig användning av presentationer.

**Kan jag lägga till ett vattenmärke på alla bilder i en presentation?**

Ja, Aspose.Slides låter dig programatiskt lägga till ett vattenmärke på varje bild i en presentation. Du kan iterera igenom alla bilder och applicera vattenmärkesinställningarna individuellt.

**Hur kan jag justera vattenmärkets transparens?**

Du kan justera vattenmärkets transparens genom att ändra fyllningsinställningarna ([FillFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/shape/get_fillformat/)) för formen. Detta säkerställer att vattenmärket är diskret och inte stör bildens innehåll.

**Vilka bildformat stöds för vattenmärken?**

Aspose.Slides stöder olika bildformat såsom PNG, JPEG, GIF, BMP, SVG med flera.

**Kan jag anpassa teckensnitt och stil för ett textvattenmärke?**

Ja, du kan välja vilket teckensnitt, storlek och stil du vill för att matcha designen av din presentation och bibehålla varumärkeskonsekvens.

**Hur ändrar jag position eller orientering för ett vattenmärke?**

Du kan programatiskt justera position och orientering för vattenmärket genom att ändra formens koordinater, storlek och rotations‑egenskaper.