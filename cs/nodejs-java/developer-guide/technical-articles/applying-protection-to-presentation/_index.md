---
title: Omezte úpravy prezentace pomocí zámků tvarů v Node.js
linktitle: Omezte úpravy prezentace
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
description: "Naučte se zamykat a odemykat tvary v PPTX prezentacích pomocí Aspose.Slides pro Node.js přes Java a omezit výběr, pohyb, změnu velikosti a seskupování."
---
## **Přehled**

Běžné použití Aspose.Slides pro Node.js přes Java je vytvářet, aktualizovat a ukládat prezentace PowerPoint (PPTX) jako součást automatizovaného pracovního postupu. Když uživatelé tyto prezentace obdrží, omezení změn tvarů může pomoci zachovat zamýšlené rozložení a obsah.

Tento článek vysvětluje, jak jsou tvary na snímcích organizovány a jak v PPTX prezentaci použít a odebrat zámky tvarů. Tyto zámky vám umožňují omezit konkrétní operace úprav u jednotlivých tvarů.

## **Složení snímku**

Snímek prezentace se skládá z komponent, jako jsou automatické tvary, tabulky, OLE objekty, seskupené tvary, rámce obrázků, video rámy, spojnice a další prvky používané k vytvoření prezentace. V Aspose.Slides pro Node.js přes Java je každý prvek na snímku reprezentován objektem, který dědí z třídy [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) .

Různé typy tvarů nabízejí různé možnosti zamykání. Třída [BaseShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/) je základní třída pro zámky tvarů. Aspose.Slides pro Node.js přes Java poskytuje následující třídy zámků:

- [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/) zamyká automatické tvary.  
- [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) zamyká tvary spojnic.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) zamyká grafické objekty.  
- [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/) zamyká seskupené tvary.  
- [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) zamyká rámy obrázků.  

Pro použití zámků v celé [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/), projděte její snímky a nastavte příslušné zámky na každém podporovaném tvaru.

## **Použití a odebrání ochrany**

Kompatibilní editory prezentací používají zámky tvarů k omezení jednotlivých operací úprav. Šifrování souboru a ochrana zápisu na úrovni dokumentu jsou samostatná [nastavení ochrany prezentace](/slides/cs/nodejs-java/password-protected-presentation/).

### **Použití ochrany na tvary PPTX**

Aspose.Slides pro Node.js přes Java poskytuje třídu [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) pro práci s tvary na snímku.

Příklad volá [setSelectLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setPositionLocked) a [setSizeLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSizeLocked) s hodnotou `true` pro automatické tvary, s ekvivalentními zámky pro seskupené tvary, spojnice a rámy obrázků. Spojnice používají [setPositionMove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/#setPositionMove) pro pohyb; skupiny také používají [setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) k omezení seskupování.

Příklad načte existující PPTX prezentaci, zkontroluje tvary v kolekci tvarů každého snímku a uloží kopii s těmito aplikovanými omezeními. Tvary mimo čtyři zpracovávané typy zůstávají nezměněny. Smyčka neprochází podřízené tvary uvnitř skupiny.

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

### **Odebrat ochranu**

Pro odebrání zámku tvaru nastavte jeho hodnotu na `false`. Následující příklad načte prezentaci se zámky tvarů a vymaže omezení výběru, pohybu a změny velikosti pomocí [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) a [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/). Také odstraní omezení seskupování předáním `false` do [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) a uloží kopii prezentace. Ostatní nastavení zámků zůstávají nezměněna.

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

### **Zachovat oříznutí obrázku**

Umístěte fotografii pojmenovanou `photo.jpg` do pracovního adresáře. Příklad ořízne 12 % zleva a 8 % zprava, poté zavolá [setCropLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/#setCropLocked) na zámek rámce obrázku. Předání `true` omezuje další oříznutí a zachová existující oříznutí.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const photoStream = java.newInstanceSync("java.io.FileInputStream", "photo.jpg");
    let photo;
    try {
        photo = presentation.getImages().addImage(photoStream);
    } finally {
        photoStream.close();
    }

    const pictureFrame = shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 30, 270, 160, photo);
    pictureFrame.getPictureFormat().setCropLeft(12);
    pictureFrame.getPictureFormat().setCropRight(8);

    const pictureFrameLock = pictureFrame.getPictureFrameLock();
    pictureFrameLock.setAspectRatioLocked(false);
    pictureFrameLock.setCropLocked(true);

    presentation.save("PictureLocked.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`PictureLocked.pptx` ukládá zámek oříznutí jako `true`. V PowerPointu je příkaz **Crop** zakázán, když je fotografie vybrána.

### **Udržet diagram seskupený**

Příklad seskupí obdélník a šipku, poté zavolá [setUngroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setUngroupingLocked) na zámek skupiny, aby udržel komponenty diagramu pohromadě. Ostatní úpravy, jako přesunutí skupiny nebo změna výplně komponenty, zůstávají k dispozici.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    
    const groupShape = shapes.addGroupShape();
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 70, 90, 50);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.RightArrow, 190, 80, 60, 30);
    groupShape.getGroupShapeLock().setUngroupingLocked(true);

    presentation.save("DiagramLocked.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`DiagramLocked.pptx` ukládá zámek rozdělení jako `true`. V PowerPointu je příkaz **Ungroup** zakázán, když je celý diagram vybrán.

### **Zpráva o existujících zámcích tvarů**

Pro revizi šablony ji otevřete a přečtěte objekt zámku pro každý tvar. Metoda [getNoLocks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/#getNoLocks) vrací `true`, když jsou všechna příznaky v tomto objektu vypnutá, a `false`, když je alespoň jeden zapnutý. Skupina a její podřízené mají samostatné objekty zámků, proto prohlédněte podřízené i když skupina nemá žádné zámky.

Tento příklad kontroluje pohyb pro automatické tvary, rámy obrázků a skupiny. Také kontroluje oříznutí pro obrázky a rozdělení pro skupiny. Zpráva vypisuje rozpoznané aktivní příznaky a označuje typy tvarů, které neprobírá.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function inspectShapes(shapes, slideNumber, prefix) {
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const path = prefix + shape.getName();
        const type = shape.getClass().getSimpleName();
        const label = `Slide ${slideNumber} | ${path} | ${type}`;
        const flags = [];
        const isGroup = java.instanceOf(shape, "com.aspose.slides.IGroupShape");
        let shapeLock;

        if (isGroup) {
            shapeLock = shape.getGroupShapeLock();
            if (shapeLock.getUngroupingLocked()) flags.push("UngroupingLocked");
        } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            shapeLock = shape.getPictureFrameLock();
            if (shapeLock.getCropLocked()) flags.push("CropLocked");
        } else if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            shapeLock = shape.getAutoShapeLock();
        } else {
            console.log(`${label} | Uninspected`);
            continue;
        }

        if (!shapeLock.getNoLocks()) {
            if (shapeLock.getPositionLocked()) flags.push("PositionLocked");
            const restrictions = flags.length ? flags.join(", ") : "Active flag not identified";
            console.log(`${label} | ${restrictions}`);
        }

        if (isGroup) {
            inspectShapes(shape.getShapes(), slideNumber, path + "/");
        }
    }
}

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    const slides = presentation.getSlides();
    for (let i = 0; i < slides.size(); i++) {
        const slide = slides.get_Item(i);
        inspectShapes(slide.getShapes(), slide.getSlideNumber(), "");
    }
} finally {
    presentation.dispose();
}
```

Předpokládejme, že snímek 1 v `Sample.pptx` obsahuje skupinu nazvanou `Layout` se zamčeným rozdělením, obrázek nazvaný `Photo` uvnitř ní se zamčeným oříznutím a odemčený obdélník nazvaný `Free`. Zpráva přeskočí `Free` a vypíše tyto dva řádky:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Zpráva čte uložené příznaky úprav na úrovni tvaru, aniž by je měnila nebo ukládala prezentaci. Ochrana zápisu na úrovni dokumentu je samostatné nastavení a vynucení každého příznaku závisí na editoru.

### **Závěr**

Aspose.Slides pro Node.js přes Java vám umožňuje omezit konkrétní operace úprav u jednotlivých tvarů nebo použít stejné omezení napříč snímky. Vyberte zámky podporované každým typem tvaru a nastavte jejich hodnoty na `false`, když potřebujete tato omezení odebrat.

## **Často kladené otázky**

**Mohu kombinovat zámky tvarů a ochranu heslem ve stejné prezentaci?**

Ano. Zámky tvarů omezují konkrétní operace úprav, zatímco [ochranu heslem](/slides/cs/nodejs-java/password-protected-presentation/) může omezit otevírání nebo úpravu prezentace. Obě můžete použít ve stejném souboru.

**Mohu omezit úpravy na konkrétních snímcích, aniž by to ovlivnilo ostatní?**

Ano. Použijte zámky pouze na tvary na vybraných snímcích. Tím se nezmění nastavení zámků na ostatních snímcích.

**Jak mohu použít zámky na jednotlivé tvary uvnitř skupiny?**

Projděte kolekci vrácenou metodou [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) skupiny a použijte příslušné zámky na každý podřízený tvar. Opakujte to pro všechny vnořené skupiny podle procházení v příkladu zprávy.