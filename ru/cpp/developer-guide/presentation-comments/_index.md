---
title: Управление комментариями презентации в C++
linktitle: Комментарии к презентации
type: docs
weight: 100
url: /ru/cpp/presentation-comments/
keywords:
- комментарий
- современный комментарий
- комментарии PowerPoint
- комментарии к презентации
- комментарии к слайду
- добавить комментарий
- доступ к комментарию
- редактировать комментарий
- ответ на комментарий
- удалить комментарий
- удалить комментарий
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Управляйте комментариями презентаций с помощью Aspose.Slides for C++: добавляйте, читайте, редактируйте и удаляйте комментарии в файлах PowerPoint быстро и легко."
---

В PowerPoint комментарий отображается как заметка или аннотация на слайде. При щелчке по комментарии его содержимое или сообщения раскрываются. 

### **Зачем добавлять комментарии к презентациям?**

Возможно, вы захотите использовать комментарии для предоставления обратной связи или общения с коллегами при просмотре презентаций.

Чтобы вы могли использовать комментарии в презентациях PowerPoint, Aspose.Slides for C++ предоставляет

* Класс [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation), который содержит коллекции авторов (из метода [get_CommentAuthors()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#ac100feeb13ea426b85557a829676227d)). Авторы добавляют комментарии к слайдам. 
* Интерфейс [ICommentCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment_collection), который содержит коллекцию комментариев для отдельных авторов. 
* Класс [IComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment), который содержит информацию об авторах и их комментариях: кто добавил комментарий, время его добавления, позиция комментария и т.д. 
* Класс [CommentAuthor](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_author), который содержит информацию об отдельных авторах: имя автора, его инициалы, комментарии, связанные с именем автора, и т.д. 

## **Добавить комментарий к слайду**
Этот код C++ показывает, как добавить комментарий к слайду в презентации PowerPoint:
```cpp
// Создает экземпляр класса Presentation
auto presentation = System::MakeObject<Presentation>();
// Добавляет пустой слайд
presentation->get_Slides()->AddEmptySlide(presentation->get_LayoutSlides()->idx_get(0));

// Добавляет автора
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Jawad", u"MF");

// Устанавливает позицию комментариев
PointF point;
point.set_X(0.2f);
point.set_Y(0.2f);

// Получает ISlide 1
auto slide1 = presentation->get_Slides()->idx_get(0);
// Получает ISlide 2
auto slide2 = presentation->get_Slides()->idx_get(1);

// Добавляет комментарий к слайду для автора на слайде 1
author->get_Comments()->AddComment(u"Hello Jawad, this is slide comment", slide1, point, DateTime::get_Now());

// Добавляет комментарий к слайду для автора на слайде 2
author->get_Comments()->AddComment(u"Hello Jawad, this is second slide comment", slide2, point, DateTime::get_Now());

// Если в качестве аргумента передан null, комментарии от всех авторов выводятся на выбранный слайд
auto comments = slide1->GetSlideComments(author);

// Accesses the comment at index 0 for slide 1
String str = comments[0]->get_Text();

presentation->Save(u"Comments_out.pptx", SaveFormat::Pptx);

if (comments->GetLength(0) > 0)
{
    // Выбирает коллекцию комментариев автора по индексу 0
    auto commentCollection = comments[0]->get_Author()->get_Comments();
    String Comment = commentCollection->idx_get(0)->get_Text();
}
```


## **Доступ к комментариям слайда**
Этот код C++ показывает, как получить доступ к существующему комментарию на слайде в презентации PowerPoint:
```cpp
// Создает экземпляр класса Presentation
auto presentation = System::MakeObject<Presentation>(u"Comments1.pptx");

for (auto&& commentAuthor : presentation->get_CommentAuthors())
{
    auto author = System::ExplicitCast<CommentAuthor>(commentAuthor);
    for (auto&& comment1 : System::IterateOver(author->get_Comments()))
    {
        SmartPtr<Comment> comment = System::ExplicitCast<Comment>(comment1);
        Console::WriteLine(String(u"ISlide :")
                        + comment->get_Slide()->get_SlideNumber()
                        + u" has comment: " + comment->get_Text()
                        + u" with Author: " + comment->get_Author()->get_Name()
                        + u" posted on time :" + comment->get_CreatedTime() + u"\n");
    }
}
```


## **Ответы на комментарии**
Родительский комментарий — это верхний или оригинальный комментарий в иерархии комментариев или ответов. С помощью свойства [ParentComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) (из интерфейса [IComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment)) можно установить или получить родительский комментарий. 

Этот код C++ показывает, как добавить комментарии и получить ответы на них:
```cpp
auto pres = System::MakeObject<Presentation>();

// Получает ISlide 1
auto slide1 = pres->get_Slides()->idx_get(0);

// Добавляет комментарий
auto author1 = pres->get_CommentAuthors()->AddAuthor(u"Author_1", u"A.A.");
auto comment1 = author1->get_Comments()->AddComment(u"comment1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

// Добавляет ответ к comment1
auto author2 = pres->get_CommentAuthors()->AddAuthor(u"Autror_2", u"B.B.");
auto reply1 = author2->get_Comments()->AddComment(u"reply 1 for comment 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply1->set_ParentComment(comment1);

// Добавляет еще один ответ к comment1
auto reply2 = author2->get_Comments()->AddComment(u"reply 2 for comment 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply2->set_ParentComment(comment1);

// Добавляет ответ к существующему ответу
auto subReply = author1->get_Comments()->AddComment(u"subreply 3 for reply 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
subReply->set_ParentComment(reply2);

auto comment2 = author2->get_Comments()->AddComment(u"comment 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
auto comment3 = author2->get_Comments()->AddComment(u"comment 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

auto reply3 = author1->get_Comments()->AddComment(u"reply 4 for comment 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply3->set_ParentComment(comment3);

// Отображает иерархию комментариев в консоли
auto comments = slide1->GetSlideComments(nullptr);
for (int32_t i = 0; i < comments->get_Length(); i++)
{
    auto comment = comments[i];
    while (comment->get_ParentComment() != nullptr)
    {
        Console::Write(u"\t");
        comment = comment->get_ParentComment();
    }

    Console::Write(u"{0} : {1}", comments[i]->get_Author()->get_Name(), comments[i]->get_Text());
    Console::WriteLine();
}

pres->Save(u"parent_comment.pptx", SaveFormat::Pptx);

// Удаляет comment1 и все ответы к нему
comment1->Remove();

pres->Save(u"remove_comment.pptx", SaveFormat::Pptx);
```


{{% alert color="warning" title="Attention" %}} 

* При использовании метода [Remove](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment#a8bb818ae804d142195c4edcf9012cccb) (из интерфейса [IComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment)) для удаления комментария также удаляются его ответы. 
* Если настройка [ParentComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) приводит к циклической ссылке, будет выброшено исключение [PptxEditException](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d).

{{% /alert %}}

## **Добавить современный комментарий**

В 2021 году Microsoft представила *современные комментарии* в PowerPoint. Функция современных комментариев существенно улучшает совместную работу в PowerPoint. С помощью современных комментариев пользователи PowerPoint могут отмечать комментарии как решённые, привязывать комментарии к объектам и тексту и гораздо проще взаимодействовать. 

В [Aspose Slides for C++ 21.11](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-21-11-release-notes/) мы реализовали поддержку современных комментариев, добавив класс [ModernComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.modern_comment). В класс [CommentCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_collection) были добавлены методы [AddModernComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_collection#a3627fcb3b05cd639fd430bd8248fe66b) и [InsertModernComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_collection#ad11c3efb52f3c17f63238447dcc03c94). 

Этот код C++ показывает, как добавить современный комментарий к слайду в презентации PowerPoint: 
```cpp
auto pres = System::MakeObject<Presentation>();
// Получает ISlide 1
auto slide1 = pres->get_Slides()->idx_get(0);

auto newAuthor = pres->get_CommentAuthors()->AddAuthor(u"Some Author", u"SA");
auto modernComment = newAuthor->get_Comments()->AddModernComment(u"This is a modern comment", slide1, nullptr, PointF(100.0f, 100.0f), DateTime::get_Now());

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```


## **Удалить комментарий**

### **Удалить все комментарии и авторов**

Этот код C++ показывает, как удалить все комментарии и авторов в презентации:
```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"example.pptx");

// Удаляет все комментарии из презентации
for (auto author : presentation->get_CommentAuthors())
{
    author->get_Comments()->Clear();
}
        
// Удаляет всех авторов
presentation->get_CommentAuthors()->Clear();
presentation->Save(u"example_out.pptx", SaveFormat::Pptx);
```


### **Удалить конкретные комментарии**

Этот код C++ показывает, как удалить конкретные комментарии на слайде:
```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
// добавить комментарии...
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Author", u"A");
author->get_Comments()->AddComment(u"comment 1", slide, PointF(0.2f, 0.2f), System::DateTime::get_Now());
author->get_Comments()->AddComment(u"comment 2", slide, PointF(0.3f, 0.2f), System::DateTime::get_Now());
        
// удалить все комментарии, содержащие текст "comment 1"
for (auto commentAuthor : presentation->get_CommentAuthors())
{
    auto toRemove = System::MakeObject<System::Collections::Generic::List<System::SharedPtr<IComment>>>();
    for (auto comment : slide->GetSlideComments(commentAuthor))
    {
        if (comment->get_Text() == u"comment 1")
        {
            toRemove->Add(comment);
        }
    }
    for (auto comment : toRemove)
    {
        commentAuthor->get_Comments()->Remove(comment);
    }
}
        
presentation->Save(u"pres.pptx", SaveFormat::Pptx);
```


## **Часто задаваемые вопросы**

**Поддерживает ли Aspose.Slides статус, например «решён», для современных комментариев?**

Да. [Современные комментарии](https://reference.aspose.com/slides/cpp/aspose.slides/moderncomment/) предоставляют методы [get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/moderncomment/get_status/) и [set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/moderncomment/set_status/); вы можете читать и задавать [состояние комментария](https://reference.aspose.com/slides/cpp/aspose.slides/moderncommentstatus/) (например, пометить его как решённое), и это состояние сохраняется в файле и распознаётся PowerPoint.

**Поддерживаются ли ветвленные обсуждения (цепочки ответов) и существует ли ограничение глубины вложения?**

Да. Каждый комментарий может ссылаться на свой [родительский комментарий](https://reference.aspose.com/slides/cpp/aspose.slides/comment/set_parentcomment/), что позволяет создавать произвольные цепочки ответов. API не объявляет конкретного ограничения глубины вложения.

**В какой системе координат определяется позиция маркера комментария на слайде?**

Позиция хранится как точка с плавающей запятой в системе координат слайда. Это позволяет разместить маркер комментария точно там, где это необходимо.