---
title: Προσθήκη σχολίου σε διαφάνεια
type: docs
weight: 10
url: /el/net/add-a-comment-to-a-slide/
---
## **OpenXML Presentation**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Add a comment to a slide.pptx"; 

AddCommentToPresentation(FileName,

"Zeeshan", "MZ",

"This is my programmatically added comment.");

// Προσθέτει ένα σχόλιο στην πρώτη διαφάνεια του εγγράφου παρουσίασης.
// Το έγγραφο παρουσίασης πρέπει να περιέχει τουλάχιστον μία διαφάνεια.

private static void AddCommentToPresentation(string file, string initials, string name, string text)

{

using (PresentationDocument doc = PresentationDocument.Open(file, true))

{

    // Δηλώνει ένα αντικείμενο CommentAuthorsPart.

    CommentAuthorsPart authorsPart;

    // Επαληθεύει ότι υπάρχει υπάρχον τμήμα συγγραφέων σχολίων.

    if (doc.PresentationPart.CommentAuthorsPart == null)

    {

        // Αν όχι, προσθέτει ένα νέο.

        authorsPart = doc.PresentationPart.AddNewPart<CommentAuthorsPart>();

    }

    else

    {

        authorsPart = doc.PresentationPart.CommentAuthorsPart;

    }

    // Επαληθεύει ότι υπάρχει λίστα συγγραφέων σχολίων στο τμήμα συγγραφέων σχολίων.

    if (authorsPart.CommentAuthorList == null)

    {

        // Αν όχι, προσθέτει ένα νέο.

        authorsPart.CommentAuthorList = new CommentAuthorList();

    }

    // Δηλώνει νέο αναγνωριστικό συγγραφέα.

    uint authorId = 0;

    CommentAuthor author = null;

    // Αν υπάρχουν υπάρχοντα στοιχεία-παιδιά στη λίστα συγγραφέων σχολίων...

    if (authorsPart.CommentAuthorList.HasChildren)

    {

        // Επαληθεύει ότι ο παρεχόμενος συγγραφέας βρίσκεται στη λίστα.

        var authors = authorsPart.CommentAuthorList.Elements<CommentAuthor>().Where(a => a.Name == name && a.Initials == initials);

        // Αν ναι...

        if (authors.Any())

        {

            // Αντιστοιχίζει στο νέο συγγραφέα σχολίου το υπάρχον αναγνωριστικό συγγραφέα.

            author = authors.First();

            authorId = author.Id;

        }

        // Αν όχι...

        if (author == null)

        {

            // Αναθέτει στον παρεχόμενο συγγραφέα νέο αναγνωριστικό

            authorId = authorsPart.CommentAuthorList.Elements<CommentAuthor>().Select(a => a.Id.Value).Max();

        }

    }

    // Αν δεν υπάρχουν υπάρχοντα στοιχεία-παιδιά στη λίστα συγγραφέων σχολίων.

    if (author == null)

    {

        authorId++;

        // Προσθέτει ένα νέο στοιχείο-παιδί (συγγραφέα σχολίου) στη λίστα συγγραφέων σχολίων.

        author = authorsPart.CommentAuthorList.AppendChild<CommentAuthor>

        (new CommentAuthor()

        {

            Id = authorId,

            Name = name,

            Initials = initials,

            ColorIndex = 0

        });

    }

    // Λαμβάνει την πρώτη διαφάνεια, χρησιμοποιώντας τη μέθοδο GetFirstSlide.

    SlidePart slidePart1 = GetFirstSlide(doc);

    // Δηλώνει τμήμα σχολίων.

    SlideCommentsPart commentsPart;

    // Επαληθεύει ότι υπάρχει τμήμα σχολίων στο πρώτο τμήμα διαφάνειας.

    if (slidePart1.GetPartsOfType<SlideCommentsPart>().Count() == 0)

    {

        // Αν όχι, προσθέτει ένα νέο τμήμα σχολίων.

        commentsPart = slidePart1.AddNewPart<SlideCommentsPart>();

    }

    else

    {

        // Διαφορετικά, χρησιμοποιεί το πρώτο τμήμα σχολίων στο τμήμα διαφάνειας.

        commentsPart = slidePart1.GetPartsOfType<SlideCommentsPart>().First();

    }

    // Αν η λίστα σχολίων δεν υπάρχει.

    if (commentsPart.CommentList == null)

    {

        // Προσθέτει μια νέα λίστα σχολίων.

        commentsPart.CommentList = new CommentList();

    }

    // Get the new comment ID.

    uint commentIdx = author.LastIndex == null ? 1 : author.LastIndex + 1;

    author.LastIndex = commentIdx;

    // Add a new comment.

    Comment comment = commentsPart.CommentList.AppendChild<Comment>(

    new Comment()

    {

        AuthorId = authorId,

        Index = commentIdx,

        DateTime = DateTime.Now

    });

    // Προσθέτει το παιδί θέση στο στοιχείο σχολίου.

    comment.Append(

    new Position() { X = 100, Y = 200 },

    new Text() { Text = text });

    // Αποθηκεύει το τμήμα συγγραφέων σχολίων.

    authorsPart.CommentAuthorList.Save();

    // Αποθηκεύει το τμήμα σχολίων.

    commentsPart.CommentList.Save();

}

}

// Λαμβάνει το τμήμα διαφάνειας της πρώτης διαφάνειας στο έγγραφο παρουσίασης.

private static SlidePart GetFirstSlide(PresentationDocument presentationDocument)

{

// Λαμβάνει το αναγνωριστικό σχέσης της πρώτης διαφάνειας

PresentationPart part = presentationDocument.PresentationPart;

SlideId slideId = part.Presentation.SlideIdList.GetFirstChild<SlideId>();

string relId = slideId.RelationshipId;

// Λαμβάνει το τμήμα διαφάνειας με βάση το αναγνωριστικό σχέσης.

SlidePart slidePart = (SlidePart)part.GetPartById(relId);

return slidePart;

}


``` 
## **Aspose.Slides**
Στο **Aspose.Slides** για .NET, η συλλογή σχολίων διαφάνειας PPT περιλαμβάνεται σε κάθε κλάση **Slide**. Η κλάση **CommentCollection** χρησιμοποιείται για τη διατήρηση των συγκεκριμένων σχολίων διαφάνειας. Η κλάση **Comment** περιλαμβάνει πληροφορίες όπως ο συγγραφέας που πρόσθεσε το σχόλιο διαφάνειας, τα αρχικά του, η ώρα δημιουργίας, η θέση του σχολίου στη διαφάνεια και το κείμενο του σχολίου. Η κλάση **CommentAuthor** χρησιμοποιείται για την προσθήκη των συγγραφέων σχολίων διαφάνειας σε επίπεδο παρουσίασης. Η κλάση **Presentation** διατηρεί τη συλλογή των συγγραφέων για την παρουσίαση στην κλάση **CommentAuthors**.

Στο παρακάτω παράδειγμα, έχουμε προσθέσει το απόσπασμα κώδικα για την προσθήκη των σχολίων διαφάνειας.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Add a comment to a slide.pptx";

using (Presentation pres = new Presentation())

{

    //Προσθήκη κενής διαφάνειας

    pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

    //Προσθήκη συγγραφέα

    ICommentAuthor author = pres.CommentAuthors.AddAuthor("Zeeshan", "MZ");

    //Θέση σχολίων

    PointF point = new PointF();

    point.X = 1;

    point.Y = 1;

    //Προσθήκη σχολίου διαφάνειας για έναν συγγραφέα στη διαφάνεια

    author.Comments.AddComment("Hello Zeeshan, this is slide comment", pres.Slides[0], point, DateTime.Now);

    pres.Save(FileName, Aspose.Slides.Export.SaveFormat.Pptx);

}

``` 
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Add%20a%20comment%20to%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Add%20a%20comment%20to%20a%20slide/)