---
title: Προσθήκη Βίντεο σε Παρουσιάσεις με Python
linktitle: Πλαίσιο Βίντεο
type: docs
weight: 10
url: /el/python-net/video-frame/
keywords:
- προσθήκη βίντεο
- δημιουργία βίντεο
- ενσωμάτωση βίντεο
- εξαγωγή βίντεο
- ανάκτηση βίντεο
- πλαίσιο βίντεο
- πηγή διαδικτύου
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε και να εξάγετε προγραμματιστικά πλαίσια βίντεο σε διαφάνειες PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Python μέσω .NET. Γρήγορος οδηγός βήμα προς βήμα."
---
## **Εισαγωγή**

Ένα σωστά τοποθετημένο βίντεο σε μια παρουσίαση μπορεί να κάνει το μήνυμά σας πιο ελκυστικό και να αυξήσει τα επίπεδα αλληλεπίδρασης με το κοινό σας.

Το PowerPoint σας επιτρέπει να προσθέσετε βίντεο σε μια διαφάνεια σε μια παρουσίαση με δύο τρόπους:

* Προσθέστε ή ενσωματώστε ένα τοπικό βίντεο (αποθηκευμένο στον υπολογιστή σας)
* Προσθέστε ένα διαδικτυακό βίντεο (από πηγή web όπως το YouTube).

Για να μπορείτε να προσθέσετε βίντεο (αντικείμενα video) σε μια παρουσίαση, το Aspose.Slides παρέχει την κλάση [Video](https://reference.aspose.com/slides/el/python-net/aspose.slides/video/) , την κλάση [VideoFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/videoframe/) και άλλους σχετικούς τύπους.

## **Δημιουργία Ενσωματωμένου Πλαισίου Βίντεο**

Εάν το αρχείο βίντεο που θέλετε να προσθέσετε στη διαφάνειά σας είναι αποθηκευμένο τοπικά, μπορείτε να δημιουργήσετε ένα πλαίσιο βίντεο για να ενσωματώσετε το βίντεο στην παρουσίασή σας.

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
2. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της. 
3. Προσθέστε ένα αντικείμενο [Video](https://reference.aspose.com/slides/el/python-net/aspose.slides/video/) και περάστε τη διαδρομή του αρχείου βίντεο για να ενσωματώσετε το βίντεο στην παρουσίαση. 
4. Προσθέστε ένα αντικείμενο [VideoFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/videoframe/) για να δημιουργήσετε ένα πλαίσιο για το βίντεο.  
5. Αποθηκεύστε την τροποποιημένη παρουσίαση. 

Αυτός ο κώδικας Python σας δείχνει πώς να προσθέσετε ένα τοπικά αποθηκευμένο βίντεο σε μια παρουσίαση:

```python
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
    with open("Wildlife.mp4", "br") as fileStream:
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)

        # Λαμβάνει την πρώτη διαφάνεια και προσθέτει ένα πλαίσιο βίντεο
        pres.slides[0].shapes.add_video_frame(10, 10, 150, 250, video)

        # Αποθηκεύει την παρουσίαση στο δίσκο
        pres.save(path + "pres-with-video.pptx", slides.export.SaveFormat.PPTX)
```

Εναλλακτικά, μπορείτε να προσθέσετε ένα βίντεο περνώντας τη διαδρομή του αρχείου απευθείας στη μέθοδο `add_video_frame(x, y, width, height, fname)`:

``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```

## **Δημιουργία Πλαισίου Βίντεο με Βίντεο από Πηγή Web**

Οι νεότερες εκδόσεις του Microsoft [PowerPoint](https://support.microsoft.com/en-us/office/insert-a-video-from-youtube-or-another-site-8340ec69-4cee-4fe1-ab96-4849154bc6db) υποστηρίζουν διαδικτυακά βίντεο σε παρουσιάσεις. Εάν το βίντεο που θέλετε να χρησιμοποιήσετε είναι διαθέσιμο online (π.χ. στο YouTube), μπορείτε να το προσθέσετε στην παρουσίασή σας μέσω του διαδικτυακού του συνδέσμου.

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) 
2. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της. 
3. Προσθέστε ένα αντικείμενο [Video](https://reference.aspose.com/slides/el/python-net/aspose.slides/video/) και περάστε το σύνδεσμο στο βίντεο.
4. Ορίστε μια μικρογραφία για το πλαίσιο βίντεο. 
5. Αποθηκεύστε την παρουσίαση. 

Αυτός ο κώδικας Python σας δείχνει πώς να προσθέσετε ένα βίντεο από το web σε μια διαφάνεια σε μια παρουσίαση PowerPoint:

```python
import aspose.slides as slides
from urllib.request import urlopen

def add_video_from_youyube(pres, videoId):
    # Προσθέτει ένα πλαίσιο βίντεο
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

## **Περικοπή Πλαισίου Βίντεο**

Το Aspose.Slides σας επιτρέπει να ελέγξετε ποιο τμήμα ενός βίντεο θα αναπαραχθεί ορίζοντας τις τιμές trim-from-start και trim-from-end μέσω των [VideoFrame.trim_from_start](https://reference.aspose.com/slides/el/python-net/aspose.slides/videoframe/trim_from_start/) και [VideoFrame.trim_from_end](https://reference.aspose.com/slides/el/python-net/aspose.slides/videoframe/trim_from_end/). Και οι δύο τιμές ορίζονται σε χιλιοστά του δευτερολέπτου και καθορίζουν πόσο χρόνο παραλείπεται από την αρχή και το τέλος του βίντεο, αντίστοιχα. Αυτές οι ρυθμίσεις αλλάζουν τις ρυθμίσεις αναπαραγωγής βίντεο στην παρουσίαση· δεν κόβουν ούτε τροποποιούν με κάποιον άλλο τρόπο τα ενσωματωμένα δυαδικά δεδομένα του βίντεο.

**Ορισμός Ρυθμίσεων Περικοπής**

Για να δημιουργήσετε ένα πλαίσιο βίντεο και να ορίσετε τις ρυθμίσεις περικοπής του:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
2. Προσθέστε ένα αντικείμενο [Video](https://reference.aspose.com/slides/el/python-net/aspose.slides/video/) στην παρουσίαση.
3. Προσθέστε ένα αντικείμενο [VideoFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/videoframe/) σε μια διαφάνεια.
4. Ορίστε τις τιμές trim-from-start και trim-from-end μέσω των [VideoFrame.trim_from_start](https://reference.aspose.com/slides/el/python-net/aspose.slides/videoframe/trim_from_start/) και [VideoFrame.trim_from_end](https://reference.aspose.com/slides/el/python-net/aspose.slides/videoframe/trim_from_end/) .
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα κώδικα παραλείπει τα πρώτα 2,5 δευτερόλεπτα και το τελευταίο δευτερόλεπτο ενός ενσωματωμένου βίντεο κατά την αναπαραγωγή:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(50, 50, 640, 360, video)

    video_frame.trim_from_start = 2500.0
    video_frame.trim_from_end = 1000.0

    presentation.save("video_with_trim.pptx", slides.export.SaveFormat.PPTX)
```

**Ανάγνωση Ρυθμίσεων Περικοπής**

Για να εξετάσετε τις υπάρχουσες ρυθμίσεις περικοπής, φορτώστε μια παρουσίαση, βρείτε ένα αντικείμενο [VideoFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/videoframe/) μεταξύ των σχημάτων στην πρώτη διαφάνεια και διαβάστε τις τιμές μέσω των [VideoFrame.trim_from_start](https://reference.aspose.com/slides/el/python-net/aspose.slides/videoframe/trim_from_start/) και [VideoFrame.trim_from_end](https://reference.aspose.com/slides/el/python-net/aspose.slides/videoframe/trim_from_end/) .

Το παρακάτω παράδειγμα κώδικα βρίσκει το πρώτο πλαίσιο βίντεο στην πρώτη διαφάνεια και αναφέρει τις ρυθμίσεις περικοπής του σε χιλιοστά του δευτερολέπτου:

```python
import aspose.slides as slides

with slides.Presentation("video_with_trim.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            video_frame = shape
            trim_from_start = video_frame.trim_from_start
            trim_from_end = video_frame.trim_from_end

            print(f"Trim from start: {trim_from_start} ms")
            print(f"Trim from end: {trim_from_end} ms")
            break
```

## **Διαχείριση Υπότιτλων Βίντεο**

Το Aspose.Slides σας επιτρέπει να διαχειριστείτε τα κλειστά υπότιτλοι για πλαίσια βίντεο σε παρουσιάσεις PowerPoint. Οι υπότιτλοι αποθηκεύονται σε μορφή WebVTT και είναι προσβάσιμοι μέσω της ιδιότητας [VideoFrame.caption_tracks](https://reference.aspose.com/slides/el/python-net/aspose.slides/videoframe/caption_tracks/) .

**Προσθήκη Υποτίτλων σε Πλαίσιο Βίντεο**

Για να προσθέσετε υπότιτλους σε ένα πλαίσιο βίντεο:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
2. Προσθέστε ένα βίντεο στην παρουσίαση.
3. Προσθέστε ένα αντικείμενο [VideoFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/videoframe/) σε μια διαφάνεια.
4. Χρησιμοποιήστε τη [CaptionsCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/captionscollection/) που επιστρέφεται από το [caption_tracks](https://reference.aspose.com/slides/el/python-net/aspose.slides/videoframe/caption_tracks/) για να προσθέσετε ένα WebVTT track υποτίτλων.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα δείχνει πώς να προσθέσετε υπότιτλους σε ένα πλαίσιο βίντεο:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)

    # Προσθέτει ένα νέο κομμάτι υποτίτλων από αρχείο WebVTT.
    video_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

Η κλάση [CaptionsCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/captionscollection/) παρέχει επίσης μια υπερφόρτωση που σας επιτρέπει να προσθέσετε υπότιτλους από ροή.

**Εξαγωγή Υποτίτλων από Πλαίσιο Βίντεο**

Για να εξαγάγετε υπότιτλους από ένα πλαίσιο βίντεο:

1. Φορτώστε την παρουσίαση που περιέχει το βίντεο.
2. Βρείτε το αντικείμενο [VideoFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/videoframe/) .
3. Διατρέξτε τη συλλογή [caption_tracks](https://reference.aspose.com/slides/el/python-net/aspose.slides/videoframe/caption_tracks/) .
4. Αποθηκεύστε κάθε track υποτίτλων σε αρχείο `.vtt` .

Το παρακάτω παράδειγμα δείχνει πώς να εξαγάγετε υπότιτλους από ένα πλαίσιο βίντεο:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            for caption_track in shape.caption_tracks:
                # Αποθηκεύει το κομμάτι υποτίτλου σε αρχείο WebVTT.
                file_path = f"{caption_track.caption_id}.vtt"
                with open(file_path, "wb") as track_stream:
                    track_stream.write(bytes(caption_track.binary_data))
```

Κάθε αντικείμενο [Captions](https://reference.aspose.com/slides/el/python-net/aspose.slides/captions/) εκθέτει το αναγνωριστικό του υπότιτλου, την ετικέτα, τα δυαδικά δεδομένα και το κείμενο του υπότιτλου ως συμβολοσειρά UTF-8.

**Αφαίρεση Υποτίτλων από Πλαίσιο Βίντεο**

Για να αφαιρέσετε υποτίτλους από ένα πλαίσιο βίντεο:

1. Φορτώστε την παρουσίαση που περιέχει το βίντεο.
2. Λάβετε το αντικείμενο [VideoFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/videoframe/) .
3. Αφαιρέστε τα tracks υποτίτλων από τη [CaptionsCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/captionscollection/) .
4. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα δείχνει πώς να αφαιρέσετε όλους τους υπότιτλους από ένα πλαίσιο βίντεο:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    video_frame = slide.shapes[0]  # type: slides.VideoFrame

    # Αφαιρεί όλους τους υπότιτλους από το πλαίσιο βίντεο.
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

Εάν χρειάζεστε να αφαιρέσετε μόνο ένα track υπότιτλου, χρησιμοποιήστε τις μεθόδους [remove](https://reference.aspose.com/slides/el/python-net/aspose.slides/captionscollection/remove/) ή [remove_at](https://reference.aspose.com/slides/el/python-net/aspose.slides/captionscollection/remove_at/) αντί για την [clear](https://reference.aspose.com/slides/el/python-net/aspose.slides/captionscollection/clear/) .

## **Εξαγωγή Βίντεο από Διαφάνεια**

Εκτός από την προσθήκη βίντεο σε διαφάνειες, το Aspose.Slides σας επιτρέπει να εξάγετε βίντεο ενσωματωμένα σε παρουσιάσεις.

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) για να φορτώσετε την παρουσίαση που περιέχει το βίντεο. 
2. Διατρέξτε όλα τα αντικείμενα [Slide](https://reference.aspose.com/slides/el/python-net/aspose.slides/slide/) .
3. Διατρέξτε όλα τα αντικείμενα [Shape](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/) για να βρείτε ένα [VideoFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/videoframe/) . 
4. Αποθηκεύστε το βίντεο στον δίσκο.

Αυτός ο κώδικας Python σας δείχνει πώς να εξάγετε το βίντεο από μια διαφάνεια παρουσίασης:

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

**Ποια παραμέτρων αναπαραγωγής βίντεο μπορούν να αλλάξουν για ένα VideoFrame;**

Μπορείτε να ελέγξετε τη [playback mode](https://reference.aspose.com/slides/el/python-net/aspose.slides/videoframe/play_mode/) (αυτόματη ή με κλικ) και το [looping](https://reference.aspose.com/slides/el/python-net/aspose.slides/videoframe/play_loop_mode/). Αυτές οι επιλογές είναι διαθέσιμες μέσω των ιδιοτήτων του αντικειμένου [VideoFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/videoframe/) .

**Επηρεάζει η προσθήκη βίντεο το μέγεθος του αρχείου PPTX;**

Ναι. Όταν ενσωματώσετε ένα τοπικό βίντεο, τα δυαδικά δεδομένα περιλαμβάνονται στο έγγραφο, οπότε το μέγεθος της παρουσίασης αυξάνεται ανάλογα με το μέγεθος του αρχείου. Όταν προσθέσετε ένα διαδικτυακό βίντεο, ενσωματώνεται ένας σύνδεσμος και μια μικρογραφία, επομένως η αύξηση μεγέθους είναι μικρότερη.

**Μπορώ να αντικαταστήσω το βίντεο σε ένα υπάρχον VideoFrame χωρίς να αλλάξω τη θέση και το μέγεθός του;**

Ναι. Μπορείτε να αντικαταστήσετε το [video content](https://reference.aspose.com/slides/el/python-net/aspose.slides/videoframe/embedded_video/) μέσα στο πλαίσιο διατηρώντας τη γεωμετρία του σχήματος· αυτό είναι μια κοινή περίπτωση για την ενημέρωση μέσων σε υπάρχουσα διάταξη.

**Μπορεί να προσδιοριστεί ο τύπος περιεχομένου (MIME) ενός ενσωματωμένου βίντεο;**

Ναι. Ένα ενσωματωμένο βίντεο έχει έναν [content type](https://reference.aspose.com/slides/el/python-net/aspose.slides/video/content_type/) που μπορείτε να διαβάσετε και να χρησιμοποιήσετε, για παράδειγμα όταν το αποθηκεύετε στον δίσκο.