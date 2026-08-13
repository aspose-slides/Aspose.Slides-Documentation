---
title: Αλλαγή Μεγέθους Σχημάτων σε Διαφάνειες Παρουσίασης
type: docs
weight: 100
url: /el/cpp/re-sizing-shapes-on-slide/
keywords:
  - αλλαγή μεγέθους σχήματος
  - αλλαγή σχήματος
  - PowerPoint
  - OpenDocument
  - παρουσίαση
  - C++
  - Aspose.Slides
description: "Απλώς αλλάξτε το μέγεθος των σχημάτων σε διαφάνειες PowerPoint και OpenDocument με το Aspose.Slides για C++ — αυτοματοποιήστε τις προσαρμογές της διάταξης των διαφανειών και αυξήστε την παραγωγικότητα."
---
## **Επισκόπηση**

Μία από τις πιο συνηθισμένες ερωτήσεις των πελατών του Aspose.Slides για C++ είναι πώς να αλλάξουν το μέγεθος των σχημάτων ώστε, όταν αλλάζει το μέγεθος της διαφάνειας, τα δεδομένα να μην περικοπούν. Αυτό το σύντομο τεχνικό άρθρο δείχνει πώς να το κάνετε.

## **Αλλαγή Μεγέθους Σχημάτων**

Για να αποτρέψετε τα σχήματα από το να καταστραφούν όταν αλλάζει το μέγεθος της διαφάνειας, ενημερώστε τη θέση και τις διαστάσεις κάθε σχήματος ώστε να ταιριάζουν στη νέα διάταξη της διαφάνειας.

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

// Φορτώστε το αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>(u"sample.ppt");

// Get the original slide size.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Change the slide size without scaling existing shapes.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);

// Get the new slide size.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

// Resize and reposition shapes on every slide.
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Κλιμακώστε το μέγεθος του σχήματος.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Κλιμακώστε τη θέση του σχήματος.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="info" %}} 
Εάν μια διαφάνεια περιέχει πίνακα, ο παραπάνω κώδικας δεν θα λειτουργήσει σωστά. Σε αυτήν την περίπτωση, κάθε κελί του πίνακα πρέπει να αλλάξει μέγεθος.
{{% /alert %}} 

Χρησιμοποιήστε τον παρακάτω κώδικα στην πλευρά σας για να αλλάξετε το μέγεθος διαφανειών που περιέχουν πίνακες. Για πίνακες, ο ορισμός του πλάτους ή του ύψους αποτελεί ειδική περίπτωση: πρέπει να προσαρμόσετε τα ύψη των μεμονωμένων σειρών και τα πλάτη των στηλών για να αλλάξετε το συνολικό μέγεθος του πίνακα.

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
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Λάβετε το αρχικό μέγεθος της διαφάνειας.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Αλλάξτε το μέγεθος της διαφάνειας χωρίς κλιμάκωση των υπαρχόντων σχημάτων.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
//presentation.SlideSize.Orientation = SlideOrienation.Portrait;

// Λάβετε το νέο μέγεθος της διαφάνειας.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

for (auto&& master : presentation->get_Masters())
{
    for (auto&& shape : master->get_Shapes())
    {
        // Κλιμακώστε το μέγεθος του σχήματος.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Κλιμακώστε τη θέση του σχήματος.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        for (auto&& shape : layoutSlide->get_Shapes())
        {
            // Κλιμακώστε το μέγεθος του σχήματος.
            shape->set_Height(shape->get_Height() * heightRatio);
            shape->set_Width(shape->get_Width() * widthRatio);

            // Κλιμακώστε τη θέση του σχήματος.
            shape->set_Y(shape->get_Y() * heightRatio);
            shape->set_X(shape->get_X() * widthRatio);
        }
    }
}

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Κλιμακώστε το μέγεθος του σχήματος.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Κλιμακώστε τη θέση του σχήματος.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);

        if (ObjectExt::Is<ITable>(shape))
        {
            SharedPtr<ITable> table = ExplicitCast<ITable>(shape);
            for (auto&& row : table->get_Rows())
            {
                row->set_MinimalHeight(row->get_MinimalHeight() * heightRatio);
            }
            for (auto&& column : table->get_Columns())
            {
                column->set_Width(column->get_Width() * widthRatio);
            }
        }
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ΣΥΧΝΑ ΕΡΩΤΗΜΑΤΑ**

### Γιατί τα σχήματα παραμορφώνονται ή περικόπτονται μετά την αλλαγή μεγέθους μιας διαφάνειας;

Κατά την αλλαγή μεγέθους μιας διαφάνειας, τα σχήματα διατηρούν τη αρχική τους θέση και διάσταση εκτός εάν αλλάξει ρητά η κλίμακα. Αυτό μπορεί να οδηγήσει σε περικοπές του περιεχομένου ή σε μη ευθυγραμμισμένα σχήματα.

### Ο κώδικας που παρέχεται λειτουργεί για όλους τους τύπους σχημάτων;

Το βασικό παράδειγμα λειτουργεί για τους περισσότερους τύπους σχημάτων (πλαίσια κειμένου, εικόνες, διαγράμματα κλπ.). Ωστόσο, για πίνακες, πρέπει να χειριστείτε ξεχωριστά τις σειρές και τις στήλες, καθώς το ύψος και το πλάτος ενός πίνακα καθορίζονται από τις διαστάσεις των μεμονωμένων κελιών.

### Πώς να αλλάξω το μέγεθος των πινάκων κατά την αλλαγή μεγέθους μιας διαφάνειας;

Πρέπει να διαπεράσετε όλες τις σειρές και στήλες του πίνακα και να αλλάξετε το ύψος και το πλάτος τους ανάλογα, όπως φαίνεται στο δεύτερο παράδειγμα κώδικα.

### Θα λειτουργήσει αυτή η αλλαγή μεγέθους για τις κύριες διαφάνειες και τις διαφάνειες διάταξης;

Ναι, αλλά θα πρέπει επίσης να διαπεράσετε τα [Ματρικά](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_masters/) και τις [Διαφάνειες διάταξης](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_layoutslides/) και να εφαρμόσετε την ίδια λογική κλιμάκωσης στα σχήματά τους για να διασφαλίσετε την ομοιομορφία σε όλη την παρουσίαση.

### Μπορώ να αλλάξω τον προσανατολισμό μιας διαφάνειας (portrait/landscape) μαζί με την αλλαγή μεγέθους;

Ναι. Μπορείτε να χρησιμοποιήσετε το [presentation->get_SlideSize()->set_Orientation](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidesize/set_orientation/) για να αλλάξετε τον προσανατολισμό. Βεβαιωθείτε ότι έχετε ορίσει τη λογική κλιμάκωσης ανάλογα ώστε να διατηρηθεί η διάταξη.

### Υπάρχει όριο στο μέγεθος της διαφάνειας που μπορώ να ορίσω;

Το Aspose.Slides υποστηρίζει προσαρμοσμένα μεγέθη, αλλά πολύ μεγάλα μεγέθη μπορεί να επηρεάσουν την απόδοση ή τη συμβατότητα με ορισμένες εκδόσεις του PowerPoint.

### Πώς μπορώ να αποτρέψω τα σχήματα με σταθερό λόγο διαστάσεων να παραμορφώνονται;

Μπορείτε να ελέγξετε τη μέθοδο `get_AspectRatioLocked` του σχήματος πριν από την κλιμάκωση. Αν είναι κλειδωμένη, προσαρμόστε το πλάτος ή το ύψος ανάλογα αντί να τα κλιμακώσετε ξεχωριστά.