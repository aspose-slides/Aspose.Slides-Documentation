---
title: Verwalten von SmartArt-Formen
type: docs
weight: 20
url: /java/manage-smartart-shape/
---


## **SmartArt-Form erstellen**
Aspose.Slides für Java bietet eine API zur Erstellung von SmartArt-Formen. Folgen Sie bitte den untenstehenden Schritten, um eine SmartArt-Form in einer Folie zu erstellen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)-Klasse.
1. Erhalten Sie die Referenz auf eine Folie, indem Sie ihren Index verwenden.
1. [Fügen Sie eine SmartArt-Form hinzu](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-), indem Sie den [LayoutTyp](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtLayoutType) festlegen.
1. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

```java
// Instanziieren Sie die Presentation-Klasse
Presentation pres = new Presentation();
try {
    // Holen Sie sich die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Fügen Sie eine SmartArt-Form hinzu
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
    
    // Präsentation speichern
    pres.save("SimpleSmartArt.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Abbildung: SmartArt-Form zur Folie hinzugefügt**|

## **Zugriff auf SmartArt-Form in der Folie**
Der folgende Code wird verwendet, um auf die in der Präsentationsfolie hinzugefügten SmartArt-Formen zuzugreifen. Im Beispielcode durchlaufen wir jede Form in der Folie und prüfen, ob es sich um eine [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt)-Form handelt. Wenn die Form vom Typ SmartArt ist, werden wir sie in eine [**SmartArt**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt)-Instanz umwandeln.

```java
// Laden Sie die gewünschte Präsentation
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Durchlaufen Sie jede Form in der ersten Folie
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Überprüfen, ob die Form vom Typ SmartArt ist
        if (shape instanceof ISmartArt)
        {
            // Typumwandlung der Form zu SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("Form Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zugriff auf SmartArt-Form mit einem bestimmten Layouttyp**
Der folgende Beispielcode hilft, auf die [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt)-Form mit einem bestimmten Layouttyp zuzugreifen. Bitte beachten Sie, dass Sie den Layouttyp der SmartArt nicht ändern können, da er schreibgeschützt ist und nur beim Hinzufügen der [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt)-Form festgelegt wird.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)-Klasse und laden Sie die Präsentation mit der SmartArt-Form.
1. Erhalten Sie die Referenz auf die erste Folie, indem Sie ihren Index verwenden.
1. Durchlaufen Sie jede Form in der ersten Folie.
1. Überprüfen Sie, ob die Form vom [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt)-Typ ist, und wandeln Sie die ausgewählte Form in SmartArt um, wenn es sich um SmartArt handelt.
1. Überprüfen Sie die SmartArt-Form mit dem bestimmten Layouttyp und führen Sie die erforderlichen Aktionen durch.

```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Durchlaufen Sie jede Form in der ersten Folie
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Überprüfen, ob die Form vom Typ SmartArt ist
        if (shape instanceof ISmartArt)
        {
            // Typumwandlung der Form zu SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // Überprüfung des SmartArt-Layouts
            if (smart.getLayout() == SmartArtLayoutType.BasicBlockList)
            {
                System.out.println("Hier etwas unternehmen....");
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt-Formstil ändern**
In diesem Beispiel lernen wir, den Schnellstil für eine beliebige SmartArt-Form zu ändern.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)-Klasse und laden Sie die Präsentation mit der SmartArt-Form.
1. Erhalten Sie die Referenz auf die erste Folie, indem Sie ihren Index verwenden.
1. Durchlaufen Sie jede Form in der ersten Folie.
1. Überprüfen Sie, ob die Form vom [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt)-Typ ist, und wandeln Sie die ausgewählte Form in SmartArt um, wenn es sich um SmartArt handelt.
1. Finden Sie die SmartArt-Form mit dem bestimmten Stil.
1. Setzen Sie den neuen Stil für die SmartArt-Form.
1. Speichern Sie die Präsentation.

```java
// Instanziieren Sie die Presentation-Klasse
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Holen Sie sich die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Durchlaufen Sie jede Form in der ersten Folie
    for (IShape shape : slide.getShapes()) 
    {
        // Überprüfen, ob die Form vom Typ SmartArt ist
        if (shape instanceof ISmartArt) 
        {
            // Typumwandlung der Form zu SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // Überprüfung des SmartArt-Stils
            if (smart.getQuickStyle() == SmartArtQuickStyleType.SimpleFill) {
                // Ändern des SmartArt-Stils
                smart.setQuickStyle(SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // Präsentation speichern
    pres.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Abbildung: SmartArt-Form mit geändertem Stil**|

## **SmartArt-Formfarbstil ändern**
In diesem Beispiel lernen wir, den Farbstil für eine beliebige SmartArt-Form zu ändern. Im folgenden Beispielcode wird auf die SmartArt-Form mit einem bestimmten Farbstil zugegriffen und deren Stil geändert.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)-Klasse und laden Sie die Präsentation mit der SmartArt-Form.
1. Erhalten Sie die Referenz auf die erste Folie, indem Sie ihren Index verwenden.
1. Durchlaufen Sie jede Form in der ersten Folie.
1. Überprüfen Sie, ob die Form vom [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt)-Typ ist, und wandeln Sie die ausgewählte Form in SmartArt um, wenn es sich um SmartArt handelt.
1. Finden Sie die SmartArt-Form mit dem bestimmten Farbstil.
1. Setzen Sie den neuen Farbstil für die SmartArt-Form.
1. Speichern Sie die Präsentation.

```java
// Instanziieren Sie die Presentation-Klasse
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Holen Sie sich die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Durchlaufen Sie jede Form in der ersten Folie
    for (IShape shape : slide.getShapes()) 
    {
        // Überprüfen, ob die Form vom Typ SmartArt ist
        if (shape instanceof ISmartArt) 
        {
            // Typumwandlung der Form zu SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // Überprüfung des SmartArt-Farbstils
            if (smart.getColorStyle() == SmartArtColorType.ColoredFillAccent1) {
                // Ändern des SmartArt-Farbstils
                smart.setColorStyle(SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // Präsentation speichern
    pres.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Abbildung: SmartArt-Form mit geändertem Farbstil**|