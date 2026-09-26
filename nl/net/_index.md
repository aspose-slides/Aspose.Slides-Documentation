---
title: Aspose.Slides for .NET
second_title: Aspose.Slides for .NET
type: docs
weight: 10
url: /nl/net/
keywords:
- documentatie
- presentatieverwerking
- presentati econversie
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Begin hier: installeer Aspose.Slides for .NET, maak een eerste presentatie, en vind de handleidingen voor veelvoorkomende taken, de API-referentie en ondersteuning."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for .NET is een class library voor het maken, lezen, bewerken en converteren van PowerPoint- en OpenDocument-presentaties in .NET-toepassingen, zonder Microsoft PowerPoint of Office-automatisering.

Het laadt en slaat PPT, PPTX, PPS, POT en ODP op, inclusief macro‑ondersteunde en sjabloonvarianten, en exporteert naar PDF, XPS, HTML, SVG, TIFF, Markdown en afbeeldingen.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Aan de slag</b></p>
<hr>
<p>AAN DE SLAG</p>
<ul>
<li><a href="/slides/nl/net/installation/">Installatie</a></li>
<li><a href="/slides/nl/net/create-presentation/">Maak je eerste presentatie</a></li>
<li><a href="/slides/nl/net/getting-started/">Beginhandleiding</a></li>
</ul>
<p>EVALUEREN</p>
<ul>
<li><a href="/slides/nl/net/supported-file-formats/">Ondersteunde bestandsformaten</a></li>
<li><a href="/slides/nl/net/evaluate-aspose-slides/">Proefversie beperkingen</a></li>
<li><a href="/slides/nl/net/licensing/">Licenties</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Bouw met Slides</b></p>
<hr>
<p>ALGEMENE TAKEN</p>
<ul>
<li><a href="/slides/nl/net/open-presentation/">Open een presentatie</a></li>
<li><a href="/slides/nl/net/save-presentation/">Sla een presentatie op</a></li>
<li><a href="/slides/nl/net/convert-powerpoint-to-pdf/">Converteer naar PDF</a></li>
<li><a href="/slides/nl/net/convert-slide/">Render dia's als afbeeldingen</a></li>
<li><a href="/slides/nl/net/manage-text/">Bewerk tekst en vormen</a></li>
</ul>
<p>SLIDES-WERKSTROMEN</p>
<ul>
<li><a href="/slides/nl/net/powerpoint-charts/">Grafieken</a></li>
<li><a href="/slides/nl/net/powerpoint-animation/">Animaties</a></li>
<li><a href="/slides/nl/net/manage-media-files/">Audio en video</a></li>
<li><a href="/slides/nl/net/presentation-design/">Dia‑ontwerp</a></li>
<li><a href="/slides/nl/net/merge-presentation/">Presentaties samenvoegen</a></li>
</ul>
<p>VOORBEELDEN</p>
<ul>
<li><a href="/slides/nl/net/examples/">Voorbeelden per dia‑element</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-.NET">Voorbeelden op GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referentie &amp; Ondersteuning</b></p>
<hr>
<p>REFERENTIE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/net/">API‑referentie</a></li>
<li><a href="https://releases.aspose.com/slides/net/release-notes/">Release‑notities</a></li>
<li><a href="/slides/nl/net/known-issues/">Bekende problemen</a></li>
<li><a href="https://releases.aspose.com/slides/net/">Download</a></li>
</ul>
<p>ONDERSTEUNING</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Gratis ondersteuningsforum</a></li>
<li><a href="https://helpdesk.aspose.com/">Betaalde ondersteunings‑helpdesk</a></li>
</ul>
</div>
</div>

------

## **Je eerste presentatie**

Maak een console‑applicatie met de .NET SDK 6 of hoger:

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

Voeg daarna één pakket toe voor je platform:

- Op Windows: `dotnet add package Aspose.Slides.NET`
- Op Linux en macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform` — zie [Installatie](/slides/nl/net/installation/) voor de Linux‑vereiste en voor de systemen die in plaats daarvan Aspose.Slides.NET nodig hebben.

Vervang de inhoud van *Program.cs* door deze code en voer `dotnet run` uit:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

Het programma slaat *hello.pptx* op met één dia met een tekstvak. Zonder licentie bevat het opgeslagen bestand een evaluatiewatermerk — zie [Licenties](/slides/nl/net/licensing/). Voor meer manieren om een presentatie te maken en te vullen, zie [Maak presentaties](/slides/nl/net/create-presentation/).