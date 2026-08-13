---
title: Εφαρμογή κινήσεων σχήματος σε παρουσιάσεις χρησιμοποιώντας Java
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
description: "Ανακαλύψτε πώς να δημιουργείτε και να προσαρμόζετε κινήσεις σχήματος σε παρουσιάσεις PowerPoint με το Aspose.Slides για Java. Ξεχωρίστε!"
---
## **Εισαγωγή**

Οι κινήσεις είναι οπτικά εφέ που μπορούν να εφαρμοστούν σε κείμενα, εικόνες, σχήματα ή [διαγράμματα](https://docs.aspose.com/slides/el/java/animated-charts/). Δίνουν ζωή στις παρουσιάσεις ή στα συστατικά τους. 

## **Γιατί να χρησιμοποιήσετε κινήσεις στις παρουσιάσεις;**

Χρησιμοποιώντας κινήσεις, μπορείτε  

* να ελέγξετε τη ροή των πληροφοριών  
* να τονίσετε σημαντικά σημεία  
* να αυξήσετε το ενδιαφέρον ή τη συμμετοχή του κοινού σας  
* να κάνετε το περιεχόμενο πιο εύκολο στην ανάγνωση, απορρόφηση ή επεξεργασία  
* να κατευθύνετε την προσοχή των αναγνωστών ή θεατών σας στα σημαντικά μέρη μιας παρουσίασης  

Το PowerPoint παρέχει πολλές επιλογές και εργαλεία για κινήσεις και εφέ κινήσεων στις κατηγορίες **είσοδος**, **έξοδος**, **έμφαση** και **διαδρομές κίνησης**. 

## **Κινήσεις στο Aspose.Slides**

* Το Aspose.Slides παρέχει τις κλάσεις και τους τύπους που χρειάζεστε για εργασία με κινήσεις στο χώρο ονομάτων `Aspose.Slides.Animation`,  
* Το Aspose.Slides παρέχει πάνω από **150 εφέ κίνησης** μέσω της απαρίθμησης [EffectType](https://reference.aspose.com/slides/el/java/com.aspose.slides/effecttype). Αυτά τα εφέ είναι ουσιαστικά τα ίδια (ή ισοδύναμα) εφέ που χρησιμοποιούνται στο PowerPoint.  

## **Εφαρμογή κίνησης σε TextBox**

Το Aspose.Slides for Java σας επιτρέπει να εφαρμόσετε κίνηση στο κείμενο ενός σχήματος. 

1. Δημιουργήστε μια παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).  
2. Πάρτε μια αναφορά σε διαφάνεια μέσω του δείκτη της.  
3. Προσθέστε ένα `rectangle` [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape).  
4. Προσθέστε κείμενο στο [IAutoShape.TextFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-).  
5. Αποκτήστε την κύρια ακολουθία εφέ.  
6. Προσθέστε ένα εφέ κίνησης στο [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape).  
7. Ορίστε την ιδιότητα `TextAnimation.BuildType` στην τιμή από την απαρίθμηση `BuildType`.  
8. Γράψτε την παρουσίαση στο δίσκο ως αρχείο PPTX.  

Αυτός ο κώδικας Java δείχνει πώς να εφαρμόσετε το εφέ `Fade` σε AutoShape και να ορίσετε την κίνηση κειμένου στην τιμή *By 1st Level Paragraphs*:

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

    // Λαμβάνει την κύρια ακολουθία της διαφάνειας.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // Προσθέτει εφέ κίνησης Fade στο σχήμα
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Κινούνται τα κείμενα του σχήματος κατά παραγράφους πρώτου επιπέδου
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // Αποθηκεύει το αρχείο PPTX στον δίσκο
    pres.save("AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="info"  %}} 
Εκτός από την εφαρμογή κινήσεων σε κείμενο, μπορείτε επίσης να εφαρμόσετε κινήσεις σε μεμονωμένο [Paragraph](https://reference.aspose.com/slides/el/java/com.aspose.slides/iparagraph). Δείτε το [**Animated Text**](/slides/el/java/animated-text/). 
{{% /alert %}} 

## **Εφαρμογή κίνησης σε PictureFrame**

1. Δημιουργήστε μια παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).  
2. Πάρτε μια αναφορά σε διαφάνεια μέσω του δείκτη της.  
3. Προσθέστε ή αποκτήστε ένα [PictureFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/pictureframe) στη διαφάνεια.  
4. Αποκτήστε την κύρια ακολουθία εφέ.  
5. Προσθέστε ένα εφέ κίνησης στο [PictureFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/pictureframe).  
6. Γράψτε την παρουσίαση στο δίσκο ως αρχείο PPTX.  

Αυτός ο κώδικας Java δείχνει πώς να εφαρμόσετε το εφέ `Fly` σε picture frame:

```java
import com.aspose.slides.*;

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

    // Αποθηκεύει το αρχείο PPTX στον δίσκο
    pres.save("AnimImage_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Εφαρμογή κίνησης σε Shape**

1. Δημιουργήστε μια παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).  
2. Πάρτε μια αναφορά σε διαφάνεια μέσω του δείκτη της.  
3. Προσθέστε ένα `rectangle` [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape).  
4. Προσθέστε ένα `Bevel` [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape) (όταν αυτό το αντικείμενο κλικάρεται, η κίνηση εκτελείται).  
5. Δημιουργήστε μια ακολουθία εφέ στο σχήμα bevel.  
6. Δημιουργήστε ένα προσαρμοσμένο `UserPath`.  
7. Προσθέστε εντολές μετακίνησης στο `UserPath`.  
8. Γράψτε την παρουσίαση στο δίσκο ως αρχείο PPTX.  

Αυτός ο κώδικας Java δείχνει πώς να εφαρμόσετε το εφέ `PathFootball` (διαδρομή μπάλα ποδοσφαίρου) σε σχήμα:

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει ένα αρχείο PPTX.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Δημιουργεί εφέ PathFootball για υπάρχον σχήμα από το μηδέν.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // Προσθέτει το εφέ κίνησης PathFootBall
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Δημιουργεί κάποιο είδος "κουμπιού".
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Δημιουργεί μια ακολουθία εφέ για αυτό το κουμπί.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // Δημιουργεί προσαρμοσμένη διαδρομή χρήστη. Το αντικείμενό μας θα μετακινηθεί μόνο αφού γίνει κλικ στο κουμπί.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // Προσθέτει εντολές κίνησης επειδή η δημιουργημένη διαδρομή είναι κενή.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

     // Γράφει το αρχείο PPTX στον δίσκο
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Λήψη των εφέ κίνησης που έχουν εφαρμοστεί σε σχήμα**

Τα παρακάτω παραδείγματα δείχνουν πώς να χρησιμοποιήσετε τη μέθοδο `getEffectsByShape` από τη διεπαφή [ISequence](https://reference.aspose.com/slides/el/java/com.aspose.slides/isequence/) για να λάβετε όλα τα εφέ κίνησης που έχουν εφαρμοστεί σε σχήμα.  

**Παράδειγμα 1: Λήψη εφέ κίνησης που έχουν εφαρμοστεί σε σχήμα σε κανονική διαφάνεια**  

Στο παρελθόν μάθατε πώς να προσθέτετε εφέ κίνησης σε σχήματα σε παρουσιάσεις PowerPoint. Ο παρακάτω κώδικας δείχνει πώς να λάβετε τα εφέ που έχουν εφαρμοστεί στο πρώτο σχήμα της πρώτης κανονικής διαφάνειας της παρουσίασης `AnimExample_out.pptx`.  

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Λαμβάνει την κύρια ακολουθία κίνησης της διαφάνειας.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Λαμβάνει το πρώτο σχήμα στην πρώτη διαφάνεια.
    IShape shape = firstSlide.getShapes().get_Item(0);

    // Λαμβάνει τα εφέ κίνησης που έχουν εφαρμοστεί στο σχήμα.
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("The shape " + shape.getName() + " has " + shapeEffects.length + " animation effects.");
} finally {
    if (presentation != null) presentation.dispose();
}
```

**Παράδειγμα 2: Λήψη όλων των εφέ κίνησης, συμπεριλαμβανομένων των κληρονομημένων από placeholders**  

Εάν ένα σχήμα σε κανονική διαφάνεια έχει placeholders που βρίσκονται στη διαφάνεια διάταξης και/ή στην κύρια διαφάνεια, και έχουν προστεθεί εφέ κίνησης σε αυτά τα placeholders, τότε όλα τα εφέ του σχήματος θα εκτελεστούν κατά την προβολή, συμπεριλαμβανομένων των κληρονομημένων.  

Ας πούμε ότι έχουμε ένα αρχείο παρουσίασης PowerPoint `sample.pptx` με μία διαφάνεια που περιέχει μόνο ένα σχήμα υποσέλιδου με το κείμενο «Made with Aspose.Slides» και το εφέ **Random Bars** έχει εφαρμοστεί στο σχήμα.  

![Slide shape animation effect](slide-shape-animation.png)

Ας υποθέσουμε επίσης ότι το εφέ **Split** έχει εφαρμοστεί στο placeholder υποσέλιδου στη **διάταξη**.  

![Layout shape animation effect](layout-shape-animation.png)

Και τέλος, το εφέ **Fly In** έχει εφαρμοστεί στο placeholder υποσέλιδου στην **κύρια** διαφάνεια.  

![Master shape animation effect](master-shape-animation.png)

Ο παρακάτω κώδικας δείχνει πώς να χρησιμοποιήσετε τη μέθοδο `getBasePlaceholder` από τη διεπαφή [IShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/) για να προσεγγίσετε τα placeholders του σχήματος και να λάβετε τα εφέ κίνησης που έχουν εφαρμοστεί στο σχήμα υποσέλιδου, συμπεριλαμβανομένων των κληρονομημένων από placeholders στις διαφάνειες διάταξης και κύριας.  

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

// Λαμβάνει τα εφέ κίνησης του σχήματος στη κανονική διαφάνεια.
IShape shape = slide.getShapes().get_Item(0);
IEffect[] shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Λαμβάνει τα εφέ κίνησης του placeholder στη διαφάνεια διάταξης.
IShape layoutShape = shape.getBasePlaceholder();
IEffect[] layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Λαμβάνει τα εφέ κίνησης του placeholder στη κύρια διαφάνεια.
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

## **Αλλαγή ιδιοτήτων χρονισμού εφέ κίνησης**

Το Aspose.Slides for Java σας επιτρέπει να αλλάξετε τις ιδιότητες Timing ενός εφέ κίνησης.  

Αυτό είναι το παράθυρο Timing Κίνησης στο Microsoft PowerPoint:  

![example1_image](shape-animation.png)

Αυτές είναι οι αντιστοιχίες μεταξύ του Timing στο PowerPoint και των ιδιοτήτων [Effect.Timing](https://reference.aspose.com/slides/el/java/com.aspose.slides/IEffect#getTiming--):  

- Η αναπτυσσόμενη λίστα **Start** του PowerPoint ταιριάζει με την ιδιότητα [Effect.Timing.TriggerType](https://reference.aspose.com/slides/el/java/com.aspose.slides/ITiming#getTriggerType--).  
- Το **Duration** του PowerPoint ταιριάζει με την ιδιότητα [Effect.Timing.Duration](https://reference.aspose.com/slides/el/java/com.aspose.slides/ITiming#getDuration--). Η διάρκεια μιας κίνησης (σε δευτερόλεπτα) είναι ο συνολικός χρόνος που χρειάζεται για να ολοκληρωθεί ένας κύκλος.  
- Η **Delay** του PowerPoint ταιριάζει με την ιδιότητα [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/el/java/com.aspose.slides/ITiming#getTriggerDelayTime--).  

Έτσι αλλάζετε τις ιδιότητες Timing του εφέ:  

1. [Apply](#apply-animation-to-shape) ή πάρτε το εφέ κίνησης.  
2. Ορίστε νέες τιμές για τις ιδιότητες [Effect.Timing](https://reference.aspose.com/slides/el/java/com.aspose.slides/IEffect#getTiming--) που χρειάζεστε.  
3. Αποθηκεύστε το τροποποιημένο αρχείο PPTX.  

Αυτός ο κώδικας Java δείχνει τη λειτουργία:

```java
import com.aspose.slides.*;

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

    // Αποθηκεύει το αρχείο PPTX στον δίσκο
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ήχος εφέ κίνησης**

Το Aspose.Slides παρέχει αυτές τις ιδιότητες για να δουλέψετε με ήχους σε εφέ κίνησης:  

- [setSound(IAudio value)](https://reference.aspose.com/slides/el/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)  
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/el/java/com.aspose.slides/effect/#setStopPreviousSound-boolean-)  

### **Προσθήκη ήχου σε εφέ κίνησης**

Αυτός ο κώδικας Java δείχνει πώς να προσθέσετε ήχο σε εφέ κίνησης και να τον σταματήσετε όταν ξεκινά το επόμενο εφέ:  

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Προσθέτει ήχο στη συλλογή ήχων της παρουσίασης
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Λαμβάνει την κύρια ακολουθία της διαφάνειας.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Λαμβάνει το πρώτο εφέ της κύριας ακολουθίας
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

    // Γράφει το αρχείο PPTX στον δίσκο
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Εξαγωγή ήχου από εφέ κίνησης**

1. Δημιουργήστε μια παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/).  
2. Πάρτε μια αναφορά σε διαφάνεια μέσω του δείκτη της.  
3. Αποκτήστε την κύρια ακολουθία εφέ.  
4. Εξαγάγετε το [setSound(IAudio value)](https://reference.aspose.com/slides/el/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) ενσωματωμένο σε κάθε εφέ κίνησης.  

Αυτός ο κώδικας Java δείχνει πώς να εξάγετε τον ήχο που είναι ενσωματωμένος σε εφέ κίνησης:  

```java
import com.aspose.slides.*;

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

        // Εξάγει τον ήχο του εφέ σε πίνακα bytes
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **After Animation**

Το Aspose.Slides for Java σας επιτρέπει να αλλάξετε την ιδιότητα After animation ενός εφέ κίνησης.  

Αυτό είναι το παράθυρο Effect και το εκτεταμένο μενού στο Microsoft PowerPoint:  

![example1_image](shape-after-animation.png)

Η αναπτυσσόμενη λίστα **After animation** του PowerPoint ταιριάζει με τις παρακάτω ιδιότητες:  

- Η ιδιότητα [setAfterAnimationType(int value)](https://reference.aspose.com/slides/el/java/com.aspose.slides/ieffect/#setAfterAnimationType-int-) περιγράφει τον τύπο After animation:  
  * Το **More Colors** του PowerPoint ταιριάζει με τον τύπο [AfterAnimationType.Color](https://reference.aspose.com/slides/el/java/com.aspose.slides/afteranimationtype/#Color).  
  * Το **Don't Dim** του PowerPoint ταιριάζει με τον τύπο [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/el/java/com.aspose.slides/afteranimationtype/#DoNotDim) (προεπιλεγμένος τύπος).  
  * Το **Hide After Animation** ταιριάζει με τον τύπο [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/el/java/com.aspose.slides/afteranimationtype/#HideAfterAnimation).  
  * Το **Hide on Next Mouse Click** ταιριάζει με τον τύπο [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/el/java/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick).  
- Η ιδιότητα [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/el/java/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) ορίζει μια μορφή χρώματος after animation. Λειτουργεί μαζί με τον τύπο [AfterAnimationType.Color](https://reference.aspose.com/slides/el/java/com.aspose.slides/afteranimationtype/#Color). Αν αλλάξετε τον τύπο, το χρώμα after animation θα αφαιρεθεί.  

Αυτός ο κώδικας Java δείχνει πώς να αλλάξετε ένα εφέ after animation:  

```java
import com.aspose.slides.*;
import java.awt.Color;

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

    // Αποθηκεύει το αρχείο PPTX στον δίσκο
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animate Text**

Το Aspose.Slides παρέχει αυτές τις ιδιότητες για να δουλέψετε με το μπλοκ *Animate text* ενός εφέ κίνησης:  

- Η ιδιότητα [setAnimateTextType(int value)](https://reference.aspose.com/slides/el/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) περιγράφει τον τύπο animation text του εφέ. Το κείμενο του σχήματος μπορεί να αναπαραχθεί:  
  - Όλο μαζί ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/el/java/com.aspose.slides/animatetexttype/#AllAtOnce))  
  - Λέξη προς λέξη ([AnimateTextType.ByWord](https://reference.aspose.com/slides/el/java/com.aspose.slides/animatetexttype/#ByWord))  
  - Γράμμα προς γράμμα ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/el/java/com.aspose.slides/animatetexttype/#ByLetter))  
- Η ιδιότητα [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/el/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) καθορίζει καθυστέρηση μεταξύ των τμημάτων κειμένου (λέξεις ή γράμματα). Θετική τιμή ορίζει ποσοστό της διάρκειας του εφέ· αρνητική τιμή ορίζει καθυστέρηση σε δευτερόλεπτα.  

Έτσι μπορείτε να αλλάξετε τις ιδιότητες Animate text:  

1. [Apply](#apply-animation-to-shape) ή πάρτε το εφέ κίνησης.  
2. Ορίστε την ιδιότητα [setBuildType(int value)](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextanimation/#setBuildType-int-) σε τιμή [BuildType.AsOneObject](https://reference.aspose.com/slides/el/java/com.aspose.slides/buildtype/#AsOneObject) για να απενεργοποιήσετε τη λειτουργία *By Paragraphs*.  
3. Ορίστε νέες τιμές για τις ιδιότητες [setAnimateTextType(int value)](https://reference.aspose.com/slides/el/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) και [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/el/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-).  
4. Αποθηκεύστε το τροποποιημένο αρχείο PPTX.  

Αυτός ο κώδικας Java δείχνει τη λειτουργία:  

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

    // Ορίζει την καθυστέρηση μεταξύ λέξεων στο 20% της διάρκειας του εφέ
    firstEffect.setDelayBetweenTextParts(20f);

    // Αποθηκεύει το αρχείο PPTX στον δίσκο
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Συχνές ερωτήσεις**

### Πώς μπορώ να διασφαλίσω ότι οι κινήσεις διατηρούνται όταν δημοσιεύω την παρουσίαση στο web;

[Export to HTML5](/slides/el/java/export-to-html5/) και ενεργοποιήστε τις [options](https://reference.aspose.com/slides/el/java/com.aspose.slides/html5options/) που είναι υπεύθυνες για τις κινήσεις [shape](https://reference.aspose.com/slides/el/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) και [transition](https://reference.aspose.com/slides/el/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-). Το απλό HTML δεν εκτελεί κινήσεις διαφάνειας, ενώ το HTML5 το κάνει.  

### Πώς η αλλαγή του z-order (σειράς στρώσεων) των σχημάτων επηρεάζει την κίνηση;

Η σειρά κίνησης και η σειρά σχεδίασης είναι ανεξάρτητες: ένα εφέ ελέγχει το χρόνο και τον τύπο εμφάνισης/απόκρυψης, ενώ το [z-order](https://reference.aspose.com/slides/el/java/com.aspose.slides/shape/#getZOrderPosition--) καθορίζει τι καλύπτει τι. Το ορατό αποτέλεσμα ορίζεται από τον συνδυασμό τους. (Αυτή είναι η γενική συμπεριφορά του PowerPoint· το μοντέλο effects‑and‑shapes του Aspose.Slides ακολουθεί την ίδια λογική.)  

### Υπάρχουν περιορισμοί κατά τη μετατροπή κινήσεων σε βίντεο για ορισμένα εφέ;

Γενικά, [οι κινήσεις υποστηρίζονται](/slides/el/java/convert-powerpoint-to-video/), αλλά σπάνιες περιπτώσεις ή συγκεκριμένα εφέ μπορεί να αποδοθούν διαφορετικά. Συνιστάται να δοκιμάσετε τα εφέ που χρησιμοποιείτε και την έκδοση της βιβλιοθήκης.