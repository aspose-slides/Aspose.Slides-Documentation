---
title: Διαχείριση πλαισίων ήχου σε παρουσιάσεις με C++
linktitle: Πλαίσιο ήχου
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
description: "Ενσωματώστε ήχο σε διαφάνειες, αλλάξτε το εικονίδιο ήχου, διαμορφώστε την αναπαραγωγή, διαχειριστείτε υπότιτλους WebVTT και εξάγετε ήχους μετάβασης διαφάνειας με το Aspose.Slides για C++."
---
## **Επισκόπηση**

Ένα πλαίσιο ήχου σάς επιτρέπει να αναπαράγετε έναν ήχο σε μια διαφάνεια. Με το Aspose.Slides for C++ μπορείτε να ενσωματώσετε ένα αποσπάσμα ήχου, να επιλέξετε την εικόνα που το αντιπροσωπεύει, να ρυθμίσετε την αναπαραγωγή και να προσθέσετε υπότιτλους. Μπορείτε επίσης να ανακτήσετε έναν ήχο που έχει οριστεί για μια μετάβαση διαφάνειας.

## **Δημιουργία Πλαισίων Ήχου**

Χρησιμοποιήστε [AddAudioFrameEmbedded](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addaudioframeembedded/) για να ενσωματώσετε ένα τοπικό αποσπάσμα ήχου στην πρώτη διαφάνεια. Οι δύο πρώτες συντεταγμένες τοποθετούν το πλαίσιο στη διαφάνεια και οι δύο επόμενες καθορίζουν το πλάτος και το ύψος του, όλα σε μονάδες σημείων. Αυτό το παράδειγμα καλεί το [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_playmode/) για να ξεκινήσει το αποσπάσμα αυτόματα και καλεί το [set_Volume](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_volume/) για να επιλέξει την έντονη προεπιλογή.

```cpp
#include <DOM/AudioPlayModePreset.h>
#include <DOM/AudioVolumeMode.h>
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto audioStream = File::OpenRead(u"audio.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 150, 100, 100, audioStream);
audioFrame->set_PlayMode(AudioPlayModePreset::Auto);
audioFrame->set_Volume(AudioVolumeMode::Loud);

presentation->Save(u"AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
```

## **Αλλαγή Μικρογραφίας Πλαισίου Ήχου**

Από προεπιλογή, ένα πλαίσιο ήχου εμφανίζει ένα εικονίδιο ηχείου. Για να εμφανίσετε μια προσαρμοσμένη μικρογραφία, προσθέστε μια εικόνα στην παρουσίαση με το [AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/) και ορίστε τη ως εικόνα του πλαισίου με το [set_Image](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/set_image/). Το παράδειγμα χρησιμοποιεί ένα JPEG ως μικρογραφία για ένα ενσωματωμένο αποσπάσμα ήχου.

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageStream = File::OpenRead(u"eagle.jpeg");
auto thumbnail = presentation->get_Images()->AddImage(imageStream);

auto audioStream = File::OpenRead(u"audio.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
audioFrame->get_PictureFormat()->get_Picture()->set_Image(thumbnail);

presentation->Save(u"example_out.pptx", SaveFormat::Pptx);
```

## **Αλλαγή Επιλογών Αναπαραγωγής Ήχου**

Οι **Ρυθμίσεις Ήχου** του PowerPoint καθορίζουν πότε ξεκινά ένα αποσπάσμα, πόσο έντονα ακούγεται και πώς συμπεριφέρεται κατά τη διάρκεια της παρουσίασης.

![PowerPoint Audio Options controls for an audio frame](audio_frame_0.png)

| Έλεγχος PowerPoint | Μέθοδος Aspose.Slides for C++ |
| --- | --- |
| Έναρξη | [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_playmode/) |
| Προκαθορισμένη ένταση | [set_Volume](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_volume/) |
| Αναπαραγωγή σε όλες τις διαφάνειες | [set_PlayAcrossSlides](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_playacrossslides/) |
| Επανάληψη μέχρι να σταματήσει | [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_playloopmode/) |
| Απόκρυψη κατά την εμφάνιση | [set_HideAtShowing](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_hideatshowing/) |
| Επιστροφή στην αρχή μετά την αναπαραγωγή | [set_RewindAudio](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_rewindaudio/) |
| Εφέ εξασθένισης (Fade In) | [set_FadeInDuration](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_fadeinduration/) |
| Εφέ εξασθένισης (Fade Out) | [set_FadeOutDuration](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_fadeoutduration/) |
| Κόψιμο ήχου - χρόνος έναρξης | [set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_trimfromstart/) |
| Κόψιμο ήχου - χρόνος λήξης | [set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_trimfromend/) |
| Ολισθητής έντασης | [set_VolumeValue](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_volumevalue/) |

Το παράδειγμα εντοπίζει το πρώτο πλαίσιο ήχου στην πρώτη διαφάνεια, καλεί το [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_playmode/) για να ξεκινήσει η αναπαραγωγή με κλικ και επιλέγει τη χαμηλή προεπιλεγμένη ένταση. Το αποσπάσμα συνεχίζει ανάμεσα στις διαφάνειες με απενεργοποιημένη επανάληψη. Το εικονίδιο παραμένει κρυφό κατά τη διάρκεια της παρουσίασης και το αποσπάσμα επανέρχεται στην αρχή μετά την αναπαραγωγή.

```cpp
#include <DOM/AudioPlayModePreset.h>
#include <DOM/AudioVolumeMode.h>
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IAudioFrame> audioFrame;
for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    audioFrame = AsCast<IAudioFrame>(shape);
    if (audioFrame)
        break;
}

if (audioFrame)
{
    audioFrame->set_PlayMode(AudioPlayModePreset::OnClick);
    audioFrame->set_Volume(AudioVolumeMode::Low);
    audioFrame->set_PlayAcrossSlides(true);
    audioFrame->set_PlayLoopMode(false);
    audioFrame->set_HideAtShowing(true);
    audioFrame->set_RewindAudio(true);

    presentation->Save(u"AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The first slide has no audio frame.");
}
```

Για ένα αποσπάσμα μεγαλύτερο των 3,5 δευτερολέπτων, το παράδειγμα παραλείπει τα πρώτα 1,5 δευτερόλεπτα και τα τελευταία 2 δευτερόλεπτα. Το όρισμα του [set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_trimfromend/) καθορίζει τη διάρκεια που θα αφαιρεθεί από το τέλος του αποσπάσματος. Για να λάβετε το χρονικό σημείο λήξης που εμφανίζεται στο PowerPoint, αφαιρέστε αυτήν την απόκλιση από τη συνολική διάρκεια του αποσπάσματος. Το κομμένο αποσπάσμα εξασθενεί (fade in) μέσα σε 200 χιλιοστά του δευτερολέπτου και εξασθενεί (fade out) μέσα σε 500 χιλιοστά του δευτερολέπτου. Οι τέσσερις μέθοδοι λαμβάνουν τιμές σε χιλιοστά του δευτερολέπτου.

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto audioStream = File::OpenRead(u"audio.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, audioStream);
audioFrame->set_TrimFromStart(1500);
audioFrame->set_TrimFromEnd(2000);
audioFrame->set_FadeInDuration(200);
audioFrame->set_FadeOutDuration(500);

presentation->Save(u"AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
```

Για να ορίσετε την ένταση αναπαραγωγής σε συγκεκριμένο ποσοστό, χρησιμοποιήστε το [set_VolumeValue](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_volumevalue/). Αυτό το παράδειγμα θέτει το πρώτο πλαίσιο ήχου στην πρώτη διαφάνεια στο 85 %.

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IAudioFrame> audioFrame;
for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    audioFrame = AsCast<IAudioFrame>(shape);
    if (audioFrame)
        break;
}

if (audioFrame)
{
    audioFrame->set_VolumeValue(85);

    presentation->Save(u"AudioFrameValue_out.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The first slide has no audio frame.");
}
```

## **Διαχείριση Υπότιτλων Ήχου**

Κάθε πλαίσιο ήχου εκθέτει τη συλλογή των υποτίτλων του μέσω του [get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/get_captiontracks/). Χρησιμοποιήστε το για να συνδέσετε υπότιτλους WebVTT με το αποσπάσμα, να εξάγετε υπάρχοντες δρόμους ή να τους αφαιρέσετε.

### **Προσθήκη Υπότιτλων Ήχου**

Το παράδειγμα ενσωματώνει ένα αποσπάσμα ήχου στην πρώτη διαφάνεια και χρησιμοποιεί το [ICaptionsCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/add/) για να προσθέσει έναν τοπικό δρόμο WebVTT. Το πρώτο όρισμα παρέχει την ετικέτα του δρόμου και το δεύτερο καθορίζει το αρχείο που περιέχει τους χρονικά σημειωμένους υπότιτλους.

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/ICaptions.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto audioStream = File::OpenRead(u"audio.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(10, 10, 50, 50, audioStream);
audioFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"audio_with_captions.pptx", SaveFormat::Pptx);
```

### **Εξαγωγή Υπότιτλων Ήχου**

Αυτό το παράδειγμα εξάγει κάθε δρόμο υπότιτλου που είναι συνδεδεμένος με ένα πλαίσιο ήχου στην πρώτη διαφάνεια. Γράφει τα byte που επιστρέφει το [get_BinaryData](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/get_binarydata/) σε ένα αρχείο WebVTT και χρησιμοποιεί την τιμή που επιστρέφει το [get_CaptionId](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/get_captionid/) ως όνομα αρχείου, ώστε κάθε δρόμος να έχει ξεχωριστή έξοδο.

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/ICaptions.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/enumerator_adapter.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    auto audioFrame = AsCast<IAudioFrame>(shape);
    if (!audioFrame)
        continue;

    for (auto&& track : IterateOver(audioFrame->get_CaptionTracks()))
    {
        auto fileName = track->get_CaptionId().ToString() + u".vtt";
        File::WriteAllBytes(fileName, track->get_BinaryData());
    }
}
```

### **Αφαίρεση Υπότιτλων Ήχου**

Χρησιμοποιήστε το [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/remove/) ή το [RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/removeat/) για να διαγράψετε έναν μεμονωμένο δρόμο. Το παράδειγμα χρησιμοποιεί το [Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/clear/) για να αφαιρέσει όλους τους υπότιτλους από το πρώτο πλαίσιο ήχου στην πρώτη διαφάνεια, διατηρώντας το αποσπάσμα.

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/ICaptions.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IAudioFrame> audioFrame;
for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    audioFrame = AsCast<IAudioFrame>(shape);
    if (audioFrame)
        break;
}

if (audioFrame)
{
    audioFrame->get_CaptionTracks()->Clear();

    presentation->Save(u"audio_without_captions.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The first slide has no audio frame.");
}
```

### **Αναζήτηση Γραμμής σε Υπότιτλους Ήχου**

Για να εντοπίσετε μια γραμμή στους υπότιτλους ήχου στην πρώτη διαφάνεια, καλέστε το [get_DataAsString](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/get_dataasstring/) σε κάθε δρόμο ώστε να διαβάσετε το κείμενο WebVTT στη μνήμη. Σε ένα απλό κείμενο WebVTT cue, η γραμμή χρονοδείκτη περιέχει `-->`, ακολουθούν οι γραμμές υπότιτλου και μια κενή γραμμή τελειώνει το cue. Αυτό το παράδειγμα εκτυπώνει την ετικέτα του δρόμου και κάθε γραμμή υπότιτλου που περιέχει τη λέξη “café”.

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/ICaptions.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/io/string_reader.h>
#include <system/smart_ptr.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    auto audioFrame = AsCast<IAudioFrame>(shape);
    if (!audioFrame)
        continue;

    for (auto&& track : IterateOver(audioFrame->get_CaptionTracks()))
    {
        auto reader = MakeObject<StringReader>(track->get_DataAsString());
        auto inCue = false;
        for (auto line = reader->ReadLine(); !line.IsNull(); line = reader->ReadLine())
        {
            if (line.get_Length() == 0)
                inCue = false;
            else if (line.Contains(u"-->"))
                inCue = true;
            else if (inCue && line.IndexOf(u"caf\u00e9", StringComparison::OrdinalIgnoreCase) >= 0)
                Console::WriteLine(track->get_Label() + u": " + line);
        }
    }
}
```

## **Εξαγωγή Ήχου**

Μια μετάβαση διαφάνειας μπορεί να έχει το δικό της ήχο. Για να το ανακτήσετε, καλέστε το [get_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_sound/) στη μετάβαση. Το παράδειγμα ανακτά τα byte ήχου με το [get_BinaryData](https://reference.aspose.com/slides/cpp/aspose.slides/iaudio/get_binarydata/) και εκτυπώνει τον αριθμό των byte. Εάν η πρώτη διαφάνεια δεν έχει ήχο μετάβασης, εκτυπώνει αντίστοιχο μήνυμα.

```cpp
#include <DOM/IAudio.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"AudioSlide.pptx");
auto slide = presentation->get_Slide(0);

auto sound = slide->get_SlideShowTransition()->get_Sound();
if (sound)
{
    auto audioData = sound->get_BinaryData();
    Console::WriteLine(u"Transition sound: {0} bytes.", audioData->get_Length());
}
else
{
    Console::WriteLine(u"The first slide has no transition sound.");
}
```

## **ΣΣΑ**

**Μπορώ να ξαναχρησιμοποιήσω το ίδιο αποσπάσμα ήχου σε πολλές διαφάνειες χωρίς να το αντιγράψω;**

Ναι. Προσθέστε το αποσπάσμα μία φορά στη [audio collection](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_audios/) της παρουσίασης και περάστε το ίδιο αντικείμενο ήχου στο [AddAudioFrameEmbedded](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addaudioframeembedded/) για κάθε διαφάνεια.

**Μπορώ να αντικαταστήσω τον ήχο σε ένα υπάρχον πλαίσιο ήχου;**

Ναι. Για έναν συνδεδεμένο ήχο, καλέστε το [set_LinkPathLong](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_linkpathlong/) με τη διαδρομή του αρχείου αντικατάστασης. Για έναν ενσωματωμένο ήχο, περάστε άλλο αποσπάσμα από τη συλλογή ήχου της παρουσίασης στο [set_EmbeddedAudio](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_embeddedaudio/). Και οι δύο προσεγγίσεις διατηρούν το υπάρχον πλαίσιο.

**Αλλάζει η κοπή τα δεδομένα ήχου που αποθηκεύονται στην παρουσίαση;**

Όχι. Τα [set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_trimfromstart/) και [set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_trimfromend/) ορίζουν τα όρια αναπαραγωγής. Μπορείτε ακόμη να ανακτήσετε το πλήρες αποσπάσμα μέσω του [get_EmbeddedAudio](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/get_embeddedaudio/).