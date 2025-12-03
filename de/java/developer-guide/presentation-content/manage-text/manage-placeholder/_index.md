---
title: Präsentationsplatzhalter in Java verwalten
linktitle: Platzhalter verwalten
type: docs
weight: 10
url: /de/java/manage-placeholder/
keywords:
- Platzhalter
- Textplatzhalter
- Bildplatzhalter
- Diagrammplatzhalter
- Aufforderungstext
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Platzhalter in Aspose.Slides für Java mühelos verwalten: Text ersetzen, Aufforderungen anpassen und Bildtransparenz in PowerPoint und OpenDocument festlegen."
---

## **Text in Platzhalter ändern**
Mit [Aspose.Slides for Java](/slides/de/java/) können Sie Platzhalter auf Folien in Präsentationen finden und ändern. Aspose.Slides ermöglicht es Ihnen, Änderungen am Text in einem Platzhalter vorzunehmen.

**Voraussetzung**: Sie benötigen eine Präsentation, die einen Platzhalter enthält. Eine solche Präsentation können Sie mit der Standard-Microsoft-PowerPoint-Anwendung erstellen.

So verwenden Sie Aspose.Slides, um den Text im Platzhalter dieser Präsentation zu ersetzen:

1. Instanziieren Sie die [`Presentation`](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)-Klasse und übergeben Sie die Präsentation als Argument.
2. Holen Sie eine Folienreferenz über deren Index.
3. Iterieren Sie durch die Formen, um den Platzhalter zu finden.
4. Casten Sie die Platzhalterform zu einem [`AutoShape`](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape) und ändern Sie den Text mithilfe des [`TextFrame`](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame), das mit dem [`AutoShape`](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape) verknüpft ist.
5. Speichern Sie die geänderte Präsentation.

Dieser Java‑Code zeigt, wie Sie den Text in einem Platzhalter ändern:
```java
// Instanziert eine Presentation-Klasse
Presentation pres = new Presentation("ReplacingText.pptx");
try {

    // Greift auf die erste Folie zu
    ISlide sld = pres.getSlides().get_Item(0);

    // Durchläuft die Formen, um den Platzhalter zu finden
    for (IShape shp : sld.getShapes()) 
    {
        if (shp.getPlaceholder() != null) {
            // Ändert den Text in jedem Platzhalter
            ((IAutoShape) shp).getTextFrame().setText("This is Placeholder");
        }
    }

    // Speichert die Präsentation auf dem Datenträger
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Aufforderungstext in Platzhalter festlegen**
Standard‑ und vorgefertigte Layouts enthalten Platzhalter‑Aufforderungstexte wie ***Click to add a title*** oder ***Click to add a subtitle***. Mit Aspose.Slides können Sie Ihre bevorzugten Aufforderungstexte in Platzhalter‑Layouts einfügen.

Dieser Java‑Code zeigt, wie Sie den Aufforderungstext in einem Platzhalter festlegen:
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    for (IShape shape : slide.getSlide().getShapes()) // Durchläuft die Folie
    {
        if (shape.getPlaceholder() != null && shape instanceof AutoShape)
        {
            String text = "";
            if (shape.getPlaceholder().getType() == PlaceholderType.CenteredTitle) // PowerPoint zeigt "Klicken, um Titel hinzuzufügen" 
            {
                text = "Add Title";
            }
            else if (shape.getPlaceholder().getType() == PlaceholderType.Subtitle) // Fügt Untertitel hinzu
            {
                text = "Add Subtitle";
            }

            ((IAutoShape)shape).getTextFrame().setText(text);
            System.out.println("Placeholder with text: " + text);
        }
    }

    pres.save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Transparenz von Platzhalter‑Bild festlegen**
Aspose.Slides ermöglicht es Ihnen, die Transparenz des Hintergrundbildes in einem Text‑Platzhalter festzulegen. Durch Anpassen der Transparenz des Bildes in einem solchen Rahmen können Sie den Text oder das Bild hervorheben (abhängig von den Farben von Text und Bild).

Dieser Java‑Code zeigt, wie Sie die Transparenz für einen Bild‑Hintergrund (innerhalb einer Form) festlegen:
```java
Presentation presentation = new Presentation("example.pptx");

IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

IImageTransformOperationCollection operationCollection = shape.getFillFormat().getPictureFillFormat().getPicture().getImageTransform();
for (int i = 0; i < operationCollection.size(); i++)
{
    if(operationCollection.get_Item(i) instanceof AlphaModulateFixed)
    {
        AlphaModulateFixed alphaModulate = (AlphaModulateFixed)operationCollection.get_Item(i);
        float currentValue = 100 - alphaModulate.getAmount();
        System.out.println("Current transparency value: " + currentValue);

        int alphaValue = 40;
        alphaModulate.setAmount(100 - alphaValue);
    }
}

presentation.save("example_out.pptx", SaveFormat.Pptx);
```


## **FAQ**

**Was ist ein Basis‑Platzhalter und wie unterscheidet er sich von einer lokalen Form auf einer Folie?**

Ein Basis‑Platzhalter ist die ursprüngliche Form in einem Layout oder einer Master‑Folien, von der die Form einer Folie erbt – Typ, Position und einige Formatierungen stammen daraus. Eine lokale Form ist unabhängig; gibt es keinen Basis‑Platzhalter, gilt die Vererbung nicht.

**Wie kann ich alle Titel oder Beschriftungen in einer Präsentation aktualisieren, ohne jede Folie zu iterieren?**

Bearbeiten Sie den entsprechenden Platzhalter im Layout oder auf dem Master. Folien, die auf diesen Layouts/ diesem Master basieren, übernehmen die Änderung automatisch.

**Wie steuere ich die Standard‑Header/Footer‑Platzhalter – Datum & Uhrzeit, Foliennummer und Footer‑Text?**

Verwenden Sie die HeaderFooter‑Manager im jeweiligen Geltungsbereich (normale Folien, Layouts, Master, Notizen/Handzettel), um diese Platzhalter ein- oder auszuschalten und deren Inhalt festzulegen.