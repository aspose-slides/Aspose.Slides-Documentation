---
title: Verwalten von Präsentationsplatzhaltern in Java
linktitle: Platzhalter verwalten
type: docs
weight: 10
url: /de/java/manage-placeholder/
keywords:
- Platzhalter
- Textplatzhalter
- Bildplatzhalter
- Diagrammplatzhalter
- Hinweistext
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Verwalten Sie Platzhalter in Aspose.Slides für Java mühelos: Text ersetzen, Hinweistexte anpassen und Bildtransparenz in PowerPoint und OpenDocument einstellen."
---

## **Text in einem Platzhalter ändern**
Mit [Aspose.Slides for Java](/slides/de/java/), können Sie Platzhalter auf Folien in Präsentationen finden und ändern. Aspose.Slides ermöglicht es Ihnen, Änderungen am Text in einem Platzhalter vorzunehmen.

**Voraussetzung**: Sie benötigen eine Präsentation, die einen Platzhalter enthält. Eine solche Präsentation können Sie in der standardmäßigen Microsoft PowerPoint‑App erstellen.

So verwenden Sie Aspose.Slides, um den Text in dem Platzhalter dieser Präsentation zu ersetzen:

1. Instanziieren Sie die [`Presentation`](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)-Klasse und übergeben Sie die Präsentation als Argument.
2. Holen Sie sich über den Index einen Folien‑Verweis.
3. Iterieren Sie über die Shapes, um den Platzhalter zu finden.
4. Typisieren Sie das Platzhalter‑Shape zu einer [`AutoShape`](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape) und ändern Sie den Text über das [`TextFrame`](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame), das mit der [`AutoShape`](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape) verknüpft ist.
5. Speichern Sie die geänderte Präsentation.

```java
// Instanziert eine Presentation-Klasse
Presentation pres = new Presentation("ReplacingText.pptx");
try {

    // Greift auf die erste Folie zu
    ISlide sld = pres.getSlides().get_Item(0);

    // Iteriert durch Shapes, um den Platzhalter zu finden
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


## **Vorgabetext in einem Platzhalter festlegen**
Standard‑ und vorgefertigte Layouts enthalten Platzhalter‑Vorgabetexte wie ***Click to add a title*** oder ***Click to add a subtitle***. Mit Aspose.Slides können Sie Ihre bevorzugten Vorgabetexte in Platzhalter‑Layouts einfügen.

Dieser Java‑Code zeigt, wie Sie den Vorgabetext in einem Platzhalter festlegen:
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    for (IShape shape : slide.getSlide().getShapes()) // Iteriert durch die Folie
    {
        if (shape.getPlaceholder() != null && shape instanceof AutoShape)
        {
            String text = "";
            if (shape.getPlaceholder().getType() == PlaceholderType.CenteredTitle) // PowerPoint zeigt "Click to add title" an
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


## **Transparenz für Platzhalter‑Bild festlegen**

Aspose.Slides ermöglicht es, die Transparenz des Hintergrundbildes in einem Text‑Platzhalter einzustellen. Durch Anpassen der Transparenz des Bildes in einem solchen Rahmen können Sie den Text oder das Bild hervorheben (abhängig von den Farben des Textes und des Bildes).

Dieser Java‑Code zeigt, wie Sie die Transparenz für einen Bild‑Hintergrund (innerhalb einer Shape) festlegen:
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

**Was ist ein Basis‑Platzhalter und wie unterscheidet er sich von einer lokalen Shape auf einer Folie?**

Ein Basis‑Platzhalter ist das originale Shape auf einem Layout oder Master, von dem das Folien‑Shape erbt – Typ, Position und einige Formatierungen stammen daraus. Eine lokale Shape ist unabhängig; gibt es keinen Basis‑Platzhalter, findet keine Vererbung statt.

**Wie kann ich alle Titel oder Beschriftungen einer Präsentation aktualisieren, ohne jede Folie zu durchlaufen?**

Bearbeiten Sie den entsprechenden Platzhalter im Layout oder im Master. Folien, die auf diesen Layouts/diesem Master basieren, erben die Änderung automatisch.

**Wie steuere ich die Standard‑Header/Footer‑Platzhalter – Datum & Uhrzeit, Foliennummer und Fußzeilentext?**

Verwenden Sie die HeaderFooter‑Manager im entsprechenden Geltungsbereich (normale Folien, Layouts, Master, Notizen/Handouts), um diese Platzhalter ein‑ oder auszuschalten und deren Inhalt zu setzen.