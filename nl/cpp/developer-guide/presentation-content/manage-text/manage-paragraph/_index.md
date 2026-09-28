---
title: Beheer PowerPoint-tekst alinea's in C++
linktitle: Beheer alinea
type: docs
weight: 40
url: /nl/cpp/manage-paragraph/
aliases:
  - /cpp/paragraph/
  - /cpp/portion/
keywords:
  - tekst toevoegen
  - alinea toevoegen
  - tekst beheren
  - alinea beheren
  - opsommingsteken beheren
  - alinea-insprong
  - hangende insprong
  - alinea-opsomming
  - genummerde lijst
  - opsommingslijst
  - alinea-eigenschappen
  - HTML importeren
  - tekst naar HTML
  - alinea naar HTML
  - alinea naar afbeelding
  - tekst naar afbeelding
  - alinea exporteren
  - PowerPoint
  - presentatie
  - C++
  - Aspose.Slides
description: "Leer hoe u alinea's, porties, opsommingstekens, genummerde lijsten, insprongen, HTML-inhoud en alinea-afbeeldingen maakt en opmaakt met Aspose.Slides voor C++."
---
## **Overzicht**

Aspose.Slides voor C++ stelt tekst voor als een hiërarchie van tekstkaders, alinea's en porties:

* [ITextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/) vertegenwoordigt de tekstcontainer in een vorm en biedt toegang tot de alinea‑collectie.
* [IParagraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraph/) vertegenwoordigt één alinea in een tekstkader en biedt toegang tot de porties en alinea‑niveau opmaak.
* [IPortion](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iportion/) vertegenwoordigt een tekstdelen binnen een alinea. Elke portie kan eigen tekst en teken‑niveau opmaak hebben.

Een alinea kan dus tekst bevatten met verschillende lettertypen, kleuren, groottes en andere opmaak door meerdere porties te gebruiken.

## **Alinea's maken en opmaken**

### **Alinea's maken met meerdere porties**

De volgende stappen maken een tekstkader met drie alinea's, elk met drie porties:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/).
2. Toegang tot de referentie van de betreffende dia via de index.
3. Voeg een rechthoekige [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) toe aan de dia.
4. Toegang tot het [ITextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/) van de vorm.
5. Gebruik de standaard alinea en voeg twee extra [IParagraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraph/) objecten toe aan het tekstframe.
6. Voeg voldoende [IPortion](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iportion/) objecten toe zodat elke alinea drie porties bevat. De standaard alinea bevat al één lege portie.
7. Stel de tekst van elke portie in.
8. Pas teken‑niveau opmaak toe via [IPortion::get_PortionFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iportion/get_portionformat/).
9. Sla de aangepaste presentatie op.

Dit C++‑voorbeeld implementeert de stappen:

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

## **Opsommingstekens en genummerde lijsten maken**

### **Een opsomming of genummerde lijst maken**

Opsommingstekens en nummering maken gerelateerde items makkelijker scanbaar. In Aspose.Slides worden lijstinstellingen gedefinieerd via [IBulletFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibulletformat/).

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/).
2. Toegang tot de referentie van de betreffende dia via de index.
3. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) toe aan de geselecteerde dia.
4. Toegang tot het [ITextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/) van de vorm.
5. Verwijder de standaard alinea uit het tekstframe.
6. Maak een [Paragraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides/paragraph/) voor een symbool‑opsommingsteken.
7. Stel [IBulletFormat::set_Type](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibulletformat/set_type/) in op [BulletType::Symbol](https://reference.aspose.com/slides/nl/cpp/aspose.slides/bullettype/) en geef het opsommingsteken op.
8. Stel de alinea‑tekst, insprong, kleur van het opsommingsteken en hoogte van het opsommingsteken in.
9. Voeg de alinea toe aan het tekstframe.
10. Maak een tweede alinea en stel [IBulletFormat::set_Type](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibulletformat/set_type/) in op [BulletType::Numbered](https://reference.aspose.com/slides/nl/cpp/aspose.slides/bullettype/).
11. Configureer de genummerde opsommingstekenstijl en voeg de alinea toe aan het tekstframe.
12. Sla de presentatie op.

Dit C++‑voorbeeld maakt een symbool‑opsommingsteken en een genummerde opsomming:

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

### **Afbeeldings‑opsommingstekens gebruiken**

Afbeeldings‑opsommingstekens laten u een aangepaste afbeelding gebruiken in plaats van een symbool of getal.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/).
2. Toegang tot de referentie van de betreffende dia via de index.
3. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) toe en krijg toegang tot zijn [ITextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/).
4. Verwijder de standaard alinea uit het tekstframe.
5. Laad de opsommingsteken‑afbeelding en voeg deze toe aan de afbeeldingscollectie van de presentatie als een [IPPImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/).
6. Maak een [Paragraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides/paragraph/) en stel de tekst in.
7. Stel [IBulletFormat::set_Type](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibulletformat/set_type/) in op [BulletType::Picture](https://reference.aspose.com/slides/nl/cpp/aspose.slides/bullettype/).
8. Wijs de afbeelding toe via [ISlidesPicture::set_Image](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidespicture/set_image/) en stel de hoogte van het opsommingsteken in.
9. Voeg de alinea toe aan het tekstframe.
10. Sla de aangepaste presentatie op.

Dit C++‑voorbeeld maakt een afbeeldings‑opsommingsteken:

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

### **Een meerlagige lijst maken**

Stel [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_depth/) in om alinea's op verschillende niveaus van een lijst te plaatsen. Het bovenste niveau heeft een diepte van `0`.

1. Maak een [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) en verkrijg een dia.
2. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) toe en verwijder de standaard alinea uit het tekstframe.
3. Maak vier alinea's en configureer hun opsommingstekensymbolen.
4. Stel hun [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_depth/) waarden in op `0`, `1`, `2` en `3`.
5. Voeg de alinea's toe aan het tekstframe en sla de presentatie op.

Dit C++‑voorbeeld maakt een vierlagige opsomminglijst:

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

### **Genummerde lijstitems starten met aangepaste waarden**

Gebruik [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) om het initiële nummer voor een genummerde alinea in te stellen.

1. Maak een [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) en voeg een [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) toe aan een dia.
2. Verwijder de standaard alinea uit het tekstframe van de vorm.
3. Maak drie genummerde alinea's.
4. Stel [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) in op `2`, `3` en `7` voor de betreffende alinea's.
5. Voeg de alinea's toe aan het tekstframe en sla de presentatie op.

Dit C++‑voorbeeld kent een aangepast startnummer toe aan elke alinea:

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

## **Alinea‑lay-out en eind‑eigenschappen beheersen**

### **Eerste‑rij insprong instellen**

Gebruik [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_indent/) om de eerste‑rij‑insprong van een alinea te regelen. Deze methode verplaatst alleen de eerste regel ten opzichte van de linkermarge van de alinea. Een positieve waarde verschuift de eerste regel naar rechts, terwijl de resterende regels uitgelijnd blijven met het alinea‑lichaam.

Gebruik [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_marginleft/) wanneer u de gehele alinea wilt verplaatsen. Gebruik [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_indent/) wanneer u alleen de eerste regel wilt verplaatsen.

Het voorbeeld hieronder maakt verschillende alinea's en past verschillende [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_indent/) waarden toe om te laten zien hoe de eerste‑rij‑insprong de alinea‑lay-out beïnvloedt.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/).
2. Toegang tot de doel‑dia.
3. Voeg een rechthoekige [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) toe aan de dia.
4. Toegang tot het [ITextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/) van de vorm en verwijder de standaard alinea.
5. Maak verschillende alinea's en stel verschillende [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_indent/) waarden voor hen in.
6. Voeg de alinea's toe aan het tekstframe.
7. Sla de aangepaste presentatie op.

Deze code toont hoe u een alinea‑insprong instelt:

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

Het resultaat:

![De eerste‑rij‑insprong van de alinea's](first_line_indent.png)

### **Hangende insprong instellen**

Een hangende insprong is een alinea‑lay-out waarbij de eerste regel links van de overige regels begint. In Aspose.Slides creëert u dit effect met [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_indent/). Stel de insprong in op een negatieve waarde om de eerste regel naar links te verplaatsen ten opzichte van het alinea‑lichaam.

In de praktijk definieert [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_marginleft/) de linkse positie van het alinea‑lichaam, en [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_indent/) de positie van de eerste regel ten opzichte van die marge. Om een hangende insprong te maken, stelt u een positieve margin‑left‑waarde en een negatieve insprong‑waarde in.

Deze opmaak is nuttig voor bibliografieën, referenties, begrippenlijsten en andere alinea's waarbij ingesprongen regels onder het alinea‑lichaam moeten uitlijnen in plaats van onder het eerste teken van de eerste regel.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/).
2. Toegang tot de doel‑dia.
3. Voeg een rechthoekige [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) toe aan de dia.
4. Toegang tot het [ITextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/) van de vorm en verwijder de standaard alinea.
5. Maak alinea's en stel voor elke alinea een positieve [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_marginleft/) waarde in.
6. Stel een negatieve [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_indent/) waarde in om het hangende‑insprongeffect te creëren.
7. Voeg de alinea's toe aan het tekstframe.
8. Sla de aangepaste presentatie op.

Deze code toont hoe u een hangende insprong voor een alinea instelt:

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

presentation->Save(u"hhang_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De hangende insprong van de alinea's](hanging_indent.png)

### **Einde‑alinea‑run‑eigenschappen instellen**

[IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) regelt de opmaak van het alinea‑eindteken. Het volgende voorbeeld kent een lettergrootte en Latijnse lettertype toe aan het eindteken van de tweede alinea:

1. Laad een [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) en krijg toegang tot een dia.
2. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) toe en wis de standaard alinea.
3. Maak twee alinea's en voeg tekstporties toe.
4. Maak een [PortionFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/portionformat/) voor het eindteken van de tweede alinea.
5. Stel [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibaseportionformat/set_fontheight/) en [IBasePortionFormat::set_LatinFont](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibaseportionformat/set_latinfont/) in.
6. Ken de opmaak toe met [IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) en sla de presentatie op.

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

## **Gerenderde regels tellen**

Voor alinea‑regels die automatische afbreking en interpunctie aan het einde van een regel beïnvloeden, zie [Regelafbreking beheren](/slides/nl/cpp/text-formatting/#control-line-breaking) en [Hangende interpunctie beheren](/slides/nl/cpp/text-formatting/#control-hanging-punctuation).

Gebruik [IParagraph::GetLinesCount](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraph/getlinescount/) om het aantal regels te tellen dat een alinea na lay‑out inneemt, inclusief automatische afbreking. Dit is nuttig bij het controleren van tekengrootte en lay‑out in presentatiesjablonen.

Een alinea is één item in [ITextFrame::get_Paragraphs](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/get_paragraphs/), en kan meerdere weergegeven regels beslaan. Een expliciete regeleinde‑invoeging binnen een alinea dwingt een nieuwe regel af zonder een extra alinea te maken. Automatische afbreking maakt regels op basis van de beschikbare breedte zonder expliciete regeleinden in de tekst in te voegen. Het tellen van alinea's of regeleinde‑tekens geeft dus niet het aantal weergegeven regels.

Het volgende voorbeeld maakt een tekstelement, telt de regels, verkleint het element, en vervangt daarna de tekst door een kortere tekenreeks. Afbreking is ingeschakeld en autofit uitgeschakeld zodat de breedte van het element de afbreking bepaalt zonder automatisch te verkleinen of het element te herschalen. De afmetingen worden in points opgegeven. Ten slotte voegt het voorbeeld een extra alinea toe en telt de regeltellingen op over het hele tekstkader.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAutofitType.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_WrapText(NullableBool::True);
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::None);

auto paragraph = textFrame->get_Paragraph(0);
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(20);
paragraph->set_Text(u"This text demonstrates how automatic wrapping changes the number of rendered lines.");
Console::WriteLine(u"Original width: {0}", paragraph->GetLinesCount());

shape->set_Width(150);
Console::WriteLine(u"Narrower shape: {0}", paragraph->GetLinesCount());

paragraph->set_Text(u"Short text.");
Console::WriteLine(u"Shorter text: {0}", paragraph->GetLinesCount());

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"Another paragraph.");
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(20);
textFrame->get_Paragraphs()->Add(secondParagraph);

auto totalLineCount = 0;
for (auto currentParagraph : textFrame->get_Paragraphs())
{
    totalLineCount += currentParagraph->GetLinesCount();
}
Console::WriteLine(u"Total lines in the text frame: {0}", totalLineCount);
presentation->Dispose();
```

Met deze tekst en afmetingen verhoogt het verkleinen van het element het aantal regels, terwijl het vervangen van de tekst door de korte tekenreeks het aantal reduceert. Exacte aantallen kunnen variëren afhankelijk van beschikbaarheid en substitutie van lettertypen, lettergrootte, marges, insprong, afbreking en autofit‑instellingen. Gebruik de lettertypen en lay‑out‑instellingen die voor de doelomgeving bedoeld zijn bij het testen van een sjabloon.

Het aantal regels alleen bepaalt niet of de tekst buiten zijn container uitloopt. De beschikbare hoogte, regelhoogtes, alinea‑ en regelafstand, en autofit‑gedrag zijn eveneens van belang; zelfs één regel kan de beschikbare breedte overschrijden wanneer afbreking is uitgeschakeld.

## **Alinea‑inhoud importeren en exporteren**

### **HTML‑tekst importeren in alinea's**

Gebruik [IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphcollection/addfromhtml/) om HTML‑opmaak om te zetten naar alinea's en porties in een tekstkader.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/).
2. Toegang tot een dia en voeg een [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) toe.
3. Toegang tot het [ITextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/) van de vorm en wis de standaard alinea.
4. Lees het bron‑HTML‑bestand.
5. Geef de HTML‑string door aan [IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphcollection/addfromhtml/).
6. Sla de aangepaste presentatie op.

Dit C++‑voorbeeld importeert HTML in een tekstkader:

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

### **Alinea‑tekst exporteren naar HTML**

Gebruik [IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphcollection/exporttohtml/) om een geselecteerd bereik van alinea's als HTML te exporteren.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) en laad de gewenste presentatie.
2. Toegang tot de dia en zoek de [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) die de tekst bevat.
3. Toegang tot het [ITextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/) van de vorm.
4. Roep [IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphcollection/exporttohtml/) aan met het start‑alinea‑index en het aantal alinea's dat moet worden geëxporteerd.
5. Schrijf de geretourneerde HTML‑string naar een bestand.

Dit C++‑voorbeeld exporteert alle alinea's van het eerste tekstelement:

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

### **Een alinea weergeven als afbeelding**

[IParagraph::GetImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraph/getimage/) rendert een individuele alinea rechtstreeks en retourneert een [IImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iimage/). Sla het resultaat op een bestand of stream op met [IImage::Save](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iimage/save/). Het is niet nodig om de omvattende vorm te renderen of handmatig een bitmap bij te snijden.

[IParagraph::GetImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraph/getimage/) kan `nullptr` retourneren als de alinea niet gevonden wordt in de bovenliggende collectie, geen geldige render‑grenzen heeft, of niet kan worden gerenderd. Controleer het resultaat vóór opslaan en maak de geretourneerde afbeelding na gebruik vrij.

#### **Een alinea weergeven op de standaard schaal**

Stel dat we een presentatiebestand hebben genaamd sample.pptx met één dia, waarbij de eerste vorm een tekstvak is met drie alinea's.

![Het tekstvak met drie alinea's](paragraph_to_image_input.png)

Het volgende voorbeeld rendert de tweede alinea in een regulier tekstvak op de standaard schaal en slaat de geretourneerde afbeelding op in PNG‑formaat.

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

Het resultaat:

![De alinea‑afbeelding](paragraph_to_image_output.png)

#### **Een alinea weergeven in een tabelcel met schaalvergroting**

Gebruik de [IParagraph::GetImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraph/getimage/) overload die de parameters `float scaleX` en `float scaleY` accepteert om respectievelijk de horizontale en verticale schaalfactoren in te stellen. Het volgende voorbeeld maakt een tabel, rendert de alinea in de eerste cel op twee keer de standaard breedte en hoogte, en slaat het resultaat op als een PNG‑afbeelding.

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

Een schaalfactor van `1` behoudt dat assen op de standaard pixelgrootte. Bijvoorbeeld, `2` voor beide factoren levert een afbeelding op waarvan breedte en hoogte ongeveer het dubbele van de standaard afmetingen zijn, wat vier keer zoveel pixels betekent. Grotere factoren geven over het algemeen scherpere tekst voor inzoomen of high‑resolution output, maar verhogen tevens het geheugen‑ en bestandsformaat. Factoren onder `1` geven kleinere afbeeldingen met minder detail. Gebruik gelijke factoren om de aspect‑ratio van de alinea te behouden; verschillende horizontale en verticale factoren rekken de output onafhankelijk uit.

Het renderen van een volledige vorm met [IShape::GetImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/getimage/) blijft nuttig wanneer de output de vulling, rand of andere visuele context van de vorm moet bevatten. Voor een afbeelding die alleen de alinea toont, gebruik [IParagraph::GetImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraph/getimage/).

## **FAQ**

**Kan ik volledige regelafbreking binnen een tekstframe uitschakelen?**

Ja. Gebruik [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframeformat/set_wraptext/) om afbreking uit te schakelen zodat regels niet breken aan de randen van het tekstframe.

**Hoe kan ik de exacte on‑slide grenzen van een specifieke alinea krijgen?**

Gebruik [IParagraph::GetRect](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraph/getrect/) om de begrenzende rechthoek van de alinea op te halen. [IPortion::GetRect](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iportion/getrect/) geeft de grenzen van een individuele portie.

**Waar wordt uitlijning van alinea's (links, rechts, gecentreerd of uitgevuld) beheerd?**

[IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_alignment/) is een alinea‑niveau instelling en wordt toegepast op de gehele alinea, ongeacht de individuele portie‑opmaak.

**Kan ik de proefleestaal voor een deel van een alinea instellen?**

Ja. Gebruik [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibaseportionformat/set_languageid/) voor individuele porties, zodat één alinea tekst in meerdere talen kan bevatten.