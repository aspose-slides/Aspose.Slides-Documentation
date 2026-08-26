---
title: "Προστασία Παρουσιάσεων με Κωδικό στην PHP"
linktitle: "Προστασία Κωδικού"
type: docs
weight: 20
url: /el/php-java/password-protected-presentation/
keywords:
- "παρουσίαση με προστασία κωδικού"
- "κωδικός ανοίγματος"
- "κρυπτογράφηση PowerPoint"
- "αποκρυπτογράφηση PowerPoint"
- "επικύρωση κωδικού παρουσίασης"
- "έλεγχος κωδικού παρουσίασης"
- "άνοιγμα κρυπτογραφημένης παρουσίασης"
- "αφαίρεση κρυπτογράφησης"
- "PowerPoint"
- "PPT"
- "PPTX"
- "παρουσίαση"
- "PHP"
- "Aspose.Slides"
description: "Κρυπτογραφήστε, ανιχνεύστε, επικυρώστε, ανοίξτε και αποκρυπτογραφήστε παρουσιάσεις PowerPoint PPT και PPTX προστατευμένες με κωδικό στην PHP με το Aspose.Slides."
---
## **Επισκόπηση**

Ένας κωδικός πρόσβασης ανοίγματος κρυπτογραφεί μια παρουσίαση. Ο σωστός κωδικός απαιτείται για τη φόρτωση και προβολή του περιεχομένου της παρουσίασης, επομένως αυτή η προστασία παρέχει εμπιστευτικότητα.

Ο κωδικός πρόσβασης ανοίγματος διαφέρει από τον κωδικό προστασίας εγγραφής. Η προστασία εγγραφής περιορίζει την τροποποίηση αλλά δεν κρυπτογραφεί το περιεχόμενο ούτε αποτρέπει τη φόρτωση της παρουσίασης. Για τη διαχείριση κωδικών πρόσβασης για τροποποίηση παρουσιάσεων, δείτε [Write-Protect Presentations](/slides/el/php-java/write-protected-presentation/).

Οι παρακάτω ροές εργασίας ισχύουν για παρουσιάσεις PPT και PPTX. Τα παραδείγματα χρησιμοποιούν και τις δύο μορφές όπου η συμπεριφορά με βάση το αρχείο και το ρεύμα (stream) είναι σημαντική.

## **Κρυπτογράφηση Παρουσίασης με Κωδικό Πρόσβασης Ανοίγματος**

Χρησιμοποιήστε το [ProtectionManager::encrypt](https://reference.aspose.com/slides/el/php-java/aspose.slides/protectionmanager/#encrypt) για να ορίσετε έναν κωδικό πρόσβασης ανοίγματος. Στη συνέχεια, χρησιμοποιήστε το [Presentation::save](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#save) για να αποθηκεύσετε την κρυπτογραφημένη παρουσίαση.

Το παρακάτω παράδειγμα κρυπτογραφεί μια παρουσίαση PPTX:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->getProtectionManager()->encrypt("open_password");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Φόρτωση Κρυπτογραφημένης Παρουσίασης**

Ορίστε το [LoadOptions::setPassword](https://reference.aspose.com/slides/el/php-java/aspose.slides/loadoptions/#setPassword) στον κωδικό πρόσβασης ανοίγματος και περάστε τις επιλογές στο [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) κατά τη φόρτωση του αρχείου. Η φόρτωση αποτυγχάνει όταν απαιτείται κωδικός πρόσβασης ανοίγματος αλλά ο παρεχόμενος κωδικός λείπει ή είναι λανθασμένος.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    # Εργασία με την αποκρυπτογραφημένη παρουσίαση.
} finally {
    $presentation->dispose();
}
```

## **Αφαίρεση Κρυπτογράφησης από Παρουσίαση**

Φορτώστε την παρουσίαση με τον κωδικό πρόσβασης ανοίγματος, καλέστε το [ProtectionManager::removeEncryption](https://reference.aspose.com/slides/el/php-java/aspose.slides/protectionmanager/#removeEncryption) και αποθηκεύστε το αποτέλεσμα. Η αποθηκευμένη παρουσίαση μπορεί στη συνέχεια να φορτωθεί χωρίς κωδικό.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $presentation->getProtectionManager()->removeEncryption();
    $presentation->save("encryption-removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Επικύρωση Κωδικού Πρόσβασης Ανοίγματος Πριν τη Φόρτωση**

Χρησιμοποιήστε το [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationfactory/#getPresentationInfo) για να λάβετε το [PresentationInfo](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationinfo/) χωρίς να δημιουργήσετε μια πλήρη παρουσίαση. Ελέγξτε το [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationinfo/#isPasswordProtected) πριν ζητήσετε ή επικυρώσετε κωδικό. Όταν υπάρχει προστασία, επικυρώστε την παρεχόμενη τιμή με το [PresentationInfo::checkPassword](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationinfo/#checkPassword).

### **Ροή Εργασίας με Διαδρομή Αρχείου**

Το παρακάτω παράδειγμα επικυρώνει έναν κωδικό πρόσβασης ανοίγματος για αρχείο PPTX, περνά την επικυρωμένη τιμή στο [LoadOptions::setPassword](https://reference.aspose.com/slides/el/php-java/aspose.slides/loadoptions/#setPassword) και στη συνέχεια φορτώνει την πλήρη παρουσίαση:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$filePath = "protected-presentation.pptx";
$password = "open_password";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($filePath);

if (!$presentationInfo->isPasswordProtected()) {
    echo("The presentation does not have an opening password.\n");
} elseif (!$presentationInfo->checkPassword($password)) {
    echo("The opening password is incorrect.\n");
} else {
    $loadOptions = new LoadOptions();
    $loadOptions->setPassword($password);

    $presentation = new Presentation($filePath, $loadOptions);
    try {
        echo("The presentation was validated and loaded successfully.\n");
    } finally {
        $presentation->dispose();
    }
}
```

### **Ροή Εργασίας με Ρεύμα**

Η υπερφόρτωση ροής του [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationfactory/#getPresentationInfo) παρέχει την ίδια ροή εργασίας. Επαναρυθμίστε τη θέση ενός αναζητήσιμου ρεύματος πριν φορτώσετε την πλήρη παρουσίαση από αυτό το ρεύμα.

Το παρακάτω παράδειγμα χρησιμοποιεί αρχείο PPT:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$password = "open_password";

$presentationStream = new Java("java.io.FileInputStream", "protected-presentation.ppt");
try {
    $presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($presentationStream);

    if (!$presentationInfo->isPasswordProtected()) {
        echo("The presentation does not have an opening password.\n");
    } elseif (!$presentationInfo->checkPassword($password)) {
        echo("The opening password is incorrect.\n");
    } else {
        $presentationStream->getChannel()->position(0);

        $loadOptions = new LoadOptions();
        $loadOptions->setPassword($password);

        $presentation = new Presentation($presentationStream, $loadOptions);
        try {
            echo("The presentation was validated and loaded successfully.\n");
        } finally {
            $presentation->dispose();
        }
    }
} finally {
    $presentationStream->close();
}
```

### **Τιμές Επιστροφής του checkPassword**

[PresentationInfo::checkPassword](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationinfo/#checkPassword) επιστρέφει `true` μόνο όταν η παρουσίαση έχει κωδικό πρόσβασης ανοίγματος και ο παρεχόμενος κωδικός είναι σωστός. Επιστρέφει `false` σε κάθε μία από τις παρακάτω περιπτώσεις:

- Ο κωδικός είναι λανθασμένος.
- Η παρουσίαση δεν έχει κωδικό πρόσβασης ανοίγματος.
- Ο παρεχόμενος κωδικός είναι `null` ή κενός.

Η συμπεριφορά είναι η ίδια για παρουσιάσεις PPT και PPTX.

## **Έλεγχος Εάν Φορτωμένη Παρουσίαση Είναι Κρυπτογραφημένη**

Αφού φορτώσετε μια παρουσίαση με τον σωστό κωδικό, ελέγξτε το [ProtectionManager::isEncrypted](https://reference.aspose.com/slides/el/php-java/aspose.slides/protectionmanager/#isEncrypted) για να επιβεβαιώσετε ότι η αρχική παρουσίαση ήταν κρυπτογραφημένη. Για να ανιχνεύσετε προστασία κωδικού ανοίγματος πριν τη φόρτωση, χρησιμοποιήστε το [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationinfo/#isPasswordProtected) όπως φαίνεται παραπάνω.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $isEncrypted = $presentation->getProtectionManager()->isEncrypted();
    echo("The presentation is encrypted: " . ($isEncrypted ? "true" : "false") . "\n");
} finally {
    $presentation->dispose();
}
```

## **Συστάσεις Ασφάλειας**
{{% alert color="warning" title="Security" %}}
Μην καταγράφετε τους κωδικούς πρόσβασης ανοίγματος ή τους συμπεριλαμβάνετε σε μηνύματα διάγνωσης. Αποφύγετε περιττές επαναλαμβανόμενες προσπάθειες επικύρωσης, διατηρήστε τους κωδικούς στη μνήμη μόνο όσο είναι απαραίτητο, και επαναχρησιμοποιήστε ένα επιτυχές αποτέλεσμα επικύρωσης όταν φορτώνετε αμέσως την παρουσίαση.
{{% /alert %}}

## **Προστασία Παρουσίασης με Κωδικό Πρόσβασης Online**

1. Ανοίξτε την εφαρμογή [Aspose.Slides Lock](https://products.aspose.app/slides/el/lock).
2. Επιλέξτε ή ανεβάστε την παρουσίαση.
3. Εισάγετε έναν κωδικό για προστασία προβολής.
4. Προαιρετικά, εισάγετε ξεχωριστό κωδικό για προστασία επεξεργασίας.
5. Εφαρμόστε την προστασία και κατεβάστε το παραγόμενο αρχείο.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/el/php-java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/el/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **ΣΥΧΝΑ ΕΡΩΤΗΜΑΤΑ**

**What is the difference between an opening password and a write-protection password?**  
Ο κωδικός πρόσβασης ανοίγματος κρυπτογραφεί την παρουσίαση και απαιτείται για τη φόρτωση του περιεχομένου της. Ο κωδικός προστασίας εγγραφής περιορίζει την τροποποίηση χωρίς να κρυπτογραφεί το περιεχόμενο.

**Can I validate an opening password without loading all slides?**  
Ναι. Λάβετε τις πληροφορίες της παρουσίασης, ελέγξτε εάν υπάρχει προστασία κωδικού ανοίγματος και επικυρώστε τον κωδικό πριν δημιουργήσετε μια πλήρη παρουσίαση.

**Do the password-checking workflows support both PPT and PPTX?**  
Ναι. Η ανίχνευση και επικύρωση κωδικού με βάση τη διαδρομή αρχείου ή το ρεύμα λειτουργούν με τον ίδιο τρόπο για παρουσιάσεις PPT και PPTX.