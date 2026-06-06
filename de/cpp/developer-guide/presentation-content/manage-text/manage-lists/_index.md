---
title: Verwalten von Aufzählungs- und nummerierten Listen in Präsentationen in C++
linktitle: Listen verwalten
type: docs
weight: 70
url: /de/cpp/manage-lists/
keywords:
- Aufzählungszeichen
- Aufzählungsliste
- nummerierte Liste
- Symbol Aufzählungszeichen
- Bild Aufzählungszeichen
- benutzerdefiniertes Aufzählungszeichen
- mehrstufige Liste
- Aufzählungszeichen erstellen
- Aufzählungszeichen hinzufügen
- Liste hinzufügen
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie Aufzählungs-, Bild-, mehrstufige und nummerierte Listen in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für C++ erstellen und formatieren."
---
## **Übersicht**

Aspose.Slides für C++ ermöglicht das Erstellen und Formatieren von Aufzählungs‑ und nummerierten Listen in PowerPoint‑ und OpenDocument‑Präsentationen. Ein Listeneintrag ist ein Absatz, dessen Aufzählungseinstellungen über das Absatzformat gesteuert werden.

Verwenden Sie die [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraph/get_paragraphformat/) Methode, um die listenbezogenen Einstellungen auf Absatzebene zu erhalten. Der Haupteinstiegspunkt ist [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraphformat/get_bullet/), das ein [IBulletFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibulletformat/) Objekt zurückgibt. Mit diesem Objekt können Sie den Aufzählungstyp, das Symbol, das Bild, die Farbe, die Größe, den Nummerierungsstil und die Anfangsnummer festlegen.

Dieser Artikel zeigt, wie man:

- eine Aufzählungsliste mit einem benutzerdefinierten Symbol erstellen
- eine Bild‑Aufzählung erstellen
- eine mehrstufige Liste erstellen, indem die Absatztiefe festgelegt wird
- eine nummerierte Liste erstellen
- die Listformatierung in einer bestehenden Präsentation prüfen und ändern

## **Erstellen einer Aufzählungsliste**

Um eine Aufzählungsliste zu erstellen, fügen Sie [Paragraph](https://reference.aspose.com/slides/de/cpp/aspose.slides/paragraph/)‑Objekte zu einem [ITextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/) hinzu und setzen [IBulletFormat::set_Type](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibulletformat/set_type/) auf [BulletType::Symbol](https://reference.aspose.com/slides/de/cpp/aspose.slides/bullettype/). Anschließend können Sie [IBulletFormat::set_Char](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibulletformat/set_char/), [IBulletFormat::get_Color](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibulletformat/get_color/) und [IBulletFormat::set_Height](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibulletformat/set_height/) festlegen, um das Aussehen der Aufzählungszeichen zu steuern.

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

Das Ergebnis:

![Die Symbol‑Aufzählungen](symbol_bullets.png)

## **Nummerierte Liste erstellen**

Verwenden Sie nummerierte Listen, wenn die Reihenfolge der Elemente wichtig ist. Setzen Sie [IBulletFormat::set_Type](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibulletformat/set_type/) auf [BulletType::Numbered](https://reference.aspose.com/slides/de/cpp/aspose.slides/bullettype/). Sie können außerdem ein Nummerierungsformat mit [IBulletFormat::set_NumberedBulletStyle](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibulletformat/set_numberedbulletstyle/) auswählen oder [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) festlegen, wenn die Liste mit einem anderen Wert als 1 beginnen soll.

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

Das Ergebnis:

![Die nummerierten Aufzählungen](numbered_bullets.png)

## **Bild‑Aufzählungszeichen erstellen**

Aspose.Slides ermöglicht es, ein reguläres Aufzählungszeichen durch ein Bild zu ersetzen. Bild‑Aufzählungszeichen funktionieren am besten mit einfachen Bildern, die auch bei kleiner Größe lesbar bleiben, z. B. Icons oder kleine transparente PNG‑Dateien.

{{% alert color="primary" %}}
Idealerweise sollten Sie, wenn Sie das reguläre Aufzählungszeichen durch ein Bild ersetzen wollen, eine einfache Grafik mit transparentem Hintergrund wählen. Solche Bilder eignen sich gut als benutzerdefinierte Aufzählungssymbole.
{{% /alert %}}

Um ein Bild‑Aufzählungszeichen zu erstellen, fügen Sie ein Bild zu [IPresentation::get_Images](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentation/get_images/) hinzu und weisen das zurückgegebene [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/)‑Objekt [IBulletFormat::get_Picture](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibulletformat/get_picture/) zu. Setzen Sie [IBulletFormat::set_Type](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibulletformat/set_type/) auf [BulletType::Picture](https://reference.aspose.com/slides/de/cpp/aspose.slides/bullettype/) , bevor Sie das Bild zuweisen.

Angenommen, wir haben eine "image.png":

![Ein Bild für die Aufzählungszeichen](picture_for_bullets.png)

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

Das Ergebnis:

![Die Bild‑Aufzählungszeichen](picture_bullets.png)

## **Mehrstufige Liste erstellen**

Verwenden Sie [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraphformat/set_depth/), um Listeneinträge auf verschiedenen Ebenen zu platzieren. Ebene 0 ist die oberste Ebene, Ebene 1 ist darunter verschachtelt usw.

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

Das Ergebnis:

![Die mehrstufige Liste](multilevel_list.png)

## **Vorhandene Liste ändern**

Um die Listformatierung in einer bestehenden Präsentation zu ändern, greifen Sie auf den gewünschten Absatz zu und aktualisieren dessen [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraphformat/get_bullet/)‑Einstellungen. Die gleichen Eigenschaften, die zum Erstellen von Listen verwendet werden, können auch zum Prüfen oder Ändern von aus einer PPT-, PPTX- oder ODP‑Datei geladenen Listen genutzt werden.

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

**Können Aufzählungs‑ und nummerierte Listen in PDF oder Bilder exportiert werden?**

Ja. Aspose.Slides bewahrt die Listformatierung, wenn das Zielformat die entsprechenden Textlayouts und Aufzählungsfunktionen unterstützt.

**Kann ich Listen in bestehenden Präsentationen bearbeiten?**

Ja. Laden Sie die Präsentation, greifen Sie auf den gewünschten Absatz zu, prüfen oder aktualisieren Sie dessen [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraphformat/get_bullet/)‑Einstellungen und speichern Sie die Präsentation.

**Können Listen nicht‑lateinischen Text enthalten?**

Ja. Der Text von Listeneinträgen kann Unicode‑Zeichen enthalten, sodass Sie Listen in mehrsprachigen Präsentationen erstellen können. Stellen Sie sicher, dass die in der Präsentation verwendeten Schriften die benötigten Zeichen unterstützen.