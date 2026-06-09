---
title: Εφαρμογή Ανιματισμών Σχημάτων σε Παρουσιάσεις Χρησιμοποιώντας C++
linktitle: Ανιματισμός Σχήματος
type: docs
weight: 60
url: /el/cpp/shape-animation/
keywords:
- σχήμα
- ανιματισμός
- εφέ
- ανιμασμένο σχήμα
- ανιμασμένο κείμενο
- προσθήκη ανιματισμού
- λήψη ανιματισμού
- εξαγωγή ανιματισμού
- προσθήκη εφέ
- λήψη εφέ
- εξαγωγή εφέ
- ήχος εφέ
- εφαρμογή ανιματισμού
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Ανακαλύψτε πώς να δημιουργείτε και να προσαρμόζετε ανιματισμούς σχημάτων σε παρουσιάσεις PowerPoint με το Aspose.Slides για C++. Κάντε τη διαφορά!"
---
## **Εισαγωγή**

Οι κινούμενες εικόνες είναι οπτικά εφέ που μπορούν να εφαρμοστούν σε κείμενα, εικόνες, σχήματα ή σε [διαγράμματα](/slides/el/cpp/animated-charts/). Δίνουν ζωή στις παρουσιάσεις ή στα στοιχεία τους. 

## **Γιατί να χρησιμοποιήσετε κινούμενες εικόνες στις παρουσιάσεις;**

Με τη χρήση κινούμενων εικόνων, μπορείτε  

* έλεγχο της ροής των πληροφοριών  
* τονισμό σημαντικών σημείων  
* αύξηση του ενδιαφέροντος ή της συμμετοχής του κοινού σας  
* καθιστώντας το περιεχόμενο πιο εύκολο στην ανάγνωση, στην απορρόφηση ή στην επεξεργασία  
* προσελκύει την προσοχή των αναγνωστών ή των θεατών σε σημαντικά μέρη της παρουσίασης  

Το PowerPoint παρέχει πολλές επιλογές και εργαλεία για animations και εφέ animation στις κατηγορίες **entrance**, **exit**, **emphasis**, και **motion paths**. 

## **Κινούμενες εικόνες στο Aspose.Slides**

* Το Aspose.Slides παρέχει τις κλάσεις και τους τύπους που χρειάζεστε για εργασία με animations υπό το χώρο ονομάτων [Aspose.Slides.Animation](https://reference.aspose.com/slides/el/cpp/namespace/aspose.slides.animation).  
* Το Aspose.Slides παρέχει πάνω από **150 εφέ animation** υπό την απαρίθμηση [EffectType](https://reference.aspose.com/slides/el/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31). Αυτά τα εφέ είναι ουσιαστικά τα ίδια (ή ισοδύναμα) εφέ που χρησιμοποιούνται στο PowerPoint.  

## **Εφαρμογή Animation σε TextBox**

Το Aspose.Slides για C++ σας επιτρέπει να εφαρμόζετε animation στο κείμενο ενός σχήματος. 

1. Δημιουργήστε μια εμφάνιση της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation/).  
2. Πάρτε την αναφορά μιας διαφάνειας μέσω του δείκτη της.  
3. Προσθέστε ένα `rectangle` [IAutoShape](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_auto_shape).  
4. Προσθέστε κείμενο στο [IAutoShape.TextFrame](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3).  
5. Πάρτε την κύρια ακολουθία εφέ.  
6. Προσθέστε ένα εφέ animation στο [IAutoShape](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_auto_shape).  
7. Ορίστε την ιδιότητα [TextAnimation.BuildType](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.animation.text_animation#afa90da088213f947baf64f8cdddd18b8) στην τιμή από την [απαρίθμηση BuildType](https://reference.aspose.com/slides/el/cpp/namespace/aspose.slides.animation#a1b0f1615881ac05b1a72c670a125b8e7).  
8. Γράψτε την παρουσίαση στο δίσκο ως αρχείο PPTX.  

Αυτός ο κώδικας C++ δείχνει πώς να εφαρμόσετε το εφέ `Fade` στο AutoShape και να ορίσετε την κίνηση κειμένου στην τιμή *By 1st Level Paragraphs*:

```c++
// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο παρουσίασης.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Adds new AutoShape with text
System::SharedPtr<IAutoShape> autoShape =
    sld->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 100.0f);

System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"First paragraph \nSecond paragraph \n Third paragraph");

// Gets the main sequence of the slide.
System::SharedPtr<ISequence> sequence = sld->get_Timeline()->get_MainSequence();

// Adds Fade animation effect to shape
System::SharedPtr<IEffect> effect = sequence->AddEffect(autoShape, Aspose::Slides::Animation::EffectType::Fade,
    Aspose::Slides::Animation::EffectSubtype::None, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Animates shape text by 1st level paragraphs
effect->get_TextAnimation()->set_BuildType(Aspose::Slides::Animation::BuildType::ByLevelParagraphs1);

// Save the PPTX file to disk
pres->Save(path + u"AnimText_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert color="primary"  %}} 

Εκτός από την εφαρμογή animations σε κείμενο, μπορείτε επίσης να εφαρμόσετε animations σε ένα μεμονωμένο [Paragraph](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_paragraph). Δείτε το [**Animated Text**](/slides/el/cpp/animated-text/).

{{% /alert %}} 

## **Εφαρμογή Animation σε PictureFrame**

1. Δημιουργήστε μια εμφάνιση της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation/).  
2. Πάρτε την αναφορά μιας διαφάνειας μέσω του δείκτη της.  
3. Προσθέστε ή λάβετε ένα [PictureFrame](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_picture_frame) στην διαφάνεια.  
4. Πάρτε την κύρια ακολουθία εφέ.  
5. Προσθέστε ένα εφέ animation στο [PictureFrame](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_picture_frame).  
6. Γράψτε την παρουσίαση στο δίσκο ως αρχείο PPTX.  

Αυτός ο κώδικας C++ δείχνει πώς να εφαρμόσετε το εφέ `Fly` σε ένα picture frame:

```c++
// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο παρουσίασης.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Φορτώνει εικόνα που θα προστεθεί στη συλλογή εικόνων της παρουσίασης
System::SharedPtr<IImage> img = Images::FromFile(u"aspose-logo.jpg");
System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(img);

// Προσθέτει πλαίσιο εικόνας στη διαφάνεια
System::SharedPtr<IPictureFrame> picFrame =
    pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 100.0f, image);

// Λαμβάνει την κύρια ακολουθία της διαφάνειας.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Προσθέτει το εφέ Fly από αριστερά στο πλαίσιο εικόνας
System::SharedPtr<IEffect> effect = sequence->AddEffect(picFrame, Aspose::Slides::Animation::EffectType::Fly,
    Aspose::Slides::Animation::EffectSubtype::Left, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Αποθηκεύει το αρχείο PPTX στο δίσκο
pres->Save(path + u"AnimImage_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Εφαρμογή Animation σε Shape**

1. Δημιουργήστε μια εμφάνιση της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation/).  
2. Πάρτε την αναφορά μιας διαφάνειας μέσω του δείκτη της.  
3. Προσθέστε ένα `rectangle` [IAutoShape](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_auto_shape).  
4. Προσθέστε ένα `Bevel` [IAutoShape](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_auto_shape) (όταν αυτό το αντικείμενο κλικάρεται, το animation παίζει).  
5. Δημιουργήστε μια ακολουθία εφέ στο σχήμα bevel.  
6. Δημιουργήστε ένα προσαρμ. `UserPath`.  
7. Προσθέστε εντολές για μετακίνηση στο `UserPath`.  
8. Γράψτε την παρουσίαση στο δίσκο ως αρχείο PPTX.  

Αυτός ο κώδικας C++ δείχνει πώς να εφαρμόσετε το εφέ `PathFootball` (path football) σε ένα shape:

```c++
	// Η διαδρομή προς τον φάκελο του εγγράφου.
	const String outPath = u"../out/AnimationsOnShapes_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Φορτώνει την παρουσίαση
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Προσπελάζει την πρώτη διαφάνεια
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Προσπελάζει τη συλλογή σχημάτων για την επιλεγμένη διαφάνεια
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Δημιουργεί το εφέ PathFootball για υπάρχον σχήμα από την αρχή.
	SharedPtr<IAutoShape> ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);

	ashp->AddTextFrame(u"Animated TextBox");

	// Προσθέτει το εφέ κίνησης PathFootBall
	slide->get_Timeline()->get_MainSequence()->AddEffect(ashp, EffectType::PathFootball,
		EffectSubtype::None, EffectTriggerType::AfterPrevious);

	// Δημιουργεί είδους «κουμπί».
	SharedPtr<IAutoShape> shapeTrigger = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 10, 10, 20, 20);

	// Δημιουργεί μια ακολουθία εφέ για αυτό το κουμπί.
	SharedPtr<ISequence> seqInter = slide->get_Timeline()->get_InteractiveSequences()->Add(shapeTrigger);
	
	 // Δημιουργεί προσαρμοσμένη διαδρομή χρήστη. Το αντικείμενό μας θα μετακινηθεί μόνο μετά το κλικ στο κουμπί.
	SharedPtr<IEffect> fxUserPath = seqInter->AddEffect(ashp, EffectType::PathUser, EffectSubtype::None, EffectTriggerType::OnClick);

	// Προσθέτει εντολές κίνησης καθώς η δημιουργηθείσα διαδρομή είναι κενή.
	 SharedPtr<MotionEffect> motionBvh = ExplicitCast<MotionEffect>(fxUserPath->get_Behaviors()->idx_get(0));

	// SharedPtr<PointF> point = MakeObject<PointF >(0.076, 0.59);
	 const PointF point = PointF (0.076, 0.59);
	 System::ArrayPtr<PointF> pts = System::MakeObject<System::Array<PointF>>(1, point);
	 motionBvh->get_Path()->Add(MotionCommandPathType::LineTo, pts, MotionPathPointsType::Auto, true);
	 
	 //PointF point2[1] = { -0.076, -0.59 };
	const  PointF point2 = PointF(-0.076, -0.59 );

	 System::ArrayPtr<PointF> pts2 = System::MakeObject<System::Array<PointF>>(1, point2);
	 motionBvh->get_Path()->Add(MotionCommandPathType::LineTo, pts2, MotionPathPointsType::Auto, false);
	 
	 motionBvh->get_Path()->Add(MotionCommandPathType::End, nullptr, MotionPathPointsType::Auto, false);
	 
	 //Γράφει το αρχείο PPTX στο δίσκο
	 pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Λήψη των εφέ Animation που έχουν εφαρμοστεί σε Shape**

Τα παρακάτω παραδείγματα δείχνουν πώς να χρησιμοποιήσετε τη μέθοδο `GetEffectsByShape` από το interface [ISequence](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/isequence/) για να λάβετε όλα τα εφέ animation που έχουν εφαρμοστεί σε ένα σχήμα.  

**Παράδειγμα 1: Λήψη εφέ animation που έχουν εφαρμοστεί σε σχήμα σε κανονική διαφάνεια**

Προηγουμένως, μάθατε πώς να προσθέτετε εφέ animation σε σχήματα σε παρουσιάσεις PowerPoint. Ο παρακάτω κώδικας δείχνει πώς να λάβετε τα εφέ που έχουν εφαρμοστεί στο πρώτο σχήμα της πρώτης κανονικής διαφάνειας στην παρουσίαση `AnimExample_out.pptx`.

```c++
SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"AnimExample_out.pptx");

SharedPtr<ISlide> firstSlide = presentation->get_Slide(0);

// Λαμβάνει την κύρια ακολουθία animation της διαφάνειας.
SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Λαμβάνει το πρώτο σχήμα στην πρώτη διαφάνεια.
SharedPtr<IShape> shape = firstSlide->get_Shape(0);

// Λαμβάνει τα εφέ animation που έχουν εφαρμοστεί στο σχήμα.
ArrayPtr<SharedPtr<IEffect>> shapeEffects = sequence->GetEffectsByShape(shape);

if (shapeEffects->get_Length() > 0)
{
    Console::WriteLine(u"The shape " + shape->get_Name() + u" has " + shapeEffects->get_Length() + u" animation effects.");
}

presentation->Dispose();
```

**Παράδειγμα 2: Λήψη όλων των εφέ animation, συμπεριλαμβανομένων αυτών που κληρονομήθηκαν από placeholders**

Εάν ένα σχήμα σε κανονική διαφάνεια έχει placeholders που βρίσκονται στη διαφάνεια διάταξης και/ή στη master διαφάνεια, και έχετε προσθέσει εφέ animation σε αυτά τα placeholders, τότε όλα τα εφέ του σχήματος θα εκτελούνται κατά τη διάρκεια της παρουσίασης, συμπεριλαμβανομένων και των κληρονομημένων από τα placeholders.  

Ας πούμε ότι έχουμε ένα αρχείο παρουσίασης PowerPoint `sample.pptx` με μία διαφάνεια που περιέχει μόνο ένα σχήμα υποσέλιδου με το κείμενο "Made with Aspose.Slides" και το εφέ **Random Bars** έχει εφαρμοστεί στο σχήμα.

![Επίπτωση εφέ σχήματος διαφάνειας](slide-shape-animation.png)

Ας υποθέσουμε επίσης ότι το εφέ **Split** έχει εφαρμοστεί στο placeholder υποσέλιδου στη **layout** διαφάνεια.

![Επίπτωση εφέ σχήματος διάταξης](layout-shape-animation.png)

Τέλος, το εφέ **Fly In** έχει εφαρμοστεί στο placeholder υποσέλιδου στη **master** διαφάνεια.

![Επίπτωση εφέ σχήματος master](master-shape-animation.png)

Ο παρακάτω κώδικας δείχνει πώς να χρησιμοποιήσετε τη μέθοδο `GetBasePlaceholder` από το interface [IShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/) για να προσπελάσετε τα placeholders του σχήματος και να λάβετε τα εφέ animation που έχουν εφαρμοστεί στο σχήμα υποσέλιδου, συμπεριλαμβανομένων των κληρονομημένων από placeholders που βρίσκονται στις διαφάνειες layout και master.

```cpp
void PrintEffects(ArrayPtr<SharedPtr<IEffect>> effects)
{
    for (SharedPtr<IEffect> effect : effects)
    {
        Console::WriteLine(String::Format(u"Type: {0}, subtype: {1}", effect->get_Type(), effect->get_Subtype()));
    }
}
```
```cpp
SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"sample.pptx");

SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Λαμβάνει τα εφέ animation του σχήματος στην κανονική διαφάνεια.
SharedPtr<IShape> shape = slide->get_Shape(0);
ArrayPtr<SharedPtr<IEffect>> shapeEffects = slide->get_Timeline()->get_MainSequence()->GetEffectsByShape(shape);

// Λαμβάνει τα εφέ animation του placeholder στη διαφάνεια διάταξης.
SharedPtr<IShape> layoutShape = shape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> layoutShapeEffects = slide->get_LayoutSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(layoutShape);

// Λαμβάνει τα εφέ animation του placeholder στη master διαφάνεια.
SharedPtr<IShape> masterShape = layoutShape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> masterShapeEffects = slide->get_LayoutSlide()->get_MasterSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(masterShape);

presentation->Dispose();

Console::WriteLine(u"Main sequence of shape effects:");
PrintEffects(masterShapeEffects);
PrintEffects(layoutShapeEffects);
PrintEffects(shapeEffects);
```

Output:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // Πτήση, Κάτω
Type: 134, subtype: 45            // Διαίρεση, Κατακόρυφη Είσοδος
Type: 126, subtype: 22            // Τυχαίες Γραμμές, Οριζόντια
```

## **Αλλαγή ιδιοτήτων χρονισμού εφέ Animation**

Το Aspose.Slides για C++ σας επιτρέπει να αλλάζετε τις ιδιότητες Timing ενός εφέ animation.  

Αυτό είναι το παράθυρο Animation Timing στο Microsoft PowerPoint:

![Παράθυρο Animation Timing](shape-animation.png)

Αυτές είναι οι αντιστοιχίες μεταξύ PowerPoint Timing και των ιδιοτήτων [Effect.Timing](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c):

- Η λίστα επιλογής **Start** του PowerPoint Timing ταιριάζει με την ιδιότητα [Effect.Timing.TriggerType](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.animation.i_timing#a9cec24d555c39e33f0b71dc2210daab3).  
- Το **Duration** του PowerPoint Timing ταιριάζει με την ιδιότητα [Effect.Timing.Duration](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.animation.i_timing#a4f5eebdec3b0b2e6d57ee944b5a8a340). Η διάρκεια ενός animation (σε δευτερόλεπτα) είναι ο συνολικός χρόνος που χρειάζεται για να ολοκληρωθεί ένας κύκλος.  
- Το **Delay** του PowerPoint Timing ταιριάζει με την ιδιότητα [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.animation.i_timing#a947ac2f79c7310d0276ef17999b7214b).  

Αυτή είναι η διαδικασία αλλαγής των ιδιοτήτων Effect Timing:

1. [Apply](#apply-animation-to-shape) ή λάβετε το εφέ animation.  
2. Ορίστε νέες τιμές για τις ιδιότητες [Effect.Timing](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) που χρειάζεστε.  
3. Αποθηκεύστε το τροποποιημένο αρχείο PPTX.  

```c++
// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο παρουσίασης.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Λαμβάνει την κύρια ακολουθία της διαφάνειας.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Λαμβάνει το πρώτο εφέ της κύριας ακολουθίας.
System::SharedPtr<IEffect> effect = sequence->idx_get(0);

// Αλλάζει το TriggerType του εφέ ώστε να ξεκινά με κλικ
effect->get_Timing()->set_TriggerType(Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Αλλάζει τη διάρκεια του εφέ
effect->get_Timing()->set_Duration(3.f);

// Αλλάζει το χρόνο καθυστέρησης ενεργοποίησης του εφέ
effect->get_Timing()->set_TriggerDelayTime(0.5f);

// Αποθηκεύει το αρχείο PPTX στο δίσκο
pres->Save(u"AnimExample_changed.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Ήχος εφέ Animation**

Το Aspose.Slides παρέχει τις παρακάτω ιδιότητες για να εργάζεστε με ήχους σε εφέ animation: 

- [set_Sound()](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/effect/set_sound/)  
- [set_StopPreviousSound()](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/effect/set_stopprevioussound/) 

### **Προσθήκη ήχου σε εφέ Animation**

Αυτός ο κώδικας C++ δείχνει πώς να προσθέσετε ήχο σε εφέ animation και να τον σταματήσετε όταν ξεκινά το επόμενο εφέ:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Προσθέτει ήχο στη συλλογή ήχων της παρουσίασης
System::SharedPtr<IAudio> effectSound = pres->get_Audios()->AddAudio(System::IO::File::ReadAllBytes(u"sampleaudio.wav"));
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Λαμβάνει την κύρια ακολουθία της διαφάνειας.
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Λαμβάνει το πρώτο εφέ της κύριας ακολουθίας
System::SharedPtr<IEffect> firstEffect = sequence->idx_get(0);

// Ελέγχει το εφέ για «Χωρίς Ήχο»
if (!firstEffect->get_StopPreviousSound() && firstEffect->get_Sound() == nullptr)
{
    // Προσθέτει ήχο για το πρώτο εφέ
    firstEffect->set_Sound(effectSound);
}

// Λαμβάνει την πρώτη διαδραστική ακολουθία της διαφάνειας.
System::SharedPtr<ISequence> interactiveSequence = firstSlide->get_Timeline()->get_InteractiveSequence(0);

// Ορίζει τη σημαία «Σταμάτημα προηγούμενου ήχου» του εφέ
interactiveSequence->idx_get(0)->set_StopPreviousSound(true);

// Αποθηκεύει το αρχείο PPTX στο δίσκο
pres->Save(u"AnimExample_Sound_out.pptx", SaveFormat::Pptx);
```

### **Εξαγωγή ήχου από εφέ Animation**

1. Δημιουργήστε μια εμφάνιση της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).  
2. Πάρτε την αναφορά μιας διαφάνειας μέσω του δείκτη της.  
3. Πάρτε την κύρια ακολουθία εφέ.  
4. Εξάγετε το ενσωματωμένο [set_Sound()](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/effect/set_sound/) σε κάθε εφέ animation.  

```c++
// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο παρουσίασης.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"EffectSound.pptx");
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Gets the main sequence of the slide.
System::SharedPtr<ISequence> sequence = slide->get_Timeline()->get_MainSequence();

for (auto&& effect : sequence)
{
    System::SharedPtr<IAudio> sound = effect->get_Sound();

    if (sound == nullptr)
        continue;

    auto audio = sound->get_BinaryData();
}
```

## **Μετά το Animation**

Το Aspose.Slides για C++ σας επιτρέπει να αλλάξετε την ιδιότητα After animation ενός εφέ animation.  

Αυτή είναι η καρτέλα Animation Effect και το εκτεταμένο μενού στο Microsoft PowerPoint:

![Παράθυρο Animation Effect](shape-after-animation.png)

Η λίστα επιλογής **After animation** του PowerPoint Effect ταιριάζει με τις παρακάτω ιδιότητες: 

- η ιδιότητα [set_AfterAnimationType()](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/ieffect/set_afteranimationtype/) που περιγράφει τον τύπο After animation :  
  * το **More Colors** του PowerPoint ταιριάζει με τον τύπο [AfterAnimationType.Color](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/afteranimationtype/)  
  * το **Don't Dim** του PowerPoint ταιριάζει με τον τύπο [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/afteranimationtype/) (προεπιλεγμένος τύπος)  
  * το **Hide After Animation** ταιριάζει με τον τύπο [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/afteranimationtype/)  
  * το **Hide on Next Mouse Click** ταιριάζει με τον τύπο [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/afteranimationtype/)  
- η ιδιότητα [set_AfterAnimationColor()](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/ieffect/set_afteranimationcolor/) που ορίζει μορφή χρώματος after animation. Αυτή η ιδιότητα λειτουργεί σε συνδυασμό με τον τύπο [AfterAnimationType.Color](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/afteranimationtype/). Αν αλλάξετε τον τύπο, το χρώμα after animation θα αφαιρεθεί.  

```c++
// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο παρουσίασης
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimImage_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Λαμβάνει το πρώτο εφέ της κύριας ακολουθίας
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Αλλάζει τον τύπο μετά το animation σε Χρώμα
firstEffect->set_AfterAnimationType(AfterAnimationType::Color);

// Ορίζει το χρώμα μετά το animation
firstEffect->get_AfterAnimationColor()->set_Color(System::Drawing::Color::get_AliceBlue());

// Γράφει το αρχείο PPTX στο δίσκο
pres->Save(u"AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
```

## **Animate Text**

Το Aspose.Slides παρέχει τις παρακάτω ιδιότητες για να εργαστείτε με το τμήμα *Animate text* ενός εφέ animation: 

- [set_AnimateTextType()](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) που περιγράφει τον τύπο animate text του εφέ. Το κείμενο του shape μπορεί να αναπαραχθεί:  
  - Όλο μαζί ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/animatetexttype/) τύπος)  
  - Ανά λέξη ([AnimateTextType.ByWord](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/animatetexttype/) τύπος)  
  - Ανά γράμμα ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/animatetexttype/) τύπος)  
- [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) ορίζει καθυστέρηση μεταξύ των τμημάτων του κειμένου (λέξεις ή γράμματα). Μια θετική τιμή καθορίζει το ποσοστό της διάρκειας του εφέ. Μια αρνητική τιμή καθορίζει την καθυστέρηση σε δευτερόλεπτα.  

Αυτή είναι η διαδικασία αλλαγής των ιδιοτήτων Effect Animate text:

1. [Apply](#apply-animation-to-shape) ή λάβετε το εφέ animation.  
2. Ορίστε την ιδιότητα [set_BuildType()](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation.itextanimation/set_buildtype/) στην τιμή [BuildType.AsOneObject](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/buildtype/) για να απενεργοποιήσετε τη λειτουργία *By Paragraphs*.  
3. Ορίστε νέες τιμές για τις ιδιότητες [set_AnimateTextType()](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) και [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/el/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/).  
4. Αποθηκεύστε το τροποποιημένο αρχείο PPTX.  

```c++
// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο παρουσίασης.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimTextBox_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Λαμβάνει το πρώτο εφέ της κύριας ακολουθίας
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Αλλάζει τον τύπο κειμενικής animation του εφέ σε "As One Object"
firstEffect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);

// Αλλάζει τον τύπο Animate text του εφέ σε "By word"
firstEffect->set_AnimateTextType(AnimateTextType::ByWord);

// Ορίζει την καθυστέρηση μεταξύ λέξεων στο 20% της διάρκειας του εφέ
firstEffect->set_DelayBetweenTextParts(20.0f);

// Γράφει το αρχείο PPTX στο δίσκο
pres->Save(u"AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
```

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Πώς μπορώ να διασφαλίσω ότι τα animations διατηρούνται όταν δημοσιεύω την παρουσίαση στο web;**

[Export to HTML5](/slides/el/cpp/export-to-html5/) και ενεργοποιήστε τις [options](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/html5options/) που αφορούν τα animations [shape](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/html5options/set_animateshapes/) και [transition](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/html5options/set_animatetransitions/). Το απλό HTML δεν εκτελεί τα animations των διαφανειών, ενώ το HTML5 το κάνει.  

**Πώς η αλλαγή του z-order (της σειράς στρώσεων) των σχημάτων επηρεάζει το animation;**

Το animation και η σειρά σχεδίασης είναι ανεξάρτητα: ένα εφέ ελέγχει το timing και τον τύπο εμφάνισης/απόσυρσης, ενώ το [z-order](https://reference.aspose.com/slides/el/cpp/aspose.slides/shape/get_zorderposition/) καθορίζει τι καλύπτει τι. Το ορατό αποτέλεσμα ορίζεται από το συνδυασμό τους. (Αυτή είναι η γενική συμπεριφορά του PowerPoint· το μοντέλο effects-and-shapes του Aspose.Slides ακολουθεί την ίδια λογική.)  

**Υπάρχουν περιορισμοί κατά τη μετατροπή των animations σε βίντεο για ορισμένα εφέ;**

Γενικά, τα [animations υποστηρίζονται](/slides/el/cpp/convert-powerpoint-to-video/), αλλά σπάνιες περιπτώσεις ή συγκεκριμένα εφέ μπορεί να αποδοθούν διαφορετικά. Συνίσταται να δοκιμάζετε με τα εφέ που χρησιμοποιείτε και με την έκδοση της βιβλιοθήκης.