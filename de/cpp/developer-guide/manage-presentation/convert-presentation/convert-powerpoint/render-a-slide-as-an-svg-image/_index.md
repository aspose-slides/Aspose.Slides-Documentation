---
title: Präsentationsfolien als SVG-Bilder rendern in C++
linktitle: Folie zu SVG
type: docs
weight: 50
url: /de/cpp/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint zu SVG
- Präsentation zu SVG
- Folie zu SVG
- PPT zu SVG
- PPTX zu SVG
- PPT als SVG speichern
- PPTX als SVG speichern
- PPT zu SVG exportieren
- PPTX zu SVG exportieren
- Folie rendern
- Folie konvertieren
- Folie exportieren
- Vektorbild
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint‑Folien mit Aspose.Slides für C++ als SVG‑Bilder rendern. Hochwertige Visualisierungen mit einfachen Code‑Beispielen."
---

## **SVG-Format**

SVG—ein Akronym für Scalable Vector Graphics—ist ein Standardgrafiktyp oder -format, das zum Rendern zweidimensionaler Bilder verwendet wird. SVG speichert Bilder als Vektoren in XML mit Details, die ihr Verhalten oder Aussehen definieren.

SVG ist eines der wenigen Bildformate, das sehr hohen Ansprüchen in diesen Bereichen genügt: Skalierbarkeit, Interaktivität, Leistung, Barrierefreiheit, Programmierbarkeit und andere. Aus diesen Gründen wird es häufig in der Webentwicklung eingesetzt.

Sie möchten SVG‑Dateien verwenden, wenn Sie

- **Ihre Präsentation in einem *sehr großen Format* drucken**. SVG‑Bilder können auf jede Auflösung oder jedes Niveau skaliert werden. Sie können SVG‑Bilder so oft wie nötig in der Größe ändern, ohne die Qualität zu beeinträchtigen.
- **Diagramme und Grafiken aus Ihren Folien in *verschiedenen Medien oder Plattformen* verwenden**. Die meisten Betrachter können SVG‑Dateien interpretieren.
- **die *kleinsten möglichen Bildgrößen* nutzen**. SVG‑Dateien sind in der Regel kleiner als ihre hochauflösenden Gegenstücke in anderen Formaten, insbesondere bei bitmapbasierten Formaten (JPEG oder PNG).

## **Eine Folie als SVG‑Bild rendern**

Aspose.Slides for C++ ermöglicht das Exportieren von Folien Ihrer Präsentationen als SVG‑Bilder. Folgen Sie diesen Schritten, um SVG‑Bilder zu erzeugen:

1. Erstellen Sie eine Instanz der Klasse Presentation.  
2. Iterieren Sie über alle Folien in der Präsentation.  
3. Schreiben Sie jede Folie über einen FileStream in eine eigene SVG‑Datei.

{{% alert color="primary" %}} 

Sie können unsere [kostenlose Webanwendung](https://products.aspose.app/slides/conversion/ppt-to-svg) ausprobieren, in der wir die PPT‑zu‑SVG‑Konvertierungsfunktion von Aspose.Slides für C++ implementiert haben.

{{% /alert %}} 

Dieser C++‑Beispielcode zeigt, wie Sie PPT mithilfe von Aspose.Slides in SVG konvertieren:
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


## **FAQ**

**Warum kann das resultierende SVG in verschiedenen Browsern unterschiedlich aussehen?**

Die Unterstützung bestimmter SVG‑Funktionen wird von Browser‑Engines unterschiedlich implementiert. [SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/)-Parameter helfen, Inkompatibilitäten auszugleichen.

**Ist es möglich, nicht nur Folien, sondern auch einzelne Formen als SVG zu exportieren?**

Ja. Jede [Form kann als separates SVG gespeichert werden](https://reference.aspose.com/slides/cpp/aspose.slides/shape/writeassvg/), was für Symbole, Piktogramme und die Wiederverwendung von Grafiken praktisch ist.

**Können mehrere Folien zu einem einzigen SVG (Strip/Dokument) kombiniert werden?**

Das Standard‑Szenario ist Folie → SVG. Das Kombinieren mehrerer Folien zu einer einzigen SVG‑Leinwand ist ein Nachbearbeitungsschritt, der auf Anwendungsebene durchgeführt wird.