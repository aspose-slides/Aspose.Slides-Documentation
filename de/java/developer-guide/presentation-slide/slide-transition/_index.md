---
title: Folienübergänge in Präsentationen mit Java verwalten
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

Dieser Artikel erklärt, wie Folienübergänge in Präsentationen mit Aspose.Slides verwaltet werden. Er zeigt, wie Übergangstypen auf Folien angewendet, das Übergangsverhalten (z. B. Weiterblättern bei Mausklick oder nach einer festgelegten Zeit) konfiguriert, automatisches Weiterblättern geprüft und deaktiviert, der Morph‑Übergang und dessen Typen verwendet sowie Optionen für Übergangseffekte festgelegt werden. Die Beispiele demonstrieren, wie eine Präsentation geladen oder erstellt, Übergangseinstellungen für ausgewählte Folien geändert und das Ergebnis als PPTX‑Datei gespeichert wird. Der Artikel beantwortet zudem häufige Fragen zu Übergangsgeschwindigkeit, Übergangstönen, dem Anwenden desselben Übergangs auf mehrere Folien und dem Prüfen des aktuell eingestellten Übergangs einer Folie.

## **Folienübergang hinzufügen**
Um einen einfachen Folienübergangseffekt zu erstellen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation).
2. Wenden Sie einen Folienübergangstyp auf die Folie an, indem Sie einen der von Aspose.Slides für Java angebotenen Übergangseffekte über das TransitionType‑Enum verwenden.
3. Schreiben Sie die geänderte Präsentationsdatei.

```java
import com.aspose.slides.*;

// Instanziieren der Presentation-Klasse, um die Quellpräsentationsdatei zu laden
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Kreisförmigen Übergang auf Folie 1 anwenden
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Sägezahn‑Übergang auf Folie 2 anwenden
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // Präsentation auf Festplatte schreiben
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Erweiterten Folienübergang hinzufügen**
Im vorherigen Abschnitt haben wir nur einen einfachen Übergangseffekt auf die Folie angewendet. Um diesen einfachen Effekt weiter zu verbessern und zu steuern, gehen Sie bitte wie folgt vor:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation).
2. Wenden Sie einen Folienübergangstyp auf die Folie an, indem Sie einen der von Aspose.Slides für Java angebotenen Übergangseffekte auswählen.
3. Sie können den Übergang auch so einstellen, dass er bei Klick, nach einem bestimmten Zeitraum oder beides fortschreitet.
4. Wenn der Folienübergang auf „Weiter bei Klick“ eingestellt ist, erfolgt das Weiterblättern nur, wenn jemand die Maus anklickt. Ist die Eigenschaft „Weiter nach Zeit“ gesetzt, wird der Übergang automatisch nach Ablauf der angegebenen Zeit fortgesetzt.
5. Speichern Sie die geänderte Präsentation als Präsentationsdatei.

```java
import com.aspose.slides.*;

// Instanziieren der Presentation-Klasse, die eine Präsentationsdatei repräsentiert
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // Kreisförmigen Übergang auf Folie 1 anwenden
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Übergangszeit von 3 Sekunden festlegen
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // Sägezahn‑Übergang auf Folie 2 anwenden
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // Übergangszeit von 5 Sekunden festlegen
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // Zoom‑Übergang auf Folie 3 anwenden
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // Übergangszeit von 7 Sekunden festlegen
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // Präsentation auf Festplatte schreiben
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Morph‑Übergang**
{{% alert color="info" %}} 

Aspose.Slides for Java unterstützt jetzt den [Morph Transition](https://reference.aspose.com/slides/de/java/com.aspose.slides/IMorphTransition). Er repräsentiert den neuen Morph‑Übergang, der in PowerPoint 2019 eingeführt wurde.

{{% /alert %}} 

Der Morph‑Übergang ermöglicht es, eine sanfte Bewegung von einer Folie zur nächsten zu animieren. Dieser Artikel beschreibt das Konzept und die Anwendung des Morph‑Übergangs. Damit der Morph‑Übergang effektiv genutzt werden kann, benötigen Sie zwei Folien mit mindestens einem gemeinsamen Objekt. Am einfachsten ist es, die Folie zu duplizieren und das Objekt auf der zweiten Folie an eine andere Position zu verschieben.

Der folgende Code‑Abschnitt zeigt, wie Sie eine Kopie der Folie mit etwas Text zur Präsentation hinzufügen und der zweiten Folie einen [morph type](https://reference.aspose.com/slides/de/java/com.aspose.slides/TransitionType)-Übergang zuweisen.

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
Ein neues Enum [TransitionMorphType](https://reference.aspose.com/slides/de/java/com.aspose.slides/TransitionMorphType) wurde hinzugefügt. Es repräsentiert verschiedene Typen des Morph‑Folienübergangs.

Das Enum TransitionMorphType verfügt über drei Mitglieder:

- ByObject: Der Morph‑Übergang wird unter Berücksichtigung der Formen als unteilbare Objekte durchgeführt.
- ByWord: Der Morph‑Übergang wird nach Möglichkeit mit Wort‑zu‑Wort‑Übertragung des Textes durchgeführt.
- ByChar: Der Morph‑Übergang wird nach Möglichkeit mit Zeichen‑zu‑Zeichen‑Übertragung des Textes durchgeführt.

Der folgende Code‑Abschnitt zeigt, wie Sie den Morph‑Übergang für eine Folie festlegen und den Morph‑Typ ändern:

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
Aspose.Slides for Java unterstützt das Festlegen von Übergangseffekten wie „von Schwarz“, „von links“, „von rechts“ usw. Um den Übergangseffekt zu setzen, gehen Sie bitte wie folgt vor:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation).
- Holen Sie die Referenz der Folie.
- Setzen Sie den Übergangseffekt.
- Schreiben Sie die Präsentation als [PPTX](https://docs.fileformat.com/presentation/pptx/)‑Datei.

Im nachstehenden Beispiel haben wir die Übergangseffekte gesetzt.

```java
import com.aspose.slides.*;

// Instanz der Presentation-Klasse erstellen
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Effekt festlegen
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // Präsentation auf Festplatte schreiben
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

### Kann ich die Wiedergabegeschwindigkeit eines Folienübergangs steuern?

Ja. Setzen Sie die [speed](https://reference.aspose.com/slides/de/java/com.aspose.slides/slideshowtransition/#setSpeed-int-) des Übergangs über die Einstellung [TransitionSpeed](https://reference.aspose.com/slides/de/java/com.aspose.slides/transitionspeed/) (z. B. langsam/mittel/schnell).

### Kann ich einem Übergang Audio anhängen und es in einer Schleife wiedergeben?

Ja. Sie können einen Sound für den Übergang einbetten und das Verhalten über Einstellungen wie Sound‑Modus und Schleife steuern (z. B. [setSound](https://reference.aspose.com/slides/de/java/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/de/java/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/de/java/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), zusätzlich Metadaten wie [setSoundIsBuiltIn](https://reference.aspose.com/slides/de/java/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) und [setSoundName](https://reference.aspose.com/slides/de/java/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)).

### Was ist der schnellste Weg, denselben Übergang auf jede Folie anzuwenden?

Konfigurieren Sie den gewünschten Übergangstyp in den Übergangseinstellungen jeder Folie; Übergänge werden pro Folie gespeichert, sodass das Anwenden desselben Typs auf alle Folien ein konsistentes Ergebnis liefert.

### Wie kann ich prüfen, welcher Übergang aktuell auf einer Folie eingestellt ist?

Untersuchen Sie die [transition settings](https://reference.aspose.com/slides/de/java/com.aspose.slides/baseslide/#getSlideShowTransition--) der Folie und lesen Sie deren [transition type](https://reference.aspose.com/slides/de/java/com.aspose.slides/slideshowtransition/#setType-int-); dieser Wert gibt genau an, welcher Effekt angewendet wurde.