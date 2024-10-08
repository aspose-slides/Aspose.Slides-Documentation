---
title: تعليقات العرض
type: docs
weight: 100
url: /ar/cpp/presentation-comments/
keywords: "تعليقات، تعليقات باوربوينت، عرض باوربوينت، C++، Aspose.Slides for C++"
description: "إضافة تعليقات وردود في عرض باوربوينت بـ C++"
---

في باوربوينت، تظهر التعليقات كملاحظات أو تعليقات على الشريحة. عند النقر على تعليق، يتم الكشف عن محتوياته أو رسائله.

### **لماذا إضافة تعليقات إلى العروض؟**

قد ترغب في استخدام التعليقات لتقديم ملاحظات أو التواصل مع زملائك عند مراجعة العروض.

لتتيح لك استخدام التعليقات في عروض باوربوينت، تقوم Aspose.Slides for C++ بتوفير

* فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) التي تحتوي على مجموعات المؤلفين (من طريقة [get_CommentAuthors()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#ac100feeb13ea426b85557a829676227d)). يضيف المؤلفون تعليقات إلى الشرائح. 
* واجهة [ICommentCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment_collection) التي تحتوي على مجموعة من التعليقات للمؤلفين الفرديين. 
* فئة [IComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment) التي تحتوي على معلومات حول المؤلفين وتعليقاتهم: من الذي أضاف التعليق، متى تمت إضافة التعليق، موقع التعليق، إلخ. 
* فئة [CommentAuthor](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_author) التي تحتوي على معلومات حول المؤلفين الفرديين: اسم المؤلف، أحرفه الأولى، التعليقات المرتبطة باسم المؤلف، إلخ.

## **إضافة تعليق على الشريحة**
هذا الكود بـ C++ يوضح لك كيفية إضافة تعليق على شريحة في عرض باوربوينت:

```cpp
// يقوم بإنشاء كائن من فئة Presentation
auto presentation = System::MakeObject<Presentation>();
// يضيف شريحة فارغة
presentation->get_Slides()->AddEmptySlide(presentation->get_LayoutSlides()->idx_get(0));

// يضيف مؤلف
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Jawad", u"MF");

// يحدد موقع التعليقات
PointF point;
point.set_X(0.2f);
point.set_Y(0.2f);

// يصل إلى ISlide 1
auto slide1 = presentation->get_Slides()->idx_get(0);
// يصل إلى ISlide 2
auto slide2 = presentation->get_Slides()->idx_get(1);

// يضيف تعليقًا على الشريحة لمؤلف على الشريحة 1
author->get_Comments()->AddComment(u"مرحبًا يا جوان، هذا تعليق على الشريحة", slide1, point, DateTime::get_Now());

// يضيف تعليقًا على الشريحة لمؤلف على الشريحة 2
author->get_Comments()->AddComment(u"مرحبًا يا جوان، هذا هو تعليق الشريحة الثاني", slide2, point, DateTime::get_Now());

// عند تمرير null كوسيط، يتم إحضار التعليقات من جميع المؤلفين إلى الشريحة المحددة
auto comments = slide1->GetSlideComments(author);

// يصل إلى التعليق عند الفهرس 0 للشريحة 1
String str = comments[0]->get_Text();

presentation->Save(u"Comments_out.pptx", SaveFormat::Pptx);

if (comments->GetLength(0) > 0)
{
    // يختار مجموعة تعليقات المؤلف عند الفهرس 0
    auto commentCollection = comments[0]->get_Author()->get_Comments();
    String Comment = commentCollection->idx_get(0)->get_Text();
}
```

## **الوصول إلى تعليقات الشريحة**
هذا الكود بـ C++ يوضح لك كيفية الوصول إلى تعليق موجود على شريحة في عرض باوربوينت:

```cpp
// يقوم بإنشاء كائن من فئة Presentation
auto presentation = System::MakeObject<Presentation>(u"Comments1.pptx");

for (auto&& commentAuthor : presentation->get_CommentAuthors())
{
    auto author = System::ExplicitCast<CommentAuthor>(commentAuthor);
    for (auto&& comment1 : System::IterateOver(author->get_Comments()))
    {
        SmartPtr<Comment> comment = System::ExplicitCast<Comment>(comment1);
        Console::WriteLine(String(u"ISlide :")
                        + comment->get_Slide()->get_SlideNumber()
                        + u" لديه تعليق: " + comment->get_Text()
                        + u" مع المؤلف: " + comment->get_Author()->get_Name()
                        + u" تم نشره في الوقت :" + comment->get_CreatedTime() + u"\n");
    }
}
```

## **الرد على التعليقات**
التعليق الأم هو أعلى تعليق أو التعليق الأصلي في تسلسل هرمي من التعليقات أو الردود. باستخدام خاصية [ParentComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) (من واجهة [IComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment))، يمكنك تعيين أو الحصول على تعليق أم.

هذا الكود بـ C++ يوضح لك كيفية إضافة تعليقات والحصول على ردود عليها:

```cpp
auto pres = System::MakeObject<Presentation>();

// يصل إلى ISlide 1
auto slide1 = pres->get_Slides()->idx_get(0);

// يضيف تعليقًا
auto author1 = pres->get_CommentAuthors()->AddAuthor(u"Author_1", u"A.A.");
auto comment1 = author1->get_Comments()->AddComment(u"comment1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

// يضيف ردًا على comment1
auto author2 = pres->get_CommentAuthors()->AddAuthor(u"Autror_2", u"B.B.");
auto reply1 = author2->get_Comments()->AddComment(u"رد 1 على التعليق 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply1->set_ParentComment(comment1);

// يضيف ردًا آخر على comment1
auto reply2 = author2->get_Comments()->AddComment(u"رد 2 على التعليق 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply2->set_ParentComment(comment1);

// يضيف ردًا على الرد الموجود
auto subReply = author1->get_Comments()->AddComment(u"رد فرعي 3 على الرد 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
subReply->set_ParentComment(reply2);

auto comment2 = author2->get_Comments()->AddComment(u"تعليق 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
auto comment3 = author2->get_Comments()->AddComment(u"تعليق 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

auto reply3 = author1->get_Comments()->AddComment(u"رد 4 على التعليق 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply3->set_ParentComment(comment3);

// يعرض تسلسل التعليقات على وحدة التحكم
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

// يزيل comment1 وجميع الردود عليه
comment1->Remove();

pres->Save(u"remove_comment.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="تنبيه" %}} 

* عند استخدام طريقة [Remove](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment#a8bb818ae804d142195c4edcf9012cccb) (من واجهة [IComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment)) لحذف تعليق، يتم حذف الردود على التعليق أيضًا. 
* إذا كانت إعدادات [ParentComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) تؤدي إلى دائرة مرجعية، سيتم رمي [PptxEditException](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d).

{{% /alert %}}

## **إضافة تعليق حديث**

في عام 2021، قدمت مايكروسوفت *التعليقات الحديثة* في باوربوينت. تعمل ميزة التعليقات الحديثة على تحسين التعاون بشكل كبير في باوربوينت. من خلال التعليقات الحديثة، يحصل مستخدمو باوربوينت على القدرة على حل التعليقات، ربط التعليقات بالكائنات والنصوص، والانخراط في التفاعلات بسهولة أكبر من ذي قبل.

في [Aspose Slides for C++ 21.11](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-21-11-release-notes/)، قمنا بتنفيذ دعم التعليقات الحديثة من خلال إضافة فئة [ModernComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.modern_comment). تمت إضافة طرق [AddModernComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_collection#a3627fcb3b05cd639fd430bd8248fe66b) و[InsertModernComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_collection#ad11c3efb52f3c17f63238447dcc03c94) إلى فئة [CommentCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_collection).

هذا الكود بـ C++ يوضح لك كيفية إضافة تعليق حديث إلى شريحة في عرض باوربوينت: 

```cpp
auto pres = System::MakeObject<Presentation>();
// يصل إلى ISlide 1
auto slide1 = pres->get_Slides()->idx_get(0);

auto newAuthor = pres->get_CommentAuthors()->AddAuthor(u"مؤلف ما", u"SA");
auto modernComment = newAuthor->get_Comments()->AddModernComment(u"هذا تعليق حديث", slide1, nullptr, PointF(100.0f, 100.0f), DateTime::get_Now());

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **إزالة التعليق**

### **حذف جميع التعليقات والمؤلفين**

هذا الكود بـ C++ يوضح لك كيفية إزالة جميع التعليقات والمؤلفين في عرض تقديمي:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"example.pptx");

// يحذف جميع التعليقات من العرض التقديمي
for (auto author : presentation->get_CommentAuthors())
{
    author->get_Comments()->Clear();
}
        
// يحذف جميع المؤلفين
presentation->get_CommentAuthors()->Clear();
presentation->Save(u"example_out.pptx", SaveFormat::Pptx);

```

### **حذف تعليقات محددة**

هذا الكود بـ C++ يوضح لك كيفية حذف تعليقات محددة على شريحة:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
// إضافة تعليقات...
auto author = presentation->get_CommentAuthors()->AddAuthor(u"مؤلف", u"A");
author->get_Comments()->AddComment(u"التعليق 1", slide, PointF(0.2f, 0.2f), System::DateTime::get_Now());
author->get_Comments()->AddComment(u"التعليق 2", slide, PointF(0.3f, 0.2f), System::DateTime::get_Now());
        
// إزالة جميع التعليقات التي تحتوي على نص "التعليق 1"
for (auto commentAuthor : presentation->get_CommentAuthors())
{
    auto toRemove = System::MakeObject<System::Collections::Generic::List<System::SharedPtr<IComment>>>();
    for (auto comment : slide->GetSlideComments(commentAuthor))
    {
        if (comment->get_Text() == u"التعليق 1")
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