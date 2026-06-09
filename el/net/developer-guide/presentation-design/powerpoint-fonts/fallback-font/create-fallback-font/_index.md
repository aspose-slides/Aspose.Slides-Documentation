---
title: Καθορισμός Εφεδρικών Γραμματοσειρών για Παρουσιάσεις σε .NET
linktitle: Εφεδρική Γραμματοσειρά
type: docs
weight: 10
url: /el/net/create-fallback-font/
keywords:
- εφεδρική γραμματοσειρά
- κανόνας εφεδρείας
- εφαρμογή γραμματοσειράς
- αντικατάσταση γραμματοσειράς
- εύρος Unicode
- ελλειπούσα γλυφή
- σωστή γλυφή
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Καθορίστε εφεδρικές γραμματοσειρές σε αρχεία PPT, PPTX και ODP με Aspose.Slides για .NET, διασφαλίζοντας συνεπή προβολή κειμένου σε κάθε συσκευή ή λειτουργικό σύστημα."
---
## **Επισκόπηση**

Η Aspose.Slides σας επιτρέπει να καθορίσετε εφεδρικές γραμματοσειρές για την απόδοση και τις λειτουργίες εξαγωγής παρουσιάσεων. Οι εφεδρικές γραμματοσειρές χρησιμοποιούνται όταν η κύρια γραμματοσειρά δεν περιέχει γλυφές για συγκεκριμένους χαρακτήρες.

Η συμπεριφορά εφεδρείας διαμορφώνεται μέσω κανόνων εφεδρείας. Κάθε κανόνας συσχετίζει ένα εύρος Unicode με μία ή περισσότερες γραμματοσειρές που μπορεί να περιέχει τις απαιτούμενες γλυφές. Μπορείτε να ορίσετε κανόνες για διάφορα εύρη χαρακτήρων, να προσθέσετε ή να αφαιρέσετε εφεδρικές γραμματοσειρές από υπάρχοντες κανόνες και να οργανώσετε πολλαπλούς κανόνες σε μια συλλογή κανόνων εφεδρικών γραμματοσειρών.

Οι κανόνες εφεδρείας είναι ρυθμίσεις απόδοσης χρόνου εκτέλεσης. Δεν τροποποιούν το ίδιο το αρχείο παρουσίασης και δεν αποθηκεύονται μέσα στο αρχείο PPTX.

## **Κανόνες Εφεδρικών Γραμματοσειρών**

Η Aspose.Slides υποστηρίζει το interface [IFontFallBackRule](https://reference.aspose.com/slides/el/net/aspose.slides/iFontFallBackRule) και την κλάση [FontFallBackRule](https://reference.aspose.com/slides/el/net/aspose.slides/FontFallBackRule) για τον καθορισμό των κανόνων εφαρμογής εφεδρικής γραμματοσειράς. Η κλάση [FontFallBackRule](https://reference.aspose.com/slides/el/net/aspose.slides/FontFallBackRule) αντιπροσωπεύει μια συσχέτιση μεταξύ του καθορισμένου εύρους Unicode, που χρησιμοποιείται για την αναζήτηση ελλειπόντων γλυφών, και μιας λίστας γραμματοσειρών που μπορεί να περιέχει τις κατάλληλες γλυφές:

```c#
uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");


//Χρησιμοποιώντας πολλούς τρόπους μπορείτε να προσθέσετε λίστα γραμματοσειρών:
string[] fontNames = new string[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Είναι επίσης δυνατό να [Remove()](https://reference.aspose.com/slides/el/net/aspose.slides/ifontfallbackrule/methods/remove) μια εφεδρική γραμματοσειρά ή [AddFallBackFonts()](https://reference.aspose.com/slides/el/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) σε υπάρχον αντικείμενο [FontFallBackRule](https://reference.aspose.com/slides/el/net/aspose.slides/FontFallBackRule) .

[FontFallBackRulesCollection](https://reference.aspose.com/slides/el/net/aspose.slides/fontfallbackrulescollection)[ ](https://reference.aspose.com/slides/el/net/aspose.slides/fontfallbackrulescollection)μπορεί να χρησιμοποιηθεί για την οργάνωση λίστας αντικειμένων [FontFallBackRule](https://reference.aspose.com/slides/el/net/aspose.slides/FontFallBackRule) όταν υπάρχει ανάγκη να καθοριστούν κανόνες αντικατάστασης εφεδρικής γραμματοσειράς για πολλαπλά εύρη Unicode.

{{% alert color="primary" title="Δείτε επίσης" %}} 
- [Δημιουργία Συλλογής Εφεδρικών Γραμματοσειρών](/slides/el/net/create-fallback-fonts-collection/)
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ εφεδρικής γραμματοσειράς, αντικατάστασης γραμματοσειράς και ενσωμάτωσης γραμματοσειράς;**

Μία εφεδρική γραμματοσειρά χρησιμοποιείται μόνο για χαρακτήρες που λείπουν στην κύρια γραμματοσειρά. Η [Αντικατάσταση Γραμματοσειράς](/slides/el/net/font-substitution/) αντικαθιστά ολόκληρη τη καθορισμένη γραμματοσειρά με άλλη γραμματοσειρά. Η [Ενσωμάτωση Γραμματοσειράς](/slides/el/net/embedded-font/) ενσωματώνει τις γραμματοσειρές μέσα στο αρχείο εξόδου ώστε οι παραλήπτες να βλέπουν το κείμενο όπως προορίζεται.

**Εφαρμόζονται οι εφεδρικές γραμματοσειρές κατά τις εξαγωγές όπως PDF, PNG ή SVG, ή μόνο στην απόδοση στην οθόνη;**

Ναι. Η εφεδρεία επηρεάζει όλες τις [απόδοση και λειτουργίες εξαγωγής](/slides/el/net/convert-presentation/) όπου πρέπει να σχεδιαστούν χαρακτήρες αλλά λείπουν στην πηγαία γραμματοσειρά.

**Αλλάζει η ρύθμιση εφεδρείας το ίδιο το αρχείο παρουσίασης και θα παραμείνει η ρύθμιση για μελλοντικές ανοίξεις;**

Όχι. Οι κανόνες εφεδρείας είναι ρυθμίσεις απόδοσης σε χρόνο εκτέλεσης στον κώδικά σας· δεν αποθηκεύονται μέσα στο .pptx και δεν εμφανίζονται στο PowerPoint.

**Επηρεάζει το λειτουργικό σύστημα (Windows/Linux/macOS) και το σύνολο των φακέλων γραμματοσειρών την επιλογή εφεδρείας;**

Ναι. Η μηχανή επιλύει γραμματοσειρές από διαθέσιμους φακέλους του συστήματος και τυχόν [πρόσθετες διαδρομές](/slides/el/net/custom-font/) που παρέχετε. Αν μια γραμματοσειρά δεν είναι φυσικά διαθέσιμη, ένας κανόνας που την αναφέρει δεν μπορεί να ενεργοποιηθεί.

**Λειτουργεί η εφεδρεία για WordArt, SmartArt και διαγράμματα;**

Ναι. Όταν αυτά τα αντικείμενα περιέχουν κείμενο, εφαρμόζεται ο ίδιος μηχανισμός αντικατάστασης γλυφών για την απόδοση των ελλιπών χαρακτήρων.