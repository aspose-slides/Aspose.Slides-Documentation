---
title: Δημιουργία παρουσιάσεων σε C++
linktitle: Δημιουργία Παρουσίασης
type: docs
weight: 10
url: /el/cpp/create-presentation/
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
- C++
- Aspose.Slides
description: "Δημιουργήστε παρουσιάσεις σε C++ με το Aspose.Slides—παράγετε αρχεία PPT, PPTX και ODP, επωφεληθείτε από την υποστήριξη OpenDocument και αποθηκεύστε τα προγραμματιστικά για αξιόπιστα αποτελέσματα."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να δημιουργήσετε μια παρουσίαση στο Aspose.Slides, να προσθέσετε ένα πλαίσιο κειμένου στην πρώτη της διαφάνεια και να αποθηκεύσετε το αποτέλεσμα ως αρχείο. Ένα σύντομο FAQ στο τέλος καλύπτει συχνές ερωτήσεις σχετικά με μορφές, πρότυπα, μέγεθος διαφανειών, μονάδες, χρήση μνήμης, πολυνηματικότητα, αδειοδότηση, ψηφιακές υπογραφές και υποστήριξη VBA.

Πριν ξεκινήσετε, προσθέστε το Aspose.Slides στο έργο σας: από το NuGet σε ένα έργο Visual Studio στα Windows, ή από το πακέτο ZIP με CMake στα Linux. Δείτε την [Εγκατάσταση](/slides/el/cpp/installation/).

## **Δημιουργία Παρουσίασης PowerPoint**

Για να δημιουργήσετε μια παρουσίαση και να τοποθετήσετε ένα πλαίσιο κειμένου στην πρώτη της διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια εμφάνιση της κλάσης [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) . Μια νέα παρουσίαση περιέχει ήδη μία κενή διαφάνεια.
2. Αποκτήστε αυτή τη διαφάνεια με τη μέθοδο [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/) και το ευρετήριο της, 0.
3. Προσθέστε ένα ορθογώνιο σχήμα με τη μέθοδο [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addautoshape/) και ορίστε το κείμενό του με τη μέθοδο [ITextFrame::set_Text](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/set_text/) .
4. Αποθηκεύστε την παρουσίαση ως αρχείο PPTX με τη μέθοδο [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) .

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

int main()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    shape->get_TextFrame()->set_Text(u"Hello, Aspose.Slides!");
    presentation->Save(u"hello.pptx", SaveFormat::Pptx);
    presentation->Dispose();
    return 0;
}
```

Η πάνω αριστερή γωνία του ορθογωνίου είναι 50 σημεία από το αριστερό άκρο και 50 σημεία από το επάνω άκρο της διαφάνειας, και το ορθογώνιο έχει πλάτος 400 σημεία και ύψος 100 σημεία. Το πρόγραμμα αποθηκεύει *hello.pptx* στον τρέχοντα φάκελο εργασίας, με μία διαφάνεια που περιέχει το ορθογώνιο και το κείμενό του. Χωρίς άδεια, το Aspose.Slides προσθέτει επίσης ένα υδατογράφημα αξιολόγησης σε κάθε διαφάνεια που αποθηκεύει· δείτε την [Αδειοδότηση](/slides/el/cpp/licensing/) .

## **FAQ**

### Σε ποιες μορφές μπορώ να αποθηκεύσω μια νέα παρουσίαση;

Μπορείτε να αποθηκεύσετε σε [PPTX, PPT, and ODP](/slides/el/cpp/save-presentation/), και να εξάγετε σε [PDF](/slides/el/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/el/cpp/convert-powerpoint-to-xps/), [HTML](/slides/el/cpp/convert-powerpoint-to-html/), [SVG](/slides/el/cpp/render-a-slide-as-an-svg-image/), και [images](/slides/el/cpp/convert-powerpoint-to-png/), μεταξύ άλλων.

### Μπορώ να ξεκινήσω από ένα πρότυπο (POTX/POTM) και να αποθηκεύσω ως κανονικό PPTX;

Ναι. Φορτώστε το πρότυπο και αποθηκεύστε στο επιθυμητό μορφότυπο· τα φορμά POTX/POTM/PPTM και παρόμοια [υποστηρίζονται](/slides/el/cpp/supported-file-formats/) .

### Πώς ελέγχω το μέγεθος/αναλογία διαφάνειας κατά τη δημιουργία μιας παρουσίασης;

Ορίστε το [μέγεθος διαφάνειας](/slides/el/cpp/slide-size/) (συμπεριλαμβανομένων προρυθμίσεων όπως 4:3 και 16:9 ή προσαρμοσμένων διαστάσεων) και επιλέξτε πώς πρέπει να κλιμακώνεται το περιεχόμενο.

### Σε ποιες μονάδες μετρώνται τα μεγέθη και οι συντεταγμένες;

Σε σημεία: 1 ίντσα ισούται με 72 μονάδες.

### Πώς διαχειρίζομαι πολύ μεγάλες παρουσιάσεις (με πολλά αρχεία πολυμέσων) ώστε να μειώσω τη χρήση μνήμης;

Χρησιμοποιήστε [στρατηγικές διαχείρισης BLOB](/slides/el/cpp/manage-blob/), περιορίστε την αποθήκευση στη μνήμη αξιοποιώντας προσωρινά αρχεία, και προτιμήστε ροές εργασίας βασισμένες σε αρχεία αντί για καθαρά ρεύματα μνήμης.

### Μπορώ να δημιουργήσω/αποθηκεύσω παρουσιάσεις παράλληλα;

Δεν μπορείτε να λειτουργήσετε στην ίδια [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) instance από [πολλαπλά νήματα](/slides/el/cpp/multithreading/). Εκτελέστε ξεχωριστές, απομονωμένες εμφανίσεις ανά νήμα ή διεργασία.

### Πώς αφαιρώ το δοκιμαστικό υδατογράφημα και τους περιορισμούς;

[Εφαρμόστε άδεια](/slides/el/cpp/licensing/) μία φορά ανά διεργασία. Το XML της άδειας πρέπει να παραμείνει αμετάβλητο, και η ρύθμιση της άδειας θα πρέπει να συγχρονίζεται εάν εμπλέκονται πολλαπλά νήματα.

### Μπορώ να υπογράψω ψηφιακά το PPTX που δημιουργώ;

Ναι. Οι [Ψηφιακές υπογραφές](/slides/el/cpp/digital-signature-in-powerpoint/) (προσθήκη και επαλήθευση) υποστηρίζονται για παρουσιάσεις.

### Υποστηρίζονται μακροεντολές (VBA) στις δημιουργημένες παρουσιάσεις;

Ναι. Μπορείτε να [δημιουργία/επεξεργασία έργων VBA](/slides/el/cpp/presentation-via-vba/) και να αποθηκεύσετε αρχεία με ενεργοποιημένα μακροεντολές όπως PPTM/PPSM.