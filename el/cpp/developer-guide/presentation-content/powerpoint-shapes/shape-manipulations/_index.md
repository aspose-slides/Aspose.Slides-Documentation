---
title: Διαχείριση Σχημάτων Παρουσίασης σε C++
linktitle: Χειρισμός Σχημάτων
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
- σημείο προσαρμογής σχήματος
- προεπιλεγμένη προσαρμογή σχήματος
- γεωμετρία σχήματος
- μορφές διάταξης σχήματος
- σχήμα ως SVG
- σχήμα σε SVG
- στοίχιση σχήματος
- αντιστροφή σχήματος
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Μάθετε πώς να εντοπίζετε, προσαρμόζετε, κλωνοποιείτε, αφαιρείτε, κρύβετε, αναδιατάζετε, εξάγετε, στοιχίζετε και αντιστρέφετε σχήματα παρουσίασης με το Aspose.Slides για C++."
---
## **Επισκόπηση**

Aspose.Slides for C++ αντιπροσωπεύει τα σχήματα σε μια διαφάνεια ως μια ταξινομημένη [IShapeCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishapecollection/). Η συλλογή αποτελεί τόσο τον χώρο όπου βρίσκετε και τροποποιείτε σχήματα, όσο και την πηγή της σειράς στοιβάξης τους: ο δείκτης `0` είναι το πιο πίσω σχήμα, ενώ ο τελευταίος δείκτης είναι το πιο μπροστινό σχήμα.

Αυτό το άρθρο ακολουθεί αυτό το μοντέλο. Πρώτα εξηγεί πώς να εντοπίζετε ένα σχήμα αξιόπιστα και να τροποποιείτε προκαθορισμένα σημεία προσαρμογής σχήματος, στη συνέχεια δείχνει πώς να κλωνοποιείτε, να αφαιρείτε, να κρύβετε και να αναδιατάξετε σχήματα. Τα τελικά τμήματα καλύπτουν μορφοποίηση σε επίπεδο διάταξης, εξαγωγή SVG, στοίχιση και ρυθμίσεις αντιστροφής. Κάθε παράδειγμα είναι ανεξάρτητο, ώστε να μπορείτε να χρησιμοποιήσετε μόνο τις λειτουργίες που απαιτούνται από τη ροή εργασίας σας.

## **Εντοπισμός και Εύρεση Σχημάτων**

Οι δείκτες της συλλογής είναι βολικοί όταν επεξεργάζεστε ένα γνωστό αρχείο, αλλά δεν αποτελούν σταθερά αναγνωριστικά. Η προσθήκη, η αφαίρεση ή η αναδιάταξη ενός σχήματος μπορεί να αλλάξει τον δείκτη του. Επιλέξτε ένα αναγνωριστικό ανάλογα με το πώς δημιουργείται και συντηρείται η παρουσίαση:

- [Name](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/get_name/) είναι χρήσιμο για πρότυπα ελεγχόμενα από προγραμματιστές και είναι εύκολο να το επιθεωρήσετε στο Selection Pane του PowerPoint. Τα ονόματα μπορούν να επεξεργαστούν και δεν εγγυώνται μοναδικότητα, επομένως καθιερώστε μια σύμβαση ονοματοδοσίας αν ο κώδικας εξαρτάται από αυτά.
- [AlternativeText](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/get_alternativetext/) είναι χρήσιμο όταν μια περιγραφή προσβασιμότητας ή μια ετικέτα που παρέχεται από το δημιουργό ήδη ταυτοποιεί το σχήμα. Είναι ορατό στους χρήστες, μπορεί να μεταφραστεί ή να ξαναγραφτεί για προσβασιμότητα, και δεν εγγυάται μοναδικότητα. Μην επαναχρησιμοποιείτε σιωπηρά σημαντικό κείμενο προσβασιμότητας ως κλειδί βάσης δεδομένων.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/get_officeinteropshapeid/) είναι ένα αναγνωριστικό μόνο για ανάγνωση που είναι μοναδικό σε μία διαφάνεια και αντιστοιχεί στο ID σχήματος που χρησιμοποιεί το PowerPoint interop. Χρησιμοποιήστε το όταν ενσωματώνετε με το PowerPoint ή όταν χρειάζεστε μια σαφή αναφορά κατά τη διάρκεια ζωής ενός σχήματος. Ένα κλωνοποιημένο ή επανδημιουργημένο σχήμα είναι διαφορετικό σχήμα και λαμβάνει το δικό του ID.

Η σχετική ιδιότητα [UniqueId](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/get_uniqueid/) έχει εμβέλεια παρουσίασης, αλλά προορίζεται για πρόσθετα και μπορεί να επαναχρηστοποιηθεί. Δεν πρέπει να θεωρείται μόνιμο εξωτερικό κλειδί. Αν η μακροπρόθεσμη ταυτότητα είναι απαραίτητη, κρατήστε την αντιστοίχιση στα δεδομένα της εφαρμογής και επαληθεύστε ότι το αναμενόμενο σχήμα υπάρχει ακόμη.

Για ένα πρακτικό παράδειγμα ανάγνωσης και ενημέρωσης τόσο του τίτλου εναλλακτικού κειμένου όσο και της περιγραφής, δείτε [Manage Alternative Text Titles and Descriptions](/slides/el/cpp/presentation-accessibility/). Χρησιμοποιήστε το εναλλακτικό κείμενο για να εξηγήσετε το νόημα του οπτικού περιεχομένου στους αναγνώστες και κρατήστε το ξεχωριστά από τα ονόματα σχημάτων που χρησιμοποιεί ο κώδικας για εύρεση σχημάτων.

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

Όταν μια λειτουργία είναι ειδική για τύπο σχήματος, ελέγξτε το interface πριν χρησιμοποιήσετε μέλη που αφορούν συγκεκριμένο τύπο. Αυτό το παράδειγμα ενημερώνει το κείμενο και το εναλλακτικό κείμενο μόνο εάν το ονομασμένο αντικείμενο είναι ένα [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/).

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

## **Εντοπισμός και Τροποποίηση Προκαθορισμένων Προσαρμογών Σχήματος**

Τα σχήματα προεπιλεγμένης γεωμετρίας μπορούν να εκθέτουν σημεία προσαρμογής που ελέγχουν χαρακτηριστικά όπως το μέγεθος γωνίας, οι αναλογίες βέλους ή οι γωνίες τόξου. Πρόσβαση σε αυτά μέσω της συλλογής μόνο για ανάγνωση [IGeometryShape::get_Adjustments](https://reference.aspose.com/slides/el/cpp/aspose.slides/igeometryshape/get_adjustments/). Η ίδια η συλλογή παρέχεται από το σχήμα, αλλά κάθε [IAdjustValue](https://reference.aspose.com/slides/el/cpp/aspose.slides/iadjustvalue/) περιέχει μια τιμή που μπορεί να αλλάξει.

Μην βασίζεστε μόνο σε σταθερό δείκτη συλλογής. Διατρέξτε τις προσαρμογές και ελέγξτε την ιδιότητα μόνο για ανάγνωση [IAdjustValue::get_Type](https://reference.aspose.com/slides/el/cpp/aspose.slides/iadjustvalue/get_type/), του οποίου η τιμή [ShapeAdjustmentType](https://reference.aspose.com/slides/el/cpp/aspose.slides/shapeadjustmenttype/) περιγράφει τι ελέγχει η προσαρμογή. Η ιδιότητα μόνο για ανάγνωση [IAdjustValue::get_Name](https://reference.aspose.com/slides/el/cpp/aspose.slides/iadjustvalue/get_name/) παρέχει πρόσθετες πληροφορίες ταυτοποίησης και είναι ιδιαίτερα χρήσιμη όταν ένα προεπιλεγμένο σχήμα περιέχει περισσότερες από μία προσαρμογές με τον ίδιο σημασιολογικό τύπο.

Χρησιμοποιήστε την ιδιότητα τιμής που ταιριάζει με το νόημα της προσαρμογής:

| Τύπος προσαρμογής | Σκοπός | Τιμή προς αλλαγή |
|---|---|---|
| `CornerSize` | Μέγεθος στρογγυλεμένων γωνιών | [RawValue](https://reference.aspose.com/slides/el/cpp/aspose.slides/iadjustvalue/set_rawvalue/) |
| `ArrowTailThickness` | Πάχος της ουράς ενός βέλους | `RawValue` |
| `ArrowheadLength` | Μήκος της άκρης του βέλους | `RawValue` |
| `ArrowheadWidth` | Πλάτος της άκρης του βέλους | `RawValue` |
| `StartAngle` | Αρχική γωνία πίτας ή τόξου | [AngleValue](https://reference.aspose.com/slides/el/cpp/aspose.slides/iadjustvalue/set_anglevalue/) |
| `EndAngle` | Τελική γωνία πίτας ή τόξου | `AngleValue` |

`Type` και `Name` δεν μπορούν να ανατεθούν. `RawValue` είναι ακέραιος ανάγνωσης/εγγραφής στις εγγενείς μονάδες γεωμετρίας του προεπιλεγμένου σχήματος, ενώ `AngleValue` είναι γωνία ανάγνωσης/εγγραφής σε μοίρες. Ο αριθμός, η σειρά, το νόημα και το έγκυρο εύρος των προσαρμογών εξαρτώνται από το προεπιλεγμένο [ShapeType](https://reference.aspose.com/slides/el/cpp/aspose.slides/igeometryshape/get_shapetype/). Μια τιμή που είναι έγκυρη για ένα προεπιλεγμένο σχήμα μπορεί να είναι άκυρη ή να έχει διαφορετικό αποτέλεσμα για άλλο.

Όταν `Type` είναι `ShapeAdjustmentType::Custom`, το API δεν αναγνωρίζει κάποιο τυπικό σημασιολογικό νόημα. Εξετάστε το `Name`, τον τύπο του προεπιλεγμένου σχήματος και την υπάρχουσα τιμή, και αφήστε την προσαρμογή αμετάβλητη εκτός αν το αναμενόμενο νόημα και εύρος είναι γνωστά. Ακόμη και για αναγνωρισμένους τύπους, ελέγξτε αν ο ίδιος τύπος εμφανίζεται περισσότερες από μία φορές πριν επιλέξετε τιμή. Το άρθρο [Connector](/slides/el/cpp/connector/) δείχνει αυτήν την κατάσταση με προσαρμογές κάμψης συνδετήρα.

Το παρακάτω πλήρες παράδειγμα δημιουργεί προεπιλεγμένες και τροποποιημένες εκδόσεις τριών προεπιλεγμένων σχημάτων. Διατρέχει κάθε προσαρμογή, αναφέρει το `Name` και το `Type`, αλλάζει τιμές σχετικές με το μέγεθος μέσω `RawValue`, αλλάζει γωνίες μέσω `AngleValue` και αποθηκεύει το αποτέλεσμα. Η αριστερή στήλη διατηρεί τη γεωμετρία προεπιλογής· η δεξιά στήλη δείχνει το προσαρμοσμένο στρογγυλεμένο ορθογώνιο, το βέλος τεσσάρων κατευθύνσεων και την πίτα.

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

// Προσθέτει επικεφαλίδες για τις στήλες προεπιλεγμένου και προσαρμοσμένου σχήματος.
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

Ο έλεγχος του σημασιολογικού τύπου πριν την αλλαγή τιμής κάνει τον κώδικα ρητό ως προς το σκοπό του και αποφεύγει την υπόθεση ότι ένας συγκεκριμένος δείκτης συλλογής έχει το ίδιο νόημα σε διαφορετικά προεπιλεγμένα σχήματα.

## **Τροποποίηση Συλλογής Σχημάτων**

Οι μέθοδοι προσθήκης, κλωνοποίησης, αφαίρεσης και αναδιάταξης λειτουργούν αμέσως στη συλλογή. Εάν μια λειτουργία αλλάξει τον αριθμό ή τη σειρά των σχημάτων, μην συνεχίσετε να βασίζεστε σε δείκτες που λήφθηκαν πριν από αυτή τη λειτουργία.

### **Κλωνοποίηση Σχήματος**

[AddClone](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishapecollection/addclone/) δημιουργεί ανεξάρτητο αντίγραφο και το προσαρτά στη συλλογή-στόχο. [InsertClone](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishapecollection/insertclone/) επίσης δημιουργεί αντίγραφο, αλλά το τοποθετεί σε καθορισμένο δείκτη z-order. Οι υπερφορτώσεις που δέχονται συντεταγμένες μετακινούν το αντίγραφο χωρίς να αλλάζουν το μέγεθός του· οι υπερφορτώσεις με πλάτος και ύψος μπορούν επίσης να το μεγεθύνουν.

Το παράδειγμα δημιουργεί μια διαφάνεια προορισμού, κλωνοποιεί ένα ορθογώνιο με ετικέτα προς τα εμπρός και εισάγει ένα δεύτερο κλώνο πίσω. Οι αλλαγές σε κάθε κλώνο δεν τροποποιούν το σχήμα προέλευσης.

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

Η κλωνοποίηση αντιγράφει το περιεχόμενο και τη μορφοποίηση του σχήματος, συμπεριλαμβανομένων του ονόματος και του εναλλακτικού κειμένου. Εκχωρήστε νέους λογικούς αναγνωριστικούς στον κλώνο όταν αυτές οι τιμές πρέπει να είναι μοναδικές. Οι πόροι που χρησιμοποιούνται από σύνθετα σχήματα διαχειρίζονται από την παρουσίαση, αλλά ένας κλώνος παραμένει νέο στοιχείο συλλογής με νέα ταυτότητα σχήματος.

### **Αφαίρεση Σχημάτων**

[Remove](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishapecollection/remove/) διαγράφει ένα συγκεκριμένο αντικείμενο σχήματος από τη συλλογή του. Κατά την αφαίρεση πολλαπλών αντιστοιχίσεων κατά τη διάρκεια επαναληπτικής επεξεργασίας με δείκτες, διασχίστε τη συλλογή από το τέλος ώστε κάθε υπόλοιπος δείκτης να παραμείνει έγκυρος.

Αυτό το παράδειγμα αφαιρεί κάθε σχήμα με ορισμένο όνομα. Διαβάζει το τρέχον σχήμα με δείκτη, όχι ένα σταθερό στοιχείο της συλλογής, και δεν κάνει άσκοπες μετατροπές τύπου.

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

Μετά την αφαίρεση, ο αριθμός σχημάτων και οι δείκτες των επόμενων σχημάτων αλλάζουν. Οι αναφορές σε σχήματα που δεν επηρεάστηκαν παραμένουν πιο αξιόπιστες από αποθηκευμένους δείκτες. Λάβετε επίσης υπόψη συνδέσμους, κινούμενα γραφικά και άλλα χαρακτηριστικά παρουσίασης που μπορεί να αναφέρονται στο αφαιρεθέν αντικείμενο· η αφαίρεση ενός ορατού σχήματος μπορεί να αλλάξει περισσότερα από την εμφάνιση της διαφάνειας.

### **Απόκρυψη Σχήματος**

Ο ορισμός του [Hidden](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/set_hidden/) σε `true` διατηρεί το σχήμα στη συλλογή αλλά εμποδίζει την εμφάνισή του στην κανονική προβολή της διαφάνειας. Ο δείκτης, η μορφοποίηση και το περιεχόμενό του παραμένουν διαθέσιμα στον κώδικα, έτσι η απόκρυψη είναι κατάλληλη για προαιρετικά στοιχεία που μπορεί να αποκατασταθούν αργότερα.

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

Η απόκρυψη δεν είναι διαγραφή ή ασφαλισμός. Το αντικείμενο μπορεί ακόμη να εντοπιστεί και να εμφανιστεί ξανά από χρήστη ή κώδικα, και παραμένει μέρος του αρχείου παρουσίασης.

### **Αλλαγή Σειράς Z**

Τα επικάλυπτα σχήματα ζωγραφίζονται με σειρά της συλλογής. [Reorder](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishapecollection/reorder/) μετακινεί ένα υπάρχον σχήμα σε έναν στόχο δείκτη χωρίς κλωνοποίηση. Ο δείκτης `0` είναι το πίσω μέρος· `Count - 1` είναι το μπροστινό.

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

Το ορθογώνιο δημιουργείται πρώτα και αρχικά βρίσκεται πίσω από την έλλειψη. Η μετακίνησή του στο τελικό δείκτη το φέρνει μπροστά. Τελειοποιήστε τη σειρά Z μετά την προσθήκη ή κλωνοποίηση όλων των σχετικών σχημάτων, επειδή αυτές οι λειτουργίες προσθέτουν ή εισάγουν νέα στοιχεία στη συλλογή και μπορούν να αλλάξουν την προγραμματισμένη στοίβα.

## **Έλεγχος Σχημάτων σε Διαφάνειες Διάταξης**

Οι κανονικές διαφάνειες, οι διαφάνειες διάταξης και οι κύριες διαφάνειες έχουν ξεχωριστές συλλογές σχημάτων. Ένα σχήμα σε συλλογή διάταξης δεν είναι το ίδιο αντικείμενο με ένα παρόμοιο σχήμα σε κανονική διαφάνεια. Ελέγξτε τα σχήματα διάταξης όταν χρειάζεται να κατανοήσετε ή να αλλάξετε τη μορφοποίηση που παρέχει μια διάταξη.

Το παρακάτω παράδειγμα διαβάζει το [FillFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/get_fillformat/) και το [LineFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/get_lineformat/) κάθε σχήματος διάταξης χωρίς να υποθέτει ότι κάθε σχήμα είναι `AutoShape`.

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

Η επεξεργασία μιας διάταξης μπορεί να επηρεάσει πολλές διαφάνειες που τη χρησιμοποιούν. Πριν αλλάξετε ένα σχήμα διάταξης, προσδιορίστε εάν μια κανονική διαφάνεια κληρονομεί το αντικείμενο ή περιέχει τοπική παράκαμψη, και δοκιμάστε κάθε διαφάνεια που χρησιμοποιεί αυτή τη διάταξη.

## **Εξαγωγή Σχήματος σε SVG**

[WriteAsSvg](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/writeassvg/) γράφει το περιεχόμενου ενός σχήματος σε ροή. Το αποτέλεσμα περιέχει το σχήμα, όχι το υπόβαθρο ολόκληρης της διαφάνειας ή τα γειτονικά σχήματα.

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

Διατηρήστε την παρουσίαση ανοιχτή κατά τη διαδικασία απόδοσης. Η έξοδος εξαρτάται από τη μορφοποίηση του σχήματος και από πόρους όπως γραμματοσειρές και εικόνες. Αν χρειάζεστε ολόκληρη τη σύνθεση, εξάγετε τη διαφάνεια αντί για ένα μεμονωμένο σχήμα. Ο καλών χρήστης είναι υπεύθυνος για το κλείσιμο ή την απελευθέρωση της ροής.

## **Στοίχιση Σχημάτων**

Οι υπερφορτώσεις του [SlideUtil::AlignShapes](https://reference.aspose.com/slides/el/cpp/aspose.slides.util/slideutil/alignshapes/) στοιχίζουν είτε όλα τα σχήματα είτε επιλεγμένους δείκτες συλλογής. Το [ShapesAlignmentType](https://reference.aspose.com/slides/el/cpp/aspose.slides/shapesalignmenttype/) καθορίζει την άκρη, την κεντρική γραμμή ή τη λειτουργία κατανομής. Ορίστε `alignToSlide` σε `true` για να χρησιμοποιήσετε τις άκρες της διαφάνειας· ορίστε το σε `false` για να στοιχίσετε τα επιλεγμένα σχήματα σχετικά μεταξύ τους.

Αυτό το παράδειγμα στοιχίζει τρία σχήματα στην επάνω άκρη της διαφάνειας. Οι επιστρεφόμενες αναφορές σχήματος μετατρέπονται αμέσως σε τρέχοντες δείκτες τους πριν από τη στοίχιση.

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

Η στοίχιση αλλάζει θέσεις, όχι τη σειρά Z. Η σχετική στοίχιση συνήθως απαιτεί τουλάχιστον δύο σχήματα, ενώ η οριζόντια ή κάθετη κατανομή χρειάζεται αρκετά σχήματα για να ορίσει το διάστημα. Επαναϋπολογίστε τους δείκτες εάν τροποποιήσετε τη συλλογή πριν καλέσετε τη μέθοδο.

## **Αντιστροφή Σχήματος**

Η κλάση [ShapeFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/shapeframe/) αποθηκεύει θέση, μέγεθος, οριζόντιες και κατακόρυφες ρυθμίσεις αντιστροφής και περιστροφή. Οι τιμές `FlipH` και `FlipV` χρησιμοποιούν [NullableBool](https://reference.aspose.com/slides/el/cpp/aspose.slides/nullablebool/): `True` ενεργοποιεί την αντιστροφή, `False` την απενεργοποιεί, και `NotDefined` διατηρεί την ακαθόριστη/προεπιλεγμένη κατάσταση.

Η εισαγώμενη παρουσίαση παρακάτω περιέχει ένα μη αντιστροφή σχήμα.

![The shape before flipping](shape_to_be_flipped.png)

Το παράδειγμα διατηρεί όλες τις άλλες τιμές του πλαισίου και αντικαθιστά μόνο τις δύο ρυθμίσεις αντιστροφής. Αυτό είναι σημαντικό γιατί η ανάθεση ενός νέου [Frame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/set_frame/) αντικαθιστά ολόκληρο το πλαίσιο.

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

Το αποθηκευμένο σχήμα είναι καθρεφτισμένο οριζόντια και κατακόρυφα διατηρώντας τη θέση, το μέγεθος και την περιστροφή του.

![The shape after flipping](flipped_shape.png)

## **Συχνές Ερωτήσεις**

**Πρέπει να χρησιμοποιώ δείκτη συλλογής ως αναγνωριστικό σχήματος;**

Μόνο για βραχυπρόθεσμη επεξεργασία όταν η συλλογή δεν θα αλλάξει πριν χρησιμοποιηθεί ο δείκτης. Προτιμήστε μια επικυρωμένη σύμβαση `Name` ή `AlternativeText` για πρότυπα δημιουργημένα, ή `OfficeInteropShapeId` για εργασίες interop σε επίπεδο διαφάνειας.

**Αφαιρεί η απόκρυψη ενός σχήματος τη θέση του στη σειρά Z;**

Όχι. Ένα κρυφό σχήμα παραμένει στη συλλογή στον ίδιο δείκτη. Μπορεί να βρεθεί, να αναδιαταγεί, να επεξεργαστεί ή να γίνει ξανά ορατό.

**Γιατί ένα κλωνοποιημένο σχήμα εμφανίστηκε μπροστά από άλλο σχήμα;**

Το `AddClone` προσθέτει το κλώνο στο τέλος της συλλογής, που είναι το μπροστινό της σειράς Z. Χρησιμοποιήστε `InsertClone` για να επιλέξετε αρχικό δείκτη ή `Reorder` μετά την προσθήκη όλων των σχημάτων.

**Μπορώ να χρησιμοποιήσω σταθερό δείκτη για την αναγνώριση προεπιλεγμένης προσαρμογής σχήματος;**

Μόνο μετά την επικύρωση του ακριβούς προεπιλεγμένου σχήματος και της διάταξης της συλλογής. Προτιμήστε την επανάληψη μέσω `IGeometryShape::get_Adjustments` και τον έλεγχο του `IAdjustValue::get_Type`; χρησιμοποιήστε το `IAdjustValue::get_Name` ως πρόσθετη πληροφορία όταν ο ίδιος σημασιολογικός τύπος εμφανίζεται περισσότερο από μία φορά.