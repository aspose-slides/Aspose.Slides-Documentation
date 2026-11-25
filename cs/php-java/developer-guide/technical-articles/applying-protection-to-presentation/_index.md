---
title: Omezte úpravy prezentace pomocí zámků tvarů v PHP
linktitle: Omezit úpravy prezentace
type: docs
weight: 60
url: /cs/php-java/applying-protection-to-presentation/
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
- PHP
- Aspose.Slides
description: "Naučte se, jak zamknout a odemknout tvary v PPTX prezentacích pomocí Aspose.Slides for PHP via Java, abyste omezili výběr, pohyb, změnu velikosti a seskupování."
---
## **Přehled**

Běžné použití Aspose.Slides for PHP via Java je vytváření, aktualizace a ukládání prezentací PowerPoint (PPTX) jako součást automatizovaného pracovního postupu. Když uživatelé tyto prezentace obdrží, omezení změn tvarů může pomoci zachovat zamýšlené rozvržení a obsah.

Tento článek vysvětluje, jak jsou tvary na snímcích uspořádány a jak použít a odstranit zámky tvarů v PPTX prezentaci. Tyto zámky vám umožňují omezit konkrétní operace úprav na jednotlivých tvarech.

## **Složení snímku**

Snímek prezentace se skládá ze součástí, jako jsou automatické tvary, tabulky, objekty OLE, seskupené tvary, rámečky obrázků, video rámečky, spojnice a další prvky používané k vytvoření prezentace. V Aspose.Slides for PHP via Java je každý prvek na snímku reprezentován objektem, který dědí ze třídy [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/).

Různé typy tvarů nabízejí různé možnosti zamykání. Třída [BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/) je základní třídou pro zámky tvarů. Aspose.Slides for PHP via Java poskytuje následující třídy zámků:

- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/) zamyká automatické tvary.  
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) zamyká tvary spojnic.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) zamyká grafické objekty.  
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/) zamyká seskupené tvary.  
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) zamyká rámečky obrázků.  

Pro použití zámků v celé [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), iterujte přes její snímky a nastavte příslušné zámky na každém podporovaném tvaru.

## **Použít a odebrat ochranu**

Kompatibilní editory prezentací používají zámky tvarů k omezení jednotlivých operací úprav. Šifrování souboru a zabezpečení zápisu na úrovni dokumentu jsou samostatná [nastavení ochrany prezentace](/slides/cs/php-java/password-protected-presentation/).

### **Použít ochranu na tvary PPTX**

Aspose.Slides for PHP via Java poskytuje třídu [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) pro práci s tvary na snímku.

Příklad volá [setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked) a [setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked) s hodnotou `true` pro automatické tvary, s ekvivalentními zámky pro seskupené tvary, spojnice a rámečky obrázků. Spojnice používají [setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove) pro pohyb; skupiny také používají [setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) k omezení seskupování.

Příklad načte existující PPTX prezentaci, zkontroluje tvary v kolekci tvarů každého snímku a uloží kopii s těmito aplikovanými omezeními. Tvary mimo čtyři zpracovávané typy zůstávají nezměněny. Smyčka neprochází podřízené tvary uvnitř skupiny.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        foreach ($slide->getShapes()->toArray() as $shape) {
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setGroupingLocked(true);
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionMove(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            }
        }
    }

    $presentation->save("ProtectedSample.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Odebrat ochranu**

Pro odebrání zámku tvaru nastavte jeho hodnotu na `false`. Následující příklad načte prezentaci se zamčenými tvary a vymaže omezení výběru, pohybu a změny velikosti pomocí [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) a [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/). Také odstraní omezení seskupování předáním `false` do [GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) a uloží kopii prezentace. Ostatní nastavení zámků zůstávají nezměněna.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("ProtectedSample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        foreach ($slide->getShapes()->toArray() as $shape) {
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setGroupingLocked(false);
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionMove(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            }
        }
    }

    $presentation->save("RemovedProtectionSample.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Zachovat oříznutí obrázku**

Umístěte fotografii pojmenovanou `photo.jpg` do pracovního adresáře. Příklad ořízne 12 % zleva a 8 % zprava, poté zavolá [setCropLocked](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/#setCropLocked) na zámku rámečku obrázku. Předání hodnoty `true` omezuje další ořezávání a zachovává existující ořez.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $image = Images::fromFile("photo.jpg");
    try {
        $photo = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $pictureFrame = $shapes->addPictureFrame(ShapeType::Rectangle, 20, 30, 270, 160, $photo);
    $pictureFrame->getPictureFormat()->setCropLeft(12);
    $pictureFrame->getPictureFormat()->setCropRight(8);

    $pictureFrameLock = $pictureFrame->getPictureFrameLock();
    $pictureFrameLock->setAspectRatioLocked(false);
    $pictureFrameLock->setCropLocked(true);

    $presentation->save("PictureLocked.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`PictureLocked.pptx` ukládá zámek oříznutí jako `true`. V PowerPointu je příkaz **Crop** zakázán, když je vybrána fotografie.

### **Udržet diagram seskupený**

Příklad seskupí obdélník a šipku, poté zavolá [setUngroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setUngroupingLocked) na zámku skupiny, aby udržel komponenty diagramu pohromadě. Ostatní úpravy, jako přesunutí skupiny nebo změna výplně komponenty, zůstávají k dispozici.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    
    $groupShape = $shapes->addGroupShape();
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 70, 90, 50);
    $groupShape->getShapes()->addAutoShape(ShapeType::RightArrow, 190, 80, 60, 30);
    $groupShape->getGroupShapeLock()->setUngroupingLocked(true);

    $presentation->save("DiagramLocked.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`DiagramLocked.pptx` ukládá zámek rozdělení jako `true`. V PowerPointu je příkaz **Ungroup** zakázán, když je vybrán celý diagram.

### **Zobrazit existující zámky tvarů**

Pro přezkoumání šablony ji otevřete a přečtěte objekt zámku pro každý tvar. Metoda [getNoLocks](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/#getNoLocks) vrací `true`, když jsou všechny příznaky v objektu vypnuté, a `false`, když je alespoň jeden zapnutý. Skupina a její podřízené prvky mají samostatné objekty zámků, takže prohlédněte podřízené prvky i když skupina nemá žádné zámky.

Tento příklad kontroluje pohyb pro automatické tvary, rámečky obrázků a skupiny. Také kontroluje oříznutí obrázků a rozdělení skupin. Zpráva uvádí povolené příznaky, které rozpozná, a označuje typy tvarů, které neinspektuje.

```php
use aspose\slides\Presentation;

function reportShapeLocks($shapes, $slideNumber, $prefix = "") {
    foreach ($shapes->toArray() as $shape) {
        $path = $prefix . java_values($shape->getName());
        $type = java_values($shape->getClass()->getSimpleName());
        $label = "Slide $slideNumber | $path | $type";
        $flags = [];
        $isGroup = java_instanceof($shape, java("com.aspose.slides.IGroupShape"));

        if ($isGroup) {
            $lock = $shape->getGroupShapeLock();
            if (java_values($lock->getUngroupingLocked())) {
                $flags[] = "UngroupingLocked";
            }
        } elseif (java_instanceof($shape, java("com.aspose.slides.IPictureFrame"))) {
            $lock = $shape->getPictureFrameLock();
            if (java_values($lock->getCropLocked())) {
                $flags[] = "CropLocked";
            }
        } elseif (java_instanceof($shape, java("com.aspose.slides.IAutoShape"))) {
            $lock = $shape->getAutoShapeLock();
        } else {
            echo "$label | Uninspected", PHP_EOL;
            continue;
        }

        if (java_values($lock->getPositionLocked())) {
            $flags[] = "PositionLocked";
        }
        if (!java_values($lock->getNoLocks())) {
            $restrictions = $flags ? implode(", ", $flags) : "Active flag not identified";
            echo "$label | $restrictions", PHP_EOL;
        }

        if ($isGroup) {
            reportShapeLocks($shape->getShapes(), $slideNumber, $path . "/");
        }
    }
}

$presentation = new Presentation("Sample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        reportShapeLocks($slide->getShapes(), java_values($slide->getSlideNumber()));
    }
} finally {
    $presentation->dispose();
}
```

Předpokládejme, že snímek 1 z `Sample.pptx` obsahuje skupinu pojmenovanou `Layout` se zamčeným rozdělením, obrázek pojmenovaný `Photo` uvnitř ní se zamčeným oříznutím a odemčený obdélník pojmenovaný `Free`. Zpráva přeskočí `Free` a vytiskne tyto dva řádky:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Zpráva čte uložené příznaky úprav na úrovni tvaru bez jejich změny nebo uložení prezentace. Zabezpečení zápisu na úrovni dokumentu je samostatné nastavení a vynucení každého příznaku závisí na editoru.

## **Závěr**

Aspose.Slides for PHP via Java vám umožňuje omezit konkrétní operace úprav na jednotlivých tvarech nebo použít stejná omezení napříč snímky. Vyberte zámky podporované každým typem tvaru a nastavte jejich hodnoty na `false`, když potřebujete tato omezení odstranit.

## **Často kladené otázky**

**Mohu kombinovat zámky tvarů a ochranu heslem v jedné prezentaci?**

Ano. Zámky tvarů omezují konkrétní operace úprav, zatímco [ochrana heslem](/slides/cs/php-java/password-protected-presentation/) může omezit otevření nebo úpravu prezentace. Můžete použít obojí v jednom souboru.

**Mohu omezit úpravy na konkrétních snímcích bez ovlivnění ostatních?**

Ano. Zámky aplikujte pouze na tvary na vybraných snímcích. To nemění nastavení zámků na ostatních snímcích.

**Jak mohu použít zámky na jednotlivé tvary uvnitř skupiny?**

Iterujte přes kolekci vrácenou metodou [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) skupiny a aplikujte příslušné zámky na každý podřízený tvar. Opakujte to pro jakékoli vnořené skupiny, podle průchodu v příkladu zprávy.