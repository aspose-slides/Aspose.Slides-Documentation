---
title: Εφαρμογή Κινήσεων Σχημάτων σε Παρουσιάσεις με Java
linktitle: Κίνηση Σχήματος
type: docs
weight: 60
url: /el/java/shape-animation/
keywords:
- σχήμα
- κίνηση
- εφέ
- κινούμενο σχήμα
- κινούμενο κείμενο
- προσθήκη κίνησης
- λήψη κίνησης
- εξαγωγή κίνησης
- προσθήκη εφέ
- λήψη εφέ
- εξαγωγή εφέ
- ήχος εφέ
- εφαρμογή κίνησης
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Ανακαλύψτε πώς να δημιουργήσετε και να προσαρμόσετε κινήσεις σχημάτων σε παρουσιάσεις PowerPoint με Aspose.Slides για Java. Διακριθείτε!"
---
## **Εισαγωγή**

Οι κινήσεις είναι οπτικά εφέ που μπορούν να εφαρμοστούν σε κείμενα, εικόνες, σχήματα ή [charts](https://docs.aspose.com/slides/el/java/animated-charts/). Δίνουν ζωή στις παρουσιάσεις ή στα στοιχεία τους. 

## **Γιατί να χρησιμοποιήσετε κινήσεις στις παρουσιάσεις;**

Χρησιμοποιώντας κινήσεις, μπορείτε 

* ελέγχετε τη ροή των πληροφοριών
* τονίζετε σημαντικά σημεία
* αυξάνετε το ενδιαφέρον ή τη συμμετοχή του κοινού σας
* καθιστάτε το περιεχόμενο πιο εύκολο στην ανάγνωση ή την επεξεργασία
* προσελκύετε την προσοχή των αναγνωστών ή θεατών σε σημαντικά τμήματα της παρουσίασης

Το PowerPoint παρέχει πολλές επιλογές και εργαλεία για κινήσεις και εφέ κινήσεων στα είδη **entrance**, **exit**, **emphasis**, και **motion paths**. 

## **Κινήσεις στο Aspose.Slides**

* Το Aspose.Slides παρέχει τις κλάσεις και τύπους που χρειάζεστε για εργασία με κινήσεις στο χώρο ονομάτων `Aspose.Slides.Animation`,
* Το Aspose.Slides παρέχει πάνω από **150 εφέ κίνησης** κάτω από την απαρίθμηση [EffectType](https://reference.aspose.com/slides/el/java/com.aspose.slides/effecttype). Αυτά τα εφέ είναι ουσιαστικά τα ίδια (ή ισοδύναμα) εφέ που χρησιμοποιούνται στο PowerPoint.

## **Εφαρμογή κίνησης σε πλαίσιο κειμένου**

Το Aspose.Slides for Java σας επιτρέπει να εφαρμόσετε κίνηση στο κείμενο ενός σχήματος. 

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
2. Αποκτήστε μια αναφορά σε διαφάνεια μέσω του δείκτη της.
3. Προσθέστε ένα `rectangle` [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape). 
4. Προσθέστε κείμενο στο [IAutoShape.TextFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-).
5. Αποκτήστε την κύρια ακολουθία εφέ.
6. Προσθέστε ένα εφέ κίνησης στο [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape). 
7. Ορίστε την ιδιότητα `TextAnimation.BuildType` στην τιμή από την απαρίθμηση `BuildType`.
8. Αποθηκεύστε την παρουσίαση στο δίσκο ως αρχείο PPTX.

Αυτός ο κώδικας Java δείχνει πώς να εφαρμόσετε το εφέ `Fade` στο AutoShape και να ορίσετε την κίνηση κειμένου στην τιμή *By 1st Level Paragraphs*:

```java
// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Προσθέτει νέο AutoShape με κείμενο
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // Λαμβάνει την κύρια ακολουθία της διαφάνειας.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // Προσθέτει εφέ κίνησης Fade στο σχήμα
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Κινεί το κείμενο του σχήματος κατά παραγράφους πρώτου επιπέδου
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // Αποθηκεύει το αρχείο PPTX στο δίσκο
    pres.save(path + "AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="primary"  %}} 

Εκτός από την εφαρμογή κινήσεων σε κείμενο, μπορείτε επίσης να εφαρμόσετε κινήσεις σε ένα μεμονωμένο [Paragraph](https://reference.aspose.com/slides/el/java/com.aspose.slides/iparagraph). Δείτε [**Animated Text**](/slides/el/java/animated-text/).

{{% /alert %}} 

## **Εφαρμογή κίνησης σε PictureFrame**

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
2. Αποκτήστε μια αναφορά σε διαφάνεια μέσω του δείκτη της.
3. Προσθέστε ή αποκτήστε ένα [PictureFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/pictureframe) στη διαφάνεια. 
4. Αποκτήστε την κύρια ακολουθία εφέ.
5. Προσθέστε ένα εφέ κίνησης στο [PictureFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/pictureframe).
6. Αποθηκεύστε την παρουσίαση στο δίσκο ως αρχείο PPTX.

Αυτός ο κώδικας Java δείχνει πώς να εφαρμόσετε το εφέ `Fly` σε ένα πλαίσιο εικόνας:

```java
// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation pres = new Presentation();
try {
    // Φορτώνει εικόνα που θα προστεθεί στη συλλογή εικόνων της παρουσίασης
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Προσθέτει πλαίσιο εικόνας στη διαφάνεια
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // Λαμβάνει την κύρια ακολουθία της διαφάνειας.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Προσθέτει εφέ κίνησης Fly από τα αριστερά στο πλαίσιο εικόνας
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Αποθηκεύει το αρχείο PPTX στο δίσκο
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Εφαρμογή κίνησης σε σχήμα**

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
2. Αποκτήστε μια αναφορά σε διαφάνεια μέσω του δείκτη της.
3. Προσθέστε ένα `rectangle` [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape). 
4. Προσθέστε ένα `Bevel` [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape) (όταν αυτό το αντικείμενο γίνεται κλικ, η κίνηση εκτελείται).
5. Δημιουργήστε μια ακολουθία εφέ στο σχήμα bevel.
6. Δημιουργήστε ένα προσαρμοσμένο `UserPath`.
7. Προσθέστε εντολές για μετακίνηση στο `UserPath`.
8. Αποθηκεύστε την παρουσίαση στο δίσκο ως αρχείο PPTX.

Αυτός ο κώδικας Java δείχνει πώς να εφαρμόσετε το εφέ `PathFootball` (διαδρομή ποδοσφαίρου) σε ένα σχήμα:

```java
// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει ένα αρχείο PPTX.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Δημιουργεί το εφέ PathFootball για υπάρχον σχήμα από το μηδέν.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // Προσθέτει το εφέ κίνησης PathFootBall
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Δημιουργεί ένα είδος "κουμπιού".
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Δημιουργεί μια ακολουθία εφέ για αυτό το κουμπί.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // Δημιουργεί προσαρμοσμένη διαδρομή χρήστη. Το αντικείμενό μας θα μετακινηθεί μόνο μετά το κλικ στο κουμπί.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // Προσθέτει εντολές μετακίνησης επειδή η δημιουργημένη διαδρομή είναι κενή.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

     // Γράφει το αρχείο PPTX στο δίσκο
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Λήψη των εφέ κίνησης που έχουν εφαρμοστεί σε σχήμα**

Τα παρακάτω παραδείγματα δείχνουν πώς να χρησιμοποιήσετε τη μέθοδο `getEffectsByShape` από τη διεπαφή [ISequence](https://reference.aspose.com/slides/el/java/com.aspose.slides/isequence/) για να λάβετε όλα τα εφέ κίνησης που έχουν εφαρμοστεί σε ένα σχήμα.

**Παράδειγμα 1: Λήψη εφέ κίνησης που εφαρμόζονται σε σχήμα σε κανονική διαφάνεια**

Προγενέστερα, μάθατε πώς να προσθέτετε εφέ κίνησης σε σχήματα σε παρουσιάσεις PowerPoint. Ο παρακάτω κώδικας δείχνει πώς να λάβετε τα εφέ που έχουν εφαρμοστεί στο πρώτο σχήμα στην πρώτη κανονική διαφάνεια της παρουσίασης `AnimExample_out.pptx`.

```java
Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Λαμβάνει την κύρια ακολουθία κίνησης της διαφάνειας.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Λαμβάνει το πρώτο σχήμα στην πρώτη διαφάνεια.
    IShape shape = firstSlide.getShapes().get_Item(0);

    // Λαμβάνει τα εφέ κίνησης που εφαρμόζονται στο σχήμα.
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("The shape " + shape.getName() + " has " + shapeEffects.length + " animation effects.");
} finally {
    if (presentation != null) presentation.dispose();
}
```

**Παράδειγμα 2: Λήψη όλων των εφέ κίνησης, συμπεριλαμβανομένων των κληρονομημένων από placeholders**

Εάν ένα σχήμα σε κανονική διαφάνεια έχει placeholders που βρίσκονται στη διαφάνεια διάταξης και/ή στην κύρια διαφάνεια, και σε αυτά τα placeholders έχουν προστεθεί εφέ κίνησης, τότε όλα τα εφέ του σχήματος θα εκτελεστούν κατά τη διάρκεια της παρουσίασης, συμπεριλαμβανομένων των κληρονομημένων από τα placeholders.

Ας υποθέσουμε ότι έχουμε ένα αρχείο παρουσίασης PowerPoint `sample.pptx` με μία διαφάνεια που περιέχει μόνο ένα σχήμα υποσέλιδου με το κείμενο "Made with Aspose.Slides" και το εφέ **Random Bars** έχει εφαρμοστεί στο σχήμα.

![Εφέ κίνησης σχήματος διαφάνειας](slide-shape-animation.png)

Ας υποθέσουμε επίσης ότι το εφέ **Split** έχει εφαρμοστεί στο placeholder υποσέλιδου στη **layout** διαφάνεια.

![Εφέ κίνησης σχήματος διάταξης](layout-shape-animation.png)

Και τέλος, το εφέ **Fly In** έχει εφαρμοστεί στο placeholder υποσέλιδου στην **master** διαφάνεια.

![Εφέ κίνησης σχήματος κύριας διαφάνειας](master-shape-animation.png)

Ο παρακάτω κώδικας δείχνει πώς να χρησιμοποιήσετε τη μέθοδο `getBasePlaceholder` από τη διεπαφή [IShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/) για να αποκτήσετε πρόσβαση στα placeholders του σχήματος και να λάβετε τα εφέ κίνησης που εφαρμόζονται στο σχήμα υποσέλιδου, συμπεριλαμβανομένων των κληρονομημένων από placeholders που βρίσκονται στη διάταξη και στην κύρια διαφάνεια.

```java
Presentation presentation = new Presentation("sample.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

// Get animation effects of the shape on the normal slide.
IShape shape = slide.getShapes().get_Item(0);
IEffect[] shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Get animation effects of the placeholder on the layout slide.
IShape layoutShape = shape.getBasePlaceholder();
IEffect[] layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Get animation effects of the placeholder on the master slide.
IShape masterShape = layoutShape.getBasePlaceholder();
IEffect[] masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

System.out.println("Main sequence of shape effects:");
printEffects(masterShapeEffects);
printEffects(layoutShapeEffects);
printEffects(shapeEffects);

presentation.dispose();
```
```java
static void printEffects(IEffect[] effects)
{
    for (IEffect effect : effects)
    {
        String typeName = EffectType.getName(EffectType.class, effect.getType());
        String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());

        System.out.println(typeName + " " + subtypeName);
    }
}
```

Output:
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```

## **Αλλαγή ιδιοτήτων χρονομέτρησης εφέ κίνησης**

Το Aspose.Slides for Java σας επιτρέπει να αλλάξετε τις ιδιότητες Timing ενός εφέ κίνησης.

Αυτό είναι το παράθυρο χρονομέτρησης κίνησης στο Microsoft PowerPoint:

![Παράθυρο χρονομέτρησης κίνησης στο Microsoft PowerPoint](shape-animation.png)

Αυτές είναι οι αντιστοιχίες μεταξύ του Timing του PowerPoint και των ιδιοτήτων [Effect.Timing](https://reference.aspose.com/slides/el/java/com.aspose.slides/IEffect#getTiming--) :

- Η λίστα **Start** του PowerPoint ταιριάζει με την ιδιότητα [Effect.Timing.TriggerType](https://reference.aspose.com/slides/el/java/com.aspose.slides/ITiming#getTriggerType--). 
- Η **Duration** του PowerPoint ταιριάζει με την ιδιότητα [Effect.Timing.Duration](https://reference.aspose.com/slides/el/java/com.aspose.slides/ITiming#getDuration--). Η διάρκεια μιας κίνησης (σε δευτερόλεπτα) είναι ο συνολικός χρόνος που χρειάζεται για να ολοκληρωθεί ένας κύκλος κίνησης. 
- Η **Delay** του PowerPoint ταιριάζει με την ιδιότητα [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/el/java/com.aspose.slides/ITiming#getTriggerDelayTime--). 

Αυτή είναι η διαδικασία αλλαγής των ιδιοτήτων Timing του εφέ:

1. [Apply](#apply-animation-to-shape) ή λάβετε το εφέ κίνησης.
2. Ορίστε νέες τιμές για τις ιδιότητες [Effect.Timing](https://reference.aspose.com/slides/el/java/com.aspose.slides/IEffect#getTiming--) που χρειάζεστε. 
3. Αποθηκεύστε το τροποποιημένο αρχείο PPTX.

```java
// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Λαμβάνει την κύρια ακολουθία της διαφάνειας.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Λαμβάνει το πρώτο εφέ της κύριας ακολουθίας.
    IEffect effect = sequence.get_Item(0);

    // Αλλάζει το TriggerType του εφέ ώστε να ξεκινά με κλικ
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // Αλλάζει τη διάρκεια του εφέ
    effect.getTiming().setDuration(3f);

    // Αλλάζει το TriggerDelayTime του εφέ
    effect.getTiming().setTriggerDelayTime(0.5f);

    // Αποθηκεύει το αρχείο PPTX στο δίσκο
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ήχος εφέ κίνησης**

Το Aspose.Slides παρέχει τις παρακάτω ιδιότητες για να εργάζεστε με ήχους σε εφέ κίνησης: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/el/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) 
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/el/java/com.aspose.slides/effect/#setStopPreviousSound-boolean-) 

### **Προσθήκη ήχου εφέ κίνησης**

Αυτός ο κώδικας Java δείχνει πώς να προσθέσετε ήχο εφέ κίνησης και να τον σταματήσετε όταν ξεκινά το επόμενο εφέ:

```java
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Προσθέτει ήχο στη συλλογή ήχων της παρουσίασης
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Λαμβάνει την κύρια ακολουθία της διαφάνειας.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Λαμβάνει το πρώτο εφέ της κύριας ακολουθίας.
    IEffect firstEffect = sequence.get_Item(0);

    // Ελέγχει το εφέ για "No Sound"
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // Προσθέτει ήχο στο πρώτο εφέ
        firstEffect.setSound(effectSound);
    }

    // Λαμβάνει την πρώτη διαδραστική ακολουθία της διαφάνειας.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // Ορίζει τη σημαία "Stop previous sound" του εφέ
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // Γράφει το αρχείο PPTX στο δίσκο
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Εξαγωγή ήχου εφέ κίνησης**

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/).
2. Αποκτήστε μια αναφορά σε διαφάνεια μέσω του δείκτη της. 
3. Αποκτήστε την κύρια ακολουθία εφέ. 
4. Εξάγετε το [setSound(IAudio value)](https://reference.aspose.com/slides/el/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) ενσωματωμένο σε κάθε εφέ κίνησης. 

```java
// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Λαμβάνει την κύρια ακολουθία της διαφάνειας.
    ISequence sequence = slide.getTimeline().getMainSequence();

    for (IEffect effect : sequence)
    {
        if (effect.getSound() == null)
            continue;

        // Εξάγει τον ήχο του εφέ σε πίνακα byte
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Μετά την κίνηση**

Το Aspose.Slides for Java σας επιτρέπει να αλλάξετε την ιδιότητα After animation ενός εφέ κίνησης.

Αυτό είναι το παράθυρο εφέ κίνησης και το εκτεταμένο μενού στο Microsoft PowerPoint:

![Παράθυρο εφέ κίνησης και εκτεταμένου μενού στο Microsoft PowerPoint](shape-after-animation.png)

Η λίστα **After animation** του PowerPoint ταιριάζει με τις παρακάτω ιδιότητες: 

- Η ιδιότητα [setAfterAnimationType(int value)](https://reference.aspose.com/slides/el/java/com.aspose.slides/ieffect/#setAfterAnimationType-int-) περιγράφει τον τύπο After animation :
  * Το PowerPoint **More Colors** ταιριάζει με τον τύπο [AfterAnimationType.Color](https://reference.aspose.com/slides/el/java/com.aspose.slides/afteranimationtype/#Color);
  * Το PowerPoint **Don't Dim** ταιριάζει με τον τύπο [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/el/java/com.aspose.slides/afteranimationtype/#DoNotDim) (προεπιλεγμένος τύπος μετά την κίνηση);
  * Το PowerPoint **Hide After Animation** ταιριάζει με τον τύπο [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/el/java/com.aspose.slides/afteranimationtype/#HideAfterAnimation);
  * Το PowerPoint **Hide on Next Mouse Click** ταιριάζει με τον τύπο [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/el/java/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick);
- Η ιδιότητα [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/el/java/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) ορίζει μια μορφή χρώματος μετά την κίνηση. Η ιδιότητα λειτουργεί σε συνδυασμό με τον τύπο [AfterAnimationType.Color](https://reference.aspose.com/slides/el/java/com.aspose.slides/afteranimationtype/#Color). Αν αλλάξετε τον τύπο σε άλλο, το χρώμα μετά την κίνηση θα διαγραφεί.

```java
// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο παρουσίασης
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Λαμβάνει το πρώτο εφέ της κύριας ακολουθίας
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Αλλάζει τον τύπο after animation σε Color
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // Ορίζει το χρώμα μετά την κίνηση
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // Γράφει το αρχείο PPTX στο δίσκο
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Κίνηση κειμένου**

Το Aspose.Slides παρέχει τις παρακάτω ιδιότητες για να εργαστείτε με το τμήμα *Animate text* ενός εφέ κίνησης:

- Η ιδιότητα [setAnimateTextType(int value)](https://reference.aspose.com/slides/el/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) περιγράφει τον τύπο animate text του εφέ. Το κείμενο του σχήματος μπορεί να αναπαραχθεί:
  - Όλα μαζί ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/el/java/com.aspose.slides/animatetexttype/#AllAtOnce) τύπος)
  - Ανά λέξη ([AnimateTextType.ByWord](https://reference.aspose.com/slides/el/java/com.aspose.slides/animatetexttype/#ByWord) τύπος)
  - Ανά γράμμα ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/el/java/com.aspose.slides/animatetexttype/#ByLetter) τύπος)
- Η ιδιότητα [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/el/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) ορίζει καθυστέρηση μεταξύ των τμημάτων του κειμένου (λέξεων ή γραμμάτων). Μια θετική τιμή καθορίζει το ποσοστό της διάρκειας του εφέ. Μια αρνητική τιμή καθορίζει τη χρονική καθυστέρηση σε δευτερόλεπτα.

Αυτή είναι η διαδικασία αλλαγής των ιδιοτήτων Animate text του εφέ:

1. [Apply](#apply-animation-to-shape) ή λάβετε το εφέ κίνησης.
2. Ορίστε την ιδιότητα [setBuildType(int value)](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextanimation/#setBuildType-int-) στο τιμή [BuildType.AsOneObject](https://reference.aspose.com/slides/el/java/com.aspose.slides/buildtype/#AsOneObject) για να απενεργοποιήσετε τη λειτουργία *By Paragraphs*.
3. Ορίστε νέες τιμές για τις ιδιότητες [setAnimateTextType(int value)](https://reference.aspose.com/slides/el/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) και [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/el/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-).
4. Αποθηκεύστε το τροποποιημένο αρχείο PPTX.

```java
// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation pres = new Presentation("AnimTextBox_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Λαμβάνει το πρώτο εφέ της κύριας ακολουθίας
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Αλλάζει τον τύπο κίνησης κειμένου του εφέ σε "As One Object"
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // Αλλάζει τον τύπο Animate text του εφέ σε "By word"
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // Ορίζει την καθυστέρηση μεταξύ των λέξεων στο 20% της διάρκειας του εφέ
    firstEffect.setDelayBetweenTextParts(20f);

    // Γράφει το αρχείο PPTX στο δίσκο
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Πώς μπορώ να διασφαλίσω ότι οι κινήσεις διατηρούνται όταν δημοσιεύω την παρουσίαση στο web;**

[Export to HTML5](/slides/el/java/export-to-html5/) και ενεργοποιήστε τις [options](https://reference.aspose.com/slides/el/java/com.aspose.slides/html5options/) που είναι υπεύθυνες για τις κινήσεις [shape](https://reference.aspose.com/slides/el/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) και [transition](https://reference.aspose.com/slides/el/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-). Το απλό HTML δεν εκτελεί κινήσεις διαφάνειας, ενώ το HTML5 το κάνει.

**Πώς η αλλαγή της σειράς z (σειράς επιπέδων) των σχημάτων επηρεάζει την κίνηση;**

Η σειρά z και η σειρά σχεδίασης είναι ανεξάρτητες: ένα εφέ ελέγχει το χρόνο και τον τύπο εμφάνισης/αφαίρεσης, ενώ η [z-order](https://reference.aspose.com/slides/el/java/com.aspose.slides/shape/#getZOrderPosition--) καθορίζει τι καλύπτει τι. Το ορατό αποτέλεσμα ορίζεται από το συνδυασμό τους. (Αυτή είναι η γενική συμπεριφορά του PowerPoint· το μοντέλο effects-and-shapes του Aspose.Slides ακολουθεί την ίδια λογική.)

**Υπάρχουν περιορισμοί κατά τη μετατροπή κινήσεων σε βίντεο για ορισμένα εφέ;**

Γενικά, τα [animations are supported](/slides/el/java/convert-powerpoint-to-video/), αλλά σπανιότερες περιπτώσεις ή συγκεκριμένα εφέ μπορεί να αποδοθούν διαφορετικά. Συνιστάται να δοκιμάσετε με τα εφέ που χρησιμοποιείτε και με την έκδοση της βιβλιοθήκης.