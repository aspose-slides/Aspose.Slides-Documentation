---
title: Beheer presentatie‑opmerkingen in C++
linktitle: Presentatie‑opmerkingen
type: docs
weight: 100
url: /nl/cpp/presentation-comments/
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
- opmerking wissen
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Beheer presentatie‑opmerkingen met Aspose.Slides voor C++: voeg opmerkingen toe, lees, bewerk en verwijder ze in PowerPoint‑bestanden snel en gemakkelijk."
---
## **Overzicht**

Dit artikel legt uit hoe u presentatie‑opmerkingen kunt beheren in Aspose.Slides. Het toont de belangrijkste typen die met opmerkingen te maken hebben en demonstreert hoe u opmerkingen aan dia's kunt toevoegen, bestaande opmerkingen kunt benaderen, met antwoorden kunt werken, moderne opmerkingen kunt gebruiken en opmerkingen uit een presentatie kunt verwijderen.

De voorbeelden richten zich op algemene beoordelings‑ en samenwerkingsscenario’s in PowerPoint, zoals het toewijzen van opmerkingen aan auteurs, het lezen van de inhoud en metadata van opmerkingen, het opbouwen van antwoordketens, en het wissen van alle opmerkingen of het verwijderen van geselecteerde opmerkingen.

In PowerPoint verschijnt een opmerking als een notitie of annotatie op een dia. Wanneer op een opmerking wordt geklikt, worden de inhoud of berichten ervan weergegeven.

### **Waarom opmerkingen toevoegen aan presentaties?**

U wilt wellicht opmerkingen gebruiken om feedback te geven of te communiceren met uw collega's tijdens het beoordelen van presentaties.

Om u in staat te stellen opmerkingen te gebruiken in PowerPoint‑presentaties, biedt Aspose.Slides voor C++:

* De [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation)‑klasse, die de collecties van auteurs bevat (van de [get_CommentAuthors()](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation#ac100feeb13ea426b85557a829676227d)‑methode). De auteurs voegen opmerkingen toe aan dia's.
* De [ICommentCollection](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_comment_collection)‑interface, die de collectie van opmerkingen voor individuele auteurs bevat.
* De [IComment](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_comment)‑klasse, die informatie bevat over auteurs en hun opmerkingen: wie de opmerking heeft toegevoegd, het tijdstip van toevoegen, de positie van de opmerking, enzovoort.
* De [CommentAuthor](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.comment_author)‑klasse, die informatie bevat over individuele auteurs: de naam van de auteur, zijn initialen, opmerkingen gekoppeld aan de naam van de auteur, enzovoort.

## **Een dia‑opmerking toevoegen**
Deze C++‑code laat zien hoe u een opmerking aan een dia in een PowerPoint‑presentatie kunt toevoegen:

```cpp
// Instantieert de Presentation‑klasse
auto presentation = System::MakeObject<Presentation>();
// Voegt een lege dia toe
presentation->get_Slides()->AddEmptySlide(presentation->get_LayoutSlides()->idx_get(0));

// Voegt een auteur toe
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Jawad", u"MF");

// Stelt de positie voor opmerkingen in
PointF point;
point.set_X(0.2f);
point.set_Y(0.2f);

// Benadert ISlide 1
auto slide1 = presentation->get_Slides()->idx_get(0);
// Benadert ISlide 2
auto slide2 = presentation->get_Slides()->idx_get(1);

// Voeg een dia‑opmerking toe voor een auteur op dia 1
author->get_Comments()->AddComment(u"Hello Jawad, this is slide comment", slide1, point, DateTime::get_Now());

// Voeg een dia‑opmerking toe voor een auteur op dia 2
author->get_Comments()->AddComment(u"Hello Jawad, this is second slide comment", slide2, point, DateTime::get_Now());

// Wanneer null als argument wordt doorgegeven, worden opmerkingen van alle auteurs naar de geselecteerde dia gehaald
auto comments = slide1->GetSlideComments(author);

// Benadert de opmerking op index 0 voor dia 1
String str = comments[0]->get_Text();

presentation->Save(u"Comments_out.pptx", SaveFormat::Pptx);

if (comments->GetLength(0) > 0)
{
    // Selecteert de opmerkingen‑collectie van de auteur op index 0
    auto commentCollection = comments[0]->get_Author()->get_Comments();
    String Comment = commentCollection->idx_get(0)->get_Text();
}
```

## **Dia‑opmerkingen benaderen**
Deze C++‑code laat zien hoe u een bestaande opmerking op een dia in een PowerPoint‑presentatie kunt benaderen:

```cpp
// Instantieert de Presentation‑klasse
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

## **Opmerkingen beantwoorden**

Een bovenliggende opmerking is de bovenste of oorspronkelijke opmerking in een hiërarchie van opmerkingen of antwoorden. Met de eigenschap [ParentComment](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) (van de [IComment](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_comment)‑interface) kunt u een bovenliggende opmerking instellen of ophalen.  

Deze C++‑code laat zien hoe u opmerkingen kunt toevoegen en antwoorden daarop kunt verkrijgen:

```cpp
auto pres = System::MakeObject<Presentation>();

// Benadert ISlide 1
auto slide1 = pres->get_Slides()->idx_get(0);

// Voegt een opmerking toe
auto author1 = pres->get_CommentAuthors()->AddAuthor(u"Author_1", u"A.A.");
auto comment1 = author1->get_Comments()->AddComment(u"comment1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

// Voegt een antwoord toe aan comment1
auto author2 = pres->get_CommentAuthors()->AddAuthor(u"Autror_2", u"B.B.");
auto reply1 = author2->get_Comments()->AddComment(u"reply 1 for comment 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply1->set_ParentComment(comment1);

// Voegt nog een antwoord toe aan comment1
auto reply2 = author2->get_Comments()->AddComment(u"reply 2 for comment 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply2->set_ParentComment(comment1);

// Voegt een antwoord toe aan bestaand antwoord
auto subReply = author1->get_Comments()->AddComment(u"subreply 3 for reply 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
subReply->set_ParentComment(reply2);

auto comment2 = author2->get_Comments()->AddComment(u"comment 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
auto comment3 = author2->get_Comments()->AddComment(u"comment 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

auto reply3 = author1->get_Comments()->AddComment(u"reply 4 for comment 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply3->set_ParentComment(comment3);

// Toont de hiërarchie van opmerkingen op de console
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

// Verwijdert comment1 en alle antwoorden erop
comment1->Remove();

pres->Save(u"remove_comment.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="Attention" %}} 
* Wanneer de [Remove](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_comment#a8bb818ae804d142195c4edcf9012cccb)‑methode (van de [IComment](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_comment)‑interface) wordt gebruikt om een opmerking te verwijderen, worden de antwoorden op die opmerking ook verwijderd. 
* Als de instelling van [ParentComment](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) leidt tot een circulaire verwijzing, wordt er een [PptxEditException](https://reference.aspose.com/slides/nl/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d) gegooid.
{{% /alert %}}

## **Een moderne opmerking toevoegen**

In 2021 introduceerde Microsoft *moderne opmerkingen* in PowerPoint. De functie voor moderne opmerkingen verbetert de samenwerking in PowerPoint aanzienlijk. Met moderne opmerkingen kunnen PowerPoint‑gebruikers opmerkingen oplossen, opmerkingen verankeren aan objecten en tekst, en veel gemakkelijker interacties aangaan dan voorheen.  

In [Aspose Slides for C++ 21.11](https://docs.aspose.com/slides/nl/cpp/aspose-slides-for-cpp-21-11-release-notes/) hebben wij ondersteuning voor moderne opmerkingen geïmplementeerd door de klasse [ModernComment](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.modern_comment) toe te voegen. De methoden [AddModernComment](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.comment_collection#a3627fcb3b05cd639fd430bd8248fe66b) en [InsertModernComment](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.comment_collection#ad11c3efb52f3c17f63238447dcc03c94) zijn toegevoegd aan de klasse [CommentCollection](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.comment_collection).  

Deze C++‑code laat zien hoe u een moderne opmerking aan een dia in een PowerPoint‑presentatie kunt toevoegen: 

```cpp
auto pres = System::MakeObject<Presentation>();
// Benadert ISlide 1
auto slide1 = pres->get_Slides()->idx_get(0);

auto newAuthor = pres->get_CommentAuthors()->AddAuthor(u"Some Author", u"SA");
auto modernComment = newAuthor->get_Comments()->AddModernComment(u"This is a modern comment", slide1, nullptr, PointF(100.0f, 100.0f), DateTime::get_Now());

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Een opmerking verwijderen**

### **Alle opmerkingen en auteurs verwijderen**

Deze C++‑code laat zien hoe u alle opmerkingen en auteurs in een presentatie kunt verwijderen:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"example.pptx");

// Verwijdert alle opmerkingen uit de presentatie
for (auto author : presentation->get_CommentAuthors())
{
    author->get_Comments()->Clear();
}
        
// Verwijdert alle auteurs
presentation->get_CommentAuthors()->Clear();
presentation->Save(u"example_out.pptx", SaveFormat::Pptx);
```

### **Specifieke opmerkingen verwijderen**

Deze C++‑code laat zien hoe u specifieke opmerkingen op een dia kunt verwijderen:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
// voeg opmerkingen toe...
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Author", u"A");
author->get_Comments()->AddComment(u"comment 1", slide, PointF(0.2f, 0.2f), System::DateTime::get_Now());
author->get_Comments()->AddComment(u"comment 2", slide, PointF(0.3f, 0.2f), System::DateTime::get_Now());
        
// verwijder alle opmerkingen die de tekst "comment 1" bevatten
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

**Ondersteunt Aspose.Slides een status zoals 'opgelost' voor moderne opmerkingen?**

Ja. [Moderne opmerkingen](https://reference.aspose.com/slides/nl/cpp/aspose.slides/moderncomment/) bieden de methoden [get_Status](https://reference.aspose.com/slides/nl/cpp/aspose.slides/moderncomment/get_status/) en [set_Status](https://reference.aspose.com/slides/nl/cpp/aspose.slides/moderncomment/set_status/); u kunt de [status van een opmerking](https://reference.aspose.com/slides/nl/cpp/aspose.slides/moderncommentstatus/) lezen en instellen (bijvoorbeeld markeren als opgelost), en deze status wordt opgeslagen in het bestand en herkend door PowerPoint.

**Worden discussies in threads (antwoordketens) ondersteund en is er een diepte‑limiet?**

Ja. Elke opmerking kan verwijzen naar zijn [bovenliggende opmerking](https://reference.aspose.com/slides/nl/cpp/aspose.slides/comment/set_parentcomment/), waardoor willekeurige antwoordketens mogelijk zijn. De API geeft geen specifieke limiet voor de nestingsdiepte op.

**In welk coördinatensysteem wordt de positie van een opmerking‑marker op een dia gedefinieerd?**

De positie wordt opgeslagen als een float‑coördinaat in het coördinatensysteem van de dia. Hiermee kunt u de opmerking‑marker precies op de gewenste plaats plaatsen.