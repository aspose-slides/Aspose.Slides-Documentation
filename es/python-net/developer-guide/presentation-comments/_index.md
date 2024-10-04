---
title: Comentarios de Presentación
type: docs
weight: 100
url: /python-net/presentation-comments/
keywords: "Comentarios, comentarios de PowerPoint, presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Agregar comentarios y respuestas en la presentación de PowerPoint en Python"
---

En PowerPoint, un comentario aparece como una nota o anotación en una diapositiva. Al hacer clic en un comentario, se revelan su contenido o mensajes.

### **¿Por qué agregar comentarios a las presentaciones?**

Es posible que desee usar comentarios para proporcionar retroalimentación o comunicarse con sus colegas al revisar presentaciones.

Para permitirle usar comentarios en presentaciones de PowerPoint, Aspose.Slides para Python a través de .NET proporciona

* La clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), que contiene las colecciones de autores (de la propiedad [CommentAuthorCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/)). Los autores añaden comentarios a las diapositivas. 
* La interfaz [ICommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/icommentcollection/), que contiene la colección de comentarios para autores individuales. 
* La clase [IComment](https://reference.aspose.com/slides/python-net/aspose.slides/icomment/), que contiene información sobre los autores y sus comentarios: quién añadió el comentario, la hora en que se añadió el comentario, la posición del comentario, etc. 
* La clase [CommentAuthor](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/), que contiene información sobre autores individuales: el nombre del autor, sus iniciales, comentarios asociados con el nombre del autor, etc. 

## **Agregar comentario a la diapositiva**
Este código de Python muestra cómo agregar un comentario a una diapositiva en una presentación de PowerPoint:

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

# Instancia la clase Presentation
with slides.Presentation() as presentation:
    # Agrega una diapositiva vacía
    presentation.slides.add_empty_slide(presentation.layout_slides[0])

    # Agrega un autor
    author = presentation.comment_authors.add_author("Jawad", "MF")

    # Establece la posición para los comentarios
    point = draw.PointF(0.2, 0.2)

    # Agrega un comentario de diapositiva para un autor en la diapositiva 1
    author.comments.add_comment("Hola Jawad, este es un comentario de diapositiva", presentation.slides[0], point, datetime.date.today())

    # Agrega un comentario de diapositiva para un autor en la diapositiva 2
    author.comments.add_comment("Hola Jawad, este es el segundo comentario de diapositiva", presentation.slides[1], point, datetime.date.today())

    # Accediendo a la ISlide 1
    slide = presentation.slides[0]

    # Cuando se pasa null como argumento, se traen los comentarios de todos los autores a la diapositiva seleccionada
    comments = slide.get_slide_comments(author)

    # Accede al comentario en el índice 0 para la diapositiva 1
    str = comments[0].text

    presentation.save("Comments_out.pptx", slides.export.SaveFormat.PPTX)

    if comments.length > 0:
        # Selecciona la colección de comentarios del autor en el índice 0
        commentCollection = comments[0].author.comments
        print(commentCollection[0].text)
```



## **Acceder a los comentarios de la diapositiva**
Este código de Python muestra cómo acceder a un comentario existente en una diapositiva en una presentación de PowerPoint:

```python
import aspose.slides as slides

# Instancia la clase Presentation
with slides.Presentation("Comments1.pptx") as presentation:
    for author in presentation.comment_authors:
        for comment in author.comments:
            print("ISlide :" + str(comment.slide.slide_number) + 
            " tiene comentario: " + comment.text + 
            " con Autor: " + comment.author.name + 
            " publicado a la hora :" + str(comment.created_time) + "\n")
```


## **Responder comentarios**
Un comentario principal es el comentario original o superior en una jerarquía de comentarios o respuestas. Usando la propiedad `parent_comment` (de la interfaz [IComment](https://reference.aspose.com/slides/python-net/aspose.slides/icomment/)), puede establecer o obtener un comentario principal. 

Este código de Python muestra cómo agregar comentarios y obtener respuestas a ellos:

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

with slides.Presentation() as pres:
    # Agrega un comentario
    author1 = pres.comment_authors.add_author("Author_1", "A.A.")
    comment1 = author1.comments.add_comment("comentario1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    # Agrega una respuesta a comment1
    author2 = pres.comment_authors.add_author("Autor_2", "B.B.")
    reply1 = author2.comments.add_comment("respuesta 1 para comentario 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply1.parent_comment = comment1

    # Agrega otra respuesta a comment1
    reply2 = author2.comments.add_comment("respuesta 2 para comentario 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply2.parent_comment = comment1

    # Agrega una respuesta a respuesta existente
    subReply = author1.comments.add_comment("subrespuesta 3 para respuesta 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    subReply.parent_comment = reply2

    comment2 = author2.comments.add_comment("comentario 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    comment3 = author2.comments.add_comment("comentario 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    reply3 = author1.comments.add_comment("respuesta 4 para comentario 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply3.parent_comment = comment3

    # Muestra la jerarquía de comentarios en la consola
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

    # Elimina comment1 y todas las respuestas a él
    comment1.remove()

    pres.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Atención" %}} 

* Cuando se usa el método `Remove` (de la interfaz [IComment](https://reference.aspose.com/slides/python-net/aspose.slides/icomment/) para eliminar un comentario, las respuestas al comentario también se eliminan. 
* Si la configuración `parent_comment` resulta en una referencia circular, se lanzará una `PptxEditException`.

{{% /alert %}}

## **Agregar comentario moderno**

En 2021, Microsoft introdujo *comentarios modernos* en PowerPoint. La función de comentarios modernos mejora significativamente la colaboración en PowerPoint. A través de comentarios modernos, los usuarios de PowerPoint pueden resolver comentarios, anclar comentarios a objetos y textos, y participar en interacciones de manera mucho más fácil que antes. 

Implementamos el soporte para comentarios modernos agregando la clase [ModernComment](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/). Se añadieron los métodos `add_modern_comment` e `insert_modern_comment` a la clase [CommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/). 

Este código de Python muestra cómo agregar un comentario moderno a una diapositiva en una presentación de PowerPoint:

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as pres:
    newAuthor = pres.comment_authors.add_author("Algún Autor", "SA")
    modernComment = newAuthor.comments.add_modern_comment("Este es un comentario moderno", pres.slides[0], None, draw.PointF(100, 100), date.today())

    pres.save("example.pptx", slides.export.SaveFormat.PPTX)
```

## **Eliminar comentario**

### **Eliminar todos los comentarios y autores**

Este código de Python muestra cómo eliminar todos los comentarios y autores en una presentación:

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    # Elimina todos los comentarios de la presentación
    for author in presentation.comment_authors:
        author.comments.clear()

    # Elimina todos los autores
    presentation.comment_authors.clear()

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Eliminar comentarios específicos**

Este código de Python muestra cómo eliminar comentarios específicos en una diapositiva:

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    # agregar comentarios...
    author = presentation.comment_authors.add_author("Autor", "A")
    author.comments.add_comment("comentario 1", slide, draw.PointF(0.2, 0.2), date.today())
    author.comments.add_comment("comentario 2", slide, draw.PointF(0.3, 0.2), date.today())
    
    # eliminar todos los comentarios que contengan el texto "comentario 1"
    for commentAuthor in presentation.comment_authors:
        toRemove = []
        for comment in slide.get_slide_comments(commentAuthor):
            if comment.text == "comentario 1":
                toRemove.append(comment)
        
        for comment in toRemove:
            commentAuthor.comments.remove(comment)
    
    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```