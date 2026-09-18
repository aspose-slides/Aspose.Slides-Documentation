---
title: "Δημιουργία και Τροποποίηση Προσαρμοσμένων Συμπεριφορών Κίνησης σε JavaScript"
linktitle: "Προσαρμοσμένη Κίνηση"
type: docs
weight: 151
url: /el/nodejs-java/custom-animation/
keywords:
- προσαρμοσμένη κίνηση
- συμπεριφορά κίνησης
- διαδρομή κίνησης
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Δημιουργήστε, επιθεωρήστε και τροποποιήστε προσαρμοσμένες συμπεριφορές κίνησης και επεξεργάσιμες διαδρομές κίνησης σε παρουσιάσεις PowerPoint με το Aspose.Slides για Node.js μέσω Java."
---
## **Επισκόπηση**

Οι προσαρμοσμένες συμπεριφορές κίνησης σάς επιτρέπουν να ελέγχετε μεμονωμένες λειτουργίες μέσα σε ένα εφέ κίνησης, όπως η αλλαγή χρώματος, η περιστροφή ενός σχήματος ή η ακολουθία επεξεργάσιμης διαδρομής κίνησης. Αυτός ο οδηγός δείχνει πώς να δημιουργήσετε και να συνδυάσετε συμπεριφορές, να ρυθμίσετε το χρόνο τους, να επιθεωρήσετε και να τροποποιήσετε υπάρχουσες κινήσεις και να επαληθεύσετε ότι οι ιδιότητές τους παραμένουν μετά την αποθήκευση και το άνοιγμα ξανά μιας παρουσίασης.

Για προεπιλεγμένα εφέ και ενεργοποιητές κλικ, δείτε [Κίνηση Σχήματος](/slides/el/nodejs-java/shape-animation/).

## **Κατανόηση του Μοντέλου Κίνησης**

Μία κίνηση οργανώνεται ως **Γραμμή Χρόνου → Ακολουθία → Εφέ → Συμπεριφορές**:

- Η μέθοδος [getTimeline](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/baseslide/#getTimeline) επιστρέφει τη γραμμή χρόνου της διαφάνειας, η οποία περιλαμβάνει την κύρια ακολουθία της και τις διαδραστικές ακολουθίες.
- Μια [Sequence](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sequence/) περιέχει εφέ, ενδέχεται στοχεύοντας σε διαφορετικά σχήματα.
- Ένα [Effect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/effect/) προσδιορίζει ένα σχήμα στόχο, προεγκατεστημένο εφέ, υποτύπο και χρόνο εφέ.
- Η συλλογή που επιστρέφεται από το [Effect.getBehaviors](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/effect/#getBehaviors) περιέχει τις λειτουργίες που εφαρμόζουν το εφέ: αλλαγή χρώματος, κίνηση, περιστροφή, ορισμό ιδιότητας κ.λπ.

## **Δημιουργία Μεμονωμένων Συμπεριφορών**

Καλείτε το [Sequence.addEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sequence/#addEffect) για να δημιουργήσετε ένα εφέ και να έχετε πρόσβαση στη συλλογή [getBehaviors](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/effect/#getBehaviors). Ένα προεπιλεγμένο εφέ μπορεί να γεμίσει αυτή τη συλλογή αυτόματα. Διατηρήστε τις λειτουργίες του όταν επεκτείνετε το προεπιλεγμένο εφέ, ή χρησιμοποιήστε το [clear](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/behaviorcollection/#clear) όταν το αντικαθιστάτε σκόπιμα.

Η [BehaviorFactory](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/behaviorfactory/) δημιουργεί τους οκτώ τύπους συμπεριφορών που απεικονίζονται παρακάτω. Η κίνηση καλύπτεται στην ενότητα [Δημιουργία Διαδρομής Κίνησης](#build-a-motion-path). Κάθε απόσπασμα κώδικα περιλαμβάνει τις εισαγωγές των μονάδων του και μπορεί να εκτελεστεί ως σενάριο Node.js με τα πακέτα `aspose.slides.via.java` και `java` εγκατεστημένα. Εκτελέστε τα παραδείγματα δημιουργίας αρχείων πριν από τα παραδείγματα που διαβάζουν το αποτέλεσμα τους. Τα παραδείγματα επεξεργασίας που ακολουθούν αναφέρουν ποιο αρχείο εξόδου χρησιμοποιούν.

### **Περιστροφή**

Χρησιμοποιήστε το [createRotationEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/behaviorfactory/#createRotationEffect) για να δημιουργήσετε μια περιστροφή. Το [getBy](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/rotationeffect/#getBy) καθορίζει μια σχετική γωνία σε μοίρες· τα [getFrom](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/rotationeffect/#getFrom) και [getTo](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/rotationeffect/#getTo) καθορίζουν τα άκρα.

Το παράδειγμα ξεκινά με ένα εφέ Spin, αντικαθιστά τις προεγκατεστημένες λειτουργίες του με μία συμπεριφορά περιστροφής και δίνει σε αυτή τη λειτουργία διάρκεια δύο δευτερολέπτων. Μία σχετική γωνία 90 μοιρών εκφράζει μια τεταρτημόρροια περιστροφή από την αρχική προσανατολισμό του σχήματος, επομένως δεν απαιτείται ρητή αρχική γωνία.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Spin, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const rotation = factory.createRotationEffect();
    rotation.setBy(90);
    rotation.getTiming().setDuration(2);

    effect.getBehaviors().add(rotation);

    presentation.save("rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`rotation.pptx` περιέχει ένα σχήμα και μια συμπεριφορά περιστροφής. Η συλλογή, ο χρόνος και τα παραδείγματα επεξεργασίας περιστροφής παρακάτω χρησιμοποιούν αυτό το αρχείο.

### **Κλιμάκωση**

Χρησιμοποιήστε το [createScaleEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/behaviorfactory/#createScaleEffect) με ποσοστά X/Y: τα [getFrom](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/scaleeffect/#getFrom) και [getTo](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/scaleeffect/#getTo) περιγράφουν το αρχικό και τελικό μέγεθος, ενώ το [getBy](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/scaleeffect/#getBy) περιγράφει μια σχετική αλλαγή. Εδώ, το 100 σημαίνει το αρχικό μέγεθος.

Το παράδειγμα αυξάνει και τις δύο διαστάσεις από 100% σε 125% σε δύο δευτερόλεπτα. Η χρήση ίσων οριζόντιων και κατακόρυφων ποσοστών διατηρεί τις αναλογίες του σχήματος· διαφορετικά ποσοστά θα τράβηξαν τη μία διάσταση περισσότερο από την άλλη.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.GrowShrink, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const scale = factory.createScaleEffect();
    scale.setFrom(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(100), java.newFloat(100)));
    scale.setTo(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(125), java.newFloat(125)));
    scale.getTiming().setDuration(2);

    effect.getBehaviors().add(scale);

    presentation.save("scale.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Χρώμα**

Χρησιμοποιήστε το [createColorEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/behaviorfactory/#createColorEffect) για να αλλάξετε τη γέμιση από μπλε σε πορτοκαλί. Τα [getFrom](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/coloreffect/#getFrom) και [getTo](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/coloreffect/#getTo) είναι χρώματα· το [getBy](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/coloreffect/#getBy) είναι μια μετατόπιση χρώματος. Το [Behavior.getProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/behavior/#getProperties) προσδιορίζει το χαρακτηριστικό που ανιματίζεται.

Η στήριξη γεμίσματος του σ.shapeμάτος αρχικοποιείται σε μπλε, ταιριάζοντας με το αρχικό χρώμα της κίνησης. Η επιλογή του χαρακτηριστικού fill-color λέει στη συμπεριφορά ποιο τμήμα του σχήματος να αλλάξει· τα άκρα χρώματος από μόνα τους δεν προσδιορίζουν αυτό το χαρακτηριστικό. Το αποθηκευμένο εφέ περιγράφει μια δις δευτερολέπτων μετάβαση στο πορτοκαλί.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.ChangeFillColor, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const color = factory.createColorEffect();
    color.getProperties().add(aspose.slides.BehaviorProperty.getFillColor().getValue());
    color.getFrom().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    const orange = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    color.getTo().setColor(orange);
    color.getTiming().setDuration(2);

    effect.getBehaviors().add(color);

    presentation.save("color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Φίλτρο**

Χρησιμοποιήστε το [createFilterEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/behaviorfactory/#createFilterEffect) για να επιλέξετε ένα ξέσαμα. Τα [getType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/filtereffect/#getType), [getSubtype](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/filtereffect/#getSubtype) και [getReveal](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/filtereffect/#getReveal) καθορίζουν το φίλτρο, την κατεύθυνση και το αν θα αποκαλυφθεί ή θα κρυφτεί το σχήμα.

Αυτό το παράδειγμα ρυθμίζει ένα ξέσαμα δύο δευτερολέπτων που αποκαλύπτει το σχήμα χρησιμοποιώντας τον υποτύπο κατεύθυνσης δεξιά. Οι ρυθμίσεις του φίλτρου ανήκουν στη συμπεριφορά μέσα στο εφέ, οπότε ρυθμίζονται αφού αφαιρεθούν οι αρχικές λειτουργίες του προεπιλεγμένου εφέ.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Wipe, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const filter = factory.createFilterEffect();
    filter.setType(aspose.slides.FilterEffectType.Wipe);
    filter.setSubtype(aspose.slides.FilterEffectSubtype.Right);
    filter.setReveal(aspose.slides.FilterEffectRevealType.In);
    filter.getTiming().setDuration(2);

    effect.getBehaviors().add(filter);

    presentation.save("filter.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Ιδιότητα**

Χρησιμοποιήστε το [createPropertyEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/behaviorfactory/#createPropertyEffect) για να ανιματίσετε τη διαφάνεια. Τα [getFrom](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/propertyeffect/#getFrom), [getTo](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/propertyeffect/#getTo) και [getBy](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/propertyeffect/#getBy) είναι συμβολοσειρές που ερμηνεύονται χρησιμοποιώντας τα [getValueType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/propertyeffect/#getValueType) και [getCalcMode](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/propertyeffect/#getCalcMode). Επιλέξτε άκρα ή μια σχετική μετατόπιση αντί να ορίζετε και τα τρία αδράξια.

Εδώ, το επιλεγμένο χαρακτηριστικό είναι η διαφάνεια, και οι αριθμητικές συμβολοσειρές αντιπροσωπεύουν μια αλλαγή από 25% διαφάνεια σε πλήρη διαφάνεια. Η γραμμική παρεμβολή περιγράφει μια βαθμιαία αλλαγή μεταξύ αυτών των τιμών. Όταν προσαρμόζετε αυτό το παράδειγμα σε άλλο χαρακτηριστικό, επιλέξτε τύπο τιμής και τιμές άκρων κατάλληλες για το συγκεκριμένο χαρακτηριστικό.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const property = factory.createPropertyEffect();
    property.getProperties().add(aspose.slides.BehaviorProperty.getStyleOpacity().getValue());
    property.setValueType(aspose.slides.PropertyValueType.Number);
    property.setCalcMode(aspose.slides.PropertyCalcModeType.Linear);
    property.setFrom("0.25");
    property.setTo("1");
    property.getTiming().setDuration(2);

    effect.getBehaviors().add(property);

    presentation.save("property.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Ορισμός**

Χρησιμοποιήστε το [createSetEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/behaviorfactory/#createSetEffect) για να ορίσετε ορατότητα μέσω του [getTo](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/seteffect/#getTo). Μια συμπεριφορά ορισμού δεν κάνει παρεμβολή μεταξύ των άκρων.

Το παράδειγμα επιλέγει το χαρακτηριστικό ορατότητας και αναθέτει τη συμβολοσειρά `visible` όταν εκτελείται η συμπεριφορά. Το ορθογώνιο είναι ήδη ορατό σε αυτή τη μίνιμυ παρουσίαση, οπότε η ανάθεση μπορεί να μην παράγει εμφανή οπτική αλλαγή από μόνη της. Μια τέτοια λειτουργία είναι χρήσιμη ως μέρος ενός μεγαλύτερου εφέ που ελέγχει επίσης πότε το σχήμα κρύβεται ή γίνεται ορατό.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const set = factory.createSetEffect();
    set.getProperties().add(aspose.slides.BehaviorProperty.getStyleVisibility().getValue());
    set.setTo("visible");

    effect.getBehaviors().add(set);

    presentation.save("set.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Εντολή**

Χρησιμοποιήστε το [createCommandEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/behaviorfactory/#createCommandEffect) και ρυθμίστε τα [getType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/commandeffect/#getType), [getCommandString](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/commandeffect/#getCommandString), και [getShapeTarget](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/commandeffect/#getShapeTarget). Τοποθετήστε μια ηχογράφημα WAV με όνομα `sample.wav` στον τρέχοντα φάκελο. Αυτό το παράδειγμα το ενσωματώνει με το [addAudioFrameEmbedded](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) και συνδέει μια εντολή αναπαραγωγής στο πλαίσιο ήχου.

Το πλαίσιο ήχου είναι τόσο ο στόχος του εφέ όσο και ο στόχος της εντολής. Αυτό συνδέει το αίτημα αναπαραγωγής με την ενσωματωμένη ηχογράφηση· μια συμβολοσειρά εντολής από μόνη της δεν προσδιορίζει ποιο αντικείμενο πολυμέσων να ελέγξει. Το εφέ ρυθμίζεται να ξεκινά με κλικ κατά τη διάρκεια της παρουσίασης.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sample.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audioStream);

        const effect = slide.getTimeline().getMainSequence().addEffect(audioFrame, aspose.slides.EffectType.MediaPlay, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
        effect.getBehaviors().clear();

        const factory = new aspose.slides.BehaviorFactory();
        const command = factory.createCommandEffect();
        command.setType(java.newByte(aspose.slides.CommandEffectType.Call));
        command.setCommandString("play");
        command.setShapeTarget(audioFrame);

        effect.getBehaviors().add(command);

        presentation.save("command.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        audioStream.close();
    }
} finally {
    presentation.dispose();
}
```

Η αποθήκευση αποθηκεύει την εντολή στο `command.pptx`; δεν αναπαράγει την ηχογράφηση. Η αναπαραγωγή απαιτεί έναν αναπαραγωγό παρουσίασης που υποστηρίζει την εντολή και τον στόχο πολυμέσων.

## **Διαχείριση της Συλλογής Συμπεριφορών**

Η [BehaviorCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/behaviorcollection/) υποστηρίζει τις λειτουργίες [add](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/behaviorcollection/#add), [insert](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/behaviorcollection/#insert), [remove](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/behaviorcollection/#remove), και [removeAt](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/behaviorcollection/#removeAt). Αυτό το παράδειγμα ανοίγει το `rotation.pptx`, προσθέτει κλιμάκωση, τη μετακινεί πριν από την περιστροφή και αφαιρεί την περιστροφή. Η αφαίρεση και η επανεισαγωγή του ίδιου αντικειμένου αλλάζει τη θέση του στην αποθηκευμένη σειρά χωρίς να δημιουργηθεί αντίγραφο.

Η σειρά των επεξεργασιών αλλάζει τη συλλογή από περιστροφή–κλιμάκωση σε κλιμάκωση–περιστροφή, και μετά μόνο σε κλιμάκωση. Οι δείκτες αναφέρονται στην τρέχουσα συλλογή, έτσι η αφαίρεση χρησιμοποιεί το νέο δείκτη της περιστροφής μετά την αναδιάταξη. Η τελική απαρίθμηση επιβεβαιώνει ποια συμπεριφορά θα αποθηκευτεί.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const behaviors = effect.getBehaviors();

    const factory = new aspose.slides.BehaviorFactory();
    const scale = factory.createScaleEffect();
    scale.setTo(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(125), java.newFloat(125)));
    scale.getTiming().setDuration(2);

    behaviors.add(scale);

    behaviors.remove(scale);
    behaviors.insert(0, scale);
    behaviors.removeAt(1);

    for (let i = 0; i < behaviors.getCount(); i++) {
        const behavior = behaviors.get_Item(i);
        console.log(behavior.getClass().getSimpleName());
    }

    presentation.save("collection-edited.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η έξοδος είναι `ScaleEffect`: παραμένει μόνο η κλιμάκωση. Η σειρά στη συλλογή δεν προγραμματίζει από μόνη της τις συμπεριφορές μία μετά την άλλη. Αδειάστε τη συλλογή μόνο όταν αντικαθιστάτε όλες τις λειτουργίες της.

## **Παραμετροποίηση Χρόνου Συμπεριφοράς**

Η [Behavior.getTiming](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/behavior/#getTiming) αποκαλύπτει το [Timing](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/timing/), ανεξάρτητα από το [Effect.getTiming](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/effect/#getTiming). Ο χρόνος του εφέ προγραμματίζει το περιβάλλον εφέ· ο χρόνος της συμπεριφοράς περιγράφει μια λειτουργία μέσα σε αυτό.

### **Ορισμός Διάρκειας, Καθυστέρησης, Επανάληψης και Επιτάχυνσης**

Ανοίξτε το `rotation.pptx` και ορίστε τη διάρκεια ([getDuration](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/timing/#getDuration)) και την καθυστέρηση ενεργοποίησης ([getTriggerDelayTime](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/timing/#getTriggerDelayTime)) σε δευτερόλεπτα, έπειτα ρυθμίστε τον αριθμό επαναλήψεων μέσω του [setRepeatCount](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/timing/#setRepeatCount). Τα [getAccelerate](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/timing/#getAccelerate) και [getDecelerate](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/timing/#getDecelerate) είναι κλάσματα της διάρκειας· διατηρήστε το άθροισμά τους το πολύ 1.

Το αρχείο εισόδου είναι αυτό που δημιουργήθηκε στο παράδειγμα περιστροφής, όπου η πρώτη συμπεριφορά είναι γνωστό ότι είναι περιστροφή. Αυτό το παράδειγμα αλλάζει μόνο το χρόνο αυτής της συμπεριφοράς· η γωνία των 90 μοιρών παραμένει αμετάβλητη. Η διαχωρισμένη διαχείριση γωνίας και χρόνου καθιστά ευκολότερη την προσαρμογή του ρυθμού χωρίς να ξαναχτίζει την κίνηση.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    const rotation = effect.getBehaviors().get_Item(0);
    rotation.getTiming().setDuration(2);
    rotation.getTiming().setTriggerDelayTime(java.newFloat(0.5));
    rotation.getTiming().setRepeatCount(3);
    rotation.getTiming().setAccelerate(java.newFloat(0.2));
    rotation.getTiming().setDecelerate(java.newFloat(0.2));

    presentation.save("timing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η συμπεριφορά χρησιμοποιεί διάρκεια δύο δευτερολέπτων, καθυστέρηση μισού δευτερολέπτου, και αριθμό επαναλήψεων 3. Το πρώτο και το τελευταίο 20% της διάρκειας χρησιμοποιούνται για επιτάχυνση και επιβράδυνση.

Άλλες πολιτικές επανάληψης περιλαμβάνουν τα [getRepeatDuration](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/timing/#getRepeatDuration), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide), και [getRepeatUntilNextClick](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick); επιλέξτε μια πολιτική αντί να τις ενεργοποιείτε όλες μαζί. Το [getAutoReverse](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/timing/#getAutoReverse) παίζει την κίνηση ανάποδα μετά το εμπρός πέρασμα. Η επιτάχυνση και η επιβράδυνση εφαρμόζονται σε συνεχείς αλλαγές, όχι σε διακριτές αναθέσεις ή εντολές.

## **Δημιουργία Διαδρομής Κίνησης**

Χρησιμοποιήστε το [createMotionEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/behaviorfactory/#createMotionEffect) για να δημιουργήσετε κίνηση. Τα [getFrom](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/motioneffect/#getFrom), [getTo](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/motioneffect/#getTo), και [getBy](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/motioneffect/#getBy) περιγράφουν συντεταγμένες ή μετατοπίσεις με βάση το ποσοστό. Για επεξεργάσιμη διαδρομή, δημιουργήστε ένα [MotionPath](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/motionpath/) και αναθέστε το με το [MotionEffect.setPath](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/motioneffect/#setPath). Το [MotionPath](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/motionpath/) αποθηκεύει τις εντολές της διαδρομής.

| Εντολή | Σημεία | Σημασία |
| --- | --- | --- |
| MoveTo | One | Ορίζει την αρχική θέση. |
| LineTo | One | Μετακινείται κατά μήκος μιας ευθείας κατεύθυνσης μέχρι το άκρο της. |
| CurveTo | Three | Ακολουθεί μια κυβική καμπύλη που ορίζεται από δύο σημεία ελέγχου και ένα άκρο. |
| CloseLoop | None | Επιστρέφει στην αρχική θέση. |
| End | None | Ολοκληρώνει τη διαδρομή. |

Το [MotionPathPointsType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/motionpathpointstype/) περιγράφει χαρακτηριστικά επεξεργασίας σημείων, όπως γωνιακά ή λείες σημεία. Δεν αντικαθιστά τον τύπο εντολής. Χρησιμοποιήστε τύπο σημείου καμπύλης για το παράδειγμα καμπύλης παρακάτω και τύπο σημείου γωνίας για τα ευθύγραμμα τμήματα.

Οι συντεταγμένες της διαδρομής είναι κανονικοποιημένες στις διαστάσεις της διαφάνειας: μια μετατόπιση X 0.25 αντιπροσωπεύει το ένα τέταρτο του πλάτους της διαφάνειας, όχι 0.25 μονάδες. Θετικό Y κατευθύνεται προς τα κάτω. Οι απόλυτες εντολές καθορίζουν θέσεις στο σύστημα συντεταγμένων της διαδρομής· οι σχετικές εντολές καθορίζουν μετατοπίσεις από την τρέχουσα θέση. Αυτό είναι διαφορετικό από το [getOrigin](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/motioneffect/#getOrigin), το οποίο επιλέγει το πλαίσιο αναφοράς της διαδρομής, και το [getPathEditMode](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/motioneffect/#getPathEditMode), το οποίο ελέγχει πώς η διαδρομή κινείται όταν το σχήμα μετακινείται.

### **Δημιουργία Ευθείας Διαδρομής**

Δημιουργήστε μια συμπεριφορά κίνησης με ένα αρχικό σημείο, ένα ευθύ τμήμα και μια εντολή λήξης. Το [MotionPath.add](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/motionpath/#add) δέχεται τον τύπο εντολής, τα σημεία της, τον τύπο σημείου και μια ένδειξη σχετικών συντεταγμένων.

Η αρχική εντολή καθιερώνει (0, 0), και η γραμμή λήγει στο (0.25, 0), δίνοντας στη διαδρομή οριζόντια μετατόπιση ενός τέταρτου του πλάτους της διαφάνειας. Η εντολή λήξης δεν έχει σημεία συντεταγμένων. Μόλις η διαδρομή ανατεθεί, η προσθήκη της συμπεριφοράς κίνησης στο εφέ συνδέει αυτή τη διαδρομή με το ορθογώνιο.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.PathRight, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const motion = factory.createMotionEffect();
    motion.setOrigin(aspose.slides.MotionOriginType.Layout);
    motion.getTiming().setDuration(2);

    const path = new aspose.slides.MotionPath();
    path.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
    path.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.25), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Corner, false);
    path.add(aspose.slides.MotionCommandPathType.End, java.newArray("java.awt.geom.Point2D$Float", []), aspose.slides.MotionPathPointsType.None, false);

    motion.setPath(path);
    effect.getBehaviors().add(motion);

    presentation.save("motion.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion.pptx` περιέχει μια συμπεριφορά κίνησης με τρεις εντολές διαδρομής. Τα παρακάτω παραδείγματα επεξεργασίας αρχείου χρησιμοποιούν αυτή τη γνωστή δομή.

### **Σύγκριση Απόλυτων και Σχετικών Συντεταγμένων**

Αυτά τα δύο αντικείμενα διαδρομής περιγράφουν την ίδια διαδρομή. Η απόλυτη εντολή λήγει στο (0.3, 0.1); η σχετική εντολή προσθέτει (0.1, 0.1) στην τρέχουσα θέση, (0.2, 0).

Και οι δύο διαδρομές ξεκινούν από την ίδια θέση. Για τη σχετική γραμμή, προσθέστε τις μετατοπίσεις X και Y στην τρέχουσα θέση για να λάβετε το άκρο· για την απόλυτη γραμμή, διαβάστε το άκρο άμεσα. Η αλλαγή του σημαιού χωρίς να μετατρέψετε τις συντεταγμένες θα περιγράψει διαφορετική διαδρομή.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const absolutePath = new aspose.slides.MotionPath();
absolutePath.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
absolutePath.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.3), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, false);

const relativePath = new aspose.slides.MotionPath();
relativePath.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
relativePath.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.1), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, true);
```

Αντιστοιχίστε οποιαδήποτε από τις διαδρομές σε μια συμπεριφορά κίνησης για να τη χρησιμοποιήσετε σε μια παρουσίαση. Το τελικό λογικό επιχείρημα επιλέγει σχετικές συντεταγμένες για αυτή την εντολή.

### **Αντικατάσταση Γραμμής με Καμπύλη**

Ανοίξτε το `motion.pptx` και αντικαταστήστε την εντολή γραμμής του με μια κυβική καμπύλη. Δώστε πρώτα τα δύο σημεία ελέγχου, ακολουθούμενα από το άκρο.

Η αρχική θέση παρέχεται από την προηγούμενη εντολή. Τα πρώτα δύο σημεία διαμορφώνουν την καμπύλη, ενώ το τρίτο είναι ο προορισμός της· δεν είναι τρία διαδοχικά σημεία προορισμού. Η ενημέρωση του τύπου εντολής, του τύπου επεξεργασίας σημείων και του πίνακα σημείων μαζί διατηρεί το τμήμα συνεπές με τη νέα του γεωμετρία.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    path.get_Item(1).setCommandType(aspose.slides.MotionCommandPathType.CurveTo);
    path.get_Item(1).setPointsType(aspose.slides.MotionPathPointsType.CurveSmooth);
    path.get_Item(1).setPoints(java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.1), java.newFloat(0)), java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0.1)), java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.3), java.newFloat(0.1))]));

    presentation.save("curve.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η διαδρομή στο `curve.pptx` εξακολουθεί να έχει τρεις εντολές· η μεσαία εντολή τώρα ορίζει μια καμπύλη.

## **Επιθεώρηση και Επεξεργασία Αποθηκευμένης Διαδρομής**

Κάθε [MotionCmdPath](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/motioncmdpath/) αποκαλύπτει τα [getPoints](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/motioncmdpath/#getPoints), [getCommandType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/motioncmdpath/#getCommandType), [getPointsType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/motioncmdpath/#getPointsType), και [isRelative](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/motioncmdpath/#isRelative). Τα παρακάτω παραδείγματα χρησιμοποιούν τη γνωστή διαδρομή τριών εντολών στο `motion.pptx`. Για αυθαίρετη είσοδο, εντοπίστε το επιθυμητό εφέ και ελέγξτε τους τύπους εντολών και τον αριθμό σημείων πριν την επεξεργασία κατά δείκτη.

#### **Ανάγνωση Εντολών και Συντεταγμένων**

Διαβάστε τη διαδρομή χωρίς να την αλλάξετε. Οι εντολές End και CloseLoop δεν χρειάζονται σημεία, έτσι επιτρέψτε έναν μηδενικό πίνακα σημείων.

Η έξοδος ζεύγεται κάθε αριθμητικό τύπο εντολής με τη σημαία σχετικών συντεταγμένων πριν καταγράψει τα σημεία του. Αυτό σας επιτρέπει να ξεχωρίσετε ένα άκρο από μια μετατόπιση πριν τροποποιήσετε τη διαδρομή. Μια καμπύλη θα κατέγραφε τρία σημεία, ενώ η ευθεία γραμμή σε αυτό το αρχείο καταγράφει μόνο ένα.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    for (let i = 0; i < path.getCount(); i++) {
        const segment = path.get_Item(i);
        console.log(segment.getCommandType() + ", relative: " + segment.isRelative());
        const points = segment.getPoints();
        if (points != null) {
            for (const point of points) {
                console.log("X=" + point.getX() + ", Y=" + point.getY());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Η λίστα περιέχει ένα αρχικό σημείο, μια απόλυτη γραμμή που λήγει στο (0.25, 0), και μια εντολή λήξης.

#### **Αλλαγή Άκρου**

Ανοίξτε το `motion.pptx` και αντικαταστήστε τον πίνακα σημείων της γραμμής για να μετακινήσετε το άκρο της.

Στο αρχείο εισόδου, ο δείκτης 0 είναι η αρχική εντολή και ο δείκτης 1 η γραμμή. Η αντικατάσταση του μοναδικού σημείου της γραμμής αλλάζει τον προορισμό της χωρίς να αλλάζει τον τύπο εντολής, τον χρόνο ή τη θέση της στη συλλογή. Επειδή η εντολή χρησιμοποιεί απόλυτες συντεταγμένες, το νέο ζευγάρι καθορίζει θέση αντί μετατόπισης.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    const motion = effect.getBehaviors().get_Item(0);
    motion.getPath().get_Item(1).setPoints(java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.4), java.newFloat(0.1))]));

    presentation.save("motion-endpoint.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η γραμμή στο `motion-endpoint.pptx` λήγει στο (0.4, 0.1); το αρχικό αρχείο παραμένει αμετάβλητο.

#### **Αντικατάσταση Τμήματος**

Χρησιμοποιήστε τα [insert](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/motionpath/#insert) και [removeAt](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/motionpath/#removeAt) για να αντικαταστήσετε τη γραμμή στο `motion.pptx`. Η εισαγωγή μετατοπίζει την παλιά γραμμή στον δείκτη 2.

Αυτό δείχνει την αντικατάσταση ενός αντικειμένου εντολής αντί για επεξεργασία των υφιστάμενων συντεταγμένων. Μετά την εισαγωγή, η συλλογή περιέχει προσωρινά την αρχική εντολή, τη νέα γραμμή, την παλιά γραμμή και την εντολή λήξης. Η αφαίρεση του δείκτη 2 απορρίπτει την παλιά γραμμή και αφήνει τη νέα διαδρομή στη θέση της.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    path.insert(1, aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, false);
    path.removeAt(2);

    presentation.save("motion-edited.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η αποθηκευμένη διαδρομή εξακολουθεί να έχει τρεις εντολές, με τη νέα γραμμή να λήγει στο (0.2, 0.1) και την εντολή λήξης τέλος.

## **Τροποποίηση και Επαλήθευση Υπάρχουσας Συμπεριφοράς**

Όταν δεν είναι γνωστός ο δείκτης της συμπεριφοράς, επιλέξτε το με βάση τον τύπο. Αυτό το παράδειγμα ανοίγει το `rotation.pptx`, εντοπίζει το [RotationEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/rotationeffect/), αλλάζει την γωνία και ελέγχει την αποθηκευμένη τιμή μετά το ξανά άνοιγμα.

Ο έλεγχος τύπου επιτρέπει στο βρόχο να παραλείψει συμπεριφορές που δεν είναι περιστροφές. Το δεύτερο φόρτωμα διαβάζει το αποθηκευμένο αρχείο σε ξεχωριστό αντικείμενο παρουσίασης, έτσι η σύγκριση ελέγχει τα αποθηκευμένα δεδομένα αντί της τιμής που παραμένει στη μνήμη. Αυτό το παράδειγμα υποθέτει ακόμη ότι το γνωστό εφέ είναι πρώτο στην κύρια ακολουθία· η επιλογή συμπεριφοράς με βάση τον τύπο δεν εντοπίζει το σωστό εφέ σε αυθαίρετη παρουσίαση.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    for (let i = 0; i < effect.getBehaviors().getCount(); i++) {
        const behavior = effect.getBehaviors().get_Item(i);
        if (java.instanceOf(behavior, "com.aspose.slides.IRotationEffect")) {
            const rotation = behavior;
            rotation.setBy(180);
        }
    }

    presentation.save("rotation-edited.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("rotation-edited.pptx");
    try {
        const savedEffect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

        for (let i = 0; i < savedEffect.getBehaviors().getCount(); i++) {
            const behavior = savedEffect.getBehaviors().get_Item(i);
            if (java.instanceOf(behavior, "com.aspose.slides.IRotationEffect")) {
                const rotation = behavior;
                console.log("Rotation preserved: " + (Math.abs(rotation.getBy() - 180) < 0.001));
            }
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Η έξοδος είναι `Rotation preserved: true`. Εφαρμόστε το ίδιο μοτίβο ελέγχου τύπου σε άλλες συμπεριφορές. Για πλήρη έλεγχο διατήρησης, συγκρίνετε το σχήμα-στόχο, το εφέ, τους τύπους και τη σειρά των συμπεριφορών, το χρόνο και τις εντολές διαδρομής. Χρησιμοποιήστε αριθμητική ανοχή για τιμές κινητής υποδιαστολής. Για παρουσίαση με άγνωστο σχεδιασμό κίνησης, δείτε [Ανάγνωση Κινήσεων Σχημάτων](/slides/el/nodejs-java/shape-animation/#read-shape-animations) για τη διέλευση των κύριων και διαδραστικών ακολουθιών.

## **Σειρά Συμπεριφορών, Προεπιλογές και Αναπαραγωγή**

Η σειρά στη [BehaviorCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/behaviorcollection/) είναι η αποθηκευμένη σειρά των λειτουργιών ενός εφέ. Δεν είναι λίστα αναπαραγωγής όπου κάθε συμπεριφορά περιμένει αυτόματα την προηγούμενη. Ο χρόνος και το περιβάλλον εφέ καθορίζουν το χρονοπρόγραμμα. Οι συμπεριφορές μπορούν να επικαλύπτονται, και λειτουργίες στο ίδιο χαρακτηριστικό μπορεί να αλληλεπιδρούν μέσω των [getAdditive](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/behavior/#getAdditive) και [getAccumulate](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/behavior/#getAccumulate). Μην χρησιμοποιείτε μόνο την επαναταξινόμηση της συλλογής για να προγραμματίσετε «μετακίνηση, στη συνέχεια περιστροφή»· χρησιμοποιήστε ρητό χρόνο ή ξεχωριστά εφέ όπως περιγράφεται στην ενότητα [Κίνηση Σχήματος](/slides/el/nodejs-java/shape-animation/).

Τα [getType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/effect/#getType) και [getSubtype](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/effect/#getSubtype) του εφέ περιγράφουν το προεπιλεγμένο εφέ του. Δεν αποτελούν πλήρη περιγραφή ενός επεξεργασμένου δένδρου συμπεριφορών. Επιλέξτε το προεπιλεγμένο εφέ και τον υποτύπο πριν προσαρμόσετε τις συμπεριφορές: η αλλαγή του προεπιλεγμένου εφέ μπορεί να ξαναχτίσει τη συλλογή και να διαγράψει τις προσαρμοσμένες σας λειτουργίες. Για παράδειγμα, η αλλαγή ενός προσαρμοσμένου εφέ Spin σε Fade μπορεί να αντικαταστήσει τη συμπεριφορά περιστροφής με συμπεριφορές set και filter. Ελέγξτε ξανά τη συλλογή μετά την αλλαγή του προεπιλεγμένου εφέ ή του υποτύπου. Η εκκαθάριση των προεπιλεγμένων συμπεριφορών μπορεί επίσης να αφαιρέσει λειτουργίες ορατότητας ή εκκίνησης που απαιτούνται από το προεπιλεγμένο εφέ. Τα παραδείγματα χρησιμοποιούν εκ προθέσεως ορατά σχήματα και αντικαθιστούν τις συμπεριφορές· δεν ανακατασκευάζουν κάθε υλοποίηση προεπιλογής.

## **Συμβατότητα Μορφών**

Ένα διατηρημένο δένδρο συμπεριφορών δεν εγγυάται την ίδια αναπαραγωγή σε κάθε προγράμμα προβολής ή μηχανή εξαγωγής. Ελέγξτε τα αποθηκευμένα δεδομένα και το παραγόμενο αποτέλεσμα ξεχωριστά.

| Μορφή ή έξοδος | Τι πρέπει να ελεγχθεί |
| --- | --- |
| PPTX | Χρησιμοποιήστε το ως κύρια μορφή για αυτά τα παραδείγματα. Ανοίξτε το ξανά για να επαληθεύσετε το επεξεργάσιμο δένδρο συμπεριφορών, έπειτα ελέγξτε την αναπαραγωγή στην επιθυμητή έκδοση του PowerPoint. |
| PPT | Η παλαιότερη δυαδική αναπαράσταση μπορεί να διαφέρει από το PPTX. Δοκιμάστε έναν ξεχωριστό κύκλο αποθήκευσης-ανοίγματος και αναπαραγωγής· μην θεωρείτε ότι υποστηρίζεται κάθε προσαρμοσμένος συνδυασμός με επιτυχία του PPTX. |
| PDF, PNG, JPEG, and other static slide images | Περιέχουν μια στατική αναπαράσταση της διαφάνειας, όχι μια αναγγέλλσιμη χρονογραμμή κίνησης ή εγγυημένο τελικό καρέ κίνησης. |
| [HTML5](/slides/el/nodejs-java/export-to-html5/) | Μπορεί να αναπαράγει υποστηριζόμενες κινήσεις όταν η κίνηση σχήματος είναι ενεργοποιημένη στις επιλογές εξαγωγής. Δοκιμάστε προσαρμοσμένους συνδυασμούς στον περιηγητή. |
| [Animated GIF](/slides/el/nodejs-java/convert-powerpoint-to-animated-gif/) | Αποθηκεύει τα καρέ που αποτυπώνονται, όχι επεξεργάσιμες συμπεριφορές ή αλληλεπιδράσεις που ενεργοποιούνται με κλικ. Ελέγξτε την πραγματική κίνηση που αποτυπώθηκε. |
| [Video](/slides/el/nodejs-java/convert-powerpoint-to-video/) | Αποδίδει τα καρέ κίνησης και τα κωδικοποιεί ως βίντεο. Η υποστήριξη περιορίζεται στις [υποστηριζόμενες κινήσεις και εφέ](/slides/el/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects) του εξαγωγέα· οι εντολές και τα διαδραστικά γεγονότα δεν γίνονται επεξεργάσιμη χρονογραμμή. |

## **Συχνές Ερωτήσεις**

**Γιατί το εφέ μου περιέχει συμπεριφορές πριν προσθέσω κάτι;**

Δημιουργώντας ένα προεπιλεγμένο εφέ μπορεί να δημιουργήσει τις υποκείμενες λειτουργίες του. Επιθεωρήστε τις πριν αποφασίσετε αν θα επεκτείνετε το προεπιλεγμένο εφέ ή θα αντικαταστήσετε τις συμπεριφορές του.

**Κάνει η μετακίνηση μιας συμπεριφοράς στην αρχή να παίζει πρώτη;**

Δεν είναι απαραίτητα. Η σειρά της συλλογής δεν υποκαθιστά τον χρόνο. Ελέγξτε τις καθυστερήσεις, τις διάρκειες και τις αλληλεπιδράσεις μεταξύ λειτουργιών στο ίδιο χαρακτηριστικό.

**Γιατί μια εντολή λήξης δεν έχει σημεία;**

Σηματοδοτεί το τέλος της διαδρομής και δεν χρειάζονται συντεταγμένες. Ελέγξτε για έναν μηδενικό πίνακα σημείων όταν επιθεωρείτε μια διαδρομή που διαβάζεται από αρχείο.

**Είναι ένα επιτυχημένο κύκλο γύρο αρκετό για να επιβεβαιώσει την αναπαραγωγή;**

Όχι. Το άνοιγμα ξανά επιβεβαιώνει τη διατήρηση των ιδιοτήτων που ελέγξατε. Δοκιμάστε τον αναπαραγωγό παρουσίασης ή την εξαγωγή με κινούμενα γραφικά ξεχωριστά για να επιβεβαιώσετε τη μορφή συμπεριφοράς του.