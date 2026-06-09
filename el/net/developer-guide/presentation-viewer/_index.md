---
title: Δημιουργία προβολέα παρουσίασης σε .NET
linktitle: Προβολέας Παρουσίασης
type: docs
weight: 50
url: /el/net/presentation-viewer/
keywords:
- προβολή παρουσίασης
- προβολέας παρουσίασης
- δημιουργία προβολέα παρουσίασης
- προβολή PPT
- προβολή PPTX
- προβολή ODP
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Δημιουργήστε έναν προσαρμοσμένο προβολέα παρουσίασης σε .NET χρησιμοποιώντας το Aspose.Slides. Εμφανίστε εύκολα αρχεία PowerPoint και OpenDocument χωρίς το Microsoft PowerPoint."
---
## **Εισαγωγή**

Το Aspose.Slides για .NET χρησιμοποιείται για τη δημιουργία αρχείων παρουσίασης με διαφάνειες. Αυτές οι διαφάνειες μπορούν να προβληθούν ανοίγοντας τις παρουσιάσεις στο Microsoft PowerPoint, για παράδειγμα. Ωστόσο, οι προγραμματιστές ενδέχεται μερικές φορές να χρειαστούν να εμφανίσουν τις διαφάνειες ως εικόνες στον προτιμώμενο προβολέα εικόνας ή να τις χρησιμοποιήσουν σε έναν προσαρμοσμένο προβολέα παρουσίασης. Σε τέτοιες περιπτώσεις, το Aspose.Slides σας επιτρέπει να εξάγετε μεμονωμένες διαφάνειες ως εικόνες. Αυτό το άρθρο εξηγεί πώς να το κάνετε.

## **Δημιουργία εικόνας SVG από διαφάνεια**

Για να δημιουργήσετε μια εικόνα SVG από μια διαφάνεια παρουσίασης χρησιμοποιώντας το Aspose.Slides, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
1. Αποκτήστε μια αναφορά στη διαφάνεια με το δείκτη της.
1. Ανοίξτε ένα ρεύμα αρχείου.
1. Αποθηκεύστε τη διαφάνεια ως εικόνα SVG στο ρεύμα αρχείου.

```c#
int slideIndex = 0;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (FileStream svgStream = File.Create("output.svg"))
    {
        slide.WriteAsSvg(svgStream);
    }
}
```

## **Δημιουργία SVG με προσαρμοσμένο αναγνωριστικό σχήματος**

Το Aspose.Slides μπορεί να χρησιμοποιηθεί για τη δημιουργία ενός [SVG](https://docs.fileformat.com/page-description-language/svg/) από μια διαφάνεια με προσαρμοσμένο `ID` σχήμα. Για να το επιτύχετε, χρησιμοποιήστε την ιδιότητα Id από το interface [ISvgShape](https://reference.aspose.com/slides/el/net/aspose.slides.export/isvgshape). Η κλάση `CustomSvgShapeFormattingController` μπορεί να χρησιμοποιηθεί για τον ορισμό του αναγνωριστικού σχήματος.

```c#
int slideIndex = 0;

using (Presentation presentation = new Presentation("sample.odp"))
{
    ISlide slide = presentation.Slides[slideIndex];
    
    SVGOptions svgOptions = new SVGOptions
    {
        ShapeFormattingController = new CustomSvgShapeFormattingController()
    };

    using (FileStream svgStream = File.Create("output.svg"))
    {
        slide.WriteAsSvg(svgStream, svgOptions);
    }
}
```

```c#
class CustomSvgShapeFormattingController : ISvgShapeFormattingController
{
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController(int shapeStartIndex = 0)
    {
        m_shapeIndex = shapeStartIndex;
    }

    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        svgShape.Id = string.Format("shape-{0}", m_shapeIndex++);
    }
}
```

## **Δημιουργία εικόνας μικρογραφίας διαφάνειας**

Το Aspose.Slides σας βοηθά να δημιουργήσετε μικρογραφίες διαφανειών. Για να δημιουργήσετε μια μικρογραφία μιας διαφάνειας χρησιμοποιώντας το Aspose.Slides, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
1. Αποκτήστε μια αναφορά στη διαφάνεια με το δείκτη της.
1. Δημιουργήστε μια εικόνα μικρογραφίας της αναφερόμενης διαφάνειας στην επιθυμητή κλίμακα.
1. Αποθηκεύστε τη μικρογραφία στην προτιμώμενη μορφή εικόνας.

```c#
int slideIndex = 0;
float scaleX = 1;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(scaleX, scaleY))
    {
        image.Save("output.jpg", ImageFormat.Jpeg);
    }
}
```

## **Δημιουργία μικρογραφίας διαφάνειας με διαστάσεις καθορισμένες από το χρήστη**

Για να δημιουργήσετε μια εικόνα μικρογραφίας διαφάνειας με διαστάσεις καθορισμένες από το χρήστη, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
1. Αποκτήστε μια αναφορά στη διαφάνεια με το δείκτη της.
1. Δημιουργήστε μια εικόνα μικρογραφίας της αναφερόμενης διαφάνειας με τις καθορισμένες διαστάσεις.
1. Αποθηκεύστε τη μικρογραφία στην προτιμώμενη μορφή εικόνας.

```c#
int slideIndex = 0;
Size slideSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("sample.odp"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(slideSize))
    {
        image.Save("output.jpg", ImageFormat.Jpeg);
    }
}
```

## **Δημιουργία μικρογραφίας διαφάνειας με σημειώσεις ομιλητή**

Για να δημιουργήσετε μια μικρογραφία μιας διαφάνειας με σημειώσεις ομιλητή χρησιμοποιώντας το Aspose.Slides, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [RenderingOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/renderingoptions/).
1. Χρησιμοποιήστε την ιδιότητα `RenderingOptions.SlidesLayoutOptions` για να ορίσετε τη θέση των σημειώσεων ομιλητή.
1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
1. Αποκτήστε μια αναφορά στη διαφάνεια με το δείκτη της.
1. Δημιουργήστε μια μικρογραφία της αναφερόμενης διαφάνειας χρησιμοποιώντας τις επιλογές απόδοσης.
1. Αποθηκεύστε τη μικρογραφία στην προτιμώμενη μορφή εικόνας.

```c#
int slideIndex = 0;

RenderingOptions renderingOptions = new RenderingOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomTruncated
    }
};

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(renderingOptions))
    {
        image.Save("output.png", ImageFormat.Png);
    }
}
```

## **Ζωντανό παράδειγμα**

Δοκιμάστε τη δωρεάν εφαρμογή [**Aspose.Slides Viewer**](https://products.aspose.app/slides/el/viewer/) για να δείτε τι μπορείτε να υλοποιήσετε με το API του Aspose.Slides:

[![Online Προβολέας PowerPoint](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/el/viewer/)

## **Συχνές ερωτήσεις**

**Μπορώ να ενσωματώσω έναν προβολέα παρουσίασης σε μια εφαρμογή web ASP.NET;**

Ναι. Μπορείτε να χρησιμοποιήσετε το Aspose.Slides στην πλευρά του διακομιστή για να αποδώσετε τις διαφάνειες ως εικόνες ή HTML και να τις εμφανίσετε στο πρόγραμμα περιήγησης. Οι λειτουργίες πλοήγησης και ζουμ μπορούν να υλοποιηθούν με JavaScript για μια διαδραστική εμπειρία.

**Ποιος είναι ο καλύτερος τρόπος για να εμφανίσετε διαφάνειες μέσα σε έναν προσαρμοσμένο προβολέα .NET;**

Η συνιστώμενη προσέγγιση είναι να αποδίδετε κάθε διαφάνεια ως εικόνα (π.χ., PNG ή SVG) ή να τη μετατρέπετε σε HTML χρησιμοποιώντας το Aspose.Slides, έπειτα να προβάλλετε το αποτέλεσμα μέσα σε ένα picture box (για desktop) ή έναν HTML container (για web).

**Πώς διαχειρίζομαι μεγάλες παρουσιάσεις με πολλαπλές διαφάνειες;**

Για μεγάλες παρουσιάσεις, εξετάστε την τεχνική lazy-loading ή απόδοση on‑demand των διαφανειών. Αυτό σημαίνει ότι δημιουργείτε το περιεχόμενο μιας διαφάνειας μόνο όταν ο χρήστης πλοηγείται σε αυτή, μειώνοντας τη μνήμη και τον χρόνο φόρτωσης.