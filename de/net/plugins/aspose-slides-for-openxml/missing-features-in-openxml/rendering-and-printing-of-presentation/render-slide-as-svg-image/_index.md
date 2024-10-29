---
title: Folie als SVG-Bild rendern
type: docs
weight: 50
url: /de/net/render-slide-as-svg-image/
---

SVG—eine Abkürzung für Scalable Vector Graphics—ist ein standardisiertes Grafikformat, das zur Darstellung zweidimensionaler Bilder verwendet wird. SVG speichert Bilder als Vektoren in XML mit Details, die ihr Verhalten oder Erscheinungsbild definieren.

SVG ist eines der wenigen Formate für Bilder, das sehr hohe Standards in diesen Bereichen erfüllt: Skalierbarkeit, Interaktivität, Leistung, Barrierefreiheit, Programmierbarkeit und andere. Aus diesen Gründen wird es häufig in der Webentwicklung eingesetzt.

Sie möchten möglicherweise SVG-Dateien in diesen Szenarien verwenden:

- wenn Sie planen, Ihre Präsentation in einem sehr großen Format zu drucken. SVG-Bilder können auf jede Auflösung oder Stufe skaliert werden. Sie können SVG-Bilder so oft wie nötig in der Größe ändern, ohne Qualität zu opfern.
- wenn Sie beabsichtigen, Diagramme und Grafiken von Ihren Folien in verschiedenen Medien oder Plattformen zu verwenden. Die meisten Reader können SVG-Dateien interpretieren.
- wenn Sie die kleinsten möglichen Dateigrößen von Bildern verwenden müssen. SVG-Dateien sind im Allgemeinen kleiner als ihre hochauflösenden Äquivalente in anderen Formaten, insbesondere in bitmap-basierten Formaten (JPEG oder PNG).

Aspose.Slides für .NET ermöglicht es Ihnen, Folien in Ihren Präsentationen als **SVG**-Bilder zu exportieren. Um ein SVG-Bild aus einer Folie zu generieren, tun Sie Folgendes:

- Erstellen Sie eine Instanz der Presentation-Klasse.
- Iterieren Sie durch alle Folien in der Präsentation.
- Schreiben Sie jede Folie in ihre eigene SVG-Datei über FileStream.

{{% alert color="primary" %}} 

Sie möchten vielleicht unsere [kostenlose Webanwendung](https://products.aspose.app/slides/conversion/ppt-to-svg) ausprobieren, in der wir die PPT zu SVG-Konvertierungsfunktion von Aspose.Slides für .NET implementiert haben.

{{% /alert %}} 

Dieser Beispielcode in C# zeigt Ihnen, wie Sie PPT in SVG mit Aspose.Slides konvertieren:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (FileStream fileStream = new FileStream($"slide-{index}.svg", FileMode.Create, FileAccess.Write))
        {
            slide.WriteAsSvg(fileStream);   
        }
    }
}
```