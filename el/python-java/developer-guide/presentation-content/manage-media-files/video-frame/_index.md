---
title: Διαχείριση Καρέ Βίντεο σε Παρουσιάσεις χρησιμοποιώντας Python
linktitle: Καρέ Βίντεο
type: docs
weight: 10
url: /el/python-java/video-frame/
keywords:
- προσθήκη βίντεο
- δημιουργία βίντεο
- ενσωμάτωση βίντεο
- εξαγωγή βίντεο
- ανάκτηση βίντεο
- καρέ βίντεο
- διαδικτυακή πηγή
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε και να εξάγετε προγραμματιστικά καρέ βίντεο σε διαφάνειες PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Python μέσω Java. Ένας γρήγορος οδηγός πρακτικής χρήσης."
---
## **Εισαγωγή**

Τα βίντεο μπορούν να βοηθήσουν στην εξήγηση ιδεών και στην εμπλοκή του κοινού. Το Aspose.Slides για Python μέσω Java σάς επιτρέπει να προσθέτετε καρέ βίντεο στις διαφάνειες, να ρυθμίζετε τις ρυθμίσεις αναπαραγωγής, να διαχειρίζεστε υπότιτλους και να εξάγετε τα ενσωματωμένα δεδομένα βίντεο.

Το PowerPoint υποστηρίζει τοπικά βίντεο και συνδέσμους σε διαδικτυακά βίντεο, όπως βίντεο του YouTube.

Για την αναπαράσταση δεδομένων βίντεο και καρέ βίντεο, το Aspose.Slides παρέχει την κλάση [Video](https://reference.aspose.com/slides/python-java/aspose.slides/video/) την κλάση [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) και άλλους σχετικούς τύπους.

## **Δημιουργία Ενσωματωμένου Καρέ Βίντεο**

Εάν το αρχείο βίντεο που θέλετε να προσθέσετε στη διαφάνειά σας είναι αποθηκευμένο τοπικά, μπορείτε να δημιουργήσετε ένα καρέ βίντεο για να ενσωματώσετε το βίντεο στην παρουσίασή σας.

Αυτό το παράδειγμα ενσωματώνει ένα τοπικό βίντεο στην πρώτη διαφάνεια μιας υπάρχουσας παρουσίασης και αποθηκεύει το αποτέλεσμα. Οι συντεταγμένες και οι διαστάσεις του καρέ είναι σε points. Η Python διαβάζει τα byte του βίντεο από το δίσκο, και η JPype τα μετατρέπει σε έναν πίνακα byte της Java πριν το βίντεο προστεθεί στην παρουσίαση.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    slide.getShapes().addVideoFrame(10, 10, 150, 250, video)

    presentation.save("embedded_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Μπορείτε επίσης να περάσετε τη διαδρομή ενός τοπικού βίντεο απευθείας στο [addVideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addVideoFrame). Αυτό το παράδειγμα ενσωματώνει το βίντεο στην πρώτη διαφάνεια μιας νέας παρουσίασης. Το βίντεο πρέπει να παραμένει προσβάσιμο μέχρι να αποθηκευτεί η παρουσίαση.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Δημιουργία Καρέ Βίντεο με Βίντεο από Διαδικτυακή Πηγή**

Το Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) υποστηρίζει διαδικτυακά βίντεο στις παρουσιάσεις. Μπορείτε να δημιουργήσετε ένα καρέ βίντεο που συνδέεται με ένα διαδικτυακό βίντεο, όπως ένα βίντεο του YouTube.

Αυτό το παράδειγμα προσθέτει έναν σύνδεσμο βίντεο YouTube και μια μικρογραφία στην πρώτη διαφάνεια. Αντικαταστήστε το αναγνωριστικό βίντεο για να χρησιμοποιήσετε άλλο βίντεο. Η μέθοδος [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) ζητά αυτόματη αναπαραγωγή. Η λήψη της μικρογραφίας και η αναπαραγωγή του βίντεο απαιτούν πρόσβαση στο διαδίκτυο. Ο προβολέας παρουσίασης πρέπει επίσης να υποστηρίζει την online αναπαραγωγή βίντεο.

```python
from urllib.request import urlopen

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoPlayModePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    video_id = "aqz-KE-bpKQ"
    video_url = "https://www.youtube.com/embed/" + video_id
    video_frame = slide.getShapes().addVideoFrame(10, 10, 427, 240, video_url)
    video_frame.setPlayMode(VideoPlayModePreset.Auto)

    thumbnail_url = "https://img.youtube.com/vi/" + video_id + "/hqdefault.jpg"
    with urlopen(thumbnail_url) as response:
        thumbnail_data = response.read()
    java_thumbnail_data = jpype.JArray(jpype.JByte)(thumbnail_data)
    thumbnail = presentation.getImages().addImage(java_thumbnail_data)
    video_frame.getPictureFormat().getPicture().setImage(thumbnail)

    presentation.save("online_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Αναπαραγωγή Βίντεο σε Λειτουργία Πλήρους Οθόνης**

Σε μια εκπαιδευτική παρουσίαση, μπορείτε να αναπαράγετε μια παρουσίαση λογισμικού σε λειτουργία πλήρους οθνης ώστε το κοινό να δει τις λεπτομέρειες. Καλέστε το [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode) με `True` για να ενεργοποιήσετε αυτή τη συμπεριφορά κατά την αναπαραγωγή.

Αυτό το παράδειγμα ανοίγει μια παρουσίαση, βρίσκει το πρώτο [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) στην πρώτη διαφάνεια και ενεργοποιεί την αναπαραγωγή πλήρους οθόνης. Η εισαγόμενη παρουσίαση πρέπει να περιέχει τουλάχιστον μία διαφάνεια με ένα υπάρχον καρέ βίντεο στην πρώτη διαφάνεια.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame

presentation = Presentation("training.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            shape.setFullScreenMode(True)
            break

    presentation.save("full_screen_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Η αναπαραγωγή πλήρους οθόνης ελέγχει πώς εμφανίζεται το βίντεο. Ανεξάρτητα, το [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) ελέγχει αν ξεκινά αυτόματα ή με κλικ, και το [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) ελέγχει αν επαναλαμβάνεται. Για να επιλέξετε τη συμπεριφορά έναρξης, ορίστε τη λειτουργία αναπαραγωγής σε [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/). Το παράδειγμα διατηρεί τις υπάρχουσες ρυθμίσεις έναρξης και βρόχου.

## **Επαναφορά Βίντεο μετά την Αναπαραγωγή**

Σε μια εκπαιδευτική παρουσίαση, η επαναφορά ενός βίντεο επίδειξης στην αρχή το καθιστά έτοιμο για τον παρουσιαστή να το ξαναπαίξει. Καλέστε το [setRewindVideo](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setRewindVideo) με `True` για να επιστρέψετε το βίντεο στην αρχή μετά το τέλος της αναπαραγωγής.

Αυτό το παράδειγμα ανοίγει μια παρουσίαση, βρίσκει το πρώτο [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) στην πρώτη διαφάνεια και ενεργοποιεί την επαναφορά. Απενεργοποιεί το βρόχο ώστε η αναπαραγωγή να μπορεί να ολοκληρωθεί και ορίζει την εκκίνηση της αναπαραγωγής με κλικ. Η εισαγόμενη παρουσίαση πρέπει να περιέχει τουλάχιστον μία διαφάνεια με ένα υπάρχον καρέ βίντεο στην πρώτη διαφάνεια.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame, VideoPlayModePreset

presentation = Presentation("training.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            shape.setRewindVideo(True)
            shape.setPlayLoopMode(False)
            shape.setPlayMode(VideoPlayModePreset.OnClick)
            break

    presentation.save("rewind_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Η επαναφορά επιστρέφει το βίντεο στην αρχή του χωρίς να το ξεκινά ξανά. Αντιθέτως, η κλήση του [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) με `True` επαναλαμβάνει την αναπαραγωγή αυτόματα. Κρατήστε απενεργοποιημένο το βρόχο όταν θέλετε το βίντεο να ολοκληρωθεί και να παραμείνει έτοιμο για επανάληψη. Το [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) ελέγχει ανεξάρτητα αυτόματη ή με κλικ εκκίνηση· αυτό το παράδειγμα χρησιμοποιεί το [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/) ώστε ο παρουσιαστής να ελέγχει πότε ξεκινά η αναπαραγωγή. Ορίστε τη λειτουργία αναπαραγωγής μετά τη ρύθμιση του βρόχου, όπως φαίνεται στο παράδειγμα. Η επαναφορά λειτουργεί ανεξάρτητα από το [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode).

## **Κοπή Καρέ Βίντεο**

Χρησιμοποιήστε το [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromStart) και το [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromEnd) για να παραλείψετε μέρος της αρχής ή του τέλους ενός βίντεο κατά την αναπαραγωγή. Και οι δύο τιμές είναι σε χιλιοστά του δευτερολέπτου. Η κοπή αλλάζει τις ρυθμίσεις αναπαραγωγής χωρίς να τροποποιεί τα ενσωματωμένα δεδομένα βίντεο.

**Ρυθμίσεις Κοπής**

Αυτό το παράδειγμα ενσωματώνει ένα τοπικό βίντεο και παραλείπει τα πρώτα 2,5 δευτερόλεπτα και το τελευταίο δευτερόλεπτο κατά την αναπαραγωγή. Χρησιμοποιήστε ένα βίντεο μεγαλύτερο από 3,5 δευτερόλεπτα ώστε να παραμείνει ένα αναγώγιμο τμήμα.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video)

    video_frame.setTrimFromStart(2500.0)
    video_frame.setTrimFromEnd(1000.0)

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Ανάγνωση Ρυθμίσεων Κοπής**

Αυτό το παράδειγμα εκτυπώνει τις τιμές κοπής του πρώτου καρέ βίντεο στην πρώτη διαφάνεια σε χιλιοστά του δευτερολέπτου. Η παρουσίαση πρέπει να περιέχει τουλάχιστον μία διαφάνεια. Εάν αυτή η διαφάνεια δεν έχει καρέ βίντεο, δεν εκτυπώνεται τίποτα. Το προηγούμενο παράδειγμα παράγει τιμές 2500 και 1000.

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

Το Aspose.Slides σάς επιτρέπει να διαχειρίζεστε κλειστούς υπότιτλους για τα καρέ βίντεο σε παρουσιάσεις PowerPoint. Οι υπότιτλοι αποθηκεύονται σε μορφή WebVTT και εκτίθενται μέσω της μεθόδου [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks).

### **Προσθήκη Υπότιτλων σε Καρέ Βίντεο**

Αυτό το παράδειγμα ενσωματώνει ένα τοπικό βίντεο και προσθέτει ένα WebVTT track υποτίτλων με ετικέτα English. Τα χρονικά σημεία των υποτίτλων πρέπει να ταιριάζουν με το βίντεο. Η αποθηκευμένη παρουσίαση περιλαμβάνει τόσο το βίντεο όσο και τους υπότιτλους του.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video)

    # Προσθέστε ένα νέο κομμάτι υποτίτλων από αρχείο WebVTT.
    video_frame.getCaptionTracks().add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Η κλάση [CaptionsCollection](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/) παρέχει επίσης υπερφόρτωση που σάς επιτρέπει να προσθέτετε υπότιτλους από ένα stream.

### **Εξαγωγή Υπότιτλων από Καρέ Βίντεο**

Αυτό το παράδειγμα αποθηκεύει όλα τα tracks υποτίτλων από τα καρέ βίντεο στην πρώτη διαφάνεια ως ξεχωριστά αρχεία WebVTT. Διαδοχικοί αριθμοί κρατούν τα αρχεία εξόδου διακριτά. Η κονσόλα αναφέρει τον αριθμό των εξαγόμενων tracks. Η παρουσίαση πρέπει να περιέχει τουλάχιστον μία διαφάνεια.

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

    track_count = 0
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            for caption_track in shape.getCaptionTracks():
                track_count += 1
                output_path = Path(f"captions_{track_count}.vtt")
                caption_data = bytes(caption_track.getBinaryData())
                output_path.write_bytes(caption_data)

    print(f"Caption tracks extracted: {track_count}")
finally:
    presentation.dispose()
```

Κάθε αντικείμενο [Captions](https://reference.aspose.com/slides/python-java/aspose.slides/captions/) εκτίδει το αναγνωριστικό υποτίτλου, την ετικέτα, τα δυαδικά δεδομένα και το κείμενο υπότιτλου ως μια συμβολοσειρά UTF-8.

### **Αφαίρεση Υπότιτλων από Καρέ Βίντεο**

Αυτό το παράδειγμα αφαιρεί όλους τους υπότιτλους από το καρέ βίντεο στη θέση του πρώτου σχήματος στην πρώτη διαφάνεια και αποθηκεύει το αποτέλεσμα. Υποθέτει ότι η διαφάνεια και το σχήμα υπάρχουν και ότι το σχήμα είναι ένα καρέ βίντεο.

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
        # Αφαιρέστε όλους τους υπότιτλους από το καρέ βίντεο.
        video_frame.getCaptionTracks().clear()
        
        presentation.save("video_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not a video frame.")
finally:
    presentation.dispose()
```

Εάν χρειάζεστε να αφαιρέσετε μόνο ένα track υποτίτλου, χρησιμοποιήστε τις μεθόδους [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) ή [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) αντί για τη [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear).

### **Αναζήτηση Υπότιτλων Βίντεο**

[Captions.getDataAsString](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getDataAsString) επιστρέφει το πλήρες track WebVTT, συμπεριλαμβανομένου του header, των γραμμών χρονοδείξεων και του κειμένου υποτίτλου. Μπορείτε να αναζητήσετε τους υπότιτλους στη μνήμη για να βρείτε μια φράση και τη χρονοσήμανσή της. Για παράδειγμα, ένα αγγλικό track στη διαφάνεια 2 μπορεί να περιέχει το παρακάτω κείμενο.

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Αυτό το παράδειγμα ανοίγει το `captioned_media.pptx` και χρησιμοποιεί το [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks) για να διαβάσει τα tracks κάθε κορυφαίου καρέ βίντεο σε κάθε διαφάνεια. Σε ένα απλό κείμενο cue, η γραμμή χρονοδείξης περιέχει `-->`, και μια κενή γραμμή τερματίζει το cue. Για κάθε υπότιτλο που περιέχει τη λέξη “café” σε οποιοδήποτε αλφάβητο, το παράδειγμα εκτυπώνει τον αριθμό διαφάνειας, την ετικέτα του track, την αρχική γραμμή χρονοδείξης και τον πλήρη υπότιτλο.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("captioned_media.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, VideoFrame):
                continue
            for track in shape.getCaptionTracks():
                track_text = str(track.getDataAsString())
                lines = iter(track_text.splitlines())
                for timing in lines:
                    if "-->" not in timing:
                        continue
                    caption_lines = []
                    for line in lines:
                        if not line:
                            break
                        caption_lines.append(line)
                    caption = "\n".join(caption_lines)
                    if "café" in caption.casefold():
                        print(f"Slide {slide.getSlideNumber()} | {track.getLabel()} | {timing}")
                        print(caption)
finally:
    presentation.dispose()
```

Η αναζήτηση για “café” παράγει ένα ταίριασμα για το δείγμα track. Η αναζήτηση εξαιρεί το header του track και διατηρεί τη ρύθμιση χρόνου και τις αλλαγές γραμμής στην έξοδο.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Εξαγωγή Βίντεο από Διαφάνεια**

Εκτός από την προσθήκη βίντεο σε διαφάνειες, το Aspose.Slides σας επιτρέπει να εξάγετε τα βίντεο που είναι ενσωματωμένα σε παρουσιάσεις.

Αυτό το παράδειγμα εξάγει τα ενσωματωμένα βίντεο από κάθε διαφάνεια σε ξεχωριστά αριθμημένα δυαδικά αρχεία. Τα συνδεδεμένα βίντεο παραλείπονται επειδή δεν έχουν ενσωματωμένα δεδομένα. Η κονσόλα εκτυπώνει τον τύπο MIME κάθε βίντεο και τον συνολικό αριθμό. Η έξοδος χρησιμοποιεί την γενική επέκταση `.bin`; αλλάξτε την ώστε να ταιριάζει με τον αναφερθέν τύπο μέσου όταν χρειάζεται.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("presentation_with_videos.pptx")
try:
    video_count = 0
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, VideoFrame):
                video = shape.getEmbeddedVideo()
                if video is None:
                    print("Skipped a linked video: no embedded data is available.")
                    continue

                video_count += 1
                output_path = Path(f"extracted_video_{video_count}.bin")
                video_data = bytes(video.getBinaryData())
                output_path.write_bytes(video_data)
                print(f"Video {video_count}: {video.getContentType()}")

    print(f"Embedded videos extracted: {video_count}")
finally:
    presentation.dispose()
```

## **Συχνές Ερωτήσεις**

**Ποια παραμέτρους αναπαραγωγής βίντεο μπορούν να αλλάξουν για ένα καρέ βίντεο;**

Μπορείτε να ελέγξετε τη [λειτουργία αναπαραγωγής](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) (αυτόματη ή με κλικ) και την [επανάληψη](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode). Αυτές οι επιλογές είναι διαθέσιμες μέσω των μεθόδων του αντικειμένου [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/).

**Επηρεάζει η προσθήκη βίντεο το μέγεθος του αρχείου PPTX;**

Ναι. Όταν ενσωματώνετε ένα τοπικό βίντεο, τα δυαδικά δεδομένα συμπεριλαμβάνονται στο έγγραφο, έτσι το μέγεθος της παρουσίασης αυξάνεται ανάλογα με το μέγεθος του αρχείου. Όταν συνδέετε σε ένα διαδικτυακό βίντεο και προσθέτετε μια μικρογραφία, η παρουσίαση αποθηκεύει τον σύνδεσμο και την εικόνα προεπισκόπησης αντί για τα δεδομένα του βίντεο, έτσι η αύξηση μεγέθους είναι συνήθως μικρότερη.

**Μπορώ να αντικαταστήσω το βίντεο σε ένα υπάρχον καρέ βίντεο χωρίς να αλλάξω τη θέση και το μέγεθός του;**

Ναι. Μπορείτε να ανταλλάξετε το [περιεχόμενο βίντεο](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setEmbeddedVideo) μέσα στο καρέ διατηρώντας τη γεωμετρία του σχήματος· αυτό είναι ένα συνηθισμένο σενάριο για την ενημέρωση των μέσων σε υπάρχουσα διάταξη.

**Μπορεί να προσδιοριστεί ο τύπος περιεχομένου (MIME) ενός ενσωματωμένου βίντεο;**

Ναι. Ένα ενσωματωμένο βίντεο διαθέτει έναν [τύπο περιεχομένου](https://reference.aspose.com/slides/python-java/aspose.slides/video/#getContentType) που μπορείτε να διαβάσετε και να χρησιμοποιήσετε, για παράδειγμα κατά την αποθήκευση του σε δίσκο.