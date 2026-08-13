---
title: Μετατροπή Παρουσιάσεων PowerPoint σε XPS με Java
linktitle: PowerPoint σε XPS
type: docs
weight: 70
url: /el/java/convert-powerpoint-to-xps/
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
- Java
- Aspose.Slides
description: "Μετατρέψτε PowerPoint PPT/PPTX σε XPS υψηλής ποιότητας, ανεξάρτητο από πλατφόρμα, με Java χρησιμοποιώντας Aspose.Slides. Λάβετε βήμα-βήμα οδηγό και παράδειγμα κώδικα."
---
## **Επισκόπηση**

Aspose.Slides σας επιτρέπει να μετατρέπετε παρουσιάσεις PowerPoint σε XPS αποθηκεύοντας ένα αρχείο PPT ή PPTX στη μορφή XPS. Αυτό το άρθρο εξηγεί πότε η μορφή XPS μπορεί να είναι χρήσιμη και δείχνει πώς να πραγματοποιήσετε τη μετατροπή με το Aspose.Slides χρησιμοποιώντας είτε τις προεπιλεγμένες ρυθμίσεις είτε τις προσαρμοσμένες ρυθμίσεις [XpsOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/xpsoptions/) .

## **Σχετικά με το XPS**

Η Microsoft ανέπτυξε το [XPS](https://docs.fileformat.com/page-description-language/xps/) ως εναλλακτική λύση στο [PDF](https://docs.fileformat.com/pdf/). Σας επιτρέπει να εκτυπώνετε περιεχόμενο δημιουργώντας ένα αρχείο πολύ παρόμοιο με PDF. Η μορφή XPS βασίζεται σε XML. Η διάταξη ή η δομή ενός αρχείου XPS παραμένει η ίδια σε όλα τα λειτουργικά συστήματα και τους εκτυπωτές. 

## **Πότε να Χρησιμοποιήσετε τη Μορφή XPS της Microsoft**

{{% alert color="info" %}} 

Για να δείτε πώς το Aspose.Slides μετατρέπει παρουσίαση PPT ή PPTX σε μορφή XPS, μπορείτε να επισκεφθείτε αυτή τη δωρεάν διαδικτυακή εφαρμογή μετατροπής [this free online converter app](https://products.aspose.app/slides/el/conversion). 

{{% /alert %}} 

Εάν θέλετε να μειώσετε τα έξοδα αποθήκευσης, μπορείτε να μετατρέψετε την παρουσίαση Microsoft PowerPoint σε μορφή XPS. Με αυτόν τον τρόπο θα είναι πιο εύκολο να αποθηκεύετε, να μοιράζεστε και να εκτυπώνετε τα έγγραφά σας. 

Η Microsoft συνεχίζει να παρέχει ισχυρή υποστήριξη για το XPS στα Windows (ακόμη και στα Windows 10), οπότε ίσως θελήσετε να εξετάσετε την αποθήκευση αρχείων σε αυτή τη μορφή. Εάν εργάζεστε με Windows 8.1, Windows 8, Windows 7 και Windows Vista, τότε το XPS μπορεί πραγματικά να είναι η καλύτερη επιλογή για ορισμένες λειτουργίες. 

- **Windows 8** χρησιμοποιεί τη μορφή OXPS (Open XPS) για αρχεία XPS. Το OXPS είναι μια τυποποιημένη έκδοση της αρχικής μορφής XPS. Τα Windows 8 παρέχουν καλύτερη υποστήριξη για αρχεία XPS από ό, τι για αρχεία PDF. 
  - **XPS:** Διαθέσιμο ενσωματωμένο πρόγραμμα προβολής/ανάγνωσης XPS και δυνατότητα εκτύπωσης σε XPS. 
  - **PDF:** Διαθέσιμο πρόγραμμα ανάγνωσης PDF, αλλά δεν υπάρχει δυνατότητα εκτύπωσης σε PDF. 

- **Windows 7 και Windows Vista** χρησιμοποιούν την αρχική μορφή XPS. Αυτά τα λειτουργικά συστήματα παρέχουν επίσης καλύτερη υποστήριξη για αρχεία XPS από ό,τι για PDFs. 
  - **XPS:** Διαθέσιμο ενσωματωμένο πρόγραμμα προβολής XPS και δυνατότητα εκτύπωσης σε XPS. 
  - **PDF:** Δεν υπάρχει πρόγραμμα ανάγνωσης PDF. Δεν υπάρχει δυνατότητα εκτύπωσης σε PDF. 

|<p>**Εισαγωγή PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Έξοδος XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



Η Microsoft τελικά υλοποίησε υποστήριξη για λειτουργίες εκτύπωσης σε PDF μέσω της δυνατότητας Print to PDF στα Windows 10. Πρώην, οι χρήστες έπρεπε να εκτυπώνουν έγγραφα μέσω της μορφής XPS. 

## **Μετατροπή XPS με το Aspose.Slides**

Στο [**Aspose.Slides**](https://products.aspose.com/slides/el/java/) για Java, μπορείτε να χρησιμοποιήσετε τη μέθοδο [**Save**](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) που εκτίθεται από την κλάση [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) για να μετατρέψετε ολόκληρη την παρουσίαση σε ένα έγγραφο XPS. 

Κατά τη μετατροπή μιας παρουσίασης σε XPS, πρέπει να αποθηκεύσετε την παρουσίαση χρησιμοποιώντας μία από τις ακόλουθες ρυθμίσεις:

- Προεπιλεγμένες ρυθμίσεις (χωρίς [**XPSOptions**](https://reference.aspose.com/slides/el/java/com.aspose.slides/xpsoptions))
- Προσαρμοσμένες ρυθμίσεις (με [**XPSOptions**](https://reference.aspose.com/slides/el/java/com.aspose.slides/xpsoptions))

### **Μετατροπή Παρουσιάσεων σε XPS με Προεπιλεγμένες Ρυθμίσεις**

Αυτό το δείγμα κώδικα σε Java δείχνει πώς να μετατρέψετε μια παρουσίαση σε έγγραφο XPS χρησιμοποιώντας τις τυπικές ρυθμίσεις:

```java
import com.aspose.slides.*;

// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // Αποθήκευση της παρουσίασης σε έγγραφο XPS
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Μετατροπή Παρουσιάσεων σε XPS με Προσαρμοσμένες Ρυθμίσεις**

Αυτό το δείγμα κώδικα δείχνει πώς να μετατρέψετε μια παρουσίαση σε έγγραφο XPS χρησιμοποιώντας προσαρμοσμένες ρυθμίσεις σε Java:

```java
import com.aspose.slides.*;

// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // Δημιουργία του αντικειμένου XpsOptions
    XpsOptions options = new XpsOptions();

    // Αποθήκευση των MetaFiles ως PNG
    options.setSaveMetafilesAsPng(true);

    // Αποθήκευση της παρουσίασης σε έγγραφο XPS
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Συχνές Ερωτήσεις**

### **Μπορώ να αποθηκεύσω σε XPS σε ροή (stream) αντί για αρχείο;**

Ναι—το Aspose.Slides σας επιτρέπει να εξάγετε απευθείας σε ροή, κάτι που είναι ιδανικό για web APIs, διαδρομές στο διακομιστή ή οποιοδήποτε σενάριο όπου θέλετε να στείλετε το XPS χωρίς να αγγίξετε το σύστημα αρχείων.

### **Μεταφέρονται οι κρυφές διαφάνειες στο XPS και μπορώ να τις εξαιρέσω;**

Από προεπιλογή, μόνο οι κανονικές (ορατές) διαφάνειες αποδίδονται. Μπορείτε να [συμπεριλάβετε ή εξαιρέσετε κρυφές διαφάνειες](https://reference.aspose.com/slides/el/java/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-) μέσω των [ρυθμίσεων εξαγωγής](https://reference.aspose.com/slides/el/java/com.aspose.slides/xpsoptions/) πριν αποθηκεύσετε σε XPS, διασφαλίζοντας ότι η έξοδος περιέχει ακριβώς τις σελίδες που θέλετε.