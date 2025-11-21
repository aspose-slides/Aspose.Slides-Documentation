---
title: Folienübergang
type: docs
weight: 80
url: /de/nodejs-java/slide-transition/
keywords: "PowerPoint Folienübergang, Morph-Übergang in JavaScript"
description: "PowerPoint Folienübergang, PowerPoint Morph-Übergang in JavaScript"
---

## **Übersicht**
{{% alert color="primary" %}} 

Aspose.Slides für Node.js via Java ermöglicht es Entwicklern außerdem, die Folienübergangseffekte der Folien zu verwalten oder anzupassen. In diesem Thema besprechen wir, wie man Folienübergänge mit großer Leichtigkeit mit Aspose.Slides für Node.js via Java steuern kann.

{{% /alert %}} 

Um das Verständnis zu erleichtern, haben wir die Verwendung von Aspose.Slides für Node.js via Java zum Verwalten einfacher Folienübergänge demonstriert. Entwickler können nicht nur verschiedene Folienübergangseffekte auf die Folien anwenden, sondern auch das Verhalten dieser Übergangseffekte anpassen.

## **Folienübergang hinzufügen**
Um einen einfachen Folienübergangseffekt zu erstellen, führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation)‑Klasse.
2. Wenden Sie einen Folienübergangstyp auf die Folie an, indem Sie einen der von Aspose.Slides für Node.js via Java angebotenen Übergangseffekte über das TransitionType‑Enum auswählen.
3. Schreiben Sie die geänderte Präsentationsdatei.
```javascript
// Instanziiere die Presentation-Klasse, um die Quell-Präsentationsdatei zu laden
var presentation = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    // Wende den Kreis-Übergangstyp auf Folie 1 an
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Circle);
    // Wende den Kamm-Übergangstyp auf Folie 2 an
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Comb);
    // Speichere die Präsentation auf die Festplatte
    presentation.save("SampleTransition_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Erweiterten Folienübergang hinzufügen**
Im vorherigen Abschnitt haben wir nur einen einfachen Übergangseffekt auf die Folie angewendet. Um diesen einfachen Übergang nun noch besser und kontrollierter zu gestalten, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation)‑Klasse.
2. Wenden Sie einen Folienübergangstyp auf die Folie an, indem Sie einen der von Aspose.Slides für Node.js via Java angebotenen Übergangseffekte auswählen.
3. Sie können den Übergang außerdem auf „Weiter bei Klick“, nach einer bestimmten Zeitspanne oder beides einstellen.
4. Wenn der Folienübergang auf „Weiter bei Klick“ aktiviert ist, wird der Übergang nur fortgesetzt, wenn jemand mit der Maus klickt. Wenn die Eigenschaft „Advance After Time“ gesetzt ist, wird der Übergang automatisch nach Ablauf der angegebenen Zeit fortgesetzt.
5. Schreiben Sie die geänderte Präsentation in eine Präsentationsdatei.
```javascript
// Instanziiere die Presentation-Klasse, die eine Präsentationsdatei repräsentiert
var pres = new aspose.slides.Presentation("BetterSlideTransitions.pptx");
try {
    // Wende den Kreis-Übergangstyp auf Folie 1 an
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Circle);
    // Setze die Übergangszeit auf 3 Sekunden
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);
    // Wende den Kamm-Übergangstyp auf Folie 2 an
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Comb);
    // Setze die Übergangszeit auf 5 Sekunden
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);
    // Wende den Zoom-Übergangstyp auf Folie 3 an
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(aspose.slides.TransitionType.Zoom);
    // Setze die Übergangszeit auf 7 Sekunden
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);
    // Speichere die Präsentation auf der Festplatte
    pres.save("SampleTransition_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Morph‑Übergang**
{{% alert color="primary" %}} 

Aspose.Slides für Node.js via Java unterstützt jetzt den [Morph Transition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MorphTransition). Er stellt den neuen Morph‑Übergang vor, der in PowerPoint 2019 eingeführt wurde.

{{% /alert %}} 

Der Morph‑Übergang ermöglicht es, eine sanfte Bewegung von einer Folie zur nächsten zu animieren. Dieser Artikel beschreibt das Konzept und die Verwendung des Morph‑Übergangs. Um den Morph‑Übergang effektiv zu nutzen, benötigen Sie zwei Folien mit mindestens einem gemeinsamen Objekt. Der einfachste Weg ist, die Folie zu duplizieren und das Objekt auf der zweiten Folie an eine andere Position zu verschieben.

Das folgende Code‑Snippet zeigt, wie Sie eine Kopie der Folie mit etwas Text zur Präsentation hinzufügen und der zweiten Folie einen [morph type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TransitionType)‑Übergang zuweisen.
```javascript
var presentation = new aspose.slides.Presentation();
try {
    var autoshape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("Morph Transition in PowerPoint Presentations");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0));
    var shape = presentation.getSlides().get_Item(1).getShapes().get_Item(0);
    shape.setX(shape.getX() + 100);
    shape.setY(shape.getY() + 50);
    shape.setWidth(shape.getWidth() - 200);
    shape.setHeight(shape.getHeight() - 10);
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Morph);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Morph‑Übergangstypen**
Der neue [TransitionMorphType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TransitionMorphType)‑Enum wurde hinzugefügt. Er repräsentiert verschiedene Typen des Morph‑Folienübergangs.

TransitionMorphType‑Enum enthält drei Mitglieder:

- ByObject: Der Morph‑Übergang wird unter Berücksichtigung der Formen als unteilbare Objekte durchgeführt.
- ByWord: Der Morph‑Übergang wird nach Möglichkeit mit Wort‑zu‑Wort‑Übertragung des Textes durchgeführt.
- ByChar: Der Morph‑Übergang wird nach Möglichkeit mit Zeichen‑zu‑Zeichen‑Übertragung des Textes durchgeführt.

Das folgende Code‑Snippet zeigt, wie Sie den Morph‑Übergang für eine Folie festlegen und den Morph‑Typ ändern:
```javascript
var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Morph);
    presentation.getSlides().get_Item(0).getSlideShowTransition().getValue().setMorphType(aspose.slides.TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Übergangseffekte festlegen**
Aspose.Slides für Node.js via Java unterstützt das Festlegen von Übergangseffekten wie „Von Schwarz“, „Von links“, „Von rechts“ usw. Um den Übergangseffekt festzulegen, führen Sie bitte die folgenden Schritte aus:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)‑Klasse.
- Holen Sie die Referenz der Folie.
- Legen Sie den Übergangseffekt fest.
- Schreiben Sie die Präsentation als eine [PPTX](https://docs.fileformat.com/presentation/pptx/)‑Datei.

Im nachstehenden Beispiel haben wir die Übergangseffekte gesetzt.
```javascript
// Erstelle eine Instanz der Presentation-Klasse
var presentation = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    // Setze den Effekt
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Cut);
    presentation.getSlides().get_Item(0).getSlideShowTransition().getValue().setFromBlack(true);
    // Speichere die Präsentation auf der Festplatte
    presentation.save("SetTransitionEffects_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **FAQ**

**Kann ich die Wiedergabegeschwindigkeit eines Folienübergangs steuern?**

Ja. Setzen Sie die [speed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/setspeed/) des Übergangs über die Einstellung [TransitionSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionspeed/) (z. B. slow/medium/fast).

**Kann ich einem Übergang Audio hinzufügen und es wiederholen lassen?**

Ja. Sie können einen Sound für den Übergang einbetten und das Verhalten über Einstellungen wie Sound‑Modus und Looping steuern (z. B. [setSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/setsound/), [setSoundMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/setsoundmode/), [setSoundLoop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/setsoundloop/), plus Metadaten wie [setSoundIsBuiltIn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/setsoundisbuiltin/) und [setSoundName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/setsoundname/)).

**Wie lässt sich am schnellsten derselbe Übergang auf alle Folien anwenden?**

Konfigurieren Sie den gewünschten Übergangstyp in den Übergangseinstellungen jeder Folie; Übergänge werden pro Folie gespeichert, sodass die Anwendung desselben Typs auf allen Folien ein einheitliches Ergebnis liefert.

**Wie kann ich prüfen, welcher Übergang aktuell auf einer Folie eingestellt ist?**

Untersuchen Sie die [transition settings](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) der Folie und lesen Sie deren [transition type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/gettype/); dieser Wert gibt genau an, welcher Effekt angewendet wird.