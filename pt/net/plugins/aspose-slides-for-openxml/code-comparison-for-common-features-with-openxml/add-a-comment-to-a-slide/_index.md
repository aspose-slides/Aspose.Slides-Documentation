---
title: Adicionar um comentário a um slide
type: docs
weight: 10
url: /pt/net/add-a-comment-to-a-slide/
---
## **Apresentação OpenXML**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Add a comment to a slide.pptx"; 

AddCommentToPresentation(FileName,

"Zeeshan", "MZ",

"This is my programmatically added comment.");

// Adiciona um comentário ao primeiro slide do documento de apresentação.
// O documento de apresentação deve conter ao menos um slide.

private static void AddCommentToPresentation(string file, string initials, string name, string text)

{

using (PresentationDocument doc = PresentationDocument.Open(file, true))

{

    // Declara um objeto CommentAuthorsPart.

    CommentAuthorsPart authorsPart;

    // Verifica se existe uma parte de autores de comentários existente.

    if (doc.PresentationPart.CommentAuthorsPart == null)

    {

        // Se não, adiciona uma nova.

        authorsPart = doc.PresentationPart.AddNewPart<CommentAuthorsPart>();

    }

    else

    {

        authorsPart = doc.PresentationPart.CommentAuthorsPart;

    }

    // Verifica se há uma lista de autores de comentários na parte de autores de comentários.

    if (authorsPart.CommentAuthorList == null)

    {

        // Se não, adiciona uma nova.

        authorsPart.CommentAuthorList = new CommentAuthorList();

    }

    // Declara um novo ID de autor.

    uint authorId = 0;

    CommentAuthor author = null;

    // Se houver elementos filho existentes na lista de autores de comentários...

    if (authorsPart.CommentAuthorList.HasChildren)

    {

        // Verifica se o autor fornecido está na lista.

        var authors = authorsPart.CommentAuthorList.Elements<CommentAuthor>().Where(a => a.Name == name && a.Initials == initials);

        // Se sim...

        if (authors.Any())

        {

            // Atribui ao novo autor de comentário o ID de autor existente.

            author = authors.First();

            authorId = author.Id;

        }

        // Se não...

        if (author == null)

        {

            // Atribui ao autor fornecido um novo ID

            authorId = authorsPart.CommentAuthorList.Elements<CommentAuthor>().Select(a => a.Id.Value).Max();

        }

    }

    // Se não houver elementos filho existentes na lista de autores de comentários.

    if (author == null)

    {

        authorId++;

        // Adiciona um novo elemento filho (autor de comentário) à lista de autores de comentários.

        author = authorsPart.CommentAuthorList.AppendChild<CommentAuthor>

        (new CommentAuthor()

        {

            Id = authorId,

            Name = name,

            Initials = initials,

            ColorIndex = 0

        });

    }

    // Obtém o primeiro slide, usando o método GetFirstSlide.

    SlidePart slidePart1 = GetFirstSlide(doc);

    // Declara uma parte de comentários.

    SlideCommentsPart commentsPart;

    // Verifica se há uma parte de comentários na primeira parte de slide.

    if (slidePart1.GetPartsOfType<SlideCommentsPart>().Count() == 0)

    {

        // Se não, adiciona uma nova parte de comentários.

        commentsPart = slidePart1.AddNewPart<SlideCommentsPart>();

    }

    else

    {

        // Caso contrário, usa a primeira parte de comentários na parte de slide.

        commentsPart = slidePart1.GetPartsOfType<SlideCommentsPart>().First();

    }

    // Se a lista de comentários não existir.

    if (commentsPart.CommentList == null)

    {

        // Adiciona uma nova lista de comentários.

        commentsPart.CommentList = new CommentList();

    }

    // Obtém o novo ID de comentário.

    uint commentIdx = author.LastIndex == null ? 1 : author.LastIndex + 1;

    author.LastIndex = commentIdx;

    // Adiciona um novo comentário.

    Comment comment = commentsPart.CommentList.AppendChild<Comment>(

    new Comment()

    {

        AuthorId = authorId,

        Index = commentIdx,

        DateTime = DateTime.Now

    });

    // Adiciona o nó filho de posição ao elemento de comentário.

    comment.Append(

    new Position() { X = 100, Y = 200 },

    new Text() { Text = text });

    // Salva a parte de autores de comentários.

    authorsPart.CommentAuthorList.Save();

    // Salva a parte de comentários.

    commentsPart.CommentList.Save();

}

}

// Obtém a parte de slide do primeiro slide no documento de apresentação.

private static SlidePart GetFirstSlide(PresentationDocument presentationDocument)

{

// Obtém o ID de relacionamento do primeiro slide

PresentationPart part = presentationDocument.PresentationPart;

SlideId slideId = part.Presentation.SlideIdList.GetFirstChild<SlideId>();

string relId = slideId.RelationshipId;

// Obtém a parte de slide pelo ID de relacionamento.

SlidePart slidePart = (SlidePart)part.GetPartById(relId);

return slidePart;

}


``` 
## **Aspose.Slides**
No **Aspose.Slides** para .NET, a coleção de comentários de slides PPT está incluída em cada classe **Slide**. A classe **CommentCollection** é usada para armazenar os comentários específicos de slides. A classe **Comment** inclui informações como o autor que adicionou o comentário ao slide, suas iniciais, hora de criação, a posição do comentário no slide e o texto do comentário. A classe **CommentAuthor** é usada para adicionar os autores dos comentários de slides ao nível da apresentação. A classe **Presentation** contém a coleção de autores da apresentação na classe **CommentAuthors**.

No exemplo a seguir, adicionamos o trecho de código para inserir os comentários nos slides.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Add a comment to a slide.pptx";

using (Presentation pres = new Presentation())

{

    //Adicionando slide vazio

    pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

    //Adicionando autor

    ICommentAuthor author = pres.CommentAuthors.AddAuthor("Zeeshan", "MZ");

    //Posição dos comentários

    PointF point = new PointF();

    point.X = 1;

    point.Y = 1;

    //Adicionando comentário de slide para um autor no slide

    author.Comments.AddComment("Hello Zeeshan, this is slide comment", pres.Slides[0], point, DateTime.Now);

    pres.Save(FileName, Aspose.Slides.Export.SaveFormat.Pptx);

}

``` 
## **Baixar Código de Exemplo**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Add%20a%20comment%20to%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Add%20a%20comment%20to%20a%20slide/)