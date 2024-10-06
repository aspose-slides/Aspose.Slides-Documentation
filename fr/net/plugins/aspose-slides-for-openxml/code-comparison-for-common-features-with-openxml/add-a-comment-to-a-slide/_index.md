---
title: Ajouter un commentaire à une diapositive
type: docs
weight: 10
url: /net/add-a-comment-to-a-slide/
---

## **OpenXML Présentation :**
``` csharp

 string FilePath = @"..\..\..\..\Exemples\";

string FileName = FilePath + "Ajouter un commentaire à une diapositive.pptx"; 

AddCommentToPresentation(FileName,

"Zeeshan", "MZ",

"Ceci est mon commentaire ajouté par programmation.");

// Ajoute un commentaire à la première diapositive du document de présentation.

// Le document de présentation doit contenir au moins une diapositive.

private static void AddCommentToPresentation(string file, string initials, string name, string text)

{

using (PresentationDocument doc = PresentationDocument.Open(file, true))

{

    // Déclarez un objet CommentAuthorsPart.

    CommentAuthorsPart authorsPart;

    // Vérifiez qu'il existe une partie auteur de commentaire existante.

    if (doc.PresentationPart.CommentAuthorsPart == null)

    {

        // Sinon, ajoutez-en une nouvelle.

        authorsPart = doc.PresentationPart.AddNewPart<CommentAuthorsPart>();

    }

    else

    {

        authorsPart = doc.PresentationPart.CommentAuthorsPart;

    }

    // Vérifiez qu'il existe une liste d'auteurs de commentaire dans la partie auteurs de commentaire.

    if (authorsPart.CommentAuthorList == null)

    {

        // Sinon, ajoutez-en une nouvelle.

        authorsPart.CommentAuthorList = new CommentAuthorList();

    }

    // Déclarez un nouvel identifiant d'auteur.

    uint authorId = 0;

    CommentAuthor author = null;

    // S'il existe des éléments enfants existants dans la liste d'auteurs de commentaire...

    if (authorsPart.CommentAuthorList.HasChildren)

    {

        // Vérifiez que l'auteur passé en paramètre est dans la liste.

        var authors = authorsPart.CommentAuthorList.Elements<CommentAuthor>().Where(a => a.Name == name && a.Initials == initials);

        // Si c'est le cas...

        if (authors.Any())

        {

            // Attribuez à l'auteur du nouveau commentaire l'identifiant d'auteur existant.

            author = authors.First();

            authorId = author.Id;

        }

        // Sinon...

        if (author == null)

        {

            // Attribuez à l'auteur passé un nouvel identifiant

            authorId = authorsPart.CommentAuthorList.Elements<CommentAuthor>().Select(a => a.Id.Value).Max();

        }

    }

    // S'il n'y a pas d'éléments enfants existants dans la liste d'auteurs de commentaire.

    if (author == null)

    {

        authorId++;

        // Ajoutez un nouvel élément enfant (auteur de commentaire) à la liste des auteurs de commentaire.

        author = authorsPart.CommentAuthorList.AppendChild<CommentAuthor>

        (new CommentAuthor()

        {

            Id = authorId,

            Name = name,

            Initials = initials,

            ColorIndex = 0

        });

    }

    // Obtenez la première diapositive, en utilisant la méthode GetFirstSlide.

    SlidePart slidePart1 = GetFirstSlide(doc);

    // Déclarez une partie de commentaires.

    SlideCommentsPart commentsPart;

    // Vérifiez qu'il existe une partie de commentaires dans la première partie de diapositive.

    if (slidePart1.GetPartsOfType<SlideCommentsPart>().Count() == 0)

    {

        // Sinon, ajoutez une nouvelle partie de commentaires.

        commentsPart = slidePart1.AddNewPart<SlideCommentsPart>();

    }

    else

    {

        // Sinon, utilisez la première partie de commentaires dans la partie diapositive.

        commentsPart = slidePart1.GetPartsOfType<SlideCommentsPart>().First();

    }

    // Si la liste de commentaires n'existe pas.

    if (commentsPart.CommentList == null)

    {

        // Ajoutez une nouvelle liste de commentaires.

        commentsPart.CommentList = new CommentList();

    }

    // Obtenez le nouvel identifiant de commentaire.

    uint commentIdx = author.LastIndex == null ? 1 : author.LastIndex + 1;

    author.LastIndex = commentIdx;

    // Ajoutez un nouveau commentaire.

    Comment comment = commentsPart.CommentList.AppendChild<Comment>(

    new Comment()

    {

        AuthorId = authorId,

        Index = commentIdx,

        DateTime = DateTime.Now

    });

    // Ajoutez le nœud enfant de position à l'élément commentaire.

    comment.Append(

    new Position() { X = 100, Y = 200 },

    new Text() { Text = text });

    // Enregistrez la partie des auteurs de commentaires.

    authorsPart.CommentAuthorList.Save();

    // Enregistrez la partie des commentaires.

    commentsPart.CommentList.Save();

}

}

// Obtenez la partie diapositive de la première diapositive dans le document de présentation.

private static SlidePart GetFirstSlide(PresentationDocument presentationDocument)

{

// Obtenez l'identifiant de relation de la première diapositive

PresentationPart part = presentationDocument.PresentationPart;

SlideId slideId = part.Presentation.SlideIdList.GetFirstChild<SlideId>();

string relId = slideId.RelationshipId;

// Obtenez la partie diapositive par l'identifiant de relation.

SlidePart slidePart = (SlidePart)part.GetPartById(relId);

return slidePart;

}


``` 
## **Aspose.Slides**
Dans **Aspose.Slides** pour .NET, la collection de commentaires de diapositive PPT est incluse dans chaque classe **Slide**. La classe **CommentCollection** est utilisée pour contenir les commentaires particuliers de la diapositive. La classe **Comment** contient des informations telles que l'auteur qui a ajouté le commentaire à la diapositive, ses initiales, l'heure de création, la position du commentaire sur la diapositive et le texte du commentaire. La classe **CommentAuthor** est utilisée pour ajouter les auteurs pour les commentaires sur les diapositives au niveau de la présentation. La classe **Presentation** contient la collection d'auteurs pour la présentation dans la classe **CommentAuthors**.

Dans l'exemple suivant, nous avons ajouté le code extrait pour ajouter les commentaires de diapositive.

``` csharp

 string FilePath = @"..\..\..\..\Exemples\";

string FileName = FilePath + "Ajouter un commentaire à une diapositive.pptx";

using (Presentation pres = new Presentation())

{

    //Ajout d'une diapositive vide

    pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

    //Ajout d'un Auteur

    ICommentAuthor author = pres.CommentAuthors.AddAuthor("Zeeshan", "MZ");

    //Position des commentaires

    PointF point = new PointF();

    point.X = 1;

    point.Y = 1;

    //Ajout d'un commentaire de diapositive pour un auteur sur la diapositive

    author.Comments.AddComment("Bonjour Zeeshan, ceci est un commentaire de diapositive", pres.Slides[0], point, DateTime.Now);

    pres.Save(FileName, Aspose.Slides.Export.SaveFormat.Pptx);

}

``` 
## **Télécharger le code exemple**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://master.dl.sourceforge.net/project/asposeopenxml/Aspose.Slides%20Vs%20OpenXML/Ajouter%20un%20commentaire%20à%20une%20diapositive%20%28Aspose.Slides%29.zip?viasf=1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Ajouter%20un%20commentaire%20à%20une%20diapositive%20\(Aspose.Slides\).zip)