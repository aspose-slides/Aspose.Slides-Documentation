---
title: "Διαχείριση ήχου σε παρουσιάσεις με C++"
linktitle: "Πλαίσιο ήχου"
type: docs
weight: 10
url: /el/cpp/audio-frame/
keywords:
- ήχος
- πλαίσιο ήχου
- μικρογραφία
- προσθήκη ήχου
- ιδιότητες ήχου
- επιλογές ήχου
- εξαγωγή ήχου
- C++
- Aspose.Slides
description: "Δημιουργία και έλεγχος πλαισίων ήχου στην Aspose.Slides για C++ — παραδείγματα κώδικα για ενσωμάτωση, περικοπή, βρόχο και διαμόρφωση της αναπαραγωγής σε παρουσιάσεις PPT, PPTX και ODP."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργαστείτε με πλαίσια ήχου στην Aspose.Slides. Δείχνει πώς να προσθέσετε ενσωματωμένο ήχο στις διαφάνειες, να προσαρμόσετε τη μικρογραφία του πλαισίου ήχου, να διαμορφώσετε επιλογές αναπαραγωγής όπως η ένταση, η επανάληψη, η απόκρυψη, η περικοπή και οι διάρκειες εξασθένισης, και να εξάγετε ήχο που χρησιμοποιείται στις μεταβάσεις της παρουσίασης.

## **Δημιουργία Πλαισίων Ήχου**

Η Aspose.Slides για C++ επιτρέπει την προσθήκη αρχείων ήχου σε διαφάνειες. Τα αρχεία ήχου ενσωματώνονται στις διαφάνειες ως πλαίσια ήχου. 

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation).
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της.
3. Φορτώστε τη ροή του αρχείου ήχου που θέλετε να ενσωματώσετε στη διαφάνεια.
4. Προσθέστε το ενσωματωμένο πλαίσιο ήχου (που περιέχει το αρχείο ήχου) στη διαφάνεια.
5. Ορίστε το [PlayMode](https://reference.aspose.com/slides/el/cpp/namespace/aspose.slides#a1e0dfa632c5498e693145d42f3cf8e4c) και το `Volume` που εκθέτει το αντικείμενο [IAudioFrame](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_audio_frame).
6. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας C++ δείχνει πώς να προσθέσετε ένα ενσωματωμένο πλαίσιο ήχου σε μια διαφάνεια:

``` cpp
// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
auto pres = System::MakeObject<Presentation>();

// Αποκτά την πρώτη διαφάνεια
auto sld = pres->get_Slides()->idx_get(0);

// Φορτώνει το αρχείο ήχου wav σε ροή
auto fstr = System::MakeObject<FileStream>(u"sampleaudio.wav", FileMode::Open, FileAccess::Read);

// Προσθέτει το Πλαίσιο Ήχου
auto audioFrame = sld->get_Shapes()->AddAudioFrameEmbedded(50.0f, 150.0f, 100.0f, 100.0f, fstr);

// Ορίζει τη Λειτουργία Αναπαραγωγής και την Ένταση του Ήχου
audioFrame->set_PlayMode(AudioPlayModePreset::Auto);
audioFrame->set_Volume(AudioVolumeMode::Loud);

// Γράφει το αρχείο PowerPoint στον δίσκο
pres->Save(u"AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
```

## **Αλλαγή της Μικρογραφίας του Πλαισίου Ήχου**

Όταν προσθέτετε ένα αρχείο ήχου σε μια παρουσίαση, ο ήχος εμφανίζεται ως πλαίσιο με μια προεπιλεγμένη τυποποιημένη εικόνα (δείτε την εικόνα στην παρακάτω ενότητα). Μπορείτε να αλλάξετε τη μικρογραφία του πλαισίου ήχου (ορίστε την προτιμώμενη εικόνα).

Αυτός ο κώδικας C++ δείχνει πώς να αλλάξετε τη μικρογραφία ή την προεπισκόπηση ενός πλαισίου ήχου:

```cpp
auto presentation = System::MakeObject<Presentation>();
        
auto slide = presentation->get_Slides()->idx_get(0);
        
// Προσθέτει ένα πλαίσιο ήχου στη διαφάνεια με καθορισμένη θέση και μέγεθος.
auto audioStream = System::MakeObject<System::IO::FileStream>(u"sample2.mp3", 
    System::IO::FileMode::Open, System::IO::FileAccess::Read);
    
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(150.0f, 100.0f, 50.0f, 50.0f, audioStream);
            
// Προσθέτει μια εικόνα στους πόρους της παρουσίασης.
auto imageStream = System::IO::File::OpenRead(u"eagle.jpeg");
auto audioImage = presentation->get_Images()->AddImage(imageStream);
            
// Ορίζει την εικόνα για το πλαίσιο ήχου. // <-----
        
//Αποθηκεύει την τροποποιημένη παρουσίαση στο δίσκο
presentation->Save(u"example_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Αλλαγή Επιλογών Αναπαραγωγής Ήχου**

Η Aspose.Slides για C++ επιτρέπει την αλλαγή επιλογών που ελέγχουν την αναπαραγωγή ή τις ιδιότητες ενός ήχου. Για παράδειγμα, μπορείτε να ρυθμίσετε την ένταση του ήχου, να ορίσετε αναπαραγωγή σε βρόχο ή ακόμη και να κρύψετε το εικονίδιο ήχου.

Το πλαίσιο **Audio Options** στο Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Οι **Audio Options** του PowerPoint που αντιστοιχούν στις μεθόδους Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/audioframe/) :

- **Start** η λίστα επιλογών ταιριάζει με τη μέθοδο [AudioFrame::set_PlayMode](https://reference.aspose.com/slides/el/cpp/aspose.slides/audioframe/set_playmode/).
- **Volume** ταιριάζει με τη μέθοδο [AudioFrame::set_Volume](https://reference.aspose.com/slides/el/cpp/aspose.slides/audioframe/set_volume/).
- **Play Across Slides** ταιριάζει με τη μέθοδο [AudioFrame::set_PlayAcrossSlides](https://reference.aspose.com/slides/el/cpp/aspose.slides/audioframe/set_playacrossslides/).
- **Loop until Stopped** ταιριάζει με τη μέθοδο [AudioFrame::set_PlayLoopMode](https://reference.aspose.com/slides/el/cpp/aspose.slides/audioframe/set_playloopmode/).
- **Hide During Show** ταιριάζει με τη μέθοδο [AudioFrame::set_HideAtShowing](https://reference.aspose.com/slides/el/cpp/aspose.slides/audioframe/set_hideatshowing/).
- **Rewind after Playing** ταιριάζει με τη μέθοδο [AudioFrame::set_RewindAudio](https://reference.aspose.com/slides/el/cpp/aspose.slides/audioframe/set_rewindaudio/).

Οι επιλογές **Editing** του PowerPoint που αντιστοιχούν στις ιδιότητες Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/audioframe/) :

- **Fade In** ταιριάζει με τη μέθοδο [AudioFrame.set_FadeInDuration](https://reference.aspose.com/slides/el/cpp/aspose.slides/audioframe/set_fadeinduration/).
- **Fade Out** ταιριάζει με τη μέθοδο [AudioFrame.set_FadeOutDuration](https://reference.aspose.com/slides/el/cpp/aspose.slides/audioframe/set_fadeoutduration/).
- **Trim Audio Start Time** ταιριάζει με τη μέθοδο [AudioFrame.set_TrimFromStart](https://reference.aspose.com/slides/el/cpp/aspose.slides/audioframe/set_trimfromstart/).
- **Trim Audio End Time** η τιμή ισούται με τη διάρκεια του ήχου μείον την τιμή της [AudioFrame.set_TrimFromEnd](https://reference.aspose.com/slides/el/cpp/aspose.slides/audioframe/set_trimfromend/) μεθόδου.

Ο **Volume controll** του PowerPoint στον πίνακα ελέγχου ήχου αντιστοιχεί στη μέθοδο [AudioFrame.set_VolumeValue](https://reference.aspose.com/slides/el/cpp/aspose.slides/audioframe/set_volumevalue/). Σας επιτρέπει να αλλάξετε την ένταση του ήχου ως ποσοστό.

Αυτή είναι η διαδικασία για την αλλαγή των επιλογών αναπαραγωγής ήχου:

1. [Δημιουργία](#creating-audio-frame) ή λήψη του Πλαισίου Ήχου.
2. Ορίστε νέες τιμές για τις ιδιότητες του Πλαισίου Ήχου που θέλετε να προσαρμόσετε.
3. Αποθηκεύστε το τροποποιημένο αρχείο PowerPoint.

Αυτός ο κώδικας C++ παρουσιάζει μια λειτουργία όπου ρυθμίζονται οι επιλογές ενός ήχου:

``` cpp 
auto pres = System::MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");

// Λήψη σχήματος
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0);

// Μετατρέπει το σχήμα σε σχήμα AudioFrame
auto audioFrame = System::ExplicitCast<AudioFrame>(shape);

// Ορίζει τη λειτουργία αναπαραγωγής σε αναπαραγωγή με κλικ
audioFrame->set_PlayMode(AudioPlayModePreset::OnClick);

// Ορίζει την ένταση σε χαμηλή
audioFrame->set_Volume(AudioVolumeMode::Low);

// Ορίζει τον ήχο να αναπαράγεται σε όλες τις διαφάνειες
audioFrame->set_PlayAcrossSlides(true);

// Απενεργοποιεί την επανάληψη του ήχου
audioFrame->set_PlayLoopMode(false);

// Κρύβει το Πλαίσιο Ήχου κατά τη διάρκεια της παρουσίασης
audioFrame->set_HideAtShowing(true);

// Επαναφέρει τον ήχο στην αρχή μετά την αναπαραγωγή
audioFrame->set_RewindAudio(true);

// Αποθηκεύει το αρχείο PowerPoint στο δίσκο
pres->Save(u"AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
```

Αυτό το παράδειγμα C++ δείχνει πώς να προσθέσετε ένα νέο πλαίσιο ήχου με ενσωματωμένο ήχο, να το κόψετε και να ορίσετε τις διάρκειες εξασθένισης:

```cpp
auto pres = MakeObject<Presentation>();
auto slide = pres->get_Slide(0);

auto audioData = File::ReadAllBytes(u"sampleaudio.mp3");
auto audio = pres->get_Audios()->AddAudio(audioData);
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, audio);

// Ορίζει το offset έναρξης περικοπής σε 1.5 δευτερόλεπτα
audioFrame->set_TrimFromStart(1500);
// Ορίζει το offset τέλους περικοπής σε 2 δευτερόλεπτα
audioFrame->set_TrimFromEnd(2000);

// Ορίζει τη διάρκεια fade-in σε 200 ms
audioFrame->set_FadeInDuration(200);
// Ορίζει τη διάρκεια fade-out σε 500 ms
audioFrame->set_FadeOutDuration(500);

pres->Save(u"AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```

Το παρακάτω δείγμα κώδικα δείχνει πώς να ανακτήσετε ένα πλαίσιο ήχου με ενσωματωμένο ήχο και να ορίσετε την ένταση του στο 85%:

```cpp
auto pres = MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");
    
// Λαμβάνει ένα σχήμα πλαισίου ήχου
auto audioFrame = ExplicitCast<IAudioFrame>(pres->get_Slide(0)->get_Shape(0));

// Ορίζει την ένταση ήχου στο 85%
audioFrame->set_VolumeValue(85);

pres->Save(u"AudioFrameValue_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```

## **Διαχείριση Υπότιτλων Ήχου**

Η Aspose.Slides επιτρέπει την προσθήκη κλειστών υπότιτλων σε ένα πλαίσιο ήχου μέσω της μεθόδου [get_CaptionTracks](https://reference.aspose.com/slides/el/cpp/aspose.slides/iaudioframe/get_captiontracks/). Αυτή η μέθοδος επιστρέφει ένα [ICaptionsCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/icaptionscollection/), το οποίο σας επιτρέπει να προσθέσετε κομμάτια υπότιτλων WebVTT, να διατρέξετε τα υπάρχοντα κομμάτια και να τα αφαιρέσετε όταν χρειάζεται.

**Προσθήκη Υπότιτλων Ήχου**

Χρησιμοποιήστε τη μέθοδο [get_CaptionTracks](https://reference.aspose.com/slides/el/cpp/aspose.slides/iaudioframe/get_captiontracks/) για να συνδέσετε μία ή περισσότερες λωρίδες υποτίτλων σε ένα πλαίσιο ήχου. Στο παρακάτω παράδειγμα, ένα αρχείο ήχου προστίθεται σε μια διαφάνεια, και στη συνέχεια φορτώνεται μια νέα λωρίδα υπότιτλου από αρχείο `.vtt`.

```cpp
auto presentation = MakeObject<Presentation>();

auto audioData = File::ReadAllBytes(u"audio.mp3");
auto audio = presentation->get_Audios()->AddAudio(audioData);

auto slide = presentation->get_Slide(0);
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(10, 10, 50, 50, audio);

// Add a new caption track from a WebVTT file.
audioFrame->get_CaptionTracks()->Add(u"New track", u"track.vtt");

presentation->Save(u"audio_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

**Εξαγωγή Υπότιτλων Ήχου**

Μπορείτε να διατρέξετε τις λωρίδες υποτίτλων που σχετίζονται με ένα πλαίσιο ήχου και να τις αποθηκεύσετε ως αρχεία `.vtt`. Κάθε λωρίδα υπότιτλου εκθέτει τα δυαδικά της δεδομένα και το μοναδικό της αναγνωριστικό, τα οποία μπορούν να χρησιμοποιηθούν κατά την εξαγωγή των υποτίτλων.

```cpp
auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);
for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IAudioFrame>(shape))
    {
        auto audioFrame = ExplicitCast<IAudioFrame>(shape);
        for (auto&& captionTrack : audioFrame->get_CaptionTracks())
        {
            // Αποθηκεύει κάθε λωρίδα υπότιτλου ως αρχείο .vtt.
            auto fileName = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(fileName, captionTrack->get_BinaryData());
        }
    }
}
presentation->Dispose();
```

**Αφαίρεση Υπότιτλων Ήχου**

Για να αφαιρέσετε υπότιτλους από ένα πλαίσιο ήχου, χρησιμοποιήστε τις μεθόδους που παρέχει το [ICaptionsCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/icaptionscollection/), όπως [Clear](https://reference.aspose.com/slides/el/cpp/aspose.slides/icaptionscollection/clear/), [Remove](https://reference.aspose.com/slides/el/cpp/aspose.slides/icaptionscollection/remove/), ή [RemoveAt](https://reference.aspose.com/slides/el/cpp/aspose.slides/icaptionscollection/removeat/). Το παρακάτω παράδειγμα αφαιρεί όλες τις λωρίδες υποτίτλων από ένα πλαίσιο ήχου.

```cpp
auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto audioFrame = ExplicitCast<IAudioFrame>(slide->get_Shape(0));

// Αφαιρέστε όλες τις λωρίδες υποτίτλων από το πλαίσιο ήχου.
audioFrame->get_CaptionTracks()->Clear();

presentation->Save(u"audio_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Εξαγωγή Ήχου**

Η Aspose.Slides επιτρέπει την εξαγωγή του ήχου που χρησιμοποιείται στις μεταβάσεις της παρουσίασης. Για παράδειγμα, μπορείτε να εξάγετε τον ήχο που χρησιμοποιείται σε μια συγκεκριμένη διαφάνεια.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation) και φορτώστε την παρουσίαση που περιέχει τον ήχο.
2. Αποκτήστε την αναφορά της αντίστοιχης διαφάνειας μέσω του δείκτη της.
3. Πρόσβαση στις μεταβάσεις της παρουσίασης για τη διαφάνεια.
4. Εξαγωγή του ήχου σε δεδομένα byte.

Αυτός ο κώδικας C++ δείχνει πώς να εξάγετε τον ήχο που χρησιμοποιείται σε μια διαφάνεια:

``` cpp
String presName = u"AudioSlide.pptx";

// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
auto pres = System::MakeObject<Presentation>(presName);

// Αποκτά τη ζητούμενη διαφάνεια
auto slide = pres->get_Slides()->idx_get(0);

// Λαμβάνει τα εφέ μετάβασης παρουσίασης για τη διαφάνεια
auto transition = slide->get_SlideShowTransition();

// Εξάγει τον ήχο σε πίνακα byte
auto audio = transition->get_Sound()->get_BinaryData();

Console::WriteLine(String(u"Length: ") + audio->get_Length());
```

## **Συχνές ερωτήσεις**

**Μπορώ να ξαναχρησιμοποιήσω το ίδιο αρχείο ήχου σε πολλές διαφάνειες χωρίς να αυξήσω το μέγεθος του αρχείου;**

Ναι. Προσθέστε τον ήχο μία φορά στη κοινόχρηστη [audio collection](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_audios/) της παρουσίασης και δημιουργήστε πρόσθετα πλαίσια ήχου που παραπέμπουν σε αυτό το υπάρχον αντικείμενο. Αυτό αποτρέπει την αντιγραφή των αρχείων πολυμέσων και διατηρεί το μέγεθος της παρουσίασης υπό έλεγχο.

**Μπορώ να αντικαταστήσω τον ήχο σε υπάρχον πλαίσιο ήχου χωρίς να ξαναδημιουργήσω το σχήμα;**

Ναι. Για έναν συνδεδεμένο ήχο, ενημερώστε το [link path](https://reference.aspose.com/slides/el/cpp/aspose.slides/audioframe/set_linkpathlong/) ώστε να δείχνει στο νέο αρχείο. Για έναν ενσωματωμένο ήχο, αντικαταστήστε το αντικείμενο [embedded audio](https://reference.aspose.com/slides/el/cpp/aspose.slides/audioframe/set_embeddedaudio/) με κάποιο άλλο από την [audio collection](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_audios/) της παρουσίασης. Η μορφοποίηση του πλαισίου και οι περισσότερες ρυθμίσεις αναπαραγωγής παραμένουν αμετάβλητες.

**Η περικοπή αλλάζει τα υποκείμενα δεδομένα ήχου που αποθηκεύονται στην παρουσίαση;**

Όχι. Η περικοπή προσαρμόζει μόνο τα όρια της αναπαραγωγής. Τα αρχικά bytes του ήχου παραμένουν αμετάβλητα και προσβάσιμα μέσω του ενσωματωμένου ήχου ή της audio collection της παρουσίασης.