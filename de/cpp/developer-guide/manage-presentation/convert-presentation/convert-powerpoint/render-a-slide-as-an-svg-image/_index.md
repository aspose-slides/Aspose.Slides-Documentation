---
title: Präsentationsfolien als SVG-Bilder in C++ rendern
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
- PPT nach SVG exportieren
- PPTX nach SVG exportieren
- Folie rendern
- Folie konvertieren
- Folie exportieren
- Vektorbild
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint-Folien mit Aspose.Slides für C++ als SVG-Bilder rendern. Hochwertige Visualisierungen mit einfachen Codebeispielen."
---

## **SVG-Format**

SVG – ein Akronym für Scalable Vector Graphics – ist ein standardisiertes Grafikformat, das zur Darstellung zweidimensionaler Bilder verwendet wird. SVG speichert Bilder als Vektoren in XML mit Details, die ihr Verhalten oder Aussehen definieren.  

SVG ist eines der wenigen Bildformate, das in diesen Bereichen sehr hohe Standards erfüllt: Skalierbarkeit, Interaktivität, Leistung, Barrierefreiheit, Programmierbarkeit und weitere. Aus diesem Grund wird es häufig in der Webentwicklung eingesetzt.  

Sie möchten SVG-Dateien verwenden, wenn Sie

- **Ihre Präsentation in einem *sehr großen Format* drucken.** SVG‑Bilder können auf jede Auflösung oder jedes Niveau skaliert werden. Sie können SVG‑Bilder beliebig oft verkleinern oder vergrößern, ohne die Qualität zu beeinträchtigen.  
- **Diagramme und Grafiken aus Ihren Folien in *verschiedenen Medien oder Plattformen* verwenden.** Die meisten Betrachter können SVG‑Dateien interpretieren.  
- **Die *kleinstmöglichen Bildgrößen* verwenden.** SVG‑Dateien sind im Allgemeinen kleiner als ihre hochauflösenden Gegenstücke in anderen Formaten, insbesondere bei bitmapbasierten Formaten (JPEG oder PNG).  

## **Eine Folie als SVG-Bild rendern**

Aspose.Slides für C++ ermöglicht das Exportieren von Folien aus Ihren Präsentationen als SVG‑Bilder. Folgen Sie diesen Schritten, um SVG‑Bilder zu erzeugen:

1. Erstellen Sie eine Instanz der Klasse Presentation.  
2. Durchlaufen Sie alle Folien in der Präsentation.  
3. Schreiben Sie jede Folie mit einem FileStream in eine eigene SVG‑Datei.  

{{% alert color="primary" %}} 

Vielleicht möchten Sie unsere [kostenlose Webanwendung](https://products.aspose.app/slides/conversion/ppt-to-svg) ausprobieren, in der wir die PPT‑zu‑SVG‑Konvertierungsfunktion von Aspose.Slides für C++ implementiert haben.

{{% /alert %}} 

Dieses Beispielcode in C++ zeigt, wie Sie PPT mit Aspose.Slides in SVG konvertieren:
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

**Warum kann das erzeugte SVG in verschiedenen Browsern unterschiedlich aussehen?**

Die Unterstützung bestimmter SVG‑Funktionen wird von den Browser‑Engines unterschiedlich implementiert. Parameter von [SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) helfen, Inkompatibilitäten auszugleichen.

**Ist es möglich, nicht nur Folien, sondern auch einzelne Formen als SVG zu exportieren?**

Ja. Jede [Form kann als separates SVG gespeichert werden](https://reference.aspose.com/slides/cpp/aspose.slides/shape/writeassvg/), was für Symbole, Piktogramme und die Wiederverwendung von Grafiken praktisch ist.

**Kann man mehrere Folien zu einem einzigen SVG (Strip/Dokument) kombinieren?**

Das übliche Szenario ist Folie → SVG. Das Zusammenführen mehrerer Folien zu einer einzigen SVG‑Leinwand ist ein Nachbearbeitungsschritt, der auf Anwendungsebene durchgeführt wird.