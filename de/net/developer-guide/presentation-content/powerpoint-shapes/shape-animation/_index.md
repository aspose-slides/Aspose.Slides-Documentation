---
title: Formanimationen in Präsentationen in .NET anwenden
linktitle: Formanimation
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
- Effekt Sound
- Animation anwenden
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Entdecken Sie, wie Sie Formanimationen in PowerPoint-Präsentationen mit Aspose.Slides für .NET erstellen und anpassen. Heben Sie sich ab!"
---

Animationen sind visuelle Effekte, die auf Texte, Bilder, Formen oder [Diagramme](/slides/de/net/animated-charts/) angewendet werden können. Sie verleihen Präsentationen oder deren Bestandteilen Leben. 

## **Warum Animationen in Präsentationen verwenden?**

* den Fluss von Informationen steuern
* wichtige Punkte hervorheben
* das Interesse oder die Beteiligung Ihres Publikums steigern
* Inhalte leichter lesbar, verständlich oder verarbeitbar machen
* die Aufmerksamkeit Ihrer Leser oder Zuschauer auf wichtige Teile einer Präsentation lenken

PowerPoint bietet zahlreiche Optionen und Werkzeuge für Animationen und Animationseffekte in den Kategorien **Eingang**, **Ausgang**, **Betonung** und **Bewegungspfade**. 

## **Animationen in Aspose.Slides**

* Aspose.Slides stellt die Klassen und Typen bereit, die Sie benötigen, um mit Animationen im Namespace [Aspose.Slides.Animation](https://reference.aspose.com/slides/net/aspose.slides.animation/) zu arbeiten,
* Aspose.Slides bietet über **150 Animationseffekte** im Aufzählungstyp [EffectType](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype). Diese Effekte entsprechen im Wesentlichen den in PowerPoint verwendeten Effekten. 

## **Animation auf TextBox anwenden**

Aspose.Slides für .NET ermöglicht es Ihnen, Animationen auf den Text in einer Form anzuwenden. 

1. Erstellen Sie eine Instanz der Klasse [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) .
2. Rufen Sie die Referenz einer Folie über ihren Index ab.
3. Fügen Sie ein `rectangle` [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) hinzu.
4. Fügen Sie Text zu [IAutoShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/textframe) hinzu.
5. Holen Sie die Hauptsequenz von Effekten.
6. Fügen Sie einen Animationseffekt zu [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) hinzu.
7. Setzen Sie die Eigenschaft [TextAnimation.BuildType](https://reference.aspose.com/slides/net/aspose.slides.animation/textanimation/properties/buildtype) auf den Wert aus der [BuildType Enumeration](https://reference.aspose.com/slides/net/aspose.slides.animation/buildtype) .
8. Schreiben Sie die Präsentation als PPTX-Datei auf die Festplatte.

Dieser C#‑Code zeigt, wie man den `Fade`‑Effekt auf AutoShape anwendet und die Textanimation auf den Wert *By 1st Level Paragraphs* setzt:
```c#
// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    
    // Fügt eine neue AutoShape mit Text hinzu
    IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "First paragraph \nSecond paragraph \n Third paragraph";

    // Ermittelt die Hauptsequenz der Folie.
    ISequence sequence = sld.Timeline.MainSequence;

    // Fügt der Form einen Fade-Animationseffekt hinzu
    IEffect effect = sequence.AddEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Animiert den Text der Form nach Absätzen der ersten Ebene
    effect.TextAnimation.BuildType = BuildType.ByLevelParagraphs1;

    // Speichert die PPTX-Datei auf die Festplatte
    pres.Save(path + "AnimTextBox_out.pptx", SaveFormat.Pptx);
}
```


{{%  alert color="primary"  %}} 

Zusätzlich zur Anwendung von Animationen auf Text können Sie Animationen auch auf einen einzelnen [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph) anwenden. Siehe [**Animated Text**](/slides/de/net/animated-text/).

{{% /alert %}} 

## **Animation auf PictureFrame anwenden**

1. Erstellen Sie eine Instanz der Klasse [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) .
2. Rufen Sie die Referenz einer Folie über ihren Index ab.
3. Fügen Sie ein [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe) hinzu oder rufen Sie ein bestehendes auf der Folie ab. 
5. Holen Sie die Hauptsequenz von Effekten. 
6. Fügen Sie einen Animationseffekt zu [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe) hinzu. 
8. Schreiben Sie die Präsentation als PPTX-Datei auf die Festplatte.

Dieser C#‑Code zeigt, wie man den `Fly`‑Effekt auf ein Bildrahmen anwendet:
```c#
// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
using (Presentation pres = new Presentation())
{
    // Bild laden, das in die Bildsammlung der Präsentation eingefügt wird
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Fügt einen Bildrahmen zur Folie hinzu
    IPictureFrame picFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Ermittelt die Hauptsequenz der Folie.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Fügt dem Bildrahmen den Fly-from-Left-Animationseffekt hinzu
    IEffect effect = sequence.AddEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Speichert die PPTX-Datei auf die Festplatte
    pres.Save("AnimImage_out.pptx", SaveFormat.Pptx);
}
```


## **Animation auf Shape anwenden**

1. Erstellen Sie eine Instanz der Klasse [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) .
2. Rufen Sie die Referenz einer Folie über ihren Index ab.
3. Fügen Sie ein `rectangle` [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) hinzu. 
4. Fügen Sie ein `Bevel` [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) hinzu (wenn dieses Objekt angeklickt wird, wird die Animation abgespielt). 
5. Erstellen Sie eine Sequenz von Effekten für die Bevel‑Form. 
6. Erstellen Sie einen benutzerdefinierten `UserPath`. 
7. Fügen Sie Befehle zum Bewegen zum `UserPath` hinzu. 
8. Schreiben Sie die Präsentation als PPTX-Datei auf die Festplatte.

Dieser C#‑Code zeigt, wie man den `PathFootball`‑Effekt (Pfad‑Fußball) auf eine Form anwendet:
```c#
// Instanziert eine Presentation-Klasse, die eine Präsentationsdatei darstellt.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // Erstellt den PathFootball-Effekt für die vorhandene Form von Grund auf.
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

    ashp.AddTextFrame("Animated TextBox");

    // Fügt den PathFootball-Animationseffekt hinzu.
    pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                           EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Erstellt eine Art "Button".
    IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Erstellt eine Sequenz von Effekten für den Button.
    ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

    // Erstellt einen benutzerdefinierten Pfad. Unser Objekt wird erst bewegt, wenn der Button geklickt wird.
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


## **Animationseffekte für Shape abrufen**

Die folgenden Beispiele zeigen, wie man die Methode `GetEffectsByShape` aus dem Interface [ISequence](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence/) verwendet, um alle auf eine Form angewendeten Animationseffekte zu erhalten.

**Beispiel 1: Animationseffekte abrufen, die auf eine Form auf einer normalen Folie angewendet wurden**

Zuvor haben Sie gelernt, wie man Animationseffekte zu Formen in PowerPoint‑Präsentationen hinzufügt. Der folgende Beispielcode zeigt, wie man die auf die erste Form der ersten normalen Folie in der Präsentation `AnimExample_out.pptx` angewendeten Effekte abruft.
```c#
using (Presentation presentation = new Presentation("AnimExample_out.pptx"))
{
    ISlide firstSlide = presentation.Slides[0];

    // Ermittelt die Hauptanimationssequenz der Folie.
    ISequence sequence = firstSlide.Timeline.MainSequence;

    // Ermittelt die erste Form der ersten Folie.
    IShape shape = firstSlide.Shapes[0];

    // Ermittelt die auf die Form angewendeten Animationseffekte.
    IEffect[] shapeEffects = sequence.GetEffectsByShape(shape);

    if (shapeEffects.Length > 0)
        Console.WriteLine($"The shape {shape.Name} has {shapeEffects.Length} animation effects.");
}
```


**Beispiel 2: Alle Animationseffekte abrufen, einschließlich der von Platzhaltern geerbten**

Hat eine Form auf einer normalen Folie Platzhalter, die sich auf der Layout‑Folie und/oder der Master‑Folie befinden, und wurden diesen Platzhaltern Animationseffekte hinzugefügt, dann werden alle Effekte der Form während der Bildschirmpräsentation abgespielt, einschließlich der von den Platzhaltern geerbten.

Angenommen, wir haben eine PowerPoint‑Präsentationsdatei `sample.pptx` mit einer Folie, die nur eine Fußzeilen‑Form mit dem Text „Made with Aspose.Slides“ enthält und auf die der Effekt **Random Bars** angewendet wurde.

![Folienformen-Animationseffekt](slide-shape-animation.png)

Angenommen, der Effekt **Split** wurde auf den Fußzeilen‑Platzhalter der **Layout**‑Folie angewendet.

![Layout‑Form‑Animationseffekt](layout-shape-animation.png)

Und schließlich wurde der Effekt **Fly In** auf den Fußzeilen‑Platzhalter der **Master**‑Folie angewendet.

![Master‑Form‑Animationseffekt](master-shape-animation.png)

Der folgende Beispielcode zeigt, wie man die Methode `GetBasePlaceholder` aus dem Interface [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) verwendet, um auf die Platzhalter der Form zuzugreifen und die auf die Fußzeilen‑Form angewendeten Animationseffekte zu erhalten, einschließlich der von Platzhaltern auf Layout‑ und Master‑Folien geerbten.
```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Animationseffekte der Form auf der normalen Folie abrufen.
    IShape shape = slide.Shapes[0];
    IEffect[] shapeEffects = slide.Timeline.MainSequence.GetEffectsByShape(shape);

    // Animationseffekte des Platzhalters auf der Layout-Folie abrufen.
    IShape layoutShape = shape.GetBasePlaceholder();
    IEffect[] layoutShapeEffects = slide.LayoutSlide.Timeline.MainSequence.GetEffectsByShape(layoutShape);

    // Animationseffekte des Platzhalters auf der Master-Folie abrufen.
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


Output:
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```


## **Timing‑Eigenschaften von Animationseffekten ändern**

Aspose.Slides für .NET ermöglicht es Ihnen, die Timing‑Eigenschaften eines Animationseffekts zu ändern.

Dies ist das „Animation Timing“-Fenster und das erweiterte Menü in Microsoft PowerPoint:

![Beispiel1_Bild](shape-animation.png)

Dies sind die Entsprechungen zwischen PowerPoint‑Timing und den Eigenschaften von [Effect.Timing](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/properties/timing):

- Die Dropdown‑Liste **Start** im PowerPoint‑Timing entspricht der Eigenschaft [Effect.Timing.TriggerType](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/triggertype) .
- PowerPoint‑Timing **Duration** entspricht der Eigenschaft [Effect.Timing.Duration](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/duration) . Die Dauer einer Animation (in Sekunden) ist die Gesamtzeit, die die Animation für einen Durchlauf benötigt. 
- PowerPoint‑Timing **Delay** entspricht der Eigenschaft [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/triggerdelaytime) .
- PowerPoint‑Timing **Repeat** Dropdown‑Liste entspricht diesen Eigenschaften:
  * Die Eigenschaft [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatcount) beschreibt die *Anzahl* der Wiederholungen des Effekts;
  * Das Flag [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatuntilendslide) gibt an, ob der Effekt bis zum Ende der Folie wiederholt wird;
  * Das Flag [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatuntilnextclick) gibt an, ob der Effekt bis zum nächsten Klick wiederholt wird.
- Das Kontrollkästchen **Rewind when done playing** im PowerPoint‑Timing entspricht der Eigenschaft [Effect.Timing.Rewind](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/rewind/) .

So ändern Sie die Eigenschaften des Effect Timing:

1. [Wenden Sie die Animation an](#apply-animation-to-shape) oder holen Sie den Animationseffekt.
2. Setzen Sie neue Werte für die benötigten [Effect.Timing](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/properties/timing) Eigenschaften.
3. Speichern Sie die geänderte PPTX‑Datei.

Dieser C#‑Code demonstriert die Vorgehensweise:
```c#
// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // Ermittelt die Hauptsequenz der Folie.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Ermittelt den ersten Effekt der Hauptsequenz.
    IEffect effect = sequence[0];

    // Ändert den TriggerType des Effekts, sodass er bei Klick startet
    effect.Timing.TriggerType = EffectTriggerType.OnClick;

    // Ändert die Dauer des Effekts
    effect.Timing.Duration = 3f;

    // Ändert die Triggerverzögerungszeit des Effekts
    effect.Timing.TriggerDelayTime = 0.5f;

    // Wenn der Wiederholungswert des Effekts "none" ist
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

    // Aktiviert das Zurückspulen des Effekts
        effect.Timing.Rewind = true;
    
    // Speichert die PPTX-Datei auf die Festplatte
    pres.Save("AnimExample_changed.pptx", SaveFormat.Pptx);
}
```


## **Animationseffekt‑Sound**

Aspose.Slides bietet diese Eigenschaften, um mit Sounds in Animationseffekten zu arbeiten: 
- [IEffect.Sound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/sound/) 
- [IEffect.StopPreviousSound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/stopprevioussound/) 

### **Animationseffekt‑Sound hinzufügen**

Dieser C#‑Code zeigt, wie man einen Sound zu einem Animationseffekt hinzufügt und ihn stoppt, wenn der nächste Effekt startet:
```c#
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
	// Fügt Audio zur Audio‑Sammlung der Präsentation hinzu
	IAudio effectSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Ermittelt die Hauptsequenz der Folie.
	ISequence sequence = firstSlide.Timeline.MainSequence;

	// Ermittelt den ersten Effekt der Hauptsequenz
	IEffect firstEffect = sequence[0];

	// Prüft, ob der Effekt keinen Sound hat
	if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
	{
		// Fügt dem ersten Effekt einen Sound hinzu
		firstEffect.Sound = effectSound;
	}

	// Ermittelt die erste interaktive Sequenz der Folie.
	ISequence interactiveSequence = firstSlide.Timeline.InteractiveSequences[0];

	// Setzt das Flag "Stop previous sound" für den Effekt
	interactiveSequence[0].StopPreviousSound = true;

	// Speichert die PPTX-Datei auf die Festplatte
	pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```


### **Animationseffekt‑Sound extrahieren**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Rufen Sie die Referenz einer Folie über ihren Index ab. 
3. Holen Sie die Hauptsequenz von Effekten. 
4. Extrahieren Sie den in jedem Animationseffekt eingebetteten [Sound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/sound/) .

Dieser C#‑Code zeigt, wie man den in einem Animationseffekt eingebetteten Sound extrahiert:
```c#
// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
using (Presentation presentation = new Presentation("EffectSound.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Ermittelt die Hauptsequenz der Folie.
    ISequence sequence = slide.Timeline.MainSequence;

    foreach (IEffect effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        // Extrahiert den Sound des Effekts in ein Byte-Array
        byte[] audio = effect.Sound.BinaryData;
    }
}
```


## **After Animation**

Aspose.Slides für .NET ermöglicht es Ihnen, die After‑Animation‑Eigenschaft eines Animationseffekts zu ändern.

Dies ist das „Animation Effect“-Fenster und das erweiterte Menü in Microsoft PowerPoint:

![Beispiel1_Bild](shape-after-animation.png)

Die Dropdown‑Liste **After animation** des PowerPoint‑Effekts entspricht diesen Eigenschaften:

- Die Eigenschaft [IEffect.AfterAnimationType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/afteranimationtype/) beschreibt den Typ der After‑Animation:
  * PowerPoint **More Colors** entspricht dem Typ [AfterAnimationType.Color](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) ;
  * PowerPoint **Don't Dim** entspricht dem Typ [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) (Standard‑After‑Animation‑Typ) ;
  * PowerPoint **Hide After Animation** entspricht dem Typ [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) ;
  * PowerPoint **Hide on Next Mouse Click** entspricht dem Typ [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) ;
- Die Eigenschaft [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/afteranimationcolor/) definiert ein Farbschema für die After‑Animation. Diese Eigenschaft arbeitet zusammen mit dem Typ [AfterAnimationType.Color](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/). Wenn Sie den Typ ändern, wird die After‑Animation‑Farbe gelöscht.

Dieser C#‑Code zeigt, wie man einen After‑Animation‑Effekt ändert:
```c#
// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei repräsentiert
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Ermittelt den ersten Effekt der Hauptsequenz
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Ändert den AfterAnimationType auf Color
    firstEffect.AfterAnimationType = AfterAnimationType.Color;

    // Setzt die AfterAnimationColor auf die Dim‑Farbe
    firstEffect.AfterAnimationColor.Color = Color.AliceBlue;

    // Schreibt die PPTX-Datei auf die Festplatte
    pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
}
```


## **Animate Text**

Aspose.Slides bietet diese Eigenschaften, um mit dem *Animate text*‑Block eines Animationseffekts zu arbeiten:

- Die Eigenschaft [IEffect.AnimateTextType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/animatetexttype/) beschreibt den Animations‑Text‑Typ eines Effekts. Der Text einer Form kann animiert werden:
  - Alles auf einmal ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/) Typ)
  - Wortweise ([AnimateTextType.ByWord](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/) Typ)
  - Buchstabenweise ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/) Typ)
- Die Eigenschaft [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/delaybetweentextparts/) legt eine Verzögerung zwischen den animierten Textteilen (Wörtern oder Buchstaben) fest. Ein positiver Wert gibt den Prozentsatz der Effektdauer an. Ein negativer Wert gibt die Verzögerung in Sekunden an.

So können Sie die Eigenschaften des Effect Animate text ändern:

1. [Wenden Sie die Animation an](#apply-animation-to-shape) oder holen Sie den Animationseffekt.
2. Setzen Sie die Eigenschaft [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/net/aspose.slides.animation/itextanimation/buildtype/) auf den Wert [BuildType.AsOneObject](https://reference.aspose.com/slides/net/aspose.slides.animation/buildtype/) , um den Animationsmodus *By Paragraphs* zu deaktivieren.
3. Setzen Sie neue Werte für die Eigenschaften [IEffect.AnimateTextType] und [IEffect.DelayBetweenTextParts] .
4. Speichern Sie die geänderte PPTX‑Datei.

Dieser C#‑Code demonstriert die Vorgehensweise:
```c#
// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
using (Presentation pres = new Presentation("AnimTextBox_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Ermittelt den ersten Effekt der Hauptsequenz
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Ändert den Textanimations-Typ des Effekts auf "As One Object"
    firstEffect.TextAnimation.BuildType = BuildType.AsOneObject;

    // Ändert den Animations-Text-Typ des Effekts zu "By word"
    firstEffect.AnimateTextType = AnimateTextType.ByWord;

    // Setzt die Verzögerung zwischen Wörtern auf 20% der Effektdauer
    firstEffect.DelayBetweenTextParts = 20f;

    // Schreibt die PPTX-Datei auf die Festplatte
    pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Wie kann ich sicherstellen, dass Animationen erhalten bleiben, wenn die Präsentation im Web veröffentlicht wird?**

[Export to HTML5](/slides/de/net/export-to-html5/) und aktivieren Sie die [Optionen](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/) für [shape](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) und [transition](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) Animationen. Reines HTML spielt Folienanimationen nicht ab, HTML5 jedoch.

**Wie wirkt sich das Ändern der Z‑Reihenfolge (Schichtreihenfolge) von Formen auf die Animation aus?**

Animation und Zeichenreihenfolge sind unabhängig: Ein Effekt steuert das Timing und den Typ des Erscheinens/Verschwindens, während die [z-order](https://reference.aspose.com/slides/net/aspose.slides/shape/zorderposition/) bestimmt, was was überdeckt. Das sichtbare Ergebnis ergibt sich aus ihrer Kombination. (Dies ist das allgemeine PowerPoint‑Verhalten; das Aspose.Slides‑Effekte‑und‑Formen‑Modell folgt derselben Logik.)

**Gibt es Einschränkungen beim Konvertieren von Animationen in Video für bestimmte Effekte?**

Im Allgemeinen werden [Animationen unterstützt](/slides/de/net/convert-powerpoint-to-video/), aber in seltenen Fällen oder bei bestimmten Effekten kann die Darstellung abweichen. Es wird empfohlen, die von Ihnen genutzten Effekte und die Bibliotheksversion zu testen.