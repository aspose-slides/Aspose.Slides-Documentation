---
title: Μετατροπή Παρουσιών PowerPoint σε Βίντεο με .NET
linktitle: PowerPoint σε Βίντεο
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
description: "Μάθετε πώς να μετατρέψετε παρουσιάσεις PowerPoint σε βίντεο με .NET. Ανακαλύψτε δείγμα κώδικα C# και τεχνικές αυτοματοποίησης για την απλοποίηση της ροής εργασίας σας."
---
## **Εισαγωγή**

Με τη μετατροπή της παρουσίασης PowerPoint ή OpenDocument σε βίντεο, κερδίζετε:

**Αυξημένη προσβασιμότητα:** Όλες οι συσκευές, ανεξαρτήτως πλατφόρμας, είναι εξοπλισμένες με προβολείς βίντεο από προεπιλογή, καθιστώντας πιο εύκολο για τους χρήστες το άνοιγμα ή την αναπαραγωγή βίντεο σε σύγκριση με τις παραδοσιακές εφαρμογές παρουσίασης.

**Μεγαλύτερη εμβέλεια:** Τα βίντεο σας επιτρέπουν να προσεγγίσετε ένα μεγαλύτερο κοινό και να παρουσιάσετε τις πληροφορίες με πιο ελκυστική μορφή. Έρευνες και στατιστικά δείχνουν ότι οι άνθρωποι προτιμούν να παρακολουθούν και να καταναλώνουν περιεχόμενο βίντεο παρά άλλες μορφές, καθιστώντας το μήνυμά σας πιο επιδραστικό.

{{% alert color="info" %}} 
Δείτε τον [**Μετατροπέα PowerPoint σε Βίντεο Online**](https://products.aspose.app/slides/el/video) επειδή προσφέρει μια ζωντανή και αποτελεσματική υλοποίηση της διαδικασίας που περιγράφεται εδώ.
{{% /alert %}} 

Στο Aspose.Slides for .NET, υλοποιήσαμε υποστήριξη για τη μετατροπή παρουσιάσεων σε βίντεο.

* Χρησιμοποιήστε το Aspose.Slides for .NET για τη δημιουργία πλαισίων από τις διαφάνειες παρουσίασης με καθορισμένο ρυθμό καρέ (FPS).
* Στη συνέχεια, χρησιμοποιήστε ένα εργαλείο τρίτου μέρους όπως το ffmpeg για τη συναρμολόγηση αυτών των πλαισίων σε ένα βίντεο.

## **Μετατροπή Παρουσίασης PowerPoint σε Βίντεο**

1. Χρησιμοποιήστε την εντολή `dotnet add package` για την προσθήκη του Aspose.Slides και της βιβλιοθήκης FFMpegCore στο έργο σας:
   * εκτελέστε `dotnet add package Aspose.Slides.NET --version 22.11.0`
   * εκτελέστε `dotnet add package FFMpegCore --version 4.8.0`
2. Κατεβάστε το ffmpeg από [εδώ](https://ffmpeg.org/download.html).
3. Το FFMpegCore απαιτεί να καθορίσετε τη διαδρομή προς το ληφθέν ffmpeg (π.χ., εξαγόμενο στο "C:\tools\ffmpeg"):  
```cs
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });
```
4. Εκτελέστε τον κώδικα μετατροπής PowerPoint σε βίντεο.

Αυτός ο κώδικας C# δείχνει πώς να μετατρέψετε μια παρουσίαση (που περιέχει σχήμα και δύο εφέ κίνησης) σε βίντεο:
```c#
using System.Collections.Generic;
using Aspose.Slides;
using FFMpegCore; // θα χρησιμοποιήσει τα δυαδικά αρχεία FFmpeg που εξαγάγαμε στο C:\tools\ffmpeg νωρίτερα.
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Προσθέστε ένα σχήμα χαμόγελου και στη συνέχεια τοποθετήστε κίνηση.
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

    // Διαμορφώστε το φάκελο των δυαδικών αρχείων ffmpeg. Δείτε αυτή τη σελίδα: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // Μεταφέ

ρα τα πλαίσια σε βίντεο webm.
    FFMpeg.JoinImageSequence("smile.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **Εφέ Βίντεο**

Κατά τη μετατροπή μιας παρουσίασης PowerPoint σε βίντεο χρησιμοποιώντας το Aspose.Slides for .NET, μπορείτε να εφαρμόσετε διάφορα εφέ βίντεο για να βελτιώσετε την οπτική ποιότητα του αποτελέσματος. Αυτά τα εφέ σας επιτρέπουν να ελέγχετε την εμφάνιση των διαφανειών στο τελικό βίντεο προσθέτοντας ομαλές μεταβάσεις, κινήσεις και άλλα οπτικά στοιχεία. Αυτή η ενότητα εξηγεί τις διαθέσιμες επιλογές εφέ βίντεο και δείχνει πώς να τις εφαρμόσετε.

{{% alert color="info" %}} 
Δείτε:
- [Βελτίωση Παρουσιάσεων PowerPoint με Κινήσεις σε C#](https://docs.aspose.com/slides/el/net/powerpoint-animation/)
- [Κίνηση Σχήματος](https://docs.aspose.com/slides/el/net/shape-animation/)
- [Εφαρμογή Εφέ Σχήματος στο PowerPoint με C#](https://docs.aspose.com/slides/el/net/shape-effect/)
{{% /alert %}} 

Οι κινήσεις και οι μεταβάσεις κάνουν τις παρουσιάσεις πιο ελκυστικές και ενδιαφέρουσες — και κάνουν το ίδιο και τα βίντεο. Ας προσθέσουμε μία επιπλέον διαφάνεια και μια μετάβαση στον κώδικα για την προηγούμενη παρουσίαση:
```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.SlideShow;

using (Presentation presentation = new Presentation())
{
    // Προσθέστε ένα σχήμα χαμόγελου και τοποθετήστε του κίνηση (δείτε τον κώδικα παραπάνω).

    // Προσθέστε μια νέα διαφάνεια και μια κινούμενη μετάβαση.
    ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
    newSlide.Background.Type = BackgroundType.OwnBackground;
    newSlide.Background.FillFormat.FillType = FillType.Solid;
    newSlide.Background.FillFormat.SolidFillColor.Color = Color.Indigo;
    newSlide.SlideShowTransition.Type = TransitionType.Push;
}
```

Το Aspose.Slides υποστηρίζει επίσης κίνησεις κειμένου. Σε αυτό το παράδειγμα, κινούμε παραγράφους σε αντικείμενα ώστε να εμφανίζονται μία προς μία, με καθυστέρηση ενός δευτερολέπτου μεταξύ τους:
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

    // Διαμορφώστε το φάκελο των δυαδικών αρχείων ffmpeg. Δείτε αυτή τη σελίδα: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // Μετατρέψτε τα πλαίσια σε βίντεο webm.
    FFMpeg.JoinImageSequence("text_animation.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **Κλάσεις Μετατροπής Βίντεο**

Για να ενεργοποιήσετε εργασίες μετατροπής PowerPoint σε βίντεο, το Aspose.Slides for .NET παρέχει τις κλάσεις [PresentationAnimationsGenerator](https://reference.aspose.com/slides/el/net/aspose.slides.export/presentationanimationsgenerator/) και [PresentationPlayer](https://reference.aspose.com/slides/el/net/aspose.slides.export/presentationplayer/).

`PresentationAnimationsGenerator` σας επιτρέπει να ορίσετε το μέγεθος πλαισίου για το βίντεο (που θα δημιουργηθεί αργότερα) και την τιμή FPS (καρέ ανά δευτερόλεπτο) μέσω του κατασκευαστή του. Εάν περάσετε μια παρουσίαση, θα χρησιμοποιηθεί το `Presentation.SlideSize` της και δημιουργεί κινήσεις που χρησιμοποιεί το [PresentationPlayer](https://reference.aspose.com/slides/el/net/aspose.slides.export/presentationplayer/).

Όταν δημιουργούνται κινήσεις, ένα συμβάν `NewAnimation` ενεργοποιείται για κάθε επόμενη κίνηση, το οποίο περιλαμβάνει μια παράμετρο [IPresentationAnimationPlayer](https://reference.aspose.com/slides/el/net/aspose.slides.export/ipresentationanimationplayer/). Αυτή η κλάση αντιπροσωπεύει έναν προγυμναστή για μια μεμονωμένη κίνηση.

Για να εργαστείτε με το [IPresentationAnimationPlayer](https://reference.aspose.com/slides/el/net/aspose.slides.export/ipresentationanimationplayer/), χρησιμοποιείτε την ιδιότητα [Duration](https://reference.aspose.com/slides/el/net/aspose.slides.export/ipresentationanimationplayer/duration/) (που δίνει τη συνολική διάρκεια της κίνησης) και τη μέθοδο [SetTimePosition](https://reference.aspose.com/slides/el/net/aspose.slides.export/ipresentationanimationplayer/settimeposition/). Κάθε θέση κίνησης ορίζεται εντός του εύρους *0 έως διάρκεια*, και η μέθοδος `GetFrame` επιστρέφει ένα Bitmap που αντιπροσωπεύει την κατάσταση της κίνησης σε εκείνο το χρονικό σημείο.
```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Προσθέστε ένα σχήμα χαμόγελου και τοποθετήστε κίνηση.
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

            animationPlayer.SetTimePosition(0);        // Η αρχική κατάσταση της κίνησης.
            IImage image = animationPlayer.GetFrame(); // Η εικόνα της αρχικής κατάστασης της κίνησης.

            animationPlayer.SetTimePosition(animationPlayer.Duration); // Η τελική κατάσταση της κίνησης.
            IImage lastImage = animationPlayer.GetFrame();             // Το τελευταίο πλαίσιο της κίνησης.
            lastImage.Save("last.png");
        };
    }
}
```

Για να κάνετε όλες τις κινήσεις σε μια παρουσίαση να αναπαράγονται ταυτόχρονα, χρησιμοποιείται η κλάση [PresentationPlayer](https://reference.aspose.com/slides/el/net/aspose.slides.export/presentationplayer/). Αυτή η κλάση λαμβάνει μια παρουσίαση [PresentationAnimationsGenerator](https://reference.aspose.com/slides/el/net/aspose.slides.export/presentationanimationsgenerator/) και μια τιμή FPS για τα εφέ στον κατασκευαστή της, και στη συνέχεια καλεί το συμβάν `FrameTick` για όλες τις κινήσεις ώστε να τις αναπαράγει:
```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

Στη συνέχεια τα παραγόμενα πλαίσια μπορούν να συναρμολογηθούν για την παραγωγή ενός βίντεο. Δείτε την ενότητα [Μετατροπή Παρουσίασης PowerPoint σε Βίντεο](/slides/el/net/convert-powerpoint-to-video/#convert-a-powerpoint-presentation-to-video).

## **Υποστηριζόμενες Κινήσεις και Εφέ**

Κατά τη μετατροπή μιας παρουσίασης PowerPoint σε βίντεο χρησιμοποιώντας το Aspose.Slides for .NET, είναι σημαντικό να κατανοήσετε ποιες κινήσεις και εφέ υποστηρίζονται στο παραγόμενο αρχείο. Το Aspose.Slides υποστηρίζει μια ευρεία γκάμα κοινών εφέ εισόδου, εξόδου και έμφασης όπως η εξαπλωση (fade), η πτήση (fly in), το ζουμ και η περιστροφή. Ωστόσο, ορισμένες προχωρημένες ή προσαρμοσμένες κινήσεις ενδέχεται να μην διατηρηθούν πλήρως ή να εμφανιστούν διαφορετικά στο τελικό βίντεο. Αυτή η ενότητα περιγράφει τις υποστηριζόμενες κινήσεις και εφέ.

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

**Motion Paths**:

| Τύπος Κίνησης | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **Υποστηριζόμενα Εφέ Μετάβασης Διαφανειών**

Τα εφέ μετάβασης διαφανειών παίζουν σημαντικό ρόλο στη δημιουργία ομαλών και οπτικά ελκυστικών αλλαγών μεταξύ των διαφανειών σε ένα βίντεο. Το Aspose.Slides for .NET υποστηρίζει μια ποικιλία κοινώς χρησιμοποιούμενων εφέ μετάβασης για να διατηρήσει τη ροή και το στυλ της αρχικής παρουσίασής σας. Αυτή η ενότητα επισημαίνει ποια εφέ μετάβασης υποστηρίζονται κατά τη διαδικασία μετατροπής.

**Subtle**:

| Τύπος Κίνησης | Aspose.Slides | PowerPoint |
|---|---|---|
| **Morph** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Push** | ![supported](v.png) | ![supported](v.png) |
| **Pull** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Reveal** | ![not supported](x.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![not supported](x.png) | ![supported](v.png) |
| **Uncover** | ![not supported](x.png) | ![supported](v.png) |
| **Cover** | ![supported](v.png) | ![supported](v.png) |
| **Flash** | ![supported](v.png) | ![supported](v.png) |
| **Strips** | ![supported](v.png) | ![supported](v.png) |

**Exciting**:

| Τύπος Κίνησης | Aspose.Slides | PowerPoint |
|---|---|---|
| **Fall Over** | ![not supported](x.png) | ![supported](v.png) |
| **Drape** | ![not supported](x.png) | ![supported](v.png) |
| **Curtains** | ![not supported](x.png) | ![supported](v.png) |
| **Wind** | ![not supported](x.png) | ![supported](v.png) |
| **Prestige** | ![not supported](x.png) | ![supported](v.png) |
| **Fracture** | ![not supported](x.png) | ![supported](v.png) |
| **Crush** | ![not supported](x.png) | ![supported](v.png) |
| **Peel Off** | ![not supported](x.png) | ![supported](v.png) |
| **Page Curl** | ![not supported](x.png) | ![supported](v.png) |
| **Airplane** | ![not supported](x.png) | ![supported](v.png) |
| **Origami** | ![not supported](x.png) | ![supported](v.png) |
| **Dissolve** | ![supported](v.png) | ![supported](v.png) |
| **Checkerboard** | ![not supported](x.png) | ![supported](v.png) |
| **Blinds** | ![not supported](x.png) | ![supported](v.png) |
| **Clock** | ![supported](v.png) | ![supported](v.png) |
| **Ripple** | ![not supported](x.png) | ![supported](v.png) |
| **Honeycomb** | ![not supported](x.png) | ![supported](v.png) |
| **Glitter** | ![not supported](x.png) | ![supported](v.png) |
| **Vortex** | ![not supported](x.png) | ![supported](v.png) |
| **Shred** | ![not supported](x.png) | ![supported](v.png) |
| **Switch** | ![not supported](x.png) | ![supported](v.png) |
| **Flip** | ![not supported](x.png) | ![supported](v.png) |
| **Gallery** | ![not supported](x.png) | ![supported](v.png) |
| **Cube** | ![not supported](x.png) | ![supported](v.png) |
| **Doors** | ![not supported](x.png) | ![supported](v.png) |
| **Box** | ![not supported](x.png) | ![supported](v.png) |
| **Comb** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v/png) |
| **Random** | ![not supported](x.png) | ![supported](v.png) |

**Dynamic Content**:

| Τύπος Κίνησης | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![not supported](x.png) | ![supported](v.png) |
| **Ferris Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Conveyor** | ![not supported](x.png) | ![supported](v.png) |
| **Rotate** | ![not supported](x.png) | ![supported](v.png) |
| **Orbit** | ![not supported](x.png) | ![supported](v.png) |
| **Fly Through** | ![supported](v.png) | ![supported](v.png) |

## **Συχνές Ερωτήσεις**

### Είναι δυνατόν να μετατραπούν παρουσιάσεις που προστατεύονται με κωδικό;

Ναι, το Aspose.Slides for .NET επιτρέπει την εργασία με παρουσιάσεις προστατευμένες με κωδικό. Κατά την επεξεργασία τέτοιων αρχείων, πρέπει να παραχωρήσετε τον σωστό κωδικό ώστε η βιβλιοθήκη να μπορεί να έχει πρόσβαση στο περιεχόμενο της παρουσίασης.

### Υποστηρίζει το Aspose.Slides for .NET τη χρήση του σε λύσεις cloud;

Ναι, το Aspose.Slides for .NET μπορεί να ενσωματωθεί σε εφαρμογές και υπηρεσίες cloud. Η βιβλιοθήκη σχεδιάστηκε για λειτουργία σε περιβάλλοντα εξυπηρετητών, εξασφαλίζοντας υψηλή απόδοση και κλιμακωσιμότητα για μαζική επεξεργασία αρχείων.

### Υπάρχουν περιορισμοί μεγέθους για τις παρουσιάσεις κατά τη μετατροπή;

Το Aspose.Slides for .NET είναι ικανό να διαχειριστεί παρουσιάσεις σχεδόν οποιουδήποτε μεγέθους. Ωστόσο, όταν εργάζεστε με πολύ μεγάλα αρχεία, ενδέχεται να απαιτηθούν επιπλέον συστημικοί πόροι, και συχνά συνιστάται η βελτιστοποίηση της παρουσίασης για τη βελτίωση της απόδοσης.