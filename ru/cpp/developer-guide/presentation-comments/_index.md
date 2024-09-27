---
title: Комментарии к Презентации
type: docs
weight: 100
url: /ru/cpp/presentation-comments/
keywords: "Комментарии, комментарии PowerPoint, презентация PowerPoint, C++, Aspose.Slides для C++"
description: "Добавьте комментарии и ответы в презентацию PowerPoint на C++"
---

В PowerPoint комментарий отображается как заметка или аннотация на слайде. Когда комментарий нажимается, его содержимое или сообщения открываются.

### **Почему стоит добавлять комментарии к презентациям?**

Вы можете использовать комментарии для предоставления отзывов или общения с вашими коллегами при просмотре презентаций.

Чтобы вы могли использовать комментарии в презентациях PowerPoint, Aspose.Slides для C++ предоставляет

* Класс [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation), который содержит коллекции авторов (из метода [get_CommentAuthors()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#ac100feeb13ea426b85557a829676227d)). Авторы добавляют комментарии к слайдам.
* Интерфейс [ICommentCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment_collection), который содержит коллекцию комментариев для отдельных авторов.
* Класс [IComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment), который содержит информацию об авторах и их комментариях: кто добавил комментарий, время добавления комментария, позиция комментария и т.д.
* Класс [CommentAuthor](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_author), который содержит информацию об отдельных авторах: имя автора, его инициалы, комментарии, связанные с именем автора и т.д.

## **Добавить комментарий к слайду**
Этот код на C++ показывает, как добавить комментарий к слайду в презентации PowerPoint:

```cpp
// Создает экземпляр класса Presentation
auto presentation = System::MakeObject<Presentation>();
// Добавляет пустой слайд
presentation->get_Slides()->AddEmptySlide(presentation->get_LayoutSlides()->idx_get(0));

// Добавляет автора
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Jawad", u"MF");

// Устанавливает позицию для комментариев
PointF point;
point.set_X(0.2f);
point.set_Y(0.2f);

// Получает ISlide 1
auto slide1 = presentation->get_Slides()->idx_get(0);
// Получает ISlide 2
auto slide2 = presentation->get_Slides()->idx_get(1);

// Добавляет комментарий к слайду для автора на слайде 1
author->get_Comments()->AddComment(u"Здравствуйте, Jawad, это комментарий к слайду", slide1, point, DateTime::get_Now());

// Добавляет комментарий к слайду для автора на слайде 2
author->get_Comments()->AddComment(u"Здравствуйте, Jawad, это второй комментарий к слайду", slide2, point, DateTime::get_Now());

// Когда null передается в качестве аргумента, комментарии от всех авторов возвращаются к выбранному слайду
auto comments = slide1->GetSlideComments(author);

// Получает комментарий с индексом 0 для слайда 1
String str = comments[0]->get_Text();

presentation->Save(u"Comments_out.pptx", SaveFormat::Pptx);

if (comments->GetLength(0) > 0)
{
    // Выбирает коллекцию комментариев автора с индексом 0
    auto commentCollection = comments[0]->get_Author()->get_Comments();
    String Comment = commentCollection->idx_get(0)->get_Text();
}
```

## **Доступ к комментариям слайда**
Этот код на C++ показывает, как получить доступ к существующему комментарию на слайде в презентации PowerPoint:

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
                        + u" имеет комментарий: " + comment->get_Text()
                        + u" от Автора: " + comment->get_Author()->get_Name()
                        + u" опубликовано в: " + comment->get_CreatedTime() + u"\n");
    }
}
```


## **Ответы на комментарии**
Родительский комментарий – это верхний или оригинальный комментарий в иерархии комментариев или ответов. Используя свойство [ParentComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) (из интерфейса [IComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment)), вы можете установить или получить родительский комментарий.

Этот код на C++ показывает, как добавить комментарии и получить ответы на них:

```cpp
auto pres = System::MakeObject<Presentation>();

// Получает ISlide 1
auto slide1 = pres->get_Slides()->idx_get(0);

// Добавляет комментарий
auto author1 = pres->get_CommentAuthors()->AddAuthor(u"Автор_1", u"A.A.");
auto comment1 = author1->get_Comments()->AddComment(u"комментарий 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

// Добавляет ответ на comment1
auto author2 = pres->get_CommentAuthors()->AddAuthor(u"Автор_2", u"B.B.");
auto reply1 = author2->get_Comments()->AddComment(u"ответ 1 на комментарий 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply1->set_ParentComment(comment1);

// Добавляет еще один ответ на comment1
auto reply2 = author2->get_Comments()->AddComment(u"ответ 2 на комментарий 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply2->set_ParentComment(comment1);

// Добавляет ответ на существующий ответ
auto subReply = author1->get_Comments()->AddComment(u"подответ 3 на ответ 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
subReply->set_ParentComment(reply2);

auto comment2 = author2->get_Comments()->AddComment(u"комментарий 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
auto comment3 = author2->get_Comments()->AddComment(u"комментарий 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

auto reply3 = author1->get_Comments()->AddComment(u"ответ 4 на комментарий 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply3->set_ParentComment(comment3);

// Отображает иерархию комментариев на консоли
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

// Удаляет comment1 и все ответы на него
comment1->Remove();

pres->Save(u"remove_comment.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="Внимание" %}} 

* Когда метод [Remove](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment#a8bb818ae804d142195c4edcf9012cccb) (из интерфейса [IComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment)) используется для удаления комментария, ответы на комментарий также удаляются.
* Если настройка [ParentComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) приводит к циклической ссылке, будет выброшено [PptxEditException](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d).

{{% /alert %}}

## **Добавить современный комментарий**

В 2021 году Microsoft представила *современные комментарии* в PowerPoint. Функция современных комментариев значительно улучшает совместную работу в PowerPoint. С помощью современных комментариев пользователи PowerPoint могут значительно легче разрешать комментарии, привязывать комментарии к объектам и текстам и взаимодействовать.

В [Aspose Slides для C++ 21.11](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-21-11-release-notes/) мы реализовали поддержку современных комментариев, добавив класс [ModernComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.modern_comment). Методы [AddModernComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_collection#a3627fcb3b05cd639fd430bd8248fe66b) и [InsertModernComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_collection#ad11c3efb52f3c17f63238447dcc03c94) были добавлены в класс [CommentCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_collection).

Этот код на C++ показывает, как добавить современный комментарий к слайду в презентации PowerPoint:

```cpp
auto pres = System::MakeObject<Presentation>();
// Получает ISlide 1
auto slide1 = pres->get_Slides()->idx_get(0);

auto newAuthor = pres->get_CommentAuthors()->AddAuthor(u"Некоторый Автор", u"SA");
auto modernComment = newAuthor->get_Comments()->AddModernComment(u"Это современный комментарий", slide1, nullptr, PointF(100.0f, 100.0f), DateTime::get_Now());

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Удалить комментарий**

### **Удалить все комментарии и авторов**

Этот код на C++ показывает, как удалить все комментарии и авторов в презентации:

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

Этот код на C++ показывает, как удалить конкретные комментарии на слайде:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
// добавляет комментарии...
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Автор", u"A");
author->get_Comments()->AddComment(u"комментарий 1", slide, PointF(0.2f, 0.2f), System::DateTime::get_Now());
author->get_Comments()->AddComment(u"комментарий 2", slide, PointF(0.3f, 0.2f), System::DateTime::get_Now());
        
// удаляет все комментарии, содержащие текст "комментарий 1"
for (auto commentAuthor : presentation->get_CommentAuthors())
{
    auto toRemove = System::MakeObject<System::Collections::Generic::List<System::SharedPtr<IComment>>>();
    for (auto comment : slide->GetSlideComments(commentAuthor))
    {
        if (comment->get_Text() == u"комментарий 1")
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