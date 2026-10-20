---
title: "Αλλαγή Μεγέθους Σχημάτων σε Διαφάνειες Παρουσίασης σε C++"
type: docs
weight: 130
url: /el/cpp/resizing-shapes-on-slide/
aliases:
  - /cpp/re-sizing-shapes-on-slide/
  - /el/cpp/re-sizing-shapes-on-slide/
keywords:
  - "αλλαγή μεγέθους σχήματος"
  - "αλλαγή μεγέθους σχήματος"
  - "PowerPoint"
  - "OpenDocument"
  - "παρουσίαση"
  - "C++"
  - "Aspose.Slides"
description: "Απλά αλλάξτε το μέγεθος των σχημάτων σε διαφάνειες PowerPoint και OpenDocument με το Aspose.Slides για C++—αυτοματοποιήστε τις προσαρμογές διάταξης διαφανειών και ενισχύστε την παραγωγικότητα."
---
## **Επισκόπηση**

Όταν αλλάζετε το μέγεθος διαφάνειας μιας παρουσίασης, μπορεί επίσης να χρειαστεί να αλλάξετε το μέγεθος και τη θέση των σχημάτων της ώστε να ταιριάζουν στις νέες διαστάσεις. Αυτό το άρθρο δείχνει πώς να κλιμακώνετε τα σχήματα χειροκίνητα και πώς να χειρίζεστε πίνακες σε διαφάνειες, master και διατάξεις.

## **Αλλαγή Μεγέθους Σχημάτων**

Για να διατηρήσετε τη σχετική θέση και το μέγεθος κάθε σχήματος, πολλαπλασιάστε τις οριζόντιες συντεταγμένες και το πλάτος του με το λόγο του νέου πλάτους διαφάνειας προς το αρχικό πλάτος. Εφαρμόστε τον αντίστοιχο λόγο ύψους στις κάθετες συντεταγμένες και το ύψος του.

Το πρώτο παράδειγμα φορτώνει μια παρουσίαση της οποίας οι διαφάνειες δεν περιέχουν πίνακες, αλλάζει το μέγεθος διαφάνειας σε A4 και αποθηκεύει το αποτέλεσμα. Χρησιμοποιεί [SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/) με [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/cpp/aspose.slides/slidesizescaletype/) ώστε η επακόλουθη βρόχος να ελέγχει την κλίμακα. Οι λόγοι είναι άσχετοι μονάδων· οι θέσεις και οι διαστάσεις των σχημάτων μετρώνται σε σημεία. Διαφορετικοί λόγοι πλάτους και ύψους μπορούν να παραμορφώσουν τα σχήματα, και η αλλαγή των διαστάσεων ενός σχήματος δεν κλιμακώνει τα μεγέθη γραμματοσειράς.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Calculate independent horizontal and vertical scale factors.
auto originalSize = presentation->get_SlideSize()->get_Size();
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
auto targetSize = presentation->get_SlideSize()->get_Size();
auto widthRatio = targetSize.get_Width() / originalSize.get_Width();
auto heightRatio = targetSize.get_Height() / originalSize.get_Height();

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        shape->set_Width(shape->get_Width() * widthRatio);
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
        shape->set_Y(shape->get_Y() * heightRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Πίνακες απαιτούν ξεχωριστή διαχείριση: κλιμακώστε το πλάτος των στηλών τους και το ύψος των γραμμών αντί να ορίσετε το συνολικό πλάτος και ύψος του πίνακα. Τα ύψη των γραμμών μπορεί να παραμείνουν μεγαλύτερα από το ζητούμενο εάν το περιεχόμενο των κελιών απαιτεί περισσότερο χώρο.
{{% /alert %}}

Το δεύτερο παράδειγμα υποστηρίζει πίνακες και επεξεργάζεται σχήματα σε master και διατάξεις καθώς και σε μεμονωμένες διαφάνειες πριν αποθηκεύσει την αλλαγμένη παρουσίαση. Η βοηθητική του λειτουργία διαχειρίζεται κάθε [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) κλιμακώντας το [IColumn::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/icolumn/set_width/) και το [IRow::set_MinimalHeight](https://reference.aspose.com/slides/cpp/aspose.slides/irow/set_minimalheight/). Στη συνέχεια κλιμακώνει τη θέση του πίνακα χωρίς να κλιμακώσει ξεχωριστά τις συνολικές διαστάσεις του.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ILayoutSlideCollection.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <DOM/Table/IColumn.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/Table/IRRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Υπολογίστε ανεξάρτητους οριζόντιους και κάθετους συντελεστές κλίμακας.
auto originalSize = presentation->get_SlideSize()->get_Size();
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
auto targetSize = presentation->get_SlideSize()->get_Size();
auto widthRatio = targetSize.get_Width() / originalSize.get_Width();
auto heightRatio = targetSize.get_Height() / originalSize.get_Height();

auto resizeShapes = [](SharedPtr<IShapeCollection> shapes, float widthRatio, float heightRatio)
{
    for (auto&& shape : shapes)
    {
        if (ObjectExt::Is<ITable>(shape))
        {
            auto table = ExplicitCast<ITable>(shape);
            // Οι διαστάσεις του πίνακα ελέγχονται από τα πλάτη των στηλών και τα ύψη των γραμμών.
            for (auto&& column : table->get_Columns())
            {
                column->set_Width(column->get_Width() * widthRatio);
            }

            for (auto&& row : table->get_Rows())
            {
                row->set_MinimalHeight(row->get_MinimalHeight() * heightRatio);
            }
        }
        else
        {
            shape->set_Width(shape->get_Width() * widthRatio);
            shape->set_Height(shape->get_Height() * heightRatio);
        }

        shape->set_X(shape->get_X() * widthRatio);
        shape->set_Y(shape->get_Y() * heightRatio);
    }
};

// Αλλάξτε το μέγεθος των σχημάτων που ορίζονται σε master και διατάξεις, καθώς και σε μεμονωμένες διαφάνειες.
for (auto&& master : presentation->get_Masters())
{
    resizeShapes(master->get_Shapes(), widthRatio, heightRatio);

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        resizeShapes(layoutSlide->get_Shapes(), widthRatio, heightRatio);
    }
}

for (auto&& slide : presentation->get_Slides())
{
    resizeShapes(slide->get_Shapes(), widthRatio, heightRatio);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ΣΥΧΝΑ ΕΡΩΤΗΜΑΤΑ**

**Γιατί τα σχήματα παραμορφώνονται ή κόβονται μετά την αλλαγή μεγέθους μιας διαφάνειας;**

Εάν αλλάξετε το μέγεθος της διαφάνειας χωρίς να κλιμακώσετε τα σχήματα, διατηρούν τις αρχικές τους θέσεις και διαστάσεις και μπορεί να εκταθούν εκτός της διαφάνειας. Η κλίμακα του πλάτους και του ύψους με διαφορετικούς λόγους μπορεί επίσης να παραμορφώσει τα σχήματα.

**Λειτουργεί ο παρεχόμενος κώδικας για όλους τους τύπους σχημάτων;**

Το πρώτο παράδειγμα αλλάζει τα όρια των σχημάτων άμεσα και προορίζεται για διαφάνειες χωρίς πίνακες. Το δεύτερο παράδειγμα διαχειρίζεται τους πίνακες ξεχωριστά. Ελέγξτε τη διαρρύθμιση που προκύπτει, ιδιαίτερα το κείμενο και τους πίνακες, επειδή αυτά τα παραδείγματα δεν κλιμακώνουν τα μεγέθη γραμματοσειράς και το περιεχόμενο των πινάκων μπορεί να περιορίσει τα ύψη των γραμμών.

**Πώς μπορώ να αλλάξω το μέγεθος των πινάκων όταν αλλάζω το μέγεθος μιας διαφάνειας;**

Κλιμακώστε το πλάτος των στηλών με τον λόγο πλάτους και το ελάχιστο ύψος των γραμμών με τον λόγο ύψους, στη συνέχεια κλιμακώστε τη θέση του πίνακα, όπως φαίνεται στο δεύτερο παράδειγμα.

**Θα λειτουργήσει αυτή η αλλαγή μεγέθους και για master διαφάνειες και διατάξεις;**

Ναι. Το δεύτερο παράδειγμα επαναλαμβάνει τις [Presentation::get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) και κάθε master's [IMasterSlide::get_LayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/get_layoutslides/) και εφαρμόζει την ίδια λογική αλλαγής μεγέθους στα σχήματά τους.

**Μπορώ να αλλάξω τον προσανατολισμό μιας διαφάνειας (κατακόρυφα/οριζόντια) μαζί με την αλλαγή μεγέθους;**

Ναι. Ορίστε το [SlideSize::set_Orientation](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/set_orientation/) μετά την αλλαγή του μεγέθους της διαφάνειας και πριν από την ανάγνωση των διαστάσεων-στόχου, ώστε οι παράγοντες κλίμακας να αντικατοπτρίζουν τον τελικό προσανατολισμό.

**Υπάρχει όριο στο μέγεθος διαφάνειας που μπορώ να ορίσω;**

Μπορείτε να καθορίσετε προσαρμοσμένες διαστάσεις διαφάνειας με το [SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/). Οι υποστηριζόμενες διαστάσεις εξαρτώνται επίσης από τη μορφή της παρουσίασης και την εφαρμογή που χρησιμοποιείται για το άνοιγμα του αρχείου.

**Πώς μπορώ να αποτρέψω τα σχήματα με σταθερό λόγο διαστάσεων να παραμορφωθούν;**

Χρησιμοποιήστε τον ίδιο παράγοντα κλίμακας για το πλάτος και το ύψος. Για να ταιριάξετε την αρχική διάταξη μέσα στις νέες διαστάσεις της διαφάνειας, χρησιμοποιήστε το μικρότερο από τους λόγους πλάτους και ύψους για και τις δύο διαστάσεις και τις θέσεις. Αυτό διατηρεί τις αναλογίες αλλά μπορεί να αφήσει αχρησιμοποίητο χώρο σε μια πλευρά.