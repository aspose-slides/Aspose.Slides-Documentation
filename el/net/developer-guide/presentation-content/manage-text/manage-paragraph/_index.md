---
title: Διαχείριση παραγράφων κειμένου PowerPoint σε .NET
linktitle: Διαχείριση παραγράφου
type: docs
weight: 40
url: /el/net/manage-paragraph/
aliases:
  - /net/paragraph/
  - /net/portion/
  - /net/παράγραφος/
  - /net/τμήμα/
keywords:
- προσθήκη κειμένου
- προσθήκη παραγράφου
- διαχείριση κειμένου
- διαχείριση παραγράφου
- διαχείριση κουκίδας
- εσοχή παραγράφου
- κρεμαστή εσοχή
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
description: "Μάθετε πώς να δημιουργείτε και να μορφοποιείτε παραγράφους, τμήματα, κουκίδες, αριθμημένες λίστες, εσοχές, περιεχόμενο HTML και εικόνες παραγράφου με το Aspose.Slides για .NET."
---
## **Επισκόπηση**

Το Aspose.Slides για .NET αντιπροσωπεύει το κείμενο ως ιεραρχία πλαισίων κειμένου, παραγράφων και τμημάτων:

* [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) αντιπροσωπεύει το κοντέινερ κειμένου σε ένα σχήμα και παρέχει πρόσβαση στη συλλογή παραγράφων του.
* [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) αντιπροσωπεύει μία παράγραφο σε ένα πλαίσιο κειμένου και παρέχει πρόσβαση στα τμήματα και στη μορφοποίηση επιπέδου παραγράφου.
* [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) αντιπροσωπεύει μια ακολουθία κειμένου μέσα σε μία παράγραφο. Κάθε τμήμα μπορεί να έχει τη δική του μορφοποίηση χαρακτήρα.

Έτσι, μία παράγραφος μπορεί να περιέχει κείμενο με διαφορετικές γραμματοσειρές, χρώματα, μεγέθη και άλλες μορφοποιήσεις, χρησιμοποιώντας πολλαπλά τμήματα.

## **Δημιουργία και μορφοποίηση παραγράφων**

Δημιουργήστε παραγράφους σε ένα πλαίσιο κειμένου σχήματος και χρησιμοποιήστε τμήματα για τη μορφοποίηση μεμονωμένων ακολουθιών κειμένου. Αυτή η ενότητα δείχνει πώς να συνδυάσετε πολλαπλά τμήματα σε κάθε παράγραφο και να εφαρμόσετε διαφορετικά χρώματα, μεγέθη γραμματοσειράς και στυλ.

### **Δημιουργία παραγράφων με πολλαπλά τμήματα**

Το ακόλουθο παράδειγμα C# δημιουργεί τρεις παραγράφους, καθεμία με τρία τμήματα κειμένου στη συλλογή [IParagraph.Portions](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/portions/). Επαναχρησιμοποιεί την προεπιλεγμένη παράγραφο και το κενό τμήμα της, στη συνέχεια προσθέτει τις υπόλοιπες παραγράφους και τμήματα. Η μορφοποίηση εφαρμόζεται μέσω [IPortion.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportion/portionformat/): το πρώτο τμήμα σε κάθε παράγραφο είναι κόκκινο, έντονο και 15 σημεία· το δεύτερο είναι μπλε, πλάγιο και 18 σημεία. Το τρίτο τμήμα διατηρεί την προεπιλεγμένη του μορφοποίηση:

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

## **Δημιουργία λιστών με κουκίδες και αριθμητικές**

Οργανώστε το κείμενο παραγράφου σε λίστες με σύμβολα, αριθμούς ή προσαρμοσμένες εικόνες. Τα παραδείγματα σε αυτήν την ενότητα καλύπτουν τη μορφοποίηση κουκίδων, τις πολυεπίπεδες λίστες και τις προσαρμοσμένες αρχικές τιμές.

### **Δημιουργία λίστας με κουκίδες ή αριθμητική**

Οι κουκίδες και η αρίθμηση κάνουν τα σχετικά στοιχεία πιο εύκολα στην ανάγνωση. Στο Aspose.Slides, οι ρυθμίσεις λίστας ορίζονται μέσω [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/).

Αυτό το παράδειγμα C# προσθέτει μια κουκίδα συμβόλου και ένα αριθμημένο στοιχείο στο ίδιο πλαίσιο κειμένου. Το [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) επιλέγει τον τύπο της κουκίδας, ενώ το [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/) παρέχει το σύμβολο και το [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstyle/) επιλέγει το στυλ αρίθμησης. Και τα δύο στοιχεία χρησιμοποιούν μαύρες κουκίδες με ύψος 100 % και εσοχή παραγράφου 25 σημεία:

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

### **Χρήση εικόνας ως κουκίδα**

Οι εικόνες ως κουκίδες σας επιτρέπουν να χρησιμοποιήσετε μια προσαρμοσμένη εικόνα αντί για σύμβολο ή αριθμό.

Αυτό το παράδειγμα C# προσθέτει μια εικόνα στη συλλογή εικόνων της παρουσίασης ως [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) και την χρησιμοποιεί ως κουκίδα παραγράφου. Ορίζει το [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) σε εικόνα κουκίδας και αντιστοιχεί την εικόνα μέσω του [IBulletFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/picture/). Το [IBulletFormat.Height](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/height/) ορίζεται σε 100 % για να προσαρμόσει το μέγεθος της κουκίδας σχετικά με το κείμενο της παραγράφου:

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

### **Δημιουργία πολυεπίπεδης λίστας**

Ορίστε το [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) για να τοποθετήσετε παραγράφους σε διαφορετικά επίπεδα λίστας. Το ανώτατο επίπεδο έχει βάθος `0`.

Αυτό το παράδειγμα C# αντιστοιχίζει τιμές [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) από 0 έως 3 σε τέσσερις παραγράφους, δημιουργώντας ιεραρχία μέσα σε ένα πλαίσιο κειμένου. Κάθε παράγραφος χρησιμοποιεί μια κουκίδα συμβόλου, με το [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/) να εναλλάσσεται μεταξύ στρογγυλής κουκίδας και εντουμενίου για τη διάκριση των γειτονικών επιπέδων:

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

### **Έναρξη αριθμημένων στοιχείων λίστας με προσαρμοσμένες τιμές**

Χρησιμοποιήστε το [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) για να ορίσετε τον αρχικό αριθμό που εμφανίζεται για μια αριθμημένη παράγραφο.

Αυτό το παράδειγμα C# ορίζει το [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) σε αρίθμηση για τρεις παραγράφους και ορίζει τιμές [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) 2, 3 και 7. Η αρχική τιμή ρυθμίζεται ξεχωριστά για κάθε παράγραφο, επιτρέποντας την παράλειψη αριθμών:

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

## **Έλεγχος διάταξης παραγράφων και ιδιοτήτων τέλους**

Ρυθμίστε τα περιθώρια και τις εσοχές της παραγράφου για να ελέγξετε τη θέση της πρώτης γραμμής και των έμμεσων γραμμών. Μπορείτε επίσης να μορφοποιήσετε το σημάδι τέλους παραγράφου ξεχωριστά από τα ορατά τμήματα κειμένου.

### **Ορισμός εσοχής πρώτης γραμμής**

Χρησιμοποιήστε την ιδιότητα [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) για να ελέγξετε την εσοχή της πρώτης γραμμής μιας παραγράφου. Αυτή η ιδιότητα μετακινεί μόνο την πρώτη γραμμή σε σχέση με το αριστερό περιθώριο της παραγράφου. Μία θετική τιμή μετατοπίζει την πρώτη γραμμή προς τα δεξιά, ενώ οι υπόλοιπες γραμμές παραμένουν ευθυγραμμισμένες με το σώμα της παραγράφου.

Χρησιμοποιήστε το [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) όταν χρειάζεται να μετακινήσετε ολόκληρη την παράγραφο. Χρησιμοποιήστε το [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) όταν χρειάζεται να μετακινήσετε μόνο την πρώτη γραμμή.

Το παρακάτω παράδειγμα δίνει τρεις παραγράφους το ίδιο [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) 20 σημείων και τιμές [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) 0, 20 και 40 σημεία. Οι πρώτες γραμμές αρχίζουν σε αυξανόμενες αποστάσεις, ενώ οι έμμεσες γραμμές διατηρούν το ίδιο αριστερό περιθώριο:

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

### **Ορισμός κρεμαστής εσοχής**

Μια κρεμαστή εσοχή είναι διάταξη παραγράφου όπου η πρώτη γραμμή ξεκινά προς τα αριστερά των υπολοίπων γραμμών. Στο Aspose.Slides, δημιουργείτε αυτό το εφέ με την ιδιότητα [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/). Ορίστε το `Indent` σε αρνητική τιμή για να μετακινήσετε την πρώτη γραμμή αριστερά σε σχέση με το σώμα της παραγράφου.

Στην πράξη, το [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) ορίζει τη θέση αριστερά του σώματος της παραγράφου, και το [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) ορίζει τη θέση της πρώτης γραμμής ως προς αυτό το περιθώριο. Για να δημιουργήσετε κρεμαστή εσοχή, ορίστε μια θετική τιμή στο `MarginLeft` και μια αρνητική τιμή στο `Indent`.

Η μορφοποίηση αυτή είναι χρήσιμη για βιβλιογραφίες, παραπομπές, γλωσσάρια και άλλες παραγράφους όπου οι έμμεσες γραμμές πρέπει να ευθυγραμμιστούν κάτω από το σώμα της παραγράφου αντί κάτω από τον πρώτο χαρακτήρα της πρώτης γραμμής.

Το παρακάτω παράδειγμα C# συνδυάζει τιμές [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) 40 και 60 σημείων με τιμές [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) –20 και –30 σημεία. Σε κάθε παράγραφο, η πρώτη γραμμή ξεκινά προς τα αριστερά των έμμεσων γραμμών· η δεύτερη παράγραφος έχει βαθύτερη κρεμαστή εσοχή:

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

![Η κρεμαστή εσοχή των παραγράφων](hanging_indent.png)

### **Ορισμός ιδιοτήτων τερματικού τμήματος παραγράφου**

Η ιδιότητα [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/endparagraphportionformat/) ελέγχει τη μορφοποίηση του σημείου τέλους παραγράφου. Το παρακάτω παράδειγμα δημιουργεί ένα [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) με το [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) ορισμένο σε 48 σημεία και το [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/latinfont/) σε Times New Roman. Αναθέτει αυτή τη μορφή στο σημείο τέλους της δεύτερης παραγράφου, αφήνοντας τα ορατά τμήματα κειμένου αμετάβλητα:

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

## **Καταμέτρηση αποτυπωμένων γραμμών**

Για κανόνες παραγράφων που επηρεάζουν την αυτόματη αναδίπλωση και την στίξη στο τέλος των γραμμών, δείτε [Control Line Breaking](/slides/el/net/text-formatting/#control-line-breaking) και [Control Hanging Punctuation](/slides/el/net/text-formatting/#control-hanging-punctuation).

Χρησιμοποιήστε το [IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/) για να μετρήσετε τις γραμμές που καταλαμβάνει μια παράγραφος μετά τη διάταξη του κειμένου, συμπεριλαμβανομένης της αυτόματης αναδίπλωσης. Αυτό είναι χρήσιμο όταν ελέγχετε το μήκος και τη διάταξη του κειμένου σε πρότυπα παρουσίασης.

Μία παράγραφος είναι ένα στοιχείο στη [ITextFrame.Paragraphs](https://reference.aspose.com/slides/net/aspose.slides/itextframe/paragraphs/), και μπορεί να καταλάβει πολλές αποτυπωμένες γραμμές. Ένα ρητό line break μέσα σε μια παράγραφο δημιουργεί νέα γραμμή χωρίς να δημιουργήσει νέα παράγραφο. Η αυτόματη αναδίπλωση δημιουργεί γραμμές βάσει του διαθέσιμου πλάτους χωρίς να εισάγει ρητές αλλαγές γραμμής στο κείμενο. Επομένως, η μέτρηση παραγράφων ή χαρακτήρων αλλαγής γραμμής δεν δίνει τον πραγματικό αριθμό αποτυπωμένων γραμμών.

Το παρακάτω παράδειγμα δημιουργεί ένα σχήμα κειμένου, μετρά τις γραμμές του, στενώνει το σχήμα και στη συνέχεια αντικαθιστά το κείμενο με ένα σύντομο κείμενο. Το παράδειγμα ενεργοποιεί το [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) και απενεργοποιεί το [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) ώστε το πλάτος του σχήματος να ελέγχει την αναδίπλωση χωρίς αυτόματη σμίκρυνση του κειμένου ή αλλαγή μεγέθους του σχήματος. Κάθε μέτρηση χρησιμοποιεί το [IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/). Οι διαστάσεις του σχήματος είναι σε σημεία. Τέλος, το παράδειγμα προσθέτει μια ακόμη παράγραφο και αθροίζει τις μετρήσεις γραμμών σε όλο το πλαίσιο κειμένου.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;

var paragraph = textFrame.Paragraphs[0];
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 20;
paragraph.Text = "This text demonstrates how automatic wrapping changes the number of rendered lines.";
Console.WriteLine($"Original width: {paragraph.GetLinesCount()}");

shape.Width = 150;
Console.WriteLine($"Narrower shape: {paragraph.GetLinesCount()}");

paragraph.Text = "Short text.";
Console.WriteLine($"Shorter text: {paragraph.GetLinesCount()}");

var secondParagraph = new Paragraph { Text = "Another paragraph." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 20;
textFrame.Paragraphs.Add(secondParagraph);

var totalLineCount = 0;
foreach (var currentParagraph in textFrame.Paragraphs)
{
    totalLineCount += currentParagraph.GetLinesCount();
}
Console.WriteLine($"Total lines in the text frame: {totalLineCount}");
```

Με αυτό το κείμενο και αυτές τις διαστάσεις, η στένωση του σχήματος αυξάνει τον αριθμό γραμμών, ενώ η αντικατάσταση του κειμένου με το σύντομο κείμενο τον μειώνει. Οι ακριβείς μετρήσεις μπορεί να διαφέρουν ανάλογα με τη διαθέσιμη γραμματοσειρά και την αντικατάστασή της, το μέγεθος γραμματοσειράς, τα περιθώρια, την εσοχή, την αναδίπλωση και τις ρυθμίσεις αυτόματης προσαρμογής. Χρησιμοποιήστε τις γραμματοσειρές και τις ρυθμίσεις διάταξης που προορίζονται για το περιβάλλον στόχο όταν ελέγχετε ένα πρότυπο.

Ο μόνος αριθμός γραμμών δεν καθορίζει αν το κείμενο υπερβαίνει το κοντέινερ του. Σημαντικό είναι επίσης το διαθέσιμο ύψος, τα ύψη των γραμμών, η απόσταση μεταξύ παραγράφων και γραμμών, και η συμπεριφορά της αυτόματης προσαρμογής· ακόμη και μία μόνο γραμμή μπορεί να υπερβεί το διαθέσιμο πλάτος όταν η αναδίπλωση είναι απενεργοποιημένη.

## **Εισαγωγή και εξαγωγή περιεχομένου παραγράφων**

Χρησιμοποιήστε HTML για να εισάγετε κείμενο σε μια παρουσίαση ή να εξάγετε υπάρχουσες παραγράφους για χρήση εκτός αυτής. Αυτή η ενότητα δείχνει επίσης πώς να αποδίδετε μεμονωμένες παραγράφους ως εικόνες, συμπεριλαμβανομένων των παραγράφων σε κελιά πινάκων.

### **Εισαγωγή κειμένου HTML σε παραγράφους**

Χρησιμοποιήστε το [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/) για να μετατρέψετε σήμανση HTML σε παραγράφους και τμήματα σε ένα πλαίσιο κειμένου.

Αυτό το παράδειγμα C# διαβάζει HTML από αρχείο και περνά τη σήμανση στο [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/). Καθαρίζει την προεπιλεγμένη παράγραφο του πλαισίου κειμένου ώστε το πλαίσιο να περιέχει μόνο το εισαγόμενο περιεχόμενο. Το ορθογώνιο σχήμα αφήνει περιθώριο 10 σημείων σε κάθε πλευρά της διαφάνειας:

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

### **Εξαγωγή κειμένου παραγράφου σε HTML**

Χρησιμοποιήστε το [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/exporttohtml/) για να εξάγετε ένα επιλεγμένο εύρος παραγράφων ως HTML. Όταν επαναχρησιμοποιείτε το κείμενο της παρουσίασης σε ιστότοπο, ίσως θέλετε να διατηρήσετε τη τοπική έμφαση χωρίς να μεταφέρετε τη γραμματοσειρά, το μέγεθος ή τα στυλ του πλαισίου κειμένου. Ορίστε το [TextToHtmlConversionOptions.TextInheritanceLimit](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/textinheritancelimit/) για να ελέγξετε πόσο μακριά ακολουθεί ο εξαγωγέας την κληρονομικότητα μορφοποίησης.

Κατεβάστε [the sample presentation](text-inheritance.pptx) και τοποθετήστε το στον φάκελο εργασίας της εφαρμογής. Η πρώτη διαφάνειά του περιέχει ένα σχήμα κειμένου με το κείμενο «Inherited text; explicit red 18pt». Η είσοδος χρησιμοποιεί σκόπιμα αρκετά επίπεδα μορφοποίησης:

- Το προεπιλεγμένο στυλ κειμένου της παρουσίασης παρέχει Calibri και μέγεθος 28 pt.
- Το στυλ κειμένου πρώτου επιπέδου του πλαισίου κειμένου παρέχει μπλε κείμενο και πλάγια γραφή.
- Η παράγραφος ορίζει ρητά έντονο κείμενο.
- Το δεύτερο τμήμα, «explicit red 18pt», ορίζει ρητά κόκκινο κείμενο και μέγεθος 18 pt.

Το παρακάτω πλήρες παράδειγμα εξάγει τις ίδιες παραγράφους τρεις φορές. Περνά το [TextToHtmlConversionOptions](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/) στη μέθοδο εξαγωγής και γράφει κάθε αποτέλεσμα σε ξεχωριστό αρχείο HTML UTF‑8:

```csharp
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("text-inheritance.pptx");
var textShape = (IAutoShape)presentation.Slides[0].Shapes[0];

var paragraphs = textShape.TextFrame.Paragraphs;
var modes = new[] { TextInheritanceLimit.All, TextInheritanceLimit.TextBox, TextInheritanceLimit.ParagraphOnly };

foreach (var mode in modes)
{
    var options = new TextToHtmlConversionOptions { TextInheritanceLimit = mode };

    var html = paragraphs.ExportToHtml(0, paragraphs.Count, options);
    File.WriteAllText($"{mode}.html", html, Encoding.UTF8);
}
```

Το παραγόμενο HTML περιλαμβάνει το ακόλουθο CSS για το πρώτο τμήμα, «Inherited text; ». Ο παρακάτω πίνακας εμφανίζει τις σχετικές δηλώσεις· άλλες παραγόμενες ιδιότητες παραλείπονται για σαφήνεια.

| Αποτέλεσμα | Σχετικό CSS για το πρώτο τμήμα | Εμφάνιση |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Μπλε, έντονο, πλάγιο κείμενο σε 28 pt με Calibri, εάν αυτή η γραμματοσειρά είναι διαθέσιμη. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Μπλε, έντονο, πλάγιο κείμενο· η περιβάλλουσα σελίδα ή ο περιηγητής παρέχει την οικογένεια γραμματοσειράς και το μέγεθος. |
| `ParagraphOnly.html` | `font-weight:bold` | Έντονο κείμενο· η περιβάλλουσα σελίδα ή ο περιηγητής παρέχει την οικογένεια γραμματοσειράς, το μέγεθος, το χρώμα και το πλάγιο στυλ. |

Το δεύτερο τμήμα διατηρεί `color:#ff0000`, `font-size:18pt` και `font-weight:bold` και στα τρία αποτελέσματα. Διατηρεί επίσης πλάγια γραφή στα `All` και `TextBox`, αλλά όχι στο `ParagraphOnly`. Ο περιορισμός κληρονομικότητας έτσι δεν αφαιρεί τη μορφοποίηση που έχει οριστεί ρητά σε μια παράγραφο ή τμήμα.

Ανοίξτε τα αρχεία στον ίδιο περιηγητή για να τα συγκρίνετε. Στις δύο περιορισμένες λειτουργίες, οι παραλειπόμενες ιδιότητες CSS επιλύονται από τα στυλ της σελίδας προορισμού ή από τις προεπιλογές του περιηγητή, οπότε η τελική εμφάνιση εξαρτάται από το πού χρησιμοποιείται το HTML.

### **Απόδοση παραγράφου ως εικόνα**

Το [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) αποδίδει μια μεμονωμένη παράγραφο απευθείας και επιστρέφει ένα [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/). Αποθηκεύστε το αποτέλεσμα σε αρχείο ή ροή με το [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/). Δεν χρειάζεται να αποδώσετε το σχήμα που το περιέχει ή να περικόψετε το bitmap χειροκίνητα.

Το [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) μπορεί να επιστρέψει `null` εάν η παράγραφος δεν βρεθεί στη γονική της συλλογή, δεν έχει έγκυρα όρια απόδοσης ή δεν μπορεί να αποδοθεί. Ελέγξτε το αποτέλεσμα πριν το αποθηκεύσετε και αποδεσμεύστε την εικόνα μετά τη χρήση.

#### **Απόδοση παραγράφου στην προεπιλεγμένη κλίμακα**

Το παράδειγμα χρησιμοποιεί μια παρουσίαση με μία διαφάνεια της οποίας το πρώτο σχήμα είναι ένα πλαίσιο κειμένου που περιέχει τρεις παραγράφους.

![Το πλαίσιο κειμένου με τρεις παραγράφους](paragraph_to_image_input.png)

Το παρακάτω παράδειγμα επιλέγει τη δεύτερη παράγραφο με δείκτη 1 και καλεί το [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) χωρίς παραμέτρους κλίμακας. Ελέγχει ότι το σχήμα περιέχει την απαιτούμενη παράγραφο και ότι η απόδοση επιστρέφει εικόνα πριν καλέσει το [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) για αποθήκευση σε μορφή PNG. Η δήλωση `using` αποδεσμεύει την εικόνα μετά τη χρήση.

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

#### **Απόδοση παραγράφου σε κελί πίνακα με κλιμάκωση**

Χρησιμοποιήστε την υπερφόρτωση του [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) που δέχεται παραμέτρους `float scaleX` και `float scaleY` για να ορίσετε τους οριζόντιους και κάθετους συντελεστές κλίμακας. Το παρακάτω παράδειγμα δημιουργεί έναν πίνακα, αποδίδει την παράγραφο στο πρώτο του κελί με διπλάσιο προεπιλεγμένο πλάτος και ύψος, και αποθηκεύει το αποτέλεσμα ως εικόνα PNG.

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

Ένας συντελεστής κλίμακας `1` διατηρεί αυτόν τον άξονα στο προεπιλεγμένο μέγεθός του σε εικονοστοιχεία. Για παράδειγμα, `2` και για τους δύο παράγοντες παράγει εικόνα του οποίου το πλάτος και το ύψος είναι περίπου διπλάσιο από τις προεπιλεγμένες διαστάσεις, με αποτέλεσμα τέσσερις φορές περισσότερα pixel. Μεγαλύτεροι συντελεστές συνήθως δίνουν πιο οξύ κείμενο για ζουμ ή εκτυπώσεις υψηλής ανάλυσης, αλλά αυξάνουν και τη χρήση μνήμης και το μέγεθος του αρχείου. Συντελεστές κάτω από `1` παράγουν μικρότερες εικόνες με λιγότερη λεπτομέρεια. Χρησιμοποιήστε ίσους συντελεστές για να διατηρήσετε την αναλογία διαστάσεων της παραγράφου· διαφορετικοί οριζόντιοι και κάθετοι συντελεστές τεντώνουν την έξοδο ανεξάρτητα.

Η απόδοση ολόκληρου σχήματος με το [IShape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/ishape/getimage/) παραμένει χρήσιμη όταν η έξοδος πρέπει να περιλαμβάνει το γέμισμα, το περίγραμμα ή άλλο οπτικό περιεχόμενο του σχήματος. Για εικόνα μόνο παραγράφου, χρησιμοποιήστε το [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/).

## **Συχνές ερωτήσεις**

**Μπορώ να απενεργοποιήσω εντελώς την αναδίπλωση γραμμών μέσα σε ένα πλαίσιο κειμένου;**

Ναι. Ορίστε το [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) ώστε να απενεργοποιήσετε την αναδίπλωση ώστε οι γραμμές να μη σπάζουν στις άκρες του πλαισίου κειμένου.

**Πώς μπορώ να λάβω τα ακριβή όρια εντός διαφάνειας μιας συγκεκριμένης παραγράφου;**

Χρησιμοποιήστε το [IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getrect/) για να ανακτήσετε το ορθογώνιο που περιβάλλει την παράγραφο. Το [IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/getrect/) παρέχει τα όρια ενός μεμονωμένου τμήματος.

**Πού ελέγχεται η στοίχιση παραγράφου (αριστερά, δεξιά, κέντρο ή πλήρης στοίχιση);**

Το [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) είναι ρύθμιση επιπέδου παραγράφου και εφαρμόζεται σε ολόκληρη την παράγραφο ανεξάρτητα από τη μορφοποίηση των επιμέρους τμημάτων.

Για κάθετη στοίχιση τμημάτων διαφορετικών μεγεθών γραμματοσειράς μέσα σε κάθε γραμμή, δείτε [Align Fonts Within a Line](/slides/el/net/text-formatting/#align-fonts-within-a-line).

**Μπορώ να ορίσω τη γλώσσα διόρθωσης για μέρος μιας παραγράφου;**

Ναι. Ορίστε το [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) για μεμονωμένα τμήματα, ώστε μια παράγραφος να μπορεί να περιέχει κείμενο σε πολλές γλώσσες.