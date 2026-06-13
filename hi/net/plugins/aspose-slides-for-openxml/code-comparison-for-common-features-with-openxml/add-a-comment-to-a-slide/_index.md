---
title: स्लाइड पर टिप्पणी जोड़ें
type: docs
weight: 10
url: /hi/net/add-a-comment-to-a-slide/
---
## **OpenXML प्रस्तुति**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Add a comment to a slide.pptx"; 

AddCommentToPresentation(FileName,

"Zeeshan", "MZ",

"This is my programmatically added comment.");

// प्रस्तुति दस्तावेज़ की पहली स्लाइड में टिप्पणी जोड़ता है।

// प्रस्तुति दस्तावेज़ में कम से कम एक स्लाइड होना चाहिए।

private static void AddCommentToPresentation(string file, string initials, string name, string text)

{

using (PresentationDocument doc = PresentationDocument.Open(file, true))

{

    // एक CommentAuthorsPart ऑब्जेक्ट घोषित करें।

    CommentAuthorsPart authorsPart;

    // जाँचें कि टिप्पणी लेखकों का भाग मौज़ूद है।

    if (doc.PresentationPart.CommentAuthorsPart == null)

    {

        // यदि नहीं, तो नया भाग जोड़ें।

        authorsPart = doc.PresentationPart.AddNewPart<CommentAuthorsPart>();

    }

    else

    {

        authorsPart = doc.PresentationPart.CommentAuthorsPart;

    }

    // जाँचें कि टिप्पणी लेखकों भाग में टिप्पणी लेखक सूची है।

    if (authorsPart.CommentAuthorList == null)

    {

        // यदि नहीं, तो नया भाग जोड़ें।

        authorsPart.CommentAuthorList = new CommentAuthorList();

    }

    // एक नया लेखक ID घोषित करें।

    uint authorId = 0;

    CommentAuthor author = null;

    // यदि टिप्पणी लेखकों सूची में मौज़ूद चाइल्ड तत्व हैं...

    if (authorsPart.CommentAuthorList.HasChildren)

    {

        // जाँचें कि पास किया गया लेखक सूची में है।

        var authors = authorsPart.CommentAuthorList.Elements<CommentAuthor>().Where(a => a.Name == name && a.Initials == initials);

        // यदि ऐसा है...

        if (authors.Any())

        {

            // नए टिप्पणी लेखक को मौज़ूद लेखक ID सौंपें।

            author = authors.First();

            authorId = author.Id;

        }

        // यदि नहीं...

        if (author == null)

        {

            // पास किए गए लेखक को नया ID दें

            authorId = authorsPart.CommentAuthorList.Elements<CommentAuthor>().Select(a => a.Id.Value).Max();

        }

    }

    // यदि टिप्पणी लेखकों सूची में कोई मौज़ूद चाइल्ड तत्व नहीं है।

    if (author == null)

    {

        authorId++;

        // टिप्पणी लेखक सूची में नया चाइल्ड तत्व (टिप्पणी लेखक) जोड़ें।

        author = authorsPart.CommentAuthorList.AppendChild<CommentAuthor>

        (new CommentAuthor()

        {

            Id = authorId,

            Name = name,

            Initials = initials,

            ColorIndex = 0

        });

    }

    // GetFirstSlide मेथड का उपयोग करके पहली स्लाइड प्राप्त करें।

    SlidePart slidePart1 = GetFirstSlide(doc);

    // एक comments भाग घोषित करें।

    SlideCommentsPart commentsPart;

    // जाँचें कि पहली स्लाइड भाग में comments भाग है।

    if (slidePart1.GetPartsOfType<SlideCommentsPart>().Count() == 0)

    {

        // यदि नहीं, तो नया comments भाग जोड़ें।

        commentsPart = slidePart1.AddNewPart<SlideCommentsPart>();

    }

    else

    {

        // अन्यथा, स्लाइड भाग में पहला comments भाग उपयोग करें।

        commentsPart = slidePart1.GetPartsOfType<SlideCommentsPart>().First();

    }

    // यदि टिप्पणी सूची मौजूद नहीं है।

    if (commentsPart.CommentList == null)

    {

        // नई टिप्पणी सूची जोड़ें।

        commentsPart.CommentList = new CommentList();

    }

    // नई टिप्पणी ID प्राप्त करें।

    uint commentIdx = author.LastIndex == null ? 1 : author.LastIndex + 1;

    author.LastIndex = commentIdx;

    // नई टिप्पणी जोड़ें।

    Comment comment = commentsPart.CommentList.AppendChild<Comment>(

    new Comment()

    {

        AuthorId = authorId,

        Index = commentIdx,

        DateTime = DateTime.Now

    });

    // टिप्पणी तत्व में position चाइल्ड नोड जोड़ें।

    comment.Append(

    new Position() { X = 100, Y = 200 },

    new Text() { Text = text });

    // टिप्पणी लेखकों भाग को सहेजें।

    authorsPart.CommentAuthorList.Save();

    // comments भाग को सहेजें।

    commentsPart.CommentList.Save();

}

}

// प्रस्तुति दस्तावेज़ में पहली स्लाइड का slide भाग प्राप्त करें।

private static SlidePart GetFirstSlide(PresentationDocument presentationDocument)

{

// पहली स्लाइड का रिलेशनशिप ID प्राप्त करें

PresentationPart part = presentationDocument.PresentationPart;

SlideId slideId = part.Presentation.SlideIdList.GetFirstChild<SlideId>();

string relId = slideId.RelationshipId;

// रिलेशनशिप ID द्वारा slide भाग प्राप्त करें।

SlidePart slidePart = (SlidePart)part.GetPartById(relId);

return slidePart;

}


``` 
## **Aspose.Slides**
.NET के लिए **Aspose.Slides** में, PPT स्लाइड टिप्पणी संग्रह प्रत्येक **Slide** क्लास में शामिल है। **CommentCollection** क्लास का उपयोग विशिष्ट स्लाइड टिप्पणियों को रखने के लिए किया जाता है। **Comment** क्लास में टिप्पणी जोड़ने वाले लेखक, उनके आद्याक्षर, निर्माण समय, स्लाइड पर टिप्पणी की स्थिति और टिप्पणी पाठ जैसी जानकारी शामिल होती है। **CommentAuthor** क्लास का उपयोग प्रस्तुति स्तर पर स्लाइड टिप्पणियों के लेखकों को जोड़ने के लिए किया जाता है। **Presentation** क्लास **CommentAuthors** क्लास में प्रस्तुति के लेखकों का संग्रह रखती है।

निम्न उदाहरण में, हमने स्लाइड टिप्पणियों को जोड़ने के लिए कोड स्निपेट जोड़ा है।

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Add a comment to a slide.pptx";

using (Presentation pres = new Presentation())

{

    //खाली स्लाइड जोड़ रहा है

    pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

    //लेखक जोड़ रहा है

    ICommentAuthor author = pres.CommentAuthors.AddAuthor("Zeeshan", "MZ");

    //टिप्पणियों की स्थिति

    PointF point = new PointF();

    point.X = 1;

    point.Y = 1;

    //स्लाइड पर लेखक के लिए स्लाइड टिप्पणी जोड़ना

    author.Comments.AddComment("Hello Zeeshan, this is slide comment", pres.Slides[0], point, DateTime.Now);

    pres.Save(FileName, Aspose.Slides.Export.SaveFormat.Pptx);

}

``` 
## **डाउनलोड नमूना कोड**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Add%20a%20comment%20to%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Add%20a%20comment%20to%20a%20slide/)