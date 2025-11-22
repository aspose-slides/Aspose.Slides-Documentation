---
title: Folienübergang
type: docs
weight: 90
url: /de/net/slide-transition/
keywords: "Folienübergang hinzufügen, PowerPoint-Folienübergang, Morph-Übergang, Erweiterter Folienübergang, Übergangseffekte, C#, Csharp, .NET, Aspose.Slides"
description: "PowerPoint-Folienübergang und Übergangseffekte in C# oder .NET hinzufügen"
---

## **Folienübergang hinzufügen**
Um das Verständnis zu erleichtern, haben wir die Verwendung von Aspose.Slides für .NET demonstriert, um einfache Folienübergänge zu verwalten. Entwickler können nicht nur verschiedene Folienübergangseffekte auf den Folien anwenden, sondern auch das Verhalten dieser Übergangseffekte anpassen. Um einen einfachen Folienübergangseffekt zu erstellen, folgen Sie den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.  
2. Wenden Sie einen Folienübergangstyp auf die Folie an, ausgewählt aus den von Aspose.Slides für .NET über das TransitionType‑Enum angebotenen Übergangseffekten.  
3. Schreiben Sie die modifizierte Präsentationsdatei.  
```c#
 // Instanziiere Presentation-Klasse um die Quellpräsentationsdatei zu laden
 using (Presentation presentation = new Presentation("AccessSlides.pptx"))
 {
     // Wende Kreis-Übergangstyp auf Folie 1 an
     presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

     // Wende Kamm-Übergangstyp auf Folie 2 an
     presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

     // Schreibe die Präsentation auf die Festplatte
     presentation.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
 }
```


## **Erweiterten Folienübergang hinzufügen**
Im obigen Abschnitt haben wir nur einen einfachen Übergangseffekt auf die Folie angewendet. Um diesen einfachen Übergangseffekt nun noch besser und steuerbarer zu machen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.  
2. Wenden Sie einen Folienübergangstyp auf die Folie an, ausgewählt aus den von Aspose.Slides für .NET angebotenen Übergangseffekten.  
3. Sie können den Übergang auch so einstellen, dass er bei einem Klick, nach einer bestimmten Zeitdauer oder beides fortschreitet.  
4. Wenn der Folienübergang auf „Bei Klick fortschreiten“ eingestellt ist, wird der Übergang nur fortschreiten, wenn jemand mit der Maus klickt. Darüber hinaus wird der Übergang automatisch fortschreiten, wenn die Eigenschaft „Advance After Time“ gesetzt ist, nachdem die angegebene Zeit verstrichen ist.  
5. Schreiben Sie die modifizierte Präsentation als Präsentationsdatei.  
```c#
 // Instanziiere Presentation-Klasse, die eine Präsentationsdatei darstellt
using (Presentation pres = new Presentation("BetterSlideTransitions.pptx"))
{

    // Wende Kreis-Übergangstyp auf Folie 1 an
    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;


    // Setze die Übergangszeit von 3 Sekunden
    pres.Slides[0].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[0].SlideShowTransition.AdvanceAfterTime = 3000;

    // Wende Kamm-Übergangstyp auf Folie 2 an
    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;


    // Setze die Übergangszeit von 5 Sekunden
    pres.Slides[1].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[1].SlideShowTransition.AdvanceAfterTime = 5000;

    // Wende Zoom-Übergangstyp auf Folie 3 an
    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;


    // Setze die Übergangszeit von 7 Sekunden
    pres.Slides[2].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[2].SlideShowTransition.AdvanceAfterTime = 7000;

    // Schreibe die Präsentation auf die Festplatte
    pres.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```


Zusätzlich können Sie mit der [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/)‑Eigenschaft prüfen, ob ein Folienübergang so konfiguriert ist, dass er zur nächsten Folie wechselt, oder die Einstellung deaktivieren.

Dieser C#‑Code demonstriert den Vorgang:  
```c#
 // Instanziiert eine Presentation-Klasse, die eine Präsentationsdatei darstellt
using (Presentation pres = new Presentation("SampleTransition_out.pptx"))
{
    foreach (ISlide slide in pres.Slides)
    {
        // Ermittelt den Folienübergang
        ISlideShowTransition slideTransition = slide.SlideShowTransition;

        // Überprüft, ob die Einstellung Advance After Time aktiviert ist
        if (slideTransition.AdvanceAfter)
        {
            // Gibt den Wert von Advance After Time aus
            Console.WriteLine("The slide #" + slide.SlideNumber + " AdvancedAfterTime: " + slideTransition.AdvanceAfterTime);
        }

        // Deaktiviert den Übergang nach einer bestimmten Zeit, wenn der Wert AdvanceAfterTime größer als 2 Sekunden ist
        if (slideTransition.AdvanceAfterTime > 2000)
        {
            slideTransition.AdvanceAfter = false;
        }
    }
}
```


## **Morph‑Übergang**
Aspose.Slides für .NET unterstützt jetzt den [Morph Transition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition). Sie stellen einen neuen Morph‑Übergang dar, der in PowerPoint 2019 eingeführt wurde. Der Morph‑Übergang ermöglicht es, eine fließende Bewegung von einer Folie zur nächsten zu animieren. Dieser Artikel beschreibt das Konzept und die Verwendung des Morph‑Übergangs. Um den Morph‑Übergang effektiv zu nutzen, benötigen Sie zwei Folien, die mindestens ein gemeinsames Objekt enthalten. Der einfachste Weg ist, die Folie zu duplizieren und das Objekt auf der zweiten Folie an eine andere Stelle zu verschieben.

Das folgende Code‑Snippet zeigt, wie Sie eine Kopie der Folie mit etwas Text zur Präsentation hinzufügen und der zweiten Folie einen Übergang des [morph type](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/properties/morphtype)‑Typs zuweisen.  
```c#
using (Presentation presentation = new Presentation())
{
    AutoShape autoshape = (AutoShape)presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.TextFrame.Text = "Morph Transition in PowerPoint Presentations";

    presentation.Slides.AddClone(presentation.Slides[0]);

    presentation.Slides[1].Shapes[0].X += 100;
    presentation.Slides[1].Shapes[0].Y += 50;
    presentation.Slides[1].Shapes[0].Width -= 200;
    presentation.Slides[1].Shapes[0].Height -= 10;

    presentation.Slides[1].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Morph;

    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```


## **Morph‑Übergangstypen**
Ein neuer [Aspose.Slides.SlideShow.TransitionMorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype)‑Enum wurde hinzugefügt. Er repräsentiert verschiedene Typen des Morph‑Folienübergangs.

Der TransitionMorphType‑Enum hat drei Mitglieder:

- ByObject: Der Morph‑Übergang wird unter Berücksichtigung der Formen als unteilbare Objekte durchgeführt.  
- ByWord: Der Morph‑Übergang wird nach Möglichkeit Text wortweise übertragen.  
- ByChar: Der Morph‑Übergang wird nach Möglichkeit Text zeichenweise übertragen.  

Das folgende Code‑Snippet zeigt, wie Sie einen Morph‑Übergang für eine Folie festlegen und den Morph‑Typ ändern:  
```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Morph;
    ((IMorphTransition)presentation.Slides[0].SlideShowTransition.Value).MorphType = TransitionMorphType.ByWord;
    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```


## **Übergangseffekte festlegen**
Aspose.Slides für .NET unterstützt das Festlegen von Übergangseffekten wie „von Schwarz“, „von links“, „von rechts“ usw. Um den Übergangseffekt festzulegen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)‑Klasse.  
- Holen Sie die Referenz der Folie.  
- Legen Sie den Übergangseffekt fest.  
- Speichern Sie die Präsentation als [PPTX](https://docs.fileformat.com/presentation/pptx/)‑Datei.  

Im folgenden Beispiel haben wir die Übergangseffekte festgelegt.  
```c#
// Erstelle eine Instanz der Presentation-Klasse
Presentation presentation = new Presentation("AccessSlides.pptx");

// Effekt festlegen
presentation.Slides[0].SlideShowTransition.Type = TransitionType.Cut;
((OptionalBlackTransition)presentation.Slides[0].SlideShowTransition.Value).FromBlack = true;

// Schreibe die Präsentation auf die Festplatte
presentation.Save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
```


## **FAQ**

**Kann ich die Wiedergabegeschwindigkeit eines Folienübergangs steuern?**  
Ja. Legen Sie die [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) des Übergangs über die Einstellung [TransitionSpeed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionspeed/) fest (z. B. langsam/mittel/schnell).

**Kann ich einer Transition Audio hinzufügen und es in einer Schleife abspielen?**  
Ja. Sie können einen Sound für den Übergang einbetten und das Verhalten über Einstellungen wie Sound‑Modus und Schleife steuern (z. B. [Sound](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/sound/), [SoundMode](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/soundmode/), [SoundLoop](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/soundloop/) sowie Metadaten wie [SoundIsBuiltIn](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/soundisbuiltin/) und [SoundName](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/soundname/)).

**Was ist der schnellste Weg, denselben Übergang auf alle Folien anzuwenden?**  
Konfigurieren Sie den gewünschten Übergangstyp in den Übergangeinstellungen jeder Folie; Übergänge werden pro Folie gespeichert, sodass das Anwenden desselben Typs auf alle Folien ein einheitliches Ergebnis liefert.

**Wie kann ich prüfen, welcher Übergang derzeit auf einer Folie festgelegt ist?**  
Untersuchen Sie die [transition settings](https://reference.aspose.com/slides/net/aspose.slides/baseslide/slideshowtransition/) der Folie und lesen Sie deren [transition type](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/type/); dieser Wert gibt exakt an, welcher Effekt angewendet wird.