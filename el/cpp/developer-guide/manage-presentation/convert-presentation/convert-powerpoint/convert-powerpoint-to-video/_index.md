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
description: "Μάθετε πώς να μετατρέπετε παρουσιάσεις PowerPoint σε βίντεο με C++. Ανακαλύψτε παραδείγματα κώδικα και τεχνικές αυτοματοποίησης για να βελτιστοποιήσετε τη ροή εργασίας σας."
---
## **Εισαγωγή**

Με τη μετατροπή της παρουσίασης PowerPoint σε βίντεο, λαμβάνετε  

* **Αύξηση προσβασιμότητας:** Όλες οι συσκευές (ανεξαρτήτως πλατφόρμας) είναι εξοπλισμένες από προεπιλογή με προγράμματα αναπαραγωγής βίντεο, σε αντίθεση με τις εφαρμογές άνοιγμα παρουσίασης, έτσι οι χρήστες βρίσκουν πιο εύκολο το άνοιγμα ή την αναπαραγωγή βίντεο.  
* **Μεγαλύτερη εμβέλεια:** Μέσω βίντεο, μπορείτε να προσεγγίσετε ένα μεγάλο κοινό και να του προσφέρετε πληροφορίες που θα ήταν διαφορετικά βαρετές σε μια παρουσίαση. Οι περισσότερες έρευνες και στατιστικές δείχνουν ότι οι άνθρωποι παρακολουθούν και καταναλώνουν βίντεο περισσότερο από άλλες μορφές περιεχομένου, και γενικά προτιμούν τέτοιο περιεχόμενο.  

Στο [Aspose.Slides 22.11](https://docs.aspose.com/slides/el/cpp/aspose-slides-for-cpp-22-11-release-notes/), εφαρμόσαμε υποστήριξη για μετατροπή παρουσίασης σε βίντεο.  

* Χρησιμοποιήστε Aspose.Slides για τη δημιουργία ενός συνόλου καρέ (από τις διαφάνειες της παρουσίασης) που αντιστοιχούν σε συγκεκριμένο FPS (καρέ ανά δευτερόλεπτο)  
* Χρησιμοποιήστε ένα τρίτο πρόγραμμα όπως `ffmpeg` για να δημιουργήσετε ένα βίντεο βασισμένο στα καρέ.  

## **Μετατροπή Παρουσίασης PowerPoint σε Βίντεο**

1. Κατεβάστε το ffmpeg[εδώ](https://ffmpeg.org/download.html).  
2. Προσθέστε το μονοπάτι προς `ffmpeg.exe` στη μεταβλητή περιβάλλοντος `PATH`.  
3. Εκτελέστε τον κώδικα μετατροπής PowerPoint σε βίντεο.  

Αυτός ο κώδικας C++ σας δείχνει πώς να μετατρέψετε μια παρουσίαση (που περιέχει μια εικόνα και δύο εφέ κίνησης) σε βίντεο:

```c++
void OnFrameTick(System::SharedPtr<PresentationPlayer> sender, System::SharedPtr<FrameTickEventArgs> args)
{
    System::String fileName = System::String::Format(u"frame_{0}.png", sender->get_FrameIndex());
    args->GetFrame()->Save(fileName);
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Προσθέτει ένα σχήμα χαμόγελου και στη συνέχεια το κινούει
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
        u"warning", m_fps, "frame_%d.png", u"libx264", u"yuv420p", "video.mp4");
    auto ffmpegProcess = System::Diagnostics::Process::Start(u"ffmpeg", ffmpegParameters);
    ffmpegProcess->WaitForExit();
}
```

## **Εφέ Βίντεο**

Μπορείτε να εφαρμόσετε κινήσεις σε αντικείμενα στις διαφάνειες και να χρησιμοποιήσετε μεταβάσεις μεταξύ των διαφανειών.

{{% alert color="primary" %}} 

Μπορεί να θέλετε να δείτε αυτά τα άρθρα: [PowerPoint Animation](https://docs.aspose.com/slides/el/cpp/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/el/cpp/shape-animation/), και [Shape Effect](https://docs.aspose.com/slides/el/cpp/shape-effect/).

{{% /alert %}} 

Οι κινήσεις και οι μεταβάσεις κάνουν τις παρουσιάσεις πιο ελκυστικές και ενδιαφέρουσες — και το ίδιο ισχύει για τα βίντεο. Ας προσθέσουμε μια άλλη διαφάνεια και μετάβαση στον κώδικα της προηγούμενης παρουσίασης:

```c++
// Προσθέτει ένα σχήμα χαμόγελου και το κινεί

// ...

// Προσθέτει μια νέα διαφάνεια και κινούμενη μετάβαση

System::SharedPtr<ISlide> newSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_Slide(0)->get_LayoutSlide());

System::SharedPtr<IBackground> slideBackground = newSlide->get_Background();

slideBackground->set_Type(BackgroundType::OwnBackground);

auto fillFormat = slideBackground->get_FillFormat();

fillFormat->set_FillType(FillType::Solid);

fillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Indigo());

newSlide->get_SlideShowTransition()->set_Type(TransitionType::Push);
```

Το Aspose.Slides υποστηρίζει επίσης κίνηση κειμένων. Έτσι, κινούμε παραγράφους σε αντικείμενα, που θα εμφανίζονται η μία μετά την άλλη (με καθυστέρηση ενός δευτερολέπτου):

```c++
void OnFrameTick(System::SharedPtr<PresentationPlayer> sender, System::SharedPtr<FrameTickEventArgs> args)
{
    System::String fileName = System::String::Format(u"frame_{0}.png", sender->get_FrameIndex());
    args->GetFrame()->Save(fileName);
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Προσθέτει κείμενο και κινήσεις
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
        u"warning", m_fps, "frame_%d.png", u"libx264", u"yuv420p", "video.mp4");
    auto ffmpegProcess = System::Diagnostics::Process::Start(u"ffmpeg", ffmpegParameters);
    ffmpegProcess->WaitForExit();
}
```

## **Κλάσεις Μετατροπής Βίντεο**

Για να εκτελέσετε εργασίες μετατροπής PowerPoint σε βίντεο, το Aspose.Slides παρέχει τις κλάσεις [PresentationAnimationsGenerator](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.export.presentation_animations_generator/) και [PresentationPlayer](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.export.presentation_player/).  

Η PresentationAnimationsGenerator σας επιτρέπει να ορίσετε το μέγεθος του καρέ για το βίντεο (που θα δημιουργηθεί αργότερα) μέσω του κατασκευαστή της. Αν περάσετε ένα αντικείμενο παρουσίασης, θα χρησιμοποιηθεί το `Presentation.SlideSize` και θα δημιουργήσει κινήσεις που η [PresentationPlayer](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.export.presentation_player/) χρησιμοποιεί.  

Κατά τη δημιουργία των κινήσεων, παράγεται ένα συμβάν `NewAnimation` για κάθε επόμενη κίνηση, το οποίο έχει ως παράμετρο έναν [IPresentationAnimationPlayer](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.export.i_presentation_animation_player/). Αυτός είναι μια κλάση που αντιπροσωπεύει έναν παίχτη για μια ξεχωριστή κίνηση.  

Για να εργαστείτε με [IPresentationAnimationPlayer](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.export.i_presentation_animation_player/), χρησιμοποιούνται η ιδιότητα [get_Duration](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.export.i_presentation_animation_player#a29881d28eb42f345ab130d52f05a2d91) (η συνολική διάρκεια της κίνησης) και η μέθοδος [SetTimePosition](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.export.i_presentation_animation_player#a29cb11a73e3ad5f645626fcee3bc4ea0). Κάθε θέση κίνησης ορίζεται εντός του εύρους *0 έως duration*, και στη συνέχεια η μέθοδος `GetFrame` επιστρέφει ένα Bitmap που αντιστοιχεί στην κατάσταση της κίνησης εκείνη τη στιγμή.

```c++
void OnNewAnimation(System::SharedPtr<IPresentationAnimationPlayer> animationPlayer)
{
    System::Console::WriteLine(u"Total animation duration: {0}", animationPlayer->get_Duration());

    animationPlayer->SetTimePosition(0);
    // αρχική κατάσταση κίνησης
    System::SharedPtr<System::Drawing::Bitmap> bitmap = animationPlayer->GetFrame();
    // bitmap αρχικής κατάστασης κίνησης

    animationPlayer->SetTimePosition(animationPlayer->get_Duration());
    // τελική κατάσταση της κίνησης
    System::SharedPtr<System::Drawing::Bitmap> lastBitmap = animationPlayer->GetFrame();
    // τελευταίο καρέ της κίνησης
    lastBitmap->Save(u"last.png");
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Προσθέτει σχήμα χαμόγελου και το κινεί
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

Για να παίξουν όλες οι κινήσεις μιας παρουσίασης ταυτόχρονα, χρησιμοποιείται η κλάση [PresentationPlayer](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.export.presentation_player/). Αυτή η κλάση λαμβάνει μια παρουσίαση [PresentationAnimationsGenerator](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.export.presentation_animations_generator/) και FPS για τα εφέ στον κατασκευαστή της και στη συνέχεια καλεί το συμβάν `FrameTick` για όλες τις κινήσεις ώστε να παιχτούν:

```c++
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

Στη συνέχεια τα παραγόμενα καρέ μπορούν να συναχθούν για να παραχθεί ένα βίντεο. Δείτε την ενότητα [Convert PowerPoint to Video](https://docs.aspose.com/slides/el/cpp/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Υποστηριζόμενες Κινήσεις και Εφέ**

**Entrance**:

| Τύπος Κίνησης | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly In** | ![supported](v.png) | ![supported](v.png) |
| **Float In** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Grow & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**Emphasis**:

| Τύπος Κίνησης | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Color Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Teeter** | ![supported](v.png) | ![supported](v.png) |
| **Spin** | ![supported](v.png) | ![supported](v.png) |
| **Grow/Shrink** | ![not supported](x.png) | ![supported](v.png) |
| **Desaturate** | ![not supported](x.png) | ![supported](v.png) |
| **Darken** | ![not supported](x.png) | ![supported](v.png) |
| **Lighten** | ![not supported](x.png) | ![supported](v.png) |
| **Transparency** | ![not supported](x.png) | ![supported](v.png) |
| **Object Color** | ![not supported](x.png) | ![supported](v.png) |
| **Complementary Color** | ![not supported](x.png) | ![supported](v.png) |
| **Line Color** | ![not supported](x.png) | ![supported](v.png) |
| **Fill Color** | ![not supported](x.png) | ![supported](v.png) |

**Exit**:

| Τύπος Κίνησης | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly Out** | ![supported](v.png) | ![supported](v.png) |
| **Float Out** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shrink & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**Motion Paths:**  

| Τύπος Κίνησης | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **Συχνές Ερωτήσεις**

**Μπορεί να γίνει μετατροπή παρουσιάσεων που είναι προστατευμένες με κωδικό;**  

Ναι, το Aspose.Slides επιτρέπει την εργασία με [password-protected presentations](/slides/el/cpp/password-protected-presentation/). Κατά την επεξεργασία τέτοιων αρχείων, πρέπει να παρέχετε τον σωστό κωδικό ώστε η βιβλιοθήκη να έχει πρόσβαση στο περιεχόμενο της παρουσίασης.  

**Υποστηρίζει το Aspose.Slides χρήση σε λύσεις cloud;**  

Ναι, το Aspose.Slides μπορεί να ενσωματωθεί σε cloud εφαρμογές και υπηρεσίες. Η βιβλιοθήκη έχει σχεδιαστεί για να λειτουργεί σε περιβάλλοντα διακομιστών, εξασφαλίζοντας υψηλή απόδοση και επεκτασιμότητα για μαζική επεξεργασία αρχείων.  

**Υπάρχουν περιορισμοί μεγέθους για τις παρουσιάσεις κατά τη μετατροπή;**  

Το Aspose.Slides μπορεί να χειριστεί παρουσιάσεις πρακτικά κάθε μεγέθους. Ωστόσο, όταν εργάζεστε με πολύ μεγάλα αρχεία, μπορεί να απαιτηθούν πρόσθετοι πόροι συστήματος, και μερικές φορές συνιστάται η βελτιστοποίηση της παρουσίασης για να βελτιωθεί η απόδοση.