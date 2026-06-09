---
title: Προσθήκη Σχημάτων Γραμμής σε Παρουσιάσεις με C++
linktitle: Γραμμή
type: docs
weight: 50
url: /el/cpp/line/
keywords:
- γραμμή
- δημιουργία γραμμής
- προσθήκη γραμμής
- απλή γραμμή
- ρύθμιση γραμμής
- προσαρμογή γραμμής
- στυλ παύλας
- κεφαλή βέλους
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε τη μορφοποίηση γραμμών σε παρουσιάσεις PowerPoint με το Aspose.Slides για C++. Ανακαλύψτε ιδιότητες, μεθόδους και παραδείγματα."
---
## **Επισκόπηση**

Το Aspose.Slides σάς επιτρέπει να προσθέτετε σχήματα γραμμής σε διαφάνειες PowerPoint προγραμματιστικά. Αυτό το άρθρο δείχνει πώς να δημιουργήσετε μια απλή γραμμή και πώς να προσαρμόσετε μια γραμμή ώστε να εμφανίζεται ως βέλος.

Θα μάθετε πώς να προσθέσετε ένα σχήμα γραμμής σε μια διαφάνεια, να προσαρμόσετε την οπτική εμφάνισή της και να αποθηκεύσετε την ενημερωμένη παρουσίαση. Τα παραδείγματα εστιάζουν σε πρακτικές ρυθμίσεις μορφοποίησης γραμμής όπως στυλ, πλάτος, μοτίβο παύλας, επιλογές άκρου βέλους και χρώμα γεμίσματος.

## **Δημιουργία Απλής Γραμμής**
Για να προσθέσετε μια απλή γραμμή σε μια επιλεγμένη διαφάνεια της παρουσίασης, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια παρουσία της [Presentation class](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
- Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
- Προσθέστε ένα AutoShape τύπου Line χρησιμοποιώντας τη μέθοδο [AddAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishapecollection/addautoshape/) που παρέχεται από το αντικείμενο Shapes.
- Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddPlainLineToSlide-AddPlainLineToSlide.cpp" >}}

## **Δημιουργία Γραμμής με Σχήμα Βέλους**
Το Aspose.Slides για C++ επιτρέπει επίσης στους προγραμματιστές να διαμορφώσουν ορισμένες ιδιότητες της γραμμής ώστε να φαίνεται πιο ελκυστική. Ας προσπαθήσουμε να ρυθμίσουμε μερικές ιδιότητες της γραμμής ώστε να μοιάζει με βέλος. Ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια παρουσία της [Presentation class](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
- Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
- Προσθέστε ένα AutoShape τύπου Line χρησιμοποιώντας τη μέθοδο [AddAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishapecollection/addautoshape/) που παρέχεται από το αντικείμενο Shapes.
- Ορίστε το Line Style σε ένα από τα στυλ που προσφέρει το Aspose.Slides για C++.
- Ορίστε το πλάτος (Width) της γραμμής.
- Ορίστε το [Dash Style](https://reference.aspose.com/slides/el/cpp/aspose.slides/linedashstyle/) της γραμμής σε ένα από τα στυλ που προσφέρονται από το Aspose.Slides για C++.
- Ορίστε το [Arrow Head Style](https://reference.aspose.com/slides/el/cpp/aspose.slides/lineformat/) και το μήκος (Length) του αρχικού σημείου της γραμμής.
- Ορίστε το Arrow Head Style και το Length του τελικού σημείου της γραμμής.
- Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddArrowShapedLineToSlide-AddArrowShapedLineToSlide.cpp" >}}

## **Συχνές Ερωτήσεις**

**Μπορώ να μετατρέψω μια κανονική γραμμή σε σύνδεσμο ώστε να «προσαρμόζεται» (snap) σε σχήματα;**

Όχι. Μια κανονική γραμμή (ένα [AutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/autoshape/) τύπου [Line](https://reference.aspose.com/slides/el/cpp/aspose.slides/shapetype/)) δεν μετατρέπεται αυτόματα σε σύνδεσμο. Για να προσαρμόζεται σε σχήματα, χρησιμοποιήστε τον ειδικό τύπο [Connector](https://reference.aspose.com/slides/el/cpp/aspose.slides/connector/) και τις [αντίστοιχες API](/slides/el/cpp/connector/) για συνδέσεις.

**Τι πρέπει να κάνω αν οι ιδιότητες μιας γραμμής κληρονόμησαν από το θέμα και είναι δύσκολο να προσδιοριστούν οι τελικές τιμές;**

[Διαβάστε τις αποτελεσματικές ιδιότητες](/slides/el/cpp/shape-effective-properties/) μέσω των διεπαφών [ILineFormatEffectiveData](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilinefillformateffectivedata/) , οι οποίες ήδη λαμβάνουν υπόψη την κληρονομικότητα και τα στυλ του θέματος.

**Μπορώ να κλειδώσω μια γραμμή ώστε να μην μπορεί να υποβληθεί σε επεξεργασία (μετακίνηση, αλλαγή μεγέθους);**

Ναι. Τα σχήματα παρέχουν [αντικείμενα κλειδώματος](https://reference.aspose.com/slides/el/cpp/aspose.slides/autoshape/get_autoshapelock/) που σας επιτρέπουν να [αποτρέψετε λειτουργίες επεξεργασίας](/slides/el/cpp/applying-protection-to-presentation/).