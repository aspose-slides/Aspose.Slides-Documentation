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
- Γλώσσα επιθεώρησης
- Προεπιλεγμένη γλώσσα
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Κατακτήστε τις ιδιότητες παρουσίασης στο Aspose.Slides for PHP via Java και βελτιστοποιήστε την αναζήτηση, τη διαφήμιση και τη ροή εργασίας στα αρχεία PowerPoint και OpenDocument σας."
---
## **Εισαγωγή**

Το Aspose.Slides υποστηρίζει δύο τύπους ιδιοτήτων εγγράφου: **Built-in** και **Custom**. Και οι δύο τύποι ιδιοτήτων μπορούν εύκολα να προσπελαστούν και να διαχειριστούν χρησιμοποιώντας το API του Aspose.Slides.

Το Aspose.Slides σας επιτρέπει να εργάζεστε με τις ιδιότητες εγγράφου παρουσίασης μέσω της κλάσης [DocumentProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/documentproperties/) . Μια παρουσία της κλάσης επιστρέφεται από τη μέθοδο [Presentation::getDocumentProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#getDocumentProperties) . Τα επόμενα παραδείγματα δείχνουν πώς να διαβάσετε, να τροποποιήσετε και να διαχειριστείτε αυτές τις ιδιότητες.

{{% alert color="info" title="Σημείωση" %}}

Παρακαλώ σημειώστε ότι τα πεδία **Application** και **AppVersion** δεν μπορούν να τροποποιηθούν. Το Aspose.Slides τα επανγράφει σε κάθε αποθήκευση, έτσι μια αποθηκευμένη παρουσίαση πάντα αναφέρει «Aspose.Slides for PHP via Java» και την έκδοση της βιβλιοθήκης που την παρήγαγε. Οποιαδήποτε τιμή περαστεί στη μέθοδο `setNameOfApplication` απορρίπτεται όταν η παρουσίαση γράφεται.

{{% /alert %}} 

## **Διαχείριση Ιδιοτήτων Παρουσίασης**

Το Microsoft PowerPoint παρέχει δυνατότητα προσθήκης ιδιοτήτων στα αρχεία παρουσίασης. Αυτές οι ιδιότητες εγγράφου επιτρέπουν την αποθήκευση χρήσιμων πληροφοριών μαζί με τα έγγραφα (αρχεία παρουσίασης). Υπάρχουν δύο είδη ιδιοτήτων εγγράφου ως εξής

- Ιδιότητες ορισμένες από το σύστημα (Built-in)
- Ιδιότητες ορισμένες από τον χρήστη (Custom)

Οι **Built-in** ιδιότητες περιλαμβάνουν γενικές πληροφορίες για το έγγραφο όπως τίτλος, όνομα συγγραφέα, στατιστικά κλπ. Οι **Custom** ιδιότητες είναι ζεύγη **Όνομα/Τιμή** που ορίζονται από τον χρήστη. Χρησιμοποιώντας το Aspose.Slides for PHP via Java, οι προγραμματιστές μπορούν να προσπελάσουν και να τροποποιήσουν τόσο τις ενσωματωμένες όσο και τις προσαρμοσμένες ιδιότητες.

## **Ιδιότητες Εγγράφου στο PowerPoint**

Το Microsoft PowerPoint 2007 επιτρέπει τη διαχείριση των ιδιοτήτων εγγράφου των αρχείων παρουσίασης. Το μόνο που χρειάζεται είναι να κάνετε κλικ στο εικονίδιο Office και στη συνέχεια στο στοιχείο μενού **Prepare | Properties | Advanced Properties** του Microsoft PowerPoint 2007 όπως φαίνεται παρακάτω:

|**Επιλογή στοιχείου μενού Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Αφού επιλέξετε το στοιχείο μενού **Advanced Properties**, εμφανίζεται ένας διάλογος που σας επιτρέπει να διαχειριστείτε τις ιδιότητες εγγράφου του αρχείου PowerPoint όπως φαίνεται παρακάτω:

|**Διάλογος Ιδιοτήτων**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
Στον παραπάνω **Διάλογο Ιδιοτήτων**, μπορείτε να δείτε πολλές καρτέλες όπως **General**, **Summary**, **Statistics**, **Contents** και **Custom**. Όλες αυτές οι καρτέλες επιτρέπουν τη διαμόρφωση διαφορετικών τύπων πληροφοριών σχετικά με τα αρχεία PowerPoint. Η καρτέλα **Custom** χρησιμοποιείται για τη διαχείριση των προσαρμοσμένων ιδιοτήτων των αρχείων PowerPoint.

### Εργασία με Ιδιότητες Εγγράφου χρησιμοποιώντας Aspose.Slides for PHP via Java

Όπως περιγράφηκε νωρίτερα, το Aspose.Slides for PHP via Java υποστηρίζει δύο είδη ιδιοτήτων εγγράφου, οι **Built-in** και **Custom**. Έτσι, οι προγραμματιστές μπορούν να προσπελάσουν και τους δύο τύπους ιδιοτήτων μέσω του API του Aspose.Slides for PHP via Java. Το Aspose.Slides for PHP via Java παρέχει την κλάση [DocumentProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/documentproperties) που αντιπροσωπεύει τις ιδιότητες εγγράφου που σχετίζονται με ένα αρχείο παρουσίασης μέσω της ιδιότητας **Presentation.DocumentProperties**.

Οι προγραμματιστές μπορούν να χρησιμοποιήσουν την ιδιότητα **DocumentProperties** που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation) για να έχουν πρόσβαση στις ιδιότητες εγγράφου των αρχείων παρουσίασης όπως περιγράφεται παρακάτω:

## **Πρόσβαση στις ενσωματωμένες (Built-in) Ιδιότητες**

Αυτές οι ιδιότητες που εκτίθενται από το αντικείμενο [DocumentProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/documentproperties) περιλαμβάνουν: **Creator** (Author), **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **Keywords**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject** και **Title**

```php
  # Δημιουργία αντικειμένου της κλάσης Presentation που αντιπροσωπεύει την παρουσίαση
  $pres = new Presentation("Presentation.pptx");
  try {
    # Δημιουργία αναφοράς στο αντικείμενο IDocumentProperties που σχετίζεται με την παρουσίαση
    $dp = $pres->getDocumentProperties();
    # Εμφάνιση των ενσωματωμένων ιδιοτήτων
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

## **Τροποποίηση ενσωματωμένων ιδιοτήτων**

Η τροποποίηση των ενσωματωμένων ιδιοτήτων των αρχείων παρουσίασης είναι εξίσου απλή με την πρόσβασή τους. Απλώς εκχωρείτε μια συμβολοσειρά σε οποιαδήποτε επιθυμητή ιδιότητα και η τιμή της ιδιότητας θα τροποποιηθεί. Στο παρακάτω παράδειγμα, δείχνουμε πώς μπορούμε να τροποποιήσουμε τις ενσωματωμένες ιδιότητες εγγράφου του αρχείου παρουσίασης χρησιμοποιώντας το Aspose.Slides for PHP via Java.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Δημιουργία αναφοράς στο αντικείμενο IDocumentProperties που σχετίζεται με την Παρουσίαση
    $dp = $pres->getDocumentProperties();
    # Ορισμός των ενσωματωμένων ιδιοτήτων
    $dp->setAuthor("Aspose.Slides for PHP via Java");
    $dp->setTitle("Modifying Presentation Properties");
    $dp->setSubject("Aspose Subject");
    $dp->setComments("Aspose Description");
    $dp->setManager("Aspose Manager");
    # Αποθήκευση της παρουσίασής σας σε αρχείο
    $pres->save("DocProps.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Το παράδειγμα αυτό τροποποιεί τις ενσωματωμένες ιδιότητες της παρουσίασης όπως φαίνεται παρακάτω:

|**Ενσωματωμένες ιδιότητες εγγράφου μετά τη τροποποίηση**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Προσθήκη προσαρμοσμένων ιδιοτήτων εγγράφου**

Το Aspose.Slides for PHP via Java επιτρέπει επίσης στους προγραμματιστές να προσθέτουν προσαρμοσμένες τιμές για τις ιδιότητες εγγράφου παρουσίασης. Ένα παράδειγμα παρατίθεται παρακάτω που δείχνει πώς να ορίσετε τις προσαρμοσμένες ιδιότητες για μια παρουσίαση.

```php
  $pres = new Presentation();
  try {
    # Ανάκτηση ιδιοτήτων εγγράφου
    $dProps = $pres->getDocumentProperties();
    # Προσθήκη προσαρμοσμένων ιδιοτήτων
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    # Ανάκτηση ονόματος ιδιότητας σε συγκεκριμένο δείκτη
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

|**Προσαρμοσμένες Ιδιότητες Εγγράφου Προστέθηκαν**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Πρόσβαση και τροποποίηση προσαρμοσμένων ιδιοτήτων**

Το Aspose.Slides for PHP via Java επιτρέπει επίσης στους προγραμματιστές να προσπελάσουν τις τιμές των προσαρμοσμένων ιδιοτήτων. Ένα παράδειγμα παρατίθεται παρακάτω που δείχνει πώς μπορείτε να προσπελάσετε και να τροποποιήσετε όλες αυτές τις προσαρμοσμένες ιδιότητες για μια παρουσίαση.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Δημιουργία αναφοράς στο αντικείμενο DocumentProperties που σχετίζεται με την Παρουσίαση
    $dp = $pres->getDocumentProperties();
    # Πρόσβαση και τροποποίηση προσαρμοσμένων ιδιοτήτων
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # Εμφάνιση ονομάτων και τιμών των προσαρμοσμένων ιδιοτήτων
      echo("Custom Property Name : " . $dp->getCustomPropertyName($i));
      echo("Custom Property Value : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      # Τροποποίηση τιμών των προσαρμοσμένων ιδιοτήτων
      $dp->set_Item($dp->getCustomPropertyName($i), "New Value " . $i + 1);
    }
    # Αποθήκευση της παρουσίασής σας σε αρχείο
    $pres->save("CustomDemoModified.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Αυτό το παράδειγμα τροποποιεί τις προσαρμοσμένες ιδιότητες του [PPTX](https://docs.fileformat.com/presentation/pptx/)presentation. Τα παρακάτω σχήματα δείχνουν τις προσαρμοσμένες ιδιότητες της παρουσίασης πριν και μετά τη τροποποίηση:

|**Προσαρμοσμένες Ιδιότητες πριν από τη Τροποποίηση**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Προσαρμοσμένες Ιδιότητες μετά τη Τροποποίηση**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Προχωρημένες ιδιότητες εγγράφου**

{{% alert color="info" title="Σημείωση" %}}

Νέες μέθοδοι [readDocumentProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/PresentationInfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) και [writeBindedPresentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation) προστέθηκαν στην κλάση [PresentationInfo](https://reference.aspose.com/slides/el/php-java/aspose.slides/PresentationInfo), η λογική του setter της ιδιότητας [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/el/php-java/aspose.slides/documentproperties/#setLastSavedTime) έχει αλλάξει.

{{% /alert %}} 

Οι δύο νέες μέθοδοι [readDocumentProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) και [updateDocumentProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) προστέθηκαν στην κλάση [PresentationInfo](https://reference.aspose.com/slides/el/php-java/aspose.slides/PresentationInfo). Παρέχουν γρήγορη πρόσβαση στις ιδιότητες εγγράφου και επιτρέπουν την αλλαγή και ενημέρωση των ιδιοτήτων χωρίς τη φόρτωση ολόκληρης της παρουσίασης.

Το τυπικό σενάριο φορτώνει τις ιδιότητες, αλλάζει κάποια τιμή και ενημερώνει το έγγραφο με τον ακόλουθο τρόπο:

```php
  # διάβασε τις πληροφορίες της παρουσίασης
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # απόκτησε τις τρέχουσες ιδιότητες
  $props = $info->readDocumentProperties();
  # ορίσε τις νέες τιμές των πεδίων Συγγραφέας και Τίτλος
  $props->setAuthor("New Author");
  $props->setTitle("New Title");
  # ενημέρωσε την παρουσίαση με νέες τιμές
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");
```

Υπάρχει ένας άλλος τρόπος να χρησιμοποιήσετε τις ιδιότητες μιας συγκεκριμένης παρουσίασης ως πρότυπο για ενημέρωση ιδιοτήτων σε άλλες παρουσιάσεις:

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

Μπορεί να δημιουργηθεί ένα νέο πρότυπο από την αρχή και στη συνέχεια να χρησιμοποιηθεί για ενημέρωση πολλαπλών παρουσιάσεων:

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

## **Ορισμός γλώσσας επιθεώρησης**

Το Aspose.Slides παρέχει την ιδιότητα LanguageId (εκτεθειμένη από την κλάση PortionFormat) για να ορίσετε τη γλώσσα επιθεώρησης ενός εγγράφου PowerPoint. Η γλώσσα επιθεώρησης είναι η γλώσσα για την οποία ελέγχονται η ορθογραφία και η γραμματική στο PowerPoint.

Αυτός ο κώδικας PHP δείχνει πώς να ορίσετε τη γλώσσα επιθεώρησης για ένα PowerPoint: xxx Why is LanguageId missing from Java PortionFormat class?

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
    $portionFormat->setLanguageId("zh-CN");// ορίστε το Id μιας γλώσσας επιθεώρησης

    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ορισμός προεπιλεγμένης γλώσσας**

Αυτός ο κώδικας PHP δείχνει πώς να ορίσετε τη προεπιλεγμένη γλώσσα για ολόκληρη την παρουσίαση PowerPoint:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    # Προσθέτει νέο σχήμα ορθογωνίου με κείμενο
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

Δοκιμάστε την online εφαρμογή [**Aspose.Slides Metadata**](https://products.aspose.app/slides/el/metadata) για να δείτε πώς να εργάζεστε με τις ιδιότητες εγγράφου μέσω του Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/el/metadata)

## **Συχνές ερωτήσεις**

**Πώς μπορώ να αφαιρέσω μια ενσωματωμένη ιδιότητα από μια παρουσίαση;**

Οι ενσωματωμένες ιδιότητες αποτελούν αναπόσπαστο μέρος της παρουσίασης και δεν μπορούν να αφαιρεθούν πλήρως. Ωστόσο, μπορείτε είτε να αλλάξετε τις τιμές τους είτε να τις ορίσετε σε κενό, εφόσον η συγκεκριμένη ιδιότητα το επιτρέπει.

**Τι συμβαίνει αν προσθέσω μια προσαρμοσμένη ιδιότητα που υπάρχει ήδη;**

Αν προσθέσετε μια προσαρμοσμένη ιδιότητα που υπάρχει ήδη, η υπάρχουσα τιμή της θα αντικατασταθεί με τη νέα. Δεν χρειάζεται να αφαιρέσετε ή να ελέγξετε την ιδιότητα εκ των προτέρων, καθώς το Aspose.Slides ενημερώνει αυτόματα την τιμή της ιδιότητας.

**Μπορώ να προσπελάσω τις ιδιότητες παρουσίασης χωρίς να φορτώσω ολόκληρη την παρουσίαση;**

Ναι. Χρησιμοποιήστε [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationfactory/) και στη συνέχεια [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationinfo/#readDocumentProperties) για να διαβάσετε τα αποθηκευμένα μεταδεδομένα εγγράφου χωρίς να δημιουργήσετε ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) . Δείτε το παράδειγμα **Build a Lightweight Presentation Inventory** (/slides/el/php-java/examine-presentation/) για πλήρη αναφορά και περιορισμούς ανά μορφή.