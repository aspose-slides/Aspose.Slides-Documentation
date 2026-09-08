---
title: Správa komentářů v prezentaci v Pythonu pomocí Java
linktitle: Komentáře v prezentaci
type: docs
weight: 100
url: /cs/python-java/presentation-comments/
keywords:
- komentář
- moderní komentář
- komentáře PowerPoint
- komentáře prezentace
- komentáře snímků
- přidat komentář
- přístup ke komentáři
- upravit komentář
- odpovědět na komentář
- odstranit komentář
- smazat komentář
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Spravujte komentáře v prezentacích pomocí Aspose.Slides for Python via Java: přidejte, přečtěte, upravte, odpovězte a odstraňte komentáře v PowerPoint prezentacích rychle a snadno."
---
## **Přehled**

Tento článek vysvětluje, jak spravovat komentáře v prezentaci pomocí Aspose.Slides for Python via Java. Představuje hlavní typy související s komentáři a demonstruje, jak přidávat komentáře do snímků, přistupovat k existujícím komentářům, pracovat s odpověďmi a moderními komentáři a odstraňovat komentáře z prezentace.

Příklady pokrývají běžné scénáře revize a spolupráce v PowerPointu, jako je přiřazování komentářů autorům, čtení textu komentáře a jeho metadat, vytváření řetězců odpovědí a odstraňování vybraných komentářů nebo všech komentářů.

V PowerPointu se komentáře zobrazují jako anotace na snímcích. Výběrem komentáře se zobrazí jeho text a související diskuse.

## **Proč přidávat komentáře do prezentací?**

Komentáře můžete použít k poskytování zpětné vazby a spolupráci s kolegy při revizi prezentací.

Aspose.Slides for Python via Java poskytuje následující API pro práci s komentáři:

* Třída [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) poskytuje přístup k autorům komentářů v prezentaci.
* Třída [CommentCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/commentcollection/) představuje komentáře spojené s konkrétním autorem.
* Třída [Comment](https://reference.aspose.com/slides/cs/python-java/aspose.slides/comment/) poskytuje informace o komentáři, včetně autora, času vytvoření, pozice a textu.
* Třída [CommentAuthor](https://reference.aspose.com/slides/cs/python-java/aspose.slides/commentauthor/) poskytuje informace o autorovi, včetně jeho jména, iniciál a souvisejících komentářů.

## **Přidat komentáře ke snímkům**

Následující příklad ukazuje, jak přidat komentáře do snímků v PowerPoint prezentaci:

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

## **Přístup ke komentářům na snímcích**

Následující příklad ukazuje, jak získat přístup k existujícím komentářům v PowerPoint prezentaci:

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

## **Odpovídání na komentáře**

Rodičovský komentář je původní komentář na vrcholu hierarchie odpovědí. Metody [Comment.getParentComment](https://reference.aspose.com/slides/cs/python-java/aspose.slides/comment/#getParentComment) a [Comment.setParentComment](https://reference.aspose.com/slides/cs/python-java/aspose.slides/comment/#setParentComment) umožňují získat nebo nastavit rodiče komentáře.

Následující příklad ukazuje, jak přidávat odpovědi a prozkoumat vzniklou hierarchii komentářů:

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
* Když je metoda [Comment.remove](https://reference.aspose.com/slides/cs/python-java/aspose.slides/comment/#remove) použita k odstranění komentáře, jsou také smazány všechny odpovědi na tento komentář.
* Pokud metoda [Comment.setParentComment](https://reference.aspose.com/slides/cs/python-java/aspose.slides/comment/#setParentComment) vytvoří kruhový odkaz, je vyvolána výjimka [PptxEditException](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Přidat moderní komentáře**

Moderní komentáře mohou být spojeny se samotným snímkem, s konkrétním tvarem nebo s rozsahem textu uvnitř [AutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/). Metoda [CommentCollection.addModernComment](https://reference.aspose.com/slides/cs/python-java/aspose.slides/commentcollection/#addModernComment) přijímá argument [Shape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/) kromě snímku a souřadnic značky komentáře.

Když je pro argument shape předáno `None`, jedná se o komentář úrovně snímku. Jeho značka je umístěna podle zadaných souřadnic, ale není spojena s konkrétním tvarem, takže [ModernComment.getShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/moderncomment/#getShape) vrací `None`. Pokud je poskytnut [Shape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/), je komentář ukotven k tomuto tvaru. Souřadnice stále určují pozici značky komentáře na snímku, zatímco asociaci s tvarem lze získat pomocí [ModernComment.getShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/moderncomment/#getShape).

### **Ukotvit moderní komentář k tvaru**

Následující příklad vytváří jak moderní komentář úrovně snímku, tak moderní komentář ukotvený k určitému [AutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/). Pak načte související tvar z každého komentáře.

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

### **Ukotvit komentáře k různým typům tvarů**

Jakýkoli objekt snímku, který dědí z [Shape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/), může být použit jako ukotvení tvaru. Běžné příklady zahrnují [AutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/cs/python-java/aspose.slides/connector/) a instance [GraphicalObject](https://reference.aspose.com/slides/cs/python-java/aspose.slides/graphicalobject/), například grafy.

Následující příklad vytváří několik běžných typů tvarů a přiřazuje k nim moderní komentář.

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

### **Ukotvit komentář k textu a nastavit jeho stav**

Pro moderní komentář spojený s [AutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/cs/python-java/aspose.slides/moderncomment/#getTextSelectionStart) a [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/cs/python-java/aspose.slides/moderncomment/#setTextSelectionStart) přistupují k počáteční pozici vybraného textu v textovém rámci tvaru. [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/cs/python-java/aspose.slides/moderncomment/#getTextSelectionLength) a [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/cs/python-java/aspose.slides/moderncomment/#setTextSelectionLength) přistupují k délce výběru. Společně tyto hodnoty spojují komentář s konkrétním rozsahem textu uvnitř AutoShape.

Metody [ModernComment.getStatus](https://reference.aspose.com/slides/cs/python-java/aspose.slides/moderncomment/#getStatus) a [ModernComment.setStatus](https://reference.aspose.com/slides/cs/python-java/aspose.slides/moderncomment/#setStatus) získávají hodnotu z konstant [ModernCommentStatus](https://reference.aspose.com/slides/cs/python-java/aspose.slides/moderncommentstatus/):

- [NotDefined] — není definován žádný konkrétní stav moderního komentáře.
- [Active] — komentář je aktivní.
- [Resolved] — komentář byl vyřešen.
- [Closed] — komentář je uzavřen.

Následující příklad vytváří moderní komentář ukotvený k tvaru, přiřadí jej k výběru textu, označí jej jako vyřešený, uloží prezentaci a po opětovném otevření souboru ověří hodnoty.

```python
import jpype
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

### **Prozkoumat existující moderní komentáře**

Pro prozkoumání existující prezentace zkontrolujte, které komentáře jsou instance [ModernComment](https://reference.aspose.com/slides/cs/python-java/aspose.slides/moderncomment/), poté prozkoumejte [ModernComment.getShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/moderncomment/#getShape), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/cs/python-java/aspose.slides/moderncomment/#getTextSelectionStart), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/cs/python-java/aspose.slides/moderncomment/#getTextSelectionLength) a [ModernComment.getStatus](https://reference.aspose.com/slides/cs/python-java/aspose.slides/moderncomment/#getStatus). Tvar `None` označuje komentář úrovně snímku. Pro ukotvení k [AutoShape] anchor metody výběru textu určují související rozsah v textovém rámci tvaru.

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

## **Odstranit komentáře**

### **Odstranit všechny komentáře a autory komentářů**

Následující příklad ukazuje, jak odstranit všechny komentáře a autory komentářů z prezentace:

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

Následující příklad ukazuje, jak odstranit konkrétní komentáře ze snímku:

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

**Podporuje Aspose.Slides stav „vyřešeno“ pro moderní komentáře?**

Ano. Metody [ModernComment.getStatus](https://reference.aspose.com/slides/cs/python-java/aspose.slides/moderncomment/#getStatus) a [ModernComment.setStatus](https://reference.aspose.com/slides/cs/python-java/aspose.slides/moderncomment/#setStatus) získávají hodnotu [ModernCommentStatus], včetně `Resolved`. Stav je uložen v prezentaci a lze jej znovu přečíst po opětovném otevření souboru.

**Jsou podporovány vlákna diskuzí (řetězce odpovědí) a existuje omezení hloubky vnoření?**

Ano. Každý komentář může odkazovat na svůj [parent comment](https://reference.aspose.com/slides/cs/python-java/aspose.slides/comment/#getParentComment), což umožňuje řetězce odpovědí. API nedefinuje konkrétní limit hloubky vnoření.

**V jakém souřadnicovém systému je definována pozice značky komentáře na snímku?**

Pozice značky je definována pomocí desetinných souřadnic v souřadnicovém systému snímku, což vám umožňuje ji přesně umístit na snímek.