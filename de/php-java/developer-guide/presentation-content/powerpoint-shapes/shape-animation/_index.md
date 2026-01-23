---
title: Formanimationen in Präsentationen mit PHP anwenden
linktitle: Formanimation
type: docs
weight: 60
url: /de/php-java/shape-animation/
keywords:
- Form
- Animation
- Effekt
- animierte Form
- animierter Text
- Animation hinzufügen
- Animation abrufen
- Animation extrahieren
- Effekt hinzufügen
- Effekt abrufen
- Effekt extrahieren
- Effektgeräusch
- Animation anwenden
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Entdecken Sie, wie Sie Formanimationen in PowerPoint-Präsentationen mit Aspose.Slides für PHP via Java erstellen und anpassen. Hervorstechen!"
---

Animationen sind visuelle Effekte, die auf Texte, Bilder, Formen oder [Diagramme](https://docs.aspose.com/slides/php-java/animated-charts/) angewendet werden können. Sie verleihen Präsentationen oder deren Bestandteilen Leben.

## **Warum Animationen in Präsentationen verwenden?**

Durch den Einsatz von Animationen können Sie  

* den Informationsfluss steuern  
* wichtige Punkte hervorheben  
* das Interesse oder die Teilnahme des Publikums erhöhen  
* den Inhalt leichter lesbar oder verdaulich bzw. verarbeitbar machen  
* die Aufmerksamkeit der Leser oder Zuschauer auf wichtige Teile einer Präsentation lenken  

PowerPoint bietet zahlreiche Optionen und Werkzeuge für Animationen und Animationseffekte in den Kategorien **Entrance**, **Exit**, **Emphasis** und **Motion Paths**.

## **Animationen in Aspose.Slides**

* Aspose.Slides stellt die Klassen und Typen bereit, die Sie benötigen, um mit Animationen im Namespace `Aspose.Slides.Animation` zu arbeiten,  
* Aspose.Slides bietet über **150 Animationseffekte** im [EffectType](https://reference.aspose.com/slides/php-java/aspose.slides/effecttype)-Aufzählungstyp. Diese Effekte entsprechen im Wesentlichen den in PowerPoint verwendeten Effekten.

## **Animation auf ein Textfeld anwenden**

Aspose.Slides für PHP via Java ermöglicht das Anwenden von Animationen auf den Text in einer Form.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.  
2. Holen Sie sich eine Folienreferenz über deren Index.  
3. Fügen Sie ein rechteckiges [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) hinzu.  
4. Fügen Sie `AutoShape`'s [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#getTextFrame) Text hinzu.  
5. Holen Sie die Hauptsequenz von Effekten.  
6. Fügen Sie einen Animationseffekt zu [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) hinzu.  
7. Verwenden Sie die Methode `TextAnimation.setBuildType` und den Wert aus der Aufzählung `BuildType`.  
8. Schreiben Sie die Präsentation als PPTX‑Datei auf die Festplatte.  

Dieser PHP‑Code zeigt, wie Sie den `Fade`‑Effekt auf ein AutoShape anwenden und die Textanimation auf den Wert *By 1st Level Paragraphs* setzen:
```php
  # Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # Fügt ein neues AutoShape mit Text hinzu
    $autoShape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 100);
    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("First paragraph \nSecond paragraph \n Third paragraph");
    # Holt die Hauptsequenz der Folie.
    $sequence = $sld->getTimeline()->getMainSequence();
    # Fügt dem Shape den Fade-Animationseffekt hinzu
    $effect = $sequence->addEffect($autoShape, EffectType::Fade, EffectSubType::None, EffectTriggerType::OnClick);
    # Animiert den Shape-Text nach Absätzen der ersten Ebene
    $effect->getTextAnimation()->setBuildType(BuildType::ByLevelParagraphs1);
    # Speichert die PPTX-Datei auf die Festplatte
    $pres->save($path . "AnimText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{%  alert color="primary"  %}} 

Neben dem Anwenden von Animationen auf Text können Sie auch Animationen auf einen einzelnen [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) anwenden. Siehe **[Animierter Text](/slides/de/php-java/animated-text/)**.

{{% /alert %}} 

## **Animation auf einen PictureFrame anwenden**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.  
2. Holen Sie sich eine Folienreferenz über deren Index.  
3. Fügen Sie ein [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe) auf der Folie hinzu oder holen Sie ein vorhandenes.  
4. Holen Sie die Hauptsequenz von Effekten.  
5. Fügen Sie einen Animationseffekt zu [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe) hinzu.  
6. Schreiben Sie die Präsentation als PPTX‑Datei auf die Festplatte.  

Dieser PHP‑Code zeigt, wie Sie den `Fly`‑Effekt auf einen Bildrahmen anwenden:
```php
  # Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
  $pres = new Presentation();
  try {
    # Lädt ein Bild, das zur Bildersammlung der Präsentation hinzugefügt werden soll
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Fügt Bildrahmen zur Folie hinzu
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, $picture);
    # Holt die Hauptsequenz der Folie.
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # Fügt dem Bildrahmen den Animationseffekt „Fliegen von links“ hinzu
    $effect = $sequence->addEffect($picFrame, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    # Speichert die PPTX-Datei auf die Festplatte
    $pres->save($path . "AnimImage_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Animation auf eine Form anwenden**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.  
2. Holen Sie sich eine Folienreferenz über deren Index.  
3. Fügen Sie ein rechteckiges [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) hinzu.  
4. Fügen Sie ein abgeschrägtes [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) hinzu (wenn dieses Objekt angeklickt wird, wird die Animation abgespielt).  
5. Erstellen Sie eine Sequenz von Effekten für die abgeschrägte Form.  
6. Erstellen Sie einen benutzerdefinierten `UserPath`.  
7. Fügen Sie Befehle zum Bewegen entlang des `UserPath` hinzu.  
8. Schreiben Sie die Präsentation als PPTX‑Datei auf die Festplatte.  

Dieser PHP‑Code zeigt, wie Sie den `PathFootball`‑Effekt (Pfad‑Fußball) auf eine Form anwenden:
```php
  # Instanziiert eine Presentation-Klasse, die eine PPTX-Datei darstellt.
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # Erstellt den PathFootball-Effekt für eine vorhandene Form von Grund auf.
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);
    $ashp->addTextFrame("Animated TextBox");
    # Fügt den PathFootball-Animationseffekt hinzu
    $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($ashp, EffectType::PathFootball, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Erstellt eine Art "Button".
    $shapeTrigger = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Bevel, 10, 10, 20, 20);
    # Erstellt eine Sequenz von Effekten für diesen Button.
    $seqInter = $pres->getSlides()->get_Item(0)->getTimeline()->getInteractiveSequences()->add($shapeTrigger);
    # Erstellt einen benutzerdefinierten Pfad. Unser Objekt wird nur bewegt, nachdem der Button geklickt wurde.
    $fxUserPath = $seqInter->addEffect($ashp, EffectType::PathUser, EffectSubType::None, EffectTriggerType::OnClick);
    # Fügt Befehle zum Bewegen hinzu, da der erstellte Pfad leer ist.
    $motionBhv = $fxUserPath->getBehaviors()->get_Item(0);
    $pts = new Point2DFloat[1];
    $pts[0] = new Point2DFloat(0.076, 0.59);
    $motionBhv->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, true);
    $pts[0] = new Point2DFloat(-0.076, -0.59);
    $motionBhv->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, false);
    $motionBhv->getPath()->add(MotionCommandPathType::End, null, MotionPathPointsType::Auto, false);
    # Schreibt die PPTX-Datei auf die Festplatte
    $pres->save("AnimExample_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Die auf eine Form angewendeten Animationseffekte abrufen**

Die folgenden Beispiele zeigen, wie Sie die Methode `getEffectsByShape` aus der [Sequence](https://reference.aspose.com/slides/php-java/aspose.slides/sequence/)‑Klasse verwenden, um alle auf eine Form angewendeten Animationseffekte zu erhalten.

**Beispiel 1: Animationseffekte einer Form auf einer normalen Folie abrufen**

Zuvor haben Sie gelernt, wie man Animationseffekte zu Formen in PowerPoint‑Präsentationen hinzufügt. Der folgende Beispielcode zeigt, wie Sie die auf die erste Form der ersten normalen Folie in der Präsentation `AnimExample_out.pptx` angewendeten Effekte erhalten.
```php
  $Array = new java_class("java.lang.reflect.Array");
  $presentation = new Presentation("AnimExample_out.pptx");

  try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    # Holt die Hauptanimationssequenz der Folie.
    $sequence = $firstSlide->getTimeline()->getMainSequence();

    # Holt die erste Form auf der ersten Folie.
    $shape = $firstSlide->getShapes()->get_Item(0);

    # Holt die auf die Form angewendeten Animationseffekte.
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


**Beispiel 2: Alle Animationseffekte, einschließlich der von Platzhaltern geerbten, abrufen**

Hat eine Form auf einer normalen Folie Platzhalter, die auf der Layout‑ bzw. Master‑Folien liegen, und wurden diesen Platzhaltern Animationseffekte hinzugefügt, dann werden sämtliche Effekte der Form während der Bildschirmanzeige abgespielt, auch die von den Platzhaltern geerbten.

Angenommen, wir besitzen eine PowerPoint‑Datei `sample.pptx` mit einer Folie, die ausschließlich eine Fußzeilen‑Form mit dem Text „Made with Aspose.Slides“ enthält, und auf diese Form wurde der Effekt **Random Bars** angewendet.

![Folienformen‑Animations‑Effekt](slide-shape-animation.png)

Nehmen wir weiter an, dass auf dem **Layout**‑Folie‑Platzhalter der Fußzeile der Effekt **Split** angewendet wurde.

![Layout‑Formen‑Animations‑Effekt](layout-shape-animation.png)

Und schließlich wurde auf dem **Master**‑Folie‑Platzhalter der Fußzeile der Effekt **Fly In** angewendet.

![Master‑Formen‑Animations‑Effekt](master-shape-animation.png)

Der folgende Beispielcode zeigt, wie Sie die Methode `getBasePlaceholder` aus der [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/)‑Klasse nutzen, um auf die Platzhalter der Form zuzugreifen und die auf die Fußzeilen‑Form angewendeten Animationseffekte – einschließlich der von Platzhaltern auf Layout‑ und Master‑Folien geerbten – zu erhalten.
```php
$presentation = new Presentation("sample.pptx");

$slide = $presentation->getSlides()->get_Item(0);

// Animations‑effekte der Form auf der normalen Folie erhalten.
$shape = $slide->getShapes()->get_Item(0);
$shapeEffects = $slide->getTimeline()->getMainSequence()->getEffectsByShape($shape);

// Animations‑effekte des Platzhalters auf der Layout‑Folie erhalten.
$layoutShape = $shape->getBasePlaceholder();
$layoutShapeEffects = $slide->getLayoutSlide()->getTimeline()->getMainSequence()->getEffectsByShape($layoutShape);

// Animations‑effekte des Platzhalters auf der Master‑Folie erhalten.
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


Ausgabe:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // Fliegen, Unten
Type: 134, subtype: 45            // Split, VertikalEin
Type: 126, subtype: 22            // Zufällige Balken, Horizontal
```


## **Methoden zum Ändern der Timing‑Parameter von Animationseffekten**

Aspose.Slides für PHP via Java ermöglicht das Ändern der Timing‑Eigenschaften eines Animationseffekts.

Dies ist das Timing‑Fenster für Animationen in Microsoft PowerPoint:

![Beispiel1_Bild](shape-animation.png)

Dies sind die Zuordnungen zwischen PowerPoint‑Timing und den Eigenschaften von [Effect Timing](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#getTiming):

- Das Dropdown‑Feld **Start** in PowerPoint entspricht der Methode [Timing::getTriggerType](https://reference.aspose.com/slides/php-java/aspose.slides/timing/#getTriggerType).  
- **Duration** in PowerPoint entspricht der Methode [Timing::getDuration](https://reference.aspose.com/slides/php-java/aspose.slides/timing/#getDuration). Die Dauer einer Animation (in Sekunden) ist die Gesamtzeit, die die Animation für einen Durchlauf benötigt.  
- **Delay** in PowerPoint entspricht der Methode [Timing::getTriggerDelayTime](https://reference.aspose.com/slides/php-java/aspose.slides/timing/#getTriggerDelayTime).  

So ändern Sie die Eigenschaften des Effect Timing:

1. [Anwenden](#apply-animation-to-shape) oder holen Sie den Animationseffekt.  
2. Setzen Sie die gewünschten neuen Werte mittels der Methode [Effect::getTiming](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#getTiming).  
3. Speichern Sie die modifizierte PPTX‑Datei.  

Dieser PHP‑Code demonstriert die Vorgehensweise:
```php
  # Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # Holt die Hauptsequenz der Folie.
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # Holt den ersten Effekt der Hauptsequenz.
    $effect = $sequence->get_Item(0);
    # Ändert den Effekt-TriggerTyp, um beim Klick zu starten
    $effect->getTiming()->setTriggerType(EffectTriggerType::OnClick);
    # Ändert die Dauer des Effekts
    $effect->getTiming()->setDuration(3.0);
    # Ändert die Triggerverzögerungszeit des Effekts
    $effect->getTiming()->setTriggerDelayTime(0.5);
    # Speichert die PPTX-Datei auf die Festplatte
    $pres->save("AnimExample_changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Sound für Animationseffekte**

Aspose.Slides stellt folgende Methoden bereit, um mit Sounds in Animationseffekten zu arbeiten:  

- [setSound(IAudio value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)  
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setStopPreviousSound-boolean-)

### **Einen Sound zu einem Animationseffekt hinzufügen**

Dieser PHP‑Code zeigt, wie Sie einen Sound zu einem Animationseffekt hinzufügen und ihn stoppen, sobald der nächste Effekt startet:
```php
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # Fügt Audio zur Audio‑Sammlung der Präsentation hinzu
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
    # Holt die Hauptsequenz der Folie.
    $sequence = $firstSlide->getTimeline()->getMainSequence();
    # Holt den ersten Effekt der Hauptsequenz
    $firstEffect = $sequence->get_Item(0);
    # Prüft den Effekt auf „Kein Sound“
    if (java_is_null(!$firstEffect->getStopPreviousSound() && $firstEffect->getSound())) {
      # Fügt dem ersten Effekt Sound hinzu
      $firstEffect->setSound($effectSound);
    }
    # Holt die erste interaktive Sequenz der Folie.
    $interactiveSequence = $firstSlide->getTimeline()->getInteractiveSequences()->get_Item(0);
    # Setzt das Flag "Stop previous sound" des Effekts
    $interactiveSequence->get_Item(0)->setStopPreviousSound(true);
    # Schreibt die PPTX‑Datei auf die Festplatte
    $pres->save("AnimExample_Sound_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **Einen Sound aus einem Animationseffekt extrahieren**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)-Klasse.  
2. Holen Sie sich die Referenz einer Folie über deren Index.  
3. Holen Sie die Hauptsequenz von Effekten.  
4. Extrahieren Sie den in jedem Animationseffekt eingebetteten Aufruf von [setSound(IAudio value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-).  

Dieser PHP‑Code zeigt, wie Sie den in einem Animationseffekt eingebetteten Sound extrahieren:
```php
  # Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
  $presentation = new Presentation("EffectSound.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Holt die Hauptsequenz der Folie.
    $sequence = $slide->getTimeline()->getMainSequence();
    foreach($sequence as $effect) {
      if (java_is_null($effect->getSound())) {
        continue;
      }
      # Extrahiert den Sound des Effekts in ein Byte-Array
      $audio = $effect->getSound()->getBinaryData();
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **Nach Animation**

Aspose.Slides für PHP via Java ermöglicht das Ändern der Eigenschaft **After animation** eines Animationseffekts.

Dies ist das Fenster für Animationseffekte und das erweiterte Menü in Microsoft PowerPoint:

![Beispiel1_Bild](shape-after-animation.png)

Das Dropdown‑Feld **After animation** in PowerPoint entspricht diesen Methoden:  

- Die Methode [setAfterAnimationType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setAfterAnimationType) definiert den Typ der Nach‑Animation:  
  * **More Colors** entspricht dem Typ [AfterAnimationType::Color](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#Color);  
  * **Don't Dim** entspricht dem Typ [AfterAnimationType::DoNotDim](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#DoNotDim) (Standard‑Typ);  
  * **Hide After Animation** entspricht dem Typ [AfterAnimationType::HideAfterAnimation](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#HideAfterAnimation);  
  * **Hide on Next Mouse Click** entspricht dem Typ [AfterAnimationType::HideOnNextMouseClick](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick).  
- Die Methode [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setAfterAnimationColor) definiert ein Farbformat für die Nach‑Animation und arbeitet zusammen mit dem Typ [AfterAnimationType::Color](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#Color). Wird der Typ zu einem anderen geändert, wird die Farbe zurückgesetzt.  

Dieser PHP‑Code zeigt, wie Sie einen Nach‑Animationseffekt ändern:
```php
  # Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
  $pres = new Presentation("AnimImage_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # Holt den ersten Effekt der Hauptsequenz
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # Ändert den Typ der Nach‑Animation zu Farbe
    $firstEffect->setAfterAnimationType(AfterAnimationType::Color);
    # Setzt die Dim‑Farbe der Nach‑Animation
    $firstEffect->getAfterAnimationColor()->setColor(java("java.awt.Color")->BLUE);
    # Schreibt die PPTX‑Datei auf die Festplatte
    $pres->save("AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Text animieren**

Aspose.Slides stellt folgende Methoden bereit, um mit dem *Animate text*‑Block eines Animationseffekts zu arbeiten:  

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setAnimateTextType) definiert, wie der Text einer Form animiert wird:  
  * Alle gleichzeitig ([AnimateTextType::AllAtOnce](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#AllAtOnce))  
  * Wortweise ([AnimateTextType::ByWord](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#ByWord))  
  * Buchstabenweise ([AnimateTextType::ByLetter](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#ByLetter))  
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setDelayBetweenTextParts) legt eine Verzögerung zwischen den animierten Textteilen (Wörter bzw. Buchstaben) fest. Ein positiver Wert gibt den Prozentsatz der Effektdauer an, ein negativer Wert die Verzögerung in Sekunden.

So ändern Sie die Eigenschaften **Animate text** eines Effekts:

1. [Anwenden](#apply-animation-to-shape) oder holen Sie den Animationseffekt.  
2. Verwenden Sie die Methode [setBuildType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/textanimation/#setBuildType) mit dem Wert [BuildType::AsOneObject](https://reference.aspose.com/slides/php-java/aspose.slides/buildtype/#AsOneObject), um den Modus *By Paragraphs* zu deaktivieren.  
3. Setzen Sie neue Werte mit den Methoden [setAnimateTextType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setAnimateTextType) und [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setDelayBetweenTextParts).  
4. Speichern Sie die modifizierte PPTX‑Datei.  

Dieser PHP‑Code demonstriert die Vorgehensweise:
```php
  # Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
  $pres = new Presentation("AnimTextBox_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # Holt den ersten Effekt der Hauptsequenz
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # Ändert den Textanimations-Typ des Effekts zu "As One Object"
    $firstEffect->getTextAnimation()->setBuildType(BuildType::AsOneObject);
    # Ändert den Animate-Text-Typ des Effekts zu "By word"
    $firstEffect->setAnimateTextType(AnimateTextType::ByWord);
    # Setzt die Verzögerung zwischen Wörtern auf 20% der Effekt-Dauer
    $firstEffect->setDelayBetweenTextParts(20.0);
    # Schreibt die PPTX-Datei auf die Festplatte
    $pres->save("AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Wie kann ich sicherstellen, dass Animationen beim Veröffentlichen der Präsentation im Web erhalten bleiben?**

[Export to HTML5](/slides/de/php-java/export-to-html5/) und aktivieren Sie die [Optionen](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/) für [shape](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/setanimateshapes/)‑ und [transition](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/setanimatetransitions/)‑Animationen. Normales HTML spielt Folienanimationen nicht ab, HTML5 jedoch schon.

**Wie wirkt sich das Ändern der Z‑Reihenfolge (Layer‑Reihenfolge) von Formen auf Animationen aus?**

Animation‑ und Zeichenreihenfolge sind unabhängig: Ein Effekt steuert das Timing und den Typ des Erscheinen/Verschwinden, während die [z‑order](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getzorderposition/) bestimmt, was was überlagert. Das sichtbare Ergebnis ergibt sich aus ihrer Kombination. (Dies ist das generelle Verhalten von PowerPoint; das Modell von Aspose.Slides folgt derselben Logik.)

**Gibt es Einschränkungen beim Konvertieren von Animationen in Video für bestimmte Effekte?**

Im Allgemeinen werden [Animationen unterstützt](/slides/de/php-java/convert-powerpoint-to-video/), jedoch können seltene Fälle oder spezielle Effekte anders gerendert werden. Es wird empfohlen, die von Ihnen genutzten Effekte und die jeweilige Bibliotheksversion zu testen.