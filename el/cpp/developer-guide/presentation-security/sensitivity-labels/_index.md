---
title: Διαχείριση Ετικετών Ευαισθησίας σε Παρουσιάσεις PowerPoint σε C++
linktitle: Ετικέτες Ευαισθησίας
type: docs
weight: 50
url: /el/cpp/sensitivity-labels/
keywords:
- ετικέτα ευαισθησίας
- Microsoft Purview
- Microsoft Information Protection
- μεταδεδομένα MIP
- σήμανση περιεχομένου
- προστασία πληροφοριών
- διακυβέρνηση εγγράφων
- PowerPoint
- PPTX
- ασφάλεια παρουσίασης
- C++
- Aspose.Slides
description: "Ανάγνωση, προσθήκη, ενημέρωση, διαγραφή και μετεγκατάσταση ετικετών ευαισθησίας του Microsoft Purview σε παρουσιάσεις PowerPoint PPTX με το Aspose.Slides για C++."
---
## **Επισκόπηση**

Οι ετικέτες ευαισθησίας του Microsoft Purview βοηθούν τις οργανώσεις να ταξινομούν και να διαχειρίζονται έγγραφα. Κατά την αυτοματοποιημένη επεξεργασία παρουσίασης, μια εφαρμογή ενδέχεται να πρέπει να διατηρήσει μια υπάρχουσα ετικέτα, να εφαρμόσει μια ετικέτα που επιλέχθηκε από πολιτική, να ενημερώσει την κατάσταση της ή να μεταφέρει μεταδεδομένα ετικέτας που γράφτηκαν από παλαιότερη ροή εργασίας Microsoft Information Protection (MIP).

Aspose.Slides εκθέτει σύγχρονα μεταδεδομένα ετικέτας ευαισθησίας μέσω [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentation/get_sensitivitylabels/). Αυτή η μέθοδος επιστρέφει μια [ISensitivityLabelCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabelcollection/) που μπορεί να εξεταστεί και να τροποποιηθεί πριν αποθηκευτεί η παρουσίαση ως PPTX.

{{% alert color="primary" title="Σημείωση" %}}

Τα αναγνωριστικά ετικετών ευαισθησίας και οι πληροφορίες πολιτικής ορίζονται από τη ρύθμιση του Microsoft Purview. Επαληθεύστε τη διαθεσιμότητα των ετικετών και τις απαιτήσεις πολιτικής στο περιβάλλον σας πριν προσθέσετε ή μεταφέρετε μεταδεδομένα. Οι τιμές της [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) περιγράφουν τα σήματα περιεχομένου που σχετίζονται με μια ετικέτα· από μόνες τους δεν προσθέτουν ορατό κείμενο ή σχήματα στις διαφάνειες.

{{% /alert %}}

## **Κατανόηση Ιδιοτήτων Ετικέτας Ευαισθησίας**

Κάθε [ISensitivityLabel](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabel/) περιέχει τα ακόλουθα μεταδεδομένα:

| Πρόσβαση | Σκοπός |
| --- | --- |
| [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabel/get_id/), [ISensitivityLabel::set_Id](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabel/set_id/) | Αναγνωρίζει την ετικέτα ευαισθησίας στην πολιτική Purview. |
| [ISensitivityLabel::get_SiteId](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabel/get_siteid/), [ISensitivityLabel::set_SiteId](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabel/set_siteid/) | Αναγνωρίζει τον ιστότοπο που συνδέεται με την πολιτική της ετικέτας. |
| [ISensitivityLabel::get_IsEnabled](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabel/get_isenabled/), [ISensitivityLabel::set_IsEnabled](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabel/set_isenabled/) | Υποδεικνύει εάν η ετικέτα είναι ενεργοποιημένη. |
| [ISensitivityLabel::get_IsRemoved](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabel/get_isremoved/), [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabel/set_isremoved/) | Υποδεικνύει ότι η ετικέτα αφαιρέθηκε. Ορίστε την τιμή σε `true` όταν η κατάσταση αφαίρεσης πρέπει να διατηρηθεί στα μεταδεδομένα. |
| [ISensitivityLabel::get_AssignmentMethodType](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabel/get_assignmentmethodtype/), [ISensitivityLabel::set_AssignmentMethodType](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabel/set_assignmentmethodtype/) | Καθορίζει εάν η ετικέτα εφαρμόστηκε αυτόματα ή μέσω απόφασης χρήστη. |
| [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) | Καταγράφει τους τύπους σήματος περιεχομένου που σχετίζονται με την ετικέτα. |

Η απαρίθμηση [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/el/cpp/aspose.slides/sensitivitylabelassignmenttype/) περιγράφει πώς εκχωρήθηκε μια ετικέτα:

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/el/cpp/aspose.slides/sensitivitylabelassignmenttype/) αντιπροσωπεύει προεπιλογή ή αυτόματα εφαρμοσμένη ετικέτα.  
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/el/cpp/aspose.slides/sensitivitylabelassignmenttype/) αντιπροσωπεύει ετικέτα που εφαρμόστηκε μέσω απόφασης χρήστη, συμπεριλαμβανομένων των χειροκίνητων, προτεινόμενων και υποχρεωτικών ετικετών.

Η απαρίθμηση [SensitivityLabelContentType](https://reference.aspose.com/slides/el/cpp/aspose.slides/sensitivitylabelcontenttype/) προσδιορίζει το σήμα που σχετίζεται με μια ετικέτα:

| Τιμή | Σημασία |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/el/cpp/aspose.slides/sensitivitylabelcontenttype/) | Η ετικέτα εφαρμόστηκε προεπιλογή ή αυτόματα. |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/el/cpp/aspose.slides/sensitivitylabelcontenttype/) | Το σήμα περιεχομένου κεφαλίδας συνδέεται με την ετικέτα. |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/el/cpp/aspose.slides/sensitivitylabelcontenttype/) | Το σήμα περιεχομένου υποσέλιδου συνδέεται με την ετικέτα. |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/el/cpp/aspose.slides/sensitivitylabelcontenttype/) | Το σήμα υδατογράφησης περιεχομένου συνδέεται με την ετικέτα. |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/el/cpp/aspose.slides/sensitivitylabelcontenttype/) | Η προστασία κρυπτογράφησης συνδέεται με την ετικέτα. |

Πολλοί τύποι σήματος μπορούν να συσχετιστούν με μία ετικέτα.

## **Λίστα Υπάρχουσων Ετικετών Ευαισθησίας**

Διαβάστε τη σύγχρονη συλλογή ετικετών από [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) και κάντε την επανάληψη. Το ακόλουθο παράδειγμα εμφανίζει κάθε ιδιότητα και σήμα περιεχομένου που αποθηκεύονται για κάθε ετικέτα:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <DOM/SensitivityLabelAssignmentType.h>
#include <DOM/SensitivityLabelContentType.h>
#include <system/collections/ilist.h>
#include <system/console.h>
#include <system/guid.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Presentation;
using System::Console;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();

for (auto&& sensitivityLabel : sensitivityLabels)
{
    auto labelIdentifier = sensitivityLabel->get_Id();
    auto siteIdentifier = sensitivityLabel->get_SiteId();
    auto isEnabled = sensitivityLabel->get_IsEnabled();
    auto isRemoved = sensitivityLabel->get_IsRemoved();
    auto assignmentMethod = sensitivityLabel->get_AssignmentMethodType();

    Console::WriteLine(u"Label ID: {0}", labelIdentifier);
    Console::WriteLine(u"Site ID: {0}", siteIdentifier);
    Console::WriteLine(u"Enabled: {0}", isEnabled);
    Console::WriteLine(u"Removed: {0}", isRemoved);
    Console::WriteLine(u"Assignment method: {0}", assignmentMethod);

    for (auto contentMarkType : sensitivityLabel->get_ContentMarkTypes())
    {
        Console::WriteLine(u"Content marking: {0}", contentMarkType);
    }
}

presentation->Dispose();
```

## **Προσθήκη Ετικέτας Ευαισθησίας με Σήμα Περιεχομένου**

Χρησιμοποιήστε [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabelcollection/add/) με το αναγνωριστικό ετικέτας, το αναγνωριστικό ιστότοπου, την κατάσταση ενεργοποίησης και τη μέθοδο εκχώρησης. Μετά την επιστροφή της νέας [ISensitivityLabel](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabel/), προσθέστε τις απαιτούμενες τιμές σημαδιών μέσω [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/).

Το παρακάτω παράδειγμα προσθέτει μια χειροκίνητα επιλεγμένη ετικέτα που συσχετίζεται με σήματα υποσέλιδου και υδατογράφησης και, στη συνέχεια, αποθηκεύει το αποτέλεσμα ως PPTX:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <DOM/SensitivityLabelAssignmentType.h>
#include <DOM/SensitivityLabelContentType.h>
#include <Export/SaveFormat.h>
#include <system/collections/ilist.h>
#include <system/guid.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::SensitivityLabelAssignmentType;
using Aspose::Slides::SensitivityLabelContentType;
using Aspose::Slides::Export::SaveFormat;
using System::Guid;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();

auto labelIdentifier = u"{11111111-2222-3333-4444-555555555555}";
auto siteIdentifier = Guid::Parse(u"{aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee}");
bool isEnabled = true;
auto assignmentMethod = SensitivityLabelAssignmentType::Privileged;

auto sensitivityLabel = sensitivityLabels->Add(
    labelIdentifier,
    siteIdentifier,
    isEnabled,
    assignmentMethod);

sensitivityLabel->get_ContentMarkTypes()->Add(SensitivityLabelContentType::Footer);
sensitivityLabel->get_ContentMarkTypes()->Add(SensitivityLabelContentType::Watermark);

presentation->Save(u"presentation_with_label.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ενημέρωση Ετικέτας Ευαισθησίας**

Οι τιμές της [ISensitivityLabel](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabel/) διαβάζονται/γράφονται μέσω των μεθόδων getter και setter, εκτός από τη συλλογή που επιστρέφεται από την [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) η οποία τροποποιείται μέσω των λειτουργιών λίστας της. Αφού εντοπίσετε την απαιτούμενη ετικέτα, μπορείτε να ενημερώσετε το αναγνωριστικό, το αναγνωριστικό ιστότοπου, την κατάσταση ενεργοποίησης, τη μέθοδο εκχώρησης, την κατάσταση αφαίρεσης και τους τύπους σήματος περιεχομένου. Αποθηκεύστε την παρουσίαση για να διατηρήσετε τις αλλαγές.

Το παρακάτω παράδειγμα ενημερώνει την κατάσταση ενεργοποίησης και τη μέθοδο εκχώρησης της πρώτης ετικέτας:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <DOM/SensitivityLabelAssignmentType.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::SensitivityLabelAssignmentType;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();
int labelCount = sensitivityLabels->get_Count();

if (labelCount > 0)
{
    auto sensitivityLabel = sensitivityLabels->idx_get(0);
    sensitivityLabel->set_IsEnabled(true);
    sensitivityLabel->set_AssignmentMethodType(SensitivityLabelAssignmentType::Privileged);
}

presentation->Save(u"presentation_with_updated_label.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Σήμανση Ετικέτας Ευαισθησίας ως Απομακρυσμένης**

Για να διατηρήσετε το γεγονός ότι μια ετικέτα αφαιρέθηκε, βρείτε την ετικέτα και καλέστε την [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabel/set_isremoved/) με `true`. Αυτό διατηρεί την εγγραφή της ετικέτας ενώ καταγράφει την κατάσταση αφαίρεσής της. Εάν αντίθετα χρειάζεται να διαγράψετε μια εγγραφή από τη σύγχρονη συλλογή, χρησιμοποιήστε την [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabelcollection/removeat/); χρησιμοποιήστε την [ISensitivityLabelCollection::Clear](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabelcollection/clear/) για τη διαγραφή όλων των εγγραφών.

Το παρακάτω παράδειγμα σημειώνει μια συγκεκριμένη ετικέτα ως αφαιρεμένη και αποθηκεύει την ενημερωμένη παρουσίαση:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::String;
using System::StringComparison;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();
auto targetLabelIdentifier = u"{11111111-2222-3333-4444-555555555555}";

for (auto&& sensitivityLabel : sensitivityLabels)
{
    auto labelIdentifier = sensitivityLabel->get_Id();
    bool isTargetLabel = String::Equals(
        labelIdentifier,
        targetLabelIdentifier,
        StringComparison::OrdinalIgnoreCase);

    if (isTargetLabel)
    {
        sensitivityLabel->set_IsRemoved(true);
        break;
    }
}

presentation->Save(u"presentation_with_removed_label.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ανάγνωση και Μεταφορά Παλαιών Ετικετών Ευαισθησίας MIP**

Οι παλαιότερες ροές εργασίας βασισμένες σε MIP μπορούν να αποθηκεύουν μεταδεδομένα ετικετών ευαισθησίας σε προσαρμοσμένες ιδιότητες εγγράφου αντί της σύγχρονης συλλογής ετικετών. Διαβάστε αυτά τα μεταδεδομένα με την [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/el/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/). Η μέθοδος αναλύει τις παλιές προσαρμοσμένες ιδιότητες και επιστρέφει έναν πίνακα αντικειμένων [ISensitivityLabel](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabel/).

Για να μεταφέρετε τα μεταδεδομένα, προσθέστε κάθε επιστρεφόμενη ετικέτα στη σύγχρονη [ISensitivityLabelCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabelcollection/) μέσω της [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabelcollection/add/). Επειδή η προσθήκη διπλού αναγνωριστικού ετικέτας προκαλεί εξαίρεση, το παράδειγμα ελέγχει τη συλλογή προορισμού πριν αντιγράψει κάθε ετικέτα. Μπορείτε να προσθέσετε περαιτέρω έλεγχο για να επιβεβαιώσετε ότι κάθε παλιά ετικέτα εξακολουθεί να υπάρχει στην τρέχουσα πολιτική Purview.

```cpp
#include <DOM/Presentation.h>
#include <DOM/IDocumentProperties.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::String;
using System::StringComparison;

auto presentation = MakeObject<Presentation>(u"presentation_with_legacy_labels.pptx");
auto documentProperties = presentation->get_DocumentProperties();
auto legacySensitivityLabels = documentProperties->GetSensitivityLabels();
auto modernSensitivityLabels = presentation->get_SensitivityLabels();

for (auto&& legacySensitivityLabel : legacySensitivityLabels)
{
    bool labelAlreadyExists = false;
    auto legacyLabelIdentifier = legacySensitivityLabel->get_Id();

    for (auto&& modernSensitivityLabel : modernSensitivityLabels)
    {
        auto modernLabelIdentifier = modernSensitivityLabel->get_Id();
        labelAlreadyExists = String::Equals(
            modernLabelIdentifier,
            legacyLabelIdentifier,
            StringComparison::OrdinalIgnoreCase);

        if (labelAlreadyExists)
        {
            break;
        }
    }

    if (!labelAlreadyExists)
    {
        modernSensitivityLabels->Add(legacySensitivityLabel);
    }
}

presentation->Save(u"presentation_with_modern_labels.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Η μεταφορά αντιγράφει τα αναλυθέντα αντικείμενα ετικέτας στη σύγχρονη συλλογή. Δεν απαιτείται εκκαθάριση όλων των προσαρμοσμένων ιδιοτήτων εγγράφου, ώστε τα μη σχετιζόμενα μεταδεδομένα του εγγράφου να παραμείνουν ανέπαφα. Χρησιμοποιήστε την [IPresentation::Save](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentation/save/) με το [SaveFormat::Pptx](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/saveformat/) για να γράψετε τα σύγχρονα μεταδεδομένα ετικετών σε αρχείο PPTX.

## **Συχνές Ερωτήσεις**

**Δημιουργεί η προσθήκη τύπου σήματος περιεχομένου ορατή κεφαλίδα, υποσέλιδο ή υδατογράφημα στις διαφάνειες;**

Όχι. Οι τιμές που προστίθενται μέσω της [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) περιγράφουν τα σήματα που σχετίζονται με την ετικέτα ευαισθησίας. Δεν δημιουργούν ορατό κείμενο ή σχήματα στην παρουσίαση. Προσθέστε το αντίστοιχο περιεχόμενο διαφάνειας ξεχωριστά, εφόσον η ροή εργασίας σας απαιτεί την απόδοση αυτών των σημάτων.

**Ποια είναι η διαφορά μεταξύ σήμανσης μιας ετικέτας ως αφαιρεμένης και της διαγραφής της από τη συλλογή;**

Καλώντας την [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabel/set_isremoved/) με `true` διατηρείται η εγγραφή της ετικέτας και καταγράφεται η κατάσταση αφαίρεσής της. Καλώντας την [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabelcollection/removeat/) διαγράφεται η εγγραφή από τη σύγχρονη συλλογή. Επιλέξτε τη λειτουργία που ταιριάζει στις απαιτήσεις διατήρησης μεταδεδομένων του οργανισμού σας.

**Μπορεί μια παρουσίαση να περιέχει τόσο παλιά μεταδεδομένα MIP όσο και σύγχρονες ετικέτες ευαισθησίας;**

Ναι. Οι παλιές ετικέτες μπορούν να παραμείνουν σε προσαρμοσμένες ιδιότητες εγγράφου, ενώ οι σύγχρονες ετικέτες είναι διαθέσιμες μέσω του [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentation/get_sensitivitylabels/). Χρησιμοποιήστε την [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/el/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/) για να διαβάσετε τα παλιά μεταδεδομένα και να μεταφέρετε μόνο τις έγκυρες ετικέτες που δεν υπάρχουν ήδη στη σύγχρονη συλλογή.

**Τι συμβαίνει όταν μια ετικέτα με το ίδιο αναγνωριστικό προστίθεται περισσότερες από μία φορές;**

Η [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabelcollection/add/) προκαλεί εξαίρεση ορίσματος όταν η συλλογή περιέχει ήδη ετικέτα με το ίδιο αναγνωριστικό. Ελέγξτε τις υπάρχουσες τιμές του [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabel/get_id/) πριν προσθέσετε ή μεταφέρετε ετικέτες.

**Ποια μορφή εξόδου πρέπει να χρησιμοποιηθεί για τη διατήρηση των ενημερωμένων ετικετών ευαισθησίας;**

Αποθηκεύστε την παρουσίαση ως PPTX καλώντας την [IPresentation::Save](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentation/save/) με το [SaveFormat::Pptx](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/saveformat/), όπως φαίνεται στα παραπάνω παραδείγματα.