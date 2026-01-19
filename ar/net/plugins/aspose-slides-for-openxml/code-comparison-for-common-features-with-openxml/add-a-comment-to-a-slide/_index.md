---
title: إضافة تعليق إلى شريحة
type: docs
weight: 10
url: /ar/net/add-a-comment-to-a-slide/
---

## **العرض التقديمي OpenXML**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Add a comment to a slide.pptx"; 

AddCommentToPresentation(FileName,

"Zeeshan", "MZ",

"This is my programmatically added comment.");

// يضيف تعليقًا إلى الشريحة الأولى في مستند العرض التقديمي.

// يجب أن يحتوي مستند العرض التقديمي على شريحة واحدة على الأقل.

private static void AddCommentToPresentation(string file, string initials, string name, string text)

{

using (PresentationDocument doc = PresentationDocument.Open(file, true))

{

    // إعلان كائن CommentAuthorsPart.

    CommentAuthorsPart authorsPart;

    // التحقق من وجود جزء مؤلفي التعليقات الحالي.

    if (doc.PresentationPart.CommentAuthorsPart == null)

    {

        // إذا لم يكن موجودًا، أضف جزءًا جديدًا.

        authorsPart = doc.PresentationPart.AddNewPart<CommentAuthorsPart>();

    }

    else

    {

        authorsPart = doc.PresentationPart.CommentAuthorsPart;

    }

    // التحقق من وجود قائمة مؤلفي التعليقات في جزء مؤلفي التعليقات.

    if (authorsPart.CommentAuthorList == null)

    {

        // إذا لم تكن موجودة، أضف قائمة جديدة.

        authorsPart.CommentAuthorList = new CommentAuthorList();

    }

    // إعلان معرف مؤلف جديد.

    uint authorId = 0;

    CommentAuthor author = null;

    // إذا كان هناك عناصر فرعية موجودة في قائمة مؤلفي التعليقات...

    if (authorsPart.CommentAuthorList.HasChildren)

    {

        // التحقق من أن المؤلف المدخل موجود في القائمة.

        var authors = authorsPart.CommentAuthorList.Elements<CommentAuthor>().Where(a => a.Name == name && a.Initials == initials);

        // إذا كان موجودًا...

        if (authors.Any())

        {

            // إسناد معرف المؤلف الموجود إلى التعليق الجديد.

            author = authors.First();

            authorId = author.Id;

        }

        // إذا لم يكن موجودًا...

        if (author == null)

        {

            // إسناد معرف جديد للمؤلف المدخل

            authorId = authorsPart.CommentAuthorList.Elements<CommentAuthor>().Select(a => a.Id.Value).Max();

        }

    }

    // إذا لم توجد عناصر فرعية في قائمة مؤلفي التعليقات.

    if (author == null)

    {

        authorId++;

        // إضافة عنصر فرعي جديد (مؤلف تعليق) إلى قائمة مؤلفي التعليقات.

        author = authorsPart.CommentAuthorList.AppendChild<CommentAuthor>

        (new CommentAuthor()

        {

            Id = authorId,

            Name = name,

            Initials = initials,

            ColorIndex = 0

        });

    }

    // الحصول على الشريحة الأولى باستخدام طريقة GetFirstSlide.

    SlidePart slidePart1 = GetFirstSlide(doc);

    // إعلان جزء التعليقات.

    SlideCommentsPart commentsPart;

    // التحقق من وجود جزء تعليقات في الشريحة الأولى.

    if (slidePart1.GetPartsOfType<SlideCommentsPart>().Count() == 0)

    {

        // إذا لم يكن موجودًا، أضف جزءًا جديدًا للتعليقات.

        commentsPart = slidePart1.AddNewPart<SlideCommentsPart>();

    }

    else

    {

        // وإلا، استخدم أول جزء تعليقات في الشريحة.

        commentsPart = slidePart1.GetPartsOfType<SlideCommentsPart>().First();

    }

    // إذا لم توجد قائمة تعليقات.

    if (commentsPart.CommentList == null)

    {

        // إضافة قائمة تعليقات جديدة.

        commentsPart.CommentList = new CommentList();

    }

    // الحصول على معرف التعليق الجديد.

    uint commentIdx = author.LastIndex == null ? 1 : author.LastIndex + 1;

    author.LastIndex = commentIdx;

    // إضافة تعليق جديد.

    Comment comment = commentsPart.CommentList.AppendChild<Comment>(

    new Comment()

    {

        AuthorId = authorId,

        Index = commentIdx,

        DateTime = DateTime.Now

    });

    // إضافة عقدة الموقع كطفل إلى عنصر التعليق.

    comment.Append(

    new Position() { X = 100, Y = 200 },

    new Text() { Text = text });

    // حفظ جزء مؤلفي التعليقات.

    authorsPart.CommentAuthorList.Save();

    // حفظ جزء التعليقات.

    commentsPart.CommentList.Save();

}

}

// الحصول على جزء الشريحة الأولى في مستند العرض التقديمي.

private static SlidePart GetFirstSlide(PresentationDocument presentationDocument)

{

// الحصول على معرف العلاقة للشريحة الأولى

PresentationPart part = presentationDocument.PresentationPart;

SlideId slideId = part.Presentation.SlideIdList.GetFirstChild<SlideId>();

string relId = slideId.RelationshipId;

// الحصول على جزء الشريحة بواسطة معرف العلاقة.

SlidePart slidePart = (SlidePart)part.GetPartById(relId);

return slidePart;

}


``` 
## **Aspose.Slides**
في **Aspose.Slides** لمنصة .NET، يتم تضمين مجموعة تعليقات شرائح PPT في كل فئة **Slide**. تُستخدم فئة **CommentCollection** للاحتفاظ بتعليقات الشريحة المحددة. تتضمن فئة **Comment** معلومات مثل المؤلف الذي أضاف التعليق، الأحرف الأولى له، وقت الإنشاء، موقع التعليق على الشريحة ونص التعليق. تُستخدم فئة **CommentAuthor** لإضافة مؤلفين لتعليقات الشرائح على مستوى العرض التقديمي. تحتفظ فئة **Presentation** بمجموعة المؤلفين للعرض التقديمي في فئة **CommentAuthors**.

في المثال التالي، أضفنا مقتطف الشيفرة لإضافة تعليقات الشرائح.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Add a comment to a slide.pptx";

using (Presentation pres = new Presentation())

{

    //إضافة شريحة فارغة

    pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

    //إضافة مؤلف

    ICommentAuthor author = pres.CommentAuthors.AddAuthor("Zeeshan", "MZ");

    //موضع التعليقات

    PointF point = new PointF();

    point.X = 1;

    point.Y = 1;

    //إضافة تعليق شريحة لمؤلف على الشريحة

    author.Comments.AddComment("Hello Zeeshan, this is slide comment", pres.Slides[0], point, DateTime.Now);

    pres.Save(FileName, Aspose.Slides.Export.SaveFormat.Pptx);

}

``` 
## **تنزيل عينة الكود**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Add%20a%20comment%20to%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Add%20a%20comment%20to%20a%20slide/)