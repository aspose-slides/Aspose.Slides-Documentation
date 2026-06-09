---
title: "Διαχείριση σχολίων παρουσίασης στο .NET"
linktitle: "Σχόλια Παρουσίασης"
type: docs
weight: 100
url: /el/net/presentation-comments/
keywords:
- "σχόλιο"
- "σύγχρονο σχόλιο"
- "σχόλια PowerPoint"
- "σχόλια παρουσίασης"
- "σχόλια διαφάνειας"
- "προσθήκη σχολίου"
- "πρόσβαση σε σχόλιο"
- "επεξεργασία σχολίου"
- "απάντηση σε σχόλιο"
- "αφαίρεση σχολίου"
- "διαγραφή σχολίου"
- "PowerPoint"
- "παρουσίαση"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Απογειώστε τη διαχείριση σχολίων παρουσίασης με το Aspose.Slides για .NET: προσθέστε, διαβάστε, επεξεργαστείτε και διαγράψτε σχόλια σε αρχεία PowerPoint γρήγορα και εύκολα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να διαχειρίζεστε τα σχόλια παρουσίασης στο Aspose.Slides. Δείχνει τους κύριους τύπους που σχετίζονται με τα σχόλια και επιδεικνύει πώς να προσθέτετε σχόλια σε διαφάνειες, να έχετε πρόσβαση σε υπάρχοντα σχόλια, να εργάζεστε με απαντήσεις, να χρησιμοποιείτε σύγχρονα σχόλια και να αφαιρείτε σχόλια από μια παρουσίαση.

Τα παραδείγματα εστιάζουν σε κοινά σενάρια ελέγχου και συνεργασίας στο PowerPoint, όπως η ανάθεση σχολίων σε συγγραφείς, η ανάγνωση του περιεχομένου και των μεταδεδομένων των σχολίων, η δημιουργία αλυσίδων απαντήσεων, και η εκκαθάριση όλων των σχολίων ή η διαγραφή επιλεγμένων.

Στο PowerPoint, ένα σχόλιο εμφανίζεται ως σημείωμα ή σημείωση σε μια διαφάνεια. Όταν κάνετε κλικ σε ένα σχόλιο, το περιεχόμενό του ή τα μηνύματά του εμφανίζονται.

## **Γιατί να προσθέτετε σχόλια σε παρουσιάσεις;**

Μπορεί να θέλετε να χρησιμοποιήσετε σχόλια για να παρέχετε ανατροφοδότηση ή να επικοινωνήσετε με τους συναδέλφους σας κατά την αξιολόγηση παρουσιάσεων.

Για να σας επιτρέψει τη χρήση σχολίων σε παρουσιάσεις PowerPoint, το Aspose.Slides for .NET παρέχει

* Τη κλάση [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation), η οποία περιέχει τις συλλογές των συγγραφέων (από την ιδιότητα [CommentAuthorCollection](https://reference.aspose.com/slides/el/net/aspose.slides/icommentauthorcollection/properties/index)). Οι συγγραφείς προσθέτουν σχόλια σε διαφάνειες. 
* Τη διεπαφή [ICommentCollection](https://reference.aspose.com/slides/el/net/aspose.slides/icommentcollection) που περιέχει τη συλλογή των σχολίων για μεμονωμένους συγγραφείς. 
* Την κλάση [IComment](https://reference.aspose.com/slides/el/net/aspose.slides/icomment) που περιέχει πληροφορίες για τους συγγραφείς και τα σχόλιά τους: ποιος πρόσθεσε το σχόλιο, η ώρα προσθήκης, η θέση του σχολίου, κ.λπ. 
* Την κλάση [CommentAuthor](https://reference.aspose.com/slides/el/net/aspose.slides/commentauthor) που περιέχει πληροφορίες για μεμονωμένους συγγραφείς: το όνομα του συγγραφέα, τα αρχικά του, τα σχόλια που σχετίζονται με το όνομα του κ.λπ. 

## **Προσθήκη σχολίων σε διαφάνειες**
Αυτός ο κώδικας C# δείχνει πώς να προσθέσετε ένα σχόλιο σε μια διαφάνεια σε μια παρουσίαση PowerPoint:

```c#
// Δημιουργεί ένα αντικείμενο της κλάσης Presentation
using (Presentation presentation = new Presentation())
{
    // Προσθέτει μια κενή διαφάνεια
    presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

    // Προσθέτει έναν συγγραφέα
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Jawad", "MF");

    // Ορίζει τη θέση για τα σχόλια
    PointF point = new PointF();
    point.X = 0.2f;
    point.Y = 0.2f;

    // Προσθέτει σχόλιο διαφάνειας για έναν συγγραφέα στη διαφάνεια 1
    author.Comments.AddComment("Hello Jawad, this is slide comment", presentation.Slides[0], point, DateTime.Now);

    // Προσθέτει σχόλιο διαφάνειας για έναν συγγραφέα στη διαφάνεια 2
    author.Comments.AddComment("Hello Jawad, this is second slide comment", presentation.Slides[1], point, DateTime.Now);

    // Αποκτά το ISlide 1
    ISlide slide = presentation.Slides[0];

    // Όταν περάσει null ως όρισμα, τα σχόλια όλων των συγγραφέων φέρνονται στη επιλεγμένη διαφάνεια
    IComment[] Comments = slide.GetSlideComments(author);

    // Αποκτά το σχόλιο στη θέση 0 για τη διαφάνεια 1
    String str = Comments[0].Text;

    presentation.Save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.GetLength(0) > 0)
    {
        // Επιλέγει τη συλλογή σχολίων του Συγγραφέα στη θέση 0
        ICommentCollection commentCollection = Comments[0].Author.Comments;
        String Comment = commentCollection[0].Text;
    }
}
```

## **Πρόσβαση σε σχόλια διαφάνειας**
Αυτός ο κώδικας C# δείχνει πώς να έχετε πρόσβαση σε υπάρχον σχόλιο σε μια διαφάνεια σε μια παρουσίαση PowerPoint:

```c#
// Δημιουργεί ένα αντικείμενο της κλάσης Presentation
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

## **Απάντηση σε σχόλια**
Ένα γονικό σχόλιο είναι το αρχικό ή κορυφαίο σχόλιο σε μια ιεραρχία σχολίων ή απαντήσεων. Χρησιμοποιώντας την ιδιότητα [ParentComment](https://reference.aspose.com/slides/el/net/aspose.slides/icomment/properties/parentcomment) (από τη διεπαφή [IComment](https://reference.aspose.com/slides/el/net/aspose.slides/icomment)), μπορείτε να ορίσετε ή να λάβετε ένα γονικό σχόλιο. 

Αυτός ο κώδικας C# δείχνει πώς να προσθέσετε σχόλια και να λάβετε απαντήσεις σε αυτά:

```c#
using (Presentation pres = new Presentation())
{
    // Προσθέτει ένα σχόλιο
    ICommentAuthor author1 = pres.CommentAuthors.AddAuthor("Author_1", "A.A.");
    IComment comment1 = author1.Comments.AddComment("comment1", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    // Προσθέτει μια απάντηση στο comment1
    ICommentAuthor author2 = pres.CommentAuthors.AddAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.Comments.AddComment("reply 1 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply1.ParentComment = comment1;

    // Προσθέτει άλλη απάντηση στο comment1
    IComment reply2 = author2.Comments.AddComment("reply 2 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply2.ParentComment = comment1;

    // Προσθέτει μια απάντηση σε υπάρχουσα απάντηση
    IComment subReply = author1.Comments.AddComment("subreply 3 for reply 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    subReply.ParentComment = reply2;

    IComment comment2 = author2.Comments.AddComment("comment 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    IComment comment3 = author2.Comments.AddComment("comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    IComment reply3 = author1.Comments.AddComment("reply 4 for comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply3.ParentComment = comment3;

    // Εμφανίζει την ιεραρχία σχολίων στην κονσόλα
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

    // Αφαιρεί το comment1 και όλες τις απαντήσεις του
    comment1.Remove();

    pres.Save("remove_comment.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" title="Attention" %}} 

* Όταν χρησιμοποιείται η μέθοδος [Remove](https://reference.aspose.com/slides/el/net/aspose.slides/icomment/methods/remove) (από τη διεπαφή [IComment](https://reference.aspose.com/slides/el/net/aspose.slides/icomment)), τα σχόλια που απαντούν στο σχόλιο διαγράφονται επίσης. 
* Εάν η ρύθμιση [ParentComment](https://reference.aspose.com/slides/el/net/aspose.slides/icomment/properties/parentcomment) οδηγεί σε κυκλική αναφορά, θα προκληθεί η εξαίρεση [PptxEditException](https://reference.aspose.com/slides/el/net/aspose.slides/pptxeditexception). 

{{% /alert %}}

## **Προσθήκη σύγχρονων σχολίων**

Το 2021, η Microsoft παρουσίασε *σύγχρονα σχόλια* στο PowerPoint. Η λειτουργία σύγχρονων σχολίων βελτιώνει σημαντικά τη συνεργασία στο PowerPoint. Μέσω σύγχρονων σχολίων, οι χρήστες του PowerPoint μπορούν να επιλύουν σχόλια, να δεσμεύουν σχόλια σε αντικείμενα και κείμενα, και να αλληλεπιδρούν πολύ πιο εύκολα από πριν. 

Στο [Aspose Slides for .NET 21.11](https://docs.aspose.com/slides/el/net/aspose-slides-for-net-21-11-release-notes/), υλοποιήσαμε υποστήριξη για σύγχρονα σχόλια προσθέτοντας την κλάση [ModernComment](https://reference.aspose.com/slides/el/net/aspose.slides/moderncomment). Οι μέθοδοι [AddModernComment](https://reference.aspose.com/slides/el/net/aspose.slides/commentcollection/methods/addmoderncomment) και [InsertModernComment](https://reference.aspose.com/slides/el/net/aspose.slides/commentcollection/methods/insertmoderncomment) προστέθηκαν στην κλάση [CommentCollection](https://reference.aspose.com/slides/el/net/aspose.slides/commentcollection). 

Αυτός ο κώδικας C# δείχνει πώς να προσθέσετε ένα σύγχρονο σχόλιο σε μια διαφάνεια σε μια παρουσίαση PowerPoint: 

```c#
using (Presentation pres = new Presentation())
{
     ICommentAuthor newAuthor = pres.CommentAuthors.AddAuthor("Some Author", "SA");
     IModernComment modernComment = newAuthor.Comments.AddModernComment("This is a modern comment", pres.Slides[0], null, new PointF(100, 100), DateTime.Now);
 
     pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Αφαίρεση σχολίων**

### **Διαγραφή όλων των σχολίων και συγγραφέων**

Αυτός ο κώδικας C# δείχνει πώς να αφαιρέσετε όλα τα σχόλια και τους συγγραφείς σε μια παρουσίαση:

```c#
using (var presentation = new Presentation("example.pptx"))
{
    // Διαγράφει όλα τα σχόλια από την παρουσίαση
    foreach (var author in presentation.CommentAuthors)
    {
        author.Comments.Clear();
    }

    // Διαγράφει όλους τους συγγραφείς
    presentation.CommentAuthors.Clear();

    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```

### **Διαγραφή συγκεκριμένων σχολίων**

Αυτός ο κώδικας C# δείχνει πώς να διαγράψετε συγκεκριμένα σχόλια σε μια διαφάνεια:

```c#
using (var presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    
    // προσθέτει σχόλια...
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Author", "A");
    author.Comments.AddComment("comment 1", slide, new PointF(0.2f, 0.2f), DateTime.Now);
    author.Comments.AddComment("comment 2", slide, new PointF(0.3f, 0.2f), DateTime.Now);
    
    // αφαιρεί όλα τα σχόλια που περιέχουν "comment 1" κείμενο
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

## **Συχνές ερωτήσεις**

**Το Aspose.Slides υποστηρίζει κατάσταση όπως «επιλυμένο» για τα σύγχρονα σχόλια;**

Ναι. Τα [σύγχρονα σχόλια](https://reference.aspose.com/slides/el/net/aspose.slides/moderncomment/) εκθέτουν μια ιδιότητα [Status](https://reference.aspose.com/slides/el/net/aspose.slides/moderncomment/status/). Μπορείτε να διαβάσετε και να ορίσετε την κατάσταση ενός σχολίου (π.χ., να το σημειώσετε ως επιλυμένο), και αυτή η κατάσταση αποθηκεύεται στο αρχείο και αναγνωρίζεται από το PowerPoint.

**Υποστηρίζονται συζητήσεις με νηματική δομή (αλυσίδες απαντήσεων) και υπάρχει όριο εσοχής;**

Ναι. Κάθε σχόλιο μπορεί να αναφέρεται στο [γονικό του σχόλιο](https://reference.aspose.com/slides/el/net/aspose.slides/comment/parentcomment/), επιτρέποντας αυθαίρετες αλυσίδες απαντήσεων. Το API δεν ορίζει συγκεκριμένο όριο βάθους εσοχής.

**Σε ποιο σύστημα συντεταγμένων ορίζεται η θέση του δείκτη σχολίου σε μια διαφάνεια;**

Η θέση αποθηκεύεται ως σημείο κινητής υποδιαστολής στο σύστημα συντεταγμένων της διαφάνειας. Αυτό σας επιτρέπει να τοποθετήσετε τον δείκτη του σχολίου ακριβώς εκεί που χρειάζεται.