---
title: "Präsentationsfolien als SVG-Bilder in Python rendern"
linktitle: "Folie zu SVG"
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
description: "Erfahren Sie, wie Sie PowerPoint‑ und OpenDocument‑Folien mit Aspose.Slides für Python via .NET als SVG‑Bilder rendern. Hochwertige Grafiken mit einfachen Codebeispielen."
---

## **Folien in SVG konvertieren**

SVG — ein Akronym für Scalable Vector Graphics — ist ein Standardgrafikformat zur Darstellung zweidimensionaler Bilder. SVG speichert Bilder als Vektoren in XML mit Details, die ihr Verhalten oder ihr Aussehen definieren.

SVG ist eines der wenigen Bildformate, das in Bezug auf Skalierbarkeit, Interaktivität, Performance, Barrierefreiheit, Programmierbarkeit und weitere Kriterien sehr hohe Standards erfüllt. Aus diesem Grund wird es häufig in der Webentwicklung eingesetzt.

Sie möchten SVG‑Dateien verwenden, wenn Sie

- **Ihre Präsentation in einem *sehr großen Format* drucken** wollen. SVG‑Bilder können auf jede Auflösung oder Größe skaliert werden. Sie können SVG‑Bilder beliebig oft vergrößern, ohne an Qualität zu verlieren.  
- **Diagramme und Grafiken aus Ihren Folien in *verschiedenen Medien oder Plattformen* nutzen** wollen. Die meisten Programme können SVG‑Dateien darstellen.  
- **die *kleinstmöglichen Bildgrößen* verwenden** möchten. SVG‑Dateien sind in der Regel kleiner als ihre hochauflösenden Gegenstücke in anderen Formaten, insbesondere von bitmap‑basierten Formaten (JPEG oder PNG).

Aspose.Slides für Python via .NET ermöglicht den Export von Folien Ihrer Präsentationen als SVG‑Bilder. Gehen Sie dabei folgendermaßen vor:

1. Erstellen Sie eine Instanz der Klasse **Presentation**.  
2. Durchlaufen Sie alle Folien der Präsentation.  
3. Schreiben Sie jede Folie in eine eigene SVG‑Datei über einen **FileStream**.

{{% alert color="primary" %}}  
Sie können unsere [kostenlose Webanwendung](https://products.aspose.app/slides/conversion/ppt-to-svg) ausprobieren, in der wir die PPT‑zu‑SVG‑Konvertierungsfunktion von Aspose.Slides für Python via .NET implementiert haben.  
{{% /alert %}}  

Dieses Beispiel in Python zeigt, wie Sie PPT mit Aspose.Slides in SVG konvertieren:

```py
import aspose.slides as slides

# Instanziieren Sie ein Presentation‑Objekt, das eine Präsentationsdatei repräsentiert
pres = slides.Presentation("pres.pptx")

for index in range(pres.slides.length):
    slide = pres.slides[index]

    with open("slide-{index}.svg".format(index = index), "wb") as file:
        slide.write_as_svg(file)
```

## **FAQ**

**Warum kann das resultierende SVG in verschiedenen Browsern unterschiedlich aussehen?**

Die Unterstützung bestimmter SVG‑Funktionen wird von den einzelnen Browser‑Engines unterschiedlich umgesetzt. Die Parameter von [SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) helfen, Inkompatibilitäten auszugleichen.

**Ist es möglich, nicht nur Folien, sondern auch einzelne Shapes als SVG zu exportieren?**

Ja. Jedes [Shape kann als separates SVG gespeichert werden](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/), was für Icons, Piktogramme und die Wiederverwendung von Grafiken praktisch ist.

**Kann man mehrere Folien zu einem einzigen SVG (Strip/Dokument) kombinieren?**

Das Standard‑Szenario ist eine Folie → ein SVG. Das Kombinieren mehrerer Folien zu einer einzigen SVG‑Leinwand ist ein Nachbearbeitungsschritt, der auf Anwendungsebene durchgeführt wird.