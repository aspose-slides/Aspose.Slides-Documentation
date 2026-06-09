---
title: Gerenciar Comentários de Apresentação em Python
linktitle: Comentários de Apresentação
type: docs
weight: 100
url: /pt/python-net/presentation-comments/
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
- Aspose.Slides
description: "Domine os comentários de apresentação com Aspose.Slides para Python via .NET: adicione, leia, edite e exclua comentários em arquivos PowerPoint de forma rápida e fácil."
---
## **Visão geral**

Este artigo explica como gerenciar comentários de apresentação no Aspose.Slides. Ele mostra os principais tipos relacionados a comentários e demonstra como adicionar comentários aos slides, acessar comentários existentes, trabalhar com respostas, usar comentários modernos e remover comentários de uma apresentação.

Os exemplos focam em cenários comuns de revisão e colaboração no PowerPoint, como atribuir comentários a autores, ler o conteúdo e os metadados dos comentários, criar cadeias de respostas e limpar todos os comentários ou excluir os selecionados.

No PowerPoint, um comentário aparece como uma nota ou anotação em um slide. Quando um comentário é clicado, seu conteúdo ou mensagens são revelados. 

## **Por que adicionar comentários a apresentações?**

Você pode desejar usar comentários para fornecer feedback ou se comunicar com colegas ao revisar apresentações.

Para permitir que você use comentários em apresentações do PowerPoint, o Aspose.Slides for Python via .NET oferece

* A classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) , que contém as coleções de autores (por meio da propriedade [CommentAuthorCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/commentauthorcollection/)). Os autores adicionam comentários aos slides. 
* A classe [CommentCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/commentcollection/) , que contém a coleção de comentários para autores individuais. 
* A classe [Comment](https://reference.aspose.com/slides/pt/python-net/aspose.slides/comment/) , que contém informações sobre autores e seus comentários: quem adicionou o comentário, a hora em que o comentário foi adicionado, a posição do comentário etc. 
* A classe [CommentAuthor](https://reference.aspose.com/slides/pt/python-net/aspose.slides/commentauthor/) , que contém informações sobre autores individuais: o nome do autor, suas iniciais, comentários associados ao nome do autor etc. 

## **Adicionar comentário ao slide**
Este código Python mostra como adicionar um comentário a um slide em uma apresentação do PowerPoint:

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

# Instancia a classe Presentation
with slides.Presentation() as presentation:
    # Adiciona um slide vazio
    presentation.slides.add_empty_slide(presentation.layout_slides[0])

    # Adiciona um autor
    author = presentation.comment_authors.add_author("Jawad", "MF")

    # Define a posição dos comentários
    point = draw.PointF(0.2, 0.2)

    # Adiciona um comentário de slide para um autor no slide 1
    author.comments.add_comment("Hello Jawad, this is slide comment", presentation.slides[0], point, datetime.date.today())

    # Adiciona um comentário de slide para um autor no slide 2
    author.comments.add_comment("Hello Jawad, this is second slide comment", presentation.slides[1], point, datetime.date.today())

    # Acessando ISlide 1
    slide = presentation.slides[0]

    # Quando null é passado como argumento, comentários de todos os autores são trazidos para o slide selecionado
    comments = slide.get_slide_comments(author)

    # Acessa o comentário no índice 0 para o slide 1
    str = comments[0].text

    presentation.save("Comments_out.pptx", slides.export.SaveFormat.PPTX)

    if comments.length > 0:
        # Seleciona a coleção de comentários do Autor no índice 0
        commentCollection = comments[0].author.comments
        print(commentCollection[0].text)
```



## **Acessar comentários do slide**
Este código Python mostra como acessar um comentário existente em um slide em uma apresentação do PowerPoint:

```python
import aspose.slides as slides

# Instancia a classe Presentation
with slides.Presentation("Comments1.pptx") as presentation:
    for author in presentation.comment_authors:
        for comment in author.comments:
            print("ISlide :" + str(comment.slide.slide_number) + 
            " has comment: " + comment.text + 
            " with Author: " + comment.author.name + 
            " posted on time :" + str(comment.created_time) + "\n")
```


## **Responder a comentários**
Um comentário pai é o comentário superior ou original em uma hierarquia de comentários ou respostas. Usando a propriedade `parent_comment` (da classe [Comment](https://reference.aspose.com/slides/pt/python-net/aspose.slides/comment/)), você pode definir ou obter um comentário pai. 

Este código Python mostra como adicionar comentários e obter respostas a eles:

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

with slides.Presentation() as pres:
    # Adiciona um comentário
    author1 = pres.comment_authors.add_author("Author_1", "A.A.")
    comment1 = author1.comments.add_comment("comment1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    # Adiciona uma resposta ao comentário1
    author2 = pres.comment_authors.add_author("Autror_2", "B.B.")
    reply1 = author2.comments.add_comment("reply 1 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply1.parent_comment = comment1

    # Adiciona outra resposta ao comentário1
    reply2 = author2.comments.add_comment("reply 2 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply2.parent_comment = comment1

    # Adiciona uma resposta a uma resposta existente
    subReply = author1.comments.add_comment("subreply 3 for reply 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    subReply.parent_comment = reply2

    comment2 = author2.comments.add_comment("comment 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    comment3 = author2.comments.add_comment("comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    reply3 = author1.comments.add_comment("reply 4 for comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply3.parent_comment = comment3

    # Exibe a hierarquia de comentários no console
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

    # Remove o comentário1 e todas as respostas a ele
    comment1.remove()

    pres.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Attention" %}} 

* Quando o método `remove` (da classe [Comment](https://reference.aspose.com/slides/pt/python-net/aspose.slides/comment/)) é usado para excluir um comentário, as respostas ao comentário também são excluídas. 
* Se a configuração `parent_comment` resultar em uma referência circular, será lançada `PptxEditException`.

{{% /alert %}}

## **Adicionar comentário moderno**

Em 2021, a Microsoft introduziu *comentários modernos* no PowerPoint. O recurso de comentários modernos melhora significativamente a colaboração no PowerPoint. Por meio de comentários modernos, os usuários do PowerPoint podem resolver comentários, ancorar comentários a objetos e textos e interagir de forma muito mais fácil do que antes. 

Implementamos suporte a comentários modernos adicionando a classe [ModernComment](https://reference.aspose.com/slides/pt/python-net/aspose.slides/moderncomment/). Os métodos `add_modern_comment` e `insert_modern_comment` foram adicionados à classe [CommentCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/commentcollection/). 

Este código Python mostra como adicionar um comentário moderno a um slide em uma apresentação do PowerPoint:

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as pres:
    newAuthor = pres.comment_authors.add_author("Some Author", "SA")
    modernComment = newAuthor.comments.add_modern_comment("This is a modern comment", pres.slides[0], None, draw.PointF(100, 100), date.today())

    pres.save("example.pptx", slides.export.SaveFormat.PPTX)
```

## **Remover comentário**

### **Excluir todos os comentários e autores**

Este código Python mostra como remover todos os comentários e autores em uma apresentação:

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    # Exclui todos os comentários da apresentação
    for author in presentation.comment_authors:
        author.comments.clear()

    # Exclui todos os autores
    presentation.comment_authors.clear()

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Excluir comentários específicos**

Este código Python mostra como excluir comentários específicos em um slide:

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    # adiciona comentários...
    author = presentation.comment_authors.add_author("Author", "A")
    author.comments.add_comment("comment 1", slide, draw.PointF(0.2, 0.2), date.today())
    author.comments.add_comment("comment 2", slide, draw.PointF(0.3, 0.2), date.today())
    
    # remove todos os comentários que contenham o texto "comment 1"
    for commentAuthor in presentation.comment_authors:
        toRemove = []
        for comment in slide.get_slide_comments(commentAuthor):
            if comment.text == "comment 1":
                toRemove.append(comment)
        
        for comment in toRemove:
            commentAuthor.comments.remove(comment)
    
    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**O Aspose.Slides oferece suporte a um status como “resolvido” para comentários modernos?**

Sim. [Modern comments](https://reference.aspose.com/slides/pt/python-net/aspose.slides/moderncomment/) expõem a propriedade [status](https://reference.aspose.com/slides/pt/python-net/aspose.slides/moderncomment/status/); você pode ler e definir o [estado do comentário](https://reference.aspose.com/slides/pt/python-net/aspose.slides/moderncommentstatus/) (por exemplo, marcá‑lo como resolvido), e esse estado é salvo no arquivo e reconhecido pelo PowerPoint.

**Discussões em cadeia (respostas) são suportadas e há limite de aninhamento?**

Sim. Cada comentário pode referenciar seu [parent comment](https://reference.aspose.com/slides/pt/python-net/aspose.slides/moderncomment/parent_comment/), permitindo cadeias de respostas arbitrárias. A API não declara um limite específico de profundidade de aninhamento.

**Em que sistema de coordenadas a posição do marcador de comentário é definida em um slide?**

A posição é armazenada como um ponto de ponto flutuante no sistema de coordenadas do slide. Isso permite que você coloque o marcador de comentário exatamente onde for necessário.