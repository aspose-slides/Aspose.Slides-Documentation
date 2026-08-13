---
title: Μετατροπή Παρουσιών PowerPoint σε Έγγραφα Word σε C++
linktitle: PowerPoint σε Word
type: docs
weight: 110
url: /el/cpp/convert-powerpoint-to-word/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- μετατροπή διαφάνειας
- μετατροπή PPT
- μετατροπή PPTX
- PowerPoint σε Word
- παρουσίαση σε Word
- διαφάνεια σε Word
- PPT σε Word
- PPTX σε Word
- PowerPoint σε DOCX
- παρουσίαση σε DOCX
- διαφάνεια σε DOCX
- PPT σε DOCX
- PPTX σε DOCX
- PowerPoint σε DOC
- παρουσίαση σε DOC
- διαφάνεια σε DOC
- PPT σε DOC
- PPTX σε DOC
- αποθήκευση PPT ως DOCX
- αποθήκευση PPTX ως DOCX
- εξαγωγή PPT σε DOCX
- εξαγωγή PPTX σε DOCX
- C++
- Aspose.Slides
description: "Μετατρέψτε τις διαφάνειες PowerPoint PPT και PPTX σε επεξεργάσιμα έγγραφα Word σε C++ χρησιμοποιώντας το Aspose.Slides με ακριβή διατήρηση διάταξης, εικόνων και μορφοποίησης."
---
## **Εισαγωγή**

Αν σκοπεύετε να χρησιμοποιήσετε κειμενικό περιεχόμενο ή πληροφορίες από μια παρουσίαση (PPT ή PPTX) με νέους τρόπους, μπορεί να ωφεληθείτε από τη μετατροπή της παρουσίασης σε Word (DOC ή DOCX).

* Σε σύγκριση με το Microsoft PowerPoint, η εφαρμογή Microsoft Word είναι πιο εξοπλισμένη με εργαλεία ή λειτουργίες για το περιεχόμενο. 
* Εκτός από τις λειτουργίες επεξεργασίας στο Word, μπορείτε επίσης να ωφεληθείτε από βελτιωμένη συνεργασία, εκτύπωση και δυνατότητες κοινής χρήσης. 

{{% alert color="info" %}} 
Μπορείτε να δοκιμάσετε τον [**Μετατροπέα Παρουσίασης σε Word Online**](https://products.aspose.app/slides/el/conversion/ppt-to-word) για να δείτε τι μπορείτε να κερδίσετε εργάζοντας με κειμενικό περιεχόμενο από διαφάνειες. 
{{% /alert %}} 

## **Aspose.Slides και Aspose.Words**

Για να μετατρέψετε ένα αρχείο PowerPoint (PPTX ή PPT) σε Word (DOCX ή DOC), χρειάζεστε και τα [Aspose.Slides for C++](https://products.aspose.com/slides/el/cpp/) και [Aspose.Words for C++](https://products.aspose.com/words/cpp/).

Ως ανεξάρτητο API, το [Aspose.Slides](https://products.aspose.app/slides) για C++ παρέχει λειτουργίες που σας επιτρέπουν να εξάγετε κείμενα από παρουσιάσεις. 

[Aspose.Words](https://docs.aspose.com/words/cpp/) είναι ένα προηγμένο API επεξεργασίας εγγράφων που επιτρέπει στις εφαρμογές να δημιουργούν, τροποποιούν, μετατρέπουν, αποτυπώνουν, εκτυπώνουν αρχεία και να εκτελούν άλλες εργασίες με έγγραφα χωρίς τη χρήση του Microsoft Word.

## **Μετατροπή Παρουσίασης PowerPoint σε Έγγραφο Word**

Χρησιμοποιήστε αυτό το απόσπασμα κώδικα για να μετατρέψετε το PowerPoint σε Word:

```cpp
#include <Aspose.Words.Cpp/BreakType.h>
#include <Aspose.Words.Cpp/Document.h>
#include <Aspose.Words.Cpp/DocumentBuilder.h>
#include <DOM/AutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto doc = MakeObject<Aspose::Words::Document>();
auto builder = MakeObject<Aspose::Words::DocumentBuilder>(doc);

for (const auto& slide : presentation->get_Slides())
{
    // δημιουργεί μια εικόνα διαφάνειας ως ροή byte array
    auto image = slide->GetImage(1.0f, 1.0f);
    auto imageStream = MakeObject<System::IO::MemoryStream>();
    image->Save(imageStream, Aspose::Slides::ImageFormat::Png);
    image->Dispose();

    builder->InsertImage(imageStream->ToArray());

    // εισάγει τα κείμενα της διαφάνειας
    for (const auto& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<AutoShape>(shape))
        {
            auto autoShape = System::AsCast<AutoShape>(shape);
            builder->Writeln(autoShape->get_TextFrame()->get_Text());
        }
    }

    builder->InsertBreak(Aspose::Words::BreakType::PageBreak);
}

doc->Save(u"output.docx");
presentation->Dispose();
```

## **Συχνές Ερωτήσεις**

### Τι συστατικά πρέπει να εγκατασταθούν για τη μετατροπή παρουσιάσεων PowerPoint και OpenDocument σε έγγραφα Word;

Χρειάζεται μόνο να προσθέσετε τα αντίστοιχα πακέτα για το [Aspose.Slides for C++](https://releases.aspose.com/slides/el/cpp/) και το [Aspose.Words for C++](https://releases.aspose.com/words/cpp/) στο έργο σας. Και οι δύο βιβλιοθήκες λειτουργούν ως ανεξάρτητα APIs και δεν υπάρχει ανάγκη εγκατάστασης του Microsoft Office.

### Υποστηρίζονται όλες οι μορφές παρουσίασης PowerPoint και OpenDocument;

Το Aspose.Slides [υποστηρίζει όλες τις μορφές παρουσίασης](/slides/el/cpp/supported-file-formats/), συμπεριλαμβανομένων των PPT, PPTX, ODP και άλλων κοινών τύπων αρχείων. Αυτό εξασφαλίζει ότι μπορείτε να εργάζεστε με παρουσιάσεις που δημιουργήθηκαν σε διάφορες εκδόσεις του Microsoft PowerPoint.