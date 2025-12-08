---
title: Formanimation
type: docs
weight: 60
url: /de/nodejs-java/shape-animation/
keywords:
- Form
- Animation
- Effekt
- Effekte hinzufügen
- Effekte abrufen
- Effekte extrahieren
- Animation anwenden
- PowerPoint
- Präsentation
- Node.js
- Java
- Aspose.Slides für Node.js via Java
description: "PowerPoint-Animation in JavaScript anwenden"
---

Animationen sind visuelle Effekte, die auf Texte, Bilder, Formen oder [Diagramme](/slides/de/nodejs-java/animated-charts/) angewendet werden können. Sie verleihen Präsentationen oder deren Bestandteilen Leben.

## **Warum Animationen in Präsentationen verwenden?**

* den Informationsfluss steuern
* wichtige Punkte hervorheben
* Interesse oder Beteiligung des Publikums erhöhen
* Inhalte leichter lesbar, verständlich oder verarbeitbar machen
* die Aufmerksamkeit Ihrer Leser oder Zuschauer auf wichtige Teile einer Präsentation lenken

PowerPoint bietet viele Optionen und Werkzeuge für Animationen und Animationseffekte in den Kategorien **Eingang**, **Ausgang**, **Betonung** und **Bewegungsbahnen**.

## **Animationen in Aspose.Slides**

* Aspose.Slides stellt die Klassen und Typen bereit, die Sie benötigen, um mit Animationen im Namespace `Aspose.Slides.Animation` zu arbeiten,
* Aspose.Slides bietet über **150 Animationseffekte** im Aufzählungstyp [EffectType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effecttype). Diese Effekte entsprechen im Wesentlichen denselben (oder gleichwertigen) Effekten, die in PowerPoint verwendet werden.

## **Animation auf TextBox anwenden**

Aspose.Slides für Node.js via Java ermöglicht es Ihnen, eine Animation auf den Text in einer Form anzuwenden.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Holen Sie sich eine Folienreferenz über ihren Index.
3. Fügen Sie eine `rectangle` [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape) hinzu.
4. Fügen Sie Text mit [AutoShape.addTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-) hinzu.
5. Holen Sie sich die Hauptsequenz der Effekte.
6. Fügen Sie einen Animationseffekt zu [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape) hinzu.
7. Rufen Sie die Methode `TextAnimation.setBuildType` mit dem Wert aus der Aufzählung `BuildType` auf.
8. Schreiben Sie die Präsentation als PPTX-Datei auf die Festplatte.

Dieser Javascript‑Code zeigt, wie Sie den `Fade`‑Effekt auf AutoShape anwenden und die Textanimation auf den Wert *By 1st Level Paragraphs* setzen:
```javascript
// Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei repräsentiert.
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    // Fügt ein neues AutoShape mit Text hinzu
    var autoShape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 100);
    var textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");
    // Ermittelt die Hauptsequenz der Folie.
    var sequence = sld.getTimeline().getMainSequence();
    // Fügt dem Shape den Fade-Animationseffekt hinzu
    var effect = sequence.addEffect(autoShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    // Animiert den Shape-Text nach Absätzen der ersten Ebene
    effect.getTextAnimation().setBuildType(aspose.slides.BuildType.ByLevelParagraphs1);
    // Speichert die PPTX-Datei auf dem Datenträger
    pres.save(path + "AnimText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{%  alert color="primary"  %}} 
Zusätzlich zum Anwenden von Animationen auf Text können Sie auch Animationen auf ein einzelnes [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph) anwenden. Siehe [**Animierter Text**](/slides/de/nodejs-java/animated-text/).
{{% /alert %}} 

## **Animation auf PictureFrame anwenden**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)‑Klasse.
2. Holen Sie sich die Referenz einer Folie über ihren Index.
3. Fügen Sie ein [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe) zur Folie hinzu oder holen Sie ein vorhandenes.
4. Holen Sie die Hauptsequenz der Effekte.
5. Fügen Sie einen Animationseffekt zu [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe) hinzu.
6. Schreiben Sie die Präsentation als PPTX‑Datei auf die Festplatte.

Dieser Javascript‑Code zeigt, wie Sie den `Fly`‑Effekt auf einen Bildrahmen anwenden:
```javascript
// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei repräsentiert.
var pres = new aspose.slides.Presentation();
try {
    // Lädt ein Bild, das zur Bildsammlung der Präsentation hinzugefügt werden soll
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Fügt der Folie einen Bildrahmen hinzu
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100, picture);
    // Ermittelt die Hauptsequenz der Folie.
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    // Fügt dem Bildrahmen den Fly von Links-Animationseffekt hinzu
    var effect = sequence.addEffect(picFrame, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Left, aspose.slides.EffectTriggerType.OnClick);
    // Speichert die PPTX-Datei auf dem Datenträger
    pres.save(path + "AnimImage_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Animation auf Form anwenden**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)‑Klasse.
2. Holen Sie die Referenz einer Folie über ihren Index.
3. Fügen Sie eine `rectangle` [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape) hinzu.
4. Fügen Sie eine `Bevel`‑[AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape) hinzu (wenn dieses Objekt angeklickt wird, wird die Animation abgespielt).
5. Erstellen Sie eine Sequenz von Effekten für die Bevel‑Form.
6. Erstellen Sie einen benutzerdefinierten `UserPath`.
7. Fügen Sie Befehle zum Bewegen zum `UserPath` hinzu.
8. Schreiben Sie die Präsentation als PPTX‑Datei auf die Festplatte.

Dieser Javascript‑Code zeigt, wie Sie den `PathFootball`‑Effekt (Pfad‑Fußball) auf eine Form anwenden:
```javascript
// Instanziert eine Presentation-Klasse, die eine PPTX-Datei darstellt.
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    // Erstellt den PathFootball-Effekt für eine vorhandene Form von Grund auf.
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");
    // Fügt den PathFootball-Animationseffekt hinzu
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, aspose.slides.EffectType.PathFootball, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // Erstellt eine Art "Button".
    var shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Bevel, 10, 10, 20, 20);
    // Erstellt eine Sequenz von Effekten für diesen Button.
    var seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);
    // Erstellt einen benutzerdefinierten Pfad. Unser Objekt wird erst bewegt, nachdem der Button angeklickt wurde.
    var fxUserPath = seqInter.addEffect(ashp, aspose.slides.EffectType.PathUser, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    // Fügt Befehle zum Bewegen hinzu, da der erstellte Pfad leer ist.
    var motionBvh = fxUserPath.getBehaviors().get_Item(0);
    var pts = java.newArray("com.aspose.slides.Point2DFloat", [java.newInstanceSync("com.aspose.slides.Point2DFloat", 0.076, 0.59)]);
    motionBvh.getPath().add(aspose.slides.MotionCommandPathType.LineTo, pts, aspose.slides.MotionPathPointsType.Auto, true);
    pts[0] = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(-0.076), java.newFloat(-0.59));
    motionBvh.getPath().add(aspose.slides.MotionCommandPathType.LineTo, pts, aspose.slides.MotionPathPointsType.Auto, false);
    motionBvh.getPath().add(aspose.slides.MotionCommandPathType.End, null, aspose.slides.MotionPathPointsType.Auto, false);
    // Schreibt die PPTX-Datei auf die Festplatte
    pres.save("AnimExample_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Animationseffekte, die einer Form zugewiesen sind, abrufen**

Die folgenden Beispiele zeigen, wie Sie die Methode `getEffectsByShape` der Klasse [Sequence](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sequence/) verwenden, um alle Animationseffekte abzurufen, die einer Form zugewiesen sind.

**Beispiel 1: Animationseffekte einer Form auf einer normalen Folie abrufen**

Zuvor haben Sie gelernt, wie man Animationseffekte zu Formen in PowerPoint‑Präsentationen hinzufügt. Der folgende Beispielcode zeigt, wie man die auf die erste Form der ersten normalen Folie in der Präsentation `AnimExample_out.pptx` angewendeten Effekte abruft.
```javascript
var presentation = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    var firstSlide = presentation.getSlides().get_Item(0);

    // Ermittelt die Hauptanimationssequenz der Folie.
    var sequence = firstSlide.getTimeline().getMainSequence();

    // Ermittelt die erste Form auf der ersten Folie.
    var shape = firstSlide.getShapes().get_Item(0);

    // Holt die auf die Form angewendeten Animationseffekte.
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


**Beispiel 2: Alle Animationseffekte abrufen, einschließlich der von Platzhaltern geerbten**

Hat eine Form auf einer normalen Folie Platzhalter, die sich auf der Layout‑Folie und/oder der Master‑Folie befinden, und wurden diesen Platzhaltern Animationseffekte hinzugefügt, dann werden alle Effekte der Form während der Vorführung abgespielt, einschließlich der von den Platzhaltern geerbten.

Angenommen, wir haben eine PowerPoint‑Datei `sample.pptx` mit einer Folie, die nur eine Fußzeilen‑Form mit dem Text "Made with Aspose.Slides" enthält, und auf die Form wurde der **Random Bars**‑Effekt angewendet.

![Folien‑Form‑Animationseffekt](slide-shape-animation.png)

Nehmen wir außerdem an, dass der **Split**‑Effekt auf den Fußzeilen‑Platzhalter der **Layout**‑Folie angewendet wurde.

![Layout‑Form‑Animationseffekt](layout-shape-animation.png)

Und schließlich wurde der **Fly In**‑Effekt auf den Fußzeilen‑Platzhalter der **Master**‑Folie angewendet.

![Master‑Form‑Animationseffekt](master-shape-animation.png)

Der folgende Beispielcode zeigt, wie man die Methode `getBasePlaceholder` der Klasse [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) verwendet, um auf die Form‑Platzhalter zuzugreifen und die auf die Fußzeilen‑Form angewendeten Animationseffekte abzurufen, einschließlich der von Platzhaltern auf Layout‑ und Master‑Folien geerbten.
```js
var presentation = new aspose.slides.Presentation("sample.pptx");

var slide = presentation.getSlides().get_Item(0);

// Ermittelt die Animations-Effekte der Form auf der normalen Folie.
var shape = slide.getShapes().get_Item(0);
var shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Ermittelt die Animations-Effekte des Platzhalters auf der Layout-Folie.
var layoutShape = shape.getBasePlaceholder();
var layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Ermittelt die Animations-Effekte des Platzhalters auf der Master-Folie.
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


```text
Main sequence of shape effects:
Type: 47, subtype: 2              // Flug, Unten
Type: 134, subtype: 45            // Aufteilen, VertikalEin
Type: 126, subtype: 22            // Zufallsbalken, Horizontal
```


## **Timing‑Eigenschaften von Animationseffekten ändern**

Aspose.Slides für Node.js via Java ermöglicht es, die Timing‑Eigenschaften eines Animationseffekts zu ändern.

Dies ist das Animations‑Timing‑Fenster in Microsoft PowerPoint:
![Animations‑Timing‑Fenster](shape-animation.png)

Dies sind die Zuordnungen zwischen PowerPoint‑Timing und den Eigenschaften von [Effect.Timing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Effect#getTiming--):
- Die Dropdown‑Liste **Start** im PowerPoint‑Timing entspricht der Eigenschaft [Effect.Timing.TriggerType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Timing#getTriggerType--).
- **Duration** im PowerPoint‑Timing entspricht der Eigenschaft [Effect.Timing.Duration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Timing#getDuration--). Die Dauer einer Animation (in Sekunden) ist die Gesamtzeit, die die Animation für einen Durchlauf benötigt.
- **Delay** im PowerPoint‑Timing entspricht der Eigenschaft [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Timing#getTriggerDelayTime--).

So ändern Sie die Timing‑Eigenschaften des Effekts:
1. [Apply](#apply-animation-to-shape) oder holen Sie den Animationseffekt.
2. Setzen Sie neue Werte für die benötigten Eigenschaften von [Effect.Timing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Effect#getTiming--).
3. Speichern Sie die modifizierte PPTX‑Datei.

Dieser Javascript‑Code demonstriert die Vorgehensweise:
```javascript
// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei repräsentiert.
var pres = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    // Ermittelt die Hauptsequenz der Folie.
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    // Ermittelt den ersten Effekt der Hauptsequenz.
    var effect = sequence.get_Item(0);
    // Ändert den TriggerType des Effekts, um bei Klick zu starten
    effect.getTiming().setTriggerType(aspose.slides.EffectTriggerType.OnClick);
    // Ändert die Dauer des Effekts
    effect.getTiming().setDuration(3.0);
    // Ändert die Triggerverzögerungszeit des Effekts
    effect.getTiming().setTriggerDelayTime(0.5);
    // Speichert die PPTX-Datei auf dem Datenträger
    pres.save("AnimExample_changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Ton des Animationseffekts**

Aspose.Slides stellt diese Eigenschaften bereit, um mit Tönen in Animationseffekten zu arbeiten:
- [setSound(IAudio value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setSound-aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setStopPreviousSound-boolean-)

### **Ton eines Animationseffekts hinzufügen**

Dieser Javascript‑Code zeigt, wie man einen Ton zu einem Animationseffekt hinzufügt und ihn stoppt, wenn der nächste Effekt startet:
```javascript
var pres = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    // Fügt Audio zur Audiosammlung der Präsentation hinzu
    var effectSound = pres.getAudios().addAudio(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "sampleaudio.wav")));
    var firstSlide = pres.getSlides().get_Item(0);
    // Ermittelt die Hauptsequenz der Folie.
    var sequence = firstSlide.getTimeline().getMainSequence();
    // Ermittelt den ersten Effekt der Hauptsequenz
    var firstEffect = sequence.get_Item(0);
    // Prüft, ob der Effekt keinen Ton hat
    if ((!firstEffect.getStopPreviousSound()) && (firstEffect.getSound() == null)) {
        // Fügt dem ersten Effekt Ton hinzu
        firstEffect.setSound(effectSound);
    }
    // Ermittelt die erste interaktive Sequenz der Folie.
    var interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);
    // Setzt das Flag "Vorherigen Ton stoppen" für den Effekt
    interactiveSequence.get_Item(0).setStopPreviousSound(true);
    // Speichert die PPTX-Datei auf dem Datenträger
    pres.save("AnimExample_Sound_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Ton eines Animationseffekts extrahieren**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)‑Klasse.
2. Holen Sie sich die Referenz einer Folie über ihren Index.
3. Holen Sie die Hauptsequenz der Effekte.
4. Extrahieren Sie den in jedem Animationseffekt eingebetteten [setSound(IAudio value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setSound-aspose.slides.IAudio-) Aufruf.

Dieser Javascript‑Code zeigt, wie man den in einem Animationseffekt eingebetteten Ton extrahiert:
```javascript
// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
var presentation = new aspose.slides.Presentation("EffectSound.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // Ermittelt die Hauptsequenz der Folie.
    var sequence = slide.getTimeline().getMainSequence();
    for (var i = 0; i < sequence.getCount(); i++) {
        var effect = sequence.get_Item(i);
        if (effect.getSound() == null) {
            continue;
        }
        // Extrahiert den Effektton in ein Byte-Array
        var audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **Nach Animation**

Aspose.Slides für Node.js via Java ermöglicht es, die Eigenschaft After animation eines Animationseffekts zu ändern.

Dies ist das Fenster für Animationseffekte und das erweiterte Menü in Microsoft PowerPoint:
![Animations‑Effekt‑Fenster](shape-after-animation.png)

Die Dropdown‑Liste **After animation** im PowerPoint‑Effekt entspricht diesen Eigenschaften:
- Die Methode [setAfterAnimationType(int value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setAfterAnimationType-int-) legt den Typ der Nachanimation fest;
  * **More Colors** in PowerPoint entspricht dem Typ [AfterAnimationType.Color](https://reference.aspose.com/slides/nodejs-java/aspose.slides/afteranimationtype/#Color);
  * **Don't Dim** entspricht dem Typ [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/nodejs-java/aspose.slides/afteranimationtype/#DoNotDim) (Standard‑Nachanimationstyp);
  * **Hide After Animation** entspricht dem Typ [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/afteranimationtype/#HideAfterAnimation);
  * **Hide on Next Mouse Click** entspricht dem Typ [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick);
- Die Methode [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setAfterAnimationColor-aspose.slides.IColorFormat-) definiert ein Farbformat für die Nachanimation. Diese Methode funktioniert zusammen mit dem Typ [AfterAnimationType.Color](https://reference.aspose.com/slides/nodejs-java/aspose.slides/afteranimationtype/#Color). Wird der Typ geändert, wird die Nachanimationsfarbe zurückgesetzt.

Dieser Javascript‑Code zeigt, wie man einen Nachanimations‑Effekt ändert:
```javascript
// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
var pres = new aspose.slides.Presentation("AnimImage_out.pptx");
try {
    var firstSlide = pres.getSlides().get_Item(0);
    // Ermittelt den ersten Effekt der Hauptsequenz
    var firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);
    // Ändert den Nachanimations-Typ zu Farbe
    firstEffect.setAfterAnimationType(aspose.slides.AfterAnimationType.Color);
    // Setzt die Nachanimations-Dimmfarbe
    firstEffect.getAfterAnimationColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // Speichert die PPTX-Datei auf dem Datenträger
    pres.save("AnimImage_AfterAnimation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Text animieren**

Aspose.Slides stellt diese Eigenschaften bereit, um mit dem *Animate text*‑Block eines Animationseffekts zu arbeiten:
- Die Methode [setAnimateTextType(int value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setAnimateTextType-int-) legt den Animations‑Text‑Typ des Effekts fest. Der Text einer Form kann animiert werden:
  - Alles auf einmal ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/nodejs-java/aspose.slides/animatetexttype/#AllAtOnce) Typ)
  - Wortweise ([AnimateTextType.ByWord](https://reference.aspose.com/slides/nodejs-java/aspose.slides/animatetexttype/#ByWord) Typ)
  - Buchstabenweise ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/animatetexttype/#ByLetter) Typ)
- Die Methode [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setDelayBetweenTextParts-float-) legt eine Verzögerung zwischen den animierten Textteilen (Wörter oder Buchstaben) fest. Ein positiver Wert gibt den Prozentsatz der Effekt‑Dauer an. Ein negativer Wert gibt die Verzögerung in Sekunden an.

So können Sie die Eigenschaften des Effect Animate text ändern:
1. [Apply](#apply-animation-to-shape) oder holen Sie den Animationseffekt.
2. Rufen Sie die Methode [setBuildType(int value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textanimation/#setBuildType-int-) mit dem Wert [BuildType.AsOneObject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/buildtype/#AsOneObject) auf, um den Animationsmodus *By Paragraphs* zu deaktivieren.
3. Setzen Sie neue Werte für die Eigenschaften [setAnimateTextType(int value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setAnimateTextType-int-) und [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setDelayBetweenTextParts-float-).
4. Speichern Sie die modifizierte PPTX‑Datei.

Dieser Javascript‑Code demonstriert die Vorgehensweise:
```javascript
// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
var pres = new aspose.slides.Presentation("AnimTextBox_out.pptx");
try {
    var firstSlide = pres.getSlides().get_Item(0);
    // Ermittelt den ersten Effekt der Hauptsequenz
    var firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);
    // Ändert den Textanimations-Typ des Effekts zu "As One Object"
    firstEffect.getTextAnimation().setBuildType(aspose.slides.BuildType.AsOneObject);
    // Ändert den Animate-Text-Typ des Effekts zu "By word"
    firstEffect.setAnimateTextType(aspose.slides.AnimateTextType.ByWord);
    // Setzt die Verzögerung zwischen den Wörtern auf 20% der Effektdauer
    firstEffect.setDelayBetweenTextParts(20.0);
    // Speichert die PPTX-Datei auf dem Datenträger
    pres.save("AnimTextBox_AnimateText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Wie kann ich sicherstellen, dass Animationen beim Veröffentlichen der Präsentation im Web erhalten bleiben?**

[Export to HTML5](/slides/de/nodejs-java/export-to-html5/) und aktivieren Sie die [options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/), die für [shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/setanimateshapes/)‑ und [transition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/setanimatetransitions/)‑Animationen verantwortlich sind. Reines HTML spielt keine Folienanimationen ab, HTML5 hingegen schon.

**Wie wirkt sich das Ändern der Z‑Reihenfolge (Schichtreihenfolge) von Formen auf die Animation aus?**

Animation und Zeichenreihenfolge sind unabhängig: Ein Effekt steuert das Timing und den Typ des Erscheinens/Verschwindens, während die [z-order](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getzorderposition/) bestimmt, was was überdeckt. Das sichtbare Ergebnis ergibt sich aus ihrer Kombination. (Dies ist das allgemeine PowerPoint‑Verhalten; das Aspose.Slides‑Effekte‑und‑Formen‑Modell folgt derselben Logik.)

**Gibt es Einschränkungen beim Konvertieren von Animationen in Video für bestimmte Effekte?**

Im Allgemeinen werden [animationen unterstützt](/slides/de/nodejs-java/convert-powerpoint-to-video/), doch seltene Fälle oder bestimmte Effekte können anders gerendert werden. Es wird empfohlen, die von Ihnen verwendeten Effekte und die Bibliotheksversion zu testen.