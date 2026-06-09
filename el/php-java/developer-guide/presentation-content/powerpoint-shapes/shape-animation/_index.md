---
title: Εφαρμογή Κινήσεων Σχήματος σε Παρουσιάσεις χρησιμοποιώντας PHP
linktitle: Κίνηση Σχήματος
type: docs
weight: 60
url: /el/php-java/shape-animation/
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
- PHP
- Aspose.Slides
description: "Ανακαλύψτε πώς να δημιουργείτε και να προσαρμόζετε κινήσεις σχήματος σε παρουσιάσεις PowerPoint με το Aspose.Slides για PHP μέσω Java. Ξεχωρίστε!"
---
## **Εισαγωγή**

Οι κινήσεις είναι οπτικά εφέ που μπορούν να εφαρμοστούν σε κείμενα, εικόνες, σχήματα ή [charts](https://docs.aspose.com/slides/el/php-java/animated-charts/). Δίνουν ζωή στις παρουσιάσεις ή στα στοιχεία τους.

## **Γιατί να χρησιμοποιήσετε κινήσεις σε παρουσιάσεις;**

Χρησιμοποιώντας κινήσεις, μπορείτε  

* να ελέγχετε τη ροή των πληροφοριών  
* να τονίζετε σημαντικά σημεία  
* να αυξάνετε το ενδιαφέρον ή τη συμμετοχή του κοινού σας  
* να κάνετε το περιεχόμενο πιο εύκολο στην ανάγνωση, την κατανόηση ή την επεξεργασία  
* να ελκύετε την προσοχή των αναγνωστών ή θεατών σας σε σημαντικά τμήματα μιας παρουσίασης  

Το PowerPoint παρέχει πολλές επιλογές και εργαλεία για κινήσεις και εφέ κινήσεων στις κατηγορίες **entrance**, **exit**, **emphasis**, και **motion paths**.

## **Κινήσεις στο Aspose.Slides**

* Το Aspose.Slides παρέχει τις κλάσεις και τους τύπους που χρειάζεστε για εργασία με κινήσεις στο χώρο ονομάτων `Aspose.Slides.Animation`,  
* Το Aspose.Slides παρέχει πάνω από **150 εφέ κινήσεων** στην απαρίθμηση [EffectType](https://reference.aspose.com/slides/el/php-java/aspose.slides/effecttype). Τα εφέ αυτά είναι ουσιαστικά τα ίδια (ή ισοδύναμα) εφέ που χρησιμοποιούνται στο PowerPoint.

## **Εφαρμογή κίνησης σε TextBox**

Το Aspose.Slides for PHP via Java σας επιτρέπει να εφαρμόσετε κίνηση στο κείμενο ενός σχήματος.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation).  
2. Λάβετε μια αναφορά σε διαφάνεια μέσω του δείκτη της.  
3. Προσθέστε ένα ορθογώνιο [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/).  
4. Προσθέστε κείμενο στο [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/#getTextFrame) του `AutoShape`.  
5. Αποκτήστε την κύρια ακολουθία εφέ.  
6. Προσθέστε ένα εφέ κίνησης στο [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/).  
7. Χρησιμοποιήστε τη μέθοδο `TextAnimation.setBuildType` και την τιμή από την απαρίθμηση `BuildType`.  
8. Γράψτε την παρουσίαση στο δίσκο ως αρχείο PPTX.  

Αυτός ο κώδικας PHP δείχνει πώς να εφαρμόσετε το εφέ `Fade` στο AutoShape και να ορίσετε την κίνηση κειμένου στην τιμή *By 1st Level Paragraphs*:

```php
  # Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο παρουσίασης.
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # Προσθέτει νέο AutoShape με κείμενο
    $autoShape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 100);
    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("First paragraph \nSecond paragraph \n Third paragraph");
    # Λαμβάνει την κύρια ακολουθία της διαφάνειας.
    $sequence = $sld->getTimeline()->getMainSequence();
    # Προσθέτει εφέ κίνησης Fade στο σχήμα
    $effect = $sequence->addEffect($autoShape, EffectType::Fade, EffectSubType::None, EffectTriggerType::OnClick);
    # Κουνεί το κείμενο του σχήματος με παραγράφους πρώτου επιπέδου
    $effect->getTextAnimation()->setBuildType(BuildType::ByLevelParagraphs1);
    # Αποθηκεύει το αρχείο PPTX στο δίσκο
    $pres->save($path . "AnimText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert color="primary"  %}} 

Εκτός από την εφαρμογή κινήσεων στο κείμενο, μπορείτε επίσης να εφαρμόσετε κινήσεις σε ένα μοναδικό [Paragraph](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraph/). Δείτε [**Animated Text**](/slides/el/php-java/animated-text/).

{{% /alert %}} 

## **Εφαρμογή κίνησης σε PictureFrame**

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation).  
2. Λάβετε μια αναφορά σε διαφάνεια μέσω του δείκτη της.  
3. Προσθέστε ή λάβετε ένα [PictureFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/pictureframe) στη διαφάνεια.  
4. Αποκτήστε την κύρια ακολουθία εφέ.  
5. Προσθέστε ένα εφέ κίνησης στο [PictureFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/pictureframe).  
6. Γράψτε την παρουσίαση στο δίσκο ως αρχείο PPTX.  

```php
  # Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο παρουσίασης.
  $pres = new Presentation();
  try {
    # Φορτώνει εικόνα που θα προστεθεί στη συλλογή εικόνων της παρουσίασης
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Προσθέτει πλαίσιο εικόνας στη διαφάνεια
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, $picture);
    # Λαμβάνει την κύρια ακολουθία της διαφάνειας.
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # Προσθέτει εφέ κίνησης Fly από αριστερά στο πλαίσιο εικόνας
    $effect = $sequence->addEffect($picFrame, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    # Αποθηκεύει το αρχείο PPTX στο δίσκο
    $pres->save($path . "AnimImage_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Εφαρμογή κίνησης σε Shape**

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation).  
2. Λάβετε μια αναφορά σε διαφάνεια μέσω του δείκτη της.  
3. Προσθέστε ένα ορθογώνιο [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/).  
4. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) με κλίση (όταν αυτό το αντικείμενο κλικάρει, η κίνηση εκτελείται).  
5. Δημιουργήστε μια ακολουθία εφέ στο σχήμα με κλίση.  
6. Δημιουργήστε ένα προσαρμοσμένο `UserPath`.  
7. Προσθέστε εντολές για κίνηση στο `UserPath`.  
8. Γράψτε την παρουσίαση στο δίσκο ως αρχείο PPTX.  

```php
  # Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει ένα αρχείο PPTX.
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # Δημιουργεί το εφέ PathFootball για υπάρχον σχήμα από το μηδέν.
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);
    $ashp->addTextFrame("Animated TextBox");
    # Προσθέτει το εφέ κίνησης PathFootBall
    $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($ashp, EffectType::PathFootball, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Δημιουργεί ένα είδος "κουμπιού".
    $shapeTrigger = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Bevel, 10, 10, 20, 20);
    # Δημιουργεί μια ακολουθία εφέ για αυτό το κουμπί.
    $seqInter = $pres->getSlides()->get_Item(0)->getTimeline()->getInteractiveSequences()->add($shapeTrigger);
    # Δημιουργεί προσαρμοσμένη διαδρομή χρήστη. Το αντικείμενό μας θα κινηθεί μόνο μετά το κλικ στο κουμπί.
    $fxUserPath = $seqInter->addEffect($ashp, EffectType::PathUser, EffectSubType::None, EffectTriggerType::OnClick);
    # Προσθέτει εντολές κίνησης επειδή η δημιουργημένη διαδρομή είναι κενή.
    $motionBhv = $fxUserPath->getBehaviors()->get_Item(0);
    $pts = new Point2DFloat[1];
    $pts[0] = new Point2DFloat(0.076, 0.59);
    $motionBhv->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, true);
    $pts[0] = new Point2DFloat(-0.076, -0.59);
    $motionBhv->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, false);
    $motionBhv->getPath()->add(MotionCommandPathType::End, null, MotionPathPointsType::Auto, false);
    # Γράφει το αρχείο PPTX στο δίσκο
    $pres->save("AnimExample_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Λήψη των εφέ κίνησης που έχουν εφαρμοστεί σε ένα Shape**

Τα παρακάτω παραδείγματα δείχνουν πώς να χρησιμοποιήσετε τη μέθοδο `getEffectsByShape` από την κλάση [Sequence](https://reference.aspose.com/slides/el/php-java/aspose.slides/sequence/) για να λάβετε όλα τα εφέ κίνησης που έχουν εφαρμοστεί σε ένα shape.

**Παράδειγμα 1: Λήψη εφέ κίνησης που έχουν εφαρμοστεί σε ένα shape σε κανονική διαφάνεια**

Στο παρελθόν, μάθατε πώς να προσθέτετε εφέ κίνησης σε σχήματα σε παρουσιάσεις PowerPoint. Ο παρακάτω κώδικας δείχνει πώς να λάβετε τα εφέ που εφαρμόζονται στο πρώτο shape στην πρώτη κανονική διαφάνεια της παρουσίασης `AnimExample_out.pptx`.

```php
  $Array = new java_class("java.lang.reflect.Array");
  $presentation = new Presentation("AnimExample_out.pptx");

  try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    # Λαμβάνει την κύρια ακολουθία κίνησης της διαφάνειας.
    $sequence = $firstSlide->getTimeline()->getMainSequence();

    # Λαμβάνει το πρώτο σχήμα στην πρώτη διαφάνεια.
    $shape = $firstSlide->getShapes()->get_Item(0);

    # Λαμβάνει τα εφέ κίνησης που εφαρμόζονται στο σχήμα.
    $shapeEffects = $sequence->getEffectsByShape($shape);

    if (java_values($Array->getLength($shapeEffects)) > 0) {
      echo("The shape " . $shape->getName() . " has " . $Array->getLength($shapeEffects) . " animation effects.");
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

**Παράδειγμα 2: Λήψη όλων των εφέ κίνησης, συμπεριλαμβανομένων αυτών που κληρονομούνται από placeholders**

Εάν ένα shape σε κανονική διαφάνεια έχει placeholders που βρίσκονται στη διαφάνεια διάταξης και/ή στην κύρια διαφάνεια, και σε αυτά τα placeholders έχουν προστεθεί εφέ κίνησης, τότε όλα τα εφέ του shape θα αναπαράγονται κατά τη διάρκεια της παρουσίασης, συμπεριλαμβανομένων αυτών που κληρονομούνται από τα placeholders.

Ας υποθέσουμε ότι έχουμε αρχείο παρουσίασης PowerPoint `sample.pptx` με μία διαφάνεια που περιέχει μόνο ένα shape υποσέλιδου με το κείμενο "Made with Aspose.Slides" και το εφέ **Random Bars** έχει εφαρμοστεί στο shape.

![Slide shape animation effect](slide-shape-animation.png)

Ας υποθέσουμε επίσης ότι το εφέ **Split** έχει εφαρμοστεί στο placeholder υποσέλιδου στη **layout** διαφάνεια.

![Layout shape animation effect](layout-shape-animation.png)

Τέλος, το εφέ **Fly In** έχει εφαρμοστεί στο placeholder υποσέλιδου στη **master** διαφάνεια.

![Master shape animation effect](master-shape-animation.png)

Ο παρακάτω κώδικας δείχνει πώς να χρησιμοποιήσετε τη μέθοδο `getBasePlaceholder` από την κλάση [Shape](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/) για να αποκτήσετε πρόσβαση στα placeholders του shape και να λάβετε τα εφέ κίνησης που έχουν εφαρμοστεί στο shape του υποσέλιδου, συμπεριλαμβανομένων αυτών που κληρονομούνται από placeholders που βρίσκονται στις διαφάνειες layout και master.

```php
$presentation = new Presentation("sample.pptx");

$slide = $presentation->getSlides()->get_Item(0);

// Λαμβάνει τα εφέ κίνησης του σχήματος στη κανονική διαφάνεια.
$shape = $slide->getShapes()->get_Item(0);
$shapeEffects = $slide->getTimeline()->getMainSequence()->getEffectsByShape($shape);

// Λαμβάνει τα εφέ κίνησης του placeholder στη διαφάνεια διάταξης.
$layoutShape = $shape->getBasePlaceholder();
$layoutShapeEffects = $slide->getLayoutSlide()->getTimeline()->getMainSequence()->getEffectsByShape($layoutShape);

// Λαμβάνει τα εφέ κίνησης του placeholder στη κύρια διαφάνεια.
$masterShape = $layoutShape->getBasePlaceholder();
$masterShapeEffects = $slide->getLayoutSlide()->getMasterSlide()->getTimeline()->getMainSequence()->getEffectsByShape($masterShape);

echo "Main sequence of shape effects:" . PHP_EOL;
printEffects($masterShapeEffects);
printEffects($layoutShapeEffects);
printEffects($shapeEffects);

$presentation->dispose();
```
```php
function printEffects($effects) {
    foreach ($effects as $effect) {
        echo "Type: " . $effect->getType() . ", subtype: " . $effect->getSubtype() . PHP_EOL;
    }
}
```

```text
Main sequence of shape effects:
Type: 47, subtype: 2              // Πτήση, Κάτω
Type: 134, subtype: 45            // Διαίρεση, Κατακόρυφο Εντός
Type: 126, subtype: 22            // Τυχαίες Μπάρες, Οριζόντια
```

## **Αλλαγή μεθόδων χρονολόγησης εφέ κίνησης**

Το Aspose.Slides for PHP via Java σας επιτρέπει να αλλάξετε τις ιδιότητες Timing ενός εφέ κίνησης.

![example1_image](shape-animation.png)

Αυτές είναι οι αντιστοιχίες μεταξύ PowerPoint Timing και ιδιοτήτων [Effect Timing](https://reference.aspose.com/slides/el/php-java/aspose.slides/effect/#getTiming):

- Η λίστα επιλογής **Start** του PowerPoint Timing αντιστοιχεί στη μέθοδο [Timing::getTriggerType](https://reference.aspose.com/slides/el/php-java/aspose.slides/timing/#getTriggerType).  
- Το **Duration** του PowerPoint Timing αντιστοιχεί στη μέθοδο [Timing::getDuration](https://reference.aspose.com/slides/el/php-java/aspose.slides/timing/#getDuration). Η διάρκεια μιας κίνησης (σε δευτερόλεπτα) είναι ο συνολικός χρόνος που χρειάζεται για να ολοκληρωθεί ένας κύκλος.  
- Το **Delay** του PowerPoint Timing αντιστοιχεί στη μέθοδο [Timing::getTriggerDelayTime](https://reference.aspose.com/slides/el/php-java/aspose.slides/timing/#getTriggerDelayTime).  

Αυτή είναι η διαδικασία αλλαγής των ιδιοτήτων χρονολόγησης του εφέ:

1. [Apply](#apply-animation-to-shape) ή λάβετε το εφέ κίνησης.  
2. Ορίστε τις νέες τιμές που χρειάζεστε χρησιμοποιώντας τη μέθοδο [Effect::getTiming](https://reference.aspose.com/slides/el/php-java/aspose.slides/effect/#getTiming).  
3. Αποθηκεύστε το τροποποιημένο αρχείο PPTX.  

```php
  # Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο παρουσίασης.
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # Λαμβάνει την κύρια ακολουθία της διαφάνειας.
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # Λαμβάνει το πρώτο εφέ της κύριας ακολουθίας.
    $effect = $sequence->get_Item(0);
    # Αλλάζει το TriggerType του εφέ ώστε να ξεκινά με κλικ
    $effect->getTiming()->setTriggerType(EffectTriggerType::OnClick);
    # Αλλάζει τη διάρκεια του εφέ
    $effect->getTiming()->setDuration(3.0);
    # Αλλάζει το TriggerDelayTime του εφέ
    $effect->getTiming()->setTriggerDelayTime(0.5);
    # Αποθηκεύει το αρχείο PPTX στο δίσκο
    $pres->save("AnimExample_changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ήχος εφέ κίνησης**

Το Aspose.Slides παρέχει αυτές τις μεθόδους για εργασία με ήχους σε εφέ κίνησης:  

- [setSound(IAudio value)](https://reference.aspose.com/slides/el/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)  
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/el/php-java/aspose.slides/effect/#setStopPreviousSound-boolean-)

### **Προσθήκη ήχου σε εφέ κίνησης**

Αυτός ο κώδικας PHP δείχνει πώς να προσθέσετε ήχο σε εφέ κίνησης και να τον σταματήσετε όταν ξεκινά το επόμενο εφέ:

```php
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # Προσθέτει ήχο στη συλλογή ήχων της παρουσίασης
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "sampleaudio.wav"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $effectSound = $pres->getAudios()->addAudio($bytes);

    $firstSlide = $pres->getSlides()->get_Item(0);
    # Λαμβάνει την κύρια ακολουθία της διαφάνειας.
    $sequence = $firstSlide->getTimeline()->getMainSequence();
    # Λαμβάνει το πρώτο εφέ της κύριας ακολουθίας
    $firstEffect = $sequence->get_Item(0);
    # Ελέγχει το εφέ για "Χωρίς ήχο"
    if (java_is_null(!$firstEffect->getStopPreviousSound() && $firstEffect->getSound())) {
      # Προσθέτει ήχο στο πρώτο εφέ
      $firstEffect->setSound($effectSound);
    }
    # Λαμβάνει την πρώτη διαδραστική ακολουθία της διαφάνειας.
    $interactiveSequence = $firstSlide->getTimeline()->getInteractiveSequences()->get_Item(0);
    # Ορίζει τη σημαία εφέ "Σταμάτημα προηγούμενου ήχου"
    $interactiveSequence->get_Item(0)->setStopPreviousSound(true);
    # Γράφει το αρχείο PPTX στο δίσκο
    $pres->save("AnimExample_Sound_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Εξαγωγή ήχου εφέ κίνησης**

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) .  
2. Λάβετε μια αναφορά σε διαφάνεια μέσω του δείκτη της.  
3. Αποκτήστε την κύρια ακολουθία εφέ.  
4. Εξάγετε το [setSound(IAudio value)](https://reference.aspose.com/slides/el/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) ενσωματωμένο σε κάθε εφέ κίνησης.  

Αυτός ο κώδικας PHP δείχνει πώς να εξάγετε τον ήχο που είναι ενσωματωμένος σε ένα εφέ κίνησης:

```php
  # Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο παρουσίασης.
  $presentation = new Presentation("EffectSound.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Λαμβάνει την κύρια ακολουθία της διαφάνειας.
    $sequence = $slide->getTimeline()->getMainSequence();
    foreach($sequence as $effect) {
      if (java_is_null($effect->getSound())) {
        continue;
      }
      # Εξάγει τον ήχο του εφέ σε byte array
      $audio = $effect->getSound()->getBinaryData();
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Μετά την κίνηση**

Το Aspose.Slides for PHP via Java σας επιτρέπει να αλλάξετε την ιδιότητα After animation ενός εφέ κίνησης.

![example1_image](shape-after-animation.png)

Η λίστα επιλογής **After animation** του PowerPoint ταιριάζει με τις ακόλουθες μεθόδους:  

- Η μέθοδος [setAfterAnimationType(int value)](https://reference.aspose.com/slides/el/php-java/aspose.slides/effect/#setAfterAnimationType) περιγράφει τον τύπο After animation:  
  * Το **More Colors** του PowerPoint ταιριάζει με τον τύπο [AfterAnimationType::Color](https://reference.aspose.com/slides/el/php-java/aspose.slides/afteranimationtype/#Color).  
  * Το **Don't Dim** του PowerPoint ταιριάζει με τον τύπο [AfterAnimationType::DoNotDim](https://reference.aspose.com/slides/el/php-java/aspose.slides/afteranimationtype/#DoNotDim) (προεπιλεγμένος τύπος μετά την κίνηση).  
  * Το **Hide After Animation** του PowerPoint ταιριάζει με τον τύπο [AfterAnimationType::HideAfterAnimation](https://reference.aspose.com/slides/el/php-java/aspose.slides/afteranimationtype/#HideAfterAnimation).  
  * Το **Hide on Next Mouse Click** του PowerPoint ταιριάζει με τον τύπο [AfterAnimationType::HideOnNextMouseClick](https://reference.aspose.com/slides/el/php-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick).  

- Η μέθοδος [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/el/php-java/aspose.slides/effect/#setAfterAnimationColor) ορίζει μια μορφή χρώματος μετά την κίνηση. Αυτή η μέθοδος λειτουργεί σε συνδυασμό με τον τύπο [AfterAnimationType::Color](https://reference.aspose.com/slides/el/php-java/aspose.slides/afteranimationtype/#Color). Εάν αλλάξετε τον τύπο σε κάποιον άλλο, το χρώμα μετά την κίνηση θα διαγραφεί.  

```php
  # Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο παρουσίασης
  $pres = new Presentation("AnimImage_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # Λαμβάνει το πρώτο εφέ της κύριας ακολουθίας
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # Αλλάζει τον τύπο μετά την κίνηση σε Χρώμα
    $firstEffect->setAfterAnimationType(AfterAnimationType::Color);
    # Ορίζει το χρώμα μετά την κίνηση
    $firstEffect->getAfterAnimationColor()->setColor(java("java.awt.Color")->BLUE);
    # Γράφει το αρχείο PPTX στο δίσκο
    $pres->save("AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Κίνηση κειμένου**

Το Aspose.Slides παρέχει αυτές τις μεθόδους για εργασία με το τμήμα *Animate text* ενός εφέ κίνησης:  

- Η μέθοδος [setAnimateTextType(int value)](https://reference.aspose.com/slides/el/php-java/aspose.slides/effect/#setAnimateTextType) περιγράφει έναν τύπο κειμένου κίνησης του εφέ. Το κείμενο του shape μπορεί να κινείται:  
  * Όλη τη φορά ([AnimateTextType::AllAtOnce](https://reference.aspose.com/slides/el/php-java/aspose.slides/animatetexttype/#AllAtOnce) τύπος)  
  * Κατά λέξη ([AnimateTextType::ByWord](https://reference.aspose.com/slides/el/php-java/aspose.slides/animatetexttype/#ByWord) τύπος)  
  * Κατά γράμμα ([AnimateTextType::ByLetter](https://reference.aspose.com/slides/el/php-java/aspose.slides/animatetexttype/#ByLetter) τύπος)  
- Η μέθοδος [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/el/php-java/aspose.slides/effect/#setDelayBetweenTextParts) ορίζει μια καθυστέρηση μεταξύ των τμημάτων του κειμένου που κινείται (λέξεις ή γράμματα). Μια θετική τιμή καθορίζει το ποσοστό της διάρκειας του εφέ. Μια αρνητική τιμή καθορίζει την καθυστέρηση σε δευτερόλεπτα.  

Αυτή είναι η διαδικασία αλλαγής των ιδιοτήτων κίνησης κειμένου:

1. [Apply](#apply-animation-to-shape) ή λάβετε το εφέ κίνησης.  
2. Χρησιμοποιήστε τη μέθοδο [setBuildType(int value)](https://reference.aspose.com/slides/el/php-java/aspose.slides/textanimation/#setBuildType) και την τιμή [BuildType::AsOneObject](https://reference.aspose.com/slides/el/php-java/aspose.slides/buildtype/#AsOneObject) για να απενεργοποιήσετε τη λειτουργία κίνησης *By Paragraphs*.  
3. Ορίστε νέες τιμές χρησιμοποιώντας τις μεθόδους [setAnimateTextType(int value)](https://reference.aspose.com/slides/el/php-java/aspose.slides/effect/#setAnimateTextType) και [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/el/php-java/aspose.slides/effect/#setDelayBetweenTextParts).  
4. Αποθηκεύστε το τροποποιημένο αρχείο PPTX.  

```php
  # Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο παρουσίασης.
  $pres = new Presentation("AnimTextBox_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # Λαμβάνει το πρώτο εφέ της κύριας ακολουθίας
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # Αλλάζει τον τύπο κίνησης κειμένου του εφέ σε "Ως ένα αντικείμενο"
    $firstEffect->getTextAnimation()->setBuildType(BuildType::AsOneObject);
    # Αλλάζει τον τύπο κίνησης κειμένου του εφέ σε "Κατά λέξη"
    $firstEffect->setAnimateTextType(AnimateTextType::ByWord);
    # Ορίζει την καθυστέρηση μεταξύ των λέξεων στο 20% της διάρκειας του εφέ
    $firstEffect->setDelayBetweenTextParts(20.0);
    # Γράφει το αρχείο PPTX στο δίσκο
    $pres->save("AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Πώς μπορώ να εξασφαλίσω ότι οι κινήσεις παραμένουν όταν δημοσιεύω την παρουσίαση στο web;**

[Export to HTML5](/slides/el/php-java/export-to-html5/) και ενεργοποιήστε τις [options](https://reference.aspose.com/slides/el/php-java/aspose.slides/html5options/) που είναι υπεύθυνες για τα animations των [shape](https://reference.aspose.com/slides/el/php-java/aspose.slides/html5options/setanimateshapes/) και των [transition](https://reference.aspose.com/slides/el/php-java/aspose.slides/html5options/setanimatetransitions/). Το απλό HTML δεν εκτελεί τις κινήσεις των διαφανειών, ενώ το HTML5 το κάνει.

**Πώς η αλλαγή της σειράς z-order (σειράς επιπέδων) των shapes επηρεάζει την κίνηση;**

Η κίνηση και η σειρά σχεδίασης είναι ανεξάρτητες: ένα εφέ ελέγχει το χρονοδιάγραμμα και τον τύπο της εμφάνισης/απόκρυψης, ενώ το [z-order](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/getzorderposition/) καθορίζει τι καλύπτει τι. Το ορατό αποτέλεσμα καθορίζεται από τον συνδυασμό τους. (Αυτή είναι η γενική συμπεριφορά του PowerPoint· το μοντέλο effects-and-shapes του Aspose.Slides ακολουθεί την ίδια λογική.)

**Υπάρχουν περιορισμοί κατά τη μετατροπή κινήσεων σε βίντεο για ορισμένα εφέ;**

Γενικά, τα [animations are supported](/slides/el/php-java/convert-powerpoint-to-video/), αλλά σπάνιες περιπτώσεις ή συγκεκριμένα εφέ μπορεί να αποδοθούν διαφορετικά. Συνιστάται να δοκιμάζετε με τα εφέ που χρησιμοποιείτε και με την έκδοση της βιβλιοθήκης.