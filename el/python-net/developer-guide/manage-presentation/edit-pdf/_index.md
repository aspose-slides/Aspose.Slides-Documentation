---
title: Επεξεργασία εγγράφων PDF σε Python
linktitle: Επεξεργασία PDF
type: docs
weight: 65
url: /el/python-net/edit-pdf/
keywords:
- επεξεργασία PDF
- αντικατάσταση κειμένου PDF
- PDF σε PPTX
- PPTX σε PDF
- Python
- Aspose.Slides
description: "Επεξεργαστείτε έγγραφα PDF σε Python εισάγοντάς τα στο Aspose.Slides, αντικαθιστώντας το κείμενο και αποθηκεύοντας την τροποποιημένη παρουσίαση ξανά σε PDF."
---
## **Επισκόπηση**

Το Aspose.Slides for Python μέσω .NET σάς επιτρέπει να επεξεργαστείτε το περιεχόμενο PDF εισάγοντας τις σελίδες του ως διαφάνειες, τροποποιώντας την παρουσίαση και εξάγόντά την ξανά σε PDF. Αυτό το άρθρο δείχνει μια απλή αντικατάσταση κειμένου. Η παρουσίαση παραμένει στη μνήμη, έτσι η αποθήκευση ενδιάμεσου αρχείου PPTX είναι προαιρετική.

## **Αντικατάσταση Κειμένου σε PDF**

Χρησιμοποιήστε [add_from_pdf](https://reference.aspose.com/slides/el/python-net/aspose.slides/slidecollection/add_from_pdf/) για να εισάγετε τις σελίδες, [replace_text](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/replace_text/) για να ενημερώσετε το κείμενο και [save](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/save/) για να εξάγετε το αποτέλεσμα.

Το παρακάτω παράδειγμα υποθέτει ότι το `input.pdf` περιέχει τη λέξη «Draft» ως επεξεργάσιμο κείμενο μετά την εισαγωγή. Αντικαθιστά αυτή τη λέξη με «Final» και γράφει το `edited.pdf`. Η εκκαθάριση της αρχικής διαφάνειας πριν την εισαγωγή αποτρέπει μια επιπλέον κενή σελίδα στο αποτέλεσμα. Η αναζήτηση ταιριάζει με ολόκληρες λέξεις με την ίδια διάκριση πεζών‑κεφαλαίων· `None` σημαίνει ότι δεν απαιτείται κλήση επιστροφής αποτελέσματος.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    presentation.slides.add_from_pdf("input.pdf")

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = True
    presentation.replace_text("Draft", "Final", search_options, None)

    presentation.save("edited.pdf", slides.export.SaveFormat.PDF)
```

Για περισσότερες επιλογές, δείτε [Αναζήτηση και Αντικατάσταση Κειμένου](/slides/el/python-net/search-and-replace-text/) και [Μετατροπή PowerPoint σε PDF](/slides/el/python-net/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Σημείωση" %}}

Η αντικατάσταση κειμένου λειτουργεί στο εισαχθέν κείμενο, όχι σε κείμενο μέσα σε σαρωμένες εικόνες. Η μετατροπή μπορεί να επηρεάσει τη διάταξη και τη μορφοποίηση, επομένως εξετάστε το αποτέλεσμα, ιδιαίτερα όταν το κείμενο αντικατάστασης είναι μεγαλύτερο από το αρχικό.

{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Χρειάζεται να αποθηκεύσω ένα αρχείο PPTX πριν εξάγω το PDF;**

Όχι. Μπορείτε να επεξεργαστείτε και να εξάγετε την ίδια παρουσίαση στη μνήμη. Αποθηκεύστε ένα αντίγραφο PPTX μόνο εάν θέλετε επίσης να συνεχίσετε την επεξεργασία του στο PowerPoint· δείτε [Αποθήκευση Παρουσιάσεων](/slides/el/python-net/save-presentation/).

**Γιατί ορισμένο κείμενο μπορεί να παραμείνει αμετάβλητο;**

Το παράδειγμα ταιριάζει με ολόκληρη τη λέξη «Draft» με ακριβή διάκριση πεζών‑κεφαλαίων. Το κείμενο που εισάγεται ως εικόνα ή διασπάται σε ξεχωριστά πλαίσια κειμένου δεν θα ταιριάζει απαραίτητα με την αναζήτηση. Ελέγξτε το εισαχθέν περιεχόμενο και προσαρμόστε την αναζήτηση για το έγγραφό σας.