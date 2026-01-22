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
- Sound des Effekts
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

* den Informationsfluss steuern
* wichtige Punkte hervorheben
* das Interesse oder die Teilnahme Ihres Publikums steigern
* Inhalte leichter lesbar, verdaulich oder verarbeitbar machen
* die Aufmerksamkeit Ihrer Leser oder Zuschauer auf wichtige Teile einer Präsentation lenken

PowerPoint bietet zahlreiche Optionen und Werkzeuge für Animationen und Animationseffekte in den Kategorien **Eingang**, **Ausgang**, **Betonung** und **Bewegungspfade**. 

## **Animationen in Aspose.Slides**

* Aspose.Slides stellt die Klassen und Typen bereit, die Sie benötigen, um mit Animationen im Namespace `Aspose.Slides.Animation` zu arbeiten,
* Aspose.Slides bietet über **150 Animationseffekte** im Aufzählungstyp [EffectType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effecttype). Diese Effekte sind im Wesentlichen dieselben (oder gleichwertige) Effekte, die in PowerPoint verwendet werden.

## **Animation auf eine TextBox anwenden**

Aspose.Slides für Android über Java ermöglicht es, einer Form den Text zu animieren.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)‑Klasse.  
2. Holen Sie eine Folienreferenz über deren Index.  
3. Fügen Sie ein `rectangle` [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape) hinzu.  
4. Fügen Sie Text zu [IAutoShape.TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-) hinzu.  
5. Holen Sie die Hauptsequenz der Effekte.  
6. Fügen Sie einen Animationseffekt zu [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape) hinzu.  
7. Setzen Sie die Eigenschaft `TextAnimation.BuildType` auf den Wert aus der Enumeration `BuildType`.  
8. Speichern Sie die Präsentation als PPTX‑Datei auf dem Datenträger.

Dieser Java‑Code zeigt, wie der `Fade`‑Effekt auf ein AutoShape angewendet und die Textanimation auf den Wert *By 1st Level Paragraphs* gesetzt wird:
```java
// Instanziiert eine Presentation-Klasse, die eine Präsentationsdatei darstellt.
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

    // Animiert den Text des Shapes nach 1. Ebenenabsätzen
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // Speichert die PPTX-Datei auf dem Datenträger
    pres.save(path + "AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{%  alert color="primary"  %}} 

Zusätzlich zum Anwenden von Animationen auf Text können Sie auch Animationen auf einen einzelnen [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph) anwenden. Siehe **Animierter Text**(/slides/de/androidjava/animated-text/).

{{% /alert %}} 

## **Animation auf ein PictureFrame anwenden**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)‑Klasse.  
2. Holen Sie die Referenz einer Folie anhand ihres Index.  
3. Fügen Sie ein [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe) hinzu oder holen Sie ein solches auf der Folie.  
4. Holen Sie die Hauptsequenz der Effekte.  
5. Fügen Sie einen Animationseffekt zu [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe) hinzu.  
6. Speichern Sie die Präsentation als PPTX‑Datei auf dem Datenträger.

Dieser Java‑Code zeigt, wie der `Fly`‑Effekt auf einen Bildrahmen angewendet wird:
```java
// Instanziert eine Presentation-Klasse, die eine Präsentationsdatei darstellt.
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

    // Fügt dem Folie ein Bildrahmen hinzu
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


## **Animation auf eine Shape anwenden**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)‑Klasse.  
2. Holen Sie eine Folienreferenz über deren Index.  
3. Fügen Sie ein `rectangle` [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape) hinzu.  
4. Fügen Sie ein `Bevel`‑[IAutoShape] hinzu (wenn dieses Objekt angeklickt wird, wird die Animation abgespielt).  
5. Erstellen Sie eine Sequenz von Effekten auf der Bevel‑Form.  
6. Erstellen Sie einen benutzerdefinierten `UserPath`.  
7. Fügen Sie Befehle zum Bewegen zum `UserPath` hinzu.  
8. Speichern Sie die Präsentation als PPTX‑Datei auf dem Datenträger.

Dieser Java‑Code zeigt, wie der `PathFootball`‑Effekt (Pfad‑Fußball) auf eine Form angewendet wird:
```java
// Instanziiert eine Presentation-Klasse, die eine PPTX-Datei darstellt.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Erstellt den PathFootball-Effekt für die vorhandene Form von Grund auf.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // Fügt den PathFootBall-Animationseffekt hinzu
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Erstellt eine Art "Button".
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Erstellt eine Sequenz von Effekten für diesen Button.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // Erstellt einen benutzerdefinierten Pfad. Unser Objekt wird erst nach dem Klick auf den Button bewegt.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // Fügt Befehle zum Bewegen hinzu, da der erstellte Pfad leer ist.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

     // Schreibt die PPTX-Datei auf dem Datenträger
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Die auf eine Shape angewendeten Animationseffekte abrufen**

Die folgenden Beispiele zeigen, wie die Methode `getEffectsByShape` aus dem [ISequence](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isequence/)‑Interface verwendet wird, um alle auf eine Form angewendeten Animationseffekte zu erhalten.

**Beispiel 1: Animationseffekte abrufen, die auf eine Form auf einer normalen Folie angewendet wurden**

Zuvor haben Sie gelernt, wie man Animationseffekte zu Formen in PowerPoint‑Präsentationen hinzufügt. Der folgende Beispielcode zeigt, wie man die auf die erste Form der ersten normalen Folie in der Präsentation `AnimExample_out.pptx` angewendeten Effekte abruft.
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

Wenn eine Form auf einer normalen Folie Platzhalter hat, die sich auf der Layout‑Folie und/oder der Master‑Folie befinden, und diesen Platzhaltern Animationseffekte hinzugefügt wurden, dann werden alle Effekte der Form während der Bildschirmanzeige abgespielt, einschließlich der von den Platzhaltern geerbten.

Angenommen, wir haben eine PowerPoint‑Präsentationsdatei `sample.pptx` mit einer Folie, die nur eine Fußzeilenform mit dem Text „Made with Aspose.Slides“ enthält und auf die der **Random Bars**‑Effekt angewendet wurde.

![Folienform-Animationseffekt](slide-shape-animation.png)

Wir nehmen außerdem an, dass der **Split**‑Effekt auf den Fußzeilen‑Platzhalter der **Layout**‑Folie angewendet wurde.

![Layout-Form-Animationseffekt](layout-shape-animation.png)

Und schließlich wurde der **Fly In**‑Effekt auf den Fußzeilen‑Platzhalter der **Master**‑Folie angewendet.

![Master-Form-Animationseffekt](master-shape-animation.png)

Der folgende Beispielcode zeigt, wie die Methode `getBasePlaceholder` aus dem [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/)‑Interface verwendet wird, um auf die Form‑Platzhalter zuzugreifen und die auf die Fußzeilenform angewendeten Animationseffekte zu erhalten, einschließlich der von Platzhaltern auf Layout‑ und Master‑Folien geerbten.
```java
Presentation presentation = new Presentation("sample.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

// Holt die Animations-Effekte der Form auf der normalen Folie.
IShape shape = slide.getShapes().get_Item(0);
IEffect[] shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Holt die Animations-Effekte des Platzhalters auf der Layout-Folie.
IShape layoutShape = shape.getBasePlaceholder();
IEffect[] layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Holt die Animations-Effekte des Platzhalters auf der Master-Folie.
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


Ausgabe:
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```


## **Animationseffekt‑Timing‑Eigenschaften ändern**

Aspose.Slides für Android über Java ermöglicht es, die Timing‑Eigenschaften eines Animationseffekts zu ändern.

![Beispiel1_Bild](shape-animation.png)

Dies sind die Entsprechungen zwischen PowerPoint‑Timing und [Effect.Timing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IEffect#getTiming--)‑Eigenschaften:

- Die Dropdown‑Liste **Start** in PowerPoint Timing entspricht der Eigenschaft [Effect.Timing.TriggerType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getTriggerType--).  
- PowerPoint Timing **Duration** entspricht der Eigenschaft [Effect.Timing.Duration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getDuration--). Die Dauer einer Animation (in Sekunden) ist die Gesamtzeit, die die Animation für einen Durchlauf benötigt.  
- PowerPoint Timing **Delay** entspricht der Eigenschaft [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getTriggerDelayTime--).

So ändern Sie die Effect Timing‑Eigenschaften:

1. Wenden Sie den Animationseffekt an ([Apply](#apply-animation-to-shape)) oder holen Sie ihn ab.  
2. Setzen Sie neue Werte für die benötigten [Effect.Timing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IEffect#getTiming--)‑Eigenschaften.  
3. Speichern Sie die modifizierte PPTX‑Datei.

Dieser Java‑Code demonstriert die Vorgehensweise:
```java
// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Holt die Hauptsequenz der Folie.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Holt den ersten Effekt der Hauptsequenz.
    IEffect effect = sequence.get_Item(0);

    // Ändert den TriggerTyp des Effekts, sodass er bei Klick startet.
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // Ändert die Dauer des Effekts.
    effect.getTiming().setDuration(3f);

    // Ändert die Triggerverzögerungszeit des Effekts.
    effect.getTiming().setTriggerDelayTime(0.5f);

    // Speichert die PPTX-Datei auf dem Datenträger.
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Animations‑Effekt‑Sound**

Aspose.Slides stellt folgende Eigenschaften bereit, um mit Sounds in Animationseffekten zu arbeiten:

- [setSound(IAudio value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)  
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setStopPreviousSound-boolean-)

### **Einen Animations‑Effekt‑Sound hinzufügen**

Dieser Java‑Code zeigt, wie man einen Animations‑Effekt‑Sound hinzufügt und ihn stoppt, wenn der nächste Effekt beginnt:
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

    // Prüft den Effekt auf "Kein Ton"
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // Fügt dem ersten Effekt einen Ton hinzu
        firstEffect.setSound(effectSound);
    }

    // Holt die erste interaktive Sequenz der Folie.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // Setzt das Flag "Vorherige Töne stoppen" für den Effekt
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // Speichert die PPTX-Datei auf dem Datenträger
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Einen Animations‑Effekt‑Sound extrahieren**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)‑Klasse.  
2. Holen Sie die Referenz einer Folie anhand ihres Index.  
3. Holen Sie die Hauptsequenz der Effekte.  
4. Extrahieren Sie den in jedem Animations‑Effekt eingebetteten [setSound(IAudio value)]‑Sound.

Dieser Java‑Code zeigt, wie man den in einem Animations‑Effekt eingebetteten Sound extrahiert:
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

        // Extrahiert den Sound des Effekts in ein Byte-Array
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Nach der Animation**

Aspose.Slides für Android über Java ermöglicht es, die After‑Animation‑Eigenschaft eines Animations‑Effekts zu ändern.

![Beispiel1_Bild](shape-after-animation.png)

PowerPoint Effect **After animation** drop‑down list matches these properties:

- Die Eigenschaft [setAfterAnimationType(int value)], die den After‑Animation‑Typ beschreibt:
  * PowerPoint **More Colors** entspricht dem Typ [AfterAnimationType.Color];  
  * PowerPoint **Don't Dim** entspricht dem Typ [AfterAnimationType.DoNotDim] (Standard‑After‑Animation‑Typ);  
  * PowerPoint **Hide After Animation** entspricht dem Typ [AfterAnimationType.HideAfterAnimation];  
  * PowerPoint **Hide on Next Mouse Click** entspricht dem Typ [AfterAnimationType.HideOnNextMouseClick];  
- Die Eigenschaft [setAfterAnimationColor(IColorFormat value)], die ein Farbformat für die After‑Animation definiert. Diese Eigenschaft funktioniert zusammen mit dem Typ [AfterAnimationType.Color]. Wird der Typ auf einen anderen geändert, wird die After‑Animation‑Farbe zurückgesetzt.

Dieser Java‑Code zeigt, wie man einen After‑Animation‑Effekt ändert:
```java
// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Holt den ersten Effekt der Hauptsequenz
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Ändert den After-Animation-Typ auf Color
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // Setzt die After-Animation-Dim-Farbe
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // Speichert die PPTX-Datei auf dem Datenträger
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Text animieren**

Aspose.Slides stellt folgende Eigenschaften bereit, um mit dem *Animate text*-Block eines Animations‑Effekts zu arbeiten:

- Die Eigenschaft [setAnimateTextType(int value)], die den Text‑Animationstyp des Effekts beschreibt. Der Text einer Form kann animiert werden:
  * Alles auf einmal ([AnimateTextType.AllAtOnce]‑Typ)  
  * Nach Wort ([AnimateTextType.ByWord]‑Typ)  
  * Nach Buchstabe ([AnimateTextType.ByLetter]‑Typ)  
- Die Eigenschaft [setDelayBetweenTextParts(float value)] legt eine Verzögerung zwischen den animierten Textteilen (Wörtern oder Buchstaben) fest. Ein positiver Wert gibt den Prozentsatz der Effekt‑Dauer an, ein negativer Wert die Verzögerung in Sekunden.

So können Sie die Eigenschaften des Effect Animate text ändern:

1. Wenden Sie den Animationseffekt an ([Apply](#apply-animation-to-shape)) oder holen Sie ihn ab.  
2. Setzen Sie die Eigenschaft [setBuildType(int value)] auf den Wert [BuildType.AsOneObject], um den *By Paragraphs*‑Animationsmodus zu deaktivieren.  
3. Setzen Sie neue Werte für die Eigenschaften [setAnimateTextType(int value)] und [setDelayBetweenTextParts(float value)] fest.  
4. Speichern Sie die modifizierte PPTX‑Datei.

Dieser Java‑Code demonstriert die Vorgehensweise:
```java
// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
Presentation pres = new Presentation("AnimTextBox_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Holt den ersten Effekt der Hauptsequenz
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Ändert den Textanimations-Typ des Effekts zu "As One Object"
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // Ändert den Animate-Text-Typ des Effekts zu "By word"
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

Exportieren Sie nach HTML5](/slides/de/androidjava/export-to-html5/) und aktivieren Sie die [options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/)‑Einstellungen, die für [shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) und [transition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) Animationen verantwortlich sind. Plain HTML spielt Folienanimationen nicht ab, HTML5 jedoch schon.

**Wie wirkt sich das Ändern der Z‑Reihenfolge (Schichtreihenfolge) von Formen auf die Animation aus?**

Animation‑ und Zeichenreihenfolge sind unabhängig: Ein Effekt steuert das Timing und den Typ des Erscheinen/Verschwinden, während die Z‑Reihenfolge bestimmt, was was überdeckt. Das sichtbare Ergebnis ergibt sich aus ihrer Kombination. (Dies ist das generelle PowerPoint‑Verhalten; das Aspose.Slides‑Modell für Effekte und Formen folgt derselben Logik.)

**Gibt es Einschränkungen beim Konvertieren von Animationen in Video für bestimmte Effekte?**

Im Allgemeinen werden Animationen unterstützt](/slides/de/androidjava/convert-powerpoint-to-video/), doch in seltenen Fällen oder bei spezifischen Effekten kann die Wiedergabe abweichen. Es wird empfohlen, die verwendeten Effekte und die Bibliotheksversion zu testen.