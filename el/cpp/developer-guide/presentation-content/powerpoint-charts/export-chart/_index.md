---
title: Εξαγωγή Διαγραμμάτων Παρουσίασης σε C++
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
- C++
- Aspose.Slides
description: "Μάθετε πώς να εξάγετε διαγράμματα παρουσίασης με το Aspose.Slides για C++, υποστηρίζοντας μορφές PPT και PPTX, και να βελτιστοποιήσετε την αναφορά σε οποιαδήποτε ροή εργασίας."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει να εξάγετε ένα γράφημα από μια παρουσίαση ως εικόνα. Αυτό το άρθρο δείχνει πώς να λάβετε μια εικόνα από ένα γράφημα και να την αποθηκεύσετε, κάτι που είναι χρήσιμο όταν χρειάζεται να επαναχρησιμοποιήσετε τα γραφικά στοιχεία του γραφήματος εκτός μιας παρουσίασης PowerPoint.

## **Απόκτηση Εικόνας Γραφήματος**
Το Aspose.Slides for C++ παρέχει υποστήριξη για εξαγωγή εικόνας συγκεκριμένου γραφήματος. Παρακάτω παρέχεται ένα παράδειγμα.

```cpp
auto presentation = MakeObject<Presentation>(u"test.pptx");

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 0, 0, 500, 500);

auto image = chart->GetImage();
image->Save(u"image.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **FAQ**

**Μπορώ να εξάγω ένα γράφημα ως διανυσματικό (SVG) αντί για εικόνα raster;**

Ναι. Ένα γράφημα είναι ένα σχήμα και τα περιεχόμενά του μπορούν να αποθηκευτούν ως SVG χρησιμοποιώντας τη [μέθοδο αποθήκευσης shape-to-SVG](https://reference.aspose.com/slides/el/cpp/aspose.slides/shape/writeassvg/).

**Πώς μπορώ να ορίσω το ακριβές μέγεθος του εξαγόμενου γραφήματος σε εικονοστοιχεία;**

Χρησιμοποιήστε τις υπερφόρτωση image-rendering που σας επιτρέπουν να ορίσετε μέγεθος ή κλίμακα — η βιβλιοθήκη υποστηρίζει την απόδοση αντικειμένων με τις καθορισμένες διαστάσεις/κλίμακα.

**Τι πρέπει να κάνω εάν οι γραμματοσειρές στα ετικέτες και στο υπόμνημα φαίνονται λανθασμένες μετά την εξαγωγή;**

[Φορτώστε τις απαιτούμενες γραμματοσειρές](/slides/el/cpp/custom-font/) μέσω του [FontsLoader](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontsloader/) ώστε η απόδοση του γραφήματος να διατηρεί τις μετρικές και την εμφάνιση του κειμένου.

**Η εξαγωγή τηρεί το θέμα, τα στυλ και τα εφέ του PowerPoint;**

Ναι. Ο renderer του Aspose.Slides ακολουθεί τη μορφοποίηση της παρουσίασης (θέματα, στυλ, γεμίσματα, εφέ), έτσι η εμφάνιση του γραφήματος διατηρείται.

**Πού μπορώ να βρω διαθέσιμες δυνατότητες απόδοσης/εξαγωγής πέρα από τις εικόνες γραφημάτων;**

Δείτε την ενότητα εξαγωγής του [API](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/)/[τεκμηρίωσης](/slides/el/cpp/convert-powerpoint/) για τους προορισμούς εξόδου ([PDF](/slides/el/cpp/convert-powerpoint-to-pdf/), [SVG](/slides/el/cpp/render-a-slide-as-an-svg-image/), [XPS](/slides/el/cpp/convert-powerpoint-to-xps/), [HTML](/slides/el/cpp/convert-powerpoint-to-html/), κ.λπ.) και τις σχετικές επιλογές απόδοσης.