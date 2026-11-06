---
title: Správa komentářů v prezentaci v Pythonu přes Java
linktitle: Komentáře k prezentaci
type: docs
weight: 100
url: /cs/python-java/presentation-comments/
keywords:
- komentář
- moderní komentář
- komentáře PowerPoint
- komentáře prezentace
- komentáře snímku
- přidat komentář
- přístup ke komentáři
- upravit komentář
- odpovědět na komentář
- odebrat komentář
- smazat komentář
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Spravujte komentáře v prezentacích pomocí Aspose.Slides pro Python přes Java: přidávejte, čtěte, upravujte, odpovídejte a odstraňujte komentáře v prezentacích PowerPoint rychle a jednoduše."
---
## **Přehled**

Tento článek vysvětluje, jak spravovat komentáře v prezentaci pomocí Aspose.Slides pro Python přes Java. Představuje hlavní typy související s komentáři a ukazuje, jak přidávat komentáře ke snímkům, přistupovat k existujícím komentářům, pracovat s odpověďmi a moderními komentáři a odstraňovat komentáře z prezentace.

Příklady pokrývají běžné scénáře revize a spolupráce v PowerPointu, jako je přiřazování komentářů autorům, čtení textu komentáře a metadat, vytváření řetězců odpovědí a odstraňování vybraných komentářů nebo všech komentářů.

V PowerPointu se komentáře zobrazují jako poznámky na snímcích. Výběr komentáře zobrazí jeho text a související diskusi.

Chcete-li požádat, aby se při otevření prezentace zobrazily nebo skryly komentáře, aniž byste měnili samotné komentáře, viz [Zobrazit nebo skrýt komentáře při otevírání prezentace](/slides/cs/python-java/presentation-view-properties/).

## **Proč přidávat komentáře do prezentací?**

Můžete použít komentáře k poskytování zpětné vazby a spolupráci s kolegy při revizi prezentací.

Aspose.Slides for Python via Java poskytuje následující rozhraní pro práci s komentáři:

* The [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class, která poskytuje přístup k autorům komentářů prezentace.
* The [CommentCollection](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/) class, která představuje komentáře přiřazené konkrétnímu autorovi.
* The [Comment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/) class, která poskytuje informace o komentáři, včetně jeho autora, času vytvoření, pozice a textu.
* The [CommentAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthor/) class, která poskytuje informace o autorovi, včetně jeho jména, iniciál a přiřazených komentářů.

## **Přidání komentářů ke snímkům**

Příklad vytvoří dva snímky a zaregistruje autora komentáře pomocí [addAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#addAuthor). Používá [addComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addComment) k umístění jednoho komentáře na každý snímek, poté získá komentáře první snímku pro toho autora pomocí [getSlideComments](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideComments). Konzole zobrazí text prvního komentáře dvakrát, což demonstruje přístup jak přes snímek, tak přes autora, a uložená prezentace obsahuje oba komentáře.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().addEmptySlide(presentation.getLayoutSlides().get_Item(0))

    author = presentation.getCommentAuthors().addAuthor("Jawad", "MF")
    position = Point2DFloat(0.2, 0.2)
    created_time = Date()

    author.getComments().addComment("Hello Jawad, this is a slide comment", first_slide, position, created_time)
    author.getComments().addComment("Hello Jawad, this is the second slide comment", second_slide, position, created_time)

    comments = first_slide.getSlideComments(author)
    if len(comments) > 0:
        first_comment = comments[0]
        print(first_comment.getText())

        author_comments = first_comment.getAuthor().getComments()
        comment_text = author_comments.get_Item(0).getText()
        print(comment_text)

    presentation.save("Comments_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Vyhledání nebo vytvoření autora komentáře**

Pokud automatizovaná revize zpracovává stejnou prezentaci opakovaně, prohledá kolekci vrácenou metodou [getCommentAuthors](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getCommentAuthors) před přidáním autora. [findByNameAndInitials](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#findByNameAndInitials) porovnává jak jméno, tak iniciály a vrací pole odpovídajících autorů nebo prázdné pole, pokud žádná shoda neexistuje. Naproti tomu [findByName](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#findByName) hledá jen podle jména, nezávisle na iniciálách. Volání [addAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#addAuthor) s již existujícím jménem a iniciálami v kolekci vyvolá výjimku.

Příklad vyžaduje soubor prezentace s alespoň jedním snímkem. V každém ze dvou průchodů znovu použije prvního odpovídajícího autora, nebo jej vytvoří pouze když je výsledek prázdný. Pokud existuje více shod, vybere první prvek pole bez slučování nebo odstraňování ostatních autorů. Poté zavolá [addComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addComment) pro vybraného autora a uloží prezentaci. Druhý průchod otevře výstup prvního průchodu a opakuje operaci.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

author_name = "Reviewer"
author_initials = "RV"

input_file = "input.pptx"
position = Point2DFloat(20, 20)

for pass_number in range(1, 3):
    presentation = Presentation(input_file)
    try:
        matches = presentation.getCommentAuthors().findByNameAndInitials(author_name, author_initials)

        author = matches[0] if len(matches) > 0 else presentation.getCommentAuthors().addAuthor(author_name, author_initials)
        created_time = Date()
        author.getComments().addComment("Please review this slide.", presentation.getSlides().get_Item(0), position, created_time)

        output_file = f"review_pass_{pass_number}.pptx"
        presentation.save(output_file, SaveFormat.Pptx)
        input_file = output_file
    finally:
        presentation.dispose()
```

Druhý průchod přidá další komentář bez přidání dalšího autora nebo odstranění existujících komentářů. Konečný soubor `review_pass_2.pptx` obsahuje oba nové komentáře spolu s původními. Opětovné použití autora nededuplicuje komentáře: aby se zabránilo opakovanému přidávání stejných komentářů, implementujte samostatnou detekci duplicit před jejich přidáním.

## **Přístup ke komentářům snímků**

Příklad otevře existující prezentaci a přečte kolekci vrácenou metodou [getCommentAuthors](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getCommentAuthors). Pro každého autora iteruje přes kolekci vrácenou metodou [getComments](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthor/#getComments) a vypisuje číslo snímku, text komentáře, jméno autora a čas vytvoření. Vstupní prezentace musí obsahovat komentáře, aby byl výstup na konzoli.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Comments1.pptx")
try:
    for author in presentation.getCommentAuthors():
        for comment in author.getComments():
            print("Slide: ", comment.getSlide().getSlideNumber())
            print("Comment: ", comment.getText())
            print("Author: ", comment.getAuthor().getName())
            print("Posted at: ", comment.getCreatedTime())
            print()
finally:
    presentation.dispose()
```

## **Odpovědi na komentáře**

Rodičovský komentář je původní komentář na vrcholu hierarchie odpovědí. Metody [Comment.getParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#getParentComment) a [Comment.setParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#setParentComment) umožňují získat nebo nastavit rodiče komentáře.

Příklad vytváří komentáře od dvou autorů a používá [setParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#setParentComment) k vytvoření odpovědí, včetně odpovědi na jinou odpověď. Předání `None` metodě [getSlideComments](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideComments) získá komentáře ze všech autorů; konzole odsazuje každou položku podle její hloubky v hierarchii odpovědí. Příklad uloží kompletní diskusi, zavolá [remove](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#remove) na první kořenový komentář a uloží druhou prezentaci s tímto komentářem a jeho odpověďmi odstraněnými.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    position = Point2DFloat(10, 10)
    created_time = Date()

    thread_author = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.")
    root_comment = thread_author.getComments().addComment("comment 1", slide, position, created_time)

    responding_author = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.")
    direct_reply = responding_author.getComments().addComment("reply 1 for comment 1", slide, position, created_time)
    direct_reply.setParentComment(root_comment)

    branch_reply = responding_author.getComments().addComment("reply 2 for comment 1", slide, position, created_time)
    branch_reply.setParentComment(root_comment)

    nested_reply = thread_author.getComments().addComment("subreply 3 for reply 2", slide, position, created_time)
    nested_reply.setParentComment(branch_reply)

    responding_author.getComments().addComment("comment 2", slide, position, created_time)
    separate_thread_comment = responding_author.getComments().addComment("comment 3", slide, position, created_time)

    separate_thread_reply = thread_author.getComments().addComment("reply 4 for comment 3", slide, position, created_time)
    separate_thread_reply.setParentComment(separate_thread_comment)

    comments = slide.getSlideComments(None)
    for i in range(len(comments)):
        comment = comments[i]
        while comment.getParentComment() is not None:
            print("\t", end="")
            comment = comment.getParentComment()

        print(f"{comments[i].getAuthor().getName()}: {comments[i].getText()}")

    presentation.save("parent_comment.pptx", SaveFormat.Pptx)

    root_comment.remove()
    presentation.save("remove_comment.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
* Když je metoda [Comment.remove](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#remove) použita k odstranění komentáře, jsou také smazány všechny odpovědi na tento komentář.
* Pokud [Comment.setParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#setParentComment) vytvoří kruhový odkaz, je vyhozena výjimka [PptxEditException](https://reference.aspose.com/slides/python-java/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Přidání moderních komentářů**

Moderní komentáře mohou být přiřazeny k samotnému snímku, k určitému tvaru nebo k textovému rozsahu uvnitř [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/). Metoda [CommentCollection.addModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addModernComment) přijímá argument [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) kromě snímku a souřadnic značky komentáře.

Když je pro argument shape předáno `None`, komentář je komentář na úrovni snímku. Jeho značka je umístěna pomocí dodaných souřadnic, ale není přiřazena k žádnému konkrétnímu tvaru, takže [ModernComment.getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape) vrací `None`. Když je poskytnut [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/), komentář je ukotven k tomuto tvaru. Souřadnice stále definují polohu značky komentáře na snímku, zatímco asociaci s tvarem lze získat pomocí [ModernComment.getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape).

### **Ukotvení moderního komentáře k objektu**

Příklad zavolá [addModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addModernComment) dvakrát: jednou s `None` tvarem pro komentář na úrovni snímku a podruhé s obdélníkem jako kotvou. Čtení [getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape) vypíše `True` pro kontrolu `None` u komentáře na úrovni snímku a `Revenue title` pro ukotvený komentář. Oba komentáře jsou uloženy s prezentací.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV")

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 300, 80)
    shape.setName("Revenue title")
    shape.getTextFrame().setText("Quarterly revenue")

    created_time = Date()
    slide_comment_position = Point2DFloat(20, 20)
    shape_comment_position = Point2DFloat(60, 60)
    slide_comment = author.getComments().addModernComment("Review the overall slide layout.", slide, None, slide_comment_position, created_time)
    shape_comment = author.getComments().addModernComment("Check this title.", slide, shape, shape_comment_position, created_time)

    print(slide_comment.getShape() is None)
    print(shape_comment.getShape().getName())

    presentation.save("modern_comments.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Ukotvení komentářů k různým typům objektů**

Jakýkoli objekt snímku, který dědí od [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/), může být použit jako kotva tvaru. Běžné příklady zahrnují [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/python-java/aspose.slides/connector/), a [GraphicalObject](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobject/) instance, jako jsou grafy.

Příklad používá [addModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addModernComment) ke spojení komentáře s každým z pěti typů tvarů: AutoShape, obrázkový rámeček, skupinu, konektor a graf. Obrázek používá vložená data obrazu, takže není potřeba externí obrázek. Každý komentář má svou vlastní polohu značky a uložená prezentace zachová všech pět asociací tvarů.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")
Base64 = jpype.JClass("java.util.Base64")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV")
    created_time = Date()

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 180, 60)
    auto_shape.getTextFrame().setText("AutoShape")

    auto_shape_comment_position = Point2DFloat(30, 30)
    author.getComments().addModernComment("Comment on an AutoShape.", slide, auto_shape, auto_shape_comment_position, created_time)

    image_base64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg=="
    image_data = Base64.getDecoder().decode(image_base64)
    image = presentation.getImages().addImage(image_data)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 120, 80, image)
    picture_comment_position = Point2DFloat(230, 30)
    author.getComments().addModernComment("Comment on a picture.", slide, picture_frame, picture_comment_position, created_time)

    group_shape = slide.getShapes().addGroupShape()
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 80, 40)
    group_shape.getShapes().addAutoShape(ShapeType.Ellipse, 100, 0, 80, 40)
    group_comment_position = Point2DFloat(40, 150)
    author.getComments().addModernComment("Comment on a group.", slide, group_shape, group_comment_position, created_time)

    connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 220, 150, 140, 40)
    connector_comment_position = Point2DFloat(240, 150)
    author.getComments().addModernComment("Comment on a connector.", slide, connector, connector_comment_position, created_time)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 400, 20, 250, 180)
    chart_comment_position = Point2DFloat(420, 40)
    author.getComments().addModernComment("Comment on a graphical object.", slide, chart, chart_comment_position, created_time)

    presentation.save("modern_comment_shape_types.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Ukotvení komentáře k textu a nastavení jeho stavu**

Pro moderní komentář spojený s [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) poskytují [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionStart) a [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionStart) přístup k počáteční pozici vybraného textu v textovém rámci tvaru. [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionLength) a [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionLength) přistupují k délce výběru. Společně tyto hodnoty spojují komentář s konkrétním textovým rozsahem uvnitř AutoShape.

Metody [ModernComment.getStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getStatus) a [ModernComment.setStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setStatus) přistupují k hodnotě z konstant [ModernCommentStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/):

- [NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#NotDefined) — není definován žádný konkrétní stav moderního komentáře.
- [Active](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#Active) — komentář je aktivní.
- [Resolved](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#Resolved) — komentář byl vyřešen.
- [Closed](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#Closed) — komentář je uzavřen.

Příklad ukotví moderní komentář ke slovům "quarterly revenue" v textu obdélníku. Vypočítá nulový výchozí index výběru z textu a předá jej metodě [setTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionStart) a použije [setTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionLength) k nastavení počtu vybraných znaků. Po zavolání [setStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setStatus) s `Resolved` uloží a znovu otevře prezentaci. Čtyři kontroly na konzoli by měly každá vypsat `True`, což potvrzuje, že kotva tvaru, textový rozsah a stav byly zachovány.

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ModernComment, ModernCommentStatus, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

output_file = "modern_comment_text_anchor.pptx"
shape_text = "Review the quarterly revenue forecast."
selected_text = "quarterly revenue"
expected_selection_start = shape_text.find(selected_text)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100)
    shape.setName("Forecast text")
    shape.getTextFrame().setText(shape_text)

    author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV")
    comment_position = Point2DFloat(60, 60)
    created_time = Date()
    comment = author.getComments().addModernComment("Verify this forecast wording.", slide, shape, comment_position, created_time)
    comment.setTextSelectionStart(expected_selection_start)
    comment.setTextSelectionLength(len(selected_text))
    comment.setStatus(ModernCommentStatus.Resolved)

    presentation.save(output_file, SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation(output_file)
try:
    reopened_slide = reopened_presentation.getSlides().get_Item(0)
    reopened_comments = reopened_slide.getSlideComments(None)

    for reopened_comment in reopened_comments:
        if not isinstance(reopened_comment, ModernComment):
            continue

        modern_comment = reopened_comment
        shape_matches = modern_comment.getShape() is not None and modern_comment.getShape().getName() == "Forecast text"
        selection_start_matches = modern_comment.getTextSelectionStart() == expected_selection_start
        selection_length_matches = modern_comment.getTextSelectionLength() == len(selected_text)
        status_matches = modern_comment.getStatus() == ModernCommentStatus.Resolved

        print("Shape anchor preserved: ", shape_matches)
        print("Text selection start preserved: ", selection_start_matches)
        print("Text selection length preserved: ", selection_length_matches)
        print("Resolved status preserved: ", status_matches)
finally:
    reopened_presentation.dispose()
```

### **Prohlédnutí existujících moderních komentářů**

Příklad vyžaduje existující prezentaci obsahující moderní komentáře a vypisuje jejich text, stav a podrobnosti kotvy. Pro prohlédnutí zkontrolujte, které komentáře jsou instance [ModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/), poté prozkoumejte [ModernComment.getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionStart), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionLength) a [ModernComment.getStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getStatus). `None` shape indikuje komentář na úrovni snímku. Pro kotvu [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) metody pro výběr textu identifikují související rozsah v textovém rámci tvaru.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ModernComment, Presentation

presentation = Presentation("comments.pptx")
try:
    for slide in presentation.getSlides():
        comments = slide.getSlideComments(None)
        for comment in comments:
            if not isinstance(comment, ModernComment):
                continue

            modern_comment = comment
            print("Slide: ", slide.getSlideNumber())
            print("Text: ", modern_comment.getText())
            print("Status: ", modern_comment.getStatus())

            shape = modern_comment.getShape()
            if shape is None:
                print("Anchor: slide level")
            else:
                print("Anchor shape: ", shape.getName())
                print("Anchor type: ", shape.getClass().getSimpleName())

                if isinstance(shape, AutoShape):
                    print("Text selection start: ", modern_comment.getTextSelectionStart())
                    print("Text selection length: ", modern_comment.getTextSelectionLength())

            print()
finally:
    presentation.dispose()
```

## **Odstranění komentářů**

Aspose.Slides for Python via Java umožňuje odstranit všechny komentáře a jejich autory z prezentace nebo smazat vybrané komentáře při zachování ostatních. Následující příklady ukazují oba přístupy a uloží aktualizovanou prezentaci.

### **Odstranit všechny komentáře a jejich autory**

Příklad otevře existující prezentaci a zavolá [CommentCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#clear) pro každého autora, poté volá [CommentAuthorCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#clear) k odstranění samotných autorů. Uložená prezentace neobsahuje ani komentáře, ani autory komentářů. Použijte prezentaci obsahující komentáře pro pozorování odstranění.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("example.pptx")
try:
    for author in presentation.getCommentAuthors():
        author.getComments().clear()

    presentation.getCommentAuthors().clear()

    presentation.save("example_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Odstranit konkrétní komentáře**

Příklad vytvoří dva komentáře na jednom snímku a používá [getSlideComments](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideComments) k nalezení komentářů od každého autora. Sbírá komentáře, jejichž text se rovná "comment 1" před voláním [CommentCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#remove), aby se vyhnul změnám kolekce během výběru. Uložená prezentace zachová pouze "comment 2".

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    author = presentation.getCommentAuthors().addAuthor("Author", "A")
    created_time = Date()

    first_comment_position = Point2DFloat(0.2, 0.2)
    second_comment_position = Point2DFloat(0.3, 0.2)
    author.getComments().addComment("comment 1", slide, first_comment_position, created_time)
    author.getComments().addComment("comment 2", slide, second_comment_position, created_time)

    for comment_author in presentation.getCommentAuthors():
        comments_to_remove = []
        comments = slide.getSlideComments(comment_author)

        for comment in comments:
            if comment.getText() == "comment 1":
                comments_to_remove.append(comment)

        for comment in comments_to_remove:
            comment_author.getComments().remove(comment)

    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Často kladené otázky**

**Podporuje Aspose.Slides stav resolved pro moderní komentáře?**

Ano. [ModernComment.getStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getStatus) a [ModernComment.setStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setStatus) přistupují k hodnotě [ModernCommentStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/), včetně `Resolved`. Stav je uložen v prezentaci a lze jej opět načíst po opětovném otevření souboru.

**Jsou podporovány vlákna diskusí (řetězce odpovědí) a existuje limit vnoření?**

Ano. Každý komentář může odkazovat na svůj [parent comment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#getParentComment), což umožňuje řetězce odpovědí. API nedefinuje konkrétní limit hloubky vnoření.

**V jakém souřadnicovém systému je definována poloha značky komentáře na snímku?**

Pozice značky je definována pomocí souřadnic s plovoucí desetinnou čárkou v souřadnicovém systému snímku, což vám umožňuje ji přesně umístit na snímek.