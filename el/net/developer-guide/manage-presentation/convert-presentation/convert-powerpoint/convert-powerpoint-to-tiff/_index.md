---
title: Μετατροπή Παρουσίασεων PowerPoint σε TIFF στο .NET
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

TIFF (**Tagged Image File Format**) είναι μια ευρέως χρησιμοποιούμενη, μη απωλεστική μορφή ραστερ εικόνας γνωστή για την εξαιρετική ποιότητά της και τη λεπτομερή διατήρηση γραφικών. Σχεδιαστές, φωτογράφοι και εκδότες επιφάνειας εργασίας συχνά επιλέγουν TIFF για να διατηρήσουν στρώματα, ακρίβεια χρωμάτων και αρχικές ρυθμίσεις στις εικόνες τους.

Με το Aspose.Slides, μπορείτε εύκολα να μετατρέψετε τις διαφάνειες PowerPoint (PPT, PPTX) και τις διαφάνειες OpenDocument (ODP) άμεσα σε εικόνες TIFF υψηλής ποιότητας, διασφαλίζοντας ότι οι παρουσιάσεις σας διατηρούν τη μέγιστη οπτική πιστότητα.

## **Μετατροπή Παρουσίασης σε TIFF**

Χρησιμοποιώντας τη μέθοδο [Save](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/save/) που παρέχεται από την κλάση [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/), μπορείτε γρήγορα να μετατρέψετε ολόκληρη μια παρουσίαση PowerPoint σε TIFF. Οι προκύπτουσες εικόνες TIFF αντιστοιχούν στο προεπιλεγμένο μέγεθος διαφάνειας.

Αυτός ο κώδικας C# δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε TIFF:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Δημιουργία ενός αντικειμένου της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης (PPT, PPTX, ODP, κλπ).
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    // Αποθήκευση της παρουσίασης ως TIFF.
    presentation.Save("Output.tiff", SaveFormat.Tiff);
}
```

## **Μετατροπή Παρουσίασης σε Ασπρόμαυρο TIFF**

Η ιδιότητα [BwConversionMode](https://reference.aspose.com/slides/el/net/aspose.slides.export/tiffoptions/bwconversionmode/) στην κλάση [TiffOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/tiffoptions/) σας επιτρέπει να καθορίσετε τον αλγόριθμο που χρησιμοποιείται κατά τη μετατροπή μιας χρωματιστής διαφάνειας ή εικόνας σε ασπρόμαυρο TIFF. Σημειώστε ότι αυτή η ρύθμιση εφαρμόζεται μόνο όταν η ιδιότητα [CompressionType](https://reference.aspose.com/slides/el/net/aspose.slides.export/tiffoptions/compressiontype/) ορίζεται σε `CCITT4` ή `CCITT3`.

{{% alert color="info" title="Σημείωση" %}}

[TiffOptions.BwConversionMode](https://reference.aspose.com/slides/el/net/aspose.slides.export/tiffoptions/bwconversionmode/) είναι ρύθμιση επιπέδου εξαγωγής που επιλέγει αλγόριθμο μετατροπής pixel για ολόκληρη την εικόνα TIFF. Για να ορίσετε πώς θα εμφανίζεται ένα συγκεκριμένο σχήμα όταν είναι ενεργή η ασπρόμαυρη λειτουργία, χρησιμοποιήστε το [IShape.BlackWhiteMode](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/blackwhitemode/). Δείτε το [Control Black-and-White Rendering for Shapes](/slides/el/net/shape-formatting/#control-black-and-white-rendering-for-shapes) για παραδείγματα.

{{% /alert %}}

Ας υποθέσουμε ότι έχουμε ένα αρχείο "sample.pptx" με την ακόλουθη διαφάνεια:

![A presentation slide](slide_black_and_white.png)

Αυτός ο κώδικας C# δείχνει πώς να μετατρέψετε τη χρωματιστή διαφάνεια σε ασπρόμαυρο TIFF:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

![Black-and-White TIFF](TIFF_black_and_white.png)

## **Μετατροπή Παρουσίασης σε TIFF με Προσαρμοσμένο Μέγεθος**

Εάν χρειάζεστε μια εικόνα TIFF με συγκεκριμένες διαστάσεις, μπορείτε να ορίσετε τις επιθυμητές τιμές χρησιμοποιώντας τις ιδιότητες της κλάσης [TiffOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/tiffoptions/). Για παράδειγμα, η ιδιότητα [ImageSize](https://reference.aspose.com/slides/el/net/aspose.slides.export/tiffoptions/imagesize/) σας επιτρέπει να καθορίσετε το μέγεθος της προκύπτουσας εικόνας.

Αυτός ο κώδικας C# δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε εικόνες TIFF με προσαρμοσμένο μέγεθος:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Δημιουργία ενός αντικειμένου της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης (PPT, PPTX, ODP, κλπ).
using (Presentation presentation = new Presentation("sample.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();

    // Ορισμός τύπου συμπίεσης.
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

    // Ορισμός DPI εικόνας.
    tiffOptions.DpiX = 200;
    tiffOptions.DpiY = 200;

    // Ορισμός μεγέθους εικόνας.
    tiffOptions.ImageSize = new Size(1728, 1078);

    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    // Αποθήκευση της παρουσίασης ως TIFF με το καθορισμένο μέγεθος.
    presentation.Save("custom_size.tiff", SaveFormat.Tiff, tiffOptions);
}
```

## **Μετατροπή Παρουσίασης σε TIFF με Προσαρμοσμένη Μορφή Πιξελών Εικόνας**

Χρησιμοποιώντας την ιδιότητα [PixelFormat](https://reference.aspose.com/slides/el/net/aspose.slides.export/tiffoptions/pixelformat/) της κλάσης [TiffOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/tiffoptions), μπορείτε να καθορίσετε την προτιμώμενη μορφή πιξελών για την τελική εικόνα TIFF.

Αυτός ο κώδικας C# δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε εικόνα TIFF με προσαρμοσμένη μορφή πιξελών:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Δημιουργία ενός αντικειμένου της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης (PPT, PPTX, ODP, κλπ).
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();
   
    tiffOptions.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    ImagePixelFormat περιέχει τις ακόλουθες τιμές (σύμφωνα με την τεκμηρίωση):
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

{{% alert title="Συμβουλή" color="info" %}}

Δοκιμάστε τον [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/el/conversion/convert-ppt-to-poster-online) της Aspose.

{{% /alert %}}

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Μπορώ να μετατρέψω μια μεμονωμένη διαφάνεια αντί για ολόκληρη παρουσίαση PowerPoint σε TIFF;**

Ναι. Το Aspose.Slides σας επιτρέπει να μετατρέψετε μεμονωμένες διαφάνειες από παρουσιάσεις PowerPoint και OpenDocument σε εικόνες TIFF ξεχωριστά.

**Υπάρχει κάποιο όριο στον αριθμό των διαφανειών κατά τη μετατροπή μιας παρουσίασης σε TIFF;**

Όχι, το Aspose.Slides δεν επιβάλλει περιορισμούς στον αριθμό των διαφανειών. Μπορείτε να μετατρέψετε παρουσιάσεις οποιουδήποτε μεγέθους σε μορφή TIFF.

**Διατηρούνται οι κινούμενες εικόνες και τα εφέ μετάβασης του PowerPoint όταν οι διαφάνειες μετατρέπονται σε TIFF;**

Όχι, το TIFF είναι στατική μορφή εικόνας. Συνεπώς, τα κινούμενα στοιχεία και τα εφέ μετάβασης δεν διατηρούνται· εξάγονται μόνο στατικές στιγμιότυπες των διαφανειών.