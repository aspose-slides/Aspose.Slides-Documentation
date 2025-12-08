---
title: Render Präsentationsfolien als SVG-Bilder in Python
linktitle: Folie zu SVG
type: docs
weight: 50
url: /de/python-net/render-a-slide-as-an-svg-image/
keywords:
- Folie zu SVG
- Präsentation zu SVG
- PowerPoint zu SVG
- OpenDocument zu SVG
- PPT zu SVG
- PPTX zu SVG
- ODP zu SVG
- Folie rendern
- Folie konvertieren
- Folie exportieren
- Vektorbild
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument‑Folien mit Aspose.Slides für Python via .NET als SVG‑Bilder rendern. Hochwertige Visuals mit einfachen Code‑Beispielen."
---

## **Folien in SVG konvertieren**

SVG — eine Abkürzung für Scalable Vector Graphics — ist ein standardisiertes Grafikformat, das zum Rendern zweidimensionaler Bilder verwendet wird. SVG speichert Bilder als Vektoren in XML mit Angaben, die ihr Verhalten oder Aussehen definieren.

SVG ist eines der wenigen Bildformate, das in Bezug auf Skalierbarkeit, Interaktivität, Leistung, Barrierefreiheit, Programmierbarkeit und weitere Aspekte sehr hohen Ansprüchen genügt. Aus diesen Gründen wird es häufig in der Webentwicklung eingesetzt.

Sie sollten SVG‑Dateien verwenden, wenn Sie

- **Ihre Präsentation in einem *sehr großen Format* zu drucken.** SVG‑Bilder können auf jede Auflösung oder jedes Niveau skaliert werden. Sie können SVG‑Bilder beliebig oft in der Größe ändern, ohne an Qualität zu verlieren.
- **Diagramme und Grafiken aus Ihren Folien in *verschiedenen Medien oder Plattformen* zu verwenden.** Die meisten Betrachter können SVG‑Dateien interpretieren.
- **die *kleinstmöglichen Bildgrößen* zu verwenden.** SVG‑Dateien sind im Allgemeinen kleiner als ihre hochauflösenden Gegenstücke in anderen Formaten, insbesondere Formaten, die auf Bitmaps basieren (JPEG oder PNG).

Aspose.Slides for Python via .NET ermöglicht das Exportieren von Folien Ihrer Präsentationen als SVG‑Bilder. Führen Sie die folgenden Schritte aus, um SVG‑Bilder zu erzeugen:

1. Erstellen Sie eine Instanz der Klasse Presentation.  
2. Iterieren Sie über alle Folien in der Präsentation.  
3. Schreiben Sie jede Folie über FileStream in eine eigene SVG‑Datei.

{{% alert color="primary" %}} 
Sie können unsere [kostenlose Webanwendung](https://products.aspose.app/slides/conversion/ppt-to-svg) ausprobieren, in der wir die PPT‑zu‑SVG‑Konvertierungsfunktion von Aspose.Slides for Python via .NET implementiert haben.
{{% /alert %}} 

Dieser Beispielcode in Python zeigt, wie Sie PPT mit Aspose.Slides in SVG konvertieren:
```py
import aspose.slides as slides

# Erstellen Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
pres = slides.Presentation("pres.pptx")

for index in range(pres.slides.length):
    slide = pres.slides[index]

    with open("slide-{index}.svg".format(index = index), "wb") as file:
        slide.write_as_svg(file)
```


## **FAQ**

**Warum kann das resultierende SVG in verschiedenen Browsern unterschiedlich aussehen?**

Die Unterstützung bestimmter SVG‑Funktionen wird von den Browser‑Engines unterschiedlich implementiert. Die Parameter von [SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) helfen, Inkompatibilitäten auszugleichen.

**Ist es möglich, nicht nur Folien, sondern auch einzelne Formen in SVG zu exportieren?**

Ja. Jede [Form kann als separates SVG gespeichert werden](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/), was für Icons, Piktogramme und die Wiederverwendung von Grafiken praktisch ist.

**Können mehrere Folien zu einem einzigen SVG (Strip/Dokument) kombiniert werden?**

Das Standard‑Szenario ist Folie → SVG. Das Kombinieren mehrerer Folien zu einer einzigen SVG‑Leinwand ist ein Nachbearbeitungsschritt, der auf Anwendungsebene durchgeführt wird.