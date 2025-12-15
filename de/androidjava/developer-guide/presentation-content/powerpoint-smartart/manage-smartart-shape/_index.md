---
title: Verwalten von SmartArt-Grafiken in Präsentationen auf Android
linktitle: SmartArt-Grafiken
type: docs
weight: 20
url: /de/androidjava/manage-smartart-shape/
keywords:
- SmartArt-Objekt
- SmartArt-Grafik
- SmartArt-Stil
- SmartArt-Farbe
- SmartArt erstellen
- SmartArt hinzufügen
- SmartArt bearbeiten
- SmartArt ändern
- SmartArt zugreifen
- SmartArt-Layouttyp
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Automatisieren Sie die Erstellung, Bearbeitung und Formatierung von PowerPoint-SmartArt mit Aspose.Slides für Android, einschließlich prägnanter Java-Codebeispiele und leistungsgesteuerter Anleitungen."
---

## **SmartArt-Form erstellen**
Aspose.Slides for Android via Java stellt eine API zum Erstellen von SmartArt-Formen bereit. Um eine SmartArt-Form in einer Folie zu erstellen, führen Sie bitte die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
2. Holen Sie sich die Referenz einer Folie, indem Sie deren Index verwenden.
3. [SmartArt-Form hinzufügen](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) und dabei den [LayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtLayoutType) festlegen.
4. Speichern Sie die modifizierte Präsentation als PPTX-Datei.
```java
// Instanziiere Presentation-Klasse
Presentation pres = new Presentation();
try {
    // Erste Folie holen
    ISlide slide = pres.getSlides().get_Item(0);
    
    // SmartArt-Form hinzufügen
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
    
    // Präsentation speichern
    pres.save("SimpleSmartArt.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figure: SmartArt shape added to the slide**|

## **Zugriff auf eine SmartArt-Form in einer Folie**
Der folgende Code wird verwendet, um auf die in der Präsentationsfolie hinzugefügten SmartArt-Formen zuzugreifen. Im Beispielcode durchlaufen wir jede Form innerhalb der Folie und prüfen, ob es sich um eine [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) Form handelt. Ist die Form vom Typ SmartArt, werden wir sie in eine [**SmartArt**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) Instanz umwandeln.
```java
// Lade die gewünschte Präsentation
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Durchlaufe jede Form in der ersten Folie
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Überprüfe, ob die Form vom SmartArt-Typ ist
        if (shape instanceof ISmartArt)
        {
            // Wandle die Form in SmartArtEx um
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Zugriff auf eine SmartArt-Form mit einem bestimmten Layouttyp**
Der folgende Beispielcode hilft, die [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt)‑Form mit einem bestimmten LayoutType zuzugreifen. Bitte beachten Sie, dass Sie den LayoutType der SmartArt nicht ändern können, da er nur lesbar ist und ausschließlich beim Hinzufügen der [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt)‑Form festgelegt wird.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) und laden Sie die Präsentation mit einer SmartArt-Form.
2. Holen Sie sich die Referenz der ersten Folie, indem Sie deren Index verwenden.
3. Durchlaufen Sie jede Form in der ersten Folie.
4. Prüfen Sie, ob die Form vom Typ [SmartArt] ist, und wandeln Sie die ausgewählte Form in SmartArt um, falls sie SmartArt ist.
5. Überprüfen Sie die SmartArt-Form mit dem gewünschten LayoutType und führen Sie anschließend die erforderlichen Aktionen aus.
```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Durchlaufe jede Form in der ersten Folie
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Überprüfe, ob die Form vom SmartArt-Typ ist
        if (shape instanceof ISmartArt)
        {
            // Wandle die Form in SmartArtEx um
            ISmartArt smart = (ISmartArt) shape;

            // Überprüfe das SmartArt-Layout
            if (smart.getLayout() == SmartArtLayoutType.BasicBlockList)
            {
                System.out.println("Do some thing here....");
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **SmartArt-Formstil ändern**
In diesem Beispiel lernen wir, den Schnellstil einer beliebigen SmartArt-Form zu ändern.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) und laden Sie die Präsentation mit einer SmartArt-Form.
2. Holen Sie sich die Referenz der ersten Folie, indem Sie deren Index verwenden.
3. Durchlaufen Sie jede Form in der ersten Folie.
4. Prüfen Sie, ob die Form vom Typ [SmartArt] ist, und wandeln Sie die ausgewählte Form in SmartArt um, falls sie SmartArt ist.
5. Finden Sie die SmartArt-Form mit einem bestimmten Stil.
6. Legen Sie den neuen Stil für die SmartArt-Form fest.
7. Speichern Sie die Präsentation.
```java
// Instanziiere Presentation-Klasse
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Erste Folie holen
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Durchlaufe jede Form in der ersten Folie
    for (IShape shape : slide.getShapes()) 
    {
        // Überprüfe, ob die Form vom SmartArt-Typ ist
        if (shape instanceof ISmartArt) 
        {
            // Wandle die Form in SmartArtEx um
            ISmartArt smart = (ISmartArt) shape;
    
            // Überprüfe den SmartArt-Stil
            if (smart.getQuickStyle() == SmartArtQuickStyleType.SimpleFill) {
                // SmartArt-Stil ändern
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
|**Figure: SmartArt shape with changed Style**|

## **SmartArt-Form-Farbstil ändern**
In diesem Beispiel lernen wir, den Farbstil einer beliebigen SmartArt-Form zu ändern. Im folgenden Beispielcode wird auf die SmartArt-Form mit einem bestimmten Farbstil zugegriffen und ihr Stil geändert.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) und laden Sie die Präsentation mit einer SmartArt-Form.
2. Holen Sie sich die Referenz der ersten Folie, indem Sie deren Index verwenden.
3. Durchlaufen Sie jede Form in der ersten Folie.
4. Prüfen Sie, ob die Form vom Typ [SmartArt] ist, und wandeln Sie die ausgewählte Form in SmartArt um, falls sie SmartArt ist.
5. Finden Sie die SmartArt-Form mit einem bestimmten Farbstil.
6. Legen Sie den neuen Farbstil für die SmartArt-Form fest.
7. Speichern Sie die Präsentation.
```java
// Instanziiere Presentation-Klasse
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Erste Folie holen
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Durchlaufe jede Form in der ersten Folie
    for (IShape shape : slide.getShapes()) 
    {
        // Überprüfe, ob die Form vom SmartArt-Typ ist
        if (shape instanceof ISmartArt) 
        {
            // Wandle die Form in SmartArtEx um
            ISmartArt smart = (ISmartArt) shape;
    
            // Überprüfe den SmartArt-Farbtyp
            if (smart.getColorStyle() == SmartArtColorType.ColoredFillAccent1) {
                // SmartArt-Farbtyp ändern
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
|**Figure: SmartArt shape with changed Color Style**|

## **FAQ**

**Kann ich SmartArt als ein einzelnes Objekt animieren?**

Ja. SmartArt ist eine Form, daher können Sie über die Animations‑API [Standardanimationen](/slides/de/androidjava/powerpoint-animation/) (Eingang, Ausgang, Hervorhebung, Bewegungspfad) genauso wie bei anderen Formen anwenden.

**Wie finde ich ein bestimmtes SmartArt auf einer Folie, wenn ich seine interne ID nicht kenne?**

Legen Sie den Alternativtext (AltText) fest und verwenden Sie ihn, um nach der Form zu suchen – dies ist ein empfohlener Weg, die Zielform zu finden.

**Kann ich SmartArt mit anderen Formen gruppieren?**

Ja. Sie können SmartArt mit anderen Formen (Bildern, Tabellen usw.) gruppieren und dann die [Gruppe manipulieren](/slides/de/androidjava/group/).

**Wie erhalte ich ein Bild eines bestimmten SmartArt (z. B. für eine Vorschau oder einen Bericht)?**

Exportieren Sie ein Vorschaubild/Thumbnail der Form; die Bibliothek kann [einzelne Formen rendern](/slides/de/androidjava/create-shape-thumbnails/) zu Rasterdateien (PNG/JPG/TIFF).

**Wird das Aussehen von SmartArt beim Konvertieren der gesamten Präsentation in PDF erhalten bleiben?**

Ja. Die Rendering‑Engine strebt eine hohe Treue beim [PDF‑Export](/slides/de/androidjava/convert-powerpoint-to-pdf/) an und bietet verschiedene Qualitäts‑ und Kompatibilitätsoptionen.