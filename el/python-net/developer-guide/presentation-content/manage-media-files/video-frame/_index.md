---
title: Προσθήκη Βίντεο σε Παρουσιάσεις με Python
linktitle: Καρέ Βίντεο
type: docs
weight: 10
url: /el/python-net/video-frame/
keywords:
- προσθήκη βίντεο
- δημιουργία βίντεο
- ενσωμάτωση βίντεο
- εξαγωγή βίντεο
- ανάκτηση βίντεο
- καρέ βίντεο
- πηγή ιστού
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε και να εξάγετε προγραμματιστικά καρέ βίντεο σε διαφάνειες PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Python μέσω .NET. Γρήγορος οδηγός βήμα-προς-βήμα."
---
## **Εισαγωγή**

Ένα καλά τοποθετημένο βίντεο σε μια παρουσίαση μπορεί να κάνει το μήνυμά σας πιο ελκυστικό και να αυξήσει τα επίπεδα αλληλεπίδρασης με το κοινό σας. 

Το PowerPoint σας επιτρέπει να προσθέτετε βίντεο σε μια διαφάνεια σε μια παρουσίαση με δύο τρόπους:

* Προσθέστε ή ενσωματώστε ένα τοπικό βίντεο (αποθηκευμένο στον υπολογιστή σας)
* Προσθέστε ένα βίντεο online (από πηγή ιστού όπως το YouTube).

Για να μπορείτε να προσθέτετε βίντεο (αντικείμενα βίντεο) σε μια παρουσίαση, το Aspose.Slides παρέχει την κλάση [Video](https://reference.aspose.com/slides/el/python-net/aspose.slides/video/) , την κλάση [VideoFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/videoframe/) και άλλους σχετικούς τύπους. 

## **Δημιουργία Ενσωματωμένου Καρέ Βίντεο**

Αν το αρχείο βίντεο που θέλετε να προσθέσετε στη διαφάνειά σας είναι αποθηκευμένο τοπικά, μπορείτε να δημιουργήσετε ένα καρέ βίντεο για να ενσωματώσετε το βίντεο στην παρουσίασή σας. 

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
1. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της. 
1. Προσθέστε ένα αντικείμενο [Video](https://reference.aspose.com/slides/el/python-net/aspose.slides/video/) και περάστε τη διαδρομή του αρχείου βίντεο για να ενσωματώσετε το βίντεο στην παρουσίαση. 
1. Προσθέστε ένα αντικείμενο [VideoFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/videoframe/) για να δημιουργήσετε ένα καρέ για το βίντεο.  
1. Αποθηκεύστε την τροποποιημένη παρουσίαση. 

```python
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
    with open("Wildlife.mp4", "br") as fileStream:
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)

        # Λαμβάνει την πρώτη διαφάνεια και προσθέτει ένα καρέ βίντεο
        pres.slides[0].shapes.add_video_frame(10, 10, 150, 250, video)

        # Αποθηκεύει την παρουσίαση στον δίσκο
        pres.save(path + "pres-with-video.pptx", slides.export.SaveFormat.PPTX)
```

Εναλλακτικά, μπορείτε να προσθέσετε ένα βίντεο περνώντας τη διαδρομή του αρχείου απευθείας στη μέθοδο `add_video_frame(x, y, width, height, fname)`:

``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```


## **Δημιουργία Καρέ Βίντεο με Βίντεο από Πηγή Ιστού**

Το Microsoft [PowerPoint 2013 και νεότερα](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) υποστηρίζει βίντεο YouTube σε παρουσιάσεις. Εάν το βίντεο που θέλετε να χρησιμοποιήσετε είναι διαθέσιμο online (π.χ. στο YouTube), μπορείτε να το προσθέσετε στην παρουσίασή σας μέσω του διαδικτυακού του συνδέσμου. 

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
1. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της. 
1. Προσθέστε ένα αντικείμενο [Video](https://reference.aspose.com/slides/el/python-net/aspose.slides/video/) και περάστε τον σύνδεσμο στο βίντεο.
1. Ορίστε μια μικρογραφία για το καρέ βίντεο. 
1. Αποθηκεύστε την παρουσίαση. 

```python
import aspose.slides as slides
from urllib.request import urlopen

def add_video_from_youyube(pres, videoId):
    # Προσθέτει ένα καρέ βίντεο
    videoFrame = pres.slides[0].shapes.add_video_frame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId)
    videoFrame.play_mode = slides.VideoPlayModePreset.AUTO

    # Φορτώνει μικρογραφία
    thumbnail_uri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg"
    f = urlopen(thumbnail_uri)
    videoFrame.picture_format.picture.image = pres.images.add_image(f.read())


with slides.Presentation() as pres:
    add_video_from_youyube(pres, "s5JbfQZ5Cc0")
    pres.save("AddVideoFrameFromWebSource_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Διαχείριση Υπότιτλων Βίντεο**

Το Aspose.Slides σας επιτρέπει να διαχειρίζεστε κλειστά υπότιτλους για καρέ βίντεο σε παρουσιάσεις PowerPoint. Οι υπότιτλοι αποθηκεύονται σε μορφή WebVTT και εκτίθενται μέσω της ιδιότητας [VideoFrame.caption_tracks](https://reference.aspose.com/slides/el/python-net/aspose.slides/videoframe/caption_tracks/).

**Προσθήκη Υπότιτλων σε Καρέ Βίντεο**

Για να προσθέσετε υπότιτλους σε ένα καρέ βίντεο:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
1. Προσθέστε ένα βίντεο στην παρουσίαση.
1. Προσθέστε ένα αντικείμενο [VideoFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/videoframe/) σε μια διαφάνεια.
1. Χρησιμοποιήστε το [CaptionsCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/captionscollection/) που επιστρέφεται από το [caption_tracks](https://reference.aspose.com/slides/el/python-net/aspose.slides/videoframe/caption_tracks/) για να προσθέσετε ένα κομμάτι υπότιτλου WebVTT.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)

    # Προσθέτει ένα νέο κομμάτι υπότιτλων από αρχείο WebVTT.
    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

Η κλάση [CaptionsCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/captionscollection/) παρέχει επίσης μια υπερφόρτωση που σας επιτρέπει να προσθέσετε υπότιτλους από μια ροή.

**Εξαγωγή Υπότιτλων από Καρέ Βίντεο**

Για να εξαγάγετε υπότιτλους από ένα καρέ βίντεο:

1. Φορτώστε την παρουσίαση που περιέχει το βίντεο.
1. Βρείτε το αντικείμενο [VideoFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/videoframe/) στόχο.
1. Επαναλάβετε τη συλλογή [caption_tracks](https://reference.aspose.com/slides/el/python-net/aspose.slides/videoframe/caption_tracks/) .
1. Αποθηκεύστε κάθε κομμάτι υπότιτλου σε ένα αρχείο `.vtt`.

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            for caption_track in shape.caption_tracks:
                # Αποθηκεύει το κομμάτι υπότιτλων σε αρχείο WebVTT.
                file_path = f"{caption_track.caption_id}.vtt"
                with open(file_path, "wb") as track_stream:
                    track_stream.write(bytes(caption_track.binary_data))
```

Κάθε αντικείμενο [Captions](https://reference.aspose.com/slides/el/python-net/aspose.slides/captions/) εκθέτει το αναγνωριστικό του υπότιτλου, την ετικέτα, τα δυαδικά δεδομένα και το κείμενο του υποτίτλου ως συμβολοσειρά UTF-8.

**Αφαίρεση Υπότιτλων από Καρέ Βίντεο**

Για να αφαιρέσετε υπότιτλους από ένα καρέ βίντεο:

1. Φορτώστε την παρουσίαση που περιέχει το βίντεο.
1. Αποκτήστε το αντικείμενο [VideoFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/videoframe/) στόχο.
1. Αφαιρέστε τα κομμάτια υπότιτλου από το [CaptionsCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/captionscollection/) .
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    video_frame = slide.shapes[0]  # τύπος: slides.VideoFrame

    # Αφαιρεί όλα τα υπότιτλα από το καρέ βίντεο.
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

Εάν χρειάζεται να αφαιρέσετε μόνο ένα κομμάτι υπότιτλου, χρησιμοποιήστε τις μεθόδους [remove](https://reference.aspose.com/slides/el/python-net/aspose.slides/captionscollection/remove/) ή [remove_at](https://reference.aspose.com/slides/el/python-net/aspose.slides/captionscollection/remove_at/) αντί για το [clear](https://reference.aspose.com/slides/el/python-net/aspose.slides/captionscollection/clear/) .

## **Εξαγωγή Βίντεο από Διαφάνεια**

Εκτός από την προσθήκη βίντεο σε διαφάνειες, το Aspose.Slides σας επιτρέπει να εξάγετε βίντεο ενσωματωμένα σε παρουσιάσεις.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) για να φορτώσετε την παρουσίαση που περιέχει το βίντεο. 
2. Επαναλάβετε μέσα από όλα τα αντικείμενα [Slide](https://reference.aspose.com/slides/el/python-net/aspose.slides/slide/) .
3. Επαναλάβετε μέσα από όλα τα αντικείμενα [Shape](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/) για να βρείτε ένα [VideoFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/videoframe/) . 
4. Αποθηκεύστε το βίντεο στον δίσκο.

```python
import aspose.slides as slides

# Δημιουργεί ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
with slides.Presentation(path + "Video.pptx") as presentation:
    for shape in presentation.slides[0].shapes:
        if type(shape) is slides.VideoFrame:
            type = shape.embedded_video.content_type
            buffer = shape.embedded_video.binary_data
            with open("NewVideo_out." + type[type.rfind('/') + 1:len(type)], "wb") as stream:
                stream.write(buffer)
```

## **Συχνές Ερωτήσεις**

**Ποιοι παράμετροι αναπαραγωγής βίντεο μπορούν να αλλάξουν για ένα VideoFrame;**

Μπορείτε να ελέγξετε τη [playback mode](https://reference.aspose.com/slides/el/python-net/aspose.slides/videoframe/play_mode/) (αυτόματη ή με κλικ) και την [looping](https://reference.aspose.com/slides/el/python-net/aspose.slides/videoframe/play_loop_mode/). Αυτές οι επιλογές είναι διαθέσιμες μέσω των ιδιοτήτων του αντικειμένου [VideoFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/videoframe/) .

**Επηρεάζει η προσθήκη ενός βίντεο το μέγεθος του αρχείου PPTX;**

Ναι. Όταν ενσωματώνετε ένα τοπικό βίντεο, τα δυαδικά δεδομένα περιλαμβάνονται στο έγγραφο, έτσι το μέγεθος της παρουσίασης αυξάνεται ανάλογα με το μέγεθος του αρχείου. Όταν προσθέτετε ένα βίντεο online, ενσωματώνεται ένας σύνδεσμος και μια μικρογραφία, οπότε η αύξηση του μεγέθους είναι μικρότερη.

**Μπορώ να αντικαταστήσω το βίντεο σε ένα υπάρχον VideoFrame χωρίς να αλλάξω τη θέση και το μέγεθός του;**

Ναι. Μπορείτε να αντικαταστήσετε το [video content](https://reference.aspose.com/slides/el/python-net/aspose.slides/videoframe/embedded_video/) μέσα στο καρέ διατηρώντας τη γεωμετρία του σχήματος· αυτό είναι μια κοινή κατάσταση για την ενημέρωση πολυμέσων σε υπάρχουσα διάταξη.

**Μπορεί να προσδιοριστεί ο τύπος περιεχομένου (MIME) ενός ενσωματωμένου βίντεο;**

Ναι. Ένα ενσωματωμένο βίντεο διαθέτει έναν [content type](https://reference.aspose.com/slides/el/python-net/aspose.slides/video/content_type/) που μπορείτε να διαβάσετε και να χρησιμοποιήσετε, για παράδειγμα κατά την αποθήκευσή του στον δίσκο.