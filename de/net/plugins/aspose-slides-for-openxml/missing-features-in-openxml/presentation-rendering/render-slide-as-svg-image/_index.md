---
title: Folie als SVG-Bild rendern
type: docs
weight: 50
url: /de/net/render-slide-as-svg-image/
---
SVG — ein Akronym für Scalable Vector Graphics — ist ein standardisierter Grafiktyp bzw. ein Format, das zur Darstellung zweidimensionaler Bilder verwendet wird. SVG speichert Bilder als Vektoren in XML mit Details, die ihr Verhalten oder ihr Aussehen definieren.

SVG gehört zu den wenigen Bildformaten, die in Bezug auf Skalierbarkeit, Interaktivität, Leistung, Barrierefreiheit, Programmierbarkeit und weitere Kriterien sehr hohen Ansprüchen genügen. Aus diesen Gründen wird es häufig in der Webentwicklung eingesetzt.

Sie möchten SVG‑Dateien in folgenden Szenarien verwenden:

- wenn Sie planen, Ihre Präsentation in einem sehr großen Format zu drucken. SVG‑Bilder können auf jede Auflösung oder jedes Niveau skalieren. Sie können SVG‑Bilder so oft wie nötig skalieren, ohne die Qualität zu beeinträchtigen.
- wenn Sie Diagramme und Grafiken aus Ihren Folien in verschiedenen Medien oder Plattformen verwenden möchten. Die meisten Leser können SVG‑Dateien interpretieren.
- wenn Sie die möglichst kleinsten Bildgrößen benötigen. SVG‑Dateien sind im Allgemeinen kleiner als ihre hochauflösenden Gegenstücke in anderen Formaten, insbesondere in bitmapbasierten Formaten (JPEG oder PNG).

Aspose.Slides für .NET ermöglicht es Ihnen, Folien Ihrer Präsentationen als **SVG**‑Bilder zu exportieren. So erzeugen Sie ein SVG‑Bild aus einer beliebigen Folie:

- Erstellen Sie eine Instanz der Klasse Presentation.
- Durchlaufen Sie alle Folien in der Präsentation.
- Schreiben Sie jede Folie über einen FileStream in eine eigene SVG‑Datei.

{{% alert color="info" %}}
Vielleicht möchten Sie unsere [kostenlose Webanwendung](https://products.aspose.app/slides/de/conversion/ppt-to-svg) ausprobieren, in der wir die PPT‑zu‑SVG‑Konvertierungsfunktion von Aspose.Slides für .NET implementiert haben.
{{% /alert %}}

Dieser Beispielcode in C# zeigt, wie Sie PPT mit Aspose.Slides nach SVG konvertieren:

``` csharp
using Aspose.Slides;

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