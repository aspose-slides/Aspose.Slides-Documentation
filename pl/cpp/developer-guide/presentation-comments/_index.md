---
title: Z zarządzanie komentarzami prezentacji w C++
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
description: "Zarządzaj komentarzami w prezentacji przy użyciu Aspose.Slides dla C++: dodawaj, odczytuj, edytuj, odpowiadaj i usuwaj komentarze w prezentacjach PowerPoint szybko i łatwo."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak zarządzać komentarzami w prezentacji przy użyciu Aspose.Slides for C++. Wprowadza główne typy związane z komentarzami i demonstruje, jak dodawać komentarze do slajdów, uzyskiwać dostęp do istniejących komentarzy, pracować z odpowiedziami i nowoczesnymi komentarzami oraz usuwać komentarze z prezentacji.

Przykłady obejmują typowe scenariusze przeglądu i współpracy w PowerPoint, takie jak przypisywanie komentarzy do autorów, odczytywanie tekstu i metadanych komentarza, budowanie łańcuchów odpowiedzi oraz usuwanie wybranych komentarzy lub wszystkich komentarzy.

W programie PowerPoint komentarze pojawiają się jako adnotacje na slajdach. Wybranie komentarza wyświetla jego tekst i powiązaną dyskusję.

Aby żądać, aby komentarze były wyświetlane lub ukrywane podczas otwierania prezentacji bez zmieniania samych komentarzy, zobacz [Pokaż lub ukryj komentarze podczas otwierania prezentacji](/slides/pl/cpp/presentation-view-properties/).

## **Dlaczego dodawać komentarze do prezentacji?**

Możesz używać komentarzy, aby przekazać opinie i współpracować z kolegami podczas przeglądania prezentacji.

Aspose.Slides for C++ udostępnia następujące API do pracy z komentarzami:

* Klasa [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) zapewnia dostęp do autorów komentarzy prezentacji.
* Interfejs [ICommentCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/) reprezentuje komentarze powiązane z poszczególnym autorem.
* Interfejs [IComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/) dostarcza informacji o komentarzu, w tym o jego autorze, czasie utworzenia, pozycji i treści.
* Klasa [CommentAuthor](https://reference.aspose.com/slides/cpp/aspose.slides/commentauthor/) dostarcza informacji o autorze, w tym jego imię, inicjały i powiązane komentarze.

## **Dodawanie komentarzy do slajdów**

Przykład tworzy dwa slajdy i rejestruje autora komentarza przy użyciu [AddAuthor](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/addauthor/). Używa [AddComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addcomment/) do umieszczenia jednego komentarza na każdym slajdzie, a następnie pobiera komentarze pierwszego slajdu dla tego autora przy użyciu [GetSlideComments](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getslidecomments/). Konsola wyświetla tekst pierwszego komentarza dwa razy, demonstrując dostęp zarówno przez slajd, jak i autora, a zapisany plik prezentacji zawiera oba komentarze.

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

## **Znajdź lub utwórz autora komentarza**

Gdy automatyczny przegląd przetwarza tę samą prezentację wielokrotnie, przeszukaj kolekcję zwróconą przez [get_CommentAuthors](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_commentauthors/) przed dodaniem autora. [FindByNameAndInitials](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/findbynameandinitials/) dopasowuje zarówno nazwę, jak i inicjały oraz zwraca tablicę pasujących autorów, lub pustą tablicę, jeśli nie ma dopasowań. Natomiast [FindByName](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/findbyname/) przeszukuje tylko po nazwie, niezależnie od inicjałów. Wywołanie [AddAuthor](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/addauthor/) z nazwą i inicjałami już istniejącymi w kolekcji generuje wyjątek.

Przykład wymaga pliku prezentacji z co najmniej jednym slajdem. W każdym z dwóch przebiegów ponownie używa pierwszego pasującego autora lub tworzy nowego tylko wtedy, gdy wynik jest pusty. Jeśli istnieje wiele dopasowań, wybiera pierwszy element tablicy bez łączenia lub usuwania pozostałych autorów. Następnie wywołuje [AddComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addcomment/) dla wybranego autora i zapisuje prezentację. Drugi przebieg otwiera wynik pierwszego przebiegu i powtarza operację.

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

Drugi przebieg dodaje kolejny komentarz bez dodawania kolejnego autora lub usuwania istniejących komentarzy. Końcowy plik, `review_pass_2.pptx`, zawiera oba nowe komentarze obok wszelkich oryginalnych komentarzy. Ponowne użycie autora nie deduplikuje komentarzy: aby uniknąć wielokrotnego dodawania tego samego komentarza, należy przed dodaniem wdrożyć oddzielną detekcję duplikatów.

## **Dostęp do komentarzy slajdu**

Przykład otwiera istniejącą prezentację i odczytuje kolekcję zwróconą przez [get_CommentAuthors](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_commentauthors/). Dla każdego autora iteruje po kolekcji zwróconej przez [get_Comments](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthor/get_comments/) i wypisuje numer slajdu, tekst komentarza, nazwę autora oraz czas utworzenia. Wejściowa prezentacja musi zawierać komentarze, aby uzyskać wyjście w konsoli.

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

Komentarz nadrzędny jest oryginalnym komentarzem na szczycie hierarchii odpowiedzi. Metody [get_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/get_parentcomment/) i [set_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) interfejsu [IComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/) pozwalają pobrać lub ustawić komentarz nadrzędny.

Przykład tworzy komentarze od dwóch autorów i używa [set_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) do budowania odpowiedzi, w tym odpowiedzi na inną odpowiedź. Przekazanie `nullptr` do [GetSlideComments](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getslidecomments/) pobiera komentarze od wszystkich autorów; konsola wcięciem oznacza każdy wpis zgodnie z jego głębokością w hierarchii odpowiedzi. Przykład zapisuje pełną dyskusję, wywołuje [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/remove/) na pierwszym komentarzu głównym i zapisuje drugą prezentację z usuniętym tym komentarzem i jego odpowiedziami.

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
* Gdy metoda [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/remove/) interfejsu [IComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/) jest używana do usunięcia komentarza, wszystkie odpowiedzi na ten komentarz są również usuwane.
* Jeśli metoda [set_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) tworzy odniesienie cykliczne, zostaje zgłoszony [PptxEditException](https://reference.aspose.com/slides/cpp/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Dodawanie nowoczesnych komentarzy**

Nowoczesne komentarze mogą być powiązane bezpośrednio z samym slajdem, z określonym kształtem lub z zakresem tekstowym wewnątrz AutoShape. Metoda [ICommentCollection::AddModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addmoderncomment/) przyjmuje argument [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) oprócz slajdu i współrzędnych znacznika komentarza.

Gdy dla argumentu shape przekazany jest `nullptr`, komentarz jest komentarzem na poziomie slajdu. Jego znacznik jest pozycjonowany za pomocą podanych współrzędnych, ale nie jest powiązany z konkretnym kształtem, więc [IModernComment::get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/) zwraca `nullptr`. Gdy podany zostanie [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/), komentarz jest przypięty do tego kształtu. Współrzędne nadal określają pozycję znacznika komentarza na slajdzie, a powiązanie z kształtem można odczytać przez [IModernComment::get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/).

### **Przytwierdzenie nowoczesnego komentarza do kształtu**

Przykład wywołuje [AddModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addmoderncomment/) dwa razy: raz z kształtem `nullptr` dla komentarza na poziomie slajdu i raz z prostokątem jako kotwicą. Wywołanie [get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/) wypisuje `True` dla sprawdzenia null w komentarzu slajdu i `Revenue title` dla komentarza przytwierdzonego. Oba komentarze są zapisywane w prezentacji.

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

### **Przytwierdzenie komentarzy do różnych typów kształtów**

Każdy obiekt slajdu implementujący [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) może być użyty jako kotwica kształtu. Typowe przykłady obejmują [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/cpp/aspose.slides/iconnector/) oraz [IGraphicalObject](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobject/) takie jak wykresy.

Przykład używa [AddModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addmoderncomment/) do powiązania komentarza z każdą z pięciu typów kształtów: AutoShape, ramką obrazu, grupą, łącznikiem i wykresem. Obraz jest osadzony jako dane, więc nie jest wymagany zewnętrzny plik obrazu. Każdy komentarz ma własną pozycję znacznika, a zapisana prezentacja zachowuje wszystkie pięć powiązań kształtów.

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

### **Przytwierdzenie komentarza do tekstu i ustawienie jego statusu**

Dla nowoczesnego komentarza powiązanego z [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/), metody [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionstart/) i [IModernComment::set_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionstart/) kontrolują początkową pozycję zaznaczonego tekstu w ramce tekstowej kształtu. Analogicznie, metody [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionlength/) i [IModernComment::set_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionlength/) kontrolują długość zaznaczenia. Razem te metody wiążą komentarz z określonym zakresem tekstu wewnątrz AutoShape.

Metody [IModernComment::get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_status/) i [IModernComment::set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_status/) przyjmują wartość z wyliczenia [ModernCommentStatus](https://reference.aspose.com/slides/cpp/aspose.slides/moderncommentstatus/):

- `NotDefined` — nie zdefiniowano konkretnego statusu nowoczesnego komentarza.
- `Active` — komentarz jest aktywny.
- `Resolved` — komentarz został rozwiązany.
- `Closed` — komentarz jest zamknięty.

Przykład przytwierdza nowoczesny komentarz do słów „quarterly revenue” w tekście prostokąta. Oblicza zerowy indeks początku wyboru z tekstu, przekazuje go do [set_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionstart/), a następnie wywołuje [set_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionlength/) z liczbą wybranych znaków. Po wywołaniu [set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_status/) z wartością `Resolved` zapisuje i ponownie otwiera prezentację. Cztery sprawdzenia w konsoli powinny kolejno wypisać `True`, potwierdzając zachowanie kotwicy kształtu, zakresu tekstu i statusu.

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

Przykład wymaga istniejącej prezentacji zawierającej nowoczesne komentarze i wypisuje ich tekst, status oraz szczegóły kotwicy. Aby je przeanalizować, sprawdź, które komentarze implementują [IModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/), a następnie zbadaj [IModernComment::get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/), [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionstart/), [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionlength/) oraz [IModernComment::get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_status/). Kształt `nullptr` wskazuje na komentarz na poziomie slajdu. Dla kotwicy typu [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) metody wyboru tekstu identyfikują odpowiedni zakres w ramce tekstowej kształtu.

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

Aspose.Slides for C++ umożliwia usunięcie wszystkich komentarzy i ich autorów z prezentacji lub usunięcie wybranych komentarzy przy zachowaniu pozostałych. Poniższe przykłady demonstrują oba podejścia i zapisują zaktualizowaną prezentację.

### **Usunięcie wszystkich komentarzy i autorów komentarzy**

Przykład otwiera istniejącą prezentację i wywołuje [ICommentCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/clear/) dla każdego autora, a następnie wywołuje [ICommentAuthorCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/clear/) w celu usunięcia samych autorów. Zapisana prezentacja nie zawiera ani komentarzy, ani ich autorów. Użyj prezentacji zawierającej komentarze, aby zobaczyć efekt usunięcia.

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

### **Usunięcie wybranych komentarzy**

Przykład tworzy dwa komentarze na jednym slajdzie i używa [GetSlideComments](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getslidecomments/) do znalezienia komentarzy każdego autora. Zbiera komentarze, których tekst równa się „comment 1”, przed wywołaniem [ICommentCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/remove/), aby uniknąć modyfikacji kolekcji w trakcie wyboru. Zapisana prezentacja zachowuje tylko „comment 2”.

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

**Czy Aspose.Slides obsługuje status „resolved” dla nowoczesnych komentarzy?**

Tak. Metody [IModernComment::get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_status/) i [IModernComment::set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_status/) używają wartości z wyliczenia [ModernCommentStatus](https://reference.aspose.com/slides/cpp/aspose.slides/moderncommentstatus/), w tym `Resolved`. Status jest przechowywany w prezentacji i może być odczytany ponownie po ponownym otwarciu pliku.

**Czy obsługiwane są wątki dyskusji (łańcuchy odpowiedzi) i czy istnieje limit zagnieżdżenia?**

Tak. Każdy komentarz może odwoływać się do swojego [parent comment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/), umożliwiając tworzenie łańcuchów odpowiedzi. API nie definiuje konkretnego limitu głębokości zagnieżdżenia.

**W jakim systemie współrzędnych definiowana jest pozycja znacznika komentarza na slajdzie?**

Pozycja znacznika jest określona przez współrzędne zmiennoprzecinkowe w systemie współrzędnych slajdu, co pozwala precyzyjnie umieścić go na slajdzie.