---
title: Διαχείριση Πλαισίων Βίντεο σε Παρουσιάσεις χρησιμοποιώντας C++
linktitle: Πλαίσιο Βίντεο
type: docs
weight: 10
url: /el/cpp/video-frame/
keywords:
- προσθήκη βίντεο
- δημιουργία βίντεο
- ενσωμάτωση βίντεο
- εξαγωγή βίντεο
- ανάκτηση βίντεο
- πλαίσιο βίντεο
- διαδικτυακή πηγή
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε και να εξάγετε προγραμματιστικά πλαίσια βίντεο σε διαφάνειες PowerPoint και OpenDocument χρησιμοποιώντας Aspose.Slides για C++. Γρήγορος οδηγός χρήσης."
---
## **Εισαγωγή**

Ένα καλά τοποθετημένο βίντεο σε μια παρουσίαση μπορεί να κάνει το μήνυμά σας πιο ελκυστικό και να αυξήσει τα επίπεδα δέσμευσης με το κοινό σας.  

Το PowerPoint σάς επιτρέπει να προσθέσετε βίντεο σε μια διαφάνεια σε μια παρουσίαση με δύο τρόπους:

* Προσθέστε ή ενσωματώστε ένα τοπικό βίντεο (αποθηκευμένο στον υπολογιστή σας)
* Προσθέστε ένα διαδικτυακό βίντεο (από πηγή στο διαδίκτυο όπως το YouTube).

Για να μπορείτε να προσθέσετε βίντεο (αντικείμενα βίντεο) σε μια παρουσίαση, το Aspose.Slides παρέχει τη διεπαφή [IVideo](https://reference.aspose.com/slides/el/cpp/aspose.slides/ivideo/) , τη διεπαφή [IVideoFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ivideoframe/) και άλλους συναφείς τύπους. 

## **Δημιουργία Ενσωματωμένου Πλαισίου Βίντεο**

Εάν το αρχείο βίντεο που θέλετε να προσθέσετε στη διαφάνειά σας είναι αποθηκευμένο τοπικά, μπορείτε να δημιουργήσετε ένα πλαίσιο βίντεο για να ενσωματώσετε το βίντεο στην παρουσίασή σας. 

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) .
2. Λάβετε αναφορά σε μια διαφάνεια μέσω του δείκτη της. 
3. Προσθέστε ένα αντικείμενο [IVideo](https://reference.aspose.com/slides/el/cpp/aspose.slides/ivideo/) και περάστε τη διαδρομή του αρχείου βίντεο για να ενσωματώσετε το βίντεο στην παρουσίαση. 
4. Προσθέστε ένα αντικείμενο [IVideoFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ivideoframe/) για να δημιουργήσετε ένα πλαίσιο για το βίντεο.  
5. Αποθηκεύστε την τροποποιημένη παρουσίαση. 

Αυτός ο κώδικας C++ δείχνει πώς να προσθέσετε ένα βίντεο που είναι αποθηκευμένο τοπικά σε μια παρουσίαση:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

// Loads the video
System::SharedPtr<System::IO::FileStream> fileStream = System::MakeObject<System::IO::FileStream>(u"Wildlife.mp4", System::IO::FileMode::Open, System::IO::FileAccess::Read);
System::SharedPtr<IVideo> video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);

// Gets the first slide and adds a videoframe
pres->get_Slide(0)->get_Shapes()->AddVideoFrame(10.0f, 10.0f, 150.0f, 250.0f, video);

// Saves the presentation to disk
pres->Save(u"pres-with-video.pptx", SaveFormat::Pptx);
```

Εναλλακτικά, μπορείτε να προσθέσετε ένα βίντεο περνώντας άμεσα τη διαδρομή του αρχείου στη μέθοδο [AddVideoFrame()](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishapecollection/addvideoframe/):

``` c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slide(0);
System::SharedPtr<IVideoFrame> vf = sld->get_Shapes()->AddVideoFrame(50.0f, 150.0f, 300.0f, 150.0f, u"video1.avi");
```

## **Δημιουργία Πλαισίου Βίντεο με Βίντεο από Διαδικτυακή Πηγή**

Το Microsoft [PowerPoint 2013 και νεότερες εκδόσεις](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) υποστηρίζουν βίντεο YouTube σε παρουσιάσεις. Εάν το βίντεο που θέλετε να χρησιμοποιήσετε είναι διαθέσιμο στο διαδίκτυο (π.χ. στο YouTube), μπορείτε να το προσθέσετε στην παρουσίασή σας μέσω του διαδικτυακού του συνδέσμου. 

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) .
2. Λάβετε αναφορά σε μια διαφάνεια μέσω του δείκτη της. 
3. Προσθέστε ένα αντικείμενο [IVideo](https://reference.aspose.com/slides/el/cpp/aspose.slides/ivideo/) και περάστε το σύνδεσμο προς το βίντεο.
4. Ορίστε μια μικρογραφία για το πλαίσιο βίντεο. 
5. Αποθηκεύστε την παρουσίαση. 

Αυτός ο κώδικας C++ δείχνει πώς να προσθέσετε ένα βίντεο από το διαδίκτυο σε μια διαφάνεια σε παρουσίαση PowerPoint:

```c++
// Η διαδρομή προς το φάκελο εγγράφων.
const String outPath = u"../out/AddVideoFrameFromWebSource_out.pptx";
const String filePath = u"../templates/video1.avi";

// Δημιουργεί ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Πρόσβαση στην πρώτη διαφάνεια
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Προσθέτει ένα Πλαίσιο Βίντεο 
System::SharedPtr<IVideoFrame> vf = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240,u"https://www.youtube.com/embed/Tj75Arhq5ho");

// Ορίζει τη Λειτουργία Αναπαραγωγής και την Ένταση ήχου του Βίντεο
vf->set_PlayMode(VideoPlayModePreset::Auto);

//Αποθηκεύει την παρουσίαση στο δίσκο
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Διαχείριση Υπότιτλων Βίντεο**

Το Aspose.Slides σάς επιτρέπει να διαχειρίζεστε κλειστούς υπότιτλους για πλαίσια βίντεο σε παρουσιάσεις PowerPoint. Οι υπότιτλοι αποθηκεύονται σε μορφή WebVTT και είναι διαθέσιμοι μέσω της μεθόδου [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/el/cpp/aspose.slides/ivideoframe/get_captiontracks/).  

**Προσθήκη Υπότιτλων σε Πλαίσιο Βίντεο**

Για να προσθέσετε υπότιτλους σε ένα πλαίσιο βίντεο:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) .
2. Προσθέστε ένα βίντεο στην παρουσίαση.
3. Προσθέστε ένα αντικείμενο [IVideoFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ivideoframe/) σε μια διαφάνεια.
4. Χρησιμοποιήστε τη [ICaptionsCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/icaptionscollection/) που επιστρέφεται από τη μέθοδο [get_CaptionTracks](https://reference.aspose.com/slides/el/cpp/aspose.slides/ivideoframe/get_captiontracks/) για να προσθέσετε ένα κομμάτι υπότιτλου WebVTT.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Ο ακόλουθος κώδικας δείχνει πώς να προσθέσετε υπότιτλους σε ένα πλαίσιο βίντεο:

```cpp
auto presentation = MakeObject<Presentation>();

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto slide = presentation->get_Slide(0);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(0, 0, 100, 100, video);

// Adds a new captions track from a WebVTT file.
videoFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"video_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Η διεπαφή [ICaptionsCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/icaptionscollection/) παρέχει επίσης μια υπερφόρτωση που σας επιτρέπει να προσθέσετε υπότιτλους από ροή.  

**Εξαγωγή Υπότιτλων από Πλαίσιο Βίντεο**

Για την εξαγωγή υποτίτλων από ένα πλαίσιο βίντεο:

1. Φορτώστε την παρουσίαση που περιέχει το βίντεο.
2. Βρείτε το αντικείμενο [IVideoFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ivideoframe/) στόχο.
3. Διατρέξτε τα κομμάτια υποτίτλων που επιστρέφονται από τη μέθοδο [get_CaptionTracks](https://reference.aspose.com/slides/el/cpp/aspose.slides/ivideoframe/get_captiontracks/) .
4. Αποθηκεύστε κάθε κομμάτι υπότιτλου σε αρχείο `.vtt` .

Ο ακόλουθος κώδικας δείχνει πώς να εξάγετε υπότιτλους από ένα πλαίσιο βίντεο:

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        for (auto&& captionTrack : videoFrame->get_CaptionTracks())
        {
            // Αποθηκεύει το κομμάτι υποτίτλων σε αρχείο WebVTT.
            auto filePath = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(filePath, captionTrack->get_BinaryData());
        }
    }
}

presentation->Dispose();
```

Κάθε αντικείμενο [ICaptions](https://reference.aspose.com/slides/el/cpp/aspose.slides/icaptions/) εκθέτει το αναγνωριστικό του υπότιτλου, την ετικέτα, τα δυαδικά δεδομένα και τα δεδομένα του υπότιτλου ως συμβολοσειρά UTF-8.  

**Αφαίρεση Υπότιτλων από Πλαίσιο Βίντεο**

Για την αφαίρεση υποτίτλων από ένα πλαίσιο βίντεο:

1. Φορτώστε την παρουσίαση που περιέχει το βίντεο.
2. Λάβετε το αντικείμενο [IVideoFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ivideoframe/) στόχο.
3. Αφαιρέστε τα κομμάτια υποτίτλων από τη συλλογή που επιστρέφεται από τη μέθοδο [get_CaptionTracks](https://reference.aspose.com/slides/el/cpp/aspose.slides/ivideoframe/get_captiontracks/) .
4. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Ο ακόλουθος κώδικας δείχνει πώς να αφαιρέσετε όλους τους υπότιτλους από ένα πλαίσιο βίντεο:

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto videoFrame = ExplicitCast<IVideoFrame>(slide->get_Shape(0));

// Αφαιρεί όλους τους υπότιτλους από το πλαίσιο βίντεο.
videoFrame->get_CaptionTracks()->Clear();

presentation->Save(u"video_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Αν χρειάζεται να αφαιρέσετε μόνο ένα κομμάτι υπότιτλου, χρησιμοποιήστε τις μεθόδους [Remove](https://reference.aspose.com/slides/el/cpp/aspose.slides/icaptionscollection/remove/) ή [RemoveAt](https://reference.aspose.com/slides/el/cpp/aspose.slides/icaptionscollection/removeat/) αντί της [Clear](https://reference.aspose.com/slides/el/cpp/aspose.slides/icaptionscollection/clear/) .

## **Εξαγωγή Βίντεο από Διαφάνεια**

Εκτός από την προσθήκη βίντεο σε διαφάνειες, το Aspose.Slides σάς επιτρέπει να εξάγετε βίντεο ενσωματωμένα σε παρουσιάσεις.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) για να φορτώσετε την παρουσίαση που περιέχει το βίντεο. 
2. Διατρέξτε όλα τα αντικείμενα [ISlide](https://reference.aspose.com/slides/el/cpp/aspose.slides/islide/) .
3. Διατρέξτε όλα τα αντικείμενα [IShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/) για να βρείτε ένα [VideoFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/videoframe/) . 
4. Αποθηκεύστε το βίντεο στο δίσκο.

Αυτός ο κώδικας C++ δείχνει πώς να εξάγετε το βίντεο από μια διαφάνεια παρουσίασης:

```c++
// Η διαδρομή προς τον φάκελο εγγράφων.
const System::String templatePath = u"../templates/Video.pptx";
const System::String outPath = u"../out/Video_out";

auto presentation = System::MakeObject<Presentation>(templatePath);
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        if (System::ObjectExt::Is<VideoFrame>(shape))
        {
            System::SharedPtr<VideoFrame> vf = System::AsCast<VideoFrame>(shape);
            System::String type = vf->get_EmbeddedVideo()->get_ContentType();
            type = type.Remove(0, type.LastIndexOf('/') + 1);
            auto buffer = vf->get_EmbeddedVideo()->get_BinaryData();

            auto stream = System::MakeObject<System::IO::FileStream>(
                outPath + type, System::IO::FileMode::Create, System::IO::FileAccess::Write,
                System::IO::FileShare::Read);
            stream->Write(buffer, 0, buffer->get_Length());
        }
    }
}
```

## **Συχνές Ερωτήσεις**

**Ποια παραμέτρους αναπαραγωγής βίντεο μπορούν να αλλάξουν για ένα VideoFrame;**

Μπορείτε να ελέγξετε τη [λειτουργία αναπαραγωγής](https://reference.aspose.com/slides/el/cpp/aspose.slides/videoframe/set_playmode/) (αυτόματη ή με κλικ) και την [επανάληψη](https://reference.aspose.com/slides/el/cpp/aspose.slides/videoframe/set_playloopmode/). Αυτές οι επιλογές είναι διαθέσιμες μέσω των ιδιοτήτων του αντικειμένου [VideoFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/videoframe/) .

**Επηρεάζει η προσθήκη βίντεο το μέγεθος του αρχείου PPTX;**

Ναι. Όταν ενσωματώνετε ένα τοπικό βίντεο, τα δυαδικά δεδομένα συμπεριλαμβάνονται στο έγγραφο, έτσι το μέγεθος της παρουσίασης αυξάνεται ανάλογα με το μέγεθος του αρχείου. Όταν προσθέτετε ένα διαδικτυακό βίντεο, ενσωματώνεται ένας σύνδεσμος και μια μικρογραφία, οπότε η αύξηση του μεγέθους είναι μικρότερη.

**Μπορώ να αντικαταστήσω το βίντεο σε ένα υπάρχον VideoFrame χωρίς να αλλάξω τη θέση και το μέγεθός του;**

Ναι. Μπορείτε να ανταλλάξετε το [περιεχόμενο βίντεο](https://reference.aspose.com/slides/el/cpp/aspose.slides/videoframe/set_embeddedvideo/) μέσα στο πλαίσιο διατηρώντας τη γεωμετρία του σχήματος· αυτό είναι συνηθισμένο σενάριο για την ενημέρωση μέσων σε υπάρχουσα διάταξη.

**Μπορεί να προσδιοριστεί ο τύπος περιεχομένου (MIME) ενός ενσωματωμένου βίντεο;**

Ναι. Ένα ενσωματωμένο βίντεο έχει έναν [τύπο περιεχομένου](https://reference.aspose.com/slides/el/cpp/aspose.slides/video/get_contenttype/) που μπορείτε να διαβάσετε και να χρησιμοποιήσετε, για παράδειγμα κατά την αποθήκευσή του στο δίσκο.