---
title: एक लेखक द्वारा सभी टिप्पणियों को हटाएँ
type: docs
weight: 70
url: /hi/net/delete-all-the-comments-by-an-author/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Delete all the comments by an author.pptx";

string author = "Zeeshan Shafqat";

DeleteCommentsByAuthorInPresentation(FileName, author);

// स्लाइड्स में एक निश्चित लेखक द्वारा सभी टिप्पणियों को हटाएँ।

public static void DeleteCommentsByAuthorInPresentation(string fileName, string author)

{

if (String.IsNullOrEmpty(fileName) || String.IsNullOrEmpty(author))

    throw new ArgumentNullException("File name or author name is NULL!");

using (PresentationDocument doc = PresentationDocument.Open(fileName, true))

{

    // निर्दिष्ट टिप्पणी लेखक प्राप्त करें।

    IEnumerable<CommentAuthor> commentAuthors =

        doc.PresentationPart.CommentAuthorsPart.CommentAuthorList.Elements<CommentAuthor>()

        .Where(e => e.Name.Value.Equals(author));

    // सभी मिलते-जुलते लेखकों पर क्रमिक रूप से जाएँ।

    foreach (CommentAuthor commentAuthor in commentAuthors)

    {

        UInt32Value authorId = commentAuthor.Id;

        // सभी स्लाइड्स पर क्रमिक रूप से जाएँ और स्लाइड भागों को प्राप्त करें।

        foreach (SlidePart slide in doc.PresentationPart.SlideParts)

        {

            SlideCommentsPart slideCommentsPart = slide.SlideCommentsPart;

            // टिप्पणियों की सूची प्राप्त करें।

            if (slideCommentsPart != null && slide.SlideCommentsPart.CommentList != null)

            {

                IEnumerable<Comment> commentList =

                    slideCommentsPart.CommentList.Elements<Comment>().Where(e => e.AuthorId == authorId.Value);

                List<Comment> comments = new List<Comment>();

                comments = commentList.ToList<Comment>();

                foreach (Comment comm in comments)

                {

                    // निर्दिष्ट लेखक द्वारा सभी टिप्पणी को हटाएँ।

                    slideCommentsPart.CommentList.RemoveChild<Comment>(comm);

                }

                // यदि commentPart में कोई मौजूदा टिप्पणी नहीं है।

                if (slideCommentsPart.CommentList.ChildElements.Count == 0)

                    // इस भाग को हटाएँ।

                    slide.DeletePart(slideCommentsPart);

            }

        }

        // टिप्पणी लेखकों भाग से टिप्पणी लेखक को हटाएँ।

        doc.PresentationPart.CommentAuthorsPart.CommentAuthorList.RemoveChild<CommentAuthor>(commentAuthor);

    }

}

}

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Delete all the comments by an author.pptx";

string author = "MZ";

DeleteCommentsByAuthorInPresentation(FileName, author);

// एक निश्चित लेखक द्वारा स्लाइड्स में सभी टिप्पणियों को हटाएँ।

public static void DeleteCommentsByAuthorInPresentation(string fileName, string author)

{

    if (String.IsNullOrEmpty(fileName) || String.IsNullOrEmpty(author))

        throw new ArgumentNullException("File name or author name is NULL!");

    // एक PresentationEx ऑब्जेक्ट बनायें जो PPTX फ़ाइल का प्रतिनिधित्व करता है।

    using (Presentation pres = new Presentation(fileName))

    {

      ICommentAuthor[] authors=  pres.CommentAuthors.FindByName(author);

      ICommentAuthor thisAuthor = authors[0];

      for (int i = thisAuthor.Comments.Count - 1; i >= 0;i-- )

      {

          thisAuthor.Comments.RemoveAt(i);

      }

      pres.Save(fileName, Aspose.Slides.Export.SaveFormat.Pptx);  

    }

}    

``` 
## **नमूना कोड डाउनलोड करें**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Delete%20all%20the%20comments%20by%20an%20author%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Delete%20all%20the%20comments%20by%20an%20author/)