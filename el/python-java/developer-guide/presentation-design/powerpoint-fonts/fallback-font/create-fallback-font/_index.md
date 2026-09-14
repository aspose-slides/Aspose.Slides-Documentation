---
title: Καθορισμός εναλλακτικών γραμματοσειρών για παρουσιάσεις σε Python μέσω Java
linktitle: Εναλλακτική Γραμματοσειρά
type: docs
weight: 10
url: /el/python-java/create-fallback-font/
keywords:
- εναλλακτική γραμματοσειρά
- κανόνας εναλλακτικής
- εφαρμογή γραμματοσειράς
- αντικατάσταση γραμματοσειράς
- περιοχή Unicode
- ελλιπής γλύφη
- σωστή γλύφη
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Αποκτήστε έλεγχο στο Aspose.Slides για Python μέσω Java για να ορίσετε εναλλακτικές γραμματοσειρές σε αρχεία PPT, PPTX και ODP, εξασφαλίζοντας συνεπή εμφάνιση κειμένου σε οποιαδήποτε συσκευή ή λειτουργικό σύστημα."
---
## **Επισκόπηση**

Aspose.Slides σας επιτρέπει να καθορίσετε εναλλακτικές (fallback) γραμματοσειρές για την απόδοση και τις εξαγωγές παρουσιάσεων. Οι εναλλακτικές γραμματοσειρές χρησιμοποιούνται όταν η κύρια γραμματοσειρά δεν περιέχει γλυφές για συγκεκριμένους χαρακτήρες.

Η συμπεριφορά εναλλακτικών γραμματοσειρών διαμορφώνεται μέσω κανόνων εναλλακτικών (fallback rules). Κάθε κανόνας συσχετίζει μια περιοχή Unicode με μία ή περισσότερες γραμματοσειρές που ενδέχεται να περιέχουν τις απαιτούμενες γλυφές. Μπορείτε να ορίσετε κανόνες για διαφορετικές περιοχές χαρακτήρων, να προσθέτετε ή να αφαιρείτε εναλλακτικές γραμματοσειρές από υπάρχοντες κανόνες και να οργανώνετε πολλαπλούς κανόνες σε μια συλλογή κανόνων εναλλακτικών γραμματοσειρών.

Οι κανόνες εναλλακτικών είναι ρυθμίσεις απόδοσης κατά το χρόνο εκτέλεσης. Δεν τροποποιούν το ίδιο το αρχείο παρουσίασης και δεν αποθηκεύονται μέσα στο αρχείο PPTX.

## **Κανόνες Εναλλακτικών Γραμματοσειρών**

Aspose.Slides παρέχει την κλάση [FontFallBackRule](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontfallbackrule/) για τον καθορισμό κανόνων εφαρμογής εναλλακτικών γραμματοσειρών. Αυτή η κλάση αντιπροσωπεύει μια συσχέτιση μεταξύ μιας περιοχής Unicode που χρησιμοποιείται για την αναζήτηση ελλιπών γλυφών και μιας λίστας γραμματοσειρών που ενδέχεται να περιέχουν τις απαιτούμενες γλυφές:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule

start_unicode_index = 0x0B80
end_unicode_index = 0x0BFF

first_rule = FontFallBackRule(start_unicode_index, end_unicode_index, "Vijaya")
second_rule = FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

# Χρησιμοποιήστε πολλαπλούς τρόπους για να καθορίσετε μια λίστα γραμματοσειρών.
font_names = jpype.JArray(jpype.JString)(["Segoe UI Emoji, Segoe UI Symbol", "Arial"])

third_rule = FontFallBackRule(0x1F300, 0x1F64F, font_names)
```

Μπορείτε επίσης να αφαιρέσετε μια εναλλακτική γραμματοσειρά χρησιμοποιώντας [remove](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontfallbackrule/#remove) ή να προσθέσετε εναλλακτικές γραμματοσειρές με [addFallBackFonts](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontfallbackrule/#addFallBackFonts) σε ένα υπάρχον αντικείμενο [FontFallBackRule](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontfallbackrule/).

[FontFallBackRulesCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontfallbackrulescollection/) μπορεί να οργανώσει μια λίστα αντικειμένων [FontFallBackRule](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontfallbackrule/) όταν χρειάζεται να καθορίσετε κανόνες αντικατάστασης εναλλακτικών γραμματοσειρών για πολλαπλές περιοχές Unicode.

{{% alert color="info" title="Δείτε επίσης" %}} 
- [Δημιουργία Συλλογής Εναλλακτικών Γραμματοσειρών](/slides/el/python-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ εναλλακτικής γραμματοσειράς, αντικατάστασης γραμματοσειράς και ενσωμάτωσης γραμματοσειράς;**

Μια εναλλακτική γραμματοσειρά χρησιμοποιείται μόνο για χαρακτήρες που λείπουν στην κύρια γραμματοσειρά. Η [Font substitution](/slides/el/python-java/font-substitution/) αντικαθιστά ολόκληρη τη συγκεκριμένη γραμματοσειρά με άλλη. Η [Font embedding](/slides/el/python-java/embedded-font/) ενσωματώνει τις γραμματοσειρές μέσα στο αρχείο εξόδου ώστε οι παραλήπτες να μπορούν να δουν το κείμενο όπως προορίζεται.

**Εφαρμόζονται οι εναλλακτικές γραμματοσειρές κατά τις εξαγωγές όπως PDF, PNG ή SVG, ή μόνο στην απόδοση στην οθόνη;**

Ναι. Οι εναλλακτικές επηρεάζουν όλες τις [rendering and export operations](/slides/el/python-java/convert-presentation/) όπου πρέπει να σχεδιαστούν χαρακτήρες που λείπουν στην πηγαία γραμματοσειρά.

**Αλλάζει η διαμόρφωση εναλλακτικών το αρχείο παρουσίασης και θα παραμείνει η ρύθμιση για μελλοντικά ανοίγματα;**

Όχι. Οι κανόνες εναλλακτικών είναι ρυθμίσεις απόδοσης κατά το χρόνο εκτέλεσης στον κώδικά σας· δεν αποθηκεύονται μέσα στο .pptx και δεν εμφανίζονται στο PowerPoint.

**Επηρεάζει η λειτουργική συσκευή (Windows/Linux/macOS) και το σύνολο των φακέλων γραμματοσειρών την επιλογή εναλλακτικών;**

Ναι. Η μηχανή εντοπίζει γραμματοσειρές από τους διαθέσιμους φακέλους του συστήματος και από τυχόν [additional paths](/slides/el/python-java/custom-font/) που παρέχετε. Εάν μια γραμματοσειρά δεν είναι φυσικά διαθέσιμη, ένας κανόνας που την αναφέρει δεν μπορεί να εφαρμοστεί.

**Λειτουργούν οι εναλλακτικές για WordArt, SmartArt και διαγράμματα;**

Ναι. Όταν αυτά τα αντικείμενα περιέχουν κείμενο, εφαρμόζεται ο ίδιος μηχανισμός αντικατάστασης γλυφών για την απόδοση των ελλιπών χαρακτήρων.