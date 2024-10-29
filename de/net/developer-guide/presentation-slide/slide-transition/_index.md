---
title: Folienübergang
type: docs
weight: 90
url: /de/net/slide-transition/
keywords: "Fügen Sie Folienübergänge hinzu, PowerPoint-Folienübergänge, Morphübergang, erweiterte Folienübergänge, Übergangseffekte, C#, Csharp, .NET, Aspose.Slides"
description: " Fügen Sie PowerPoint-Folienübergänge und Übergangseffekte in C# oder .NET hinzu "
---

## **Folie Übergang Hinzufügen**
Um es einfacher zu verstehen, haben wir die Verwendung von Aspose.Slides für .NET zur Verwaltung einfacher Folienübergänge demonstriert. Entwickler können nicht nur verschiedene Folienübergangseffekte auf die Folien anwenden, sondern auch das Verhalten dieser Übergangseffekte anpassen. Um einen einfachen Folienübergangseffekt zu erstellen, befolgen Sie die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
1. Wenden Sie einen Folienübergangstyp auf die Folie aus einem der von Aspose.Slides für .NET angebotenen Übergangseffekte über das TransitionType-Enum an.
1. Schreiben Sie die modifizierte Präsentationsdatei.

```c#
// Instanziieren Sie die Presentation-Klasse, um die Quelldatei der Präsentation zu laden
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    // Wenden Sie den Übergangstyp 'Kreis' auf Folie 1 an
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    // Wenden Sie den Übergangstyp 'Kamm' auf Folie 2 an
    presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    // Schreiben Sie die Präsentation auf die Festplatte
    presentation.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```

## **Erweiterten Folienübergang Hinzufügen**
Im obigen Abschnitt haben wir nur einen einfachen Übergangseffekt auf die Folie angewendet. Um diesen einfachen Übergangseffekt noch besser und kontrollierter zu gestalten, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
1. Wenden Sie einen Folienübergangstyp auf die Folie aus einem der von Aspose.Slides für .NET angebotenen Übergangseffekte an.
1. Sie können auch den Übergang auf 'Nach Klick weitervorrücken', nach einem bestimmten Zeitraum oder beides setzen.
1. Wenn der Folienübergang auf 'Nach Klick weitervorrücken' aktiviert ist, wird der Übergang nur ausgeführt, wenn jemand die Maus klickt. Zudem wird der Übergang automatisch voranschreiten, wenn die 'Nach Zeit fortschreiten'-Eigenschaft festgelegt ist und die angegebene Zeit abgelaufen ist.
1. Schreiben Sie die modifizierte Präsentation als Präsentationsdatei.

```c#
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt
using (Presentation pres = new Presentation("BetterSlideTransitions.pptx"))
{
    // Wenden Sie den Übergangstyp 'Kreis' auf Folie 1 an
    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    // Setzen Sie die Übergangszeit auf 3 Sekunden
    pres.Slides[0].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[0].SlideShowTransition.AdvanceAfterTime = 3000;

    // Wenden Sie den Übergangstyp 'Kamm' auf Folie 2 an
    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    // Setzen Sie die Übergangszeit auf 5 Sekunden
    pres.Slides[1].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[1].SlideShowTransition.AdvanceAfterTime = 5000;

    // Wenden Sie den Übergangstyp 'Zoom' auf Folie 3 an
    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;

    // Setzen Sie die Übergangszeit auf 7 Sekunden
    pres.Slides[2].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[2].SlideShowTransition.AdvanceAfterTime = 7000;

    // Schreiben Sie die Präsentation auf die Festplatte
    pres.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```

Zusätzlich können Sie mit der [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/)-Eigenschaft überprüfen, ob ein Folienübergang so konfiguriert wurde, dass er zur nächsten Folie wechselt oder die Einstellung deaktiviert.

Dieser C#-Code demonstriert die Funktion:

```c#
// Instanziert eine Presentation-Klasse, die eine Präsentationsdatei darstellt
using (Presentation pres = new Presentation("SampleTransition_out.pptx"))
{
    foreach (ISlide slide in pres.Slides)
    {
        // Erhält den Folienübergang
        ISlideShowTransition slideTransition = slide.SlideShowTransition;

        // Überprüft, ob die Einstellung 'Nach Zeit fortschreiten' aktiviert ist
        if (slideTransition.AdvanceAfter)
        {
            // Gibt den Wert von 'Nach Zeit fortschreiten' aus
            Console.WriteLine("Die Folie #" + slide.SlideNumber + " AdvancedAfterTime: " + slideTransition.AdvanceAfterTime);
        }

        // Deaktiviert den Übergang nach einer bestimmten Zeit, falls der Wert von 'Nach Zeit fortschreiten' größer als 2 Sekunden ist
        if (slideTransition.AdvanceAfterTime > 2000)
        {
            slideTransition.AdvanceAfter = false;
        }
    }
}
```

## **Morph Übergang**
Aspose.Slides für .NET unterstützt jetzt den [Morph Übergang](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition). Er repräsentiert einen neuen Morph-Übergang, der in PowerPoint 2019 eingeführt wurde. Der Morph-Übergang ermöglicht es Ihnen, eine sanfte Bewegung von einer Folie zur nächsten zu animieren. Dieser Artikel beschreibt das Konzept und die Verwendung des Morph-Übergangs. Um den Morph-Übergang effektiv zu verwenden, benötigen Sie zwei Folien mit mindestens einem gemeinsamen Objekt. Der einfachste Weg besteht darin, die Folie zu duplizieren und das Objekt auf der zweiten Folie an eine andere Stelle zu verschieben.

Der folgende Code zeigt, wie Sie einen Klon der Folie mit etwas Text zur Präsentation hinzufügen und einen Übergang des [morph Typs](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/properties/morphtype) auf die zweite Folie setzen.

```c#
using (Presentation presentation = new Presentation())
{
    AutoShape autoshape = (AutoShape)presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.TextFrame.Text = "Morph Transition in PowerPoint Präsentationen";

    presentation.Slides.AddClone(presentation.Slides[0]);

    presentation.Slides[1].Shapes[0].X += 100;
    presentation.Slides[1].Shapes[0].Y += 50;
    presentation.Slides[1].Shapes[0].Width -= 200;
    presentation.Slides[1].Shapes[0].Height -= 10;

    presentation.Slides[1].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Morph;

    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

## **Morph Übergang Typen**
Ein neues [Aspose.Slides.SlideShow.TransitionMorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype) Enum wurde hinzugefügt. Es repräsentiert verschiedene Typen von Morph-Folienübergängen.

Das TransitionMorphType-Enum hat drei Mitglieder:

- ByObject: Der Morph-Übergang wird durchgeführt, wobei Formen als unteilbare Objekte betrachtet werden.
- ByWord: Der Morph-Übergang wird durchgeführt, indem Texte nach Wörtern übertragen werden, wo möglich.
- ByChar: Der Morph-Übergang wird durchgeführt, indem Texte nach Zeichen übertragen werden, wo möglich.

Der folgende Code zeigt, wie Sie den Morph-Übergang auf die Folie setzen und den Morph-Typ ändern:

```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Morph;
    ((IMorphTransition)presentation.Slides[0].SlideShowTransition.Value).MorphType = TransitionMorphType.ByWord;
    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

## **Übergangseffekte Festlegen**
Aspose.Slides für .NET unterstützt das Festlegen von Übergangseffekten wie von schwarz, von links, von rechts usw. Um den Übergangseffekt festzulegen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
- Holen Sie sich die Referenz der Folie.
- Setzen des Übergangseffekts.
- Schreiben Sie die Präsentation als [PPTX ](https://docs.fileformat.com/presentation/pptx/)Datei.

Im folgenden Beispiel haben wir die Übergangseffekte festgelegt.

```c#
// Erstellen Sie eine Instanz der Presentation-Klasse
Presentation presentation = new Presentation("AccessSlides.pptx");

// Setzen Sie den Effekt
presentation.Slides[0].SlideShowTransition.Type = TransitionType.Cut;
((OptionalBlackTransition)presentation.Slides[0].SlideShowTransition.Value).FromBlack = true;

// Schreiben Sie die Präsentation auf die Festplatte
presentation.Save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
```