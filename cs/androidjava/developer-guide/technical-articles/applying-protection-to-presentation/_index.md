---
title: Omezte úpravy prezentace pomocí zamykání tvarů na Androidu
linktitle: Omezte úpravy prezentace
type: docs
weight: 60
url: /cs/androidjava/applying-protection-to-presentation/
keywords:
- zabránit úpravám
- ochránit před úpravami
- zamknout tvar
- zamknout polohu
- zamknout výběr
- zamknout změnu velikosti
- zamknout seskupování
- PowerPoint
- PPTX
- prezentace
- Android
- Java
- Aspose.Slides
description: "Naučte se zamykat a odemykat tvary v PPTX prezentacích pomocí Aspose.Slides pro Android prostřednictvím Javy, abyste omezili výběr, pohyb, změnu velikosti a seskupování."
---
## **Přehled**

Běžné použití Aspose.Slides pro Android prostřednictvím Javy je vytvářet, aktualizovat a ukládat prezentace PowerPoint (PPTX) jako součást automatizovaného pracovního postupu. Když uživatelé tyto prezentace obdrží, omezení změn tvarů může pomoci zachovat zamýšlené rozložení a obsah.

Tento článek vysvětluje, jak jsou tvary organizovány na snímcích a jak aplikovat a odebrat zamykání tvarů v PPTX prezentaci. Tato zamknutí vám umožňují omezit konkrétní operace úprav na jednotlivých tvarech.

## **Složení snímku**

Snímek prezentace se skládá ze součástí, jako jsou automatické tvary, tabulky, OLE objekty, seskupené tvary, rámečky obrázků, video rámečky, spojnice a další prvky používané k tvorbě prezentace. V Aspose.Slides pro Android prostřednictvím Javy je každý prvek na snímku reprezentován objektem, který implementuje rozhraní [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) nebo dědí z třídy, která to dělá.

Různé typy tvarů nabízejí různé možnosti zamknutí. Rozhraní [IBaseShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/) je základním rozhraním pro zamykání tvarů. Aspose.Slides pro Android prostřednictvím Javy poskytuje následující rozhraní zamykání:

- [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/) zamyká automatické tvary.  
- [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) zamyká tvary spojnic.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) zamyká grafické objekty.  
- [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/) zamyká seskupené tvary.  
- [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) zamyká rámečky obrázků.  

Pro aplikaci zamykání napříč [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/), projděte její snímky a nastavte příslušná zamknutí na každém podporovaném tvaru.

## **Použití a odebrání ochrany**

Kompatibilní editory prezentací používají zamykání tvarů k omezení jednotlivých operací úprav. Šifrování souborů a ochrana zápisu na úrovni dokumentu jsou oddělená [nastavení ochrany prezentace](/slides/cs/androidjava/password-protected-presentation/).

### **Použít ochranu na PPTX tvary**

Aspose.Slides pro Android prostřednictvím Javy poskytuje rozhraní [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) pro práci s tvary na snímku.

Příklad volá [setSelectLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-), [setPositionLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-), a [setSizeLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) s `true` pro automatické tvary, s ekvivalentními zamykáními pro seskupené tvary, spojnice a rámečky obrázků. Spojnice používají [setPositionMove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) pro pohyb; skupiny také používají [setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) k omezení seskupování.

Příklad načte existující PPTX prezentaci, zkontroluje tvary v kolekci tvarů každého snímku a uloží kopii s těmito omezeními aplikovanými. Tvary mimo čtyři zpracovávané typy zůstávají nezměněny. Smyčka neprochází podřízené tvary uvnitř skupiny.

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

### **Odebrat ochranu**

Chcete-li odebrat zamykání tvaru, nastavte jeho hodnotu na `false`. Následující příklad načte prezentaci se zamknutými tvary a vymaže omezení výběru, pohybu a změny velikosti pomocí [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/), a [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/). Také odstraní omezení seskupování předáním `false` metodě [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) a uloží kopii prezentace. Ostatní nastavení zamykání zůstávají nezměněna.

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

### **Zachovat oříznutí obrázku**

Umístěte fotografii pojmenovanou `photo.jpg` do pracovního adresáře. Příklad ořízne 12 % zleva a 8 % zprava, poté zavolá [setCropLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/#setCropLocked-boolean-) na zamčení rámečku obrázku. Předání `true` omezuje další ořezávání a zachovává existující ořez.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IPPImage photo;
    try (FileInputStream input = new FileInputStream("photo.jpg")) {
        photo = presentation.getImages().addImage(input);
    }

    IPictureFrame pictureFrame = shapes.addPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo);
    pictureFrame.getPictureFormat().setCropLeft(12);
    pictureFrame.getPictureFormat().setCropRight(8);

    IPictureFrameLock pictureFrameLock = pictureFrame.getPictureFrameLock();
    pictureFrameLock.setAspectRatioLocked(false);
    pictureFrameLock.setCropLocked(true);

    presentation.save("PictureLocked.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`PictureLocked.pptx` ukládá zamknutí ořezu jako `true`. V PowerPointu je příkaz **Crop** zakázán, když je vybrána fotografie.

### **Udržet diagram seskupený**

Příklad seskupí obdélník a šipku, poté zavolá [setUngroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setUngroupingLocked-boolean-) na zamknutí skupiny, aby komponenty diagramu zůstaly pohromadě. Ostatní úpravy, jako přesunutí skupiny nebo změna výplně komponenty, zůstávají dostupné.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IGroupShape groupShape = shapes.addGroupShape();
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 100, 70, 90, 50);
    groupShape.getShapes().addAutoShape(ShapeType.RightArrow, 190, 80, 60, 30);
    groupShape.getGroupShapeLock().setUngroupingLocked(true);

    presentation.save("DiagramLocked.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`DiagramLocked.pptx` ukládá zamknutí rozdělení jako `true`. V PowerPointu je příkaz **Ungroup** zakázán, když je vybrán celý diagram.

### **Zpráva o existujících zamknutích tvarů**

Pro revizi šablony ji otevřete a přečtěte objekt zamčení pro každý tvar. Metoda [getNoLocks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/#getNoLocks--) vrací `true`, když jsou všechny příznaky na tomto objektu vypnuté, a `false`, když je alespoň jeden zapnutý. Skupina a její podřízené mají samostatné objekty zamčení, takže prohlédněte podřízené i když skupina nemá žádné zamknutí.

Tento příklad kontroluje pohyb pro automatické tvary, rámečky obrázků a skupiny. Také kontroluje ořezávání pro obrázky a rozdělení pro skupiny. Zpráva vypisuje povolené příznaky, které rozpozná, a označuje typy tvarů, které neinspektuje.

```java
import com.aspose.slides.*;
import android.text.TextUtils;
import java.util.ArrayList;
import java.util.List;

class ShapeLockReport {
    void inspect(IShapeCollection shapes, int slideNumber, String prefix) {
        for (IShape shape : shapes) {
            String path = prefix + shape.getName();
            String label = "Slide " + slideNumber + " | " + path + " | " + shape.getClass().getSimpleName();
            List<String> flags = new ArrayList<>();
            IBaseShapeLock shapeLock;

            if (shape instanceof IGroupShape) {
                IGroupShapeLock groupLock = ((IGroupShape) shape).getGroupShapeLock();
                shapeLock = groupLock;
                if (groupLock.getUngroupingLocked()) flags.add("UngroupingLocked");
                if (groupLock.getPositionLocked()) flags.add("PositionLocked");
            } else if (shape instanceof IPictureFrame) {
                IPictureFrameLock pictureLock = ((IPictureFrame) shape).getPictureFrameLock();
                shapeLock = pictureLock;
                if (pictureLock.getCropLocked()) flags.add("CropLocked");
                if (pictureLock.getPositionLocked()) flags.add("PositionLocked");
            } else if (shape instanceof IAutoShape) {
                IAutoShapeLock autoShapeLock = ((IAutoShape) shape).getAutoShapeLock();
                shapeLock = autoShapeLock;
                if (autoShapeLock.getPositionLocked()) flags.add("PositionLocked");
            } else {
                System.out.println(label + " | Uninspected");
                continue;
            }

            if (!shapeLock.getNoLocks()) {
                String restrictions = !flags.isEmpty() ? TextUtils.join(", ", flags) : "Active flag not identified";
                System.out.println(label + " | " + restrictions);
            }

            if (shape instanceof IGroupShape) {
                inspect(((IGroupShape) shape).getShapes(), slideNumber, path + "/");
            }
        }
    }
}

ShapeLockReport report = new ShapeLockReport();
Presentation presentation = new Presentation("Sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        report.inspect(slide.getShapes(), slide.getSlideNumber(), "");
    }
} finally {
    presentation.dispose();
}
```

Předpokládejme, že snímek 1 souboru `Sample.pptx` obsahuje skupinu pojmenovanou `Layout` s uzamčeným rozdělením, obrázek pojmenovaný `Photo` uvnitř ní s uzamčeným ořezáním a odemčený obdélník pojmenovaný `Free`. Zpráva přeskočí `Free` a vypíše tyto dva řádky:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Zpráva čte uložené příznaky úprav na úrovni tvaru, aniž by je měnila nebo ukládala prezentaci. Ochrana zápisu na úrovni dokumentu je samostatné nastavení a vynucení každého příznaku závisí na editoru.

### **Závěr**

Aspose.Slides pro Android prostřednictvím Javy vám umožňuje omezit konkrétní operace úprav na jednotlivých tvarech nebo použít stejná omezení napříč snímky. Vyberte zamknutí podporovaná každým typem tvaru a nastavte jejich hodnoty na `false`, když potřebujete tato omezení odebrat.

## **Často kladené otázky**

**Mohu kombinovat zamykání tvarů a ochranu heslem ve stejné prezentaci?**

Ano. Zamykání tvarů omezuje konkrétní operace úprav, zatímco [ochranu heslem](/slides/cs/androidjava/password-protected-presentation/) může omezit otevírání nebo úpravy prezentace. Můžete používat oba ve stejném souboru.

**Mohu omezit úpravy na konkrétních snímcích bez ovlivnění ostatních?**

Ano. Aplikujte zamykání pouze na tvary na vybraných snímcích. Toto nezmění nastavení zamykání na ostatních snímcích.

**Jak mohu aplikovat zamykání na jednotlivé tvary uvnitř skupiny?**

Projděte kolekci vrácenou metodou [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) skupiny a aplikujte příslušná zamknutí na každý podřízený tvar. Opakujte to pro jakékoli vnořené skupiny, podle průchodu v příkladu zprávy.