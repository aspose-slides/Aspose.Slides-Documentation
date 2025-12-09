---
title: Verwalten von Tags und benutzerdefinierten Daten in Präsentationen mit Java
linktitle: Tags und benutzerdefinierte Daten
type: docs
weight: 300
url: /de/java/managing-tags-and-custom-data/
keywords:
- Dokumenteigenschaften
- Tag
- benutzerdefinierte Daten
- Tag hinzufügen
- Paarwerte
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Tags & benutzerdefinierte Daten in Aspose.Slides für Java hinzufügen, lesen, aktualisieren und entfernen, mit Beispielen für PowerPoint- und OpenDocument-Präsentationen."
---

## Datenspeicherung in Präsentationsdateien

PPTX‑Dateien - Elemente mit der Dateierweiterung .pptx - werden im PresentationML‑Format gespeichert, das Teil der Office Open XML‑Spezifikation ist. Das Office Open XML‑Format definiert die Struktur der in Präsentationen enthaltenen Daten.  

Da eine *Folien* eines der Elemente in Präsentationen ist, enthält ein *Folien‑Teil* den Inhalt einer einzelnen Folie. Ein Folien‑Teil ist berechtigt, explizite Beziehungen zu vielen Teilen zu haben - beispielsweise zu User Defined Tags - die in ISO/IEC 29500 definiert sind.  

Benutzerdefinierte Daten (spezifisch für eine Präsentation) oder Benutzer können als Tags ([ITagCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ITagCollection)) und CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ICustomXmlPartCollection)) vorliegen.  

{{% alert color="primary" %}} 
Tags sind im Wesentlichen Paare aus Zeichenketten‑Schlüssel‑Werten. 
{{% /alert %}} 

## Abrufen der Werte für Tags

In Folien entspricht ein Tag den Methoden [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/java/com.aspose.slides/IDocumentProperties#getKeywords--) und [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/java/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-) . Dieser Beispielcode zeigt, wie Sie den Wert eines Tags mit Aspose.Slides for Java für [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) abrufen:  
```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```


## Hinzufügen von Tags zu Präsentationen

Aspose.Slides ermöglicht das Hinzufügen von Tags zu Präsentationen. Ein Tag besteht typischerweise aus zwei Elementen: 
- der Name einer benutzerdefinierten Eigenschaft – `MyTag` 
- der Wert der benutzerdefinierten Eigenschaft – `My Tag Value`  

Wenn Sie einige Präsentationen anhand einer bestimmten Regel oder Eigenschaft klassifizieren müssen, können Sie von der Verwendung von Tags profitieren. Beispielsweise können Sie, wenn Sie alle Präsentationen aus nordamerikanischen Ländern zusammenfassen möchten, ein Tag „North American“ erstellen und dann die jeweiligen Länder (USA, Mexiko und Kanada) als Werte zuweisen.  

Dieser Beispielcode zeigt, wie Sie einem [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) mit Aspose.Slides for Java ein Tag hinzufügen:  
```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```


Tags können auch für [Slide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide) festgelegt werden:  
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```


Oder für jedes einzelne [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape):  
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Kann ich alle Tags aus einer Präsentation, Folie oder Form mit einem Vorgang entfernen?**  

Ja. Die [tag collection](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/) unterstützt die [clear](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/#clear--)‑Operation, die alle Schlüssel‑Wert‑Paare auf einmal löscht.  

**Wie lösche ich ein einzelnes Tag anhand seines Namens, ohne die gesamte Sammlung zu iterieren?**  

Verwenden Sie die [Remove(name)](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/#remove-java.lang.String-)‑Operation auf der [tag collection](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/), um das Tag anhand seines Schlüssels zu löschen.  

**Wie kann ich die vollständige Liste der Tag‑Namen für Analysen oder Filterungen abrufen?**  

Verwenden Sie [getNamesOfTags](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/#getNamesOfTags--) auf der [tag collection](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/); sie gibt ein Array aller Tag‑Namen zurück.