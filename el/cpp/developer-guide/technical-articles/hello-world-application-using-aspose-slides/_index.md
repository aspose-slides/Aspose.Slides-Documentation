---
title: Εφαρμογή Hello World χρησιμοποιώντας το Aspose.Slides για C++
type: docs
weight: 80
url: /el/cpp/hello-world-application-using-aspose-slides/
keywords:
- γεια σου κόσμε
- εφαρμογή
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Δημιουργήστε την πρώτη σας εφαρμογή C++ με το Aspose.Slides, ένα απλό παράδειγμα Hello World που σας ετοιμάζει να αυτοματοποιήσετε παρουσιάσεις PPT, PPTX και ODP."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να δημιουργήσετε μια απλή παρουσίαση PowerPoint **Hello World** χρησιμοποιώντας το Aspose.Slides. Το παράδειγμα επιδεικνύει πώς να δημιουργήσετε μια νέα παρουσίαση, να προσπελάσετε τη πρώτη διαφάνεια, να προσθέσετε ένα AutoShape σε σχήμα ορθογωνίου σε καθορισμένη θέση, να εισάγετε ένα πλαίσιο κειμένου που περιέχει το κείμενο **Hello World**, και να προσαρμόσετε τη μορφή του σχήματος και του κειμένου.

Επίσης εξηγεί πώς να κάνετε το κείμενο ορατό αλλάζοντας το χρώμα του σε μαύρο, να κρύψετε το περίγραμμα του σχήματος ορίζοντας το χρώμα της γραμμής σε λευκό, να αφαιρέσετε τη γεμίσματος του σχήματος, και να αποθηκεύσετε την παρουσίαση ως αρχείο PPTX.

## **Βήματα για τη δημιουργία μιας εφαρμογής Hello World**

Ακολουθήστε τα παρακάτω βήματα για να δημιουργήσετε μια εφαρμογή **Hello World** χρησιμοποιώντας το Aspose.Slides για C++ API:

- Δημιουργήστε ένα αντικείμενο της κλάσης Presentation
- Αποκτήστε την αναφορά της πρώτης διαφάνειας στην παρουσίαση, η οποία δημιουργείται κατά την δημιουργία του αντικειμένου Presentation.
- Προσθέστε ένα AutoShape με ShapeType ως Rectangle στη καθορισμένη θέση της διαφάνειας.
- Προσθέστε ένα TextFrame στο AutoShape που περιέχει το κείμενο Hello World ως προεπιλεγμένο
- Αλλάξτε το χρώμα του κειμένου σε μαύρο, επειδή είναι λευκό εξ ορισμού και δεν είναι ορατό στη διαφάνεια με λευκό φόντο
- Αλλάξτε το χρώμα της γραμμής του σχήματος σε λευκό για να κρύψετε το περίγραμμα του σχήματος
- Αφαιρέστε τον προεπιλεγμένο τύπο γεμίσματος του σχήματος
- Τέλος, γράψτε την παρουσίαση στο επιθυμητό μορφό αρχείου χρησιμοποιώντας το αντικείμενο Presentation

Η υλοποίηση των παραπάνω βημάτων παρουσιάζεται παρακάτω σε ένα παράδειγμα.

``` cpp
#include <DOM/Presentation.h>
#include <DOM/SlideCollection.h>
#include <DOM/Slide.h>
#include <DOM/ShapeCollection.h>
#include <DOM/AutoShape.h>
#include <DOM/Paragraph.h>
#include <DOM/ParagraphCollection.h>
#include <DOM/TextFrame.h>
#include <DOM/PortionCollection.h>
#include <DOM/Portion.h>
#include <DOM/PortionFormat.h>
#include <DOM/ColorFormat.h>
#include <DOM/FillFormat.h>
#include <DOM/ShapeStyle.h>
#include <DOM/ShapeType.h>
#include <DOM/FillType.h>

#include <Export/SaveFormat.h>

#include <drawing/color.h>

using namespace Aspose;
using namespace Slides;
using namespace Export;

using namespace System;

int main(int argc, const char argv[])
{
    auto pres = System::MakeObject<Presentation>();

    // πάρετε την πρώτη διαφάνεια
    auto slide = pres->get_Slides()->idx_get(0);

    // προσθέστε ένα AutoShape τύπου Rectangle
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

    // προσθέστε TextFrame στο Rectangle
    shape->AddTextFrame(u"Hello World");

    // αλλάξτε το χρώμα του κειμένου σε Μαύρο (που είναι Λευκό εξ ορισμού)
    auto portionFillFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_FillFormat();
    portionFillFormat->set_FillType(FillType::Solid);
    portionFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());

    // αλλάξτε το χρώμα της γραμμής του rectangle σε Λευκό
    shape->get_ShapeStyle()->get_LineColor()->set_Color(System::Drawing::Color::get_White());

    // αφαιρέστε οποιαδήποτε μορφοποίηση γεμίσματος στο shape
    shape->get_FillFormat()->set_FillType(FillType::NoFill);

    // αποθηκεύστε την παρουσίαση στο δίσκο
    pres->Save(u"output.pptx", SaveFormat::Pptx);

    return 0;
}
```