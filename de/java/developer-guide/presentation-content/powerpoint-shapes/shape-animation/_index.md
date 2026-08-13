---
title: Shape-Animationen in Präsentationen mit Java anwenden
linktitle: Form-Animation
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
- Effekt Sound
- Animation anwenden
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Entdecken Sie, wie Sie Shape-Animationen in PowerPoint-Präsentationen mit Aspose.Slides für Java erstellen und anpassen. Heben Sie sich ab!"
---
## **Einführung**

Animationen sind visuelle Effekte, die auf Texte, Bilder, Formen oder [Diagramme](https://docs.aspose.com/slides/de/java/animated-charts/) angewendet werden können. Sie verleihen Präsentationen oder deren Bestandteilen Leben. 

## **Warum Animationen in Präsentationen verwenden?**

* den Informationsfluss steuern
* wichtige Punkte hervorheben
* das Interesse oder die Beteiligung des Publikums erhöhen
* Inhalte leichter lesbar, verständlich oder verarbeitbar machen
* die Aufmerksamkeit der Leser oder Zuschauer auf wichtige Teile einer Präsentation lenken

PowerPoint bietet zahlreiche Optionen und Werkzeuge für Animationen und Animationseffekte in den Kategorien **Eintritt**, **Verlassen**, **Betonung** und **Bewegungswege**. 

## **Animationen in Aspose.Slides**

* Aspose.Slides stellt die Klassen und Typen bereit, die Sie benötigen, um mit Animationen im Namensraum `Aspose.Slides.Animation` zu arbeiten,
* Aspose.Slides bietet über **150 Animationseffekte** im [EffectType](https://reference.aspose.com/slides/de/java/com.aspose.slides/effecttype)-Enum. Diese Effekte entsprechen im Wesentlichen den in PowerPoint verwendeten (oder äquivalenten) Effekten.

## **Animation auf ein Textfeld anwenden**

Aspose.Slides für Java ermöglicht es Ihnen, Animationen auf den Text in einer Form anzuwenden. 

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation).
2. Holen Sie sich eine Folienreferenz über deren Index.
3. Fügen Sie eine `rectangle`‑[IAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape) hinzu. 
4. Fügen Sie Text zu [IAutoShape.TextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-) hinzu.
5. Holen Sie die Hauptsequenz der Effekte.
6. Fügen Sie einen Animationseffekt zu [IAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape) hinzu. 
7. Setzen Sie die Eigenschaft `TextAnimation.BuildType` auf den Wert aus der `BuildType`‑Enumeration.
8. Schreiben Sie die Präsentation als PPTX-Datei auf die Festplatte.

Dieser Java‑Code zeigt, wie man den `Fade`‑Effekt auf eine AutoShape anwendet und die Textanimation auf den Wert *By 1st Level Paragraphs* einstellt:

```java
import com.aspose.slides.*;

// Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei repräsentiert.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Fügt ein neues AutoShape mit Text hinzu
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // Holt die Hauptsequenz der Folie.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // Fügt den Fade-Animationseffekt zur Form hinzu
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Animiert den Text der Form nach Absätzen der ersten Ebene
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // Speichert die PPTX-Datei auf der Festplatte
    pres.save("AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="info"  %}} 

Neben der Anwendung von Animationen auf Text können Sie auch Animationen auf ein einzelnes [Paragraph](https://reference.aspose.com/slides/de/java/com.aspose.slides/iparagraph) anwenden. Siehe [**Animated Text**](/slides/de/java/animated-text/).

{{% /alert %}} 

## **Animation auf ein PictureFrame anwenden**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation)‑Klasse.
2. Holen Sie die Referenz einer Folie über deren Index.
3. Fügen Sie ein [PictureFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/pictureframe) hinzu oder holen Sie es.
4. Holen Sie die Hauptsequenz der Effekte.
5. Fügen Sie einen Animationseffekt zu [PictureFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/pictureframe) hinzu.
6. Schreiben Sie die Präsentation als PPTX-Datei auf die Festplatte.

Dieser Java‑Code zeigt, wie man den `Fly`‑Effekt auf einen Bildrahmen anwendet:

```java
import com.aspose.slides.*;

// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei repräsentiert.
Presentation pres = new Presentation();
try {
    // Lädt ein Bild, das zur Bildsammlung der Präsentation hinzugefügt werden soll
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Fügt einen Bildrahmen zur Folie hinzu
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // Holt die Hauptsequenz der Folie.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Fügt dem Bildrahmen den Fly‑von‑links‑Animationseffekt hinzu
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Speichert die PPTX‑Datei auf der Festplatte
    pres.save("AnimImage_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animation auf eine Form anwenden**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation)‑Klasse.
2. Holen Sie die Referenz einer Folie über deren Index.
3. Fügen Sie eine `rectangle`‑[IAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape) hinzu. 
4. Fügen Sie eine `Bevel`‑[IAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape) hinzu (wenn dieses Objekt angeklickt wird, wird die Animation abgespielt).
5. Erstellen Sie eine Sequenz von Effekten für die Bevel‑Form.
6. Erstellen Sie einen benutzerdefinierten `UserPath`.
7. Fügen Sie Befehle zum Bewegen zum `UserPath` hinzu.
8. Schreiben Sie die Präsentation als PPTX-Datei auf die Festplatte.

Dieser Java‑Code zeigt, wie man den `PathFootball`‑Effekt (Pfad‑Fußball) auf eine Form anwendet:

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

// Instanziert eine Presentation-Klasse, die eine PPTX-Datei repräsentiert.
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
    IMotionEffect motionBvh = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBvh.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBvh.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBvh.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

     // Schreibt die PPTX-Datei auf die Festplatte
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Die auf eine Form angewendeten Animationseffekte abrufen**

Die folgenden Beispiele zeigen, wie Sie die Methode `getEffectsByShape` aus dem [ISequence](https://reference.aspose.com/slides/de/java/com.aspose.slides/isequence/)-Interface verwenden, um alle auf eine Form angewendeten Animationseffekte zu erhalten.

**Beispiel 1: Animationseffekte, die auf einer normalen Folie einer Form zugewiesen sind, abrufen**

Zuvor haben Sie gelernt, wie man Animationseffekte zu Formen in PowerPoint‑Präsentationen hinzufügt. Der folgende Beispielcode zeigt, wie man die auf die erste Form der ersten normalen Folie in der Präsentation `AnimExample_out.pptx` angewendeten Effekte abruft.

```java
import com.aspose.slides.*;

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

Hat eine Form auf einer normalen Folie Platzhalter, die sich auf der Layout‑Folie und/oder der Master‑Folie befinden, und wurden diesen Platzhaltern Animationseffekte hinzugefügt, dann werden während der Bildschirmpräsentation alle Effekte der Form abgespielt, einschließlich der von den Platzhaltern geerbten.

Angenommen, wir haben eine PowerPoint‑Datei `sample.pptx` mit einer Folie, die nur eine Fußzeilenform mit dem Text "Made with Aspose.Slides" enthält und auf die der **Random Bars**‑Effekt angewendet wurde.

![Slide shape animation effect](slide-shape-animation.png)

Nehmen wir außerdem an, dass der **Split**‑Effekt auf den Fußzeilen‑Platzhalter der **Layout**‑Folie angewendet wird.

![Layout shape animation effect](layout-shape-animation.png)

Und schließlich ist der **Fly In**‑Effekt auf den Fußzeilen‑Platzhalter der **Master**‑Folie angewendet.

![Master shape animation effect](master-shape-animation.png)

Der folgende Beispielcode zeigt, wie Sie die Methode `getBasePlaceholder` aus dem [IShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/)-Interface verwenden, um auf die Platzhalter der Form zuzugreifen und die auf die Fußzeilenform angewendeten Animationseffekte zu erhalten, einschließlich der von Platzhaltern auf Layout‑ und Master‑Folien geerbten.

```java
import com.aspose.slides.*;

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
for (IEffect[] effects : new IEffect[][] { masterShapeEffects, layoutShapeEffects, shapeEffects }) {
    for (IEffect effect : effects) {
        String typeName = EffectType.getName(EffectType.class, effect.getType());
        String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());

        System.out.println(typeName + " " + subtypeName);
    }
}

presentation.dispose();
```
```java
import com.aspose.slides.*;

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

Aspose.Slides für Java ermöglicht es, die Timing‑Eigenschaften eines Animationseffekts zu ändern.

Dies ist das Animation Timing‑Fenster in Microsoft PowerPoint:

![example1_image](shape-animation.png)

Dies sind die Entsprechungen zwischen PowerPoint Timing und den [Effect.Timing](https://reference.aspose.com/slides/de/java/com.aspose.slides/IEffect#getTiming--)-Eigenschaften:

- Die **Start**‑Auswahlliste von PowerPoint entspricht der Eigenschaft [Effect.Timing.TriggerType](https://reference.aspose.com/slides/de/java/com.aspose.slides/ITiming#getTriggerType--) .
- Die **Duration**‑Angabe von PowerPoint entspricht der Eigenschaft [Effect.Timing.Duration](https://reference.aspose.com/slides/de/java/com.aspose.slides/ITiming#getDuration--) . Die Dauer eines Effekts (in Sekunden) ist die Gesamtzeit, die für einen Durchlauf benötigt wird. 
- Die **Delay**‑Angabe von PowerPoint entspricht der Eigenschaft [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/de/java/com.aspose.slides/ITiming#getTriggerDelayTime--) . 

So ändern Sie die Effect‑Timing‑Eigenschaften:

1. [Anwenden](#apply-animation-to-shape) oder den Animationseffekt abrufen.
2. Setzen Sie neue Werte für die benötigten [Effect.Timing](https://reference.aspose.com/slides/de/java/com.aspose.slides/IEffect#getTiming--)‑Eigenschaften.
3. Speichern Sie die geänderte PPTX‑Datei.

```java
import com.aspose.slides.*;

// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei repräsentiert.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Holt die Hauptsequenz der Folie.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Holt den ersten Effekt der Hauptsequenz.
    IEffect effect = sequence.get_Item(0);

    // Ändert den TriggerType des Effekts, damit er bei einem Klick startet
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // Ändert die Dauer des Effekts
    effect.getTiming().setDuration(3f);

    // Ändert die Triggerverzögerungszeit des Effekts
    effect.getTiming().setTriggerDelayTime(0.5f);

    // Speichert die PPTX-Datei auf der Festplatte
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ton für Animationseffekt**

Aspose.Slides stellt diese Eigenschaften zur Verfügung, um mit Sounds in Animationseffekten zu arbeiten: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/de/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) 
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/de/java/com.aspose.slides/effect/#setStopPreviousSound-boolean-) 

### **Ton zu einem Animationseffekt hinzufügen**

Dieser Java‑Code zeigt, wie man einem Animationseffekt einen Ton hinzufügt und ihn stoppt, wenn der nächste Effekt beginnt:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Fügt Audio zur Audio‑Sammlung der Präsentation hinzu
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Holt die Hauptsequenz der Folie.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Holt den ersten Effekt der Hauptsequenz
    IEffect firstEffect = sequence.get_Item(0);

    // Prüft den Effekt auf "No Sound"
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // Fügt dem ersten Effekt Sound hinzu
        firstEffect.setSound(effectSound);
    }

    // Holt die erste interaktive Sequenz der Folie.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // Setzt das Flag "Stop previous sound" für den Effekt
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // Speichert die PPTX-Datei auf der Festplatte
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Ton aus einem Animationseffekt extrahieren**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)-Klasse.
2. Holen Sie die Referenz einer Folie über deren Index. 
3. Holen Sie die Hauptsequenz der Effekte. 
4. Extrahieren Sie das in jedem Animationseffekt eingebettete [setSound(IAudio value)](https://reference.aspose.com/slides/de/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) .

Dieser Java‑Code zeigt, wie man den in einem Animationseffekt eingebetteten Ton extrahiert:

```java
import com.aspose.slides.*;

// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei repräsentiert.
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Holt die Hauptsequenz der Folie.
    ISequence sequence = slide.getTimeline().getMainSequence();

    for (IEffect effect : sequence)
    {
        if (effect.getSound() == null)
            continue;

        // Extrahiert den Effekt‑Sound als Byte‑Array
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Nach Animation**

Aspose.Slides für Java ermöglicht es, die Eigenschaft „After animation“ eines Animationseffekts zu ändern.

Dies ist das Animation Effect‑Fenster und das erweiterte Menü in Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

Die **After animation**‑Auswahlliste von PowerPoint entspricht diesen Eigenschaften: 

- Die Eigenschaft [setAfterAnimationType(int value)](https://reference.aspose.com/slides/de/java/com.aspose.slides/ieffect/#setAfterAnimationType-int-) beschreibt den Typ nach der Animation:
  * PowerPoint **More Colors** entspricht dem Typ [AfterAnimationType.Color](https://reference.aspose.com/slides/de/java/com.aspose.slides/afteranimationtype/#Color);
  * PowerPoint **Don't Dim** entspricht dem Typ [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/de/java/com.aspose.slides/afteranimationtype/#DoNotDim) (Standard‑Typ);
  * PowerPoint **Hide After Animation** entspricht dem Typ [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/de/java/com.aspose.slides/afteranimationtype/#HideAfterAnimation);
  * PowerPoint **Hide on Next Mouse Click** entspricht dem Typ [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/de/java/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick);
- Die Eigenschaft [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/de/java/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) definiert ein Farbschema nach der Animation. Sie wird in Verbindung mit dem Typ [AfterAnimationType.Color](https://reference.aspose.com/slides/de/java/com.aspose.slides/afteranimationtype/#Color) verwendet. Wird der Typ geändert, wird die Farbe zurückgesetzt.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei repräsentiert
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Holt den ersten Effekt der Hauptsequenz
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Ändert den Nachanimations-Typ zu Color
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // Setzt die Farbe der Nachanimation
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // Schreibt die PPTX-Datei auf die Festplatte
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Text animieren**

Aspose.Slides stellt diese Eigenschaften bereit, um mit dem *Animate text*‑Block eines Animationseffekts zu arbeiten:

- Die Eigenschaft [setAnimateTextType(int value)](https://reference.aspose.com/slides/de/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) beschreibt den Animate‑Text‑Typ des Effekts. Der Text einer Form kann animiert werden:
  - Alles gleichzeitig ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/de/java/com.aspose.slides/animatetexttype/#AllAtOnce)‑Typ)
  - Wortweise ([AnimateTextType.ByWord](https://reference.aspose.com/slides/de/java/com.aspose.slides/animatetexttype/#ByWord)‑Typ)
  - Buchstabenweise ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/de/java/com.aspose.slides/animatetexttype/#ByLetter)‑Typ)
- Die Eigenschaft [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/de/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) legt eine Verzögerung zwischen den animierten Textteilen (Wörtern oder Buchstaben) fest. Ein positiver Wert gibt den Prozentsatz der Effekt­dauer an, ein negativer Wert die Verzögerung in Sekunden.

So können Sie die Eigenschaften des Effect‑Animate‑Text ändern:

1. [Anwenden](#apply-animation-to-shape) oder den Animationseffekt abrufen.
2. Setzen Sie die Eigenschaft [setBuildType(int value)](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextanimation/#setBuildType-int-) auf den Wert [BuildType.AsOneObject](https://reference.aspose.com/slides/de/java/com.aspose.slides/buildtype/#AsOneObject), um den Modus *By Paragraphs* zu deaktivieren.
3. Setzen Sie neue Werte für die Eigenschaften [setAnimateTextType(int value)](https://reference.aspose.com/slides/de/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) und [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/de/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-).
4. Speichern Sie die geänderte PPTX‑Datei.

```java
import com.aspose.slides.*;

// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei repräsentiert.
Presentation pres = new Presentation("AnimText_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Holt den ersten Effekt der Hauptsequenz
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

### Wie kann ich sicherstellen, dass Animationen beim Veröffentlichen der Präsentation im Web erhalten bleiben?

[Export to HTML5](/slides/de/java/export-to-html5/) und aktivieren Sie die [Optionen](https://reference.aspose.com/slides/de/java/com.aspose.slides/html5options/) , die für die Animation von [shape](https://reference.aspose.com/slides/de/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) und [transition](https://reference.aspose.com/slides/de/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) Elementen verantwortlich sind. Reines HTML spielt Folienanimationen nicht ab, HTML5 jedoch schon.

### Wie wirkt sich das Ändern der Z‑Reihenfolge (Layer‑Reihenfolge) von Formen auf Animationen aus?

Animations‑ und Zeichenreihenfolge sind unabhängig: Ein Effekt steuert das Timing und die Art des Erscheinens/Verscheidens, während die [z-order](https://reference.aspose.com/slides/de/java/com.aspose.slides/shape/#getZOrderPosition--) bestimmt, was was überlappt. Das sichtbare Ergebnis ergibt sich aus ihrer Kombination. (Dies ist das allgemeine Verhalten von PowerPoint; das Modell von Aspose.Slides für Effekte und Formen folgt derselben Logik.)

### Gibt es Einschränkungen beim Konvertieren von Animationen in Video für bestimmte Effekte?

Im Allgemeinen werden [Animationen unterstützt](/slides/de/java/convert-powerpoint-to-video/), jedoch können seltene Fälle oder bestimmte Effekte anders gerendert werden. Es wird empfohlen, die von Ihnen verwendeten Effekte und die Bibliotheksversion zu testen.