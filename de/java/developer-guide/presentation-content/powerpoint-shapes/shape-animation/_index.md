---
title: Shape-Animationen in Präsentationen mit Java anwenden
linktitle: Shape-Animation
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
- Effekt-Sound
- Animation anwenden
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: Erfahren Sie, wie Sie Shape-Animationen in PowerPoint-Präsentationen mit Aspose.Slides für Java erstellen und anpassen. Heben Sie sich ab!
---

Animationen sind visuelle Effekte, die auf Texte, Bilder, Formen oder [Diagrammen](https://docs.aspose.com/slides/java/animated-charts/) angewendet werden können. Sie verleihen Präsentationen oder deren Bestandteilen Leben. 

## **Warum Animationen in Präsentationen verwenden?**

Durch den Einsatz von Animationen können Sie  

* den Informationsfluss steuern  
* wichtige Punkte hervorheben  
* das Interesse oder die Beteiligung des Publikums steigern  
* Inhalte leichter les‑ bzw. verständlich machen  
* die Aufmerksamkeit der Leser oder Zuschauer auf wichtige Teile einer Präsentation lenken  

PowerPoint bietet zahlreiche Optionen und Werkzeuge für Animationen und Animationseffekte in den Kategorien **Eingang**, **Ausgang**, **Betonung** und **Bewegungs­pfade**. 

## **Animationen in Aspose.Slides**

* Aspose.Slides stellt die Klassen und Typen bereit, die Sie benötigen, um mit Animationen im Namensraum `Aspose.Slides.Animation` zu arbeiten,  
* Aspose.Slides bietet über **150 Animationseffekte** im [EffectType](https://reference.aspose.com/slides/java/com.aspose.slides/effecttype)-Aufzählung. Diese Effekte entsprechen im Wesentlichen den in PowerPoint verwendeten Effekten (oder sind äquivalent).  

## **Animation auf ein Textfeld anwenden**

Aspose.Slides für Java ermöglicht das Anwenden von Animationen auf den Text in einer Form.  

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).  
2. Rufen Sie eine Folienreferenz über deren Index ab.  
3. Fügen Sie ein `rectangle`‑[IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape) hinzu.  
4. Fügen Sie Text zu [IAutoShape.TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-) hinzu.  
5. Erhalten Sie die Hauptsequenz von Effekten.  
6. Fügen Sie einen Animationseffekt zu [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape) hinzu.  
7. Setzen Sie die Eigenschaft `TextAnimation.BuildType` auf einen Wert aus der Aufzählung `BuildType`.  
8. Schreiben Sie die Präsentation als PPTX-Datei auf die Festplatte.  

Der folgende Java‑Code zeigt, wie man den `Fade`‑Effekt auf ein AutoShape anwendet und die Textanimation auf den Wert *By 1st Level Paragraphs* einstellt:
```java
// Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Fügt eine neue AutoShape mit Text hinzu
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // Erhält die Hauptsequenz der Folie.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // Fügt der Form den Fade-Animationseffekt hinzu
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Animiert den Formtext nach Absätzen der ersten Ebene
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // Speichert die PPTX-Datei auf dem Datenträger
    pres.save(path + "AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{%  alert color="primary"  %}} 

Neben der Anwendung von Animationen auf Text können Sie auch Animationen auf einen einzelnen [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph) anwenden. Siehe [**Animated Text**](/slides/de/java/animated-text/).

{{% /alert %}} 

## **Animation auf ein PictureFrame anwenden**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).  
2. Rufen Sie die Referenz einer Folie über deren Index ab.  
3. Fügen Sie ein [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe) hinzu oder holen Sie es von der Folie.  
4. Holen Sie die Hauptsequenz der Effekte.  
5. Fügen Sie einen Animationseffekt zu [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe) hinzu.  
6. Schreiben Sie die Präsentation als PPTX-Datei auf die Festplatte.  

Der folgende Java‑Code zeigt, wie man den `Fly`‑Effekt auf einen Bildrahmen anwendet:
```java
// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei repräsentiert.
Presentation pres = new Presentation();
try {
    // Lädt ein Bild, das der Bildsammlung der Präsentation hinzugefügt werden soll
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Fügt einen Bildrahmen zur Folie hinzu
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // Ermittelt die Hauptsequenz der Folie.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Fügt dem Bildrahmen den Fly‑von‑links‑Animationseffekt hinzu
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Speichert die PPTX‑Datei auf dem Datenträger
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Animation auf eine Form anwenden**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)-Klasse.  
2. Rufen Sie die Referenz einer Folie über deren Index ab.  
3. Fügen Sie ein `rectangle`‑[IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape) hinzu.  
4. Fügen Sie ein `Bevel`‑[IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape) hinzu (wenn dieses Objekt angeklickt wird, wird die Animation abgespielt).  
5. Erstellen Sie eine Sequenz von Effekten für die Bevel‑Form.  
6. Erstellen Sie einen benutzerdefinierten `UserPath`.  
7. Fügen Sie Befehle zum Bewegen auf den `UserPath` hinzu.  
8. Schreiben Sie die Präsentation als PPTX-Datei auf die Festplatte.  

Der folgende Java‑Code zeigt, wie man den `PathFootball`‑Effekt (Pfad‑Fußball) auf eine Form anwendet:
```java
// Instanziiert eine Presentation-Klasse, die eine PPTX-Datei darstellt.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Erstellt den PathFootball-Effekt für eine vorhandene Form von Grund auf.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // Fügt den PathFootball-Animationseffekt hinzu
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Erstellt eine Art "button".
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

     // Schreibt die PPTX-Datei auf die Festplatte
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Animationseffekte einer Form abrufen**

Die folgenden Beispiele zeigen, wie Sie die Methode `getEffectsByShape` aus der [ISequence](https://reference.aspose.com/slides/java/com.aspose.slides/isequence/)‑Schnittstelle verwenden, um alle auf eine Form angewendeten Animationseffekte abzurufen.

**Beispiel 1: Animationseffekte einer Form auf einer normalen Folie abrufen**

Zuvor haben Sie gelernt, wie man Animationseffekte zu Formen in PowerPoint‑Präsentationen hinzufügt. Der folgende Beispielcode zeigt, wie man die Effekte der ersten Form auf der ersten normalen Folie in der Präsentation `AnimExample_out.pptx` abruft.
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

Wenn eine Form auf einer normalen Folie Platzhalter hat, die sich auf der Layout‑Folie und/oder Master‑Folie befinden, und diesen Platzhaltern Animationseffekte zugewiesen wurden, dann werden alle Effekte der Form während der Bildschirmanzeige abgespielt, einschließlich der von den Platzhaltern geerbten.

Angenommen, wir haben die PowerPoint‑Datei `sample.pptx` mit einer Folie, die nur eine Fußzeilen‑Form mit dem Text „Made with Aspose.Slides“ enthält und auf die der Effekt **Random Bars** angewendet wurde.

![Folienform‑Animationseffekt](slide-shape-animation.png)

Nehmen wir weiter an, dass der Effekt **Split** auf den Fußzeilen‑Platzhalter der **Layout**‑Folie angewendet wird.

![Layout‑Form‑Animationseffekt](layout-shape-animation.png)

Und schließlich ist der Effekt **Fly In** auf den Fußzeilen‑Platzhalter der **Master**‑Folie angewendet.

![Master‑Form‑Animationseffekt](master-shape-animation.png)

Der folgende Beispielcode zeigt, wie man die Methode `getBasePlaceholder` aus der [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/)‑Schnittstelle verwendet, um auf die Platzhalter der Form zuzugreifen und die auf die Fußzeilen‑Form angewendeten Animationseffekte zu erhalten, einschließlich der von Platzhaltern auf Layout‑ und Master‑Folien geerbten.
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


## **Zeitsteuerungseigenschaften von Animationseffekten ändern**

Aspose.Slides für Java ermöglicht das Ändern der Zeitsteuerungseigenschaften eines Animationseffekts.

Dies ist das Animations‑Timing‑Fenster in Microsoft PowerPoint:
![Animations‑Timing‑Fenster](shape-animation.png)

Diese Zuordnungen zwischen PowerPoint‑Timing und [Effect.Timing](https://reference.aspose.com/slides/java/com.aspose.slides/IEffect#getTiming--)‑Eigenschaften gelten:

- Die **Start**‑Dropdown‑Liste der PowerPoint‑Zeitsteuerung entspricht der Eigenschaft [Effect.Timing.TriggerType](https://reference.aspose.com/slides/java/com.aspose.slides/ITiming#getTriggerType--). 
- Die **Duration**‑Zeitsteuerung von PowerPoint entspricht der Eigenschaft [Effect.Timing.Duration](https://reference.aspose.com/slides/java/com.aspose.slides/ITiming#getDuration--). Die Dauer eines Effekts (in Sekunden) ist die Gesamtzeit, die das Ergebnis für einen Durchlauf benötigt. 
- Die **Delay**‑Zeitsteuerung von PowerPoint entspricht der Eigenschaft [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/java/com.aspose.slides/ITiming#getTriggerDelayTime--). 

So ändern Sie die Effect‑Timing‑Eigenschaften:

1. [Anwenden](#apply-animation-to-shape) oder das Animationseffekt abrufen.  
2. Setzen Sie neue Werte für die benötigten [Effect.Timing](https://reference.aspose.com/slides/java/com.aspose.slides/IEffect#getTiming--)‑Eigenschaften.  
3. Speichern Sie die geänderte PPTX‑Datei.  

```java
// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Ermittelt die Hauptsequenz der Folie.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Ermittelt den ersten Effekt der Hauptsequenz.
    IEffect effect = sequence.get_Item(0);

    // Ändert den TriggerType des Effekts auf Klick
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // Ändert die Dauer des Effekts
    effect.getTiming().setDuration(3f);

    // Ändert die TriggerDelayTime des Effekts
    effect.getTiming().setTriggerDelayTime(0.5f);

    // Speichert die PPTX-Datei auf dem Datenträger
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Sound für Animationseffekt**

Aspose.Slides stellt die folgenden Eigenschaften bereit, um mit Sounds in Animationseffekten zu arbeiten: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)  
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/java/com.aspose.slides/effect/#setStopPreviousSound-boolean-) 

### **Sound zu einem Animationseffekt hinzufügen**

Der folgende Java‑Code zeigt, wie man einen Sound zu einem Animationseffekt hinzufügt und ihn stoppt, wenn der nächste Effekt startet:
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

    // Prüft den Effekt auf "No Sound"
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // Fügt dem ersten Effekt Sound hinzu
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


### **Sound aus einem Animationseffekt extrahieren**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .  
2. Rufen Sie die Referenz einer Folie über deren Index ab.  
3. Holen Sie die Hauptsequenz der Effekte.  
4. Extrahieren Sie den in jedem Animationseffekt eingebetteten [setSound(IAudio value)](https://reference.aspose.com/slides/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) .  

Der folgende Java‑Code zeigt, wie man den in einem Animationseffekt eingebetteten Sound extrahiert:
```java
// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ermittelt die Hauptsequenz der Folie.
    ISequence sequence = slide.getTimeline().getMainSequence();

    for (IEffect effect : sequence)
    {
        if (effect.getSound() == null)
            continue;

        // Extrahiert den Effekt-Sound in ein Byte-Array
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Nach Animation**

Aspose.Slides für Java ermöglicht das Ändern der Eigenschaft „After animation“ eines Animationseffekts.

Dies ist das Fenster für Animationseffekte und das erweiterte Menü in Microsoft PowerPoint:
![Animationseffekt‑Fenster](shape-after-animation.png)

- Die Eigenschaft [setAfterAnimationType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAfterAnimationType-int-) beschreibt den Typ der Nachanimation:
  * PowerPoint **More Colors** entspricht dem Typ [AfterAnimationType.Color](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#Color);
  * PowerPoint **Don't Dim** entspricht dem Typ [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#DoNotDim) (Standard‑Nachanimationstyp);
  * PowerPoint **Hide After Animation** entspricht dem Typ [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#HideAfterAnimation);
  * PowerPoint **Hide on Next Mouse Click** entspricht dem Typ [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick);
- Die Eigenschaft [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) definiert ein Farbformat für die Nachanimation. Diese Eigenschaft wird in Verbindung mit dem Typ [AfterAnimationType.Color](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#Color) verwendet. Ändert man den Typ, wird die Nachanimationsfarbe zurückgesetzt.

```java
// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Ermittelt den ersten Effekt der Hauptsequenz
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Ändert den Nachanimations-Typ zu Farbe
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

Aspose.Slides stellt die folgenden Eigenschaften bereit, um mit dem *Animate text*‑Block eines Animationseffekts zu arbeiten: 

- Die Eigenschaft [setAnimateTextType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) beschreibt den Typ der Textanimation des Effekts. Der Text einer Form kann animiert werden:
  * Alles auf einmal ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/java/com.aspose.slides/animatetexttype/#AllAtOnce))
  * Wortweise ([AnimateTextType.ByWord](https://reference.aspose.com/slides/java/com.aspose.slides/animatetexttype/#ByWord))
  * Buchstabenweise ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/java/com.aspose.slides/animatetexttype/#ByLetter))
- Die Eigenschaft [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) legt eine Verzögerung zwischen den animierten Textteilen (Wörter oder Buchstaben) fest. Ein positiver Wert gibt den Prozentsatz der Effektdauer an, ein negativer Wert die Verzögerung in Sekunden.

1. [Anwenden](#apply-animation-to-shape) oder den Animationseffekt holen.  
2. Setzen Sie die Eigenschaft [setBuildType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/itextanimation/#setBuildType-int-) auf den Wert [BuildType.AsOneObject](https://reference.aspose.com/slides/java/com.aspose.slides/buildtype/#AsOneObject), um den Animationsmodus *By Paragraphs* zu deaktivieren.  
3. Setzen Sie neue Werte für die Eigenschaften [setAnimateTextType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) und [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-).  
4. Speichern Sie die geänderte PPTX‑Datei.  

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

    // Setzt die Verzögerung zwischen Wörtern auf 20% der Effektdauer
    firstEffect.setDelayBetweenTextParts(20f);

    // Schreibt die PPTX-Datei auf die Festplatte
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Wie kann ich sicherstellen, dass Animationen beim Veröffentlichen der Präsentation im Web erhalten bleiben?**  

[Export to HTML5](/slides/de/java/export-to-html5/) und aktivieren Sie die [Optionen](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/), die für die Animation von [Formen](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) und [Übergängen](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) verantwortlich sind. Reines HTML spielt Folienanimationen nicht ab, HTML5 jedoch schon.  

**Wie wirkt sich das Ändern der Z‑Reihenfolge (Schichtenreihenfolge) von Formen auf die Animation aus?**  

Animation und Zeichenreihenfolge sind unabhängig: Ein Effekt steuert das Timing und den Typ des Erscheinens/Verscheidens, während die [z-order](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getZOrderPosition--) bestimmt, was was überdeckt. Das sichtbare Ergebnis ergibt sich aus ihrer Kombination. (Dies ist das allgemeine PowerPoint‑Verhalten; das Aspose.Slides‑Modell für Effekte und Formen folgt derselben Logik.)  

**Gibt es Einschränkungen beim Konvertieren von Animationen in Video für bestimmte Effekte?**  

Im Allgemeinen werden [Animationen unterstützt](/slides/de/java/convert-powerpoint-to-video/), doch seltene Fälle oder bestimmte Effekte können anders gerendert werden. Es wird empfohlen, die von Ihnen genutzten Effekte und die Bibliotheksversion zu testen.