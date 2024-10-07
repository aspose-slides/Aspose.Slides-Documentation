---
title: Folie aus Präsentation entfernen
type: docs
weight: 30
url: /androidjava/remove-slide-from-presentation/
keywords: "Folie entfernen, Folie löschen, PowerPoint, Präsentation, Java, Aspose.Slides"
description: "Folie aus PowerPoint nach Referenz oder Index in Java entfernen"

---

Wenn eine Folie (oder deren Inhalte) überflüssig wird, können Sie sie löschen. Aspose.Slides stellt die [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) Klasse bereit, die [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/) kapselt, die ein Repository für alle Folien in einer Präsentation ist. Mit Zeigern (Referenz oder Index) für ein bekanntes [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) Objekt können Sie die Folie angeben, die Sie entfernen möchten.

## **Folie nach Referenz entfernen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) Klasse.
1. Holen Sie sich eine Referenz der Folie, die Sie entfernen möchten, über deren ID oder Index.
1. Entfernen Sie die referenzierte Folie aus der Präsentation.
1. Speichern Sie die modifizierte Präsentation.

Dieser Java-Code zeigt Ihnen, wie Sie eine Folie über ihre Referenz entfernen:

```java
// Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei repräsentiert
Presentation pres = new Presentation("demo.pptx");
try {
    // Greift auf eine Folie über ihren Index in der Folienkollektion zu
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Entfernt eine Folie über ihre Referenz
    pres.getSlides().remove(slide);
    
    // Speichert die modifizierte Präsentation
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Folie nach Index entfernen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) Klasse.
1. Entfernen Sie die Folie aus der Präsentation über ihre Indexposition.
1. Speichern Sie die modifizierte Präsentation.

Dieser Java-Code zeigt Ihnen, wie Sie eine Folie über ihren Index entfernen:

```java
// Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei repräsentiert
Presentation pres = new Presentation("demo.pptx");
try {
    // Entfernt eine Folie über ihren Folienindex
    pres.getSlides().removeAt(0);
    
    // Speichert die modifizierte Präsentation
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Nicht verwendete Layoutfolie entfernen**

Aspose.Slides stellt die [removeUnusedLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) Methode (aus der [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/) Klasse) bereit, um unerwünschte und nicht verwendete Layoutfolien zu löschen. Dieser Java-Code zeigt Ihnen, wie Sie eine Layoutfolie aus einer PowerPoint-Präsentation entfernen:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.removeUnusedLayoutSlides(pres);

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Nicht verwendete Masterfolie entfernen**

Aspose.Slides stellt die [removeUnusedMasterSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) Methode (aus der [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/) Klasse) bereit, um unerwünschte und nicht verwendete Masterfolien zu löschen. Dieser Java-Code zeigt Ihnen, wie Sie eine Masterfolie aus einer PowerPoint-Präsentation entfernen:

```java
Presentation pres = new Presentation("pres.pptx");
 try {
     Compress.removeUnusedMasterSlides(pres);

     pres.save("pres-out.pptx", SaveFormat.Pptx);
 } finally {
     if (pres != null) pres.dispose();
 }
```