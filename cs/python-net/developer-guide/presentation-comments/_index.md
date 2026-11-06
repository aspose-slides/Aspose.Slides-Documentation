---
title: Správa komentářů v prezentaci v Pythonu
linktitle: Komentáře prezentace
type: docs
weight: 100
url: /cs/python-net/presentation-comments/
keywords:
- komentář
- moderní komentář
- komentáře PowerPoint
- komentáře v prezentaci
- komentáře snímků
- přidat komentář
- přístup k komentáři
- upravit komentář
- odpověď na komentář
- odstranit komentář
- smazat komentář
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Spravujte komentáře v prezentaci pomocí Aspose.Slides pro Python prostřednictvím .NET: přidávejte, čtěte, upravujte, odpovídejte na a odstraňujte komentáře v prezentacích PowerPoint."
---
## **Přehled**

Tento článek vysvětluje, jak spravovat komentáře v prezentaci pomocí Aspose.Slides pro Python prostřednictvím .NET. Představuje hlavní typy související s komentáři a ukazuje, jak přidávat komentáře do snímků, přistupovat k existujícím komentářům, pracovat s odpověďmi a moderními komentáři a odstraňovat komentáře z prezentace.

Příklady pokrývají běžné scénáře revize a spolupráce v PowerPointu, jako je přiřazení komentářů autorům, čtení textu a metadat komentáře, vytváření řetězců odpovědí a odstraňování vybraných nebo všech komentářů.

V PowerPointu se komentáře zobrazují jako anotace na snímcích. Výběrem komentáře se zobrazí jeho text a související diskuse.

Chcete-li požadovat, aby se komentáře při otevření prezentace zobrazily nebo skryly, aniž byste měnili samotné komentáře, viz [Zobrazit nebo skrýt komentáře při otevření prezentace](/slides/cs/python-net/presentation-view-properties/).

## **Proč přidávat komentáře do prezentací?**

Můžete použít komentáře k poskytování zpětné vazby a spolupráci s kolegy při revizi prezentací.

Aspose.Slides pro Python prostřednictvím .NET poskytuje následující API pro práci s komentáři:

* Třída [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), která poskytuje přístup k autorům komentářů v prezentaci.
* Třída [CommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/), která představuje komentáře spojené s jednotlivým autorem.
* Třída [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/), která poskytuje informace o komentáři, včetně autora, času vytvoření, pozice a textu.
* Třída [CommentAuthor](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/), která poskytuje informace o autorovi, včetně jména, iniciál a souvisejících komentářů.

## **Přidání komentářů do snímků**

Příklad vytvoří dva snímky a zaregistruje autora komentáře pomocí [add_author](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/add_author/). Použije [add_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_comment/) k umístění jednoho komentáře na každý snímek, poté získá komentáře prvního snímku pro tohoto autora pomocí [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/). Konzole zobrazí text prvního komentáře dvakrát, což demonstruje přístup jak přes snímek, tak přes autora, a uložená prezentace obsahuje oba komentáře.

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])

    author = presentation.comment_authors.add_author("Jawad", "MF")
    position = slides.PointF(0.2, 0.2)
    created_time = datetime.now()

    author.comments.add_comment("Hello Jawad, this is a slide comment", first_slide, position, created_time)
    author.comments.add_comment("Hello Jawad, this is the second slide comment", second_slide, position, created_time)

    comments = first_slide.get_slide_comments(author)
    if len(comments) > 0:
        first_comment = comments[0]
        print(first_comment.text)

        comment_text = first_comment.author.comments[0].text
        print(comment_text)

    presentation.save("Comments_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Najít nebo vytvořit autora komentáře**

Když automatizovaná revize opakovaně zpracovává stejnou prezentaci, před přidáním autora prohledejte její kolekci [comment_authors](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/comment_authors/). Metoda [find_by_name_and_initials](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/find_by_name_and_initials/) porovnává jak jméno, tak iniciály a vrací pole odpovídajících autorů, nebo prázdné pole, pokud žádná shoda neexistuje. Naopak [find_by_name](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/find_by_name/) hledá jen podle jména, nezávisle na iniciálách. Volání [add_author](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/add_author/) se jménem a iniciálami, které již v kolekci existují, vyvolá výjimku.

Příklad vyžaduje soubor prezentace s alespoň jedním snímkem. Během dvou průchodů znovu použije prvního shodného autora nebo vytvoří nového jen když je výsledek prázdný. Pokud existuje více shod, vybere první prvek pole bez slučování nebo odstraňování ostatních autorů. Poté zavolá [add_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_comment/) pro vybraného autora a uloží prezentaci. Druhý průchod otevře výstup první iterace a operaci zopakuje.

```python
from datetime import datetime

import aspose.slides as slides

author_name = "Reviewer"
author_initials = "RV"

input_file = "input.pptx"
position = slides.PointF(20, 20)

for pass_number in range(1, 3):
    with slides.Presentation(input_file) as presentation:
        matches = presentation.comment_authors.find_by_name_and_initials(author_name, author_initials)

        author = matches[0] if len(matches) > 0 else presentation.comment_authors.add_author(author_name, author_initials)
        author.comments.add_comment("Please review this slide.", presentation.slides[0], position, datetime.now())

        output_file = f"review_pass_{pass_number}.pptx"
        presentation.save(output_file, slides.export.SaveFormat.PPTX)
        input_file = output_file
```

Druhý průchod přidá další komentář, aniž by přidal nového autora nebo odstranil existující komentáře. Výsledný soubor `review_pass_2.pptx` obsahuje oba nové komentáře vedle všech původních. Opětovné použití autora neodstraňuje duplicitní komentáře: pro zabránění opakovanému přidávání stejného komentáře implementujte samostatnou detekci duplicit před jeho přidáním.

## **Přístup ke komentářům snímků**

Příklad otevře existující prezentaci a načte její kolekci [comment_authors](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/comment_authors/). Pro každého autora iteruje přes [comments](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/comments/) a vypíše číslo snímku, text komentáře, jméno autora a čas vytvoření. Vstupní prezentace musí obsahovat komentáře, aby byl generován výstup do konzole.

```python
import aspose.slides as slides

with slides.Presentation("Comments1.pptx") as presentation:
    for author in presentation.comment_authors:
        for comment in author.comments:
            print("Slide: " + str(comment.slide.slide_number))
            print("Comment: " + comment.text)
            print("Author: " + comment.author.name)
            print("Posted at: " + str(comment.created_time))
            print()
```

## **Odpovědi na komentáře**

Rodičovský komentář je původní komentář na vrcholu hierarchie odpovědí. Vlastnost [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) třídy [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) umožňuje získat nebo nastavit rodiče komentáře.

Příklad vytvoří komentáře od dvou autorů a použije [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) k vytvoření řetězců odpovědí, včetně odpovědi na další odpověď. Předání `None` metodě [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/) načte komentáře ze všech autorů; konzole odsazuje každý záznam podle jeho hloubky v hierarchii odpovědí. Příklad uloží kompletní diskusi, zavolá [remove](https://reference.aspose.com/slides/python-net/aspose.slides/comment/remove/) na první kořenový komentář a uloží druhou prezentaci, ve které jsou tento komentář a jeho odpovědi odstraněny.

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    position = slides.PointF(10, 10)
    created_time = datetime.now()

    original_author = presentation.comment_authors.add_author("Author_1", "A.A.")
    root_comment = original_author.comments.add_comment("comment 1", slide, position, created_time)

    reviewer = presentation.comment_authors.add_author("Author_2", "B.B.")
    first_reply = reviewer.comments.add_comment("reply 1 for comment 1", slide, position, created_time)
    first_reply.parent_comment = root_comment

    second_reply = reviewer.comments.add_comment("reply 2 for comment 1", slide, position, created_time)
    second_reply.parent_comment = root_comment

    sub_reply = original_author.comments.add_comment("subreply 3 for reply 2", slide, position, created_time)
    sub_reply.parent_comment = second_reply

    reviewer.comments.add_comment("comment 2", slide, position, created_time)
    separate_comment = reviewer.comments.add_comment("comment 3", slide, position, created_time)

    separate_reply = original_author.comments.add_comment("reply 4 for comment 3", slide, position, created_time)
    separate_reply.parent_comment = separate_comment

    comments = slide.get_slide_comments(None)
    for current_comment in comments:
        comment = current_comment
        while comment.parent_comment is not None:
            print("\t", end="")
            comment = comment.parent_comment

        print(current_comment.author.name + ": " + current_comment.text)

    presentation.save("parent_comment.pptx", slides.export.SaveFormat.PPTX)

    root_comment.remove()
    presentation.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}
* Když je metoda [remove](https://reference.aspose.com/slides/python-net/aspose.slides/comment/remove/) třídy [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) použita k odstranění komentáře, jsou také odstraněny všechny odpovědi na tento komentář.
* Pokud vlastnost [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) vytvoří kruhový odkaz, je vyvolána výjimka [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Přidání moderních komentářů**

Moderní komentáře mohou být přiřazeny samotnému snímku, konkrétnímu tvaru nebo textovému rozsahu uvnitř AutoShape. Metoda [CommentCollection.add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) přijímá argument [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) navíc k snímku a souřadnicím ukazatele komentáře.

Když je pro argument shape předáno `None`, jedná se o komentář úrovně snímku. Jeho ukazatel je umístěn podle zadaných souřadnic, ale není spojen s konkrétním tvarem, takže [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/) vrací `None`. Když je předán [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/), je komentář ukotven k tomuto tvaru. Souřadnice i nadále určují pozici ukazatele komentáře na snímku, zatímco asociaci s tvarem lze získat přes [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/).

### **Ukotvení moderního komentáře k objektu Shape**

Příklad dvakrát zavolá [add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/): jednou s tvarem `None` pro komentář úrovně snímku a podruhé s obdélníkem jako kotvou. Čtení [shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/) vypíše `True` pro kontrolu null u komentáře úrovně snímku a `Revenue title` pro ukotvený komentář. Oba komentáře jsou uloženy v prezentaci.

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    author = presentation.comment_authors.add_author("Reviewer", "RV")

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 300, 80)
    shape.name = "Revenue title"
    shape.text_frame.text = "Quarterly revenue"

    created_time = datetime.now()
    slide_comment_position = slides.PointF(20, 20)
    shape_comment_position = slides.PointF(60, 60)
    slide_comment = author.comments.add_modern_comment("Review the overall slide layout.", slide, None, slide_comment_position, created_time)
    shape_comment = author.comments.add_modern_comment("Check this title.", slide, shape, shape_comment_position, created_time)

    print(slide_comment.shape is None)
    print(shape_comment.shape.name)

    presentation.save("modern_comments.pptx", slides.export.SaveFormat.PPTX)
```

### **Ukotvení komentářů k různým typům Shape**

Jakýkoli objekt snímku odvozený od [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) může být použit jako kotva. Běžné příklady zahrnují [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/python-net/aspose.slides/connector/) a instance [GraphicalObject](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobject/) jako jsou grafy.

Příklad použije [add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) k přiřazení komentáře každému z pěti typů tvarů: AutoShape, rámec obrázku, skupina, spojovací prvek a graf. Obrázek používá vložená data obrázku, takže není vyžadován externí obrázek. Každý komentář má svou pozici ukazatele a uložená prezentace si zachová všech pět asociací s tvary.

```python
import base64
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    author = presentation.comment_authors.add_author("Reviewer", "RV")
    created_time = datetime.now()

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 180, 60)
    auto_shape.text_frame.text = "AutoShape"

    auto_shape_comment_position = slides.PointF(30, 30)
    author.comments.add_modern_comment("Comment on an AutoShape.", slide, auto_shape, auto_shape_comment_position, created_time)

    image_base64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg=="
    image_data = base64.b64decode(image_base64)
    image = presentation.images.add_image(image_data)
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 220, 20, 120, 80, image)
    picture_comment_position = slides.PointF(230, 30)
    author.comments.add_modern_comment("Comment on a picture.", slide, picture_frame, picture_comment_position, created_time)

    group_shape = slide.shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 80, 40)
    group_shape.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 100, 0, 80, 40)
    group_comment_position = slides.PointF(40, 150)
    author.comments.add_modern_comment("Comment on a group.", slide, group_shape, group_comment_position, created_time)

    connector = slide.shapes.add_connector(slides.ShapeType.STRAIGHT_CONNECTOR1, 220, 150, 140, 40)
    connector_comment_position = slides.PointF(240, 150)
    author.comments.add_modern_comment("Comment on a connector.", slide, connector, connector_comment_position, created_time)

    chart = slide.shapes.add_chart(slides.charts.ChartType.CLUSTERED_COLUMN, 400, 20, 250, 180)
    chart_comment_position = slides.PointF(420, 40)
    author.comments.add_modern_comment("Comment on a graphical object.", slide, chart, chart_comment_position, created_time)

    presentation.save("modern_comment_shape_types.pptx", slides.export.SaveFormat.PPTX)
```

### **Ukotvení komentáře k textu a nastavení jeho stavu**

U moderního komentáře spojeného s [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) určuje [ModernComment.text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/) počáteční pozici vybraného textu v textovém rámečku tvaru, zatímco [ModernComment.text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) udává délku výběru. Tyto vlastnosti společně asociují komentář s konkrétním textovým rozsahem uvnitř AutoShape.

Vlastnost [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) lze číst nebo aktualizovat hodnotou z výčtu [ModernCommentStatus](https://reference.aspose.com/slides/python-net/aspose.slides/moderncommentstatus/):

- `NOT_DEFINED` — není definován žádný konkrétní stav moderního komentáře.
- `ACTIVE` — komentář je aktivní.
- `RESOLVED` — komentář byl vyřešen.
- `CLOSED` — komentář je uzavřen.

Příklad ukotví moderní komentář k slovům „quarterly revenue“ v textu obdélníku. Vypočítá nulově indexovaný [text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/) z textu a nastaví [text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) na počet vybraných znaků. Po nastavení [status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) na `RESOLVED` prezentaci uloží a znovu otevře. Čtyři kontroly v konzoli by měly každá vypsat `True`, čímž potvrdí zachování ukotvení tvaru, textového rozsahu a stavu.

```python
from datetime import datetime

import aspose.slides as slides

output_file = "modern_comment_text_anchor.pptx"
shape_text = "Review the quarterly revenue forecast."
selected_text = "quarterly revenue"
expected_selection_start = shape_text.index(selected_text)

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 400, 100)
    shape.name = "Forecast text"
    shape.text_frame.text = shape_text

    author = presentation.comment_authors.add_author("Reviewer", "RV")
    comment_position = slides.PointF(60, 60)
    comment = author.comments.add_modern_comment("Verify this forecast wording.", slide, shape, comment_position, datetime.now())
    comment.text_selection_start = expected_selection_start
    comment.text_selection_length = len(selected_text)
    comment.status = slides.ModernCommentStatus.RESOLVED

    presentation.save(output_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(output_file) as reopened_presentation:
    reopened_slide = reopened_presentation.slides[0]
    reopened_comments = reopened_slide.get_slide_comments(None)

    for reopened_comment in reopened_comments:
        if not isinstance(reopened_comment, slides.ModernComment):
            continue

        shape_matches = reopened_comment.shape.name == "Forecast text"
        selection_start_matches = reopened_comment.text_selection_start == expected_selection_start
        selection_length_matches = reopened_comment.text_selection_length == len(selected_text)
        status_matches = reopened_comment.status == slides.ModernCommentStatus.RESOLVED

        print("Shape anchor preserved: " + str(shape_matches))
        print("Text selection start preserved: " + str(selection_start_matches))
        print("Text selection length preserved: " + str(selection_length_matches))
        print("Resolved status preserved: " + str(status_matches))
```

### **Prozkoumání existujících moderních komentářů**

Příklad vyžaduje existující prezentaci obsahující moderní komentáře a vypíše jejich text, stav a podrobnosti o ukotvení. Pro zkoumání zjistěte, které komentáře jsou instance [ModernComment](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/), poté prozkoumejte [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/), [ModernComment.text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/), [ModernComment.text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) a [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/). `None` tvar indikuje komentář úrovně snímku. Pro ukotvení k [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) vlastnosti výběru textu identifikují související rozsah v textovém rámečku tvaru.

```python
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    for slide in presentation.slides:
        comments = slide.get_slide_comments(None)
        for comment in comments:
            if not isinstance(comment, slides.ModernComment):
                continue

            print("Slide: " + str(slide.slide_number))
            print("Text: " + comment.text)
            print("Status: " + str(comment.status))

            shape = comment.shape
            if shape is None:
                print("Anchor: slide level")
            else:
                print("Anchor shape: " + shape.name)
                print("Anchor type: " + type(shape).__name__)

                if isinstance(shape, slides.AutoShape):
                    print("Text selection start: " + str(comment.text_selection_start))
                    print("Text selection length: " + str(comment.text_selection_length))

            print()
```

## **Odstranění komentářů**

Aspose.Slides pro Python prostřednictvím .NET umožňuje odstranit všechny komentáře a jejich autory z prezentace nebo smazat vybrané komentáře a zachovat ostatní. Následující příklady ukazují oba přístupy a ukládají aktualizovanou prezentaci.

### **Odstranění všech komentářů a jejich autorů**

Příklad otevře existující prezentaci a zavolá [CommentCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/clear/) pro každého autora, poté použije [CommentAuthorCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/clear/) k odstranění samotných autorů. Uložená prezentace neobsahuje ani komentáře, ani jejich autory. Použijte prezentaci obsahující komentáře, abyste viděli odstranění.

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    for author in presentation.comment_authors:
        author.comments.clear()

    presentation.comment_authors.clear()

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Odstranění konkrétních komentářů**

Příklad vytvoří dva komentáře na jednom snímku a použije [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/) k nalezení komentářů od každého autora. Shromáždí komentáře, jejichž text je roven „comment 1“, před voláním [CommentCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/remove/), čímž se vyhne změnám kolekce během výběru. Uložená prezentace zachová jen „comment 2“.

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    author = presentation.comment_authors.add_author("Author", "A")
    created_time = datetime.now()

    first_comment_position = slides.PointF(0.2, 0.2)
    second_comment_position = slides.PointF(0.3, 0.2)
    author.comments.add_comment("comment 1", slide, first_comment_position, created_time)
    author.comments.add_comment("comment 2", slide, second_comment_position, created_time)

    for comment_author in presentation.comment_authors:
        comments_to_remove = []
        comments = slide.get_slide_comments(comment_author)

        for comment in comments:
            if comment.text == "comment 1":
                comments_to_remove.append(comment)

        for comment in comments_to_remove:
            comment_author.comments.remove(comment)

    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Často kladené otázky**

**Podporuje Aspose.Slides stav vyřešen pro moderní komentáře?**

Ano. [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) lze číst a nastavit hodnotou z [ModernCommentStatus](https://reference.aspose.com/slides/python-net/aspose.slides/moderncommentstatus/), včetně `RESOLVED`. Stav je uložen v prezentaci a může být po opětovném otevření souboru znovu načten.

**Jsou podporovány vlákna diskusí (řetězce odpovědí) a existuje limit hloubky?**

Ano. Každý komentář může odkazovat na svůj [parent comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/), což umožňuje řetězce odpovědí. API nedefinuje konkrétní limit hloubky vnoření.

**V jakém souřadnicovém systému je definována pozice markeru komentáře na snímku?**

Pozice markeru je definována pomocí souřadnic s desetinnou čárkou v souřadnicovém systému snímku, což umožňuje přesné umístění na snímku.