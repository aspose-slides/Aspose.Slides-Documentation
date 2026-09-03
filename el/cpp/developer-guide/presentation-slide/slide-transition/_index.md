---
title: Διαχείριση Μεταβάσεων Διαφανειών σε Παρουσιάσεις με C++
linktitle: Μετάβαση Διαφάνειας
type: docs
weight: 80
url: /el/cpp/slide-transition/
keywords:
- μετάβαση διαφάνειας
- προσθήκη μετάβασης διαφάνειας
- εφαρμογή μετάβασης διαφάνειας
- προχωρημένη μετάβαση διαφάνειας
- μετάβαση Morph
- τύπος μετάβασης
- εφέ μετάβασης
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Εφαρμόστε μεταβάσεις διαφανειών, διαμορφώστε την αυτόματη προώθηση διαφανειών και προσαρμόστε το Morph και άλλα εφέ μεταβάσεων με το Aspose.Slides for C++."
---
## **Επισκόπηση**

Οι μεταβάσεις διαφανειών ελέγχουν πώς εμφανίζονται οι διαφάνειες κατά τη διάρκεια μιας παρουσίασης. Με το Aspose.Slides for C++ μπορείτε να επιλέξετε ένα εφέ μετάβασης για κάθε διαφάνεια, να ρυθμίσετε την προώθηση με κλικ του ποντικιού ή χρονοδιακόπτη και να προσαρμόσετε επιλογές που είναι συγκεκριμένες για το εφέ. Αυτό το άρθρο χρησιμοποιεί παραδείγματα C++ για την εφαρμογή μεταβάσεων, τον καθορισμό ακριβών χρόνων μετάβασης, τη διαχείριση του χρόνου εμφάνισης των διαφανειών και τη δημιουργία μιας μετάβασης Morph μεταξύ δύο διαφανειών. Τα παραδείγματα δείχνουν επίσης πώς να αποθηκεύσετε τις ρυθμίσεις σε αρχείο PPTX.

## **Προσθήκη Μετάβασης Διαφάνειας**

Για να εφαρμόσετε μια μετάβαση, φορτώστε μια παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) και αποκτήστε πρόσβαση στις ρυθμίσεις μετάβασης της διαφάνειας μέσω της μεθόδου [get_SlideShowTransition](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibaseslide/get_slideshowtransition/). Καλέστε τη μέθοδο [set_Type](https://reference.aspose.com/slides/el/cpp/aspose.slides/islideshowtransition/set_type/) με μια τιμή από την παύση [TransitionType](https://reference.aspose.com/slides/el/cpp/aspose.slides.slideshow/transitiontype/), στη συνέχεια αποθηκεύστε την παρουσίαση.

Το παρακάτω παράδειγμα εφαρμόζει τη μετάβαση Circle στην πρώτη διαφάνεια και τη μετάβαση Comb στη δεύτερη. Χρησιμοποιήστε ένα αρχείο `input.pptx` που περιέχει τουλάχιστον δύο διαφάνειες.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    presentation->get_Slide(0)->get_SlideShowTransition()->set_Type(TransitionType::Circle);
    presentation->get_Slide(1)->get_SlideShowTransition()->set_Type(TransitionType::Comb);

    presentation->Save(u"slide-transitions.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

## **Προχωρημένη Προσθήκη Μετάβασης Διαφάνειας**

Μπορείτε να ρυθμίσετε πόσο χρόνο παραμένει μια διαφάνεια στην οθόνη και αν το κλικ του ποντικιού προωθεί την παρουσίαση. Οι παρακάτω μέθοδοι ελέγχουν αυτή τη συμπεριφορά:

- [set_AdvanceOnClick](https://reference.aspose.com/slides/el/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) επιτρέπει στον θεατή να προχωρήσει με κλικ του ποντικιού.
- [set_AdvanceAfter](https://reference.aspose.com/slides/el/cpp/aspose.slides/islideshowtransition/set_advanceafter/) ενεργοποιεί την αυτόματη προώθηση.
- [set_AdvanceAfterTime](https://reference.aspose.com/slides/el/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) ορίζει την καθυστέρηση πριν από την αυτόματη προώθηση, σε χιλιοστά του δευτερολέπτου.

Ενεργοποιήστε και τα δύο, κλικ και χρονοπρογραμματισμένη προώθηση, ώστε ο θεατής να μπορεί να προχωρήσει με κλικ ή να περιμένει τον χρονοδιακόπτη. Για χρήση μόνο του χρονοδιακόπτη, καλέστε το [set_AdvanceOnClick](https://reference.aspose.com/slides/el/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) με `false`. Η καθυστέρηση ελέγχει πότε προχωρά η παρουσίαση· δεν ορίζει τη διάρκεια του οπτικού εφέ μετάβασης.

Αυτό το παράδειγμα εκχωρεί διαφορετικά εφέ στις τρεις πρώτες διαφάνειες και ενεργοποιεί την αυτόματη προώθηση μετά από 3, 5 και 7 δευτερόλεπτα, αντίστοιχα. Τα κλικ του ποντικιού μπορούν επίσης να προωθήσουν αυτές τις διαφάνειες. Χρησιμοποιήστε ένα αρχείο `input.pptx` που περιέχει τουλάχιστον τρεις διαφάνειες.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 3)
{
    auto firstTransition = presentation->get_Slide(0)->get_SlideShowTransition();
    firstTransition->set_Type(TransitionType::Circle);
    firstTransition->set_AdvanceOnClick(true);
    firstTransition->set_AdvanceAfter(true);
    firstTransition->set_AdvanceAfterTime(3000);

    auto secondTransition = presentation->get_Slide(1)->get_SlideShowTransition();
    secondTransition->set_Type(TransitionType::Comb);
    secondTransition->set_AdvanceOnClick(true);
    secondTransition->set_AdvanceAfter(true);
    secondTransition->set_AdvanceAfterTime(5000);

    auto thirdTransition = presentation->get_Slide(2)->get_SlideShowTransition();
    thirdTransition->set_Type(TransitionType::Zoom);
    thirdTransition->set_AdvanceOnClick(true);
    thirdTransition->set_AdvanceAfter(true);
    thirdTransition->set_AdvanceAfterTime(7000);

    presentation->Save(u"advanced-transitions.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least three slides.");
}

presentation->Dispose();
```

Για να ελέγξετε αν η χρονοπρογραμματισμένη προώθηση είναι ενεργή, καλέστε το [get_AdvanceAfter](https://reference.aspose.com/slides/el/cpp/aspose.slides/islideshowtransition/get_advanceafter/). Η αποθηκευμένη καθυστέρηση από μόνη της δεν υποδηλώνει ότι ο χρονοδιακόπτης είναι ενεργός.

Το επόμενο παράδειγμα ανοίγει το αρχείο που αποθηκεύτηκε παραπάνω, αναφέρει κάθε ενεργό χρονοδιακόπτη και απενεργοποιεί την αυτόματη προώθηση για τις διαφάνειες με καθυστέρηση μεγαλύτερη των δύο δευτερολέπτων. Ενεργοποιεί τα κλικ του ποντικιού για αυτές τις διαφάνειες και αποθηκεύει τις ενημερωμένες ρυθμίσεις.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>(u"advanced-transitions.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();

    if (transition->get_AdvanceAfter())
    {
        Console::WriteLine(u"Slide {0}: advance after {1} ms.", slide->get_SlideNumber(), transition->get_AdvanceAfterTime());

        if (transition->get_AdvanceAfterTime() > 2000)
        {
            transition->set_AdvanceAfter(false);
            transition->set_AdvanceOnClick(true);
        }
    }
}

presentation->Save(u"adjusted-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Ακριβής Έλεγχος Χρόνου Μετάβασης**

Χρησιμοποιήστε το [set_Duration](https://reference.aspose.com/slides/el/cpp/aspose.slides/islideshowtransition/set_duration/) για να ορίσετε το ακριβές μήκος ενός εφέ μετάβασης σε χιλιοστά του δευτερολέπτου. Η μέθοδος [get_SlideShowTransition](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) της διαφάνειας εκθέτει αυτές τις ρυθμίσεις μέσω του [ISlideShowTransition](https://reference.aspose.com/slides/el/cpp/aspose.slides/islideshowtransition/):

| Μέθοδος | Σκοπός |
| --- | --- |
| [set_Duration](https://reference.aspose.com/slides/el/cpp/aspose.slides/islideshowtransition/set_duration/) | Ορίζει τη διάρκεια του ίδιου του εφέ μετάβασης, σε χιλιοστά του δευτερολέπτου. |
| [set_AdvanceAfterTime](https://reference.aspose.com/slides/el/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) | Ορίζει την καθυστέρηση πριν από την αυτόματη προώθηση της διαφάνειας, σε χιλιοστά του δευτερολέπτου. Καλέστε το [set_AdvanceAfter](https://reference.aspose.com/slides/el/cpp/aspose.slides/islideshowtransition/set_advanceafter/) με `true` για να ενεργοποιήσετε αυτόν τον χρονοδιακόπτη. |
| [set_Speed](https://reference.aspose.com/slides/el/cpp/aspose.slides/islideshowtransition/set_speed/) | Επιλέγει μια προ‑ορισμένη κατηγορία ταχύτητας από το [TransitionSpeed](https://reference.aspose.com/slides/el/cpp/aspose.slides.slideshow/transitionspeed/): Slow, Medium ή Fast. Χρησιμοποιείται όταν δεν έχει καθοριστεί ακριβής διάρκεια. |

Το [set_Duration](https://reference.aspose.com/slides/el/cpp/aspose.slides/islideshowtransition/set_duration/) ελέγχει μόνο το εφέ μετάβασης· δεν καθορίζει πόσο χρόνο παραμένει η διαφάνεια ορατή. Ρυθμίστε ξεχωριστά την καθυστέρηση αυτόματης προώθησης. Όταν δεν οριστεί ρητή διάρκεια, το Aspose.Slides υπολογίζει τη διάρκεια του εφέ βάσει του τύπου μετάβασης και της τιμής που επιστρέφει το [get_Speed](https://reference.aspose.com/slides/el/cpp/aspose.slides/islideshowtransition/get_speed/).

### **Εφαρμογή Ίδιας Διάρκειας σε Όλες τις Διαφάνειες**

Για ομοιόμορφο ρυθμό, εφαρμόστε το ίδιο εφέ και την ίδια ακριβή διάρκεια σε κάθε διαφάνεια. Αυτό το παράδειγμα φορτώνει το `input.pptx`, επιλέγει Fade από το [TransitionType](https://reference.aspose.com/slides/el/cpp/aspose.slides.slideshow/transitiontype/) και δίνει σε κάθε μετάβαση διάρκεια 750 χιλιοστών του δευτερολέπτου. Επιπλέον, ενεργοποιεί την αυτόματη προώθηση μετά από 5 000 χιλιοστά του δευτερολέπτου και απενεργοποιεί την προώθηση με κλικ του ποντικιού, μετά αποθηκεύει το αποτέλεσμα ως PPTX.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();
    transition->set_Type(TransitionType::Fade);
    transition->set_Duration(750);

    // Διαμορφώστε την αυτόματη προώθηση ανεξάρτητα από τη διάρκεια του εφέ.
    transition->set_AdvanceAfter(true);
    transition->set_AdvanceAfterTime(5000);
    transition->set_AdvanceOnClick(false);
}

presentation->Save(u"precise-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Ορισμός Διαφορετικών Διαρκειών για Ατομικές Διαφάνειες**

Διαφορετικές διαφάνειες μπορούν να έχουν διαφορετικές διάρκειες εφέ. Για παράδειγμα, χρησιμοποιήστε μια σύντομη μετάβαση για τη διαφάνεια τίτλου και μια μεγαλύτερη για την εισαγωγή ενότητας. Αυτό το παράδειγμα ορίζει 500 χιλιοστά του δευτερολέπτου για την πρώτη διαφάνεια και 1 200 χιλιοστά του δευτερολέπτου για τη δεύτερη. Χρησιμοποιήστε ένα αρχείο `input.pptx` που περιέχει τουλάχιστον δύο διαφάνειες.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    auto firstTransition = presentation->get_Slide(0)->get_SlideShowTransition();
    firstTransition->set_Type(TransitionType::Fade);
    firstTransition->set_Duration(500);

    auto secondTransition = presentation->get_Slide(1)->get_SlideShowTransition();
    secondTransition->set_Type(TransitionType::Push);
    secondTransition->set_Duration(1200);

    presentation->Save(u"individual-transition-durations.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

### **Συντονισμός Μεταβάσεων με Αναπαράγεται Έξοδο**

Κατά την προετοιμασία ενός [animated GIF](/slides/el/cpp/convert-powerpoint-to-animated-gif/), μιας [HTML5 presentation](/slides/el/cpp/export-to-html5/) ή ενός [video](/slides/el/cpp/convert-powerpoint-to-video/), ορίστε ακριβείς διάρκειες μεταβάσεων πριν από την εξαγωγή ώστε να ταιριάζουν με το επιθυμητό ρυθμό. Για παράδειγμα, χρησιμοποιήστε ένα fade 600 ms μεταξύ σκηνών και ρυθμίστε χωριστά την καθυστέρηση προώθησης κάθε διαφάνειας για να επιτρέψετε χρόνο για αφήγηση ή περιεχόμενο.

Για GIF και βίντεο, συντονίστε το ρυθμό καρέ εξόδου με τη διάρκεια του εφέ: 600 ms αντιστοιχούν σε 18 καρέ στα 30 fps. Στο HTML5, ενεργοποιήστε τις animated μεταβάσεις στις ρυθμίσεις εξαγωγής. Ελέγξτε τις υποστηριζόμενες επιλογές εφέ και χρόνου του επιλεγμένου μορφότυπου εξόδου και προεπισκοπήστε το αποτέλεσμα για επαλήθευση του συγχρονισμού.

### **Ανάγνωση Υπάρχουσας Διάρκειας Μετάβασης**

Καλέστε το [get_Duration](https://reference.aspose.com/slides/el/cpp/aspose.slides/islideshowtransition/get_duration/) πριν τροποποιήσετε τη μετάβαση για να διαπιστώσετε αν αποθηκεύεται ρητή τιμή. Μια τιμή `-1` σημαίνει ότι δεν έχει οριστεί ρητή διάρκεια· μια μη αρνητική τιμή υποδεικνύει την αποθηκευμένη διάρκεια σε χιλιοστά του δευτερολέπτου. Η μη ορισμένη τιμή δεν είναι η υπολογισμένη διάρκεια αναπαραγωγής: το Aspose.Slides χρησιμοποιεί τον τύπο μετάβασης και την τιμή που επιστρέφει το [get_Speed](https://reference.aspose.com/slides/el/cpp/aspose.slides/islideshowtransition/get_speed/) για να προσδιορίσει αυτή τη διάρκεια. Η ρύθμιση τύπου μετάβασης μπορεί να αρχικοποιήσει μια διάρκεια, γι’ αυτό πρώτα εξετάστε τις αρχικές ρυθμίσεις.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <DOM/SlideShowTransition/TransitionSpeed.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();
    auto duration = transition->get_Duration();

    if (duration >= 0)
    {
        Console::WriteLine(u"Slide {0}: stored transition duration is {1} ms.", slide->get_SlideNumber(), duration);
    }
    else
    {
        Console::WriteLine(u"Slide {0}: no explicit duration; timing depends on {1} and {2}.", slide->get_SlideNumber(), transition->get_Type(), transition->get_Speed());
    }
}

presentation->Dispose();
```

## **Μετάβαση Morph**

Η μετάβαση Morph ανιματοποιεί τις αλλαγές μεταξύ αντικειμένων σε διαδοχικές διαφάνειες. Για να δημιουργήσετε ένα απλό εφέ Morph, κλωνοποιήστε μια διαφάνεια, μετακινήστε ή αλλάξτε το μέγεθος ενός αντικειμένου στο αντίγραφο και εφαρμόστε τη μετάβαση Morph στη δεύτερη διαφάνεια. Αυτό δίνει στα αντίστοιχα αντικείμενα τη δυνατότητα να ανιματοποιηθούν από την αρχική στην τροποποιημένη τους κατάσταση.

Το παρακάτω παράδειγμα δημιουργεί μια διαφάνεια με ένα ορθογώνιο κείμενο, κλωνοποιεί τη διαφάνεια και αλλάζει τη θέση και το μέγεθος του ορθογωνίου στο αντίγραφο. Στη συνέχεια επιλέγει Morph από την παύση [TransitionType](https://reference.aspose.com/slides/el/cpp/aspose.slides.slideshow/transitiontype/) για τη δεύτερη διαφάνεια. Ανοίξτε το αποθηκευμένο αρχείο σε προβολή παρουσίασης που υποστηρίζει Morph για να δείτε το εφέ κατά τη διάρκεια της παρουσίασης.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);
auto rectangle = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
rectangle->get_TextFrame()->set_Text(u"Morph transition");

auto secondSlide = presentation->get_Slides()->AddClone(firstSlide);
auto movedRectangle = secondSlide->get_Shape(0);
movedRectangle->set_X(movedRectangle->get_X() + 100);
movedRectangle->set_Y(movedRectangle->get_Y() + 50);
movedRectangle->set_Width(movedRectangle->get_Width() - 200);
movedRectangle->set_Height(movedRectangle->get_Height() - 10);

secondSlide->get_SlideShowTransition()->set_Type(TransitionType::Morph);

presentation->Save(u"morph-transition.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Τύποι Μετάβασης Morph**

Η παύση [TransitionMorphType](https://reference.aspose.com/slides/el/cpp/aspose.slides.slideshow/transitionmorphtype/) ελέγχει πώς το Morph ταιριάζει και ανιματοποιεί το περιεχόμενο:

- [ByObject](https://reference.aspose.com/slides/el/cpp/aspose.slides.slideshow/transitionmorphtype/) θεωρεί κάθε σχήμα ως ολόκληρο αντικείμενο.
- [ByWord](https://reference.aspose.com/slides/el/cpp/aspose.slides.slideshow/transitionmorphtype/) ανιματοποιεί το κείμενο ταιριάζοντας λέξεις όπου είναι δυνατόν.
- [ByChar](https://reference.aspose.com/slides/el/cpp/aspose.slides.slideshow/transitionmorphtype/) ανιματοποιεί το κείμενο ταιριάζοντας χαρακτήρες όπου είναι δυνατόν.

Καλέστε το [set_Type](https://reference.aspose.com/slides/el/cpp/aspose.slides/islideshowtransition/set_type/) με Morph πριν αποκτήσετε το [get_Value](https://reference.aspose.com/slides/el/cpp/aspose.slides/islideshowtransition/get_value/). Η τιμή παρέχει τη διεπαφή [IMorphTransition](https://reference.aspose.com/slides/el/cpp/aspose.slides.slideshow/imorphtransition/), της οποίας η μέθοδος [set_MorphType](https://reference.aspose.com/slides/el/cpp/aspose.slides.slideshow/imorphtransition/set_morphtype/) επιλέγει τη λειτουργία ταύτισης.

Αυτό το παράδειγμα ανοίγει την παρουσίαση που δημιουργήθηκε στην προηγούμενη ενότητα και διαμορφώνει τη δεύτερη διαφάνεια ώστε να χρησιμοποιεί ανίμαση βάσει λέξεων.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/IMorphTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionMorphType.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"morph-transition.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    auto transition = presentation->get_Slide(1)->get_SlideShowTransition();
    transition->set_Type(TransitionType::Morph);

    auto morphTransition = AsCast<IMorphTransition>(transition->get_Value());
    if (morphTransition != nullptr)
    {
        morphTransition->set_MorphType(TransitionMorphType::ByWord);
        presentation->Save(u"morph-by-word.pptx", SaveFormat::Pptx);
    }
    else
    {
        Console::WriteLine(u"Morph transition options are unavailable.");
    }
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

## **Ορισμός Εφέ Μετάβασης**

Ορισμένες μεταβάσεις εκθέτουν πρόσθετες επιλογές, όπως κατεύθυνση ή το αν το εφέ ξεκινά από μαύρη οθόνη. Οι διαθέσιμες επιλογές εξαρτώνται από τον επιλεγμένο τύπο μετάβασης. Ορίστε πρώτα τον τύπο, κατόπιν χρησιμοποιήστε τη σχετική διεπαφή που επιστρέφεται από το [get_Value](https://reference.aspose.com/slides/el/cpp/aspose.slides/islideshowtransition/get_value/).

Το παρακάτω παράδειγμα εφαρμόζει τη μετάβαση Cut στην πρώτη διαφάνεια του `input.pptx`. Καλεί το [set_FromBlack](https://reference.aspose.com/slides/el/cpp/aspose.slides.slideshow/ioptionalblacktransition/set_fromblack/) με `true` μέσω του [IOptionalBlackTransition](https://reference.aspose.com/slides/el/cpp/aspose.slides.slideshow/ioptionalblacktransition/) ώστε η μετάβαση να ξεκινά από μαύρη οθόνη.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/IOptionalBlackTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto transition = presentation->get_Slide(0)->get_SlideShowTransition();
transition->set_Type(TransitionType::Cut);

auto cutTransition = AsCast<IOptionalBlackTransition>(transition->get_Value());
if (cutTransition != nullptr)
{
    cutTransition->set_FromBlack(true);
    presentation->Save(u"cut-from-black.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Cut transition options are unavailable.");
}

presentation->Dispose();
```

## **ΣΥΝΗΘΕΣ ΕΡΩΤΗΣΕΙΣ**

**Μπορώ να ελέγξω την ταχύτητα αναπαραγωγής μιας μετάβασης διαφάνειας;**

Ναι. Προτιμήστε το [set_Duration](https://reference.aspose.com/slides/el/cpp/aspose.slides/islideshowtransition/set_duration/) όταν χρειάζεστε ακριβή διάρκεια εφέ σε χιλιοστά του δευτερολέπτου. Χρησιμοποιήστε το [set_Speed](https://reference.aspose.com/slides/el/cpp/aspose.slides/islideshowtransition/set_speed/) όταν αρκεί μια προ‑ορισμένη κατηγορία [TransitionSpeed](https://reference.aspose.com/slides/el/cpp/aspose.slides.slideshow/transitionspeed/): Slow, Medium ή Fast, και δεν έχει οριστεί ρητή διάρκεια. Αυτές οι ρυθμίσεις ελέγχουν το εφέ μετάβασης ανεξάρτητα από την καθυστέρηση αυτόματης προώθησης.

**Μπορώ να συσχετίσω ήχο με μια μετάβαση και να τον επαναλαμβάνω;**

Ναι. Αντιστοιχίστε ενσωματωμένο ήχο με το [set_Sound](https://reference.aspose.com/slides/el/cpp/aspose.slides/islideshowtransition/set_sound/), καλέστε το [set_SoundMode](https://reference.aspose.com/slides/el/cpp/aspose.slides/islideshowtransition/set_soundmode/) με `StartSound` από την παύση [TransitionSoundMode](https://reference.aspose.com/slides/el/cpp/aspose.slides.slideshow/transitionsoundmode/), και ενεργοποιήστε την επανάληψη με το [set_SoundLoop](https://reference.aspose.com/slides/el/cpp/aspose.slides/islideshowtransition/set_soundloop/). Ο ήχος επαναλαμβάνεται μέχρι το επόμενο γεγονός ήχου στην παρουσίαση.

**Ποιος είναι ο γρηγορότερος τρόπος για να εφαρμόσετε την ίδια μετάβαση σε όλες τις διαφάνειες;**

Κάντε βρόχο μέσω της συλλογής που επιστρέφεται από τη μέθοδο [get_Slides](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_slides/) της παρουσίασης και καλέστε το [set_Type](https://reference.aspose.com/slides/el/cpp/aspose.slides/islideshowtransition/set_type/) με την ίδια τιμή για τη μετάβαση κάθε διαφάνειας. Ορίστε τυχόν χρόνους και επιλογές εφέ μέσα στον ίδιο βρόχο ώστε η συμπεριφορά να παραμένει συνεπής σε όλες τις διαφάνειες.

**Πώς μπορώ να ελέγξω ποια μετάβαση είναι αυτή τη στιγμή ορισμένη σε μια διαφάνεια;**

Καλέστε το [get_Type](https://reference.aspose.com/slides/el/cpp/aspose.slides/islideshowtransition/get_type/) στη μετάβαση που επιστρέφεται από τη μέθοδο [get_SlideShowTransition](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) της διαφάνειας. Επιστρέφει μια τιμή από την παύση [TransitionType](https://reference.aspose.com/slides/el/cpp/aspose.slides.slideshow/transitiontype/); η τιμή None σημαίνει ότι δεν έχει εφαρμοστεί καμία μετάβαση.