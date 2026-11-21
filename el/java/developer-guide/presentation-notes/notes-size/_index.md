---
title: Αλλαγή Μεγέθους και Προσανατολισμού Σελίδας Σημειώσεων σε Java
linktitle: Μέγεθος Σελίδας Σημειώσεων
type: docs
weight: 10
url: /el/java/notes-size/
keywords:
- μέγεθος σελίδας σημειώσεων
- προσανατολισμός σημειώσεων
- οριζόντιες σημειώσεις
- κατακόρυφες σημειώσεις
- μέγεθος εγχειριδίου
- PowerPoint
- παρουσίαση
- PPT
- PPTX
- Java
- Aspose.Slides
description: "Διαβάστε και αλλάξτε τις διαστάσεις της σελίδας σημειώσεων στο Aspose.Slides για Java, αλλάξτε τον προσανατολισμό, επαληθεύστε τα αποθηκευμένα μεγέθη και εξάγετε σημειώσεις ή εγχειρίδια σε PDF και εικόνες."
---
## **Επισκόπηση**

Χρησιμοποιήστε [Presentation.getNotesSize](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#getNotesSize--) για να έχετε πρόσβαση στις ρυθμίσεις της σελίδας σημειώσεων της παρουσίασης. Επιστρέφει ένα αντικείμενο [INotesSize](https://reference.aspose.com/slides/el/java/com.aspose.slides/inotessize/) του οποίου η μέθοδος [setSize](https://reference.aspose.com/slides/el/java/com.aspose.slides/inotessize/#setSize-java.awt.geom.Dimension2D-) ορίζει τις διαστάσεις της σελίδας. Αν και το αντικείμενο ρυθμίσεων δεν μπορεί να αντικατασταθεί, μπορείτε να αντιστοιχίσετε νέες διαστάσεις μέσω αυτής της μεθόδου.

Το πλάτος και το ύψος ορίζονται σε **points**, με 72 points ανά ίντσα. Για παράδειγμα, 900 × 600 points ισοδυναμούν με 12,5 × 8⅓ ίντσες. Αυτές οι ρυθμίσεις ισχύουν για όλη την παρουσίαση, όχι για τις σημειώσεις ενός μεμονωμένου διαφάνειας.

| Ρύθμιση | Σκοπός |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#getNotesSize--) | Ελέγχει τις διαστάσεις της σελίδας σημειώσεων και τις διαστάσεις σελίδας που χρησιμοποιούνται για εξαγωγή σημειώσεων. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#getSlideSize--) | Ελέγχει τις κανονικές διαστάσεις των διαφανειών της παρουσίασης μέσω [ISlideSize](https://reference.aspose.com/slides/el/java/com.aspose.slides/islidesize/). |

Η αλλαγή της μιας ρύθμισης δεν αλλάζει αυτόματα την άλλη. Η αλλαγή του προσανατολισμού της σελίδας σημειώσεων επίσης δεν περιστρέφει τις κανονικές διαφάνειες. Δείτε το [Slide Size](/slides/el/java/slide-size/) για να αλλάξετε το μέγεθος των κανονικών διαφανειών.

Τα παραδείγματα παρακάτω χρησιμοποιούν ένα υπάρχον `sample.pptx`. Για τα παραδείγματα εξαγωγής, χρησιμοποιήστε μια παρουσίαση με τουλάχιστον μία διαφάνεια που περιέχει σημειώσεις ομιλητή. Κάθε παράδειγμα μπορεί να εκτελεστεί ανεξάρτητα.

## **Ανάγνωση του Μεγέθους και του Προσανατολισμού της Σελίδας Σημειώσεων**

Διαβάστε το πλάτος και το ύψος και συγκρίνετε τα για να καθορίσετε τον προσανατολισμό: μια πιο ευρεία σελίδα είναι οριζόντια, μια πιο ψηλή σελίδα είναι κάθετη, και ίσες διαστάσεις περιγράφουν μια τετράγωνη σελίδα. Αυτό το παράδειγμα εκτυπώνει τις πραγματικές διαστάσεις σε points, χωρίς να υποθέτει τυπικό μέγεθος χαρτιού.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D size = presentation.getNotesSize().getSize();
    String orientation = "Square";

    if (size.getWidth() > size.getHeight()) {
        orientation = "Landscape";
    } else if (size.getWidth() < size.getHeight()) {
        orientation = "Portrait";
    }

    System.out.println("Notes page: " + size.getWidth() + " x " + size.getHeight() + " points");
    System.out.println("Orientation: " + orientation);
} finally {
    presentation.dispose();
}
```

## **Αλλαγή σε Οριζόντιο Χωρίς Αλλαγή του Μεγέθους Χαρτιού**

Για να αλλάξετε μόνο τον προσανατολισμό, ανταλλάξτε το υπάρχον πλάτος και ύψος. Αυτό διατηρεί τα μήκη και των δύο πλευρών, συμπεριλαμβανομένων αυτών ενός προσαρμοσμένου μεγέθους χαρτιού. Η παρακάτω συνθήκη αποτρέπει μια ήδη οριζόντια σελίδα να επανέλθει σε κάθετο και αφήνει μια τετράγωνη σελίδα αμετάβλητη.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        double width = size.getWidth();
        size.setSize(size.getHeight(), width);
        presentation.getNotesSize().setSize(size);
    }

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Για κάθετο προσανατολισμό, χρησιμοποιήστε την ίδια ανάθεση όταν `size.getWidth() > size.getHeight()`. Μην αντικαταστήσετε τις διαστάσεις A4 ή Letter εκτός εάν θέλετε επίσης να αλλάξετε το μέγεθος του χαρτιού.

## **Ορισμός και Επαλήθευση Προσαρμοσμένου Μεγέθους Σελίδας Σημειώσεων**

Ορίστε και τις δύο διαστάσεις μαζί, έπειτα χρησιμοποιήστε [Presentation.save](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#save-java.lang.String-int-) για να αποθηκεύσετε την παρουσίαση. Αυτό το παράδειγμα ορίζει μια οριζόντια σελίδα 900 × 600 points, την αποθηκεύει ως PPTX και ανοίγει ξανά το αποθηκευμένο αρχείο για να ελέγξει τις αποθηκευμένες τιμές. Η σύγκριση επιτρέπει ανοχή 0,01 point για τιμές κινητής υποδιαστολής· δεν αποτελεί εγγύηση ακρίβειας για κάθε μορφή αρχείου.

```java
import com.aspose.slides.*;
import java.awt.Dimension;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D expectedSize = new Dimension(900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom-notes.pptx");
    try {
        Dimension2D actualSize = reopened.getNotesSize().getSize();
        boolean widthMatches = Math.abs(actualSize.getWidth() - expectedSize.getWidth()) < 0.01;
        boolean heightMatches = Math.abs(actualSize.getHeight() - expectedSize.getHeight()) < 0.01;
        boolean preserved = widthMatches && heightMatches;

        System.out.println("Stored notes page: " + actualSize.getWidth() + " x " + actualSize.getHeight() + " points");
        System.out.println("Size preserved: " + preserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Το αναμενόμενο αποτέλεσμα είναι `900.0 x 600.0 points` και `Size preserved: true`. Ο έλεγχος μιας νεοανοιγμένης παρουσίασης επαληθεύει το αποθηκευμένο αρχείο, όχι μόνο τις ρυθμίσεις στη μνήμη.

## **Εξαγωγή Σημειώσεων και Εγχειριδίων**

Οι διαστάσεις της σελίδας ορίζουν τη διαθέσιμη περιοχή για τη διάταξη σημειώσεων ή εγχειριδίων. Δεν ενεργοποιούν αυτές τις διατάξεις από μόνες τους: ρυθμίστε επίσης τις επιλογές εξαγωγής. Η κανονική εξαγωγή διαφανειών συνεχίζει να χρησιμοποιεί τις διαστάσεις της διαφάνειας.

### **Εξαγωγή Σημειώσεων σε PDF και PNG**

Αναθέστε [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/notescommentslayoutingoptions/) σε [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/pdfoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) για να συμπεριλάβετε τις σημειώσεις στο PDF. Αυτό το παράδειγμα επίσης αποδίδει την πρώτη διαφάνεια με σημειώσεις σε PNG χρησιμοποιώντας [Slide.getImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) και [RenderingOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/renderingoptions/).

Η λειτουργία [BottomTruncated](https://reference.aspose.com/slides/el/java/com.aspose.slides/notespositions/) διατηρεί τις σημειώσεις σε μία σελίδα· οι σημειώσεις που δεν χωράνε μπορούν να περικοπούν. Το PDF χρησιμοποιεί σελίδες 900 × 600 points. Στην κλίμακα εικόνας 1 × 1 που χρησιμοποιείται παρακάτω, το PNG είναι 900 × 600 pixels. Τα points περιγράφουν τη γεωμετρία της σελίδας· τα pixels περιγράφουν την raster έξοδο, των οποίων οι διαστάσεις εξαρτώνται επίσης από την κλίμακα απόδοσης.

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension size = new Dimension(900, 600);
    presentation.getNotesSize().setSize(size);

    NotesCommentsLayoutingOptions layout = new NotesCommentsLayoutingOptions();
    layout.setNotesPosition(NotesPositions.BottomTruncated);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("notes.pdf", SaveFormat.Pdf, pdfOptions);

    RenderingOptions renderingOptions = new RenderingOptions();
    renderingOptions.setSlidesLayoutOptions(layout);

    IImage image = presentation.getSlides().get_Item(0).getImage(renderingOptions, 1, 1);
    try {
        image.save("first-slide-notes.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

Για εξαγωγή PDF με μεγάλες σημειώσεις, η λειτουργία [BottomFull](https://reference.aspose.com/slides/el/java/com.aspose.slides/notespositions/) επιτρέπει πρόσθετες σελίδες όπως απαιτείται. Μην χρησιμοποιείτε αυτή τη λειτουργία με την κλήση εικόνας μίας διαφάνειας παραπάνω, η οποία δεν τη υποστηρίζει. Μετά την αλλαγή μεγέθους, εξετάστε την έξοδο για αποκομμένες σημειώσεις και τη θέση των υπαρχόντων αντικειμένων notes‑master· η αλλαγή διαστάσεων της σελίδας μόνη της δεν πρέπει να θεωρείται εγγύηση ότι όλο το περιεχόμενο θα χωρίσει. Δείτε το [Convert PowerPoint to PDF with Notes](/slides/el/java/convert-powerpoint-to-pdf-with-notes/) για περισσότερα σχετικά με την εξαγωγή σημειώσεων.

### **Εξαγωγή Εγχειριδίων σε PDF**

Χρησιμοποιήστε [HandoutLayoutingOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/handoutlayoutingoptions/) για πολλαπλά μικρογραφίες διαφανειών σε μία σελίδα. Το παρακάτω παράδειγμα ορίζει μια σελίδα 900 × 600 points και χρησιμοποιεί το [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/el/java/com.aspose.slides/handouttype/) για να τοποθετήσει έως τέσσερις διαφάνειες ανά σελίδα. Η οριζόντια προεπιλογή ελέγχει τη σειρά των διαφανειών· ο προσανατολισμός της σελίδας προέρχεται από το πλάτος και το ύψος της.

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension size = new Dimension(900, 600);
    presentation.getNotesSize().setSize(size);

    HandoutLayoutingOptions layout = new HandoutLayoutingOptions();
    layout.setHandout(HandoutType.Handouts4Horizontal);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("handouts.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Η αλλαγή του μεγέθους της σελίδας αλλάζει την περιοχή που είναι διαθέσιμη για το πλέγμα των εγχειριδίων χωρίς να αλλάζει τις διαστάσεις των αρχικών διαφανειών. Για εικόνες εγχειριδίων, χρησιμοποιήστε το [Presentation.getImages](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) με τη διάταξη εγχειριδίου, αντί για τη μέθοδο εικόνας μιας μεμονωμένης διαφάνειας. Στο Aspose.Slides, η απόδοση εγχειριδίων σε επίπεδο παρουσίασης χρησιμοποιεί τις διαστάσεις της σελίδας σημειώσεων, ενώ η κλήση εικόνας μεμονωμένης διαφάνειας δεν παράγει τη σελίδα του εγχειριδίου. Δείτε το [Handout Mode](/slides/el/java/convert-powerpoint-in-handout-mode/) για επιλογές διάταξης.

## **Μέγεθος Σελίδας σε Προβολείς, Εξαγωγές και Εκτυπώσεις**

Διατηρήστε ξεχωριστά το αποθηκευμένο μέγεθος της παρουσίασης, το εξαγόμενο μέγεθος σελίδας και το εκτυπωμένο μέγεθος χαρτιού:

- **Προβολείς Παρουσίας:** Ένας προβολέας μπορεί να εμφανίζει ή να εκτυπώνει τις σημειώσεις χρησιμοποιώντας τους δικούς του κανόνες διάταξης. Εάν μια άλλη εφαρμογή αποθηκεύσει το αρχείο, ανοίξτε το ξανά και ελέγξτε τις διαστάσεις· η μετατροπή μορφής της εφαρμογής ενδέχεται να τις ομαλοποιήσει.
- **Μορφές Εξαγωγής:** Τα παραδείγματα PDF σημειώσεων και εγχειριδίων παραπάνω χρησιμοποιούν τις διαμορφωμένες διαστάσεις σελίδας. Οι raster εικόνες χρησιμοποιούν ακέραιες διαστάσεις pixel και μια κλίμακα απόδοσης, έτσι οι κλασματικές τιμές points μπορούν να στρογγυλοποιηθούν στην έξοδο εικόνας. Η εξαγωγή κανονικών διαφανειών δεν εφαρμόζει το μέγεθος σελίδας σημειώσεων.
- **Οδηγοί Εκτυπωτών:** Η επιλογή χαρτιού, η αυτόματη περιστροφή και οι ρυθμίσεις προσαρμογής σε σελίδα μπορούν να αλλάξουν το φυσικό αποτέλεσμα χωρίς να αλλάξουν τις διαστάσεις που αποθηκεύονται στην παρουσίαση ή στο PDF. Για συγκεκριμένο μέγεθος χαρτιού, ταιριάξτε τις ρυθμίσεις του εκτυπωτή και ελέγξτε την προεπισκόπηση εκτύπωσης.

## **Συχνές Ερωτήσεις**

**Μπορώ να ορίσω το μέγεθος των σημειώσεων μόνο για μία διαφάνεια;**

Το μέγεθος της σελίδας σημειώσεων είναι ρύθμιση σε επίπεδο παρουσίασης. Οι μεμονωμένες διαφάνειες μπορούν να έχουν διαφορετικό περιεχόμενο σημειώσεων, αλλά αυτή η ιδιότητα δεν παρέχει ξεχωριστό μέγεθος σελίδας για κάθε διαφάνεια.

**Γιατί η αλλαγή του προσανατολισμού των σημειώσεων δεν άλλαξε τις διαφάνειες μου;**

Οι σελίδες σημειώσεων και οι κανονικές διαφάνειες έχουν ανεξάρτητες διαστάσεις. Χρησιμοποιήστε τις ρυθμίσεις μεγέθους κανονικών διαφανειών όταν θέλετε να αλλάξετε το μέγεθος των διαφανειών.

**Γιατί το αποθηκευμένο ή εκτυπωμένο αποτέλεσμα έχει διαφορετικό μέγεθος;**

Πρώτα ανοίξτε ξανά την αποθηκευμένη παρουσίαση και συγκρίνετε τις διαστάσεις των σημειώσεων. Εάν αυτές άλλαξαν, ελέγξτε αν η αποθήκευση ή η μετατροπή του αρχείου σε άλλη εφαρμογή άλλαξε τις ρυθμίσεις της σελίδας. Αν δεν άλλαξαν, ελέγξτε τη διάταξη εξαγωγής, την κλίμακα εικόνας, τις ρυθμίσεις του προβολέα και την επιλογή χαρτιού του εκτυπωτή.