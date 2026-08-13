---
title: Διαχείριση λιστών με κουκκίδες και αριθμούς σε παρουσιάσεις σε .NET
linktitle: Διαχείριση λιστών
type: docs
weight: 70
url: /el/net/manage-lists/
aliases:
  - /net/manage-bullet-and-numbered-lists/
keywords:
- κουκκίδα
- λίστα με κουκκίδες
- αριθμημένη λίστα
- συμβολική κουκκίδα
- εικόνα‑κουκκίδα
- προσαρμοσμένη κουκκίδα
- πολυεπίπεδη λίστα
- δημιουργία κουκκίδας
- προσθήκη κουκκίδας
- προσθήκη λίστας
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς να δημιουργείτε και να μορφοποιείτε λίστες με κουκκίδες, εικόνα, πολυεπίπεδες και αριθμημένες σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για .NET."
---
## **Επισκόπηση**

Aspose.Slides for .NET σάς επιτρέπει να δημιουργείτε και να μορφοποιείτε κουκκίδες και αριθμημένες λίστες σε παρουσιάσεις PowerPoint και OpenDocument. Ένα στοιχείο λίστας είναι μια παράγραφος της οποίας οι ρυθμίσεις κουκκίδας ελέγχονται μέσω της μορφοποίησης της παραγράφου.

Χρησιμοποιήστε την ιδιότητα [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraph/paragraphformat/) για πρόσβαση στις ρυθμίσεις λίστας σε επίπεδο παραγράφου. Το κύριο σημείο εισόδου είναι το [IParagraphFormat.Bullet](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/bullet/), το οποίο επιστρέφει ένα αντικείμενο [IBulletFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ibulletformat/). Με αυτό το αντικείμενο, μπορείτε να ορίσετε τον τύπο κουκκίδας, το σύμβολο, την εικόνα, το χρώμα, το μέγεθος, το στυλ αρίθμησης και τον αρχικό αριθμό.

Αυτό το άρθρο δείχνει πώς να:

- δημιουργήσετε μια λιστό κουκκίδων με προσαρμοσμένο σύμβολο
- δημιουργήσετε μια εικόνα‑κουκκίδα
- δημιουργήσετε πολυεπίπεδη λίστα ορίζοντας το βάθος της παραγράφου
- δημιουργήσετε μια αριθμημένη λίστα
- ελέγξετε και αλλάξετε τη μορφοποίηση λίστας σε υπάρχουσα παρουσίαση

## **Δημιουργία λίστας κουκκίδων**

Για να δημιουργήσετε μια λιστό κουκκίδων, προσθέστε αντικείμενα [IParagraph](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraph/) σε ένα [ITextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/) και ορίστε την ιδιότητα [IBulletFormat.Type](https://reference.aspose.com/slides/el/net/aspose.slides/ibulletformat/type/) στο [BulletType.Symbol](https://reference.aspose.com/slides/el/net/aspose.slides/bullettype/). Στη συνέχεια μπορείτε να ορίσετε τις ιδιότητες [IBulletFormat.Char](https://reference.aspose.com/slides/el/net/aspose.slides/ibulletformat/char/), [IBulletFormat.Color](https://reference.aspose.com/slides/el/net/aspose.slides/ibulletformat/color/) και [IBulletFormat.Height](https://reference.aspose.com/slides/el/net/aspose.slides/ibulletformat/height/) για να ελέγξετε την εμφάνιση της κουκκίδας.

Ο παρακάτω κώδικας C# δείχνει πώς να δημιουργήσετε μια λιστό κουκκίδων σε μια διαφάνεια:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

static Paragraph CreateParagraph(string text)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    paragraph.ParagraphFormat.Bullet.Char = '*';
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
    paragraph.ParagraphFormat.Bullet.Color.Color = Color.IndianRed;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = text;
    return paragraph;
}

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = CreateParagraph("The first paragraph");
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = CreateParagraph("The second paragraph");
textFrame.Paragraphs.Add(paragraph2);

presentation.Save("symbol_bullets.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![The symbol bullets](symbol_bullets.png)

## **Δημιουργία αριθμημένης λίστας**

Χρησιμοποιήστε αριθμημένες λίστες όταν η σειρά των στοιχείων έχει σημασία. Ορίστε την ιδιότητα [IBulletFormat.Type](https://reference.aspose.com/slides/el/net/aspose.slides/ibulletformat/type/) στο [BulletType.Numbered](https://reference.aspose.com/slides/el/net/aspose.slides/bullettype/). Μπορείτε επίσης να επιλέξετε μορφή αρίθμησης με την ιδιότητα [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/el/net/aspose.slides/ibulletformat/numberedbulletstyle/) ή να ορίσετε την ιδιότητα [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/el/net/aspose.slides/ibulletformat/numberedbulletstartwith/) όταν η λίστα πρέπει να ξεκινά από τιμή διαφορετική από 1.

Ο παρακάτω κώδικας C# εμφανίζει πώς να δημιουργήσετε μια αριθμημένη λίστα σε μια διαφάνεια:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 90, 80);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = new Paragraph();
paragraph1.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph1.Text = "Apple";
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = new Paragraph();
paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph2.Text = "Orange";
textFrame.Paragraphs.Add(paragraph2);

var paragraph3 = new Paragraph();
paragraph3.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph3.Text = "Banana";
textFrame.Paragraphs.Add(paragraph3);

presentation.Save("numbered_bullets.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![The numbered bullets](numbered_bullets.png)

## **Δημιουργία εικόνας‑κουκκίδας**

Aspose.Slides σάς επιτρέπει να αντικαταστήσετε ένα κανονικό σύμβολο κουκκίδας με μια εικόνα. Οι εικόνες‑κουκκίδες λειτουργούν καλύτερα με απλές εικόνες που παραμένουν αναγνώσιμες σε μικρό μέγεθος, όπως εικονίδια ή μικρά διαφανή αρχεία PNG.

{{% alert color="info" %}}
Ιδανικά, εάν σκοπεύετε να αντικαταστήσετε το κανονικό σύμβολο κουκκίδας με μια εικόνα, είναι καλύτερο να επιλέξετε ένα απλό γραφικό με διαφανές φόντο. Τέτοιες εικόνες λειτουργούν καλά ως προσαρμοσμένα σύμβολα κουκκίδας.

Λάβετε υπόψη ότι η εικόνα θα κλιμακωθεί σε πολύ μικρό μέγεθος. Γι’ αυτό τον λόγο συνιστούμε ανεπιφύλακτα την επιλογή μιας εικόνας που παραμένει καθαρή και οπτικά αποτελεσματική όταν χρησιμοποιείται ως κουκκίδα σε λίστα.
{{% /alert %}}

Για να δημιουργήσετε μια εικόνα‑κουκκίδα, προσθέστε μια εικόνα στο [Presentation.Images](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/images/) και αντιστοιχίστε το αντικείμενο εικόνας που επιστρέφεται στην ιδιότητα [IBulletFormat.Picture](https://reference.aspose.com/slides/el/net/aspose.slides/ibulletformat/picture/). Ορίστε την ιδιότητα [IBulletFormat.Type](https://reference.aspose.com/slides/el/net/aspose.slides/ibulletformat/type/) στο [BulletType.Picture](https://reference.aspose.com/slides/el/net/aspose.slides/bullettype/) πριν αναθέσετε την εικόνα.

Ας πούμε ότι έχουμε το αρχείο "image.png":

![A picture for the bullets](picture_for_bullets.png)

Ο παρακάτω κώδικας C# δείχνει πώς να δημιουργήσετε εικόνες‑κουκκίδες σε μια διαφάνεια:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

static Paragraph CreateParagraph(string text, IPPImage image)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
    paragraph.ParagraphFormat.Bullet.Picture.Image = image;
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = text;
    return paragraph;
}

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var imageBytes = File.ReadAllBytes("image.png");
var bulletImage = presentation.Images.AddImage(imageBytes);

var paragraph1 = CreateParagraph("The first paragraph", bulletImage);
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = CreateParagraph("The second paragraph", bulletImage);
textFrame.Paragraphs.Add(paragraph2);

presentation.Save("picture_bullets.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![The picture bullets](picture_bullets.png)

## **Δημιουργία πολυεπίπεδης λίστας**

Χρησιμοποιήστε την ιδιότητα [IParagraphFormat.Depth](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/depth/) για να τοποθετήσετε στοιχεία λίστας σε διαφορετικά επίπεδα. Το επίπεδο 0 είναι το ανώτερο επίπεδο, το επίπεδο 1 είναι ενσωματωμένο κάτω από αυτό, κ.ο.κ.

Ο παρακάτω κώδικας C# δείχνει πώς να δημιουργήσετε μια πολυεπίπεδη λιστό κουκκίδων:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 260, 110);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = new Paragraph();
paragraph1.ParagraphFormat.Depth = 0;
paragraph1.Text = "My text - Depth 0";
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = new Paragraph();
paragraph2.ParagraphFormat.Depth = 1;
paragraph2.Text = "My text - Depth 1";
textFrame.Paragraphs.Add(paragraph2);

var paragraph3 = new Paragraph();
paragraph3.ParagraphFormat.Depth = 2;
paragraph3.Text = "My text - Depth 2";
textFrame.Paragraphs.Add(paragraph3);

var paragraph4 = new Paragraph();
paragraph4.ParagraphFormat.Depth = 3;
paragraph4.Text = "My text - Depth 3";
textFrame.Paragraphs.Add(paragraph4);

presentation.Save("multilevel_bullets.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![The multilevel list](multilevel_list.png)

## **Αλλαγή υπάρχουσας λίστας**

Για να αλλάξετε τη μορφοποίηση λίστας σε υπάρχουσα παρουσίαση, αποκτήστε πρόσβαση στην επιθυμητή παράγραφο και ενημερώστε τις ρυθμίσεις της ιδιότητας [IParagraphFormat.Bullet](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/bullet/). Οι ίδιες ιδιότητες που χρησιμοποιούνται για τη δημιουργία λιστών μπορούν να χρησιμοποιηθούν για την επισκόπηση ή την τροποποίηση λιστών που έχουν φορτωθεί από αρχείο PPT, PPTX ή ODP.

Ο παρακάτω κώδικας C# αλλάζει την πρώτη παράγραφο σε ένα πλαίσιο κειμένου ώστε να χρησιμοποιεί το στυλ αριθμημένης λίστας:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var slide = presentation.Slides[0];
var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

paragraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletRomanUCPeriod;
paragraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 1;
paragraph.ParagraphFormat.MarginLeft = 30;
paragraph.ParagraphFormat.Indent = -20;

presentation.Save("updated_list.pptx", SaveFormat.Pptx);
```

## **FAQ**

### Μπορούν οι λιστές με κουκκίδες και αριθμούς να εξαχθούν σε PDF ή εικόνες;

Ναι. Το Aspose.Slides διατηρεί τη μορφοποίηση της λίστας όταν η μορφή προορισμού υποστηρίζει την αντίστοιχη διάταξη κειμένου και τις δυνατότητες κουκκίδας.

### Μπορώ να επεξεργαστώ τις λίστες σε υπάρχουσες παρουσιάσεις;

Ναι. Φορτώστε την παρουσίαση, αποκτήστε πρόσβαση στην επιθυμητή παράγραφο, ελέγξτε ή ενημερώστε τις ρυθμίσεις της ιδιότητας [IParagraphFormat.Bullet](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/bullet/), και αποθηκεύστε την παρουσίαση.

### Μπορούν οι λίστες να περιέχουν μη‑λατινικό κείμενο;

Ναι. Το κείμενο των στοιχείων λίστας μπορεί να περιέχει χαρακτήρες Unicode, ώστε να μπορείτε να δημιουργείτε λίστες σε πολυγλωσσικές παρουσιάσεις. Βεβαιωθείτε ότι οι γραμματοσειρές που χρησιμοποιούνται στην παρουσίαση υποστηρίζουν τους χαρακτήρες που χρειάζεστε.