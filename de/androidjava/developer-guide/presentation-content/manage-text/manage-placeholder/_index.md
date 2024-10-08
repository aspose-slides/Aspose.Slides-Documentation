---
title: Platzhalter verwalten
type: docs
weight: 10
url: /de/androidjava/manage-placeholder/
description: Ändern Sie den Text in einem Platzhalter in PowerPoint-Folien mit Java. Setzen Sie den Eingabetext in einem Platzhalter in PowerPoint-Folien mit Java.
---

## **Text im Platzhalter ändern**
Mit [Aspose.Slides für Android über Java](/slides/de/androidjava/) können Sie Platzhalter auf Folien in Präsentationen finden und bearbeiten. Aspose.Slides ermöglicht Ihnen Änderungen am Text in einem Platzhalter vorzunehmen.

**Voraussetzung**: Sie benötigen eine Präsentation, die einen Platzhalter enthält. Sie können eine solche Präsentation in der Standardanwendung Microsoft PowerPoint erstellen.

So verwenden Sie Aspose.Slides, um den Text im Platzhalter in dieser Präsentation zu ersetzen:

1. Instanziieren Sie die [`Presentation`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)-Klasse und übergeben Sie die Präsentation als Argument.
2. Holen Sie sich eine Folienreferenz über ihren Index.
3. Durchlaufen Sie die Formen, um den Platzhalter zu finden.
4. Typumwandlung der Platzhalterform in eine [`AutoShape`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape) und ändern Sie den Text mit dem [`TextFrame`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame), das mit der [`AutoShape`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape) verknüpft ist.
5. Speichern Sie die bearbeitete Präsentation.

Dieser Java-Code zeigt, wie man den Text in einem Platzhalter ändert:

```java
// Instanziiert eine Präsentationsklasse
Presentation pres = new Presentation("ReplacingText.pptx");
try {

    // Greift auf die erste Folie zu
    ISlide sld = pres.getSlides().get_Item(0);

    // Durchläuft die Formen, um den Platzhalter zu finden
    for (IShape shp : sld.getShapes()) 
    {
        if (shp.getPlaceholder() != null) {
            // Ändert den Text in jedem Platzhalter
            ((IAutoShape) shp).getTextFrame().setText("Das ist ein Platzhalter");
        }
    }

    // Speichert die Präsentation auf der Festplatte
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Eingabetext im Platzhalter festlegen**
Standard- und vorkonfigurierte Layouts enthalten Platzhalter-Eingabetexte wie ***Klicken Sie hier, um einen Titel hinzuzufügen*** oder ***Klicken Sie hier, um einen Untertitel hinzuzufügen***. Mit Aspose.Slides können Sie Ihre bevorzugten Eingabetexte in Platzhalter-Layouts einfügen.

Dieser Java-Code zeigt Ihnen, wie Sie den Eingabetext in einem Platzhalter festlegen:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    for (IShape shape : slide.getSlide().getShapes()) // Durchläuft die Folie
    {
        if (shape.getPlaceholder() != null && shape instanceof AutoShape)
        {
            String text = "";
            if (shape.getPlaceholder().getType() == PlaceholderType.CenteredTitle) // PowerPoint zeigt "Klicken Sie hier, um einen Titel hinzuzufügen"
            {
                text = "Titel hinzufügen";
            }
            else if (shape.getPlaceholder().getType() == PlaceholderType.Subtitle) // Fügt einen Untertitel hinzu
            {
                text = "Untertitel hinzufügen";
            }

            ((IAutoShape)shape).getTextFrame().setText(text);
            System.out.println("Platzhalter mit Text: " + text);
        }
    }

    pres.save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Transparenz des Platzhalterbildes festlegen**

Aspose.Slides ermöglicht es Ihnen, die Transparenz des Hintergrundbildes in einem Textplatzhalter festzulegen. Durch Anpassung der Transparenz des Bildes in einem solchen Rahmen können Sie den Text oder das Bild hervorheben (je nach Farben des Textes und Bildes).

Dieser Java-Code zeigt Ihnen, wie Sie die Transparenz für einen Bildhintergrund (in einer Form) festlegen:

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
        System.out.println("Aktueller Transparenzwert: " + currentValue);

        int alphaValue = 40;
        alphaModulate.setAmount(100 - alphaValue);
    }
}

presentation.save("example_out.pptx", SaveFormat.Pptx);
```