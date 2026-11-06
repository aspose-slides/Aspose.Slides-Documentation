---
title: Gerenciar comentários de apresentação em Python
linktitle: Comentários de apresentação
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
description: "Gerenciar comentários de apresentação com Aspose.Slides for Python via .NET: adicionar, ler, editar, responder e remover comentários em apresentações do PowerPoint."
---
## **Visão geral**

Este artigo explica como gerenciar comentários de apresentações com Aspose.Slides for Python via .NET. Ele apresenta os principais tipos relacionados a comentários e demonstra como adicionar comentários aos slides, acessar comentários existentes, trabalhar com respostas e comentários modernos, e remover comentários de uma apresentação.

Os exemplos cobrem cenários comuns de revisão e colaboração no PowerPoint, como atribuir comentários a autores, ler o texto e os metadados do comentário, construir cadeias de respostas e remover comentários selecionados ou todos os comentários.

No PowerPoint, os comentários aparecem como anotações nos slides. Selecionar um comentário exibe seu texto e a discussão relacionada.

Para solicitar que comentários sejam mostrados ou ocultados ao abrir uma apresentação sem alterar os próprios comentários, veja [Mostrar ou ocultar comentários ao abrir uma apresentação](/slides/pt/python-net/presentation-view-properties/).

## **Por que adicionar comentários às apresentações?**

Você pode usar comentários para fornecer feedback e colaborar com colegas ao revisar apresentações.

Aspose.Slides for Python via .NET fornece as seguintes APIs para trabalhar com comentários:

* A [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class, que fornece acesso aos autores de comentários da apresentação.
* A [CommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/) class, que representa os comentários associados a um autor individual.
* A [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) class, que fornece informações sobre um comentário, incluindo seu autor, horário de criação, posição e texto.
* A [CommentAuthor](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/) class, que fornece informações sobre um autor, incluindo seu nome, iniciais e comentários associados.

## **Adicionar comentários de slide**

O exemplo cria dois slides e registra um autor de comentário com [add_author](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/add_author/). Ele usa [add_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_comment/) para colocar um comentário em cada slide, depois recupera os comentários do primeiro slide para esse autor com [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/). O console exibe o texto do primeiro comentário duas vezes, demonstrando o acesso tanto pelo slide quanto pelo autor, e a apresentação salva contém ambos os comentários.

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

## **Encontrar ou criar um autor de comentário**

Quando uma revisão automatizada processa a mesma apresentação repetidamente, pesquise sua coleção [comment_authors](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/comment_authors/) antes de adicionar um autor. [find_by_name_and_initials](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/find_by_name_and_initials/) corresponde tanto ao nome quanto às iniciais e retorna uma matriz de autores correspondentes, ou uma matriz vazia se não houver correspondências. Em contraste, [find_by_name](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/find_by_name/) pesquisa apenas por nome, independentemente das iniciais. Chamar [add_author](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/add_author/) com um nome e iniciais já presentes na coleção lança uma exceção.

O exemplo requer um arquivo de apresentação com pelo menos um slide. Em cada uma das duas passagens, ele reutiliza o primeiro autor correspondente, ou cria um apenas quando o resultado está vazio. Se houver várias correspondências, ele seleciona o primeiro elemento da matriz sem mesclar ou remover os outros autores. Em seguida, ele chama [add_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_comment/) para o autor selecionado e salva a apresentação. A segunda passagem abre a saída da primeira passagem e repete a operação.

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

A segunda passagem adiciona outro comentário sem adicionar outro autor ou remover comentários existentes. O arquivo final, `review_pass_2.pptx`, contém ambos os novos comentários junto com quaisquer comentários originais. Reutilizar um autor não deduplica comentários: para evitar adicionar repetidamente o mesmo comentário, implemente uma detecção de duplicatas separada antes de adicioná‑lo.

## **Acessar comentários de slide**

O exemplo abre uma apresentação existente e lê sua coleção [comment_authors](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/comment_authors/). Para cada autor, ele itera pelos [comments](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/comments/) e imprime o número do slide, o texto do comentário, o nome do autor e o horário de criação. A apresentação de entrada deve conter comentários para gerar saída no console.

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

## **Responder a comentários**

Um comentário pai é o comentário original no topo de uma hierarquia de respostas. A propriedade [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) da classe [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) permite obter ou definir o pai de um comentário.

O exemplo cria comentários de dois autores e usa [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) para construir respostas, incluindo uma resposta a outra resposta. Passar `None` para [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/) recupera comentários de todos os autores; o console indenta cada entrada de acordo com sua profundidade na hierarquia de respostas. O exemplo salva a discussão completa, chama [remove](https://reference.aspose.com/slides/python-net/aspose.slides/comment/remove/) no primeiro comentário raiz e salva uma segunda apresentação com esse comentário e suas respostas removidos.

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
* Quando o método [remove](https://reference.aspose.com/slides/python-net/aspose.slides/comment/remove/) da classe [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) é usado para excluir um comentário, todas as respostas a esse comentário também são excluídas.
* Se a propriedade [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) cria uma referência circular, uma [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/) é lançada.
{{% /alert %}}

## **Adicionar comentários modernos**

Comentários modernos podem ser associados ao próprio slide, a uma forma específica ou a um intervalo de texto dentro de um AutoShape. O método [CommentCollection.add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) aceita um argumento [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) além do slide e das coordenadas do marcador de comentário.

Quando `None` é passado para o argumento shape, o comentário é um comentário de nível de slide. Seu marcador é posicionado pelas coordenadas fornecidas, mas não está associado a uma forma específica, portanto [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/) retorna `None`. Quando uma [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) é fornecida, o comentário é ancorado a essa forma. As coordenadas ainda definem a posição do marcador de comentário no slide, enquanto a associação de forma pode ser obtida através de [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/).

### **Ancorar um comentário moderno a uma forma**

O exemplo chama [add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) duas vezes: uma com uma forma `None` para um comentário de nível de slide e outra com um retângulo como âncora. Ler [shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/) imprime `True` para a verificação nula do comentário de nível de slide e `Revenue title` para o comentário ancorado. Ambos os comentários são salvos com a apresentação.

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

### **Ancorar comentários a diferentes tipos de forma**

Qualquer objeto de slide derivado de [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) pode ser usado como âncora de forma. Exemplos comuns incluem instâncias de [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/python-net/aspose.slides/connector/) e [GraphicalObject](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobject/) como gráficos.

O exemplo usa [add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) para associar um comentário a cada um dos cinco tipos de forma: um AutoShape, uma moldura de imagem, um grupo, um conector e um gráfico. A imagem usa dados de imagem incorporados, portanto não é necessária imagem externa. Cada comentário tem sua própria posição de marcador, e a apresentação salva mantém as cinco associações de forma.

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

### **Ancorar um comentário a texto e definir seu status**

Para um comentário moderno associado a um [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/), [ModernComment.text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/) especifica a posição inicial do texto selecionado no quadro de texto da forma, enquanto [ModernComment.text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) especifica o comprimento da seleção. Juntas, essas propriedades associam o comentário a um intervalo de texto específico dentro do AutoShape.

A propriedade [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) pode ser lida ou atualizada com um valor da enumeração [ModernCommentStatus](https://reference.aspose.com/slides/python-net/aspose.slides/moderncommentstatus/):

- `NOT_DEFINED` — nenhum status de comentário moderno específico está definido.
- `ACTIVE` — o comentário está ativo.
- `RESOLVED` — o comentário foi resolvido.
- `CLOSED` — o comentário está fechado.

O exemplo ancora um comentário moderno às palavras "quarterly revenue" no texto de um retângulo. Ele calcula o [text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/) baseado em zero a partir do texto e define [text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) como o número de caracteres selecionados. Após definir [status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) para `RESOLVED`, ele salva e reabre a apresentação. As quatro verificações no console devem imprimir `True`, confirmando que a âncora da forma, o intervalo de texto e o status foram preservados.

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

### **Inspecionar comentários modernos existentes**

O exemplo requer uma apresentação existente contendo comentários modernos e imprime seu texto, status e detalhes da âncora. Para inspecioná‑la, verifique quais comentários são instâncias de [ModernComment](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/), então examine [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/), [ModernComment.text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/), [ModernComment.text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) e [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/). Uma forma `None` indica um comentário de nível de slide. Para uma âncora [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/), as propriedades de seleção de texto identificam o intervalo associado no quadro de texto da forma.

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

## **Remover comentários**

Aspose.Slides for Python via .NET permite remover todos os comentários e seus autores de uma apresentação ou excluir comentários selecionados mantendo o restante. Os exemplos a seguir demonstram ambas as abordagens e salvam a apresentação atualizada.

### **Remover todos os comentários e autores de comentários**

O exemplo abre uma apresentação existente e chama [CommentCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/clear/) para cada autor, depois chama [CommentAuthorCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/clear/) para remover os próprios autores. A apresentação salva não contém nem comentários nem autores de comentários. Use uma apresentação contendo comentários para observar a remoção.

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    for author in presentation.comment_authors:
        author.comments.clear()

    presentation.comment_authors.clear()

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Remover comentários específicos**

O exemplo cria dois comentários em um slide e usa [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/) para encontrar comentários de cada autor. Ele coleta comentários cujo texto seja "comment 1" antes de chamar [CommentCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/remove/), evitando alterações na coleção durante a seleção. A apresentação salva retém apenas "comment 2".

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

## **FAQ**

**O Aspose.Slides oferece suporte a um status resolvido para comentários modernos?**

Sim. [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) pode ser lido e definido com um valor [ModernCommentStatus](https://reference.aspose.com/slides/python-net/aspose.slides/moderncommentstatus/), incluindo `RESOLVED`. O status é armazenado na apresentação e pode ser lido novamente após o arquivo ser reaberto.

**As discussões em thread (cadeias de respostas) são suportadas, e existe um limite de aninhamento?**

Sim. Cada comentário pode referenciar seu [parent comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/), permitindo cadeias de respostas. A API não define um limite específico de profundidade de aninhamento.

**Em qual sistema de coordenadas a posição do marcador de comentário é definida em um slide?**

A posição do marcador é definida por coordenadas de ponto flutuante no sistema de coordenadas do slide, permitindo posicioná‑lo precisamente no slide.