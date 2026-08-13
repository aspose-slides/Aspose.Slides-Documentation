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

Τα κινούμενα εφέ είναι οπτικά εφέ που μπορούν να εφαρμοστούν σε κείμενα, εικόνες, σχήματα ή [διαγράμματα](/slides/el/net/animated-charts/). Δίνουν ζωή σε παρουσιάσεις ή στα συστατικά τους. 

## **Γιατί να χρησιμοποιείτε κινήσεις σε παρουσιάσεις;**

Χρησιμοποιώντας κινήσεις, μπορείτε  

* να ελέγχετε τη ροή των πληροφοριών  
* να τονίζετε σημαντικά σημεία  
* να αυξάνετε το ενδιαφέρον ή τη συμμετοχή του κοινού σας  
* να κάνετε το περιεχόμενο πιο εύκολο στην ανάγνωση, την απορρόφηση ή την επεξεργασία  
* να προσελκύετε την προσοχή των αναγνωστών ή των θεατών σας στα σημαντικά τμήματα μιας παρουσίασης  

Το PowerPoint παρέχει πολλές επιλογές και εργαλεία για κινήσεις και εφέ κίνησης στις κατηγορίες **entrance**, **exit**, **emphasis**, και **motion paths**. 

## **Κινήσεις στο Aspose.Slides**

* Το Aspose.Slides παρέχει τις κλάσεις και τους τύπους που χρειάζεστε για να εργάζεστε με κινήσεις στο χώρο ονομάτων [Aspose.Slides.Animation](https://reference.aspose.com/slides/el/net/aspose.slides.animation/),  
* Το Aspose.Slides παρέχει πάνω από **150 εφέ κίνησης** στο [EffectType](https://reference.aspose.com/slides/el/net/aspose.slides.animation/effecttype) απαρίθμηση. Αυτά τα εφέ είναι ουσιαστικά τα ίδια (ή ισοδύναμα) εφέ που χρησιμοποιούνται στο PowerPoint.  

## **Εφαρμογή Κίνησης σε TextBox**

Το Aspose.Slides για .NET σας επιτρέπει να εφαρμόσετε κίνηση στο κείμενο ενός σχήματος. 

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](http://www.aspose.com/api/net/slides/el/aspose.slides/).  
2. Αποκτήστε μια αναφορά σε μια διαφάνεια μέσω του δείκτη της.  
3. Προσθέστε ένα `rectangle` [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape).  
4. Προσθέστε κείμενο στο [IAutoShape.TextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/properties/textframe).  
5. Αποκτήστε την κύρια ακολουθία εφέ.  
6. Προσθέστε ένα εφέ κίνησης στο [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape).  
7. Ορίστε την ιδιότητα [TextAnimation.BuildType](https://reference.aspose.com/slides/el/net/aspose.slides.animation/textanimation/properties/buildtype) στην τιμή από το [BuildType Enumeration](https://reference.aspose.com/slides/el/net/aspose.slides.animation/buildtype).  
8. Γράψτε την παρουσίαση στο δίσκο ως αρχείο PPTX.  

Αυτός ο κώδικας C# σας δείχνει πώς να εφαρμόσετε το εφέ `Fade` στο AutoShape και να ορίσετε την κίνηση κειμένου στην τιμή *By 1st Level Paragraphs*:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Δημιουργεί μια παρουσίαση, κλάση που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // Προσθέτει νέο AutoShape με κείμενο
    IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    // Προσθέτει τρεις παραγράφους ώστε η δημιουργία ανά παράγραφο να έχει κάτι για να προχωρήσει.
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "First paragraph";
    textFrame.Paragraphs.Add(new Paragraph { Text = "Second paragraph" });
    textFrame.Paragraphs.Add(new Paragraph { Text = "Third paragraph" });

    // Λαμβάνει την κύρια ακολουθία της διαφάνειας.
    ISequence sequence = sld.Timeline.MainSequence;

    // Προσθέτει εφέ κίνησης Fade στο σχήμα
    IEffect effect = sequence.AddEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Κινεί το κείμενο του σχήματος ανά παραγράφους πρώτου επιπέδου
    effect.TextAnimation.BuildType = BuildType.ByLevelParagraphs1;

    // Αποθηκεύει το αρχείο PPTX στο δίσκο
    pres.Save("AnimTextBox_out.pptx", SaveFormat.Pptx);
}
```

{{%  alert color="info"  %}} 

Εκτός από την εφαρμογή κινήσεων σε κείμενο, μπορείτε επίσης να εφαρμόσετε κινήσεις σε ένα μοναδικό [Paragraph](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraph). Δείτε [**Κινούμενο Κείμενο**](/slides/el/net/animated-text/).

{{% /alert %}} 

## **Εφαρμογή Κίνησης σε PictureFrame**

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](http://www.aspose.com/api/net/slides/el/aspose.slides/).  
2. Αποκτήστε μια αναφορά σε μια διαφάνεια μέσω του δείκτη της.  
3. Προσθέστε ή αποκτήστε ένα [PictureFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ipictureframe) στη διαφάνεια.  
5. Αποκτήστε την κύρια ακολουθία εφέ.  
6. Προσθέστε ένα εφέ κίνησης στο [PictureFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ipictureframe).  
8. Γράψτε την παρουσίαση στο δίσκο ως αρχείο PPTX.  

Αυτός ο κώδικας C# σας δείχνει πώς να εφαρμόσετε το εφέ `Fly` σε ένα πλαίσιο εικόνας:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Δημιουργεί μια παρουσίαση, κλάση που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using (Presentation pres = new Presentation())
{
    // Φορτώνει εικόνα που θα προστεθεί στη συλλογή εικόνων της παρουσίασης
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Προσθέτει πλαίσιο εικόνας στη διαφάνεια
    IPictureFrame picFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Λαμβάνει την κύρια ακολουθία της διαφάνειας.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Προσθέτει εφέ κίνησης Fly από αριστερά στο πλαίσιο εικόνας
    IEffect effect = sequence.AddEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Αποθηκεύει το αρχείο PPTX στο δίσκο
    pres.Save("AnimImage_out.pptx", SaveFormat.Pptx);
}
```

## **Εφαρμογή Κίνησης σε Shape**

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](http://www.aspose.com/api/net/slides/el/aspose.slides/).  
2. Αποκτήστε μια αναφορά σε μια διαφάνεια μέσω του δείκτη της.  
3. Προσθέστε ένα `rectangle` [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape).  
4. Προσθέστε ένα `Bevel` [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape) (όταν αυτό το αντικείμενο κλικάρεται, η κίνηση παίζει).  
5. Δημιουργήστε μια ακολουθία εφέ για το σχήμα bevel.  
6. Δημιουργήστε ένα προσαρμοσμένο `UserPath`.  
7. Προσθέστε εντολές για μετακίνηση στο `UserPath`.  
8. Γράψτε την παρουσίαση στο δίσκο ως αρχείο PPTX.  

Αυτός ο κώδικας C# σας δείχνει πώς να εφαρμόσετε το εφέ `PathFootball` σε ένα σχήμα:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // Δημιουργεί το εφέ PathFootball για υπάρχον σχήμα από το μηδέν.
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

    ashp.AddTextFrame("Animated TextBox");

    // Προσθέτει το εφέ κίνησης PathFootBall.
    pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                           EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Δημιουργεί κάποιο είδος "κουμπί".
    IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Δημιουργεί μια ακολουθία εφέ για το κουμπί.
    ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

    // Δημιουργεί μια προσαρμοσμένη διαδρομή χρήστη. Το αντικείμενό μας θα μετακινηθεί μόνο μετά το κλικ στο κουμπί.
    IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // Προσθέτει εντολές κίνησης επειδή η δημιουργηθείσα διαδρομή είναι κενή.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.Behaviors[0]);

    PointF[] pts = new PointF[1];
    pts[0] = new PointF(0.076f, 0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new PointF(-0.076f, -0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.Path.Add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

    // Αποθηκεύει το αρχείο PPTX στο δίσκο
    pres.Save("AnimExample_out.pptx", SaveFormat.Pptx);
}
```

## **Λήψη των Εφέ Κίνησης που Εφαρμόζονται σε Shape**

Τα παρακάτω παραδείγματα δείχνουν πώς να χρησιμοποιήσετε τη μέθοδο `GetEffectsByShape` από το interface [ISequence](https://reference.aspose.com/slides/el/net/aspose.slides.animation/isequence/) για να λάβετε όλα τα εφέ κίνησης που έχουν εφαρμοστεί σε ένα σχήμα.

**Παράδειγμα 1: Λήψη εφέ κίνησης που εφαρμόζονται σε shape σε κανονική διαφάνεια**

Προηγουμένως, μάθατε πώς να προσθέτετε εφέ κίνησης σε σχήματα σε παρουσιάσεις PowerPoint. Ο παρακάτω κώδικας δείγματος σας δείχνει πώς να λάβετε τα εφέ που έχουν εφαρμοστεί στο πρώτο σχήμα της πρώτης κανονικής διαφάνειας στην παρουσίαση `AnimExample_out.pptx`.

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation("AnimExample_out.pptx"))
{
    ISlide firstSlide = presentation.Slides[0];

    // Λαμβάνει την κύρια ακολουθία κινήσεων της διαφάνειας.
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

Εάν ένα σχήμα σε κανονική διαφάνεια έχει placeholders που βρίσκονται στη διαφάνεια διάταξης και/ή στο master, και έχουν προστεθεί εφέ κίνησης σε αυτά τα placeholders, τότε όλα τα εφέ του σχήματος θα αναπαράγονται κατά τη διάρκεια της παρουσίασης, συμπεριλαμβανομένων των κληρονομημένων εφέ.

Ας υποθέσουμε ότι έχουμε ένα αρχείο παρουσίασης PowerPoint `sample.pptx` με μία διαφάνεια που περιέχει μόνο ένα σχήμα υποσέλιδου με το κείμενο "Made with Aspose.Slides" και το εφέ **Random Bars** έχει εφαρμοστεί στο σχήμα.

![Εφέ κίνησης σχήματος διαφάνειας](slide-shape-animation.png)

Ας υποθέσουμε επίσης ότι το εφέ **Split** έχει εφαρμοστεί στο placeholder υποσέλιδου της **διάταξης**.

![Εφέ κίνησης σχήματος διάταξης](layout-shape-animation.png)

Και τέλος, το εφέ **Fly In** έχει εφαρμοστεί στο placeholder υποσέλιδου του **master**.

![Εφέ κίνησης σχήματος κύριου πρότυπου](master-shape-animation.png)

Ο παρακάτω κώδικας δείγματος σας δείχνει πώς να χρησιμοποιήσετε τη μέθοδο `GetBasePlaceholder` από το interface [IShape](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/) για να έχετε πρόσβαση στα placeholders του σχήματος και να λάβετε τα εφέ κίνησης που έχουν εφαρμοστεί στο σχήμα υποσέλιδου, συμπεριλαμβανομένων των κληρονομημένων εφέ από placeholders που βρίσκονται στις διαφάνειες διάταξης και master.

```cs
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Λαμβάνει τα εφέ κίνησης του σχήματος στην κανονική διαφάνεια.
    IShape shape = slide.Shapes[0];
    IEffect[] shapeEffects = slide.Timeline.MainSequence.GetEffectsByShape(shape);

    // Λαμβάνει τα εφέ κίνησης του placeholder στη διαφάνεια διάταξης.
    IShape layoutShape = shape.GetBasePlaceholder();
    IEffect[] layoutShapeEffects = slide.LayoutSlide.Timeline.MainSequence.GetEffectsByShape(layoutShape);

    // Λαμβάνει τα εφέ κίνησης του placeholder στην κύρια (master) διαφάνεια.
    IShape masterShape = layoutShape.GetBasePlaceholder();
    IEffect[] masterShapeEffects = slide.LayoutSlide.MasterSlide.Timeline.MainSequence.GetEffectsByShape(masterShape);

    Console.WriteLine("Main sequence of shape effects:");
    PrintEffects(masterShapeEffects);
    PrintEffects(layoutShapeEffects);
    PrintEffects(shapeEffects);
}

static void PrintEffects(IEnumerable<IEffect> effects)
{
    foreach (IEffect effect in effects)
    {
        Console.WriteLine($"{effect.Type} {effect.Subtype}");
    }
}
```
```cs
using Aspose.Slides.Animation;

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

## **Αλλαγή Ιδιοτήτων Χρόνου Εφέ Κίνησης**

Το Aspose.Slides για .NET σας επιτρέπει να αλλάξετε τις ιδιότητες Χρόνου ενός εφέ κίνησης.

Αυτή είναι η ενότητα Timing του Animation και το εκτεταμένο μενού στο Microsoft PowerPoint:

![example1_image](shape-animation.png)

Αυτές είναι οι αντιστοιχίες μεταξύ του Timing του PowerPoint και των ιδιοτήτων [Effect.Timing](https://reference.aspose.com/slides/el/net/aspose.slides.animation/effect/properties/timing):

- Η λίστα **Start** του PowerPoint ταιριάζει με την ιδιότητα [Effect.Timing.TriggerType](https://reference.aspose.com/slides/el/net/aspose.slides.animation/itiming/properties/triggertype).  
- Η **Duration** του PowerPoint ταιριάζει με την ιδιότητα [Effect.Timing.Duration](https://reference.aspose.com/slides/el/net/aspose.slides.animation/itiming/properties/duration). Η διάρκεια μιας κίνησης (σε δευτερόλεπτα) είναι ο συνολικός χρόνος που χρειάζεται για να ολοκληρωθεί ένας κύκλος.  
- Η **Delay** του PowerPoint ταιριάζει με την ιδιότητα [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/el/net/aspose.slides.animation/itiming/properties/triggerdelaytime).  
- Η λίστα **Repeat** του PowerPoint ταιριάζει με τις παρακάτω ιδιότητες:  
  * η ιδιότητα [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/el/net/aspose.slides.animation/itiming/repeatcount) που περιγράφει τον *αριθμό* επαναλήψεων του εφέ·  
  * η σημαία [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/el/net/aspose.slides.animation/itiming/repeatuntilendslide) που ορίζει αν το εφέ επαναλαμβάνεται μέχρι το τέλος της διαφάνειας·  
  * η σημαία [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/el/net/aspose.slides.animation/itiming/repeatuntilnextclick) που ορίζει αν το εφέ επαναλαμβάνεται μέχρι το επόμενο κλικ.  
- Το πλαίσιο ελέγχου **Rewind when done playing** του PowerPoint ταιριάζει με την ιδιότητα [Effect.Timing.Rewind](https://reference.aspose.com/slides/el/net/aspose.slides.animation/itiming/rewind/).  

Αυτή είναι η διαδικασία για να αλλάξετε τις ιδιότητες Timing του εφέ:

1. [Εφαρμόστε](#apply-animation-to-shape) ή λάβετε το εφέ κίνησης.  
2. Ορίστε νέες τιμές για τις ιδιότητες [Effect.Timing](https://reference.aspose.com/slides/el/net/aspose.slides.animation/effect/properties/timing) που χρειάζεστε.  
3. Αποθηκεύστε το τροποποιημένο αρχείο PPTX.  

Αυτός ο κώδικας C# επιδεικνύει τη λειτουργία:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // Λαμβάνει την κύρια ακολουθία της διαφάνειας.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Λαμβάνει το πρώτο εφέ της κύριας ακολουθίας.
    IEffect effect = sequence[0];

    // Αλλάζει το TriggerType του εφέ ώστε να ξεκινά με κλικ
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

## **Ήχος Εφέ Κίνησης**

Το Aspose.Slides παρέχει τις παρακάτω ιδιότητες για να εργαστείτε με ήχους σε εφέ κίνησης:  
- [IEffect.Sound](https://reference.aspose.com/slides/el/net/aspose.slides.animation/effect/sound/)  
- [IEffect.StopPreviousSound](https://reference.aspose.com/slides/el/net/aspose.slides.animation/effect/stopprevioussound/)  

### **Προσθήκη Ήχου Εφέ Κίνησης**

Αυτός ο κώδικας C# σας δείχνει πώς να προσθέσετε ήχο σε εφέ κίνησης και να τον σταματήσετε όταν ξεκινά το επόμενο εφέ:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
	// Προσθέτει ήχο στη συλλογή ήχων της παρουσίασης
	IAudio effectSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Λαμβάνει την κύρια ακολουθία της διαφάνειας.
	ISequence sequence = firstSlide.Timeline.MainSequence;

	// Λαμβάνει το πρώτο εφέ της κύριας ακολουθίας
	IEffect firstEffect = sequence[0];

	// Ελέγχει το εφέ για "Χωρίς ήχο"
	if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
	{
		// Προσθέτει ήχο για το πρώτο εφέ
		firstEffect.Sound = effectSound;
	}

	// Λαμβάνει την πρώτη διαδραστική ακολουθία της διαφάνειας.
	ISequence interactiveSequence = firstSlide.Timeline.InteractiveSequences[0];

	// Ορίζει την σημαία "Stop previous sound" του εφέ
	interactiveSequence[0].StopPreviousSound = true;

	// Αποθηκεύει το αρχείο PPTX στο δίσκο
	pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```

### **Εξαγωγή Ήχου Εφέ Κίνησης**

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).  
2. Αποκτήστε μια αναφορά σε μια διαφάνεια μέσω του δείκτη της.  
3. Αποκτήστε την κύρια ακολουθία εφέ.  
4. Εξάγετε τον [Sound](https://reference.aspose.com/slides/el/net/aspose.slides.animation/effect/sound/) που είναι ενσωματωμένος σε κάθε εφέ κίνησης.  

Αυτός ο κώδικας C# σας δείχνει πώς να εξάγετε τον ήχο που ενσωματώνεται σε ένα εφέ κίνησης:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;

// Δημιουργεί μια παρουσίαση, κλάση που αντιπροσωπεύει ένα αρχείο παρουσίασης.
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

## **Μετά την Κίνηση**

Το Aspose.Slides για .NET σας επιτρέπει να αλλάξετε την ιδιότητα After animation ενός εφέ κίνησης.

Αυτή είναι η ενότητα Animation Effect και το εκτεταμένο μενού στο Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

Η λίστα **After animation** του PowerPoint ταιριάζει με τις παρακάτω ιδιότητες:  

- Η ιδιότητα [IEffect.AfterAnimationType](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ieffect/afteranimationtype/) που περιγράφει τον τύπο After animation :  
  * Το **More Colors** του PowerPoint ταιριάζει με τον τύπο [AfterAnimationType.Color](https://reference.aspose.com/slides/el/net/aspose.slides.animation/afteranimationtype/).  
  * Το στοιχείο **Don't Dim** του PowerPoint ταιριάζει με τον τύπο [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/el/net/aspose.slides.animation/afteranimationtype/) (προεπιλεγμένος τύπος).  
  * Το **Hide After Animation** του PowerPoint ταιριάζει με τον τύπο [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/el/net/aspose.slides.animation/afteranimationtype/).  
  * Το **Hide on Next Mouse Click** του PowerPoint ταιριάζει με τον τύπο [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/el/net/aspose.slides.animation/afteranimationtype/).  
- Η ιδιότητα [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ieffect/afteranimationcolor/) που ορίζει τη μορφή χρώματος μετά την κίνηση. Αυτή η ιδιότητα λειτουργεί σε συνδυασμό με τον τύπο [AfterAnimationType.Color](https://reference.aspose.com/slides/el/net/aspose.slides.animation/afteranimationtype/). Αν αλλάξετε τον τύπο, το χρώμα μετά την κίνηση θα διαγραφεί.  

Αυτός ο κώδικας C# σας δείχνει πώς να αλλάξετε ένα εφέ μετά την κίνηση:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Λαμβάνει το πρώτο εφέ της κύριας ακολουθίας
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Αλλάζει το AfterAnimationType σε Color
    firstEffect.AfterAnimationType = AfterAnimationType.Color;

    // Ορίζει το χρώμα μετά την κίνηση
    firstEffect.AfterAnimationColor.Color = Color.AliceBlue;

    // Αποθηκεύει το αρχείο PPTX στο δίσκο
    pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
}
```

## **Κίνηση Κειμένου**

Το Aspose.Slides παρέχει τις παρακάτω ιδιότητες για να εργαστείτε με το μπλοκ *Animate text* ενός εφέ κίνησης:  

- [IEffect.AnimateTextType](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ieffect/animatetexttype/) που περιγράφει τον τύπο animate text του εφέ. Το κείμενο του σχήματος μπορεί να αναπαράγεται:  
  - Όλο ταυτόχρονα ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/el/net/aspose.slides.animation/animatetexttype/) τύπος)  
  - Λέξη προς λέξη ([AnimateTextType.ByWord](https://reference.aspose.com/slides/el/net/aspose.slides.animation/animatetexttype/) τύπος)  
  - Γράμμα προς γράμμα ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/el/net/aspose.slides.animation/animatetexttype/) τύπος)  
- [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ieffect/delaybetweentextparts/) ορίζει καθυστέρηση μεταξύ των τμημάτων του κειμένου (λέξεων ή γραμμάτων). Μία θετική τιμή καθορίζει το ποσοστό της διάρκειας του εφέ. Μία αρνητική τιμή ορίζει τη καθυστέρηση σε δευτερόλεπτα.  

Αυτή είναι η διαδικασία για να αλλάξετε τις ιδιότητες Animate text του εφέ:

1. [Εφαρμόστε](#apply-animation-to-shape) ή λάβετε το εφέ κίνησης.  
2. Ορίστε την ιδιότητα [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/el/net/aspose.slides.animation/itextanimation/buildtype/) στην τιμή [BuildType.AsOneObject](https://reference.aspose.com/slides/el/net/aspose.slides.animation/buildtype/) για να απενεργοποιήσετε τη λειτουργία *By Paragraphs*.  
3. Ορίστε νέες τιμές για τις ιδιότητες [IEffect.AnimateTextType](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ieffect/animatetexttype/) και [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ieffect/delaybetweentextparts/).  
4. Αποθηκεύστε το τροποποιημένο αρχείο PPTX.  

Αυτός ο κώδικας C# επιδεικνύει τη λειτουργία:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using (Presentation pres = new Presentation("AnimTextBox_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Λαμβάνει το πρώτο εφέ της κύριας ακολουθίας
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Αλλάζει τον τύπο κίνησης κειμένου του εφέ σε "As One Object"
    firstEffect.TextAnimation.BuildType = BuildType.AsOneObject;

    // Αλλάζει τον τύπο Animate text του εφέ σε "By word"
    firstEffect.AnimateTextType = AnimateTextType.ByWord;

    // Ορίζει την καθυστέρηση μεταξύ των λέξεων στο 20% της διάρκειας του εφέ
    firstEffect.DelayBetweenTextParts = 20f;

    // Αποθηκεύει το αρχείο PPTX στο δίσκο
    pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
}
```

## **Συχνές Ερωτήσεις**

### Πώς μπορώ να διασφαλίσω ότι οι κινήσεις διατηρούνται όταν δημοσιεύω την παρουσίαση στον ιστό;

[Export to HTML5](/slides/el/net/export-to-html5/) και ενεργοποιήστε τις [options](https://reference.aspose.com/slides/el/net/aspose.slides.export/html5options/) υπεύθυνες για τις [shape](https://reference.aspose.com/slides/el/net/aspose.slides.export/html5options/animateshapes/) και [transition](https://reference.aspose.com/slides/el/net/aspose.slides.export/html5options/animatetransitions/) κινήσεις. Το καθαρό HTML δεν εκτελεί κινήσεις διαφάνειας, ενώ το HTML5 το κάνει.

### Πώς επηρεάζει η αλλαγή της σειράς z‑order (σειράς στρώσεων) των σχημάτων την κίνηση;

Η σειρά εκτέλεσης κινήσεων και η σειρά σχεδίασης είναι ανεξάρτητες: ένα εφέ ελέγχει το χρόνο και τον τύπο εμφάνισης/απόκρυψης, ενώ το [z-order](https://reference.aspose.com/slides/el/net/aspose.slides/shape/zorderposition/) καθορίζει τι καλύπτει τι. Το ορατό αποτέλεσμα ορίζεται από τον συνδυασμό τους. (Αυτή είναι η γενική συμπεριφορά του PowerPoint· το μοντέλο Aspose.Slides ακολουθεί την ίδια λογική.)

### Υπάρχουν περιορισμοί κατά τη μετατροπή κινήσεων σε βίντεο για ορισμένα εφέ;

Γενικά, τα [animations are supported](/slides/el/net/convert-powerpoint-to-video/), αλλά σπάνιες περιπτώσεις ή συγκεκριμένα εφέ μπορεί να αποδοθούν διαφορετικά. Συνίσταται να δοκιμάσετε τα εφέ που χρησιμοποιείτε και την έκδοση της βιβλιοθήκης.