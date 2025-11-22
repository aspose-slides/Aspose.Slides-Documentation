---
title: Linie
type: docs
weight: 50
url: /de/nodejs-java/Line/
---

{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java unterstützt das Hinzufügen verschiedener Arten von Formen zu den Folien. In diesem Thema werden wir mit Formen arbeiten, indem wir Linien zu den Folien hinzufügen. Mit Aspose.Slides for Node.js via Java können Entwickler nicht nur einfache Linien erstellen, sondern auch einige ausgefallene Linien auf den Folien zeichnen.

{{% /alert %}} 

## **Einfachere Linie erstellen**

Um eine einfache Linie zu einer ausgewählten Folie der Präsentation hinzuzufügen, führen Sie bitte die folgenden Schritte aus:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Holen Sie die Referenz einer Folie über ihren Index.
- Fügen Sie eine AutoShape vom Typ Line mithilfe der Methode [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) hinzu, die vom Objekt [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) bereitgestellt wird.
- Speichern Sie die modifizierte Präsentation als PPTX-Datei.

Im nachfolgenden Beispiel haben wir eine Linie zur ersten Folie der Präsentation hinzugefügt.
```javascript
// Instanziieren Sie die PresentationEx-Klasse, die die PPTX-Datei darstellt
var pres = new aspose.slides.Presentation();
try {
    // Holen Sie die erste Folie
    var sld = pres.getSlides().get_Item(0);
    // Fügen Sie eine AutoShape des Typs Linie hinzu
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // Schreiben Sie die PPTX-Datei auf die Festplatte
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Pfeilförmige Linie erstellen**

Aspose.Slides for Node.js via Java ermöglicht es Entwicklern zudem, einige Eigenschaften der Linie zu konfigurieren, um ihr Aussehen zu verbessern. Versuchen wir, einige Eigenschaften so zu konfigurieren, dass die Linie wie ein Pfeil aussieht. Gehen Sie dazu wie folgt vor:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Holen Sie die Referenz einer Folie über ihren Index.
- Fügen Sie eine AutoShape vom Typ Line mithilfe der Methode [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) hinzu, die vom Objekt [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) bereitgestellt wird.
- Setzen Sie den [Line Style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineStyle) auf einen der von Aspose.Slides for Node.js via Java angebotenen Stile.
- Setzen Sie die Breite der Linie.
- Setzen Sie den [Dash Style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineDashStyle) der Linie auf einen der von Aspose.Slides for Node.js via Java angebotenen Stile.
- Setzen Sie den [Arrow Head Style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineArrowheadStyle) und die [Length](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineArrowheadLength) des Startpunkts der Linie.
- Setzen Sie den [Arrow Head Style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineArrowheadStyle) und die [Length](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineArrowheadLength) des Endpunkts der Linie.
- Speichern Sie die modifizierte Präsentation als PPTX-Datei.
```javascript
// Instanziieren Sie die PresentationEx-Klasse, die die PPTX-Datei darstellt
var pres = new aspose.slides.Presentation();
try {
    // Holen Sie die erste Folie
    var sld = pres.getSlides().get_Item(0);
    // Fügen Sie eine AutoShape des Typs Linie hinzu
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // Wenden Sie einige Formatierungen auf die Linie an
    shp.getLineFormat().setStyle(aspose.slides.LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);
    shp.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    shp.getLineFormat().setBeginArrowheadLength(aspose.slides.LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(aspose.slides.LineArrowheadStyle.Oval);
    shp.getLineFormat().setEndArrowheadLength(aspose.slides.LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.Maroon));
    // Schreiben Sie die PPTX-Datei auf die Festplatte
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Kann ich eine normale Linie in einen Connector umwandeln, damit sie an Formen „einrastet“?**

Nein. Eine normale Linie (eine [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) vom Typ [Line](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapetype/)) wird nicht automatisch zu einem Connector. Um sie an Formen einrasten zu lassen, verwenden Sie den dedizierten [Connector](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connector/)‑Typ und die zugehörigen APIs (/slides/de/nodejs-java/connector/) für Verbindungen.

**Was soll ich tun, wenn die Eigenschaften einer Linie vom Theme geerbt werden und es schwierig ist, die endgültigen Werte zu bestimmen?**

Lesen Sie die effektiven Eigenschaften über die Klassen `ILineFormatEffectiveData`/`ILineFillFormatEffectiveData` – diese berücksichtigen bereits Vererbung und Theme‑Stile.

**Kann ich eine Linie gegen Bearbeitung (Verschieben, Skalieren) sperren?**

Ja. Formen bieten [lock objects](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/getautoshapelock/), mit denen Sie [disallow editing operations](/slides/de/nodejs-java/applying-protection-to-presentation/) deaktivieren können.