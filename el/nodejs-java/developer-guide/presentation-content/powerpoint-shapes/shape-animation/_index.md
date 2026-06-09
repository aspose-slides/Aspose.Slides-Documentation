---
title: "Εφαρμογή Κινήσεων Σχήματος σε Παρουσιάσεις Χρησιμοποιώντας JavaScript"
linktitle: "Κίνηση Σχήματος"
type: docs
weight: 60
url: /el/nodejs-java/shape-animation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Ανακαλύψτε πώς να δημιουργείτε και να προσαρμόζετε κινήσεις σχήματος σε παρουσιάσεις PowerPoint με JavaScript και Aspose.Slides για Node.js μέσω Java. Διακριθείτε!"
---
## **Εισαγωγή**

Οι κινήσεις είναι οπτικά εφέ που μπορούν να εφαρμοστούν σε κείμενα, εικόνες, σχήματα ή [διαγράμματα](/slides/el/nodejs-java/animated-charts/). Δίνουν ζωή σε παρουσιάσεις ή στα συστατικά τους.

## **Γιατί να χρησιμοποιήσετε κινήσεις στις παρουσιάσεις;**

Με τη χρήση κινήσεων, μπορείτε  

* Έλεγχο της ροής των πληροφοριών  
* Έμφαση σε σημαντικά σημεία  
* Αύξηση του ενδιαφέροντος ή της συμμετοχής του κοινού σας  
* Κάνοντας το περιεχόμενο πιο εύκολο στην ανάγνωση, την απορρόφηση ή την επεξεργασία  
* Κατεύθυνση της προσοχής των αναγνωστών ή θεατών σας σε σημαντικά μέρη της παρουσίασης  

Το PowerPoint παρέχει πολλές επιλογές και εργαλεία για κινήσεις και εφέ κινήσεων στις κατηγορίες **entrance**, **exit**, **emphasis** και **motion paths**.

## **Κινήσεις στο Aspose.Slides**

* Το Aspose.Slides παρέχει τις κλάσεις και τους τύπους που χρειάζεστε για εργασία με κινήσεις στο χώρο ονομάτων `Aspose.Slides.Animation`,  
* Το Aspose.Slides παρέχει πάνω από **150 εφέ κίνησης** μέσω της αρίθμησης [EffectType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/effecttype). Αυτά τα εφέ είναι ουσιαστικά τα ίδια (ή ισοδύναμα) με τα εφέ που χρησιμοποιούνται στο PowerPoint.

## **Εφαρμογή κίνησης σε TextBox**

Το Aspose.Slides για Node.js μέσω Java σας επιτρέπει να εφαρμόσετε κίνηση στο κείμενο ενός σχήματος.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).  
2. Αποκτήστε μια αναφορά διαφάνειας μέσω του δείκτη της.  
3. Προσθέστε ένα `rectangle` [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape).  
4. Προσθέστε κείμενο χρησιμοποιώντας το [AutoShape.addTextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-).  
5. Λάβετε την κύρια ακολουθία εφέ.  
6. Προσθέστε ένα εφέ κίνησης στο [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape).  
7. Καλέστε τη μέθοδο `TextAnimation.setBuildType` με την τιμή από την αρίθμηση `BuildType`.  
8. Αποθηκεύστε την παρουσίαση στο δίσκο ως αρχείο PPTX.  

Αυτός ο κώδικας JavaScript σας δείχνει πώς να εφαρμόσετε το εφέ `Fade` στο AutoShape και να ορίσετε την κίνηση κειμένου στην τιμή *By 1st Level Paragraphs*:

```javascript
// Δημιουργεί ένα αντικείμενο κλάσης παρουσίασης που αντιπροσωπεύει ένα αρχείο παρουσίασης.
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    // Προσθέτει νέο AutoShape με κείμενο
    var autoShape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 100);
    var textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");
    // Λαμβάνει την κύρια ακολουθία της διαφάνειας.
    var sequence = sld.getTimeline().getMainSequence();
    // Προσθέτει εφέ κίνησης Fade στο σχήμα
    var effect = sequence.addEffect(autoShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    // Κινεί το κείμενο του σχήματος κατά παραγράφους πρώτου επιπέδου
    effect.getTextAnimation().setBuildType(aspose.slides.BuildType.ByLevelParagraphs1);
    // Αποθηκεύει το αρχείο PPTX στον δίσκο
    pres.save(path + "AnimText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{%  alert color="primary"  %}} 

Εκτός από την εφαρμογή κινήσεων στο κείμενο, μπορείτε επίσης να εφαρμόσετε κινήσεις σε ένα μεμονωμένο [Paragraph](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraph). Δείτε [**Animated Text**](/slides/el/nodejs-java/animated-text/).

{{% /alert %}} 

## **Εφαρμογή κίνησης σε PictureFrame**

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).  
2. Αποκτήστε μια αναφορά διαφάνειας μέσω του δείκτη της.  
3. Προσθέστε ή λάβετε ένα [PictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframe) στη διαφάνεια.  
4. Λάβετε την κύρια ακολουθία εφέ.  
5. Προσθέστε ένα εφέ κίνησης στο [PictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframe).  
6. Αποθηκεύστε την παρουσίαση στο δίσκο ως αρχείο PPTX.  

Αυτός ο κώδικας JavaScript σας δείχνει πώς να εφαρμόσετε το εφέ `Fly` σε ένα πλαίσιο εικόνας:

```javascript
// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο παρουσίασης.
var pres = new aspose.slides.Presentation();
try {
    // Φορτώνει εικόνα για να προστεθεί στη συλλογή εικόνων της παρουσίασης
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Προσθέτει πλαίσιο εικόνας στη διαφάνεια
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100, picture);
    // Λαμβάνει την κύρια ακολουθία της διαφάνειας.
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    // Προσθέτει εφέ κίνησης Fly από αριστερά στο πλαίσιο εικόνας
    var effect = sequence.addEffect(picFrame, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Left, aspose.slides.EffectTriggerType.OnClick);
    // Αποθηκεύει το αρχείο PPTX στον δίσκο
    pres.save(path + "AnimImage_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Εφαρμογή κίνησης σε Shape**

1. Δημιουργήστε ένα στιγμιότυπο της [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation) κλάσης.  
2. Αποκτήστε μια αναφορά διαφάνειας μέσω του δείκτη της.  
3. Προσθέστε ένα `rectangle` [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape).  
4. Προσθέστε ένα `Bevel` [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape) (όταν αυτό το αντικείμενο κλικάρεται, η κίνηση εκτελείται).  
5. Δημιουργήστε μια ακολουθία εφέ στο σχήμα Bevel.  
6. Δημιουργήστε ένα προσαρμοσμένο `UserPath`.  
7. Προσθέστε εντολές για μετακίνηση στο `UserPath`.  
8. Αποθηκεύστε την παρουσίαση στο δίσκο ως αρχείο PPTX.  

Αυτός ο κώδικας JavaScript σας δείχνει πώς να εφαρμόσετε το εφέ `PathFootball` (path football) σε ένα σχήμα:

```javascript
// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει ένα αρχείο PPTX.
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    // Δημιουργεί το εφέ PathFootball για υπάρχον σχήμα από το μηδέν.
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");
    // Προσθέτει το εφέ κίνησης PathFootBall
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, aspose.slides.EffectType.PathFootball, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // Δημιουργεί ένα είδος «κουμπιού».
    var shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Bevel, 10, 10, 20, 20);
    // Δημιουργεί μια ακολουθία εφέ για αυτό το κουμπί.
    var seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);
    // Δημιουργεί ένα προσαρμοσμένο μονοπάτι χρήστη. Το αντικείμενό μας θα κινηθεί μόνο μετά το κλικ στο κουμπί.
    var fxUserPath = seqInter.addEffect(ashp, aspose.slides.EffectType.PathUser, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    // Προσθέτει εντολές για κίνηση επειδή το δημιουργημένο μονοπάτι είναι κενό.
    var motionBhv = fxUserPath.getBehaviors().get_Item(0);
    var pts = java.newArray("com.aspose.slides.Point2DFloat", [java.newInstanceSync("com.aspose.slides.Point2DFloat", 0.076, 0.59)]);
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.LineTo, pts, aspose.slides.MotionPathPointsType.Auto, true);
    pts[0] = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(-0.076), java.newFloat(-0.59));
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.LineTo, pts, aspose.slides.MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.End, null, aspose.slides.MotionPathPointsType.Auto, false);
    // Γράφει το αρχείο PPTX στον δίσκο
    pres.save("AnimExample_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Λήψη των εφέ κίνησης που έχουν εφαρμοστεί σε σχήμα**

Τα ακόλουθα παραδείγματα δείχνουν πώς να χρησιμοποιήσετε τη μέθοδο `getEffectsByShape` από την κλάση [Sequence](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sequence/) για να λάβετε όλα τα εφέ κίνησης που έχουν εφαρμοστεί σε ένα σχήμα.

**Παράδειγμα 1: Λήψη εφέ κίνησης που έχουν εφαρμοστεί σε σχήμα σε κανονική διαφάνεια**

Προηγουμένως, μάθατε πώς να προσθέτετε εφέ κίνησης σε σχήματα σε παρουσιάσεις PowerPoint. Ο παρακάτω κώδικας δείχνει πώς να λάβετε τα εφέ που έχουν εφαρμοστεί στο πρώτο σχήμα της πρώτης κανονικής διαφάνειας στην παρουσίαση `AnimExample_out.pptx`.

```javascript
var presentation = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    var firstSlide = presentation.getSlides().get_Item(0);

    // Λαμβάνει την κύρια ακολουθία κίνησης της διαφάνειας.
    var sequence = firstSlide.getTimeline().getMainSequence();

    // Λαμβάνει το πρώτο σχήμα στην πρώτη διαφάνεια.
    var shape = firstSlide.getShapes().get_Item(0);

    // Λαμβάνει τα εφέ κίνησης που έχουν εφαρμοστεί στο σχήμα.
    var shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0) {
        console.log("The shape", shape.getName(), "has", shapeEffects.length, "animation effects.");
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

**Παράδειγμα 2: Λήψη όλων των εφέ κίνησης, συμπεριλαμβανομένων των κληρονομικών από placeholders**

Εάν ένα σχήμα σε κανονική διαφάνεια έχει placeholders που βρίσκονται στη διαφάνεια διάταξης και/ή στην κύρια διαφάνεια, και έχουν προστεθεί εφέ κίνησης σε αυτά τα placeholders, τότε όλα τα εφέ του σχήματος θα αναπαράγονται κατά τη παρουσίαση, συμπεριλαμβανομένων των κληρονομικών από τα placeholders.

Ας πούμε ότι έχουμε ένα αρχείο παρουσίασης PowerPoint `sample.pptx` με μία διαφάνεια που περιέχει μόνο ένα σχήμα υποσέλιδου με το κείμενο "Made with Aspose.Slides" και το εφέ **Random Bars** έχει εφαρμοστεί στο σχήμα.

![Εφέ κίνησης σχήματος διαφάνειας](slide-shape-animation.png)

Ας υποθέσουμε επίσης ότι το εφέ **Split** έχει εφαρμοστεί στο placeholder υποσέλιδου στη **layout** διαφάνεια.

![Εφέ κίνησης σχήματος διάταξης](layout-shape-animation.png)

Και τέλος, το εφέ **Fly In** έχει εφαρμοστεί στο placeholder υποσέλιδου στη **master** διαφάνεια.

![Εφέ κίνησης σχήματος κύριου](master-shape-animation.png)

Ο παρακάτω κώδικας δείχνει πώς να χρησιμοποιήσετε τη μέθοδο `getBasePlaceholder` από την κλάση [Shape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/) για να προσπελάσετε τα placeholders του σχήματος και να λάβετε τα εφέ κίνησης που έχουν εφαρμοστεί στο σχήμα υποσέλιδου, συμπεριλαμβανομένων των κληρονομικών από placeholders που βρίσκονται στις διαφάνειες layout και master.

```js
var presentation = new aspose.slides.Presentation("sample.pptx");

var slide = presentation.getSlides().get_Item(0);

// Λάβετε τα εφέ κίνησης του σχήματος στη κανονική διαφάνεια.
var shape = slide.getShapes().get_Item(0);
var shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Λάβετε τα εφέ κίνησης του placeholder στη διαφάνεια διάταξης.
var layoutShape = shape.getBasePlaceholder();
var layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Λάβετε τα εφέ κίνησης του placeholder στη κύρια διαφάνεια.
var masterShape = layoutShape.getBasePlaceholder();
var masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

console.log("Main sequence of shape effects:");
printEffects(masterShapeEffects);
printEffects(layoutShapeEffects);
printEffects(shapeEffects);

presentation.dispose();
```
```js
function printEffects(effects) {
    for (const effect of effects) {
        console.log("Type:", effect.getType() + ", subtype:", effect.getSubtype());
    }
}
```

Output:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // Πτήση, Κάτω
Type: 134, subtype: 45            // Διαίρεση, Κάθετη Εισαγωγή
Type: 126, subtype: 22            // Τυχαίες Γραμμές, Οριζόντια
```

## **Αλλαγή ιδιοτήτων χρονομέτρησης εφέ κίνησης**

Το Aspose.Slides για Node.js μέσω Java σας επιτρέπει να αλλάξετε τις ιδιότητες Timing ενός εφέ κίνησης.

Αυτό είναι το παράθυρο Animation Timing στο Microsoft PowerPoint:

![παράδειγμα1_εικόνα](shape-animation.png)

Αυτές είναι οι αντιστοιχίες μεταξύ PowerPoint Timing και ιδιοτήτων [Effect.Timing](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Effect#getTiming--):

- Το πεδίο επιλογής **Start** του PowerPoint Timing αντιστοιχεί στην ιδιότητα [Effect.Timing.TriggerType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Timing#getTriggerType--).  
- Το **Duration** του PowerPoint Timing αντιστοιχεί στην ιδιότητα [Effect.Timing.Duration](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Timing#getDuration--). Η διάρκεια μιας κίνησης (σε δευτερόλεπτα) είναι ο συνολικός χρόνος που χρειάζεται η κίνηση για να ολοκληρώσει έναν κύκλο.  
- Το **Delay** του PowerPoint Timing αντιστοιχεί στην ιδιότητα [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Timing#getTriggerDelayTime--).  

Αυτός είναι ο τρόπος αλλαγής των ιδιοτήτων Timing του εφέ:

1. [Εφαρμόστε](#apply-animation-to-shape) ή λάβετε το εφέ κίνησης.  
2. Ορίστε νέες τιμές για τις ιδιότητες [Effect.Timing](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Effect#getTiming--) που χρειάζεστε.  
3. Αποθηκεύστε το τροποποιημένο αρχείο PPTX.  

Αυτός ο κώδικας JavaScript δείχνει τη λειτουργία:

```javascript
// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο παρουσίασης.
var pres = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    // Λαμβάνει την κύρια ακολουθία της διαφάνειας.
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    // Λαμβάνει το πρώτο εφέ της κύριας ακολουθίας.
    var effect = sequence.get_Item(0);
    // Αλλάζει τον TriggerType του εφέ ώστε να ξεκινά με κλικ
    effect.getTiming().setTriggerType(aspose.slides.EffectTriggerType.OnClick);
    // Αλλάζει τη διάρκεια του εφέ
    effect.getTiming().setDuration(3.0);
    // Αλλάζει το TriggerDelayTime του εφέ
    effect.getTiming().setTriggerDelayTime(0.5);
    // Αποθηκεύει το αρχείο PPTX στον δίσκο
    pres.save("AnimExample_changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ήχος εφέ κίνησης**

Το Aspose.Slides παρέχει αυτές τις ιδιότητες για να εργαστείτε με ήχους σε εφέ κίνησης: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/effect/#setSound-aspose.slides.IAudio-)  
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/effect/#setStopPreviousSound-boolean-)

### **Προσθήκη ήχου εφέ κίνησης**

Αυτός ο κώδικας JavaScript σας δείχνει πώς να προσθέσετε ήχο εφέ κίνησης και να τον διακόψετε όταν ξεκινά το επόμενο εφέ:

```javascript
var pres = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    // Προσθέτει ήχο στη συλλογή ήχων της παρουσίασης
    var effectSound = pres.getAudios().addAudio(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "sampleaudio.wav")));
    var firstSlide = pres.getSlides().get_Item(0);
    // Λαμβάνει την κύρια ακολουθία της διαφάνειας.
    var sequence = firstSlide.getTimeline().getMainSequence();
    // Λαμβάνει το πρώτο εφέ της κύριας ακολουθίας
    var firstEffect = sequence.get_Item(0);
    // Ελέγχει το εφέ για «Κανέναν ήχο»
    if ((!firstEffect.getStopPreviousSound()) && (firstEffect.getSound() == null)) {
        // Προσθέτει ήχο για το πρώτο εφέ
        firstEffect.setSound(effectSound);
    }
    // Λαμβάνει την πρώτη διαδραστική ακολουθία της διαφάνειας.
    var interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);
    // Ορίζει τη σημαία εφέ «Διακοπή προηγούμενου ήχου»
    interactiveSequence.get_Item(0).setStopPreviousSound(true);
    // Γράφει το αρχείο PPTX στον δίσκο
    pres.save("AnimExample_Sound_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Εξαγωγή ήχου εφέ κίνησης**

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) .  
2. Αποκτήστε μια αναφορά διαφάνειας μέσω του δείκτη της.  
3. Λάβετε την κύρια ακολουθία εφέ.  
4. Εξάγετε το ενσωματωμένο [setSound(IAudio value)](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/effect/#setSound-aspose.slides.IAudio-) σε κάθε εφέ κίνησης.  

Αυτός ο κώδικας JavaScript δείχνει πώς να εξάγετε τον ήχο που είναι ενσωματωμένος σε ένα εφέ κίνησης:

```javascript
// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο παρουσίασης.
var presentation = new aspose.slides.Presentation("EffectSound.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // Λαμβάνει την κύρια ακολουθία της διαφάνειας.
    var sequence = slide.getTimeline().getMainSequence();
    for (var i = 0; i < sequence.getCount(); i++) {
        var effect = sequence.get_Item(i);
        if (effect.getSound() == null) {
            continue;
        }
        // Εξάγει τον ήχο του εφέ σε πίνακα byte
        var audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Μετά την κίνηση**

Το Aspose.Slides για Node.js μέσω Java σας επιτρέπει να αλλάξετε την ιδιότητα After animation ενός εφέ κίνησης.

Αυτό είναι το παράθυρο Effect και το εκτατικό μενού στο Microsoft PowerPoint:

![παράδειγμα1_εικόνα](shape-after-animation.png)

Η λίστα επιλογής **After animation** του PowerPoint ταιριάζει με τις παρακάτω ιδιότητες: 

- Η μέθοδος [setAfterAnimationType(int value)](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/effect/#setAfterAnimationType-int-) περιγράφει τον τύπο After animation·  
  * Το **More Colors** του PowerPoint ταιριάζει με τον τύπο [AfterAnimationType.Color](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/afteranimationtype/#Color).  
  * Το **Don't Dim** του PowerPoint ταιριάζει με τον τύπο [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/afteranimationtype/#DoNotDim) (προεπιλεγμένος τύπος μετά την κίνηση).  
  * Το **Hide After Animation** του PowerPoint ταιριάζει με τον τύπο [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/afteranimationtype/#HideAfterAnimation).  
  * Το **Hide on Next Mouse Click** του PowerPoint ταιριάζει με τον τύπο [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick).  
- Η μέθοδος [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/effect/#setAfterAnimationColor-aspose.slides.IColorFormat-) ορίζει μορφή χρώματος μετά την κίνηση. Αυτή η μέθοδος λειτουργεί μαζί με τον τύπο [AfterAnimationType.Color](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/afteranimationtype/#Color). Αν αλλάξετε τον τύπο σε κάποιον άλλο, το χρώμα μετά την κίνηση θα καθαριστεί.  

Αυτός ο κώδικας JavaScript δείχνει πώς να αλλάξετε ένα εφέ μετά την κίνηση:

```javascript
// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο παρουσίασης
var pres = new aspose.slides.Presentation("AnimImage_out.pptx");
try {
    var firstSlide = pres.getSlides().get_Item(0);
    // Λαμβάνει το πρώτο εφέ της κύριας ακολουθίας
    var firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);
    // Αλλάζει τον τύπο μετά την κίνηση σε Color
    firstEffect.setAfterAnimationType(aspose.slides.AfterAnimationType.Color);
    // Ορίζει το χρώμα μετά την κίνηση
    firstEffect.getAfterAnimationColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // Αποθηκεύει το αρχείο PPTX στον δίσκο
    pres.save("AnimImage_AfterAnimation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Κίνηση κειμένου**

Το Aspose.Slides παρέχει αυτές τις ιδιότητες ώστε να εργαστείτε με το τμήμα *Animate text* ενός εφέ κίνησης:

- Η μέθοδος [setAnimateTextType(int value)](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/effect/#setAnimateTextType-int-) περιγράφει τον τύπο Animate text του εφέ. Το κείμενο του σχήματος μπορεί να αναδιατάσσεται:  
  - Όλα ταυτόχρονα ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/animatetexttype/#AllAtOnce) τύπος)  
  - Κατά λέξη ([AnimateTextType.ByWord](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/animatetexttype/#ByWord) τύπος)  
  - Κατά γράμμα ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/animatetexttype/#ByLetter) τύπος)  
- Η μέθοδος [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/effect/#setDelayBetweenTextParts-float-) ορίζει καθυστέρηση μεταξύ των τμημάτων του κειμένου (λέξεις ή γράμματα). Μία θετική τιμή καθορίζει το ποσοστό της διάρκειας του εφέ. Μία αρνητική τιμή ορίζει την καθυστέρηση σε δευτερόλεπτα.  

Αυτός είναι ο τρόπος αλλαγής των ιδιοτήτων Animate text του εφέ:

1. [Εφαρμόστε](#apply-animation-to-shape) ή λάβετε το εφέ κίνησης.  
2. Ορίστε τη μέθοδο [setBuildType(int value)](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textanimation/#setBuildType-int-) στην τιμή [BuildType.AsOneObject](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/buildtype/#AsOneObject) για να απενεργοποιήσετε τη λειτουργία *By Paragraphs*.  
3. Ορίστε νέες τιμές για τις ιδιότητες [setAnimateTextType(int value)](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/effect/#setAnimateTextType-int-) και [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/effect/#setDelayBetweenTextParts-float-).  
4. Αποθηκεύστε το τροποποιημένο αρχείο PPTX.  

Αυτός ο κώδικας JavaScript δείχνει τη λειτουργία:

```javascript
// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο παρουσίασης.
var pres = new aspose.slides.Presentation("AnimTextBox_out.pptx");
try {
    var firstSlide = pres.getSlides().get_Item(0);
    // Λαμβάνει το πρώτο εφέ της κύριας ακολουθίας
    var firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);
    // Αλλάζει τον τύπο κίνησης κειμένου του εφέ σε «Ως ένα αντικείμενο»
    firstEffect.getTextAnimation().setBuildType(aspose.slides.BuildType.AsOneObject);
    // Αλλάζει τον τύπο κίνησης κειμένου του εφέ σε «Κατά λέξη»
    firstEffect.setAnimateTextType(aspose.slides.AnimateTextType.ByWord);
    // Ορίζει την καθυστέρηση μεταξύ λέξεων στο 20% της διάρκειας του εφέ
    firstEffect.setDelayBetweenTextParts(20.0);
    // Γράφει το αρχείο PPTX στον δίσκο
    pres.save("AnimTextBox_AnimateText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Συχνές ερωτήσεις**

**Πώς μπορώ να διασφαλίσω ότι οι κινήσεις διατηρούνται όταν δημοσιεύεται η παρουσίαση στον ιστό;**

[Export to HTML5](/slides/el/nodejs-java/export-to-html5/) και ενεργοποιήστε τις [options](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/html5options/) που είναι υπεύθυνες για τις κινήσεις σχήματος ([setanimateshapes]()) και μετάβασης ([setanimatetransitions]()). Η απλή HTML δεν αναπαράγει κινήσεις διαφάνειας, ενώ η HTML5 το κάνει.

**Πώς η αλλαγή της σειράς z (σειράς επιπέδων) των σχημάτων επηρεάζει την κίνηση;**

Η σειρά χ (z-order) και η σειρά σχεδίασης είναι ανεξάρτητες: ένα εφέ ελέγχει το χρόνο και τον τύπο εμφάνισης/εξαφάνισης, ενώ η [z-order](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/getzorderposition/) καθορίζει τι καλύπτει τι. Το ορατό αποτέλεσμα ορίζεται από το συνδυασμό τους. (Αυτή είναι η γενική συμπεριφορά του PowerPoint· το μοντέλο Aspose.Slides ακολουθεί την ίδια λογική.)

**Υπάρχουν περιορισμοί κατά τη μετατροπή κινήσεων σε βίντεο για ορισμένα εφέ;**

Γενικά, [οι κινήσεις υποστηρίζονται](/slides/el/nodejs-java/convert-powerpoint-to-video/), αλλά σπάνιες περιπτώσεις ή συγκεκριμένα εφέ μπορεί να αποδοθούν διαφορετικά. Συνιστάται να δοκιμάζετε με τα εφέ που χρησιμοποιείτε και με την έκδοση της βιβλιοθήκης.