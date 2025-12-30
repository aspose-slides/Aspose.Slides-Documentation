---
title: Formenanimationen in Präsentationen mit PHP anwenden
linktitle: Formenanimation
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
- Effektton
- Animation anwenden
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Entdecken Sie, wie Sie Formenanimationen in PowerPoint‑Präsentationen mit Aspose.Slides für PHP via Java erstellen und anpassen. Hervorstechen!"
---

Animationen sind visuelle Effekte, die auf Texte, Bilder, Formen oder [Diagramme](https://docs.aspose.com/slides/php-java/animated-charts/) angewendet werden können. Sie verleihen Präsentationen oder deren Bestandteilen Leben.

## **Warum Animationen in Präsentationen verwenden?**

Mit Animationen können Sie

* den Informationsfluss steuern
* wichtige Punkte hervorheben
* das Interesse oder die Beteiligung Ihres Publikums erhöhen
* Inhalte leichter lesbar, verdaulich oder verarbeitbar machen
* die Aufmerksamkeit Ihrer Leser oder Zuschauer auf wichtige Teile einer Präsentation lenken

PowerPoint bietet zahlreiche Optionen und Werkzeuge für Animationen und Animationseffekte in den Kategorien **Eingang**, **Ausgang**, **Betonung** und **Bewegungspfade**.

## **Animationen in Aspose.Slides**

* Aspose.Slides stellt die Klassen und Typen bereit, die Sie benötigen, um mit Animationen im Namespace `Aspose.Slides.Animation` zu arbeiten,
* Aspose.Slides bietet über **150 Animationseffekte** im Aufzählungstyp [EffectType](https://reference.aspose.com/slides/php-java/aspose.slides/effecttype). Diese Effekte entsprechen im Wesentlichen denselben (oder äquivalenten) Effekten, die in PowerPoint verwendet werden.

## **Animation auf ein Textfeld anwenden**

Aspose.Slides for PHP via Java ermöglicht es Ihnen, Animationen auf den Text in einer Form anzuwenden.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.
2. Holen Sie sich eine Folienreferenz über deren Index.
3. Fügen Sie eine `rectangle` [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape) hinzu.
4. Fügen Sie Text zu [IAutoShape.TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape#addTextFrame-java.lang.String-) hinzu.
5. Erhalten Sie die Hauptsequenz der Effekte.
6. Fügen Sie einen Animationseffekt zu [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape) hinzu.
7. Setzen Sie die Eigenschaft `TextAnimation.BuildType` auf den Wert aus der Aufzählung `BuildType`.
8. Schreiben Sie die Präsentation als PPTX-Datei auf die Festplatte.

Dieser PHP‑Code zeigt, wie Sie den `Fade`‑Effekt auf eine AutoShape anwenden und die Textanimation auf den Wert *By 1st Level Paragraphs* setzen:
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
    # Sichert die PPTX-Datei auf dem Datenträger
    $pres->save($path . "AnimText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{%  alert color="primary"  %}} 

Neben der Anwendung von Animationen auf Text können Sie auch Animationen auf ein einzelnes [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraph) anwenden. Siehe [**Animierter Text**](/slides/de/php-java/animated-text/).

{{% /alert %}} 

## **Animation auf ein PictureFrame anwenden**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.
2. Holen Sie sich eine Folienreferenz über deren Index.
3. Fügen Sie ein [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe) zur Folie hinzu oder holen Sie es ab.
4. Erhalten Sie die Hauptsequenz der Effekte.
5. Fügen Sie einen Animationseffekt zu [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe) hinzu.
6. Schreiben Sie die Präsentation als PPTX-Datei auf die Festplatte.

Dieser PHP‑Code zeigt, wie Sie den `Fly`‑Effekt auf ein Bildrahmen anwenden:
```php
  # Instanziert eine Präsentationsklasse, die eine Präsentationsdatei repräsentiert.
  $pres = new Presentation();
  try {
    # Lädt ein Bild, das zur Bildsammlung der Präsentation hinzugefügt wird
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
    # Fügt dem Bildrahmen den Fly‑von‑links‑Animationseffekt hinzu
    $effect = $sequence->addEffect($picFrame, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    # Speichert die PPTX-Datei auf dem Datenträger
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
3. Fügen Sie eine `rectangle` [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape) hinzu.
4. Fügen Sie eine `Bevel` [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape) hinzu (wenn dieses Objekt angeklickt wird, wird die Animation abgespielt).
5. Erstellen Sie eine Sequenz von Effekten für die Keilform.
6. Erstellen Sie einen benutzerdefinierten `UserPath`.
7. Fügen Sie Befehle zum Bewegen zum `UserPath` hinzu.
8. Schreiben Sie die Präsentation als PPTX-Datei auf die Festplatte.

Dieser PHP‑Code zeigt, wie Sie den `PathFootball`‑Effekt auf eine Form anwenden:
```php
  # Instanziiert eine Presentation-Klasse, die eine PPTX-Datei darstellt.
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # Erstellt den PathFootball-Effekt für die vorhandene Form von Grund auf.
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);
    $ashp->addTextFrame("Animated TextBox");
    # Fügt den PathFootball-Animationseffekt hinzu
    $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($ashp, EffectType::PathFootball, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Erstellt eine Art "Button".
    $shapeTrigger = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Bevel, 10, 10, 20, 20);
    # Erstellt eine Sequenz von Effekten für diesen Button.
    $seqInter = $pres->getSlides()->get_Item(0)->getTimeline()->getInteractiveSequences()->add($shapeTrigger);
    # Erstellt einen benutzerdefinierten Pfad. Unser Objekt wird erst bewegt, nachdem der Button geklickt wurde.
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

Die folgenden Beispiele zeigen, wie Sie die Methode `getEffectsByShape` der [Sequence](https://reference.aspose.com/slides/php-java/aspose.slides/sequence/)-Klasse verwenden, um alle auf eine Form angewendeten Animationseffekte zu erhalten.

**Beispiel 1: Animationseffekte einer Form auf einer normalen Folie abrufen**

Zuvor haben Sie gelernt, wie Sie Animationseffekte zu Formen in PowerPoint‑Präsentationen hinzufügen. Der folgende Beispielcode zeigt, wie Sie die Effekte der ersten Form auf der ersten normalen Folie in der Präsentation `AnimExample_out.pptx` abrufen.
```php
  $Array = new java_class("java.lang.reflect.Array");
  $presentation = new Presentation("AnimExample_out.pptx");

  try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    # Ermittelt die Hauptanimationssequenz der Folie.
    $sequence = $firstSlide->getTimeline()->getMainSequence();

    # Ermittelt die erste Form auf der ersten Folie.
    $shape = $firstSlide->getShapes()->get_Item(0);

    # Ermittelt die auf die Form angewendeten Animationseffekte.
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

Hat eine Form auf einer normalen Folie Platzhalter, die sich auf der Layout‑ oder Master‑Folie befinden, und wurden diesen Platzhaltern Animationseffekte zugewiesen, dann werden beim Vorführen alle Effekte der Form abgespielt, einschließlich der von den Platzhaltern geerbten.

Angenommen, wir haben eine PowerPoint‑Datei `sample.pptx` mit einer Folie, die nur eine Fußzeilen‑Form mit dem Text „Made with Aspose.Slides“ enthält, und der **Random Bars**‑Effekt ist auf die Form angewendet.

![Folienform‑Animationseffekt](slide-shape-animation.png)

Angenommen, auf dem **Layout**‑Folie ist der **Split**‑Effekt auf den Fußzeilen‑Platzhalter angewendet.

![Layout‑Form‑Animationseffekt](layout-shape-animation.png)

Und schließlich ist auf der **Master**‑Folie der **Fly In**‑Effekt auf den Fußzeilen‑Platzhalter angewendet.

![Master‑Form‑Animationseffekt](master-shape-animation.png)

Der folgende Beispielcode zeigt, wie Sie die Methode `getBasePlaceholder` der [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/)-Klasse verwenden, um die Platzhalter der Form zu erreichen und die darauf angewendeten Animationseffekte, einschließlich der von Layout‑ und Master‑Platzhaltern geerbten, abzurufen.
```php
$presentation = new Presentation("sample.pptx");

$slide = $presentation->getSlides()->get_Item(0);

// Ermittelt die Animationseffekte der Form auf der normalen Folie.
$shape = $slide->getShapes()->get_Item(0);
$shapeEffects = $slide->getTimeline()->getMainSequence()->getEffectsByShape($shape);

// Ermittelt die Animationseffekte des Platzhalters auf der Layout‑Folie.
$layoutShape = $shape->getBasePlaceholder();
$layoutShapeEffects = $slide->getLayoutSlide()->getTimeline()->getMainSequence()->getEffectsByShape($layoutShape);

// Ermittelt die Animationseffekte des Platzhalters auf der Master‑Folie.
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
Type: 47, subtype: 2              // Flug, unten
Type: 134, subtype: 45            // Aufteilen, vertikalEingang
Type: 126, subtype: 22            // Zufällige Balken, horizontal
```


## **Timing‑Eigenschaften eines Animationseffekts ändern**

Aspose.Slides for PHP via Java ermöglicht es Ihnen, die Timing‑Eigenschaften eines Animationseffekts zu ändern.

Dies ist das Fenster **Animation Timing** in Microsoft PowerPoint:

![example1_image](shape-animation.png)

Die Entsprechungen zwischen PowerPoint‑Timing und den Eigenschaften von [Effect.Timing](https://reference.aspose.com/slides/php-java/aspose.slides/IEffect#getTiming--) sind:

- Die Dropdown‑Liste **Start** im PowerPoint‑Timing entspricht der Eigenschaft [Effect.Timing.TriggerType](https://reference.aspose.com/slides/php-java/aspose.slides/ITiming#getTriggerType--).
- **Duration** entspricht der Eigenschaft [Effect.Timing.Duration](https://reference.aspose.com/slides/php-java/aspose.slides/ITiming#getDuration--). Die Dauer einer Animation (in Sekunden) ist die Gesamtzeit, die die Animation für einen Zyklus benötigt.
- **Delay** entspricht der Eigenschaft [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/php-java/aspose.slides/ITiming#getTriggerDelayTime--).

So ändern Sie die Timing‑Eigenschaften des Effekts:

1. [Anwenden](#apply-animation-to-shape) oder erhalten Sie den Animationseffekt.
2. Setzen Sie neue Werte für die benötigten [Effect.Timing](https://reference.aspose.com/slides/php-java/aspose.slides/IEffect#getTiming--)‑Eigenschaften.
3. Speichern Sie die geänderte PPTX‑Datei.

Dieser PHP‑Code demonstriert den Vorgang:
```php
  # Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # Ermittelt die Hauptsequenz der Folie.
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # Ermittelt den ersten Effekt der Hauptsequenz.
    $effect = $sequence->get_Item(0);
    # Ändert den TriggerType des Effekts, sodass er bei Klick startet
    $effect->getTiming()->setTriggerType(EffectTriggerType::OnClick);
    # Ändert die Dauer des Effekts
    $effect->getTiming()->setDuration(3.0);
    # Ändert die TriggerDelayTime des Effekts
    $effect->getTiming()->setTriggerDelayTime(0.5);
    # Speichert die PPTX-Datei auf dem Datenträger
    $pres->save("AnimExample_changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Animationseffekt‑Ton**

Aspose.Slides stellt diese Eigenschaften bereit, um mit Tönen in Animationseffekten zu arbeiten:

- [setSound(IAudio value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setStopPreviousSound-boolean-)

### **Einen Animationseffekt‑Ton hinzufügen**

Dieser PHP‑Code zeigt, wie Sie einem Animationseffekt einen Ton hinzufügen und diesen stoppen, wenn der nächste Effekt beginnt:
```php
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # Fügt Audio zur Audiosammlung der Präsentation hinzu
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
    # Ermittelt die Hauptsequenz der Folie.
    $sequence = $firstSlide->getTimeline()->getMainSequence();
    # Ermittelt den ersten Effekt der Hauptsequenz
    $firstEffect = $sequence->get_Item(0);
    # Prüft den Effekt auf "No Sound"
    if (java_is_null(!$firstEffect->getStopPreviousSound() && $firstEffect->getSound())) {
      # Fügt dem ersten Effekt einen Ton hinzu
      $firstEffect->setSound($effectSound);
    }
    # Ermittelt die erste interaktive Sequenz der Folie.
    $interactiveSequence = $firstSlide->getTimeline()->getInteractiveSequences()->get_Item(0);
    # Setzt das Flag "Stop previous sound" für den Effekt
    $interactiveSequence->get_Item(0)->setStopPreviousSound(true);
    # Schreibt die PPTX-Datei auf die Festplatte
    $pres->save("AnimExample_Sound_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **Einen Animationseffekt‑Ton extrahieren**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)-Klasse.
2. Holen Sie sich eine Folienreferenz über deren Index.
3. Erhalten Sie die Hauptsequenz der Effekte.
4. Extrahieren Sie den in jedem Animationseffekt eingebetteten [setSound(IAudio value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)‑Ton.

Dieser PHP‑Code zeigt, wie Sie den in einem Animationseffekt eingebetteten Ton extrahieren:
```php
  # Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
  $presentation = new Presentation("EffectSound.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Ermittelt die Hauptsequenz der Folie.
    $sequence = $slide->getTimeline()->getMainSequence();
    foreach($sequence as $effect) {
      if (java_is_null($effect->getSound())) {
        continue;
      }
      # Extrahiert den Effektton in ein Byte-Array
      $audio = $effect->getSound()->getBinaryData();
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **Nach der Animation**

Aspose.Slides for PHP via Java ermöglicht es Ihnen, die **After animation**‑Eigenschaft eines Animationseffekts zu ändern.

Dies ist das Fenster **Animation Effect** und das erweiterte Menü in Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

Die Dropdown‑Liste **After animation** in PowerPoint entspricht folgenden Eigenschaften:

- Eigenschaft [setAfterAnimationType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setAfterAnimationType-int-), die den Typ der Nach‑Animation beschreibt:
  * **More Colors** entspricht dem Typ [AfterAnimationType::Color](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#Color);
  * **Don't Dim** entspricht dem Typ [AfterAnimationType::DoNotDim](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#DoNotDim) (Standard‑Nach‑Animationstyp);
  * **Hide After Animation** entspricht dem Typ [AfterAnimationType::HideAfterAnimation](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#HideAfterAnimation);
  * **Hide on Next Mouse Click** entspricht dem Typ [AfterAnimationType::HideOnNextMouseClick](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick);
- Eigenschaft [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-), die ein Nach‑Animations‑Farbformat definiert. Diese Eigenschaft wirkt zusammen mit dem Typ [AfterAnimationType::Color](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#Color). Ändern Sie den Typ, wird die Nach‑Animations‑Farbe gelöscht.

Dieser PHP‑Code zeigt, wie Sie einen Nach‑Animation‑Effekt ändern:
```php
  # Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
  $pres = new Presentation("AnimImage_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # Ermittelt den ersten Effekt der Hauptsequenz
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # Ändert den After‑Animation‑Typ zu Color
    $firstEffect->setAfterAnimationType(AfterAnimationType::Color);
    # Setzt die After‑Animation‑Farbe
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

Aspose.Slides stellt diese Eigenschaften bereit, um mit dem *Animate text*‑Block eines Animationseffekts zu arbeiten:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setAnimateTextType-int-), die den Animations‑Text‑Typ des Effekts beschreibt. Der Form‑Text kann animiert werden:
  - Alles auf einmal ([AnimateTextType::AllAtOnce](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#AllAtOnce))
  - Wortweise ([AnimateTextType::ByWord](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#ByWord))
  - Buchstabenweise ([AnimateTextType::ByLetter](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#ByLetter))
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setDelayBetweenTextParts-float-) legt eine Verzögerung zwischen den animierten Textteilen (Wörtern oder Buchstaben) fest. Ein positiver Wert gibt den Prozentsatz der Effekt­dauer an. Ein negativer Wert gibt die Verzögerung in Sekunden an.

So ändern Sie die Eigenschaften **Effect Animate text**:

1. [Anwenden](#apply-animation-to-shape) oder erhalten Sie den Animationseffekt.
2. Setzen Sie die Eigenschaft [setBuildType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/itextanimation/#setBuildType-int-) auf den Wert [BuildType::AsOneObject](https://reference.aspose.com/slides/php-java/aspose.slides/buildtype/#AsOneObject), um den Animationsmodus *By Paragraphs* zu deaktivieren.
3. Setzen Sie neue Werte für die Eigenschaften [setAnimateTextType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setAnimateTextType-int-) und [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setDelayBetweenTextParts-float-).
4. Speichern Sie die geänderte PPTX‑Datei.

Dieser PHP‑Code demonstriert den Vorgang:
```php
  # Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
  $pres = new Presentation("AnimTextBox_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # Ermittelt den ersten Effekt der Hauptsequenz
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # Ändert den Textanimations-Typ des Effekts zu "As One Object"
    $firstEffect->getTextAnimation()->setBuildType(BuildType::AsOneObject);
    # Ändert den Animieren-Text-Typ des Effekts zu "By word"
    $firstEffect->setAnimateTextType(AnimateTextType::ByWord);
    # Setzt die Verzögerung zwischen den Wörtern auf 20% der Effektdauer
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

[Export to HTML5](/slides/de/php-java/export-to-html5/) und aktivieren Sie die [Optionen](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/) für [shape](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/setanimateshapes/)‑ und [transition](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/setanimatetransitions/)‑Animationen. Reines HTML spielt Folienanimationen nicht ab, HTML5 jedoch schon.

**Wie wirkt sich das Ändern der Z‑Reihenfolge (Layer‑Reihenfolge) von Formen auf Animationen aus?**

Animations‑ und Zeichenreihenfolge sind unabhängig: Ein Effekt steuert das Timing und den Typ des Erscheinens/Verschwindens, während die [z-order](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getzorderposition/) bestimmt, was was überdeckt. Das sichtbare Ergebnis ergibt sich aus ihrer Kombination. (Dies ist das allgemeine Verhalten von PowerPoint; das Aspose.Slides‑Modell für Effekte und Formen folgt derselben Logik.)

**Gibt es Einschränkungen beim Konvertieren von Animationen in Video für bestimmte Effekte?**

Im Allgemeinen werden [Animationen unterstützt](/slides/de/php-java/convert-powerpoint-to-video/), aber seltene Fälle oder spezielle Effekte können anders gerendert werden. Es wird empfohlen, die von Ihnen genutzten Effekte und die Bibliotheksversion zu testen.