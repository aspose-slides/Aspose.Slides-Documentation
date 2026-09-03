---
title: "Folienübergänge in Präsentationen in .NET verwalten"
linktitle: "Folienübergang"
type: docs
weight: 90
url: /de/net/slide-transition/
keywords:
- "Folienübergang"
- "Folienübergang hinzufügen"
- "Folienübergang anwenden"
- "Erweiterter Folienübergang"
- "Morph‑Übergang"
- "Übergangstyp"
- "Übergangseffekt"
- "PowerPoint"
- "OpenDocument"
- "Präsentation"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Wenden Sie Folienübergänge an, konfigurieren Sie die automatische Folienfortschritt und passen Sie Morph- und andere Übergangseffekte mit Aspose.Slides für .NET an."
---
## **Übersicht**

Folienübergänge steuern, wie Folien während einer Diashow erscheinen. Mit Aspose.Slides für .NET können Sie für jede Folie einen Übergangseffekt auswählen, den Fortschritt per Mausklick oder Timer konfigurieren und optionsspezifische Einstellungen für einen Effekt anpassen. Dieser Artikel verwendet C#‑Beispiele, um Übergänge anzuwenden, genaue Übergangsdauern festzulegen, Folienzeiten zu verwalten und einen Morph‑Übergang zwischen zwei Folien zu erstellen. Die Beispiele zeigen außerdem, wie die Einstellungen in einer PPTX‑Datei gespeichert werden.

## **Folienübergang hinzufügen**

Um einen Übergang anzuwenden, laden Sie eine Präsentation mit der [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/)‑Klasse und greifen auf die [SlideShowTransition](https://reference.aspose.com/slides/de/net/aspose.slides/ibaseslide/slideshowtransition/)‑Eigenschaft der Folie zu. Setzen Sie deren [Type](https://reference.aspose.com/slides/de/net/aspose.slides/islideshowtransition/type/) auf einen Wert aus der [TransitionType](https://reference.aspose.com/slides/de/net/aspose.slides.slideshow/transitiontype/)‑Aufzählung und speichern Sie anschließend die Präsentation.

Das folgende Beispiel wendet für die erste Folie einen Circle‑Übergang und für die zweite Folie einen Comb‑Übergang an. Verwenden Sie eine Datei `input.pptx` mit mindestens zwei Folien.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 2)
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;
    presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    presentation.Save("slide-transitions.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

## **Erweiterten Folienübergang hinzufügen**

Sie können festlegen, wie lange eine Folie angezeigt wird und ob ein Mausklick die Diashow voranbringt. Die folgenden Eigenschaften steuern dieses Verhalten:

- [AdvanceOnClick](https://reference.aspose.com/slides/de/net/aspose.slides/islideshowtransition/advanceonclick/) ermöglicht dem Betrachter, durch Klicken der Maus voranzuschreiten.
- [AdvanceAfter](https://reference.aspose.com/slides/de/net/aspose.slides/islideshowtransition/advanceafter/) aktiviert die automatische Fortsetzung.
- [AdvanceAfterTime](https://reference.aspose.com/slides/de/net/aspose.slides/islideshowtransition/advanceaftertime/) gibt die Verzögerung vor der automatischen Fortsetzung in Millisekunden an.

Aktivieren Sie sowohl Klick‑ als auch Timer‑Fortschritt, damit der Betrachter entweder per Klick weitergeht oder auf den Timer wartet. Um nur den Timer zu verwenden, setzen Sie [AdvanceOnClick](https://reference.aspose.com/slides/de/net/aspose.slides/islideshowtransition/advanceonclick/) auf `false`. Die Verzögerung bestimmt, wann die Diashow fortschreitet; sie legt nicht die Dauer des visuellen Übergangseffekts fest.

Dieses Beispiel weist den ersten drei Folien unterschiedliche Effekte zu und aktiviert die automatische Fortsetzung nach 3, 5 bzw. 7 Sekunden. Mausklicks können diese Folien ebenfalls voranbringen. Verwenden Sie eine Datei `input.pptx` mit mindestens drei Folien.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 3)
{
    var firstTransition = presentation.Slides[0].SlideShowTransition;
    firstTransition.Type = TransitionType.Circle;
    firstTransition.AdvanceOnClick = true;
    firstTransition.AdvanceAfter = true;
    firstTransition.AdvanceAfterTime = 3000;

    var secondTransition = presentation.Slides[1].SlideShowTransition;
    secondTransition.Type = TransitionType.Comb;
    secondTransition.AdvanceOnClick = true;
    secondTransition.AdvanceAfter = true;
    secondTransition.AdvanceAfterTime = 5000;

    var thirdTransition = presentation.Slides[2].SlideShowTransition;
    thirdTransition.Type = TransitionType.Zoom;
    thirdTransition.AdvanceOnClick = true;
    thirdTransition.AdvanceAfter = true;
    thirdTransition.AdvanceAfterTime = 7000;

    presentation.Save("advanced-transitions.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least three slides.");
}
```

Um zu prüfen, ob die zeitgesteuerte Fortsetzung aktiviert ist, lesen Sie [AdvanceAfter](https://reference.aspose.com/slides/de/net/aspose.slides/islideshowtransition/advanceafter/). Ein gespeicherter Verzögerungswert allein bedeutet nicht, dass der Timer aktiv ist.

Das nächste Beispiel öffnet die oben gespeicherte Datei, gibt für jede aktivierte Timer‑Einstellung eine Meldung aus und deaktiviert die automatische Fortsetzung für Folien mit einer Verzögerung von mehr als zwei Sekunden. Für diese Folien wird der Mausklick wieder aktiviert und die geänderten Einstellungen werden gespeichert.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("advanced-transitions.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;

    if (transition.AdvanceAfter)
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: advance after {transition.AdvanceAfterTime} ms.");

        if (transition.AdvanceAfterTime > 2000)
        {
            transition.AdvanceAfter = false;
            transition.AdvanceOnClick = true;
        }
    }
}

presentation.Save("adjusted-transitions.pptx", SaveFormat.Pptx);
```

## **Übergangszeit exakt steuern**

Verwenden Sie [Duration](https://reference.aspose.com/slides/de/net/aspose.slides.slideshow/slideshowtransition/duration/), um die genaue Länge eines Übergangseffekts in Millisekunden festzulegen. Die [SlideShowTransition](https://reference.aspose.com/slides/de/net/aspose.slides/ibaseslide/slideshowtransition/)‑Eigenschaft der Folie stellt diese Einstellungen über [ISlideShowTransition](https://reference.aspose.com/slides/de/net/aspose.slides/islideshowtransition/) bereit:

| Eigenschaft | Zweck |
| --- | --- |
| [Duration](https://reference.aspose.com/slides/de/net/aspose.slides.slideshow/slideshowtransition/duration/) | Legt die Dauer des Übergangseffekts selbst in Millisekunden fest. |
| [AdvanceAfterTime](https://reference.aspose.com/slides/de/net/aspose.slides.slideshow/slideshowtransition/advanceaftertime/) | Legt die Verzögerung vor der automatischen Folienfortschritt in Millisekunden fest. Aktivieren Sie [AdvanceAfter](https://reference.aspose.com/slides/de/net/aspose.slides/islideshowtransition/advanceafter/), um diesen Timer zu nutzen. |
| [Speed](https://reference.aspose.com/slides/de/net/aspose.slides.slideshow/slideshowtransition/speed/) | Wählt eine vordefinierte Geschwindigkeitskategorie aus [TransitionSpeed](https://reference.aspose.com/slides/de/net/aspose.slides.slideshow/transitionspeed/): Slow, Medium oder Fast. Sie wird verwendet, wenn keine genaue Dauer angegeben ist. |

[Duration](https://reference.aspose.com/slides/de/net/aspose.slides.slideshow/slideshowtransition/duration/) beeinflusst ausschließlich den Übergangseffekt; sie bestimmt nicht, wie lange die Folie sichtbar bleibt. Die Verzögerung für die automatische Fortsetzung wird separat konfiguriert. Wenn keine explizite Dauer gesetzt ist, ermittelt Aspose.Slides die Effektdauer aus dem Übergangstyp und dem [Speed](https://reference.aspose.com/slides/de/net/aspose.slides.slideshow/slideshowtransition/speed/)-Wert.

### **Für jede Folie dieselbe Dauer anwenden**

Für ein gleichmäßiges Tempo wenden Sie denselben Effekt und dieselbe exakte Dauer auf alle Folien an. Dieses Beispiel lädt `input.pptx`, wählt Fade aus [TransitionType](https://reference.aspose.com/slides/de/net/aspose.slides.slideshow/transitiontype/) und gibt jedem Übergang eine Dauer von 750 ms. Zusätzlich wird die automatische Fortsetzung nach 5.000 ms aktiviert und der Mausklick deaktiviert; anschließend wird das Ergebnis als PPTX gespeichert.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;
    transition.Type = TransitionType.Fade;
    transition.Duration = 750;

    // Konfigurieren Sie die automatische Folienfortschritt unabhängig von der Dauer des Effekts.
    transition.AdvanceAfter = true;
    transition.AdvanceAfterTime = 5000;
    transition.AdvanceOnClick = false;
}

presentation.Save("precise-transitions.pptx", SaveFormat.Pptx);
```

### **Unterschiedliche Dauern für einzelne Folien festlegen**

Verschiedene Folien können unterschiedliche Effektdauern erhalten. Beispielsweise kann für eine Titelfolie ein kurzer Übergang und für eine Abschnittseinleitung ein längerer Übergang verwendet werden. Dieses Beispiel setzt 500 ms für die erste Folie und 1.200 ms für die zweite Folie. Verwenden Sie eine Datei `input.pptx` mit mindestens zwei Folien.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 2)
{
    var firstTransition = presentation.Slides[0].SlideShowTransition;
    firstTransition.Type = TransitionType.Fade;
    firstTransition.Duration = 500;

    var secondTransition = presentation.Slides[1].SlideShowTransition;
    secondTransition.Type = TransitionType.Push;
    secondTransition.Duration = 1200;

    presentation.Save("individual-transition-durations.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

### **Übergänge mit animierten Ausgaben abstimmen**

Beim Exportieren zu einem [animated GIF](/slides/de/net/convert-powerpoint-to-animated-gif/), einer [HTML5 presentation](/slides/de/net/export-to-html5/) oder einem [video](/slides/de/net/convert-powerpoint-to-video/) sollten Sie die exakten Übergangsdauern vor dem Export festlegen, um das gewünschte Tempo zu erreichen. Verwenden Sie zum Beispiel einen 600‑ms‑Fade zwischen Szenen und passen Sie die Fortsetzungsverzögerung jeder Folie separat an, um Zeit für die Narration oder den Inhalt zu lassen.

Für GIF und Video muss die Bildrate mit der Effektdauer abgestimmt werden: 600 ms entsprechen 18 Frames bei 30 Frames pro Sekunde. In HTML5 aktivieren Sie animierte Übergänge in den Exporteinstellungen. Prüfen Sie die unterstützten Effekte und Zeitoptionen des gewählten Formats und sehen Sie sich eine Vorschau an, um die Synchronisation zu bestätigen.

### **Vorhandene Übergangsdauer auslesen**

Lesen Sie [Duration](https://reference.aspose.com/slides/de/net/aspose.slides.slideshow/slideshowtransition/duration/), bevor Sie den Übergang ändern, um festzustellen, ob ein expliziter Wert gespeichert ist. Ein Wert von `-1` bedeutet, dass keine explizite Dauer gesetzt wurde; ein nicht‑negativer Wert gibt die gespeicherte Dauer in Millisekunden an. Der nicht gesetzte Wert ist nicht die berechnete Wiedergabedauer: Aspose.Slides verwendet den Übergangstyp und [Speed](https://reference.aspose.com/slides/de/net/aspose.slides.slideshow/slideshowtransition/speed/), um diese Dauer zu bestimmen. Das Festlegen eines Übergangstyps kann eine Dauer initialisieren, daher sollten Sie zuerst die Originaleinstellungen prüfen.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;
    var duration = transition.Duration;

    if (duration >= 0)
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: stored transition duration is {duration} ms.");
    }
    else
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: no explicit duration; timing depends on {transition.Type} and {transition.Speed}.");
    }
}
```

## **Morph‑Übergang**

Der Morph‑Übergang animiert Änderungen zwischen Objekten auf aufeinanderfolgenden Folien. Um einen einfachen Morph‑Effekt zu erzeugen, duplizieren Sie eine Folie, verschieben oder skalieren Sie ein Objekt auf der Kopie und wenden den Morph‑Übergang auf die zweite Folie an. Dadurch erhalten die entsprechenden Objekte eine Animation zwischen ihrem ursprünglichen und veränderten Zustand.

Das folgende Beispiel erstellt eine Folie mit einem Textrechteck, dupliziert die Folie und ändert Position und Größe des Rechtecks auf der Kopie. Anschließend wird für die zweite Folie Morph aus der [TransitionType](https://reference.aspose.com/slides/de/net/aspose.slides.slideshow/transitiontype/)‑Aufzählung ausgewählt. Öffnen Sie die gespeicherte Datei in einem Präsentationsviewer, der Morph unterstützt, um den Effekt während einer Diashow zu sehen.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation();

var firstSlide = presentation.Slides[0];
var rectangle = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
rectangle.TextFrame.Text = "Morph transition";

var secondSlide = presentation.Slides.AddClone(firstSlide);
var movedRectangle = secondSlide.Shapes[0];
movedRectangle.X += 100;
movedRectangle.Y += 50;
movedRectangle.Width -= 200;
movedRectangle.Height -= 10;

secondSlide.SlideShowTransition.Type = TransitionType.Morph;

presentation.Save("morph-transition.pptx", SaveFormat.Pptx);
```

## **Morph‑Übergangstypen**

Die [TransitionMorphType](https://reference.aspose.com/slides/de/net/aspose.slides.slideshow/transitionmorphtype/)‑Aufzählung bestimmt, wie Morph Inhalte abgleicht und animiert:

- [ByObject](https://reference.aspose.com/slides/de/net/aspose.slides.slideshow/transitionmorphtype/) behandelt jede Form als Ganzes.
- [ByWord](https://reference.aspose.com/slides/de/net/aspose.slides.slideshow/transitionmorphtype/) animiert Text, indem nach Möglichkeit Wörter abgeglichen werden.
- [ByChar](https://reference.aspose.com/slides/de/net/aspose.slides.slideshow/transitionmorphtype/) animiert Text, indem nach Möglichkeit Zeichen abgeglichen werden.

Setzen Sie vor dem Zugriff auf das [Value](https://reference.aspose.com/slides/de/net/aspose.slides/islideshowtransition/value/) des Übergangs die [Type](https://reference.aspose.com/slides/de/net/aspose.slides/islideshowtransition/type/) auf Morph. Der erhaltene Wert liefert das [IMorphTransition](https://reference.aspose.com/slides/de/net/aspose.slides.slideshow/imorphtransition/)‑Interface, dessen [MorphType](https://reference.aspose.com/slides/de/net/aspose.slides.slideshow/imorphtransition/morphtype/)‑Eigenschaft den Abgleichmodus auswählt.

Dieses Beispiel öffnet die in dem vorherigen Abschnitt erstellte Präsentation und konfiguriert die zweite Folie so, dass sie eine wortbasierte Morph‑Animation verwendet.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("morph-transition.pptx");

if (presentation.Slides.Count >= 2)
{
    var transition = presentation.Slides[1].SlideShowTransition;
    transition.Type = TransitionType.Morph;

    if (transition.Value is IMorphTransition morphTransition)
    {
        morphTransition.MorphType = TransitionMorphType.ByWord;
        presentation.Save("morph-by-word.pptx", SaveFormat.Pptx);
    }
    else
    {
        Console.WriteLine("Morph transition options are unavailable.");
    }
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

## **Übergangseffekte festlegen**

Einige Übergänge bieten zusätzliche Optionen, etwa Richtung oder ob der Effekt von einem schwarzen Bildschirm aus startet. Die verfügbaren Optionen hängen vom gewählten [Type](https://reference.aspose.com/slides/de/net/aspose.slides/islideshowtransition/type/) ab. Setzen Sie zuerst den Typ und verwenden Sie dann das passende Interface aus dem zugehörigen [Value](https://reference.aspose.com/slides/de/net/aspose.slides/islideshowtransition/value/).

Das folgende Beispiel wendet einen Cut‑Übergang auf die erste Folie von `input.pptx` an. Über [IOptionalBlackTransition](https://reference.aspose.com/slides/de/net/aspose.slides.slideshow/ioptionalblacktransition/) wird [FromBlack](https://reference.aspose.com/slides/de/net/aspose.slides.slideshow/ioptionalblacktransition/fromblack/) gesetzt, sodass der Übergang von einem schwarzen Bildschirm startet.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");
var transition = presentation.Slides[0].SlideShowTransition;
transition.Type = TransitionType.Cut;

if (transition.Value is IOptionalBlackTransition cutTransition)
{
    cutTransition.FromBlack = true;
    presentation.Save("cut-from-black.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Cut transition options are unavailable.");
}
```

## **FAQ**

**Kann ich die Wiedergabegeschwindigkeit eines Folienübergangs steuern?**

Ja. Verwenden Sie [Duration](https://reference.aspose.com/slides/de/net/aspose.slides.slideshow/slideshowtransition/duration/), wenn Sie eine exakte Effektdauer in Millisekunden benötigen. Nutzen Sie [Speed](https://reference.aspose.com/slides/de/net/aspose.slides.slideshow/slideshowtransition/speed/), wenn eine vordefinierte [TransitionSpeed](https://reference.aspose.com/slides/de/net/aspose.slides.slideshow/transitionspeed/)-Kategorie – Slow, Medium oder Fast – ausreicht und keine explizite Dauer gesetzt ist. Diese Einstellungen steuern den Übergangseffekt unabhängig von der automatischen Fortsetzungsverzögerung.

**Kann ich einem Übergang Audio zuweisen und es wiederholen lassen?**

Ja. Weisen Sie eingebettetes Audio [Sound](https://reference.aspose.com/slides/de/net/aspose.slides/islideshowtransition/sound/) zu, setzen Sie [SoundMode](https://reference.aspose.com/slides/de/net/aspose.slides/islideshowtransition/soundmode/) auf `StartSound` aus der [TransitionSoundMode](https://reference.aspose.com/slides/de/net/aspose.slides.slideshow/transitionsoundmode/)-Aufzählung und aktivieren Sie [SoundLoop](https://reference.aspose.com/slides/de/net/aspose.slides/islideshowtransition/soundloop/). Das Audio wiederholt sich, bis das nächste Sound‑Ereignis in der Diashow eintritt.

**Was ist der schnellste Weg, denselben Übergang auf alle Folien anzuwenden?**

Iterieren Sie über die [Slides](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/slides/de/)‑Sammlung der Präsentation und setzen Sie für jede Folie den [Type](https://reference.aspose.com/slides/de/net/aspose.slides/islideshowtransition/type/) des Übergangs auf denselben Wert. Setzen Sie Timing‑ und Effektoptionen im selben Durchlauf, um das Verhalten über alle Folien hinweg konsistent zu halten.

**Wie kann ich prüfen, welcher Übergang aktuell auf einer Folie eingestellt ist?**

Lesen Sie die [Type](https://reference.aspose.com/slides/de/net/aspose.slides/islideshowtransition/type/)‑Eigenschaft der [SlideShowTransition](https://reference.aspose.com/slides/de/net/aspose.slides/ibaseslide/slideshowtransition/) der Folie aus. Sie liefert einen Wert aus der [TransitionType](https://reference.aspose.com/slides/de/net/aspose.slides.slideshow/transitiontype/)-Aufzählung; `None` bedeutet, dass kein Übergangseffekt angewendet wurde.