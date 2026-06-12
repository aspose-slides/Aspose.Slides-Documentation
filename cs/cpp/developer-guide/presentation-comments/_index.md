---
title: Správa komentářů v prezentaci v C++
linktitle: Komentáře v prezentaci
type: docs
weight: 100
url: /cs/cpp/presentation-comments/
keywords:
- komentář
- moderní komentář
- komentáře PowerPoint
- komentáře v prezentaci
- komentáře snímků
- přidat komentář
- přístup k komentáři
- upravit komentář
- odpovědět na komentář
- odstranit komentář
- smazat komentář
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Ovládněte komentáře v prezentacích pomocí Aspose.Slides pro C++: přidávejte, čtěte, upravujte a odstraňujte komentáře v souborech PowerPoint rychle a snadno."
---
## **Přehled**

Tento článek vysvětluje, jak spravovat komentáře v prezentaci v Aspose.Slides. Ukazuje hlavní typy související s komentáři a demonstruje, jak přidávat komentáře do snímků, přistupovat k existujícím komentářům, pracovat s odpověďmi, používat moderní komentáře a odstraňovat komentáře z prezentace.

Příklady se zaměřují na běžné scénáře recenzí a spolupráce v PowerPointu, jako je přiřazování komentářů autorům, čtení obsahu a metadat komentářů, vytváření řetězců odpovědí a odstranění všech komentářů nebo smazání vybraných.

V PowerPointu se komentář zobrazuje jako poznámka nebo anotace na snímku. Po kliknutí na komentář se zobrazí jeho obsah nebo zprávy.

### **Proč přidávat komentáře do prezentací?**

Můžete chtít používat komentáře k poskytování zpětné vazby nebo komunikaci s kolegy při recenzování prezentací.

Aby vám bylo umožněno používat komentáře v prezentacích PowerPoint, poskytuje Aspose.Slides for C++  

* Třída [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation), která obsahuje kolekce autorů (z metody [get_CommentAuthors()](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation#ac100feeb13ea426b85557a829676227d)). Autoři přidávají komentáře do snímků.  
* Rozhraní [ICommentCollection](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_comment_collection), které obsahuje kolekci komentářů pro jednotlivé autory.  
* Třída [IComment](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_comment), která obsahuje informace o autorech a jejich komentářích: kdo komentář přidal, čas přidání komentáře, pozice komentáře atd.  
* Třída [CommentAuthor](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.comment_author), která obsahuje informace o jednotlivých autorech: jméno autora, jeho iniciály, komentáře spojené s jménem autora atd.  

## **Přidat komentář ke snímku**
Tento C++ kód ukazuje, jak přidat komentář do snímku v prezentaci PowerPoint:

```cpp
// Vytvoří instanci třídy Presentation
auto presentation = System::MakeObject<Presentation>();
// Přidá prázdný snímek
presentation->get_Slides()->AddEmptySlide(presentation->get_LayoutSlides()->idx_get(0));

// Přidá autora
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Jawad", u"MF");

// Nastaví pozici pro komentáře
PointF point;
point.set_X(0.2f);
point.set_Y(0.2f);

// Přistupuje k ISlide 1
auto slide1 = presentation->get_Slides()->idx_get(0);
// Přistupuje k ISlide 2
auto slide2 = presentation->get_Slides()->idx_get(1);

// Přidá komentář ke snímku pro autora na snímku 1
author->get_Comments()->AddComment(u"Hello Jawad, this is slide comment", slide1, point, DateTime::get_Now());

// Přidá komentář ke snímku pro autora na snímku 2
author->get_Comments()->AddComment(u"Hello Jawad, this is second slide comment", slide2, point, DateTime::get_Now());

// Když je jako argument předáno null, jsou na vybraný snímek načteny komentáře od všech autorů
auto comments = slide1->GetSlideComments(author);

// Přistupuje k komentáři na indexu 0 pro snímek 1
String str = comments[0]->get_Text();

presentation->Save(u"Comments_out.pptx", SaveFormat::Pptx);

if (comments->GetLength(0) > 0)
{
    // Vybere kolekci komentářů autora na indexu 0
    auto commentCollection = comments[0]->get_Author()->get_Comments();
    String Comment = commentCollection->idx_get(0)->get_Text();
}
```

## **Přístup ke komentářům snímku**
Tento C++ kód ukazuje, jak získat přístup k existujícímu komentáři na snímku v prezentaci PowerPoint:

```cpp
// Vytvoří instanci třídy Presentation
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

## **Odpovědi na komentáře**

Nadřazený komentář je hlavní nebo původní komentář v hierarchii komentářů či odpovědí. Pomocí vlastnosti [ParentComment](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) (z rozhraní [IComment](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_comment)) můžete nastavit nebo získat nadřazený komentář.

Tento C++ kód ukazuje, jak přidávat komentáře a získávat odpovědi na ně:

```cpp
auto pres = System::MakeObject<Presentation>();

// Přistupuje k ISlide 1
auto slide1 = pres->get_Slides()->idx_get(0);

// Přidá komentář
auto author1 = pres->get_CommentAuthors()->AddAuthor(u"Author_1", u"A.A.");
auto comment1 = author1->get_Comments()->AddComment(u"comment1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

// Přidá odpověď na comment1
auto author2 = pres->get_CommentAuthors()->AddAuthor(u"Autror_2", u"B.B.");
auto reply1 = author2->get_Comments()->AddComment(u"reply 1 for comment 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply1->set_ParentComment(comment1);

// Přidá další odpověď na comment1
auto reply2 = author2->get_Comments()->AddComment(u"reply 2 for comment 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply2->set_ParentComment(comment1);

// Přidá odpověď na existující odpověď
auto subReply = author1->get_Comments()->AddComment(u"subreply 3 for reply 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
subReply->set_ParentComment(reply2);

auto comment2 = author2->get_Comments()->AddComment(u"comment 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
auto comment3 = author2->get_Comments()->AddComment(u"comment 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

auto reply3 = author1->get_Comments()->AddComment(u"reply 4 for comment 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply3->set_ParentComment(comment3);

// Zobrazí hierarchii komentářů v konzoli
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

// Odstraní comment1 a všechny odpovědi na něj
comment1->Remove();

pres->Save(u"remove_comment.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="Attention" %}} 
* Když je metoda [Remove](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_comment#a8bb818ae804d142195c4edcf9012cccb) (z rozhraní [IComment](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_comment)) použita k odstranění komentáře, jsou také smazány odpovědi na tento komentář. 
* Pokud nastavení [ParentComment](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) způsobí kruhový odkaz, bude vyvolána výjimka [PptxEditException](https://reference.aspose.com/slides/cs/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d). 
{{% /alert %}}

## **Přidat moderní komentář**

V roce 2021 představila společnost Microsoft v PowerPointu *moderní komentáře*. Funkce moderních komentářů výrazně zlepšuje spolupráci v PowerPointu. Díky moderním komentářům mohou uživatelé PowerPointu řešit komentáře, připevňovat je k objektům a textům a zapojovat se do interakcí mnohem snadněji než dříve.  

V [Aspose Slides for C++ 21.11](https://docs.aspose.com/slides/cs/cpp/aspose-slides-for-cpp-21-11-release-notes/) jsme implementovali podporu moderních komentářů přidáním třídy [ModernComment](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.modern_comment). Metody [AddModernComment](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.comment_collection#a3627fcb3b05cd639fd430bd8248fe66b) a [InsertModernComment](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.comment_collection#ad11c3efb52f3c17f63238447dcc03c94) byly přidány do třídy [CommentCollection](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.comment_collection).  

Tento C++ kód ukazuje, jak přidat moderní komentář do snímku v prezentaci PowerPoint: 

```cpp
auto pres = System::MakeObject<Presentation>();
// Přistupuje k ISlide 1
auto slide1 = pres->get_Slides()->idx_get(0);

auto newAuthor = pres->get_CommentAuthors()->AddAuthor(u"Some Author", u"SA");
auto modernComment = newAuthor->get_Comments()->AddModernComment(u"This is a modern comment", slide1, nullptr, PointF(100.0f, 100.0f), DateTime::get_Now());

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Odstranit komentář**

### **Odstranit všechny komentáře a autory**

Tento C++ kód ukazuje, jak odstranit všechny komentáře a autory v prezentaci:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"example.pptx");

// Odstraní všechny komentáře z prezentace
for (auto author : presentation->get_CommentAuthors())
{
    author->get_Comments()->Clear();
}
        
// Odstraní všechny autory
presentation->get_CommentAuthors()->Clear();
presentation->Save(u"example_out.pptx", SaveFormat::Pptx);
```

### **Odstranit konkrétní komentáře**

Tento C++ kód ukazuje, jak smazat konkrétní komentáře na snímku:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
// přidá komentáře...
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Author", u"A");
author->get_Comments()->AddComment(u"comment 1", slide, PointF(0.2f, 0.2f), System::DateTime::get_Now());
author->get_Comments()->AddComment(u"comment 2", slide, PointF(0.3f, 0.2f), System::DateTime::get_Now());
        
// odstraní všechny komentáře, které obsahují text "comment 1"
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

## **Často kladené otázky**

**Podporuje Aspose.Slides stav jako 'vyřešeno' pro moderní komentáře?**

Ano. [Moderní komentáře](https://reference.aspose.com/slides/cs/cpp/aspose.slides/moderncomment/) poskytují metody [get_Status](https://reference.aspose.com/slides/cs/cpp/aspose.slides/moderncomment/get_status/) a [set_Status](https://reference.aspose.com/slides/cs/cpp/aspose.slides/moderncomment/set_status/); můžete číst a nastavit [stav komentáře](https://reference.aspose.com/slides/cs/cpp/aspose.slides/moderncommentstatus/) (například jej označit jako vyřešený), a tento stav je uložen v souboru a rozeznán PowerPointem.

**Jsou podporovány vlákna diskusí (řetězce odpovědí) a existuje limit hloubky?**

Ano. Každý komentář může odkazovat na svůj [parent comment](https://reference.aspose.com/slides/cs/cpp/aspose.slides/comment/set_parentcomment/), což umožňuje libovolné řetězce odpovědí. API neurčuje konkrétní limit hloubky vnoření.

**V jakém souřadnicovém systému je definována pozice značky komentáře na snímku?**

Pozice je uložena jako bod s plovoucí desetinnou čárkou v souřadnicovém systému snímku. To vám umožní umístit značku komentáře přesně tam, kde ji potřebujete.