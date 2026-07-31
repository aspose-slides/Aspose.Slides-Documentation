---
title: Linienformen zu Präsentationen auf Android hinzufügen
linktitle: Linie
type: docs
weight: 50
url: /de/androidjava/line/
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
## **Übersicht**

Aspose.Slides ermöglicht das programmgesteuerte Hinzufügen von Linienformen zu PowerPoint‑Folien. Dieser Artikel zeigt, wie man eine einfache Linie erstellt und wie man eine Linie so anpasst, dass sie wie ein Pfeil aussieht.

Sie lernen, wie man einer Folie eine Linienform hinzufügt, ihr Aussehen anpasst und die aktualisierte Präsentation speichert. Die Beispiele konzentrieren sich auf praktische Formatierungseinstellungen für Linien wie Stil, Breite, Strichmuster, Pfeilspitzenoptionen und Füllfarbe.

## **Einfache Linie erstellen**

Um einer ausgewählten Folie der Präsentation eine einfache Linie hinzuzufügen, gehen Sie wie folgt vor:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation)-Klasse.
- Rufen Sie die Referenz einer Folie über ihren Index ab.
- Fügen Sie mit der Methode [addAutoShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) ein AutoShape vom Typ Line über das [IShapeCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IShapeCollection)-Objekt hinzu.
- Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Im nachfolgenden Beispiel haben wir eine Linie zur ersten Folie der Präsentation hinzugefügt.

```java
// Instanziieren Sie die PresentationEx-Klasse, die die PPTX-Datei repräsentiert
Presentation pres = new Presentation();
try {
    // Erhalte die erste Folie
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Füge ein AutoShape vom Typ Linie hinzu
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // Schreibe die PPTX auf die Festplatte
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Pfeilförmige Linie erstellen**

Aspose.Slides for Android via Java ermöglicht Entwicklern außerdem, einige Eigenschaften der Linie zu konfigurieren, um sie ansprechender zu gestalten. Konfigurieren wir ein paar Eigenschaften, damit die Linie wie ein Pfeil aussieht. Befolgen Sie dazu die nachstehenden Schritte:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation)-Klasse.
- Rufen Sie die Referenz einer Folie über ihren Index ab.
- Fügen Sie mit der Methode [addAutoShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) ein AutoShape vom Typ Line über das [IShapeCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IShapeCollection)-Objekt hinzu.
- Setzen Sie den [Linienstil](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/LineStyle) auf einen der von Aspose.Slides for Android via Java angebotenen Stile.
- Legen Sie die Breite der Linie fest.
- Setzen Sie den [Strichstil](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/LineDashStyle) der Linie auf einen der von Aspose.Slides for Android via Java angebotenen Stile.
- Definieren Sie den [Pfeilspitzenstil](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/LineArrowheadStyle) und die [Länge](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/LineArrowheadLength) des Startpunkts der Linie.
- Definieren Sie den [Pfeilspitzenstil](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/LineArrowheadStyle) und die [Länge](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/LineArrowheadLength) des Endpunkts der Linie.
- Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

```java
// Instanziieren Sie die PresentationEx-Klasse, die die PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Erhalte die erste Folie
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

**Kann ich eine normale Linie in einen Verbinder umwandeln, damit sie „an Formen einrastet“?**

Nein. Eine normale Linie (ein [AutoShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/autoshape/) vom Typ [Line](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/shapetype/)) wird nicht automatisch zu einem Verbinder. Verwenden Sie den dedizierten [Connector](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/connector/)-Typ und die [entsprechenden APIs](/slides/de/androidjava/connector/) für Verbindungen.

**Was soll ich tun, wenn die Eigenschaften einer Linie vom Design übernommen werden und es schwierig ist, die endgültigen Werte zu bestimmen?**

Lesen Sie die [effektiven Eigenschaften](/slides/de/androidjava/shape-effective-properties/) über die Schnittstellen [ILineFormatEffectiveData](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ilinefillformateffectivedata/); diese berücksichtigen bereits Vererbung und Designthemen.

**Kann ich eine Linie gegen Bearbeitung (Verschieben, Größenänderung) sperren?**

Ja. Formen bieten [Sperrobjekte](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/autoshape/#getAutoShapeLock--) an, mit denen Sie Bearbeitungsoperationen verbieten können.