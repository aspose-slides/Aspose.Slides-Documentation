---
title: Добавить комментарий к слайду
type: docs
weight: 10
url: /net/add-a-comment-to-a-slide/
---

## **OpenXML Презентация:**
``` csharp

 string FilePath = @"..\..\..\..\Примеры Файлов\";

string FileName = FilePath + "Добавить комментарий к слайду.pptx"; 

AddCommentToPresentation(FileName,

"Zeeshan", "MZ",

"Это мой программно добавленный комментарий.");

// Добавляет комментарий к первому слайду презентации.

// Презентация должна содержать как минимум один слайд.

private static void AddCommentToPresentation(string file, string initials, string name, string text)

{

using (PresentationDocument doc = PresentationDocument.Open(file, true))

{

    // Объявить объект CommentAuthorsPart.

    CommentAuthorsPart authorsPart;

    // Проверить, существует ли часть авторов комментариев.

    if (doc.PresentationPart.CommentAuthorsPart == null)

    {

        // Если нет, добавить новую.

        authorsPart = doc.PresentationPart.AddNewPart<CommentAuthorsPart>();

    }

    else

    {

        authorsPart = doc.PresentationPart.CommentAuthorsPart;

    }

    // Проверить, существует ли список авторов комментариев в части авторов комментариев.

    if (authorsPart.CommentAuthorList == null)

    {

        // Если нет, добавить новый.

        authorsPart.CommentAuthorList = new CommentAuthorList();

    }

    // Объявить новый идентификатор автора.

    uint authorId = 0;

    CommentAuthor author = null;

    // Если в списке авторов комментариев есть существующие дочерние элементы...

    if (authorsPart.CommentAuthorList.HasChildren)

    {

        // Проверить, есть ли автор в списке.

        var authors = authorsPart.CommentAuthorList.Elements<CommentAuthor>().Where(a => a.Name == name && a.Initials == initials);

        // Если да...

        if (authors.Any())

        {

            // Присвоить новому автору комментария существующий идентификатор автора.

            author = authors.First();

            authorId = author.Id;

        }

        // Если нет...

        if (author == null)

        {

            // Присвоить переданному автору новый идентификатор

            authorId = authorsPart.CommentAuthorList.Elements<CommentAuthor>().Select(a => a.Id.Value).Max();

        }

    }

    // Если в списке авторов комментариев нет дочерних элементов.

    if (author == null)

    {

        authorId++;

        // Добавить новый дочерний элемент (автор комментария) в список авторов комментариев.

        author = authorsPart.CommentAuthorList.AppendChild<CommentAuthor>

        (new CommentAuthor()

        {

            Id = authorId,

            Name = name,

            Initials = initials,

            ColorIndex = 0

        });

    }

    // Получить первый слайд, используя метод GetFirstSlide.

    SlidePart slidePart1 = GetFirstSlide(doc);

    // Объявить часть комментариев.

    SlideCommentsPart commentsPart;

    // Проверить, существует ли часть комментариев в первом слайде.

    if (slidePart1.GetPartsOfType<SlideCommentsPart>().Count() == 0)

    {

        // Если нет, добавить новую часть комментариев.

        commentsPart = slidePart1.AddNewPart<SlideCommentsPart>();

    }

    else

    {

        // Иначе, использовать первую часть комментариев в слайде.

        commentsPart = slidePart1.GetPartsOfType<SlideCommentsPart>().First();

    }

    // Если список комментариев не существует.

    if (commentsPart.CommentList == null)

    {

        // Добавить новый список комментариев.

        commentsPart.CommentList = new CommentList();

    }

    // Получить новый идентификатор комментария.

    uint commentIdx = author.LastIndex == null ? 1 : author.LastIndex + 1;

    author.LastIndex = commentIdx;

    // Добавить новый комментарий.

    Comment comment = commentsPart.CommentList.AppendChild<Comment>(

    new Comment()

    {

        AuthorId = authorId,

        Index = commentIdx,

        DateTime = DateTime.Now

    });

    // Добавить дочерний узел позиции к элементу комментария.

    comment.Append(

    new Position() { X = 100, Y = 200 },

    new Text() { Text = text });

    // Сохранить часть авторов комментариев.

    authorsPart.CommentAuthorList.Save();

    // Сохранить часть комментариев.

    commentsPart.CommentList.Save();

}

}

// Получить часть слайда первого слайда в документе презентации.

private static SlidePart GetFirstSlide(PresentationDocument presentationDocument)

{

// Получить идентификатор отношения первого слайда

PresentationPart part = presentationDocument.PresentationPart;

SlideId slideId = part.Presentation.SlideIdList.GetFirstChild<SlideId>();

string relId = slideId.RelationshipId;

// Получить часть слайда по идентификатору отношения.

SlidePart slidePart = (SlidePart)part.GetPartById(relId);

return slidePart;

}


``` 
## **Aspose.Slides**
В **Aspose.Slides** для .NET коллекция комментариев к слайдам включена в каждый класс **Slide**. Класс **CommentCollection** используется для хранения комментариев конкретного слайда. Класс **Comment** включает информацию о авторе, который добавил комментарий к слайду, его инициалы, время создания, положение комментария на слайде и текст комментария. Класс **CommentAuthor** используется для добавления авторов для комментариев к слайдам на уровне презентации. Класс **Presentation** хранит коллекцию авторов для презентации в классе **CommentAuthors**.

В следующем примере мы добавили фрагмент кода для добавления комментариев к слайду.

``` csharp

 string FilePath = @"..\..\..\..\Примеры Файлов\";

string FileName = FilePath + "Добавить комментарий к слайду.pptx";

using (Presentation pres = new Presentation())

{

    //Добавление пустого слайда

    pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

    //Добавление автора

    ICommentAuthor author = pres.CommentAuthors.AddAuthor("Zeeshan", "MZ");

    //Положение комментариев

    PointF point = new PointF();

    point.X = 1;

    point.Y = 1;

    //Добавление комментария к слайду для автора на слайде

    author.Comments.AddComment("Привет, Зишан, это комментарий к слайду", pres.Slides[0], point, DateTime.Now);

    pres.Save(FileName, Aspose.Slides.Export.SaveFormat.Pptx);

}

``` 
## **Скачать образец кода**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://master.dl.sourceforge.net/project/asposeopenxml/Aspose.Slides%20Vs%20OpenXML/Add%20a%20comment%20to%20a%20slide%20%28Aspose.Slides%29.zip?viasf=1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Add%20a%20comment%20to%20a%20slide%20\(Aspose.Slides\).zip)