---
title: Μορφοποίηση Σχημάτων PowerPoint σε C++
linktitle: Μορφοποίηση Σχημάτων
type: docs
weight: 20
url: /el/cpp/shape-formatting/
keywords:
- μορφοποίηση σχήματος
- μορφοποίηση γραμμής
- εφέ σκίτσου
- γραμμή σχήματος σκίτσου
- μορφοποίηση στυλ σύνδεσης
- γεμισμα διαβάθμισης
- γεμισμα σχεδίου
- γεμισμα εικόνας
- γεμισμα υφής
- γεμισμα στερεού χρώματος
- διαφάνεια σχήματος
- αποτύπωση σχήματος ασπρόμαυρη
- αποτύπωση σχήματος σε γκρι κλίμακα
- περιστροφή σχήματος
- εφέ λοξότμησης 3Δ
- εφέ περιστροφής 3Δ
- επαναφορά μορφοποίησης
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Μάθετε πώς να μορφοποιείτε σχήματα PowerPoint σε C++ χρησιμοποιώντας το Aspose.Slides—ορίστε στυλ γεμίσματος, γραμμής και εφέ για αρχεία PPT, PPTX και ODP με ακρίβεια και πλήρη έλεγχο."
---
## **Εισαγωγή**

Στο PowerPoint, μπορείτε να προσθέσετε σχήματα στις διαφάνειες. Επειδή τα σχήματα αποτελούνται από γραμμές, μπορείτε να τα μορφοποιήσετε τροποποιώντας ή εφαρμόζοντας εφέ στα περιγράμματά τους. Επιπλέον, μπορείτε να μορφοποιήσετε τα σχήματα καθορίζοντας ρυθμίσεις που ελέγχουν τον τρόπο γεμίσματος του εσωτερικού τους.

![μορφοποίηση-σχήματος-powerpoint](format-shape-powerpoint.png)

Το Aspose.Slides για C++ παρέχει διασυνδέσεις και μεθόδους που σας επιτρέπουν να μορφοποιήσετε σχήματα χρησιμοποιώντας τις ίδιες επιλογές που είναι διαθέσιμες στο PowerPoint.

## **Μορφοποίηση Γραμμών**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να καθορίσετε προσαρμοσμένο στυλ γραμμής για ένα σχήμα. Τα παρακάτω βήματα περιγράφουν τη διαδικασία:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [line style](https://reference.aspose.com/slides/cpp/aspose.slides/linestyle/) του σχήματος.
1. Ορίστε το πάχος γραμμής.
1. Ορίστε το [dash style](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/) της γραμμής.
1. Ορίστε το χρώμα γραμμής για το σχήμα.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο παρακάτω κώδικας δείχνει πώς να μορφοποιήσετε ένα ορθογώνιο `AutoShape`:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/LineDashStyle.h>
#include <DOM/LineStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>();

// Λάβετε την πρώτη διαφάνεια.
auto slide = presentation->get_Slide(0);

// Προσθέστε ένα αυτόματο σχήμα του τύπου Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// Ορίστε το χρώμα γεμίσματος για το σχήμα Rectangle.
shape->get_FillFormat()->set_FillType(FillType::NoFill);

// Εφαρμόστε μορφοποίηση στις γραμμές του Rectangle.
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);

// Ορίστε το χρώμα για τη γραμμή του Rectangle.
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Αποθηκεύστε το αρχείο PPTX στο δίσκο.
presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Οι μορφοποιημένες γραμμές στην παρουσίαση](formatted-lines.png)

## **Εφαρμογή Σχεδίου Εφέ στις Γραμμές Σχήματος**

Ένα εφέ σκίτσου κάνει τη γραμμή ενός σχήματος να φαίνεται σχεδιασμένη με το χέρι. Χρησιμοποιήστε [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) για να έχετε πρόσβαση στις ρυθμίσεις της γραμμής, [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/get_sketchformat/) για να έχετε πρόσβαση στις ρυθμίσεις του σκίτσου και [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/set_sketchtype/) για να επιλέξετε μια τιμή από την απαρίθμηση [LineSketchType](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/).

Ο παρακάτω κώδικας C++ δείχνει πώς να εφαρμόσετε το εφέ [LineSketchType::Curved](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/) , να διαβάσετε την ρητά εκχωρημένη τιμή και να αφαιρέσετε το εφέ με το [LineSketchType::None](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/):

```cpp
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

// Access the shape's line format and its sketch format.
auto sketchFormat = shape->get_LineFormat()->get_SketchFormat();

// Apply a sketch effect.
sketchFormat->set_SketchType(LineSketchType::Curved);

// Read the sketch effect assigned directly to the shape.
auto explicitSketchType = sketchFormat->get_SketchType();
Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);

// Remove the sketch effect.
sketchFormat->set_SketchType(LineSketchType::None);

presentation->Dispose();
```

Η τιμή που επιστρέφει το [ISketchFormat::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/get_sketchtype/) αντιπροσωπεύει τη ρύθμιση που έχει εκχωρηθεί άμεσα στο σχήμα. Εάν η μορφοποίηση της γραμμής μπορεί να κληρονομηθεί από ένα θέμα, τη μητρική διαφάνεια ή τη διαφάνεια διάταξης, χρησιμοποιήστε το [ILineFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/geteffective/), αποκτήστε πρόσβαση στο [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/) και διαβάστε το [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/). Η αποτελεσματική τιμή αντικατοπτρίζει τη μορφοποίηση που εφαρμόζεται πραγματικά μετά την επίλυση της κληρονομιάς:

```cpp
auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto lineFormat = shape->get_LineFormat();

auto explicitSketchType = lineFormat->get_SketchFormat()->get_SketchType();
auto effectiveLineFormat = lineFormat->GetEffective();
auto effectiveSketchType = effectiveLineFormat->get_SketchFormat()->get_SketchType();

Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);
Console::WriteLine(u"Effective sketch type: {0}", effectiveSketchType);

presentation->Dispose();
```

## **Μορφοποίηση Στυλ Συνδέσεων**

Αυτές είναι οι τρεις επιλογές τύπου συνδέσμου:

* Στρογγυλό
* Κόψιμο
* Λοξότμηση

Από προεπιλογή, όταν το PowerPoint συνδέει δύο γραμμές σε γωνία (όπως στη γωνία ενός σχήματος), χρησιμοποιεί τη ρύθμιση **Στρογγυλό**. Ωστόσο, εάν σχεδιάζετε ένα σχήμα με οξύνες γωνίες, μπορεί να προτιμάτε την επιλογή **Κόψιμο**.

![Το στυλ σύνδεσης στην παρουσίαση](join-style-powerpoint.png)

Ο παρακάτω κώδικας C++ δείχνει πώς τρία ορθογώνια (όπως φαίνονται στην εικόνα παραπάνω) δημιουργήθηκαν χρησιμοποιώντας τις ρυθμίσεις τύπου συνδέσμου Μήτρα, Λοξότμηση και Στρογγυλό:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LineJoinStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>();

// Λάβετε την πρώτη διαφάνεια.
auto slide = presentation->get_Slide(0);

// Προσθέστε τρία αυτόματα σχήματα του τύπου Rectangle.
auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

// Ορίστε το χρώμα γεμίσματος για κάθε σχήμα rectangle.
shape1->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape2->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape3->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// Ορίστε το πάχος της γραμμής.
shape1->get_LineFormat()->set_Width(15);
shape2->get_LineFormat()->set_Width(15);
shape3->get_LineFormat()->set_Width(15);

// Ορίστε το χρώμα για τη γραμμή κάθε rectangle.
shape1->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape3->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Ορίστε το στυλ σύνδεσης.
shape1->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
shape2->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
shape3->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

// Προσθέστε κείμενο σε κάθε rectangle.
shape1->get_TextFrame()->set_Text(u"Miter Join Style");
shape2->get_TextFrame()->set_Text(u"Bevel Join Style");
shape3->get_TextFrame()->set_Text(u"Round Join Style");

// Αποθηκεύστε το αρχείο PPTX στο δίσκο.
presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Γεμισμα Διαβάθμισης**

Στο PowerPoint, το Γεμισμα Διαβάθμισης είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εφαρμόσετε μια συνεχόμενη μίξη χρωμάτων σε ένα σχήμα. Για παράδειγμα, μπορείτε να εφαρμόσετε δύο ή περισσότερα χρώματα με τρόπο ώστε το ένα να εξασθενεί σταδιακά στο άλλο.

Αυτή είναι η διαδικασία για να εφαρμόσετε ένα γεμισμα διαβάθμισης σε σχήμα χρησιμοποιώντας το Aspose.Slides:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) του σχήματος σε `Gradient`.
1. Προσθέστε τα δύο προτιμώμενα χρώματά σας με καθορισμένες θέσεις χρησιμοποιώντας τις μεθόδους `Add` της συλλογής διαβάθμισης που εκτίθενται από τη διεπαφή [IGradientFormat](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/).
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο παρακάτω κώδικας C++ δείχνει πώς να εφαρμόσετε ένα εφέ γεμίσματος διαβάθμισης σε μια έλλειψη:

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientDirection.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/PresetColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>();

// Λάβετε την πρώτη διαφάνεια.
auto slide = presentation->get_Slide(0);

// Προσθέστε ένα αυτόματο σχήμα του τύπου Ellipse.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// Εφαρμόστε μορφοποίηση διαβάθμισης στην έλλειψη.
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// Ορίστε την κατεύθυνση της διαβάθμισης.
shape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// Προσθέστε δύο στάσεις διαβάθμισης.
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// Αποθηκεύστε το αρχείο PPTX στο δίσκο.
presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Η έλλειψη με γεμισμα διαβάθμισης](gradient-fill.png)

Εάν μια διαβάθμιση φαίνεται διαφορετική σε εξαγόμενο εικόνα από ό,τι στο PowerPoint, δείτε [Επιλογή Στυλ Απόδοσης Διαβάθμισης](/slides/el/cpp/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Μπορείτε να επιλέξετε στυλ απόδοσης χωρίς να αλλάξετε το γεμισμα διαβάθμισης που είναι αποθηκευμένο στην παρουσίαση.

## **Γέμισμα Σχεδίου**

Στο PowerPoint, το Γέμισμα Σχεδίου είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εφαρμόσετε ένα σχέδιο με δύο χρώματα—όπως κουκκίδες, ρίγες, σταυρογραμμώσεις ή σκαλιά—σε ένα σχήμα. Μπορείτε να επιλέξετε προσαρμοσμένα χρώματα για το προσκήνιο και το φόντο του σχεδίου.

Το Aspose.Slides παρέχει πάνω από 45 προ‑ορισμένα στυλ σχεδίου που μπορείτε να εφαρμόσετε στα σχήματα για να ενισχύσετε την οπτική ελκυστικότητα των παρουσιάσεών σας. Ακόμη και αφού επιλέξετε ένα προ‑ορισμένο σχέδιο, μπορείτε να καθορίσετε ακριβώς τα χρώματα που θα χρησιμοποιηθούν.

Αυτή είναι η διαδικασία για να εφαρμόσετε ένα γέμισμα σχεδίου σε σχήμα χρησιμοποιώντας το Aspose.Slides:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) του σχήματος σε `Pattern`.
1. Επιλέξτε ένα στυλ σχεδίου από τις προ‑ορισμένες επιλογές.
1. Ορίστε το [Background Color](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_backcolor/) του σχεδίου.
1. Ορίστε το [Foreground Color](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_forecolor/) του σχεδίου.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο παρακάτω κώδικας C++ δείχνει πώς να εφαρμόσετε ένα γέμισμα σχεδίου σε ένα ορθογώνιο:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPatternFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>();

// Λάβετε την πρώτη διαφάνεια.
auto slide = presentation->get_Slide(0);

// Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Ορίστε τον τύπο γεμίσματος σε Pattern.
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// Ορίστε το στυλ του σχεδίου.
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// Ορίστε τα χρώματα φόντου και πρόσοψης του σχεδίου.
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// Αποθηκεύστε το αρχείο PPTX στο δίσκο.
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Το ορθογώνιο με γέμισμα σχεδίου](pattern-fill.png)

## **Γέμισμα Εικόνας**

Στο PowerPoint, το Γέμισμα Εικόνας είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εισάγετε μια εικόνα μέσα σε ένα σχήμα—χρησιμοποιώντας ουσιαστικά την εικόνα ως φόντο του σχήματος.

Αυτή είναι η διαδικασία για να χρησιμοποιήσετε το Aspose.Slides για να εφαρμόσετε ένα γέμισμα εικόνας σε σχήμα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) του σχήματος σε `Picture`.
1. Ορίστε τη λειτουργία γεμίσματος εικόνας σε `Tile` (ή σε άλλη προτιμώμενη λειτουργία).
1. Δημιουργήστε ένα αντικείμενο [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) από την εικόνα που θέλετε να χρησιμοποιήσετε.
1. Περάστε την εικόνα στη μέθοδο `ISlidesPicture.set_Image`.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ας υποθέσουμε ότι έχουμε το αρχείο «lotus.png» με την ακόλουθη εικόνα:

![Η εικόνα λωτού](lotus.png)

Ο παρακάτω κώδικας C++ δείχνει πώς να γεμίσετε ένα σχήμα με την εικόνα:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>();

// Λάβετε την πρώτη διαφάνεια.
auto slide = presentation->get_Slide(0);

// Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// Ορίστε τον τύπο γεμίσματος σε Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Ορίστε τη λειτουργία γεμίσματος εικόνας.
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// Φορτώστε μια εικόνα και προσθέστε τη στους πόρους της παρουσίασης.
auto image = Images::FromFile(u"lotus.png");
auto picture = presentation->get_Images()->AddImage(image);
image->Dispose();

// Ορίστε την εικόνα.
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(picture);

// Αποθηκεύστε το αρχείο PPTX στο δίσκο.
presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Το σχήμα με γέμισμα εικόνας](picture-fill.png)

### **Τοποθέτηση Εικόνας σε Υφή Πλακίδωσης**

Εάν θέλετε να ορίσετε μια εικόνα σε μορφή πλακιδίου ως υφή και να προσαρμόσετε τη συμπεριφορά του πλακιδίου, μπορείτε να χρησιμοποιήσετε τις παρακάτω μεθόδους της διεπαφής [IPictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/) και της κλάσης [PictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/):

- [set_PictureFillMode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): Ορίζει τη λειτουργία γεμίσματος εικόνας—είτε `Tile` είτε `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): Καθορίζει την ευθυγράμμιση των πλακιδίων εντός του σχήματος.
- [set_TileFlip](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileflip/): Ελέγχει αν το πλακίδιο θα αναστραφεί οριζόντια, κάθετα ή και τα δύο.
- [set_TileOffsetX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): Ορίζει την οριζόντια απόσταση του πλακιδίου (σε points) από την αρχή του σχήματος.
- [set_TileOffsetY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): Ορίζει την κάθετη απόσταση του πλακιδίου (σε points) από την αρχή του σχήματος.
- [set_TileScaleX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): Ορίζει την οριζόντια κλίμακα του πλακιδίου ως ποσοστό.
- [set_TileScaleY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): Ορίζει την κάθετη κλίμακα του πλακιδίου ως ποσοστό.

Ο παρακάτω κώδικας δείχνει πώς να προσθέσετε ένα ορθογώνιο σχήμα με γεμισμα εικόνας σε μορφή πλακιδίου και να ρυθμίσετε τις επιλογές του πλακιδίου:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>();

// Λάβετε την πρώτη διαφάνεια.
auto firstSlide = presentation->get_Slide(0);

// Προσθέστε ένα αυτόματο σχήμα ορθογωνίου.
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// Ορίστε τον τύπο γεμίσματος του σχήματος σε Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Φορτώστε την εικόνα και προσθέστε τη στους πόρους της παρουσίασης.
auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

// Αναθέστε την εικόνα στο σχήμα.
auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);

// Διμορφώστε τη λειτουργία γεμίσματος εικόνας και τις ιδιότητες πλακιδίων.
pictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
pictureFillFormat->set_TileOffsetX(-32);
pictureFillFormat->set_TileOffsetY(-32);
pictureFillFormat->set_TileScaleX(50);
pictureFillFormat->set_TileScaleY(50);
pictureFillFormat->set_TileAlignment(RectangleAlignment::BottomRight);
pictureFillFormat->set_TileFlip(TileFlip::FlipBoth);

// Αποθηκεύστε το αρχείο PPTX στο δίσκο.
presentation->Save(u"tile.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Οι επιλογές πλακιδίων](tile-options.png)

## **Γεμισμα Στερεού Χρώματος**

Στο PowerPoint, το Γεμισμα Στερεού Χρώματος είναι μια επιλογή μορφοποίησης που γεμίζει ένα σχήμα με ένα ενιαίο, ομοιόμορφο χρώμα. Αυτό το απλό χρώμα φόντου εφαρμόζεται χωρίς κανένα διαβάθμιση, υφή ή σχέδιο.

Για να εφαρμόσετε ένα γεμισμα στερεού χρώματος σε σχήμα χρησιμοποιώντας το Aspose.Slides, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) του σχήματος σε `Solid`.
1. Αναθέστε το προτιμώμενο χρώμα γεμίσματος στο σχήμα.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο παρακάτω κώδικας C++ δείχνει πώς να εφαρμόσετε ένα γεμισμα στερεού χρώματος σε ένα ορθογώνιο σε διαφάνεια PowerPoint:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>();

// Λάβετε την πρώτη διαφάνεια.
auto slide = presentation->get_Slide(0);

// Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Ορίστε τον τύπο γεμίσματος σε Solid.
shape->get_FillFormat()->set_FillType(FillType::Solid);

// Ορίστε το χρώμα γεμίσματος.
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// Αποθηκεύστε το αρχείο PPTX στο δίσκο.
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Το σχήμα με στερεό χρώμα γεμισμού](solid-color-fill.png)

## **Ορισμός Διαφάνειας**

Στο PowerPoint, όταν εφαρμόζετε γεμισμα στερεού χρώματος, διαβάθμισης, εικόνας ή υφής στα σχήματα, μπορείτε επίσης να ορίσετε ένα επίπεδο διαφάνειας για να ελέγξετε την αδιαφάνεια του γεμίσματος. Μια υψηλότερη τιμή διαφάνειας κάνει το σχήμα πιο διαυγές, επιτρέποντας στο φόντο ή στα υποκείμενα αντικείμενα να είναι μερικώς ορατά.

Το Aspose.Slides σάς επιτρέπει να ορίσετε το επίπεδο διαφάνειας ρυθμίζοντας την τιμή alpha του χρώματος που χρησιμοποιείται για το γέμισμα. Να πώς γίνεται:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) σε `Solid`.
1. Χρησιμοποιήστε `Color` για να ορίσετε ένα χρώμα με διαφάνεια (το συστατικό `alpha` ελέγχει τη διαφάνεια).
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας C++ δείχνει πώς να εφαρμόσετε ένα διαφανές χρώμα γεμίσματος σε ένα ορθογώνιο:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>();

// Λάβετε την πρώτη διαφάνεια.
auto slide = presentation->get_Slide(0);

// Προσθέστε ένα αυτόματο σχήμα στερεού ορθογωνίου.
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Προσθέστε ένα αυτόματο σχήμα διαφανούς ορθογωνίου πάνω από το στερεό σχήμα.
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// Αποθηκεύστε το αρχείο PPTX στο δίσκο.
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Το διαφανές σχήμα](shape-transparency.png)

## **Περιστροφή Σχημάτων**

Το Aspose.Slides σάς επιτρέπει να περιστρέψετε σχήματα σε παρουσιάσεις PowerPoint. Αυτό μπορεί να είναι χρήσιμο όταν θέλετε να τοποθετήσετε οπτικά στοιχεία με συγκεκριμένη στοίχιση ή σχεδιαστικές απαιτήσεις.

Για να περιστρέψετε ένα σχήμα σε μια διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε την ιδιότητα περιστροφής του σχήματος στη ζητούμενη γωνία.
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας C++ δείχνει πώς να περιστρέψετε ένα σχήμα κατά 5 μοίρες:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>();

// Λάβετε την πρώτη διαφάνεια.
auto slide = presentation->get_Slide(0);

// Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Περιστρέψτε το σχήμα κατά 5 μοίρες.
shape->set_Rotation(5);

// Αποθηκεύστε το αρχείο PPTX στο δίσκο.
presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Η περιστροφή του σχήματος](shape-rotation.png)

## **Προσθήκη 3Δ Εφέ Λοξότμησης**

Το Aspose.Slides σάς επιτρέπει να εφαρμόσετε 3Δ εφέ λοξότμησης σε σχήματα διαμορφώνοντας τις ιδιότητες του [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/).

Για να προσθέσετε 3Δ εφέ λοξότμησης σε ένα σχήμα, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) στη διαφάνεια.
1. Διαμορφώστε τις ιδιότητες του [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/) του σχήματος για να ορίσετε τις ρυθμίσεις λοξότμησης.
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας C++ δείχνει πώς να εφαρμόσετε 3Δ εφέ λοξότμησης σε ένα σχήμα:

```cpp
#include <DOM/BevelPresetType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeBevel.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Προσθέστε ένα σχήμα στη διαφάνεια.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);

// Ορίστε τις ιδιότητες ThreeDFormat του σχήματος.
shape->get_ThreeDFormat()->set_Depth(4.0);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

// Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.
presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Το 3Δ εφέ λοξότμησης](3D-bevel-effect.png)

## **Προσθήκη 3Δ Εφέ Περιστροφής**

Το Aspose.Slides σάς επιτρέπει να εφαρμόσετε 3Δ εφέ περιστροφής σε σχήματα διαμορφώνοντας τις ιδιότητες του [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/).

Για να εφαρμόσετε 3Δ περιστροφή σε ένα σχήμα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) στη διαφάνεια.
1. Χρησιμοποιήστε τις μεθόδους [set_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/set_cameratype/) και [set_LightType](https://reference.aspose.com/slides/cpp/aspose.slides/ilightrig/set_lighttype/) για να ορίσετε την 3Δ περιστροφή.
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας C++ δείχνει πώς να εφαρμόσετε 3Δ εφέ περιστροφής σε ένα σχήμα:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/ILightRig.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_TextFrame()->set_Text(u"Hello, Aspose!");

shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// Save the presentation as a PPTX file.
presentation->Save(u"3D_rotation_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Το 3Δ εφέ περιστροφής](3D-rotation-effect.png)

## **Έλεγχος Ασπρόμαυρης Απόδοσης για Σχήματα**

Η μέθοδος [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_blackwhitemode/) καθορίζει πώς θα αποδίδεται ένα μεμονωμένο σχήμα όταν η παρουσίαση προβάλλεται ή επεξεργάζεται σε ασπρόμαυρη λειτουργία. Δεν ενεργοποιεί την ασπρόμαυρη προβολή από μόνη της και δεν αλλάζει το γέμισμα, τη γραμμή ή άλλες μορφοποιήσεις σε κανονική χρωματική λειτουργία.

Χρησιμοποιήστε μια τιμή από την απαρίθμηση [BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/blackwhitemode/) για να επιλέξετε τη ζητούμενη συμπεριφορά. Για παράδειγμα, `Automatic` αφήνει την εφαρμογή απόδοσης να επιλέξει τη μετατροπή, `Gray` και `LightGray` χρησιμοποιούν γκρι χρώματα, `BlackWhite` χρησιμοποιεί μόνο μαύρο και λευκό, `Black` και `White` επιβάλλουν ένα ενιαίο χρώμα, `Color` διατηρεί το κανονικό χρώμα, και `Hidden` αποκρύπτει το σχήμα σε ασπρόμαυρη λειτουργία. `NotDefined` σημαίνει ότι δεν έχει οριστεί λειτουργία σε επίπεδο σχήματος.

Ο παρακάτω κώδικας C++ δημιουργεί ένα χρωματιστό σχήμα και το εμφανίζει γκρι σε ασπρόμαυρη λειτουργία:

```cpp
#include <DOM/BlackWhiteMode.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());

// Keep the orange fill in color mode, but render the shape with gray coloring in black-and-white mode.
shape->set_BlackWhiteMode(BlackWhiteMode::Gray);

presentation->Save(u"shape_black_white_mode.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Σε κανονική χρωματική λειτουργία, το ορθογώνιο διατηρεί το πορτοκαλί γέμισμά του. Σε ροή εργασίας ασπρόμαυρης προβολής, χρησιμοποιεί γκρι χρώμα επειδή η λειτουργία του έχει οριστεί σε `Gray`. Αυτό σάς επιτρέπει να διατηρήσετε μια πλήρως έγχρωμη διαφάνεια ενώ ορίζετε ξεχωριστή εμφάνιση για εκτύπωση, προεπισκόπηση ή άλλες ροές εργασίας που σέβονται τις ρυθμίσεις ασπρόμαυρης προβολής της παρουσίασης.

## **Επαναφορά Μορφοποίησης**

Ο παρακάτω κώδικας C++ δείχνει πώς να επαναφέρετε τη μορφοποίηση μιας διαφάνειας και να επαναφέρετε τη θέση, το μέγεθος και τη μορφοποίηση όλων των σχημάτων με placeholders στη [LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/layoutslide/) στις προεπιλεγμένες ρυθμίσεις τους:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    // Επαναφορά κάθε σχήματος στη διαφάνεια που έχει placeholder στη διάταξη.
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Συχνές Ερωτήσεις**

**Επηρεάζει η μορφοποίηση του σχήματος το τελικό μέγεθος του αρχείου παρουσίασης;**

Μόνο ελάχιστα. Οι ενσωματωμένες εικόνες και τα μέσα καταλαμβάνουν το μεγαλύτερο μέρος του χώρου του αρχείου, ενώ οι παράμετροι σχήματος όπως χρώματα, εφέ και διαβαθμίσεις αποθηκεύονται ως μεταδεδομένα και δεν προσθέτουν ουσιαστικά επιπλέον μέγεθος.

**Πώς μπορώ να εντοπίσω σχήματα σε μια διαφάνεια που μοιράζονται την ίδια μορφοποίηση ώστε να τα ομαδοποιήσω;**

Συγκρίνετε τις κύριες ιδιότητες μορφοποίησης κάθε σχήματος—γέμισμα, γραμμή και ρυθμίσεις εφέ. Εάν όλες οι αντίστοιχες τιμές ταιριάζουν, θεωρήστε τα στυλ ως ταυτόσημα και λογικά ομαδοποιήστε αυτά τα σχήματα, πράγμα που απλοποιεί τη διαχείριση στυλ αργότερα.

**Μπορώ να αποθηκεύσω ένα σύνολο προσαρμοσμένων στυλ σχήματος σε ξεχωριστό αρχείο για επαναχρησιμοποίηση σε άλλες παρουσιάσεις;**

Ναι. Αποθηκεύστε δείγματα σχημάτων με τα επιθυμητά στυλ σε ένα πρότυπο σετ διαφανειών ή σε αρχείο προτύπου .POTX. Όταν δημιουργείτε μια νέα παρουσίαση, ανοίξτε το πρότυπο, κλωνοποιήστε τα στυλ που χρειάζεστε και επαναεφαρμόστε τη μορφοποίησή τους όπου απαιτείται.