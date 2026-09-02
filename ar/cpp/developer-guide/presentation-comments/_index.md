---
title: إدارة تعليقات العرض التقديمي في C++
linktitle: تعليقات العرض التقديمي
type: docs
weight: 100
url: /ar/cpp/presentation-comments/
keywords:
- تعليق
- تعليق حديث
- تعليقات PowerPoint
- تعليقات العرض التقديمي
- تعليقات الشريحة
- إضافة تعليق
- الوصول إلى التعليق
- تحرير التعليق
- الرد على التعليق
- إزالة التعليق
- حذف التعليق
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "إدارة تعليقات العرض التقديمي باستخدام Aspose.Slides للغة C++: إضافة، قراءة، تحرير، الرد على، وإزالة التعليقات في عروض PowerPoint بسرعة وسهولة."
---
## **نظرة عامة**

توضح هذه المقالة كيفية إدارة تعليقات العرض التقديمي باستخدام Aspose.Slides للغة C++. تُقدِّم الأنواع الرئيسية المتعلقة بالتعليقات وتُظهر كيفية إضافة تعليقات إلى الشرائح، والوصول إلى التعليقات الموجودة، والعمل مع الردود والتعليقات الحديثة، وحذف التعليقات من العرض التقديمي.

تغطي الأمثلة سيناريوهات المراجعة والتعاون الشائعة في PowerPoint، مثل إسناد التعليقات إلى مؤلفين، قراءة نص التعليق والبيانات الوصفية، بناء سلاسل الردود، وحذف التعليقات المختارة أو جميع التعليقات.

في PowerPoint، تظهر التعليقات كتعليقات توضيحية على الشرائح. عند تحديد تعليق، يتم عرض نصه والنقاش المرتبط به.

## **لماذا نضيف تعليقات إلى العروض التقديمية؟**

يمكنك استخدام التعليقات لتقديم ملاحظات والتعاون مع الزملاء عند مراجعة العروض التقديمية.

توفر Aspose.Slides للغة C++ واجهات برمجة التطبيقات التالية للعمل مع التعليقات:

* الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) التي تُوفِّر إمكانية الوصول إلى مؤلفي التعليقات في العرض التقديمي.
* الواجهة [ICommentCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icommentcollection/) التي تمثّل التعليقات المرتبطة بمؤلف معين.
* الواجهة [IComment](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icomment/) التي تُقدِّم معلومات حول التعليق، بما في ذلك المؤلف، ووقت الإنشاء، والموقع، والنص.
* الفئة [CommentAuthor](https://reference.aspose.com/slides/ar/cpp/aspose.slides/commentauthor/) التي تُقدِّر معلومات عن المؤلف، بما في ذلك اسمه، وأحرفه الأولى، والتعليقات المرتبطة به.

## **إضافة تعليقات إلى الشرائح**

المثال التالي يوضح كيفية إضافة تعليقات إلى الشرائح في عرض PowerPoint:

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

## **الوصول إلى تعليقات الشرائح**

المثال التالي يوضح كيفية الوصول إلى التعليقات الموجودة في عرض PowerPoint:

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

## **الرد على التعليقات**

التعليق الأصلي هو التعليق الأصلي في أعلى تسلسل الردود. تُتيح طُرُق [get_ParentComment](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icomment/get_parentcomment/) و[set_ParentComment](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icomment/set_parentcomment/) في الواجهة [IComment](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icomment/) الحصول على التعليق الأصلي أو تحديده.

المثال التالي يوضح كيفية إضافة ردود وفحص هيكلية التعليقات الناتجة:

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
* عند استخدام طريقة [Remove](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icomment/remove/) في الواجهة [IComment](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icomment/) لحذف تعليق، يتم حذف جميع الردود المرتبطة بهذا التعليق أيضًا.
* إذا أدت طريقة [set_ParentComment](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icomment/set_parentcomment/) إلى إنشاء إشارة دائرية، يتم إثارة استثناء [PptxEditException](https://reference.aspose.com/slides/ar/cpp/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **إضافة تعليقات حديثة**

يمكن ربط التعليقات الحديثة بالشفرة نفسها، أو بشكل محدد، أو بنطاق نص داخل AutoShape. تقبل طريقة [ICommentCollection::AddModernComment](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icommentcollection/addmoderncomment/) معاملًا من نوع [IShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/) بالإضافة إلى إحداثيات الشريحة وعلامة التعليق.

عند تمرير `nullptr` كمعامل الشكل، يكون التعليق تعليقًا على مستوى الشريحة. يتم تحديد موقع العلامة بالإحداثيات المقدمة، لكنه لا يرتبط بشكل معين، لذا تُعيد طريقة [IModernComment::get_Shape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imoderncomment/get_shape/) `nullptr`. عند توفير [IShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/)، يتم تثبيت التعليق على ذلك الشكل. ما تزال الإحداثيات تحدد موقع علامة التعليق على الشريحة، بينما يمكن استرجاع ارتباط الشكل عبر [IModernComment::get_Shape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imoderncomment/get_shape/).

### **تثبيت تعليق حديث على شكل**

المثال التالي ينشئ كلًا من تعليق حديث على مستوى الشريحة وتعليق حديث مثبت إلى AutoShape محدد. ثم يقرأ الشكل المرتبط بكل تعليق.

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

### **تثبيت التعليقات على أنواع أشكال مختلفة**

يمكن استخدام أي كائن شريحة يُنفّذ الواجهة [IShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/) كمرساة للشكل. تشمل الأمثلة الشائعة [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/)، [IPictureFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipictureframe/)، [IGroupShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/igroupshape/)، [IConnector](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iconnector/)، و[IGraphicalObject](https://reference.aspose.com/slides/ar/cpp/aspose.slides/igraphicalobject/) مثل المخططات.

المثال التالي ينشئ عدة أنواع شائعة من الأشكال ويربط تعليقًا حديثًا بكل منها.

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

### **تثبيت تعليق على نص وتعيين حالته**

بالنسبة لتعليق حديث مرتبط بـ [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/)، تتحكم الطريقة [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imoderncomment/get_textselectionstart/) والطريقة [IModernComment::set_TextSelectionStart](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imoderncomment/set_textselectionstart/) في موضع بدء النص المحدد داخل إطار نص الشكل. بالمثل، تتحكم الطريقة [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imoderncomment/get_textselectionlength/) والطريقة [IModernComment::set_TextSelectionLength](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imoderncomment/set_textselectionlength/) في طول التحديد. معًا، تُربط هذه الطرق التعليق بنطاق نص محدد داخل AutoShape.

تستخدم الطريقتان [IModernComment::get_Status](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imoderncomment/get_status/) و[IModernComment::set_Status](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imoderncomment/set_status/) قيمة من تعداد [ModernCommentStatus](https://reference.aspose.com/slides/ar/cpp/aspose.slides/moderncommentstatus/):

- `NotDefined` — لا توجد حالة محددة للتعليق الحديث.
- `Active` — التعليق نشط.
- `Resolved` — تم حل التعليق.
- `Closed` — التعليق مغلق.

المثال التالي ينشئ تعليقًا حديثًا ثابتًا على شكل، ويربطه بتحديد نص، ويُحدِّده كـ "تم حلّه"، ثم يحفظ العرض التقديمي ويتحقق من القيم بعد إعادة فتح الملف.

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

### **فحص التعليقات الحديثة الموجودة**

لفحص عرض تقديمي موجود، تحقق من التعليقات التي تُنفّذ الواجهة [IModernComment](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imoderncomment/)، ثم افحص [IModernComment::get_Shape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imoderncomment/get_shape/)، [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imoderncomment/get_textselectionstart/)، [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imoderncomment/get_textselectionlength/)، و[IModernComment::get_Status](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imoderncomment/get_status/). يشير الشكل `nullptr` إلى تعليق على مستوى الشريحة. بالنسبة لمرساة [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/)، تحدد طرق اختيار النص النطاق المرتبط في إطار نص الشكل.

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

## **إزالة التعليقات**

### **إزالة جميع التعليقات ومؤلفي التعليقات**

المثال التالي يوضح كيفية إزالة جميع التعليقات ومؤلفي التعليقات من عرض تقديمي:

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

### **إزالة تعليقات معينة**

المثال التالي يوضح كيفية إزالة تعليقات معينة من شريحة:

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

## **الأسئلة الشائعة**

**هل تدعم Aspose.Slides حالة "تم الحل" للتعليقات الحديثة؟**

نعم. تستخدم الطريقتان [IModernComment::get_Status](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imoderncomment/get_status/) و[IModernComment::set_Status](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imoderncomment/set_status/) قيمة من تعداد [ModernCommentStatus](https://reference.aspose.com/slides/ar/cpp/aspose.slides/moderncommentstatus/)، بما في ذلك `Resolved`. تُخزن الحالة في العرض التقديمي ويمكن قراءتها مرة أخرى بعد إعادة فتح الملف.

**هل تدعم المناقشات المتسلسلة (سلاسل الردود) وهل هناك حد للتعشيق؟**

نعم. يمكن لكل تعليق الإشارة إلى [التعليق الأصلي](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icomment/set_parentcomment/)، مما يتيح سلاسل الردود. لا تُحدِّد واجهة برمجة التطبيقات حدًا معينًا لعمق التعشيق.

**في أي نظام إحداثيات يتم تعريف موقع علامة التعليق على الشريحة؟**

يتم تعريف موقع العلامة بإحداثيات ذات نقطتين عشريتين في نظام إحداثيات الشريحة، مما يتيح لك وضعها بدقة على الشريحة.