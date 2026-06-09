---
title: Διαχείριση κεφαλίδων και υποσέλιδων παρουσίασης σε Android
linktitle: Κεφαλίδα & Υποσέλιδο
type: docs
weight: 140
url: /el/androidjava/presentation-header-and-footer/
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
- Android
- Java
- Aspose.Slides
description: "Χρησιμοποιήστε το Aspose.Slides for Android μέσω Java για να προσθέσετε και να προσαρμόσετε κεφαλίδες και υποσέλιδα σε παρουσιάσεις PowerPoint και OpenDocument για επαγγελματική εμφάνιση."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει να διαχειρίζεστε τις ρυθμίσεις κεφαλίδας και υποσέλιδου σε παρουσιάσεις PowerPoint. Οι κεφαλίδες και τα υποσέλιδα διαχειρίζονται σε επίπεδο κύριου πρότυπου παρουσίασης, και το API παρέχει μεθόδους για ορισμό κειμένου υποσέλιδου, αλλαγή της ορατότητας του υποσέλιδου και ενημέρωση του κειμένου κεφαλίδας στις κύριες διαφάνειες σημειώσεων.

Μπορείτε επίσης να διαχειριστείτε τις κεφαλίδες και τα υποσέλιδα για διαφάνειες σημειώσεων και φυλλάδια. Αυτό περιλαμβάνει την αλλαγή της ορατότητας και του κειμένου των θέσεων κράτησης κεφαλίδας, υποσέλιδου, αριθμού διαφάνειας και ημερομηνίας‑ώρας για το κύριο σημειώσεων, όλες τις θυγατρικές διαφάνειες σημειώσεων ή μία μεμονωμένη διαφάνεια σημειώσεων.

## **Διαχείριση κεφαλίδων και υποσέλιδων σε μια παρουσίαση**
Οι σημειώσεις ορισμένων συγκεκριμένων διαφανειών μπορούν να αφαιρεθούν όπως φαίνεται στο παρακάτω παράδειγμα:

```java
// Φόρτωση παρουσίασης
Presentation pres = new Presentation("headerTest.pptx");
try {
    // Ορισμός υποσέλιδου
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);

    // Πρόσβαση και ενημέρωση κεφαλίδας
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
Το Aspose.Slides for Android via Java υποστηρίζει Κεφαλίδα και Υποσέλιδο σε φυλλάδια και διαφάνειες σημειώσεων. Ακολουθήστε τα παρακάτω βήματα:

- Φορτώστε μια [Παρουσίαση](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation) που περιέχει βίντεο.
- Αλλάξτε τις ρυθμίσεις Κεφαλίδας και Υποσέλιδου για το κύριο σημειώσεων και όλες τις διαφάνειες σημειώσεων.
- Ορίστε ορατές τις θέσεις κράτησης Υποσέλιδο του κύριου σημειώσεων και όλων των θυγατρικών.
- Ορίστε ορατές τις θέσεις κράτησης Ημερομηνίας‑Ώρας του κύριου σημειώσεων και όλων των θυγατρικών.
- Αλλάξτε τις ρυθμίσεις Κεφαλίδας και Υποσέλιδου μόνο για την πρώτη διαφάνεια σημειώσεων.
- Ορίστε ορατή τη θέση κράτησης Κεφαλίδας της διαφάνειας σημειώσεων.
- Ορίστε κείμενο στη θέση κράτησης Κεφαλίδας της διαφάνειας σημειώσεων.
- Ορίστε κείμενο στη θέση κράτησης Ημερομηνίας‑Ώρας της διαφάνειας σημειώσεων.
- Γράψτε το τροποποιημένο αρχείο παρουσίασης.

Κώδικας που δίνεται στο παρακάτω παράδειγμα.

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // Αλλαγή ρυθμίσεων κεφαλίδας και υποσέλιδου για το κύριο σημειώσεων και όλες τις διαφάνειες σημειώσεων
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // κάνει ορατή τη κύρια διαφάνεια σημειώσεων και όλες τις θυγατρικές θέσεις κράτησης Υποσέλιδου
        headerFooterManager.setFooterAndChildFootersVisibility(true); // κάνει ορατή τη κύρια διαφάνεια σημειώσεων και όλες τις θυγατρικές θέσεις κράτησης Κεφαλίδας
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // κάνει ορατή τη κύρια διαφάνεια σημειώσεων και όλες τις θυγατρικές θέσεις κράτησης Αριθμού διαφάνειας
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // κάνει ορατή τη κύρια διαφάνεια σημειώνων και όλες τις θυγατρικές θέσεις κράτησης Ημερομηνίας και ώρας

        headerFooterManager.setHeaderAndChildHeadersText("Header text"); // ορίζει κείμενο στη κύρια διαφάνεια σημειώσεων και όλες τις θυγατρικές θέσεις κράτησης Κεφαλίδας
        headerFooterManager.setFooterAndChildFootersText("Footer text"); // ορίζει κείμενο στη κύρια διαφάνεια σημειώσεων και όλες τις θυγατρικές θέσεις κράτησης Υποσέλιδου
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text"); // ορίζει κείμενο στη κύρια διαφάνεια σημειώσεων και όλες τις θυγατρικές θέσεις κράτησης Ημερομηνίας και ώρας
    }

    // Αλλαγή ρυθμίσεων κεφαλίδας και υποσέλιδου μόνο για την πρώτη διαφάνεια σημειώσεων
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // κάνει ορατή τη θέση κράτησης Κεφαλίδας σε αυτήν τη διαφάνεια σημειώσεων

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // κάνει ορατή τη θέση κράτησης Υποσέλιδου σε αυτήν τη διαφάνεια σημειώσεων

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // κάνει ορατή τη θέση κράτησης Αριθμού διαφάνειας σε αυτήν τη διαφάνεια σημειώσεων

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // κάνει ορατή τη θέση κράτησης Ημερομηνίας‑Ώρας σε αυτήν τη διαφάνεια σημειώσεων

        headerFooterManager.setHeaderText("New header text"); // ορίζει κείμενο στη θέση κράτησης Κεφαλίδας της διαφάνειας σημειώσεων
        headerFooterManager.setFooterText("New footer text"); // ορίζει κείμενο στη θέση κράτησης Υποσέλιδου της διαφάνειας σημειώσεων
        headerFooterManager.setDateTimeText("New date and time text"); // ορίζει κείμενο στη θέση κράτησης Ημερομηνίας‑Ώρας της διαφάνειας σημειώσεων
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Συχνές ερωτήσεις**

**Μπορώ να προσθέσω μια "header" σε κανονικές διαφάνειες;**

Στο PowerPoint, η «Κεφαλίδα» υπάρχει μόνο για σημειώσεις και φυλλάδια· σε κανονικές διαφάνειες, τα υποστηριζόμενα στοιχεία είναι το υποσέλιδο, η ημερομηνία/ώρα και ο αριθμός διαφάνειας. Στο Aspose.Slides αυτό αντικατοπτρίζει τις ίδιες περιορισμούς: κεφαλίδα μόνο για Σημειώσεις/Φυλλάδια, και σε διαφάνειες — Υποσέλιδο/Ημερομηνία‑Ώρα/ΑριθμόςΔιαφάνειας.

**Τι γίνεται αν η διάταξη δεν περιέχει περιοχή υποσέλιδου· μπορώ να «ενεργοποιήσω» την ορατότητά του;**

Ναι. Ελέγξτε την ορατότητα μέσω του διαχειριστή κεφαλίδας/υποσέλιδου και ενεργοποιήστε την αν χρειάζεται. Αυτοί οι δείκτες και οι μέθοδοι του API έχουν σχεδιαστεί για περιπτώσεις όπου η θέση κράτησης λείπει ή είναι κρυμμένη.

**Πώς μπορώ να κάνω ώστε ο αριθμός διαφάνειας να ξεκινά από τιμή διαφορετική από το 1;**

Ορίστε τον [αριθμό πρώτης διαφάνειας](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) της παρουσίασης· μετά από αυτό, όλα τα νούμερα επανυπολογίζονται. Για παράδειγμα, μπορείτε να ξεκινήσετε από 0 ή 10 και να κρύψετε τον αριθμό στη διαφάνεια τίτλου.

**Τι συμβαίνει με τις κεφαλίδες/υποσέλιδα κατά την εξαγωγή σε PDF/εικόνες/HTML;**

Αποδίδονται ως κανονικά κειμενικά στοιχεία της παρουσίασης. Δηλαδή, αν τα στοιχεία είναι ορατά στις διαφάνειες/σελίδες σημειώσεων, θα εμφανίζονται επίσης και στην έξοδο μαζί με το υπόλοιπο περιεχόμενο.