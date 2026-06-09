---
title: Διαμόρφωση Σχημάτων PowerPoint σε C++
linktitle: Μορφοποίηση Σχημάτων
type: docs
weight: 20
url: /el/cpp/shape-formatting/
keywords:
- μορφοποίηση σχήματος
- μορφοποίηση γραμμής
- μορφοποίηση στυλ συνένωσης
- γέμιση διαβάθμισης
- γέμιση μοτίβου
- γέμιση εικόνας
- γέμιση υφής
- γέμιση συμπαγούς χρώματος
- διαφάνεια σχήματος
- περιστροφή σχήματος
- εφέ 3δ λεπίδας
- εφέ 3δ περιστροφής
- επαναφορά μορφοποίησης
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Μάθετε πώς να μορφοποιείτε σχήματα PowerPoint σε C++ χρησιμοποιώντας το Aspose.Slides—ορίστε γέμισμα, γραμμή και στυλ εφέ για αρχεία PPT, PPTX και ODP με ακρίβεια και πλήρη έλεγχο."
---
## **Εισαγωγή**

Στο PowerPoint, μπορείτε να προσθέσετε σχήματα σε διαφάνειες. Καθώς τα σχήματα αποτελούνται από γραμμές, μπορείτε να τα μορφοποιήσετε τροποποιώντας ή εφαρμόζοντας εφέ στα περίγραμμα τους. Επιπλέον, μπορείτε να μορφοποιήσετε τα σχήματα ορίζοντας ρυθμίσεις που ελέγχουν πώς γεμίζουν τα εσωτερικά τους.

![μορφοποίηση-σχήματος-powerpoint](format-shape-powerpoint.png)

Το Aspose.Slides για C++ παρέχει διεπαφές και μεθόδους που σας επιτρέπουν να μορφοποιείτε σχήματα χρησιμοποιώντας τις ίδιες επιλογές που διατίθενται στο PowerPoint.

## **Μορφοποίηση Γραμμών**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να ορίσετε προσαρμοσμένο στυλ γραμμής για ένα σχήμα. Τα παρακάτω βήματα περιγράφουν τη διαδικασία:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [στυλ γραμμής](https://reference.aspose.com/slides/el/cpp/aspose.slides/linestyle/) του σχήματος.
1. Ορίστε το πάχος της γραμμής.
1. Ορίστε το [στυλ παύλας](https://reference.aspose.com/slides/el/cpp/aspose.slides/linedashstyle/) της γραμμής.
1. Ορίστε το χρώμα γραμμής για το σχήμα.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο κώδικας που ακολουθεί παρουσιάζει πώς να μορφοποιήσετε ένα ορθογώνιο `AutoShape`:

```cpp
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>();

// Αποκτήστε την πρώτη διαφάνεια.
auto slide = presentation->get_Slide(0);

// Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
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

## **Μορφοποίηση Στυλ Συνένωσης**

Αυτές είναι οι τρεις επιλογές τύπου συνένωσης:

* Στρογγυλό
* Μήτερ
* Πλάγιο

Από προεπιλογή, όταν το PowerPoint ενώνει δύο γραμμές υπό γωνία (όπως στη γωνία ενός σχήματος), χρησιμοποιεί τη ρύθμιση **Στρογγυλό**. Ωστόσο, εάν σχεδιάζετε ένα σχήμα με οξότες γωνίες, μπορεί να προτιμάτε την επιλογή **Μήτερ**.

![Το στυλ συνένωσης στην παρουσίαση](join-style-powerpoint.png)

Ο παρακάτω κώδικας C++ δείχνει πώς δημιουργήθηκαν τρία ορθογώνια (όπως φαίνεται στην εικόνα παραπάνω) χρησιμοποιώντας τις ρυθμίσεις τύπου συνένωσης Μήτερ, Πλάγιο και Στρογγυλό:

```cpp
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>();

// Λάβετε την πρώτη διαφάνεια.
auto slide = presentation->get_Slide(0);

// Προσθέστε τρία αυτόματα σχήματα τύπου Rectangle.
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

Στο PowerPoint, η Γέμιση Διαβάθμισης είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εφαρμόσετε ένα συνεχές μείγμα χρωμάτων σε ένα σχήμα. Για παράδειγμα, μπορείτε να εφαρμόσετε δύο ή περισσότερα χρώματα με τρόπο που το ένα λιώνει σταδιακά στο άλλο.

Ακολουθεί η διαδικασία για να εφαρμόσετε γέμιση διαβάθμισης σε σχήμα χρησιμοποιώντας το Aspose.Slides:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε του σχήματος το [FillType](https://reference.aspose.com/slides/el/cpp/aspose.slides/filltype/) σε `Gradient`.
1. Προσθέστε τα δύο επιθυμητά χρώματα με καθορισμένες θέσεις χρησιμοποιώντας τις μεθόδους `Add` της συλλογής σταθμών διαβάθμισης που εκτίθεται από το interface [IGradientFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/igradientformat/).
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο παρακάτω κώδικας C++ δείχνει πώς να εφαρμόσετε εφέ γέμισης διαβάθμισης σε μια έλλειψη:

```cpp
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>();

// Λάβετε την πρώτη διαφάνεια.
auto slide = presentation->get_Slide(0);

// Προσθέστε ένα αυτόματο σχήμα τύπου Ellipse.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// Εφαρμόστε μορφοποίηση διαβάθμισης στην έλλειψη.
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

Το αποτέλεσμα:

![Η έλλειψη με γέμιση διαβάθμισης](gradient-fill.png)

## **Γέμιση Μοτίβου**

Στο PowerPoint, η Γέμιση Μοτίβου είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εφαρμόσετε ένα σχέδιο δύο χρωμάτων—όπως κουκκίδες, ρίγες, χάλκινα ή τετράγωνα—σε ένα σχήμα. Μπορείτε να επιλέξετε προσαρμοσμένα χρώματα για το προσκήνιο και το παρασκήνιο του μοτίβου.

Το Aspose.Slides παρέχει πάνω από 45 προεπιλεγμένα στυλ μοτίβου που μπορείτε να εφαρμόσετε στα σχήματα για να ενισχύσετε την οπτική ελκυστικότητα των παρουσιάσεών σας. Ακόμη και αφού επιλέξετε ένα προεπιλεγμένο μοτίβο, μπορείτε να ορίσετε ακριβώς τα χρώματα που θα χρησιμοποιηθούν.

Ακολουθήστε τα βήματα για να εφαρμόσετε γέμιση μοτίβου σε σχήμα χρησιμοποιώντας το Aspose.Slides:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε του σχήματος το [FillType](https://reference.aspose.com/slides/el/cpp/aspose.slides/filltype/) σε `Pattern`.
1. Επιλέξτε ένα στυλ μοτίβου από τις προεπιλεγμένες επιλογές.
1. Ορίστε το [Background Color](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipatternformat/get_backcolor/) του μοτίβου.
1. Ορίστε το [Foreground Color](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipatternformat/get_forecolor/) του μοτίβου.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο παρακάτω κώδικας C++ δείχνει πώς να εφαρμόσετε γέμιση μοτίβου σε ένα ορθογώνιο:

```cpp
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>();

// Λάβετε την πρώτη διαφάνεια.
auto slide = presentation->get_Slide(0);

// Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
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

Το αποτέλεσμα:

![Το ορθογώνιο με γέμιση μοτίβου](pattern-fill.png)

## **Γέμιση Εικόνας**

Στο PowerPoint, η Γέμιση Εικόνας είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εισάγετε μια εικόνα μέσα σε ένα σχήμα—χρησιμοποιώντας ουσιαστικά την εικόνα ως φόντο του σχήματος.

Ακολουθήστε τα βήματα για να χρησιμοποιήσετε το Aspose.Slides ώστε να εφαρμόσετε γέμιση εικόνας σε σχήμα:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε του σχήματος το [FillType](https://reference.aspose.com/slides/el/cpp/aspose.slides/filltype/) σε `Picture`.
1. Ορίστε τη λειτουργία γέμισης εικόνας σε `Tile` (ή άλλη προτιμώμενη λειτουργία).
1. Δημιουργήστε ένα αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/) από την εικόνα που θέλετε να χρησιμοποιήσετε.
1. Περνάτε την εικόνα στη μέθοδο `ISlidesPicture.set_Image`.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ας υποθέσουμε ότι έχουμε το αρχείο «lotus.png» με την παρακάτω εικόνα:

![Η εικόνα lotus](lotus.png)

Ο παρακάτω κώδικας C++ δείχνει πώς να γεμίσετε ένα σχήμα με την εικόνα:

```cpp
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>();

// Λάβετε την πρώτη διαφάνεια.
auto slide = presentation->get_Slide(0);

// Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// Ορίστε τον τύπο γεμίσματος σε Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Ορίστε τη λειτουργία γέμισης εικόνας.
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

Το αποτέλεσμα:

![Το σχήμα με γέμιση εικόνας](picture-fill.png)

### **Τίτλοι Εικόνας Ως Υφή**

Εάν θέλετε να ορίσετε μια επαναλαμβανόμενη εικόνα ως υφή και να προσαρμόσετε τη συμπεριφορά της επανάληψης, μπορείτε να χρησιμοποιήσετε τις παρακάτω μεθόδους του interface [IPictureFillFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipicturefillformat/) και της κλάσης [PictureFillFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/picturefillformat/):

- [set_PictureFillMode](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): Ορίζει τη λειτουργία γέμισης εικόνας—`Tile` ή `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): Καθορίζει την ευθυγράμμιση των πλακιδίων μέσα στο σχήμα.
- [set_TileFlip](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipicturefillformat/set_tileflip/): Ελέγχει εάν το πλακίδιο γίνεται οριζόντια, κάθετα ή και τα δύο.
- [set_TileOffsetX](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): Ορίζει την οριζόντια μετατόπιση του πλακιδίου (σε points) από το αρχικό σημείο του σχήματος.
- [set_TileOffsetY](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): Ορίζει τη κάθετη μετατόπιση του πλακιδίου (σε points) από το αρχικό σημείο του σχήματος.
- [set_TileScaleX](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): Ορίζει την οριζόντια κλίμακα του πλακιδίου ως ποσοστό.
- [set_TileScaleY](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): Ορίζει την κάθετη κλίμακα του πλακιδίου ως ποσοστό.

Ο παρακάτω κώδικας δείχνει πώς να προσθέσετε ένα ορθογώνιο σχήμα με επαναλαμβανόμενη γέμιση εικόνας και να ρυθμίσετε τις επιλογές πλακιδίου:

```cpp
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>();

// Λάβετε την πρώτη διαφάνεια.
auto firstSlide = presentation->get_Slide(0);

// Προσθέστε ένα αυτόματο σχήμα Rectangle.
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// Ορίστε τον τύπο γεμίσματος του σχήματος σε Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Φορτώστε την εικόνα και προσθέστε την στους πόρους της παρουσίασης.
auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

// Αναθέστε την εικόνα στο σχήμα.
auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);

// Ρυθμίστε τη λειτουργία γέμισης εικόνας και τις ιδιότητες επανάληψης.
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

Το αποτέλεσμα:

![Οι επιλογές πλακιδίου](tile-options.png)

## **Γέμιση Συμπαγούς Χρώματος**

Στο PowerPoint, η Γέμιση Συμπαγούς Χρώματος είναι μια επιλογή μορφοποίησης που γεμίζει ένα σχήμα με ένα ενιαίο, ομοιόμορφο χρώμα. Αυτό το απλό χρώμα φόντου εφαρμόζεται χωρίς διαβαθμίσεις, υφές ή μοτίβα.

Για να εφαρμόσετε γέμιση συμπαγούς χρώματος σε σχήμα χρησιμοποιώντας το Aspose.Slides, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε του σχήματος το [FillType](https://reference.aspose.com/slides/el/cpp/aspose.slides/filltype/) σε `Solid`.
1. Αναθέστε το επιθυμητό χρώμα γέμισμα στο σχήμα.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο παρακάτω κώδικας C++ δείχνει πώς να εφαρμόσετε γέμιση συμπαγούς χρώματος σε ένα ορθογώνιο σε διαφάνεια PowerPoint:

```cpp
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>();

// Λάβετε την πρώτη διαφάνεια.
auto slide = presentation->get_Slide(0);

// Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Ορίστε τον τύπο γεμίσματος σε Solid.
shape->get_FillFormat()->set_FillType(FillType::Solid);

// Ορίστε το χρώμα γεμίσματος.
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// Αποθηκεύστε το αρχείο PPTX στον δίσκο.
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Το σχήμα με γέμιση συμπαγούς χρώματος](solid-color-fill.png)

## **Ορισμός Διαφάνειας**

Στο PowerPoint, όταν εφαρμόζετε γέμιση συμπαγούς χρώματος, διαβάθμισης, εικόνας ή υφής σε σχήματα, μπορείτε επίσης να ορίσετε επίπεδο διαφάνειας για να ελέγξετε την αδιαφάνεια του γεμίσματος. Ένα υψηλότερο επίπεδο διαφάνειας κάνει το σχήμα πιο διαυγές, επιτρέποντας στο φόντο ή στα αντικείμενα που βρίσκονται πίσω του να είναι εν μέρει ορατά.

Το Aspose.Slides σας επιτρέπει να ορίσετε το επίπεδο διαφάνειας ρυθμίζοντας την τιμή alpha στο χρώμα που χρησιμοποιείται για το γέμισμα. Ακολουθήστε τα βήματα:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/cpp/aspose.slides/filltype/) σε `Solid`.
1. Χρησιμοποιήστε την κλάση `Color` για να ορίσετε ένα χρώμα με διαφάνεια (το συστατικό `alpha` ελέγχει τη διαφάνεια).
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας C++ δείχνει πώς να εφαρμόσετε χρώμα γεμίσματος με διαφάνεια σε ένα ορθογώνιο:

```cpp
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>();

// Λάβετε την πρώτη διαφάνεια.
auto slide = presentation->get_Slide(0);

// Προσθέστε ένα συμπαγές αυτόματο σχήμα Rectangle.
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Προσθέστε ένα διαφανές αυτόματο σχήμα Rectangle πάνω από το συμπαγές σχήμα.
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// Αποθηκεύστε το αρχείο PPTX στον δίσκο.
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Το διαφανές σχήμα](shape-transparency.png)

## **Περιστροφή Σχημάτων**

Το Aspose.Slides σάς επιτρέπει να περιστρέφετε σχήματα σε παρουσιάσεις PowerPoint. Αυτό μπορεί να είναι χρήσιμο όταν θέλετε να τοποθετήσετε οπτικά στοιχεία με συγκεκριμένη ευθυγράμμιση ή σχεδιαστικές απαιτήσεις.

Για να περιστρέψετε ένα σχήμα σε μια διαφάνεια, ακολουθήστε τα βήματα:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε την ιδιότητα περιστροφής του σχήματος στην επιθυμητή γωνία.
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας C++ δείχνει πώς να περιστρέψετε ένα σχήμα κατά 5 μοίρες:

```cpp
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>();

// Λάβετε την πρώτη διαφάνεια.
auto slide = presentation->get_Slide(0);

// Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Περιστρέψτε το σχήμα κατά 5 μοίρες.
shape->set_Rotation(5);

// Αποθηκεύστε το αρχείο PPTX στον δίσκο.
presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Η περιστροφή του σχήματος](shape-rotation.png)

## **Προσθήκη Εφέ 3D Λεπίδας**

Το Aspose.Slides σάς επιτρέπει να εφαρμόζετε εφέ 3D λεπίδας σε σχήματα ρυθμίζοντας τις ιδιότητες του [ThreeDFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/threedformat/).

Για να προσθέσετε εφέ 3D λεπίδας σε ένα σχήμα, ακολουθήστε τα βήματα:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/) στη διαφάνεια.
1. Ρυθμίστε το [ThreeDFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/threedformat/) του σχήματος για να ορίσετε τις ρυθμίσεις λεπίδας.
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας C++ δείχνει πώς να εφαρμόσετε εφέ 3D λεπίδας σε ένα σχήμα:

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

Το αποτέλεσμα:

![Το εφέ 3D λεπίδας](3D-bevel-effect.png)

## **Προσθήκη Εφέ 3D Περιστροφής**

Το Aspose.Slides σάς επιτρέπει να εφαρμόζετε εφέ 3D περιστροφής σε σχήματα ρυθμίζοντας τις ιδιότητες του [ThreeDFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/threedformat/).

Για να εφαρμόσετε 3D περιστροφή σε σχήμα:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/) στη διαφάνεια.
1. Χρησιμοποιήστε τις μεθόδους [set_CameraType](https://reference.aspose.com/slides/el/cpp/aspose.slides/icamera/set_cameratype/) και [set_LightType](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilightrig/set_lighttype/) για να ορίσετε την 3D περιστροφή.
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας C++ δείχνει πώς να εφαρμόσετε εφέ 3D περιστροφής σε σχήμα:

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

Το αποτέλεσμα:

![Το εφέ 3D περιστροφής](3D-rotation-effect.png)

## **Επαναφορά Μορφοποίησης**

Ο παρακάτω κώδικας C++ δείχνει πώς να επαναρυθμίσετε τη μορφοποίηση μιας διαφάνειας και να επαναφέρετε τη θέση, το μέγεθος και τη μορφοποίηση όλων των σχημάτων με placeholders στη [LayoutSlide](https://reference.aspose.com/slides/el/cpp/aspose.slides/layoutslide/) στις προεπιλεγμένες ρυθμίσεις τους:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // Επαναφορά κάθε σχήματος στη διαφάνεια που έχει placeholder στη διάταξη.
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Συχνές Ερωτήσεις**

**Επηρεάζει η μορφοποίηση σχήματος το τελικό μέγεθος του αρχείου παρουσίασης;**

Μόνο ελάχιστα. Οι ενσωματωμένες εικόνες και τα μέσα καταλαμβάνουν το μεγαλύτερο μέρος του χώρου του αρχείου, ενώ οι παράμετροι σχήματος όπως χρώματα, εφέ και διαβαθμίσεις αποθηκεύονται ως μεταδεδομένα και δεν προσθέτουν ουσιαστικό μέγεθος.

**Πώς μπορώ να εντοπίσω σχήματα σε μια διαφάνεια που έχουν ταυτόσημη μορφοποίηση ώστε να τα ομαδοποιήσω;**

Συγκρίνετε τις κύριες ιδιότητες μορφοποίησης κάθε σχήματος—ρυθμίσεις γέμισματος, γραμμής και εφέ. Εάν όλες οι αντίστοιχες τιμές ταιριάζουν, θεωρήστε ότι τα στυλ είναι τα ίδια και ομαδοποιήστε λογικά αυτά τα σχήματα, κάτι που απλουστεύει τη μετέπειτα διαχείριση στυλ.

**Μπορώ να αποθηκεύσω ένα σύνολο προσαρμοσμένων στυλ σχήματος σε ξεχωριστό αρχείο για χρήση σε άλλες παρουσιάσεις;**

Ναι. Αποθηκεύστε τα δείγματα σχημάτων με τα επιθυμητά στυλ σε μια διαφάνεια προτύπου ή σε αρχείο προτύπου .POTX. Όταν δημιουργείτε νέα παρουσίαση, ανοίξτε το πρότυπο, κλωνοποιήστε τα σχήματα που χρειάζεστε και εφαρμόστε ξανά τη μορφοποίησή τους όπου απαιτείται.