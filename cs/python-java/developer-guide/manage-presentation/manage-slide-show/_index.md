---
title: Správa prezentací v Pythonu přes Java
linktitle: Prezentace
type: docs
weight: 90
url: /cs/python-java/manage-slide-show/
keywords:
- typ prezentace
- prezentováno přednášejícím
- prohlíženo jednotlivcem
- prohlíženo v kiosku
- možnosti prezentace
- opakovat nepřetržitě
- bez vyprávění
- bez animace
- barva pera
- zobrazit snímky
- vlastní prezentace
- posunout snímky
- ručně
- s časováním
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Naučte se, jak spravovat prezentace v Aspose.Slides pro Python přes Java. Ovládejte přechody snímků, časování a další možnosti v formátech PPT, PPTX a ODP s lehkostí."
---
## **Úvod**

Možnosti **Set Up Show** v Microsoft PowerPoint vám umožňují vybrat typ prezentace, povolit opakování, vybrat snímky a řídit, jak se snímky posunují. S Aspose.Slides for Python via Java můžete tyto možnosti konfigurovat programově a uložit je do souboru prezentace.

Metoda [Presentation.getSlideShowSettings](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getSlideShowSettings) vrací objekt [SlideShowSettings](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slideshowsettings/) , který tyto možnosti řídí. Níže uvedené příklady vyžadují Aspose.Slides for Python via Java a kompatibilní runtime Java. Každý příklad spustí JVM, pokud je to potřeba, a po dokončení uvolní prezentaci.

## **Vyberte typ prezentace**

[SlideShowSettings.setSlideShowType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slideshowsettings/#setSlideShowType) definuje typ prezentace, který může být instancí jedné z následujících tříd: [PresentedBySpeaker](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/cs/python-java/aspose.slides/browsedbyindividual/) nebo [BrowsedAtKiosk](https://reference.aspose.com/slides/cs/python-java/aspose.slides/browsedatkiosk/). Použitím této metody můžete prezentaci přizpůsobit různým scénářům použití, například automatizovaným kioskom nebo ručním prezentacím.

Níže uvedený ukázkový kód vytvoří novou prezentaci a nastaví typ prezentace na „Browsed by an individual“ bez zobrazení posuvníku.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, BrowsedByIndividual

presentation = Presentation()
try:
    show_type = BrowsedByIndividual()
    show_type.setShowScrollbar(False)
    presentation.getSlideShowSettings().setSlideShowType(show_type)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Povolit možnosti prezentace**

[SlideShowSettings.setLoop](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slideshowsettings/#setLoop) určuje, zda se má prezentace opakovat v nekonečné smyčce, dokud není ručně zastavena. To je užitečné pro automatizované prezentace, které mají běžet kontinuálně. [SlideShowSettings.setShowNarration](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slideshowsettings/#setShowNarration) určuje, zda mají být během prezentace přehrávány hlasové výklady. To je užitečné pro automatizované prezentace, které obsahují hlasové vedení pro publikum. [SlideShowSettings.setShowAnimation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slideshowsettings/#setShowAnimation) určuje, zda mají být přehrány animace přidané k objektům snímku. To je užitečné pro zajištění plného vizuálního efektu prezentace.

Následující ukázkový kód vytvoří novou prezentaci a nastaví opakování prezentace.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setLoop(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Vyberte snímky k zobrazení**

Metoda [SlideShowSettings.setSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slideshowsettings/#setSlides) vám umožňuje vybrat rozsah snímků, které budou během prezentace zobrazeny. To je užitečné, když potřebujete zobrazit jen část prezentace místo všech snímků. Následující ukázkový kód vytvoří prezentaci s devíti snímky a vybere snímky 2 až 9. Rozsah používá číslování snímků od jedné.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlidesRange

presentation = Presentation()
try:
    # Vytvořte devět snímků, aby vybraný rozsah existoval.
    first_slide = presentation.getSlides().get_Item(0)
    for _ in range(8):
        presentation.getSlides().addClone(first_slide)

    slide_range = SlidesRange()
    slide_range.setStart(2)
    slide_range.setEnd(9)
    presentation.getSlideShowSettings().setSlides(slide_range)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Řízení postupu snímků**

Metoda [SlideShowSettings.setUseTimings](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slideshowsettings/#setUseTimings) umožňuje povolit nebo zakázat použití přednastavených časování pro každý snímek. To je užitečné pro automatické zobrazování snímků s předdefinovanou dobou zobrazení. Níže uvedený ukázkový kód vytvoří novou prezentaci a zakáže použití časování.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setUseTimings(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zobrazit ovládací prvky médií**

Metoda [SlideShowSettings.setShowMediaControls](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slideshowsettings/#setShowMediaControls) určuje, zda mají být během prezentace zobrazeny ovládací prvky médií (např. přehrát, pozastavit, zastavit), když se přehrává multimediální obsah (např. video nebo audio). To je užitečné, pokud chcete presenterovi poskytnout kontrolu nad přehráváním médií během prezentace.

Následující ukázkový kód vytvoří novou prezentaci a povolí zobrazení ovládacích prvků médií.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setShowMediaControls(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Často kladené otázky**

**Mohu uložit prezentaci tak, aby se po otevření rovnou spustila v režimu prezentace?**

Ano. Uložte soubor jako PPSX nebo PPSM; tyto formáty se po otevření v PowerPointu spustí přímo v režimu prezentace. V Aspose.Slides vyberte odpovídající formát uložení [během exportu](/slides/cs/python-java/save-presentation/).

**Mohu vyloučit jednotlivé snímky z prezentace, aniž bych je smazal ze souboru?**

Ano. Označte snímek jako [hidden](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/#setHidden). Skryté snímky zůstávají v prezentaci, ale nejsou zobrazovány během prezentace.

**Může Aspose.Slides přehrávat prezentaci nebo ovládat živou prezentaci na obrazovce?**

Ne. Aspose.Slides upravuje, analyzuje a konvertuje soubory prezentací; samotné přehrávání zajišťuje prohlížeč, například PowerPoint.