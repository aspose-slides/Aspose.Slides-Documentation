---
title: "Προηγμένη Εξαγωγή Κειμένου από Παρουσιάσεις σε C++"
linktitle: "Εξαγωγή Κειμένου"
type: docs
weight: 90
url: /el/cpp/extract-text-from-presentation/
aliases:
  - /cpp/extracting-text-from-the-presentation/
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
description: "Εξαγάγετε γρήγορα κείμενο από παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για C++. Ακολουθήστε τον απλό, βήμα προς βήμα οδηγό μας για να εξοικονομήσετε χρόνο."
---
## **Επισκόπηση**

Η εξαγωγή κειμένου από παρουσιάσεις είναι μια συχνή, αλλά ουσιώδης, εργασία για προγραμματιστές που εργάζονται με περιεχόμενο διαφανειών. Είτε διαχειρίζεστε αρχεία Microsoft PowerPoint σε μορφή PPT ή PPTX, είτε παρουσιάσεις OpenDocument (ODP), η πρόσβαση και η ανάκτηση κειμενικών δεδομένων μπορεί να είναι κρίσιμη για ανάλυση, αυτοματοποίηση, ευρετηρίαση ή μετανάστευση περιεχομένου.

Αυτό το άρθρο παρέχει έναν ολοκληρωμένο οδηγό για το πώς να εξάγετε κείμενο αποδοτικά από διάφορες μορφές παρουσιάσεων, συμπεριλαμβανομένων των PPT, PPTX και ODP, χρησιμοποιώντας το Aspose.Slides for C++. Θα μάθετε πώς να επαναλαμβάνετε συστηματικά τα στοιχεία μιας παρουσίασης για την ακριβή ανάκτηση του κειμένου που χρειάζεστε.

## **Εξαγωγή κειμένου από μια διαφάνεια**

Το Aspose.Slides for C++ παρέχει τον χώρο ονομάτων [Aspose.Slides.Util](https://reference.aspose.com/slides/el/cpp/aspose.slides.util/), ο οποίος περιλαμβάνει την κλάση [SlideUtil](https://reference.aspose.com/slides/el/cpp/aspose.slides.util/slideutil/). Αυτή η κλάση εκθέτει πολλές υπερφορτωμένες στατικές μεθόδους για την εξαγωγή όλου του κειμένου από μια παρουσίαση ή διαφάνεια. Για την εξαγωγή κειμένου από μια διαφάνεια σε μια παρουσίαση, χρησιμοποιήστε τη μέθοδο [GetAllTextBoxes](https://reference.aspose.com/slides/el/cpp/aspose.slides.util/slideutil/getalltextboxes/). Αυτή η μέθοδος δέχεται ένα αντικείμενο του τύπου [IBaseSlide](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibaseslide/) ως παράμετρο. Κατά την εκτέλεση, η μέθοδος σαρώει ολόκληρη τη διαφάνεια για κείμενο και επιστρέφει έναν πίνακα αντικειμένων του τύπου [ITextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/), διατηρώντας τυχόν μορφοποίηση κειμένου.

Το παρακάτω απόσπασμα κώδικα εξάγει όλο το κείμενο από την πρώτη διαφάνεια της παρουσίασης:

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

## **Εξαγωγή κειμένου από μια παρουσίαση**

Για να σαρώσετε κείμενο από ολόκληρη την παρουσίαση, χρησιμοποιήστε τη στατική μέθοδο [GetAllTextFrames](https://reference.aspose.com/slides/el/cpp/aspose.slides.util/slideutil/getalltextframes/) που εκτίθεται από την κλάση [SlideUtil](https://reference.aspose.com/slides/el/cpp/aspose.slides.util/slideutil/). Δέχεται δύο παραμέτρους:

1. Πρώτον, ένα αντικείμενο [IPresentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentation/) που αντιπροσωπεύει μια παρουσίαση PowerPoint ή OpenDocument από την οποία θα εξαχθεί το κείμενο.
2. Δεύτερον, μια τιμή `Boolean` που υποδεικνύει αν οι κύριες διαφάνειες (master slides) θα συμπεριληφθούν κατά τη σάρωση του κειμένου από την παρουσίαση.

Η μέθοδος επιστρέφει έναν πίνακα αντικειμένων του τύπου [ITextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/), περιλαμβάνοντας πληροφορίες μορφοποίησης κειμένου. Ο παρακάτω κώδικας σαρώει το κείμενο και τις λεπτομέρειες μορφοποίησης από μια παρουσίαση, συμπεριλαμβανομένων των master slides.

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

## **Κατηγοριοποιημένη και γρήγορη εξαγωγή κειμένου**

Η κλάση [PresentationFactory](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentationfactory/) παρέχει επίσης μεθόδους για την εξαγωγή όλου του κειμένου από παρουσιάσεις:

```cpp
System::SharedPtr<IPresentationText> GetPresentationText(System::String file, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode, System::SharedPtr<ILoadOptions> options);
```

Το όρισμα enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/el/cpp/aspose.slides/textextractionarrangingmode/) υποδεικνύει τη μέθοδο οργάνωσης του αποτελέσματος εξαγωγής κειμένου και μπορεί να οριστεί στις παρακάτω τιμές:
- `Unarranged` – Το ακατέργαστο κείμενο χωρίς προσαρμογή στη θέση του στην διαφάνεια.
- `Arranged` – Το κείμενο διατεταγμένο στη ίδια σειρά όπως στην διαφάνεια.

Η αδιάτακτη (Unarranged) λειτουργία μπορεί να χρησιμοποιηθεί όταν η ταχύτητα είναι κρίσιμη· είναι ταχύτερη από τη διατεταγμένη (Arranged) λειτουργία.

Το [IPresentationText](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentationtext/) αντιπροσωπεύει το ακατέργαστο κείμενο που εξάγεται από την παρουσίαση. Η μέθοδος `get_SlidesText()` του επιστρέφει έναν πίνακα αντικειμένων του τύπου [ISlideText](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidetext/). Κάθε αντικείμενο αντιπροσωπεύει το κείμενο στην αντίστοιχη διαφάνεια. Το αντικείμενο τύπου [ISlideText](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidetext/) διαθέτει τις ακόλουθες μεθόδους:

- `get_Text()` – Το κείμενο εντός των σχημάτων της διαφάνειας.
- `get_MasterText()` – Το κείμενο εντός των σχημάτων του master slide που σχετίζονται με αυτή τη διαφάνεια.
- `get_LayoutText()` – Το κείμενο εντός των σχημάτων του layout slide που σχετίζονται με αυτή τη διαφάνεια.
- `get_NotesText()` – Το κείμενο εντός των σχημάτων της notes slide που σχετίζονται με αυτή τη διαφάνεια.
- `get_CommentsText()` – Το κείμενο εντός των σχολίων που σχετίζονται με αυτή τη διαφάνεια.

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

## **Συχνές ερωτήσεις**

**Πόσο γρήγορα επεξεργάζεται το Aspose.Slides μεγάλες παρουσιάσεις κατά την εξαγωγή κειμένου;**

Το Aspose.Slides είναι βελτιστοποιημένο για υψηλή απόδοση και μπορεί να επεξεργαστεί ακόμη και [μεγάλες παρουσιάσεις](/slides/el/cpp/open-presentation/), καθιστώντας το κατάλληλο για σενάρια σε πραγματικό χρόνο ή μαζικής επεξεργασίας.

**Μπορεί το Aspose.Slides να εξάγει κείμενο από πίνακες και γραφήματα μέσα σε παρουσιάσεις;**

Ναι. Το Aspose.Slides μπορεί να εξάγει κείμενο από πολλά στοιχεία διαφάνειας, συμπεριλαμβανομένων πινάκων και αντικειμένων σχετικών με γραφήματα, ώστε να μπορείτε να έχετε πρόσβαση και να αναλύετε το κειμενικό περιεχόμενο σε κοινές δομές παρουσίασης.

**Χρειάζομαι ειδική άδεια Aspose.Slides για την εξαγωγή κειμένου από παρουσιάσεις;**

Μπορείτε να εξάγετε κείμενο χρησιμοποιώντας τη δωρεάν έκδοση δοκιμής του Aspose.Slides, αν και θα έχει [ορισμένους περιορισμούς](/slides/el/cpp/licensing/), όπως η επεξεργασία μόνο περιορισμένου αριθμού διαφανειών. Για απεριόριστη χρήση και για την επεξεργασία μεγαλύτερων παρουσιάσεων, συνιστάται η αγορά πλήρους άδειας.