---
title: Prezentáció szerkesztésének korlátozása formazárakkal PHP-ben
linktitle: Prezentáció szerkesztésének korlátozása
type: docs
weight: 60
url: /hu/php-java/applying-protection-to-presentation/
keywords:
- szerkesztés megakadályozása
- védelem a szerkesztéstől
- forma zárolása
- pozíció zárolása
- kijelölés zárolása
- méretezés zárolása
- csoportosítás zárolása
- PowerPoint
- PPTX
- prezentáció
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan lehet zárolni és feloldani a formákat PPTX prezentációkban az Aspose.Slides for PHP via Java segítségével, hogy korlátozza a kijelölést, mozgatást, méretezést és a csoportosítást."
---
## **Áttekintés**

Az Aspose.Slides for PHP via Java gyakori felhasználása a PowerPoint (PPTX) prezentációk létrehozása, frissítése és mentése egy automatizált munkafolyamat részeként. Amikor a felhasználók megkapják ezeket a prezentációkat, a formák módosításának korlátozása segíthet megőrizni a kívánt elrendezést és tartalmat.

Ez a cikk elmagyarázza, hogyan vannak szervezve a formák a diákon, valamint hogyan lehet alkalmazni és eltávolítani a formazárakat egy PPTX prezentációban. Ezek az zárak lehetővé teszik, hogy egyes szerkesztési műveleteket korlátozzunk az egyedi formákon.

## **A dia összetétele**

Egy prezentációs dia alkotóelemei közé tartoznak az autóformák, táblázatok, OLE‑objektumok, csoportosított formák, képkockák, videokockák, összekötők és egyéb elemek, amelyek a prezentáció építésére szolgálnak. Az Aspose.Slides for PHP via Java‑ban a dia minden elemét egy olyan objektum képviseli, amely a [Alak](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) osztályból származik.

A különböző forma típusok különféle zárolási lehetőségeket biztosítanak. A [BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/) osztály a formazárak alaposztálya. Az Aspose.Slides for PHP via Java a következő zárolási osztályokat kínálja:

- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/) autóformák zárolásához.  
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) összekötőformák zárolásához.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) grafikus objektumok zárolásához.  
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/) csoportosított formák zárolásához.  
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) képkockák zárolásához.  

A zárolások alkalmazásához egy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) objektumban iterálja végig a diákat, és a támogatott formákon állítsa be a megfelelő zárolásokat.

## **Zárolás alkalmazása és eltávolítása**

A kompatibilis prezentációs szerkesztők a formazárakat használják egyedi szerkesztési műveletek korlátozására. A fájl titkosítása és a dokumentumszintű írásvédettség külön [prezentációvédelmi beállítások](/slides/hu/php-java/password-protected-presentation/).

### **Zárolás alkalmazása PPTX formákra**

Az Aspose.Slides for PHP via Java biztosítja a [Alak](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) osztályt a diáknapokon lévő formákkal való munka érdekében.

A példa meghívja a [setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked), a [setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked) és a [setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked) metódusokat `true` értékkel az autóformákra, valamint a megfelelő zárolásokat a csoportosított formákra, összekötőkre és képkockákra. Az összekötők a [setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove) metódust használják a mozgatáshoz; a csoportok továbbá a [setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) metódust alkalmazzák a csoportosítás korlátozására.

A példa betölti a meglévő PPTX prezentációt, ellenőrzi a formákat minden dia forma‑gyűjteményében, és egy másolatot ment a beállított korlátozásokkal. A négy kezelt típuson kívüli formák változatlanul maradnak. A ciklus nem járja be a csoporton belüli gyermekformákat.

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

### **Zárolás eltávolítása**

A formazár eltávolításához állítsa az értékét `false`‑ra. Az alábbi példa betölt egy formazárral ellátott prezentációt, és törli a kiválasztási, mozgási és méretezési korlátozásokat a [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/), a [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/), a [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) és a [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) segítségével. A csoportosítás korlátozást szintén eltávolítja a [GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) `false` argumentummal, majd ment egy másolatot a prezentációból. A többi zárolási beállítás változatlan marad.

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

### **Képvágás megőrzése**

Helyezze a `photo.jpg` nevű képet a munkakönyvtárba. A példa a bal oldalról 12 %‑ot, a jobb oldalról 8 %‑ot vág le, majd meghívja a [setCropLocked](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/#setCropLocked) metódust a képkocka zárolásán. A `true` érték további vágást korlátoz, és megőrzi a már meglévő vágást.

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

A `PictureLocked.pptx` fájlban a vágászár `true` értéken van tárolva. PowerPointban a **Crop** (Vágás) parancs le van tiltva, amikor a képet kijelölik.

### **Diagram csoportosítva tartása**

A példa egy téglalapot és egy nyilat csoportosít, majd a csoport zárolásán a [setUngroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setUngroupingLocked) metódust hívja, hogy a diagram elemei együtt maradjanak. Egyéb szerkesztések, például a csoport mozgatása vagy egy komponens kitöltésének módosítása továbbra is elérhetők.

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

A `DiagramLocked.pptx` fájlban az egyesítés feloldása zárolva van (`true`). PowerPointban a **Ungroup** (Csoport felbontása) parancs le van tiltva, amikor az egész diagram ki van jelölve.

### **Meglévő formazárak jelentése**

Egy sablon áttekintéséhez nyissa meg, és olvassa ki a zárolási objektumot minden egyes formához. A [getNoLocks](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/#getNoLocks) metódus `true`‑t ad vissza, ha az objektum összes jelzője le van tiltva, és `false`‑t, ha legalább egy be van kapcsolva. Egy csoport és annak gyermekei külön zárolási objektummal rendelkeznek, ezért a gyermekeket is ellenőrizze, még ha a csoportnak nincsenek zárjai is.

Ez a példa ellenőrzi a mozgást autóformákon, képkockákon és csoportokon. Emellett ellenőrzi a képek vágását és a csoportok egyesítés feloldását. A jelentés felsorolja a felismert engedélyezett jelzőket, és megjelöli azokat a forma típusokat, amelyeket nem vizsgál.

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

Tegyük fel, hogy a `Sample.pptx` első diáján egy `Layout` nevű csoport van, amelynek a csoportfeloldás zárolva van, a csoporton belül egy `Photo` nevű kép van, amelynek a vágás zárolva van, és egy `Free` nevű, zárolás nélküli téglalap. A jelentés kihagyja a `Free` elemet, és a következő két sort írja ki:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

A jelentés a tárolt forma‑szintű szerkesztési jelzőket olvassa be anélkül, hogy módosítaná vagy mentené a prezentációt. A dokumentumszintű írásvédelem egy külön beállítás, és minden jelző érvényesülését a szerkesztő határozza meg.

### **Összegzés**

Az Aspose.Slides for PHP via Java lehetővé teszi, hogy egyedi szerkesztési műveleteket korlátozzunk egyedi formákon, vagy ugyanazokat a korlátozásokat alkalmazzuk a diákon át. Válassza ki a formatípusonként támogatott zárakat, és állítsa azok értékét `false`‑ra, ha el szeretné távolítani a korlátozásokat.

## **GYIK**

**Kombinálhatom a formazárakat és a jelszóvédelmet ugyanabban a prezentációban?**

Igen. A formazárak bizonyos szerkesztési műveleteket korlátoznak, míg a [jelszóvédelem](/slides/hu/php-java/password-protected-presentation/) korlátozhatja a prezentáció megnyitását vagy módosítását. Mindkettőt használhatja egy fájlban.

**Korlátozhatom a szerkesztést bizonyos diáknál anélkül, hogy a többi érintett lenne?**

Igen. Csak a kiválasztott diák formáira alkalmazza a zárolásokat. Ez nem módosítja a többi dia zárolási beállításait.

**Hogyan alkalmazhatok zárakat egyedi formákra egy csoporton belül?**

Iteráljon a csoport [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) metódusa által visszaadott gyűjteményen, és minden gyermekformára alkalmazza a megfelelő zárakat. Ismételje meg ezt minden beágyazott csoport esetén, a jelentési példában bemutatott bejárás szerint.