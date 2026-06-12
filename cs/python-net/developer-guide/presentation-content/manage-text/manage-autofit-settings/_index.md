---
title: Vylepšete své prezentace pomocí AutoFit v Pythonu
linktitle: Nastavení AutoFit
type: docs
weight: 30
url: /cs/python-net/manage-autofit-settings/
keywords:
- textové pole
- automatické přizpůsobení
- nepoužívat automatické přizpůsobení
- přizpůsobit text
- zmenšit text
- zalamovat text
- změnit velikost tvaru
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Zjistěte, jak spravovat nastavení AutoFit v Aspose.Slides pro Python via .NET, abyste optimalizovali zobrazení textu ve svých prezentacích PowerPoint a OpenDocument a zlepšili čitelnost obsahu."
---
## **Úvod**

Ve výchozím nastavení, když přidáte textové pole, Microsoft PowerPoint používá nastavení **Resize shape to fix text** pro textové pole – automaticky mění velikost textového pole, aby se jeho text vždy vešel do něj. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Když se text v textovém poli prodlouží nebo zvětší, PowerPoint automaticky zvětší textové pole – zvýší jeho výšku – aby pojmula více textu. 
* Když se text v textovém poli zkrátí nebo zmenší, PowerPoint automaticky zmenší textové pole – sníží jeho výšku – aby odstranil nadbytečný prostor. 

V PowerPointu jsou to 4 důležité parametry nebo možnosti, které řídí chování autofitu pro textové pole: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Python via .NET poskytuje podobné možnosti – některé vlastnosti ve třídě [TextFrameFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframeformat/) – které vám umožní řídit chování autofitu pro textová pole v prezentacích. 

## **Změna velikosti tvarů, aby se text vešel**

Pokud chcete, aby text v rámečku vždy zapadl do tohoto rámečku po změnách textu, musíte použít možnost **Resize shape to fix text**. Pro nastavení této volby nastavte vlastnost [autofit_type](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframeformat/) ze třídy [TextFrameFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframeformat/) na `SHAPE`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Tento Python kód ukazuje, jak nastavit, aby text vždy zapadal do svého rámečku v prezentaci PowerPoint:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Pokud se text prodlouží nebo zvětší, textové pole bude automaticky změněno (zvýší se výška), aby se do něj vešel celý text. Pokud se text zkrátí, nastane opak. 

## **Do Not Autofit**

Pokud chcete, aby textové pole nebo tvar zachovalo své rozměry bez ohledu na změny textu, který obsahuje, musíte použít možnost **Do not Autofit**. Pro nastavení této volby nastavte vlastnost [autofit_type](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframeformat/) ze třídy [TextFrameFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframeformat/) na `NONE`. 

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Tento Python kód ukazuje, jak nastavit, aby textové pole vždy zachovalo své rozměry v prezentaci PowerPoint:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NONE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Když se text stane příliš dlouhým pro svůj rámeček, přesune se mimo něj. 

## **Shrink Text on Overflow**

Pokud se text prodlouží tak, že přesáhne svojí oblast, pomocí možnosti **Shrink text on overflow** můžete určit, že velikost a rozestupy textu se zmenší, aby se vešel do svého rámečku. Pro nastavení této volby nastavte vlastnost [autofit_type](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframeformat/) ze třídy [TextFrameFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframeformat/) na `NORMAL`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Tento Python kód ukazuje, jak nastavit, aby se text při přetečení zmenšil v prezentaci PowerPoint:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NORMAL

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Info" color="info" %}}
Když je použita možnost **Shrink text on overflow**, nastavení se aplikuje pouze v případě, že je text příliš dlouhý pro svůj rámeček. 
{{% /alert %}}

## **Wrap Text**

Pokud chcete, aby se text v tvaru zalamoval uvnitř tohoto tvaru, když přesáhne jeho okraj (pouze šířka), musíte použít parametr **Wrap text in shape**. Pro nastavení této volby musíte nastavit vlastnost [wrap_text](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframeformat/) ze třídy [TextFrameFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframeformat/) na `NullableBool.TRUE`. 

Tento Python kód ukazuje, jak použít nastavení Zalamování textu v prezentaci PowerPoint:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame_format.wrap_text = slides.NullableBool.TRUE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Note" color="warning" %}} 
Pokud nastavíte vlastnost `wrap_text` na `NullableBool.FALSE` pro tvar, když se text uvnitř tvaru prodlouží přes jeho šířku, text se rozšíří za hranice tvaru v jedné řádce. 
{{% /alert %}}

## **FAQ**

**Ovlivňují vnitřní okraje textového rámce AutoFit?**

Ano. Padding (vnitřní okraje) snižuje použitelné místo pro text, takže AutoFit se aktivuje dříve – zmenšuje písmo nebo mění velikost tvaru dříve. Zkontrolujte a upravte okraje před laděním AutoFit.

**Jak AutoFit spolupracuje s ručními a měkkými konci řádků?**

Vynucené konce řádků zůstávají na místě a AutoFit upravuje velikost písma a rozestupy kolem nich. Odstranění zbytečných konců řádků často snižuje agresivitu, s jakou AutoFit musí text zmenšovat.

**Ovlivňuje změna písma motivu nebo spuštění náhrady písma výsledky AutoFit?**

Ano. Náhrada písma s jinými metrikami glyfů mění šířku/výšku textu, což může změnit finální velikost písma a zalamování řádků. Po jakékoli změně nebo náhradě písma znovu zkontrolujte snímky.