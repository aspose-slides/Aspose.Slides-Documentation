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
description: "Kezelje a prezentációs megjegyzéseket Az Aspose.Slides for C++ segítségével: gyorsan és egyszerűen adjon hozzá, olvasson, szerkesszen, válaszoljon, és távolítson el megjegyzéseket PowerPoint prezentációkban."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan kezelhetők a prezentáció megjegyzései az Aspose.Slides for C++ segítségével. Bemutatja a fő megjegyzéssel kapcsolatos típusokat, és megmutatja, hogyan adhatunk megjegyzéseket a diákhoz, hogyan érhetjük el a meglévő megjegyzéseket, hogyan dolgozhatunk válaszokkal és modern megjegyzésekkel, valamint hogyan távolíthatók el a megjegyzések a prezentációból.

Az példák a PowerPointban gyakran előforduló felülvizsgálati és együttműködési eseteket fedik le, például a megjegyzések íróhoz rendelését, a megjegyzések szövegének és metaadatainak olvasását, a válaszkötetek építését, illetve a kiválasztott vagy az összes megjegyzés eltávolítását.

A PowerPointban a megjegyzések annotációként jelennek meg a diákon. Egy megjegyzés kiválasztása megjeleníti annak szövegét és a hozzá kapcsolódó vitát.

Ahhoz, hogy a megjegyzéseket a prezentáció megnyitásakor megjeleníteni vagy elrejteni lehessen a megjegyzések módosítása nélkül, lásd [Megjegyzések megjelenítése vagy elrejtése a prezentáció megnyitásakor](/slides/hu/cpp/presentation-view-properties/).

## **Miért adjunk megjegyzéseket a prezentációkhoz?**

A megjegyzéseket felhasználhatja visszajelzés nyújtására és a kollégákkal való együttműködésre a prezentációk felülvizsgálata során.

Az Aspose.Slides for C++ a következő API-kat biztosítja a megjegyzésekkel való munkához:
* A [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) osztály, amely hozzáférést biztosít a prezentáció megjegyzésíróihoz.
* Az [ICommentCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/) interfész, amely az egyes szerzőkhöz kapcsolódó megjegyzéseket képviseli.
* Az [IComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/) interfész, amely információkat ad egy megjegyzésről, beleértve a szerzőt, a létrehozás időpontját, a pozíciót és a szöveget.
* A [CommentAuthor](https://reference.aspose.com/slides/cpp/aspose.slides/commentauthor/) osztály, amely információkat szolgáltat egy szerzőről, beleértve a nevét, a monogramját és a kapcsolódó megjegyzéseket.

## **Megjegyzések hozzáadása a diákhoz**

A példa két diát hoz létre, és egy megjegyzésírót regisztrál az [AddAuthor](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/addauthor/). Az [AddComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addcomment/) segítségével egy megjegyzést helyez el minden dián, majd a [GetSlideComments](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getslidecomments/) segítségével lekéri az első dia megjegyzéseit az adott szerző számára. A konzol kétszer jeleníti meg az első megjegyzés szövegét, bemutatva a hozzáférést mind a dia, mind a szerző útján, és a mentett prezentáció mindkét megjegyzést tartalmazza.

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

## **Megjegyzésíró keresése vagy létrehozása**

Amikor egy automatizált felülvizsgálat többször dolgozza fel ugyanazt a prezentációt, a szerző hozzáadása előtt keresse meg a [get_CommentAuthors](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_commentauthors/) által visszaadott gyűjteményt. A [FindByNameAndInitials](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/findbynameandinitials/) egyezést keres a név és a monogram alapján, és egy tömböt ad vissza a megfelelő szerzőkkel, vagy egy üres tömböt, ha nincs egyezés. Ezzel szemben a [FindByName](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/findbyname/) csak név alapján keres, a monogramtól függetlenül. Ha a [AddAuthor](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/addauthor/) hívás olyan nevet és monogramot ad meg, amely már létezik a gyűjteményben, kivételt dob.

A példa egy legalább egy diát tartalmazó prezentációfájlt igényel. Két átfutás során újra felhasználja az első egyező szerzőt, vagy csak akkor hoz létre újat, ha az eredmény üres. Ha több egyezés van, az első tömbelemet választja ki, a többi szerzőt összevonás vagy eltávolítás nélkül hagyja. Ezután a [AddComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addcomment/) metódust hívja a kiválasztott szerzőre, és menti a prezentációt. A második átfutás megnyitja az első átfutás kimenetét, és megismétli a műveletet.

```cpp
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/date_time.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

const String authorName = u"Reviewer";
const String authorInitials = u"RV";

auto inputFile = String(u"input.pptx");
auto position = PointF(20.0f, 20.0f);

for (auto pass = 1; pass <= 2; pass++)
{
    auto presentation = MakeObject<Presentation>(inputFile);

    auto matches = presentation->get_CommentAuthors()->FindByNameAndInitials(authorName, authorInitials);

    auto author = matches->get_Length() > 0 ? matches[0] : presentation->get_CommentAuthors()->AddAuthor(authorName, authorInitials);
    author->get_Comments()->AddComment(u"Please review this slide.", presentation->get_Slide(0), position, DateTime::get_Now());

    auto outputFile = String::Format(u"review_pass_{0}.pptx", pass);
    presentation->Save(outputFile, SaveFormat::Pptx);
    inputFile = outputFile;
}
```

A második átfutás egy újabb megjegyzést ad hozzá anélkül, hogy új szerzőt hozna létre vagy meglévő megjegyzéseket eltávolítana. A végső fájl, `review_pass_2.pptx`, mindkét új megjegyzést tartalmazza, valamint az esetleges eredeti megjegyzéseket is. Egy szerző újrafelhasználása nem szűri ki a duplikátumokat: a ugyanazon megjegyzés többszöri hozzáadásának elkerülése érdekében külön duplikátum-ellenőrzést kell bevezetni a hozzáadás előtt.

## **Megjegyzések elérése a diákban**

A példa megnyit egy meglévő prezentációt, és beolvassa a [get_CommentAuthors](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_commentauthors/) által visszaadott gyűjteményt. Minden szerzőre iterál a [get_Comments](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthor/get_comments/) által visszaadott gyűjteményen, és kiírja a dia számát, a megjegyzés szövegét, a szerző nevét és a létrehozás idejét. A bemeneti prezentációnak megjegyzéseket kell tartalmaznia, hogy a konzolra kimenet kerüljön.

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

## **Válasz a megjegyzésekre**

Egy szülő megjegyzés a válaszhierarchia tetején lévő eredeti megjegyzés. Az [IComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/) interfész [get_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/get_parentcomment/) és [set_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) metódusai lehetővé teszik a megjegyzés szülőjének lekérését vagy beállítását.

A példa két szerzőtől származó megjegyzéseket hoz létre, és a [set_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) segítségével felépíti a válaszokat, beleértve egy választ egy másik válaszra is. A `nullptr` átadása a [GetSlideComments](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getslidecomments/) metódusnak az összes szerző megjegyzéseit adja vissza; a konzol minden bejegyzést a válaszhierarchia mélysége szerint indentál. A példa elmenti a teljes vitát, meghívja a [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/remove/) metódust az első gyökér megjegyzésen, és egy második prezentációt ment, ahol az a megjegyzés és válaszai eltávolításra kerülnek.

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

auto originalAuthor = presentation->get_CommentAuthors()->AddAuthor(u"Author_1", u"A.A.");
auto rootComment = originalAuthor->get_Comments()->AddComment(u"comment 1", slide, position, createdTime);

auto reviewer = presentation->get_CommentAuthors()->AddAuthor(u"Author_2", u"B.B.");
auto firstReply = reviewer->get_Comments()->AddComment(u"reply 1 for comment 1", slide, position, createdTime);
firstReply->set_ParentComment(rootComment);

auto secondReply = reviewer->get_Comments()->AddComment(u"reply 2 for comment 1", slide, position, createdTime);
secondReply->set_ParentComment(rootComment);

auto subReply = originalAuthor->get_Comments()->AddComment(u"subreply 3 for reply 2", slide, position, createdTime);
subReply->set_ParentComment(secondReply);

reviewer->get_Comments()->AddComment(u"comment 2", slide, position, createdTime);
auto separateComment = reviewer->get_Comments()->AddComment(u"comment 3", slide, position, createdTime);

auto separateReply = originalAuthor->get_Comments()->AddComment(u"reply 4 for comment 3", slide, position, createdTime);
separateReply->set_ParentComment(separateComment);

auto comments = slide->GetSlideComments(nullptr);
for (auto i = 0; i < comments->get_Length(); i++)
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

rootComment->Remove();
presentation->Save(u"remove_comment.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="Warning" %}}
* Amikor a [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/remove/) metódust a [IComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/) interfész használja egy megjegyzés törlésére, a megjegyzésre adott összes válasz is törlésre kerül.
* Ha a [set_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) metódus körkörös hivatkozást hoz létre, akkor egy [PptxEditException](https://reference.aspose.com/slides/cpp/aspose.slides/pptxeditexception/) kivétel dobódik.
{{% /alert %}}

## **Modern megjegyzések hozzáadása**

A modern megjegyzések a diára, egy konkrét alakzatra vagy egy AutoShape szövegtartományára is hivatkozhatnak. Az [ICommentCollection::AddModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addmoderncomment/) metódus egy [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) paramétert is elfogad a dia és a megjegyzésjelző koordinátái mellett.

Ha a `nullptr` érték kerül átadásra az alakzat argumentumnak, a megjegyzés egy dia-szintű megjegyzés lesz. A jelzőt a megadott koordináták helyezik el, de nincs hozzárendelve konkrét alakzathoz, így az [IModernComment::get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/) `nullptr`-t ad vissza. Ha egy [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) van megadva, a megjegyzés arra az alakzatra lesz rögzítve. A koordináták továbbra is a megjegyzésjelző pozícióját határozzák a dián, míg az alakzat-hivatkozást a [IModernComment::get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/) segítségével lehet lekérni.

### **Modern megjegyzés rögzítése egy alakzatra**

A példa kétszer hívja meg az [AddModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addmoderncomment/) metódust: egyszer egy `nullptr` alakzattal egy dia-szintű megjegyzéshez, és egyszer egy téglalappal, mint rögzítő pont. A [get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/) hívás `True`-t ír ki a dia-szintű megjegyzés null ellenőrzésére és a `Revenue title`-t a rögzített megjegyzésre. Mindkét megjegyzés a prezentációval együtt kerül mentésre.

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

### **Megjegyzések rögzítése különböző alakzattípusokra**

Bármely, [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) interfészt megvalósító diaobjektum használható alakzat rögzítésként. Gyakori példák: [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/cpp/aspose.slides/iconnector/), valamint [IGraphicalObject](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobject/) példányok, például diagramok.

A példa az [AddModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addmoderncomment/) segítségével egy megjegyzést kapcsol minden egyes öt alakzattípushoz: egy AutoShape-hez, egy képkerethez, egy csoporthoz, egy összekötőhöz és egy diagramhoz. A kép beágyazott képadatot használ, így külső képre nincs szükség. Minden megjegyzésnek saját jelzőpozíciója van, és a mentett prezentáció megtartja az öt alakzat-hivatkozást.

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

### **Megjegyzés rögzítése szövegre és állapotának beállítása**

Egy [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)‑hez kapcsolódó modern megjegyzésnél az [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionstart/) és az [IModernComment::set_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionstart/) határozzák meg a kiválasztott szöveg kezdőpozícióját az alakzat szövegdobozában. Hasonló módon az [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionlength/) és az [IModernComment::set_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionlength/) szabályozzák a kiválasztás hosszát. Ezek a metódusok együtt a megjegyzést egy adott szövegtartományhoz kapcsolják az AutoShape‑ben.

Az [IModernComment::get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_status/) és [IModernComment::set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_status/) egy [ModernCommentStatus](https://reference.aspose.com/slides/cpp/aspose.slides/moderncommentstatus/) felsorolásból származó értéket használ, amely tartalmazza a `Resolved` állapotot.
- `NotDefined` — nincs meghatározott modern megjegyzés állapot.
- `Active` — a megjegyzés aktív.
- `Resolved` — a megjegyzés megoldott.
- `Closed` — a megjegyzés lezárt.

A példa egy modern megjegyzést rögzít a "quarterly revenue" szavakra egy téglalap szövegében. Kiszámítja a nullától induló kiválasztás kezdő indexét a szövegből, átadja a [set_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionstart/) metódusnak, és a [set_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionlength/)‑t a kiválasztott karakterek számával hívja meg. A [set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_status/) `Resolved` értékkel történő meghívása után menti és újra megnyitja a prezentációt. A négy konzol-ellenőrzés mind `True`‑t kell, hogy kiírjon, megerősítve, hogy az alakzat‑ankor, a szövegtartomány és az állapot megmaradt.

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

### **Meglévő modern megjegyzések vizsgálata**

A példa egy olyan meglévő prezentációt igényel, amely modern megjegyzéseket tartalmaz, és kiírja azok szövegét, állapotát és rögzítési részleteit. A vizsgálathoz ellenőrizze, mely megjegyzések implementálják az [IModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/) interfészt, majd vizsgálja meg az [IModernComment::get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/), [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionstart/), [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionlength/) és [IModernComment::get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_status/) metódusokat. A `nullptr` alakzat egy dia-szintű megjegyzést jelöl. Egy [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) rögzítés esetén a szövegkijelölés metódusai meghatározzák a kapcsolódó tartományt az alakzat szövegdobozában.

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

## **Megjegyzések eltávolítása**

Az Aspose.Slides for C++ lehetővé teszi, hogy egy prezentációból eltávolítsa az összes megjegyzést és azok szerzőit, vagy egyes megjegyzéseket töröljön a többi megőrzése mellett. A következő példák mindkét megközelítést bemutatják, és elmentik a frissített prezentációt.

### **Minden megjegyzés és megjegyzésíró eltávolítása**

A példa megnyit egy meglévő prezentációt, és minden szerzőre meghívja az [ICommentCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/clear/) metódust, majd az [ICommentAuthorCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/clear/) metódust a szerzők eltávolításához. A mentett prezentáció sem megjegyzéseket, sem megjegyzésírókat nem tartalmaz. A törlés megfigyeléséhez használjon olyan prezentációt, amely megjegyzéseket tartalmaz.

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

### **Kiválasztott megjegyzések eltávolítása**

A példa egy dián két megjegyzést hoz létre, és a [GetSlideComments](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getslidecomments/) segítségével keresi meg a megjegyzéseket szerzőként. A [ICommentCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/remove/) meghívása előtt összegyűjti azokat a megjegyzéseket, amelyek szövege "comment 1". Így elkerüli a gyűjtemény módosítását a kiválasztás során. A mentett prezentáció csak a "comment 2"-t tartja meg.

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

## **FAQ**

**Támogatja az Aspose.Slides a megoldott állapotot a modern megjegyzésekhez?**

Igen. Az [IModernComment::get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_status/) és az [IModernComment::set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_status/) egy [ModernCommentStatus](https://reference.aspose.com/slides/cpp/aspose.slides/moderncommentstatus/) értéket használ, amely tartalmazza a `Resolved` állapotot. Az állapot a prezentációban tárolódik, és a fájl újra megnyitása után újra leolvasható.

**Támogatják a szálas vitákat (válaszköteteket), és van-e beágyazási korlát?**

Igen. Minden megjegyzés hivatkozhat a [parent comment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/), ami lehetővé teszi a válaszköteteket. Az API nem határoz meg konkrét beágyazási mélységkorlátot.

**Milyen koordináta‑rendszerben van meghatározva egy megjegyzésjelző pozíciója a dián?**

A jelző pozíciója lebegőpontos koordinátákkal van definiálva a dia koordináta‑rendszerében, ami lehetővé teszi a pontos elhelyezést a dián.