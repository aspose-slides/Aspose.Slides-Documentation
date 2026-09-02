---
title: Προστασία Εγγραφής Παρουσιάσεων σε C++
linktitle: Προστασία Εγγραφής
type: docs
weight: 25
url: /el/cpp/write-protected-presentation/
keywords:
- προστασία εγγραφής
- προστασία εγγραφής PowerPoint
- κωδικός για τροποποίηση
- περιορισμός επεξεργασίας παρουσίασης
- αφαίρεση προστασίας εγγραφής
- επικύρωση κωδικού τροποποίησης
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Ορίστε, εντοπίστε, επικυρώστε και αφαιρέστε κωδικούς προστασίας εγγραφής σε παρουσιάσεις PowerPoint PPT και PPTX χρησιμοποιώντας το Aspose.Slides για C++."
---
## **Εισαγωγή**

Ένας κωδικός προστασίας εγγραφής περιορίζει την τροποποίηση μιας παρουσίασης αλλά δεν κρυπτογραφεί το περιεχόμενό της. Οι χρήστες μπορούν να φορτώσουν και να προβάλουν μια παρουσίαση με προστασία εγγραφής χωρίς τον κωδικό. Ανάλογα με την εφαρμογή, μπορεί επίσης να έχουν τη δυνατότητα να επεξεργαστούν το περιεχόμενο και να το αποθηκεύσουν με διαφορετικό όνομα, επομένως η προστασία εγγραφής δεν πρέπει να θεωρείται μηχανισμός εμπιστευτικότητας.

Ένας κωδικός ανοίγματος εξυπηρετεί διαφορετικό σκοπό: κρυπτογραφεί την παρουσίαση και απαιτείται για τη φόρτωση του περιεχομένου της. Για την κρυπτογράφηση μιας παρουσίασης ή την επαλήθευση κωδικού ανοίγματος, δείτε [Password-Protect Presentations](/slides/el/cpp/password-protected-presentation/).

Οι ροές εργασίας σε αυτό το άρθρο εφαρμόζονται τόσο σε παρουσιάσεις PPT όσο και PPTX. Τα παραδείγματα χρησιμοποιούν αρχεία PPTX· όταν αποθηκεύετε σε PPT, χρησιμοποιήστε την κατάληξη `.ppt` και την αντίστοιχη μορφή αποθήκευσης PPT.

## **Ορισμός Προστασίας Εγγραφής σε Παρουσίαση**

Χρησιμοποιήστε [IProtectionManager::SetWriteProtection](https://reference.aspose.com/slides/el/cpp/aspose.slides/iprotectionmanager/setwriteprotection/) για να ορίσετε κωδικό για την τροποποίηση μιας παρουσίασης. Η αποθήκευση της παρουσίασης διατηρεί τη ρύθμιση προστασίας.

Το παρακάτω παράδειγμα ορίζει προστασία εγγραφής σε μια παρουσίαση PPTX:

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"modify_password");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **Φόρτωση Παρουσίασης με Προστασία Εγγραφής**

Επειδή η προστασία εγγραφής δεν κρυπτογραφεί το περιεχόμενο της παρουσίασης, δεν απαιτείται κωδικός για τη φόρτωση της παρουσίασης. Ο κωδικός είναι σχετικός μόνο κατά την επαλήθευση εξουσιοδότησης για τροποποίηση της προστατευμένης παρουσίασης.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"write-protected-pres.pptx");

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());
```

Μην περάσετε κωδικό προστασίας εγγραφής στη [LoadOptions::set_Password](https://reference.aspose.com/slides/el/cpp/aspose.slides/loadoptions/set_password/). Η ιδιότητα αυτή δέχεται έναν κωδικό ανοίγματος για κρυπτογραφημένο περιεχόμενο. Εάν μια παρουσίαση διαθέτει και τους δύο τύπους προστασίας, δώστε τον κωδικό ανοίγματος για τη φόρτωση της και διαχειριστείτε ξεχωριστά τον κωδικό προστασίας εγγραφής.

## **Αφαίρεση Προστασίας Εγγραφής από Παρουσίαση**

Χρησιμοποιήστε [IProtectionManager::RemoveWriteProtection](https://reference.aspose.com/slides/el/cpp/aspose.slides/iprotectionmanager/removewriteprotection/) για να αφαιρέσετε τον περιορισμό τροποποίησης, στη συνέχεια αποθηκεύστε την παρουσίαση.

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"write-protected-pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **Έλεγχος Αν Μια Παρουσίαση Είναι Προστατευμένη Εγγραφή**

Για να εξετάσετε ένα αρχείο χωρίς να δημιουργήσετε ένα πλήρες αντικείμενο [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/), καλέστε την [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) και ελέγξτε την [IPresentationInfo::get_IsWriteProtected](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentationinfo/get_iswriteprotected/). Η ιδιότητα χρησιμοποιεί την [NullableBool](https://reference.aspose.com/slides/el/cpp/aspose.slides/nullablebool/) και επιστρέφει `NullableBool::True` όταν εντοπιστεί προστασία εγγραφής.

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/NullableBool.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"write-protected-pres.pptx");

if (presentationInfo->get_IsWriteProtected() == NullableBool::True)
{
    Console::WriteLine(u"The presentation is write protected.");
}
else
{
    Console::WriteLine(u"Write protection was not detected.");
}
```

Η έκδοση με ροή της [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) παρέχει τις ίδιες πληροφορίες για μια παρουσίαση που παρέχεται ως ροή.

## **Επικύρωση Κωδικού Προστασίας Εγγραφής**

Χρησιμοποιήστε [IPresentationInfo::CheckWriteProtection](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentationinfo/checkwriteprotection/) για να επαληθεύσετε έναν κωδικό τροποποίησης χωρίς να φορτώσετε ολόκληρη την παρουσίαση. Ελέγξτε πρώτα την [IPresentationInfo::get_IsWriteProtected](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentationinfo/get_iswriteprotected/) ώστε η εφαρμογή να ζητήσει ή να επαληθεύσει κωδικό μόνο όταν υπάρχει προστασία εγγραφής.

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/NullableBool.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"write-protected-pres.pptx");

if (presentationInfo->get_IsWriteProtected() != NullableBool::True)
{
    Console::WriteLine(u"The presentation is not write protected.");
}
else if (presentationInfo->CheckWriteProtection(u"modify_password"))
{
    Console::WriteLine(u"The write-protection password is correct.");
}
else
{
    Console::WriteLine(u"The write-protection password is incorrect.");
}
```

[IPresentationInfo::CheckWriteProtection](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentationinfo/checkwriteprotection/) επικυρώνει μόνο τον κωδικό προστασίας εγγραφής. Δεν επικυρώνει κωδικό ανοίγματος ή καθορίζει εάν μπορεί να φορτωθεί κρυπτογραφημένο περιεχόμενο. Αντιθέτως, [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentationinfo/checkpassword/) επικυρώνει μόνο έναν κωδικό ανοίγματος. Εάν μια πλήρης παρουσίαση έχει ήδη φορτωθεί, το [IProtectionManager::CheckWriteProtection](https://reference.aspose.com/slides/el/cpp/aspose.slides/iprotectionmanager/checkwriteprotection/) παρέχει τον ισοδύναμο έλεγχο προστασίας εγγραφής μέσω του διαχειριστή προστασίας.

Σε εφαρμογές παραγωγής, μην καταγράφετε κωδικούς ή τους συμπεριλαμβάνετε σε διαγνωστικά μηνύματα. Αποφύγετε περιττές επαναλαμβανόμενες προσπάθειες επικύρωσης και διατηρήστε τους κωδικούς στη μνήμη μόνο όσο είναι απαραίτητο.

{{% alert color="info" title="Δείτε επίσης" %}}
- [Προστασία Παρουσιάσεων με Κωδικό](/slides/el/cpp/password-protected-presentation/)
- [Παρουσιάσεις Μόνο για Ανάγνωση](/slides/el/cpp/read-only-presentation/)
- [Ψηφιακή Υπογραφή στο PowerPoint](/slides/el/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Κρυπτογραφεί η προστασία εγγραφής μια παρουσίαση;**

Όχι. Περιορίζει την τροποποίηση αλλά αφήνει το περιεχόμενο της παρουσίασης διαθέσιμο για φόρτωση και προβολή.

**Απαιτείται ο κωδικός προστασίας εγγραφής για το άνοιγμα μιας παρουσίασης;**

Όχι. Μόνο ένας κωδικός ανοίγματος απαιτείται για τη φόρτωση κρυπτογραφημένου περιεχομένου παρουσίασης.

**Μπορεί μια παρουσίαση να έχει τόσο κωδικό ανοίγματος όσο και κωδικό προστασίας εγγραφής;**

Ναι. Δώστε τον κωδικό ανοίγματος μέσω των επιλογών φόρτωσης για να ανοίξετε την κρυπτογραφημένη παρουσίαση, και επαληθεύστε ξεχωριστά τον κωδικό προστασίας εγγραφής όταν απαιτείται εξουσιοδότηση για τροποποίηση.