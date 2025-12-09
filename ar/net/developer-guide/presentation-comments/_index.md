---
title: إدارة تعليقات العرض التقديمي في .NET
linktitle: تعليقات العرض التقديمي
type: docs
weight: 100
url: /ar/net/presentation-comments/
keywords:
- تعليق
- تعليق حديث
- تعليقات PowerPoint
- تعليقات العرض التقديمي
- تعليقات الشريحة
- إضافة تعليق
- الوصول إلى التعليق
- تعديل تعليق
- الرد على التعليق
- إزالة تعليق
- حذف تعليق
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تحكم في تعليقات العرض التقديمي باستخدام Aspose.Slides for .NET: أضف، واقرأ، وعدل، واحذف التعليقات في ملفات PowerPoint بسرعة وسهولة."
---

في PowerPoint، يظهر التعليق كملاحظة أو توضيح على الشريحة. عند النقر على التعليق، يتم الكشف عن محتوياته أو رسائله. 

## **لماذا نضيف تعليقات إلى العروض التقديمية؟**

قد ترغب في استخدام التعليقات لتقديم الملاحظات أو التواصل مع زملائك عند مراجعة العروض التقديمية.

للسماح لك باستخدام التعليقات في عروض PowerPoint، يوفر Aspose.Slides for .NET:

* الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) التي تحتوي على مجموعات المؤلفين (من الخاصية [CommentAuthorCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/properties/index)). يضيف المؤلفون تعليقات إلى الشرائح. 
* الواجهة [ICommentCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection) التي تحتوي على مجموعة التعليقات لكل مؤلف. 
* الفئة [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) التي تحتوي على معلومات حول المؤلفين وتعليقاتهم: من أضاف التعليق، وقت إضافة التعليق، موضع التعليق، إلخ. 
* الفئة [CommentAuthor](https://reference.aspose.com/slides/net/aspose.slides/commentauthor) التي تحتوي على معلومات حول كل مؤلف: اسم المؤلف، حروفه الأولى، التعليقات المرتبطة باسم المؤلف، إلخ. 

## **إضافة تعليق إلى شريحة**
هذا الكود C# يوضح لك كيفية إضافة تعليق إلى شريحة في عرض PowerPoint:
```c#
// ينشئ فئة Presentation
using (Presentation presentation = new Presentation())
{
    // يضيف شريحة فارغة
    presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

    // يضيف مؤلفًا
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Jawad", "MF");

    // يحدد الموقع للتعليقات
    PointF point = new PointF();
    point.X = 0.2f;
    point.Y = 0.2f;

    // يضيف تعليق شريحة لمؤلف على الشريحة 1
    author.Comments.AddComment("Hello Jawad, this is slide comment", presentation.Slides[0], point, DateTime.Now);

    // يضيف تعليق شريحة لمؤلف على الشريحة 2
    author.Comments.AddComment("Hello Jawad, this is second slide comment", presentation.Slides[1], point, DateTime.Now);

    // يصل إلى ISlide 1
    ISlide slide = presentation.Slides[0];

    // عند تمرير null كمعامل، يتم جلب التعليقات من جميع المؤلفين إلى الشريحة المحددة
    IComment[] Comments = slide.GetSlideComments(author);

    // يصل إلى التعليق في الفهرس 0 للشريحة 1
    String str = Comments[0].Text;

    presentation.Save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.GetLength(0) > 0)
    {
        // يختار مجموعة تعليقات المؤلف في الفهرس 0
        ICommentCollection commentCollection = Comments[0].Author.Comments;
        String Comment = commentCollection[0].Text;
    }
}
```


## **الوصول إلى تعليقات الشريحة**
هذا الكود C# يوضح لك كيفية الوصول إلى تعليق موجود على شريحة في عرض PowerPoint:
```c#
// ينشئ فئة Presentation
using (Presentation presentation = new Presentation("Comments1.pptx"))
{
    foreach (var commentAuthor in presentation.CommentAuthors)
    {
        var author = (CommentAuthor) commentAuthor;
        foreach (var comment1 in author.Comments)
        {
            var comment = (Comment) comment1;
            Console.WriteLine("ISlide :" + comment.Slide.SlideNumber + " has comment: " + comment.Text + " with Author: " + comment.Author.Name + " posted on time :" + comment.CreatedTime + "\n");
        }
    }
}
```


## **الرد على التعليقات**
التعليق الأصلي هو أعلى أو أول تعليق في تسلسل هرمي من التعليقات أو الردود. باستخدام خاصية [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/properties/parentcomment) (من الواجهة [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment)) يمكنك تعيين أو الحصول على التعليق الأصلي. 

هذا الكود C# يوضح لك كيفية إضافة تعليقات والحصول على الردود عليها:
```c#
using (Presentation pres = new Presentation())
{
    // يضيف تعليق
    ICommentAuthor author1 = pres.CommentAuthors.AddAuthor("Author_1", "A.A.");
    IComment comment1 = author1.Comments.AddComment("comment1", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    // يضيف ردًا على comment1
    ICommentAuthor author2 = pres.CommentAuthors.AddAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.Comments.AddComment("reply 1 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply1.ParentComment = comment1;

    // يضيف ردًا آخر على comment1
    IComment reply2 = author2.Comments.AddComment("reply 2 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply2.ParentComment = comment1;

    // يضيف ردًا على رد موجود
    IComment subReply = author1.Comments.AddComment("subreply 3 for reply 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    subReply.ParentComment = reply2;

    IComment comment2 = author2.Comments.AddComment("comment 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    IComment comment3 = author2.Comments.AddComment("comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    IComment reply3 = author1.Comments.AddComment("reply 4 for comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply3.ParentComment = comment3;

    // يعرض تسلسل التعليقات الهرمي على وحدة التحكم
    ISlide slide = pres.Slides[0];
    var comments = slide.GetSlideComments(null);
    for (int i = 0; i < comments.Length; i++)
    {
        IComment comment = comments[i];
        while (comment.ParentComment != null)
        {
            Console.Write("\t");
            comment = comment.ParentComment;
        }

        Console.Write("{0} : {1}", comments[i].Author.Name, comments[i].Text);
        Console.WriteLine();
    }

    pres.Save("parent_comment.pptx",SaveFormat.Pptx);

    // يزيل comment1 وجميع الردود عليه
    comment1.Remove();

    pres.Save("remove_comment.pptx", SaveFormat.Pptx);
}
```


{{% alert color="warning" title="Attention" %}} 

* عند استخدام طريقة [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/methods/remove) (من الواجهة [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment)) لحذف تعليق، يتم أيضًا حذف الردود على التعليق. 
* إذا أدت إعدادات [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/properties/parentcomment) إلى مرجع دائري، سيتم رمي الاستثناء [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception).

{{% /alert %}}

## **إضافة تعليق حديث**

في عام 2021، قدمت Microsoft *التعليقات الحديثة* في PowerPoint. تُحسن ميزة التعليقات الحديثة بشكل كبير التعاون في PowerPoint. من خلال التعليقات الحديثة، يتمكن مستخدمو PowerPoint من حل التعليقات، ربط التعليقات بالأجسام والنصوص، والتفاعل بسهولة أكبر مما كان من قبل. 

في [Aspose Slides for .NET 21.11](https://docs.aspose.com/slides/net/aspose-slides-for-net-21-11-release-notes/)، قمنا بتنفيذ دعم التعليقات الحديثة بإضافة الفئة [ModernComment](https://reference.aspose.com/slides/net/aspose.slides/moderncomment). تمت إضافة الطريقتين [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/commentcollection/methods/addmoderncomment) و [InsertModernComment](https://reference.aspose.com/slides/net/aspose.slides/commentcollection/methods/insertmoderncomment) إلى الفئة [CommentCollection](https://reference.aspose.com/slides/net/aspose.slides/commentcollection). 

هذا الكود C# يوضح لك كيفية إضافة تعليق حديث إلى شريحة في عرض PowerPoint: 
```c#
using (Presentation pres = new Presentation())
{
     ICommentAuthor newAuthor = pres.CommentAuthors.AddAuthor("Some Author", "SA");
     IModernComment modernComment = newAuthor.Comments.AddModernComment("This is a modern comment", pres.Slides[0], null, new PointF(100, 100), DateTime.Now);
 
     pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **إزالة التعليق**

### **حذف جميع التعليقات والمؤلفين**

هذا الكود C# يوضح لك كيفية حذف جميع التعليقات والمؤلفين في عرض تقديمي:
```c#
using (var presentation = new Presentation("example.pptx"))
{
    // حذف جميع التعليقات من العرض التقديمي
    foreach (var author in presentation.CommentAuthors)
    {
        author.Comments.Clear();
    }

    // حذف جميع المؤلفين
    presentation.CommentAuthors.Clear();

    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```


### **حذف تعليقات محددة**

هذا الكود C# يوضح لك كيفية حذف تعليقات محددة على شريحة:
```c#
using (var presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    
    // إضافة تعليقات...
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Author", "A");
    author.Comments.AddComment("comment 1", slide, new PointF(0.2f, 0.2f), DateTime.Now);
    author.Comments.AddComment("comment 2", slide, new PointF(0.3f, 0.2f), DateTime.Now);
    
    // إزالة جميع التعليقات التي تحتوي على النص "comment 1"
    foreach (ICommentAuthor commentAuthor in presentation.CommentAuthors)
    {
        List<IComment> toRemove = new List<IComment>();
        foreach (IComment comment in slide.GetSlideComments(commentAuthor))
        {
            if (comment.Text == "comment 1")
            {
                toRemove.Add(comment);
            }
        }
        
        foreach (IComment comment in toRemove)
        {
            commentAuthor.Comments.Remove(comment);
        }
    }
    
    presentation.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **الأسئلة الشائعة**

**هل يدعم Aspose.Slides حالة مثل 'محلول' للتعليقات الحديثة؟**

نعم. تُظهر [Modern comments](https://reference.aspose.com/slides/net/aspose.slides/moderncomment/) خاصية [Status](https://reference.aspose.com/slides/net/aspose.slides/moderncomment/status/); يمكنك قراءة وتعيين [حالة التعليق](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/) (على سبيل المثال، وضع علامة بأنه محلول)، وهذه الحالة تُحفظ في الملف وتُعترف بها من قبل PowerPoint.

**هل تدعم المناقشات المتسلسلة (سلاسل الردود) وهل هناك حد للتعشيق؟**

نعم. يمكن لكل تعليق الإشارة إلى [التعليق الأصلي](https://reference.aspose.com/slides/net/aspose.slides/comment/parentcomment/)، مما يتيح سلاسل ردود غير محدودة. لا تُحدد الواجهة حدًا معينًا لعمق التعشيق.

**في أي نظام إحداثيات يتم تعريف موضع علامة التعليق على الشريحة؟**

يتم تخزين الموضع كنقطة ذات نقطة عائمة في نظام إحداثيات الشريحة. يتيح لك ذلك وضع علامة التعليق بدقة في المكان الذي تحتاجه.