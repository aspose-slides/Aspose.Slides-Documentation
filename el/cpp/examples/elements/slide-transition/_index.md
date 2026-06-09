---
title: Μετάβαση Διαφάνειας
type: docs
weight: 110
url: /el/cpp/examples/elements/slide-transition/
keywords:
- παράδειγμα κώδικα
- μετάβαση διαφάνειας
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Κατακτήστε τις μεταβάσεις διαφάνειας στο Aspose.Slides for C++: προσθέστε, προσαρμόστε και συνδυάστε εφέ και διάρκειες με παραδείγματα C++ για παρουσιάσεις PPT, PPTX και ODP."
---
Αυτό το άρθρο δείχνει την εφαρμογή εφέ μετάβασης διαφάνειας και χρονισμών με **Aspose.Slides for C++**.

## **Προσθήκη Μετάβασης Διαφάνειας**

Εφαρμόστε ένα εφέ εξασθένισης στην πρώτη διαφάνεια.

```cpp
static void AddSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    // Εφαρμόστε μια μετάβαση εξασθένισης.
    slide->get_SlideShowTransition()->set_Type(TransitionType::Fade);

    presentation->Dispose();
}
```

## **Πρόσβαση σε Μετάβαση Διαφάνειας**

Διαβάστε τον τύπο μετάβασης που έχει εκχωρηθεί αυτή τη στιγμή σε μία διαφάνεια.

```cpp
static void AccessSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_Type(TransitionType::Push);

    // Πρόσβαση στον τύπο μετάβασης.
    auto type = slide->get_SlideShowTransition()->get_Type();

    presentation->Dispose();
}
```

## **Αφαίρεση Μετάβασης Διαφάνειας**

Αφαιρέστε οποιοδήποτε εφέ μετάβασης ορίζοντας τον τύπο σε `None`.

```cpp
static void RemoveSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_Type(TransitionType::Fade);

    // Αφαιρέστε τη μετάβαση ορίζοντας none.
    slide->get_SlideShowTransition()->set_Type(TransitionType::None);

    presentation->Dispose();
}
```

## **Ορισμός Διάρκειας Μετάβασης**

Καθορίστε για πόσο χρόνο εμφανίζεται η διαφάνεια πριν προχωρήσει αυτόματα.

```cpp
static void SetTransitionDuration()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_AdvanceOnClick(true);
    slide->get_SlideShowTransition()->set_AdvanceAfterTime(2000); // Σε χιλιοστά του δευτερολέπτου.

    presentation->Dispose();
}
```