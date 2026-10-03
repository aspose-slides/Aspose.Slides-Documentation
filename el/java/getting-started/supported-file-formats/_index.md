---
title: Υποστηριζόμενες Μορφές Αρχείων
type: docs
weight: 106
url: /el/java/supported-file-formats/
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
- Java
- Aspose.Slides
description: "Δείτε ποιες μορφές αρχείων μπορεί το Aspose.Slides for Java να φορτώσει, εισάγει, αποθηκεύσει και αποδώσει, και ποιο API διαβάζει ή γράφει καθεμία."
---
## **Επισκόπηση**

Aspose.Slides for Java ανοίγει και αποθηκεύει παρουσιάσεις PowerPoint και OpenDocument. Επίσης, εισάγει περιεχόμενο PDF και HTML στις διαφάνειες, αποθηκεύει παρουσιάσεις σε μορφές εγγράφου, ιστού και εικόνας, και αποδίδει μεμονωμένες διαφάνειες και σχήματα ως εικόνες. Αυτό το άρθρο απαριθμεί κάθε υποστηριζόμενη μορφή και ονομάζει το API που τη διαβάζει ή τη γράφει.

Για μια επισκόπηση των λειτουργιών επεξεργασίας, δείτε [Επισκόπηση Χαρακτηριστικών](/slides/el/java/features-overview/).

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

{{% alert color="info" title="Σημείωση" %}}

Παρουσιάσεις που αποθηκεύτηκαν με PowerPoint 95 και παλαιότερες εκδόσεις δεν μπορούν να ανοιχτούν. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) αναγνωρίζει αρχείο PowerPoint 95 και αναφέρει `LoadFormat.Ppt95`, αλλά ο κατασκευαστής [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#Presentation-java.lang.String-)  πετάει [PptUnsupportedFormatException](https://reference.aspose.com/slides/el/java/com.aspose.slides/pptunsupportedformatexception/) για αυτό.

{{% /alert %}}

## **Υποστηριζόμενες Μορφές Αρχείων**

Ο πίνακας χρησιμοποιεί τέσσερις λειτουργίες:

- **Φόρτωση**: ο κατασκευαστής [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) ανοίγει το αρχείο ως επεξεργάσιμη παρουσίαση.
- **Εισαγωγή**: μια μέθοδος [SlideCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/slidecollection/) δημιουργεί διαφάνειες από το περιεχόμενο του αρχείου και τις προσθέτει σε υπάρχουσα παρουσίαση. Ο κατασκευαστής Presentation δεν μετατρέπει αυτά τα αρχεία σε διαφάνειες.
- **Αποθήκευση**: [Presentation.save](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#save-java.lang.String-int-) γράφει την παρουσίαση σε αρχείο ή ροή. Κάθε μορφή εκτός από XAML επιλέγεται με τιμή [SaveFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/saveformat/).
- **Απόδοση**: μια μέθοδος απόδοσης σχεδιάζει μια διαφάνεια ή ένα σχήμα ως εικόνα. Οι μορφές που αποδίδονται μόνο δεν είναι τιμές SaveFormat.

|**Μορφή**|**Περιγραφή**|**Φόρτωση / Εισαγωγή**|**Αποθήκευση / Απόδοση**|**API**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|Παρουσίαση PowerPoint 97-2003|Φόρτωση|Αποθήκευση|`LoadFormat.Ppt`, `SaveFormat.Ppt`|
|[POT](https://docs.fileformat.com/presentation/pot/)|Πρότυπο PowerPoint 97-2003|Φόρτωση|Αποθήκευση|`LoadFormat.Pot`, `SaveFormat.Pot`|
|[PPS](https://docs.fileformat.com/presentation/pps/)|Παρουσίαση Διαφάνειας PowerPoint 97-2003|Φόρτωση|Αποθήκευση|`LoadFormat.Pps`, `SaveFormat.Pps`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|Παρουσίαση PowerPoint|Φόρτωση|Αποθήκευση|`LoadFormat.Pptx`, `SaveFormat.Pptx`|
|[POTX](https://docs.fileformat.com/presentation/potx/)|Πρότυπο PowerPoint|Φόρτωση|Αποθήκευση|`LoadFormat.Potx`, `SaveFormat.Potx`|
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|Παρουσίαση Διαφάνειας PowerPoint|Φόρτωση|Αποθήκευση|`LoadFormat.Ppsx`, `SaveFormat.Ppsx`|
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|Παρουσίαση PowerPoint με Μακροεντολές|Φόρτωση|Αποθήκευση|`LoadFormat.Pptm`, `SaveFormat.Pptm`|
|[POTM](https://docs.fileformat.com/presentation/potm/)|Πρότυπο PowerPoint με Μακροεντολές|Φόρτωση|Αποθήκευση|`LoadFormat.Potm`, `SaveFormat.Potm`|
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|Παρουσίαση Διαφάνειας PowerPoint με Μακροεντολές|Φόρτωση|Αποθήκευση|`LoadFormat.Ppsm`, `SaveFormat.Ppsm`|
|[ODP](https://docs.fileformat.com/presentation/odp/)|Παρουσίαση OpenDocument|Φόρτωση|Αποθήκευση|`LoadFormat.Odp`, `SaveFormat.Odp`|
|FODP|Παρουσίαση Flat XML OpenDocument|Φόρτωση|Αποθήκευση|`LoadFormat.Fodp`, `SaveFormat.Fodp`|
|[OTP](https://docs.fileformat.com/presentation/otp/)|Πρότυπο Παρουσίασης OpenDocument|Φόρτωση|Αποθήκευση|`LoadFormat.Otp`, `SaveFormat.Otp`|
|[XML](https://docs.fileformat.com/web/xml/)|Παρουσίαση PowerPoint XML|Φόρτωση|Αποθήκευση|`SaveFormat.Xml`; loaded files report `SourceFormat.Xml` (there is no `LoadFormat` value)|
|[PDF](https://docs.fileformat.com/pdf/)|Portable Document Format|Εισαγωγή|Αποθήκευση|`SlideCollection.addFromPdf`; `SaveFormat.Pdf`|
|[HTML](https://docs.fileformat.com/web/html/)|Hypertext Markup Language|Εισαγωγή|Αποθήκευση|`SlideCollection.addFromHtml`, `SlideCollection.insertFromHtml`; `SaveFormat.Html`, `SaveFormat.Html5`|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML Paper Specification|—|Αποθήκευση|`SaveFormat.Xps`|
|[TIFF](https://docs.fileformat.com/image/tiff/)|Tagged Image File Format|—|Αποθήκευση, Απόδοση|`SaveFormat.Tiff` (one page per slide); `ImageFormat.Tiff` (one slide)|
|[GIF](https://docs.fileformat.com/image/gif/)|Graphics Interchange Format|—|Αποθήκευση, Απόδοση|`SaveFormat.Gif` (animated, all slides); `ImageFormat.Gif` (one slide)|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Small Web Format (Flash)|—|Αποθήκευση|`SaveFormat.Swf`|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|Αποθήκευση|`SaveFormat.Md`|
|[XAML](https://docs.fileformat.com/web/xaml/)|Extensible Application Markup Language|—|Αποθήκευση|`Presentation.save(IXamlOptions)`, one XAML file per slide; not a `SaveFormat` value|
|[PNG](https://docs.fileformat.com/image/png/)|Portable Network Graphics|—|Απόδοση|`ImageFormat.Png`|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|JPEG Image|—|Απόδοση|`ImageFormat.Jpeg`|
|[BMP](https://docs.fileformat.com/image/bmp/)|Bitmap Image|—|Απόδοση|`ImageFormat.Bmp`|
|[EMF](https://docs.fileformat.com/image/emf/)|Enhanced Metafile|—|Απόδοση|`Slide.writeAsEmf`|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Scalable Vector Graphics|—|Απόδοση|`Slide.writeAsSvg`, `Shape.writeAsSvg`|

## **Φόρτωση και Εισαγωγή**

- **Φόρτωση:** Περνάτε διαδρομή αρχείου ή ροή στον κατασκευαστή [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#Presentation-java.lang.String-). Η μορφή ανιχνεύεται από το περιεχόμενο· [LoadOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/loadoptions/) παρέχει ρυθμίσεις όπως κωδικός πρόσβασης. Για να ελέγξετε ένα αρχείο πριν το ανοίξετε, καλέστε [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-), το οποίο αναφέρει μια τιμή [LoadFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/loadformat/). Αναφέρει `LoadFormat.Unknown` για PowerPoint XML, αλλά ο κατασκευαστής ανοίγει τέτοιο αρχείο, και [Presentation.getSourceFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#getSourceFormat--) τότε επιστρέφει `SourceFormat.Xml`. Δείτε [Open Presentations](/slides/el/java/open-presentation/) και [Determine the Original Presentation Format](/slides/el/java/detect-presentation-source-format/).
- **Εισαγωγή:** [SlideCollection.addFromPdf](https://reference.aspose.com/slides/el/java/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) προσθέτει μια διαφάνεια ανά σελίδα PDF στο τέλος της παρουσίασης. [SlideCollection.addFromHtml](https://reference.aspose.com/slides/el/java/com.aspose.slides/slidecollection/#addFromHtml-java.lang.String-) προσθέτει διαφάνειες που δημιουργήθηκαν από HTML, και [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/el/java/com.aspose.slides/slidecollection/#insertFromHtml-int-java.lang.String-) τις εισάγει σε συγκεκριμένη θέση. Ο κατασκευαστής Presentation δεν εισάγει: πετάει [PptUnsupportedFormatException] για αρχείο PDF και δεν μετατρέπει το markup HTML σε περιεχόμενο διαφάνειας. Δείτε [Import Presentations from PDF or HTML](/slides/el/java/import-presentation/).

## **Αποθήκευση και Απόδοση**

- **Αποθήκευση:** [Presentation.save](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#save-java.lang.String-int-) γράφει την παρουσίαση με τιμή [SaveFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/saveformat/). Υπερφορτωμένες εκδόσεις που δέχονται αντικείμενο επιλογών ελέγχουν την έξοδο, π.χ. [PdfOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/htmloptions/), [Html5Options](https://reference.aspose.com/slides/el/java/com.aspose.slides/html5options/), [TiffOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/tiffoptions/), και [GifOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/gifoptions/). Υπερφορτωμένες εκδόσεις που παίρνουν πίνακα θέσεων διαφάνειας, αρχίζοντας από 1, γράφουν μόνο αυτές τις διαφάνειες· υποστηρίζουν PDF, XPS, TIFF, HTML, HTML5, SWF, GIF και Markdown, αλλά όχι τις μορφές παρουσίασης ή PowerPoint XML. Το XAML έχει τη δική του υπερφόρτωση, [Presentation.save](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-), η οποία δέχεται [IXamlOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/ixamloptions/). Δείτε [Save Presentations](/slides/el/java/save-presentation/), [Convert Presentations](/slides/el/java/convert-presentation/), και [Export Presentations to XAML](/slides/el/java/export-to-xaml/).
- **Απόδοση:** [Slide.getImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/slide/#getImage-float-float-) και [Shape.getImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/shape/#getImage--) επιστρέφουν ένα [IImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimage/), και [IImage.save](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimage/#save-java.lang.String-int-) το γράφει ως PNG, JPEG, BMP, GIF ή TIFF, επιλεγμένο με τιμή [ImageFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/imageformat/). [Presentation.getImages](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) αποδίδει όλες ή επιλεγμένες διαφάνειες ταυτόχρονα. [Slide.writeAsSvg](https://reference.aspose.com/slides/el/java/com.aspose.slides/slide/#writeAsSvg-java.io.OutputStream-) και [Shape.writeAsSvg](https://reference.aspose.com/slides/el/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-) γράφουν SVG, και [Slide.writeAsEmf](https://reference.aspose.com/slides/el/java/com.aspose.slides/slide/#writeAsEmf-java.io.OutputStream-) γράφει EMF. Δείτε [Convert Presentation Slides to Images](/slides/el/java/convert-slide/) και [Render Presentation Slides as SVG Images](/slides/el/java/render-a-slide-as-an-svg-image/).

{{% alert color="warning" title="Προειδοποίηση" %}}

Το ImageFormat έχει επίσης τιμές `Emf`, `Wmf`, `Icon`, `Exif`, και `MemoryBmp`, αλλά το IImage.save δεν παράγει αυτές τις μορφές: το αρχείο που γράφει περιέχει δεδομένα PNG. Για να λάβετε εικόνα EMF μιας διαφάνειας, χρησιμοποιήστε Slide.writeAsEmf.

{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Μπορώ να μετατρέψω μια παρουσίαση PPT σε PPTX ή ODP;**

Ναι. Ανοίξτε το αρχείο PPT με τον κατασκευαστή Presentation και αποθηκεύστε το με `SaveFormat.Pptx` ή `SaveFormat.Odp`. Δείτε [Convert PPT to PPTX](/slides/el/java/convert-ppt-to-pptx/).

**Μπορώ να ανοίξω ένα αρχείο PDF ή HTML ως παρουσίαση;**

Όχι. Ο κατασκευαστής Presentation πετάει PptUnsupportedFormatException για αρχείο PDF και δεν μετατρέπει το markup HTML σε διαφάνειες. Δημιουργήστε ή ανοίξτε μια παρουσίαση, εισάγετε τις σελίδες PDF ή το περιεχόμενο HTML σε αυτή με τις μεθόδους της συλλογής διαφανειών που περιγράφησαν παραπάνω, και έπειτα αποθηκεύστε την σε οποιαδήποτε υποστηριζόμενη μορφή.

**Μπορώ να φορτώσω μια εξαγόμενη εικόνα PNG ή SVG ως επεξεργάσιμη παρουσίαση;**

Όχι. Η έξοδος εικόνας καταγράφει πώς φαίνεται μια διαφάνεια, όχι το κείμενο, τα σχήματα ή τα διαγράμματα. Κρατήστε την αρχική παρουσίαση εάν πρέπει να την επεξεργαστείτε αργότερα.

**Μπορώ να αποθηκεύσω έγγραφα PDF/A ή PDF/UA;**

Ναι. Περνείμετε μια τιμή [PdfCompliance](https://reference.aspose.com/slides/el/java/com.aspose.slides/pdfcompliance/) στη μέθοδο [PdfOptions.setCompliance](https://reference.aspose.com/slides/el/java/com.aspose.slides/pdfoptions/#setCompliance-int-): PDF/A-1a, PDF/A-1b, PDF/A-2a, PDF/A-2b, PDF/A-2u, PDF/A-3a, PDF/A-3b ή PDF/UA.

**Μπορώ να ελέγξω αν ένα αρχείο είναι προστατευμένο με κωδικό πριν το ανοίξω;**

Ναί. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) ελέγχει ένα αρχείο χωρίς να δημιουργήσει αντικείμενο Presentation, και [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) αναφέρει αν απαιτείται κωδικός. Δείτε [Password-Protect Presentations](/slides/el/java/password-protected-presentation/).