---
title: Linienformen zu Präsentationen auf Android hinzufügen
linktitle: Linie
type: docs
weight: 50
url: /de/androidjava/Line/
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
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie die Linienformatierung in PowerPoint‑Präsentationen mit Aspose.Slides für Android manipulieren. Entdecken Sie Eigenschaften, Methoden und Java‑Beispiele."
---

{{% alert color="primary" %}} 

Aspose.Slides für Android über Java unterstützt das Hinzufügen verschiedener Formen zu den Folien. In diesem Thema beginnen wir mit Formen, indem wir Linien zu den Folien hinzufügen. Mit Aspose.Slides für Android über Java können Entwickler nicht nur einfache Linien erstellen, sondern auch ausgefallene Linien auf den Folien zeichnen.

{{% /alert %}} 

## **Einfache Linie erstellen**

Um eine einfache gerade Linie zu einer ausgewählten Folie der Präsentation hinzuzufügen, folgen Sie bitte den untenstehenden Schritten:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Erhalten Sie die Referenz einer Folie, indem Sie deren Index verwenden.
- Fügen Sie eine AutoShape vom Typ Linie mithilfe der Methode [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) hinzu, die vom Objekt [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) bereitgestellt wird.
- Schreiben Sie die geänderte Präsentation als PPTX-Datei.

Im nachstehenden Beispiel haben wir eine Linie zur ersten Folie der Präsentation hinzugefügt.
```java
// Instanziieren Sie die PresentationEx-Klasse, die die PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Erste Folie abrufen
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Fügen Sie eine AutoShape vom Typ Linie hinzu
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // PPTX auf die Festplatte schreiben
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Pfeilförmige Linie erstellen**

Aspose.Slides für Android über Java ermöglicht es Entwicklern auch, einige Eigenschaften der Linie zu konfigurieren, damit sie ansprechender aussieht. Versuchen wir, einige Eigenschaften einer Linie zu konfigurieren, damit sie wie ein Pfeil aussieht. Befolgen Sie dazu die folgenden Schritte:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Erhalten Sie die Referenz einer Folie, indem Sie deren Index verwenden.
- Fügen Sie eine AutoShape vom Typ Linie mithilfe der Methode [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) hinzu, die vom Objekt [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) bereitgestellt wird.
- Setzen Sie den [Line Style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineStyle) auf einen der von Aspose.Slides für Android über Java angebotenen Stile.
- Legen Sie die Breite der Linie fest.
- Setzen Sie den [Dash Style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineDashStyle) der Linie auf einen der von Aspose.Slides für Android über Java angebotenen Stile.
- Legen Sie den [Arrow Head Style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadStyle) und die [Length](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadLength) des Startpunkts der Linie fest.
- Legen Sie den [Arrow Head Style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadStyle) und die [Length](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadLength) des Endpunkts der Linie fest.
- Schreiben Sie die geänderte Präsentation als PPTX-Datei.
```java
// Instanziieren Sie die PresentationEx‑Klasse, die die PPTX‑Datei darstellt
Presentation pres = new Presentation();
try {
    // Erste Folie abrufen
    ISlide sld = pres.getSlides().get_Item(0);

    // AutoShape vom Typ Linie hinzufügen
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

    // PPTX auf die Festplatte schreiben
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Kann ich eine normale Linie in einen Verbinder umwandeln, sodass sie an Formen „einrastet“?**

Nein. Eine normale Linie (ein [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/) vom Typ [Line](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapetype/)) wird nicht automatisch zu einem Verbinder. Um sie an Formen einrasten zu lassen, verwenden Sie den dedizierten [Connector](https://reference.aspose.com/slides/androidjava/com.aspose.slides/connector/) Typ und die [corresponding APIs](/slides/de/androidjava/connector/) für Verbindungen.

**Was soll ich tun, wenn die Eigenschaften einer Linie vom Design geerbt werden und es schwierig ist, die endgültigen Werte zu bestimmen?**

Lesen Sie die effektiven Eigenschaften ([Read the effective properties](/slides/de/androidjava/shape-effective-properties/)) über die Schnittstellen [ILineFormatEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformateffectivedata/) / [ILineFillFormatEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilinefillformateffectivedata/); diese berücksichtigen bereits Vererbung und Designstile.

**Kann ich eine Linie gegen Bearbeitung (Verschieben, Größenänderung) sperren?**

Ja. Formen bieten [lock objects](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/#getAutoShapeLock--) , mit denen Sie das Bearbeiten ([disallow editing operations](/slides/de/androidjava/applying-protection-to-presentation/)) verhindern können.