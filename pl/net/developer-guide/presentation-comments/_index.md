---
title: Zarządzanie komentarzami w prezentacji w .NET
linktitle: Komentarze prezentacji
type: docs
weight: 100
url: /pl/net/presentation-comments/
keywords:
- komentarz
- nowoczesny komentarz
- komentarze PowerPoint
- komentarze prezentacji
- komentarze slajdów
- dodaj komentarz
- uzyskaj dostęp do komentarza
- edytuj komentarz
- odpowiedz na komentarz
- usuń komentarz
- usuń komentarz
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Mistrzowskie zarządzanie komentarzami w prezentacjach z Aspose.Slides dla .NET: dodawaj, odczytuj, edytuj i usuwaj komentarze w plikach PowerPoint szybko i łatwo."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak zarządzać komentarzami w prezentacji w Aspose.Slides. Pokazuje główne typy związane z komentarzami i demonstruje, jak dodawać komentarze do slajdów, uzyskiwać dostęp do istniejących komentarzy, pracować z odpowiedziami, używać nowoczesnych komentarzy oraz usuwać komentarze z prezentacji.

Przykłady koncentrują się na typowych scenariuszach przeglądu i współpracy w PowerPoint, takich jak przypisywanie komentarzy do autorów, odczytywanie treści i metadanych komentarzy, budowanie łańcuchów odpowiedzi oraz czyszczenie wszystkich komentarzy lub usuwanie wybranych.

W PowerPoint komentarz pojawia się jako notatka lub adnotacja na slajdzie. Po kliknięciu komentarza jego zawartość lub wiadomości zostają wyświetlone. 

## **Dlaczego dodawać komentarze do prezentacji?**

Możesz chcieć używać komentarzy, aby przekazać uwagi lub komunikować się z kolegami podczas przeglądania prezentacji.

Aby umożliwić korzystanie z komentarzy w prezentacjach PowerPoint, Aspose.Slides for .NET udostępnia

* klasę [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation), która zawiera kolekcje autorów (z właściwości [CommentAuthorCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/icommentauthorcollection/properties/index)). Autorzy dodają komentarze do slajdów. 
* interfejs [ICommentCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/icommentcollection), który zawiera kolekcję komentarzy dla poszczególnych autorów. 
* klasę [IComment](https://reference.aspose.com/slides/pl/net/aspose.slides/icomment), która zawiera informacje o autorach i ich komentarzach: kto dodał komentarz, kiedy został dodany, pozycję komentarza itp. 
* klasę [CommentAuthor](https://reference.aspose.com/slides/pl/net/aspose.slides/commentauthor), która zawiera informacje o pojedynczych autorach: imię i nazwisko autora, jego inicjały, komentarze powiązane z nazwą autora itp. 

## **Dodawanie komentarzy do slajdu**
Ten kod C# pokazuje, jak dodać komentarz do slajdu w prezentacji PowerPoint:

```c#
// Tworzy instancję klasy Presentation
using (Presentation presentation = new Presentation())
{
    // Dodaje pusty slajd
    presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

    // Dodaje autora
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Jawad", "MF");

    // Ustawia pozycję dla komentarzy
    PointF point = new PointF();
    point.X = 0.2f;
    point.Y = 0.2f;

    // Dodaje komentarz slajdu dla autora na slajdzie 1
    author.Comments.AddComment("Hello Jawad, this is slide comment", presentation.Slides[0], point, DateTime.Now);

    // Dodaje komentarz slajdu dla autora na slajdzie 2
    author.Comments.AddComment("Hello Jawad, this is second slide comment", presentation.Slides[1], point, DateTime.Now);

    // Uzyskuje dostęp do ISlide 1
    ISlide slide = presentation.Slides[0];

    // Gdy jako argument przekazany zostanie null, komentarze od wszystkich autorów są pobierane do wybranego slajdu
    IComment[] Comments = slide.GetSlideComments(author);

    // Uzyskuje dostęp do komentarza o indeksie 0 dla slajdu 1
    String str = Comments[0].Text;

    presentation.Save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.GetLength(0) > 0)
    {
        // Wybiera kolekcję komentarzy autora o indeksie 0
        ICommentCollection commentCollection = Comments[0].Author.Comments;
        String Comment = commentCollection[0].Text;
    }
}
```

## **Uzyskiwanie dostępu do komentarzy slajdu**
Ten kod C# pokazuje, jak uzyskać dostęp do istniejącego komentarza na slajdzie w prezentacji PowerPoint:

```c#
// Tworzy instancję klasy Presentation
using (Presentation presentation = new Presentation("Comments1.pptx"))
{
    foreach (var commentAuthor in presentation.CommentAuthors)
    {
        var author = (CommentAuthor) commentAuthor;
        foreach (var comment1 in author.Comments)
        {
            var comment = (Comment) comment1;
            Console.WriteLine("ISlide :" + comment.Slide.SlideNumber + " has comment: " + comment.Text + " with Author: " + comment.Author.Name + " posted on time :" + comment.CreatedTime + "\n");
        }
    }
}
```

## **Komentarze odpowiedzi**
Komentarz nadrzędny to górny lub oryginalny komentarz w hierarchii komentarzy lub odpowiedzi. Korzystając z właściwości [ParentComment](https://reference.aspose.com/slides/pl/net/aspose.slides/icomment/properties/parentcomment) (z interfejsu [IComment](https://reference.aspose.com/slides/pl/net/aspose.slides/icomment)), można ustawić lub pobrać komentarz nadrzędny. 

Ten kod C# pokazuje, jak dodawać komentarze i uzyskiwać ich odpowiedzi:

```c#
using (Presentation pres = new Presentation())
{
    // Dodaje komentarz
    ICommentAuthor author1 = pres.CommentAuthors.AddAuthor("Author_1", "A.A.");
    IComment comment1 = author1.Comments.AddComment("comment1", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    // Dodaje odpowiedź do comment1
    ICommentAuthor author2 = pres.CommentAuthors.AddAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.Comments.AddComment("reply 1 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply1.ParentComment = comment1;

    // Dodaje kolejną odpowiedź do comment1
    IComment reply2 = author2.Comments.AddComment("reply 2 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply2.ParentComment = comment1;

    // Dodaje odpowiedź do istniejącej odpowiedzi
    IComment subReply = author1.Comments.AddComment("subreply 3 for reply 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    subReply.ParentComment = reply2;

    IComment comment2 = author2.Comments.AddComment("comment 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    IComment comment3 = author2.Comments.AddComment("comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    IComment reply3 = author1.Comments.AddComment("reply 4 for comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply3.ParentComment = comment3;

    // Wyświetla hierarchię komentarzy w konsoli
    ISlide slide = pres.Slides[0];
    var comments = slide.GetSlideComments(null);
    for (int i = 0; i < comments.Length; i++)
    {
        IComment comment = comments[i];
        while (comment.ParentComment != null)
        {
            Console.Write("\t");
            comment = comment.ParentComment;
        }

        Console.Write("{0} : {1}", comments[i].Author.Name, comments[i].Text);
        Console.WriteLine();
    }

    pres.Save("parent_comment.pptx",SaveFormat.Pptx);

    // Usuwa comment1 i wszystkie jego odpowiedzi
    comment1.Remove();

    pres.Save("remove_comment.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" title="Attention" %}} 

* Gdy metoda [Remove](https://reference.aspose.com/slides/pl/net/aspose.slides/icomment/methods/remove) (z interfejsu [IComment](https://reference.aspose.com/slides/pl/net/aspose.slides/icomment)) jest używana do usunięcia komentarza, również usuwane są odpowiedzi na ten komentarz. 
* Jeśli ustawienie [ParentComment](https://reference.aspose.com/slides/pl/net/aspose.slides/icomment/properties/parentcomment) powoduje odwołanie cykliczne, zostanie zgłoszony wyjątek [PptxEditException](https://reference.aspose.com/slides/pl/net/aspose.slides/pptxeditexception).

{{% /alert %}}

## **Dodawanie nowoczesnych komentarzy**

W 2021 r. Microsoft wprowadził *nowoczesne komentarze* w PowerPoint. Funkcja nowoczesnych komentarzy znacznie usprawnia współpracę w PowerPoint. Dzięki nowoczesnym komentarzom użytkownicy PowerPoint mogą rozwiązywać komentarze, przypinać je do obiektów i tekstów oraz prowadzić interakcje znacznie łatwiej niż dotychczas. 

W [Aspose Slides for .NET 21.11](https://docs.aspose.com/slides/pl/net/aspose-slides-for-net-21-11-release-notes/) wprowadziliśmy obsługę nowoczesnych komentarzy, dodając klasę [ModernComment](https://reference.aspose.com/slides/pl/net/aspose.slides/moderncomment). Do klasy [CommentCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/commentcollection) dodano metody [AddModernComment](https://reference.aspose.com/slides/pl/net/aspose.slides/commentcollection/methods/addmoderncomment) i [InsertModernComment](https://reference.aspose.com/slides/pl/net/aspose.slides/commentcollection/methods/insertmoderncomment). 

Ten kod C# pokazuje, jak dodać nowoczesny komentarz do slajdu w prezentacji PowerPoint: 

```c#
using (Presentation pres = new Presentation())
{
     ICommentAuthor newAuthor = pres.CommentAuthors.AddAuthor("Some Author", "SA");
     IModernComment modernComment = newAuthor.Comments.AddModernComment("This is a modern comment", pres.Slides[0], null, new PointF(100, 100), DateTime.Now);
 
     pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Usuwanie komentarzy**

### **Usuwanie wszystkich komentarzy i autorów**

Ten kod C# pokazuje, jak usunąć wszystkie komentarze i autorów w prezentacji:

```c#
using (var presentation = new Presentation("example.pptx"))
{
    // Usuwa wszystkie komentarze z prezentacji
    foreach (var author in presentation.CommentAuthors)
    {
        author.Comments.Clear();
    }

    // Usuwa wszystkich autorów
    presentation.CommentAuthors.Clear();

    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```

### **Usuwanie wybranych komentarzy**

Ten kod C# pokazuje, jak usunąć wybrane komentarze na slajdzie:

```c#
using (var presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    
    // dodaj komentarze...
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Author", "A");
    author.Comments.AddComment("comment 1", slide, new PointF(0.2f, 0.2f), DateTime.Now);
    author.Comments.AddComment("comment 2", slide, new PointF(0.3f, 0.2f), DateTime.Now);
    
    // usuń wszystkie komentarze, które zawierają tekst "comment 1"
    foreach (ICommentAuthor commentAuthor in presentation.CommentAuthors)
    {
        List<IComment> toRemove = new List<IComment>();
        foreach (IComment comment in slide.GetSlideComments(commentAuthor))
        {
            if (comment.Text == "comment 1")
            {
                toRemove.Add(comment);
            }
        }
        
        foreach (IComment comment in toRemove)
        {
            commentAuthor.Comments.Remove(comment);
        }
    }
    
    presentation.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Czy Aspose.Slides obsługuje status „rozwiązany” dla nowoczesnych komentarzy?**

Tak. [Nowoczesne komentarze](https://reference.aspose.com/slides/pl/net/aspose.slides/moderncomment/) udostępniają właściwość [Status](https://reference.aspose.com/slides/pl/net/aspose.slides/moderncomment/status/); można odczytać i ustawić [stan komentarza](https://reference.aspose.com/slides/pl/net/aspose.slides/moderncommentstatus/) (na przykład oznaczyć go jako rozwiązany), a stan ten jest zapisywany w pliku i rozpoznawany przez PowerPoint.

**Czy obsługiwane są dyskusje wątkowe (łańcuchy odpowiedzi) i czy istnieje limit zagnieżdżenia?**

Tak. Każdy komentarz może odwoływać się do swojego [komentarza nadrzędnego](https://reference.aspose.com/slides/pl/net/aspose.slides/comment/parentcomment/), umożliwiając dowolnie długie łańcuchy odpowiedzi. API nie określa konkretnego limitu głębokości zagnieżdżenia.

**W jakim układzie współrzędnych definiowana jest pozycja znacznika komentarza na slajdzie?**

Pozycja jest przechowywana jako punkt zmiennoprzecinkowy w układzie współrzędnych slajdu. Dzięki temu można precyzyjnie umieścić znacznik komentarza w dowolnym miejscu.