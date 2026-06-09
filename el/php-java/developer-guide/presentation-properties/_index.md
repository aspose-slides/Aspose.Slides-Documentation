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
- Παρουσίαση
- PHP
- Aspose.Slides
description: "Διαχειριστείτε τις ιδιότητες παρουσίασης στο Aspose.Slides for PHP via Java και βελτιώστε την αναζήτηση, το branding και τη ροή εργασίας στα αρχεία PowerPoint και OpenDocument."
---
## **Εισαγωγή**

Το Aspose.Slides υποστηρίζει δύο τύπους ιδιοτήτων εγγράφου: **Built-in** και **Custom**. Και οι δύο τύποι ιδιοτήτων μπορούν εύκολα να προσπελαστούν και να διαχειριστούν χρησιμοποιώντας το API του Aspose.Slides.

Το Aspose.Slides σάς επιτρέπει να εργάζεστε με ιδιότητες εγγράφου παρουσίασης μέσω της κλάσης [DocumentProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/documentproperties/) . Μια παρουσίαση αυτής της κλάσης επιστρέφεται από τη μέθοδο [Presentation::getDocumentProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#getDocumentProperties) . Τα παρακάτω παραδείγματα δείχνουν πώς να διαβάσετε, να τροποποιήσετε και να διαχειριστείτε αυτές τις ιδιότητες.

{{% alert color="primary" %}} 

Παρακαλώ σημειώστε ότι τα πεδία **Application** και **Producer** δεν μπορούν να τροποποιηθούν, καθώς αυτά πάντα θα εμφανίζουν «Aspose Ltd.» και «Aspose.Slides for PHP via Java x.x.x».

{{% /alert %}} 

## **Διαχείριση Ιδιοτήτων Παρουσίασης**

Το Microsoft PowerPoint παρέχει μια λειτουργία για να προσθέσετε ορισμένες ιδιότητες στα αρχεία παρουσίασης. Αυτές οι ιδιότητες εγγράφου επιτρέπουν την αποθήκευση χρήσιμων πληροφοριών μαζί με τα έγγραφα (αρχεία παρουσίασης). Υπάρχουν δύο είδη ιδιοτήτων εγγράφου ως εξής

- System Defined (Built-in) Properties
- User-Defined (Custom) Properties

Οι **Built-in** ιδιότητες περιέχουν γενικές πληροφορίες για το έγγραφο όπως ο τίτλος του εγγράφου, το όνομα του δημιουργού, στατιστικά του εγγράφου κλπ. Οι **Custom** ιδιότητες είναι αυτές που ορίζονται από τους χρήστες ως ζεύγη **Name/Value**, όπου τόσο το όνομα όσο και η τιμή ορίζονται από τον χρήστη. Χρησιμοποιώντας το Aspose.Slides for PHP via Java, οι προγραμματιστές μπορούν να έχουν πρόσβαση και να τροποποιήσουν τις τιμές των built-in ιδιοτήτων καθώς και των custom ιδιοτήτων.

## **Ιδιότητες Εγγράφου στο PowerPoint**

Το Microsoft PowerPoint 2007 επιτρέπει τη διαχείριση των ιδιοτήτων εγγράφου των αρχείων παρουσίασης. Το μόνο που χρειάζεται να κάνετε είναι να κάνετε κλικ στο εικονίδιο Office και στη συνέχεια στο στοιχείο μενού **Prepare | Properties | Advanced Properties** του Microsoft PowerPoint 2007 όπως φαίνεται παρακάτω:

|**Επιλογή στοιχείου μενού Advanced Properties**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Αφού επιλέξετε το στοιχείο μενού **Advanced Properties**, θα εμφανιστεί ένας διάλογος που σας επιτρέπει να διαχειριστείτε τις ιδιότητες εγγράφου του αρχείου PowerPoint όπως φαίνεται παρακάτω στη εικόνα:

|**Διάλογος Ιδιοτήτων**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
Στον παραπάνω **Διάλογος Ιδιοτήτων**, μπορείτε να δείτε ότι υπάρχουν πολλές καρτέλες όπως **General**, **Summary**, **Statistics**, **Contents** και **Custom**. Όλες αυτές οι καρτέλες επιτρέπουν τη διαμόρφωση διαφορετικών τύπων πληροφοριών σχετικών με τα αρχεία PowerPoint. Η καρτέλα **Custom** χρησιμοποιείται για τη διαχείριση των προσαρμοσμένων ιδιοτήτων των αρχείων PowerPoint.

Εργασία με Ιδιότητες Εγγράφου χρησιμοποιώντας Aspose.Slides for PHP via Java

Όπως περιγράψαμε νωρίτερα, το Aspose.Slides for PHP via Java υποστηρίζει δύο είδη ιδιοτήτων εγγράφου, οι **Built-in** και **Custom**. Έτσι, οι προγραμματιστές μπορούν να έχουν πρόσβαση και στα δύο είδη ιδιοτήτων μέσω του API του Aspose.Slides for PHP via Java. Το Aspose.Slides for PHP via Java παρέχει μια κλάση [DocumentProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/documentproperties) που αντιπροσωπεύει τις ιδιότητες εγγράφου που σχετίζονται με ένα αρχείο παρουσίασης μέσω της ιδιότητας **Presentation.DocumentProperties**.

Οι προγραμματιστές μπορούν να χρησιμοποιήσουν την ιδιότητα **DocumentProperties** που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation) για να έχουν πρόσβαση στις ιδιότητες εγγράφου των αρχείων παρουσίασης όπως περιγράφεται παρακάτω:

## **Πρόσβαση σε Built-in Ιδιότητες**

Αυτές οι ιδιότητες όπως εκτίθενται από το αντικείμενο [DocumentProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/documentproperties) περιλαμβάνουν: **Creator** (Author), **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject** και **Title**.

```php
  # Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει την παρουσίαση
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

## **Τροποποίηση Built-in Ιδιοτήτων**

Η τροποποίηση των built-in ιδιοτήτων των αρχείων παρουσίασης είναι εξίσου εύκολη με την πρόσβασή τους. Απλώς αντιστοιχίστε μια συμβολοσειρά στην επιθυμητή ιδιότητα και η τιμή της ιδιότητας θα τροποποιηθεί. Στο παρακάτω παράδειγμα, δείχνουμε πώς μπορούμε να τροποποιήσουμε τις built-in ιδιότητες εγγράφου του αρχείου παρουσίασης χρησιμοποιώντας το Aspose.Slides for PHP via Java.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Δημιουργία αναφοράς στο αντικείμενο IDocumentProperties που σχετίζεται με την Παρουσίαση
    $dp = $pres->getDocumentProperties();
    # Ορισμός ενσωματωμένων ιδιοτήτων
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

Αυτό το παράδειγμα τροποποιεί τις built-in ιδιότητες της παρουσίασης όπως φαίνεται παρακάτω:

|**Built-in document properties after modification**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Προσθήκη Προσαρμοσμένων Ιδιοτήτων Εγγράφου**

Το Aspose.Slides for PHP via Java επίσης επιτρέπει στους προγραμματιστές να προσθέσουν προσαρμοσμένες τιμές για τις ιδιότητες εγγράφου της παρουσίασης. Ένα παράδειγμα δίνεται παρακάτω που δείχνει πώς να ορίσετε τις προσαρμοσμένες ιδιότητες για μια παρουσίαση.

```php
  $pres = new Presentation();
  try {
    # Λήψη Ιδιοτήτων Εγγράφου
    $dProps = $pres->getDocumentProperties();
    # Προσθήκη Προσαρμοσμένων ιδιοτήτων
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

Το Aspose.Slides for PHP via Java επίσης επιτρέπει στους προγραμματιστές να έχουν πρόσβαση στις τιμές των προσαρμοσμένων ιδιοτήτων. Ένα παράδειγμα δίνεται παρακάτω που δείχνει πώς μπορείτε να έχετε πρόσβαση και να τροποποιήσετε όλες αυτές τις προσαρμοσμένες ιδιότητες για μια παρουσίαση.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Δημιουργία αναφοράς στο αντικείμενο DocumentProperties που σχετίζεται με την Παρουσίαση
    $dp = $pres->getDocumentProperties();
    # Πρόσβαση και τροποποίηση προσαρμοσμένων ιδιοτήτων
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # Εμφάνιση ονομάτων και τιμών προσαρμοσμένων ιδιοτήτων
      echo("Custom Property Name : " . $dp->getCustomPropertyName($i));
      echo("Custom Property Value : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      # Τροποποίηση τιμών προσαρμοσμένων ιδιοτήτων
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

Αυτό το παράδειγμα τροποποιεί τις προσαρμοσμένες ιδιότητες του [PPTX ](https://docs.fileformat.com/presentation/pptx/)presentation. Οι παρακάτω εικόνες δείχνουν τις προσαρμοσμένες ιδιότητες της παρουσίασης πριν και μετά την τροποποίηση:

|**Προσαρμοσμένες Ιδιότητες πριν από Τροποποίηση**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Προσαρμοσμένες Ιδιότητες μετά από Τροποποίηση**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Προηγμένες Ιδιότητες Εγγράφου**

{{% alert color="primary" %}} 

Νέες μέθοδοι [readDocumentProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/PresentationInfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) και [writeBindedPresentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation) προστέθηκαν στην κλάση [PresentationInfo](https://reference.aspose.com/slides/el/php-java/aspose.slides/PresentationInfo). Η λογική του setter της ιδιότητας [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/el/php-java/aspose.slides/documentproperties/#setLastSavedTime) έχει αλλάξει.

{{% /alert %}} 

Οι δύο νέες μέθοδοι [readDocumentProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) και [updateDocumentProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) προστέθηκαν στην κλάση [PresentationInfo](https://reference.aspose.com/slides/el/php-java/aspose.slides/PresentationInfo). Παρέχουν γρήγορη πρόσβαση στις ιδιότητες εγγράφου και επιτρέπουν την αλλαγή και ενημέρωση των ιδιοτήτων χωρίς τη φόρτωση ολόκληρης της παρουσίασης.

Το τυπικό σενάριο φόρτωσης των ιδιοτήτων, αλλαγής κάποιας τιμής και ενημέρωσης του εγγράφου μπορεί να υλοποιηθεί ως εξής:

```php
  # ανάγνωση πληροφοριών της παρουσίασης
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # λήψη τρεχουσών ιδιοτήτων
  $props = $info->readDocumentProperties();
  # ορισμός νέων τιμών για τα πεδία Συγγραφέας και Τίτλος
  $props->setAuthor("New Author");
  $props->setTitle("New Title");
  # ενημέρωση της παρουσίασης με νέες τιμές
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");
```

Υπάρχει ένας άλλος τρόπος να χρησιμοποιήσετε τις ιδιότητες μιας συγκεκριμένης παρουσίασης ως πρότυπο για την ενημέρωση ιδιοτήτων σε άλλες παρουσιάσεις:

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

Ένα νέο πρότυπο μπορεί να δημιουργηθεί από το μηδέν και έπειτα να χρησιμοποιηθεί για την ενημέρωση πολλαπλών παρουσιάσεων:

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

Το Aspose.Slides παρέχει την ιδιότητα LanguageId (εκτίθεται από την κλάση PortionFormat) για να σας επιτρέψει να ορίσετε τη γλώσσα ελέγχου ορθογραφίας για ένα έγγραφο PowerPoint. Η γλώσσα ελέγχου ορθογραφίας είναι η γλώσσα για την οποία ελέγχονται η ορθογραφία και η γραμματική στο PowerPoint.

Αυτός ο κώδικας PHP δείχνει πώς να ορίσετε τη γλώσσα ελέγχου ορθογραφίας για ένα PowerPoint: xxx Why is LanguageId missing from Java PortionFormat class?

```php
  $pres = new Presentation($pptxFileName);
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();
    $newPortion = new Portion();
    $font = new FontData("SimSun");
    $portionFormat = $newPortion->getPortionFormat();
    $portionFormat::setComplexScriptFont($font);
    $portionFormat::setEastAsianFont($font);
    $portionFormat::setLatinFont($font);
    $portionFormat::setLanguageId("zh-CN");// ορίστε το Id μιας γλώσσας ελέγχου ορθογραφίας

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

Δοκιμάστε την online εφαρμογή [**Aspose.Slides Metadata**](https://products.aspose.app/slides/el/metadata) για να δείτε πώς να εργαστείτε με ιδιότητες εγγράφου μέσω του Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/el/metadata)

## **FAQ**

**Πώς μπορώ να αφαιρέσω μια built-in ιδιότητα από μια παρουσίαση;**

Οι built-in ιδιότητες αποτελούν αναπόσπαστο μέρος της παρουσίασης και δεν μπορούν να αφαιρεθούν εντελώς. Ωστόσο, μπορείτε είτε να αλλάξετε τις τιμές τους είτε να τις θέσετε σε κενό, εφόσον το επιτρέπει η συγκεκριμένη ιδιότητα.

**Τι συμβαίνει αν προσθέσω μια προσαρμοσμένη ιδιότητα που ήδη υπάρχει;**

Αν προσθέσετε μια προσαρμοσμένη ιδιότητα που υπάρχει ήδη, η υπάρχουσα τιμή της θα αντικατασταθεί με τη νέα. Δεν χρειάζεται να αφαιρέσετε ή να ελέγξετε την ιδιότητα εκ των προτέρων, καθώς το Aspose.Slides ενημερώνει αυτόματα την τιμή της ιδιότητας.

**Μπορώ να έχω πρόσβαση στις ιδιότητες της παρουσίασης χωρίς να φορτώσω πλήρως την παρουσίαση;**

Ναι, μπορείτε να έχετε πρόσβαση στις ιδιότητες της παρουσίασης χωρίς να φορτώσετε πλήρως την παρουσίαση χρησιμοποιώντας τη μέθοδο `getPresentationInfo` από την κλάση [PresentationFactory](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationfactory/) . Στη συνέχεια, αξιοποιήστε τη μέθοδο `readDocumentProperties` που παρέχεται από την κλάση [PresentationInfo](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationinfo/) για να διαβάσετε τις ιδιότητες αποδοτικά, εξοικονομώντας μνήμη και βελτιώνοντας την απόδοση.