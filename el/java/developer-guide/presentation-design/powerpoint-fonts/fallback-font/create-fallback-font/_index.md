---
title: Καθορισμός Εφεδρικών Γραμματοσειρών για Παρουσιάσεις σε Java
linktitle: Εφεδρική Γραμματοσειρά
type: docs
weight: 10
url: /el/java/create-fallback-font/
keywords:
- εφεδρική γραμματοσειρά
- κανόνας εφεδρείας
- εφαρμογή γραμματοσειράς
- αντικατάσταση γραμματοσειράς
- περιοχή Unicode
- χαμένος γλύφος
- σωστός γλύφος
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Κατακτήστε το Aspose.Slides για Java ώστε να ορίσετε εφεδρικές γραμματοσειρές σε αρχεία PPT, PPTX και ODP, εξασφαλίζοντας συνεπή προβολή κειμένου σε οποιαδήποτε συσκευή ή λειτουργικό σύστημα."
---
## **Επισκόπηση**

Το Aspose.Slides σάς επιτρέπει να καθορίσετε εφεδρικές γραμματοσειρές για την απόδοση και τις εξαγωγές της παρουσίασης. Οι εφεδρικές γραμματοσειρές χρησιμοποιούνται όταν η κύρια γραμματοσειρά δεν περιέχει γλύφους για συγκεκριμένους χαρακτήρες.

Η συμπεριφορά εφεδρείας ρυθμίζεται μέσω κανόνων εφεδρείας. Κάθε κανόνας συσχετώνει μια περιοχή Unicode με μία ή περισσότερες γραμματοσειρές που μπορεί να περιέχουν τους απαιτούμενους γλύφους. Μπορείτε να ορίσετε κανόνες για διαφορετικές περιοχές χαρακτήρων, να προσθέσετε ή να αφαιρέσετε εφεδρικές γραμματοσειρές από υπάρχοντες κανόνες και να οργανώσετε πολλαπλούς κανόνες σε μια συλλογή κανόνων εφεδρικής γραμματοσειράς.

Οι κανόνες εφεδρείας είναι ρυθμίσεις απόδοσης χρόνου εκτέλεσης. Δεν τροποποιούν το αρχείο παρουσίασης καθ' αυτό και δεν αποθηκεύονται μέσα στο αρχείο PPTX.

## **Κανόνες Εφεδρείας**

Το Aspose.Slides υποστηρίζει τη διεπαφή [IFontFallBackRule](https://reference.aspose.com/slides/el/java/com.aspose.slides/IFontFallBackRule) και την κλάση [FontFallBackRule](https://reference.aspose.com/slides/el/java/com.aspose.slides/FontFallBackRule) για τον καθορισμό των κανόνων που εφαρμόζουν μια εφεδρική γραμματοσειρά. Η κλάση [FontFallBackRule](https://reference.aspose.com/slides/el/java/com.aspose.slides/FontFallBackRule) αντιπροσωπεύει μια συσχέτιση μεταξύ της καθορισμένης περιοχής Unicode, που χρησιμοποιείται για την αναζήτηση χαμένων γλύφων, και μιας λίστας γραμματοσειρών που ενδέχεται να περιέχουν τους κατάλληλους γλύφους:

```java
import com.aspose.slides.*;

long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Χρησιμοποιώντας πολλαπλούς τρόπους μπορείτε να προσθέσετε λίστα γραμματοσειρών:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Επίσης είναι δυνατόν να [remove](https://reference.aspose.com/slides/el/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) εφεδρική γραμματοσειρά ή να [addFallBackFonts](https://reference.aspose.com/slides/el/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) σε υπάρχον αντικείμενο [FontFallBackRule](https://reference.aspose.com/slides/el/java/com.aspose.slides/FontFallBackRule).

Η κλάση [FontFallBackRulesCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/FontFallBackRulesCollection) μπορεί να χρησιμοποιηθεί για την οργάνωση λίστας αντικειμένων [FontFallBackRule](https://reference.aspose.com/slides/el/java/com.aspose.slides/FontFallBackRule), όταν υπάρχει ανάγκη να καθοριστούν κανόνες αντικατάστασης εφεδρικής γραμματοσειράς για πολλαπλές περιοχές Unicode.

{{% alert color="info" title="See also" %}} 
- [Δημιουργία Συλλογής Εφεδρικών Γραμματοσειρών](/slides/el/java/create-fallback-fonts-collection/)
{{% /alert %}}

## **Συχνές Ερωτήσεις**

### Ποια είναι η διαφορά μεταξύ εφεδρικής γραμματοσειράς, αντικατάστασης γραμματοσειράς και ενσωμάτωσης γραμματοσειράς;

Μια εφεδρική γραμματοσειρά χρησιμοποιείται μόνο για χαρακτήρες που λείπουν στην κύρια γραμματοσειρά. Η [Αντικατάσταση γραμματοσειράς](/slides/el/java/font-substitution/) αντικαθιστά ολόκληρη τη συγκεκριμένη γραμματοσειρά με άλλη γραμματοσειρά. Η [Ενσωμάτωση γραμματοσειράς](/slides/el/java/embedded-font/) ενσωματώνει τις γραμματοσειρές μέσα στο αρχείο εξόδου ώστε οι παραλήπτες να μπορούν να βλέπουν το κείμενο όπως προορίζεται.

### Εφαρμόζονται οι εφεδρικές γραμματοσειρές κατά τις εξαγωγές όπως PDF, PNG ή SVG, ή μόνο στην απόδοση στην οθόνη;

Ναι. Η εφεδρεία επηρεάζει όλες τις [επιχειρήσεις απόδοσης και εξαγωγής](/slides/el/java/convert-presentation/) όπου πρέπει να σχεδιαστούν χαρακτήρες αλλά λείπουν από τη γραμματοσειρά προέλευσης.

### Η διαμόρφωση εφεδρείας αλλάζει το αρχείο παρουσίασης και θα παραμείνει η ρύθμιση για μελλοντικά ανοίγματα;

Όχι. Οι κανόνες εφεδρείας είναι ρυθμίσεις απόδοσης χρόνου εκτέλεσης στον κώδικά σας· δεν αποθηκεύονται μέσα στο .pptx και δεν εμφανίζονται στο PowerPoint.

### Επηρεάζουν το λειτουργικό σύστημα (Windows/Linux/macOS) και το σύνολο των καταλόγων γραμματοσειρών την επιλογή εφεδρείας;

Ναι. Η μηχανή εντοπίζει γραμματοσειρές από τους διαθέσιμους φακέλους συστήματος και τυχόν [πρόσθετες διαδρομές](/slides/el/java/custom-font/) που παρέχετε. Εάν μια γραμματοσειρά δεν είναι φυσικά διαθέσιμη, ένας κανόνας που την αναφέρει δεν μπορεί να ενεργοποιηθεί.

### Η εφεδρεία λειτουργεί για WordArt, SmartArt και διαγράμματα;

Ναι. Όταν αυτά τα αντικείμενα περιέχουν κείμενο, εφαρμόζεται ο ίδιος μηχανισμός αντικατάστασης γλύφων για την απόδοση των ελλειπουσών χαρακτήρων.