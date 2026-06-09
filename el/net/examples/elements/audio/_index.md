---
title: Ήχος
type: docs
weight: 70
url: /el/net/examples/elements/audio/
keywords:
- ήχος
- πλαίσιο ήχου
- προσθήκη ήχου
- πρόσβαση ήχου
- αφαίρεση ήχου
- αναπαραγωγή ήχου
- παράδειγμα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Ανακαλύψτε παραδείγματα ήχου του Aspose.Slides για .NET: εισαγωγή, αναπαραγωγή, περικοπή και εξαγωγή ήχου σε παρουσιάσεις PPT, PPTX και ODP με σαφή κώδικα C#."
---
Αυτό το άρθρο δείχνει πώς να ενσωματώσετε πλαίσια ήχου και να ελέγξετε την αναπαραγωγή με **Aspose.Slides for .NET**. Τα παρακάτω παραδείγματα δείχνουν βασικές λειτουργίες ήχου.

## **Προσθήκη πλαισίου ήχου**

Εισάγετε ένα κενό πλαίσιο ήχου που μπορεί αργότερα να περιέχει ενσωματωμένα δεδομένα ήχου.

```csharp
static void AddAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Δημιουργήστε ένα κενό πλαίσιο ήχου (ο ήχος θα ενσωματωθεί αργότερα).
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());
}
```

## **Πρόσβαση σε πλαίσιο ήχου**

Αυτός ο κώδικας ανακτά το πρώτο πλαίσιο ήχου σε μια διαφάνεια.

```csharp
static void AccessAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Πρόσβαση στο πρώτο πλαίσιο ήχου στη διαφάνεια.
    var firstAudio = slide.Shapes.OfType<IAudioFrame>().First();
}
```

## **Αφαίρεση πλαισίου ήχου**

Διαγράψτε ένα πλαίσιο ήχου που είχε προστεθεί προηγουμένως.

```csharp
static void RemoveAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Αφαιρέστε το πλαίσιο ήχου.
    slide.Shapes.Remove(audioFrame);
}
```

## **Ρύθμιση αναπαραγωγής ήχου**

Ρυθμίστε το πλαίσιο ήχου να αναπαράγεται αυτόματα όταν εμφανίζεται η διαφάνεια.

```csharp
static void SetAudioPlayback()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Αναπαραγωγή αυτόματα όταν εμφανίζεται η διαφάνεια.
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
}
```