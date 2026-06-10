---
title: C++-ban felsorolási és számozott listák kezelése a prezentációkban
linktitle: Listák kezelése
type: docs
weight: 70
url: /hu/cpp/manage-lists/
keywords:
- jelölő
- felsorolási lista
- számozott lista
- szimbólum jelölő
- képjelölő
- egyéni jelölő
- többszintű lista
- jelölő létrehozása
- jelölő hozzáadása
- lista hozzáadása
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és formázhat felsorolási, kép-, többszintű és számozott listákat PowerPoint és OpenDocument prezentációkban az Aspose.Slides for C++ használatával."
---
## **Áttekintés**

Az Aspose.Slides for C++ lehetővé teszi, hogy felsorolás‑ és számozott listákat hozzon létre és formázzon PowerPoint és OpenDocument prezentációkban. A listaelem egy bekezdés, amelynek a felsorolás beállításait a bekezdés formátuma vezérli.

Használja az [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraph/get_paragraphformat/) metódust a bekezdés szintű lista beállítások eléréséhez. A fő belépési pont az [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/get_bullet/), amely egy [IBulletFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibulletformat/) objektumot ad vissza. Ezzel az objektummal beállíthatja a felsorolás típusát, szimbólumát, képét, színét, méretét, számozási stílusát és a kezdő számot.

Ez a cikk bemutatja, hogyan:

- felsorolás létrehozása egy egyedi szimbólummal
- képjelölő létrehozása
- többszintű lista létrehozása a bekezdés mélységének beállításával
- számozott lista létrehozása
- lista formázásának megtekintése és módosítása egy meglévő prezentációban

## **Felsorolás létrehozása**

Felsorolás létrehozásához adjon [Paragraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides/paragraph/) objektumokat egy [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/)-hez, és állítsa be az [IBulletFormat::set_Type](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibulletformat/set_type/) értékét a [BulletType::Symbol](https://reference.aspose.com/slides/hu/cpp/aspose.slides/bullettype/)-ra. Ezután beállíthatja az [IBulletFormat::set_Char](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibulletformat/set_char/), [IBulletFormat::get_Color](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibulletformat/get_color/) és [IBulletFormat::set_Height](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibulletformat/set_height/) értékeket a felsorolás megjelenésének szabályozásához.

Az alábbi C++ kód bemutatja, hogyan hozhat létre felsorolást egy dián:

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

Az eredmény:

![A szimbólum jelölők](symbol_bullets.png)

## **Számozott lista létrehozása**

Használjon számozott listákat, ha az elemek sorrendje fontos. Állítsa az [IBulletFormat::set_Type](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibulletformat/set_type/) értékét a [BulletType::Numbered](https://reference.aspose.com/slides/hu/cpp/aspose.slides/bullettype/)-ra. Választhat számozási formátumot az [IBulletFormat::set_NumberedBulletStyle](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibulletformat/set_numberedbulletstyle/) segítségével, vagy beállíthatja a [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) értékét, ha a lista nem 1‑től szeretne indulni.

Az alábbi C++ kód megmutatja, hogyan hozhat létre számozott listát egy dián:

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

Az eredmény:

![A számozott jelölők](numbered_bullets.png)

## **Képjelölő létrehozása**

Az Aspose.Slides lehetővé teszi, hogy egy szabályos felsorolás szimbólumát képpel helyettesítse. A képjelölők leginkább egyszerű, kicsi méretben is olvasható képekkel működnek, például ikonokkal vagy átlátszó PNG fájlokkal.

{{% alert color="primary" %}}

Ideális esetben, ha a szabályos felsorolás szimbólumát képpel akarja helyettesíteni, a legjobb egy egyszerű, átlátszó háttérrel rendelkező grafikát választani. Az ilyen képek jól használhatók egyedi felsorolás‑szimbólumokként.

Tartsa szem előtt, hogy a képet nagyon kicsire kell méretezni. Emiatt erősen ajánljuk, hogy olyan képet válasszon, amely tiszta és vizuálisan hatékony marad, amikor felsorolás‑elemként használják.

{{% /alert %}}

Képjelölő létrehozásához adjon képet a [IPresentation::get_Images](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/get_images/) gyűjteményhez, és a visszakapott [IPPImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ippimage/) objektumot rendelje az [IBulletFormat::get_Picture](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibulletformat/get_picture/) property‑hez. A kép hozzárendelése előtt állítsa be az [IBulletFormat::set_Type](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibulletformat/set_type/) értékét a [BulletType::Picture](https://reference.aspose.com/slides/hu/cpp/aspose.slides/bullettype/)‑ra.

Tegyük fel, hogy van egy "image.png" nevű fájlunk:

![Kép a felsoroláshoz](picture_for_bullets.png)

Az alábbi C++ kód megmutatja, hogyan hozhat létre képjelölőket egy dián:

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

Az eredmény:

![A képjelölők](picture_bullets.png)

## **Többszintű lista létrehozása**

Használja az [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_depth/) metódust a listaelemek különböző szintekre helyezéséhez. Az 0‑szint a legfelső szint, az 1‑szint alatta van, stb.

Az alábbi C++ kód bemutatja, hogyan hozhat létre többszintű felsorolást:

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

Az eredmény:

![A többszintű lista](multilevel_list.png)

## **Meglévő lista módosítása**

A lista formázásának módosításához egy meglévő prezentációban, érje el a cél bekezdést, és frissítse annak [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/get_bullet/) beállításait. A listák létrehozásához használt ugyanazok a tulajdonságok használhatók a PPT, PPTX vagy ODP fájlból betöltött listák vizsgálatához vagy módosításához.

Az alábbi C++ kód a szövegkeret első bekezdését számozott lista stílusra állítja:

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

## **GYIK**

**Exportálhatóak a felsorolás‑ és számozott listák PDF‑re vagy képekre?**

Igen. Az Aspose.Slides megőrzi a lista formázását, ha a célnyelv támogatja a megfelelő szövegelrendezést és felsorolás‑jellemzőket.

**Szerkeszthetek listákat meglévő prezentációkban?**

Igen. Töltse be a prezentációt, érje el a cél bekezdést, vizsgálja vagy frissítse annak [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/get_bullet/) beállításait, majd mentse a prezentációt.

**Tartalmazhatnak a listák nem latin betűket?**

Igen. A listaelemek szövege Unicode karaktereket tartalmazhat, így többnyelvű listákat hozhat létre. Győződjön meg arról, hogy a prezentációban használt betűkészletek támogatják a szükséges karaktereket.