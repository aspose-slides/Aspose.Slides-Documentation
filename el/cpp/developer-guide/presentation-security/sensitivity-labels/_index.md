---
title: Διαχείριση ετικετών ευαισθησίας σε παρουσιάσεις PowerPoint με C++
linktitle: Ετικέτες ευαισθησίας
type: docs
weight: 50
url: /el/cpp/sensitivity-labels/
keywords:
- ετικέτα ευαισθησίας
- Microsoft Purview
- Microsoft Information Protection
- μεταδεδομένα MIP
- επισημάνσεις περιεχομένου
- προστασία πληροφοριών
- διακυβέρνηση εγγράφων
- PowerPoint
- PPTX
- ασφάλεια παρουσίασης
- C++
- Aspose.Slides
description: "Διαβάστε, προσθέστε, ενημερώστε, αφαιρέστε και μεταφέρετε τις ετικέτες ευαισθησίας Microsoft Purview σε παρουσιάσεις PowerPoint PPTX με το Aspose.Slides για C++."
---
## **Επισκόπηση**

Microsoft Purview sensitivity labels help organizations classify and govern documents. During automated presentation processing, an application may need to preserve an existing label, apply a label selected by a policy, update its state, or migrate label metadata written by an older Microsoft Information Protection (MIP) workflow.

Aspose.Slides exposes modern sensitivity label metadata through [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentation/get_sensitivitylabels/). This method returns an [ISensitivityLabelCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabelcollection/) that can be inspected and modified before the presentation is saved as PPTX.

{{% alert color="info" title="Note" %}}
Sensitivity label identifiers and policy information are defined by your Microsoft Purview configuration. Validate label availability and policy requirements in your environment before adding or migrating metadata. The [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) values describe the content markings associated with a label; they do not by themselves add visible text or shapes to slides.
{{% /alert %}}

## **Κατανόηση Ιδιοτήτων Ετικέτας Ευαισθησίας**

Κάθε [ISensitivityLabel](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabel/) περιέχει τα ακόλουθα μεταδεδομένα:

| Πρόσβαση | Σκοπός |
| --- | --- |
| [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabel/get_id/), [ISensitivityLabel::set_Id](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabel/set_id/) | Αναγνωρίζει την ετικέτα ευαισθησίας στην πολιτική Purview. |
| [ISensitivityLabel::get_SiteId](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabel/get_siteid/), [ISensitivityLabel::set_SiteId](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabel/set_siteid/) | Αναγνωρίζει την τοποθεσία που συνδέεται με την πολιτική ετικέτας. |
| [ISensitivityLabel::get_IsEnabled](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabel/get_isenabled/), [ISensitivityLabel::set_IsEnabled](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabel/set_isenabled/) | Δεικνύει εάν η ετικέτα είναι ενεργοποιημένη. |
| [ISensitivityLabel::get_IsRemoved](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabel/get_isremoved/), [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabel/set_isremoved/) | Δεικνύει ότι η ετικέτα έχει αφαιρεθεί. Ορίστε την τιμή σε `true` όταν η κατάσταση αφαίρεσης πρέπει να διατηρείται στα μεταδεδομένα. |
| [ISensitivityLabel::get_AssignmentMethodType](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabel/get_assignmentmethodtype/), [ISensitivityLabel::set_AssignmentMethodType](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabel/set_assignmentmethodtype/) | Καθορίζει αν η ετικέτα εφαρμόστηκε αυτόματα ή μέσω απόφασης χρήστη. |
| [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) | Λίστα των τύπων επισημάνσεων περιεχομένου που σχετίζονται με την ετικέτα. |

Η απαρίθμηση [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/el/cpp/aspose.slides/sensitivitylabelassignmenttype/) περιγράφει πώς μια ετικέτα εκχωρήθηκε:

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/el/cpp/aspose.slides/sensitivitylabelassignmenttype/) αντιπροσωπεύει μια προεπιλεγμένη ή αυτόματα εφαρμοσμένη ετικέτα.
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/el/cpp/aspose.slides/sensitivitylabelassignmenttype/) αντιπροσωπεύει μια ετικέτα που εφαρμόζεται μέσω απόφασης χρήστη, συμπεριλαμβανομένων των χειροκίνητα εφαρμοσμένων, προτεινόμενων και υποχρεωτικών ετικετών.

Η απαρίθμηση [SensitivityLabelContentType](https://reference.aspose.com/slides/el/cpp/aspose.slides/sensitivitylabelcontenttype/) εντοπίζει την επισημάνση που συνδέεται με μια ετικέτα:

| Τιμή | Σημασία |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/el/cpp/aspose.slides/sensitivitylabelcontenttype/) | Η ετικέτα εφαρμόστηκε προεπιλεγμένα ή αυτόματα. |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/el/cpp/aspose.slides/sensitivitylabelcontenttype/) | Η επισημάνση περιεχομένου κεφαλίδας συνδέεται με την ετικέτα. |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/el/cpp/aspose.slides/sensitivitylabelcontenttype/) | Η επισημάνση περιεχομένου υποσέλιδου συνδέεται με την ετικέτα. |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/el/cpp/aspose.slides/sensitivitylabelcontenttype/) | Η επισημάνση περιεχομένου υδατογραφήματος συνδέεται με την ετικέτα. |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/el/cpp/aspose.slides/sensitivitylabelcontenttype/) | Η προστασία κρυπτογράφησης συνδέεται με την ετικέτα. |

Πολλαπλοί τύποι επισημάνσεων μπορούν να συνδεθούν με μία ετικέτα.

## **Λίστα Υπάρχουσων Ετικετών Ευαισθησίας**

Διαβάστε τη σύγχρονη συλλογή ετικετών από το [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) και καταμετρήστε την. Το παρακάτω παράδειγμα παραθέτει κάθε ιδιότητα και επισημάνση περιεχομένου που αποθηκεύεται για κάθε ετικέτα:

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

## **Προσθήκη Ετικέτας Ευαισθησίας με Επισημάνση Περιεχομένου**

Χρησιμοποιήστε το [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabelcollection/add/) με το αναγνωριστικό της ετικέτας, το αναγνωριστικό τοποθεσίας, την κατάσταση ενεργοποίησης και τη μέθοδο εκχώρησης. Αφού η μέθοδος επιστρέψει τη νέα [ISensitivityLabel](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabel/), προσθέστε τις απαιτούμενες τιμές επισημάνσεων μέσω του [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/).

Το παρακάτω παράδειγμα προσθέτει μια χειροκίνητα επιλεγμένη ετικέτα που συνδέεται με επισημάνσεις υποσέλιδου και υδατογραφήματος, και στη συνέχεια αποθηκεύει το αποτέλεσμα ως PPTX:

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

Οι τιμές του [ISensitivityLabel](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabel/) είναι αναγνώσιμες/εγγράψιμες μέσω των μεθόδων getter και setter τους, εκτός από τη συλλογή που επιστρέφεται από το [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) η οποία τροποποιείται μέσω των λειτουργιών λίστας της. Αφού εντοπίσετε την απαιτούμενη ετικέτα, μπορείτε να ενημερώσετε το αναγνωριστικό της, το αναγνωριστικό τοποθεσίας, την κατάσταση ενεργοποίησης, τη μέθοδο εκχώρησης, την κατάσταση αφαίρεσης και τους τύπους επισημάνσεων περιεχομένου. Αποθηκεύστε την παρουσίαση για να διατηρήσετε τις αλλαγές.

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

## **Σήμανση Ετικέτας Ευαισθησίας ως Αφαιρεμένη**

Για να διατηρήσετε το γεγονός ότι μια ετικέτα αφαιρέθηκε, βρείτε την ετικέτα και καλέστε το [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabel/set_isremoved/) με `true`. Αυτό διατηρεί την καταχώρηση της ετικέτας ενώ καταγράφει την κατάσταση αφαίρεσής της. Εάν αντίθετα χρειάζεται να διαγράψετε μια καταχώρηση από τη σύγχρονη συλλογή, χρησιμοποιήστε το [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabelcollection/removeat/); χρησιμοποιήστε το [ISensitivityLabelCollection::Clear](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabelcollection/clear/) για να διαγράψετε όλες τις καταχωρήσεις.

Το παρακάτω παράδειγμα σημάνει μια συγκεκριμένη ετικέτα ως αφαιρεμένη και αποθηκεύει την ενημερωμένη παρουσίαση:

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

## **Ανάγνωση και Μεταφορά Κληρονομικών Ετικετών Ευαισθησίας MIP**

Οι παλαιότερες ροές εργασίας που βασίζονται σε MIP μπορούν να αποθηκεύουν μεταδεδομένα ετικετών ευαισθησίας στις προσαρμοσμένες ιδιότητες εγγράφων αντί στη σύγχρονη συλλογή ετικετών. Διαβάστε αυτά τα μεταδεδομένα με το [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/el/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/). Η μέθοδος αναλύει τις κληρονομικές προσαρμοσμένες ιδιότητες και επιστρέφει έναν πίνακα αντικειμένων [ISensitivityLabel](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabel/).

Για να μεταφέρετε τα μεταδεδομένα, προσθέστε κάθε επιστρεφόμενη ετικέτα στη σύγχρονη [ISensitivityLabelCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabelcollection/) μέσω του [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabelcollection/add/). Επειδή η προσθήκη διπλότυπου αναγνωριστικού ετικέτας προκαλεί εξαίρεση, το παράδειγμα ελέγχει τη συλλογή προορισμού πριν αντιγράψει κάθε ετικέτα. Μπορείτε να προσθέσετε περαιτέρω έλεγχο για να επιβεβαιώσετε ότι κάθε κληρονομική ετικέτα εξακολουθεί να υπάρχει στην τρέχουσα πολιτική Purview.

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

Η μεταφορά αντιγράφει τα αναλυμένα αντικείμενα ετικετών στη σύγχρονη συλλογή. Δεν απαιτεί την εκκαθάριση όλων των προσαρμοσμένων ιδιοτήτων εγγράφου, έτσι τα ανεξάρτητα μεταδεδομένα του εγγράφου παραμένουν αμετάβλητα. Χρησιμοποιήστε το [IPresentation::Save](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentation/save/) με το [SaveFormat::Pptx](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/saveformat/) για να γράψετε τα σύγχρονα μεταδεδομένα ετικετών σε αρχείο PPTX.

## **FAQ**

**Δημιουργεί η προσθήκη τύπου επισημάνσης περιεχομένου μια ορατή κεφαλίδα, υποσέλιδο ή υδατογράφημα στις διαφάνειες;**

Όχι. Οι τιμές που προστίθενται μέσω του [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) περιγράφουν τις επισημάνσεις που σχετίζονται με την ετικέτα ευαισθησίας. Δεν δημιουργούν ορατό κείμενο ή σχήματα στην παρουσίαση. Προσθέστε το αντίστοιχο περιεχόμενο των διαφανειών ξεχωριστά εάν η ροή εργασίας σας πρέπει να αποτυπώνει αυτές τις επισημάνσεις.

**Ποια είναι η διαφορά μεταξύ σήμανσης μιας ετικέτας ως αφαιρεμένης και διαγραφής της από τη συλλογή;**

Η κλήση του [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabel/set_isremoved/) με `true` διατηρεί την καταχώρηση της ετικέτας και καταγράφει την κατάσταση αφαίρεσής της. Η κλήση του [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabelcollection/removeat/) διαγράφει την καταχώρηση από τη σύγχρονη συλλογή. Επιλέξτε τη λειτουργία που ταιριάζει στις απαιτήσεις διατήρησης μεταδεδομένων του οργανισμού σας.

**Μπορεί μια παρουσίαση να περιέχει τόσο κληρονομικά μεταδεδομένα MIP όσο και σύγχρονες ετικέτες ευαισθησίας;**

Ναι. Οι κληρονομικές ετικέτες μπορούν να παραμείνουν στις προσαρμοσμένες ιδιότητες εγγράφου, ενώ οι σύγχρονες ετικέτες είναι διαθέσιμες μέσω του [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentation/get_sensitivitylabels/). Χρησιμοποιήστε το [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/el/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/) για να διαβάσετε τα κληρονομικά μεταδεδομένα και να μεταφέρετε μόνο τις έγκυρες ετικέτες που δεν υπάρχουν ήδη στη σύγχρονη συλλογή.

**Τι συμβαίνει όταν μια ετικέτα με το ίδιο αναγνωριστικό προστίθεται περισσότερες από μία φορές;**

Το [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabelcollection/add/) πετάει εξαίρεση argument όταν η συλλογή περιέχει ήδη μια ετικέτα με το ίδιο αναγνωριστικό. Ελέγξτε τις υπάρχουσες τιμές του [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/el/cpp/aspose.slides/isensitivitylabel/get_id/) πριν προσθέσετε ή μεταφέρετε ετικέτες.

**Ποια μορφή εξόδου πρέπει να χρησιμοποιηθεί για τη διατήρηση των ενημερωμένων ετικετών ευαισθησίας;**

Αποθηκεύστε την παρουσίαση ως PPTX καλώντας το [IPresentation::Save](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentation/save/) με το [SaveFormat::Pptx](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/saveformat/), όπως φαίνεται στα παραπάνω παραδείγματα.