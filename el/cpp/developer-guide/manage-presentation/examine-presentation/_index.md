---
title: Ανάκτηση και Ενημέρωση Πληροφοριών Παρουσίασης σε C++
linktitle: Πληροφορίες Παρουσίασης
type: docs
weight: 30
url: /el/cpp/examine-presentation/
keywords:
- μορφή παρουσίασης
- ιδιότητες παρουσίασης
- ιδιότητες εγγράφου
- λήψη ιδιοτήτων
- ανάγνωση ιδιοτήτων
- αλλαγή ιδιοτήτων
- τροποποίηση ιδιοτήτων
- ενημέρωση ιδιοτήτων
- εξέταση PPTX
- εξέταση PPT
- εξέταση ODP
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Εξερευνήστε διαφάνειες, τη δομή και τα μεταδεδομένα σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας C++ για γρηγορότερη κατανόηση και πιο έξυπνους ελέγχους περιεχομένου."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να ελέγξετε πληροφορίες παρουσίασης στο Aspose.Slides. Εξηγεί πώς να προσδιορίσετε τη τρέχουσα μορφή μιας παρουσίασης χωρίς να φορτώσετε ολόκληρο το αρχείο, να διαβάσετε τις ιδιότητες του εγγράφου και να ενημερώσετε αυτές τις ιδιότητες όταν είναι απαραίτητο.

Τα παραδείγματα βασίζονται στις API [PresentationInfo](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentationinfo/) και [DocumentProperties](https://reference.aspose.com/slides/el/cpp/aspose.slides/documentproperties/) και παρουσιάζουν τυπικές λειτουργίες για εργασία με μεταδεδομένα παρουσίασης.

## **Έλεγχος μορφής παρουσίασης**

Πριν ξεκινήσετε την εργασία με μια παρουσίαση, ίσως θέλετε να διαπιστώσετε σε ποια μορφή (PPT, PPTX, ODP και άλλες) βρίσκεται η παρουσίαση αυτή τη στιγμή.

Μπορείτε να ελέγξετε τη μορφή μιας παρουσίασης χωρίς να τη φορτώσετε. Δείτε αυτόν τον κώδικα C++:

``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
// PPTX
Console::WriteLine(ObjectExt::ToString(info->get_LoadFormat()));

auto info2 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.ppt");
// PPT
Console::WriteLine(ObjectExt::ToString(info2->get_LoadFormat()));

auto info3 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.odp");
// ODP
Console::WriteLine(ObjectExt::ToString(info3->get_LoadFormat()));
```

## **Λήψη ιδιοτήτων παρουσίασης**

Αυτός ο κώδικας C++ σας δείχνει πώς να λάβετε τις ιδιότητες παρουσίασης (πληροφορίες για την παρουσίαση):

``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
auto props = info->ReadDocumentProperties();
Console::WriteLine(ObjectExt::ToString(props->get_CreatedTime()));
Console::WriteLine(props->get_Subject());
Console::WriteLine(props->get_Title());
// …
```

## **Ενημέρωση ιδιοτήτων παρουσίασης**

Το Aspose.Slides παρέχει τη μέθοδο [PresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentationinfo/updatedocumentproperties/) που σας επιτρέπει να κάνετε αλλαγές στις ιδιότητες παρουσίασης.

Ας πούμε ότι έχουμε μια παρουσίαση PowerPoint με τις ιδιότητες εγγράφου όπως φαίνονται παρακάτω.

![Αρχικές ιδιότητες εγγράφου της παρουσίασης PowerPoint](input_properties.png)

Αυτό το παράδειγμα κώδικα σας δείχνει πώς να επεξεργαστείτε ορισμένες ιδιότητες παρουσίασης:

```cpp
auto fileName = u"sample.pptx";

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);

auto properties = info->ReadDocumentProperties();
properties->set_Title(u"My title");
properties->set_LastSavedTime(DateTime::get_Now());

info->UpdateDocumentProperties(properties);
info->WriteBindedPresentation(fileName);
```

Τα αποτελέσματα της αλλαγής των ιδιοτήτων εγγράφου εμφανίζονται παρακάτω.

![Αλλαγμένες ιδιότητες εγγράφου της παρουσίασης PowerPoint](output_properties.png)

## **Χρήσιμοι σύνδεσμοι**

Για περισσότερες πληροφορίες σχετικά με μια παρουσίαση και τα χαρακτηριστικά ασφαλείας της, μπορεί να βρείτε χρήσιμους αυτούς τους συνδέσμους:

- [Έλεγχος εάν η Παρουσίαση είναι Κρυπτογραφημένη](https://docs.aspose.com/slides/el/cpp/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Έλεγχος εάν η Παρουσίαση είναι Προστατευμένη ενάντια στην Εγγραφή (μόνο ανάγνωση)](https://docs.aspose.com/slides/el/cpp/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Έλεγχος εάν η Παρουσίαση είναι Προστατευμένη με Κωδικό Πρόσβασης Πριν τη Φόρτωση](https://docs.aspose.com/slides/el/cpp/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Επιβεβαίωση του Κωδικού Πρόσβασης που Χρησιμοποιείται για την Προστασία μιας Παρουσίασης](https://docs.aspose.com/slides/el/cpp/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **Συχνές ερωτήσεις**

**Πώς μπορώ να ελέγξω αν οι γραμματοσειρές είναι ενσωματωμένες και ποιες είναι;**

Αναζητήστε τις [πληροφορίες ενσωματωμένων γραμματοσειρών](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontsmanager/getembeddedfonts/) στο επίπεδο της παρουσίασης, στη συνέχεια συγκρίνετε αυτές τις εγγραφές με το σύνολο των [γραμματοσειρών που χρησιμοποιούνται πραγματικά στο περιεχόμενο](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontsmanager/getfonts/) για να εντοπίσετε ποιες γραμματοσειρές είναι κρίσιμες για την απόδοση.

**Πώς μπορώ γρήγορα να διαπιστώ αν το αρχείο περιέχει κρυφές διαφάνειες και πόσες;**

Περιηγηθείτε στη [συλλογή διαφανειών](https://reference.aspose.com/slides/el/cpp/aspose.slides/slidecollection/) και ελέγξτε τη [σημαία ορατότητας](https://reference.aspose.com/slides/el/cpp/aspose.slides/slide/get_hidden/) κάθε διαφάνειας.

**Μπορώ να εντοπίσω αν χρησιμοποιείται προσαρμοσμένο μέγεθος και προσανατολισμός διαφάνειας, και αν διαφέρουν από τις προεπιλογές;**

Ναι. Συγκρίνετε το τρέχον [μέγεθος και προσανατολισμό διαφάνειας](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_slidesize/) με τις τυπικές προεπιλογές· αυτό βοηθά στην πρόβλεψη της συμπεριφοράς για εκτύπωση και εξαγωγή.

**Υπάρχει γρήγορος τρόπος να δω αν τα γραφήματα αναφέρονται σε εξωτερικές πηγές δεδομένων;**

Ναι. Περιηγηθείτε σε όλα τα [γραφήματα](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/chart/), ελέγξτε την [πηγή δεδομένων](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) τους, και σημειώστε αν τα δεδομένα είναι εσωτερικά ή βασισμένα σε σύνδεσμο, περιλαμβάνοντας τυχόν σπασμένους συνδέσμους.

**Πώς μπορώ να αξιολογήσω τις 'βαριές' διαφάνειες που μπορεί να επιβραδύνουν την απόδοση ή την εξαγωγή PDF;**

Για κάθε διαφάνεια, μετρήστε τον αριθμό των αντικειμένων και ψάξτε μεγάλες εικόνες, διαφάνειες, σκιές, κινούμενα σχέδια και πολυμέσα· εκχωρήστε έναν κατά προσέγγιση βαθμό πολυπλοκότητας για να επισημάνετε πιθανά σημεία συμφόρησης της απόδοσης.