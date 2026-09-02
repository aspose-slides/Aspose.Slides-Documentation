---
title: Προστασία Εγγραφής Παρουσιάσεων σε PHP
linktitle: Προστασία Εγγραφής
type: docs
weight: 25
url: /el/php-java/write-protected-presentation/
keywords:
- προστασία εγγραφής
- προστασία εγγραφής PowerPoint
- κωδικός για τροποποίηση
- περιορισμός επεξεργασίας παρουσίασης
- αφαίρεση προστασίας εγγραφής
- επικύρωση κωδικού τροποποίησης
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Ορισμός, ανίχνευση, επικύρωση και αφαίρεση κωδικών προστασίας εγγραφής σε παρουσιάσεις PowerPoint PPT και PPTX χρησιμοποιώντας το Aspose.Slides για PHP."
---
## **Εισαγωγή**

Ένας κωδικός προστασίας εγγραφής περιορίζει την τροποποίηση μιας παρουσίασης, αλλά δεν κρυπτογραφεί το περιεχόμενό της. Οι χρήστες μπορούν να φορτώσουν και να προβάλλουν μια παρουσίαση με προστασία εγγραφής χωρίς τον κωδικό. Ανάλογα με την εφαρμογή, μπορεί επίσης να είναι δυνατή η επεξεργασία του περιεχομένου και η αποθήκευσή του υπό διαφορετικό όνομα, οπότε η προστασία εγγραφής δεν πρέπει να θεωρείται μηχανισμός εμπιστευτικότητας.

Ένας κωδικός ανοίγματος εξυπηρετεί διαφορετικό σκοπό: κρυπτογραφεί την παρουσίαση και απαιτείται για τη φόρτωση του περιεχομένου της. Για να κρυπτογραφήσετε μια παρουσίαση ή να επαληθεύσετε έναν κωδικό ανοίγματος, δείτε [Παρουσιάσεις με προστασία κωδικού](/slides/el/php-java/password-protected-presentation/).

Οι ροές εργασίας σε αυτό το άρθρο ισχύουν για παρουσιάσεις PPT και PPTX. Τα παραδείγματα χρησιμοποιούν αρχεία PPTX· κατά την αποθήκευση σε PPT, χρησιμοποιήστε την επέκταση `.ppt` και την αντίστοιχη μορφή αποθήκευσης PPT.

## **Ορισμός προστασίας εγγραφής σε παρουσίαση**

Χρησιμοποιήστε [ProtectionManager::setWriteProtection](https://reference.aspose.com/slides/el/php-java/aspose.slides/protectionmanager/#setWriteProtection) για να εκχωρήσετε έναν κωδικό για την τροποποίηση μιας παρουσίασης. Η αποθήκευση της παρουσίασης διατηρεί τη ρύθμιση προστασίας.

Το παρακάτω παράδειγμα ορίζει προστασία εγγραφής σε μια παρουσίαση PPTX:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->getProtectionManager()->setWriteProtection("modify_password");
    $presentation->save("write-protected-pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Φόρτωση παρουσίασης με προστασία εγγραφής**

Επειδή η προστασία εγγραφής δεν κρυπτογραφεί το περιεχόμενο της παρουσίασης, δεν απαιτείται κωδικός για τη φόρτωση της παρουσίασης. Ο κωδικός είναι σχετικός μόνο κατά την επαλήθευση εξουσιοδότησης για τροποποίηση της προστατευμένης παρουσίασης.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("write-protected-pres.pptx");
try {
    echo("Slide count: " . $presentation->getSlides()->size() . "\n");
} finally {
    $presentation->dispose();
}
```

Μην περάσετε έναν κωδικό προστασίας εγγραφής στο [LoadOptions::setPassword](https://reference.aspose.com/slides/el/php-java/aspose.slides/loadoptions/#setPassword). Αυτή η μέθοδος δέχεται έναν κωδικό ανοίγματος για κρυπτογραφημένο περιεχόμενο. Εάν μια παρουσίαση διαθέτει και τους δύο τύπους προστασίας, παρέχετε τον κωδικό ανοίγματος για τη φόρτωση της και διαχειριστείτε τον κωδικό προστασίας εγγραφής ξεχωριστά.

## **Αφαίρεση προστασίας εγγραφής από παρουσίαση**

Χρησιμοποιήστε [ProtectionManager::removeWriteProtection](https://reference.aspose.com/slides/el/php-java/aspose.slides/protectionmanager/#removeWriteProtection) για να αφαιρέσετε τον περιορισμό τροποποίησης, έπειτα αποθηκεύστε την παρουσίαση.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("write-protected-pres.pptx");
try {
    $presentation->getProtectionManager()->removeWriteProtection();
    $presentation->save("write-protection-removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Έλεγχος εάν μια παρουσίαση είναι προστατευμένη κατά την εγγραφή**

Για να εξετάσετε ένα αρχείο χωρίς να δημιουργήσετε ένα πλήρες αντικείμενο [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/), καλέστε το [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationfactory/#getPresentationInfo) και ελέγξτε το [PresentationInfo::isWriteProtected](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationinfo/#isWriteProtected). Η μέθοδος χρησιμοποιεί το [NullableBool](https://reference.aspose.com/slides/el/php-java/aspose.slides/nullablebool/) και επιστρέφει `NullableBool::True` όταν εντοπιστεί προστασία εγγραφής.

```php
use aspose\slides\NullableBool;
use aspose\slides\PresentationFactory;

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo("write-protected-pres.pptx");

if ($presentationInfo->isWriteProtected() == NullableBool::True) {
    echo("The presentation is write protected.\n");
} else {
    echo("Write protection was not detected.\n");
}
```

Η υπερφόρτωση με ρεύμα του [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationfactory/#getPresentationInfo) παρέχει τις ίδιες πληροφορίες για μια παρουσίαση που παρέχεται ως ρεύμα.

## **Επικύρωση κωδικού προστασίας εγγραφής**

Χρησιμοποιήστε το [PresentationInfo::checkWriteProtection](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationinfo/#checkWriteProtection) για να επικυρώσετε έναν κωδικό τροποποίησης χωρίς να φορτώσετε την πλήρη παρουσίαση. Ελέγξτε πρώτα το [PresentationInfo::isWriteProtected](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationinfo/#isWriteProtected) ώστε η εφαρμογή να ζητά ή να επικυρώνει κωδικό μόνο όταν υπάρχει προστασία εγγραφής.

```php
use aspose\slides\NullableBool;
use aspose\slides\PresentationFactory;

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo("write-protected-pres.pptx");

if ($presentationInfo->isWriteProtected() != NullableBool::True) {
    echo("The presentation is not write protected.\n");
} elseif ($presentationInfo->checkWriteProtection("modify_password")) {
    echo("The write-protection password is correct.\n");
} else {
    echo("The write-protection password is incorrect.\n");
}
```

[PresentationInfo::checkWriteProtection](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationinfo/#checkWriteProtection) επικυρώνει μόνο τον κωδικό προστασίας εγγραφής. Δεν επικυρώνει έναν κωδικό ανοίγματος ούτε καθορίζει αν μπορεί να φορτωθεί κρυπτογραφημένο περιεχόμενο. Αντιθέτως, το [PresentationInfo::checkPassword](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationinfo/#checkPassword) επικυρώνει μόνο έναν κωδικό ανοίγματος. Εάν έχει ήδη φορτωθεί μια πλήρης παρουσίαση, το [ProtectionManager::checkWriteProtection](https://reference.aspose.com/slides/el/php-java/aspose.slides/protectionmanager/#checkWriteProtection) παρέχει τον ισοδύναμο έλεγχο προστασίας εγγραφής μέσω του διαχειριστή προστασίας του.

Σε παραγωγικές εφαρμογές, μην καταγράφετε τους κωδικούς ή τους ενσωματώνετε σε μηνύματα διάγνωσης. Αποφύγετε περιττές επαναλαμβανόμενες προσπάθειες επικύρωσης και διατηρήστε τους κωδικούς στη μνήμη μόνο όσο είναι απαραίτητο.

{{% alert color="info" title="Δείτε επίσης" %}}
- [Παρουσιάσεις με προστασία κωδικού](/slides/el/php-java/password-protected-presentation/)
- [Παρουσιάσεις μόνο για ανάγνωση](/slides/el/php-java/read-only-presentation/)
- [Ψηφιακή υπογραφή στο PowerPoint](/slides/el/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Συχνές ερωτήσεις**

**Κρυπτογραφεί η προστασία εγγραφής μια παρουσίαση;**

Όχι. Περιορίζει την τροποποίηση αλλά αφήνει το περιεχόμενο της παρουσίασης διαθέσιμο για φόρτωση και προβολή.

**Απαιτείται ο κωδικός προστασίας εγγραφής για το άνοιγμα μιας παρουσίασης;**

Όχι. Μόνο ένας κωδικός ανοίγματος απαιτείται για τη φόρτωση κρυπτογραφημένου περιεχομένου παρουσίασης.

**Μπορεί μια παρουσίαση να έχει και κωδικό ανοίγματος και κωδικό προστασίας εγγραφής;**

Ναι. Παρέχετε τον κωδικό ανοίγματος μέσω των επιλογών φόρτωσης για να ανοίξετε την κρυπτογραφημένη παρουσίαση και επικυρώστε ξεχωριστά τον κωδικό προστασίας εγγραφής όταν απαιτείται εξουσιοδότηση τροποποίησης.