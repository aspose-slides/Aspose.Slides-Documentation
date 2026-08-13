---
title: Εφαρμογή Κινήσεων Σχημάτων σε Παρουσιάσεις σε Android
linktitle: Κίνηση Σχήματος
type: docs
weight: 60
url: /el/androidjava/shape-animation/
keywords:
- σχήμα
- κίνηση
- εφέ
- Κινούμενο σχήμα
- Κινούμενο κείμενο
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
- Android
- Java
- Aspose.Slides
description: "Ανακαλύψτε πώς να δημιουργήσετε και να προσαρμόσετε κινήσεις σχημάτων σε παρουσιάσεις PowerPoint με το Aspose.Slides για Android μέσω Java. Ξεχωρίστε!"
---
## **Εισαγωγή**

Οι κινήσεις είναι οπτικά εφέ που μπορούν να εφαρμοστούν σε κείμενα, εικόνες, σχήματα ή [charts](https://docs.aspose.com/slides/el/androidjava/animated-charts/). Δίνουν ζωή σε παρουσιάσεις ή στα στοιχεία τους.

## **Γιατί Να Χρησιμοποιείτε Κινήσεις σε Παρουσιάσεις;**

* ελέγχου της ροής των πληροφοριών  
* τονίσετε σημαντικά σημεία  
* αυξήσετε το ενδιαφέρον ή τη συμμετοχή του κοινού σας  
* κάνετε το περιεχόμενο πιο εύκολο στην ανάγνωση, την απορρόφηση ή την επεξεργασία  
* κατευθύνετε την προσοχή των αναγνωστών ή θεατών σας στα σημαντικά τμήματα μιας παρουσίασης  

PowerPoint παρέχει πολλές επιλογές και εργαλεία για κινήσεις και εφέ κίνησης στις κατηγορίες **εισόδου**, **εξόδου**, **τονισμού** και **διαδρομές κίνησης**.

## **Κινήσεις στο Aspose.Slides**

* Το Aspose.Slides παρέχει τις κλάσεις και τύπους που χρειάζεστε για εργασία με κινήσεις στο χώρο ονομάτων `Aspose.Slides.Animation`,  
* Το Aspose.Slides προσφέρει πάνω από **150 εφέ κίνησης** στην απαρίθμηση [EffectType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/effecttype). Αυτά τα εφέ είναι ουσιαστικά τα ίδια (ή ισοδύναμα) εφέ που χρησιμοποιούνται στο PowerPoint.

## **Εφαρμογή Κίνησης σε Πεδίο Κειμένου**

Το Aspose.Slides για Android μέσω Java σάς επιτρέπει να εφαρμόσετε κίνηση στο κείμενο ενός σχήματος.

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).  
2. Απόσπαστε μια αναφορά σε διαφάνεια μέσω του δείκτη της.  
3. Προσθέστε ένα `rectangle` [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape).  
4. Προσθέστε κείμενο στο [IAutoShape.TextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-).  
5. Λάβετε την κύρια ακολουθία εφέ.  
6. Προσθέστε ένα εφέ κίνησης στο [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape).  
7. Ορίστε την ιδιότητα `TextAnimation.BuildType` στην τιμή από την απαρίθμηση `BuildType`.  
8. Γράψτε την παρουσίαση στο δίσκο ως αρχείο PPTX.  

Αυτός ο κώδικας Java σας δείχνει πώς να εφαρμόσετε το εφέ `Fade` στο AutoShape και να ορίσετε την κίνηση κειμένου στην τιμή *By 1st Level Paragraphs*:

```java
import com.aspose.slides.*;

// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Προσθέτει νέο AutoShape με κείμενο
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // Λαμβάνει τη κύρια ακολουθία της διαφάνειας.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // Προσθέτει εφέ κίνησης Fade στο σχήμα
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Κινεί το κείμενο του σχήματος με παραγράφους πρώτου επιπέδου
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // Αποθηκεύει το αρχείο PPTX στο δίσκο
    pres.save("AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="info"  %}} 

Εκτός από την εφαρμογή κινήσεων σε κείμενο, μπορείτε επίσης να εφαρμόσετε κινήσεις σε ένα μόνο [Paragraph](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraph). Δείτε [**Animated Text**](/slides/el/androidjava/animated-text/).

{{% /alert %}} 

## **Εφαρμογή Κίνησης σε PictureFrame**

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).  
2. Απόσπαστε μια αναφορά σε διαφάνεια μέσω του δείκτη της.  
3. Προσθέστε ή λάβετε ένα [PictureFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pictureframe) στη διαφάνεια.  
4. Λάβετε την κύρια ακολουθία εφέ.  
5. Προσθέστε ένα εφέ κίνησης στο [PictureFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pictureframe).  
6. Γράψτε την παρουσίαση στο δίσκο ως αρχείο PPTX.  

Αυτός ο κώδικας Java σας δείχνει πώς να εφαρμόσετε το εφέ `Fly` σε ένα πλαίσιο εικόνας:

```java
import com.aspose.slides.*;

// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation pres = new Presentation();
try {
    // Φορτώνει εικόνα για προσθήκη στη συλλογή εικόνων της παρουσίασης
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Προσθέτει πλαίσια εικόνας στη διαφάνεια
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // Λαμβάνει τη κύρια ακολουθία της διαφάνειας.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Προσθέτει το εφέ κίνησης Fly από τα αριστερά στο πλαίσιο εικόνας
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Αποθηκεύει το αρχείο PPTX στο δίσκο
    pres.save("AnimImage_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Εφαρμογή Κίνησης σε Σχήμα**

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).  
2. Απόσπαστε μια αναφορά σε διαφάνεια μέσω του δείκτη της.  
3. Προσθέστε ένα `rectangle` [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape).  
4. Προσθέστε ένα `Bevel` [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape) (όταν αυτό το αντικείμενο κλικάρεται, η κίνηση εκτελείται).  
5. Δημιουργήστε μια ακολουθία εφέ στο σχήμα bevel.  
6. Δημιουργήστε ένα προσαρμοσμένο `UserPath`.  
7. Προσθέστε εντολές για μετακίνηση στο `UserPath`.  
8. Γράψτε την παρουσίαση στο δίσκο ως αρχείο PPTX.  

Αυτός ο κώδικας Java σας δείχνει πώς να εφαρμόσετε το εφέ `PathFootball` (path football) σε ένα σχήμα:

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει ένα αρχείο PPTX.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Δημιουργεί το εφέ PathFootball για υπάρχον σχήμα από την αρχή.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // Προσθέτει το εφέ κίνησης PathFootball
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Δημιουργεί κάποιο είδους "κουμπί".
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Δημιουργεί μια ακολουθία εφέ για αυτό το κουμπί.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // Δημιουργεί προσαρμοσμένη διαδρομή χρήστη. Το αντικείμενό μας θα μετακινηθεί μόνο μετά το κλικ στο κουμπί.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // Προσθέτει εντολές κίνησης επειδή η δημιουργημένη διαδρομή είναι κενή.
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

## **Λήψη των Εφέ Κίνησης που Εφαρμόζονται σε Σχήμα**

Τα παρακάτω παραδείγματα σας δείχνουν πώς να χρησιμοποιήσετε τη μέθοδο `getEffectsByShape` από την διεπαφή [ISequence](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isequence/) για να λάβετε όλα τα εφέ κίνησης που εφαρμόζονται σε ένα σχήμα.

**Παράδειγμα 1: Λήψη εφέ κίνησης που εφαρμόζονται σε σχήμα σε κανονική διαφάνεια**

Προηγουμένως, μάθατε πώς να προσθέτετε εφέ κίνησης σε σχήματα σε παρουσιάσεις PowerPoint. Ο παρακάτω κώδικας δείχνει πώς να λαμβάνετε τα εφέ που εφαρμόζονται στο πρώτο σχήμα στην πρώτη κανονική διαφάνεια της παρουσίασης `AnimExample_out.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Λαμβάνει τη κύρια ακολουθία κίνησης της διαφάνειας.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Λαμβάνει το πρώτο σχήμα της πρώτης διαφάνειας.
    IShape shape = firstSlide.getShapes().get_Item(0);

    // Λαμβάνει τα εφέ κίνησης που εφαρμόζονται στο σχήμα.
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("The shape " + shape.getName() + " has " + shapeEffects.length + " animation effects.");
} finally {
    if (presentation != null) presentation.dispose();
}
```

**Παράδειγμα 2: Λήψη όλων των εφέ κίνησης, συμπεριλαμβανομένων αυτών που κληρονόμησαν από placeholders**

Εάν ένα σχήμα σε μια κανονική διαφάνεια διαθέτει placeholders που βρίσκονται στη διαφάνεια διάταξης και/ή στην κύρια διαφάνεια, και έχουν προστεθεί εφέ κίνησης σε αυτά τα placeholders, τότε όλα τα εφέ του σχήματος θα εκτελεστούν κατά την παρουσίαση, συμπεριλαμβανομένων αυτών που κληρονόμησαν από τα placeholders.

Ας πούμε ότι έχουμε ένα αρχείο παρουσίασης PowerPoint `sample.pptx` με μια διαφάνεια που περιέχει μόνο ένα σχήμα υποσέλιδου με το κείμενο "Made with Aspose.Slides" και το εφέ **Random Bars** εφαρμόζεται στο σχήμα.

![Εφέ κίνησης σχήματος διαφάνειας](slide-shape-animation.png)

Ας υποθέσουμε επίσης ότι το εφέ **Split** εφαρμόζεται στο placeholder υποσέλιδου στη διαφάνεια **layout**.

![Εφέ κίνησης σχήματος διάταξης](layout-shape-animation.png)

Και τέλος, το εφέ **Fly In** εφαρμόζεται στο placeholder υποσέλιδου στη διαφάνεια **master**.

![Εφέ κίνησης σχήματος κύριας διαφάνειας](master-shape-animation.png)

Ο παρακάτω κώδικας δείχνει πώς να χρησιμοποιήσετε τη μέθοδο `getBasePlaceholder` από τη διεπαφή [IShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/) για να προσπελάσετε τα placeholders του σχήματος και να λάβετε τα εφέ κίνησης που εφαρμόζονται στο σχήμα υποσέλιδου, συμπεριλαμβανομένων αυτών που κληρονόμησαν από placeholders στη διάταξη και στην κύρια διαφάνεια.

```java
import com.aspose.slides.*;

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
for (IEffect[] effects : new IEffect[][] { masterShapeEffects, layoutShapeEffects, shapeEffects }) {
    for (IEffect effect : effects) {
        String typeName = EffectType.getName(EffectType.class, effect.getType());
        String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());

        System.out.println(typeName + " " + subtypeName);
    }
}

presentation.dispose();
```
```java
import com.aspose.slides.*;

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

## **Αλλαγή Ιδιοτήτων Χρόνου Εφέ Κίνησης**

Το Aspose.Slides για Android μέσω Java επιτρέπει την αλλαγή των ιδιοτήτων Χρόνου ενός εφέ κίνησης.

Αυτή είναι η περιοχή Χρόνου Κίνησης στο Microsoft PowerPoint:

![example1_image](shape-animation.png)

Αυτές είναι οι αντιστοιχίες μεταξύ PowerPoint Timing και ιδιοτήτων [Effect.Timing](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IEffect#getTiming--):

- Η λίστα déroulement **Start** του PowerPoint Timing ταιριάζει με την ιδιότητα [Effect.Timing.TriggerType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ITiming#getTriggerType--).  
- Η λίστα déroulement **Duration** του PowerPoint Timing ταιριάζει με την ιδιότητα [Effect.Timing.Duration](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ITiming#getDuration--). Η διάρκεια ενός εφέ (σε δευτερόλεπτα) είναι ο συνολικός χρόνος που χρειάζεται για να ολοκληρωθεί ένας κύκλος.  
- Η λίστα déroulement **Delay** του PowerPoint Timing ταιριάζει με την ιδιότητα [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ITiming#getTriggerDelayTime--).  

Αυτή είναι η διαδικασία αλλαγής των ιδιοτήτων Χρόνου του εφέ:

1. Εφαρμόστε (βλ. #apply-animation-to-shape) ή λάβετε το εφέ κίνησης.  
2. Ορίστε νέες τιμές για τις ιδιότητες [Effect.Timing](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IEffect#getTiming--) που χρειάζεστε.  
3. Αποθηκεύστε το τροποποιημένο αρχείο PPTX.  

```java
import com.aspose.slides.*;

// Δημιουργεί μία κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Λαμβάνει τη κύρια ακολουθία της διαφάνειας.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Λαμβάνει το πρώτο εφέ της κύριας ακολουθίας.
    IEffect effect = sequence.get_Item(0);

    // Αλλάζει τον TriggerType του εφέ ώστε να ξεκινά με κλικ
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

## **Ήχος Εφέ Κίνησης**

Το Aspose.Slides παρέχει τις ακόλουθες ιδιότητες για να εργαστείτε με ήχους σε εφέ κίνησης:

- [setSound(IAudio value)](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) – ορίζει ήχο.  
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/effect/#setStopPreviousSound-boolean-) – σταματά προηγούμενο ήχο.

### **Προσθήκη Ήχου σε Εφέ Κίνησης**

Αυτός ο κώδικας Java σας δείχνει πώς να προσθέσετε ήχο εφέ κίνησης και να τον σταματήσετε όταν ξεκινά το επόμενο εφέ:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Προσθέτει ήχο στη συλλογή ήχων της παρουσίασης
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Λαμβάνει τη κύρια ακολουθία της διαφάνειας.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Λαμβάνει το πρώτο εφέ της κύριας ακολουθίας
    IEffect firstEffect = sequence.get_Item(0);

    // Ελέγχει το εφέ για "No Sound"
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // Προσθέτει ήχο για το πρώτο εφέ
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

### **Εξαγωγή Ήχου από Εφέ Κίνησης**

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/).  
2. Απόσπαστε μια αναφορά σε διαφάνεια μέσω του δείκτη της.  
3. Λάβετε την κύρια ακολουθία εφέ.  
4. Εξάγετε το ενσωματωμένο [setSound(IAudio value)](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) σε κάθε εφέ κίνησης.  

```java
import com.aspose.slides.*;

// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Λαμβάνει τη κύρια ακολουθία της διαφάνειας.
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

## **Μετά την Κίνηση**

Το Aspose.Slides για Android μέσω Java επιτρέπει την αλλαγή της ιδιότητας After animation ενός εφέ κίνησης.

Αυτή είναι η περιοχή Εφέ Κίνησης και το εκτεταμένο μενού στο Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

Η λίστα déroulement **After animation** του PowerPoint ταιριάζει με τις παρακάτω ιδιότητες:

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ieffect/#setAfterAnimationType-int-) ιδιότητα που περιγράφει τον τύπο μετά την κίνηση :
  * PowerPoint **More Colors** ταιριάζει με τον τύπο [AfterAnimationType.Color](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/afteranimationtype/#Color).  
  * PowerPoint **Don't Dim** ταιριάζει με τον τύπο [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/afteranimationtype/#DoNotDim) (προεπιλεγμένος τύπος).  
  * PowerPoint **Hide After Animation** ταιριάζει με τον τύπο [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/afteranimationtype/#HideAfterAnimation).  
  * PowerPoint **Hide on Next Mouse Click** ταιριάζει με τον τύπο [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick).  
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) ιδιότητα που ορίζει μορφή χρώματος μετά την κίνηση. Λειτουργεί σε συνδυασμό με τον τύπο [AfterAnimationType.Color](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/afteranimationtype/#Color). Αν αλλάξετε τον τύπο, το χρώμα μετά την κίνηση θα καθαριστεί.

Αυτός ο κώδικας Java σας δείχνει πώς να αλλάξετε ένα εφέ μετά την κίνηση:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο παρουσίασης
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Λαμβάνει το πρώτο εφέ της κύριας ακολουθίας
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Αλλάζει τον τύπο μετά την κίνηση σε Χρώμα
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // Ορίζει το χρώμα μετά την κίνηση
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // Αποθηκεύει το αρχείο PPTX στο δίσκο
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Κίνηση Κειμένου**

Το Aspose.Slides παρέχει τις ακόλουθες ιδιότητες για να εργαστείτε με το τμήμα *Animate text* ενός εφέ κίνησης:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) που περιγράφει τον τύπο κειμένου κίνησης. Το κείμενο του σχήματος μπορεί να κουνιέται:
  - All at once ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/animatetexttype/#AllAtOnce) τύπος)  
  - By word ([AnimateTextType.ByWord](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/animatetexttype/#ByWord) τύπος)  
  - By letter ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/animatetexttype/#ByLetter) τύπος)  
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) ορίζει καθυστέρηση μεταξύ των τμημάτων του κειμένου (λέξεων ή γραμμάτων). Ένα θετικό τιμή καθορίζει ποσοστό της διάρκειας του εφέ· μια αρνητική τιμή καθορίζει τη χρονική καθυστέρηση σε δευτερόλεπτα.  

Αυτή είναι η διαδικασία αλλαγής των ιδιοτήτων Animate text του εφέ:

1. Εφαρμόστε (βλ. #apply-animation-to-shape) ή λάβετε το εφέ κίνησης.  
2. Ορίστε την ιδιότητα [setBuildType(int value)](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextanimation/#setBuildType-int-) στην τιμή [BuildType.AsOneObject](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/buildtype/#AsOneObject) για να απενεργοποιήσετε τη λειτουργία *By Paragraphs*.  
3. Ορίστε νέες τιμές για τις ιδιότητες [setAnimateTextType(int value)](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) και [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-).  
4. Αποθηκεύστε το τροποποιημένο αρχείο PPTX.  

```java
import com.aspose.slides.*;

// Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο παρουσίασης.
Presentation pres = new Presentation("AnimText_out.pptx");
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

## **ΣΥΝΑΡΤΗΣΕΣ**

### Πώς μπορώ να διασφαλίσω ότι οι κινήσεις διατηρούνται όταν δημοσιεύω την παρουσίαση στο web;

[Export to HTML5](/slides/el/androidjava/export-to-html5/) και ενεργοποιήστε τις [options](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/html5options/) υπεύθυνες για τις κινήσεις [shape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) και [transition](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-). Το απλό HTML δεν εκτελεί κινήσεις διαφανειών, ενώ το HTML5 το κάνει.

### Πώς η αλλαγή της σειράς z (σειράς στρώματος) των σχημάτων επηρεάζει την κίνηση;

Η σειρά κίνησης και η σειρά σχεδίασης είναι ανεξάρτητες: ένα εφέ ελέγχει το χρόνο και τον τύπο εμφάνισης/απόκρυψης, ενώ το [z-order](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/shape/#getZOrderPosition--) καθορίζει τι καλύπτει τι. Το ορατό αποτέλεσμα ορίζεται από τον συνδυασμό τους. (Αυτή είναι η γενική συμπεριφορά του PowerPoint· το μοντέλο Aspose.Slides για εφέ‑σχήματα ακολουθεί την ίδια λογική.)

### Υπάρχουν περιορισμοί κατά τη μετατροπή κινήσεων σε βίντεο για ορισμένα εφέ;

Γενικά, τα [animations are supported](/slides/el/androidjava/convert-powerpoint-to-video/), αλλά σπάνιες περιπτώσεις ή συγκεκριμένα εφέ μπορεί να αποδοθούν διαφορετικά. Συνιστάται να δοκιμάζετε με τα εφέ που χρησιμοποιείτε και με την έκδοση της βιβλιοθήκης.