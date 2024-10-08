--- 
title: Folienübergang 
type: docs 
weight: 80 
url: /de/java/slide-transition/ 
keywords: "PowerPoint Folienübergang, Morphübergang in Java" 
description: "PowerPoint Folienübergang, PowerPoint Morphübergang in Java" 
--- 

## **Übersicht** 
{{% alert color="primary" %}} 

Aspose.Slides für Java ermöglicht Entwicklern auch die Verwaltung oder Anpassung der Folienübergangseffekte der Folien. In diesem Thema werden wir diskutieren, wie man Folienübergänge mit großer Leichtigkeit mithilfe von Aspose.Slides für Java steuert. 

{{% /alert %}} 

Um das Verständnis zu erleichtern, haben wir die Verwendung von Aspose.Slides für Java zur Verwaltung einfacher Folienübergänge demonstriert. Entwickler können nicht nur verschiedene Folienübergangseffekte auf den Folien anwenden, sondern auch das Verhalten dieser Übergangseffekte anpassen. 

## **Folienübergang hinzufügen** 
Um einen einfachen Folienübergangseffekt zu erstellen, befolgen Sie die folgenden Schritte: 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) Klasse. 
1. Wenden Sie einen Folienübergangstyp auf die Folie aus einem der von Aspose.Slides für Java angebotenen Übergangseffekte über das TransitionType-Enum an. 
1. Schreiben Sie die modifizierte Präsentationsdatei. 

```java 
// Instanziieren Sie die Presentation-Klasse, um die Quellpräsentationsdatei zu laden 
Presentation presentation = new Presentation("AccessSlides.pptx"); 
try { 
    // Wenden Sie den Übergangstyp Kreis auf Folie 1 an 
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle); 

    // Wenden Sie den Übergangstyp Kamm auf Folie 2 an 
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb); 

    // Schreiben Sie die Präsentation auf die Festplatte 
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx); 
} finally { 
    presentation.dispose(); 
} 
``` 

## **Erweiterter Folienübergang hinzufügen** 
Im obigen Abschnitt haben wir nur einen einfachen Übergangseffekt auf die Folie angewendet. Um diesen einfachen Übergangseffekt noch besser und kontrollierter zu gestalten, befolgen Sie bitte die folgenden Schritte: 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) Klasse. 
1. Wenden Sie einen Folienübergangstyp auf die Folie aus einem der von Aspose.Slides für Java angebotenen Übergangseffekte an. 
1. Sie können auch den Übergang auf „Bei Klick fortsetzen“, nach einem bestimmten Zeitintervall oder beides einstellen. 
1. Wenn der Folienübergang auf „Bei Klick fortsetzen“ aktiviert ist, wird der Übergang nur fortgesetzt, wenn jemand mit der Maus klickt. Wenn zudem die Eigenschaft „Nach Zeit fortsetzen“ eingestellt ist, wird der Übergang automatisch nach der angegebenen Vorlaufzeit fortgesetzt. 
1. Schreiben Sie die modifizierte Präsentation als Präsentationsdatei. 

```java 
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei repräsentiert 
Presentation pres = new Presentation("BetterSlideTransitions.pptx"); 
try { 
    // Wenden Sie den Übergangstyp Kreis auf Folie 1 an 
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle); 

    // Setzen Sie die Übergangszeit auf 3 Sekunden 
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true); 
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000); 

    // Wenden Sie den Übergangstyp Kamm auf Folie 2 an 
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb); 
    
    // Setzen Sie die Übergangszeit auf 5 Sekunden 
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true); 
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000); 

    // Wenden Sie den Übergangstyp Zoom auf Folie 3 an 
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

## **Morphübergang** 
{{% alert color="primary" %}} 

Aspose.Slides für Java unterstützt jetzt den [Morphübergang](https://reference.aspose.com/slides/java/com.aspose.slides/IMorphTransition). Dieser stellt einen neuen Morphübergang dar, der in PowerPoint 2019 eingeführt wurde. 

{{% /alert %}} 

Der Morphübergang ermöglicht es Ihnen, eine sanfte Bewegung von einer Folie zur nächsten zu animieren. Dieser Artikel beschreibt das Konzept und wie man den Morphübergang verwendet. Um den Morphübergang effektiv zu nutzen, benötigen Sie zwei Folien mit mindestens einem gemeinsamen Objekt. Der einfachste Weg ist, die Folie zu duplizieren und das Objekt auf der zweiten Folie an einen anderen Ort zu verschieben. 

Der folgende Codeausschnitt zeigt Ihnen, wie Sie einen Klon der Folie mit etwas Text zur Präsentation hinzufügen und einen Übergang vom [Morphtyp](https://reference.aspose.com/slides/java/com.aspose.slides/TransitionType) zur zweiten Folie einstellen. 

```java 
Presentation presentation = new Presentation(); 
try { 
    AutoShape autoshape = (AutoShape)presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100); 
    autoshape.getTextFrame().setText("Morphübergang in PowerPoint-Präsentationen"); 

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

## **Morphübergangstypen** 
Ein neues [TransitionMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/TransitionMorphType) enum wurde hinzugefügt. Es repräsentiert verschiedene Arten von Morph-Folienübergängen. 

Das TransitionMorphType-Enum hat drei Mitglieder: 

- ByObject: Der Morphübergang wird unter Berücksichtigung der Formen als unteilbare Objekte durchgeführt. 
- ByWord: Der Morphübergang wird durchgeführt, indem Text, wo möglich, nach Wörtern übertragen wird. 
- ByChar: Der Morphübergang wird durchgeführt, indem Text, wo möglich, nach Zeichen übertragen wird. 

Der folgende Codeausschnitt zeigt Ihnen, wie Sie den Morphübergang auf die Folie einstellen und den Morphtyp ändern: 

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
Aspose.Slides für Java unterstützt das Festlegen von Übergangseffekten wie von Schwarz, von links, von rechts usw. Um den Übergangseffekt festzulegen, befolgen Sie bitte die folgenden Schritte: 

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse. 
- Holen Sie sich das Referenzobjekt der Folie. 
- Übergangseffekt festlegen. 
- Schreiben Sie die Präsentation als [PPTX](https://docs.fileformat.com/presentation/pptx/) Datei. 

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