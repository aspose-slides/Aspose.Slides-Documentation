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
description: "Εξερευνήστε διαφάνειες, τη δομή και τα μεταδεδομένα σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας C++ για ταχύτερη κατανόηση και πιο έξυπνες αξιολογήσεις περιεχομένου."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να επιθεωρήσετε τις πληροφορίες παρουσίασης στο Aspose.Slides. Εξηγεί πώς να καθορίσετε τη τρέχουσα μορφή μιας παρουσίασης χωρίς να φορτώσετε ολόκληρο το αρχείο, να διαβάσετε τις ιδιότητες εγγράφου της και να ενημερώσετε αυτές τις ιδιότητες όταν χρειάζεται.

Τα παραδείγματα βασίζονται στα API [PresentationInfo](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentationinfo/) και [DocumentProperties](https://reference.aspose.com/slides/el/cpp/aspose.slides/documentproperties/) και επιδεικνύουν τυπικές λειτουργίες για εργασία με μεταδεδομένα παρουσίασης.

## **Έλεγχος Μορφής Παρουσίασης**

Πριν δουλέψετε πάνω σε μια παρουσίαση, ίσως θέλετε να μάθετε σε ποια μορφή (PPT, PPTX, ODP και άλλα) βρίσκεται η παρουσίαση αυτή τη στιγμή.

Μπορείτε να ελέγξετε τη μορφή μιας παρουσίασης χωρίς να την φορτώσετε. Δείτε αυτόν τον κώδικα C++:

``` cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

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

## **Λήψη Ιδιοτήτων Παρουσίασης**

Αυτός ο κώδικας C++ σας δείχνει πώς να λάβετε τις ιδιότητες της παρουσίασης (πληροφορίες για την παρουσίαση):

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
auto props = info->ReadDocumentProperties();
Console::WriteLine(ObjectExt::ToString(props->get_CreatedTime()));
Console::WriteLine(props->get_Subject());
Console::WriteLine(props->get_Title());
// .. 
```

## **Ενημέρωση Ιδιοτήτων Παρουσίασης**

Το Aspose.Slides παρέχει τη μέθοδο [PresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentationinfo/updatedocumentproperties/) που σας επιτρέπει να κάνετε αλλαγές στις ιδιότητες της παρουσίασης.

Ας πούμε ότι έχουμε μια παρουσίαση PowerPoint με τις ιδιότητες εγγράφου όπως φαίνονται παρακάτω.

![Αρχικές ιδιότητες εγγράφου της παρουσίασης PowerPoint](input_properties.png)

Αυτό το παράδειγμα κώδικα δείχνει πώς να επεξεργαστείτε κάποιες ιδιότητες της παρουσίασης:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/date_time.h>
using namespace Aspose::Slides;
using namespace System;

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

## **Χρήσιμα Σύνδεσμοι**

Για να λάβετε περισσότερες πληροφορίες σχετικά με μια παρουσίαση και τα χαρακτηριστικά ασφαλείας της, μπορεί να βρείτε χρήσιμους αυτούς συνδέσμους:

- [Παρουσιάσεις με Προστασία Κωδικού](/slides/el/cpp/password-protected-presentation/)
- [Παρουσιάσεις με Προστασία Εγγραφής](/slides/el/cpp/write-protected-presentation/)

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να ελέγξω αν οι γραμματοσειρές είναι ενσωματωμένες και ποιες είναι;**

Κοιτάξτε τις [πληροφορίες ενσωματωμένων γραμματοσειρών](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontsmanager/getembeddedfonts/) σε επίπεδο παρουσίασης, έπειτα συγκρίνετε αυτές τις καταχωρίσεις με το σύνολο των [γραμματοσειρών που χρησιμοποιούνται πραγματικά στο περιεχόμενο](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontsmanager/getfonts/) για να εντοπίσετε ποιες γραμματοσειρές είναι κρίσιμες για την απόδοση.

**Πώς μπορώ γρήγορα να διαπιστώ αν το αρχείο περιέχει κρυφές διαφάνειες και πόσες;**

Περιηγηθείτε στη [συλλογή διαφανειών](https://reference.aspose.com/slides/el/cpp/aspose.slides/slidecollection/) και ελέγξτε τη [σημαία ορατότητας](https://reference.aspose.com/slides/el/cpp/aspose.slides/slide/get_hidden/) κάθε διαφάνειας.

**Μπορώ να εντοπίσω εάν χρησιμοποιούνται προσαρμοσμένο μέγεθος και προσανατολισμός διαφάνειας, και αν διαφέρουν από τις προεπιλογές;**

Ναι. Συγκρίνετε το τρέχον [μέγεθος και προσανατολισμό διαφάνειας](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_slidesize/) με τις τυπικές προεπιλογές· αυτό βοηθά στην πρόβλεψη της συμπεριφοράς για εκτύπωση και εξαγωγή.

**Υπάρχει γρήγορος τρόπος να δούμε αν τα διαγράμματα αναφέρονται σε εξωτερικές πηγές δεδομένων;**

Ναι. Διασχίστε όλα τα [διαγράμματα](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/chart/), ελέγξτε τη [πηγή δεδομένων](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/chartdata/get_datasourcetype/), και σημειώστε αν τα δεδομένα είναι εσωτερικά ή βασισμένα σε σύνδεσμο, συμπεριλαμβανομένων τυχόν σπασμένων συνδέσμων.

**Πώς μπορώ να αξιολογήσω τις «βαριές» διαφάνειες που μπορεί να επιβραδύνουν την απόδοση ή την εξαγωγή σε PDF;**

Για κάθε διαφάνεια, καταμετρήστε τις αντικειμενικές καταμετρήσεις και αναζητήστε μεγάλες εικόνες, διαφάνεια, σκιές, κινήσεις και πολυμέσα· εκχωρήστε μια αδρή βαθμολογία πολυπλοκότητας για να επισημάνετε πιθανές περιοχές απόδοσης.