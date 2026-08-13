---
title: Form-Animationen in Präsentationen auf Android anwenden
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
- Effektsound
- Animation anwenden
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Formanimationen in PowerPoint‑Präsentationen mit Aspose.Slides für Android via Java erstellen und anpassen. Hervorstechen!"
---
## **Einführung**

Animationen sind visuelle Effekte, die auf Texte, Bilder, Formen oder [Diagramme](https://docs.aspose.com/slides/de/androidjava/animated-charts/) angewendet werden können. Sie verleihen Präsentationen oder deren Bestandteilen Leben.

## **Warum Animationen in Präsentationen verwenden?**

* den Informationsfluss steuern
* wichtige Punkte hervorheben
* das Interesse oder die Beteiligung Ihres Publikums erhöhen
* Inhalte leichter lesbar, verständlich oder verarbeitbar machen
* die Aufmerksamkeit Ihrer Leser oder Zuschauer auf wichtige Teile einer Präsentation lenken

PowerPoint bietet viele Optionen und Werkzeuge für Animationen und Animationseffekte in den Kategorien **Eingang**, **Ausgang**, **Betonung** und **Bewegungspfade**.

## **Animationen in Aspose.Slides**

* Aspose.Slides stellt die Klassen und Typen bereit, die Sie benötigen, um mit Animationen im Namensraum `Aspose.Slides.Animation` zu arbeiten,
* Aspose.Slides bietet über **150 Animationseffekte** im Aufzählungstyp [EffectType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/effecttype) an. Diese Effekte entsprechen im Wesentlichen den in PowerPoint verwendeten Effekten (oder sind gleichwertig).

## **Animation auf ein Textfeld anwenden**

Aspose.Slides für Android via Java ermöglicht es Ihnen, Animationen auf den Text in einer Form anzuwenden.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation).
2. Holen Sie sich eine Folienreferenz über deren Index.
3. Fügen Sie eine `rectangle`-[IAutoShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iautoshape) hinzu.
4. Fügen Sie Text zu [IAutoShape.TextFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-) hinzu.
5. Erhalten Sie die Hauptsequenz von Effekten.
6. Fügen Sie einen Animationseffekt zu [IAutoShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iautoshape) hinzu.
7. Setzen Sie die Eigenschaft `TextAnimation.BuildType` auf den Wert aus der Aufzählung `BuildType`.
8. Schreiben Sie die Präsentation als PPTX-Datei auf die Festplatte.

Dieser Java-Code zeigt, wie Sie den `Fade`-Effekt auf AutoShape anwenden und die Textanimation auf den Wert *By 1st Level Paragraphs* setzen:

```java
import com.aspose.slides.*;

// Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei repräsentiert.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Fügt eine neue AutoShape mit Text hinzu
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // Ermittelt die Hauptsequenz der Folie.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // Fügt der Form den Fade-Animationseffekt hinzu
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Animiert den Text der Form nach Absätzen der ersten Ebene
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // Speichert die PPTX-Datei auf dem Datenträger
    pres.save("AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="info"  %}} 

Neben der Anwendung von Animationen auf Text können Sie auch Animationen auf einen einzelnen [Paragraph](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iparagraph) anwenden. Siehe [**Animated Text**](/slides/de/androidjava/animated-text/).

{{% /alert %}} 

## **Animation auf ein PictureFrame anwenden**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation).
2. Holen Sie sich die Referenz einer Folie über deren Index.
3. Fügen Sie ein [PictureFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pictureframe) zur Folie hinzu oder holen Sie es.
4. Erhalten Sie die Hauptsequenz von Effekten.
5. Fügen Sie einen Animationseffekt zu [PictureFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pictureframe) hinzu.
6. Schreiben Sie die Präsentation als PPTX-Datei auf die Festplatte.

Dieser Java-Code zeigt, wie Sie den `Fly`-Effekt auf einen Bildrahmen anwenden:

```java
import com.aspose.slides.*;

// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei repräsentiert.
Presentation pres = new Presentation();
try {
    // Bild laden, das zur Bildsammlung der Präsentation hinzugefügt werden soll
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Bildrahmen zur Folie hinzufügen
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // Holt die Hauptsequenz der Folie.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Fügt dem Bildrahmen den Fly‑from‑Left‑Animationseffekt hinzu
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Speichert die PPTX-Datei auf dem Datenträger
    pres.save("AnimImage_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animation auf eine Form anwenden**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation).
2. Holen Sie sich die Referenz einer Folie über deren Index.
3. Fügen Sie eine `rectangle`-[IAutoShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iautoshape) hinzu.
4. Fügen Sie eine `Bevel`-[IAutoShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iautoshape) hinzu (wenn dieses Objekt angeklickt wird, wird die Animation abgespielt).
5. Erstellen Sie eine Sequenz von Effekten für die Bevel-Form.
6. Erstellen Sie einen benutzerdefinierten `UserPath`.
7. Fügen Sie Befehle zum Bewegen zum `UserPath` hinzu.
8. Schreiben Sie die Präsentation als PPTX-Datei auf die Festplatte.

Dieser Java-Code zeigt, wie Sie den `PathFootball` (path football)-Effekt auf eine Form anwenden:

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

// Instanziert eine Presentation-Klasse, die eine PPTX-Datei darstellt.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Erstellt den PathFootball-Effekt für eine vorhandene Form von Grund auf.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // Fügt den PathFootBall-Animationseffekt hinzu
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Erzeugt eine Art "Button".
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Erstellt eine Sequenz von Effekten für diesen Button.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // Erstellt einen benutzerdefinierten Pfad. Unser Objekt wird erst bewegt, nachdem der Button angeklickt wurde.
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

## **Animationseffekte, die einer Form zugewiesen sind**

Die folgenden Beispiele zeigen, wie Sie die Methode `getEffectsByShape` aus dem Interface [ISequence](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isequence/) verwenden, um alle auf eine Form angewendeten Animationseffekte zu erhalten.

**Beispiel 1: Animationseffekte erhalten, die einer Form auf einer normalen Folie zugewiesen sind**

Zuvor haben Sie gelernt, wie man Animationseffekte zu Formen in PowerPoint‑Präsentationen hinzufügt. Der folgende Beispielcode zeigt, wie Sie die Effekte der ersten Form auf der ersten normalen Folie in der Präsentation `AnimExample_out.pptx` erhalten.

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

**Beispiel 2: Alle Animationseffekte erhalten, einschließlich der von Platzhaltern geerbten**

Wenn eine Form auf einer normalen Folie Platzhalter hat, die sich auf der Layout‑Folge und/oder der Master‑Folge befinden, und diesen Platzhaltern Animationseffekte zugewiesen wurden, dann werden beim Vorführen alle Effekte der Form abgespielt, einschließlich der von den Platzhaltern geerbten.

Angenommen, wir haben eine PowerPoint‑Präsentationsdatei `sample.pptx` mit einer Folie, die nur eine Fußzeilen‑Form mit dem Text „Made with Aspose.Slides“ enthält und auf die der **Random Bars**‑Effekt angewendet wurde.

![Folienform-Animationseffekt](slide-shape-animation.png)

Nehmen wir weiter an, dass auf der **Layout**‑Folge der **Split**‑Effekt auf den Fußzeilen‑Platzhalter angewendet wurde.

![Layout-Form-Animationseffekt](layout-shape-animation.png)

Und schließlich wurde auf der **Master**‑Folge der **Fly In**‑Effekt auf den Fußzeilen‑Platzhalter angewendet.

![Master-Form-Animationseffekt](master-shape-animation.png)

Der folgende Beispielcode zeigt, wie Sie die Methode `getBasePlaceholder` aus dem Interface [IShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/) verwenden, um auf die Platzhalter der Form zuzugreifen und die auf die Fußzeilen‑Form angewendeten Animationseffekte zu erhalten, einschließlich der von Platzhaltern auf Layout‑ und Master‑Folien geerbten.

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

## **Timing-Eigenschaften von Animationseffekten ändern**

Aspose.Slides für Android via Java ermöglicht es Ihnen, die Timing‑Eigenschaften eines Animationseffekts zu ändern.

Dies ist das Fenster „Animation Timing“ in Microsoft PowerPoint:

![example1_image](shape-animation.png)

Diese Entsprechungen zwischen PowerPoint‑Timing und den Eigenschaften von [Effect.Timing](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IEffect#getTiming--) gelten:

- Die Dropdown‑Liste **Start** im PowerPoint‑Timing entspricht der Eigenschaft [Effect.Timing.TriggerType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ITiming#getTriggerType--).
- **Duration** im PowerPoint‑Timing entspricht der Eigenschaft [Effect.Timing.Duration](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ITiming#getDuration--). Die Dauer einer Animation (in Sekunden) ist die Gesamtzeit, die die Animation für einen Durchlauf benötigt.
- **Delay** im PowerPoint‑Timing entspricht der Eigenschaft [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ITiming#getTriggerDelayTime--).

So ändern Sie die Eigenschaften des Effect‑Timing:

1. [Anwenden](#apply-animation-to-shape) oder holen Sie den Animationseffekt.
2. Setzen Sie neue Werte für die benötigten Eigenschaften von [Effect.Timing](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IEffect#getTiming--).
3. Speichern Sie die modifizierte PPTX‑Datei.

Dieser Java-Code demonstriert die Vorgehensweise:

```java
import com.aspose.slides.*;

// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei repräsentiert.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Holt die Hauptsequenz der Folie.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Holt den ersten Effekt der Hauptsequenz.
    IEffect effect = sequence.get_Item(0);

    // Ändert den Effekt TriggerType, sodass er bei Klick startet
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

## **Ton für Animationseffekt**

Aspose.Slides stellt diese Eigenschaften bereit, um mit Tönen in Animationseffekten zu arbeiten:

- [setSound(IAudio value)](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/effect/#setStopPreviousSound-boolean-)

### **Ton zu einem Animationseffekt hinzufügen**

Dieser Java-Code zeigt, wie Sie einem Animationseffekt einen Ton hinzufügen und ihn stoppen, wenn der nächste Effekt startet:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Fügt Audio zur Audiosammlung der Präsentation hinzu
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Holt die Hauptsequenz der Folie.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Holt den ersten Effekt der Hauptsequenz
    IEffect firstEffect = sequence.get_Item(0);

    // Prüft, ob der Effekt keinen Ton hat
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // Fügt dem ersten Effekt einen Ton hinzu
        firstEffect.setSound(effectSound);
    }

    // Holt die erste interaktive Sequenz der Folie.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // Setzt das Flag "Stop previous sound" für den Effekt
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // Schreibt die PPTX-Datei auf die Festplatte
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Ton aus einem Animationseffekt extrahieren**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/).
2. Holen Sie sich die Referenz einer Folie über deren Index.
3. Erhalten Sie die Hauptsequenz von Effekten.
4. Extrahieren Sie den in jedem Animationseffekt eingebetteten [setSound(IAudio value)](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)‑Ton.

Dieser Java-Code zeigt, wie Sie den in einem Animationseffekt eingebetteten Ton extrahieren:

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

        // Extrahiert den Effektton als Byte‑Array
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Nach Animation**

Aspose.Slides für Android via Java ermöglicht es Ihnen, die After‑Animation‑Eigenschaft eines Animationseffekts zu ändern.

Dies ist das Fenster „Animation Effect“ und das erweiterte Menü in Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

Die Dropdown‑Liste **After animation** in PowerPoint entspricht diesen Eigenschaften:

- Die Eigenschaft [setAfterAnimationType(int value)](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ieffect/#setAfterAnimationType-int-) beschreibt den Nach‑Animations‑Typ:
  * **More Colors** entspricht dem Typ [AfterAnimationType.Color](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/afteranimationtype/#Color);
  * **Don't Dim** entspricht dem Typ [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/afteranimationtype/#DoNotDim) (Standard‑Nach‑Animations‑Typ);
  * **Hide After Animation** entspricht dem Typ [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/afteranimationtype/#HideAfterAnimation);
  * **Hide on Next Mouse Click** entspricht dem Typ [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick);
- Die Eigenschaft [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) definiert ein Farbschema für die Nach‑Animation. Diese Eigenschaft funktioniert zusammen mit dem Typ [AfterAnimationType.Color](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/afteranimationtype/#Color). Wird der Typ zu einem anderen geändert, wird die Nach‑Animations‑Farbe zurückgesetzt.

Dieser Java-Code zeigt, wie Sie einen Nach‑Animationseffekt ändern:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei repräsentiert
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Holt den ersten Effekt der Hauptsequenz
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Ändert den After-Animation-Typ zu Color
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // Setzt die Nach-Animations-Dim-Farbe
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // Schreibt die PPTX-Datei auf die Festplatte
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Text animieren**

Aspose.Slides stellt diese Eigenschaften bereit, um mit dem *Animate text*‑Block eines Animationseffekts zu arbeiten:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) beschreibt den Animations‑Typ des Texteffekts. Der Formtext kann animiert werden:
  - Alles gleichzeitig ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/animatetexttype/#AllAtOnce))
  - Wortweise ([AnimateTextType.ByWord](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/animatetexttype/#ByWord))
  - Buchstabenweise ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/animatetexttype/#ByLetter))
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) legt eine Verzögerung zwischen den animierten Textteilen (Wörter oder Buchstaben) fest. Ein positiver Wert gibt den Prozentsatz der Effekt­dauer an, ein negativer Wert die Verzögerung in Sekunden.

So können Sie die Eigenschaften *Effect Animate text* ändern:

1. [Anwenden](#apply-animation-to-shape) oder holen Sie den Animationseffekt.
2. Setzen Sie die Eigenschaft [setBuildType(int value)](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextanimation/#setBuildType-int-) auf den Wert [BuildType.AsOneObject](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/buildtype/#AsOneObject), um den Modus *By Paragraphs* zu deaktivieren.
3. Setzen Sie neue Werte für die Eigenschaften [setAnimateTextType(int value)](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) und [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-).
4. Speichern Sie die modifizierte PPTX‑Datei.

Dieser Java-Code demonstriert die Vorgehensweise:

```java
import com.aspose.slides.*;

// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei repräsentiert.
Presentation pres = new Presentation("AnimText_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Holt den ersten Effekt der Hauptsequenz
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Ändert den Textanimations‑Typ des Effekts zu "As One Object"
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // Ändert den Animate‑Text‑Typ des Effekts zu "By word"
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

### Wie kann ich sicherstellen, dass Animationen beim Veröffentlichen der Präsentation im Web erhalten bleiben?

[Export to HTML5](/slides/de/androidjava/export-to-html5/) und aktivieren Sie die [options](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/html5options/) für die Animation von [shape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) und [transition](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-). Reines HTML spielt Folienanimationen nicht ab, HTML5 hingegen schon.

### Wie wirkt sich das Ändern der Z‑Reihenfolge (Ebenenreihenfolge) von Formen auf die Animation aus?

Animation‑ und Zeichenreihenfolge sind unabhängig: Ein Effekt steuert das Timing und den Typ des Erscheinens/Verschwindens, während die Z‑Reihenfolge bestimmt, was was überdeckt. Das sichtbare Ergebnis ergibt sich aus ihrer Kombination. (Dies ist das generelle PowerPoint‑Verhalten; das Modell von Aspose.Slides für Effekte und Formen folgt derselben Logik.)

### Gibt es Einschränkungen beim Konvertieren von Animationen in Video für bestimmte Effekte?

Grundsätzlich werden [Animationen unterstützt](/slides/de/androidjava/convert-powerpoint-to-video/), aber seltene Fälle oder spezielle Effekte können anders gerendert werden. Es wird empfohlen, die von Ihnen genutzten Effekte und die verwendete Bibliotheksversion zu testen.