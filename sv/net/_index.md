---
title: Aspose.Slides för .NET
second_title: Aspose.Slides för .NET
type: docs
weight: 10
url: /sv/net/
keywords:
- dokumentation
- presentationbearbetning
- presentationkonvertering
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Börja här: installera Aspose.Slides för .NET, skapa en första presentation och hitta guiderna för vanliga uppgifter, API-referensen och support."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for .NET är ett klassbibliotek för att skapa, läsa, redigera och konvertera PowerPoint‑ och OpenDocument‑presentationer i .NET‑applikationer, utan Microsoft PowerPoint eller Office‑automation.

Det laddar och sparar PPT, PPTX, PPS, POT och ODP, inklusive makro‑aktiverade och mall‑varianter, och exporterar till PDF, XPS, HTML, SVG, TIFF, Markdown och bilder.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Kom igång</b></p>
<hr>
<p>KOMMA IGÅNG</p>
<ul>
<li><a href="/slides/sv/net/installation/">Installation</a></li>
<li><a href="/slides/sv/net/create-presentation/">Skapa din första presentation</a></li>
<li><a href="/slides/sv/net/getting-started/">Kom igång‑guide</a></li>
</ul>
<p>UTVÄRDERA</p>
<ul>
<li><a href="/slides/sv/net/supported-file-formats/">Filformat som stöds</a></li>
<li><a href="/slides/sv/net/evaluate-aspose-slides/">Begränsningar i provversion</a></li>
<li><a href="/slides/sv/net/licensing/">Licensiering</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Bygg med Slides</b></p>
<hr>
<p>VANLIGA UPPGIFTER</p>
<ul>
<li><a href="/slides/sv/net/open-presentation/">Öppna en presentation</a></li>
<li><a href="/slides/sv/net/save-presentation/">Spara en presentation</a></li>
<li><a href="/slides/sv/net/convert-powerpoint-to-pdf/">Konvertera till PDF</a></li>
<li><a href="/slides/sv/net/convert-slide/">Rendera slides som bilder</a></li>
<li><a href="/slides/sv/net/manage-text/">Redigera text och former</a></li>
</ul>
<p>SLIDES‑ARBETSFÖRDE</p>
<ul>
<li><a href="/slides/sv/net/powerpoint-charts/">Diagram</a></li>
<li><a href="/slides/sv/net/powerpoint-animation/">Animationer</a></li>
<li><a href="/slides/sv/net/manage-media-files/">Audio och video</a></li>
<li><a href="/slides/sv/net/presentation-design/">Slide‑design</a></li>
<li><a href="/slides/sv/net/merge-presentation/">Slå ihop presentationer</a></li>
</ul>
<p>EXEMPEL</p>
<ul>
<li><a href="/slides/sv/net/examples/">Exempel per slide‑element</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-.NET">Exempel på GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referens &amp; Support</b></p>
<hr>
<p>REFERENS</p>
<ul>
<li><a href="https://reference.aspose.com/slides/sv/net/">API‑referens</a></li>
<li><a href="https://releases.aspose.com/slides/sv/net/release-notes/">Release‑anteckningar</a></li>
<li><a href="/slides/sv/net/known-issues/">Kända problem</a></li>
<li><a href="https://releases.aspose.com/slides/sv/net/">Nedladdning</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/sv/11">Gratis supportforum</a></li>
<li><a href="https://helpdesk.aspose.com/">Betald support‑helpdesk</a></li>
</ul>
</div>
</div>

------

## **Din första presentation**

Skapa en konsolapplikation med .NET SDK 6 eller senare:

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

Lägg sedan till ett paket för din plattform:

- På Windows: `dotnet add package Aspose.Slides.NET`
- På Linux och macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform` — se [Installation](/slides/sv/net/installation/) för Linux‑förutsättningen och för systemen som behöver Aspose.Slides.NET istället.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

Programmet sparar *hello.pptx* med ett bildspel som innehåller en textruta. Utan licens innehåller den sparade filen ett utvärderingsvattenstämpel — se [Licensiering](/slides/sv/net/licensing/). För fler sätt att skapa och fylla en presentation, se [Skapa presentationer](/slides/sv/net/create-presentation/).