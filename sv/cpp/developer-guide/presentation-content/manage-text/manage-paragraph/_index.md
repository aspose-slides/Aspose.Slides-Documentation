---
title: Hantera PowerPoint-textstycken i C++
linktitle: Hantera stycke
type: docs
weight: 40
url: /sv/cpp/manage-paragraph/
aliases:
  - /cpp/paragraph/
  - /cpp/portion/
keywords:
- lägga till text
- lägga till stycke
- hantera text
- hantera stycke
- hantera punkt
- styckeindrag
- hängande indrag
- styckepunkt
- numrerad lista
- punktlista
- styckeegenskaper
- importera HTML
- text till HTML
- stycke till HTML
- stycke till bild
- text till bild
- exportera stycke
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Lär dig hur du skapar och formaterar stycken, portioner, punkter, numrerade listor, indrag, HTML-innehåll och styckebilder med Aspose.Slides för C++."
---
## **Översikt**

Aspose.Slides för C++ representerar text som en hierarki av textramar, stycken och portioner:

* [ITextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/) representerar textbehållaren i en form och ger åtkomst till dess samling av stycken.
* [IParagraph](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraph/) representerar ett stycke i en textram och ger åtkomst till dess portioner och formatering på stycknivå.
* [IPortion](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iportion/) representerar en textsekvens inom ett stycke. Varje portion kan ha sin egen text och teckenformatering.

Ett stycke kan därför innehålla text med olika typsnitt, färger, storlekar och annan formatering genom att använda flera portioner.

## **Skapa och formatera stycken**

### **Skapa stycken med flera portioner**

Följande steg skapar en textram med tre stycken, där varje stycke innehåller tre portioner:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/).
2. Hämta referensen till den aktuella bilden via dess index.
3. Lägg till en rektangulär [IAutoShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/) på bilden.
4. Hämta formens [ITextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/).
5. Använd standardstycket och lägg till två ytterligare [IParagraph](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraph/)‑objekt i textramen.
6. Lägg till tillräckligt med [IPortion](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iportion/)‑objekt så att varje stycke innehåller tre portioner. Standardstycket innehåller redan en tom portion.
7. Ange texten för varje portion.
8. Tillämpa teckenformatering via [IPortion::get_PortionFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iportion/get_portionformat/).
9. Spara den ändrade presentationen.

Detta C++‑exempel implementerar stegen:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
auto textFrame = shape->get_TextFrame();

auto firstParagraph = textFrame->get_Paragraph(0);
firstParagraph->get_Portions()->Add(MakeObject<Portion>());
firstParagraph->get_Portions()->Add(MakeObject<Portion>());

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_Portions()->Add(MakeObject<Portion>());
secondParagraph->get_Portions()->Add(MakeObject<Portion>());
secondParagraph->get_Portions()->Add(MakeObject<Portion>());
textFrame->get_Paragraphs()->Add(secondParagraph);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->get_Portions()->Add(MakeObject<Portion>());
thirdParagraph->get_Portions()->Add(MakeObject<Portion>());
thirdParagraph->get_Portions()->Add(MakeObject<Portion>());
textFrame->get_Paragraphs()->Add(thirdParagraph);

auto paragraphCount = textFrame->get_Paragraphs()->get_Count();
for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    auto paragraph = textFrame->get_Paragraph(paragraphIndex);
    auto portionCount = paragraph->get_Portions()->get_Count();
    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        auto portion = paragraph->get_Portion(portionIndex);
        portion->set_Text(String::Format(u"Portion {0}.{1}", paragraphIndex + 1, portionIndex + 1));
        auto portionFormat = portion->get_PortionFormat();

        if (portionIndex == 0)
        {
            portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
            portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
            portionFormat->set_FontBold(NullableBool::True);
            portionFormat->set_FontHeight(15);
        }
        else if (portionIndex == 1)
        {
            portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
            portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
            portionFormat->set_FontItalic(NullableBool::True);
            portionFormat->set_FontHeight(18);
        }
    }
}

presentation->Save(u"paragraphs_with_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Skapa punkt- och numrerade listor**

### **Skapa en punkt- eller numrerad lista**

Punkter och numrering gör relaterade objekt enklare att skanna. I Aspose.Slides definieras listinställningar via [IBulletFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ibulletformat/).

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/).
2. Hämta referensen till den aktuella bilden via dess index.
3. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/) på den valda bilden.
4. Hämta formens [ITextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/).
5. Ta bort standardstycket från textramen.
6. Skapa ett [Paragraph](https://reference.aspose.com/slides/sv/cpp/aspose.slides/paragraph/) för en symbolpunkt.
7. Ställ in [IBulletFormat::set_Type](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ibulletformat/set_type/) till [BulletType::Symbol](https://reference.aspose.com/slides/sv/cpp/aspose.slides/bullettype/) och ange punkttecknet.
8. Ange styckets text, indrag, punktfärg och punktens höjd.
9. Lägg till stycket i textramen.
10. Skapa ett andra stycke och ställ in [IBulletFormat::set_Type](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ibulletformat/set_type/) till [BulletType::Numbered](https://reference.aspose.com/slides/sv/cpp/aspose.slides/bullettype/).
11. Konfigurera den numrerade punktstilen och lägg till stycket i textramen.
12. Spara presentationen.

```cpp
#include <DOM/BulletType.h>
#include <DOM/ColorType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/NullableBool.h>
#include <DOM/NumberedBulletStyle.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/convert.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto symbolParagraph = MakeObject<Paragraph>();
symbolParagraph->set_Text(u"Welcome to Aspose.Slides");
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(Convert::ToChar(0x2022));
symbolParagraph->get_ParagraphFormat()->set_Indent(25);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);
textFrame->get_Paragraphs()->Add(symbolParagraph);

auto numberedParagraph = MakeObject<Paragraph>();
numberedParagraph->set_Text(u"This is a numbered item");
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle(NumberedBulletStyle::BulletCircleNumWDBlackPlain);
numberedParagraph->get_ParagraphFormat()->set_Indent(25);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);
textFrame->get_Paragraphs()->Add(numberedParagraph);

presentation->Save(u"bulleted_and_numbered_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Använd bildpunkter**

Bildpunkter låter dig använda en egen bild istället för en symbol eller ett tal.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/).
2. Hämta referensen till den aktuella bilden via dess index.
3. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/) och hämta dess [ITextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/).
4. Ta bort standardstycket från textramen.
5. Läs in bildpunkten och lägg till den i presentationens bildsamling som en [IPPImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ippimage/).
6. Skapa ett [Paragraph](https://reference.aspose.com/slides/sv/cpp/aspose.slides/paragraph/) och ange dess text.
7. Ställ in [IBulletFormat::set_Type](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ibulletformat/set_type/) till [BulletType::Picture](https://reference.aspose.com/slides/sv/cpp/aspose.slides/bullettype/).
8. Tilldela bilden via [ISlidesPicture::set_Image](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidespicture/set_image/) och ange punktens höjd.
9. Lägg till stycket i textramen.
10. Spara den ändrade presentationen.

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto bulletImage = Images::FromFile(u"bullets.png");
auto presentationImage = presentation->get_Images()->AddImage(bulletImage);
bulletImage->Dispose();

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph = MakeObject<Paragraph>();
paragraph->set_Text(u"Welcome to Aspose.Slides");
paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Picture);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Picture()->set_Image(presentationImage);
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);
textFrame->get_Paragraphs()->Add(paragraph);

presentation->Save(u"picture_bullet.pptx", SaveFormat::Pptx);
presentation->Save(u"picture_bullet.ppt", SaveFormat::Ppt);
presentation->Dispose();
```

### **Skapa en flernivålista**

Ställ in [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraphformat/set_depth/) för att placera stycken på olika nivåer i en lista. Toppnivån har djup `0`.

1. Skapa en [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) och hämta en bild.
2. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/) och rensa standardstycket från dess textram.
3. Skapa fyra stycken och konfigurera deras punkt‑symboler.
4. Ställ in deras [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraphformat/set_depth/) värden till `0`, `1`, `2` och `3`.
5. Lägg till styckena i textramen och spara presentationen.

```cpp
#include <DOM/BulletType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/convert.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"Content");
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(Convert::ToChar(0x2022));
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->get_ParagraphFormat()->set_Depth(0);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"Second level");
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(u'-');
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->get_ParagraphFormat()->set_Depth(1);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->set_Text(u"Third level");
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(Convert::ToChar(0x2022));
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
thirdParagraph->get_ParagraphFormat()->set_Depth(2);

auto fourthParagraph = MakeObject<Paragraph>();
fourthParagraph->set_Text(u"Fourth level");
fourthParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
fourthParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(u'-');
fourthParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
fourthParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
fourthParagraph->get_ParagraphFormat()->set_Depth(3);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);
textFrame->get_Paragraphs()->Add(thirdParagraph);
textFrame->get_Paragraphs()->Add(fourthParagraph);

presentation->Save(u"multilevel_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Starta numrerade listobjekt med egna värden**

Använd [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) för att ange det första nummer som visas för ett numrerat stycke.

1. Skapa en [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) och lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/) på en bild.
2. Rensa standardstycket från formens textram.
3. Skapa tre numrerade stycken.
4. Ställ in [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) till `2`, `3` och `7` för respektive stycke.
5. Lägg till styckena i textramen och spara presentationen.

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"Start at 2");
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStartWith(2);
textFrame->get_Paragraphs()->Add(firstParagraph);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"Start at 3");
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStartWith(3);
textFrame->get_Paragraphs()->Add(secondParagraph);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->set_Text(u"Start at 7");
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStartWith(7);
textFrame->get_Paragraphs()->Add(thirdParagraph);

presentation->Save(u"custom_numbered_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Kontrollera styckeutformning och slutegenskaper**

### **Ställ in ett indrag för första raden**

Använd [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraphformat/set_indent/) för att kontrollera indraget för första raden i ett stycke. Denna metod flyttar endast den första raden i förhållande till styckets vänstra marginal. Ett positivt värde förflyttar första raden åt höger, medan de övriga raderna förblir justerade med styckeinnehållet.

Använd [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraphformat/set_marginleft/) när du behöver flytta hela stycket. Använd [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraphformat/set_indent/) när du bara behöver flytta den första raden.

Exemplet nedan skapar flera stycken och tillämpar olika [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraphformat/set_indent/)‑värden för att demonstrera hur indraget för första raden påverkar styckeutformningen.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/).
2. Hämta målbilden.
3. Lägg till en rektangulär [IAutoShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/) på bilden.
4. Hämta formens [ITextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/) och ta bort standardstycket.
5. Skapa flera stycken och ange olika [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraphformat/set_indent/)‑värden för dem.
6. Lägg till styckena i textramen.
7. Spara den ändrade presentationen.

Denna kod visar hur du anger ett styckeindrag:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"No first-line indent. Wrapped lines start at the same position as the first line.");
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->get_ParagraphFormat()->set_MarginLeft(20);
firstParagraph->get_ParagraphFormat()->set_Indent(0);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->get_ParagraphFormat()->set_MarginLeft(20);
secondParagraph->get_ParagraphFormat()->set_Indent(20);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->set_Text(u"First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
thirdParagraph->get_ParagraphFormat()->set_MarginLeft(20);
thirdParagraph->get_ParagraphFormat()->set_Indent(40);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);
textFrame->get_Paragraphs()->Add(thirdParagraph);

presentation->Save(u"paragraph_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Resultatet:

![Det första radindraget för styckena](first_line_indent.png)

### **Ställ in hängande indrag**

Ett hängande indrag är en styckeutformning där den första raden börjar till vänster om de återstående raderna. I Aspose.Slides skapar du denna effekt med [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraphformat/set_indent/). Ställ in indraget på ett negativt värde för att flytta den första raden åt vänster i förhållande till styckeinnehållet.

I praktiken definierar [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraphformat/set_marginleft/) den vänstra positionen för styckeinnehållet, och [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraphformat/set_indent/) anger positionen för den första raden relativt den marginalen. För att skapa ett hängande indrag, ange ett positivt värde för margin‑left och ett negativt värde för indent.

Denna formatering är användbar för bibliografier, referenser, förklaringsordboksposter och andra stycken där radbrytningar ska justeras under styckeinnehållet snarare än under första tecknet i den första raden.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/).
2. Hämta målbilden.
3. Lägg till en rektangulär [IAutoShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/) på bilden.
4. Hämta formens [ITextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/) och ta bort standardstycket.
5. Skapa stycken och ange ett positivt [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraphformat/set_marginleft/)‑värde för varje stycke.
6. Ange ett negativt [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraphformat/set_indent/)‑värde för att skapa hängande indrag.
7. Lägg till styckena i textramen.
8. Spara den ändrade presentationen.

Denna kod visar hur du anger ett hängande indrag för ett stycke:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->get_ParagraphFormat()->set_MarginLeft(40);
firstParagraph->get_ParagraphFormat()->set_Indent(-20);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->get_ParagraphFormat()->set_MarginLeft(60);
secondParagraph->get_ParagraphFormat()->set_Indent(-30);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);

presentation->Save(u"hanging_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Resultatet:

![Det hängande indraget för styckena](hanging_indent.png)

### **Ställ in egenskaper för slutförande av stycke**

[IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) styr formateringen av styckets slutmarkering. Följande exempel tilldelar en teckenstorlek och ett latin‑typsnitt till slutmarkeringen för det andra stycket:

1. Läs in en [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) och hämta en bild.
2. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/) och rensa dess standardstycke.
3. Skapa två stycken och lägg till textportioner i dem.
4. Skapa ett [PortionFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/portionformat/) för det andra styckets slutmarkering.
5. Ange [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ibaseportionformat/set_fontheight/) och [IBasePortionFormat::set_LatinFont](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ibaseportionformat/set_latinfont/).
6. Tilldela formatet med [IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) och spara presentationen.

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/PortionFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Test.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->get_Portions()->Add(MakeObject<Portion>(u"Sample text"));

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_Portions()->Add(MakeObject<Portion>(u"Sample text 2"));

auto endParagraphFormat = MakeObject<PortionFormat>();
endParagraphFormat->set_FontHeight(48);
endParagraphFormat->set_LatinFont(MakeObject<FontData>(u"Times New Roman"));
secondParagraph->set_EndParagraphPortionFormat(endParagraphFormat);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);

presentation->Save(u"end_paragraph_format.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Importera och exportera styckeinnehåll**

### **Importera HTML‑text till stycken**

Använd [IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraphcollection/addfromhtml/) för att konvertera HTML‑markup till stycken och portioner i en textram.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/).
2. Hämta en bild och lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/).
3. Hämta formens [ITextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/) och rensa dess standardstycke.
4. Läs in käll‑HTML‑filen.
5. Skicka HTML‑strängen till [IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraphcollection/addfromhtml/).
6. Spara den ändrade presentationen.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/stream_reader.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto slideSize = presentation->get_SlideSize()->get_Size();
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, slideSize.get_Width() - 20, slideSize.get_Height() - 20);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->get_Paragraphs()->Clear();

auto reader = MakeObject<StreamReader>(u"file.html");
auto html = reader->ReadToEnd();
reader->Close();
shape->get_TextFrame()->get_Paragraphs()->AddFromHtml(html);

presentation->Save(u"html_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Exportera stycketext till HTML**

Använd [IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraphcollection/exporttohtml/) för att exportera ett valt område av stycken som HTML.

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)‑klassen och läs in den önskade presentationen.
2. Hämta bilden och hitta den [IAutoShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/) som innehåller texten.
3. Hämta formens [ITextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/).
4. Anropa [IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraphcollection/exporttohtml/) med start‑styckeindexet och antalet stycken som ska exporteras.
5. Skriv den returnerade HTML‑strängen till en fil.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/stream_writer.h>
#include <system/object_ext.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;
using namespace System::Text;

auto presentation = MakeObject<Presentation>(u"ExportingHTMLText.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto textShape = AsCast<IAutoShape>(shape);

if (textShape != nullptr && textShape->get_TextFrame() != nullptr)
{
    auto paragraphs = textShape->get_TextFrame()->get_Paragraphs();
    auto html = paragraphs->ExportToHtml(0, paragraphs->get_Count(), nullptr);
    auto writer = MakeObject<StreamWriter>(u"paragraphs.html", false, Encoding::get_UTF8());
    writer->Write(html);
    writer->Close();
}
else
{
    Console::WriteLine(u"The first shape is not a text shape.");
}

presentation->Dispose();
```

### **Rendera ett stycke som en bild**

[IParagraph::GetImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraph/getimage/) renderar ett enskilt stycke direkt och returnerar en [IImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iimage/). Spara resultatet till en fil eller ström med [IImage::Save](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iimage/save/). Du behöver inte rendera den omgivande formen eller beskära en bitmap manuellt.

[IParagraph::GetImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraph/getimage/) kan returnera `nullptr` om stycket inte kan hittas i sin föräldrakollektion, saknar giltiga renderingsgränser eller inte kan renderas. Kontrollera resultatet innan du sparar det och släpp den returnerade bilden efter användning.

#### **Rendera ett stycke i standardskala**

Anta att vi har en presentationsfil som heter sample.pptx med en bild, där den första formen är en textruta som innehåller tre stycken.

![Textrutan med tre stycken](paragraph_to_image_input.png)

Följande exempel renderar det andra stycket i en vanlig textram i standardskala och sparar den returnerade bilden i PNG‑format.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto textShape = AsCast<IAutoShape>(shape);

if (textShape != nullptr && textShape->get_TextFrame() != nullptr && textShape->get_TextFrame()->get_Paragraphs()->get_Count() > 1)
{
    auto paragraph = textShape->get_TextFrame()->get_Paragraph(1);
    auto paragraphImage = paragraph->GetImage();

    if (paragraphImage != nullptr)
    {
        paragraphImage->Save(u"paragraph.png", ImageFormat::Png);
        paragraphImage->Dispose();
    }
    else
    {
        Console::WriteLine(u"The paragraph could not be rendered.");
    }
}
else
{
    Console::WriteLine(u"The expected text shape or paragraph was not found.");
}

presentation->Dispose();
```

Resultatet:

![Stycke‑bild](paragraph_to_image_output.png)

#### **Rendera ett stycke i en tabellcell med skalning**

Använd [IParagraph::GetImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraph/getimage/)‑överladdningen som accepterar parametrarna `float scaleX` och `float scaleY` för att ange horisontella och vertikala skalningsfaktorer.

Följande exempel skapar en tabell, renderar stycket i dess första cell med dubbla standardbredd och -höjd, och sparar resultatet som en PNG‑bild.

```cpp
#include <DOM/IParagraph.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/array.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto scaleX = 2.0f;
auto scaleY = 2.0f;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto table = slide->get_Shapes()->AddTable(50, 50, MakeArray<double>({300}), MakeArray<double>({80}));
auto paragraph = table->idx_get(0, 0)->get_TextFrame()->get_Paragraph(0);
paragraph->set_Text(u"Text in a table cell");

auto paragraphImage = paragraph->GetImage(scaleX, scaleY);
if (paragraphImage != nullptr)
{
    paragraphImage->Save(u"table_paragraph.png", ImageFormat::Png);
    paragraphImage->Dispose();
}
else
{
    Console::WriteLine(u"The paragraph could not be rendered.");
}

presentation->Dispose();
```

En skalningsfaktor på `1` behåller den axeln i sin standardpixelstorlek. Till exempel ger `2` för båda faktorerna en bild vars bredd och höjd är ungefär dubbelt så stora som standardmåtten, vilket ger fyra gånger så många pixlar. Större faktorer ger vanligtvis skarpare text för zoomning eller högupplöst utskrift, men de ökar även minnesanvändning och filstorlek. Faktorer under `1` ger mindre bilder med mindre detalj. Använd lika faktorer för att bevara styckets bildförhållande; olika horisontella och vertikala faktorer sträcker utskriften oberoende.

Att rendera en hel form med [IShape::GetImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/getimage/) är fortfarande användbart när utskriften måste inkludera formens fyllning, kantlinje eller annan visuell kontext. För enbart styckebild, använd [IParagraph::GetImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraph/getimage/).

## **FAQ**

**Kan jag helt inaktivera radbrytning i en textram?**

Ja. Använd [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframeformat/set_wraptext/) för att inaktivera radbrytning så att raderna inte bryts vid textrammens kanter.

**Hur kan jag få de exakta gränserna på bilden för ett specifikt stycke?**

Använd [IParagraph::GetRect](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraph/getrect/) för att hämta styckets inneslutande rektangel. [IPortion::GetRect](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iportion/getrect/) ger gränserna för en enskild portion.

**Var styrs styckejusteringen (vänster, höger, centrerad eller blockjusterad)?**

[IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraphformat/set_alignment/) är en inställning på stycknivå och tillämpas på hela stycket oavsett individuell portionsformatering.

**Kan jag ange språkgranskning för en del av ett stycke?**

Ja. Använd [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ibaseportionformat/set_languageid/) för enskilda portioner, så att ett stycke kan innehålla text på flera språk.