---
title: Μετατροπή παρουσιάσεων PowerPoint σε βίντεο με C++
linktitle: PowerPoint σε βίντεο
type: docs
weight: 130
url: /el/cpp/convert-powerpoint-to-video/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- μετατροπή PPT
- μετατροπή PPTX
- PowerPoint σε βίντεο
- παρουσίαση σε βίντεο
- PPT σε βίντεο
- PPTX σε βίντεο
- PowerPoint σε MP4
- παρουσίαση σε MP4
- PPT σε MP4
- PPTX σε MP4
- αποθήκευση PPT ως MP4
- αποθήκευση PPTX ως MP4
- εξαγωγή PPT σε MP4
- εξαγωγή PPTX σε MP4
- μετατροπή βίντεο
- PowerPoint
- C++
- Aspose.Slides
description: "Μάθετε πώς να μετατρέψετε παρουσιάσεις PowerPoint σε βίντεο με C++. Ανακαλύψτε δείγμα κώδικα και τεχνικές αυτοματοποίησης για να βελτιώσετε τη ροή εργασίας σας."
---
## **Εισαγωγή**

Με τη μετατροπή της παρουσίασης PowerPoint σας σε βίντεο, έχετε 

* **Αύξηση προσβασιμότητας:** Όλες οι συσκευές (ανεξάρτητα από την πλατφόρμα) διαθέτουν προεγκατεστημένους αναπαραγωγείς βίντεο συγκριτικά με τις εφαρμογές άνοιγμα παρουσίασης, έτσι οι χρήστες βρίσκουν πιο εύκολο το άνοιγμα ή την αναπαραγωγή βίντεο.
* **Μεγαλύτερο εύρος:** Μέσω βίντεο μπορείτε να προσεγγίσετε μεγάλο κοινό και να του παρέχετε πληροφορίες που διαφορετικά θα μπορούσαν να φανούν βαρετές σε μια παρουσίαση. Οι περισσότερες έρευνες και στατιστικά δείχνουν ότι οι άνθρωποι παρακολουθούν και καταναλώνουν βίντεο περισσότερο από άλλα είδη περιεχομένου, και γενικά προτιμούν τέτοιο περιεχόμενο.

Στο [Aspose.Slides 22.11](https://docs.aspose.com/slides/el/cpp/aspose-slides-for-cpp-22-11-release-notes/), εφαρμόσαμε υποστήριξη για μετατροπή παρουσίασης σε βίντεο. 

* Χρησιμοποιήστε το Aspose.Slides για να δημιουργήσετε ένα σύνολο καρέ (από τις διαφάνειες της παρουσίασης) που αντιστοιχούν σε ένα συγκεκριμένο FPS (καρέ ανά δευτερόλεπτο)
* Χρησιμοποιήστε ένα εξωτερικό εργαλείο όπως το `ffmpeg` για να δημιουργήσετε ένα βίντεο βασισμένο στα καρέ.

## **Μετατροπή παρουσίασης PowerPoint σε βίντεο**

1. Κατεβάστε το ffmpeg[εδώ](https://ffmpeg.org/download.html).
2. Προσθέστε τη διαδρομή του `ffmpeg.exe` στη μεταβλητή περιβάλλοντος `PATH`.
3. Εκτελέστε τον κώδικα μετατροπής PowerPoint σε βίντεο.

Αυτός ο κώδικας C++ δείχνει πώς να μετατρέψετε μια παρουσίαση (που περιέχει ένα σχήμα και δύο εφέ κίνησης) σε βίντεο:

```c++
#include <DOM/Animation/EffectPresetClassType.h>
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
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/FramesStream/FrameTickEventArgs.h>
#include <Export/FramesStream/PresentationAnimationsGenerator.h>
#include <Export/FramesStream/PresentationPlayer.h>
#include <IImage.h>
#include <system/diagnostics/process.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

void OnFrameTick(System::SharedPtr<PresentationPlayer> sender, System::SharedPtr<FrameTickEventArgs> args)
{
    System::String fileName = System::String::Format(u"frame_{0}.png", sender->get_FrameIndex());
    args->GetFrame()->Save(fileName);
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Προσθέτει ένα σχήμα χαμόγελο και στη συνέχεια το ανιματοποιεί
    System::SharedPtr<IAutoShape> smile = slide->get_Shapes()->AddAutoShape(ShapeType::SmileyFace, 110.0f, 20.0f, 500.0f, 500.0f);
    auto sequence = slide->get_Timeline()->get_MainSequence();
    System::SharedPtr<IEffect> effectIn = sequence->AddEffect(smile, EffectType::Fly, EffectSubtype::TopLeft, EffectTriggerType::AfterPrevious);
    System::SharedPtr<IEffect> effectOut = sequence->AddEffect(smile, EffectType::Fly, EffectSubtype::BottomRight, EffectTriggerType::AfterPrevious);
    effectIn->get_Timing()->set_Duration(2.0f);
    effectOut->set_PresetClassType(EffectPresetClassType::Exit);

    const int32_t fps = 33;

    auto animationsGenerator = System::MakeObject<PresentationAnimationsGenerator>(presentation);
    auto player = System::MakeObject<PresentationPlayer>(animationsGenerator, fps);
    player->FrameTick += OnFrameTick;
    animationsGenerator->Run(presentation->get_Slides());

    const System::String ffmpegParameters = System::String::Format(
        u"-loglevel {0} -framerate {1} -i {2} -y -c:v {3} -pix_fmt {4} {5}",
        u"warning", fps, u"frame_%d.png", u"libx264", u"yuv420p", u"video.mp4");
    auto ffmpegProcess = System::Diagnostics::Process::Start(u"ffmpeg", ffmpegParameters);
    ffmpegProcess->WaitForExit();
}
```

## **Εφέ βίντεο**

Μπορείτε να εφαρμόσετε κινήσεις σε αντικείμενα στις διαφάνειες και να χρησιμοποιήσετε μεταβάσεις μεταξύ των διαφανειών.

{{% alert color="info" %}} 

Μπορεί να θέλετε να δείτε αυτά τα άρθρα: [PowerPoint Animation](https://docs.aspose.com/slides/el/cpp/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/el/cpp/shape-animation/), και [Shape Effect](https://docs.aspose.com/slides/el/cpp/shape-effect/).

{{% /alert %}} 

Οι κινήσεις και οι μεταβάσεις κάνουν τις παρουσιάσεις πιο ελκυστικές και ενδιαφέρουσες—και το ίδιο ισχύει για τα βίντεο. Ας προσθέσουμε μια ακόμα διαφάνεια και μετάβαση στον κώδικα της προηγούμενης παρουσίασης:

```c++
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/Presentation.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::SlideShow;

// Προσθέτει ένα σχήμα χαμόγελο και το ανιματοποιεί όπως φαίνεται παραπάνω
auto presentation = System::MakeObject<Presentation>();

// Προσθέτει μια νέα διαφάνεια και κίνηση μετάβασης

System::SharedPtr<ISlide> newSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_Slide(0)->get_LayoutSlide());

System::SharedPtr<IBackground> slideBackground = newSlide->get_Background();

slideBackground->set_Type(BackgroundType::OwnBackground);

auto fillFormat = slideBackground->get_FillFormat();

fillFormat->set_FillType(FillType::Solid);

fillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Indigo());

newSlide->get_SlideShowTransition()->set_Type(TransitionType::Push);
```

Το Aspose.Slides υποστηρίζει επίσης κίνηση κειμένου. Έτσι κινούμε παραγράφους σε αντικείμενα, που θα εμφανίζονται μία μετά την άλλη (με καθυστέρηση ενός δευτερολέπτου):

```c++
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/FramesStream/FrameTickEventArgs.h>
#include <Export/FramesStream/PresentationAnimationsGenerator.h>
#include <Export/FramesStream/PresentationPlayer.h>
#include <IImage.h>
#include <system/diagnostics/process.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

void OnFrameTick(System::SharedPtr<PresentationPlayer> sender, System::SharedPtr<FrameTickEventArgs> args)
{
    System::String fileName = System::String::Format(u"frame_{0}.png", sender->get_FrameIndex());
    args->GetFrame()->Save(fileName);
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Προσθέτει κείμενο και κινούμενα εφέ
    System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210.0f, 120.0f, 300.0f, 300.0f);
    System::SharedPtr<Paragraph> para1 = System::MakeObject<Paragraph>();
    para1->get_Portions()->Add(System::MakeObject<Portion>(u"Aspose Slides for C++"));
    System::SharedPtr<Paragraph> para2 = System::MakeObject<Paragraph>();
    para2->get_Portions()->Add(System::MakeObject<Portion>(u"convert PowerPoint Presentation with text to video"));

    System::SharedPtr<Paragraph> para3 = System::MakeObject<Paragraph>();
    para3->get_Portions()->Add(System::MakeObject<Portion>(u"paragraph by paragraph"));
    auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
    paragraphs->Add(para1);
    paragraphs->Add(para2);
    paragraphs->Add(para3);
    paragraphs->Add(System::MakeObject<Paragraph>());

    auto sequence = slide->get_Timeline()->get_MainSequence();
    System::SharedPtr<IEffect> effect = sequence->AddEffect(para1, EffectType::Appear, EffectSubtype::None, EffectTriggerType::AfterPrevious);

    System::SharedPtr<IEffect> effect2 = sequence->AddEffect(para2, EffectType::Appear, EffectSubtype::None, EffectTriggerType::AfterPrevious);

    System::SharedPtr<IEffect> effect3 = sequence->AddEffect(para3, EffectType::Appear, EffectSubtype::None, EffectTriggerType::AfterPrevious);

    System::SharedPtr<IEffect> effect4 = sequence->AddEffect(para3, EffectType::Appear, EffectSubtype::None, EffectTriggerType::AfterPrevious);

    effect->get_Timing()->set_TriggerDelayTime(1.0f);
    effect2->get_Timing()->set_TriggerDelayTime(1.0f);
    effect3->get_Timing()->set_TriggerDelayTime(1.0f);
    effect4->get_Timing()->set_TriggerDelayTime(1.0f);

    // Μετατρέπει τα καρέ σε βίντεο
    const int32_t fps = 33;

    auto animationsGenerator = System::MakeObject<PresentationAnimationsGenerator>(presentation);
    auto player = System::MakeObject<PresentationPlayer>(animationsGenerator, fps);

    player->FrameTick += OnFrameTick;
    animationsGenerator->Run(presentation->get_Slides());

    const System::String ffmpegParameters = System::String::Format(
        u"-loglevel {0} -framerate {1} -i {2} -y -c:v {3} -pix_fmt {4} {5}",
        u"warning", fps, u"frame_%d.png", u"libx264", u"yuv420p", u"video.mp4");
    auto ffmpegProcess = System::Diagnostics::Process::Start(u"ffmpeg", ffmpegParameters);
    ffmpegProcess->WaitForExit();
}
```

## **Κλάσεις μετατροπής βίντεο**

Για να μπορείτε να εκτελείτε εργασίες μετατροπής PowerPoint σε βίντεο, το Aspose.Slides παρέχει τις κλάσεις [PresentationAnimationsGenerator](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.export.presentation_animations_generator/) και [PresentationPlayer](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.export.presentation_player/).

Η PresentationAnimationsGenerator σας επιτρέπει να ορίσετε το μέγεθος του καρέ για το βίντεο (που θα δημιουργηθεί αργότερα) μέσω του κατασκευαστή της. Αν περάσετε μια παρουσίαση, θα χρησιμοποιηθεί το `Presentation.SlideSize` και θα παραχθούν κινήσεις που χρησιμοποιεί η PresentationPlayer. 

Όταν δημιουργηθούν οι κινήσεις, ένα συμβάν `NewAnimation` δημιουργείται για κάθε επόμενη κίνηση, το οποίο διαθέτει την παράμετρο [IPresentationAnimationPlayer](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.export.i_presentation_animation_player/). Η τελευταία είναι μια κλάση που αντιπροσωπεύει έναν παίκτη για μια ξεχωριστή κίνηση.

Για εργασία με [IPresentationAnimationPlayer](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.export.i_presentation_animation_player/), χρησιμοποιούνται η ιδιότητα [get_Duration](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.export.i_presentation_animation_player#a29881d28eb42f345ab130d52f05a2d91) (η συνολική διάρκεια της κίνησης) και η μέθοδος [SetTimePosition](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.export.i_presentation_animation_player#a29cb11a73e3ad5f645626fcee3bc4ea0). Κάθε θέση κίνησης ορίζεται εντός του εύρους *0 έως διάρκεια*, και στη συνέχεια η μέθοδος `GetFrame` επιστρέφει ένα Bitmap που αντιστοιχεί στην κατάσταση της κίνησης εκείνη τη στιγμή.

```c++
#include <DOM/Animation/EffectPresetClassType.h>
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
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/FramesStream/IPresentationAnimationPlayer.h>
#include <Export/FramesStream/PresentationAnimationsGenerator.h>
#include <IImage.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

void OnNewAnimation(System::SharedPtr<IPresentationAnimationPlayer> animationPlayer)
{
    System::Console::WriteLine(u"Total animation duration: {0}", animationPlayer->get_Duration());

    animationPlayer->SetTimePosition(0);
    // αρχική κατάσταση κίνησης
    System::SharedPtr<IImage> image = animationPlayer->GetFrame();
    // bitmap της αρχικής κατάστασης κίνησης

    animationPlayer->SetTimePosition(animationPlayer->get_Duration());
    // τελική κατάσταση της κίνησης
    System::SharedPtr<IImage> lastImage = animationPlayer->GetFrame();
    // τελευταίο καρέ της κίνησης
    lastImage->Save(u"last.png");
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Προσθέτει ένα σχήμα χαμόγελο και το ανιματοποιεί
    System::SharedPtr<IAutoShape> smile = slide->get_Shapes()->AddAutoShape(ShapeType::SmileyFace, 110.0f, 20.0f, 500.0f, 500.0f);
    auto sequence = slide->get_Timeline()->get_MainSequence();
    System::SharedPtr<IEffect> effectIn = sequence->AddEffect(smile, EffectType::Fly, EffectSubtype::TopLeft, EffectTriggerType::AfterPrevious);
    System::SharedPtr<IEffect> effectOut = sequence->AddEffect(smile, EffectType::Fly, EffectSubtype::BottomRight, EffectTriggerType::AfterPrevious);
    effectIn->get_Timing()->set_Duration(2.0f);
    effectOut->set_PresetClassType(EffectPresetClassType::Exit);

    auto animationsGenerator = System::MakeObject<PresentationAnimationsGenerator>(presentation);
    animationsGenerator->NewAnimation += OnNewAnimation;
}
```

Για να παιχτούν όλες οι κινήσεις σε μια παρουσίαση ταυτόχρονα, χρησιμοποιείται η κλάση [PresentationPlayer](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.export.presentation_player/). Αυτή η κλάση λαμβάνει μια παρουσία της [PresentationAnimationsGenerator](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.export.presentation_animations_generator/) και FPS για τα εφέ στον κατασκευαστή της και στη συνέχεια καλεί το συμβάν `FrameTick` για όλες τις κινήσεις ώστε να παιχτούν:

```c++
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/FramesStream/FrameTickEventArgs.h>
#include <Export/FramesStream/PresentationAnimationsGenerator.h>
#include <Export/FramesStream/PresentationPlayer.h>
#include <IImage.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

void OnFrameTick(System::SharedPtr<PresentationPlayer> sender, System::SharedPtr<FrameTickEventArgs> args)
{
    System::String fileName = System::String::Format(u"frame_{0}.png", sender->get_FrameIndex());
    args->GetFrame()->Save(fileName);
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>(u"animated.pptx");
    auto animationsGenerator = System::MakeObject<PresentationAnimationsGenerator>(presentation);
    auto player = System::MakeObject<PresentationPlayer>(animationsGenerator, 33);

    player->FrameTick += OnFrameTick;
    animationsGenerator->Run(presentation->get_Slides());
}
```

Στη συνέχεια τα παραγόμενα καρότσια μπορούν να συναχθούν για να παραχθεί ένα βίντεο. Δείτε την ενότητα [Convert PowerPoint to Video](https://docs.aspose.com/slides/el/cpp/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Υποστηριζόμενες κίνησεις και εφέ**

**Είσοδος**:

| Τύπος κίνησης | Aspose.Slides | PowerPoint |
|---|---|---|
| **Εμφάνιση** | ![δεν υποστηρίζεται](x.png) | ![υποστηρίζεται](v.png) |
| **Ξεθώριασμα** | ![υποστηρίζεται](v.png) | ![υποστηρίζεται](v.png) |
| **Πτήση μέσα** | ![υποστηρίζεται](v.png) | ![υποστηρίζεται](v.png) |
| **Αναζωή μέσα** | ![υποστηρίζεται](v.png) | ![υποστηρίζεται](v.png) |
| **Διαίρεση** | ![υποστηρίζεται](v.png) | ![υποστηρίζεται](v.png) |
| **Σκούπισμα** | ![υποστηρίζεται](v.png) | ![υποστηρίζεται](v.png) |
| **Σχήμα** | ![υποστηρίζεται](v.png) | ![υποστηρίζεται](v.png) |
| **Τροχός** | ![υποστηρίζεται](v.png) | ![υποστηρίζεται](v.png) |
| **Τυχαίες μπάρες** | ![υποστηρίζεται](v.png) | ![υποστηρίζεται](v.png) |
| **Ανάπτυξη & Περιστροφή** | ![δεν υποστηρίζεται](x.png) | ![υποστηρίζεται](v.png) |
| **Ζουμ** | ![υποστηρίζεται](v.png) | ![υποστηρίζεται](v.png) |
| **Ανέλιξη** | ![υποστηρίζεται](v.png) | ![υποστηρίζεται](v.png) |
| **Αναπήδηση** | ![υποστηρίζεται](v.png) | ![υποστηρίζεται](v.png) |

**Έμφαση**:

| Τύπος κίνησης | Aspose.Slides | PowerPoint |
|---|---|---|
| **Παλμός** | ![δεν υποστηρίζεται](x.png) | ![υποστηρίζεται](v.png) |
| **Παλμός χρώματος** | ![δεν υποστηρίζεται](x.png) | ![υποστηρίζεται](v.png) |
| **Ταλάντωση** | ![υποστηρίζεται](v.png) | ![υποστηρίζεται](v.png) |
| **Περιστροφή** | ![υποστηρίζεται](v.png) | ![υποστηρίζεται](v.png) |
| **Ανάπτυξη/Σμίκρυνση** | ![δεν υποστηρίζεται](x.png) | ![υποστηρίζεται](v.png) |
| **Απόσυρση χρώματος** | ![δεν υποστηρίζεται](x.png) | ![υποστηρίζεται](v.png) |
| **Σκοτείνιασμα** | ![δεν υποστηρίζεται](x.png) | ![υποστηρίζεται](v.png) |
| **Φωτισμός** | ![δεν υποστηρίζεται](x.png) | ![υποστηρίζεται](v.png) |
| **Διαφάνεια** | ![δεν υποστηρίζεται](x.png) | ![υποστηρίζεται](v.png) |
| **Χρώμα αντικειμένου** | ![δεν υποστηρίζεται](x.png) | ![υποστηρίζεται](v.png) |
| **Συμπληρωματικό χρώμα** | ![δεν υποστηρίζεται](x.png) | ![υποστηρίζεται](v.png) |
| **Χρώμα γραμμής** | ![δεν υποστηρίζεται](x.png) | ![υποστηρίζεται](v.png) |
| **Χρώμα γεμίσματος** | ![δεν υποστηρίζεται](x.png) | ![υποστηρίζεται](v.png) |

**Έξοδος**:

| Τύπος κίνησης | Aspose.Slides | PowerPoint |
|---|---|---|
| **Εξαφάνιση** | ![δεν υποστηρίζεται](x.png) | ![υποστηρίζεται](v.png) |
| **Ξεθώριασμα** | ![υποστηρίζεται](v.png) | ![υποστηρίζεται](v.png) |
| **Πτήση έξω** | ![υποστηρίζεται](v.png) | ![υποστηρίζεται](v.png) |
| **Αναζωή έξω** | ![υποστηρίζεται](v.png) | ![υποστηρίζεται](v.png) |
| **Διαίρεση** | ![υποστηρίζεται](v.png) | ![υποστηρίζεται](v.png) |
| **Σκούπισμα** | ![υποστηρίζεται](v.png) | ![υποστηρίζεται](v.png) |
| **Σχήμα** | ![υποστηρίζεται](v.png) | ![υποστηρίζεται](v.png) |
| **Τυχαίες μπάρες** | ![υποστηρίζεται](v.png) | ![υποστηρίζεται](v.png) |
| **Σμίκρυνση & Περιστροφή** | ![δεν υποστηρίζεται](x.png) | ![υποστηρίζεται](v.png) |
| **Ζουμ** | ![υποστηρίζεται](v.png) | ![υποστηρίζεται](v.png) |
| **Ανέλιξη** | ![υποστηρίζεται](v.png) | ![υποστηρίζεται](v.png) |
| **Αναπήδηση** | ![υποστηρίζεται](v.png) | ![υποστηρίζεται](v.png) |

**Διαδρομές κίνησης**:

| Τύπος κίνησης | Aspose.Slides | PowerPoint |
|---|---|---|
| **Γραμμές** | ![υποστηρίζεται](v.png) | ![υποστηρίζεται](v.png) |
| **Τόξα** | ![υποστηρίζεται](v.png) | ![υποστηρίζεται](v.png) |
| **Στροφές** | ![υποστηρίζεται](v.png) | ![υποστηρίζεται](v.png) |
| **Σχήματα** | ![υποστηρίζεται](v.png) | ![υποστηρίζεται](v.png) |
| **Βρόχοι** | ![υποστηρίζεται](v.png) | ![υποστηρίζει

ται](v.png) |
| **Προσαρμοσμένη διαδρομή** | ![υποστηρίζεται](v.png) | ![υποστηρίζεται](v.png) |

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

### Είναι δυνατόν να μετατρέψετε παρουσιάσεις που είναι προστατευμένες με κωδικό;

Ναι, το Aspose.Slides επιτρέπει την εργασία με [παρουσιάσεις προστατευμένες με κωδικό](/slides/el/cpp/password-protected-presentation/). Κατά την επεξεργασία τέτοιων αρχείων, πρέπει να παρέχετε τον σωστό κωδικό ώστε η βιβλιοθήκη να έχει πρόσβαση στο περιεχόμενο της παρουσίασης.

### Υποστηρίζει το Aspose.Slides χρήση σε cloud λύσεις;

Ναι, το Aspose.Slides μπορεί να ενσωματωθεί σε cloud εφαρμογές και υπηρεσίες. Η βιβλιοθήκη έχει σχεδιαστεί για λειτουργία σε περιβάλλοντα διακομιστών, εξασφαλίζοντας υψηλή απόδοση και κλιμακωσιμότητα για ομαδική επεξεργασία αρχείων.

### Υπάρχουν περιορισμοί μεγέθους για παρουσιάσεις κατά τη μετατροπή;

Το Aspose.Slides είναι ικανό να διαχειριστεί παρουσιάσεις σχεδόν οποιουδήποτε μεγέθους. Ωστόσο, όταν εργάζεστε με πολύ μεγάλα αρχεία, μπορεί να απαιτηθούν πρόσθετοι πόροι συστήματος, και συχνά συνιστάται η βελτιστοποίηση της παρουσίασης για βελτίωση της απόδοσης.