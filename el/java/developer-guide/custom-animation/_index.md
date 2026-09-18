---
title: Δημιουργία και Τροποποίηση Προσαρμοσμένων Συμπεριφορών Κίνησης σε Java
linktitle: Προσαρμοσμένη Κίνηση
type: docs
weight: 151
url: /el/java/custom-animation/
keywords:
- προσαρμοσμένη κίνηση
- συμπεριφορά κίνησης
- διαδρομή κίνησης
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Δημιουργήστε, ελέγξτε και τροποποιήστε προσαρμοσμένες συμπεριφορές κίνησης και επεξεργάσιμες διαδρομές κίνησης σε παρουσιάσεις PowerPoint με το Aspose.Slides για Java."
---
## **Επισκόπηση**

Οι προσαρμοσμένες συμπεριφορές κίνησης σάς επιτρέπουν να ελέγχετε μεμονωμένες λειτουργίες εντός ενός εφέ κίνησης, όπως η αλλαγή χρώματος, η περιστροφή ενός σχήματος ή η ακολουθία μιας επεξεργάσιμης διαδρομής κίνησης. Αυτός ο οδηγός δείχνει πώς να δημιουργήσετε και να συνδυάσετε συμπεριφορές, να ρυθμίσετε το χρονισμό τους, να ελέγξετε και να τροποποιήσετε υπάρχουσες κινήσεις και να επιβεβαιώσετε ότι οι ιδιότητές τους παραμένουν μετά την αποθήκευση και το άνοιγμα μιας παρουσίασης.

Για προ-ορισμένα εφέ και ενεργοποιητές κλικ, δείτε [Κίνηση Σχήματος](/slides/el/java/shape-animation/).

## **Κατανόηση του Μοντέλου Κίνησης**

Μια κίνηση οργανώνεται ως **Timeline → Sequence → Effect → Behaviors**:

- Η μέθοδος [getTimeline](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibaseslide/#getTimeline--) επιστρέφει το χρονοδιάγραμμα της διαφάνειας, το οποίο περιέχει την κύρια ακολουθία του και τις διαδραστικές ακολουθίες.
- Ένα [ISequence](https://reference.aspose.com/slides/el/java/com.aspose.slides/isequence/) περιέχει εφέ, πιθανώς με διαφορετικά σχήματα-στόχους.
- Ένα [IEffect](https://reference.aspose.com/slides/el/java/com.aspose.slides/ieffect/) προσδιορίζει το σχήμα-στόχο, το προεπιλεγμένο εφέ, τον υποτύπο και το χρονισμό του εφέ.
- Η συλλογή που επιστρέφει το [IEffect.getBehaviors](https://reference.aspose.com/slides/el/java/com.aspose.slides/ieffect/#getBehaviors--) περιλαμβάνει τις λειτουργίες που υλοποιούν το εφέ: αλλαγή χρώματος, μετακίνηση, περιστροφή, ορισμός ιδιότητας κλπ.

## **Δημιουργία Μεμονωμένων Συμπεριφορών**

Καλέστε το [ISequence.addEffect](https://reference.aspose.com/slides/el/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) για να δημιουργήσετε ένα εφέ και να αποκτήσετε πρόσβαση στη συλλογή [getBehaviors](https://reference.aspose.com/slides/el/java/com.aspose.slides/ieffect/#getBehaviors--). Ένα προεπιλεγμένο εφέ μπορεί να γεμίσει αυτή τη συλλογή αυτόματα. Διατηρήστε τις λειτουργίες του όταν επεκτείνετε το προεπιλεγμένο εφέ ή χρησιμοποιήστε το [clear](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibehaviorcollection/#clear--) όταν θέλετε να τις αντικαταστήσετε σκόπιμα.

Το [IBehaviorFactory](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibehaviorfactory/) δημιουργεί τους οκτώ τύπους συμπεριφορών που απεικονίζονται παρακάτω. Η κίνηση καλύπτεται στο [Δημιουργία Διαδρομής Κίνησης](#build-a-motion-path). Κάθε απόσπασμα κώδικα περιέχει τις εισαγωγές του· τοποθετήστε τις εκτελέσιμες δηλώσεις μέσα σε μια μέθοδο. Τα παραδείγματα επεξεργασίας αργότερα αναφέρουν ποιο αρχείο εξόδου χρησιμοποιούν.

### **Περιστροφή**

Χρησιμοποιήστε το [createRotationEffect](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibehaviorfactory/#createRotationEffect--) για να δημιουργήσετε μια περιστροφή. Το [getBy](https://reference.aspose.com/slides/el/java/com.aspose.slides/irotationeffect/#getBy--) ορίζει σχετική γωνία σε μοίρες· τα [getFrom](https://reference.aspose.com/slides/el/java/com.aspose.slides/irotationeffect/#getFrom--) και [getTo](https://reference.aspose.com/slides/el/java/com.aspose.slides/irotationeffect/#getTo--) ορίζουν τα άκρα.

Το παράδειγμα ξεκινά με ένα εφέ Spin, αντικαθιστά τις προεπιλεγμένες λειτουργίες του με μία συμπεριφορά περιστροφής και δίνει στην λειτουργία αυτή διάρκεια δύο δευτερολέπτων. Μία σχετική γωνία 90 μοιρών εκφράζει ένα τέταρτο κύκλο από την αρχική προσανατολισμένη θέση του σχήματος, επομένως δεν απαιτείται ρητή αρχική γωνία.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Spin, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IRotationEffect rotation = factory.createRotationEffect();
    rotation.setBy(90f);
    rotation.getTiming().setDuration(2f);

    effect.getBehaviors().add(rotation);

    presentation.save("rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`rotation.pptx` περιέχει ένα σχήμα και μία συμπεριφορά περιστροφής. Η συλλογή, ο χρονισμός και τα παραδείγματα επεξεργασίας περιστροφής παρακάτω χρησιμοποιούν αυτό το αρχείο.

### **Κλιμάκωση**

Χρησιμοποιήστε το [createScaleEffect](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibehaviorfactory/#createScaleEffect--) με ποσοστά X/Y: τα [getFrom](https://reference.aspose.com/slides/el/java/com.aspose.slides/iscaleeffect/#getFrom--) και [getTo](https://reference.aspose.com/slides/el/java/com.aspose.slides/iscaleeffect/#getTo--) περιγράφουν το αρχικό και το τελικό μέγεθος, ενώ το [getBy](https://reference.aspose.com/slides/el/java/com.aspose.slides/iscaleeffect/#getBy--) περιγράφει μια σχετική αλλαγή. Εδώ, 100 σημαίνει το αρχικό μέγεθος.

Το παράδειγμα αυξάνει και τις δύο διαστάσεις από 100 % σε 125 % σε δύο δευτερόλεπτα. Η χρήση ίσων οριζόντιων και κατακόρυφων ποσοστών διατηρεί τις αναλογίες του σχήματος· διαφορετικά ποσοστά θα τεντώσουν τη μία διάσταση περισσότερο από την άλλη.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setFrom(new Point2D.Float(100, 100));
    scale.setTo(new Point2D.Float(125, 125));
    scale.getTiming().setDuration(2f);

    effect.getBehaviors().add(scale);

    presentation.save("scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Χρώμα**

Χρησιμοποιήστε το [createColorEffect](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibehaviorfactory/#createColorEffect--) για να αλλάξετε τη γέμιση από μπλε σε πορτοκαλί. Τα [getFrom](https://reference.aspose.com/slides/el/java/com.aspose.slides/icoloreffect/#getFrom--) και [getTo](https://reference.aspose.com/slides/el/java/com.aspose.slides/icoloreffect/#getTo--) είναι χρώματα· το [getBy](https://reference.aspose.com/slides/el/java/com.aspose.slides/icoloreffect/#getBy--) είναι μια μετατόπιση χρώματος. Η [IBehavior.getProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibehavior/#getProperties--) προσδιορίζει το χαρακτηριστικό που αναπαράγεται.

Η στερεή γέμιση του σχήματος αρχικοποιείται σε μπλε, ώστε να ταιριάζει με το αρχικό χρώμα του εφέ. Η επιλογή του χαρακτηριστικού γεμίσματος λέει στη συμπεριφορά ποιο μέρος του σχήματος να αλλάξει· τα μόνο τα άκρα των χρωμάτων δεν προσδιορίζουν το χαρακτηριστικό. Το αποθηκευμένο εφέ περιγράφει μια μετάβαση δύο δευτερολέπτων προς το πορτοκαλί.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IColorEffect color = factory.createColorEffect();
    color.getProperties().add(BehaviorProperty.getFillColor().getValue());
    color.getFrom().setColor(Color.BLUE);
    Color orange = new Color(255, 165, 0);
    color.getTo().setColor(orange);
    color.getTiming().setDuration(2f);

    effect.getBehaviors().add(color);

    presentation.save("color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Φίλτρο**

Χρησιμοποιήστε το [createFilterEffect](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibehaviorfactory/#createFilterEffect--) για να επιλέξετε μια αποξήρανση. Τα [getType](https://reference.aspose.com/slides/el/java/com.aspose.slides/ifiltereffect/#getType--), [getSubtype](https://reference.aspose.com/slides/el/java/com.aspose.slides/ifiltereffect/#getSubtype--) και [getReveal](https://reference.aspose.com/slides/el/java/com.aspose.slides/ifiltereffect/#getReveal--) καθορίζουν το φίλτρο, την κατεύθυνση και το αν θα αποκαλυφθεί ή θα κρυφτεί το σχήμα.

Αυτό το παράδειγμα ρυθμίζει μια αποξήρανση δύο δευτερολέπτων που αποκαλύπτει το σχήμα με υποτύπο δεξιάς κατεύθυνσης. Οι ρυθμίσεις του φίλτρου ανήκουν στη συμπεριφορά μέσα στο εφέ, επομένως ρυθμίζονται αφού αφαιρεθούν οι αρχικές λειτουργίες του προεπιλεγμένου εφέ.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Wipe, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IFilterEffect filter = factory.createFilterEffect();
    filter.setType(FilterEffectType.Wipe);
    filter.setSubtype(FilterEffectSubtype.Right);
    filter.setReveal(FilterEffectRevealType.In);
    filter.getTiming().setDuration(2f);

    effect.getBehaviors().add(filter);

    presentation.save("filter.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Ιδιότητα**

Χρησιμοποιήστε το [createPropertyEffect](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibehaviorfactory/#createPropertyEffect--) για να αναπαράγετε τη διαφάνεια. Τα [getFrom](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipropertyeffect/#getFrom--), [getTo](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipropertyeffect/#getTo--) και [getBy](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipropertyeffect/#getBy--) είναι συμβολοσειρές που ερμηνεύονται με χρήση των [getValueType](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipropertyeffect/#getValueType--) και [getCalcMode](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipropertyeffect/#getCalcMode--). Επιλέξτε άκρα ή σχετική μετατόπιση αντί να ορίσετε και τα τρία ανεξάρτητα.

Εδώ, το επιλεγμένο χαρακτηριστικό είναι η διαφάνεια, και οι αριθμητικές συμβολοσειρές αντιπροσωπεύουν αλλαγή από 25 % διαφάνειας σε πλήρη διαφάνεια. Η γραμμική παρεμβολή περιγράφει μια ομαλή αλλαγή μεταξύ των τιμών. Όταν προσαρμόζετε αυτό το παράδειγμα σε άλλο χαρακτηριστικό, επιλέξτε τύπο τιμής και τιμές άκρων κατάλληλες για αυτό το χαρακτηριστικό.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IPropertyEffect property = factory.createPropertyEffect();
    property.getProperties().add(BehaviorProperty.getStyleOpacity().getValue());
    property.setValueType(PropertyValueType.Number);
    property.setCalcMode(PropertyCalcModeType.Linear);
    property.setFrom("0.25");
    property.setTo("1");
    property.getTiming().setDuration(2f);

    effect.getBehaviors().add(property);

    presentation.save("property.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Ορισμός**

Χρησιμοποιήστε το [createSetEffect](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibehaviorfactory/#createSetEffect--) για να ορίσετε την ορατότητα μέσω του [getTo](https://reference.aspose.com/slides/el/java/com.aspose.slides/iseteffect/#getTo--). Μία συμπεριφορά set δεν παρεμβάλλει μεταξύ των άκρων.

Το παράδειγμα επιλέγει το χαρακτηριστικό ορατότητας και ορίζει τη συμβολοσειρά `visible` όταν εκτελείται η συμπεριφορά. Το ορθογώνιο είναι ήδη ορατό σε αυτήν τη μινιμαλιστική παρουσίαση, έτσι η ανάθεση μπορεί να μην προκαλέσει εμφανή οπτική αλλαγή από μόνη της. Μια τέτοια λειτουργία είναι χρήσιμη ως μέρος ενός μεγαλύτερου εφέ που ελέγχει επίσης πότε το σχήμα κρύβεται ή γίνεται ορατό.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Appear, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    ISetEffect set = factory.createSetEffect();
    set.getProperties().add(BehaviorProperty.getStyleVisibility().getValue());
    set.setTo("visible");

    effect.getBehaviors().add(set);

    presentation.save("set.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Εντολή**

Χρησιμοποιήστε το [createCommandEffect](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibehaviorfactory/#createCommandEffect--) και ρυθμίστε τα [getType](https://reference.aspose.com/slides/el/java/com.aspose.slides/icommandeffect/#getType--), [getCommandString](https://reference.aspose.com/slides/el/java/com.aspose.slides/icommandeffect/#getCommandString--) και [getShapeTarget](https://reference.aspose.com/slides/el/java/com.aspose.slides/icommandeffect/#getShapeTarget--). Τοποθετήστε ένα αρχείο ήχου WAV με όνομα `sample.wav` στον τρέχοντα φάκελο. Αυτό το παράδειγμα το ενσωματώνει με το [addAudioFrameEmbedded](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) και προσθέτει μια εντολή αναπαραγωγής στο πλαίσιο ήχου.

Το πλαίσιο ήχου είναι ταυτόχρονα στόχος του εφέ και στόχος της εντολής. Αυτό συνδέει το αίτημα αναπαραγωγής με την ενσωματωμένη ηχογράφησή του· μία απλή συμβολοσειρά εντολής δεν προσδιορίζει ποιο αντικείμενο πολυμέσων ελέγχει. Το εφέ ρυθμίζεται να ξεκινά με κλικ κατά τη διάρκεια της παρουσίασης.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.IOException;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    try (FileInputStream audioStream = new FileInputStream("sample.wav")) {
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audioStream);

        IEffect effect = slide.getTimeline().getMainSequence().addEffect(audioFrame, EffectType.MediaPlay, EffectSubtype.None, EffectTriggerType.OnClick);
        effect.getBehaviors().clear();

        IBehaviorFactory factory = new BehaviorFactory();
        ICommandEffect command = factory.createCommandEffect();
        command.setType(CommandEffectType.Call);
        command.setCommandString("play");
        command.setShapeTarget(audioFrame);

        effect.getBehaviors().add(command);

        presentation.save("command.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Unable to read sample.wav: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

Η αποθήκευση καταγράφει την εντολή σε `command.pptx`; δεν αναπαράγει την ηχογράφηση. Η αναπαραγωγή απαιτεί έναν αναπαραγωγέα παρουσίασης που υποστηρίζει την εντολή και το μέσο-στόχο της.

## **Διαχείριση της Συλλογής Συμπεριφορών**

Το [IBehaviorCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibehaviorcollection/) υποστηρίζει τα [add](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibehaviorcollection/#add-com.aspose.slides.IBehavior-), [insert](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibehaviorcollection/#insert-int-com.aspose.slides.IBehavior-), [remove](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibehaviorcollection/#remove-com.aspose.slides.IBehavior-), και [removeAt](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibehaviorcollection/#removeAt-int-). Αυτό το παράδειγμα ανοίγει το `rotation.pptx`, προσθέτει κλιμάκωση, τη μετακινεί πριν από την περιστροφή και αφαιρεί την περιστροφή. Η αφαίρεση και η επανεισαγωγή του ίδιου αντικειμένου αλλάζει τη θέση του χωρίς να γίνει αντίγραφο.

Η σειρά των επεξεργασιών αλλάζει τη συλλογή από περιστροφή–κλιμάκωση σε κλιμάκωση–περιστροφή και στη συνέχεια μόνο σε κλιμάκωση. Οι δείκτες αναφέρονται στη τρέχουσα συλλογή, επομένως η αφαίρεση χρησιμοποιεί το νέο δείκτη της περιστροφής μετά την επαναδιάταξη. Η τελική απαρίθμηση επιβεβαιώνει ποια συμπεριφορά θα αποθηκευτεί.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IBehaviorCollection behaviors = effect.getBehaviors();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setTo(new Point2D.Float(125, 125));
    scale.getTiming().setDuration(2f);

    behaviors.add(scale);

    behaviors.remove(scale);
    behaviors.insert(0, scale);
    behaviors.removeAt(1);

    for (IBehavior behavior : behaviors)
        System.out.println(behavior.getClass().getSimpleName());

    presentation.save("collection-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η έξοδος είναι `ScaleEffect`: απομένει μόνο η κλιμάκωση. Η σειρά της συλλογής από μόνη της δεν προγραμματίζει τις συμπεριφορές μία μετά την άλλη. Καθαρίστε τη συλλογή μόνο όταν αντικαθιστάτε όλες τις λειτουργίες της.

## **Ρύθμιση Χρονισμού Συμπεριφοράς**

Το [IBehavior.getTiming](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibehavior/#getTiming--) εκθέτει το [ITiming](https://reference.aspose.com/slides/el/java/com.aspose.slides/itiming/), ανεξάρτητα από το [IEffect.getTiming](https://reference.aspose.com/slides/el/java/com.aspose.slides/ieffect/#getTiming--). Ο χρονισμός του εφέ προγραμματίζει το περιβάλλον εφέ· ο χρονισμός της συμπεριφοράς περιγράφει μια λειτουργία μέσα σε αυτό.

### **Ορισμός Διάρκειας, Καθυστέρησης, Επανάληψης και Επιτάχυνσης**

Ανοίξτε το `rotation.pptx` και ορίστε τη διάρκεια ([getDuration](https://reference.aspose.com/slides/el/java/com.aspose.slides/itiming/#getDuration--)) και την καθυστέρηση ενεργοποίησης ([getTriggerDelayTime](https://reference.aspose.com/slides/el/java/com.aspose.slides/itiming/#getTriggerDelayTime--)) σε δευτερόλεπτα, στη συνέχεια ρυθμίστε τον αριθμό επαναλήψεων μέσω του [setRepeatCount](https://reference.aspose.com/slides/el/java/com.aspose.slides/itiming/#setRepeatCount-float-). Τα [getAccelerate](https://reference.aspose.com/slides/el/java/com.aspose.slides/itiming/#getAccelerate--) και [getDecelerate](https://reference.aspose.com/slides/el/java/com.aspose.slides/itiming/#getDecelerate--) είναι κλάσματα της διάρκειας· κρατήστε το άθροισμά τους το πολύ 1.

Το αρχείο εισόδου είναι εκείνο που δημιουργήθηκε στο παράδειγμα περιστροφής, όπου η πρώτη συμπεριφορά είναι γνωστή ότι είναι περιστροφή. Αυτό το παράδειγμα αλλάζει μόνο τον χρονισμό εκείνης της συμπεριφοράς· η γωνία των 90 μοιρών παραμένει αμετάβλητη. Η διατήρηση της γωνίας και του χρονισμού ξεχωριστά καθιστά πιο εύκολη τη ρύθμιση του ρυθμού χωρίς την ανάγκη επανακατασκευής της κίνησης.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IRotationEffect rotation = (IRotationEffect)effect.getBehaviors().get_Item(0);
    rotation.getTiming().setDuration(2f);
    rotation.getTiming().setTriggerDelayTime(0.5f);
    rotation.getTiming().setRepeatCount(3f);
    rotation.getTiming().setAccelerate(0.2f);
    rotation.getTiming().setDecelerate(0.2f);

    presentation.save("timing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η συμπεριφορά χρησιμοποιεί διάρκεια δύο δευτερολέπτων, καθυστέρηση μισού δευτερολέπτου και αριθμό επαναλήψεων 3. Τα πρώτα και τα τελευταία 20 % της διάρκειας χρησιμοποιούνται για επιτάχυνση και επιβράδυνση.

Άλλες πολιτικές επανάληψης περιλαμβάνουν τα [getRepeatDuration](https://reference.aspose.com/slides/el/java/com.aspose.slides/itiming/#getRepeatDuration--), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/el/java/com.aspose.slides/itiming/#getRepeatUntilEndSlide--), και [getRepeatUntilNextClick](https://reference.aspose.com/slides/el/java/com.aspose.slides/itiming/#getRepeatUntilNextClick--); επιλέξτε μία πολιτική αντί να τις ενεργοποιήσετε όλες μαζί. Το [getAutoReverse](https://reference.aspose.com/slides/el/java/com.aspose.slides/itiming/#getAutoReverse--) παίζει το εφέ ανάποδα μετά το προωθητικό πέρασμα. Η επιτάχυνση και η επιβράδυνση εφαρμόζονται σε συνεχείς αλλαγές, όχι σε διακριτές αναθέσεις ή εντολές.

## **Δημιουργία Διαδρομής Κίνησης**

Χρησιμοποιήστε το [createMotionEffect](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibehaviorfactory/#createMotionEffect--) για να δημιουργήσετε κίνηση. Τα [getFrom](https://reference.aspose.com/slides/el/java/com.aspose.slides/imotioneffect/#getFrom--), [getTo](https://reference.aspose.com/slides/el/java/com.aspose.slides/imotioneffect/#getTo--) και [getBy](https://reference.aspose.com/slides/el/java/com.aspose.slides/imotioneffect/#getBy--) περιγράφουν συντεταγμένες ή μετατοπίσεις βάσει ποσοστών. Για επεξεργάσιμη διαδρομή, δημιουργήστε ένα [MotionPath](https://reference.aspose.com/slides/el/java/com.aspose.slides/motionpath/) και αναθέστε το με το [IMotionEffect.setPath](https://reference.aspose.com/slides/el/java/com.aspose.slides/imotioneffect/#setPath-com.aspose.slides.IMotionPath-). Το [IMotionPath](https://reference.aspose.com/slides/el/java/com.aspose.slides/imotionpath/) αποθηκεύει τις εντολές της διαδρομής.

[MotionCommandPathType](https://reference.aspose.com/slides/el/java/com.aspose.slides/motioncommandpathtype/) επιλέγει τη λειτουργία:

| Εντολή | Σημεία | Σημασία |
| --- | --- | --- |
| MoveTo | Ένα | Ορίζει τη θέση εκκίνησης. |
| LineTo | Ένα | Μετακινεί κατά ευθεία λωρίδα μέχρι το άκρο της. |
| CurveTo | Τρία | Ακολουθεί μια κυρτή καμπύλη που ορίζεται από δύο σημεία ελέγχου και ένα άκρο. |
| CloseLoop | Καθόλου | Επιστρέφει στη θέση εκκίνησης. |
| End | Καθόλου | Ολοκληρώνει τη διαδρομή. |

[MotionPathPointsType](https://reference.aspose.com/slides/el/java/com.aspose.slides/motionpathpointstype/) περιγράφει χαρακτηριστικά επεξεργασίας σημείων, όπως γωνιακά ή λειανό σημείο. Δεν αντικαθιστά τον τύπο εντολής. Χρησιμοποιήστε τύπο σημείου καμπύλης για το παράδειγμα καμπύλης παρακάτω και τύπο σημείου γωνίας για τα ευθείες τμήματα.

Οι συντεταγμένες της διαδρομής κανονικοποιούνται ως διαστάσεις της διαφάνειας: μια μετατόπιση X 0,25 αντιπροσωπεύει το ένα τέταρτο του πλάτους της διαφάνειας, όχι 0,25 μονάδες. Θετικό Y τρέχει προς τα κάτω. Οι απόλυτες εντολές καθορίζουν θέσεις στο σύστημα συντεταγμένων της διαδρομής· οι σχετικές εντολές καθορίζουν μετατοπίσεις από τη τρέχουσα θέση. Αυτό είναι ξεχωριστό από το [getOrigin](https://reference.aspose.com/slides/el/java/com.aspose.slides/imotioneffect/#getOrigin--), που επιλέγει το πλαίσιο αναφοράς της διαδρομής, και το [getPathEditMode](https://reference.aspose.com/slides/el/java/com.aspose.slides/imotioneffect/#getPathEditMode--), που ελέγχει πώς η διαδρομή κινείται όταν το σχήμα μετακινείται.

### **Δημιουργία Ευθείας Διαδρομής**

Δημιουργήστε μια συμπεριφορά κίνησης με σημείο εκκίνησης, ένα ευθύ τμήμα και μια εντολή τέλους. Το [IMotionPath.add](https://reference.aspose.com/slides/el/java/com.aspose.slides/imotionpath/#add-int-java.awt.geom.Point2D.Float---int-boolean-) λαμβάνει τον τύπο εντολής, τα σημεία του, τον τύπο σημείου και μια σημαία σχετικής συντεταγμένης.

Η εντολή εκκίνησης θέτει (0, 0) και η γραμμή τερματίζει στο (0.25, 0), δίνοντας στη διαδρομή οριζόντια μετατόπιση ενός τέταρτου του πλάτους της διαφάνειας. Η εντολή τέλους δεν έχει σημεία συντεταγμένων. Μόλις η διαδρομή εκχωρηθεί, η προσθήκη της συμπεριφοράς κίνησης στο εφέ συνδέει αυτή τη διαδρομή με το ορθογώνιο.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.PathRight, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IMotionEffect motion = factory.createMotionEffect();
    motion.setOrigin(MotionOriginType.Layout);
    motion.getTiming().setDuration(2f);

    IMotionPath path = new MotionPath();
    path.add(MotionCommandPathType.MoveTo, new Point2D.Float[] { new Point2D.Float(0, 0) }, MotionPathPointsType.Auto, false);
    path.add(MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.25f, 0) }, MotionPathPointsType.Corner, false);
    path.add(MotionCommandPathType.End, new Point2D.Float[0], MotionPathPointsType.None, false);

    motion.setPath(path);
    effect.getBehaviors().add(motion);

    presentation.save("motion.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion.pptx` περιέχει μία συμπεριφορά κίνησης με τρεις εντολές διαδρομής. Τα παρακάτω παραδείγματα επεξεργασίας αρχείων χρησιμοποιούν αυτή τη γνωστή δομή.

### **Σύγκριση Απόλυτων και Σχετικών Συντεταγμένων**

Αυτά τα δύο αντικείμενα διαδρομής περιγράφουν την ίδια διαδρομή. Η απόλυτη εντολή λήγει στο (0.3, 0.1); η σχετική εντολή προσθέτει (0.1, 0.1) στη τρέχουσα θέση, (0.2, 0).

Και οι δύο διαδρομές ξεκινούν από το ίδιο σημείο. Στη σχετική γραμμή, προσθέτετε τις μετατοπίσεις X και Y στη τρέχουσα θέση για να πάρετε το άκρο· στην απόλυτη γραμμή διαβάζετε το άκρο άμεσα. Η αλλαγή της σημαίας χωρίς μετατροπή των συντεταγμένων θα περιέγραφε διαφορετική διαδρομή.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

MotionPath absolutePath = new MotionPath();
absolutePath.add(MotionCommandPathType.MoveTo, new Point2D.Float[] { new Point2D.Float(0.2f, 0) }, MotionPathPointsType.Auto, false);
absolutePath.add(MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.3f, 0.1f) }, MotionPathPointsType.Corner, false);

MotionPath relativePath = new MotionPath();
relativePath.add(MotionCommandPathType.MoveTo, new Point2D.Float[] { new Point2D.Float(0.2f, 0) }, MotionPathPointsType.Auto, false);
relativePath.add(MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.1f, 0.1f) }, MotionPathPointsType.Corner, true);
```

Αναθέστε είτε τη μία είτε την άλλη διαδρομή σε μια συμπεριφορά κίνησης για χρήση στην παρουσίαση. Το τελικό Boolean όρισμα επιλέγει σχετικές συντεταγμένες για εκείνη την εντολή.

### **Αντικατάσταση Γραμμής με Καμπύλη**

Ανοίξτε το `motion.pptx` και αντικαταστήστε την εντολή γραμμής του με μια κυρτή καμπύλη. Πρώτα δώστε τα δύο σημεία ελέγχου, στη συνέχεια το άκρο.

Η θέση εκκίνησης παρέχεται από την προηγούμενη εντολή. Τα πρώτα δύο σημεία διαμορφώνουν την καμπύλη, ενώ το τρίτο είναι ο προορισμός· δεν είναι τρία διαδοχικά σημεία προορισμού. Η ενημέρωση του τύπου εντολής, του τύπου επεξεργασίας σημείων και του πίνακα σημείων μαζί διατηρεί το τμήμα σύμφωνο με τη νέα γεωμετρία του.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo);
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth);
    path.get_Item(1).setPoints(new Point2D.Float[] { new Point2D.Float(0.1f, 0), new Point2D.Float(0.2f, 0.1f), new Point2D.Float(0.3f, 0.1f) });

    presentation.save("curve.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η διαδρομή στο `curve.pptx` εξακολουθεί να έχει τρεις εντολές· η ενδιάμεση εντολή τώρα ορίζει μια καμπύλη.

## **Ανάγνωση και Επεξεργασία Αποθηκευμένης Διαδρομής**

Κάθε [IMotionCmdPath](https://reference.aspose.com/slides/el/java/com.aspose.slides/imotioncmdpath/) εκθέτει τα [getPoints](https://reference.aspose.com/slides/el/java/com.aspose.slides/imotioncmdpath/#getPoints--), [getCommandType](https://reference.aspose.com/slides/el/java/com.aspose.slides/imotioncmdpath/#getCommandType--), [getPointsType](https://reference.aspose.com/slides/el/java/com.aspose.slides/imotioncmdpath/#getPointsType--), και [isRelative](https://reference.aspose.com/slides/el/java/com.aspose.slides/imotioncmdpath/#isRelative--). Τα παρακάτω παραδείγματα χρησιμοποιούν τη γνωστή διαδρομή τριών εντολών στο `motion.pptx`. Για αυθαίρετο εισερχόμενο, εντοπίστε το επιθυμητό εφέ και ελέγξτε τους τύπους εντολών και τον αριθμό σημείων πριν την επεξεργασία με δείκτη.

### **Ανάγνωση Εντολών και Συντεταγμένων**

Διαβάστε τη διαδρομή χωρίς αλλαγές. Οι εντολές τέλος και κλεισίματος δεν απαιτούν σημεία, επομένως επιτρέψτε έναν μηδενικό πίνακα σημείων.

Η έξοδος αντιστοιχίζει κάθε αριθμητικό τύπο εντολής με τη σημαία σχετικής συντεταγμένης πριν την απαρίθμηση των σημείων του. Αυτό σας επιτρέπει να διακρίνετε ένα άκρο από μια μετατόπιση πριν την τροποποίηση της διαδρομής. Μια καμπύλη θα εμφανίσει τρία σημεία, ενώ η ευθεία γραμμή σε αυτό το αρχείο εμφανίζει μόνο ένα.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    for (IMotionCmdPath segment : path)
    {
        System.out.println(segment.getCommandType() + ", relative: " + segment.isRelative());
        if (segment.getPoints() != null)
            for (Point2D.Float point : segment.getPoints())
                System.out.println("X=" + point.x + ", Y=" + point.y);
    }
} finally {
    presentation.dispose();
}
```

Η λίστα περιέχει ένα σημείο εκκίνησης, μια απόλυτη γραμμή που λήγει στο (0.25, 0) και μια εντολή τέλους.

### **Αλλαγή Άκρου**

Ανοίξτε το `motion.pptx` και αντικαταστήστε τον πίνακα σημείων της γραμμής για να αλλάξετε το άκρο της.

Στο αρχείο εισόδου, ο δείκτης 0 είναι η εντολή εκκίνησης και ο δείκτης 1 είναι η γραμμή. Αντικαθιστώντας το μοναδικό σημείο της γραμμής αλλάζετε τον προορισμό της χωρίς να αλλάξετε τον τύπο εντολής, το χρονισμό ή τη θέση στη συλλογή. Επειδή η εντολή χρησιμοποιεί απόλυτές συντεταγμένες, το νέο ζεύγος καθορίζει θέση και όχι πρόσθετη μετατόπιση.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);
    motion.getPath().get_Item(1).setPoints(new Point2D.Float[] { new Point2D.Float(0.4f, 0.1f) });

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η γραμμή στο `motion-endpoint.pptx` λήγει στο (0.4, 0.1); το αρχικό αρχείο παραμένει αμετάβλητο.

### **Αντικατάσταση Τμηματος**

Χρησιμοποιήστε τα [insert](https://reference.aspose.com/slides/el/java/com.aspose.slides/imotionpath/#insert-int-int-java.awt.geom.Point2D.Float---int-boolean-) και [removeAt](https://reference.aspose.com/slides/el/java/com.aspose.slides/imotionpath/#removeAt-int-) για να αντικαταστήσετε τη γραμμή στο `motion.pptx`. Η εισαγωγή μετακινεί την παλιά γραμμή στον δείκτη 2.

Αυτό επιδεικνύει την αντικατάσταση ενός αντικειμένου εντολής αντί την επεξεργασία των υπαρχουσών συντεταγμένων του. Μετά την εισαγωγή, η συλλογή περιλαμβάνει προσωρινά την εντολή εκκίνησης, τη νέα γραμμή, την παλιά γραμμή και την εντολή τέλους. Η αφαίρεση του δείκτη 2 απορρίπτει την παλιά γραμμή και αφήνει τη νέα διαδρομή στη θέση της.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.insert(1, MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.2f, 0.1f) }, MotionPathPointsType.Corner, false);
    path.removeAt(2);

    presentation.save("motion-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η αποθηκευμένη διαδρομή εξακολουθεί να έχει τρεις εντολές, με τη νέα γραμμή να λήγει στο (0.2, 0.1) και την εντολή τέλους στο τέλος.

## **Τροποποίηση και Επαλήθευση Υπάρχουσας Συμπεριφοράς**

Όταν ο δείκτης της συμπεριφοράς δεν είναι γνωστός, επιλέξτε τη βάσει τύπου. Αυτό το παράδειγμα ανοίγει το `rotation.pptx`, εντοπίζει το [IRotationEffect](https://reference.aspose.com/slides/el/java/com.aspose.slides/irotationeffect/), αλλάζει τη γωνία και ελέγχει την αποθηκευμένη τιμή μετά το ξανά άνοιγμα.

Ο έλεγχος τύπου επιτρέπει στην επανάληψη να παραλείψει συμπεριφορές που δεν είναι περιστροφές. Το δεύτερο φόρτωμα διαβάζει το αποθηκευμένο αρχείο σε ξεχωριστό αντικείμενο παρουσίασης, ώστε η σύγκριση να ελέγχει τα δεδομένα που αποθηκεύτηκαν και όχι την τιμή που παραμένει στη μνήμη. Αυτό το παράδειγμα υποθέτει ότι το γνωστό εφέ είναι η πρώτη στην κύρια ακολουθία· η επιλογή συμπεριφοράς βάσει τύπου δεν εντοπίζει το σωστό εφέ σε αυθαίρετη παρουσίαση.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    for (IBehavior behavior : effect.getBehaviors())
    {
        if (behavior instanceof IRotationEffect) {
            IRotationEffect rotation = (IRotationEffect) behavior;
            rotation.setBy(180f);
        }
    }

    presentation.save("rotation-edited.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("rotation-edited.pptx");
    try {
        IEffect savedEffect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

        for (IBehavior behavior : savedEffect.getBehaviors())
        {
            if (behavior instanceof IRotationEffect) {
                IRotationEffect rotation = (IRotationEffect) behavior;
                System.out.println("Rotation preserved: " + (Math.abs(rotation.getBy() - 180f) < 0.001f));
            }
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Η έξοδος είναι `Rotation preserved: true`. Εφαρμόστε το ίδιο μοτίβο ελέγχου τύπου και σε άλλες συμπεριφορές. Για πλήρη έλεγχο διατήρησης, συγκρίνετε το σχήμα-στόχο, το εφέ, τους τύπους και τη σειρά των συμπεριφορών, το χρονισμό, και τις εντολές διαδρομής. Χρησιμοποιήστε αριθμητική ανοχή για τιμές κινητής υποδιαστολής. Για παρουσίαση με άγνωστη διάταξη κίνησης, δείτε [Ανάγνωση Κινήσεων Σχημάτων](/slides/el/java/shape-animation/#read-shape-animations) για την περιήγηση των κύριων και διαδραστικών ακολουθιών.

## **Σειρά Συμπεριφορών, Προεπιλογές και Αναπαραγωγή**

Η σειρά στο [IBehaviorCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibehaviorcollection/) είναι η αποθηκευμένη σειρά των λειτουργιών ενός εφέ. Δεν είναι λίστα αναπαραγωγής στην οποία κάθε συμπεριφορά περιμένει αυτόματα την προηγούμενη. Ο χρονισμός και το περιβάλλον εφέ καθορίζουν τον προγραμματισμό. Οι συμπεριφορές μπορεί να επικαλύπτονται, και οι λειτουργίες στο ίδιο χαρακτηριστικό μπορεί να αλληλεπιδρούν μέσω των [getAdditive](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibehavior/#getAdditive--) και [getAccumulate](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibehavior/#getAccumulate--). Μην χρησιμοποιείτε μόνο την επαναδιάταξη της συλλογής για να προγραμματίσετε «μετακίνηση, έπειτα περιστροφή»· χρησιμοποιήστε ρητό χρονισμό ή ξεχωριστά εφέ όπως περιγράφεται στο [Κίνηση Σχήματος](/slides/el/java/shape-animation/).

Ο [getType](https://reference.aspose.com/slides/el/java/com.aspose.slides/ieffect/#getType--) και ο [getSubtype](https://reference.aspose.com/slides/el/java/com.aspose.slides/ieffect/#getSubtype--) του εφέ περιγράφουν το προεπιλεγμένο εφέ. Δεν αποτελεί πλήρη περιγραφή ενός επεξεργασμένου δέντρου συμπεριφορών. Επιλέξτε το προεπιλεγμένο εφέ και τον υποτύπο πριν προσαρμόσετε τις συμπεριφορές: η αλλαγή του προεπιλεγμένου εφέ μπορεί να ξαναχτίσει τη συλλογή και να διαγράψει τις προσαρμοσμένες λειτουργίες σας. Για παράδειγμα, η αλλαγή ενός προσαρμοσμένου εφέ Spin σε Fade μπορεί να αντικαταστήσει τη συμπεριφορά περιστροφής με συμπεριφορές set και filter. Ελέγξτε ξανά τη συλλογή μετά την αλλαγή προεπιλογής ή υποτύπου. Η εκκαθάριση των προεπιλεγμένων συμπεριφορών μπορεί επίσης να αφαιρέσει λειτουργίες ορατότητας ή αρχικοποίησης που απαιτούνται από την προεπιλογή. Τα παραδείγματα χρησιμοποιούν ορατά σχήματα και αντικαθιστούν τις συμπεριφορές· δεν αναδημιουργούν ολόκληρη την υλοποίηση κάθε προεπιλογής.

## **Συμβατότητα Μορφής**

Ένα διατηρημένο δέντρο συμπεριφορών δεν εγγυάται ταυτοπαθή αναπαραγωγή σε κάθε προβολέα ή εξαγωγέα. Ελέγξτε τα αποθηκευμένα δεδομένα και το παραγόμενο αποτέλεσμα ξεχωριστά.

| Μορφή ή έξοδος | Τι να ελεγχθεί |
| --- | --- |
| PPTX | Χρησιμοποιήστε ως κύρια μορφή για αυτά τα παραδείγματα. Ανοίξτε ξανά το αρχείο για να επαληθεύσετε το επεξεργάσιμο δέντρο συμπεριφορών, έπειτα ελέγξτε την αναπαραγωγή στην προορισμένη έκδοση του PowerPoint. |
| PPT | Η κληρονομική δυαδική αναπαράσταση μπορεί να διαφέρει από το PPTX. Εκτελέστε ξεχωριστό κύκλο αποθήκευσης‑ανοίγματος και ελέγξτε την αναπαραγωγή· μην συμπεραίνετε υποστήριξη για κάθε προσαρμοσμένο συνδυασμό από την επιτυχή έξοδο PPTX. |
| PDF, PNG, JPEG και άλλες στατικές εικόνες διαφανειών | Περιέχουν στατική αναπαράσταση διαφάνειας, όχι ένα εκτελέσιμο χρονοδιάγραμμα ή εγγυημένο τελικό καρέ κίνησης. |
| [HTML5](/slides/el/java/export-to-html5/) | Μπορεί να αναπαράγει υποστηριζόμενες κινήσεις όταν η κίνηση σχήματος είναι ενεργοποιημένη στις επιλογές εξαγωγής. Δοκιμάστε προσαρμοσμένους συνδυασμούς στο πρόγραμμα περιήγησης. |
| [Animated GIF](/slides/el/java/convert-powerpoint-to-animated-gif/) | Αποθηκεύει αποσπασμένα καρέ, όχι επεξεργάσιμες κινήσεις ή αλληλεπιδράσεις κλικ. Ελέγξτε την πραγματική αποτυπωμένη κίνηση. |
| [Video](/slides/el/java/convert-powerpoint-to-video/) | Εξάγει καρέ κίνησης και τα κωδικοποιεί ως βίντεο. Η υποστήριξη περιορίζεται στις [υποστηριζόμενες κινήσεις και εφέ](/slides/el/java/convert-powerpoint-to-video/#supported-animations-and-effects) του εξαγωγέα· εντολές και διαδραστικά γεγονότα δεν γίνονται επεξεργάσιμο χρονοδιάγραμμα. |

## **Συχνές Ερωτήσεις**

**Γιατί το εφέ μου περιέχει συμπεριφορές πριν προσθέσω καμία;**

Η δημιουργία ενός προεπιλεγμένου εφέ μπορεί να δημιουργήσει τις υποκείμενες λειτουργίες του. Εξετάστε τες πριν αποφασίσετε αν θα επεκτείνετε την προεπιλογή ή θα τις αντικαταστήσετε.

**Κάνει η μετακίνηση μιας συμπεριφοράς στην αρχή το εφέ να παίζει πρώτη;**

Δεν απαραίτητα. Η σειρά της συλλογής δεν υποκαθιστά τον χρονισμό. Ελέγξτε τις καθυστερήσεις, τις διάρκειες και τις αλληλεπιδράσεις μεταξύ λειτουργιών στο ίδιο χαρακτηριστικό.

**Γιατί η εντολή "τέλος" δεν έχει σημεία;**

Σηματοδοτεί το τέλος της διαδρομής και δεν χρειάζεται συντεταγμένες. Ελέγξτε για μηδενικό πίνακα σημείων όταν εξετάζετε μια διαδρομή που διαβάστηκε από αρχείο.

**Αρκεί ένας επιτυχής κύκλος αποθήκευσης‑ανοίγματος για να επιβεβαιωθεί η αναπαραγωγή;**

Όχι. Το ξανά άνοιγμα επιβεβαιώνει τη διατήρηση των ιδιοτήτων που ελέγξατε. Δοκιμάστε τον προβολέα παρουσίασης ή την εξαγωγή σε κίνηση ξεχωριστά για να επιβεβαιώσετε τη οπτική συμπεριφορά.