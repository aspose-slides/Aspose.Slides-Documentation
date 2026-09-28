---
title: Aspose.Slides voor .NET
second_title: Aspose.Slides voor .NET
type: docs
weight: 10
url: /nl/net/
keywords:
- documentatie
- presentatieverwerking
- presentatieconversie
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Begin hier: installeer Aspose.Slides voor .NET, maak een eerste presentatie en vind de handleidingen voor veelvoorkomende taken, implementatie en de API‑referentie."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for .NET is een class library voor het maken, lezen, bewerken en converteren van PowerPoint- en OpenDocument‑presentaties in .NET‑toepassingen, zonder Microsoft PowerPoint of Office‑automatisering.

Het laadt en slaat PPT, PPTX, PPS, POT en ODP op, inclusief macro‑ingeschakelde en sjabloonvarianten, en exporteert naar PDF, XPS, HTML, SVG, TIFF, Markdown en afbeeldingen.

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
<li><a href="/slides/nl/net/system-requirements/">Systeemvereisten</a></li>
<li><a href="/slides/nl/net/getting-started/">Beginnershandleiding</a></li>
</ul>
<p>EVALUATIE</p>
<ul>
<li><a href="/slides/nl/net/supported-file-formats/">Ondersteunde bestandsformaten</a></li>
<li><a href="/slides/nl/net/features-overview/">Overzicht van functies</a></li>
<li><a href="/slides/nl/net/evaluate-aspose-slides/">Beperkingen proefversie</a></li>
<li><a href="/slides/nl/net/licensing/">Licenties</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Bouwen met Slides</b></p>
<hr>
<p>ALGEMENE TAKEN</p>
<ul>
<li><a href="/slides/nl/net/open-presentation/">Open een presentatie</a></li>
<li><a href="/slides/nl/net/save-presentation/">Sla een presentatie op</a></li>
<li><a href="/slides/nl/net/convert-powerpoint-to-pdf/">Converteer naar PDF</a></li>
<li><a href="/slides/nl/net/convert-slide/">Render dia's als afbeeldingen</a></li>
<li><a href="/slides/nl/net/manage-text/">Bewerk tekst en vormen</a></li>
</ul>
<p>SLIDES‑WERKSTROMEN</p>
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
<p><b>Implementatie &amp; Ondersteuning</b></p>
<hr>
<p>IMPLEMENTATIE</p>
<ul>
<li><a href="/slides/nl/net/net6/">Cross‑platform (.NET 6+)</a></li>
<li><a href="/slides/nl/net/how-to-run-aspose-slides-in-docker/">Uitvoeren in Docker</a></li>
<li><a href="/slides/nl/net/deploy-fonts/">Lettertypen</a></li>
<li><a href="/slides/nl/net/security/">Beveiliging</a></li>
</ul>
<p>REFERENTIE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/net/">API‑referentie</a></li>
<li><a href="https://releases.aspose.com/slides/net/release-notes/">Release‑notes</a></li>
<li><a href="/slides/nl/net/known-issues/">Bekende problemen</a></li>
<li><a href="/slides/nl/net/api-limitations/">Beperkingen uitvoer‑metadata</a></li>
<li><a href="https://releases.aspose.com/slides/net/">Downloaden</a></li>
</ul>
<p>ONDERSTEUNING</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Gratis ondersteuningsforum</a></li>
<li><a href="https://helpdesk.aspose.com/">Betaalde ondersteuningshelpdesk</a></li>
</ul>
</div>
</div>

------

<a name="your-first-presentation"></a>

## **Je eerste presentatie**

Maak een console‑applicatie met de .NET SDK 6 of hoger:

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

Voeg vervolgens één pakket toe voor je platform:

- Op Windows: `dotnet add package Aspose.Slides.NET`
- Op Linux en macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform` — zie [Installatie](/slides/nl/net/installation/) voor de Linux‑voorwaarde en voor systemen die Aspose.Slides.NET nodig hebben.

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

Het programma slaat *hello.pptx* op met één dia die een tekstvak bevat. Zonder licentie bevat het opgeslagen bestand een evaluatiewatermerk — zie [Licenties](/slides/nl/net/licensing/). Voor meer manieren om een presentatie te maken en te vullen, zie [Presentaties maken](/slides/nl/net/create-presentation/).