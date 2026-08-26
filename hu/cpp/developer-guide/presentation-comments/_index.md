---
title: Prezentációs megjegyzések kezelése C++-ban
linktitle: Prezentációs megjegyzések
type: docs
weight: 100
url: /hu/cpp/presentation-comments/
keywords:
- megjegyzés
- modern megjegyzés
- PowerPoint megjegyzések
- prezentációs megjegyzések
- dia megjegyzések
- megjegyzés hozzáadása
- megjegyzés elérése
- megjegyzés szerkesztése
- megjegyzésre válasz
- megjegyzés eltávolítása
- megjegyzés törlése
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Prezentációs megjegyzések kezelése az Aspose.Slides for C++ segítségével: megjegyzések hozzáadása, olvasása, szerkesztése, válaszolás, és eltávolítása PowerPoint prezentációkban gyorsan és egyszerűen."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan kezelhetők a prezentáció megjegyzései az Aspose.Slides for C++ használatával. Bemutatja a megjegyzésekkel kapcsolatos fő típusokat, valamint azt, hogyan adhatunk megjegyzéseket diákhoz, érhetjük el a meglévő megjegyzéseket, dolgozhatunk válaszokkal és modern megjegyzésekkel, és hogyan távolíthatunk el megjegyzéseket egy prezentációból.

A példák a PowerPoint általános felülvizsgálati és együttműködési forgatókönyveit fedik le, például a megjegyzések szerzőkhöz rendelését, a megjegyzés szövegének és metaadatainak olvasását, válaszláncok építését, valamint a kiválasztott vagy az összes megjegyzés eltávolítását.

A PowerPointban a megjegyzések annotációként jelennek meg a diákon. Egy megjegyzés kiválasztásakor megjelenik a szövege és a kapcsolódó beszélgetés.

## **Miért adjunk megjegyzéseket a prezentációkhoz?**

Megjegyzésekkel visszajelzést adhat és együttműködhet kollégáival a prezentációk felülvizsgálata során.

Az Aspose.Slides for C++ a megjegyzésekkel való munkához a következő API‑kat biztosítja:

* A [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztály, amely hozzáférést biztosít a prezentáció megjegyzés‑szerzőihez.
* Az [ICommentCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icommentcollection/) interfész, amely egy adott szerzőhöz tartozó megjegyzéseket képviseli.
* Az [IComment](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icomment/) interfész, amely információkat nyújt egy megjegyzésről, beleértve annak szerzőjét, létrehozási idejét, pozícióját és szövegét.
* A [CommentAuthor](https://reference.aspose.com/slides/hu/cpp/aspose.slides/commentauthor/) osztály, amely információkat ad egy szerzőről, például a nevét, inicialjait és a kapcsolódó megjegyzéseket.

## **Dia Megjegyzések Hozzáadása**

Az alábbi példa bemutatja, hogyan adhatunk megjegyzéseket diákhoz egy PowerPoint‑prezentációban:

```cpp
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/console.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto firstSlide = presentation->get_Slide(0);
auto secondSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_LayoutSlide(0));
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Jawad", u"MF");
auto position = PointF(0.2f, 0.2f);
auto createdTime = DateTime::get_Now();

author->get_Comments()->AddComment(u"Hello Jawad, this is a slide comment", firstSlide, position, createdTime);
author->get_Comments()->AddComment(u"Hello Jawad, this is the second slide comment", secondSlide, position, createdTime);

auto comments = firstSlide->GetSlideComments(author);
if (comments->get_Length() > 0)
{
    auto firstComment = comments[0];
    Console::WriteLine(firstComment->get_Text());

    auto commentText = firstComment->get_Author()->get_Comments()->idx_get(0)->get_Text();
    Console::WriteLine(commentText);
}

presentation->Save(u"Comments_out.pptx", SaveFormat::Pptx);
```

## **Dia Megjegyzések Elérése**

Az alábbi példa bemutatja, hogyan érhetők el a meglévő megjegyzések egy PowerPoint‑prezentációban:

```cpp
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Comments1.pptx");

for (auto&& author : presentation->get_CommentAuthors())
{
    for (auto&& comment : author->get_Comments())
    {
        Console::WriteLine(u"Slide: {0}", comment->get_Slide()->get_SlideNumber());
        Console::WriteLine(u"Comment: {0}", comment->get_Text());
        Console::WriteLine(u"Author: {0}", comment->get_Author()->get_Name());
        Console::WriteLine(u"Posted at: {0}", comment->get_CreatedTime());
        Console::WriteLine();
    }
}
```

## **Válasz a Megjegyzésekre**

A szülőmegjegyzés a válaszhierarchia tetején lévő eredeti megjegyzés. Az [IComment](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icomment/) interfész [get_ParentComment](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icomment/get_parentcomment/) és [set_ParentComment](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icomment/set_parentcomment/) metódusai lehetővé teszik egy megjegyzés szülőjének lekérdezését vagy beállítását.

Az alábbi példa bemutatja, hogyan adhatunk válaszokat, és hogyan vizsgálhatjuk meg a keletkezett megjegyzés‑hierarchiát:

```cpp
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/console.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto position = PointF(10.0f, 10.0f);
auto createdTime = DateTime::get_Now();

auto author1 = presentation->get_CommentAuthors()->AddAuthor(u"Author_1", u"A.A.");
auto comment1 = author1->get_Comments()->AddComment(u"comment 1", slide, position, createdTime);

auto author2 = presentation->get_CommentAuthors()->AddAuthor(u"Author_2", u"B.B.");
auto reply1 = author2->get_Comments()->AddComment(u"reply 1 for comment 1", slide, position, createdTime);
reply1->set_ParentComment(comment1);

auto reply2 = author2->get_Comments()->AddComment(u"reply 2 for comment 1", slide, position, createdTime);
reply2->set_ParentComment(comment1);

auto subReply = author1->get_Comments()->AddComment(u"subreply 3 for reply 2", slide, position, createdTime);
subReply->set_ParentComment(reply2);

author2->get_Comments()->AddComment(u"comment 2", slide, position, createdTime);
auto comment3 = author2->get_Comments()->AddComment(u"comment 3", slide, position, createdTime);

auto reply3 = author1->get_Comments()->AddComment(u"reply 4 for comment 3", slide, position, createdTime);
reply3->set_ParentComment(comment3);

auto comments = slide->GetSlideComments(nullptr);
for (int32_t i = 0; i < comments->get_Length(); i++)
{
    auto comment = comments[i];
    while (comment->get_ParentComment() != nullptr)
    {
        Console::Write(u"\t");
        comment = comment->get_ParentComment();
    }

    Console::WriteLine(u"{0}: {1}", comments[i]->get_Author()->get_Name(), comments[i]->get_Text());
}

presentation->Save(u"parent_comment.pptx", SaveFormat::Pptx);

comment1->Remove();
presentation->Save(u"remove_comment.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="Warning" %}}

* Amikor az [IComment](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icomment/) interfész [Remove](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icomment/remove/) metódusát használják egy megjegyzés törlésére, az annak a megjegyzésnek a minden válasza is törlődik.
* Ha a [set_ParentComment](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icomment/set_parentcomment/) metódus körkörös hivatkozást hoz létre, akkor egy [PptxEditException](https://reference.aspose.com/slides/hu/cpp/aspose.slides/pptxeditexception/) keletkezik.

{{% /alert %}}

## **Modern Megjegyzések Hozzáadása**

Modern megjegyzések a diára, egy konkrét alakra vagy egy AutoShape‑on belüli szövegtartományra vonatkozhatnak. Az [ICommentCollection::AddModernComment](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icommentcollection/addmoderncomment/) metódus egy [IShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/) argumentumot is elfogad a dia és a megjegyzés‑jelző koordinátái mellett.

Ha a shape argumentumként `nullptr` kerül átadásra, a megjegyzés dia‑szintű megjegyzés lesz. Jelzője a megadott koordináták alapján helyezkedik el, de nem kapcsolódik konkrét alakhoz, ezért az [IModernComment::get_Shape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imoderncomment/get_shape/) `nullptr`‑t ad vissza. Ha egy [IShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/) kerül megadásra, a megjegyzés ehhez az alakhoz lesz rögzítve. A koordináták továbbra is a megjegyzés jelzőjének pozícióját határozzák meg a dián, míg az alakkapcsolat az [IModernComment::get_Shape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imoderncomment/get_shape/) segítségével kérdezhető le.

### **Modern Megjegyzés Rögzítése Alakzatra**

Az alábbi példa létrehoz egy dia‑szintű modern megjegyzést és egy AutoShape‑ra rögzített modern megjegyzést, majd minden megjegyzéshez kiolvassa a kapcsolódó alakot.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/IModernComment.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/console.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Reviewer", u"RV");
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 300.0f, 80.0f);
shape->set_Name(u"Revenue title");
shape->get_TextFrame()->set_Text(u"Quarterly revenue");

auto createdTime = DateTime::get_Now();
auto slideCommentPosition = PointF(20.0f, 20.0f);
auto shapeCommentPosition = PointF(60.0f, 60.0f);
auto slideComment = author->get_Comments()->AddModernComment(u"Review the overall slide layout.", slide, nullptr, slideCommentPosition, createdTime);
auto shapeComment = author->get_Comments()->AddModernComment(u"Check this title.", slide, shape, shapeCommentPosition, createdTime);

Console::WriteLine(slideComment->get_Shape() == nullptr);
auto shapeAnchor = shapeComment->get_Shape();
if (shapeAnchor != nullptr)
{
    Console::WriteLine(shapeAnchor->get_Name());
}

presentation->Save(u"modern_comments.pptx", SaveFormat::Pptx);
```

### **Megjegyzések Rögzítése Különböző Alakzat Típusokra**

Bármely diaobjektum, amely megvalósítja az [IShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/) interfészt, használható alak‑horgonyként. Gyakori példák: [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iconnector/) és [IGraphicalObject](https://reference.aspose.com/slides/hu/cpp/aspose.slides/igraphicalobject/) példányok, mint például diagramok.

Az alábbi példa több gyakori alakzat típust hoz létre, és mindegyikhez modern megjegyzést csatol.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/IConnector.h>
#include <DOM/IGroupShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/convert.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Reviewer", u"RV");
auto createdTime = DateTime::get_Now();

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 180.0f, 60.0f);
autoShape->get_TextFrame()->set_Text(u"AutoShape");
auto autoShapeCommentPosition = PointF(30.0f, 30.0f);
author->get_Comments()->AddModernComment(u"Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

auto imageBase64 = u"iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
auto imageData = Convert::FromBase64String(imageBase64);
auto image = presentation->get_Images()->AddImage(imageData);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 220.0f, 20.0f, 120.0f, 80.0f, image);
auto pictureCommentPosition = PointF(230.0f, 30.0f);
author->get_Comments()->AddModernComment(u"Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

auto groupShape = slide->get_Shapes()->AddGroupShape();
groupShape->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0.0f, 0.0f, 80.0f, 40.0f);
groupShape->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 100.0f, 0.0f, 80.0f, 40.0f);
auto groupCommentPosition = PointF(40.0f, 150.0f);
author->get_Comments()->AddModernComment(u"Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

auto connector = slide->get_Shapes()->AddConnector(ShapeType::StraightConnector1, 220.0f, 150.0f, 140.0f, 40.0f);
auto connectorCommentPosition = PointF(240.0f, 150.0f);
author->get_Comments()->AddModernComment(u"Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 400.0f, 20.0f, 250.0f, 180.0f);
auto chartCommentPosition = PointF(420.0f, 40.0f);
author->get_Comments()->AddModernComment(u"Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

presentation->Save(u"modern_comment_shape_types.pptx", SaveFormat::Pptx);
```

### **Megjegyzés Rögzítése Szöveghez és Állapotának Beállítása**

Egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/)-hez kapcsolt modern megjegyzés esetén az [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imoderncomment/get_textselectionstart/) és az [IModernComment::set_TextSelectionStart](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imoderncomment/set_textselectionstart/) határozza meg a kiválasztott szöveg kezdőpozícióját az alak szövegtartományában. Hasonlóképpen az [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imoderncomment/get_textselectionlength/) és az [IModernComment::set_TextSelectionLength](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imoderncomment/set_textselectionlength/) szabályozza a kiválasztás hosszát. Ezek a metódusok együtt a megjegyzést egy adott szövegtartományhoz kapcsolják az AutoShape‑on belül.

Az [IModernComment::get_Status](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imoderncomment/get_status/) és az [IModernComment::set_Status](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imoderncomment/set_status/) metódusok a [ModernCommentStatus](https://reference.aspose.com/slides/hu/cpp/aspose.slides/moderncommentstatus/) felsorolás egyik értékét használják:

- `NotDefined` — nincs meghatározott modern‑megjegyzés állapot.
- `Active` — a megjegyzés aktív.
- `Resolved` — a megjegyzés megoldott.
- `Closed` — a megjegyzés lezárt.

Az alábbi példa létrehoz egy alakra rögzített modern megjegyzést, szövegválasztáshoz csatolja, megoldottnak jelöli, elmenti a prezentációt, majd a fájl újranyitása után ellenőrzi az értékeket.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/IModernComment.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ModernCommentStatus.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/console.h>
#include <system/date_time.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

const String outputFile = u"modern_comment_text_anchor.pptx";
const String shapeText = u"Review the quarterly revenue forecast.";
const String selectedText = u"quarterly revenue";
auto expectedSelectionStart = shapeText.IndexOf(selectedText);

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 400.0f, 100.0f);
shape->set_Name(u"Forecast text");
shape->get_TextFrame()->set_Text(shapeText);

auto author = presentation->get_CommentAuthors()->AddAuthor(u"Reviewer", u"RV");
auto commentPosition = PointF(60.0f, 60.0f);
auto comment = author->get_Comments()->AddModernComment(u"Verify this forecast wording.", slide, shape, commentPosition, DateTime::get_Now());
comment->set_TextSelectionStart(expectedSelectionStart);
comment->set_TextSelectionLength(selectedText.get_Length());
comment->set_Status(ModernCommentStatus::Resolved);

presentation->Save(outputFile, SaveFormat::Pptx);

auto reopenedPresentation = MakeObject<Presentation>(outputFile);
auto reopenedSlide = reopenedPresentation->get_Slide(0);
auto reopenedComments = reopenedSlide->GetSlideComments(nullptr);

for (auto&& reopenedComment : reopenedComments)
{
    auto modernComment = AsCast<IModernComment>(reopenedComment);
    if (modernComment == nullptr)
    {
        continue;
    }

    auto shapeAnchor = modernComment->get_Shape();
    auto shapeMatches = shapeAnchor != nullptr && shapeAnchor->get_Name() == u"Forecast text";
    auto selectionStartMatches = modernComment->get_TextSelectionStart() == expectedSelectionStart;
    auto selectionLengthMatches = modernComment->get_TextSelectionLength() == selectedText.get_Length();
    auto statusMatches = modernComment->get_Status() == ModernCommentStatus::Resolved;

    Console::WriteLine(u"Shape anchor preserved: {0}", shapeMatches);
    Console::WriteLine(u"Text selection start preserved: {0}", selectionStartMatches);
    Console::WriteLine(u"Text selection length preserved: {0}", selectionLengthMatches);
    Console::WriteLine(u"Resolved status preserved: {0}", statusMatches);
}
```

### **Meglévő Modern Megjegyzések Ellenőrzése**

Egy meglévő prezentáció vizsgálatához ellenőrizze, mely megjegyzések valósítják meg az [IModernComment](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imoderncomment/) interfészt, majd vizsgálja meg az [IModernComment::get_Shape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imoderncomment/get_shape/), [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imoderncomment/get_textselectionstart/), [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imoderncomment/get_textselectionlength/) és [IModernComment::get_Status](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imoderncomment/get_status/) metódusokat. A `nullptr` alak dia‑szintű megjegyzést jelez. Egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) horgonynál a szöveg‑kiválasztási metódusok a kapcsolódó tartományt az alak szövegtartományában határozzák meg.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IComment.h>
#include <DOM/IModernComment.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ModernCommentStatus.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"comments.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto comments = slide->GetSlideComments(nullptr);
    for (auto&& comment : comments)
    {
        auto modernComment = AsCast<IModernComment>(comment);
        if (modernComment == nullptr)
        {
            continue;
        }

        Console::WriteLine(u"Slide: {0}", slide->get_SlideNumber());
        Console::WriteLine(u"Text: {0}", modernComment->get_Text());
        Console::WriteLine(u"Status: {0}", modernComment->get_Status());

        auto shape = modernComment->get_Shape();
        if (shape == nullptr)
        {
            Console::WriteLine(u"Anchor: slide level");
        }
        else
        {
            Console::WriteLine(u"Anchor shape: {0}", shape->get_Name());
            Console::WriteLine(u"Anchor type: {0}", shape->GetType().get_Name());

            auto autoShape = AsCast<IAutoShape>(shape);
            if (autoShape != nullptr)
            {
                Console::WriteLine(u"Text selection start: {0}", modernComment->get_TextSelectionStart());
                Console::WriteLine(u"Text selection length: {0}", modernComment->get_TextSelectionLength());
            }
        }

        Console::WriteLine();
    }
}
```

## **Megjegyzések Eltávolítása**

### **Minden Megjegyzés és Megjegyzés Szerző Eltávolítása**

Az alábbi példa bemutatja, hogyan távolítható el minden megjegyzés és megjegyzés‑szerző egy prezentációból:

```cpp
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"example.pptx");

for (auto&& author : presentation->get_CommentAuthors())
{
    author->get_Comments()->Clear();
}

presentation->get_CommentAuthors()->Clear();
presentation->Save(u"example_out.pptx", SaveFormat::Pptx);
```

### **Specifikus Megjegyzések Eltávolítása**

Az alábbi példa bemutatja, hogyan távolítható el specifikus megjegyzés egy diáról:

```cpp
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/collections/list.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Author", u"A");
auto createdTime = DateTime::get_Now();

auto firstCommentPosition = PointF(0.2f, 0.2f);
auto secondCommentPosition = PointF(0.3f, 0.2f);
author->get_Comments()->AddComment(u"comment 1", slide, firstCommentPosition, createdTime);
author->get_Comments()->AddComment(u"comment 2", slide, secondCommentPosition, createdTime);

for (auto&& commentAuthor : presentation->get_CommentAuthors())
{
    auto commentsToRemove = MakeObject<List<SharedPtr<IComment>>>();
    auto comments = slide->GetSlideComments(commentAuthor);

    for (auto&& comment : comments)
    {
        if (comment->get_Text() == u"comment 1")
        {
            commentsToRemove->Add(comment);
        }
    }

    for (auto&& comment : commentsToRemove)
    {
        commentAuthor->get_Comments()->Remove(comment);
    }
}

presentation->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **GYIK**

**Támogatja-e az Aspose.Slides a modern megjegyzések megoldott állapotát?**

Igen. Az [IModernComment::get_Status](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imoderncomment/get_status/) és az [IModernComment::set_Status](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imoderncomment/set_status/) egy [ModernCommentStatus](https://reference.aspose.com/slides/hu/cpp/aspose.slides/moderncommentstatus/) értéket használ, többek között a `Resolved`‑t. Az állapot a prezentációban tárolódik, és a fájl újbóli megnyitása után újra kiolvasható.

**Támogatottak-e a szálas beszélgetések (válaszláncok), és van-e beágyazási korlát?**

Igen. Minden megjegyzés hivatkozhat a [szülő megjegyzésére](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icomment/set_parentcomment/), ami lehetővé teszi a válaszláncokat. Az API nem határoz meg konkrét beágyazási mélységkorlátot.

**Milyen koordináta‑rendszerben van meghatározva egy megjegyzés jelzőpontjának pozíciója a dián?**

A jelző pozíciója lebegőpontos koordinátákkal van meghatározva a dia koordináta‑rendszerében, ami lehetővé teszi a pontos elhelyezést a dián.