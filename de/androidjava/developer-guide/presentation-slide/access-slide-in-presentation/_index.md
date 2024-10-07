---
title: Zugriff auf Folie in Präsentation
type: docs
weight: 20
url: /androidjava/access-slide-in-presentation/
keywords: "Zugriff auf PowerPoint-Präsentation, Zugriff auf Folie, Folieneigenschaften bearbeiten, Folienposition ändern, Foliennummer, Index, ID, Position Java, Aspose.Slides"
description: "Zugriff auf PowerPoint-Folie über Index, ID oder Position in Java. Folieneigenschaften bearbeiten"
---

Aspose.Slides ermöglicht es Ihnen, auf Folien auf zwei Arten zuzugreifen: über den Index und über die ID.

## **Zugriff auf Folie über Index**

Alle Folien in einer Präsentation sind numerisch basierend auf der Folienposition angeordnet, beginnend mit 0. Die erste Folie ist über den Index 0 zugänglich; die zweite Folie wird über den Index 1 aufgerufen; usw.

Die Klasse Presentation, die eine Präsentationsdatei darstellt, stellt alle Folien als eine [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/) Sammlung (Sammlung von [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) Objekten) zur Verfügung. Dieser Java-Code zeigt Ihnen, wie Sie auf eine Folie über ihren Index zugreifen:

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

## **Zugriff auf Folie über ID**

Jede Folie in einer Präsentation hat eine eindeutige ID, die mit ihr verknüpft ist. Sie können die [getSlideById](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlideById-long-) Methode (bereitgestellt von der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) Klasse) verwenden, um diese ID anzusteuern. Dieser Java-Code zeigt, wie Sie eine gültige Folien-ID angeben und auf diese Folie über die [getSlideById](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlideById-long-) Methode zugreifen:

```java
// Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
Presentation pres = new Presentation("demo.pptx");
try {
    // Ruft eine Folien-ID ab
    int id = (int) pres.getSlides().get_Item(0).getSlideId();
    
    // Greift auf die Folie über ihre ID zu
    IBaseSlide slide = pres.getSlideById(id);
} finally {
    pres.dispose();
}
```

## **Folienposition ändern**

Aspose.Slides ermöglicht es Ihnen, die Position einer Folie zu ändern. Zum Beispiel können Sie festlegen, dass die erste Folie zur zweiten Folie werden soll.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) Klasse.
1. Holen Sie sich die Referenz auf die Folie (deren Position Sie ändern möchten) über ihren Index.
1. Setzen Sie eine neue Position für die Folie über die [setSlideNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#setSlideNumber-int-) Eigenschaft.
1. Speichern Sie die modifizierte Präsentation.

Dieser Java-Code zeigt einen Vorgang, bei dem die Folie an Position 1 auf Position 2 verschoben wird:

```java
// Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Ruft die Folie ab, deren Position geändert wird
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Setzt die neue Position für die Folie
    sld.setSlideNumber(2);
    
    // Speichert die modifizierte Präsentation
    pres.save("helloworld_Pos.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Die erste Folie wurde zur zweiten; die zweite Folie wurde zur ersten. Wenn Sie die Position einer Folie ändern, werden andere Folien automatisch angepasst.

## **Foliennummer setzen**

Mit der [setFirstSlideNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) Eigenschaft (bereitgestellt von der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) Klasse) können Sie eine neue Nummer für die erste Folie in einer Präsentation festlegen. Dieser Vorgang führt dazu, dass andere Foliennummern neu berechnet werden.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) Klasse.
1. Holen Sie sich die Foliennummer.
1. Setzen Sie die Foliennummer.
1. Speichern Sie die modifizierte Präsentation.

Dieser Java-Code zeigt einen Vorgang, bei dem die erste Foliennummer auf 10 gesetzt wird:

```java
// Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    // Ruft die Foliennummer ab
    int firstSlideNumber = pres.getFirstSlideNumber();

    // Setzt die Foliennummer
    pres.setFirstSlideNumber(10);
	
    // Speichert die modifizierte Präsentation
    pres.save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Wenn Sie die erste Folie überspringen möchten, können Sie die Nummerierung von der zweiten Folie aus starten (und die Nummerierung für die erste Folie ausblenden) auf diese Weise:

```java
Presentation presentation = new Presentation();
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    // Setzt die Nummer für die erste Präsentationsfolie
    presentation.setFirstSlideNumber(0);

    // Zeigt Foliennummern für alle Folien an
    presentation.getHeaderFooterManager().setAllSlideNumbersVisibility(true);

    // Blendert die Foliennummer für die erste Folie aus
    presentation.getSlides().get_Item(0).getHeaderFooterManager().setSlideNumberVisibility(false);

    // Speichert die modifizierte Präsentation
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```