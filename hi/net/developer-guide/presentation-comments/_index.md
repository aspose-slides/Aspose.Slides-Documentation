---
title: ".NET में प्रस्तुति टिप्पणियों का प्रबंधन"
linktitle: "प्रस्तुति टिप्पणियाँ"
type: docs
weight: 100
url: /hi/net/presentation-comments/
keywords:
- टिप्पणी
- आधुनिक टिप्पणी
- PowerPoint टिप्पणियाँ
- प्रस्तुति टिप्पणियाँ
- स्लाइड टिप्पणियाँ
- टिप्पणी जोड़ें
- टिप्पणी तक पहुँचें
- टिप्पणी संपादित करें
- टिप्पणी का उत्तर दें
- टिप्पणी हटाएँ
- टिप्पणी मिटाएँ
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ प्रस्तुति टिप्पणियों को महारत हासिल करें: PowerPoint फ़ाइलों में टिप्पणियों को तेज़ी और आसानी से जोड़ें, पढ़ें, संपादित करें और हटाएँ।"
---
## **अवलोकन**

यह आलेख Aspose.Slides में प्रस्तुति टिप्पणियों को प्रबंधित करने का तरीका बताता है। यह मुख्य टिप्पणी‑संबंधी प्रकारों को दिखाता है और स्लाइड में टिप्पणियाँ जोड़ना, मौजूदा टिप्पणियों तक पहुंचना, उत्तरों के साथ काम करना, आधुनिक टिप्पणियों का उपयोग करना, और प्रस्तुति से टिप्पणियों को हटाने का प्रदर्शन करता है।

उदाहरण सामान्य समीक्षा और सहयोग परिदृश्यों पर केंद्रित हैं, जैसे लेखकों को टिप्पणियाँ असाइन करना, टिप्पणी सामग्री और मेटाडेटा पढ़ना, उत्तर शृंखलाएँ बनाना, तथा सभी टिप्पणियों को साफ़ करना या चयनित टिप्पणियों को हटाना।

PowerPoint में, एक टिप्पणी स्लाइड पर नोट या एनोटेशन के रूप में दिखाई देती है। जब टिप्पणी पर क्लिक किया जाता है, तो उसकी सामग्री या संदेश प्रदर्शित होते हैं।

## **प्रस्तुति में टिप्पणियाँ क्यों जोड़ें?**

आप प्रस्तुति की समीक्षा करते समय अपने सहयोगियों को प्रतिक्रिया देने या संवाद करने के लिए टिप्पणियों का उपयोग करना चाह सकते हैं।

PowerPoint प्रस्तुतियों में टिप्पणियों के उपयोग की अनुमति देने के लिए, Aspose.Slides for .NET प्रदान करता है

* The [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) class, जो लेखकों (authors) का संग्रह (collection) रखता है (जैसे कि [CommentAuthorCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/icommentauthorcollection/properties/index) प्रॉपर्टी से)। लेखक स्लाइड में टिप्पणियाँ जोड़ते हैं। 
* The  [ICommentCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/icommentcollection) interface, जो व्यक्तिगत लेखकों के लिए टिप्पणियों का संग्रह रखता है। 
* The  [IComment](https://reference.aspose.com/slides/hi/net/aspose.slides/icomment) class, जो लेखकों और उनकी टिप्पणियों की जानकारी रखता है: किसने टिप्पणी जोड़ी, टिप्पणी कब जोड़ी गई, टिप्पणी की स्थिति आदि। 
* The [CommentAuthor](https://reference.aspose.com/slides/hi/net/aspose.slides/commentauthor) class, जो व्यक्तिगत लेखकों की जानकारी रखता है: लेखक का नाम, उसके आद्याक्षर, लेखक के नाम से जुड़ी टिप्पणियाँ आदि। 

## **स्लाइड टिप्पणियाँ जोड़ें**
यह C# कोड दिखाता है कि PowerPoint प्रस्तुति में एक स्लाइड पर टिप्पणी कैसे जोड़ी जाती है:

```c#
// Presentation क्लास का एक उदाहरण बनाता है
using (Presentation presentation = new Presentation())
{
    // एक खाली स्लाइड जोड़ता है
    presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

    // एक लेखक जोड़ता है
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Jawad", "MF");

    // टिप्पणियों के लिए स्थिति सेट करता है
    PointF point = new PointF();
    point.X = 0.2f;
    point.Y = 0.2f;

    // लेखक के लिए स्लाइड 1 पर स्लाइड टिप्पणी जोड़ता है
    author.Comments.AddComment("Hello Jawad, this is slide comment", presentation.Slides[0], point, DateTime.Now);

    // लेखक के लिए स्लाइड 2 पर स्लाइड टिप्पणी जोड़ता है
    author.Comments.AddComment("Hello Jawad, this is second slide comment", presentation.Slides[1], point, DateTime.Now);

    // ISlide 1 तक पहुंचता है
    ISlide slide = presentation.Slides[0];

    // जब तर्क के रूप में null पास किया जाता है, तो सभी लेखकों की टिप्पणियाँ चयनित स्लाइड पर लाई जाती हैं
    IComment[] Comments = slide.GetSlideComments(author);

    // स्लाइड 1 के लिए इंडेक्स 0 पर टिप्पणी तक पहुंचता है
    String str = Comments[0].Text;

    presentation.Save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.GetLength(0) > 0)
    {
        // इंडेक्स 0 पर लेखक की टिप्पणी संग्रह चुनता है
        ICommentCollection commentCollection = Comments[0].Author.Comments;
        String Comment = commentCollection[0].Text;
    }
}
```

## **स्लाइड टिप्पणियों तक पहुंचें**
यह C# कोड दिखाता है कि PowerPoint प्रस्तुति में एक स्लाइड की मौजूदा टिप्पणी तक कैसे पहुंचा जाए:

```c#
 // Presentation क्लास का एक उदाहरण बनाता है
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

## **टिप्पणियों के उत्तर**
एक पेरेंट टिप्पणी (Parent comment) टिप्पणियों या उत्तरों की पदानुक्रम में सबसे ऊपर या मूल टिप्पणी होती है। [ParentComment](https://reference.aspose.com/slides/hi/net/aspose.slides/icomment/properties/parentcomment) प्रॉपर्टी (जो [IComment](https://reference.aspose.com/slides/hi/net/aspose.slides/icomment) इंटरफ़ेस से आती है) का उपयोग करके, आप पेरेंट टिप्पणी को सेट या प्राप्त कर सकते हैं। 

यह C# कोड दिखाता है कि टिप्पणियाँ कैसे जोड़ें और उनके उत्तर कैसे प्राप्त करें:

```c#
using (Presentation pres = new Presentation())
{
    // टिप्पणी जोड़ता है
    ICommentAuthor author1 = pres.CommentAuthors.AddAuthor("Author_1", "A.A.");
    IComment comment1 = author1.Comments.AddComment("comment1", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    // comment1 के लिए उत्तर जोड़ता है
    ICommentAuthor author2 = pres.CommentAuthors.AddAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.Comments.AddComment("reply 1 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply1.ParentComment = comment1;

    // comment1 के लिए एक और उत्तर जोड़ता है
    IComment reply2 = author2.Comments.AddComment("reply 2 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply2.ParentComment = comment1;

    // मौजूदा उत्तर पर एक उत्तर जोड़ता है
    IComment subReply = author1.Comments.AddComment("subreply 3 for reply 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    subReply.ParentComment = reply2;

    IComment comment2 = author2.Comments.AddComment("comment 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    IComment comment3 = author2.Comments.AddComment("comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    IComment reply3 = author1.Comments.AddComment("reply 4 for comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply3.ParentComment = comment3;

    // कंसोल पर टिप्पणी पदानुक्रम दिखाता है
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

    // comment1 और उसके सभी उत्तरों को हटाता है
    comment1.Remove();

    pres.Save("remove_comment.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" title="Attention" %}} 

* जब [Remove](https://reference.aspose.com/slides/hi/net/aspose.slides/icomment/methods/remove) मेथड (जो [IComment](https://reference.aspose.com/slides/hi/net/aspose.slides/icomment) इंटरफ़ेस से है) का उपयोग करके कोई टिप्पणी हटाई जाती है, तो उस टिप्पणी के उत्तर भी हटाए जाते हैं। 
* यदि [ParentComment](https://reference.aspose.com/slides/hi/net/aspose.slides/icomment/properties/parentcomment) सेटिंग एक सर्कुलर रेफरेंस का कारण बनती है, तो [PptxEditException](https://reference.aspose.com/slides/hi/net/aspose.slides/pptxeditexception) फेंका जाएगा।

{{% /alert %}}

## **आधुनिक टिप्पणियाँ जोड़ें**

2021 में, Microsoft ने PowerPoint में *आधुनिक टिप्पणियाँ* प्रस्तुत कीं। आधुनिक टिप्पणी सुविधा PowerPoint में सहयोग को काफी सुधारती है। आधुनिक टिप्पणियों के माध्यम से, PowerPoint उपयोगकर्ता टिप्पणियों को हल (resolve) कर सकते हैं, टिप्पणियों को वस्तुओं और पाठों से जोड़ सकते हैं, और इंटरैक्शन को पहले से बहुत आसान बना सकते हैं। 

हमने [Aspose Slides for .NET 21.11](https://docs.aspose.com/slides/hi/net/aspose-slides-for-net-21-11-release-notes/) में [ModernComment](https://reference.aspose.com/slides/hi/net/aspose.slides/moderncomment) क्लास जोड़कर आधुनिक टिप्पणियों के समर्थन को लागू किया। [AddModernComment](https://reference.aspose.com/slides/hi/net/aspose.slides/commentcollection/methods/addmoderncomment) और [InsertModernComment](https://reference.aspose.com/slides/hi/net/aspose.slides/commentcollection/methods/insertmoderncomment) मेथड्स को [CommentCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/commentcollection) क्लास में जोड़ा गया। 

यह C# कोड दिखाता है कि PowerPoint प्रस्तुति में एक स्लाइड पर आधुनिक टिप्पणी कैसे जोड़ी जाए: 

```c#
using (Presentation pres = new Presentation())
{
     ICommentAuthor newAuthor = pres.CommentAuthors.AddAuthor("Some Author", "SA");
     IModernComment modernComment = newAuthor.Comments.AddModernComment("This is a modern comment", pres.Slides[0], null, new PointF(100, 100), DateTime.Now);
 
     pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **टिप्पणियाँ हटाएँ**

### **सभी टिप्पणियों और लेखकों को हटाएँ**
यह C# कोड दिखाता है कि प्रस्तुति में सभी टिप्पणियों और लेखकों को कैसे हटाया जाए:

```c#
using (var presentation = new Presentation("example.pptx"))
{
    // प्रस्तुति से सभी टिप्पणियों को हटाता है
    foreach (var author in presentation.CommentAuthors)
    {
        author.Comments.Clear();
    }

    // सभी लेखकों को हटाता है
    presentation.CommentAuthors.Clear();

    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```

### **विशिष्ट टिप्पणियों को हटाएँ**
यह C# कोड दिखाता है कि स्लाइड पर विशिष्ट टिप्पणियों को कैसे हटाया जाए:

```c#
using (var presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    
    // टिप्पणियाँ जोड़ें...
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Author", "A");
    author.Comments.AddComment("comment 1", slide, new PointF(0.2f, 0.2f), DateTime.Now);
    author.Comments.AddComment("comment 2", slide, new PointF(0.3f, 0.2f), DateTime.Now);
    
    // "comment 1" पाठ शामिल करने वाली सभी टिप्पणियों को हटाएँ
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

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides आधुनिक टिप्पणियों के लिए 'resolved' जैसी स्थिति का समर्थन करता है?**

हाँ। [Modern comments](https://reference.aspose.com/slides/hi/net/aspose.slides/moderncomment/) एक [Status](https://reference.aspose.com/slides/hi/net/aspose.slides/moderncomment/status/) प्रॉपर्टी प्रदान करती हैं; आप एक [comment का state](https://reference.aspose.com/slides/hi/net/aspose.slides/moderncommentstatus/) पढ़ और सेट कर सकते हैं (उदाहरण के लिए, इसे resolved के रूप में चिह्नित करें), और यह स्थिति फ़ाइल में सहेजी जाती है और PowerPoint द्वारा पहचानी जाती है।

**क्या थ्रेडेड चर्चाएँ (उत्तर शृंखलाएँ) समर्थित हैं, और क्या कोई नेस्टिंग सीमा है?**

हाँ। प्रत्येक टिप्पणी अपने [parent comment](https://reference.aspose.com/slides/hi/net/aspose.slides/comment/parentcomment/) को संदर्भित कर सकती है, जिससे मनमानी उत्तर शृंखलाएँ बनती हैं। API कोई विशिष्ट नेस्टिंग गहराई सीमा घोषित नहीं करती।

**स्लाइड पर टिप्पणी मार्कर की स्थिति किस कोऑर्डिनेट सिस्टम में परिभाषित होती है?**

स्थिति स्लाइड के कोऑर्डिनेट सिस्टम में एक फ्लोटिंग‑पॉइंट बिंदु के रूप में सहेजी जाती है। यह आपको टिप्पणी मार्कर को ठीक वहीँ रखने की सुविधा देती है जहाँ आपको आवश्यकता है।