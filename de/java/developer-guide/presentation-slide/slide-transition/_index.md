---
title: Verwalten von Folienübergängen in Präsentationen mit Java
linktitle: Folienübergang
type: docs
weight: 80
url: /de/java/slide-transition/
keywords:
- Folienübergang
- Folienübergang hinzufügen
- Folienübergang anwenden
- Erweiterter Folienübergang
- Morph-Übergang
- Übergangstyp
- Übergangseffekt
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Entdecken Sie, wie Sie Folienübergänge in Aspose.Slides für Java anpassen, mit Schritt-für-Schritt-Anleitungen für PowerPoint- und OpenDocument-Präsentationen."
---

## **Übersicht**
{{% alert color="primary" %}} 

Aspose.Slides for Java ermöglicht es Entwicklern auch, die Folienübergangseffekte der Folien zu verwalten oder anzupassen. In diesem Thema werden wir die Steuerung von Folienübergängen mit großer Leichtigkeit mithilfe von Aspose.Slides for Java besprechen.

{{% /alert %}} 

Um das Verständnis zu erleichtern, haben wir die Verwendung von Aspose.Slides for Java zur Verwaltung einfacher Folienübergänge demonstriert. Entwickler können nicht nur verschiedene Folienübergangseffekte auf die Folien anwenden, sondern auch das Verhalten dieser Übergangseffekte anpassen.

## **Folienübergang hinzufügen**
Um einen einfachen Folienübergangseffekt zu erstellen, folgen Sie den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) Klasse.
1. Wenden Sie einen Folienübergangstyp auf die Folie an, indem Sie einen der von Aspose.Slides for Java angebotenen Übergangseffekte über das TransitionType‑Enum verwenden.
1. Schreiben Sie die geänderte Präsentationsdatei.
```java
// Instanziieren der Presentation-Klasse zum Laden der Quellpräsentationsdatei
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Kreis-Übergangstyp auf Folie 1 anwenden
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Kombinations-Übergangstyp auf Folie 2 anwenden
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // Schreiben der Präsentation auf die Festplatte
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Erweiterte Folienübergänge hinzufügen**
Im obigen Abschnitt haben wir nur einen einfachen Übergangseffekt auf die Folie angewendet. Um diesen einfachen Übergang noch besser und kontrollierter zu gestalten, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) Klasse.
1. Wenden Sie einen Folienübergangstyp auf die Folie an, indem Sie einen der von Aspose.Slides for Java angebotenen Übergangseffekte auswählen.
1. Sie können den Übergang auch so einstellen, dass er bei einem Klick fortschreitet, nach einem bestimmten Zeitraum oder beides.
1. Wenn der Folienübergang auf „Advance On Click“ (Weiter bei Klick) eingestellt ist, wird der Übergang nur fortschreiten, wenn jemand die Maus klickt. Außerdem, wenn die Eigenschaft „Advance After Time“ (Weiter nach Zeit) gesetzt ist, wird der Übergang automatisch nach Ablauf der angegebenen Zeit fortschreiten.
1. Speichern Sie die geänderte Präsentation als Präsentationsdatei.
```java
// Instanziieren der Presentation-Klasse, die eine Präsentationsdatei repräsentiert
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // Kreis-Übergangstyp auf Folie 1 anwenden
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Übergangszeit von 3 Sekunden festlegen
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // Kombinations-Übergangstyp auf Folie 2 anwenden
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // Übergangszeit von 5 Sekunden festlegen
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // Zoom-Übergangstyp auf Folie 3 anwenden
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // Übergangszeit von 7 Sekunden festlegen
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // Präsentation auf die Festplatte schreiben
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Morph-Übergang**
{{% alert color="primary" %}} 

Aspose.Slides for Java unterstützt jetzt den [Morph Transition](https://reference.aspose.com/slides/java/com.aspose.slides/IMorphTransition). Sie stellen den neuen Morph-Übergang dar, der in PowerPoint 2019 eingeführt wurde.

{{% /alert %}} 

Der Morph-Übergang ermöglicht es, eine sanfte Bewegung von einer Folie zur nächsten zu animieren. Dieser Artikel beschreibt das Konzept und die Verwendung des Morph-Übergangs. Um den Morph-Übergang effektiv zu nutzen, benötigen Sie zwei Folien mit mindestens einem gemeinsamen Objekt. Der einfachste Weg ist, die Folie zu duplizieren und das Objekt auf der zweiten Folie an eine andere Position zu verschieben.

Das folgende Code‑Snippet zeigt, wie Sie eine Kopie der Folie mit etwas Text zur Präsentation hinzufügen und einen Übergang des [Morph‑Typs](https://reference.aspose.com/slides/java/com.aspose.slides/TransitionType) auf die zweite Folie anwenden.
```java
Presentation presentation = new Presentation();
try {
    AutoShape autoshape = (AutoShape)presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("Morph Transition in PowerPoint Presentations");

    presentation.getSlides().addClone(presentation.getSlides().get_Item(0));

    IShape shape = presentation.getSlides().get_Item(1).getShapes().get_Item(0);
    shape.setX(shape.getX() + 100);
    shape.setY(shape.getY() + 50);
    shape.setWidth(shape.getWidth() - 200);
    shape.setHeight(shape.getHeight() - 10);

    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(com.aspose.slides.TransitionType.Morph);

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```


## **Morph-Übergangstypen**
Ein neuer Enum [TransitionMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/TransitionMorphType) wurde hinzugefügt. Er repräsentiert verschiedene Typen von Morph‑Folienübergängen.

Der TransitionMorphType‑Enum hat drei Mitglieder:

- ByObject: Der Morph‑Übergang wird unter Berücksichtigung der Formen als unteilbare Objekte durchgeführt.
- ByWord: Der Morph‑Übergang wird nach Möglichkeit Text wortweise übertragen.
- ByChar: Der Morph‑Übergang wird nach Möglichkeit Text zeichenweise übertragen.

Das folgende Code‑Snippet zeigt, wie Sie den Morph‑Übergang für eine Folie festlegen und den Morph‑Typ ändern:
```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Morph);
    ((IMorphTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setMorphType(TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Übergangseffekte festlegen**
Aspose.Slides for Java unterstützt das Festlegen von Übergangseffekten wie „Aus Schwarz“, „Von links“, „Von rechts“ usw. Um den Übergangseffekt festzulegen, folgen Sie bitte den untenstehenden Schritten:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
- Holen Sie die Referenz der Folie.
- Legen Sie den Übergangseffekt fest.
- Speichern Sie die Präsentation als [PPTX](https://docs.fileformat.com/presentation/pptx/)‑Datei.

Im nachstehenden Beispiel haben wir die Übergangseffekte festgelegt.
```java
// Instanziieren der Presentation-Klasse
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Effekt festlegen
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // Präsentation auf die Festplatte schreiben
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **FAQ**

**Kann ich die Wiedergabegeschwindigkeit eines Folienübergangs steuern?**

Ja. Stellen Sie die [Geschwindigkeit](https://reference.aspose.com/slides/java/com.aspose.slides/slideshowtransition/#setSpeed-int-) des Übergangs über die Einstellung [TransitionSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/transitionspeed/) ein (z. B. langsam/mittel/schnell).

**Kann ich einem Übergang Audio hinzufügen und es wiederholen lassen?**

Ja. Sie können einen Sound für den Übergang einbetten und das Verhalten über Einstellungen wie Sound‑Modus und Wiederholung steuern (z. B. [setSound](https://reference.aspose.com/slides/java/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/java/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/java/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), sowie Metadaten wie [setSoundIsBuiltIn](https://reference.aspose.com/slides/java/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) und [setSoundName](https://reference.aspose.com/slides/java/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)).

**Was ist der schnellste Weg, denselben Übergang auf jede Folie anzuwenden?**

Konfigurieren Sie den gewünschten Übergangstyp in den Übergangseinstellungen jeder Folie; Übergänge werden pro Folie gespeichert, sodass das Anwenden desselben Typs auf alle Folien ein konsistentes Ergebnis liefert.

**Wie kann ich prüfen, welcher Übergang derzeit auf einer Folie eingestellt ist?**

Untersuchen Sie die [Übergangseinstellungen](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getSlideShowTransition--) der Folie und lesen Sie deren [Übergangstyp](https://reference.aspose.com/slides/java/com.aspose.slides/slideshowtransition/#setType-int-); dieser Wert gibt exakt an, welcher Effekt angewendet wurde.