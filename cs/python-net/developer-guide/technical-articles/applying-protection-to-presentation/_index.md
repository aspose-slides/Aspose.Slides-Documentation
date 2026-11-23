---
title: Omezit úpravy prezentace pomocí uzamčení tvarů v Pythonu
linktitle: Omezit úpravy prezentace
type: docs
weight: 70
url: /cs/python-net/applying-protection-to-presentation/
keywords:
- zabránit úpravám
- chránit před úpravami
- uzamknout tvar
- uzamknout polohu
- uzamknout výběr
- uzamknout změnu velikosti
- uzamknout seskupování
- PowerPoint
- PPTX
- prezentace
- Python
- Aspose.Slides
description: "Zjistěte, jak uzamknout a odemknout tvary v PPTX prezentacích pomocí Aspose.Slides pro Python via .NET, abyste omezili výběr, pohyb, změnu velikosti a seskupování."
---
## **Pozadí**

Běžné využití Aspose.Slides pro Python via .NET je vytváření, aktualizace a ukládání prezentací PowerPoint (PPTX) jako součást automatizovaného pracovního postupu. Když uživatelé obdrží tyto prezentace, omezení změn tvarů může pomoci zachovat zamýšlené rozvržení a obsah.

Tento článek vysvětluje, jak jsou tvary uspořádány na snímcích a jak použít a odebrat uzamčení tvarů v prezentaci PPTX. Tato uzamčení vám umožní omezit konkrétní editační operace na jednotlivých tvarech.

## **Složení snímku**

Snímek prezentace se skládá z komponent, jako jsou automatické tvary, tabulky, objekty OLE, seskupené tvary, rámečky obrázků, videorámečky, spoje a další prvky používané k vytvoření prezentace. V Aspose.Slides pro Python via .NET je každý prvek na snímku reprezentován objektem, který dědí ze třídy [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) .

Různé typy tvarů nabízejí různé možnosti uzamčení. Třída [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) je základní třídou pro uzamčení tvarů. Aspose.Slides pro Python via .NET poskytuje následující třídy uzamčení:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) uzamyká automatické tvary.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) uzamyká spoje.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) uzamyká grafické objekty.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) uzamyká seskupené tvary.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) uzamyká rámečky obrázků.  

Pro použití uzamčení napříč [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), projděte jeho snímky a nastavte příslušná uzamčení na každý podporovaný tvar.

## **Použití a odebrání ochrany**

Kompatibilní editory prezentací používají uzamčení tvarů k omezení individuálních editačních operací. Šifrování souboru a ochrana zápisu na úrovni dokumentu jsou samostatná [nastavení ochrany prezentace](/slides/cs/python-net/password-protected-presentation/) .

### **Použití ochrany na tvary PPTX**

Aspose.Slides pro Python via .NET poskytuje třídu [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) pro práci s tvary na snímku.

Příklad nastaví [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/), [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/) a [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) na `True` pro automatické tvary, s ekvivalentními uzamčeními pro seskupené tvary, spoje a rámečky obrázků. Spoje používají [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) pro pohyb; skupiny také používají [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) k omezení seskupování.

Příklad načte existující PPTX prezentaci, zkontroluje tvary v kolekci tvarů každého snímku a uloží kopii s těmito omezeními aplikovanými. Tvary mimo čtyři zpracovávané typy zůstávají beze změny. Smyčka neprochází podřízené tvary uvnitř skupiny.

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

Chcete‑li odebrat uzamčení tvaru, nastavte jeho hodnotu na `False`. Následující příklad načte prezentaci s uzamčenými tvary a vymaže omezení výběru, pohybu a změny velikosti prostřednictvím [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) a [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/). Také vymaže [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) a uloží kopii prezentace. Ostatní nastavení uzamčení zůstávají beze změny.

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

### **Zachovat oříznutí obrázku**

Umístěte fotografii pojmenovanou `photo.jpg` do pracovního adresáře. Příklad ořízne 12 % zleva a 8 % zprava, pak nastaví [crop_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/crop_locked/) na rámečku obrázku, aby oříznutí zůstalo zachováno.

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

`PictureLocked.pptx` ukládá uzamčení ořezu jako `True`. V PowerPoint je příkaz **Crop** zakázán, když je vybrána fotografie.

### **Udržet diagram seskupený**

Příklad seskupí obdélník a šipku a poté nastaví [ungrouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/ungrouping_locked/) na samotnou skupinu, aby komponenty diagramu zůstaly pohromadě. Ostatní úpravy, jako přesun skupiny nebo změna výplně komponentu, jsou nadále k dispozici.

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

`DiagramLocked.pptx` ukládá uzamčení rozeskupení jako `True`. V PowerPoint je příkaz **Ungroup** zakázán, když je vybrán celý diagram.

### **Závěr**

Aspose.Slides pro Python via .NET vám umožňuje omezit konkrétní editační operace na jednotlivých tvarech nebo aplikovat stejná omezení napříč snímky. Vyberte uzamčení podporovaná každým typem tvaru a nastavte jejich hodnoty na `False`, když potřebujete tato omezení odebrat.

## **FAQ**

**Mohu kombinovat uzamčení tvarů a ochranu heslem ve stejné prezentaci?**

Ano. Uzamčení tvarů omezuje konkrétní editační operace, zatímco [ochrana heslem](/slides/cs/python-net/password-protected-presentation/) může omezit otevírání nebo úpravy prezentace. Obě možnosti můžete použít ve stejném souboru.

**Mohu omezit úpravy na konkrétních snímcích, aniž bych ovlivnil ostatní?**

Ano. Uzamčení aplikujte pouze na tvary na vybraných snímcích. Tím se nezmění nastavení uzamčení na ostatních snímcích.

**Jak mohu použít uzamčení na jednotlivé tvary uvnitř skupiny?**

Projděte kolekci [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) skupiny a na každý podřízený tvar aplikujte příslušná uzamčení. Opakujte to pro všechny vnořené skupiny. Příklady výše zpracovávají pouze kolekci tvarů snímku, takže nenastavují uzamčení na jednotlivé členy skupiny.