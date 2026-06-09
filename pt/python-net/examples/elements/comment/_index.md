---
title: Comentário
type: docs
weight: 230
url: /pt/python-net/examples/elements/comment/
keywords:
- comentário
- comentário moderno
- adicionar comentário
- acessar comentário
- remover comentário
- responder ao comentário
- exemplos de código
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Gerencie comentários de slides em Python com Aspose.Slides: adicione, leia, responda, edite, exclua e trabalhe com comentários encadeados para PowerPoint e OpenDocument."
---
Apresenta a adição, leitura, remoção e resposta a comentários modernos usando **Aspose.Slides for Python via .NET**.

## **Adicionar um Comentário Moderno**

Crie um comentário escrito por um usuário e salve a apresentação.

```py
def add_modern_comment():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Adicionar um autor de comentário.
        author = presentation.comment_authors.add_author("User", "U1")

        # Adicionar um comentário moderno.
        author.comments.add_modern_comment(
            "This is a modern comment", slide, None, drawing.PointF(100, 100), datetime.date.today())

        presentation.save("modern_comment.pptx", slides.export.SaveFormat.PPTX)
```

## **Acessar um Comentário Moderno**

Leia um comentário moderno de uma apresentação existente.

```py
def access_modern_comment():
    with slides.Presentation("modern_comment.pptx") as presentation:
        author = presentation.comment_authors[0]

        # Acessar o primeiro comentário moderno.
        comment = author.comments[0]

        print(f"Author: {author.name}, Comment: {comment.text}")
```

## **Remover um Comentário Moderno**

Remova um comentário e salve o arquivo atualizado.

```py
def remove_modern_comment():
    with slides.Presentation("modern_comment.pptx") as presentation:
        author = presentation.comment_authors[0]
        comment = author.comments[0]

        # Remover o comentário.
        comment.remove()

        presentation.save("modern_comment_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Responder a um Comentário Moderno**

Adicione respostas a um comentário moderno pai.

```py
def reply_to_modern_comment():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        author = presentation.comment_authors.add_author("User", "U1")

        # Adicionar comentário pai.
        parent = author.comments.add_modern_comment(
            "Parent comment", slide, None, drawing.PointF(100, 100), datetime.date.today())

        # Adicionar primeira resposta.
        reply1 = author.comments.add_modern_comment(
            "Reply 1", slide, None, drawing.PointF(110, 100), datetime.date.today())

        # Adicionar segunda resposta.
        reply2 = author.comments.add_modern_comment(
            "Reply 2", slide, None, drawing.PointF(120, 100), datetime.date.today())

        reply1.parent_comment = parent
        reply2.parent_comment = parent

        presentation.save("modern_comment_replies.pptx", slides.export.SaveFormat.PPTX)
```