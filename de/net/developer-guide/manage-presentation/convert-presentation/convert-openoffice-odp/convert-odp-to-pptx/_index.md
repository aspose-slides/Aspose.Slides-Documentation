---
title: ODP in PPTX umwandeln in C#
linktitle: ODP in PPTX umwandeln
type: docs
weight: 10
url: /de/net/convert-odp-to-pptx/
keywords: "OpenOffice-Präsentation umwandeln, ODP, ODP in PPTX, C#, Csharp, .NET"
description: "OpenOffice ODP in PowerPoint-Präsentation PPTX in C# oder .NET umwandeln"
---

## Überblick

Dieser Artikel erklärt die folgenden Themen.

- [C# ODP in PPTX umwandeln](#csharp-odp-to-pptx)
- [C# ODP in PowerPoint umwandeln](#csharp-odp-to-powerpoint)

## C# ODP in PPTX Umwandlung

Aspose.Slides für .NET bietet die Klasse Presentation, die eine Präsentationsdatei darstellt. [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse kann jetzt auch ODP über den Konstruktor der Präsentation zugreifen, wenn das Objekt instanziiert wird. Das folgende Beispiel zeigt, wie man eine ODP-Präsentation in eine PPTX-Präsentation umwandelt.

<a name="csharp-odp-to-pptx" id="csharp-odp-to-pptx"><strong>Schritte: ODP in PPTX umwandeln in C#</strong></a> |
<a name="csharp-odp-to-powerpoint" id="csharp-odp-to-powerpoint"><strong>Schritte: ODP in PowerPoint umwandeln in C#</strong></a>

```c#
// Öffnen der ODP-Datei
Presentation pres = new Presentation("AccessOpenDoc.odp");

// Speichern der ODP-Präsentation im PPTX-Format
pres.Save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
```

## **Live-Beispiel**
Sie können die [**Aspose.Slides Umwandlung**](https://products.aspose.app/slides/conversion/) Webanwendung besuchen, die mit der **Aspose.Slides API** erstellt wurde. Die App demonstriert, wie die Umwandlung von ODP in PPTX mit der Aspose.Slides API implementiert werden kann.