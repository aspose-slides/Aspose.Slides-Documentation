---
title: "Διαχείριση Πλαισίων Ήχου σε Παρουσιάσεις σε .NET"
linktitle: "Πλαίσιο Ήχου"
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
description: "Δημιουργία και διαχείριση πλαισίων ήχου στο Aspose.Slides για .NET—παραδείγματα C# για ενσωμάτωση, περικοπή, επανάληψη και διαμόρφωση αναπαραγωγής σε παρουσιάσεις PPT, PPTX και ODP."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να δουλεύετε με πλαίσια ήχου στο Aspose.Slides. Δείχνει πώς να προσθέσετε ενσωματωμένο ήχο στις διαφάνειες, να προσαρμόσετε τη μικρογραφία του πλαισίου ήχου, να διαμορφώσετε τις επιλογές αναπαραγωγής όπως ένταση, επανάληψη, απόκρυψη, περικοπή και χρονικές διάρκειες εξασθένισης, και να εξάγετε τον ήχο που χρησιμοποιείται στις μεταβάσεις της παρουσίασης.

## **Δημιουργία Πλαισίων Ήχου**

Aspose.Slides for .NET σας επιτρέπει να προσθέτετε αρχεία ήχου στις διαφάνειες. Τα αρχεία ήχου ενσωματώνονται στις διαφάνειες ως πλαίσια ήχου. 

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation ](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
2. Αποκτήστε μια αναφορά σε μια διαφάνεια μέσω του δείκτη της.
3. Φορτώστε τη ροή αρχείου ήχου που θέλετε να ενσωματώσετε στη διαφάνεια.
4. Προσθέστε το ενσωματωμένο πλαίσιο ήχου (που περιέχει το αρχείο ήχου) στη διαφάνεια.
5. Ορίστε το [PlayMode](https://reference.aspose.com/slides/el/net/aspose.slides/audioplaymodepreset) και το `Volume` που εκτίθενται από το αντικείμενο [IAudioFrame](https://reference.aspose.com/slides/el/net/aspose.slides/audioframe).
6. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```c#
// Δημιουργεί μια παρουσία κλάσης παρουσίασης που αντιπροσωπεύει ένα αρχείο παρουσίασης
using (Presentation pres = new Presentation())
{
    // Λαμβάνει την πρώτη διαφάνεια
    ISlide sld = pres.Slides[0];
    
    // Φορτώνει το αρχείο ήχου wav σε ροή
    FileStream fstr = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read);

    // Προσθέτει το Πλαίσιο Ήχου
    IAudioFrame audioFrame = sld.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, fstr);

    // Ορίζει τη Λειτουργία Αναπαραγωγής και την Ένταση του Ήχου
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
    audioFrame.Volume = AudioVolumeMode.Loud;

    // Γράφει το αρχείο PowerPoint στο δίσκο
    pres.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
}
```

## **Αλλαγή της Μικρογραφίας Πλαισίου Ήχου**

Όταν προσθέτετε ένα αρχείο ήχου σε μια παρουσίαση, ο ήχος εμφανίζεται ως πλαίσιο με μια προεπιλεγμένη τυπική εικόνα (δείτε την εικόνα στην παρακάτω ενότητα). Μπορείτε να αλλάξετε τη μικρογραφία του πλαισίου ήχου (ορίζοντας την προτιμώμενη εικόνα).

```c#
using (var presentation = new Presentation())
{
    var slide = presentation.Slides[0];

    // Προσθέτει ένα πλαίσιο ήχου στη διαφάνεια με συγκεκριμένη θέση και μέγεθος.
    var audioStream = new FileStream("sample2.mp3", FileMode.Open, FileAccess.Read);
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.Dispose();

    // Προσθέτει μια εικόνα στους πόρους της παρουσίασης.
    var imageStream = File.OpenRead("eagle.jpeg");
    var audioImage = presentation.Images.AddImage(imageStream);
    imageStream.Dispose();

    // Sets the image for the audio frame. // <-----
    
	//Αποθηκεύει την τροποποιημένη παρουσίαση στο δίσκο
    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```

## **Αλλαγή Επιλογών Αναπαραγωγής Ήχου**

Aspose.Slides for .NET σας επιτρέπει να αλλάζετε τις επιλογές που ελέγχουν την αναπαραγωγή ή τις ιδιότητες ενός ήχου. Για παράδειγμα, μπορείτε να ρυθμίσετε την ένταση του ήχου, να θέσετε τον ήχο να αναπαράγεται σε βρόχο, ή ακόμη και να κρύψετε το εικονίδιο του ήχου.

Το πλαίσιο **Audio Options** στο Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** που αντιστοιχούν στις ιδιότητες Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/el/net/aspose.slides/audioframe):

- **Start** το αναπτυσσόμενο μενού ταιριάζει με την ιδιότητα [AudioFrame.PlayMode](https://reference.aspose.com/slides/el/net/aspose.slides/audioframe/properties/playmode) 
- **Volume** ταιριάζει με την ιδιότητα [AudioFrame.Volume](https://reference.aspose.com/slides/el/net/aspose.slides/audioframe/properties/volume) 
- **Play Across Slides** ταιριάζει με την ιδιότητα [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/el/net/aspose.slides/audioframe/properties/playacrossslides) 
- **Loop until Stopped** ταιριάζει με την ιδιότητα [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/el/net/aspose.slides/audioframe/properties/playloopmode) 
- **Hide During Show** ταιριάζει με την  [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/el/net/aspose.slides/audioframe/properties/hideatshowing) 
- **Rewind after Playing** ταιριάζει με την [AudioFrame.RewindAudio ](https://reference.aspose.com/slides/el/net/aspose.slides/audioframe/properties/rewindaudio) ιδιότητα 

Οι επιλογές **Editing** του PowerPoint που αντιστοιχούν στις ιδιότητες του Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/el/net/aspose.slides/audioframe):

- **Fade In** ταιριάζει με την ιδιότητα [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/el/net/aspose.slides/audioframe/fadeinduration/) 
- **Fade Out** ταιριάζει με την ιδιότητα [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/el/net/aspose.slides/audioframe/fadeoutduration/) 
- **Trim Audio Start Time** ταιριάζει με την ιδιότητα [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/el/net/aspose.slides/audioframe/trimfromstart/) 
- **Trim Audio End Time** η τιμή ισούται με τη διάρκεια του ήχου μείον την τιμή της ιδιότητας [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/el/net/aspose.slides/audioframe/trimfromend/) 

Ο **Volume controll** του PowerPoint στον πίνακα ελέγχου ήχου αντιστοιχεί στην ιδιότητα [AudioFrame.VolumeValue](https://reference.aspose.com/slides/el/net/aspose.slides/audioframe/volumevalue/) . Σας επιτρέπει να αλλάξετε την ένταση του ήχου ως ποσοστό.

Αυτή είναι η διαδικασία για την αλλαγή των επιλογών αναπαραγωγής ήχου:

1. [Δημιουργία](#create-audio-frame) ή λάβετε το Audio Frame.
2. Ορίστε νέες τιμές για τις ιδιότητες του Audio Frame που θέλετε να προσαρμόσετε.
3. Αποθηκεύστε το τροποποιημένο αρχείο PowerPoint.

``` csharp 
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // Λαμβάνει το σχήμα AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.Slides[0].Shapes[0];

    // Ορίζει τη λειτουργία αναπαραγωγής σε αναπαραγωγή με κλικ
    audioFrame.PlayMode = AudioPlayModePreset.OnClick;

    // Ορίζει τη ένταση σε Χαμηλή
    audioFrame.Volume = AudioVolumeMode.Low;

    // Ορίζει τον ήχο να αναπαράγεται σε όλες τις διαφάνειες
    audioFrame.PlayAcrossSlides = true;

    // Απενεργοποιεί την επανάληψη για τον ήχο
    audioFrame.PlayLoopMode = false;

    // Αποκρύπτει το AudioFrame κατά τη διάρκεια της παρουσίασης
    audioFrame.HideAtShowing = true;

    // Επαναφέρει τον ήχο στην αρχή μετά την αναπαραγωγή
    audioFrame.RewindAudio = true;

    // Αποθηκεύει το αρχείο PowerPoint στο δίσκο
    pres.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
}
```

Αυτό το παράδειγμα C# δείχνει πώς να προσθέσετε ένα νέο πλαίσιο ήχου με ενσωματωμένο ήχο, να το περικόψετε και να ορίσετε τις διάρκειες εξασθένισης:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] audioData = File.ReadAllBytes("sampleaudio.mp3");
    IAudio audio = pres.Audios.AddAudio(audioData);
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Ορίζει το offset έναρξης περικοπής σε 1.5 δευτερόλεπτα
    // Ορίζει το offset λήξης περικοπής σε 2 δευτερόλεπτα

    // Ορίζει τη διάρκεια εξασθένισης εισόδου σε 200 ms
    // Ορίζει τη διάρκεια εξασθένισης εξόδου σε 500 ms

    pres.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
}
```

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ανακτήσετε ένα πλαίσιο ήχου με ενσωματωμένο ήχο και να ορίσετε την ένταση του στο 85%:

```c#
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // Λαμβάνει ένα σχήμα πλαισίου ήχου
    IAudioFrame audioFrame = (IAudioFrame)pres.Slides[0].Shapes[0];

    // Ορίζει την ένταση ήχου στο 85%
    audioFrame.VolumeValue = 85f;
    
    pres.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
```

## **Διαχείριση Υπότιτλων Ήχου**

Aspose.Slides σας επιτρέπει να προσθέτετε κλειστά υπότιτλους σε ένα πλαίσιο ήχου μέσω της ιδιότητας [CaptionTracks](https://reference.aspose.com/slides/el/net/aspose.slides/iaudioframe/captiontracks/). Η ιδιότητα αυτή επιστρέφει ένα [ICaptionsCollection](https://reference.aspose.com/slides/el/net/aspose.slides/icaptionscollection/), το οποίο σας επιτρέπει να προσθέτετε κομμάτια υποτίτλων WebVTT, να διατρέχετε τα υπάρχοντα κομμάτια και να τα αφαιρείτε όταν είναι απαραίτητο.

**Προσθήκη Υπότιτλων Ήχου**

Χρησιμοποιήστε την ιδιότητα [CaptionTracks](https://reference.aspose.com/slides/el/net/aspose.slides/iaudioframe/captiontracks/) για να προσαρτήσετε ένα ή περισσότερα κομμάτια υποτίτλων σε ένα πλαίσιο ήχου. Στο παρακάτω παράδειγμα, ένα αρχείο ήχου προστίθεται σε μια διαφάνεια και στη συνέχεια ένα νέο κομμάτι υπότιτλου φορτώνεται από αρχείο `.vtt`.

```cs
using (Presentation presentation = new Presentation())
{
    byte[] audioData = File.ReadAllBytes("audio.mp3");
    IAudio audio = presentation.Audios.AddAudio(audioData);

    ISlide slide = presentation.Slides[0];
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(10, 10, 50, 50, audio);

    // Προσθέτει ένα νέο κομμάτι υπότιτλου από αρχείο WebVTT.
    audioFrame.CaptionTracks.Add("New track", "track.vtt");

    presentation.Save("audio_with_captions.pptx", SaveFormat.Pptx);
}
```

**Εξαγωγή Υπότιτλων Ήχου**

Μπορείτε να διατρέξετε τα κομμάτια υποτίτλων που σχετίζονται με ένα πλαίσιο ήχου και να τα αποθηκεύσετε ως αρχεία `.vtt`. Κάθε κομμάτι υπότιτλου εκθέτει τα δυαδικά του δεδομένα και το μοναδικό του αναγνωριστικό, τα οποία μπορούν να χρησιμοποιηθούν κατά την εξαγωγή των υποτίτλων.

```cs
using (Presentation presentation = new Presentation("audio_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IAudioFrame audioFrame)
        {
            foreach (ICaptions captionTrack in audioFrame.CaptionTracks)
            {
                // Αποθηκεύει το κομμάτι υπότιτλου ως αρχείο .vtt.
                File.WriteAllBytes($"{captionTrack.CaptionId}.vtt", captionTrack.BinaryData);
            }
        }
    }
}
```

**Αφαίρεση Υπότιτλων Ήχου**

Για να αφαιρέσετε τους υπότιτλους από ένα πλαίσιο ήχου, χρησιμοποιήστε τις μεθόδους που παρέχονται από το [ICaptionsCollection](https://reference.aspose.com/slides/el/net/aspose.slides/icaptionscollection/), όπως [Clear](https://reference.aspose.com/slides/el/net/aspose.slides/icaptionscollection/clear/), [Remove](https://reference.aspose.com/slides/el/net/aspose.slides/icaptionscollection/remove/), ή [RemoveAt](https://reference.aspose.com/slides/el/net/aspose.slides/icaptionscollection/removeat/). Το παρακάτω παράδειγμα αφαιρεί όλα τα κομμάτια υποτίτλων από ένα πλαίσιο ήχου.

```cs
using (Presentation presentation = new Presentation("audio_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IAudioFrame audioFrame = slide.Shapes[0] as IAudioFrame;

    // Αφαίρεση όλων των κομματιών υποτίτλων από το πλαίσιο ήχου.
    audioFrame.CaptionTracks.Clear();

    presentation.Save("audio_without_captions.pptx", SaveFormat.Pptx);
}
```

## **Εξαγωγή Ήχου**

Aspose.Slides for .NET σας επιτρέπει να εξάγετε τον ήχο που χρησιμοποιείται στις μεταβάσεις της παρουσίασης διαφανειών. Για παράδειγμα, μπορείτε να εξάγετε τον ήχο που χρησιμοποιείται σε μια συγκεκριμένη διαφάνεια.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) και φορτώστε την παρουσίαση που περιέχει τον ήχο.
2. Αποκτήστε την αναφορά της σχετικής διαφάνειας μέσω του δείκτη της.
3. Προσπελάστε τις μεταβάσεις της παρουσίασης για τη διαφάνεια.
4. Εξάγετε τον ήχο σε δεδομένα bytes.

```c#
string presName = "AudioSlide.pptx";

// Δημιουργεί ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
Presentation pres = new Presentation(presName);

// Προσπελαύνει τη διαφάνεια
ISlide slide = pres.Slides[0];

// Λαμβάνει τα εφέ μετάβασης της παρουσίασης για τη διαφάνεια
ISlideShowTransition transition = slide.SlideShowTransition;

//Εξάγει τον ήχο σε πίνακα byte
byte[] audio = transition.Sound.BinaryData;

System.Console.WriteLine("Length: " + audio.Length);
```

## **Συχνές Ερωτήσεις**

**Μπορώ να επαναχρησιμοποιήσω το ίδιο αρχείο ήχου σε πολλές διαφάνειες χωρίς να αυξήσω το μέγεθος του αρχείου;**

Ναι. Προσθέστε τον ήχο μία φορά στη [audio collection](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/audios/) κοινή της παρουσίασης και δημιουργήστε επιπλέον πλαίσια ήχου που αναφέρονται σε αυτό το υπάρχον μέσο. Αυτό αποτρέπει την αντιγραφή των δεδομένων πολυμέσων και διατηρεί το μέγεθος της παρουσίασης υπό έλεγχο.

**Μπορώ να αντικαταστήσω τον ήχο σε ένα υπάρχον πλαίσιο ήχου χωρίς να δημιουργήσω ξανά το σχήμα;**

Ναί. Για έναν συνδεδεμένο ήχο, ενημερώστε το [link path](https://reference.aspose.com/slides/el/net/aspose.slides/audioframe/linkpathlong/) ώστε να δείχνει στο νέο αρχείο. Για έναν ενσωματωμένο ήχο, αντικαταστήστε το αντικείμενο [embedded audio](https://reference.aspose.com/slides/el/net/aspose.slides/audioframe/embeddedaudio/) με ένα άλλο από τη [audio collection](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/audios/) της παρουσίασης. Η μορφοποίηση του πλαισίου και οι περισσότερες ρυθμίσεις αναπαραγωγής παραμένουν αμετάβλητες.

**Αλλάζει η περικοπή τα υποκείμενα δεδομένα ήχου που αποθηκεύονται στην παρουσίαση;**

Όχι. Η περικοπή ρυθμίζει μόνο τα όρια αναπαραγωγής. Τα αρχικά bytes του ήχου παραμένουν αμετάβλητα και προσβάσιμα μέσω του ενσωματωμένου ήχου ή της συλλογής ήχου της παρουσίασης.