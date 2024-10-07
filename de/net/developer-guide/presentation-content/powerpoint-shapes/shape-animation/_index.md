---
title: Formanimation
type: docs
weight: 60
url: /net/shape-animation/
keywords: 
- PowerPoint-Animation
- Animationseffekt
- Animation anwenden
- PowerPoint-Präsentation
- C#
- Csharp
- Aspose.Slides für .NET
description: "PowerPoint-Animation in C# oder .NET anwenden"
---

Animationen sind visuelle Effekte, die auf Texte, Bilder, Formen oder [Diagramme](/slides/net/animated-charts/) angewendet werden können. Sie verleihen Präsentationen oder deren Bestandteilen Leben.

### **Warum Animationen in Präsentationen verwenden?**

Mit Animationen können Sie

* den Fluss von Informationen steuern
* wichtige Punkte betonen
* das Interesse oder die Teilnahme Ihres Publikums erhöhen
* Inhalte leichter lesbar oder verdaubar machen
* die Aufmerksamkeit Ihrer Leser oder Zuschauer auf wichtige Teile einer Präsentation lenken

PowerPoint bietet viele Optionen und Werkzeuge für Animationen und Animationseffekte in den Kategorien **Eingang**, **Ausgang**, **Betonung** und **Bewegungsbahnen**.

### **Animationen in Aspose.Slides**

* Aspose.Slides stellt die Klassen und Typen bereit, die Sie zur Arbeit mit Animationen im [Aspose.Slides.Animation](https://reference.aspose.com/slides/net/aspose.slides.animation/) Namespace benötigen,
* Aspose.Slides bietet über **150 Animationseffekte** unter der [EffectType](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype) Enumeration. Diese Effekte sind im Wesentlichen die gleichen (oder äquivalenten) Effekte, die in PowerPoint verwendet werden.

## **Animation auf Textfeld anwenden**

Aspose.Slides für .NET ermöglicht es Ihnen, Animation auf den Text in einer Form anzuwenden.

1. Erstellen Sie eine Instanz der [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) Klasse.
2. Holen Sie sich eine Referenz auf eine Folie über ihren Index.
3. Fügen Sie eine `rectangle` [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) hinzu. 
4. Fügen Sie Text zu [IAutoShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/textframe) hinzu.
5. Holen Sie sich eine Hauptsequenz von Effekten.
6. Fügen Sie einen Animationseffekt zu [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) hinzu.
7. Setzen Sie die [TextAnimation.BuildType](https://reference.aspose.com/slides/net/aspose.slides.animation/textanimation/properties/buildtype) Eigenschaft auf den Wert aus der [BuildType Enumeration](https://reference.aspose.com/slides/net/aspose.slides.animation/buildtype).
8. Schreiben Sie die Präsentation auf die Festplatte als PPTX-Datei.

Dieser C#-Code zeigt, wie Sie den `Fade`-Effekt auf AutoShape anwenden und die Textanimation auf den Wert *Nach 1. Ebene Absätzen* setzen:

```c#
// Erstellt eine Instanz einer Präsentationsklasse, die eine Präsentationsdatei darstellt.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    
    // Fügt eine neue AutoShape mit Text hinzu
    IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "Erster Absatz \nZweiter Absatz \n Dritter Absatz";

    // Holt die Hauptsequenz der Folie.
    ISequence sequence = sld.Timeline.MainSequence;

    // Fügt den Fade-Animationseffekt zur Form hinzu
    IEffect effect = sequence.AddEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Animiert das Formtext nach 1. Ebene Absätzen
    effect.TextAnimation.BuildType = BuildType.ByLevelParagraphs1;

    // Speichert die PPTX-Datei auf der Festplatte
    pres.Save(path + "AnimTextBox_out.pptx", SaveFormat.Pptx);
}
```

{{%  alert color="primary"  %}} 

Neben der Anwendung von Animationen auf Text können Sie auch Animationen auf einen einzelnen [Absatz](https://reference.aspose.com/slides/net/aspose.slides/iparagraph) anwenden. Siehe [**Animierter Text**](/slides/net/animated-text/).

{{% /alert %}} 

## **Animation auf PictureFrame anwenden**

1. Erstellen Sie eine Instanz der [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) Klasse.
2. Holen Sie sich eine Referenz auf eine Folie über ihren Index.
3. Fügen Sie [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe) auf der Folie hinzu oder rufen Sie sie ab. 
5. Holen Sie sich die Hauptsequenz von Effekten.
6. Fügen Sie einen Animationseffekt zu [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe) hinzu.
8. Schreiben Sie die Präsentation auf die Festplatte als PPTX-Datei.

Dieser C#-Code zeigt, wie Sie den `Fly`-Effekt auf ein Bildrahmen anwenden:

```c#
// Erstellt eine Instanz einer Präsentationsklasse, die eine Präsentationsdatei darstellt.
using (Presentation pres = new Presentation())
{
    // Bild laden, das in die Präsentationsbildsammlung hinzugefügt werden soll
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Bildrahmen zur Folie hinzufügen
    IPictureFrame picFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Holt die Hauptsequenz der Folie.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Fügt den Fly-from-Left-Animationseffekt zum Bildrahmen hinzu
    IEffect effect = sequence.AddEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Speichert die PPTX-Datei auf der Festplatte
    pres.Save("AnimImage_out.pptx", SaveFormat.Pptx);
}
```

## **Animation auf Form anwenden**

1. Erstellen Sie eine Instanz der [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) Klasse.
2. Holen Sie sich eine Referenz auf eine Folie über ihren Index.
3. Fügen Sie eine `rectangle` [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) hinzu. 
4. Fügen Sie eine `Bevel` [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) hinzu (wenn dieses Objekt angeklickt wird, wird die Animation abgespielt).
5. Erstellen Sie eine Sequenz von Effekten an der Bevel-Form.
6. Erstellen Sie einen benutzerdefinierten `UserPath`.
7. Fügen Sie Befehle zum Bewegen zum `UserPath` hinzu.
8. Schreiben Sie die Präsentation auf die Festplatte als PPTX-Datei.

Dieser C#-Code zeigt, wie Sie den `PathFootball` (Pfad Fußball) Effekt auf eine Form anwenden:

```c#
// Erstellt eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // Erstellt den PathFootball-Effekt für die vorhandene Form von Grund auf neu.
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

    ashp.AddTextFrame("Animierter Textfeld");

    // Fügt den PathFootBall-Animationseffekt hinzu.
    pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                           EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Erstellt eine Art "Schaltfläche".
    IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Erstellt eine Sequenz von Effekten für die Schaltfläche.
    ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

    // Erstellt einen benutzerdefinierten Benutzerpfad. Unser Objekt wird nur bewegt, nachdem die Schaltfläche angeklickt wurde.
    IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // Fügt Befehle zum Bewegen hinzu, da der erstellte Pfad leer ist.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.Behaviors[0]);

    PointF[] pts = new PointF[1];
    pts[0] = new PointF(0.076f, 0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new PointF(-0.076f, -0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.Path.Add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

    // Schreibt die PPTX-Datei auf die Festplatte
    pres.Save("AnimExample_out.pptx", SaveFormat.Pptx);
}
```

## **Animationseffekte auf eine Form anwenden**

Sie können entscheiden, alle Animationseffekte zu ermitteln, die auf eine einzelne Form angewendet wurden.

Dieser C#-Code zeigt Ihnen, wie Sie alle auf eine bestimmte Form angewendeten Effekte abrufen:

```c#
// Erstellt eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Holt die Hauptsequenz der Folie.
    ISequence sequence = firstSlide.Timeline.MainSequence;

    // Holt die erste Form auf der Folie.
    IShape shape = firstSlide.Shapes[0];

    // Holt alle Animationseffekte, die auf die Form angewendet wurden.
    IEffect[] shapeEffects = sequence.GetEffectsByShape(shape);

    if (shapeEffects.Length > 0)
        Console.WriteLine("Die Form " + shape.Name + " hat " + shapeEffects.Length + " Animationseffekte.");
}
```

## **Timing-Eigenschaften des Animationseffekts ändern**

Aspose.Slides für .NET ermöglicht es Ihnen, die Timing-Eigenschaften eines Animationseffekts zu ändern.

Dies ist das Animation Timing-Fenster und das erweiterte Menü in Microsoft PowerPoint:

![example1_image](shape-animation.png)

Dies sind die Entsprechungen zwischen PowerPoint-Timing und [Effect.Timing](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/properties/timing) Eigenschaften:
- PowerPoint Timing **Start** Dropdown-Liste entspricht der [Effect.Timing.TriggerType](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/triggertype) Eigenschaft. 
- PowerPoint Timing **Dauer** entspricht der [Effect.Timing.Duration](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/duration) Eigenschaft. Die Dauer einer Animation (in Sekunden) ist die Gesamtzeit, die die Animation benötigt, um einen Zyklus abzuschließen. 
- PowerPoint Timing **Verzögerung** entspricht der [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/triggerdelaytime) Eigenschaft. 
- PowerPoint Timing **Wiederholen** Dropdown-Liste entspricht diesen Eigenschaften: 
  * [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatcount) Eigenschaft, die die *Anzahl* der Wiederholungen des Effekts beschreibt;
  * [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatuntilendslide) Flag, das angibt, ob der Effekt bis zum Ende der Folie wiederholt wird;
  * [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatuntilnextclick) Flag, das angibt, ob der Effekt bis zum nächsten Klick wiederholt wird.
- PowerPoint Timing **Zurückspulen, wenn die Wiedergabe abgeschlossen ist** Checkbox entspricht der [Effect.Timing.Rewind](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/rewind/) Eigenschaft. 

So ändern Sie die Effekt-Timing-Eigenschaften:

1. [Wenden Sie an](#apply-animation-to-shape) oder rufen Sie den Animationseffekt ab.
2. Setzen Sie neue Werte für die [Effect.Timing](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/properties/timing) Eigenschaften, die Sie benötigen. 
3. Speichern Sie die modifizierte PPTX-Datei.

Dieser C#-Code demonstriert den Vorgang:

```c#
// Erstellt eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // Holt die Hauptsequenz der Folie.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Holt den ersten Effekt der Hauptsequenz.
    IEffect effect = sequence[0];

    // Ändert den TriggerType des Effekts, um beim Klicken zu starten
    effect.Timing.TriggerType = EffectTriggerType.OnClick;

    // Ändert die Dauer des Effekts
    effect.Timing.Duration = 3f;

    // Ändert die TriggerDelayTime des Effekts
    effect.Timing.TriggerDelayTime = 0.5f;

    // Wenn der Wert für die Wiederholung des Effekts "Keine" ist
    if (effect.Timing.RepeatCount == 1f)
    {
        // Ändert die Wiederholung des Effekts auf "Bis zum nächsten Klick"
        effect.Timing.RepeatUntilNextClick = true;
    }
    else
    {
        // Ändert die Wiederholung des Effekts auf "Bis zum Ende der Folie"
        effect.Timing.RepeatUntilEndSlide = true;
    }

    // Schaltet das Zurückspulen des Effekts ein
    effect.Timing.Rewind = true;
    
    // Speichert die PPTX-Datei auf der Festplatte
    pres.Save("AnimExample_changed.pptx", SaveFormat.Pptx);
}
```

## **Animations-Effekt-Sound**

Aspose.Slides bietet diese Eigenschaften, um mit Geräuschen in Animationseffekten zu arbeiten: 
- [IEffect.Sound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/sound/) 
- [IEffect.StopPreviousSound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/stopprevioussound/) 

### **Animationseffekt-Sound hinzufügen**

Dieser C#-Code zeigt, wie Sie einen Animations-Effekt-Sound hinzufügen und ihn stoppen, wenn der nächste Effekt beginnt:

```c#
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
	// Fügt Audio zur Präsentationsaudio-Sammlung hinzu
	IAudio effectSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Holt die Hauptsequenz der Folie.
	ISequence sequence = firstSlide.Timeline.MainSequence;

	// Holt den ersten Effekt der Hauptsequenz
	IEffect firstEffect = sequence[0];

	// Überprüft den Effekt auf "Kein Ton"
	if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
	{
		// Fügt den Sound für den ersten Effekt hinzu
		firstEffect.Sound = effectSound;
	}

	// Holt die erste interaktive Sequenz der Folie.
	ISequence interactiveSequence = firstSlide.Timeline.InteractiveSequences[0];

	// Setzt das Flag "Vorherigen Sound stoppen" des Effekts
	interactiveSequence[0].StopPreviousSound = true;

	// Schreibt die PPTX-Datei auf die Festplatte
	pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```

### **Animationseffekt-Sound extrahieren**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse.
2. Holen Sie sich eine Referenz auf eine Folie über ihren Index. 
3. Holen Sie sich die Hauptsequenz von Effekten. 
4. Extrahieren Sie den [Sound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/sound/) embedded in jedem Animationseffekt. 

Dieser C#-Code zeigt, wie Sie den Sound extrahieren, der in einem Animationseffekt eingebettet ist:

```c#
// Erstellt eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
using (Presentation presentation = new Presentation("EffectSound.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Holt die Hauptsequenz der Folie.
    ISequence sequence = slide.Timeline.MainSequence;

    foreach (IEffect effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        // Extrahiert den Effekt-Sound in ein Byte-Array
        byte[] audio = effect.Sound.BinaryData;
    }
}
```

## **Nach Animation**

Aspose.Slides für .NET ermöglicht es Ihnen, die Nach-Animation-Eigenschaft eines Animationseffekts zu ändern.

Dies ist das Animationseffekt-Fenster und das erweiterte Menü in Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

PowerPoint-Effekt **Nach Animation** Dropdown-Liste entspricht diesen Eigenschaften: 

- [IEffect.AfterAnimationType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/afteranimationtype/) Eigenschaft, die den Nach-Animations-Typ beschreibt:
  * PowerPoint **Weitere Farben** entspricht dem [AfterAnimationType.Color](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) Typ;
  * PowerPoint **Nicht dimmen** Listenelement entspricht dem [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) Typ (Standard-Nachanimations-Typ);
  * PowerPoint **Nach Animation ausblenden** Element entspricht dem [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) Typ;
  * PowerPoint **Bei nächstem Mausklick ausblenden** Element entspricht dem [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) Typ;
- [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/afteranimationcolor/) Eigenschaft, die ein Nach-Animations-Farbformat definiert. Diese Eigenschaft funktioniert in Kombination mit dem [AfterAnimationType.Color](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) Typ. Wenn Sie den Typ in einen anderen ändern, wird die NachAnimationsfarbe gelöscht.

Dieser C#-Code zeigt, wie Sie einen Nach-Animations-Effekt ändern:

```c#
// Erstellt eine Präsentationsklasse, die eine Präsentationsdatei darstellt
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Holt den ersten Effekt der Hauptsequenz
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Ändert den Nachanimations-Typ auf Farbe
    firstEffect.AfterAnimationType = AfterAnimationType.Color;

    // Setzt die Nachanimations-Dim-Farbe
    firstEffect.AfterAnimationColor.Color = Color.AliceBlue;

    // Schreibt die PPTX-Datei auf die Festplatte
    pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
}
```

## **Text animieren**

Aspose.Slides bietet diese Eigenschaften, um mit dem *Text animieren*-Block eines Animationseffekts zu arbeiten:

- [IEffect.AnimateTextType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/animatetexttype/) beschreibt einen Animate-Themen-Typ des Effekts. Der Text der Form kann animiert werden:
  - Alle auf einmal ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/) Typ)
  - Nach Wort ([AnimateTextType.ByWord](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/) Typ)
  - Nach Buchstabe ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/) Typ)
- [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/delaybetweentextparts/) setzt eine Verzögerung zwischen den animierten Textteilen (Wörtern oder Buchstaben). Ein positiver Wert gibt den Prozentsatz der Effekt-Dauer an. Ein negativer Wert gibt die Verzögerung in Sekunden an.

So können Sie die Effekt-Textanimationseigenschaften ändern:

1. [Wenden Sie an](#apply-animation-to-shape) oder rufen Sie den Animationseffekt ab.
2. Setzen Sie die [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/net/aspose.slides.animation/itextanimation/buildtype/) Eigenschaft auf den Wert [BuildType.AsOneObject](https://reference.aspose.com/slides/net/aspose.slides.animation/buildtype/), um den *Nach Absätzen* Animationsmodus auszuschalten.
3. Setzen Sie neue Werte für die [IEffect.AnimateTextType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/animatetexttype/) und [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/delaybetweentextparts/) Eigenschaften.
4. Speichern Sie die modifizierte PPTX-Datei.

Dieser C#-Code demonstriert den Vorgang:

```c#
// Erstellt eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
using (Presentation pres = new Presentation("AnimTextBox_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Holt den ersten Effekt der Hauptsequenz
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Ändert den Effekt-Textanimationstyp auf "Als ein Objekt"
    firstEffect.TextAnimation.BuildType = BuildType.AsOneObject;

    // Ändert den Effekt-Textanimierungstyp auf "Nach Wort"
    firstEffect.AnimateTextType = AnimateTextType.ByWord;

    // Setzt die Verzögerung zwischen Wörtern auf 20% der Effekt-Dauer
    firstEffect.DelayBetweenTextParts = 20f;

    // Schreibt die PPTX-Datei auf die Festplatte
    pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
}
```