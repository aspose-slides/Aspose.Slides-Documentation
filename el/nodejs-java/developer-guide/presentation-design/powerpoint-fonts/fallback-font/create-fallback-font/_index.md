---
title: Καθορισμός Εναλλακτικών Γραμματοσειρών για Παρουσιάσεις σε JavaScript
linktitle: Εναλλακτική Γραμματοσειρά
type: docs
weight: 10
url: /el/nodejs-java/create-fallback-font/
keywords:
- εναλλακτική γραμματοσειρά
- κανόνας εναλλακτικότητας
- εφαρμογή γραμματοσειράς
- αντικατάσταση γραμματοσειράς
- περιοχή Unicode
- απουσία γλύφου
- σωστός γλύφος
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Αποκτήστε έλεγχο του Aspose.Slides για Node.js ώστε να ορίσετε εναλλακτικές γραμματοσειρές σε αρχεία PPT, PPTX και ODP με JavaScript, διασφαλίζοντας συνεπή εμφάνιση κειμένου σε οποιαδήποτε συσκευή ή λειτουργικό σύστημα."
---
## **Επισκόπηση**

Το Aspose.Slides σάς επιτρέπει να καθορίσετε εναλλακτικές γραμματοσειρές για την απόδοση και τις εξαγωγές παρουσιάσεων. Οι εναλλακτικές γραμματοσειρές χρησιμοποιούνται όταν η κύρια γραμματοσειρά δεν περιέχει γλύφους για συγκεκριμένους χαρακτήρες.

Η συμπεριφορά των εναλλακτικών γραμματοσειρών ρυθμίζεται μέσω κανόνων εναλλακτικών γραμματοσειρών. Κάθε κανόνας συνδέει μια περιοχή Unicode με μία ή περισσότερες γραμματοσειρές που μπορεί να περιέχουν τους απαιτούμενους γλύφους. Μπορείτε να ορίσετε κανόνες για διαφορετικές περιοχές χαρακτήρων, να προσθέσετε ή να αφαιρέσετε εναλλακτικές γραμματοσειρές από υπάρχοντες κανόνες και να οργανώσετε πολλαπλούς κανόνες σε μια συλλογή κανόνων εναλλακτικών γραμματοσειρών.

Οι κανόνες εναλλακτικών γραμματοσειρών είναι ρυθμίσεις απόδοσης χρόνου εκτέλεσης. Δεν τροποποιούν το αρχείο παρουσίασης αυτό καθ' αυτό και δεν αποθηκεύονται μέσα στο αρχείο PPTX.

## **Κανόνες Εναλλακτικής Γραμματοσειράς**

Το Aspose.Slides υποστηρίζει την κλάση [FontFallBackRule](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/FontFallBackRule) για να καθορίσετε τους κανόνες εφαρμογής μιας εναλλακτικής γραμματοσειράς. Η κλάση [FontFallBackRule](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/FontFallBackRule) αντιπροσωπεύει μια σύνδεση μεταξύ της καθορισμένης περιοχής Unicode, που χρησιμοποιείται για την αναζήτηση ελλιπών γλύφων, και μιας λίστας γραμματοσειρών που μπορεί να περιέχουν τους κατάλληλους γλύφους:

```javascript
var startUnicodeIndex = 0xb80;
var endUnicodeIndex = 0xbff;
var firstRule = new aspose.slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
var secondRule = new aspose.slides.FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
// Χρησιμοποιώντας πολλούς τρόπους μπορείτε να προσθέσετε λίστα γραμματοσειρών:
var fontNames = java.newArray("java.lang.String", ["Segoe UI Emoji, Segue UI Symbol", "Arial"]));
var thirdRule = new aspose.slides.FontFallBackRule(0x1f300, 0x1f64f, fontNames);
```

Επίσης, είναι δυνατόν να [remove](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) μια εναλλακτική γραμματοσειρά ή να [addFallBackFonts](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) προσθέσετε σε ένα υπάρχον αντικείμενο [FontFallBackRule](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/FontFallBackRule).

Η [FontFallBackRulesCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/FontFallBackRulesCollection) μπορεί να χρησιμοποιηθεί για την οργάνωση λίστας αντικειμένων [FontFallBackRule](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/FontFallBackRule), όταν υπάρχει ανάγκη να καθοριστούν κανόνες αντικατάστασης εναλλακτικής γραμματοσειράς για πολλαπλές περιοχές Unicode.

{{% alert color="primary" title="Δείτε επίσης" %}} 
- [Δημιουργία Συλλογής Εναλλακτικών Γραμματοσειρών](/slides/el/nodejs-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ εναλλακτικής γραμματοσειράς, αντικατάστασης γραμματοσειράς και ενσωμάτωσης γραμματοσειράς;**

Μια εναλλακτική γραμματοσειρά χρησιμοποιείται μόνο για χαρακτήρες που λείπουν στην κύρια γραμματοσειρά. Η [Font substitution](/slides/el/nodejs-java/font-substitution/) αντικαθιστά ολόκληρη τη συγκεκριμένη γραμματοσειρά με άλλη γραμματοσειρά. Η [Font embedding](/slides/el/nodejs-java/embedded-font/) ενσωματώνει τις γραμματοσειρές μέσα στο αρχείο εξόδου ώστε οι αποδέκτες να μπορούν να δουν το κείμενο όπως προβλέπεται.

**Εφαρμόζονται οι εναλλακτικές γραμματοσειρές κατά τις εξαγωγές όπως PDF, PNG ή SVG, ή μόνο στην απόδοση στην οθόνη;**

Ναι. Η εναλλακτική γραμματοσειρά επηρεάζει όλες τις [απεικόνιση και εξαγωγές](/slides/el/nodejs-java/convert-presentation/) όπου οι χαρακτήρες πρέπει να σχεδιαστούν αλλά λείπουν από τη γραμματοσειρά προέλευσης.

**Αλλάζει η ρύθμιση εναλλακτικής γραμματοσειράς το ίδιο το αρχείο παρουσίασης, και θα παραμείνει η ρύθμιση για μελλοντικά άνοιγμα;**

Όχι. Οι κανόνες εναλλακτικής γραμματοσειράς είναι ρυθμίσεις απόδοσης χρόνου εκτέλεσης στον κώδικά σας· δεν αποθηκεύονται μέσα στο .pptx και δεν εμφανίζονται στο PowerPoint.

**Επηρεάζει το λειτουργικό σύστημα (Windows/Linux/macOS) και το σύνολο των φακέλων γραμματοσειρών την επιλογή εναλλακτικής γραμματοσειράς;**

Ναι. Η μηχανή εντοπίζει τις γραμματοσειρές από τους διαθέσιμους φάκελους του συστήματος και τυχόν [πρόσθετες διαδρομές](/slides/el/nodejs-java/custom-font/) που παρέχετε. Εάν μια γραμματοσειρά δεν είναι φυσικά διαθέσιμη, ένας κανόνας που την αναφέρει δεν μπορεί να ενεργοποιηθεί.

**Λειτουργεί η εναλλακτική γραμματοσειρά για WordArt, SmartArt και διαγράμματα;**

Ναί. Όταν αυτά τα αντικείμενα περιέχουν κείμενο, η ίδια μηχανή αντικατάστασης γλύφων εφαρμόζεται για την απόδοση των ελλιπών χαρακτήρων.