---
title: Ορισμός Εναλλακτικών Γραμματοσειρών για Παρουσιάσεις σε C++
linktitle: Εναλλακτική Γραμματοσειρά
type: docs
weight: 10
url: /el/cpp/create-fallback-font/
keywords:
- εναλλακτική γραμματοσειρά
- κανόνας εναλλακτικής
- εφαρμογή γραμματοσειράς
- αντικατάσταση γραμματοσειράς
- περιοχή Unicode
- ελλιπής γλύφος
- σωστός γλύφος
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Κατακτήστε το Aspose.Slides για C++ ώστε να ορίσετε εναλλακτικές γραμματοσειρές σε αρχεία PPT, PPTX και ODP, διασφαλίζοντας συνεπή εμφάνιση κειμένου σε οποιαδήποτε συσκευή ή λειτουργικό σύστημα."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει να καθορίζετε εναλλακτικές γραμματοσειρές για την απόδοση και τις εξαγωγές παρουσιάσεων. Οι εναλλακτικές γραμματοσειρές χρησιμοποιούνται όταν η κύρια γραμματοσειρά δεν περιέχει γλύφους για συγκεκριμένους χαρακτήρες.

Η συμπεριφορά εναλλακτικής γραμματοσειράς διαμορφώνεται μέσω κανόνων εναλλακτικής γραμματοσειράς. Κάθε κανόνας συσχετίζει μια περιοχή Unicode με μία ή περισσότερες γραμματοσειρές που μπορεί να περιέχουν τους απαιτούμενους γλύφους. Μπορείτε να ορίσετε κανόνες για διαφορετικές περιοχές χαρακτήρων, να προσθέσετε ή να αφαιρέσετε εναλλακτικές γραμματοσειρές από υπάρχοντες κανόνους και να οργανώσετε πολλαπλούς κανόνες σε μια συλλογή κανόνων εναλλακτικών γραμματοσειρών.

Οι κανόνες εναλλακτικής γραμματοσειράς είναι ρυθμίσεις απόδοσης χρόνου εκτέλεσης. Δεν τροποποιούν το αρχείο παρουσίασης και δεν αποθηκεύονται μέσα στο αρχείο PPTX.

## **Κανόνες Εναλλακτικής Γραμματοσειράς**

Το Aspose.Slides υποστηρίζει τη διεπαφή [IFontFallBackRule](https://reference.aspose.com/slides/el/cpp/aspose.slides/ifontfallbackrule/) και την κλάση [FontFallBackRule](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontfallbackrule/) για τον καθορισμό των κανόνων εφαρμογής μιας εναλλακτικής γραμματοσειράς. Η κλάση [FontFallBackRule](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontfallbackrule/) αντιπροσωπεύει μια συσχέτιση μεταξύ της καθορισμένης περιοχής Unicode, η οποία χρησιμοποιείται για την αναζήτηση εσφαλμένων γλύφων, και μιας λίστας γραμματοσειρών που ενδέχεται να περιέχουν τους σωστούς γλύφους:

``` cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Χρησιμοποιώντας πολλαπλούς τρόπους μπορείτε να προσθέσετε λίστα γραμματοσειρών:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```

Επίσης είναι δυνατό να [Remove()](https://reference.aspose.com/slides/el/cpp/aspose.slides/ifontfallbackrule/remove/) μια εναλλακτική γραμματοσειρά ή να [AddFallBackFonts()](https://reference.aspose.com/slides/el/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) σε ένα υπάρχον αντικείμενο [FontFallBackRule](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontfallbackrule/). Η [FontFallBackRulesCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontfallbackrulescollection/) μπορεί να χρησιμοποιηθεί για την οργάνωση λίστας αντικειμένων [FontFallBackRule](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontfallbackrule/), όταν υπάρχει ανάγκη να καθοριστούν κανόνες αντικατάστασης εναλλακτικών γραμματοσειρών για πολλαπλές περιοχές Unicode.

{{% alert color="primary" title="Δείτε επίσης" %}} 
- [Δημιουργία Συλλογής Εναλλακτικών Γραμματοσειρών](/slides/el/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ μιας εναλλακτικής γραμματοσειράς, της αντικατάστασης γραμματοσειράς και της ενσωμάτωσης γραμματοσειράς;**

Μια εναλλακτική γραμματοσειρά χρησιμοποιείται μόνο για χαρακτήρες που λείπουν στην κύρια γραμματοσειρά. Η [Font substitution](/slides/el/cpp/font-substitution/) αντικαθιστά ολόκληρη τη συγκεκριμένη γραμματοσειρά με άλλη γραμματοσειρά. Η [Font embedding](/slides/el/cpp/embedded-font/) ενσωματώνει τις γραμματοσειρές μέσα στο αρχείο εξόδου ώστε οι παραλήπτες να μπορούν να δουν το κείμενο όπως προοριζόταν.

**Εφαρμόζονται οι εναλλακτικές γραμματοσειρές κατά τις εξαγωγές όπως PDF, PNG ή SVG, ή μόνο στην απόδοση στην οθόνη;**

Ναι. Η εναλλακτική γραμματοσειρά επηρεάζει όλες τις [rendering and export operations](/slides/el/cpp/convert-presentation/) όπου οι χαρακτήρες πρέπει να σχεδιαστούν αλλά λείπουν από τη γραμματοσειρά προέλευσης.

**Αλλάζει η διαμόρφωση της εναλλακτικής γραμματοσειράς το ίδιο το αρχείο παρουσίασης και θα παραμείνει η ρύθμιση για μελλοντικά ανοίγματα;**

Όχι. Οι κανόνες εναλλακτικής γραμματοσειράς είναι ρυθμίσεις απόδοσης χρόνου εκτέλεσης στον κώδικά σας· δεν αποθηκεύονται μέσα στο .pptx και δεν εμφανίζονται στο PowerPoint.

**Επηρεάζουν το λειτουργικό σύστημα (Windows/Linux/macOS) και το σύνολο των φακέλων γραμματοσειρών την επιλογή εναλλακτικής γραμματοσειράς;**

Ναι. Η μηχανή εντοπίζει γραμματοσειρές από τους διαθέσιμους φακέλους του συστήματος και τυχόν [additional paths](/slides/el/cpp/custom-font/) που παρέχετε. Εάν μια γραμματοσειρά δεν είναι φυσικά διαθέσιμη, ένας κανόνας που την αναφέρει δεν μπορεί να εφαρμοστεί.

**Λειτουργεί η εναλλακτική γραμματοσειρά για WordArt, SmartArt και διαγράμματα;**

Ναι. Όταν αυτά τα αντικείμενα περιέχουν κείμενο, ο ίδιος μηχανισμός αντικατάστασης γλύφων εφαρμόζεται για την απόδοση των ελλειπούσων χαρακτήρων.