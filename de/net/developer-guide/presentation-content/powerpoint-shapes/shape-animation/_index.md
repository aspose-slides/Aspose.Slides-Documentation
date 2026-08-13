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
- Effekt‑Sound
- Animation anwenden
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Entdecken Sie, wie Sie Formanimationen in PowerPoint-Präsentationen mit Aspose.Slides für .NET erstellen und anpassen. Heben Sie sich ab!"
---
## **Einführung**

Animationen sind visuelle Effekte, die auf Texte, Bilder, Formen oder [Diagramme](/slides/de/net/animated-charts/) angewendet werden können. Sie verleihen Präsentationen oder deren Bestandteilen Leben. 

## **Warum Animationen in Präsentationen verwenden?**

* den Fluss der Informationen steuern
* wichtige Punkte hervorheben
* Interesse oder Beteiligung Ihres Publikums erhöhen
* Inhalte leichter lesbar, erfassbar oder verarbeitbar machen
* die Aufmerksamkeit Ihrer Leser oder Zuschauer auf wichtige Teile einer Präsentation lenken

PowerPoint bietet zahlreiche Optionen und Werkzeuge für Animationen und Animationseffekte in den Kategorien **Eingang**, **Ausgang**, **Hervorhebung** und **Bewegungsabläufe**. 

## **Animationen in Aspose.Slides**

* Aspose.Slides stellt die Klassen und Typen bereit, die Sie benötigen, um mit Animationen im Namensraum [Aspose.Slides.Animation](https://reference.aspose.com/slides/de/net/aspose.slides.animation/) zu arbeiten,  
* Aspose.Slides stellt über **150 Animationseffekte** im Aufzählungstyp [EffectType](https://reference.aspose.com/slides/de/net/aspose.slides.animation/effecttype) bereit. Diese Effekte entsprechen im Wesentlichen den in PowerPoint verwendeten (oder gleichwertigen) Effekten.  

## **Animation auf ein Textfeld anwenden**

Aspose.Slides für .NET ermöglicht es Ihnen, einer Form Textanimationen zuzuweisen. 

1. Erstellen Sie eine Instanz der Klasse [Presentation](http://www.aspose.com/api/net/slides/de/aspose.slides/) .  
2. Holen Sie die Referenz einer Folie über ihren Index.  
3. Fügen Sie eine `rectangle` [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape) hinzu.  
4. Fügen Sie dem [IAutoShape.TextFrame](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/properties/textframe) Text hinzu.  
5. Rufen Sie die Hauptsequenz der Effekte ab.  
6. Fügen Sie dem [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape) einen Animationseffekt hinzu.  
7. Setzen Sie die Eigenschaft [TextAnimation.BuildType](https://reference.aspose.com/slides/de/net/aspose.slides.animation/textanimation/properties/buildtype) auf den Wert aus der [BuildType Enumeration](https://reference.aspose.com/slides/de/net/aspose.slides.animation/buildtype).  
8. Schreiben Sie die Präsentation als PPTX-Datei auf die Festplatte.  

Dieser C#‑Code zeigt, wie Sie den `Fade`‑Effekt auf ein AutoShape anwenden und die Textanimation auf den Wert *By 1st Level Paragraphs* setzen:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei repräsentiert.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // Fügt ein neues AutoShape mit Text hinzu
    IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    // Fügt drei Absätze hinzu, damit der Absatz‑aufbau etwas zum Durchlaufen hat.
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "First paragraph";
    textFrame.Paragraphs.Add(new Paragraph { Text = "Second paragraph" });
    textFrame.Paragraphs.Add(new Paragraph { Text = "Third paragraph" });

    // Ermittelt die Hauptsequenz der Folie.
    ISequence sequence = sld.Timeline.MainSequence;

    // Fügt dem Shape den Fade‑Animationseffekt hinzu
    IEffect effect = sequence.AddEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Animiert den Text des Shapes nach Absätzen der ersten Ebene
    effect.TextAnimation.BuildType = BuildType.ByLevelParagraphs1;

    // Speichert die PPTX-Datei auf dem Datenträger
    pres.Save("AnimTextBox_out.pptx", SaveFormat.Pptx);
}
```

{{%  alert color="info"  %}} 

Zusätzlich zum Anwenden von Animationen auf Text können Sie Animationen auch auf ein einzelnes [Paragraph](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraph) anwenden. Siehe [**Animated Text**](/slides/de/net/animated-text/).

{{% /alert %}} 

## **Animation auf einen Bildrahmen anwenden**

1. Erstellen Sie eine Instanz der Klasse [Presentation](http://www.aspose.com/api/net/slides/de/aspose.slides/) .  
2. Holen Sie die Referenz einer Folie über ihren Index.  
3. Fügen Sie dem Folie ein [PictureFrame](https://reference.aspose.com/slides/de/net/aspose.slides/ipictureframe) hinzu oder holen Sie es.  
5. Rufen Sie die Hauptsequenz der Effekte ab.  
6. Fügen Sie dem [PictureFrame](https://reference.aspose.com/slides/de/net/aspose.slides/ipictureframe) einen Animationseffekt hinzu.  
8. Schreiben Sie die Präsentation als PPTX-Datei auf die Festplatte.  

Dieser C#‑Code zeigt, wie Sie den `Fly`‑Effekt auf einen Bildrahmen anwenden:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei repräsentiert.
using (Presentation pres = new Presentation())
{
    // Bild laden, das zur Bildsammlung der Präsentation hinzugefügt werden soll
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Fügt der Folie einen Bildrahmen hinzu
    IPictureFrame picFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Ermittelt die Hauptsequenz der Folie.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Fügt dem Bildrahmen den Fly‑von‑links‑Animationseffekt hinzu
    IEffect effect = sequence.AddEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Speichert die PPTX-Datei auf dem Datenträger
    pres.Save("AnimImage_out.pptx", SaveFormat.Pptx);
}
```

## **Animation auf eine Form anwenden**

1. Erstellen Sie eine Instanz der Klasse [Presentation](http://www.aspose.com/api/net/slides/de/aspose.slides/) .  
2. Holen Sie die Referenz einer Folie über ihren Index.  
3. Fügen Sie eine `rectangle` [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape) hinzu.  
4. Fügen Sie eine `Bevel` [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape) hinzu (wenn dieses Objekt angeklickt wird, wird die Animation abgespielt).  
5. Erstellen Sie eine Sequenz von Effekten für die Bevel‑Form.  
6. Erstellen Sie einen benutzerdefinierten `UserPath`.  
7. Fügen Sie Befehle zum Bewegen zum `UserPath` hinzu.  
8. Schreiben Sie die Präsentation als PPTX-Datei auf die Festplatte.  

Dieser C#‑Code zeigt, wie Sie den `PathFootball` (path football)‑Effekt auf eine Form anwenden:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Instanziert eine Presentation-Klasse, die eine Präsentationsdatei repräsentiert.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // Erstellt den PathFootball‑Effekt für die vorhandene Form von Grund auf.
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

    ashp.AddTextFrame("Animated TextBox");

    // Fügt den PathFootball‑Animationseffekt hinzu.
    pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                           EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Erstellt eine Art „Button“.
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

    // Schreibt die PPTX-Datei auf die Festplatte
    pres.Save("AnimExample_out.pptx", SaveFormat.Pptx);
}
```

## **Animationseffekte, die auf eine Form angewendet wurden, abrufen**

Die folgenden Beispiele zeigen, wie Sie die Methode `GetEffectsByShape` aus der Schnittstelle [ISequence](https://reference.aspose.com/slides/de/net/aspose.slides.animation/isequence/) verwenden, um alle auf eine Form angewendeten Animationseffekte zu erhalten.

**Beispiel 1: Animationseffekte, die auf eine Form auf einer normalen Folie angewendet wurden, abrufen**

Zuvor haben Sie gelernt, wie man Animationseffekte zu Formen in PowerPoint‑Präsentationen hinzufügt. Der folgende Beispielcode zeigt, wie Sie die auf die erste Form der ersten normalen Folie in der Präsentation `AnimExample_out.pptx` angewendeten Effekte abrufen.

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation("AnimExample_out.pptx"))
{
    ISlide firstSlide = presentation.Slides[0];

    // Ermittelt die Hauptanimationssequenz der Folie.
    ISequence sequence = firstSlide.Timeline.MainSequence;

    // Ermittelt die erste Form auf der ersten Folie.
    IShape shape = firstSlide.Shapes[0];

    // Ermittelt die auf die Form angewendeten Animationseffekte.
    IEffect[] shapeEffects = sequence.GetEffectsByShape(shape);

    if (shapeEffects.Length > 0)
        Console.WriteLine($"The shape {shape.Name} has {shapeEffects.Length} animation effects.");
}
```

**Beispiel 2: Alle Animationseffekte, einschließlich der von Platzhaltern geerbten, abrufen**

Hat eine Form auf einer normalen Folie Platzhalter, die sich auf der Layout‑Folie und/oder der Master‑Folie befinden, und wurden diesen Platzhaltern Animationseffekte hinzugefügt, dann werden alle Effekte der Form während der Bildschirmpräsentation abgespielt, einschließlich der von den Platzhaltern geerbten.

Angenommen, wir haben eine PowerPoint‑Präsentationsdatei `sample.pptx` mit einer Folie, die nur eine Fußzeilenform mit dem Text "Made with Aspose.Slides" enthält, und auf die Form ist der Effekt **Random Bars** angewendet.

![Folienform‑Animations‑Effekt](slide-shape-animation.png)

Nehmen wir außerdem an, dass auf dem **Layout**‑Folie‑Fußzeilenplatzhalter der Effekt **Split** angewendet wird.

![Layout‑Form‑Animations‑Effekt](layout-shape-animation.png)

Und schließlich ist auf dem **Master**‑Folie‑Fußzeilenplatzhalter der Effekt **Fly In** angewendet.

![Master‑Form‑Animations‑Effekt](master-shape-animation.png)

Der folgende Beispielcode zeigt, wie Sie die Methode `GetBasePlaceholder` aus der Schnittstelle [IShape](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/) verwenden, um auf die Form‑Platzhalter zuzugreifen und die auf die Fußzeilenform angewendeten Animationseffekte zu erhalten, einschließlich der von Platzhaltern auf Layout‑ und Master‑Folien geerbten.

```cs
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Animationseffekte der Form auf der normalen Folie ermitteln.
    IShape shape = slide.Shapes[0];
    IEffect[] shapeEffects = slide.Timeline.MainSequence.GetEffectsByShape(shape);

    // Animationseffekte des Platzhalters auf der Layout-Folien ermitteln.
    IShape layoutShape = shape.GetBasePlaceholder();
    IEffect[] layoutShapeEffects = slide.LayoutSlide.Timeline.MainSequence.GetEffectsByShape(layoutShape);

    // Animationseffekte des Platzhalters auf der Master-Folien ermitteln.
    IShape masterShape = layoutShape.GetBasePlaceholder();
    IEffect[] masterShapeEffects = slide.LayoutSlide.MasterSlide.Timeline.MainSequence.GetEffectsByShape(masterShape);

    Console.WriteLine("Main sequence of shape effects:");
    PrintEffects(masterShapeEffects);
    PrintEffects(layoutShapeEffects);
    PrintEffects(shapeEffects);
}

static void PrintEffects(IEnumerable<IEffect> effects)
{
    foreach (IEffect effect in effects)
    {
        Console.WriteLine($"{effect.Type} {effect.Subtype}");
    }
}
```
```cs
using Aspose.Slides.Animation;

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

Dies ist das Bedienfeld „Animation Timing“ und das erweiterte Menü in Microsoft PowerPoint:

![Beispiel für das Animation‑Timing‑Paneel](shape-animation.png)

Die Dropdown‑Liste **Start** in PowerPoint Timing entspricht der Eigenschaft [Effect.Timing.TriggerType](https://reference.aspose.com/slides/de/net/aspose.slides.animation/itiming/properties/triggertype).  
PowerPoint Timing **Duration** entspricht der Eigenschaft [Effect.Timing.Duration](https://reference.aspose.com/slides/de/net/aspose.slides.animation/itiming/properties/duration). Die Dauer einer Animation (in Sekunden) ist die Gesamtzeit, die die Animation für einen Durchlauf benötigt.  
PowerPoint Timing **Delay** entspricht der Eigenschaft [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/de/net/aspose.slides.animation/itiming/properties/triggerdelaytime).  
PowerPoint Timing **Repeat** Dropdown‑Liste entspricht diesen Eigenschaften:
  * Die Eigenschaft [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/de/net/aspose.slides.animation/itiming/repeatcount) beschreibt die *Anzahl* der Wiederholungen des Effekts;
  * Die Kennzeichnung [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/de/net/aspose.slides.animation/itiming/repeatuntilendslide) gibt an, ob der Effekt bis zum Ende der Folie wiederholt wird;
  * Die Kennzeichnung [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/de/net/aspose.slides.animation/itiming/repeatuntilnextclick) gibt an, ob der Effekt bis zum nächsten Klick wiederholt wird.
PowerPoint Timing **Rewind when done playing** Kontrollkästchen entspricht der Eigenschaft [Effect.Timing.Rewind](https://reference.aspose.com/slides/de/net/aspose.slides.animation/itiming/rewind/). 

So ändern Sie die Timing‑Eigenschaften des Effekts:

1. [Anwenden](#apply-animation-to-shape) oder Abrufen des Animationseffekts.  
2. Setzen Sie neue Werte für die benötigten [Effect.Timing](https://reference.aspose.com/slides/de/net/aspose.slides.animation/effect/properties/timing)‑Eigenschaften.  
3. Speichern Sie die geänderte PPTX‑Datei.  

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei repräsentiert.
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // Ermittelt die Hauptsequenz der Folie.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Ermittelt den ersten Effekt der Hauptsequenz.
    IEffect effect = sequence[0];

    // Ändert den TriggerType des Effekts, damit er bei Klick startet
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
    
    // Speichert die PPTX-Datei auf dem Datenträger
    pres.Save("AnimExample_changed.pptx", SaveFormat.Pptx);
}
```

## **Sound für Animationseffekte**

Aspose.Slides stellt folgende Eigenschaften zur Verfügung, um mit Sounds in Animationseffekten zu arbeiten: 
- [IEffect.Sound](https://reference.aspose.com/slides/de/net/aspose.slides.animation/effect/sound/) 
- [IEffect.StopPreviousSound](https://reference.aspose.com/slides/de/net/aspose.slides.animation/effect/stopprevioussound/) 

### **Sound zu einem Animationseffekt hinzufügen**

Dieser C#‑Code zeigt, wie Sie einem Animationseffekt einen Sound hinzufügen und ihn stoppen, wenn der nächste Effekt beginnt:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
	// Fügt Audio zur Audiosammlung der Präsentation hinzu
	IAudio effectSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Ermittelt die Hauptsequenz der Folie.
	ISequence sequence = firstSlide.Timeline.MainSequence;

	// Ermittelt den ersten Effekt der Hauptsequenz
	IEffect firstEffect = sequence[0];

	// Prüft den Effekt auf "No Sound"
	if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
	{
		// Fügt den ersten Effekt einen Sound hinzu
		firstEffect.Sound = effectSound;
	}

	// Ermittelt die erste interaktive Sequenz der Folie.
	ISequence interactiveSequence = firstSlide.Timeline.InteractiveSequences[0];

	// Setzt das Flag "Stop previous sound" des Effekts
	interactiveSequence[0].StopPreviousSound = true;

	// Schreibt die PPTX-Datei auf die Festplatte
	pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```

### **Sound aus einem Animationseffekt extrahieren**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/).  
2. Holen Sie die Referenz einer Folie über ihren Index.  
3. Rufen Sie die Hauptsequenz der Effekte ab.  
4. Extrahieren Sie den in jeden Animationseffekt eingebetteten [Sound](https://reference.aspose.com/slides/de/net/aspose.slides.animation/effect/sound/).  

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;

// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei repräsentiert.
using (Presentation presentation = new Presentation("EffectSound.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Ermittelt die Hauptsequenz der Folie.
    ISequence sequence = slide.Timeline.MainSequence;

    foreach (IEffect effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        // Extrahiert den Effekt‑Sound in ein Byte‑Array
        byte[] audio = effect.Sound.BinaryData;
    }
}
```

## **Nach der Animation**

Aspose.Slides für .NET ermöglicht es Ihnen, die After‑Animation‑Eigenschaft eines Animationseffekts zu ändern.

![Beispiel für After‑Animation‑Paneel](shape-after-animation.png)

Die Dropdown‑Liste **After animation** in PowerPoint‑Effekten entspricht folgenden Eigenschaften:

- [IEffect.AfterAnimationType](https://reference.aspose.com/slides/de/net/aspose.slides.animation/ieffect/afteranimationtype/)‑Eigenschaft, die den Typ der After‑Animation beschreibt:
  * PowerPoint **More Colors** entspricht dem Typ [AfterAnimationType.Color](https://reference.aspose.com/slides/de/net/aspose.slides.animation/afteranimationtype/);
  * PowerPoint **Don't Dim** entspricht dem Typ [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/de/net/aspose.slides.animation/afteranimationtype/) (Standard‑After‑Animation‑Typ);
  * PowerPoint **Hide After Animation** entspricht dem Typ [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/de/net/aspose.slides.animation/afteranimationtype/);
  * PowerPoint **Hide on Next Mouse Click** entspricht dem Typ [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/de/net/aspose.slides.animation/afteranimationtype/);
- [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/de/net/aspose.slides.animation/ieffect/afteranimationcolor/)‑Eigenschaft, die ein Farbformat für die After‑Animation definiert. Diese Eigenschaft funktioniert zusammen mit dem Typ [AfterAnimationType.Color](https://reference.aspose.com/slides/de/net/aspose.slides.animation/afteranimationtype/). Wenn Sie den Typ ändern, wird die After‑Animation‑Farbe gelöscht.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei repräsentiert
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Ermittelt den ersten Effekt der Hauptsequenz
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Ändert den AfterAnimation‑Typ zu Color
    firstEffect.AfterAnimationType = AfterAnimationType.Color;

    // Setzt die Farbe der After‑Animation
    firstEffect.AfterAnimationColor.Color = Color.AliceBlue;

    // Schreibt die PPTX-Datei auf die Festplatte
    pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
}
```

## **Text animieren**

Aspose.Slides stellt folgende Eigenschaften zur Verfügung, um mit dem *Animate text*‑Block eines Animationseffekts zu arbeiten:

- [IEffect.AnimateTextType](https://reference.aspose.com/slides/de/net/aspose.slides.animation/ieffect/animatetexttype/) beschreibt den Typ der Textanimation des Effekts. Der Text der Form kann animiert werden:
  * Alles auf einmal ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/de/net/aspose.slides.animation/animatetexttype/) Typ)
  * Wortweise ([AnimateTextType.ByWord](https://reference.aspose.com/slides/de/net/aspose.slides.animation/animatetexttype/) Typ)
  * Buchstabenweise ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/de/net/aspose.slides.animation/animatetexttype/) Typ)
- [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/de/net/aspose.slides.animation/ieffect/delaybetweentextparts/) legt eine Verzögerung zwischen den animierten Textteilen (Wörter oder Buchstaben) fest. Ein positiver Wert gibt den Prozentsatz der Effektdauer an. Ein negativer Wert gibt die Verzögerung in Sekunden an.

So können Sie die Eigenschaften des Effect‑Animate‑Text ändern:

1. [Anwenden](#apply-animation-to-shape) oder Abrufen des Animationseffekts.  
2. Setzen Sie die Eigenschaft [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/de/net/aspose.slides.animation/itextanimation/buildtype/) auf den Wert [BuildType.AsOneObject](https://reference.aspose.com/slides/de/net/aspose.slides.animation/buildtype/), um den Animationsmodus *By Paragraphs* zu deaktivieren.  
3. Setzen Sie neue Werte für die Eigenschaften [IEffect.AnimateTextType](https://reference.aspose.com/slides/de/net/aspose.slides.animation/ieffect/animatetexttype/) und [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/de/net/aspose.slides.animation/ieffect/delaybetweentextparts/).  
4. Speichern Sie die geänderte PPTX‑Datei.  

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei repräsentiert.
using (Presentation pres = new Presentation("AnimTextBox_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Ermittelt den ersten Effekt der Hauptsequenz
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Ändert den Textanimations‑Typ des Effekts zu "As One Object"
    firstEffect.TextAnimation.BuildType = BuildType.AsOneObject;

    // Ändert den Animate‑Text‑Typ des Effekts zu "By word"
    firstEffect.AnimateTextType = AnimateTextType.ByWord;

    // Setzt die Verzögerung zwischen Wörtern auf 20% der Effektdauer
    firstEffect.DelayBetweenTextParts = 20f;

    // Schreibt die PPTX‑Datei auf die Festplatte
    pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

### Wie kann ich sicherstellen, dass Animationen beim Veröffentlichen der Präsentation im Web erhalten bleiben?

[Export to HTML5](/slides/de/net/export-to-html5/) und aktivieren Sie die [Optionen](https://reference.aspose.com/slides/de/net/aspose.slides.export/html5options/), die für [shape](https://reference.aspose.com/slides/de/net/aspose.slides.export/html5options/animateshapes/) und [transition](https://reference.aspose.com/slides/de/net/aspose.slides.export/html5options/animatetransitions/) Animationen verantwortlich sind. Reines HTML spielt keine Folienanimationen ab, HTML5 jedoch schon.

### Wie wirkt sich das Ändern der Z‑Reihenfolge (Ebenenreihenfolge) von Formen auf die Animation aus?

Animation und Zeichenreihenfolge sind unabhängig: Ein Effekt steuert das Timing und den Typ des Erschienen‑ bzw. Verschwindens, während die [z-order](https://reference.aspose.com/slides/de/net/aspose.slides/shape/zorderposition/) bestimmt, was was überlagert. Das sichtbare Ergebnis ergibt sich aus ihrer Kombination. (Dies ist das allgemeine Verhalten von PowerPoint; das Aspose.Slides‑Modell für Effekte und Formen folgt derselben Logik.)

### Gibt es Einschränkungen beim Konvertieren von Animationen in Video für bestimmte Effekte?

Im Allgemeinen werden [Animationen unterstützt](/slides/de/net/convert-powerpoint-to-video/), aber seltene Fälle oder spezielle Effekte können anderweitig gerendert werden. Es wird empfohlen, die von Ihnen verwendeten Effekte und die Bibliotheksversion zu testen.