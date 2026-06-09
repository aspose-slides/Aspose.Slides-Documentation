---
title: Μετατροπή διαφανειών παρουσίασης σε εικόνες στο Android
linktitle: Διαφάνεια σε εικόνα
type: docs
weight: 35
url: /el/androidjava/convert-slide/
keywords:
- μετατροπή διαφάνειας
- εξαγωγή διαφάνειας
- διαφάνεια σε εικόνα
- αποθήκευση διαφάνειας ως εικόνα
- διαφάνεια σε PNG
- διαφάνεια σε JPEG
- διαφάνεια σε bitmap
- διαφάνεια σε TIFF
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Μετατροπή διαφανειών από PPT, PPTX και ODP σε εικόνες χρησιμοποιώντας το Aspose.Slides για Android—γρήγορη, υψηλής ποιότητας απόδοση με σαφή παραδείγματα κώδικα Java."
---
## **Εισαγωγή**

Το Aspose.Slides for Android via Java σας επιτρέπει να μετατρέψετε εύκολα διαφάνειες παρουσιάσεων PowerPoint και OpenDocument σε διάφορες μορφές εικόνας, συμπεριλαμβανομένων των BMP, PNG, JPG (JPEG), GIF και άλλων.

Για να μετατρέψετε μια διαφάνεια σε εικόνα, ακολουθήστε τα παρακάτω βήματα:

1. Ορίστε τις επιθυμητές ρυθμίσεις μετατροπής και επιλέξτε τις διαφάνειες που θέλετε να εξάγετε χρησιμοποιώντας:
    - Την διεπαφή [ITiffOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itiffoptions/) ή
    - Τη διεπαφή [IRenderingOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/irenderingoptions/) .
2. Δημιουργήστε την εικόνα της διαφάνειας καλώντας τη μέθοδο [getImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islide/#getImage--) .

Στο Aspose.Slides for Android via Java, το [IImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iimage/) είναι μια διεπαφή που σας επιτρέπει να εργάζεστε με εικόνες που ορίζονται από δεδομένα εικονοστοιχείων. Μπορείτε να χρησιμοποιήσετε αυτή τη διεπαφή για να αποθηκεύετε εικόνες σε ένα ευρύ φάσμα μορφών (BMP, JPG, PNG κ.ά.).

## **Μετατροπή διαφανειών σε bitmap και αποθήκευση των εικόνων σε PNG**

Μπορείτε να μετατρέψετε μια διαφάνεια σε αντικείμενο bitmap και να το χρησιμοποιήσετε άμεσα στην εφαρμογή σας. Εναλλακτικά, μπορείτε να μετατρέψετε μια διαφάνεια σε bitmap και στη συνέχεια να αποθηκεύσετε την εικόνα σε JPEG ή οποιαδήποτε άλλη προτιμώμενη μορφή.

Αυτός ο κώδικας δείχνει πώς να μετατρέψετε την πρώτη διαφάνεια μιας παρουσίασης σε αντικείμενο bitmap και έπειτα να αποθηκεύσετε την εικόνα σε μορφή PNG:

```java 
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Μετατρέψτε την πρώτη διαφάνεια στην παρουσίαση σε bitmap.
    IImage image = presentation.getSlides().get_Item(0).getImage();
	try {
        // Αποθηκεύστε την εικόνα σε μορφή PNG.
        image.save("Slide_0.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Μετατροπή διαφανειών σε εικόνες με προσαρμοσμένα μεγέθη**

Μπορεί να χρειαστεί να λάβετε μια εικόνα συγκεκριμένου μεγέθους. Χρησιμοποιώντας μία υπερφόρτωση της μεθόδου [getImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-), μπορείτε να μετατρέψετε μια διαφάνεια σε εικόνα με συγκεκριμένες διαστάσεις (πλάτος και ύψος). 

Αυτό το παράδειγμα κώδικα δείχνει πώς να το κάνετε:

```java 
Size imageSize = new Size(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Μετατρέψτε την πρώτη διαφάνεια στην παρουσίαση σε bitmap με το καθορισμένο μέγεθος.
    IImage image = presentation.getSlides().get_Item(0).getImage(imageSize);

    try {
        // Αποθηκεύστε την εικόνα σε μορφή JPEG.
        image.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Μετατροπή διαφανειών με σημειώσεις και σχόλια σε εικόνες**

Ορισμένες διαφάνειες μπορεί να περιέχουν σημειώσεις και σχόλια.

Aspose.Slides παρέχει δύο διεπαφές — [ITiffOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itiffoptions/) και [IRenderingOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/irenderingoptions/) — που σας επιτρέπουν να ελέγχετε τη μετατροπή των διαφανειών παρουσίασης σε εικόνες. Και οι δύο διεπαφές περιλαμβάνουν τη μέθοδο `setSlidesLayoutOptions`, η οποία σας επιτρέπει να ρυθμίσετε την απόδοση των σημειώσεων και των σχολίων σε μια διαφάνεια κατά τη μετατροπή της σε εικόνα.

Με την κλάση [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/notescommentslayoutingoptions/) μπορείτε να καθορίσετε την προτιμώμενη θέση των σημειώσεων και των σχολίων στην τελική εικόνα.

Αυτός ο κώδικας δείχνει πώς να μετατρέψετε μια διαφάνεια με σημειώσεις και σχόλια:

```java 
float scaleX = 2;
float scaleY = scaleX;

// Φορτώστε ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    NotesCommentsLayoutingOptions notesCommentsOptions = new NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(NotesPositions.BottomTruncated);  // Ορίστε τη θέση των σημειώσεων.
    notesCommentsOptions.setCommentsPosition(CommentsPositions.Right);      // Ορίστε τη θέση των σχολίων.
    notesCommentsOptions.setCommentsAreaWidth(500);                         // Ορίστε το πλάτος της περιοχής σχολίων.
    notesCommentsOptions.setCommentsAreaColor(Color.LTGRAY);   // Ορίστε το χρώμα της περιοχής σχολίων.

    // Δημιουργήστε τις επιλογές απόδοσης.
    RenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);

    // Μετατρέψτε την πρώτη διαφάνεια της παρουσίασης σε εικόνα.
    IImage image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);

    try {
        // Αποθηκεύστε την εικόνα σε μορφή GIF.
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 

Σε οποιαδήποτε διαδικασία μετατροπής διαφάνειας σε εικόνα, η μέθοδος [setNotesPosition](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/inotescommentslayoutingoptions/#setNotesPosition-int-) δεν μπορεί να εφαρμόσει το `BottomFull` (για τον καθορισμό της θέσης των σημειώσεων) επειδή το κείμενο μιας σημείωσης μπορεί να είναι πολύ μεγάλο, καθιστώντας αδύνατη την προσαρμογή του στην καθορισμένη διάσταση της εικόνας.

{{% /alert %}} 

## **Μετατροπή διαφανειών σε εικόνες χρησιμοποιώντας επιλογές TIFF**

Η διεπαφή [ITiffOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itiffoptions/) προσφέρει μεγαλύτερο έλεγχο πάνω στην τελική εικόνα TIFF, επιτρέποντάς σας να καθορίσετε παραμέτρους όπως μέγεθος, ανάλυση, παλέτα χρωμάτων και άλλα.

Αυτός ο κώδικας δείχνει μια διαδικασία μετατροπής όπου οι επιλογές TIFF χρησιμοποιούνται για να παραχθεί μια ασπρόμαυρη εικόνα με ανάλυση 300 DPI και μέγεθος 2160 × 2800:

```java 
// Φορτώστε ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Πάρτε την πρώτη διαφάνεια από την παρουσίαση.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Διαμορφώστε τις ρυθμίσεις της εξαγόμενης εικόνας TIFF.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setImageSize(new Size(2160, 2880));                  // Ορίστε το μέγεθος της εικόνας.
    tiffOptions.setPixelFormat(ImagePixelFormat.Format1bppIndexed);  // Ορίστε τη μορφή εικονοστοιχείων (ασπρόμαυρη).
    tiffOptions.setDpiX(300);                                        // Ορίστε την οριζόντια ανάλυση.
    tiffOptions.setDpiY(300);                                        // Ορίστε την κάθετη ανάλυση.

    // Μετατρέψτε τη διαφάνεια σε εικόνα με τις καθορισμένες επιλογές.
    IImage image = slide.getImage(tiffOptions);

    try {
        // Αποθηκεύστε την εικόνα σε μορφή TIFF.
        image.save("output.tiff", ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Μετατροπή όλων των διαφανειών σε εικόνες**

Το Aspose.Slides σας επιτρέπει να μετατρέψετε όλες τις διαφάνειες μιας παρουσίασης σε εικόνες, μετατρέποντας ουσιαστικά ολόκληρη την παρουσίαση σε μια σειρά εικόνων.

Αυτό το παράδειγμα κώδικα δείχνει πώς να μετατρέψετε όλες τις διαφάνειες μιας παρουσίασης σε εικόνες σε Java:

```java 
float scaleX = 2;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Αποδώστε την παρουσίαση σε εικόνες διαφάνεια προς διαφάνεια.
    for (int i = 0 ; i < presentation.getSlides().size(); i++)
    {
        // Διαχειριστείτε κρυμμένες διαφάνειες (μην αποδίδετε κρυμμένες διαφάνειες).
        if (presentation.getSlides().get_Item(i).getHidden())
            continue;

        // Μετατρέψτε τη διαφάνεια σε εικόνα.
        IImage image = presentation.getSlides().get_Item(i).getImage(scaleX, scaleY);

        try {
            // Αποθηκεύστε την εικόνα σε μορφή JPEG.
            image.save("Slide_" + i + ".jpg", ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Συχνές ερωτήσεις**

**Υποστηρίζει το Aspose.Slides την απόδοση διαφανειών με κινούμενα σχέδια;**

Όχι, η μέθοδος `getImage` αποθηκεύει μόνο μια στατική εικόνα της διαφάνειας, χωρίς κινούμενα σχέδια.

**Μπορούν οι κρυμμένες διαφάνειες να εξαχθούν ως εικόνες;**

Ναι, οι κρυμμένες διαφάνειες μπορούν να επεξεργαστούν όπως και οι κανονικές. Απλώς βεβαιωθείτε ότι περιλαμβάνονται στο βρόχο επεξεργασίας.

**Μπορούν οι εικόνες να αποθηκευτούν με σκιές και εφέ;**

Ναι, το Aspose.Slides υποστηρίζει την απόδοση σκιών, διαφάνειας και άλλων γραφικών εφέ κατά την αποθήκευση των διαφανειών ως εικόνες.