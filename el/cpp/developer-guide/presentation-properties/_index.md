---
title: Διαχείριση Ιδιοτήτων Παρουσίασης σε C++
linktitle: Ιδιότητες Παρουσίασης
type: docs
weight: 70
url: /el/cpp/presentation-properties/
keywords:
- Ιδιότητες PowerPoint
- Ιδιότητες παρουσίασης
- Ιδιότητες εγγράφου
- Ενσωματωμένες ιδιότητες
- Προσαρμοσμένες ιδιότητες
- Προηγμένες ιδιότητες
- Διαχείριση ιδιοτήτων
- Τροποποίηση ιδιοτήτων
- Μεταδεδομένα εγγράφου
- Επεξεργασία μεταδεδομένων
- Γλώσσα επιμέλειας
- Προεπιλεγμένη γλώσσα
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Διαχειριστείτε τις κύριες ιδιότητες παρουσίασης στο Aspose.Slides για C++ και βελτιστοποιήστε την αναζήτηση, την εμπορική σήμανση και τη ροή εργασίας στα αρχεία PowerPoint και OpenDocument."
---
## **Εισαγωγή**

Το Aspose.Slides για C++ υποστηρίζει **ενσωματωμένες** και **προσαρμοσμένες** ιδιότητες εγγράφου. Χρησιμοποιήστε αυτές τις ιδιότητες για ανάγνωση και ενημέρωση μεταδεδομένων παρουσίασης, όπως ο συγγραφέας, ο τίτλος και οι τιμές που ορίζονται από τον χρήστη.

Το Aspose.Slides σας επιτρέπει να εργάζεστε με ιδιότητες εγγράφου παρουσίασης μέσω του περιβάλλοντος [IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/). Μια παρουσίαση αυτής της διεπαφής επιστρέφεται από το [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/). Τα παρακάτω παραδείγματα δείχνουν πώς να διαβάζετε, να τροποποιείτε και να διαχειρίζεστε αυτές τις ιδιότητες.

{{% alert color="info" title="Note" %}}
Το Aspose.Slides διαχειρίζεται τα μεταδεδομένα της εφαρμογής και του παραγωγού κατά την αποθήκευση παρουσιάσεων· αυτά τα πεδία αναγνωρίζουν το λογισμικό που δημιούργησε το αποτέλεσμα.
{{% /alert %}}

## **Διαχείριση Ιδιοτήτων Παρουσίασης**

Οι ιδιότητες εγγράφου αποθηκεύουν περιγραφικές πληροφορίες μαζί με το περιεχόμενο της παρουσίασης. Κατατάσσονται σε δύο κατηγορίες:

- **Ενσωματωμένες ιδιότητες** περιέχουν τυπικά μεταδεδομένα, όπως ο τίτλος, ο συγγράφος και οι στατιστικές του εγγράφου.
- **Προσαρμοσμένες ιδιότητες** αποθηκεύουν ζεύγη ονομαστικού/τιμής που ορίζονται από το χρήστη.

Το Aspose.Slides για C++ παρέχει πρόσβαση και στις δύο κατηγορίες. Στο PowerPoint, επιλέξτε **File → Info → Properties → Advanced Properties** για να εξετάσετε τα μεταδεδομένα του εγγράφου. Ο διάλογος ομαδοποιεί τις πληροφορίες σε καρτέλες όπως **Summary**, **Statistics**, **Contents**, και **Custom**. Χρησιμοποιήστε την καρτέλα **Custom** για να διαχειριστείτε τις ιδιότητες που ορίζει ο χρήστης.

## **Ανάγνωση Δημοσίων Ιδιοτήτων από Κρυπτογραφημένη Παρουσίαση**

Ένας κωδικός ανοίγματος συνήθως προστατεύει τόσο το περιεχόμενο της παρουσίασης όσο και τις ιδιότητες του εγγράφου. Όταν μια παρουσίαση κρυπτογραφείται περνώντας `false` στη μέθοδο [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/), οι ιδιότητες του εγγράφου παραμένουν δημόσιες. Στη συνέχεια μια εφαρμογή μπορεί να περάσει `true` στη μέθοδο [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) και να διαβάσει τα δημόσια μεταδεδομένα χωρίς να παράσχει τον κωδικό ανοίγματος.

[LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) ελέγχει τι φορτώνει το Aspose.Slides· δεν αποκρυπτογραφεί τίποτα. Εάν οι ιδιότητες περιλαμβάνονταν στην κρυπτογράφηση, η φόρτωση χωρίς κωδικό αποτυγχάνει. Εάν η παρουσίαση δεν είναι κρυπτογραφημένη, η επιλογή αγνοείται και φορτώνεται η πλήρης παρουσίαση.

Το παράδειγμα απαιτεί μια κρυπτογραφημένη παρουσίαση της οποίας οι ιδιότητες εγγράφου έχουν παραμείνει δημόσιες. Επαληθεύει τη λειτουργία φόρτωσης μέσω του [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) και στη συνέχεια διαβάζει τις ενσωματωμένες ιδιότητες μέσω του [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/):

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <DOM/LoadOptions.h>
#include <DOM/IProtectionManager.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = System::MakeObject<Presentation>(u"public-properties-encrypted.pptx", loadOptions);

if (presentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    auto documentProperties = presentation->get_DocumentProperties();

    System::Console::WriteLine(u"Author: {0}", documentProperties->get_Author());
    System::Console::WriteLine(u"Title: {0}", documentProperties->get_Title());
    System::Console::WriteLine(u"Keywords: {0}", documentProperties->get_Keywords());
}
else
{
    System::Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}
```

Σε αυτή τη λειτουργία, το περιεχόμενο των διαφανειών δεν φορτώνεται. Οι διαφάνειες, τα master, οι διατάξεις, τα σχήματα, τα πολυμέσα και άλλα αντικείμενα παρουσίασης δεν είναι διαθέσιμα. Οι εφαρμογές πρέπει πάντα να ελέγχουν το [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) πριν εκτελέσουν ενέργεια που απαιτεί το πλήρες μοντέλο αντικειμένων παρουσίασης.

{{% alert color="warning" title="Security" %}}
Τα δημόσια μεταδεδομένα μπορεί να εκθέτουν ονόματα συγγραφέων, τίτλους, θέματα, λέξεις-κλειδιά, πληροφορίες εταιρείας, σχόλια και προσαρμοσμένες τιμές. Κρυπτογραφήστε τα ευαίσθητα στοιχεία μαζί με την παρουσίαση. Κρατήστε τα δημόσια μόνο όταν η αρχειοθέτηση, η ταξινόμηση, η αναζήτηση ή τα συστήματα διαχείρισης εγγράφων έχουν συγκεκριμένη ανάγκη πρόσβασης χωρίς κωδικό.
{{% /alert %}}

## **Ενημέρωση Ιδιοτήτων Κρυπτογραφημένης Παρουσίασης**

Για ένα κρυπτογραφημένο αρχείο PPTX, μια παρουσίαση που φορτώνεται περνώντας `true` στη μέθοδο [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) προορίζεται για ανάγνωση δημόσιων μεταδεδομένων. Το Aspose.Slides δεν μπορεί να αποθηκεύσει τις αλλαγμένες ιδιότητες από αυτό το αντικείμενο μόνο-με-μεταδεδομένα, επειδή οι δημόσιες ιδιότητες πρέπει να παραμείνουν σύμφωνες με τα αντίστοιχα δεδομένα μέσα στην κρυπτογραφημένη παρουσίαση. Η ενημέρωσή τους απαιτεί therefore τον σωστό κωδικό ανοίγματος και πλήρη φόρτωση.

Το παράδειγμα απαιτεί μια κρυπτογραφημένη παρουσίαση PPTX με δημόσιες ιδιότητες εγγράφου και γνωστό κωδικό ανοίγματος. Ανοίγει την πλήρη παρουσίαση με τη μέθοδο [LoadOptions::set_Password](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_password/), ενημερώνει τις δημόσιες ενσωματωμένες ιδιότητες και αποθηκεύει το αποτέλεσμα. Στη συνέχεια χρησιμοποιεί το [IPresentationInfo::get_IsEncrypted](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/get_isencrypted/) για να επαληθεύσει ότι η κρυπτογράφηση παραμένει και ανοίγει ξανά τα δημόσια μεταδεδομένα χωρίς κωδικό για να ελέγξει τις νέες τιμές:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <DOM/LoadOptions.h>
#include <DOM/IProtectionManager.h>
#include <DOM/PresentationFactory.h>
#include <DOM/IPresentationInfo.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

const System::String inputPath = u"public-properties-encrypted.pptx";
const System::String outputPath = u"updated-public-properties-encrypted.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(inputPath, loadOptions);

auto documentProperties = presentation->get_DocumentProperties();
documentProperties->set_Title(u"Updated Product Roadmap");
documentProperties->set_Keywords(u"roadmap, planning, indexed");

presentation->Save(outputPath, SaveFormat::Pptx);

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(outputPath);
System::Console::WriteLine(u"The presentation is encrypted: {0}", presentationInfo->get_IsEncrypted());

auto metadataLoadOptions = System::MakeObject<LoadOptions>();
metadataLoadOptions->set_OnlyLoadDocumentProperties(true);

auto metadataPresentation = System::MakeObject<Presentation>(outputPath, metadataLoadOptions);

if (metadataPresentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    System::Console::WriteLine(u"Title: {0}", metadataPresentation->get_DocumentProperties()->get_Title());
    System::Console::WriteLine(u"Keywords: {0}", metadataPresentation->get_DocumentProperties()->get_Keywords());
}
else
{
    System::Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}
```

Εάν μια εφαρμογή δεν επιτρέπεται να αποκρυπτογραφήσει ή να φορτώσει το περιεχόμενο της παρουσίασης, πρέπει να αντιμετωπίζει τις δημόσιες ιδιότητες ενός κρυπτογραφημένου αρχείου PPTX ως μόνο για ανάγνωση.

## **Πρόσβαση σε Ενσωματωμένες Ιδιότητες**

Η διεπαφή [IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/) εκθέτει ενσωματωμένα μεταδεδομένα μέσω τυποποιημένων getters, όπως [get_Author](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_author/), [get_Title](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_title/) και [get_CreatedTime](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_createdtime/). Αυτό το παράδειγμα ανοίγει μια υπάρχουσα παρουσίαση και εκτυπώνει τα αποθηκευμένα μεταδεδομένα στην κονσόλα. Οι τιμές εξαρτώνται από την είσοδο της παρουσίασης· ορισμένα πεδία μπορεί να είναι κενά.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"AccessBuiltInProperties.pptx");

auto documentProperties = presentation->get_DocumentProperties();

System::Console::WriteLine(u"Category: {0}", documentProperties->get_Category());
System::Console::WriteLine(u"Content status: {0}", documentProperties->get_ContentStatus());
System::Console::WriteLine(u"Creation date: {0}", documentProperties->get_CreatedTime());
System::Console::WriteLine(u"Author: {0}", documentProperties->get_Author());
System::Console::WriteLine(u"Comments: {0}", documentProperties->get_Comments());
System::Console::WriteLine(u"Keywords: {0}", documentProperties->get_Keywords());
System::Console::WriteLine(u"Last modified by: {0}", documentProperties->get_LastSavedBy());
System::Console::WriteLine(u"Manager: {0}", documentProperties->get_Manager());
System::Console::WriteLine(u"Modified date: {0}", documentProperties->get_LastSavedTime());
System::Console::WriteLine(u"Presentation format: {0}", documentProperties->get_PresentationFormat());
System::Console::WriteLine(u"Last print date: {0}", documentProperties->get_LastPrinted());
System::Console::WriteLine(u"Is shared between producers: {0}", documentProperties->get_SharedDoc());
System::Console::WriteLine(u"Subject: {0}", documentProperties->get_Subject());
System::Console::WriteLine(u"Title: {0}", documentProperties->get_Title());
```

## **Τροποποίηση Ενσωματωμένων Ιδιοτήτων**

Για να ενημερώσετε τα ενσωματωμένα μεταδεδομένα, χρησιμοποιήστε τις setters στο αντικείμενο που επιστρέφεται από το [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/). Αυτό το παράδειγμα ανοίγει μια υπάρχουσα παρουσίαση, καλεί τις μεθόδους [set_Author](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_author/), [set_Title](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_title/), [set_Subject](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_subject/), [set_Comments](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_comments/), και [set_Manager](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_manager/), στη συνέχεια αποθηκεύει την ενημερωμένη παρουσίαση με το [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/). Το αποθηκευμένο PPTX περιέχει τα νέα μεταδεδομένα.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"ModifyBuiltInProperties.pptx");

auto documentProperties = presentation->get_DocumentProperties();

documentProperties->set_Author(u"Aspose.Slides for C++");
documentProperties->set_Title(u"Manage PowerPoint Presentation Properties");
documentProperties->set_Subject(u"Modify Built-in Properties");
documentProperties->set_Comments(u"Aspose description");
documentProperties->set_Manager(u"Aspose manager");

presentation->Save(u"DocumentProperties_output.pptx", SaveFormat::Pptx);
```

## **Διαχείριση Βάσης Υπερσύνδεσμου**

Η μέθοδος [IDocumentProperties::get_HyperlinkBase](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_hyperlinkbase/) διαβάζει τη βάση εγγράφου για σχετικές υπερσυνδέσεις. Αυτό είναι χρήσιμο όταν μετακινείτε μια παρουσίαση και τα συνδεδεμένα της αρχεία σε άλλη τοποθεσία. Είναι ξεχωριστή από το [IHyperlink::get_ExternalUrl](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_externalurl/): η αλλαγή της βάσης δεν ξαναγράφει τις αποθηκευμένες διευθύνσεις των συνδέσμων ούτε αλλάζει τις απόλυτες προορισμούς.

Το παράδειγμα απαιτεί μια παρουσίαση που περιέχει τόσο μια σχετική σύνδεση, όπως `target.html`, όσο και μια απόλυτη σύνδεση, όπως `https://example.org/absolute.html`. Διαβάζει την υπάρχουσα βάση, ορίζει μια νέα διεύθυνση βάσης με τη [IDocumentProperties::set_HyperlinkBase](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_hyperlinkbase/), και αποθηκεύει και ξαναφορτώνει την παρουσίαση για να ελέγξει την τιμή. Στη συνέχεια αφαιρεί τη βάση με `u""` και επαληθεύει την κενή τιμή σε ξεχωριστό αποθηκευμένο αρχείο. Αντικαταστήστε τη διεύθυνση βάσης του παραδείγματος με τη θέση των συνδεδεμένων αρχείων σας.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"hyperlinks.pptx");

System::Console::WriteLine(u"Original base: {0}", presentation->get_DocumentProperties()->get_HyperlinkBase());

const System::String newBase = u"https://example.com/new/";
presentation->get_DocumentProperties()->set_HyperlinkBase(newBase);
presentation->Save(u"hyperlinks-updated.pptx", SaveFormat::Pptx);

auto updatedPresentation = System::MakeObject<Presentation>(u"hyperlinks-updated.pptx");
System::Console::WriteLine(u"Base preserved: {0}", (updatedPresentation->get_DocumentProperties()->get_HyperlinkBase() == newBase));

updatedPresentation->get_DocumentProperties()->set_HyperlinkBase(u"");
updatedPresentation->Save(u"hyperlinks-cleared.pptx", SaveFormat::Pptx);

auto clearedPresentation = System::MakeObject<Presentation>(u"hyperlinks-cleared.pptx");
System::Console::WriteLine(u"Base cleared: {0}", (clearedPresentation->get_DocumentProperties()->get_HyperlinkBase() == u""));
```

Τα δύο μηνύματα επαλήθευσης πρέπει να εκτυπώσουν `True`. Η εκκαθάριση της βάσης αφήνει ακέραιες τις διευθύνσεις των μεμονωμένων υπερσυνδέσμων.

Μια σχετική σύνδεση προς `target.pptx` άνοιγε `old/target.pptx` όταν η βάση έδειχνε στο φάκελο `old`. Αφού αλλάξατε τη βάση στο φάκελο `new`, αποθηκεύσατε και ξαναφορτώσατε την παρουσίαση, η ίδια σύνδεση άνοιξε `new/target.pptx`. Μια απόλυτη σύνδεση συνέχισε να ανοίγει το ίδιο αρχείο. Δοκιμάστε τις σχετικές συνδέσεις σας στο PowerPoint πριν και μετά τη μετακίνηση της παρουσίασης ή την αλλαγή της βάσης.

## **Προσθήκη Προσαρμοσμένων Ιδιοτήτων Παρουσίασης**

Οι προσαρμοσμένες ιδιότητες αποθηκεύουν μεταδεδομένα που δεν έχουν αντίστοιχο ενσωματωμένο πεδίο. Η μέθοδος [IDocumentProperties::idx_set](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_set/) σας επιτρέπει να αντιστοιχίσετε μια τιμή με βάση το όνομα της ιδιότητας. Αυτό το παράδειγμα δημιουργεί μια παρουσίαση, προσθέτει δύο τιμές κειμένου και μια ακέραια τιμή έκδοσης, και αποθηκεύει την παρουσίαση με το [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/). Η ανάθεση τιμής σε υπάρχον όνομα αντικαθιστά την τιμή της ιδιότητας.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto documentProperties = presentation->get_DocumentProperties();

documentProperties->idx_set(u"Reviewed by", System::ObjectExt::Box<System::String>(u"John Smith"));
documentProperties->idx_set(u"Confidentiality level", System::ObjectExt::Box<System::String>(u"Internal"));
documentProperties->idx_set(u"Document version", System::ObjectExt::Box(2));

presentation->Save(u"CustomDocumentProperties_output.pptx", SaveFormat::Pptx);
```

## **Πρόσβαση και Τροποποίηση Προσαρμοσμένων Ιδιοτήτων**

Αυτό το παράδειγμα ανοίγει μια παρουσίαση που περιέχει προσαρμοσμένες ιδιότητες και χρησιμοποιεί το [get_CountOfCustomProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_countofcustomproperties/) για να τις επαναλάβει. Η [GetCustomPropertyName](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/getcustompropertyname/) δέχεται ένα μηδενικό δείκτη και επιστρέφει το όνομα που χρησιμοποιείται από το [IDocumentProperties::idx_get](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_get/) και το [idx_set](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_set/). Το παράδειγμα εκτυπώνει κάθε αρχικό όνομα και τιμή, αντικαθιστά κάθε τιμή με μια αριθμημένη συμβολοσειρά ανεξαρτήτως του αρχικού τύπου, και αποθηκεύει τις αλλαγές. Εάν δεν υπάρχουν προσαρμοσμένες ιδιότητες, ο βρόχος δεν κάνει καμία αλλαγή.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"AccessAndModifyProperties.pptx");

auto documentProperties = presentation->get_DocumentProperties();

for (auto i = 0; i < documentProperties->get_CountOfCustomProperties(); i++)
{
    auto propertyName = documentProperties->GetCustomPropertyName(i);
    auto propertyValue = documentProperties->idx_get(propertyName);

    System::Console::WriteLine(u"Custom property name: {0}", propertyName);
    System::Console::WriteLine(u"Custom property value: {0}", propertyValue);

    documentProperties->idx_set(propertyName, System::ObjectExt::Box(System::String::Format(u"New Value {0}", i + 1)));
}

presentation->Save(u"CustomProperties_output.pptx", SaveFormat::Pptx);
```

## **Ζωντανό Παράδειγμα**

Δοκιμάστε την ηλεκτρονική εφαρμογή [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) για να δείτε πώς να εργάζεστε με τις ιδιότητες εγγράφου χρησιμοποιώντας το API του Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Πώς μπορώ να αφαιρέσω μια ενσωματωμένη ιδιότητα από μια παρουσίαση;**

Οι ενσωματωμένες ιδιότητες αποτελούν αναπόσπαστο μέρος της παρουσίασης και δεν μπορούν να αφαιρεθούν εντελώς. Ωστόσο, μπορείτε είτε να αλλάξετε τις τιμές τους είτε να τις ορίσετε κενές εάν αυτό επιτρέπεται από τη συγκεκριμένη ιδιότητα.

**Τι συμβαίνει αν προσθέσω μια προσαρμοσμένη ιδιότητα που υπάρχει ήδη;**

Εάν προσθέσετε μια προσαρμοσμένη ιδιότητα που υπάρχει ήδη, η υπάρχουσα τιμή της θα αντικατασταθεί με τη νέα. Δεν χρειάζεται να αφαιρέσετε ή να ελέγξετε την ιδιότητα εκ των προτέρων, αφού το Aspose.Slides ενημερώνει αυτόματα την τιμή της ιδιότητας.

**Μπορώ να έχω πρόσβαση στις ιδιότητες της παρουσίασης χωρίς να φορτώσω πλήρως την παρουσίαση;**

Ναι. Χρησιμοποιήστε το [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/cpp/aspose.slides/presentationfactory/getpresentationinfo/) και στη συνέχεια το [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) για να διαβάσετε τα αποθηκευμένα μεταδεδομένα εγγράφου χωρίς να δημιουργήσετε μια παρουσίαση [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) instance. Δείτε το [Δημιουργία Ελαφρού Καταλόγου Παρουσίασης](/slides/el/cpp/examine-presentation/) για ένα πλήρες παράδειγμα αναφοράς και περιορισμούς ανά μορφή.

**Μπορώ να διαβάσω τις δημόσιες ιδιότητες μιας κρυπτογραφημένης παρουσίασης χωρίς τον κωδικό ανοίγματος;**

Ναι. Η παρουσίαση πρέπει να έχει κρυπτογραφηθεί περνώντας `false` στη μέθοδο [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/), και πρέπει να φορτωθεί περνώντας `true` στη μέθοδο [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/).

**Μπορώ να ενημερώσω ένα κρυπτογραφημένο αρχείο PPTX σε λειτουργία μόνο-ιδιοτήτων-εγγράφου;**

Όχι. Τα δημόσια και κρυπτογραφημένα δεδομένα ιδιοτήτων πρέπει να παραμένουν σύμφωνα, επομένως η ενημέρωση ενός κρυπτογραφημένου αρχείου PPTX απαιτεί τη φόρτωση της πλήρης παρουσίασης με τον σωστό κωδικό ανοίγματος.