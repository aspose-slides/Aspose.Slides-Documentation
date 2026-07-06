---
title: Απόκτηση συνόρων τμήματος κειμένου από παρουσιάσεις σε C++
linktitle: Σύνορα τμήματος
type: docs
weight: 47
url: /el/cpp/portion-bounds/
keywords:
- σύνορα τμήματος κειμένου
- τμήμα κειμένου
- μέρος κειμένου
- συντεταγμένες κειμένου
- θέση κειμένου
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Μάθετε πώς να ανακτήσετε τα σύνορα τμήματος κειμένου σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για C++."
---
## **Επισκόπηση**

Ένα τμήμα κειμένου αντιπροσωπεύει ένα συγκεκριμένο κομμάτι κειμένου μέσα σε μια παράγραφο και σας επιτρέπει να εργάζεστε με αυτό το κομμάτι ανεξάρτητα από το περιεχόμενο γύρω του. Στο Aspose.Slides, τα τμήματα μπορούν να χρησιμοποιηθούν όταν χρειάζεται να ανακτήσετε τα όρια ενός τμήματος κειμένου, να εφαρμόσετε μορφοποίηση μόνο σε μέρος μιας παραγράφου ή να ελέγξετε τη συμπεριφορά του κειμένου σε πιο λεπτομερή επίπεδο.

Αυτό το άρθρο δείχνει πώς να λάβετε το ορθογώνιο περιθώριο ενός τμήματος χρησιμοποιώντας [IPortion::GetRect](https://reference.aspose.com/slides/el/cpp/aspose.slides/iportion/getrect/). Επίσης δείχνει πώς να λάβετε τις συντεταγμένες της αρχής ενός τμήματος χρησιμοποιώντας [IPortion::GetCoordinates](https://reference.aspose.com/slides/el/cpp/aspose.slides/iportion/getcoordinates/). Επιπλέον, αναδεικνύει κοινές περιπτώσεις που αφορούν τα τμήματα, όπως η εφαρμογή υπερσυνδέσμου σε ένα μόνο κομμάτι κειμένου, η κατανόηση του πώς η μορφοποίηση επιλύεται μέσω του τμήματος, της παραγράφου, του πλαισίου κειμένου και της κληρονομικότητας θέματος, καθώς και η διαχείριση περιπτώσεων όπου μια καθορισμένη γραμματοσειρά δεν είναι διαθέσιμη.

## **Λήψη Ορίων ενός Τμήματος Κειμένου**

Χρησιμοποιήστε το [IPortion::GetRect](https://reference.aspose.com/slides/el/cpp/aspose.slides/iportion/getrect/) για να ανακτήσετε το ορθογώνιο περιθώριο ενός τμήματος κειμένου:

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraphs = shape->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    auto portions = paragraph->get_Portions();
    for (const auto& portion : portions)
    {
        auto rectangle = portion->GetRect();
        auto rectangleX = rectangle.get_X();
        auto rectangleY = rectangle.get_Y();
        auto rectangleWidth = rectangle.get_Width();
        auto rectangleHeight = rectangle.get_Height();

        Console::WriteLine(u"X = {0}; Y = {1}; Width = {2}; Height = {3}", rectangleX, rectangleY, rectangleWidth, rectangleHeight);
    }
}

presentation->Dispose();
```

## **Λήψη Συντεταγμένων ενός Τμήματος Κειμένου**

Χρησιμοποιήστε το [IPortion::GetCoordinates](https://reference.aspose.com/slides/el/cpp/aspose.slides/iportion/getcoordinates/) για να ανακτήσετε τις συντεταγμένες της αρχής ενός τμήματος κειμένου:

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraphs = shape->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    auto portions = paragraph->get_Portions();
    for (const auto& portion : portions)
    {
        auto point = portion->GetCoordinates();
        auto pointX = point.get_X();
        auto pointY = point.get_Y();

        Console::WriteLine(u"X = {0}; Y = {1}", pointX, pointY);
    }
}

presentation->Dispose();
```

## **Συχνές Ερωτήσεις**

**Μπορώ να εφαρμόσω έναν υπερσύνδεσμο μόνο σε μέρος του κειμένου μέσα σε μία παράγραφο;**

Ναι, μπορείτε να [αναθέσετε έναν υπερσύνδεσμο](/slides/el/cpp/manage-hyperlinks/) σε ένα μεμονωμένο τμήμα· μόνο αυτό το κομμάτι θα είναι κλικάσιμο, όχι ολόκληρη η παράγραφος.

**Πώς λειτουργεί η κληρονομικότητα στυλ: τι παρακάμπτει ένα τμήμα και τι λαμβάνει από μια παράγραφο ή ένα πλαίσιο κειμένου;**

Οι ιδιότητες σε επίπεδο τμήματος έχουν τη μεγαλύτερη προτεραιότητα. Εάν μια ιδιότητα δεν είναι ορισμένη στο [IPortion](https://reference.aspose.com/slides/el/cpp/aspose.slides/iportion/), το Aspose.Slides τη λαμβάνει από το [IParagraph](https://reference.aspose.com/slides/el/cpp/aspose.slides/iparagraph/). Εάν δεν είναι ορισμένη ούτε εκεί, το Aspose.Slides χρησιμοποιεί το στυλ του [ITextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/) ή του [theme](https://reference.aspose.com/slides/el/cpp/aspose.slides.theme/theme/) .

**Τι συμβαίνει αν η γραμματοσειρά που έχει καθοριστεί για ένα τμήμα λείπει από τον προορισμό ή τον διακομιστή;**

Ισχύουν οι [κανόνες αντικατάστασης γραμματοσειρών](/slides/el/cpp/font-selection-sequence/). Το κείμενο μπορεί να αναδιαταχθεί: οι μετρήσεις, η συλλαβισμός και το πλάτος μπορούν να αλλάξουν, κάτι που έχει σημασία για ακριβή τοποθέτηση.

**Μπορώ να ορίσω διαφάνεια ή διαβάθμιση γεμίσματος κειμένου ειδικά για ένα τμήμα, ανεξάρτητα από το υπόλοιπο της παραγράφου;**

Ναι, το χρώμα κειμένου, το γέμισμα και η διαφάνεια στο επίπεδο του [IPortion](https://reference.aspose.com/slides/el/cpp/aspose.slides/iportion/) μπορούν να διαφέρουν από τα γειτονικά τμήματα.