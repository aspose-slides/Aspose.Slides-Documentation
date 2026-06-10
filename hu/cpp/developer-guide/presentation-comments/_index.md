---
title: Prezentáció megjegyzéseinek kezelése C++-ban
linktitle: Prezentáció megjegyzései
type: docs
weight: 100
url: /hu/cpp/presentation-comments/
keywords:
- megjegyzés
- modern megjegyzés
- PowerPoint megjegyzések
- prezentáció megjegyzései
- dia megjegyzések
- megjegyzés hozzáadása
- megjegyzés elérése
- megjegyzés szerkesztése
- megjegyzésre válasz
- megjegyzés eltávolítása
- megjegyzés törlése
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Kezelje hatékonyan a prezentáció megjegyzéseket az Aspose.Slides for C++ segítségével: gyorsan és egyszerűen adjon hozzá, olvasson, szerkesszen és töröljön megjegyzéseket PowerPoint fájlokban."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan kezelhetők a prezentáció megjegyzései az Aspose.Slides‑ban. Megmutatja a megjegyzésekkel kapcsolatos fő típusokat, és bemutatja, hogyan adhat megjegyzéseket a diákhoz, érheti el a meglévő megjegyzéseket, kezelheti a válaszokat, használhat modern megjegyzéseket, és távolíthatja el a megjegyzéseket egy prezentációból.

A példák a PowerPointban gyakori felülvizsgálati és együttműködési helyzetekre fókuszálnak, például a megjegyzések szerzőkhöz való hozzárendelésére, a megjegyzés tartalmának és metaadatainak olvasására, válaszláncok felépítésére, valamint az összes megjegyzés törlésére vagy a kiválasztottak eltávolítására.

PowerPointban a megjegyzés egy jegyzetként vagy annotációként jelenik meg a dián. Amikor egy megjegyzésre kattintanak, a tartalma vagy üzenetei megjelennek.

### **Miért adjunk megjegyzéseket a prezentációkhoz?**

Érdemes megjegyzéseket használni a visszajelzéshez vagy a kollégákkal való kommunikációhoz a prezentációk felülvizsgálata során.

A PowerPoint prezentációkban való megjegyzések használatának lehetővé tételéhez az Aspose.Slides for C++ a következőket biztosítja:

* A [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztály, amely tartalmazza a szerzők gyűjteményét (a [get_CommentAuthors()](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation#ac100feeb13ea426b85557a829676227d) metódusból). A szerzők megjegyzéseket adnak hozzá a diákhoz. 
* A [ICommentCollection](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_comment_collection) interfész, amely egy adott szerző megjegyzéseinek gyűjteményét tartalmazza. 
* A [IComment](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_comment) osztály, amely információkat tartalmaz a szerzőkről és megjegyzéseikről: ki adta a megjegyzést, mikor adták hozzá, a megjegyzés pozíciója stb. 
* A [CommentAuthor](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.comment_author) osztály, amely egyes szerzőkről tartalmaz információkat: a szerző neve, monogramja, a szerző nevéhez kapcsolódó megjegyzések stb. 

## **Dia megjegyzés hozzáadása**
Ez a C++ kód bemutatja, hogyan adjon megjegyzést egy diához egy PowerPoint prezentációban:

```cpp
// Példányosítja a Presentation osztályt
auto presentation = System::MakeObject<Presentation>();
// Üres diát ad hozzá
presentation->get_Slides()->AddEmptySlide(presentation->get_LayoutSlides()->idx_get(0));

// Szerzőt ad hozzá
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Jawad", u"MF");

// Beállítja a megjegyzések pozícióját
PointF point;
point.set_X(0.2f);
point.set_Y(0.2f);

// Eléri az ISlide 1-et
auto slide1 = presentation->get_Slides()->idx_get(0);
// Eléri az ISlide 2-et
auto slide2 = presentation->get_Slides()->idx_get(1);

// Megjegyzést ad a szerzőnek a 1. dián
author->get_Comments()->AddComment(u"Hello Jawad, this is slide comment", slide1, point, DateTime::get_Now());

// Megjegyzést ad a szerzőnek a 2. dián
author->get_Comments()->AddComment(u"Hello Jawad, this is second slide comment", slide2, point, DateTime::get_Now());

// Ha null értéket adunk argumentumként, az összes szerző megjegyzései a kiválasztott diára kerülnek
auto comments = slide1->GetSlideComments(author);

// Eléri a 0. indexű megjegyzést az 1. dián
String str = comments[0]->get_Text();

presentation->Save(u"Comments_out.pptx", SaveFormat::Pptx);

if (comments->GetLength(0) > 0)
{
    // Kiválasztja a szerző megjegyzéseinek gyűjteményét a 0. indexen
    auto commentCollection = comments[0]->get_Author()->get_Comments();
    String Comment = commentCollection->idx_get(0)->get_Text();
}
```

## **Dia megjegyzések elérése**
Ez a C++ kód bemutatja, hogyan érhet el egy meglévő megjegyzést egy diához egy PowerPoint prezentációban:

```cpp
// Példányosítja a Presentation osztályt
auto presentation = System::MakeObject<Presentation>(u"Comments1.pptx");

for (auto&& commentAuthor : presentation->get_CommentAuthors())
{
    auto author = System::ExplicitCast<CommentAuthor>(commentAuthor);
    for (auto&& comment1 : System::IterateOver(author->get_Comments()))
    {
        SmartPtr<Comment> comment = System::ExplicitCast<Comment>(comment1);
        Console::WriteLine(String(u"ISlide :")
                        + comment->get_Slide()->get_SlideNumber()
                        + u" has comment: " + comment->get_Text()
                        + u" with Author: " + comment->get_Author()->get_Name()
                        + u" posted on time :" + comment->get_CreatedTime() + u"\n");
    }
}
```

## **Megjegyzések válaszolása**
A szülő megjegyzés a hierarchia legfelső vagy eredeti megjegyzése a megjegyzések vagy válaszok között. A [ParentComment](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) tulajdonság (az [IComment](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_comment) interfészből) használatával beállíthat vagy lekérdezhet egy szülő megjegyzést. 

Ez a C++ kód bemutatja, hogyan adjon megjegyzéseket, és hogyan kapjon válaszokat rájuk:

```cpp
auto pres = System::MakeObject<Presentation>();

// Eléri az ISlide 1-et
auto slide1 = pres->get_Slides()->idx_get(0);

// Hozzáad egy megjegyzést
auto author1 = pres->get_CommentAuthors()->AddAuthor(u"Author_1", u"A.A.");
auto comment1 = author1->get_Comments()->AddComment(u"comment1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

// Választ ad comment1-hez
auto author2 = pres->get_CommentAuthors()->AddAuthor(u"Autror_2", u"B.B.");
auto reply1 = author2->get_Comments()->AddComment(u"reply 1 for comment 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply1->set_ParentComment(comment1);

// Hozzáad egy másik választ a comment1-hez
auto reply2 = author2->get_Comments()->AddComment(u"reply 2 for comment 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply2->set_ParentComment(comment1);

// Választ ad egy meglévő válaszhoz
auto subReply = author1->get_Comments()->AddComment(u"subreply 3 for reply 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
subReply->set_ParentComment(reply2);

auto comment2 = author2->get_Comments()->AddComment(u"comment 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
auto comment3 = author2->get_Comments()->AddComment(u"comment 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

auto reply3 = author1->get_Comments()->AddComment(u"reply 4 for comment 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply3->set_ParentComment(comment3);

// Kiírja a megjegyzések hierarchiáját a konzolra
auto comments = slide1->GetSlideComments(nullptr);
for (int32_t i = 0; i < comments->get_Length(); i++)
{
    auto comment = comments[i];
    while (comment->get_ParentComment() != nullptr)
    {
        Console::Write(u"\t");
        comment = comment->get_ParentComment();
    }

    Console::Write(u"{0} : {1}", comments[i]->get_Author()->get_Name(), comments[i]->get_Text());
    Console::WriteLine();
}

pres->Save(u"parent_comment.pptx", SaveFormat::Pptx);

// Eltávolítja a comment1-et és minden rá adott választ
comment1->Remove();

pres->Save(u"remove_comment.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="Figyelem" %}} 

* Ha a [Remove](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_comment#a8bb818ae804d142195c4edcf9012cccb) metódust (az [IComment](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_comment) interfészből) használják egy megjegyzés törlésére, a megjegyzéshez tartozó válaszok is törlődnek. 
* Ha a [ParentComment](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) beállítása körkörös hivatkozást eredményez, a [PptxEditException](https://reference.aspose.com/slides/hu/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d) kivétel kerül dobásra.

{{% /alert %}}

## **Modern megjegyzés hozzáadása**

2021-ben a Microsoft bevezetett a PowerPointba *modern megjegyzéseket*. A modern megjegyzések funkció jelentősen javítja az együttműködést a PowerPointban. A modern megjegyzések révén a PowerPoint felhasználók könnyebben oldhatják meg a megjegyzéseket, rögzíthetik azokat objektumokhoz és szövegekhez, és sokkal egyszerűbben léphetnek interakcióba.

A [Aspose Slides for C++ 21.11](https://docs.aspose.com/slides/hu/cpp/aspose-slides-for-cpp-21-11-release-notes/) kiadásban támogatást adtunk a modern megjegyzésekhez a [ModernComment](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.modern_comment) osztály hozzáadásával. A [AddModernComment](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.comment_collection#a3627fcb3b05cd639fd430bd8248fe66b) és a [InsertModernComment](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.comment_collection#ad11c3efb52f3c17f63238447dcc03c94) metódusok a [CommentCollection](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.comment_collection) osztályhoz lettek hozzáadva.

Ez a C++ kód bemutatja, hogyan adjon modern megjegyzést egy diához egy PowerPoint prezentációban: 

```cpp
auto pres = System::MakeObject<Presentation>();
// Eléri az ISlide 1-et
auto slide1 = pres->get_Slides()->idx_get(0);

auto newAuthor = pres->get_CommentAuthors()->AddAuthor(u"Some Author", u"SA");
auto modernComment = newAuthor->get_Comments()->AddModernComment(u"This is a modern comment", slide1, nullptr, PointF(100.0f, 100.0f), DateTime::get_Now());

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Megjegyzés eltávolítása**

### **Az összes megjegyzés és szerző törlése**

Ez a C++ kód bemutatja, hogyan távolítsa el az összes megjegyzést és szerzőt egy prezentációból:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"example.pptx");

// Törli az összes megjegyzést a prezentációból
for (auto author : presentation->get_CommentAuthors())
{
    author->get_Comments()->Clear();
}
        
// Törli az összes szerzőt
presentation->get_CommentAuthors()->Clear();
presentation->Save(u"example_out.pptx", SaveFormat::Pptx);
```

### **Specifikus megjegyzések törlése**

Ez a C++ kód bemutatja, hogyan törölhet konkrét megjegyzéseket egy diáron:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
// hozzáad megjegyzéseket...
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Author", u"A");
author->get_Comments()->AddComment(u"comment 1", slide, PointF(0.2f, 0.2f), System::DateTime::get_Now());
author->get_Comments()->AddComment(u"comment 2", slide, PointF(0.3f, 0.2f), System::DateTime::get_Now());
        
// eltávolít minden megjegyzést, amely a "comment 1" szöveget tartalmazza
for (auto commentAuthor : presentation->get_CommentAuthors())
{
    auto toRemove = System::MakeObject<System::Collections::Generic::List<System::SharedPtr<IComment>>>();
    for (auto comment : slide->GetSlideComments(commentAuthor))
    {
        if (comment->get_Text() == u"comment 1")
        {
            toRemove->Add(comment);
        }
    }
    for (auto comment : toRemove)
    {
        commentAuthor->get_Comments()->Remove(comment);
    }
}
        
presentation->Save(u"pres.pptx", SaveFormat::Pptx);

```

## **GYIK**

**Az Aspose.Slides támogatja-e a 'megoldott' státuszt a modern megjegyzéseknél?**

Igen. A [Modern comments](https://reference.aspose.com/slides/hu/cpp/aspose.slides/moderncomment/) rendelkezik [get_Status](https://reference.aspose.com/slides/hu/cpp/aspose.slides/moderncomment/get_status/) és [set_Status](https://reference.aspose.com/slides/hu/cpp/aspose.slides/moderncomment/set_status/) metódusokkal; olvashatja és beállíthatja egy [megjegyzés állapotát](https://reference.aspose.com/slides/hu/cpp/aspose.slides/moderncommentstatus/), (például megjelölheti megoldottként), és ez az állapot a fájlban van tárolva, valamint a PowerPoint is felismeri.

**Támogatottak-e a szálas megbeszélések (válaszláncok), és van-e mélységkorlát?**

Igen. Minden megjegyzés hivatkozhat a [szülő megjegyzésére](https://reference.aspose.com/slides/hu/cpp/aspose.slides/comment/set_parentcomment/), ez lehetővé teszi tetszőleges válaszláncok létrehozását. Az API nem határoz meg konkrét mélységkorlátot.

**Milyen koordináta-rendszerben van definiálva egy megjegyzésmarker pozíciója a dián?**

A pozíció lebegőpontos pontként van tárolva a dia koordináta-rendszerében. Ez lehetővé teszi, hogy a megjegyzésmarkert pontosan oda helyezze, ahová szüksége van.