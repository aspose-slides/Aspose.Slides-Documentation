---
title: إضافة تعليق إلى شريحة
type: docs
weight: 10
url: /ar/net/add-a-comment-to-a-slide/
---

## **OpenXML العرض التقديمي:**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Add a comment to a slide.pptx"; 

AddCommentToPresentation(FileName,

"Zeeshan", "MZ",

"This is my programmatically added comment.");

// يضيف تعليقًا إلى الشريحة الأولى من مستند العرض التقديمي.

// يجب أن يحتوي مستند العرض التقديمي على شريحة واحدة على الأقل.

private static void AddCommentToPresentation(string file, string initials, string name, string text)

{

using (PresentationDocument doc = PresentationDocument.Open(file, true))

{

    // إعلان كائن CommentAuthorsPart.

    CommentAuthorsPart authorsPart;

    // التحقق من وجود جزء مؤلفي التعليقات موجود.

    if (doc.PresentationPart.CommentAuthorsPart == null)

    {

        // إذا لم يكن موجودًا، أضف واحدًا جديدًا.

        authorsPart = doc.PresentationPart.AddNewPart<CommentAuthorsPart>();

    }

    else

    {

        authorsPart = doc.PresentationPart.CommentAuthorsPart;

    }

    // التحقق من وجود قائمة مؤلفي التعليقات في جزء مؤلفي التعليقات.

    if (authorsPart.CommentAuthorList == null)

    {

        // إذا لم يكن موجودًا، أضف واحدة جديدة.

        authorsPart.CommentAuthorList = new CommentAuthorList();

    }

    // إعلان معرف مؤلف جديد.

    uint authorId = 0;

    CommentAuthor author = null;

    // إذا كانت هناك عناصر طفيلية موجودة في قائمة مؤلفي التعليقات...

    if (authorsPart.CommentAuthorList.HasChildren)

    {

        // تحقق من أن المؤلف المرسل في القائمة.

        var authors = authorsPart.CommentAuthorList.Elements<CommentAuthor>().Where(a => a.Name == name && a.Initials == initials);

        // إذا كان الأمر كذلك...

        if (authors.Any())

        {

            // تخصيص معرف المؤلف الجديد لمؤلف موجود.

            author = authors.First();

            authorId = author.Id;

        }

        // إذا لم يكن الأمر كذلك...

        if (author == null)

        {

            // تخصيص معرف جديد للمؤلف المرسل في القائمة.

            authorId = authorsPart.CommentAuthorList.Elements<CommentAuthor>().Select(a => a.Id.Value).Max();

        }

    }

    // إذا لم تكن هناك عناصر طفيلية موجودة في قائمة مؤلفي التعليقات.

    if (author == null)

    {

        authorId++;

        // أضف عنصر طفلي جديد (مؤلف تعليق) إلى قائمة مؤلفي التعليقات.

        author = authorsPart.CommentAuthorList.AppendChild<CommentAuthor>

        (new CommentAuthor()

        {

            Id = authorId,

            Name = name,

            Initials = initials,

            ColorIndex = 0

        });

    }

    // احصل على الشريحة الأولى، باستخدام طريقة GetFirstSlide.

    SlidePart slidePart1 = GetFirstSlide(doc);

    // إعلان جزء التعليقات.

    SlideCommentsPart commentsPart;

    // تحقق من وجود جزء التعليقات في جزء الشريحة الأولى.

    if (slidePart1.GetPartsOfType<SlideCommentsPart>().Count() == 0)

    {

        // إذا لم يكن موجودًا، أضف جزء تعليقات جديد.

        commentsPart = slidePart1.AddNewPart<SlideCommentsPart>();

    }

    else

    {

        // خلاف ذلك، استخدم أول جزء تعليقات في جزء الشريحة.

        commentsPart = slidePart1.GetPartsOfType<SlideCommentsPart>().First();

    }

    // إذا كانت قائمة التعليقات غير موجودة.

    if (commentsPart.CommentList == null)

    {

        // أضف قائمة تعليقات جديدة.

        commentsPart.CommentList = new CommentList();

    }

    // احصل على معرف التعليق الجديد.

    uint commentIdx = author.LastIndex == null ? 1 : author.LastIndex + 1;

    author.LastIndex = commentIdx;

    // أضف تعليقًا جديدًا.

    Comment comment = commentsPart.CommentList.AppendChild<Comment>(

    new Comment()

    {

        AuthorId = authorId,

        Index = commentIdx,

        DateTime = DateTime.Now

    });

    // أضف عنصر موضع الشجرة إلى عنصر التعليق.

    comment.Append(

    new Position() { X = 100, Y = 200 },

    new Text() { Text = text });

    // احفظ جزء مؤلفي التعليقات.

    authorsPart.CommentAuthorList.Save();

    // احفظ جزء التعليقات.

    commentsPart.CommentList.Save();

}

}

// احصل على جزء الشريحة الأولى في مستند العرض التقديمي.

private static SlidePart GetFirstSlide(PresentationDocument presentationDocument)

{

// احصل على معرف العلاقة للشريحة الأولى

PresentationPart part = presentationDocument.PresentationPart;

SlideId slideId = part.Presentation.SlideIdList.GetFirstChild<SlideId>();

string relId = slideId.RelationshipId;

// احصل على جزء الشريحة بواسطة معرف العلاقة.

SlidePart slidePart = (SlidePart)part.GetPartById(relId);

return slidePart;

}


``` 
## **Aspose.Slides**
في **Aspose.Slides** لـ .NET، يتم تضمين مجموعة تعليقات شريحة PPT في كل فصل **Slide**. تُستخدم فئة **CommentCollection** للاحتفاظ بتعليقات الشريحة المعينة. تتضمن فئة **Comment** معلومات مثل المؤلف الذي أضاف تعليق الشريحة، وبياناته الأولية، ووقت الإنشاء، وموضع تعليق الشريحة على الشريحة ونص التعليق. تُستخدم فئة **CommentAuthor** لإضافة المؤلفين لتعليقات الشرائح على مستوى العرض التقديمي. تحتوي فئة **Presentation** على مجموعة من المؤلفين للعرض التقديمي في فئة **CommentAuthors**.

في المثال التالي، أضفنا مقتطف الشفرة لإضافة تعليقات الشرائح.

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
## **تحميل الشيفرة المصدرية**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://master.dl.sourceforge.net/project/asposeopenxml/Aspose.Slides%20Vs%20OpenXML/Add%20a%20comment%20to%20a%20slide%20%28Aspose.Slides%29.zip?viasf=1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Add%20a%20comment%20to%20a%20slide%20\(Aspose.Slides\).zip)