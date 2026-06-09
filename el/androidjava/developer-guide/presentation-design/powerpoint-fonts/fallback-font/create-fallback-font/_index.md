---
title: Καθορίστε εφεδρικές γραμματοσειρές για παρουσιάσεις σε Android
linktitle: Εφεδρική γραμματοσειρά
type: docs
weight: 10
url: /el/androidjava/create-fallback-font/
keywords:
- εφεδρική γραμματοσειρά
- κανόνας εφεδρείας
- εφαρμογή γραμματοσειράς
- αντικατάσταση γραμματοσειράς
- διάστημα Unicode
- ελλιπής γλύφος
- σωστός γλύφος
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Κατακτήστε το Aspose.Slides για Android μέσω Java για να ορίσετε εφεδρικές γραμματοσειρές σε αρχεία PPT, PPTX και ODP, διασφαλίζοντας συνεπή εμφάνιση κειμένου σε κάθε συσκευή ή λειτουργικό σύστημα."
---
## **Επισκόπηση**

Το Aspose.Slides επιτρέπει τον καθορισμό εφεδρικών γραμματοσειρών για την απόδοση και τις εξαγωγές παρουσιάσεων. Οι εφεδρικές γραμματοσειρές χρησιμοποιούνται όταν η κύρια γραμματοσειρά δεν περιέχει γλύφους για συγκεκριμένους χαρακτήρες.

Η συμπεριφορά εφεδρείας διαμορφώνεται μέσω κανόνων εφεδρείας. Κάθε κανόνας συσχετίζει ένα διάστημα Unicode με μία ή περισσότερες γραμματοσειρές που μπορεί να περιέχουν τους απαιτούμενους γλύφους. Μπορείτε να ορίσετε κανόνες για διαφορετικά διαστήματα χαρακτήρων, να προσθέτε ή να αφαιρέσετε εφεδρικές γραμματοσειρές από υπάρχοντες κανόνες και να οργανώσετε πολλούς κανόνες σε μια συλλογή κανόνων εφεδρικής γραμματοσειράς.

Οι κανόνες εφεδρείας είναι ρυθμίσεις απόδοσης χρόνου εκτέλεσης. Δεν τροποποιούν το αρχείο παρουσίασης ούτε αποθηκεύονται μέσα στο αρχείο PPTX.

## **Κανόνες Εφεδρείας**

Το Aspose.Slides υποστηρίζει το interface [IFontFallBackRule](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IFontFallBackRule) και την κλάση [FontFallBackRule](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/FontFallBackRule) για τον καθορισμό των κανόνων εφαρμογής εφεδρικής γραμματοσειράς. Η κλάση [FontFallBackRule](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/FontFallBackRule) αναπαριστά μια σύζευξη μεταξύ του καθορισμένου διαστήματος Unicode, που χρησιμοποιείται για την αναζήτηση ελλιπών γλύφων, και μιας λίστας γραμματοσειρών που μπορεί να περιέχει τους κατάλληλους γλύφους:

```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Χρησιμοποιώντας πολλούς τρόπους μπορείτε να προσθέσετε λίστα γραμματοσειρών:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Είναι επίσης δυνατό να [remove](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) μια εφεδρική γραμματοσειρά ή να [addFallBackFonts](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) προστεθούν σε υπάρχον [FontFallBackRule](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/FontFallBackRule) αντικείμενο.

Το [FontFallBackRulesCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/FontFallBackRulesCollection) μπορεί να χρησιμοποιηθεί για την οργάνωση λίστας αντικειμένων [FontFallBackRule](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/FontFallBackRule), όταν χρειάζεται να καθοριστούν κανόνες αντικατάστασης εφεδρικής γραμματοσειράς για πολλαπλά διαστήματα Unicode.

{{% alert color="primary" title="Δείτε επίσης" %}} 
- [Δημιουργία Συλλογής Εφεδρικών Γραμματοσειρών](/slides/el/androidjava/create-fallback-fonts-collection/)
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ εφεδρικής γραμματοσειράς, αντικατάστασης γραμματοσειράς και ενσωμάτωσης γραμματοσειράς;**

Μια εφεδρική γραμματοσειρά χρησιμοποιείται μόνο για χαρακτήρες που λείπουν από την κύρια γραμματοσειρά. [Αντικατάσταση γραμματοσειράς](/slides/el/androidjava/font-substitution/) αντικαθιστά ολόκληρη την καθορισμένη γραμματοσειρά με άλλη γραμματοσειρά. [Ενσωμάτωση γραμματοσειράς](/slides/el/androidjava/embedded-font/) πακετάρει τις γραμματοσειρές μέσα στο αρχείο εξόδου ώστε οι παραλήπτες να μπορούν να δουν το κείμενο όπως προορίζεται.

**Εφαρμόζονται οι εφεδρικές γραμματοσειρές κατά τις εξαγωγές όπως PDF, PNG ή SVG, ή μόνο στην απόδοση στην οθόνη;**

Ναι. Η εφεδρεία επηρεάζει όλες τις [λειτουργίες απόδοσης και εξαγωγής](/slides/el/androidjava/convert-presentation/) όπου πρέπει να σχεδιαστούν χαρακτήρες που λείπουν από τη πηγαία γραμματοσειρά.

**Αλλάζει η διαμόρφωση εφεδρείας το ίδιο το αρχείο παρουσίασης και θα παραμείνει η ρύθμιση για μελλοντικές ανοίξεις;**

Οχι. Οι κανόνες εφεδρείας είναι ρυθμίσεις απόδοσης χρόνου εκτέλεσης στον κώδικά σας· δεν αποθηκεύονται μέσα στο .pptx και δεν εμφανίζονται στο PowerPoint.

**Επηρεάζει η λειτουργική σύστημα (Windows/Linux/macOS) και το σύνολο των φακέλων γραμματοσειρών την επιλογή εφεδρείας;**

Ναί. Η μηχανή εντοπίζει γραμματοσειρές από τα διαθέσιμα συστημικά φακέλους και τυχόν [επιπλέον διαδρομές](/slides/el/androidjava/custom-font/) που παρέχετε. Εάν μια γραμματοσειρά δεν είναι φυσικά διαθέσιμη, ένας κανόνας που την αναφέρει δεν μπορεί να εφαρμοστεί.

**Λειτουργεί η εφεδρεία για WordArt, SmartArt και γραφήματα;**

Ναί. Όταν αυτά τα αντικείμενα περιέχουν κείμενο, εφαρμόζεται ο ίδιος μηχανισμός [γλυφ‑αντικατάστασης] για την απόδοση των ελλιπών χαρακτήρων.