---
title: Μετατροπή Παρουσιών PowerPoint σε XPS με PHP
linktitle: PowerPoint σε XPS
type: docs
weight: 70
url: /el/php-java/convert-powerpoint-to-xps/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- μετατροπή διαφάνειας
- μετατροπή PPT
- μετατροπή PPTX
- PowerPoint σε XPS
- παρουσίαση σε XPS
- διαφάνεια σε XPS
- PPT σε XPS
- PPTX σε XPS
- αποθήκευση PPT ως XPS
- αποθήκευση PPTX ως XPS
- εξαγωγή PPT σε XPS
- εξαγωγή PPTX σε XPS
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Μετατρέψτε PowerPoint PPT/PPTX σε υψηλής ποιότητας, ανεξάρτητο από πλατφόρμα XPS χρησιμοποιώντας το Aspose.Slides για PHP μέσω Java. Λάβετε αναλυτική οδηγία βήμα προς βήμα και δείγμα κώδικα."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει να μετατρέψετε παρουσιάσεις PowerPoint σε XPS αποθηκεύοντας ένα αρχείο PPT ή PPTX σε μορφή XPS. Αυτό το άρθρο εξηγεί πότε η μορφή XPS μπορεί να είναι χρήσιμη και δείχνει πώς να εκτελέσετε τη μετατροπή με το Aspose.Slides χρησιμοποιώντας είτε τις προεπιλεγμένες ρυθμίσεις είτε προσαρμοσμένες ρυθμίσεις [XpsOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/xpsoptions/) .

## **Σχετικά με το XPS**
Η Microsoft ανέπτυξε το [XPS](https://docs.fileformat.com/page-description-language/xps/) ως εναλλακτική λύση στο [PDF](https://docs.fileformat.com/pdf/). Σας επιτρέπει να εκτυπώνετε περιεχόμενο εξάγοντας ένα αρχείο πολύ παρόμοιο με το PDF. Η μορφή XPS βασίζεται σε XML. Η διάταξη ή η δομή ενός αρχείου XPS παραμένει η ίδια σε όλα τα λειτουργικά συστήματα και τους εκτυπωτές. 

## **Πότε να Χρησιμοποιήσετε τη Μορφή Microsoft XPS**

{{% alert color="primary" %}} 

Για να δείτε πώς το Aspose.Slides μετατρέπει μια παρουσίαση PPT ή PPTX στη μορφή XPS, μπορείτε να δοκιμάσετε [αυτήν τη δωρεάν διαδικτυακή εφαρμογή μετατροπής](https://products.aspose.app/slides/el/conversion). 

{{% /alert %}} 

Αν θέλετε να μειώσετε το κόστος αποθήκευσης, μπορείτε να μετατρέψετε την παρουσίαση Microsoft PowerPoint σε μορφή XPS. Με αυτόν τον τρόπο, θα είναι πιο εύκολο να αποθηκεύετε, να μοιράζεστε και να εκτυπώνετε τα έγγραφά σας. 

Η Microsoft συνεχίζει να παρέχει ισχυρή υποστήριξη για το XPS στα Windows (ακόμη και στα Windows 10), οπότε μπορεί να θέλετε να εξετάσετε την αποθήκευση αρχείων σε αυτή τη μορφή. Εάν εργάζεστε με Windows 8.1, Windows 8, Windows 7 και Windows Vista, τότε το XPS μπορεί να είναι η καλύτερη επιλογή σας για ορισμένες λειτουργίες. 

- **Windows 8** χρησιμοποιεί τη μορφή OXPS (Open XPS) για αρχεία XPS. Το OXPS είναι μια τυποποιημένη έκδοση της αρχικής μορφής XPS. Τα Windows 8 παρέχουν καλύτερη υποστήριξη για αρχεία XPS από ό,τι για αρχεία PDF. 
  - **XPS:** Διαθέσιμο ενσωματωμένο πρόγραμμα προβολής/ανάγνωσης XPS και δυνατότητα εκτύπωσης σε XPS. 
  - **PDF:** Διαθέσιμο πρόγραμμα ανάγνωσης PDF, αλλά δεν υπάρχει δυνατότητα εκτύπωσης σε PDF. 

- **Windows 7 και Windows Vista** χρησιμοποιούν την αρχική μορφή XPS. Αυτά τα λειτουργικά συστήματα παρέχουν επίσης καλύτερη υποστήριξη για αρχεία XPS από ό,τι για PDF. 
  - **XPS:** Διαθέσιμο ενσωματωμένο πρόγραμμα προβολής XPS και δυνατότητα εκτύπωσης σε XPS. 
  - **PDF:** Δεν υπάρχει πρόγραμμα ανάγνωσης PDF. Δεν υπάρχει δυνατότητα εκτύπωσης σε PDF. 

|<p>**Είσοδος PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Έξοδος XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Η Microsoft τελικά υλοποίησε υποστήριξη για λειτουργίες εκτύπωσης σε PDF μέσω της δυνατότητας Εκτύπωση σε PDF στα Windows 10. Πριν από αυτό, οι χρήστες έπρεπε να εκτυπώνουν έγγραφα μέσω της μορφής XPS. 

## **Μετατροπή XPS με το Aspose.Slides**

Στο [**Aspose.Slides**](https://products.aspose.com/slides/el/php-java/) για Java, μπορείτε να χρησιμοποιήσετε τη μέθοδο [**Save**](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) που εκτίθεται από την κλάση [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation) για να μετατρέψετε ολόκληρη την παρουσίαση σε έγγραφο XPS.

Κατά τη μετατροπή μιας παρουσίασης σε XPS, πρέπει να αποθηκεύσετε την παρουσίαση χρησιμοποιώντας μία από τις εξής ρυθμίσεις:

- Προεπιλεγμένες ρυθμίσεις (χωρίς [**XPSOptions**](https://reference.aspose.com/slides/el/php-java/aspose.slides/xpsoptions))
- Προσαρμοσμένες ρυθμίσεις (με [**XPSOptions**](https://reference.aspose.com/slides/el/php-java/aspose.slides/xpsoptions))

### **Μετατροπή Παρουσιάσεων σε XPS με Προεπιλεγμένες Ρυθμίσεις**

Αυτό το παράδειγμα κώδικα σας δείχνει πώς να μετατρέψετε μια παρουσίαση σε έγγραφο XPS χρησιμοποιώντας τις προεπιλεγμένες ρυθμίσεις:

```php
  # Δημιουργεί αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
  $pres = new Presentation("Convert_XPS.pptx");
  try {
    # Αποθήκευση της παρουσίασης σε έγγραφο XPS
    $pres->save("XPS_Output_Without_XPSOption.xps", SaveFormat::Xps);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Μετατροπή Παρουσιάσεων σε XPS με Προσαρμοσμένες Ρυθμίσεις**

Αυτό το παράδειγμα κώδικα σας δείχνει πώς να μετατρέψετε μια παρουσίαση σε έγγραφο XPS χρησιμοποιώντας προσαρμοσμένες ρυθμίσεις :

```php
  # Δημιουργεί αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
  $pres = new Presentation("Convert_XPS_Options.pptx");
  try {
    # Δημιουργεί την κλάση TiffOptions
    $options = new XpsOptions();
    # Αποθήκευση MetaFiles ως PNG
    $options->setSaveMetafilesAsPng(true);
    # Αποθήκευση της παρουσίασης σε έγγραφο XPS
    $pres->save("XPS_Output_With_Options.xps", SaveFormat::Xps, $options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Συχνές Ερωτήσεις**

**Μπορώ να αποθηκεύσω το XPS σε ροή αντί για αρχείο;**

Ναι—το Aspose.Slides σας επιτρέπει να εξάγετε απευθείας σε ροή, κάτι που είναι ιδανικό για web APIs, pipelines στον διακομιστή, ή οποιοδήποτε σενάριο όπου θέλετε να στείλετε το XPS χωρίς να αγγίξετε το σύστημα αρχείων.

**Οι κρυφές διαφάνειες μεταφέρονται στο XPS και μπορώ να τις εξαιρέσω;**

Από προεπιλογή, μόνο οι κανονικές (ορατές) διαφάνειες αποδίδονται. Μπορείτε να [συμπεριλάβετε ή εξαιρέσετε κρυφές διαφάνειες](https://reference.aspose.com/slides/el/php-java/aspose.slides/xpsoptions/setshowhiddenslides/) μέσω των [ρυθμίσεων εξαγωγής](https://reference.aspose.com/slides/el/php-java/aspose.slides/xpsoptions/) πριν αποθηκεύσετε σε XPS, εξασφαλίζοντας ότι η έξοδος περιέχει ακριβώς τις σελίδες που θέλετε.