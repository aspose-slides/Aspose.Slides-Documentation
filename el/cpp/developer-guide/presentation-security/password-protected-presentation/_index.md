---
title: Προστασία Παρουσιάσεων με Κωδικό Πρόσβασης σε C++
linktitle: Προστασία Κωδικού Πρόσβασης
type: docs
weight: 20
url: /el/cpp/password-protected-presentation/
keywords:
- προστατευμένη με κωδικό παρουσίαση
- κωδικός πρόσβασης ανοίγματος
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
description: "Κρυπτογραφήστε, εντοπίστε, επικυρώστε, ανοίξτε και αποκρυπτογραφήστε παρουσιάσεις PowerPoint PPT και PPTX με προστασία κωδικού σε C++ με το Aspose.Slides."
---
## **Επισκόπηση**

Ένας κωδικός πρόσβασης ανοίγματος κρυπτογραφεί μια παρουσίαση. Ο σωστός κωδικός πρόσβασης απαιτείται για τη φόρτωση και προβολή του περιεχομένου της παρουσίασης, επομένως αυτή η προστασία παρέχει εμπιστευτικότητα.

Ο κωδικός πρόσβασης ανοίγματος διαφέρει από τον κωδικό πρόσβασης προστασίας εγγραφής. Η προστασία εγγραφής περιορίζει την τροποποίηση, αλλά δεν κρυπτογραφεί το περιεχόμενο ή εμποδίζει τη φόρτωση της παρουσίασης. Για τη διαχείριση κωδικών πρόσβασης για τροποποίηση παρουσιάσεων, δείτε [Write-Protect Presentations](/slides/el/cpp/write-protected-presentation/).

Οι ροές εργασίας παρακάτω εφαρμόζονται και στις παρουσιάσεις PPT και PPTX. Τα παραδείγματα χρησιμοποιούν και τις δύο μορφές όταν η συμπεριφορά τους βάσει αρχείου ή ροής είναι σημαντική.

## **Κρυπτογράφηση μιας Παρουσίασης με Κωδικό Πρόσβασης Ανοίγματος**

Χρησιμοποιήστε το [IProtectionManager::Encrypt](https://reference.aspose.com/slides/el/cpp/aspose.slides/iprotectionmanager/encrypt/) για να ορίσετε έναν κωδικό πρόσβασης ανοίγματος. Μετά χρησιμοποιήστε το [IPresentation::Save](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentation/save/) για να αποθηκεύσετε την κρυπτογραφημένη παρουσίαση.

Το παρακάτω παράδειγμα κρυπτογραφεί μια παρουσίαση PPTX:

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

## **Φόρτωση Κρυπτογραφημένης Παρουσίασης**

Ορίστε το [LoadOptions::set_Password](https://reference.aspose.com/slides/el/cpp/aspose.slides/loadoptions/set_password/) στον κωδικό πρόσβασης ανοίγματος και περάστε τις επιλογές στη [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) κατά τη φόρτωση του αρχείου. Η φόρτωση αποτυγχάνει όταν απαιτείται κωδικός πρόσβασης ανοίγματος αλλά ο παρεχόμενος κωδικός λείπει ή είναι λανθασμένος.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

// Εργαστείτε με την αποκρυπτογραφημένη παρουσίαση.
```

## **Αφαίρεση Κρυπτογράφησης από Παρουσίαση**

Φορτώστε την παρουσίαση με τον κωδικό πρόσβασης ανοίγματος, καλέστε το [IProtectionManager::RemoveEncryption](https://reference.aspose.com/slides/el/cpp/aspose.slides/iprotectionmanager/removeencryption/), και αποθηκεύστε το αποτέλεσμα. Η αποθηκευμένη παρουσίαση μπορεί μετά να φορτωθεί χωρίς κωδικό πρόσβασης.

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

## **Επικύρωση Κωδικού Πρόσβασης Ανοίγματος Πριν τη Φόρτωση**

Χρησιμοποιήστε το [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) για να αποκτήσετε το [IPresentationInfo](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentationinfo/) χωρίς τη δημιουργία πλήρους αντικειμένου παρουσίασης. Ελέγξτε το [IPresentationInfo::get_IsPasswordProtected](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentationinfo/get_ispasswordprotected/) πριν ζητήσετε ή επικυρώσετε έναν κωδικό πρόσβασης. Όταν υπάρχει προστασία, επικυρώστε την παρεχόμενη τιμή με το [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentationinfo/checkpassword/).

### **Ροή Εργασίας με Διαδρομή Αρχείου**

Το παρακάτω παράδειγμα επικυρώνει έναν κωδικό πρόσβασης ανοίγματος για ένα αρχείο PPTX, περνά την επικυρωμένη τιμή στο [LoadOptions::set_Password](https://reference.aspose.com/slides/el/cpp/aspose.slides/loadoptions/set_password/), και στη συνέχεια φορτώνει την πλήρη παρουσίαση:

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

### **Ροή Εργασίας με Ροή**

Η υπερφόρτωση με ροή του [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) παρέχει την ίδια ροή εργασίας. Επαναφέρετε τη θέση μιας ρευσιμιζόμενης ροής πριν φορτώσετε την πλήρη παρουσίαση από αυτήν τη ροή.

Το παρακάτω παράδειγμα χρησιμοποιεί ένα αρχείο PPT:

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

### **Τιμές Επιστροφής του CheckPassword**

Το [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentationinfo/checkpassword/) επιστρέφει `true` μόνο όταν η παρουσίαση έχει κωδικό πρόσβασης ανοίγματος και ο παρεχόμενος κωδικός είναι σωστός. Επιστρέφει `false` σε κάθε μία από τις ακόλουθες περιπτώσεις:

- Ο κωδικός πρόσβασης είναι λανθασμένος.
- Η παρουσίαση δεν διαθέτει κωδικό πρόσβασης ανοίγματος.
- Ο παρεχόμενος κωδικός πρόσβασης είναι null ή κενός.

Η συμπεριφορά είναι η ίδια για παρουσιάσεις PPT και PPTX.

## **Έλεγχος Αν Η Φορτωμένη Παρουσίαση Είναι Κρυπτογραφημένη**

Μετά τη φόρτωση μιας παρουσίασης με τον σωστό κωδικό πρόσβασης, ελέγξτε το [IProtectionManager::get_IsEncrypted](https://reference.aspose.com/slides/el/cpp/aspose.slides/iprotectionmanager/get_isencrypted/) για να επιβεβαιώσετε ότι η πηγαία παρουσίαση ήταν κρυπτογραφημένη. Για τον εντοπισμό προστασίας κωδικού πρόσβασης ανοίγματος πριν τη φόρτωση, χρησιμοποιήστε το `IPresentationInfo::get_IsPasswordProtected` όπως φαίνεται παραπάνω.

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

## **Συστάσεις Ασφάλειας**

{{% alert color="warning" title="Security" %}}
Μην καταγράφετε τους κωδικούς πρόσβασης ανοίγματος ή τους συμπεριλαμβάνετε σε διαγνωστικά μηνύματα. Αποφύγετε περιττές επαναλαμβανόμενες προσπάθειες επικύρωσης, διατηρείτε τους κωδικούς πρόσβασης στη μνήμη μόνο όσο είναι απαραίτητο, και επαναχρησιμοποιήστε ένα επιτυχές αποτέλεσμα επικύρωσης όταν φορτώνετε αμέσως την παρουσίαση.
{{% /alert %}}

## **Προστασία Παρουσίασης με Κωδικό Πρόσβασης Online**

1. Ανοίξτε την εφαρμογή [Aspose.Slides Lock](https://products.aspose.app/slides/el/lock).
1. Επιλέξτε ή ανεβάστε την παρουσίαση.
1. Εισάγετε έναν κωδικό πρόσβασης για προστασία προβολής.
1. Προαιρετικά εισάγετε ξεχωριστό κωδικό πρόσβασης για προστασία επεξεργασίας.
1. Εφαρμόστε την προστασία και κατεβάστε το δημιουργημένο αρχείο.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/el/cpp/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/el/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Ποια είναι η διαφορά μεταξύ κωδικού πρόσβασης ανοίγματος και κωδικού πρόσβασης προστασίας εγγραφής;**

Ένας κωδικός πρόσβασης ανοίγματος κρυπτογραφεί την παρουσίαση και απαιτείται για τη φόρτωση του περιεχομένου της. Ένας κωδικός πρόσβασης προστασίας εγγραφής περιορίζει την τροποποίηση χωρίς να κρυπτογραφεί το περιεχόμενο.

**Μπορώ να επικυρώσω έναν κωδικό πρόσβασης ανοίγματος χωρίς να φορτώσω όλες τις διαφάνειες;**

Ναι. Αποκτήστε πληροφορίες παρουσίασης, ελέγξτε αν υπάρχει προστασία κωδικού πρόσβασης ανοίγματος, και επικυρώστε τον κωδικό πριν δημιουργήσετε ένα πλήρες αντικείμενο παρουσίασης.

**Υποστηρίζουν οι ροές επαλήθευσης κωδικού πρόσβασης και τα PPT και PPTX;**

Ναί. Η ανίχνευση και επικύρωση κωδικού πρόσβασης βάσει διαδρομής αρχείου ή ροής συμπεριφέρονται τα ίδια για παρουσιάσεις PPT και PPTX.