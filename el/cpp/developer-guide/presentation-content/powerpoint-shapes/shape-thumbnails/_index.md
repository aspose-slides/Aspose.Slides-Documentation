---
title: Δημιουργία μικρογραφιών σχημάτων παρουσίασης σε C++
linktitle: Μικρογραφίες Σχημάτων
type: docs
weight: 70
url: /el/cpp/shape-thumbnails/
keywords:
- μικρογραφία σχήματος
- εικόνα σχήματος
- απόδοση σχήματος
- απόδοση σχημάτων
- οπτικά όρια
- όρια σχήματος
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Δημιουργήστε υψηλής ποιότητας μικρογραφίες σχημάτων από διαφάνειες PowerPoint με το Aspose.Slides για C++ – δημιουργήστε και εξάγετε εύκολα μικρογραφίες παρουσίασης."
---
## **Εισαγωγή**

Aspose.Slides χρησιμοποιείται για τη δημιουργία αρχείων παρουσίασης όπου κάθε σελίδα είναι μια διαφάνεια. Αυτές οι διαφάνειες μπορούν να προβληθούν ανοίγοντας τα αρχεία παρουσίασης με το Microsoft PowerPoint. Αλλά μερικές φορές, οι προγραμματιστές μπορεί να χρειαστεί να δουν τις εικόνες των σχημάτων ξεχωριστά σε μια προβολή εικόνων. Σε τέτοιες περιπτώσεις, το Aspose.Slides σας βοηθά να δημιουργήσετε μικρογραφίες εικόνων των σχημάτων της διαφάνειας. Πώς να χρησιμοποιήσετε αυτή τη δυνατότητα περιγράφεται σε αυτό το άρθρο.

Αυτό το άρθρο εξηγεί πώς να δημιουργήσετε μικρογραφίες διαφανειών με διάφορους τρόπους:

- Δημιουργία μικρογραφίας σχήματος εντός μιας διαφάνειας.
- Δημιουργία μικρογραφίας σχήματος για σχήμα διαφάνειας με διαστάσεις ορισμένες από τον χρήστη.
- Δημιουργία μικρογραφίας σχήματος στα όρια της εμφάνισης ενός σχήματος.

## **Δημιουργία μικρογραφίας σχήματος από μια διαφάνεια**
Για να δημιουργήσετε μια μικρογραφία σχήματος από οποιαδήποτε διαφάνεια χρησιμοποιώντας το Aspose.Slides για C++:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) .
2. Αποκτήστε την αναφορά οποιασδήποτε διαφάνειας χρησιμοποιώντας το αναγνωριστικό της ή το δείκτη.
3. Λάβετε την εικόνα μικρογραφίας σχήματος της αναφερθείσας διαφάνειας σε προεπιλεγμένη κλίμακα.
4. Αποθηκεύστε την εικόνα μικρογραφίας σε οποιαδήποτε επιθυμητή μορφή εικόνας.

Το παρακάτω παράδειγμα δημιουργεί μια μικρογραφία σχήματος.

```cpp
auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage();
image->Save(u"Shape_thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Δημιουργία μικρογραφίας με παράγοντα κλιμάκωσης ορισμένο από το χρήστη**
Για να δημιουργήσετε τη μικρογραφία σχήματος οποιουδήποτε σχήματος διαφάνειας χρησιμοποιώντας το Aspose.Slides για C++:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) .
2. Αποκτήστε την αναφορά οποιασδήποτε διαφάνειας χρησιμοποιώντας το αναγνωριστικό της ή το δείκτη.
3. Λάβετε την εικόνα μικρογραφίας της αναφερθείσας διαφάνειας με τα όρια του σχήματος.
4. Αποθηκεύστε την εικόνα μικρογραφίας σε οποιαδήποτε επιθυμητή μορφή εικόνας.

Το παρακάτω παράδειγμα δημιουργεί μια μικρογραφία με παράγοντα κλιμάκωσης ορισμένο από το χρήστη.

```cpp
auto bounds = ShapeThumbnailBounds::Shape;
auto scale = 1; // Κλιμάκωση κατά τους άξονες X και Y.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Scaling Factor Thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Δημιουργία μικρογραφίας εμφάνισης σχήματος βάσει ορίων**
Αυτή η μέθοδος δημιουργίας μικρογραφιών σχημάτων επιτρέπει στους προγραμματιστές να δημιουργούν μια μικρογραφία στα όρια της εμφάνισης του σχήματος. Λαμβάνει υπόψη όλα τα εφέ του σχήματος. Η δημιουργημένη μικρογραφία σχήματος περιορίζεται από τα όρια της διαφάνειας. Για να δημιουργήσετε μια μικρογραφία οποιουδήποτε σχήματος διαφάνειας στα όρια της εμφάνισής του, χρησιμοποιήστε τον παρακάτω κώδικα παραδείγματος:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) .
2. Αποκτήστε την αναφορά οποιασδήποτε διαφάνειας χρησιμοποιώντας το αναγνωριστικό της ή το δείκτη.
3. Λάβετε την εικόνα μικρογραφίας της αναφερθείσας διαφάνειας με τα όρια του σχήματος ως εμφάνιση.
4. Αποθηκεύστε την εικόνα μικρογραφίας σε οποιαδήποτε επιθυμητή μορφή εικόνας.

Το παρακάτω παράδειγμα δημιουργεί μια μικρογραφία με παράγοντα κλιμάκωσης ορισμένο από το χρήστη.

```cpp
auto bounds = ShapeThumbnailBounds::Appearance;
auto scale = 1; // Κλιμάκωση κατά τους άξονες X και Y.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Shape_thumbnail_Bound_Shape_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Λήψη των πραγματικών οπτικών ορίων ενός σχήματος**

Οι ιδιότητες πλαισίου του [IShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/)—`IShape::get_X()`, `IShape::get_Y()`, `IShape::get_Width()`, and `IShape::get_Height()`—περιγράφουν το ορθογώνιο που αποθηκεύεται στο μοντέλο της παρουσίασης. Το περιεχόμενο που πραγματικά αποδίδεται μπορεί να εκτείνεται πέρα από αυτό το πλαίσιο ή να καταλαμβάνει διαφορετικό ορθογώνιο ευθυγραμμισμένο με τους άξονες. Περιστροφή, περιγράμματα, κεφαλές βελών, διάταξη κειμένου και υπερχείλιση, η γεωμετρία του παραγόμενου SmartArt και άλλα εφέ απόδοσης μπορούν όλα να αλλάξουν την καταλαμβανόμενη περιοχή.

Χρησιμοποιήστε το [Shape::GetVisualBounds](https://reference.aspose.com/slides/el/cpp/aspose.slides/shape/getvisualbounds/) για να υπολογίσετε αυτήν την περιοχή χωρίς να δημιουργήσετε εικόνα. Η μέθοδος επιστρέφει ένα [RectangleF](https://reference.aspose.com/slides/el/cpp/system.drawing/rectanglef/) σε συντεταγμένες διαφάνειας. Το επιστρεφόμενο ορθογώνιο δεν περικόπτεται στη διαφάνεια, επομένως οι συντεταγμένες του μπορούν να είναι αρνητικές όταν το περιεχόμενο εκτείνεται πέρα από το αρχικό σημείο της διαφάνειας.

Το [Shape::GetVisualBounds](https://reference.aspose.com/slides/el/cpp/aspose.slides/shape/getvisualbounds/) δεν έχει δηλωθεί ακόμη από το interface [IShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/). Συνεπώς, διατηρήστε το σχήμα που λαμβάνεται από τη συλλογή σχημάτων της διαφάνειας ως τιμή interface και εκτελέστε cast μόνο όταν καλείτε τη μέθοδο.

Το παρακάτω παράδειγμα λαμβάνει και συγκρίνει το πλαίσιο και τα οπτικά όρια:

```cpp
auto presentation = MakeObject<Presentation>(u"example.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

auto visualBounds = System::AsCast<Shape>(shape)->GetVisualBounds();

System::Drawing::RectangleF frameBounds(
    shape->get_X(), shape->get_Y(), shape->get_Width(), shape->get_Height());

Console::WriteLine(u"Frame bounds: {0}", frameBounds);
Console::WriteLine(u"Visual bounds: {0}", visualBounds);

presentation->Dispose();
```

Το ίδιο [RectangleF](https://reference.aspose.com/slides/el/cpp/system.drawing/rectanglef/) μπορεί να χρησιμοποιηθεί για τη στοίχιση κοντινών σχημάτων προς τις άκρες `RectangleF::get_Left()`, `RectangleF::get_Right()`, `RectangleF::get_Top()` ή `RectangleF::get_Bottom()`· για να διατηρηθεί αρκετός χώρος σε μια παραγόμενη διάταξη· ή για την ανίχνευση περιεχομένου εκτός επιτρεπόμενης περιοχής. Τα οπτικά όρια είναι ιδιαίτερα χρήσιμα για SmartArt, πλαίσια κειμένου, βέλη, εικόνες, περιστρεφόμενα σχήματα και ομαδικά σχήματα, όπου το αποθηκευμένο πλαίσιο μπορεί να μην αντιπροσωπεύει το πλήρες αποδοθέν αποτέλεσμα.

Χρησιμοποιήστε το [Shape::GetVisualBounds](https://reference.aspose.com/slides/el/cpp/aspose.slides/shape/getvisualbounds/) όταν χρειάζεστε συντεταγμένες για διάταξη ή επικύρωση και δεν χρειάζεστε bitmap. Χρησιμοποιήστε το [IShape::GetImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/getimage/) όταν χρειάζεται να αποδώσετε το σχήμα. Με το [ShapeThumbnailBounds](https://reference.aspose.com/slides/el/cpp/aspose.slides/shapethumbnailbounds/), το `ShapeThumbnailBounds::Shape` καθορίζει το μέγεθος της εικόνας από τα όρια του σχήματος, συμπεριλαμβανομένων των ρυθμίσεων περιγράμματος, ενώ το `ShapeThumbnailBounds::Appearance` το καθορίζει από την εμφάνιση του σχήματος και περιορίζει το αποτέλεσμα στα όρια της διαφάνειας. Αντίθετα, το [Shape::GetVisualBounds](https://reference.aspose.com/slides/el/cpp/aspose.slides/shape/getvisualbounds/) επιστρέφει μόνο το υπολογισμένο ορθογώνιο και δεν το κόβει στη διαφάνεια.

## **Συχνές Ερωτήσεις**

**Ποιοι μορφές εικόνας μπορούν να χρησιμοποιηθούν κατά την αποθήκευση μικρογραφιών σχημάτων;**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/el/cpp/aspose.slides/imageformat/), και άλλες. Τα σχήματα μπορούν επίσης να [εξαχθούν ως διανυσματικό SVG](https://reference.aspose.com/slides/el/cpp/aspose.slides/shape/writeassvg/) αποθηκεύοντας το περιεχόμενο του σχήματος ως SVG.

**Ποια είναι η διαφορά μεταξύ των ορίων Shape και Appearance κατά την απόδοση μιας μικρογραφίας;**

`Shape` χρησιμοποιεί τη γεωμετρία του σχήματος· `Appearance` λαμβάνει υπόψη τα [visual effects](/slides/el/cpp/shape-effect/) (σκιές, λάμψεις κ.λπ.).

**Τι συμβαίνει αν ένα σχήμα είναι επισημασμένο ως κρυφό; Θα εξακολουθεί να αποδίδεται ως μικρογραφία;**

Ένα κρυφό σχήμα παραμένει μέρος του μοντέλου και μπορεί να αποδοθεί· η σημαία κρυφού επηρεάζει την προβολή στη παρουσίαση, αλλά δεν εμποδίζει τη δημιουργία της εικόνας του σχήματος.

**Υποστηρίζονται τα ομαδικά σχήματα, τα διαγράμματα, το SmartArt και άλλα σύνθετα αντικείμενα;**

Ναι. Οποιοδήποτε αντικείμενο που αντιπροσωπεύεται ως [Shape](https://reference.aspose.com/slides/el/cpp/aspose.slides/shape/) (συμπεριλαμβανομένων των [GroupShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/chart/), και [SmartArt](https://reference.aspose.com/slides/el/cpp/aspose.slides.smartart/smartart/)) μπορεί να αποθηκευτεί ως μικρογραφία ή ως SVG.

**Επηρεάζουν οι γραμματοσειρές που είναι εγκατεστημένες στο σύστημα την ποιότητα των μικρογραφιών για σχήματα κειμένου;**

Ναι. Θα πρέπει να [παρέχετε τις απαιτούμενες γραμματοσειρές](/slides/el/cpp/custom-font/) (ή να [ρυθμίσετε αντικαταστάσεις γραμματοσειρών](/slides/el/cpp/font-substitution/)) ώστε να αποφευχθούν ανεπιθύμητες εναλλακτικές και επαναδιάταξη κειμένου.