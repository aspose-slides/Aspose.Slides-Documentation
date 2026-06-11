---
title: Zarządzanie komentarzami w prezentacji w C++
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
- odpowiedź na komentarz
- usuń komentarz
- kasowanie komentarza
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Zarządzaj komentarzami w prezentacji za pomocą Aspose.Slides for C++: dodawaj, czytaj, edytuj i usuwaj komentarze w plikach PowerPoint szybko i łatwo."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak zarządzać komentarzami w prezentacji w Aspose.Slides. Pokazuje główne typy związane z komentarzami oraz demonstruje, jak dodawać komentarze do slajdów, uzyskiwać dostęp do istniejących komentarzy, pracować z odpowiedziami, używać nowoczesnych komentarzy oraz usuwać komentarze z prezentacji.

Przykłady koncentrują się na typowych scenariuszach przeglądu i współpracy w PowerPoint, takich jak przydzielanie komentarzy autorom, odczytywanie treści i metadanych komentarzy, budowanie łańcuchów odpowiedzi oraz czyszczenie wszystkich komentarzy lub usuwanie wybranych.

W PowerPoint komentarz pojawia się jako notatka lub adnotacja na slajdzie. Po kliknięciu komentarza wyświetlana jest jego zawartość lub wiadomości.

### **Dlaczego dodawać komentarze do prezentacji?**

Możesz chcieć używać komentarzy, aby przekazywać opinie lub komunikować się z kolegami podczas przeglądania prezentacji.

Aby umożliwić użycie komentarzy w prezentacjach PowerPoint, Aspose.Slides for C++ zapewnia
* Klasa [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation), która zawiera kolekcje autorów (z metody [get_CommentAuthors()](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation#ac100feeb13ea426b85557a829676227d)). Autorzy dodają komentarze do slajdów. 
* Interfejs [ICommentCollection](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_comment_collection), który zawiera kolekcję komentarzy dla poszczególnych autorów. 
* Klasa [IComment](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_comment), która zawiera informacje o autorach i ich komentarzach: kto dodał komentarz, czas jego dodania, pozycję komentarza itp. 
* Klasa [CommentAuthor](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.comment_author), która zawiera informacje o poszczególnych autorach: nazwę autora, jego inicjały, komentarze powiązane z nazwą autora itp. 

## **Dodaj komentarz do slajdu**
Ten kod C++ pokazuje, jak dodać komentarz do slajdu w prezentacji PowerPoint:

```cpp
// Tworzy instancję klasy Presentation
auto presentation = System::MakeObject<Presentation>();
// Dodaje pusty slajd
presentation->get_Slides()->AddEmptySlide(presentation->get_LayoutSlides()->idx_get(0));

// Dodaje autora
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Jawad", u"MF");

// Ustawia pozycję komentarzy
PointF point;
point.set_X(0.2f);
point.set_Y(0.2f);

// Dostęp do ISlide 1
auto slide1 = presentation->get_Slides()->idx_get(0);
// Dostęp do ISlide 2
auto slide2 = presentation->get_Slides()->idx_get(1);

// Dodaje komentarz slajdu dla autora na slajdzie 1
author->get_Comments()->AddComment(u"Hello Jawad, this is slide comment", slide1, point, DateTime::get_Now());

// Dodaje komentarz slajdu dla autora na slajdzie 2
author->get_Comments()->AddComment(u"Hello Jawad, this is second slide comment", slide2, point, DateTime::get_Now());

// Gdy jako argument przekazany zostanie null, komentarze od wszystkich autorów są przywoływane na wybrany slajd
auto comments = slide1->GetSlideComments(author);

// Dostęp do komentarza o indeksie 0 dla slajdu 1
String str = comments[0]->get_Text();

presentation->Save(u"Comments_out.pptx", SaveFormat::Pptx);

if (comments->GetLength(0) > 0)
{
    // Wybiera kolekcję komentarzy autora o indeksie 0
    auto commentCollection = comments[0]->get_Author()->get_Comments();
    String Comment = commentCollection->idx_get(0)->get_Text();
}
```

## **Uzyskaj dostęp do komentarzy slajdu**
Ten kod C++ pokazuje, jak uzyskać dostęp do istniejącego komentarza na slajdzie w prezentacji PowerPoint:

```cpp
// Tworzy instancję klasy Presentation
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

## **Odpowiadanie na komentarze**

Komentarz nadrzędny to górny lub oryginalny komentarz w hierarchii komentarzy lub odpowiedzi. Używając właściwości [ParentComment](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) (z interfejsu [IComment](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_comment)), możesz ustawić lub pobrać komentarz nadrzędny. 

Ten kod C++ pokazuje, jak dodawać komentarze i pobierać odpowiedzi na nie:

```cpp
auto pres = System::MakeObject<Presentation>();

// Uzyskuje dostęp do ISlide 1
auto slide1 = pres->get_Slides()->idx_get(0);

// Dodaje komentarz
auto author1 = pres->get_CommentAuthors()->AddAuthor(u"Author_1", u"A.A.");
auto comment1 = author1->get_Comments()->AddComment(u"comment1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

// Dodaje odpowiedź do comment1
auto author2 = pres->get_CommentAuthors()->AddAuthor(u"Autror_2", u"B.B.");
auto reply1 = author2->get_Comments()->AddComment(u"reply 1 for comment 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply1->set_ParentComment(comment1);

// Dodaje kolejną odpowiedź do comment1
auto reply2 = author2->get_Comments()->AddComment(u"reply 2 for comment 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply2->set_ParentComment(comment1);

// Dodaje odpowiedź do istniejącej odpowiedzi
auto subReply = author1->get_Comments()->AddComment(u"subreply 3 for reply 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
subReply->set_ParentComment(reply2);

auto comment2 = author2->get_Comments()->AddComment(u"comment 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
auto comment3 = author2->get_Comments()->AddComment(u"comment 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

auto reply3 = author1->get_Comments()->AddComment(u"reply 4 for comment 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply3->set_ParentComment(comment3);

// Wyświetla hierarchię komentarzy w konsoli
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

// Usuwa comment1 i wszystkie odpowiedzi na niego
comment1->Remove();

pres->Save(u"remove_comment.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="Attention" %}} 
* Gdy metoda [Remove](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_comment#a8bb818ae804d142195c4edcf9012cccb) (z interfejsu [IComment](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_comment)) jest używana do usunięcia komentarza, odpowiedzi na ten komentarz również zostają usunięte. 
* Jeśli ustawienie [ParentComment](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) spowoduje cykliczne odwołanie, zostanie rzucony wyjątek [PptxEditException](https://reference.aspose.com/slides/pl/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d).
{{% /alert %}}

## **Dodaj nowoczesny komentarz**

W 2021 roku Microsoft wprowadził *nowoczesne komentarze* w PowerPoint. Funkcja nowoczesnych komentarzy znacznie usprawnia współpracę w PowerPoint. Dzięki nowoczesnym komentarzom użytkownicy PowerPoint mogą rozwiązywać komentarze, przypinać je do obiektów i tekstów oraz prowadzić interakcje znacznie łatwiej niż wcześniej. 

W [Aspose Slides for C++ 21.11](https://docs.aspose.com/slides/pl/cpp/aspose-slides-for-cpp-21-11-release-notes/), wdrożyliśmy obsługę nowoczesnych komentarzy, dodając klasę [ModernComment](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.modern_comment). Do klasy [CommentCollection](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.comment_collection) dodano metody [AddModernComment](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.comment_collection#a3627fcb3b05cd639fd430bd8248fe66b) oraz [InsertModernComment](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.comment_collection#ad11c3efb52f3c17f63238447dcc03c94).

Ten kod C++ pokazuje, jak dodać nowoczesny komentarz do slajdu w prezentacji PowerPoint: 

```cpp
auto pres = System::MakeObject<Presentation>();
// Uzyskuje dostęp do ISlide 1
auto slide1 = pres->get_Slides()->idx_get(0);

auto newAuthor = pres->get_CommentAuthors()->AddAuthor(u"Some Author", u"SA");
auto modernComment = newAuthor->get_Comments()->AddModernComment(u"This is a modern comment", slide1, nullptr, PointF(100.0f, 100.0f), DateTime::get_Now());

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Usuń komentarz**

### **Usuń wszystkie komentarze i autorów**

Ten kod C++ pokazuje, jak usunąć wszystkie komentarze i autorów w prezentacji:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"example.pptx");

// Usuwa wszystkie komentarze z prezentacji
for (auto author : presentation->get_CommentAuthors())
{
    author->get_Comments()->Clear();
}
        
// Usuwa wszystkich autorów
presentation->get_CommentAuthors()->Clear();
presentation->Save(u"example_out.pptx", SaveFormat::Pptx);
```

### **Usuń wybrane komentarze**

Ten kod C++ pokazuje, jak usunąć określone komentarze na slajdzie:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
// dodaj komentarze...
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Author", u"A");
author->get_Comments()->AddComment(u"comment 1", slide, PointF(0.2f, 0.2f), System::DateTime::get_Now());
author->get_Comments()->AddComment(u"comment 2", slide, PointF(0.3f, 0.2f), System::DateTime::get_Now());
        
// usuń wszystkie komentarze zawierające tekst "comment 1"
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

## **FAQ**

**Czy Aspose.Slides obsługuje status taki jak „rozwiązany” dla nowoczesnych komentarzy?**

Tak. [Nowoczesne komentarze](https://reference.aspose.com/slides/pl/cpp/aspose.slides/moderncomment/) udostępniają metody [get_Status](https://reference.aspose.com/slides/pl/cpp/aspose.slides/moderncomment/get_status/) i [set_Status](https://reference.aspose.com/slides/pl/cpp/aspose.slides/moderncomment/set_status/). Możesz odczytać i ustawić [stan komentarza](https://reference.aspose.com/slides/pl/cpp/aspose.slides/moderncommentstatus/) (na przykład oznaczyć go jako rozwiązany), a stan ten jest zapisywany w pliku i rozpoznawany przez PowerPoint.

**Czy obsługiwane są dyskusje wątkowe (łańcuchy odpowiedzi) i czy istnieje limit zagnieżdżenia?**

Tak. Każdy komentarz może odwoływać się do swojego [komentarza nadrzędnego](https://reference.aspose.com/slides/pl/cpp/aspose.slides/comment/set_parentcomment/), co umożliwia dowolne łańcuchy odpowiedzi. API nie określa konkretnego limitu głębokości zagnieżdzenia.

**W jakim układzie współrzędnych określona jest pozycja znacznika komentarza na slajdzie?**

Pozycja jest zapisywana jako punkt zmiennoprzecinkowy w układzie współrzędnych slajdu. Dzięki temu możesz umieścić znacznik komentarza dokładnie w wybranym miejscu.