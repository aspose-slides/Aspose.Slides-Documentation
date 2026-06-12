---
title: Beheer presentatiecommentaren in .NET
linktitle: Presentatiecommentaren
type: docs
weight: 100
url: /nl/net/presentation-comments/
keywords:
- opmerking
- moderne opmerking
- PowerPoint-opmerkingen
- presentatiecommentaren
- dia-commentaren
- opmerking toevoegen
- opmerking benaderen
- opmerking bewerken
- opmerking beantwoorden
- opmerking verwijderen
- opmerking schrappen
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Beheer presentatiecommentaren met Aspose.Slides voor .NET: voeg opmerkingen toe, lees ze, bewerk ze en verwijder ze snel en eenvoudig in PowerPoint‑bestanden."
---
## **Overzicht**

Dit artikel legt uit hoe u opmerkingen in een presentatie kunt beheren met Aspose.Slides. Het toont de belangrijkste type‑gerelateerde objecten en laat zien hoe u opmerkingen aan dia's toevoegt, bestaande opmerkingen benadert, met antwoorden werkt, moderne opmerkingen gebruikt en opmerkingen uit een presentatie verwijderd.

De voorbeelden richten zich op veelvoorkomende beoordelings‑ en samenwerkingsscenario’s in PowerPoint, zoals het toewijzen van opmerkingen aan auteurs, het lezen van commentaarinhoud en metadata, het opbouwen van antwoordketens en het opruimen van alle opmerkingen of het verwijderen van geselecteerde opmerkingen.

In PowerPoint verschijnt een opmerking als een notitie of annotatie op een dia. Wanneer op een opmerking wordt geklikt, worden de inhoud of berichten ervan getoond. 

## **Waarom opmerkingen aan presentaties toevoegen?**

U wilt wellicht opmerkingen gebruiken om feedback te geven of te communiceren met collega’s tijdens het beoordelen van presentaties.

Om u toe te staan opmerkingen te gebruiken in PowerPoint‑presentaties, biedt Aspose.Slides voor .NET

* De [Presentatie](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)‑klasse, die de verzamelingen van auteurs (van de [CommentAuthorCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/icommentauthorcollection/properties/index)‑eigenschap) bevat. De auteurs voegen opmerkingen toe aan dia’s. 
* De [ICommentCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/icommentcollection)‑interface, die de verzameling van opmerkingen voor individuele auteurs bevat. 
* De [IComment](https://reference.aspose.com/slides/nl/net/aspose.slides/icomment)‑klasse, die informatie over auteurs en hun opmerkingen bevat: wie de opmerking heeft toegevoegd, het tijdstip van toevoegen, de positie van de opmerking, enz. 
* De [CommentAuthor](https://reference.aspose.com/slides/nl/net/aspose.slides/commentauthor)‑klasse, die informatie over een individuele auteur bevat: de naam van de auteur, zijn initialen, opmerkingen gekoppeld aan de naam van de auteur, enz. 

## **Opmerkingen aan dia’s toevoegen**
Deze C#‑code laat zien hoe u een opmerking aan een dia in een PowerPoint‑presentatie toevoegt:

```c#
// Instantieert de Presentation-klasse
using (Presentation presentation = new Presentation())
{
    // Voegt een lege dia toe
    presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

    // Voegt een auteur toe
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Jawad", "MF");

    // Stelt de positie voor opmerkingen in
    PointF point = new PointF();
    point.X = 0.2f;
    point.Y = 0.2f;

    // Voegt een dia-opmerking toe voor een auteur op dia 1
    author.Comments.AddComment("Hello Jawad, this is slide comment", presentation.Slides[0], point, DateTime.Now);

    // Voegt een dia-opmerking toe voor een auteur op dia 2
    author.Comments.AddComment("Hello Jawad, this is second slide comment", presentation.Slides[1], point, DateTime.Now);

    // Benadert ISlide 1
    ISlide slide = presentation.Slides[0];

    // Wanneer null wordt doorgegeven als argument, worden de opmerkingen van alle auteurs naar de geselecteerde dia gehaald
    IComment[] Comments = slide.GetSlideComments(author);

    // Benadert de opmerking op index 0 voor dia 1
    String str = Comments[0].Text;

    presentation.Save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.GetLength(0) > 0)
    {
        // Selecteert de commentaarverzameling van de auteur op index 0
        ICommentCollection commentCollection = Comments[0].Author.Comments;
        String Comment = commentCollection[0].Text;
    }
}
```

## **Opmerkingen van dia’s benaderen**
Deze C#‑code laat zien hoe u een bestaande opmerking op een dia in een PowerPoint‑presentatie benadert:

```c#
// Instantieert de Presentation-klasse
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

## **Antwoorden op opmerkingen**
Een bovenliggende opmerking is de eerste of oorspronkelijke opmerking in een hiërarchie van opmerkingen of antwoorden. Met de [ParentComment](https://reference.aspose.com/slides/nl/net/aspose.slides/icomment/properties/parentcomment)‑eigenschap (van de [IComment](https://reference.aspose.com/slides/nl/net/aspose.slides/icomment)‑interface) kunt u een bovenliggende opmerking instellen of ophalen. 

Deze C#‑code laat zien hoe u opmerkingen toevoegt en antwoorden daarop haalt:

```c#
using (Presentation pres = new Presentation())
{
    // Voegt een opmerking toe
    ICommentAuthor author1 = pres.CommentAuthors.AddAuthor("Author_1", "A.A.");
    IComment comment1 = author1.Comments.AddComment("comment1", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    // Voegt een antwoord toe aan comment1
    ICommentAuthor author2 = pres.CommentAuthors.AddAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.Comments.AddComment("reply 1 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply1.ParentComment = comment1;

    // Voegt nog een antwoord toe aan comment1
    IComment reply2 = author2.Comments.AddComment("reply 2 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply2.ParentComment = comment1;

    // Voegt een antwoord toe aan bestaand antwoord
    IComment subReply = author1.Comments.AddComment("subreply 3 for reply 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    subReply.ParentComment = reply2;

    IComment comment2 = author2.Comments.AddComment("comment  2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    IComment comment3 = author2.Comments.AddComment("comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    IComment reply3 = author1.Comments.AddComment("reply 4 for comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply3.ParentComment = comment3;

    // Toont de hiërarchie van opmerkingen op de console
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

    // Verwijdert comment1 en alle bijbehorende antwoorden
    comment1.Remove();

    pres.Save("remove_comment.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" title="Let op" %}} 

* Wanneer de [Remove](https://reference.aspose.com/slides/nl/net/aspose.slides/icomment/methods/remove)‑methode (van de [IComment](https://reference.aspose.com/slides/nl/net/aspose.slides/icomment)‑interface) wordt gebruikt om een opmerking te verwijderen, worden ook de antwoorden op die opmerking verwijderd. 
* Als de [ParentComment](https://reference.aspose.com/slides/nl/net/aspose.slides/icomment/properties/parentcomment)‑instelling resulteert in een circulaire verwijzing, wordt een [PptxEditException](https://reference.aspose.com/slides/nl/net/aspose.slides/pptxeditexception) gegooid.

{{% /alert %}}

## **Moderne opmerkingen toevoegen**

In 2021 introduceerde Microsoft *moderne opmerkingen* in PowerPoint. De functie voor moderne opmerkingen verbetert de samenwerking in PowerPoint aanzienlijk. Met moderne opmerkingen kunnen gebruikers opmerkingen oplossen, opmerkingen verankeren aan objecten en teksten, en veel gemakkelijker interacties aangaan dan voorheen. 

In [Aspose Slides for .NET 21.11](https://docs.aspose.com/slides/nl/net/aspose-slides-for-net-21-11-release-notes/) hebben we ondersteuning voor moderne opmerkingen geïmplementeerd door de [ModernComment](https://reference.aspose.com/slides/nl/net/aspose.slides/moderncomment)‑klasse toe te voegen. De methoden [AddModernComment](https://reference.aspose.com/slides/nl/net/aspose.slides/commentcollection/methods/addmoderncomment) en [InsertModernComment](https://reference.aspose.com/slides/nl/net/aspose.slides/commentcollection/methods/insertmoderncomment) zijn toegevoegd aan de [CommentCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/commentcollection)‑klasse. 

Deze C#‑code laat zien hoe u een moderne opmerking aan een dia in een PowerPoint‑presentatie toevoegt: 

```c#
using (Presentation pres = new Presentation())
{
     ICommentAuthor newAuthor = pres.CommentAuthors.AddAuthor("Some Author", "SA");
     IModernComment modernComment = newAuthor.Comments.AddModernComment("This is a modern comment", pres.Slides[0], null, new PointF(100, 100), DateTime.Now);
 
     pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Opmerkingen verwijderen**

### **Alle opmerkingen en auteurs verwijderen**

Deze C#‑code laat zien hoe u alle opmerkingen en auteurs in een presentatie verwijdert:

```c#
using (var presentation = new Presentation("example.pptx"))
{
    // Verwijdert alle opmerkingen van de presentatie
    foreach (var author in presentation.CommentAuthors)
    {
        author.Comments.Clear();
    }

    // Verwijdert alle auteurs
    presentation.CommentAuthors.Clear();

    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```

### **Specifieke opmerkingen verwijderen**

Deze C#‑code laat zien hoe u specifieke opmerkingen op een dia verwijdert:

```c#
using (var presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    
    // voeg opmerkingen toe...
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Author", "A");
    author.Comments.AddComment("comment 1", slide, new PointF(0.2f, 0.2f), DateTime.Now);
    author.Comments.AddComment("comment 2", slide, new PointF(0.3f, 0.2f), DateTime.Now);
    
    // verwijder alle opmerkingen die de tekst "comment 1" bevatten
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

**Ondersteunt Aspose.Slides een status zoals ‘opgelost’ voor moderne opmerkingen?**

Ja. [Moderne opmerkingen](https://reference.aspose.com/slides/nl/net/aspose.slides/moderncomment/) bieden een [Status](https://reference.aspose.com/slides/nl/net/aspose.slides/moderncomment/status/)‑eigenschap; u kunt de [status van een opmerking](https://reference.aspose.com/slides/nl/net/aspose.slides/moderncommentstatus/) lezen en instellen (bijvoorbeeld markeren als opgelost), en deze status wordt opgeslagen in het bestand en herkend door PowerPoint.

**Worden draadgesprekken (antwoordketens) ondersteund, en is er een limiet aan de nesting?**

Ja. Elke opmerking kan verwijzen naar zijn [parent comment](https://reference.aspose.com/slides/nl/net/aspose.slides/comment/parentcomment/), waardoor willekeurige antwoordketens mogelijk zijn. De API specificeert geen specifieke diepte‑limiet voor nesting.

**In welk coördinatensysteem wordt de positie van een opmerkingmarker gedefinieerd op een dia?**

De positie wordt opgeslagen als een zwevend‑kommagetal in het coördinatensysteem van de dia. Hierdoor kunt u de marker precies plaatsen waar u deze nodig heeft.