---
title: Ήχος
type: docs
weight: 70
url: /el/cpp/examples/elements/audio/
keywords:
- παράδειγμα κώδικα
- ήχος
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Ανακαλύψτε παραδείγματα ήχου Aspose.Slides for C++: εισαγωγή, αναπαραγωγή, αποκοπή και εξαγωγή ήχου σε παρουσιάσεις PPT, PPTX και ODP με σαφή κώδικα C++."
---
Αυτό το άρθρο δείχνει πώς να ενσωματώσετε πλαίσια ήχου και να ελέγξετε την αναπαραγωγή με **Aspose.Slides for C++**. Τα παρακάτω παραδείγματα παρουσιάζουν βασικές λειτουργίες ήχου.

## **Προσθήκη Πλαισίου Ήχου**

Εισάγετε ένα κενό πλαίσιο ήχου που μπορεί αργότερα να περιέχει ενσωματωμένα δεδομένα ήχου.

```cpp
static void AddAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Δημιουργήστε ένα κενό πλαίσιο ήχου (ο ήχος θα ενσωματωθεί αργότερα).
    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    presentation->Dispose();
}
```

## **Πρόσβαση σε Πλαίσιο Ήχου**

Αυτός ο κώδικας ανακτά το πρώτο πλαίσιο ήχου σε μια διαφάνεια.

```cpp
static void AccessAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // Πρόσβαση στο πρώτο πλαίσιο ήχου στη διαφάνεια.
    auto firstAudio = SharedPtr<IAudioFrame>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAudioFrame>(shape))
        {
            firstAudio = ExplicitCast<IAudioFrame>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **Αφαίρεση Πλαισίου Ήχου**

Διαγράψτε ένα πλαίσιο ήχου που προστέθηκε προηγουμένως.

```cpp
static void RemoveAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // Αφαίρεση του πλαισίου ήχου.
    slide->get_Shapes()->Remove(audioFrame);

    presentation->Dispose();
}
```

## **Ρύθμιση Αναπαραγωγής Ήχου**

Ρυθμίστε το πλαίσιο ήχου να αναπαράγεται αυτόματα όταν εμφανίζεται η διαφάνεια.

```cpp
static void SetAudioPlayback()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // Αναπαραγωγή αυτόματα όταν εμφανίζεται η διαφάνεια.
    audioFrame->set_PlayMode(AudioPlayModePreset::Auto);

    presentation->Dispose();
}
```