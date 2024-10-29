---
title: تعليقات العرض
type: docs
weight: 100
url: /ar/net/presentation-comments/
keywords: "تعليقات، تعليقات PowerPoint، عرض PowerPoint، C#، Csharp، Aspose.Slides لـ .NET"
description: "إضافة تعليقات وردود في عرض PowerPoint باستخدام C# أو .NET"
---

في PowerPoint، تظهر التعليقات كنوتة أو ملاحظة على شريحة. عند النقر على تعليق، يتم الكشف عن محتوياته أو رسائله.

## **لماذا نضيف تعليقات إلى العروض؟**

قد ترغب في استخدام التعليقات لتقديم ملاحظات أو التواصل مع زملائك عند مراجعة العروض.

للسماح لك باستخدام التعليقات في عروض PowerPoint، يوفر Aspose.Slides لـ .NET

* صنف [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)، الذي يحتوي على مجموعات من المؤلفين (من خاصية [CommentAuthorCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/properties/index)). يضيف المؤلفون تعليقات إلى الشرائح.
* واجهة [ICommentCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection)، التي تحتوي على مجموعة من التعليقات للمؤلفين الفرديين.
* صنف [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment)، الذي يحتوي على معلومات حول المؤلفين وتعليقاتهم: من أضاف التعليق، الوقت الذي تمت إضافة التعليق فيه، موقع التعليق، إلخ.
* صنف [CommentAuthor](https://reference.aspose.com/slides/net/aspose.slides/commentauthor)، الذي يحتوي على معلومات حول المؤلفين الفرديين: اسم المؤلف، الأحرف الأولى له، التعليقات المرتبطة باسم المؤلف، إلخ.

## **إضافة تعليق على الشريحة**
يوضح لك هذا الرمز C# كيفية إضافة تعليق إلى شريحة في عرض PowerPoint:

```c#
// يقوم بإنشاء صنف Presentation
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

    // يضيف تعليق على الشريحة لمؤلف على الشريحة 1
    author.Comments.AddComment("مرحبًا Jawad، هذا تعليق الشريحة", presentation.Slides[0], point, DateTime.Now);

    // يضيف تعليق على الشريحة لمؤلف على الشريحة 2
    author.Comments.AddComment("مرحبًا Jawad، هذا هو تعليق الشريحة الثاني", presentation.Slides[1], point, DateTime.Now);

    // يصل إلى الشريحة ISlide 1
    ISlide slide = presentation.Slides[0];

    // عند تمرير null كوسيط، يتم جلب التعليقات من جميع المؤلفين إلى الشريحة المحددة
    IComment[] Comments = slide.GetSlideComments(author);

    // يصل إلى التعليق عند الفهرس 0 للشريحة 1
    String str = Comments[0].Text;

    presentation.Save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.GetLength(0) > 0)
    {
        // يحدد مجموعة تعليقات المؤلف عند الفهرس 0
        ICommentCollection commentCollection = Comments[0].Author.Comments;
        String Comment = commentCollection[0].Text;
    }
}
```

## **الوصول إلى تعليقات الشريحة**
يوضح لك هذا الرمز C# كيفية الوصول إلى تعليق موجود على شريحة في عرض PowerPoint:

```c#
// يقوم بإنشاء صنف Presentation
using (Presentation presentation = new Presentation("Comments1.pptx"))
{
    foreach (var commentAuthor in presentation.CommentAuthors)
    {
        var author = (CommentAuthor) commentAuthor;
        foreach (var comment1 in author.Comments)
        {
            var comment = (Comment) comment1;
            Console.WriteLine("ISlide :" + comment.Slide.SlideNumber + " لديه تعليق: " + comment.Text + " مع المؤلف: " + comment.Author.Name + " تم نشره في الوقت :" + comment.CreatedTime + "\n");
        }
    }
}
```

## **الرد على التعليقات**
التعليق الأب هو التعليق الأعلى أو الأصلي في تسلسل تعليقات أو ردود. باستخدام خاصية [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/properties/parentcomment) (من واجهة [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment))، يمكنك تعيين أو الحصول على تعليق الأب.

يوضح لك هذا الرمز C# كيفية إضافة التعليقات والحصول على الردود عليها:

```c#
using (Presentation pres = new Presentation())
{
    // يضيف تعليقًا
    ICommentAuthor author1 = pres.CommentAuthors.AddAuthor("Author_1", "A.A.");
    IComment comment1 = author1.Comments.AddComment("comment1", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    // يضيف ردًا على comment1
    ICommentAuthor author2 = pres.CommentAuthors.AddAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.Comments.AddComment("رد 1 على التعليق 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply1.ParentComment = comment1;

    // يضيف ردًا آخر على comment1
    IComment reply2 = author2.Comments.AddComment("رد 2 على التعليق 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply2.ParentComment = comment1;

    // يضيف ردًا على الرد الحالي
    IComment subReply = author1.Comments.AddComment("رد فرعي 3 على الرد 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    subReply.ParentComment = reply2;

    IComment comment2 = author2.Comments.AddComment("تعليق 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    IComment comment3 = author2.Comments.AddComment("تعليق 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    IComment reply3 = author1.Comments.AddComment("رد 4 على التعليق 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply3.ParentComment = comment3;

    // يعرض تسلسل التعليقات على وحدة التحكم
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

{{% alert color="warning" title="انتباه" %}} 

* عند استخدام طريقة [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/methods/remove) (من واجهة [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment)) لحذف تعليق، سيتم أيضًا حذف الردود على التعليق. 
* إذا أسفر إعداد [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/properties/parentcomment) عن حلقة دائرية، سيتم طرح استثناء [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception).

{{% /alert %}}

## **إضافة تعليق حديث**

في عام 2021، قدمت Microsoft *تعليقات حديثة* في PowerPoint. تعمل ميزة التعليقات الحديثة على تحسين التعاون بشكل كبير في PowerPoint. من خلال التعليقات الحديثة، يحصل مستخدمو PowerPoint على القدرة على حل التعليقات، ربط التعليقات بالأجسام والنصوص، والانخراط في التفاعلات بسهولة أكبر من السابق.

في [Aspose Slides لـ .NET 21.11](https://docs.aspose.com/slides/net/aspose-slides-for-net-21-11-release-notes/)، قمنا بتنفيذ دعم التعليقات الحديثة من خلال إضافة صنف [ModernComment](https://reference.aspose.com/slides/net/aspose.slides/moderncomment). وتمت إضافة طريقتي [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/commentcollection/methods/addmoderncomment) و [InsertModernComment](https://reference.aspose.com/slides/net/aspose.slides/commentcollection/methods/insertmoderncomment) إلى صنف [CommentCollection](https://reference.aspose.com/slides/net/aspose.slides/commentcollection).

يوضح لك هذا الرمز C# كيفية إضافة تعليق حديث إلى شريحة في عرض PowerPoint:

```c#
using (Presentation pres = new Presentation())
{
     ICommentAuthor newAuthor = pres.CommentAuthors.AddAuthor("Some Author", "SA");
     IModernComment modernComment = newAuthor.Comments.AddModernComment("هذا تعليق حديث", pres.Slides[0], null, new PointF(100, 100), DateTime.Now);
 
     pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **إزالة تعليق**

### **حذف جميع التعليقات والمؤلفين**

يوضح لك هذا الرمز C# كيفية إزالة جميع التعليقات والمؤلفين في عرض تقديمي:

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

### **حذف تعليقات معينة**

يوضح لك هذا الرمز C# كيفية حذف تعليقات معينة على شريحة:

```c#
using (var presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    
    // إضافة التعليقات...
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("مؤلف", "A");
    author.Comments.AddComment("تعليق 1", slide, new PointF(0.2f, 0.2f), DateTime.Now);
    author.Comments.AddComment("تعليق 2", slide, new PointF(0.3f, 0.2f), DateTime.Now);
    
    // إزالة جميع التعليقات التي تحتوي على نص "تعليق 1"
    foreach (ICommentAuthor commentAuthor in presentation.CommentAuthors)
    {
        List<IComment> toRemove = new List<IComment>();
        foreach (IComment comment in slide.GetSlideComments(commentAuthor))
        {
            if (comment.Text == "تعليق 1")
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