---
title: Ορισμός εναλλακτικών γραμματοσειρών για παρουσιάσεις σε .NET
linktitle: Εναλλακτική γραμματοσειρά
type: docs
weight: 10
url: /el/net/create-fallback-font/
keywords:
- εναλλακτική γραμματοσειρά
- κανόνας εναλλακτικής γραμματοσειράς
- εφαρμογή γραμματοσειράς
- αντικατάσταση γραμματοσειράς
- περιοχή Unicode
- χαμένος γλύφος
- σωστός γλύφος
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Εκμεταλλευτείτε το Aspose.Slides για .NET ώστε να ορίσετε εναλλακτικές γραμματοσειρές σε αρχεία PPT, PPTX και ODP, διασφαλίζοντας συνεπή εμφάνιση κειμένου σε οποιαδήποτε συσκευή ή λειτουργικό σύστημα."
---
## **Επισκόπηση**

Aspose.Slides σας επιτρέπει να καθορίζετε εναλλακτικές γραμματοσειρές για την απόδοση και τις εξαγωγές παρουσιάσεων. Οι εναλλακτικές γραμματοσειρές χρησιμοποιούνται όταν η κύρια γραμματοσειρά δεν περιέχει γλύφους για συγκεκριμένους χαρακτήρες.

Η συμπεριφορά εναλλακτικών γραμματοσειρών ρυθμίζεται μέσω κανόνων εναλλακτικής γραμματοσειράς. Κάθε κανόνας συνδέει μια περιοχή Unicode με μία ή περισσότερες γραμματοσειρές που μπορεί να περιέχουν τους απαιτούμενους γλύφους. Μπορείτε να ορίσετε κανόνες για διαφορετικές περιοχές χαρακτήρων, να προσθέσετε ή να αφαιρέσετε εναλλακτικές γραμματοσειρές από υπάρχοντες κανόνες και να οργανώσετε πολλαπλούς κανόνες σε μια συλλογή κανόνων εναλλακτικής γραμματοσειράς.

Οι κανόνες εναλλακτικής γραμματοσειράς είναι ρυθμίσεις απόδοσης κατά την εκτέλεση. Δεν τροποποιούν το αρχείο παρουσίασης αυτό καθαυτό και δεν αποθηκεύονται μέσα στο αρχείο PPTX.

## **Κανόνες Αντικατάστασης Γραμματοσειράς**

Το Aspose.Slides υποστηρίζει τη διεπαφή [IFontFallBackRule](https://reference.aspose.com/slides/el/net/aspose.slides/iFontFallBackRule) και την κλάση [FontFallBackRule](https://reference.aspose.com/slides/el/net/aspose.slides/FontFallBackRule) για να καθορίσετε τους κανόνες εφαρμογής μιας εναλλακτικής γραμματοσειράς. Η κλάση [FontFallBackRule](https://reference.aspose.com/slides/el/net/aspose.slides/FontFallBackRule) αντιπροσωπεύει μια συσχέτιση μεταξύ της καθορισμένης περιοχής Unicode, που χρησιμοποιείται για την αναζήτηση χαμένων γλύφων, και μιας λίστας γραμματοσειρών που μπορεί να περιέχει τους κατάλληλους γλύφους:

```c#
using Aspose.Slides;

uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Χρησιμοποιώντας πολλαπλούς τρόπους μπορείτε να προσθέσετε λίστα γραμματοσειρών:
string[] fontNames = new string[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Επίσης είναι δυνατό να [Remove()](https://reference.aspose.com/slides/el/net/aspose.slides/ifontfallbackrule/methods/remove) εναλλακτική γραμματοσειρά ή να [AddFallBackFonts()](https://reference.aspose.com/slides/el/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) σε υπάρχον αντικείμενο [FontFallBackRule](https://reference.aspose.com/slides/el/net/aspose.slides/FontFallBackRule).

[FontFallBackRulesCollection](https://reference.aspose.com/slides/el/net/aspose.slides/fontfallbackrulescollection)[ ](https://reference.aspose.com/slides/el/net/aspose.slides/fontfallbackrulescollection) μπορεί να χρησιμοποιηθεί για την οργάνωση λίστας αντικειμένων [FontFallBackRule](https://reference.aspose.com/slides/el/net/aspose.slides/FontFallBackRule), όταν υπάρχει ανάγκη να καθοριστούν κανόνες αντικατάστασης εναλλακτικής γραμματοσειράς για πολλαπλές περιοχές Unicode.

{{% alert color="info" title="Δείτε επίσης" %}} 
- [Δημιουργία Συλλογής Εναλλακτικών Γραμματοσειρών](/slides/el/net/create-fallback-fonts-collection/)
{{% /alert %}}

## **Συχνές Ερωτήσεις**

### Ποια είναι η διαφορά μεταξύ εναλλακτικής γραμματοσειράς, αντικατάστασης γραμματοσειράς και ενσωμάτωσης γραμματοσειράς;

Μια εναλλακτική γραμματοσειρά χρησιμοποιείται μόνο για χαρακτήρες που λείπουν στην κύρια γραμματοσειρά. Η [Font substitution](/slides/el/net/font-substitution/) αντικαθιστά ολόκληρη τη καθορισμένη γραμματοσειρά με μια άλλη. Η [Font embedding](/slides/el/net/embedded-font/) ενσωματώνει τις γραμματοσειρές μέσα στο αρχείο εξόδου ώστε οι παραλήπτες να μπορούν να δουν το κείμενο όπως προορίζεται.

### Εφαρμόζονται οι εναλλακτικές γραμματοσειρές κατά τις εξαγωγές όπως PDF, PNG ή SVG, ή μόνο κατά την απόδοση στην οθόνη;

Ναι. Η εναλλακτική γραμματοσειρά επηρεάζει όλες τις [rendering and export operations](/slides/el/net/convert-presentation/) όπου πρέπει να σχεδιαστούν χαρακτήρες που λείπουν από τη γραμματοσειρά προέλευσης.

### Αλλάζει η ρύθμιση εναλλακτικής γραμματοσειράς το ίδιο το αρχείο παρουσίασης και θα παραμείνει η ρύθμιση για μελλοντικά άνοιγμα;

Όχι. Οι κανόνες εναλλακτικής γραμματοσειράς είναι ρυθμίσεις απόδοσης κατά την εκτέλεση στον κώδικά σας· δεν αποθηκεύονται μέσα στο .pptx και δεν θα εμφανιστούν στο PowerPoint.

### Επηρεάζει το λειτουργικό σύστημα (Windows/Linux/macOS) και το σύνολο των φακέλων γραμματοσειρών την επιλογή εναλλακτικής γραμματοσειράς;

Ναι. Η μηχανή εντοπίζει τις γραμματοσειρές από τους διαθέσιμους φακέλους του συστήματος και από οποιεσδήποτε [additional paths](/slides/el/net/custom-font/) παρέχετε. Εάν μια γραμματοσειρά δεν είναι φυσικά διαθέσιμη, ένας κανόνας που την αναφέρει δεν μπορεί να εφαρμοστεί.

### Λειτουργεί η εναλλακτική γραμματοσειρά για WordArt, SmartArt και διαγράμματα;

Ναι. Όταν αυτά τα αντικείμενα περιέχουν κείμενο, εφαρμόζεται ο ίδιος μηχανισμός αντικατάστασης γλύφων για την απόδοση των ελλιπών χαρακτήρων.