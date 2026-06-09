---
title: Απόδοση Παρουσιάσεων με Εφεδρικές Γραμματοσειρές σε Python
linktitle: Απόδοση Παρουσιάσεων
type: docs
weight: 30
url: /el/python-net/render-presentation-with-fallback-font/
keywords:
- εφεδρική γραμματοσειρά
- απόδοση PowerPoint
- απόδοση παρουσίασης
- απόδοση διαφάνειας
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Απόδοση παρουσιάσεων με εφεδρικές γραμματοσειρές στο Aspose.Slides για Python μέσω .NET - διατήρηση του κειμένου συνεπούς σε PPT, PPTX και ODP με βήμα-προς-βήμα παραδείγματα κώδικα."
---
## **Επισκόπηση**

Το Aspose.Slides σάς επιτρέπει να αποδίδετε παρουσιάσεις χρησιμοποιώντας κανόνες εφεδρικής γραμματοσειράς. Αυτό το άρθρο δείχνει πώς να δημιουργήσετε μια συλλογή κανόνων εφεδρικής γραμματοσειράς, να τροποποιήσετε τους κανόνες αφαιρώντας ή προσθέτοντας εφεδρικές γραμματοσειρές, και να αντιστοιχίσετε τη συλλογή στην ιδιότητα `FontsManager.font_fall_back_rules_collection`.

Μόλις η συλλογή κανόνων εφεδρικής γραμματοσειράς αντιστοιχιστεί στον `fonts_manager` της παρουσίασης, οι κανόνες εφαρμόζονται κατά τη διάρκεια λειτουργιών όπως η αποθήκευση, η απόδοση και η μετατροπή της παρουσίασης. Το παράδειγμα δείχνει πώς να χρησιμοποιήσετε τους ρυθμισμένους κανόνες κατά την απόδοση μιας μικρογραφίας διαφάνειας και την αποθήκευσή της ως εικόνα PNG.

## **Απόδοση Διαφάνειας Χρησιμοποιώντας Κανόνες Εφεδρικής Γραμματοσειράς**

1. [δημιουργούμε τη συλλογή κανόνων εφεδρικής γραμματοσειράς](/slides/el/python-net/create-fallback-fonts-collection/).
2. [Καταργήστε](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontfallbackrule/remove/) έναν κανόνα εφεδρικής γραμματοσειράς και [add_fall_back_fonts](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontfallbackrule/add_fall_back_fonts/) σε άλλο κανόνα.
3. Ορίστε τη συλλογή κανόνων στην ιδιότητα [FontsManager.font_fall_back_rules_collection](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontsmanager/font_fall_back_rules_collection/).
4. Με τη μέθοδο [Presentation.save()](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) μπορούμε να αποθηκεύσουμε την παρουσίαση στην ίδια μορφή ή σε άλλη. Αφού η συλλογή κανόνων εφεδρικής γραμματοσειράς οριστεί στο FontsManager, αυτοί οι κανόνες εφαρμόζονται κατά οποιεσδήποτε λειτουργίες στην παρουσίαση: αποθήκευση, απόδοση, μετατροπή κ.λπ.

```py
import aspose.slides as slides

# Δημιουργία νέου στιγμιοτύπου συλλογής κανόνων
rulesList = slides.FontFallBackRulesCollection()

# δημιουργία κάποιων κανόνων
rulesList.add(slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"))

for fallBackRule in rulesList:
	# Προσπάθεια αφαίρεσης της εφεδρικής γραμματοσειράς "Tahoma" από τους φορτωμένους κανόνες
	fallBackRule.remove("Tahoma")

	# Και ενημέρωση των κανόνων για το συγκεκριμένο εύρος
	if fallBackRule.range_end_index >= 0x4000 and fallBackRule.range_start_index < 0x5000:
		fallBackRule.add_fall_back_fonts("Verdana")

# Μπορούμε επίσης να αφαιρέσουμε τυχόν υπάρχοντες κανόνες από τη λίστα
if len(rulesList) > 0:
	rulesList.remove(rulesList[0])

with slides.Presentation(path + "input.pptx") as pres:
	# Ανάθεση μιας προετοιμασμένης λίστας κανόνων για χρήση
	pres.fonts_manager.font_fall_back_rules_collection = rulesList

	# Απόδοση μικρογραφίας με χρήση της αρχικοποιημένης συλλογής κανόνων και αποθήκευση σε PNG
	with pres.slides[0].get_image(1, 1) as img:
		img.save("Slide_0.png", slides.ImageFormat.PNG)
```

{{% alert color="primary" %}} 
Διαβάστε περισσότερα για το πώς να [Μετατρέψετε Διαφάνειες PowerPoint σε PNG με Python](/slides/el/python-net/convert-powerpoint-to-png/).
{{% /alert %}}