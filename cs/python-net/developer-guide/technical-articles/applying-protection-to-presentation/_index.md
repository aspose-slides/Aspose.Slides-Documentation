---
title: Omezte úpravy prezentace pomocí zámků tvarů v Pythonu
linktitle: Omezte úpravy prezentace
type: docs
weight: 70
url: /cs/python-net/applying-protection-to-presentation/
keywords:
- zabránit úpravám
- chránit před úpravami
- zamknout tvar
- zamknout pozici
- zamknout výběr
- zamknout změnu velikosti
- zamknout seskupování
- PowerPoint
- PPTX
- prezentace
- Python
- Aspose.Slides
description: "Zjistěte, jak zamknout a odemknout tvary v PPTX prezentacích pomocí Aspose.Slides for Python via .NET, abyste omezili výběr, pohyb, změnu velikosti a seskupování."
---
## **Pozadí**

Běžné použití Aspose.Slides for Python via .NET je vytváření, aktualizace a ukládání prezentací PowerPoint (PPTX) jako součást automatizovaného pracovního postupu. Když uživatelé obdrží tyto prezentace, omezení změn tvarů může pomoci zachovat zamýšlené rozložení a obsah.

Tento článek vysvětluje, jak jsou tvary uspořádány na snímcích a jak aplikovat a odebrat zámky tvarů v prezentaci PPTX. Tyto zámky vám umožňují omezit konkrétní operace úprav u jednotlivých tvarů.

## **Složení snímku**

Snímek prezentace se skládá z komponent, jako jsou automatické tvary, tabulky, OLE objekty, seskupené tvary, rámečky obrázků, video rámečky, spojnice a další prvky používané k vytvoření prezentace. V Aspose.Slides for Python via .NET je každý prvek na snímku představován objektem, který dědí ze třídy [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/).

Různé typy tvarů nabízejí různé možnosti zamykání. Třída [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) je základní třídou pro zámky tvarů. Aspose.Slides for Python via .NET poskytuje následující třídy zámků:
- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) zamyká automatické tvary.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) zamyká tvary spojnic.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) zamyká grafické objekty.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) zamyká seskupené tvary.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) zamyká rámečky obrázků.  

Pro aplikaci zámků napříč [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), projděte jeho snímky a nastavte odpovídající zámky na každém podporovaném tvaru.

## **Použití a odebrání ochrany**

Kompatibilní editory prezentací používají zámky tvarů k omezení individuálních operací úprav. Šifrování souboru a ochrana zápisu na úrovni dokumentu jsou samostatná [nastavení ochrany prezentace](/slides/cs/python-net/password-protected-presentation/).

### **Aplikace ochrany na tvary PPTX**

Aspose.Slides for Python via .NET poskytuje třídu [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) pro práci s tvary na snímku.

Příklad nastavuje [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/), [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/), a [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) na `True` pro automatické tvary, s ekvivalentními zámky pro seskupené tvary, spojnice a rámečky obrázků. Spojnice používají [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) pro pohyb; skupiny také používají [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) k omezení seskupování.

Příklad načte existující PPTX prezentaci, zkontroluje tvary v kolekci tvarů každého snímku a uloží kopii s těmito aplikovanými omezeními. Tvary mimo čtyři zpracovávané typy zůstávají beze změny. Smyčka neprochází podřízené tvary uvnitř skupiny.

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.GroupShape):
                shape.shape_lock.grouping_locked = True
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.Connector):
                shape.shape_lock.position_move = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.PictureFrame):
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True

    presentation.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Odebrání ochrany**

Pro odebrání zámku tvaru nastavte jeho hodnotu na `False`. Následující příklad načte prezentaci se zámky tvarů a vymaže omezení výběru, pohybu a změny velikosti pomocí [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/), a [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/). Také vymaže [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) a uloží kopii prezentace. Ostatní nastavení zámků zůstávají beze změny.

```python
import aspose.slides as slides

with slides.Presentation("ProtectedSample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.GroupShape):
                shape.shape_lock.grouping_locked = False
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.Connector):
                shape.shape_lock.position_move = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.PictureFrame):
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False

    presentation.save("RemovedProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Zachování ořezu obrázku**

Umístěte fotografii pojmenovanou `photo.jpg` do pracovního adresáře. Příklad ořízne 12 % zleva a 8 % zprava a poté nastaví [crop_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/crop_locked/) na rámečku obrázku. Tento příznak omezuje další ořezávání a zachovává stávající ořez.

```python
from pathlib import Path

import aspose.slides as slides

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes

    photo_bytes = Path("photo.jpg").read_bytes()
    photo = presentation.images.add_image(photo_bytes)

    picture_frame = shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 30, 270, 160, photo)
    picture_frame.picture_format.crop_left = 12
    picture_frame.picture_format.crop_right = 8
    picture_frame.shape_lock.aspect_ratio_locked = False
    picture_frame.shape_lock.crop_locked = True

    presentation.save("PictureLocked.pptx", slides.export.SaveFormat.PPTX)
```

`PictureLocked.pptx` ukládá zámek ořezu jako `True`. V PowerPointu je příkaz **Crop** zakázán, když je fotografie vybraná.

### **Udržení diagramu seskupeného**

Příklad seskupí obdélník a šipku, pak nastaví [ungrouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/ungrouping_locked/) na samotnou skupinu, aby komponenty diagramu zůstaly pohromadě. Ostatní úpravy, jako přesunutí skupiny nebo změna výplně komponenty, jsou nadále dostupné.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes
    
    group_shape = shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 70, 90, 50)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RIGHT_ARROW, 190, 80, 60, 30)
    group_shape.shape_lock.ungrouping_locked = True

    presentation.save("DiagramLocked.pptx", slides.export.SaveFormat.PPTX)
```

`DiagramLocked.pptx` ukládá zámek rozdělení jako `True`. V PowerPointu je příkaz **Ungroup** zakázán, když je celý diagram vybrán.

### **Zpráva o existujících zámcích tvarů**

Pro revizi šablony ji otevřete a přečtěte objekt zámku pro každý tvar. [no_locks](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/no_locks/) je `True`, když jsou všechny příznaky v tomto objektu zakázány, a `False`, když je alespoň jeden povolen. Skupina a její podřazené mají samostatné objekty zámků, takže zkontrolujte podřízené i když skupina nemá žádné zámky.

Tento příklad kontroluje pohyb automatických tvarů, rámečků obrázků a skupin, ořez pro obrázky a rozdělení pro skupiny. Vypisuje rozpoznané příznaky a označuje typy tvarů, které nezkoumá.

```python
import aspose.slides as slides


def inspect_shapes(shapes, slide_number, prefix=""):
    for shape in shapes:
        path = prefix + shape.name
        label = f"Slide {slide_number} | {path} | {type(shape).__name__}"
        if not isinstance(shape, (slides.GroupShape, slides.PictureFrame, slides.AutoShape)):
            print(f"{label} | Uninspected")
            continue

        shape_lock = shape.shape_lock
        if not shape_lock.no_locks:
            flags = []
            if isinstance(shape, slides.GroupShape) and shape_lock.ungrouping_locked:
                flags.append("ungrouping_locked")
            if isinstance(shape, slides.PictureFrame) and shape_lock.crop_locked:
                flags.append("crop_locked")
            if shape_lock.position_locked:
                flags.append("position_locked")
            restrictions = ", ".join(flags) if flags else "Active flag not identified"
            print(f"{label} | {restrictions}")

        if isinstance(shape, slides.GroupShape):
            inspect_shapes(shape.shapes, slide_number, path + "/")


with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        inspect_shapes(slide.shapes, slide.slide_number)
```

Předpokládejme, že snímek 1 souboru `Sample.pptx` obsahuje skupinu pojmenovanou `Layout` s uzamčeným rozdělením, obrázek pojmenovaný `Photo` uvnitř ní s uzamčeným ořezem a odemčený obdélník pojmenovaný `Free`. Zpráva přeskočí `Free` a vytiskne tyto dva řádky:

```text
Slide 1 | Layout | GroupShape | ungrouping_locked
Slide 1 | Layout/Photo | PictureFrame | crop_locked
```

Zpráva načte uložené příznaky úprav na úrovni tvaru, aniž by je měnila nebo ukládala prezentaci. Ochrana zápisu na úrovni dokumentu je samostatné nastavení a vynucování každého příznaku závisí na editoru.

### **Závěr**

Aspose.Slides for Python via .NET vám umožňuje omezit konkrétní operace úprav u jednotlivých tvarů nebo aplikovat stejná omezení napříč snímky. Vyberte zámky podporované daným typem tvaru a nastavte jejich hodnoty na `False`, když potřebujete tato omezení odebrat.

## **Často kladené otázky**

**Mohu kombinovat zámky tvarů a ochranu heslem ve stejné prezentaci?**

Ano. Zámky tvarů omezují konkrétní operace úprav, zatímco [ochranu heslem](/slides/cs/python-net/password-protected-presentation/) může omezit otevření nebo úpravu prezentace. Obě možnosti můžete v jednom souboru použít.

**Mohu omezit úpravy na konkrétních snímcích, aniž bych ovlivnil ostatní?**

Ano. Aplikujte zámky pouze na tvary na vybraných snímcích. Tím se nezmění nastavení zámků na ostatních snímcích.

**Jak mohu aplikovat zámky na jednotlivé tvary uvnitř skupiny?**

Projděte kolekci [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) skupiny a aplikujte odpovídající zámky na každý podřízený tvar. Tento postup opakujte pro všechny vnořené skupiny podle průchodu v příkladu zprávy.