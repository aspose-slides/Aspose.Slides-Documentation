---
title: Omezte úpravy prezentace pomocí zámků tvarů v .NET
linktitle: Omezte úpravy prezentace
type: docs
weight: 70
url: /cs/net/applying-protection-to-presentation/
keywords:
- zabránit úpravám
- chránit před úpravami
- zámek tvaru
- zámek polohy
- zámek výběru
- zámek změny velikosti
- zámek seskupování
- PowerPoint
- PPTX
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Naučte se, jak zamknout a odblokovat tvary v PPTX prezentacích pomocí Aspose.Slides pro .NET, aby bylo možné omezit výběr, přesun, změnu velikosti a seskupování."
---
## **Pozadí**

Běžné využití Aspose.Slides pro .NET je vytváření, aktualizace a ukládání prezentací PowerPoint (PPTX) jako součást automatizovaného pracovního postupu. Když uživatelé obdrží tyto prezentace, omezení změn tvarů může pomoci zachovat zamýšlené rozvržení a obsah.

Tento článek vysvětluje, jak jsou tvary organizovány na snímcích a jak v PPTX prezentaci použít a odstranit zámky tvarů. Tyto zámky vám umožňují omezit konkrétní úpravy jednotlivých tvarů.

## **Složení snímku**

Snímek prezentace se skládá z komponent, jako jsou automatické tvary, tabulky, OLE objekty, seskupené tvary, rámečky obrázků, video rámečky, propojení a další prvky používané k vytvoření prezentace. V Aspose.Slides pro .NET je každý prvek na snímku reprezentován objektem, který implementuje rozhraní [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) nebo dědí z třídy, která tak činí.

Různé typy tvarů nabízejí různé možnosti zamykání. Rozhraní [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) je základním rozhraním pro zámky tvarů. Aspose.Slides pro .NET poskytuje následující rozhraní zámků:

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) zamyká automatické tvary.  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) zamyká tvary propojení.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) zamyká grafické objekty.  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) zamyká skupinové tvary.  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) zamyká rámečky obrázků.  

Pro použití zámků napříč [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), procházejte jejích snímky a nastavte příslušné zámky na každém podporovaném tvaru.

## **Použití a odebrání ochrany**

Zámky tvarů omezují operace, jako je výběr, přesouvání a změna velikosti tvarů. Nečiní celou prezentaci needitovatelnou.

### **Použití ochrany na tvary PPTX**

Aspose.Slides pro .NET poskytuje rozhraní [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) , které umožňuje pracovat s tvary na snímku.

Příklad nastavuje [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/), [PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/) a [SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) na `true` pro automatické tvary, s ekvivalentními zámky pro skupinové tvary, propojení a rámečky obrázků. Propojení používají [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) pro pohyb; skupiny také používají [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) , aby omezily seskupování.

Příklad načte existující PPTX prezentaci, prověří tvary v kolekci tvarů každého snímku a uloží kopii s těmito aplikovanými omezeními. Tvary mimo čtyři zpracovávané typy zůstávají nezměněny. Smyčka neprochází podřízené tvary uvnitř skupiny.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = true;
            autoShape.ShapeLock.SelectLocked = true;
            autoShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = true;
            groupShape.ShapeLock.PositionLocked = true;
            groupShape.ShapeLock.SelectLocked = true;
            groupShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = true;
            connectorShape.ShapeLock.SelectLocked = true;
            connectorShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = true;
            pictureFrame.ShapeLock.SelectLocked = true;
            pictureFrame.ShapeLock.SizeLocked = true;
        }
    }
}

presentation.Save("ProtectedSample.pptx", SaveFormat.Pptx);
```

### **Odebrání ochrany**

Pro odebrání zámku tvaru nastavte jeho hodnotu na `false`. Následující příklad načte prezentaci se zámky tvarů a vymaže omezení výběru, přesunu a změny velikosti pomocí [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/), a [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/). Také vymaže [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) a uloží kopii prezentace. Ostatní nastavení zámků zůstávají nezměněna.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ProtectedSample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = false;
            autoShape.ShapeLock.SelectLocked = false;
            autoShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = false;
            groupShape.ShapeLock.PositionLocked = false;
            groupShape.ShapeLock.SelectLocked = false;
            groupShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = false;
            connectorShape.ShapeLock.SelectLocked = false;
            connectorShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = false;
            pictureFrame.ShapeLock.SelectLocked = false;
            pictureFrame.ShapeLock.SizeLocked = false;
        }
    }
}

presentation.Save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
```

### **Závěr**

Aspose.Slides pro .NET vám umožňuje omezit konkrétní úpravy jednotlivých tvarů nebo použít stejné omezení napříč snímky. Vyberte zámky podporované daným typem tvaru a nastavte jejich hodnoty na `false`, když chcete tato omezení odstranit.

## **Často kladené otázky**

**Mohu kombinovat zámky tvarů a ochranu heslem ve stejné prezentaci?**

Ano. Zámky tvarů omezují konkrétní úpravy, zatímco [ochrana heslem](/slides/cs/net/password-protected-presentation/) může omezit otevření nebo úpravu prezentace. Můžete používat oba ve stejném souboru.

**Mohu omezit úpravy na konkrétních snímcích, aniž by to ovlivnilo ostatní?**

Ano. Použijte zámky pouze na tvary na vybraných snímcích. Tím se nezmění nastavení zámků na ostatních snímcích.

**Jak mohu použít zámky na jednotlivé tvary uvnitř skupiny?**

Procházejte kolekci [Tvary](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) skupiny a aplikujte příslušné zámky na každý podřízený tvar. Opakujte to pro všechny vnořené skupiny. Výše uvedené příklady zpracovávají pouze kolekci tvarů snímku, takže nenastavují zámky na jednotlivé členy skupiny.