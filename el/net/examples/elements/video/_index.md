---
title: Βίντεο
type: docs
weight: 80
url: /el/net/examples/elements/video/
keywords:
- βίντεο
- καρέ βίντεο
- προσθήκη βίντεο
- πρόσβαση βίντεο
- αφαίρεση βίντεο
- αναπαραγωγή βίντεο
- παράδειγμα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Προσθέστε και ελέγξτε βίντεο με το Aspose.Slides για .NET: εισαγωγή, αναπαραγωγή, περικοπή, ορισμός καρέ αφίσας και εξαγωγή με παραδείγματα C# για παρουσιάσεις PPT, PPTX και ODP."
---
Αυτό το άρθρο δείχνει πώς να ενσωματώσετε καρέ βίντεο και να θέσετε επιλογές αναπαραγωγής χρησιμοποιώντας **Aspose.Slides for .NET**.

## **Προσθήκη καρέ βίντεο**

Εισαγάγετε ένα κενό καρέ βίντεο σε μια διαφάνεια.

```csharp
static void AddVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Προσθήκη βίντεο.
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");
}
```

## **Πρόσβαση σε καρέ βίντεο**

Ανακτήστε το πρώτο καρέ βίντεο που προστέθηκε σε μια διαφάνεια.

```csharp
static void AccessVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Πρόσβαση στο πρώτο καρέ βίντεο στη διαφάνεια.
    var firstVideo = slide.Shapes.OfType<IVideoFrame>().First();
}
```

## **Κατάργηση καρέ βίντεο**

Διαγράψτε ένα καρέ βίντεο από τη διαφάνεια.

```csharp
static void RemoveVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Κατάργηση του καρέ βίντεο.
    slide.Shapes.Remove(videoFrame);
}
```

## **Ρύθμιση αναπαραγωγής βίντεο**

Ρυθμίστε το βίντεο ώστε να αναπαράγεται αυτόματα όταν εμφανίζεται η διαφάνεια.

```csharp
static void SetVideoPlayback()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Ρύθμιση του βίντεο ώστε να αναπαράγεται αυτόματα.
    videoFrame.PlayMode = VideoPlayModePreset.Auto;
}
```