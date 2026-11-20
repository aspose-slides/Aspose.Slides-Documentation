---
title: Διαχείριση πλαισίων ήχου σε παρουσιάσεις με Python
linktitle: Πλαίσιο ήχου
type: docs
weight: 10
url: /el/python-net/audio-frame/
keywords:
- ήχος
- πλαίσιο ήχου
- μικρογραφία
- προσθήκη ήχου
- ιδιότητες ήχου
- επιλογές ήχου
- εξαγωγή ήχου
- WebVTT
- Python
- Aspose.Slides
description: "Ενσωματώστε ήχο στις διαφάνειες, αλλάξτε το εικονίδιο ήχου, διαμορφώστε την αναπαραγωγή, διαχειριστείτε υπότιτλους WebVTT και εξάγετε ήχους μετάβασης διαφανειών με το Aspose.Slides for Python via .NET."
---
## **Επισκόπηση**

Ένα πλαίσιο ήχου σας επιτρέπει να αναπαράγετε έναν ήχο σε μια διαφάνεια. Με το Aspose.Slides for Python via .NET, μπορείτε να ενσωματώσετε ένα ηχητικό κλιπ, να επιλέξετε την εικόνα που το αντιπροσωπεύει, να ρυθμίσετε την αναπαραγωγή και να προσθέσετε υπότιτλους. Μπορείτε επίσης να ανακτήσετε έναν ήχο που έχει οριστεί για τη μετάβαση της διαφάνειας.

## **Δημιουργία πλαισίων ήχου**

Χρησιμοποιήστε [add_audio_frame_embedded](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) για να ενσωματώσετε ένα τοπικό ηχητικό κλιπ στην πρώτη διαφάνεια. Οι πρώτες δύο συντεταγμένες τοποθετούν το πλαίσιο στη διαφάνεια και οι επόμενες δύο τιμές ορίζουν το πλάτος και το ύψος του, όλα σε σημεία. Αυτό το παράδειγμα ορίζει το [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) ώστε το κλιπ να ξεκινά αυτόματα και το [volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume/) στο preset υψηλής έντασης.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(50, 150, 100, 100, audio_stream)
    audio_frame.play_mode = slides.AudioPlayModePreset.AUTO
    audio_frame.volume = slides.AudioVolumeMode.LOUD

    presentation.save("AudioFrameEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Αλλαγή της μικρογραφίας του πλαισίου ήχου**

Από προεπιλογή, ένα πλαίσιο ήχου εμφανίζει ένα εικονίδιο ηχείου. Για να εμφανίσετε μια προσαρμοσμένη μικρογραφία, προσθέστε μια εικόνα στην παρουσίαση με το [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/) και αντιστοιχίστε τη στην ιδιότητα [picture_format.picture.image](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image/) του πλαισίου. Το παράδειγμα χρησιμοποιεί ένα JPEG ως μικρογραφία για το ενσωματωμένο ηχητικό κλιπ.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("eagle.jpeg", "rb") as image_stream:
        thumbnail = presentation.images.add_image(image_stream)

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(150, 100, 50, 50, audio_stream)
    audio_frame.picture_format.picture.image = thumbnail

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Αλλαγή επιλογών αναπαραγωγής ήχου**

Οι **ρυθμίσεις ήχου** του PowerPoint καθορίζουν πότε ξεκινά ένα κλιπ, πόσο δυνατό είναι και πώς συμπεριφέρεται κατά τη διάρκεια της παρουσίασης.

![PowerPoint Audio Options controls for an audio frame](audio_frame_0.png)

| Έλεγχος PowerPoint | Ιδιότητα Aspose.Slides |
| --- | --- |
| Έναρξη | [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) |
| Πρόεπιλεγμένη ένταση | [volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume/) |
| Αναπαραγωγή σε όλες τις διαφάνειες | [play_across_slides](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_across_slides/) |
| Βρόχος μέχρι τη διακοπή | [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_loop_mode/) |
| Απόκρυψη κατά την προβολή | [hide_at_showing](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/hide_at_showing/) |
| Επιστροφή στην αρχή μετά την αναπαραγωγή | [rewind_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/rewind_audio/) |
| Εξασθένιση εισόδου | [fade_in_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_in_duration/) |
| Εξασθένιση εξόδου | [fade_out_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_out_duration/) |
| Περικοπή χρόνου έναρξης ήχου | [trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_start/) |
| Περικοπή χρόνου λήξης ήχου | [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) |
| Ολισθητής έντασης | [volume_value](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume_value/) |

Το παράδειγμα εντοπίζει το πρώτο πλαίσιο ήχου στην πρώτη διαφάνεια, ορίζει το [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) ώστε η αναπαραγωγή να ξεκινά με κλικ, και επιλέγει το preset χαμηλής έντασης. Το κλιπ συνεχίζει μεταξύ των διαφανειών με απενεργοποιημένο το βρόχο. Το εικονίδιο παραμένει κρυφό κατά τη διάρκεια της παρουσίασης, και το κλιπ επανέρχεται στην αρχή μετά την αναπαραγωγή.

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as presentation:
    slide = presentation.slides[0]

    audio_frame = next((shape for shape in slide.shapes if isinstance(shape, slides.AudioFrame)), None)
    if audio_frame is None:
        print("The first slide has no audio frame.")
    else:
        audio_frame.play_mode = slides.AudioPlayModePreset.ON_CLICK
        audio_frame.volume = slides.AudioVolumeMode.LOW
        audio_frame.play_across_slides = True
        audio_frame.play_loop_mode = False
        audio_frame.hide_at_showing = True
        audio_frame.rewind_audio = True
        
        presentation.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```

Για κλιπ μεγαλύτερο από 3,5 δευτερόλεπτα, αυτό το παράδειγμα παραλείπει τα πρώτα 1,5 δευτερόλεπτα και τα τελευταία 2 δευτερόλεπτα. Το [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) μετρά τη διάρκεια που πρέπει να παραλειφθεί από το τέλος του κλιπ. Για να λάβετε τον χρόνο λήξης που εμφανίζεται στο PowerPoint, αφαιρέστε αυτήν την παράμετρο από τη συνολική διάρκεια του κλιπ. Το περικομμένο κλιπ εξασθένει στην είσοδο σε 200 χιλιοστά του δευτερολέπτου και στην έξοδο σε 500 χιλιοστά του δευτερολέπτου. Όλες οι τέσσερις ιδιότητες παίρνουν τιμές σε χιλιοστά του δευτερολέπτου.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio_stream)
    audio_frame.trim_from_start = 1500.0
    audio_frame.trim_from_end = 2000.0
    audio_frame.fade_in_duration = 200.0
    audio_frame.fade_out_duration = 500.0

    presentation.save("AudioFrameTrimFade_out.pptx", slides.export.SaveFormat.PPTX)
```

Για να ορίσετε την ένταση αναπαραγωγής σε συγκεκριμένο ποσοστό, χρησιμοποιήστε το [volume_value](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume_value/). Αυτό το παράδειγμα θέτει το πρώτο πλαίσιο ήχου στην πρώτη διαφάνεια στο 85 %.

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as presentation:
    slide = presentation.slides[0]

    audio_frame = next((shape for shape in slide.shapes if isinstance(shape, slides.AudioFrame)), None)
    if audio_frame is None:
        print("The first slide has no audio frame.")
    else:
        audio_frame.volume_value = 85.0
        presentation.save("AudioFrameValue_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Διαχείριση υποτίτλων ήχου**

Κάθε πλαίσιο ήχου έχει μια συλλογή [caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/caption_tracks/). Χρησιμοποιήστε την για να επισυνάψετε υποτίτλους WebVTT στο κλιπ, να εξάγετε υπάρχοντες δρόμους ή να τους αφαιρέσετε.

### **Προσθήκη υποτίτλων ήχου**

Το παράδειγμα ενσωματώνει ένα ηχητικό κλιπ στην πρώτη διαφάνεια και χρησιμοποιεί το [CaptionsCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/add/) για να επισυνάψει έναν τοπικό δρόμο WebVTT. Το πρώτο όρισμα παρέχει την ετικέτα του δρόμου, και το δεύτερο προσδιορίζει το αρχείο που περιέχει τους χρονισμένους υποτίτλους.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 50, 50, audio_stream)
    audio_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("audio_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

### **Εξαγωγή υποτίτλων ήχου**

Αυτό το παράδειγμα εξάγει κάθε δρόμο υποτίτλων που είναι επισυνάψιμος σε ένα πλαίσιο ήχου στην πρώτη διαφάνεια. Γράφει τα [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/captions/binary_data/) του δρόμου σε αρχείο WebVTT και χρησιμοποιεί το [caption_id](https://reference.aspose.com/slides/python-net/aspose.slides/captions/caption_id/) του ως όνομα αρχείου, ώστε κάθε δρόμος να έχει ξεχωριστό αποτέλεσμα.

```python
import aspose.slides as slides

with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            for track in shape.caption_tracks:
                with open(f"{track.caption_id}.vtt", "wb") as output:
                    output.write(track.binary_data)
```

### **Αφαίρεση υποτίτλων ήχου**

Χρησιμοποιήστε το [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) ή το [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/) για να διαγράψετε έναν μεμονωμένο δρόμο. Το παράδειγμα χρησιμοποιεί το [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/) για να αφαιρέσει όλους τους υποτίτλους από το πρώτο πλαίσιο ήχου στην πρώτη διαφάνεια ενώ διατηρεί το κλιπ.

```python
import aspose.slides as slides

with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    audio_frame = next((shape for shape in slide.shapes if isinstance(shape, slides.AudioFrame)), None)
    if audio_frame is None:
        print("The first slide has no audio frame.")
    else:
        audio_frame.caption_tracks.clear()
        presentation.save("audio_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

### **Αναζήτηση γραμμής στους υποτίτλους ήχου**

Για να βρείτε μια γραμμή στους υποτίτλους ήχου στην πρώτη διαφάνεια, διαβάστε το [data_as_string](https://reference.aspose.com/slides/python-net/aspose.slides/captions/data_as_string/) κάθε δρόμου στη μνήμη. Σε ένα κείμενο WebVTT, η γραμμή χρόνου περιέχει `-->`, οι γραμμές υποτίτλων το ακολουθούν, και μια κενή γραμμή τερματίζει το cue. Το παράδειγμα εκτυπώνει την ετικέτα του δρόμου και κάθε γραμμή υποτίτλου που περιέχει το “café”.

```python
import aspose.slides as slides

with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            for track in shape.caption_tracks:
                in_cue = False
                for line in track.data_as_string.splitlines():
                    if not line:
                        in_cue = False
                    elif "-->" in line:
                        in_cue = True
                    elif in_cue and "café" in line.casefold():
                        print(f"{track.label}: {line}")
```

## **Εξαγωγή ήχου**

Μια μετάβαση διαφάνειας μπορεί να έχει τον δικό της ήχο. Για να το ανακτήσετε, διαβάστε την ιδιότητα [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/) της μετάβασης. Το παράδειγμα προσπερνά τα [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/audio/binary_data/) του ήχου και εκτυπώνει το μέγεθός του σε bytes. Αν η πρώτη διαφάνεια δεν έχει ήχο μετάβασης, εκτυπώνει μήνυμα αντί αυτού.

```python
import aspose.slides as slides

with slides.Presentation("AudioSlide.pptx") as presentation:
    slide = presentation.slides[0]

    sound = slide.slide_show_transition.sound
    if sound is None:
        print("The first slide has no transition sound.")
    else:
        audio_data = sound.binary_data
        print(f"Transition sound: {len(audio_data)} bytes.")
```

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Μπορώ να χρησιμοποιήσω το ίδιο ηχητικό κλιπ σε πολλές διαφάνειες χωρίς να το αντιγράψω;**

Ναι. Προσθέστε το κλιπ μία φορά στη [συλλογή ήχου](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/audios/) της παρουσίασης και περάστε το ίδιο αντικείμενο ήχου στο [add_audio_frame_embedded](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) για κάθε διαφάνεια.

**Μπορώ να αντικαταστήσω τον ήχο σε υπάρχον πλαίσιο ήχου;**

Ναι. Για έναν συνδεδεμένο ήχο, ενημερώστε το [link_path_long](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/link_path_long/) ώστε να δείχνει στο αρχείο αντικατάστασης. Για έναν ενσωματωμένο ήχο, αντιστοιχίστε ένα διαφορετικό κλιπ από τη συλλογή ήχου της παρουσίασης στο [embedded_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/embedded_audio/). Και οι δύο προσεγγίσεις διατηρούν το υπάρχον πλαίσιο.

**Η περικοπή αλλάζει τα ηχητικά δεδομένα που αποθηκεύονται στην παρουσίαση;**

Όχι. Τα [trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_start/) και [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) ορίζουν τα όρια αναπαραγωγής. Μπορείτε ακόμη να ανακτήσετε το πλήρες κλιπ από το [embedded_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/embedded_audio/).