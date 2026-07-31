---
title: Linienformen zu Präsentationen in Java hinzufügen
linktitle: Linie
type: docs
weight: 50
url: /de/java/line/
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
description: "Erfahren Sie, wie Sie die Linienformatierung in PowerPoint‑Präsentationen mit Aspose.Slides für Java manipulieren. Entdecken Sie Eigenschaften, Methoden und Beispiele."
---
## **Übersicht**

Aspose.Slides ermöglicht es Ihnen, Linienformen programmgesteuert zu PowerPoint‑Folien hinzuzufügen. Dieser Artikel zeigt, wie Sie eine einfache Linie erstellen und wie Sie eine Linie anpassen, sodass sie als Pfeil dargestellt wird.

Sie lernen, wie Sie einer Folie eine Linienform hinzufügen, ihr Aussehen anpassen und die aktualisierte Präsentation speichern. Die Beispiele konzentrieren sich auf praktische Formatierungseinstellungen für Linien, wie Stil, Breite, Strichmuster, Pfeilspitzenoptionen und Füllfarbe.

## **Einfache Linie erstellen**

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation).
- Rufen Sie die Referenz einer Folie über deren Index ab.
- Fügen Sie mit der Methode [addAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) ein AutoShape vom Typ Line hinzu, die vom Objekt [IShapeCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/IShapeCollection) bereitgestellt wird.
- Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Im nachstehenden Beispiel haben wir eine Linie zur ersten Folie der Präsentation hinzugefügt.

```java
// Instanziiere die PresentationEx-Klasse, die die PPTX-Datei repräsentiert
Presentation pres = new Presentation();
try {
    // Hole die erste Folie
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Füge ein AutoShape vom Typ Linie hinzu
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // Schreibe die PPTX-Datei auf die Festplatte
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Pfeilförmige Linie erstellen**

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation).
- Rufen Sie die Referenz einer Folie über deren Index ab.
- Fügen Sie mit der Methode [addAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) ein AutoShape vom Typ Line hinzu, die vom Objekt [IShapeCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/IShapeCollection) bereitgestellt wird.
- Setzen Sie den [Line Style](https://reference.aspose.com/slides/de/java/com.aspose.slides/LineStyle) auf einen der von Aspose.Slides für Java angebotenen Stile.
- Legen Sie die Breite der Linie fest.
- Setzen Sie den [Dash Style](https://reference.aspose.com/slides/de/java/com.aspose.slides/LineDashStyle) der Linie auf einen der von Aspose.Slides für Java angebotenen Stile.
- Legen Sie den [Arrow Head Style](https://reference.aspose.com/slides/de/java/com.aspose.slides/LineArrowheadStyle) und die [Length](https://reference.aspose.com/slides/de/java/com.aspose.slides/LineArrowheadLength) des Startpunkts der Linie fest.
- Legen Sie den [Arrow Head Style](https://reference.aspose.com/slides/de/java/com.aspose.slides/LineArrowheadStyle) und die [Length](https://reference.aspose.com/slides/de/java/com.aspose.slides/LineArrowheadLength) des Endpunkts der Linie fest.
- Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

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

    // Schreibe die PPTX-Datei auf die Festplatte
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Kann ich eine normale Linie in einen Connector umwandeln, sodass sie an Formen „einrastet“?**

Nein. Eine normale Linie (ein [AutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/autoshape/) vom Typ [Line](https://reference.aspose.com/slides/de/java/com.aspose.slides/shapetype/)) wird nicht automatisch zu einem Connector. Um sie an Formen einrasten zu lassen, verwenden Sie den speziellen [Connector](https://reference.aspose.com/slides/de/java/com.aspose.slides/connector/)‑Typ und die [corresponding APIs](/slides/de/java/connector/) für Verbindungen.

**Was soll ich tun, wenn die Eigenschaften einer Linie vom Theme geerbt werden und die endgültigen Werte schwer zu bestimmen sind?**

Lesen Sie die [effective properties](/slides/de/java/shape-effective-properties/) über die Schnittstellen [ILineFormatEffectiveData](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilinefillformateffectivedata/); diese berücksichtigen bereits Vererbung und Theme‑Stile.

**Kann ich eine Linie vor Bearbeitung (Verschieben, Größenänderung) schützen?**

Ja. Formen bieten [lock objects](https://reference.aspose.com/slides/de/java/com.aspose.slides/autoshape/#getAutoShapeLock--) an, mit denen Sie [disallow editing operations](/slides/de/java/applying-protection-to-presentation/) verhindern.