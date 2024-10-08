---
title: Formanimation
type: docs
weight: 60
url: /de/java/shape-animation/
keywords: "PowerPoint-Animation, Animationseffekt, Animation anwenden, PowerPoint-Präsentation, Java, Aspose.Slides für Java"
description: "PowerPoint-Animation in Java anwenden"
---

Animationen sind visuelle Effekte, die auf Texte, Bilder, Formen oder [Diagramme](https://docs.aspose.com/slides/java/animated-charts/) angewendet werden können. Sie verleihen Präsentationen oder ihren Bestandteilen Leben.

### **Warum Animationen in Präsentationen verwenden?**

Mit Animationen können Sie

* den Fluss von Informationen steuern
* wichtige Punkte hervorheben
* das Interesse oder die Teilnahme Ihres Publikums erhöhen
* Inhalte leichter lesbar oder verdaulich machen
* die Aufmerksamkeit Ihrer Leser oder Zuschauer auf wichtige Teile einer Präsentation lenken

PowerPoint bietet viele Optionen und Werkzeuge für Animationen und Animationseffekte in den Kategorien **Eingang**, **Ausgang**, **Hervorhebung** und **Bewegungspfade**.

### **Animationen in Aspose.Slides**

* Aspose.Slides bietet die Klassen und Typen, die Sie benötigen, um mit Animationen im `Aspose.Slides.Animation`-Namespace zu arbeiten,
* Aspose.Slides bietet über **150 Animationseffekte** unter der [EffectType](https://reference.aspose.com/slides/java/com.aspose.slides/effecttype)-Aufzählung. Diese Effekte sind im Wesentlichen dieselben (oder äquivalenten) Effekte, die in PowerPoint verwendet werden.

## **Animation auf Textfeld anwenden**

Aspose.Slides für Java ermöglicht es Ihnen, Animation auf den Text in einer Form anzuwenden.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)-Klasse.
2. Erhalten Sie einen Folienverweis über dessen Index.
3. Fügen Sie eine `rectangle` [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape) hinzu.
4. Fügen Sie Text zu [IAutoShape.TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-) hinzu.
5. Erhalten Sie eine Hauptsequenz von Effekten.
6. Fügen Sie einen Animationseffekt zu [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape) hinzu.
7. Setzen Sie die `TextAnimation.BuildType`-Eigenschaft auf den Wert aus der `BuildType`-Aufzählung.
8. Speichern Sie die Präsentation als PPTX-Datei auf der Festplatte.

Dieser Java-Code zeigt Ihnen, wie Sie den `Fade`-Effekt auf AutoShape anwenden und die Textanimation auf den Wert *Nach 1. Ebene Absätzen* setzen:

```java
// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Fügt eine neue AutoShape mit Text hinzu
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Erster Absatz \nZweiter Absatz \nDritter Absatz");

    // Erhält die Hauptsequenz der Folie.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // Fügt den Fade-Animationseffekt zur Form hinzu
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Animiert den Formtext nach 1. Ebene Absätzen
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // Speichert die PPTX-Datei auf der Festplatte
    pres.save(path + "AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="primary"  %}} 

Neben der Anwendung von Animationen auf Text können Sie auch Animationen auf einen einzelnen [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph) anwenden. Siehe [**Animierter Text**](/slides/de/java/animated-text/).

{{% /alert %}} 

## **Animation auf PictureFrame anwenden**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)-Klasse.
2. Erhalten Sie einen Folienverweis über dessen Index.
3. Fügen Sie einen [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe) zur Folie hinzu oder erhalten Sie ihn.
4. Erhalten Sie die Hauptsequenz von Effekten.
5. Fügen Sie einen Animationseffekt zu [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe) hinzu.
6. Speichern Sie die Präsentation als PPTX-Datei auf der Festplatte.

Dieser Java-Code zeigt Ihnen, wie Sie den `Fly`-Effekt auf einen PictureFrame anwenden:

```java
// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
Presentation pres = new Presentation();
try {
    // Bild laden, das zur Präsentation hinzugefügt werden soll
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Fügen Sie den PictureFrame zur Folie hinzu
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // Erhält die Hauptsequenz der Folie.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Fügt Fly from Left-Animationseffekt zum PictureFrame hinzu
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Speichert die PPTX-Datei auf der Festplatte
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animation auf Form anwenden**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)-Klasse.
2. Erhalten Sie einen Folienverweis über dessen Index.
3. Fügen Sie eine `rectangle` [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape) hinzu.
4. Fügen Sie eine `Bevel` [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape) hinzu (wenn dieses Objekt angeklickt wird, wird die Animation abgespielt).
5. Erstellen Sie eine Sequenz von Effekten für die Bevel-Form.
6. Erstellen Sie einen benutzerdefinierten `UserPath`.
7. Fügen Sie Befehle zum Bewegen zum `UserPath` hinzu.
8. Speichern Sie die Präsentation als PPTX-Datei auf der Festplatte.

Dieser Java-Code zeigt Ihnen, wie Sie den `PathFootball` (Pfad Fußball) Effekt auf eine Form anwenden:

```java
// Instanziert eine Präsentationsklasse, die eine PPTX-Datei darstellt.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Erstellt den PathFootball-Effekt für eine vorhandene Form von Grund auf.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animierter Textkasten");

    // Fügt den PathFootBall-Animationseffekt hinzu
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Erstellt eine Art "Taste".
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Erstellt eine Sequenz von Effekten für diese Taste.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // Erstellt einen benutzerdefinierten Benutzerpfad. Unser Objekt wird nur bewegt, nachdem die Taste geklickt wurde.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // Fügt Befehle zum Bewegen hinzu, da der erstellte Pfad leer ist.
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

## **Die auf die Form angewendeten Animationseffekte abrufen**

Sie können entscheiden, alle auf eine einzelne Form angewendeten Animationseffekte herauszufinden.

Dieser Java-Code zeigt Ihnen, wie Sie alle auf eine bestimmte Form angewendeten Effekte erhalten:

```java
// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Erhält die Hauptsequenz der Folie.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Erhält die erste Form auf der Folie.
    IShape shape = firstSlide.getShapes().get_Item(0);

    // Erhält alle Animationseffekte, die auf die Form angewendet wurden.
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("Die Form " + shape.getName() + " hat " + shapeEffects.length + " Animationseffekte.");
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animationseffektzeit-Eigenschaften ändern**

Aspose.Slides für Java ermöglicht es Ihnen, die Timing-Eigenschaften eines Animationseffekts zu ändern.

Dies ist das Animation Timing-Fenster in Microsoft PowerPoint:

![example1_image](shape-animation.png)

Dies sind die Entsprechungen zwischen PowerPoint-Timing und [Effect.Timing](https://reference.aspose.com/slides/java/com.aspose.slides/IEffect#getTiming--) Eigenschaften:

- PowerPoint Timing **Start** Dropdown-Liste entspricht der [Effect.Timing.TriggerType](https://reference.aspose.com/slides/java/com.aspose.slides/ITiming#getTriggerType--) Eigenschaft. 
- PowerPoint Timing **Dauer** entspricht der [Effect.Timing.Duration](https://reference.aspose.com/slides/java/com.aspose.slides/ITiming#getDuration--) Eigenschaft. Die Dauer einer Animation (in Sekunden) ist die Gesamtzeit, die die Animation benötigt, um einen Zyklus abzuschließen. 
- PowerPoint Timing **Verzögerung** entspricht der [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/java/com.aspose.slides/ITiming#getTriggerDelayTime--) Eigenschaft. 

So ändern Sie die Effektzeit-Eigenschaften:

1. [Wenden Sie an](#apply-animation-to-shape) oder erhalten Sie den Animationseffekt.
2. Setzen Sie neue Werte für die [Effect.Timing](https://reference.aspose.com/slides/java/com.aspose.slides/IEffect#getTiming--) Eigenschaften, die Sie benötigen. 
3. Speichern Sie die modifizierte PPTX-Datei.

Dieser Java-Code demonstriert die Operation:

```java
// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Erhält die Hauptsequenz der Folie.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Erhält den ersten Effekt der Hauptsequenz.
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

## **Animations-Effekt-Sound**

Aspose.Slides bietet diese Eigenschaften, um mit Sounds in Animationseffekten zu arbeiten: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) 
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/java/com.aspose.slides/effect/#setStopPreviousSound-boolean-) 

### **Animations-Effekt-Sound hinzufügen**

Dieser Java-Code zeigt Ihnen, wie Sie einem Animations-Effekt-Sound hinzufügen und ihn stoppen, wenn der nächste Effekt beginnt:

```java
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Fügt Audio zur Präsentations-Audio-Kollektion hinzu
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Erhält die Hauptsequenz der Folie.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Erhält den ersten Effekt der Hauptsequenz
    IEffect firstEffect = sequence.get_Item(0);

    // Überprüft den Effekt auf "Kein Sound"
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // Fügt Sound für den ersten Effekt hinzu
        firstEffect.setSound(effectSound);
    }

    // Erhält die erste interaktive Sequenz der Folie.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // Setzt das Effekt "Stop vorherigen Sound"-Flag
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // Schreibt die PPTX-Datei auf die Festplatte
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Animations-Effekt-Sound extrahieren**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/aspose.slides/presentation/) Klasse.
2. Erhalten Sie einen Folienverweis über dessen Index. 
3. Erhalten Sie die Hauptsequenz von Effekten. 
4. Extrahieren Sie den [setSound(IAudio value)](https://reference.aspose.com/slides/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) in jedem Animations-Effekt eingebetteten Sound. 

Dieser Java-Code zeigt Ihnen, wie Sie den in einem Animations-Effekt eingebetteten Sound extrahieren:

```java
// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Erhält die Hauptsequenz der Folie.
    ISequence sequence = slide.getTimeline().getMainSequence();

    for (IEffect effect : sequence)
    {
        if (effect.getSound() == null)
            continue;

        // Extrahiert den Effekt-Sound als Byte-Array
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Nach Animation**

Aspose.Slides für Java ermöglicht es Ihnen, die Nachanimationseigenschaft eines Animationseffekts zu ändern.

Dies ist das Animationseffektfenster und das erweiterte Menü in Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

Die PowerPoint Effekt **Nachanimation** Dropdown-Liste entspricht diesen Eigenschaften: 

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAfterAnimationType-int-) Eigenschaft, die den Nachanimationstyp beschreibt:
  * PowerPoint **Mehr Farben** entspricht dem [AfterAnimationType.Color](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#Color) Typ;
  * PowerPoint **Nicht dimmen** Listeneintrag entspricht dem [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#DoNotDim) Typ (Standard-Nachanimationstyp);
  * PowerPoint **Nach Animation ausblenden** Eintrag entspricht dem [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#HideAfterAnimation) Typ;
  * PowerPoint **Beim nächsten Mausklick ausblenden** Eintrag entspricht dem [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick) Typ;
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) Eigenschaft, die ein Nachanimationsfarbformat definiert. Diese Eigenschaft funktioniert in Verbindung mit dem [AfterAnimationType.Color](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#Color) Typ. Wenn Sie den Typ in einen anderen ändern, wird die Nachanimationsfarbe gelöscht.

Dieser Java-Code zeigt Ihnen, wie Sie den Nachanimations-Effekt ändern:

```java
// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Erhält den ersten Effekt der Hauptsequenz
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Ändert den Nachanimations-Typ auf Farbe
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // Setzt die Nachanimationsdimfarbe
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // Schreibt die PPTX-Datei auf die Festplatte
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Text animieren**

Aspose.Slides bietet diese Eigenschaften, um mit dem *Text animieren*-Block eines Animations-Effekts zu arbeiten:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) der den Animations-Texttyp des Effekts beschreibt. Der Text der Form kann animiert werden:
  - Alle auf einmal ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/java/com.aspose.slides/animatetexttype/#AllAtOnce) Typ)
  - Nach Wort ([AnimateTextType.ByWord](https://reference.aspose.com/slides/java/com.aspose.slides/animatetexttype/#ByWord) Typ)
  - Nach Buchstaben ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/java/com.aspose.slides/animatetexttype/#ByLetter) Typ)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) setzt eine Verzögerung zwischen den animierten Textteilen (Wörtern oder Buchstaben). Ein positiver Wert gibt den Prozentsatz der Effekt-Dauer an. Ein negativer Wert gibt die Verzögerung in Sekunden an.

So ändern Sie die Effekt-Textanimator-Eigenschaften:

1. [Wenden Sie an](#apply-animation-to-shape) oder erhalten Sie den Animationseffekt.
2. Setzen Sie die [setBuildType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/itextanimation/#setBuildType-int-) Eigenschaft auf den Wert [BuildType.AsOneObject](https://reference.aspose.com/slides/java/com.aspose.slides/buildtype/#AsOneObject), um den *Nach Absätzen* Animationsmodus auszuschalten.
3. Setzen Sie neue Werte für die [setAnimateTextType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) und [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) Eigenschaften.
4. Speichern Sie die modifizierte PPTX-Datei.

Dieser Java-Code demonstriert die Operation:

```java
// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
Presentation pres = new Presentation("AnimTextBox_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Erhält den ersten Effekt der Hauptsequenz
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Ändert den Effekt-Textanimations-Typ auf "Als ein Objekt"
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // Ändert den Effekt-Textanimations-Typ auf "Nach Wort"
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // Setzt die Verzögerung zwischen Wörtern auf 20% der Effekt-Dauer
    firstEffect.setDelayBetweenTextParts(20f);

    // Schreibt die PPTX-Datei auf die Festplatte
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```