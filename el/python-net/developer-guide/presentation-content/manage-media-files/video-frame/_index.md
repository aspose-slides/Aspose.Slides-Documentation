---
title: Διαχείριση πλαισίων βίντεο σε παρουσιάσεις με Python
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
description: "Μάθετε πώς να προσθέτετε και να εξάγετε προγραμματιστικά πλαίσια βίντεο στις διαφάνειες PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Python μέσω .NET. Γρήγορος οδηγός βήμα προς βήμα."
---
## **Εισαγωγή**

Τα βίντεο μπορούν να βοηθήσουν στην εξήγηση ιδεών και στην εμπλοκή του κοινού. Το Aspose.Slides για Python μέσω .NET επιτρέπει να προσθέτετε πλαίσια βίντεο στις διαφάνειες, να προσαρμόζετε τις ρυθμίσεις αναπαραγωγής, να διαχειρίζεστε υπότιτλους και να εξάγετε ενσωματωμένα δεδομένα βίντεο.

Το PowerPoint υποστηρίζει τοπικά βίντεο και συνδέσμους σε διαδικτυακά βίντεο, όπως βίντεο του YouTube.

Για την αναπαράσταση δεδομένων βίντεο και πλαισίων βίντεο, το Aspose.Slides παρέχει τις κλάσεις [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/) , [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) και άλλους σχετικούς τύπους.

## **Δημιουργία ενσωματωμένου πλαισίου βίντεο**

Εάν το αρχείο βίντεο που θέλετε να προσθέσετε στη διαφάνεια σας βρίσκεται τοπικά, μπορείτε να δημιουργήσετε ένα πλαίσιο βίντεο για να ενσωματώσετε το βίντεο στην παρουσίασή σας.

Αυτό το παράδειγμα ενσωματώνει ένα τοπικό βίντεο στην πρώτη διαφάνεια μιας υπάρχουσας παρουσίασης και αποθηκεύει το αποτέλεσμα. Οι συντεταγμένες και οι διαστάσεις του πλαισίου είναι σε points. Η ροή παραμένει ανοιχτή μέχρι να ολοκληρωθεί η αποθήκευση επειδή η κλάση [LoadingStreamBehavior.KEEP_LOCKED](https://reference.aspose.com/slides/python-net/aspose.slides/loadingstreambehavior/) τη διατηρεί κλειδωμένη ενώ η παρουσίαση τη χρησιμοποιεί.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(video_stream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        slide.shapes.add_video_frame(10, 10, 150, 250, video)

        presentation.save("embedded_video.pptx", slides.export.SaveFormat.PPTX)
```

Μπορείτε επίσης να περάσετε το τοπικό μονοπάτι βίντεο απευθείας στο [add_video_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_video_frame/). Αυτό το παράδειγμα ενσωματώνει το βίντεο στην πρώτη διαφάνεια μιας νέας παρουσίασης. Το βίντεο πρέπει να παραμένει προσβάσιμο μέχρι να αποθηκευτεί η παρουσίαση.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_video_frame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", slides.export.SaveFormat.PPTX)
```

## **Δημιουργία πλαισίου βίντεο με βίντεο από διαδικτυακή πηγή**

Το Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) υποστηρίζει διαδικτυακά βίντεο στις παρουσιάσεις. Μπορείτε να δημιουργήσετε ένα πλαίσιο βίντεο που συνδέεται με ένα διαδικτυακό βίντεο, όπως ένα βίντεο του YouTube.

Αυτό το παράδειγμα προσθέτει έναν σύνδεσμο βίντεο YouTube και μικρογραφία στην πρώτη διαφάνεια. Αντικαταστήστε το αναγνωριστικό του βίντεο για να χρησιμοποιήσετε άλλο βίντεο. Η ρύθμιση [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) ζητά αυτόματη αναπαραγωγή. Η λήψη της μικρογραφίας και η αναπαραγωγή του βίντεο απαιτούν πρόσβαση στο διαδίκτυο. Ο προβολέας παρουσίασης πρέπει επίσης να υποστηρίζει τη διαδικτυακή αναπαραγωγή βίντεο.

```python
from urllib.request import urlopen
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    video_id = "aqz-KE-bpKQ"
    video_url = f"https://www.youtube.com/embed/{video_id}"
    video_frame = slide.shapes.add_video_frame(10, 10, 427, 240, video_url)
    video_frame.play_mode = slides.VideoPlayModePreset.AUTO

    thumbnail_url = f"https://img.youtube.com/vi/{video_id}/hqdefault.jpg"
    with urlopen(thumbnail_url) as response:
        thumbnail_data = response.read()
    thumbnail = presentation.images.add_image(thumbnail_data)
    video_frame.picture_format.picture.image = thumbnail

    presentation.save("online_video.pptx", slides.export.SaveFormat.PPTX)
```

## **Αναπαραγωγή βίντεο σε λειτουργία πλήρους οθόνης**

Σε μια εκπαιδευτική παρουσίαση, μπορείτε να αναπαράγετε μια επίδειξη λογισμικού σε λειτουργία πλήρους οθόνης έτσι ώστε το κοινό να βλέπει τις λεπτομέρειες. Ορίστε το [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/) σε `True` για να ενεργοποιήσετε αυτή τη συμπεριφορά κατά την αναπαραγωγή.

Αυτό το παράδειγμα ανοίγει μια παρουσίαση, βρίσκει το πρώτο [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) στην πρώτη διαφάνεια και ενεργοποιεί την αναπαραγωγή πλήρους οθόνης. Η εισερχόμενη παρουσίαση πρέπει να περιέχει τουλάχιστον μία διαφάνεια με υπάρχον πλαίσιο βίντεο στην πρώτη διαφάνεια.

```python
import aspose.slides as slides

with slides.Presentation("training.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            shape.full_screen_mode = True
            break

    presentation.save("full_screen_video.pptx", slides.export.SaveFormat.PPTX)
```

Η αναπαραγωγή πλήρους οθόνης ελέγχει πώς εμφανίζεται το βίντεο. Ανεξάρτητα, το [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) ελέγχει αν ξεκινά αυτόματα ή με κλικ, και το [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) ελέγχει αν επαναλαμβάνεται. Για να επιλέξετε τη συμπεριφορά εκκίνησης, ορίστε τη λειτουργία αναπαραγωγής σε [VideoPlayModePreset.AUTO or VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/). Το παράδειγμα διατηρεί τις υπάρχουσες ρυθμίσεις εκκίνησης και λούπ.

## **Επιστροφή βίντεο στην αρχή μετά την αναπαραγωγή**

Σε μια εκπαιδευτική παρουσίαση, η επιστροφή ενός βίντεο επίδειξης στην αρχή το κάνει έτοιμο για ξανά αναπαραγωγή. Ορίστε το [rewind_video](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/rewind_video/) σε `True` για να επιστρέψετε το βίντεο στην αρχή μετά το τέλος της αναπαραγωγής.

Αυτό το παράδειγμα ανοίγει μια παρουσίαση, βρίσκει το πρώτο [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) στην πρώτη διαφάνεια και ενεργοποιεί την επιστροφή. Απενεργοποιεί το λούπ ώστε η αναπαραγωγή να μπορεί να ολοκληρωθεί και ορίζει την αναπαραγωγή να ξεκινά με κλικ. Η εισερχόμενη παρουσίαση πρέπει να περιέχει τουλάχιστον μία διαφάνεια με υπάρχον πλαίσιο βίντεο στην πρώτη διαφάνεια.

```python
import aspose.slides as slides

with slides.Presentation("training.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            shape.rewind_video = True
            shape.play_loop_mode = False
            shape.play_mode = slides.VideoPlayModePreset.ON_CLICK
            break

    presentation.save("rewind_video.pptx", slides.export.SaveFormat.PPTX)
```

Η επιστροφή βίντεο στην αρχή το επαναφέρει χωρίς να το ξεκινήσει ξανά. Αντίθετα, η ενεργοποίηση του [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) επαναλαμβάνει αυτόματα την αναπαραγωγή. Κρατήστε το λούπ απενεργοποιημένο όταν θέλετε το βίντεο να ολοκληρωθεί και να παραμείνει έτοιμο για επανααναπαραγωγή. Το [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) ελέγχει ανεξάρτητα την αυτόματη ή με κλικ εκκίνηση· αυτό το παράδειγμα χρησιμοποιεί το [VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/) ώστε ο παρουσιαστής να ελέγχει πότε ξεκινά η αναπαραγωγή. Ορίστε τη λειτουργία αναπαραγωγής μετά τη ρύθμιση λούπ, όπως φαίνεται στο παράδειγμα. Η επιστροφή λειτουργεί ανεξάρτητα από το [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/).

## **Περικοπή πλαισίου βίντεο**

Χρησιμοποιήστε το [VideoFrame.trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_start/) και το [VideoFrame.trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_end/) για να παραλείψετε μέρος της αρχής ή του τέλους ενός βίντεο κατά την αναπαραγωγή. Και οι δύο τιμές εκφράζονται σε milliseconds. Η περικοπή αλλάζει τις ρυθμίσεις αναπαραγωγής χωρίς να τροποποιεί τα ενσωματωμένα δεδομένα βίντεο.

**Ορισμός ρυθμίσεων περικοπής**

Αυτό το παράδειγμα ενσωματώνει ένα τοπικό βίντεο και παραλείπει τα πρώτα 2,5 δευτερόλεπτα και το τελευταίο δευτερόλεπτο κατά την αναπαραγωγή. Χρησιμοποιήστε ένα βίντεο μεγαλύτερο από 3,5 δευτερόλεπτα ώστε να παραμείνει ένα αναγώγιμο τμήμα.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()
    video = presentation.videos.add_video(video_data)

    video_frame = slide.shapes.add_video_frame(50, 50, 640, 360, video)
    video_frame.trim_from_start = 2500.0
    video_frame.trim_from_end = 1000.0

    presentation.save("video_with_trim.pptx", slides.export.SaveFormat.PPTX)
```

**Ανάγνωση ρυθμίσεων περικοπής**

Αυτό το παράδειγμα εκτυπώνει τις τιμές περικοπής του πρώτου πλαισίου βίντεο στην πρώτη διαφάνεια σε milliseconds. Η παρουσίαση πρέπει να περιέχει τουλάχιστον μία διαφάνεια. Εάν αυτή η διαφάνεια δεν έχει πλαίσιο βίντεο, δεν εκτυπώνεται τίποτα. Το προηγούμενο παράδειγμα παράγει τιμές 2500 και 1000.

```python
import aspose.slides as slides

with slides.Presentation("video_with_trim.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            print(f"Trim from start: {shape.trim_from_start} ms")
            print(f"Trim from end: {shape.trim_from_end} ms")
            break
```

## **Διαχείριση υποτίτλων βίντεο**

Το Aspose.Slides σας επιτρέπει να διαχειρίζεστε κλειστούς υπότιτλους για πλαίσια βίντεο σε παρουσιάσεις PowerPoint. Οι υπότιτλοι αποθηκεύονται σε μορφή WebVTT και εκτίθενται μέσω της ιδιότητας [VideoFrame.caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/caption_tracks/).

### **Προσθήκη υποτίτλων σε ένα πλαίσιο βίντεο**

Αυτό το παράδειγμα ενσωματώνει ένα τοπικό βίντεο και προσθέτει ένα WebVTT track υποτίτλων με ετικέτα English. Τα χρονικά σημεία των υποτίτλων πρέπει να ταιριάζουν με το βίντεο. Η αποθηκευμένη παρουσίαση περιλαμβάνει τόσο το βίντεο όσο και τους υπότιτλους του.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()
    video = presentation.videos.add_video(video_data)

    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)
    video_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

Η κλάση [CaptionsCollection](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/) παρέχει επίσης μια υπερφόρτωση που επιτρέπει την προσθήκη υποτίτλων από ροή.

### **Εξαγωγή υποτίτλων από ένα πλαίσιο βίντεο**

Αυτό το παράδειγμα αποθηκεύει όλα τα tracks υποτίτλων από πλαίσια βίντεο στην πρώτη διαφάνεια ως ξεχωριστά αρχεία WebVTT. Διαδοχικοί αριθμοί κρατούν τα αρχεία εξόδου διακριτά. Η κονσόλα αναφέρει τον αριθμό των εξαγόμενων tracks. Η παρουσίαση πρέπει να περιέχει τουλάχιστον μία διαφάνεια.

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    track_count = 0
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            for caption_track in shape.caption_tracks:
                track_count += 1
                output_path = f"captions_{track_count}.vtt"
                with open(output_path, "wb") as track_stream:
                    track_stream.write(bytes(caption_track.binary_data))

    print(f"Caption tracks extracted: {track_count}")
```

Κάθε αντικείμενο [Captions](https://reference.aspose.com/slides/python-net/aspose.slides/captions/) εκθέτει το αναγνωριστικό του υπότιτλου, την ετικέτα, τα δυαδικά δεδομένα και το κείμενο του υπότιτλου ως συμβολοσειρά UTF-8.

### **Αφαίρεση υποτίτλων από ένα πλαίσιο βίντεο**

Αυτό το παράδειγμα αφαιρεί όλους τους υπότιτλους από το πλαίσιο βίντεο στη θέση του πρώτου σχήματος στην πρώτη διαφάνεια και αποθηκεύει το αποτέλεσμα. Υποθέτει ότι η διαφάνεια και το σχήμα υπάρχουν και ότι το σχήμα είναι πλαίσιο βίντεο.

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    
    video_frame = slide.shapes[0]
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

Εάν χρειάζεται να αφαιρέσετε μόνο ένα track υποτίτλου, χρησιμοποιήστε τις μεθόδους [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) ή [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/) αντί για το [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/).

### **Αναζήτηση υποτίτλων βίντεο**

[Captions.data_as_string](https://reference.aspose.com/slides/python-net/aspose.slides/captions/data_as_string/) επιστρέφει ολόκληρο το track WebVTT, συμπεριλαμβανομένου του header, των γραμμών χρονισμού και του κειμένου υποτίτλου. Για παράδειγμα, ένα αγγλικό track στη διαφάνεια 2 μπορεί να περιέχει το ακόλουθο cue:

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Αυτό το παράδειγμα ανοίγει το `captioned_media.pptx` και διαβάζει τα [caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/caption_tracks/) κάθε κορυφαίου πλαισίου βίντεο σε κάθε διαφάνεια. Για κάθε cue απλού κειμένου, βρίσκει τη γραμμή χρονισμού που περιέχει `-->` και συλλέγει τις γραμμές υποτίτλου μέχρι την επόμενη κενή γραμμή ή το τέλος του track. Αναζητεί το κείμενο υποτίτλου για “café” χωρίς διάκριση πεζών‑κεφαλαίων και εκτυπώνει τον αριθμό διαφάνειας, την ετικέτα του track, την αρχική γραμμή χρονισμού και τον πλήρη υπότιτλο για κάθε αντιστοιχία.

```python
import aspose.slides as slides

with slides.Presentation("captioned_media.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.VideoFrame):
                continue

            for track in shape.caption_tracks:
                lines = iter(track.data_as_string.splitlines())
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
                        print(f"Slide {slide.slide_number} | {track.label} | {timing}")
                        print(caption)
```

Το δείγμα track παράγει μία αντιστοιχία. Το “Café” στο header είναι εκτός του κειμένου υποτίτλου, και η έξοδος διατηρεί τη ρύθμιση χρονισμού και και τις δύο γραμμές υποτίτλου.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Εξαγωγή βίντεο από διαφάνεια**

Εκτός από την προσθήκη βίντεο στις διαφάνειες, το Aspose.Slides επιτρέπει την εξαγωγή βίντεο ενσωματωμένων σε παρουσιάσεις.

Αυτό το παράδειγμα εξάγει ενσωματωμένα βίντεο από κάθε διαφάνεια σε ξεχωριστά, αριθμημένα δυαδικά αρχεία. Τα συνδεδεμένα βίντεο παραλείπονται επειδή δεν έχουν ενσωματωμένα δεδομένα. Η κονσόλα εκτυπώνει τον τύπο MIME κάθε βίντεο και το συνολικό πλήθος. Η έξοδος χρησιμοποιεί την γενική επέκταση `.bin`; αλλάξτε την ώστε να ταιριάζει με τον αναφερόμενο τύπο μέσου όταν χρειάζεται.

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_videos.pptx") as presentation:
    video_count = 0
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.VideoFrame):
                video = shape.embedded_video
                if video is None:
                    print("Skipped a linked video: no embedded data is available.")
                    continue

                video_count += 1
                output_path = f"extracted_video_{video_count}.bin"
                with open(output_path, "wb") as video_stream:
                    video_stream.write(bytes(video.binary_data))
                print(f"Video {video_count}: {video.content_type}")

    print(f"Embedded videos extracted: {video_count}")
```

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Ποια παραμέτρα αναπαραγωγής βίντεο μπορούν να αλλάξουν για ένα πλαίσιο βίντεο;**

Μπορείτε να ελέγξετε τη [playback mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) (αυτόματη ή με κλικ) και το [looping](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/). Αυτές οι επιλογές είναι διαθέσιμες μέσω των ιδιοτήτων του αντικειμένου [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/).

**Επηρεάζει η προσθήκη βίντεο το μέγεθος αρχείου PPTX;**

Ναι. Όταν ενσωματώνετε ένα τοπικό βίντεο, τα δυαδικά δεδομένα περιλαμβάνονται στο έγγραφο, έτσι το μέγεθος της παρουσίασης αυξάνεται ανάλογα με το μέγεθος του αρχείου. Όταν συνδέετε ένα διαδικτυακό βίντεο και προσθέτετε μια μικρογραφία, η παρουσίαση αποθηκεύει μόνο τον σύνδεσμο και την εικόνα προεπισκόπησης αντί για τα δεδομένα του βίντεο, οπότε η αύξηση μεγέθους είναι συνήθως μικρότερη.

**Μπορώ να αντικαταστήσω το βίντεο σε ένα υπάρχον πλαίσιο βίντεο χωρίς να αλλάξω τη θέση και το μέγεθός του;**

Ναι. Μπορείτε να ανταλλάξετε το [video content](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/embedded_video/) μέσα στο πλαίσιο διατηρώντας τη γεωμετρία του σχήματος· αυτό είναι συνηθισμένο σενάριο για την ενημέρωση πολυμέσων σε υπάρχουσα διάταξη.

**Μπορεί να προσδιοριστεί ο τύπος περιεχομένου (MIME) ενός ενσωματωμένου βίντεο;**

Ναι. Ένα ενσωματωμένο βίντεο έχει έναν [content type](https://reference.aspose.com/slides/python-net/aspose.slides/video/content_type/) που μπορείτε να διαβάσετε και να χρησιμοποιήσετε, για παράδειγμα κατά την αποθήκευση του σε δίσκο.