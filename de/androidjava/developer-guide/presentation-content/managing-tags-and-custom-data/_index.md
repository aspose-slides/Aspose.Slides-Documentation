---
title: Verwalten von Tags und benutzerdefinierten Daten
type: docs
weight: 300
url: /de/androidjava/managing-tags-and-custom-data

---

## Datenspeicherung in Präsentationsdateien

PPTX-Dateien—Elemente mit der Erweiterung .pptx—werden im PresentationML-Format gespeichert, das Teil der Office Open XML-Spezifikation ist. Das Office Open XML-Format definiert die Struktur für Daten, die in Präsentationen enthalten sind.

Da eine *Folie* eines der Elemente in Präsentationen ist, enthält ein *Folienteil* den Inhalt einer einzelnen Folie. Ein Folienteil darf explizite Beziehungen zu vielen Teilen haben—wie z. B. Benutzerdefinierte Tags—die von ISO/IEC 29500 definiert sind.

Benutzerdefinierte Daten (spezifisch für eine Präsentation) oder Benutzer können als Tags ([ITagCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITagCollection)) und CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICustomXmlPartCollection)) existieren.

{{% alert color="primary" %}} 

Tags sind im Wesentlichen Werte von Schlüssel-Paar-Strings. 

{{% /alert %}} 

## Abrufen der Werte für Tags

In Folien entspricht ein Tag den Methoden [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IDocumentProperties#getKeywords--) und [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-). Dieser Beispielcode zeigt Ihnen, wie Sie den Wert eines Tags mit Aspose.Slides für Android über Java für [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) abrufen:

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

Wenn Sie einige Präsentationen basierend auf einer bestimmten Regel oder Eigenschaft klassifizieren müssen, können Sie davon profitieren, Tags zu diesen Präsentationen hinzuzufügen. Wenn Sie beispielsweise alle Präsentationen aus nordamerikanischen Ländern kategorisieren oder zusammenführen möchten, können Sie ein nordamerikanisches Tag erstellen und dann die relevanten Länder (die USA, Mexiko und Kanada) als Werte zuweisen.

Dieser Beispielcode zeigt Ihnen, wie Sie ein Tag zu einer [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) mit Aspose.Slides für Android über Java hinzufügen:

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

Oder für jede einzelne [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape):

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