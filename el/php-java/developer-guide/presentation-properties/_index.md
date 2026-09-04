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
- Προηγμένες ιδιότητες
- Διαχείριση ιδιοτήτων
- Τροποποίηση ιδιοτήτων
- Μεταδεδομένα εγγράφου
- Επεξεργασία μεταδεδομένων
- Γλώσσα ελέγχου ορθογραφίας
- Προεπιλεγμένη γλώσσα
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Διαχειριστείτε κύριες ιδιότητες παρουσίασης στο Aspose.Slides για PHP μέσω Java και βελτιστοποιήστε την αναζήτηση, την σήμανση και τη ροή εργασίας στα αρχεία PowerPoint και OpenDocument σας."
---
## **Εισαγωγή**

Το Aspose.Slides υποστηρίζει δύο τύπους ιδιοτήτων εγγράφου: **Built-in** και **Custom**. Και οι δύο τύποι ιδιοτήτων μπορούν εύκολα να προσπελαστούν και να διαχειριστούν χρησιμοποιώντας το API του Aspose.Slides.

Το Aspose.Slides σας επιτρέπει να εργάζεστε με τις ιδιότητες εγγράφου της παρουσίασης μέσω της κλάσης [DocumentProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/documentproperties/) . Μια παρουσία της κλάσης αυτής επιστρέφεται από τη μέθοδο [Presentation::getDocumentProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#getDocumentProperties) . Τα παρακάτω παραδείγματα δείχνουν πώς να διαβάσετε, να τροποποιήσετε και να διαχειριστείτε αυτές τις ιδιότητες.

{{% alert color="info" title="Note" %}}

Παρακαλούμε σημειώστε ότι τα πεδία **Application** και **AppVersion** δεν μπορούν να τροποποιηθούν. Το Aspose.Slides τα ξαναγράφει σε κάθε αποθήκευση, έτσι μια αποθηκευμένη παρουσίαση πάντα αναφέρει "Aspose.Slides for PHP via Java" και την έκδοση της βιβλιοθήκης που την παρήγαγε. Οποιαδήποτε τιμή δοθεί στη μέθοδο `setNameOfApplication` απορρίπτεται όταν η παρουσίαση γράφεται.

{{% /alert %}} 

## **Διαχείριση Ιδιοτήτων Παρουσίασης**

Το Microsoft PowerPoint παρέχει μια δυνατότητα για προσθήκη ορισμένων ιδιοτήτων στα αρχεία παρουσίασης. Αυτές οι ιδιότητες εγγράφου επιτρέπουν την αποθήκευση χρήσιμων πληροφοριών μαζί με τα έγγραφα (αρχεία παρουσίασης). Υπάρχουν δύο είδη ιδιοτήτων εγγράφου ως εξής

- System Defined (Built‑in) Properties  
- User‑Defined (Custom) Properties  

Οι **Built-in** ιδιότητες περιέχουν γενικές πληροφορίες για το έγγραφο, όπως ο τίτλος του εγγράφου, το όνομα του δημιουργού, στατιστικά του εγγράφου κ.λπ. Οι **Custom** ιδιότητες είναι αυτές που ορίζονται από τους χρήστες ως ζεύγη **Name/Value**, όπου τόσο το όνομα όσο και η τιμή καθορίζονται από τον χρήστη. Χρησιμοποιώντας το Aspose.Slides for PHP via Java, οι προγραμματιστές μπορούν να προσπελάσουν και να τροποποιήσουν τις τιμές των ενσωματωμένων ιδιοτήτων καθώς και των προσαρμοσμένων ιδιοτήτων.

## **Ιδιότητες Εγγράφου στο PowerPoint**

Το Microsoft PowerPoint 2007 επιτρέπει τη διαχείριση των ιδιοτήτων εγγράφου των αρχείων παρουσίασης. Το μόνο που χρειάζεται να κάνετε είναι να κάνετε κλικ στο εικονίδιο Office και στη συνέχεια στην εντολή **Prepare | Properties | Advanced Properties** του Microsoft PowerPoint 2007 όπως φαίνεται παρακάτω:

|**Επιλογή στοιχείου μενού Advanced Properties**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Αφού επιλέξετε το στοιχείο μενού **Advanced Properties**, εμφανίζεται ένας διάλογος που σας επιτρέπει να διαχειριστείτε τις ιδιότητες εγγράφου του αρχείου PowerPoint, όπως φαίνεται στην παρακάτω εικόνα:

|**Διάλογος Ιδιοτήτων**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

Στον παραπάνω **Διάλογο Ιδιοτήτων**, μπορείτε να δείτε ότι υπάρχουν πολλές καρτέλες όπως **General**, **Summary**, **Statistics**, **Contents** και **Custom**. Όλες αυτές οι καρτέλες επιτρέπουν τη ρύθμιση διαφορετικών τύπων πληροφοριών που σχετίζονται με τα αρχεία PowerPoint. Η καρτέλα **Custom** χρησιμοποιείται για τη διαχείριση των προσαρμοσμένων ιδιοτήτων των αρχείων PowerPoint.

### Εργασία με Ιδιότητες Εγγράφου Χρησιμοποιώντας Aspose.Slides for PHP via Java

Όπως περιγράψαμε νωρίτερα, το Aspose.Slides for PHP via Java υποστηρίζει δύο είδη ιδιοτήτων εγγράφου: **Built-in** και **Custom**. Συνεπώς, οι προγραμματιστές μπορούν να προσπελάσουν και τα δύο είδη ιδιοτήτων με τη χρήση του API του Aspose.Slides for PHP via Java. Το Aspose.Slides for PHP via Java παρέχει την κλάση [DocumentProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/documentproperties) η οποία αντιπροσωπεύει τις ιδιότητες εγγράφου που σχετίζονται με ένα αρχείο παρουσίασης μέσω της ιδιότητας **Presentation.DocumentProperties**.

Οι προγραμματιστές μπορούν να χρησιμοποιήσουν την ιδιότητα **DocumentProperties** που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation) για να προσπελάσουν τις ιδιότητες εγγράφου των αρχείων παρουσίασης όπως περιγράφεται παρακάτω:

## **Ανάγνωση Δημόσιων Ιδιοτήτων από Κρυπτογραφημένη Παρουσίαση**

Ένας κωδικός ανοίγματος προστατεύει κανονικά τόσο το περιεχόμενο της παρουσίασης όσο και τις ιδιότητες εγγράφου. Όταν μια παρουσίαση κρυπτογραφηθεί με τη μέθοδο `false` στο [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties), οι ιδιότητες εγγράφου παραμένουν δημόσιες. Μία εφαρμογή μπορεί στη συνέχεια να περάσει `true` στο [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) και να διαβάσει τα δημόσια μεταδεδομένα χωρίς να παρέχει τον κωδικό ανοίγματος.

Η επιλογή «μόνο ιδιότητες εγγράφου» ελέγχει τι φορτώνει το Aspose.Slides· δεν αποκρυπτογραφεί τίποτα. Αν οι ιδιότητες περιλαμβάνονταν στην κρυπτογράφηση, η φόρτωσή τους χωρίς κωδικό αποτυγχάνει. Αν η παρουσίαση δεν είναι κρυπτογραφημένη, η επιλογή αγνοείται και φορτώνεται όλη η παρουσίαση.

Το παρακάτω παράδειγμα ελέγχει τη λειτουργία φόρτωσης μέσω του [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/el/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) και στη συνέχεια διαβάζει τις ενσωματωμένες ιδιότητες μέσω του [Presentation::getDocumentProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#getDocumentProperties):

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("public-properties-encrypted.pptx", $loadOptions);
try {
    if (java_values($presentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        $properties = $presentation->getDocumentProperties();

        echo("Author: " . $properties->getAuthor() . "\n");
        echo("Title: " . $properties->getTitle() . "\n");
        echo("Keywords: " . $properties->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode.\n");
    }
} finally {
    $presentation->dispose();
}
```

Σε αυτή τη λειτουργία, το περιεχόμενο των διαφανειών δεν φορτώνεται. Διαφάνειες, master, layout, σχήματα, πολυμέσα και άλλα αντικείμενα παρουσίασης δεν είναι διαθέσιμα. Οι εφαρμογές πρέπει πάντα να ελέγχουν το [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/el/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) πριν εκτελέσουν λειτουργία που απαιτεί το πλήρες μοντέλο αντικειμένων της παρουσίασης.

{{% alert color="warning" title="Warning" %}}
Τα δημόσια μεταδεδομένα μπορεί να εκθέτουν ονόματα συγγραφέων, τίτλους, θέματα, λέξεις‑κλειδιά, πληροφορίες εταιρείας, σχόλια και προσαρμοσμένες τιμές. Κρυπτογραφήστε ευαίσθητες ιδιότητες μαζί με την παρουσίαση. Κρατήστε τις δημόσιες μόνο όταν η ανάγκη προέρχεται από συστήματα ευρετηρίασης, ταξινόμησης, αναζήτησης ή διαχείρισης εγγράφων που απαιτούν πρόσβαση χωρίς κωδικό.
{{% /alert %}}

## **Ενημέρωση Ιδιοτήτων Κρυπτογραφημένης Παρουσίας**

Για ένα κρυπτογραφημένο αρχείο PPTX, μια παρουσίαση που φορτώνεται σε λειτουργία «μόνο ιδιότητες εγγράφου» προορίζεται για ανάγνωση δημόσιων μεταδεδομένων. Το Aspose.Slides δεν μπορεί να αποθηκεύσει αλλαγμένες ιδιότητες από αυτό το αντικείμενο μόνο‑μεταδεδομένων επειδή οι δημόσιες ιδιότητες πρέπει να παραμείνουν συνεπείς με τα αντίστοιχα δεδομένα μέσα στην κρυπτογραφημένη παρουσίαση. Η ενημέρωσή τους απαιτεί επομένως τον σωστό κωδικό ανοίγματος και πλήρη φόρτωση.

Το παρακάτω παράδειγμα ανοίγει την παρουσίαση με [LoadOptions::setPassword](https://reference.aspose.com/slides/el/php-java/aspose.slides/loadoptions/#setPassword), ενημερώνει τις δημόσιες ενσωματωμένες ιδιότητες και αποθηκεύει το αποτέλεσμα. Στη συνέχεια χρησιμοποιεί το [PresentationInfo::isEncrypted](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationinfo/#isEncrypted) για να επαληθεύσει ότι η κρυπτογράφηση διατηρείται και ξανά ανοίγει τα δημόσια μεταδεδομένα χωρίς κωδικό για να ελέγξει τις νέες τιμές:

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
    $presentation->getDocumentProperties()->setTitle("Updated Product Roadmap");
    $presentation->getDocumentProperties()->setKeywords("roadmap, planning, indexed");
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
        echo("The presentation was not loaded in document-properties-only mode.\n");
    }
} finally {
    $metadataPresentation->dispose();
}
```

Αν μια εφαρμογή δεν επιτρέπεται να αποκρυπτογραφήσει ή να φορτώσει το περιεχόμενο της παρουσίασης, πρέπει να αντιμετωπίζει τις δημόσιες ιδιότητες ενός κρυπτογραφημένου αρχείου PPTX ως μόνο‑ανάγνωση.

## **Πρόσβαση σε Ενσωματωμένες Ιδιότητες**

Αυτές οι ιδιότητες που εκτίθενται από το αντικείμενο [DocumentProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/documentproperties) περιλαμβάνουν: **Creator** (Author), **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **Keywords**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject** και **Title**.

```php
  # Δημιουργήστε μια παρουσία της κλάσης Presentation που αντιπροσωπεύει την παρουσίαση
  $pres = new Presentation("Presentation.pptx");
  try {
    # Δημιουργήστε μια αναφορά στο αντικείμενο IDocumentProperties που σχετίζεται με την Presentation
    $dp = $pres->getDocumentProperties();
    # Εμφανίστε τις ενσωματωμένες ιδιότητες
    echo("Category : " . $dp->getCategory());
    echo("Current Status : " . $dp->getContentStatus());
    echo("Creation Date : " . $dp->getCreatedTime());
    echo("Author : " . $dp->getAuthor());
    echo("Description : " . $dp->getComments());
    echo("KeyWords : " . $dp->getKeywords());
    echo("Last Modified By : " . $dp->getLastSavedBy());
    echo("Supervisor : " . $dp->getManager());
    echo("Modified Date : " . $dp->getLastSavedTime());
    echo("Presentation Format : " . $dp->getPresentationFormat());
    echo("Last Print Date : " . $dp->getLastPrinted());
    echo("Is Shared between producers : " . $dp->getSharedDoc());
    echo("Subject : " . $dp->getSubject());
    echo("Title : " . $dp->getTitle());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Τροποποίηση Ενσωματωμένων Ιδιοτήτων**

Η τροποποίηση των ενσωματωμένων ιδιοτήτων των αρχείων παρουσίασης είναι τόσο απλή όσο η πρόσβαση σε αυτές. Απλώς αντιστοιχίστε μια συμβολοσειρά σε οποιαδήποτε επιθυμητή ιδιότητα και η τιμή της ιδιότητας θα τροποποιηθεί. Στο παρακάτω παράδειγμα δείχνουμε πώς μπορούμε να τροποποιήσουμε τις ενσωματωμένες ιδιότητες εγγράφου της παρουσίασης χρησιμοποιώντας το Aspose.Slides for PHP via Java.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Δημιουργήστε μια αναφορά στο αντικείμενο IDocumentProperties που σχετίζεται με την Presentation
    $dp = $pres->getDocumentProperties();
    # Ορίστε τις ενσωματωμένες ιδιότητες
    $dp->setAuthor("Aspose.Slides for PHP via Java");
    $dp->setTitle("Modifying Presentation Properties");
    $dp->setSubject("Aspose Subject");
    $dp->setComments("Aspose Description");
    $dp->setManager("Aspose Manager");
    # Αποθηκεύστε την παρουσίασή σας σε αρχείο
    $pres->save("DocProps.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Αυτό το παράδειγμα τροποποιεί τις ενσωματωμένες ιδιότητες της παρουσίασης όπως φαίνεται παρακάτω:

|**Ενσωματωμένες ιδιότητες εγγράφου μετά τη τροποποίηση**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Προσθήκη Προσαρμοσμένων Ιδιοτήτων Εγγράφου**

Το Aspose.Slides for PHP via Java επιτρέπει επίσης στους προγραμματιστές να προσθέσουν προσαρμοσμένες τιμές για τις ιδιότητες εγγράφου της παρουσίασης. Ένα παράδειγμα παρατίθεται παρακάτω που δείχνει πώς να ορίσετε τις προσαρμοσμένες ιδιότητες για μια παρουσίαση.

```php
  $pres = new Presentation();
  try {
    # Λήψη ιδιοτήτων εγγράφου
    $dProps = $pres->getDocumentProperties();
    # Προσθήκη προσαρμοσμένων ιδιοτήτων
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    # Λήψη ονόματος ιδιότητας σε συγκεκριμένο δείκτη
    $getPropertyName = $dProps->getCustomPropertyName(2);
    # Αφαίρεση επιλεγμένης ιδιότητας
    $dProps->removeCustomProperty($getPropertyName);
    # Αποθήκευση παρουσίασης
    $pres->save("CustomDemo.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|**Προσαρμοσμένες Ιδιότητες Εγγράφου Προστέθηκαν**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Πρόσβαση και Τροποποίηση Προσαρμοσμένων Ιδιοτήτων**

Το Aspose.Slides for PHP via Java επιτρέπει επίσης στους προγραμματιστές να προσπελάσουν τις τιμές των προσαρμοσμένων ιδιοτήτων. Ένα παράδειγμα παρατίθεται παρακάτω που δείχνει πώς μπορείτε να προσπελάσετε και να τροποποιήσετε όλες αυτές τις προσαρμοσμένες ιδιότητες για μια παρουσίαση.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Δημιουργήστε μια αναφορά στο αντικείμενο DocumentProperties που σχετίζεται με την Presentation
    $dp = $pres->getDocumentProperties();
    # Πρόσβαση και τροποποίηση προσαρμοσμένων ιδιοτήτων
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # Εμφάνιση ονομάτων και τιμών των προσαρμοσμένων ιδιοτήτων
      echo("Custom Property Name : " . $dp->getCustomPropertyName($i));
      echo("Custom Property Value : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      # Τροποποίηση τιμών των προσαρμοσμένων ιδιοτήτων
      $dp->set_Item($dp->getCustomPropertyName($i), "New Value " . $i + 1);
    }
    # Αποθηκεύστε την παρουσίασή σας σε αρχείο
    $pres->save("CustomDemoModified.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Αυτό το παράδειγμα τροποποιεί τις προσαρμοσμένες ιδιότητες του [PPTX](https://docs.fileformat.com/presentation/pptx/)presentation. Οι παρακάτω εικόνες δείχνουν τις προσαρμοσμένες ιδιότητες της παρουσίασης πριν και μετά την τροποποίηση:

|**Προσαρμοσμένες Ιδιότητες πριν από την Τροποποίηση**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Προσαρμοσμένες Ιδιότητες μετά την Τροποποίηση**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Προηγμένες Ιδιότητες Εγγράφου**

{{% alert color="info" title="Note" %}}

Νέες μέθοδοι [readDocumentProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/PresentationInfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) και [writeBindedPresentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation) προστέθηκαν στο [PresentationInfo](https://reference.aspose.com/slides/el/php-java/aspose.slides/PresentationInfo). Η λογική του setter της ιδιότητας [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/el/php-java/aspose.slides/documentproperties/#setLastSavedTime) έχει αλλάξει.

{{% /alert %}} 

Οι δύο νέες μέθοδοι [readDocumentProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) και [updateDocumentProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) προστέθηκαν στην κλάση [PresentationInfo](https://reference.aspose.com/slides/el/php-java/aspose.slides/PresentationInfo). Παρέχουν γρήγορη πρόσβαση στις ιδιότητες εγγράφου και επιτρέπουν την αλλαγή και ενημέρωση των ιδιοτήτων χωρίς τη φόρτωση ολόκληρης της παρουσίασης.

Το τυπικό σενάριο φόρτωσης των ιδιοτήτων, αλλαγής κάποιας τιμής και ενημέρωσης του εγγράφου μπορεί να υλοποιηθεί ως εξής:

```php
  # διαβάστε τις πληροφορίες της παρουσίασης
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # αποκτήστε τις τρέχουσες ιδιότητες
  $props = $info->readDocumentProperties();
  # ορίστε τις νέες τιμές των πεδίων Συγγραφέας και Τίτλος
  $props->setAuthor("New Author");
  $props->setTitle("New Title");
  # ενημερώστε την παρουσίαση με νέες τιμές
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");
```

Υπάρχει ένας άλλος τρόπος χρήσης των ιδιοτήτων μιας συγκεκριμένης παρουσίασης ως πρότυπο για την ενημέρωση ιδιοτήτων σε άλλες παρουσιάσεις:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("template.pptx");
  $template = $info->readDocumentProperties();
  $template->setAuthor("Template Author");
  $template->setTitle("Template Title");
  $template->setCategory("Template Category");
  $template->setKeywords("Keyword1, Keyword2, Keyword3");
  $template->setCompany("Our Company");
  $template->setComments("Created from template");
  $template->setContentType("Template Content");
  $template->setSubject("Template Subject");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);
```

```php

```

Ένα νέο πρότυπο μπορεί να δημιουργηθεί από το μηδέν και στη συνέχεια να χρησιμοποιηθεί για την ενημέρωση πολλαπλών παρουσιάσεων:

```php
  $template = new DocumentProperties();
  $template->setAuthor("Template Author");
  $template->setTitle("Template Title");
  $template->setCategory("Template Category");
  $template->setKeywords("Keyword1, Keyword2, Keyword3");
  $template->setCompany("Our Company");
  $template->setComments("Created from template");
  $template->setContentType("Template Content");
  $template->setSubject("Template Subject");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);
```

## **Ορισμός Γλώσσας Ελέγχου Ορθογραφίας**

Το Aspose.Slides παρέχει την ιδιότητα LanguageId (εκτεθειμένη από την κλάση PortionFormat) για να ορίσετε τη γλώσσα ελέγχου ορθογραφίας σε ένα έγγραφο PowerPoint. Η γλώσσα ελέγχου ορθογραφίας είναι η γλώσσα για την οποία γίνεται έλεγχος ορθογραφίας και γραμματικής στο PowerPoint.

Αυτός ο κώδικας PHP δείχνει πώς να ορίσετε τη γλώσσα ελέγχου ορθογραφίας για ένα PowerPoint: xxx Why is LanguageId missing from Java PortionFormat class?

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();
    $newPortion = new Portion();
    $font = new FontData("SimSun");
    $portionFormat = $newPortion->getPortionFormat();
    $portionFormat->setComplexScriptFont($font);
    $portionFormat->setEastAsianFont($font);
    $portionFormat->setLatinFont($font);
    $portionFormat->setLanguageId("zh-CN");// ορίστε το Id μιας γλώσσας ελέγχου

    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ορισμός Προεπιλεγμένης Γλώσσας**

Αυτός ο κώδικας PHP δείχνει πώς να ορίσετε τη προεπιλεγμένη γλώσσα για ολόκληρη την παρουσίαση PowerPoint:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    # Προσθέτει ένα νέο σχήμα ορθογωνίου με κείμενο
    $shp = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    $shp->getTextFrame()->setText("New Text");
    # Ελέγχει τη γλώσσα του πρώτου τμήματος
    echo($shp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getLanguageId());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ζωντανό Παράδειγμα**

Δοκιμάστε την online εφαρμογή [**Aspose.Slides Metadata**](https://products.aspose.app/slides/el/metadata) για να δείτε πώς να εργαστείτε με τις ιδιότητες εγγράφου μέσω του Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/el/metadata)

## **FAQ**

**Πώς μπορώ να αφαιρέσω μια ενσωματωμένη ιδιότητα από μια παρουσίαση;**

Οι ενσωματωμένες ιδιότητες αποτελούν αναπόσπαστο μέρος της παρουσίασης και δεν μπορούν να αφαιρεθούν εντελώς. Ωστόσο, μπορείτε είτε να αλλάξετε τις τιμές τους είτε να τις θέσετε κενές, εφόσον το επιτρέπει η συγκεκριμένη ιδιότητα.

**Τι συμβαίνει αν προσθέσω μια προσαρμοσμένη ιδιότητα που υπάρχει ήδη;**

Αν προσθέσετε μια προσαρμοσμένη ιδιότητα που υπάρχει ήδη, η υπάρχουσα τιμή της θα αντικατασταθεί με τη νέα. Δεν χρειάζεται να αφαιρέσετε ή να ελέγξετε την ιδιότητα εκ των προτέρων, καθώς το Aspose.Slides ενημερώνει αυτόματα την τιμή της ιδιότητας.

**Μπορώ να προσπελάσω τις ιδιότητες παρουσίασης χωρίς να φορτώσω πλήρως την παρουσίαση;**

Ναι. Χρησιμοποιήστε το [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationfactory/) και έπειτα το [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationinfo/#readDocumentProperties) για να διαβάσετε τα αποθηκευμένα μεταδεδομένα εγγράφου χωρίς να δημιουργήσετε ένα στιγμιότυπο [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) . Δείτε το [Build a Lightweight Presentation Inventory](/slides/el/php-java/examine-presentation/) για ένα πλήρες παράδειγμα αναφοράς και περιορισμών ανά μορφή.

**Μπορώ να διαβάσω δημόσιες ιδιότητες κρυπτογραφημένης παρουσίασης χωρίς τον κωδικό ανοίγματος;**

Ναι. Η κρυπτογράφηση ιδιοτήτων εγγράφου πρέπει να είχε απενεργοποιηθεί πριν κρυπτογραφηθεί η παρουσίαση και η παρουσίαση πρέπει να φορτωθεί σε λειτουργία «μόνο ιδιότητες εγγράφου».

**Μπορώ να ενημερώσω ένα κρυπτογραφημένο αρχείο PPTX σε λειτουργία «μόνο ιδιότητες εγγράφου»;**

Όχι. Τα δημόσια και κρυπτογραφημένα δεδομένα ιδιοτήτων πρέπει να παραμένουν συνεπή, έτσι η ενημέρωση ενός κρυπτογραφημένου αρχείου PPTX απαιτεί τη φόρτωση ολόκληρης της παρουσίασης με τον σωστό κωδικό ανοίγματος.