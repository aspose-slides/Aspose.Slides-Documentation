---
title: Διαχείριση Κεφαλίδων και Υποσέλιδων Παρουσίασης σε Java
linktitle: Κεφαλίδα και Υποσέλιδο
type: docs
weight: 140
url: /el/java/presentation-header-and-footer/
keywords:
- κεφαλίδα
- κείμενο κεφαλίδας
- υποσέλιδο
- κείμενο υποσέλιδου
- ορισμός κεφαλίδας
- ορισμός υποσέλιδου
- φυλλάδιο
- σημειώσεις
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Χρησιμοποιήστε το Aspose.Slides for Java για να προσθέσετε και να προσαρμόσετε κεφαλίδες και υποσέλιδα σε παρουσιάσεις PowerPoint και OpenDocument, ώστε να αποκτήσετε επαγγελματική εμφάνιση."
---
## **Επισκόπηση**

Το Aspose.Slides σάς επιτρέπει να διαχειρίζεστε τις ρυθμίσεις κεφαλίδας και υποσέλιδου σε παρουσιάσεις PowerPoint. Οι κεφαλίδες και τα υποσέλιδα χειρίζονται στο επίπεδο του κύριου προτύπου παρουσίασης, και το API παρέχει μεθόδους για ορισμό κειμένου υποσέλιδου, αλλαγή ορατότητας του υποσέλιδου και ενημέρωση κειμένου κεφαλίδας στις κύριες διαφάνειες σημειώσεων.

Μπορείτε επίσης να διαχειριστείτε κεφαλίδες και υποσέλιδα για τις διαφάνειες φυλλαδίων και σημειώσεων. Αυτό περιλαμβάνει την αλλαγή της ορατότητας και του κειμένου των πεδίων κεφαλίδας, υποσέλιδου, αριθμού διαφάνειας και ημερομηνίας‑ώρας για το κύριο πρότυπο σημειώσεων, όλες τις θυγατρικές διαφάνειες σημειώσεων ή μια μεμονωμένη διαφάνεια σημειώσεων.

## **Διαχείριση κεφαλίδων και υποσέλιδων σε παρουσίαση**

Οι σημειώσεις ορισμένων συγκεκριμένων διαφανειών μπορούν να αφαιρεθούν, όπως φαίνεται στο παρακάτω παράδειγμα:

```java
// Φόρτωση Παρουσίασης
Presentation pres = new Presentation("headerTest.pptx");
try {
    // Ορισμός Υποσέλιδου
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);

    // Πρόσβαση και Ενημέρωση Κεφαλίδας
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (null != masterNotesSlide)
    {
        updateHeaderFooterText(masterNotesSlide);
    }

    // Αποθήκευση παρουσίασης
    pres.save("HeaderFooterJava.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
```java
// Μέθοδος για ορισμό κειμένου Κεφαλίδας/Υποσέλιδου
public static void updateHeaderFooterText(IBaseSlide master)
{
    for (IShape shape : master.getShapes())
    {
        if (shape.getPlaceholder() != null)
        {
            if (shape.getPlaceholder().getType() == PlaceholderType.Header)
            {
                ((IAutoShape)shape).getTextFrame().setText("HI there new header");
            }
        }
    }
}
```

## **Διαχείριση κεφαλίδων και υποσέλιδων σε φυλλάδια και διαφάνειες σημειώσεων**

Το Aspose.Slides for Java υποστηρίζει την κεφαλίδα και το υποσέλιδο σε φυλλάδια και διαφάνειες σημειώσεων. Ακολουθήστε τα παρακάτω βήματα:

- Φορτώστε ένα [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) που περιέχει βίντεο.
- Αλλάξτε τις ρυθμίσεις κεφαλίδας και υποσέλιδου για το κύριο πρότυπο σημειώσεων και όλες τις διαφάνειες σημειώσεων.
- Ορίστε τα πεδία υποσέλιδου στο κύριο πρότυπο σημειώσεων και σε όλες τις θυγατρικές διαφάνειες ορατά.
- Ορίστε τα πεδία ημερομηνίας και ώρας στο κύριο πρότυπο σημειώσεων και σε όλες τις θυγατρικές διαφάνειες ορατά.
- Αλλάξτε τις ρυθμίσεις κεφαλίδας και υποσέλιδου μόνο για την πρώτη διαφάνεια σημειώσεων.
- Ορίστε το πεδίο κεφαλίδας στη διαφάνεια σημειώσεων ορατό.
- Ορίστε κείμενο στο πεδίο κεφαλίδας της διαφάνειας σημειώσεων.
- Ορίστε κείμενο στο πεδίο ημερομηνίας‑ώρας της διαφάνειας σημειώσεων.
- Γράψτε το τροποποιημένο αρχείο παρουσίασης.

Το απόσπασμα κώδικα παρέχεται στο παρακάτω παράδειγμα.

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // Αλλαγή ρυθμίσεων κεφαλίδας και υποσέλιδου για το κύριο πρότυπο σημειώσεων και όλες τις διαφάνειες σημειώσεων
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // καθιστά ορατό το κύριο σημείωμα διαφάνειας και όλα τα παιδικά πεδία υποσέλιδου
        headerFooterManager.setFooterAndChildFootersVisibility(true); // καθιστά ορατό το κύριο σημείωμα διαφάνειας και όλα τα παιδικά πεδία κεφαλίδας
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // καθιστά ορατό το κύριο σημείωμα διαφάνειας και όλα τα παιδικά πεδία αριθμού διαφάνειας
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // καθιστά ορατό το κύριο σημείωμα διαφάνειας και όλα τα παιδικά πεδία ημερομηνίας και ώρας

        headerFooterManager.setHeaderAndChildHeadersText("Header text"); // ορίζει κείμενο στο κύριο σημείωμα διαφάνειας και όλα τα παιδικά πεδία κεφαλίδας
        headerFooterManager.setFooterAndChildFootersText("Footer text"); // ορίζει κείμενο στο κύριο σημείωμα διαφάνειας και όλα τα παιδικά πεδία υποσέλιδου
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text"); // ορίζει κείμενο στο κύριο σημείωμα διαφάνειας και όλα τα παιδικά πεδία ημερομηνίας και ώρας
    }

    // Αλλαγή ρυθμίσεων κεφαλίδας και υποσέλιδου μόνο για την πρώτη διαφάνεια σημειώσεων
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // καθιστά ορατό το πεδίο κεφαλίδας αυτής της διαφάνειας σημειώσεων

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // καθιστά ορατό το πεδίο υποσέλιδου αυτής της διαφάνειας σημειώσεων

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // καθιστά ορατό το πεδίο αριθμού διαφάνειας αυτής της διαφάνειας σημειώσεων

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // καθιστά ορατό το πεδίο ημερομηνίας‑ώρας αυτής της διαφάνειας σημειώσεων

        headerFooterManager.setHeaderText("New header text"); // ορίζει κείμενο στο πεδίο κεφαλίδας της διαφάνειας σημειώσεων
        headerFooterManager.setFooterText("New footer text"); // ορίζει κείμενο στο πεδίο υποσέλιδου της διαφάνειας σημειώσεων
        headerFooterManager.setDateTimeText("New date and time text"); // ορίζει κείμενο στο πεδίο ημερομηνίας‑ώρας της διαφάνειας σημειώσεων
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Συχνές ερωτήσεις**

**Μπορώ να προσθέσω μια «κεφαλίδα» στις κανονικές διαφάνειες;**

Στο PowerPoint, η «Κεφαλίδα» υπάρχει μόνο για σημειώσεις και φυλλάδια· στις κανονικές διαφάνειες, τα υποστηριζόμενα στοιχεία είναι το υποσέλιδο, η ημερομηνία/ώρα και ο αριθμός διαφάνειας. Στο Aspose.Slides αυτό ανταποκρίνεται στις ίδιες περιορισμούς: κεφαλίδα μόνο για Σημειώσεις/Φυλλάδια, και στις διαφάνειες — Υποσέλιδο/DateTime/SlideNumber.

**Τι γίνεται αν η διάταξη δεν περιέχει περιοχή υποσέλιδου—μπορώ να «ενεργοποιήσω» την ορατότητά του;**

Ναι. Ελέγξτε την ορατότητα μέσω του διαχειριστή κεφαλίδας/υποσέλιδου και ενεργοποιήστε την εάν χρειάζεται. Αυτοί οι δείκτες και οι μέθοδοι του API έχουν σχεδιαστεί για περιπτώσεις όπου το πεδίο λείπει ή είναι κρυφό.

**Πώς μπορώ να κάνω τον αριθμό διαφάνειας να ξεκινά από τιμή διαφορετική από το 1;**

Ορίστε το [first slide number](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-) της παρουσίασης· έπειτα, όλοι οι αριθμοί επανυπολογίζονται. Για παράδειγμα, μπορείτε να ξεκινήσετε από 0 ή 10 και να κρύψετε τον αριθμό στη διαφάνεια τίτλου.

**Τι συμβαίνει με τις κεφαλίδες/υποσέλιδα κατά την εξαγωγή σε PDF/εικόνες/HTML;**

Αποτυπώνονται ως κανονικά κειμενικά στοιχεία της παρουσίασης. Δηλαδή, εάν τα στοιχεία είναι ορατά στις διαφάνειες/σελίδες σημειώσεων, θα εμφανιστούν επίσης στην έξοδο μορφής μαζί με το υπόλοιπο περιεχόμενο.