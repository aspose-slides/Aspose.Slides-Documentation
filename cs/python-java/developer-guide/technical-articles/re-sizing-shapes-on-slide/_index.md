---
title: Změna velikosti tvarů na snímcích prezentace v Pythonu přes Java
type: docs
weight: 110
url: /cs/python-java/re-sizing-shapes-on-slide/
keywords:
- úprava velikosti tvaru
- změna velikosti tvaru
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Jednoduše změňte velikost tvarů na snímcích PowerPoint a OpenDocument pomocí Aspose.Slides pro Python prostřednictvím Java — automatizujte úpravy rozvržení snímků a zvyšte produktivitu."
---
## **Přehled**

Jednou z nejčastějších otázek zákazníků Aspose.Slides pro Python via Java je, jak změnit velikost tvarů tak, aby při změně velikosti snímku nedošlo k oříznutí dat. Tento krátký technický článek ukazuje, jak to provést.

## **Změna velikosti tvarů**

Cílem je zabránit tomu, aby se tvary během změny velikosti snímku posunuly. Aktualizujte polohu a rozměry každého tvaru, aby odpovídaly novému rozvržení snímku.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, SlideOrientation

# Načíst soubor prezentace.
presentation = Presentation("sample.ppt")
try:
    # Získat původní velikost snímku.
    current_height = presentation.getSlideSize().getSize().getHeight()
    current_width = presentation.getSlideSize().getSize().getWidth()

    # Změnit velikost snímku bez škálování existujících tvarů.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)

    # Získat novou velikost snímku.
    new_height = presentation.getSlideSize().getSize().getHeight()
    new_width = presentation.getSlideSize().getSize().getWidth()

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    # Změnit velikost a pozici tvarů na každém snímku.
    for slide in presentation.getSlides():
        for shape in slide.getShapes():

            # Škálovat velikost tvaru.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # Škálovat pozici tvaru.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Poznámka" %}} 
Tabulky nevyžadují žádné zvláštní úpravy: nastavení šířky a výšky tabulky přepočítá její sloupce a řádky proporcionalně, takže další změna výšky řádků a šířky sloupců by aplikovala poměr podruhé.
{{% /alert %}} 

Kód výše mění pouze tvary na snímcích. Předložní snímky a rozložení snímků mají své vlastní tvary, takže je také upravte, pokud chcete, aby celá prezentace odpovídala nové velikosti snímku:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpway.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, SlideOrientation

presentation = Presentation("sample.pptx")
try:
    # Získat původní velikost snímku.
    current_height = presentation.getSlideSize().getSize().getHeight()
    current_width = presentation.getSlideSize().getSize().getWidth()

    # Změnit velikost snímku bez škálování existujících tvarů.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    # presentation.getSlideSize().setOrientation(SlideOrientation.Portrait)

    # Získat novou velikost snímku.
    new_height = presentation.getSlideSize().getSize().getHeight()
    new_width = presentation.getSlideSize().getSize().getWidth()

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    for master in presentation.getMasters():
        for shape in master.getShapes():
            # Škálovat velikost tvaru.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # Škálovat pozici tvaru.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

        for layout_slide in master.getLayoutSlides():
            for shape in layout_slide.getShapes():
                # Škálovat velikost tvaru.
                shape.setHeight(shape.getHeight() * height_ratio)
                shape.setWidth(shape.getWidth() * width_ratio)

                # Škálovat pozici tvaru.
                shape.setY(shape.getY() * height_ratio)
                shape.setX(shape.getX() * width_ratio)

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            # Škálovat velikost tvaru.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # Škálovat pozici tvaru.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Často kladené otázky**

**Proč jsou tvary po změně velikosti snímku deformované nebo oříznuté?**  
Při změně velikosti snímku si tvary zachovávají původní polohu a velikost, pokud není měřítko explicitně změněno. To může vést k oříznutí obsahu nebo k nesprávnému zarovnání tvarů.

**Funguje poskytnutý kód pro všechny typy tvarů?**  
Ano. Nastavení výšky a šířky funguje stejně pro textová pole, obrázky, grafy i tabulky.

**Jak změním velikost tabulek při změně velikosti snímku?**  
Změňte velikost samotného tvaru tabulky, stejně jako u jakéhokoli jiného tvaru. Její řádky a sloupce se přizpůsobí proporcionalně, takže je pak neškálujte znovu.

**Bude tato změna velikosti fungovat i pro předložní snímky a rozložení?**  
Ano, ale měli byste také projít [Presentation.getMasters](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getMasters) a [Presentation.getLayoutSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getLayoutSlides) a aplikovat stejnou logiku škálování na jejich tvary, aby byla zajištěna konzistence v celé prezentaci.

**Mohu při změně velikosti také změnit orientaci snímku (na výšku/na šířku)?**  
Ano. K změně orientace můžete použít [SlideSize.setOrientation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidesize/#setOrientation). Ujistěte se, že odpovídajícím způsobem nastavíte logiku škálování, aby byl zachován rozvrh.

**Existuje limit velikosti snímku, kterou mohu nastavit?**  
Aspose.Slides podporuje vlastní velikosti, ale velmi velké rozměry mohou ovlivnit výkon nebo kompatibilitu s některými verzemi PowerPointu.

**Jak mohu zabránit deformaci tvarů se zachovaným poměrem stran?**  
Můžete před škálováním zkontrolovat metodu [getAspectRatioLocked](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshapelock/#getAspectRatioLocked) uzamčení tvaru. Pokud je uzamčený, upravte šířku nebo výšku proporcionalně místo samostatného škálování.