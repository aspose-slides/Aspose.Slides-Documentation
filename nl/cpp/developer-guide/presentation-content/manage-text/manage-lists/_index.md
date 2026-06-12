---
title: Beheer opsommingstekens en genummerde lijsten in presentaties in C++
linktitle: Lijsten beheren
type: docs
weight: 70
url: /nl/cpp/manage-lists/
keywords:
- opsommingsteken
- opsomming
- genummerde lijst
- symbool opsommingsteken
- afbeelding opsommingsteken
- aangepast opsommingsteken
- meerlagige lijst
- opsomming maken
- opsomming toevoegen
- lijst toevoegen
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe u opsommingstekens, afbeelding‑opsommingsteken, meerlagige en genummerde lijsten maakt en opmaakt in PowerPoint‑ en OpenDocument‑presentaties met behulp van Aspose.Slides voor C++."
---
## **Overzicht**

Aspose.Slides for C++ stelt u in staat om opsomming‑ en genummerde lijsten te maken en op te maken in PowerPoint‑ en OpenDocument‑presentaties. Een lijstelement is een alinea waarvan de opsomminginstellingen worden beheerd via het alinea‑formaat.

Gebruik de [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraph/get_paragraphformat/)‑methode om de lijstinstellingen op alinea‑niveau te benaderen. Het belangrijkste toegangspunt is [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/get_bullet/), die een [IBulletFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibulletformat/)‑object retourneert. Met dit object kunt u het opsommingstype, symbool, afbeelding, kleur, grootte, nummeringsstijl en startnummer instellen.

Dit artikel laat zien hoe u:

- een opsomming maken met een aangepast symbool
- een afbeeldings‑bullet maken
- een meerlagige lijst maken door de alinea‑diepte in te stellen
- een genummerde lijst maken
- de lijstopmaak in een bestaande presentatie onderzoeken en wijzigen

## **Een opsomming maken**

Om een opsomming te maken, voegt u [Paragraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides/paragraph/)‑objecten toe aan een [ITextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/) en stelt u [IBulletFormat::set_Type](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibulletformat/set_type/) in op [BulletType::Symbol](https://reference.aspose.com/slides/nl/cpp/aspose.slides/bullettype/). Vervolgens kunt u [IBulletFormat::set_Char](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibulletformat/set_char/), [IBulletFormat::get_Color](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibulletformat/get_color/) en [IBulletFormat::set_Height](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibulletformat/set_height/) instellen om het uiterlijk van de opsomming te beheersen.

De volgende C++‑code toont hoe u een opsomming in een dia maakt:

```cpp
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

Gebruik genummerde lijsten wanneer de volgorde van items van belang is. Stel [IBulletFormat::set_Type](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibulletformat/set_type/) in op [BulletType::Numbered](https://reference.aspose.com/slides/nl/cpp/aspose.slides/bullettype/). U kunt ook een nummerings­formaat kiezen met [IBulletFormat::set_NumberedBulletStyle](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibulletformat/set_numberedbulletstyle/) of [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) instellen wanneer de lijst moet beginnen met een andere waarde dan 1.

De volgende C++‑code laat zien hoe u een genummerde lijst in een dia maakt:

```cpp
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

## **Een afbeeldings‑bullet maken**

Aspose.Slides staat u toe om een gewoon opsommingsteken te vervangen door een afbeelding. Afbeeldings‑bullets werken het beste met eenvoudige afbeeldingen die ook op een kleine afmeting leesbaar blijven, zoals iconen of kleine transparante PNG‑bestanden.

 {{% alert color="primary" %}}
Idealiter, als u van plan bent het gewone opsommingsteken te vervangen door een afbeelding, is het het beste een eenvoudige grafiek met een transparante achtergrond te kiezen. Dergelijke afbeeldingen werken goed als aangepaste opsommingstekens.
{{% /alert %}}

Om een afbeeldings‑bullet te maken, voegt u een afbeelding toe aan [IPresentation::get_Images](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentation/get_images/) en kent u het geretourneerde [IPPImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/)‑object toe aan [IBulletFormat::get_Picture](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibulletformat/get_picture/). Stel [IBulletFormat::set_Type](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibulletformat/set_type/) in op [BulletType::Picture](https://reference.aspose.com/slides/nl/cpp/aspose.slides/bullettype/) voordat u de afbeelding toewijst.

Stel dat we een "image.png" hebben:

![Een afbeelding voor de opsommingen](picture_for_bullets.png)

De volgende C++‑code toont hoe u afbeeldings‑bullets in een dia maakt:

```cpp
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

![De afbeelding‑bullets](picture_bullets.png)

## **Een meerlagige lijst maken**

Gebruik [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_depth/) om lijstitems op verschillende niveaus te plaatsen. Niveau 0 is het bovenste niveau, niveau 1 is eronder genesteld, enzovoort.

De volgende C++‑code laat zien hoe u een meerlagige opsomming maakt:

```cpp
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

Om de lijstopmaak in een bestaande presentatie te wijzigen, benadert u de doel‑alinea en werkt u de instellingen van [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/get_bullet/) bij. Dezelfde eigenschappen die worden gebruikt om lijsten te maken, kunnen ook worden gebruikt om lijsten die uit een PPT‑, PPTX‑ of ODP‑bestand zijn geladen, te onderzoeken of te wijzigen.

De volgende C++‑code wijzigt de eerste alinea in een tekst‑frame zodat deze een genummerde lijststijl gebruikt:

```cpp
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

## **FAQ**

**Kunnen opsommingen en genummerde lijsten geëxporteerd worden naar PDF of beelden?**

**Ja**. Aspose.Slides behoudt de lijstopmaak wanneer het doelformaat de overeenkomstige tekstlay-out en opsomming‑eigenschappen ondersteunt.

**Kan ik lijsten bewerken in bestaande presentaties?**

**Ja**. Laad de presentatie, benader de doel‑alinea, onderzoek of werk de instellingen van [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/get_bullet/) bij, en sla de presentatie op.

**Kunnen lijsten niet‑Latijnse tekst bevatten?**

**Ja**. De tekst van een lijstelement kan Unicode‑tekens bevatten, zodat u lijsten kunt maken in meertalige presentaties. Zorg ervoor dat de in de presentatie gebruikte lettertypen de benodigde tekens ondersteunen.