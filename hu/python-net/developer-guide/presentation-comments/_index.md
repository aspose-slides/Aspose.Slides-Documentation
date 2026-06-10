---
title: Prezentációs megjegyzések kezelése Pythonban
linktitle: Prezentációs megjegyzések
type: docs
weight: 100
url: /hu/python-net/presentation-comments/
keywords:
- megjegyzés
- modern megjegyzés
- PowerPoint megjegyzések
- prezentációs megjegyzések
- dia megjegyzések
- megjegyzés hozzáadása
- megjegyzés elérése
- megjegyzés szerkesztése
- megjegyzés megválaszolása
- megjegyzés eltávolítása
- megjegyzés törlése
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Kezelje a prezentációs megjegyzéseket az Aspose.Slides for Python via .NET segítségével: gyorsan és egyszerűen adjon hozzá, olvasson, szerkesszen és töröljön megjegyzéseket PowerPoint fájlokban."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet kezelni a prezentációs megjegyzéseket az Aspose.Slides-ban. Megjeleníti a megjegyzésekkel kapcsolatos fő típusokat, és bemutatja, hogyan lehet megjegyzéseket hozzáadni a diákhoz, meglévő megjegyzéseket elérni, válaszokkal dolgozni, modern megjegyzéseket használni, és megjegyzéseket eltávolítani a prezentációból.

A példák a PowerPoint-ban gyakori felülvizsgálati és együttműködési helyzetekre összpontosítanak, például a megjegyzések szerzőkhöz rendelésére, a megjegyzés tartalmának és metaadatainak olvasására, válaszközök építésére, valamint az összes megjegyzés törlésére vagy a kijelöltek eltávolítására.

A PowerPoint-ban a megjegyzés jegyzetként vagy annotációként jelenik meg egy dián. Ha egy megjegyzésre kattintanak, a tartalma vagy üzenetei megjelennek.

## **Miért adjunk megjegyzéseket a prezentációkhoz?**

Előfordulhat, hogy megjegyzéseket szeretne használni visszajelzés nyújtására vagy a kollégáival való kommunikációra a prezentációk felülvizsgálata során.

Ahhoz, hogy megjegyzéseket használhasson PowerPoint-prezentációkban, az Aspose.Slides for Python via .NET a következőket biztosítja

* A [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztály, amely tartalmazza a szerzők gyűjteményeit (a [CommentAuthorCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/commentauthorcollection/) tulajdonságból). A szerzők megjegyzéseket adnak a diákhoz. 
* A  [CommentCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/commentcollection/) osztály, amely egyes szerzők megjegyzéseinek gyűjteményét tartalmazza. 
* A [Comment](https://reference.aspose.com/slides/hu/python-net/aspose.slides/comment/) osztály, amely információkat tartalmaz a szerzőkről és a megjegyzéseikről: ki adta a megjegyzést, mikor adták hozzá, a megjegyzés pozíciója stb. 
* A [CommentAuthor](https://reference.aspose.com/slides/hu/python-net/aspose.slides/commentauthor/) osztály, amely egyes szerzőkről nyújt információkat: a szerző neve, a monogramja, a szerző nevéhez kapcsolódó megjegyzések stb. 

## **Dia megjegyzés hozzáadása**
Ez a Python kód megmutatja, hogyan lehet megjegyzést hozzáadni egy diához egy PowerPoint prezentációban:

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

# Példányosítja a Presentation osztályt
with slides.Presentation() as presentation:
    # Üres diát ad hozzá
    presentation.slides.add_empty_slide(presentation.layout_slides[0])

    # Szerzőt ad hozzá
    author = presentation.comment_authors.add_author("Jawad", "MF")

    # Beállítja a megjegyzések pozícióját
    point = draw.PointF(0.2, 0.2)

    # Megjegyzést ad egy szerzőnek az 1. diára
    author.comments.add_comment("Hello Jawad, this is slide comment", presentation.slides[0], point, datetime.date.today())

    # Megjegyzést ad egy szerzőnek a 2. diára
    author.comments.add_comment("Hello Jawad, this is second slide comment", presentation.slides[1], point, datetime.date.today())

    # Az 1. ISlide elérése
    slide = presentation.slides[0]

    # Ha null értéket adunk át argumentumként, az összes szerző megjegyzései a kiválasztott diára kerülnek
    comments = slide.get_slide_comments(author)

    # Eléri a 0. indexű megjegyzést az 1. dián
    str = comments[0].text

    presentation.save("Comments_out.pptx", slides.export.SaveFormat.PPTX)

    if comments.length > 0:
        # Kiválasztja a szerző 0. indexű megjegyzésgyűjteményét
        commentCollection = comments[0].author.comments
        print(commentCollection[0].text)
```



## **Dia megjegyzések elérése**
Ez a Python kód megmutatja, hogyan lehet elérni egy meglévő megjegyzést egy dián egy PowerPoint prezentációban:

```python
import aspose.slides as slides

# Példányosítja a Presentation osztályt
with slides.Presentation("Comments1.pptx") as presentation:
    for author in presentation.comment_authors:
        for comment in author.comments:
            print("ISlide :" + str(comment.slide.slide_number) + 
            " has comment: " + comment.text + 
            " with Author: " + comment.author.name + 
            " posted on time :" + str(comment.created_time) + "\n")
```


## **Megjegyzések válaszolása**
A szülő megjegyzés a hierarchia legfelső vagy eredeti megjegyzése a megjegyzések vagy válaszok között. A `parent_comment` tulajdonság (a [Comment](https://reference.aspose.com/slides/hu/python-net/aspose.slides/comment/) osztályból) használatával beállíthat vagy lekérdezhet egy szülő megjegyzést. 

Ez a Python kód bemutatja, hogyan lehet megjegyzéseket hozzáadni és válaszokat kapni rájuk:

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

with slides.Presentation() as pres:
    # Megjegyzést ad hozzá
    author1 = pres.comment_authors.add_author("Author_1", "A.A.")
    comment1 = author1.comments.add_comment("comment1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    # Válasz hozzáadása comment1-hez
    author2 = pres.comment_authors.add_author("Autror_2", "B.B.")
    reply1 = author2.comments.add_comment("reply 1 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply1.parent_comment = comment1

    # Másik válasz hozzáadása comment1-hez
    reply2 = author2.comments.add_comment("reply 2 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply2.parent_comment = comment1

    # Válasz hozzáadása meglévő válaszhoz
    subReply = author1.comments.add_comment("subreply 3 for reply 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    subReply.parent_comment = reply2

    comment2 = author2.comments.add_comment("comment 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    comment3 = author2.comments.add_comment("comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    reply3 = author1.comments.add_comment("reply 4 for comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply3.parent_comment = comment3

    # Kiírja a megjegyzések hierarchiáját a konzolra
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

    # Eltávolítja a comment1-et és az összes rá adott választ
    comment1.remove()

    pres.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Attention" %}} 

* Amikor a `remove` metódust (a [Comment](https://reference.aspose.com/slides/hu/python-net/aspose.slides/comment/) osztályból) használják egy megjegyzés törlésére, a megjegyzésre adott válaszok is törlésre kerülnek. 
* Ha a `parent_comment` beállítás körkörös hivatkozást eredményez, `PptxEditException` lesz dobva.

{{% /alert %}}

## **Modern megjegyzés hozzáadása**

2021-ben a Microsoft bevezette a *modern megjegyzéseket* a PowerPointban. A modern megjegyzések funkció jelentősen javítja az együttműködést a PowerPointban. A modern megjegyzéseken keresztül a PowerPoint felhasználók könnyebben oldhatják meg a megjegyzéseket, rögzíthetik azokat objektumokhoz és szövegekhez, és sokkal egyszerűbben léphetnek interakcióba.

A modern megjegyzések támogatását a [ModernComment](https://reference.aspose.com/slides/hu/python-net/aspose.slides/moderncomment/) osztály hozzáadásával valósítottuk meg. A `add_modern_comment` és `insert_modern_comment` metódusok a [CommentCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/commentcollection/) osztályhoz lettek hozzáadva. 

Ez a Python kód megmutatja, hogyan lehet modern megjegyzést hozzáadni egy diához egy PowerPoint prezentációban:

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as pres:
    newAuthor = pres.comment_authors.add_author("Some Author", "SA")
    modernComment = newAuthor.comments.add_modern_comment("This is a modern comment", pres.slides[0], None, draw.PointF(100, 100), date.today())

    pres.save("example.pptx", slides.export.SaveFormat.PPTX)
```

## **Megjegyzés eltávolítása**

### **Minden megjegyzés és szerző törlése**

Ez a Python kód megmutatja, hogyan lehet eltávolítani az összes megjegyzést és szerzőt egy prezentációból:

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    # Törli az összes megjegyzést a prezentációból
    for author in presentation.comment_authors:
        author.comments.clear()

    # Törli az összes szerzőt
    presentation.comment_authors.clear()

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Kijelölt megjegyzések törlése**

Ez a Python kód megmutatja, hogyan lehet egy dián specifikus megjegyzéseket törölni:

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    # hozzáadja a megjegyzéseket...
    author = presentation.comment_authors.add_author("Author", "A")
    author.comments.add_comment("comment 1", slide, draw.PointF(0.2, 0.2), date.today())
    author.comments.add_comment("comment 2", slide, draw.PointF(0.3, 0.2), date.today())
    
    # eltávolítja az összes megjegyzést, amely a "comment 1" szöveget tartalmazza
    for commentAuthor in presentation.comment_authors:
        toRemove = []
        for comment in slide.get_slide_comments(commentAuthor):
            if comment.text == "comment 1":
                toRemove.append(comment)
        
        for comment in toRemove:
            commentAuthor.comments.remove(comment)
    
    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Támogatja az Aspose.Slides a 'megoldva' állapotot a modern megjegyzéseknél?**

Igen. A [Modern comments](https://reference.aspose.com/slides/hu/python-net/aspose.slides/moderncomment/) egy [status](https://reference.aspose.com/slides/hu/python-net/aspose.slides/moderncomment/status/) tulajdonságot biztosít; olvashatja és beállíthatja egy [megjegyzés állapotát](https://reference.aspose.com/slides/hu/python-net/aspose.slides/moderncommentstatus/) (például megjelölheti megoldottként), és ez az állapot a fájlban tárolódik, valamint a PowerPoint felismeri.

**Támogatottak a szálas beszélgetések (válaszkövetés), és van-e beágyazási korlát?**

Igen. Minden megjegyzés hivatkozhat a saját [parent comment](https://reference.aspose.com/slides/hu/python-net/aspose.slides/moderncomment/parent_comment/) elemére, lehetővé téve tetszőleges válaszkövetéseket. Az API nem határoz meg konkrét beágyazási mélységkorlátot.

**Milyen koordináta rendszerben határozzák meg a megjegyzés jelölő pozícióját a dián?**

A pozíció lebegőpontos pontként kerül tárolásra a dia koordináta rendszerében. Ez lehetővé teszi, hogy a megjegyzés jelölőt pontosan oda helyezze, ahol szüksége van.