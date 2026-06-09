---
title: Διαχείριση ήχου σε παρουσιάσεις με χρήση PHP
linktitle: Πλαίσιο ήχου
type: docs
weight: 10
url: /el/php-java/audio-frame/
keywords:
- ήχος
- πλαίσιο ήχου
- μικρογραφία
- προσθήκη ήχου
- ιδιότητες ήχου
- επιλογές ήχου
- εξαγωγή ήχου
- PHP
- Aspose.Slides
description: "Δημιουργήστε και ελέγξτε πλαίσια ήχου στο Aspose.Slides για PHP—παραδείγματα κώδικα για ενσωμάτωση, περικοπή, βρόχο και διαμόρφωση της αναπαραγωγής σε παρουσιάσεις PPT, PPTX και ODP."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να δουλεύετε με πλαίσια ήχου στο Aspose.Slides. Δείχνει πώς να προσθέσετε ενσωματωμένο ήχο στις διαφάνειες, να προσαρμόσετε τη μικρογραφία του πλαισίου ήχου, να ρυθμίσετε επιλογές αναπαραγωγής όπως η ένταση, η επανάληψη, η απόκρυψη, η περικοπή και οι διάρκειες μετάπτωσης, και να εξάγετε τον ήχο που χρησιμοποιείται στις μεταβάσεις της παρουσίασης.

## **Δημιουργία πλαισίων ήχου**

Το Aspose.Slides για PHP μέσω Java σάς επιτρέπει να προσθέτετε αρχεία ήχου σε διαφάνειες. Τα αρχεία ήχου ενσωματώνονται στις διαφάνειες ως πλαίσια ήχου.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation).
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της.
3. Φορτώστε τη ροή αρχείου ήχου που θέλετε να ενσωματώσετε στη διαφάνεια.
4. Προσθέστε το ενσωματωμένο πλαίσιο ήχου (που περιέχει το αρχείο ήχου) στη διαφάνεια.
5. Ορίστε το [PlayMode](https://reference.aspose.com/slides/el/php-java/aspose.slides/AudioPlayModePreset) και το `Volume` που εκτίθενται από το αντικείμενο [AudioFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/audioframe/).
6. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας PHP δείχνει πώς να προσθέσετε ένα ενσωματωμένο πλαίσιο ήχου σε μια διαφάνεια:

```php
// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
$pres = new Presentation();
try {
    # Λαμβάνει την πρώτη διαφάνεια
    $sld = $pres->getSlides()->get_Item(0);
    # Φορτώνει το αρχείο ήχου wav σε ροή
    $fstr = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
    # Προσθέτει το Πλαίσιο Ήχου
    $audioFrame = $sld->getShapes()->addAudioFrameEmbedded(50, 150, 100, 100, $fstr);
    $fstr->close();
    # Ορίζει το Λειτουργικό Μέσο Αναπαραγωγής και την Ένταση του Ήχου
    $audioFrame->setPlayMode(AudioPlayModePreset->Auto);
    $audioFrame->setVolume(AudioVolumeMode->Loud);
    # Γράφει το αρχείο PowerPoint στον δίσκο
    $pres->save("AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
} catch(JavaException e) {
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```

## **Αλλαγή της μικρογραφίας του πλαισίου ήχου**

Όταν προσθέτετε ένα αρχείο ήχου σε μια παρουσίαση, ο ήχος εμφανίζεται ως πλαίσιο με μια τυπική προεπιλεγμένη εικόνα (δείτε την εικόνα στην παρακάτω ενότητα). Μπορείτε να αλλάξετε την εικόνα προεπισκόπησης του πλαισίου ήχου (ορίστε την επιθυμητή σας εικόνα).

Αυτός ο κώδικας PHP δείχνει πώς να αλλάξετε τη μικρογραφία ή την εικόνα προεπισκόπησης ενός πλαισίου ήχου:

```php
$presentation = new Presentation();
try {
	$slide = $presentation->getSlides()->get_Item(0);
	# Προσθέτει ένα πλαίσιο ήχου στη διαφάνεια με καθορισμένη θέση και μέγεθος.
	$audioStream = new Java("java.io.FileInputStream", "sample2.mp3");
	$audioFrame = $slide->getShapes()->addAudioFrameEmbedded(150, 100, 50, 50, $audioStream);
	$audioStream->close();
	# Προσθέτει μια εικόνα στους πόρους της παρουσίασης.
	$picture;
	$image = Images->fromFile("eagle.jpeg");
	try {
		$picture = $presentation->getImages()->addImage($image);
	} finally {
		if (!java_is_null($image)) {
			$image->dispose();
		}
	}
	# Ορίζει την εικόνα για το πλαίσιο ήχου.
	$audioFrame->getPictureFormat()->getPicture()->setImage($picture);// <-----

	# Αποθηκεύει την τροποποιημένη παρουσίαση στον δίσκο
	$presentation->save("example_out.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
	if (!java_is_null($presentation)) {
		$presentation->dispose();
	}
}
```

## **Αλλαγή επιλογών αναπαραγωγής ήχου**

Το Aspose.Slides για PHP μέσω Java σάς επιτρέπει να αλλάζετε επιλογές που ελέγχουν την αναπαραγωγή ή τις ιδιότητες ενός ήχου. Για παράδειγμα, μπορείτε να ρυθμίσετε την ένταση του ήχου, να θέσετε τον ήχο να αναπαράγεται σε βρόχο, ή ακόμη και να κρύψετε το εικονίδιο του ήχου.

Το πάνελ **Audio Options** στο Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Οι **Audio Options** του PowerPoint που αντιστοιχούν στις ιδιότητες του Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/audioframe/) :

- **Start** η λίστα επιλογών ταιριάζει με τη μέθοδο [AudioFrame::setPlayMode](https://reference.aspose.com/slides/el/php-java/aspose.slides/audioframe/#setPlayMode)
- **Volume** ταιριάζει με τη μέθοδο [AudioFrame::setVolume](https://reference.aspose.com/slides/el/php-java/aspose.slides/audioframe/#setVolume)
- **Play Across Slides** ταιριάζει με τη μέθοδο [AudioFrame::setPlayAcrossSlides](https://reference.aspose.com/slides/el/php-java/aspose.slides/audioframe/#setPlayAcrossSlides)
- **Loop until Stopped** ταιριάζει με τη μέθοδο [AudioFrame::setPlayLoopMode](https://reference.aspose.com/slides/el/php-java/aspose.slides/audioframe/#setPlayLoopMode)
- **Hide During Show** ταιριάζει με τη μέθοδο [AudioFrame::setHideAtShowing](https://reference.aspose.com/slides/el/php-java/aspose.slides/audioframe/#setHideAtShowing)
- **Rewind after Playing** ταιριάζει με τη μέθοδο [AudioFrame::setRewindAudio](https://reference.aspose.com/slides/el/php-java/aspose.slides/audioframe/#setRewindAudio)

Οι επιλογές **Editing** του PowerPoint που αντιστοιχούν στις ιδιότητες του Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/audioframe/) :

- **Fade In** ταιριάζει με τη μέθοδο [AudioFrame::setFadeInDuration](https://reference.aspose.com/slides/el/php-java/aspose.slides/audioframe/#setFadeInDuration) 
- **Fade Out** ταιριάζει με τη μέθοδο [AudioFrame::setFadeOutDuration](https://reference.aspose.com/slides/el/php-java/aspose.slides/audioframe/#setFadeOutDuration) 
- **Trim Audio Start Time** ταιριάζει με τη μέθοδο [AudioFrame::setTrimFromStart](https://reference.aspose.com/slides/el/php-java/aspose.slides/audioframe/#setTrimFromStart) 
- **Trim Audio End Time** η τιμή ισούται με τη διάρκεια του ήχου μείον την τιμή της μεθόδου [AudioFrame::setTrimFromEnd](https://reference.aspose.com/slides/el/php-java/aspose.slides/audioframe/#setTrimFromEnd)

Ο **Volume controll** του PowerPoint στον πίνακα ελέγχου ήχου αντιστοιχεί στη μέθοδο [AudioFrame::setVolumeValue](https://reference.aspose.com/slides/el/php-java/aspose.slides/audioframe/#setVolumeValue). Σας επιτρέπει να αλλάξετε την ένταση του ήχου ως ποσοστό.

Αυτή είναι η διαδικασία για να αλλάξετε τις επιλογές αναπαραγωγής ήχου:

1. [Δημιουργία](#create-audio-frame) ή λήψη του πλαισίου ήχου.
2. Ορίστε νέες τιμές για τις ιδιότητες του πλαισίου ήχου που θέλετε να προσαρμόσετε.
3. Αποθηκεύστε το τροποποιημένο αρχείο PowerPoint.

Αυτός ο κώδικας PHP δείχνει μια λειτουργία όπου οι επιλογές ενός ήχου προσαρμόζονται:

```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    # Αποκτά το σχήμα AudioFrame
    $audioFrame = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Ορίζει τη λειτουργία αναπαραγωγής σε κλικ
    $audioFrame->setPlayMode(AudioPlayModePreset->OnClick);
    # Ορίζει την ένταση σε Χαμηλή
    $audioFrame->setVolume(AudioVolumeMode->Low);
    # Ορίζει τον ήχο να παίζει σε όλες τις διαφάνειες
    $audioFrame->setPlayAcrossSlides(true);
    # Απενεργοποιεί την επανάληψη για τον ήχο
    $audioFrame->setPlayLoopMode(false);
    # Κρύβει το AudioFrame κατά τη διάρκεια της παρουσίασης
    $audioFrame->setHideAtShowing(true);
    # Επαναφέρει τον ήχο στην αρχή μετά την αναπαραγωγή
    $audioFrame->setRewindAudio(true);
    # Αποθηκεύει το αρχείο PowerPoint στον δίσκο
    $pres->save("AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```

Αυτό το παράδειγμα PHP δείχνει πώς να προσθέσετε ένα νέο πλαίσιο ήχου με ενσωματωμένο ήχο, να το περικόψετε και να ορίσετε τις διάρκειες μετάπτωσης:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $audioData = file_get_contents("sampleaudio.mp3");
    $audio = $pres->getAudios()->addAudio($audioData);
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audio);

    // Ορίζει το σημείο έναρξης περικοπής σε 1,5 δευτερόλεπτα
    $audioFrame->setTrimFromStart(1500);
    // Ορίζει το σημείο λήξης περικοπής σε 2 δευτερόλεπτα
    $audioFrame->setTrimFromEnd(2000);

    // Ορίζει τη διάρκεια fade‑in σε 200 ms
    $audioFrame->setFadeInDuration(200);
    // Ορίζει τη διάρκεια fade‑out σε 500 ms
    $audioFrame->setFadeOutDuration(500);

    $pres->save("AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

Το παρακάτω δείγμα κώδικα δείχνει πώς να ανακτήσετε ένα πλαίσιο ήχου με ενσωματωμένο ήχο και να ορίσετε την ένταση του στο 85%:

```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $pres->getSlides()->get_Item(0);

    // Λαμβάνει ένα σχήμα πλαισίου ήχου
    $audioFrame = $slide->getShapes()->get_Item(0);

    // Ορίζει την ένταση ήχου στο 85%
    $audioFrame->setVolumeValue(85);

    $pres->save("AudioFrameValue_out.pptx", SaveFormat::Pptx);
}
finally {
    $pres->dispose();
}
```

## **Διαχείριση Υπότιτλων Ήχου**

Το Aspose.Slides σας επιτρέπει να προσθέσετε κλειστούς υπότιτλους σε ένα πλαίσιο ήχου μέσω της μεθόδου [getCaptionTracks](https://reference.aspose.com/slides/el/php-java/aspose.slides/audioframe/#getCaptionTracks). Αυτή η μέθοδος επιστρέφει ένα [CaptionsCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/captionscollection/), το οποίο σας δίνει τη δυνατότητα να προσθέτετε δίκτυα WebVTT, να διατρέχετε υπάρχοντες υπότιτλους και να τους αφαιρείτε όταν χρειάζεται.

**Add Audio Captions**

Χρησιμοποιήστε τη μέθοδο [getCaptionTracks](https://reference.aspose.com/slides/el/php-java/aspose.slides/audioframe/#getCaptionTracks) για να συνημψετε μία ή περισσότερες γραμμές υπότιτλου σε ένα πλαίσιο ήχου. Στο παρακάτω παράδειγμα, ένα αρχείο ήχου προστίθεται σε μια διαφάνεια και στη συνέχεια ένας νέος υπότιτλος φορτώνεται από αρχείο `.vtt`.

```php
$presentation = new Presentation();
try {
    $audioData = file_get_contents("audio.mp3");
    $audio = $presentation->getAudios()->addAudio($audioData);

    $slide = $presentation->getSlides()->get_Item(0);
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(10, 10, 50, 50, $audio);

    // Προσθέτει μια νέα γραμμή υπότιτλου από αρχείο WebVTT.
    $audioFrame->getCaptionTracks()->add("New track", "track.vtt");

    $presentation->save("audio_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Extract Audio Captions**

Μπορείτε να διατρέχετε τις γραμμές υπότιτλου που σχετίζονται με ένα πλαίσιο ήχου και να τις αποθηκεύετε ως αρχεία `.vtt`. Κάθε γραμμή υπότιτλου εκθέτει τα δυαδικά της δεδομένα και το μοναδικό της αναγνωριστικό, τα οποία μπορούν να χρησιμοποιηθούν κατά την εξαγωγή των υποτίτλων.

```php
$presentation = new Presentation("audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AudioFrame"))) {
            $audioFrame = $shape;
            $trackCount = java_values($audioFrame->getCaptionTracks()->getCount());
            for ($trackIndex = 0; $trackIndex < $trackCount; $trackIndex++) {
                $captionTrack = $audioFrame->getCaptionTracks()->get_Item($trackIndex);
                // Αποθηκεύει κάθε γραμμή υπότιτλου ως αρχείο .vtt.
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

**Remove Audio Captions**

Για να αφαιρέσετε υπότιτλους από ένα πλαίσιο ήχου, χρησιμοποιήστε τις μεθόδους που παρέχονται από το [CaptionsCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/captionscollection/), όπως [clear](https://reference.aspose.com/slides/el/php-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/el/php-java/aspose.slides/captionscollection/#remove), ή [removeAt](https://reference.aspose.com/slides/el/php-java/aspose.slides/captionscollection/#removeAt). Το παρακάτω παράδειγμα αφαιρεί όλες τις γραμμές υπότιτλου από ένα πλαίσιο ήχου.

```php
$presentation = new Presentation($folderPath . "audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $audioFrame = $slide->getShapes()->get_Item(0); // τύπος: AudioFrame

    // Αφαιρέστε όλες τις γραμμές υπότιτλου από το πλαίσιο ήχου.
    $audioFrame->getCaptionTracks()->clear();

    $presentation->save($folderPath . "audio_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Εξαγωγή ήχου**

Το Aspose.Slides για PHP μέσω Java σάς επιτρέπει να εξάγετε τον ήχο που χρησιμοποιείται στις μεταβάσεις της παρουσίασης διαφανειών. Για παράδειγμα, μπορείτε να εξάγετε τον ήχο που χρησιμοποιείται σε μια συγκεκριμένη διαφάνεια.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation) και φορτώστε την παρουσίαση που περιέχει τον ήχο.
2. Αποκτήστε την αναφορά της σχετικής διαφάνειας μέσω του δείκτη της.
3. Πρόσβαση στις [slideshow transitions](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseslide/#getSlideShowTransition) για τη διαφάνεια.
4. Εξαγάγετε τον ήχο σε δεδομένα byte.

Αυτός ο κώδικας δείχνει πώς να εξάγετε τον ήχο που χρησιμοποιείται σε μια διαφάνεια:

```php
# Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
$pres = new Presentation("AudioSlide.pptx");
$Array = new java_class("java.lang.reflect.Array");
try {
	# Πρόσβαση στη ζητούμενη διαφάνεια
	$slide = $pres->getSlides()->get_Item(0);
	# Λαμβάνει τα εφέ μετάβασης της παρουσίασης για τη διαφάνεια
	$transition = $slide->getSlideShowTransition();
	# Εξάγει τον ήχο σε πίνακα byte
	$audio = $transition->getSound()->getBinaryData();
	echo("Length: " . $Array->getLength($audio));
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```

## **Συχνές ερωτήσεις**

**Μπορώ να ξαναχρησιμοποιήσω το ίδιο αρχείο ήχου σε πολλαπλές διαφάνειες χωρίς να αυξήσω το μέγεθος του αρχείου;**

Ναι. Προσθέστε τον ήχο μία φορά στη συλλογή [audio collection](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/getaudios/) της παρουσίασης και δημιουργήστε επιπλέον πλαίσια ήχου που αναφέρονται σε αυτό το υπάρχον στοιχείο. Αυτό αποτρέπει την επανάληψη των δεδομένων πολυμέσων και διατηρεί το μέγεθος της παρουσίασης υπό έλεγχο.

**Μπορώ να αντικαταστήσω τον ήχο σε ένα υπάρχον πλαίσιο ήχου χωρίς να ξαναδημιουργήσω το σχήμα;**

Ναι. Για έναν συνδεδεμένο ήχο, ενημερώστε το [link path](https://reference.aspose.com/slides/el/php-java/aspose.slides/audioframe/setlinkpathlong/) ώστε να δείχνει στο νέο αρχείο. Για έναν ενσωματωμένο ήχο, αντικαταστήστε το αντικείμενο [embedded audio](https://reference.aspose.com/slides/el/php-java/aspose.slides/audioframe/setembeddedaudio/) με ένα άλλο από τη [audio collection](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/getaudios/) της παρουσίασης. Η μορφοποίηση του πλαισίου και οι περισσότερες ρυθμίσεις αναπαραγωγής παραμένουν αμετάβλητες.

**Η περικοπή αλλάζει τα υποκείμενα δεδομένα ήχου που είναι αποθηκευμένα στην παρουσίαση;**

Όχι. Η περικοπή προσαρμόζει μόνο τα όρια αναπαραγωγής. Τα αρχικά byte του ήχου παραμένουν άθραυστα και προσβάσιμα μέσω του ενσωματωμένου ήχου ή της συλλογής ήχου της παρουσίασης.