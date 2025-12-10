---
title: Shape-Animationen in Präsentationen in .NET anwenden
linktitle: Shape-Animation
type: docs
weight: 60
url: /de/net/shape-animation/
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
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Shape-Animationen in PowerPoint-Präsentationen mit Aspose.Slides für .NET erstellen und anpassen. Heben Sie sich ab!"
---

Animationen sind visuelle Effekte, die auf Texte, Bilder, Formen oder [Diagramme](/slides/de/net/animated-charts/) angewendet werden können. Sie verleihen Präsentationen oder deren Bestandteilen Leben. 

## **Warum Animationen in Präsentationen verwenden?**

Mit Animationen können Sie 

* den Informationsfluss steuern
* wichtige Punkte hervorheben
* das Interesse oder die Beteiligung Ihres Publikums steigern
* Inhalte leichter lesbar, verdaulich oder verarbeitbar machen
* die Aufmerksamkeit Ihrer Leser oder Zuschauer auf wichtige Teile einer Präsentation lenken

PowerPoint bietet zahlreiche Optionen und Werkzeuge für Animationen und Animationseffekte in den Kategorien **Eingang**, **Ausgang**, **Betonung** und **Bewegungspfade**. 

## **Animationen in Aspose.Slides**

* Aspose.Slides stellt die Klassen und Typen bereit, die Sie benötigen, um unter dem Namespace [Aspose.Slides.Animation](https://reference.aspose.com/slides/net/aspose.slides.animation/) mit Animationen zu arbeiten,
* Aspose.Slides bietet über **150 Animationseffekte** im Aufzählungstyp [EffectType](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype) an. Diese Effekte entsprechen im Wesentlichen den in PowerPoint verwendeten (oder gleichwertigen) Effekten.

## **Animation auf ein Textfeld anwenden**

Aspose.Slides für .NET ermöglicht es Ihnen, Animationen auf den Text in einer Form anzuwenden. 

1. Erstellen Sie eine Instanz der [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/)‑Klasse.
2. Holen Sie sich über den Index eine Referenz auf eine Folie.
3. Fügen Sie ein `rectangle` [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) hinzu. 
4. Fügen Sie Text zu [IAutoShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/textframe) hinzu.
5. Holen Sie die Hauptsequenz der Effekte.
6. Fügen Sie einen Animationseffekt zu [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) hinzu.
7. Setzen Sie die Eigenschaft [TextAnimation.BuildType](https://reference.aspose.com/slides/net/aspose.slides.animation/textanimation/properties/buildtype) auf den Wert aus der [BuildType Enumeration](https://reference.aspose.com/slides/net/aspose.slides.animation/buildtype).
8. Schreiben Sie die Präsentation als PPTX‑Datei auf die Festplatte.

Dieser C#‑Code zeigt, wie Sie den `Fade`‑Effekt auf AutoShape anwenden und die Textanimation auf den Wert *By 1st Level Paragraphs* setzen:
```c#
// Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei repräsentiert.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    
    // Fügt ein neues AutoShape mit Text hinzu
    IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "First paragraph \nSecond paragraph \n Third paragraph";

    // Ruft die Hauptsequenz der Folie ab.
    ISequence sequence = sld.Timeline.MainSequence;

    // Fügt dem Shape den Fade-Animationseffekt hinzu
    IEffect effect = sequence.AddEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Animiert den Shape-Text anhand von Absätzen der 1. Ebene
    effect.TextAnimation.BuildType = BuildType.ByLevelParagraphs1;

    // Speichert die PPTX-Datei auf der Festplatte
    pres.Save(path + "AnimTextBox_out.pptx", SaveFormat.Pptx);
}
```


{{%  alert color="primary"  %}} 

Neben der Anwendung von Animationen auf Text können Sie auch Animationen auf einen einzelnen [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph) anwenden. Siehe [**Animated Text**](/slides/de/net/animated-text/).

{{% /alert %}} 

## **Animation auf einen PictureFrame anwenden**

1. Erstellen Sie eine Instanz der [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/)‑Klasse.
2. Holen Sie sich über den Index eine Referenz auf eine Folie.
3. Fügen Sie einen [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe) hinzu oder holen Sie ihn von der Folie. 
5. Holen Sie die Hauptsequenz der Effekte.
6. Fügen Sie einen Animationseffekt zu [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe) hinzu.
8. Schreiben Sie die Präsentation als PPTX‑Datei auf die Festplatte.

Dieser C#‑Code zeigt, wie Sie den `Fly`‑Effekt auf einen Bildrahmen anwenden:
```c#
// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
using (Presentation pres = new Presentation())
{
    // Bild laden, das zur Bildsammlung der Präsentation hinzugefügt wird
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Fügt der Folie einen Bildrahmen hinzu
    IPictureFrame picFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Ruft die Hauptsequenz der Folie ab.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Fügt dem Bildrahmen den Fly‑von‑links‑Animations‑Effekt hinzu
    IEffect effect = sequence.AddEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Speichert die PPTX‑Datei auf der Festplatte
    pres.Save("AnimImage_out.pptx", SaveFormat.Pptx);
}
```


## **Animation auf eine Form anwenden**

1. Erstellen Sie eine Instanz der [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/)‑Klasse.
2. Holen Sie sich über den Index eine Referenz auf eine Folie.
3. Fügen Sie ein `rectangle` [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) hinzu. 
4. Fügen Sie ein `Bevel`‑[IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) hinzu (wenn dieses Objekt angeklickt wird, wird die Animation abgespielt).
5. Erstellen Sie eine Sequenz von Effekten für die Bevel‑Form.
6. Erstellen Sie einen benutzerdefinierten `UserPath`.
7. Fügen Sie Befehle zum Bewegen zu dem `UserPath` hinzu.
8. Schreiben Sie die Präsentation als PPTX‑Datei auf die Festplatte.

Dieser C#‑Code zeigt, wie Sie den `PathFootball`‑Effekt (Pfad‑Football) auf eine Form anwenden:
```c#
// Instanziert eine Presentation‑Klasse, die eine Präsentationsdatei darstellt.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // Erstellt den PathFootball‑Effekt für eine vorhandene Form von Grund auf.
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

    ashp.AddTextFrame("Animated TextBox");

    // Fügt den PathFootball‑Animationseffekt hinzu.
    pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                           EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Erstellt eine Art "Button".
    IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Erstellt eine Sequenz von Effekten für den Button.
    ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

    // Erstellt einen benutzerdefinierten Pfad. Unser Objekt wird erst bewegt, nachdem der Button geklickt wurde.
    IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // Fügt Befehle zum Bewegen hinzu, da der erstellte Pfad leer ist.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.Behaviors[0]);

    PointF[] pts = new PointF[1];
    pts[0] = new PointF(0.076f, 0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new PointF(-0.076f, -0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.Path.Add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

    // Schreibt die PPTX‑Datei auf die Festplatte
    pres.Save("AnimExample_out.pptx", SaveFormat.Pptx);
}
```


## **Animationseffekte, die auf eine Form angewendet wurden, abrufen**

Die folgenden Beispiele zeigen, wie Sie die Methode `GetEffectsByShape` aus dem Interface [ISequence](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence/) verwenden, um alle auf eine Form angewendeten Animationseffekte zu erhalten.

**Beispiel 1: Animationseffekte, die auf eine Form auf einer normalen Folie angewendet wurden, abrufen**

Zuvor haben Sie gelernt, wie Sie Animationseffekte zu Formen in PowerPoint‑Präsentationen hinzufügen. Der folgende Beispielcode zeigt, wie Sie die Effekte abrufen, die auf die erste Form der ersten normalen Folie in der Präsentation `AnimExample_out.pptx` angewendet wurden.
```c#
using (Presentation presentation = new Presentation("AnimExample_out.pptx"))
{
    ISlide firstSlide = presentation.Slides[0];

    // Ruft die Hauptanimationssequenz der Folie ab.
    ISequence sequence = firstSlide.Timeline.MainSequence;

    // Ruft die erste Form auf der ersten Folie ab.
    IShape shape = firstSlide.Shapes[0];

    // Ruft die auf die Form angewendeten Animationseffekte ab.
    IEffect[] shapeEffects = sequence.GetEffectsByShape(shape);

    if (shapeEffects.Length > 0)
        Console.WriteLine($"The shape {shape.Name} has {shapeEffects.Length} animation effects.");
}
```


**Beispiel 2: Alle Animationseffekte, einschließlich der von Platzhaltern geerbten, abrufen**

Hat eine Form auf einer normalen Folie Platzhalter, die auf der Layout‑ oder Master‑Folie liegen, und wurden diesen Platzhaltern Animationseffekte hinzugefügt, dann werden alle Effekte der Form während der Bildschirmanzeige abgespielt, einschließlich der von den Platzhaltern geerbten.

Angenommen, wir haben die PowerPoint‑Datei `sample.pptx` mit einer Folie, die nur eine Fußzeilenform mit dem Text „Made with Aspose.Slides“ enthält und auf die der Effekt **Random Bars** angewendet wurde.

![Slide shape animation effect](slide-shape-animation.png)

Nehmen wir weiter an, dass der Effekt **Split** auf den Fußzeilen‑Platzhalter der **Layout**‑Folie angewendet wurde.

![Layout shape animation effect](layout-shape-animation.png)

Und schließlich wurde der Effekt **Fly In** auf den Fußzeilen‑Platzhalter der **Master**‑Folie angewendet.

![Master shape animation effect](master-shape-animation.png)

Der folgende Beispielcode zeigt, wie Sie die Methode `GetBasePlaceholder` aus dem Interface [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) verwenden, um auf die Form‑Platzhalter zuzugreifen und die auf die Fußzeilenform angewendeten Animationseffekte abzurufen, einschließlich der von Platzhaltern auf Layout‑ und Master‑Folien geerbten.
```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Erhalte die Animationseffekte der Form auf der normalen Folie.
    IShape shape = slide.Shapes[0];
    IEffect[] shapeEffects = slide.Timeline.MainSequence.GetEffectsByShape(shape);

    // Erhalte die Animationseffekte des Platzhalters auf der Layoutfolie.
    IShape layoutShape = shape.GetBasePlaceholder();
    IEffect[] layoutShapeEffects = slide.LayoutSlide.Timeline.MainSequence.GetEffectsByShape(layoutShape);

    // Erhalte die Animationseffekte des Platzhalters auf der Masterfolie.
    IShape masterShape = layoutShape.GetBasePlaceholder();
    IEffect[] masterShapeEffects = slide.LayoutSlide.MasterSlide.Timeline.MainSequence.GetEffectsByShape(masterShape);

    Console.WriteLine("Main sequence of shape effects:");
    PrintEffects(masterShapeEffects);
    PrintEffects(layoutShapeEffects);
    PrintEffects(shapeEffects);
}
```

```cs
static void PrintEffects(IEnumerable<IEffect> effects)
{
    foreach (IEffect effect in effects)
    {
        Console.WriteLine($"{effect.Type} {effect.Subtype}");
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


## **Timing‑Eigenschaften von Animationseffekten ändern**

Aspose.Slides für .NET ermöglicht es Ihnen, die Timing‑Eigenschaften eines Animationseffekts zu ändern.

Dies ist das Animations‑Timing‑Fenster und das erweiterte Menü in Microsoft PowerPoint:

![example1_image](shape-animation.png)

Dies sind die Entsprechungen zwischen PowerPoint‑Timing und den Eigenschaften von [Effect.Timing](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/properties/timing):
- Das Dropdown‑Feld **Start** von PowerPoint entspricht der Eigenschaft [Effect.Timing.TriggerType](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/triggertype). 
- **Duration** entspricht der Eigenschaft [Effect.Timing.Duration](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/duration). Die Dauer einer Animation (in Sekunden) ist die gesamte Zeit, die die Animation für einen Durchlauf benötigt. 
- **Delay** entspricht der Eigenschaft [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/triggerdelaytime). 
- Das Dropdown‑Feld **Repeat** entspricht diesen Eigenschaften: 
  * [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatcount) – beschreibt die *Anzahl* der Wiederholungen des Effekts;
  * [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatuntilendslide) – gibt an, ob der Effekt bis zum Ende der Folie wiederholt wird;
  * [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatuntilnextclick) – gibt an, ob der Effekt bis zum nächsten Klick wiederholt wird.
- Das Kontrollkästchen **Rewind when done playing** entspricht der Eigenschaft [Effect.Timing.Rewind](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/rewind/). 

So ändern Sie die Timing‑Eigenschaften eines Effekts:

1. [Apply](#apply-animation-to-shape) oder holen Sie den Animationseffekt.
2. Setzen Sie neue Werte für die gewünschten [Effect.Timing](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/properties/timing)‑Eigenschaften. 
3. Speichern Sie die geänderte PPTX‑Datei.

Dieser C#‑Code demonstriert die Vorgehensweise:
```c#
// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // Ruft die Hauptsequenz der Folie ab.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Ruft den ersten Effekt der Hauptsequenz ab.
    IEffect effect = sequence[0];

    // Ändert den TriggerType des Effekts auf Klickstart
    effect.Timing.TriggerType = EffectTriggerType.OnClick;

    // Ändert die Dauer des Effekts
    effect.Timing.Duration = 3f;

    // Ändert die Triggerverzögerungszeit des Effekts
    effect.Timing.TriggerDelayTime = 0.5f;

    // Wenn der Wiederholungswert des Effekts "keine" ist
    if (effect.Timing.RepeatCount == 1f)
    {
        // Ändert die Wiederholung des Effekts zu "Bis zum nächsten Klick"
        effect.Timing.RepeatUntilNextClick = true;
    }
    else
    {
        // Ändert die Wiederholung des Effekts zu "Bis zum Ende der Folie"
        effect.Timing.RepeatUntilEndSlide = true;
    }

    // Schaltet das Zurückspulen des Effekts ein
        effect.Timing.Rewind = true;
    
    // Speichert die PPTX-Datei auf der Festplatte
    pres.Save("AnimExample_changed.pptx", SaveFormat.Pptx);
}
```


## **Ton eines Animationseffekts**

Aspose.Slides stellt diese Eigenschaften bereit, um mit Tönen in Animationseffekten zu arbeiten: 
- [IEffect.Sound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/sound/) 
- [IEffect.StopPreviousSound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/stopprevioussound/) 

### **Einen Ton zu einem Animationseffekt hinzufügen**

Dieser C#‑Code zeigt, wie Sie einem Animationseffekt einen Ton hinzufügen und diesen stoppen, wenn der nächste Effekt startet:
```c#
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
	// Fügt Audio zur Audiosammlung der Präsentation hinzu
	IAudio effectSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Ruft die Hauptsequenz der Folie ab.
	ISequence sequence = firstSlide.Timeline.MainSequence;

	// Ruft den ersten Effekt der Hauptsequenz ab
	IEffect firstEffect = sequence[0];

	// Prüft den Effekt auf „Kein Ton“
	if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
	{
		// Fügt dem ersten Effekt einen Ton hinzu
		firstEffect.Sound = effectSound;
	}

	// Ruft die erste interaktive Sequenz der Folie ab.
	ISequence interactiveSequence = firstSlide.Timeline.InteractiveSequences[0];

	// Setzt das Flag „Stop previous sound“ des Effekts
	interactiveSequence[0].StopPreviousSound = true;

	// Schreibt die PPTX-Datei auf die Festplatte
	pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```


### **Einen Ton aus einem Animationseffekt extrahieren**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Klasse.
2. Holen Sie sich über den Index eine Referenz auf eine Folie. 
3. Holen Sie die Hauptsequenz der Effekte. 
4. Extrahieren Sie den zu jedem Animationseffekt eingebetteten [Sound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/sound/). 

Dieser C#‑Code zeigt, wie Sie den in einem Animationseffekt eingebetteten Ton extrahieren:
```c#
// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
using (Presentation presentation = new Presentation("EffectSound.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Ruft die Hauptsequenz der Folie ab.
    ISequence sequence = slide.Timeline.MainSequence;

    foreach (IEffect effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        // Extrahiert den Effektton in ein Byte-Array
        byte[] audio = effect.Sound.BinaryData;
    }
}
```


## **After Animation**

Aspose.Slides für .NET ermöglicht es Ihnen, die After‑Animation‑Eigenschaft eines Animationseffekts zu ändern.

Dies ist das After‑Animation‑Fenster und das erweiterte Menü in Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

Das Dropdown‑Feld **After animation** von PowerPoint entspricht diesen Eigenschaften: 

- Die Eigenschaft [IEffect.AfterAnimationType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/afteranimationtype/) beschreibt den Typ der After‑Animation:
  * **More Colors** entspricht dem Typ [AfterAnimationType.Color](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/);
  * **Don't Dim** entspricht dem Typ [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) (Standard‑After‑Animation‑Typ);
  * **Hide After Animation** entspricht dem Typ [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/);
  * **Hide on Next Mouse Click** entspricht dem Typ [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/);
- Die Eigenschaft [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/afteranimationcolor/) definiert ein Farbformat für die After‑Animation. Diese Eigenschaft wird zusammen mit dem Typ [AfterAnimationType.Color](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) verwendet. Ändern Sie den Typ, wird die After‑Animation‑Farbe zurückgesetzt.

Dieser C#‑Code zeigt, wie Sie einen After‑Animation‑Effekt ändern:
```c#
 // Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
 using (Presentation pres = new Presentation("AnimImage_out.pptx"))
 {
     ISlide firstSlide = pres.Slides[0];

     // Ruft den ersten Effekt der Hauptsequenz ab
     IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

     // Ändert den After-Animation-Typ zu Farbe
     firstEffect.AfterAnimationType = AfterAnimationType.Color;

     // Legt die Dim-Farbe der After-Animation fest
     firstEffect.AfterAnimationColor.Color = Color.AliceBlue;

     // Schreibt die PPTX-Datei auf die Festplatte
     pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
 }
```


## **Text animieren**

Aspose.Slides stellt diese Eigenschaften bereit, um den *Animate text*‑Block eines Animationseffekts zu bearbeiten:

- [IEffect.AnimateTextType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/animatetexttype/) beschreibt den Animations‑Text‑Typ des Effekts. Der Text einer Form kann folgendermaßen animiert werden:
  - Alles auf einmal ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/)‑Typ)
  - Wortweise ([AnimateTextType.ByWord](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/)‑Typ)
  - Buchstabenweise ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/)‑Typ)
- [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/delaybetweentextparts/) legt eine Verzögerung zwischen den animierten Textteilen (Wörtern oder Buchstaben) fest. Ein positiver Wert gibt den Prozentsatz der Effekt­dauer an; ein negativer Wert gibt die Verzögerung in Sekunden an.

So ändern Sie die Eigenschaften des Effect‑Animate‑Text:

1. [Apply](#apply-animation-to-shape) oder holen Sie den Animationseffekt.
2. Setzen Sie die Eigenschaft [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/net/aspose.slides.animation/itextanimation/buildtype/) auf den Wert [BuildType.AsOneObject](https://reference.aspose.com/slides/net/aspose.slides.animation/buildtype/), um den Animationsmodus *By Paragraphs* zu deaktivieren.
3. Setzen Sie neue Werte für die Eigenschaften [IEffect.AnimateTextType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/animatetexttype/) und [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/delaybetweentextparts/).
4. Speichern Sie die geänderte PPTX‑Datei.

Dieser C#‑Code demonstriert die Vorgehensweise:
```c#
// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
using (Presentation pres = new Presentation("AnimTextBox_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Ruft den ersten Effekt der Hauptsequenz ab
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Ändert den Textanimationstyp des Effekts zu "As One Object"
    firstEffect.TextAnimation.BuildType = BuildType.AsOneObject;

    // Ändert den Animate-Text-Typ des Effekts zu "By word"
    firstEffect.AnimateTextType = AnimateTextType.ByWord;

    // Setzt die Verzögerung zwischen Wörtern auf 20% der Effekt-Dauer
    firstEffect.DelayBetweenTextParts = 20f;

    // Schreibt die PPTX-Datei auf die Festplatte
    pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Wie kann ich sicherstellen, dass Animationen beim Veröffentlichen der Präsentation im Web erhalten bleiben?**

[Export to HTML5](/slides/de/net/export-to-html5/) und aktivieren Sie die [options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/), die für die Animationen von [shape](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) und [transition](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) verantwortlich sind. Reines HTML spielt Folienanimationen nicht ab, HTML5 jedoch schon.

**Wie wirkt sich das Ändern der Z‑Reihenfolge (Layer‑Reihenfolge) von Formen auf Animationen aus?**

Animation und Zeichenreihenfolge sind unabhängig: Ein Effekt steuert das Timing und den Typ des Erscheinens/Vergehens, während die [z-order](https://reference.aspose.com/slides/net/aspose.slides/shape/zorderposition/) bestimmt, was was überdeckt. Das sichtbare Ergebnis ergibt sich aus ihrer Kombination. (Dies ist das allgemeine Verhalten von PowerPoint; das Aspose.Slides‑Modell für Effekte‑und‑Formen folgt derselben Logik.)

**Gibt es Einschränkungen beim Konvertieren von Animationen in Video für bestimmte Effekte?**

Im Allgemeinen werden [Animationen unterstützt](/slides/de/net/convert-powerpoint-to-video/), aber seltene Fälle oder bestimmte Effekte können anders gerendert werden. Es wird empfohlen, die von Ihnen genutzten Effekte und die verwendete Bibliotheksversion zu testen.