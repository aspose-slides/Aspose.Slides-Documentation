---
title: Διαχείριση Σχημάτων Παρουσίασης σε C++
linktitle: Μεταχείριση Σχημάτων
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
- λήψη ID σχήματος interop
- εναλλακτικό κείμενο σχήματος
- σημείο ρύθμισης σχήματος
- προκαθορισμένη ρύθμιση σχήματος
- γεωμετρία σχήματος
- μορφές διάταξης σχήματος
- σχήμα ως SVG
- σχήμα σε SVG
- ευθυγράμμιση σχήματος
- αναστροφή σχήματος
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Μάθετε πώς να αναγνωρίζετε, να προσαρμόζετε, να κλωνοποιείτε, να αφαιρείτε, να κρύβετε, να αναδιατάζετε, να εξάγετε, να ευθυγραμμίζετε και να αναστρέφετε σχήματα παρουσίασης με το Aspose.Slides για C++."
---
## **Επισκόπηση**

Το Aspose.Slides for C++ αντιπροσωπεύει τα σχήματα σε μια διαφάνεια ως μια διατεταγμένη [IShapeCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishapecollection/). Η συλλογή είναι τόσο το μέρος όπου βρίσκετε και τροποποιείτε τα σχήματα όσο και η πηγή της σειράς στοιβάγματός τους: το ευρετήριο `0` είναι το πιο πίσω σχήμα, ενώ το τελευταίο ευρετήριο είναι το πιο μπροστινό σχήμα.

Αυτό το άρθρο ακολουθεί το μοντέλο αυτό. Πρώτα εξηγεί πώς να αναγνωρίζετε αξιόπιστα ένα σχήμα και να τροποποιείτε τα προκαθορισμένα σημεία ρύθμισης του σχήματος, στη συνέχεια δείχνει πώς να κλωνοποιείτε, να αφαιρείτε, να κρύβετε και να αναδιατάσσετε σχήματα. Οι τελικές ενότητες καλύπτουν μορφοποίηση επιπέδου διάταξης, εξαγωγή SVG, ευθυγράμμιση και ρυθμίσεις ανάστροφης εμφάνισης. Κάθε παράδειγμα είναι ανεξάρτητο, ώστε να μπορείτε να χρησιμοποιείτε μόνο τις ενέργειες που απαιτεί η ροή εργασίας σας.

## **Αναγνώριση και Εύρεση Σχημάτων**

Οι δείκτες της συλλογής είναι βολικοί κατά την επεξεργασία ενός γνωστού αρχείου, αλλά δεν αποτελούν σταθερά αναγνωριστικά. Η προσθήκη, η αφαίρεση ή η αναδιάταξη ενός σχήματος μπορεί να αλλάξει τον δείκτη του. Επιλέξτε ένα αναγνωριστικό ανάλογα με το πώς δημιουργείται και συντηρείται η παρουσίαση:

- [Name](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/get_name/) είναι χρήσιμο για πρότυπα που ελέγχονται από προγραμματιστές και είναι εύκολο να επιθεωρηθεί στο Πάνελ Επιλογής του PowerPoint. Τα ονόματα μπορούν να επεξεργαστούν και δεν είναι εγγυημένα ότι είναι μοναδικά, οπότε θέστε μια σύμβαση ονοματοδοσίας αν ο κώδικας εξαρτάται από αυτά.
- [AlternativeText](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/get_alternativetext/) είναι χρήσιμο όταν μια περιγραφή προσβασιμότητας ή μια ετικέτα που παρέχεται από τον δημιουργό έχει ήδη ταυτοποιήσει το σχήμα. Είναι ορατό στους χρήστες, μπορεί να μεταφραστεί ή να ξαναγραφεί για προσβασιμότητα, και δεν εγγυάται μοναδικότητα. Μην επαναχρησιμοποιείτε σιωπηρά το περιεχόμενο προσβασιμότητας ως κλειδί βάσης δεδομένων.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/get_officeinteropshapeid/) είναι μόνο για ανάγνωση, μοναδικό εντός μιας διαφάνειας και αντιστοιχεί στο αναγνωριστικό σχήματος που χρησιμοποιείται από το PowerPoint interop. Χρησιμοποιήστε το όταν ενσωματώνετε με το PowerPoint ή όταν χρειάζεστε μια σαφή αναφορά κατά τη διάρκεια της ζωής ενός σχήματος. Ένα κλωνοποιημένο ή ξανά δημιουργημένο σχήμα είναι διαφορετικό σχήμα και λαμβάνει το δικό του ID.

Η σχετική ιδιότητα [UniqueId](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/get_uniqueid/) έχει εμβέλεια παρουσίασης, αλλά προορίζεται για πρόσθετα και μπορεί να εκχωρηθεί ξανά. Δεν πρέπει να θεωρείται μόνιμο εξωτερικό κλειδί. Αν η μακροπρόθεσμη ταυτότητα είναι ουσιώδης, διατηρήστε την αντιστοίχηση στα δεδομένα της εφαρμογής και επαληθεύστε ότι το αναμενόμενο σχήμα εξακολουθεί να υπάρχει.

Το παρακάτω παράδειγμα αναζητά με βάση το `Name` και αναφέρει το ID interop της διαφάνειας. Όταν το πρότυπο δεν περιέχει το αναμενόμενο σχήμα, ο κώδικας αναφέρει αυτό το αποτέλεσμα αντί να συνεχίσει με το λανθασμένο αντικείμενο.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IShape> targetShape;
for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"RevenueChart")
    {
        targetShape = shape;
        break;
    }
}

if (targetShape == nullptr)
{
    Console::WriteLine(u"The shape 'RevenueChart' was not found on slide 1.");
}
else
{
    Console::WriteLine(String::Format(u"Found {0}; interop ID: {1}", targetShape->get_Name(), targetShape->get_OfficeInteropShapeId()));
}

presentation->Dispose();
```

Όταν μια λειτουργία είναι συγκεκριμένη για τύπο σχήματος, ελέγξτε τη διεπαφή πριν χρησιμοποιήσετε μέλη τύπου-συγκεκριμένα. Το παράδειγμα αυτό ενημερώνει το κείμενο και το εναλλακτικό κείμενο μόνο εάν το ονομασμένο αντικείμενο είναι ένα [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/).

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IShape> candidate;
for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"StatusLabel")
    {
        candidate = shape;
        break;
    }
}

if (candidate != nullptr && ObjectExt::Is<IAutoShape>(candidate))
{
    auto autoShape = ExplicitCast<IAutoShape>(candidate);
    autoShape->get_TextFrame()->set_Text(u"Approved");
    autoShape->set_AlternativeText(u"Approval status: approved");
    presentation->Save(u"identified-shape.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"'StatusLabel' is missing or is not an AutoShape.");
}

presentation->Dispose();
```

## **Αναγνώριση και Τροποποίηση Προκαθορισμένων Ρυθμίσεων Σχήματος**

Τα σχήματα προεπιλογής γεωμετρίας μπορούν να εκθέσουν σημεία ρύθμισης που ελέγχουν χαρακτηριστικά όπως το μέγεθος γωνίας, τις αναλογίες βέλους ή τις γωνίες τόξου. Πρόσβαση σε αυτά γίνεται μέσω της μόνο-ανάγνωσης συλλογής [IGeometryShape::get_Adjustments](https://reference.aspose.com/slides/el/cpp/aspose.slides/igeometryshape/get_adjustments/). Η ίδια η συλλογή παρέχεται από το σχήμα, αλλά κάθε [IAdjustValue](https://reference.aspose.com/slides/el/cpp/aspose.slides/iadjustvalue/) περιέχει μια τιμή που μπορεί να αλλάξει.

Μη βασίζεστε μόνο σε ένα σταθερό δείκτη συλλογής. Περπατήστε τις ρυθμίσεις και εξετάστε την ιδιότητα μόνο-ανάγνωσης [IAdjustValue::get_Type](https://reference.aspose.com/slides/el/cpp/aspose.slides/iadjustvalue/get_type/), της οποίας η τιμή [ShapeAdjustmentType](https://reference.aspose.com/slides/el/cpp/aspose.slides/shapeadjustmenttype/) περιγράφει τι ελέγχει η ρύθμιση. Η ιδιότητα μόνο-ανάγνωσης [IAdjustValue::get_Name](https://reference.aspose.com/slides/el/cpp/aspose.slides/iadjustvalue/get_name/) παρέχει επιπλέον πληροφορίες ταυτοποίησης και είναι ιδιαίτερα χρήσιμη όταν μια προεπιλογή περιέχει περισσότερες από μία ρυθμίσεις με τον ίδιο σημασιολογικό τύπο.

Χρησιμοποιήστε την ιδιότητα τιμής που ταιριάζει με το νόημα της ρύθμισης:

| Τύπος προσαρμογής | Σκοπός | Τιμή προς αλλαγή |
|---|---|---|
| `CornerSize` | Μέγεθος στρογγυλεμένων γωνιών | [RawValue](https://reference.aspose.com/slides/el/cpp/aspose.slides/iadjustvalue/set_rawvalue/) |
| `ArrowTailThickness` | Πάχος ουράς βέλους | `RawValue` |
| `ArrowheadLength` | Μήκος άκρου βέλους | `RawValue` |
| `ArrowheadWidth` | Πλάτος άκρου βέλους | `RawValue` |
| `StartAngle` | Αρχική γωνία πίτας ή τόξου | [AngleValue](https://reference.aspose.com/slides/el/cpp/aspose.slides/iadjustvalue/set_anglevalue/) |
| `EndAngle` | Τελική γωνία πίτας ή τόξου | `AngleValue` |

Το `Type` και το `Name` δεν μπορούν να εκχωρηθούν. Το `RawValue` είναι ένας ακέραιος αναγνώσιμος/εγγράψιμος στις εγγενείς μονάδες γεωμετρίας της προεπιλογής, ενώ το `AngleValue` είναι μία γωνία αναγνώσιμη/εγγράψιμη σε μοίρες. Ο αριθμός, η σειρά, το νόημα και το έγκυρο εύρος των ρυθμίσεων εξαρτώνται από τον τύπο προεπιλογής [ShapeType](https://reference.aspose.com/slides/el/cpp/aspose.slides/igeometryshape/get_shapetype/). Μία τιμή που είναι έγκυρη για μία προεπιλογή μπορεί να είναι άκυρη ή να έχει διαφορετικό αποτέλεσμα για άλλη.

Όταν το `Type` είναι `ShapeAdjustmentType::Custom`, το API δεν αναγνωρίζει τυπικό σημασιολογικό νόημα. Εξετάστε το `Name`, τον τύπο προεπιλογής και την υπάρχουσα τιμή, και αφήστε την ρύθμιση αμετάβλητη εκτός εάν γνωρίζετε το αναμενόμενο νόημα και εύρος. Ακόμη και για αναγνωρισμένους τύπους, ελέγξτε αν ο ίδιος τύπος εμφανίζεται περισσότερο από μία φορά πριν επιλέξετε τιμή. Το άρθρο [Connector](/slides/el/cpp/connector/) δείχνει αυτήν την κατάσταση με ρυθμίσεις κάμπυλης σύνδεσμου.

Το παρακάτω ολοκληρωμένο παράδειγμα δημιουργεί προεπιλεγμένες και τροποποιημένες εκδοχές τριών προεπιλεγμένων σχημάτων. Περπατά μέσα από κάθε ρύθμιση, αναφέρει το `Name` και το `Type`, αλλάζει τις τιμές που σχετίζονται με μέγεθος μέσω `RawValue`, αλλάζει γωνίες μέσω `AngleValue`, και αποθηκεύει το αποτέλεσμα. Η αριστερή στήλη διατηρεί τη προεπιλεγμένη γεωμετρία· η δεξιά στήλη δείχνει το προσαρμοσμένο στρογγυλεμένο ορθογώνιο, το τετραπλό βέλος και την πίτα.

```cpp
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Προσθέτει κεφαλίδες για τις στήλες προεπιλεγμένου και προσαρμοσμένου σχήματος.
auto defaultColumnLabel = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 20, 250, 30);
defaultColumnLabel->get_TextFrame()->set_Text(u"Default preset geometry");
auto adjustedColumnLabel = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 390, 20, 250, 30);
adjustedColumnLabel->get_TextFrame()->set_Text(u"Modified adjustment values");

slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 80, 70, 160, 70);
auto modifiedRoundedRectangle = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 430, 70, 160, 70);
modifiedRoundedRectangle->set_Name(u"ModifiedRoundedRectangle");

slide->get_Shapes()->AddAutoShape(ShapeType::QuadArrow, 80, 180, 160, 110);
auto modifiedArrow = slide->get_Shapes()->AddAutoShape(ShapeType::QuadArrow, 430, 180, 160, 110);
modifiedArrow->set_Name(u"ModifiedQuadArrow");

slide->get_Shapes()->AddAutoShape(ShapeType::Pie, 95, 330, 130, 130);
auto modifiedPie = slide->get_Shapes()->AddAutoShape(ShapeType::Pie, 445, 330, 130, 130);
modifiedPie->set_Name(u"ModifiedPie");

auto shapesToAdjust = MakeArray<SharedPtr<IGeometryShape>>({modifiedRoundedRectangle, modifiedArrow, modifiedPie});

for (auto shape : shapesToAdjust)
{
    auto adjustments = shape->get_Adjustments();
    for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
    {
        auto adjustment = adjustments->idx_get(adjustmentIndex);
        Console::WriteLine(shape->get_Name() + u" / " + adjustment->get_Name() + u": " + ObjectExt::ToString(adjustment->get_Type()));

        switch (adjustment->get_Type())
        {
            case ShapeAdjustmentType::CornerSize:
                adjustment->set_RawValue(5000);
                break;
            case ShapeAdjustmentType::ArrowTailThickness:
                adjustment->set_RawValue(25000);
                break;
            case ShapeAdjustmentType::ArrowheadLength:
                adjustment->set_RawValue(30000);
                break;
            case ShapeAdjustmentType::ArrowheadWidth:
                adjustment->set_RawValue(40000);
                break;
            case ShapeAdjustmentType::StartAngle:
                adjustment->set_AngleValue(30);
                break;
            case ShapeAdjustmentType::EndAngle:
                adjustment->set_AngleValue(300);
                break;
            case ShapeAdjustmentType::Custom:
                Console::WriteLine(u"Custom adjustment '" + adjustment->get_Name() + u"' was not changed.");
                break;
        }
    }
}

presentation->Save(u"preset-shape-adjustments.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Ο έλεγχος του τύπου σημασιολογίας πριν την αλλαγή τιμής κάνει τον κώδικα σαφή σχετικά με την πρόθεσή του και αποτρέπει την υπόθεση ότι ένας συγκεκριμένος δείκτης συλλογής έχει το ίδιο νόημα σε διαφορετικά προεπιλεγμένα σχήματα.

## **Τροποποίηση της Συλλογής Σχημάτων**

Οι μέθοδοι προσθήκης, κλωνοποίησης, αφαίρεσης και αναδιάταξης λειτουργούν αμέσως πάνω στη συλλογή. Εάν μια λειτουργία αλλάζει τον αριθμό ή τη σειρά των σχημάτων, μην συνεχίσετε να βασίζεστε σε δείκτες που ελήφθησαν πριν από αυτή τη λειτουργία.

### **Κλωνοποίηση Σχήματος**

[AddClone](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishapecollection/addclone/) δημιουργεί ένα ανεξάρτητο αντίγραφο και το προσθέτει στο στοχευμένο σύνολο. [InsertClone](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishapecollection/insertclone/) επίσης δημιουργεί ένα αντίγραφο αλλά το τοποθετεί σε καθορισμένο δείκτη z‑order. Οι υπερφορτώσεις που δέχονται συντεταγμένες μετακινούν το κλώνος χωρίς να αλλάζουν το μέγεθός του· οι υπερφορτώσεις με πλάτος και ύψος μπορούν επίσης να το αναγκάσουν σε αλλαγή μεγέθους.

Το παράδειγμα δημιουργεί μια διαφάνεια προορισμού, κλωνοποιεί ένα επισημασμένο ορθογώνιο προς τα εμπρός και εισάγει ένα δεύτερο κλώνο προς τα πίσω. Αλλαγές σε οποιονδήποτε κλώνο δεν τροποποιούν το αρχικό σχήμα.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto sourceSlide = presentation->get_Slide(0);
auto sourceShape = sourceSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 180, 60);
sourceShape->set_Name(u"SourceLabel");
sourceShape->get_TextFrame()->set_Text(u"Source");

auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto destinationSlide = presentation->get_Slides()->AddEmptySlide(blankLayout);

auto frontCloneShape = destinationSlide->get_Shapes()->AddClone(sourceShape, 80, 80);
frontCloneShape->set_Name(u"FrontClone");
if (ObjectExt::Is<IAutoShape>(frontCloneShape))
{
    auto frontClone = ExplicitCast<IAutoShape>(frontCloneShape);
    frontClone->get_TextFrame()->set_Text(u"Front clone");
}
else
{
    Console::WriteLine(u"The front clone is not an AutoShape; its text was not changed.");
}

auto backCloneShape = destinationSlide->get_Shapes()->InsertClone(0, sourceShape, 80, 180);
backCloneShape->set_Name(u"BackClone");
if (ObjectExt::Is<IAutoShape>(backCloneShape))
{
    auto backClone = ExplicitCast<IAutoShape>(backCloneShape);
    backClone->get_TextFrame()->set_Text(u"Back clone");
}
else
{
    Console::WriteLine(u"The back clone is not an AutoShape; its text was not changed.");
}

presentation->Save(u"cloned-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Η κλωνοποίηση αντιγράφει το περιεχόμενο και τη μορφοποίηση του σχήματος, συμπεριλαμβανομένων του ονόματος και του εναλλακτικού κειμένου. Εκχωρήστε νέες λογικές ταυτοποιήσεις στο κλώνο όταν αυτές οι τιμές πρέπει να είναι μοναδικές. Οι πόροι που χρησιμοποιούνται από σύνθετα σχήματα διαχειρίζονται από την παρουσίαση, αλλά ένα κλώνο παραμένει νέο στοιχείο της συλλογής με νέα ταυτότητα σχήματος.

### **Αφαίρεση Σχημάτων**

[Remove](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishapecollection/remove/) διαγράφει ένα συγκεκριμένο αντικείμενο σχήματος από τη συλλογή του. Όταν αφαιρείτε πολλαπλές αντιστοιχίσεις κατά τη διάρκεια επαναληπτικής επεξεργασίας με δείκτες, διασχίστε από το τέλος ώστε κάθε υπόλοιπος δείκτης να παραμένει έγκυρος.

Το παράδειγμα αφαιρεί κάθε σχήμα με καθορισμένο όνομα. Διαβάζει το τρέχον σχήμα με βάση τον δείκτη, όχι ένα σταθερό στοιχείο συλλογής, και δεν κάνει περιττές μετατροπές τύπου.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto keepShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 140, 60);
keepShape->set_Name(u"Keep");

auto firstTemporaryShape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 220, 40, 80, 80);
firstTemporaryShape->set_Name(u"Temporary");

auto secondTemporaryShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 340, 40, 100, 80);
secondTemporaryShape->set_Name(u"Temporary");

for (int32_t i = slide->get_Shapes()->get_Count() - 1; i >= 0; --i)
{
    auto shape = slide->get_Shape(i);
    if (shape->get_Name() == u"Temporary")
    {
        slide->get_Shapes()->Remove(shape);
    }
}

presentation->Save(u"removed-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Μετά την αφαίρεση, ο αριθμός σχημάτων και οι δείκτες των επόμενων σχημάτων αλλάζουν. Οι αναφορές σε ανεπηρέαστα σχήματα παραμένουν πιο αξιόπιστες από αποθηκευμένους δείκτες. Επίσης λάβετε υπόψη συνδέσμους, αναπαραγωγές και άλλες λειτουργίες παρουσίασης που μπορεί να αναφέρονται στο αφαιρεθέν αντικείμενο· η αφαίρεση ενός ορατού σχήματος μπορεί να αλλάξει περισσότερο από την εμφάνιση της διαφάνειας.

### **Απόκρυψη Σχήματος**

Ορίζοντας [Hidden](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/set_hidden/) σε `true` κρατά το σχήμα στη συλλογή αλλά εμποδίζει την εμφάνισή του στην κανονική παρουσίαση. Ο δείκτης, η μορφοποίηση και το περιεχόμενο παραμένουν διαθέσιμα στον κώδικα, έτσι η απόκρυψη είναι κατάλληλη για προαιρετικά στοιχεία που μπορεί να επαναφερθούν αργότερα.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto visibleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 160, 60);
visibleShape->set_Name(u"VisibleLabel");

auto optionalShape = slide->get_Shapes()->AddAutoShape(ShapeType::Moon, 240, 40, 100, 100);
optionalShape->set_Name(u"OptionalDecoration");

for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"OptionalDecoration")
    {
        shape->set_Hidden(true);
    }
}

presentation->Save(u"hidden-shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Η απόκρυψη δεν είναι διαγραφή ή ασφάλεια. Το αντικείμενο μπορεί ακόμα να εντοπισθεί και να αποκρυφθεί από χρήστη ή κώδικα, και παραμένει μέρος του αρχείου παρουσίασης.

### **Αλλαγή του Z‑Order**

Τα επικαλυπτόμενα σχήματα ζωγραφίζονται με τη σειρά της συλλογής. [Reorder](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishapecollection/reorder/) μετακινεί ένα υπάρχον σχήμα σε έναν στόχο δείκτη χωρίς κλωνοποίηση. Ο δείκτης `0` είναι το πίσω, το `Count - 1` είναι το εμπρός.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto blueRectangle = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 220, 120);
blueRectangle->set_Name(u"BlueRectangle");
blueRectangle->get_FillFormat()->set_FillType(FillType::Solid);
blueRectangle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_SteelBlue());

auto orangeEllipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 180, 140, 220, 120);
orangeEllipse->set_Name(u"OrangeEllipse");
orangeEllipse->get_FillFormat()->set_FillType(FillType::Solid);
orangeEllipse->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());

slide->get_Shapes()->Reorder(slide->get_Shapes()->get_Count() - 1, blueRectangle);
presentation->Save(u"reordered-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το ορθογώνιο δημιουργείται πρώτα και αρχικά βρίσκεται πίσω από την έλλειψη. Η μετακίνηση του στον τελικό δείκτη το φέρνει εμπρός. Ολοκληρώστε το z‑order αφού προσθέσετε ή κλωνοποιήσετε όλα τα σχετικά σχήματα, επειδή αυτές οι λειτουργίες προσθέτουν ή εισάγουν νέα στοιχεία στη συλλογή και μπορούν να αλλάξουν την επιθυμητή στοίβα.

## **Επιθεώρηση Σχημάτων σε Διαφάνειες Διάταξης**

Οι κανονικές διαφάνειες, οι διαφάνειες διάταξης και οι κύριες διαφάνειες έχουν ξεχωριστές συλλογές σχημάτων. Ένα σχήμα σε συλλογή διάταξης δεν είναι το ίδιο αντικείμενο με ένα παρόμοιο σχήμα σε κανονική διαφάνεια. Επιθεωρήστε τα σχήματα διάταξης όταν χρειάζεται να καταλάβετε ή να αλλάξετε μορφοποίηση που παρέχεται από μια διάταξη.

Το παρακάτω παράδειγμα διαβάζει το [FillFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/get_fillformat/) και το [LineFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/get_lineformat/) κάθε σχήματος διάταξης χωρίς την υπόθεση ότι κάθε σχήμα είναι `AutoShape`.

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto layoutSlide : presentation->get_LayoutSlides())
{
    for (auto shape : layoutSlide->get_Shapes())
    {
        auto fillType = shape->get_FillFormat()->get_FillType();
        auto lineWidth = shape->get_LineFormat()->get_Width();
        Console::WriteLine(String::Format(u"{0} / {1}: fill={2}, line width={3}", layoutSlide->get_Name(), shape->get_Name(), fillType, lineWidth));
    }
}

presentation->Dispose();
```

Η επεξεργασία μιας διάταξης μπορεί να επηρεάσει πολλές διαφάνειες που τη χρησιμοποιούν. Πριν αλλάξετε ένα σχήμα διάταξης, προσδιορίστε εάν μια κανονική διαφάνεια κληρονομεί το αντικείμενο ή περιέχει τοπική παράκαμψη, και δοκιμάστε κάθε διαφάνεια που χρησιμοποιεί τη διάταξη.

## **Εξαγωγή Σχήματος σε SVG**

[WriteAsSvg](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/writeassvg/) γράφει το αποδιδόμενο περιεχόμενο ενός σχήματος σε μια ροή. Το αποτέλεσμα περιέχει μόνο το σχήμα, όχι το πλήρες φόντο της διαφάνειας ή τα γειτονικά σχήματα.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

if (slide->get_Shapes()->get_Count() == 0)
{
    Console::WriteLine(u"Slide 1 does not contain a shape to export.");
}
else
{
    auto shape = slide->get_Shape(0);
    auto svgStream = File::Create(u"shape.svg");
    shape->WriteAsSvg(svgStream);
    svgStream->Close();
}

presentation->Dispose();
```

Διατηρήστε την παρουσίαση ανοικτή κατά τη διάρκεια της απόδοσης. Η έξοδος εξαρτάται από τη μορφοποίηση του σχήματος και από πόρους όπως γραμματοσειρές και εικόνες. Αν χρειάζεστε ολόκληρη τη σύνθεση, εξάγετε τη διαφάνεια αντί για το μεμονωμένο σχήμα. Ο καλούντας κατέχει τη ροή και πρέπει να τη κλείσει ή να την αποδεσμεύσει.

## **Ευθυγράμμιση Σχημάτων**

Οι υπερφορτώσεις [SlideUtil::AlignShapes](https://reference.aspose.com/slides/el/cpp/aspose.slides.util/slideutil/alignshapes/) ευθυγραμμίζουν είτε όλα τα σχήματα είτε επιλεγμένους δείκτες συλλογής. [ShapesAlignmentType](https://reference.aspose.com/slides/el/cpp/aspose.slides/shapesalignmenttype/) καθορίζει το άκρο, τη κεντρική γραμμή ή τη λειτουργία κατανομής. Ορίστε `alignToSlide` σε `true` για χρήση των άκρων της διαφάνειας· ορίστε το σε `false` για ευθυγράμμιση των επιλεγμένων σχημάτων μεταξύ τους.

Το παράδειγμα ευθυγραμμίζει τρία σχήματα στην επάνω άκρη της διαφάνειας. Οι επιστρεφόμενες αναφορές σχήματος μετατρέπονται αμέσως στους τρέχοντες δείκτες τους πριν την ευθυγράμμιση.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/ShapesAlignmentType.h>
#include <Export/SaveFormat.h>
#include <Util/SlideUtil.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Util;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto firstShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 60, 80, 120, 50);
auto secondShape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 240, 160, 120, 50);
auto thirdShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 420, 240, 120, 50);
firstShape->set_Name(u"FirstAlignedShape");
secondShape->set_Name(u"SecondAlignedShape");
thirdShape->set_Name(u"ThirdAlignedShape");

auto shapeIndexes = MakeArray<int32_t>({slide->get_Shapes()->IndexOf(firstShape), slide->get_Shapes()->IndexOf(secondShape), slide->get_Shapes()->IndexOf(thirdShape)});

SlideUtil::AlignShapes(ShapesAlignmentType::AlignTop, true, slide, shapeIndexes);
presentation->Save(u"aligned-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Η ευθυγράμμιση αλλάζει τις θέσεις, όχι το z‑order. Η σχετική ευθυγράμμιση συνήθως απαιτεί τουλάχιστον δύο σχήματα, ενώ η οριζόντια ή κάθετη κατανομή χρειάζεται αρκετά σχήματα για να ορίσει το διάστημα. Υπολογίστε εκ νέου τους δείκτες αν τροποποιήσετε τη συλλογή πριν καλέσετε τη μέθοδο.

## **Αναστροφή Σχήματος**

Η κλάση [ShapeFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/shapeframe/) αποθηκεύει θέση, μέγεθος, οριζόντιες και κάθετες ρυθμίσεις ανάστροφης εμφάνισης και περιστροφή. Οι τιμές `FlipH` και `FlipV` χρησιμοποιούν [NullableBool](https://reference.aspose.com/slides/el/cpp/aspose.slides/nullablebool/): `True` ενεργοποιεί την ανάστροφη εμφάνιση, `False` την απενεργοποιεί, και `NotDefined` διατηρεί την ακαθόριστη/προεπιλεγμένη κατάσταση.

Η παρακάτω παρουσίαση εισόδου περιέχει ένα μη αναστροφομένο σχήμα.

![The shape before flipping](shape_to_be_flipped.png)

Το παράδειγμα διατηρεί κάθε άλλη τιμή πλαισίου και αντικαθιστά μόνο τις δύο ρυθμίσεις ανάστροφης εμφάνισης. Αυτό είναι σημαντικό επειδή η εκχώρηση ενός νέου [Frame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/set_frame/) αντικαθιστά ολόκληρο το πλαίσιο.

```cpp
#include <DOM/IShape.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeFrame.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto frame = shape->get_Frame();

Console::WriteLine(String::Format(u"Horizontal flip before change: {0}", frame->get_FlipH()));
Console::WriteLine(String::Format(u"Vertical flip before change: {0}", frame->get_FlipV()));

shape->set_Frame(MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y(), frame->get_Width(), frame->get_Height(), NullableBool::True, NullableBool::True, frame->get_Rotation()));

presentation->Save(u"flipped-shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποθηκευμένο σχήμα αντικατοπτρίζεται οριζόντια και κάθετα διατηρώντας τη θέση, το μέγεθος και την περιστροφή.

![The shape after flipping](flipped_shape.png)

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Θα πρέπει να χρησιμοποιήσω έναν δείκτη συλλογής ως αναγνωριστικό σχήματος;**

Μόνο για βραχύβια επεξεργασία όταν η συλλογή δεν θα αλλάξει πριν από τη χρήση του δείκτη. Προτιμήστε μια επικυρωμένη σύμβαση `Name` ή `AlternativeText` για πρότυπα που δημιουργούνται, ή `OfficeInteropShapeId` για εργασίες interop εντός διαφάνειας.

**Αν κρύβω ένα σχήμα αφαιρείται από το z‑order;**

Όχι. Ένα κρυφό σχήμα παραμένει στη συλλογή στο ίδιο δείκτη. Μπορεί να βρεθεί, να αναδιαταχθεί, να επεξεργαστεί ή να γίνει ξανά ορατό.

**Γιατί ένα κλωνοποιημένο σχήμα εμφανίστηκε μπροστά από άλλο σχήμα;**

Το `AddClone` προσθέτει το κλώνο στο τέλος της συλλογής, που είναι το μπροστινό μέρος του z‑order. Χρησιμοποιήστε `InsertClone` για επιλογή αρχικού δείκτη ή `Reorder` μετά την προσθήκη όλων των σχημάτων.

**Μπορώ να χρησιμοποιήσω σταθερό δείκτη για την αναγνώριση προεπιλεγμένης ρύθμισης σχήματος;**

Μόνο μετά τον έλεγχο της ακριβούς προεπιλογής και της διάταξης της συλλογής. Προτιμήστε τη διαπέραση του `IGeometryShape::get_Adjustments` και τον έλεγχο του `IAdjustValue::get_Type`; χρησιμοποιήστε το `IAdjustValue::get_Name` ως επιπλέον πληροφορία όταν εμφανίζεται ο ίδιος σημασιολογικός τύπος περισσότερες από μία φορές.