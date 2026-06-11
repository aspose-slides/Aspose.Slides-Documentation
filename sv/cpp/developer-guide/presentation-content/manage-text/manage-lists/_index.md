---
title: Hantera punkt- och numrerade listor i presentationer i C++
linktitle: Hantera listor
type: docs
weight: 70
url: /sv/cpp/manage-lists/
keywords:
- punkt
- punktlista
- numrerad lista
- symbolpunkt
- bildpunkt
- anpassad punkt
- flernivålista
- skapa punkt
- lägg till punkt
- lägg till lista
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Lär dig hur du skapar och formaterar punkt-, bild-, flernivå- och numrerade listor i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för C++."
---
## **Översikt**

Aspose.Slides för C++ låter dig skapa och formatera punkt- och numrerade listor i PowerPoint- och OpenDocument-presentationer. Ett listobjekt är ett stycke vars punktinställningar styrs via dess styckeformat.

Använd metoden [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraph/get_paragraphformat/) för att komma åt listinställningar på stycknivå. Huvudingångspunkten är [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraphformat/get_bullet/), som returnerar ett [IBulletFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ibulletformat/)‑objekt. Med detta objekt kan du ställa in punkttyp, symbol, bild, färg, storlek, numreringsstil och startnummer.

Den här artikeln visar hur man:

- skapa en punktlista med en anpassad symbol
- skapa en bildpunkt
- skapa en flernivålista genom att ange styckedjup
- skapa en numrerad lista
- undersöka och ändra listformatering i en befintlig presentation

## **Skapa en punktlista**

För att skapa en punktlista, lägg till [Paragraph](https://reference.aspose.com/slides/sv/cpp/aspose.slides/paragraph/)‑objekt i ett [ITextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/) och sätt [IBulletFormat::set_Type](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ibulletformat/set_type/) till [BulletType::Symbol](https://reference.aspose.com/slides/sv/cpp/aspose.slides/bullettype/). Du kan sedan sätta [IBulletFormat::set_Char](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ibulletformat/set_char/), [IBulletFormat::get_Color](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ibulletformat/get_color/) och [IBulletFormat::set_Height](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ibulletformat/set_height/) för att styra punktens utseende.

Följande C++‑kod demonstrerar hur man skapar en punktlista i en bild:

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

Resultatet:

![Symbolpunkterna](symbol_bullets.png)

## **Skapa en numrerad lista**

Använd numrerade listor när ordningsföljden på objekten är viktig. Sätt [IBulletFormat::set_Type](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ibulletformat/set_type/) till [BulletType::Numbered](https://reference.aspose.com/slides/sv/cpp/aspose.slides/bullettype/). Du kan också välja ett nummerformat med [IBulletFormat::set_NumberedBulletStyle](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ibulletformat/set_numberedbulletstyle/) eller sätta [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) när listan ska börja med ett annat värde än 1.

Följande C++‑kod visar hur man skapar en numrerad lista i en bild:

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

Resultatet:

![Numrerade punkter](numbered_bullets.png)

## **Skapa en bildpunkt**

Aspose.Slides låter dig ersätta en vanlig punkt‑symbol med en bild. Bildpunkter fungerar bäst med enkla bilder som förblir läsbara i liten storlek, till exempel ikoner eller små transparenta PNG‑filer.

{{% alert color="primary" %}}
Idealiskt, om du planerar att ersätta den vanliga punkt‑symbolen med en bild, är det bäst att välja en enkel grafik med transparent bakgrund. Sådana bilder fungerar bra som anpassade punkt‑symboler.

Kom ihåg att bilden kommer att skalas ner till en mycket liten storlek. Av den anledningen rekommenderar vi starkt att välja en bild som förblir tydlig och visuellt effektiv när den används som punkt i en lista.
{{% /alert %}}

För att skapa en bildpunkt, lägg till en bild i [IPresentation::get_Images](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentation/get_images/) och tilldela det returnerade [IPPImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ippimage/)‑objektet till [IBulletFormat::get_Picture](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ibulletformat/get_picture/). Sätt [IBulletFormat::set_Type](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ibulletformat/set_type/) till [BulletType::Picture](https://reference.aspose.com/slides/sv/cpp/aspose.slides/bullettype/) innan du tilldelar bilden.

Anta att vi har en "image.png":

![En bild för punkterna](picture_for_bullets.png)

Följande C++‑kod visar hur man skapar bildpunkter i en bild:

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

Resultatet:

![Bildpunkterna](picture_bullets.png)

## **Skapa en flernivålista**

Använd [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraphformat/set_depth/) för att placera listobjekt på olika nivåer. Nivå 0 är översta nivån, nivå 1 ligger inbäddad under den och så vidare.

Följande C++‑kod visar hur man skapar en flernivåpunktlista:

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

Resultatet:

![Den flernivålista](multilevel_list.png)

## **Ändra en befintlig lista**

För att ändra listformatering i en befintlig presentation, få åtkomst till mål‑stycket och uppdatera dess [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraphformat/get_bullet/)‑inställningar. Samma egenskaper som används för att skapa listor kan också användas för att inspektera eller ändra listor som lästs in från en PPT-, PPTX- eller ODP‑fil.

Följande C++‑kod ändrar det första stycket i en textram för att använda en numrerad liststil:

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

## **Vanliga frågor**

**Kan punkt- och nummerlistor exporteras till PDF eller bilder?**

Ja. Aspose.Slides bevarar listformatering när målformatet stödjer motsvarande textlayout och punktfunktioner.

**Kan jag redigera listor i befintliga presentationer?**

Ja. Ladda presentationen, få åtkomst till mål‑stycket, inspektera eller uppdatera dess [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraphformat/get_bullet/)‑inställningar och spara presentationen.

**Kan listor innehålla icke‑latinsk text?**

Ja. Text i listobjekt kan innehålla Unicode‑tecken, så du kan skapa listor i flerspråkiga presentationer. Se till att de teckensnitt som används i presentationen stödjer de tecken du behöver.