---
title: Αλλαγή Μεγέθους και Προσανατολισμού Σελίδας Σημειώσεων σε .NET
linktitle: Μέγεθος Σελίδας Σημειώσεων
type: docs
weight: 10
url: /el/net/notes-size/
keywords:
- μέγεθος σελίδας σημειώσεων
- προσανατολισμός σημειώσεων
- σημειώσεις τοπίο
- σημειώσεις πορτραίτο
- μέγεθος φυλλαδίου
- PowerPoint
- παρουσίαση
- PPT
- PPTX
- C#
- Aspose.Slides
description: "Διαβάστε και αλλάξτε τις διαστάσεις της σελίδας σημειώσεων στο Aspose.Slides για .NET, αλλάγοντας τον προσανατολισμό, επαληθεύστε τα αποθηκευμένα μεγέθη και εξάγετε σημειώσεις ή φυλλάδια σε PDF και εικόνες."
---
## **Επισκόπηση**

Χρησιμοποιήστε [Presentation.NotesSize](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/notessize/) για να αποκτήσετε πρόσβαση στις ρυθμίσεις σελίδας σημειώσεων της παρουσίασης. Επιστρέφει ένα αντικείμενο [INotesSize](https://reference.aspose.com/slides/el/net/aspose.slides/inotessize/) του οποίου η ιδιότητα [Size](https://reference.aspose.com/slides/el/net/aspose.slides/inotessize/size/) είναι εγγράψιμη. Παρόλο που το αντικείμενο ρυθμίσεων είναι μόνο για ανάγνωση, μπορείτε να αναθέσετε νέες διαστάσεις στην ιδιότητα size.

Το πλάτος και το ύψος καθορίζονται σε **points**, με 72 points ανά ίντσα. Για παράδειγμα, 900 × 600 points είναι 12,5 × 8⅓ ίντσες. Αυτές οι ρυθμίσεις εφαρμόζονται στην παρουσίαση, όχι σε σημειώσεις ενός μεμονωμένου διαφάνειας.

| Ρύθμιση | Σκοπός |
| --- | --- |
| [Presentation.NotesSize](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/notessize/) | Ελέγχει τις διαστάσεις της σελίδας σημειώσεων και τις διαστάσεις της σελίδας που χρησιμοποιούνται για εξαγωγή φυλλαδίου. |
| [Presentation.SlideSize](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/slidesize/) | Ελέγχει τις κανονικές διαστάσεις των διαφανειών της παρουσίασης μέσω του [ISlideSize](https://reference.aspose.com/slides/el/net/aspose.slides/islidesize/). |

Η αλλαγή της μιας ρύθμισης δεν αλλάζει αυτόματα την άλλη. Η αλλαγή του προσανατολισμού της σελίδας σημειώσεων επίσης δεν περιστρέφει τις κανονικές διαφάνειες. Δείτε το [Slide Size](/slides/el/net/slide-size/) για να αλλάξετε το μέγεθος των κανονικών διαφανειών.

Τα παραδείγματα παρακάτω χρησιμοποιούν ένα υπάρχον `sample.pptx`. Για τα παραδείγματα εξαγωγής, χρησιμοποιήστε μια παρουσίαση με τουλάχιστον μία διαφάνεια που περιέχει σημειώσεις ομιλητή. Κάθε παράδειγμα μπορεί να εκτελεστεί ανεξάρτητα.

## **Διαβάστε το Μέγεθος και τον Προσανατολισμό της Σελίδας Σημειώσεων**

Διαβάστε το πλάτος και το ύψος και συγκρίνετε τα για να προσδιορίσετε τον προσανατολισμό: μια πιο πλατιά σελίδα είναι τοπίο, μια πιο ψηλή σελίδα είναι πορτραίτο, και ίσες διαστάσεις περιγράφουν τετράγωνη σελίδα. Αυτό το παράδειγμα εκτυπώνει τις πραγματικές διαστάσεις σε points, χωρίς να υποθέτει ένα τυπικό μέγεθος χαρτιού.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var size = presentation.NotesSize.Size;
var orientation = "Square";

if (size.Width > size.Height)
    orientation = "Landscape";
else if (size.Width < size.Height)
    orientation = "Portrait";

Console.WriteLine($"Notes page: {size.Width} x {size.Height} points");
Console.WriteLine($"Orientation: {orientation}");
```

## **Αλλαγή σε Τοπίο Χωρίς Αλλαγή του Μεγέθους Χαρτιού**

Για να αλλάξετε μόνο τον προσανατολισμό, ανταλλάξτε το υπάρχον πλάτος και ύψος. Αυτό διατηρεί τα μήκη και των δύο πλευρών, συμπεριλαμβανομένων αυτών ενός προσαρμοσμένου μεγέθους χαρτιού. Η παρακάτω συνθήκη αποτρέπει το να μετατραπεί μια ήδη τοπίο σελίδα ξανά σε πορτραίτο και αφήνει μια τετράγωνη σελίδα αμετάβλητη.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var size = presentation.NotesSize.Size;

if (size.Width < size.Height)
    presentation.NotesSize.Size = new SizeF(size.Height, size.Width);

presentation.Save("landscape-notes.pptx", SaveFormat.Pptx);
```

Για προσανατολισμό πορτραίτου, χρησιμοποιήστε την ίδια εκχώρηση όταν `size.Width > size.Height`. Μην αντικαθιστάτε διαστάσεις A4 ή Letter εκτός εάν θέλετε επίσης να αλλάξετε το μέγεθος χαρτιού.

## **Ορίστε και Επαληθεύστε Προσαρμοσμένο Μέγεθος Σελίδας Σημειώσεων**

Αναθέστε και τις δύο διαστάσεις μαζί, στη συνέχεια χρησιμοποιήστε το [Presentation.Save](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/save/) για να γράψετε την παρουσίαση. Αυτό το παράδειγμα ορίζει μια τοπίο σελίδα 900 × 600 points, την αποθηκεύει ως PPTX και ανοίγει ξανά το αποθηκευμένο αρχείο για να ελέγξει τις διατηρημένες τιμές. Η σύγκριση επιτρέπει ανοχή 0,01 point για τιμές κινητής υποδιαστολής· δεν αποτελεί εγγύηση ακριβείας για κάθε μορφή αρχείου.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var expectedSize = new SizeF(900, 600);
presentation.NotesSize.Size = expectedSize;
presentation.Save("custom-notes.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("custom-notes.pptx");
var actualSize = reopened.NotesSize.Size;
var widthMatches = Math.Abs(actualSize.Width - expectedSize.Width) < 0.01f;
var heightMatches = Math.Abs(actualSize.Height - expectedSize.Height) < 0.01f;
var preserved = widthMatches && heightMatches;

Console.WriteLine($"Stored notes page: {actualSize.Width} x {actualSize.Height} points");
Console.WriteLine($"Size preserved: {preserved}");
```

Το αναμενόμενο αποτέλεσμα είναι `900 x 600 points` και `Size preserved: True`. Ο έλεγχος μιας νεάνοιχτης παρουσίασης επαληθεύει το αποθηκευμένο αρχείο, αντί μόνο των ρυθμίσεων στη μνήμη.

## **Εξαγωγή Σημειώσεων και Φυλλαδίων**

Οι διαστάσεις της σελίδας ορίζουν τον διαθέσιμο χώρο για διατάξεις σημειώσεων ή φυλλαδίων. Δεν ενεργοποιούν αυτές τις διατάξεις από μόνες τους: ρυθμίστε επίσης τις επιλογές εξαγωγής. Η εξαγωγή κανονικών διαφανειών συνεχίζει να χρησιμοποιεί τις διαστάσεις της διαφάνειας.

### **Εξαγωγή Σημειώσεων σε PDF και PNG**

Αναθέστε το [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/notescommentslayoutingoptions/) στο [PdfOptions.SlidesLayoutOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/pdfoptions/slideslayoutoptions/) για να συμπεριλάβετε τις σημειώσεις στο PDF. Αυτό το παράδειγμα επίσης αποδίδει την πρώτη διαφάνεια με σημειώσεις σε PNG χρησιμοποιώντας το [Slide.GetImage](https://reference.aspose.com/slides/el/net/aspose.slides/slide/getimage/) και το [RenderingOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/renderingoptions/).

Η λειτουργία [BottomTruncated](https://reference.aspose.com/slides/el/net/aspose.slides.export/notespositions/) διατηρεί τις σημειώσεις σε μία σελίδα· οι σημειώσεις που δεν χωρούν μπορούν να περικοπούν. Το PDF χρησιμοποιεί σελίδες 900 × 600 points. Στην κλίμακα εικόνας 1 × 1 που χρησιμοποιείται παρακάτω, το PNG είναι 900 × 600 pixels. Τα points περιγράφουν τη γεωμετρία της σελίδας· τα pixels περιγράφουν την έξοδο raster, των οποίων οι διαστάσεις εξαρτώνται επίσης από την κλίμακα απόδοσης.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
presentation.NotesSize.Size = new SizeF(900, 600);

var layout = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomTruncated
};

var pdfOptions = new PdfOptions { SlidesLayoutOptions = layout };
presentation.Save("notes.pdf", SaveFormat.Pdf, pdfOptions);

var renderingOptions = new RenderingOptions { SlidesLayoutOptions = layout };
using var image = presentation.Slides[0].GetImage(renderingOptions, 1, 1);
image.Save("first-slide-notes.png", ImageFormat.Png);
```

Για εξαγωγή PDF με μακρές σημειώσεις, το [BottomFull](https://reference.aspose.com/slides/el/net/aspose.slides.export/notespositions/) επιτρέπει πρόσθετες σελίδες ανάλογα με τις ανάγκες. Μην χρησιμοποιείτε αυτή τη λειτουργία με την κλήση εικόνας μιας διαφάνειας παραπάνω, η οποία δεν τη υποστηρίζει. Μετά την αλλαγή μεγέθους, ελέγξτε το αποτέλεσμα για περικομμένες σημειώσεις και τη θέση των υφιστάμενων αντικειμένων notes-master· η αλλαγή μόνο των διαστάσεων της σελίδας δεν πρέπει να θεωρείται εγγύηση ότι όλο το περιεχόμενο θα χωράει. Δείτε το [Convert PowerPoint to PDF with Notes](/slides/el/net/convert-powerpoint-to-pdf-with-notes/) για περισσότερα σχετικά με την εξαγωγή σημειώσεων.

### **Εξαγωγή Φυλλαδίων σε PDF**

Χρησιμοποιήστε το [HandoutLayoutingOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/handoutlayoutingoptions/) για πολλαπλές μικρογραφίες διαφανειών σε μία σελίδα. Το παρακάτω παράδειγμα ορίζει μια σελίδα 900 × 600 points και χρησιμοποιεί το [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/el/net/aspose.slides.export/handouttype/) για να τοποθετήσει έως τέσσερις διαφάνειες ανά σελίδα. Η οριζόντια προεπιλογή ελέγχει τη σειρά των διαφανών· ο προσανατολισμός της σελίδας προκύπτει από το πλάτος και το ύψος της.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
presentation.NotesSize.Size = new SizeF(900, 600);

var layout = new HandoutLayoutingOptions
{
    Handout = HandoutType.Handouts4Horizontal
};

var pdfOptions = new PdfOptions { SlidesLayoutOptions = layout };
presentation.Save("handouts.pdf", SaveFormat.Pdf, pdfOptions);
```

Η αλλαγή του μεγέθους της σελίδας αλλάζει τον διαθέσιμο χώρο για το πλέγμα του φυλλαδίου χωρίς να αλλάζει τις διαστάσεις των αρχικών διαφανειών. Για εικόνες φυλλαδίου, χρησιμοποιήστε το [Presentation.GetImages](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/getimages/) με τη διάταξη φυλλαδίου, αντί για τη μέθοδο εικόνας μιας μεμονωμένης διαφάνειας. Στο Aspose.Slides, η απόδοση φυλλαδίου επιπέδου παρουσίασης χρησιμοποιεί τις διαστάσεις της σελίδας σημειώσεων, ενώ η κλήση εικόνας μεμονωμένης διαφάνειας δεν παράγει τη σελίδα φυλλαδίου. Δείτε το [Handout Mode](/slides/el/net/convert-powerpoint-in-handout-mode/) για επιλογές διάταξης.

## **Μέγεθος Σελίδας σε Προγράμματα Προβολής, Εξαγωγή και Εκτύπωση**

Διατηρήστε το αποθηκευμένο μέγεθος παρουσίασης, το εξαγόμενο μέγεθος σελίδας και το εκτυπωμένο μέγεθος χαρτιού ξεχωριστά:

- **Προβολείς παρουσίασης:** Ένας προβολέας μπορεί να εμφανίσει ή να εκτυπώσει τις σημειώσεις χρησιμοποιώντας τους δικούς του κανόνες διάταξης. Εάν άλλη εφαρμογή αποθηκεύσει το αρχείο, ανοίξτε το ξανά και ελέγξτε τις διαστάσεις· η μετατροπή μορφής εκείνης της εφαρμογής μπορεί να τις ομαλοποιήσει.
- **Μορφές εξαγωγής:** Τα παραδείγματα PDF σημειώσεων και φυλλαδίου παραπάνω χρησιμοποιούν τις ρυθμισμένες διαστάσεις σελίδας. Οι εικόνες raster χρησιμοποιούν ακέραιες διαστάσεις pixel και μια κλίμακα απόδοσης, έτσι οι κλασματικές τιμές points μπορούν να στρογγυλοποιηθούν στην έξοδο εικόνας. Η εξαγωγή κανονικών διαφανειών δεν εφαρμόζει το μέγεθος σελίδας σημειώσεων.
- **Οδηγοί εκτυπωτών:** Η επιλογή χαρτιού, η αυτόματη περιστροφή και οι ρυθμίσεις προσαρμογής στη σελίδα μπορούν να αλλάξουν το φυσικό αποτέλεσμα χωρίς να αλλάξουν τις διαστάσεις που αποθηκεύονται στην παρουσίαση ή το PDF. Για συγκεκριμένο μέγεθος χαρτιού, ταιριάξτε τις ρυθμίσεις του εκτυπωτή και ελέγξτε την προεπισκόπηση εκτύπωσης.

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Can I set the notes size for just one slide?**

Το μέγεθος σελίδας σημειώσεων είναι ρύθμιση σε επίπεδο παρουσίασης. Οι μεμονωμένες διαφάνειες μπορούν να έχουν διαφορετικό περιεχόμενο σημειώσεων, αλλά αυτή η ιδιότητα δεν παρέχει ξεχωριστό μέγεθος σελίδας για κάθε διαφάνεια.

**Why did changing notes orientation not change my slides?**

Οι σελίδες σημειώσεων και οι κανονικές διαφάνειες έχουν ανεξάρτητες διαστάσεις. Χρησιμοποιήστε τις ρυθμίσεις μεγέθους κανονικών διαφανειών όταν θέλετε να αλλάξετε το μέγεθος των ίδιων των διαφανειών.

**Why does my saved or printed result have a different size?**

Πρώτα ανοίξτε ξανά την αποθηκευμένη παρουσίαση και συγκρίνετε τις διαστάσεις των σημειώσεων. Εάν αυτές άλλαξαν, ελέγξτε αν η αποθήκευση ή η μετατροπή του αρχείου σε άλλη εφαρμογή άλλαξε τις ρυθμίσεις σελίδας. Εάν δεν άλλαξαν, ελέγξτε τη διάταξη εξαγωγής, την κλίμακα εικόνας, τις ρυθμίσεις προβολέα και την επιλογή χαρτιού του εκτυπωτή.