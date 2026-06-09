---
title: Δημιουργία προβολέα παρουσίασης στο Android
linktitle: Προβολέας Παρουσίασης
type: docs
weight: 50
url: /el/androidjava/presentation-viewer/
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
- Android
- Java
- Aspose.Slides
description: Δημιουργήστε έναν προσαρμοσμένο προβολέα παρουσίασης σε Java χρησιμοποιώντας το Aspose.Slides για Android. Εμφανίστε εύκολα αρχεία PowerPoint και OpenDocument χωρίς το Microsoft PowerPoint.
---
## **Εισαγωγή**

Το Aspose.Slides for Android μέσω Java χρησιμοποιείται για τη δημιουργία αρχείων παρουσίασης με διαφάνειες. Αυτές οι διαφάνειες μπορούν να προβληθούν ανοίγοντας τις παρουσιάσεις στο Microsoft PowerPoint, για παράδειγμα. Ωστόσο, μερικές φορές οι προγραμματιστές μπορεί να χρειαστεί να προβούν στις διαφάνειες ως εικόνες στον προτιμώμενο προβολέα εικόνων ή να δημιουργήσουν τον δικό τους προβολέα παρουσιάσεων. Σε τέτοιες περιπτώσεις, το Aspose.Slides σας επιτρέπει να εξάγετε μια μεμονωμένη διαφάνεια ως εικόνα. Αυτό το άρθρο περιγράφει πώς να το κάνετε.

## **Δημιουργία εικόνας SVG από διαφάνεια**

Για να δημιουργήσετε μια εικόνα SVG από μια διαφάνεια παρουσίασης με το Aspose.Slides, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/).
1. Αποκτήστε την αναφορά της διαφάνειας με βάση τον δείκτη της.
1. Ανοίξτε μια ροή αρχείου.
1. Αποθηκεύστε τη διαφάνεια ως εικόνα SVG στη ροή αρχείου.

```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```

## **Δημιουργία SVG με προσαρμοσμένο αναγνωριστικό σχήματος**

Το Aspose.Slides μπορεί να χρησιμοποιηθεί για τη δημιουργία ενός [SVG](https://docs.fileformat.com/page-description-language/svg/) από μια διαφάνεια με προσαρμοσμένο αναγνωριστικό σχήματος. Για να το κάνετε αυτό, χρησιμοποιήστε τη μέθοδο `setId` από το [ISvgShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isvgshape/). Το `CustomSvgShapeFormattingController` μπορεί να χρησιμοποιηθεί για να ορίσει το αναγνωριστικό του σχήματος.

```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

SVGOptions svgOptions = new SVGOptions();
svgOptions.setShapeFormattingController(new CustomSvgShapeFormattingController());

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream, svgOptions);
svgStream.close();

presentation.dispose();
```
```java
class CustomSvgShapeFormattingController implements ISvgShapeFormattingController
{
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController()
    {
        m_shapeIndex = 0;
    }

    public CustomSvgShapeFormattingController(int shapeStartIndex)
    {
        m_shapeIndex = shapeStartIndex;
    }

    public void formatShape(ISvgShape svgShape, IShape shape)
    {
        svgShape.setId(String.format("shape-%d", m_shapeIndex++));
    }
}
```

## **Δημιουργία μικρογραφίας διαφάνειας**

Το Aspose.Slides σας βοηθά να δημιουργήσετε μικρογραφίες διαφάνειας. Για να δημιουργήσετε μια μικρογραφία μιας διαφάνειας χρησιμοποιώντας το Aspose.Slides, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/).
1. Αποκτήστε την αναφορά της διαφάνειας με βάση τον δείκτη της.
1. Λάβετε τη μικρογραφία της αναφερόμενης διαφάνειας σε καθορισμένη κλίμακα.
1. Αποθηκεύστε τη μικρογραφία σε οποιαδήποτε επιθυμητή μορφή εικόνας.

```java
int slideIndex = 0;
float scaleX = 1;
float scaleY = scaleX;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(scaleX, scaleY);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **Δημιουργία μικρογραφίας διαφάνειας με διαστάσεις ορισμένες από τον χρήστη**

Για να δημιουργήσετε μια μικρογραφία διαφάνειας με διαστάσεις που ορίζονται από το χρήστη, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/).
1. Αποκτήστε την αναφορά της διαφάνειας με βάση τον δείκτη της.
1. Λάβετε τη μικρογραφία της αναφερόμενης διαφάνειας με τις καθορισμένες διαστάσεις.
1. Αποθηκεύστε τη μικρογραφία σε οποιαδήποτε επιθυμητή μορφή εικόνας.

```java
int slideIndex = 0;
Size slideSize = new Size(1200, 800);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(slideSize);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **Δημιουργία μικρογραφίας διαφάνειας με σημειώσεις ομιλητή**

Για να δημιουργήσετε τη μικρογραφία μιας διαφάνειας με σημειώσεις ομιλητή χρησιμοποιώντας το Aspose.Slides, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσίαση της κλάσης [RenderingOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/renderingoptions/).
1. Χρησιμοποιήστε τη μέθοδο `RenderingOptions.setSlidesLayoutOptions` για να ορίσετε τη θέση των σημειώσεων ομιλητή.
1. Δημιουργήστε μια παρουσίαση της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/).
1. Αποκτήστε την αναφορά της διαφάνειας με βάση τον δείκτη της.
1. Λάβετε τη μικρογραφία της αναφερόμενης διαφάνειας με τις ρυθμίσεις απόδοσης.
1. Αποθηκεύστε τη μικρογραφία σε οποιαδήποτε επιθυμητή μορφή εικόνας.

```java
int slideIndex = 0;

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setNotesPosition(NotesPositions.BottomTruncated);

RenderingOptions renderingOptions = new RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(renderingOptions);
image.save("output.png", ImageFormat.Png);
image.dispose();

presentation.dispose();
```

## **Ζωντανό παράδειγμα**

Μπορείτε να δοκιμάσετε την δωρεάν εφαρμογή [**Aspose.Slides Viewer**](https://products.aspose.app/slides/el/viewer/) για να δείτε τι μπορείτε να υλοποιήσετε με το API του Aspose.Slides:

![Online PowerPoint Viewer](online-PowerPoint-viewer.png)

## **Συχνές ερωτήσεις**

**Μπορώ να ενσωματώσω έναν προβολέα παρουσιάσεων σε μια διαδικτυακή εφαρμογή;**

Ναι. Μπορείτε να χρησιμοποιήσετε το Aspose.Slides στην πλευρά του διακομιστή για να δημιουργήσετε διαφάνειες ως εικόνες ή HTML και να τις εμφανίσετε στο πρόγραμμα περιήγησης. Οι λειτουργίες πλοήγησης και ζουμ μπορούν να υλοποιηθούν με JavaScript για μια διαδραστική εμπειρία.

**Ποιος είναι ο καλύτερος τρόπος για να εμφανίσω διαφάνειες μέσα σε προσαρμοσμένο προβολέα;**

Η προτεινόμενη προσέγγιση είναι να αποδώσετε κάθε διαφάνεια ως εικόνα (π.χ. PNG ή SVG) ή να τη μετατρέψετε σε HTML χρησιμοποιώντας το Aspose.Slides, και στη συνέχεια να εμφανίσετε το αποτέλεσμα μέσα σε ένα picture box (για επιτραπέζιες εφαρμογές) ή σε ένα HTML container (για το web).

**Πώς διαχειρίζομαι μεγάλες παρουσιάσεις με πολλές διαφάνειες;**

Για μεγάλα σύνολα διαφανειών, εξετάστε τη lazy‑loading ή την απόδοση κατάζητήματος των διαφανειών. Αυτό σημαίνει ότι η δημιουργία του περιεχομένου μιας διαφάνειας γίνεται μόνο όταν ο χρήστης πλοηγείται σε αυτήν, μειώνοντας τη μνήμη και το χρόνο φόρτωσης.