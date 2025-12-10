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
description: "Erfahren Sie, wie Sie Tags und benutzerdefinierte Daten in Aspose.Slides für Java hinzufügen, lesen, aktualisieren und entfernen, mit Beispielen für PowerPoint- und OpenDocument-Präsentationen."
---

## **Datenspeicherung in Präsentationsdateien**

PPTX‑Dateien — Elemente mit der Erweiterung .pptx — werden im PresentationML‑Format gespeichert, das Teil der Office‑Open‑XML‑Spezifikation ist. Das Office‑Open‑XML‑Format definiert die Struktur für die in Präsentationen enthaltenen Daten.  

Da eine *Folie* eines der Elemente in Präsentationen ist, enthält ein *Folien‑Teil* den Inhalt einer einzelnen Folie. Ein Folien‑Teil darf explizite Beziehungen zu vielen Teilen — wie zum Beispiel benutzerdefinierten Tags — haben, die von ISO/IEC 29500 definiert sind.  

Benutzerdefinierte Daten (spezifisch für eine Präsentation) oder Benutzer können als Tags ([ITagCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ITagCollection)) und CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ICustomXmlPartCollection)) vorliegen.  

{{% alert color="primary" %}} 
Tags sind im Wesentlichen Schlüssel‑Wert‑Paare als Zeichenketten. 
{{% /alert %}} 

## **Werte von Tags abrufen**

In Folien entspricht ein Tag den Methoden [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/java/com.aspose.slides/IDocumentProperties#getKeywords--) und [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/java/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-) . Dieses Beispielcode zeigt, wie man mit Aspose.Slides für Java den Wert eines Tags für eine [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) abruft:
```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```


## **Tags zu Präsentationen hinzufügen**

Aspose.Slides ermöglicht das Hinzufügen von Tags zu Präsentationen. Ein Tag besteht typischerweise aus zwei Elementen: 

- der Name einer benutzerdefinierten Eigenschaft – `MyTag` 
- der Wert der benutzerdefinierten Eigenschaft – `My Tag Value`

If Sie Präsentationen anhand einer bestimmten Regel oder Eigenschaft klassifizieren müssen, kann das Hinzufügen von Tags zu diesen Präsentationen hilfreich sein. Zum Beispiel können Sie, wenn Sie alle Präsentationen aus nordamerikanischen Ländern zusammenfassen möchten, ein „North American“-Tag erstellen und dann die entsprechenden Länder (USA, Mexiko und Kanada) als Werte zuweisen. 

Dieses Beispielcode zeigt, wie man mit Aspose.Slides für Java einem [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) ein Tag hinzufügt:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```


Tags können auch für eine [Slide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide) gesetzt werden:
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```


Oder für ein einzelnes [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape):
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

**Kann ich alle Tags aus einer Präsentation, Folie oder Form in einem Vorgang entfernen?**

Ja. Die [tag collection](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/) unterstützt die [clear](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/#clear--)‑Operation, die alle Schlüssel‑Wert‑Paare gleichzeitig löscht.

**Wie lösche ich ein einzelnes Tag anhand seines Namens, ohne die gesamte Sammlung zu iterieren?**

Verwenden Sie die [Remove(name)](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/#remove-java.lang.String-)‑Operation auf der [tag collection](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/), um das Tag anhand seines Schlüssels zu löschen.

**Wie kann ich die vollständige Liste der Tag‑Namen für Analysen oder Filterungen abrufen?**

Verwenden Sie [getNamesOfTags](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/#getNamesOfTags--) auf der [tag collection](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/); sie gibt ein Array aller Tag‑Namen zurück.