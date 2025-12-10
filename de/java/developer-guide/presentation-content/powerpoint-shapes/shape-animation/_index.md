---
title: Formanimationen in Präsentationen mit Java anwenden
linktitle: Formanimation
type: docs
weight: 60
url: /de/java/shape-animation/
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
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Formanimationen in PowerPoint-Präsentationen mit Aspose.Slides für Java erstellen und anpassen. Heben Sie sich ab!"
---

Animationen sind visuelle Effekte, die auf Texte, Bilder, Formen oder [Diagramme](https://docs.aspose.com/slides/java/animated-charts/) angewendet werden können. Sie verleihen Präsentationen oder deren Bestandteilen Leben. 

## **Warum Animationen in Präsentationen verwenden?**

Mit Animationen können Sie  

* den Informationsfluss steuern  
* wichtige Punkte hervorheben  
* das Interesse oder die Beteiligung Ihres Publikums erhöhen  
* Inhalte leichter lesbar, verdaulich oder verarbeitbar machen  
* die Aufmerksamkeit Ihrer Leser oder Zuschauer auf wichtige Teile einer Präsentation lenken  

PowerPoint bietet zahlreiche Optionen und Werkzeuge für Animationen und Animationseffekte in den Kategorien **Eingang**, **Ausgang**, **Betonung** und **Bewegungspfade**. 

## **Animationen in Aspose.Slides**

* Aspose.Slides stellt die Klassen und Typen bereit, die Sie zum Arbeiten mit Animationen im Namensraum `Aspose.Slides.Animation` benötigen,  
* Aspose.Slides bietet über **150 Animationseffekte** im [EffectType](https://reference.aspose.com/slides/java/com.aspose.slides/effecttype)-Aufzählung. Diese Effekte entsprechen im Wesentlichen den in PowerPoint verwendeten (oder äquivalenten) Effekten.  

## **Animation auf ein Textfeld anwenden**

Aspose.Slides for Java ermöglicht es Ihnen, eine Animation auf den Text in einer Form anzuwenden. 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)-Klasse.  
2. Holen Sie sich eine Folienreferenz über deren Index.  
3. Fügen Sie ein `rectangle` [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape) hinzu.  
4. Fügen Sie Text zu [IAutoShape.TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-) hinzu.  
5. Erhalten Sie die Hauptsequenz der Effekte.  
6. Fügen Sie einen Animationseffekt zu [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape) hinzu.  
7. Setzen Sie die Eigenschaft `TextAnimation.BuildType` auf den Wert aus der Aufzählung `BuildType`.  
8. Schreiben Sie die Präsentation als PPTX-Datei auf die Festplatte.  

Dieses Java‑Beispiel zeigt, wie Sie den `Fade`‑Effekt auf ein AutoShape anwenden und die Texteanimation auf den Wert *By 1st Level Paragraphs* setzen:
```java
// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei repräsentiert.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Fügt eine neue AutoShape mit Text hinzu
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // Holt die Hauptsequenz der Folie.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // Fügt dem Shape den Fade-Animationseffekt hinzu
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Animiert den Text der Form nach Absätzen der ersten Ebene
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // Speichert die PPTX-Datei auf die Festplatte
    pres.save(path + "AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{%  alert color="primary"  %}} 

Neben der Anwendung von Animationen auf Text können Sie auch Animationen auf einen einzelnen [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph) anwenden. Siehe [**Animierter Text**](/slides/de/java/animated-text/).  

{{% /alert %}} 

## **Animation auf ein PictureFrame anwenden**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)-Klasse.  
2. Holen Sie sich die Referenz einer Folie über deren Index.  
3. Fügen Sie ein [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe) zur Folie hinzu oder holen Sie es ab.  
4. Erhalten Sie die Hauptsequenz der Effekte.  
5. Fügen Sie einen Animationseffekt zu [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe) hinzu.  
6. Schreiben Sie die Präsentation als PPTX-Datei auf die Festplatte.  

Dieses Java‑Beispiel zeigt, wie Sie den `Fly`‑Effekt auf einen Bildrahmen anwenden:
```java
// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
Presentation pres = new Presentation();
try {
    // Bild laden, das der Bildersammlung der Präsentation hinzugefügt werden soll
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

    // Speichert die PPTX-Datei auf der Festplatte
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Animation auf eine Form anwenden**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)-Klasse.  
2. Holen Sie sich die Referenz einer Folie über deren Index.  
3. Fügen Sie ein `rectangle` [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape) hinzu.  
4. Fügen Sie ein `Bevel`‑[IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape) hinzu (wenn dieses Objekt angeklickt wird, wird die Animation abgespielt).  
5. Erstellen Sie eine Sequenz von Effekten für die Abschrägungsform.  
6. Erstellen Sie einen benutzerdefinierten `UserPath`.  
7. Fügen Sie Befehle zum Bewegen entlang des `UserPath` hinzu.  
8. Schreiben Sie die Präsentation als PPTX-Datei auf die Festplatte.  

Dieses Java‑Beispiel zeigt, wie Sie den `PathFootball`‑Effekt (Pfad‑Fußball) auf eine Form anwenden:
```java
// Instanziert eine Presentation-Klasse, die eine PPTX-Datei darstellt.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Erstellt den PathFootball-Effekt für eine vorhandene Form von Grund auf.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // Fügt den PathFootball-Animationseffekt hinzu
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Erstellt eine Art "Button".
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Erstellt eine Sequenz von Effekten für diesen Button.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // Erstellt einen benutzerdefinierten Pfad. Unser Objekt wird erst verschoben, nachdem der Button geklickt wurde.
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


## **Die auf eine Form angewendeten Animationseffekte abrufen**

Die folgenden Beispiele zeigen, wie Sie die Methode `getEffectsByShape` aus dem [ISequence](https://reference.aspose.com/slides/java/com.aspose.slides/isequence/)-Interface verwenden, um alle auf eine Form angewendeten Animationseffekte zu erhalten.

**Beispiel 1: Animationseffekte einer Form auf einer normalen Folie abrufen**

Zuvor haben Sie gelernt, wie Sie Animationseffekte zu Formen in PowerPoint‑Präsentationen hinzufügen. Der folgende Beispielcode zeigt, wie Sie die auf die erste Form der ersten normalen Folie in der Präsentation `AnimExample_out.pptx` angewendeten Effekte abrufen.
```java
Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Ermittelt die Hauptanimationssequenz der Folie.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Ermittelt die erste Form auf der ersten Folie.
    IShape shape = firstSlide.getShapes().get_Item(0);

    // Ermittelt die auf die Form angewendeten Animationseffekte.
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("The shape " + shape.getName() + " has " + shapeEffects.length + " animation effects.");
} finally {
    if (presentation != null) presentation.dispose();
}
```


**Beispiel 2: Alle Animationseffekte, einschließlich der von Platzhaltern geerbten, abrufen**

Hat eine Form auf einer normalen Folie Platzhalter, die sich auf der Layout‑ oder Master‑Folien befinden, und wurden diesen Platzhaltern Animationseffekte zugewiesen, dann werden alle Effekte der Form während der Präsentation abgespielt, einschließlich der von den Platzhaltern geerbten.

Angenommen, wir haben eine PowerPoint‑Präsentationsdatei `sample.pptx` mit einer Folie, die nur eine Fußzeilenform mit dem Text „Made with Aspose.Slides“ enthält und auf die der Effekt **Random Bars** angewendet wurde.

![Slide shape animation effect](slide-shape-animation.png)

Nehmen wir weiter an, dass auf dem **Layout**‑Foliensatz der Fußzeilen‑Platzhalter der Effekt **Split** angewendet wurde.

![Layout shape animation effect](layout-shape-animation.png)

Und schließlich wurde auf dem **Master**‑Foliensatz der Fußzeilen‑Platzhalter der Effekt **Fly In** angewendet.

![Master shape animation effect](master-shape-animation.png)

Der folgende Beispielcode demonstriert, wie Sie die Methode `getBasePlaceholder` aus dem [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/)-Interface verwenden, um auf die Platzhalter der Form zuzugreifen und die auf die Fußzeilenform angewendeten Animationseffekte zu erhalten, einschließlich der von Platzhaltern auf Layout‑ und Master‑Folien geerbten.
```java
Presentation presentation = new Presentation("sample.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

// Ermittelt die Animations-Effekte der Form auf der normalen Folie.
IShape shape = slide.getShapes().get_Item(0);
IEffect[] shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Ermittelt die Animations-Effekte des Platzhalters auf der Layout-Folie.
IShape layoutShape = shape.getBasePlaceholder();
IEffect[] layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Ermittelt die Animations-Effekte des Platzhalters auf der Master-Folie.
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


## **Zeit-Eigenschaften von Animationseffekten ändern**

Aspose.Slides for Java ermöglicht es Ihnen, die Timing‑Eigenschaften eines Animationseffekts zu ändern.

Dies ist das **Animation Timing**‑Fenster in Microsoft PowerPoint:

![example1_image](shape-animation.png)

Die Zuordnungen zwischen PowerPoint‑Timing und den Eigenschaften von [Effect.Timing](https://reference.aspose.com/slides/java/com.aspose.slides/IEffect#getTiming--) sind:

- Das Dropdown‑Feld **Start** in PowerPoint entspricht der Eigenschaft [Effect.Timing.TriggerType](https://reference.aspose.com/slides/java/com.aspose.slides/ITiming#getTriggerType--).  
- **Duration** entspricht der Eigenschaft [Effect.Timing.Duration](https://reference.aspose.com/slides/java/com.aspose.slides/ITiming#getDuration--). Die Dauer einer Animation (in Sekunden) ist die Gesamtzeit, die die Animation für einen Durchlauf benötigt.  
- **Delay** entspricht der Eigenschaft [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/java/com.aspose.slides/ITiming#getTriggerDelayTime--).  

So ändern Sie die Timing‑Eigenschaften eines Effekts:

1. [Wenden](#apply-animation-to-shape) Sie den Animationseffekt an oder rufen Sie ihn ab.  
2. Setzen Sie neue Werte für die gewünschten [Effect.Timing](https://reference.aspose.com/slides/java/com.aspose.slides/IEffect#getTiming--)‑Eigenschaften.  
3. Speichern Sie die geänderte PPTX‑Datei.  

Dieser Java‑Code demonstriert den Vorgang:
```java
// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Ermittelt die Hauptsequenz der Folie.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Ermittelt den ersten Effekt der Hauptsequenz.
    IEffect effect = sequence.get_Item(0);

    // Ändert den TriggerType des Effekts, sodass er bei Klick startet
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


## **Sound für Animationseffekte**

Aspose.Slides stellt folgende Eigenschaften bereit, um mit Sounds in Animationseffekten zu arbeiten: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)  
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/java/com.aspose.slides/effect/#setStopPreviousSound-boolean-)  

### **Ein Sound zu einem Animationseffekt hinzufügen**

Dieser Java‑Code zeigt, wie Sie einen Sound zu einem Animationseffekt hinzufügen und ihn stoppen, wenn der nächste Effekt beginnt:
```java
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Fügt Audio zur Audiosammlung der Präsentation hinzu
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Ermittelt die Hauptsequenz der Folie.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Ermittelt den ersten Effekt der Hauptsequenz
    IEffect firstEffect = sequence.get_Item(0);

    // Prüft, ob der Effekt keinen Sound hat
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // Fügt dem ersten Effekt einen Sound hinzu
        firstEffect.setSound(effectSound);
    }

    // Ermittelt die erste interaktive Sequenz der Folie.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // Setzt das Flag "Stop previous sound" für den Effekt
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // Schreibt die PPTX-Datei auf die Festplatte
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Einen Sound aus einem Animationseffekt extrahieren**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/aspose.slides/presentation/)-Klasse.  
2. Holen Sie sich die Referenz einer Folie über deren Index.  
3. Erhalten Sie die Hauptsequenz der Effekte.  
4. Extrahieren Sie den in jedem Animationseffekt eingebetteten [setSound(IAudio value)](https://reference.aspose.com/slides/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-).  

Dieser Java‑Code zeigt, wie Sie den in einem Animationseffekt eingebetteten Sound extrahieren:
```java
// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei repräsentiert.
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ermittelt die Hauptsequenz der Folie.
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


## **Nach‑Animation**

Aspose.Slides for Java ermöglicht es Ihnen, die **After animation**‑Eigenschaft eines Animationseffekts zu ändern.

Dies ist das Fenster **Animation Effect** und das erweiterte Menü in Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

Das Dropdown‑Feld **After animation** in PowerPoint entspricht diesen Eigenschaften: 

- Die Eigenschaft [setAfterAnimationType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAfterAnimationType-int-) beschreibt den Typ der Nach‑Animation:  
  * **More Colors** entspricht dem Typ [AfterAnimationType.Color](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#Color);  
  * **Don't Dim** entspricht dem Typ [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#DoNotDim) (Standard‑Nach‑Animationstyp);  
  * **Hide After Animation** entspricht dem Typ [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#HideAfterAnimation);  
  * **Hide on Next Mouse Click** entspricht dem Typ [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick).  
- Die Eigenschaft [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) definiert ein Farbschema für die Nach‑Animation. Diese Eigenschaft wirkt zusammen mit dem Typ [AfterAnimationType.Color](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#Color). Wird ein anderer Typ gewählt, wird die Nach‑Animationsfarbe zurückgesetzt.  

Dieser Java‑Code zeigt, wie Sie einen Nach‑Animationseffekt ändern:
```java
// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Ermittelt den ersten Effekt der Hauptsequenz
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Ändert den Nachanimationstyp zu Color
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // Setzt die Nachanimations-Dim-Farbe
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // Schreibt die PPTX-Datei auf die Festplatte
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Text animieren**

Aspose.Slides bietet folgende Eigenschaften, um den Block *Animate text* eines Animationseffekts zu steuern:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) beschreibt den Animations‑Texttyp des Effekts. Der Text einer Form kann animiert werden:  
  - Alles auf einmal ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/java/com.aspose.slides/animatetexttype/#AllAtOnce))  
  - Wortweise ([AnimateTextType.ByWord](https://reference.aspose.com/slides/java/com.aspose.slides/animatetexttype/#ByWord))  
  - Buchstabenweise ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/java/com.aspose.slides/animatetexttype/#ByLetter))  
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) legt eine Verzögerung zwischen den animierten Textteilen (Wörtern oder Buchstaben) fest. Ein positiver Wert gibt den Prozentsatz der Effekt‑Dauer an, ein negativer Wert die Verzögerung in Sekunden.  

So ändern Sie die Eigenschaften **Effect Animate text**:

1. [Wenden](#apply-animation-to-shape) Sie den Animationseffekt an oder rufen Sie ihn ab.  
2. Setzen Sie die Eigenschaft [setBuildType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/itextanimation/#setBuildType-int-) auf den Wert [BuildType.AsOneObject](https://reference.aspose.com/slides/java/com.aspose.slides/buildtype/#AsOneObject), um den Animationsmodus *By Paragraphs* zu deaktivieren.  
3. Setzen Sie neue Werte für die Eigenschaften [setAnimateTextType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) und [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-).  
4. Speichern Sie die geänderte PPTX‑Datei.  

Dieser Java‑Code demonstriert den Vorgang:
```java
// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
Presentation pres = new Presentation("AnimTextBox_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Ermittelt den ersten Effekt der Hauptsequenz
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Ändert den Textanimations-Typ des Effekts zu "As One Object"
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // Ändert den Animate-Text-Typ des Effekts zu "By word"
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // Setzt die Verzögerung zwischen Wörtern auf 20% der Effekt-Dauer
    firstEffect.setDelayBetweenTextParts(20f);

    // Schreibt die PPTX-Datei auf die Festplatte
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Wie kann ich sicherstellen, dass Animationen beim Veröffentlichen der Präsentation im Web erhalten bleiben?**

[Export to HTML5](/slides/de/java/export-to-html5/) und aktivieren Sie die [Optionen](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/) für die Animation von [Shapes](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) und [Transitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-). Reines HTML spielt Folienanimationen nicht ab, HTML5 jedoch.

**Wie wirkt sich die Änderung der Z‑Reihenfolge (Layer‑Order) von Formen auf Animationen aus?**

Animation‑ und Zeichenreihenfolge sind unabhängig: Ein Effekt steuert das Timing und den Typ des Erscheinens/Verscheidens, während die [Z‑Order](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getZOrderPosition--) bestimmt, was was überdeckt. Das sichtbare Ergebnis ergibt sich aus deren Kombination. (Dies ist das allgemeine PowerPoint‑Verhalten; das Aspose.Slides‑Modell für Effekte und Formen folgt derselben Logik.)

**Gibt es Einschränkungen beim Konvertieren von Animationen in Video für bestimmte Effekte?**

Im Allgemeinen werden [Animationen unterstützt](/slides/de/java/convert-powerpoint-to-video/), aber seltene Fälle oder spezifische Effekte können unterschiedlich gerendert werden. Es wird empfohlen, die von Ihnen genutzten Effekte und die Bibliotheksversion zu testen.