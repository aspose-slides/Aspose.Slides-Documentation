---
title: Folienübergang
type: docs
weight: 80
url: /androidjava/slide-transition/
keywords: "PowerPoint Folienübergang, Morph-Übergang in Java"
description: "PowerPoint Folienübergang, PowerPoint Morph-Übergang in Java"
---


## **Überblick**
{{% alert color="primary" %}} 

Aspose.Slides für Android über Java ermöglicht es Entwicklern, die Folienübergangseffekte der Folien zu verwalten oder anzupassen. In diesem Thema werden wir erörtern, wie Folienübergänge mit großer Leichtigkeit mithilfe von Aspose.Slides für Android über Java gesteuert werden können.

{{% /alert %}} 

Um das Verständnis zu erleichtern, haben wir die Verwendung von Aspose.Slides für Android über Java zur Verwaltung einfacher Folienübergänge demonstriert. Entwickler können nicht nur verschiedene Folienübergangseffekte auf die Folien anwenden, sondern auch das Verhalten dieser Übergangseffekte anpassen.

## **Folienübergang hinzufügen**
Um einen einfachen Folienübergangseffekt zu erstellen, befolgen Sie die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) Klasse.
1. Wenden Sie einen Folienübergangstyp auf die Folie an, aus einem der von Aspose.Slides für Android über Java angebotenen Übergangseffekte durch das TransitionType-Enum.
1. Schreiben Sie die modifizierte Präsentationsdatei.

```java
// Instanziieren Sie die Presentation-Klasse zum Laden der Quellpräsentationsdatei
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Wenden Sie den Übergang des Typus Kreis auf Folie 1 an
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Wenden Sie den Übergang des Typus Kombi auf Folie 2 an
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // Schreiben Sie die Präsentation auf die Festplatte
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Erweiterten Folienübergang hinzufügen**
Im obigen Abschnitt haben wir nur einen einfachen Übergangseffekt auf die Folie angewendet. Um diesen einfachen Übergangseffekt noch besser und kontrollierbarer zu gestalten, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) Klasse.
1. Wenden Sie einen Folienübergangstyp auf die Folie an, aus einem der von Aspose.Slides für Android über Java angebotenen Übergangseffekte.
1. Sie können den Übergang auch auf "Bei Klick fortsetzen", nach einem bestimmten Zeitraum oder beides setzen.
1. Wenn der Folienübergang auf "Bei Klick fortsetzen" aktiviert ist, wird der Übergang nur vorangetrieben, wenn jemand mit der Maus klickt. Darüber hinaus wird der Übergang automatisch fortschreiten, wenn die Eigenschaft "Nach Zeit fortschreiten" gesetzt ist und die angegebene Zeit vergangen ist.
1. Schreiben Sie die modifizierte Präsentation als Präsentationsdatei.

```java
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // Wenden Sie den Übergang des Typus Kreis auf Folie 1 an
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Setzen Sie die Übergangszeit auf 3 Sekunden
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // Wenden Sie den Übergang des Typus Kombi auf Folie 2 an
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // Setzen Sie die Übergangszeit auf 5 Sekunden
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // Wenden Sie den Übergang des Typus Zoom auf Folie 3 an
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // Setzen Sie die Übergangszeit auf 7 Sekunden
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // Schreiben Sie die Präsentation auf die Festplatte
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Morph-Übergang**
{{% alert color="primary" %}} 

Aspose.Slides für Android über Java unterstützt jetzt den [Morph-Übergang](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMorphTransition). Sie repräsentieren den neuen Morph-Übergang, der in PowerPoint 2019 eingeführt wurde.

{{% /alert %}} 

Der Morph-Übergang ermöglicht es Ihnen, eine flüssige Bewegung von einer Folie zur nächsten zu animieren. Dieser Artikel beschreibt das Konzept und wie man den Morph-Übergang verwendet. Um den Morph-Übergang effektiv zu nutzen, benötigen Sie zwei Folien mit mindestens einem gemeinsamen Objekt. Der einfachste Weg ist, die Folie zu duplizieren und das Objekt auf der zweiten Folie an einen anderen Ort zu verschieben.

Der folgende Codeausschnitt zeigt, wie Sie eine Kopie der Folie mit etwas Text zur Präsentation hinzufügen und einen [Morph-Typ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TransitionType) für die zweite Folie festlegen.

```java
Presentation presentation = new Presentation();
try {
    AutoShape autoshape = (AutoShape)presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("Morph-Übergang in PowerPoint-Präsentationen");

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
Das neue [TransitionMorphType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TransitionMorphType) Enum wurde hinzugefügt. Es repräsentiert verschiedene Typen von Morph-Folienübergängen.

Das TransitionMorphType-Enum hat drei Mitglieder:

- ByObject: Der Morph-Übergang wird unter Berücksichtigung von Formen als unteilbare Objekte durchgeführt.
- ByWord: Der Morph-Übergang wird mit dem Übertragen von Text nach Wörtern durchgeführt, wo möglich.
- ByChar: Der Morph-Übergang wird mit dem Übertragen von Text nach Zeichen durchgeführt, wo möglich.

Der folgende Codeausschnitt zeigt, wie Sie den Morph-Übergang auf eine Folie anwenden und den Morph-Typ ändern:

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
Aspose.Slides für Android über Java unterstützt das Festlegen von Übergangseffekten wie, von Schwarz, von links, von rechts usw. Um den Übergangseffekt festzulegen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
- Holen Sie sich die Referenz der Folie.
- Festlegen des Übergangseffekts.
- Schreiben Sie die Präsentation als [PPTX ](https://docs.fileformat.com/presentation/pptx/)Datei.

Im folgenden Beispiel haben wir die Übergangseffekte festgelegt.

```java
// Erstellen Sie eine Instanz der Presentation-Klasse
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Effekt festlegen
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // Schreiben Sie die Präsentation auf die Festplatte
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```