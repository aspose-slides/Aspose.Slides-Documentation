---
title: Beheer PowerPoint-tekstalinea's in C++
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
- alinea-opsommingsteken
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
description: "Leer hoe u alinea's, gedeelten, opsommingstekens, genummerde lijsten, insprongen, HTML-inhoud en alinea-afbeeldingen kunt maken en opmaken met Aspose.Slides voor C++."
---
## **Overzicht**

Aspose.Slides voor C++ stelt tekst voor als een hiërarchie van tekstframes, alinea's en gedeelten:

* [ITextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/) stelt de tekstcontainer in een vorm voor en biedt toegang tot de alinea‑verzameling.
* [IParagraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraph/) stelt één alinea in een tekstframe voor en biedt toegang tot de gedeelten en alinea‑opmaak.
* [IPortion](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iportion/) stelt een tekstrun binnen een alinea voor. Elk gedeelte kan zijn eigen tekst en teken‑niveau opmaak hebben.

Een alinea kan daarom tekst bevatten met verschillende lettertypes, kleuren, groottes en andere opmaak door meerdere gedeelten te gebruiken.

## **Alinea's maken en opmaken**

### **Alinea's maken met meerdere gedeelten**

De volgende stappen maken een tekstframe met drie alinea's, elk met drie gedeelten:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) aan.
2. Open de referentie naar de betreffende slide via de index.
3. Voeg een rechthoekige [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) toe aan de slide.
4. Open de [ITextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/) van de vorm.
5. Gebruik de standaardalinea en voeg twee extra [IParagraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraph/) objecten toe aan het tekstframe.
6. Voeg voldoende [IPortion](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iportion/) objecten toe zodat elke alinea drie gedeelten bevat. De standaardalinea bevat al één leeg gedeelte.
7. Stel de tekst van elk gedeelte in.
8. Pas teken‑niveau opmaak toe via [IPortion::get_PortionFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iportion/get_portionformat/) .
9. Sla de gewijzigde presentatie op.

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

Opsommingstekens en nummering maken gerelateerde items makkelijker scanbaar. In Aspose.Slides worden lijstinstellingen gedefinieerd via [IBulletFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibulletformat/) .

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) aan.
2. Open de referentie naar de betreffende slide via de index.
3. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) toe aan de geselecteerde slide.
4. Open de [ITextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/) van de vorm.
5. Verwijder de standaardalinea uit het tekstframe.
6. Maak een [Paragraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides/paragraph/) voor een symbool‑opsommingsteken.
7. Stel [IBulletFormat::set_Type](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibulletformat/set_type/) in op [BulletType::Symbol](https://reference.aspose.com/slides/nl/cpp/aspose.slides/bullettype/) en specificeer het opsommingsteken‑karakter.
8. Stel de alinea‑tekst, insprong, opsommingstekenkleur en opsommingsteekengrootte in.
9. Voeg de alinea toe aan het tekstframe.
10. Maak een tweede alinea en stel [IBulletFormat::set_Type](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibulletformat/set_type/) in op [BulletType::Numbered](https://reference.aspose.com/slides/nl/cpp/aspose.slides/bullettype/) .
11. Configureer de genummerde opsommingsteken‑stijl en voeg de alinea toe aan het tekstframe.
12. Sla de presentatie op.

Dit C++‑voorbeeld maakt een symbool‑opsommingsteken en een genummerd opsommingsteken:

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

Afbeeldings‑opsommingstekens laten je een aangepast beeld gebruiken in plaats van een symbool of cijfer.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) aan.
2. Open de referentie naar de betreffende slide via de index.
3. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) toe en open de [ITextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/) .
4. Verwijder de standaardalinea uit het tekstframe.
5. Laad de opsommingsteken‑afbeelding en voeg deze toe aan de afbeeldingscollectie van de presentatie als een [IPPImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/) .
6. Maak een [Paragraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides/paragraph/) en stel de tekst in.
7. Stel [IBulletFormat::set_Type](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibulletformat/set_type/) in op [BulletType::Picture](https://reference.aspose.com/slides/nl/cpp/aspose.slides/bullettype/) .
8. Wijs de afbeelding toe via [ISlidesPicture::set_Image](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidespicture/set_image/) en stel de opsommingsteken‑grootte in.
9. Voeg de alinea toe aan het tekstframe.
10. Sla de gewijzigde presentatie op.

Dit C++‑voorbeeld maakt een afbeelding‑opsommingsteken:

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

### **Een meerniveaulijst maken**

Stel [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_depth/) in om alinea's op verschillende niveaus van een lijst te plaatsen. Het bovenste niveau heeft een diepte van `0`.

1. Maak een [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) en open een slide.
2. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) toe en verwijder de standaardalinea uit het tekstframe.
3. Maak vier alinea's en configureer hun opsommingsteken‑symbolen.
4. Stel hun [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_depth/) waarden in op `0`, `1`, `2` en `3`.
5. Voeg de alinea's toe aan het tekstframe en sla de presentatie op.

Dit C++‑voorbeeld maakt een vier‑niveau opsommingslijst:

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

Gebruik [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) om het initiële cijfer voor een genummerde alinea in te stellen.

1. Maak een [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) en voeg een [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) toe aan een slide.
2. Verwijder de standaardalinea uit het tekstframe van de vorm.
3. Maak drie genummerde alinea's.
4. Stel [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) in op `2`, `3` respectievelijk `7` voor de alinea's.
5. Voeg de alinea's toe aan het tekstframe en sla de presentatie op.

Dit C++‑voorbeeld kent een aangepaste startwaarde toe aan elke alinea:

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

## **Alinea‑lay‑out en eind‑eigenschappen beheren**

### **Een eerste‑regelinsprong instellen**

Gebruik [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_indent/) om de insprong van de eerste regel van een alinea te bepalen. Deze methode verplaatst alleen de eerste regel ten opzichte van de linkermarge van de alinea. Een positieve waarde verschuift de eerste regel naar rechts, terwijl de overige regels op de alinea‑lichaam uitgelijnd blijven.

Gebruik [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_marginleft/) wanneer je de hele alinea wilt verplaatsen. Gebruik [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_indent/) wanneer je alleen de eerste regel wilt verplaatsen.

Het onderstaande voorbeeld maakt meerdere alinea's en past verschillende [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_indent/) waarden toe om te laten zien hoe de eerste‑regelinsprong de lay‑out beïnvloedt.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) aan.
2. Open de doel‑slide.
3. Voeg een rechthoekige [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) toe aan de slide.
4. Open de [ITextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/) van de vorm en verwijder de standaardalinea.
5. Maak meerdere alinea's en stel verschillende [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_indent/) waarden in.
6. Voeg de alinea's toe aan het tekstframe.
7. Sla de gewijzigde presentatie op.

Deze code laat zien hoe je een alinea‑insprong instelt:

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

![De eerste‑regelinsprong van de alinea's](first_line_indent.png)

### **Een hangende insprong instellen**

Een hangende insprong is een alinea‑lay‑out waarbij de eerste regel links van de overige regels begint. In Aspose.Slides maak je dit effect met [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_indent/). Stel de insprong in op een negatieve waarde om de eerste regel naar links te verplaatsen ten opzichte van het alinea‑lichaam.

In de praktijk definieert [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_marginleft/) de linkermarge van het alinea‑lichaam, en [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_indent/) de positie van de eerste regel ten opzichte van die marge. Om een hangende insprong te maken, stel je een positieve margin‑left waarde in en een negatieve insprongwaarde.

Deze opmaak is nuttig voor bibliografieën, referenties, woordenboekvermeldingen en andere alinea's waarbij de omslagen onder het alinea‑lichaam moeten uitlijnen in plaats van onder het eerste teken van de eerste regel.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) aan.
2. Open de doel‑slide.
3. Voeg een rechthoekige [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) toe aan de slide.
4. Open de [ITextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/) van de vorm en verwijder de standaardalinea.
5. Maak alinea's en stel voor elke alinea een positieve [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_marginleft/) waarde in.
6. Stel een negatieve [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_indent/) waarde in om het hangende‑insprong‑effect te krijgen.
7. Voeg de alinea's toe aan het tekstframe.
8. Sla de gewijzigde presentatie op.

Deze code toont hoe je een hangende insprong voor een alinea instelt:

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

Het resultaat:

![De hangende insprong van de alinea's](hanging_indent.png)

### **Einde‑alinea‑eigenschappen instellen**

[IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) bepaalt de opmaak van het einde‑teken van een alinea. Het volgende voorbeeld kent een lettergrootte en een Latijnse lettertype toe aan het einde‑teken van de tweede alinea:

1. Laad een [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) en open een slide.
2. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) toe en verwijder de standaardalinea.
3. Maak twee alinea's en voeg tekstgedeelten toe.
4. Maak een [PortionFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/portionformat/) voor het einde‑teken van de tweede alinea.
5. Stel [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibaseportionformat/set_fontheight/) en [IBasePortionFormat::set_LatinFont](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibaseportionformat/set_latinfont/) in.
6. Wijs de opmaak toe met [IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) en sla de presentatie op.

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

## **Inhoud van alinea's importeren en exporteren**

### **HTML‑tekst importeren in alinea's**

Gebruik [IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphcollection/addfromhtml/) om HTML‑opmaak om te zetten naar alinea's en gedeelten in een tekstframe.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) aan.
2. Open een slide en voeg een [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) toe.
3. Open de [ITextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/) van de vorm en verwijder de standaardalinea.
4. Lees het bron‑HTML‑bestand.
5. Geef de HTML‑string door aan [IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphcollection/addfromhtml/) .
6. Sla de gewijzigde presentatie op.

Dit C++‑voorbeeld importeert HTML in een tekstframe:

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
2. Open de slide en vind de [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) die de tekst bevat.
3. Open de [ITextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/) van de vorm.
4. Roep [IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphcollection/exporttohtml/) aan met de start‑alinea‑index en het aantal alinea's dat geëxporteerd moet worden.
5. Schrijf de geretourneerde HTML‑string naar een bestand.

Dit C++‑voorbeeld exporteert alle alinea's uit de eerste tekstvorm:

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

### **Een alinea renderen als afbeelding**

[IParagraph::GetImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraph/getimage/) rendert een individuele alinea direct en geeft een [IImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iimage/) terug. Sla het resultaat op in een bestand of stream met [IImage::Save](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iimage/save/) . Je hoeft de omsluitende vorm niet te renderen of een bitmap handmatig bij te snijden.

[IParagraph::GetImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraph/getimage/) kan `nullptr` retourneren als de alinea niet in de bovenliggende verzameling gevonden wordt, geen geldige render‑afmetingen heeft, of niet gerenderd kan worden. Controleer het resultaat vóór het opslaan en maak de geretourneerde afbeelding vrij na gebruik.

#### **Een alinea renderen op de standaardschaal**

Stel dat we een presentatie‑bestand genaamd sample.pptx hebben met één slide, waarbij de eerste vorm een tekstvak is met drie alinea's.

![Het tekstvak met drie alinea's](paragraph_to_image_input.png)

Het volgende voorbeeld rendert de tweede alinea in een gewone tekstvorm op de standaardschaal en slaat de geretourneerde afbeelding op in PNG‑formaat.

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

#### **Een alinea renderen in een tabelcel met schaalvergroting**

Gebruik de overload van [IParagraph::GetImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraph/getimage/) die de parameters `float scaleX` en `float scaleY` accepteert om de horizontale en verticale schaalfactoren in te stellen. Het volgende voorbeeld maakt een tabel, rendert de alinea in de eerste cel op het dubbele van de standaardbreedte en -hoogte, en slaat het resultaat op als PNG‑afbeelding.

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

Een schaalfactor van `1` behoudt die as op de standaardpixelgrootte. Bijvoorbeeld, `2` voor beide factoren produceert een afbeelding waarvan breedte en hoogte ongeveer het dubbele zijn van de standaardafmetingen, wat resulteert in vier keer zoveel pixels. Grotere factoren leveren over het algemeen scherpere tekst voor inzoomen of hoge‑resolutie‑output, maar verhogen ook het geheugenverbruik en de bestandsgrootte. Factoren onder `1` geven kleinere afbeeldingen met minder detail. Gebruik gelijke factoren om de beeldverhouding van de alinea te behouden; verschillende horizontale en verticale factoren rekken de uitvoer onafhankelijk uit.

Het renderen van een volledige vorm met [IShape::GetImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/getimage/) blijft nuttig wanneer de uitvoer de vulling, rand of andere visuele context van de vorm moet bevatten. Voor een afbeelding die alleen de alinea bevat, gebruik je [IParagraph::GetImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraph/getimage/) .

## **FAQ**

**Kan ik het automatisch afbreken van tekst in een tekstframe volledig uitschakelen?**

Ja. Gebruik [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframeformat/set_wraptext/) om afbreken uit te schakelen zodat regels niet worden gesplitst bij de randen van het tekstframe.

**Hoe kan ik de exacte in‑slide‑grenzen van een specifieke alinea verkrijgen?**

Gebruik [IParagraph::GetRect](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraph/getrect/) om de omhullende rechthoek van de alinea op te halen. [IPortion::GetRect](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iportion/getrect/) geeft de grenzen van een individueel gedeelte.

**Waar wordt de alinea‑uitlijning (links, rechts, gecentreerd of uitgevuld) geregeld?**

[IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_alignment/) is een alinea‑niveau instelling en wordt toegepast op de volledige alinea ongeacht de opmaak van individuele gedeelten.

**Kan ik de taalcontrole instellen voor een deel van een alinea?**

Ja. Gebruik [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibaseportionformat/set_languageid/) voor individuele gedeelten, zodat één alinea tekst in meerdere talen kan bevatten.