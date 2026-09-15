---
title: Zabránit úpravám prezentace pomocí uzamčení tvarů
linktitle: Zabránit úpravám prezentace
type: docs
weight: 60
url: /cs/python-java/applying-protection-to-presentation/
keywords:
- zabránit úpravám
- ochránit před úpravami
- uzamknout tvar
- uzamknout pozici
- uzamknout výběr
- uzamknout velikost
- uzamknout seskupování
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Objevte, jak Aspose.Slides for Python via Java zamyká nebo odemyká tvary v souborech PPT, PPTX a ODP, zabezpečuje prezentace a zároveň umožňuje řízené úpravy a rychlejší doručení."
---
## **Pozadí**

Běžným využitím Aspose.Slides je vytváření, aktualizace a ukládání prezentací Microsoft PowerPoint (PPTX) jako součást automatizovaného pracovního postupu. Uživatelé aplikací, které Aspose.Slides takto používají, mají přístup k vygenerovaným prezentacím, takže ochrana před úpravami je běžnou starostí. Je důležité, aby automaticky generované prezentace zachovaly původní formátování a obsah.

Tento článek vysvětluje, jak jsou prezentace a snímky strukturovány a jak Aspose.Slides for Python via Java může na prezentaci použít ochranu a později ji odebrat. Poskytuje vývojářům způsob, jak kontrolovat, jak jsou prezentace generované jejich aplikacemi používány.

## **Složení snímku**

Snímek prezentace se skládá z komponent, jako jsou autoshapes, tabulky, OLE objekty, seskupené tvary, rámy obrázků, video rámy, propojení a další prvky používané pro tvorbu prezentace. V Aspose.Slides for Python via Java je každý prvek na snímku reprezentován objektem, který dědí od třídy [Shape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/).

Struktura PPTX je složitá, takže na rozdíl od PPT, kde lze použít obecný zámek pro všechny typy tvarů, různé typy tvarů vyžadují odlišné zámky. Třída [BaseShapeLock](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseshapelock/) je obecná třída zámku pro PPTX. Následující typy zámků jsou v Aspose.Slides for Python via Java pro PPTX podporovány:

- [AutoShapeLock](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshapelock/) zamyká autoshapes.  
- [ConnectorLock](https://reference.aspose.com/slides/cs/python-java/aspose.slides/connectorlock/) zamyká tvary propojení.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/cs/python-java/aspose.slides/graphicalobjectlock/) zamyká grafické objekty.  
- [GroupShapeLock](https://reference.aspose.com/slides/cs/python-java/aspose.slides/groupshapelock/) zamyká seskupené tvary.  
- [PictureFrameLock](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pictureframelock/) zamyká rámy obrázků.  

Jakákoli akce provedená na všech objektech tvarů v objektu [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) se aplikuje na celou prezentaci.

## **Použití a odebrání ochrany**

Aplikace ochrany zajišťuje, že prezentaci nelze upravovat. Je to užitečná technika pro ochranu obsahu prezentace.

### **Použít ochranu na tvary PPTX**

Aspose.Slides for Python via Java poskytuje třídu [Shape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/) pro práci s tvary na snímku.

Jak bylo zmíněno dříve, každá třída tvaru má přiřazenou třídu shape-lock pro ochranu. Tento článek se zaměřuje na zámky NoSelect, NoMove a NoResize. Tyto zámky zajišťují, že tvary nelze vybrat (kliknutím myši nebo jinými metodami výběru) a že je nelze přesunout ani změnit jejich velikost.

Následující ukázkový kód aplikuje ochranu na všechny typy tvarů v prezentaci.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

# Vytvořte instanci třídy Presentation, která představuje soubor PPTX.
presentation = Presentation("Sample.pptx")
try:
    # Procházejte všechny snímky v prezentaci.
    for slide in presentation.getSlides():
        # Procházejte všechny tvary na snímku.
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

    # Uložte soubor prezentace.
    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Odebrat ochranu**

Pro odemčení tvaru nastavte hodnotu použitého zámku na `False`. Následující ukázkový kód ukazuje, jak odemknout tvary v zamčené prezentaci.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

# Vytvořte instanci třídy Presentation, která představuje soubor PPTX.
presentation = Presentation("ProtectedSample.pptx")
try:
    # Procházejte všechny snímky v prezentaci.
    for slide in presentation.getSlides():
        # Procházejte všechny tvary na snímku.
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

    # Uložte soubor prezentace.
    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Závěr**

Aspose.Slides nabízí několik možností pro ochranu tvarů v prezentaci. Můžete zamknout jednotlivý tvar nebo projít všechny tvary v prezentaci a zamknout je, čímž efektivně zabezpečíte celý soubor. Ochranu můžete odstranit nastavením hodnoty zámku na `False`.

## **Často kladené otázky**

**Mohu kombinovat zámky tvarů a ochranu heslem ve stejné prezentaci?**

**Ano.** Zámky omezují úpravy objektů uvnitř souboru, zatímco [ochrana heslem](/slides/cs/python-java/password-protected-presentation/) řídí přístup k otevírání a/nebo ukládání změn. Tyto mechanismy se doplňují a fungují společně.

**Mohu omezit úpravy na konkrétních snímcích bez ovlivnění ostatních?**

**Ano.** Použijte zámky na tvary na vybraných snímcích; zbytkové snímky zůstanou upravitelné.

**Platí zámky tvarů i pro seskupené objekty a propojení?**

**Ano.** Pro skupiny, propojení, grafické objekty a další typy tvarů jsou podporovány specializované typy zámků.