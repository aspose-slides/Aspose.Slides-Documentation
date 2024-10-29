---
title: Rendern Sie eine Folie als SVG-Bild
type: docs
weight: 50
url: /de/java/render-a-slide-as-an-svg-image/
---

SVG—eine Abkürzung für Scalable Vector Graphics—ist ein standardisiertes Grafikformat, das zur Darstellung von zwei-dimensionalen Bildern verwendet wird. SVG speichert Bilder als Vektoren in XML mit Details, die ihr Verhalten oder Aussehen definieren.

SVG ist eines der wenigen Bildformate, das in diesen Belangen sehr hohen Standards entspricht: Skalierbarkeit, Interaktivität, Leistung, Zugänglichkeit, Programmierbarkeit und andere. Aus diesen Gründen wird es häufig in der Webentwicklung verwendet.

Sie möchten möglicherweise SVG-Dateien verwenden, wenn Sie

- **Ihre Präsentation in einem *sehr großen Format* drucken müssen.** SVG-Bilder können auf jede Auflösung oder Ebene skaliert werden. Sie können SVG-Bilder so oft wie nötig skalieren, ohne die Qualität zu beeinträchtigen.
- **Diagramme und Grafiken aus Ihren Folien in *verschiedenen Medien oder Plattformen* verwenden möchten.** Die meisten Leser können SVG-Dateien interpretieren.
- **Die *kleinsten möglichen Bildgrößen* verwenden möchten.** SVG-Dateien sind im Allgemeinen kleiner als ihre hochauflösenden Äquivalente in anderen Formaten, insbesondere in bitmap-basierten Formaten (JPEG oder PNG).

Aspose.Slides für Java ermöglicht es Ihnen, Folien in Ihren Präsentationen als SVG-Bilder zu exportieren. Gehen Sie diese Schritte durch, um SVG-Bilder zu generieren:

1. Erstellen Sie eine Instanz der Präsentationsklasse.
2. Durchlaufen Sie alle Folien in der Präsentation.
3. Schreiben Sie jede Folie in ihre eigene SVG-Datei über FileOutputStream.

{{% alert color="primary" %}} 

Sie möchten vielleicht unsere [kostenlose Webanwendung](https://products.aspose.app/slides/conversion/ppt-to-svg) ausprobieren, in der wir die PPT-zu-SVG-Konvertierungsfunktion von Aspose.Slides für Java implementiert haben.

{{% /alert %}} 

Dieser Beispielcode in Java zeigt Ihnen, wie Sie PPT in SVG umwandeln können, indem Sie Aspose.Slides verwenden:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);

        FileOutputStream fileStream = new FileOutputStream("slide-" + index + ".svg");
        try {
            slide.writeAsSvg(fileStream);
        } finally {
            fileStream.close();
        }
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```