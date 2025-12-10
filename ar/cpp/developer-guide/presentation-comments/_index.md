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
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "قم بإدارة تعليقات العرض التقديمي باستخدام Aspose.Slides للغة C++: إضافة، قراءة، تحرير، وحذف التعليقات في ملفات PowerPoint بسرعة وسهولة."
---

في PowerPoint، يظهر التعليق كملاحظة أو شرح على الشريحة. عند النقر على التعليق، تُظهر محتوياته أو رسائله.

### **لماذا إضافة تعليقات إلى العروض التقديمية؟**

قد ترغب في استخدام التعليقات لتقديم ملاحظات أو التواصل مع زملائك عند مراجعة العروض التقديمية.

للسماح لك باستخدام التعليقات في عروض PowerPoint، توفر Aspose.Slides for C++  

* الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) التي تحتوي على مجموعات المؤلفين (من طريقة [get_CommentAuthors()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#ac100feeb13ea426b85557a829676227d)). يضيف المؤلفون تعليقات إلى الشرائح.  
* الواجهة [ICommentCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment_collection) التي تحتوي على مجموعة التعليقات للكاتب الفردي.  
* الفئة [IComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment) التي تحتوي على معلومات عن المؤلفين وتعليقاتهم: من أضاف التعليق، وقت إضافة التعليق، موضع التعليق، إلخ.  
* الفئة [CommentAuthor](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_author) التي تحتوي على معلومات عن كل كاتب: اسم الكاتب، الأحرف الأولى له، التعليقات المرتبطة باسمه، إلخ.

## **إضافة تعليق إلى الشريحة**
هذا الكود C++ يوضح لك كيفية إضافة تعليق إلى شريحة في عرض PowerPoint:
```cpp
// إنشاء كائن من الفئة Presentation
auto presentation = System::MakeObject<Presentation>();
// إضافة شريحة فارغة
presentation->get_Slides()->AddEmptySlide(presentation->get_LayoutSlides()->idx_get(0));

// إضافة مؤلف
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Jawad", u"MF");

// تحديد موضع التعليقات
PointF point;
point.set_X(0.2f);
point.set_Y(0.2f);

// الوصول إلى ISlide 1
auto slide1 = presentation->get_Slides()->idx_get(0);
// الوصول إلى ISlide 2
auto slide2 = presentation->get_Slides()->idx_get(1);

// إضافة تعليق شريحة لمؤلف على الشريحة 1
author->get_Comments()->AddComment(u"Hello Jawad, this is slide comment", slide1, point, DateTime::get_Now());

// إضافة تعليق شريحة لمؤلف على الشريحة 2
author->get_Comments()->AddComment(u"Hello Jawad, this is second slide comment", slide2, point, DateTime::get_Now());

// عند تمرير null كمعامل، يتم جلب التعليقات من جميع المؤلفين إلى الشريحة المحددة
auto comments = slide1->GetSlideComments(author);

// Accesses the comment at index 0 for slide 1
String str = comments[0]->get_Text();

presentation->Save(u"Comments_out.pptx", SaveFormat::Pptx);

if (comments->GetLength(0) > 0)
{
    // اختيار مجموعة تعليقات المؤلف عند الفهرس 0
    auto commentCollection = comments[0]->get_Author()->get_Comments();
    String Comment = commentCollection->idx_get(0)->get_Text();
}
```


## **الوصول إلى تعليقات الشريحة**
هذا الكود C++ يوضح لك كيفية الوصول إلى تعليق موجود على شريحة في عرض PowerPoint:
```cpp
// إنشاء كائن من فئة Presentation
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


## **الرد على التعليقات**
التعليق الأصلي هو أعلى أو أول تعليق في هيكلية التعليقات أو الردود. باستخدام خاصية [ParentComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) من واجهة [IComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment)، يمكنك تعيين أو الحصول على التعليق الأصلي.

هذا الكود C++ يوضح لك كيفية إضافة تعليقات والحصول على الردود عليها:
```cpp
auto pres = System::MakeObject<Presentation>();

// الوصول إلى ISlide 1
auto slide1 = pres->get_Slides()->idx_get(0);

// إضافة تعليق
auto author1 = pres->get_CommentAuthors()->AddAuthor(u"Author_1", u"A.A.");
auto comment1 = author1->get_Comments()->AddComment(u"comment1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

// إضافة رد إلى التعليق 1
auto author2 = pres->get_CommentAuthors()->AddAuthor(u"Autror_2", u"B.B.");
auto reply1 = author2->get_Comments()->AddComment(u"reply 1 for comment 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply1->set_ParentComment(comment1);

// إضافة رد آخر إلى التعليق 1
auto reply2 = author2->get_Comments()->AddComment(u"reply 2 for comment 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply2->set_ParentComment(comment1);

// إضافة رد إلى الرد الموجود
auto subReply = author1->get_Comments()->AddComment(u"subreply 3 for reply 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
subReply->set_ParentComment(reply2);

auto comment2 = author2->get_Comments()->AddComment(u"comment 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
auto comment3 = author2->get_Comments()->AddComment(u"comment 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

auto reply3 = author1->get_Comments()->AddComment(u"reply 4 for comment 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply3->set_ParentComment(comment3);

// عرض هيكلية التعليقات على وحدة التحكم
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

// إزالة التعليق 1 وكل الردود عليه
comment1->Remove();

pres->Save(u"remove_comment.pptx", SaveFormat::Pptx);
```


{{% alert color="warning" title="Attention" %}} 
* عند استخدام طريقة [Remove](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment#a8bb818ae804d142195c4edcf9012cccb) من واجهة [IComment] لحذف تعليق، تُحذف أيضًا الردود على هذا التعليق.  
* إذا أدت إعدادات [ParentComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) إلى إشارة دائرية، سيتم إلقاء استثناء [PptxEditException](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d). 
{{% /alert %}}

## **إضافة تعليق حديث**

في عام 2021، قدمت Microsoft *التعليقات الحديثة* في PowerPoint. تحسّن ميزة التعليقات الحديثة بشكل كبير التعاون في PowerPoint. من خلال التعليقات الحديثة، يمكن لمستخدمي PowerPoint حل التعليقات، ربط التعليقات بالكائنات والنصوص، والتفاعل بسهولة أكبر مما كان سابقًا.

في [Aspose Slides for C++ 21.11](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-21-11-release-notes/)، نفّذنا دعم التعليقات الحديثة بإضافة الفئة [ModernComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.modern_comment). أضيفت طريقتا [AddModernComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_collection#a3627fcb3b05cd639fd430bd8248fe66b) و[InsertModernComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_collection#ad11c3efb52f3c17f63238447dcc03c94) إلى فئة [CommentCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_collection).

هذا الكود C++ يوضح لك كيفية إضافة تعليق حديث إلى شريحة في عرض PowerPoint: 
```cpp
auto pres = System::MakeObject<Presentation>();
// الوصول إلى ISlide 1
auto slide1 = pres->get_Slides()->idx_get(0);

auto newAuthor = pres->get_CommentAuthors()->AddAuthor(u"Some Author", u"SA");
auto modernComment = newAuthor->get_Comments()->AddModernComment(u"This is a modern comment", slide1, nullptr, PointF(100.0f, 100.0f), DateTime::get_Now());

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```


## **إزالة تعليق**

### **حذف جميع التعليقات والمؤلفين**

هذا الكود C++ يوضح لك كيفية حذف جميع التعليقات والمؤلفين في عرض:
```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"example.pptx");

// حذف جميع التعليقات من العرض التقديمي
for (auto author : presentation->get_CommentAuthors())
{
    author->get_Comments()->Clear();
}
        
// حذف جميع المؤلفين
presentation->get_CommentAuthors()->Clear();
presentation->Save(u"example_out.pptx", SaveFormat::Pptx);
```


### **حذف تعليقات محددة**

هذا الكود C++ يوضح لك كيفية حذف تعليقات محددة على شريحة:
```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
// إضافة تعليقات...
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Author", u"A");
author->get_Comments()->AddComment(u"comment 1", slide, PointF(0.2f, 0.2f), System::DateTime::get_Now());
author->get_Comments()->AddComment(u"comment 2", slide, PointF(0.3f, 0.2f), System::DateTime::get_Now());
        
// إزالة جميع التعليقات التي تحتوي على النص "comment 1"
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


## **الأسئلة المتكررة**

**هل يدعم Aspose.Slides حالة مثل 'محلول' للتعليقات الحديثة؟**

نعم. تُظهر [Modern comments](https://reference.aspose.com/slides/cpp/aspose.slides/moderncomment/) طرقًا [get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/moderncomment/get_status/) و[set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/moderncomment/set_status/). يمكنك قراءة وتعيين حالة التعليق (على سبيل المثال، وضع علامة “محلول”)، وتُحفظ هذه الحالة في الملف وتتعرف عليها PowerPoint.

**هل تدعم المناقشات المتسلسلة (سلاسل الردود)، وهل هناك حد للتعمق؟**

نعم. يمكن لكل تعليق الإشارة إلى [parent comment](https://reference.aspose.com/slides/cpp/aspose.slides/comment/set_parentcomment/)، مما يسمح بسلاسل ردود غير محدودة. لا تُعلن الواجهة عن حد معين لعمق التعمق.

**في أي نظام إحداثيات يتم تعريف موضع علامة التعليق على الشريحة؟**

يُخزن الموضع كنقطة ذات قيمة عائمة في نظام إحداثيات الشريحة. يتيح لك ذلك وضع علامة التعليق بدقة في المكان الذي تحتاجه.