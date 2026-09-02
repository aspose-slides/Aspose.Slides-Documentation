---
title: Zarządzanie komentarzami prezentacji w C++
linktitle: Komentarze prezentacji
type: docs
weight: 100
url: /pl/cpp/presentation-comments/
keywords:
- komentarz
- nowoczesny komentarz
- komentarze PowerPoint
- komentarze prezentacji
- komentarze slajdów
- dodaj komentarz
- dostęp do komentarza
- edytuj komentarz
- odpowiedz na komentarz
- usuń komentarz
- kasuj komentarz
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Zarządzaj komentarzami w prezentacji za pomocą Aspose.Slides for C++: dodawaj, odczytuj, edytuj, odpowiadaj i usuwaj komentarze w prezentacjach PowerPoint szybko i łatwo."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak zarządzać komentarzami w prezentacji przy użyciu Aspose.Slides for C++. Przedstawia główne typy związane z komentarzami oraz pokazuje, jak dodawać komentarze do slajdów, uzyskiwać dostęp do istniejących komentarzy, pracować z odpowiedziami i nowoczesnymi komentarzami oraz usuwać komentarze z prezentacji.

Przykłady obejmują typowe scenariusze przeglądu i współpracy w PowerPoint, takie jak przypisywanie komentarzy do autorów, odczytywanie tekstu i metadanych komentarza, budowanie łańcuchów odpowiedzi oraz usuwanie wybranych komentarzy lub wszystkich komentarzy.

W programie PowerPoint komentarze są wyświetlane jako adnotacje na slajdach. Wybranie komentarza wyświetla jego tekst i powiązaną dyskusję.

## **Dlaczego dodawać komentarze do prezentacji?**

Możesz używać komentarzy, aby przekazywać informacje zwrotne i współpracować z kolegami podczas przeglądania prezentacji.

Aspose.Slides for C++ udostępnia następujące interfejsy API do pracy z komentarzami:

* Klasa [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) zapewnia dostęp do autorów komentarzy w prezentacji.
* Interfejs [ICommentCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icommentcollection/) reprezentuje komentarze powiązane z pojedynczym autorem.
* Interfejs [IComment](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icomment/) dostarcza informacje o komentarzu, w tym autora, czas utworzenia, pozycję i tekst.
* Klasa [CommentAuthor](https://reference.aspose.com/slides/pl/cpp/aspose.slides/commentauthor/) zapewnia informacje o autorze, w tym jego nazwę, inicjały i powiązane komentarze.

## **Dodawanie komentarzy do slajdów**

Poniższy przykład pokazuje, jak dodać komentarze do slajdów w prezentacji PowerPoint:

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

## **Dostęp do komentarzy na slajdzie**

Poniższy przykład pokazuje, jak uzyskać dostęp do istniejących komentarzy w prezentacji PowerPoint:

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

## **Odpowiadanie na komentarze**

Komentarz nadrzędny to oryginalny komentarz u góry hierarchii odpowiedzi. Metody [get_ParentComment](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icomment/get_parentcomment/) i [set_ParentComment](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icomment/set_parentcomment/) interfejsu [IComment](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icomment/) umożliwiają pobranie lub ustawienie komentarza nadrzędnego.

Poniższy przykład pokazuje, jak dodać odpowiedzi i zbadać powstałą hierarchię komentarzy:

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
* Gdy metoda [Remove](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icomment/remove/) interfejsu [IComment](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icomment/) jest używana do usunięcia komentarza, wszystkie odpowiedzi na ten komentarz są również usuwane.
* Jeśli metoda [set_ParentComment](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icomment/set_parentcomment/) tworzy odwołanie cykliczne, zostaje rzucony wyjątek [PptxEditException](https://reference.aspose.com/slides/pl/cpp/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Dodawanie nowoczesnych komentarzy**

Nowoczesne komentarze mogą być powiązane z samym slajdem, określonym kształtem lub zakresem tekstowym wewnątrz AutoShape. Metoda [ICommentCollection::AddModernComment](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icommentcollection/addmoderncomment/) przyjmuje argument typu [IShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/) oprócz slajdu i współrzędnych znacznika komentarza.

Gdy jako argument kształtu przekazany zostanie `nullptr`, komentarz jest komentarzem na poziomie slajdu. Jego znacznik jest pozycjonowany według podanych współrzędnych, ale nie jest powiązany z konkretnym kształtem, więc [IModernComment::get_Shape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imoderncomment/get_shape/) zwraca `nullptr`. Gdy dostarczony zostanie obiekt [IShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/), komentarz jest zakotwiczony w tym kształcie. Współrzędne nadal określają pozycję znacznika komentarza na slajdzie, a powiązanie kształtu można uzyskać przez [IModernComment::get_Shape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imoderncomment/get_shape/).

### **Zakotwiczanie nowoczesnego komentarza w kształcie**

Poniższy przykład tworzy zarówno nowoczesny komentarz na poziomie slajdu, jak i nowoczesny komentarz zakotwiczony w określonym AutoShape. Następnie odczytuje powiązany kształt z każdego komentarza.

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

### **Zakotwiczanie komentarzy w różnych typach kształtów**

Każdy obiekt slajdu implementujący [IShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/) może być użyty jako kotwica kształtu. Typowe przykłady to [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iconnector/) oraz instancje [IGraphicalObject](https://reference.aspose.com/slides/pl/cpp/aspose.slides/igraphicalobject/) takie jak wykresy.

Poniższy przykład tworzy kilka popularnych typów kształtów i powiązuje z każdym z nich nowoczesny komentarz.

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

### **Zakotwiczanie komentarza w tekście i ustawianie jego statusu**

Dla nowoczesnego komentarza powiązanego z [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/), metody [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imoderncomment/get_textselectionstart/) i [IModernComment::set_TextSelectionStart](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imoderncomment/set_textselectionstart/) kontrolują początkową pozycję zaznaczonego tekstu w ramce tekstowej kształtu. Analogicznie, metody [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imoderncomment/get_textselectionlength/) i [IModernComment::set_TextSelectionLength](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imoderncomment/set_textselectionlength/) kontrolują długość zaznaczenia. Razem te metody wiążą komentarz z określonym zakresem tekstowym wewnątrz AutoShape.

Metody [IModernComment::get_Status](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imoderncomment/get_status/) i [IModernComment::set_Status](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imoderncomment/set_status/) używają wartości z wyliczenia [ModernCommentStatus](https://reference.aspose.com/slides/pl/cpp/aspose.slides/moderncommentstatus/):

- `NotDefined` — nie określono konkretnego statusu nowoczesnego komentarza.
- `Active` — komentarz jest aktywny.
- `Resolved` — komentarz został rozwiązany.
- `Closed` — komentarz jest zamknięty.

Poniższy przykład tworzy nowoczesny komentarz zakotwiczony w kształcie, powiązuje go z zaznaczeniem tekstu, oznacza jako rozwiązany, zapisuje prezentację i weryfikuje wartości po ponownym otwarciu pliku.

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

### **Inspekcja istniejących nowoczesnych komentarzy**

Aby przeanalizować istniejącą prezentację, sprawdź, które komentarze implementują [IModernComment](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imoderncomment/), a następnie zbadaj [IModernComment::get_Shape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imoderncomment/get_shape/), [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imoderncomment/get_textselectionstart/), [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imoderncomment/get_textselectionlength/) i [IModernComment::get_Status](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imoderncomment/get_status/). Kształt `nullptr` wskazuje na komentarz na poziomie slajdu. Dla kotwicy typu [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) metody wyboru tekstu identyfikują powiązany zakres w ramce tekstowej kształtu.

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

## **Usuwanie komentarzy**

### **Usuwanie wszystkich komentarzy i ich autorów**

Poniższy przykład pokazuje, jak usunąć wszystkie komentarze i ich autorów z prezentacji:

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

### **Usuwanie wybranych komentarzy**

Poniższy przykład pokazuje, jak usunąć wybrane komentarze ze slajdu:

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

**Czy Aspose.Slides obsługuje status rozwiązany dla nowoczesnych komentarzy?**

Tak. Metody [IModernComment::get_Status](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imoderncomment/get_status/) i [IModernComment::set_Status](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imoderncomment/set_status/) używają wartości z [ModernCommentStatus](https://reference.aspose.com/slides/pl/cpp/aspose.slides/moderncommentstatus/), w tym `Resolved`. Status jest przechowywany w prezentacji i może być odczytany po ponownym otwarciu pliku.

**Czy obsługiwane są wątki dyskusji (łańcuchy odpowiedzi) i czy istnieje limit zagnieżdżenia?**

Tak. Każdy komentarz może odwoływać się do swojego [parent comment](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icomment/set_parentcomment/), umożliwiając tworzenie łańcuchów odpowiedzi. API nie definiuje konkretnego limitu głębokości zagnieżdżenia.

**W jakim układzie współrzędnych określona jest pozycja znacznika komentarza na slajdzie?**

Pozycja znacznika jest określona przez współrzędne zmiennoprzecinkowe w układzie współrzędnych slajdu, co umożliwia precyzyjne umieszczenie go na slajdzie.