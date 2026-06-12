---
title: Vícevláknové zpracování v Aspose.Slides pro Python
linktitle: Vícevláknové
type: docs
weight: 200
url: /cs/python-net/multithreading/
keywords:
- vícevláknové
- více vláken
- paralelní práce
- převod snímků
- snímky na obrázky
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Aspose.Slides pro Python pomocí .NET vícevláknového zpracování zrychluje zpracování PowerPoint a OpenDocument. Objevte osvědčené postupy pro efektivní pracovní postupy s prezentacemi."
---
## **Úvod**

I když je paralelní práce s prezentacemi možná (kromě parsování/loading/cloning) a většinou vše funguje (většinou), existuje malá šance, že při použití knihovny ve více vláknech získáte nesprávné výsledky.

Důrazně doporučujeme **ne** používat jedinou [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) instanci v prostředí s více vlákny, protože to může vést k nepředvídatelným chybám nebo selháním, která není snadno detekovat.

Není **bezpečné** načítat, ukládat a/nebo klonovat instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) ve více vláknech. Takové operace **nejsou** podporovány.  Pokud potřebujete provádět takové úkoly, musíte operace paralelizovat pomocí několika jednovláknových procesů – a každý z těchto procesů by měl používat vlastní instanci prezentace. 

## **Převod snímků prezentace na obrázky paralelně**

Předpokládejme, že chceme převést všechny snímky z PowerPoint prezentace na PNG obrázky paralelně. Vzhledem k tomu, že je nebezpečné používat jedinou `Presentation` instanci ve více vláknech, rozdělíme snímky prezentace do samostatných prezentací a převedeme snímky na obrázky paralelně, přičemž každou prezentaci použijeme v samostatném vlákně. Následující ukázkový kód ukazuje, jak to provést.

```py
input_file_path = "sample.pptx"
output_file_path_template = "slide_{0}.png"
image_scale = 2

presentation = Presentation(input_file_path)

slide_count = len(presentation.slides)
slide_size = presentation.slide_size.size

conversion_tasks = []


def convert_slide(slide_index):
    # Extrahovat snímek i do samostatné prezentace.
    with Presentation() as slide_presentation:
        slide_presentation.slide_size.set_size(slide_size.width, slide_size.height, SlideSizeScaleType.DO_NOT_SCALE)
        slide_presentation.slides.remove_at(0)
        slide_presentation.slides.add_clone(presentation.slides[slide_index])

        slide_number = slide_index + 1
        slide = slide_presentation.slides[0]

        # Převést snímek na obrázek.
        with slide.get_image(image_scale, image_scale) as image:
            image_file_path = output_file_path_template.format(slide_number)
            image.save(image_file_path, ImageFormat.PNG)


with ThreadPoolExecutor() as thread_executor:
    for index in range(slide_count):
        conversion_tasks.append(thread_executor.submit(convert_slide, index))

# Počkat, až se všechny úlohy dokončí.
for task in conversion_tasks:
    task.result()

del presentation
```

## **Často kladené otázky**

**Musím volat nastavení licence v každém vláknu?**

Ne. Stačí to provést jednou na proces/aplikaci doménu před zahájením vláken. Pokud by [license setup](/slides/cs/python-net/licensing/) mohl být volán souběžně (například během líné inicializace), synchronizujte tento volání, protože metoda nastavení licence není vlákny bezpečná.

**Mohu předávat objekty `Presentation` nebo `Slide` mezi vlákny?**

Předávání „živých“ objektů prezentace mezi vlákny není doporučeno: použijte nezávislé instance na vlákno nebo předem vytvořte samostatné prezentace/kontejnery snímků pro každé vlákno. Tento přístup vychází z obecného doporučení nesdílet jedinou instanci prezentace napříč vlákny.

**Je bezpečné paralelizovat export do různých formátů (PDF, HTML, obrázky), pokud má každé vlákno vlastní `Presentation` instanci?**

Ano. S nezávislými instancemi a samostatnými výstupními cestami se takové úkoly obvykle paralelizují správně; vyhněte se sdíleným objektům prezentace a sdíleným I/O proudům.

**Co mám dělat s globálními nastaveními fontů (složky, substituce) ve vícenásobném vláknění?**

Inicializujte všechna globální nastavení fontů před spuštěním vláken a během paralelní práce je neměňte. Tím se eliminují závody při přístupu ke sdíleným fontovým zdrojům.