---
title: Διαχείριση πλαισίων βίντεο σε παρουσιάσεις χρησιμοποιώντας C++
linktitle: Πλαίσιο βίντεο
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
- πηγή web
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε και να εξάγετε προγραμματιστικά πλαίσια βίντεο σε διαφάνειες PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για C++. Γρήγορος οδηγός βήμα προς βήμα."
---
## **Εισαγωγή**

Ένα καλά τοποθετημένο βίντεο σε μια παρουσίαση μπορεί να κάνει το μήνυμά σας πιο ελκυστικό και να αυξήσει τα επίπεδα δέσμευσης με το κοινό σας. 

Το PowerPoint σας επιτρέπει να προσθέτετε βίντεο σε μια διαφάνεια σε μια παρουσίαση με δύο τρόπους:

* Προσθέστε ή ενσωματώστε ένα τοπικό βίντεο (αποθηκευμένο στον υπολογιστή σας)
* Προσθέστε ένα διαδικτυακό βίντεο (από πηγή web όπως το YouTube).

Για να μπορείτε να προσθέτετε βίντεο (αντικείμενα βίντεο) σε μια παρουσίαση, το Aspose.Slides παρέχει τη διεπαφή [IVideo](https://reference.aspose.com/slides/el/cpp/aspose.slides/ivideo/) , τη διεπαφή [IVideoFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ivideoframe/) και άλλους σχετικούς τύπους. 

## **Δημιουργία Ενσωματωμένου Πλαισίου Βίντεο**

Αν το αρχείο βίντεο που θέλετε να προσθέσετε στη διαφάνειά σας είναι αποθηκευμένο τοπικά, μπορείτε να δημιουργήσετε ένα πλαίσιο βίντεο για να ενσωματώσετε το βίντεο στην παρουσίασή σας. 

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια μέσω του δείκτη της. 
1. Προσθέστε ένα αντικείμενο [IVideo](https://reference.aspose.com/slides/el/cpp/aspose.slides/ivideo/) και περάστε τη διαδρομή του αρχείου βίντεο για να ενσωματώσετε το βίντεο στην παρουσίαση. 
1. Προσθέστε ένα αντικείμενο [IVideoFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ivideoframe/) για να δημιουργήσετε ένα πλαίσιο για το βίντεο.  
1. Αποθηκεύστε την τροποποιημένη παρουσίαση. 

Αυτός ο κώδικας C++ δείχνει πώς να προσθέσετε ένα βίντεο αποθηκευμένο τοπικά σε μια παρουσίαση:

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

Εναλλακτικά, μπορείτε να προσθέσετε ένα βίντεο περνόντας τη διαδρομή του αρχείου απευθείας στη μέθοδο [AddVideoFrame()](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishapecollection/addvideoframe/):

``` c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slide(0);
System::SharedPtr<IVideoFrame> vf = sld->get_Shapes()->AddVideoFrame(50.0f, 150.0f, 300.0f, 150.0f, u"video1.avi");
```

## **Δημιουργία Πλαισίου Βίντεο με Βίντεο από Πηγή Web**

Νεότερες εκδόσεις του Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) υποστηρίζουν διαδικτυακά βίντεο στις παρουσιάσεις. Εάν το βίντεο που θέλετε να χρησιμοποιήσετε είναι διαθέσιμο διαδικτυακά (π.χ. στο YouTube), μπορείτε να το προσθέσετε στην παρουσίασή σας μέσω του συνδέσμου web.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια μέσω του δείκτη της. 
1. Προσθέστε ένα αντικείμενο [IVideo](https://reference.aspose.com/slides/el/cpp/aspose.slides/ivideo/) και περάστε τον σύνδεσμο στο βίντεο.
1. Ορίστε μια μικρογραφία για το πλαίσιο βίντεο. 
1. Αποθηκεύστε την παρουσίαση. 

Αυτός ο κώδικας C++ δείχνει πώς να προσθέσετε ένα βίντεο από το web σε μια διαφάνεια σε μια παρουσίαση PowerPoint:

```c++
// Η διαδρομή του καταλόγου εγγράφων.
const String outPath = u"../out/AddVideoFrameFromWebSource_out.pptx";
const String filePath = u"../templates/video1.avi";

// Δημιουργεί ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Πρόσβαση στην πρώτη διαφάνεια
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Προσθέτει πλαίσιο βίντεο 
System::SharedPtr<IVideoFrame> vf = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240,u"https://www.youtube.com/embed/Tj75Arhq5ho");

// Ορίζει τη λειτουργία αναπαραγωγής και την ένταση του βίντεο
vf->set_PlayMode(VideoPlayModePreset::Auto);

//Αποθηκεύει την παρουσίαση στο δίσκο
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Περικοπή Πλαισίου Βίντεο**

Το Aspose.Slides σας επιτρέπει να ελέγχετε ποιο τμήμα ενός βίντεο θα αναπαράγεται ορίζοντας τις τιμές trim-from-start και trim-from-end μέσω των μεθόδων [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/el/cpp/aspose.slides/ivideoframe/set_trimfromstart/) και [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/el/cpp/aspose.slides/ivideoframe/set_trimfromend/). Και οι δύο τιμές καθορίζονται σε χιλιοστά του δευτερολέπτου και ορίζουν πόσο χρόνο παραλείπεται από την αρχή και το τέλος του βίντεο, αντίστοιχα. Αυτές οι ρυθμίσεις αλλάζουν τις ρυθμίσεις αναπαραγωγής βίντεο στην παρουσίαση· δεν κόβουν ή τροποποιούν τα ενσωματωμένα δυαδικά δεδομένα του βίντεο.

**Ορισμός Ρυθμίσεων Περικοπής**

Για να δημιουργήσετε ένα πλαίσιο βίντεο και να ορίσετε τις ρυθμίσεις περικοπής του:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
1. Προσθέστε ένα αντικείμενο [IVideo](https://reference.aspose.com/slides/el/cpp/aspose.slides/ivideo/) στην παρουσίαση.
1. Προσθέστε ένα αντικείμενο [IVideoFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ivideoframe/) σε μια διαφάνεια.
1. Ορίστε τις τιμές trim-from-start και trim-from-end μέσω των [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/el/cpp/aspose.slides/ivideoframe/set_trimfromstart/) και [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/el/cpp/aspose.slides/ivideoframe/set_trimfromend/).
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα κώδικα παραλείπει τα πρώτα 2,5 δευτερόλεπτα και το τελευταίο δευτερόλεπτο ενός ενσωματωμένου βίντεο κατά την αναπαραγωγή:

```cpp
auto presentation = MakeObject<Presentation>();

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto slide = presentation->get_Slide(0);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 640, 360, video);

videoFrame->set_TrimFromStart(2500.0f);
videoFrame->set_TrimFromEnd(1000.0f);

presentation->Save(u"video_with_trim.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

**Ανάγνωση Ρυθμίσεων Περικοπής**

Για να εξετάσετε τις υπάρχουσες ρυθμίσεις περικοπής, φορτώστε μια παρουσίαση, βρείτε ένα αντικείμενο [IVideoFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ivideoframe/) μεταξύ των σχημάτων στην πρώτη διαφάνεια και διαβάστε τις τιμές μέσω των [IVideoFrame::get_TrimFromStart](https://reference.aspose.com/slides/el/cpp/aspose.slides/ivideoframe/get_trimfromstart/) και [IVideoFrame::get_TrimFromEnd](https://reference.aspose.com/slides/el/cpp/aspose.slides/ivideoframe/get_trimfromend/).

Το παρακάτω παράδειγμα κώδικα βρίσκει το πρώτο πλαίσιο βίντεο στην πρώτη διαφάνεια και αναφέρει τις ρυθμίσεις περικοπής του σε χιλιοστά του δευτερολέπτου:

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_trim.pptx");

auto slide = presentation->get_Slide(0);
for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        auto trimFromStart = videoFrame->get_TrimFromStart();
        auto trimFromEnd = videoFrame->get_TrimFromEnd();

        Console::WriteLine(u"Trim from start: {0} ms", trimFromStart);
        Console::WriteLine(u"Trim from end: {0} ms", trimFromEnd);

        break;
    }
}

presentation->Dispose();
```

## **Διαχείριση Υπότιτλων Βίντεο**

Το Aspose.Slides σας επιτρέπει να διαχειρίζεστε υπότιτλους κλειστού τύπου για πλαίσια βίντεο σε παρουσιάσεις PowerPoint. Οι υπότιτλοι αποθηκεύονται σε μορφή WebVTT και παρέχονται μέσω της μεθόδου [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/el/cpp/aspose.slides/ivideoframe/get_captiontracks/).

**Προσθήκη Υπότιτλων σε Πλαίσιο Βίντεο**

Για να προσθέσετε υπότιτλους σε ένα πλαίσιο βίντεο:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
1. Προσθέστε ένα βίντεο στην παρουσίαση.
1. Προσθέστε ένα αντικείμενο [IVideoFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ivideoframe/) σε μια διαφάνεια.
1. Χρησιμοποιήστε τη [ICaptionsCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/icaptionscollection/) που επιστρέφεται από το [get_CaptionTracks](https://reference.aspose.com/slides/el/cpp/aspose.slides/ivideoframe/get_captiontracks/) για να προσθέσετε ένα κομμάτι υποτίτλου WebVTT.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Ο παρακάτω κώδικας δείχνει πώς να προσθέσετε υπότιτλους σε ένα πλαίσιο βίντεο:

```cpp
auto presentation = MakeObject<Presentation>();

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto slide = presentation->get_Slide(0);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(0, 0, 100, 100, video);

// Προσθέτει ένα νέο κομμάτι υποτίτλων από αρχείο WebVTT.
videoFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"video_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Η διεπαφή [ICaptionsCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/icaptionscollection/) παρέχει επίσης μια υπερφόρτωση που σας επιτρέπει να προσθέσετε υποτίτλους από μια ροή.

**Εξαγωγή Υπότιτλων από Πλαίσιο Βίντεο**

Για να εξαγάγετε υπότιτλους από ένα πλαίσιο βίντεο:

1. Φορτώστε την παρουσίαση που περιέχει το βίντεο.
1. Βρείτε το αντικείμενο [IVideoFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ivideoframe/) στόχο.
1. Περάστε διαδοχικά τα κομμάτια υποτίτλων που επιστρέφονται από το [get_CaptionTracks](https://reference.aspose.com/slides/el/cpp/aspose.slides/ivideoframe/get_captiontracks/).
1. Αποθηκεύστε κάθε κομμάτι υποτίτλου σε ένα αρχείο `.vtt`.

Ο παρακάτω κώδικας δείχνει πώς να εξαγάγετε υπότιτλους από ένα πλαίσιο βίντεο:

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

Για να αφαιρέσετε υπότιτλους από ένα πλαίσιο βίντεο:

1. Φορτώστε την παρουσίαση που περιέχει το βίντεο.
1. Αποκτήστε το αντικείμενο [IVideoFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ivideoframe/) στόχο.
1. Αφαιρέστε τα κομμάτια υποτίτλων από τη συλλογή που επιστρέφεται από το [get_CaptionTracks](https://reference.aspose.com/slides/el/cpp/aspose.slides/ivideoframe/get_captiontracks/).
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Ο παρακάτω κώδικας δείχνει πώς να αφαιρέσετε όλους τους υπότιτλους από ένα πλαίσιο βίντεο:

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto videoFrame = ExplicitCast<IVideoFrame>(slide->get_Shape(0));

// Αφαιρεί όλους τους υπότιτλους από το πλαίσιο βίντεο.
videoFrame->get_CaptionTracks()->Clear();

presentation->Save(u"video_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Αν χρειάζεται να αφαιρέσετε μόνο ένα κομμάτι υποτίτλου, χρησιμοποιήστε τις μεθόδους [Remove](https://reference.aspose.com/slides/el/cpp/aspose.slides/icaptionscollection/remove/) ή [RemoveAt](https://reference.aspose.com/slides/el/cpp/aspose.slides/icaptionscollection/removeat/) αντί για τη [Clear](https://reference.aspose.com/slides/el/cpp/aspose.slides/icaptionscollection/clear/).

## **Εξαγωγή Βίντεο από Διαφάνεια**

Εκτός από την προσθήκη βίντεο σε διαφάνειες, το Aspose.Slides σας επιτρέπει να εξάγετε βίντεο ενσωματωμένα σε παρουσιάσεις.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) για να φορτώσετε την παρουσίαση που περιέχει το βίντεο. 
2. Διασχίστε όλα τα αντικείμενα [ISlide](https://reference.aspose.com/slides/el/cpp/aspose.slides/islide/).
3. Διασχίστε όλα τα αντικείμενα [IShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/) για να βρείτε ένα [VideoFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/videoframe/). 
4. Αποθηκεύστε το βίντεο στο δίσκο.

Αυτός ο κώδικας C++ δείχνει πώς να εξάγετε το βίντεο από μια διαφάνεια παρουσίασης:

```c++
// Η διαδρομή του καταλόγου εγγράφων.
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

**Ποια παραμέτρα αναπαραγωγής βίντεο μπορούν να αλλάξουν για ένα VideoFrame;**

Μπορείτε να ελέγχετε το [playback mode](https://reference.aspose.com/slides/el/cpp/aspose.slides/videoframe/set_playmode/) (αυτόματο ή με κλικ) και την [looping](https://reference.aspose.com/slides/el/cpp/aspose.slides/videoframe/set_playloopmode/). Αυτές οι επιλογές διατίθενται μέσω των ιδιοτήτων του αντικειμένου [VideoFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/videoframe/).

**Επηρεάζει η προσθήκη βίντεο το μέγεθος του αρχείου PPTX;**

Ναι. Όταν ενσωματώνετε ένα τοπικό βίντεο, τα δυαδικά δεδομένα περιλαμβάνονται στο έγγραφο, έτσι το μέγεθος της παρουσίασης αυξάνεται ανάλογα με το μέγεθος του αρχείου. Όταν προσθέτετε ένα διαδικτυακό βίντεο, ενσωματώνεται ένας σύνδεσμος και μια μικρογραφία, επομένως η αύξηση του μεγέθους είναι μικρότερη.

**Μπορώ να αντικαταστήσω το βίντεο σε ένα υπάρχον VideoFrame χωρίς να αλλάξω τη θέση και το μέγεθός του;**

Ναι. Μπορείτε να ανταλλάξετε το [video content](https://reference.aspose.com/slides/el/cpp/aspose.slides/videoframe/set_embeddedvideo/) μέσα στο πλαίσιο διατηρώντας τη γεωμετρία του σχήματος· αυτό είναι ένα σύνηθες σενάριο για ενημέρωση μέσων σε υπάρχουσα διάταξη.

**Μπορεί να προσδιοριστεί ο τύπος περιεχομένου (MIME) ενός ενσωματωμένου βίντεο;**

Ναι. Ένα ενσωματωμένο βίντεο διαθέτει έναν [content type](https://reference.aspose.com/slides/el/cpp/aspose.slides/video/get_contenttype/) που μπορείτε να διαβάσετε και να χρησιμοποιήσετε, για παράδειγμα κατά την αποθήκευση του στο δίσκο.