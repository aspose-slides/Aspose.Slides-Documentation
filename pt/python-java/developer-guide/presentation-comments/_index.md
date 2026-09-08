---
title: Gerenciar Comentários de Apresentação em Python via Java
linktitle: Comentários de Apresentação
type: docs
weight: 100
url: /pt/python-java/presentation-comments/
keywords:
- comentário
- comentário moderno
- comentários do PowerPoint
- comentários de apresentação
- comentários de slide
- adicionar comentário
- acessar comentário
- editar comentário
- responder comentário
- remover comentário
- excluir comentário
- PowerPoint
- apresentação
- Python
- Java
- Aspose.Slides
description: "Gerencie comentários de apresentação com Aspose.Slides para Python via Java: adicione, leia, edite, responda e remova comentários em apresentações do PowerPoint de forma rápida e fácil."
---
## **Visão geral**

Este artigo explica como gerenciar comentários de apresentação com Aspose.Slides for Python via Java. Ele introduz os principais tipos relacionados a comentários e demonstra como adicionar comentários a slides, acessar comentários existentes, trabalhar com respostas e comentários modernos e remover comentários de uma apresentação.

Os exemplos cobrem cenários comuns de revisão e colaboração no PowerPoint, como atribuir comentários a autores, ler o texto e os metadados dos comentários, construir cadeias de respostas e remover comentários selecionados ou todos os comentários.

No PowerPoint, os comentários aparecem como anotações nos slides. Selecionar um comentário exibe seu texto e a discussão relacionada.

## **Por que adicionar comentários às apresentações?**

Você pode usar comentários para fornecer feedback e colaborar com colegas ao revisar apresentações.

Aspose.Slides for Python via Java fornece as seguintes APIs para trabalhar com comentários:

* A classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) fornece acesso aos autores de comentários da apresentação.
* A classe [CommentCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/commentcollection/) representa os comentários associados a um autor específico.
* A classe [Comment](https://reference.aspose.com/slides/pt/python-java/aspose.slides/comment/) fornece informações sobre um comentário, incluindo seu autor, horário de criação, posição e texto.
* A classe [CommentAuthor](https://reference.aspose.com/slides/pt/python-java/aspose.slides/commentauthor/) fornece informações sobre um autor, incluindo seu nome, iniciais e comentários associados.

## **Adicionar comentários a slides**

O exemplo a seguir mostra como adicionar comentários a slides em uma apresentação do PowerPoint:

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

## **Acessar comentários de slides**

O exemplo a seguir mostra como acessar comentários existentes em uma apresentação do PowerPoint:

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

## **Responder a comentários**

Um comentário pai é o comentário original no topo de uma hierarquia de respostas. Os métodos [Comment.getParentComment](https://reference.aspose.com/slides/pt/python-java/aspose.slides/comment/#getParentComment) e [Comment.setParentComment](https://reference.aspose.com/slides/pt/python-java/aspose.slides/comment/#setParentComment) permitem obter ou definir o pai de um comentário.

O exemplo a seguir mostra como adicionar respostas e inspecionar a hierarquia de comentários resultante:

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
* Quando o método [Comment.remove](https://reference.aspose.com/slides/pt/python-java/aspose.slides/comment/#remove) é usado para excluir um comentário, todas as respostas a esse comentário também são excluídas.
* Se [Comment.setParentComment](https://reference.aspose.com/slides/pt/python-java/aspose.slides/comment/#setParentComment) criar uma referência circular, uma [PptxEditException](https://reference.aspose.com/slides/pt/python-java/aspose.slides/pptxeditexception/) será lançada.
{{% /alert %}}

## **Adicionar comentários modernos**

Comentários modernos podem ser associados ao próprio slide, a uma forma específica ou a um intervalo de texto dentro de um [AutoShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/autoshape/). O método [CommentCollection.addModernComment](https://reference.aspose.com/slides/pt/python-java/aspose.slides/commentcollection/#addModernComment) aceita um argumento [Shape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/) além do slide e das coordenadas do marcador de comentário.

Quando `None` é passado para o argumento shape, o comentário é um comentário de nível de slide. Seu marcador é posicionado pelas coordenadas fornecidas, mas não está associado a uma forma específica, portanto [ModernComment.getShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/moderncomment/#getShape) retorna `None`. Quando uma [Shape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/) é fornecida, o comentário é ancorado a essa forma. As coordenadas ainda definem a posição do marcador de comentário no slide, enquanto a associação à forma pode ser recuperada através de [ModernComment.getShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/moderncomment/#getShape).

### **Ancorar um comentário moderno a uma forma**

O exemplo a seguir cria tanto um comentário moderno de nível de slide quanto um comentário moderno ancorado a um [AutoShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/autoshape/) específico. Em seguida, lê a forma associada de cada comentário.

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

### **Ancorar comentários a diferentes tipos de forma**

Qualquer objeto de slide que herde de [Shape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/) pode ser usado como âncora de forma. Exemplos comuns incluem [AutoShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/pt/python-java/aspose.slides/connector/) e instâncias de [GraphicalObject](https://reference.aspose.com/slides/pt/python-java/aspose.slides/graphicalobject/) como gráficos.

O exemplo a seguir cria vários tipos de forma comuns e associa um comentário moderno a cada um deles.

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

### **Ancorar um comentário a texto e definir seu status**

Para um comentário moderno associado a um [AutoShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/autoshape/), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/pt/python-java/aspose.slides/moderncomment/#getTextSelectionStart) e [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/pt/python-java/aspose.slides/moderncomment/#setTextSelectionStart) acessam a posição inicial do texto selecionado na caixa de texto da forma. [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/pt/python-java/aspose.slides/moderncomment/#getTextSelectionLength) e [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/pt/python-java/aspose.slides/moderncomment/#setTextSelectionLength) acessam o comprimento da seleção. Juntos, esses valores associam o comentário a um intervalo de texto específico dentro do AutoShape.

Os métodos [ModernComment.getStatus](https://reference.aspose.com/slides/pt/python-java/aspose.slides/moderncomment/#getStatus) e [ModernComment.setStatus](https://reference.aspose.com/slides/pt/python-java/aspose.slides/moderncomment/#setStatus) acessam um valor dos constantes [ModernCommentStatus](https://reference.aspose.com/slides/pt/python-java/aspose.slides/moderncommentstatus/):

- [NotDefined](https://reference.aspose.com/slides/pt/python-java/aspose.slides/moderncommentstatus/#NotDefined) — nenhum status específico de comentário moderno está definido.
- [Active](https://reference.aspose.com/slides/pt/python-java/aspose.slides/moderncommentstatus/#Active) — o comentário está ativo.
- [Resolved](https://reference.aspose.com/slides/pt/python-java/aspose.slides/moderncommentstatus/#Resolved) — o comentário foi resolvido.
- [Closed](https://reference.aspose.com/slides/pt/python-java/aspose.slides/moderncommentstatus/#Closed) — o comentário está fechado.

O exemplo a seguir cria um comentário moderno ancorado a uma forma, o associa a uma seleção de texto, marca-o como resolvido, salva a apresentação e verifica os valores após reabrir o arquivo.

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

### **Inspecionar comentários modernos existentes**

Para inspecionar uma apresentação existente, verifique quais comentários são instâncias de [ModernComment](https://reference.aspose.com/slides/pt/python-java/aspose.slides/moderncomment/), então examine [ModernComment.getShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/moderncomment/#getShape), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/pt/python-java/aspose.slides/moderncomment/#getTextSelectionStart), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/pt/python-java/aspose.slides/moderncomment/#getTextSelectionLength) e [ModernComment.getStatus](https://reference.aspose.com/slides/pt/python-java/aspose.slides/moderncomment/#getStatus). Uma forma `None` indica um comentário de nível de slide. Para uma âncora de [AutoShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/autoshape/), os métodos de seleção de texto identificam o intervalo associado na caixa de texto da forma.

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

## **Remover comentários**

### **Remover todos os comentários e autores de comentário**

O exemplo a seguir mostra como remover todos os comentários e autores de comentário de uma apresentação:

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

### **Remover comentários específicos**

O exemplo a seguir mostra como remover comentários específicos de um slide:

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

## **FAQ**

**O Aspose.Slides oferece suporte a um status resolvido para comentários modernos?**

Sim. [ModernComment.getStatus](https://reference.aspose.com/slides/pt/python-java/aspose.slides/moderncomment/#getStatus) e [ModernComment.setStatus](https://reference.aspose.com/slides/pt/python-java/aspose.slides/moderncomment/#setStatus) acessam um valor de [ModernCommentStatus](https://reference.aspose.com/slides/pt/python-java/aspose.slides/moderncommentstatus/), incluindo `Resolved`. O status é armazenado na apresentação e pode ser lido novamente após o arquivo ser reaberto.

**As discussões encadeadas (cadeias de respostas) são suportadas e há um limite de aninhamento?**

Sim. Cada comentário pode referenciar seu [parent comment](https://reference.aspose.com/slides/pt/python-java/aspose.slides/comment/#getParentComment), permitindo cadeias de respostas. A API não define um limite específico de profundidade de aninhamento.

**Em que sistema de coordenadas a posição do marcador de comentário é definida em um slide?**

A posição do marcador é definida por coordenadas de ponto flutuante no sistema de coordenadas do slide, permitindo posicioná‑lo com precisão no slide.