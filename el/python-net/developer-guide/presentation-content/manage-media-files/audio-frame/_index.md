---
title: Διαχείριση Ήχου σε Παρουσιάσεις με Python
linktitle: Πλαίσιο Ήχου
type: docs
weight: 10
url: /el/python-net/audio-frame/
keywords:
- προσθήκη ήχου
- ενσωμάτωση ήχου
- πλαίσιο ήχου
- αρχείο ήχου
- ιδιότητες ήχου
- εξαγωγή ήχου
- ανάκτηση ήχου
- αλλαγή ήχου
- επιλογές αναπαραγωγής
- λειτουργία αναπαραγωγής
- αναπαραγωγή σε όλες τις διαφάνειες
- βρόχος μέχρι τη διακοπή
- απόκρυψη κατά τη διάρκεια της παρουσίασης
- επαναφορά μετά την αναπαραγωγή
- ένταση ήχου
- προεπιλεγμένη εικόνα
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Προσθέστε, εξάγετε και διαχειριστείτε εύκολα πλαίσια ήχου σε PPT, PPTX και ODP με Aspose.Slides για Python μέσω .NET. Εξερευνήστε παραδείγματα κώδικα και ενισχύστε τις παρουσιάσεις σας σήμερα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με πλαίσια ήχου στο Aspose.Slides. Εμφανίζει πώς να προσθέτετε ενσωματωμένο ήχο σε διαφάνειες, να προσαρμόζετε τη μικρογραφία του πλαισίου ήχου, να διαμορφώνετε επιλογές αναπαραγωγής όπως η ένταση, η επανάληψη, η απόκρυψη, η περικοπή και οι διάρκειες εξασθένισης, και να εξάγετε τον ήχο που χρησιμοποιείται σε μεταβάσεις παρουσίασης.

## **Δημιουργία Πλαισίων Ήχου**

Το Aspose.Slides για Python μέσω .NET σας επιτρέπει να προσθέτετε αρχεία ήχου σε διαφάνειες. Τα αρχεία ήχου ενσωματώνονται στις διαφάνειες ως πλαίσια ήχου. 

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) .
2. Λάβετε μια αναφορά στη διαφάνεια μέσω του δείκτη της.
3. Φορτώστε το ρεύμα αρχείου ήχου που θέλετε να ενσωματώσετε στη διαφάνεια.
4. Προσθέστε το ενσωματωμένο πλαίσιο ήχου (που περιέχει το αρχείο ήχου) στη διαφάνεια.
5. Ορίστε το [PlayMode](https://reference.aspose.com/slides/el/python-net/aspose.slides/audioplaymodepreset) και το `Volume` που εκτίθενται από το αντικείμενο [IAudioFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/audioframe/) .
6. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας Python σας δείχνει πώς να προσθέσετε ένα ενσωματωμένο πλαίσιο ήχου σε μια διαφάνεια:

```python
import aspose.slides as slides

# Δημιουργήστε μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο παρουσίασης
with slides.Presentation() as pres:
    # Λαμβάνει την πρώτη διαφάνεια
    sld = pres.slides[0]

    # Φορτώνει το αρχείο ήχου wav σε ρεύμα
    with open(path + "sampleaudio.wav", "rb") as in_file:
        # Προσθέτει το Πλαίσιο Ήχου
        audio_frame = sld.shapes.add_audio_frame_embedded(50, 150, 100, 100, in_file)

        # Ορίζει τη Λειτουργία Αναπαραγωγής και την Ένταση του Ήχου
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO
        audio_frame.volume = slides.AudioVolumeMode.LOUD

        # Γράφει το αρχείο PowerPoint στο δίσκο
        pres.save("AudioFrameEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Αλλαγή Μικρογραφίας Πλαισίου Ήχου**

Όταν προσθέτετε ένα αρχείο ήχου σε μια παρουσίαση, ο ήχος εμφανίζεται ως πλαίσιο με μια τυπική προεπιλεγμένη εικόνα (δείτε την εικόνα στην παρακάτω ενότητα). Μπορείτε να αλλάξετε τη μικρογραφία του πλαισίου ήχου (ορίστε την προτιμώμενη εικόνα σας).

Αυτός ο κώδικας Python σας δείχνει πώς να αλλάξετε τη μικρογραφία ή την εικόνα προεπισκόπησης ενός πλαισίου ήχου:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Προσθέτει ένα πλαίσιο ήχου στη διαφάνεια με καθορισμένη θέση και μέγεθος.
    with open("sample2.mp3", "rb") as audio_fs:
        audioFrame = slide.shapes.add_audio_frame_embedded(150, 100, 50, 50, audio_fs)

        # Προσθέτει μια εικόνα στους πόρους της παρουσίασης.
        with open("eagle.jpeg", "rb") as image_fs:
            data = image_fs.read()
        
        audioImage = presentation.images.add_image(data)

        # Ορίζει την εικόνα για το πλαίσιο ήχου.
        audioFrame.picture_format.picture.image = audioImage
        
        #Αποθηκεύει την τροποποιημένη παρουσίαση στο δίσκο
        presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Αλλαγή Επιλογών Αναπαραγωγής Ήχου**

Το Aspose.Slides για Python μέσω .NET σας επιτρέπει να αλλάξετε τις επιλογές που ελέγχουν την αναπαραγωγή ή τις ιδιότητες ενός ήχου. Για παράδειγμα, μπορείτε να ρυθμίσετε την ένταση ήχου, να ορίσετε τον ήχο να παίζει σε βρόχο, ή ακόμη και να κρύψετε το εικονίδιο ήχου.

Το **Επιλογές ήχου** pane στο Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Οι **Επιλογές ήχου** του PowerPoint που αντιστοιχούν στις ιδιότητες Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/audioframe/) :

- **Έναρξη** η λίστα drop-down ταιριάζει με την ιδιότητα [AudioFrame.play_mode](https://reference.aspose.com/slides/el/python-net/aspose.slides/audioframe/play_mode/) 
- **Ένταση** ταιριάζει με την ιδιότητα [AudioFrame.volume](https://reference.aspose.com/slides/el/python-net/aspose.slides/audioframe/volume/) 
- **Αναπαραγωγή σε όλες τις διαφάνειες** ταιριάζει με την ιδιότητα [AudioFrame.play_across_slides](https://reference.aspose.com/slides/el/python-net/aspose.slides/audioframe/play_across_slides/) 
- **Βρόχος μέχρι τη διακοπή** ταιριάζει με την ιδιότητα [AudioFrame.play_loop_mode](https://reference.aspose.com/slides/el/python-net/aspose.slides/audioframe/play_loop_mode/) 
- **Απόκρυψη κατά τη διάρκεια της παρουσίασης** ταιριάζει με την ιδιότητα [AudioFrame.hide_at_showing](https://reference.aspose.com/slides/el/python-net/aspose.slides/audioframe/hide_at_showing/) 
- **Προώθηση προς τα πίσω μετά την αναπαραγωγή** ταιριάζει με την ιδιότητα [AudioFrame.rewind_audio](https://reference.aspose.com/slides/el/python-net/aspose.slides/audioframe/rewind_audio/) 

Οι επιλογές **Επεξεργασίας** του PowerPoint που αντιστοιχούν στις ιδιότητες Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/audioframe/) :

- **Βαθμιαία εμφάνιση** ταιριάζει με την ιδιότητα [AudioFrame.fade_in_duration](https://reference.aspose.com/slides/el/python-net/aspose.slides/audioframe/fade_in_duration/) 
- **Βαθμιαία εξάλειψη** ταιριάζει με την ιδιότητα [AudioFrame.fade_out_duration](https://reference.aspose.com/slides/el/python-net/aspose.slides/audioframe/fade_out_duration/) 
- **Περικοπή χρόνου έναρξης ήχου** ταιριάζει με την ιδιότητα [AudioFrame.trim_from_start](https://reference.aspose.com/slides/el/python-net/aspose.slides/audioframe/trim_from_start/) 
- **Περικοπή χρόνου λήξης ήχου** η τιμή ισούται με τη διάρκεια του ήχου μείον την τιμή της ιδιότητας [AudioFrame.trim_from_end](https://reference.aspose.com/slides/el/python-net/aspose.slides/audioframe/trim_from_end/) 

Ο **ελεγκτής έντασης** του PowerPoint στον πίνακα ελέγχου ήχου αντιστοιχεί στην ιδιότητα [AudioFrame.volume_value](https://reference.aspose.com/slides/el/python-net/aspose.slides/audioframe/volume_value/) . Σας επιτρέπει να αλλάξετε την ένταση του ήχου ως ποσοστό.

Αυτή είναι η διαδικασία αλλαγής των επιλογών αναπαραγωγής ήχου:

1. [Сreate](#create-audio-frame) ή λάβετε το πλαίσιο ήχου.
2. Ορίστε νέες τιμές για τις ιδιότητες του πλαισίου ήχου που θέλετε να προσαρμόσετε.
3. Αποθηκεύστε το τροποποιημένο αρχείο PowerPoint.

Αυτός ο κώδικας Python δείχνει μια λειτουργία στην οποία προσαρμόζονται οι επιλογές ήχου:

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # Λαμβάνει το σχήμα AudioFrame
    audioFrame = pres.slides[0].shapes[0]

    # Ορίζει τη λειτουργία αναπαραγωγής σε αναπαραγωγή με κλικ
    audioFrame.play_mode = slides.AudioPlayModePreset.ON_CLICK

    # Ορίζει την ένταση σε χαμηλή
    audioFrame.volume = slides.AudioVolumeMode.LOW

    # Ορίζει τον ήχο να αναπαράγεται σε όλες τις διαφάνειες
    audioFrame.play_across_slides = True

    # Απενεργοποιεί τον βρόχο για τον ήχο
    audioFrame.play_loop_mode = False

    # Κρύβει το AudioFrame κατά τη διάρκεια της παρουσίασης
    audioFrame.hide_at_showing = True

    # Επαναφέρει τον ήχο στην αρχή μετά την αναπαραγωγή
    audioFrame.rewind_audio = True

    # Αποθηκεύει το αρχείο PowerPoint στο δίσκο
    pres.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```

Αυτό το παράδειγμα Python δείχνει πώς να προσθέσετε ένα νέο πλαίσιο ήχου με ενσωματωμένο ήχο, να το περικόψετε και να ορίσετε τις διάρκειες εξασθένισης:

```py
with slides.Presentation() as pres:
    slide = pres.slides[0]

    with open("sampleaudio.mp3", "rb") as audio_stream:
        audio_data = audio_stream.read()

    audio = pres.audios.add_audio(audio_data)
    audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio)

    # Ορίζει το offset έναρξης περικοπής σε 1,5 δευτερόλεπτα
    audio_frame.trim_from_start = 1500.0
    # Ορίζει το offset λήξης περικοπής σε 2 δευτερόλεπτα
    audio_frame.trim_from_end = 2000.0

    # Ορίζει τη διάρκεια εξασθένισης εισόδου σε 200 ms
    audio_frame.fade_in_duration = 200.0
    # Ορίζει τη διάρκεια εξασθένισης εξόδου σε 500 ms
    audio_frame.fade_out_duration = 500.0

    pres.save("AudioFrameTrimFade_out.pptx", slides.export.SaveFormat.PPTX)
```

Το παρακάτω δείγμα κώδικα δείχνει πώς να ανακτήσετε ένα πλαίσιο ήχου με ενσωματωμένο ήχο και να ορίσετε την έντασή του στο 85%:

```py
with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # Λαμβάνει ένα σχήμα πλαισίου ήχου
    audio_frame = pres.slides[0].shapes[0]

    # Ορίζει την ένταση ήχου στο 85%
    audio_frame.volume_value = 85.0

    pres.save("AudioFrameValue_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Διαχείριση Υπότιτλων Ήχου**

Το Aspose.Slides σας επιτρέπει να προσθέτετε κλειστά υπότιτλους σε ένα πλαίσιο ήχου μέσω της ιδιότητας [caption_tracks](https://reference.aspose.com/slides/el/python-net/aspose.slides/audioframe/caption_tracks/) . Αυτή η ιδιότητα επιστρέφει ένα [CaptionsCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/captionscollection/) , που σας επιτρέπει να προσθέτετε διαδρομές υποτίτλων WebVTT, να τις διατρέχετε και να τις αφαιρείτε όταν χρειάζεται.

**Προσθήκη Υπότιτλων Ήχου**

Χρησιμοποιήστε την ιδιότητα [caption_tracks](https://reference.aspose.com/slides/el/python-net/aspose.slides/audioframe/caption_tracks/) για να επισυνάψετε μία ή περισσότερες διαδρομές υποτίτλων σε ένα πλαίσιο ήχου. Στο παρακάτω παράδειγμα, ένα αρχείο ήχου προστίθεται σε μια διαφάνεια, και στη συνέχεια μια νέα διαδρομή υποτίτλου φορτώνεται από ένα αρχείο `.vtt` .

```py
with slides.Presentation() as presentation:
    with open("audio.mp3", "rb") as audio_stream:
        audio = presentation.audios.add_audio(audio_stream.read())

    slide = presentation.slides[0]
    audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 50, 50, audio)

    # Προσθέστε μια νέα διαδρομή υποτίτλων από αρχείο WebVTT.
    presentation.save("audio_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

**Εξαγωγή Υπότιτλων Ήχου**

Μπορείτε να διατρέξετε τις διαδρομές υποτίτλων που σχετίζονται με ένα πλαίσιο ήχου και να τις αποθηκεύσετε ως αρχεία `.vtt`. Κάθε διαδρομή υπότιτλου εκθέτει τα δυαδικά της δεδομένα και το μοναδικό της αναγνωριστικό, που μπορεί να χρησιμοποιηθεί κατά την εξαγωγή των υποτίτλων.

```py
with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            audio_frame = shape
            for caption_track in audio_frame.caption_tracks:
                # Αποθηκεύστε τη διαδρομή υποτίτλων ως αρχείο .vtt.
                with open(f"{caption_track.caption_id}.vtt", "wb") as track_stream:
                    track_stream.write(caption_track.binary_data)
```

**Απομάκρυνση Υπότιτλων Ήχου**

Για να αφαιρέσετε τους υπότιτλους από ένα πλαίσιο ήχου, χρησιμοποιήστε τις μεθόδους που παρέχονται από το [CaptionsCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/captionscollection/) , όπως [clear](https://reference.aspose.com/slides/el/python-net/aspose.slides/captionscollection/clear/) , [remove](https://reference.aspose.com/slides/el/python-net/aspose.slides/captionscollection/remove/) , ή [remove_at](https://reference.aspose.com/slides/el/python-net/aspose.slides/captionscollection/remove_at/) . Το παρακάτω παράδειγμα αφαιρεί όλες τις διαδρομές υποτίτλων από ένα πλαίσιο ήχου.

```py
with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    audio_frame = slide.shapes[0]  # τύπος: slides.AudioFrame

    # Αφαιρέστε όλες τις διαδρομές υποτίτλων από το πλαίσιο ήχου.
    audio_frame.caption_tracks.clear()

    presentation.save("audio_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

## **Εξαγωγή Ήχου**
Το Aspose.Slides για Python μέσω .NET σας επιτρέπει να εξάγετε τον ήχο που χρησιμοποιείται σε μεταβάσεις παρουσίασης. Για παράδειγμα, μπορείτε να εξάγετε τον ήχο που χρησιμοποιείται σε μια συγκεκριμένη διαφάνεια.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) και φορτώστε την παρουσίαση που περιέχει τον ήχο.
2. Λάβετε την αναφορά της σχετικής διαφάνειας μέσω του δείκτη της.
3. Προσπελάστε τις μεταβάσεις παρουσίασης για τη διαφάνεια.
4. Εξάγετε τον ήχο ως δεδομένα byte.

Αυτός ο κώδικας Python σας δείχνει πώς να εξάγετε τον ήχο που χρησιμοποιείται σε μια διαφάνεια:

```python
import aspose.slides as slides

#with slides.Presentation("AudioSlide.pptx") as pres:
with slides.Presentation("AudioFrameEmbed_changed.pptx") as pres:
    # Προσεγγίζει τη ζητούμενη διαφάνεια
    slide = pres.slides[0]  

    # Λαμβάνει τα εφέ μετάβασης παρουσίασης για τη διαφάνεια
    transition = slide.slide_show_transition

    # Εξάγει τον ήχο ως πεδίο byte
    audio = transition.sound.binary_data

    print("Length: " + str(len(audio)))
```

## **FAQ**

**Μπορώ να επαναχρησιμοποιήσω το ίδιο αρχείο ήχου σε πολλαπλές διαφάνειες χωρίς να αυξήσω το μέγεθος του αρχείου;**

Ναι. Προσθέστε τον ήχο μία φορά στη [audio collection](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/audios/) κοινόχρηστη συλλογή ήχου της παρουσίασης και δημιουργήστε επιπλέον πλαίσια ήχου που αναφέρονται σε αυτό το υπάρχον αντικείμενο. Αυτό αποτρέπει το διπλασιασμό των δεδομένων πολυμέσων και διατηρεί το μέγεθος της παρουσίασης υπό έλεγχο.

**Μπορώ να αντικαταστήσω τον ήχο σε ένα υπάρχον πλαίσιο ήχου χωρίς να δημιουργήσω ξανά το σχήμα;**

Ναι. Για έναν συνδεδεμένο ήχο, ενημερώστε τη [link path](https://reference.aspose.com/slides/el/python-net/aspose.slides/audioframe/link_path_long/) ώστε να δείχνει στο νέο αρχείο. Για έναν ενσωματωμένο ήχο, αντικαταστήστε το αντικείμενο [embedded audio](https://reference.aspose.com/slides/el/python-net/aspose.slides/audioframe/embedded_audio/) με άλλο από τη [audio collection](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/audios/) της παρουσίασης. Η μορφοποίηση του πλαισίου και οι περισσότεροι ρυθμίσεις αναπαραγωγής παραμένουν αμετάβλητες.

**Αλλάζει η περικοπή τα υποκείμενα δεδομένα ήχου που αποθηκεύονται στην παρουσίαση;**

Όχι. Η περικοπή προσαρμόζει μόνο τα όρια αναπαραγωγής. Τα αρχικά bytes του ήχου παραμένουν άθικτα και είναι προσβάσιμα μέσω του ενσωματωμένου ήχου ή της συλλογής ήχου της παρουσίασης.