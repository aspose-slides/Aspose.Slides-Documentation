---
title: Linie
type: docs
weight: 50
url: /de/androidjava/Line/
---


{{% alert color="primary" %}} 

Aspose.Slides für Android über Java unterstützt das Hinzufügen verschiedener Arten von Formen zu den Folien. In diesem Thema werden wir mit Formen beginnen, indem wir Linien zu den Folien hinzufügen. Mit Aspose.Slides für Android über Java können Entwickler nicht nur einfache Linien erstellen, sondern auch einige ausgefallene Linien auf den Folien zeichnen.

{{% /alert %}} 

## **Einfache Linie erstellen**

Um eine einfache, gerade Linie zu einer ausgewählten Folie der Präsentation hinzuzufügen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
- Erhalten Sie den Verweis auf eine Folie, indem Sie ihren Index verwenden.
- Fügen Sie eine AutoShape vom Typ Linie mit der Methode [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) hinzu, die vom [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) Objekt bereitgestellt wird.
- Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Im folgenden Beispiel haben wir eine Linie zur ersten Folie der Präsentation hinzugefügt.

```java
// Erstellen Sie eine Instanz der PresentationEx-Klasse, die die PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Erhalten Sie die erste Folie
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Fügen Sie eine AutoShape vom Typ Linie hinzu
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // Schreiben Sie die PPTX auf die Festplatte
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Pfeilförmige Linie erstellen**

Aspose.Slides für Android über Java ermöglicht es Entwicklern auch, einige Eigenschaften der Linie zu konfigurieren, um sie ansprechender zu gestalten. Lassen Sie uns versuchen, einige Eigenschaften einer Linie zu konfigurieren, damit sie wie ein Pfeil aussieht. Bitte folgen Sie den untenstehenden Schritten:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
- Erhalten Sie den Verweis auf eine Folie, indem Sie ihren Index verwenden.
- Fügen Sie eine AutoShape vom Typ Linie mit der Methode [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) hinzu, die vom [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) Objekt bereitgestellt wird.
- Setzen Sie den [Linienstil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineStyle) auf einen der Stile, die von Aspose.Slides für Android über Java angeboten werden.
- Setzen Sie die Breite der Linie.
- Setzen Sie den [Strichstil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineDashStyle) der Linie auf einen der Stile, die von Aspose.Slides für Android über Java angeboten werden.
- Setzen Sie den [Pfeilkopfstil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadStyle) und die [Länge](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadLength) des Startpunkts der Linie.
- Setzen Sie den [Pfeilkopfstil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadStyle) und die [Länge](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadLength) des Endpunkts der Linie.
- Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

```java
// Erstellen Sie eine Instanz der PresentationEx-Klasse, die die PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Erhalten Sie die erste Folie
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