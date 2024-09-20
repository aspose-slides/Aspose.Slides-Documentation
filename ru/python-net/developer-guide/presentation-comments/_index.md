---
title: Комментарии к презентации
type: docs
weight: 100
url: /python-net/presentation-comments/
keywords: "Комментарии, комментарии PowerPoint, презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Добавляйте комментарии и ответы в презентации PowerPoint на Python"
---

В PowerPoint комментарий появляется как заметка или аннотация на слайде. Когда комментарий щелкают, его содержимое или сообщения становятся видимыми. 

### **Почему стоит добавлять комментарии к презентациям?**

Вы можете захотеть использовать комментарии, чтобы предоставить отзывы или общаться с коллегами, когда вы просматриваете презентации.

Чтобы вы могли использовать комментарии в презентациях PowerPoint, Aspose.Slides для Python через .NET предоставляет

* Класс [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), который содержит коллекции авторов (из свойства [CommentAuthorCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/)). Авторы добавляют комментарии к слайдам. 
* Интерфейс [ICommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/icommentcollection/), который содержит коллекцию комментариев для отдельных авторов. 
* Класс [IComment](https://reference.aspose.com/slides/python-net/aspose.slides/icomment/), который содержит информацию об авторах и их комментариях: кто добавил комментарий, время добавления комментария, позиция комментария и т.д. 
* Класс [CommentAuthor](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/), который содержит информацию об отдельных авторах: имя автора, его инициалы, комментарии, связанные с именем автора, и т.д. 

## **Добавить комментарий к слайду**
Этот код на Python показывает, как добавить комментарий к слайду в презентации PowerPoint:

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

# Создание экземпляра класса Presentation
with slides.Presentation() as presentation:
    # Добавляет пустой слайд
    presentation.slides.add_empty_slide(presentation.layout_slides[0])

    # Добавляет автора
    author = presentation.comment_authors.add_author("Jawad", "MF")

    # Устанавливает позицию для комментариев
    point = draw.PointF(0.2, 0.2)

    # Добавляет комментарий к слайду для автора на слайде 1
    author.comments.add_comment("Привет, Jawad, это комментарий к слайду", presentation.slides[0], point, datetime.date.today())

    # Добавляет комментарий к слайду для автора на слайде 2
    author.comments.add_comment("Привет, Jawad, это второй комментарий к слайду", presentation.slides[1], point, datetime.date.today())

    # Доступ к ISlide 1
    slide = presentation.slides[0]

    # Когда null передается в качестве аргумента, комментарии от всех авторов извлекаются для выбранного слайда
    comments = slide.get_slide_comments(author)

    # Доступ к комментарию по индексу 0 для слайда 1
    str = comments[0].text

    presentation.save("Comments_out.pptx", slides.export.SaveFormat.PPTX)

    if comments.length > 0:
        # Выбирает коллекцию комментариев автора по индексу 0
        commentCollection = comments[0].author.comments
        print(commentCollection[0].text)
```



## **Доступ к комментариям на слайде**
Этот код на Python показывает, как получить доступ к существующему комментарию на слайде в презентации PowerPoint:

```python
import aspose.slides as slides

# Создание экземпляра класса Presentation
with slides.Presentation("Comments1.pptx") as presentation:
    for author in presentation.comment_authors:
        for comment in author.comments:
            print("ISlide :" + str(comment.slide.slide_number) + 
            " имеет комментарий: " + comment.text + 
            " от автора: " + comment.author.name + 
            " опубликовано в: " + str(comment.created_time) + "\n")
```


## **Ответы на комментарии**
Родительский комментарий - это верхний или оригинальный комментарий в иерархии комментариев или ответов. С помощью свойства `parent_comment` (из интерфейса [IComment](https://reference.aspose.com/slides/python-net/aspose.slides/icomment/)) вы можете установить или получить родительский комментарий. 

Этот код на Python показывает, как добавлять комментарии и получать ответы на них:

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

with slides.Presentation() as pres:
    # Добавляет комментарий
    author1 = pres.comment_authors.add_author("Author_1", "A.A.")
    comment1 = author1.comments.add_comment("комментарий 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    # Добавляет ответ на comment1
    author2 = pres.comment_authors.add_author("Autror_2", "B.B.")
    reply1 = author2.comments.add_comment("ответ 1 на комментарий 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply1.parent_comment = comment1

    # Добавляет еще один ответ на comment1
    reply2 = author2.comments.add_comment("ответ 2 на комментарий 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply2.parent_comment = comment1

    # Добавляет ответ на существующий ответ
    subReply = author1.comments.add_comment("подответ 3 на ответ 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    subReply.parent_comment = reply2

    comment2 = author2.comments.add_comment("комментарий 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    comment3 = author2.comments.add_comment("комментарий 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    reply3 = author1.comments.add_comment("ответ 4 на комментарий 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply3.parent_comment = comment3

    # Выводит иерархию комментариев в консоль
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

    # Удаляет comment1 и все его ответы
    comment1.remove()

    pres.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Внимание" %}} 

* Когда метод `Remove` (из интерфейса [IComment](https://reference.aspose.com/slides/python-net/aspose.slides/icomment/)) используется для удаления комментария, ответы на комментарий также удаляются. 
* Если настройка `parent_comment` приводит к циклической ссылке, будет выброшено исключение `PptxEditException`.

{{% /alert %}}

## **Добавить современный комментарий**

В 2021 году Microsoft представила *современные комментарии* в PowerPoint. Функция современных комментариев значительно улучшает совместную работу в PowerPoint. Через современные комментарии пользователи PowerPoint могут решать комментарии, привязывать комментарии к объектам и текстам, а также легче взаимодействовать, чем когда-либо прежде. 

Мы реализовали поддержку современных комментариев, добавив класс [ModernComment](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/). Методы `add_modern_comment` и `insert_modern_comment` были добавлены в класс [CommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/). 

Этот код на Python показывает, как добавить современный комментарий к слайду в презентации PowerPoint:

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as pres:
    newAuthor = pres.comment_authors.add_author("Некоторый Автор", "SA")
    modernComment = newAuthor.comments.add_modern_comment("Это современный комментарий", pres.slides[0], None, draw.PointF(100, 100), date.today())

    pres.save("example.pptx", slides.export.SaveFormat.PPTX)
```

## **Удалить комментарий**

### **Удалить все комментарии и авторов**

Этот код на Python показывает, как удалить все комментарии и авторов в презентации:

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    # Удаляет все комментарии из презентации
    for author in presentation.comment_authors:
        author.comments.clear()

    # Удаляет всех авторов
    presentation.comment_authors.clear()

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Удалить конкретные комментарии**

Этот код на Python показывает, как удалить конкретные комментарии на слайде:

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    # добавление комментариев...
    author = presentation.comment_authors.add_author("Автор", "A")
    author.comments.add_comment("комментарий 1", slide, draw.PointF(0.2, 0.2), date.today())
    author.comments.add_comment("комментарий 2", slide, draw.PointF(0.3, 0.2), date.today())
    
    # удаление всех комментариев, которые содержат текст "комментарий 1"
    for commentAuthor in presentation.comment_authors:
        toRemove = []
        for comment in slide.get_slide_comments(commentAuthor):
            if comment.text == "комментарий 1":
                toRemove.append(comment)
        
        for comment in toRemove:
            commentAuthor.comments.remove(comment)
    
    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```