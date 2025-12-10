---
title: إدارة تعليقات العرض في .NET
linktitle: تعليقات العرض
type: docs
weight: 100
url: /ar/net/presentation-comments/
keywords:
- تعليق
- تعليق حديث
- تعليقات PowerPoint
- تعليقات العرض
- تعليقات الشريحة
- إضافة تعليق
- الوصول إلى التعليق
- تحرير التعليق
- الرد على التعليق
- إزالة التعليق
- حذف التعليق
- PowerPoint
- عرض
- .NET
- C#
- Aspose.Slides
description: "تحكم في تعليقات العرض باستخدام Aspose.Slides لـ .NET: إضافة، قراءة، تحرير، وحذف التعليقات في ملفات PowerPoint بسرعة وسهولة."
---

في PowerPoint، يظهر التعليق كملحوظة أو توضيح على شريحة. عند النقر على التعليق، يتم الكشف عن محتوياته أو رسائله. 

## **لماذا نضيف التعليقات إلى العروض التقديمية؟**

قد ترغب في استخدام التعليقات لتقديم ملاحظات أو التواصل مع زملائك عند مراجعة العروض التقديمية.

للسماح لك باستخدام التعليقات في عروض PowerPoint، توفر Aspose.Slides للـ .NET ما يلي:

* الفئة [Presentation]، التي تحتوي على مجموعات المؤلفين (من الخاصية [CommentAuthorCollection]). المؤلفون يضيفون تعليقات إلى الشرائح. 
* الواجهة [ICommentCollection]، التي تحتوي على مجموعة التعليقات للمؤلفين الفرديين. 
* الفئة [IComment]، التي تحتوي على معلومات حول المؤلفين وتعليقاتهم: من أضاف التعليق، وقت إضافة التعليق، موقع التعليق، إلخ. 
* الفئة [CommentAuthor]، التي تحتوي على معلومات حول المؤلفين الفرديين: اسم المؤلف، أحرفه الأولى، التعليقات المرتبطة باسم المؤلف، إلخ. 

## **إضافة تعليقات إلى الشريحة**
هذا الكود C# يوضح لك كيفية إضافة تعليق إلى شريحة في عرض PowerPoint:
```c#
// ينشئ كائن الفئة Presentation
using (Presentation presentation = new Presentation())
{
    // يضيف شريحة فارغة
    presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

    // يضيف مؤلفًا
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Jawad", "MF");

    // يحدد موضع التعليقات
    PointF point = new PointF();
    point.X = 0.2f;
    point.Y = 0.2f;

    // يضيف تعليق شريحة لمؤلف على الشريحة 1
    author.Comments.AddComment("Hello Jawad, this is slide comment", presentation.Slides[0], point, DateTime.Now);

    // يضيف تعليق شريحة لمؤلف على الشريحة 2
    author.Comments.AddComment("Hello Jawad, this is second slide comment", presentation.Slides[1], point, DateTime.Now);

    // يصل إلى ISlide 1
    ISlide slide = presentation.Slides[0];

    // عندما يتم تمرير null كمعامل، يتم جلب التعليقات من جميع المؤلفين إلى الشريحة المختارة
    IComment[] Comments = slide.GetSlideComments(author);

    // يصل إلى التعليق في الفهرس 0 للشريحة 1
    String str = Comments[0].Text;

    presentation.Save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.GetLength(0) > 0)
    {
        // يحدد مجموعة تعليقات المؤلف في الفهرس 0
        ICommentCollection commentCollection = Comments[0].Author.Comments;
        String Comment = commentCollection[0].Text;
    }
}
```


## **الوصول إلى تعليقات الشريحة**
هذا الكود C# يوضح لك كيفية الوصول إلى تعليق موجود على شريحة في عرض PowerPoint:
```c#
// ينشئ كائن الفئة Presentation
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
التعليق الأصلي هو التعليق الأعلى أو الأول في تسلسل هرمي من التعليقات أو الردود. باستخدام الخاصية [ParentComment] (من الواجهة [IComment])، يمكنك تعيين أو الحصول على التعليق الأصلي. 

هذا الكود C# يوضح لك كيفية إضافة تعليقات والحصول على الردود عليها:
```c#
using (Presentation pres = new Presentation())
{
    // يضيف تعليقًا
    ICommentAuthor author1 = pres.CommentAuthors.AddAuthor("Author_1", "A.A.");
    IComment comment1 = author1.Comments.AddComment("comment1", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    // يضيف ردًا على التعليق 1
    ICommentAuthor author2 = pres.CommentAuthors.AddAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.Comments.AddComment("reply 1 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply1.ParentComment = comment1;

    // يضيف ردًا آخر على التعليق 1
    IComment reply2 = author2.Comments.AddComment("reply 2 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply2.ParentComment = comment1;

    // يضيف ردًا على رد موجود
    IComment subReply = author1.Comments.AddComment("subreply 3 for reply 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    subReply.ParentComment = reply2;

    IComment comment2 = author2.Comments.AddComment("comment 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    IComment comment3 = author2.Comments.AddComment("comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    IComment reply3 = author1.Comments.AddComment("reply 4 for comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply3.ParentComment = comment3;

    // يعرض تسلسل هرم التعليقات على وحدة التحكم
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

    // يزيل التعليق 1 وجميع الردود عليه
    comment1.Remove();

    pres.Save("remove_comment.pptx", SaveFormat.Pptx);
}
```


{{% alert color="warning" title="Attention" %}} 

* عند استخدام طريقة [Remove] (من الواجهة [IComment]) لحذف تعليق، يتم حذف الردود على التعليق أيضًا. 
* إذا أدّى ضبط [ParentComment] إلى إشارة دائرية، سيتم إلقاء استثناء [PptxEditException].

{{% /alert %}}

## **إضافة تعليقات حديثة**

في عام 2021، قدمت Microsoft *التعليقات الحديثة* في PowerPoint. تحسّن ميزة التعليقات الحديثة بشكل كبير التعاون في PowerPoint. من خلال التعليقات الحديثة، يحصل مستخدمو PowerPoint على إمكانية حل التعليقات، ربط التعليقات بالكائنات والنصوص، والتفاعل بسهولة أكبر مما كان قبل ذلك. 

في [Aspose Slides for .NET 21.11]، نفّذنا دعم التعليقات الحديثة بإضافة الفئة [ModernComment]. أضيفت الطريقتان [AddModernComment] و [InsertModernComment] إلى الفئة [CommentCollection]. 

هذا الكود C# يوضح لك كيفية إضافة تعليق حديث إلى شريحة في عرض PowerPoint: 
```c#
using (Presentation pres = new Presentation())
{
     ICommentAuthor newAuthor = pres.CommentAuthors.AddAuthor("Some Author", "SA");
     IModernComment modernComment = newAuthor.Comments.AddModernComment("This is a modern comment", pres.Slides[0], null, new PointF(100, 100), DateTime.Now);
 
     pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **إزالة التعليقات**

### **حذف جميع التعليقات والمؤلفين**

هذا الكود C# يوضح لك كيفية إزالة جميع التعليقات والمؤلفين في عرض تقديمي:
```c#
using (var presentation = new Presentation("example.pptx"))
{
    // يحذف جميع التعليقات من العرض
    foreach (var author in presentation.CommentAuthors)
    {
        author.Comments.Clear();
    }

    // يحذف جميع المؤلفين
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
    
    // إزالة جميع التعليقات التي تحتوي على نص "comment 1"
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


## **FAQ**

**هل يدعم Aspose.Slides حالة مثل 'تم الحل' للتعليقات الحديثة؟**

نعم. التعليقات الحديثة ([ModernComment]) توفر خاصية [Status]؛ يمكنك قراءة وتعيين حالة التعليق (على سبيل المثال، وضعه كـ "تم الحل")، ويتم حفظ هذه الحالة في الملف وتُعترف بها في PowerPoint.

**هل يتم دعم المناقشات المتسلسلة (سلاسل الرد) وهل هناك حد للتعشيق؟**

نعم. يمكن لكل تعليق الإشارة إلى [parent comment] الخاص به، مما يتيح سلاسل رد غير محدودة. لا تحدد الـ API حدًا محددًا لعمق التعشيق.

**في أي نظام إحداثيات يتم تعريف موضع علامة التعليق على الشريحة؟**

يُخزن الموضع كنقطة ذات قيم فاصلة عائمة في نظام إحداثيات الشريحة، مما يتيح لك وضع علامة التعليق بدقة في المكان المطلوب.