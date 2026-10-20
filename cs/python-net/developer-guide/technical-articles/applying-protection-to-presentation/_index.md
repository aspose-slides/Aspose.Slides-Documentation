---
title: Omezte úpravy prezentace pomocí zámků tvarů v Pythonu
linktitle: Omezte úpravy prezentace
type: docs
weight: 70
url: /cs/python-net/applying-protection-to-presentation/
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
- Aspose.Slides
description: "Naučte se, jak uzamknout a odblokovat tvary v PPTX prezentacích pomocí Aspose.Slides pro Python prostřednictvím .NET, abyste omezili výběr, pohyb, změnu velikosti a seskupování."
---
## **Pozadí**

Běžné využití Aspose.Slides pro Python prostřednictvím .NET je vytvářet, aktualizovat a ukládat prezentace PowerPoint (PPTX) jako součást automatizovaného pracovního postupu. Když uživatelé tyto prezentace obdrží, omezení změn tvarů může pomoci zachovat zamýšlené rozvržení a obsah.

Tento článek vysvětluje, jak jsou tvary uspořádány na snímcích a jak v PPTX prezentaci použít a odebrat zámky tvarů. Tyto zámky vám umožňují omezit konkrétní operace úprav na jednotlivých tvarech.

## **Složení snímku**

Snímek prezentace se skládá z komponent, jako jsou automatické tvary, tabulky, OLE objekty, seskupené tvary, rámečky obrázků, video rámečky, konektory a další prvky použité k vytvoření prezentace. V Aspose.Slides pro Python prostřednictvím .NET je každý prvek na snímku reprezentován objektem, který dědí z třídy [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) .

Různé typy tvarů nabízejí různé možnosti zamykání. Třída [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) je základní třídou pro zamykání tvarů. Aspose.Slides pro Python prostřednictvím .NET poskytuje následující třídy zámků:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) zamyká automatické tvary.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) zamyká tvary konektorů.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) zamyká grafické objekty.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) zamyká seskupené tvary.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) zamyká rámečky obrázků.  

Chcete‑li použít zámky napříč [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), projděte jeho snímky a nastavte příslušné zámky na každém podporovaném tvaru.

## **Použití a odebrání ochrany**

Zámky tvarů omezují operace, jako je výběr, přesun a změna velikosti tvarů. Nezpřístupní celou prezentaci k úpravám.

### **Použití ochrany na PPTX tvary**

Aspose.Slides pro Python prostřednictvím .NET poskytuje třídu [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) pro práci s tvary na snímku.

Příklad nastaví [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/), [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/) a [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) na `True` pro automatické tvary, s ekvivalentními zámky pro seskupené tvary, konektory a rámečky obrázků. Konektory používají [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) pro pohyb; skupiny také používají [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) k omezení seskupování.

Příklad načte existující PPTX prezentaci, zkontroluje tvary v kolekci tvarů každého snímku a uloží kopii s aplikovanými omezeními. Tvary, které nejsou jedním ze čtyř zpracovávaných typů, zůstávají beze změny. Smyčka neprochází podřízené tvary uvnitř skupiny.

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

### **Odebrat ochranu**

Chcete‑li odebrat zámek tvaru, nastavte jeho hodnotu na `False`. Následující příklad načte prezentaci se zámky tvarů a vymaže omezení výběru, pohybu a změny velikosti pomocí [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) a [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/). Také vymaže [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) a uloží kopii prezentace. Ostatní nastavení zámků zůstávají beze změny.

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

### **Závěr**

Aspose.Slides pro Python prostřednictvím .NET vám umožní omezit konkrétní operace úprav na jednotlivých tvarech nebo použít stejná omezení napříč snímky. Vyberte zámky podporované daným typem tvaru a nastavte jejich hodnoty na `False`, když potřebujete tato omezení odebrat.

## **Často kladené otázky**

**Mohu kombinovat zámky tvarů a ochranu heslem ve stejné prezentaci?**

Ano. Zámky tvarů omezují konkrétní operace úprav, zatímco [ochrana heslem](/slides/cs/python-net/password-protected-presentation/) může omezit otevření nebo úpravu prezentace. Můžete použít obojí ve stejném souboru.

**Mohu omezit úpravy na konkrétních snímcích, aniž bych ovlivnil ostatní?**

Ano. Aplikujte zámky pouze na tvary na vybraných snímcích. Toto nezmění nastavení zámků na ostatních snímcích.

**Jak mohu aplikovat zámky na jednotlivé tvary uvnitř skupiny?**

Projděte kolekci [tvary](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) skupiny a aplikujte příslušné zámky na každý podřízený tvar. Opakujte to pro všechny vnořené skupiny. Výše uvedené příklady zpracovávají pouze kolekci tvarů snímku, takže nenastavují zámky na jednotlivé členy skupiny.