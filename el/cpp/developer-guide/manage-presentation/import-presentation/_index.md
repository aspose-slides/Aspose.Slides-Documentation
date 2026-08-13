---
title: Εισαγωγή Παρουσιάσεων από PDF ή HTML σε C++
linktitle: Εισαγωγή Παρουσίασης
type: docs
weight: 60
url: /el/cpp/import-presentation/
keywords:
- εισαγωγή παρουσίασης
- εισαγωγή διαφάνειας
- εισαγωγή PDF
- εισαγωγή HTML
- PDF σε παρουσίαση
- PDF σε PPT
- PDF σε PPTX
- PDF σε ODP
- HTML σε παρουσίαση
- HTML σε PPT
- HTML σε PPTX
- HTML σε ODP
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "Εισάγετε απρόσκοπτα έγγραφα PDF και HTML σε παρουσιάσεις PowerPoint και OpenDocument σε C++ με το Aspose.Slides για ομαλή, υψηλής απόδοσης επεξεργασία διαφάνειας."
---
## **Εισαγωγή**

Χρησιμοποιώντας [**Aspose.Slides for C++**](https://products.aspose.com/slides/el/cpp/), μπορείτε να εισάγετε παρουσιάσεις από αρχεία σε άλλες μορφές. Το Aspose.Slides παρέχει την κλάση [SlideCollection](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.slide_collection) για να σας επιτρέψει να εισάγετε παρουσιάσεις από PDF, έγγραφα HTML κ.λπ.

## **Εισαγωγή PowerPoint από PDF**

Σε αυτήν την περίπτωση, μετατρέπετε ένα PDF σε παρουσίαση PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Δημιουργήστε ένα αντικείμενο της κλάσης παρουσίασης. 
2. Κλήστε τη μέθοδο [AddFromPdf()](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.slide_collection#a966c00d26b741a6c56e424d2f0d689a5) και περάστε το αρχείο PDF. 
3. Χρησιμοποιήστε τη μέθοδο [Save()](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) για να αποθηκεύσετε το αρχείο σε μορφή PowerPoint.

Αυτός ο κώδικας C++ παρουσιάζει τη λειτουργία μετατροπής PDF σε PowerPoint:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
    
pres->get_Slides()->AddFromPdf(u"InputPDF.pdf");
pres->Save(u"OutputPresentation.pptx", SaveFormat::Pptx);
```

{{% alert  title="Tip" color="info" %}} 

Μπορείτε να δοκιμάσετε την δωρεάν εφαρμογή Aspose **PDF to PowerPoint** [PDF to PowerPoint](https://products.aspose.app/slides/el/import/pdf-to-powerpoint) επειδή αποτελεί ζωντανή υλοποίηση της διαδικασίας που περιγράφεται εδώ. 

{{% /alert %}} 

## **Εισαγωγή PowerPoint από HTML**

Σε αυτήν την περίπτωση, μετατρέπετε ένα έγγραφο HTML σε παρουσίαση PowerPoint.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation/). 
2. Κλήστε τη μέθοδο [AddFromHtml()](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.slide_collection#ad4337f6be235c230d5d422a6799ef965) και περάστε το αρχείο HTML. 
3. Χρησιμοποιήστε τη μέθοδο [Save()](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) για να αποθηκεύσετε το αρχείο σε μορφή PowerPoint.

Αυτός ο κώδικας C++ παρουσιάζει τη λειτουργία μετατροπής HTML σε PowerPoint:

```c++
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>();

{
    auto htmlStream = System::IO::File::OpenRead(u"page.html");
    presentation->get_Slides()->AddFromHtml(htmlStream);
}

presentation->Save(u"MyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 

Μπορείτε επίσης να χρησιμοποιήσετε το Aspose.Slides για να μετατρέψετε HTML σε άλλες δημοφιλείς μορφές αρχείων: 

* [HTML σε εικόνα](https://products.aspose.com/slides/el/cpp/conversion/html-to-image/)
* [HTML σε JPG](https://products.aspose.com/slides/el/cpp/conversion/html-to-jpg/)
* [HTML σε XML](https://products.aspose.com/slides/el/cpp/conversion/html-to-xml/)
* [HTML σε TIFF](https://products.aspose.com/slides/el/cpp/conversion/html-to-tiff/)

{{% /alert %}}

## **Συχνές Ερωτήσεις**

### Διατηρούνται οι πίνακες κατά την εισαγωγή ενός PDF και μπορεί να βελτιωθεί η ανίχνευσή τους;

Οι πίνακες μπορούν να εντοπιστούν κατά την εισαγωγή· το [PdfImportOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.import/pdfimportoptions/) περιλαμβάνει τη μέθοδο [set_DetectTables](https://reference.aspose.com/slides/el/cpp/aspose.slides.import/pdfimportoptions/set_detecttables/) που ενεργοποιεί την αναγνώριση πινάκων. Η αποτελεσματικότητα εξαρτάται από τη δομή του PDF.