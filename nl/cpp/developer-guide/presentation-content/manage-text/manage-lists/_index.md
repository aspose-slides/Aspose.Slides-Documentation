---
title: Beheer opsommingstekens en genummerde lijsten in presentaties in C++
linktitle: Lijsten beheren
type: docs
weight: 70
url: /nl/cpp/manage-lists/
keywords:
- opsommingsteken
- opsommingslijst
- genummerde lijst
- symbool opsommingsteken
- afbeeldingsopsomming
- aangepast opsommingsteken
- meerlagige lijst
- opsommingsteken maken
- opsommingsteken toevoegen
- lijst toevoegen
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe u opsommings-, afbeeldings-, meerlagige en genummerde lijsten kunt maken en opmaken in PowerPoint- en OpenDocument‑presentaties met Aspose.Slides voor C++."
---
## **Overzicht**

Aspose.Slides for C++ stelt u in staat om opsommingstekens en genummerde lijsten te maken en op te maken in PowerPoint‑ en OpenDocument‑presentaties. Een lijstitem is een alinea waarvan de opsommingstekensinstellingen worden beheerd via de alinea‑opmaak.

Gebruik de [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraph/get_paragraphformat/)‑methode om de lijstinstellingen op alinea‑niveau te benaderen. Het belangrijkste toegangspunt is [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/get_bullet/), dat een [IBulletFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibulletformat/)‑object teruggeeft. Met dit object kunt u het type opsommingsteken, symbool, afbeelding, kleur, grootte, nummeringsstijl en startnummer instellen.

In dit artikel wordt getoond hoe u:

- een opsomming met een aangepast symbool maken
- een afbeelding als opsommingsteken maken
- een meerlagige lijst maken door de alinea‑diepte in te stellen
- een genummerde lijst maken
- de lijstopmaak in een bestaande presentatie inspecteren en wijzigen

## **Een opsomming maken**

Om een opsomming te maken, voegt u [Paragraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides/paragraph/)‑objecten toe aan een [ITextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/) en stelt u [IBulletFormat::set_Type](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibulletformat/set_type/) in op [BulletType::Symbol](https://reference.aspose.com/slides/nl/cpp/aspose.slides/bullettype/). Vervolgens kunt u [IBulletFormat::set_Char](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibulletformat/set_char/), [IBulletFormat::get_Color](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibulletformat/get_color/) en [IBulletFormat::set_Height](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibulletformat/set_height/) instellen om het uiterlijk van het opsommingsteken te regelen.

De volgende C++‑code laat zien hoe u een opsomming maakt in een dia:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBulletFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto createParagraph = [](System::String text)
{
    auto paragraph = System::MakeObject<Paragraph>();
    auto paragraphFormat = paragraph->get_ParagraphFormat();
    auto bulletFormat = paragraphFormat->get_Bullet();

    bulletFormat->set_Type(BulletType::Symbol);
    bulletFormat->set_Char(u'*');
    paragraphFormat->set_Indent(15);
    bulletFormat->set_IsBulletHardColor(NullableBool::True);
    bulletFormat->get_Color()->set_Color(System::Drawing::Color::get_IndianRed());
    bulletFormat->set_Height(100);
    paragraph->set_Text(text);

    return paragraph;
};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph1 = createParagraph(u"The first paragraph");
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = createParagraph(u"The second paragraph");
textFrame->get_Paragraphs()->Add(paragraph2);

presentation->Save(u"symbol_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De symbool‑opsommingen](symbol_bullets.png)

## **Een genummerde lijst maken**

Gebruik genummerde lijsten wanneer de volgorde van items belangrijk is. Stel [IBulletFormat::set_Type](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibulletformat/set_type/) in op [BulletType::Numbered](https://reference.aspose.com/slides/nl/cpp/aspose.slides/bullettype/). U kunt ook een nummeringsopmaak kiezen met [IBulletFormat::set_NumberedBulletStyle](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibulletformat/set_numberedbulletstyle/) of [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) instellen wanneer de lijst moet beginnen bij een andere waarde dan 1.

De volgende C++‑code toont hoe u een genummerde lijst maakt in een dia:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBulletFormat.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 90, 80);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph1 = System::MakeObject<Paragraph>();
paragraph1->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
paragraph1->set_Text(u"Apple");
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = System::MakeObject<Paragraph>();
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
paragraph2->set_Text(u"Orange");
textFrame->get_Paragraphs()->Add(paragraph2);

auto paragraph3 = System::MakeObject<Paragraph>();
paragraph3->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
paragraph3->set_Text(u"Banana");
textFrame->get_Paragraphs()->Add(paragraph3);

presentation->Save(u"numbered_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De genummerde opsommingen](numbered_bullets.png)

## **Een afbeelding‑opsomming maken**

Aspose.Slides stelt u in staat om een regulier opsommingsteken te vervangen door een afbeelding. Afbeeldings‑opsommingstekens werken het best met eenvoudige afbeeldingen die ook op kleine schaal leesbaar blijven, zoals pictogrammen of kleine transparante PNG‑bestanden.

{{% alert color="info" %}}
Idealiter, als u van plan bent het reguliere opsommingsteken te vervangen door een afbeelding, kiest u het beste een eenvoudige afbeelding met een transparante achtergrond. Dergelijke afbeeldingen werken goed als aangepaste opsommingstekens.
{{% /alert %}}

Om een afbeelding‑opsomming te maken, voegt u een afbeelding toe aan [IPresentation::get_Images](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentation/get_images/) en kent u het geretourneerde [IPPImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/)‑object toe aan [IBulletFormat::get_Picture](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibulletformat/get_picture/). Stel [IBulletFormat::set_Type](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibulletformat/set_type/) in op [BulletType::Picture](https://reference.aspose.com/slides/nl/cpp/aspose.slides/bullettype/) voordat u de afbeelding toewijst.

Stel, we hebben een "image.png":

![Een afbeelding voor de opsommingen](picture_for_bullets.png)

De volgende C++‑code toont hoe u afbeeldings‑opsommingen maakt in een dia:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBulletFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto createParagraph = [](System::String text, System::SharedPtr<IPPImage> image)
{
    auto paragraph = System::MakeObject<Paragraph>();
    auto paragraphFormat = paragraph->get_ParagraphFormat();
    auto bulletFormat = paragraphFormat->get_Bullet();

    bulletFormat->set_Type(BulletType::Picture);
    bulletFormat->get_Picture()->set_Image(image);
    paragraphFormat->set_Indent(15);
    bulletFormat->set_Height(100);
    paragraph->set_Text(text);

    return paragraph;
};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto sourceImage = Images::FromFile(u"image.png");
auto bulletImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

auto paragraph1 = createParagraph(u"The first paragraph", bulletImage);
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = createParagraph(u"The second paragraph", bulletImage);
textFrame->get_Paragraphs()->Add(paragraph2);

presentation->Save(u"picture_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De afbeelding‑opsommingen](picture_bullets.png)

## **Een meerlagige lijst maken**

Gebruik [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_depth/) om lijstitems op verschillende niveaus te plaatsen. Niveau 0 is het bovenste niveau, niveau 1 is eronder ingebed, enzovoort.

De volgende C++‑code toont hoe u een meerlagige opsomming maakt:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 260, 110);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph1 = System::MakeObject<Paragraph>();
paragraph1->get_ParagraphFormat()->set_Depth(0);
paragraph1->set_Text(u"My text - Depth 0");
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = System::MakeObject<Paragraph>();
paragraph2->get_ParagraphFormat()->set_Depth(1);
paragraph2->set_Text(u"My text - Depth 1");
textFrame->get_Paragraphs()->Add(paragraph2);

auto paragraph3 = System::MakeObject<Paragraph>();
paragraph3->get_ParagraphFormat()->set_Depth(2);
paragraph3->set_Text(u"My text - Depth 2");
textFrame->get_Paragraphs()->Add(paragraph3);

auto paragraph4 = System::MakeObject<Paragraph>();
paragraph4->get_ParagraphFormat()->set_Depth(3);
paragraph4->set_Text(u"My text - Depth 3");
textFrame->get_Paragraphs()->Add(paragraph4);

presentation->Save(u"multilevel_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De meerlagige lijst](multilevel_list.png)

## **Een bestaande lijst wijzigen**

Om de lijstopmaak in een bestaande presentatie te wijzigen, krijgt u toegang tot de doel‑alinea en werkt u de [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/get_bullet/)‑instellingen bij. Dezelfde eigenschappen die bij het maken van lijsten worden gebruikt, kunnen worden gebruikt om lijsten die uit een PPT‑, PPTX‑ of ODP‑bestand zijn geladen, te inspecteren of te wijzigen.

De volgende C++‑code wijzigt de eerste alinea in een tekstframe zodat deze een genummerde lijststijl gebruikt:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBulletFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/NumberedBulletStyle.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);
auto autoShape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

auto paragraphFormat = paragraph->get_ParagraphFormat();
auto bulletFormat = paragraphFormat->get_Bullet();

bulletFormat->set_Type(BulletType::Numbered);
bulletFormat->set_NumberedBulletStyle(NumberedBulletStyle::BulletRomanUCPeriod);
bulletFormat->set_NumberedBulletStartWith(1);
paragraphFormat->set_MarginLeft(30);
paragraphFormat->set_Indent(-20);

presentation->Save(u"updated_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Veelgestelde vragen**

### Kunnen opsommingen en genummerde lijsten worden geëxporteerd naar PDF of afbeeldingen?

Ja. Aspose.Slides behoudt de lijstopmaak wanneer het doelformaat de overeenkomstige tekstlay-out en opsommingsteken‑functies ondersteunt.

### Kan ik lijsten bewerken in bestaande presentaties?

Ja. Laad de presentatie, krijg toegang tot de doel‑alinea, inspecteer of werk de [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/get_bullet/)‑instellingen bij, en sla de presentatie vervolgens op.

### Kunnen lijsten niet‑Latijnse tekst bevatten?

Ja. De tekst van lijstitems kan Unicode‑tekens bevatten, zodat u lijsten kunt maken in meertalige presentaties. Zorg ervoor dat de gebruikte lettertypen in de presentatie de benodigde tekens ondersteunen.