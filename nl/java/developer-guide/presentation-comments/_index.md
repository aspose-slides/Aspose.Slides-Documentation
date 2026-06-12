---
title: Beheer presentatiecommentaren in Java
linktitle: Presentatiecommentaren
type: docs
weight: 100
url: /nl/java/presentation-comments/
keywords:
- commentaar
- modern commentaar
- PowerPoint-commentaren
- presentatiecommentaren
- dia-commentaren
- commentaar toevoegen
- commentaar benaderen
- commentaar bewerken
- commentaar beantwoorden
- commentaar verwijderen
- commentaar verwijderen
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Beheer presentatiecommentaren met Aspose.Slides voor Java: voeg commentaren toe, lees, bewerk en verwijder commentaren in PowerPoint-bestanden snel en eenvoudig."
---
## **Overzicht**

Dit artikel legt uit hoe u presentatiecommentaren beheert in Aspose.Slides. Het toont de belangrijkste commentaar‑gerelateerde types en laat zien hoe u commentaren aan dia’s toevoegt, bestaande commentaren benadert, met antwoorden werkt, moderne commentaren gebruikt en commentaren uit een presentatie verwijdert.

De voorbeelden richten zich op veelvoorkomende review‑ en collaboratiescenario’s in PowerPoint, zoals het toewijzen van commentaren aan auteurs, het lezen van commentaarinhoud en metadata, het opbouwen van antwoordketens, en het wissen van alle commentaren of het verwijderen van geselecteerde commentaren.

In PowerPoint verschijnt een commentaar als een notitie of annotatie op een dia. Wanneer op een commentaar wordt geklikt, worden de inhoud of berichten ervan getoond.

## **Waarom commentaren toevoegen aan presentaties?**

U wilt mogelijk commentaren gebruiken om feedback te geven of te communiceren met uw collega's tijdens het beoordelen van presentaties.

Om u in staat te stellen commentaren te gebruiken in PowerPoint‑presentaties, biedt Aspose.Slides voor Java:

* De [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation)‑klasse, die de collecties van auteurs bevat (van de [ICommentAuthorCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ICommentAuthorCollection)‑interface). De auteurs voegen commentaren toe aan dia’s. 
* De [ICommentCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ICommentCollection)‑interface, die de collectie van commentaren voor individuele auteurs bevat. 
* De [IComment](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IComment)‑klasse, die informatie bevat over auteurs en hun commentaren: wie het commentaar heeft toegevoegd, het tijdstip van toevoegen, de positie van het commentaar, enz. 
* De [CommentAuthor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/CommentAuthor)‑klasse, die informatie over individuele auteurs bevat: de naam van de auteur, zijn initialen, commentaren die aan de naam van de auteur gekoppeld zijn, enz. 

## **Commentaren aan dia toevoegen**
Deze Java‑code laat zien hoe u een commentaar toevoegt aan een dia in een PowerPoint‑presentatie:

```java
// Instantieert de Presentation-klasse
Presentation pres = new Presentation();
try {
    // Voegt een lege dia toe
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    // Voegt een auteur toe
    ICommentAuthor author = pres.getCommentAuthors().addAuthor("Jawad", "MF");

    // Stelt de positie voor commentaren in
    Point2D.Float point = new Point2D.Float(0.2f, 0.2f);

    // Voegt een dia-commentaar toe voor een auteur op dia 1
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, new Date());

    // Voegt een dia-commentaar toe voor een auteur op dia 2
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, new Date());

    // Benadert ISlide 1
    ISlide slide = pres.getSlides().get_Item(0);

    // Wanneer null wordt doorgegeven als argument, worden commentaren van alle auteurs naar de geselecteerde dia gehaald
    IComment[] Comments = slide.getSlideComments(author);

    // Benadert het commentaar op index 0 voor dia 1
    String str = Comments[0].getText();

    pres.save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.length > 0)
    {
        // Selecteert de commentaarcollectie van de auteur op index 0
        ICommentCollection commentCollection = Comments[0].getAuthor().getComments();
        String Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Commentaren op dia benaderen**
Deze Java‑code laat zien hoe u een bestaand commentaar op een dia in een PowerPoint‑presentatie benadert:

```java
// Instantieert de Presentation-klasse
Presentation pres = new Presentation("Comments1.pptx");
try {
    for (ICommentAuthor commentAuthor : pres.getCommentAuthors())
    {
        CommentAuthor author = (CommentAuthor) commentAuthor;
        for (IComment comment1 : author.getComments())
        {
            Comment comment = (Comment) comment1;
            System.out.println("ISlide :" + comment.getSlide().getSlideNumber() + " has comment: " + comment.getText() +
                    " with Author: " + comment.getAuthor().getName() + " posted on time :" + comment.getCreatedTime() + "\n");
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Antwoorden op commentaren**
Een bovenliggend commentaar is het eerste of originele commentaar in een hiërarchie van commentaren of antwoorden. Met de [getParentComment](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IComment#getParentComment--) of [setParentComment](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) methoden (van de [IComment](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IComment)‑interface) kunt u een bovenliggend commentaar instellen of ophalen. 

Deze Java‑code laat zien hoe u commentaren toevoegt en de antwoorden hierop verkrijgt:

```java
Presentation pres = new Presentation();
try {
    // Voegt een commentaar toe
    ICommentAuthor author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    // Voegt een antwoord toe aan comment1
    ICommentAuthor author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply1.setParentComment(comment1);

    // Voegt nog een antwoord toe aan comment1
    IComment reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    reply2.setParentComment(comment1);

    // Voegt een antwoord toe aan een bestaand antwoord
    IComment subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    subReply.setParentComment(reply2);

    IComment comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    IComment comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    IComment reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply3.setParentComment(comment3);

    // Toont de commentaarhiërarchie op de console
    ISlide slide = pres.getSlides().get_Item(0);
    IComment[] comments = slide.getSlideComments(null);
    for (int i = 0; i < comments.length; i++)
    {
        IComment comment = comments[i];
        while (comment.getParentComment() != null)
        {
            System.out.print("\t");
            comment = comment.getParentComment();
        }

        System.out.println(comments[i].getAuthor().getName() +  " : " + comments[i].getText());
        System.out.println();
    }
    pres.save("parent_comment.pptx",SaveFormat.Pptx);

    // Verwijdert comment1 en alle antwoorden daarop
    comment1.remove();

    pres.save("remove_comment.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" title="Attention" %}} 
* Wanneer de [Remove](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IComment#remove--)‑methode (van de [IComment](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IComment)‑interface) wordt gebruikt om een commentaar te verwijderen, worden ook de antwoorden op dat commentaar verwijderd. 
* Als de [setParentComment](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-)‑instelling leidt tot een circulaire referentie, wordt er een [PptxEditException](https://reference.aspose.com/slides/nl/java/com.aspose.slides/PptxEditException) gegooid.
{{% /alert %}}

## **Moderne commentaren toevoegen**

In 2021 heeft Microsoft *moderne commentaren* geïntroduceerd in PowerPoint. De functie voor moderne commentaren verbetert de samenwerking in PowerPoint aanzienlijk. Met moderne commentaren kunnen PowerPoint‑gebruikers commentaren oplossen, commentaren aan objecten en tekst verankeren, en veel gemakkelijker interacties aangaan dan voorheen. 

In [Aspose Slides for Java 21.11](https://docs.aspose.com/slides/nl/java/aspose-slides-for-java-21-11-release-notes/) hebben we ondersteuning voor moderne commentaren geïmplementeerd door de [ModernComment](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ModernComment)‑klasse toe te voegen. De [addModernComment](https://reference.aspose.com/slides/nl/java/com.aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-)‑ en [insertModernComment](https://reference.aspose.com/slides/nl/java/com.aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-)‑methoden zijn toegevoegd aan de [CommentCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/CommentCollection)‑klasse. 

Deze Java‑code laat zien hoe u een modern commentaar toevoegt aan een dia in een PowerPoint‑presentatie: 

```java
Presentation pres = new Presentation();
try {
    ICommentAuthor newAuthor = pres.getCommentAuthors().addAuthor("Some Author", "SA");
    IModernComment modernComment = newAuthor.getComments().addModernComment("This is a modern comment", pres.getSlides().get_Item(0), null, new Point2D.Float(100, 100), new Date());

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Commentaren verwijderen**

### **Alle commentaren en auteurs verwijderen**
Deze Java‑code laat zien hoe u alle commentaren en auteurs in een presentatie verwijdert:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    // Verwijdert alle commentaren uit de presentatie
    for (ICommentAuthor author : presentation.getCommentAuthors())
    {
        author.getComments().clear();
    }

    // Verwijdert alle auteurs
    presentation.getCommentAuthors().clear();

    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **Specifieke commentaren verwijderen**
Deze Java‑code laat zien hoe u specifieke commentaren op een dia verwijdert:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // voeg commentaren toe...
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, new Point2D.Float(0.2f, 0.2f), new Date());
    author.getComments().addComment("comment 2", slide, new Point2D.Float(0.3f, 0.2f), new Date());

    // verwijder alle commentaren die de tekst "comment 1" bevatten
    for (ICommentAuthor commentAuthor : presentation.getCommentAuthors())
    {
        ArrayList<IComment> toRemove = new ArrayList<IComment>();
        for (IComment comment : slide.getSlideComments(commentAuthor))
        {
            if (comment.getText().equals("comment 1"))
            {
                toRemove.add(comment);
            }
        }

        for (IComment comment : toRemove)
        {
            commentAuthor.getComments().remove(comment);
        }
    }

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Veelgestelde vragen**

**Ondersteunt Aspose.Slides een status zoals 'opgelost' voor moderne commentaren?**

Ja. [Modern comments](https://reference.aspose.com/slides/nl/java/com.aspose.slides/moderncomment/) bieden een [setStatus](https://reference.aspose.com/slides/nl/java/com.aspose.slides/moderncomment/#setStatus-byte-)‑methode; u kunt een [commentaarstatus](https://reference.aspose.com/slides/nl/java/com.aspose.slides/moderncommentstatus/) (bijvoorbeeld markeren als opgelost) instellen, en deze status wordt opgeslagen in het bestand en wordt herkend door PowerPoint.

**Worden draadgesprekken (antwoordketens) ondersteund, en is er een limiet op het nestingsniveau?**

Ja. Elk commentaar kan naar zijn [parent comment](https://reference.aspose.com/slides/nl/java/com.aspose.slides/comment/#getParentComment--) verwijzen, waardoor willekeurige antwoordketens mogelijk zijn. De API specificeert geen specifieke limiet voor de nestingsdiepte.

**In welk coördinatensysteem wordt de positie van een commentaarmarker gedefinieerd op een dia?**

De positie wordt opgeslagen als een zwevend‑kommagetal in het coördinatensysteem van de dia. Hierdoor kunt u de commentaarmarker precies plaatsen waar u dat nodig heeft.