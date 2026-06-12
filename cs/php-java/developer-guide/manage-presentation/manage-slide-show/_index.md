---
title: Spravovat slideshow v PHP
linktitle: Slideshow
type: docs
weight: 90
url: /cs/php-java/manage-slide-show/
keywords:
- typ prezentace
- přednášený řečníkem
- prohlížený jednotlivcem
- prohlížený v kiosku
- možnosti představení
- nepřetržité opakování
- prezentace bez komentáře
- prezentace bez animace
- barva pera
- prezentovat snímky
- vlastní představení
- přechod na další snímky
- ručně
- s časováním
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Naučte se, jak spravovat slideshow v Aspose.Slides pro PHP prostřednictvím Javy. Ovládejte přechody snímků, časování a další funkce v formátech PPT, PPTX a ODP s lehkostí."
---
## **Úvod**

V Microsoft PowerPointu jsou nastavení **Slide Show** klíčovým nástrojem pro přípravu a předávání profesionálních prezentací. Jednou z nejdůležitějších funkcí v této sekci je **Set Up Show**, která vám umožní přizpůsobit prezentaci konkrétním podmínkám a publiku, čímž zajistí flexibilitu a pohodlí. S touto funkcí můžete vybrat typ představení (např. přednášený řečníkem, prohlížený jednotlivcem nebo prohlížený v kiosku), povolit nebo zakázat opakování, zvolit konkrétní snímky k zobrazení a použít časování. Tento krok v přípravě je zásadní pro zvýšení účinnosti a profesionality vaší prezentace.

`getSlideShowSettings` je metoda třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) , která vrací objekt typu [SlideShowSettings](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slideshowsettings/), což vám umožňuje spravovat nastavení slideshow v prezentaci PowerPoint. V tomto článku prozkoumáme, jak tuto metodu použít k nastavení a řízení různých aspektů nastavení slideshow. 

## **Vyberte typ představení**

`SlideShowSettings->setSlideShowType` určuje typ slideshow, který může být instancí jedné z následujících tříd: [PresentedBySpeaker](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/cs/php-java/aspose.slides/browsedbyindividual/), nebo [BrowsedAtKiosk](https://reference.aspose.com/slides/cs/php-java/aspose.slides/browsedatkiosk/). Použití této metody vám umožní přizpůsobit prezentaci různým scénářům použití, jako jsou automatizované kiosky nebo manuální prezentace.

Níže uvedený ukázkový kód vytvoří novou prezentaci a nastaví typ představení na „Browsed by an individual“ bez zobrazení posuvníku.

```php
$presentation = new Presentation();

$showType = new BrowsedByIndividual();
$showType->setShowScrollbar(false);

$presentation->getSlideShowSettings()->setSlideShowType($showType);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Povolit možnosti představení**

`SlideShowSettings->setLoop` určuje, zda se slideshow má opakovat v cyklu, dokud není ručně zastavena. To je užitečné pro automatizované prezentace, které musí běžet neustále. `SlideShowSettings->setShowNarration` určuje, zda se během slideshow přehrávají hlasové komentáře. To je užitečné pro automatizované prezentace, které obsahují hlasové vedení pro publikum. `SlideShowSettings->setShowAnimation` určuje, zda se přehrávají animace přidané k objektům snímků. To je užitečné pro poskytnutí plného vizuálního efektu prezentace.

Následující ukázkový kód vytvoří novou prezentaci a zapne opakování slideshow.

```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setLoop(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Vyberte snímky k zobrazení**

`SlideShowSettings->setSlides` metoda vám umožňuje vybrat rozsah snímků, které budou během prezentace zobrazeny. To je užitečné, když potřebujete zobrazit jen část prezentace místo všech snímků. Následující ukázkový kód vytvoří novou prezentaci a nastaví rozsah snímků k zobrazení od snímku `2` do `9`.

```php
$presentation = new Presentation();

$slideRange = new SlidesRange();
$slideRange->setStart(2);
$slideRange->setEnd(9);

$presentation->getSlideShowSettings()->setSlides($slideRange);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Použít automatické posouvání snímků**

`SlideShowSettings->setUseTimings` metoda vám umožňuje povolit nebo zakázat použití přednastavených časování pro každý snímek. To je užitečné pro automatické přehrávání snímků s předdefinovanou dobou zobrazení. Níže uvedený kód vytvoří novou prezentaci a zakáže použití časování.

```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setUseTimings(false);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Zobrazit ovládací prvky médií**

`SlideShowSettings->setShowMediaControls` metoda určuje, zda se během slideshow mají zobrazovat ovládací prvky médií (např. přehrát, pozastavit a zastavit), když se přehrává multimediální obsah (např. video nebo audio). To je užitečné, když chcete prezentujícímu poskytnout kontrolu nad přehráváním médií během prezentace.

Následující ukázkový kód vytvoří novou prezentaci a povolí zobrazení ovládacích prvků médií.

```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setShowMediaControls(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Často kladené otázky**

**Mohu uložit prezentaci tak, aby se po otevření rovnou spustila v režimu slideshow?**

Ano. Uložte soubor jako PPSX nebo PPSM; tyto formáty se po otevření v PowerPointu spustí přímo v režimu slideshow. V Aspose.Slides vyberte odpovídající formát ukládání [během exportu](/slides/cs/php-java/save-presentation/).

**Mohu vyloučit jednotlivé snímky z představení, aniž bych je mazal ze souboru?**

Ano. Označte snímek jako [skrytý](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slide/sethidden/). Skryté snímky zůstávají v prezentaci, ale nejsou během slideshow zobrazeny.

**Může Aspose.Slides přehrávat slideshow nebo ovládat živou prezentaci na obrazovce?**

Ne. Aspose.Slides upravuje, analyzuje a převádí soubory prezentací; samotné přehrávání zajišťuje zobrazovací aplikace, například PowerPoint.