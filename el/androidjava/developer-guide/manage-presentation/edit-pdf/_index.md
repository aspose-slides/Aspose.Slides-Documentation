---
title: Επεξεργασία εγγράφων PDF σε Android
linktitle: Επεξεργασία PDF
type: docs
weight: 65
url: /el/androidjava/edit-pdf/
keywords:
- επεξεργασία PDF
- αντικατάσταση κειμένου PDF
- PDF σε PPTX
- PPTX σε PDF
- Android
- Java
- Aspose.Slides
description: "Επεξεργαστείτε έγγραφα PDF σε Android με Java, εισάγοντάς τα στο Aspose.Slides, αντικαθιστώντας κείμενο και αποθηκεύοντας την τροποποιημένη παρουσίαση ξανά σε PDF."
---
## **Επισκόπηση**

Το Aspose.Slides for Android μέσω Java σάς επιτρέπει να επεξεργάζεστε περιεχόμενο PDF εισάγοντας τις σελίδες του ως διαφάνειες, τροποποιώντας την παρουσίαση και εξάγοντας την ξανά σε PDF. Αυτό το άρθρο δείχνει μια απλή αντικατάσταση κειμένου. Η παρουσίαση παραμένει στη μνήμη, οπότε η αποθήκευση ενός ενδιάμεσου αρχείου PPTX είναι προαιρετική.

## **Αντικατάσταση κειμένου σε PDF**

Χρησιμοποιήστε [addFromPdf](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) για να εισάγετε τις σελίδες, [replaceText](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) για να ενημερώσετε το κείμενο και [save](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) για να εξάγετε το αποτέλεσμα.

Το παρακάτω παράδειγμα υποθέτει ότι το `input.pdf` περιέχει τη λέξη “Draft” ως επεξεργάσιμο κείμενο μετά την εισαγωγή. Αντικαθιστά αυτή τη λέξη με “Final” και γράφει το `edited.pdf`. Η εκκαθάριση της αρχικής διαφάνειας πριν την εισαγωγή αποτρέπει την εμφάνιση μιας επιπλέον κενής σελίδας στο αποτέλεσμα. Η αναζήτηση ταιριάζει με ολόκληρες λέξεις με την ίδια διάκριση πεζών‑κεφαλαίων· το `null` σημαίνει ότι δεν απαιτείται κλήση επιστροφής αποτελεσμάτων.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.TextSearchOptions;

Presentation presentation = new Presentation();
try {
    presentation.getSlides().removeAt(0);

    presentation.getSlides().addFromPdf("input.pdf");

    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);
    presentation.replaceText("Draft", "Final", searchOptions, null);

    presentation.save("edited.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

Για περισσότερες επιλογές, δείτε [Αναζήτηση και Αντικατάσταση Κειμένου](/slides/el/androidjava/search-and-replace-text/) και [Μετατροπή PowerPoint σε PDF](/slides/el/androidjava/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Η αντικατάσταση κειμένου λειτουργεί στο εισαγόμενο κείμενο, όχι σε κείμενο μέσα σε σαρωμένες εικόνες. Η μετατροπή μπορεί να επηρεάσει τη διάταξη και τη μορφοποίηση, οπότε εξετάστε το αποτέλεσμα, ιδιαίτερα όταν το κείμενο αντικατάστασης είναι μεγαλύτερο από το αρχικό.
{{% /alert %}}

## **Συχνές ερωτήσεις**

**Πρέπει να αποθηκεύσω ένα αρχείο PPTX πριν εξάγω το PDF;**

Όχι. Μπορείτε να επεξεργαστείτε και να εξάγετε την ίδια παρουσίαση στη μνήμη. Αποθηκεύστε ένα αντίγραφο PPTX μόνο εάν θέλετε επίσης να συνεχίσετε την επεξεργασία του στο PowerPoint· δείτε [Αποθήκευση Παρουσιάσεων](/slides/el/androidjava/save-presentation/).

**Γιατί μπορεί κάποιο κείμενο να παραμείνει αμετάβλητο;**

Το παράδειγμα ταιριάζει με ολόκληρη τη λέξη “Draft” με ακριβή διάκριση πεζών‑κεφαλαίων. Το κείμενο που εισάγεται ως εικόνα ή που είναι διασπασμένο σε ξεχωριστά πλαίσια κειμένου δεν θα ταιριάζει απαραίτητα με την αναζήτηση. Ελέγξτε το εισαγόμενο περιεχόμενο και προσαρμόστε την αναζήτηση για το έγγραφό σας.