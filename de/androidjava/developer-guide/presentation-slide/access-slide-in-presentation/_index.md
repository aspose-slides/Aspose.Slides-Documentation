---
title: Zugriff auf Präsentationsfolien unter Android
linktitle: Zugriff auf Folie
type: docs
weight: 20
url: /de/androidjava/access-slide-in-presentation/
keywords:
- Folie zugreifen
- Folienindex
- Folien-ID
- Folienposition
- Position ändern
- Folieneigenschaften
- Foliennummer
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Folien in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Android zugreifen und verwalten können. Steigern Sie die Produktivität mit Java-Codebeispielen."
---

Aspose.Slides ermöglicht den Zugriff auf Folien auf zwei Arten: über den Index und über die ID.

## **Zugriff auf eine Folie über den Index**

Alle Folien in einer Präsentation sind numerisch nach ihrer Position angeordnet, beginnend bei 0. Die erste Folie ist über den Index 0 zugänglich; die zweite Folie über den Index 1; usw.

Die Klasse Presentation, die eine Präsentationsdatei repräsentiert, stellt alle Folien als Sammlung von [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/) (Sammlung von [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/)‑Objekten) bereit. Dieser Java‑Code zeigt, wie man über den Index auf eine Folie zugreift:
```java
// Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
Presentation pres = new Presentation("demo.pptx");
try {
    // Greift auf eine Folie zu, indem ihr Folienindex verwendet wird
    ISlide slide = pres.getSlides().get_Item(0);
} finally {
    pres.dispose();
}
```


## **Zugriff auf eine Folie über die ID**

Jede Folie in einer Präsentation hat eine eindeutige ID. Sie können die Methode [getSlideById](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlideById-long-) (bereitgestellt von der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)) verwenden, um diese ID anzusprechen. Dieser Java‑Code zeigt, wie man eine gültige Folien‑ID übergibt und die Folie über die Methode [getSlideById](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlideById-long-) aufruft:
```java
// Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
Presentation pres = new Presentation("demo.pptx");
try {
    // Ruft die Folien-ID ab
    int id = (int) pres.getSlides().get_Item(0).getSlideId();
    
    // Greift über die ID auf die Folie zu
    IBaseSlide slide = pres.getSlideById(id);
} finally {
    pres.dispose();
}
```


## **Ändern der Folienposition**

Aspose.Slides ermöglicht das Ändern einer Folienposition. Beispielsweise können Sie festlegen, dass die erste Folie zur zweiten Folie wird.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)‑Klasse.  
1. Holen Sie sich die Referenz der Folie (deren Position Sie ändern möchten) über deren Index.  
1. Setzen Sie eine neue Position für die Folie über die Eigenschaft [setSlideNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#setSlideNumber-int-).  
1. Speichern Sie die geänderte Präsentation.

Dieser Java‑Code demonstriert eine Operation, bei der die Folie an Position 1 zu Position 2 verschoben wird:
```java
// Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
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

## **Festlegen der Foliennummer**

Mit der Eigenschaft [setFirstSlideNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) (bereitgestellt von der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)) können Sie eine neue Nummer für die erste Folie einer Präsentation festlegen. Dieser Vorgang bewirkt, dass die anderen Foliennummern neu berechnet werden.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)‑Klasse.  
1. Holen Sie die Foliennummer.  
1. Setzen Sie die Foliennummer.  
1. Speichern Sie die geänderte Präsentation.

Dieser Java‑Code demonstriert eine Operation, bei der die erste Foliennummer auf 10 gesetzt wird:
```java
// Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    // Ermittelt die Foliennummer
    int firstSlideNumber = pres.getFirstSlideNumber();

    // Setzt die Foliennummer
    pres.setFirstSlideNumber(10);
	
    // Speichert die geänderte Präsentation
    pres.save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


Wenn Sie die erste Folie überspringen möchten, können Sie die Nummerierung ab der zweiten Folie beginnen (und die Nummerierung für die erste Folie ausblenden) auf folgende Weise:
```java
Presentation presentation = new Presentation();
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    // Setzt die Nummer für die erste Folie der Präsentation
    presentation.setFirstSlideNumber(0);

    // Zeigt die Foliennummern für alle Folien an
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

**Entspricht die von einem Benutzer gesehene Foliennummer dem nullbasierten Index der Sammlung?**

Die auf einer Folie angezeigte Nummer kann mit einem beliebigen Wert beginnen (z. B. 10) und muss nicht mit dem Index übereinstimmen; die Beziehung wird durch die Einstellung der [first slide number](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) der Präsentation gesteuert.

**Beeinflussen ausgeblendete Folien das Indexieren?**

Ja. Eine ausgeblendete Folie bleibt in der Sammlung und wird beim Indexieren gezählt; „ausgeblendet“ bezieht sich auf die Anzeige, nicht auf ihre Position in der Sammlung.

**Ändert sich der Index einer Folie, wenn andere Folien hinzugefügt oder entfernt werden?**

Ja. Indizes spiegeln stets die aktuelle Reihenfolge der Folien wider und werden bei Einfüge‑, Lösch‑ und Verschiebe‑Vorgängen neu berechnet.