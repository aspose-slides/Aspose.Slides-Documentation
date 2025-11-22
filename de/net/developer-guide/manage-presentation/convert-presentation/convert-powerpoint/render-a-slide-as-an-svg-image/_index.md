---
title: Eine Folie als SVG-Bild rendern in C#
linktitle: Eine Folie als SVG-Bild rendern
type: docs
weight: 50
url: /de/net/render-a-slide-as-an-svg-image/
description: Dieser Artikel erklärt, wie man PowerPoint-Präsentationen mit C# in das SVG-Format konvertiert. Sie können PPT-, PPTX- und ODP-Formate in SVG-Bilder konvertieren.
keywords: C# PowerPoint zu SVG konvertieren, C# PPT zu SVG, C# PPTX zu SVG
---

## **Übersicht**

Dieser Artikel erklärt, wie man **PowerPoint-Präsentationen mit C# in das SVG-Format konvertiert**. Er behandelt die folgenden Themen.

_Format_: **PowerPoint**
- [C# PowerPoint zu SVG](#csharp-powerpoint-to-svg)
- [C# PowerPoint zu SVG konvertieren](#csharp-powerpoint-to-svg)
- [C# Wie man PowerPoint-Dateien zu SVG konvertiert](#csharp-powerpoint-to-svg)

_Format_: **PPT**
- [C# PPT zu SVG](#csharp-ppt-to-svg)
- [C# PPT zu SVG konvertieren](#csharp-ppt-to-svg)
- [C# Wie man PPT-Dateien zu SVG konvertiert](#csharp-ppt-to-svg)

_Format_: **PPTX**
- [C# PPTX zu SVG](#csharp-pptx-to-svg)
- [C# PPTX zu SVG konvertieren](#csharp-pptx-to-svg)
- [C# Wie man PPTX-Dateien zu SVG konvertiert](#csharp-pptx-to-svg)

_Format_: **ODP**
- [C# ODP zu SVG](#csharp-odp-to-svg)
- [C# ODP zu SVG konvertieren](#csharp-odp-to-svg)
- [C# Wie man ODP-Dateien zu SVG konvertiert](#csharp-odp-to-svg)

_Format_: **Slide**
- [C# PowerPoint-Folie zu SVG konvertieren](#render-a-slide-as-an-svg-image)
- [C# PPT-Folie zu SVG konvertieren](#render-a-slide-as-an-svg-image)
- [C# PPTX-Folie zu SVG konvertieren](#render-a-slide-as-an-svg-image)
- [C# ODP-Folie zu SVG konvertieren](#render-a-slide-as-an-svg-image)

Weitere Themen in diesem Artikel.
- [Siehe auch](#see-also)

## **SVG-Format**
SVG – ein Akronym für Scalable Vector Graphics – ist ein standardisiertes Grafikformat, das zur Darstellung zweidimensionaler Bilder verwendet wird. SVG speichert Bilder als Vektoren in XML mit Details, die ihr Verhalten oder ihr Aussehen definieren.

SVG ist eines der wenigen Bildformate, das in Bezug auf Skalierbarkeit, Interaktivität, Leistung, Barrierefreiheit, Programmierbarkeit und weitere Aspekte sehr hohe Standards erfüllt. Aus diesem Grund wird es häufig in der Webentwicklung eingesetzt.

Sie sollten SVG-Dateien verwenden, wenn Sie

- **Ihre Präsentation in einem *sehr großen Format* drucken möchten.** SVG‑Bilder können auf jede Auflösung oder Größe skaliert werden. Sie können SVG‑Bilder beliebig oft vergrößern, ohne an Qualität zu verlieren.
- **Diagramme und Grafiken aus Ihren Folien in *verschiedenen Medien oder Plattformen* nutzen**. Die meisten Viewer können SVG‑Dateien interpretieren.
- **die *kleinstmöglichen Dateigrößen* für Bilder erreichen** wollen. SVG‑Dateien sind im Allgemeinen kleiner als ihre hochauflösenden Gegenstücke in bitmapbasierten Formaten (JPEG oder PNG).

## **Eine Folie als SVG-Bild rendern**

Aspose.Slides für .NET ermöglicht den Export von Folien Ihrer Präsentationen als SVG‑Bilder. Führen Sie die folgenden Schritte aus, um SVG‑Bilder zu erzeugen:

_Schritte: PowerPoint‑zu‑SVG‑Konvertierungen in C#_

Der nachfolgende Beispielcode erklärt diese Konvertierungen mit .NET.
- <a name="csharp-powerpoint-to-svg" id="csharp-powerpoint-to-svg"><strong>Schritte: PowerPoint zu SVG konvertieren in C#</strong></a>
- <a name="csharp-ppt-to-svg" id="csharp-ppt-to-svg"><strong>Schritte: PPT zu SVG konvertieren in C#</strong></a>
- <a name="csharp-pptx-to-svg" id="csharp-pptx-to-svg"><strong>Schritte: PPTX zu SVG konvertieren in C#</strong></a>
- <a name="csharp-odp-to-svg" id="csharp-odp-to-svg"><strong>Schritte: ODP zu SVG konvertieren in C#</strong></a>

_Code‑Schritte:_

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Klasse.  
   * _.ppt_-Erweiterung zum Laden einer **PPT**‑Datei in die _Presentation_-Klasse.  
   * _.pptx_-Erweiterung zum Laden einer **PPTX**‑Datei in die _Presentation_-Klasse.  
   * _.odp_-Erweiterung zum Laden einer **ODP**‑Datei in die _Presentation_-Klasse.  
   * _.pps_-Erweiterung zum Laden einer **PPS**‑Datei in die _Presentation_-Klasse.
2. Durchlaufen Sie alle Folien der Präsentation.
3. Schreiben Sie jede Folie in eine eigene SVG‑Datei über einen FileStream.

{{% alert color="primary" %}} 

Sie können unsere [kostenlose Web‑Anwendung](https://products.aspose.app/slides/conversion/ppt-to-svg) ausprobieren, in der wir die PPT‑zu‑SVG‑Konvertierungsfunktion von Aspose.Slides für .NET implementiert haben.

{{% /alert %}} 

Dieser C#‑Beispielcode zeigt, wie Sie PowerPoint mit Aspose.Slides in SVG konvertieren: 
``` csharp
// Presentation-Objekt kann PowerPoint-Formate wie PPT, PPTX, ODP usw. laden.
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


## **FAQ**

**Warum kann das resultierende SVG in verschiedenen Browsern unterschiedlich aussehen?**

Die Unterstützung einzelner SVG‑Features wird von den Browser‑Engines unterschiedlich implementiert. Parameter der [SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) helfen, Inkompatibilitäten auszugleichen.

**Ist es möglich, nicht nur Folien, sondern auch einzelne Formen als SVG zu exportieren?**

Ja. Jede [Form kann als separates SVG gespeichert werden](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/), was für Icons, Piktogramme und die Wiederverwendung von Grafiken praktisch ist.

**Können mehrere Folien zu einem einzigen SVG (Strip/Dokument) kombiniert werden?**

Das Standard‑Szenario ist: eine Folie → ein SVG. Das Kombinieren mehrerer Folien zu einer einzigen SVG‑Leinwand erfolgt als Nachbearbeitung auf Anwendungsebene.

## **Siehe auch** 

Dieser Artikel behandelt zudem die folgenden Themen. Die Codes sind identisch mit den oben genannten.

_Format_: **PowerPoint**
- [C# PowerPoint zu SVG Code](#csharp-powerpoint-to-svg)
- [C# PowerPoint zu SVG API](#csharp-powerpoint-to-svg)
- [C# PowerPoint zu SVG programmgesteuert](#csharp-powerpoint-to-svg)
- [C# PowerPoint zu SVG Bibliothek](#csharp-powerpoint-to-svg)
- [C# PowerPoint als SVG speichern](#csharp-powerpoint-to-svg)
- [C# SVG aus PowerPoint generieren](#csharp-powerpoint-to-svg)
- [C# SVG aus PowerPoint erstellen](#csharp-powerpoint-to-svg)
- [C# PowerPoint zu SVG Konverter](#csharp-powerpoint-to-svg)

_Format_: **PPT**
- [C# PPT zu SVG Code](#csharp-ppt-to-svg)
- [C# PPT zu SVG API](#csharp-ppt-to-svg)
- [C# PPT zu SVG programmgesteuert](#csharp-ppt-to-svg)
- [C# PPT zu SVG Bibliothek](#csharp-ppt-to-svg)
- [C# PPT als SVG speichern](#csharp-ppt-to-svg)
- [C# SVG aus PPT generieren](#csharp-ppt-to-svg)
- [C# SVG aus PPT erstellen](#csharp-ppt-to-svg)
- [C# PPT zu SVG Konverter](#csharp-ppt-to-svg)

_Format_: **PPTX**
- [C# PPTX zu SVG Code](#csharp-pptx-to-svg)
- [C# PPTX zu SVG API](#csharp-pptx-to-svg)
- [C# PPTX zu SVG programmgesteuert](#csharp-pptx-to-svg)
- [C# PPTX zu SVG Bibliothek](#csharp-pptx-to-svg)
- [C# PPTX als SVG speichern](#csharp-pptx-to-svg)
- [C# SVG aus PPTX generieren](#csharp-pptx-to-svg)
- [C# SVG aus PPTX erstellen](#csharp-pptx-to-svg)
- [C# PPTX zu SVG Konverter](#csharp-pptx-to-svg)

_Format_: **ODP**
- [C# ODP zu SVG Code](#csharp-odp-to-svg)
- [C# ODP zu SVG API](#csharp-odp-to-svg)
- [C# ODP zu SVG programmgesteuert](#csharp-odp-to-svg)
- [C# ODP zu SVG Bibliothek](#csharp-odp-to-svg)
- [C# ODP als SVG speichern](#csharp-odp-to-svg)
- [C# SVG aus ODP generieren](#csharp-odp-to-svg)
- [C# SVG aus ODP erstellen](#csharp-odp-to-svg)
- [C# ODP zu SVG Konverter](#csharp-odp-to-svg)