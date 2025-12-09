---
title: Verwalten von Tags und benutzerdefinierten Daten
type: docs
weight: 300
url: /de/nodejs-java/managing-tags-and-custom-data
---

## **Datenspeicherung in Präsentationsdateien**

PPTX-Dateien—Elemente mit der Erweiterung .pptx—werden im PresentationML-Format gespeichert, das Teil der Office Open XML‑Spezifikation ist. Das Office Open XML-Format definiert die Struktur für Daten, die in Präsentationen enthalten sind.  

Da eine *Folie* eines der Elemente in Präsentationen ist, enthält ein *Folienteil* den Inhalt einer einzelnen Folie. Ein Folienteil darf explizite Beziehungen zu vielen Teilen — wie z. B. benutzerdefinierte Tags — haben, die von ISO/IEC 29500 definiert werden.  

Benutzerdefinierte Daten (spezifisch für eine Präsentation) oder der Nutzer können als Tags ([TagCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TagCollection)) und CustomXmlParts ([CustomXmlPartCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CustomXmlPartCollection)) vorliegen.  

{{% alert color="primary" %}} 
Tags sind im Wesentlichen Schlüssel‑Wert‑Paare aus Zeichenketten. 
{{% /alert %}} 

## **Abrufen der Werte für Tags**

In Folien entspricht ein Tag den Methoden [DocumentProperties.getKeywords()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getKeywords--) und [DocumentProperties.setKeywords()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setKeywords-java.lang.String-). Dieser Beispielcode zeigt, wie man den Wert eines Tags mit Aspose.Slides für Node.js über Java für [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) abruft:
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

Wenn Sie einige Präsentationen basierend auf einer bestimmten Regel oder Eigenschaft klassifizieren müssen, können Sie davon profitieren, Tags zu diesen Präsentationen hinzuzufügen. Beispielsweise können Sie, wenn Sie alle Präsentationen aus nordamerikanischen Ländern kategorisieren oder zusammenfassen möchten, ein Tag für Nordamerika erstellen und dann die entsprechenden Länder (USA, Mexiko und Kanada) als Werte zuweisen.  

Dieser Beispielcode zeigt, wie man mit Aspose.Slides für Node.js über Java ein Tag zu einer [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) hinzufügt:
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


Tags können auch für [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) gesetzt werden:
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


Oder für jedes individuelle [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape):
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


## **FAQ**

**Kann ich alle Tags aus einer Präsentation, Folie oder Form in einem Vorgang entfernen?**

Ja. Die [tag collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tagcollection/) unterstützt eine [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tagcollection/clear/)‑Operation, die alle Schlüssel‑Wert‑Paare auf einmal löscht.

**Wie lösche ich ein einzelnes Tag nach seinem Namen, ohne die gesamte Sammlung zu iterieren?**

Verwenden Sie die [remove(name)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tagcollection/remove/)‑Operation auf [TagCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tagcollection/), um das Tag anhand seines Schlüssels zu löschen.

**Wie kann ich die vollständige Liste der Tag-Namen für Analysen oder Filterung abrufen?**

Verwenden Sie [getNamesOfTags](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tagcollection/getnamesoftags/) auf der [tag collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tagcollection/); sie liefert ein Array aller Tag‑Namen.