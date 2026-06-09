---
title: Καθορίστε Εναλλακτικές Γραμματοσειρές για Παρουσιάσεις σε C++
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
description: "Αποκτήστε τον έλεγχο του Aspose.Slides για C++ ώστε να ορίζετε εναλλακτικές γραμματοσειρές σε αρχεία PPT, PPTX και ODP, διασφαλίζοντας συνεπή προβολή κειμένου σε οποιαδήποτε συσκευή ή λειτουργικό σύστημα."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει να καθορίσετε εναλλακτικές γραμματοσειρές για τη σωστή απόδοση και τις εξαγωγές παρουσίασης. Οι εναλλακτικές γραμματοσειρές χρησιμοποιούνται όταν η κύρια γραμματοσειρά δεν περιέχει γλύφους για συγκεκριμένους χαρακτήρες.

Η συμπεριφορά εναλλακτικής ρυθμίζεται μέσω κανόνων εναλλακτικής. Κάθε κανόνας συνδέει μια περιοχή Unicode με μία ή περισσότερες γραμματοσειρές που μπορεί να περιέχουν τους απαιτούμενους γλύφους. Μπορείτε να ορίσετε κανόνες για διαφορετικές περιοχές χαρακτήρων, να προσθέσετε ή να αφαιρέσετε εναλλακτικές γραμματοσειρές από υπάρχοντες κανόνες, και να οργανώσετε πολλαπλούς κανόνες σε μια συλλογή κανόνων εναλλακτικών γραμματοσειρών.

Οι κανόνες εναλλακτικής είναι ρυθμίσεις απόδοσης χρόνου εκτέλεσης. Δεν τροποποιούν το αρχείο της παρουσίασης και δεν αποθηκεύονται μέσα στο αρχείο PPTX.

## **Κανόνες εναλλακτικής**

Το Aspose.Slides υποστηρίζει τη διεπαφή [IFontFallBackRule](https://reference.aspose.com/slides/el/cpp/aspose.slides/ifontfallbackrule/) και την κλάση [FontFallBackRule](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontfallbackrule/) για τον καθορισμό των κανόνων εφαρμογής εναλλακτικής γραμματοσειράς. Η κλάση [FontFallBackRule](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontfallbackrule/) αντιπροσωπεύει μια σύζευξη μεταξύ της καθορισμένης περιοχής Unicode, που χρησιμοποιείται για την αναζήτηση των ελλειπών γλύφων, και μιας λίστας γραμματοσειρών που μπορεί να περιέχουν τους σωστούς γλύφους:

``` cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Χρησιμοποιώντας πολλαπλούς τρόπους μπορείτε να προσθέσετε λίστα γραμματοσειρών:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```

Είναι επίσης δυνατό να [Remove()](https://reference.aspose.com/slides/el/cpp/aspose.slides/ifontfallbackrule/remove/) μια εναλλακτική γραμματοσειρά ή να [AddFallBackFonts()](https://reference.aspose.com/slides/el/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) σε υπάρχουσα αντικείμενο [FontFallBackRule](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontfallbackrule/) object.

Η [FontFallBackRulesCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontfallbackrulescollection/) μπορεί να χρησιμοποιηθεί για την οργάνωση λίστας αντικειμένων [FontFallBackRule](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontfallbackrule/) όταν υπάρχει ανάγκη καθορισμού κανόνων αντικατάστασης εναλλακτικών γραμματοσειρών για πολλαπλές περιοχές Unicode.

{{% alert color="primary" title="See also" %}} 
- [Δημιουργία Συλλογής Εναλλακτικών Γραμματοσειρών](/slides/el/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ εναλλακτικής γραμματοσειράς, υποκατάστασης γραμματοσειράς και ενσωμάτωσης γραμματοσειράς;**

Μία εναλλακτική γραμματοσειρά χρησιμοποιείται μόνο για χαρακτήρες που λείπουν στην κύρια γραμματοσειρά. Η [Font substitution](/slides/el/cpp/font-substitution/) αντικαθιστά ολόκληρη τη συγκεκριμένη γραμματοσειρά με άλλη γραμματοσειρά. Η [Font embedding](/slides/el/cpp/embedded-font/) ενσωματώνει τις γραμματοσειρές μέσα στο αρχείο εξόδου ώστε οι παραλήπτες να μπορούν να δουν το κείμενο όπως προοριζόταν.

**Εφαρμόζονται οι εναλλακτικές γραμματοσειρές κατά τις εξαγωγές όπως PDF, PNG ή SVG, ή μόνο στην απόδοση στην οθόνη;**

Ναι. Η εναλλακτική επηρεάζει όλες τις [rendering and export operations](/slides/el/cpp/convert-presentation/) όπου οι χαρακτήρες πρέπει να σχεδιαστούν αλλά λείπουν από τη γραμματοσειρά προέλευσης.

**Αλλάζει η διαμόρφωση της εναλλακτικής το ίδιο το αρχείο παρουσίασης και θα παραμείνει η ρύθμιση για μελλοντικές ανοιγές;**

Όχι. Οι κανόνες εναλλακτικής είναι ρυθμίσεις απόδοσης χρόνου εκτέλεσης στον κώδικά σας· δεν αποθηκεύονται μέσα στο .pptx και δεν θα εμφανιστούν στο PowerPoint.

**Επηρεάζει το λειτουργικό σύστημα (Windows/Linux/macOS) και το σύνολο των καταλόγων γραμματοσειρών την επιλογή εναλλακτικής;**

Ναι. Η μηχανή εντοπίζει γραμματοσειρές από τους διαθέσιμους φακέλους του συστήματος και τυχόν [additional paths](/slides/el/cpp/custom-font/) που παρέχετε. Αν μια γραμματοσειρά δεν είναι φυσικά διαθέσιμη, ένας κανόνας που την αναφέρει δεν μπορεί να ισχύσει.

**Λειτουργεί η εναλλακτική για WordArt, SmartArt και διαγράμματα;**

Ναι. Όταν αυτά τα αντικείμενα περιέχουν κείμενο, ισχύει ο ίδιος μηχανισμός αντικατάστασης γλύφων για την απόδοση των ελλειπών χαρακτήρων.