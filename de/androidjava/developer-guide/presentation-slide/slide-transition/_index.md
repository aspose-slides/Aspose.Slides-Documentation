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
- Erweiterter Folienübergang
- Morph-Übergang
- Übergangstyp
- Übergangseffekt
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Folienübergänge in Aspose.Slides für Android via Java individuell anpassen, mit Schritt-für-Schritt-Anleitungen für PowerPoint- und OpenDocument-Präsentationen."
---
## **Übersicht**

Dieser Artikel erklärt, wie Sie Folienübergänge in Präsentationen mithilfe von Aspose.Slides verwalten. Er zeigt, wie Sie Übergangstypen auf Folien anwenden, das Verhalten des Übergangs konfigurieren, z. B. das Vorwärtsschalten per Klick oder nach einer festgelegten Zeit, den Morph‑Übergang und dessen Typen verwenden sowie Optionen für den Übergangseffekt festlegen. Die Beispiele demonstrieren, wie eine Präsentation geladen oder erstellt, die Übergangseinstellungen für ausgewählte Folien geändert und das Ergebnis als PPTX‑Datei gespeichert wird. Der Artikel beantwortet außerdem häufige Fragen zur Übergangsgeschwindigkeit, zu Übergangstönen, zur Anwendung desselben Übergangs auf mehrere Folien und zur Überprüfung des aktuell für eine Folie festgelegten Übergangs.

## **Folienübergang hinzufügen**
Um einen einfachen Folienübergangseffekt zu erstellen, führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation) Klasse.
2. Wenden Sie einen Folienübergangstyp auf die Folie an, indem Sie einen der von Aspose.Slides für Android via Java über das TransitionType‑Enum angebotenen Übergangseffekte auswählen.
3. Schreiben Sie die modifizierte Präsentationsdatei.

```java
import com.aspose.slides.*;

// Instanziiere die Presentation-Klasse, um die Quellpräsentationsdatei zu laden
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Kreis‑Übergang auf Folie 1 anwenden
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Kamm‑Übergang auf Folie 2 anwenden
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // Präsentation auf die Festplatte schreiben
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Erweiterten Folienübergang hinzufügen**
Im obigen Abschnitt haben wir lediglich einen einfachen Übergangseffekt auf die Folie angewendet. Um diesen einfachen Übergang jetzt noch besser und kontrollierter zu machen, führen Sie bitte die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation) Klasse.
2. Wenden Sie einen Folienübergangstyp auf die Folie an, indem Sie einen der von Aspose.Slides für Android via Java angebotenen Übergangseffekte auswählen.
3. Sie können den Übergang auch so einstellen, dass er per Klick fortschreitet, nach einem bestimmten Zeitraum oder beides.
4. Wenn der Folienübergang so konfiguriert ist, dass er per Klick fortschreitet, wird der Übergang nur weiterlaufen, wenn jemand mit der Maus klickt. Wenn zudem die Eigenschaft Advance After Time gesetzt ist, schreitet der Übergang automatisch nach Ablauf der angegebenen Zeit vor.
5. Schreiben Sie die modifizierte Präsentation als Präsentationsdatei.

```java
import com.aspose.slides.*;

// Instanziiere die Presentation-Klasse, die eine Präsentationsdatei darstellt
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // Kreis‑Übergang auf Folie 1 anwenden
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Beim Klick oder automatisch nach 3 Sekunden vorwärts
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // Kamm‑Übergang auf Folie 2 anwenden
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // Beim Klick oder automatisch nach 5 Sekunden vorwärts
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // Zoom‑Übergang auf Folie 3 anwenden
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // Beim Klick oder automatisch nach 7 Sekunden vorwärts
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // Präsentation auf die Festplatte schreiben
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Morph‑Übergang**
{{% alert color="info" %}} 
Aspose.Slides für Android via Java unterstützt jetzt den [Morph-Übergang](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IMorphTransition). Sie stellen den neuen Morph‑Übergang vor, der in PowerPoint 2019 eingeführt wurde.
{{% /alert %}} 

Der Morph‑Übergang ermöglicht es, eine gleichmäßige Bewegung von einer Folie zur nächsten zu animieren. Dieser Artikel beschreibt das Konzept und die Verwendung des Morph‑Übergangs. Um den Morph‑Übergang effektiv zu nutzen, benötigen Sie zwei Folien, die mindestens ein gemeinsames Objekt aufweisen. Der einfachste Weg ist, die Folie zu duplizieren und das Objekt auf der zweiten Folie an eine andere Position zu verschieben.

Das folgende Code‑Snippet zeigt, wie Sie eine Kopie der Folie mit etwas Text zur Präsentation hinzufügen und der zweiten Folie einen Übergang vom [Morph‑Typ](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/TransitionType) zuweisen.

```java
import com.aspose.slides.*;

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
Ein neuer Enum [TransitionMorphType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/TransitionMorphType) wurde hinzugefügt. Er repräsentiert verschiedene Typen des Morph‑Folienübergangs.

Der TransitionMorphType‑Enum hat drei Mitglieder:

- ByObject: Der Morph‑Übergang wird unter Berücksichtigung von Formen als unteilbare Objekte durchgeführt.
- ByWord: Der Morph‑Übergang wird, wo möglich, durch Übertragen von Text Wort für Wort durchgeführt.
- ByChar: Der Morph‑Übergang wird, wo möglich, durch Übertragen von Text Zeichen für Zeichen durchgeführt.

Das folgende Code‑Snippet zeigt, wie Sie den Morph‑Übergang für eine Folie festlegen und den Morph‑Typ ändern:

```java
import com.aspose.slides.*;

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
Aspose.Slides für Android via Java unterstützt das Festlegen von Übergangseffekten wie von Schwarz, von links, von rechts usw. Um den Übergangseffekt festzulegen, führen Sie bitte die folgenden Schritte aus:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation) Klasse.
- Holen Sie die Referenz der Folie.
- Legen Sie den Übergangseffekt fest.
- Schreiben Sie die Präsentation als [PPTX ](https://docs.fileformat.com/presentation/pptx/) Datei.

Im folgenden Beispiel haben wir die Übergangseffekte festgelegt.

```java
import com.aspose.slides.*;

// Instanz der Presentation-Klasse erstellen
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Effekt einstellen
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // Präsentation auf die Festplatte schreiben
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

### Kann ich die Wiedergabegeschwindigkeit eines Folienübergangs steuern?

Ja. Setzen Sie die [Geschwindigkeit](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/slideshowtransition/#setSpeed-int-) des Übergangs über die Einstellung [TransitionSpeed](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/transitionspeed/) (z. B. langsam/mittel/schnell).

### Kann ich einem Übergang Audio hinzufügen und eine Schleife aktivieren?

Ja. Sie können für den Übergang einen Klang einbetten und das Verhalten über Einstellungen wie Soundmodus und Schleife steuern (z. B. [setSound](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), plus Metadaten wie [setSoundIsBuiltIn](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) und [setSoundName](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)).

### Was ist der schnellste Weg, denselben Übergang auf jede Folie anzuwenden?

Konfigurieren Sie den gewünschten Übergangstyp in den Übergangseinstellungen jeder Folie; Übergänge werden pro Folie gespeichert, sodass das Anwenden desselben Typs auf alle Folien ein konsistentes Ergebnis liefert.

### Wie kann ich prüfen, welcher Übergang derzeit für eine Folie eingestellt ist?

Untersuchen Sie die [Übergangseinstellungen](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/baseslide/#getSlideShowTransition--) der Folie und lesen Sie deren [Übergangstyp](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/slideshowtransition/#setType-int-); dieser Wert gibt Ihnen genau an, welcher Effekt angewendet wurde.