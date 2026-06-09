---
title: "Μετατροπή διαφανειών παρουσίασης σε εικόνες σε C++"
linktitle: "Διαφάνεια σε εικόνα"
type: docs
weight: 41
url: /el/cpp/convert-slide/
keywords:
- "μετατροπή διαφάνειας"
- "εξαγωγή διαφάνειας"
- "διαφάνεια σε εικόνα"
- "αποθήκευση διαφάνειας ως εικόνα"
- "διαφάνεια σε PNG"
- "διαφάνεια σε JPEG"
- "διαφάνεια σε bitmap"
- "διαφάνεια σε TIFF"
- "PowerPoint"
- "OpenDocument"
- "παρουσίαση"
- "C++"
- "Aspose.Slides"
description: "Μετατρέψτε διαφάνειες από PPT, PPTX και ODP σε εικόνες σε C++ χρησιμοποιώντας το Aspose.Slides — γρήγορη, υψηλής ποιότητας απόδοση με σαφή παραδείγματα κώδικα."
---
## **Εισαγωγή**

Το Aspose.Slides για C++ σας επιτρέπει να μετατρέπετε εύκολα διαφάνειες παρουσιάσεων PowerPoint και OpenDocument σε διάφορες μορφές εικόνας, συμπεριλαμβανομένων των BMP, PNG, JPG (JPEG), GIF και άλλων.

Για να μετατρέψετε μια διαφάνεια σε εικόνα, ακολουθήστε τα παρακάτω βήματα:

1. Ορίστε τις επιθυμητές ρυθμίσεις μετατροπής και επιλέξτε τις διαφάνειες που θέλετε να εξάγετε χρησιμοποιώντας:
    - Το interface [ITiffOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/itiffoptions/) ή
    - Το interface [IRenderingOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/irenderingoptions/)
2. Δημιουργήστε την εικόνα της διαφάνειας καλώντας τη μέθοδο [GetImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/islide/getimage/).

Ένα [Bitmap](https://reference.aspose.com/slides/el/cpp/system.drawing/bitmap/) είναι ένα αντικείμενο που σας επιτρέπει να εργάζεστε με εικόνες ορισμένες από δεδομένα εικονοστοιχείων. Μπορείτε να χρησιμοποιήσετε μια παρουσία αυτής της κλάσης για να αποθηκεύσετε εικόνες σε ένα ευρύ φάσμα μορφών (BMP, JPG, PNG κλ.).

## **Μετατροπή Διαφανειών σε Bitmap και Αποθήκευση των Εικόνων σε PNG**

Μπορείτε να μετατρέψετε μια διαφάνεια σε αντικείμενο bitmap και να το χρησιμοποιήσετε άμεσα στην εφαρμογή σας. Εναλλακτικά, μπορείτε να μετατρέψετε μια διαφάνεια σε bitmap και στη συνέχεια να αποθηκεύσετε την εικόνα σε JPEG ή σε οποιαδήποτε άλλη προτιμώμενη μορφή.

Αυτός ο κώδικας C++ δείχνει πώς να μετατρέψετε την πρώτη διαφάνεια μιας παρουσίασης σε αντικείμενο bitmap και στη συνέχεια να αποθηκεύσετε την εικόνα σε μορφή PNG:

```cpp 
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Μετατρέψτε την πρώτη διαφάνεια της παρουσίασης σε bitmap.
auto image = presentation->get_Slide(0)->GetImage();

// Αποθηκεύστε την εικόνα σε μορφή PNG.
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **Μετατροπή Διαφανειών σε Εικόνες με Προσαρμοσμένα Μεγέθη**

Μπορεί να χρειαστεί να λάβετε μια εικόνα με συγκεκριμένο μέγεθος. Χρησιμοποιώντας μια υπερφόρτωση της μεθόδου [GetImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/islide/getimage/), μπορείτε να μετατρέψετε μια διαφάνεια σε εικόνα με συγκεκριμένες διαστάσεις (πλάτος και ύψος).

Αυτός ο κώδικας δείγματος δείχνει πώς να το κάνετε:

```cpp 
Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Μετατρέψτε την πρώτη διαφάνεια της παρουσίασης σε bitmap με το καθορισμένο μέγεθος.
auto image = presentation->get_Slide(0)->GetImage(imageSize);

// Αποθηκεύστε την εικόνα σε μορφή JPEG.
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **Μετατροπή Διαφανειών με Σημειώσεις και Σχόλια σε Εικόνες**

Κάποιες διαφάνειες ενδέχεται να περιέχουν σημειώσεις και σχόλια.

Το Aspose.Slides παρέχει δύο διεπαφές — [ITiffOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/itiffoptions/) και [IRenderingOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/irenderingoptions/) — που σας επιτρέπουν να ελέγχετε την απόδοση των διαφανειών παρουσίασης σε εικόνες. Και οι δύο διεπαφές περιλαμβάνουν τη μέθοδο `set_SlidesLayoutOptions`, η οποία σας επιτρέπει να διαμορφώσετε την απόδοση των σημειώσεων και των σχολίων σε μια διαφάνεια κατά τη μετατροπή της σε εικόνα.

Με την κλάση [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/notescommentslayoutingoptions/) μπορείτε να καθορίσετε την προτιμώμενη θέση των σημειώσεων και των σχολίων στην τελική εικόνα.

Αυτός ο κώδικας C++ δείχνει πώς να μετατρέψετε μια διαφάνεια με σημειώσεις και σχόλια:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

// Φορτώστε ένα αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");

auto notesCommentsOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesCommentsOptions->set_NotesPosition(NotesPositions::BottomTruncated);  // Ορίστε τη θέση των σημειώσεων.
notesCommentsOptions->set_CommentsPosition(CommentsPositions::Right);      // Ορίστε τη θέση των σχολίων.
notesCommentsOptions->set_CommentsAreaWidth(500);                          // Ορίστε το πλάτος της περιοχής σχολίων.
notesCommentsOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());    // Ορίστε το χρώμα της περιοχής σχολίων.

// Δημιουργήστε τις επιλογές απόδοσης.
auto options = MakeObject<RenderingOptions>();
options->set_SlidesLayoutOptions(notesCommentsOptions);

// Μετατρέψτε την πρώτη διαφάνεια της παρουσίασης σε εικόνα.
auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);

// Αποθηκεύστε την εικόνα σε μορφή GIF.
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Σημείωση" color="warning" %}} 

Σε οποιαδήποτε διαδικασία μετατροπής διαφάνειας σε εικόνα, η μέθοδος [set_NotesPosition](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) δεν μπορεί να εφαρμόσει το `BottomFull` (για τον καθορισμό της θέσης των σημειώσεων) επειδή το κείμενο μιας σημείωσης μπορεί να είναι πολύ μεγάλο, καθιστώντας αδύνατη την τοποθέτησή του μέσα στο καθορισμένο μέγεθος της εικόνας.

{{% /alert %}} 

## **Μετατροπή Διαφανειών σε Εικόνες Χρησιμοποιώντας Επιλογές TIFF**

Η [ITiffOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/itiffoptions/) διεπαφή παρέχει μεγαλύτερο έλεγχο της παραγόμενης εικόνας TIFF επιτρέποντάς σας να καθορίσετε παραμέτρους όπως το μέγεθος, η ανάλυση, η παλέτα χρωμάτων και άλλα.

Αυτός ο κώδικας C++ δείχνει μια διαδικασία μετατροπής όπου χρησιμοποιούνται οι επιλογές TIFF για να παραχθεί μια ασπρόμαυρη εικόνα με ανάλυση 300 DPI και μέγεθος 2160 × 2800:

```cpp 
// Φορτώστε ένα αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Λάβετε την πρώτη διαφάνεια από την παρουσίαση.
auto slide = presentation->get_Slide(0);

// Διαμορφώστε τις ρυθμίσεις της εξόδου εικόνας TIFF.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));                       // Ορίστε το μέγεθος της εικόνας.
tiffOptions->set_PixelFormat(ImagePixelFormat::Format1bppIndexed);  // Ορίστε τη μορφή εικονοστοιχείων (μαύρο και λευκό).
tiffOptions->set_DpiX(300);                                         // Ορίστε την οριζόντια ανάλυση.
tiffOptions->set_DpiY(300);                                         // Ορίστε την κατακόρυφη ανάλυση.

// Μετατρέψτε τη διαφάνεια σε εικόνα με τις καθορισμένες επιλογές.
auto image = slide->GetImage(tiffOptions);

// Αποθηκεύστε την εικόνα σε μορφή TIFF.
image->Save(u"output.bmp", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```

## **Μετατροπή Όλων των Διαφανειών σε Εικόνες**

Το Aspose.Slides σας επιτρέπει να μετατρέψετε όλες τις διαφάνειες μιας παρουσίασης σε εικόνες, μετατρέποντας αποτελεσματικά ολόκληρη την παρουσίαση σε σειρά εικόνων.

Αυτός ο κώδικας δείγματος δείχνει πώς να μετατρέψετε όλες τις διαφάνειες μιας παρουσίασης σε εικόνες σε C++:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Αποδώστε την παρουσίαση σε εικόνες διαφάνεια προς διαφάνεια.
for (int i = 0; i < presentation->get_Slides()->get_Count(); i++)
{
    // Διαχειριστείτε τις κρυμμένες διαφάνειες (να μην αποδοθούν οι κρυμμένες διαφάνειες).
    if (presentation->get_Slide(i)->get_Hidden())
    {
        continue;
    }

    // Μετατρέψτε τη διαφάνεια σε εικόνα.
    auto image = presentation->get_Slide(i)->GetImage(scaleX, scaleY);

    // Αποθηκεύστε την εικόνα σε μορφή JPEG.
    image->Save(String::Format(u"Slide_{0}.jpg", i), ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **Συχνές Ερωτήσεις**

**Υποστηρίζει το Aspose.Slides την απόδοση διαφανειών με κινούμενα σχέδια;**

Όχι, η μέθοδος `GetImage` αποθηκεύει μόνο μια στατική εικόνα της διαφάνειας, χωρίς κινούμενα σχέδια.

**Μπορούν οι κρυμμένες διαφάνειες να εξαχθούν ως εικόνες;**

Ναι, οι κρυμμένες διαφάνειες μπορούν να υποβληθούν σε επεξεργασία όπως οι κανονικές. Απλώς βεβαιωθείτε ότι περιλαμβάνονται στον βρόχο επεξεργασίας.

**Μπορούν οι εικόνες να αποθηκευτούν με σκιές και εφέ;**

Ναι, το Aspose.Slides υποστηρίζει την απόδοση σκιών, διαφάνειας και άλλων γραφικών εφέ κατά την αποθήκευση των διαφανειών ως εικόνες.