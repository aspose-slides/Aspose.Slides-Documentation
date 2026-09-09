---
title: Animovat text PowerPointu v Pythonu via Java
linktitle: Animovaný text
type: docs
weight: 60
url: /cs/python-java/animated-text/
keywords:
- animovaný text
- animace textu
- animovaný odstavec
- animace odstavce
- efekt animace
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Vytvořte dynamický animovaný text v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Python via Java, s snadno sledovatelnými, optimalizovanými ukázkami kódu v Pythonu."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s animovaným textem v Aspose.Slides aplikací animačních efektů na jednotlivé odstavce a získáním efektů již přiřazených odstavcům v textovém rámečku. Zaměřuje se na API metody používané k přidání animace na úrovni odstavce a k prohlédnutí existujících animačních efektů odstavců v prezentaci.

## **Přidání animačních efektů k odstavcům**

Metoda [addEffect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sequence/#addEffect) třídy [Sequence](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sequence/) umožňuje přidat animační efekt k jednomu odstavci. Tento ukázkový kód ukazuje, jak přidat animační efekt k jednomu odstavci:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

presentation = Presentation("Presentation.pptx")
try:
    # Vyberte odstavec, ke kterému chcete přidat efekt.
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Přidejte efekt animace Fly k vybranému odstavci.
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick)

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Získání animačních efektů odstavců**

Možná budete chtít získat animační efekty aplikované na odstavec – například pro aplikaci těchto efektů na jiný odstavec nebo tvar.

Aspose.Slides for Python via Java umožňuje získat všechny animační efekty aplikované na odstavce obsažené v textovém rámečku (tvaru). Tento ukázkový kód ukazuje, jak získat animační efekty aplikované na odstavec:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    sequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence()
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    for paragraph in auto_shape.getTextFrame().getParagraphs():
        effects = sequence.getEffectsByParagraph(paragraph)

        if len(effects) > 0:
            print(f'Paragraph "{paragraph.getText()}" has {effects[0].getType()} effect.')
finally:
    presentation.dispose()
```

## **FAQ**

**Jak se liší textové animace od přechodů snímků a lze je kombinovat?**

Textové animace řídí chování objektu v čase na snímku, zatímco [transitions](/slides/cs/python-java/slide-transition/) řídí, jak se mění snímky. Jsou nezávislé a lze je použít společně; pořadí přehrávání určuje časová osa animace a nastavení přechodu.

**Zůstávají textové animace zachovány při exportu do PDF nebo obrázků?**

Ne. PDF a rastrové obrázky jsou statické, takže uvidíte jediný stav snímku bez pohybu. Pro zachování pohybu použijte export do [video](/slides/cs/python-java/convert-powerpoint-to-video/) nebo [HTML](/slides/cs/python-java/export-to-html5/).

**Fungují textové animace v rozvrženích a v hlavním snímku?**

Efekty aplikované na objekty rozvržení/masteru jsou děděny snímky, ale jejich načasování a interakce s animacemi na úrovni snímku závisí na konečné sekvenci na snímku.