---
title: Μετατροπή παρουσιάσεων PowerPoint σε TIFF σε .NET
titlelink: PowerPoint σε TIFF
type: docs
weight: 90
url: /el/net/convert-powerpoint-to-tiff/
keywords:
- μετατροπή PowerPoint
- μετατροπή OpenDocument
- μετατροπή παρουσίασης
- μετατροπή διαφάνειας
- μετατροπή PPT
- μετατροπή PPTX
- PowerPoint σε TIFF
- παρουσίαση σε TIFF
- διαφάνεια σε TIFF
- PPT σε TIFF
- PPTX σε TIFF
- αποθήκευση PPT ως TIFF
- αποθήκευση PPTX ως TIFF
- εξαγωγή PPT σε TIFF
- εξαγωγή PPTX σε TIFF
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς να μετατρέπετε εύκολα παρουσιάσεις PowerPoint (PPT, PPTX) σε εικόνες TIFF υψηλής ποιότητας χρησιμοποιώντας το Aspose.Slides για .NET. Παραδείγματα κώδικα C#."
---
## **Εισαγωγή**

TIFF (**Tagged Image File Format**) είναι μια ευρέως χρησιμοποιούμενη, μη απωλεστική μορφή ραστερ εικόνας γνωστή για την εξαιρετική της ποιότητα και την λεπτομερή διατήρηση των γραφικών. Σχεδιαστές, φωτογράφοι και desktop publishers συχνά επιλέγουν TIFF για τη διατήρηση των στρωμάτων, της ακρίβειας χρωμάτων και των αρχικών ρυθμίσεων στις εικόνες τους.

Χρησιμοποιώντας το Aspose.Slides, μπορείτε εύκολα να μετατρέψετε τις διαφάνειες PowerPoint (PPT, PPTX) και OpenDocument (ODP) απευθείας σε εικόνες TIFF υψηλής ποιότητας, διασφαλίζοντας ότι οι παρουσιάσεις σας διατηρούν τη μέγιστη οπτική πιστότητα.

## **Μετατροπή Παρουσίασης σε TIFF**

Χρησιμοποιώντας τη μέθοδο [Save](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/save/) που παρέχεται από την κλάση [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) μπορείτε γρήγορα να μετατρέψετε ολόκληρη μια παρουσίαση PowerPoint σε TIFF. Οι παραγόμενες εικόνες TIFF αντιστοιχούν στο προεπιλεγμένο μέγεθος διαφάνειας.

Αυτός ο κώδικας C# δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε TIFF:

```cs
// Δημιουργία ενός αντικειμένου της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης (PPT, PPTX, ODP, κ.λπ.).
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    // Αποθήκευση της παρουσίασης ως TIFF.
    presentation.Save("Output.tiff", SaveFormat.Tiff);
}
```

## **Μετατροπή Παρουσίασης σε Μαύρο-Άσπρο TIFF**

Η ιδιότητα [BwConversionMode](https://reference.aspose.com/slides/el/net/aspose.slides.export/tiffoptions/bwconversionmode/) στην κλάση [TiffOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/tiffoptions/) σάς επιτρέπει να ορίσετε τον αλγόριθμο που χρησιμοποιείται κατά τη μετατροπή μιας έγχρωμης διαφάνειας ή εικόνας σε μαύρο-άσπρο TIFF. Σημειώστε ότι αυτή η ρύθμιση εφαρμόζεται μόνο όταν η ιδιότητα [CompressionType](https://reference.aspose.com/slides/el/net/aspose.slides.export/tiffoptions/compressiontype/) έχει οριστεί σε `CCITT4` ή `CCITT3`.

Ας πούμε ότι έχουμε ένα αρχείο "sample.pptx" με την ακόλουθη διαφάνεια:

![Διαφάνεια παρουσίασης](slide_black_and_white.png)

Αυτός ο κώδικας C# δείχνει πώς να μετατρέψετε τη χρωματιστή διαφάνεια σε μαύρο-άσπρο TIFF:

```cs
TiffOptions tiffOptions = new TiffOptions
{
    CompressionType = TiffCompressionTypes.CCITT4,
    BwConversionMode = BlackWhiteConversionMode.Dithering
};

using (Presentation presentation = new Presentation("sample.pptx"))
{
    presentation.Save("output.tiff", SaveFormat.Tiff, tiffOptions);
}
```

Το αποτέλεσμα:

![Μαύρο-Άσπρο TIFF](TIFF_black_and_white.png)

## **Μετατροπή Παρουσίασης σε TIFF με Προσαρμοσμένο Μέγεθος**

Εάν χρειάζεστε εικόνα TIFF με συγκεκριμένες διαστάσεις, μπορείτε να ορίσετε τις επιθυμητές τιμές χρησιμοποιώντας τις ιδιότητες που διατίθενται στην κλάση [TiffOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/tiffoptions/). Για παράδειγμα, η ιδιότητα [ImageSize](https://reference.aspose.com/slides/el/net/aspose.slides.export/tiffoptions/imagesize/) σας επιτρέπει να ορίσετε το μέγεθος της παραγόμενης εικόνας.

Αυτός ο κώδικας C# δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε εικόνες TIFF με προσαρμοσμένο μέγεθος:

```cs
// Δημιουργία ενός αντικειμένου της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης (PPT, PPTX, ODP κ.λπ.).
using (Presentation presentation = new Presentation("sample.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();

    // Ορισμός του τύπου συμπίεσης.
    tiffOptions.CompressionType = TiffCompressionTypes.Default;
    /* 
    Τύποι συμπίεσης:
        Default - Καθορίζει το προεπιλεγμένο σχήμα συμπίεσης (LZW).
        None - Καθορίζει ότι δεν υπάρχει συμπίεση.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // Το βάθος εξαρτάται από τον τύπο συμπίεσης και δεν μπορεί να οριστεί χειροκίνητα.

    // Ορισμός του DPI της εικόνας.
    tiffOptions.DpiX = 200;
    tiffOptions.DpiY = 200;

    // Ορισμός του μεγέθους της εικόνας.
    tiffOptions.ImageSize = new Size(1728, 1078);

    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    // Αποθήκευση της παρουσίασης ως TIFF με το καθορισμένο μέγεθος.
    presentation.Save("custom_size.tiff", SaveFormat.Tiff, tiffOptions);
}
```

## **Μετατροπή Παρουσίασης σε TIFF με Προσαρμοσμένη Μορφή Pixel Εικόνας**

Χρησιμοποιώντας την ιδιότητα [PixelFormat](https://reference.aspose.com/slides/el/net/aspose.slides.export/tiffoptions/pixelformat/) από την κλάση [TiffOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/tiffoptions) μπορείτε να καθορίσετε την προτιμώμενη μορφή pixel για την τελική εικόνα TIFF.

Αυτός ο κώδικας C# δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε εικόνα TIFF με προσαρμοσμένη μορφή pixel:

```cs
// Δημιουργία ενός αντικειμένου της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης (PPT, PPTX, ODP, κ.λπ.).
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();
   
    tiffOptions.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    Το ImagePixelFormat περιέχει τις παρακάτω τιμές (σύμφωνα με την τεκμηρίωση):
        Format1bppIndexed - 1 bit ανά pixel, με ευρετήριο.
        Format4bppIndexed - 4 bits ανά pixel, με ευρετήριο.
        Format8bppIndexed - 8 bits ανά pixel, με ευρετήριο.
        Format24bppRgb    - 24 bits ανά pixel, RGB.
        Format32bppArgb   - 32 bits ανά pixel, ARGB.
    */

    // Αποθήκευση της παρουσίασης ως TIFF με το καθορισμένο μέγεθος εικόνας.
    presentation.Save("Custom_Image_Pixel_Format.tiff", SaveFormat.Tiff, tiffOptions);
}
```

{{% alert title="Tip" color="primary" %}}
Δείτε τον [Δωρεάν Μετατροπέας PowerPoint σε Αφίσα του Aspose](https://products.aspose.app/slides/el/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Μπορώ να μετατρέψω μία μόνο διαφάνεια αντί για ολόκληρη την παρουσίαση PowerPoint σε TIFF;**

Ναι. Το Aspose.Slides σάς επιτρέπει να μετατρέψετε ξεχωριστές διαφάνειες από παρουσιάσεις PowerPoint και OpenDocument σε εικόνες TIFF χωριστά.

**Υπάρχει κάποιο όριο στον αριθμό των διαφανειών κατά τη μετατροπή μιας παρουσίασης σε TIFF;**

Όχι, το Aspose.Slides δεν επιβάλλει περιορισμούς στον αριθμό των διαφανειών. Μπορείτε να μετατρέψετε παρουσιάσεις οποιουδήποτε μεγέθους σε μορφή TIFF.

**Διατηρούνται οι κινήσεις και τα εφέ μετάβασης του PowerPoint όταν μετατρέπονται οι διαφάνειες σε TIFF;**

Όχι, το TIFF είναι στατική μορφή εικόνας. Επομένως, οι κινήσεις και τα εφέ μετάβασης δεν διατηρούνται· εξάγονται μόνο στατικές στιγμιότυπες των διαφανειών.