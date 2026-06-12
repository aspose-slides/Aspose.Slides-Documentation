---
title: Správa prezentace v Javě
linktitle: Prezentace
type: docs
weight: 90
url: /cs/java/manage-slide-show/
keywords:
- typ prezentace
- prezentováno přednášejícím
- prohlíženo jednotlivcem
- prohlíženo v kiosku
- možnosti prezentace
- neustálé opakování
- prezentace bez komentáře
- prezentace bez animace
- barva pera
- prezentovat snímky
- vlastní prezentace
- postupovat snímky
- ručně
- s použitím časování
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Zjistěte, jak spravovat prezentace v Aspose.Slides pro Javu. Ovládejte přechody snímků, časování a další funkce v formátech PPT, PPTX a ODP s lehkostí."
---
## **Úvod**

V Microsoft PowerPoint jsou nastavení **Slide Show** klíčovým nástrojem pro přípravu a předkládání profesionálních prezentací. Jednou z nejdůležitějších funkcí v této sekci je **Set Up Show**, která vám umožní přizpůsobit prezentaci konkrétním podmínkám a publiku, což zajišťuje flexibilitu a pohodlí. S touto funkcí můžete vybrat typ prezentace (např. přednášená řečníkem, prohlížená jednotlivcem nebo prohlížená v kiosku), povolit nebo zakázat opakování, zvolit konkrétní snímky k zobrazení a použít časování. Tento krok v přípravě je zásadní pro zvýšení účinnosti a profesionality vaší prezentace.

`getSlideShowSettings` je metoda třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) , která vrací objekt typu [SlideShowSettings](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slideshowsettings/), umožňující spravovat nastavení prezentace v PowerPointu. V tomto článku se podíváme, jak tuto metodu použít k nastavení a řízení různých aspektů nastavení prezentace. 

## **Vybrat typ prezentace**

`SlideShowSettings.setSlideShowType` definuje typ prezentace, který může být instancí následujících tříd: [PresentedBySpeaker](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/cs/java/com.aspose.slides/browsedbyindividual/), nebo [BrowsedAtKiosk](https://reference.aspose.com/slides/cs/java/com.aspose.slides/browsedatkiosk/). Použití této metody vám umožní přizpůsobit prezentaci různým scénářům použití, jako jsou automatizované kiosky nebo ruční prezentace.

Níže uvedený příklad kódu vytvoří novou prezentaci a nastaví typ prezentace na „Browsed by an individual“ bez zobrazení posuvníku.

```java
Presentation presentation = new Presentation();

BrowsedByIndividual showType = new BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Povolení možností prezentace**

`SlideShowSettings.setLoop` určuje, zda se má prezentace opakovat v smyčce, dokud není ručně zastavena. To je užitečné pro automatizované prezentace, které musí běžet kontinuálně. `SlideShowSettings.setShowNarration` určuje, zda se mají během prezentace přehrávat hlasové komentáře. To je užitečné pro automatizované prezentace, které obsahují hlasové pokyny pro publikum. `SlideShowSettings.setShowAnimation` určuje, zda se mají přehrávat animace přidané k objektům snímku. To je užitečné pro zajištění plného vizuálního efektu prezentace.

Následující příklad kódu vytvoří novou prezentaci a bude prezentaci opakovat ve smyčce.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Výběr snímků k zobrazení**

Metoda `SlideShowSettings.setSlides` vám umožňuje vybrat rozsah snímků, které mají být během prezentace zobrazeny. To je užitečné, pokud potřebujete předvést jen část prezentace místo všech snímků. Níže uvedený příklad kódu vytvoří novou prezentaci a nastaví rozsah snímků k zobrazení od snímku `2` do `9`.

```java
Presentation presentation = new Presentation();

SlidesRange slideRange = new SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Použít časování snímků**

Metoda `SlideShowSettings.setUseTimings` vám umožňuje povolit nebo zakázat použití předdefinovaného časování pro každý snímek. To je užitečné pro automatické zobrazování snímků s předem určenou délkou zobrazení. Níže uvedený příklad kódu vytvoří novou prezentaci a zakáže použití časování.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Zobrazit ovládací prvky médií**

Metoda `SlideShowSettings.setShowMediaControls` určuje, zda se během prezentace mají zobrazovat ovládací prvky médií (například přehrát, pozastavit a zastavit), pokud je přehráván multimediální obsah (např. video nebo audio). To je užitečné, když chcete, aby prezentující měl kontrolu nad přehráváním médií během prezentace.

Následující příklad kódu vytvoří novou prezentaci a povolí zobrazení ovládacích prvků médií.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Často kladené otázky**

**Mohu uložit prezentaci tak, aby se po otevření rovnou spustila v režimu prezentace?**

Ano. Uložte soubor jako PPSX nebo PPSM; tyto formáty se po otevření v PowerPointu automaticky spustí v režimu prezentace. V Aspose.Slides zvolte odpovídající formát ukládání [během exportu](/slides/cs/java/save-presentation/).

**Mohu vyloučit jednotlivé snímky z prezentace, aniž bych je smazal ze souboru?**

Ano. Označte snímek jako [skrytý](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slide/#setHidden-boolean-). Skryté snímky zůstávají v prezentaci, ale nejsou zobrazovány během prezentace.

**Může Aspose.Slides přehrávat prezentaci nebo ovládat živou prezentaci na obrazovce?**

Ne. Aspose.Slides upravuje, analyzuje a převádí soubory prezentací; samotné přehrávání zajišťuje prohlížeč, například PowerPoint.