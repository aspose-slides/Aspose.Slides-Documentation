---
title: Προστασία Παρουσιάσεων με Κωδικό σε C++
linktitle: Προστασία Κωδικού
type: docs
weight: 20
url: /el/cpp/password-protected-presentation/
keywords:
- παρουσίαση με προστασία κωδικού
- κωδικός ανοίγματος
- κρυπτογράφηση PowerPoint
- αποκρυπτογράφηση PowerPoint
- επικύρωση κωδικού παρουσίασης
- έλεγχος κωδικού παρουσίασης
- άνοιγμα κρυπτογραφημένης παρουσίασης
- αφαίρεση κρυπτογράφησης
- PowerPoint
- PPT
- PPTX
- παρουσίαση
- C++
- Aspose.Slides
description: "Κρυπτογραφήστε, ανιχνεύστε, επικυρώστε, ανοίξτε και αποκρυπτογραφήστε παρουσιάσεις PowerPoint PPT και PPTX με προστασία κωδικού σε C++ χρησιμοποιώντας το Aspose.Slides."
---
## **Επισκόπηση**

Ένας κωδικός ανοίγματος κρυπτογραφεί μια παρουσίαση. Ο σωστός κωδικός απαιτείται για τη φόρτωση και την προβολή του περιεχομένου της παρουσίασης, έτσι αυτή η προστασία παρέχει εμπιστευτικότητα.

Ο κωδικός ανοίγματος είναι διαφορετικός από τον κωδικό προστασίας εγγραφής. Η προστασία εγγραφής περιορίζει την τροποποίηση αλλά δεν κρυπτογραφεί το περιεχόμενο ούτε εμποδίζει τη φόρτωση της παρουσίασης. Για τη διαχείριση κωδικών για την τροποποίηση παρουσιάσεων, δείτε [Προστασία παρουσίασης από εγγραφή](/slides/el/cpp/write-protected-presentation/).

Οι παρακάτω ροές εργασίας ισχύουν για παρουσιάσεις PPT και PPTX. Οι παραδείγματα χρησιμοποιούν και τις δύο μορφές όπου η συμπεριφορά τους βάσει αρχείου και ροής είναι σημαντική.

## **Κρυπτογράφηση παρουσίασης με κωδικό ανοίγματος**

Χρησιμοποιήστε το [IProtectionManager::Encrypt](https://reference.aspose.com/slides/el/cpp/aspose.slides/iprotectionmanager/encrypt/) για να ορίσετε έναν κωδικό ανοίγματος. Στη συνέχεια χρησιμοποιήστε το [IPresentation::Save](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentation/save/) για να αποθηκεύσετε την κρυπτογραφημένη παρουσίαση.

Το ακόλουθο παράδειγμα κρυπτογραφεί μια παρουσίαση PPTX:

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"open_password");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **Διατήρηση ιδιοτήτων εγγράφου δημόσιες**

Από προεπιλογή, το Aspose.Slides περιλαμβάνει τις ιδιότητες εγγράφου στην κρυπτογράφηση παρουσίασης. Το [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/el/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/) ελέγχει αυτή τη συμπεριφορά ανεξάρτητα από την κρυπτογράφηση του περιεχομένου των διαφανειών. Περάστε `false` σε αυτή τη μέθοδο πριν καλέσετε το [IProtectionManager::Encrypt](https://reference.aspose.com/slides/el/cpp/aspose.slides/iprotectionmanager/encrypt/) όταν ένα σύστημα καταλογοποίησης, ταξινόμησης, αναζήτησης ή διαχείρισης εγγράφων πρέπει να διαβάσει μεταδεδομένα χωρίς τον κωδικό ανοίγματος.

Το ακόλουθο παράδειγμα δημιουργεί μια κρυπτογραφημένη παρουσίαση PPTX ενώ αφήνει τις ενσωματωμένες ιδιότητες εγγράφου δημόσιες:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IProtectionManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto properties = presentation->get_DocumentProperties();
properties->set_Author(u"Contoso Knowledge Management");
properties->set_Title(u"Quarterly Product Roadmap");
properties->set_Keywords(u"roadmap, planning, internal");

presentation->get_Slide(0)->set_Name(u"Encrypted presentation content");
presentation->get_ProtectionManager()->set_EncryptDocumentProperties(false);
presentation->get_ProtectionManager()->Encrypt(u"open_password");
presentation->Save(u"public-properties-encrypted.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

Η μετάδοση του `false` στο `set_EncryptDocumentProperties` δεν κάνει τις διαφάνειες, τα master, τα layouts, τα σχήματα, τα μέσα ή άλλο περιεχόμενο παρουσίασης δημόσια. Επηρεάζει μόνο τις ιδιότητες εγγράφου. Για ανάγνωση αυτών των ιδιοτήτων χωρίς τη φόρτωση του κρυπτογραφημένου περιεχομένου, δείτε [Διαχείριση ιδιοτήτων παρουσίασης](/slides/el/cpp/presentation-properties/).

## **Φόρτωση κρυπτογραφημένης παρουσίασης**

Ορίστε το [LoadOptions::set_Password](https://reference.aspose.com/slides/el/cpp/aspose.slides/loadoptions/set_password/) στον κωδικό ανοίγματος και περάστε τις επιλογές στο [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) κατά τη φόρτωση του αρχείου. Η φόρτωση αποτυγχάνει όταν απαιτείται κωδικός ανοίγματος αλλά ο παρεχόμενος κωδικός λείπει ή είναι λανθασμένος.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

// Εργαστείτε με την αποκρυπτογραφημένη παρουσίαση.
```

## **Αφαίρεση κρυπτογράφησης από παρουσίαση**

Φορτώστε την παρουσίαση με τον κωδικό ανοίγματος, καλέστε το [IProtectionManager::RemoveEncryption](https://reference.aspose.com/slides/el/cpp/aspose.slides/iprotectionmanager/removeencryption/) και αποθηκεύστε το αποτέλεσμα. Η αποθηκευμένη παρουσίαση μπορεί στη συνέχεια να φορτωθεί χωρίς κωδικό.

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **Επικύρωση κωδικού ανοίγματος πριν τη φόρτωση**

Χρησιμοποιήστε το [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) για να αποκτήσετε το [IPresentationInfo](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentationinfo/) χωρίς να δημιουργήσετε μια πλήρη παρουσίαση. Ελέγξτε το [IPresentationInfo::get_IsPasswordProtected](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentationinfo/get_ispasswordprotected/) πριν ζητήσετε ή επικυρώσετε έναν κωδικό. Όταν υπάρχει προστασία, επικυρώστε την παρεχόμενη τιμή με το [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentationinfo/checkpassword/).

### **Ροή εργασίας με διαδρομή αρχείου**

Το ακόλουθο παράδειγμα επικυρώνει έναν κωδικό ανοίγματος για αρχείο PPTX, περνά την επικυρωμένη τιμή στο [LoadOptions::set_Password](https://reference.aspose.com/slides/el/cpp/aspose.slides/loadoptions/set_password/) και στη συνέχεια φορτώνει την πλήρη παρουσίαση:

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

String filePath = u"protected-presentation.pptx";
String password = u"open_password";
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(filePath);

if (!presentationInfo->get_IsPasswordProtected())
{
    Console::WriteLine(u"The presentation does not have an opening password.");
}
else if (!presentationInfo->CheckPassword(password))
{
    Console::WriteLine(u"The opening password is incorrect.");
}
else
{
    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(password);
    auto presentation = MakeObject<Presentation>(filePath, loadOptions);

    Console::WriteLine(u"The presentation was validated and loaded successfully.");
}
```

### **Ροή εργασίας με ροή**

Η υπερφόρτωση ροής του [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) παρέχει την ίδια ροή εργασίας. Επαναρυθμίστε τη θέση μιας ροής με δυνατότητα αναζήτησης πριν φορτώσετε την πλήρη παρουσίαση από αυτή τη ροή.

Το ακόλουθο παράδειγμα χρησιμοποιεί αρχείο PPT:

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

String password = u"open_password";
auto presentationStream = File::OpenRead(u"protected-presentation.ppt");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(presentationStream);

if (!presentationInfo->get_IsPasswordProtected())
{
    Console::WriteLine(u"The presentation does not have an opening password.");
}
else if (!presentationInfo->CheckPassword(password))
{
    Console::WriteLine(u"The opening password is incorrect.");
}
else
{
    presentationStream->set_Position(0);

    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(password);
    auto presentation = MakeObject<Presentation>(presentationStream, loadOptions);

    Console::WriteLine(u"The presentation was validated and loaded successfully.");
}
```

### **Τιμές επιστροφής CheckPassword**

Το [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentationinfo/checkpassword/) επιστρέφει `true` μόνο όταν η παρουσίαση έχει κωδικό ανοίγματος και ο παρεχόμενος κωδικός είναι σωστός. Επιστρέφει `false` σε κάθε μία από τις παρακάτω περιπτώσεις:
- Ο κωδικός είναι λανθασμένος.
- Η παρουσίαση δεν έχει κωδικό ανοίγματος.
- Ο παρεχόμενος κωδικός είναι null ή κενός.

Η συμπεριφορά είναι η ίδια για παρουσιάσεις PPT και PPTX.

## **Έλεγχος εάν μια φορτωμένη παρουσίαση είναι κρυπτογραφημένη**

Μετά τη φόρτωση μιας παρουσίασης με τον σωστό κωδικό, εξετάστε το [IProtectionManager::get_IsEncrypted](https://reference.aspose.com/slides/el/cpp/aspose.slides/iprotectionmanager/get_isencrypted/) για να επιβεβαιώσετε ότι η πηγή παρουσίασης ήταν κρυπτογραφημένη. Για να ανιχνεύσετε προστασία κωδικού ανοίγματος πριν τη φόρτωση, χρησιμοποιήστε το `IPresentationInfo::get_IsPasswordProtected` όπως φαίνεται παραπάνω.

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");
auto presentation = MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
Console::WriteLine(isEncrypted ? u"The presentation is encrypted." : u"The presentation is not encrypted.");
```

## **Συστάσεις ασφαλείας**

{{% alert color="warning" title="Ασφάλεια" %}}
Μην καταγράφετε τους κωδικούς ανοίγματος ή τους συμπεριλαμβάνετε σε μηνύματα διάγνωσης. Αποφύγετε περιττές επαναλαμβανόμενες προσπάθειες επικύρωσης, διατηρήστε τους κωδικούς στη μνήμη μόνο όσο είναι απαραίτητο και επαναχρησιμοποιήστε το αποτέλεσμα επιτυχούς επικύρωσης όταν φορτώνετε αμέσως την παρουσίαση.

Οι δημόσιες ιδιότητες εγγράφου μπορεί να αποκαλύψουν ονόματα συγγραφέων, τίτλους, θέματα, λέξεις-κλειδιά, πληροφορίες εταιρείας, σχόλια και προσαρμοσμένες τιμές, ακόμη και όταν το περιεχόμενο της παρουσίασης είναι κρυπτογραφημένο. Κρυπτογραφήστε τα ευαίσθητα μεταδεδομένα μαζί με την παρουσίαση. Η διατήρηση των ιδιοτήτων σε δημόσια κατάσταση θα πρέπει να αποτελεί σαφή απόφαση που λαμβάνεται μόνο όταν συστήματα πρέπει να καταλογοποιούν, ταξινομούν, αναζητούν ή διαχειρίζονται το αρχείο χωρίς κωδικό ανοίγματος.
{{% /alert %}}

## **Προστασία παρουσίασης με κωδικό online**

1. Ανοίξτε την εφαρμογή [Aspose.Slides Lock](https://products.aspose.app/slides/el/lock).
2. Επιλέξτε ή ανεβάστε την παρουσίαση.
3. Εισαγάγετε έναν κωδικό για προστασία προβολής.
4. Προαιρετικά, εισαγάγετε διαφορετικό κωδικό για προστασία επεξεργασίας.
5. Εφαρμόστε την προστασία και κατεβάστε το προκύπτον αρχείο.

{{% alert color="info" title="Δείτε επίσης" %}}
- [Προστασία παρουσίασης από εγγραφή](/slides/el/cpp/write-protected-presentation/)
- [Ψηφιακή υπογραφή στο PowerPoint](/slides/el/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Συχνές ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ κωδικού ανοίγματος και κωδικού προστασίας εγγραφής;**

Ένας κωδικός ανοίγματος κρυπτογραφεί την παρουσίαση και απαιτείται για τη φόρτωση του περιεχομένου της. Ένας κωδικός προστασίας εγγραφής περιορίζει την τροποποίηση χωρίς να κρυπτογραφεί το περιεχόμενο.

**Μπορώ να επικυρώσω έναν κωδικό ανοίγματος χωρίς τη φόρτωση όλων των διαφανειών;**

Ναι. Αποκτήστε πληροφορίες παρουσίασης, ελέγξτε εάν υπάρχει προστασία κωδικού ανοίγματος και επικυρώστε τον κωδικό πριν δημιουργήσετε μια πλήρη παρουσίαση.

**Μπορεί μια εφαρμογή να διαβάσει τα μεταδεδομένα χωρίς τον κωδικό ανοίγματος;**

Ναι, αλλά μόνο όταν η παρουσίαση κρυπτογραφήθηκε με `set_EncryptDocumentProperties(false)`. Η εφαρμογή πρέπει στη συνέχεια να χρησιμοποιήσει τη λειτουργία φόρτωσης μόνο ιδιοτήτων εγγράφου που περιγράφεται στο [Διαχείριση ιδιοτήτων παρουσίασης](/slides/el/cpp/presentation-properties/).

**Υποστηρίζουν οι ροές εργασίας ελέγχου κωδικού και τα δύο PPT και PPTX;**

Ναι. Ο εντοπισμός και η επικύρωση κωδικού με διαδρομή αρχείου και ροής λειτουργούν με τον ίδιο τρόπο για παρουσιάσεις PPT και PPTX.