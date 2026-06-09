---
title: Διαχείριση τμημάτων κειμένου σε παρουσιάσεις χρησιμοποιώντας C++
linktitle: Τμήμα κειμένου
type: docs
weight: 70
url: /el/cpp/portion/
keywords:
- τμήμα κειμένου
- μέρος κειμένου
- συντεταγμένες κειμένου
- θέση κειμένου
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: Μάθετε πώς να διαχειρίζεστε τμήματα κειμένου σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για C++, βελτιώνοντας την απόδοση και την προσαρμογή.
---
## **Εισαγωγή**

Ένα τμήμα κειμένου αντιπροσωπεύει ένα συγκεκριμένο απόσπασμα κειμένου μέσα σε μια παράγραφο και σας επιτρέπει να εργάζεστε με αυτό το απόσπασμα ανεξάρτητα από το περιβάλλον περιεχόμενο. Στο Aspose.Slides, τα τμήματα μπορούν να χρησιμοποιηθούν όταν χρειάζεται να ανακτήσετε τη θέση ενός αποσπάσματος κειμένου, να εφαρμόσετε μορφοποίηση μόνο σε μέρος μιας παραγράφου ή να ελέγξετε τη συμπεριφορά του κειμένου σε πιο λεπτομερές επίπεδο.

## **Λήψη Συντεταγμένων ενός Τμήματος Κειμένου**
**GetCoordinates()** method has been added to IPortion and Portion class which allows retrieving the coordinates of the beginning of the portion:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();

for (const auto& paragraph : textFrame->get_Paragraphs())
{
    for (const auto& portion : paragraph->get_Portions())
    {
        PointF point = portion->GetCoordinates();
        Console::WriteLine(String(u"Coordinates X =") + point.get_X() + u" Coordinates Y =" + point.get_Y());
    }
}
```

## **FAQ**

**Μπορώ να εφαρμόσω έναν υπερσύνδεσμο μόνο σε μέρος του κειμένου μέσα σε μία παράγραφο;**

Ναι, μπορείτε να [αναθέσετε έναν υπερσύνδεσμο](/slides/el/cpp/manage-hyperlinks/) σε ένα μεμονωμένο τμήμα· μόνο εκείνο το απόσπασμα θα είναι κλικιμη, όχι ολόκληρη η παράγραφος.

**Πώς λειτουργεί η κληρονομικότητα στυλ: τι παρακάμπτει ένα Portion και τι λαμβάνεται από το Paragraph/TextFrame;**

Οι ιδιότητες σε επίπεδο Portion έχουν την υψηλότερη προτεραιότητα. Εάν μια ιδιότητα δεν έχει οριστεί στο [Portion](https://reference.aspose.com/slides/el/cpp/aspose.slides/portion/), η μηχανή τη λαμβάνει από το [Paragraph](https://reference.aspose.com/slides/el/cpp/aspose.slides/paragraph/); εάν δεν είναι ορισμένη ούτε εκεί, τη λαμβάνει από το [TextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/textframe/) ή από το στυλ του [theme](https://reference.aspose.com/slides/el/cpp/aspose.slides.theme/theme/).

**Τι συμβαίνει εάν η γραμματοσειρά που έχει οριστεί για ένα Portion λείπει στο στόχο μηχάνημα/διακομιστή;**

Εφαρμόζονται οι [κανόνες αντικατάστασης γραμματοσειρών](/slides/el/cpp/font-selection-sequence/). Το κείμενο μπορεί να αναδιαταχθεί: οι μετρικές, η συλλαβοτομία και το πλάτος μπορεί να αλλάξουν, κάτι που είναι σημαντικό για ακριβή τοποθέτηση.

**Μπορώ να ορίσω διαφάνεια ή διαβάθμιση γεμίσματος κειμένου ειδικά για ένα Portion, ανεξάρτητα από το υπόλοιπο της παραγράφου;**

Ναι, το χρώμα κειμένου, το γέμισμα και η διαφάνεια σε επίπεδο [Portion](https://reference.aspose.com/slides/el/cpp/aspose.slides/portion/) μπορούν να διαφέρουν από τα γειτονικά τμήματα.