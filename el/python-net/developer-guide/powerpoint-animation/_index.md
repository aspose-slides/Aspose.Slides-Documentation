---
title: Βελτιώστε τις παρουσιάσεις PowerPoint με κινήσεις σε Python
linktitle: Κίνηση PowerPoint
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
description: "Εξερευνήστε τις δυνατότητες του Aspose.Slides για Python via .NET στην διαχείριση κινήσεων PowerPoint. Αυτή η γενική επισκόπηση αναδεικνύει βασικά χαρακτηριστικά και προσφέρει ιδέες για τη βελτίωση των παρουσιάσεών σας."
---
## **Εισαγωγή**

Οι παρουσιάσεις σχεδιάζονται για να μεταφέρουν πληροφορίες, επομένως η οπτική εμφάνιση και η διαδραστική συμπεριφορά τους είναι βασικές παραμέτρους κατά τη δημιουργία.

**PowerPoint animation** παίζει σημαντικό ρόλο στο να κάνει μια παρουσίαση ελκυστική και ενδιαφέρουσα για το κοινό. Το Aspose.Slides for Python via .NET παρέχει μια ευρεία γκάμα επιλογών για την προσθήκη κινήσεων σε μια παρουσίαση PowerPoint. Μπορείτε:

- Εφαρμόστε διάφορα εφέ κίνησης σε σχήματα, διαγράμματα, πίνακες, αντικείμενα OLE και άλλα στοιχεία.
- Χρησιμοποιήστε πολλαπλά εφέ κίνησης σε ένα μόνο σχήμα.
- Ελέγξτε τα εφέ μέσω της γραμμής χρόνου της κίνησης.
- Δημιουργήστε προσαρμοσμένες κινήσεις.

Στο Aspose.Slides for Python via .NET, τα εφέ κίνησης μπορούν να εφαρμοστούν σε σχήματα. Επειδή κάθε στοιχείο σε μια διαφάνεια —συμπεριλαμβανομένου του κειμένου, των εικόνων, των αντικειμένων OLE και των πινάκων—θεωρείται σχήμα, μπορείτε να εφαρμόσετε εφέ κίνησης σε οποιοδήποτε στοιχείο της διαφάνειας.

Ο χώρος ονομάτων [aspose.slides.animation](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/) παρέχει τις κλάσεις για εργασία με κινήσεις PowerPoint.

## **Εγκατάσταση**

```bash
pip install aspose.slides
```

## **Προσθήκη εφέ κίνησης σε σχήμα με Python**

Τα εφέ κίνησης βρίσκονται στην κύρια ακολουθία μιας διαφάνειας. Προσθέστε ένα σχήμα, στη συνέχεια καλέστε `add_effect` στο `slide.timeline.main_sequence`, περνώντας τον τύπο του εφέ, το υποτύπο του και το trigger που το ενεργοποιεί.

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

Το αποθηκευμένο αρχείο περιέχει ένα εφέ στην πρώτη διαφάνεια: το ορθογώνιο εμφανίζεται από τα αριστερά σε διάρκεια δύο δευτερολέπτων όταν ο παρουσιαστής κάνει κλικ. Επανανοίγοντας το και διαβάζοντας `slide.timeline.main_sequence` επιστρέφεται αυτό το εφέ, έτσι η κίνηση παραμένει μετά τη αποθήκευση αντί να υπάρχει μόνο στη μνήμη.

## **Εφέ κίνησης**

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

## **Προσαρμοσμένη κίνηση**

Για πλήρη παραδείγματα Python που δημιουργούν, επιθεωρούν και τροποποιούν συμπεριφορές και επεξεργάσιμες διαδρομές κίνησης, δείτε [Προσαρμοσμένη κίνηση](/slides/el/python-net/custom-animation/).

Μπορείτε να δημιουργήσετε τις δικές σας **προσαρμοσμένες κινήσεις** στο Aspose.Slides συνδυάζοντας πολλαπλές συμπεριφορές σε ένα ενιαίο εφέ.

[Behavior](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/behavior/) είναι ένα δομικό στοιχείο ενός εφέ κίνησης PowerPoint. Συνδυάστε συμπεριφορές για να προσαρμόσετε ένα εφέ ή προσθέστε μια συμπεριφορά για να επεκτείνετε ένα προκαθορισμένο εφέ. Η επανάληψη ρυθμίζεται μέσω των ρυθμίσεων χρονισμού αντί για ξεχωριστή συμπεριφορά επανάληψης.

[Animation Point](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/point/) υποδεικνύει τη στιγμή ή τη θέση κατά την οποία εφαρμόζεται μια συμπεριφορά (ένα keyframe).

## **Γραμμή χρόνου κίνησης**

[Sequence](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/sequence/) είναι μια συλλογή εφέ κίνησης που μπορούν να στοχεύσουν διαφορετικά σχήματα.

[Timeline](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/animationtimeline/) είναι το σύνολο των ακολουθιών που χρησιμοποιείται σε μια συγκεκριμένη διαφάνεια. Εισήχθη στο PowerPoint 2002. Σε παλαιότερες εκδόσεις του PowerPoint, η προσθήκη εφέ κίνησης ήταν δύσκολη και συχνά απαιτούσε παρακάμψεις. Η Timeline αντικαθιστά την παλιά κλάση `AnimationSettings` και παρέχει ένα πιο σαφές αντικειμενοστραφές μοντέλο για τις κινήσεις PowerPoint. Κάθε διαφάνεια μπορεί να έχει μόνο μια γραμμή χρόνου κίνησης.

## **Διαδραστική κίνηση**

[Trigger](https://reference.aspose.com/slides/el/python-net/aspose.slides.animation/effecttriggertype/) σάς επιτρέπει να ορίσετε ενέργειες χρήστη (π.χ., κλικ σε κουμπί) που ξεκινούν μια συγκεκριμένη κίνηση. Τα triggers προστέθηκαν μόνο στις πιο πρόσφατες εκδόσεις του PowerPoint.

## **Κίνηση σχήματος**

Το Aspose.Slides σας επιτρέπει να εφαρμόζετε κινήσεις σε σχήματα —όπως κείμενο, ορθογώνια, γραμμές, πλαίσια, αντικείμενα OLE και άλλα.

{{% alert color="info" title="Note" %}}
Διαβάστε περισσότερα [**Σχετικά με την κίνηση σχήματος**](/slides/el/python-net/shape-animation/).
{{% /alert %}}

## **Κινούμενα διαγράμματα**

Για τη δημιουργία κινούμενων διαγραμμάτων, χρησιμοποιήστε τις ίδιες κλάσεις όπως για τα σχήματα. Ωστόσο, οι κινήσεις PowerPoint μπορούν να εφαρμοστούν μόνο σε κατηγορίες διαγράμματος ή σειρές διαγράμματος. Μπορείτε επίσης να εφαρμόσετε ένα εφέ κίνησης σε μεμονωμένο στοιχείο κατηγορίας ή σε στοιχείο σειράς.

{{% alert color="info" title="Note" %}}
Διαβάστε περισσότερα [**Σχετικά με τα κινούμενα διαγράμματα**](/slides/el/python-net/animated-charts/).
{{% /alert %}}

## **Κινούμενο κείμενο**

Εκτός από την κίνηση κειμένου, μπορείτε να εφαρμόσετε κίνηση σε μια παράγραφο.

{{% alert color="info" title="Note" %}}
Διαβάστε περισσότερα [**Σχετικά με το κινούμενο κείμενο**](/slides/el/python-net/animated-text/).
{{% /alert %}}

## **Συχνές ερωτήσεις**

**Θα διατηρηθούν οι κινήσεις κατά την εξαγωγή σε PDF;**

Όχι. Το PDF είναι μορφή στατική, έτσι οι κινήσεις και οι [slide transitions](/slides/el/python-net/slide-transition/) δεν αναπαράγονται. Εάν χρειάζεστε κίνηση, εξάγετε σε [HTML5](/slides/el/python-net/export-to-html5/), [animated GIF](/slides/el/python-net/convert-powerpoint-to-animated-gif/), ή [video](/slides/el/python-net/convert-powerpoint-to-video/) αντί.

**Μπορώ να μετατρέψω μια κινούμενη παρουσίαση σε βίντεο και να ελέγξω τον ρυθμό καρέ και το μέγεθος του καρέ;**

Ναι. Μπορείτε να [render the presentation as frames](/slides/el/python-net/convert-powerpoint-to-video/) και να τα κωδικοποιήσετε σε βίντεο (π.χ., μέσω ffmpeg), επιλέγοντας τα FPS και την ανάλυση. Οι κινήσεις και οι μεταβάσεις διαφανειών αναπαράγονται κατά τη διαδικασία rendering.

**Θα παραμείνουν οι κινήσεις ανέπαφες όταν δουλεύετε με ODP (όχι μόνο PPTX);**

Τα PPT, PPTX και ODP υποστηρίζονται για [reading](/slides/el/python-net/open-presentation/) και [writing](/slides/el/python-net/save-presentation/), αλλά αυτό δεν εγγυάται τη διατήρηση των κινήσεων. Τα προσαρμοσμένα δεδομένα κίνησης μπορεί να χαθούν κατά τη μετατροπή σε ODP. Δείτε το [Custom Animation](/slides/el/python-net/custom-animation/) για παραδείγματα και οδηγίες σχετικά με τον έλεγχο συμβατότητας μορφής.