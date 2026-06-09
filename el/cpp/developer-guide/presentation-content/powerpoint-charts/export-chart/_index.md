---
title: Εξαγωγή Διαγραμμάτων Παρουσίασης σε С++
linktitle: Εξαγωγή Διαγράμματος
type: docs
weight: 90
url: /el/cpp/export-chart/
keywords:
- διάγραμμα
- διάγραμμα σε εικόνα
- διάγραμμα ως εικόνα
- εξαγωγή εικόνας διαγράμματος
- PowerPoint
- παρουσίαση
- С++
- Aspose.Slides
description: "Μάθετε πώς να εξάγετε τα διαγράμματα παρουσίασης με Aspose.Slides για С++, υποστηρίζοντας τις μορφές PPT και PPTX, και να βελτιστοποιήσετε την αναφορά σε οποιαδήποτε ροή εργασίας."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει να εξάγετε ένα διάγραμμα από μια παρουσίαση ως εικόνα. Αυτό το άρθρο δείχνει πώς να λάβετε μια εικόνα από ένα διάγραμμα και να την αποθηκεύσετε, κάτι που είναι χρήσιμο όταν χρειάζεται να επαναχρησιμοποιήσετε τα γραφικά του διαγράμματος εκτός μιας παρουσίασης PowerPoint.

## **Λήψη εικόνας διαγράμματος**
Το Aspose.Slides for C++ παρέχει υποστήριξη για την εξαγωγή εικόνας συγκεκριμένου διαγράμματος. Παρακάτω δίνεται ένα παράδειγμα.

```cpp
auto presentation = MakeObject<Presentation>(u"test.pptx");

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 0, 0, 500, 500);

auto image = chart->GetImage();
image->Save(u"image.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Συχνές ερωτήσεις**

**Μπορώ να εξάγω ένα διάγραμμα ως διάνυσμα (SVG) αντί για ραστερ εικόνα;**

Ναι. Ένα διάγραμμα είναι ένα σχήμα, και το περιεχόμενό του μπορεί να αποθηκευτεί σε SVG χρησιμοποιώντας τη [μέθοδο αποθήκευσης shape-to-SVG](https://reference.aspose.com/slides/el/cpp/aspose.slides/shape/writeassvg/).

**Πώς μπορώ να ορίσω το ακριβές μέγεθος του εξαγόμενου διαγράμματος σε εικονοστοιχεία;**

Χρησιμοποιήστε τις υπερφορτώσεις image-rendering που σας επιτρέπουν να καθορίσετε το μέγεθος ή την κλίμακα — η βιβλιοθήκη υποστηρίζει την απόδοση αντικειμένων με συγκεκριμένες διαστάσεις/κλίμακα.

**Τι πρέπει να κάνω αν οι γραμματοσειρές στις ετικέτες και τη λεζάντα εμφανίζονται λανθασμένες μετά την εξαγωγή;**

[Φορτώστε τις απαιτούμενες γραμματοσειρές](/slides/el/cpp/custom-font/) μέσω του [FontsLoader](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontsloader/) έτσι ώστε η απόδοση του διαγράμματος να διατηρεί τα μετρικά στοιχεία και την εμφάνιση του κειμένου.

**Συμμορφώνεται η εξαγωγή με το θέμα, τα στυλ και τα εφέ του PowerPoint;**

Ναι. Ο renderer του Aspose.Slides ακολουθεί τη μορφοποίηση της παρουσίασης (θέματα, στυλ, γέμισμα, εφέ), έτσι η εμφάνιση του διαγράμματος διατηρείται.

**Πού μπορώ να βρω διαθέσιμες δυνατότητες απόδοσης/εξαγωγής πέρα από τις εικόνες διαγραμμάτων;**

Δείτε την ενότητα εξαγωγής του [API](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/)/[τεκμηρίωσης](/slides/el/cpp/convert-powerpoint/) για προορισμούς εξόδου ([PDF](/slides/el/cpp/convert-powerpoint-to-pdf/), [SVG](/slides/el/cpp/render-a-slide-as-an-svg-image/), [XPS](/slides/el/cpp/convert-powerpoint-to-xps/), [HTML](/slides/el/cpp/convert-powerpoint-to-html/), κ.λπ.) και τις σχετικές επιλογές απόδοσης.