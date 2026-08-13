---
title: Καθορίστε εναλλακτικές γραμματοσειρές για παρουσιάσεις σε Android
linktitle: Εναλλακτική γραμματοσειρά
type: docs
weight: 10
url: /el/androidjava/create-fallback-font/
keywords:
- εναλλακτική γραμματοσειρά
- κανόνας εναλλακτικότητας
- εφαρμογή γραμματοσειράς
- αντικατάσταση γραμματοσειράς
- εύρος Unicode
- χαμένος γλύφος
- σωστός γλύφος
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Αποκτήστε πλήρη εξειδίκευση στο Aspose.Slides για Android μέσω Java για να ορίσετε εναλλακτικές γραμματοσειρές σε αρχεία PPT, PPTX και ODP, διασφαλίζοντας συνεπή εμφάνιση κειμένου σε οποιαδήποτε συσκευή ή λειτουργικό σύστημα."
---
## **Επισκόπηση**

Το Aspose.Slides σάς επιτρέπει να καθορίσετε εναλλακτικές γραμματοσειρές για την απόδοση και τις λειτουργίες εξαγωγής της παρουσίασης. Οι εναλλακτικές γραμματοσειρές χρησιμοποιούνται όταν η κύρια γραμματοσειρά δεν περιέχει γλύφους για συγκεκριμένους χαρακτήρες.

Η συμπεριφορά εναλλακτικής γραμματοσειράς ρυθμίζεται μέσω κανόνων εναλλακτικότητας. Κάθε κανόνας συσχετίζει ένα εύρος Unicode με μία ή περισσότερες γραμματοσειρές που μπορεί να περιέχουν τους απαιτούμενους γλύφους. Μπορείτε να ορίσετε κανόνες για διαφορετικά εύρη χαρακτήρων, να προσθέσετε ή να αφαιρέσετε εναλλακτικές γραμματοσειρές από υπάρχοντες κανόνες και να οργανώσετε πολλαπλούς κανόνες σε μια συλλογή κανόνων εναλλακτικών γραμματοσειρών.

Οι κανόνες εναλλακτικότητας είναι ρυθμίσεις απόδοσης χρόνου εκτέλεσης. Δεν τροποποιούν το αρχείο παρουσίασης ούτε αποθηκεύονται μέσα στο αρχείο PPTX.

## **Κανόνες Εναλλακτικότητας**

Το Aspose.Slides υποστηρίζει το interface [IFontFallBackRule](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IFontFallBackRule) και την κλάση [FontFallBackRule](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/FontFallBackRule) για τον καθορισμό των κανόνων εφαρμογής εναλλακτικής γραμματοσειράς. Η κλάση [FontFallBackRule](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/FontFallBackRule) αντιπροσωπεύει μια συσχέτιση μεταξύ του καθορισμένου εύρους Unicode, που χρησιμοποιείται για την αναζήτηση χαμένων γλύφων, και μιας λίστας γραμματοσειρών που μπορεί να περιέχουν τους σωστούς γλύφους:

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

Είναι επίσης δυνατό να [remove](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) μια εναλλακτική γραμματοσειρά ή να [addFallBackFonts](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) προσθέσετε σε υπάρχον [FontFallBackRule](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/FontFallBackRule) αντικείμενο.

Η κλάση [FontFallBackRulesCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/FontFallBackRulesCollection) μπορεί να χρησιμοποιηθεί για την οργάνωση λίστας αντικειμένων [FontFallBackRule](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/FontFallBackRule), όταν χρειάζεται να καθοριστούν κανόνες αντικατάστασης εναλλακτικών γραμματοσειρών για πολλαπλά εύρη Unicode.

{{% alert color="info" title="See also" %}} 
- [Create Fallback Fonts Collection](/slides/el/androidjava/create-fallback-fonts-collection/)
{{% /alert %}}

## **Συχνές Ερωτήσεις**

### Ποια είναι η διαφορά μεταξύ εναλλακτικής γραμματοσειράς, αντικατάστασης γραμματοσειράς και ενσωμάτωσης γραμματοσειράς;

Μια εναλλακτική γραμματοσειρά χρησιμοποιείται μόνο για χαρακτήρες που λείπουν στην κύρια γραμματοσειρά. Η [Font substitution](/slides/el/androidjava/font-substitution/) αντικαθιστά ολόκληρη τη συγκεκριμένη γραμματοσειρά με άλλη γραμματοσειρά. Η [Font embedding](/slides/el/androidjava/embedded-font/) ενσωματώνει τις γραμματοσειρές μέσα στο αρχείο εξόδου ώστε οι παραλήπτες να μπορούν να δουν το κείμενο όπως προοριζόταν.

### Εφαρμόζονται οι εναλλακτικές γραμματοσειρές κατά την εξαγωγή σε PDF, PNG ή SVG, ή μόνο στην απόδοση στην οθόνη;

Ναι. Η εναλλακτικότητα επηρεάζει όλες τις [rendering and export operations](/slides/el/androidjava/convert-presentation/) όπου πρέπει να σχεδιαστούν χαρακτήρες που λείπουν στην πηραία γραμματοσειρά.

### Η ρύθμιση της εναλλακτικότητας αλλάζει το ίδιο το αρχείο παρουσίασης και παραμένει η ρύθμιση για μελλοντικά ανοίγματα;

Όχι. Οι κανόνες εναλλακτικότητας είναι ρυθμίσεις απόδοσης χρόνου εκτέλεσης στον κώδικά σας· δεν αποθηκεύονται μέσα στο .pptx και δεν εμφανίζονται στο PowerPoint.

### Επηρεάζει την επιλογή εναλλακτικής γραμματοσειράς το λειτουργικό σύστημα (Windows/Linux/macOS) και το σύνολο των φακέλων γραμματοσειρών;

Ναι. Η μηχανή εντοπίζει γραμματοσειρές από τους διαθέσιμους φακέλους του συστήματος και από τυχόν [additional paths](/slides/el/androidjava/custom-font/) που παρέχετε. Εάν μια γραμματοσειρά δεν είναι φυσικά διαθέσιμη, ένας κανόνας που την αναφέρεται δεν μπορεί να εφαρμοστεί.

### Λειτουργεί η εναλλακτική για WordArt, SmartArt και διαγράμματα;

Ναι. Όταν αυτά τα αντικείμενα περιέχουν κείμενο, εφαρμόζεται ο ίδιος μηχανισμός αντικατάστασης γλύφων για την απόδοση των ελλειπούσων χαρακτήρων.