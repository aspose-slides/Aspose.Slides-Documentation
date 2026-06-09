---
title: Μετατροπή Παρουσιών PowerPoint σε XPS στο Android
linktitle: PowerPoint σε XPS
type: docs
weight: 70
url: /el/androidjava/convert-powerpoint-to-xps/
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
- Android
- Java
- Aspose.Slides
description: "Μετατρέψτε PowerPoint PPT/PPTX σε XPS υψηλής ποιότητας, ανεξάρτητο από πλατφόρμα, σε Java χρησιμοποιώντας το Aspose.Slides για Android. Λάβετε αναλυτική οδηγία βήμα προς βήμα και παράδειγμα κώδικα."
---
## **Επισκόπηση**

Το Aspose.Slides σάς επιτρέπει να μετατρέψετε παρουσιάσεις PowerPoint σε XPS αποθηκεύοντας ένα αρχείο PPT ή PPTX στη μορφή XPS. Αυτό το άρθρο εξηγεί πότε η μορφή XPS μπορεί να είναι χρήσιμη και δείχνει πώς να εκτελέσετε τη μετατροπή με το Aspose.Slides χρησιμοποιώντας είτε τις προεπιλεγμένες ρυθμίσεις είτε προσαρμοσμένες ρυθμίσεις [XpsOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/xpsoptions/).

## **Σχετικά με το XPS**
Η Microsoft ανέπτυξε το [XPS](https://docs.fileformat.com/page-description-language/xps/) ως εναλλακτική λύση προς το [PDF](https://docs.fileformat.com/pdf/). Σας επιτρέπει να εκτυπώσετε περιεχόμενο εξάγοντας ένα αρχείο πολύ παρόμοιο με PDF. Η μορφή XPS βασίζεται σε XML. Η διάταξη ή η δομή ενός αρχείου XPS παραμένει η ίδια σε όλα τα λειτουργικά συστήματα και τους εκτυπωτές. 

## **Πότε να χρησιμοποιήσετε τη μορφή Microsoft XPS**

{{% alert color="primary" %}} 

Για να δείτε πώς το Aspose.Slides μετατρέπει παρουσιάσεις PPT ή PPTX σε μορφή XPS, μπορείτε να επισκεφθείτε [αυτή η δωρεάν διαδικτυακή εφαρμογή μετατροπής](https://products.aspose.app/slides/el/conversion). 

{{% /alert %}} 

Αν θέλετε να μειώσετε τα έξοδα αποθήκευσης, μπορείτε να μετατρέψετε την παρουσίαση Microsoft PowerPoint σας σε μορφή XPS. Με αυτόν τον τρόπο θα βρείτε πιο εύκολο το αποθήκευση, η κοινή χρήση και η εκτύπωση των εγγράφων σας. 

Η Microsoft συνεχίζει να ενσωματώνει ισχυρή υποστήριξη για XPS στα Windows (ακόμη και στα Windows 10), οπότε ίσως θελήσετε να εξετάσετε την αποθήκευση αρχείων σε αυτή τη μορφή. Αν εργάζεστε με Windows 8.1, Windows 8, Windows 7 και Windows Vista, το XPS μπορεί να είναι η καλύτερη επιλογή για ορισμένες λειτουργίες. 

- **Windows 8** χρησιμοποιεί τη μορφή OXPS (Open XPS) για αρχεία XPS. Το OXPS είναι μια τυποποιημένη έκδοση της αρχικής μορφής XPS. Τα Windows 8 παρέχουν καλύτερη υποστήριξη για αρχεία XPS από ότι για αρχεία PDF. 
  - **XPS:** Διαθέσιμη ενσωματωμένη προβολή/αναγνώστης XPS και δυνατότητα εκτύπωσης σε XPS. 
  - **PDF:** Διαθέσιμο πρόγραμμα ανάγνωσης PDF, αλλά χωρίς δυνατότητα εκτύπωσης σε PDF. 

- **Windows 7** και **Windows Vista** χρησιμοποιούν την αρχική μορφή XPS. Αυτά τα λειτουργικά συστήματα επίσης παρέχουν καλύτερη υποστήριξη για αρχεία XPS από ότι για PDF. 
  - **XPS:** Διαθέσιμη ενσωματωμένη προβολή XPS και δυνατότητα εκτύπωσης σε XPS. 
  - **PDF:** Δεν υπάρχει πρόγραμμα ανάγνωσης PDF. Δεν υπάρχει δυνατότητα εκτύπωσης σε PDF. 

|<p>**Είσοδος PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Έξοδος XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Η Microsoft εντέλει ενσωμάτωσε υποστήριξη για λειτουργίες εκτύπωσης σε PDF μέσω της δυνατότητας "Print to PDF" στα Windows 10. Πριν από αυτό, οι χρήστες έπρεπε να εκτυπώνουν έγγραφα μέσω της μορφής XPS. 

## **Μετατροπή XPS με Aspose.Slides**

Στο [**Aspose.Slides**](https://products.aspose.com/slides/el/androidjava/) για Java, μπορείτε να χρησιμοποιήσετε τη μέθοδο [**Save**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) που εκτίθεται από την κλάση [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation) για να μετατρέψετε ολόκληρη την παρουσίαση σε έγγραφο XPS.

Κατά τη μετατροπή μιας παρουσίασης σε XPS, πρέπει να αποθηκεύσετε την παρουσίαση χρησιμοποιώντας μία από τις εξής ρυθμίσεις:

- Προεπιλεγμένες ρυθμίσεις (χωρίς [**XPSOptions**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/xpsoptions))
- Προσαρμοσμένες ρυθμίσεις (με [**XPSOptions**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/xpsoptions))

### **Μετατροπή παρουσιών σε XPS με προεπιλεγμένες ρυθμίσεις**

Αυτό το δείγμα κώδικα σε Java δείχνει πώς να μετατρέψετε μια παρουσίαση σε έγγραφο XPS χρησιμοποιώντας τυπικές ρυθμίσεις:

```java
// Δημιουργήστε ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // Αποθήκευση της παρουσίασης σε έγγραφο XPS
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Μετατροπή παρουσιών σε XPS με προσαρμοσμένες ρυθμίσεις**
Αυτό το δείγμα κώδικα δείχνει πώς να μετατρέψετε μια παρουσίαση σε έγγραφο XPS χρησιμοποιώντας προσαρμοσμένες ρυθμίσεις σε Java:

```java
// Δημιουργήστε ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // Δημιουργήστε ένα αντικείμενο της κλάσης TiffOptions
    XpsOptions options = new XpsOptions();

    // Αποθήκευση MetaFiles ως PNG
    options.setSaveMetafilesAsPng(true);

    // Αποθήκευση της παρουσίασης σε έγγραφο XPS
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Συχνές ερωτήσεις**

**Μπορώ να αποθηκεύσω το XPS σε ροή (stream) αντί για αρχείο;**

Ναι—το Aspose.Slides σας επιτρέπει να εξάγετε απευθείας σε ροή, κάτι που είναι ιδανικό για web API, pipelines διακομιστή ή οποιοδήποτε σενάριο όπου θέλετε να στείλετε το XPS χωρίς να αγγίξετε το σύστημα αρχείων.

**Μεταφέρονται οι κρυμμένες διαφάνειες στο XPS και μπορώ να τις εξαιρέσω;**

Από προεπιλογή, μόνο οι κανονικές (ορατές) διαφάνειες αποδίδονται. Μπορείτε να [συμπεριλάβετε ή εξαιρέσετε κρυμμένες διαφάνειες](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-) μέσω των [ρυθμίσεων εξαγωγής](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/xpsoptions/) πριν αποθηκεύσετε σε XPS, διασφαλίζοντας ότι η έξοδος περιέχει ακριβώς τις σελίδες που επιθυμείτε.