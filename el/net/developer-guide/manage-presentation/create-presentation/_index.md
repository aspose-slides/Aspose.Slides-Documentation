---
title: Δημιουργία παρουσιάσεων σε .NET
linktitle: Δημιουργία παρουσίασης
type: docs
weight: 10
url: /el/net/create-presentation/
keywords:
- δημιουργία παρουσίασης
- νέα παρουσίαση
- δημιουργία PPT
- νέο PPT
- δημιουργία PPTX
- νέο PPTX
- δημιουργία ODP
- νέο ODP
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Δημιουργήστε παρουσιάσεις σε .NET με το Aspose.Slides - παράγετε αρχεία PPT, PPTX και ODP, επωφεληθείτε από την υποστήριξη OpenDocument και αποθηκεύστε τα προγραμματιστικά για αξιόπιστα αποτελέσματα."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να δημιουργήσετε μια παρουσίαση στο Aspose.Slides, να προσθέσετε ένα πλαίσιο κειμένου στην πρώτη διαφάνειά της και να αποθηκεύσετε το αποτέλεσμα ως αρχείο. Επίσης δείχνει πώς να δημιουργήσετε και να αποθηκεύσετε μια κενή παρουσίαση, καθώς και πώς να ανοίξετε μια υπάρχουσα παρουσίαση σε υποστηριζόμενη μορφή και να την αποθηκεύσετε σε άλλη μορφή. Ένα σύντομο FAQ στο τέλος καλύπτει κοινές ερωτήσεις σχετικά με μορφές, πρότυπα, μέγεθος διαφάνειας, μονάδες, χρήση μνήμης, πολυνηματισμό, αδειοδότηση, ψηφιακές υπογραφές και υποστήριξη VBA.

Πριν ξεκινήσετε, προσθέστε το Aspose.Slides στο έργο σας από το NuGet. Δείτε [Εγκατάσταση](/slides/el/net/installation/) για το πακέτο που χρησιμοποιείται σε Windows, Linux και macOS.

## **Δημιουργία παρουσίασης PowerPoint**

Για να δημιουργήσετε μια παρουσίαση και να τοποθετήσετε ένα πλαίσιο κειμένου στην πρώτη διαφάνειά της, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/). Μια νέα παρουσίαση περιέχει ήδη μία κενή διαφάνεια.
2. Αποκτήστε αυτή τη διαφάνεια από τη συλλογή [Slides](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/slides/el/) με το δείκτη 0.
3. Προσθέστε ένα ορθογώνιο σχήμα με τη μέθοδο [AddAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection/addautoshape/) και ορίστε το [text](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/text/).
4. Αποθηκεύστε την παρουσίαση ως αρχείο PPTX χρησιμοποιώντας τη μέθοδο [Save](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/save/).

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

Η γωνία επάνω‑αριστερά του ορθογωνίου βρίσκεται 50 points από την αριστερή άκρη και 50 points από την επάνω άκρη της διαφάνειας, και το ορθογώνιο έχει πλάτος 400 points και ύψος 100 points. Το αποθηκευμένο αρχείο περιλαμβάνει μία διαφάνεια με αυτό το ορθογώνιο και το κείμενό του. Χωρίς άδεια, το Aspose.Slides προσθέτει επίσης ένα υδατογράφημα αξιολόγησης σε κάθε διαφάνεια που αποθηκεύει· δείτε [Αδειοδότηση](/slides/el/net/licensing/).

## **Δημιουργία και αποθήκευση μιας παρουσίασης**

<a name="csharp-create-save-presentation"></a>

Για να δημιουργήσετε μια κενή παρουσίαση και να την αποθηκεύσετε, δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) και αποθηκεύστε την σε οποιαδήποτε μορφή του απαριθμού [SaveFormat](https://reference.aspose.com/slides/el/net/aspose.slides.export/saveformat/). Το αποτέλεσμα είναι μια παρουσίαση με μία κενή διαφάνεια.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
```

## **Άνοιγμα και αποθήκευση παρουσίασης**

<a name="csharp-open-save-presentation"></a>

Για να μετατρέψετε μια παρουσίαση από τη μία μορφή στην άλλη, ανοίξτε την περνώντας τη διαδρομή της στον κατασκευαστή [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/presentation/). Στη συνέχεια αποθηκεύστε την στην επιλεγμένη μορφή. Το Aspose.Slides ανιχνεύει τη μορφή εισόδου, όπως PPT, PPTX ή ODP, από το ίδιο το αρχείο.

Το παρακάτω παράδειγμα αναμένει μια παρουσίαση OpenDocument με όνομα *Sample.odp* στον τρέχοντα φάκελο και την αποθηκεύει ως PPTX.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.odp");
presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
```

## **Συχνές ερωτήσεις**

### Σε ποιες μορφές μπορώ να αποθηκεύσω μια νέα παρουσίαση;

Μπορείτε να αποθηκεύσετε σε [PPTX, PPT, and ODP](/slides/el/net/save-presentation/), και να εξάγετε σε [PDF](/slides/el/net/convert-powerpoint-to-pdf/), [XPS](/slides/el/net/convert-powerpoint-to-xps/), [HTML](/slides/el/net/convert-powerpoint-to-html/), [SVG](/slides/el/net/render-a-slide-as-an-svg-image/) και [images](/slides/el/net/convert-powerpoint-to-png/), μεταξύ άλλων.

### Μπορώ να ξεκινήσω από ένα πρότυπο (POTX/POTM) και να το αποθηκεύσω ως κανονικό PPTX;

Ναι. Φορτώστε το πρότυπο και αποθηκεύστε το στην επιθυμητή μορφή· τα μορφές POTX/POTM/PPTM και παρόμοιες [υποστηρίζονται](/slides/el/net/supported-file-formats/).

### Πώς μπορώ να ελέγξω το μέγεθος/αναλογία διαφάνειας κατά τη δημιουργία μιας παρουσίασης;

Ορίστε το [slide size](/slides/el/net/slide-size/) (συμπεριλαμβανομένων των προεπιλογών όπως 4:3 και 16:9 ή προσαρμοσμένων διαστάσεων) και επιλέξτε πώς θα κλιμακώνονται τα περιεχόμενα.

### Σε ποιες μονάδες μετρώνται τα μεγέθη και οι συντεταγμένες;

Σε points: 1 ίντσα ισούται με 72 μονάδες.

### Πώς μπορώ να διαχειριστώ πολύ μεγάλες παρουσιάσεις (με πολλά αρχεία πολυμέσων) για να μειώσω τη χρήση μνήμης;

Χρησιμοποιήστε τις [BLOB management strategies](/slides/el/net/manage-blob/), περιορίστε την αποθήκευση στη μνήμη αξιοποιώντας προσωρινά αρχεία, και προτιμήστε ροές εργασίας βασισμένες σε αρχεία αντί για καθαρά ρεύματα στη μνήμη.

### Μπορώ να δημιουργώ/αποθηκεύω παρουσιάσεις παράλληλα;

Δεν μπορείτε να λειτουργήσετε στο ίδιο αντικείμενο [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) από [multiple threads](/slides/el/net/multithreading/). Εκτελέστε ξεχωριστές, απομονωμένες εμφανίσεις ανά νήμα ή διαδικασία.

### Πώς μπορώ να αφαιρέσω το υδατογράφημα δοκιμής και τους περιορισμούς;

[Εφαρμογή άδειας](/slides/el/net/licensing/) μία φορά ανά διαδικασία. Το XML της άδειας πρέπει να παραμείνει αμετάβλητο, και η ρύθμιση της άδειας πρέπει να συγχρονίζεται εάν εμπλέκονται πολλαπλά νήματα.

### Μπορώ να υπογράψω ψηφιακά το PPTX που δημιουργώ;

Ναι. Οι [Digital signatures](/slides/el/net/digital-signature-in-powerpoint/) (προσθήκη και επαλήθευση) υποστηρίζονται για παρουσιάσεις.

### Υποστηρίζονται μακροεντολές (VBA) σε δημιουργημένες παρουσιάσεις;

Ναι. Μπορείτε να [create/edit VBA projects](/slides/el/net/presentation-via-vba/) και να αποθηκεύσετε αρχεία με ενεργοποιημένες μακροεντολές όπως PPTM/PPSM.