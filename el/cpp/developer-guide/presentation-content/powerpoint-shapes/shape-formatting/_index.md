---
title: Μορφοποίηση Σχημάτων PowerPoint σε C++
linktitle: Μορφοποίηση Σχήματος
type: docs
weight: 20
url: /el/cpp/shape-formatting/
keywords:
- μορφοποίηση σχήματος
- μορφοποίηση γραμμής
- εφέ σκίτσου
- γραμμή σχήματος σκίτσου
- μορφοποίηση στυλ συνένωσης
- γέμιση διαβάθμισης
- γέμιση μοτίβου
- γέμιση εικόνας
- γέμιση υφής
- γέμιση στερεού χρώματος
- διαφάνεια σχήματος
- περιστροφή σχήματος
- εφέ 3Δ λειάνσης
- εφέ 3Δ περιστροφής
- επαναφορά μορφοποίησης
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Μάθετε πώς να μορφοποιείτε σχήματα PowerPoint σε C++ χρησιμοποιώντας το Aspose.Slides—ορίστε στυλ γεμίσματος, γραμμής και εφέ για αρχεία PPT, PPTX και ODP με ακρίβεια και πλήρη έλεγχο."
---
## **Εισαγωγή**

Στο PowerPoint, μπορείτε να προσθέσετε σχήματα σε διαφάνειες. Επειδή τα σχήματα αποτελούνται από γραμμές, μπορείτε να μορφοποιήσετε τις γραμμές τους τροποποιώντας ή εφαρμόζοντας εφέ στα περιγράμματά τους. Επιπλέον, μπορείτε να μορφοποιήσετε τα σχήματα ορίζοντας ρυθμίσεις που ελέγχουν τον τρόπο γεμίσματος των εσωτερικών τους.

![μορφοποίηση-σχήματος-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for C++ παρέχει διεπαφές και μεθόδους που σας επιτρέπουν να μορφοποιείτε σχήματα χρησιμοποιώντας τις ίδιες επιλογές που διατίθενται στο PowerPoint.

## **Μορφοποίηση Γραμμών**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να καθορίσετε προσαρμοσμένο στυλ γραμμής για ένα σχήμα. Τα παρακάτω βήματα περιγράφουν τη διαδικασία:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε μια [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [line style](https://reference.aspose.com/slides/el/cpp/aspose.slides/linestyle/) του σχήματος.
1. Ορίστε το πλάτος γραμμής.
1. Ορίστε το [dash style](https://reference.aspose.com/slides/el/cpp/aspose.slides/linedashstyle/) της γραμμής.
1. Ορίστε το χρώμα γραμμής για το σχήμα.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο παρακάτω κώδικας δείχνει πώς να μορφοποιήσετε ένα ορθογώνιο `AutoShape`:

```cpp
// Δημιουργήστε μία παρουσίαση της κλάσης Presentation που αντιπροσωπεύει αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>();

// Αποκτήστε την πρώτη διαφάνεια.
auto slide = presentation->get_Slide(0);

// Προσθέστε ένα auto shape τύπου Rectangle.
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

// Αποθηκεύστε το αρχείο PPTX στον δίσκο.
presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Οι μορφοποιημένες γραμμές στην παρουσίαση](formatted-lines.png)

## **Εφαρμογή Σχεδίων Εφέ σε Γραμμές Σχήματος**

Ένα εφέ σκίτσου κάνει μια γραμμή σχήματος να φαίνεται σχεδιασμένη με το χέρι. Χρησιμοποιήστε [IShape::get_LineFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/get_lineformat/) για πρόσβαση στις ρυθμίσεις γραμμής, [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilineformat/get_sketchformat/) για πρόσβαση στις ρυθμίσεις σκίτσου, και [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/el/cpp/aspose.slides/isketchformat/set_sketchtype/) για επιλογή τιμής από την απαρίθμηση [LineSketchType](https://reference.aspose.com/slides/el/cpp/aspose.slides/linesketchtype/).

Ο παρακάτω κώδικας C++ δείχνει πώς να εφαρμόσετε το εφέ [LineSketchType::Curved](https://reference.aspose.com/slides/el/cpp/aspose.slides/linesketchtype/) , να διαβάσετε την ρητά εκχωρημένη τιμή και να αφαιρέσετε το εφέ με το [LineSketchType::None](https://reference.aspose.com/slides/el/cpp/aspose.slides/linesketchtype/):

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

Η τιμή που επιστρέφεται από το [ISketchFormat::get_SketchType](https://reference.aspose.com/slides/el/cpp/aspose.slides/isketchformat/get_sketchtype/) αντιπροσωπεύει τη ρύθμιση που έχει εκχωρηθεί άμεσα στο σχήμα. Εάν η μορφοποίηση της γραμμής μπορεί να κληθεί από ένα θέμα, μια κύρια διαφάνεια ή μια διάταξη, χρησιμοποιήστε το [ILineFormat::GetEffective](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilineformat/geteffective/), αποκτήστε πρόσβαση στο [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/) και διαβάστε το [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/el/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/). Η αποτελεσματική τιμή αντικατοπτρίζει τη μορφοποίηση που εφαρμόζεται πραγματικά μετά την επίλυση της κληρονομιάς:

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

- Στρογγυλό
- Κωνικό
- Λεία

Από προεπιλογή, όταν το PowerPoint ενώνει δύο γραμμές σε γωνία (όπως στη γωνία ενός σχήματος), χρησιμοποιεί τη ρύθμιση **Στρογγυλό**. Ωστόσο, εάν σχεδιάζετε ένα σχήμα με αιχμηρές γωνίες, μπορεί να προτιμάτε την επιλογή **Κωνικό**.

![Το στυλ συνένωσης στην παρουσίαση](join-style-powerpoint.png)

Ο παρακάτω κώδικας C++ δείχνει πώς δημιουργήθηκαν τρία ορθογώνια (όπως φαίνεται στην παραπάνω εικόνα) χρησιμοποιώντας τις ρυθμίσεις τύπου συνένωσης Στρογγυλό, Κωνικό και Λεία:

```cpp
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>();

// Αποκτήστε την πρώτη διαφάνεια.
auto slide = presentation->get_Slide(0);

// Προσθέστε τρία auto shapes τύπου Rectangle.
auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

// Ορίστε το χρώμα γεμίσματος για κάθε σχήμα Rectangle.
shape1->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape2->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape3->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// Ορίστε το πλάτος της γραμμής.
shape1->get_LineFormat()->set_Width(15);
shape2->get_LineFormat()->set_Width(15);
shape3->get_LineFormat()->set_Width(15);

// Ορίστε το χρώμα για τη γραμμή κάθε Rectangle.
shape1->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape3->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Ορίστε το στυλ συνένωσης.
shape1->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
shape2->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
shape3->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

// Προσθέστε κείμενο σε κάθε Rectangle.
shape1->get_TextFrame()->set_Text(u"Miter Join Style");
shape2->get_TextFrame()->set_Text(u"Bevel Join Style");
shape3->get_TextFrame()->set_Text(u"Round Join Style");

// Αποθηκεύστε το αρχείο PPTX στον δίσκο.
presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Γέμιση Διαβάθμισης**

Στο PowerPoint, η Γέμιση Διαβάθμισης είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εφαρμόσετε ένα συνεχές μείγμα χρωμάτων σε ένα σχήμα. Για παράδειγμα, μπορείτε να εφαρμόσετε δύο ή περισσότερα χρώματα με τρόπο που το ένα ξεθωριάζει σταδιακά στο άλλο.

Ακολουθεί πώς να εφαρμόσετε γέμιση διαβάθμισης σε ένα σχήμα χρησιμοποιώντας το Aspose.Slides:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε μια [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType] του σχήματος σε `Gradient`.
1. Προσθέστε τα δύο προτιμώμενα χρώματά σας με καθορισμένες θέσεις χρησιμοποιώντας τις μεθόδους `Add` της συλλογής σταθμών διαβάθμισης που εκτίθενται από τη διεπαφή [IGradientFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/igradientformat/).
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```cpp
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>();

// Αποκτήστε την πρώτη διαφάνεια.
auto slide = presentation->get_Slide(0);

// Προσθέστε ένα auto shape τύπου Ellipse.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// Εφαρμόστε μορφοποίηση διαβάθμισης στην Ellipse.
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// Ορίστε την κατεύθυνση της διαβάθμισης.
shape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// Προσθέστε δύο στάσεις διαβάθμισης.
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// Αποθηκεύστε το αρχείο PPTX στον δίσκο.
presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Η έλλειψη με γέμιση διαβάθμισης](gradient-fill.png)

## **Γέμιση Μοτίβου**

Στο PowerPoint, η Γέμιση Μοτίβου είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εφαρμόσετε ένα δίσκο χρωμάτων—όπως κουκκίδες, γραμμές, σταυροδιαδισίες ή τετράγωνα—σε ένα σχήμα. Μπορείτε να επιλέξετε προσαρμοσμένα χρώματα για το προσκήνιο και το φόντο του μοτίβου.

Το Aspose.Slides παρέχει πάνω από 45 προεπιλεγμένα στυλ μοτίβου που μπορείτε να εφαρμόσετε σε σχήματα για να βελτιώσετε την οπτική ελκυστικότητα των παρουσιάσεών σας. Ακόμη και μετά την επιλογή ενός προεπιλεγμένου μοτίβου, μπορείτε να καθορίσετε τα ακριβή χρώματα που θα χρησιμοποιήσει.

Ακολουθεί πώς να εφαρμόσετε γέμιση μοτίβου σε ένα σχήμα χρησιμοποιώντας το Aspose.Slides:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε μια [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType] του σχήματος σε `Pattern`.
1. Επιλέξτε ένα στυλ μοτίβου από τις προεπιλεγμένες επιλογές.
1. Ορίστε το [Background Color] του μοτίβου.
1. Ορίστε το [Foreground Color] του μοτίβου.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```cpp
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>();

// Αποκτήστε την πρώτη διαφάνεια.
auto slide = presentation->get_Slide(0);

// Προσθέστε ένα auto shape τύπου Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Ορίστε τον τύπο γεμίσματος σε Pattern.
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// Ορίστε το στυλ μοτίβου.
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// Ορίστε τα χρώματα φόντου και προσκηνίου του μοτίβου.
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// Αποθηκεύστε το αρχείο PPTX στον δίσκο.
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Το ορθογώνιο με γέμιση μοτίβου](pattern-fill.png)

## **Γέμιση Εικόνας**

Στο PowerPoint, η Γέμιση Εικόνας είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εισάγετε μια εικόνα μέσα σε ένα σχήμα—χρησιμοποιώντας ουσιαστικά την εικόνα ως φόντο του σχήματος.

Ακολουθεί πώς να χρησιμοποιήσετε το Aspose.Slides για να εφαρμόσετε γέμιση εικόνας σε ένα σχήμα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε μια [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType] του σχήματος σε `Picture`.
1. Ορίστε τη λειτουργία γέμισης εικόνας σε `Tile` (ή άλλη προτιμώμενη λειτουργία).
1. Δημιουργήστε ένα αντικείμενο [IPPImage] από την εικόνα που θέλετε να χρησιμοποιήσετε.
1. Προωθήστε την εικόνα στη μέθοδο `ISlidesPicture.set_Image`.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ας πούμε ότι έχουμε ένα αρχείο "lotus.png" με την παρακάτω εικόνα:

![Η εικόνα lotus](lotus.png)

```cpp
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>();

// Αποκτήστε την πρώτη διαφάνεια.
auto slide = presentation->get_Slide(0);

// Προσθέστε ένα auto shape τύπου Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// Ορίστε τον τύπο γεμίσματος σε Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Ορίστε τη λειτουργία γεμίσματος εικόνας.
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// Φορτώστε μια εικόνα και προσθέστε την στους πόρους της παρουσίασης.
auto image = Images::FromFile(u"lotus.png");
auto picture = presentation->get_Images()->AddImage(image);
image->Dispose();

// Ορίστε την εικόνα.
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(picture);

// Αποθηκεύστε το αρχείο PPTX στον δίσκο.
presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Το σχήμα με γέμιση εικόνας](picture-fill.png)

### **Τίλινγκ Εικόνας Ως Υφή**

Εάν θέλετε να ορίσετε μια εικόνα σε πλακίδια ως υφή και να προσαρμόσετε τη συμπεριφορά του πλακιδίου, μπορείτε να χρησιμοποιήσετε τις ακόλουθες μεθόδους της διεπαφής [IPictureFillFormat] και της κλάσης [PictureFillFormat]:

- Ορίζει τη λειτουργία γέμισης εικόνας—είτε `Tile` είτε `Stretch`.
- Καθορίζει την ευθυγράμμιση των πλακιδίων μέσα στο σχήμα.
- Ελέγχει αν το πλακίδιο είναι αναστραμμένο οριζόντια, κάθετα ή και τα δύο.
- Ορίζει την οριζόντια μετατόπιση του πλακιδίου (σε σημεία) από το αρχικό σημείο του σχήματος.
- Ορίζει την κάθετη μετατόπιση του πλακιδίου (σε σημεία) από το αρχικό σημείο του σχήματος.
- Ορίζει την οριζόντια κλίμακα του πλακιδίου ως ποσοστό.
- Ορίζει την κάθετη κλίμακα του πλακιδίου ως ποσοστό.

Ο παρακάτω κώδικας δείχνει πώς να προσθέσετε ένα ορθογώνιο σχήμα με γέμιση εικόνας σε πλακίδια και να ρυθμίσετε τις επιλογές πλακιδίων:

```cpp
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>();

// Αποκτήστε την πρώτη διαφάνεια.
auto firstSlide = presentation->get_Slide(0);

// Προσθέστε ένα αυτόματο σχήμα Rectangle.
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// Ορίστε τον τύπο γεμίσματος του σχήματος σε Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Φορτώστε την εικόνα και προσθέστε την στους πόρους της παρουσίασης.
auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

// Αντιστοιχίστε την εικόνα στο σχήμα.
auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);

// Ρυθμίστε τη λειτουργία γεμίσματος εικόνας και τις ιδιότητες πλακιδίων.
pictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
pictureFillFormat->set_TileOffsetX(-32);
pictureFillFormat->set_TileOffsetY(-32);
pictureFillFormat->set_TileScaleX(50);
pictureFillFormat->set_TileScaleY(50);
pictureFillFormat->set_TileAlignment(RectangleAlignment::BottomRight);
pictureFillFormat->set_TileFlip(TileFlip::FlipBoth);

// Αποθηκεύστε το αρχείο PPTX στον δίσκο.
presentation->Save(u"tile.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Οι επιλογές πλακιδίου](tile-options.png)

## **Γέμιση Στερεού Χρώματος**

Στο PowerPoint, η Γέμιση Στερεού Χρώματος είναι μια επιλογή μορφοποίησης που γεμίζει ένα σχήμα με ένα ενιαίο, ομοιόμορφο χρώμα. Αυτό το απλό χρώμα φόντου εφαρμόζεται χωρίς διαβαθμίσεις, υφές ή μοτίβα.

Για να εφαρμόσετε γέμιση στερεού χρώματος σε ένα σχήμα χρησιμοποιώντας το Aspose.Slides, ακολουθήστε τα εξής βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε μια [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType] του σχήματος σε `Solid`.
1. Αναθέστε το προτιμώμενο χρώμα γεμίσματος στο σχήμα.
1. Αποθηκεύστε την παρουσίαση.

```cpp
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>();

// Αποκτήστε την πρώτη διαφάνεια.
auto slide = presentation->get_Slide(0);

// Προσθέστε ένα auto shape τύπου Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Ορίστε τον τύπο γεμίσματος σε Solid.
shape->get_FillFormat()->set_FillType(FillType::Solid);

// Ορίστε το χρώμα γεμίσματος.
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// Αποθηκεύστε το αρχείο PPTX στον δίσκο.
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Το σχήμα με γέμιση στερεού χρώματος](solid-color-fill.png)

## **Ορισμός Διαφάνειας**

Στο PowerPoint, όταν εφαρμόζετε γέμιση στερεού χρώματος, διαβάθμισης, εικόνας ή υφής σε σχήματα, μπορείτε επίσης να ορίσετε ένα επίπεδο διαφάνειας για να ελέγξετε την αδιαφάνεια του γεμίσματος. Μια υψηλότερη τιμή διαφάνειας κάνει το σχήμα πιο διαυγές, επιτρέποντας στο φόντο ή στα υποκείμενα αντικείμενα να φαίνονται μερικώς.

Το Aspose.Slides σας επιτρέπει να ορίσετε το επίπεδο διαφάνειας ρυθμίζοντας την τιμή alpha στο χρώμα που χρησιμοποιείται για το γέμισμα. Ακολουθεί πώς να το κάνετε:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε μια [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType] του σχήματος σε `Solid`.
1. Χρησιμοποιήστε το `Color` για να ορίσετε ένα χρώμα με διαφάνεια (το στοιχείο `alpha` ελέγχει τη διαφάνεια).
1. Αποθηκεύστε την παρουσίαση.

```cpp
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>();

// Αποκτήστε την πρώτη διαφάνεια.
auto slide = presentation->get_Slide(0);

// Προσθέστε ένα στερεό αυτόματο σχήμα Rectangle.
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Προσθέστε ένα διαφανές αυτόματο σχήμα Rectangle πάνω από το στερεό σχήμα.
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// Αποθηκεύστε το αρχείο PPTX στον δίσκο.
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Το διαφανές σχήμα](shape-transparency.png)

## **Περιστροφή Σχημάτων**

Το Aspose.Slides σας επιτρέπει να περιστρέφετε σχήματα σε παρουσιάσεις PowerPoint. Αυτό μπορεί να είναι χρήσιμο κατά την τοποθέτηση οπτικών στοιχείων με συγκεκριμένη ευθυγράμμιση ή σχεδιαστικές απαιτήσεις.

Για να περιστρέψετε ένα σχήμα σε μια διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε μια [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε την ιδιότητα περιστροφής του σχήματος στη ζητούμενη γωνία.
1. Αποθηκεύστε την παρουσίαση.

```cpp
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>();

// Αποκτήστε την πρώτη διαφάνεια.
auto slide = presentation->get_Slide(0);

// Προσθέστε ένα auto shape τύπου Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Περιστρέψτε το σχήμα 5 μοίρες.
shape->set_Rotation(5);

// Αποθηκεύστε το αρχείο PPTX στον δίσκο.
presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Η περιστροφή του σχήματος](shape-rotation.png)

## **Προσθήκη 3Δ Εφέ Λείανσης**

Το Aspose.Slides σας επιτρέπει να εφαρμόσετε 3Δ εφέ λειάνσης σε σχήματα διαμορφώνοντας τις ιδιότητες [ThreeDFormat] τους.

Για να προσθέσετε 3Δ εφέ λειάνσης σε ένα σχήμα, ακολουθήστε τα βήματα:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε μια [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/) στη διαφάνεια.
1. Διαμορφώστε το [ThreeDFormat] του σχήματος για να ορίσετε τις ρυθμίσεις λειάνσης.
1. Αποθηκεύστε την παρουσίαση.

```cpp
// Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation.
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

![Το 3Δ εφέ λειάνσης](3D-bevel-effect.png)

## **Προσθήκη 3Δ Εφέ Περιστροφής**

Το Aspose.Slides σας επιτρέπει να εφαρμόσετε 3Δ εφέ περιστροφής σε σχήματα διαμορφώνοντας τις ιδιότητές τους [ThreeDFormat].

Για να εφαρμόσετε 3Δ περιστροφή σε ένα σχήμα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε μια [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/) στη διαφάνεια.
1. Χρησιμοποιήστε τις μεθόδους [set_CameraType](https://reference.aspose.com/slides/el/cpp/aspose.slides/icamera/set_cameratype/) και [set_LightType](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilightrig/set_lighttype/) για να ορίσετε την 3Δ περιστροφή.
1. Αποθηκεύστε την παρουσίαση.

```cpp
// Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_TextFrame()->set_Text(u"Hello, Aspose!");

shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.
presentation->Save(u"3D_rotation_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Το 3Δ εφέ περιστροφής](3D-rotation-effect.png)

## **Επαναφορά Μορφοποίησης**

Ο παρακάτω κώδικας C++ δείχνει πώς να επαναφέρετε τη μορφοποίηση μιας διαφάνειας και να επαναφέρετε τη θέση, το μέγεθος και τη μορφοποίηση όλων των σχημάτων με placeholders στο [LayoutSlide](https://reference.aspose.com/slides/el/cpp/aspose.slides/layoutslide/) στις προεπιλεγμένες ρυθμίσεις τους:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // Επαναφέρετε κάθε σχήμα στη διαφάνεια που έχει θέση κράτησης στη διάταξη.
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Συχνές Ερωτήσεις**

**Επηρεάζει η μορφοποίηση των σχημάτων το τελικό μέγεθος του αρχείου παρουσίασης;**

Μόνο ελάχιστα. Οι ενσωματωμένες εικόνες και τα μέσα καταλαμβάνουν το μεγαλύτερο μέρος του χώρου του αρχείου, ενώ οι παράμετροι των σχημάτων όπως χρώματα, εφέ και διαβαθμίσεις αποθηκεύονται ως μεταδεδομένα και δεν προσθέτουν σχεδόν κανένα επιπλέον μέγεθος.

**Πώς μπορώ να εντοπίσω σχήματα σε μια διαφάνεια που μοιράζονται την ίδια μορφοποίηση ώστε να τα ομαδοποιήσω;**

Συγκρίνετε τις βασικές ιδιότητες μορφοποίησης κάθε σχήματος—ρυθμίσεις γεμίσματος, γραμμής και εφέ. Εάν όλα τα αντίστοιχα τιμές ταιριάζουν, θεωρήστε τα στυλ τους ως πανομοιότυπα και ομαδοποιήστε λογικά αυτά τα σχήματα, κάτι που απλοποιεί τη διαχείριση στυλ αργότερα.

**Μπορώ να αποθηκεύσω ένα σύνολο προσαρμοσμένων στυλ σχημάτων σε ξεχωριστό αρχείο για επαναχρησιμοποίηση σε άλλες παρουσιάσεις;**

Ναι. Αποθηκεύστε δείγματα σχημάτων με τα επιθυμητά στυλ σε μια παρουσίαση‑πρότυπο ή αρχείο προτύπου .POTX. Όταν δημιουργείτε νέα παρουσίαση, ανοίξτε το πρότυπο, κλωνοποιήστε τα σχήματα με το στυλ που χρειάζεστε και επαναεφαρμόστε τη μορφοποίησή τους όπου απαιτείται.