---
title: Verwalten von Tags und benutzerdefinierten Daten in Präsentationen mit JavaScript
linktitle: Tags und benutzerdefinierte Daten
type: docs
weight: 300
url: /de/nodejs-java/managing-tags-and-custom-data/
keywords:
- Dokumenteigenschaften
- Tag
- benutzerdefinierte Daten
- Tag hinzufügen
- Wertpaare
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Erfahren Sie, wie Sie Tags und benutzerdefinierte Daten in Aspose.Slides für Node.js hinzufügen, lesen, aktualisieren und entfernen, mit Beispielen für PowerPoint- und OpenDocument-Präsentationen."
---
## **Übersicht**

Dieser Artikel erklärt, wie Aspose.Slides mit Tags und benutzerdefinierten Daten in PowerPoint‑Präsentationen arbeitet. Er gibt einen kurzen Überblick darüber, wie Daten in PPTX‑Dateien gespeichert werden, weist darauf hin, dass präsentationsspezifische Daten als Tags und benutzerdefinierte XML‑Teile existieren können, und beschreibt Tags als Schlüssel‑Wert‑Zeichenkettenpaare.

Er zeigt außerdem, wie Tag‑Werte gelesen und wie Tags zu einer Präsentation, einer einzelnen Folie oder einer Form hinzugefügt werden können. Außerdem behandelt der Artikel gängige Tag‑Verwaltungsaufgaben wie das Löschen aller Tags, das Entfernen eines Tags nach Namen und das Abrufen der Liste der Tag‑Namen.

## **Datenspeicherung in Präsentationsdateien**

PPTX‑Dateien – Dateien mit der Endung .pptx – werden im PresentationML‑Format gespeichert, das Teil der Office Open XML‑Spezifikation ist. Das Office Open XML‑Format definiert die Struktur der in Präsentationen enthaltenen Daten.

Eine *Folien* ist eines der Elemente in Präsentationen; ein *Folienteil* enthält den Inhalt einer einzelnen Folie. Ein Folienteil darf explizite Beziehungen zu vielen Teilen – wie beispielsweise benutzerdefinierten Tags – haben, die durch ISO/IEC 29500 definiert sind.

Benutzerdefinierte Daten (spezifisch für eine Präsentation) oder Benutzer können als Tags ([TagCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/TagCollection)) und CustomXmlParts ([CustomXmlPartCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/CustomXmlPartCollection)) existieren.

{{% alert color="primary" %}} 
Tags sind im Wesentlichen Zeichenketten‑Schlüssel‑Paar‑Werte. 
{{% /alert %}} 

## **Abrufen der Werte für Tags**

In Slides entspricht ein Tag den Methoden [DocumentProperties.getKeywords()](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/DocumentProperties#getKeywords--) und [DocumentProperties.setKeywords()](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/DocumentProperties#setKeywords-java.lang.String-). Dieser Beispielcode zeigt, wie man den Wert eines Tags mit Aspose.Slides für Node.js via Java für [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Presentation) abruft:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Hinzufügen von Tags zu Präsentationen**

Aspose.Slides ermöglicht das Hinzufügen von Tags zu Präsentationen. Ein Tag besteht typischerweise aus zwei Elementen:

- der Name einer benutzerdefinierten Eigenschaft – `MyTag`
- der Wert der benutzerdefinierten Eigenschaft – `My Tag Value`

Wenn Sie einige Präsentationen anhand einer bestimmten Regel oder Eigenschaft klassifizieren müssen, können Sie davon profitieren, Tags zu diesen Präsentationen hinzuzufügen. Beispielsweise können Sie, wenn Sie alle Präsentationen aus nordamerikanischen Ländern zusammenfassen möchten, ein Nordamerika‑Tag erstellen und dann die entsprechenden Länder (USA, Mexiko und Kanada) als Werte zuweisen.

Dieser Beispielcode zeigt, wie man einem [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Presentation) mit Aspose.Slides für Node.js via Java ein Tag hinzufügt:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Tags können auch für [Slide](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Slide) festgelegt werden:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Oder für jede einzelne [Shape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/AutoShape):

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Einschränkungen**

Tags, die über die benutzerdefinierte Daten‑Tag‑Kollektion mittels `getCustomData().getTags()` hinzugefügt werden, werden nur in der PowerPoint‑Datei gespeichert. Sie werden **nicht** in die PDF‑Tag‑Struktur übertragen, wenn die Präsentation als PDF exportiert wird. Folglich kann ein als Tag zugewiesener benutzerdefinierter Bezeichner nicht aus dem getaggten PDF abgerufen werden.

**Umgehungslösung**: Sie können einen benutzerdefinierten Bezeichner im **Alt‑Text** des Objekts speichern (z. B. `shape.setAlternativeText("MyId")`). Nach dem Exportieren zu PDF kann der Alt‑Text in der PDF‑Tag‑Struktur erscheinen.

## **FAQ**

**Kann ich alle Tags aus einer Präsentation, Folie oder Form in einem Vorgang entfernen?**

Ja. Die [tag collection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/tagcollection/) unterstützt eine [clear](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/tagcollection/clear/)‑Operation, die alle Schlüssel‑Wert‑Paare auf einmal löscht.

**Wie kann ich ein einzelnes Tag anhand seines Namens löschen, ohne die gesamte Sammlung zu durchlaufen?**

Verwenden Sie die [remove(name)](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/tagcollection/remove/)‑Operation auf [TagCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/tagcollection/), um das Tag anhand seines Schlüssels zu löschen.

**Wie kann ich die vollständige Liste der Tag‑Namen für Analysen oder Filterungen abrufen?**

Verwenden Sie [getNamesOfTags](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/tagcollection/getnamesoftags/) auf der [tag collection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/tagcollection/); sie gibt ein Array aller Tag‑Namen zurück.