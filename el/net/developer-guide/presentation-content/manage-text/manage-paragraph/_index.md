---
title: Διαχείριση Παραγράφων Κειμένου PowerPoint σε .NET
linktitle: Διαχείριση Παραγράφου
type: docs
weight: 40
url: /el/net/manage-paragraph/
aliases:
  - /net/paragraph/
  - /net/portion/
keywords:
- προσθήκη κειμένου
- προσθήκη παραγράφου
- διαχείριση κειμένου
- διαχείριση παραγράφου
- διαχείριση κουκίδας
- εσοχή παραγράφου
- εσοχή κρεμασμένη
- κουκίδα παραγράφου
- αριθμημένη λίστα
- λίστα με κουκίδες
- ιδιότητες παραγράφου
- εισαγωγή HTML
- κείμενο σε HTML
- παράγραφος σε HTML
- παράγραφος σε εικόνα
- κείμενο σε εικόνα
- εξαγωγή παραγράφου
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς να δημιουργείτε και να μορφοποιείτε παραγράφους, τμήματα, κουκίδες, αριθμημένες λίστες, εσοχές, περιεχόμενο HTML και εικόνες παραγράφων με το Aspose.Slides για .NET."
---
## **Επισκόπηση**

Το Aspose.Slides για .NET αντιπροσωπεύει το κείμενο ως ιεραρχία πλαισίων κειμένου, παραγράφων και τμημάτων:

* [ITextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/) αντιπροσωπεύει το κοντέινερ κειμένου σε ένα σχήμα και παρέχει πρόσβαση στη συλλογή παραγράφων του.
* [IParagraph](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraph/) αντιπροσωπεύει μια παράγραφο σε ένα πλαίσιο κειμένου και παρέχει πρόσβαση στα τμήματα και στη μορφοποίηση επιπέδου παραγράφου.
* [IPortion](https://reference.aspose.com/slides/el/net/aspose.slides/iportion/) αντιπροσωπεύει ένα τμήμα κειμένου μέσα σε μια παράγραφο. Κάθε τμήμα μπορεί να έχει το δικό του κείμενο και μορφοποίηση επιπέδου χαρακτήρα.

Μια παράγραφος μπορεί επομένως να περιέχει κείμενο με διαφορετικές γραμματοσειρές, χρώματα, μεγέθη και άλλες μορφοποιήσεις χρησιμοποιώντας πολλαπλά τμήματα.

## **Δημιουργία και Μορφοποίηση Παραγράφων**

### **Δημιουργία Παραγράφων με Πολλαπλά Τμήματα**

Τα παρακάτω βήματα δημιουργούν ένα πλαίσιο κειμένου με τρεις παραγράφους, κάθε μία με τρία τμήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
2. Προσπελάστε την αντίστοιχη διαφάνεια μέσω του δείκτη της.
3. Προσθέστε ένα ορθογώνιο [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) στη διαφάνεια.
4. Προσπελάστε το [ITextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/) του σχήματος.
5. Χρησιμοποιήστε την προεπιλεγμένη παράγραφο και προσθέστε δύο ακόμη αντικείμενα [IParagraph](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraph/) στο πλαίσιο κειμένου.
6. Προσθέστε αρκετά αντικείμενα [IPortion](https://reference.aspose.com/slides/el/net/aspose.slides/iportion/) ώστε κάθε παράγραφος να περιέχει τρία τμήματα. Η προεπιλεγμένη παράγραφος περιέχει ήδη ένα κενό τμήμα.
7. Ορίστε το κείμενο για κάθε τμήμα.
8. Εφαρμόστε μορφοποίηση επιπέδου χαρακτήρα μέσω του [IPortion.PortionFormat](https://reference.aspose.com/slides/el/net/aspose.slides/iportion/portionformat/).
9. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτό το παράδειγμα C# υλοποιεί τα βήματα:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);
var textFrame = shape.TextFrame;

var firstParagraph = textFrame.Paragraphs[0];
firstParagraph.Portions.Add(new Portion());
firstParagraph.Portions.Add(new Portion());

var secondParagraph = new Paragraph();
secondParagraph.Portions.Add(new Portion());
secondParagraph.Portions.Add(new Portion());
secondParagraph.Portions.Add(new Portion());
textFrame.Paragraphs.Add(secondParagraph);

var thirdParagraph = new Paragraph();
thirdParagraph.Portions.Add(new Portion());
thirdParagraph.Portions.Add(new Portion());
thirdParagraph.Portions.Add(new Portion());
textFrame.Paragraphs.Add(thirdParagraph);

var paragraphCount = textFrame.Paragraphs.Count;
for (var paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    var paragragaph = textFrame.Paragraphs[paragraphIndex];
    var portionCount = paragragaph.Portions.Count;
    for (var portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        var portion = paragragaph.Portions[portionIndex];
        portion.Text = $"Portion {paragraphIndex + 1}.{portionIndex + 1}";

        if (portionIndex == 0)
        {
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;
            portion.PortionFormat.FontBold = NullableBool.True;
            portion.PortionFormat.FontHeight = 15;
        }
        else if (portionIndex == 1)
        {
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;
            portion.PortionFormat.FontItalic = NullableBool.True;
            portion.PortionFormat.FontHeight = 18;
        }
    }
}

presentation.Save("paragraphs_with_portions.pptx", SaveFormat.Pptx);
```

## **Δημιουργία Λιστών με Κουκίδες και Αριθμούς**

### **Δημιουργία Λίστας με Κουκίδες ή Αριθμημένη Λίστα**

Οι κουκίδες και η αρίθμηση κάνουν τα σχετιζόμενα στοιχεία πιο εύκολα στην ανάγνωση. Στο Aspose.Slides, οι ρυθμίσεις λίστας ορίζονται μέσω του [IBulletFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ibulletformat/).

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
2. Προσπελάστε την αντίστοιχη διαφάνεια μέσω του δείκτη της.
3. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) στη διαφάνεια.
4. Προσπελάστε το [ITextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/) του σχήματος.
5. Αφαιρέστε την προεπιλεγμένη παράγραφο από το πλαίσιο κειμένου.
6. Δημιουργήστε ένα [Paragraph](https://reference.aspose.com/slides/el/net/aspose.slides/paragraph/) για μια κουκίδα συμβόλου.
7. Ορίστε το [IBulletFormat.Type](https://reference.aspose.com/slides/el/net/aspose.slides/ibulletformat/type/) σε [BulletType.Symbol](https://reference.aspose.com/slides/el/net/aspose.slides/bullettype/) και καθορίστε τον χαρακτήρα της κουκίδας.
8. Ορίστε το κείμενο της παραγράφου, την εσοχή, το χρώμα της κουκίδας και το ύψος της κουκίδας.
9. Προσθέστε την παράγραφο στο πλαίσιο κειμένου.
10. Δημιουργήστε δεύτερη παράγραφο και ορίστε το [IBulletFormat.Type](https://reference.aspose.com/slides/el/net/aspose.slides/ibulletformat/type/) σε [BulletType.Numbered](https://reference.aspose.com/slides/el/net/aspose.slides/bullettype/).
11. Ρυθμίστε το στυλ αριθμημένης κουκίδας και προσθέστε την παράγραφο στο πλαίσιο κειμένου.
12. Αποθηκεύστε την παρουσίαση.

Αυτό το παράδειγμα C# δημιουργεί μια κουκίδα συμβόλου και μια αριθμημένη κουκίδα:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var symbolParagraph = new Paragraph { Text = "Welcome to Aspose.Slides" };
symbolParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
symbolParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
symbolParagraph.ParagraphFormat.Indent = 25;
symbolParagraph.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
symbolParagraph.ParagraphFormat.Bullet.Color.Color = Color.Black;
symbolParagraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
symbolParagraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(symbolParagraph);

var numberedParagraph = new Paragraph { Text = "This is a numbered item" };
numberedParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
numberedParagraph.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;
numberedParagraph.ParagraphFormat.Indent = 25;
numberedParagraph.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
numberedParagraph.ParagraphFormat.Bullet.Color.Color = Color.Black;
numberedParagraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
numberedParagraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(numberedParagraph);

presentation.Save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx);
```

### **Χρήση Κουκίδων Εικόνας**

Οι κουκίδες εικόνας σας επιτρέπουν να χρησιμοποιήσετε μια προσαρμοσμένη εικόνα αντί για σύμβολο ή αριθμό.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
2. Προσπελάστε την αντίστοιχη διαφάνεια μέσω του δείκτη της.
3. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) και προσπελάστε το [ITextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/).
4. Αφαιρέστε την προεπιλεγμένη παράγραφο από το πλαίσιο κειμένου.
5. Φορτώστε την εικόνα της κουκίδας και προσθέστε την στη συλλογή εικόνων της παρουσίασης ως [IPPImage](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage/).
6. Δημιουργήστε ένα [Paragraph](https://reference.aspose.com/slides/el/net/aspose.slides/paragraph/) και ορίστε το κείμενό του.
7. Ορίστε το [IBulletFormat.Type](https://reference.aspose.com/slides/el/net/aspose.slides/ibulletformat/type/) σε [BulletType.Picture](https://reference.aspose.com/slides/el/net/aspose.slides/bullettype/).
8. Αντιστοιχίστε την εικόνα μέσω του [IBulletFormat.Picture](https://reference.aspose.com/slides/el/net/aspose.slides/ibulletformat/picture/) και ορίστε το ύψος της κουκίδας.
9. Προσθέστε την παράγραφο στο πλαίσιο κειμένου.
10. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτό το παράδειγμα C# δημιουργεί μια κουκίδα εικόνας:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var bulletImage = Images.FromFile("bullets.png");
var presentationImage = presentation.Images.AddImage(bulletImage);

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph = new Paragraph { Text = "Welcome to Aspose.Slides" };
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = presentationImage;
paragraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(paragraph);

presentation.Save("picture_bullet.pptx", SaveFormat.Pptx);
presentation.Save("picture_bullet.ppt", SaveFormat.Ppt);
```

### **Δημιουργία Πολυεπίπεδης Λίστας**

Ορίστε το [IParagraphFormat.Depth](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/depth/) για να τοποθετήσετε παραγράφους σε διαφορετικά επίπεδα μιας λίστας. Το ανώτερο επίπεδο έχει βάθος `0`.

1. Δημιουργήστε ένα [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) και προσπελάστε μια διαφάνεια.
2. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) και διαγράψτε την προεπιλεγμένη παράγραφο από το πλαίσιο κειμένου του.
3. Δημιουργήστε τέσσερις παραγράφους και ρυθμίστε τα σύμβολα κουκίδας τους.
4. Ορίστε τις τιμές [IParagraphFormat.Depth](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/depth/) σε `0`, `1`, `2` και `3`.
5. Προσθέστε τις παραγράφους στο πλαίσιο κειμένου και αποθηκεύστε την παρουσίαση.

Αυτό το παράδειγμα C# δημιουργεί μια λίστα με κουκίδες τεσσάρων επιπέδων:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "Content" };
firstParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
firstParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.Depth = 0;

var secondParagraph = new Paragraph { Text = "Second level" };
secondParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
secondParagraph.ParagraphFormat.Bullet.Char = '-';
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.Depth = 1;

var thirdParagraph = new Paragraph { Text = "Third level" };
thirdParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
thirdParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
thirdParagraph.ParagraphFormat.Depth = 2;

var fourthParagraph = new Paragraph { Text = "Fourth level" };
fourthParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
fourthParagraph.ParagraphFormat.Bullet.Char = '-';
fourthParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
fourthParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
fourthParagraph.ParagraphFormat.Depth = 3;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);
textFrame.Paragraphs.Add(thirdParagraph);
textFrame.Paragraphs.Add(fourthParagraph);

presentation.Save("multilevel_list.pptx", SaveFormat.Pptx);
```

### **Έναρξη Αριθμημένων Στοιχείων Λίστας με Προσαρμοσμένες Τιμές**

Χρησιμοποιήστε το [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/el/net/aspose.slides/ibulletformat/numberedbulletstartwith/) για να ορίσετε τον αρχικό αριθμό που εμφανίζεται για μια αριθμημένη παράγραφο.

1. Δημιουργήστε ένα [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) και προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) σε μια διαφάνεια.
2. Καθαρίστε την προεπιλεγμένη παράγραφο από το πλαίσιο κειμένου του σχήματος.
3. Δημιουργήστε τρεις αριθμημένες παραγράφους.
4. Ορίστε το [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/el/net/aspose.slides/ibulletformat/numberedbulletstartwith/) σε `2`, `3` και `7` για τις αντίστοιχες παραγράφους.
5. Προσθέστε τις παραγράφους στο πλαίσιο κειμένου και αποθηκεύστε την παρουσίαση.

Αυτό το παράδειγμα C# αντιστοιχίζει προσαρμοσμένο αρχικό αριθμό σε κάθε παράγραφο:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "Start at 2" };
firstParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
firstParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 2;
textFrame.Paragraphs.Add(firstParagraph);

var secondParagraph = new Paragraph { Text = "Start at 3" };
secondParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
secondParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 3;
textFrame.Paragraphs.Add(secondParagraph);

var thirdParagraph = new Paragraph { Text = "Start at 7" };
thirdParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
thirdParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 7;
textFrame.Paragraphs.Add(thirdParagraph);

presentation.Save("custom_numbered_list.pptx", SaveFormat.Pptx);
```

## **Έλεγχος Διατάξεων Παραγράφων και Ιδιοτήτων Τέλους**

### **Ορισμός Εσοχής Πρώτης Γραμμής**

Χρησιμοποιήστε την ιδιότητα [IParagraphFormat.Indent](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/indent/) για να ελέγξετε την εσοχή της πρώτης γραμμής μιας παραγράφου. Αυτή η ιδιότητα μετακινεί μόνο την πρώτη γραμμή σε σχέση με το αριστερό περιθώριο της παραγράφου. Θετική τιμή μετακινεί την πρώτη γραμμή δεξιά, ενώ οι υπόλοιπες γραμμές παραμένουν ευθυγραμμισμένες με το σώμα της παραγράφου.

Χρησιμοποιήστε το [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/marginleft/) όταν χρειάζεται να μετακινήσετε ολόκληρη την παράγραφο. Χρησιμοποιήστε το [IParagraphFormat.Indent](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/indent/) όταν θέλετε να μετακινήσετε μόνο την πρώτη γραμμή.

Το παρακάτω παράδειγμα δημιουργεί πολλές παραγράφους και εφαρμόζει διαφορετικές τιμές [IParagraphFormat.Indent](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/indent/) για να δείξει πώς η εσοχή πρώτης γραμμής επηρεάζει τη διάταξη της παραγράφου.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
2. Προσπελάστε τη στοχευόμενη διαφάνεια.
3. Προσθέστε ένα ορθογώνιο [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) στη διαφάνεια.
4. Προσπελάστε το [ITextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/) του σχήματος και αφαιρέστε την προεπιλεγμένη παράγραφο.
5. Δημιουργήστε πολλές παραγράφους και ορίστε διαφορετικές τιμές [Indent](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/indent/) για αυτές.
6. Προσθέστε τις παραγράφους στο πλαίσιο κειμένου.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας δείχνει πώς να ορίσετε εσοχή παραγράφου:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "No first-line indent. Wrapped lines start at the same position as the first line." };
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.MarginLeft = 20;
firstParagraph.ParagraphFormat.Indent = 0;

var secondParagraph = new Paragraph { Text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.MarginLeft = 20;
secondParagraph.ParagraphFormat.Indent = 20;

var thirdParagraph = new Paragraph { Text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see." };
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
thirdParagraph.ParagraphFormat.MarginLeft = 20;
thirdParagraph.ParagraphFormat.Indent = 40;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);
textFrame.Paragraphs.Add(thirdParagraph);

presentation.Save("paragraph_indent.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Η εσοχή πρώτης γραμμής των παραγράφων](first_line_indent.png)

### **Ορισμός Επιστολής Εσοχής**

Η επιστολή εσοχής είναι μια διάταξη παραγράφου στην οποία η πρώτη γραμμή ξεκινά πιο αριστερά από τις υπόλοιπες γραμμές. Στο Aspose.Slides, δημιουργείτε αυτό το εφέ με την ιδιότητα [IParagraphFormat.Indent](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/indent/). Ορίστε το `Indent` σε αρνητική τιμή για να μετακινήσετε την πρώτη γραμμή αριστερά σε σχέση με το σώμα της παραγράφου.

Στην πράξη, το [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/marginleft/) ορίζει τη θέση αριστερά του σώματος της παραγράφου, και το [IParagraphFormat.Indent](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/indent/) ορίζει τη θέση της πρώτης γραμμής σε σχέση με αυτό το περιθώριο. Για να δημιουργήσετε επιστολή εσοχής, ορίστε μια θετική τιμή `MarginLeft` και μια αρνητική τιμή `Indent`.

Αυτή η μορφοποίηση είναι χρήσιμη για βιβλιογραφίες, παραπομπές, όρους γλωσσολογίας και άλλες παραγράφους όπου οι γραμμές πρέπει να ευθυγραμμίζονται κάτω από το σώμα της παραγράφου αντί κάτω από τον πρώτο χαρακτήρα της πρώτης γραμμής.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
2. Προσπελάστε τη στοχευόμενη διαφάνεια.
3. Προσθέστε ένα ορθογώνιο [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) στη διαφάνεια.
4. Προσπελάστε το [ITextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/) του σχήματος και αφαιρέστε την προεπιλεγμένη παράγραφο.
5. Δημιουργήστε παραγράφους και ορίστε μια θετική τιμή [MarginLeft](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/marginleft/) για κάθε παράγραφο.
6. Ορίστε μια αρνητική τιμή [Indent](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/indent/) για να δημιουργήσετε το εφέ της επιστολής εσοχής.
7. Προσθέστε τις παραγράφους στο πλαίσιο κειμένου.
8. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας δείχνει πώς να ορίσετε επιστολή εσοχής για μια παράγραφο:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body." };
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.MarginLeft = 40;
firstParagraph.ParagraphFormat.Indent = -20;

var secondParagraph = new Paragraph { Text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.MarginLeft = 60;
secondParagraph.ParagraphFormat.Indent = -30;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);

presentation.Save("hanging_indent.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Η επιστολή εσοχής των παραγράφων](hanging_indent.png)

### **Ορισμός Ιδιοτήτων Τερματισμού Παραγράφου**

Η ιδιότητα [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraph/endparagraphportionformat/) ελέγχει τη μορφοποίηση του χαρακτήρα τέλους παραγράφου. Το παρακάτω παράδειγμα αντιστοιχεί μέγεθος γραμματοσειράς και λατινική γραμματοσειρά στο τέλος της δεύτερης παραγράφου:

1. Φορτώστε μια [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) και προσπελάστε μια διαφάνεια.
2. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) και διαγράψτε την προεπιλεγμένη παράγραφο.
3. Δημιουργήστε δύο παραγράφους και προσθέστε τμήματα κειμένου σε αυτές.
4. Δημιουργήστε ένα [PortionFormat](https://reference.aspose.com/slides/el/net/aspose.slides/portionformat/) για το τέλος της δεύτερης παραγράφου.
5. Ορίστε το [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/el/net/aspose.slides/ibaseportionformat/fontheight/) και το [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/el/net/aspose.slides/ibaseportionformat/latinfont/).
6. Αντιστοιχίστε τη μορφοποίηση στο [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraph/endparagraphportionformat/) και αποθηκεύστε την παρουσίαση.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Test.pptx");
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph();
firstParagraph.Portions.Add(new Portion("Sample text"));

var secondParagraph = new Paragraph();
secondParagraph.Portions.Add(new Portion("Sample text 2"));

var endParagraphFormat = new PortionFormat();
endParagraphFormat.FontHeight = 48;
endParagraphFormat.LatinFont = new FontData("Times New Roman");
secondParagraph.EndParagraphPortionFormat = endParagraphFormat;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);

presentation.Save("end_paragraph_format.pptx", SaveFormat.Pptx);
```

## **Εισαγωγή και Εξαγωγή Περιεχομένου Παραγράφων**

### **Εισαγωγή Κειμένου HTML σε Παραγράφους**

Χρησιμοποιήστε το [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/el/net/aspose.slides/paragraphcollection/addfromhtml/) για να μετατρέψετε HTML markup σε παραγράφους και τμήματα σε ένα πλαίσιο κειμένου.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
2. Προσπελάστε μια διαφάνεια και προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/).
3. Προσπελάστε το [ITextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/) του σχήματος και αφαιρέστε την προεπιλεγμένη παράγραφο.
4. Διαβάστε το πηγαίο αρχείο HTML.
5. Πέρασμα της αλυσίδας HTML στο [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/el/net/aspose.slides/paragraphcollection/addfromhtml/).
6. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτό το παράδειγμα C# εισάγει HTML σε ένα πλαίσιο κειμένου:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shapeWidth = presentation.SlideSize.Size.Width - 20;
var shapeHeight = presentation.SlideSize.Size.Height - 20;
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
shape.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Paragraphs.Clear();

using var reader = new StreamReader("file.html");
var html = reader.ReadToEnd();
shape.TextFrame.Paragraphs.AddFromHtml(html);

presentation.Save("html_text.pptx", SaveFormat.Pptx);
```

### **Εξαγωγή Κειμένου Παραγράφου σε HTML**

Χρησιμοποιήστε το [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/el/net/aspose.slides/paragraphcollection/exporttohtml/) για να εξάγετε ένα επιλεγμένο εύρος παραγράφων ως HTML.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) και φορτώστε την επιθυμητή παρουσίαση.
2. Προσπελάστε τη διαφάνεια και βρείτε το [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) που περιέχει το κείμενο.
3. Προσπελάστε το [ITextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/).
4. Καλέστε το [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/el/net/aspose.slides/paragraphcollection/exporttohtml/) με το δείκτη της αρχικής παραγράφου και τον αριθμό των παραγράφων προς εξαγωγή.
5. Γράψτε την επιστρεφόμενη αλυσίδα HTML σε αρχείο.

Αυτό το παράδειγμα C# εξάγει όλες τις παραγράφους από το πρώτο πλαίσιο κειμένου:

```csharp
using System;
using System.IO;
using System.Text;
using Aspose.Slides;

using var presentation = new Presentation("ExportingHTMLText.pptx");
var shape = presentation.Slides[0].Shapes[0];

if (shape is IAutoShape textShape && textShape.TextFrame != null)
{
    var paragraphs = textShape.TextFrame.Paragraphs;
    var html = paragraphs.ExportToHtml(0, paragraphs.Count, null);
    using var writer = new StreamWriter("paragraphs.html", false, Encoding.UTF8);
    writer.Write(html);
}
else
{
    Console.WriteLine("The first shape is not a text shape.");
}
```

### **Απόδοση Παραγράφου ως Εικόνα**

Το [IParagraph.GetImage](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraph/getimage/) αποδίδει άμεσα μια μεμονωμένη παράγραφο και επιστρέφει ένα [IImage](https://reference.aspose.com/slides/el/net/aspose.slides/iimage/). Αποθηκεύστε το αποτέλεσμα σε αρχείο ή ρεύμα με το [IImage.Save](https://reference.aspose.com/slides/el/net/aspose.slides/iimage/save/). Δεν χρειάζεται να αποδώσετε το περιέχον σχήμα ή να περικόψετε ένα bitmap χειροκίνητα.

Το [IParagraph.GetImage](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraph/getimage/) μπορεί να επιστρέψει `null` εάν η παράγραφος δεν μπορεί να βρεθεί στη γονική της συλλογή, δεν έχει έγκυρα όρια απόδοσης ή δεν μπορεί να αποδοθεί. Ελέγξτε το αποτέλεσμα πριν το αποθηκεύσετε και απελευθερώστε την εικόνα μετά τη χρήση.

#### **Απόδοση Παραγράφου στην Προεπιλεγμένη Κλίμακα**

Ας υποθέσουμε ότι έχουμε ένα αρχείο παρουσίασης με όνομα sample.pptx με μία διαφάνεια, όπου το πρώτο σχήμα είναι ένα πλαίσιο κειμένου που περιέχει τρεις παραγράφους.

![Το πλαίσιο κειμένου με τρεις παραγράφους](paragraph_to_image_input.png)

Το παρακάτω παράδειγμα αποδίδει τη δεύτερη παράγραφο σε ένα κανονικό πλαίσιο κειμένου στην προεπιλεγμένη κλίμακα και αποθηκεύει την επιστρεφόμενη εικόνα σε μορφή PNG. Η δήλωση `using` εξασφαλίζει ότι η εικόνα απελευθερώνεται σωστά.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var shape = presentation.Slides[0].Shapes[0];
if (shape is IAutoShape textShape && 
    textShape.TextFrame != null && 
    textShape.TextFrame.Paragraphs.Count > 1)
{
    var paragraph = textShape.TextFrame.Paragraphs[1];
    using var paragraphImage = paragraph.GetImage();

    if (paragraphImage != null)
    {
        paragraphImage.Save("paragraph.png", ImageFormat.Png);
    }
    else
    {
        Console.WriteLine("The paragraph could not be rendered.");
    }
}
else
{
    Console.WriteLine("The expected text shape or paragraph was not found.");
}
```

Το αποτέλεσμα:

![Η εικόνα της παραγράφου](paragraph_to_image_output.png)

#### **Απόδοση Παραγράφου σε Κελί Πίνακα με Κλιμάκωση**

Χρησιμοποιήστε την υπερφόρτωση του [IParagraph.GetImage](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraph/getimage/) που δέχεται τις παραμέτρους `float scaleX` και `float scaleY` για να ορίσετε τους οριζόντιους και κάθετους συντελεστές κλίμακας. Το παρακάτω παράδειγμα δημιουργεί έναν πίνακα, αποδίδει την παράγραφο στο πρώτο κελί του με διπλάσιο πλάτος και ύψος από το προεπιλεγμένο, και αποθηκεύει το αποτέλεσμα σε εικόνα PNG.

```csharp
using System;
using Aspose.Slides;

var scaleX = 2f;
var scaleY = 2f;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var table = slide.Shapes.AddTable(50, 50, new[] { 300d }, new[] { 80d });
var paragraph = table[0, 0].TextFrame.Paragraphs[0];
paragraph.Text = "Text in a table cell";

using var paragraphImage = paragraph.GetImage(scaleX, scaleY);
if (paragraphImage != null)
{
    paragraphImage.Save("table_paragraph.png", ImageFormat.Png);
}
else
{
    Console.WriteLine("The paragraph could not be rendered.");
}
```

Συντελεστής κλίμακας `1` διατηρεί αυτόν τον άξονα στο προεπιλεγμένο μέγεθος pixel. Για παράδειγμα, `2` για και τους δύο συντελεστές παράγει εικόνα του οποίου το πλάτος και το ύψος είναι περίπου διπλάσια από τις προεπιλεγμένες διαστάσεις, με αποτέλεσμα τέσσερις φορές περισσότερα pixel. Μεγαλύτεροι συντελεστές συνήθως παράγουν πιο ευκρινές κείμενο για μεγέθυνση ή υψηλή ανάλυση, αλλά αυξάνουν επίσης τη χρήση μνήμης και το μέγεθος του αρχείου. Συντελεστές κάτω από `1` δημιουργούν μικρότερες εικόνες με λιγότερες λεπτομέρειες. Χρησιμοποιήστε ίσους συντελεστές για να διατηρήσετε την αναλογία διαστάσεων της παραγράφου· διαφορετικοί οριζόντιοι και κάθετοι συντελεστές τεντώσουν το αποτέλεσμα ανεξάρτητα.

Η απόδοση ολόκληρου σχήματος με το [IShape.GetImage](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/getimage/) παραμένει χρήσιμη όταν η έξοδος πρέπει να περιλαμβάνει το γέμισμα, το περίγραμμα ή άλλο οπτικό πλαίσιο του σχήματος. Για εικόνα μόνο της παραγράφου, χρησιμοποιήστε το [IParagraph.GetImage](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraph/getimage/).

## **Συχνές Ερωτήσεις**

**Μπορώ να απενεργοποιήσω εντελώς την αναδίπλωση κειμένου μέσα σε ένα πλαίσιο κειμένου;**

Ναι. Ορίστε το [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/el/net/aspose.slides/itextframeformat/wraptext/) ώστε να μηδενίσετε την αναδίπλωση, ώστε οι γραμμές να μην σπάσουν στις άκρες του πλαισίου κειμένου.

**Πώς μπορώ να λάβω τα ακριβή όρια μιας συγκεκριμένης παραγράφου στο slide;**

Χρησιμοποιήστε το [IParagraph.GetRect](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraph/getrect/) για να ανακτήσετε το ορθογώνιο περιβάλλον της παραγράφου. Το [IPortion.GetRect](https://reference.aspose.com/slides/el/net/aspose.slides/iportion/getrect/) παρέχει τα όρια ενός μεμονωμένου τμήματος.

**Πού ελέγχεται η ευθυγράμμιση παραγράφου (αριστερά, δεξιά, κέντρο ή πλήρης στοίχιση);**

Το [IParagraphFormat.Alignment](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/alignment/) είναι ρύθμιση επιπέδου παραγράφου και εφαρμόζεται σε ολόκληρη την παράγραφο ανεξαρτήτως μορφοποίησης μεμονωμένων τμημάτων.

**Μπορώ να ορίσω τη γλώσσα διόρθωσης για μέρος μιας παραγράφου;**

Ναι. Ορίστε το [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/el/net/aspose.slides/ibaseportionformat/languageid/) για μεμονωμένα τμήματα, ώστε μια παράγραφος να μπορεί να περιέχει κείμενο σε πολλαπλές γλώσσες.