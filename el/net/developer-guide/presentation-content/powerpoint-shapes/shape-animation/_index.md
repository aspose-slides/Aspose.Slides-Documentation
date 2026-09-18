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
description: "Μάθετε πώς να προσθέτετε, ελέγχετε και προσαρμόζετε τις κινήσεις σχημάτων, το χρονισμό, τους ήχους, τη συμπεριφορά μετά το εφέ και το κείμενο με κινήσεις, χρησιμοποιώντας το Aspose.Slides για .NET."
---
## **Επισκόπηση**

Για να δουλέψετε με τις μεμονωμένες συμπεριφορές μέσα σε ένα εφέ ή επεξεργαστείτε τμήματα διαδρομής κίνησης, δείτε [Προσαρμοσμένη Κίνηση](/slides/el/net/custom-animation/).

Το Aspose.Slides for .NET αντιπροσωπεύει τις κινήσεις των διαφανειών ως εφέ σε χρονοδιάγραμμα διαφάνειας. Ένα εφέ έχει ένα σχήμα‑στόχο, έναν τύπο κίνησης και υποτύπο, έναν ενεργοποιητή, ρυθμίσεις χρονισμού και προαιρετικές ιδιότητες όπως ήχος ή συμπεριφορά μετά το εφέ.

Το χρονοδιάγραμμα περιέχει δύο είδη ακολουθιών:

- Η **κύρια ακολουθία** παίζει καθώς προχωρά η διαφάνεια.
- Μία **διαδραστική ακολουθία** ξεκινά όταν κλικάρεται το σχήμα‑ενεργοποιητής.

Επειδή τα πλαίσια κειμένου, οι εικόνες, τα διαγράμματα, οι πίνακες και άλλα αντικείμενα διαφάνειας υλοποιούν το [IShape](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/), χρησιμοποιείτε την ίδια μέθοδο [ISequence.AddEffect](https://reference.aspose.com/slides/el/net/aspose.slides.animation/isequence/addeffect/) για τα περισσότερα περιεχόμενα διαφάνειας. Τα διαθέσιμα εφέ παρατίθενται στην απαρίθμηση [EffectType](https://reference.aspose.com/slides/el/net/aspose.slides.animation/effecttype/).

## **Προσθήκη Κινήσεων Σχημάτων**

Για να προσθέσετε μια κίνηση, πάρτε την κύρια ακολουθία της διαφάνειας και καλέστε την [ISequence.AddEffect](https://reference.aspose.com/slides/el/net/aspose.slides.animation/isequence/addeffect/) με το σχήμα‑στόχο, τον τύπο εφέ, το υποτύπο και τον ενεργοποιητή. Για ένα εφέ που ξεκινά όταν κλικάρεται κάποιο άλλο σχήμα, δημιουργήστε μια διαδραστική ακολουθία της οποίας ο ενεργοποιητής είναι αυτό το άλλο σχήμα.

Το παρακάτω παράδειγμα δημιουργεί και τους δύο τύπους κινήσεων και αποθηκεύει το αποτέλεσμα στο `shape-animations.pptx`.

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

Ο ενεργοποιητής ελέγχει πότε ξεκινά ένα εφέ:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/el/net/aspose.slides.animation/effecttriggertype/) περιμένει κλικ στην κύρια ακολουθία ή κλικ στο σχήμα‑ενεργοποιητή σε μια διαδραστική ακολουθία.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/el/net/aspose.slides.animation/effecttriggertype/) αρχίζει με το προηγούμενο εφέ.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/el/net/aspose.slides.animation/effecttriggertype/) αρχίζει όταν το προηγούμενο εφέ ολοκληρώνεται.

Για να κινήσετε μια εικόνα, ένα γράφημα ή κάποιον άλλο τύπο σχήματος, περάστε αυτό το αντικείμενο στην [ISequence.AddEffect](https://reference.aspose.com/slides/el/net/aspose.slides.animation/isequence/addeffect/) αντί για `targetShape`. Για επιλογές ομαδοποίησης ειδικές για γραφήματα, δείτε [Γραφήματα με Κίνηση](/slides/el/net/animated-charts/).

## **Ανάγνωση Κινήσεων Σχημάτων**

Χρησιμοποιήστε το [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/el/net/aspose.slides.animation/isequence/geteffectsbyshape/) όταν γνωρίζετε το σχήμα‑στόχο. Για να εξετάσετε κάθε εφέ, απαριθμήστε την κύρια ακολουθία και κάθε διαδραστική ακολουθία. Η απαρίθμηση αποτρέπει την υπόθεση ότι μια ακολουθία περιέχει εφέ στη θέση `0`.

Το παρακάτω παράδειγμα δημιουργεί ένα σχήμα με εφέ κύριας και διαδραστικής ακολουθίας, λαμβάνει τα εφέ που στοχεύουν στο σχήμα και στη συνέχεια απαριθμεί κάθε ακολουθία στη διαφάνεια.

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

Αν χρειάζεστε μόνο τα εφέ για ένα σχήμα, πρώτα προσδιορίστε το σχήμα με όνομα, τύπο σύμβολου ή άλλη σταθερή ιδιότητα· έπειτα καλέστε το [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/el/net/aspose.slides.animation/isequence/geteffectsbyshape/). Μην υποθέτετε ότι το [IShapeCollection.Item](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection/item/) στη θέση `0` είναι πάντα το επιθυμητό αντικείμενο.

## **Εργασία με Κληρονομημένα Εφέ Σύμβολων**

Ένα σύμβολο σε μια κανονική διαφάνεια μπορεί να κληρονομήσει τη συμπεριφορά κίνησης από το αντίστοιχο σύμβολο στη διαφάνεια διάταξης και στην κύρια διαφάνεια. Το [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/getbaseplaceholder/) επιστρέφει εκείνο το γονικό σύμβολο ή `null` όταν δεν υπάρχει γονέας.

Στην παρακάτω παρουσίαση παραδείγματος, το υποσέλιδο έχει **Random Bars** στη φυσική διαφάνεια, **Split** στη διαφάνεια διάταξης και **Fly In** στη κύρια διαφάνεια.

![Εφέ κίνησης υποσέλιδου στη φυσική διαφάνεια](slide‑shape‑animation.png)

![Εφέ κίνησης σύμβολου υποσέλιδου στη διαφάνεια διάταξης](layout‑shape‑animation.png)

![Εφέ κίνησης σύμβολου υποσέλιδου στη κύρια διαφάνεια](master‑shape‑animation.png)

Το επόμενο παράδειγμα δημιουργεί την ιεραρχία των συμβόλων. Προσθέτει εφέ σε ένα σύμβολο κύριας διαφάνειας, ένα σύμβολο διάταξης και το αντίστοιχο σύμβολο σε μια κανονική διαφάνεια. Κάθε κλήση στο [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/getbaseplaceholder/) ελέγχεται πριν χρησιμοποιηθεί το επιστρεφόμενο σχήμα.

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

Ο διάλογος **Timing** του PowerPoint αντιστοιχεί στις ιδιότητες του [ITiming](https://reference.aspose.com/slides/el/net/aspose.slides.animation/itiming/).

![Διάλογος Χρόνου PowerPoint για ένα εφέ κίνησης](shape‑animation.png)

- Η **Έναρξη** αντιστοιχεί στο [ITiming.TriggerType](https://reference.aspose.com/slides/el/net/aspose.slides.animation/itiming/triggertype/).
- Η **Δ διάρκεια** αντιστοιχεί στο [ITiming.Duration](https://reference.aspose.com/slides/el/net/aspose.slides.animation/itiming/duration/), σε δευτερόλεπτα.
- Η **Καθυστέρηση** αντιστοιχεί στο [ITiming.TriggerDelayTime](https://reference.aspose.com/slides/el/net/aspose.slides.animation/itiming/triggerdelaytime/), σε δευτερόλεπτα.
- Η **Επανάληψη** αντιστοιχεί στο [ITiming.RepeatCount](https://reference.aspose.com/slides/el/net/aspose.slides.animation/itiming/repeatcount/), [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/el/net/aspose.slides.animation/itiming/repeatuntilnextclick/), ή [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/el/net/aspose.slides.animation/itiming/repeatuntilendslide/).
- Η **Επαναφορά όταν ολοκληρωθεί η αναπαραγωγή** αντιστοιχεί στο [ITiming.Rewind](https://reference.aspose.com/slides/el/net/aspose.slides.animation/itiming/rewind/).

Αυτό το ανεξάρτητο παράδειγμα προσθέτει ένα εφέ, αλλάζει το χρονισμό του μέσω του αντικειμένου που επιστρέφεται από το [ISequence.AddEffect](https://reference.aspose.com/slides/el/net/aspose.slides.animation/isequence/addeffect/), και αποθηκεύει το αποτέλεσμα. Η διατήρηση της επιστρεφόμενης αναφοράς [IEffect](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ieffect/) αποτρέπει έναν μη απαραίτητο δείκτη συλλογής.

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

Χρησιμοποιήστε έναν τρόπο επανάληψης σκόπιμα. Ο συνδυασμός μετρήματος επανάληψης με σημαία «until» μπορεί να παράγει συγκεχυμένα αποτελέσματα σε διαφορετικούς προβολείς. Όταν αλλάζετε τους τρόπους επανάληψης, ορίστε πρώτα το [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/el/net/aspose.slides.animation/itiming/repeatuntilnextclick/) και το [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/el/net/aspose.slides.animation/itiming/repeatuntilendslide/) πριν το [ITiming.RepeatCount](https://reference.aspose.com/slides/el/net/aspose.slides.animation/itiming/repeatcount/), επειδή ο ορισμός οποιασδήποτε σημαίας αλλάζει επίσης τον ενεργό τρόπο επανάληψης.

## **Προσθήκη και Εξαγωγή Ήχων Κίνησης**

Ένα εφέ κίνησης μπορεί να αναφέρεται σε ενσωματωμένο ήχο μέσω του [IEffect.Sound](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ieffect/sound/). Το [IEffect.StopPreviousSound](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ieffect/stopprevioussound/) λέει σε ένα εφέ να σταματήσει ήχο που είχε ξεκινήσει ένα προηγούμενο εφέ.

### **Προσθήκη Ήχου σε Ένα Εφέ**

Το παρακάτω παράδειγμα περιμένει ένα τοπικό αρχείο ήχου με όνομα `animation-sound.wav`. Δημιουργεί δύο εφέ, ενσωματώνει το αρχείο ως ήχο για το πρώτο εφέ και ρυθμίζει το δεύτερο εφέ να σταματάει τον ήχο. Χρησιμοποιεί τα αντικείμενα που επιστρέφονται από το [ISequence.AddEffect](https://reference.aspose.com/slides/el/net/aspose.slides.animation/isequence/addeffect/), έτσι δεν απαιτείται δείκτης ακολουθίας.

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

Το παρακάτω παράδειγμα περιμένει μια τοπική παρουσίαση με όνομα `presentation-with-animation-sounds.pptx`. Σαρώνει τόσο τις κύριες όσο και τις διαδραστικές ακολουθίες και γράφει κάθε ενσωματωμένο ήχο εφέ στον φάκελο `extracted-animation-sounds`. Η επέκταση επιλέγεται από τον τύπο MIME του ήχου που εκτίθεται από το [IAudio.ContentType](https://reference.aspose.com/slides/el/net/aspose.slides/iaudio/contenttype/).

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

Για μεγάλα αρχεία ήχου, χρησιμοποιήστε το [IAudio.GetStream](https://reference.aspose.com/slides/el/net/aspose.slides/iaudio/getstream/) και αντιγράψτε τη ροή σε ένα αρχείο αντί να φορτώσετε ολόκληρο το αντικείμενο σε έναν πίνακα byte.

## **Ορισμός Συμπεριφοράς Μετά το Εφέ**

Η επιλογή **After animation** ελέγχει τι συμβαίνει με ένα σχήμα μετά το τέλος του εφέ του.

![Διάλογος Επιλογών Εφέ PowerPoint που εμφανίζει τις ρυθμίσεις Μετά το εφέ](shape‑after‑animation.png)

Η απαρίθμηση [AfterAnimationType](https://reference.aspose.com/slides/el/net/aspose.slides.animation/afteranimationtype/) υποστηρίζει την διατήρηση του σχήματος αμετάβλητο, την αλλαγή του χρώματός του, την απόκρυψή του μετά την κίνηση, ή την απόκρυψή του στο επόμενο κλικ. Όταν ο τύπος είναι [AfterAnimationType.Color](https://reference.aspose.com/slides/el/net/aspose.slides.animation/afteranimationtype/), ορίστε επίσης το [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ieffect/afteranimationcolor/).

Αυτό το ανεξάρτητο παράδειγμα δημιουργεί ένα εφέ, ορίζει τη συμπεριφορά μετά το εφέ μέσω του επιστρεφόμενου αντικειμένου εφέ και αποθηκεύει το αποτέλεσμα.

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

Η αλλαγή του τύπου από το [AfterAnimationType.Color](https://reference.aspose.com/slides/el/net/aspose.slides.animation/afteranimationtype/) καθαρίζει τη ρύθμιση χρώματος μετά το εφέ.

## **Κίνηση Κειμένου**

Η κίνηση κειμένου έχει δύο σχετικούς ελέγχους:

- Το [ITextAnimation.BuildType](https://reference.aspose.com/slides/el/net/aspose.slides.animation/itextanimation/buildtype/) ελέγχει εάν οι παράγραφοι εμφανίζονται μαζί ή ανά επίπεδο παραγράφου.
- Το [IEffect.AnimateTextType](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ieffect/animatetexttype/) ελέγχει εάν το κείμενο εμφανίζεται ολόκληρο μονομιάς, λέξη‑με‑λέξη ή γράμμα‑με‑γράμμα. Το [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ieffect/delaybetweentextparts/) ορίζει την καθυστέρηση μεταξύ λέξεων ή γραμμάτων. Μια θετική τιμή είναι ποσοστό της διάρκεια του εφέ· μια αρνητική τιμή είναι καθυστέρηση σε δευτερόλεπτα.

Το παρακάτω ανεξάρτητο παράδειγμα κινεί τις λέξεις σε ένα πλαίσιο κειμένου. Το [BuildType.AsOneObject](https://reference.aspose.com/slides/el/net/aspose.slides.animation/buildtype/) απενεργοποιεί την κατασκευή παράγραφος‑από‑παράγραφο, ώστε η ρύθμιση λέξης να ισχύει για ολόκληρο το πλαίσιο κειμένου.

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

Για να χτίσετε ένα πλαίσιο κειμένου παράγραφο‑ προς‑ παράγραφο, ορίστε το [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/el/net/aspose.slides.animation/buildtype/) (ή κάποιο άλλο επίπεδο παραγράφου). Για να στοχεύσετε μια ενιαία παράγραφο με δικό της εφέ, χρησιμοποιήστε την υπερφόρτωση του [ISequence.AddEffect](https://reference.aspose.com/slides/el/net/aspose.slides.animation/isequence/addeffect/) που δέχεται ένα [IParagraph](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraph/). Δείτε το [Animated Text](/slides/el/net/animated-text/) για παραδείγματα επιπέδου παραγράφου.

## **Σημειώσεις Εξαγωγής και Συμβατότητας**

- Η αποθήκευση σε PPT ή PPTX διατηρεί το μοντέλο κίνησης, αλλά η τελική αναπαραγωγή ελέγχεται από τον προβολέα παρουσίασης.
- Το PDF και οι στατικές εικόνες δεν εκτελούν κινήσεις. Χρησιμοποιήστε την [HTML5 export](/slides/el/net/export-to-html5/), animated GIF ή τη [video conversion](/slides/el/net/convert-powerpoint-to-video/) όταν η έξοδος πρέπει να δείχνει κίνηση.
- Για HTML5, ενεργοποιήστε το [Html5Options.AnimateShapes](https://reference.aspose.com/slides/el/net/aspose.slides.export/html5options/animateshapes/) και, εφόσον χρειάζεται, το [Html5Options.AnimateTransitions](https://reference.aspose.com/slides/el/net/aspose.slides.export/html5options/animatetransitions/).
- Η απόδοση βίντεο υποστηρίζει πολλά κοινά εφέ εισόδου, έμφασης, εξόδου και διαδρομής κίνησης, αλλά δεν υποστηρίζονται όλα τα εφέ του PowerPoint. Ελέγξτε τις τρέχουσες [supported animations and effects](/slides/el/net/convert-powerpoint-to-video/#supported-animations-and-effects) και δοκιμάστε κρίσιμες παρουσιάσεις με την έκδοση του Aspose.Slides που στοχεύετε.
- Προηγμένα προσαρμοσμένα εφέ και εφέ που εισάγονται από άλλες μορφές παρουσίασης μπορεί να διατηρηθούν στο αρχείο αλλά να αποδοθούν διαφορετικά στο PowerPoint, HTML5 ή βίντεο. Επικυρώστε το εξαγόμενο αποτέλεσμα αντί να βασίζεστε μόνο στο όνομα του εφέ.

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Γιατί εμφανίζεται μια κίνηση στο PowerPoint αλλά όχι σε PDF;**

Το PDF είναι στατική μορφή, επομένως οι κινήσεις και οι μεταβάσεις διαφάνειας δεν εκτελούνται. Εξάγετε σε HTML5, animated GIF ή βίντεο όταν πρέπει να διατηρηθεί η κίνηση.

**Γιατί ένα εφέ παίζει διαφορετικά σε βίντεο;**

Η εξαγωγή βίντεο αποδίδει τις κινήσεις αντί να αποθηκεύει τη συμπεριφορά του αρχικού PowerPoint. Ορισμένα προχωρημένα εφέ δεν υποστηρίζονται ή προσεγγίζονται. Εξετάστε τον πίνακα των υποστηριζόμενων εφέ και δοκιμάστε την πραγματική παρουσίαση πριν τη χρήση στην παραγωγή.

**Αλλάζει η μετακίνηση ενός σχήματος προς τα εμπρός ή προς τα πίσω τη σειρά των κινήσεων του;**

Όχι. Η σειρά z‑order του σχήματος ελέγχει την επικάλυψη, ενώ η σειρά των ακολουθιών και οι ενεργοποιητές ελέγχουν την αναπαραγωγή της κίνησης. Αλλάξτε το χρονοδιάγραμμα αν χρειάζεστε διαφορετική σειρά αναπαραγωγής.