---
title: Eine Folie als SVG-Bild rendern
type: docs
weight: 50
url: /python-net/render-a-slide-as-an-svg-image/
---

SVG – eine Abkürzung für Scalable Vector Graphics – ist ein Standardgrafiktyp oder -format, der verwendet wird, um zweidimensionale Bilder darzustellen. SVG speichert Bilder als Vektoren in XML mit Details, die ihr Verhalten oder Aussehen definieren.

SVG ist eines der wenigen Formate für Bilder, das in diesen Aspekten sehr hohe Standards erfüllt: Skalierbarkeit, Interaktivität, Leistung, Barrierefreiheit, Programmierbarkeit und andere. Aus diesen Gründen wird es häufig in der Webentwicklung eingesetzt.

Sie möchten möglicherweise SVG-Dateien verwenden, wenn Sie

- **Ihre Präsentation in einem *sehr großen Format* drucken möchten.** SVG-Bilder können bis zu jeder Auflösung oder Ebene skaliert werden. Sie können SVG-Bilder so oft wie nötig in der Größe ändern, ohne die Qualität zu opfern.
- **Diagramme und Grafiken aus Ihren Folien in *verschiedenen Medien oder Plattformen* verwenden möchten.** Die meisten Leser können SVG-Dateien interpretieren.
- **die *kleinstmöglichen Größen von Bildern* verwenden möchten.** SVG-Dateien sind in der Regel kleiner als ihre hochauflösenden Äquivalente in anderen Formaten, insbesondere in Formaten, die auf Bitmap (JPEG oder PNG) basieren.

Aspose.Slides für Python über .NET ermöglicht es Ihnen, Folien in Ihren Präsentationen als SVG-Bilder zu exportieren. Gehen Sie durch diese Schritte, um SVG-Bilder zu generieren:

1. Erstellen Sie eine Instanz der Presentation-Klasse.
2. Iterieren Sie durch alle Folien in der Präsentation.
3. Schreiben Sie jede Folie in ihre eigene SVG-Datei über FileStream.

{{% alert color="primary" %}} 

Sie möchten möglicherweise unsere [kostenlose Webanwendung](https://products.aspose.app/slides/conversion/ppt-to-svg) ausprobieren, in der wir die Funktion zur PPT-zu-SVG-Konvertierung von Aspose.Slides für Python über .NET implementiert haben.

{{% /alert %}} 

Dieser Beispielcode in Python zeigt Ihnen, wie Sie PPT in SVG mit Aspose.Slides konvertieren:

```py
import aspose.slides as slides

# Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt 
pres = slides.Presentation("pres.pptx")

for index in range(pres.slides.length):
    slide = pres.slides[index]

    with open("slide-{index}.svg".format(index = index), "wb") as file:
        slide.write_as_svg(file)
```