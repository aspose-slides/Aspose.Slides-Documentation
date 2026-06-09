---
title: Αυτοματοποίηση της τοπικοποίησης παρουσίασης με Python
linktitle: Τοπικοποίηση παρουσίασης
type: docs
weight: 100
url: /el/python-net/presentation-localization/
keywords:
- αλλαγή γλώσσας
- ορθογραφικός έλεγχος
- αναγνωριστικό γλώσσας
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Αυτοματοποιήστε την τοπικοποίηση διαφανειών PowerPoint και OpenDocument σε Python με το Aspose.Slides, χρησιμοποιώντας πρακτικά παραδείγματα κώδικα και συμβουλές για ταχύτερη παγκόσμια κυκλοφορία."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να ορίσετε το `language_id` για κείμενο σε μια παρουσίαση χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να ανοίξετε μια παρουσίαση, να προσθέσετε ένα σχήμα με κείμενο, να εκχωρήσετε έναν αναγνωριστικό γλώσσας σε ένα τμήμα κειμένου και να αποθηκεύσετε το αποτέλεσμα ως αρχείο PPTX.

## **Αλλαγή γλώσσας για την παρουσίαση και το κείμενο του σχήματος**
- Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/)
- Λάβετε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της
- Προσθέστε ένα AutoShape τύπου Rectangle στη διαφάνεια
- Προσθέστε κάποιο κείμενο στο TextFrame
- Ορισμός Language Id στο κείμενο
- Γράψτε την παρουσίαση ως αρχείο PPTX

Η υλοποίηση των παραπάνω βημάτων παρουσιάζεται παρακάτω σε ένα παράδειγμα.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)
    shape.add_text_frame("Text to apply spellcheck language")
    shape.text_frame.paragraphs[0].portions[0].portion_format.language_id = "en-EN"

    pres.save("test1.pptx", slides.export.SaveFormat.PPTX)
```

## **Συχνές ερωτήσεις**

**Ενεργοποιεί το language ID την αυτόματη μετάφραση κειμένου;**

Όχι. Το [language_id](https://reference.aspose.com/slides/el/python-net/aspose.slides/portionformat/language_id/) στο Aspose.Slides αποθηκεύει τη γλώσσα για ορθογραφικό και γραμματικό έλεγχο, αλλά δεν μεταφράζει ή αλλάζει το περιεχόμενο του κειμένου. Είναι μεταδεδομένα που κατανοεί το PowerPoint για έλεγχο.

**Επηρεάζει το language ID την συλλαβοποίηση και τις αλλαγές γραμμής κατά την απόδοση;**

Στο Aspose.Slides, το [language_id](https://reference.aspose.com/slides/el/python-net/aspose.slides/portionformat/language_id/) χρησιμοποιείται για έλεγχο. Η ποιότητα της συλλαβοποίησης και η αναδίπλωση γραμμών εξαρτώνται κυρίως από τη διαθεσιμότητα των [σωστών γραμματοσειρών](/slides/el/python-net/powerpoint-fonts/) και τις ρυθμίσεις διάταξης/αλλαγής γραμμής για το σύστημα γραφής. Για σωστή απόδοση, βεβαιωθείτε ότι οι απαιτούμενες γραμματοσειρές είναι διαθέσιμες, διαμορφώστε τους [κανόνες αντικατάστασης γραμματοσειρών](/slides/el/python-net/font-substitution/) και/ή [ενσωματώστε γραμματοσειρές](/slides/el/python-net/embedded-font/) στην παρουσίαση.

**Μπορώ να ορίσω διαφορετικές γλώσσες σε μία μόνο παράγραφο;**

Ναι. Το [language_id](https://reference.aspose.com/slides/el/python-net/aspose.slides/portionformat/language_id/) εφαρμόζεται σε επίπεδο τμήματος κειμένου, έτσι ώστε μια μόνο παράγραφος να μπορεί να αναμειγνύει πολλαπλές γλώσσες με διαφορετικές ρυθμίσεις ελέγχου.