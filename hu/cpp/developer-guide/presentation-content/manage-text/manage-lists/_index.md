---
title: C++-ban felsorolásos és számozott listák kezelése prezentációkban
linktitle: Listák kezelése
type: docs
weight: 70
url: /hu/cpp/manage-lists/
keywords:
- jelölő
- felsoroláslista
- számozott lista
- szimbólum jelölő
- képes jelölő
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
description: "Ismerje meg, hogyan hozhat létre és formázhat felsorolásos, képes, többszintű és számozott listákat PowerPoint és OpenDocument prezentációkban az Aspose.Slides for C++ használatával."
---
## **Áttekintés**

Az Aspose.Slides for C++ lehetővé teszi, hogy felsorolás- és számozott listákat hozzon létre és formázzon PowerPoint és OpenDocument prezentációkban. Egy listaelem egy bekezdés, amelynek a jelölőbeállításait a bekezdés formátuma szabályozza.

Használja a [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraph/get_paragraphformat/) metódust a bekezdés szintű lista beállítások eléréséhez. A fő belépési pont a [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/get_bullet/), amely egy [IBulletFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibulletformat/) objektumot ad vissza. Ezzel az objektummal állíthatja be a jelölő típusát, szimbólumát, képét, színét, méretét, a számozás stílusát és a kezdő számot.

Ez a cikk bemutatja, hogyan:

- hozhat létre felsoroláslistát egy egyéni szimbólummal
- hozhat létre képes jelölőt
- hozhat létre többszintű listát a bekezdés mélységének beállításával
- hozhat létre számozott listát
- vizsgálhatja és módosíthatja a lista formázását egy meglévő prezentációban

## **Felsoroláslista létrehozása**

Felsoroláslista létrehozásához adjon [Paragraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides/paragraph/) objektumokat egy [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/)-hez, és állítsa be a [IBulletFormat::set_Type](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibulletformat/set_type/) értékét a [BulletType::Symbol](https://reference.aspose.com/slides/hu/cpp/aspose.slides/bullettype/) típusra. Ezután a [IBulletFormat::set_Char](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibulletformat/set_char/), a [IBulletFormat::get_Color](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibulletformat/get_color/) és a [IBulletFormat::set_Height](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibulletformat/set_height/) beállításokkal szabályozhatja a jelölő megjelenését.

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

Az eredmény:

![A szimbólum jelölőpontok](symbol_bullets.png)

## **Számozott lista létrehozása**

Számozott listákat akkor használjon, amikor az elemek sorrendje számít. Állítsa a [IBulletFormat::set_Type](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibulletformat/set_type/) értékét a [BulletType::Numbered](https://reference.aspose.com/slides/hu/cpp/aspose.slides/bullettype/) típusra. A számozás formátumát a [IBulletFormat::set_NumberedBulletStyle](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibulletformat/set_numberedbulletstyle/) segítségével választhatja ki, vagy a [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) beállítással adhat meg egy 1‑nél eltérő kezdő értéket.

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

Az eredmény:

![A számozott jelölőpontok](numbered_bullets.png)

## **Képes jelölőpont létrehozása**

Az Aspose.Slides lehetővé teszi, hogy egy szabványos jelölő szimbólumát egy képpel helyettesítse. A képes jelölőpontok leginkább egyszerű képekkel működnek, amelyek kis méretben is olvashatóak, például ikonok vagy kis átlátszó PNG fájlok.

{{% alert color="info" %}}
Ideális esetben, ha a szabványos jelölő szimbólumát képpel szeretné helyettesíteni, érdemes egy egyszerű, átlátszó háttérrel rendelkező grafikát választani. Az ilyen képek jól használhatók egyéni jelölő szimbólumokként.
{{% /alert %}}

Képes jelölőpont létrehozásához adjon képet a [IPresentation::get_Images](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/get_images/) gyűjteményhez, és rendelje hozzá a visszakapott [IPPImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ippimage/) objektumot a [IBulletFormat::get_Picture](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibulletformat/get_picture/) tulajdonsághoz. A kép hozzárendelése előtt állítsa be a [IBulletFormat::set_Type](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibulletformat/set_type/) értékét a [BulletType::Picture](https://reference.aspose.com/slides/hu/cpp/aspose.slides/bullettype/) típusra.

Tegyük fel, hogy van egy "image.png" fájlunk:

![Kép a jelölőpontokhoz](picture_for_bullets.png)

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

Az eredmény:

![A képes jelölőpontok](picture_bullets.png)

## **Többszintű lista létrehozása**

Használja a [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_depth/) metódust a listaelemek különböző szintekre helyezéséhez. A 0‑szint a legfelső szint, az 1‑szint alatta, és így tovább.

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

Az eredmény:

![A többszintű lista](multilevel_list.png)

## **Meglévő lista módosítása**

Meglévő prezentációban a lista formázásának módosításához érje el a célbekezdést, és frissítse annak [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/get_bullet/) beállításait. A listák létrehozásához használt ugyanazok a tulajdonságok felhasználhatók a PPT, PPTX vagy ODP fájlból betöltött listák vizsgálatára vagy módosítására.

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

## **GYIK**

### Exportálhatók a felsorolás- és számozott listák PDF‑re vagy képekre?

Igen. Az Aspose.Slides megőrzi a lista formázását, ha a célformátum támogatja a megfelelő szövegelrendezést és jelölő funkciókat.

### Szerkeszthetek listákat meglévő prezentációkban?

Igen. Töltse be a prezentációt, érje el a célbekezdést, vizsgálja meg vagy frissítse annak [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/get_bullet/) beállításait, majd mentse a prezentációt.

### Tartalmazhatnak a listák nem latin szöveget?

Igen. A listaelemek szövege Unicode karaktereket is tartalmazhat, így többnyelvű prezentációkban is létrehozhat listákat. Győződjön meg arról, hogy a prezentációban használt betűtípusok támogatják a szükséges karaktereket.