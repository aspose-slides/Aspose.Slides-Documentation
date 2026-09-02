---
title: Μετατροπή διαφανειών παρουσίασης σε εικόνες σε Android
linktitle: Διαφάνεια σε Εικόνα
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
description: "Μετατρέψτε διαφάνειες από PPT, PPTX και ODP σε εικόνες χρησιμοποιώντας Aspose.Slides για Android—γρήγορη, υψηλής ποιότητας απόδοση με σαφή παραδείγματα κώδικα Java."
---
## **Εισαγωγή**

Aspose.Slides for Android via Java σας επιτρέπει να μετατρέπετε εύκολα διαφάνειες PowerPoint και OpenDocument παρουσίασης σε διάφορες μορφές εικόνας, όπως BMP, PNG, JPG (JPEG), GIF και άλλες.

Για να μετατρέψετε μια διαφάνεια σε εικόνα, ακολουθήστε τα παρακάτω βήματα:

1. Ορίστε τις επιθυμητές ρυθμίσεις μετατροπής και επιλέξτε τις διαφάνειες που θέλετε να εξάγετε χρησιμοποιώντας:
    - Το [ITiffOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itiffoptions/) interface, ή
    - Το [IRenderingOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/irenderingoptions/) interface.
2. Δημιουργήστε την εικόνα της διαφάνειας καλώντας τη μέθοδο [getImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islide/#getImage--) .

Στο Aspose.Slides for Android via Java, ένα [IImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iimage/) είναι ένα interface που σας επιτρέπει να εργάζεστε με εικόνες που ορίζονται από δεδομένα pixel. Μπορείτε να χρησιμοποιήσετε αυτό το interface για να αποθηκεύσετε εικόνες σε ευρύ φάσμα μορφών (BMP, JPG, PNG κ.λπ.).

## **Μετατροπή διαφανειών σε bitmap και αποθήκευση των εικόνων σε PNG**

Μπορείτε να μετατρέψετε μια διαφάνεια σε αντικείμενο bitmap και να το χρησιμοποιήσετε απευθείας στην εφαρμογή σας. Εναλλακτικά, μπορείτε να μετατρέψετε μια διαφάνεια σε bitmap και στη συνέχεια να αποθηκεύσετε την εικόνα σε JPEG ή οποιαδήποτε άλλη προτιμώμενη μορφή.

Αυτός ο κώδικας δείχνει πώς να μετατρέψετε την πρώτη διαφάνεια μιας παρουσίασης σε αντικείμενο bitmap και στη συνέχεια να αποθηκεύσετε την εικόνα σε μορφή PNG:

```java 
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Μετατρέψτε την πρώτη διαφάνεια στην παρουσίαση σε bitmap.
    IImage image = presentation.getSlides().get_Item(0).getImage();
	try {
        // Αποθηκεύστε την εικόνα στη μορφή PNG.
        image.save("Slide_0.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Μετατροπή διαφανειών σε εικόνες με προσαρμοσμένα μεγέθη**

Μπορεί να χρειαστεί να λάβετε μια εικόνα με συγκεκριμένο μέγεθος. Χρησιμοποιώντας μια υπερφόρτωση της [getImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) , μπορείτε να μετατρέψετε μια διαφάνεια σε εικόνα με συγκεκριμένες διαστάσεις (πλάτος και ύψος).

Αυτό το δείγμα κώδικα δείχνει πώς γίνεται αυτό:

```java 
Size imageSize = new Size(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Μετατρέψτε την πρώτη διαφάνεια στην παρουσίαση σε bitmap με το καθορισμένο μέγεθος.
    IImage image = presentation.getSlides().get_Item(0).getImage(imageSize);

    try {
        // Αποθηκεύστε την εικόνα στη μορφή JPEG.
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

Το Aspose.Slides παρέχει δύο interfaces—[ITiffOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itiffoptions/) και [IRenderingOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/irenderingoptions/)—που επιτρέπουν τον έλεγχο της απόδοσης των διαφανειών παρουσίασης σε εικόνες. Και τα δύο interfaces περιλαμβάνουν τη μέθοδο `setSlidesLayoutOptions`, η οποία σας δίνει τη δυνατότητα να διαμορφώσετε την απόδοση των σημειώσεων και των σχολίων σε μια διαφάνεια κατά τη μετατροπή της σε εικόνα.

Με την κλάση [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/notescommentslayoutingoptions/) μπορείτε να καθορίσετε την προτιμώμενη θέση των σημειώσεων και των σχολίων στην τελική εικόνα.

Αυτός ο κώδικας δείχνει πώς να μετατρέψετε μια διαφάνεια με σημειώσεις και σχόλια:

```java 
float scaleX = 2;
float scaleY = scaleX;

// Φορτώστε ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    NotesCommentsLayoutingOptions notesCommentsOptions = new NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(NotesPositions.BottomTruncated);  // Ορίζει τη θέση των σημειώσεων.
    notesCommentsOptions.setCommentsPosition(CommentsPositions.Right);      // Ορίζει τη θέση των σχολίων.
    notesCommentsOptions.setCommentsAreaWidth(500);                         // Ορίζει το πλάτος της περιοχής σχολίων.
    notesCommentsOptions.setCommentsAreaColor(Color.LTGRAY);   // Ορίζει το χρώμα της περιοχής σχολίων.

    // Δημιουργεί τις επιλογές απόδοσης.
    RenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);

    // Μετατρέπει την πρώτη διαφάνεια της παρουσίασης σε εικόνα.
    IImage image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);

    try {
        // Αποθηκεύει την εικόνα στη μορφή GIF.
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Σημείωση" color="warning" %}} 

Σε οποιαδήποτε διαδικασία μετατροπής διαφάνειας σε εικόνα, η μέθοδος [setNotesPosition](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/inotescommentslayoutingoptions/#setNotesPosition-int-) δεν μπορεί να εφαρμόσει το `BottomFull` (για καθορισμό της θέσης των σημειώσεων) επειδή το κείμενο μιας σημείωσης μπορεί να είναι πολύ μεγάλο, κάνοντας αδύνατη την προσαρμογή του στο καθορισμένο μέγεθος εικόνας.

{{% /alert %}} 

## **Μετατροπή διαφανειών σε εικόνες χρησιμοποιώντας TIFF Options**

Το interface [ITiffOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itiffoptions/) παρέχει μεγαλύτερο έλεγχο της τελικής εικόνας TIFF επιτρέποντας τον καθορισμό παραμέτρων όπως μέγεθος, ανάλυση, παλέτα χρωμάτων κ.λπ.

Αυτός ο κώδικας δείχνει μια διαδικασία μετατροπής όπου οι ρυθμίσεις TIFF χρησιμοποιούνται για την παραγωγή μιας ασπρόμαυρης εικόνας με ανάλυση 300 DPI και μέγεθος 2160 × 2800:

```java 
// Φορτώστε ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Αποκτήστε την πρώτη διαφάνεια από την παρουσίαση.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Διαμορφώστε τις ρυθμίσεις της εξόδου εικόνας TIFF.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setImageSize(new Size(2160, 2880));                  // Ορίζει το μέγεθος της εικόνας.
    tiffOptions.setPixelFormat(ImagePixelFormat.Format1bppIndexed);  // Ορίζει τη μορφή pixel (μαύρο και άσπρο).
    tiffOptions.setDpiX(300);                                        // Ορίζει την οριζόντια ανάλυση.
    tiffOptions.setDpiY(300);                                        // Ορίζει την κάθετη ανάλυση.

    // Μετατρέπει τη διαφάνεια σε εικόνα με τις καθορισμένες επιλογές.
    IImage image = slide.getImage(tiffOptions);

    try {
        // Αποθηκεύει την εικόνα σε μορφή TIFF.
        image.save("output.tiff", ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Μετατροπή όλων των διαφανειών σε εικόνες**

Το Aspose.Slides σας επιτρέπει να μετατρέψετε όλες τις διαφάνειες μιας παρουσίασης σε εικόνες, μετατρέποντας ουσιαστικά ολόκληρη την παρουσίαση σε σειρά εικόνων.

Αυτό το δείγμα κώδικα δείχνει πώς να μετατρέψετε όλες τις διαφάνειες μιας παρουσίασης σε εικόνες σε Java:

```java 
float scaleX = 2;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Αποδίδει την παρουσίαση σε εικόνες, διαφάνεια προς διαφάνεια.
    for (int i = 0 ; i < presentation.getSlides().size(); i++)
    {
        // Διαχειρίζεται τις κρυμμένες διαφάνειες (μη απόδοση κρυμμένων διαφανειών).
        if (presentation.getSlides().get_Item(i).getHidden())
            continue;

        // Μετατρέπει τη διαφάνεια σε εικόνα.
        IImage image = presentation.getSlides().get_Item(i).getImage(scaleX, scaleY);

        try {
            // Αποθηκεύει την εικόνα στη μορφή JPEG.
            image.save("Slide_" + i + ".jpg", ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Απόδοση έγχρωμων Emoji**

{{% alert title="Σημείωση" color="warning" %}} 
Για σωστή απόδοση έγχρωμων emoji κατά τη μετατροπή διαφανειών παρουσίασης σε εικόνες, οι γραμματοσειρές emoji που χρησιμοποιούνται στην παρουσίαση πρέπει να είναι εγκατεστημένες και διαθέσιμες στο σύστημα που εκτελεί τη μετατροπή. Για παράδειγμα, εάν η παρουσίαση χρησιμοποιεί **Segoe UI Emoji** και αυτή η γραμματοσειρά λείπει, τα emoji μπορεί να εμφανιστούν μονόχρωμα στις εικόνες εξόδου.
{{% /alert %}}

## **Συχνές ερωτήσεις**

**Υποστηρίζει το Aspose.Slides την απόδοση διαφανειών με κινούμενα σχέδια;**

Όχι, η μέθοδος `getImage` αποθηκεύει μόνο μια στατική εικόνα της διαφάνειας, χωρίς κινούμενα σχέδια.

**Μπορούν οι κρυμμένες διαφάνειες να εξαχθούν ως εικόνες;**

Ναι, οι κρυμμένες διαφάνειες μπορούν να υποβληθούν σε επεξεργασία όπως και οι κανονικές. Απλώς βεβαιωθείτε ότι περιλαμβάνονται στον βρόχο επεξεργασίας.

**Μπορούν οι εικόνες να αποθηκευτούν με σκιά και εφέ;**

Ναι, το Aspose.Slides υποστηρίζει την απόδοση σκιάς, διαφάνειας και άλλων γραφικών εφέ κατά την αποθήκευση των διαφανειών ως εικόνες.