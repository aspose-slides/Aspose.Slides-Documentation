---
title: Pokročilé extrahování textu z prezentací v Pythonu
linktitle: Extrahovat text
type: docs
weight: 90
url: /cs/python-net/extract-text-from-presentation/
keywords:
- extrahovat text
- extrahovat text ze snímku
- extrahovat text z prezentace
- extrahovat text z PowerPointu
- extrahovat text z OpenDocument
- extrahovat text z PPT
- extrahovat text z PPTX
- extrahovat text z ODP
- získat text
- získat text ze snímku
- získat text z prezentace
- získat text z PowerPointu
- získat text z OpenDocument
- získat text z PPT
- získat text z PPTX
- získat text z ODP
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Rychle extrahujte text z prezentací PowerPoint a OpenDocument pomocí Aspose.Slides for Python via .NET. Postupujte podle našeho jednoduchého, krok za krokem průvodce a ušetřete čas."
---
## **Přehled**

Extrahování textu z prezentací je běžná, ale zároveň zásadní úloha pro vývojáře pracující s obsahem snímků. Ať už pracujete se soubory Microsoft PowerPoint ve formátu PPT nebo PPTX, nebo s OpenDocument prezentacemi (ODP), přístup k textovým datům může být klíčový pro analýzu, automatizaci, indexování či migraci obsahu.

Tento článek poskytuje komplexní návod, jak efektivně extrahovat text z různých formátů prezentací, včetně PPT, PPTX a ODP, pomocí Aspose.Slides for Python via .NET. Naučíte se systematicky procházet prvky prezentace a přesně získat požadovaný textový obsah.

## **Extrahování textu ze snímku**

Aspose.Slides for Python via .NET poskytuje jmenný prostor [aspose.slides.util](https://reference.aspose.com/slides/cs/python-net/aspose.slides.util/), který obsahuje třídu [SlideUtil](https://reference.aspose.com/slides/cs/python-net/aspose.slides.util/slideutil/). Tato třída vystavuje několik přetížených statických metod pro extrahování veškerého textu z prezentace nebo ze snímku. Pro extrahování textu ze snímku v prezentaci použijte metodu [get_all_text_boxes](https://reference.aspose.com/slides/cs/python-net/aspose.slides.util/slideutil/get_all_text_boxes/). Tato metoda přijímá jako parametr objekt typu [BaseSlide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/baseslide/). Při provedení metoda prohledá celý snímek a vrátí pole objektů typu [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/), přičemž zachová veškeré formátování textu.

Následující úryvek kódu extrahuje veškerý text z prvního snímku prezentace:

```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[slide_index]

    text_frames = slides.util.SlideUtil.get_all_text_boxes(slide)

    for text_frame in text_frames:
        for paragraph in text_frame.paragraphs:
            for portion in paragraph.portions:
                portion_text = portion.text
                print(portion_text)

                portion_format = portion.portion_format
                font_height = portion_format.font_height
                print(font_height)

                latin_font = portion_format.latin_font
                if latin_font is not None:
                    font_name = latin_font.font_name
                    print(font_name)
```

## **Extrahování textu z celé prezentace**

Pro skenování textu v celé prezentaci použijte statickou metodu [get_all_text_frames](https://reference.aspose.com/slides/cs/python-net/aspose.slides.util/slideutil/get_all_text_frames/) vystavenou třídou [SlideUtil](https://reference.aspose.com/slides/cs/python-net/aspose.slides.util/slideutil/). Přijímá dva parametry:

1. Prvním je objekt typu [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/), který představuje PowerPoint nebo OpenDocument prezentaci, ze které bude text extrahován.
2. Druhým je hodnota typu `Boolean`, která udává, zda mají být při skenování textu zahrnuty i hlavní snímky (master slides).

Metoda vrací pole objektů typu [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/), včetně informací o formátování textu. Níže uvedený kód skenuje text a podrobnosti o formátování v prezentaci, včetně hlavních snímků.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    include_master_slides = True
    text_frames = slides.util.SlideUtil.get_all_text_frames(presentation, include_master_slides)

    for text_frame in text_frames:
        for paragraph in text_frame.paragraphs:
            for portion in paragraph.portions:
                portion_text = portion.text
                print(portion_text)

                portion_format = portion.portion_format
                font_height = portion_format.font_height
                print(font_height)

                latin_font = portion_format.latin_font
                if latin_font is not None:
                    font_name = latin_font.font_name
                    print(font_name)
```

## **Kategorizované a rychlé extrahování textu**

Třída [PresentationFactory](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationfactory/) také poskytuje metody pro extrahování veškerého textu z prezentací:

```py
PresentationFactory.get_presentation_text(file, mode)
PresentationFactory.get_presentation_text(stream, mode)
PresentationFactory.get_presentation_text(stream, mode, options)
```

Argument výčtu [TextExtractionArrangingMode](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textextractionarrangingmode/) určuje režim uspořádání výsledku extrakce textu a může být nastaven na následující hodnoty:
- `UNARRANGED` – Surový text bez ohledu na jeho polohu na snímku.
- `ARRANGED` – Text je uspořádán ve stejném pořadí jako na snímku.

Režim `UNARRANGED` lze použít, když je rychlost kritická; je rychlejší než režim `ARRANGED`.

[PresentationText](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationtext/) představuje surový text extrahovaný z prezentace. Jeho vlastnost `slides_text` vrací pole objektů textu snímků. Každý objekt představuje text na odpovídajícím snímku a má následující vlastnosti:

- `text` – Text v tvarech snímku.
- `master_text` – Text v tvarech hlavního snímku (master slide) přiřazeném k tomuto snímku.
- `layout_text` – Text v tvarech rozložení snímku (layout slide) přiřazeném k tomuto snímku.
- `notes_text` – Text v tvarech poznámkového snímku (notes slide) přiřazeném k tomuto snímku.
- `comments_text` – Text v komentářích přiřazených k tomuto snímku.

```py
import aspose.slides as slides

presentation_path = "presentation.ppt"
arranging_mode = slides.TextExtractionArrangingMode.UNARRANGED
presentation_text = slides.PresentationFactory.instance.get_presentation_text(presentation_path, arranging_mode)
first_slide_text = presentation_text.slides_text[0]

print(first_slide_text.text)
print(first_slide_text.layout_text)
print(first_slide_text.master_text)
print(first_slide_text.notes_text)
print(first_slide_text.comments_text)
```

## **Často kladené otázky**

**Jak rychle Aspose.Slides zpracovává velké prezentace při extrakci textu?**

Aspose.Slides je optimalizováno pro vysoký výkon a dokáže zpracovat i [velké prezentace](/slides/cs/python-net/open-presentation/), což ho činí vhodným pro scénáře v reálném čase nebo hromadného zpracování.

**Může Aspose.Slides extrahovat text z tabulek a grafů v prezentacích?**

Ano. Aspose.Slides dokáže extrahovat text z mnoha prvků snímku, včetně tabulek a objektů souvisejících s grafy, takže můžete přistupovat k textovému obsahu v běžných strukturách prezentací.

**Potřebuji zvláštní licenci Aspose.Slides k extrahování textu z prezentací?**

Text můžete extrahovat pomocí bezplatné zkušební verze Aspose.Slides, i když bude mít [určité omezení](/slides/cs/python-net/licensing/), například zpracování jen omezeného počtu snímků. Pro neomezené používání a práci s většími prezentacemi se doporučuje zakoupit plnou licenci.