---
title: Aspose.Slides for .NET
second_title: Aspose.Slides for .NET
type: docs
weight: 10
url: /cs/net/
keywords:
- dokumentace
- zpracování prezentací
- převod prezentací
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Začněte zde: nainstalujte Aspose.Slides pro .NET, vytvořte první prezentaci a najděte průvodce pro běžné úkoly, nasazení a referenci API."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for .NET je knihovna tříd pro vytváření, čtení, úpravu a převod prezentací PowerPoint a OpenDocument v aplikacích .NET, bez Microsoft PowerPoint nebo Office Automation.

Načítá a ukládá soubory PPT, PPTX, PPS, POT a ODP, včetně variant s makry a šablon, a exportuje do PDF, XPS, HTML, SVG, TIFF, Markdown a obrázků.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Začínáme</b></p>
<hr>
<p>Zahájení</p>
<ul>
<li><a href="/slides/cs/net/installation/">Instalace</a></li>
<li><a href="/slides/cs/net/create-presentation/">Vytvořte svou první prezentaci</a></li>
<li><a href="/slides/cs/net/system-requirements/">Systémové požadavky</a></li>
<li><a href="/slides/cs/net/getting-started/">Průvodce pro začátek</a></li>
</ul>
<p>EVALUACE</p>
<ul>
<li><a href="/slides/cs/net/supported-file-formats/">Podporované formáty souborů</a></li>
<li><a href="/slides/cs/net/features-overview/">Přehled funkcí</a></li>
<li><a href="/slides/cs/net/evaluate-aspose-slides/">Omezení zkušební verze</a></li>
<li><a href="/slides/cs/net/licensing/">Licencování</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Vytvářejte pomocí Slides</b></p>
<hr>
<p>Obecné úkoly</p>
<ul>
<li><a href="/slides/cs/net/open-presentation/">Otevřít prezentaci</a></li>
<li><a href="/slides/cs/net/save-presentation/">Uložit prezentaci</a></li>
<li><a href="/slides/cs/net/convert-powerpoint-to-pdf/">Převést do PDF</a></li>
<li><a href="/slides/cs/net/convert-slide/">Vykreslit snímky jako obrázky</a></li>
<li><a href="/slides/cs/net/manage-text/">Upravit text a tvary</a></li>
</ul>
<p>Pracovní procesy</p>
<ul>
<li><a href="/slides/cs/net/powerpoint-charts/">Grafy</a></li>
<li><a href="/slides/cs/net/powerpoint-animation/">Animace</a></li>
<li><a href="/slides/cs/net/manage-media-files/">Audio a video</a></li>
<li><a href="/slides/cs/net/presentation-design/">Návrh snímků</a></li>
<li><a href="/slides/cs/net/merge-presentation/">Sloučit prezentace</a></li>
</ul>
<p>Příklady</p>
<ul>
<li><a href="/slides/cs/net/examples/">Příklady podle prvku snímku</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-.NET">Příklady na GitHubu</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Nasazení a podpora</b></p>
<hr>
<p>Nasazení</p>
<ul>
<li><a href="/slides/cs/net/net6/">Více platforem (.NET 6+)</a></li>
<li><a href="/slides/cs/net/how-to-run-aspose-slides-in-docker/">Spustit v Dockeru</a></li>
<li><a href="/slides/cs/net/deploy-fonts/">Písma</a></li>
<li><a href="/slides/cs/net/security/">Zabezpečení</a></li>
</ul>
<p>Reference</p>
<ul>
<li><a href="https://reference.aspose.com/slides/net/">Reference API</a></li>
<li><a href="https://releases.aspose.com/slides/net/release-notes/">Poznámky k vydání</a></li>
<li><a href="/slides/cs/net/known-issues/">Známé problémy</a></li>
<li><a href="/slides/cs/net/api-limitations/">Omezení výstupních metadat</a></li>
<li><a href="https://products.aspose.com/slides/net/">Stránka produktu</a></li>
<li><a href="https://releases.aspose.com/slides/net/">Stáhnout</a></li>
</ul>
<p>Podpora</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Bezplatné fórum podpory</a></li>
<li><a href="https://helpdesk.aspose.com/">Placená podpora helpdesk</a></li>
</ul>
</div>
</div>

------

<a name="your-first-presentation"></a>

## **Vaše první prezentace**

Vytvořte konzolovou aplikaci pomocí .NET SDK 6 nebo novější:

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

Poté přidejte jeden balíček pro vaši platformu:

- Na Windows: `dotnet add package Aspose.Slides.NET`
- Na Linuxu a macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform` — viz [Installation](/slides/cs/net/installation/) pro předpoklad pro Linux a pro systémy, které potřebují místo toho Aspose.Slides.NET.

Nahraďte obsah souboru *Program.cs* tímto kódem a spusťte `dotnet run`:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

Program uloží *hello.pptx* s jedním snímkem obsahujícím textové pole. Bez licence obsahuje uložený soubor vodoznak evaluace — viz [Licensing](/slides/cs/net/licensing/). Další způsoby, jak vytvořit a naplnit prezentaci, najdete v [Create Presentations](/slides/cs/net/create-presentation/).