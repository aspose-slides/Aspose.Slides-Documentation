---
title: Διαφάνεια
type: docs
weight: 10
url: /el/cpp/examples/elements/slide/
keywords:
- παράδειγμα κώδικα
- διαφάνεια
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Διαχειριστείτε τις διαφάνειες στο Aspose.Slides for C++: δημιουργήστε, κλωνοποιήστε, αναδιατάξτε, αλλάξτε το μέγεθος, ορίστε φόντο και εφαρμόστε μεταβάσεις με C++ για παρουσιάσεις PPT, PPTX και ODP."
---
Αυτό το άρθρο παρέχει μια σειρά παραδειγμάτων που δείχνουν πώς να εργάζεστε με διαφάνειες χρησιμοποιώντας **Aspose.Slides for C++**. Θα μάθετε πώς να προσθέτετε, να έχετε πρόσβαση, να κλωνοποιείτε, να αναδιατάσσετε και να αφαιρείτε διαφάνειες χρησιμοποιώντας την κλάση `Presentation`.

Κάθε παράδειγμα παρακάτω περιλαμβάνει μια σύντομη εξήγηση, ακολουθούμενη από ένα κομμάτι κώδικα σε C++.

## **Προσθήκη διαφάνειας**

Για να προσθέσετε μια νέα διαφάνεια, πρέπει πρώτα να επιλέξετε μια διάταξη. Σε αυτό το παράδειγμα, χρησιμοποιούμε τη διάταξη `Blank` και προσθέτουμε μια κενή διαφάνεια στην παρουσίαση.

```cpp
static void AddSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    presentation->get_Slides()->AddEmptySlide(blankLayout);

    presentation->Dispose();
}
```

> 💡**Σημείωση:** Κάθε διάταξη διαφάνειας προέρχεται από μια κύρια διαφάνεια, η οποία ορίζει το συνολικό σχέδιο και τη δομή των δεσμευτικών θέσεων. Η παρακάτω εικόνα απεικονίζει πώς οργανώνονται οι κύριες διαφάνειες και οι σχετικές διατάξεις τους στο PowerPoint.

![Σχέση κύριας διαφάνειας και διάταξης](master-layout-slide.png)

## **Πρόσβαση σε διαφάνειες με βάση τον δείκτη**

Μπορείτε να έχετε πρόσβαση σε διαφάνειες χρησιμοποιώντας τον δείκτη τους, ή να βρείτε τον δείκτη μιας διαφάνειας με βάση μια αναφορά. Αυτό είναι χρήσιμο για την επανάληψη μέσα ή την τροποποίηση συγκεκριμένων διαφανειών.

```cpp
static void AccessSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Προσθέστε άλλη κενή διαφάνεια.
    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
    presentation->get_Slides()->AddEmptySlide(blankLayout);

    // Πρόσβαση σε διαφάνειες με βάση τον δείκτη.
    auto firstSlide = presentation->get_Slide(0);
    auto secondSlide = presentation->get_Slide(1);

    // Λάβετε τον δείκτη της διαφάνειας από μια αναφορά, μετά αποκτήστε πρόσβαση σε αυτήν με το δείκτη.
    auto secondSlideIndex = presentation->get_Slides()->IndexOf(secondSlide);
    auto secondSlideByIndex = presentation->get_Slide(secondSlideIndex);

    presentation->Dispose();
}
```

## **Κλωνοποίηση διαφάνειας**

Αυτό το παράδειγμα δείχνει πώς να κλωνοποιήσετε μια υπάρχουσα διαφάνεια. Η κλωνοποιημένη διαφάνεια προστίθεται αυτόματα στο τέλος της συλλογής διαφανειών.

```cpp
static void CloneSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto firstSlide = presentation->get_Slide(0);

    auto clonedSlide = presentation->get_Slides()->AddClone(firstSlide);

    auto clonedSlideIndex = presentation->get_Slides()->IndexOf(clonedSlide);

    presentation->Dispose();
}
```

## **Αναδιάταξη διαφανειών**

Μπορείτε να αλλάξετε τη σειρά των διαφανειών μετακινώντας μία σε νέο δείκτη. Σε αυτήν την περίπτωση, μετακινούμε μια κλωνοποιημένη διαφάνεια στην πρώτη θέση.

```cpp
static void ReorderSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto firstSlide = presentation->get_Slide(0);

    auto clonedSlide = presentation->get_Slides()->AddClone(firstSlide);

    presentation->get_Slides()->Reorder(0, clonedSlide);

    presentation->Dispose();
}
```

## **Αφαίρεση διαφάνειας**

Για να αφαιρέσετε μια διαφάνεια, απλώς κάντε αναφορά σε αυτήν και καλέστε την `Remove`. Αυτό το παράδειγμα προσθέτει μια δεύτερη διαφάνεια και στη συνέχεια αφαιρεί την αρχική, αφήνοντας μόνο τη νέα.

```cpp
static void RemoveSlide()
{
    auto presentation = MakeObject<Presentation>();

    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
    auto secondSlide = presentation->get_Slides()->AddEmptySlide(blankLayout);

    auto firstSlide = presentation->get_Slide(0);
    presentation->get_Slides()->Remove(firstSlide);

    presentation->Dispose();
}
```