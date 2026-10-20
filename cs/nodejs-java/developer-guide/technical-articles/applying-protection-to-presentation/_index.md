---
title: Omezit úpravy prezentace pomocí zamknutí tvarů v Node.js
linktitle: Omezit úpravy prezentace
type: docs
weight: 60
url: /cs/nodejs-java/applying-protection-to-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Naučte se, jak zamykat a odemykat tvary v PPTX prezentacích pomocí Aspose.Slides pro Node.js přes Java, aby bylo možné omezit výběr, přesun, změnu velikosti a seskupování."
---
## **Přehled**

Běžné použití Aspose.Slides for Node.js via Java je vytváření, aktualizace a ukládání prezentací PowerPoint (PPTX) jako součást automatizovaného pracovního postupu. Když uživatelé obdrží tyto prezentace, omezení změn tvarů může pomoci zachovat zamýšlené rozložení a obsah.

Tento článek vysvětluje, jak jsou tvary organizovány na snímcích a jak aplikovat a odstranit zamknutí tvarů v PPTX prezentaci. Tato zamknutí vám umožňují omezit konkrétní úpravy jednotlivých tvarů.

## **Složení snímku**

Snímek prezentace se skládá z komponent, jako jsou automatické tvary, tabulky, objekty OLE, seskupené tvary, rámečky obrázků, videorámečky, propojení a další prvky používané k vytvoření prezentace. V Aspose.Slides for Node.js via Java je každý prvek na snímku reprezentován objektem, který dědí od třídy [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/).

Různé typy tvarů nabízejí různé možnosti zamykání. Třída [BaseShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/) je základní třídou pro zamykání tvarů. Aspose.Slides for Node.js via Java poskytuje následující třídy zamykání:

- [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/) zamyká automatické tvary.  
- [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) zamyká tvary propojení.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) zamyká grafické objekty.  
- [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/) zamyká seskupené tvary.  
- [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) zamyká rámečky obrázků.  

Pro aplikaci zamknutí napříč [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/), projděte její snímky a nastavte příslušná zamknutí na každý podporovaný tvar.

## **Aplikace a odebrání ochrany**

Zamknutí tvarů omezují operace, jako je výběr, přesun a změna velikosti tvarů. Neznemožňují úpravy celé prezentace.

### **Aplikace ochrany na PPTX tvary**

Aspose.Slides for Node.js via Java poskytuje třídu [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) pro práci s tvary na snímku.

Příklad volá [setSelectLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setPositionLocked) a [setSizeLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSizeLocked) s hodnotou `true` pro automatické tvary, s ekvivalentními zamknutími pro seskupené tvary, propojení a rámečky obrázků. Propojení používají [setPositionMove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/#setPositionMove) pro pohyb; skupiny také používají [setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked), aby omezily seskupování.

Příklad načte existující PPTX prezentaci, zkontroluje tvary v kolekci tvarů každého snímku a uloží kopii s těmito aplikovanými omezeními. Tvary mimo čtyři zpracovávané typy zůstávají beze změny. Smyčka neprochází podřízené tvary uvnitř skupiny.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const autoShapeLock = shape.getShapeLock();
                autoShapeLock.setPositionLocked(true);
                autoShapeLock.setSelectLocked(true);
                autoShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                const groupShapeLock = shape.getShapeLock();
                groupShapeLock.setGroupingLocked(true);
                groupShapeLock.setPositionLocked(true);
                groupShapeLock.setSelectLocked(true);
                groupShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IConnector")) {
                const connectorShapeLock = shape.getShapeLock();
                connectorShapeLock.setPositionMove(true);
                connectorShapeLock.setSelectLocked(true);
                connectorShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                const pictureFrameLock = shape.getShapeLock();
                pictureFrameLock.setPositionLocked(true);
                pictureFrameLock.setSelectLocked(true);
                pictureFrameLock.setSizeLocked(true);
            }
        }
    }

    presentation.save("ProtectedSample.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Odebrání ochrany**

Pro odebrání zamknutí tvaru nastavte jeho hodnotu na `false`. Následující příklad načte prezentaci se zamknutími tvarů a vymaže omezení výběru, pohybu a změny velikosti pomocí [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) a [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/). Také odstraní omezení seskupování předáním `false` metodě [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) a uloží kopii prezentace. Ostatní nastavení zamknutí zůstávají beze změny.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("ProtectedSample.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const autoShapeLock = shape.getShapeLock();
                autoShapeLock.setPositionLocked(false);
                autoShapeLock.setSelectLocked(false);
                autoShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                const groupShapeLock = shape.getShapeLock();
                groupShapeLock.setGroupingLocked(false);
                groupShapeLock.setPositionLocked(false);
                groupShapeLock.setSelectLocked(false);
                groupShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IConnector")) {
                const connectorShapeLock = shape.getShapeLock();
                connectorShapeLock.setPositionMove(false);
                connectorShapeLock.setSelectLocked(false);
                connectorShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                const pictureFrameLock = shape.getShapeLock();
                pictureFrameLock.setPositionLocked(false);
                pictureFrameLock.setSelectLocked(false);
                pictureFrameLock.setSizeLocked(false);
            }
        }
    }

    presentation.save("RemovedProtectionSample.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Závěr**

Aspose.Slides for Node.js via Java vám umožňuje omezit konkrétní úpravy jednotlivých tvarů nebo aplikovat stejná omezení napříč snímky. Vyberte zamknutí podporovaná pro každý typ tvaru a nastavte jejich hodnoty na `false`, když potřebujete tato omezení odstranit.

## **Často kladené otázky**

**Mohu kombinovat zamknutí tvarů a ochranu heslem ve stejné prezentaci?**

Ano. Zamknutí tvarů omezují konkrétní úpravy, zatímco [ochrana heslem](/slides/cs/nodejs-java/password-protected-presentation/) může omezit otevření nebo úpravu prezentace. Můžete použít obojí ve stejném souboru.

**Mohu omezit úpravy na konkrétních snímcích, aniž by to ovlivnilo ostatní?**

Ano. Aplikujte zamknutí pouze na tvary na vybraných snímcích. To nemění nastavení zamknutí na ostatních snímcích.

**Jak mohu aplikovat zamknutí na jednotlivé tvary uvnitř skupiny?**

Projděte kolekci vrácenou metodou [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) skupiny a aplikujte příslušná zamknutí na každý podřízený tvar. Opakujte to pro všechny vnořené skupiny. Výše uvedené příklady zpracovávají pouze kolekci tvarů snímku, takže nenastavují zamknutí na jednotlivé členy skupiny.