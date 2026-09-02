---
title: "Μορφοποίηση Σχημάτων PowerPoint σε C++"
linktitle: "Μορφοποίηση Σχημάτων"
type: docs
weight: 20
url: /el/cpp/shape-formatting/
keywords:
- μορφοποίηση σχήματος
- μορφοποίηση γραμμής
- εφέ σχεδίασης
- γραμμή σχήματος σχεδίασης
- μορφοποίηση στυλ συνένωσης
- γέμισμα διαβάθμισης
- γέμισμα μοτίβου
- γέμισμα εικόνας
- γέμισμα υφής
- γέμισμα συμπαγούς χρώματος
- διαφάνεια σχήματος
- απεικόνιση σχήματος σε ασπρόμαυρο
- απεικόνιση σχήματος σε γκρι κλίμακα
- περιστροφή σχήματος
- εφέ 3Δ λεπίδας
- εφέ 3Δ περιστροφής
- επαναφορά μορφοποίησης
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Μάθετε πώς να μορφοποιείτε σχήματα PowerPoint σε C++ χρησιμοποιώντας το Aspose.Slides—ορίστε στυλ γεμίσματος, γραμμής και εφέ για αρχεία PPT, PPTX και ODP με ακρίβεια και πλήρη έλεγχο."
---
## **Εισαγωγή**

Στο PowerPoint, μπορείτε να προσθέσετε σχήματα στις διαφάνειες. Καθώς τα σχήματα αποτελούνται από γραμμές, μπορείτε να τα μορφοποιήσετε τροποποιώντας ή εφαρμόζοντας εφέ στις περιγραμμίσεις τους. Επιπλέον, μπορείτε να μορφοποιήσετε τα σχήματα καθορίζοντας ρυθμίσεις που ελέγχουν πώς γεμίζουν τα εσωτερικά τους.

![μορφοποίηση-σχήματος-powerpoint](format-shape-powerpoint.png)

Η Aspose.Slides for C++ παρέχει διεπαφές και μεθόδους που σας επιτρέπουν να μορφοποιείτε σχήματα χρησιμοποιώντας τις ίδιες επιλογές που είναι διαθέσιμες στο PowerPoint.

## **Μορφοποίηση Γραμμών**

Χρησιμοποιώντας την Aspose.Slides, μπορείτε να ορίσετε ένα προσαρμοσμένο στυλ γραμμής για ένα σχήμα. Τα παρακάτω βήματα περιγράφουν τη διαδικασία:

1. Δημιουργήστε μια παρουσία της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση τον αριθμό της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [στυλ γραμμής](https://reference.aspose.com/slides/el/cpp/aspose.slides/linestyle/) του σχήματος.
1. Ορίστε το πλάτος της γραμμής.
1. Ορίστε το [στυλ παύλας](https://reference.aspose.com/slides/el/cpp/aspose.slides/linedashstyle/) της γραμμής.
1. Ορίστε το χρώμα γραμμής για το σχήμα.
1. Αποθηκεύστε την τροποποιημένη παρουσία ως αρχείο PPTX.

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

// Δημιουργεί την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>();

// Αποκτά την πρώτη διαφάνεια.
auto slide = presentation->get_Slide(0);

// Προσθέτει ένα auto shape τύπου Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// Ορίζει το χρώμα γεμίσματος για το σχήμα rectangle.
shape->get_FillFormat()->set_FillType(FillType::NoFill);

// Εφαρμόζει μορφοποίηση στις γραμμές του rectangle.
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);

// Ορίζει το χρώμα για τη γραμμή του rectangle.
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Αποθηκεύει το αρχείο PPTX στο δίσκο.
presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Οι μορφοποιημένες γραμμές στην παρουσία](formatted-lines.png)

## **Εφαρμογή Σχεδίου Εφέ στις Γραμμές Σχήματος**

Ένα εφέ σχεδίασης κάνει τη γραμμή ενός σχήματος να φαίνεται χειροποίητη. Χρησιμοποιήστε [IShape::get_LineFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/get_lineformat/) για να προσπελάσετε τις ρυθμίσεις γραμμής, [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilineformat/get_sketchformat/) για να προσπελάσετε τις ρυθμίσεις σχεδίασης και [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/el/cpp/aspose.slides/isketchformat/set_sketchtype/) για να επιλέξετε μια τιμή από την αρίθμηση [LineSketchType](https://reference.aspose.com/slides/el/cpp/aspose.slides/linesketchtype/).

Ο παρακάτω κώδικας C++ δείχνει πώς να εφαρμόσετε το εφέ [LineSketchType::Curved](https://reference.aspose.com/slides/el/cpp/aspose.slides/linesketchtype/) , να διαβάσετε την ρητά ορισμένη τιμή και να αφαιρέσετε το εφέ με το [LineSketchType::None](https://reference.aspose.com/slides/el/cpp/aspose.slides/linesketchtype/):

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

Η τιμή που επιστρέφει το [ISketchFormat::get_SketchType](https://reference.aspose.com/slides/el/cpp/aspose.slides/isketchformat/get_sketchtype/) αντιπροσωπεύει τη ρύθμιση που έχει οριστεί άμεσα στο σχήμα. Εάν η μορφοποίηση της γραμμής μπορεί να κληθεί από ένα θέμα, κύρια διαφάνεια ή διάταξη, χρησιμοποιήστε το [ILineFormat::GetEffective](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilineformat/geteffective/), προσπελάστε το [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/) και διαβάστε το [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/el/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/). Η αποτελεσματική τιμή αντανακλά τη μορφοποίηση που εφαρμόζεται μετά την επίλυση της κληρονομικότητας:

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

## **Μορφοποίηση Στυλ Συνένωσης**

Αυτές είναι οι τρεις επιλογές τύπου συνένωσης:

* Στρογγυλό
* Μπλεβέρ
* Κοψί

Από προεπιλογή, όταν το PowerPoint ενώνει δύο γραμμές υπό γωνία (όπως στη γωνία ενός σχήματος), χρησιμοποιεί τη ρύθμιση **Στρογγυλό**. Ωστόσο, αν σχεδιάζετε ένα σχήμα με κοφτερές γωνίες, ίσως προτιμήσετε την επιλογή **Κοψί**.

![Το στυλ συνένωσης στην παρουσία](join-style-powerpoint.png)

Ο παρακάτω κώδικας C++ δείχνει πώς τρία ορθογώνια (όπως φαίνονται στην παραπάνω εικόνα) δημιουργήθηκαν χρησιμοποιώντας τις ρυθμίσεις στυλ συνένωσης Μπλεβέρ, Κοψί και Στρογγυλό:

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

// Δημιουργεί το αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>();

// Αποκτά την πρώτη διαφάνεια.
auto slide = presentation->get_Slide(0);

// Προσθέτει τρία auto shapes τύπου Rectangle.
auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

// Ορίζει το χρώμα γεμίσματος για κάθε σχήμα rectangle.
shape1->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape2->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape3->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// Ορίζει το πλάτος της γραμμής.
shape1->get_LineFormat()->set_Width(15);
shape2->get_LineFormat()->set_Width(15);
shape3->get_LineFormat()->set_Width(15);

// Ορίζει το χρώμα για τη γραμμή κάθε rectangle.
shape1->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape3->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Ορίζει το στυλ συνένωσης.
shape1->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
shape2->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
shape3->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

// Προσθέτει κείμενο σε κάθε rectangle.
shape1->get_TextFrame()->set_Text(u"Miter Join Style");
shape2->get_TextFrame()->set_Text(u"Bevel Join Style");
shape3->get_TextFrame()->set_Text(u"Round Join Style");

// Αποθηκεύει το αρχείο PPTX στο δίσκο.
presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Γέμισμα Διαβάθμισης**

Στο PowerPoint, το Γέμισμα Διαβάθμισης είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εφαρμόσετε ένα συνεχές μίγμα χρωμάτων σε ένα σχήμα. Για παράδειγμα, μπορείτε να εφαρμόσετε δύο ή περισσότερα χρώματα με τρόπο που το ένα σταδιακά να εξασθενεί στο άλλο.

Ακολουθεί πώς να εφαρμόσετε ένα γέμισμα διαβάθμισης σε σχήμα χρησιμοποιώντας την Aspose.Slides:

1. Δημιουργήστε μια παρουσία της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση τον αριθμό της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/cpp/aspose.slides/filltype/) του σχήματος σε `Gradient`.
1. Προσθέστε τα δύο προτιμώμενα χρώματά σας με καθορισμένες θέσεις χρησιμοποιώντας τις μεθόδους `Add` της συλλογής διαβάθμισης που εκτίθεται από τη διεπαφή [IGradientFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/igradientformat/).
1. Αποθηκεύστε την τροποποιημένη παρουσία ως αρχείο PPTX.

Ο παρακάτω κώδικας C++ δείχνει πώς να εφαρμόσετε ένα εφέ γέμισμα διαβάθμισης σε μια έλλειψη:

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

// Δημιουργεί το αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>();

// Αποκτά την πρώτη διαφάνεια.
auto slide = presentation->get_Slide(0);

// Προσθέτει ένα auto shape τύπου Ellipse.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// Εφαρμόζει διαβαθμισμένη μορφοποίηση στην έλλειψη.
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// Ορίζει την κατεύθυνση του gradient.
shape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// Προσθέτει δύο σημεία διαβάθμισης.
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// Αποθηκεύει το αρχείο PPTX στο δίσκο.
presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Η έλλειψη με γέμισμα διαβάθμισης](gradient-fill.png)

## **Γέμισμα Σχεδίου**

Στο PowerPoint, το Γέμισμα Σχεδίου είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εφαρμόσετε ένα σχεδιασμό δύο χρωμάτων — όπως κουκκίδες, γραμμές, διαγώνιες λωρίδες ή σκακιές — σε ένα σχήμα. Μπορείτε να επιλέξετε προσαρμοσμένα χρώματα για το προσκήνιο και το φόντο του σχεδίου.

Η Aspose.Slides παρέχει πάνω από 45 προεπιλεγμένα στυλ σχεδίου που μπορείτε να εφαρμόσετε σε σχήματα για να ενισχύσετε το οπτικό αποτέλεσμα των παρουσιάσεων σας. Ακόμη και αφού επιλέξετε ένα προεπιλεγμένο σχέδιο, μπορείτε να καθορίσετε τα ακριβή χρώματα που θα χρησιμοποιήσει.

Ακολουθεί πώς να εφαρμόσετε ένα γέμισμα σχεδίου σε σχήμα χρησιμοποιώντας την Aspose.Slides:

1. Δημιουργήστε μια παρουσία της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση τον αριθμό της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/cpp/aspose.slides/filltype/) του σχήματος σε `Pattern`.
1. Επιλέξτε ένα στυλ σχεδίου από τις προεπιλεγμένες επιλογές.
1. Ορίστε το [Background Color](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipatternformat/get_backcolor/) του σχεδίου.
1. Ορίστε το [Foreground Color](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipatternformat/get_forecolor/) του σχεδίου.
1. Αποθηκεύστε την τροποποιημένη παρουσία ως αρχείο PPTX.

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

// Δημιουργεί το αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>();

// Αποκτά την πρώτη διαφάνεια.
auto slide = presentation->get_Slide(0);

// Προσθέτει ένα auto shape τύπου Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Ορίζει τον τύπο γεμίσματος σε Pattern.
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// Ορίζει το στυλ του μοτίβου.
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// Ορίζει τα χρώματα φόντου και προσκηνίου του μοτίβου.
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// Αποθηκεύει το αρχείο PPTX στο δίσκο.
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Το ορθογώνιο με γέμισμα σχεδίου](pattern-fill.png)

## **Γέμισμα Εικόνας**

Στο PowerPoint, το Γέμισμα Εικόνας είναι μια επιλογή μορφοποίησης που σας επιτρέπει να ενσωματώσετε μια εικόνα μέσα σε ένα σχήμα — χρησιμοποιώντας ουσιαστικά την εικόνα ως φόντο του σχήματος.

Ακολουθεί πώς να χρησιμοποιήσετε την Aspose.Slides για να εφαρμόσετε ένα γέμισμα εικόνας σε σχήμα:

1. Δημιουργήστε μια παρουσία της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση τον αριθμό της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/cpp/aspose.slides/filltype/) του σχήματος σε `Picture`.
1. Ορίστε τη λειτουργία γεμίσματος εικόνας σε `Tile` (ή άλλη προτιμώμενη λειτουργία).
1. Δημιουργήστε ένα αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/) από την εικόνα που θέλετε να χρησιμοποιήσετε.
1. Περάστε την εικόνα στη μέθοδο `ISlidesPicture.set_Image`.
1. Αποθηκεύστε την τροποποιημένη παρουσία ως αρχείο PPTX.

Ας υποθέσουμε ότι έχουμε ένα αρχείο «lotus.png» με την παρακάτω εικόνα:

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

// Δημιουργεί το αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>();

// Αποκτά την πρώτη διαφάνεια.
auto slide = presentation->get_Slide(0);

// Προσθέτει ένα auto shape τύπου Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// Ορίζει τον τύπο γεμίσματος σε Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Ορίζει τη λειτουργία γεμίσματος εικόνας.
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// Φορτώνει μια εικόνα και την προσθέτει στους πόρους της παρουσίασης.
auto image = Images::FromFile(u"lotus.png");
auto picture = presentation->get_Images()->AddImage(image);
image->Dispose();

// Ορίζει την εικόνα.
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(picture);

// Αποθηκεύει το αρχείο PPTX στο δίσκο.
presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Το σχήμα με γέμισμα εικόνας](picture-fill.png)

### **Ταπετσαρία Εικόνας Ως Υφή**

Εάν θέλετε να ορίσετε μια ταπετσαρία εικόνας ως υφή και να προσαρμόσετε τη συμπεριφορά ταπέτας, μπορείτε να χρησιμοποιήσετε τις παρακάτω μεθόδους της διεπαφής [IPictureFillFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipicturefillformat/) και της κλάσης [PictureFillFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/picturefillformat/):

- [set_PictureFillMode](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): Ορίζει τη λειτουργία γεμίσματος εικόνας — είτε `Tile` είτε `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): Καθορίζει την ευθυγράμμιση των πλακιδίων μέσα στο σχήμα.
- [set_TileFlip](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipicturefillformat/set_tileflip/): Ελέγχει αν το πλακίδιο θα αναστραφεί οριζόντια, κάθετα ή και τα δύο.
- [set_TileOffsetX](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): Ορίζει την οριζόντια απόκλιση του πλακιδίου (σε points) από την αρχή του σχήματος.
- [set_TileOffsetY](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): Ορίζει τη καθέτη απόκλιση του πλακιδίου (σε points) από την αρχή του σχήματος.
- [set_TileScaleX](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): Ορίζει την οριζόντια κλίμακα του πλακιδίου ως ποσοστό.
- [set_TileScaleY](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): Ορίζει τη καθέτη κλίμακα του πλακιδίου ως ποσοστό.

Ο παρακάτω κώδικας δείχνει πώς να προσθέσετε ένα ορθογώνιο σχήμα με ταπετσαρία εικόνας και να ρυθμίσετε τις παραμέτρους πλακιδίων:

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

// Δημιουργεί το αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>();

// Αποκτά την πρώτη διαφάνεια.
auto firstSlide = presentation->get_Slide(0);

// Προσθέτει ένα ορθογώνιο auto shape.
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// Ορίζει τον τύπο γεμίσματος του σχήματος σε Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Φορτώνει την εικόνα και την προσθέτει στους πόρους της παρουσίασης.
auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

// Αναθέτει την εικόνα στο σχήμα.
auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);

// Διαμορφώνει τη λειτουργία γεμίσματος εικόνας και τις ιδιότητες τοποθέτησης πλακιδίων.
pictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
pictureFillFormat->set_TileOffsetX(-32);
pictureFillFormat->set_TileOffsetY(-32);
pictureFillFormat->set_TileScaleX(50);
pictureFillFormat->set_TileScaleY(50);
pictureFillFormat->set_TileAlignment(RectangleAlignment::BottomRight);
pictureFillFormat->set_TileFlip(TileFlip::FlipBoth);

// Αποθηκεύει το αρχείο PPTX στο δίσκο.
presentation->Save(u"tile.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Οι επιλογές πλακιδίων](tile-options.png)

## **Συμπαγές Χρώμα Γέμισμα**

Στο PowerPoint, το Συμπαγές Χρώμα Γέμισμα είναι μια επιλογή μορφοποίησης που γεμίζει ένα σχήμα με ένα ενιαίο, ομοιόμορφο χρώμα. Αυτό το απλό χρώμα φόντου εφαρμόζεται χωρίς διαβαθμίσεις, υφές ή μοτίβα.

Για να εφαρμόσετε ένα συμπαγές χρώμα γέμισμα σε σχήμα χρησιμοποιώντας την Aspose.Slides, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση τον αριθμό της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/cpp/aspose.slides/filltype/) του σχήματος σε `Solid`.
1. Αναθέστε το προτιμώμενο χρώμα γεμίσματος στο σχήμα.
1. Αποθηκεύστε την τροποποιημένη παρουσία ως αρχείο PPTX.

Ο παρακάτω κώδικας C++ δείχνει πώς να εφαρμόσετε ένα συμπαγές χρώμα γέμισμα σε ένα ορθογώνιο σε διαφάνεια PowerPoint:

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

// Δημιουργεί το αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>();

// Αποκτά την πρώτη διαφάνεια.
auto slide = presentation->get_Slide(0);

// Προσθέτει ένα auto shape τύπου Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Ορίζει τον τύπο γεμίσματος σε Solid.
shape->get_FillFormat()->set_FillType(FillType::Solid);

// Ορίζει το χρώμα γεμίσματος.
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// Αποθηκεύει το αρχείο PPTX στο δίσκο.
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Το σχήμα με συμπαγές χρώμα γέμισμα](solid-color-fill.png)

## **Ορισμός Διαφάνειας**

Στο PowerPoint, όταν εφαρμόζετε ένα συμπαγές χρώμα, διαβάθμιση, εικόνα ή υφή σε σχήματα, μπορείτε επίσης να ορίσετε ένα επίπεδο διαφάνειας για να ελέγξετε τη διαφάνεια του γέμισης. Μια υψηλότερη τιμή διαφάνειας κάνει το σχήμα πιο διαφανές, επιτρέποντας στο φόντο ή στα υποκείμενα αντικείμενα να φαίνονται εν μέρει.

Η Aspose.Slides σας επιτρέπει να ορίσετε το επίπεδο διαφάνειας ρυθμίζοντας την τιμή alpha στο χρώμα που χρησιμοποιείται για το γέμισμα. Δείτε πώς:

1. Δημιουργήστε μια παρουσία της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση τον αριθμό της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/cpp/aspose.slides/filltype/) σε `Solid`.
1. Χρησιμοποιήστε το `Color` για να ορίσετε ένα χρώμα με διαφάνεια (το στοιχείο `alpha` ελέγχει τη διαφάνεια).
1. Αποθηκεύστε την παρουσία.

Ο παρακάτω κώδικας C++ δείχνει πώς να εφαρμόσετε ένα διαφανές χρώμα γέμισματος σε ένα ορθογώνιο:

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

// Δημιουργεί το αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>();

// Αποκτά την πρώτη διαφάνεια.
auto slide = presentation->get_Slide(0);

// Προσθέτει ένα συμπαγές ορθογώνιο auto shape.
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Προσθέτει ένα διαφανές ορθογώνιο auto shape πάνω από το συμπαγές σχήμα.
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// Αποθηκεύει το αρχείο PPTX στο δίσκο.
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Το διαφανές σχήμα](shape-transparency.png)

## **Περιστροφή Σχημάτων**

Η Aspose.Slides σας επιτρέπει να περιστρέφετε σχήματα σε παρουσιάσεις PowerPoint. Αυτό μπορεί να είναι χρήσιμο όταν θέλετε να τοποθετήσετε οπτικά στοιχεία με συγκεκριμένη ευθυγράμμιση ή σχεδιαστικές ανάγκες.

Για να περιστρέψετε ένα σχήμα σε μια διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση τον αριθμό της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε την ιδιότητα περιστροφής του σχήματος στη gewünschte γωνία.
1. Αποθηκεύστε την παρουσία.

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

// Δημιουργεί το αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>();

// Αποκτά την πρώτη διαφάνεια.
auto slide = presentation->get_Slide(0);

// Προσθέτει ένα auto shape τύπου Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Περιστρέφει το σχήμα κατά 5 μοίρες.
shape->set_Rotation(5);

// Αποθηκεύει το αρχείο PPTX στο δίσκο.
presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Η περιστροφή του σχήματος](shape-rotation.png)

## **Προσθήκη 3Δ Εφέ Λεπίδας**

Η Aspose.Slides σας επιτρέπει να εφαρμόζετε 3Δ εφέ λεπίδας σε σχήματα διαμορφώνοντας τις ιδιότητες του [ThreeDFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/threedformat/).

Για να προσθέσετε 3Δ εφέ λεπίδας σε ένα σχήμα, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση τον αριθμό της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/) στη διαφάνεια.
1. Διαμορφώστε το [ThreeDFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/threedformat/) του σχήματος για να ορίσετε τις ρυθμίσεις λεπίδας.
1. Αποθηκεύστε την παρουσία.

Ο παρακάτω κώδικας C++ δείχνει πώς να εφαρμόσετε 3Δ εφέ λεπίδας σε ένα σχήμα:

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

// Δημιουργεί ένα αντικείμενο της κλάσης Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Προσθέτει ένα σχήμα στη διαφάνεια.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);

// Ορίζει τις ιδιότητες ThreeDFormat του σχήματος.
shape->get_ThreeDFormat()->set_Depth(4.0);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

// Αποθηκεύει την παρουσίαση ως αρχείο PPTX.
presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Το 3Δ εφέ λεπίδας](3D-bevel-effect.png)

## **Προσθήκη 3Δ Εφέ Περιστροφής**

Η Aspose.Slides σας επιτρέπει να εφαρμόζετε 3Δ εφέ περιστροφής σε σχήματα διαμορφώνοντας τις ιδιότητες του [ThreeDFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/threedformat/).

Για να εφαρμόσετε 3Δ περιστροφή σε ένα σχήμα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση τον αριθμό της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/) στη διαφάνεια.
1. Χρησιμοποιήστε τα [set_CameraType](https://reference.aspose.com/slides/el/cpp/aspose.slides/icamera/set_cameratype/) και [set_LightType](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilightrig/set_lighttype/) για να ορίσετε την 3Δ περιστροφή.
1. Αποθηκεύστε την παρουσία.

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

// Δημιουργεί ένα αντικείμενο της κλάσης Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_TextFrame()->set_Text(u"Hello, Aspose!");

shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// Αποθηκεύει την παρουσίαση ως αρχείο PPTX.
presentation->Save(u"3D_rotation_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Το 3Δ εφέ περιστροφής](3D-rotation-effect.png)

## **Έλεγχος Μονόχρωμης Απόδοσης για Σχήματα**

Η μέθοδος [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/set_blackwhitemode/) καθορίζει πώς θα αποδίδεται ένα μεμονωμένο σχήμα όταν μια παρουσία προβάλλεται ή επεξεργάζεται σε μονόχρωμη λειτουργία. Δεν ενεργοποιεί αυτόματα την εμφάνιση σε μαυρόλευκο χρώμα και δεν αλλάζει το γέμισμα, τη γραμμή ή άλλες μορφοποιήσεις του σχήματος σε κανονική έγχρωμη λειτουργία.

Χρησιμοποιήστε μια τιμή από την αρίθμηση [BlackWhiteMode](https://reference.aspose.com/slides/el/cpp/aspose.slides/blackwhitemode/) για να επιλέξετε τη ζητούμενη συμπεριφορά. Για παράδειγμα, `Automatic` αφήνει την εφαρμογή απόδοσης να επιλέξει τη μετατροπή, `Gray` και `LightGray` χρησιμοποιούν γκρι χρώματα, `BlackWhite` χρησιμοποιεί μόνο μαύρο και λευκό, `Black` και `White` εξαναγκάζουν ένα ενιαίο χρώμα, `Color` διατηρεί το κανονικό χρώμα και `Hidden` παραλείπει το σχήμα στη μονόχρωμη λειτουργία. `NotDefined` σημαίνει ότι δεν έχει οριστεί λειτουργία σε επίπεδο σχήματος.

Ο παρακάτω κώδικας C++ δημιουργεί ένα έγχρωμο σχήμα και το κάνει να φαίνεται γκρι σε μονόχρωμη λειτουργία προβολής:

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

Σε κανονική έγχρωμη λειτουργία, το ορθογώνιο διατηρεί το πορτοκαλί γέμισμά του. Σε μονόχρωμη λειτουργία προβολής, εμφανίζεται γκρι επειδή η λειτουργία του έχει οριστεί σε `Gray`. Έτσι μπορείτε να διατηρήσετε μια πλήρως έγχρωμη διαφάνεια ενώ ορίζετε διαφορετική εμφάνιση για εκτύπωση, προεπισκόπηση ή άλλες ροές εργασίας που σέβονται τις ρυθμίσεις μονόχρωμης εμφάνισης της παρουσίασης.

## **Επαναφορά Μορφοποίησης**

Ο παρακάτω κώδικας C++ δείχνει πώς να επαναφέρετε τη μορφοποίηση μιας διαφάνειας και να επαναφέρετε τη θέση, το μέγεθος και τη μορφοποίηση όλων των σχημάτων με σύμβολα στην [LayoutSlide](https://reference.aspose.com/slides/el/cpp/aspose.slides/layoutslide/) στις προεπιλεγμένες τιμές τους:

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
    // Επαναφέρει κάθε σχήμα στη διαφάνεια που έχει σύμβολο στην διάταξη.
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Συχνές Ερωτήσεις**

**Επηρεάζει η μορφοποίηση σχήματος το τελικό μέγεθος αρχείου της παρουσίασης;**

Μόνο ελαφρώς. Οι ενσωματωμένες εικόνες και τα μέσα καταλαμβάνουν το μεγαλύτερο μέρος του χώρου του αρχείου, ενώ οι παράμετροι σχήματος όπως χρώματα, εφέ και διαβαθμίσεις αποθηκεύονται ως μεταδεδομένα και προσθέτουν πρακτικά κανένα επιπλέον μέγεθος.

**Πώς μπορώ να εντοπίσω σχήματα σε μια διαφάνεια που έχουν ίδια μορφοποίηση ώστε να τα ομαδοποιήσω;**

Συγκρίνετε τις κύριες ιδιότητες μορφοποίησης κάθε σχήματος — γέμισμα, γραμμή και ρυθμίσεις εφέ. Εάν όλες οι αντίστοιχες τιμές ταιριάζουν, θεωρήστε ότι τα στυλ είναι ίδια και ομαδοποιήστε λογικά αυτά τα σχήματα, κάτι που απλοποιεί τη μετέπειτα διαχείριση στυλ.

**Μπορώ να αποθηκεύσω ένα σύνολο προσαρμοσμένων στυλ σχήματος σε ξεχωριστό αρχείο για χρήση σε άλλες παρουσιάσεις;**

Ναι. Αποθηκεύστε δείγματα σχημάτων με τα επιθυμητά στυλ σε ένα πρότυπο σετ διαφανειών ή σε ένα αρχείο πρότυπου .POTX. Κατά τη δημιουργία νέας παρουσίασης, ανοίξτε το πρότυπο, αντιγράψτε τα στυλσχημάτων που χρειάζεστε και εφαρμόστε ξανά τη μορφοποίησή τους όπου απαιτείται.