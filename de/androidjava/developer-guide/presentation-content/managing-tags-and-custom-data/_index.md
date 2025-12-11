---
title: Verwalten von Tags und benutzerdefinierten Daten in Präsentationen auf Android
linktitle: Tags und benutzerdefinierte Daten
type: docs
weight: 300
url: /de/androidjava/managing-tags-and-custom-data
keywords:
- Dokumenteigenschaften
- Tag
- benutzerdefinierte Daten
- Tag hinzufügen
- Paarwerte
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Tags und benutzerdefinierte Daten in Aspose.Slides für Android hinzufügen, lesen, aktualisieren und entfernen, mit Java‑Beispielen für PowerPoint‑ und OpenDocument‑Präsentationen."
---

## **Datenspeicherung in Präsentationsdateien**

PPTX‑Dateien — Elemente mit der Erweiterung .pptx — werden im PresentationML‑Format gespeichert, das Teil der Office Open XML‑Spezifikation ist. Das Office Open XML‑Format definiert die Struktur der in Präsentationen enthaltenen Daten. 

Ein *Foliensatz* ist eines der Elemente in Präsentationen; ein *Foliensatz‑Teil* enthält den Inhalt einer einzelnen Folie. Ein Foliensatz‑Teil darf explizite Beziehungen zu vielen Teilen haben — z. B. zu benutzerdefinierten Tags — die nach ISO/IEC 29500 definiert sind. 

Benutzerdefinierte Daten (spezifisch für eine Präsentation) oder Benutzer können als Tags ([ITagCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITagCollection)) und CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICustomXmlPartCollection)) vorkommen.

{{% alert color="primary" %}} 
Tags sind im Wesentlichen Schlüssel‑Wert‑Paare aus Zeichenketten. 
{{% /alert %}} 

## **Werte von Tags abrufen**

In Folien entspricht ein Tag den Methoden [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IDocumentProperties#getKeywords--) und [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-). Dieser Beispielcode zeigt, wie Sie den Wert eines Tags mit Aspose.Slides für Android via Java für [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) erhalten:
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

- dem Namen einer benutzerdefinierten Eigenschaft — `MyTag` 
- dem Wert der benutzerdefinierten Eigenschaft — `My Tag Value`

Wenn Sie einige Präsentationen nach einer bestimmten Regel oder Eigenschaft klassifizieren möchten, können Sie davon profitieren, Tags zu diesen Präsentationen hinzuzufügen. Beispielsweise können Sie, um alle Präsentationen aus nordamerikanischen Ländern zusammenzufassen, einen Tag „North American“ erstellen und die jeweiligen Länder (USA, Mexiko und Kanada) als Werte zuweisen. 

Dieser Beispielcode zeigt, wie Sie mit Aspose.Slides für Android via Java einem [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) einen Tag hinzufügen:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```


Tags können auch für [Slide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide) gesetzt werden:
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```


Oder für ein einzelnes [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape):
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

**Kann ich alle Tags einer Präsentation, Folie oder Form in einem Vorgang entfernen?**

Ja. Die [tag collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tagcollection/) unterstützt die [clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tagcollection/#clear--)‑Operation, die alle Schlüssel‑Wert‑Paare auf einmal löscht.

**Wie kann ich ein einzelnes Tag anhand seines Namens löschen, ohne die gesamte Sammlung zu durchlaufen?**

Verwenden Sie die [remove(name)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-)‑Methode der [tag collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tagcollection/), um das Tag anhand seines Schlüssels zu löschen.

**Wie kann ich die vollständige Liste der Tag‑Namen für Analysen oder Filterungen abrufen?**

Verwenden Sie [getNamesOfTags](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--) auf der [tag collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tagcollection/); sie liefert ein Array aller Tag‑Namen.