---
title: Správa komentářů k prezentaci v Pythonu
linktitle: Komentáře k prezentaci
type: docs
weight: 100
url: /cs/python-net/presentation-comments/
keywords:
- komentář
- moderní komentář
- komentáře PowerPointu
- komentáře prezentace
- komentáře snímku
- přidat komentář
- přístup ke komentáři
- upravit komentář
- odpovědět na komentář
- odstranit komentář
- smazat komentář
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Ovládejte komentáře k prezentaci pomocí Aspose.Slides pro Python přes .NET: přidávejte, čtěte, upravujte a mažte komentáře v souborech PowerPoint rychle a snadno."
---
## **Přehled**

Tento článek vysvětluje, jak spravovat komentáře k prezentaci v Aspose.Slides. Ukazuje hlavní typy související s komentáři a demonstruje, jak přidávat komentáře do snímků, přistupovat k existujícím komentářům, pracovat s odpověďmi, používat moderní komentáře a odstraňovat komentáře z prezentace.

Příklady se zaměřují na běžné scénáře revize a spolupráce v PowerPointu, jako je přiřazování komentářů autorům, čtení obsahu a metadat komentářů, vytváření řetězců odpovědí a vymazání všech komentářů nebo odstranění vybraných.

V PowerPointu se komentář zobrazuje jako poznámka nebo anotace na snímku. Po kliknutí na komentář se zobrazí jeho obsah nebo zprávy.

## **Proč přidávat komentáře k prezentacím?**

Možná chcete používat komentáře k poskytnutí zpětné vazby nebo komunikaci s kolegy při revizi prezentací.

Aby vám umožnilo používat komentáře v PowerPoint prezentacích, Aspose.Slides pro Python prostřednictvím .NET poskytuje
* Třídu [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) , která obsahuje kolekce autorů (z vlastnosti [CommentAuthorCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/commentauthorcollection/)). Autoři přidávají komentáře do snímků. 
* Třídu [CommentCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/commentcollection/) , která obsahuje kolekci komentářů pro jednotlivé autory. 
* Třídu [Comment](https://reference.aspose.com/slides/cs/python-net/aspose.slides/comment/) , která obsahuje informace o autorech a jejich komentářích: kdo komentář přidal, kdy byl komentář přidán, pozice komentáře atd. 
* Třídu [CommentAuthor](https://reference.aspose.com/slides/cs/python-net/aspose.slides/commentauthor/) , která obsahuje informace o jednotlivých autorech: jméno autora, jeho iniciály, komentáře spojené s jménem autora atd. 

## **Přidat komentář k snímku**
Ukázkový kód v Pythonu, který ukazuje, jak přidat komentář k snímku v PowerPoint prezentaci:

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

# Vytvoří instanci třídy Presentation
with slides.Presentation() as presentation:
    # Přidá prázdný snímek
    presentation.slides.add_empty_slide(presentation.layout_slides[0])

    # Přidá autora
    author = presentation.comment_authors.add_author("Jawad", "MF")

    # Nastaví pozici pro komentáře
    point = draw.PointF(0.2, 0.2)

    # Přidá komentář k snímku pro autora na snímku 1
    author.comments.add_comment("Hello Jawad, this is slide comment", presentation.slides[0], point, datetime.date.today())

    # Přidá komentář k snímku pro autora na snímku 2
    author.comments.add_comment("Hello Jawad, this is second slide comment", presentation.slides[1], point, datetime.date.today())

    # Přístup k ISlide 1
    slide = presentation.slides[0]

    # Když je jako argument předáno null, jsou na vybraný snímek přineseny komentáře od všech autorů
    comments = slide.get_slide_comments(author)

    # Přistupuje ke komentáři na indexu 0 pro snímek 1
    str = comments[0].text

    presentation.save("Comments_out.pptx", slides.export.SaveFormat.PPTX)

    if comments.length > 0:
        # Vybere kolekci komentářů autora na indexu 0
        commentCollection = comments[0].author.comments
        print(commentCollection[0].text)
```



## **Přístup ke komentářům na snímku**
Ukázkový kód v Pythonu, který ukazuje, jak získat existující komentář na snímku v PowerPoint prezentaci:

```python
import aspose.slides as slides

# Vytvoří instanci třídy Presentation
with slides.Presentation("Comments1.pptx") as presentation:
    for author in presentation.comment_authors:
        for comment in author.comments:
            print("ISlide :" + str(comment.slide.slide_number) + 
            " has comment: " + comment.text + 
            " with Author: " + comment.author.name + 
            " posted on time :" + str(comment.created_time) + "\n")
```


## **Odpovědi na komentáře**
Nadřazený komentář je nejvyšší nebo původní komentář v hierarchii komentářů nebo odpovědí. Pomocí vlastnosti `parent_comment` (z třídy [Comment](https://reference.aspose.com/slides/cs/python-net/aspose.slides/comment/)) můžete nastavit nebo získat nadřazený komentář. 

Ukázkový kód v Pythonu, který ukazuje, jak přidávat komentáře a získávat na ně odpovědi:

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

with slides.Presentation() as pres:
    # Přidá komentář
    author1 = pres.comment_authors.add_author("Author_1", "A.A.")
    comment1 = author1.comments.add_comment("comment1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    # Přidá odpověď na comment1
    author2 = pres.comment_authors.add_author("Autror_2", "B.B.")
    reply1 = author2.comments.add_comment("reply 1 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply1.parent_comment = comment1

    # Přidá další odpověď na comment1
    reply2 = author2.comments.add_comment("reply 2 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply2.parent_comment = comment1

    # Přidá odpověď na existující odpověď
    subReply = author1.comments.add_comment("subreply 3 for reply 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    subReply.parent_comment = reply2

    comment2 = author2.comments.add_comment("comment 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    comment3 = author2.comments.add_comment("comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    reply3 = author1.comments.add_comment("reply 4 for comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply3.parent_comment = comment3

    # Zobrazí hierarchii komentářů v konzoli
    slide = pres.slides[0]
    comments = slide.get_slide_comments(None)
    for i in range(comments.length):
        comment = comments[i]
        while comment.parent_comment is not None:
            print("\t")
            comment = comment.parent_comment

        print(comments[i].author.name + " : " + comments[i].text)
        print("\r\n")

    pres.save("parent_comment.pptx", slides.export.SaveFormat.PPTX)

    # Odstraní comment1 a všechny odpovědi na něj
    comment1.remove()

    pres.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Attention" %}} 

* Když je metodou `remove` (z třídy [Comment](https://reference.aspose.com/slides/cs/python-net/aspose.slides/comment/)) odstraněn komentář, jsou také odstraněny odpovědi na tento komentář. 
* Pokud nastavení `parent_comment` způsobí kruhový odkaz, bude vyvolána výjimka `PptxEditException`. 

{{% /alert %}}

## **Přidat moderní komentář**

V roce 2021 společnost Microsoft představila *moderní komentáře* v PowerPointu. Funkce moderních komentářů významně zlepšuje spolupráci v PowerPointu. Díky moderním komentářům mohou uživatelé PowerPointu řešit komentáře, ukotvit je k objektům a textům a zapojovat se do interakcí mnohem jednodušeji než dříve. 

Podporu moderních komentářů jsme implementovali přidáním třídy [ModernComment](https://reference.aspose.com/slides/cs/python-net/aspose.slides/moderncomment/). Metody `add_modern_comment` a `insert_modern_comment` byly přidány do třídy [CommentCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/commentcollection/). 

Ukázkový kód v Pythonu, který ukazuje, jak přidat moderní komentář k snímku v PowerPoint prezentaci:

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as pres:
    newAuthor = pres.comment_authors.add_author("Some Author", "SA")
    modernComment = newAuthor.comments.add_modern_comment("This is a modern comment", pres.slides[0], None, draw.PointF(100, 100), date.today())

    pres.save("example.pptx", slides.export.SaveFormat.PPTX)
```

## **Odstranit komentář**

### **Odstranit všechny komentáře a autory**

Ukázkový kód v Pythonu, který ukazuje, jak odstranit všechny komentáře a autory v prezentaci:

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    # Odstraní všechny komentáře z prezentace
    for author in presentation.comment_authors:
        author.comments.clear()

    # Odstraní všechny autory
    presentation.comment_authors.clear()

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Odstranit konkrétní komentáře**

Ukázkový kód v Pythonu, který ukazuje, jak smazat konkrétní komentáře na snímku:

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    # přidá komentáře...
    author = presentation.comment_authors.add_author("Author", "A")
    author.comments.add_comment("comment 1", slide, draw.PointF(0.2, 0.2), date.today())
    author.comments.add_comment("comment 2", slide, draw.PointF(0.3, 0.2), date.today())
    
    # odstraní všechny komentáře, které obsahují text "comment 1"
    for commentAuthor in presentation.comment_authors:
        toRemove = []
        for comment in slide.get_slide_comments(commentAuthor):
            if comment.text == "comment 1":
                toRemove.append(comment)
        
        for comment in toRemove:
            commentAuthor.comments.remove(comment)
    
    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Časté otázky**

**Podporuje Aspose.Slides u moderních komentářů stav jako „vyřešeno“?**

Ano. [Moderní komentáře](https://reference.aspose.com/slides/cs/python-net/aspose.slides/moderncomment/) poskytují vlastnost [status](https://reference.aspose.com/slides/cs/python-net/aspose.slides/moderncomment/status/); můžete číst a nastavit [stav komentáře](https://reference.aspose.com/slides/cs/python-net/aspose.slides/moderncommentstatus/) (například ho označit jako vyřešený) a tento stav je uložen v souboru a rozpoznán PowerPointem.

**Jsou podporovány vlákna diskuzí (řetězce odpovědí) a existuje limit vnoření?**

Ano. Každý komentář může odkazovat na svůj [nadřazený komentář](https://reference.aspose.com/slides/cs/python-net/aspose.slides/moderncomment/parent_comment/), což umožňuje libovolné řetězce odpovědí. API neuvádí konkrétní limit hloubky vnoření.

**V jakém souřadnicovém systému je definována pozice značky komentáře na snímku?**

Pozice je uložena jako bod s desetinnou čárkou v souřadnicovém systému snímku. To vám umožňuje umístit značku komentáře přesně tam, kde ji potřebujete.