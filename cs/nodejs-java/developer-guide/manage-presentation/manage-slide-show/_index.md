---
title: Správa prezentace v JavaScriptu
linktitle: Prezentace
type: docs
weight: 90
url: /cs/nodejs-java/manage-slide-show/
keywords:
- typ prezentace
- prezentováno řečníkem
- prohlíženo jednotlivcem
- prohlíženo na kiosku
- možnosti prezentace
- neustálé opakování
- prezentace bez komentáře
- prezentace bez animací
- barva pera
- zobrazit snímky
- vlastní prezentace
- posun snímků
- ručně
- s použitím časování
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Spravujte prezentace v JavaScriptu pomocí Aspose.Slides pro Node.js. Ovládejte přechody snímků, časování a další funkce napříč formáty PPT, PPTX a ODP s lehkostí."
---
## **Úvod**

V Microsoft PowerPoint jsou nastavení **Slide Show** klíčovým nástrojem pro přípravu a předkládání profesionálních prezentací. Jednou z nejdůležitějších funkcí v této sekci je **Set Up Show**, která vám umožňuje přizpůsobit prezentaci konkrétním podmínkám a publiku, což zajišťuje flexibilitu a pohodlí. S touto funkcí můžete vybrat typ prezentace (např. prezentováno řečníkem, prohlíženo jednotlivcem nebo na kiosku), povolit nebo zakázat opakování, vybrat konkrétní snímky k zobrazení a použít načasování. Tento krok v přípravě je zásadní pro zvýšení účinnosti a profesionality vaší prezentace.

`getSlideShowSettings` je metoda třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/), která vrací objekt typu [SlideShowSettings](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slideshowsettings/), umožňující spravovat nastavení prezentace v PowerPoint souboru. V tomto článku prozkoumáme, jak tuto metodu použít k konfiguraci a ovládání různých aspektů nastavení prezentace. 

## **Vybrat typ prezentace**

`SlideShowSettings.setSlideShowType` určuje typ prezentace, který může být instancí jedné z následujících tříd: [PresentedBySpeaker](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/browsedbyindividual/), nebo [BrowsedAtKiosk](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/browsedatkiosk/). Použitím této metody můžete přizpůsobit prezentaci různým scénářům použití, například automatickým kioskovým nebo ručním prezentacím.

Níže uvedený ukázkový kód vytvoří novou prezentaci a nastaví typ prezentace na „Browsed by an individual“ bez zobrazení posuvníku.

```js
var presentation = new asposeSlides.Presentation();

var showType = new asposeSlides.BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Povolit možnosti prezentace**

`SlideShowSettings.setLoop` určuje, zda se má prezentace opakovat v smyčce až do ručního zastavení. To je užitečné pro automatizované prezentace, které musí běžet nepřetržitě. `SlideShowSettings.setShowNarration` určuje, zda mají být během prezentace přehrávány hlasové komentáře. To je užitečné pro automatizované prezentace, které obsahují hlasové vedení pro publikum. `SlideShowSettings.setShowAnimation` určuje, zda mají být přehrávány animace přidané k objektům snímků. To je užitečné pro zajištění kompletního vizuálního efektu prezentace.

Níže uvedený ukázkový kód vytvoří novou prezentaci a nastaví opakování prezentace.

```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Vybrat snímky k zobrazení**

`SlideShowSettings.setSlides` metoda umožňuje vybrat rozsah snímků, které se mají během prezentace zobrazit. To je užitečné, když potřebujete zobrazit jen část prezentace místo všech snímků. Níže uvedený ukázkový kód vytvoří novou prezentaci a nastaví rozsah snímků k zobrazení od snímku `2` do `9`.

```js
var presentation = new asposeSlides.Presentation();

var slideRange = new asposeSlides.SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Použít časování snímků**

`SlideShowSettings.setUseTimings` metoda umožňuje povolit nebo zakázat použití přednastavených časových intervalů pro každý snímek. To je užitečné pro automatické zobrazování snímků s definovanou dobou zobrazení. Níže uvedený ukázkový kód vytvoří novou prezentaci a zakáže použití časování.

```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Zobrazit ovládací prvky média**

`SlideShowSettings.setShowMediaControls` metoda určuje, zda se během prezentace mají zobrazovat ovládací prvky média (např. přehrát, pozastavit, zastavit), když je přehráván multimediální obsah (např. video nebo audio). To je užitečné, pokud chcete prezentujícímu umožnit řídit přehrávání médií během prezentace.

Níže uvedený ukázkový kód vytvoří novou prezentaci a povolí zobrazení ovládacích prvků média.

```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Často kladené otázky**

**Mohu uložit prezentaci tak, aby se po otevření přímo spustila v režimu prezentace?**

Ano. Uložte soubor jako PPSX nebo PPSM; tyto formáty se po otevření v PowerPointu spustí přímo v režimu prezentace. V Aspose.Slides vyberte odpovídající formát uložení [během exportu](/slides/cs/nodejs-java/save-presentation/).

**Mohu vyloučit jednotlivé snímky ze prezentace, aniž bych je smazal ze souboru?**

Ano. Označte snímek jako [skrytý](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slide/sethidden/). Skryté snímky zůstávají v prezentaci, ale během prezentace se nezobrazují.

**Může Aspose.Slides přehrávat prezentaci nebo řídit živou prezentaci na obrazovce?**

Ne. Aspose.Slides upravuje, analyzuje a převádí soubory prezentací; samotné přehrávání zajišťuje aplikace pro prohlížení, například PowerPoint.