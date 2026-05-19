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
description: "Erfahren Sie, wie Sie Tags & benutzerdefinierte Daten in Aspose.Slides für Java hinzufügen, lesen, aktualisieren und entfernen, mit Beispielen für PowerPoint- und OpenDocument‑Präsentationen."
---
## **Übersicht**

Dieser Artikel erklärt, wie Aspose.Slides mit Tags und benutzerdefinierten Daten in PowerPoint‑Präsentationen arbeitet. Er gibt einen kurzen Überblick darüber, wie Daten in PPTX‑Dateien gespeichert werden, weist darauf hin, dass präsentationsspezifische Daten als Tags und benutzerdefinierte XML‑Teile existieren können, und beschreibt Tags als Schlüssel‑Wert‑String‑Paare.

Er zeigt außerdem, wie Tag‑Werte ausgelesen und wie Tags zu einer Präsentation, einer einzelnen Folie oder einer Form hinzugefügt werden können. Darüber hinaus behandelt der Artikel gängige Tag‑Verwaltungsaufgaben wie das Löschen aller Tags, das Entfernen eines Tags anhand seines Namens und das Abrufen der Liste von Tag‑Namen.

## **Datenspeicherung in Präsentationsdateien**

PPTX‑Dateien — Elemente mit der Dateierweiterung .pptx — werden im PresentationML‑Format gespeichert, das Teil der Office Open XML‑Spezifikation ist. Das Office Open XML‑Format definiert die Struktur für Daten, die in Präsentationen enthalten sind.

Da eine *Folie* eines der Elemente in Präsentationen ist, enthält ein *Folien‑Teil* den Inhalt einer einzelnen Folie. Ein Folien‑Teil darf explizite Beziehungen zu vielen Teilen — beispielsweise User Defined Tags — haben, die nach ISO/IEC 29500 definiert sind.

Benutzerdefinierte Daten (spezifisch für eine Präsentation) oder Benutzer können als Tags ([ITagCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/ITagCollection)) und CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/ICustomXmlPartCollection)) existieren.

{{% alert color="primary" %}} 

Tags sind im Wesentlichen Schlüssel‑Wert‑String‑Paare. 

{{% /alert %}} 

## **Werte von Tags abrufen**

In Slides entspricht ein Tag den Methoden [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/de/java/com.aspose.slides/IDocumentProperties#getKeywords--) und [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/de/java/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-). Dieser Beispielcode zeigt, wie man den Wert eines Tags mit Aspose.Slides für Java für eine [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation) abruft:

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

Wenn Sie einige Präsentationen anhand einer bestimmten Regel oder Eigenschaft klassifizieren müssen, können Sie von der Verwendung von Tags profitieren. Beispielsweise können Sie, wenn Sie alle Präsentationen aus nordamerikanischen Ländern zusammenfassen möchten, einen Tag „North American“ erstellen und die entsprechenden Länder (USA, Mexiko und Kanada) als Werte zuweisen.

Dieser Beispielcode zeigt, wie ein Tag zu einer [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation) mit Aspose.Slides für Java hinzugefügt wird:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```

Tags können auch für [Slide](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISlide) gesetzt werden:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

Oder für eine einzelne [Shape](https://reference.aspose.com/slides/de/java/com.aspose.slides/IAutoShape):

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

### **Einschränkungen**

Tags, die über die benutzerdefinierte Datentag‑Sammlung mit `getCustomData().getTags()` hinzugefügt werden, werden ausschließlich innerhalb der PowerPoint‑Datei gespeichert. Sie werden **nicht** in die PDF‑Tag‑Struktur übernommen, wenn die Präsentation nach PDF exportiert wird. Folglich kann ein als Tag zugewiesener benutzerdefinierter Bezeichner nicht aus dem getaggten PDF abgerufen werden.

**Umgehungslösung**: Sie können einen benutzerdefinierten Bezeichner im **Alt‑Text** des Objekts speichern (z. B. `shape.setAlternativeText("MyId")`). Nach dem Export nach PDF kann der Alt‑Text in der PDF‑Tag‑Struktur erscheinen.

## **FAQ**

**Kann ich alle Tags aus einer Präsentation, Folie oder Form in einem Schritt entfernen?**

Ja. Die [tag collection](https://reference.aspose.com/slides/de/java/com.aspose.slides/tagcollection/) unterstützt die [clear](https://reference.aspose.com/slides/de/java/com.aspose.slides/tagcollection/#clear--)‑Operation, die alle Schlüssel‑Wert‑Paare auf einmal löscht.

**Wie lösche ich ein einzelnes Tag anhand seines Namens, ohne die gesamte Sammlung zu durchlaufen?**

Verwenden Sie die [Remove(name)](https://reference.aspose.com/slides/de/java/com.aspose.slides/tagcollection/#remove-java.lang.String-)‑Operation auf der [tag collection](https://reference.aspose.com/slides/de/java/com.aspose.slides/tagcollection/), um das Tag anhand seines Schlüssels zu entfernen.

**Wie kann ich die vollständige Liste der Tag‑Namen für Analysen oder Filterungen abrufen?**

Verwenden Sie [getNamesOfTags](https://reference.aspose.com/slides/de/java/com.aspose.slides/tagcollection/#getNamesOfTags--) auf der [tag collection](https://reference.aspose.com/slides/de/java/com.aspose.slides/tagcollection/); sie gibt ein Array aller Tag‑Namen zurück.