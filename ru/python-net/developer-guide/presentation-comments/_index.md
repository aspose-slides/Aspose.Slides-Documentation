---
title: У管理 презентации comment в Python
linktitle: Комментарии к презентации
type: docs
weight: 100
url: /ru/python-net/presentation-comments/
keywords:
- комментарий
- современный комментарий
- комментарии PowerPoint
- комментарии к презентации
- комментарии к слайдам
- добавить комментарий
- доступ к комментариям
- редактировать комментарий
- ответить на комментарий
- удалить комментарий
- удалить комментарий
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Освойте работу с комментариями презентаций с помощью Aspose.Slides for Python via .NET: быстро и легко добавляйте, читаете, редактируйте и удаляйте комментарии в файлах PowerPoint."
---

В PowerPoint комментарий отображается как заметка или аннотация на слайде. При нажатии на комментарий его содержимое или сообщения раскрываются. 

## **Почему добавлять комментарии к презентациям?**

Возможно, вы захотите использовать комментарии для предоставления отзывов или общения с коллегами при проверке презентаций.

Чтобы вы могли использовать комментарии в презентациях PowerPoint, Aspose.Slides for Python via .NET предоставляет

* Класс [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) , который содержит коллекцию авторов (из свойства [CommentAuthorCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/)). Авторы добавляют комментарии к слайдам. 
* Интерфейс [ICommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/icommentcollection/) , который содержит коллекцию комментариев для отдельных авторов. 
* Класс [IComment](https://reference.aspose.com/slides/python-net/aspose.slides/icomment/) , который содержит информацию об авторах и их комментариях: кто добавил комментарий, время его добавления, позицию комментария и т.д. 
* Класс [CommentAuthor](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/) , который содержит информацию об отдельных авторах: имя автора, его инициалы, комментарии, связанные с именем автора, и т.д. 

## **Добавить комментарий к слайду**
Этот пример кода на Python показывает, как добавить комментарий к слайду в презентации PowerPoint:
```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

# Создаёт экземпляр класса Presentation
with slides.Presentation() as presentation:
    # Добавляет пустой слайд
    presentation.slides.add_empty_slide(presentation.layout_slides[0])

    # Добавляет автора
    author = presentation.comment_authors.add_author("Jawad", "MF")

    # Устанавливает позицию для комментариев
    point = draw.PointF(0.2, 0.2)

    # Добавляет комментарий к слайду для автора на слайде 1
    author.comments.add_comment("Hello Jawad, this is slide comment", presentation.slides[0], point, datetime.date.today())

    # Добавляет комментарий к слайду для автора на слайде 2
    author.comments.add_comment("Hello Jawad, this is second slide comment", presentation.slides[1], point, datetime.date.today())

    # Доступ к ISlide 1
    slide = presentation.slides[0]

    # Когда в качестве аргумента передаётся null, комментарии всех авторов выводятся для выбранного слайда
    comments = slide.get_slide_comments(author)

    # Получает комментарий с индексом 0 для слайда 1
    str = comments[0].text

    presentation.save("Comments_out.pptx", slides.export.SaveFormat.PPTX)

    if comments.length > 0:
        # Выбирает коллекцию комментариев автора с индексом 0
        commentCollection = comments[0].author.comments
        print(commentCollection[0].text)
```


## **Получить комментарии слайда**
Этот пример кода на Python показывает, как получить существующий комментарий на слайде в презентации PowerPoint:
```python
import aspose.slides as slides

# Создаёт экземпляр класса Presentation
with slides.Presentation("Comments1.pptx") as presentation:
    for author in presentation.comment_authors:
        for comment in author.comments:
            print("ISlide :" + str(comment.slide.slide_number) + 
            " has comment: " + comment.text + 
            " with Author: " + comment.author.name + 
            " posted on time :" + str(comment.created_time) + "\n")
```


## **Ответы на комментарии**
Родительский комментарий — это верхний или оригинальный комментарий в иерархии комментариев или ответов. С помощью свойства `parent_comment` (из интерфейса [IComment](https://reference.aspose.com/slides/python-net/aspose.slides/icomment/)) вы можете установить или получить родительский комментарий. 

Этот пример кода на Python показывает, как добавлять комментарии и получать ответы на них:
```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

with slides.Presentation() as pres:
    # Добавляет комментарий
    author1 = pres.comment_authors.add_author("Author_1", "A.A.")
    comment1 = author1.comments.add_comment("comment1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    # Добавляет ответ к comment1
    author2 = pres.comment_authors.add_author("Autror_2", "B.B.")
    reply1 = author2.comments.add_comment("reply 1 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply1.parent_comment = comment1

    # Добавляет еще один ответ к comment1
    reply2 = author2.comments.add_comment("reply 2 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply2.parent_comment = comment1

    # Добавляет ответ к существующему ответу
    subReply = author1.comments.add_comment("subreply 3 for reply 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    subReply.parent_comment = reply2

    comment2 = author2.comments.add_comment("comment 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    comment3 = author2.comments.add_comment("comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    reply3 = author1.comments.add_comment("reply 4 for comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
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

    # Удаляет comment1 и все ответы на него
    comment1.remove()

    pres.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert color="warning" title="Attention" %}} 

* При использовании метода `Remove` (из интерфейса [IComment](https://reference.aspose.com/slides/python-net/aspose.slides/icomment/)) для удаления комментария также удаляются ответы на этот комментарий. 
* Если настройка `parent_comment` приводит к кольцевой ссылке, будет выброшено исключение `PptxEditException`.

{{% /alert %}}

## **Добавить современный комментарий**

В 2021 году Microsoft внедрила *современные комментарии* в PowerPoint. Функция современных комментариев значительно улучшает совместную работу в PowerPoint. С помощью современных комментариев пользователи PowerPoint могут решать комментарии, привязывать их к объектам и тексту и взаимодействовать намного проще, чем раньше. 

Мы реализовали поддержку современных комментариев, добавив класс [ModernComment](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/). Методы `add_modern_comment` и `insert_modern_comment` были добавлены в класс [CommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/). 

Этот пример кода на Python показывает, как добавить современный комментарий к слайду в презентации PowerPoint:
```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as pres:
    newAuthor = pres.comment_authors.add_author("Some Author", "SA")
    modernComment = newAuthor.comments.add_modern_comment("This is a modern comment", pres.slides[0], None, draw.PointF(100, 100), date.today())

    pres.save("example.pptx", slides.export.SaveFormat.PPTX)
```


## **Удалить комментарий**

### **Удалить все комментарии и авторов**

Этот пример кода на Python показывает, как удалить все комментарии и авторов в презентации:
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

Этот пример кода на Python показывает, как удалить конкретные комментарии на слайде:
```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    # добавить комментарии...
    author = presentation.comment_authors.add_author("Author", "A")
    author.comments.add_comment("comment 1", slide, draw.PointF(0.2, 0.2), date.today())
    author.comments.add_comment("comment 2", slide, draw.PointF(0.3, 0.2), date.today())
    
    # удалить все комментарии, содержащие текст "comment 1"
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

**Поддерживает ли Aspose.Slides статус, например, 'решено', для современных комментариев?**

Да. [Современные комментарии](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/) предоставляют свойство [status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/); вы можете читать и задавать [состояние комментария](https://reference.aspose.com/slides/python-net/aspose.slides/moderncommentstatus/) (например, пометить его как решённое), и это состояние сохраняется в файле и распознаётся PowerPoint.

**Поддерживаются ли обсуждения в виде цепочек ответов, и существует ли ограничение вложенности?**

Да. Каждый комментарий может ссылаться на свой [parent comment](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/parent_comment/), что позволяет создавать произвольные цепочки ответов. API не объявляет конкретного предела глубины вложенности.

**В какой системе координат определяется позиция маркера комментария на слайде?**

Позиция хранится как точка с плавающей запятой в системе координат слайда. Это позволяет разместить маркер комментария точно там, где это необходимо.