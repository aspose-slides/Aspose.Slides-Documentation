---
title: Εφαρμογή Κινήσεων Σχημάτων σε Παρουσιάσεις σε .NET
linktitle: Κίνηση Σχήματος
type: docs
weight: 60
url: /el/net/shape-animation/
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
- .NET
- C#
- Aspose.Slides
description: "Ανακαλύψτε πώς να δημιουργήσετε και να προσαρμόσετε κινήσεις σχημάτων σε παρουσιάσεις PowerPoint με το Aspose.Slides για .NET. Ξεχωρίστε!"
---
## **Εισαγωγή**

Οι αναμεταθέσεις είναι οπτικά εφέ που μπορούν να εφαρμοστούν σε κείμενα, εικόνες, σχήματα ή [διαγράμματα](/slides/el/net/animated-charts/). Δίνουν ζωή στις παρουσιάσεις ή στα στοιχεία τους. 

## **Γιατί να χρησιμοποιήσετε κινήσεις σε παρουσιάσεις;**

Χρησιμοποιώντας κινήσεις, μπορείτε  

* να ελέγχετε τη ροή της πληροφορίας  
* να τονίζετε σημαντικά σημεία  
* να αυξάνετε το ενδιαφέρον ή τη συμμετοχή του κοινού σας  
* να καθιστάτε το περιεχόμενο πιο ευανάγνωστο ή κατανοητό ή επεξεργάσιμο  
* να προσελκύετε την προσοχή των αναγνωστών ή θεατών σας σε σημαντικά τμήματα μιας παρουσίασης  

PowerPoint παρέχει πολλές επιλογές και εργαλεία για κινήσεις και εφέ κίνησης στις κατηγορίες **entrance**, **exit**, **emphasis**, και **motion paths**. 

## **Κινήσεις στο Aspose.Slides**

* Το Aspose.Slides παρέχει τις κλάσεις και τους τύπους που χρειάζεστε για να εργαστείτε με κινήσεις στο χώρο ονομάτων [Aspose.Slides.Animation](https://reference.aspose.com/slides/el/net/aspose.slides.animation/) namespace,  
* Το Aspose.Slides παρέχει πάνω από **150 εφέ κίνησης** στο [EffectType](https://reference.aspose.com/slides/el/net/aspose.slides.animation/effecttype) enumeration. Αυτά τα εφέ είναι ουσιαστικά τα ίδια (ή ισοδύναμα) που χρησιμοποιούνται στο PowerPoint.

## **Εφαρμογή κίνησης σε TextBox**

Το Aspose.Slides για .NET σας επιτρέπει να εφαρμόσετε κίνηση στο κείμενο ενός σχήματος. 

1. Δημιουργήστε ένα αντίτυπο της κλάσης [Presentation](http://www.aspose.com/api/net/slides/el/aspose.slides/) class.  
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της.  
3. Προσθέστε ένα `rectangle` [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape).  
4. Προσθέστε κείμενο στο [IAutoShape.TextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/properties/textframe).  
5. Αποκτήστε τη κύρια ακολουθία εφέ.  
6. Προσθέστε ένα εφέ κίνησης στο [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape).  
7. Ορίστε την ιδιότητα [TextAnimation.BuildType](https://reference.aspose.com/slides/el/net/aspose.slides.animation/textanimation/properties/buildtype) στην τιμή από την [BuildType Enumeration](https://reference.aspose.com/slides/el/net/aspose.slides.animation/buildtype).  
8. Γράψτε την παρουσίαση στο δίσκο ως αρχείο PPTX.  

Αυτός ο κώδικας C# δείχνει πώς να εφαρμόσετε το εφέ `Fade` στο AutoShape και να ορίσετε την κίνηση κειμένου στην τιμή *By 1st Level Paragraphs*:

```c#
// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    
    // Προσθέτει νέο AutoShape με κείμενο
    IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "First paragraph \nSecond paragraph \n Third paragraph";

    // Λαμβάνει τη κύρια ακολουθία της διαφάνειας.
    ISequence sequence = sld.Timeline.MainSequence;

    // Προσθέτει εφέ κίνησης Fade στο σχήμα
    IEffect effect = sequence.AddEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Κινεί το κείμενο του σχήματος ανά πρώτα επίπεδα παραγράφων
    effect.TextAnimation.BuildType = BuildType.ByLevelParagraphs1;

    // Αποθηκεύει το αρχείο PPTX στο δίσκο
    pres.Save(path + "AnimTextBox_out.pptx", SaveFormat.Pptx);
}
```

{{%  alert color="primary"  %}} 

Εκτός από την εφαρμογή κινήσεων σε κείμενο, μπορείτε επίσης να εφαρμόσετε κινήσεις σε ένα μοναδικό [Paragraph](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraph). Δείτε [**Animated Text**](/slides/el/net/animated-text/).

{{% /alert %}} 

## **Εφαρμογή κίνησης σε PictureFrame**

1. Δημιουργήστε ένα αντίτυπο της κλάσης [Presentation](http://www.aspose.com/api/net/slides/el/aspose.slides/) class.  
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της.  
3. Προσθέστε ή αποκτήστε ένα [PictureFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ipictureframe) στη διαφάνεια.  
5. Αποκτήστε τη κύρια ακολουθία εφέ.  
6. Προσθέστε ένα εφέ κίνησης στο [PictureFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ipictureframe).  
8. Γράψτε την παρουσίαση στο δίσκο ως αρχείο PPTX.  

Αυτός ο κώδικας C# δείχνει πώς να εφαρμόσετε το εφέ `Fly` σε ένα picture frame:

```c#
// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using (Presentation pres = new Presentation())
{
    // Φορτώνει εικόνα που θα προστεθεί στη συλλογή εικόνων της παρουσίασης
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Προσθέτει πλαίσιο εικόνας στη διαφάνεια
    IPictureFrame picFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Λαμβάνει τη κύρια ακολουθία της διαφάνειας.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Προσθέτει εφέ κίνησης Fly από αριστερά στο πλαίσιο εικόνας
    IEffect effect = sequence.AddEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Αποθηκεύει το αρχείο PPTX στο δίσκο
    pres.Save("AnimImage_out.pptx", SaveFormat.Pptx);
}
```

## **Εφαρμογή κίνησης σε Shape**

1. Δημιουργήστε ένα αντίτυπο της κλάσης [Presentation](http://www.aspose.com/api/net/slides/el/aspose.slides/) class.  
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της.  
3. Προσθέστε ένα `rectangle` [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape).  
4. Προσθέστε ένα `Bevel` [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape) (when this object is clicked, the animation gets played).  
5. Δημιουργήστε μια ακολουθία εφέ στο σχήμα bevel.  
6. Δημιουργήστε ένα προσαρμοσμένο `UserPath`.  
7. Προσθέστε εντολές για κίνηση στο `UserPath`.  
8. Γράψτε την παρουσίαση στο δίσκο ως αρχείο PPTX.  

Αυτός ο κώδικας C# δείχνει πώς να εφαρμόσετε το εφέ `PathFootball` (path football) σε ένα σχήμα:

```c#
    // Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
    using (Presentation pres = new Presentation())
    {
        ISlide sld = pres.Slides[0];
    
        // Δημιουργεί εφέ PathFootball για υπάρχον σχήμα από την αρχή.
        IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    
        ashp.AddTextFrame("Animated TextBox");
    
        // Προσθέτει το εφέ κίνησης PathFootBall.
        pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                               EffectSubtype.None, EffectTriggerType.AfterPrevious);
    
        // Δημιουργεί κάποιο είδος "κουμπιού".
        IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);
    
        // Δημιουργεί μια ακολουθία εφέ για το κουμπί.
        ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);
    
        // Δημιουργεί προσαρμοσμένη διαδρομή χρήστη. Το αντικείμενό μας θα μετακινηθεί μόνο αφού γίνει κλικ στο κουμπί.
        IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);
    
        // Προσθέτει εντολές κίνησης επειδή η δημιουργημένη διαδρομή είναι κενή.
        IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.Behaviors[0]);
    
        PointF[] pts = new PointF[1];
        pts[0] = new PointF(0.076f, 0.59f);
        motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
        pts[0] = new PointF(-0.076f, -0.59f);
        motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
        motionBhv.Path.Add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);
    
        // Γράφει το αρχείο PPTX στο δίσκο
        pres.Save("AnimExample_out.pptx", SaveFormat.Pptx);
    }
```

## **Λήψη των εφέ κίνησης που έχουν εφαρμοστεί σε σχήμα**

Τα παρακάτω παραδείγματα δείχνουν πώς να χρησιμοποιήσετε τη μέθοδο `GetEffectsByShape` από τη διεπαφή [ISequence](https://reference.aspose.com/slides/el/net/aspose.slides.animation/isequence/) για να λάβετε όλα τα εφέ κίνησης που έχουν εφαρμοστεί σε ένα σχήμα.

**Παράδειγμα 1: Λήψη εφέ κίνησης που έχουν εφαρμοστεί σε σχήμα σε κανονική διαφάνεια**

Σε προηγούμενη φάση, μάθατε πώς να προσθέτετε εφέ κίνησης σε σχήματα σε παρουσιάσεις PowerPoint. Ο παρακάτω κώδικας δείχνει πώς να λάβετε τα εφέ που έχουν εφαρμοστεί στο πρώτο σχήμα της πρώτης κανονικής διαφάνειας στην παρουσίαση `AnimExample_out.pptx`.

```c#
using (Presentation presentation = new Presentation("AnimExample_out.pptx"))
{
    ISlide firstSlide = presentation.Slides[0];

    // Λαμβάνει την κύρια ακολουθία κίνησης της διαφάνειας.
    ISequence sequence = firstSlide.Timeline.MainSequence;

    // Λαμβάνει το πρώτο σχήμα στην πρώτη διαφάνεια.
    IShape shape = firstSlide.Shapes[0];

    // Λαμβάνει τα εφέ κίνησης που έχουν εφαρμοστεί στο σχήμα.
    IEffect[] shapeEffects = sequence.GetEffectsByShape(shape);

    if (shapeEffects.Length > 0)
        Console.WriteLine($"The shape {shape.Name} has {shapeEffects.Length} animation effects.");
}
```

**Παράδειγμα 2: Λήψη όλων των εφέ κίνησης, συμπεριλαμβανομένων αυτών που κληρονομούνται από placeholders**

Εάν ένα σχήμα σε κανονική διαφάνεια περιέχει placeholders που βρίσκονται στη διαφάνεια διάταξης και/ή στην κύρια διαφάνεια, και έχουν προστεθεί εφέ κίνησης σε αυτά τα placeholders, τότε όλα τα εφέ του σχήματος θα εκτελεστούν κατά τη διάρκεια της παρουσίασης, συμπεριλαμβανομένων αυτών που κληρονομούνται από τα placeholders.

Ας υποθέσουμε ότι έχουμε ένα αρχείο παρουσίασης PowerPoint `sample.pptx` με μία διαφάνεια που περιέχει μόνο ένα σχήμα υποσέλιδου με το κείμενο "Made with Aspose.Slides" και το εφέ **Random Bars** έχει εφαρμοστεί στο σχήμα.

![Slide shape animation effect](slide-shape-animation.png)

Ας υποθέσουμε επίσης ότι το εφέ **Split** έχει εφαρμοστεί στο placeholder υποσέλιδου στη **layout** διαφάνεια.

![Layout shape animation effect](layout-shape-animation.png)

Και τέλος, το εφέ **Fly In** έχει εφαρμοστεί στο placeholder υποσέλιδου στη **master** διαφάνεια.

![Master shape animation effect](master-shape-animation.png)

Ο παρακάτω κώδικας δείχνει πώς να χρησιμοποιήσετε τη μέθοδο `GetBasePlaceholder` από τη διεπαφή [IShape](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/) για να προσπελάσετε τα placeholders του σχήματος και να λάβετε τα εφέ κίνησης που έχουν εφαρμοστεί στο σχήμα υποσέλιδου, συμπεριλαμβανομένων των κληρονομουμένων από placeholders που βρίσκονται στις διαφάνειες layout και master.

```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Λαμβάνει τα εφέ κίνησης του σχήματος στη κανονική διαφάνεια.
    IShape shape = slide.Shapes[0];
    IEffect[] shapeEffects = slide.Timeline.MainSequence.GetEffectsByShape(shape);

    // Λαμβάνει τα εφέ κίνησης του placeholder στη διαφάνεια διάταξης.
    IShape layoutShape = shape.GetBasePlaceholder();
    IEffect[] layoutShapeEffects = slide.LayoutSlide.Timeline.MainSequence.GetEffectsByShape(layoutShape);

    // Λαμβάνει τα εφέ κίνησης του placeholder στη κύρια διαφάνεια.
    IShape masterShape = layoutShape.GetBasePlaceholder();
    IEffect[] masterShapeEffects = slide.LayoutSlide.MasterSlide.Timeline.MainSequence.GetEffectsByShape(masterShape);

    Console.WriteLine("Main sequence of shape effects:");
    PrintEffects(masterShapeEffects);
    PrintEffects(layoutShapeEffects);
    PrintEffects(shapeEffects);
}
```
```cs
static void PrintEffects(IEnumerable<IEffect> effects)
{
    foreach (IEffect effect in effects)
    {
        Console.WriteLine($"{effect.Type} {effect.Subtype}");
    }
}
```

Output:
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```

## **Αλλαγή ιδιοτήτων χρονισμού εφέ κίνησης**

Το Aspose.Slides για .NET σας επιτρέπει να αλλάξετε τις ιδιότητες Timing ενός εφέ κίνησης.

This is the Animation Timing pane and extended menu in Microsoft PowerPoint:

![example1_image](shape-animation.png)

These are the correspondences between PowerPoint Timing and [Effect.Timing](https://reference.aspose.com/slides/el/net/aspose.slides.animation/effect/properties/timing) properties:
- Η αναπτυσσόμενη λίστα **Start** του PowerPoint Timing αντιστοιχεί στην ιδιότητα [Effect.Timing.TriggerType](https://reference.aspose.com/slides/el/net/aspose.slides.animation/itiming/properties/triggertype). 
- Το **Duration** του PowerPoint Timing αντιστοιχεί στην ιδιότητα [Effect.Timing.Duration](https://reference.aspose.com/slides/el/net/aspose.slides.animation/itiming/properties/duration). Η διάρκεια ενός εφέ (σε δευτερόλεπτα) είναι ο συνολικός χρόνος που απαιτείται για να ολοκληρωθεί ένας κύκλος του εφέ. 
- Το **Delay** του PowerPoint Timing αντιστοιχεί στην ιδιότητα [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/el/net/aspose.slides.animation/itiming/properties/triggerdelaytime). 
- Η αναπτυσσόμενη λίστα **Repeat** του PowerPoint Timing αντιστοιχεί στις ακόλουθες ιδιότητες: 
  * η ιδιότητα [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/el/net/aspose.slides.animation/itiming/repeatcount) που περιγράφει τον *αριθμό* των επαναλήψεων του εφέ·  
  * η σημαία [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/el/net/aspose.slides.animation/itiming/repeatuntilendslide) που καθορίζει αν το εφέ επαναλαμβάνεται μέχρι το τέλος της διαφάνειας·  
  * η σημαία [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/el/net/aspose.slides.animation/itiming/repeatuntilnextclick) που καθορίζει αν το εφέ επαναλαμβάνεται μέχρι το επόμενο κλικ.  
- Το πεδίο ελέγχου **Rewind when done playing** του PowerPoint Timing αντιστοιχεί στην ιδιότητα [Effect.Timing.Rewind](https://reference.aspose.com/slides/el/net/aspose.slides.animation/itiming/rewind/). 

Αυτή είναι η διαδικασία αλλαγής των ιδιοτήτων Timing του Effect:

1. [Apply](#apply-animation-to-shape) ή πάρτε το εφέ κίνησης.  
2. Ορίστε νέες τιμές για τις ιδιότητες [Effect.Timing](https://reference.aspose.com/slides/el/net/aspose.slides.animation/effect/properties/timing) που χρειάζεστε.  
3. Αποθηκεύστε το τροποποιημένο αρχείο PPTX.  

```c#
// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // Λαμβάνει την κύρια ακολουθία της διαφάνειας.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Λαμβάνει το πρώτο εφέ της κύριας ακολουθίας.
    IEffect effect = sequence[0];

    // Αλλάζει τον TriggerType του εφέ ώστε να ξεκινά με κλικ
    effect.Timing.TriggerType = EffectTriggerType.OnClick;

    // Αλλάζει τη διάρκεια του εφέ
    effect.Timing.Duration = 3f;

    // Αλλάζει το TriggerDelayTime του εφέ
    effect.Timing.TriggerDelayTime = 0.5f;

    // Αν η τιμή Repeat του εφέ είναι "none"
    if (effect.Timing.RepeatCount == 1f)
    {
        // Αλλάζει το Repeat του εφέ σε "Until Next Click"
        effect.Timing.RepeatUntilNextClick = true;
    }
    else
    {
        // Αλλάζει το Repeat του εφέ σε "Until End of Slide"
        effect.Timing.RepeatUntilEndSlide = true;
    }

    // Ενεργοποιεί το Rewind του εφέ
        effect.Timing.Rewind = true;
    
    // Αποθηκεύει το αρχείο PPTX στο δίσκο
    pres.Save("AnimExample_changed.pptx", SaveFormat.Pptx);
}
```

## **Ήχος εφέ κίνησης**

Το Aspose.Slides παρέχει τις παρακάτω ιδιότητες ώστε να μπορείτε να εργαστείτε με ήχους στα εφέ κίνησης: 
- [IEffect.Sound](https://reference.aspose.com/slides/el/net/aspose.slides.animation/effect/sound/) 
- [IEffect.StopPreviousSound](https://reference.aspose.com/slides/el/net/aspose.slides.animation/effect/stopprevioussound/) 

### **Προσθήκη ήχου σε εφέ κίνησης**

Αυτός ο κώδικας C# δείχνει πώς να προσθέσετε ήχο σε ένα εφέ κίνησης και να τον σταματήσετε όταν ξεκινά το επόμενο εφέ:

```c#
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
	// Προσθέτει ήχο στη συλλογή ήχων της παρουσίασης
	IAudio effectSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Λαμβάνει την κύρια ακολουθία της διαφάνειας.
	ISequence sequence = firstSlide.Timeline.MainSequence;

	// Λαμβάνει το πρώτο εφέ της κύριας ακολουθίας
	IEffect firstEffect = sequence[0];

	// Ελέγχει το εφέ για "No Sound"
	if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
	{
		// Προσθέτει ήχο στο πρώτο εφέ
		firstEffect.Sound = effectSound;
	}

	// Λαμβάνει την πρώτη διαδραστική ακολουθία της διαφάνειας.
	ISequence interactiveSequence = firstSlide.Timeline.InteractiveSequences[0];

	// Ορίζει τη σημαία "Stop previous sound" του εφέ
	interactiveSequence[0].StopPreviousSound = true;

	// Γράφει το αρχείο PPTX στο δίσκο
	pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```

### **Απόσπαση ήχου από εφέ κίνησης**

1. Δημιουργήστε ένα αντίτυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).  
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της.  
3. Αποκτήστε τη κύρια ακολουθία εφέ.  
4. Εξάγετε το [Sound](https://reference.aspose.com/slides/el/net/aspose.slides.animation/effect/sound/) ενσωματωμένο σε κάθε εφέ κίνησης.  

Αυτός ο κώδικας C# δείχνει πώς να εξάγετε τον ήχο ενσωματωμένο σε ένα εφέ κίνησης:

```c#
// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using (Presentation presentation = new Presentation("EffectSound.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Λαμβάνει την κύρια ακολουθία της διαφάνειας.
    ISequence sequence = slide.Timeline.MainSequence;

    foreach (IEffect effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        // Εξάγει τον ήχο του εφέ σε πίνακα byte
        byte[] audio = effect.Sound.BinaryData;
    }
}
```

## **Μετά την κίνηση**

Το Aspose.Slides για .NET σας επιτρέπει να αλλάξετε την ιδιότητα After animation ενός εφέ κίνησης.

This is the Animation Effect pane and extended menu in Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

Η αναπτυσσόμενη λίστα **After animation** του PowerPoint Effect αντιστοιχεί σε αυτές τις ιδιότητες: 

-   * η ιδιότητα [IEffect.AfterAnimationType](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ieffect/afteranimationtype/) που περιγράφει τον τύπο After animation :
    - Το **More Colors** του PowerPoint αντιστοιχεί στον τύπο [AfterAnimationType.Color](https://reference.aspose.com/slides/el/net/aspose.slides.animation/afteranimationtype/) ;  
    - Το **Don't Dim** του PowerPoint αντιστοιχεί στον τύπο [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/el/net/aspose.slides.animation/afteranimationtype/) (προεπιλεγμένος τύπος μετά την κίνηση) ;  
    - Το **Hide After Animation** του PowerPoint αντιστοιχεί στον τύπο [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/el/net/aspose.slides.animation/afteranimationtype/) ;  
    - Το **Hide on Next Mouse Click** του PowerPoint αντιστοιχεί στον τύπο [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/el/net/aspose.slides.animation/afteranimationtype/) ;  
-   * η ιδιότητα [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ieffect/afteranimationcolor/) που ορίζει μια μορφή χρώματος μετά την κίνηση. Αυτή η ιδιότητα λειτουργεί σε συνδυασμό με τον τύπο [AfterAnimationType.Color](https://reference.aspose.com/slides/el/net/aspose.slides.animation/afteranimationtype/). Εάν αλλάξετε τον τύπο σε άλλο, το χρώμα after animation θα διαγραφεί.  

Αυτός ο κώδικας C# δείχνει πώς να αλλάξετε ένα εφέ μετά την κίνηση:

```c#
// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο παρουσίασης
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
	ISlide firstSlide = pres.Slides[0];

	// Λαμβάνει το πρώτο εφέ της κύριας ακολουθίας
	IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

	// Αλλάζει τον τύπο μετά την κίνηση σε Color
	firstEffect.AfterAnimationType = AfterAnimationType.Color;

	// Ορίζει το χρώμα μετά την κίνηση
	firstEffect.AfterAnimationColor.Color = Color.AliceBlue;

	// Γράφει το αρχείο PPTX στο δίσκο
	pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
}
```

## **Κίνηση κειμένου**

Το Aspose.Slides παρέχει τις παρακάτω ιδιότητες ώστε να μπορείτε να εργαστείτε με το μπλοκ *Animate text* ενός εφέ κίνησης: 
-   * η ιδιότητα [IEffect.AnimateTextType](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ieffect/animatetexttype/) που περιγράφει τον τύπο κίνησης κειμένου του εφέ. Το κείμενο του σχήματος μπορεί να κινείται:
    - Όλο μαζί ([AnimateTextType.AllAtOnce])  
    - Κατά λέξη ([AnimateTextType.ByWord])  
    - Κατά γράμμα ([AnimateTextType.ByLetter])  
-   * η ιδιότητα [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ieffect/delaybetweentextparts/) ορίζει καθυστέρηση μεταξύ των τμημάτων του κειμένου (λέξεις ή γράμματα). Μια θετική τιμή καθορίζει το ποσοστό διάρκειας του εφέ. Μια αρνητική τιμή καθορίζει την καθυστέρηση σε δευτερόλεπτα.  

Αυτή είναι η διαδικασία αλλαγής των ιδιοτήτων Animate text του Effect:  

1. [Apply](#apply-animation-to-shape) ή πάρτε το εφέ κίνησης.  
2. Ορίστε την ιδιότητα [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/el/net/aspose.slides.animation/itextanimation/buildtype/) στην τιμή [BuildType.AsOneObject] για να απενεργοποιήσετε τη λειτουργία κίνησης *By Paragraphs*.  
3. Ορίστε νέες τιμές για τις ιδιότητες [IEffect.AnimateTextType](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ieffect/animatetexttype/) και [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ieffect/delaybetweentextparts/).  
4. Αποθηκεύστε το τροποποιημένο αρχείο PPTX.  

```c#
// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using (Presentation pres = new Presentation("AnimTextBox_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Λαμβάνει το πρώτο εφέ της κύριας ακολουθίας
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Αλλάζει τον τύπο κίνησης κειμένου του εφέ σε "As One Object"
    firstEffect.TextAnimation.BuildType = BuildType.AsOneObject;

    // Αλλάζει τον τύπο κίνησης κειμένου του εφέ σε "By word"
    firstEffect.AnimateTextType = AnimateTextType.ByWord;

    // Ορίζει την καθυστέρηση μεταξύ των λέξεων στο 20% της διάρκειας του εφέ
    firstEffect.DelayBetweenTextParts = 20f;

    // Γράφει το αρχείο PPTX στο δίσκο
    pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
}
```

## **Συχνές ερωτήσεις**

**Πώς μπορώ να εξασφαλίσω ότι οι κινήσεις θα διατηρηθούν όταν δημοσιεύεται η παρουσίαση στον ιστό;**

[Export to HTML5](/slides/el/net/export-to-html5/) και ενεργοποιήστε τις [options](https://reference.aspose.com/slides/el/net/aspose.slides.export/html5options/) που είναι υπεύθυνες για τις κινούμενες [shape](https://reference.aspose.com/slides/el/net/aspose.slides.export/html5options/animateshapes/) και [transition](https://reference.aspose.com/slides/el/net/aspose.slides.export/html5options/animatetransitions/) animations. Το απλό HTML δεν εκτελεί τις κινήσεις των διαφανειών, ενώ το HTML5 το κάνει.

**Πώς η αλλαγή του z-order (της σειράς στρώσεων) των σχημάτων επηρεάζει τις κινήσεις;**

Η κίνηση και η σειρά σχεδίασης είναι ανεξάρτητες: ένα εφέ ελέγχει το χρονισμό και τον τύπο εμφάνισης/απόκρυψης, ενώ το [z-order](https://reference.aspose.com/slides/el/net/aspose.slides/shape/zorderposition/) καθορίζει τι καλύπτει τι. Το ορατό αποτέλεσμα ορίζεται από τον συνδυασμό τους. (Αυτή είναι η γενική συμπεριφορά του PowerPoint· το μοντέλο effects-and-shapes του Aspose.Slides ακολουθεί την ίδια λογική.)

**Υπάρχουν περιορισμοί κατά τη μετατροπή των κινήσεων σε βίντεο για ορισμένα εφέ;**

Γενικά, τα [animations are supported](/slides/el/net/convert-powerpoint-to-video/), αλλά σπάνιες περιπτώσεις ή συγκεκριμένα εφέ μπορεί να αποδοθούν διαφορετικά. Συνιστάται να δοκιμάσετε τα εφέ που χρησιμοποιείτε και την έκδοση της βιβλιοθήκης.