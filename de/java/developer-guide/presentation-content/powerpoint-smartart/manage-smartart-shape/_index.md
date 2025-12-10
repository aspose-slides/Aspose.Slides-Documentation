---
title: SmartArt-Grafiken in Präsentationen mit Java verwalten
linktitle: SmartArt-Grafiken
type: docs
weight: 20
url: /de/java/manage-smartart-shape/
keywords:
- SmartArt-Objekt
- SmartArt-Grafik
- SmartArt-Stil
- SmartArt-Farbe
- SmartArt erstellen
- SmartArt hinzufügen
- SmartArt bearbeiten
- SmartArt ändern
- SmartArt abrufen
- SmartArt-Layouttyp
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Automatisieren Sie die Erstellung, Bearbeitung und Gestaltung von PowerPoint-SmartArt in Java mit Aspose.Slides, inklusive prägnanter Codebeispiele und leistungsgesteuerter Anleitung."
---

## **SmartArt-Form erstellen**
Aspose.Slides for Java hat eine API zum Erstellen von SmartArt-Formen bereitgestellt. Um eine SmartArt-Form in einer Folie zu erstellen, befolgen Sie bitte die nachstehenden Schritte:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Rufen Sie die Referenz einer Folie über deren Index ab.
3. Fügen Sie eine [SmartArt-Form hinzufügen](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) hinzu, indem Sie den [LayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtLayoutType) festlegen.
4. Speichern Sie die modifizierte Präsentation als PPTX-Datei.
```java
    // Präsentationsklasse instanziieren
    Presentation pres = new Presentation();
    try {
        // Erste Folie abrufen
        ISlide slide = pres.getSlides().get_Item(0);
        
        // Smart Art-Form hinzufügen
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

## **Zugriff auf eine SmartArt-Form auf einer Folie**
Der folgende Code wird verwendet, um auf die in der Präsentationsfolie hinzugefügten SmartArt-Formen zuzugreifen. Im Beispielcode durchlaufen wir jede Form in der Folie und prüfen, ob es sich um eine [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt)‑Form handelt. Ist die Form vom Typ SmartArt, dann casten wir sie in eine [**SmartArt**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt)‑Instanz.
```java
// Lade die gewünschte Präsentation
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Durchlaufe jede Form in der ersten Folie
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Prüfe, ob die Form vom SmartArt Typ ist
        if (shape instanceof ISmartArt)
        {
            // Form in SmartArt umwandeln
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Zugriff auf eine SmartArt-Form mit einem bestimmten Layouttyp**
Der folgende Beispielcode hilft, die [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt)‑Form mit einem bestimmten LayoutType zu finden. Bitte beachten Sie, dass Sie den LayoutType der SmartArt nicht ändern können, da er schreibgeschützt ist und nur festgelegt wird, wenn die [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt)‑Form hinzugefügt wird.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) und laden Sie die Präsentation mit einer SmartArt-Form.
2. Rufen Sie die Referenz der ersten Folie über deren Index ab.
3. Durchlaufen Sie jede Form in der ersten Folie.
4. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) ist, und casten Sie die ausgewählte Form zu SmartArt, falls sie SmartArt ist.
5. Prüfen Sie die SmartArt-Form mit dem gewünschten LayoutType und führen Sie anschließend die erforderlichen Aktionen aus.
```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Durchlaufe jede Form in der ersten Folie
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Prüfe, ob die Form vom SmartArt-Typ ist
        if (shape instanceof ISmartArt)
        {
            // Form in SmartArtEx umwandeln
            ISmartArt smart = (ISmartArt) shape;

            // Überprüfen des SmartArt-Layouts
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


## **Ändern eines SmartArt-Form-Stils**
In diesem Beispiel lernen wir, den Schnellstil für eine beliebige SmartArt-Form zu ändern.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) und laden Sie die Präsentation mit einer SmartArt-Form.
2. Rufen Sie die Referenz der ersten Folie über deren Index ab.
3. Durchlaufen Sie jede Form in der ersten Folie.
4. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) ist, und casten Sie die ausgewählte Form zu SmartArt, falls sie SmartArt ist.
5. Suchen Sie die SmartArt-Form mit dem gewünschten Stil.
6. Setzen Sie den neuen Stil für die SmartArt-Form.
7. Speichern Sie die Präsentation.
```java
// Präsentationsklasse instanziieren
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Erste Folie abrufen
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Durchlaufe jede Form in der ersten Folie
    for (IShape shape : slide.getShapes()) 
    {
        // Prüfe, ob die Form vom SmartArt-Typ ist
        if (shape instanceof ISmartArt) 
        {
            // Form in SmartArtEx umwandeln
            ISmartArt smart = (ISmartArt) shape;
    
            // SmartArt-Stil prüfen
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
|**Abbildung: SmartArt-Form mit geändertem Stil**|

## **Ändern eines SmartArt-Form-Farbstils**
In diesem Beispiel lernen wir, den Farbstil für eine beliebige SmartArt-Form zu ändern. Im folgenden Beispielcode wird die SmartArt-Form mit einem bestimmten Farbstil aufgerufen und ihr Stil geändert.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) und laden Sie die Präsentation mit einer SmartArt-Form.
2. Rufen Sie die Referenz der ersten Folie über deren Index ab.
3. Durchlaufen Sie jede Form in der ersten Folie.
4. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) ist, und casten Sie die ausgewählte Form zu SmartArt, falls sie SmartArt ist.
5. Suchen Sie die SmartArt-Form mit dem gewünschten Farbstil.
6. Setzen Sie den neuen Farbstil für die SmartArt-Form.
7. Speichern Sie die Präsentation.
```java
// Präsentationsklasse instanziieren
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Erste Folie abrufen
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Durchlaufe jede Form in der ersten Folie
    for (IShape shape : slide.getShapes()) 
    {
        // Prüfe, ob die Form vom SmartArt-Typ ist
        if (shape instanceof ISmartArt) 
        {
            // Form in SmartArtEx umwandeln
            ISmartArt smart = (ISmartArt) shape;
    
            // SmartArt-Farbtyp prüfen
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
|**Abbildung: SmartArt-Form mit geändertem Farbstil**|

## **FAQ**

**Kann ich SmartArt als einzelnes Objekt animieren?**  
Ja. SmartArt ist eine Form, daher können Sie über die Animations‑API (Eintritt, Austritt, Hervorhebung, Bewegungspfade) [Standardanimationen](/slides/de/java/powerpoint-animation/) wie bei anderen Formen anwenden.

**Wie kann ich ein bestimmtes SmartArt auf einer Folie finden, wenn ich seine interne ID nicht kenne?**  
Setzen Sie den Alternativtext (AltText) und suchen Sie die Form nach diesem Wert – dies ist ein empfohlener Weg, die Ziel‑Form zu lokalisieren.

**Kann ich SmartArt mit anderen Formen gruppieren?**  
Ja. Sie können SmartArt mit anderen Formen (Bilder, Tabellen usw.) gruppieren und dann die Gruppe [manipulieren](/slides/de/java/group/).

**Wie erhalte ich ein Bild eines bestimmten SmartArt (z. B. für eine Vorschau oder einen Bericht)?**  
Exportieren Sie ein Thumbnail/Bild der Form; die Bibliothek kann einzelne Formen [rendern](/slides/de/java/create-shape-thumbnails/) zu Rasterdateien (PNG/JPG/TIFF).

**Wird das Aussehen von SmartArt beim Konvertieren der gesamten Präsentation in PDF beibehalten?**  
Ja. Die Rendering‑Engine zielt auf hohe Treue für den [PDF‑Export](/slides/de/java/convert-powerpoint-to-pdf/) ab, mit einer Reihe von Qualitäts‑ und Kompatibilitätsoptionen.