---
title: "Verwalten von Tags und benutzerdefinierten Daten in Präsentationen unter Android"
linktitle: "Tags und benutzerdefinierte Daten"
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
## **Datenablage in Präsentationsdateien**

PPTX-Dateien - Elemente mit der Erweiterung .pptx - werden im PresentationML-Format gespeichert, das Teil der Office Open XML-Spezifikation ist. Das Office Open XML-Format definiert die Struktur für in Präsentationen enthaltene Daten. 

Da eine *Folie* eines der Elemente in Präsentationen ist, enthält ein *Folien-Teil* den Inhalt einer einzelnen Folie. Ein Folien-Teil darf explizite Beziehungen zu vielen Teilen haben - wie z. B. benutzerdefinierte Tags - wie in ISO/IEC 29500 definiert. 

Benutzerdefinierte Daten (spezifisch für eine Präsentation) oder Benutzer können als Tags ([ITagCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ITagCollection)) und CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ICustomXmlPartCollection)) vorkommen.

{{% alert color="primary" %}} 
Tags sind im Wesentlichen Schlüssel‑Wert‑Paare aus Zeichenketten. 
{{% /alert %}} 

## **Werte von Tags abrufen**

In Folien entspricht ein Tag den Methoden [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IDocumentProperties#getKeywords--) und [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-). Dieser Beispielcode zeigt, wie man mit Aspose.Slides für Android über Java den Wert eines Tags für eine [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation) abruft:

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

Wenn Sie einige Präsentationen anhand einer bestimmten Regel oder Eigenschaft klassifizieren müssen, können Sie von der Verwendung von Tags profitieren. Beispielsweise können Sie, wenn Sie alle Präsentationen aus nordamerikanischen Ländern zusammenfassen wollen, ein Tag „North American“ erstellen und dann die entsprechenden Länder (USA, Mexiko und Kanada) als Werte zuweisen. 

Dieser Beispielcode zeigt, wie man ein Tag zu einer [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation) mit Aspose.Slides für Android über Java hinzufügt:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```

Tags können auch für [Slide](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISlide) festgelegt werden:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

Oder ein beliebiges einzelnes [Shape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IAutoShape):

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

Tags, die über die benutzerdefinierte Datentag‑Sammlung mit `getCustomData().getTags()` hinzugefügt werden, werden nur in der PowerPoint‑Datei gespeichert. Sie werden **nicht** in die PDF-Tag-Struktur übertragen, wenn die Präsentation als PDF exportiert wird. Folglich kann ein als Tag zugewiesener benutzerdefinierter Bezeichner nicht aus dem getaggten PDF abgerufen werden.

**Workaround**: Sie können einen benutzerdefinierten Bezeichner im **Alt-Text** des Objekts speichern (z. B. `shape.setAlternativeText("MyId")`). Nach dem Exportieren nach PDF kann der Alt-Text in der PDF-Tag-Struktur erscheinen.

## **FAQ**

**Kann ich alle Tags aus einer Präsentation, Folie oder Form in einem Vorgang entfernen?**

Ja. Die [tag collection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/tagcollection/) unterstützt eine [clear](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/tagcollection/#clear--)‑Operation, die alle Schlüssel‑Wert‑Paare auf einmal löscht.

**Wie kann ich ein einzelnes Tag anhand seines Namens löschen, ohne die gesamte Sammlung zu durchlaufen?**

Verwenden Sie die [remove(name)](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-)‑Operation auf der [tag collection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/tagcollection/), um das Tag anhand seines Schlüssels zu löschen.

**Wie kann ich die vollständige Liste der Tag-Namen für Analysen oder Filterungen abrufen?**

Verwenden Sie [getNamesOfTags](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--) auf der [tag collection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/tagcollection/); sie gibt ein Array aller Tag-Namen zurück.