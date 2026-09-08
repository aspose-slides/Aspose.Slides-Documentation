---
title: Διαχείριση Πλαισίων Βίντεο σε Παρουσιάσεις Χρησιμοποιώντας Python
linktitle: Πλαίσιο Βίντεο
type: docs
weight: 10
url: /el/python-java/video-frame/
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
- Python
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε και να εξάγετε προγραμματιστικά πλαίσια βίντεο σε διαφάνειες PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Python μέσω Java. Γρήγορος οδηγός βήμα-βήμα."
---
## **Εισαγωγή**

Ένα καλά τοποθετημένο βίντεο σε μια παρουσίαση μπορεί να κάνει το μήνυμά σας πιο ελκυστικό και να αυξήσει τα επίπεδα αλληλεπίδρασης με το κοινό σας.

Το PowerPoint σας επιτρέπει να προσθέσετε βίντεο σε μια διαφάνεια μιας παρουσίασης με δύο τρόπους:

* Προσθέστε ή ενσωματώστε ένα τοπικό βίντεο (αποθηκευμένο στον υπολογιστή σας)
* Προσθέστε ένα διαδικτυακό βίντεο (από πηγή ιστού όπως το YouTube).

Για να μπορείτε να προσθέσετε βίντεο (αντικείμενα βίντεο) σε μια παρουσίαση, το Aspose.Slides παρέχει τις κλάσεις [Video](https://reference.aspose.com/slides/el/python-java/aspose.slides/video/) , [VideoFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/videoframe/) και άλλους σχετικούς τύπους.

## **Δημιουργία Ενσωματωμένων Πλαισίων Βίντεο**

Αν το αρχείο βίντεο που θέλετε να προσθέσετε στη διαφάνεια σας είναι αποθηκευμένο τοπικά, μπορείτε να δημιουργήσετε ένα πλαίσιο βίντεο για να ενσωματώσετε το βίντεο στην παρουσίασή σας.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια μέσω του δείκτη της.
1. Προσθέστε ένα αντικείμενο [Video](https://reference.aspose.com/slides/el/python-java/aspose.slides/video/) και περάστε τα δεδομένα του αρχείου βίντεο για να ενσωματώσετε το βίντεο στην παρουσίαση.
1. Προσθέστε ένα αντικείμενο [VideoFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/videoframe/) για να δημιουργήσετε ένα πλαίσιο για το βίντεο.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας Python σας δείχνει πώς να προσθέσετε ένα βίντεο που είναι αποθηκευμένο τοπικά σε μια παρουσίαση:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    video_data = Path("Wildlife.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video)
    presentation.save("pres-with-video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Εναλλακτικά, μπορείτε να προσθέσετε ένα βίντεο περνώντας το μονοπάτι του αρχείου κατευθείαν στη μέθοδο [addVideoFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/#addVideoFrame):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi")
finally:
    presentation.dispose()
```

## **Δημιουργία Πλαισίων Βίντεο με Βίντεο από Πηγές Ιστού**

Το Microsoft [PowerPoint 2013 και νεότερο](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) υποστηρίζει βίντεο YouTube σε παρουσιάσεις. Εάν το βίντεο που θέλετε να χρησιμοποιήσετε είναι διαθέσιμο διαδικτυακά (π.χ. στο YouTube), μπορείτε να το προσθέσετε στην παρουσίασή σας μέσω του διαδικτυακού του συνδέσμου.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια μέσω του δείκτη της.
1. Προσθέστε ένα αντικείμενο [VideoFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/videoframe/) και περάστε το σύνδεσμο στο βίντεο.
1. Ορίστε μια μικρογραφία για το πλαίσιο βίντεο.
1. Αποθηκεύστε την παρουσίαση.

Αυτός ο κώδικας Python σας δείχνει πώς να προσθέσετε ένα βίντεο από το διαδίκτυο σε μια διαφάνεια σε μια παρουσίαση PowerPoint:

```python
from urllib.request import urlopen

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoPlayModePreset

video_id = "Tj75Arhq5ho"
presentation = Presentation()
try:
    video_frame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + video_id)
    video_frame.setPlayMode(VideoPlayModePreset.Auto)

    # Φόρτωση της μικρογραφίας.
    thumbnail_uri = "https://img.youtube.com/vi/" + video_id + "/hqdefault.jpg"
    try:
        with urlopen(thumbnail_uri) as response:
            thumbnail_data = response.read()
        java_thumbnail_data = jpype.JArray(jpype.JByte)(thumbnail_data)
        thumbnail = presentation.getImages().addImage(java_thumbnail_data)
        video_frame.getPictureFormat().getPicture().setImage(thumbnail)
    except OSError as error:
        print("Could not load the thumbnail:", error)

    presentation.save("out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Περικοπή Πλαισίου Βίντεο**

Το Aspose.Slides σας επιτρέπει να ελέγξετε ποιο τμήμα ενός βίντεο θα αναπαραχθεί ορίζοντας τις τιμές trim-from-start και trim-from-end μέσω των μεθόδων [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/el/python-java/aspose.slides/videoframe/#setTrimFromStart) και [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/el/python-java/aspose.slides/videoframe/#setTrimFromEnd). Και οι δύο τιμές καθορίζονται σε χιλιοστά του δευτερολέπτου και ορίζουν πόσο χρόνο θα παραληφθεί από την αρχή και το τέλος του βίντεο, αντίστοιχα. Αυτές οι ρυθμίσεις αλλάζουν τις ρυθμίσεις αναπαραγωγής βίντεο στην παρουσίαση· δεν κόβουν ή τροποποιούν τα ενσωματωμένα δυαδικά δεδομένα του βίντεο.

**Ορισμός Ρυθμίσεων Περικοπής**

Για να δημιουργήσετε ένα πλαίσιο βίντεο και να ορίσετε τις ρυθμίσεις περικοπής του:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
1. Προσθέστε ένα αντικείμενο [Video](https://reference.aspose.com/slides/el/python-java/aspose.slides/video/) στην παρουσίαση.
1. Προσθέστε ένα αντικείμενο [VideoFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/videoframe/) σε μια διαφάνεια.
1. Ορίστε τις τιμές trim-from-start και trim-from-end μέσω των μεθόδων [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/el/python-java/aspose.slides/videoframe/#setTrimFromStart) και [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/el/python-java/aspose.slides/videoframe/#setTrimFromEnd).
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα κώδικα παραλείπει τα πρώτα 2,5 δευτερόλεπτα και το τελευταίο δευτερόλεπτο ενός ενσωματωμένου βίντεο κατά την αναπαραγωγή:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video)

    video_frame.setTrimFromStart(2500.0)
    video_frame.setTrimFromEnd(1000.0)
    presentation.save("video_with_trim.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Ανάγνωση Ρυθμίσεων Περικοπής**

Για να εξετάσετε τις υπάρχουσες ρυθμίσεις περικοπής, φορτώστε μια παρουσίαση, βρείτε ένα αντικείμενο [VideoFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/videoframe/) μεταξύ των σχημάτων στην πρώτη διαφάνεια και διαβάστε τις τιμές μέσω των μεθόδων [VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/el/python-java/aspose.slides/videoframe/#getTrimFromStart) και [VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/el/python-java/aspose.slides/videoframe/#getTrimFromEnd).

Το παρακάτω παράδειγμα κώδικα βρίσκει το πρώτο πλαίσιο βίντεο στην πρώτη διαφάνεια και αναφέρει τις ρυθμίσεις περικοπής του σε χιλιοστά του δευτερολέπτου:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("video_with_trim.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            trim_from_start = shape.getTrimFromStart()
            trim_from_end = shape.getTrimFromEnd()
            print(f"Trim from start: {trim_from_start} ms")
            print(f"Trim from end: {trim_from_end} ms")
            break
finally:
    presentation.dispose()
```

## **Διαχείριση Υπότιτλων Βίντεο**

Το Aspose.Slides σας επιτρέπει να διαχειρίζεστε κλειστά υπότιτλους για πλαίσια βίντεο σε παρουσιάσεις PowerPoint. Οι υπότιτλοι αποθηκεύονται σε μορφή WebVTT και είναι προσβάσιμοι μέσω της μεθόδου [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/el/python-java/aspose.slides/videoframe/#getCaptionTracks).

**Προσθήκη Υπότιτλων σε Πλαίσιο Βίντεο**

Για να προσθέσετε υπότιτλους σε ένα πλαίσιο βίντεο:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
1. Προσθέστε ένα βίντεο στην παρουσίαση.
1. Προσθέστε ένα αντικείμενο [VideoFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/videoframe/) σε μια διαφάνεια.
1. Χρησιμοποιήστε το [CaptionsCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/captionscollection/) που επιστρέφεται από τη μέθοδο [getCaptionTracks](https://reference.aspose.com/slides/el/python-java/aspose.slides/videoframe/#getCaptionTracks) για να προσθέσετε ένα κομμάτι υπότιτλου WebVTT.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Ο παρακάτω κώδικας σας δείχνει πώς να προσθέσετε υπότιτλους σε ένα πλαίσιο βίντεο:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video)

    # Πρόσθεση νέας πορείας υπότιτλου από αρχείο WebVTT.
    video_frame.getCaptionTracks().add("English", "track.vtt")
    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Η κλάση [CaptionsCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/captionscollection/) παρέχει επίσης μια υπερφόρτωση που σας επιτρέπει να προσθέσετε υπότιτλους από ροή.

**Εξαγωγή Υπότιτλων από Πλαίσιο Βίντεο**

Για να εξάγετε υπότιτλους από ένα πλαίσιο βίντεο:

1. Φορτώστε την παρουσίαση που περιέχει το βίντεο.
1. Βρείτε το στόχο [VideoFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/videoframe/).
1. Περιηγηθείτε στα κομμάτια υπότιτλου της [CaptionsCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/captionscollection/).
1. Αποθηκεύστε κάθε κομμάτι υπότιτλου σε αρχείο `.vtt`.

Ο παρακάτω κώδικας σας δείχνει πώς να εξάγετε υπότιτλους από ένα πλαίσιο βίντεο:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("video_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            for caption_track in shape.getCaptionTracks():
                # Αποθήκευση της πορείας υπότιτλου σε αρχείο WebVTT.
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

Κάθε αντικείμενο [Captions](https://reference.aspose.com/slides/el/python-java/aspose.slides/captions/) εκθέτει το αναγνωριστικό του υπότιτλου, την ετικέτα, τα δυαδικά δεδομένα και το κείμενο του υπότιτλου ως συμβολοσειρά UTF-8.

**Αφαίρεση Υπότιτλων από Πλαίσιο Βίντεο**

Για να αφαιρέσετε υπότιτλους από ένα πλαίσιο βίντεο:

1. Φορτώστε την παρουσίαση που περιέχει το βίντεο.
1. Αποκτήστε το στόχο [VideoFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/videoframe/).
1. Αφαιρέστε τα κομμάτια υπότιτλου από τη [CaptionsCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/captionscollection/).
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Ο παρακάτω κώδικας σας δείχνει πώς να αφαιρέσετε όλους τους υπότιτλους από ένα πλαίσιο βίντεο:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame

presentation = Presentation("video_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().get_Item(0)
    if isinstance(video_frame, VideoFrame):
        # Αφαίρεση όλων των υποτίτλων από το πλαίσιο βίντεο.
        video_frame.getCaptionTracks().clear()
        presentation.save("video_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not a video frame.")
finally:
    presentation.dispose()
```

Αν χρειάζεται να αφαιρέσετε μόνο ένα κομμάτι υπότιτλου, χρησιμοποιήστε τις μεθόδους [remove](https://reference.aspose.com/slides/el/python-java/aspose.slides/captionscollection/#remove) ή [removeAt](https://reference.aspose.com/slides/el/python-java/aspose.slides/captionscollection/#removeAt) αντί για την [clear](https://reference.aspose.com/slides/el/python-java/aspose.slides/captionscollection/#clear).

## **Εξαγωγή Βίντεο από Διαφάνειες**

Εκτός από την προσθήκη βίντεο σε διαφάνειες, το Aspose.Slides σας επιτρέπει να εξάγετε βίντεο ενσωματωμένα σε παρουσιάσεις.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) για να φορτώσετε την παρουσίαση που περιέχει το βίντεο.
2. Περιηγηθείτε σε όλα τα αντικείμενα [Slide](https://reference.aspose.com/slides/el/python-java/aspose.slides/slide/).
3. Περιηγηθείτε σε όλα τα αντικείμενα [Shape](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/) για να βρείτε ένα [VideoFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/videoframe/).
4. Αποθηκεύστε το βίντεο στο δίσκο.

Αυτός ο κώδικας Python σας δείχνει πώς να εξάγετε το βίντεο από μια διαφάνεια παρουσίασης:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("VideoSample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, VideoFrame):
                video = shape.getEmbeddedVideo()
                if video is not None:
                    content_type = str(video.getContentType())
                    file_extension = content_type.split("/", 1)[-1]
                    video_data = bytes(video.getBinaryData())
                    Path("testing2." + file_extension).write_bytes(video_data)
                else:
                    print("The video frame has no embedded video.")
finally:
    presentation.dispose()
```

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Ποια παραμέτρα αναπαραγωγής βίντεο μπορούν να αλλάξουν για ένα VideoFrame;**

Μπορείτε να ελέγξετε τη [λειτουργία αναπαραγωγής](https://reference.aspose.com/slides/el/python-java/aspose.slides/videoframe/#setPlayMode) (αυτόματα ή με κλικ) και την [επαναλήψη](https://reference.aspose.com/slides/el/python-java/aspose.slides/videoframe/#setPlayLoopMode). Αυτές οι επιλογές είναι διαθέσιμες μέσω των ιδιοτήτων του αντικειμένου [VideoFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/videoframe/).

**Επηρεάζει η προσθήκη βίντεο το μέγεθος του αρχείου PPTX;**

Ναι. Όταν ενσωματώνετε ένα τοπικό βίντεο, τα δυαδικά δεδομένα περιλαμβάνονται στο έγγραφο, οπότε το μέγεθος της παρουσίασης αυξάνεται ανάλογα με το μέγεθος του αρχείου. Όταν προσθέτετε ένα διαδικτυακό βίντεο, ενσωματώνεται ένας σύνδεσμος και μια μικρογραφία, επομένως η αύξηση του μεγέθους είναι μικρότερη.

**Μπορώ να αντικαταστήσω το βίντεο σε ένα υπάρχον VideoFrame χωρίς να αλλάξω τη θέση και το μέγεθός του;**

Ναι. Μπορείτε να ανταλλάξετε το [video content](https://reference.aspose.com/slides/el/python-java/aspose.slides/videoframe/#setEmbeddedVideo) μέσα στο πλαίσιο διατηρώντας τη γεωμετρία του σχήματος· αυτό είναι ένα συχνό σενάριο για την ενημέρωση πολυμέσων σε υπάρχουσα διάταξη.

**Μπορεί να προσδιοριστεί ο τύπος περιεχομένου (MIME) ενός ενσωματωμένου βίντεο;**

Ναι. Ένα ενσωματωμένο βίντεο έχει έναν [content type](https://reference.aspose.com/slides/el/python-java/aspose.slides/video/#getContentType) που μπορείτε να διαβάσετε και να χρησιμοποιήσετε, για παράδειγμα όταν το αποθηκεύετε στο δίσκο.