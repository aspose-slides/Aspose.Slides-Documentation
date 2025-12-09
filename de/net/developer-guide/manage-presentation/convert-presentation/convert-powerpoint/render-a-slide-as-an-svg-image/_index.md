---
title: Rendern von Präsentationsfolien als SVG-Bilder in .NET
linktitle: Folie zu SVG
type: docs
weight: 50
url: /de/net/render-a-slide-as-an-svg-image/
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
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint-Folien mit Aspose.Slides für .NET als SVG-Bilder rendern. Hochwertige Visualisierungen mit einfachen C#-Codebeispielen."
---

## **Übersicht**

Dieser Artikel erklärt, wie man **PowerPoint‑Präsentationen in das SVG‑Format mit C# konvertiert**. Er behandelt die folgenden Themen.

_Format_: **PowerPoint**
- [C# PowerPoint zu SVG](#csharp-powerpoint-to-svg)
- [C# PowerPoint zu SVG](#csharp-powerpoint-to-svg)
- [C# PowerPoint zu SVG](#csharp-powerpoint-to-svg)

_Format_: **PPT**
- [C# PPT zu SVG](#csharp-ppt-to-svg)
- [C# PPT zu SVG](#csharp-ppt-to-svg)
- [C# PPT zu SVG](#csharp-ppt-to-svg)

_Format_: **PPTX**
- [C# PPTX zu SVG](#csharp-pptx-to-svg)
- [C# PPTX zu SVG](#csharp-pptx-to-svg)
- [C# PPTX zu SVG](#csharp-pptx-to-svg)

_Format_: **ODP**
- [C# ODP zu SVG](#csharp-odp-to-svg)
- [C# ODP zu SVG](#csharp-odp-to-svg)
- [C# ODP zu SVG](#csharp-odp-to-svg)

_Format_: **Slide**
- [C# PowerPoint Folie zu SVG konvertieren](#render-a-slide-as-an-svg-image)
- [C# PPT Folie zu SVG konvertieren](#render-a-slide-as-an-svg-image)
- [C# PPTX Folie zu SVG konvertieren](#render-a-slide-as-an-svg-image)
- [C# ODP Folie zu SVG konvertieren](#render-a-slide-as-an-svg-image)

Weitere Themen, die in diesem Artikel behandelt werden.
- [Siehe auch](#see-also)

## **SVG-Format**
SVG—eine Abkürzung für Scalable Vector Graphics—ist ein standardisiertes Grafikformat, das zur Darstellung zweidimensionaler Bilder verwendet wird. SVG speichert Bilder als Vektoren in XML mit Details, die ihr Verhalten oder Aussehen definieren.

SVG ist eines der wenigen Bildformate, das in Bezug auf Skalierbarkeit, Interaktivität, Performance, Barrierefreiheit, Programmierbarkeit und weitere sehr hohe Standards erfüllt. Aus diesen Gründen wird es häufig in der Webentwicklung eingesetzt.

Sie möchten SVG‑Dateien verwenden, wenn Sie

- **Ihre Präsentation in einem *sehr großen Format* ausdrucken.** SVG‑Bilder können auf jede Auflösung oder jedes Niveau skaliert werden. Sie können SVG‑Bilder beliebig oft in der Größe ändern, ohne die Qualität zu beeinträchtigen.
- **Diagramme und Grafiken aus Ihren Folien in *verschiedenen Medien oder Plattformen* verwenden.** Die meisten Viewer können SVG‑Dateien interpretieren.
- **die *kleinsten möglichen Bildgrößen* verwenden.** SVG‑Dateien sind im Allgemeinen kleiner als ihre hochauflösenden Gegenstücke in anderen Formaten, insbesondere in bitmapbasierten Formaten (JPEG oder PNG).

## **Eine Folie als SVG‑Bild rendern**

Aspose.Slides für .NET ermöglicht das Exportieren von Folien Ihrer Präsentationen als SVG‑Bilder. Gehen Sie die folgenden Schritte durch, um SVG‑Bilder zu erzeugen:

*Schritte: PowerPoint‑zu‑SVG‑Konvertierungen in C#*

Der folgende Beispielcode erklärt diese Konvertierungen mit .NET.
- <a name="csharp-powerpoint-to-svg" id="csharp-powerpoint-to-svg"><strong>Schritte: PowerPoint nach SVG in C# konvertieren</strong></a>
- <a name="csharp-ppt-to-svg" id="csharp-ppt-to-svg"><strong>Schritte: PPT nach SVG in C# konvertieren</strong></a>
- <a name="csharp-pptx-to-svg" id="csharp-pptx-to-svg"><strong>Schritte: PPTX nach SVG in C# konvertieren</strong></a>
- <a name="csharp-odp-to-svg" id="csharp-odp-to-svg"><strong>Schritte: ODP nach SVG in C# konvertieren</strong></a>

*Code‑Schritte:*

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Klasse.
   * _.ppt_ Erweiterung zum Laden einer **PPT**‑Datei in die _Presentation_-Klasse.
   * _.pptx_ Erweiterung zum Laden einer **PPTX**‑Datei in die _Presentation_-Klasse.
   * _.odp_ Erweiterung zum Laden einer **ODP**‑Datei in die _Presentation_-Klasse.
   * _.pps_ Erweiterung zum Laden einer **PPS**‑Datei in die _Presentation_-Klasse.
2. Iterieren Sie über alle Folien in der Präsentation.
3. Schreiben Sie jede Folie in eine eigene SVG‑Datei über einen FileStream.

{{% alert color="primary" %}} 
Sie können unsere [kostenlose Webanwendung](https://products.aspose.app/slides/conversion/ppt-to-svg) ausprobieren, in der wir die PPT‑zu‑SVG‑Konvertierungsfunktion von Aspose.Slides für .NET implementiert haben.
{{% /alert %}} 

Dieser Beispielcode in C# zeigt, wie Sie PowerPoint mit Aspose.Slides nach SVG konvertieren: 
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

Die Unterstützung bestimmter SVG‑Funktionen wird von Browser‑Engines unterschiedlich implementiert. [SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/)-Parameter helfen, Inkompatibilitäten auszugleichen.

**Ist es möglich, nicht nur Folien, sondern auch einzelne Formen als SVG zu exportieren?**

Ja. Jede [Form kann als separates SVG gespeichert werden](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/), was praktisch für Symbole, Piktogramme und die Wiederverwendung von Grafiken ist.

**Können mehrere Folien zu einem einzigen SVG (Strip/Dokument) kombiniert werden?**

Das Standard‑Szenario ist eine Folie → ein SVG. Das Kombinieren mehrerer Folien zu einem einzigen SVG‑Canvas ist ein Nachbearbeitungsschritt, der auf Anwendungsebene durchgeführt wird.

## **Siehe auch** 

Dieser Artikel behandelt auch diese Themen. Der Code ist derselbe wie oben.

_Format_: **PowerPoint**
- [C# PowerPoint zu SVG Code](#csharp-powerpoint-to-svg)
- [C# PowerPoint zu SVG API](#csharp-powerpoint-to-svg)
- [C# PowerPoint zu SVG programmgesteuert](#csharp-powerpoint-to-svg)
- [C# PowerPoint zu SVG Bibliothek](#csharp-powerpoint-to-svg)
- [C# PowerPoint als SVG speichern](#csharp-powerpoint-to-svg)
- [C# SVG aus PowerPoint erzeugen](#csharp-powerpoint-to-svg)
- [C# SVG aus PowerPoint erstellen](#csharp-powerpoint-to-svg)
- [C# PowerPoint zu SVG Konverter](#csharp-powerpoint-to-svg)

_Format_: **PPT**
- [C# PPT zu SVG Code](#csharp-ppt-to-svg)
- [C# PPT zu SVG API](#csharp-ppt-to-svg)
- [C# PPT zu SVG programmgesteuert](#csharp-ppt-to-svg)
- [C# PPT zu SVG Bibliothek](#csharp-ppt-to-svg)
- [C# PPT als SVG speichern](#csharp-ppt-to-svg)
- [C# SVG aus PPT erzeugen](#csharp-ppt-to-svg)
- [C# SVG aus PPT erstellen](#csharp-ppt-to-svg)
- [C# PPT zu SVG Konverter](#csharp-ppt-to-svg)

_Format_: **PPTX**
- [C# PPTX zu SVG Code](#csharp-pptx-to-svg)
- [C# PPTX zu SVG API](#csharp-pptx-to-svg)
- [C# PPTX zu SVG programmgesteuert](#csharp-pptx-to-svg)
- [C# PPTX zu SVG Bibliothek](#csharp-pptx-to-svg)
- [C# PPTX als SVG speichern](#csharp-pptx-to-svg)
- [C# SVG aus PPTX erzeugen](#csharp-pptx-to-svg)
- [C# SVG aus PPTX erstellen](#csharp-pptx-to-svg)
- [C# PPTX zu SVG Konverter](#csharp-pptx-to-svg)

_Format_: **ODP**
- [C# ODP zu SVG Code](#csharp-odp-to-svg)
- [C# ODP zu SVG API](#csharp-odp-to-svg)
- [C# ODP zu SVG programmgesteuert](#csharp-odp-to-svg)
- [C# ODP zu SVG Bibliothek](#csharp-odp-to-svg)
- [C# ODP als SVG speichern](#csharp-odp-to-svg)
- [C# SVG aus ODP erzeugen](#csharp-odp-to-svg)
- [C# SVG aus ODP erstellen](#csharp-odp-to-svg)
- [C# ODP zu SVG Konverter](#csharp-odp-to-svg)