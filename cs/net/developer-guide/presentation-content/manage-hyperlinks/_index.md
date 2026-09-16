---
title: Spravovat hypertextové odkazy v prezentacích v .NET
linktitle: Spravovat hypertextové odkazy
type: docs
weight: 20
url: /cs/net/manage-hyperlinks/
keywords:
- přidat URL
- přidat hypertextový odkaz
- vytvořit hypertextový odkaz
- formátovat hypertextový odkaz
- odstranit hypertextový odkaz
- aktualizovat hypertextový odkaz
- hypertextový odkaz v textu
- hypertextový odkaz na snímku
- hypertextový odkaz na tvaru
- hypertextový odkaz na obrázku
- hypertextový odkaz na videu
- mutabilní hypertextový odkaz
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Přidávejte, formátujte, aktualizujte a odstraňujte hypertextové odkazy v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro .NET s příklady v jazyce C#."
---
## **Úvod**

Hypertextový odkaz spojuje obsah prezentace s webovou stránkou nebo umístěním v rámci prezentace. V PowerPointu hypertextové odkazy běžně slouží dvěma účelům:

* Otevřít webovou stránku z textu, tvaru nebo mediálního rámce.
* Přesunout se na jiný snímek, například z obsahu.

Aspose.Slides for .NET vám umožňuje přidávat tyto odkazy, řídit jejich vzhled a zvuk, aktualizovat jejich vlastnosti a odstraňovat je. Níže uvedené příklady ukazují, jak pracovat s hypertextovými odkazy na jednotlivých prvcích a jak získat přístup k odkazům na úrovni prezentace, snímku nebo textového rámce.

{{% alert color="info" title="Note" %}}
Můžete také upravovat prezentace pomocí [free online Aspose PowerPoint editor](https://products.aspose.app/slides/cs/editor).
{{% /alert %}} 

## **Přidat URL hypertextové odkazy**

Můžete přiřadit URL webové stránky k textu, tvaru nebo mediálnímu rámci. Prvek, ke kterému hypertextový odkaz přiřadíte, určuje klikací oblast: část textu odkazuje vybraný text, zatímco tvar nebo rámec odkazuje na objekt snímku.

### **Přidat URL hypertextové odkazy k textu**

Pro propojení textu s webovou stránkou přiřaďte [Hyperlink](https://reference.aspose.com/slides/cs/net/aspose.slides/hyperlink/) k vlastnosti [HyperlinkClick](https://reference.aspose.com/slides/cs/net/aspose.slides/portionformat/hyperlinkclick/) části textu, jak je ukázáno níže. Pouze tato část textu se stane klikací.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var textShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
textShape.AddTextFrame("Aspose: File Format APIs");
var portionFormat = textShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
portionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
portionFormat.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";
portionFormat.FontHeight = 32;

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

### **Přidat URL hypertextové odkazy k tvarům a mediálním rámcům**

Aby byl tvar nebo rámec klikací, nastavte jeho vlastnost [HyperlinkClick](https://reference.aspose.com/slides/cs/net/aspose.slides/shape/hyperlinkclick/). Hypertextový odkaz patří samotnému objektu, nikoli části textu uvnitř něj.

Stejný přístup platí pro obrázkové, audio a video rámečky: přiřaďte odkaz k rámci a v případě potřeby nastavte [Tooltip](https://reference.aspose.com/slides/cs/net/aspose.slides/ihyperlink/tooltip/) odkazu.

Následující příklad dělá obdélník klikacím:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
shape.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

## **Použít hypertextové odkazy pro vytvoření obsahu**

Interní hypertextové odkazy umožňují čtenářům přejít z obsahu na konkrétní snímek. Následující příklad používá [SetInternalHyperlinkClick](https://reference.aspose.com/slides/cs/net/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) k propojení textu „Page 2“ na prvním snímku na druhý snímek.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var firstSlide = presentation.Slides[0];
var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

var tableOfContents = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
tableOfContents.FillFormat.FillType = FillType.NoFill;
tableOfContents.LineFormat.FillFormat.FillType = FillType.NoFill;
tableOfContents.TextFrame.Paragraphs.Clear();

var paragraph = new Paragraph();
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
paragraph.Text = "Title of slide 2 .......... ";

var linkPortion = new Portion();
linkPortion.Text = "Page 2";
linkPortion.PortionFormat.HyperlinkManager.SetInternalHyperlinkClick(secondSlide);

paragraph.Portions.Add(linkPortion);
tableOfContents.TextFrame.Paragraphs.Add(paragraph);

presentation.Save("link_to_slide.pptx", SaveFormat.Pptx);
```

## **Formátovat hypertextové odkazy**

### **Barva**

Vlastnost [ColorSource](https://reference.aspose.com/slides/cs/net/aspose.slides/ihyperlink/colorsource/) rozhraní [IHyperlink](https://reference.aspose.com/slides/cs/net/aspose.slides/ihyperlink/) určuje, zda hypertextový odkaz používá barvu odkazu prezentace nebo formátování části textu. Pro použití vlastní barvy textu vyberte [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/hyperlinkcolorsource/) a nastavte barvu výplně části. Tato funkce byla zavedena v PowerPoint 2019; starší verze toto nastavení neaplikují.

Následující příklad přidává dva textové odkazy na stejný snímek. První používá červenou výplň textu, zatímco druhý zachovává výchozí barvu odkazu.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var coloredShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
coloredShape.AddTextFrame("This hyperlink uses a custom color.");
var coloredPortionFormat = coloredShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
coloredPortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
coloredPortionFormat.HyperlinkClick.ColorSource = HyperlinkColorSource.PortionFormat;
coloredPortionFormat.FillFormat.FillType = FillType.Solid;
coloredPortionFormat.FillFormat.SolidFillColor.Color = Color.Red;

var defaultShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
defaultShape.AddTextFrame("This hyperlink uses the default color.");
defaultShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");

presentation.Save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
```

### **Zvuk**

Hypertextový odkaz může při aktivaci přehrát zvuk nebo zastavit zvuk, který již přehrává. Použijte následující vlastnosti pro konfiguraci těchto chování:

- [IHyperlink.Sound](https://reference.aspose.com/slides/cs/net/aspose.slides/ihyperlink/sound/) určuje audio spojené s odkazem.
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/cs/net/aspose.slides/ihyperlink/stopsoundonclick/) řídí, zda aktivace odkazu zastaví předchozí zvuk.

#### **Přidat zvuk k hypertextovému odkazu**

Následující příklad načte `sampleaudio.wav` a přiřadí jej tlačítku na prvním snímku. Kliknutí na tlačítko přehraje zvuk a přejde na další snímek. Druhý tvar na tomto snímku zastaví předchozí zvuk při kliknutí, aniž by provedl navigaci.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var audioData = File.ReadAllBytes("sampleaudio.wav");
var hyperlinkSound = presentation.Audios.AddAudio(audioData);

var firstSlide = presentation.Slides[0];

var playButton = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
playButton.HyperlinkClick = Hyperlink.NextSlide;

if (!playButton.HyperlinkClick.StopSoundOnClick && playButton.HyperlinkClick.Sound == null)
{
    playButton.HyperlinkClick.Sound = hyperlinkSound;
}

var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

var stopButton = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
stopButton.HyperlinkClick = Hyperlink.NoAction;

stopButton.HyperlinkClick.StopSoundOnClick = true;

presentation.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
```

#### **Extrahovat zvuk z hypertextového odkazu**

Následující příklad otevře výše vytvořenou prezentaci a načte audio hypertextového odkazu prvního tvaru do paměti pomocí [Sound](https://reference.aspose.com/slides/cs/net/aspose.slides/ihyperlink/sound/) a [BinaryData](https://reference.aspose.com/slides/cs/net/aspose.slides/iaudio/binarydata/).

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("hyperlink-sound.pptx");

if (presentation.Slides.Count > 0 && presentation.Slides[0].Shapes.Count > 0)
{
    var hyperlink = presentation.Slides[0].Shapes[0].HyperlinkClick;
    var sound = hyperlink?.Sound;
    if (sound != null)
    {
        var audioData = sound.BinaryData;
        Console.WriteLine($"Extracted {audioData.Length} bytes of hyperlink audio.");
    }
    else
    {
        Console.WriteLine("The first shape has no hyperlink sound.");
    }
}
else
{
    Console.WriteLine("The presentation has no first slide or shape to inspect.");
}
```

### **Tooltip a nastavení interakce**

Po přiřazení hypertextového odkazu k textu nebo tvaru můžete aktualizovat následující vlastnosti rozhraní [IHyperlink](https://reference.aspose.com/slides/cs/net/aspose.slides/ihyperlink/):

- [Tooltip](https://reference.aspose.com/slides/cs/net/aspose.slides/ihyperlink/tooltip/) nastavuje text, který může uživatel vidět jako nápovědu k odkazu.
- [TargetFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ihyperlink/targetframe/) určuje cílový rámec v nadřazeném HTML framesetu, pokud je to relevantní.
- [History](https://reference.aspose.com/slides/cs/net/aspose.slides/ihyperlink/history/) řídí, zda aktivace odkazu přidá jeho cílovou adresu do seznamu prohlížených odkazů.
- [HighlightClick](https://reference.aspose.com/slides/cs/net/aspose.slides/ihyperlink/highlightclick/) řídí, zda je odkaz po kliknutí zvýrazněn.

## **Odstranit hypertextové odkazy z prezentací**

Použijte [GetAnyHyperlinks](https://reference.aspose.com/slides/cs/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) k získání kolekce kontejnerů hypertextových odkazů, včetně odkazů na části textu, před jejich změnou. Následující příklad odstraňuje oba typy aktivace z prvního snímku. Chcete‑li odstranit jen jeden typ, zavolejte pouze [RemoveHyperlinkClick](https://reference.aspose.com/slides/cs/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) nebo [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/cs/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/); odstranění akce kliknutí neodstraňuje odpovídající akci při najetí myší.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

if (presentation.Slides.Count > 0)
{
    var containers = presentation.Slides[0].HyperlinkQueries.GetAnyHyperlinks().ToList();
    foreach (var container in containers)
    {
        container.HyperlinkManager.RemoveHyperlinkClick();
        container.HyperlinkManager.RemoveHyperlinkMouseOver();
    }
    presentation.Save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The presentation has no slides to process.");
}
```

Pro nepodmíněné odstranění [RemoveAllHyperlinks](https://reference.aspose.com/slides/cs/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) odstraňuje oba typy aktivace ve vybraném rozsahu jedním voláním. Pro selektivní úklid a pokrytí mistrů, rozvržení a poznámek viz [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Vytvořit kompletní inventář hypertextových odkazů**

Před distribucí prezentace proveďte inventuru jejích interaktivních akcí i webových odkazů. [GetAnyHyperlinks](https://reference.aspose.com/slides/cs/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) vrací objekty [IHyperlinkContainer](https://reference.aspose.com/slides/cs/net/aspose.slides/ihyperlinkcontainer/), nikoli plochý seznam řetězců URL. Prozkoumejte jak [HyperlinkClick](https://reference.aspose.com/slides/cs/net/aspose.slides/ihyperlinkcontainer/hyperlinkclick/), tak [HyperlinkMouseOver](https://reference.aspose.com/slides/cs/net/aspose.slides/ihyperlinkcontainer/hyperlinkmouseover/) v každém kontejneru. Jsou nezávislé: stejný kontejner může mít obě akce, takže kompletní zpráva potřebuje až dva řádky na kontejner.

Prohledávání jen na úrovni tvarů může minout odkazy připojené k částem textu. Dotazujte místo toho příslušný rozsah a uchovávejte vrácené kontejnery, abyste je mohli později aktualizovat nebo odstranit jejich akce.

### **Dotazovat rozsahy prezentace, snímku a textového rámce**

Rozhraní [IHyperlinkQueries](https://reference.aspose.com/slides/cs/net/aspose.slides/ihyperlinkqueries/) je dostupné přes [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentation/hyperlinkqueries/), [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/cs/net/aspose.slides/ibaseslide/hyperlinkqueries/) a [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/hyperlinkqueries/). Každý rozsah podporuje stejné dotazy:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/cs/net/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) vrací kontejnery s akcí kliknutí.
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/cs/net/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) vrací kontejnery s akcí při najetí myší.
- [GetAnyHyperlinks](https://reference.aspose.com/slides/cs/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) vrací kontejnery s jednou nebo oběma akcemi.

Následující příklad vytváří `hyperlink-audit-input.pptx` s externím odkazem kliknutí, odkazem souboru při najetí myší, interní navigací na snímek, odkazem textu při najetí a makro akcí. Žádná z těchto akcí se neprovádí. Stejné tři dotazy fungují v každém rozsahu; počty popisují kontejnery, nikoli celkový počet akcí. Rozsah textového rámce vylučuje odkazy vlastního tvaru.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var destination = presentation.Slides.AddEmptySlide(slide.LayoutSlide);
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
shape.TextFrame.Text = "Click the text to go to slide 2";
shape.HyperlinkManager.SetExternalHyperlinkClick("https://example.com/");
shape.HyperlinkClick.Tooltip = "Public website";
shape.HyperlinkManager.SetExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

var portionFormat = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
portionFormat.HyperlinkManager.SetInternalHyperlinkClick(destination);
portionFormat.HyperlinkManager.SetExternalHyperlinkMouseOver("https://example.com/help");
var macroButton = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 120, 200, 60);
macroButton.HyperlinkManager.SetMacroHyperlinkClick("ReviewPresentation");

PrintCounts("Presentation", presentation.HyperlinkQueries);
PrintCounts("Slide 1", slide.HyperlinkQueries);
PrintCounts("Text frame", shape.TextFrame.HyperlinkQueries);
presentation.Save("hyperlink-audit-input.pptx", SaveFormat.Pptx);

static void PrintCounts(string scope, IHyperlinkQueries queries)
{
    var clickContainers = queries.GetHyperlinkClicks();
    var mouseOverContainers = queries.GetHyperlinkMouseOvers();
    var allContainers = queries.GetAnyHyperlinks();
    Console.WriteLine($"{scope}: click={clickContainers.Count}, mouse-over={mouseOverContainers.Count}, any={allContainers.Count}");
}
```

Pro tento příklad dotazy na prezentaci a snímek uvádějí tři kontejnery kliknutí, dva kontejnery při najetí a tři kontejnery s libovolnou akcí. Dotaz na textový rámec uvádí po jednom kontejneru v každé kategorii.

### **Klasifikovat akce a cíle**

Použijte [IHyperlink.ActionType](https://reference.aspose.com/slides/cs/net/aspose.slides/ihyperlink/actiontype/) k interpretaci akce před interpretací jejího cíle. Hodnoty [HyperlinkActionType](https://reference.aspose.com/slides/cs/net/aspose.slides/hyperlinkactiontype/) pokrývají více než jen webovou navigaci:

| Values | Meaning for an audit |
| --- | --- |
| `Hyperlink` | Externí hypertextový odkaz; prověřte URL a její schéma. |
| `JumpSpecificSlide` | Interní navigace na konkrétní snímek. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Vestavěná navigace prezentace, řešená v kontextu režimu prezentace. |
| `JumpEndShow`, `StartCustomSlideShow` | Ukončit aktuální prezentaci nebo spustit vlastní prezentaci. |
| `StartMacro` | Spustit makro. |
| `StartProgram` | Spustit program. |
| `OpenFile`, `OpenPresentation` | Otevřít soubor nebo jinou prezentaci; posuzujte odděleně od webových URL. |
| `StartStopMedia` | Spustit nebo zastavit přehrávání média. |
| `NoAction`, `Unknown` | Žádná navigační akce, nebo nerozpoznaná akce vyžadující revizi. |

Čtěte externí cíle z [ExternalUrl](https://reference.aspose.com/slides/cs/net/aspose.slides/ihyperlink/externalurl/) a konkrétní interní cíle z [TargetSlide](https://reference.aspose.com/slides/cs/net/aspose.slides/ihyperlink/targetslide/). Interní akce a vestavěné příkazy nemusí mít externí URL; prázdná URL neznamená, že kontejner nemá akci. Zachovejte [ExternalUrlOriginal](https://reference.aspose.com/slides/cs/net/aspose.slides/ihyperlink/externalurloriginal/) pokud se liší od normalizované URL, a zahrňte [Tooltip](https://reference.aspose.com/slides/cs/net/aspose.slides/ihyperlink/tooltip/) pokud je dostupný.

### **Zpráva, sanitizace a ověření hypertextových odkazů**

Následující příklad pro .NET 6+ načte existující prezentaci (použijte soubor vytvořený výše), zapíše `hyperlink-audit.json`, aplikuje politiku, uloží `hyperlink-sanitized.pptx` a znovu ji otevře, aby zkontroloval oba typy aktivace. Před změnou sbírá kontejnery a používá referenční rovnost k zamezení dvojitého zpracování stejného kontejneru. Dotazy na prezentaci zahrnují běžné snímky; pro inventář na úrovni balíčku dotazuje také výslovně mistry, rozvržení, poznámky a mistry poznámek a podkladů, pokud jsou přítomny.

Zpráva zaznamenává jednorozměrný index snímku a [SlideId](https://reference.aspose.com/slides/cs/net/aspose.slides/ibaseslide/slideid/) kde je to možné. [ISlideComponent.Slide](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecomponent/slide/) poskytuje vlastní snímek pro podporované kontejnery. Mistry, rozvržení a poznámky nemají běžný index snímku a jsou identifikovány podle svého rozsahu. Kontejnery tvarů a kontejnery formátování částí textu jsou označeny odděleně; ostatní typy kontejnerů si zachovávají svůj runtime typový název. Každému kontejneru je přiřazeno lokální ID zprávy, aby bylo možné provázat jeho dvě akce.

Tato úmyslně restriktivní aplikační politika povoluje pouze absolutní HTTPS URL a platné interní cíle snímků. Odmítá makra, programy, souborové akce, jiné akce prezentace, neznámé akce a jiné schémata URL. Tato odmítnutí jsou rozhodnutí politiky, nikoli závěrem o bezpečnosti Aspose.Slides. Pouze HTTPS nezaručuje důvěryhodnost: přidejte seznamy povolených hostitelů a další kontroly pro vaši aplikaci. Kontrolují se jak původní, tak normalizované externí URL. Příklad audituje metadata bez následování odkazů či spouštění akcí.

Pro opravu podporuje [HyperlinkManager](https://reference.aspose.com/slides/cs/net/aspose.slides/ihyperlinkcontainer/hyperlinkmanager/) metody [SetExternalHyperlinkClick](https://reference.aspose.com/slides/cs/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/cs/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) a [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/cs/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/). Zde jsou zakázané externí odkazy kliknutí nahrazeny pevnou HTTPS vstupní stránkou; ostatní zakázané odkazy kliknutí i zakázané akce při najetí jsou odstraněny samostatně. Nastavte `replaceExternalClicks` na `false`, chcete‑li odstranit všechna porušení politiky. Vyberte náhradní stránku vlastněnou aplikací před nasazením.

Exportní vlajka zprávy používá konzervativní politiku revize PDF: označuje akce při najetí a vše kromě externího odkazu nebo konkrétního skoku na snímek jako potenciálně nepodporované. Jedná se o náznak revize, nikoli o test schopností nebo záruku, že neoznačené odkazy přežijí export. Podporované exporty do [PDF](/slides/cs/net/convert-powerpoint-to-pdf/) a [HTML](/slides/cs/net/convert-powerpoint-to-html/) mohou zachovat hypertextové odkazy, v závislosti na akci, možnostech exportu a prohlížeči. Rasterové [images](/slides/cs/net/convert-powerpoint-to-png/) a [video](/slides/cs/net/convert-powerpoint-to-video/) nemohou zachovat interaktivní odkazy; při auditu pro tyto výstupy označte každou akci.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

const bool replaceExternalClicks = true;
const string replacementUrl = "https://example.com/blocked-link";
using var presentation = new Presentation("hyperlink-audit-input.pptx");
var containers = CollectContainers(presentation);
var rows = new List<object>();

for (var index = 0; index < containers.Count; index++)
{
    var container = containers[index];
    AddRow(container.HyperlinkClick, "click", container, index + 1);
    AddRow(container.HyperlinkMouseOver, "mouse-over", container, index + 1);
}

var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
var json = JsonSerializer.Serialize(rows, jsonOptions);
File.WriteAllText("hyperlink-audit.json", json);

foreach (var container in containers)
{
    var click = container.HyperlinkClick;
    if (PolicyViolation(click) != null)
    {
        if (replaceExternalClicks && click.ActionType == HyperlinkActionType.Hyperlink)
        {
            container.HyperlinkManager.SetExternalHyperlinkClick(replacementUrl);
        }
        else
        {
            container.HyperlinkManager.RemoveHyperlinkClick();
        }
    }
    if (PolicyViolation(container.HyperlinkMouseOver) != null)
    {
        container.HyperlinkManager.RemoveHyperlinkMouseOver();
    }
}

presentation.Save("hyperlink-sanitized.pptx", SaveFormat.Pptx);
using var reopened = new Presentation("hyperlink-sanitized.pptx");
var remainingContainers = CollectContainers(reopened);
var violations = 0;
foreach (var container in remainingContainers)
{
    if (PolicyViolation(container.HyperlinkClick) != null) violations++;
    if (PolicyViolation(container.HyperlinkMouseOver) != null) violations++;
}
Console.WriteLine($"Audit rows: {rows.Count}; prohibited actions after reopening: {violations}");
if (violations != 0)
{
    Console.WriteLine("Verification failed: do not distribute the saved presentation.");
    Environment.ExitCode = 1;
}

void AddRow(IHyperlink? link, string activation, IHyperlinkContainer container, int containerId)
{
    if (link == null) return;
    var ownerSlide = (container as ISlideComponent)?.Slide;
    var targetSlide = link.TargetSlide;
    var violation = PolicyViolation(link);
    var ownerType = container is IShape ? "Shape" : container is IPortionFormat ? "Text portion" : container.GetType().Name;
    var ordinaryAction = link.ActionType == HyperlinkActionType.Hyperlink || link.ActionType == HyperlinkActionType.JumpSpecificSlide;
    rows.Add(new
    {
        ContainerId = containerId,
        SlideIndex = SlideIndex(presentation, ownerSlide),
        SlideId = ownerSlide?.SlideId,
        Scope = ownerSlide?.GetType().Name,
        OwnerType = ownerType,
        Activation = activation,
        ActionType = link.ActionType.ToString(),
        ExternalUrl = link.ExternalUrl,
        TargetSlideIndex = SlideIndex(presentation, targetSlide),
        TargetSlideId = targetSlide?.SlideId,
        Tooltip = link.Tooltip,
        OriginalExternalUrl = link.ExternalUrlOriginal != link.ExternalUrl ? link.ExternalUrlOriginal : null,
        PotentiallyUnsafe = violation != null,
        PolicyViolation = violation,
        TargetExport = "PDF",
        PotentiallyUnsupportedByExport = activation == "mouse-over" || !ordinaryAction
    });
}

static int? SlideIndex(IPresentation presentation, IBaseSlide? slide)
{
    for (var index = 0; index < presentation.Slides.Count; index++)
    {
        if (ReferenceEquals(presentation.Slides[index], slide)) return index + 1;
    }
    return null;
}

static string? PolicyViolation(IHyperlink? link)
{
    if (link == null) return null;
    if (link.ActionType == HyperlinkActionType.JumpSpecificSlide)
    {
        return link.TargetSlide == null ? "Missing target slide" : null;
    }
    if (link.ActionType != HyperlinkActionType.Hyperlink) return "Action is not allowed";
    if (!IsHttps(link.ExternalUrl)) return "Normalized URL is not absolute HTTPS";
    var original = link.ExternalUrlOriginal;
    if (!string.IsNullOrEmpty(original) && !IsHttps(original)) return "Original URL is not absolute HTTPS";
    return null;
}

static bool IsHttps(string? value)
{
    return Uri.TryCreate(value, UriKind.Absolute, out var uri) && uri.Scheme == Uri.UriSchemeHttps;
}

static List<IHyperlinkContainer> CollectContainers(IPresentation presentation)
{
    var found = new List<IHyperlinkContainer>();
    found.AddRange(presentation.HyperlinkQueries.GetAnyHyperlinks());
    foreach (var master in presentation.Masters) AddScope(master);
    foreach (var layout in presentation.LayoutSlides) AddScope(layout);
    foreach (var slide in presentation.Slides) AddScope(slide.NotesSlideManager.NotesSlide);
    AddScope(presentation.MasterNotesSlideManager.MasterNotesSlide);
    AddScope(presentation.MasterHandoutSlideManager.MasterHandoutSlide);
    return found.Distinct<IHyperlinkContainer>(ReferenceEqualityComparer.Instance).ToList();

    void AddScope(IBaseSlide? slide)
    {
        if (slide != null) found.AddRange(slide.HyperlinkQueries.GetAnyHyperlinks());
    }
}
```

S výše vytvořeným vstupem zpráva obsahuje pět řádků akcí. Odkaz souboru při najetí a makro kliknutí jsou odstraněny, zatímco HTTPS odkazy a interní navigace na snímek zůstávají. Ověření vypisuje nula zakázaných akcí. Vstup obsahující zakázanou externí URL pro kliknutí také ukazuje směrovací větev. Kontejner s povoleným kliknutím a zakázaným najetím si ponechává akci kliknutí.

Tento selektivní úklid se liší od [RemoveAllHyperlinks](https://reference.aspose.com/slides/cs/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/), který odstraňuje oba typy aktivace v celém vybraném rozsahu bez ohledu na politiku. Ověření zde kontroluje jen akce hypertextových odkazů; neodstraňuje vložené VBA projekty, OLE objekty ani jiný aktivní obsah a nevaliduje exportovaný PDF ani HTML soubor.

## **FAQ**

**Jak mohu propojit sekci nebo její první snímek?**

Sekce v PowerPointu seskupují snímky, ale interní hypertextový odkaz cílí na konkrétní snímek. Pro vytvoření navigace na sekci propojte odkaz na první snímek v této sekci.

**Mohu připojit hypertextový odkaz k prvkům hlavního snímku, aby fungoval na všech snímcích?**

Ano. Prvky hlavního snímku a rozvržení podporují hypertextové odkazy. Odkazy na těchto prvcích jsou dostupné během režimu prezentace na snímcích, které používají odpovídající hlavní snímek nebo rozvržení.

**Zůstanou hypertextové odkazy zachovány při exportu do PDF, HTML, obrázků nebo videa?**

Podporované exporty do PDF a HTML mohou odkazy zachovat; rastrové obrázky a video ne. Viz úvahy o exportu v [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).