---
title: Animovat text v PowerPointu v Pythonu
linktitle: Animovaný text
type: docs
weight: 60
url: /cs/python-net/animated-text/
keywords:
- animovaný text
- animace textu
- animovaný odstavec
- animace odstavce
- efekt animace
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Vytvořte dynamický animovaný text v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Python prostřednictvím .NET, s snadno sledovatelnými, optimalizovanými ukázkovými kódy."
---
## **Přehled**

Článek ukazuje, jak animovat text v prezentacích PowerPoint pomocí Aspose.Slides pro Python. Naučíte se přidávat efekty k jednotlivým odstavcům, upravovat spouštěče a číst existující animační sekvence. Na konci budete schopni vytvořit znovupoužitelné pracovní postupy pro animaci textu, které exportují do standardního PPTX a správně se přehrávají v PowerPointu.

## **Přidání animačních efektů odstavce**

Metoda [add_effect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/sequence/add_effect/) třídy [Sequence](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/sequence/) vám umožňuje použít animační efekt na jediný odstavec. Níže uvedený ukázkový kód demonstruje, jak to provést:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    # Vyberte odstavec, ke kterému chcete přidat efekt.
    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Přidejte efekt Fly k vybranému odstavci.
    effect = slide.timeline.main_sequence.add_effect(paragraph,
                                                     slides.animation.EffectType.FLY,
                                                     slides.animation.EffectSubtype.LEFT,
                                                     slides.animation.EffectTriggerType.ON_CLICK)
    presentation.save("ParagraphAnimationEffect.pptx", slides.export.SaveFormat.PPTX)
```

## **Získání animačních efektů odstavce**

Možná budete chtít zjistit, jaké animační efekty jsou použity na odstavci – například pokud chcete tyto efekty zkopírovat do jiného odstavce nebo tvaru.

Aspose.Slides pro Python vám umožňuje získat všechny animační efekty použité na odstavcích v textovém rámečku (tvaru). Následující ukázkový kód ukazuje, jak získat animační efekty odstavce:

```py
import aspose.slides as slides

with slides.Presentation("ParagraphAnimationEffect.pptx") as presentation:
    slide = presentation.slides[0]
    sequence = slide.timeline.main_sequence
    auto_shape = slide.shapes[0]

    for paragraph in auto_shape.text_frame.paragraphs:
        effects = sequence.get_effects_by_paragraph(paragraph)
        if len(effects) > 0:
            print(f"Paragraph \"{paragraph.text}\" has the first animation effect of type {str(effects[0].type)}.")
```

## **Často kladené otázky**

**Jak se animační efekty textu liší od přechodů mezi slidemi a lze je kombinovat?**

Animační efekty textu řídí chování objektu v průběhu času na slidu, zatímco [transitions](/slides/cs/python-net/slide-transition/) řídí způsob, jakým se slidy mění. Jsou nezávislé a lze je použít společně; pořadí přehrávání je řízeno časovou osou animace a nastavením přechodu.

**Zůstávají animační efekty textu při exportu do PDF nebo obrázků?**

Ne. PDF a rastrové obrázky jsou statické, takže uvidíte jediný stav slidu bez pohybu. Pro zachování pohybu použijte export do [video](/slides/cs/python-net/convert-powerpoint-to-video/) nebo [HTML](/slides/cs/python-net/export-to-html5/).

**Fungují animační efekty textu v rozvrženích a hlavním snímku (masteru)?**

Efekty aplikované na objekty rozvržení/masteru jsou děděny slidy, ale jejich načasování a interakce s animacemi na úrovni slidu závisí na konečné sekvenci na slidu.