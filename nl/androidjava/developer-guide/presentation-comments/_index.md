---
title: Presentatieopmerkingen beheren op Android
linktitle: Presentatie‑opmerkingen
type: docs
weight: 100
url: /nl/androidjava/presentation-comments/
keywords:
- opmerking
- moderne opmerking
- PowerPoint‑opmerkingen
- presentatie‑opmerkingen
- dia‑opmerkingen
- opmerking toevoegen
- opmerking benaderen
- opmerking bewerken
- opmerking beantwoorden
- opmerking verwijderen
- opmerking verwijderen
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Beheer presentatie‑opmerkingen met Aspose.Slides voor Android via Java: voeg opmerkingen toe, lees ze, bewerk en verwijder ze in PowerPoint‑bestanden, snel en eenvoudig."
---
## **Overzicht**

Dit artikel legt uit hoe u opmerkingen in een presentatie kunt beheren met Aspose.Slides. Het toont de belangrijkste commentaargerelateerde types en laat zien hoe u opmerkingen aan dia's kunt toevoegen, bestaande opmerkingen kunt benaderen, met antwoorden kunt werken, moderne opmerkingen kunt gebruiken en opmerkingen uit een presentatie kunt verwijderen.

De voorbeelden richten zich op veelvoorkomende beoordelings‑ en samenwerkingsscenario's in PowerPoint, zoals het toewijzen van opmerkingen aan auteurs, het lezen van de inhoud en metadata van opmerkingen, het opbouwen van antwoordketens, en het wissen van alle opmerkingen of het verwijderen van geselecteerde opmerkingen.

In PowerPoint verschijnt een opmerking als een notitie of annotatie op een dia. Wanneer op een opmerking wordt geklikt, worden de inhoud of berichten ervan getoond.

### **Waarom opmerkingen aan presentaties toevoegen?**

U wilt wellicht opmerkingen gebruiken om feedback te geven of te communiceren met uw collega's bij het beoordelen van presentaties.

Om u het gebruik van opmerkingen in PowerPoint‑presentaties mogelijk te maken, biedt Aspose.Slides for Android via Java

* De klasse [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) die de collecties van auteurs bevat (van de interface [ICommentAuthorCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ICommentAuthorCollection)). De auteurs voegen opmerkingen toe aan dia's.
* De interface [ICommentCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ICommentCollection) die de collectie van opmerkingen voor individuele auteurs bevat.
* De klasse [IComment](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IComment) die informatie over auteurs en hun opmerkingen bevat: wie de opmerking heeft toegevoegd, het tijdstip van toevoegen, de positie van de opmerking, enz.
* De klasse [CommentAuthor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/CommentAuthor) die informatie over individuele auteurs bevat: de naam van de auteur, zijn initialen, opmerkingen die aan de naam van de auteur zijn gekoppeld, enz.

## **Een dia‑opmerking toevoegen**
Deze Java‑code laat zien hoe u een opmerking aan een dia in een PowerPoint‑presentatie kunt toevoegen:

```java
// Instantieert de Presentation‑klasse
Presentation pres = new Presentation();
try {
    // Voegt een lege dia toe
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    // Voegt een auteur toe
    ICommentAuthor author = pres.getCommentAuthors().addAuthor("Jawad", "MF");

    // Stelt de positie voor opmerkingen in
    Point2D.Float point = new Point2D.Float(0.2f, 0.2f);

    // Voegt een dia‑opmerking toe voor een auteur op dia 1
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, new Date());

    // Voegt een dia‑opmerking toe voor een auteur op dia 2
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, new Date());

    // Benadert ISlide 1
    ISlide slide = pres.getSlides().get_Item(0);

    // Wanneer null als argument wordt doorgegeven, worden opmerkingen van alle auteurs naar de geselecteerde dia gehaald
    IComment[] Comments = slide.getSlideComments(author);

    // Benadert de opmerking op index 0 voor dia 1
    String str = Comments[0].getText();

    pres.save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.length > 0)
    {
        // Selecteert de opmerkingenverzameling van de auteur op index 0
        ICommentCollection commentCollection = Comments[0].getAuthor().getComments();
        String Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Dia‑opmerkingen benaderen**
Deze Java‑code laat zien hoe u een bestaande opmerking op een dia in een PowerPoint‑presentatie kunt benaderen:

```java
// Instantieert de Presentation‑klasse
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

## **Antwoorden op opmerkingen**

Een bovenliggende opmerking is de bovenste of oorspronkelijke opmerking in een hiërarchie van opmerkingen of antwoorden. Met behulp van de methoden [getParentComment](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IComment#getParentComment--) of [setParentComment](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) (van de interface [IComment](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IComment)) kunt u een bovenliggende opmerking instellen of opvragen.

Deze Java‑code laat zien hoe u opmerkingen kunt toevoegen en de antwoorden daarop kunt ophalen:

```java
Presentation pres = new Presentation();
try {
    // Voegt een opmerking toe
    ICommentAuthor author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    // Voegt een antwoord toe aan comment1
    ICommentAuthor author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply1.setParentComment(comment1);

    // Voegt nog een antwoord toe aan comment1
    IComment reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    reply2.setParentComment(comment1);

    // Voeg een antwoord toe aan een bestaand antwoord
    IComment subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    subReply.setParentComment(reply2);

    IComment comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    IComment comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    IComment reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply3.setParentComment(comment3);

    // Toont de hiërarchie van opmerkingen op de console
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

    // Verwijdert comment1 en alle antwoorden erop
    comment1.remove();

    pres.save("remove_comment.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" title="Let op" %}} 
* Wanneer de methode [Remove](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IComment#remove--) (van de interface [IComment](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IComment)) wordt gebruikt om een opmerking te verwijderen, worden ook de antwoorden op die opmerking verwijderd.
* Indien de instelling van [setParentComment](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) een circulaire verwijzing oplevert, wordt [PptxEditException](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/PptxEditException) gegenereerd.
{{% /alert %}}

## **Een moderne opmerking toevoegen**

In 2021 heeft Microsoft *moderne opmerkingen* geïntroduceerd in PowerPoint. De functie voor moderne opmerkingen verbetert de samenwerking in PowerPoint aanzienlijk. Met moderne opmerkingen kunnen PowerPoint‑gebruikers opmerkingen oplossen, opmerkingen verankeren aan objecten en teksten, en veel gemakkelijker interacties aangaan dan daarvoor.

Aspose.Slides ondersteunt moderne opmerkingen via de klasse [ModernComment](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ModernComment). De methoden [addModernComment](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) en [insertModernComment](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) zijn toegevoegd aan de klasse [CommentCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/CommentCollection).

Deze Java‑code laat zien hoe u een moderne opmerking aan een dia in een PowerPoint‑presentatie kunt toevoegen: 

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

## **Een opmerking verwijderen**

### **Alle opmerkingen en auteurs verwijderen**

Deze Java‑code laat zien hoe u alle opmerkingen en auteurs in een presentatie kunt verwijderen:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    // Verwijdert alle opmerkingen uit de presentatie
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

### **Specifieke opmerkingen verwijderen**

Deze Java‑code laat zien hoe u specifieke opmerkingen op een dia kunt verwijderen:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // voeg opmerkingen toe...
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, new Point2D.Float(0.2f, 0.2f), new Date());
    author.getComments().addComment("comment 2", slide, new Point2D.Float(0.3f, 0.2f), new Date());

    // verwijder alle opmerkingen die de tekst "comment 1" bevatten
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

## **FAQ**

**Ondersteunt Aspose.Slides een status zoals 'opgelost' voor moderne opmerkingen?**

Ja. [Moderne opmerkingen](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/moderncomment/) bieden een methode [setStatus](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/moderncomment/#setStatus-byte-); u kunt de [status van een opmerking](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/moderncommentstatus/) instellen (bijvoorbeeld markeren als opgelost), en deze status wordt in het bestand opgeslagen en herkend door PowerPoint.

**Worden discussies in threads (antwoordketens) ondersteund, en is er een limiet op het nestingsdiepte?**

Ja. Elke opmerking kan verwijzen naar zijn [bovenliggende opmerking](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/comment/#getParentComment--), waardoor willekeurige antwoordketens mogelijk zijn. De API stelt geen specifieke limiet aan de nestingsdiepte.

**In welk coördinatensysteem wordt de positie van een opmerkingmarker gedefinieerd op een dia?**

De positie wordt opgeslagen als een zwevend‑kommagetal in het coördinatensysteem van de dia. Hierdoor kunt u de opmerkingmarker precies op de gewenste plek plaatsen.