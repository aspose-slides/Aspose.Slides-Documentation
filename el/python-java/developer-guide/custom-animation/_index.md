---
title: Δημιουργία και Τροποποίηση Προσαρμοσμένων Συμπεριφορών Κίνησης σε Python μέσω Java
linktitle: Προσαρμοσμένη Κίνηση
type: docs
weight: 151
url: /el/python-java/custom-animation/
keywords:
- προσαρμοσμένη κίνηση
- συμπεριφορά κίνησης
- διαδρομή κίνησης
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Δημιουργήστε, επιθεωρήστε και τροποποιήστε προσαρμοσμένες συμπεριφορές κίνησης και επεξεργάσιμες διαδρομές κίνησης σε παρουσιάσεις PowerPoint με το Aspose.Slides για Python μέσω Java."
---
## **Επισκόπηση**

Οι προσαρμοσμένες συμπεριφορές κίνησης σάς επιτρέπουν να ελέγχετε επιμέρους λειτουργίες εντός ενός εφέ κίνησης, όπως η αλλαγή χρώματος, η περιστροφή σχήματος ή η παρακολούθηση μιας επεξεργάσιμης διαδρομής κίνησης. Αυτός ο οδηγός δείχνει πώς να δημιουργήσετε και να συνδυάσετε συμπεριφορές, να ρυθμίσετε το χρόνο τους, να εξετάσετε και να τροποποιήσετε υπάρχουσες κινήσεις και να επαληθεύσετε ότι οι ιδιότητές τους διατηρούνται μετά την αποθήκευση και την επαναφόρτωση μιας παρουσίασης.

For predefined effects and click triggers, see [Κίνηση Σχήματος](/slides/el/python-java/shape-animation/).

## **Κατανόηση του Μοντέλου Κίνησης**

Μια κίνηση οργανώνεται ως **Timeline → Sequence → Effect → Behaviors**:

- Η μέθοδος [getTimeline](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseslide/#getTimeline) επιστρέφει τη χρονική γραμμή της διαφάνειας, η οποία περιέχει την κύρια ακολουθία της και τις διαδραστικές ακολουθίες.
- Η [Sequence](https://reference.aspose.com/slides/el/python-java/aspose.slides/sequence/) περιέχει εφέ, ενδεχομένως με διαφορετικά σχήματα-στόχους.
- Ένα [Effect](https://reference.aspose.com/slides/el/python-java/aspose.slides/effect/) προσδιορίζει ένα σχήμα-στόχο, μια προεπιλογή, έναν υποτύπο και το χρόνο του εφέ.
- Η συλλογή που επιστρέφει η [Effect.getBehaviors](https://reference.aspose.com/slides/el/python-java/aspose.slides/effect/#getBehaviors) περιέχει τις λειτουργίες που υλοποιούν το εφέ: αλλαγή χρώματος, μετακίνηση, περιστροφή, ορισμός ιδιότητας κλπ.

## **Δημιουργία Ατομικών Συμπεριφορών**

Καλέστε τη [Sequence.addEffect](https://reference.aspose.com/slides/el/python-java/aspose.slides/sequence/#addEffect) για να δημιουργήσετε ένα εφέ και να έχετε πρόσβαση στη συλλογή [getBehaviors](https://reference.aspose.com/slides/el/python-java/aspose.slides/effect/#getBehaviors). Μια προεπιλογή μπορεί να γεμίσει αυτόματα τη συλλογή. Διατηρήστε τις λειτουργίες της όταν επεκτείνετε την προεπιλογή ή χρησιμοποιήστε το [clear](https://reference.aspose.com/slides/el/python-java/aspose.slides/behaviorcollection/#clear) όταν θέλετε να τις αντικαταστήσετε σκόπιμα.

### **Περιστροφή**

Χρησιμοποιήστε το [createRotationEffect](https://reference.aspose.com/slides/el/python-java/aspose.slides/behaviorfactory/#createRotationEffect) για να δημιουργήσετε μια περιστροφή. Η [getBy](https://reference.aspose.com/slides/el/python-java/aspose.slides/rotationeffect/#getBy) ορίζει μια σχετική γωνία σε μοίρες· οι [getFrom](https://reference.aspose.com/slides/el/python-java/aspose.slides/rotationeffect/#getFrom) και [getTo](https://reference.aspose.com/slides/el/python-java/aspose.slides/rotationeffect/#getTo) ορίζουν τα άκρα.

Το παράδειγμα ξεκινά με εφέ Spin, αντικαθιστά τις λειτουργίες της προεπιλογής του με μία συμπεριφορά περιστροφής και δίνει σε αυτήν διάρκεια δύο δευτερολέπτων. Μια σχετική γωνία 90 μοιρών εκφράζει τέταρτο γύρο από την αρχική προσανατολισμό του σχήματος, οπότε δεν απαιτείται ρητή αρχική γωνία.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Spin, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    rotation = factory.createRotationEffect()
    rotation.setBy(90)
    rotation.getTiming().setDuration(2)

    effect.getBehaviors().add(rotation)

    presentation.save("rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`rotation.pptx` περιέχει ένα σχήμα και μια συμπεριφορά περιστροφής. Η συλλογή, ο χρόνος και τα παραδείγματα επεξεργασίας περιστροφής παρακάτω χρησιμοποιούν αυτό το αρχείο.

### **Κλιμάκωση**

Χρησιμοποιήστε το [createScaleEffect](https://reference.aspose.com/slides/el/python-java/aspose.slides/behaviorfactory/#createScaleEffect) με ποσοστά X/Y: οι [getFrom](https://reference.aspose.com/slides/el/python-java/aspose.slides/scaleeffect/#getFrom) και [getTo](https://reference.aspose.com/slides/el/python-java/aspose.slides/scaleeffect/#getTo) περιγράφουν το αρχικό και το τελικό μέγεθος, ενώ η [getBy](https://reference.aspose.com/slides/el/python-java/aspose.slides/scaleeffect/#getBy) περιγράφει μια σχετική αλλαγή. Εδώ, 100 σημαίνει το αρχικό μέγεθος.

Το παράδειγμα αυξάνει και τις δύο διαστάσεις από 100 % σε 125 % σε δύο δευτερόλεπτα. Η χρήση ίδιων οριζόντιων και κάθετων ποσοστών διατηρεί τις αναλογίες του σχήματος· διαφορετικά ποσοστά θα τεντώσουν τη μία διάσταση περισσότερο από την άλλη.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    scale = factory.createScaleEffect()
    scale.setFrom(Point2DFloat(100, 100))
    scale.setTo(Point2DFloat(125, 125))
    scale.getTiming().setDuration(2)

    effect.getBehaviors().add(scale)

    presentation.save("scale.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Χρώμα**

Χρησιμοποιήστε το [createColorEffect](https://reference.aspose.com/slides/el/python-java/aspose.slides/behaviorfactory/#createColorEffect) για να αλλάξετε το γέμισμα από μπλε σε πορτοκαλί. Οι [getFrom](https://reference.aspose.com/slides/el/python-java/aspose.slides/coloreffect/#getFrom) και [getTo](https://reference.aspose.com/slides/el/python-java/aspose.slides/coloreffect/#getTo) είναι χρώματα· η [getBy](https://reference.aspose.com/slides/el/python-java/aspose.slides/coloreffect/#getBy) είναι μετατόπιση χρώματος. Η [Behavior.getProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/behavior/#getProperties) προσδιορίζει το χαρακτηριστικό που κινείται.

Το γεμάτο του σχήματος αρχικοποιείται σε μπλε, ταιριάζοντας με το αρχικό χρώμα της κίνησης. Η επιλογή του χαρακτηριστικού γεμίσματος λέει στη συμπεριφορά ποιο τμήμα του σχήματος να αλλάξει· τα άκρα των χρωμάτων από μόνα τους δεν προσδιορίζουν το χαρακτηριστικό. Το αποθηκευμένο εφέ περιγράφει μια μετάβαση δύο δευτερολέπτων σε πορτοκαλί.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, FillType, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    color = factory.createColorEffect()
    color.getProperties().add(BehaviorProperty.getFillColor().getValue())
    color.getFrom().setColor(Color.BLUE)
    color.getTo().setColor(Color(255, 165, 0))
    color.getTiming().setDuration(2)

    effect.getBehaviors().add(color)

    presentation.save("color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Φίλτρο**

Χρησιμοποιήστε το [createFilterEffect](https://reference.aspose.com/slides/el/python-java/aspose.slides/behaviorfactory/#createFilterEffect) για να επιλέξετε ένα ξέσπασμα. Οι [getType](https://reference.aspose.com/slides/el/python-java/aspose.slides/filtereffect/#getType), [getSubtype](https://reference.aspose.com/slides/el/python-java/aspose.slides/filtereffect/#getSubtype) και [getReveal](https://reference.aspose.com/slides/el/python-java/aspose.slides/filtereffect/#getReveal) καθορίζουν το φίλτρο, την κατεύθυνση και το αν αποκαλύπτεται ή κρύβεται το σχήμα.

Αυτό το παράδειγμα ρυθμίζει ένα ξέσπασμα δύο δευτερολέπτων που αποκαλύπτει το σχήμα χρησιμοποιώντας τον υποτύπο δεξιάς κατεύθυνσης. Οι ρυθμίσεις του φίλτρου ανήκουν στη συμπεριφορά μέσα στο εφέ, έτσι ρυθμίζονται αφού έχουν αφαιρεθεί οι αρχικές λειτουργίες της προεπιλογής.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, FilterEffectRevealType, FilterEffectSubtype, FilterEffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Wipe, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    filter = factory.createFilterEffect()
    filter.setType(FilterEffectType.Wipe)
    filter.setSubtype(FilterEffectSubtype.Right)
    filter.setReveal(FilterEffectRevealType.In)
    filter.getTiming().setDuration(2)

    effect.getBehaviors().add(filter)

    presentation.save("filter.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Ιδιότητα**

Χρησιμοποιήστε το [createPropertyEffect](https://reference.aspose.com/slides/el/python-java/aspose.slides/behaviorfactory/#createPropertyEffect) για να κινήσετε τη διαφάνεια. Οι [getFrom](https://reference.aspose.com/slides/el/python-java/aspose.slides/propertyeffect/#getFrom), [getTo](https://reference.aspose.com/slides/el/python-java/aspose.slides/propertyeffect/#getTo) και [getBy](https://reference.aspose.com/slides/el/python-java/aspose.slides/propertyeffect/#getBy) είναι συμβολοσειρές που ερμηνεύονται με τη [getValueType](https://reference.aspose.com/slides/el/python-java/aspose.slides/propertyeffect/#getValueType) και τη [getCalcMode](https://reference.aspose.com/slides/el/python-java/aspose.slides/propertyeffect/#getCalcMode). Επιλέξτε άκρα ή σχετική μετατόπιση αντί να θέσετε και τις τρεις τιμές αδιάφορα.

Εδώ, το επιλεγμένο χαρακτηριστικό είναι η διαφάνεια, και οι αριθμητικές συμβολοσειρές αντιπροσωπεύουν αλλαγή από 25 % διαφάνειας σε πλήρη διαφάνεια. Η γραμμική παρεμβολή περιγράφει μια βαθμιαία μεταβολή μεταξύ αυτών των τιμών. Όταν προσαρμόζετε αυτό το παράδειγμα σε άλλο χαρακτηριστικό, επιλέξτε τύπο τιμής και τιμές άκρων κατάλληλες για εκείνο το χαρακτηριστικό.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, Presentation, PropertyCalcModeType, PropertyValueType, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    property = factory.createPropertyEffect()
    property.getProperties().add(BehaviorProperty.getStyleOpacity().getValue())
    property.setValueType(PropertyValueType.Number)
    property.setCalcMode(PropertyCalcModeType.Linear)
    property.setFrom("0.25")
    property.setTo("1")
    property.getTiming().setDuration(2)

    effect.getBehaviors().add(property)

    presentation.save("property.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Ορισμός**

Χρησιμοποιήστε το [createSetEffect](https://reference.aspose.com/slides/el/python-java/aspose.slides/behaviorfactory/#createSetEffect) για να ορίσετε την ορατότητα μέσω της [getTo](https://reference.aspose.com/slides/el/python-java/aspose.slides/seteffect/#getTo). Μια συμπεριφορά set δεν παρεμβάλλεται μεταξύ των άκρων.

Το παράδειγμα επιλέγει το χαρακτηριστικό ορατότητας και αντιστοιχίζει τη συμβολοσειρά `visible` όταν εκτελείται η συμπεριφορά. Το ορθογώνιο είναι ήδη ορατό σε αυτήν την ελάχιστη παρουσίαση, οπότε η αντιστοίχηση μπορεί να μην παράγει εμφανή οπτική αλλαγή μόνη της. Τέτοια λειτουργία είναι χρήσιμη ως μέρος ενός μεγαλύτερου εφέ που ελέγχει επίσης πότε το σχήμα κρύβεται ή εμφανίζεται.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    set = factory.createSetEffect()
    set.getProperties().add(BehaviorProperty.getStyleVisibility().getValue())
    set.setTo("visible")

    effect.getBehaviors().add(set)

    presentation.save("set.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Εντολή**

Χρησιμοποιήστε το [createCommandEffect](https://reference.aspose.com/slides/el/python-java/aspose.slides/behaviorfactory/#createCommandEffect) και ρυθμίστε τις [getType](https://reference.aspose.com/slides/el/python-java/aspose.slides/commandeffect/#getType), [getCommandString](https://reference.aspose.com/slides/el/python-java/aspose.slides/commandeffect/#getCommandString) και [getShapeTarget](https://reference.aspose.com/slides/el/python-java/aspose.slides/commandeffect/#getShapeTarget). Τοποθετήστε μια ηχογραφημένη WAV με όνομα `sample.wav` στον τρέχοντα φάκελο. Αυτό το παράδειγμα την ενσωματώνει με το [addAudioFrameEmbedded](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) και προσθέτει μια εντολή αναπαραγωγής στο ηχητικό πλαίσιο.

Το ηχητικό πλαίσιο είναι τόσο ο στόχος του εφέ όσο και ο στόχος της εντολής. Αυτό συνδέει το αίτημα αναπαραγωγής με την ενσωματωμένη ηχογράφηση· μια εντολή από μόνη της δεν προσδιορίζει ποιο αντικείμενο πολυμέσου θα ελεγχθεί. Το εφέ ρυθμίζεται να ξεκινά με κλικ κατά τη διάρκεια της παρουσίασης.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path

from asposeslides.api import BehaviorFactory, CommandEffectType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    audio_data = Path("sample.wav").read_bytes()
    audio_bytes = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(audio_bytes)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audio)

    effect = slide.getTimeline().getMainSequence().addEffect(audio_frame, EffectType.MediaPlay, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    command = factory.createCommandEffect()
    command.setType(CommandEffectType.Call)
    command.setCommandString("play")
    command.setShapeTarget(audio_frame)

    effect.getBehaviors().add(command)

    presentation.save("command.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Η αποθήκευση αποθηκεύει την εντολή στο `command.pptx`; δεν αναπαράγει την ηχογράφηση. Η αναπαραγωγή απαιτεί πρόγραμμα παρουσίασης που υποστηρίζει την εντολή και το στόχο πολυμέσου της.

## **Διαχείριση της Συλλογής Συμπεριφορών**

Η [BehaviorCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/behaviorcollection/) υποστηρίζει τα [add](https://reference.aspose.com/slides/el/python-java/aspose.slides/behaviorcollection/#add), [insert](https://reference.aspose.com/slides/el/python-java/aspose.slides/behaviorcollection/#insert), [remove](https://reference.aspose.com/slides/el/python-java/aspose.slides/behaviorcollection/#remove) και [removeAt](https://reference.aspose.com/slides/el/python-java/aspose.slides/behaviorcollection/#removeAt). Αυτό το παράδειγμα ανοίγει το `rotation.pptx`, προσθέτει κλιμάκωση, τη μετακινεί πριν από την περιστροφή και αφαιρεί την περιστροφή. Η αφαίρεση και η επανεισαγωγή του ίδιου αντικειμένου αλλάζουν τη θέση του στην αποθήκευση χωρίς να δημιουργείται αντίγραφο.

Η σειρά των επεξεργασιών αλλάζει τη συλλογή από περιστροφή–κλιμάκωση σε κλιμάκωση–περιστροφή, και στη συνέχεια σε μόνο κλιμάκωση. Οι δείκτες αναφέρονται στη τρέχουσα συλλογή, έτσι η αφαίρεση χρησιμοποιεί το νέο δείκτη της περιστροφής μετά την αναδιάταξη. Η τελική απαρίθμηση επιβεβαιώνει ποια συμπεριφορά θα αποθηκευτεί.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    behaviors = effect.getBehaviors()

    factory = BehaviorFactory()
    scale = factory.createScaleEffect()
    scale.setTo(Point2DFloat(125, 125))
    scale.getTiming().setDuration(2)

    behaviors.add(scale)

    behaviors.remove(scale)
    behaviors.insert(0, scale)
    behaviors.removeAt(1)

    for behavior in behaviors:
        print(behavior.getClass().getSimpleName())

    presentation.save("collection-edited.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα είναι `ScaleEffect`: απομένει μόνο η κλιμάκωση. Η σειρά στη συλλογή από μόνη της δεν προγραμματίζει τις συμπεριφορές η μία μετά την άλλη. Απομακρύνετε τη συλλογή μόνο όταν αντικαθιστάτε όλες τις λειτουργίες της.

## **Ρύθμιση Χρόνου Συμπεριφοράς**

Η [Behavior.getTiming](https://reference.aspose.com/slides/el/python-java/aspose.slides/behavior/#getTiming) εκθέτει το [Timing](https://reference.aspose.com/slides/el/python-java/aspose.slides/timing/), ανεξάρτητα από το [Effect.getTiming](https://reference.aspose.com/slides/el/python-java/aspose.slides/effect/#getTiming). Ο χρόνος του εφέ προγραμματίζει το περιβάλλον εφέ· ο χρόνος της συμπεριφοράς περιγράφει μια λειτουργία εντός αυτού.

### **Ορισμός Διάρκειας, Καθυστέρησης, Επανάληψης και Επιτάχυνσης**

Ανοίξτε το `rotation.pptx` και ορίστε τη διάρκεια ([getDuration](https://reference.aspose.com/slides/el/python-java/aspose.slides/timing/#getDuration)) και την καθυστέρηση ενεργοποίησης ([getTriggerDelayTime](https://reference.aspose.com/slides/el/python-java/aspose.slides/timing/#getTriggerDelayTime)) σε δευτερόλεπτα, έπειτα ρυθμίστε τον αριθμό επαναλήψεων μέσω του [setRepeatCount](https://reference.aspose.com/slides/el/python-java/aspose.slides/timing/#setRepeatCount). Οι [getAccelerate](https://reference.aspose.com/slides/el/python-java/aspose.slides/timing/#getAccelerate) και [getDecelerate](https://reference.aspose.com/slides/el/python-java/aspose.slides/timing/#getDecelerate) είναι κλάσματα της διάρκειας· κρατήστε το άθροισμά τους το πολύ 1.

Το αρχείο εισόδου είναι το αρχείο που δημιουργήθηκε στο παράδειγμα περιστροφής, όπου η πρώτη συμπεριφορά είναι γνωστή ως περιστροφή. Αυτό το παράδειγμα αλλάζει μόνο το χρονοπρογραμματισμό αυτής της συμπεριφοράς· η γωνία των 90 μοιρών παραμένει αμετάβλητη. Η διαχωριστική διαχείριση γωνίας και χρόνου κάνει πιο εύκολη τη ρύθμιση του ρυθμού χωρίς επανέκτιση της κίνησης.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RotationEffect, SaveFormat

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    rotation = effect.getBehaviors().get_Item(0)
    rotation.getTiming().setDuration(2)
    rotation.getTiming().setTriggerDelayTime(0.5)
    rotation.getTiming().setRepeatCount(3)
    rotation.getTiming().setAccelerate(0.2)
    rotation.getTiming().setDecelerate(0.2)

    presentation.save("timing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Η συμπεριφορά χρησιμοποιεί διάρκεια δύο δευτερολέπτων, καθυστέρηση μισού δευτερολέπτου και αριθμό επαναλήψεων 3. Τα πρώτα και τα τελευταία 20 % της διάρκειάς της χρησιμοποιούνται για επιτάχυνση και επιβράδυνση.

Άλλες πολιτικές επανάληψης περιλαμβάνουν τα [getRepeatDuration](https://reference.aspose.com/slides/el/python-java/aspose.slides/timing/#getRepeatDuration), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/el/python-java/aspose.slides/timing/#getRepeatUntilEndSlide) και [getRepeatUntilNextClick](https://reference.aspose.com/slides/el/python-java/aspose.slides/timing/#getRepeatUntilNextClick); επιλέξτε μία πολιτική αντί να τις ενεργοποιείτε όλες μαζί. Το [getAutoReverse](https://reference.aspose.com/slides/el/python-java/aspose.slides/timing/#getAutoReverse) παίζει την κίνηση ανάποδα μετά την προώθηση. Η επιτάχυνση και η επιβράδυνση εφαρμόζονται σε συνεχείς αλλαγές, όχι σε διακριτές αναθέσεις ή εντολές.

## **Δημιουργία Διαδρομής Κίνησης**

Χρησιμοποιήστε το [createMotionEffect](https://reference.aspose.com/slides/el/python-java/aspose.slides/behaviorfactory/#createMotionEffect) για να δημιουργήσετε κίνηση. Τα [getFrom](https://reference.aspose.com/slides/el/python-java/aspose.slides/motioneffect/#getFrom), [getTo](https://reference.aspose.com/slides/el/python-java/aspose.slides/motioneffect/#getTo) και [getBy](https://reference.aspose.com/slides/el/python-java/aspose.slides/motioneffect/#getBy) περιγράφουν συντεταγμένες ή μετατοπίσεις με βάση τα ποσοστά. Για επεξεργάσιμη διαδρομή, δημιουργήστε ένα [MotionPath](https://reference.aspose.com/slides/el/python-java/aspose.slides/motionpath/) και αναθέστε το με το [MotionEffect.setPath](https://reference.aspose.com/slides/el/python-java/aspose.slides/motioneffect/#setPath). Το [MotionPath](https://reference.aspose.com/slides/el/python-java/aspose.slides/motionpath/) αποθηκεύει τις εντολές της διαδρομής.

[MotionCommandPathType](https://reference.aspose.com/slides/el/python-java/aspose.slides/motioncommandpathtype/) επιλέγει τη λειτουργία:

| Εντολή | Σημεία | Σημασία |
| --- | --- | --- |
| MoveTo | Ένα | Ορίζει τη θέση εκκίνησης. |
| LineTo | Ένα | Μετακινείται κατά ένα ευθύ τμήμα μέχρι το άκρο του. |
| CurveTo | Τρία | Ακολουθεί μια κυβική καμπύλη που ορίζεται από δύο σημεία ελέγχου και ένα άκρο. |
| CloseLoop | Καμία | Επιστρέφει στη θέση εκκίνησης. |
| End | Καμία | Ολοκληρώνει τη διαδρομή. |

[MotionPathPointsType](https://reference.aspose.com/slides/el/python-java/aspose.slides/motionpathpointstype/) περιγράφει χαρακτηριστικά επεξεργασίας σημείων, όπως γωνιακά ή ομαλά σημεία. Δεν αντικαθιστά τον τύπο εντολής. Χρησιμοποιήστε τύπο σημείου καμπύλης για το παράδειγμα καμπύλης πιο κάτω και τύπο σημείου γωνίας για τα ευθύγραμμα τμήματα.

Οι συντεταγμένες της διαδρομής κανονικοποιούνται στις διαστάσεις της διαφάνειας: μια μετατόπιση X 0.25 αντιπροσωπεύει το ένα τέταρτο του πλάτους της διαφάνειας, όχι 0.25 μονάδες. Θετικό Y τρέχει προς τα κάτω. Οι απόλυτες εντολές καθορίζουν θέσεις στο σύστημα συντεταγμένων της διαδρομής· οι σχετικές εντολές καθορίζουν μετατοπίσεις από την τρέχουσα θέση. Αυτό είναι ξεχωριστό από το [getOrigin](https://reference.aspose.com/slides/el/python-java/aspose.slides/motioneffect/#getOrigin), που επιλέγει το πλαίσιο αναφοράς της διαδρομής, και το [getPathEditMode](https://reference.aspose.com/slides/el/python-java/aspose.slides/motioneffect/#getPathEditMode), που ελέγχει πώς η διαδρομή κινείται όταν το σχήμα μετακινείται.

### **Δημιουργία Ευθείας Διαδρομής**

Δημιουργήστε μια συμπεριφορά κίνησης με σημείο εκκίνησης, ένα ευθύ τμήμα και εντολή τερματισμού. Η [MotionPath.add](https://reference.aspose.com/slides/el/python-java/aspose.slides/motionpath/#add) δέχεται τον τύπο εντολής, τα σημεία της, τον τύπο σημείου και μια σημαία σχετικής συντεταγμένης.

Η εντολή εκκίνησης θέτει (0, 0), και η γραμμή τελειώνει στο (0.25, 0), δίνοντας στη διαδρομή οριζόντια μετατόπιση ενός τέταρτου του πλάτους της διαφάνειας. Η εντολή τερματισμού δεν έχει σημεία. Μόλις η διαδρομή ανατεθεί, η προσθήκη της συμπεριφοράς κίνησης στο εφέ συνδέει τη διαδρομή με το ορθογώνιο.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, MotionCommandPathType, MotionOriginType, MotionPath, MotionPathPointsType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.PathRight, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    motion = factory.createMotionEffect()
    motion.setOrigin(MotionOriginType.Layout)
    motion.getTiming().setDuration(2)

    path = MotionPath()
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0, 0)])
    path.add(MotionCommandPathType.MoveTo, path_points, MotionPathPointsType.Auto, False)
    path_points_2 = jpype.JArray(Point2DFloat)([Point2DFloat(0.25, 0)])
    path.add(MotionCommandPathType.LineTo, path_points_2, MotionPathPointsType.Corner, False)
    path_points_3 = jpype.JArray(Point2DFloat)(0)
    path.add(MotionCommandPathType.End, path_points_3, MotionPathPointsType.None_, False)

    motion.setPath(path)
    effect.getBehaviors().add(motion)

    presentation.save("motion.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`motion.pptx` περιέχει μια συμπεριφορά κίνησης με τρεις εντολές διαδρομής. Τα παρακάτω παραδείγματα επεξεργασίας αρχείων χρησιμοποιούν αυτήν τη γνωστή δομή.

### **Σύγκριση Απόλυτων και Σχετικών Συντεταγμένων**

Αυτά τα δύο αντικείμενα διαδρομής περιγράφουν την ίδια διαδρομή. Η απόλυτη εντολή τελειώνει στο (0.3, 0.1); η σχετική εντολή προσθέτει (0.1, 0.1) στην τρέχουσα θέση, δηλαδή (0.2, 0).

Και οι δύο διαδρομές ξεκινούν από την ίδια θέση. Για τη σχετική γραμμή, προσθέστε τις μετατοπίσεις X και Y στην τρέχουσα θέση για να πάρετε το άκρο· για την απόλυτη γραμμή διαβάστε το άκρο απευθείας. Η αλλαγή της σημαίας χωρίς μετατροπή των συντεταγμένων θα περιγράψει διαφορετική διαδρομή.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPath, MotionPathPointsType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

absolute_path = MotionPath()
path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0)])
absolute_path.add(MotionCommandPathType.MoveTo, path_points, MotionPathPointsType.Auto, False)
path_points_2 = jpype.JArray(Point2DFloat)([Point2DFloat(0.3, 0.1)])
absolute_path.add(MotionCommandPathType.LineTo, path_points_2, MotionPathPointsType.Corner, False)

relative_path = MotionPath()
path_points_3 = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0)])
relative_path.add(MotionCommandPathType.MoveTo, path_points_3, MotionPathPointsType.Auto, False)
path_points_4 = jpype.JArray(Point2DFloat)([Point2DFloat(0.1, 0.1)])
relative_path.add(MotionCommandPathType.LineTo, path_points_4, MotionPathPointsType.Corner, True)
```

Αναθέστε είτε τη μία είτε την άλλη διαδρομή σε μια συμπεριφορά κίνησης για χρήση στην παρουσίαση. Το τελικό λογικό επιχείρημα επιλέγει σχετικές συντεταγμένες για εκείνη την εντολή.

### **Αντικατάσταση Γραμμής με Καμπύλη**

Ανοίξτε το `motion.pptx` και αντικαταστήστε την εντολή γραμμής του με μια κυβική καμπύλη. Δώστε πρώτα τα δύο σημεία ελέγχου, μετά το άκρο.

Η θέση εκκίνησης παρέχεται από την προηγούμενη εντολή. Τα πρώτα δύο σημεία σχηματίζουν την καμπύλη, ενώ το τρίτο είναι ο προορισμός· δεν είναι τρία διαδοχικά άκρα. Η ενημέρωση του τύπου εντολής, του τύπου επεξεργασίας σημείων και του πίνακα σημείων μαζί διατηρεί το τμήμα συνεπές με τη νέα του γεωμετρία.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPathPointsType, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo)
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth)
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.1, 0), Point2DFloat(0.2, 0.1), Point2DFloat(0.3, 0.1)])
    path.get_Item(1).setPoints(path_points)

    presentation.save("curve.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Η διαδρομή στο `curve.pptx` έχει ακόμα τρεις εντολές· η μεσαία εντολή τώρα ορίζει μια καμπύλη.

## **Επιθεώρηση και Επεξεργασία Αποθηκευμένης Διαδρομής**

Κάθε [MotionCmdPath](https://reference.aspose.com/slides/el/python-java/aspose.slides/motioncmdpath/) εκθέτει τα [getPoints](https://reference.aspose.com/slides/el/python-java/aspose.slides/motioncmdpath/#getPoints), [getCommandType](https://reference.aspose.com/slides/el/python-java/aspose.slides/motioncmdpath/#getCommandType), [getPointsType](https://reference.aspose.com/slides/el/python-java/aspose.slides/motioncmdpath/#getPointsType) και το [isRelative](https://reference.aspose.com/slides/el/python-java/aspose.slides/motioncmdpath/#isRelative). Τα παρακάτω παραδείγματα χρησιμοποιούν τη γνωστή τριεντολή διαδρομή στο `motion.pptx`. Για αυθαίρετη είσοδο, εντοπίστε το αντίστοιχο εφέ και ελέγξτε τους τύπους εντολών και τους αριθμούς σημείων πριν επεξεργαστείτε με βάση δείκτη.

### **Ανάγνωση Εντολών και Συντεταγμένων**

Διαβάστε τη διαδρομή χωρίς αλλαγές. Οι εντολές End και CloseLoop δεν απαιτούν σημεία, έτσι πρέπει να προβλεφθεί ένας μηδενικός πίνακας σημείων.

Η έξοδος ζευγάρει κάθε αριθμητικό τύπο εντολής με τη σημαία σχετικής συντεταγμένης πριν καταγράψει τα σημεία του. Έτσι μπορείτε να διακρίνετε ένα άκρο από μια μετατόπιση πριν τροποποιήσετε τη διαδρομή. Μια καμπύλη θα καταγράψει τρία σημεία, ενώ η ευθεία γραμμή σε αυτό το αρχείο καταγράφει μόνο ένα.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    for segment in path:
        print(f"{segment.getCommandType()}, relative: {segment.isRelative()}")
        if segment.getPoints() is not None:
            for point in segment.getPoints():
                print(f"X={point.x}, Y={point.y}")
finally:
    presentation.dispose()
```

Η λίστα περιέχει σημείο εκκίνησης, μια απόλυτη γραμμή που τελειώνει στο (0.25, 0) και μια εντολή τερματισμού.

### **Αλλαγή Τελικού Σημείου**

Ανοίξτε το `motion.pptx` και αντικαταστήστε τον πίνακα σημείων της γραμμής για να μετακινήσετε το άκρο της.

Στο αρχείο εισόδου, ο δείκτης 0 είναι η εντολή εκκίνησης και ο δείκτης 1 είναι η γραμμή. Η αντικατάσταση του μοναδικού σημείου της γραμμής αλλάζει τον προορισμό της χωρίς να αλλάζει τον τύπο της εντολής, το χρόνο ή τη θέση της στη συλλογή. Επειδή η εντολή χρησιμοποιεί απόλυτες συντεταγμένες, το νέο ζεύγος καθορίζει θέση και όχι πρόσθετη μετατόπιση.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    motion = effect.getBehaviors().get_Item(0)
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.4, 0.1)])
    motion.getPath().get_Item(1).setPoints(path_points)

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Η γραμμή στο `motion-endpoint.pptx` τελειώνει στο (0.4, 0.1); το αρχικό αρχείο δεν έχει τροποποιηθεί.

### **Αντικατάσταση Τμήματος**

Χρησιμοποιήστε τις [insert](https://reference.aspose.com/slides/el/python-java/aspose.slides/motionpath/#insert) και [removeAt](https://reference.aspose.com/slides/el/python-java/aspose.slides/motionpath/#removeAt) για να αντικαταστήσετε τη γραμμή στο `motion.pptx`. Η εισαγωγή μετακινεί την παλιά γραμμή στη θέση 2.

Αυτό δείχνει την αντικατάσταση ενός αντικειμένου εντολής αντί για επεξεργασία των υπαρχουσών συντεταγμένων του. Μετά την εισαγωγή, η συλλογή περιλαμβάνει προσωρινά την εντολή εκκίνησης, τη νέα γραμμή, την παλιά γραμμή και την εντολή τερματισμού. Η αφαίρεση του δείκτη 2 απορρίπτει την παλιά γραμμή και αφήνει τη νέα διαδρομή στη θέση της.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPathPointsType, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0.1)])
    path.insert(1, MotionCommandPathType.LineTo, path_points, MotionPathPointsType.Corner, False)
    path.removeAt(2)

    presentation.save("motion-edited.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Η αποθηκευμένη διαδρομή εξακολουθεί να έχει τρεις εντολές· η καινούρια γραμμή τελειώνει στο (0.2, 0.1) και η εντολή τερματισμού παραμένει τελευταία.

## **Τροποποίηση και Επαλήθευση Υπάρχουσας Συμπεριφοράς**

Όταν δεν γνωρίζετε τον δείκτη της συμπεριφοράς, επιλέξτε τη βάση του τύπου. Αυτό το παράδειγμα ανοίγει το `rotation.pptx`, εντοπίζει το [RotationEffect](https://reference.aspose.com/slides/el/python-java/aspose.slides/rotationeffect/), αλλάζει τη γωνία και ελέγχει την αποθηκευμένη τιμή μετά την επανέναρξη.

Ο έλεγχος τύπου επιτρέπει στον βρόχο να παραλείψει συμπεριφορές που δεν είναι περιστροφές. Η δεύτερη φόρτωση διαβάζει το αποθηκευμένο αρχείο σε ξεχωριστό αντικείμενο παρουσίασης, ώστε η σύγκριση να ελέγχει τα δεδομένα που διατηρήθηκαν και όχι την τιμή που παραμένει στη μνήμη. Αυτό το παράδειγμα υποθέτει ότι το γνωστό εφέ είναι πρώτο στην κύρια ακολουθία· η επιλογή συμπεριφοράς με βάση τον τύπο δεν εντοπίζει σωστά το εφέ σε αυθαίρετη παρουσίαση.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RotationEffect, SaveFormat

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    for behavior in effect.getBehaviors():
        if isinstance(behavior, RotationEffect):
            rotation = behavior
            rotation.setBy(180)

    presentation.save("rotation-edited.pptx", SaveFormat.Pptx)

    reopened = Presentation("rotation-edited.pptx")
    try:
        saved_effect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

        for behavior in saved_effect.getBehaviors():
            if isinstance(behavior, RotationEffect):
                rotation = behavior
                print(f"Rotation preserved: {abs(rotation.getBy() - 180) < 0.001}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Η έξοδος είναι `Rotation preserved: True`. Εφαρμόστε το ίδιο πρότυπο ελέγχου τύπου σε άλλες συμπεριφορές. Για πλήρη έλεγχο διατήρησης, συγκρίνετε το σχήμα-στόχο, το εφέ, τους τύπους και τη σειρά των συμπεριφορών, το χρόνο, και τις εντολές διαδρομής. Χρησιμοποιήστε αριθμητική ανοχή για τιμές κινητής υποδιαστολής. Για παρουσίαση με άγνωστη διάταξη κίνησης, δείτε [Read Shape Animations](/slides/el/python-java/shape-animation/#read-shape-animations) για την περιήγηση των κύριων και διαδραστικών ακολουθιών.

## **Σειρά Συμπεριφορών, Προεπιλογές και Αναπαραγωγή**

Η σειρά στο [BehaviorCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/behaviorcollection/) είναι η αποθηκευμένη σειρά των λειτουργιών ενός εφέ. Δεν είναι λίστα αναπαραγωγής στην οποία κάθε συμπεριφορά περιμένει αυτόματα την προηγούμενη. Ο χρονοπρογραμματισμός και το περιβάλλον εφέ καθορίζουν το προγραμματισμό. Οι συμπεριφορές μπορούν να επικαλύπτονται και οι λειτουργίες στο ίδιο χαρακτηριστικό ενδέχεται να αλληλεπιδράσουν μέσω των [getAdditive](https://reference.aspose.com/slides/el/python-java/aspose.slides/behavior/#getAdditive) και [getAccumulate](https://reference.aspose.com/slides/el/python-java/aspose.slides/behavior/#getAccumulate). Μην χρησιμοποιείτε μόνο την αναδιάταξη της συλλογής για να προγραμματίσετε «μετακίνηση, μετά περιστροφή»· χρησιμοποιήστε ρητό χρονοπρογραμματισμό ή ξεχωριστά εφέ όπως περιγράφεται στην [Κίνηση Σχήματος](/slides/el/python-java/shape-animation/).

Το [getType](https://reference.aspose.com/slides/el/python-java/aspose.slides/effect/#getType) και το [getSubtype](https://reference.aspose.com/slides/el/python-java/aspose.slides/effect/#getSubtype) του εφέ περιγράφουν την προεπιλογή του. Δεν είναι πλήρης περιγραφή ενός επεξεργασμένου δένδρου συμπεριφορών. Επιλέξτε την προεπιλογή και τον υποτύπο πριν προσαρμόσετε τις συμπεριφορές: η αλλαγή της προεπιλογής μπορεί να ξαναχτίσει τη συλλογή και να διαγράψει τις προσαρμοσμένες λειτουργίες σας. Για παράδειγμα, η αλλαγή ενός προσαρμοσμένου εφέ Spin σε Fade μπορεί να αντικαταστήσει τη συμπεριφορά περιστροφής με συμπεριφορές set και filter. Εξετάστε ξανά τη συλλογή μετά την αλλαγή προεπιλογής ή υποτύπου. Η εκκαθάριση των προεπιλογών μπορεί επίσης να αφαιρέσει λειτουργίες ορατότητας ή αρχικοποίησης που απαιτούνται από την προεπιλογή. Τα παραδείγματα χρησιμοποιούν σχήματα που είναι ήδη ορατά και αντικαθιστούν τις συμπεριφορές· δεν αναδημιουργούν την υλοποίηση κάθε προεπιλογής.

## **Συμβατότητα Μορφής**

| Μορφή ή έξοδος | Τι να επαληθεύσετε |
| --- | --- |
| PPTX | Χρησιμοποιήστε το ως κύρια μορφή για αυτά τα παραδείγματα. Ανοίξτε το ξανά για να επαληθεύσετε το επεξεργάσιμο δένδρο συμπεριφορών, έπειτα ελέγξτε την αναπαραγωγή στην επιθυμητή έκδοση του PowerPoint. |
| PPT | Η παλαιά δυαδική αναπαράσταση μπορεί να διαφέρει από το PPTX. Δοκιμάστε έναν ξεχωριστό κύκλο αποθήκευσης‑ανάκτησης και αναπαραγωγής· μην υποθέτετε υποστήριξη για κάθε προσαρμοστικό συνδυασμό από την επιτυχημένη έξοδο PPTX. |
| PDF, PNG, JPEG και άλλες στατικές εικόνες διαφάνειας | Περιέχουν μια στατική αναπαράσταση της διαφάνειας, όχι μια αναγγλική χρονογραμμή συμπεριφορών ή εγγυημένο τελικό καρέ κίνησης. |
| [HTML5](/slides/el/python-java/export-to-html5/) | Μπορεί να παίζει υποστηριζόμενες κινήσεις όταν η κίνηση σχήματος είναι ενεργοποιημένη στις επιλογές εξαγωγής. Δοκιμάστε προσαρμοσμένους συνδυασμούς στον περιηγητή. |
| [Animated GIF](/slides/el/python-java/convert-powerpoint-to-animated-gif/) | Αποθηκεύει τα αποδιδόμενα πλαίσια, όχι επεξεργάσιμες συμπεριφορές ή αλληλεπιδράσεις κλικ. Ελέγξτε την πραγματική αποδιδόμενη κίνηση. |
| [Video](/slides/el/python-java/convert-powerpoint-to-video/) | Δημιουργεί πλαίσια κίνησης και τα κωδικοποιεί ως βίντεο. Η υποστήριξη περιορίζεται στις [supported animations and effects](/slides/el/python-java/convert-powerpoint-to-video/#supported-animations-and-effects) του δημιουργού· οι εντολές και τα διαδραστικά γεγονότα δεν γίνονται επεξεργάσιμο χρονοδιάγραμμα. |

## **Συχνές Ερωτήσεις**

**Γιατί το εφέ μου περιέχει συμπεριφορές πριν προσθέσω κάτι;**

Η δημιουργία ενός προεπιλεγμένου εφέ μπορεί να δημιουργήσει τις υποκείμενες λειτουργίες του. Εξετάστε τις πριν αποφασίσετε αν θα επεκτείνετε ή θα αντικαταστήσετε τις συμπεριφορές της προεπιλογής.

**Αν μετακινήσω μια συμπεριφορά στην αρχή, θα παίξει πρώτη;**

Όχι απαραίτητα. Η σειρά της συλλογής δεν αντικαθιστά τον χρονοπρογραμματισμό. Ελέγξτε καθυστέρηση, διάρκεια και αλληλεπιδράσεις μεταξύ λειτουργιών στο ίδιο χαρακτηριστικό.

**Γιατί η εντολή «End» δεν έχει σημεία;**

Σηματοδοτεί το τέλος της διαδρομής και δεν απαιτεί συντεταγμένες. Ελέγξτε για μηδενικό πίνακα σημείων όταν επιθεωρείτε μια διαδρομή που διαβάζεται από αρχείο.

**Είναι ένας επιτυχής κύκλος αποθήκευσης και ανάκτησης επαρκής για επιβεβαίωση της αναπαραγωγής;**

Όχι. Η επαναφόρτωση επαληθεύει την διατήρηση των ιδιοτήτων που ελέγξατε. Δοκιμάστε το πρόγραμμα παρουσίασης ή την εξαγωγή animation ξεχωριστά για να επιβεβαιώσετε τη οπτική συμπεριφορά.