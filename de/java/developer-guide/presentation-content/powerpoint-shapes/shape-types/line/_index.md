---
title: "Linienformen zu Präsentationen in Java hinzufügen"
linktitle: "Linie"
type: docs
weight: 50
url: /de/java/Line/
keywords:
- Linie
- Linie erstellen
- Linie hinzufügen
- einfache Linie
- Linie konfigurieren
- Linie anpassen
- Strichstil
- Pfeilspitze
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie die Linienformatierung in PowerPoint-Präsentationen mit Aspose.Slides für Java manipulieren. Entdecken Sie Eigenschaften, Methoden und Beispiele."
---

{{% alert color="primary" %}} 

Aspose.Slides for Java unterstützt das Hinzufügen verschiedener Formen zu den Folien. In diesem Thema beginnen wir mit Formen, indem wir Linien zu den Folien hinzufügen. Mit Aspose.Slides for Java können Entwickler nicht nur einfache Linien erstellen, sondern auch ausgefallene Linien auf den Folien zeichnen.

{{% /alert %}} 

## **Eine einfache Linie erstellen**

Um eine einfache Linie zu einer ausgewählten Folie der Präsentation hinzuzufügen, gehen Sie bitte wie folgt vor:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Holen Sie sich die Referenz einer Folie, indem Sie deren Index verwenden.
- Fügen Sie eine AutoShape vom Typ Line hinzu, indem Sie die Methode [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) verwenden, die vom Objekt [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) bereitgestellt wird.
- Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Im nachstehenden Beispiel haben wir einer ersten Folie der Präsentation eine Linie hinzugefügt.
```java
// Instanziieren Sie die PresentationEx-Klasse, die die PPTX-Datei repräsentiert
Presentation pres = new Presentation();
try {
    // Holen Sie die erste Folie
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Fügen Sie eine AutoShape vom Typ Linie hinzu
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // Schreiben Sie die PPTX auf die Festplatte
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Eine pfeilförmige Linie erstellen**

Aspose.Slides for Java ermöglicht es Entwicklern zudem, einige Eigenschaften der Linie zu konfigurieren, damit sie ansprechender aussieht. Versuchen wir, einige Eigenschaften einer Linie so zu konfigurieren, dass sie wie ein Pfeil aussieht. Bitte folgen Sie den nachstehenden Schritten, um dies zu tun:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Holen Sie sich die Referenz einer Folie, indem Sie deren Index verwenden.
- Fügen Sie eine AutoShape vom Typ Line hinzu, indem Sie die Methode [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) verwenden, die vom Objekt [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) bereitgestellt wird.
- Setzen Sie den [Line Style](https://reference.aspose.com/slides/java/com.aspose.slides/LineStyle) auf einen der von Aspose.Slides for Java angebotenen Stile.
- Setzen Sie die Breite der Linie.
- Setzen Sie den [Dash Style](https://reference.aspose.com/slides/java/com.aspose.slides/LineDashStyle) der Linie auf einen der von Aspose.Slides for Java angebotenen Stile.
- Setzen Sie den [Arrow Head Style](https://reference.aspose.com/slides/java/com.aspose.slides/LineArrowheadStyle) und die [Length](https://reference.aspose.com/slides/java/com.aspose.slides/LineArrowheadLength) des Startpunkts der Linie.
- Setzen Sie den [Arrow Head Style](https://reference.aspose.com/slides/java/com.aspose.slides/LineArrowheadStyle) und die [Length](https://reference.aspose.com/slides/java/com.aspose.slides/LineArrowheadLength) des Endpunkts der Linie.
- Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.
```java
// Instanziieren Sie die PresentationEx-Klasse, die die PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Holen Sie die erste Folie
    ISlide sld = pres.getSlides().get_Item(0);

    // Fügen Sie eine AutoShape vom Typ Linie hinzu
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Wenden Sie einige Formatierungen auf die Linie an
    shp.getLineFormat().setStyle(LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);

    shp.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    shp.getLineFormat().setBeginArrowheadLength(LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.Oval);

    shp.getLineFormat().setEndArrowheadLength(LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);

    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Maroon));

    // Schreiben Sie die PPTX auf die Festplatte
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Kann ich eine normale Linie in einen Connector umwandeln, damit sie an Formen „einrastet“?**

Nein. Eine normale Linie (eine [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/) vom Typ [Line](https://reference.aspose.com/slides/java/com.aspose.slides/shapetype/)) wird nicht automatisch zu einem Connector. Um sie an Formen einrasten zu lassen, verwenden Sie den speziellen [Connector](https://reference.aspose.com/slides/java/com.aspose.slides/connector/)‑Typ und die [entsprechende APIs](/slides/de/java/connector/) für Verbindungen.

**Was soll ich tun, wenn die Eigenschaften einer Linie vom Theme geerbt werden und es schwierig ist, die endgültigen Werte zu bestimmen?**

[Lesen Sie die effektiven Eigenschaften](/slides/de/java/shape-effective-properties/) über die Schnittstellen [ILineFormatEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ilinefillformateffectivedata/) — diese berücksichtigen bereits Vererbung und Theme‑Stile.

**Kann ich eine Linie gegen Bearbeitung (Verschieben, Größenändern) sperren?**

Ja. Formen stellen [lock objects](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/#getAutoShapeLock--) bereit, die es ermöglichen, [Bearbeitungsoperationen nicht zulassen](/slides/de/java/applying-protection-to-presentation/) zu verhindern.