---
title: Omezit úpravy prezentace pomocí zamykání tvarů v Pythonu
linktitle: Omezit úpravy prezentace
type: docs
weight: 60
url: /cs/python-java/applying-protection-to-presentation/
keywords:
- zabránit úpravám
- chránit před úpravami
- uzamknout tvar
- uzamknout pozici
- uzamknout výběr
- uzamknout změnu velikosti
- uzamknout seskupování
- PowerPoint
- PPTX
- prezentace
- Python
- Java
- Aspose.Slides
description: "Naučte se, jak zamknout a odemknout tvary v PPTX prezentacích pomocí Aspose.Slides for Python via Java pro omezení výběru, přesunu, změny velikosti a seskupování."
---
## **Pozadí**

Běžné využití Aspose.Slides for Python via Java je vytvářet, aktualizovat a ukládat prezentace PowerPoint (PPTX) jako součást automatizovaného pracovního postupu. Když uživatelé obdrží tyto prezentace, omezení změn tvarů může pomoci zachovat zamýšlené rozvržení a obsah.

Tento článek vysvětluje, jak jsou tvary uspořádány na snímcích a jak aplikovat a odebrat zámky tvarů v PPTX prezentaci. Tyto zámky vám umožňují omezit konkrétní operace úprav na jednotlivých tvarech.

## **Složení snímku**

Prezentace snímku se skládá z komponent, jako jsou automatické tvary, tabulky, OLE objekty, seskupené tvary, rámečky obrázků, video rámečky, spojky a další prvky používané k vytvoření prezentace. V Aspose.Slides for Python via Java je každý prvek na snímku reprezentován objektem, který dědí ze třídy [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/).

Různé typy tvarů poskytují různé možnosti zamykání. Třída [BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/) je základní třídou pro zámky tvarů. Aspose.Slides for Python via Java poskytuje následující třídy zámků:

- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) uzamyká automatické tvary.  
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) uzamyká spojovací tvary.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) uzamyká grafické objekty.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) uzamyká seskupené tvary.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) uzamyká rámečky obrázků.  

Pro aplikaci zámků napříč [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) iterujte přes jeho snímky a nastavte příslušné zámky na každý podporovaný tvar.

## **Použití a odebrání ochrany**

Zámky tvarů omezují operace, jako je výběr, přesun a změna velikosti tvarů. Neznamenají, že celá prezentace bude needitovatelná.

### **Aplikovat ochranu na PPTX tvary**

Aspose.Slides for Python via Java poskytuje třídu [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) pro práci s tvary na snímku.

Příklad volá [setSelectLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setPositionLocked) a [setSizeLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSizeLocked) s hodnotou `True` pro automatické tvary, s ekvivalentními zámky pro seskupené tvary, spojky a rámečky obrázků. Spojky používají [setPositionMove](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/#setPositionMove) pro přesun; skupiny také používají [setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) k omezení seskupování.

Příklad načte existující PPTX prezentaci, zkontroluje tvary v kolekci tvarů každého snímku a uloží kopii s těmito omezeními. Tvary mimo čtyři zpracovávané typy zůstávají beze změny. Smyčka neprochází podřízené tvary uvnitř skupiny.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                auto_shape_lock = shape.getShapeLock()
                auto_shape_lock.setPositionLocked(True)
                auto_shape_lock.setSelectLocked(True)
                auto_shape_lock.setSizeLocked(True)
            elif isinstance(shape, GroupShape):
                group_shape_lock = shape.getShapeLock()
                group_shape_lock.setGroupingLocked(True)
                group_shape_lock.setPositionLocked(True)
                group_shape_lock.setSelectLocked(True)
                group_shape_lock.setSizeLocked(True)
            elif isinstance(shape, Connector):
                connector_shape_lock = shape.getShapeLock()
                connector_shape_lock.setPositionMove(True)
                connector_shape_lock.setSelectLocked(True)
                connector_shape_lock.setSizeLocked(True)
            elif isinstance(shape, PictureFrame):
                picture_frame_lock = shape.getShapeLock()
                picture_frame_lock.setPositionLocked(True)
                picture_frame_lock.setSelectLocked(True)
                picture_frame_lock.setSizeLocked(True)

    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Odebrání ochrany**

Pro odebrání zámku tvaru nastavte jeho hodnotu na `False`. Následující příklad načte prezentaci se zámky tvarů a vymaže omezení výběru, přesunu a změny velikosti pomocí [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) a [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/). Také odstraní omezení seskupování předáním `False` do [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) a uloží kopii prezentace. Ostatní nastavení zámků zůstávají beze změny.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

presentation = Presentation("ProtectedSample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                auto_shape_lock = shape.getShapeLock()
                auto_shape_lock.setPositionLocked(False)
                auto_shape_lock.setSelectLocked(False)
                auto_shape_lock.setSizeLocked(False)
            elif isinstance(shape, GroupShape):
                group_shape_lock = shape.getShapeLock()
                group_shape_lock.setGroupingLocked(False)
                group_shape_lock.setPositionLocked(False)
                group_shape_lock.setSelectLocked(False)
                group_shape_lock.setSizeLocked(False)
            elif isinstance(shape, Connector):
                connector_shape_lock = shape.getShapeLock()
                connector_shape_lock.setPositionMove(False)
                connector_shape_lock.setSelectLocked(False)
                connector_shape_lock.setSizeLocked(False)
            elif isinstance(shape, PictureFrame):
                picture_frame_lock = shape.getShapeLock()
                picture_frame_lock.setPositionLocked(False)
                picture_frame_lock.setSelectLocked(False)
                picture_frame_lock.setSizeLocked(False)

    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Závěr**

Aspose.Slides for Python via Java vám umožňuje omezit konkrétní operace úprav na jednotlivých tvarech nebo aplikovat stejná omezení napříč snímky. Vyberte zámky podporované daným typem tvaru a nastavte jejich hodnoty na `False`, když potřebujete tato omezení odebrat.

## **Často kladené otázky**

**Mohu kombinovat zámky tvarů a ochranu heslem ve stejné prezentaci?**

Ano. Zámky tvarů omezují konkrétní operace úprav, zatímco [ochranu heslem](/slides/cs/python-java/password-protected-presentation/) může omezit otevření nebo úpravu prezentace. Obě můžete použít ve stejném souboru.

**Mohu omezit úpravy na konkrétních snímcích, aniž by to ovlivnilo ostatní?**

Ano. Aplikujte zámky pouze na tvary na vybraných snímcích. Tím se nezmění nastavení zámků na ostatních snímcích.

**Jak mohu aplikovat zámky na jednotlivé tvary uvnitř skupiny?**

Iterujte přes kolekci vrácenou metodou [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) skupiny a aplikujte příslušné zámky na každý podřazený tvar. Opakujte to pro všechny vnořené skupiny. Výše uvedené příklady zpracovávají pouze kolekci tvarů snímku, takže nenastavují zámky na jednotlivé členy skupiny.