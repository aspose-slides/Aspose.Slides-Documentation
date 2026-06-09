---
title: Διαφάνεια Διάταξης
type: docs
weight: 20
url: /el/cpp/examples/elements/layout-slide/
keywords:
- παράδειγμα κώδικα
- διαφάνεια διάταξης
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Κύριες διαφάνειες διάταξης στο Aspose.Slides για C++: επιλέξτε, εφαρμόστε και προσαρμόστε διαφάνειες διάταξης, σύμβολα κράτησης θέσης και αρχεία master με παραδείγματα C++ για παρουσιάσεις PPT, PPTX και ODP."
---
Αυτό το άρθρο δείχνει πώς να δουλέψετε με **Layout Slides** στο Aspose.Slides για C++. Μια διαφάνεια διάταξης ορίζει το σχέδιο και τη μορφοποίηση που κληρονομείται από τις κανονικές διαφάνειες. Μπορείτε να προσθέσετε, να προσπελάσετε, να κλωνοποιήσετε και να αφαιρέσετε διαφάνειες διάταξης, καθώς και να καθαρίσετε τις αχρησιμοποίητες ώστε να μειώσετε το μέγεθος της παρουσίασης.

## **Προσθήκη διαφάνειας διάταξης**

Μπορείτε να δημιουργήσετε μια προσαρμοσμένη διαφάνεια διάταξης για να ορίσετε επαναχρησιμοποιήσιμη μορφοποίηση. Για παράδειγμα, θα μπορούσατε να προσθέσετε ένα πλαίσιο κειμένου που εμφανίζεται σε όλες τις διαφάνειες που χρησιμοποιούν αυτή τη διάταξη.

```cpp
static void AddLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto masterSlide = presentation->get_Master(0);

    // Δημιουργήστε μια διαφάνεια διάταξης με τύπο κενής διάταξης και προσαρμοσμένο όνομα.
    auto layoutSlide = presentation->get_LayoutSlides()->Add(masterSlide, SlideLayoutType::Blank, u"Main layout");

    // Προσθέστε ένα πλαίσιο κειμένου στην διαφάνεια διάταξης.
    auto layoutTextBox = layoutSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 75, 75, 150, 150);
    layoutTextBox->get_TextFrame()->set_Text(u"Layout Slide Text");

    // Προσθέστε δύο διαφάνειες χρησιμοποιώντας αυτή τη διάταξη· και οι δύο θα κληρονομήσουν το κείμενο από τη διάταξη.
    presentation->get_Slides()->AddEmptySlide(layoutSlide);
    presentation->get_Slides()->AddEmptySlide(layoutSlide);

    presentation->Dispose();
}
```

> 💡 **Σημείωση 1:** Οι διαφάνειες διάταξης λειτουργούν ως πρότυπα για μεμονωμένες διαφάνειες. Μπορείτε να ορίσετε κοινά στοιχεία μία φορά και να τα επαναχρησιμοποιήσετε σε πολλές διαφάνειες.

> 💡 **Σημείωση 2:** Όταν προσθέτετε σχήματα ή κείμενο σε μια διαφάνεια διάταξης, όλες οι διαφάνειες που βασίζονται σε αυτή τη διάταξη θα εμφανίζουν αυτό το κοινό περιεχόμενο αυτόματα.
> Το στιγμιότυπο παρακάτω δείχνει δύο διαφάνειες, η καθεμία κληρονομεί ένα πλαίσιο κειμένου από την ίδια διαφάνεια διάταξης.

![Διαφάνειες που κληρονομούν περιεχόμενο διάταξης](layout-slide-result.png)

## **Πρόσβαση σε διαφάνεια διάταξης**

Μπορείτε να έχετε πρόσβαση στις διαφάνειες διάταξης με βάση το ευρετήριο ή τον τύπο διάταξης (π.χ., `Blank`, `Title`, `SectionHeader`, κ.λπ.).

```cpp
static void AccessLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Πρόσβαση σε διαφάνεια διάταξης με ευρετήριο.
    auto firstLayoutSlide = presentation->get_LayoutSlide(0);

    // Πρόσβαση σε διαφάνεια διάταξης με τύπο.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    presentation->Dispose();
}
```

## **Αφαίρεση διαφάνειας διάταξης**

Μπορείτε να αφαιρέσετε μια συγκεκριμένη διαφάνεια διάταξης εάν δεν χρειάζεται πια.

```cpp
static void RemoveLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Πάρτε μια διαφάνεια διάταξης κατά τύπο και αφαιρέστε την.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
    presentation->get_LayoutSlides()->Remove(blankLayoutSlide);

    presentation->Dispose();
}
```

## **Αφαίρεση αχρησιμοποίητων διαφανειών διάταξης**

Για να μειώσετε το μέγεθος της παρουσίασης, ίσως θελήσετε να αφαιρέσετε τις διαφάνειες διάταξης που δεν χρησιμοποιούνται από καμία κανονική διαφάνεια.

```cpp
static void RemoveUnusedLayoutSlides()
{
    auto presentation = MakeObject<Presentation>();

    // Αυτόματα αφαιρεί όλες τις διαφάνειες διάταξης που δεν αναφέρονται από καμία διαφάνεια.
    presentation->get_LayoutSlides()->RemoveUnused();

    presentation->Dispose();
}
```

## **Κλωνοποίηση διαφάνειας διάταξης**

Μπορείτε να αντιγράψετε μια διαφάνεια διάταξης χρησιμοποιώντας τη μέθοδο `AddClone`.

```cpp
static void CloneLayoutSlides()
{
    auto presentation = MakeObject<Presentation>();

    // Πάρτε μια υπάρχουσα διαφάνεια διάταξης κατά τύπο.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    // Κλωνοποιήστε τη διαφάνεια διάταξης στο τέλος της συλλογής διαφανειών διάταξης.
    auto clonedLayoutSlide = presentation->get_LayoutSlides()->AddClone(blankLayoutSlide);

    presentation->Dispose();
}
```

> ✅ **Σύνοψη:** Οι διαφάνειες διάταξης είναι ισχυρά εργαλεία για τη διαχείριση συνεπούς μορφοποίησης σε όλες τις διαφάνειες. Το Aspose.Slides παρέχει πλήρη έλεγχο στη δημιουργία, τη διαχείριση και τη βελτιστοποίηση των διαφανειών διάταξης.