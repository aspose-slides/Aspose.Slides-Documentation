---
title: Διαχείριση Σχημάτων Παρουσίασης σε C++
linktitle: Διαχείριση Σχημάτων
type: docs
weight: 40
url: /el/cpp/shape-manipulations/
keywords:
- σχήμα PowerPoint
- σχήμα παρουσίασης
- σχήμα σε διαφάνεια
- εύρεση σχήματος
- κλωνοποίηση σχήματος
- αφαίρεση σχήματος
- απόκρυψη σχήματος
- αλλαγή σειράς σχήματος
- Λήψη Interop Shape ID
- εναλλακτικό κείμενο σχήματος
- μορφές διάταξης σχήματος
- σχήμα ως SVG
- σχήμα σε SVG
- στοίχιση σχήματος
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Μάθετε να δημιουργείτε, επεξεργάζεστε και βελτιστοποιείτε σχήματα στο Aspose.Slides για C++ και να παραδίδετε παρουσιάσεις PowerPoint υψηλής απόδοσης."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με σχήματα σε παρουσιάσεις χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να βρείτε ένα σχήμα σε μια διαφάνεια, να το κλωνοποιήσετε, να το αφαιρέσετε, να το κρύψετε, να αλλάξετε τη σειρά του, να λάβετε το Interop Shape ID του και να ορίσετε εναλλακτικό κείμενο για ταυτοποίηση και περαιτέρω επεξεργασία.

Επιπλέον, καλύπτει πώς να προσπελάσετε τις διαμορφώσεις διάταξης για σχήματα, να αποδώσετε ένα σχήμα ως SVG, να στοιχίσετε σχήματα σε μια διαφάνεια και να χρησιμοποιήσετε τις ιδιότητες αντιστροφής για οριζόντια και κάθετη αντανάκλαση. Επιπλέον, το άρθρο περιλαμβάνει μια σύντομη ενότητα FAQ σχετικά με τον συνδυασμό σχημάτων, τη σειρά στοιβάγματος και το κλείδωμα σχήματος.

## **Find a Shape on a Slide**
Αυτό το θέμα περιγράφει μια απλή τεχνική που διευκολύνει τους προγραμματιστές να βρουν ένα συγκεκριμένο σχήμα σε μια διαφάνεια χωρίς τη χρήση του εσωτερικού του Id. Είναι σημαντικό να γνωρίζουμε ότι τα αρχεία PowerPoint Presentation δεν διαθέτουν κανέναν τρόπο να ταυτοποιήσουν σχήματα σε μια διαφάνεια εκτός από ένα εσωτερικό μοναδικό Id. Φαίνεται δύσκολο για τους προγραμματιστές να βρουν ένα σχήμα χρησιμοποιώντας το εσωτερικό του μοναδικό Id. Όλα τα σχήματα που προστίθενται στις διαφάνειες έχουν κάποιο Alt Text. Προτείνουμε στους προγραμματιστές να χρησιμοποιούν εναλλακτικό κείμενο για την εύρεση ενός συγκεκριμένου σχήματος. Μπορείτε να χρησιμοποιήσετε το MS PowerPoint για να ορίσετε το εναλλακτικό κείμενο για αντικείμενα που σκοπεύετε να αλλάξετε στο μέλλον.

Αφού ορίσετε το εναλλακτικό κείμενο του οποιουδήποτε επιθυμητού σχήματος, μπορείτε στη συνέχεια να ανοίξετε αυτήν την παρουσίαση χρησιμοποιώντας το Aspose.Slides for C++ και να επαναλάβετε όλα τα σχήματα που προστέθηκαν σε μια διαφάνεια. Κατά τη διάρκεια κάθε επανάληψης, μπορείτε να ελέγξετε το εναλλακτικό κείμενο του σχήματος και το σχήμα με το αντίστοιχο εναλλακτικό κείμενο θα είναι το σχήμα που χρειάζεστε. Για να επιδείξουμε αυτήν την τεχνική με καλύτερο τρόπο, δημιουργήσαμε μια μέθοδο, [FindShape](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.util.slide_util#ad6ecc982512ef758ea4d5d28672db71f) που κάνει την εύρεση συγκεκριμένου σχήματος σε μια διαφάνεια και στη συνέχεια επιστρέφει απλά αυτό το σχήμα.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FindShapeInSlide-FindShapeInSlide.cpp" >}}


## **Clone a Shape**
Για να κλωνοποιήσετε ένα σχήμα σε μια διαφάνεια χρησιμοποιώντας το Aspose.Slides for C++:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation).
1. Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το δείκτη της.
1. Πρόσβαση στη συλλογή σ shapes της πηγής διαφάνειας.
1. Προσθήκη μιας νέας διαφάνειας στην παρουσία.
1. Κλωνοποίηση σ shapes από τη συλλογή σ shapes της πηγής διαφάνειας στη νέα διαφάνεια.
1. Αποθήκευση της τροποποιημένης παρουσίασης ως αρχείο PPTX.

Το παρακάτω παράδειγμα προσθέτει ένα group shape σε μια διαφάνεια.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneShapes-CloneShapes.cpp" >}}


## **Remove a Shape**
Το Aspose.Slides for C++ επιτρέπει στους προγραμματιστές να αφαιρέσουν οποιοδήποτε σχήμα. Για να αφαιρέσετε το σχήμα από οποιαδήποτε διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation).
1. Πρόσβαση στην πρώτη διαφάνεια.
1. Βρείτε το σχήμα με συγκεκριμένο AlternativeText.
1. Αφαιρέστε το σχήμα.
1. Αποθηκεύστε το αρχείο στον δίσκο.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveShape-RemoveShape.cpp" >}}


## **Hide a Shape**
Το Aspose.Slides for C++ επιτρέπει στους προγραμματιστές να κρύψουν οποιοδήποτε σχήμα. Για να κρύψετε το σχήμα από οποιαδήποτε διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation).
1. Πρόσβαση στην πρώτη διαφάνεια.
1. Βρείτε το σχήμα με συγκεκριμένο AlternativeText.
1. Κρύψτε το σχήμα.
1. Αποθηκεύστε το αρχείο στον δίσκο.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-Hidingshapes-Hidingshapes.cpp" >}}



## **Change Shape Order**
Το Aspose.Slides for C++ επιτρέπει στους προγραμματιστές να αλλάξουν τη σειρά των σχημάτων. Η αλλαγή σειράς καθορίζει ποιο σχήμα είναι μπροστά ή ποιο είναι στο παρασκήνιο. Για να αλλάξετε τη σειρά ενός σχήματος σε οποιαδήποτε διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation).
1. Πρόσβαση στην πρώτη διαφάνεια.
1. Προσθέστε ένα σχήμα.
1. Προσθέστε κάποιο κείμενο στο πλαίσιο κειμένου του σχήματος.
1. Προσθέστε ένα άλλο σχήμα με τις ίδιες συντεταγμένες.
1. Αλλάξτε τη σειρά των σχημάτων.
1. Αποθηκεύστε το αρχείο στον δίσκο.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeShapeOrder-ChangeShapeOrder.cpp" >}}


## **Get the Interop Shape ID**
Το Aspose.Slides for C++ επιτρέπει στους προγραμματιστές να λάβουν ένα μοναδικό αναγνωριστικό σχήματος σε επίπεδο διαφάνειας, σε αντίθεση με την ιδιότητα UniqueId, η οποία παρέχει μοναδικό αναγνωριστικό σε επίπεδο παρουσίασης. Η ιδιότητα OfficeInteropShapeId προστέθηκε στις διεπαφές IShape και στην κλάση Shape. Η τιμή που επιστρέφει η ιδιότητα OfficeInteropShapeId αντιστοιχεί στην τιμή του Id του αντικειμένου Microsoft.Office.Interop.PowerPoint.Shape. Παρακάτω δίνεται το δείγμα κώδικα.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-InterlopShapeID-InterlopShapeID.cpp" >}}


## **Set the AlternativeText Property**
Το Aspose.Slides for C++ επιτρέπει στους προγραμματιστές να ορίσουν το AlternativeText οποιουδήποτε σχήματος. Για να ορίσετε το AlternativeText ενός σχήματος, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation).
1. Πρόσβαση στην πρώτη διαφάνεια.
1. Προσθέστε οποιοδήποτε σχήμα στη διαφάνεια.
1. Εργαστείτε με το νεοπροστέθεισες σχήμα.
1. Περιηγηθείτε στα σχήματα για να βρείτε ένα σχήμα.
1. Ορίστε το AlternativeText.
1. Αποθηκεύστε το αρχείο στον δίσκο.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAlternativeText-SetAlternativeText.cpp" >}}


## **Access Layout Formats for a Shape**
Το Aspose.Slides for C++ επιτρέπει στους προγραμματιστές να έχουν πρόσβαση στις διαμορφώσεις διάταξης για ένα σχήμα. Αυτό το άρθρο δείχνει πώς μπορείτε να προσπελάσετε τις ιδιότητες **FillFormat** και **LineFormat** ενός σχήματος.

Παρακάτω δίνεται το δείγμα κώδικα.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AccessLayoutFormats-AccessLayoutFormats.cpp" >}}

## **Render a Shape as SVG**
Τώρα το Aspose.Slides for C++ υποστηρίζει την απόδοση ενός σχήματος ως svg. Η μέθοδος WriteAsSvg (και η υπερφόρτωσή της) προστέθηκε στην κλάση Shape και στην διεπαφή IShape. Αυτή η μέθοδος επιτρέπει την αποθήκευση του περιεχομένου του σχήματος ως αρχείο SVG. Το παρακάτω απόσπασμα κώδικα δείχνει πώς να εξάγετε το σχήμα μιας διαφάνειας σε αρχείο SVG.

``` cpp
String outSvgFileName = u"SingleShape.svg";

auto pres = System::MakeObject<Presentation>(u"TestExportShapeToSvg.pptx");

auto stream = System::MakeObject<FileStream>(outSvgFileName, FileMode::Create, FileAccess::Write);
pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0)->WriteAsSvg(stream);
```

## **Shapes Alignment**
Το Aspose.Slides επιτρέπει στοίχιση σχημάτων είτε σχετικά με τα περιθώρια της διαφάνειας είτε μεταξύ τους. Για το σκοπό αυτό, προστέθηκε μια υπερφορτωμένη μέθοδος [SlidesUtil.AlignShapes()](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.util.slide_util#a2263709efa423c11706e57b21014d3ab). Η απαρίθμηση [ShapesAlignmentType](https://reference.aspose.com/slides/el/cpp/namespace/aspose.slides#aeb3015a196294029a0ee1f545bc5887f) ορίζει τις πιθανές επιλογές στοίχισης.

**Example 1**

Ο παρακάτω κώδικας ευθυγραμμίζει σχήματα με δείκτες 1, 2 και 4 κατά το επάνω άκρο της διαφάνειας.

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"example.pptx");

SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
SharedPtr<IShape> shape1 = slide->get_Shapes()->idx_get(1);
SharedPtr<IShape> shape2 = slide->get_Shapes()->idx_get(2);
SharedPtr<IShape> shape3 = slide->get_Shapes()->idx_get(4);
SlideUtil::AlignShapes(ShapesAlignmentType::AlignTop, true, pres->get_Slides()->idx_get(0), 
System::MakeArray<int32_t>(
    {
        slide->get_Shapes()->IndexOf(shape1),
        slide->get_Shapes()->IndexOf(shape2),
        slide->get_Shapes()->IndexOf(shape3)
    }));
```

**Example 2**

Το παρακάτω παράδειγμα δείχνει πώς να ευθυγραμμίσετε ολόκληρη τη συλλογή σχημάτων σε σχέση με το πιο κάτω σχήμα της συλλογής.

``` cpp
SharedPtr<Presentation> pres = MakeObject<Presentation>(u"example.pptx");
SlideUtil::AlignShapes(ShapesAlignmentType::AlignBottom, false, pres->get_Slides()->idx_get(0)->get_Shapes());
```

## **Flip Properties**

Στο Aspose.Slides, η κλάση [ShapeFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/shapeframe/) παρέχει έλεγχο της οριζόντιας και κάθετης αντιστροφής των σχημάτων μέσω των ιδιοτήτων `flipH` και `flipV`. Και οι δύο ιδιότητες είναι τύπου [NullableBool](https://reference.aspose.com/slides/el/cpp/aspose.slides/nullablebool/), επιτρέποντας τιμές `True` για αντιστροφή, `False` για χωρίς αντιστροφή, ή `NotDefined` για χρήση προεπιλεγμένης συμπεριφοράς. Αυτές οι τιμές είναι προσβάσιμες από το [Frame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/get_frame/) ενός σχήματος.

Για να τροποποιήσετε τις ρυθμίσεις αντιστροφής, δημιουργείται μια νέα παρουσία [ShapeFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/shapeframe/) με την τρέχουσα θέση και μέγεθος του σχήματος, τις επιθυμητές τιμές για `flipH` και `flipV`, και τη γωνία περιστροφής. Η ανάθεση αυτής της παρουσίας στο [Frame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/get_frame/) του σχήματος και η αποθήκευση της παρουσίασης εφαρμόζει τους μετασχηματισμούς καθρεπτισμού και τους καταγράφει στο αρχείο εξόδου.

Ας υποθέσουμε ότι έχουμε ένα αρχείο sample.pptx στο οποίο η πρώτη διαφάνεια περιέχει ένα μόνο σχήμα με προεπιλεγμένες ρυθμίσεις αντιστροφής, όπως φαίνεται παρακάτω.

![The shape to be flipped](shape_to_be_flipped.png)

Ο παρακάτω κώδικας ανακτά τις τρέχουσες ιδιότητες αντιστροφής του σχήματος και το αντιστρέφει οριζόντια και κάθετα.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);

// Ανάκτηση της ιδιότητας οριζόντιας αντανάκλασης του σχήματος.
auto horizontalFlip = shape->get_Frame()->get_FlipH();
Console::WriteLine(u"Horizontal flip: " + ObjectExt::ToString(horizontalFlip));

// Ανάκτηση της ιδιότητας κάθετης αντανάκλασης του σχήματος.
auto verticalFlip = shape->get_Frame()->get_FlipV();
Console::WriteLine(u"Vertical flip: " + ObjectExt::ToString(verticalFlip));

auto x = shape->get_Frame()->get_X();
auto y = shape->get_Frame()->get_Y();
auto width = shape->get_Frame()->get_Width();
auto height = shape->get_Frame()->get_Height();
auto flipH = NullableBool::True; // Αντιστροφή οριζόντια.
auto flipV = NullableBool::True; // Αντιστροφή οριζόντια.
auto rotation = shape->get_Frame()->get_Rotation();

shape->set_Frame(MakeObject<ShapeFrame>(x, y, width, height, flipH, flipV, rotation));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![The flipped shape](flipped_shape.png)

## **FAQ**

**Can I combine shapes (union/intersect/subtract) on a slide like in a desktop editor?**

Δεν υπάρχει ενσωματωμένο API Boolean λειτουργιών. Μπορείτε να το προσεγγίσετε δημιουργώντας το επιθυμητό περίγραμμα εσείς – π.χ., υπολογίζοντας το τελικό γεωμετρικό σχήμα (μέσω του [GeometryPath](https://reference.aspose.com/slides/el/cpp/aspose.slides/geometrypath/)) και δημιουργώντας νέο σχήμα με αυτό το περίγραμμα, προαιρετικά αφαιρώντας τα αρχικά.

**How can I control the stacking order (z-order) so a shape always stays "on top"?**

Αλλάξτε τη σειρά εισαγωγής/μετακίνησης μέσα στη συλλογή [shapes](https://reference.aspose.com/slides/el/cpp/aspose.slides/baseslide/get_shapes/) της διαφάνειας. Για προβλέψιμα αποτελέσματα, ορίστε το z-order μετά από όλες τις άλλες τροποποιήσεις της διαφάνειας.

**Can I "lock" a shape to prevent users from editing it in PowerPoint?**

Ναι. Ορίστε τις [σημαίες προστασίας σε επίπεδο σχήματος](/slides/el/cpp/applying-protection-to-presentation/) (π.χ., κλείδωμα επιλογής, μετακίνησης, αλλαγής μεγέθους, επεξεργασίας κειμένου). Αν χρειάζεται, εφαρμόστε περιορισμούς και στο master ή το layout. Σημειώστε ότι αυτή είναι προστασία σε επίπεδο UI, όχι λειτουργία ασφαλείας· για ισχυρότερη προστασία, συνδυάστε με περιορισμούς σε επίπεδο αρχείου όπως προτάσεις μόνο για ανάγνωση ή κωδικούς πρόσβασης [/slides/el/cpp/password-protected-presentation/].