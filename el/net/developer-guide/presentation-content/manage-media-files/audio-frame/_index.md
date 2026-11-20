---
title: Διαχείριση πλαισίων ήχου σε παρουσιάσεις σε .NET
linktitle: Πλαίσιο ήχου
type: docs
weight: 10
url: /el/net/audio-frame/
keywords:
- ήχος
- πλαίσιο ήχου
- μικρογραφία
- προσθήκη ήχου
- ιδιότητες ήχου
- επιλογές ήχου
- εξαγωγή ήχου
- .NET
- C#
- Aspose.Slides
description: "Ενσωματώστε ήχο στις διαφάνειες, αλλάξτε το εικονίδιο ήχου, ρυθμίστε την αναπαραγωγή, διαχειριστείτε υποτίτλους WebVTT και εξαγάγετε ήχους μετάβασης διαφάνειας με το Aspose.Slides για .NET."
---
## **Επισκόπηση**

Ένα πλαίσιο ήχου σάς επιτρέπει να αναπαράγετε έναν ήχο σε μια διαφάνεια. Με το Aspose.Slides για .NET, μπορείτε να ενσωματώσετε ένα αποσπάσμα ήχου, να επιλέξετε την εικόνα που το αντιπροσωπεύει, να ρυθμίσετε την αναπαραγωγή και να προσθέσετε υπότιτλους. Μπορείτε επίσης να ανακτήσετε έναν ήχο που έχει ανατεθεί σε μια μετάβαση διαφάνειας.

## **Δημιουργία πλαισίων ήχου**

Χρησιμοποιήστε [AddAudioFrameEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addaudioframeembedded/) για να ενσωματώσετε ένα τοπικό αποσπάσμα ήχου στην πρώτη διαφάνεια. Οι πρώτες δύο συντεταγμένες τοποθετούν το πλαίσιο στη διαφάνεια, και οι επόμενες δύο τιμές ορίζουν το πλάτος και το ύψος του, όλα σε σημεία. Αυτό το παράδειγμα ορίζει το [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) ώστε το αποσπάσμα να ξεκινά αυτόματα και το [Volume](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volume/) στο υψηλό προεπιλεγμένο επίπεδο.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, audioStream);
audioFrame.PlayMode = AudioPlayModePreset.Auto;
audioFrame.Volume = AudioVolumeMode.Loud;

presentation.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
```

## **Αλλαγή μικρογραφίας πλαισίου ήχου**

Από προεπιλογή, ένα πλαίσιο ήχου εμφανίζει ένα εικονίδιο ηχείου. Για να εμφανίσετε μια προσαρμοσμένη μικρογραφία, προσθέστε μια εικόνα στην παρουσίαση με το [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/) και αντιστοιχίστε την στην ιδιότητα [Picture.Image](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/image/) του πλαισίου. Το παράδειγμα χρησιμοποιεί ένα JPEG ως μικρογραφία για ένα ενσωματωμένο αποσπάσμα ήχου.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var imageStream = File.OpenRead("eagle.jpeg");
var thumbnail = presentation.Images.AddImage(imageStream);

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
audioFrame.PictureFormat.Picture.Image = thumbnail;

presentation.Save("example_out.pptx", SaveFormat.Pptx);
```

## **Αλλαγή επιλογών αναπαραγωγής ήχου**

Τα **Επιλογές ήχου** του PowerPoint καθορίζουν πότε ξεκινά ένα αποσπάσμα, πόσο έντονο ακούγεται και πώς συμπεριφέρεται κατά τη διάρκεια μιας παρουσίασης.

![Έλεγχοι Επιλογών ήχου του PowerPoint για ένα πλαίσιο ήχου](audio_frame_0.png)

| Έλεγχος PowerPoint | Ιδιότητα Aspose.Slides |
| --- | --- |
| Έναρξη | [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) |
| Προκαθορισμένο έντασης | [Volume](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volume/) |
| Αναπαραγωγή σε όλες τις διαφάνειες | [PlayAcrossSlides](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playacrossslides/) |
| Επανάληψη μέχρι τη διακοπή | [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playloopmode/) |
| Απόκρυψη κατά την παρουσίαση | [HideAtShowing](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/hideatshowing/) |
| Επιστροφή μετά την αναπαραγωγή | [RewindAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/rewindaudio/) |
| Ομαλή εισαγωγή | [FadeInDuration](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/fadeinduration/) |
| Ομαλή εξαγωγή | [FadeOutDuration](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/fadeoutduration/) |
| Περικοπή χρόνου έναρξης ήχου | [TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromstart/) |
| Περικοπή χρόνου λήξης ήχου | [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) |
| Ρυθμιστικό έντασης | [VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volumevalue/) |

Το παράδειγμα βρίσκει το πρώτο πλαίσιο ήχου στην πρώτη διαφάνεια, ορίζει το [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) ώστε η αναπαραγωγή να ξεκινά με κλικ, και επιλέγει το χαμηλό προεπιλεγμένο επίπεδο έντασης. Το αποσπάσμα συνεχίζει σε επόμενες διαφάνειες με απενεργοποιημένη επανάληψη. Το εικονίδιο παραμένει κρυφό κατά την παρουσίαση και το αποσπάσμα επανέρχεται στην αρχή μετά την αναπαραγωγή.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AudioFrameEmbed_out.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.PlayMode = AudioPlayModePreset.OnClick;
audioFrame.Volume = AudioVolumeMode.Low;
audioFrame.PlayAcrossSlides = true;
audioFrame.PlayLoopMode = false;
audioFrame.HideAtShowing = true;
audioFrame.RewindAudio = true;

presentation.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
```

Για ένα αποσπάσμα μεγαλύτερο από 3,5 δευτερόλεπτα, αυτό το παράδειγμα παραλείπει τα πρώτα 1,5 δευτερόλεπτα και τα τελευταία 2 δευτερόλεπτα. Το [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) μετρά τη διάρκεια που πρέπει να παραλειφθεί από το τέλος του αποσπάσματος. Για να λάβετε το χρόνο λήξης που εμφανίζεται στο PowerPoint, αφαιρέστε αυτήν την απόκλιση από τη συνολική διάρκεια του αποσπάσματος. Το περικομμένο αποσπάσμα εισέρχεται ομαλά μέσα σε 200 χιλιοστά του δευτερολέπτου και εξέρχεται ομαλά μέσα σε 500 χιλιοστά του δευτερολέπτου. Όλες οι τέσσερις ιδιότητες δέχονται τιμές σε χιλιοστά του δευτερολέπτου.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audioStream);
audioFrame.TrimFromStart = 1500f;
audioFrame.TrimFromEnd = 2000f;
audioFrame.FadeInDuration = 200f;
audioFrame.FadeOutDuration = 500f;

presentation.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
```

Για να ορίσετε την ένταση αναπαραγωγής σε συγκεκριμένο ποσοστό, χρησιμοποιήστε το [VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volumevalue/). Αυτό το παράδειγμα ορίζει το πρώτο πλαίσιο ήχου στην πρώτη διαφάνεια στο 85%.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AudioFrameEmbed_out.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.VolumeValue = 85f;

presentation.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
```

## **Διαχείριση υποτίτλων ήχου**

Κάθε πλαίσιο ήχου διαθέτει μια συλλογή [CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/captiontracks/). Χρησιμοποιήστε την για να επισυνάψετε υποτίτλους WebVTT στο αποσπάσμα, να εξάγετε υπάρχοντες δρόμους ή να τους αφαιρέσετε.

### **Προσθήκη υποτίτλων ήχου**

Το παράδειγμα ενσωματώνει ένα αποσπάσμα ήχου στην πρώτη διαφάνεια και χρησιμοποιεί το [ICaptionsCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/add/) για να επισυνάψει έναν τοπικό δρόμο WebVTT. Το πρώτο όρισμα παρέχει την ετικέτα του δρόμου, και το δεύτερο προσδιορίζει το αρχείο που περιέχει τους χρονικά συγχρονισμένους υπότιτλους.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(10, 10, 50, 50, audioStream);
audioFrame.CaptionTracks.Add("English", "track.vtt");

presentation.Save("audio_with_captions.pptx", SaveFormat.Pptx);
```

### **Εξαγωγή υποτίτλων ήχου**

Αυτό το παράδειγμα εξάγει κάθε δρόμο υπότιτλου που είναι συνδεδεμένος με ένα πλαίσιο ήχου στην πρώτη διαφάνεια. Γράφει τα [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/icaptions/binarydata/) του δρόμου σε ένα αρχείο WebVTT και χρησιμοποιεί το [CaptionId](https://reference.aspose.com/slides/net/aspose.slides/icaptions/captionid/) του ως όνομα αρχείου, ώστε κάθε δρόμος να έχει ξεχωριστό αποτέλεσμα.

```csharp
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

foreach (var audioFrame in slide.Shapes.OfType<IAudioFrame>())
{
    foreach (var track in audioFrame.CaptionTracks)
    {
        File.WriteAllBytes($"{track.CaptionId}.vtt", track.BinaryData);
    }
}
```

### **Αφαίρεση υποτίτλων ήχου**

Χρησιμοποιήστε το [Remove](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/remove/) ή το [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/removeat/) για να διαγράψετε έναν μεμονωμένο δρόμο. Το παράδειγμα χρησιμοποιεί το [Clear](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/clear/) για να αφαιρέσει όλους τους υπότιτλους από το πρώτο πλαίσιο ήχου στην πρώτη διαφάνεια, διατηρώντας το αποσπάσμα.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.CaptionTracks.Clear();

presentation.Save("audio_without_captions.pptx", SaveFormat.Pptx);
```

### **Εύρεση γραμμής σε υπότιτλους ήχου**

Για να βρείτε μια γραμμή στους υπότιτλους ήχου στην πρώτη διαφάνεια, διαβάστε το [DataAsString](https://reference.aspose.com/slides/net/aspose.slides/icaptions/dataasstring/) κάθε δρόμου στη μνήμη. Σε ένα κείμενο WebVTT cue, η γραμμή χρόνου περιέχει `-->`, οι γραμμές υποτίτλου την ακολουθούν, και μια κενή γραμμή τερματίζει το cue. Αυτό το παράδειγμα εκτυπώνει την ετικέτα του δρόμου και κάθε γραμμή υποτίτλου που περιέχει τη λέξη «café».

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

foreach (var frame in slide.Shapes.OfType<IAudioFrame>())
{
    foreach (var track in frame.CaptionTracks)
    {
        using var reader = new StringReader(track.DataAsString);
        var inCue = false;
        while (reader.ReadLine() is string line)
        {
            if (line.Length == 0)
                inCue = false;
            else if (line.Contains("-->"))
                inCue = true;
            else if (inCue && line.Contains("café", StringComparison.OrdinalIgnoreCase))
                Console.WriteLine($"{track.Label}: {line}");
        }
    }
}
```

## **Εξαγωγή ήχου**

Μια μετάβαση διαφάνειας μπορεί να έχει το δικό της ήχο. Για να το ανακτήσετε, διαβάστε την ιδιότητα [Sound](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/sound/) της μετάβασης. Το παράδειγμα προσπελάζει τα [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/iaudio/binarydata/) του ήχου και εκτυπώνει το μέγεθός του σε bytes. Αν η πρώτη διαφάνεια δεν έχει ήχο μετάβασης, εκτυπώνει ένα μήνυμα αντί αυτού.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("AudioSlide.pptx");
var slide = presentation.Slides[0];

var sound = slide.SlideShowTransition.Sound;
if (sound == null)
{
    Console.WriteLine("The first slide has no transition sound.");
    return;
}

var audioData = sound.BinaryData;
Console.WriteLine($"Transition sound: {audioData.Length} bytes.");
```

## **FAQ**

**Μπορώ να επαναχρησιμοποιήσω το ίδιο αποσπάσμα ήχου σε πολλές διαφάνειες χωρίς αντιγραφή;**

Ναι. Προσθέστε το αποσπάσμα μία φορά στη [audio collection](https://reference.aspose.com/slides/net/aspose.slides/presentation/audios/) της παρουσίασης και περάστε το ίδιο αντικείμενο ήχου στο [AddAudioFrameEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addaudioframeembedded/) για κάθε διαφάνεια.

**Μπορώ να αντικαταστήσω τον ήχο σε ένα υπάρχον πλαίσιο ήχου;**

Ναι. Για έναν συνδεδεμένο ήχο, ενημερώστε το [LinkPathLong](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/linkpathlong/) ώστε να δείχνει στο νέο αρχείο. Για έναν ενσωματωμένο ήχο, αντιστοιχίστε ένα άλλο αποσπάσμα από τη συλλογή ήχου της παρουσίασης στο [EmbeddedAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/embeddedaudio/). Και οι δύο προσεγγίσεις διατηρούν το υπάρχον πλαίσιο.

**Η περικοπή αλλάζει τα δεδομένα ήχου που αποθηκεύονται στην παρουσίαση;**

Όχι. Τα [TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromstart/) και [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) ορίζουν τα όρια αναπαραγωγής. Μπορείτε ακόμη να ανακτήσετε το πλήρες αποσπάσμα από το [EmbeddedAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/embeddedaudio/).