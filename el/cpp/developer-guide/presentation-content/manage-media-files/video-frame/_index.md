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
- πηγή ιστού
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε και να εξάγετε προγραμματιστικά πλαίσια βίντεο σε διαφάνειες PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για C++. Γρήγορος οδηγός πρακτικών."
---
## **Εισαγωγή**

Τα βίντεο μπορούν να βοηθήσουν στην εξήγηση ιδεών και στην εμπλοκή του κοινού. Το Aspose.Slides για C++ σάς επιτρέπει να προσθέτετε πλαίσια βίντεο στις διαφάνειες, να ρυθμίζετε τις ρυθμίσεις αναπαραγωγής, να διαχειρίζεστε υπότιτλους και να εξάγετε ενσωματωμένα δεδομένα βίντεο.

Το PowerPoint υποστηρίζει τοπικά βίντεο και συνδέσμους σε βίντεο στο διαδίκτυο, όπως βίντεο YouTube.

Για την αναπαράσταση δεδομένων βίντεο και πλαισίων βίντεο, το Aspose.Slides παρέχει τη διεπαφή [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) , τη διεπαφή [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) και άλλους σχετικούς τύπους.

## **Δημιουργία Ενσωματωμένου Πλαισίου Βίντεο**

Αν το αρχείο βίντεο που θέλετε να προσθέσετε στη διαφάνειά σας είναι αποθηκευμένο τοπικά, μπορείτε να δημιουργήσετε ένα πλαίσιο βίντεο για να ενσωματώσετε το βίντεο στην παρουσίασή σας.

Αυτό το παράδειγμα ενσωματώνει ένα τοπικό βίντεο στην πρώτη διαφάνεια μιας υπάρχουσας παρουσίασης και αποθηκεύει το αποτέλεσμα. Οι συντεταγμένες και οι διαστάσεις του πλαισίου είναι σε μονάδες point. Η ροή παραμένει ανοιχτή μέχρι να ολοκληρωθεί η αποθήκευση επειδή το [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/cpp/aspose.slides/loadingstreambehavior/) το διατηρεί κλειδωμένο ενώ η παρουσίαση το χρησιμοποιεί.

```cpp
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoCollection.h>
#include <Export/SaveFormat.h>
#include <LoadingStreamBehavior.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);

auto videoStream = File::OpenRead(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoStream, LoadingStreamBehavior::KeepLocked);
slide->get_Shapes()->AddVideoFrame(10, 10, 150, 250, video);

presentation->Save(u"embedded_video.pptx", SaveFormat::Pptx);

presentation->Dispose();
videoStream->Dispose();
```

Μπορείτε επίσης να περάσετε μια διαδρομή τοπικού βίντεο απευθείας στη μέθοδο [AddVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addvideoframe/). Αυτό το παράδειγμα ενσωματώνει το βίντεο στην πρώτη διαφάνεια μιας νέας παρουσίασης. Το βίντεο πρέπει να παραμένει προσβάσιμο μέχρι να αποθηκευτεί η παρουσίαση.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

slide->get_Shapes()->AddVideoFrame(50, 150, 300, 150, u"video.avi");

presentation->Save(u"video_from_path.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Δημιουργία Πλαισίου Βίντεο με Βίντεο από Πηγή στο Διαδίκτυο**

Το Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) υποστηρίζει βίντεο στο διαδίκτυο στις παρουσιάσεις. Μπορείτε να δημιουργήσετε ένα πλαίσιο βίντεο που συνδέεται με ένα βίντεο στο διαδίκτυο, όπως ένα βίντεο YouTube.

Αυτό το παράδειγμα προσθέτει έναν σύνδεσμο βίντεο YouTube και μια μικρογραφία στην πρώτη διαφάνεια. Αντικαταστήστε το αναγνωριστικό του βίντεο για να χρησιμοποιήσετε άλλο βίντεο. Η μέθοδος [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_playmode/) ζητά αυτόματη αναπαραγωγή. Η λήψη της μικρογραφίας και η αναπαραγωγή του βίντεο απαιτούν πρόσβαση στο διαδίκτυο. Ο προβολέας της παρουσίασης πρέπει επίσης να υποστηρίζει την αναπαραγωγή βίντεο στο διαδίκτυο.

```cpp
#include <net/web_client.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <DOM/VideoPlayModePreset.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);


auto webClient = MakeObject<System::Net::WebClient>();

String videoId = u"aqz-KE-bpKQ";
auto videoUrl = String::Format(u"https://www.youtube.com/embed/{0}", videoId);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240, videoUrl);
videoFrame->set_PlayMode(VideoPlayModePreset::Auto);

auto thumbnailUrl = String::Format(u"https://img.youtube.com/vi/{0}/hqdefault.jpg", videoId);
auto thumbnailData = webClient->DownloadData(thumbnailUrl);
auto thumbnail = presentation->get_Images()->AddImage(thumbnailData);
videoFrame->get_PictureFormat()->get_Picture()->set_Image(thumbnail);

presentation->Save(u"online_video.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Αναπαραγωγή Βίντεο σε Λειτουργία Πλήρους Οθόνης**

Σε μια παρουσίαση εκπαίδευσης, μπορείτε να προβάλετε μια επίδειξη λογισμικού σε λειτουργία πλήρους οθόνης ώστε το κοινό να βλέπει τις λεπτομέρειες. Η [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/) δέχεται `true` για να ενεργοποιήσει αυτήν τη συμπεριφορά κατά την αναπαραγωγή.

Αυτό το παράδειγμα ανοίγει μια παρουσίαση, βρίσκει το πρώτο [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) στην πρώτη διαφάνεια και ενεργοποιεί την αναπαραγωγή σε πλήρη οθόνη. Η παρουσίαση εισόδου πρέπει να περιέχει τουλάχιστον μία διαφάνεια με υπάρχον πλαίσιο βίντεο στην πρώτη διαφάνεια.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"training.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        videoFrame->set_FullScreenMode(true);
        break;
    }
}

presentation->Save(u"full_screen_video.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Η αναπαραγωγή σε πλήρη οθόνη ελέγχει πώς εμφανίζεται το βίντεο. Ξεχωριστά, η [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) ελέγχει αν ξεκινά αυτόματα ή με κλικ, και η [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) ελέγχει αν επαναλαμβάνεται. Για να επιλέξετε τη συμπεριφορά εκκίνησης, ορίστε τη λειτουργία αναπαραγωγής σε [VideoPlayModePreset::Auto or VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/). Το παράδειγμα διατηρεί τις υπάρχουσες ρυθμίσεις εκκίνησης και επανάληψης.

## **Επιστροφή του Βίντεο στην Αρχή μετά την Αναπαραγωγή**

Σε μια παρουσίαση εκπαίδευσης, η επιστροφή ενός βίντεο επίδειξης στην αρχή το καθιστά έτοιμο για τον παρουσιαστή να το ξαναπροβάλλει. Καλέστε τη [set_RewindVideo](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_rewindvideo/) με `true` για να επιστρέψετε το βίντεο στην αρχή μετά το τέλος της αναπαραγωγής.

Αυτό το παράδειγμα ανοίγει μια παρουσίαση, βρίσκει το πρώτο [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) στην πρώτη διαφάνεια και ενεργοποιεί την επιστροφή. Απενεργοποιεί την επανάληψη ώστε η αναπαραγωγή να μπορεί να ολοκληρωθεί και ορίζει την εκκίνηση στην αναπαραγωγή με κλικ. Η παρουσίαση εισόδου πρέπει να περιέχει τουλάχιστον μία διαφάνεια με υπάρχον πλαίσιο βίντεο στην πρώτη διαφάνεια.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <DOM/VideoPlayModePreset.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"training.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        videoFrame->set_RewindVideo(true);
        videoFrame->set_PlayLoopMode(false);
        videoFrame->set_PlayMode(VideoPlayModePreset::OnClick);
        break;
    }
}

presentation->Save(u"rewind_video.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Η επιστροφή επαναφέρει το βίντεο στην αρχή χωρίς να το ξεκινήσει ξανά. Αντίθετα, η ενεργοποίηση της [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) επαναλαμβάνει την αναπαραγωγή αυτόματα. Διατηρήστε την επανάληψη απενεργοποιημένη όταν θέλετε το βίντεο να ολοκληρωθεί και να παραμείνει έτοιμο για επανάληψη. Η [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) ελέγχει αυτόνομα την αυτόματη ή με κλικ εκκίνηση· αυτό το παράδειγμα χρησιμοποιεί το [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/) έτσι ώστε ο παρουσιαστής να ελέγχει πότε ξεκινά η αναπαραγωγή. Ορίστε τη λειτουργία αναπαραγωγής μετά τη ρύθμιση επανάληψης, όπως φαίνεται στο παράδειγμα. Η επιστροφή λειτουργεί αυτόνομα από τη [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/).

## **Περικοπή Πλαισίου Βίντεο**

Χρησιμοποιήστε τις [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromstart/) και [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromend/) για να παραλείψετε μέρος της αρχής ή του τέλους ενός βίντεο κατά την αναπαραγωγή. Και οι δύο τιμές είναι σε χιλιοστά του δευτερολέπτου. Η περικοπή αλλάζει τις ρυθμίσεις αναπαραγωγής χωρίς να τροποποιεί τα ενσωματωμένα δεδομένα βίντεο.

**Ορισμός Ρυθμίσεων Περικοπής**

Αυτό το παράδειγμα ενσωματώνει ένα τοπικό βίντεο και παραλείπει τα πρώτα 2,5 δευτερόλεπτα και το τελευταίο δευτερόλεπτο κατά την αναπαραγωγή. Χρησιμοποιήστε ένα βίντεο μεγαλύτερο από 3,5 δευτερόλεπτα ώστε να παραμείνει ένα αναγνώσιμο τμήμα.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 640, 360, video);
videoFrame->set_TrimFromStart(2500.0f);
videoFrame->set_TrimFromEnd(1000.0f);

presentation->Save(u"video_with_trim.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

**Ανάγνωση Ρυθμίσεων Περικοπής**

Αυτό το παράδειγμα εμφανίζει τις τιμές περικοπής του πρώτου πλαισίου βίντεο στην πρώτη διαφάνεια σε χιλιοστά του δευτερολέπτου. Η παρουσίαση πρέπει να περιέχει τουλάχιστον μία διαφάνεια. Αν αυτή η διαφάνεια δεν έχει πλαίσιο βίντεο, δεν εμφανίζεται κανένα αποτέλεσμα. Το προηγούμενο παράδειγμα παράγει τιμές 2500 και 1000.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"video_with_trim.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        Console::WriteLine(String::Format(u"Trim from start: {0} ms", videoFrame->get_TrimFromStart()));
        Console::WriteLine(String::Format(u"Trim from end: {0} ms", videoFrame->get_TrimFromEnd()));
        break;
    }
}

presentation->Dispose();
```

## **Διαχείριση Υπότιτλων Βίντεο**

Το Aspose.Slides σας επιτρέπει να διαχειρίζεστε κλειστά υπότιτλους για πλαίσια βίντεο σε παρουσιάσεις PowerPoint. Οι υπότιτλοι αποθηκεύονται σε μορφή WebVTT και εκτίθενται μέσω της μεθόδου [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/get_captiontracks/).

**Πρόσθεση Υπότιτλων σε Πλαίσιο Βίντεο**

Αυτό το παράδειγμα ενσωματώνει ένα τοπικό βίντεο και προσθέτει ένα WebVTT track υπότιτλων με ετικέτα English. Τα χρονικά σημεία των υποτίτλων πρέπει να ταιριάζουν με το βίντεο. Η αποθηκευμένη παρουσίαση περιλαμβάνει τόσο το βίντεο όσο και τους υπότιτλούς του.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <DOM/ICaptionsCollection.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto videoFrame = slide->get_Shapes()->AddVideoFrame(0, 0, 100, 100, video);
videoFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"video_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Η διεπαφή [ICaptionsCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/) παρέχει επίσης μια υπερφόρτωση που σας επιτρέπει να προσθέσετε υπότιτλους από μια ροή.

**Εξαγωγή Υπότιτλων από Πλαίσιο Βίντεο**

Αυτό το παράδειγμα αποθηκεύει όλα τα tracks υποτίτλων από τα πλαίσια βίντεο στην πρώτη διαφάνεια ως ξεχωριστά αρχεία WebVTT. Οι διαδοχικοί αριθμοί κρατούν τα αρχεία εξόδου διαφορετικά. Η κονσόλα αναφέρει τον αριθμό των εξαγόμενων tracks. Η παρουσίαση πρέπει να περιέχει τουλάχιστον μία διαφάνεια.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <system/io/file.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/ICaptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);

auto trackCount = 0;
for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        for (auto&& captionTrack : IterateOver(videoFrame->get_CaptionTracks()))
        {
            trackCount++;
            auto outputPath = String::Format(u"captions_{0}.vtt", trackCount);
            File::WriteAllBytes(outputPath, captionTrack->get_BinaryData());
        }
    }
}

Console::WriteLine(String::Format(u"Caption tracks extracted: {0}", trackCount));

presentation->Dispose();
```

Κάθε αντικείμενο [ICaptions](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/) εκθέτει το αναγνωριστικό του υπότιτλου, την ετικέτα, τα δυαδικά δεδομένα και το κείμενο του υπότιτλου ως συμβολοσειρά UTF-8.

**Κατάργηση Υπότιτλων από Πλαίσιο Βίντεο**

Αυτό το παράδειγμα καταργεί όλους τους υπότιτλους από το πλαίσιο βίντεο στην πρώτη θέση σχήματος της πρώτης διαφάνειας και αποθηκεύει το αποτέλεσμα. Υποθέτει ότι η διαφάνεια και το σχήμα υπάρχουν και ότι το σχήμα είναι ένα πλαίσιο βίντεο.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <DOM/ICaptionsCollection.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);

auto videoFrame = ExplicitCast<IVideoFrame>(slide->get_Shape(0));
videoFrame->get_CaptionTracks()->Clear();

presentation->Save(u"video_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Εάν χρειάζεται να αφαιρέσετε μόνο ένα track υπότιτλου, χρησιμοποιήστε τις μεθόδους [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/remove/) ή [RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/removeat/) αντί για τη [Clear](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/clear/).

## **Εξαγωγή Βίντεο από Διαφάνεια**

Εκτός από την προσθήκη βίντεο σε διαφάνειες, το Aspose.Slides σας επιτρέπει να εξάγετε βίντεο ενσωματωμένα σε παρουσιάσεις.

Αυτό το παράδειγμα εξάγει ενσωματωμένα βίντεο από κάθε διαφάνεια σε ξεχωριστά αριθμημένα δυαδικά αρχεία. Τα συνδεδεμένα βίντεο παραλείπονται επειδή δεν έχουν ενσωματωμένα δεδομένα. Η κονσόλα εμφανίζει τον τύπο MIME κάθε βίντεο και τον συνολικό αριθμό. Η έξοδος χρησιμοποιεί την γενική επέκταση `.bin`; αλλάξτε την ώστε να ταιριάζει με τον αναφερόμενο τύπο μέσου όταν χρειάζεται.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IVideo.h>
#include <system/io/file.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation_with_videos.pptx");

auto videoCount = 0;
for (auto&& slide : IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IVideoFrame>(shape))
        {
            auto videoFrame = ExplicitCast<IVideoFrame>(shape);
            auto video = videoFrame->get_EmbeddedVideo();
            if (video == nullptr)
            {
                Console::WriteLine(u"Skipped a linked video: no embedded data is available.");
                continue;
            }

            videoCount++;
            auto outputPath = String::Format(u"extracted_video_{0}.bin", videoCount);
            File::WriteAllBytes(outputPath, video->get_BinaryData());
            Console::WriteLine(String::Format(u"Video {0}: {1}", videoCount, video->get_ContentType()));
        }
    }
}

Console::WriteLine(String::Format(u"Embedded videos extracted: {0}", videoCount));

presentation->Dispose();
```

## **Συχνές Ερωτήσεις**

**Ποια παραμέτρα αναπαραγωγής βίντεο μπορούν να αλλάξουν για ένα πλαίσιο βίντεο;**

Μπορείτε να ελέγξετε τη [λειτουργία αναπαραγωγής](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) (αυτόματη ή με κλικ) και την [επανάληψη](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/). Αυτές οι επιλογές είναι διαθέσιμες μέσω των μεθόδων του αντικειμένου [VideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/).

**Επηρεάζει η προσθήκη βίντεο το μέγεθος του αρχείου PPTX;**

Ναι. Όταν ενσωματώνετε ένα τοπικό βίντεο, τα δυαδικά δεδομένα περιλαμβάνονται στο έγγραφο, οπότε το μέγεθος της παρουσίασης αυξάνεται ανάλογα με το μέγεθος του αρχείου. Όταν συνδέεστε με ένα βίντεο στο διαδίκτυο και προσθέτετε μια μικρογραφία, η παρουσίαση αποθηκεύει τον σύνδεσμο και την εικόνα προεπισκόπησης αντί για τα δεδομένα του βίντεο, επομένως η αύξηση του μεγέθους είναι συνήθως μικρότερη.

**Μπορώ να αντικαταστήσω το βίντεο σε υπάρχον πλαίσιο βίντεο χωρίς να αλλάξω τη θέση και το μέγεθός του;**

Ναι. Μπορείτε να ανταλλάξετε το [video content](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_embeddedvideo/) εντός του πλαισίου διατηρώντας τη γεωμετρία του σχήματος· αυτό είναι ένα κοινό σενάριο για την ενημέρωση μέσων σε υπάρχουσα διάταξη.

**Μπορεί να προσδιοριστεί ο τύπος περιεχομένου (MIME) ενός ενσωματωμένου βίντεο;**

Ναι. Ένα ενσωματωμένο βίντεο έχει έναν [content type](https://reference.aspose.com/slides/cpp/aspose.slides/video/get_contenttype/) που μπορείτε να διαβάσετε και να χρησιμοποιήσετε, για παράδειγμα όταν το αποθηκεύετε στο δίσκο.