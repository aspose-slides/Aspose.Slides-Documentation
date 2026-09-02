---
title: "Βελτιώστε τις παρουσιάσεις PowerPoint με κινήσεις σε Python"
linktitle: "Κίνηση PowerPoint"
type: docs
weight: 150
url: /el/python-net/powerpoint-animation/
keywords:
- προσθήκη κίνησης
- ενημέρωση κίνησης
- αλλαγή κίνησης
- αφαίρεση κίνησης
- διαχείριση κίνησης
- έλεγχος κίνησης
- εφέ κίνησης
- κίνηση PowerPoint
- γραμμή χρόνου κίνησης
- διαδραστική κίνηση
- προσαρμοσμένη κίνηση
- κίνηση σχήματος
- κινούμενο διάγραμμα
- κινούμενο κείμενο
- κινούμενο σχήμα
- κινούμενο αντικείμενο OLE
- κινούμενη εικόνα
- κινούμενος πίνακας
- παρουσίαση PowerPoint
- Python
- Aspose.Slides
description: "Εξερευνήστε τις δυνατότητες του Aspose.Slides for Python μέσω .NET στη διαχείριση κινήσεων PowerPoint. Αυτή η γενική επισκόπηση επισημαίνει βασικά χαρακτηριστικά και προσφέρει πληροφορίες για τη βελτίωση των παρουσιάσεών σας."
---
## **Εισαγωγή**

Οι παρουσιάσεις σχεδιάζονται για τη μετάδοση πληροφοριών, γι' αυτό η οπτική εμφάνιση και η διαδραστική τους συμπεριφορά είναι βασικές πτυχές κατά τη δημιουργία.

**PowerPoint animation** παίζει σημαντικό ρόλο στο να κάνει μια παρουσίαση ελκυστική και δελεαστική για το κοινό. Το Aspose.Slides for Python μέσω .NET παρέχει ένα ευρύ φάσμα επιλογών για την προσθήκη κίνησης σε παρουσίαση PowerPoint. Μπορείτε να:

- Εφαρμόζετε διάφορα εφέ κίνησης σε σχήματα, διαγράμματα, πίνακες, αντικείμενα OLE και άλλα στοιχεία.
- Χρησιμοποιείτε πολλαπλά εφέ κίνησης σε ένα μόνο σχήμα.
- Ελέγχετε τα εφέ μέσω της γραμμής χρόνου κίνησης.
- Δημιουργείτε προσαρμοσμένες κινήσεις.

Στο Aspose.Slides for Python μέσω .NET, τα εφέ κίνησης μπορούν να εφαρμοστούν σε σχήματα. Δεδομένου ότι κάθε στοιχείο σε μια διαφάνεια—συμπεριλαμβανομένου κειμένου, εικόνων, αντικειμένων OLE και πινάκων—θεωρείται σχήμα, μπορείτε να εφαρμόσετε εφέ κίνησης σε οποιοδήποτε στοιχείο της διαφάνειας.

Το namespace [aspose.slides.animation](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/) παρέχει τις κλάσεις για εργασία με κινήσεις PowerPoint.

## **Εγκατάσταση**

```bash
pip install aspose.slides
```

## **Προσθήκη Εφέ Κίνησης σε Σχήμα με Python**

Τα εφέ κίνησης βρίσκονται στη κύρια ακολουθία μιας διαφάνειας. Προσθέστε ένα σχήμα, στη συνέχεια καλέστε `add_effect` στο `slide.timeline.main_sequence`, περνώντας τον τύπο του εφέ, το υποτύπο του και τον ενεργοποιητή που το ξεκινά.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 100)
    shape.text_frame.text = "Animated shape"

    sequence = slide.timeline.main_sequence
    effect = sequence.add_effect(
        shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.LEFT,
        slides.animation.EffectTriggerType.ON_CLICK,
    )
    effect.timing.duration = 2.0

    presentation.save("animated.pptx", slides.export.SaveFormat.PPTX)
```

Το αποθηκευμένο αρχείο περιέχει ένα εφέ στην πρώτη διαφάνεια: το ορθογώνιο εισέρχεται από τα αριστερά σε δύο δευτερόλεπτα όταν ο παρουσιαστής κάνει κλικ. Επαναφέροντάς το και διαβάζοντας `slide.timeline.main_sequence` λαμβάνεται αυτό το εφέ, έτσι η κίνηση επιβιώνει στο round‑trip και δεν υπάρχει μόνο στη μνήμη.

## **Εφέ Κίνησης**

Το Aspose.Slides υποστηρίζει **πάνω από 150 εφέ κίνησης**, συμπεριλαμβανομένων βασικών εφέ όπως Bounce, PathFootball και Zoom, καθώς και εξειδικευμένων εφέ όπως OLEObjectShow και OLEObjectOpen. Μπορείτε να βρείτε την πλήρη λίστα στην απαρίθμηση [EffectType](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/effecttype/).

Επιπλέον, αυτά τα εφέ κίνησης μπορούν να συνδυαστούν με τα ακόλουθα εφέ:

- [ColorEffect](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/seteffect/)

## **Προσαρμοσμένη Κίνηση**

Μπορείτε να δημιουργήσετε τις δικές σας **προσαρμοσμένες κινήσεις** στο Aspose.Slides συνδυάζοντας πολλαπλές συμπεριφορές σε ένα εφέ.

[Behavior](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/behavior/) είναι το βασικό δομικό στοιχείο κάθε εφέ κίνησης PowerPoint. Κάθε εφέ κίνησης αποτελεί ουσιαστικά ένα σύνολο συμπεριφορών που τοποθετούνται σε μια στρατηγική ή γραμμή χρόνου. Μπορείτε να συναρμολογήσετε συμπεριφορές σε μια προσαρμοσμένη κίνηση μία φορά και να την επαναχρησιμοποιήσετε σε άλλες παρουσιάσεις. Εάν προσθέσετε μια νέα συμπεριφορά σε ένα τυπικό εφέ κίνησης PowerPoint, αυτή γίνεται προσαρμοσμένη κίνηση — για παράδειγμα, προσθέτοντας μια συμπεριφορά επανάληψης για να παίζει η κίνηση πολλές φορές.

[Animation Point](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/point/) καθορίζει τη στιγμή ή θέση όπου εφαρμόζεται μια συμπεριφορά (ένα keyframe).

## **Γραμμή Χρόνου Κίνησης**

[Sequence](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/sequence/) είναι μια συλλογή εφέ κίνησης που εφαρμόζονται σε ένα συγκεκριμένο σχήμα.

[Timeline](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/animationtimeline/) είναι το σύνολο των ακολουθιών που χρησιμοποιούνται σε μια συγκεκριμένη διαφάνεια. Εισήχθη στο PowerPoint 2002. Σε προηγούμενες εκδόσεις του PowerPoint, η προσθήκη εφέ κίνησης ήταν δύσκολη και συχνά απαιτούσε παραϲοδικές λύσεις. Η Timeline αντικαθιστά την παλιά κλάση `AnimationSettings` και παρέχει ένα πιο σαφές αντικειμενικό μοντέλο για τις κινήσεις PowerPoint. Κάθε διαφάνεια μπορεί να έχει μόνο μία γραμμή χρόνου κίνησης.

## **Διαδραστική Κίνηση**

[Trigger](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/effecttriggertype/) σας επιτρέπει να ορίσετε ενέργειες χρήστη (π.χ., κλικ σε κουμπί) που ξεκινούν μια συγκεκριμένη κίνηση. Οι Trigger προστέθηκαν μόνο στις πιο πρόσφατες εκδόσεις του PowerPoint.

## **Κίνηση Σχημάτων**

Το Aspose.Slides σας επιτρέπει να εφαρμόζετε κινήσεις σε σχήματα—όπως κείμενο, ορθογώνια, γραμμές, πλαίσια, αντικείμενα OLE και άλλα.

{{% alert color="primary" %}}
Διαβάστε περισσότερα [**Σχετικά με την Κίνηση Σχημάτων**](/slides/el/python-net/shape-animation/).
{{% /alert %}}

## **Διαδραστικά Διαγράμματα**

Για να δημιουργήσετε κινούμενα διαγράμματα, χρησιμοποιήστε τις ίδιες κλάσεις όπως για τα σχήματα. Ωστόσο, οι κινήσεις PowerPoint μπορούν να εφαρμοστούν μόνο σε κατηγορίες διαγράμματος ή σε σειρές διαγράμματος. Μπορείτε επίσης να εφαρμόσετε ένα εφέ κίνησης σε ένα μεμονωμένο στοιχείο κατηγορίας ή στοιχείο σειράς.

{{% alert color="primary" %}}
Διαβάστε περισσότερα [**Σχετικά με τα Κινούμενα Διαγράμματα**](/slides/el/python-net/animated-charts/).
{{% /alert %}}

## **Κινούμενο κείμενο**

Εκτός από την κίνηση κειμένου, μπορείτε να εφαρμόσετε κίνηση σε μια παράγραφο.

{{% alert color="primary" %}}
Διαβάστε περισσότερα [**Σχετικά με το Κινούμενο Κείμενο**](/slides/el/python-net/animated-text/).
{{% /alert %}}

## **Συχνές ερωτήσεις**

### Θα διατηρηθούν οι κινήσεις κατά την εξαγωγή σε PDF;

Όχι. το PDF είναι μορφή στατική, επομένως οι κινήσεις και οι [μεταβάσεις διαφανειών](/slides/el/python-net/slide-transition/) δεν αναπαράγονται. Εάν χρειάζεστε κίνηση, εξάγετε σε [HTML5](/slides/el/python-net/export-to-html5/), [animated GIF](/slides/el/python-net/convert-powerpoint-to-animated-gif/), ή [video](/slides/el/python-net/convert-powerpoint-to-video/) αντί αυτού.

### Μπορώ να μετατρέψω μια κινούμενη παρουσίαση σε βίντεο και να ελέγξω το ρυθμό καρέ και το μέγεθος καρέ;

Ναι. Μπορείτε να [αποδώσετε την παρουσίαση ως καρέ](/slides/el/python-net/convert-powerpoint-to-video/) και να τα κωδικοποιήσετε σε βίντεο (π.χ., μέσω ffmpeg), επιλέγοντας τα FPS και την ανάλυση. Οι κινήσεις και οι μεταβάσεις διαφανειών αναπαράγονται κατά την απόδοση.

### Θα παραμείνουν οι κινήσεις αμετάβλητες όταν εργάζεστε με ODP (όχι μόνο PPTX);

Τα PPT, PPTX και ODP υποστηρίζονται για [ανάγνωση](/slides/el/python-net/open-presentation/) και [εγγραφή](/slides/el/python-net/save-presentation/), αλλά οι διαφορές μορφής σημαίνουν ότι ορισμένα εφέ μπορεί να φαίνονται ή να συμπεριφέρονται ελαφρώς διαφορετικά. Επικυρώστε κρίσιμες περιπτώσεις με πραγματικά δείγματα.