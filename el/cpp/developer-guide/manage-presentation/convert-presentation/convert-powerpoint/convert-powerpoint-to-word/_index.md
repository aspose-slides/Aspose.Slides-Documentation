---
title: Μετατροπή Παρουσιάσεων PowerPoint σε Έγγραφα Word σε C++
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
description: "Μετατρέψτε τις διαφάνειες PowerPoint PPT και PPTX σε επεξεργάσιμα έγγραφα Word σε C++ χρησιμοποιώντας το Aspose.Slides με ακριβή διάταξη, εικόνες και διατηρημένη μορφοποίηση."
---
## **Εισαγωγή**

Αν σκοπεύετε να χρησιμοποιήσετε το κειμενικό περιεχόμενο ή τις πληροφορίες από μια παρουσίαση (PPT ή PPTX) με νέους τρόπους, μπορεί να ωφεληθείτε από τη μετατροπή της παρουσίασης σε Word (DOC ή DOCX). 

* Σε σύγκριση με το Microsoft PowerPoint, η εφαρμογή Microsoft Word είναι πιο εξοπλισμένη με εργαλεία ή λειτουργίες για περιεχόμενο. 
* Εκτός από τις λειτουργίες επεξεργασίας στο Word, μπορείτε επίσης να ωφεληθείτε από τις ενισχυμένες δυνατότητες συνεργασίας, εκτύπωσης και κοινής χρήσης. 

{{% alert color="primary" %}} 

Μπορεί να θέλετε να δοκιμάσετε τον [**Μετατροπέα Παρουσίασης σε Word Online**](https://products.aspose.app/slides/el/conversion/ppt-to-word) για να δείτε τι μπορείτε να κερδίσετε δουλεύοντας με κειμενικό περιεχόμενο από διαφάνειες. 

{{% /alert %}} 

## **Aspose.Slides και Aspose.Words**

Για να μετατρέψετε ένα αρχείο PowerPoint (PPTX ή PPT) σε Word (DOCX ή DOCX), χρειάζεστε και τα δύο [Aspose.Slides for C++](https://products.aspose.com/slides/el/cpp/) και [Aspose.Words for C++](https://products.aspose.com/words/cpp/).

Ως αυτόνομο API, το [Aspose.Slides](https://products.aspose.app/slides) for C++ παρέχει λειτουργίες που σας επιτρέπουν να εξάγετε κείμενα από παρουσιάσεις. 

Το [Aspose.Words](https://docs.aspose.com/words/cpp/) είναι ένα προηγμένο API επεξεργασίας εγγράφων που επιτρέπει στις εφαρμογές να δημιουργούν, τροποποιούν, μετατρέπουν, αποδίδουν, εκτυπώνουν αρχεία και να εκτελούν άλλες εργασίες με έγγραφα χωρίς τη χρήση του Microsoft Word.

## **Μετατροπή Παρουσίασης PowerPoint σε Έγγραφο Word**

Χρησιμοποιήστε αυτό το απόσπασμα κώδικα για να μετατρέψετε το PowerPoint σε Word:

```cpp
auto presentation = MakeObject<Presentation>();
auto doc = MakeObject<Aspose::Words::Document>();
auto builder = MakeObject<Aspose::Words::DocumentBuilder>(doc);

for (const auto& slide : presentation->get_Slides())
{
    // δημιουργεί και εισάγει την εικόνα της διαφάνειας
    auto image = slide->GetImage(1.0f, 1.0f);
    builder->InsertImage(image);

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
```

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Τι στοιχεία πρέπει να εγκατασταθούν για να μετατρέψετε παρουσιάσεις PowerPoint και OpenDocument σε έγγραφα Word;**

Χρειάζεται μόνο να προσθέσετε τα αντίστοιχα πακέτα για [Aspose.Slides for C++](https://releases.aspose.com/slides/el/cpp/) και [Aspose.Words for C++](https://releases.aspose.com/words/cpp/) στο έργο σας. Και οι δύο βιβλιοθήκες λειτουργούν ως αυτόνομα APIs και δεν υπάρχει απαίτηση να εγκατασταθεί το Microsoft Office.

**Υποστηρίζονται όλα τα μορφότυπα παρουσίασης PowerPoint και OpenDocument;**

Το Aspose.Slides [υποστηρίζει όλα τα μορφότυπα παρουσίασης](/slides/el/cpp/supported-file-formats/), συμπεριλαμβανομένων των PPT, PPTX, ODP και άλλων κοινών τύπων αρχείων. Αυτό διασφαλίζει ότι μπορείτε να εργάζεστε με παρουσιάσεις που δημιουργήθηκαν σε διάφορες εκδόσεις του Microsoft PowerPoint.