---
title: Διαχείριση σχολίων παρουσίασης στο .NET
linktitle: Σχόλια παρουσίασης
type: docs
weight: 100
url: /el/net/presentation-comments/
keywords:
- σχόλιο
- σύγχρονο σχόλιο
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
description: "Διαχειριστείτε τα σχόλια παρουσίασης με το Aspose.Slides για .NET: προσθέστε, διαβάστε, επεξεργαστείτε, απαντήστε και αφαιρέστε σχόλια σε παρουσιάσεις PowerPoint γρήγορα και εύκολα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να διαχειρίζεστε τα σχόλια παρουσίασης με το Aspose.Slides for .NET. Παρουσιάζει τους κύριους τύπους που σχετίζονται με τα σχόλια και δείχνει πώς να προσθέτετε σχόλια σε διαφάνειες, να έχετε πρόσβαση σε υπάρχοντα σχόλια, να εργάζεστε με απαντήσεις και σύγχρονα σχόλια, και να αφαιρείτε σχόλια από μια παρουσίαση.

Τα παραδείγματα καλύπτουν κοινά σενάρια ελέγχου και συνεργασίας στο PowerPoint, όπως η ανάθεση σχολίων σε συγγραφείς, η ανάγνωση κειμένου σχολίου και μεταδεδομένων, η δημιουργία αλυσίδων απαντήσεων, και η κατάργηση επιλεγμένων σχολίων ή όλων των σχολίων.

Στο PowerPoint, τα σχόλια εμφανίζονται ως σημειώσεις στις διαφάνειες. Η επιλογή ενός σχολίου εμφανίζει το κείμενό του και τη σχετική συζήτηση.

## **Γιατί να Προσθέτετε Σχόλια σε Παρουσιάσεις;**

Μπορείτε να χρησιμοποιήσετε τα σχόλια για να παρέχετε ανατροφοδότηση και να συνεργάζεστε με συναδέλφους κατά την ανασκόπηση παρουσιάσεων.

Aspose.Slides for .NET παρέχει τα παρακάτω API για εργασία με σχόλια:

* The [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) class, which provides access to the presentation's comment authors. → κλάση, η οποία παρέχει πρόσβαση στους συγγραφείς σχολίων της παρουσίασης.
* The [ICommentCollection](https://reference.aspose.com/slides/el/net/aspose.slides/icommentcollection) interface, which represents the comments associated with an individual author. → διεπαφή, η οποία αντιπροσωπεύει τα σχόλια που σχετίζονται με έναν συγκεκριμένο συγγραφέα.
* The [IComment](https://reference.aspose.com/slides/el/net/aspose.slides/icomment) interface, which provides information about a comment, including its author, creation time, position, and text. → διεπαφή, η οποία παρέχει πληροφορίες σχετικά με ένα σχόλιο, συμπεριλαμβανομένου του συγγραφέα, του χρόνου δημιουργίας, της θέσης και του κειμένου.
* The [CommentAuthor](https://reference.aspose.com/slides/el/net/aspose.slides/commentauthor) class, which provides information about an author, including their name, initials, and associated comments. → κλάση, η οποία παρέχει πληροφορίες για έναν συγγραφέα, συμπεριλαμβανομένου του ονόματος, των αρχικών και των σχετικών σχολίων.

## **Προσθήκη Σχολίων σε Διαφάνειες**

Το παρακάτω παράδειγμα δείχνει πώς να προσθέτετε σχόλια σε διαφάνειες σε μια παρουσίαση PowerPoint:

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

## **Πρόσβαση σε Σχόλια Διαφάνειας**

Το παρακάτω παράδειγμα δείχνει πώς να έχετε πρόσβαση σε υπάρχοντα σχόλια σε μια παρουσίαση PowerPoint:

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

Ένα γονικό σχόλιο είναι το αρχικό σχόλιο στην κορυφή μιας ιεραρχίας απαντήσεων. Η ιδιότητα [ParentComment](https://reference.aspose.com/slides/el/net/aspose.slides/icomment/properties/parentcomment) της διεπαφής [IComment](https://reference.aspose.com/slides/el/net/aspose.slides/icomment) σας επιτρέπει να λάβετε ή να ορίσετε το γονικό σχόλιο.

Το παρακάτω παράδειγμα δείχνει πώς να προσθέτετε απαντήσεις και να εξετάζετε την προκύπτουσα ιεραρχία σχολίων:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var position = new PointF(10, 10);
var createdTime = DateTime.Now;

var author1 = presentation.CommentAuthors.AddAuthor("Author_1", "A.A.");
var comment1 = author1.Comments.AddComment("comment 1", slide, position, createdTime);

var author2 = presentation.CommentAuthors.AddAuthor("Author_2", "B.B.");
var reply1 = author2.Comments.AddComment("reply 1 for comment 1", slide, position, createdTime);
reply1.ParentComment = comment1;

var reply2 = author2.Comments.AddComment("reply 2 for comment 1", slide, position, createdTime);
reply2.ParentComment = comment1;

var subReply = author1.Comments.AddComment("subreply 3 for reply 2", slide, position, createdTime);
subReply.ParentComment = reply2;

author2.Comments.AddComment("comment 2", slide, position, createdTime);
var comment3 = author2.Comments.AddComment("comment 3", slide, position, createdTime);

var reply3 = author1.Comments.AddComment("reply 4 for comment 3", slide, position, createdTime);
reply3.ParentComment = comment3;

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

comment1.Remove();
presentation.Save("remove_comment.pptx", SaveFormat.Pptx);
```

{{% alert color="warning" title="Προσοχή" %}} 

* Όταν η μέθοδος [Remove](https://reference.aspose.com/slides/el/net/aspose.slides/icomment/methods/remove) της διεπαφής [IComment](https://reference.aspose.com/slides/el/net/aspose.slides/icomment) χρησιμοποιείται για τη διαγραφή ενός σχολίου, όλες οι απαντήσεις σε αυτό το σχόλιο διαγράφονται επίσης.
* Εάν η ιδιότητα [ParentComment](https://reference.aspose.com/slides/el/net/aspose.slides/icomment/properties/parentcomment) δημιουργεί κυκλική αναφορά, ρίχεται μια [PptxEditException](https://reference.aspose.com/slides/el/net/aspose.slides/pptxeditexception).

{{% /alert %}}

## **Προσθήκη Σύγχρονων Σχολίων**

Τα σύγχρονα σχόλια μπορούν να συσχετιστούν με την ίδια τη διαφάνεια, με ένα συγκεκριμένο σχήμα ή με ένα εύρος κειμένου μέσα σε AutoShape. Η μέθοδος [ICommentCollection.AddModernComment](https://reference.aspose.com/slides/el/net/aspose.slides/icommentcollection/addmoderncomment/) δέχεται ένα όρισμα [IShape](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/) επιπλέον των συντεταγμένων της διαφάνειας και του δείκτη σχολίου.

Όταν `null` παρασχεθεί για το όρισμα σχήματος, το σχόλιο είναι σχόλιο επιπέδου διαφάνειας. Ο δείκτης του τοποθετείται με τις δοθείσες συντεταγμένες, αλλά δεν συσχετίζεται με κάποιο συγκεκριμένο σχήμα, έτσι το [IModernComment.Shape](https://reference.aspose.com/slides/el/net/aspose.slides/imoderncomment/shape/) επιστρέφει `null`. Όταν παρέχεται ένα [IShape](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/), το σχόλιο αγκυροβολείται σε αυτό το σχήμα. Οι συντεταγμένες εξακολουθούν να ορίζουν τη θέση του δείκτη σχολίου στη διαφάνεια, ενώ η συσχέτιση σχήματος μπορεί να ληφθεί μέσω του [IModernComment.Shape](https://reference.aspose.com/slides/el/net/aspose.slides/imoderncomment/shape/).

### **Αγκύρωση Σύγχρονου Σχολίου σε Σχήμα**

Το παρακάτω παράδειγμα δημιουργεί τόσο ένα σχόλιο επιπέδου διαφάνειας όσο και ένα σύγχρονο σχόλιο αγκυροπολημένο σε συγκεκριμένο AutoShape. Στη συνέχεια διαβάζει το συσχετισμένο σχήμα από κάθε σχόλιο.

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

### **Αγκύρωση Σχολίων σε Διαφορετικούς Τύπους Σχημάτων**

Οποιοδήποτε αντικείμενο διαφάνειας που υλοποιεί το [IShape](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/) μπορεί να χρησιμοποιηθεί ως άγκυρα σχήματος. Συνήθεις παραδείγματα περιλαμβάνουν τα [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/el/net/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/el/net/aspose.slides/iconnector/) και αντικείμενα [IGraphicalObject](https://reference.aspose.com/slides/el/net/aspose.slides/igraphicalobject/) όπως γραφήματα.

Το παρακάτω παράδειγμα δημιουργεί αρκετούς κοινούς τύπους σχημάτων και συσχετίζει ένα σύγχρονο σχόλιο με το καθένα.

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

### **Αγκύρωση Σχολίου σε Κείμενο και Ορισμός Κατάστασής του**

Για ένα σύγχρονο σχόλιο που συσχετίζεται με ένα [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/), το [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/el/net/aspose.slides/imoderncomment/textselectionstart/) καθορίζει τη θέση έναρξης του επιλεγμένου κειμένου στο πλαίσιο κειμένου του σχήματος, ενώ το [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/el/net/aspose.slides/imoderncomment/textselectionlength/) καθορίζει το μήκος της επιλογής. Μαζί, αυτές οι ιδιότητες συσχετίζουν το σχόλιο με ένα συγκεκριμένο εύρος κειμένου μέσα στο AutoShape.

Η ιδιότητα [IModernComment.Status](https://reference.aspose.com/slides/el/net/aspose.slides/imoderncomment/status/) μπορεί να διαβαστεί ή να ενημερωθεί με μια τιμή από την αρίθμηση [ModernCommentStatus](https://reference.aspose.com/slides/el/net/aspose.slides/moderncommentstatus/):

- `NotDefined` — δεν έχει οριστεί συγκεκριμένη κατάσταση σύγχρονου σχολίου.
- `Active` — το σχόλιο είναι ενεργό.
- `Resolved` — το σχόλιο έχει επιλυθεί.
- `Closed` — το σχόλιο είναι κλειστό.

Το παρακάτω παράδειγμα δημιουργεί ένα σχήμα‑αγκυροποιημένο σύγχρονο σχόλιο, το συσχετίζει με μια επιλογή κειμένου, το σημειώνει ως επιλυμένο, αποθηκεύει την παρουσίαση και επαληθεύει τις τιμές μετά το άνοιγμά της.

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

### **Επιθεώρηση Υπάρχοντων Συγχρόνων Σχολίων**

Για να επιθεωρήσετε μια υπάρχουσα παρουσίαση, ελέγξτε ποια σχόλια υλοποιούν το [IModernComment](https://reference.aspose.com/slides/el/net/aspose.slides/imoderncomment/), στη συνέχεια εξετάστε το [IModernComment.Shape](https://reference.aspose.com/slides/el/net/aspose.slides/imoderncomment/shape/), το [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/el/net/aspose.slides/imoderncomment/textselectionstart/), το [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/el/net/aspose.slides/imoderncomment/textselectionlength/) και την ιδιότητα [IModernComment.Status](https://reference.aspose.com/slides/el/net/aspose.slides/imoderncomment/status/). Ένα `null` σχήμα υποδεικνύει σχόλιο επιπέδου διαφάνειας. Για άγκυρα [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/), οι ιδιότητες επιλογής κειμένου προσδιορίζουν το σχετικό εύρος στο πλαίσιο κειμένου του σχήματος.

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

## **Κατάργηση Σχολίων**

### **Κατάργηση Όλων των Σχολίων και Συγγραφέων Σχολίων**

Το παρακάτω παράδειγμα δείχνει πώς να αφαιρέσετε όλα τα σχόλια και τους συγγραφείς σχολίων από μια παρουσίαση:

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

### **Κατάργηση Συγκεκριμένων Σχολίων**

Το παρακάτω παράδειγμα δείχνει πώς να αφαιρέσετε συγκεκριμένα σχόλια από μια διαφάνεια:

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

## **Συχνές Ερωτήσεις**

**Υποστηρίζει το Aspose.Slides κατάσταση «Επιλυμένο» για σύγχρονα σχόλια;**

Ναι. Η ιδιότητα [IModernComment.Status](https://reference.aspose.com/slides/el/net/aspose.slides/imoderncomment/status/) μπορεί να διαβαστεί και να οριστεί με μια τιμή της αρίθμησης [ModernCommentStatus](https://reference.aspose.com/slides/el/net/aspose.slides/moderncommentstatus/), συμπεριλαμβανομένου του `Resolved`. Η κατάσταση αποθηκεύεται στην παρουσίαση και μπορεί να διαβαστεί ξανά μετά το άνοιγμα του αρχείου.

**Υποστηρίζονται συζητήσεις με νήματα (αλυσίδες απαντήσεων) και υπάρχει όριο βάθους εμφώλευσης;**

Ναι. Κάθε σχόλιο μπορεί να αναφέρεται στο [parent comment](https://reference.aspose.com/slides/el/net/aspose.slides/comment/parentcomment/), επιτρέποντας αλυσίδες απαντήσεων. Το API δεν ορίζει συγκεκριμένο όριο βάθους εμφώλευσης.

**Σε ποιο σύστημα συντεταγμένων ορίζεται η θέση του δείκτη σχολίου σε μια διαφάνεια;**

Η θέση του δείκτη ορίζεται από συντεταγμένες κινητής υποδιαστολής στο σύστημα συντεταγμένων της διαφάνειας, επιτρέποντάς σας να τοποθετήσετε ακριβώς το δείκτη στη διαφάνεια.