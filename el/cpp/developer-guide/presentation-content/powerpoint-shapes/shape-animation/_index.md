---
title: Εφαρμογή Κινήσεων Σχημάτων σε Παρουσιάσεις Χρησιμοποιώντας C++
linktitle: Κίνηση Σχήματος
type: docs
weight: 60
url: /el/cpp/shape-animation/
keywords:
- σχήμα
- κίνηση
- εφέ
- κινούμενο σχήμα
- κινούμενο κείμενο
- προσθήκη κίνησης
- λήψη κίνησης
- εξαγωγή κίνησης
- προσθήκη εφέ
- λήψη εφέ
- εξαγωγή εφέ
- ήχος εφέ
- εφαρμογή κίνησης
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε, ελέγχετε και προσαρμόζετε τις κινήσεις σχημάτων, το χρονισμό, τους ήχους, τη συμπεριφορά μετά την κίνηση και το κινούμενο κείμενο με το Aspose.Slides για C++."
---
## **Επισκόπηση**

Για να εργάζεστε με τις μεμονωμένες συμπεριφορές μέσα σε ένα εφέ ή να επεξεργαστείτε τμήματα διαδρομής κίνησης, δείτε [Προσαρμοσμένη Κίνηση](/slides/el/cpp/custom-animation/).

Το Aspose.Slides for C++ αντιπροσωπεύει τις κινήσεις των διαφανειών ως εφέ σε μια χρονοδιάγραμμα διαφάνειας. Ένα εφέ έχει ένα σχήμα-στόχο, έναν τύπο και υποτύπο κίνησης, ένα trigger, ρυθμίσεις χρονισμού και προαιρετικές ιδιότητες όπως ήχος ή συμπεριφορά μετά την κίνηση.

Η χρονοδιάγραμμα περιέχει δύο είδη ακολουθιών:

- Η **κύρια ακολουθία** παίζει καθώς η διαφάνεια προχωρά.
- Μια **διαδραστική ακολουθία** ξεκινά όταν το σχήμα-ενεργοποιητής της κάνει κλικ.

Επειδή τα πλαίσια κειμένου, οι εικόνες, τα διαγράμματα, οι πίνακες και άλλα αντικείμενα διαφάνειας υλοποιούν το [IShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/), χρησιμοποιείτε την ίδια μέθοδο [ISequence::AddEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/isequence/addeffect/) για το μεγαλύτερο μέρος του περιεχομένου της διαφάνειας. Τα διαθέσιμα εφέ αναφέρονται στην απαρίθμηση [EffectType](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/effecttype/).

## **Προσθήκη Κινήσεων Σχημάτων**

Για να προσθέσετε μια κίνηση, λάβετε την κύρια ακολουθία της διαφάνειας και καλέστε το [ISequence::AddEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/isequence/addeffect/) με το σχήμα-στόχο, τον τύπο εφέ, τον υποτύπο και το trigger. Για ένα εφέ που ξεκινά όταν κάνετε κλικ σε άλλο σχήμα, δημιουργήστε μια διαδραστική ακολουθία του οποίου το trigger είναι αυτό το άλλο σχήμα.

Το παρακάτω παράδειγμα δημιουργεί και τους δύο τύπους κίνησης και αποθηκεύει το αποτέλεσμα στο `shape-animations.pptx`.

```cpp
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ISequenceCollection.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto targetShape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 120.0f, 100.0f, 320.0f, 80.0f);
targetShape->get_TextFrame()->set_Text(u"Click to animate this shape");

auto mainSequence = slide->get_Timeline()->get_MainSequence();
auto entranceEffect = mainSequence->AddEffect(targetShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
entranceEffect->get_Timing()->set_Duration(1.5f);

auto triggerShape = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 20.0f, 20.0f, 100.0f, 40.0f);
triggerShape->get_TextFrame()->set_Text(u"Move");

auto interactiveSequence = slide->get_Timeline()->get_InteractiveSequences()->Add(triggerShape);
interactiveSequence->AddEffect(targetShape, EffectType::PathFootball, EffectSubtype::None, EffectTriggerType::OnClick);

presentation->Save(u"shape-animations.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το trigger ελέγχει πότε ένα εφέ ξεκινά:

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/effecttriggertype/) περιμένει κλικ στην κύρια ακολουθία, ή κλικ στο σχήμα-ενεργοποιητή σε μια διαδραστική ακολουθία.
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/effecttriggertype/) ξεκινά με το προηγούμενο εφέ.
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/effecttriggertype/) ξεκινά όταν το προηγούμενο εφέ ολοκληρωθεί.

Για να κινήσετε μια εικόνα, ένα διάγραμμα ή κάποιον άλλο τύπο σχήματος, περάστε αυτό το αντικείμενο στο [ISequence::AddEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/isequence/addeffect/) αντί για `targetShape`. Για επιλογές ομαδοποίησης ειδικές για διαγράμματα, δείτε [Κινούμενα Διαγράμματα](/slides/el/cpp/animated-charts/).

## **Ανάγνωση Κινήσεων Σχημάτων**

Χρησιμοποιήστε το [ISequence::GetEffectsByShape](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/isequence/geteffectsbyshape/) όταν γνωρίζετε το σχήμα-στόχο. Για να εξετάσετε κάθε εφέ, απαριθμήστε την κύρια ακολουθία και κάθε διαδραστική ακολουθία. Η απαρίθμηση αποφεύγει την υπόθεση ότι μια ακολουθία περιέχει εφέ στη θέση `0`.

Το παρακάτω παράδειγμα δημιουργεί ένα σχήμα με εφέ κύριας ακολουθίας και διαδραστικά εφέ, παίρνει τα εφέ που στοχεύουν το σχήμα, και στη συνέχεια απαριθμεί κάθε ακολουθία στη διαφάνεια.

```cpp
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ISequenceCollection.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;

auto printSequence = [](const String& label, const SharedPtr<ISequence>& sequence)
{
    Console::WriteLine(String::Format(u"  {0}: {1} effect(s)", label, sequence->get_Count()));

    for (const auto& effect : sequence)
    {
        auto targetName = effect->get_TargetShape() == nullptr ? u"unknown" : effect->get_TargetShape()->get_Name();
        auto effectDescription = String::Format(u"{0} {1}; target: {2}; trigger: {3}", effect->get_Type(), effect->get_Subtype(), targetName, effect->get_Timing()->get_TriggerType());
        Console::WriteLine(u"    " + effectDescription);
    }
};

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto targetShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 120.0f, 100.0f, 320.0f, 80.0f);
targetShape->get_TextFrame()->set_Text(u"Animated shape");

auto mainSequence = slide->get_Timeline()->get_MainSequence();
mainSequence->AddEffect(targetShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

auto triggerShape = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 20.0f, 20.0f, 100.0f, 40.0f);
triggerShape->get_TextFrame()->set_Text(u"Move");

auto interactiveSequence = slide->get_Timeline()->get_InteractiveSequences()->Add(triggerShape);
interactiveSequence->AddEffect(targetShape, EffectType::PathFootball, EffectSubtype::None, EffectTriggerType::OnClick);

auto targetEffects = mainSequence->GetEffectsByShape(targetShape);
Console::WriteLine(String::Format(u"The main sequence contains {0} effect(s) for {1}.", targetEffects->get_Length(), targetShape->get_Name()));

printSequence(u"Main sequence", mainSequence);

int32_t interactiveIndex = 1;
for (const auto& sequence : slide->get_Timeline()->get_InteractiveSequences())
{
    auto triggerName = sequence->get_TriggerShape() == nullptr ? u"unknown" : sequence->get_TriggerShape()->get_Name();
    auto sequenceLabel = String::Format(u"Interactive sequence {0}, trigger: {1}", interactiveIndex, triggerName);
    printSequence(sequenceLabel, sequence);
    interactiveIndex++;
}

presentation->Dispose();
```

Αν χρειάζεστε τα εφέ μόνο για ένα σχήμα, πρώτα αναγνωρίστε το σχήμα με το όνομα, τον τύπο placeholder ή άλλη σταθερή ιδιότητα· στη συνέχεια καλέστε το [ISequence::GetEffectsByShape](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/isequence/geteffectsbyshape/). Μην υποθέτετε ότι το [IShapeCollection::idx_get](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishapecollection/idx_get/) στη θέση `0` είναι πάντα το επιθυμητό αντικείμενο.

## **Εργασία με Κληρονόμενα Εφέ Placeholder**

Ένα placeholder σε μια κανονική διαφάνεια μπορεί να κληρονομήσει τη συμπεριφορά κίνησης από το αντίστοιχο placeholder στη διαφάνεια διάταξης και στην κύρια διαφάνεια. Το [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/getbaseplaceholder/) επιστρέφει αυτό το γονικό placeholder ή `nullptr` όταν δεν υπάρχει γονέας.

Στην παρακάτω παρουσίαση παραδείγματος, το υποσέλιδο έχει **Random Bars** στη κανονική διαφάνεια, **Split** στη διαφάνεια διάταξης, και **Fly In** στην κύρια διαφάνεια.

![Εφέ κίνησης υποσέλιδου στη κανονική διαφάνεια](slide-shape-animation.png)

![Εφέ κίνησης placeholder υποσέλιδου στη διαφάνεια διάταξης](layout-shape-animation.png)

![Εφέ κίνησης placeholder υποσέλιδου στην κύρια διαφάνεια](master-shape-animation.png)

Το επόμενο παράδειγμα δημιουργεί την ιεραρχία του placeholder. Προσθέτει εφέ σε ένα master placeholder, ένα layout placeholder και το αντίστοιχο placeholder σε μια κανονική διαφάνεια. Κάθε κλήση στο [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/getbaseplaceholder/) ελέγχεται πριν χρησιμοποιηθεί το επιστραφέν σχήμα.

```cpp
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutPlaceholderManager.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto findPlaceholderWithBase = [](const SharedPtr<ISlide>& slide) -> SharedPtr<IShape>
{
    for (const auto& shape : slide->get_Shapes())
    {
        if (shape->GetBasePlaceholder() != nullptr)
            return shape;
    }

    return nullptr;
};

auto printEffects = [](const String& source, const ArrayPtr<SharedPtr<IEffect>>& effects)
{
    Console::WriteLine(String::Format(u"{0}: {1} effect(s)", source, effects->get_Length()));

    for (const auto& effect : effects)
        Console::WriteLine(String::Format(u"  {0} {1}", effect->get_Type(), effect->get_Subtype()));
};

auto presentation = MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto layoutPlaceholder = layoutSlide->get_PlaceholderManager()->AddTextPlaceholder(100.0f, 100.0f, 400.0f, 80.0f);
layoutSlide->get_Timeline()->get_MainSequence()->AddEffect(layoutPlaceholder, EffectType::Split, EffectSubtype::VerticalIn, EffectTriggerType::OnClick);

auto masterPlaceholder = layoutPlaceholder->GetBasePlaceholder();
if (masterPlaceholder != nullptr)
{
    auto masterSequence = layoutSlide->get_MasterSlide()->get_Timeline()->get_MainSequence();
    masterSequence->AddEffect(masterPlaceholder, EffectType::Fly, EffectSubtype::Bottom, EffectTriggerType::OnClick);
}

auto slide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto slidePlaceholder = findPlaceholderWithBase(slide);

if (slidePlaceholder == nullptr)
    throw InvalidOperationException(u"The slide does not contain a placeholder linked to its layout slide.");

slide->get_Timeline()->get_MainSequence()->AddEffect(slidePlaceholder, EffectType::RandomBars, EffectSubtype::Horizontal, EffectTriggerType::OnClick);
printEffects(u"Normal slide", slide->get_Timeline()->get_MainSequence()->GetEffectsByShape(slidePlaceholder));

auto baseLayoutPlaceholder = slidePlaceholder->GetBasePlaceholder();
if (baseLayoutPlaceholder != nullptr)
{
    printEffects(u"Layout slide", layoutSlide->get_Timeline()->get_MainSequence()->GetEffectsByShape(baseLayoutPlaceholder));

    auto baseMasterPlaceholder = baseLayoutPlaceholder->GetBasePlaceholder();
    if (baseMasterPlaceholder != nullptr)
        printEffects(u"Master slide", layoutSlide->get_MasterSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(baseMasterPlaceholder));
}

presentation->Save(u"placeholder-animations.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Αλλαγή Χρονισμού Κίνησης**

Ο διάλογος **Timing** του PowerPoint αντιστοιχεί στις μεθόδους του [ITiming](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/itiming/).

![Διάλογος Timing του PowerPoint για ένα εφέ κίνησης](shape-animation.png)

- **Start** αντιστοιχεί στο [ITiming::set_TriggerType](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/itiming/set_triggertype/).
- **Duration** αντιστοιχεί στο [ITiming::set_Duration](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/itiming/set_duration/), σε δευτερόλεπτα.
- **Delay** αντιστοιχεί στο [ITiming::set_TriggerDelayTime](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/itiming/set_triggerdelaytime/), σε δευτερόλεπτα.
- **Repeat** αντιστοιχεί στο [ITiming::set_RepeatCount](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/itiming/set_repeatcount/), [ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/), ή [ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/).
- **Rewind when done playing** αντιστοιχεί στο [ITiming::set_Rewind](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/itiming/set_rewind/).

Αυτό το ανεξάρτητο παράδειγμα προσθέτει ένα εφέ, αλλάζει το χρονισμό του μέσω του αντικειμένου που επιστρέφει το [ISequence::AddEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/isequence/addeffect/), και αποθηκεύει το αποτέλεσμα. Η διατήρηση της επιστρεφόμενης αναφοράς [IEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/ieffect/) αποτρέπει έναν περιττό δείκτη συλλογής.

```cpp
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 120.0f, 100.0f, 320.0f, 80.0f);
shape->get_TextFrame()->set_Text(u"Timed animation");

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Timing()->set_TriggerType(EffectTriggerType::OnClick);
effect->get_Timing()->set_Duration(2.0f);
effect->get_Timing()->set_TriggerDelayTime(0.5f);
effect->get_Timing()->set_RepeatUntilNextClick(false);
effect->get_Timing()->set_RepeatUntilEndSlide(false);
effect->get_Timing()->set_RepeatCount(2.0f);
effect->get_Timing()->set_Rewind(true);

presentation->Save(u"shape-animation-timing.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Χρησιμοποιήστε έναν τρόπο επανάληψης σκόπιμα. Ο συνδυασμός μετρήτη επανάληψης με μια σημαία "until" μπορεί να παράγει συγκεχυμένα αποτελέσματα σε διαφορετικούς προβολείς. Όταν αλλάζετε τρόπους επανάληψης, καλέστε το [ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/) και το [ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/) πριν το [ITiming::set_RepeatCount](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/itiming/set_repeatcount/), επειδή η ρύθμιση οποιουδήποτε από τα δύο σημαίες αλλάζει επίσης τη δραστήρια λειτουργία επανάληψης.

## **Προσθήκη και Εξαγωγή Ήχων Κίνησης**

Ένα εφέ κίνησης μπορεί να αναφέρει ενσωματωμένο ήχο μέσω του [IEffect::set_Sound](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/ieffect/set_sound/). Το [IEffect::set_StopPreviousSound](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/ieffect/set_stopprevioussound/) υποδεικνύει σε ένα εφέ να σταματήσει τον ήχο που ξεκίνησε ένα προηγούμενο εφέ.

### **Προσθήκη Ήχου σε Ένα Εφέ**

Το παρακάτω παράδειγμα αναμένει ένα τοπικό αρχείο ήχου με όνομα `animation-sound.wav`. Δημιουργεί δύο εφέ, ενσωματώνει αυτό το αρχείο ως ήχο για το πρώτο εφέ, και ρυθμίζει το δεύτερο εφέ να σταματά τον ήχο. Χρησιμοποιεί τα αντικείμενα που επιστρέφει το [ISequence::AddEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/isequence/addeffect/), επομένως δεν απαιτείται δείκτης ακολουθίας.

```cpp
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudio.h>
#include <DOM/IAudioCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto firstShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80.0f, 100.0f, 240.0f, 80.0f);
auto secondShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 400.0f, 100.0f, 240.0f, 80.0f);
firstShape->get_TextFrame()->set_Text(u"Starts sound");
secondShape->get_TextFrame()->set_Text(u"Stops sound");

auto sequence = slide->get_Timeline()->get_MainSequence();
auto firstEffect = sequence->AddEffect(firstShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
auto secondEffect = sequence->AddEffect(secondShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

auto audioData = File::ReadAllBytes(u"animation-sound.wav");
auto effectSound = presentation->get_Audios()->AddAudio(audioData);
firstEffect->set_Sound(effectSound);
secondEffect->set_StopPreviousSound(true);

presentation->Save(u"shape-animation-sound.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Εξαγωγή Ενσωματωμένων Ήχων Εφέ**

Το παρακάτω παράδειγμα αναμένει μια τοπική παρουσίαση με όνομα `presentation-with-animation-sounds.pptx`. Σαρώνει τόσο τις κύριες όσο και τις διαδραστικές ακολουθίες και γράφει κάθε ενσωματωμένο ήχο εφέ στο φάκελο `extracted-animation-sounds`. Η επέκταση επιλέγεται από το MIME type ήχου που εκτίθεται από το [IAudio::get_ContentType](https://reference.aspose.com/slides/el/cpp/aspose.slides/iaudio/get_contenttype/).

```cpp
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ISequenceCollection.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudio.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/directory.h>
#include <system/io/file.h>
#include <system/io/path.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;
using namespace System::IO;

auto getAudioExtension = [](const String& contentType)
{
    auto normalizedType = String::IsNullOrEmpty(contentType) ? String::Empty : contentType.ToLowerInvariant();

    if (normalizedType == u"audio/mpeg")
        return String(u".mp3");

    if (normalizedType == u"audio/mp4")
        return String(u".m4a");

    if (normalizedType == u"audio/ogg")
        return String(u".ogg");

    if (normalizedType == u"audio/wav" || normalizedType == u"audio/x-wav")
        return String(u".wav");

    return String(u".bin");
};

auto saveSounds = [&getAudioExtension](const SharedPtr<ISequence>& sequence, const String& outputDirectory, int32_t& soundIndex)
{
    for (const auto& effect : sequence)
    {
        if (effect->get_Sound() == nullptr)
            continue;

        auto extension = getAudioExtension(effect->get_Sound()->get_ContentType());
        auto outputPath = Path::Combine(outputDirectory, String::Format(u"effect-sound-{0}{1}", soundIndex, extension));
        File::WriteAllBytes(outputPath, effect->get_Sound()->get_BinaryData());
        soundIndex++;
    }
};

auto inputPath = String(u"presentation-with-animation-sounds.pptx");
auto outputDirectory = String(u"extracted-animation-sounds");

Directory::CreateDirectory_(outputDirectory);

auto presentation = MakeObject<Presentation>(inputPath);
int32_t soundIndex = 1;

for (const auto& slide : presentation->get_Slides())
{
    saveSounds(slide->get_Timeline()->get_MainSequence(), outputDirectory, soundIndex);

    for (const auto& sequence : slide->get_Timeline()->get_InteractiveSequences())
        saveSounds(sequence, outputDirectory, soundIndex);
}

Console::WriteLine(String::Format(u"Extracted {0} sound file(s) to {1}.", soundIndex - 1, Path::GetFullPath(outputDirectory)));
presentation->Dispose();
```

Για μεγάλα αντικείμενα ήχου, χρησιμοποιήστε το [IAudio::GetStream](https://reference.aspose.com/slides/el/cpp/aspose.slides/iaudio/getstream/) και αντιγράψτε τη ροή σε ένα αρχείο αντί να φορτώσετε ολόκληρο το αντικείμενο σε έναν πίνακα byte.

## **Ορισμός Συμπεριφοράς Μετά την Κίνηση**

Η επιλογή **After animation** ελέγχει τι συμβαίνει με ένα σχήμα μετά το τέλος του εφέ.

![Διάλογος Επιλογών Εφέ του PowerPoint που δείχνει τις ρυθμίσεις After animation](shape-after-animation.png)

Η απαρίθμηση [AfterAnimationType](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/afteranimationtype/) υποστηρίζει τη διατήρηση του σχήματος αμετάβλητου, την αλλαγή του χρώματος, την απόκρυψή του μετά την κίνηση, ή την απόκρυψή του στο επόμενο κλικ. Όταν ο τύπος είναι [AfterAnimationType::Color](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/afteranimationtype/), καλέστε το [IEffect::get_AfterAnimationColor](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/ieffect/get_afteranimationcolor/) για να ορίσετε και το χρώμα.

Αυτό το ανεξάρτητο παράδειγμα δημιουργεί ένα εφέ, ορίζει τη συμπεριφορά μετά την κίνηση μέσω του επιστρεφόμενου αντικειμένου εφέ, και αποθηκεύει το αποτέλεσμα.

```cpp
#include <DOM/Animation/AfterAnimationType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 120.0f, 100.0f, 320.0f, 80.0f);
shape->get_TextFrame()->set_Text(u"Dim after animation");

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
effect->set_AfterAnimationType(AfterAnimationType::Color);
effect->get_AfterAnimationColor()->set_Color(Color::get_LightGray());

presentation->Save(u"shape-animation-after-effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Αλλαγή του τύπου από το [AfterAnimationType::Color](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/afteranimationtype/) αφαιρεί τη ρύθμιση χρώματος μετά την κίνηση.

## **Κίνηση Κειμένου**

Η κίνηση κειμένου έχει δύο σχετικούς ελέγχους:

- Το [ITextAnimation::set_BuildType](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/itextanimation/set_buildtype/) ελέγχει αν οι παράγραφοι εμφανίζονται μαζί ή ανά επίπεδο παραγράφου.
- Το [IEffect::set_AnimateTextType](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) ελέγχει αν το κείμενο εμφανίζεται όλο ταυτόχρονα, ανά λέξη ή ανά γράμμα. Το [IEffect::set_DelayBetweenTextParts](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) ορίζει την καθυστέρηση μεταξύ λέξεων ή γραμμάτων. Μία θετική τιμή είναι ποσοστό της διάρκειας του εφέ· μία αρνητική τιμή είναι καθυστέρηση σε δευτερόλεπτα.

Το παρακάτω ανεξάρτητο παράδειγμα κινεί τις λέξεις σε ένα πλαίσιο κειμένου. Το [BuildType::AsOneObject](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/buildtype/) απενεργοποιεί την κατασκευή παράγραφος‑ανά‑παράγραφο έτσι ώστε η ρύθμιση λέξης να ισχύει για ολόκληρο το πλαίσιο κειμένου.

```cpp
#include <DOM/Animation/AnimateTextType.h>
#include <DOM/Animation/BuildType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITextAnimation.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80.0f, 80.0f, 560.0f, 100.0f);
textBox->get_TextFrame()->set_Text(u"Aspose.Slides animates this sentence word by word.");

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(textBox, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);
effect->set_AnimateTextType(AnimateTextType::ByWord);
effect->set_DelayBetweenTextParts(20.0f);

presentation->Save(u"animated-text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Για να κατασκευάσετε ένα πλαίσιο κειμένου ανά παράγραφο, χρησιμοποιήστε το [ITextAnimation::set_BuildType](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/itextanimation/set_buildtype/) με το [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/buildtype/) ή άλλο επίπεδο παραγράφου. Για να στοχεύσετε μια μοναδική παράγραφο με δικό της εφέ, χρησιμοποιήστε την υπερφόρτωση του [ISequence::AddEffect](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/isequence/addeffect/) που δέχεται ένα [IParagraph](https://reference.aspose.com/slides/el/cpp/aspose.slides/iparagraph/). Δείτε το [Animated Text](/slides/el/cpp/animated-text/) για παραδείγματα επιπέδου παραγράφου.

## **Σημειώσεις Εξαγωγής και Συμβατότητας**

- Η αποθήκευση σε PPT ή PPTX διατηρεί το μοντέλο κίνησης, αλλά η τελική αναπαραγωγή ελέγχεται από τον προβολέα παρουσίασης.
- Τα PDF και οι στατικές εικόνες δεν αναπαράγουν κινήσεις. Χρησιμοποιήστε [HTML5 export](/slides/el/cpp/export-to-html5/), κινούμενο GIF, ή [video conversion](/slides/el/cpp/convert-powerpoint-to-video/) όταν η έξοδος πρέπει να δείχνει κίνηση.
- Για HTML5, ενεργοποιήστε το [Html5Options::set_AnimateShapes](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/html5options/set_animateshapes/) και, όταν χρειάζεται, το [Html5Options::set_AnimateTransitions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/html5options/set_animatetransitions/).
- Η απόδοση βίντεο υποστηρίζει πολλά κοινά εφέ εισόδου, έμφασης, εξόδου και διαδρομής κίνησης, αλλά δεν υποστηρίζονται όλα τα εφέ του PowerPoint. Ελέγξτε τις τρέχουσες [supported animations and effects](/slides/el/cpp/convert-powerpoint-to-video/#supported-animations-and-effects) και δοκιμάστε κρίσιμες παρουσιάσεις με την έκδοση Aspose.Slides που στοχεύετε.
- Τα προηγμένα προσαρμοσμένα εφέ και τα εφέ που εισάγονται από άλλες μορφές παρουσίασης μπορεί να διατηρηθούν στο αρχείο αλλά να αποδίδονται διαφορετικά στο PowerPoint, HTML5 ή βίντεο. Επικυρώστε το εξαγόμενο αποτέλεσμα αντί να βασίζεστε μόνο στο όνομα του εφέ.

## **Συχνές Ερωτήσεις**

**Γιατί εμφανίζεται μια κίνηση στο PowerPoint αλλά όχι σε PDF;**

Το PDF είναι στατική μορφή, επομένως οι κινήσεις και οι μεταβάσεις διαφάνειας δεν αναπαράγονται. Εξάγετε σε HTML5, κινούμενο GIF ή βίντεο όταν πρέπει να διατηρηθεί η κίνηση.

**Γιατί ένα εφέ αναπαράγεται διαφορετικά σε βίντεο;**

Η εξαγωγή βίντεο αποδίδει τις κινήσεις αντί να αποθηκεύει τη συμπεριφορά του αρχικού PowerPoint. Μερικά προηγμένα εφέ δεν υποστηρίζονται ή προσεγγίζονται. Εξετάστε τον πίνακα υποστηριζόμενων εφέ και δοκιμάστε την πραγματική παρουσίαση πριν τη χρήση στην παραγωγή.

**Αλλάζει η μετακίνηση ενός σχήματος προς τα εμπρός ή πίσω τη σειρά των κινήσεων;**

Όχι. Η σειρά z-order του σχήματος ελέγχει την επικάλυψη, ενώ η σειρά της ακολουθίας και τα triggers ελέγχουν την αναπαραγωγή των κινήσεων. Αλλάξτε τη χρονοδιάγραμμα εάν χρειάζεστε διαφορετική σειρά αναπαραγωγής.