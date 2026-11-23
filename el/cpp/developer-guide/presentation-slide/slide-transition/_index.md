---
title: Διαχείριση Μεταβάσεων Διαφάνειας σε Παρουσιάσεις Χρησιμοποιώντας C++
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
description: "Εφαρμόστε μεταβάσεις διαφάνειας, ρυθμίστε την αυτόματη προώθηση διαφανειών και προσαρμόστε τη μετάβαση Morph και άλλα εφέ μετάβασης με το Aspose.Slides για C++."
---
## **Επισκόπηση**

Οι μεταβάσεις διαφάνειας ελέγχουν πώς εμφανίζονται οι διαφάνειες κατά τη διάρκεια μιας παρουσίασης. Με το Aspose.Slides for C++ μπορείτε να επιλέξετε ένα εφέ μετάβασης για κάθε διαφάνεια, να ρυθμίσετε την προώθηση με κλικ του ποντικιού ή χρονοδιακόπτη και να προσαρμόσετε επιλογές συγκεκριμένες για το εφέ. Αυτό το άρθρο χρησιμοποιεί παραδείγματα C++ για να εφαρμόσει μεταβάσεις, να ορίσει ακριβείς διάρκειες μετάβασης, να διαχειριστεί το χρονοδιάγραμμα των διαφανειών και να δημιουργήσει μια μετάβαση Morph μεταξύ δύο διαφανειών. Τα παραδείγματα δείχνουν επίσης πώς να αποθηκεύσετε τις ρυθμίσεις σε αρχείο PPTX.

## **Προσθήκη μετάπτωσης διαφάνειας**

Για να εφαρμόσετε μια μετάβαση, φορτώστε μια παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) και αποκτήστε πρόσβαση στις ρυθμίσεις μετάβασης μιας διαφάνειας μέσω του [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/). Καλέστε το [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) με τιμή από την απαρίθμηση [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/), μετά αποθηκεύστε την παρουσίαση.

Το παρακάτω παράδειγμα εφαρμόζει μια μετάβαση Circle στην πρώτη διαφάνεια και μια μετάβαση Comb στη δεύτερη. Χρησιμοποιήστε ένα αρχείο `input.pptx` με τουλάχιστον δύο διαφάνειες.

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

## **Μετάβαση Wheel**

Η μέθοδος [set_Spokes](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/set_spokes/) του [IWheelTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/) ελέγχει τον αριθμό των κεκεντρικών τμημάτων που αποκαλύπτουν τη διαφάνεια-στόχο. Καλέστε το [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) με Wheel από το [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) πριν προσπελάσετε το [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/) ως [IWheelTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/).

Αυτό το παράδειγμα δημιουργεί δύο ζεύγη πανομοιότυπων διαφανειών: μια μαύρη διαφάνεια ακολουθείται από μια διαφάνεια με χρυσό ορθογώνιο. Οι διαφάνειες-στόχοι χρησιμοποιούν αριθμούς ακίδων 1 και 8, με την ίδια ταχύτητα ορισμένη μέσω του [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) και ρητή διάρκεια 8 000 χιλιοστών του δευτερολέπτου ορισμένη μέσω του [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) ώστε η διαφορά να είναι εύκολα παρατηρήσιμη.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/IBackground.h>
#include <DOM/BackgroundType.h>
#include <DOM/IFillFormat.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideShowTransition/IWheelTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <DOM/SlideShowTransition/TransitionSpeed.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <drawing/size_f.h>
#include <system/object_ext.h>
#include <cstdint>

using namespace System;
using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>();
auto slideWidth = presentation->get_SlideSize()->get_Size().get_Width();
auto slideHeight = presentation->get_SlideSize()->get_Size().get_Height();

auto blackSlide = presentation->get_Slide(0);
blackSlide->get_Shapes()->Clear();
blackSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
blackSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
blackSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

auto destinationSlide = presentation->get_Slides()->AddClone(blackSlide);
auto rectangle = destinationSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, slideWidth, slideHeight);
rectangle->get_FillFormat()->set_FillType(FillType::Solid);
rectangle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gold());
rectangle->get_TextFrame()->set_Text(u"Wheel transition");

presentation->get_Slides()->AddClone(blackSlide);
presentation->get_Slides()->AddClone(destinationSlide);

const uint32_t spokeCounts[] = { 1, 8 };
for (auto i = 0; i < 2; i++)
{
    auto transition = presentation->get_Slide(i * 2 + 1)->get_SlideShowTransition();
    transition->set_Type(TransitionType::Wheel);
    auto wheelTransition = ExplicitCast<IWheelTransition>(transition->get_Value());
    wheelTransition->set_Spokes(spokeCounts[i]);
    transition->set_Speed(TransitionSpeed::Slow);
    transition->set_Duration(8000);
}

presentation->Save(u"wheel-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

Ανοίξτε την παραγόμενη παρουσίαση στο PowerPoint και τρέξτε την παρουσίαση. Προχωρήστε από τη διαφάνεια 1 στη διαφάνεια 2, έπειτα από τη διαφάνεια 3 στη διαφάνεια 4. Στην αναπαραγωγή του PowerPoint, η επαληθευμένη ακίδα 1 αποκαλύπτει τη διαφάνεια με μια κυκλική σάρωση δεξιόστροφα· η επαληθευμένη ακίδα 8 την αποκαλύπτει μέσω οκτώ ακτινικών τμημάτων ταυτόχρονα. Το περιεχόμενο-στόχος και το χρονοδιάγραμμα της μετάβασης είναι ίδια, οπότε η διαφορά είναι ο αριθμός των τμημάτων αποκάλυψης.

## **Fade Through Black με τη μετάβαση Reveal**

Ορίστε τον τύπο μετάβασης της διαφάνειας-στόχου σε Reveal, έπειτα καλέστε το [set_ThroughBlack](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/irevealtransition/set_throughblack/) στο περιβάλλον [IRevealTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/irevealtransition/). Το παράδειγμα δημιουργεί μια γαλαζοπράσινη διαφάνεια-πηγή και μια κοραλική διαφάνεια-στόχο, και στη συνέχεια κλωνοποιεί και τις δύο ώστε να μπορείτε να συγκρίνετε την ίδια διουστική μετάβαση των δύο δευτερολέπτων με το fade through black απενεργοποιημένο και ενεργοποιημένο.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/IBackground.h>
#include <DOM/BackgroundType.h>
#include <DOM/IFillFormat.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/SlideShowTransition/IRevealTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionLeftRightDirectionType.h>
#include <DOM/SlideShowTransition/TransitionSpeed.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/object_ext.h>

using namespace System;
using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto styleSlide = [](SharedPtr<ISlide> slide, Color background, const String& label)
{
    slide->get_Background()->set_Type(BackgroundType::OwnBackground);
    auto fill = slide->get_Background()->get_FillFormat();
    fill->set_FillType(FillType::Solid);
    fill->get_SolidFillColor()->set_Color(background);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 160, 180, 400, 130);
    auto textFrame = shape->get_TextFrame();
    textFrame->set_Text(label);
    textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_FontHeight(44);
};

auto presentation = MakeObject<Presentation>();

auto source = presentation->get_Slide(0);
auto destination = presentation->get_Slides()->AddClone(source);
styleSlide(source, Color::get_Teal(), u"Source");
styleSlide(destination, Color::get_Coral(), u"Destination");
presentation->get_Slides()->AddClone(source);
presentation->get_Slides()->AddClone(destination);

for (auto index : {1, 3})
{
    auto transition = presentation->get_Slide(index)->get_SlideShowTransition();
    transition->set_Type(TransitionType::Reveal);
    transition->set_Speed(TransitionSpeed::Slow);
    transition->set_Duration(2000);

    auto reveal = ExplicitCast<IRevealTransition>(transition->get_Value());
    reveal->set_Direction(TransitionLeftRightDirectionType::Left);
    reveal->set_ThroughBlack(index == 3);
}

presentation->Save(u"reveal-transitions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Σε μια παρουσίαση PowerPoint, προχωρήστε από τη διαφάνεια 1 στη διαφάνεια 2. Η γαλαζοπράσινη διαφάνεια γίνεται άμεσα κοραλική. Έπειτα προχωρήστε από τη διαφάνεια 3 στη διαφάνεια 4. Η οθόνη σκοτεινώνει προσωρινά σχεδόν σε μαύρο πριν εμφανιστεί η κοραλική διαφάνεια. Και οι δύο διαφάνειες διατηρούν τα αρχικά χρώματα φόντου.

Οι παρακάτω γραμμές δείχνουν καρέ από το PowerPoint ανά μισό δευτερόλεπτο. Συγκρίνετε το μεσαίο καρέ σε κάθε γραμμή για να δείτε το αποτέλεσμα της ρύθμισης.

![PowerPoint playback with ThroughBlack disabled (top) and enabled (bottom). Only the bottom row passes through near black.](reveal-through-black.png)

*Το κοινό παράδειγμα δίνει σε κάθε διαφάνεια μια μετάβαση Fade 750 ms και ενεργοποιεί ξεχωριστά την αυτόματη προώθηση στα 5 000 ms. Η διάρκεια της μετάβασης ελέγχει το εφέ· η προώθηση ελέγχει πότε να φύγει η διαφάνεια. Αυτές οι μπαρ είναι σχήμαστικές ρυθμίσεις, όχι μετρημένη συνδυασμένη χρονογραμμή.*

## **Προσθήκη προχωρημένης μετάπτωσης διαφάνειας**

Μπορείτε να ρυθμίσετε πόσο καιρό παραμένει μια διαφάνεια στην οθόνη και αν ένα κλικ του ποντικιού προωθεί την παρουσίαση. Οι παρακάτω μέθοδοι ελέγχουν αυτή τη συμπεριφορά:

- [set_AdvanceOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) επιτρέπει στον θεατή να προχωρήσει κλικάροντας το ποντίκι.
- [set_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceafter/) ενεργοποιεί αυτόματη προώθηση.
- [set_AdvanceAfterTime](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) ορίζει την καθυστέρηση πριν από την αυτόματη προώθηση, σε χιλιοστά του δευτερολέπτου.

Ενεργοποιήστε και το κλικ και την χρονομετρημένη προώθηση ώστε ο θεατής να μπορεί να προχωρήσει με κλικ ή να περιμένει τον χρονοδιακόπτη. Για χρήση μόνο του χρονοδιακόπτη, καλέστε το [set_AdvanceOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) με `false`. Η καθυστέρηση ελέγχει πότε η παρουσίαση προχωρά· δεν ορίζει τη διάρκεια του οπτικού εφέ μετάβασης.

Αυτό το παράδειγμα εκχωρεί διαφορετικά εφέ στις πρώτες τρεις διαφάνειες και ενεργοποιεί αυτόματη προώθηση μετά από 3, 5 και 7 δευτερόλεπτα, αντίστοιχα. Τα κλικ του ποντικιού μπορούν επίσης να προωθήσουν αυτές τις διαφάνειες. Χρησιμοποιήστε ένα αρχείο `input.pptx` με τουλάχιστον τρεις διαφάνειες.

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

Για να ελέγξετε αν η χρονομετρημένη προώθηση είναι ενεργοποιημένη, καλέστε το [get_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_advanceafter/). Μια αποθηκευμένη καθυστέρηση από μόνη της δεν υποδεικνύει ότι ο χρονοδιακόπτης είναι ενεργός.

Το επόμενο παράδειγμα ανοίγει το παραπάνω αρχείο, αναφέρει κάθε ενεργοποιημένο χρονοδιακόπτη και απενεργοποιεί την αυτόματη προώθηση για διαφάνειες με καθυστέρηση μεγαλύτερη από δύο δευτερόλεπτα. Ενεργοποιεί κλικ του ποντικιού για αυτές τις διαφάνειες και αποθηκεύει τις ενημερωμένες ρυθμίσεις.

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

## **Ακριβής έλεγχος του χρονοδιαγράμματος της μετάβασης**

Χρησιμοποιήστε το [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) για να ορίσετε το ακριβές μήκος ενός εφέ μετάβασης σε χιλιοστά του δευτερολέπτου. Η μέθοδος [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) της διαφάνειας αποκαλύπτει αυτές τις ρυθμίσεις μέσω του [ISlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/):

| Μέθοδος | Σκοπός |
| --- | --- |
| [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) | Ορίζει τη διάρκεια του ίδιου του εφέ μετάβασης, σε χιλιοστά του δευτερολέπτου. |
| [set_AdvanceAfterTime](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) | Ορίζει την καθυστέρηση πριν από την αυτόματη προώθηση της διαφάνειας, σε χιλιοστά του δευτερολέπτου. Καλέστε το [set_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceafter/) με `true` για να ενεργοποιήσετε αυτόν τον χρονοδιακόπτη. |
| [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) | Επιλέγει μια προ‑καθορισμένη κατηγορία ταχύτητας από το [TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/): Slow, Medium ή Fast. Χρησιμοποιείται όταν δεν έχει οριστεί ακριβής διάρκεια. |

Το [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) ελέγχει μόνο το εφέ της μετάβασης· δεν καθορίζει πόσο καιρό παραμένει η διαφάνεια ορατή. Ρυθμίστε την αυτόματη καθυστέρηση προώθησης ξεχωριστά. Όταν δεν έχει οριστεί ρητή διάρκεια, το Aspose.Slides υπολογίζει τη διάρκεια του εφέ από τον τύπο της μετάβασης και την τιμή που επιστρέφει η [get_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_speed/).

<!-- visual-explanation:slide-transition:start -->
[![Separate bars identify the 750-ms transition duration and 5,000-ms automatic advancement setting.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Το κοινό παράδειγμα δίνει σε κάθε διαφάνεια μια μετάβαση Fade 750 ms και ξεχωριστά ενεργοποιεί την αυτόματη προώθηση στα 5 000 ms. Η διάρκεια της μετάβασης ελέγχει το εφέ· η προώθηση ελέγχει πότε η διαφάνεια θα φύγει. Αυτές οι μπαρ είναι σχήμαστικές ρυθμίσεις, όχι μια μετρημένη συνδυασμένη χρονογραμμή.*
<!-- visual-explanation:slide-transition:end -->

### **Εφαρμογή της ίδιας διάρκειας σε κάθε διαφάνεια**

Για σταθερό ρυθμό, εφαρμόστε το ίδιο εφέ και την ίδια ακριβή διάρκεια σε κάθε διαφάνεια. Αυτό το παράδειγμα φορτώνει το `input.pptx`, επιλέγει Fade από το [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) και δίνει σε κάθε μετάβαση διάρκεια 750 ms. Ενεργοποιεί ξεχωριστά την αυτόματη προώθηση μετά από 5 000 ms και απενεργοποιεί την προώθηση με κλικ του ποντικιού, έπειτα αποθηκεύει το αποτέλεσμα ως PPTX.

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

### **Ορισμός διαφορετικών διάρκειων για μεμονωμένες διαφάνειες**

Διαφορετικές διαφάνειες μπορούν να έχουν διαφορετικές διάρκειες εφέ. Για παράδειγμα, χρησιμοποιήστε μια σύντομη μετάβαση για μια διαφάνεια τίτλου και μια μεγαλύτερη για μια εισαγωγική διαφάνεια ενότητας. Αυτό το παράδειγμα ορίζει 500 ms για την πρώτη διαφάνεια και 1 200 ms για τη δεύτερη. Χρησιμοποιήστε ένα αρχείο `input.pptx` με τουλάχιστον δύο διαφάνειες.

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

### **Συντονισμός μεταβάσεων με εξαγόμενη κίνηση**

Κατά την προετοιμασία ενός [animated GIF](/slides/el/cpp/convert-powerpoint-to-animated-gif/), μιας [HTML5 presentation](/slides/el/cpp/export-to-html5/) ή ενός [video](/slides/el/cpp/convert-powerpoint-to-video/), ορίστε ακριβείς διάρκειες μεταβάσεων πριν από την εξαγωγή ώστε να ταιριάζουν με τον επιθυμητό ρυθμό. Για παράδειγμα, χρησιμοποιήστε fade 600 ms μεταξύ σκηνών και προσαρμόστε ξεχωριστά την καθυστέρηση προώθησης κάθε διαφάνειας ώστε να υπάρχει χρόνος για αφήγηση ή περιεχόμενο.

Για GIF και βίντεο, συντονίστε το ρυθμό καρέ εξόδου με τη διάρκεια του εφέ: 600 ms αντιστοιχούν σε 18 καρέ στα 30 fps. Στο HTML5, ενεργοποιήστε τις αναλυτικές μεταβάσεις στις ρυθμίσεις εξαγωγής. Ελέγξτε τις υποστηριζόμενες επιλογές εφέ και χρονοδιαγράμματος του επιλεγμένου φορμά εξαγωγής και προεπισκοπήστε το αποτέλεσμα για επιβεβαίωση του συγχρονισμού.

### **Ανάγνωση υπάρχουσας διάρκειας μετάβασης**

Καλέστε το [get_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_duration/) πριν τροποποιήσετε τη μετάβαση για να διαπιστώσετε αν υπάρχει αποθηκευμένη ρητή τιμή. Μια τιμή `-1` σημαίνει ότι δεν έχει οριστεί ρητή διάρκεια· μια μη αρνητική τιμή δηλώνει τη διάρκεια σε χιλιοστά του δευτερολέπτου. Η μη ορισμένη τιμή δεν είναι η υπολογιζόμενη διάρκεια αναπαραγωγής: το Aspose.Slides χρησιμοποιεί τον τύπο της μετάβασης και την τιμή που επιστρέφει η [get_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_speed/) για να την καθορίσει. Ο ορισμός ενός τύπου μετάβασης μπορεί να αρχικοποιήσει μια διάρκεια, γι'αυτό πρώτα ελέγξτε τις αρχικές ρυθμίσεις.

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

Η μετάβαση Morph ανιματοποιεί αλλαγές μεταξύ αντικειμένων σε διαδοχικές διαφάνειες. Για να δημιουργήσετε ένα απλό εφέ Morph, κλωνοποιήστε μια διαφάνεια, μετακινήστε ή αλλάξτε το μέγεθος ενός αντικειμένου στο κλώνο και εφαρμόστε τη μετάβαση Morph στη δεύτερη διαφάνεια. Έτσι τα αντίστοιχα αντικείμενα θα αναπαραχθούν μεταξύ των αρχικών και των τροποποιημένων καταστάσεών τους.

Το παρακάτω παράδειγμα δημιουργεί μια διαφάνεια με ορθογώνιο κείμενο, κλωνοποιεί τη διαφάνεια και αλλάζει τη θέση και το μέγεθος του ορθογωνίου στο κλώνο. Στη συνέχεια επιλέγει Morph από την απαρίθμηση [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) για τη δεύτερη διαφάνεια. Ανοίξτε το αποθηκευμένο αρχείο σε προβολέα που υποστηρίζει Morph για να δείτε το εφέ κατά τη διάρκεια μιας παρουσίασης.

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

## **Τύποι Morph Transition**

Η απαρίθμηση [TransitionMorphType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) ελέγχει πώς το Morph ταιριάζει και ανιματοποιεί το περιεχόμενο:

- [ByObject](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) αντιμετωπίζει κάθε σχήμα ως ολόκληρο αντικείμενο.
- [ByWord](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) ανιματοποιεί το κείμενο ταιριάζοντας λέξεις όπου είναι δυνατόν.
- [ByChar](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) ανιματοποιεί το κείμενο ταιριάζοντας χαρακτήρες όπου είναι δυνατόν.

Καλέστε το [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) με Morph πριν προσπελάσετε το [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/). Η τιμή παρέχει το περιβάλλον [IMorphTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/imorphtransition/), του οποίου η μέθοδος [set_MorphType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/imorphtransition/set_morphtype/) επιλέγει τη λειτουργία αντιστοίχισης.

Αυτό το παράδειγμα ανοίγει την παρουσίαση που δημιουργήθηκε στην προηγούμενη ενότητα και ρυθμίζει τη δεύτερη διαφάνεια να χρησιμοποιεί Morph βάσει λέξεων.

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

## **Ορισμός εφέ μετάβασης**

Ορισμένες μεταβάσεις εκθέτουν πρόσθετες επιλογές, όπως κατεύθυνση ή αν το εφέ ξεκινά από μαύρη οθόνη. Οι διαθέσιμες επιλογές εξαρτώνται από τον επιλεγμένο τύπο μετάβασης. Ορίστε πρώτα τον τύπο, έπειτα χρησιμοποιήστε το αντίστοιχο περιβάλλον που επιστρέφεται από το [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/).

Το παρακάτω παράδειγμα εφαρμόζει μια μετάβαση Cut στην πρώτη διαφάνεια του `input.pptx`. Καλει το [set_FromBlack](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/ioptionalblacktransition/set_fromblack/) με `true` μέσω του [IOptionalBlackTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/ioptionalblacktransition/) ώστε η μετάβαση να ξεκινά από μαύρη οθόνη.

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

## **ΣΥΝΕΧΩΣ ΕΡΩΤΗΜΑΤΑ**

**Μπορώ να ελέγξω την ταχύτητα αναπαραγωγής μιας μετάβασης διαφάνειας;**

Ναι. Προτιμήστε το [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) όταν χρειάζεστε ακριβή διάρκεια εφέ σε χιλιοστά του δευτερολέπτου. Χρησιμοποιήστε το [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) όταν αρκεί μια προ‑καθορισμένη κατηγορία [TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/): Slow, Medium ή Fast, και δεν έχει οριστεί ρητή διάρκεια. Αυτές οι ρυθμίσεις ελέγχουν το εφέ μετάβασης ανεξάρτητα από την καθυστέρηση αυτόματης προώθησης.

**Μπορώ να προσθέσω ήχο σε μια μετάβαση και να τον επαναλαμβάνω;**

Ναι. Αναθέστε ενσωματωμένο ήχο με το [set_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_sound/), καλέστε το [set_SoundMode](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_soundmode/) με StartSound από την απαρίθμηση [TransitionSoundMode](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionsoundmode/), και ενεργοποιήστε την επανάληψη με το [set_SoundLoop](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_soundloop/). Ο ήχος επαναλαμβάνεται μέχρι το επόμενο ηχητικό γεγονός στην παρουσίαση.

**Ποιος είναι ο πιο γρήγορος τρόπος για να εφαρμόσω την ίδια μετάβαση σε όλες τις διαφάνειες;**

Κάντε βρόχο μέσω της συλλογής που επιστρέφει η μέθοδος [get_Slides](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slides/) της παρουσίασης και καλέστε το [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) με την ίδια τιμή για τη μετάβαση κάθε διαφάνειας. Ορίστε τυχόν χρονοδιαγράμματα και επιλογές εφέ στο ίδιο βρόχο ώστε η συμπεριφορά να είναι ομοιόμορφη.

**Πώς μπορώ να ελέγξω ποια μετάβαση είναι αυτή τη στιγμή ορισμένη σε μια διαφάνεια;**

Καλέστε το [get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_type/) στη μετάβαση που επιστρέφεται από τη μέθοδο [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) της διαφάνειας. Επιστρέφει μια τιμή από την απαρίθμηση [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/); η τιμή None σημαίνει ότι δεν έχει εφαρμοστεί καμία μετάβαση.