---
title: Formenanimation
type: docs
weight: 60
url: /de/androidjava/shape-animation/
keywords: "PowerPoint-Animation, Animationseffekt, Animation anwenden, PowerPoint-Präsentation, Java, Aspose.Slides für Android über Java"
description: "PowerPoint-Animation in Java anwenden"
---

Animationen sind visuelle Effekte, die auf Texte, Bilder, Formen oder [Diagramme](https://docs.aspose.com/slides/androidjava/animated-charts/) angewendet werden können. Sie erwecken Präsentationen oder deren Bestandteile zum Leben.

### **Warum Animationen in Präsentationen verwenden?**

Mit Animationen können Sie

* den Informationsfluss steuern
* wichtige Punkte hervorheben
* das Interesse oder die Beteiligung Ihres Publikums steigern
* Inhalte leichter lesbar oder verständlich machen
* die Aufmerksamkeit Ihrer Leser oder Zuschauer auf wichtige Teile einer Präsentation lenken

PowerPoint bietet viele Optionen und Werkzeuge für Animationen und Animationseffekte in den Kategorien **Eingang**, **Austritt**, **Hervorhebung** und **Bewegungsbahnen**. 

### **Animationen in Aspose.Slides**

* Aspose.Slides bietet die Klassen und Typen, die Sie benötigen, um mit Animationen im `Aspose.Slides.Animation` Namensraum zu arbeiten.
* Aspose.Slides bietet über **150 Animationseffekte** im [EffectType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effecttype) Aufzählung. Diese Effekte sind im Wesentlichen dieselben (oder äquivalenten), die in PowerPoint verwendet werden.

## **Animation auf TextBox anwenden**

Aspose.Slides für Android über Java ermöglicht es Ihnen, Animationen auf den Text in einer Form anzuwenden.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
2. Erhalten Sie eine Folienreferenz über ihren Index.
3. Fügen Sie eine `rectangle` [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape) hinzu.
4. Fügen Sie Text zu [IAutoShape.TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-) hinzu.
5. Holen Sie die Hauptsequenz von Effekten.
6. Fügen Sie einen Animationseffekt zu [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape) hinzu.
7. Setzen Sie die `TextAnimation.BuildType` Eigenschaft auf den Wert aus der `BuildType` Aufzählung.
8. Schreiben Sie die Präsentation auf die Festplatte als PPTX-Datei.

Dieser Java-Code zeigt Ihnen, wie Sie den `Fade` Effekt auf AutoShape anwenden und die Texteanimation auf den Wert *Nach 1. Ebene Absätzen* setzen:

```java
// Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Fügt eine neue AutoShape mit Text hinzu
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Erster Absatz \nZweiter Absatz \nDritter Absatz");

    // Holt die Hauptsequenz der Folie.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // Fügt einen Fade-Animationseffekt zur Form hinzu
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Animiert den Text der Form nach 1. Ebene Absätzen
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // Speichert die PPTX-Datei auf der Festplatte
    pres.save(path + "AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="primary"  %}} 

Neben der Anwendung von Animationen auf den Text können Sie auch Animationen auf einen einzelnen [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph) anwenden. Siehe [**Animierter Text**](/slides/de/androidjava/animated-text/).

{{% /alert %}} 

## **Animation auf PictureFrame anwenden**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
2. Holen Sie eine Folienreferenz über ihren Index.
3. Fügen Sie einen [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe) zur Folie hinzu oder holen Sie ihn.
4. Holen Sie die Hauptsequenz von Effekten.
5. Fügen Sie einen Animationseffekt zu [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe) hinzu.
6. Schreiben Sie die Präsentation auf die Festplatte als PPTX-Datei.

Dieser Java-Code zeigt Ihnen, wie Sie den `Fly` Effekt auf einen PictureFrame anwenden:

```java
// Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
Presentation pres = new Presentation();
try {
    // Lädt das Bild, das der Präsentations-Bildersammlung hinzugefügt werden soll
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Fügt den PictureFrame zur Folie hinzu
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // Holt die Hauptsequenz der Folie.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Fügt einen Fly von Links Animationseffekt zum PictureFrame hinzu
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Speichert die PPTX-Datei auf der Festplatte
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animation auf Shape anwenden**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
2. Holen Sie eine Folienreferenz über ihren Index.
3. Fügen Sie eine `rectangle` [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape) hinzu.
4. Fügen Sie eine `Bevel` [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape) hinzu (wenn dieses Objekt angeklickt wird, wird die Animation abgespielt).
5. Erstellen Sie eine Sequenz von Effekten auf der Bevel-Form.
6. Erstellen Sie einen benutzerdefinierten `UserPath`.
7. Fügen Sie Befehle zum Bewegen zum `UserPath` hinzu.
8. Schreiben Sie die Präsentation auf die Festplatte als PPTX-Datei.

Dieser Java-Code zeigt Ihnen, wie Sie den `PathFootball` (Pfad Fußball) Effekt auf eine Form anwenden:

```java
// Instanziiert eine Präsentationsklasse, die eine PPTX-Datei darstellt.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Erstellt den PathFootball Effekt für eine bestehende Form von Grund auf.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animations-TextBox");

    // Fügt den PathFootBall Animationseffekt hinzu
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Erstellt eine Art "Taste".
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Erstellt eine Sequenz von Effekten für diese Taste.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

    // Erstellt einen benutzerdefinierten Benutzerpfad. Unser Objekt wird nur nach dem Klicken auf die Taste bewegt.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // Fügt Befehle für die Bewegung hinzu, da der erstellte Pfad leer ist.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

    // Schreibt die PPTX-Datei auf die Festplatte
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Die angewendeten Animationseffekte auf eine Form abrufen**

Sie können sich entscheiden, alle Animationseffekte, die auf eine bestimmte Form angewendet wurden, herauszufinden. 

Dieser Java-Code zeigt Ihnen, wie Sie alle Effekte abrufen, die auf eine bestimmte Form angewendet wurden:

```java
// Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Holt die Hauptsequenz der Folie.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Holt die erste Form auf der Folie.
    IShape shape = firstSlide.getShapes().get_Item(0);

    // Holt alle Animationseffekte, die auf die Form angewendet wurden.
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("Die Form " + shape.getName() + " hat " + shapeEffects.length + " Animationseffekte.");
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ändern der Zeitproperties der Animationseffekte**

Aspose.Slides für Android über Java ermöglicht es Ihnen, die Timing-Eigenschaften eines Animationseffekts zu ändern.

Dies ist das Animationszeitschema in Microsoft PowerPoint:

![example1_image](shape-animation.png)

Dies sind die Entsprechungen zwischen PowerPoint Timing und [Effect.Timing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IEffect#getTiming--) Eigenschaften:

- Die PowerPoint Timing **Start** Dropdown-Liste entspricht der [Effect.Timing.TriggerType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getTriggerType--) Eigenschaft.
- Die PowerPoint Timing **Dauer** entspricht der [Effect.Timing.Duration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getDuration--) Eigenschaft. Die Dauer einer Animation (in Sekunden) ist die gesamte Zeit, die die Animation benötigt, um einen Zyklus abzuschließen.
- Die PowerPoint Timing **Verzögerung** entspricht der [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getTriggerDelayTime--) Eigenschaft.

So ändern Sie die Effect Timing Eigenschaften:

1. [Wenden Sie an](#apply-animation-to-shape) oder holen Sie den Animationseffekt.
2. Setzen Sie neue Werte für die [Effect.Timing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IEffect#getTiming--) Eigenschaften, die Sie benötigen.
3. Speichern Sie die modifizierte PPTX-Datei.

Dieser Java-Code demonstriert die Operation:

```java
// Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Holt die Hauptsequenz der Folie.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Holt den ersten Effekt der Hauptsequenz.
    IEffect effect = sequence.get_Item(0);

    // Ändert den TriggerType des Effekts, um beim Klicken zu starten
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // Ändert die Dauer des Effekts
    effect.getTiming().setDuration(3f);

    // Ändert die TriggerDelayTime des Effekts
    effect.getTiming().setTriggerDelayTime(0.5f);

    // Speichert die PPTX-Datei auf der Festplatte
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Der Animationseffekt-Ton**

Aspose.Slides bietet diese Eigenschaften, die es Ihnen ermöglichen, mit Tönen in Animationseffekten zu arbeiten: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setStopPreviousSound-boolean-)

### **Animationseffekt-Ton hinzufügen**

Dieser Java-Code zeigt Ihnen, wie Sie einen Animationseffekt-Ton hinzufügen und ihn stoppen, wenn der nächste Effekt beginnt:

```java
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Fügt Audio zur Präsentations-Audio-Sammlung hinzu
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Holt die Hauptsequenz der Folie.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Holt den ersten Effekt der Hauptsequenz
    IEffect firstEffect = sequence.get_Item(0);

    // Überprüft den Effekt auf "Kein Ton"
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // Fügt den Ton für den ersten Effekt hinzu
        firstEffect.setSound(effectSound);
    }

    // Holt die erste interaktive Sequenz der Folie.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // Setzt die "Stoppe vorherigen Ton" Flagge des Effekts
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // Schreibt die PPTX-Datei auf die Festplatte
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Animationseffekt-Ton extrahieren**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/aspose.slides/presentation/) Klasse.
2. Holen Sie eine Folienreferenz über ihren Index. 
3. Holen Sie die Hauptsequenz von Effekten. 
4. Extrahieren Sie den [setSound(IAudio value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) eingebetteten Ton in jedem Animationseffekt.

Dieser Java-Code zeigt Ihnen, wie Sie den in einem Animationseffekt eingebetteten Ton extrahieren:

```java
// Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Holt die Hauptsequenz der Folie.
    ISequence sequence = slide.getTimeline().getMainSequence();

    for (IEffect effect : sequence)
    {
        if (effect.getSound() == null)
            continue;

        // Extrahiert den Effekt-Ton in ein Byte-Array
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Nach Animation**

Aspose.Slides für Android über Java ermöglicht es Ihnen, die Nach-Animationseigenschaft eines Animationseffekts zu ändern.

Dies ist das Animations-Effekt-Fenster und das erweiterte Menü in Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

Die PowerPoint Effekt **Nach Animation** Dropdown-Liste entspricht diesen Eigenschaften: 

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAfterAnimationType-int-) Eigenschaft, die den Nach-Animationstyp beschreibt:
  * PowerPoint **Weitere Farben** entspricht dem [AfterAnimationType.Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#Color) Typ;
  * PowerPoint **Nicht dimmen** Listenpunkt entspricht dem [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#DoNotDim) Typ (Standard Nachanimationstyp);
  * PowerPoint **Nach Animation ausblenden** Listenpunkt entspricht dem [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#HideAfterAnimation) Typ;
  * PowerPoint **Nach dem nächsten Mausklick ausblenden** Listenpunkt entspricht dem [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick) Typ;
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) Eigenschaft, die ein Nachanimationsfarbformat definiert. Diese Eigenschaft funktioniert in Verbindung mit dem [AfterAnimationType.Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#Color) Typ. Wenn Sie den Typ in einen anderen ändern, wird die Nachanimationsfarbe gelöscht.

Dieser Java-Code zeigt Ihnen, wie Sie einen Nachanimations-Effekt ändern:

```java
// Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Holt den ersten Effekt der Hauptsequenz
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Ändert den Nachanimations-Typ auf Farbe
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // Setzt die Nachanimations-Dimmfarbe
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // Schreibt die PPTX-Datei auf die Festplatte
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Text animieren**

Aspose.Slides bietet diese Eigenschaften, die es Ihnen ermöglichen, mit dem *Animationstext* Block eines Animationseffekts zu arbeiten:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) beschreibt einen Animationstexttyp des Effekts. Der Formtext kann animiert werden:
  - Alles auf einmal ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#AllAtOnce) Typ)
  - Nach Wort ([AnimateTextType.ByWord](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#ByWord) Typ)
  - Nach Buchstabe ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#ByLetter) Typ)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) setzt eine Verzögerung zwischen den animierten Textteilen (Wörtern oder Buchstaben). Ein positiver Wert gibt den Prozentsatz der Effekt-Dauer an. Ein negativer Wert gibt die Verzögerung in Sekunden an.

So ändern Sie die Effect Animate Text Eigenschaften:

1. [Wenden Sie an](#apply-animation-to-shape) oder holen Sie den Animationseffekt.
2. Setzen Sie die [setBuildType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextanimation/#setBuildType-int-) Eigenschaft auf [BuildType.AsOneObject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/buildtype/#AsOneObject) Wert, um den *Nach Absätzen* Animationsmodus auszuschalten.
3. Setzen Sie neue Werte für die [setAnimateTextType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) und [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) Eigenschaften.
4. Speichern Sie die modifizierte PPTX-Datei.

Dieser Java-Code demonstriert die Operation:

```java
// Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
Presentation pres = new Presentation("AnimTextBox_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Holt den ersten Effekt der Hauptsequenz
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Ändert den Effekt Animationstexttyp auf "Als ein Objekt"
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // Ändert den Effekt Animationstexttyp auf "Nach Wort"
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // Setzt die Verzögerung zwischen Wörtern auf 20% der Effekt-Dauer
    firstEffect.setDelayBetweenTextParts(20f);

    // Schreibt die PPTX-Datei auf die Festplatte
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```