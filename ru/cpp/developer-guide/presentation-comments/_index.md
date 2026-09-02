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
- комментарии презентации
- комментарии слайдов
- добавить комментарий
- получить комментарий
- редактировать комментарий
- ответить на комментарий
- удалить комментарий
- стереть комментарий
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Управляйте комментариями презентаций с помощью Aspose.Slides для C++: добавляйте, читайте, редактируйте, отвечайте и удаляйте комментарии в презентациях PowerPoint быстро и легко."
---
## **Обзор**

Эта статья объясняет, как управлять комментариями в презентации с помощью Aspose.Slides для C++. Она вводит основные типы, связанные с комментариями, и демонстрирует, как добавлять комментарии к слайдам, получать доступ к существующим комментариям, работать с ответами и современными комментариями, а также удалять комментарии из презентации.

Примеры охватывают типичные сценарии рецензирования и совместной работы в PowerPoint, такие как назначение комментариев авторам, чтение текста комментария и метаданных, построение цепочек ответов и удаление выбранных комментариев или всех комментариев.

В PowerPoint комментарии отображаются как аннотации на слайдах. Выбор комментария показывает его текст и связанную дискуссию.

## **Зачем добавлять комментарии в презентации?**

Вы можете использовать комментарии для предоставления обратной связи и совместной работы с коллегами при рецензировании презентаций.

Aspose.Slides для C++ предоставляет следующие API для работы с комментариями:

* Класс [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) предоставляет доступ к авторам комментариев презентации.
* Интерфейс [ICommentCollection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icommentcollection/) представляет комментарии, связанные с отдельным автором.
* Интерфейс [IComment](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icomment/) предоставляет информацию о комментарии, включая его автора, время создания, позицию и текст.
* Класс [CommentAuthor](https://reference.aspose.com/slides/ru/cpp/aspose.slides/commentauthor/) предоставляет информацию об авторе, включая его имя, инициалы и связанные комментарии.

## **Добавить комментарии к слайдам**

Следующий пример показывает, как добавить комментарии к слайдам в презентации PowerPoint:

```cpp
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/console.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto firstSlide = presentation->get_Slide(0);
auto secondSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_LayoutSlide(0));
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Jawad", u"MF");
auto position = PointF(0.2f, 0.2f);
auto createdTime = DateTime::get_Now();

author->get_Comments()->AddComment(u"Hello Jawad, this is a slide comment", firstSlide, position, createdTime);
author->get_Comments()->AddComment(u"Hello Jawad, this is the second slide comment", secondSlide, position, createdTime);

auto comments = firstSlide->GetSlideComments(author);
if (comments->get_Length() > 0)
{
    auto firstComment = comments[0];
    Console::WriteLine(firstComment->get_Text());

    auto commentText = firstComment->get_Author()->get_Comments()->idx_get(0)->get_Text();
    Console::WriteLine(commentText);
}

presentation->Save(u"Comments_out.pptx", SaveFormat::Pptx);
```

## **Получить комментарии к слайдам**

Следующий пример показывает, как получить доступ к существующим комментариям в презентации PowerPoint:

```cpp
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Comments1.pptx");

for (auto&& author : presentation->get_CommentAuthors())
{
    for (auto&& comment : author->get_Comments())
    {
        Console::WriteLine(u"Slide: {0}", comment->get_Slide()->get_SlideNumber());
        Console::WriteLine(u"Comment: {0}", comment->get_Text());
        Console::WriteLine(u"Author: {0}", comment->get_Author()->get_Name());
        Console::WriteLine(u"Posted at: {0}", comment->get_CreatedTime());
        Console::WriteLine();
    }
}
```

## **Ответы на комментарии**

Родительский комментарий — это исходный комментарий в верхней части иерархии ответов. Методы [get_ParentComment](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icomment/get_parentcomment/) и [set_ParentComment](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icomment/set_parentcomment/) интерфейса [IComment](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icomment/) позволяют получить или задать родительский комментарий.

Следующий пример показывает, как добавить ответы и просмотреть получившуюся иерархию комментариев:

```cpp
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/console.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto position = PointF(10.0f, 10.0f);
auto createdTime = DateTime::get_Now();

auto author1 = presentation->get_CommentAuthors()->AddAuthor(u"Author_1", u"A.A.");
auto comment1 = author1->get_Comments()->AddComment(u"comment 1", slide, position, createdTime);

auto author2 = presentation->get_CommentAuthors()->AddAuthor(u"Author_2", u"B.B.");
auto reply1 = author2->get_Comments()->AddComment(u"reply 1 for comment 1", slide, position, createdTime);
reply1->set_ParentComment(comment1);

auto reply2 = author2->get_Comments()->AddComment(u"reply 2 for comment 1", slide, position, createdTime);
reply2->set_ParentComment(comment1);

auto subReply = author1->get_Comments()->AddComment(u"subreply 3 for reply 2", slide, position, createdTime);
subReply->set_ParentComment(reply2);

author2->get_Comments()->AddComment(u"comment 2", slide, position, createdTime);
auto comment3 = author2->get_Comments()->AddComment(u"comment 3", slide, position, createdTime);

auto reply3 = author1->get_Comments()->AddComment(u"reply 4 for comment 3", slide, position, createdTime);
reply3->set_ParentComment(comment3);

auto comments = slide->GetSlideComments(nullptr);
for (int32_t i = 0; i < comments->get_Length(); i++)
{
    auto comment = comments[i];
    while (comment->get_ParentComment() != nullptr)
    {
        Console::Write(u"\t");
        comment = comment->get_ParentComment();
    }

    Console::WriteLine(u"{0}: {1}", comments[i]->get_Author()->get_Name(), comments[i]->get_Text());
}

presentation->Save(u"parent_comment.pptx", SaveFormat::Pptx);

comment1->Remove();
presentation->Save(u"remove_comment.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="Warning" %}}
* При использовании метода [Remove](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icomment/remove/) интерфейса [IComment](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icomment/) для удаления комментария также удаляются все ответы на этот комментарий.
* Если метод [set_ParentComment](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icomment/set_parentcomment/) создаёт циклическую ссылку, генерируется исключение [PptxEditException](https://reference.aspose.com/slides/ru/cpp/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Добавить современные комментарии**

Современные комментарии могут быть связаны непосредственно со слайдом, с конкретной фигурой или с диапазоном текста внутри AutoShape. Метод [ICommentCollection::AddModernComment](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icommentcollection/addmoderncomment/) принимает аргумент [IShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/) в дополнение к слайду и координатам маркера комментария.

Когда в аргументе shape передаётся `nullptr`, комментарий является комментариев уровня слайда. Его маркер позиционируется по заданным координатам, но не привязан к какой‑либо фигуре, поэтому [IModernComment::get_Shape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imoderncomment/get_shape/) возвращает `nullptr`. Когда передаётся объект [IShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/), комментарий привязывается к этой фигуре. Координаты по‑прежнему определяют положение маркера комментария на слайде, а привязка к фигуре может быть получена через [IModernComment::get_Shape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imoderncomment/get_shape/).

### **Привязать современный комментарий к фигуре**

Следующий пример создаёт как комментарий уровня слайда, так и современный комментарий, привязанный к конкретному AutoShape. Затем он читает связанную фигуру из каждого комментария.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/IModernComment.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/console.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Reviewer", u"RV");
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 300.0f, 80.0f);
shape->set_Name(u"Revenue title");
shape->get_TextFrame()->set_Text(u"Quarterly revenue");

auto createdTime = DateTime::get_Now();
auto slideCommentPosition = PointF(20.0f, 20.0f);
auto shapeCommentPosition = PointF(60.0f, 60.0f);
auto slideComment = author->get_Comments()->AddModernComment(u"Review the overall slide layout.", slide, nullptr, slideCommentPosition, createdTime);
auto shapeComment = author->get_Comments()->AddModernComment(u"Check this title.", slide, shape, shapeCommentPosition, createdTime);

Console::WriteLine(slideComment->get_Shape() == nullptr);
auto shapeAnchor = shapeComment->get_Shape();
if (shapeAnchor != nullptr)
{
    Console::WriteLine(shapeAnchor->get_Name());
}

presentation->Save(u"modern_comments.pptx", SaveFormat::Pptx);
```

### **Привязать комментарии к разным типам фигур**

Любой объект слайда, реализующий [IShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/), может использоваться в качестве привязки фигуры. Распространённые примеры включают [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iconnector/) и экземпляры [IGraphicalObject](https://reference.aspose.com/slides/ru/cpp/aspose.slides/igraphicalobject/) такие как диаграммы.

Следующий пример создаёт несколько распространённых типов фигур и привязывает к каждой современный комментарий.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/IConnector.h>
#include <DOM/IGroupShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/convert.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Reviewer", u"RV");
auto createdTime = DateTime::get_Now();

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 180.0f, 60.0f);
autoShape->get_TextFrame()->set_Text(u"AutoShape");
auto autoShapeCommentPosition = PointF(30.0f, 30.0f);
author->get_Comments()->AddModernComment(u"Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

auto imageBase64 = u"iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
auto imageData = Convert::FromBase64String(imageBase64);
auto image = presentation->get_Images()->AddImage(imageData);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 220.0f, 20.0f, 120.0f, 80.0f, image);
auto pictureCommentPosition = PointF(230.0f, 30.0f);
author->get_Comments()->AddModernComment(u"Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

auto groupShape = slide->get_Shapes()->AddGroupShape();
groupShape->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0.0f, 0.0f, 80.0f, 40.0f);
groupShape->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 100.0f, 0.0f, 80.0f, 40.0f);
auto groupCommentPosition = PointF(40.0f, 150.0f);
author->get_Comments()->AddModernComment(u"Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

auto connector = slide->get_Shapes()->AddConnector(ShapeType::StraightConnector1, 220.0f, 150.0f, 140.0f, 40.0f);
auto connectorCommentPosition = PointF(240.0f, 150.0f);
author->get_Comments()->AddModernComment(u"Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 400.0f, 20.0f, 250.0f, 180.0f);
auto chartCommentPosition = PointF(420.0f, 40.0f);
author->get_Comments()->AddModernComment(u"Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

presentation->Save(u"modern_comment_shape_types.pptx", SaveFormat::Pptx);
```

### **Привязать комментарий к тексту и установить его статус**

Для современного комментария, связанного с [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/), методы [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imoderncomment/get_textselectionstart/) и [IModernComment::set_TextSelectionStart](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imoderncomment/set_textselectionstart/) управляют начальной позицией выбранного текста во фрейме текста фигуры. Аналогично, методы [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imoderncomment/get_textselectionlength/) и [IModernComment::set_TextSelectionLength](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imoderncomment/set_textselectionlength/) задают длину выделения. Вместе эти методы привязывают комментарий к конкретному диапазону текста внутри AutoShape.

Методы [IModernComment::get_Status](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imoderncomment/get_status/) и [IModernComment::set_Status](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imoderncomment/set_status/) используют значение из перечисления [ModernCommentStatus](https://reference.aspose.com/slides/ru/cpp/aspose.slides/moderncommentstatus/):

- `NotDefined` — не определён конкретный статус современного комментария.
- `Active` — комментарий активен.
- `Resolved` — комментарий решён.
- `Closed` — комментарий закрыт.

Следующий пример создаёт привязанный к фигуре современный комментарий, связывает его с выделением текста, отмечает его как решённый, сохраняет презентацию и проверяет значения после повторного открытия файла.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/IModernComment.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ModernCommentStatus.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/console.h>
#include <system/date_time.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

const String outputFile = u"modern_comment_text_anchor.pptx";
const String shapeText = u"Review the quarterly revenue forecast.";
const String selectedText = u"quarterly revenue";
auto expectedSelectionStart = shapeText.IndexOf(selectedText);

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 400.0f, 100.0f);
shape->set_Name(u"Forecast text");
shape->get_TextFrame()->set_Text(shapeText);

auto author = presentation->get_CommentAuthors()->AddAuthor(u"Reviewer", u"RV");
auto commentPosition = PointF(60.0f, 60.0f);
auto comment = author->get_Comments()->AddModernComment(u"Verify this forecast wording.", slide, shape, commentPosition, DateTime::get_Now());
comment->set_TextSelectionStart(expectedSelectionStart);
comment->set_TextSelectionLength(selectedText.get_Length());
comment->set_Status(ModernCommentStatus::Resolved);

presentation->Save(outputFile, SaveFormat::Pptx);

auto reopenedPresentation = MakeObject<Presentation>(outputFile);
auto reopenedSlide = reopenedPresentation->get_Slide(0);
auto reopenedComments = reopenedSlide->GetSlideComments(nullptr);

for (auto&& reopenedComment : reopenedComments)
{
    auto modernComment = AsCast<IModernComment>(reopenedComment);
    if (modernComment == nullptr)
    {
        continue;
    }

    auto shapeAnchor = modernComment->get_Shape();
    auto shapeMatches = shapeAnchor != nullptr && shapeAnchor->get_Name() == u"Forecast text";
    auto selectionStartMatches = modernComment->get_TextSelectionStart() == expectedSelectionStart;
    auto selectionLengthMatches = modernComment->get_TextSelectionLength() == selectedText.get_Length();
    auto statusMatches = modernComment->get_Status() == ModernCommentStatus::Resolved;

    Console::WriteLine(u"Shape anchor preserved: {0}", shapeMatches);
    Console::WriteLine(u"Text selection start preserved: {0}", selectionStartMatches);
    Console::WriteLine(u"Text selection length preserved: {0}", selectionLengthMatches);
    Console::WriteLine(u"Resolved status preserved: {0}", statusMatches);
}
```

### **Проверить существующие современные комментарии**

Чтобы проанализировать существующую презентацию, найдите комментарии, реализующие [IModernComment](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imoderncomment/), затем изучите [IModernComment::get_Shape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imoderncomment/get_shape/), [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imoderncomment/get_textselectionstart/), [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imoderncomment/get_textselectionlength/) и [IModernComment::get_Status](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imoderncomment/get_status/). `nullptr` в качестве фигуры указывает на комментарий уровня слайда. Для привязки к [IAutoShape] методы выбора текста определяют соответствующий диапазон во фрейме текста фигуры.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IComment.h>
#include <DOM/IModernComment.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ModernCommentStatus.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"comments.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto comments = slide->GetSlideComments(nullptr);
    for (auto&& comment : comments)
    {
        auto modernComment = AsCast<IModernComment>(comment);
        if (modernComment == nullptr)
        {
            continue;
        }

        Console::WriteLine(u"Slide: {0}", slide->get_SlideNumber());
        Console::WriteLine(u"Text: {0}", modernComment->get_Text());
        Console::WriteLine(u"Status: {0}", modernComment->get_Status());

        auto shape = modernComment->get_Shape();
        if (shape == nullptr)
        {
            Console::WriteLine(u"Anchor: slide level");
        }
        else
        {
            Console::WriteLine(u"Anchor shape: {0}", shape->get_Name());
            Console::WriteLine(u"Anchor type: {0}", shape->GetType().get_Name());

            auto autoShape = AsCast<IAutoShape>(shape);
            if (autoShape != nullptr)
            {
                Console::WriteLine(u"Text selection start: {0}", modernComment->get_TextSelectionStart());
                Console::WriteLine(u"Text selection length: {0}", modernComment->get_TextSelectionLength());
            }
        }

        Console::WriteLine();
    }
}
```

## **Удалить комментарии**

### **Удалить все комментарии и их авторов**

Следующий пример показывает, как удалить все комментарии и их авторов из презентации:

```cpp
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"example.pptx");

for (auto&& author : presentation->get_CommentAuthors())
{
    author->get_Comments()->Clear();
}

presentation->get_CommentAuthors()->Clear();
presentation->Save(u"example_out.pptx", SaveFormat::Pptx);
```

### **Удалить конкретные комментарии**

Следующий пример показывает, как удалить конкретные комментарии со слайда:

```cpp
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/collections/list.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Author", u"A");
auto createdTime = DateTime::get_Now();

auto firstCommentPosition = PointF(0.2f, 0.2f);
auto secondCommentPosition = PointF(0.3f, 0.2f);
author->get_Comments()->AddComment(u"comment 1", slide, firstCommentPosition, createdTime);
author->get_Comments()->AddComment(u"comment 2", slide, secondCommentPosition, createdTime);

for (auto&& commentAuthor : presentation->get_CommentAuthors())
{
    auto commentsToRemove = MakeObject<List<SharedPtr<IComment>>>();
    auto comments = slide->GetSlideComments(commentAuthor);

    for (auto&& comment : comments)
    {
        if (comment->get_Text() == u"comment 1")
        {
            commentsToRemove->Add(comment);
        }
    }

    for (auto&& comment : commentsToRemove)
    {
        commentAuthor->get_Comments()->Remove(comment);
    }
}

presentation->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Поддерживает ли Aspose.Slides статус «Resolved» для современных комментариев?**

Да. Методы [IModernComment::get_Status](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imoderncomment/get_status/) и [IModernComment::set_Status](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imoderncomment/set_status/) используют значение из перечисления [ModernCommentStatus](https://reference.aspose.com/slides/ru/cpp/aspose.slides/moderncommentstatus/), включая `Resolved`. Статус сохраняется в презентации и может быть считан после повторного открытия файла.

**Поддерживаются ли ветвистые обсуждения (цепочки ответов) и существует ли ограничение вложенности?**

Да. Каждый комментарий может ссылаться на свой [parent comment](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icomment/set_parentcomment/), что позволяет формировать цепочки ответов. API не задаёт конкретного ограничения глубины вложения.

**В какой системе координат определяется позиция маркера комментария на слайде?**

Позиция маркера определяется координатами с плавающей точкой в системе координат слайда, что позволяет точно разместить его на слайде.