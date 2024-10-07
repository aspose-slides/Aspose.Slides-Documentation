---
title: Verwaltung von Tags und benutzerdefinierten Daten
type: docs
weight: 300
url: /java/managing-tags-and-custom-data

---

## Datenspeicherung in Präsentationsdateien

PPTX-Dateien – Objekte mit der .pptx-Erweiterung – werden im PresentationML-Format gespeichert, das Teil der Office Open XML-Spezifikation ist. Das Office Open XML-Format definiert die Struktur für Daten, die in Präsentationen enthalten sind.

Ein *Folien* ist eines der Elemente in Präsentationen, ein *Folienabschnitt* enthält den Inhalt einer einzelnen Folie. Ein Folienabschnitt darf explizite Beziehungen zu vielen Abschnitten haben – wie z.B. Benutzerdefinierte Tags – die durch ISO/IEC 29500 definiert sind.

Benutzerdefinierte Daten (spezifisch für eine Präsentation) oder Benutzer können als Tags ([ITagCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ITagCollection)) und CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ICustomXmlPartCollection)) existieren.

{{% alert color="primary" %}} 

Tags sind im Wesentlichen Schlüssel-Wert-Paarwerte.

{{% /alert %}} 

## Abrufen der Werte für Tags

In Folien entspricht ein Tag den Methoden [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/java/com.aspose.slides/IDocumentProperties#getKeywords--) und [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/java/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-). Dieser Beispielcode zeigt Ihnen, wie Sie den Wert eines Tags mit Aspose.Slides für Java für [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) abrufen:

```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```

## Hinzufügen von Tags zu Präsentationen

Aspose.Slides ermöglicht es Ihnen, Tags zu Präsentationen hinzuzufügen. Ein Tag besteht typischerweise aus zwei Elementen:

- dem Namen einer benutzerdefinierten Eigenschaft - `MyTag` 
- dem Wert der benutzerdefinierten Eigenschaft - `My Tag Value`

Wenn Sie einige Präsentationen basierend auf einer bestimmten Regel oder Eigenschaft klassifizieren müssen, können Sie davon profitieren, Tags zu diesen Präsentationen hinzuzufügen. Zum Beispiel, wenn Sie alle Präsentationen aus nordamerikanischen Ländern kategorisieren oder zusammenfassen möchten, können Sie ein nordamerikanisches Tag erstellen und dann die entsprechenden Länder (die USA, Mexiko und Kanada) als Werte zuweisen.

Dieser Beispielcode zeigt Ihnen, wie Sie ein Tag zu einer [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) mit Aspose.Slides für Java hinzufügen:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```

Tags können auch für [Slide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide) gesetzt werden:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

Oder für jede einzelne [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape):

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("Mein Text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```