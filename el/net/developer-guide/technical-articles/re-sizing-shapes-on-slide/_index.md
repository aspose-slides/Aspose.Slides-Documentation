---
title: Αλλαγή Μεγέθους Σχημάτων σε Διαφάνειες Παρουσίασης σε .NET
type: docs
weight: 130
url: /el/net/resizing-shapes-on-slide/
aliases:
  - /net/re-sizing-shapes-on-slide/
  - /el/net/re-sizing-shapes-on-slide/
keywords:
- αλλαγή μεγέθους σχήματος
- μεγέθυνση σχήματος
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Κάντε εύκολη αλλαγή μεγέθους των σχημάτων σε διαφάνειες PowerPoint και OpenDocument με Aspose.Slides για .NET—αυτοματοποιήστε τις προσαρμογές διάταξης διαφανειών και αυξήστε την παραγωγικότητα."
---
## **Επισκόπηση**

Όταν αλλάζετε το μέγεθος της διαφάνειας μιας παρουσίασης, μπορεί επίσης να χρειαστεί να αλλάξετε το μέγεθος και τη θέση των σχημάτων της ώστε να ταιριάζουν με τις νέες διαστάσεις. Αυτό το άρθρο δείχνει πώς να κλιμακώσετε τα σχήματα χειροκίνητα και πώς να διαχειριστείτε τους πίνακες στις διαφάνειες, τα master και τα layout.

## **Αλλαγή Μεγέθους Σχημάτων**

Για να διατηρήσετε τη σχετική θέση και το μέγεθος κάθε σχήματος, πολλαπλασιάστε τις οριζόντιες συντεταγμένες και το πλάτος του με το λόγο του νέου πλάτους της διαφάνειας προς το αρχικό πλάτος. Εφαρμόστε τον αντίστοιχο λόγο ύψους στις κάθετες συντεταγμένες και το ύψος του.

Το πρώτο παράδειγμα φορτώνει μια παρουσίαση των οποίων οι διαφάνειες δεν περιέχουν πίνακες, αλλάζει το μέγεθος της διαφάνειας σε A4 και αποθηκεύει το αποτέλεσμα. Χρησιμοποιεί [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) με [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/net/aspose.slides/slidesizescaletype/) ώστε η επακόλουθη βρόχος να ελέγχει την κλιμάκωση. Οι λόγοι είναι χωρίς μονάδα· οι θέσεις και οι διαστάσεις των σχημάτων μετρώνται σε points. Διαφορετικοί λόγοι πλάτους και ύψους μπορούν να παραμορφώσουν τα σχήματα, και η αλλαγή των διαστάσεων ενός σχήματος δεν κλιμακώνει τα μεγέθη γραμματοσειράς.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Υπολογίστε ανεξάρτητους οριζόντιους και κάθετους συντελεστές κλιμάκωσης.
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        shape.Width *= widthRatio;
        shape.Height *= heightRatio;
        shape.X *= widthRatio;
        shape.Y *= heightRatio;
    }
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert color="info" title="Note" %}}
Οι πίνακες απαιτούν ξεχωριστή διαχείριση: κλιμακώστε το πλάτος των στηλών τους και το ύψος των σειρών αντί να ορίσετε το συνολικό πλάτος και ύψος του πίνακα. Το ύψος των σειρών μπορεί να παραμείνει μεγαλύτερο από το ζητούμενο εάν το περιεχόμενο των κελιών απαιτεί περισσότερη θέση.
{{% /alert %}}

Το δεύτερο παράδειγμα υποστηρίζει πίνακες και επεξεργάζεται σχήματα στα master και τα layout, καθώς και σε μεμονωμένες διαφάνειες, πριν αποθηκεύσει την αλλαγμένη παρουσίαση. Ο βοηθός του επεξεργάζεται κάθε [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) κλιμακώντας το [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) και το [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/). Στη συνέχεια κλιμακώνει τη θέση του πίνακα χωρίς να κλιμακώνει χωριστά τις συνολικές διαστάσεις του.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Υπολογίστε ανεξάρτητους οριζόντιους και κάθετους συντελεστές κλιμάκωσης.
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

// Αλλάξτε το μέγεθος των σχημάτων που ορίζονται στα master και στα layout, καθώς και σε μεμονωμένες διαφάνειες.
foreach (var master in presentation.Masters)
{
    ResizeShapes(master.Shapes, widthRatio, heightRatio);

    foreach (var layoutSlide in master.LayoutSlides)
    {
        ResizeShapes(layoutSlide.Shapes, widthRatio, heightRatio);
    }
}

foreach (var slide in presentation.Slides)
{
    ResizeShapes(slide.Shapes, widthRatio, heightRatio);
}

presentation.Save("output.pptx", SaveFormat.Pptx);

static void ResizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio)
{
    foreach (var shape in shapes)
    {
        if (shape is ITable table)
        {
            // Οι διαστάσεις του πίνακα ελέγχονται από το πλάτος των στηλών και το ύψος των σειρών.
            foreach (var column in table.Columns)
            {
                column.Width *= widthRatio;
            }

            foreach (var row in table.Rows)
            {
                row.MinimalHeight *= heightRatio;
            }
        }
        else
        {
            shape.Width *= widthRatio;
            shape.Height *= heightRatio;
        }

        shape.X *= widthRatio;
        shape.Y *= heightRatio;
    }
}
```

## **Συχνές Ερωτήσεις**

**Γιατί τα σχήματα παραμορφώνονται ή περικόπτονται μετά την αλλαγή μεγέθους μιας διαφάνειας;**

Αν αλλάξετε το μέγεθος της διαφάνειας χωρίς να κλιμακώσετε τα σχήματα, αυτά διατηρούν τις αρχικές τους θέσεις και διαστάσεις και μπορεί να εκτείνονται εκτός της διαφάνειας. Η κλιμάκωση του πλάτους και του ύψους με διαφορετικούς λόγους μπορεί επίσης να παραμορφώσει τα σχήματα.

**Λειτουργεί ο παρεχόμενος κώδικας για όλους τους τύπους σχημάτων;**

Το πρώτο παράδειγμα αλλάζει τα όρια των σχημάτων άμεσα και προορίζεται για διαφάνειες χωρίς πίνακες. Το δεύτερο παράδειγμα διαχειρίζεται τους πίνακες ξεχωριστά. Ελέγξτε τη διαρρύθμιση του αποτελέσματος, ιδιαίτερα το κείμενο και τους πίνακες, επειδή αυτά τα παραδείγματα δεν κλιμακώνουν τα μεγέθη γραμματοσειρών και το περιεχόμενο του πίνακα μπορεί να περιορίσει το ύψος των σειρών.

**Πώς αλλάζω το μέγεθος των πινάκων όταν αλλάζω το μέγεθος μιας διαφάνειας;**

Κλιμακώστε το πλάτος των στηλών με τον λόγο πλάτους και το ελάχιστο ύψος των σειρών με τον λόγο ύψους, έπειτα κλιμακώστε τη θέση του πίνακα, όπως φαίνεται στο δεύτερο παράδειγμα.

**Θα λειτουργήσει αυτή η αλλαγή μεγέθους για master διαφάνειες και layout διαφάνειες;**

Ναί. Το δεύτερο παράδειγμα διατρέχει τις [Presentation.Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) και κάθε [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/layoutslides/) του master και εφαρμόζει την ίδια λογική αλλαγής μεγέθους στα σχήματά τους.

**Μπορώ να αλλάξω τον προσανατολισμό μιας διαφάνειας (κάθετη/οριζόντια) μαζί με την αλλαγή μεγέθους;**

Ναί. Ορίστε το [SlideSize.Orientation](https://reference.aspose.com/slides/net/aspose.slides/slidesize/orientation/) μετά την αλλαγή του μεγέθους της διαφάνειας και πριν από την ανάγνωση των διαστάσεων-στόχου, ώστε οι συντελεστές κλιμάκωσης να αντανακλούν τον τελικό προσανατολισμό.

**Υπάρχει όριο στο μέγεθος διαφάνειας που μπορώ να ορίσω;**

Μπορείτε να ορίσετε προσαρμοσμένες διαστάσεις διαφάνειας με το [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/). Οι υποστηριζόμενες διαστάσεις εξαρτώνται επίσης από τη μορφή της παρουσίασης και την εφαρμογή που χρησιμοποιείται για το άνοιγμα του αρχείου.

**Πώς μπορώ να αποτρέψω τα σχήματα με σταθερό λόγο διαστάσεων να παραμορφώνονται;**

Χρησιμοποιήστε τον ίδιο συντελεστή κλιμάκωσης για το πλάτος και το ύψος. Για να ταιριάξετε την αρχική διάταξη μέσα στις νέες διαστάσεις της διαφάνειας, χρησιμοποιήστε το μικρότερο από τους λόγους πλάτους και ύψους για και τις δύο διαστάσεις και τις θέσεις. Αυτό διατηρεί τις αναλογίες αλλά μπορεί να αφήσει αχρησιμοποίητο χώρο κατά το ένα άκρο.