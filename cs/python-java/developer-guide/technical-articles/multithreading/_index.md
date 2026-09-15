---
title: Multithreading v Aspose.Slides pro Python přes Java
linktitle: Vícevláknové zpracování
type: docs
weight: 310
url: /cs/python-java/multithreading/
keywords:
- vícevláknové zpracování
- více vláken
- paralelní práce
- převod snímků
- snímky na obrázky
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Vícevláknové zpracování v Aspose.Slides pro Python přes Java zvyšuje výkon při zpracování PowerPoint a OpenDocument. Objevte osvědčené postupy pro efektivní pracovní postupy s prezentacemi."
---
## **Úvod**

I když je paralelní práce s prezentacemi možná (s výjimkou parsování, načítání a klonování) a obvykle funguje dobře, existuje malá šance na nesprávné výsledky při použití knihovny ve více vláknech.

Doporučujeme, abyste **ne** používali jedinou [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) instanci v multithreadovaném prostředí, protože to může vést k nepředvídatelným chybám nebo selháním, které nejsou snadno odhalitelné.

Není **bezpečné** načítat, ukládat a/nebo klonovat [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) instanci ve více vláknech. Takové operace **nejsou** podporovány. Pokud potřebujete provádět takové úkoly, musíte operace paralelizovat pomocí několika jednovláknových procesů – a každý z těchto procesů by měl používat vlastní instanci prezentace.

## **Převod snímků prezentace na obrázky paralelně**

Řekněme, že chceme převést všechny snímky z PowerPointové prezentace na PNG obrázky paralelně. Protože je nebezpečné používat jedinou [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) instanci ve více vláknech, rozdělíme snímky prezentace do samostatných prezentací a převádíme snímky na obrázky paralelně, přičemž každou prezentaci používáme v samostatném vláknu. Následující ukázkový kód ukazuje, jak to provést.

```python
from concurrent.futures import ThreadPoolExecutor

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, SlideSizeScaleType


input_file_path = "sample.pptx"
output_file_path_template = "slide_{}.png"
image_scale = 2.0


def convert_slide_to_image(slide_presentation, slide_number):
    try:
        slide = slide_presentation.getSlides().get_Item(0)
        image = slide.getImage(image_scale, image_scale)
        try:
            image_file_path = output_file_path_template.format(slide_number)
            image.save(image_file_path, ImageFormat.Png)
        finally:
            image.dispose()
    finally:
        slide_presentation.dispose()


presentation = Presentation(input_file_path)
try:
    slide_count = presentation.getSlides().size()
    slide_size = presentation.getSlideSize().getSize()
    slide_width = jpype.JFloat(slide_size.getWidth())
    slide_height = jpype.JFloat(slide_size.getHeight())

    with ThreadPoolExecutor() as executor:
        conversion_tasks = []
        for slide_index in range(slide_count):
            # Extrahujte snímek do samostatné prezentace.
            slide_presentation = Presentation()
            slide_presentation.getSlideSize().setSize(slide_width, slide_height, SlideSizeScaleType.DoNotScale)
            slide_presentation.getSlides().removeAt(0)
            slide_presentation.getSlides().addClone(presentation.getSlides().get_Item(slide_index))

            # Převeďte snímek na obrázek v samostatném úkolu.
            slide_number = slide_index + 1
            conversion_task = executor.submit(convert_slide_to_image, slide_presentation, slide_number)
            conversion_tasks.append(conversion_task)

        # Počkejte na dokončení všech úkolů.
        for conversion_task in conversion_tasks:
            conversion_task.result()
finally:
    presentation.dispose()
```

## **Často kladené otázky**

**Potřebuji volat nastavení licence v každém vlákně?**

Ne. Stačí to provést jednou na proces před spuštěním vláken. Pokud by [license setup](/slides/cs/python-java/licensing/) mohl být volán souběžně (například během líné inicializace), synchronizujte tento volání, protože metoda nastavení licence není vlákny bezpečná.

**Mohu předávat objekty [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) nebo [Slide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/) mezi vlákny?**

Předávání „živých“ objektů prezentace mezi vlákny se nedoporučuje: použijte nezávislé instance na vlákno nebo vytvořte samostatné prezentace či kontejnery snímků pro každé vlákno předem. Tento přístup odpovídá obecné doporučení nesdílet jedinou instanci prezentace mezi vlákny.

**Je bezpečné paralelizovat export do různých formátů (PDF, HTML, obrázky), pokud má každé vlákno vlastní instanci [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/)?**

Ano. Při použití nezávislých instancí a samostatných výstupních cest tyto úlohy obvykle fungují správně v paralelním režimu; vyhněte se sdíleným objektům prezentace a sdíleným I/O tokům.

**Co mám dělat s globálními nastaveními fontů (složky, náhrady) v multithreadování?**

Inicializujte všechna globální [font settings](/slides/cs/python-java/powerpoint-fonts/) před spuštěním vláken a během paralelní práce je neměňte. Tím se odstraní závody při přístupu ke sdíleným zdrojům fontů.