---
title: Správa promítání snímků v Pythonu
linktitle: Promítání snímků
type: docs
weight: 90
url: /cs/python-net/manage-slide-show/
keywords:
- typ prezentace
- prezentováno přednášejícím
- prohlíženo jednotlivcem
- prohlíženo v kiosku
- možnosti prezentace
- nepřetržité opakování
- prezentace bez komentáře
- prezentace bez animace
- barva pera
- zobrazit snímky
- vlastní prezentace
- postupovat po snímcích
- ručně
- použití časování
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Naučte se, jak spravovat promítání snímků v Aspose.Slides pro Python pomocí .NET. Ovládejte přechody snímků, časování a další funkce v formátech PPT, PPTX a ODP s lehkostí."
---
## **Úvod**

V aplikaci Microsoft PowerPoint jsou nastavení **Slide Show** klíčovým nástrojem pro přípravu a předkládání profesionálních prezentací. Jednou z nejdůležitějších funkcí v této sekci je **Set Up Show**, která vám umožní přizpůsobit vaši prezentaci konkrétním podmínkám a publiku, což zajišťuje flexibilitu a pohodlí. Cí tímto nástrojem můžete vybrat typ předvádění (např. předváděno přednášejícím, prohlíženo jednotlivcem nebo v kiosku), povolit nebo zakázat opakování smyčkou, zvolit konkrétní snímky k zobrazení a použít časování. Tento krok v přípravě je zásadní pro zvýšení efektivity a profesionality vaší prezentace.

`slide_show_settings` je vlastnost třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) typu [SlideShowSettings](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slideshowsettings/), která vám umožňuje spravovat nastavení prezentace v PowerPointu. V tomto článku se podíváme, jak tuto vlastnost použít k nastavení a řízení různých aspektů nastavení prezentace.

## **Výběr typu předvádění**

`SlideShowSettings.slide_show_type` určuje typ prezentace, který může být instancí jedné z následujících tříd: [PresentedBySpeaker](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/cs/python-net/aspose.slides/browsedbyindividual/), nebo [BrowsedAtKiosk](https://reference.aspose.com/slides/cs/python-net/aspose.slides/browsedatkiosk/). Použití této vlastnosti vám umožní přizpůsobit prezentaci různým scénářům použití, jako jsou automatizované kiosky nebo ruční předvádění.

Níže uvedený příklad kódu vytvoří novou prezentaci a nastaví typ předvádění na “Browsed by an individual” bez zobrazení posuvníku.

```py
with slides.Presentation() as presentation:

    show_type = slides.BrowsedByIndividual()
    show_type.show_scrollbar = False

    presentation.slide_show_settings.slide_show_type = show_type

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Povolení možností předvádění**

`SlideShowSettings.loop` určuje, zda se prezentace má opakovat ve smyčce, dokud není ručně zastavena. To je užitečné pro automatizované prezentace, které musí běžet nepřetržitě. `SlideShowSettings.show_narration` určuje, zda se během prezentace mají přehrávat hlasové komentáře. To je užitečné pro automatizované prezentace, které obsahují hlasové vedení pro publikum. `SlideShowSettings.show_animation` určuje, zda se mají přehrávat animace přidané k objektům snímků. To je užitečné pro zajištění plného vizuálního efektu prezentace.

Následující příklad kódu vytvoří novou prezentaci a zapne opakování prezentace ve smyčce.

```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.loop = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Výběr snímků k zobrazení**

Vlastnost `SlideShowSettings.slides` vám umožňuje vybrat rozsah snímků, které se mají během prezentace zobrazit. To je užitečné, když potřebujete ukázat jen část prezentace místo všech snímků. Následující příklad kódu vytvoří novou prezentaci a nastaví rozsah snímků k zobrazení od snímku `2` do `9`.

```py
with slides.Presentation() as presentation:
    
    slide_range = slides.SlidesRange()
    slide_range.start = 2
    slide_range.end = 9

    presentation.slide_show_settings.slides = slide_range

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Použití časování snímků**

Vlastnost `SlideShowSettings.use_timings` umožňuje povolit nebo zakázat použití předdefinovaných časování pro jednotlivé snímky. To je užitečné pro automatické přehrávání snímků s předem nastavenou dobou zobrazení. Níže uvedený příklad kódu vytvoří novou prezentaci a zakáže používání časování.

```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.use_timings = False

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Zobrazení ovládacích prvků médií**

Vlastnost `SlideShowSettings.show_media_controls` určující, zda se během prezentace mají zobrazovat ovládací prvky médií (např. přehrát, pozastavit a zastavit), když je přehráván multimediální obsah (např. video nebo audio). To je užitečné, když chcete poskytnout prezentujícímu kontrolu nad přehráváním médií během prezentace.

Následující příklad kódu vytvoří novou prezentaci a povolí zobrazení ovládacích prvků médií.

```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.show_media_controls = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Mohu uložit prezentaci tak, aby se otevřela přímo v režimu prezentace?**

Ano. Uložte soubor jako PPSX nebo PPSM; tyto formáty se při otevření v PowerPointu spustí přímo v režimu prezentace. V Aspose.Slides zvolte odpovídající formát ukládání [během exportu](/slides/cs/python-net/save-presentation/).

**Mohu vyloučit jednotlivé snímky z prezentace bez jejich smazání ze souboru?**

Ano. Označte snímek jako [hidden](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/hidden/). Skryté snímky zůstávají v prezentaci, ale nejsou během prezentace zobrazeny.

**Může Aspose.Slides přehrávat prezentaci nebo ovládat živou prezentaci na obrazovce?**

Ne. Aspose.Slides upravuje, analyzuje a převádí soubory prezentací; samotné přehrávání zajišťuje prohlížeč, například PowerPoint.