---
title: Správa promítání snímků v C++
linktitle: Promítání snímků
type: docs
weight: 90
url: /cs/cpp/manage-slide-show/
keywords:
- typ prezentace
- prezentováno řečníkem
- prohlíženo jednotlivcem
- prohlíženo v kiosk režimu
- možnosti prezentace
- neustálé opakování
- prezentace bez komentáře
- prezentace bez animace
- barva pera
- prezentovat snímky
- vlastní prezentace
- posunout snímky
- ručně
- použití časování
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Naučte se, jak spravovat promítání snímků v Aspose.Slides pro C++. Ovládejte přechody snímků, časování a další funkce napříč formáty PPT, PPTX a ODP s lehkostí."
---
## **Úvod**

V Microsoft PowerPoint jsou nastavení **Slide Show** klíčovým nástrojem pro přípravu a předkládání profesionálních prezentací. Jednou z nejužitečnějších funkcí v této sekci je **Set Up Show**, která vám umožňuje přizpůsobit prezentaci konkrétním podmínkám a publiku, což zajišťuje flexibilitu a pohodlí. Pomocí této funkce můžete vybrat typ předvedení (např. přednášený řečníkem, prohlížený jednotlivcem nebo prohlížený v kiosk režimu), povolit nebo zakázat opakování, zvolit konkrétní snímky k zobrazení a použít časování. Tento krok v přípravě je zásadní pro zvýšení účinnosti a profesionality vaší prezentace.

`get_SlideShowSettings` je metoda třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) , která vrací objekt typu [SlideShowSettings](https://reference.aspose.com/slides/cs/cpp/aspose.slides/slideshowsettings/), umožňující spravovat nastavení prezentace v PowerPointu. V tomto článku se podíváme, jak tuto metodu použít k nakonfigurování a řízení různých aspektů nastavení prezentace.

## **Vybrat typ prezentace**

`SlideShowSettings.set_SlideShowType` určuje typ prezentace, který může být instancí jedné z následujících tříd: [PresentedBySpeaker](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/cs/cpp/aspose.slides/browsedbyindividual/) nebo [BrowsedAtKiosk](https://reference.aspose.com/slides/cs/cpp/aspose.slides/browsedatkiosk/). Použitím této metody můžete přizpůsobit prezentaci různým scénářům použití, jako jsou automatické kiosky nebo ruční přednášky.

Níže uvedený ukázkový kód vytvoří novou prezentaci a nastaví typ předvedení na „Prohlížený jednotlivcem“ bez zobrazení posuvníku.

```cpp
auto presentation = MakeObject<Presentation>();

auto showType = MakeObject<BrowsedByIndividual>();
showType->set_ShowScrollbar(false);

presentation->get_SlideShowSettings()->set_SlideShowType(showType);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Povolit možnosti prezentace**

`SlideShowSettings.set_Loop` určuje, zda má prezentace opakovat v cyklu až do ručního zastavení. To je užitečné pro automatické prezentace, které musí běžet nepřetržitě. `SlideShowSettings.set_ShowNarration` určuje, zda se mají během prezentace přehrávat hlasové komentáře. To je vhodné pro automatické prezentace, které obsahují hlasové instrukce pro publikum. `SlideShowSettings.set_ShowAnimation` určuje, zda se mají přehrávat animace přidané k objektům snímku. To poskytuje plný vizuální efekt prezentace.

Následující ukázkový kód vytvoří novou prezentaci a zapne opakování prezentace.

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_Loop(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Vybrat snímky k zobrazení**

Metoda `SlideShowSettings.set_Slides` vám umožňuje vybrat rozsah snímků, které budou během prezentace zobrazeny. To je užitečné, když potřebujete předvést jen část prezentace místo všech snímků. Níže uvedený ukázkový kód vytvoří novou prezentaci a nastaví rozsah snímků k zobrazení od snímku `2` do `9`.

```cpp
auto presentation = MakeObject<Presentation>();

auto slideRange = MakeObject<SlidesRange>();
slideRange->set_Start(2);
slideRange->set_End(9);

presentation->get_SlideShowSettings()->set_Slides(slideRange);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Použít časování snímků**

Metoda `SlideShowSettings.set_UseTimings` umožňuje povolit nebo zakázat použití předdefinovaného časování pro každý snímek. To je užitečné pro automatické přehrávání snímků s předem nastavenou dobou zobrazení. Níže uvedený ukázkový kód vytvoří novou prezentaci a zakáže použití časování.

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_UseTimings(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Zobrazit ovládací prvky médií**

Metoda `SlideShowSettings.set_ShowMediaControls` určuje, zda se během prezentace mají zobrazovat ovládací prvky médií (jako přehrát, pozastavit a zastavit), když je přehráván multimediální obsah (např. video nebo audio). To je užitečné, pokud chcete, aby přednášející měl kontrolu nad přehráváním médií během prezentace.

Níže uvedený ukázkový kód vytvoří novou prezentaci a povolí zobrazení ovládacích prvků médií.

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_ShowMediaControls(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Mohu uložit prezentaci tak, aby se při otevření rovnou spustila v režimu prezentace?**

Ano. Uložte soubor jako PPSX nebo PPSM; tyto formáty se při otevření v PowerPointu spustí přímo v režimu prezentace. V Aspose.Slides zvolte odpovídající formát uložení [during export](/slides/cs/cpp/save-presentation/).

**Mohu vyloučit jednotlivé snímky z předvedení, aniž bych je smazal ze souboru?**

Ano. Označte snímek jako [hidden](https://reference.aspose.com/slides/cs/cpp/aspose.slides/slide/set_hidden/). Skryté snímky zůstávají v prezentaci, ale nejsou během prezentace zobrazovány.

**Může Aspose.Slides přehrávat prezentaci nebo řídit živé předvedení na obrazovce?**

Ne. Aspose.Slides upravuje, analyzuje a převádí soubory prezentací; samotné přehrávání zajišťuje aplikace pro prohlížení, jako je PowerPoint.