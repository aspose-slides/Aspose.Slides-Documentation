---
title: Omezit úpravy prezentace pomocí zamykání tvarů v Pythonu
linktitle: Omezit úpravy prezentace
type: docs
weight: 60
url: /cs/python-java/applying-protection-to-presentation/
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
- Java
- Aspose.Slides
description: "Naučte se, jak zamknout a odemknout tvary v PPTX prezentacích pomocí Aspose.Slides for Python via Java a omezit výběr, pohyb, změnu velikosti a seskupování."
---
## **Pozadí**

Běžné použití Aspose.Slides for Python via Java je vytváření, aktualizace a ukládání prezentací PowerPoint (PPTX) jako součást automatizovaného pracovního postupu. Když uživatelé tyto prezentace obdrží, omezení změn tvarů může pomoci zachovat zamýšlené rozložení a obsah.

Tento článek vysvětluje, jak jsou tvary organizovány na snímcích a jak použít a odebrat zámky tvarů v PPTX prezentaci. Tyto zámky vám umožňují omezit konkrétní operace úprav u jednotlivých tvarů.

## **Složení snímku**

Snímek prezentace se skládá z komponent jako jsou automatické tvary, tabulky, OLE objekty, seskupené tvary, rámečky obrázků, video rámečky, spojnice a další prvky používané k vytvoření prezentace. V Aspose.Slides for Python via Java je každý prvek na snímku reprezentován objektem, který dědí ze třídy [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/).

Různé typy tvarů poskytují různé možnosti zamykání. Třída [BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/) je základní třída pro zamky tvarů. Aspose.Slides for Python via Java poskytuje následující třídy zamykání:

- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) uzamyká automatické tvary.  
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) uzamyká tvary spojnic.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) uzamyká grafické objekty.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) uzamyká seskupené tvary.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) uzamyká rámečky obrázků.  

Pro použití zamykání napříč [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/), projděte jeho snímky a nastavte příslušné zamky na každý podporovaný tvar.

## **Použití a odebrání ochrany**

Kompatibilní editory prezentací používají zamky tvarů k omezení individuálních operací úprav. Šifrování souboru a úroveň ochrany zápisu na úrovni dokumentu jsou samostatná [nastavení ochrany prezentace](/slides/cs/python-java/password-protected-presentation/).

### **Použití ochrany na tvary PPTX**

Aspose.Slides for Python via Java poskytuje třídu [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) pro práci s tvary na snímku.

Příklad volá [setSelectLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setPositionLocked) a [setSizeLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSizeLocked) s hodnotou `True` pro automatické tvary, s ekvivalentními zamky pro seskupené tvary, spojnice a rámečky obrázků. Spojnice používají [setPositionMove](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/#setPositionMove) pro pohyb; skupiny také používají [setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) k omezení seskupování.

Příklad načte existující PPTX prezentaci, zkontroluje tvary v kolekci tvarů každého snímku a uloží kopii s těmito uplatněnými omezeními. Tvary mimo čtyři zpracovávané typy zůstávají beze změny. Smyčka neprochází podřízené tvary uvnitř skupiny.

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

Pro odebrání zamku tvaru nastavte jeho hodnotu na `False`. Následující příklad načte prezentaci se zamky tvarů a vymaže omezení výběru, pohybu a změny velikosti pomocí [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) a [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/). Také odstraní omezení seskupování předáním `False` metodě [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) a uloží kopii prezentace. Ostatní nastavení zamků zůstávají beze změny.

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

### **Zachování ořezu obrázku**

Umístěte fotografii pojmenovanou `photo.jpg` do pracovního adresáře. Příklad ořízne 12 % zlevé a 8 % zprava, poté zavolá [setCropLocked](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/#setCropLocked) s hodnotou `True` pro zachování ořezu.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()

    photo_bytes = Path("photo.jpg").read_bytes()
    photo = presentation.getImages().addImage(photo_bytes)
    
    picture_frame = shapes.addPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo)
    picture_frame.getPictureFormat().setCropLeft(12)
    picture_frame.getPictureFormat().setCropRight(8)

    picture_lock = picture_frame.getPictureFrameLock()
    picture_lock.setAspectRatioLocked(False)
    picture_lock.setCropLocked(True)

    presentation.save("PictureLocked.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

V souboru `PictureLocked.pptx` PowerPoint zakáže příkaz **Crop**, když vyberete fotografii.

### **Udržet diagram seskupený**

Příklad seskupí obdélník a šipku, poté zavolá [setUngroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setUngroupingLocked) s hodnotou `True`, aby udržel dva tvary pohromadě. Stále můžete přesunout skupinu nebo změnit výplň komponenty.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()

    group = shapes.addGroupShape()
    group.getShapes().addAutoShape(ShapeType.Rectangle, 100, 70, 90, 50)
    group.getShapes().addAutoShape(ShapeType.RightArrow, 190, 80, 60, 30)
    group.getGroupShapeLock().setUngroupingLocked(True)

    presentation.save("DiagramLocked.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

V souboru `DiagramLocked.pptx` PowerPoint zakáže příkaz **Ungroup**, když vyberete celý diagram.

### **Zpráva o existujících zamcích tvarů**

Pro revizi šablony ji otevřete a přečtěte objekt zamku pro každý tvar. Metoda [getNoLocks](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/#getNoLocks) vrací `True`, když jsou všechna příznaky na tomto objektu zakázána, a `False`, když je alespoň jeden povolen. Skupina a její podřízené prvky mají samostatné objekty zamků, takže kontrolujte podřízené prvky i když skupina nemá žádné zamky.

Tento příklad kontroluje pohyb automatických tvarů, rámečků obrázků a skupin. Také kontroluje ořez obrázků a rozeskupování pro skupiny. Zpráva uvádí povolené příznaky, které rozpozná, a označuje typy tvarů, které nezkoumá.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, GroupShape, PictureFrame, Presentation


def inspect_shapes(shapes, slide_number, prefix=""):
    for shape in shapes:
        path = f"{prefix}{shape.getName()}"
        label = f"Slide {slide_number} | {path} | {shape.getClass().getSimpleName()}"
        flags = []

        if isinstance(shape, GroupShape):
            shape_lock = shape.getGroupShapeLock()
            if shape_lock.getUngroupingLocked():
                flags.append("UngroupingLocked")
        elif isinstance(shape, PictureFrame):
            shape_lock = shape.getPictureFrameLock()
            if shape_lock.getCropLocked():
                flags.append("CropLocked")
        elif isinstance(shape, AutoShape):
            shape_lock = shape.getAutoShapeLock()
        else:
            print(f"{label} | Uninspected")
            continue

        if shape_lock.getPositionLocked():
            flags.append("PositionLocked")
        if not shape_lock.getNoLocks():
            restrictions = ", ".join(flags) if flags else "Active flag not identified"
            print(f"{label} | {restrictions}")

        if isinstance(shape, GroupShape):
            inspect_shapes(shape.getShapes(), slide_number, f"{path}/")


presentation = Presentation("Sample.pptx")
try:
    for slide in presentation.getSlides():
        inspect_shapes(slide.getShapes(), slide.getSlideNumber())
finally:
    presentation.dispose()
```

Předpokládejme, že snímek 1 souboru `Sample.pptx` obsahuje skupinu pojmenovanou `Layout` s uzamčeným rozeskupováním, obrázek pojmenovaný `Photo` uvnitř ní s uzamčeným ořezem a odemčený obdélník pojmenovaný `Free`. Zpráva přeskočí `Free` a vypíše tyto dva řádky:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Zpráva načte uložené příznaky úprav na úrovni tvaru, aniž by je měnila nebo ukládala prezentaci. Ochrana zápisu na úrovni dokumentu je samostatné nastavení a vynucení každého příznaku závisí na editoru.

### **Závěr**

Aspose.Slides for Python via Java vám umožňuje omezit konkrétní operace úprav u jednotlivých tvarů nebo použít stejná omezení napříč snímky. Vyberte zamky podporované u každého typu tvaru a nastavte jejich hodnoty na `False`, když potřebujete tato omezení odstranit.

## **Často kladené otázky**

**Mohu kombinovat zamky tvarů a ochranu heslem ve stejné prezentaci?**

Ano. Zamky tvarů omezují konkrétní operace úprav, zatímco [ochranu heslem](/slides/cs/python-java/password-protected-presentation/) může omezit otevírání nebo úpravu prezentace. Můžete použít obojí ve stejném souboru.

**Mohu omezit úpravy na konkrétních snímcích, aniž by to ovlivnilo ostatní?**

Ano. Použijte zamky pouze na tvary na vybraných snímcích. To nemění nastavení zamků na ostatních snímcích.

**Jak mohu použít zamky na jednotlivé tvary uvnitř skupiny?**

Procházejte kolekci vrácenou metodou [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) skupiny a použijte příslušné zamky na každý podřízený tvar. Opakujte to pro všechny vnořené skupiny podle průchodu v příkladu pro zprávu.