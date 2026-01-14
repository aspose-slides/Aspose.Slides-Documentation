---
title: Gestionar comentarios de presentaciones en Python
linktitle: Comentarios de presentación
type: docs
weight: 100
url: /es/python-net/presentation-comments/
keywords:
- comentario
- comentario moderno
- comentarios de PowerPoint
- comentarios de presentación
- comentarios de diapositiva
- añadir comentario
- acceder al comentario
- editar comentario
- responder comentario
- eliminar comentario
- borrar comentario
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Domina los comentarios de presentaciones con Aspose.Slides para Python mediante .NET: añade, lee, edita y elimina comentarios en archivos de PowerPoint de forma rápida y sencilla."
---

En PowerPoint, un comentario aparece como una nota o anotación en una diapositiva. Cuando se hace clic en un comentario, su contenido o mensajes se revelan. 

## **¿Por qué añadir comentarios a las presentaciones?**

Puede que desee usar comentarios para proporcionar retroalimentación o comunicarse con sus colegas al revisar presentaciones.

Para permitirle usar comentarios en presentaciones de PowerPoint, Aspose.Slides for Python a través de .NET ofrece

* La clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) , que contiene las colecciones de autores (del atributo [CommentAuthorCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/)). Los autores añaden comentarios a las diapositivas. 
* La clase [CommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/) , que contiene la colección de comentarios para autores individuales. 
* La clase [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) , que contiene información sobre los autores y sus comentarios: quién añadió el comentario, la hora en que se añadió, la posición del comentario, etc. 
* La clase [CommentAuthor](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/) , que contiene información sobre autores individuales: el nombre del autor, sus iniciales, los comentarios asociados al nombre del autor, etc. 

## **Añadir comentario a la diapositiva**
Este código Python muestra cómo añadir un comentario a una diapositiva en una presentación de PowerPoint:
```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

    # Instancia la clase Presentation
    # Añade una diapositiva vacía
    # Añade un autor
    # Establece la posición de los comentarios
    # Añade un comentario de diapositiva para un autor en la diapositiva 1
    # Añade un comentario de diapositiva para un autor en la diapositiva 2
    # Accediendo a ISlide 1
    # Cuando se pasa null como argumento, se traen los comentarios de todos los autores a la diapositiva seleccionada
    # Accede al comentario en el índice 0 de la diapositiva 1
    # Accessing ISlide 1
    # When null is passed as an argument, comments from all authors are brought to the selected slide
    # Accesses the comment at index 0 for slide 1

    with slides.Presentation() as presentation:
        # Adds an empty slide
        presentation.slides.add_empty_slide(presentation.layout_slides[0])

        # Adds an author
        author = presentation.comment_authors.add_author("Jawad", "MF")

        # Sets the position for comments
        point = draw.PointF(0.2, 0.2)

        # Adds slide comment for an author on slide 1
        author.comments.add_comment("Hello Jawad, this is slide comment", presentation.slides[0], point, datetime.date.today())

        # Adds slide comment for an author on slide 2
        author.comments.add_comment("Hello Jawad, this is second slide comment", presentation.slides[1], point, datetime.date.today())

        # Accessing ISlide 1
        slide = presentation.slides[0]

        # When null is passed as an argument, comments from all authors are brought to the selected slide
        comments = slide.get_slide_comments(author)

        # Accesses the comment at index 0 for slide 1
        str = comments[0].text

        presentation.save("Comments_out.pptx", slides.export.SaveFormat.PPTX)

        if comments.length > 0:
            # Selects the Author's comments collection at index 0
            commentCollection = comments[0].author.comments
            print(commentCollection[0].text)
```




## **Acceder a los comentarios de la diapositiva**
Este código Python muestra cómo acceder a un comentario existente en una diapositiva de una presentación de PowerPoint:
```python
import aspose.slides as slides

# Instancia la clase Presentation
with slides.Presentation("Comments1.pptx") as presentation:
    for author in presentation.comment_authors:
        for comment in author.comments:
            print("ISlide :" + str(comment.slide.slide_number) + 
            " has comment: " + comment.text + 
            " with Author: " + comment.author.name + 
            " posted on time :" + str(comment.created_time) + "\n")
```



## **Responder a comentarios**

Un comentario padre es el comentario principal u original en una jerarquía de comentarios o respuestas. Usando la propiedad `parent_comment` (de la clase [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/)), puede establecer o obtener un comentario padre. 

Este código Python muestra cómo añadir comentarios y obtener respuestas a los mismos:
```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

with slides.Presentation() as pres:
    # Añade un comentario
    author1 = pres.comment_authors.add_author("Author_1", "A.A.")
    comment1 = author1.comments.add_comment("comment1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    # Añade una respuesta al comentario1
    author2 = pres.comment_authors.add_author("Autror_2", "B.B.")
    reply1 = author2.comments.add_comment("reply 1 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply1.parent_comment = comment1

    # Añade otra respuesta al comentario1
    reply2 = author2.comments.add_comment("reply 2 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply2.parent_comment = comment1

    # Añade una respuesta a la respuesta existente
    subReply = author1.comments.add_comment("subreply 3 for reply 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    subReply.parent_comment = reply2

    comment2 = author2.comments.add_comment("comment 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    comment3 = author2.comments.add_comment("comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    reply3 = author1.comments.add_comment("reply 4 for comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
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

    # Elimina el comentario1 y todas sus respuestas
    comment1.remove()

    pres.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert color="warning" title="Atención" %}} 

* Cuando se usa el método `remove` (de la clase [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/)) para eliminar un comentario, también se eliminan las respuestas al comentario. 
* Si la configuración `parent_comment` da lugar a una referencia circular, se lanzará `PptxEditException`.

{{% /alert %}}

## **Añadir comentario moderno**

En 2021, Microsoft introdujo *comentarios modernos* en PowerPoint. La función de comentarios modernos mejora significativamente la colaboración en PowerPoint. Gracias a los comentarios modernos, los usuarios de PowerPoint pueden resolver comentarios, anclar comentarios a objetos y textos, y participar en interacciones de forma mucho más sencilla que antes. 

Implementamos compatibilidad con comentarios modernos añadiendo la clase [ModernComment](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/). Los métodos `add_modern_comment` e `insert_modern_comment` se añadieron a la clase [CommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/). 

Este código Python muestra cómo añadir un comentario moderno a una diapositiva en una presentación de PowerPoint:
```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as pres:
    newAuthor = pres.comment_authors.add_author("Some Author", "SA")
    modernComment = newAuthor.comments.add_modern_comment("This is a modern comment", pres.slides[0], None, draw.PointF(100, 100), date.today())

    pres.save("example.pptx", slides.export.SaveFormat.PPTX)
```


## **Eliminar comentario**

### **Eliminar todos los comentarios y autores**

Este código Python muestra cómo eliminar todos los comentarios y autores en una presentación:
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

Este código Python muestra cómo eliminar comentarios específicos en una diapositiva:
```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    # añadir comentarios...
    author = presentation.comment_authors.add_author("Author", "A")
    author.comments.add_comment("comment 1", slide, draw.PointF(0.2, 0.2), date.today())
    author.comments.add_comment("comment 2", slide, draw.PointF(0.3, 0.2), date.today())
    
    # eliminar todos los comentarios que contengan el texto "comment 1"
    for commentAuthor in presentation.comment_authors:
        toRemove = []
        for comment in slide.get_slide_comments(commentAuthor):
            if comment.text == "comment 1":
                toRemove.append(comment)
        
        for comment in toRemove:
            commentAuthor.comments.remove(comment)
    
    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```


## **Preguntas frecuentes**

**¿Aspose.Slides admite un estado como 'resuelto' para los comentarios modernos?**

Sí. Los [comentarios modernos](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/) exponen una propiedad [status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/); puede leer y establecer el [estado del comentario](https://reference.aspose.com/slides/python-net/aspose.slides/moderncommentstatus/) (por ejemplo, marcarlo como resuelto), y este estado se guarda en el archivo y es reconocido por PowerPoint.

**¿Se admiten discusiones en hilos (cadenas de respuestas) y hay un límite de anidación?**

Sí. Cada comentario puede referenciar su [comentario padre](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/parent_comment/), lo que permite cadenas de respuestas arbitrarias. La API no declara un límite específico de profundidad de anidación.

**¿En qué sistema de coordenadas se define la posición del marcador de comentario en una diapositiva?**

La posición se almacena como un punto de coma flotante en el sistema de coordenadas de la diapositiva. Esto le permite colocar el marcador de comentario exactamente donde lo necesita.