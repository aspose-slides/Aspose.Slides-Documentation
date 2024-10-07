---
title: Formanimation
type: docs
weight: 60
url: /php-java/shape-animation/
keywords: "PowerPoint-Animation, Animationseffekt, Animation anwenden, PowerPoint-Präsentation, Java, Aspose.Slides für PHP über Java"
description: "PowerPoint-Animation anwenden"
---

Animationen sind visuelle Effekte, die auf Texte, Bilder, Formen oder [Diagramme](https://docs.aspose.com/slides/php-java/animated-charts/) angewendet werden können. Sie erwecken Präsentationen oder deren Bestandteile zum Leben.

### **Warum Animationen in Präsentationen verwenden?**

Durch die Verwendung von Animationen können Sie 

* den Fluss von Informationen steuern
* wichtige Punkte betonen
* das Interesse oder die Teilnahme Ihres Publikums erhöhen
* Inhalte leichter lesbar oder verdaulich machen
* die Aufmerksamkeit Ihrer Leser oder Zuschauer auf wichtige Teile in einer Präsentation lenken

PowerPoint bietet viele Optionen und Werkzeuge für Animationen und Animationseffekte in den Kategorien **Eingang**, **Ausgang**, **Betonung** und **Bewegungsbahnen**. 

### **Animationen in Aspose.Slides**

* Aspose.Slides bietet die Klassen und Typen, die Sie benötigen, um mit Animationen im `Aspose.Slides.Animation`-Namensraum zu arbeiten.
* Aspose.Slides bietet über **150 Animationseffekte** unter der [EffectType](https://reference.aspose.com/slides/php-java/aspose.slides/effecttype) Aufzählung. Diese Effekte sind im Wesentlichen dieselben (oder äquivalenten) Effekte, die in PowerPoint verwendet werden.

## **Animation auf TextBox anwenden**

Aspose.Slides für PHP über Java ermöglicht es Ihnen, Animationen auf den Text in einer Form anzuwenden.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
2. Erhalten Sie eine Folienreferenz über ihren Index.
3. Fügen Sie ein `rechteckiges` [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape) hinzu.
4. Fügen Sie Text zu [IAutoShape.TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape#addTextFrame-java.lang.String-) hinzu.
5. Holen Sie sich eine Hauptsequenz von Effekten.
6. Fügen Sie einen Animationseffekt zu [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape) hinzu.
7. Setzen Sie die `TextAnimation.BuildType`-Eigenschaft auf den Wert aus der `BuildType`-Enumeration.
8. Schreiben Sie die Präsentation als PPTX-Datei auf die Festplatte.

Dieser PHP-Code zeigt Ihnen, wie Sie den `Fade`-Effekt auf das AutoShape anwenden und die Texteffektnanimation auf den Wert *Nach 1. Ebene Absätzen* setzen:

```php
  # Instanziiert eine Präsentation, die eine Präsentationsdatei darstellt.
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # Fügt eine neue AutoShape mit Text hinzu
    $autoShape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 100);
    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("Erster Absatz \nZweiter Absatz \nDritter Absatz");
    # Holt die Hauptsequenz der Folie.
    $sequence = $sld->getTimeline()->getMainSequence();
    # Fügt einen Fade-Animationseffekt zur Form hinzu
    $effect = $sequence->addEffect($autoShape, EffectType::Fade, EffectSubType::None, EffectTriggerType::OnClick);
    # Animiert den Formtext nach den 1. Ebene Absätzen
    $effect->getTextAnimation()->setBuildType(BuildType::ByLevelParagraphs1);
    # Speichert die PPTX-Datei auf der Festplatte
    $pres->save($path . "AnimText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert color="primary"  %}} 

Neben der Anwendung von Animationen auf Text können Sie auch Animationen auf einen einzelnen [Absatz](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraph) anwenden. Siehe [**Animierter Text**](/slides/php-java/animated-text/).

{{% /alert %}} 

## **Animation auf PictureFrame anwenden**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
2. Holen Sie sich eine Folienreferenz über ihren Index.
3. Fügen Sie auf der Folie einen [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe) hinzu oder holen Sie ihn.
4. Holen Sie sich die Hauptsequenz von Effekten.
5. Fügen Sie einen Animationseffekt zu [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe) hinzu.
6. Schreiben Sie die Präsentation als PPTX-Datei auf die Festplatte.

Dieser PHP-Code zeigt Ihnen, wie Sie den `Fly`-Effekt auf einen PictureFrame anwenden:

```php
  # Instanziiert eine Präsentation, die eine Präsentationsdatei darstellt.
  $pres = new Presentation();
  try {
    # Bild zum Hinzufügen zur Präsentationsbildersammlung laden
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Fügt einen PictureFrame zur Folie hinzu
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, $picture);
    # Holt die Hauptsequenz der Folie.
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # Fügt den Fly from Left-Animationseffekt zum PictureFrame hinzu
    $effect = $sequence->addEffect($picFrame, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    # Speichert die PPTX-Datei auf der Festplatte
    $pres->save($path . "AnimImage_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Animation auf Form anwenden**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
2. Holen Sie sich eine Folienreferenz über ihren Index.
3. Fügen Sie ein `rechteckiges` [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape) hinzu.
4. Fügen Sie eine `Bevel` [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape) hinzu (wenn dieses Objekt angeklickt wird, wird die Animation abgespielt).
5. Erstellen Sie eine Sequenz von Effekten auf der Bevel-Form.
6. Erstellen Sie einen benutzerdefinierten `UserPath`.
7. Fügen Sie Befehle zum Bewegen zum `UserPath` hinzu.
8. Schreiben Sie die Präsentation als PPTX-Datei auf die Festplatte.

Dieser PHP-Code zeigt Ihnen, wie Sie den `PathFootball` (Pfadfußball)-Effekt auf eine Form anwenden:

```php
  # Instanziiert eine Präsentation, die eine PPTX-Datei darstellt.
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # Erstellt den PathFootball-Effekt für eine vorhandene Form von Grund auf.
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);
    $ashp->addTextFrame("Animierter TextBox");
    # Fügt den PathFootBall-Animationseffekt hinzu
    $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($ashp, EffectType::PathFootball, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Erstellt eine Art "Schaltfläche".
    $shapeTrigger = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Bevel, 10, 10, 20, 20);
    # Erstellt eine Sequenz von Effekten für diese Schaltfläche.
    $seqInter = $pres->getSlides()->get_Item(0)->getTimeline()->getInteractiveSequences()->add($shapeTrigger);
    # Erstellt einen benutzerdefinierten Benutzerpfad. Unser Objekt wird nur verschoben, nachdem die Schaltfläche angeklickt wurde.
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

Sie können entscheiden, alle auf eine einzelne Form angewendeten Animationseffekte herauszufinden. 

Dieser PHP-Code zeigt Ihnen, wie Sie alle Effekte abrufen, die auf eine bestimmte Form angewendet wurden:

```php
  # Instanziiert eine Präsentation, die eine Präsentationsdatei darstellt.
  $pres = new Presentation("AnimExample_out.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # Holt die Hauptsequenz der Folie.
    $sequence = $firstSlide->getTimeline()->getMainSequence();
    # Holt die erste Form auf der Folie.
    $shape = $firstSlide->getShapes()->get_Item(0);
    # Holt alle Animationseffekte, die auf die Form angewendet wurden.
    $shapeEffects = $sequence->getEffectsByShape($shape);
    if (java_values($Array->getLength($shapeEffects)) > 0) {
      echo("Die Form " . $shape->getName() . " hat " . $Array->getLength($shapeEffects) . " Animationseffekte.");
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ändern der Zeitwerte von Animationseffekten**

Aspose.Slides für PHP über Java ermöglicht es Ihnen, die Timing-Eigenschaften eines Animationseffekts zu ändern.

Das ist das Animation Timing-Fenster in Microsoft PowerPoint:

![example1_image](shape-animation.png)

Diese sind die Entsprechungen zwischen PowerPoint Timing und [Effect.Timing](https://reference.aspose.com/slides/php-java/aspose.slides/IEffect#getTiming--) Eigenschaften:

- PowerPoint Timing **Start** Dropdown-Liste entspricht der [Effect.Timing.TriggerType](https://reference.aspose.com/slides/php-java/aspose.slides/ITiming#getTriggerType--) Eigenschaft.
- PowerPoint Timing **Dauer** entspricht der [Effect.Timing.Duration](https://reference.aspose.com/slides/php-java/aspose.slides/ITiming#getDuration--) Eigenschaft. Die Dauer einer Animation (in Sekunden) ist die Gesamtzeit, die die Animation benötigt, um einen Zyklus abzuschließen.
- PowerPoint Timing **Verzögerung** entspricht der [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/php-java/aspose.slides/ITiming#getTriggerDelayTime--) Eigenschaft.

So ändern Sie die Effekte Timing Eigenschaften:

1. [Wenden Sie an](#apply-animation-to-shape) oder erhalten Sie den Animationseffekt.
2. Setzen Sie neue Werte für die [Effect.Timing](https://reference.aspose.com/slides/php-java/aspose.slides/IEffect#getTiming--) Eigenschaften, die Sie benötigen.
3. Speichern Sie die geänderte PPTX-Datei.

Dieser PHP-Code demonstriert den Vorgang:

```php
  # Instanziiert eine Präsentation, die eine Präsentationsdatei darstellt.
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # Holt die Hauptsequenz der Folie.
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # Holt den ersten Effekt der Hauptsequenz.
    $effect = $sequence->get_Item(0);
    # Ändert den Effekt TriggerType auf "Beim Klicken starten"
    $effect->getTiming()->setTriggerType(EffectTriggerType::OnClick);
    # Ändert die Effekt-Dauer
    $effect->getTiming()->setDuration(3.0);
    # Ändert den Effekt TriggerDelayTime
    $effect->getTiming()->setTriggerDelayTime(0.5);
    # Speichert die PPTX-Datei auf der Festplatte
    $pres->save("AnimExample_changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Soundeffekt der Animation**

Aspose.Slides bietet diese Eigenschaften, um Ihnen die Arbeit mit Sounds in Animationseffekten zu ermöglichen:

- [setSound(IAudio value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setStopPreviousSound-boolean-)

### **Animationseffekt-Sound hinzufügen**

Dieser PHP-Code zeigt Ihnen, wie Sie einen Sound für einen Animationseffekt hinzufügen und ihn stoppen, wenn der nächste Effekt beginnt:

```php
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # Fügt Audio zur Präsentationsaudio-Sammlung hinzu
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
    # Überprüft den Effekt auf "Kein Sound"
    if (java_is_null(!$firstEffect->getStopPreviousSound() && $firstEffect->getSound())) {
      # Fügt Sound für den ersten Effekt hinzu
      $firstEffect->setSound($effectSound);
    }
    # Holt die erste interaktive Sequenz der Folie.
    $interactiveSequence = $firstSlide->getTimeline()->getInteractiveSequences()->get_Item(0);
    # Setzt die "Vorherigen Sound stoppen" Flag des Effekts
    $interactiveSequence->get_Item(0)->setStopPreviousSound(true);
    # Schreibt die PPTX-Datei auf die Festplatte
    $pres->save("AnimExample_Sound_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Animationseffekt-Sound extrahieren**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse.
2. Holen Sie sich eine Folienreferenz über ihren Index. 
3. Holen Sie sich die Hauptsequenz der Effekte. 
4. Extrahieren Sie den [setSound(IAudio value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) in jeden Animationseffekt eingebetteten Sound.

Dieser PHP-Code zeigt Ihnen, wie Sie den in einem Animationseffekt eingebetteten Sound extrahieren:

```php
  # Instanziiert eine Präsentation, die eine Präsentationsdatei darstellt.
  $presentation = new Presentation("EffectSound.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Holt die Hauptsequenz der Folie.
    $sequence = $slide->getTimeline()->getMainSequence();
    foreach($sequence as $effect) {
      if (java_is_null($effect->getSound())) {
        continue;
      }
      # Extrahiert den Effekt-Sound in ein Byte-Array
      $audio = $effect->getSound()->getBinaryData();
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Nach der Animation**

Aspose.Slides für PHP über Java ermöglicht es Ihnen, die Nach-Animation-Eigenschaft eines Animationseffekts zu ändern.

Das ist das Animationseffektfenster und das erweiterte Menü in Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

PowerPoint Effekt **Nach der Animation** Dropdown-Liste entspricht diesen Eigenschaften: 

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setAfterAnimationType-int-) Eigenschaft, die den Nach-Animation-Typ beschreibt:
  * PowerPoint **Mehr Farben** entspricht dem [AfterAnimationType::Color](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#Color) Typ;
  * PowerPoint **Nicht dimmen** Listeneintrag entspricht dem [AfterAnimationType::DoNotDim](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#DoNotDim) Typ (standardmäßiger Nach-Animatioanteil);
  * PowerPoint **Nach der Animation ausblenden** entspricht dem [AfterAnimationType::HideAfterAnimation](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#HideAfterAnimation) Typ;
  * PowerPoint **Nach dem nächsten Mausklick ausblenden** Listeneintrag entspricht dem [AfterAnimationType::HideOnNextMouseClick](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick) Typ;
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) Eigenschaft, die ein Nach-Animation Farbformat definiert. Diese Eigenschaft arbeitet in Verbindung mit dem [AfterAnimationType::Color](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#Color) Typ. Wenn Sie den Typ auf einen anderen ändern, wird die Nach-Animationsfarbe gelöscht.

Dieser PHP-Code zeigt Ihnen, wie Sie einen Nach-Animationseffekt ändern:

```php
  # Instanziiert eine Präsentation, die eine Präsentationsdatei darstellt
  $pres = new Presentation("AnimImage_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # Holt den ersten Effekt der Hauptsequenz
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # Ändert den Nach-Animation-Typ auf Color
    $firstEffect->setAfterAnimationType(AfterAnimationType::Color);
    # Setzt die Nach-Animation-Dimmen-Farbe
    $firstEffect->getAfterAnimationColor()->setColor(java("java.awt.Color")->BLUE);
    # Schreibt die PPTX-Datei auf die Festplatte
    $pres->save("AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Text animieren**

Aspose.Slides bietet diese Eigenschaften, um Ihnen die Arbeit mit dem *Text animieren*-Block eines Animationseffekts zu ermöglichen:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setAnimateTextType-int-) beschreibt einen Animationstexttyp des Effekts. Der Text der Form kann animiert werden:
  - Alles auf einmal ([AnimateTextType::AllAtOnce](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#AllAtOnce) Typ)
  - Nach Wörtern ([AnimateTextType::ByWord](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#ByWord) Typ)
  - Nach Buchstaben ([AnimateTextType::ByLetter](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#ByLetter) Typ)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setDelayBetweenTextParts-float-) setzt eine Verzögerung zwischen den animierten Textteilen (Wörter oder Buchstaben). Ein positiver Wert gibt den Prozentsatz der Effekt-Dauer an. Ein negativer Wert gibt die Verzögerung in Sekunden an.

So ändern Sie die Eigenschaften Effekt *Text animieren*:

1. [Wenden Sie an](#apply-animation-to-shape) oder erhalten Sie den Animationseffekt.
2. Setzen Sie die [setBuildType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/itextanimation/#setBuildType-int-) Eigenschaft auf den Wert [BuildType::AsOneObject](https://reference.aspose.com/slides/php-java/aspose.slides/buildtype/#AsOneObject), um den Animationsmodus *Nach Absätzen* zu deaktivieren.
3. Setzen Sie neue Werte für die [setAnimateTextType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setAnimateTextType-int-) und [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setDelayBetweenTextParts-float-) Eigenschaften.
4. Speichern Sie die geänderte PPTX-Datei.

Dieser PHP-Code demonstriert den Vorgang:

```php
  # Instanziiert eine Präsentation, die eine Präsentationsdatei darstellt.
  $pres = new Presentation("AnimTextBox_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # Holt den ersten Effekt der Hauptsequenz
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # Ändert den Texteffekt-Typ auf "Als ein Objekt"
    $firstEffect->getTextAnimation()->setBuildType(BuildType::AsOneObject);
    # Ändert den Effekt *Text animieren* Typ auf "Nach Wort"
    $firstEffect->setAnimateTextType(AnimateTextType::ByWord);
    # Setzt die Verzögerung zwischen Wörtern auf 20 % der Effekt-Dauer
    $firstEffect->setDelayBetweenTextParts(20.0);
    # Schreibt die PPTX-Datei auf die Festplatte
    $pres->save("AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```