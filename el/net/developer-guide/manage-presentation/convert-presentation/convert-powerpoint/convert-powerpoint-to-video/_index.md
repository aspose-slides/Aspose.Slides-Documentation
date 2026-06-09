---
title: Μετατροπή παρουσιάσεων PowerPoint σε βίντεο στο .NET
linktitle: PowerPoint σε βίντεο
type: docs
weight: 130
url: /el/net/convert-powerpoint-to-video/
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
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς να μετατρέπετε παρουσιάσεις PowerPoint σε βίντεο στο .NET. Ανακαλύψτε δείγματα κώδικα C# και τεχνικές αυτοματοποίησης για να βελτιώσετε τη ροή εργασίας σας."
---
## **Εισαγωγή**

Με τη μετατροπή της παρουσίασής σας PowerPoint ή OpenDocument σε βίντεο, κερδίζετε:

**Αυξημένη προσβασιμότητα:** Όλες οι συσκευές, ανεξαρτήτως πλατφόρμας, διαθέτουν προεγκατεστημένους αναπαραγωγείς βίντεο, καθιστώντας πιο εύκολο για τους χρήστες το άνοιγμα ή την αναπαραγωγή βίντεο σε σύγκριση με τις παραδοσιακές εφαρμογές παρουσίασης.

**Μεγαλύτερη εμβέλεια:** Τα βίντεο σας επιτρέπουν να προσεγγίσετε ένα ευρύτερο κοινό και να παρουσιάσετε πληροφορίες με πιο ελκυστικό τρόπο. Έρευνες και στατιστικά δείχνουν ότι οι άνθρωποι προτιμούν την παρακολούθηση και κατανάλωση βίντεο σε σχέση με άλλες μορφές, καθιστώντας το μήνυμά σας πιο αποτελεσματικό.

{{% alert color="primary" %}} 

Δείτε τον [**Μετατροπέα PowerPoint σε Βίντεο Online**](https://products.aspose.app/slides/el/video) επειδή προσφέρει μια ζωντανή και αποτελεσματική υλοποίηση της διαδικασίας που περιγράφεται εδώ.

{{% /alert %}} 

Στο Aspose.Slides for .NET, υλοποιήσαμε υποστήριξη για τη μετατροπή παρουσιάσεων σε βίντεο.

* Χρησιμοποιήστε το Aspose.Slides for .NET για να δημιουργήσετε καρέ από τις διαφάνειες της παρουσίασης με καθορισμένο ρυθμό καρέ (FPS).
* Στη συνέχεια, χρησιμοποιήστε ένα εργαλείο τρίτου μέρους όπως το ffmpeg για να συναρμολογήσετε αυτά τα καρέ σε βίντεο.

## **Μετατροπή Παρουσίασης PowerPoint σε Βίντεο**

1. Χρησιμοποιήστε την εντολή `dotnet add package` για να προσθέσετε το Aspose.Slides και τη βιβλιοθήκη FFMpegCore στην εφαρμογή σας:
   * εκτελέστε `dotnet add package Aspose.Slides.NET --version 22.11.0`
   * εκτελέστε `dotnet add package FFMpegCore --version 4.8.0`
2. Κατεβάστε το ffmpeg από [εδώ](https://ffmpeg.org/download.html).
3. Το FFMpegCore απαιτεί να καθορίσετε τη διαδρομή προς το ληφθέν ffmpeg (π.χ., εξαγμένο στο "C:\tools\ffmpeg"):  
```cs
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });
```
4. Εκτελέστε τον κώδικα μετατροπής PowerPoint‑σε‑βίντεο.

Αυτός ο κώδικας C# δείχνει πώς να μετατρέψετε μια παρουσίαση (με ένα σχήμα και δύο εφέ κίνησης) σε βίντεο:

```c#
using System.Collections.Generic;
using Aspose.Slides;
using FFMpegCore; // θα χρησιμοποιήσει τα εκτελέσιμα του FFmpeg που εξάγαμε στο C:\tools\ffmpeg νωρίτερα.
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Προσθέστε ένα σχήμα χαμόγελου και στη συνέχεια το κινήστε.
    IAutoShape smile = slide.Shapes.AddAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);

    IEffect effectIn = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);

    IEffect effectOut = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);

    effectIn.Timing.Duration = 2f;
    effectOut.PresetClassType = EffectPresetClassType.Exit;

    const int Fps = 33;
    List<string> frames = new List<string>();

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    using (var player = new PresentationPlayer(animationsGenerator, Fps))
    {
        player.FrameTick += (sender, args) =>
        {
            string frame = $"frame_{(sender.FrameIndex):D4}.png";
            args.GetFrame().Save(frame);
            frames.Add(frame);
        };
        animationsGenerator.Run(presentation.Slides);
    }

    // Ρυθμίστε το φάκελο των εκτελέσιμων ffmpeg. Δείτε αυτή τη σελίδα: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // Μετατρέψτε τα καρέ σε βίντεο webm.
    FFMpeg.JoinImageSequence("smile.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **Εφέ Βίντεο**

Κατά τη μετατροπή μιας παρουσίασης PowerPoint σε βίντεο με το Aspose.Slides for .NET, μπορείτε να εφαρμόσετε διάφορα εφέ βίντεο για να ενισχύσετε την οπτική ποιότητα του αποτελέσματος. Αυτά τα εφέ σας επιτρέπουν να ελέγξετε την εμφάνιση των διαφανειών στο τελικό βίντεο προσθέτοντας ομαλές μεταβάσεις, κινήσεις και άλλα οπτικά στοιχεία. Αυτή η ενότητα εξηγεί τις διαθέσιμες επιλογές εφέ βίντεο και δείχνει πώς να τις εφαρμόσετε.

{{% alert color="primary" %}} 

Δείτε:
- [Βελτιώνοντας Παρουσιάσεις PowerPoint με Κινήσεις σε C#](https://docs.aspose.com/slides/el/net/powerpoint-animation/)
- [Κίνηση Σχήματος](https://docs.aspose.com/slides/el/net/shape-animation/)
- [Εφαρμογή Εφέ Σχήματος σε PowerPoint με C#](https://docs.aspose.com/slides/el/net/shape-effect/)

{{% /alert %}} 

Οι κινήσεις και οι μεταβάσεις κάνουν τις διαφάνειες πιο δελεαστικές· το ίδιο ισχύει και για τα βίντεο. Ας προσθέσουμε μια ακόμη διαφάνεια και μια μετάβαση στον κώδικα της προηγούμενης παρουσίασης:

```c#
 // Προσθέστε ένα σχήμα χαμόγελου και το κινήστε.
 // ...

 // Προσθέστε μια νέα διαφάνεια και μια κινητική μετάβαση.
 ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
 newSlide.Background.Type = BackgroundType.OwnBackground;
 newSlide.Background.FillFormat.FillType = FillType.Solid;
 newSlide.Background.FillFormat.SolidFillColor.Color = Color.Indigo;
 newSlide.SlideShowTransition.Type = TransitionType.Push;
```

Το Aspose.Slides υποστηρίζει επίσης κινήσεις κειμένου. Σε αυτό το παράδειγμα, κινουμε παραγράφους σε αντικείμενα ώστε να εμφανίζονται η μία μετά την άλλη, με καθυστέρηση ενός δευτερολέπτου μεταξύ τους:

```c#
using System.Collections.Generic;
using Aspose.Slides.Export;
using Aspose.Slides;
using FFMpegCore;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Προσθέστε κείμενο και κινήσεις.
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.Portions.Add(new Portion("Aspose Slides for .NET"));
    Paragraph para2 = new Paragraph();
    para2.Portions.Add(new Portion("Convert a PowerPoint presentation with text to video"));

    Paragraph para3 = new Paragraph();
    para3.Portions.Add(new Portion("paragraph by paragraph"));
    autoShape.TextFrame.Paragraphs.Add(para1);
    autoShape.TextFrame.Paragraphs.Add(para2);
    autoShape.TextFrame.Paragraphs.Add(para3);
    autoShape.TextFrame.Paragraphs.Add(new Paragraph());

    IEffect effect1 = slide.Timeline.MainSequence.AddEffect(
        para1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect2 = slide.Timeline.MainSequence.AddEffect(
        para2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect3 = slide.Timeline.MainSequence.AddEffect(
        para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect4 = slide.Timeline.MainSequence.AddEffect(
        para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    effect1.Timing.TriggerDelayTime = 1f;
    effect2.Timing.TriggerDelayTime = 1f;
    effect3.Timing.TriggerDelayTime = 1f;
    effect4.Timing.TriggerDelayTime = 1f;

    const int Fps = 33;
    List<string> frames = new List<string>();

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    using (var player = new PresentationPlayer(animationsGenerator, Fps))
    {
        player.FrameTick += (sender, args) =>
        {
            string frame = $"frame_{(sender.FrameIndex):D4}.png";
            args.GetFrame().Save(frame);
            frames.Add(frame);
        };

        animationsGenerator.Run(presentation.Slides);
    }

    // Ρυθμίστε το φάκελο των εκτελέσιμων ffmpeg. Δείτε αυτή τη σελίδα: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // Μετατρέψτε τα καρέ σε βίντεο webm.
    FFMpeg.JoinImageSequence("text_animation.webv", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **Κλάσεις Μετατροπής Βίντεο**

Για να εκτελέσετε εργασίες μετατροπής PowerPoint σε βίντεο, το Aspose.Slides for .NET παρέχει τις κλάσεις [PresentationAnimationsGenerator](https://reference.aspose.com/slides/el/net/aspose.slides.export/presentationanimationsgenerator/) και [PresentationPlayer](https://reference.aspose.com/slides/el/net/aspose.slides.export/presentationplayer/).

`PresentationAnimationsGenerator` σας επιτρέπει να ορίσετε το μέγεθος του καρέ για το βίντεο (που θα δημιουργηθεί αργότερα) και την τιμή FPS (καρέ ανά δευτερόλεπτο) μέσω του κατασκευαστή του. Αν περάσετε μια παρουσίαση, θα χρησιμοποιηθεί το `Presentation.SlideSize` της και θα δημιουργήσει κινήσεις που χρησιμοποιεί η [PresentationPlayer](https://reference.aspose.com/slides/el/net/aspose.slides.export/presentationplayer/).

Όταν δημιουργούνται κινήσεις, προκαλείται το συμβάν `NewAnimation` για κάθε επόμενη κίνηση, το οποίο περιλαμβάνει μια παράμετρο τύπου [IPresentationAnimationPlayer](https://reference.aspose.com/slides/el/net/aspose.slides.export/ipresentationanimationplayer/). Αυτή η κλάση αντιπροσωπεύει έναν παίκτη για μια μεμονωμένη κίνηση.

Για να εργαστείτε με το [IPresentationAnimationPlayer](https://reference.aspose.com/slides/el/net/aspose.slides.export/ipresentationanimationplayer/), χρησιμοποιείτε την ιδιότητα [Duration](https://reference.aspose.com/slides/el/net/aspose.slides.export/ipresentationanimationplayer/duration/) (που δίνει τη συνολική διάρκεια της κίνησης) και τη μέθοδο [SetTimePosition](https://reference.aspose.com/slides/el/net/aspose.slides.export/ipresentationanimationplayer/settimeposition/). Κάθε θέση κίνησης ορίζεται μέσα στο εύρος *0 έως duration*, και η μέθοδος `GetFrame` επιστρέφει ένα Bitmap που αντιπροσωπεύει την κατάσταση της κίνησης εκείνη τη στιγμή.

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Προσθέστε ένα σχήμα χαμόγελου και το κινήστε.
    IAutoShape smile = slide.Shapes.AddAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);

    IEffect effectIn = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);

    IEffect effectOut = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);

    effectIn.Timing.Duration = 2f;
    effectOut.PresetClassType = EffectPresetClassType.Exit;

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    {
        animationsGenerator.NewAnimation += animationPlayer =>
        {
            Console.WriteLine($"Total animation duration: {animationPlayer.Duration}");

            animationPlayer.SetTimePosition(0);          // Η αρχική κατάσταση της κίνησης.
            Bitmap bitmap = animationPlayer.GetFrame();  // Το bitmap της αρχικής κατάστασης της κίνησης.

            animationPlayer.SetTimePosition(animationPlayer.Duration);  // Η τελική κατάσταση της κίνησης.
            Bitmap lastBitmap = animationPlayer.GetFrame();             // Το τελευταίο καρέ της κίνησης.
            lastBitmap.Save("last.png");
        };
    }
}
```

Για να παίζονται όλες οι κινήσεις μιας παρουσίασης ταυτόχρονα, χρησιμοποιείται η κλάση [PresentationPlayer](https://reference.aspose.com/slides/el/net/aspose.slides.export/presentationplayer/). Αυτή η κλάση δέχεται μια παρουσίαση [PresentationAnimationsGenerator](https://reference.aspose.com/slides/el/net/aspose.slides.export/presentationanimationsgenerator/) και μια τιμή FPS για τα εφέ στον κατασκευαστή της, και στη συνέχεια καλεί το συμβάν `FrameTick` για όλες τις κινήσεις ώστε να τις παίξει:

```c#
using (Presentation presentation = new Presentation("animated.pptx"))
{
    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    using (var player = new PresentationPlayer(animationsGenerator, 33))
    {
        player.FrameTick += (sender, args) =>
        {
            args.GetFrame().Save($"frame_{sender.FrameIndex}.png");
        };
        animationsGenerator.Run(presentation.Slides);
    }
}
```

Στη συνέχεια τα παραγόμενα καρέ μπορούν να συναρμολογηθούν για να παραχθεί ένα βίντεο. Δείτε την ενότητα [Μετατροπή Παρουσίασης PowerPoint σε Βίντεο](/slides/el/net/convert-powerpoint-to-video/#convert-a-powerpoint-presentation-to-video).

## **Υποστηριζόμενες Κινήσεις και Εφέ**

Κατά τη μετατροπή μιας παρουσίασης PowerPoint σε βίντεο με το Aspose.Slides for .NET, είναι σημαντικό να γνωρίζετε ποιες κινήσεις και ποια εφέ υποστηρίζονται στο τελικό αποτέλεσμα. Το Aspose.Slides υποστηρίζει μια ευρεία γκάμα κοινών εφέ εισόδου, εξόδου και έμφασης όπως ξεθώριασμα, «πτήση», ζουμ και περιστροφή. Ωστόσο, ορισμένες προχωρημένες ή προσαρμοσμένες κινήσεις μπορεί να μην διατηρηθούν πλήρως ή να εμφανιστούν διαφορετικά στο τελικό βίντεο. Η παρακάτω ενότητα παραθέτει τις υποστηριζόμενες κινήσεις και εφέ.

**Είσοδος**:

| Τύπος Κίνησης | Aspose.Slides | PowerPoint |
|---|---|---|
| **Εμφάνιση** | ![not supported](x.png) | ![supported](v.png) |
| **Ξεθώριασμα** | ![supported](v.png) | ![supported](v.png) |
| **Πτήση μέσα** | ![supported](v.png) | ![supported](v.png) |
| **Πλεύση μέσα** | ![supported](v.png) | ![supported](v.png) |
| **Διαίρεση** | ![supported](v.png) | ![supported](v.png) |
| **Σκούρτ** | ![supported](v.png) | ![supported](v.png) |
| **Σχήμα** | ![supported](v.png) | ![supported](v.png) |
| **Τροχός** | ![supported](v.png) | ![supported](v.png) |
| **Τυχαίες Γραμμές** | ![supported](v.png) | ![supported](v.png) |
| **Αύξηση & Περιστροφή** | ![not supported](x.png) | ![supported](v.png) |
| **Ζουμ** | ![supported](v.png) | ![supported](v.png) |
| **Αναστροφή** | ![supported](v.png) | ![supported](v.png) |
| **Αναπήδηση** | ![supported](v.png) | ![supported](v.png) |

**Έμφαση**:

| Τύπος Κίνησης | Aspose.Slides | PowerPoint |
|---|---|---|
| **Παλμός** | ![not supported](x.png) | ![supported](v.png) |
| **Παλμός Χρώματος** | ![not supported](x.png) | ![supported](v.png) |
| **Κολάσιμο** | ![supported](v.png) | ![supported](v.png) |
| **Περιστροφή** | ![supported](v.png) | ![supported](v.png) |
| **Αύξηση/Σμίκρυνση** | ![not supported](x.png) | ![supported](v.png) |
| **Αποκορεσμός** | ![not supported](x.png) | ![supported](v.png) |
| **Σκοτείνιασμα** | ![not supported](x.png) | ![supported](v.png) |
| **Φωτισμός** | ![not supported](x.png) | ![supported](v.png) |
| **Διαφάνεια** | ![not supported](x.png) | ![supported](v.png) |
| **Χρώμα Αντικειμένου** | ![not supported](x.png) | ![supported](v.png) |
| **Συμπληρωματικό Χρώμα** | ![not supported](x.png) | ![supported](v.png) |
| **Χρώμα Γραμμής** | ![not supported](x.png) | ![supported](v.png) |
| **Χρώμα Γέμισματος** | ![not supported](x.png) | ![supported](v.png) |

**Έξοδος**:

| Τύπος Κίνησης | Aspose.Slides | PowerPoint |
|---|---|---|
| **Ανεμφανισία** | ![not supported](x.png) | ![supported](v.png) |
| **Ξεθώριασμα** | ![supported](v.png) | ![supported](v.png) |
| **Πτήση έξω** | ![supported](v.png) | ![supported](v.png) |
| **Πλεύση έξω** | ![supported](v.png) | ![supported](v.png) |
| **Διαίρεση** | ![supported](v.png) | ![supported](v.png) |
| **Σκούρτ** | ![supported](v.png) | ![supported](v.png) |
| **Σχήμα** | ![supported](v.png) | ![supported](v.png) |
| **Τυχαίες Γραμμές** | ![supported](v.png) | ![supported](v.png) |
| **Σμίκρυνση & Περιστροφή** | ![not supported](x.png) | ![supported](v.png) |
| **Ζουμ** | ![supported](v.png) | ![supported](v.png) |
| **Αναστροφή** | ![supported](v.png) | ![supported](v.png) |
| **Αναπήδηση** | ![supported](v.png) | ![supported](v.png) |

**Διαδρομές Κίνησης**:

| Τύπος Κίνησης | Aspose.Slides | PowerPoint |
|---|---|---|
| **Γραμμές** | ![supported](v.png) | ![supported](v.png) |
| **Τόξα** | ![supported](v.png) | ![supported](v.png) |
| **Στροφές** | ![supported](v.png) | ![supported](v.png) |
| **Σχήματα** | ![supported](v.png) | ![supported](v.png) |
| **Βρόχοι** | ![supported](v.png) | ![supported](v.png) |
| **Προσαρμοσμένη Διαδρομή** | ![supported](v.png) | ![supported](v.png) |

## **Υποστηριζόμενα Εφέ Μετάβασης Διαφάνειας**

Τα εφέ μετάβασης διαφάνειας διαδραματίζουν σημαντικό ρόλο στη δημιουργία ομαλών και οπτικά ελκυστικών αλλαγών μεταξύ των διαφανειών σε ένα βίντεο. Το Aspose.Slides for .NET υποστηρίζει μια ποικιλία κοινών εφέ μετάβασης για να διασφαλίσει τη συνέπεια της ροής και του στυλ της αρχικής παρουσίασής σας. Η ενότητα αυτή επισημαίνει ποια εφέ μετάβασης υποστηρίζονται κατά τη διαδικασία μετατροπής.

**Υποτονικά**:

| Τύπος Εφέ | Aspose.Slides | PowerPoint |
|---|---|---|
| **Μορφοποίηση** | ![not supported](x.png) | ![supported](v.png) |
| **Ξεθώριασμα** | ![supported](v.png) | ![supported](v.png) |
| **Σπρώξιμο** | ![supported](v.png) | ![supported](v.png) |
| **Τράβηγμα** | ![supported](v.png) | ![supported](v.png) |
| **Σκούρτ** | ![supported](v.png) | ![supported](v.png) |
| **Διαίρεση** | ![supported](v.png) | ![supported](v.png) |
| **Αποκάλυψη** | ![not supported](x.png) | ![supported](v.png) |
| **Τυχαίες Γραμμές** | ![supported](v.png) | ![supported](v.png) |
| **Σχήμα** | ![not supported](x.png) | ![supported](v.png) |
| **Αποκάλυψη** | ![not supported](x.png) | ![supported](v.png) |
| **Κάλυψη** | ![supported](v.png) | ![supported](v.png) |
| **Αναλαμπή** | ![supported](v.png) | ![supported](v.png) |
| **Λωρίδες** | ![supported](v.png) | ![supported](v.png) |

**Συναρπαστικά**:

| Τύπος Εφέ | Aspose.Slides | PowerPoint |
|---|---|---|
| **Πτώση** | ![not supported](x.png) | ![supported](v.png) |
| **Κάλυμμα** | ![not supported](x.png) | ![supported](v.png) |
| **Κουρτίνες** | ![not supported](x.png) | ![supported](v.png) |
| **Άνεμος** | ![not supported](x.png) | ![supported](v.png) |
| **Πρεστίζ** | ![not supported](x.png) | ![supported](v.png) |
| **Ρήξη** | ![not supported](x.png) | ![supported](v.png) |
| **Συντριβή** | ![not supported](x.png) | ![supported](v.png) |
| **Αποξένωση** | ![not supported](x.png) | ![supported](v.png) |
| **Τσουβάλι Σελίδας** | ![not supported](x.png) | ![supported](v.png) |
| **Αεροπλάνο** | ![not supported](x.png) | ![supported](v.png) |
| **Οριγκάμι** | ![not supported](x.png) | ![supported](v.png) |
| **Διαλύση** | ![supported](v.png) | ![supported](v.png) |
| **Σκακιέρα** | ![not supported](x.png) | ![supported](v.png) |
| **Παράθυρα** | ![not supported](x.png) | ![supported](v.png) |
| **Ρολόι** | ![supported](v.png) | ![supported](v.png) |
| **Κυματισμός** | ![not supported](x.png) | ![supported](v.png) |
| **Κηρήθρα** | ![not supported](x.png) | ![supported](v.png) |
| **Λαμπερός** | ![not supported](x.png) | ![supported](v.png) |
| **Ανεστραμμένο** | ![not supported](x.png) | ![supported](v.png) |
| **Θραύση** | ![not supported](x.png) | ![supported](v.png) |
| **Αλλαγή** | ![not supported](x.png) | ![supported](v.png) |
| **Αναστροφή** | ![not supported](x.png) | ![supported](v.png) |
| **Γκαλερί** | ![not supported](x.png) | ![supported](v.png) |
| **Κύβος** | ![not supported](x.png) | ![supported](v.png) |
| **Πόρτες** | ![not supported](x.png) | ![supported](v.png) |
| **Κουτί** | ![not supported](x.png) | ![supported](v.png) |
| **Χτένα** | ![not supported](x.png) | ![supported](v.png) |
| **Ζουμ** | ![supported](v.png) | ![supported](v.png) |
| **Τυχαίο** | ![not supported](x.png) | ![supported](v.png) |

**Δυναμικό Περιεχόμενο**:

| Τύπος Εφέ | Aspose.Slides | PowerPoint |
|---|---|---|
| **Πανοραμική** | ![not supported](x.png) | ![supported](v.png) |
| **Τροχός Φέρις** | ![supported](v.png) | ![supported](v.png) |
| **Μεταφορικό** | ![not supported](x.png) | ![supported](v.png) |
| **Περιστροφή** | ![not supported](x.png) | ![supported](v.png) |
| **Τροχιά** | ![not supported](x.png) | ![supported](v.png) |
| **Πτήση Διέλευσης** | ![supported](v.png) | ![supported](v.png) |

## **Συχνές Ερωτήσεις**

**Μπορεί να γίνει μετατροπή παρουσιάσεων που προστατεύονται με κωδικό;**

Ναι, το Aspose.Slides for .NET υποστηρίζει την εργασία με παρουσιάσεις που προστατεύονται με κωδικό πρόσβασης. Κατά την επεξεργασία τέτοιων αρχείων, πρέπει να παρέχετε τον σωστό κωδικό ώστε η βιβλιοθήκη να έχει πρόσβαση στο περιεχόμενο της παρουσίασης.

**Υποστηρίζει το Aspose.Slides for .NET χρήση σε λύσεις cloud;**

Ναι, το Aspose.Slides for .NET μπορεί να ενσωματωθεί σε εφαρμογές και υπηρεσίες cloud. Η βιβλιοθήκη έχει σχεδιαστεί για λειτουργία σε περιβάλλοντα διακομιστών, διασφαλίζοντας υψηλή απόδοση και κλιμακωσιμότητα για επεξεργασία αρχείων κατά παρτίδες.