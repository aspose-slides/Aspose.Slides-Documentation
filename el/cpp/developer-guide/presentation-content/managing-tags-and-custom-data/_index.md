---
title: Διαχείριση ετικετών και προσαρμοσμένων δεδομένων σε παρουσιάσεις με C++
linktitle: Ετικέτες και προσαρμοσμένα δεδομένα
type: docs
weight: 300
url: /el/cpp/managing-tags-and-custom-data/
keywords:
- ιδιότητες εγγράφου
- ετικέτα
- προσαρμοσμένα δεδομένα
- προσαρμοσμένο XML
- προσαρμοσμένο τμήμα XML
- μεταδεδομένα XML
- ItemId
- προσθήκη ετικέτας
- ζεύγος τιμών
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε ετικέτες και προσαρμοσμένα δεδομένα XML σε παρουσιάσεις PowerPoint με το Aspose.Slides για C++, συμπεριλαμβανομένης της προσθήκης, ανάγνωσης, ενημέρωσης, ελέγχου και αφαίρεσης προσαρμοσμένων τμημάτων XML."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς το Aspose.Slides λειτουργεί με ετικέτες και προσαρμοσμένα δεδομένα σε παρουσιάσεις PowerPoint. Τα δεδομένα που ανήκουν σε μια παρουσίαση μπορούν να αποθηκευτούν ως ετικέτες ή προσαρμοσμένα τμήματα XML. Οι ετικέτες είναι απλά ζευγάρια κλειδιού‑ τιμής συμβολοσειράς, ενώ τα προσαρμοσμένα τμήματα XML μπορούν να αποθηκεύσουν δομημένα μεταδεδομένα και φορτία XML ειδικά για την εφαρμογή.

Το Aspose.Slides παρέχει API για προσθήκη, ανάγνωση, ενημέρωση, έλεγχο και αφαίρεση προσαρμοσμένων τμημάτων XML σε επίπεδο παρουσίασης, διαφάνειας και σχήματος. Τα προσαρμοσμένα τμήματα XML είναι χρήσιμα για ενσωματώσεις που αποθηκεύουν πληροφορίες όπως αναγνωριστικά διαχείρισης εγγράφων, κατάσταση ροής εργασίας, μεταδεδομένα συμμόρφωσης, δεδομένα σύνδεσης προτύπου ή άλλα δομημένα δεδομένα εφαρμογής μέσα σε μια παρουσίαση.

## **Αποθήκευση Δεδομένων σε Αρχεία Παρουσίασης**

Τα αρχεία PPTX—αρχεία με την επέκταση `.pptx`—αποθηκεύονται στη μορφή PresentationML, η οποία αποτελεί μέρος του προτύπου Office Open XML. Το Office Open XML ορίζει τη δομή του πακέτου και τις σχέσεις που χρησιμοποιούνται για την αποθήκευση του περιεχομένου της παρουσίασης και των σχετικών δεδομένων.

Μια παρουσίαση περιέχει πολλαπλά τμήματα συνδεδεμένα με σχέσεις. Για παράδειγμα, ένα τμήμα διαφάνειας περιέχει το περιεχόμενο μιας μοναδικής διαφάνειας και μπορεί να έχει ρητές σχέσεις με άλλα τμήματα που ορίζονται από το ISO/IEC 29500.

Τα προσαρμοσμένα δεδομένα μπορούν να αποθηκευτούν ως ετικέτες ([ITagCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/itagcollection/)) ή προσαρμοσμένα τμήματα XML ([ICustomXmlPartCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/icustomxmlpartcollection/)). Και τα δύο είναι διαθέσιμα μέσω της διεπαφής [`ICustomData`](https://reference.aspose.com/slides/el/cpp/aspose.slides/icustomdata/) .

{{% alert color="primary" %}}
Οι ετικέτες αποθηκεύουν απλά ζευγάρια κλειδιού‑ τιμής συμβολοσειράς. Τα προσαρμοσμένα τμήματα XML αποθηκεύουν δομημένα δεδομένα XML και μπορούν να συσχετιστούν με μια παρουσίαση, διαφάνεια ή σχήμα.
{{% /alert %}}

## **Εργασία με Προσαρμοσμένα Τμήματα XML**

Η μέθοδος [`ICustomData::get_CustomXmlParts`](https://reference.aspose.com/slides/el/cpp/aspose.slides/icustomdata/get_customxmlparts/) επιστρέφει τη συλλογή των προσαρμοσμένων τμημάτων XML που σχετίζονται με ένα συγκεκριμένο αντικείμενο παρουσίασης. Για παράδειγμα:

- `presentation->get_CustomData()->get_CustomXmlParts()` περιέχει προσαρμοσμένα τμήματα XML που σχετίζονται με την ίδια την παρουσίαση.
- `slide->get_CustomData()->get_CustomXmlParts()` περιέχει προσαρμοσμένα τμήματα XML που σχετίζονται με μια συγκεκριμένη διαφάνεια.
- `shape->get_CustomData()->get_CustomXmlParts()` περιέχει προσαρμοσμένα τμήματα XML που σχετίζονται με ένα συγκεκριμένο σχήμα.

Χρησιμοποιήστε το [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_allcustomxmlparts/) όταν χρειάζεται να εξετάσετε όλα τα προσαρμοσμένα τμήματα XML στην παρουσίαση ανεξάρτητα από το που είναι συσχετισμένα.

### **Προσθήκη Προσαρμοσμένου Τμήματος XML σε Παρουσίαση**

Χρησιμοποιήστε το [`ICustomXmlPartCollection::Add`](https://reference.aspose.com/slides/el/cpp/aspose.slides/icustomxmlpartcollection/add/) για να προσθέσετε δεδομένα XML σε μια συλλογή προσαρμοσμένων τμημάτων XML. Το XML πρέπει να είναι έγκυρο και μη κενό.

Το παρακάτω παράδειγμα προσθέτει δομημένα μεταδεδομένα στη συλλογή δεδομένων σε επίπεδο παρουσίασης:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPart.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/guid.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::String customXmlContent =
    u"<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
    u"<metadata xmlns=\"urn:example:metadata\">"
        u"<documentId>DOC-1001</documentId>"
        u"<workflowState>Draft</workflowState>"
    u"</metadata>";

auto presentation = System::MakeObject<Presentation>();
auto customXmlPart = presentation->get_CustomData()->get_CustomXmlParts()->Add(customXmlContent);

// Η προσθήκη εκχωρεί ένα αναγνωριστικό αυτόματα. Ορίστε ένα συγκεκριμένο GUID μόνο όταν απαιτείται.
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"presentation_with_custom_xml.pptx", SaveFormat::Pptx);
```

Η μέθοδος `Add` μπορεί επίσης να δέχεται XML ως πίνακα byte ή ροή, κάτι που είναι χρήσιμο όταν το περιεχόμενο XML είναι ήδη διαθέσιμο σε δυαδική μορφή.

### **Προσθήκη Προσαρμοσμένου Τμήματος XML σε Διαφάνεια ή Σχήμα**

Τα προσαρμοσμένα δεδομένα XML μπορούν να συσχετιστούν με μια συγκεκριμένη διαφάνεια ή σχήμα αντί για ολόκληρη την παρουσίαση. Αυτό είναι χρήσιμο όταν τα μεταδεδομένα περιγράφουν μόνο ένα αντικείμενο, όπως κλειδί προτύπου, εξωτερικό αναγνωριστικό εγγραφής ή πληροφορίες σύνδεσης.

Το παρακάτω παράδειγμα προσθέτει ένα προσαρμοσμένο τμήμα XML σε μια διαφάνεια και άλλο σε ένα σχήμα:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

slide->get_CustomData()->get_CustomXmlParts()->Add(
    u"<slideMetadata xmlns=\"urn:example:slides\">"
        u"<templateKey>TitleSlide</templateKey>"
    u"</slideMetadata>");

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 250.0f, 80.0f);

shape->get_TextFrame()->set_Text(u"Customer data");
shape->get_CustomData()->get_CustomXmlParts()->Add(
    u"<shapeMetadata xmlns=\"urn:example:shapes\">"
        u"<recordId>CRM-4281</recordId>"
    u"</shapeMetadata>");

presentation->Save(u"object_custom_xml.pptx", SaveFormat::Pptx);
```

Το επίπεδο στο οποίο προστίθεται ένα τμήμα καθορίζει ποια συλλογή `get_CustomData()->get_CustomXmlParts()` του αντικειμένου περιέχει τη σχέση με το τμήμα. Τα δεδομένα σε επίπεδο παρουσίασης είναι κατάλληλα για μεταδεδομένα σε όλο το έγγραφο, τα δεδομένα σε επίπεδο διαφάνειας για πληροφορίες που ανήκουν σε συγκεκριμένη διαφάνεια, και τα δεδομένα σε επίπεδο σχήματος για μεταδεδομένα που συνδέονται με ένα μεμονωμένο σχήμα.

### **Καταγραφή και Έλεγχος Όλων των Προσαρμοσμένων Τμημάτων XML**

Χρησιμοποιήστε το [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_allcustomxmlparts/) για να ανακτήσετε όλα τα προσαρμοσμένα τμήματα XML από μια παρουσίαση. Κάθε [`ICustomXmlPart`](https://reference.aspose.com/slides/el/cpp/aspose.slides/icustomxmlpart/) εκθέτει το αναγνωριστικό του, το περιεχόμενο XML και τα συνδεδεμένα σχήματα ονομάτων χώρου.

Το παρακάτω παράδειγμα εμφανίζει όλα τα προσαρμοσμένα τμήματα XML και τα σχήματα ονομάτων χώρου τους:

```cpp
#include <DOM/ICustomXmlPart.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (auto customXmlPart : presentation->get_AllCustomXmlParts())
{
    System::Console::WriteLine(System::String(u"ItemId: ") + customXmlPart->get_ItemId().ToString());
    System::Console::WriteLine(u"XML:");
    System::Console::WriteLine(customXmlPart->get_XmlAsString());

    for (auto namespaceSchema : customXmlPart->get_NamespaceSchemas())
    {
        System::Console::WriteLine(System::String(u"Namespace schema: ") + namespaceSchema);
    }

    System::Console::WriteLine();
}
```

Η μέθοδος [`ICustomXmlPart::get_NamespaceSchemas`](https://reference.aspose.com/slides/el/cpp/aspose.slides/icustomxmlpart/get_namespaceschemas/) επιστρέφει τα σχήματα XML που συνδέονται με το προσαρμοσμένο τμήμα XML. Αυτή η πληροφορία μπορεί να είναι χρήσιμη κατά τον έλεγχο παρουσιάσεων που περιέχουν XML που παράγεται από εξωτερικά συστήματα.

### **Ανάγνωση και Ενημέρωση Περιεχομένου XML και ItemId**

Χρησιμοποιήστε τα [`ICustomXmlPart::get_XmlAsString`](https://reference.aspose.com/slides/el/cpp/aspose.slides/icustomxmlpart/get_xmlasstring/) και `set_XmlAsString` για εργασία με XML ως συμβολοσειρά UTF‑8, ή τα [`ICustomXmlPart::get_XmlData`](https://reference.aspose.com/slides/el/cpp/aspose.slides/icustomxmlpart/get_xmldata/) και `set_XmlData` για εργασία με ακατέργαστα bytes XML. Και οι δύο αναπαραστάσεις μπορούν να διαβαστούν και να ενημερωθούν.

Η μέθοδος [`ICustomXmlPart::get_ItemId`](https://reference.aspose.com/slides/el/cpp/aspose.slides/icustomxmlpart/get_itemid/) επιστρέφει το GUID που αναγνωρίζει το προσαρμοσμένο τμήμα XML στο έγγραφο Office Open XML. Το αναγνωριστικό μπορεί επίσης να αλλάξει με `set_ItemId` όταν μια ενσωμάτωση απαιτεί νέο αναγνωριστικό.

Το παρακάτω παράδειγμα ενημερώνει το περιεχόμενο XML και το αναγνωριστικό:

```cpp
#include <DOM/ICustomXmlPart.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/guid.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto customXmlPart = presentation->get_AllCustomXmlParts()->idx_get(0);

// Διαβάστε το τρέχον XML ως κείμενο.
auto currentXmlContent = customXmlPart->get_XmlAsString();
System::Console::WriteLine(currentXmlContent);

// Ενημερώστε το XML ως συμβολοσειρά UTF-8.
customXmlPart->set_XmlAsString(
    u"<metadata xmlns=\"urn:example:metadata\">"
        u"<documentId>DOC-1001</documentId>"
        u"<workflowState>Approved</workflowState>"
    u"</metadata>");

// Το XmlData παρέχει το ίδιο περιεχόμενο XML ως ακατέργαστα bytes.
auto customXmlData = customXmlPart->get_XmlData();
System::Console::WriteLine(System::Text::Encoding::get_UTF8()->GetString(customXmlData));

// Αντικαταστήστε το αναγνωριστικό όταν απαιτείται από την ενσωμάτωση.
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"updated_custom_xml.pptx", SaveFormat::Pptx);
```

Κατά την ανάθεση XML με `set_XmlAsString` ή `set_XmlData`, παρέχετε έγκυρο, μη κενό XML. Χρησιμοποιήστε τη μία ή την άλλη αναπαράσταση ανάλογα με το αν η εφαρμογή δουλεύει κυρίως με συμβολοσειρές ή με δεδομένα byte.

### **Αφαίρεση Προσαρμοσμένου Τμήματος XML**

Το Aspose.Slides παρέχει αρκετούς τρόπους αφαίρεσης προσαρμοσμένων δεδομένων XML:

- [`ICustomXmlPart::Remove`](https://reference.aspose.com/slides/el/cpp/aspose.slides/icustomxmlpart/remove/) αφαιρεί το προσαρμοσμένο τμήμα XML από την παρουσίαση.
- [`ICustomXmlPartCollection::Remove`](https://reference.aspose.com/slides/el/cpp/aspose.slides/icustomxmlpartcollection/remove/) αφαιρεί ένα συγκεκριμένο τμήμα από μια συλλογή προσαρμοσμένων τμημάτων XML.
- [`ICustomXmlPartCollection::RemoveAt`](https://reference.aspose.com/slides/el/cpp/aspose.slides/icustomxmlpartcollection/removeat/) αφαιρεί το τμήμα στη συγκεκριμένη θέση της συλλογής.
- [`ICustomXmlPartCollection::Clear`](https://reference.aspose.com/slides/el/cpp/aspose.slides/icustomxmlpartcollection/clear/) αφαιρεί όλα τα τμήματα από μια συγκεκριμένη συλλογή.

Το παρακάτω παράδειγμα αφαιρεί ένα προσαρμοσμένο τμήμα XML σε επίπεδο παρουσίασης με αναφορά:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto customXmlParts = presentation->get_CustomData()->get_CustomXmlParts();

if (customXmlParts->get_Count() > 0)
{
    auto customXmlPart = customXmlParts->idx_get(0);
    customXmlParts->Remove(customXmlPart);
}

presentation->Save(u"custom_xml_removed.pptx", SaveFormat::Pptx);
```

Αν έχετε ήδη ένα αντικείμενο `ICustomXmlPart` και θέλετε να το αφαιρέσετε από την παρουσίαση αντί να στοχεύσετε μια συγκεκριμένη συλλογή, καλέστε `customXmlPart->Remove()`.

Μπορείτε επίσης να αφαιρέσετε ένα στοιχείο με βάση το δείκτη:

```cpp
presentation->get_CustomData()->get_CustomXmlParts()->RemoveAt(0);
```

### **Καθαρισμός Όλων των Προσαρμοσμένων Τμημάτων XML από μια Συλλογή**

Χρησιμοποιήστε `Clear` όταν πρέπει να αφαιρεθούν όλα τα προσαρμοσμένα τμήματα XML που σχετίζονται με ένα συγκεκριμένο αντικείμενο παρουσίασης.

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->get_Slides()->idx_get(0)->get_CustomData()->get_CustomXmlParts()->Clear();

presentation->Save(u"slide_custom_xml_cleared.pptx", SaveFormat::Pptx);
```

Το `Clear` επηρεάζει μόνο τη συλλογή που έχει επιλεγεί. Για παράδειγμα, ο καθαρισμός της συλλογής μιας διαφάνειας δεν καθαρίζει τις συλλογές σε επίπεδο παρουσίασης ή σχήματος.

Για να αφαιρέσετε κάθε προσαρμοσμένο τμήμα XML στην παρουσίαση, επαναλάβετε το `get_AllCustomXmlParts()` και αφαιρέστε κάθε τμήμα:

```cpp
#include <DOM/ICustomXmlPart.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (auto customXmlPart : presentation->get_AllCustomXmlParts())
{
    customXmlPart->Remove();
}

presentation->Save(u"all_custom_xml_removed.pptx", SaveFormat::Pptx);
```

### **Διαχείριση Συνδεδεμένων ή Κοινόχρηστων Προσαρμοσμένων Τμημάτων XML**

Σε μια παρουσίαση Office Open XML, το ίδιο προσαρμοσμένο τμήμα XML μπορεί να αναφέρεται από περισσότερα από ένα αντικείμενα παρουσίασης. Για παράδειγμα, ένα υπάρχον αρχείο μπορεί να περιέχει σχέσεις από πολλαπλές διαφάνειες ή σχήματα προς το ίδιο υποκείμενο προσαρμοσμένο τμήμα XML.

Ένα κοινόχρηστο τμήμα πρέπει να θεωρείται ως ένα αντικείμενο δεδομένων με πολλαπλές αναφορές:

- Η ενημέρωσή του με `set_XmlAsString`, `set_XmlData` ή `set_ItemId` αλλάζει το υποκείμενο τμήμα XML, οπότε η αλλαγή ισχύει όπου και αν το τμήμα αναφέρεται.
- Το `get_ItemId()` μπορεί να χρησιμοποιηθεί για την ταυτοποίηση του ίδιου προσαρμοσμένου τμήματος XML κατά τον έλεγχο συλλογών σε επίπεδο αντικειμένου.
- Η αφαίρεση ενός τμήματος από μια συγκεκριμένη συλλογή `get_CustomXmlParts()` το αφαιρεί μόνο από εκείνη τη συλλογή. Χρησιμοποιήστε `ICustomXmlPart::Remove()` όταν το τμήμα πρέπει να αφαιρεθεί πλήρως από την παρουσίαση.
- Πριν διαγράψετε ή αντικαταστήσετε ένα κοινόχρηστο τμήμα, ελέγξτε τις συλλογές σε επίπεδο αντικειμένου για να διαπιστώσετε εάν άλλες διαφάνειες ή σχήματα το αναφέρουν ακόμη.

Οι υπερφορτώσεις της `Add` δημιουργούν νέο προσαρμοσμένο τμήμα XML από το περιεχόμενο XML· δεν δέχονται υπάρχον `ICustomXmlPart`. Συνεπώς, οι κοινές σχέσεις εμφανίζονται συνήθως όταν φορτώνονται παρουσιάσεις που τα περιέχουν ήδη.

Το παρακάτω παράδειγμα ελέγχει τις συλλογές σε επίπεδο παρουσίασης, διαφάνειας και σχήματος βάσει `ItemId` και αναφέρει τμήματα που αναφέρονται από περισσότερα από ένα σημεία:

```cpp
#include <algorithm>
#include <vector>
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPart.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/guid.h>
#include <system/string.h>

using namespace Aspose::Slides;

struct CustomXmlReferenceEntry
{
    System::Guid itemId;
    std::vector<System::String> owners;
};

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
std::vector<CustomXmlReferenceEntry> referencesByItemId;

auto registerCustomXmlParts = [&referencesByItemId](
    const System::String& ownerName,
    const System::SharedPtr<ICustomXmlPartCollection>& customXmlParts)
{
    for (int32_t partIndex = 0; partIndex < customXmlParts->get_Count(); ++partIndex)
    {
        auto customXmlPart = customXmlParts->idx_get(partIndex);
        auto itemId = customXmlPart->get_ItemId();

        auto entry = std::find_if(
            referencesByItemId.begin(),
            referencesByItemId.end(),
            [&itemId](const CustomXmlReferenceEntry& referenceEntry)
            {
                return referenceEntry.itemId == itemId;
            });

        if (entry == referencesByItemId.end())
        {
            referencesByItemId.push_back({ itemId, { ownerName } });
        }
        else
        {
            entry->owners.push_back(ownerName);
        }
    }
};

registerCustomXmlParts(u"Presentation", presentation->get_CustomData()->get_CustomXmlParts());

for (int32_t slideIndex = 0; slideIndex < presentation->get_Slides()->get_Count(); ++slideIndex)
{
    auto slide = presentation->get_Slides()->idx_get(slideIndex);
    registerCustomXmlParts(
        System::String::Format(u"Slide {0}", slideIndex + 1),
        slide->get_CustomData()->get_CustomXmlParts());

    for (int32_t shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
    {
        auto shape = slide->get_Shapes()->idx_get(shapeIndex);
        registerCustomXmlParts(
            System::String::Format(u"Slide {0}, shape {1}", slideIndex + 1, shapeIndex),
            shape->get_CustomData()->get_CustomXmlParts());
    }
}

for (const auto& referenceEntry : referencesByItemId)
{
    if (referenceEntry.owners.size() > 1)
    {
        System::Console::WriteLine(
            System::String(u"Shared custom XML part: ") + referenceEntry.itemId.ToString());

        for (const auto& ownerName : referenceEntry.owners)
        {
            System::Console::WriteLine(System::String(u"  Referenced by: ") + ownerName);
        }
    }
}
```

Αυτός ο τύπος ελέγχου είναι χρήσιμος πριν από την τροποποίηση ή διαγραφή προσαρμοσμένων δεδομένων XML σε παρουσιάσεις που δημιουργήθηκαν από εξωτερικά συστήματα, επειδή το ίδιο τμήμα μεταδεδομένων μπορεί να συμμετέχει σε περισσότερες από μία σχέσεις.

## **Λήψη Τιμών Ετικετών**

Στις διαφάνειες, μια ετικέτα αντιστοιχεί στην ιδιότητα `IDocumentProperties::get_Keywords`. Αυτό το δείγμα κώδικα δείχνει πώς να λάβετε τιμή ετικέτας με το Aspose.Slides for C++ για [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) :

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto keywords = presentation->get_DocumentProperties()->get_Keywords();
```

## **Προσθήκη Ετικετών σε Παρουσιάσεις**

Το Aspose.Slides επιτρέπει την προσθήκη ετικετών σε παρουσιάσεις. Μια ετικέτα συνήθως αποτελείται από δύο στοιχεία:

- το όνομα μιας προσαρμοσμένης ιδιότητας, π.χ. `MyTag`;
- την τιμή της προσαρμοσμένης ιδιότητας, π.χ. `My Tag Value`.

Αν χρειάζεται να ταξινομήσετε παρουσιάσεις βάσει ενός συγκεκριμένου κανόνα ή ιδιότητας, μπορείτε να προσθέσετε ετικέτες για αυτόν τον σκοπό. Για παράδειγμα, αν θέλετε να κατηγοριοποιήσετε παρουσιάσεις από βόρειες αμερικανικές χώρες, μπορείτε να δημιουργήσετε μια ετικέτα “North American” και να αναθέσετε τη σχετική χώρα ως τιμή.

Αυτό το δείγμα κώδικα δείχνει πώς να προσθέσετε μια ετικέτα σε μια [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) χρησιμοποιώντας το Aspose.Slides for C++ :

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ITagCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto tags = presentation->get_CustomData()->get_Tags();
tags->idx_set(u"MyTag", u"My Tag Value");
```

Οι ετικέτες μπορούν επίσης να οριστούν για μια [Slide](https://reference.aspose.com/slides/el/cpp/aspose.slides/slide/) :

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITagCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

Ή για ένα μεμονωμένο [Shape](https://reference.aspose.com/slides/el/cpp/aspose.slides/shape/) :

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICustomData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITagCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

### **Περιορισμοί**

Οι ετικέτες που προστίθενται μέσω της συλλογής `get_CustomData()->get_Tags()` αποθηκεύονται μόνο στο αρχείο PowerPoint. Δεν μεταφέρονται στη δομή ετικετών PDF όταν η παρουσίαση εξάγεται σε PDF. Συνεπώς, ένας προσαρμοσμένος αναγνωριστής που έχει οριστεί ως ετικέτα δεν μπορεί να ανακτηθεί από το PDF με ετικέτες.

**Λύση**: Μπορείτε να αποθηκεύσετε έναν προσαρμοσμένο αναγνωριστή στο **Alt Text** του αντικειμένου (π.χ. `shape->set_AlternativeText(u"MyId")`). Μετά την εξαγωγή σε PDF, το Alt Text μπορεί να εμφανιστεί στη δομή ετικετών του PDF.

## **ΣΥΝΑΡΤΑΣΕΙΣ (FAQ)**

**Μπορώ να αφαιρέσω όλες τις ετικέτες από μια παρουσίαση, διαφάνεια ή σχήμα με μία ενέργεια;**

Ναι. Η [συλλογή ετικετών](https://reference.aspose.com/slides/el/cpp/aspose.slides/tagcollection/) υποστηρίζει τη λειτουργία [Clear](https://reference.aspose.com/slides/el/cpp/aspose.slides/tagcollection/clear/) που διαγράφει όλα τα ζευγάρια κλειδιού‑ τιμής ταυτόχρονα.

**Πώς διαγράφω μια μεμονωμένη ετικέτα με βάση το όνομά της χωρίς να περάσω όλη τη συλλογή;**

Χρησιμοποιήστε [Remove(name)](https://reference.aspose.com/slides/el/cpp/aspose.slides/tagcollection/remove/) στην [TagCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/tagcollection/) για να διαγράψετε την ετικέτα με το κλειδί της.

**Πώς μπορώ να ανακτήσω την πλήρη λίστα ονομάτων ετικετών για ανάλυση ή φιλτράρισμα;**

Χρησιμοποιήστε [GetNamesOfTags](https://reference.aspose.com/slides/el/cpp/aspose.slides/tagcollection/getnamesoftags/) στην [συλλογή ετικετών](https://reference.aspose.com/slides/el/cpp/aspose.slides/tagcollection/); επιστρέφει έναν πίνακα με όλα τα ονόματα ετικετών.

**Πώς μπορώ να βρω όλα τα προσαρμοσμένα τμήματα XML ανεξάρτητα από το που αποθηκεύονται;**

Χρησιμοποιήστε το [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_allcustomxmlparts/) για να ανακτήσετε όλα τα προσαρμοσμένα τμήματα XML στην παρουσίαση.

**Πρέπει να χρησιμοποιήσω `get_XmlAsString`/`set_XmlAsString` ή `get_XmlData`/`set_XmlData` για την ενημέρωση ενός προσαρμοσμένου τμήματος XML;**

Χρησιμοποιήστε `get_XmlAsString` και `set_XmlAsString` όταν η εφαρμογή εργάζεται με κείμενο XML UTF‑8. Χρησιμοποιήσετε `get_XmlData` και `set_XmlData` όταν το XML είναι ήδη διαθέσιμο ως πίνακας byte ή όταν η επεξεργασία σε δυαδική μορφή είναι πιο βολική. Και οι δύο αναπαραστάσεις αναφέρονται στο ίδιο περιεχόμενο XML του προσαρμοσμένου τμήματος.