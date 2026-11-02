---
title: Διαχείριση Ιδιοτήτων Παρουσίασης σε PHP
linktitle: Ιδιότητες Παρουσίασης
type: docs
weight: 70
url: /el/php-java/presentation-properties/
keywords:
- Ιδιότητες PowerPoint
- Ιδιότητες παρουσίασης
- Ιδιότητες εγγράφου
- Ενσωματωμένες ιδιότητες
- Προσαρμοσμένες ιδιότητες
- Προχωρημένες ιδιότητες
- Διαχείριση ιδιοτήτων
- Τροποποίηση ιδιοτήτων
- Μεταδεδομένα εγγράφου
- Επεξεργασία μεταδεδομένων
- Γλώσσα διόρθωσης
- Προεπιλεγμένη γλώσσα
- PowerPoint
- OpenDocument
- Παρουσίαση
- PHP
- Aspose.Slides
description: "Διαχειριστείτε τις κύριες ιδιότητες παρουσίασης στο Aspose.Slides για PHP μέσω Java και βελτιστοποιήστε την αναζήτηση, το branding και τη ροή εργασίας στα αρχεία PowerPoint και OpenDocument σας."
---
## **Εισαγωγή**

Το Aspose.Slides για PHP μέσω Java υποστηρίζει **ενσωματωμένες** και **προσαρμοσμένες** ιδιότητες εγγράφου. Χρησιμοποιήστε αυτές τις ιδιότητες για να διαβάζετε και να ενημερώνετε τα μεταδεδομένα της παρουσίασης, όπως ο συγγραφέας, ο τίτλος και τιμές που ορίζονται από τον χρήστη.

Το Aspose.Slides σας επιτρέπει να εργάζεστε με τις ιδιότητες εγγράφου της παρουσίασης μέσω της κλάσης [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) . Μια παρουσίαση αυτής της κλάσης επιστρέφεται από τη μέθοδο [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/). Τα παρακάτω παραδείγματα δείχνουν πώς να διαβάσετε, να τροποποιήσετε και να διαχειριστείτε αυτές τις ιδιότητες. Υποθέτουν ότι το PHP/Java Bridge και το PHP wrapper του Aspose.Slides έχουν αρχικοποιηθεί.

{{% alert color="info" title="Note" %}}
Το Aspose.Slides διαχειρίζεται τα μεταδεδομένα της εφαρμογής και του δημιουργού κατά την αποθήκευση παρουσιάσεων· αυτά τα πεδία ταυτοποιούν το λογισμικό που δημιούργησε το αποτέλεσμα.
{{% /alert %}}

## **Διαχείριση Ιδιοτήτων Παρουσίασης**

Οι ιδιότητες εγγράφου αποθηκεύουν περιγραφικές πληροφορίες μαζί με το περιεχόμενο της παρουσίασης. Κατηγοριοποιούνται σε δύο κατηγορίες:

- **Ενσωματωμένες ιδιότητες** περιέχουν τυπικά μεταδεδομένα, όπως ο τίτλος, ο συγγραφέας και οι στατιστικές του εγγράφου.
- **Προσαρμοσμένες ιδιότητες** αποθηκεύουν ζεύγη ονόματος/τιμής που ορίζονται από τον χρήστη.

Το Aspose.Slides για PHP μέσω Java παρέχει πρόσβαση και στις δύο κατηγορίες. Στο PowerPoint, επιλέξτε **File → Info → Properties → Advanced Properties** για να επιθεωρήσετε τα μεταδεδομένα του εγγράφου. Το παράθυρο διαλόγου ομαδοποιεί τις πληροφορίες σε καρτέλες όπως **Summary**, **Statistics**, **Contents**, και **Custom**. Χρησιμοποιήστε την καρτέλα **Custom** για να διαχειριστείτε τις ιδιότητες που ορίζονται από τον χρήστη.

## **Ανάγνωση Δημόσιων Ιδιοτήτων από Κρυπτογραφημένη Παρουσίαση**

Ένας κωδικός πρόσβασης ανοίγματος προστατεύει κανονικά τόσο το περιεχόμενο της παρουσίασης όσο και τις ιδιότητες του εγγράφου. Όταν μια παρουσίαση κρυπτογραφείται μετά την κλήση της μεθόδου [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/setencryptdocumentproperties/) με `false`, οι ιδιότητές της παραμένουν δημόσιες. Μία εφαρμογή μπορεί στη συνέχεια να καλέσει τη μέθοδο [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) με `true` και να διαβάσει τα δημόσια μεταδεδομένα χωρίς να παρέχει τον κωδικό πρόσβασης ανοίγματος.

[LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) ελέγχει τι φορτώνει το Aspose.Slides· δεν αποκρυπτογραφεί τίποτα. Εάν οι ιδιότητες περιλαμβάνονταν στην κρυπτογράφηση, η φόρτωση τους χωρίς κωδικό αποτυγχάνει. Εάν η παρουσίαση δεν είναι κρυπτογραφημένη, η επιλογή αγνοείται και η πλήρης παρουσίαση φορτώνεται.

Το παράδειγμα απαιτεί μια κρυπτογραφημένη παρουσίαση των ιδιοτήτων της οποίες έχουν παραμείνει δημόσιες. Ελέγχει τη λειτουργία φόρτωσης μέσω της μεθόδου [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/isonlydocumentpropertiesloaded/) και στη συνέχεια διαβάζει τις ενσωματωμένες ιδιότητες μέσω της [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/):

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("public-properties-encrypted.pptx", $loadOptions);
try {
    if (java_values($presentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        $documentProperties = $presentation->getDocumentProperties();

        echo("Author: " . $documentProperties->getAuthor() . "\n");
        echo("Title: " . $documentProperties->getTitle() . "\n");
        echo("Keywords: " . $documentProperties->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode." . "\n");
    }
} finally {
    $presentation->dispose();
}
```

Σε αυτή τη λειτουργία, το περιεχόμενο των διαφανειών δεν φορτώνεται. Οι διαφάνειες, τα master, οι διάταξεις, τα σχήματα, τα μέσα και άλλα αντικείμενα παρουσίασης δεν είναι διαθέσιμα. Οι εφαρμογές πρέπει πάντα να ελέγχουν το [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/isonlydocumentpropertiesloaded/) πριν εκτελέσουν μια λειτουργία που απαιτεί το πλήρες μοντέλο αντικειμένων της παρουσίασης.

{{% alert color="warning" title="Warning" %}}
Τα δημόσια μεταδεδομένα μπορεί να εκθέτουν ονόματα συγγραφέων, τίτλους, θέματα, λέξεις-κλειδιά, πληροφορίες εταιρείας, σχόλια και προσαρμοσμένες τιμές. Κρυπτογραφήστε τις ευαίσθητες ιδιότητες μαζί με την παρουσίαση. Διατηρήστε τις δημόσιες μόνο όταν συστήματα ευρετηρίασης, ταξινόμησης, αναζήτησης ή διαχείρισης εγγράφων έχουν ειδική ανάγκη πρόσβασης χωρίς κωδικό.
{{% /alert %}}

## **Ενημέρωση Ιδιοτήτων Κρυπτογραφημένης Παρουσίασης**

Για ένα κρυπτογραφημένο αρχείο PPTX, μια παρουσίαση που φορτώνεται μετά την κλήση του [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) με `true` προορίζεται για ανάγνωση δημόσιων μεταδεδομένων. Το Aspose.Slides δεν μπορεί να αποθηκεύσει αλλαγμένες ιδιότητες από αυτό το αντικείμενο μόνο‑με‑μεταδεδομένα επειδή οι δημόσιες ιδιότητες πρέπει να παραμένουν συνεπείς με τα αντίστοιχα δεδομένα μέσα στην κρυπτογραφημένη παρουσίαση. Η ενημέρωσή τους επομένως απαιτεί τον σωστό κωδικό ανοίγματος και πλήρη φόρτωση.

Το παράδειγμα απαιτεί μια κρυπτογραφημένη παρουσίαση PPTX με δημόσιες ιδιότητες εγγράφου και έναν γνωστό κωδικό ανοίγματος. Ανοίγει την πλήρη παρουσίαση με το [LoadOptions::setPassword](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setpassword/), ενημερώνει τις δημόσιες ενσωματωμένες ιδιότητες και αποθηκεύει το αποτέλεσμα. Στη συνέχεια χρησιμοποιεί το [PresentationInfo::isEncrypted](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/isencrypted/) για να επαληθεύσει ότι η κρυπτογράφηση διατηρείται και ανοίγει ξανά τα δημόσια μεταδεδομένα χωρίς κωδικό για να ελέγξει τις νέες τιμές:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;
use aspose\slides\SaveFormat;

$inputPath = "public-properties-encrypted.pptx";
$outputPath = "updated-public-properties-encrypted.pptx";

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation($inputPath, $loadOptions);
try {
    $documentProperties = $presentation->getDocumentProperties();
    $documentProperties->setTitle("Updated Product Roadmap");
    $documentProperties->setKeywords("roadmap, planning, indexed");
    
    $presentation->save($outputPath, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($outputPath);
echo("The presentation is encrypted: " . (java_values($presentationInfo->isEncrypted()) ? "true" : "false") . "\n");

$metadataLoadOptions = new LoadOptions();
$metadataLoadOptions->setOnlyLoadDocumentProperties(true);

$metadataPresentation = new Presentation($outputPath, $metadataLoadOptions);
try {
    if (java_values($metadataPresentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        echo("Title: " . $metadataPresentation->getDocumentProperties()->getTitle() . "\n");
        echo("Keywords: " . $metadataPresentation->getDocumentProperties()->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode." . "\n");
    }
} finally {
    $metadataPresentation->dispose();
}
```

Εάν μια εφαρμογή δεν επιτρέπεται να αποκρυπτογραφήσει ή να φορτώσει το περιεχόμενο της παρουσίασης, πρέπει να αντιμετωπίζει τις δημόσιες ιδιότητες ενός κρυπτογραφημένου αρχείου PPTX ως μόνο για ανάγνωση.

## **Πρόσβαση στις Ενσωματωμένες Ιδιότητες**

Η κλάση [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) εκθέτει ενσωματωμένα μεταδεδομένα μέσω μεθόδων getter, συμπεριλαμβανομένων των [getAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getauthor/), [getTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/gettitle/) και [getCreatedTime](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcreatedtime/). Αυτό το παράδειγμα ανοίγει μια υπάρχουσα παρουσίαση και εκτυπώνει τα αποθηκευμένα μεταδεδομένα στην κονσόλα. Οι τιμές εξαρτώνται από την είσοδο της παρουσίασης· ορισμένα πεδία μπορεί να είναι κενά.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("AccessBuiltInProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    echo("Category: " . $documentProperties->getCategory() . "\n");
    echo("Content status: " . $documentProperties->getContentStatus() . "\n");
    echo("Creation date: " . $documentProperties->getCreatedTime() . "\n");
    echo("Author: " . $documentProperties->getAuthor() . "\n");
    echo("Comments: " . $documentProperties->getComments() . "\n");
    echo("Keywords: " . $documentProperties->getKeywords() . "\n");
    echo("Last modified by: " . $documentProperties->getLastSavedBy() . "\n");
    echo("Manager: " . $documentProperties->getManager() . "\n");
    echo("Modified date: " . $documentProperties->getLastSavedTime() . "\n");
    echo("Presentation format: " . $documentProperties->getPresentationFormat() . "\n");
    echo("Last print date: " . $documentProperties->getLastPrinted() . "\n");
    echo("Is shared between producers: " . (java_values($documentProperties->getSharedDoc()) ? "true" : "false") . "\n");
    echo("Subject: " . $documentProperties->getSubject() . "\n");
    echo("Title: " . $documentProperties->getTitle() . "\n");
} finally {
    $presentation->dispose();
}
```

## **Τροποποίηση Ενσωματωμένων Ιδιοτήτων**

Για να ενημερώσετε ενσωματωμένα μεταδεδομένα, χρησιμοποιήστε τις μεθόδους setter στο αντικείμενο που επιστρέφεται από το [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/). Αυτό το παράδειγμα ανοίγει μια υπάρχουσα παρουσίαση, καλεί τις μεθόδους [setAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setauthor/), [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/settitle/), [setSubject](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setsubject/), [setComments](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setcomments/) και [setManager](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setmanager/), στη συνέχεια αποθηκεύει την ενημερωμένη παρουσίαση με το [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/). Το αποθηκευμένο PPTX περιέχει τα νέα μεταδεδομένα.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("ModifyBuiltInProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    $documentProperties->setAuthor("Aspose.Slides for PHP via Java");
    $documentProperties->setTitle("Manage PowerPoint Presentation Properties");
    $documentProperties->setSubject("Modify Built-in Properties");
    $documentProperties->setComments("Aspose description");
    $documentProperties->setManager("Aspose manager");

    $presentation->save("DocumentProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Διαχείριση της Βάσης Υπερσυνδέσμων**

[DocumentProperties::getHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/gethyperlinkbase/) επιστρέφει τη βάση επιπέδου εγγράφου για σχετικούς υπερσυνδέσμους. Χρησιμοποιήστε το [DocumentProperties::setHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/sethyperlinkbase/) για να την αλλάξετε ή να την αφαιρέσετε. Αυτό είναι χρήσιμο όταν μετακινείται μια παρουσίαση και τα συνδεδεμένα αρχεία της σε άλλη τοποθεσία. Είναι ξεχωριστό από τον εξωτερικό σύνδεσμο ενός μεμονωμένου υπερσυνδέσμου [Hyperlink::getExternalUrl](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getexternalurl/): η αλλαγή της βάσης δεν ξαναγράφει τις αποθηκευμένες διευθύνσεις συνδέσμων ούτε αλλάζει απόλυτους προορισμούς.

Το παράδειγμα απαιτεί μια παρουσίαση που περιέχει τόσο έναν σχετικό σύνδεσμο, όπως `target.html`, όσο και έναν απόλυτο σύνδεσμο, όπως `https://example.org/absolute.html`. Διαβάζει τη βάση που υπάρχει, ορίζει μια νέα διεύθυνση βάσης, και αποθηκεύει και ανοίγει ξανά την παρουσίαση για να ελέγξει την τιμή. Στη συνέχεια αφαιρεί τη βάση με κενή συμβολοσειρά και επαληθεύει την κενή τιμή σε ξεχωριστό αποθηκευμένο αρχείο. Αντικαταστήστε τη δείγμα διεύθυνση βάσης με τη θέση των συνδεδεμένων αρχείων σας.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("hyperlinks.pptx");
try {
    echo("Original base: " . $presentation->getDocumentProperties()->getHyperlinkBase() . "\n");

    $newBase = "https://example.com/new/";
    $presentation->getDocumentProperties()->setHyperlinkBase($newBase);
    $presentation->save("hyperlinks-updated.pptx", SaveFormat::Pptx);

    $updatedPresentation = new Presentation("hyperlinks-updated.pptx");
    try {
        echo("Base preserved: " . ((string) $updatedPresentation->getDocumentProperties()->getHyperlinkBase() === $newBase ? "true" : "false") . "\n");

        $updatedPresentation->getDocumentProperties()->setHyperlinkBase("");
        $updatedPresentation->save("hyperlinks-cleared.pptx", SaveFormat::Pptx);

        $clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
        try {
            echo("Base cleared: " . ((string) $clearedPresentation->getDocumentProperties()->getHyperlinkBase() === "" ? "true" : "false") . "\n");
        } finally {
            $clearedPresentation->dispose();
        }
    } finally {
        $updatedPresentation->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Τα δύο μηνύματα επαλήθευσης πρέπει να εκτυπώσουν `true`. Η αφαίρεση της βάσης αφήνει ανέπαφες τις διευθύνσεις των μεμονωμένων υπερσυνδέσμων.

Ένας σχετικός σύνδεσμος προς `target.pptx` άνοιγε `old/target.pptx` όταν η βάση έδειχνε στο φάκελο `old`. Αφού αλλάξει η βάση στο φάκελο `new`, αποθηκεύοντας και ανοίγοντας ξανά την παρουσίαση, ο ίδιος σύνδεσμος άνοιγε `new/target.pptx`. Ένας απόλυτος σύνδεσμος συνέχισε να ανοίγει το ίδιο αρχείο. Δοκιμάστε τους σχετικούς συνδέσμους σας στο PowerPoint πριν και μετά τη μετακίνηση της παρουσίασης ή την αλλαγή της βάσης.

## **Προσθήκη Προσαρμοσμένων Ιδιοτήτων Παρουσίασης**

Οι προσαρμοσμένες ιδιότητες αποθηκεύουν μεταδεδομένα που δεν έχουν αντίστοιχη ενσωματωμένη πεδίο. Η μέθοδος [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/set_item/) σας επιτρέπει να αντιστοιχίσετε μια τιμή με βάση το όνομα της ιδιότητας. Αυτό το παράδειγμα δημιουργεί μια παρουσίαση, προσθέτει δύο τιμές κειμένου και μια αριθμητική τιμή έκδοσης, και αποθηκεύει την παρουσίαση με το [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/). Η ανάθεση τιμής σε υπάρχον όνομα αντικαθιστά την τιμή της ιδιότητας.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $documentProperties = $presentation->getDocumentProperties();

    $documentProperties->set_Item("Reviewed by", "John Smith");
    $documentProperties->set_Item("Confidentiality level", "Internal");
    $documentProperties->set_Item("Document version", 2);

    $presentation->save("CustomDocumentProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Πρόσβαση και Τροποποίηση Προσαρμοσμένων Ιδιοτήτων**

Αυτό το παράδειγμα ανοίγει μια παρουσίαση που περιέχει προσαρμοσμένες ιδιότητες και χρησιμοποιεί το [getCountOfCustomProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcountofcustomproperties/) για επανάληψη πάνω σε αυτές. Η [getCustomPropertyName](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcustompropertyname/) δέχεται έναν μηδενική‑βασική δείκτη και επιστρέφει το όνομα που χρησιμοποιείται από το [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/set_item/). Το παράδειγμα εκτυπώνει κάθε αρχικό όνομα και τιμή, αντικαθιστά κάθε τιμή με μια αριθμημένη συμβολοσειρά ανεξάρτητα από τον αρχικό τύπο, και αποθηκεύει τις αλλαγές. Εάν δεν υπάρχουν προσαρμοσμένες ιδιότητες, η επανάληψη δεν κάνει καμία αλλαγή.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("AccessAndModifyProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    for ($i = 0; $i < java_values($documentProperties->getCountOfCustomProperties()); $i++) {
        $propertyName = $documentProperties->getCustomPropertyName($i);
        $propertyValue = $documentProperties->get_Item($propertyName);

        echo("Custom property name: " . $propertyName . "\n");
        echo("Custom property value: " . $propertyValue . "\n");

        $documentProperties->set_Item($propertyName, "New Value " . ($i + 1));
    }

    $presentation->save("CustomProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ζωντανό Παράδειγμα**

Δοκιμάστε την [**Προβολή & Επεξεργασία Μεταδεδομένων PowerPoint**](https://products.aspose.app/slides/metadata) διαδικτυακή εφαρμογή για να δείτε πώς να εργάζεστε με τις ιδιότητες εγγράφου χρησιμοποιώντας το API του Aspose.Slides:

[![Προβολή & Επεξεργασία Μεταδεδομένων PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να αφαιρέσω μια ενσωματωμένη ιδιότητα από μια παρουσίαση;**

Οι ενσωματωμένες ιδιότητες αποτελούν αναπόσπαστο μέρος της παρουσίασης και δεν μπορούν να αφαιρεθούν εντελώς. Ωστόσο, μπορείτε είτε να αλλάξετε τις τιμές τους είτε να τις ορίσετε κενές εφόσον το επιτρέπει η συγκεκριμένη ιδιότητα.

**Τι συμβαίνει αν προσθέσω μια προσαρμοσμένη ιδιότητα που υπάρχει ήδη;**

Εάν προσθέσετε μια προσαρμοσμένη ιδιότητα που υπάρχει ήδη, η υπάρχουσα τιμή της θα αντικατασταθεί με τη νέα. Δεν χρειάζεται να αφαιρέσετε ή να ελέγξετε την ιδιότητα εκ των προτέρων, καθώς το Aspose.Slides ενημερώνει αυτόματα την τιμή της ιδιότητας.

**Μπορώ να έχω πρόσβαση στις ιδιότητες της παρουσίασης χωρίς να φορτώσω πλήρως την παρουσίαση;**

Ναι. Χρησιμοποιήστε το [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/presentationfactory/getpresentationinfo/) και στη συνέχεια το [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/readdocumentproperties/) για να διαβάσετε τα αποθηκευμένα μεταδεδομένα εγγράφου χωρίς να δημιουργήσετε μια παρουσίαση [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) . Δείτε το [Δημιουργία Ελαφρού Καταλόγου Παρουσιάσεων](/slides/el/php-java/examine-presentation/) για ένα πλήρες παράδειγμα αναφοράς και περιορισμούς ανά μορφή.

**Μπορώ να διαβάσω δημόσιες ιδιότητες κρυπτογραφημένης παρουσίασης χωρίς τον κωδικό ανοίγματος;**

Ναι. Η παρουσίαση πρέπει να έχει κρυπτογραφηθεί μετά την κλήση του [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/setencryptdocumentproperties/) με `false`, και πρέπει να φορτωθεί μετά την κλήση του [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) με `true`.

**Μπορώ να ενημερώσω ένα κρυπτογραφημένο αρχείο PPTX σε λειτουργία μόνο‑ιδιοτήτων‑εγγράφου;**

Όχι. Οι δημόσιες και κρυπτογραφημένες ιδιότητες πρέπει να παραμείνουν συνεπείς, επομένως η ενημέρωση ενός κρυπτογραφημένου αρχείου PPTX απαιτεί τη φόρτωση της πλήρης παρουσίασης με τον σωστό κωδικό ανοίγματος.