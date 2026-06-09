---
title: Δημιουργία Προβολέα Παρουσίασης σε Java
linktitle: Προβολέας Παρουσίασης
type: docs
weight: 50
url: /el/java/presentation-viewer/
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
- Java
- Aspose.Slides
description: "Δημιουργήστε έναν προσαρμοσμένο προβολέα παρουσίασης σε Java χρησιμοποιώντας το Aspose.Slides. Εμφανίστε εύκολα αρχεία PowerPoint και OpenDocument χωρίς το Microsoft PowerPoint."
---
## **Εισαγωγή**

Το Aspose.Slides for Java χρησιμοποιείται για τη δημιουργία αρχείων παρουσίασης με διαφάνειες. Αυτές οι διαφάνειες μπορούν να προβληθούν ανοίγοντας τις παρουσιάσεις στο Microsoft PowerPoint, για παράδειγμα. Ωστόσο, μερικές φορές οι προγραμματιστές μπορεί να χρειαστεί να προβάλλουν διαφάνειες ως εικόνες στον προτιμώμενο προβολέα εικόνων ή να δημιουργήσουν τον δικό τους προβολέα παρουσίασης. Σε τέτοιες περιπτώσεις, το Aspose.Slides σάς επιτρέπει να εξάγετε μια μεμονωμένη διαφάνεια ως εικόνα. Αυτό το άρθρο περιγράφει πώς να το κάνετε.

## **Δημιουργία εικόνας SVG από μια διαφάνεια**

Για να δημιουργήσετε μια εικόνα SVG από μια διαφάνεια παρουσίασης με το Aspose.Slides, παρακαλώ ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/).
1. Αποκτήστε την αναφορά της διαφάνειας με τον δείκτη της.
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

Το Aspose.Slides μπορεί να χρησιμοποιηθεί για τη δημιουργία ενός [SVG](https://docs.fileformat.com/page-description-language/svg/) από μια διαφάνεια με προσαρμοσμένο αναγνωριστικό σχήματος. Για να το κάνετε αυτό, χρησιμοποιήστε τη μέθοδο `setId` από το [ISvgShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/isvgshape/). Το `CustomSvgShapeFormattingController` μπορεί να χρησιμοποιηθεί για τον ορισμό του αναγνωριστικού σχήματος.

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
class CustomSvgShapeFormattingController implements ISvgShapeFormattingController {
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController() {
        m_shapeIndex = 0;
    }

    public CustomSvgShapeFormattingController(int shapeStartIndex) {
        m_shapeIndex = shapeStartIndex;
    }

    public void formatShape(ISvgShape svgShape, IShape shape) {
        svgShape.setId(String.format("shape-%d", m_shapeIndex++));
    }
}
```

## **Δημιουργία εικόνας μικρογραφίας διαφάνειας**

Το Aspose.Slides σας βοηθά να δημιουργήσετε μικρογραφίες διαφανειών. Για να δημιουργήσετε μια μικρογραφία μιας διαφάνειας χρησιμοποιώντας το Aspose.Slides, παρακαλώ ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/).
1. Αποκτήστε την αναφορά της διαφάνειας με τον δείκτη της.
1. Αποκτήστε την εικόνα μικρογραφίας της αναφερόμενης διαφάνειας σε καθορισμένη κλίμακα.
1. Αποθηκεύστε την εικόνα μικρογραφίας σε οποιαδήποτε επιθυμητή μορφή εικόνας.

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

Για να δημιουργήσετε μια εικόνα μικρογραφίας διαφάνειας με διαστάσεις ορισμένες από το χρήστη, παρακαλώ ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/).
1. Αποκτήστε την αναφορά της διαφάνειας με τον δείκτη της.
1. Αποκτήστε την εικόνα μικρογραφίας της αναφερόμενης διαφάνειας με τις καθορισμένες διαστάσεις.
1. Αποθηκεύστε την εικόνα μικρογραφίας σε οποιαδήποτε επιθυμητή μορφή εικόνας.

```java
int slideIndex = 0;
Dimension slideSize = new Dimension(1200, 800);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(slideSize);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **Δημιουργία μικρογραφίας διαφάνειας με σημειώσεις ομιλητή**

Για να δημιουργήσετε τη μικρογραφία μιας διαφάνειας με σημειώσεις ομιλητή χρησιμοποιώντας το Aspose.Slides, παρακαλώ ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [RenderingOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/renderingoptions/).
1. Χρησιμοποιήστε τη μέθοδο `RenderingOptions.setSlidesLayoutOptions` για να ορίσετε τη θέση των σημειώσεων ομιλητή.
1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/).
1. Αποκτήστε την αναφορά της διαφάνειας με τον δείκτη της.
1. Αποκτήστε την εικόνα μικρογραφίας της αναφερόμενης διαφάνειας με τις επιλογές απόδοσης.
1. Αποθηκεύστε την εικόνα μικρογραφίας σε οποιαδήποτε επιθυμητή μορφή εικόνας.

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

## **Ζωντανό Παράδειγμα**

Μπορείτε να δοκιμάσετε τη δωρεάν εφαρμογή [**Aspose.Slides Viewer**](https://products.aspose.app/slides/el/viewer/) για να δείτε τι μπορείτε να υλοποιήσετε με το API του Aspose.Slides:

![Online προβολέας PowerPoint](online-PowerPoint-viewer.png)

## **Συχνές ερωτήσεις**

**Μπορώ να ενσωματώσω έναν προβολέα παρουσίασης σε μια διαδικτυακή εφαρμογή;**

Ναι. Μπορείτε να χρησιμοποιήσετε το Aspose.Slides στην πλευρά του διακομιστή για να αποδώσετε διαφάνειες ως εικόνες ή HTML και να τις εμφανίσετε στον περιηγητή. Οι λειτουργίες πλοήγησης και ζουμ μπορούν να υλοποιηθούν με JavaScript για μια διαδραστική εμπειρία.

**Ποιος είναι ο καλύτερος τρόπος για να εμφανίζετε διαφάνειες μέσα σε έναν προσαρμοσμένο προβολέα;**

Η συνιστώμενη προσέγγιση είναι να αποδίδετε κάθε διαφάνεια ως εικόνα (π.χ., PNG ή SVG) ή να τη μετατρέπετε σε HTML χρησιμοποιώντας το Aspose.Slides, και στη συνέχεια να εμφανίζετε το αποτέλεσμα μέσα σε ένα picture box (για εφαρμογές επιφάνειας εργασίας) ή ένα HTML container (για το web).

**Πώς μπορώ να διαχειριστώ μεγάλες παρουσιάσεις με πολλές διαφάνειες;**

Για μεγάλες παρουσιάσεις, εξετάστε την τεχνική lazy‑loading ή την απόδοση των διαφανειών κατά απαίτηση. Αυτό σημαίνει ότι το περιεχόμενο μιας διαφάνειας δημιουργείται μόνο όταν ο χρήστης πλοηγείται σε αυτήν, μειώνοντας τη χρήση μνήμης και τον χρόνο φόρτωσης.