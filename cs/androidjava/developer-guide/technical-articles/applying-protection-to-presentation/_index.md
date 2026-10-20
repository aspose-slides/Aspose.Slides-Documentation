---
title: Omezit úpravy prezentací pomocí zámků tvarů na Androidu
linktitle: Omezit úpravy prezentací
type: docs
weight: 60
url: /cs/androidjava/applying-protection-to-presentation/
keywords:
- zabránit úpravám
- chránit před úpravami
- zámek tvaru
- zámek pozice
- zámek výběru
- zámek změny velikosti
- zámek seskupování
- PowerPoint
- PPTX
- prezentace
- Android
- Java
- Aspose.Slides
description: "Naučte se, jak zamknout a odemknout tvary v PPTX prezentacích pomocí Aspose.Slides pro Android přes Java, aby bylo možné omezit výběr, přesun, změnu velikosti a seskupování."
---
## **Přehled**

Běžné použití Aspose.Slides pro Android pomocí Javy je vytvářet, aktualizovat a ukládat prezentace PowerPoint (PPTX) jako součást automatizovaného pracovního postupu. Když uživatelé obdrží tyto prezentace, omezení změn tvarů může pomoci zachovat zamýšlené rozvržení a obsah.

Tento článek vysvětluje, jak jsou tvary organizovány na snímcích a jak v PPTX prezentaci použít a odebrat zámky tvarů. Tyto zámky vám umožní omezit konkrétní operace úprav na jednotlivých tvarech.

## **Složení snímku**

Snímek prezentace se skládá ze součástí, jako jsou automatické tvary, tabulky, OLE objekty, seskupené tvary, rámečky obrázků, video rámečky, spoje a další prvky používané k vytvoření prezentace. V Aspose.Slides pro Android pomocí Javy je každý prvek na snímku reprezentován objektem, který implementuje rozhraní [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) nebo dědí z třídy, která to dělá.

Různé typy tvarů nabízejí různé možnosti zamykání. Rozhraní [IBaseShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/) je základní rozhraní pro zámky tvarů. Aspose.Slides pro Android pomocí Javy poskytuje následující rozhraní zámků:

- [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/) zamyká automatické tvary.  
- [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) zamyká tvary spojů.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) zamyká grafické objekty.  
- [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/) zamyká seskupené tvary.  
- [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) zamyká rámečky obrázků.  

Chcete‑li použít zámky napříč [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/), projděte její snímky a nastavte příslušné zámky na každý podporovaný tvar.

## **Použití a odebrání ochrany**

Zámky tvarů omezují operace, jako je výběr, přesun a změna velikosti tvarů. Neznemožňují úpravy celé prezentace.

### **Použití ochrany na tvary PPTX**

Aspose.Slides pro Android pomocí Javy poskytuje rozhraní [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/), které umožňuje pracovat s tvary na snímku.

Příklad volá [setSelectLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-), [setPositionLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-), a [setSizeLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) s hodnotou `true` pro automatické tvary, s ekvivalentními zámky pro seskupené tvary, spoje a rámečky obrázků. Spoje používají [setPositionMove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) pro pohyb; seskupení také používají [setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) k omezení seskupování.

Příklad načte existující PPTX prezentaci, zkontroluje tvary v kolekci tvarů každého snímku a uloží kopii s aplikovanými omezeními. Tvary mimo čtyři zpracovávané typy zůstávají nezměněny. Smyčka neprochází podřízené tvary uvnitř skupiny.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();
                autoShapeLock.setPositionLocked(true);
                autoShapeLock.setSelectLocked(true);
                autoShapeLock.setSizeLocked(true);
            } else if (shape instanceof IGroupShape) {
                IGroupShape groupShape = (IGroupShape) shape;
                IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();
                groupShapeLock.setGroupingLocked(true);
                groupShapeLock.setPositionLocked(true);
                groupShapeLock.setSelectLocked(true);
                groupShapeLock.setSizeLocked(true);
            } else if (shape instanceof IConnector) {
                IConnector connectorShape = (IConnector) shape;
                IConnectorLock connectorShapeLock = connectorShape.getShapeLock();
                connectorShapeLock.setPositionMove(true);
                connectorShapeLock.setSelectLocked(true);
                connectorShapeLock.setSizeLocked(true);
            } else if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();
                pictureFrameLock.setPositionLocked(true);
                pictureFrameLock.setSelectLocked(true);
                pictureFrameLock.setSizeLocked(true);
            }
        }
    }

    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Odebrání ochrany**

Chcete‑li odebrat zámek tvaru, nastavte jeho hodnotu na `false`. Následující příklad načte prezentaci se zamčenými tvary a vymaže omezení výběru, přesunu a změny velikosti pomocí [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/), a [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/). Také odebere omezení seskupování předáním `false` metodě [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) a uloží kopii prezentace. Ostatní nastavení zámků zůstávají nezměněna.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ProtectedSample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();
                autoShapeLock.setPositionLocked(false);
                autoShapeLock.setSelectLocked(false);
                autoShapeLock.setSizeLocked(false);
            } else if (shape instanceof IGroupShape) {
                IGroupShape groupShape = (IGroupShape) shape;
                IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();
                groupShapeLock.setGroupingLocked(false);
                groupShapeLock.setPositionLocked(false);
                groupShapeLock.setSelectLocked(false);
                groupShapeLock.setSizeLocked(false);
            } else if (shape instanceof IConnector) {
                IConnector connectorShape = (IConnector) shape;
                IConnectorLock connectorShapeLock = connectorShape.getShapeLock();
                connectorShapeLock.setPositionMove(false);
                connectorShapeLock.setSelectLocked(false);
                connectorShapeLock.setSizeLocked(false);
            } else if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();
                pictureFrameLock.setPositionLocked(false);
                pictureFrameLock.setSelectLocked(false);
                pictureFrameLock.setSizeLocked(false);
            }
        }
    }

    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Závěr**

Aspose.Slides pro Android pomocí Javy vám umožňuje omezit konkrétní operace úprav na jednotlivých tvarech nebo aplikovat stejná omezení napříč snímky. Vyberte zámky podporované každým typem tvaru a nastavte jejich hodnoty na `false`, když potřebujete tato omezení odstranit.

## **Často kladené otázky**

**Mohu v jedné prezentaci kombinovat zámky tvarů a ochranu heslem?**

Ano. Zámky tvarů omezují konkrétní operace úprav, zatímco [password protection](/slides/cs/androidjava/password-protected-presentation/) může omezit otevření nebo úpravu prezentace. V jednom souboru můžete použít obojí.

**Mohu omezit úpravy na konkrétních snímcích, aniž by to ovlivnilo ostatní?**

Ano. Zámky použijte pouze na tvary na vybraných snímcích. Tím se nezmění nastavení zámků na ostatních snímcích.

**Jak mohu použít zámky na jednotlivé tvary uvnitř skupiny?**

Projděte kolekci vrácenou metodou [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) skupiny a použijte příslušné zámky na každý podřízený tvar. Opakujte to pro všechny vnořené skupiny. Výše uvedené příklady zpracovávají pouze kolekci tvarů snímku, takže nenastavují zámky na jednotlivé členy skupiny.