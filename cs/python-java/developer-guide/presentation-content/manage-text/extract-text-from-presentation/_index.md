---
title: Pokročilé extrahování textu z prezentací v Pythonu přes Java
linktitle: Extrahovat text
type: docs
weight: 90
url: /cs/python-java/extract-text-from-presentation/
keywords:
- extrahovat text
- extrahovat text ze snímku
- extrahovat text z prezentace
- extrahovat text z PowerPointu
- extrahovat text z OpenDocumentu
- extrahovat text z PPT
- extrahovat text z PPTX
- extrahovat text z ODP
- získat text
- získat text ze snímku
- získat text z prezentace
- získat text z PowerPointu
- získat text z OpenDocumentu
- získat text z PPT
- získat text z PPTX
- získat text z ODP
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Rychle extrahujte text z prezentací PowerPoint a OpenDocument pomocí Aspose.Slides pro Python přes Java. Postupujte podle našeho jednoduchého, krok po kroku návodu a ušetřete čas."
---
## **Přehled**

Extrahování textu z prezentací je běžná, ale zásadní úloha pro vývojáře pracující s obsahem snímků. Ať už pracujete se soubory Microsoft PowerPoint ve formátu PPT nebo PPTX, nebo s prezentacemi OpenDocument (ODP), přístup k textovým datům může být klíčový pro analýzu, automatizaci, indexování nebo migraci obsahu.

Tento článek poskytuje ucelený návod, jak efektivně extrahovat text z různých formátů prezentací, včetně PPT, PPTX a ODP, pomocí Aspose.Slides pro Python přes Java. Naučíte se systematicky procházet prvky prezentace a přesně získat požadovaný textový obsah.

## **Extrahovat text ze snímku**

Aspose.Slides pro Python přes Java poskytuje třídu [SlideUtil](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slideutil/). Tato třída nabízí několik přetížených statických metod pro extrahování veškerého textu z prezentace nebo snímku. Pro extrahování textu ze snímku v prezentaci použijte metodu [SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slideutil/#getAllTextBoxes). Tato metoda přijímá jako parametr objekt typu [BaseSlide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseslide/). Po spuštění metoda prohledá celý snímek a vrátí pole objektů typu [TextFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframe/), přičemž zachová formátování textu.

Následující úryvek kódu extrahuje veškerý text z prvního snímku prezentace:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil

slide_index = 0

presentation = Presentation("demo.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    text_frames = SlideUtil.getAllTextBoxes(slide)

    for text_frame in text_frames:
        for paragraph in text_frame.getParagraphs():
            for portion in paragraph.getPortions():
                portion_text = portion.getText()
                print(portion_text)

                portion_format = portion.getPortionFormat()
                font_height = portion_format.getFontHeight()
                print(font_height)

                latin_font = portion_format.getLatinFont()
                if latin_font is not None:
                    font_name = latin_font.getFontName()
                    print(font_name)
finally:
    presentation.dispose()
```

## **Extrahovat text z celé prezentace**

Pro skenování textu v celé prezentaci použijte statickou metodu [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slideutil/#getAllTextFrames), kterou nabízí třída [SlideUtil](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slideutil/). Přijímá dva parametry:

1. Nejprve objekt typu [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/), který představuje PowerPoint nebo OpenDocument prezentaci, ze které bude text extrahován.
1. Dále hodnotu typu `bool`, která určuje, zda mají být při skenování textu zahrnuty i hlavní snímky (master slides).

Metoda vrací pole objektů typu [TextFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframe/), včetně informací o formátování textu. Níže uvedený kód prohledá text a podrobnosti o formátování v prezentaci, včetně hlavních snímků.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil

presentation = Presentation("demo.pptx")
try:
    include_master_slides = True
    text_frames = SlideUtil.getAllTextFrames(presentation, include_master_slides)

    for text_frame in text_frames:
        for paragraph in text_frame.getParagraphs():
            for portion in paragraph.getPortions():
                portion_text = portion.getText()
                print(portion_text)

                portion_format = portion.getPortionFormat()
                font_height = portion_format.getFontHeight()
                print(font_height)

                latin_font = portion_format.getLatinFont()
                if latin_font is not None:
                    font_name = latin_font.getFontName()
                    print(font_name)
finally:
    presentation.dispose()
```

## **Kategorizovaná a rychlá extrakce textu**

Třída [PresentationFactory](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationfactory/) také poskytuje metody pro extrahování veškerého textu z prezentací:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, PresentationFactory, TextExtractionArrangingMode
from java.io import FileInputStream

mode = TextExtractionArrangingMode.Unarranged
load_options = LoadOptions()

# Extrahovat text ze souboru.
file_text = PresentationFactory.getInstance().getPresentationText("presentation.pptx", mode)

# Extrahovat text z proudu.
stream = FileInputStream("presentation.pptx")
try:
    stream_text = PresentationFactory.getInstance().getPresentationText(stream, mode)
finally:
    stream.close()

# Extrahovat text z proudu pomocí možností načtení.
stream_with_options = FileInputStream("presentation.pptx")
try:
    stream_text_with_options = PresentationFactory.getInstance().getPresentationText(stream_with_options, mode, load_options)
finally:
    stream_with_options.close()
```

Argument výčtu [TextExtractionArrangingMode](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textextractionarrangingmode/) určuje režim uspořádání výsledků extrakce textu a může být nastaven na následující hodnoty:

- [Unarranged](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textextractionarrangingmode/#Unarranged) – surový text bez ohledu na jeho polohu na snímku.
- [Arranged](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textextractionarrangingmode/#Arranged) – text je uspořádán ve stejném pořadí jako na snímku.

Režim Unarranged lze použít, když je kritická rychlost; je rychlejší než režim Arranged.

[Třída PresentationText](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationtext/) představuje surový text extrahovaný z prezentace. Její metoda [getSlidesText](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationtext/#getSlidesText) vrací pole objektů typu `SlideText`. Každý objekt představuje text na odpovídajícím snímku. Objekt typu `SlideText` má následující metody:

- `getText` – Text uvnitř tvarů snímku.
- `getMasterText` – Text uvnitř tvarů hlavního snímku spojeného s tímto snímkem.
- `getLayoutText` – Text uvnitř tvarů rozložení snímku spojeného s tímto snímkem.
- `getNotesText` – Text uvnitř tvarů poznámkového snímku spojeného s tímto snímkem.
- `getCommentsText` – Text v komentářích spojených s tímto snímkem.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory, TextExtractionArrangingMode

presentation_path = "presentation.ppt"
arranging_mode = TextExtractionArrangingMode.Unarranged
presentation_text = PresentationFactory.getInstance().getPresentationText(presentation_path, arranging_mode)
first_slide_text = presentation_text.getSlidesText()[0]

print(first_slide_text.getText())
print(first_slide_text.getLayoutText())
print(first_slide_text.getMasterText())
print(first_slide_text.getNotesText())
print(first_slide_text.getCommentsText())
```

## **Často kladené otázky**

**Jak rychle Aspose.Slides zpracovává velké prezentace při extrakci textu?**

Aspose.Slides je optimalizováno pro vysoký výkon a dokáže zpracovat i [velké prezentace](/slides/cs/python-java/open-presentation/), což jej činí vhodným pro scénáře v reálném čase i hromadného zpracování.

**Dokáže Aspose.Slides extrahovat text z tabulek a grafů v prezentacích?**

Ano. Aspose.Slides může extrahovat text z mnoha prvků snímku, včetně tabulek a objektů souvisejících s grafy, takže můžete přistupovat k textovému obsahu běžných strukturových prvků prezentace.

**Potřebuji speciální licenci Aspose.Slides pro extrakci textu z prezentací?**

Text můžete extrahovat pomocí bezplatné zkušební verze Aspose.Slides, i když má [některá omezení](/slides/cs/python-java/licensing/), například zpracování jen omezeného počtu snímků. Pro neomezené používání a zpracování větších prezentací se doporučuje zakoupit plnou licenci.