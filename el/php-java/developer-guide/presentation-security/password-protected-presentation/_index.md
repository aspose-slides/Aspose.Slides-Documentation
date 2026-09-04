---
title: ΠΡΟΣΤΑΣΗ ΠΑΡΟΥΣΙΑΣΕΩΝ ΜΕ ΚΩΔΙΚΟ ΠΡΟΣΒΑΣΗΣ ΣΕ PHP
linktitle: Προστασία Κωδικού Πρόσβασης
type: docs
weight: 20
url: /el/php-java/password-protected-presentation/
keywords:
- παρουσίαση με κωδικό πρόσβασης
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
- PHP
- Aspose.Slides
description: "Κρυπτογράφηση, ανίχνευση, επικύρωση, άνοιγμα και αποκρυπτογράφηση παρουσιάσεων PowerPoint PPT και PPTX προστατευμένων με κωδικό πρόσβασης σε PHP με Aspose.Slides."
---
## **Επισκόπηση**

Ένας κωδικός πρόσβασης ανοίγματος κρυπτογραφεί μια παρουσίαση. Ο σωστός κωδικός πρόσβασης απαιτείται για τη φόρτωση και προβολή του περιεχομένου της παρουσίασης, επομένως αυτή η προστασία παρέχει εμπιστευτικότητα.

Ένας κωδικός πρόσβασης ανοίγματος διαφέρει από έναν κωδικό πρόσβασης προστασίας εγγραφής. Η προστασία εγγραφής περιορίζει την τροποποίηση, αλλά δεν κρυπτογραφεί το περιεχόμενο ή αποτρέπει τη φόρτωση της παρουσίασης. Για τη διαχείριση κωδικών πρόσβασης για την τροποποίηση παρουσιάσεων, δείτε [Προστασία Παρουσιάσεων από Εγγραφή](/slides/el/php-java/write-protected-presentation/).

Οι παρακάτω ροές εργασίας ισχύουν για παρουσιάσεις PPT και PPTX. Τα παραδείγματα χρησιμοποιούν και τις δύο μορφές όταν η συμπεριφορά βάσει αρχείου και βάσει ροής είναι σημαντική.

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

## **Διατήρηση Δημόσιων Ιδιοτήτων Εγγράφου**

Από προεπιλογή, το Aspose.Slides περιλαμβάνει τις ιδιότητες εγγράφου στην κρυπτογράφηση της παρουσίασης. Η μέθοδος [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) ελέγχει αυτή τη συμπεριφορά ανεξάρτητα από την κρυπτογράφηση του περιεχομένου των διαφανειών. Περνάτε `false` πριν καλέσετε το [ProtectionManager::encrypt](https://reference.aspose.com/slides/el/php-java/aspose.slides/protectionmanager/#encrypt) όταν ένα σύστημα ευρετηρίασης, ταξινόμησης, αναζήτησης ή διαχείρισης εγγράφων πρέπει να διαβάσει τα μεταδεδομένα χωρίς τον κωδικό πρόσβασης ανοίγματος.

Το παρακάτω παράδειγμα δημιουργεί μια κρυπτογραφημένη παρουσίαση PPTX ενώ διατηρεί τις ενσωματωμένες ιδιότητες εγγράφου δημόσιες:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $properties = $presentation->getDocumentProperties();
    $properties->setAuthor("Contoso Knowledge Management");
    $properties->setTitle("Quarterly Product Roadmap");
    $properties->setKeywords("roadmap, planning, internal");

    $presentation->getSlides()->get_Item(0)->setName("Encrypted presentation content");
    $presentation->getProtectionManager()->setEncryptDocumentProperties(false);
    $presentation->getProtectionManager()->encrypt("open_password");
    $presentation->save("public-properties-encrypted.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Η περάτωση του `false` στη μέθοδο [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) δεν καθιστά τις διαφάνειες, τα master, τα layouts, τα σχήματα, τα πολυμέσα ή άλλο περιεχόμενο παρουσίασης δημόσια. Επηρεάζει μόνο τις ιδιότητες εγγράφου. Για να διαβάσετε αυτές τις ιδιότητες χωρίς τη φόρτωση του κρυπτογραφημένου περιεχομένου, δείτε [Διαχείριση Ιδιοτήτων Παρουσίασης](/slides/el/php-java/presentation-properties/).

## **Φόρτωση Κρυπτογραφημένης Παρουσίασης**

Ορίστε το [LoadOptions::setPassword](https://reference.aspose.com/slides/el/php-java/aspose.slides/loadoptions/#setPassword) στον κωδικό πρόσβασης ανοίγματος και περάστε τις επιλογές στη [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) κατά τη φόρτωση του αρχείου. Η φόρτωση αποτυγχάνει όταν απαιτείται κωδικός πρόσβασης ανοίγματος αλλά ο παρεχόμενος κωδικός είναι ελλιπής ή λανθασμένος.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    # Εργαστείτε με την αποκρυπτογραφημένη παρουσίαση.
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

Χρησιμοποιήστε το [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationfactory/#getPresentationInfo) για να αποκτήσετε το [PresentationInfo](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationinfo/) χωρίς τη δημιουργία πλήρους παρουσιαστικού αντικειμένου. Ελέγξτε το [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationinfo/#isPasswordProtected) πριν ζητήσετε ή επικυρώσετε έναν κωδικό πρόσβασης. Όταν υπάρχει προστασία, επικυρώστε την παρεχόμενη τιμή με το [PresentationInfo::checkPassword](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationinfo/#checkPassword).

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

### **Ροή Εργασίας με Ροή (Stream)**

Η υπερφόρτωση ροής του [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationfactory/#getPresentationInfo) παρέχει την ίδια ροή εργασίας. Επαναρυθμίστε τη θέση μιας ρευσαρίσιμης ροής πριν φορτώσετε την πλήρη παρουσίαση από αυτήν τη ροή.

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

### **Τιμές Επιστροφής checkPassword**

Το [PresentationInfo::checkPassword](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationinfo/#checkPassword) επιστρέφει `true` μόνο όταν η παρουσίαση έχει κωδικό πρόσβασης ανοίγματος και ο παρεχόμενος κωδικός είναι σωστός. Επιστρέφει `false` σε καθένα από τις παρακάτω περιπτώσεις:

- Ο κωδικός πρόσβασης είναι λανθασμένος.
- Η παρουσίαση δεν έχει κωδικό πρόσβασης ανοίγματος.
- Ο παρεχόμενος κωδικός πρόσβασης είναι `null` ή κενός.

Η συμπεριφορά είναι η ίδια για παρουσιάσεις PPT και PPTX.

## **Έλεγχος Εάν Η Φορτωμένη Παρουσίαση Είναι Κρυπτογραφημένη**

Μετά τη φόρτωση μιας παρουσίασης με τον σωστό κωδικό, εξετάστε το [ProtectionManager::isEncrypted](https://reference.aspose.com/slides/el/php-java/aspose.slides/protectionmanager/#isEncrypted) για να επιβεβαιώσετε ότι η αρχική παρουσίαση ήταν κρυπτογραφημένη. Για να ανιχνεύσετε την προστασία κωδικού πρόσβασης ανοίγματος πριν τη φόρτωση, χρησιμοποιήστε το [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationinfo/#isPasswordProtected) όπως φαίνεται παραπάνω.

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

## **Συστάσεις Ασφαλείας**

{{% alert color="warning" title="Ασφάλεια" %}}
Μην καταγράφετε τους κωδικούς πρόσβασης ανοίγματος ούτε τους συμπεριλαμβάνετε σε διαγνωστικά μηνύματα. Αποφύγετε περιττές επανειλημμένες προσπάθειες επικύρωσης, διατηρήστε τους κωδικούς πρόσβασης στη μνήμη μόνο όσο χρειάζεται, και επαναχρησιμοποιήστε ένα επιτυχημένο αποτέλεσμα επικύρωσης όταν φορτώνετε αμέσως την παρουσίαση.

Οι δημόσιες ιδιότητες εγγράφου μπορεί να αποκαλύψουν ονόματα δημιουργών, τίτλους, θέματα, λέξεις‑κλειδιά, πληροφορίες εταιρείας, σχόλια και προσαρμοσμένες τιμές, ακόμη και αν το περιεχόμενο της παρουσίασης είναι κρυπτογραφημένο. Κρυπτογραφήστε τα ευαίσθητα μεταδεδομένα μαζί με την παρουσίαση. Η διατήρηση των ιδιοτήτων δημόσιων πρέπει να είναι έλεγχή απόφαση που λαμβάνεται μόνο όταν τα συστήματα πρέπει να ευρετηριάσουν, ταξινομήσουν, αναζητήσουν ή διαχειριστούν το αρχείο χωρίς κωδικό πρόσβασης ανοίγματος.
{{% /alert %}}

## **Προστασία Παρουσίασης με Κωδικό Πρόσβασης Online**

1. Ανοίξτε την εφαρμογή [Aspose.Slides Lock](https://products.aspose.app/slides/el/lock).
2. Επιλέξτε ή ανεβάστε την παρουσίαση.
3. Εισάγετε έναν κωδικό πρόσβασης για προστασία προβολής.
4. Προαιρετικά, εισάγετε έναν ξεχωριστό κωδικό πρόσβασης για προστασία επεξεργασίας.
5. Εφαρμόστε την προστασία και κατεβάστε το δημιουργημένο αρχείο.

{{% alert color="info" title="Δείτε επίσης" %}}
- [Προστασία Παρουσιάσεων από Εγγραφή](/slides/el/php-java/write-protected-presentation/)
- [Ψηφιακή Υπογραφή στο PowerPoint](/slides/el/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ κωδικού πρόσβασης ανοίγματος και κωδικού πρόσβασης προστασίας εγγραφής;**

Ένας κωδικός πρόσβασης ανοίγματος κρυπτογραφεί την παρουσίαση και απαιτείται για τη φόρτωση του περιεχομένου της. Ένας κωδικός πρόσβασης προστασίας εγγραφής περιορίζει την τροποποίηση χωρίς να κρυπτογραφεί το περιεχόμενο.

**Μπορώ να επικυρώσω έναν κωδικό πρόσβασης ανοίγματος χωρίς να φορτώσω όλες τις διαφάνειες;**

Ναι. Λάβετε πληροφορίες παρουσίασης, ελέγξτε εάν υπάρχει προστασία κωδικού πρόσβασης ανοίγματος, και επικυρώστε τον κωδικό πριν δημιουργήσετε ένα πλήρες αντικείμενο παρουσίασης.

**Μπορεί μια εφαρμογή να διαβάσει μεταδεδομένα χωρίς τον κωδικό πρόσβασης ανοίγματος;**

Ναι, αλλά μόνο όταν η παρουσίαση κρυπτογραφήθηκε με την κρυπτογράφηση ιδιοτήτων εγγράφου απενεργοποιημένη. Η εφαρμογή πρέπει τότε να χρησιμοποιήσει τη λειτουργία φόρτωσης μόνο ιδιοτήτων εγγράφου που περιγράφεται στο [Διαχείριση Ιδιοτήτων Παρουσίασης](/slides/el/php-java/presentation-properties/).

**Υποστηρίζουν οι ροές ελέγχου κωδικών πρόσβασης και τα δύο, PPT και PPTX;**

Ναι. Η ανίχνευση κωδικών πρόσβασης και η επικύρωση βάσει διαδρομής αρχείου και ροής λειτουργούν με τον ίδιο τρόπο για παρουσιάσεις PPT και PPTX.