---
title: Formanimationen in Präsentationen auf Android anwenden
linktitle: Formanimation
type: docs
weight: 60
url: /de/androidjava/shape-animation/
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
- Android
- Java
- Aspose.Slides
description: "Entdecken Sie, wie Sie Formanimationen in PowerPoint-Präsentationen mit Aspose.Slides für Android via Java erstellen und anpassen. Heben Sie sich ab!"
---

Animationen sind visuelle Effekte, die auf Texte, Bilder, Formen oder [Diagramme](https://docs.aspose.com/slides/androidjava/animated-charts/) angewendet werden können. Sie verleihen Präsentationen oder deren Bestandteilen Leben.

## **Warum Animationen in Präsentationen verwenden?**

Mit Animationen können Sie

* den Informationsfluss steuern
* wichtige Punkte hervorheben
* das Interesse oder die Beteiligung Ihres Publikums steigern
* Inhalte leichter lesbar, nachvollziehbar oder verarbeitbar machen
* die Aufmerksamkeit Ihrer Leser oder Zuschauer auf wichtige Teile einer Präsentation lenken

PowerPoint bietet viele Optionen und Werkzeuge für Animationen und Animationseffekte in den Kategorien **Eingang**, **Ausgang**, **Betonung** und **Bewegungsbahnen**.

## **Animationen in Aspose.Slides**

* Aspose.Slides stellt die Klassen und Typen bereit, die Sie benötigen, um mit Animationen im Namensraum `Aspose.Slides.Animation` zu arbeiten,
* Aspose.Slides bietet über **150 Animationseffekte** in der Aufzählung [EffectType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effecttype). Diese Effekte entsprechen im Wesentlichen denselben (oder gleichwertigen) Effekten, die in PowerPoint verwendet werden.

## **Animation auf ein Textfeld anwenden**

Aspose.Slides für Android via Java ermöglicht es Ihnen, Animationen auf den Text in einer Form anzuwenden.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Holen Sie sich eine Folienreferenz über deren Index.
3. Fügen Sie eine `rectangle` [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape) hinzu.
4. Fügen Sie Text zu [IAutoShape.TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-) hinzu.
5. Holen Sie sich die Hauptsequenz der Effekte.
6. Fügen Sie einen Animationseffekt zu [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape) hinzu.
7. Setzen Sie die Eigenschaft `TextAnimation.BuildType` auf den Wert aus der Aufzählung `BuildType`.
8. Schreiben Sie die Präsentation als PPTX-Datei auf die Festplatte.

Dieser Java-Code zeigt Ihnen, wie Sie den `Fade`-Effekt auf AutoShape anwenden und die Textanimation auf den Wert *By 1st Level Paragraphs* setzen:
```java
// Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Fügt ein neues AutoShape mit Text hinzu
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // Holt die Hauptsequenz der Folie.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // Fügt dem Shape den Fade-Animationseffekt hinzu
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Animiert den Shape-Text nach Absätzen der ersten Ebene
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // Speichert die PPTX-Datei auf dem Datenträger
    pres.save(path + "AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{%  alert color="primary"  %}} 

Neben dem Anwenden von Animationen auf Text können Sie auch Animationen auf einen einzelnen [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph) anwenden. Siehe [**Animierter Text**](/slides/de/androidjava/animated-text/).

{{% /alert %}} 

## **Animation auf ein PictureFrame anwenden**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Holen Sie sich die Referenz einer Folie über deren Index.
3. Fügen Sie ein [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe) zur Folie hinzu oder holen Sie es.
4. Holen Sie die Hauptsequenz der Effekte.
5. Fügen Sie einen Animationseffekt zu [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe) hinzu.
6. Schreiben Sie die Präsentation als PPTX-Datei auf die Festplatte.

Dieser Java-Code zeigt Ihnen, wie Sie den `Fly`-Effekt auf einen Bildrahmen anwenden:
```java
// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
Presentation pres = new Presentation();
try {
    // Bild laden, das der Bildsammlung der Präsentation hinzugefügt werden soll
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Fügt der Folie einen Bildrahmen hinzu
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // Holt die Hauptsequenz der Folie.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Fügt dem Bildrahmen den Fly-from-Left-Animationseffekt hinzu
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Speichert die PPTX-Datei auf dem Datenträger
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Animation auf eine Form anwenden**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)-Klasse.
2. Holen Sie sich die Referenz einer Folie über deren Index.
3. Fügen Sie eine `rectangle` [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape) hinzu.
4. Fügen Sie eine `Bevel` [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape) hinzu (wenn dieses Objekt angeklickt wird, wird die Animation abgespielt).
5. Erstellen Sie eine Sequenz von Effekten für die Bevel-Form.
6. Erstellen Sie einen benutzerdefinierten `UserPath`.
7. Fügen Sie Befehle zum Bewegen zum `UserPath` hinzu.
8. Schreiben Sie die Präsentation als PPTX-Datei auf die Festplatte.

Dieser Java-Code zeigt Ihnen, wie Sie den `PathFootball` (Pfad-Fußball)-Effekt auf eine Form anwenden:
```java
// Instanziiert eine Presentation-Klasse, die eine PPTX-Datei darstellt.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Erstellt den PathFootball-Effekt für die vorhandene Form von Grund auf.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // Fügt den PathFootball-Animationseffekt hinzu
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Erstellt eine Art "Button".
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Erstellt eine Sequenz von Effekten für diesen Button.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // Erstellt einen benutzerdefinierten Pfad. Unser Objekt wird erst bewegt, nachdem der Button geklickt wurde.
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


## **Animationseffekte einer Form abrufen**

Die folgenden Beispiele zeigen Ihnen, wie Sie die Methode `getEffectsByShape` aus dem Interface [ISequence](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isequence/) verwenden, um alle auf eine Form angewendeten Animationseffekte abzurufen.

**Beispiel 1: Animationseffekte einer Form auf einer normalen Folie abrufen**

Zuvor haben Sie gelernt, wie man Animationseffekte zu Formen in PowerPoint-Präsentationen hinzufügt. Der folgende Beispielcode zeigt Ihnen, wie Sie die auf die erste Form der ersten normalen Folie in der Präsentation `AnimExample_out.pptx` angewendeten Effekte abrufen.
```java
Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Holt die Hauptanimationssequenz der Folie.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Holt die erste Form auf der ersten Folie.
    IShape shape = firstSlide.getShapes().get_Item(0);

    // Holt die auf die Form angewendeten Animationseffekte.
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("The shape " + shape.getName() + " has " + shapeEffects.length + " animation effects.");
} finally {
    if (presentation != null) presentation.dispose();
}
```


**Beispiel 2: Alle Animationseffekte abrufen, einschließlich der von Platzhaltern geerbten**

Wenn eine Form auf einer normalen Folie Platzhalter hat, die sich auf der Layout‑Folie und/oder der Master‑Folie befinden, und diesen Platzhaltern Animationseffekte hinzugefügt wurden, dann werden alle Effekte der Form während der Bildschirmpräsentation abgespielt, einschließlich der von den Platzhaltern geerbten.

Angenommen, wir haben eine PowerPoint‑Präsentationsdatei `sample.pptx` mit einer Folie, die nur eine Fußzeilenform mit dem Text "Made with Aspose.Slides" enthält und auf die der **Random Bars**‑Effekt angewendet wurde.

![Slide shape animation effect](slide-shape-animation.png)

Nehmen wir außerdem an, dass der **Split**‑Effekt auf den Fußzeilen‑Platzhalter auf der **Layout**‑Folie angewendet wurde.

![Layout shape animation effect](layout-shape-animation.png)

Und schließlich wurde der **Fly In**‑Effekt auf den Fußzeilen‑Platzhalter auf der **Master**‑Folie angewendet.

![Master shape animation effect](master-shape-animation.png)

Der folgende Beispielcode zeigt Ihnen, wie Sie die Methode `getBasePlaceholder` aus dem Interface [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) verwenden, um auf die Platzhalter der Form zuzugreifen und die auf die Fußzeilenform angewendeten Animationseffekte abzurufen, einschließlich der von Platzhaltern, die sich auf Layout‑ und Master‑Folien befinden, geerbten.
```java
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
printEffects(masterShapeEffects);
printEffects(layoutShapeEffects);
printEffects(shapeEffects);

presentation.dispose();
```

```java
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


## **Timing‑Eigenschaften von Animationseffekten ändern**

Aspose.Slides für Android via Java ermöglicht es Ihnen, die Timing‑Eigenschaften eines Animationseffekts zu ändern.

Dies ist das Animations‑Timing‑Fenster in Microsoft PowerPoint:
![example1_image](shape-animation.png)

Dies sind die Zuordnungen zwischen PowerPoint‑Timing und den Eigenschaften von [Effect.Timing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IEffect#getTiming--):
- Die Drop‑Down‑Liste **Start** im PowerPoint‑Timing entspricht der Eigenschaft [Effect.Timing.TriggerType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getTriggerType--).
- Das PowerPoint‑Timing **Duration** entspricht der Eigenschaft [Effect.Timing.Duration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getDuration--). Die Dauer einer Animation (in Sekunden) ist die Gesamtzeit, die die Animation für einen Durchlauf benötigt.
- Das PowerPoint‑Timing **Delay** entspricht der Eigenschaft [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getTriggerDelayTime--).

So ändern Sie die Eigenschaften des Effect‑Timing:
1. [Apply](#apply-animation-to-shape) oder holen Sie den Animationseffekt.
2. Setzen Sie neue Werte für die benötigten [Effect.Timing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IEffect#getTiming--) Eigenschaften.
3. Speichern Sie die modifizierte PPTX‑Datei.

Dieser Java-Code demonstriert die Vorgehensweise:
```java
// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Holt die Hauptsequenz der Folie.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Holt den ersten Effekt der Hauptsequenz.
    IEffect effect = sequence.get_Item(0);

    // Ändert den TriggerType des Effekts, damit er bei Klick startet
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // Ändert die Dauer des Effekts
    effect.getTiming().setDuration(3f);

    // Ändert die Triggerverzögerungszeit des Effekts
    effect.getTiming().setTriggerDelayTime(0.5f);

    // Speichert die PPTX-Datei auf dem Datenträger
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Ton von Animationseffekten**

Aspose.Slides stellt diese Eigenschaften zur Verfügung, um mit Tönen in Animationseffekten zu arbeiten:
- [setSound(IAudio value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setStopPreviousSound-boolean-)

### **Einen Ton zu einem Animationseffekt hinzufügen**

Dieser Java-Code zeigt Ihnen, wie Sie einen Ton zu einem Animationseffekt hinzufügen und ihn stoppen, wenn der nächste Effekt startet:
```java
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Fügt Audio zur Audiosammlung der Präsentation hinzu
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Holt die Hauptsequenz der Folie.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Holt den ersten Effekt der Hauptsequenz
    IEffect firstEffect = sequence.get_Item(0);

    // Prüft den Effekt auf "No Sound"
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // Fügt dem ersten Effekt einen Ton hinzu
        firstEffect.setSound(effectSound);
    }

    // Holt die erste interaktive Sequenz der Folie.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // Setzt das Flag "Stop previous sound" des Effekts
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // Speichert die PPTX-Datei auf dem Datenträger
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```



### **Einen Ton eines Animationseffekts extrahieren**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/aspose.slides/presentation/).
2. Holen Sie sich die Referenz einer Folie über deren Index.
3. Holen Sie die Hauptsequenz der Effekte.
4. Extrahieren Sie den in jedem Animationseffekt eingebetteten [setSound(IAudio value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) .

Dieser Java-Code zeigt Ihnen, wie Sie den in einen Animationseffekt eingebetteten Ton extrahieren:
```java
// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Holt die Hauptsequenz der Folie.
    ISequence sequence = slide.getTimeline().getMainSequence();

    for (IEffect effect : sequence)
    {
        if (effect.getSound() == null)
            continue;

        // Extrahiert den Ton des Effekts in ein Byte-Array
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Nach der Animation**

Aspose.Slides für Android via Java ermöglicht es Ihnen, die Eigenschaft Nach‑Animation eines Animationseffekts zu ändern.

Dies ist das Fenster für Animationseffekte und das erweiterte Menü in Microsoft PowerPoint:
![example1_image](shape-after-animation.png)

Die Drop‑Down‑Liste **After animation** des PowerPoint‑Effekts entspricht diesen Eigenschaften:
- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAfterAnimationType-int-)‑Eigenschaft, die den Typ der Nach‑Animation beschreibt:
  * PowerPoint **More Colors** entspricht dem Typ [AfterAnimationType.Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#Color).
  * PowerPoint **Don't Dim**‑Eintrag entspricht dem Typ [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#DoNotDim), (Standard‑Nach‑Animationstyp);
  * PowerPoint **Hide After Animation**‑Eintrag entspricht dem Typ [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#HideAfterAnimation);
  * PowerPoint **Hide on Next Mouse Click**‑Eintrag entspricht dem Typ [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick);
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-)‑Eigenschaft, die ein Farbformat für die Nach‑Animation definiert. Diese Eigenschaft arbeitet zusammen mit dem Typ [AfterAnimationType.Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#Color). Wenn Sie den Typ zu einem anderen ändern, wird die Nach‑Animationsfarbe gelöscht.

Dieser Java-Code zeigt Ihnen, wie Sie einen Nach‑Animationseffekt ändern:
```java
// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Holt den ersten Effekt der Hauptsequenz
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Ändert den Nach-Animationstyp auf Farbe
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // Setzt die Dim-Farbe nach der Animation
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // Speichert die PPTX-Datei auf dem Datenträger
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Text animieren**

Aspose.Slides stellt diese Eigenschaften zur Verfügung, um mit dem *Animate text*‑Block eines Animationseffekts zu arbeiten:
- [setAnimateTextType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-)‑Eigenschaft, die den Animations‑Text‑Typ des Effekts beschreibt. Der Text einer Form kann animiert werden:
  * Alle gleichzeitig ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#AllAtOnce) Typ)
  * Wortweise ([AnimateTextType.ByWord](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#ByWord) Typ)
  * Buchstabenweise ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#ByLetter) Typ)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-)‑Eigenschaft legt eine Verzögerung zwischen den animierten Textteilen (Wörter oder Buchstaben) fest. Ein positiver Wert gibt den Prozentsatz der Effekt‑Dauer an. Ein negativer Wert gibt die Verzögerung in Sekunden an.

So können Sie die Eigenschaften des Effect‑Animate‑Text ändern:
1. [Apply](#apply-animation-to-shape) oder holen Sie den Animationseffekt.
2. Setzen Sie die [setBuildType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextanimation/#setBuildType-int-)‑Eigenschaft auf den Wert [BuildType.AsOneObject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/buildtype/#AsOneObject), um den *By Paragraphs*‑Animationsmodus zu deaktivieren.
3. Setzen Sie neue Werte für die Eigenschaften [setAnimateTextType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) und [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-).
4. Speichern Sie die modifizierte PPTX‑Datei.

Dieser Java-Code demonstriert die Vorgehensweise:
```java
// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
Presentation pres = new Presentation("AnimTextBox_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Holt den ersten Effekt der Hauptsequenz
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Ändert den Textanimations-Typ des Effekts zu "As One Object"
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // Ändert den Textanimierungstyp des Effekts zu "By word"
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // Setzt die Verzögerung zwischen Wörtern auf 20% der Effektdauer
    firstEffect.setDelayBetweenTextParts(20f);

    // Speichert die PPTX-Datei auf dem Datenträger
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Wie kann ich sicherstellen, dass Animationen beim Veröffentlichen der Präsentation im Web erhalten bleiben?**  
[Export to HTML5](/slides/de/androidjava/export-to-html5/) und aktivieren Sie die [Optionen](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/), die für [Formen](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) und [Übergänge](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) Animationen verantwortlich sind. Reines HTML spielt Folienanimationen nicht ab, während HTML5 dies tut.

**Wie wirkt sich das Ändern der Z‑Reihenfolge (Schichtenreihenfolge) von Formen auf die Animation aus?**  
Animation und Zeichenreihenfolge sind unabhängig: Ein Effekt steuert das Timing und die Art des Erscheinen/Verschwinden, während die [z-order](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getZOrderPosition--) bestimmt, was was überlappt. Das sichtbare Ergebnis wird durch ihre Kombination definiert. (Dies ist das allgemeine Verhalten von PowerPoint; das Aspose.Slides‑Effekte‑und‑Formen‑Modell folgt derselben Logik.)

**Gibt es Einschränkungen beim Konvertieren von Animationen in Video für bestimmte Effekte?**  
Im Allgemeinen werden [Animationen unterstützt](/slides/de/androidjava/convert-powerpoint-to-video/), aber seltene Fälle oder spezifische Effekte können anders gerendert werden. Es wird empfohlen, die von Ihnen verwendeten Effekte und die Bibliotheksversion zu testen.