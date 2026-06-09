---
title: Βίντεο
type: docs
weight: 80
url: /el/cpp/examples/elements/video/
keywords:
- παράδειγμα κώδικα
- βίντεο
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Προσθέστε και ελέγξτε βίντεο με το Aspose.Slides for C++: εισαγωγή, αναπαραγωγή, περικοπή, ορισμός καρέ αφίσας και εξαγωγή με παραδείγματα C++ για παρουσιάσεις PPT, PPTX και ODP."
---
Το άρθρο αυτό δείχνει πώς να ενσωματώσετε καρέ βίντεο και να ορίσετε επιλογές αναπαραγωγής χρησιμοποιώντας **Aspose.Slides for C++**.

## **Προσθήκη Καρέ Βίντεο**

Εισάγετε ένα κενό καρέ βίντεο σε μια διαφάνεια.

```cpp
static void AddVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Προσθήκη βίντεο.
    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    presentation->Dispose();
}
```

## **Πρόσβαση σε Καρέ Βίντεο**

Ανακτήστε το πρώτο καρέ βίντεο που προστέθηκε σε μια διαφάνεια.

```cpp
static void AccessVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // Πρόσβαση στο πρώτο καρέ βίντεο στη διαφάνεια.
    auto firstVideo = SharedPtr<IVideoFrame>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IVideoFrame>(shape))
        {
            firstVideo = ExplicitCast<IVideoFrame>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **Αφαίρεση Καρέ Βίντεο**

Διαγράψτε ένα καρέ βίντεο από τη διαφάνεια.

```cpp
static void RemoveVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // Αφαίρεση του καρέ βίντεο.
    slide->get_Shapes()->Remove(videoFrame);

    presentation->Dispose();
}
```

## **Ορισμός Αναπαραγωγής Βίντεο**

Ρυθμίστε το βίντεο να παίζει αυτόματα όταν εμφανίζεται η διαφάνεια.

```cpp
static void SetVideoPlayback()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // Ρύθμιση του βίντεο ώστε να αναπαράγεται αυτόματα.
    videoFrame->set_PlayMode(VideoPlayModePreset::Auto);

    presentation->Dispose();
}
```