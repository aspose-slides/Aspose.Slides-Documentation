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
- الوصول إلى تعليق
- تعديل تعليق
- الرد على تعليق
- إزالة تعليق
- حذف تعليق
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "إدارة تعليقات العرض التقديمي باستخدام Aspose.Slides لـ C++: إضافة، قراءة، تعديل، الرد على، وإزالة التعليقات في عروض PowerPoint بسرعة وسهولة."
---
## **نظرة عامة**

يشرح هذا المقال كيفية إدارة تعليقات العرض التقديمي باستخدام Aspose.Slides for C++. يقدم الأنواع الرئيسية المتعلقة بالتعليقات ويظهر كيفية إضافة تعليقات إلى الشرائح، والوصول إلى التعليقات الموجودة، والعمل مع الردود والتعليقات الحديثة، وإزالة التعليقات من العرض التقديمي.

تغطي الأمثلة سيناريوهات المراجعة والتعاون الشائعة في PowerPoint، مثل تعيين التعليقات للكتاب، قراءة نص التعليق والبيانات الوصفية، بناء سلاسل الردود، وإزالة التعليقات المحددة أو جميع التعليقات.

في PowerPoint، تظهر التعليقات كتعليقات توضيحية على الشرائح. يؤدي تحديد تعليق إلى عرض نصه والنقاش المتعلق به.

لطلب إظهار أو إخفاء التعليقات عند فتح عرض تقديمي دون تعديل التعليقات نفسها، راجع [إظهار أو إخفاء التعليقات عند فتح عرض تقديمي](/slides/ar/cpp/presentation-view-properties/).

## **لماذا إضافة تعليقات إلى العروض التقديمية؟**

يمكنك استخدام التعليقات لتقديم الملاحظات والتعاون مع الزملاء عند مراجعة العروض التقديمية.

توفر Aspose.Slides for C++ واجهات برمجة التطبيقات (APIs) التالية للعمل مع التعليقات:

* الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) التي توفر الوصول إلى مؤلفي تعليقات العرض التقديمي.
* الواجهة [ICommentCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/) التي تمثل التعليقات المرتبطة بكاتب معين.
* الواجهة [IComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/) التي توفر معلومات حول التعليق، بما في ذلك مؤلفه، وقت الإنشاء، الموقع، والنص.
* الفئة [CommentAuthor](https://reference.aspose.com/slides/cpp/aspose.slides/commentauthor/) التي توفر معلومات عن المؤلف، بما في ذلك اسمه، الأحرف الأولى، والتعليقات المرتبطة به.

## **إضافة تعليقات إلى الشريحة**

يُنشئ المثال شريحتين ويسجل كاتب تعليق باستخدام [AddAuthor](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/addauthor/). يستخدم [AddComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addcomment/) لوضع تعليق واحد على كل شريحة، ثم يسترجع تعليقات الشريحة الأولى لذلك الكاتب باستخدام [GetSlideComments](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getslidecomments/). تُظهر وحدة التحكم نص التعليق الأول مرتين، مظهرةً الوصول عبر كل من الشريحة والكاتب، ويحتوي العرض التقديمي المحفوظ على كلا التعليقين.

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

## **العثور على كاتب تعليق أو إنشاؤه**

عندما تقوم مراجعة تلقائية بمعالجة نفس العرض التقديمي بشكل متكرر، ابحث في المجموعة التي تُعيدها الدالة [get_CommentAuthors](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_commentauthors/) قبل إضافة كاتب. تتطابق الدالة [FindByNameAndInitials](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/findbynameandinitials/) مع كل من الاسم والأحرف الأولى وتعيد مصفوفة من الكتاب المتطابقين، أو مصفوفة فارغة إذا لم توجد مطابقات. بالمقابل، تبحث الدالة [FindByName](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/findbyname/) بالاسم فقط، بغض النظر عن الأحرف الأولى. استدعاء [AddAuthor](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/addauthor/) باسم وأحرف أولى موجودة بالفعل في المجموعة يطرح استثناءً.

يتطلب المثال ملف عرض تقديمي يحتوي على شريحة واحدة على الأقل. في كل من المرورين، يعيد استخدام أول كاتب متطابق، أو ينشئ واحدًا فقط عندما تكون النتيجة فارغة. إذا كان هناك عدة مطابقات، يختار العنصر الأول في المصفوفة دون دمج أو إزالة الكتاب الآخرين. ثم يستدعي [AddComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addcomment/) للكاتب المختار ويحفظ العرض التقديمي. يفتح المرور الثاني مخرجات المرور الأول ويكرر العملية.

```cpp
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/date_time.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

const String authorName = u"Reviewer";
const String authorInitials = u"RV";

auto inputFile = String(u"input.pptx");
auto position = PointF(20.0f, 20.0f);

for (auto pass = 1; pass <= 2; pass++)
{
    auto presentation = MakeObject<Presentation>(inputFile);

    auto matches = presentation->get_CommentAuthors()->FindByNameAndInitials(authorName, authorInitials);

    auto author = matches->get_Length() > 0 ? matches[0] : presentation->get_CommentAuthors()->AddAuthor(authorName, authorInitials);
    author->get_Comments()->AddComment(u"Please review this slide.", presentation->get_Slide(0), position, DateTime::get_Now());

    auto outputFile = String::Format(u"review_pass_{0}.pptx", pass);
    presentation->Save(outputFile, SaveFormat::Pptx);
    inputFile = outputFile;
}
```

يضيف المرور الثاني تعليقًا آخر دون إضافة كاتب آخر أو إزالة التعليقات الموجودة. يحتوي الملف النهائي، `review_pass_2.pptx`، على كل من التعليقات الجديدة وأي تعليقات أصلية. إعادة استخدام كاتب لا تقوم بإزالة التكرارات في التعليقات: لتجنب إضافة نفس التعليق مرارًا، نفذ كشفًا منفصلاً للتكرارات قبل إضافته.

## **الوصول إلى تعليقات الشرائح**

يفتح المثال عرضًا تقديميًا موجودًا ويقرأ المجموعة التي تُعيدها الدالة [get_CommentAuthors](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_commentauthors/). لكل كاتب، يتنقل عبر المجموعة التي تُعيدها الدالة [get_Comments](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthor/get_comments/) ويطبع رقم الشريحة، نص التعليق، اسم الكاتب، ووقت الإنشاء. يجب أن يحتوي العرض التقديمي المُدخل على تعليقات لإنتاج مخرجات وحدة التحكم.

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

التعليق الأصلي هو التعليق الأصلي في أعلى تسلسل الردود. تسمح طريقتا [get_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/get_parentcomment/) و [set_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) في واجهة [IComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/) بالحصول على أو ضبط التعليق الأصلي للتعليق.

ينشئ المثال تعليقات من كاتبَيْن ويستخدم [set_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) لبناء الردود، بما في ذلك رد على رد آخر. تمرير `nullptr` إلى [GetSlideComments](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getslidecomments/) يسترجع التعليقات من جميع الكتاب؛ تقوم وحدة التحكم بعمل مسافات بادئة لكل إدخال وفقًا لعمقه في تسلسل الردود. يحفظ المثال النقاش الكامل، ويستدعي [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/remove/) على أول تعليق جذري، ويحفظ عرضًا تقديميًا ثانياً مع إزالة ذلك التعليق وردوده.

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

auto originalAuthor = presentation->get_CommentAuthors()->AddAuthor(u"Author_1", u"A.A.");
auto rootComment = originalAuthor->get_Comments()->AddComment(u"comment 1", slide, position, createdTime);

auto reviewer = presentation->get_CommentAuthors()->AddAuthor(u"Author_2", u"B.B.");
auto firstReply = reviewer->get_Comments()->AddComment(u"reply 1 for comment 1", slide, position, createdTime);
firstReply->set_ParentComment(rootComment);

auto secondReply = reviewer->get_Comments()->AddComment(u"reply 2 for comment 1", slide, position, createdTime);
secondReply->set_ParentComment(rootComment);

auto subReply = originalAuthor->get_Comments()->AddComment(u"subreply 3 for reply 2", slide, position, createdTime);
subReply->set_ParentComment(secondReply);

reviewer->get_Comments()->AddComment(u"comment 2", slide, position, createdTime);
auto separateComment = reviewer->get_Comments()->AddComment(u"comment 3", slide, position, createdTime);

auto separateReply = originalAuthor->get_Comments()->AddComment(u"reply 4 for comment 3", slide, position, createdTime);
separateReply->set_ParentComment(separateComment);

auto comments = slide->GetSlideComments(nullptr);
for (auto i = 0; i < comments->get_Length(); i++)
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

rootComment->Remove();
presentation->Save(u"remove_comment.pptx", SaveFormat::Pptx);
```
{{% alert color="warning" title="Warning" %}}
* عندما تُستخدم طريقة [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/remove/) لواجهة [IComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/) لحذف تعليق، تُحذف جميع الردود على ذلك التعليق أيضًا.
* إذا أدت طريقة [set_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) إلى إنشاء إشارة دائرية، يتم إلقاء استثناء [PptxEditException](https://reference.aspose.com/slides/cpp/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **إضافة تعليقات حديثة**

يمكن ربط التعليقات الحديثة بالشرائح نفسها، أو بشكل محدد، أو بنطاق نص داخل AutoShape. تقبل طريقة [ICommentCollection::AddModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addmoderncomment/) معلمة [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) بالإضافة إلى إحداثيات الشريحة وعلامة التعليق.

عند تمرير `nullptr` كمعلمة الشكل، يكون التعليق تعليقًا على مستوى الشريحة. يتم وضع علامته وفقًا للإحداثيات المقدمة، ولكن لا يرتبط بشكل معين، لذا تُعيد [IModernComment::get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/) `nullptr`. عند توفير [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/)، يتم تثبيت التعليق على ذلك الشكل. لا تزال الإحداثيات تحدد موضع علامة التعليق على الشريحة، بينما يمكن استرجاع ارتباط الشكل عبر [IModernComment::get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/).

### **تثبيت تعليق حديث على شكل**

يستدعي المثال [AddModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addmoderncomment/) مرتين: مرةً مع شكل `nullptr` لتعليق على مستوى الشريحة ومرةً أخرى مع مستطيل كمرساة. طباعة [get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/) تُظهر `True` للتحقق من عدم وجود الشكل في التعليق على مستوى الشريحة و`Revenue title` للتعليق المثبت. يتم حفظ كلا التعليقين مع العرض التقديمي.

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

يمكن استخدام أي كائن شريحة يُطبق [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) كمرساة شكل. تشمل الأمثلة الشائعة [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)، [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/)، [IGroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/)، [IConnector](https://reference.aspose.com/slides/cpp/aspose.slides/iconnector/)، و[IGraphicalObject](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobject/) مثل المخططات.

يستخدم المثال [AddModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addmoderncomment/) لربط تعليق مع كل من الأنواع الخمسة للأشكال: AutoShape، إطار صورة، مجموعة، موصل، ومخطط. تستخدم الصورة بيانات صورة مدمجة، لذا لا يلزم صورة خارجية. لكل تعليق موقع علامة خاص به، ويحتفظ العرض التقديمي المحفوظ بجميع ارتباطات الأشكال الخمسة.

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

### **تثبيت تعليق على نص وتعيين الحالة**

بالنسبة لتعليق حديث مرتبط بـ [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)، تتحكم كل من [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionstart/) و [IModernComment::set_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionstart/) في موقع بدء النص المحدد داخل إطار نص الشكل. بالمثل، تتحكم كل من [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionlength/) و [IModernComment::set_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionlength/) في طول التحديد. معًا، تربط هذه الطرق التعليق بنطاق نص محدد داخل AutoShape.

تستخدم طرق [IModernComment::get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_status/) و [IModernComment::set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_status/) قيمة من تعداد [ModernCommentStatus](https://reference.aspose.com/slides/cpp/aspose.slides/moderncommentstatus/):

- `NotDefined` — لا يتم تعريف حالة تعليق حديث محددة.
- `Active` — التعليق نشط.
- `Resolved` — تم حل التعليق.
- `Closed` — التعليق مغلق.

يثبت المثال تعليقًا حديثًا على كلمة "quarterly revenue" في نص المستطيل. يحسب بداية التحديد الصفرية من النص، يمررها إلى [set_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionstart/)، ويستدعي [set_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionlength/) بعدد الأحرف المحددة. بعد استدعاء [set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_status/) بـ `Resolved`، يحفظ العرض التقديمي ويعيد فتحه. يجب أن يطبع الفحص الأربعة في وحدة التحكم `True`، مؤكدًا أن ارتباط الشكل، نطاق النص، والحالة تم الحفاظ عليها.

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

يتطلب المثال عرضًا تقديميًا موجودًا يحتوي على تعليقات حديثة ويطبع نصها، حالتها، وتفاصيل الربط. لتفحصه، تحقق من أي تعليقات تنفذ [IModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/)، ثم فحص [IModernComment::get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/)، [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionstart/), [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionlength/)، و[IModernComment::get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_status/). يشير شكل `nullptr` إلى تعليق على مستوى الشريحة. لمرساة [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)، تحدد طرق اختيار النص النطاق المرتبط بإطار نص الشكل.

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

تتيح لك Aspose.Slides for C++ إزالة جميع التعليقات ومؤلفيها من عرض تقديمي أو حذف تعليقات محددة مع إبقاء البقية. توضح الأمثلة التالية كلا النهجين وتحفظ العرض التقديمي المحدّث.

### **إزالة جميع التعليقات ومؤلفي التعليقات**

يفتح المثال عرضًا تقديميًا موجودًا ويستدعي [ICommentCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/clear/) لكل كاتب، ثم يستدعي [ICommentAuthorCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/clear/) لإزالة المؤلفين أنفسهم. لا يحتوي العرض التقديمي المحفوظ على تعليقات ولا على مؤلفي التعليقات. استخدم عرضًا تقديميًا يحتوي على تعليقات لملاحظة الإزالة.

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

### **إزالة تعليقات محددة**

ينشئ المثال تعليقاتين على شريحة واحدة ويستخدم [GetSlideComments](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getslidecomments/) للعثور على التعليقات لكل كاتب. يجمع التعليقات التي يساوي نصها "comment 1" قبل استدعاء [ICommentCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/remove/)، متجنبًا تغييرات على المجموعة أثناء الاختيار. يحتفظ العرض التقديمي المحفوظ بـ "comment 2" فقط.

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

## **الأسئلة المتداولة**

**هل تدعم Aspose.Slides حالة "تم حله" للتعليقات الحديثة؟**

نعم. تستخدم [IModernComment::get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_status/) و [IModernComment::set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_status/) قيمة من تعداد [ModernCommentStatus](https://reference.aspose.com/slides/cpp/aspose.slides/moderncommentstatus/)، بما في ذلك `Resolved`. تُخزن الحالة في العرض التقديمي ويمكن قراءتها مرة أخرى بعد إعادة فتح الملف.

**هل تدعم المناقشات المتسلسلة (سلاسل الردود) وهل هناك حد للتعشيق؟**

نعم. يمكن لكل تعليق الإشارة إلى [parent comment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/)، مما يتيح سلاسل الردود. لا تُحدد واجهة برمجة التطبيقات حدًا محددًا لعمق التعشيق.

**في أي نظام إحداثيات يتم تعريف موضع علامة التعليق على الشريحة؟**

يتم تعريف موضع علامة التعليق بواسطة إحداثيات ذات نقطة عائمة في نظام إحداثيات الشريحة، مما يتيح لك وضعها بدقة على الشريحة.