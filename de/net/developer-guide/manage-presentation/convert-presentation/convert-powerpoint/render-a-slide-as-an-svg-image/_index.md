---
title: Ein Slide als SVG-Bild in C# rendern
linktitle: Ein Slide als SVG-Bild rendern
type: docs
weight: 50
url: /de/net/render-a-slide-as-an-svg-image/
description: Dieser Artikel erklärt, wie man eine PowerPoint-Präsentation in das SVG-Format mithilfe von C# konvertiert. Sie können PPT-, PPTX- und ODP-Formate in SVG-Bilder umwandeln.
keywords: C# PowerPoint in SVG konvertieren, C# PPT in SVG, C# PPTX in SVG
---

## Übersicht

Dieser Artikel erklärt, wie man eine **PowerPoint-Präsentation in das SVG-Format mithilfe von C# konvertiert**. Er behandelt die folgenden Themen.

_Format_: **PowerPoint**
- [C# PowerPoint zu SVG](#csharp-powerpoint-to-svg)
- [C# PowerPoint in SVG konvertieren](#csharp-powerpoint-to-svg)
- [C# Wie konvertiere ich eine PowerPoint-Datei in SVG](#csharp-powerpoint-to-svg)

_Format_: **PPT**
- [C# PPT zu SVG](#csharp-ppt-to-svg)
- [C# PPT in SVG konvertieren](#csharp-ppt-to-svg)
- [C# Wie konvertiere ich eine PPT-Datei in SVG](#csharp-ppt-to-svg)

_Format_: **PPTX**
- [C# PPTX zu SVG](#csharp-pptx-to-svg)
- [C# PPTX in SVG konvertieren](#csharp-pptx-to-svg)
- [C# Wie konvertiere ich eine PPTX-Datei in SVG](#csharp-pptx-to-svg)

_Format_: **ODP**
- [C# ODP zu SVG](#csharp-odp-to-svg)
- [C# ODP in SVG konvertieren](#csharp-odp-to-svg)
- [C# Wie konvertiere ich eine ODP-Datei in SVG](#csharp-odp-to-svg)

_Format_: **Slide**
- [C# PowerPoint-Slide in SVG konvertieren](#render-a-slide-as-an-svg-image)
- [C# PPT-Slide in SVG konvertieren](#render-a-slide-as-an-svg-image)
- [C# PPTX-Slide in SVG konvertieren](#render-a-slide-as-an-svg-image)
- [C# ODP-Slide in SVG konvertieren](#render-a-slide-as-an-svg-image)

Andere Themen, die in diesem Artikel behandelt werden.
- [Siehe auch](#see-also)

## SVG-Format
SVG—eine Abkürzung für Scalable Vector Graphics—ist ein Standardgrafiktyp oder -format, das zur Darstellung zweidimensionaler Bilder verwendet wird. SVG speichert Bilder als Vektoren in XML mit Details, die ihr Verhalten oder Aussehen definieren.

SVG ist eines der wenigen Bildformate, die sehr hohe Standards in diesen Punkten erfüllen: Skalierbarkeit, Interaktivität, Leistung, Zugänglichkeit, Programmierbarkeit und andere. Aus diesen Gründen wird es häufig in der Webentwicklung verwendet.

Sie möchten möglicherweise SVG-Dateien verwenden, wenn Sie

- **Ihre Präsentation in einem *sehr großen Format* drucken möchten.** SVG-Bilder können auf jede Auflösung oder Ebene skaliert werden. Sie können SVG-Bilder so oft wie nötig in der Größe ändern, ohne Qualität einzubüßen.
- **Diagramme und Grafiken von Ihren Folien in *verschiedenen Medien oder Plattformen* verwenden möchten.** Die meisten Leser können SVG-Dateien interpretieren.
- **die *kleinsten möglichen Bildgrößen* verwenden möchten.** SVG-Dateien sind im Allgemeinen kleiner als ihre hochauflösenden Pendants in anderen Formaten, insbesondere in solchen, die auf Bitmap (JPEG oder PNG) basieren.

## Rendern eines Slides als SVG-Bild

Aspose.Slides für .NET ermöglicht es Ihnen, Folien in Ihren Präsentationen als SVG-Bilder zu exportieren. Gehen Sie diese Schritte durch, um SVG-Bilder zu erzeugen:

_Schritte: PowerPoint zu SVG-Konvertierungen in C#_

Der folgende Beispielcode erklärt diese Konvertierungen mithilfe von .NET.
- <a name="csharp-powerpoint-to-svg" id="csharp-powerpoint-to-svg"><strong>Schritte: PowerPoint in SVG in C# konvertieren</strong></a>
- <a name="csharp-ppt-to-svg" id="csharp-ppt-to-svg"><strong>Schritte: PPT in SVG in C# konvertieren</strong></a>
- <a name="csharp-pptx-to-svg" id="csharp-pptx-to-svg"><strong>Schritte: PPTX in SVG in C# konvertieren</strong></a>
- <a name="csharp-odp-to-svg" id="csharp-odp-to-svg"><strong>Schritte: ODP in SVG in C# konvertieren</strong></a>

_Code Schritte:_

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse.
   * _.ppt_ Erweiterung zum Laden der **PPT**-Datei innerhalb der _Presentation_ Klasse.
   * _.pptx_ Erweiterung zum Laden der **PPTX**-Datei innerhalb der _Presentation_ Klasse.
   * _.odp_ Erweiterung zum Laden der **ODP**-Datei innerhalb der _Presentation_ Klasse.
   * _.pps_ Erweiterung zum Laden der **PPS**-Datei innerhalb der _Presentation_ Klasse.
2. Iterieren Sie durch alle Folien in der Präsentation.
3. Schreiben Sie jede Folie in ihre eigene SVG-Datei über FileStream.

{{% alert color="primary" %}} 

Sie möchten vielleicht unsere [kostenlose Webanwendung](https://products.aspose.app/slides/conversion/ppt-to-svg) ausprobieren, in der wir die PPT zu SVG-Konvertierungsfunktion von Aspose.Slides für .NET implementiert haben.

{{% /alert %}} 

Dieser Beispielcode in C# zeigt Ihnen, wie man PowerPoint in SVG mithilfe von Aspose.Slides konvertiert:

``` csharp
// Präsentationsobjekt kann PowerPoint-Formate wie PPT, PPTX, ODP usw. laden.
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

## Siehe auch 

Dieser Artikel behandelt auch diese Themen. Die Codes sind dieselben wie oben.

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