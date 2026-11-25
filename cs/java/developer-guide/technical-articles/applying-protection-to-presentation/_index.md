---
title: Omezte úpravy prezentace zamčením tvarů v Javě
linktitle: Omezit úpravy prezentace
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
description: "Zjistěte, jak zamykat a odemykat tvary v PPTX prezentacích pomocí Aspose.Slides for Java, abyste omezili výběr, pohyb, změnu velikosti a seskupování."
---
## **Pozadí**

Běžné využití Aspose.Slides for Java je vytvářet, aktualizovat a ukládat prezentace PowerPoint (PPTX) jako součást automatizovaného pracovního postupu. Když uživatelé obdrží tyto prezentace, omezení změn tvarů může pomoci zachovat zamýšlené rozvržení a obsah.

Tento článek popisuje, jak jsou tvary na snímcích organizovány a jak v PPTX prezentaci použít a odebrat zamykání tvarů. Tato zamknutí vám umožňují omezit konkrétní operace úprav na jednotlivých tvarech.

## **Složení snímku**

Prezentační snímek je složen z komponent, jako jsou automatické tvary, tabulky, OLE objekty, seskupené tvary, rámy obrázků, video rámy, propojení a další prvky používané k vytvoření prezentace. V Aspose.Slides for Java je každý prvek na snímku reprezentován objektem, který implementuje rozhraní [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) nebo dědí z třídy, která to dělá.

Různé typy tvarů nabízejí různé možnosti zamykání. Rozhraní [IBaseShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/) je základním rozhraním pro zamykání tvarů. Aspose.Slides for Java poskytuje následující rozhraní zamykání:

- [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/) zamyká automatické tvary.  
- [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) zamyká tvary propojení.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/) zamyká grafické objekty.  
- [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/) zamyká skupinové tvary.  
- [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) zamyká rámy obrázků.  

Pro aplikaci zamykání napříč [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) iterujte přes její snímky a nastavte příslušná zamknutí na každý podporovaný tvar.

## **Aplikace a odebrání ochrany**

Kompatibilní editory prezentací používají zamykání tvarů k omezení jednotlivých operací úprav. Šifrování souborů a ochrana zápisu na úrovni dokumentu jsou samostatná [nastavení ochrany prezentace](/slides/cs/java/password-protected-presentation/).

### **Aplikace ochrany na PPTX tvary**

Aspose.Slides for Java poskytuje rozhraní [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) pro práci s tvary na snímku.

Příklad volá [setSelectLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-), [setPositionLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-) a [setSizeLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) s hodnotou `true` pro automatické tvary, s ekvivalentními zamknutími pro skupinové tvary, propojení a rámy obrázků. Propojení používají [setPositionMove](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) pro pohyb; skupiny také používají [setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) k omezení seskupování.

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

### **Odebrání ochrany**

Pro odebrání zamknutí tvaru nastavte jeho hodnotu na `false`. Následující příklad načte prezentaci se zamknutími tvarů a vymaže omezení výběru, pohybu a změny velikosti prostřednictvím [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) a [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/). Také odstraní omezení seskupování předáním `false` metodě [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) a uloží kopii prezentace. Ostatní nastavení zamykání zůstávají nezměněna.

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

### **Zachování ořezu obrázku**

Umístěte fotografii s názvem `photo.jpg` do pracovního adresáře. Příklad ořízne 12 % zleva a 8 % zprava, poté zavolá [setCropLocked](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/#setCropLocked-boolean-) na zamykání rámce obrázku. Předání hodnoty `true` omezuje další ořezávání a zachovává existující ořez.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    byte[] photoBytes = Files.readAllBytes(Paths.get("photo.jpg"));
    IPPImage photo = presentation.getImages().addImage(photoBytes);

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

`PictureLocked.pptx` ukládá zamknutí ořezu jako `true`. V PowerPointu je příkaz **Crop** vypnutý, když je vybrán obrázek.

### **Udržení diagramu seskupeného**

Příklad seskupí obdélník a šipku a poté zavolá [setUngroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setUngroupingLocked-boolean-) na zamykání skupiny, aby komponenty diagramu zůstaly pohromadě. Ostatní úpravy, jako je přesunutí skupiny nebo změna výplně komponenty, zůstávají dostupné.

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

`DiagramLocked.pptx` ukládá zamknutí rozdělení jako `true`. V PowerPointu je příkaz **Ungroup** vypnutý, když je vybrán celý diagram.

### **Zpráva o existujících zamknutích tvarů**

Pro přezkoumání šablony ji otevřete a přečtěte objekt zamykání pro každý tvar. Metoda [getNoLocks](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/#getNoLocks--) vrací `true`, když jsou na tomto objektu vypnuté všechny příznaky, a `false`, když je alespoň jeden povolen. Skupina a její podřízené položky mají samostatné objekty zamykání, takže kontrolujte podřízené i když skupina nemá žádná zamknutí.

Tento příklad kontroluje pohyb u automatických tvarů, rámců obrázků a skupin. Také kontroluje ořez u obrázků a rozdělování u skupin. Zpráva uvádí povolené příznaky, které rozpozná, a označuje typy tvarů, které neprozkoumává.

```java
import com.aspose.slides.*;
import java.util.StringJoiner;

class ShapeLockReport {
    void inspect(IShapeCollection shapes, int slideNumber, String prefix) {
        for (IShape shape : shapes) {
            String path = prefix + shape.getName();
            String label = "Slide " + slideNumber + " | " + path + " | " + shape.getClass().getSimpleName();
            StringJoiner flags = new StringJoiner(", ");
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
                String restrictions = flags.length() > 0 ? flags.toString() : "Active flag not identified";
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

Předpokládejme, že snímek 1 souboru `Sample.pptx` obsahuje skupinu s názvem `Layout` s uzamčeným rozdělením, obrázek s názvem `Photo` uvnitř ní s uzamčeným ořezem a odemčený obdélník s názvem `Free`. Zpráva přeskočí `Free` a vypíše tyto dva řádky:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Zpráva čte uložené příznaky úprav na úrovni tvaru, aniž by je měnila nebo ukládala prezentaci. Ochrana zápisu na úrovni dokumentu je samostatné nastavení a vynucení každého příznaku závisí na editoru.

### **Závěr**

Aspose.Slides for Java vám umožňuje omezit konkrétní operace úprav na jednotlivých tvarech nebo aplikovat stejná omezení napříč snímky. Vyberte zamykání podporovaná každým typem tvaru a nastavte jejich hodnoty na `false`, když potřebujete tato omezení odebrat.

## **Často kladené otázky**

**Mohu kombinovat zamykání tvarů a ochranu heslem ve stejné prezentaci?**

Ano. Zamykání tvarů omezuje konkrétní operace úprav, zatímco [ochranu heslem](/slides/cs/java/password-protected-presentation/) může omezit otevírání nebo úpravu prezentace. Obě můžete použít ve stejném souboru.

**Mohu omezit úpravy na konkrétních snímcích, aniž bych ovlivnil ostatní?**

Ano. Aplikujte zamykání pouze na tvary na vybraných snímcích. Toto nezmění nastavení zamykání na ostatních snímcích.

**Jak mohu aplikovat zamykání na jednotlivé tvary uvnitř skupiny?**

Projděte kolekci vrácenou metodou [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) skupiny a aplikujte příslušná zamykání na každý podřízený tvar. Opakujte to pro všechny vnořené skupiny podle průchodu v příkladu zprávy.