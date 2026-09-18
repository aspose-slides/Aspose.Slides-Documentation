---
title: Δημιουργία και Τροποποίηση Προσαρμοσμένων Συμπεριφορών Κίνησης σε Android
linktitle: Προσαρμοσμένη Κίνηση
type: docs
weight: 151
url: /el/androidjava/custom-animation/
keywords:
- προσαρμοσμένη κίνηση
- συμπεριφορά κίνησης
- μονοπάτι κίνησης
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Δημιουργία, εξέταση και τροποποίηση προσαρμοσμένων συμπεριφορών κίνησης και επεξεργάσιμων μονοπατιών κίνησης σε παρουσιάσεις PowerPoint με το Aspose.Slides για Android μέσω Java."
---
## **Επισκόπηση**

Οι προσαρμοσμένες συμπεριφορές κίνησης σάς επιτρέπουν να ελέγχετε μεμονωμένες λειτουργίες μέσα σε ένα εφέ κίνησης, όπως η αλλαγή χρώματος, η περιστροφή σχήματος ή η ακολουθία ενός επεξεργαστέου μονοπατιού κίνησης. Αυτός ο οδηγός δείχνει πώς να δημιουργείτε και να συνδυάζετε συμπεριφορές, να ρυθμίζετε το χρονοδιάγραμμα τους, να ελέγχετε και να τροποποιείτε υπάρχουσες κινήσεις και να επαληθεύετε ότι οι ιδιότητές τους διατηρούνται κατά την αποθήκευση και το άνοιγμα ξανά μιας παρουσίασης.

Για προκαθορισμένα εφέ και εναύσματα κλικ, δείτε [Κίνηση Σχήματος](/slides/el/androidjava/shape-animation/).

## **Κατανόηση του Μοντέλου Κίνησης**

Μία κίνηση οργανώνεται ως **Χρονοδιάγραμμα → Ακολουθία → Επίδραση → Συμπεριφορές**:

- Η μέθοδος [getTimeline](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibaseslide/#getTimeline--) επιστρέφει το χρονοδιάγραμμα της διαφάνειας, το οποίο περιέχει τη κύρια ακολουθία και τις διαδραστικές ακολουθίες.
- Ένα [ISequence](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isequence/) περιέχει εφέ, που ενδέχεται να στοχεύουν διαφορετικά σχήματα.
- Ένα [IEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ieffect/) προσδιορίζει ένα σχήμα‑στόχο, προκαθορισμένο εφέ, υποτύπο και το χρονοδιάγραμμα του εφέ.
- Η συλλογή που επιστρέφεται από το [IEffect.getBehaviors](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ieffect/#getBehaviors--) περιέχει τις λειτουργίες που υλοποιούν το εφέ: αλλαγή χρώματος, μετακίνηση, περιστροφή, ορισμός ιδιότητας κ.λπ.

## **Δημιουργία Μεμονωμένων Συμπεριφορών**

Καλέστε την [ISequence.addEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) για να δημιουργήσετε ένα εφέ και να αποκτήσετε πρόσβαση στη συλλογή [getBehaviors](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ieffect/#getBehaviors--). Ένα προεπιλεγμένο εφέ μπορεί να γεμίσει αυτή τη συλλογή αυτόματα. Διατηρήστε τις λειτουργίες του όταν επεκτείνετε το προεπιλεγμένο εφέ ή χρησιμοποιήστε το [clear](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibehaviorcollection/#clear--) όταν θέλετε να τις αντικαταστήσετε σκόπιμα.

[IBehaviorFactory](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibehaviorfactory/) δημιουργεί τους οκτώ τύπους συμπεριφορών που απεικονίζονται παρακάτω. Η κίνηση καλύπτεται στην ενότητα [Δημιουργία Μονοπατιού Κίνησης](#build-a-motion-path). Κάθε απόσπασμα περιλαμβάνει τις εισαγωγές του· τοποθετήστε τις εκτελέσιμες δηλώσεις μέσα σε μία μέθοδο. Τα παραδείγματα επεξεργασίας που ακολουθούν αναφέρουν το αρχείο εξόδου που χρησιμοποιούν. Σε Android, αντικαταστήστε τα ονόματα των αρχείων δείγματος με πλήρεις διαδρομές σε κατάλογο προσβάσιμο από την εφαρμογή, όπως ο φάκελος αρχείων της εφαρμογής σας.

### **Περιστροφή**

Χρησιμοποιήστε το [createRotationEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibehaviorfactory/#createRotationEffect--) για να δημιουργήσετε μια περιστροφή. Το [getBy](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/irotationeffect/#getBy--) ορίζει γωνία σχετική σε μοίρες· τα [getFrom](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/irotationeffect/#getFrom--) και [getTo](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/irotationeffect/#getTo--) ορίζουν τα άκρα.

Το παράδειγμα ξεκινά με ένα εφέ Spin, αντικαθιστά τις προεπιλεγμένες λειτουργίες του με μία συμπεριφορά περιστροφής και της δίνει διάρκεια δύο δευτερολέπτων. Μια σχετική γωνία 90 μοιρών εκφράζει μια τέταρτη στροφή από την αρχική προσανατολισμένη θέση του σχήματος, οπότε δεν απαιτείται ρητή αρχική γωνία.

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

`rotation.pptx` περιέχει ένα σχήμα και μία συμπεριφορά περιστροφής. Η συλλογή, το χρονοδιάγραμμα και τα παραδείγματα επεξεργασίας περιστροφής παρακάτω χρησιμοποιούν αυτό το αρχείο.

### **Κλιμάκωση**

Χρησιμοποιήστε το [createScaleEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibehaviorfactory/#createScaleEffect--) με ποσοστά X/Y: τα [getFrom](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iscaleeffect/#getFrom--) και [getTo](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iscaleeffect/#getTo--) περιγράφουν το αρχικό και το τελικό μέγεθος, ενώ το [getBy](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iscaleeffect/#getBy--) περιγράφει μια σχετική μεταβολή. Εδώ, 100 σημαίνει το αρχικό μέγεθος.

Το παράδειγμα αυξάνει και τις δύο διαστάσεις από 100 % σε 125 % σε δύο δευτερόλεπτα. Η χρήση ίσων οριζόντιων και κάθετων ποσοστών διατηρεί τις αναλογίες του σχήματος· διαφορετικά ποσοστά θα τεντώσουν μία διάσταση περισσότερο από την άλλη.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setFrom(new PointF(100, 100));
    scale.setTo(new PointF(125, 125));
    scale.getTiming().setDuration(2f);

    effect.getBehaviors().add(scale);

    presentation.save("scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Χρώμα**

Χρησιμοποιήστε το [createColorEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibehaviorfactory/#createColorEffect--) για να αλλάξετε το γέμισμα από μπλε σε πορτοκαλί. Τα [getFrom](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icoloreffect/#getFrom--) και [getTo](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icoloreffect/#getTo--) είναι χρώματα· το [getBy](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icoloreffect/#getBy--) είναι μια μετατόπιση χρώματος. Το [IBehavior.getProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibehavior/#getProperties--) προσδιορίζει το χαρακτηριστικό που κινείται.

Το σχήμα έχει αρχικό συμπαγές γέμισμα μπλε, ταιριάζοντας με το αρχικό χρώμα της κίνησης. Η επιλογή του χαρακτηριστικού γέμισης ενημερώνει τη συμπεριφορά ποιο μέρος του σχήματος θα αλλάξει· τα άκρα του χρώματος από μόνα τους δεν προσδιορίζουν το χαρακτηριστικό. Το αποθηκευμένο εφέ περιγράφει μια μεταβατική κίνηση δύο δευτερολέπτων προς το πορτοκαλί.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int orange = Color.rgb(255, 165, 0);
    color.getTo().setColor(orange);
    color.getTiming().setDuration(2f);

    effect.getBehaviors().add(color);

    presentation.save("color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Φίλτρο**

Χρησιμοποιήστε το [createFilterEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibehaviorfactory/#createFilterEffect--) για να επιλέξετε ένα σφράγισμα. Τα [getType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ifiltereffect/#getType--), [getSubtype](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ifiltereffect/#getSubtype--), και [getReveal](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ifiltereffect/#getReveal--) ορίζουν το φίλτρο, την κατεύθυνση και το αν θα αποκαλυφθεί ή κρυφτεί το σχήμα.

Αυτό το παράδειγμα ρυθμίζει μια σφράγισμα διάρκειας δύο δευτερολέπτων που αποκαλύπτει το σχήμα χρησιμοποιώντας το υποτύπο δεξιάς κατεύθυνσης. Οι ρυθμίσεις του φίλτρου ανήκουν στη συμπεριφορά μέσα στο εφέ, γι’ αυτό ρυθμίζονται αφού αφαιρεθούν οι αρχικές λειτουργίες του προεπιλεγμένου εφέ.

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

Χρησιμοποιήστε το [createPropertyEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibehaviorfactory/#createPropertyEffect--) για να κινήσετε τη διαφάνεια. Τα [getFrom](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipropertyeffect/#getFrom--), [getTo](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipropertyeffect/#getTo--), και [getBy](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipropertyeffect/#getBy--) είναι αλφαριθμητικά που ερμηνεύονται με τα [getValueType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipropertyeffect/#getValueType--) και [getCalcMode](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipropertyeffect/#getCalcMode--). Επιλέξτε άκρα ή σχετική μετατόπιση αντί να ορίσετε και τις τρεις τιμές αδιαφορητά.

Εδώ, το επιλεγμένο χαρακτηριστικό είναι η διαφάνεια, και οι αριθμητικές αλφαριθμητικές αντιπροσωπεύουν μια αλλαγή από 25 % διαφάνειας σε πλήρη διαφάνεια. Η γραμμική παρεμβολή περιγράφει μια ομαλή μεταβολή μεταξύ των τιμών. Όταν προσαρμόζετε αυτό το παράδειγμα σε άλλο χαρακτηριστικό, επιλέξτε τύπο τιμής και τιμές άκρων κατάλληλες για το συγκεκριμένο χαρακτηριστικό.

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

Χρησιμοποιήστε το [createSetEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibehaviorfactory/#createSetEffect--) για να ορίσετε την ορατότητα μέσω του [getTo](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iseteffect/#getTo--). Μία συμπεριφορά ορισμού δεν παρεμβάλλεται μεταξύ των άκρων.

Το παράδειγμα επιλέγει το χαρακτηριστικό ορατότητας και ορίζει την αλφαριθμητική `visible` όταν εκτελείται η συμπεριφορά. Το ορθογώνιο είναι ήδη ορατό σε αυτή τη μίνι παρουσίαση, έτσι η ανάθεση δεν παράγει προφανή οπτική αλλαγή από μόνη της. Μία τέτοια λειτουργία είναι χρήσιμη ως μέρος ενός μεγαλύτερου εφέ που ελέγχει επίσης πότε το σχήμα κρύβεται ή γίνεται ορατό.

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

Χρησιμοποιήστε το [createCommandEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibehaviorfactory/#createCommandEffect--) και ρυθμίστε τα [getType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icommandeffect/#getType--), [getCommandString](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icommandeffect/#getCommandString--), και [getShapeTarget](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icommandeffect/#getShapeTarget--). Τοποθετήστε ένα αρχείο ήχου WAV με όνομα `sample.wav` στον κατάλογο εργασίας. Αυτό το παράδειγμα το ενσωματώνει με το [addAudioFrameEmbedded](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) και προσθέτει μια εντολή αναπαραγωγής στο πλαίσιο ήχου.

Το πλαίσιο ήχου είναι τόσο ο στόχος του εφέ όσο και ο στόχος της εντολής. Αυτό συνδέει το αίτημα αναπαραγωγής με την ενσωματωμένη ηχογράφηση· μια αλφαριθμητική εντολή από μόνη της δεν προσδιορίζει ποιο αντικείμενο πολυμέσων ελέγχεται. Το εφέ ρυθμίζεται να ξεκινά με κλικ κατά τη διάρκεια της παρουσίασης.

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

Η αποθήκευση αποθηκεύει την εντολή στο `command.pptx`; δεν αναπαράγει την ηχογράφηση. Για αναπαραγωγή απαιτείται ένας προγράμματος παρουσίασης που υποστηρίζει την εντολή και τον στόχο πολυμέσων.

## **Διαχείριση της Συλλογής Συμπεριφορών**

[IBehaviorCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibehaviorcollection/) υποστηρίζει τις μεθόδους [add](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibehaviorcollection/#add-com.aspose.slides.IBehavior-), [insert](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibehaviorcollection/#insert-int-com.aspose.slides.IBehavior-), [remove](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibehaviorcollection/#remove-com.aspose.slides.IBehavior-), και [removeAt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibehaviorcollection/#removeAt-int-). Αυτό το παράδειγμα ανοίγει το `rotation.pptx`, προσθέτει κλιμάκωση, τη μετακινεί πριν την περιστροφή και αφαιρεί την περιστροφή. Η αφαίρεση και επανεισαγωγή του ίδιου αντικειμένου αλλάζει τη θέση του χωρίς να δημιουργεί αντίγραφο.

Η σειρά των επεξεργασιών αλλάζει τη συλλογή από περιστροφή–κλιμάκωση σε κλιμάκωση–περιστροφή και, στη συνέχεια, μόνο κλιμάκωση. Οι δείκτες αναφέρονται στην τρέχουσα συλλογή, έτσι η αφαίρεση χρησιμοποιεί το νέο δείκτη της περιστροφής μετά την αναδιάταξη. Η τελική καταμέτρηση επιβεβαιώνει ποια συμπεριφορά θα αποθηκευτεί.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IBehaviorCollection behaviors = effect.getBehaviors();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setTo(new PointF(125, 125));
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

Το αποτέλεσμα είναι `ScaleEffect`: παραμένει μόνο η κλιμάκωση. Η σειρά της συλλογής δεν προγραμματίζει οι συμπεριφορές μία μετά την άλλη. Καθαρίστε τη συλλογή μόνο όταν αντικαθιστάτε όλες τις λειτουργίες της.

## **Ρύθμιση Χρονοδιαγράμματος Συμπεριφοράς**

[IBehavior.getTiming](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibehavior/#getTiming--) εκθέτει το [ITiming](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itiming/), ανεξάρτητα από το [IEffect.getTiming](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ieffect/#getTiming--). Το χρονοδιάγραμμα του εφέ προγραμματίζει το περιβάλλον εφέ· το χρονοδιάγραμμα της συμπεριφοράς περιγράφει μια λειτουργία εντός αυτού.

### **Ορισμός Διάρκειας, Καθυστέρησης, Επανάληψης και Επιτάχυνσης**

Ανοίξτε το `rotation.pptx` και ορίστε τη διάρκεια ([getDuration](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itiming/#getDuration--)) και την καθυστέρηση ενεργοποίησης ([getTriggerDelayTime](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itiming/#getTriggerDelayTime--)) σε δευτερόλεπτα, μετά ρυθμίστε τον αριθμό επαναλήψεων μέσω του [setRepeatCount](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itiming/#setRepeatCount-float-). Τα [getAccelerate](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itiming/#getAccelerate--) και [getDecelerate](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itiming/#getDecelerate--) είναι κλάσματα της διάρκειας· διατηρήστε το άθροισμά τους το πολύ 1.

Το αρχείο εισόδου είναι αυτό που δημιουργήθηκε στο παράδειγμα περιστροφής, όπου η πρώτη συμπεριφορά είναι γνωστό ότι είναι περιστροφή. Αυτό το παράδειγμα αλλάζει μόνο το χρονοδιάγραμμα εκείνης της συμπεριφοράς· η γωνία των 90 μοιρών παραμένει αμετάβλητη. Η διαχωρισμένη διαχείριση γωνίας και χρονοδιαγράμματος κάνει πιο εύκολο να προσαρμόσετε τον ρυθμό χωρίς να ξαναχτίσετε την κίνηση.

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

Η συμπεριφορά χρησιμοποιεί διάρκεια δύο δευτερολέπτων, καθυστέρηση μισού δευτερολέπτου και αριθμό επαναλήψεων 3. Το πρώτο και το τελευταίο 20 % της διάρκειας χρησιμοποιείται για επιτάχυνση και επιβράδυνση.

Άλλες πολιτικές επανάληψης περιλαμβάνουν τα [getRepeatDuration](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itiming/#getRepeatDuration--), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itiming/#getRepeatUntilEndSlide--), και [getRepeatUntilNextClick](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itiming/#getRepeatUntilNextClick--); επιλέξτε μία πολιτική αντί να τις ενεργοποιήσετε όλες μαζί. Το [getAutoReverse](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itiming/#getAutoReverse--) παίζει την κίνηση ανάποδα μετά το εμπρός πέρασμα. Η επιτάχυνση και η επιβράδυνση ισχύουν σε συνεχείς αλλαγές, όχι σε διακριτές αναθέσεις ή εντολές.

## **Δημιουργία Μονοπατιού Κίνησης**

Χρησιμοποιήστε το [createMotionEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibehaviorfactory/#createMotionEffect--) για να δημιουργήσετε κίνηση. Τα [getFrom](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imotioneffect/#getFrom--), [getTo](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imotioneffect/#getTo--), και [getBy](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imotioneffect/#getBy--) περιγράφουν συντεταγμένες ή μετατοπίσεις βάσει ποσοστών. Για επεξεργάσιμο μονοπάτι, δημιουργήστε ένα [MotionPath](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/motionpath/) και εκχωρήστε το με το [IMotionEffect.setPath](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imotioneffect/#setPath-com.aspose.slides.IMotionPath-). Το [IMotionPath](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imotionpath/) αποθηκεύει τις εντολές του μονοπατιού.

[MotionCommandPathType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/motioncommandpathtype/) επιλέγει τη λειτουργία:

| Εντολή | Σημεία | Νόημα |
| --- | --- | --- |
| MoveTo | One | Ορίζει τη θέση εκκίνησης. |
| LineTo | One | Μετακινείται σε ευθεία γραμμή μέχρι το άκρο. |
| CurveTo | Three | Ακολουθεί μια κυβική καμπύλη ορισμένη από δύο σημεία ελέγχου και ένα άκρο. |
| CloseLoop | None | Επιστρέφει στη θέση εκκίνησης. |
| End | None | Ολοκληρώνει το μονοπάτι. |

[MotionPathPointsType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/motionpathpointstype/) περιγράφει χαρακτηριστικά επεξεργασίας σημείων, όπως γωνιακά ή λείαντα σημεία. Δεν αντικαθιστά τον τύπο εντολής. Χρησιμοποιήστε τύπο σημείου καμπύλης για το παράδειγμα καμπύλης παρακάτω, και τύπο σημείου γωνίας για τα ευθύγραμμα τμήματα.

Οι συντεταγμένες του μονοπατιού είναι κανονικοποιημένες στις διαστάσεις της διαφάνειας: μια μετατόπιση X 0.25 αντιπροσωπεύει το ένα τέταρτο του πλάτους της διαφάνειας, όχι 0.25 μονάδες. Θετικό Y τρέχει προς τα κάτω. Οι απόλυτες εντολές ορίζουν θέσεις στο σύστημα συντεταγμένων του μονοπατιού· οι σχετικές εντολές ορίζουν μετατοπίσεις από την τρέχουσα θέση. Αυτό είναι ξεχωριστό από το [getOrigin](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imotioneffect/#getOrigin--), που επιλέγει το πλαίσιο αναφοράς του μονοπατιού, και το [getPathEditMode](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imotioneffect/#getPathEditMode--), που ελέγχει πώς κινείται το μονοπάτι όταν κινείται το σχήμα.

### **Δημιουργία Ευθύγραμμου Μονοπατιού**

Δημιουργήστε μια συμπεριφορά κίνησης με σημείο εκκίνησης, ένα ευθύγραμμο τμήμα και εντολή λήξης. Η μέθοδος [IMotionPath.add](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imotionpath/#add-int-android.graphics.PointF---int-boolean-) δέχεται τον τύπο εντολής, τα σημεία, τον τύπο σημείου και μια σημαία σχετικών συντεταγμένων.

Η εντολή εκκίνησης καθορίζει (0, 0) και η γραμμή λήγει στο (0.25, 0), δίνοντας στο μονοπάτι οριζόντια μετατόπιση ενός τετάρτου του πλάτους της διαφάνειας. Η εντολή λήξης δεν έχει σημεία συντεταγμένων. Μόλις το μονοπάτι εκχωρηθεί, η προσθήκη της συμπεριφοράς κίνησης στο εφέ συνδέει αυτή τη διαδρομή με το ορθογώνιο.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

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
    path.add(MotionCommandPathType.MoveTo, new PointF[] { new PointF(0, 0) }, MotionPathPointsType.Auto, false);
    path.add(MotionCommandPathType.LineTo, new PointF[] { new PointF(0.25f, 0) }, MotionPathPointsType.Corner, false);
    path.add(MotionCommandPathType.End, new PointF[0], MotionPathPointsType.None, false);

    motion.setPath(path);
    effect.getBehaviors().add(motion);

    presentation.save("motion.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion.pptx` περιέχει μία συμπεριφορά κίνησης με τρεις εντολές μονοπατιού. Τα παρακάτω παραδείγματα επεξεργασίας αρχείων χρησιμοποιούν αυτή τη γνωστή δομή.

### **Σύγκριση Απόλυτων και Σχετικών Συντεταγμένων**

Αυτά τα δύο αντικείμενα μονοπατιού περιγράφουν την ίδια διαδρομή. Η απόλυτη εντολή λήγει στο (0.3, 0.1); η σχετική εντολή προσθέτει (0.1, 0.1) στη τρέχουσα θέση, (0.2, 0).

Και τα δύο μονοπάτια ξεκινούν από την ίδια θέση. Για τη σχετική γραμμή, προσθέστε τις μετατοπίσεις X και Y στην τρέχουσα θέση για να λάβετε το άκρο· για την απόλυτη γραμμή, διαβάστε το άκρο άμεσα. Η αλλαγή της σημαίας χωρίς μετατροπή των συντεταγμένων θα περιείχε διαφορετική διαδρομή.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

MotionPath absolutePath = new MotionPath();
absolutePath.add(MotionCommandPathType.MoveTo, new PointF[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
absolutePath.add(MotionCommandPathType.LineTo, new PointF[] { new PointF(0.3f, 0.1f) }, MotionPathPointsType.Corner, false);

MotionPath relativePath = new MotionPath();
relativePath.add(MotionCommandPathType.MoveTo, new PointF[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
relativePath.add(MotionCommandPathType.LineTo, new PointF[] { new PointF(0.1f, 0.1f) }, MotionPathPointsType.Corner, true);
```

Αναθέστε το ένα ή το άλλο μονοπάτι σε μια συμπεριφορά κίνησης για χρήση σε παρουσίαση. Το τελικό λογικό όρισμα επιλέγει σχετικές συντεταγμένες για εκείνη την εντολή.

### **Αντικατάσταση Γραμμής με Καμπύλη**

Ανοίξτε το `motion.pptx` και αντικαταστήστε την εντολή γραμμής με μια κυβική καμπύλη. Παρέχετε πρώτα τα δύο σημεία ελέγχου, μετά το σημείο άκρου.

Η θέση εκκίνησης παρέχεται από την προηγούμενη εντολή. Τα πρώτα δύο σημεία διαμορφώνουν την καμπύλη, ενώ το τρίτο είναι ο προορισμός· δεν είναι τρία διαδοχικά σημεία προορισμού. Η ενημέρωση του τύπου εντολής, του τύπου επεξεργασίας σημείων και του πίνακα σημείων μαζί διατηρεί το τμήμα συνεπές με τη νέα του γεωμετρία.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo);
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth);
    path.get_Item(1).setPoints(new PointF[] { new PointF(0.1f, 0), new PointF(0.2f, 0.1f), new PointF(0.3f, 0.1f) });

    presentation.save("curve.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το μονοπάτι στο `curve.pptx` διατηρεί τρεις εντολές· η μέση εντολή ορίζεται πλέον ως καμπύλη.

## **Ανάγνωση και Επεξεργασία Αποθηκευμένου Μονοπατιού**

Κάθε [IMotionCmdPath](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imotioncmdpath/) εκθέτει τα [getPoints](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imotioncmdpath/#getPoints--), [getCommandType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imotioncmdpath/#getCommandType--), [getPointsType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imotioncmdpath/#getPointsType--), και [isRelative](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imotioncmdpath/#isRelative--). Τα παρακάτω παραδείγματα χρησιμοποιούν το γνωστό μονοπάτι τριών εντολών στο `motion.pptx`. Για τυχαία είσοδο, εντοπίστε το επιθυμητό εφέ και ελέγξτε τους τύπους εντολών και τον αριθμό σημείων πριν από την επεξεργασία κατά δείκτη.

### **Ανάγνωση Εντολών και Συντεταγμένων**

Διαβάστε το μονοπάτι χωρίς αλλαγές. Οι εντολές End και CloseLoop δεν χρειάζονται σημεία, έτσι πρέπει να επιτρέπεται ένας μηδενικός πίνακας σημείων.

Η έξοδος ζεύγει κάθε αριθμητικό τύπο εντολής με τη σημαία σχετικών συντεταγμένων πριν την καταγραφή των σημείων του. Αυτό σας επιτρέπει να διακρίνετε ένα άκρο από μια μετατόπιση πριν τροποποιήσετε το μονοπάτι. Μία καμπύλη θα καταγράψει τρία σημεία, ενώ η ευθεία γραμμή σε αυτό το αρχείο καταγράφει μόνο ένα.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    for (IMotionCmdPath segment : path)
    {
        System.out.println(segment.getCommandType() + ", relative: " + segment.isRelative());
        if (segment.getPoints() != null)
            for (PointF point : segment.getPoints())
                System.out.println("X=" + point.x + ", Y=" + point.y);
    }
} finally {
    presentation.dispose();
}
```

Η λίστα περιέχει σημείο εκκίνησης, απόλυτη γραμμή που λήγει στο (0.25, 0), και εντολή λήξης.

### **Αλλαγή Ακρουσης**

Ανοίξτε το `motion.pptx` και αντικαταστήστε τον πίνακα σημείων της γραμμής για μετακίνηση του ακρουστικού σημείου.

Στο αρχείο εισόδου, ο δείκτης 0 είναι η εντολή εκκίνησης και ο δείκτης 1 είναι η γραμμή. Η αντικατάσταση του μοναδικού σημείου της γραμμής αλλάζει τον προορισμό της χωρίς αλλαγή του τύπου εντολής, του χρονοδιαγράμματος ή της θέσης στη συλλογή. Επειδή η εντολή χρησιμοποιεί απόλυτες συντεταγμένες, το νέο ζεύγος καθορίζει θέση αντί για προσθήκη μετατόπισης.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);
    motion.getPath().get_Item(1).setPoints(new PointF[] { new PointF(0.4f, 0.1f) });

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η γραμμή στο `motion-endpoint.pptx` λήγει στο (0.4, 0.1); το αρχικό αρχείο παραμένει αμετάβλητο.

### **Αντικατάσταση Τμήματος**

Χρησιμοποιήστε τα [insert](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imotionpath/#insert-int-int-android.graphics.PointF---int-boolean-) και [removeAt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imotionpath/#removeAt-int-) για αντικατάσταση της γραμμής στο `motion.pptx`. Η εισαγωγή μετακινεί την παλιά γραμμή στο δείκτη 2.

Αυτό δείχνει αντικατάσταση ενός αντικειμένου εντολής αντί για επεξεργασία των υφιστάμενων συντεταγμένων του. Μετά την εισαγωγή, η συλλογή περιέχει προσωρινά την εντολή εκκίνησης, τη νέα γραμμή, την παλιά γραμμή και την εντολή λήξης. Η αφαίρεση του δείκτη 2 απορρίπτει την παλιά γραμμή και αφήνει τη νέα διαδρομή στη θέση της.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.insert(1, MotionCommandPathType.LineTo, new PointF[] { new PointF(0.2f, 0.1f) }, MotionPathPointsType.Corner, false);
    path.removeAt(2);

    presentation.save("motion-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποθηκευμένο μονοπάτι διατηρεί τρεις εντολές, με τη νέα γραμμή να λήγει στο (0.2, 0.1) και την εντολή λήξης τελευταία.

## **Τροποποίηση και Επαλήθευση Υπάρχουσας Συμπεριφοράς**

Όταν ο δείκτης της συμπεριφοράς δεν είναι γνωστός, επιλέξτε τη βάση του τύπου. Αυτό το παράδειγμα ανοίγει το `rotation.pptx`, εντοπίζει το [IRotationEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/irotationeffect/), αλλάζει τη γωνία και ελέγχει την αποθηκευμένη τιμή μετά το ξανά άνοιγμα.

Η έλεγχος τύπου επιτρέπει στον βρόχο να παραλείψει συμπεριφορές που δεν είναι περιστροφές. Η δεύτερη φόρτωση διαβάζει το αποθηκευμένο αρχείο σε ξεχωριστό αντικείμενο παρουσίασης, έτσι η σύγκριση ελέγχει δεδομένα που έχουν διατηρηθεί και όχι την τιμή που παραμένει στη μνήμη. Αυτό το παράδειγμα υποθέτει ότι το γνωστό εφέ είναι πρώτο στην κύρια ακολουθία· η επιλογή συμπεριφοράς βάσει τύπου δεν εντοπίζει το σωστό εφέ σε τυχαία παρουσίαση.

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

Η έξοδος είναι `Rotation preserved: true`. Εφαρμόστε το ίδιο μοτίβο ελέγχου τύπου σε άλλες συμπεριφορές. Για πλήρη έλεγχο διατήρησης, συγκρίνετε το σχήμα‑στόχο, το εφέ, τους τύπους και τη σειρά των συμπεριφορών, το χρονοδιάγραμμα, και τις εντολές μονοπατιού. Χρησιμοποιήστε αριθμητική ανοχή για τιμές κινητής υποδιαστολής. Για παρουσίαση με άγνωστη διάταξη κίνησης, δείτε [Ανάγνωση Κινήσεων Σχήματος](/slides/el/androidjava/shape-animation/#read-shape-animations) για περιήγηση των κύριων και διαδραστικών ακολουθιών.

## **Σειρά Συμπεριφορών, Προεπιλογές και Αναπαραγωγή**

Η σειρά στο [IBehaviorCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibehaviorcollection/) είναι η αποθηκευμένη σειρά των λειτουργιών ενός εφέ. Δεν αποτελεί λίστα αναπαραγωγής στην οποία κάθε συμπεριφορά περιμένει αυτόματα την προηγούμενη. Το χρονοδιάγραμμα και το περιβάλλον εφέ καθορίζουν τον προγραμματισμό. Οι συμπεριφορές μπορούν να επικαλύπτονται, και οι λειτουργίες στο ίδιο χαρακτηριστικό μπορεί να αλληλεπιδρούν μέσω των [getAdditive](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibehavior/#getAdditive--) και [getAccumulate](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibehavior/#getAccumulate--). Μην χρησιμοποιείτε μόνο την επαναταξινόμηση της συλλογής για να προγραμματίσετε “μετακίνηση, μετά περιστροφή”; χρησιμοποιήστε ρητό χρονοδιάγραμμα ή ξεχωριστά εφέ όπως περιγράφεται στην ενότητα [Κίνηση Σχήματος](/slides/el/androidjava/shape-animation/).

Ο τύπος εφέ [getType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ieffect/#getType--) και το [getSubtype](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ieffect/#getSubtype--) περιγράφουν το προεπιλεγμένο εφέ. Δεν αποτελούν πλήρη περιγραφή ενός επεξεργασμένου δέντρου συμπεριφορών. Επιλέξτε το προεπιλεγμένο και το υποτύπο πριν προσαρμόσετε τις συμπεριφορές: η αλλαγή του προεπιλεγμένου μπορεί να ξαναχτίσει τη συλλογή και να απορρίψει τις προσαρμοσμένες λειτουργίες σας. Για παράδειγμα, η αλλαγή ενός προσαρμοσμένου εφέ Spin σε Fade μπορεί να αντικαταστήσει τη συμπεριφορά περιστροφής με συμπεριφορές set και filter. Ελέγξτε ξανά τη συλλογή μετά την αλλαγή προεπιλογής ή υποτύπου. Ο καθαρισμός των προεπιλεγμένων συμπεριφορών μπορεί επίσης να αφαιρέσει λειτουργίες ορατότητας ή αρχικοποίησης που απαιτούνται από το προεπιλεγμένο. Τα παραδείγματα χρησιμοποιούν σχήματα που είναι ήδη ορατά και αντικαθιστούν τις συμπεριφορές· δεν ξαναχτίζουν όλη την υλοποίηση του προεπιλεγμένου.

## **Συμβατότητα Μορφών**

Ένα διατηρημένο δέντρο συμπεριφορών δεν εγγυάται ίδια αναπαραγωγή σε κάθε προγράμματα προβολής ή εξαγωγέα. Ελέγξτε τα αποθηκευμένα δεδομένα και το παραγόμενο αποτέλεσμα ξεχωριστά.

| Μορφή ή έξοδος | Τι να ελεγχθεί |
| --- | --- |
| PPTX | Χρησιμοποιήστε ως κύρια μορφή για αυτά τα παραδείγματα. Ανοίξτε ξανά για επαλήθευση του επεξεργάσιμου δέντρου συμπεριφορών, στη συνέχεια ελέγξτε την αναπαραγωγή στην εκδότη PowerPoint. |
| PPT | Η παλαιότερη δυαδική αναπαράσταση μπορεί να διαφέρει από το PPTX. Δοκιμάστε ένα ξεχωριστό κύκλο αποθήκευσης‑ανοίγματος και αναπαραγωγής· μην υποθέτετε υποστήριξη κάθε προσαρμοστικού συνδυασμού από επιτυχία PPTX. |
| PDF, PNG, JPEG, και άλλες στατικές εικόνες διαφανειών | Περιέχουν μια στατική αναπαράσταση διαφάνειας, όχι μια αναγνώσιμη γραμμή χρόνου ή εγγυημένο τελικό καρέ κίνησης. |
| [HTML5](/slides/el/androidjava/export-to-html5/) | Μπορεί να αναπαράγει υποστηριζόμενες κινήσεις όταν η κίνηση σχήματος είναι ενεργοποιημένη στις επιλογές εξαγωγής. Δοκιμάστε προσαρμοσμένους συνδυασμούς στον φυλλομετρητή. |
| [Animated GIF](/slides/el/androidjava/convert-powerpoint-to-animated-gif/) | Αποθηκεύει καρέ που αποδόθηκαν, όχι επεξεργάσιμες κινήσεις ή αλληλεπιδράσεις με κλικ. Ελέγξτε την πραγματική κίνηση που αποδόθηκε. |
| [Video](/slides/el/androidjava/convert-powerpoint-to-video/) | Αποδίδει καρέ κίνησης και τα κωδικοποιεί ως βίντεο. Η υποστήριξη είναι περιορισμένη στις [υποστηριζόμενες κινήσεις και εφέ](/slides/el/androidjava/convert-powerpoint-to-video/#supported-animations-and-effects) του εξαγωγέα· οι εντολές και τα διαδραστικά συμβάντα δεν γίνονται επεξεργάσιμη χρονογραμμή. |

## **Συχνές Ερωτήσεις**

**Γιατί το εφέ μου περιέχει συμπεριφορές πριν προσθέσω τίποτα;**

Η δημιουργία ενός προκαθορισμένου εφέ μπορεί να δημιουργήσει τις υποκείμενες λειτουργίες του. Ελέγξτε τες πριν αποφασίσετε αν θα επεκτείνετε το προεπιλεγμένο ή θα αντικαταστήσετε τις συμπεριφορές του.

**Η μετακίνηση μιας συμπεριφοράς στην αρχή την κάνει να παίζει πρώτη;**

Δεν είναι απαραίτητα. Η σειρά της συλλογής δεν υποκαθιστά το χρονοδιάγραμμα. Ελέγξτε καθυστερήσεις, διάρκειες και αλληλεπιδράσεις μεταξύ λειτουργιών στο ίδιο χαρακτηριστικό.

**Γιατί μια εντολή λήξης δεν έχει σημεία;**

Δυνητικά σηματοδοτεί το τέλος του μονοπατιού και δεν απαιτεί συντεταγμένες. Ελέγξτε για μηδενική σειρά σημείων όταν ελέγχετε ένα μονοπάτι που διαβάζεται από αρχείο.

**Είναι μια επιτυχημένη πλήρης ανακύκλωση επαρκής για επιβεβαίωση αναπαραγωγής;**

Όχι. Η επαναφόρτωση επιβεβαιώνει τη διατήρηση των ιδιοτήτων που ελέγξατε. Δοκιμάστε τον προγραμματιστή παρουσίασης ή την εξαγωγή animation ξεχωριστά για να επιβεβαιώσετε τη συμπεριφορά του οπτικού αποτελέσματος.