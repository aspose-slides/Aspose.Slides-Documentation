---
title: Προχωρημένη Εξαγωγή Κειμένου από Παρουσιάσεις σε C++
linktitle: Εξαγωγή Κειμένου
type: docs
weight: 90
url: /el/cpp/extract-text-from-presentation/
keywords:
- εξαγωγή κειμένου
- εξαγωγή κειμένου από διαφάνεια
- εξαγωγή κειμένου από παρουσίαση
- εξαγωγή κειμένου από PowerPoint
- εξαγωγή κειμένου από OpenDocument
- εξαγωγή κειμένου από PPT
- εξαγωγή κειμένου από PPTX
- εξαγωγή κειμένου από ODP
- ανάκτηση κειμένου
- ανάκτηση κειμένου από διαφάνεια
- ανάκτηση κειμένου από παρουσίαση
- ανάκτηση κειμένου από PowerPoint
- ανάκτηση κειμένου από OpenDocument
- ανάκτηση κειμένου από PPT
- ανάκτηση κειμένου από PPTX
- ανάκτηση κειμένου από ODP
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Εξαγάγετε γρήγορα κείμενο από παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για C++. Ακολουθήστε τον απλό, βήμα-βήμα οδηγό μας για να εξοικονομήσετε χρόνο."
---
## **Επισκόπηση**

Η εξαγωγή κειμένου από παρουσιάσεις είναι μια συνηθισμένη αλλά απαραίτητη εργασία για προγραμματιστές που εργάζονται με το περιεχόμενο των διαφανειών. Είτε χειρίζεστε αρχεία Microsoft PowerPoint σε μορφή PPT ή PPTX, είτε παρουσιάσεις OpenDocument (ODP), η πρόσβαση και η ανάκτηση κειμενικών δεδομένων μπορεί να είναι κρίσιμη για ανάλυση, αυτοματοποίηση, ευρετηρίαση ή μεταφορά περιεχομένου.

Αυτό το άρθρο παρέχει έναν ολοκληρωμένο οδηγό για το πώς να εξάγετε αποτελεσματικά κείμενο από διάφορες μορφές παρουσιάσεων, συμπεριλαμβανομένων των PPT, PPTX και ODP, χρησιμοποιώντας το Aspose.Slides for C++. Θα μάθετε πώς να διασχίζετε συστηματικά τα στοιχεία μιας παρουσίασης ώστε να ανακτήσετε ακριβώς το κείμενο που χρειάζεστε.

## **Εξαγωγή Κειμένου από μια Διαφάνεια**

Το Aspose.Slides for C++ παρέχει το χώρο ονομάτων [Aspose.Slides.Util](https://reference.aspose.com/slides/el/cpp/aspose.slides.util/) , ο οποίος περιλαμβάνει την κλάση [SlideUtil](https://reference.aspose.com/slides/el/cpp/aspose.slides.util/slideutil/). Αυτή η κλάση εκθέτει αρκετές υπερφορτωμένες στατικές μεθόδους για την εξαγωγή όλου του κειμένου από μια παρουσίαση ή διαφάνεια. Για να εξάγετε κείμενο από μια διαφάνεια σε μια παρουσίαση, χρησιμοποιήστε τη μέθοδο [GetAllTextBoxes](https://reference.aspose.com/slides/el/cpp/aspose.slides.util/slideutil/getalltextboxes/). Αυτή η μέθοδος δέχεται ένα αντικείμενο τύπου [IBaseSlide](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibaseslide/) ως παράμετρο. Κατά την εκτέλεση, η μέθοδος σαρώει ολόκληρη τη διαφάνεια για κείμενο και επιστρέφει έναν πίνακα αντικειμένων τύπου [ITextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/), διατηρώντας τυχόν μορφοποίηση του κειμένου.

```cpp
auto slideIndex = 0;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto textFrames = Util::SlideUtil::GetAllTextBoxes(slide);

for (const auto& textFrame : textFrames)
{
    for (const auto& paragraph : textFrame->get_Paragraphs())
    {
        for (const auto& portion : paragraph->get_Portions())
        {
            auto portionText = portion->get_Text();
            Console::WriteLine(portionText);

            auto portionFormat = portion->get_PortionFormat();
            auto fontHeight = portionFormat->get_FontHeight();
            Console::WriteLine(fontHeight);

            auto latinFont = portionFormat->get_LatinFont();
            if (latinFont != nullptr)
            {
                auto fontName = latinFont->get_FontName();
                Console::WriteLine(fontName);
            }
        }
    }
}

presentation->Dispose();
```

## **Εξαγωγή Κειμένου από Παρουσίαση**

Για να σαρώσετε το κείμενο σε ολόκληρη την παρουσίαση, χρησιμοποιήστε τη στατική μέθοδο [GetAllTextFrames](https://reference.aspose.com/slides/el/cpp/aspose.slides.util/slideutil/getalltextframes/) που εκτίθεται από την κλάση [SlideUtil](https://reference.aspose.com/slides/el/cpp/aspose.slides.util/slideutil/). Δέχεται δύο παραμέτρους:

1. Πρώτα, ένα αντικείμενο [IPresentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentation/) που αντιπροσωπεύει μια παρουσίαση PowerPoint ή OpenDocument από την οποία θα εξαχθεί το κείμενο.  
1. Δεύτερον, μια τιμή `Boolean` που υποδεικνύει εάν οι κύριες διαφάνειες πρέπει να συμπεριληφθούν κατά τη σάρωση του κειμένου στην παρουσίαση.

Η μέθοδος επιστρέφει έναν πίνακα αντικειμένων τύπου [ITextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/), περιλαμβάνοντας πληροφορίες μορφοποίησης κειμένου. Ο παρακάτω κώδικας σαρώνει το κείμενο και τις λεπτομέρειες μορφοποίησης από μια παρουσίαση, συμπεριλαμβανομένων των κύριων διαφανειών.

```cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto includeMasterSlides = true;
auto textFrames = Util::SlideUtil::GetAllTextFrames(presentation, includeMasterSlides);

for (const auto& textFrame : textFrames)
{
    for (const auto& paragraph : textFrame->get_Paragraphs())
    {
        for (const auto& portion : paragraph->get_Portions())
        {
            auto portionText = portion->get_Text();
            Console::WriteLine(portionText);

            auto portionFormat = portion->get_PortionFormat();
            auto fontHeight = portionFormat->get_FontHeight();
            Console::WriteLine(fontHeight);

            auto latinFont = portionFormat->get_LatinFont();
            if (latinFont != nullptr)
            {
                auto fontName = latinFont->get_FontName();
                Console::WriteLine(fontName);
            }
        }
    }
}

presentation->Dispose();
```

## **Κατηγοριοποιημένη και Γρήγορη Εξαγωγή Κειμένου**

Η κλάση [PresentationFactory](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentationfactory/) παρέχει επίσης μεθόδους για την εξαγωγή όλου του κειμένου από παρουσιάσεις:

```cpp
System::SharedPtr<IPresentationText> GetPresentationText(System::String file, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode, System::SharedPtr<ILoadOptions> options);
```

Το όρισμα enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/el/cpp/aspose.slides/textextractionarrangingmode/) υποδεικνύει τη λειτουργία οργάνωσης του αποτελέσματος εξαγωγής κειμένου και μπορεί να οριστεί στις ακόλουθες τιμές:
- `Unarranged` – Το ακατέργαστο κείμενο χωρίς να ληφθεί υπόψη η θέση του στη διαφάνεια.  
- `Arranged` – Το κείμενο είναι διατεταγμένο με την ίδια σειρά όπως στη διαφάνεια.

Η λειτουργία Unarranged μπορεί να χρησιμοποιηθεί όταν η ταχύτητα είναι κρίσιμη· είναι ταχύτερη από τη λειτουργία Arranged.

[IPresentationText](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentationtext/) αντιπροσωπεύει το ακατέργαστο κείμενο που εξάγεται από την παρουσίαση. Η μέθοδός του `get_SlidesText()` επιστρέφει έναν πίνακα αντικειμένων τύπου [ISlideText](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidetext/). Κάθε αντικείμενο αντιπροσωπεύει το κείμενο της αντίστοιχης διαφάνειας. Το αντικείμενο τύπου [ISlideText](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidetext/) διαθέτει τις παρακάτω μεθόδους:

- `get_Text()` – Το κείμενο εντός των σχήματων της διαφάνειας.  
- `get_MasterText()` – Το κείμενο εντός των σχήματων της κύριας διαφάνειας που σχετίζεται με αυτήν τη διαφάνεια.  
- `get_LayoutText()` – Το κείμενο εντός των σχήματων της διάταξης διαφάνειας που σχετίζεται με αυτήν τη διαφάνεια.  
- `get_NotesText()` – Το κείμενο εντός των σχήματων της σημειωμένης διαφάνειας που σχετίζεται με αυτήν τη διαφάνεια.  
- `get_CommentsText()` – Το κείμενο εντός των σχολίων που σχετίζονται με αυτήν τη διαφάνεια.

```cpp
auto presentationPath = u"presentation.ppt";
auto arrangingMode = TextExtractionArrangingMode::Unarranged;
auto presentationText = PresentationFactory::get_Instance()->GetPresentationText(presentationPath, arrangingMode);
auto firstSlideText = presentationText->get_SlidesText()[0];

Console::WriteLine(firstSlideText->get_Text());
Console::WriteLine(firstSlideText->get_LayoutText());
Console::WriteLine(firstSlideText->get_MasterText());
Console::WriteLine(firstSlideText->get_NotesText());
Console::WriteLine(firstSlideText->get_CommentsText());
```

## **Συχνές Ερωτήσεις**

**Πόσο γρήγορα επεξεργάζεται το Aspose.Slides μεγάλες παρουσιάσεις κατά την εξαγωγή κειμένου;**

Το Aspose.Slides είναι βελτιστοποιημένο για υψηλή απόδοση και μπορεί να επεξεργαστεί ακόμη και [large presentations](/slides/el/cpp/open-presentation/), καθιστώντας το κατάλληλο για σενάρια επεξεργασίας σε πραγματικό χρόνο ή μαζικά.

**Μπορεί το Aspose.Slides να εξάγει κείμενο από πίνακες και γραφήματα μέσα σε παρουσιάσεις;**

Ναι. Το Aspose.Slides μπορεί να εξάγει κείμενο από πολλά στοιχεία διαφάνειας, συμπεριλαμβανομένων πινάκων και αντικειμένων σχετικών με γραφήματα, ώστε να μπορείτε να έχετε πρόσβαση και να αναλύετε το κειμενικό περιεχόμενο σε κοινές δομές παρουσιάσεων.

**Χρειάζομαι ειδική άδεια Aspose.Slides για την εξαγωγή κειμένου από παρουσιάσεις;**

Μπορείτε να εξάγετε κείμενο χρησιμοποιώντας τη δωρεάν δοκιμαστική έκδοση του Aspose.Slides, αν και θα έχει [certain limitations](/slides/el/cpp/licensing/), όπως η επεξεργασία μόνο περιορισμένου αριθμού διαφανειών. Για απεριόριστη χρήση και για την επεξεργασία μεγαλύτερων παρουσιάσεων, συνιστάται η αγορά πλήρους άδειας.