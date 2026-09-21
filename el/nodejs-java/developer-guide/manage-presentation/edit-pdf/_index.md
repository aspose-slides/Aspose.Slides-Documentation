---
title: Επεξεργασία εγγράφων PDF σε JavaScript
linktitle: Επεξεργασία PDF
type: docs
weight: 65
url: /el/nodejs-java/edit-pdf/
keywords:
- επεξεργασία PDF
- αντικατάσταση κειμένου PDF
- PDF σε PPTX
- PPTX σε PDF
- Node.js
- JavaScript
- Aspose.Slides
description: "Επεξεργασία εγγράφων PDF σε JavaScript εισάγοντάς τα στο Aspose.Slides, αντικαθιστώντας το κείμενο και αποθηκεύοντας την τροποποιημένη παρουσίαση πίσω σε PDF."
---
## **Επισκόπηση**

Το Aspose.Slides για Node.js μέσω Java σάς επιτρέπει να επεξεργάζεστε το περιεχόμενο PDF εισάγοντας τις σελίδες του ως διαφάνειες, τροποποιώντας την παρουσίαση και εξάγοντας την ξανά σε PDF. Αυτό το άρθρο δείχνει μια απλή αντικατάσταση κειμένου. Η παρουσίαση παραμένει στη μνήμη, έτσι η αποθήκευση ενδιάμεσου αρχείου PPTX είναι προαιρετική.

## **Αντικατάσταση κειμένου σε PDF**

Χρησιμοποιήστε το [addFromPdf](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slidecollection/#addFromPdf) για να εισάγετε τις σελίδες, το [replaceText](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#replaceText) για να ενημερώσετε το κείμενο και το [save](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#save) για να εξαγάγετε το αποτέλεσμα.

Το παρακάτω παράδειγμα αναμένει το `input.pdf` να περιέχει τη λέξη «Draft» ως επεξεργάσιμο κείμενο μετά την εισαγωγή. Αντικαθιστά αυτή τη λέξη με «Final» και γράφει το `edited.pdf`. Η εκκαθάριση της αρχικής διαφάνειας πριν από την εισαγωγή αποτρέπει μια επιπλέον κενή σελίδα στην έξοδο. Η αναζήτηση ταιριάζει ολόκληρες λέξεις με την ίδια κεφαλοποίηση· το `null` σημαίνει ότι δεν απαιτείται κλήση επιστροφής αποτελεσμάτων.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    presentation.getSlides().removeAt(0);

    presentation.getSlides().addFromPdf("input.pdf");

    const searchOptions = new slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);
    presentation.replaceText("Draft", "Final", searchOptions, null);

    presentation.save("edited.pdf", slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

Για περισσότερες επιλογές, δείτε το [Search and Replace Text](/slides/el/nodejs-java/search-and-replace-text/) και το [Convert PowerPoint to PDF](/slides/el/nodejs-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Η αντικατάσταση κειμένου λειτουργεί σε εισαχθέν κείμενο, όχι σε κείμενο μέσα σε σαρωμένες εικόνες. Η μετατροπή μπορεί να επηρεάσει τη διάταξη και τη μορφοποίηση, επομένως ελέγξτε το αποτέλεσμα, ειδικά όταν το κείμενο αντικατάστασης είναι μεγαλύτερο από το αρχικό.
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Πρέπει να αποθηκεύσω ένα αρχείο PPTX πριν εξάγω το PDF;**

Όχι. Μπορείτε να επεξεργαστείτε και να εξάγετε την ίδια παρουσίαση στη μνήμη. Αποθηκεύστε ένα αντίγραφο PPTX μόνο εάν θέλετε επίσης να συνεχίσετε την επεξεργασία του στο PowerPoint· δείτε το [Save Presentations](/slides/el/nodejs-java/save-presentation/).

**Γιατί ορισμένο κείμενο μπορεί να παραμείνει αμετάβλητο;**

Το παράδειγμα ταιριάζει ολόκληρη τη λέξη «Draft» με ακριβή κεφαλοποίηση. Το κείμενο που εισάγεται ως εικόνα ή που είναι διασπασμένο σε ξεχωριστά πλαίσια κειμένου δεν θα ταιριάζει απαραίτητα με την αναζήτηση. Ελέγξτε το εισαχθέν περιεχόμενο και προσαρμόστε την αναζήτηση για το έγγραφό σας.