---
title: Rendere eine Folie als SVG-Bild
type: docs
weight: 50
url: /de/cpp/render-a-slide-as-an-svg-image/
---

SVG—ein Akronym für skalierbare Vektorgrafiken—ist ein Standardgrafiktyp oder -format, das verwendet wird, um zweidimensionale Bilder darzustellen. SVG speichert Bilder als Vektoren in XML mit Details, die ihr Verhalten oder Aussehen definieren.

SVG ist eines der wenigen Formate für Bilder, das sehr hohe Standards in Bezug auf Skalierbarkeit, Interaktivität, Leistung, Zugänglichkeit, Programmierbarkeit und andere erfüllt. Aus diesen Gründen wird es häufig in der Webentwicklung verwendet.

Möglicherweise möchten Sie SVG-Dateien verwenden, wenn Sie

- **Ihre Präsentation in einem *sehr großen Format* drucken möchten.** SVG-Bilder können auf jede Auflösung oder Stufe skaliert werden. Sie können SVG-Bilder so oft wie nötig in der Größe ändern, ohne die Qualität zu beeinträchtigen.
- **Diagramme und Grafiken aus Ihren Folien in *verschiedenen Medien oder Plattformen* verwenden möchten.** Die meisten Leser können SVG-Dateien interpretieren.
- **die *möglichst kleinsten Bildgrößen* verwenden möchten.** SVG-Dateien sind generell kleiner als ihre hochauflösenden Pendants in anderen Formaten, insbesondere in bitmap-basierten Formaten (JPEG oder PNG).

Aspose.Slides für C++ ermöglicht es Ihnen, Folien in Ihren Präsentationen als SVG-Bilder zu exportieren. Gehen Sie durch diese Schritte, um SVG-Bilder zu generieren:

1. Erstellen Sie eine Instanz der Präsentationsklasse.
2. Iterieren Sie über alle Folien in der Präsentation.
3. Schreiben Sie jede Folie in ihre eigene SVG-Datei über FileStream.

{{% alert color="primary" %}} 

Sie möchten vielleicht unsere [kostenlose Webanwendung](https://products.aspose.app/slides/conversion/ppt-to-svg) ausprobieren, in der wir die PPT zu SVG-Umwandlungsfunktion von Aspose.Slides für C++ implementiert haben.

{{% /alert %}} 

Dieser Beispielcode in C++ zeigt Ihnen, wie Sie PPT in SVG mit Aspose.Slides konvertieren:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
        
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto fileName = String::Format(u"slide-{0}.svg", index);
    auto fileStream = System::MakeObject<FileStream>(fileName, FileMode::Create, FileAccess::Write);

    auto slide = pres->get_Slides()->idx_get(index);
    slide->WriteAsSvg(fileStream);
}
```