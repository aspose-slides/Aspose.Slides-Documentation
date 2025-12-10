---
title: Zugriff auf Präsentationsfolien in Java
linktitle: Zugriff auf Folie
type: docs
weight: 20
url: /de/java/access-slide-in-presentation/
keywords:
- Folienzugriff
- Folienindex
- Folien-ID
- Folienposition
- Position ändern
- Folieneigenschaften
- Foliennummer
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Folien in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Java zugreifen und verwalten können. Steigern Sie die Produktivität mit Codebeispielen."
---

Aspose.Slides ermöglicht den Zugriff auf Folien auf zwei Arten: über den Index und über die ID.

## **Zugriff auf eine Folie über den Index**

Alle Folien in einer Präsentation sind numerisch anhand ihrer Position angeordnet, beginnend bei 0. Die erste Folie ist über den Index 0 zugänglich; die zweite Folie wird über den Index 1 aufgerufen; usw.

Die Klasse Presentation, die eine Präsentationsdatei repräsentiert, stellt alle Folien als Sammlung von [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/) (Sammlung von [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/) Objekten) bereit. Dieser Java‑Code zeigt, wie Sie über den Index auf eine Folie zugreifen:
```java
// Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
Presentation pres = new Presentation("demo.pptx");
try {
    // Greift auf eine Folie über ihren Folienindex zu
    ISlide slide = pres.getSlides().get_Item(0);
} finally {
    pres.dispose();
}
```


## **Zugriff auf eine Folie über die ID**

Jede Folie in einer Präsentation besitzt eine eindeutige ID. Sie können die Methode [getSlideById](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlideById-long-) (bereitgestellt von der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)) verwenden, um diese ID anzusprechen. Dieser Java‑Code zeigt, wie Sie eine gültige Folien‑ID übergeben und die Folie mit der Methode [getSlideById](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlideById-long-) aufrufen:
```java
// Instanziert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
Presentation pres = new Presentation("demo.pptx");
try {
    // Holt eine Folien-ID
    int id = (int) pres.getSlides().get_Item(0).getSlideId();
    
    // Greift über die ID auf die Folie zu
    IBaseSlide slide = pres.getSlideById(id);
} finally {
    pres.dispose();
}
```


## **Folienposition ändern**

Aspose.Slides ermöglicht das Ändern der Position einer Folie. Zum Beispiel können Sie festlegen, dass die erste Folie zur zweiten Folie wird.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Holen Sie die Referenz der Folie (deren Position Sie ändern möchten) über ihren Index.
1. Setzen Sie eine neue Position für die Folie über die Eigenschaft [setSlideNumber](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#setSlideNumber-int-).
1. Speichern Sie die geänderte Präsentation.

Dieser Java‑Code demonstriert eine Operation, bei der die Folie an Position 1 nach Position 2 verschoben wird: 
```java
// Instanziert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Holt die Folie, deren Position geändert wird
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Setzt die neue Position für die Folie
    sld.setSlideNumber(2);
    
    // Speichert die geänderte Präsentation
    pres.save("helloworld_Pos.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


Die erste Folie wurde zur zweiten; die zweite Folie wurde zur ersten. Wenn Sie die Position einer Folie ändern, werden die anderen Folien automatisch angepasst.

## **Foliennummer festlegen**

Mit der Eigenschaft [setFirstSlideNumber](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-) (bereitgestellt von der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)) können Sie eine neue Nummer für die erste Folie einer Präsentation festlegen. Diese Operation veranlasst die Neuberechnung der anderen Foliennummern.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Holen Sie die Foliennummer.
1. Setzen Sie die Foliennummer.
1. Speichern Sie die geänderte Präsentation.

Dieser Java‑Code demonstriert eine Operation, bei der die erste Foliennummer auf 10 gesetzt wird: 
```java
// Instanziert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    // Holt die Foliennummer
    int firstSlideNumber = pres.getFirstSlideNumber();

    // Setzt die Foliennummer
    pres.setFirstSlideNumber(10);
	
    // Speichert die geänderte Präsentation
    pres.save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


Wenn Sie die erste Folie überspringen möchten, können Sie die Nummerierung ab der zweiten Folie beginnen (und die Nummerierung für die erste Folie ausblenden) wie folgt:
```java
Presentation presentation = new Presentation();
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    // Setzt die Nummer für die erste Folie der Präsentation
    presentation.setFirstSlideNumber(0);

    // Zeigt Foliennummern für alle Folien an
    presentation.getHeaderFooterManager().setAllSlideNumbersVisibility(true);

    // Blendet die Foliennummer für die erste Folie aus
    presentation.getSlides().get_Item(0).getHeaderFooterManager().setSlideNumberVisibility(false);

    // Speichert die geänderte Präsentation
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **FAQ**

**Entspricht die vom Benutzer sichtbare Foliennummer dem nullbasierten Index der Sammlung?**

Die auf einer Folie angezeigte Nummer kann bei einem beliebigen Wert beginnen (z. B. 10) und muss nicht mit dem Index übereinstimmen; die Beziehung wird durch die Einstellung der [ersten Foliennummer](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-) der Präsentation gesteuert.

**Wirken sich ausgeblendete Folien auf die Indizierung aus?**

Ja. Eine ausgeblendete Folie bleibt in der Sammlung und wird bei der Indizierung gezählt; „ausgeblendet“ bezieht sich auf die Anzeige, nicht auf ihre Position in der Sammlung.

**Ändert sich der Index einer Folie, wenn andere Folien hinzugefügt oder entfernt werden?**

Ja. Indizes spiegeln stets die aktuelle Reihenfolge der Folien wider und werden bei Einfüge-, Lösch‑ und Verschiebe‑Operationen neu berechnet.