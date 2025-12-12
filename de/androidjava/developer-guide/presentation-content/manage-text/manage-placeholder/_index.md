---
title: Verwalten von Präsentations-Platzhaltern auf Android
linktitle: Platzhalter verwalten
type: docs
weight: 10
url: /de/androidjava/manage-placeholder/
keywords:
- Platzhalter
- Text-Platzhalter
- Bild-Platzhalter
- Diagramm-Platzhalter
- Aufforderungstext
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Platzhalter in Aspose.Slides für Android via Java mühelos verwalten: Text ersetzen, Eingabeaufforderungen anpassen und Bildtransparenz in PowerPoint und OpenDocument einstellen."
---

## **Text in einem Platzhalter ändern**
Mit [Aspose.Slides for Android via Java](/slides/de/androidjava/) können Sie Platzhalter auf Folien in Präsentationen finden und ändern. Aspose.Slides ermöglicht es Ihnen, den Text in einem Platzhalter zu ändern.

**Voraussetzung**: Sie benötigen eine Präsentation, die einen Platzhalter enthält. Eine solche Präsentation können Sie in der Standard‑Microsoft‑PowerPoint‑App erstellen.

So verwenden Sie Aspose.Slides, um den Text in dem Platzhalter dieser Präsentation zu ersetzen:

1. Instanziieren Sie die [`Presentation`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)‑Klasse und übergeben Sie die Präsentation als Argument.
2. Holen Sie sich eine Folienreferenz über deren Index.
3. Durchlaufen Sie die Formen, um den Platzhalter zu finden.
4. Casten Sie die Platzhalterform zu einer [`AutoShape`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape) und ändern Sie den Text mithilfe des mit der `AutoShape` verbundenen [`TextFrame`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame).
5. Speichern Sie die geänderte Präsentation.

Dieser Java‑Code zeigt, wie der Text in einem Platzhalter geändert wird:
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

    // Speichert die Präsentation auf die Festplatte
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Aufforderungstext in einem Platzhalter festlegen**
Standard‑ und vordefinierte Layouts enthalten Platzhalter‑Aufforderungstexte wie ***Klicken, um einen Titel hinzuzufügen*** oder ***Klicken, um einen Untertitel hinzuzufügen***. Mit Aspose.Slides können Sie Ihre bevorzugten Aufforderungstexte in Platzhalter‑Layouts einfügen.

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


## **Transparenz des Platzhalterbildes festlegen**

Aspose.Slides ermöglicht es Ihnen, die Transparenz des Hintergrundbildes in einem Text‑Platzhalter festzulegen. Durch Anpassen der Transparenz des Bildes in einem solchen Rahmen können Sie den Text oder das Bild hervorheben (je nach Farbe von Text und Bild).

Dieser Java‑Code zeigt, wie Sie die Transparenz für einen Bildhintergrund (innerhalb einer Form) festlegen:
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

Ein Basis‑Platzhalter ist die ursprüngliche Form in einem Layout oder einer Master‑Folien, von der die Form der Folie erbt – Typ, Position und einige Formatierungen stammen daraus. Eine lokale Form ist unabhängig; existiert kein Basis‑Platzhalter, findet keine Vererbung statt.

**Wie kann ich alle Titel oder Beschriftungen einer Präsentation aktualisieren, ohne jede Folie einzeln zu durchlaufen?**

Bearbeiten Sie den entsprechenden Platzhalter im Layout oder im Master. Folien, die auf diesen Layouts/diesem Master basieren, übernehmen die Änderung automatisch.

**Wie kann ich die Standard‑Kopf‑/Fußzeilen‑Platzhalter – Datum & Uhrzeit, Foliennummer und Fußzeilentext – steuern?**

Verwenden Sie die HeaderFooter‑Manager im jeweiligen Geltungsbereich (normale Folien, Layouts, Master, Notizen/Handouts), um diese Platzhalter ein‑ oder auszuschalten und deren Inhalt festzulegen.