---
title: Folienübergänge in Präsentationen auf Android verwalten
linktitle: Folienübergang
type: docs
weight: 80
url: /de/androidjava/slide-transition/
keywords:
- Folienübergang
- Folienübergang hinzufügen
- Folienübergang anwenden
- erweiterter Folienübergang
- Morph‑Übergang
- Übergangstyp
- Übergangseffekt
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Folienübergänge in Aspose.Slides für Android via Java anpassen, mit Schritt‑für‑Schritt‑Anleitung für PowerPoint‑ und OpenDocument‑Präsentationen."
---

## **Übersicht**
{{% alert color="primary" %}} 

Aspose.Slides für Android via Java ermöglicht Entwicklern zudem das Verwalten und Anpassen von Folienübergangseffekten. In diesem Thema besprechen wir, wie man Folienübergänge mit großer Leichtigkeit mithilfe von Aspose.Slides für Android via Java steuern kann.

{{% /alert %}} 

Um das Verständnis zu erleichtern, haben wir die Verwendung von Aspose.Slides für Android via Java zur Verwaltung einfacher Folienübergänge demonstriert. Entwickler können nicht nur verschiedene Folienübergangseffekte auf die Folien anwenden, sondern auch das Verhalten dieser Übergangseffekte anpassen.

## **Folienübergang hinzufügen**
Um einen einfachen Folienübergangseffekt zu erstellen, folgen Sie den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) Klasse.
1. Wenden Sie einen Folienübergangstyp auf die Folie an, indem Sie einen der von Aspose.Slides für Android via Java angebotenen Übergangseffekte über das TransitionType-Enum auswählen.
1. Schreiben Sie die modifizierte Präsentationsdatei.
```java
// Instanziieren der Presentation-Klasse zum Laden der Quelldatei
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Kreis-Übergangstyp auf Folie 1 anwenden
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Kamm-Übergangstyp auf Folie 2 anwenden
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // Präsentation auf Festplatte schreiben
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Erweiterten Folienübergang hinzufügen**
Im vorherigen Abschnitt haben wir nur einen einfachen Übergangseffekt auf die Folie angewendet. Um diesen einfachen Übergangseffekt nun noch besser und steuerbarer zu machen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) Klasse.
1. Wenden Sie einen Folienübergangstyp auf die Folie an, indem Sie einen der von Aspose.Slides für Android via Java angebotenen Übergangseffekte auswählen.
1. Sie können den Übergang außerdem auf „Advance On Click“, nach einem bestimmten Zeitraum oder beides setzen.
1. Wenn der Folienübergang auf „Advance On Click“ aktiviert ist, wird der Übergang nur fortschreiten, wenn jemand mit der Maus klickt. Ist die Eigenschaft „Advance After Time“ gesetzt, wird der Übergang automatisch nach Ablauf der festgelegten Vorlaufzeit fortschreiten.
1. Schreiben Sie die modifizierte Präsentation als Präsentationsdatei.
```java
// Instanziieren der Presentation-Klasse, die eine Präsentationsdatei darstellt
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // Kreis-Übergangstyp auf Folie 1 anwenden
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Setzen der Übergangszeit auf 3 Sekunden
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // Kamm-Übergangstyp auf Folie 2 anwenden
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // Setzen der Übergangszeit auf 5 Sekunden
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // Zoom-Übergangstyp auf Folie 3 anwenden
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // Setzen der Übergangszeit auf 7 Sekunden
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // Präsentation auf Festplatte schreiben
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Morph-Übergang**
{{% alert color="primary" %}} 

Aspose.Slides für Android via Java unterstützt jetzt den [Morph Transition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMorphTransition). Sie stellen den neuen Morph‑Übergang vor, der in PowerPoint 2019 eingeführt wurde.

{{% /alert %}} 

Der Morph‑Übergang ermöglicht es, eine sanfte Bewegung von einer Folie zur nächsten zu animieren. Dieser Artikel beschreibt das Konzept und die Verwendung des Morph‑Übergangs. Um den Morph‑Übergang effektiv zu nutzen, benötigen Sie zwei Folien mit mindestens einem gemeinsamen Objekt. Der einfachste Weg besteht darin, die Folie zu duplizieren und das Objekt auf der zweiten Folie an eine andere Position zu verschieben.

Das folgende Code‑Snippet zeigt, wie man eine Kopie der Folie mit etwas Text zur Präsentation hinzufügt und für die zweite Folie einen Übergang des [Morph‑Typ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TransitionType) festlegt.
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


## **Morph‑Übergangstypen**
Das neue [TransitionMorphType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TransitionMorphType)‑Enum wurde hinzugefügt. Es stellt verschiedene Typen des Morph‑Folienübergangs dar.

Das TransitionMorphType‑Enum hat drei Mitglieder:

- ByObject: Der Morph‑Übergang wird unter Berücksichtigung der Formen als unteilbare Objekte ausgeführt.
- ByWord: Der Morph‑Übergang wird durchgeführt, indem der Text nach Möglichkeit wortweise übertragen wird.
- ByChar: Der Morph‑Übergang wird durchgeführt, indem der Text nach Möglichkeit zeichenweise übertragen wird.

Das folgende Code‑Snippet zeigt, wie man den Morph‑Übergang für eine Folie festlegt und den Morph‑Typ ändert:
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
Aspose.Slides für Android via Java unterstützt das Festlegen von Übergangseffekten wie „From Black“, „From Left“, „From Right“ usw. Um den Übergangseffekt festzulegen, folgen Sie bitte den untenstehenden Schritten:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
- Holen Sie sich die Referenz der Folie.
- Setzen Sie den Übergangseffekt.
- Schreiben Sie die Präsentation als [PPTX](https://docs.fileformat.com/presentation/pptx/)‑Datei.

Im nachfolgenden Beispiel haben wir die Übergangseffekte festgelegt.
```java
// Erstelle eine Instanz der Presentation-Klasse
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

Ja. Setzen Sie die [speed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowtransition/#setSpeed-int-) des Übergangs mittels der [TransitionSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionspeed/) Einstellung (z. B. langsam/mittel/schnell).

**Kann ich einer Transition Audio anhängen und sie wiederholen lassen?**

Ja. Sie können einen Ton für den Übergang einbetten und das Verhalten über Einstellungen wie Sound‑Modus und Schleife steuern (z. B. [setSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), sowie Metadaten wie [setSoundIsBuiltIn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) und [setSoundName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)).

**Was ist der schnellste Weg, denselben Übergang auf jede Folie anzuwenden?**

Konfigurieren Sie den gewünschten Übergangstyp in den Übergangseinstellungen jeder Folie; Übergänge werden pro Folie gespeichert, sodass das Anwenden desselben Typs auf alle Folien ein konsistentes Ergebnis liefert.

**Wie kann ich prüfen, welcher Übergang derzeit auf einer Folie eingestellt ist?**

Untersuchen Sie die [transition settings](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getSlideShowTransition--) der Folie und lesen Sie den [transition type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowtransition/#setType-int-); dieser Wert gibt genau an, welcher Effekt angewendet ist.