---
title: Δημιουργία προσαρμοσμένου προβολέα παρουσίασης σε C++
linktitle: Προβολέας παρουσίασης
type: docs
weight: 50
url: /el/cpp/presentation-viewer/
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
- C++
- Aspose.Slides
description: "Δημιουργήστε έναν προσαρμοσμένο προβολέα παρουσίασης σε C++ χρησιμοποιώντας το Aspose.Slides. Εύκολη προβολή αρχείων PowerPoint και OpenDocument χωρίς το Microsoft PowerPoint."
---
## **Εισαγωγή**

Το Aspose.Slides για C++ χρησιμοποιείται για τη δημιουργία αρχείων παρουσίασης με διαφάνειες. Αυτές οι διαφάνειες μπορούν να προβληθούν ανοίγοντας τις παρουσιάσεις στο Microsoft PowerPoint, για παράδειγμα. Ωστόσο, μερικές φορές οι προγραμματιστές μπορεί να χρειαστεί να βλέπουν τις διαφάνειες ως εικόνες στον προτιμώμενο προβολέα εικόνων ή να δημιουργήσουν το δικό τους πρόγραμμα προβολής παρουσίασης. Σε τέτοιες περιπτώσεις, το Aspose.Slides επιτρέπει την εξαγωγή μιας μεμονωμένης διαφάνειας ως εικόνας. Αυτό το άρθρο περιγράφει πώς γίνεται.

## **Δημιουργία εικόνας SVG από διαφάνεια**

Για να δημιουργήσετε μια εικόνα SVG από μια διαφάνεια παρουσίασης με το Aspose.Slides, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) .
1. Αποκτήστε την αναφορά της διαφάνειας με το δείκτη της .
1. Ανοίξτε μια ροή αρχείου .
1. Αποθηκεύστε τη διαφάνεια ως εικόνα SVG στη ροή αρχείου .

```cpp
auto slideIndex = 0;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto svgStream = File::Create(u"output.svg");
slide->WriteAsSvg(svgStream);
svgStream->Dispose();

presentation->Dispose();
```

## **Δημιουργία SVG με προσαρμοσμένο αναγνωριστικό σχήματος**

Το Aspose.Slides μπορεί να χρησιμοποιηθεί για τη δημιουργία ενός [SVG](https://docs.fileformat.com/page-description-language/svg/) από μια διαφάνεια με προσαρμοσμένο αναγνωριστικό σχήματος. Για να το κάνετε αυτό, χρησιμοποιήστε τη μέθοδο `set_Id` από το [ISvgShape](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/isvgshape/). Μπορεί να χρησιμοποιηθεί το `CustomSvgShapeFormattingController` για να ορίσετε το αναγνωριστικό του σχήματος.

```cpp
auto slideIndex = 0;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<CustomSvgShapeFormattingController>());

auto svgStream = File::Create(u"output.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```
```cpp
class CustomSvgShapeFormattingController : public ISvgShapeFormattingController
{
private:
    int m_shapeIndex;

public:
    CustomSvgShapeFormattingController(int shapeStartIndex = 0)
    {
        m_shapeIndex = shapeStartIndex;
    }

    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape)
    {
        svgShape->set_Id(String::Format(u"shape-{0}", m_shapeIndex++));
    }
};
```

## **Δημιουργία μικρογραφίας διαφάνειας**

Το Aspose.Slides σας βοηθά να δημιουργήσετε μικρογραφίες διαφανειών. Για να δημιουργήσετε μια μικρογραφία μιας διαφάνειας χρησιμοποιώντας το Aspose.Slides, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) .
1. Αποκτήστε την αναφορά της διαφάνειας με το δείκτη της .
1. Αποκτήστε την εικόνα μικρογραφίας της αναφοράς διαφάνειας σε καθορισμένη κλίμακα .
1. Αποθηκεύστε τη μικρογραφία σε οποιαδήποτε επιθυμητή μορφή εικόνας .

```cpp
auto slideIndex = 0;
auto scaleX = 1;
auto scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(scaleX, scaleY);
image->Save(u"output.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Δημιουργία μικρογραφίας διαφάνειας με διαστάσεις ορισμένες από τον χρήστη**

Για να δημιουργήσετε μια μικρογραφία διαφάνειας με διαστάσεις που ορίζονται από τον χρήστη, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) .
1. Αποκτήστε την αναφορά της διαφάνειας με το δείκτη της .
1. Αποκτήστε την εικόνα μικρογραφίας της αναφοράς διαφάνειας με τις καθορισμένες διαστάσεις .
1. Αποθηκεύστε τη μικρογραφία σε οποιαδήποτε επιθυμητή μορφή εικόνας .

```cpp
auto slideIndex = 0;
auto slideSize = Size(1200, 800);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(slideSize);
image->Save(u"output.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Δημιουργία μικρογραφίας διαφάνειας με σημειώσεις ομιλητή**

Για να δημιουργήσετε τη μικρογραφία μιας διαφάνειας με σημειώσεις ομιλητή χρησιμοποιώντας το Aspose.Slides, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [RenderingOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/renderingoptions/) .
1. Χρησιμοποιήστε τη μέθοδο `RenderingOptions.set_SlidesLayoutOptions` για να ορίσετε τη θέση των σημειώσεων ομιλητή .
1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) .
1. Αποκτήστε την αναφορά της διαφάνειας με το δείκτη της .
1. Αποκτήστε την εικόνα μικρογραφίας της αναφοράς διαφάνειας με τις ρυθμίσεις απόδοσης .
1. Αποθηκεύστε τη μικρογραφία σε οποιαδήποτε επιθυμητή μορφή εικόνας .

```cpp
auto slideIndex = 0;

auto layoutingOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutingOptions->set_NotesPosition(NotesPositions::BottomTruncated);

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layoutingOptions);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(renderingOptions);
image->Save(u"output.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Ζωντανό Παράδειγμα**

Μπορείτε να δοκιμάσετε την ελεύθερη εφαρμογή [**Aspose.Slides Viewer**](https://products.aspose.app/slides/el/viewer/) για να δείτε τι μπορείτε να υλοποιήσετε με το API του Aspose.Slides:

![Online προβολέας PowerPoint](online-PowerPoint-viewer.png)

## **Συχνές ερωτήσεις**

**Μπορώ να ενσωματώσω έναν προβολέα παρουσίασης σε μια web εφαρμογή;**

Ναι. Μπορείτε να χρησιμοποιήσετε το Aspose.Slides στην πλευρά του διακομιστή για να αποδίδετε τις διαφάνειες ως εικόνες ή HTML και να τις εμφανίζετε στο πρόγραμμα περιήγησης. Οι λειτουργίες πλοήγησης και ζουμ μπορούν να υλοποιηθούν με JavaScript για μια διαδραστική εμπειρία.

**Ποιος είναι ο καλύτερος τρόπος για να εμφανίσετε διαφάνειες σε έναν προσαρμοσμένο προβολέα;**

Η συνιστώμενη προσέγγιση είναι να αποδίδετε κάθε διαφάνεια ως εικόνα (π.χ., PNG ή SVG) ή να τη μετατρέπετε σε HTML χρησιμοποιώντας το Aspose.Slides, και στη συνέχεια να εμφανίζετε το αποτέλεσμα μέσα σε ένα picture box (για επιτραπέζιους υπολογιστές) ή σε ένα HTML container (για το web).

**Πώς να διαχειριστώ μεγάλες παρουσιάσεις με πολλές διαφάνειες;**

Για μεγάλες παρουσιάσεις, σκεφτείτε τη φερέωση (lazy-loading) ή την απόδοση κατόπιν ζήτησης των διαφανειών. Αυτό σημαίνει ότι το περιεχόμενο μιας διαφάνειας δημιουργείται μόνο όταν ο χρήστης πλοηγείται σε αυτήν, μειώνοντας τη χρήση μνήμης και το χρόνο φόρτωσης.