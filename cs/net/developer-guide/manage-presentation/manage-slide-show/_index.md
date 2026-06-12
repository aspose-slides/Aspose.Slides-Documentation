---
title: Správa prezentace v .NET
linktitle: Prezentace
type: docs
weight: 90
url: /cs/net/manage-slide-show/
keywords:
- typ prezentace
- prezentováno řečníkem
- prohlíženo jednotlivcem
- prohlíženo v kiosku
- možnosti prezentace
- nepřetržité smyčkování
- prezentace bez komentáře
- prezentace bez animace
- barva pera
- prezentovat snímky
- vlastní prezentace
- postupovat snímky
- ručně
- použití časování
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Naučte se, jak spravovat prezentace v Aspose.Slides pro .NET. Ovládejte přechody snímků, časování a další funkce v formátech PPT, PPTX a ODP s lehkostí."
---
## **Úvod**

V Microsoft PowerPoint jsou nastavení **Slide Show** klíčovým nástrojem pro přípravu a předkládání profesionálních prezentací. Jednou z nejdůležitějších funkcí v této sekci je **Set Up Show**, která vám umožňuje přizpůsobit prezentaci konkrétním podmínkám a publiku, čímž zajišťuje flexibilitu a pohodlí. Pomocí této funkce můžete vybrat typ prezentace (např. přednášená řečníkem, prohlížená jednotlivcem nebo prohlížená v kiosku), povolit nebo zakázat opakování, zvolit konkrétní snímky k zobrazení a použít časování. Tento krok v přípravě je zásadní pro zvýšení účinnosti a profesionality vaší prezentace.

`SlideShowSettings` je vlastnost třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) typu [SlideShowSettings](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/slideshowsettings/), která vám umožňuje spravovat nastavení prezentace ve PowerPointu. V tomto článku prozkoumáme, jak tuto vlastnost použít k nastavení a kontrole různých aspektů nastavení prezentace.

## **Vyberte typ prezentace**

`SlideShowSettings.SlideShowType` určuje typ prezentace, který může být instancí jedné z následujících tříd: [PresentedBySpeaker](https://reference.aspose.com/slides/cs/net/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/cs/net/aspose.slides/browsedbyindividual/) nebo [BrowsedAtKiosk](https://reference.aspose.com/slides/cs/net/aspose.slides/browsedatkiosk/). Použití této vlastnosti vám umožní přizpůsobit prezentaci různým scénářům použití, jako jsou automatizované kiosky nebo ruční prezentace.

Níže uvedený příklad kódu vytvoří novou prezentaci a nastaví typ prezentace na „Browsed by an individual“ bez zobrazení posuvníku.

```cs
using var presentation = new Presentation();

var showType = new BrowsedByIndividual
{
    ShowScrollbar = false
};

presentation.SlideShowSettings.SlideShowType = showType;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Povolit možnosti prezentace**

`SlideShowSettings.Loop` určuje, zda se má prezentace opakovat ve smyčce, dokud není ručně zastavena. To je užitečné pro automatizované prezentace, které musí běžet nepřetržitě. `SlideShowSettings.ShowNarration` určuje, zda se během prezentace mají přehrávat hlasové komentáře. To je vhodné pro automatizované prezentace obsahující hlasové vedení pro publikum. `SlideShowSettings.ShowAnimation` určuje, zda se mají přehrávat animace přidané k objektům snímku. To zajišťuje úplný vizuální efekt prezentace.

Níže uvedený příklad kódu vytvoří novou prezentaci a nastaví prezentaci do smyčky.

```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.Loop = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Vyberte snímky k zobrazení**

Vlastnost `SlideShowSettings.Slides` vám umožňuje vybrat rozsah snímků, které se mají během prezentace zobrazit. To je užitečné, když potřebujete zobrazit jen část prezentace místo všech snímků. Níže uvedený příklad kódu vytvoří novou prezentaci a nastaví rozsah snímků k zobrazení od snímku `2` do `9`.

```cs
using var presentation = new Presentation();

var slideRange = new SlidesRange 
{
    Start = 2,
    End = 9
};

presentation.SlideShowSettings.Slides = slideRange;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Použít časování snímků**

Vlastnost `SlideShowSettings.UseTimings` umožňuje povolit nebo zakázat použití předdefinovaného časování pro každý snímek. To je užitečné pro automatické zobrazování snímků s předem nastavenou dobou zobrazení. Níže uvedený příklad kódu vytvoří novou prezentaci a zakáže použití časování.

```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.UseTimings = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Zobrazit ovládací prvky multimédií**

Vlastnost `SlideShowSettings.ShowMediaControls` určuje, zda se během prezentace mají zobrazovat ovládací prvky multimédií (např. přehrát, pozastavit a zastavit) při přehrávání multimediálního obsahu (např. videa nebo audia). To je užitečné, pokud chcete, aby přednášející měl během prezentace kontrolu nad přehráváním médií.

Níže uvedený příklad kódu vytvoří novou prezentaci a povolí zobrazení ovládacích prvků multimédií.

```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.ShowMediaControls = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Často kladené otázky**

**Mohu uložit prezentaci tak, aby se po otevření rovnou spustila v režimu prezentace?**

Ano. Soubor uložte jako PPSX nebo PPSM; tyto formáty se po otevření v PowerPointu okamžitě spustí v režimu prezentace. V Aspose.Slides zvolte odpovídající formát uložení [během exportu](/slides/cs/net/save-presentation/).

**Mohu vyloučit jednotlivé snímky z prezentace, aniž bych je smazal ze souboru?**

Ano. Označte snímek jako [Hidden](https://reference.aspose.com/slides/cs/net/aspose.slides/slide/hidden/). Skryté snímky zůstávají v prezentaci, ale nejsou zobrazovány během prezentace.

**Dokáže Aspose.Slides přehrát prezentaci nebo řídit živou prezentaci na obrazovce?**

Ne. Aspose.Slides upravuje, analyzuje a převádí soubory prezentací; skutečné přehrávání zajišťuje prohlížeč, například PowerPoint.