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
- lägg till vattenmärke i PPT
- lägg till vattenmärke i PPTX
- lägg till vattenmärke i ODP
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
description: "Hantera text- och bildvattenmärken i PowerPoint- och OpenDocument-presentationer i C++ för att indikera ett utkast, konfidentiell information, upphovsrätt och mer."
---
## **Introduktion**

**Ett vattenmärke** i en presentation är en text‑ eller bildstämpel som används på en bild eller på alla bilder i en presentation. Vanligtvis används ett vattenmärke för att indikera att presentationen är ett utkast (t.ex. ett ”Utkast”-vattenmärke), att den innehåller konfidentiell information (t.ex. ett ”Konfidentiellt”-vattenmärke), för att ange vilket företag den tillhör (t.ex. ett ”Företagsnamn”-vattenmärke), för att identifiera författaren till presentationen osv. Ett vattenmärke hjälper till att förhindra upphovsrättsintrång genom att visa att presentationen inte bör kopieras. Vattenmärken används både i PowerPoint‑ och OpenOffice‑presentationsformat. I Aspose.Slides kan du lägga till ett vattenmärke i PowerPoint‑filerna PPT, PPTX och OpenOffice‑filformatet ODP.

I [**Aspose.Slides**](https://products.aspose.com/slides/sv/cpp/), finns det flera sätt att skapa vattenmärken i PowerPoint‑ eller OpenOffice‑dokument och att ändra deras utseende och beteende. Den gemensamma delen är att för att lägga till textvattenmärken ska du använda gränssnittet [ITextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/), och för att lägga till bildvattenmärken, använd klassen [PictureFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/pictureframe/) eller fyll en vattenmärkesform med en bild. `PictureFrame` implementerar gränssnittet [IShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/), vilket gör att du kan använda alla flexibla inställningar för formobjektet. Eftersom `ITextFrame` inte är en form och dess inställningar är begränsade, omsluts den i ett [IShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/)-objekt.

Det finns två sätt att applicera ett vattenmärke: på en enskild bild eller på alla presentationsbilder. Bild‑mastern används för att applicera ett vattenmärke på alla presentationsbilder — vattenmärket läggs till i Bild‑mastern, designas där helt och appliceras på alla bilder utan att påverka möjligheten att redigera vattenmärket på enskilda bilder.

Ett vattenmärke anses vanligtvis vara otillgängligt för redigering av andra användare. För att förhindra att vattenmärket (eller snarare vattenmärkets föräldraform) redigeras, erbjuder Aspose.Slides funktionalitet för låsning av former. En specifik form kan låsas på en normal bild eller på en Bild‑master. När vattenmärkesformen låses på Bild‑mastern, låses den på alla presentationsbilder.

Du kan ange ett namn på vattenmärket så att du i framtiden, om du vill ta bort det, kan hitta det i bildens former efter namn.

Du kan designa vattenmärket på vilket sätt som helst; det finns dock vanliga egenskaper i vattenmärken, såsom centrering, rotation, framre position osv. Vi kommer att titta på hur man använder dessa i exemplen nedan.

## **Textvattenmärke**

### **Lägg till ett textvattenmärke på en bild**

För att lägga till ett textvattenmärke i PPT, PPTX eller ODP kan du först lägga till en form på bilden och sedan lägga till en textram i den formen. Textramen representeras av gränssnittet [ITextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/). Denna typ är inte ärvd från [IShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/), som har ett brett urval av egenskaper för att placera vattenmärket på ett flexibelt sätt. Därför omsluts [ITextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/)-objektet i ett [IAutoShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/)-objekt. För att lägga till vattenmärkestext till formen, använd metoden [AddTextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/addtextframe/) som visas nedan.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="info" title="Se också" %}} 
- [Hur man använder TextFrame-klassen](/slides/sv/cpp/text-formatting/)
{{% /alert %}}

### **Lägg till ett textvattenmärke i en presentation**

Om du vill lägga till ett textvattenmärke i hela presentationen (dvs. alla bilder på en gång), lägg till det i [MasterSlide](https://reference.aspose.com/slides/sv/cpp/aspose.slides/masterslide/). Resten av logiken är densamma som när du lägger till ett vattenmärke på en enskild bild — skapa ett [IAutoShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/)-objekt och lägg sedan till vattenmärket med metoden [AddTextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/addtextframe/).

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);

auto watermarkShape = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="info" title="Se också" %}} 
- [Hur man använder Bild‑mastern](/slides/sv/cpp/slide-master/)
{{% /alert %}}

### **Ställ in transparens för vattenmärkesformen**

Som standard är rektangelformen formaterad med fyllnings‑ och linjefärger. Följande kodrad gör formen genomskinlig.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

watermarkShape->get_FillFormat()->set_FillType(FillType::NoFill);
watermarkShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
```

### **Ställ in typsnitt för ett textvattenmärke**

Du kan ändra typsnittet för textvattenmärket som visas nedan.

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(u"CONFIDENTIAL");

auto textFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
textFormat->set_LatinFont(MakeObject<FontData>(u"Arial"));
textFormat->set_FontHeight(50);
```

### **Ställ in färg för vattenmärkestext**

För att ange färgen på vattenmärkestexten, använd följande kod:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(u"CONFIDENTIAL");

auto alpha = 150, red = 200, green = 200, blue = 200;

auto fillFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Solid);
fillFormat->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, red, green, blue));
```

### **Centrera ett textvattenmärke**

Det är möjligt att centrera vattenmärket på en bild, och för att göra det kan du göra följande:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

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
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

auto imageStream = File::ReadAllBytes(u"watermark.png");
auto image = presentation->get_Images()->AddImage(imageStream);

watermarkShape->get_FillFormat()->set_FillType(FillType::Picture);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
```

## **Lås ett vattenmärke från redigering**

Om det är nödvändigt att förhindra att ett vattenmärke redigeras, använd metoden [IAutoShape::get_AutoShapeLock](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/get_autoshapelock/) på formen. Med denna egenskap kan du skydda formen från att väljas, ändra storlek, flyttas, grupperas med andra element, låsa dess text från redigering och mycket mer:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IAutoShapeLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

// Lås vattenmärkesformen från att ändras
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->set_SizeLocked(true);
watermarkShape->get_AutoShapeLock()->set_TextLocked(true);
watermarkShape->get_AutoShapeLock()->set_PositionLocked(true);
watermarkShape->get_AutoShapeLock()->set_GroupingLocked(true);
```

## **Flytta ett vattenmärke framåt**

I Aspose.Slides kan Z‑ordningen för former ställas in via metoden [IShapeCollection::Reorder](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishapecollection/reorder/). För att göra detta måste du anropa metoden från presentationsbildlistan och skicka referensen till formen samt dess ordningsnummer till metoden. På så sätt är det möjligt att föra en form framåt eller skicka den bakåt på bilden. Denna funktion är särskilt användbar om du behöver placera ett vattenmärke framför presentationen:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

auto shapeCount = slide->get_Shapes()->get_Count();
slide->get_Shapes()->Reorder(shapeCount - 1, watermarkShape);
```

## **Ställ in rotation för vattenmärke**

Här är ett kodexempel på hur du justerar rotationen av vattenmärket så att det placeras diagonalt över bilden:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/size_f.h>
#include <system/math.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto slideSize = presentation->get_SlideSize()->get_Size();

auto diagonalAngle = Math::Atan((slideSize.get_Height() / slideSize.get_Width())) * 180 / Math::PI;

watermarkShape->set_Rotation((float)diagonalAngle);
```

## **Ange ett namn för ett vattenmärke**

Aspose.Slides låter dig ange ett namn på en form. Genom att använda formens namn kan du i framtiden komma åt den för att ändra eller ta bort den. För att ange namn på vattenmärkesformen, tilldela det via metoden [IAutoShape::set_Name](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/set_name/):

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

watermarkShape->set_Name(u"watermark");
```

## **Ta bort ett vattenmärke**

För att ta bort vattenmärkesformen, använd metoden [IAutoShape::get_Name](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/get_name/) för att hitta den i bildens former. Passa sedan vattenmärkesformen till metoden [IShapeCollection::Remove](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishapecollection/remove/):

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation_with_watermark.pptx");
auto slide = presentation->get_Slide(0);

auto slideShapes = slide->get_Shapes()->ToArray();
for(auto shape : slideShapes)
{
    if (String::Compare(shape->get_Name(), u"watermark", StringComparison::Ordinal) == 0)
    {
        slide->get_Shapes()->Remove(shape);
    }
}
```

## **Ett levande exempel**

Du kanske vill prova **Aspose.Slides free**‑verktygen [Add Watermark](https://products.aspose.app/slides/sv/watermark) och [Remove Watermark](https://products.aspose.app/slides/sv/watermark/remove-watermark) online.

![Online tools to add and remove watermarks](online_tools.png)

## **FAQ**

### Vad är ett vattenmärke och varför ska jag använda det?

Ett vattenmärke är ett text‑ eller bildöverlägg som appliceras på bilder och som hjälper till att skydda immateriella rättigheter, stärka varumärkesigenkänning eller förhindra obehörig användning av presentationer.

### Kan jag lägga till ett vattenmärke på alla bilder i en presentation?

Ja, Aspose.Slides låter dig programatiskt lägga till ett vattenmärke på varje bild i en presentation. Du kan iterera genom alla bilder och applicera vattenmärkesinställningarna individuellt.

### Hur kan jag justera transparensen för vattenmärket?

Du kan justera transparensen för vattenmärket genom att ändra fyllningsinställningarna ([FillFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/shape/get_fillformat/)) för formen. Detta säkerställer att vattenmärket är subtilt och inte distraherar från bildens innehåll.

### Vilka bildformat stöds för vattenmärken?

Aspose.Slides stöder olika bildformat såsom PNG, JPEG, GIF, BMP, SVG och fler.

### Kan jag anpassa typsnitt och stil för ett textvattenmärke?

Ja, du kan välja vilket typsnitt, storlek och stil som helst för att matcha din presentations design och upprätthålla varumärkeskonsekvens.

### Hur ändrar jag position eller orientering för ett vattenmärke?

Du kan programatiskt justera position och orientering för vattenmärket genom att ändra formens koordinater, storlek och rotations‑egenskaper.