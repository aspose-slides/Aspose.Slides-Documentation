---
title: اضافه کردن یک نظر به اسلاید
type: docs
weight: 10
url: /fa/net/add-a-comment-to-a-slide/
---
## **ارائه OpenXML**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Add a comment to a slide.pptx"; 

AddCommentToPresentation(FileName,

"Zeeshan", "MZ",

"This is my programmatically added comment.");

// یک نظر را به اولین اسلاید سند ارائه اضافه می‌کند.

// سند ارائه باید حداقل یک اسلاید داشته باشد.

private static void AddCommentToPresentation(string file, string initials, string name, string text)

{

using (PresentationDocument doc = PresentationDocument.Open(file, true))

{

    // یک شیء CommentAuthorsPart را اعلام کنید.

    CommentAuthorsPart authorsPart;

    // بررسی کنید که بخشی از نویسندگان نظرات موجود است.

    if (doc.PresentationPart.CommentAuthorsPart == null)

    {

        // اگر وجود ندارد، یک بخش جدید اضافه کنید.

        authorsPart = doc.PresentationPart.AddNewPart<CommentAuthorsPart>();

    }

    else

    {

        authorsPart = doc.PresentationPart.CommentAuthorsPart;

    }

    // بررسی کنید که لیست نویسندگان نظرات در بخش نویسندگان نظرات وجود دارد.

    if (authorsPart.CommentAuthorList == null)

    {

        // اگر وجود ندارد، یک مورد جدید اضافه کنید.

        authorsPart.CommentAuthorList = new CommentAuthorList();

    }

    // یک شناسه نویسنده جدید اعلام کنید.

    uint authorId = 0;

    CommentAuthor author = null;

    // اگر عناصر فرزند موجودی در لیست نویسندگان نظرات وجود دارد...

    if (authorsPart.CommentAuthorList.HasChildren)

    {

        // بررسی کنید که نویسندهٔ وارد شده در لیست وجود دارد.

        var authors = authorsPart.CommentAuthorList.Elements<CommentAuthor>().Where(a => a.Name == name && a.Initials == initials);

        // اگر چنین است...

        if (authors.Any())

        {

            // شناسه نویسندهٔ موجود را به نویسندهٔ نظر جدید اختصاص دهید.

            author = authors.First();

            authorId = author.Id;

        }

        // اگر وجود ندارد...

        if (author == null)

        {

            // به نویسندهٔ وارد شده یک شناسه جدید اختصاص دهید

            authorId = authorsPart.CommentAuthorList.Elements<CommentAuthor>().Select(a => a.Id.Value).Max();

        }

    }

    // اگر هیچ عنصر فرزندی در لیست نویسندگان نظرات وجود نداشته باشد.

    if (author == null)

    {

        authorId++;

        // یک عنصر فرزند جدید (نویسندهٔ نظر) به لیست نویسندگان نظرات اضافه کنید.

        author = authorsPart.CommentAuthorList.AppendChild<CommentAuthor>

        (new CommentAuthor()

        {

            Id = authorId,

            Name = name,

            Initials = initials,

            ColorIndex = 0

        });

    }

    // اولین اسلاید را با استفاده از متد GetFirstSlide دریافت کنید.

    SlidePart slidePart1 = GetFirstSlide(doc);

    // یک بخش نظرات اعلام کنید.

    SlideCommentsPart commentsPart;

    // بررسی کنید که بخش نظرات در اولین بخش اسلاید وجود دارد.

    if (slidePart1.GetPartsOfType<SlideCommentsPart>().Count() == 0)

    {

        // اگر وجود ندارد، یک بخش نظرات جدید اضافه کنید.

        commentsPart = slidePart1.AddNewPart<SlideCommentsPart>();

    }

    else

    {

        // در غیر این صورت، اولین بخش نظرات در بخش اسلاید را استفاده کنید.

        commentsPart = slidePart1.GetPartsOfType<SlideCommentsPart>().First();

    }

    // اگر لیست نظرات وجود ندارد.

    if (commentsPart.CommentList == null)

    {

        // یک لیست نظرات جدید اضافه کنید.

        commentsPart.CommentList = new CommentList();

    }

    // یک نظر جدید اضافه کنید.

    uint commentIdx = author.LastIndex == null ? 1 : author.LastIndex + 1;

    author.LastIndex = commentIdx;

    Comment comment = commentsPart.CommentList.AppendChild<Comment>(

    new Comment()

    {

        AuthorId = authorId,

        Index = commentIdx,

        DateTime = DateTime.Now

    });

    // گره فرزند موقعیت را به عنصر نظر اضافه کنید.

    comment.Append(

    new Position() { X = 100, Y = 200 },

    new Text() { Text = text });

    // بخش نویسندگان نظرات را ذخیره کنید.

    authorsPart.CommentAuthorList.Save();

    // بخش نظرات را ذخیره کنید.

    commentsPart.CommentList.Save();

}

}

// بخش اسلاید اولین اسلاید در سند ارائه را دریافت کنید.

private static SlidePart GetFirstSlide(PresentationDocument presentationDocument)

{

// شناسهٔ رابطه اولین اسلاید را دریافت کنید

PresentationPart part = presentationDocument.PresentationPart;

SlideId slideId = part.Presentation.SlideIdList.GetFirstChild<SlideId>();

string relId = slideId.RelationshipId;

// بخش اسلاید را با شناسهٔ رابطه دریافت کنید.

SlidePart slidePart = (SlidePart)part.GetPartById(relId);

return slidePart;

}


``` 
## **Aspose.Slides**
در **Aspose.Slides** برای .NET، مجموعهٔ نظرات اسلاید PPT در هر کلاس **Slide** گنجانده شده است. از کلاس **CommentCollection** برای نگهداری نظرات خاص اسلاید استفاده می‌شود. کلاس **Comment** شامل اطلاعاتی مانند نویسنده‌ای که نظر اسلاید را اضافه کرده است، حروف اول وی، زمان ایجاد، موقعیت نظر در اسلاید و متن نظر می‌باشد. کلاس **CommentAuthor** برای افزودن نویسندگان نظرات اسلاید در سطح ارائه استفاده می‌شود. کلاس **Presentation** مجموعهٔ نویسندگان ارائه را در کلاس **CommentAuthors** نگه می‌دارد.

در مثال زیر، قطعه کد برای افزودن نظرات اسلاید اضافه شده است.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Add a comment to a slide.pptx";

using (Presentation pres = new Presentation())

{

    // افزودن اسلاید خالی

    pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

    // افزودن نویسنده

    ICommentAuthor author = pres.CommentAuthors.AddAuthor("Zeeshan", "MZ");

    // موقعیت نظرات

    PointF point = new PointF();

    point.X = 1;

    point.Y = 1;

    // افزودن نظر اسلاید برای یک نویسنده بر روی اسلاید

    author.Comments.AddComment("Hello Zeeshan, this is slide comment", pres.Slides[0], point, DateTime.Now);

    pres.Save(FileName, Aspose.Slides.Export.SaveFormat.Pptx);

}

``` 
## **بارگیری کد نمونه**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Add%20a%20comment%20to%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Add%20a%20comment%20to%20a%20slide/)