---  
title: Správa prezentace na Androidu  
linktitle: Promítání  
type: docs  
weight: 90  
url: /cs/androidjava/manage-slide-show/  
keywords:  
- typ prezentace  
- prezentováno přednášejícím  
- prohlíženo jednotlivcem  
- prohlíženo v kiosku  
- možnosti prezentace  
- neustálé opakování  
- prezentace bez výkladu  
- prezentace bez animace  
- barva pera  
- zobrazit snímky  
- vlastní prezentace  
- postupovat snímky  
- ručně  
- s použitím časování  
- PowerPoint  
- OpenDocument  
- prezentace  
- Android  
- Java  
- Aspose.Slides  
description: "Naučte se, jak spravovat prezentace v Aspose.Slides pro Android pomocí Javy. Ovládejte přechody snímků, časování a další funkce v formátech PPT, PPTX a ODP s lehkostí."  
---
## **Úvod**

V Microsoft PowerPoint jsou nastavení **Slide Show** klíčovým nástrojem pro přípravu a předkládání profesionálních prezentací. Jednou z nejdůležitějších funkcí v této sekci je **Set Up Show**, která vám umožní přizpůsobit prezentaci konkrétním podmínkám a publiku, čímž zajišťuje flexibilitu a pohodlí. S touto funkcí můžete vybrat typ prezentace (např. přednášena řečníkem, prohlížena jednotlivcem nebo v kiosku), povolit nebo zakázat opakování, vybrat konkrétní snímky k zobrazení a použít časování. Tento krok v přípravě je zásadní pro zvýšení efektivity a profesionality vaší prezentace.

`getSlideShowSettings` je metoda třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) , která vrací objekt typu [SlideShowSettings](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slideshowsettings/), což umožňuje spravovat nastavení prezentace v PowerPointu. V tomto článku prozkoumáme, jak tuto metodu použít k nastavení a řízení různých aspektů nastavení prezentace.

## **Vybrat typ prezentace**

`SlideShowSettings.setSlideShowType` určuje typ prezentace, který může být instancí jedné z následujících tříd: [PresentedBySpeaker](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/browsedbyindividual/), nebo [BrowsedAtKiosk](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/browsedatkiosk/). Použitím této metody můžete přizpůsobit prezentaci různým scénářům použití, například automatizovaným kioskům nebo manuálním prezentacím.

Níže uvedený příklad kódu vytvoří novou prezentaci a nastaví typ prezentace na „Browsed by an individual“ bez zobrazení posuvníku.

```java
Presentation presentation = new Presentation();

BrowsedByIndividual showType = new BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Povolit možnosti prezentace**

`SlideShowSettings.setLoop` určuje, zda se prezentace má opakovat v nekonečné smyčce, dokud není ručně zastavena. To je užitečné pro automatizované prezentace, které mají běžet nepřetržitě. `SlideShowSettings.setShowNarration` určuje, zda se během prezentace mají přehrávat hlasové výklady. To je užitečné pro automatizované prezentace obsahující hlasové pokyny pro publikum. `SlideShowSettings.setShowAnimation` určuje, zda se mají přehrávat animace přidané k objektům snímků. To je užitečné pro plné vizuální efekty prezentace.

Následující příklad kódu vytvoří novou prezentaci a nastaví opakování prezentace.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Vybrat snímky k zobrazení**

Metoda `SlideShowSettings.setSlides` vám umožňuje vybrat rozsah snímků, které se mají během prezentace zobrazit. To je užitečné, když chcete zobrazit jen část prezentace místo všech snímků. Níže uvedený příklad kódu vytvoří novou prezentaci a nastaví rozsah snímků k zobrazení od snímku `2` do `9`.

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

Metoda `SlideShowSettings.setUseTimings` umožňuje povolit nebo zakázat použití předdefinovaných časových intervalů pro každý snímek. To je užitečné pro automatické přehrávání snímků s předem nastavenou délkou zobrazení. Níže uvedený příklad kódu vytvoří novou prezentaci a zakáže použití časování.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Zobrazit ovládací prvky médií**

Metoda `SlideShowSettings.setShowMediaControls` určuje, zda se během prezentace mají zobrazovat ovládací prvky médií (např. přehrát, pozastavit a zastavit), když je přehráván multimediální obsah (např. video nebo audio). To je užitečné, pokud chcete dát přednášejícímu kontrolu nad přehráváním médií během prezentace.

Následující příklad kódu vytvoří novou prezentaci a povolí zobrazení ovládacích prvků médií.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Často kladené otázky**

**Mohu uložit prezentaci tak, aby se po otevření rovnou spustila v režimu prezentace?**

Ano. Uložte soubor jako PPSX nebo PPSM; tyto formáty se po otevření v PowerPointu spustí přímo v režimu prezentace. V Aspose.Slides zvolte odpovídající formát uložení [během exportu](/slides/cs/androidjava/save-presentation/).

**Mohu vyloučit jednotlivé snímky z prezentace, aniž bych je smazal ze souboru?**

Ano. Označte snímek jako [hidden](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slide/#setHidden-boolean-). Skryté snímky zůstávají v prezentaci, ale nejsou zobrazovány během prezentace.

**Může Aspose.Slides přehrávat prezentaci nebo ovládat živou přednášku na obrazovce?**

Ne. Aspose.Slides upravuje, analyzuje a převádí soubory prezentací; samotné přehrávání zajišťuje zobrazovací aplikace, například PowerPoint.