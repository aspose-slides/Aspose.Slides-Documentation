---
title: Διαχείριση έργων VBA σε παρουσιάσεις με χρήση PHP
linktitle: Παρουσίαση μέσω VBA
type: docs
weight: 250
url: /el/php-java/presentation-via-vba/
keywords:
- μακροεντολή
- VBA
- μακροεντολή VBA
- προσθήκη μακροεντολής
- αφαίρεση μακροεντολής
- εξαγωγή μακροεντολής
- πρόσθεση VBA
- αφαίρεση VBA
- εξαγωγή VBA
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Ανακαλύψτε πώς να δημιουργείτε και να διαχειρίζεστε παρουσιάσεις PowerPoint και OpenDocument μέσω VBA με το Aspose.Slides για PHP μέσω Java για να βελτιώσετε τη ροή εργασίας σας."
---
## **Εισαγωγή**

Το API Aspose.Slides περιέχει κλάσεις για εργασία με μακροεντολές και κώδικα VBA.

{{% alert title="Σημείωση" color="warning" %}} 

Όταν μετατρέπετε μια παρουσίαση που περιέχει μακροεντολές σε διαφορετική μορφή αρχείου (PDF, HTML κ.λπ.), το Aspose.Slides αγνοεί όλες τις μακροεντολές (οι μακροεντολές δεν μεταφέρονται στο τελικό αρχείο).

Όταν προσθέτετε μακροεντολές σε μια παρουσίαση ή αποθηκεύετε ξανά μια παρουσίαση που περιέχει μακροεντολές, το Aspose.Slides απλώς γράφει τα bytes των μακροεντολών.

Το Aspose.Slides **ποτέ** δεν εκτελεί τις μακροεντολές σε μια παρουσίαση.

{{% /alert %}}

## **Προσθήκη Μακροεντολών VBA**

Το Aspose.Slides παρέχει την κλάση [VbaProject](https://reference.aspose.com/slides/el/php-java/aspose.slides/vbaproject/) ώστε να μπορείτε να δημιουργείτε έργα VBA (και αναφορές έργου) και να επεξεργάζεστε υπάρχουσες ενότητες. Μπορείτε να χρησιμοποιήσετε την κλάση `VbaProject` για να διαχειρίζεστε τον ενσωματωμένο VBA κώδικα σε μια παρουσίαση.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation).
1. Χρησιμοποιήστε τον κατασκευαστή [VbaProject](https://reference.aspose.com/slides/el/php-java/aspose.slides/vbaproject/#VbaProject) για να προσθέσετε ένα νέο έργο VBA.
1. Προσθέστε μια ενότητα στο VbaProject.
1. Ορίστε τον πηγαίο κώδικα της ενότητας.
1. Προσθέστε αναφορές στο <stdole>.
1. Προσθέστε αναφορές στο **Microsoft Office**.
1. Συσχετίστε τις αναφορές με το έργο VBA.
1. Αποθηκεύστε την παρουσίαση.

Αυτός ο κώδικας PHP δείχνει πώς να προσθέσετε μια μακροεντολή VBA από το μηδέν σε μια παρουσίαση:

```php
  # Δημιουργεί ένα στιγμιότυπο της κλάσης παρουσίασης
  $pres = new Presentation();
  try {
    # Δημιουργεί ένα νέο έργο VBA
    $pres->setVbaProject(new VbaProject());
    # Προσθέτει μια κενή μονάδα στο έργο VBA
    $module = $pres->getVbaProject()->getModules()->addEmptyModule("Module");
    # Ορίζει τον πηγαίο κώδικα της μονάδας
    $module->setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    # Δημιουργεί μια αναφορά στο <stdole>
    $stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    # Δημιουργεί μια αναφορά στο Office
    $officeReference = new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    # Προσθέτει αναφορές στο έργο VBA
    $pres->getVbaProject()->getReferences()->add($stdoleReference);
    $pres->getVbaProject()->getReferences()->add($officeReference);
    # Αποθηκεύει την παρουσίαση
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 

Μπορεί να θέλετε να δοκιμάσετε το **Aspose** [Macro Remover](https://products.aspose.app/slides/el/remove-macros), μια δωρεάν διαδικτυακή εφαρμογή για την αφαίρεση μακροεντολών από αρχεία PowerPoint, Excel και Word. 

{{% /alert %}} 

## **Αφαίρεση Μακροεντολών VBA**

Χρησιμοποιώντας την ιδιότητα [VbaProject](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#getVbaProject) στην κλάση [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation) μπορείτε να αφαιρέσετε μια μακροεντολή VBA.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation) και φορτώστε την παρουσίαση που περιέχει τη μακροεντολή.
1. Προσεγγίστε τη μονάδα Macro και αφαιρέστε την.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας PHP δείχνει πώς να αφαιρέσετε μια μακροεντολή VBA:

```php
  # Φορτώνει την παρουσίαση που περιέχει τη μακροεντολή
  $pres = new Presentation("VBA.pptm");
  try {
    # Προσπελάζει τη μονάδα Vba και την αφαιρεί
    $pres->getVbaProject()->getModules()->remove($pres->getVbaProject()->getModules()->get_Item(0));
    # Αποθηκεύει την παρουσίαση
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Εξαγωγή Μακροεντολών VBA**

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation) και φορτώστε την παρουσίαση που περιέχει τη μακροεντολή.
2. Ελέγξτε εάν η παρουσίαση περιέχει έργο VBA.
3. Διασχίστε όλες τις ενότητες που περιέχονται στο έργο VBA για να προβάλετε τις μακροεντολές.

Αυτός ο κώδικας PHP δείχνει πώς να εξάγετε μακροεντολές VBA από μια παρουσίαση που τις περιέχει:

```php
  # Φορτώνει την παρουσίαση που περιέχει τη μακροεντολή
  $pres = new Presentation("VBA.pptm");
  try {
    # Ελέγχει εάν η παρουσίαση περιέχει έργο VBA
    if (!java_is_null($pres->getVbaProject())) {
      foreach($pres->getVbaProject()->getModules() as $module) {
        echo($module->getName());
        echo($module->getSourceCode());
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Έλεγχος Εάν Ένα Έργο VBA Είναι Προστατευμένο με Κωδικό**

Χρησιμοποιώντας τη μέθοδο [VbaProject::isPasswordProtected](https://reference.aspose.com/slides/el/php-java/aspose.slides/vbaproject/#isPasswordProtected), μπορείτε να καθορίσετε εάν οι ιδιότητες ενός έργου είναι προστατευμένες με κωδικό.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) και φορτώστε μια παρουσίαση που περιέχει μακροεντολή.
2. Ελέγξτε εάν η παρουσίαση περιέχει [VBA project](https://reference.aspose.com/slides/el/php-java/aspose.slides/vbaproject/).
3. Ελέγξτε εάν το έργο VBA είναι προστατευμένο με κωδικό για να προβάλετε τις ιδιότητές του.

```php
$presentation = new Presentation("VBA.pptm");
try {
    if ($presentation->getVbaProject() != null) { // Έλεγχος εάν η παρουσίαση περιέχει έργο VBA.
        if ($presentation->getVbaProject()->isPasswordProtected()) {
            printf("The VBA Project '%s' is protected by password to view project properties.", 
                    $presentation->getVbaProject()->getName());
        }
    }
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Τι συμβαίνει με τις μακροεντολές αν αποθηκεύσω την παρουσίαση ως PPTX;**

Οι μακροεντολές αφαιρούνται επειδή το PPTX δεν υποστηρίζει VBA. Για να διατηρηθούν οι μακροεντολές, επιλέξτε PPTM, PPSM ή POTM.

**Μπορεί το Aspose.Slides να εκτελεί μακροεντολές μέσα σε μια παρουσίαση, για παράδειγμα για ενημέρωση δεδομένων;**

Όχι. Η βιβλιοθήκη δεν εκτελεί ποτέ κώδικα VBA· η εκτέλεση είναι δυνατή μόνο μέσα στο PowerPoint με τις κατάλληλες ρυθμίσεις ασφαλείας.

**Υποστηρίζεται η εργασία με ελέγχους ActiveX που συνδέονται με κώδικα VBA;**

Ναι, μπορείτε να προσπελάζετε υπάρχοντες [ActiveX controls](/slides/el/php-java/activex/), να τροποποιείτε τις ιδιότητές τους και να τους αφαιρείτε. Αυτό είναι χρήσιμο όταν οι μακροεντολές αλληλεπιδρούν με τα ActiveX.