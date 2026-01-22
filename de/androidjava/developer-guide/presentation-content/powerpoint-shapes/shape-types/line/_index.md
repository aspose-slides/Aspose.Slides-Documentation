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
description: "Lernen Sie, die Linienformatierung in PowerPoint-Präsentationen mit Aspose.Slides für Android zu manipulieren. Entdecken Sie Eigenschaften, Methoden und Java-Beispiele."
---

{{% alert color="primary" %}} 

Aspose.Slides for Android via Java unterstützt das Hinzufügen verschiedener Formen zu den Folien. In diesem Thema beginnen wir mit Formen, indem wir Linien zu den Folien hinzufügen. Mit Aspose.Slides for Android via Java können Entwickler nicht nur einfache Linien erstellen, sondern auch einige ausgefallene Linien auf den Folien zeichnen.

{{% /alert %}} 

## **Eine einfache Linie erstellen**

Um einer ausgewählten Folie der Präsentation eine einfache Linie hinzuzufügen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
- Holen Sie die Referenz einer Folie anhand ihres Index.
- Fügen Sie mit der Methode [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) ein AutoShape vom Typ Linie hinzu, das vom Objekt [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) bereitgestellt wird.
- Speichern Sie die geänderte Präsentation als PPTX-Datei.

Im nachstehenden Beispiel haben wir eine Linie zur ersten Folie der Präsentation hinzugefügt.
```java
// Instanziiere die PresentationEx-Klasse, die die PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Hole die erste Folie
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Füge ein AutoShape vom Typ Linie hinzu
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // Schreibe die PPTX auf die Festplatte
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Eine pfeilförmige Linie erstellen**

Aspose.Slides for Android via Java ermöglicht es Entwicklern außerdem, einige Eigenschaften der Linie zu konfigurieren, um sie ansprechender zu gestalten. Versuchen wir, einige Eigenschaften einer Linie zu konfigurieren, damit sie wie ein Pfeil aussieht. Bitte befolgen Sie die folgenden Schritte, um dies zu tun:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
- Holen Sie die Referenz einer Folie anhand ihres Index.
- Fügen Sie mit der Methode [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) ein AutoShape vom Typ Linie hinzu, das vom Objekt [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) bereitgestellt wird.
- Setzen Sie den [Line Style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineStyle) auf einen der von Aspose.Slides for Android via Java angebotenen Stile.
- Setzen Sie die Breite der Linie.
- Setzen Sie den [Dash Style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineDashStyle) der Linie auf einen der von Aspose.Slides for Android via Java angebotenen Stile.
- Setzen Sie den [Arrow Head Style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadStyle) und die [Length](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadLength) des Startpunkts der Linie.
- Setzen Sie den [Arrow Head Style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadStyle) und die [Length](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadLength) des Endpunkts der Linie.
- Speichern Sie die geänderte Präsentation als PPTX-Datei.
```java
// Instanziiere die PresentationEx-Klasse, die die PPTX-Datei repräsentiert
Presentation pres = new Presentation();
try {
    // Hole die erste Folie
    ISlide sld = pres.getSlides().get_Item(0);

    // Füge ein AutoShape vom Typ Linie hinzu
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Wende einige Formatierungen auf die Linie an
    shp.getLineFormat().setStyle(LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);

    shp.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    shp.getLineFormat().setBeginArrowheadLength(LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.Oval);

    shp.getLineFormat().setEndArrowheadLength(LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);

    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Maroon));

    // Schreibe die PPTX auf die Festplatte
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Kann ich eine normale Linie in einen Connector umwandeln, damit sie an Formen "schnappt"?**

Nein. Eine normale Linie (ein [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/) vom Typ [Line](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapetype/)) wird nicht automatisch zu einem Connector. Um sie an Formen zu schnappen, verwenden Sie den dedizierten [Connector](https://reference.aspose.com/slides/androidjava/com.aspose.slides/connector/)‑Typ und die [corresponding APIs](/slides/de/androidjava/connector/) für Verbindungen.

**Was soll ich tun, wenn die Eigenschaften einer Linie vom Theme geerbt werden und es schwierig ist, die endgültigen Werte zu bestimmen?**

[Lesen Sie die effektiven Eigenschaften](/slides/de/androidjava/shape-effective-properties/) über die Schnittstellen [ILineFormatEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilinefillformateffectivedata/) — diese berücksichtigen bereits Vererbung und Theme‑Stile.

**Kann ich eine Linie gegen Bearbeitung (Verschieben, Größe ändern) sperren?**

Ja. Formen bieten [lock objects](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/#getAutoShapeLock--) , mit denen Sie Bearbeitungsvorgänge verbieten können.