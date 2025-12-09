---
title: Rendern einer Folie als SVG-Bild
type: docs
weight: 50
url: /de/nodejs-java/render-a-slide-as-an-svg-image/
---

## **SVG-Format**

SVG — ein Akronym für Scalable Vector Graphics — ist ein Standardgrafiktyp bzw. -format, das zum Rendern zweidimensionaler Bilder verwendet wird. SVG speichert Bilder als Vektoren in XML mit Details, die ihr Verhalten oder ihr Aussehen definieren.

SVG ist eines der wenigen Bildformate, das in Bezug auf Skalierbarkeit, Interaktivität, Leistung, Barrierefreiheit, Programmierbarkeit und weitere Aspekte sehr hohe Standards erfüllt. Aus diesem Grund wird es häufig in der Webentwicklung eingesetzt.

Sie möchten SVG‑Dateien verwenden, wenn Sie

- **Ihre Präsentation in einem *sehr großen Format* drucken möchten.** SVG‑Bilder können auf jede Auflösung oder Größe skaliert werden. Sie können SVG‑Bilder beliebig oft vergrößern, ohne an Qualität zu verlieren.
- **Diagramme und Grafiken Ihrer Folien in *verschiedenen Medien oder Plattformen* nutzen** wollen. Die meisten Viewer können SVG‑Dateien interpretieren.
- **die *kleinstmöglichen Bildgrößen* verwenden** möchten. SVG‑Dateien sind im Allgemeinen kleiner als ihre hochauflösenden Gegenstücke in anderen Formaten, insbesondere in bitmapbasierten Formaten (JPEG oder PNG).

## **Folien als SVG‑Bilder rendern**

Aspose.Slides für Node.js via Java ermöglicht den Export von Folien Ihrer Präsentationen als SVG‑Bilder. Führen Sie die folgenden Schritte aus, um SVG‑Bilder zu erzeugen:

1. Erstellen Sie eine Instanz der Klasse `Presentation`.
2. Durchlaufen Sie alle Folien der Präsentation.
3. Schreiben Sie jede Folie in eine separate SVG‑Datei über `FileOutputStream`.

{{% alert color="primary" %}} 

Sie können unsere [kostenlose Webanwendung](https://products.aspose.app/slides/conversion/ppt-to-svg) ausprobieren, in der wir die PPT‑zu‑SVG‑Konvertierungsfunktion von Aspose.Slides für Node.js via Java implementiert haben.

{{% /alert %}} 

Dieser Beispielcode in JavaScript zeigt, wie Sie PPT mit Aspose.Slides in SVG konvertieren:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var fileStream = java.newInstanceSync("java.io.FileOutputStream", ("slide-" + index) + ".svg");
        try {
            slide.writeAsSvg(fileStream);
        } finally {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Warum kann das erzeugte SVG in verschiedenen Browsern unterschiedlich aussehen?**

Die Unterstützung bestimmter SVG‑Features wird von den Browser‑Engines unterschiedlich implementiert. Die Parameter von [SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) helfen, Inkompatibilitäten auszugleichen.

**Ist es möglich, nicht nur Folien, sondern auch einzelne Formen als SVG zu exportieren?**

Ja. Jede [Form kann als separates SVG](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/) gespeichert werden, was für Symbole, Piktogramme und die Wiederverwendung von Grafiken praktisch ist.

**Können mehrere Folien zu einem einzigen SVG (Strip/Dokument) kombiniert werden?**

Das Standardszenario ist eine Folie → ein SVG. Das Kombinieren mehrerer Folien zu einer einzigen SVG‑Leinwand ist ein nachgelagerter Verarbeitungsschritt, der auf Anwendungsebene durchgeführt wird.