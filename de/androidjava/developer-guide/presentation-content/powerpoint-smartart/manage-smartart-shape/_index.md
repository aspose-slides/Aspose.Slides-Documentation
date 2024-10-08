---
title: SmartArt-Form verwalten
type: docs
weight: 20
url: /de/androidjava/manage-smartart-shape/
---


## **SmartArt-Form erstellen**
Aspose.Slides für Android über Java stellt eine API zum Erstellen von SmartArt-Formen bereit. Um eine SmartArt-Form in einer Folie zu erstellen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)-Klasse.
1. Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
1. [Fügen Sie eine SmartArt-Form hinzu](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-), indem Sie den [Layouttyp](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtLayoutType) festlegen.
1. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

```java
// Instanziieren der Präsentationsklasse
Presentation pres = new Presentation();
try {
    // Erste Folie abrufen
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Smart Art Form hinzufügen
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
Der folgende Code wird verwendet, um auf die in der Präsentationsfolie hinzugefügten SmartArt-Formen zuzugreifen. Im Beispielcode durchlaufen wir jede Form innerhalb der Folie und überprüfen, ob sie eine [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt)-Form ist. Wenn die Form vom SmartArt-Typ ist, werden wir diese als [**SmartArt**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt)-Instanz typisieren.

```java
// Die gewünschte Präsentation laden
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Jede Form innerhalb der ersten Folie durchlaufen
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Überprüfen, ob die Form vom SmartArt-Typ ist
        if (shape instanceof ISmartArt)
        {
            // Form zu SmartArtEx typisieren
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("Formname:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zugriff auf SmartArt-Form mit einem bestimmten Layouttyp**
Der folgende Beispielcode hilft beim Zugriff auf die [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt)-Form mit einem bestimmten Layouttyp. Bitte beachten Sie, dass Sie den Layouttyp der SmartArt nicht ändern können, da er nur schreibgeschützt ist und nur festgelegt wird, wenn die [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt)-Form hinzugefügt wird.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)-Klasse und laden Sie die Präsentation mit der SmartArt-Form.
1. Erhalten Sie die Referenz der ersten Folie, indem Sie ihren Index verwenden.
1. Durchlaufen Sie jede Form innerhalb der ersten Folie.
1. Überprüfen Sie, ob die Form vom [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt)-Typ ist, und typisieren Sie die ausgewählte Form als SmartArt, wenn es sich um SmartArt handelt.
1. Überprüfen Sie die SmartArt-Form mit einem bestimmten Layouttyp und führen Sie anschließend die erforderlichen Aktionen durch.

```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Jede Form innerhalb der ersten Folie durchlaufen
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Überprüfen, ob die Form vom SmartArt-Typ ist
        if (shape instanceof ISmartArt)
        {
            // Form zu SmartArtEx typisieren
            ISmartArt smart = (ISmartArt) shape;

            // Überprüfen des SmartArt-Layouts
            if (smart.getLayout() == SmartArtLayoutType.BasicBlockList)
            {
                System.out.println("Hier etwas tun....");
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt-Form-Stil ändern**
In diesem Beispiel lernen wir, den Schnellstil für eine SmartArt-Form zu ändern.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)-Klasse und laden Sie die Präsentation mit der SmartArt-Form.
1. Erhalten Sie die Referenz der ersten Folie, indem Sie ihren Index verwenden.
1. Durchlaufen Sie jede Form innerhalb der ersten Folie.
1. Überprüfen Sie, ob die Form vom [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt)-Typ ist, und typisieren Sie die ausgewählte Form als SmartArt, wenn es sich um SmartArt handelt.
1. Finden Sie die SmartArt-Form mit einem bestimmten Stil.
1. Setzen Sie den neuen Stil für die SmartArt-Form.
1. Speichern Sie die Präsentation.

```java
// Instanziieren der Präsentationsklasse
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Erste Folie abrufen
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Jede Form innerhalb der ersten Folie durchlaufen
    for (IShape shape : slide.getShapes()) 
    {
        // Überprüfen, ob die Form vom SmartArt-Typ ist
        if (shape instanceof ISmartArt) 
        {
            // Form zu SmartArtEx typisieren
            ISmartArt smart = (ISmartArt) shape;
    
            // Überprüfen des SmartArt-Stils
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

## **SmartArt-Form-Farbstil ändern**
In diesem Beispiel lernen wir, den Farbstil für eine SmartArt-Form zu ändern. Im folgenden Beispielcode wird auf die SmartArt-Form mit einem bestimmten Farbstil zugegriffen und dessen Stil geändert.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)-Klasse und laden Sie die Präsentation mit der SmartArt-Form.
1. Erhalten Sie die Referenz der ersten Folie, indem Sie ihren Index verwenden.
1. Durchlaufen Sie jede Form innerhalb der ersten Folie.
1. Überprüfen Sie, ob die Form vom [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt)-Typ ist, und typisieren Sie die ausgewählte Form als SmartArt, wenn es sich um SmartArt handelt.
1. Finden Sie die SmartArt-Form mit einem bestimmten Farbstil.
1. Setzen Sie den neuen Farbstil für die SmartArt-Form.
1. Speichern Sie die Präsentation.

```java
// Instanziieren der Präsentationsklasse
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Erste Folie abrufen
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Jede Form innerhalb der ersten Folie durchlaufen
    for (IShape shape : slide.getShapes()) 
    {
        // Überprüfen, ob die Form vom SmartArt-Typ ist
        if (shape instanceof ISmartArt) 
        {
            // Form zu SmartArtEx typisieren
            ISmartArt smart = (ISmartArt) shape;
    
            // Überprüfen des SmartArt-Farbstils
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