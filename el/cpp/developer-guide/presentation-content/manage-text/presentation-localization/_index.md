---
title: Αυτοματοποιήστε την τοπική προσαρμογή παρουσίασης σε C++
linktitle: Τοπική προσαρμογή παρουσίασης
type: docs
weight: 100
url: /el/cpp/presentation-localization/
keywords:
- αλλαγή γλώσσας
- ορθογραφικός έλεγχος
- αναγνωριστικό γλώσσας
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Αυτοματοποιήστε την τοπική προσαρμογή διαφανειών PowerPoint και OpenDocument σε C++ με το Aspose.Slides, χρησιμοποιώντας πρακτικά παραδείγματα κώδικα και συμβουλές για πιο γρήγορη παγκόσμια υλοποίηση."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να ορίσετε το `LanguageId` για κείμενο σε μια παρουσίαση χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να ανοίξετε μια παρουσίαση, να προσθέσετε ένα σχήμα με κείμενο, να εκχωρήσετε έναν ταυτοποιητή γλώσσας σε ένα τμήμα κειμένου και να αποθηκεύσετε το αποτέλεσμα ως αρχείο PPTX.

## **Αλλαγή γλώσσας για μια παρουσίαση και κείμενο σχήματος**
- Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) .
- Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
- Προσθέστε ένα AutoShape τύπου Rectangle στη διαφάνεια.
- Προσθέστε κείμενο στο TextFrame.
- Ορισμός του Language Id στο κείμενο.
- Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.

Η υλοποίηση των παραπάνω βημάτων παρουσιάζεται παρακάτω σε ένα παράδειγμα.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-TextBoxOnSlideProgram-TextBoxOnSlideProgram.cpp" >}}

## **Συχνές ερωτήσεις**

**Ενεργοποιεί το αναγνωριστικό γλώσσας αυτόματη μετάφραση κειμένου;**

Όχι. Το [Language ID](https://reference.aspose.com/slides/el/cpp/aspose.slides/baseportionformat/set_languageid/) στο Aspose.Slides αποθηκεύει τη γλώσσα για ορθογραφικό έλεγχο και γραμματική διόρθωση, αλλά δεν μεταφράζει ή αλλάζει το περιεχόμενο του κειμένου. Είναι μεταδεδομένα που καταλαβαίνει το PowerPoint για τη διόρθωση.

**Επηρεάζει το αναγνωριστικό γλώσσας την συλλαβοποίηση και τις αλλαγές γραμμής κατά την απόδοση;**

Στο Aspose.Slides, το [Language ID](https://reference.aspose.com/slides/el/cpp/aspose.slides/baseportionformat/set_languageid/) χρησιμοποιείται για τη διόρθωση. Η ποιότητα της συλλαβοποίησης και η αναδίπλωση γραμμών εξαρτώνται κυρίως από τη διαθεσιμότητα των [proper fonts](/slides/el/cpp/powerpoint-fonts/) και τις ρυθμίσεις διάταξης/αλλαγής γραμμής για το σύστημα γραφής. Για να εξασφαλίσετε σωστή απόδοση, κάντε διαθέσιμες τις απαιτούμενες γραμματοσειρές, διαμορφώστε τους [font substitution rules](/slides/el/cpp/font-substitution/) και/ή [embed fonts](/slides/el/cpp/embedded-font/) στην παρουσίαση.

**Μπορώ να ορίσω διαφορετικές γλώσσες μέσα σε μια παράγραφο;**

Ναι. Το [Language ID](https://reference.aspose.com/slides/el/cpp/aspose.slides/baseportionformat/set_languageid/) εφαρμόζεται στο επίπεδο του τμήματος κειμένου, έτσι ώστε μια μόνο παράγραφο να μπορεί να συνδυάζει πολλαπλές γλώσσες με διαφορετικές ρυθμίσεις διόρθωσης.