---
title: Změna velikosti tvarů v prezentacích pomocí Pythonu
linktitle: Změna velikosti tvarů
type: docs
weight: 130
url: /cs/python-net/re-sizing-shapes-on-slide/
keywords:
- změna velikosti tvaru
- změna rozměrů tvaru
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Jednoduše změňte velikost tvarů na slidech PowerPoint a OpenDocument pomocí Aspose.Slides pro Python přes .NET—automatizujte úpravy rozvržení snímků a zvýšte produktivitu."
---
## **Přehled**

Jedna z nejčastějších otázek zákazníků Aspose.Slides pro Python je, jak změnit velikost tvarů tak, aby při změně velikosti snímku nebyla data oříznuta. Tento krátký technický článek ukazuje, jak to provést.

## **Změna velikosti tvarů**

Aby se zabránilo nesouladu tvarů při změně velikosti snímku, aktualizujte pozici a rozměry každého tvaru tak, aby odpovídaly novému rozvržení snímku.

```py
import aspose.slides as slides

# Načíst soubor prezentace.
with slides.Presentation("sample.pptx") as presentation:
    # Získat původní velikost snímku.
    current_height = presentation.slide_size.size.height
    current_width = presentation.slide_size.size.width

    # Změnit velikost snímku bez škálování existujících tvarů.
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    # Získat novou velikost snímku.
    new_height = presentation.slide_size.size.height
    new_width = presentation.slide_size.size.width

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    # Změnit velikost a přemístit tvary na každém snímku.
    for slide in presentation.slides:
        for shape in slide.shapes:
            # Změnit velikost tvaru.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # Změnit pozici tvaru.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 
Pokud snímek obsahuje tabulku, výše uvedený kód nebude fungovat správně. V takovém případě je nutné změnit velikost každé buňky v tabulce.
{{% /alert %}} 

Použijte následující kód k úpravě velikosti snímků, které obsahují tabulky. Pro tabulky je nastavení šířky nebo výšky zvláštní případ: musíte upravit výšky jednotlivých řádků a šířky sloupců, aby se změnila celková velikost tabulky.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Získat původní velikost snímku.
    current_height = presentation.slide_size.size.height
    current_width = presentation.slide_size.size.width

    # Změnit velikost snímku bez škálování existujících tvarů.
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    # Získat novou velikost snímku.
    new_height = presentation.slide_size.size.height
    new_width = presentation.slide_size.size.width

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    for master in presentation.masters:
        for shape in master.shapes:
            # Změnit velikost tvaru.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # Změnit pozici tvaru.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

        for layout_slide in master.layout_slides:
            for shape in layout_slide.shapes:
                # Změnit velikost tvaru.
                shape.height = shape.height * height_ratio
                shape.width = shape.width * width_ratio

                # Změnit pozici tvaru.
                shape.y = shape.y * height_ratio
                shape.x = shape.x * width_ratio

    for slide in presentation.slides:
        for shape in slide.shapes:
            # Změnit velikost tvaru.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # Změnit pozici tvaru.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

            if type(shape) is slides.Table:
                for row in shape.rows:
                    row.minimal_height = row.minimal_height * height_ratio
                for column in shape.columns:
                    column.width = column.width * width_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Často kladené otázky**

**Proč jsou tvary po změně velikosti snímku zkreslené nebo oříznuté?**

Při změně velikosti snímku si tvary zachovávají původní pozici a velikost, pokud není měřítko výslovně změněno. To může vést k ořezu obsahu nebo k nesouladu tvarů.

**Funguje poskytnutý kód pro všechny typy tvarů?**

Základní příklad funguje pro většinu typů tvarů (textboxy, obrázky, grafy atd.). U tabulek však musíte zpracovávat řádky a sloupce samostatně, protože výška a šířka tabulky jsou určeny rozměry jednotlivých buněk.

**Jak změním velikost tabulek při změně velikosti snímku?**

Je třeba projít všechny řádky a sloupce tabulky a proporčně upravit jejich výšku a šířku, jak je ukázáno ve druhém příkladu kódu.

**Bude tato změna velikosti fungovat pro masterové snímky a rozložení snímků?**

Ano, ale měli byste také projít [Masterové snímky](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/masters/) a [Rozložení snímků](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/layout_slides/) a aplikovat stejnou logiku škálování na jejich tvary, aby byla zajištěna konzistence v celé prezentaci.

**Mohu změnit orientaci snímku (na výšku/na šířku) spolu se změnou velikosti?**

Ano. K změně orientace můžete použít [presentation.slide_size.orientation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/islidesize/orientation/). Ujistěte se, že logiku škálování nastavíte odpovídajícím způsobem, aby byl zachován rozvrh.

**Existuje limit velikosti snímku, kterou mohu nastavit?**

Aspose.Slides podporuje vlastní velikosti, ale velmi velké rozměry mohou ovlivnit výkon nebo kompatibilitu s některými verzemi PowerPointu.

**Jak mohu zabránit deformaci tvarů se zamknutým poměrem stran?**

Můžete před měřením zkontrolovat vlastnost `aspect_ratio_locked` tvaru. Pokud je zamknutá, upravte šířku nebo výšku proporčně místo individuálního škálování.