---
title: Prezentáció szerkesztésének korlátozása alakzatzárolásokkal PHP-ben
linktitle: Prezentáció szerkesztésének korlátozása
type: docs
weight: 60
url: /hu/php-java/applying-protection-to-presentation/
keywords:
- szerkesztés megakadályozása
- védelem a szerkesztéstől
- alakzat zárolása
- pozíció zárolása
- kiválasztás zárolása
- átméretezés zárolása
- csoportosítás zárolása
- PowerPoint
- PPTX
- prezentáció
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan zárolhat és feloldhat alakzatokat PPTX prezentációkban az Aspose.Slides for PHP via Java segítségével, hogy korlátozza a kiválasztást, mozgatást, átméretezést és csoportosítást."
---
## **Áttekintés**

Az Aspose.Slides for PHP via Java gyakori felhasználása a PowerPoint (PPTX) prezentációk létrehozása, frissítése és mentése automatizált munkafolyamat részeként. Amikor a felhasználók megkapják ezeket a prezentációkat, az alakzatok módosításának korlátozása segíthet megőrizni a kívánt elrendezést és tartalmat.

Ez a cikk elmagyarázza, hogyan vannak az alakzatok elrendezve a diaokon, és hogyan lehet alkalmazni és eltávolítani az alakzatzárolásokat egy PPTX prezentációban. Ezek a zárolások lehetővé teszik, hogy egyes alakzatokon korlátozzuk a specifikus szerkesztési műveleteket.

## **Dia felépítése**

Egy prezentációs dia olyan komponensekből áll, mint az autoshape-ek, táblázatok, OLE-objektumok, csoportosított alakzatok, képkockák, videokockák, összekötők és egyéb elemek, amelyeket a prezentáció építéséhez használnak. Az Aspose.Slides for PHP via Java-ban a dia minden eleme egy olyan objektummal van reprezentálva, amely a [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) osztályból származik.

A különböző alakzat típusok különböző zárolási opciókat biztosítanak. A [BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/) osztály a alakzatzárolások alaposztálya. Az Aspose.Slides for PHP via Java a következő zárolási osztályokat kínálja:

- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/) zárolja az autoshape-eket.  
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) zárolja a csatlakozó alakzatokat.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) zárolja a grafikus objektumokat.  
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/) zárolja a csoportosított alakzatokat.  
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) zárolja a képkockákat.  

A [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) során a zárolások alkalmazásához iteráljunk a diákon, és állítsuk be a megfelelő zárolásokat minden támogatott alakzatra.

## **Védelem alkalmazása és eltávolítása**

Az alakzatzárolások korlátozzák a műveleteket, mint például az alakzatok kiválasztása, mozgatása és átméretezése. Nem teszik a teljes prezentációt szerkeszthetetlenné.

### **Védelem alkalmazása PPTX alakzatokra**

Az Aspose.Slides for PHP via Java a [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) osztályt biztosítja a dián lévő alakzatok kezeléséhez.

A példa meghívja a [setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked) és a [setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked) metódusokat `true` értékkel az autoshape-eknél, valamint a megfelelő zárolásokat a csoportosított alakzatok, csatlakozók és képkockák esetén. A csatlakozók a [setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove) metódust használják a mozgatáshoz; a csoportok pedig a [setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) metódust is alkalmazzák a csoportosítás korlátozásához.

A példa betölti a meglévő PPTX prezentációt, ellenőrzi az egyes diák alakzatgyűjtését, és egy másolatot ment a alkalmazott korlátozásokkal. A négy kezelt típuson kívül eső alakzatok változatlanok maradnak. A ciklus nem járja be a csoporton belüli gyermekalakzatokat.

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

### **Védelem eltávolítása**

Az alakzatzárolás eltávolításához állítsa az értékét `false`-ra. A következő példa betölt egy prezentációt alakzatzárolásokkal, és a [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) és [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) segítségével törli a kiválasztás, mozgatás és átméretezés korlátozásait. Emellett a csoportosítási korlátozást is eltávolítja, ha `false` értéket ad át a [GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) metódusnak, és a prezentáció egy másolatát menti. A többi zárolási beállítás változatlan marad.

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

### **Összegzés**

Az Aspose.Slides for PHP via Java lehetővé teszi, hogy bizonyos szerkesztési műveleteket korlátozzon egyes alakzatokon vagy ugyanazokat a korlátozásokat alkalmazza a diákon keresztül. Válassza ki az egyes alakzat típusok által támogatott zárolásokat, és állítsa értéküket `false`-ra, ha el szeretné távolítani ezeket a korlátozásokat.

## **GYIK**

**Kombinálhatom a shape zárolásokat és a jelszóvédelmet ugyanabban a prezentációban?**

Igen. A shape zárolások bizonyos szerkesztési műveleteket korlátoznak, míg a [jelszóvédelem](/slides/hu/php-java/password-protected-presentation/) korlátozhatja a prezentáció megnyitását vagy módosítását. Mindkettőt használhatja ugyanabban a fájlban.

**Korlátozhatom a szerkesztést bizonyos diaokon, anélkül, hogy a többit befolyásolnám?**

Igen. Csak a kiválasztott diák alakzatain alkalmazza a zárolásokat. Ez nem változtatja meg a többi dia zárolási beállításait.

**Hogyan alkalmazhatok zárolásokat egyes alakzatokra egy csoporton belül?**

Iteráljon a csoport [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) metódusa által visszaadott gyűjteményen, és alkalmazza a megfelelő zárolásokat minden gyermekalakzatra. Ismételje ezt bármely beágyazott csoport esetén. A fenti példák csak a dia alakzatgyűjteményét dolgozzák fel, ezért nem állítanak be zárolásokat egyes csoporttagokra.