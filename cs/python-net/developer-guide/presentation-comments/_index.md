---
title: Správa komentářů prezentací v Pythonu
linktitle: Komentáře k prezentaci
type: docs
weight: 100
url: /cs/python-net/presentation-comments/
keywords:
- komentář
- moderní komentář
- komentáře PowerPoint
- komentáře prezentace
- komentáře snímku
- přidat komentář
- přístup k komentáři
- upravit komentář
- odpovědět na komentář
- odstranit komentář
- smazat komentář
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Spravovat komentáře v prezentacích pomocí Aspose.Slides pro Python prostřednictvím .NET: přidávat, číst, upravovat, odpovídat a odstraňovat komentáře v prezentacích PowerPoint."
---
## **Přehled**

Tento článek vysvětluje, jak spravovat komentáře v prezentaci pomocí Aspose.Slides pro Python prostřednictvím .NET. Představuje hlavní typy související s komentáři a ukazuje, jak přidávat komentáře do snímků, přistupovat k existujícím komentářům, pracovat s odpověďmi a moderními komentáři a odstraňovat komentáře z prezentace.

Příklady pokrývají běžné scénáře revize a spolupráce v PowerPointu, jako je přiřazování komentářů autorům, čtení textu a metadat komentářů, tvorba řetězců odpovědí a odstraňování vybraných nebo všech komentářů.

V PowerPointu se komentáře zobrazují jako anotace na snímcích. Výběr komentáře zobrazí jeho text a související diskusi.

Pro požadavek, aby se při otevírání prezentace zobrazovaly nebo skrývaly komentáře bez změny samotných komentářů, viz [Show or Hide Comments When Opening a Presentation](/slides/cs/python-net/presentation-view-properties/).

## **Proč přidávat komentáře do prezentací?**

Komentáře můžete použít k poskytování zpětné vazby a spolupráci s kolegy při revizi prezentací.

Aspose.Slides pro Python prostřednictvím .NET poskytuje následující API pro práci s komentáři:

* Třída [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) poskytuje přístup k autorům komentářů prezentace.
* Třída [CommentCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/commentcollection/) představuje komentáře přiřazené konkrétnímu autorovi.
* Třída [Comment](https://reference.aspose.com/slides/cs/python-net/aspose.slides/comment/) poskytuje informace o komentáři, včetně autora, času vytvoření, pozice a textu.
* Třída [CommentAuthor](https://reference.aspose.com/slides/cs/python-net/aspose.slides/commentauthor/) poskytuje informace o autorovi, včetně jména, iniciál a přiřazených komentářů.

## **Přidat komentáře ke snímkům**

Následující příklad ukazuje, jak přidat komentáře ke snímkům v PowerPoint prezentaci:

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])
    author = presentation.comment_authors.add_author("Jawad", "MF")
    position = draw.PointF(0.2, 0.2)
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

## **Přístup ke komentářům na snímcích**

Následující příklad ukazuje, jak přistupovat k existujícím komentářům v PowerPoint prezentaci:

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

Rodičovský komentář je původní komentář v horní části hierarchie odpovědí. Vlastnost [parent_comment](https://reference.aspose.com/slides/cs/python-net/aspose.slides/comment/parent_comment/) třídy [Comment](https://reference.aspose.com/slides/cs/python-net/aspose.slides/comment/) umožňuje získat nebo nastavit rodiče komentáře.

Následující příklad ukazuje, jak přidat odpovědi a prozkoumat vzniklou hierarchii komentářů:

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    position = draw.PointF(10, 10)
    created_time = datetime.now()

    author1 = presentation.comment_authors.add_author("Author_1", "A.A.")
    comment1 = author1.comments.add_comment("comment 1", slide, position, created_time)

    author2 = presentation.comment_authors.add_author("Author_2", "B.B.")
    reply1 = author2.comments.add_comment("reply 1 for comment 1", slide, position, created_time)
    reply1.parent_comment = comment1

    reply2 = author2.comments.add_comment("reply 2 for comment 1", slide, position, created_time)
    reply2.parent_comment = comment1

    sub_reply = author1.comments.add_comment("subreply 3 for reply 2", slide, position, created_time)
    sub_reply.parent_comment = reply2

    author2.comments.add_comment("comment 2", slide, position, created_time)
    comment3 = author2.comments.add_comment("comment 3", slide, position, created_time)

    reply3 = author1.comments.add_comment("reply 4 for comment 3", slide, position, created_time)
    reply3.parent_comment = comment3

    comments = slide.get_slide_comments(None)
    for current_comment in comments:
        comment = current_comment
        while comment.parent_comment is not None:
            print("\t", end="")
            comment = comment.parent_comment

        print(current_comment.author.name + ": " + current_comment.text)

    presentation.save("parent_comment.pptx", slides.export.SaveFormat.PPTX)

    comment1.remove()
    presentation.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}
* Když je metoda [remove](https://reference.aspose.com/slides/cs/python-net/aspose.slides/comment/remove/) třídy [Comment](https://reference.aspose.com/slides/cs/python-net/aspose.slides/comment/) použita k odstranění komentáře, jsou také smazány všechny odpovědi na tento komentář.
* Pokud vlastnost [parent_comment](https://reference.aspose.com/slides/cs/python-net/aspose.slides/comment/parent_comment/) vytvoří kruhový odkaz, je vyvolána výjimka [PptxEditException](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Přidat moderní komentáře**

Moderní komentáře lze přiřadit samotnému snímku, konkrétnímu tvaru nebo textovému rozsahu uvnitř AutoShape. Metoda [CommentCollection.add_modern_comment](https://reference.aspose.com/slides/cs/python-net/aspose.slides/commentcollection/add_modern_comment/) přijímá argument [Shape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/) kromě snímku a souřadnic značky komentáře.

Když je jako argument tvaru předáno `None`, jedná se o komentář na úrovni snímku. Jeho značka je umístěna podle zadaných souřadnic, ale není přiřazena konkrétnímu tvaru, takže [ModernComment.shape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/moderncomment/shape/) vrací `None`. Když je poskytnut [Shape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/), je komentář ukotven k tomuto tvaru. Souřadnice nadále určují pozici značky komentáře na snímku, zatímco přiřazení tvaru lze získat pomocí [ModernComment.shape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/moderncomment/shape/).

### **Ukotvit moderní komentář k tvaru**

Následující příklad vytvoří jak moderní komentář na úrovni snímku, tak moderní komentář ukotvený k určitému AutoShape. Pak načte přiřazený tvar z každého komentáře.

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    author = presentation.comment_authors.add_author("Reviewer", "RV")
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 300, 80)
    shape.name = "Revenue title"
    shape.text_frame.text = "Quarterly revenue"

    created_time = datetime.now()
    slide_comment_position = draw.PointF(20, 20)
    shape_comment_position = draw.PointF(60, 60)
    slide_comment = author.comments.add_modern_comment("Review the overall slide layout.", slide, None, slide_comment_position, created_time)
    shape_comment = author.comments.add_modern_comment("Check this title.", slide, shape, shape_comment_position, created_time)

    print(slide_comment.shape is None)
    print(shape_comment.shape.name)

    presentation.save("modern_comments.pptx", slides.export.SaveFormat.PPTX)
```

### **Ukotvit komentáře k různým typům tvarů**

Jakýkoli objekt snímku odvozený od [Shape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/) může být použit jako ukotvení tvaru. Běžné příklady zahrnují [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/cs/python-net/aspose.slides/connector/) a [GraphicalObject](https://reference.aspose.com/slides/cs/python-net/aspose.slides/graphicalobject/) jako jsou například grafy.

Následující příklad vytvoří několik běžných typů tvarů a přiřadí k nim moderní komentář.

```python
import base64
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    author = presentation.comment_authors.add_author("Reviewer", "RV")
    created_time = datetime.now()

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 180, 60)
    auto_shape.text_frame.text = "AutoShape"
    auto_shape_comment_position = draw.PointF(30, 30)
    author.comments.add_modern_comment("Comment on an AutoShape.", slide, auto_shape, auto_shape_comment_position, created_time)

    image_base64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg=="
    image_data = base64.b64decode(image_base64)
    image = presentation.images.add_image(image_data)
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 220, 20, 120, 80, image)
    picture_comment_position = draw.PointF(230, 30)
    author.comments.add_modern_comment("Comment on a picture.", slide, picture_frame, picture_comment_position, created_time)

    group_shape = slide.shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 80, 40)
    group_shape.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 100, 0, 80, 40)
    group_comment_position = draw.PointF(40, 150)
    author.comments.add_modern_comment("Comment on a group.", slide, group_shape, group_comment_position, created_time)

    connector = slide.shapes.add_connector(slides.ShapeType.STRAIGHT_CONNECTOR1, 220, 150, 140, 40)
    connector_comment_position = draw.PointF(240, 150)
    author.comments.add_modern_comment("Comment on a connector.", slide, connector, connector_comment_position, created_time)

    chart = slide.shapes.add_chart(slides.charts.ChartType.CLUSTERED_COLUMN, 400, 20, 250, 180)
    chart_comment_position = draw.PointF(420, 40)
    author.comments.add_modern_comment("Comment on a graphical object.", slide, chart, chart_comment_position, created_time)

    presentation.save("modern_comment_shape_types.pptx", slides.export.SaveFormat.PPTX)
```

### **Ukotvit komentář k textu a nastavit jeho stav**

Pro moderní komentář přiřazený k [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/) specifikuje [ModernComment.text_selection_start](https://reference.aspose.com/slides/cs/python-net/aspose.slides/moderncomment/text_selection_start/) počáteční pozici vybraného textu v textovém rámci tvaru, zatímco [ModernComment.text_selection_length](https://reference.aspose.com/slides/cs/python-net/aspose.slides/moderncomment/text_selection_length/) určuje délku výběru. Společně tyto vlastnosti přiřazují komentář konkrétnímu textovému rozsahu uvnitř AutoShape.

Vlastnost [ModernComment.status](https://reference.aspose.com/slides/cs/python-net/aspose.slides/moderncomment/status/) lze číst nebo aktualizovat hodnotou z výčtu [ModernCommentStatus](https://reference.aspose.com/slides/cs/python-net/aspose.slides/moderncommentstatus/):

- `NOT_DEFINED` — není definován žádný konkrétní stav moderního komentáře.
- `ACTIVE` — komentář je aktivní.
- `RESOLVED` — komentář byl vyřešen.
- `CLOSED` — komentář je uzavřen.

Následující příklad vytvoří moderní komentář ukotvený k tvaru, přiřadí ho k výběru textu, označí jej jako vyřešený, uloží prezentaci a po opětovném otevření souboru ověří hodnoty.

```python
from datetime import datetime

import aspose.pydrawing as draw
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
    comment_position = draw.PointF(60, 60)
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

### **Prozkoumat existující moderní komentáře**

Pro prozkoumání existující prezentace zjistěte, které komentáře jsou instance [ModernComment](https://reference.aspose.com/slides/cs/python-net/aspose.slides/moderncomment/), poté zkontrolujte [ModernComment.shape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/moderncomment/shape/), [ModernComment.text_selection_start](https://reference.aspose.com/slides/cs/python-net/aspose.slides/moderncomment/text_selection_start/), [ModernComment.text_selection_length](https://reference.aspose.com/slides/cs/python-net/aspose.slides/moderncomment/text_selection_length/) a [ModernComment.status](https://reference.aspose.com/slides/cs/python-net/aspose.slides/moderncomment/status/). Tvar `None` indikuje komentář na úrovni snímku. Pro ukotvení na [AutoShape] identifikují vlastnosti výběru textu přiřazený rozsah v textovém rámci tvaru.

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

## **Odstranit komentáře**

### **Odstranit všechny komentáře a autory komentářů**

Následující příklad ukazuje, jak odstranit všechny komentáře a autory komentářů z prezentace:

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    for author in presentation.comment_authors:
        author.comments.clear()

    presentation.comment_authors.clear()
    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Odstranit konkrétní komentáře**

Následující příklad ukazuje, jak odstranit konkrétní komentáře ze snímku:

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    author = presentation.comment_authors.add_author("Author", "A")
    created_time = datetime.now()

    first_comment_position = draw.PointF(0.2, 0.2)
    second_comment_position = draw.PointF(0.3, 0.2)
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

**Podporuje Aspose.Slides stav resolved pro moderní komentáře?**

Ano. [ModernComment.status](https://reference.aspose.com/slides/cs/python-net/aspose.slides/moderncomment/status/) lze číst a nastavit pomocí hodnoty z výčtu [ModernCommentStatus](https://reference.aspose.com/slides/cs/python-net/aspose.slides/moderncommentstatus/), včetně `RESOLVED`. Stav je uložen v prezentaci a lze jej znovu načíst po opětovném otevření souboru.

**Jsou podporovány vláknové diskuse (řetězce odpovědí) a existuje omezení hloubky vnoření?**

Ano. Každý komentář může odkazovat na svůj [parent comment](https://reference.aspose.com/slides/cs/python-net/aspose.slides/comment/parent_comment/), což umožňuje řetězce odpovědí. API nedefinuje konkrétní limit hloubky vnoření.

**V jakém souřadnicovém systému je definována pozice značky komentáře na snímku?**

Pozice značky je definována pomocí desetinných souřadnic v souřadnicovém systému snímku, což umožňuje její přesné umístění na snímku.