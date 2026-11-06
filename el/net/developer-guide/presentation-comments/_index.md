---
title: Διαχείριση Σχολίων Παρουσίασης σε .NET
linktitle: Σχόλια Παρουσίασης
type: docs
weight: 100
url: /el/net/presentation-comments/
keywords:
- σχόλιο
- μοντέρνο σχόλιο
- σχόλια PowerPoint
- σχόλια παρουσίασης
- σχόλια διαφάνειας
- προσθήκη σχολίου
- πρόσβαση σε σχόλιο
- επεξεργασία σχολίου
- απάντηση σε σχόλιο
- αφαίρεση σχολίου
- διαγραφή σχολίου
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Διαχειριστείτε τα σχόλια παρουσίασης με το Aspose.Slides για .NET: προσθέστε, διαβάστε, επεξεργαστείτε, απαντήστε σε και αφαιρέστε σχόλια σε παρουσιάσεις PowerPoint γρήγορα και εύκολα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να διαχειρίζεστε τα σχόλια παρουσίασης με το Aspose.Slides for .NET. Παρουσιάζει τους κύριους τύπους που σχετίζονται με σχόλια και επιδεικνύει πώς να προσθέσετε σχόλια στις διαφάνειες, να αποκτήσετε πρόσβαση σε υπάρχοντα σχόλια, να εργαστείτε με απαντήσεις και μοντέρνα σχόλια, και να αφαιρέσετε σχόλια από μια παρουσίαση.

Τα παραδείγματα καλύπτουν κοινά σενάρια ανασκόπησης και συνεργασίας στο PowerPoint, όπως η ανάθεση σχολίων σε συγγραφείς, η ανάγνωση του κειμένου και των μεταδεδομένων των σχολίων, η δημιουργία αλυσίδων απαντήσεων, και η αφαίρεση επιλεγμένων σχολίων ή όλων των σχολίων.

Στο PowerPoint, τα σχόλια εμφανίζονται ως σημειώσεις στις διαφάνειες. Η επιλογή ενός σχολίου εμφανίζει το κείμενό του και τη σχετική συζήτηση.

Για να ζητήσετε τα σχόλια να εμφανίζονται ή να κρύβονται όταν ανοίγει μια παρουσίαση χωρίς να αλλάζετε τα σχόλια, δείτε [Εμφάνιση ή Απόκρυψη Σχολίων Κατά το Άνοιγμα μιας Παρουσίασης](/slides/el/net/presentation-view-properties/).

## **Γιατί να Προσθέτετε Σχόλια σε Παρουσιάσεις;**

Μπορείτε να χρησιμοποιήσετε σχόλια για να παρέχετε ανατροφοδότηση και να συνεργάζεστε με συναδέλφους κατά την ανασκόπηση παρουσιάσεων.

Το Aspose.Slides for .NET παρέχει τα ακόλουθα API για εργασία με σχόλια:

* Την κλάση [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) που παρέχει πρόσβαση στους συγγραφείς σχολίων της παρουσίασης.
* Τη διεπαφή [ICommentCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection) που αντιπροσωπεύει τα σχόλια που σχετίζονται με έναν συγκεκριμένο συγγραφέα.
* Τη διεπαφή [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) που παρέχει πληροφορίες σχετικά με ένα σχόλιο, συμπεριλαμβανομένου του συγγραφέα, της ώρας δημιουργίας, της θέσης και του κειμένου.
* Την κλάση [CommentAuthor](https://reference.aspose.com/slides/net/aspose.slides/commentauthor) που παρέχει πληροφορίες για έναν συγγραφέα, όπως το όνομα, τα αρχικά και τα συσχετισμένα σχόλια.

## **Προσθήκη Σχολίων σε Διαφάνειες**

Το παράδειγμα δημιουργεί δύο διαφάνειες και καταχωρεί έναν συγγραφέα σχολίου με το [AddAuthor](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/addauthor/). Χρησιμοποιεί το [AddComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addcomment/) για να τοποθετήσει ένα σχόλιο σε κάθε διαφάνεια, στη συνέχεια ανακτά τα σχόλια της πρώτης διαφάνειας για αυτόν τον συγγραφέα με το [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/). Η κονσόλα εμφανίζει το κείμενο του πρώτου σχολίου δύο φορές, δείχνοντας πρόσβαση τόσο από τη διαφάνεια όσο και από τον συγγραφέα, και η αποθηκευμένη παρουσίαση περιέχει και τα δύο σχόλια.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];
var secondSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

var author = presentation.CommentAuthors.AddAuthor("Jawad", "MF");
var position = new PointF(0.2f, 0.2f);
var createdTime = DateTime.Now;

author.Comments.AddComment("Hello Jawad, this is a slide comment", firstSlide, position, createdTime);
author.Comments.AddComment("Hello Jawad, this is the second slide comment", secondSlide, position, createdTime);

var comments = firstSlide.GetSlideComments(author);
if (comments.Length > 0)
{
    var firstComment = comments[0];
    Console.WriteLine(firstComment.Text);

    var commentText = firstComment.Author.Comments[0].Text;
    Console.WriteLine(commentText);
}

presentation.Save("Comments_out.pptx", SaveFormat.Pptx);
```

## **Εύρεση ή Δημιουργία Συγγραφέα Σχολίου**

Όταν μια αυτοματοποιημένη ανασκόπηση επεξεργάζεται την ίδια παρουσίαση επανειλημμένα, ψάξτε στη συλλογή [CommentAuthors](https://reference.aspose.com/slides/net/aspose.slides/presentation/commentauthors/) πριν προσθέσετε νέο συγγραφέα. Η μέθοδος [FindByNameAndInitials](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/findbynameandinitials/) ταιριάζει τόσο με το όνομα όσο και με τα αρχικά και επιστρέφει έναν πίνακα με τους αντίστοιχους συγγραφείς, ή έναν κενό πίνακα αν δεν βρεθούν αντιστοιχίες. Αντίθετα, η [FindByName](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/findbyname/) αναζητεί μόνο με βάση το όνομα, χωρίς να λαμβάνει υπόψη τα αρχικά. Η κλήση του [AddAuthor](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/addauthor/) με όνομα και αρχικά που ήδη υπάρχουν στη συλλογή προκαλεί εξαίρεση.

Το παράδειγμα απαιτεί ένα αρχείο παρουσίασης με τουλάχιστον μία διαφάνεια. Σε κάθε μια από τις δύο διέλευσεις, επαναχρησιμοποιεί τον πρώτο ταιριανό συγγραφέα ή δημιουργεί νέο μόνο όταν το αποτέλεσμα είναι κενό. Αν υπάρχουν πολλαπλές αντιστοιχίες, επιλέγει το πρώτο στοιχείο του πίνακα χωρίς να συγχωνεύει ή να αφαιρεί άλλους συγγραφείς. Στη συνέχεια καλεί το [AddComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addcomment/) για τον επιλεγμένο συγγραφέα και αποθηκεύει την παρουσίαση. Η δεύτερη διέλευση ανοίγει το αποτέλεσμα της πρώτης διέλευσης και επαναλαμβάνει τη λειτουργία.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const string authorName = "Reviewer";
const string authorInitials = "RV";

var inputFile = "input.pptx";
var position = new PointF(20, 20);

for (var pass = 1; pass <= 2; pass++)
{
    using var presentation = new Presentation(inputFile);

    var matches = presentation.CommentAuthors.FindByNameAndInitials(authorName, authorInitials);
    
    var author = matches.Length > 0 ? matches[0] : presentation.CommentAuthors.AddAuthor(authorName, authorInitials);
    author.Comments.AddComment("Please review this slide.", presentation.Slides[0], position, DateTime.Now);

    var outputFile = $"review_pass_{pass}.pptx";
    presentation.Save(outputFile, SaveFormat.Pptx);
    inputFile = outputFile;
}
```

Η δεύτερη διέλευση προσθέτει ακόμη ένα σχόλιο χωρίς να προσθέτει νέο συγγραφέα ή να αφαιρεί υπάρχοντα σχόλια. Το τελικό αρχείο, `review_pass_2.pptx`, περιέχει και τα νέα σχόλια και τυχόν αυθεντικά σχόλια. Η επανάληψη ενός συγγραφέα δεν αφαιρεί διπλότυπα σχόλια: για να αποφύγετε την επανειλημμένη προσθήκη του ίδιου σχολίου, υλοποιήστε ξεχωριστό έλεγχο διπλοτύπων πριν το προσθέσετε.

## **Πρόσβαση σε Σχόλια Διαφάνειας**

Το παράδειγμα ανοίγει μια υπάρχουσα παρουσίαση και διαβάζει τη συλλογή [CommentAuthors](https://reference.aspose.com/slides/net/aspose.slides/presentation/commentauthors/). Για κάθε συγγραφέα, διατρέχει τα [Comments](https://reference.aspose.com/slides/net/aspose.slides/icommentauthor/comments/) και εκτυπώνει τον αριθμό της διαφάνειας, το κείμενο του σχολίου, το όνομα του συγγραφέα και την ώρα δημιουργίας. Η εισαγόμενη παρουσίαση πρέπει να περιέχει σχόλια για να παραχθεί έξοδος στην κονσόλα.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Comments1.pptx");

foreach (var author in presentation.CommentAuthors)
{
    foreach (var comment in author.Comments)
    {
        Console.WriteLine($"Slide: {comment.Slide.SlideNumber}");
        Console.WriteLine($"Comment: {comment.Text}");
        Console.WriteLine($"Author: {comment.Author.Name}");
        Console.WriteLine($"Posted at: {comment.CreatedTime}");
        Console.WriteLine();
    }
}
```

## **Απάντηση σε Σχόλια**

Ένα γονικό σχόλιο είναι το αρχικό σχόλιο στην κορυφή μιας ιεραρχίας απαντήσεων. Η ιδιότητα [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) της διεπαφής [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) επιτρέπει την ανάκτηση ή την ορισμό του γονέα ενός σχολίου.

Το παράδειγμα δημιουργεί σχόλια από δύο συγγραφείς και χρησιμοποιεί το [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) για να δημιουργήσει απαντήσεις, συμπεριλαμβανομένης μιας απάντησης σε άλλη απάντηση. Η παράδοση του `null` στο [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/) ανακτά σχόλια από όλους τους συγγραφείς· η κονσόλα εσοχή κάθε καταχώρησης ανάλογα με το βάθος της στην ιεραρχία απαντήσεων. Το παράδειγμα αποθηκεύει τη συνολική συζήτηση, καλεί το [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/remove/) στο πρώτο ριζικό σχόλιο, και αποθηκεύει μια δεύτερη παρουσίαση με το σχόλιο αυτό και τις απαντήσεις του αφαιρεμένες.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var position = new PointF(10, 10);
var createdTime = DateTime.Now;

var originalAuthor = presentation.CommentAuthors.AddAuthor("Author_1", "A.A.");
var rootComment = originalAuthor.Comments.AddComment("comment 1", slide, position, createdTime);

var reviewer = presentation.CommentAuthors.AddAuthor("Author_2", "B.B.");
var firstReply = reviewer.Comments.AddComment("reply 1 for comment 1", slide, position, createdTime);
firstReply.ParentComment = rootComment;

var secondReply = reviewer.Comments.AddComment("reply 2 for comment 1", slide, position, createdTime);
secondReply.ParentComment = rootComment;

var subReply = originalAuthor.Comments.AddComment("subreply 3 for reply 2", slide, position, createdTime);
subReply.ParentComment = secondReply;

reviewer.Comments.AddComment("comment 2", slide, position, createdTime);
var separateComment = reviewer.Comments.AddComment("comment 3", slide, position, createdTime);

var separateReply = originalAuthor.Comments.AddComment("reply 4 for comment 3", slide, position, createdTime);
separateReply.ParentComment = separateComment;

var comments = slide.GetSlideComments(null);
for (var i = 0; i < comments.Length; i++)
{
    var comment = comments[i];
    while (comment.ParentComment != null)
    {
        Console.Write("\t");
        comment = comment.ParentComment;
    }

    Console.WriteLine($"{comments[i].Author.Name}: {comments[i].Text}");
}

presentation.Save("parent_comment.pptx", SaveFormat.Pptx);

rootComment.Remove();
presentation.Save("remove_comment.pptx", SaveFormat.Pptx);
```

{{% alert color="warning" title="Warning" %}}
* Όταν η μέθοδος [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/remove/) της διεπαφής [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) χρησιμοποιείται για διαγραφή ενός σχολίου, διαγράφονται επίσης όλες οι απαντήσεις σε αυτό το σχόλιο.
* Εάν η ιδιότητα [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) δημιουργεί κυκλική αναφορά, εξαίρεση [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception) ρίχνεται.
{{% /alert %}}

## **Προσθήκη Μοντέρνων Σχολίων**

Τα μοντέρνα σχόλια μπορούν να συσχετιστούν με την ίδια τη διαφάνεια, με ένα συγκεκριμένο σχήμα ή με μια περιοχή κειμένου μέσα σε AutoShape. Η μέθοδος [ICommentCollection.AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) δέχεται ένα όρισμα τύπου [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) επιπλέον των συντεταγμένων της διαφάνειας και του δείκτη σχολίου.

Όταν το όρισμα του σχήματος είναι `null`, το σχόλιο είναι σχολιασμένο στο επίπεδο της διαφάνειας. Ο δείκτης του τοποθετείται από τις δοθείσες συντεταγμένες, αλλά δεν σχετίζεται με κάποιο συγκεκριμένο σχήμα, έτσι η ιδιότητα [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/) επιστρέφει `null`. Όταν παρέχεται ένα [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/), το σχόλιο αγκυροβολείται στο σχήμα αυτό. Οι συντεταγμένες εξακολουθούν να ορίζουν τη θέση του δείκτη σχολίου στη διαφάνεια, ενώ η συσχέτιση σχήματος μπορεί να ανακτηθεί μέσω του [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/).

### **Αγκυροβολία Μοντέρνου Σχολίου σε Σχήμα**

Το παράδειγμα καλεί το [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) δύο φορές: μία με σχήμα `null` για σχόλιο σε επίπεδο διαφάνειας και μία με ένα ορθογώνιο ως αγκίστρωση. Η ανάγνωση του [Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/) εκτυπώνει `True` για τον έλεγχο null του σχολίου επιπέδου διαφάνειας και `Revenue title` για το αγκυρωμένο σχόλιο. Και τα δύο σχόλια αποθηκεύονται με την παρουσίαση.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var author = presentation.CommentAuthors.AddAuthor("Reviewer", "RV");

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 300, 80);
shape.Name = "Revenue title";
shape.TextFrame.Text = "Quarterly revenue";

var createdTime = DateTime.Now;
var slideCommentPosition = new PointF(20, 20);
var shapeCommentPosition = new PointF(60, 60);
var slideComment = author.Comments.AddModernComment("Review the overall slide layout.", slide, null, slideCommentPosition, createdTime);
var shapeComment = author.Comments.AddModernComment("Check this title.", slide, shape, shapeCommentPosition, createdTime);

Console.WriteLine(slideComment.Shape == null);
Console.WriteLine(shapeComment.Shape?.Name);

presentation.Save("modern_comments.pptx", SaveFormat.Pptx);
```

### **Αγκυροβολία Σχολίων σε Διαφορετικούς Τύπους Σχημάτων**

Οποιοδήποτε αντικείμενο διαφάνειας που υλοποιεί την διεπαφή [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) μπορεί να χρησιμοποιηθεί ως αγκίστρωση σχήματος. Συνήθη παραδείγματα περιλαμβάνουν [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/net/aspose.slides/iconnector/), και [IGraphicalObject](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobject/) όπως τα γραφήματα.

Το παράδειγμα χρησιμοποιεί το [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) για να συσχετίσει ένα σχόλιο με καθέναν από τους πέντε τύπους σχημάτων: ένα AutoShape, ένα πλαίσιο εικόνας, μια ομάδα, ένα σύνδεσμο και ένα γράφημα. Η εικόνα ενσωματώνει δεδομένα εικόνας, έτσι δεν απαιτείται εξωτερική εικόνα. Κάθε σχόλιο έχει τη δική του θέση δείκτη, και η αποθηκευμένη παρουσίαση διατηρεί όλες τις πέντε συσχετίσεις σχήματος.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var author = presentation.CommentAuthors.AddAuthor("Reviewer", "RV");
var createdTime = DateTime.Now;

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 180, 60);
autoShape.TextFrame.Text = "AutoShape";

var autoShapeCommentPosition = new PointF(30, 30);
author.Comments.AddModernComment("Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

var imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
var imageData = Convert.FromBase64String(imageBase64);
var image = presentation.Images.AddImage(imageData);
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 220, 20, 120, 80, image);
var pictureCommentPosition = new PointF(230, 30);
author.Comments.AddModernComment("Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

var groupShape = slide.Shapes.AddGroupShape();
groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 80, 40);
groupShape.Shapes.AddAutoShape(ShapeType.Ellipse, 100, 0, 80, 40);
var groupCommentPosition = new PointF(40, 150);
author.Comments.AddModernComment("Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

var connector = slide.Shapes.AddConnector(ShapeType.StraightConnector1, 220, 150, 140, 40);
var connectorCommentPosition = new PointF(240, 150);
author.Comments.AddModernComment("Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 400, 20, 250, 180);
var chartCommentPosition = new PointF(420, 40);
author.Comments.AddModernComment("Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

presentation.Save("modern_comment_shape_types.pptx", SaveFormat.Pptx);
```

### **Αγκυροβολία Σχολίου σε Κείμενο και Ορισμός της Κατάστασής του**

Για ένα μοντέρνο σχόλιο που συνδέεται με ένα [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), η ιδιότητα [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/) καθορίζει τη θέση έναρξης του επιλεγμένου κειμένου στο πλαίσιο κειμένου του σχήματος, ενώ η [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) καθορίζει το μήκος της επιλογής. Μαζί, αυτές οι ιδιότητες συνδέουν το σχόλιο με ένα συγκεκριμένο εύρος κειμένου μέσα στο AutoShape.

Η ιδιότητα [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) μπορεί να διαβαστεί ή να ενημερωθεί με τιμή από τον αριθμό [ModernCommentStatus](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/):

- `NotDefined` — δεν έχει οριστεί συγκεκριμένη κατάσταση μοντέρνου σχολίου.
- `Active` — το σχόλιο είναι ενεργό.
- `Resolved` — το σχόλιο έχει επιλυθεί.
- `Closed` — το σχόλιο είναι κλειστό.

Το παράδειγμα αγκυροβολεί ένα μοντέρνο σχόλιο στις λέξεις «quarterly revenue» σε κείμενο ορθογωνίου. Υπολογίζει τη θέση έναρξης μηδενικής βάσης του [TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/) από το κείμενο και ορίζει το [TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) στον αριθμό των επιλεγμένων χαρακτήρων. Αφού θέτει το [Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) σε `Resolved`, αποθηκεύει και ξαναφορτώνει την παρουσίαση. Οι τέσσερις έλεγχοι στην κονσόλα θα πρέπει να εκτυπώσουν `True`, επιβεβαιώνοντας ότι η αγκίστρωση σχήματος, το εύρος κειμένου και η κατάσταση διατηρήθηκαν.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputFile = "modern_comment_text_anchor.pptx";
const string shapeText = "Review the quarterly revenue forecast.";
const string selectedText = "quarterly revenue";
var expectedSelectionStart = shapeText.IndexOf(selectedText, StringComparison.Ordinal);

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.Name = "Forecast text";
shape.TextFrame.Text = shapeText;

var author = presentation.CommentAuthors.AddAuthor("Reviewer", "RV");
var commentPosition = new PointF(60, 60);
var comment = author.Comments.AddModernComment("Verify this forecast wording.", slide, shape, commentPosition, DateTime.Now);
comment.TextSelectionStart = expectedSelectionStart;
comment.TextSelectionLength = selectedText.Length;
comment.Status = ModernCommentStatus.Resolved;

presentation.Save(outputFile, SaveFormat.Pptx);

using var reopenedPresentation = new Presentation(outputFile);
var reopenedSlide = reopenedPresentation.Slides[0];
var reopenedComments = reopenedSlide.GetSlideComments(null);

foreach (var reopenedComment in reopenedComments)
{
    if (reopenedComment is not IModernComment modernComment)
    {
        continue;
    }

    var shapeMatches = modernComment.Shape?.Name == "Forecast text";
    var selectionStartMatches = modernComment.TextSelectionStart == expectedSelectionStart;
    var selectionLengthMatches = modernComment.TextSelectionLength == selectedText.Length;
    var statusMatches = modernComment.Status == ModernCommentStatus.Resolved;

    Console.WriteLine($"Shape anchor preserved: {shapeMatches}");
    Console.WriteLine($"Text selection start preserved: {selectionStartMatches}");
    Console.WriteLine($"Text selection length preserved: {selectionLengthMatches}");
    Console.WriteLine($"Resolved status preserved: {statusMatches}");
}
```

### **Επιθεώρηση Υπαρχόντων Μοντέρνων Σχολίων**

Το παράδειγμα απαιτεί μια υπάρχουσα παρουσίαση που περιέχει μοντέρνα σχόλια και εκτυπώνει το κείμενό τους, την κατάσταση και τις λεπτομέρειες αγκίστρωσης. Για να το επιθεωρήσετε, ελέγξτε ποια σχόλια υλοποιούν το [IModernComment](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/), στη συνέχεια εξετάστε το [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/), το [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/), το [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) και το [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/). Ένα σχήμα `null` υποδεικνύει σχολίαση σε επίπεδο διαφάνειας. Για μια αγκίστρωση σε [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), οι ιδιότητες επιλογής κειμένου προσδιορίζουν το αντίστοιχο εύρος στο πλαίσιο κειμένου του σχήματος.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("comments.pptx");

foreach (var slide in presentation.Slides)
{
    var comments = slide.GetSlideComments(null);
    foreach (var comment in comments)
    {
        if (comment is not IModernComment modernComment)
        {
            continue;
        }

        Console.WriteLine($"Slide: {slide.SlideNumber}");
        Console.WriteLine($"Text: {modernComment.Text}");
        Console.WriteLine($"Status: {modernComment.Status}");

        var shape = modernComment.Shape;
        if (shape == null)
        {
            Console.WriteLine("Anchor: slide level");
        }
        else
        {
            Console.WriteLine($"Anchor shape: {shape.Name}");
            Console.WriteLine($"Anchor type: {shape.GetType().Name}");

            if (shape is IAutoShape)
            {
                Console.WriteLine($"Text selection start: {modernComment.TextSelectionStart}");
                Console.WriteLine($"Text selection length: {modernComment.TextSelectionLength}");
            }
        }

        Console.WriteLine();
    }
}
```

## **Αφαίρεση Σχολίων**

Το Aspose.Slides for .NET επιτρέπει την αφαίρεση όλων των σχολίων και των συγγραφέων τους από μια παρουσίαση ή τη διαγραφή επιλεγμένων σχολίων διατηρώντας τα υπόλοιπα. Τα παρακάτω παραδείγματα δείχνουν και τις δύο προσεγγίσεις και αποθηκεύουν την ενημερωμένη παρουσίαση.

### **Αφαίρεση Όλων των Σχολίων και των Συγγραφέων Σχολίων**

Το παράδειγμα ανοίγει μια υπάρχουσα παρουσίαση και καλεί το [ICommentCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/clear/) για κάθε συγγραφέα, στη συνέχεια καλεί το [ICommentAuthorCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/clear/) για την αφαίρεση των ίδιων των συγγραφέων. Η αποθηκευμένη παρουσίαση δεν περιλαμβάνει ούτε σχόλια ούτε συγγραφείς σχολίων. Χρησιμοποιήστε μια παρουσίαση που περιέχει σχόλια για να παρατηρήσετε την αφαίρεση.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("example.pptx");

foreach (var author in presentation.CommentAuthors)
{
    author.Comments.Clear();
}

presentation.CommentAuthors.Clear();

presentation.Save("example_out.pptx", SaveFormat.Pptx);
```

### **Αφαίρεση Συγκεκριμένων Σχολίων**

Το παράδειγμα δημιουργεί δύο σχόλια σε μία διαφάνεια και χρησιμοποιεί το [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/) για να βρει τα σχόλια ανά συγγραφέα. Συλλέγει σχόλια του οποίου το κείμενο είναι ίσο με «comment 1» πριν καλέσει το [ICommentCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/remove/), αποφεύγοντας αλλαγές στη συλλογή κατά την επιλογή. Η αποθηκευμένη παρουσίαση διατηρεί μόνο το «comment 2».

```csharp
using System;
using System.Collections.Generic;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var author = presentation.CommentAuthors.AddAuthor("Author", "A");
var createdTime = DateTime.Now;

var firstCommentPosition = new PointF(0.2f, 0.2f);
var secondCommentPosition = new PointF(0.3f, 0.2f);
author.Comments.AddComment("comment 1", slide, firstCommentPosition, createdTime);
author.Comments.AddComment("comment 2", slide, secondCommentPosition, createdTime);

foreach (var commentAuthor in presentation.CommentAuthors)
{
    var commentsToRemove = new List<IComment>();
    var comments = slide.GetSlideComments(commentAuthor);

    foreach (var comment in comments)
    {
        if (comment.Text == "comment 1")
        {
            commentsToRemove.Add(comment);
        }
    }

    foreach (var comment in commentsToRemove)
    {
        commentAuthor.Comments.Remove(comment);
    }
}

presentation.Save("pres.pptx", SaveFormat.Pptx);
```

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Υποστηρίζει το Aspose.Slides κατάσταση «επιλυμένο» για μοντέρνα σχόλια;**

Ναι. Η ιδιότητα [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) μπορεί να διαβαστεί και να οριστεί με τιμή του αριθμού [ModernCommentStatus](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/), συμπεριλαμβανομένου του `Resolved`. Η κατάσταση αποθηκεύεται στην παρουσίαση και μπορεί να αναγνωστεί ξανά μετά το άνοιγμα του αρχείου.

**Υποστηρίζονται συζητήσεις με αλληλουχίες απαντήσεων και υπάρχει όριο εσωτερικοποίησης;**

Ναι. Κάθε σχόλιο μπορεί να αναφέρει το [parent comment](https://reference.aspose.com/slides/net/aspose.slides/comment/parentcomment/), επιτρέποντας αλληλουχίες απαντήσεων. Το API δεν ορίζει συγκεκριμένο όριο βάθους εσωτερικοποίησης.

**Σε ποιο σύστημα συντεταγμένων ορίζεται η θέση του δείκτη σχολίου σε μια διαφάνεια;**

Η θέση του δείκτη ορίζεται από συντεταγμένες κινητής υποδιαστολής στο σύστημα συντεταγμένων της διαφάνειας, επιτρέποντάς σας να τοποθετήσετε το δείκτη ακριβώς στη διαφάνεια.