---
title: Omezte úpravy prezentace zamykáním tvarů v Javě
linktitle: Omezte úpravy prezentace
type: docs
weight: 60
url: /cs/java/applying-protection-to-presentation/
keywords:
- zabránit úpravám
- chránit před úpravami
- zamknout tvar
- zamknout polohu
- zamknout výběr
- zamknout změnu velikosti
- zamknout seskupování
- PowerPoint
- PPTX
- prezentace
- Java
- Aspose.Slides
description: "Naučte se, jak zamykat a odemykat tvary v PPTX prezentacích pomocí Aspose.Slides for Java k omezení výběru, přesunu, změny velikosti a seskupování."
---
## **Pozadí**

Běžné využití Aspose.Slides for Java je vytváření, aktualizace a ukládání prezentací PowerPoint (PPTX) jako součást automatizovaného pracovního postupu. Když uživatelé obdrží tyto prezentace, omezení změn tvarů může pomoci zachovat zamýšlené rozvržení a obsah.

Tento článek vysvětluje, jak jsou tvary organizovány na snímcích a jak v PPTX prezentaci použít a odstranit zamykání tvarů. Tato zamknutí vám umožní omezit konkrétní úpravy jednotlivých tvarů.

## **Složení snímku**

Snímek prezentace se skládá z komponent, jako jsou automatické tvary, tabulky, objekty OLE, seskupené tvary, rámečky obrázků, video rámečky, spoje a další prvky používané k vytvoření prezentace. V Aspose.Slides for Java je každý prvek na snímku reprezentován objektem, který implementuje rozhraní [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) nebo dědí z třídy, která to dělá.

Různé typy tvarů nabízejí různé možnosti zamykání. Rozhraní [IBaseShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/) je základní rozhraní pro zamykání tvarů. Aspose.Slides for Java poskytuje následující rozhraní pro zamykání:

- [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/) zamyká automatické tvary.  
- [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) zamyká spoje.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/) zamyká grafické objekty.  
- [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/) zamyká seskupené tvary.  
- [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) zamyká rámečky obrázků.  

Aby bylo možné použít zamknutí napříč [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/), projděte jeho snímky a nastavte příslušná zamknutí na každém podporovaném tvaru.

## **Použití a odebrání ochrany**

Zamknutí tvarů omezuje operace, jako je výběr, přesun a změna velikosti tvarů. Neznamená to, že je celá prezentace needitovatelná.

### **Použití ochrany na PPTX tvary**

Aspose.Slides for Java poskytuje rozhraní [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) pro práci s tvary na snímku.

Ukázka volá [setSelectLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-) [setPositionLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-) a [setSizeLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) s `true` pro automatické tvary, s ekvivalentními zamknutími pro seskupené tvary, spoje a rámečky obrázků. Spoje používají [setPositionMove](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) pro pohyb; skupiny také používají [setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) aby omezily seskupování.

Ukázka načte existující PPTX prezentaci, zkontroluje tvary v kolekci tvarů každého snímku a uloží kopii s těmito uplatněnými omezeními. Tvary mimo čtyři zpracovávané typy zůstávají beze změny. Smyčka neprochází podřízené tvary uvnitř skupiny.

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

Aby bylo možné odebrat zamknutí tvaru, nastavte jeho hodnotu na `false`. Následující ukázka načte prezentaci se zamknutými tvary a vymaže omezení výběru, pohybu a změny velikosti pomocí [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) a [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/). Také odstraní omezení seskupování předáním `false` metodě [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) a uloží kopii prezentace. Ostatní nastavení zamknutí zůstávají beze změny.

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

Aspose.Slides for Java vám umožňuje omezit konkrétní úpravy jednotlivých tvarů nebo použít stejná omezení napříč snímky. Vyberte zamknutí podporovaná každým typem tvaru a nastavte jejich hodnoty na `false`, když potřebujete tato omezení odebrat.

## **Často kladené otázky**

**Mohu kombinovat zamknutí tvarů a ochranu heslem ve stejné prezentaci?**

Ano. Zamknutí tvarů omezuje konkrétní úpravy, zatímco [password protection](/slides/cs/java/password-protected-presentation/) může omezit otevření nebo úpravy prezentace. Oba můžete použít ve stejném souboru.

**Mohu omezit úpravy konkrétních snímků, aniž by to ovlivnilo ostatní?**

Ano. Aplikujte zamknutí jen na tvary na vybraných snímcích. Tím se nezmění nastavení zamknutí na ostatních snímcích.

**Jak mohu použít zamknutí na jednotlivé tvary uvnitř skupiny?**

Procházejte kolekci vrácenou metodou [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) skupiny a aplikujte příslušná zamknutí na každý podřízený tvar. Tento postup opakujte pro jakékoli vnořené skupiny. Výše uvedené ukázky zpracovávají pouze kolekci tvarů snímku, takže nenastavují zamknutí na jednotlivé členy skupiny.