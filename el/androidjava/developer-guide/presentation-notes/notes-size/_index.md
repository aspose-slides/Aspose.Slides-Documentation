---
title: Αλλαγή Μεγέθους Σελίδας Σημειώσεων και Προσανατολισμού σε Android
linktitle: Μέγεθος Σελίδας Σημειώσεων
type: docs
weight: 10
url: /el/androidjava/notes-size/
keywords:
- μέγεθος σελίδας σημειώσεων
- προσανατολισμός σημειώσεων
- οριζόντιες σημειώσεις
- κάθετες σημειώσεις
- μέγεθος φυλλαδίου
- PowerPoint
- παρουσίαση
- PPT
- PPTX
- Android
- Java
- Aspose.Slides
description: "Διαβάστε και αλλάξτε τις διαστάσεις της σελίδας σημειώσεων στο Aspose.Slides για Android μέσω Java, αλλάξτε τον προσανατολισμό, επαληθεύστε τα αποθηκευμένα μεγέθη και εξαγάγετε σημειώσεις ή φυλλάδια σε PDF και εικόνες."
---
## **Επισκόπηση**

Χρησιμοποιήστε [Presentation.getNotesSize](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#getNotesSize--) για να αποκτήσετε πρόσβαση στις ρυθμίσεις σελίδας σημειώσεων της παρουσίασης. Επιστρέφει ένα αντικείμενο [INotesSize](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/inotessize/) του οποίου η μέθοδος [setSize](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/inotessize/#setSize-com.aspose.slides.android.SizeF-) ορίζει τις διαστάσεις της σελίδας. Αν και το αντικείμενο ρυθμίσεων δεν μπορεί να αντικατασταθεί, μπορείτε να αναθέσετε νέες διαστάσεις μέσω αυτής της μεθόδου.

Το πλάτος και το ύψος καθορίζονται σε **σημεία**, με 72 σημεία ανά ίντσα. Για παράδειγμα, 900 × 600 σημεία ισοδυναμούν με 12,5 × 8⅓ ίντσες. Αυτές οι ρυθμίσεις ισχύουν για ολόκληρη την παρουσίαση, όχι για τις σημειώσεις ενός μεμονωμένου διαφάνειας.

| Ρύθμιση | Σκοπός |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#getNotesSize--) | Ελέγχει τις διαστάσεις της σελίδας σημειώσεων και τις διαστάσεις σελίδας που χρησιμοποιούνται για την εξαγωγή φυλλαδίου. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#getSlideSize--) | Ελέγχει τις κανονικές διαστάσεις των διαφανειών της παρουσίασης μέσω του [ISlideSize](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islidesize/). |

Η αλλαγή οποιασδήποτε ρύθμισης δεν αλλάζει αυτόματα την άλλη. Η αλλαγή του προσανατολισμού της σελίδας σημειώσεων δεν περιστρέφει επίσης τις κανονικές διαφάνειες. Δείτε το [Slide Size](/slides/el/androidjava/slide-size/) για να αλλάξετε το μέγεθος των κανονικών διαφανειών.

Τα παραδείγματα παρακάτω χρησιμοποιούν ένα υπάρχον αρχείο `sample.pptx`. Για τα παραδείγματα εξαγωγής, χρησιμοποιήστε μια παρουσίαση που περιέχει τουλάχιστον μία διαφάνεια με σημειώσεις ομιλητή. Κάθε παράδειγμα μπορεί να εκτελεστεί ανεξάρτητα.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = presentation.getNotesSize().getSize();
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

## **Ανάγνωση του Μεγέθους και του Προσανατολισμού της Σελίδας Σημειώσεων**

Διαβάστε το πλάτος και το ύψος και συγκρίνετε τα για να καθορίσετε τον προσανατολισμό: μια πιο πλατιά σελίδα είναι οριζόντια, μια πιο ψηλή σελίδα είναι κάθετη, και ίσες διαστάσεις περιγράφουν μια τετράγωνη σελίδα. Αυτό το παράδειγμα εκτυπώνει τις πραγματικές διαστάσεις σε σημεία, χωρίς να υποθέτει ένα τυπικό μέγεθος χαρτιού.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        SizeF landscapeSize = new SizeF(size.getHeight(), size.getWidth());
        presentation.getNotesSize().setSize(landscapeSize);
    }

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Αλλαγή σε Οριζόντια Διάταξη Χωρίς Αλλαγή του Μεγέθους Χαρτιού**

Για να αλλάξετε μόνο τον προσανατολισμό, ανταλλάξτε το υπάρχον πλάτος και ύψος. Αυτό διατηρεί τα μήκη και των δύο πλευρών, συμπεριλαμβανομένων εκείνων ενός προσαρμοσμένου μεγέθους χαρτιού. Η παρακάτω συνθήκη αποτρέπει το να αλλάξει μια ήδη οριζόντια σελίδα πίσω σε κάθετη και αφήνει μια τετράγωνη σελίδα αμετάβλητη.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF expectedSize = new SizeF(900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom-notes.pptx");
    try {
        SizeF actualSize = reopened.getNotesSize().getSize();
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

Για κάθετη διάταξη, χρησιμοποιήστε την ίδια ανάθεση όταν `size.getWidth() > size.getHeight()`. Μην αντικαταστήσετε τις διαστάσεις A4 ή Letter εκτός εάν θέλετε επίσης να αλλάξετε το μέγεθος του χαρτιού.

## **Ορισμός και Επαλήθευση Προσαρμοσμένου Μεγέθους Σελίδας Σημειώσεων**

Αναθέστε και τις δύο διαστάσεις μαζί, στη συνέχεια χρησιμοποιήστε το [Presentation.save](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) για να αποθηκεύσετε την παρουσίαση. Αυτό το παράδειγμα ορίζει μια οριζόντια σελίδα 900 × 600 σημεία, τη αποθηκεύει ως PPTX και ανοίγει ξανά το αποθηκευμένο αρχείο για να ελέγξει τις αποθηκευμένες τιμές. Η σύγκριση επιτρέπει μια ανοχή 0,01 σημείου για τις τιμές κινητής υποδιαστολής· δεν αποτελεί εγγύηση ακρίβειας για κάθε μορφή αρχείου.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = new SizeF(900, 600);
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

## **Εξαγωγή Σημειώσεων και Φυλλαδίων**

Οι διαστάσεις της σελίδας καθορίζουν την διαθέσιμη περιοχή για τις διατάξεις σημειώσεων ή φυλλαδίων. Δεν ενεργοποιούν από μόνες τους αυτές τις διατάξεις: διαμορφώστε επίσης τις επιλογές εξαγωγής. Η εξαγωγή κανονικών διαφανειών συνεχίζει να χρησιμοποιεί τις διαστάσεις των διαφανειών.

### **Εξαγωγή Σημειώσεων σε PDF και PNG**

Αναθέστε το [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/notescommentslayoutingoptions/) στην μέθοδο [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pdfoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) για να συμπεριλάβετε τις σημειώσεις στο PDF. Αυτό το παράδειγμα επίσης αποδίδει την πρώτη διαφάνεια με σημειώσεις σε PNG χρησιμοποιώντας το [Slide.getImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) και το [RenderingOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/renderingoptions/).

Η λειτουργία [BottomTruncated](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/notespositions/) διατηρεί τις σημειώσεις σε μία σελίδα· οι σημειώσεις που δεν χωρούν μπορούν να περικοπούν. Το PDF χρησιμοποιεί σελίδες 900 × 600 σημείων. Με την κλίμακα εικόνας 1 × 1 που χρησιμοποιείται παρακάτω, το PNG είναι 900 × 600 εικονοστοιχεία. Τα σημεία περιγράφουν τη γεωμετρία της σελίδας· τα εικονοστοιχεία περιγράφουν την έξοδο raster, των οποίων οι διαστάσεις εξαρτώνται επίσης από την κλίμακα απόδοσης.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = new SizeF(900, 600);
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

Για εξαγωγή PDF με μακρές σημειώσεις, η λειτουργία [BottomFull](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/notespositions/) επιτρέπει επιπλέον σελίδες όπως απαιτείται. Μην χρησιμοποιήσετε αυτή τη λειτουργία με την κλήση εικόνας μίας διαφάνειας παραπάνω, η οποία δεν την υποστηρίζει. Μετά την αλλαγή μεγέθους, ελέγξτε το αποτέλεσμα για περικομμένες σημειώσεις και τη θέση των υπαρχόντων αντικειμένων notes‑master· η αλλαγή των διαστάσεων της σελίδας από μόνης της δεν πρέπει να θεωρείται εγγύηση ότι όλο το περιεχόμενο θα χωράει. Δείτε το [Convert PowerPoint to PDF with Notes](/slides/el/androidjava/convert-powerpoint-to-pdf-with-notes/) για περισσότερα σχετικά με την εξαγωγή σημειώσεων.

### **Εξαγωγή Φυλλαδίων σε PDF**

Χρησιμοποιήστε το [HandoutLayoutingOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/handoutlayoutingoptions/) για πολλαπλές μικρογραφίες διαφανειών σε μία σελίδα. Το παρακάτω παράδειγμα ορίζει μια σελίδα 900 × 600 σημείων και χρησιμοποιεί το [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/handouttype/) για να τοποθετήσει έως τέσσερις διαφάνειες ανά σελίδα. Η οριζόντια προεπιλογή ελέγχει τη σειρά των διαφανειών· ο προσανατολισμός της σελίδας προέρχεται από το πλάτος και το ύψος της.

Η αλλαγή του μεγέθους της σελίδας αλλαγεί την περιοχή που είναι διαθέσιμη για το πλέγμα του φυλλαδίου χωρίς να αλλάζει τις διαστάσεις των πηγαίων διαφανειών. Για εικόνες φυλλαδίων, χρησιμοποιήστε το [Presentation.getImages](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) με τη διάταξη φυλλαδίου, αντί για τη μέθοδο εικόνας μιας μεμονωμένης διαφάνειας. Στο Aspose.Slides, η απόδοση φυλλαδίων σε επίπεδο παρουσίασης χρησιμοποιεί τις διαστάσεις της σελίδας σημειώσεων, ενώ η κλήση εικόνας μεμονωμένης διαφάνειας δεν δημιουργεί τη σελίδα φυλλαδίου. Δείτε το [Handout Mode](/slides/el/androidjava/convert-powerpoint-in-handout-mode/) για επιλογές διάταξης.

## **Μέγεθος Σελίδας σε Προγράμματα Προβολής, Εξαγωγή και Εκτύπωση**

Διατηρήστε το αποθηκευμένο μέγεθος παρουσίασης, το μέγεθος σελίδας κατά την εξαγωγή και το εκτυπωμένο μέγεθος χαρτιού ξεχωριστά:

- **Presentation viewers:** Ένας προβολέας μπορεί να εμφανίσει ή να εκτυπώσει σημειώσεις χρησιμοποιώντας τους δικούς του κανόνες διάταξης. Εάν μια άλλη εφαρμογή αποθηκεύσει το αρχείο, ανοίξτε το ξανά και ελέγξτε τις διαστάσεις· η μετατροπή μορφής εκείνης της εφαρμογής μπορεί να τις ομαλοποιήσει.
- **Export formats:** Τα παραδείγματα PDF σημειώσεων και φυλλαδίων παραπάνω χρησιμοποιούν τις ρυθμισμένες διαστάσεις σελίδας. Τα raster εικόνες χρησιμοποιούν ακέραιες διαστάσεις εικονοστοιχείων και κλίμακα απόδοσης, έτσι οι κλασματικές τιμές σημείων μπορεί να στρογγυλοποιηθούν στην έξοδο εικόνας. Η εξαγωγή κανονικών διαφανειών δεν εφαρμόζει το μέγεθος της σελίδας σημειώσεων.
- **Printer drivers:** Η επιλογή χαρτιού, η αυτόματη περιστροφή και οι ρυθμίσεις προσαρμογής στη σελίδα μπορούν να αλλάξουν το φυσικό αποτέλεσμα χωρίς να τροποποιούν τις διαστάσεις που είναι αποθηκευμένες στην παρουσίαση ή στο PDF. Για ένα συγκεκριμένο μέγεθος χαρτιού, ταιριάξτε τις ρυθμίσεις του εκτυπωτή και ελέγξτε την προεπισκόπηση εκτύπωσης.

## **FAQ**

**Μπορώ να ορίσω το μέγεθος των σημειώσεων για μόνο μία διαφάνεια;**

Το μέγεθος της σελίδας σημειώσεων είναι ρύθμιση επιπέδου παρουσίασης. Οι μεμονωμένες διαφάνειες μπορούν να έχουν διαφορετικό περιεχόμενο σημειώσεων, αλλά αυτή η ιδιότητα δεν παρέχει ξεχωριστό μέγεθος σελίδας για κάθε διαφάνεια.

**Γιατί η αλλαγή του προσανατολισμού των σημειώσεων δεν άλλαξε τις διαφάνειές μου;**

Οι σελίδες σημειώσεων και οι κανονικές διαφάνειες έχουν ανεξάρτητες διαστάσεις. Χρησιμοποιήστε τις ρυθμίσεις μεγέθους κανονικής διαφάνειας όταν θέλετε να αλλάξετε το μέγεθος των ίδιων των διαφανειών.

**Γιατί το αποθηκευμένο ή εκτυπωμένο αποτέλεσμα έχει διαφορετικό μέγεθος;**

Πρώτα ανοίξτε ξανά την αποθηκευμένη παρουσίαση και συγκρίνετε τις διαστάσεις των σημειώσεων της. Εάν αυτές έχουν αλλάξει, ελέγξτε αν η αποθήκευση ή η μετατροπή του αρχείου σε άλλη εφαρμογή άλλαξε τις ρυθμίσεις σελίδας. Εάν όχι, ελέγξτε τη διάταξη εξαγωγής, την κλίμακα εικόνας, τις ρυθμίσεις προβολής και την επιλογή χαρτιού του εκτυπωτή.