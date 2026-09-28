---
title: Υποστηριζόμενες Μορφές Αρχείων
type: docs
weight: 96
url: /el/net/supported-file-formats/
keywords:
- υποστηριζόμενες μορφές αρχείων
- φόρτωση παρουσίασης
- εισαγωγή PDF
- εισαγωγή HTML
- αποθήκευση παρουσίασης
- απόδοση διαφανειών
- PowerPoint
- OpenDocument
- PPT
- PPTX
- ODP
- PDF
- HTML
- XPS
- SVG
- XAML
- .NET
- C#
- Aspose.Slides
description: "Δείτε ποιες μορφές αρχείων μπορεί το Aspose.Slides για .NET να φορτώσει, να εισάγει, να αποθηκεύσει και να αποδώσει, και ποιο API διαβάζει ή γράφει την καθεμία."
---
## **Επισκόπηση**

Το Aspose.Slides για .NET ανοίγει και αποθηκεύει παρουσιάσεις PowerPoint και OpenDocument. Εισάγει επίσης περιεχόμενο PDF και HTML σε διαφάνειες, αποθηκεύει παρουσιάσεις σε μορφές εγγράφου, web και εικόνας, και αποδίδει μεμονωμένες διαφάνειες και σχήματα ως εικόνες. Αυτό το άρθρο απαριθμεί κάθε υποστηριζόμενη μορφή και ονομάζει το API που την διαβάζει ή την γράφει.

Και τα δύο πακέτα NuGet, Aspose.Slides.NET και Aspose.Slides.NET6.CrossPlatform, υποστηρίζουν τις ίδιες μορφές· δείτε [Εγκατάσταση](/slides/el/net/installation/) για να επιλέξετε μεταξύ τους. Για μια επισκόπηση των δυνατοτήτων επεξεργασίας, δείτε [Επισκόπηση Χαρακτηριστικών](/slides/el/net/features-overview/).

## **Υποστηριζόμενες Εκδόσεις Microsoft PowerPoint**

- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003
- Microsoft PowerPoint 2007
- Microsoft PowerPoint 2010
- Microsoft PowerPoint 2013
- Microsoft PowerPoint 2016
- Microsoft PowerPoint 2019
- Microsoft PowerPoint for Mac
- PowerPoint for Microsoft 365 (formerly Office 365)

{{% alert color="info" title="Note" %}}

Οι παρουσιάσεις που αποθηκεύτηκαν με το PowerPoint 95 και παλαιότερες εκδόσεις δεν μπορούν να ανοίξουν. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) αναγνωρίζει ένα αρχείο PowerPoint 95 και επιστρέφει `LoadFormat.Ppt95`, αλλά ο κατασκευαστής [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) ρίχνει [PptUnsupportedFormatException](https://reference.aspose.com/slides/net/aspose.slides/pptunsupportedformatexception/) γι' αυτό.

{{% /alert %}}

## **Υποστηριζόμενες Μορφές Αρχείων**

Ο πίνακας χρησιμοποιεί τέσσερις λειτουργίες:

- **Load**: ο κατασκευαστής [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) ανοίγει το αρχείο ως επεξεργάσιμη παρουσίαση.
- **Import**: μια μέθοδος [SlideCollection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) δημιουργεί διαφάνειες από το περιεχόμενο του αρχείου και τις προσθέτει σε υπάρχουσα παρουσίαση. Ο κατασκευαστής Presentation δεν φορτώνει αυτά τα αρχεία ως παρουσιάσεις.
- **Save**: [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) γράφει την παρουσίαση σε αρχείο ή ροή. Κάθε μορφή εκτός από XAML επιλέγεται με τιμή [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/).
- **Render**: μια μέθοδος απόδοσης σχεδιάζει μια διαφάνεια ή ένα σχήμα ως εικόνα. Οι μορφές που αποδίδονται μόνο δεν είναι τιμές SaveFormat.

|**Μορφή**|**Περιγραφή**|**Φόρτωση / Εισαγωγή**|**Αποθήκευση / Απόδοση**|**API**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|Παρουσίαση PowerPoint 97‑2003|Load|Save|`LoadFormat.Ppt`, `SaveFormat.Ppt`|
|[POT](https://docs.fileformat.com/presentation/pot/)|Πρότυπο PowerPoint 97‑2003|Load|Save|`LoadFormat.Pot`, `SaveFormat.Pot`|
|[PPS](https://docs.fileformat.com/presentation/pps/)|Παρουσίαση Διαφανειών PowerPoint 97‑2003|Load|Save|`LoadFormat.Pps`, `SaveFormat.Pps`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|Παρουσίαση PowerPoint|Load|Save|`LoadFormat.Pptx`, `SaveFormat.Pptx`|
|[POTX](https://docs.fileformat.com/presentation/potx/)|Πρότυπο PowerPoint|Load|Save|`LoadFormat.Potx`, `SaveFormat.Potx`|
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|Παρουσίαση Διαφανειών PowerPoint|Load|Save|`LoadFormat.Ppsx`, `SaveFormat.Ppsx`|
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|Παρουσίαση PowerPoint με Μακροεντολές|Load|Save|`LoadFormat.Pptm`, `SaveFormat.Pptm`|
|[POTM](https://docs.fileformat.com/presentation/potm/)|Πρότυπο PowerPoint με Μακροεντολές|Load|Save|`LoadFormat.Potm`, `SaveFormat.Potm`|
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|Παρουσίαση Διαφανειών PowerPoint με Μακροεντολές|Load|Save|`LoadFormat.Ppsm`, `SaveFormat.Ppsm`|
|[ODP](https://docs.fileformat.com/presentation/odp/)|Παρουσίαση OpenDocument|Load|Save|`LoadFormat.Odp`, `SaveFormat.Odp`|
|FODP|Παρουσίαση Flat XML OpenDocument|Load|Save|`LoadFormat.Fodp`, `SaveFormat.Fodp`|
|[OTP](https://docs.fileformat.com/presentation/otp/)|Πρότυπο Παρουσίασης OpenDocument|Load|Save|`LoadFormat.Otp`, `SaveFormat.Otp`|
|[XML](https://docs.fileformat.com/web/xml/)|Παρουσίαση PowerPoint XML|Load|Save|`SaveFormat.Xml`; loaded files report `SourceFormat.Xml` (there is no `LoadFormat` value)|
|[PDF](https://docs.fileformat.com/pdf/)|Μορφή Φορητού Εγγράφου|Import|Save|`SlideCollection.AddFromPdf`; `SaveFormat.Pdf`|
|[HTML](https://docs.fileformat.com/web/html/)|Γλώσσα Σήμανσης Υπερκειμένου|Import|Save|`SlideCollection.AddFromHtml`, `SlideCollection.InsertFromHtml`; `SaveFormat.Html`, `SaveFormat.Html5`|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|Πρότυπο Χαρτιού XML|—|Save|`SaveFormat.Xps`|
|[TIFF](https://docs.fileformat.com/image/tiff/)|Μορφή Αρχείου Ετικεταρισμένων Εικόνων|—|Save, Render|`SaveFormat.Tiff`; `ImageFormat.Tiff` (one slide)|
|[GIF](https://docs.fileformat.com/image/gif/)|Μορφή Ανταλλαγής Γραφικών|—|Save, Render|`SaveFormat.Gif` (animated, all slides); `ImageFormat.Gif` (one slide)|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Μικρή Διαδικτυακή Μορφή (Flash)|—|Save|`SaveFormat.Swf`|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|Save|`SaveFormat.Md`|
|[XAML](https://docs.fileformat.com/web/xaml/)|Επεκτάσιμη Γλώσσα Σήμανσης Εφαρμογών|—|Save|`Presentation.Save(IXamlOptions)`, one XAML file per slide; not a `SaveFormat` value|
|[PNG](https://docs.fileformat.com/image/png/)|Φορητές Γραφικές Δικτύου|—|Render|`ImageFormat.Png`|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|Εικόνα JPEG|—|Render|`ImageFormat.Jpeg`|
|[BMP](https://docs.fileformat.com/image/bmp/)|Εικόνα Bitmap|—|Render|`ImageFormat.Bmp`|
|[EMF](https://docs.fileformat.com/image/emf/)|Βελτιωμένο Μετααρχείο|—|Render|`Slide.WriteAsEmf`|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Κλιματιζόμενα Διανυσματικά Γραφικά|—|Render|`Slide.WriteAsSvg`, `Shape.WriteAsSvg`|

## **Φόρτωση και Εισαγωγή**

- **Load:** Πέρασμα διαδρομής αρχείου ή ροής στον κατασκευαστή [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/). Η μορφή ανιχνεύεται από το περιεχόμενο· το [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) παρέχει ρυθμίσεις όπως κωδικός πρόσβασης. Για να ελέγξετε ένα αρχείο πριν το ανοίξετε, καλέστε [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/), το οποίο επιστρέφει μια τιμή [LoadFormat](https://reference.aspose.com/slides/net/aspose.slides/loadformat/). Αναφέρει `LoadFormat.Unknown` για PowerPoint XML, αλλά ο κατασκευαστής ανοίγει τέτοιο αρχείο και το [Presentation.SourceFormat](https://reference.aspose.com/slides/net/aspose.slides/presentation/sourceformat/) επιστρέφει `SourceFormat.Xml`. Δείτε [Open Presentations](/slides/el/net/open-presentation/) και [Determine the Original Presentation Format](/slides/el/net/detect-presentation-source-format/).
- **Import:** Το [SlideCollection.AddFromPdf](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfrompdf/) προσθέτει μία διαφάνεια ανά σελίδα PDF στο τέλος μιας παρουσίασης. Το [SlideCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfromhtml/) προσθέτει διαφάνειες που δημιουργούνται από HTML, και το [SlideCollection.InsertFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/insertfromhtml/) τις εισάγει σε δεδομένη θέση. Ο κατασκευαστής Presentation δεν εισάγει: ρίχνει [PptUnsupportedFormatException](https://reference.aspose.com/slides/net/aspose.slides/pptunsupportedformatexception/) για αρχείο PDF και δεν μετατρέπει το markup HTML σε περιεχόμενο διαφάνειας. Δείτε [Import Presentations from PDF or HTML](/slides/el/net/import-presentation/).

## **Αποθήκευση και Απόδοση**

- **Save:** Το [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) γράφει την παρουσίαση με βάση μια τιμή [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/). Οι υπερφορτώσεις που δέχονται επίσης αντικείμενο επιλογών ελέγχουν την έξοδο, π.χ. [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/), [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/), [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/), και [GifOptions](https://reference.aspose.com/slides/net/aspose.slides.export/gifoptions/). Οι υπερφορτώσεις που δέχονται πίνακα θέσεων διαφανειών (από 1) γράφουν μόνο εκείνες τις διαφάνειες· υποστηρίζουν PDF, XPS, TIFF, HTML, HTML5, SWF, GIF και Markdown, αλλά όχι τις μορφές παρουσίασης ή PowerPoint XML. Το XAML έχει τη δική του υπερφόρτωση που δέχεται [IXamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions/). Δείτε [Save Presentations](/slides/el/net/save-presentation/), [Convert Presentations](/slides/el/net/convert-presentation/), και [Export Presentations to XAML](/slides/el/net/export-to-xaml/).
- **Render:** Τα [Slide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/) και [Shape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) επιστρέφουν ένα [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/), και το [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) το γράφει ως PNG, JPEG, BMP, GIF ή TIFF, επιλεγμένο με τιμή [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/). Το [Presentation.GetImages](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages/) αποδίδει όλες ή επιλεγμένες διαφάνειες ταυτόχρονα. Τα [Slide.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/slide/writeassvg/) και [Shape.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) γράφουν SVG, και το [Slide.WriteAsEmf](https://reference.aspose.com/slides/net/aspose.slides/slide/writeasemf/) γράφει EMF. Δείτε [Convert Presentation Slides to Images](/slides/el/net/convert-slide/) και [Render a Slide as an SVG Image](/slides/el/net/render-a-slide-as-an-svg-image/).

{{% alert color="warning" title="Warning" %}}

Το ImageFormat περιλαμβάνει επίσης τις τιμές `Emf`, `Wmf`, `Icon`, `Exif` και `MemoryBmp`, αλλά το IImage.Save δεν παράγει αυτές τις μορφές: το αρχείο που γράφει περιέχει δεδομένα PNG. Για να πάρετε εικόνα EMF από διαφάνεια, χρησιμοποιήστε Slide.WriteAsEmf.

{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Μπορώ να μετατρέψω μια παρουσίαση PPT σε PPTX ή ODP;**

Ναί. Ανοίξτε το αρχείο PPT με τον κατασκευαστή Presentation και αποθηκεύστε το με `SaveFormat.Pptx` ή `SaveFormat.Odp`. Δείτε [Convert PPT to PPTX](/slides/el/net/convert-ppt-to-pptx/).

**Μπορώ να ανοίξω ένα αρχείο PDF ή HTML ως παρουσίαση;**

Όχι. Δημιουργήστε ή ανοίξτε μια παρουσίαση, εισάγετε τις σελίδες PDF ή το περιεχόμενο HTML με τις μεθόδους συλλογής διαφανειών που περιγράφονται παραπάνω, και στη συνέχεια αποθηκεύστε τη σε οποιαδήποτε υποστηριζόμενη μορφή.

**Μπορώ να φορτώσω μια εξαγόμενη εικόνα PNG ή SVG ως επεξεργάσιμη παρουσίαση;**

Όχι. Η έξοδος εικόνας καταγράφει πώς φαίνεται μια διαφάνεια, όχι το κείμενο, τα σχήματα ή τα διαγράμματα. Διατηρήστε την αρχική παρουσίαση αν χρειάζεται να την επεξεργαστείτε αργότερα.

**Μπορώ να αποθηκεύσω έγγραφα PDF/A ή PDF/UA;**

Ναί. Ορίστε [PdfOptions.Compliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/compliance/) σε μια τιμή [PdfCompliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfcompliance/): PDF/A-1a, PDF/A-1b, PDF/A-2a, PDF/A-2b, PDF/A-2u, PDF/A-3a, PDF/A-3b ή PDF/UA.

**Μπορώ να ελέγξω αν ένα αρχείο είναι προστατευμένο με κωδικό πριν το ανοίξω;**

Ναί. Το [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) εξετάζει ένα αρχείο χωρίς να δημιουργήσει αντικείμενο Presentation, και η ιδιότητα [IsPasswordProtected](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/ispasswordprotected/) αναφέρει αν απαιτείται κωδικός. Δείτε [Password-Protect Presentations](/slides/el/net/password-protected-presentation/).

**Υποστηρίζουν τα δύο πακέτα NuGet διαφορετικές μορφές;**

Όχι. Τα Aspose.Slides.NET και Aspose.Slides.NET6.CrossPlatform έχουν τις ίδιες τιμές LoadFormat και SaveFormat και τις ίδιες μεθόδους εισαγωγής και απόδοσης. Διαφέρουν στις πλατφόρμες που τρέχουν και σε ό,τι χρειάζονται αυτές οι πλατφόρμες· δείτε [Εγκατάσταση](/slides/el/net/installation/).