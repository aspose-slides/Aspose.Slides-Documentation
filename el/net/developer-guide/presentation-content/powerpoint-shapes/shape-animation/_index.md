---
title: Εφαρμογή Κινήσεων Σχημάτων σε Παρουσιάσεις στο .NET
linktitle: Κίνηση Σχήματος
type: docs
weight: 60
url: /el/net/shape-animation/
keywords:
- σχήμα
- κίνηση
- εφέ
- σχήμα με κίνηση
- κείμενο με κίνηση
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
description: "Μάθετε πώς να προσθέτετε, ελέγχετε και προσαρμόζετε κινήσεις σχημάτων, χρονισμούς, ήχους, συμπεριφορά μετά την κίνηση και κείμενο με κίνηση με το Aspose.Slides για .NET."
---
## **Επισκόπηση**

Το Aspose.Slides for .NET αντιπροσωπεύει τις κινήσεις διαφάνειας ως εφέ σε χρονοδιάγραμμα διαφάνειας. Ένα εφέ έχει σχήμα-στόχο, τύπο κίνησης και υποτύπο, ένα ενεργοποιητή, ρυθμίσεις χρονισμού και προαιρετικές ιδιότητες όπως ήχος ή συμπεριφορά μετά το εφέ.

Το χρονοδιάγραμμα περιέχει δύο είδη ακολουθιών:

- Η **κύρια ακολουθία** παίζει καθώς προχωρά η διαφάνεια.
- Μια **διαδραστική ακολουθία** ξεκινά όταν κάνει κλικ στο σχήμα-ενεργοποιητή της.

Επειδή πλαίσια κειμένου, εικόνες, γραφήματα, πίνακες και άλλα αντικείμενα διαφάνειας υλοποιούν το [IShape](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/), χρησιμοποιείτε την ίδια μέθοδο [ISequence.AddEffect](https://reference.aspose.com/slides/el/net/aspose.slides.animation/isequence/addeffect/) για το μεγαλύτερο μέρος του περιεχομένου διαφάνειας. Τα διαθέσιμα εφέ αναφέρονται στην απαρίθμηση [EffectType](https://reference.aspose.com/slides/el/net/aspose.slides.animation/effecttype/).

## **Προσθήκη Κινήσεων Σχημάτων**

Για να προσθέσετε μια κίνηση, λάβετε την κύρια ακολουθία της διαφάνειας και καλέστε την [ISequence.AddEffect](https://reference.aspose.com/slides/el/net/aspose.slides.animation/isequence/addeffect/) με το σχήμα-στόχο, τον τύπο εφέ, τον υποτύπο και τον ενεργοποιητή. Για ένα εφέ που ξεκινά όταν κάνει κλικ σε άλλο σχήμα, δημιουργήστε μια διαδραστική ακολουθία της οποίας ο ενεργοποιητής είναι το συγκεκριμένο σχήμα.

Το παρακάτω παράδειγμα δημιουργεί και τους δύο τύπους κίνησης και αποθηκεύει το αποτέλεσμα στο `shape-animations.pptx`.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var targetShape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 120, 100, 320, 80);
targetShape.TextFrame.Text = "Click to animate this shape";

var mainSequence = slide.Timeline.MainSequence;
var entranceEffect = mainSequence.AddEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
entranceEffect.Timing.Duration = 1.5f;

var triggerShape = slide.Shapes.AddAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
triggerShape.TextFrame.Text = "Move";

var interactiveSequence = slide.Timeline.InteractiveSequences.Add(triggerShape);
interactiveSequence.AddEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

presentation.Save("shape-animations.pptx", SaveFormat.Pptx);
```

Ο ενεργοποιητής ελέγχει πότε αρχίζει ένα εφέ:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/el/net/aspose.slides.animation/effecttriggertype/) περιμένει κλικ στη κύρια ακολουθία ή κλικ στο σχήμα-ενεργοποιητή σε διαδραστική ακολουθία.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/el/net/aspose.slides.animation/effecttriggertype/) ξεκινά με το προηγούμενο εφέ.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/el/net/aspose.slides.animation/effecttriggertype/) ξεκινά όταν ολοκληρωθεί το προηγούμενο εφέ.

Για να ανιματίσετε μια εικόνα, ένα γράφημα ή άλλο τύπο σχήματος, περάστε το αντικείμενο αυτό στην [ISequence.AddEffect](https://reference.aspose.com/slides/el/net/aspose.slides.animation/isequence/addeffect/) αντί για το `targetShape`. Για επιλογές ομαδοποίησης ειδικές για γραφήματα, δείτε το [Animated Charts](/slides/el/net/animated-charts/).

## **Ανάγνωση Κινήσεων Σχημάτων**

Χρησιμοποιήστε την [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/el/net/aspose.slides.animation/isequence/geteffectsbyshape/) όταν γνωρίζετε το σχήμα-στόχο. Για να ελέγξετε κάθε εφέ, κάντε επανάληψη στη κύρια ακολουθία και σε κάθε διαδραστική ακολουθία. Η επανάληψη αποφεύγει την υπόθεση ότι μια ακολουθία περιέχει εφέ στο ευρετήριο `0`.

Το παρακάτω παράδειγμα δημιουργεί ένα σχήμα με εφέ κύριας ακολουθίας και διαδραστικής ακολουθίας, παίρνει τα εφέ που στοχεύουν το σχήμα και, στη συνέχεια, κάνει επανάληψη σε κάθε ακολουθία της διαφάνειας.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
targetShape.TextFrame.Text = "Animated shape";

var mainSequence = slide.Timeline.MainSequence;
mainSequence.AddEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

var triggerShape = slide.Shapes.AddAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
triggerShape.TextFrame.Text = "Move";

var interactiveSequence = slide.Timeline.InteractiveSequences.Add(triggerShape);
interactiveSequence.AddEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

var targetEffects = mainSequence.GetEffectsByShape(targetShape);
Console.WriteLine($"The main sequence contains {targetEffects.Length} effect(s) for {targetShape.Name}.");

PrintSequence("Main sequence", mainSequence);

var interactiveIndex = 1;
foreach (var sequence in slide.Timeline.InteractiveSequences)
{
    var triggerName = sequence.TriggerShape == null ? "unknown" : sequence.TriggerShape.Name;
    var sequenceLabel = $"Interactive sequence {interactiveIndex}, trigger: {triggerName}";
    PrintSequence(sequenceLabel, sequence);
    interactiveIndex++;
}

static void PrintSequence(string label, ISequence sequence)
{
    Console.WriteLine($"  {label}: {sequence.Count} effect(s)");

    foreach (var effect in sequence)
    {
        var targetName = effect.TargetShape == null ? "unknown" : effect.TargetShape.Name;
        var effectDescription = $"{effect.Type} {effect.Subtype}; target: {targetName}; trigger: {effect.Timing.TriggerType}";
        Console.WriteLine($"    {effectDescription}");
    }
}
```

Αν χρειάζεστε μόνο τα εφέ για ένα σχήμα, προσδιορίστε πρώτα το σχήμα με όνομα, τύπο placeholder ή άλλη σταθερή ιδιότητα· έπειτα καλέστε την [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/el/net/aspose.slides.animation/isequence/geteffectsbyshape/). Μην υποθέτετε ότι το [IShapeCollection.Item](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection/item/) στο ευρετήριο `0` είναι πάντα το επιθυμητό αντικείμενο.

## **Εργασία με Κληρονομημένα Εφέ Placeholder**

Ένα placeholder σε κανονική διαφάνεια μπορεί να κληρονομήσει τη συμπεριφορά κίνησης από το αντίστοιχο placeholder στη διάταξη και στο master. Η [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/getbaseplaceholder/) επιστρέφει το γονικό placeholder ή `null` όταν δεν υπάρχει γονέας.

Στο παρακάτω παράδειγμα παρουσίασης, το υποσέλιδο έχει **Random Bars** στη κανονική διαφάνεια, **Split** στη διαφάνεια διάταξης και **Fly In** στη master.

![Footer animation effect on the normal slide](slide-shape-animation.png)

![Footer placeholder animation effect on the layout slide](layout-shape-animation.png)

![Footer placeholder animation effect on the master slide](master-shape-animation.png)

Το επόμενο παράδειγμα κατασκευάζει τη ιεραρχία των placeholder. Προσθέτει εφέ σε ένα master placeholder, ένα layout placeholder και το αντίστοιχο placeholder σε κανονική διαφάνεια. Κάθε κλήση στην [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/getbaseplaceholder/) ελέγχεται πριν χρησιμοποιηθεί το επιστρεφόμενο σχήμα.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
var layoutPlaceholder = layoutSlide.PlaceholderManager.AddTextPlaceholder(100, 100, 400, 80);
layoutSlide.Timeline.MainSequence.AddEffect(layoutPlaceholder, EffectType.Split, EffectSubtype.VerticalIn, EffectTriggerType.OnClick);

var masterPlaceholder = layoutPlaceholder.GetBasePlaceholder();
if (masterPlaceholder != null)
{
    var masterSequence = layoutSlide.MasterSlide.Timeline.MainSequence;
    masterSequence.AddEffect(masterPlaceholder, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
}

var slide = presentation.Slides.AddEmptySlide(layoutSlide);
var slidePlaceholder = FindPlaceholderWithBase(slide);

if (slidePlaceholder == null)
{
    throw new InvalidOperationException("The slide does not contain a placeholder linked to its layout slide.");
}

slide.Timeline.MainSequence.AddEffect(slidePlaceholder, EffectType.RandomBars, EffectSubtype.Horizontal, EffectTriggerType.OnClick);
PrintEffects("Normal slide", slide.Timeline.MainSequence.GetEffectsByShape(slidePlaceholder));

var baseLayoutPlaceholder = slidePlaceholder.GetBasePlaceholder();
if (baseLayoutPlaceholder != null)
{
    PrintEffects("Layout slide", layoutSlide.Timeline.MainSequence.GetEffectsByShape(baseLayoutPlaceholder));

    var baseMasterPlaceholder = baseLayoutPlaceholder.GetBasePlaceholder();
    if (baseMasterPlaceholder != null)
    {
        PrintEffects("Master slide", layoutSlide.MasterSlide.Timeline.MainSequence.GetEffectsByShape(baseMasterPlaceholder));
    }
}

presentation.Save("placeholder-animations.pptx", SaveFormat.Pptx);

static IShape FindPlaceholderWithBase(ISlide slide)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape.GetBasePlaceholder() != null)
        {
            return shape;
        }
    }

    return null;
}

static void PrintEffects(string source, IEffect[] effects)
{
    Console.WriteLine($"{source}: {effects.Length} effect(s)");

    foreach (var effect in effects)
    {
        Console.WriteLine($"  {effect.Type} {effect.Subtype}");
    }
}
```

## **Αλλαγή Χρονισμού Κίνησης**

Το διάλογο **Timing** του PowerPoint αντιστοιχεί στις ιδιότητες της [ITiming](https://reference.aspose.com/slides/el/net/aspose.slides.animation/itiming/).

![PowerPoint Timing dialog for an animation effect](shape-animation.png)

- **Start** αντιστοιχεί στο [ITiming.TriggerType](https://reference.aspose.com/slides/el/net/aspose.slides.animation/itiming/triggertype/).
- **Duration** αντιστοιχεί στο [ITiming.Duration](https://reference.aspose.com/slides/el/net/aspose.slides.animation/itiming/duration/), σε δευτερόλεπτα.
- **Delay** αντιστοιχεί στο [ITiming.TriggerDelayTime](https://reference.aspose.com/slides/el/net/aspose.slides.animation/itiming/triggerdelaytime/), σε δευτερόλεπτα.
- **Repeat** αντιστοιχεί στο [ITiming.RepeatCount](https://reference.aspose.com/slides/el/net/aspose.slides.animation/itiming/repeatcount/), στο [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/el/net/aspose.slides.animation/itiming/repeatuntilnextclick/) ή στο [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/el/net/aspose.slides.animation/itiming/repeatuntilendslide/).
- **Rewind when done playing** αντιστοιχεί στο [ITiming.Rewind](https://reference.aspose.com/slides/el/net/aspose.slides.animation/itiming/rewind/).

Αυτό το ανεξάρτητο παράδειγμα προσθέτει ένα εφέ, αλλάζει το χρονισμό του μέσω του αντικειμένου που επιστρέφει η [ISequence.AddEffect](https://reference.aspose.com/slides/el/net/aspose.slides.animation/isequence/addeffect/), και αποθηκεύει το αποτέλεσμα. Η διατήρηση της αναφοράς προς το [IEffect](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ieffect/) αποτρέπει μια περιττή πρόσβαση σε δείκτη συλλογής.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
shape.TextFrame.Text = "Timed animation";

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Timing.TriggerType = EffectTriggerType.OnClick;
effect.Timing.Duration = 2.0f;
effect.Timing.TriggerDelayTime = 0.5f;
effect.Timing.RepeatUntilNextClick = false;
effect.Timing.RepeatUntilEndSlide = false;
effect.Timing.RepeatCount = 2.0f;
effect.Timing.Rewind = true;

presentation.Save("shape-animation-timing.pptx", SaveFormat.Pptx);
```

Χρησιμοποιήστε έναν τρόπο επανάληψης σκόπιμα. Ο συνδυασμός μετρήτρου επανάληψης με σημείο «μέχρι» μπορεί να οδηγήσει σε ασάφια σε διαφορετικούς προβολείς. Κατά την αλλαγή τρόπων επανάληψης, ορίστε πρώτα το [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/el/net/aspose.slides.animation/itiming/repeatuntilnextclick/) και το [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/el/net/aspose.slides.animation/itiming/repeatuntilendslide/) πριν το [ITiming.RepeatCount](https://reference.aspose.com/slides/el/net/aspose.slides.animation/itiming/repeatcount/), καθώς η ρύθμιση οποιουδήποτε σημαίας αλλάζει επίσης τη λειτουργική κατάσταση επανάληψης.

## **Προσθήκη και Εξαγωγή Ήχων Κίνησης**

Ένα εφέ κίνησης μπορεί να παραπέμπει σε ενσωματωμένο ήχο μέσω του [IEffect.Sound](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ieffect/sound/). Το [IEffect.StopPreviousSound](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ieffect/stopprevioussound/) λέει στο εφέ να διακόψει ήχο που ξεκίνησε ένα προηγούμενο εφέ.

### **Προσθήκη Ήχου σε Εφέ**

Το παρακάτω παράδειγμα απαιτεί τοπικό αρχείο ήχου ονόματι `animation-sound.wav`. Δημιουργεί δύο εφέ, ενσωματώνει το αρχείο ως ήχο για το πρώτο εφέ και ρυθμίζει το δεύτερο εφέ να σταματά τον ήχο. Χρησιμοποιεί τα αντικείμενα που επιστρέφει η [ISequence.AddEffect](https://reference.aspose.com/slides/el/net/aspose.slides.animation/isequence/addeffect/), οπότε δεν απαιτείται δείκτης ακολουθίας.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var firstShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 100, 240, 80);
var secondShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 400, 100, 240, 80);
firstShape.TextFrame.Text = "Starts sound";
secondShape.TextFrame.Text = "Stops sound";

var sequence = slide.Timeline.MainSequence;
var firstEffect = sequence.AddEffect(firstShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
var secondEffect = sequence.AddEffect(secondShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

var audioData = File.ReadAllBytes("animation-sound.wav");
var effectSound = presentation.Audios.AddAudio(audioData);
firstEffect.Sound = effectSound;
secondEffect.StopPreviousSound = true;

presentation.Save("shape-animation-sound.pptx", SaveFormat.Pptx);
```

### **Εξαγωγή Ενσωματωμένων Ήχων Εφέ**

Το παρακάτω παράδειγμα απαιτεί μια τοπική παρουσίαση ονόματι `presentation-with-animation-sounds.pptx`. Σαρώνει τόσο την κύρια όσο και τη διαδραστική ακολουθία και γράφει κάθε ενσωματωμένο ήχο εφέ στον φάκελο `extracted-animation-sounds`. Η επέκταση επιλέγεται από τον τύπο MIME του ήχου που εκθέτει το [IAudio.ContentType](https://reference.aspose.com/slides/el/net/aspose.slides/iaudio/contenttype/).

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;

var inputPath = "presentation-with-animation-sounds.pptx";
var outputDirectory = "extracted-animation-sounds";

Directory.CreateDirectory(outputDirectory);

using var presentation = new Presentation(inputPath);
var soundIndex = 1;

foreach (var slide in presentation.Slides)
{
    SaveSounds(slide.Timeline.MainSequence, outputDirectory, ref soundIndex);

    foreach (var sequence in slide.Timeline.InteractiveSequences)
    {
        SaveSounds(sequence, outputDirectory, ref soundIndex);
    }
}

Console.WriteLine($"Extracted {soundIndex - 1} sound file(s) to {Path.GetFullPath(outputDirectory)}.");

static void SaveSounds(ISequence sequence, string outputDirectory, ref int soundIndex)
{
    foreach (var effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        var extension = GetAudioExtension(effect.Sound.ContentType);
        var outputPath = Path.Combine(outputDirectory, $"effect-sound-{soundIndex}{extension}");
        File.WriteAllBytes(outputPath, effect.Sound.BinaryData);
        soundIndex++;
    }
}

static string GetAudioExtension(string contentType)
{
    var normalizedType = contentType == null ? string.Empty : contentType.ToLowerInvariant();

    if (normalizedType == "audio/mpeg")
        return ".mp3";

    if (normalizedType == "audio/mp4")
        return ".m4a";

    if (normalizedType == "audio/ogg")
        return ".ogg";

    if (normalizedType == "audio/wav" || normalizedType == "audio/x-wav")
        return ".wav";

    return ".bin";
}
```

Για μεγάλα αντικείμενα ήχου, χρησιμοποιήστε το [IAudio.GetStream](https://reference.aspose.com/slides/el/net/aspose.slides/iaudio/getstream/) και αντιγράψτε τη ροή σε αρχείο αντί να φορτώσετε ολόκληρο το αντικείμενο σε πίνακα byte.

## **Ορισμός Συμπεριφοράς Μετά την Κίνηση**

Η επιλογή **After animation** ελέγχει τι συμβαίνει με ένα σχήμα μετά το τέλος του εφέ.

![PowerPoint Effect Options dialog showing After animation settings](shape-after-animation.png)

Η απαρίθμηση [AfterAnimationType](https://reference.aspose.com/slides/el/net/aspose.slides.animation/afteranimationtype/) υποστηρίζει την διατήρηση του σχήματος αμετάβλητου, την αλλαγή του χρώματος, την απόκρυψη του μετά την κίνηση ή την απόκρυψη του με το επόμενο κλικ. Όταν ο τύπος είναι [AfterAnimationType.Color](https://reference.aspose.com/slides/el/net/aspose.slides.animation/afteranimationtype/), ορίστε επίσης το [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ieffect/afteranimationcolor/).

Αυτό το ανεξάρτητο παράδειγμα δημιουργεί ένα εφέ, ορίζει τη συμπεριφορά μετά την κίνηση μέσω του αντικειμένου εφέ που επιστρέφεται, και αποθηκεύει το αποτέλεσμα.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
shape.TextFrame.Text = "Dim after animation";

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.AfterAnimationType = AfterAnimationType.Color;
effect.AfterAnimationColor.Color = Color.LightGray;

presentation.Save("shape-animation-after-effect.pptx", SaveFormat.Pptx);
```

Η αλλαγή του τύπου από το [AfterAnimationType.Color](https://reference.aspose.com/slides/el/net/aspose.slides.animation/afteranimationtype/) καθαρίζει τη ρύθμιση χρώματος μετά την κίνηση.

## **Κίνηση Κειμένου**

Η κίνηση κειμένου διαθέτει δύο σχετιζόμενους ελέγχους:

- Το [ITextAnimation.BuildType](https://reference.aspose.com/slides/el/net/aspose.slides.animation/itextanimation/buildtype/) ελέγχει αν οι παράγραφοι εμφανίζονται μαζί ή ανά επίπεδο παραγράφου.
- Το [IEffect.AnimateTextType](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ieffect/animatetexttype/) ελέγχει αν το κείμενο εμφανίζεται ολόκληρο, ανά λέξη ή ανά γράμμα. Το [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ieffect/delaybetweentextparts/) ορίζει την καθυστέρηση μεταξύ λέξεων ή γραμμάτων. Μία θετική τιμή είναι ποσοστό της διάρκειας του εφέ· μια αρνητική τιμή είναι καθυστέρηση σε δευτερόλεπτα.

Το παρακάτω ανεξάρτητο παράδειγμα κινεί τις λέξεις σε ένα πλαίσιο κειμένου. Το [BuildType.AsOneObject](https://reference.aspose.com/slides/el/net/aspose.slides.animation/buildtype/) απενεργοποιεί το χτίσιμο ανά παράγραφο ώστε η ρύθμιση λέξης να ισχύει για όλο το κείμενο.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 560, 100);
textBox.TextFrame.Text = "Aspose.Slides animates this sentence word by word.";

var effect = slide.Timeline.MainSequence.AddEffect(textBox, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.TextAnimation.BuildType = BuildType.AsOneObject;
effect.AnimateTextType = AnimateTextType.ByWord;
effect.DelayBetweenTextParts = 20.0f;

presentation.Save("animated-text.pptx", SaveFormat.Pptx);
```

Για χτίσιμο πλαισίου κειμένου ανά παράγραφο, ορίστε το [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/el/net/aspose.slides.animation/buildtype/) (ή άλλο επίπεδο παραγράφου). Για να στοχεύσετε μία μόνο παράγραφο με δικό της εφέ, χρησιμοποιήστε την υπερφόρτωση της [ISequence.AddEffect](https://reference.aspose.com/slides/el/net/aspose.slides.animation/isequence/addeffect/) που δέχεται ένα [IParagraph](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraph/). Δείτε το [Animated Text](/slides/el/net/animated-text/) για παραδείγματα επιπέδου παραγράφου.

## **Εξαγωγή και Σημειώσεις Συμβατότητας**

- Η αποθήκευση σε PPT ή PPTX διατηρεί το μοντέλο κίνησης, αλλά η τελική αναπαραγωγή ελέγχεται από τον προβολέα παρουσίασης.
- Τα PDF και οι στατικές εικόνες δεν παίζουν κίνησεις. Χρησιμοποιήστε την [HTML5 export](/slides/el/net/export-to-html5/), animated GIF ή τη [video conversion](/slides/el/net/convert-powerpoint-to-video/) όταν η έξοδος πρέπει να δείχνει κίνηση.
- Για HTML5, ενεργοποιήστε το [Html5Options.AnimateShapes](https://reference.aspose.com/slides/el/net/aspose.slides.export/html5options/animateshapes/) και, κατά ανάγκη, το [Html5Options.AnimateTransitions](https://reference.aspose.com/slides/el/net/aspose.slides.export/html5options/animatetransitions/).
- Η απόδοση βίντεο υποστηρίζει πολλούς συνηθισμένους εφέ είσοδος, έμφαση, έξοδος και διαδρομές κίνησης, αλλά δεν υποστηρίζει κάθε εφέ του PowerPoint. Ελέγξτε τις τρέχουσες [supported animations and effects](/slides/el/net/convert-powerpoint-to-video/#supported-animations-and-effects) και δοκιμάστε κρίσιμες παρουσιάσεις με την έκδοση Aspose.Slides που χρησιμοποιείτε.
- Προηγμένα προσαρμοσμένα εφέ και εφέ που έχουν εισαχθεί από άλλες μορφές παρουσίασης μπορεί να διατηρηθούν στο αρχείο αλλά να αποδοθούν διαφορετικά σε PowerPoint, HTML5 ή βίντεο. Επαληθεύστε το εξαγόμενο αποτέλεσμα αντί να βασίζεστε μόνο στο όνομα του εφέ.

## **Συχνές Ερωτήσεις**

**Γιατί ένα εφέ εμφανίζεται στο PowerPoint αλλά όχι σε PDF;**

Το PDF είναι στατική μορφή, επομένως οι κινήσεις και οι μεταβάσεις διαφάνειας δεν παίζουν. Εξάγετε σε HTML5, animated GIF ή βίντεο όταν πρέπει να διατηρηθεί η κίνηση.

**Γιατί ένα εφέ παίζει διαφορετικά σε βίντεο;**

Η εξαγωγή βίντεο αποδίδει τις κινήσεις αντί να αποθηκεύει την αρχική συμπεριφορά του PowerPoint. Ορισμένα προχωρημένα εφέ δεν υποστηρίζονται ή προσεγγίζονται. Εξετάστε τον πίνακα υποστηριζόμενων εφέ και δοκιμάστε την παρουσίαση πριν από την παραγωγική χρήση.

**Αλλάζει η μετατόπιση ενός σχήματος προς τα εμπρός ή προς τα πίσω τη σειρά των κινήσεων;**

Όχι. Η σειρά z-order ελέγχει την επικάλυψη, ενώ η σειρά ακολουθίας και οι ενεργοποιητές ελέγχουν την αναπαραγωγή των κινήσεων. Αλλάξτε το χρονοδιάγραμμα αν χρειάζεστε διαφορετική σειρά αναπαραγωγής.