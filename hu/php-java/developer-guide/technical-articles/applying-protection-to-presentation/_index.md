---
title: Prezentáció szerkesztésének korlátozása alakzatzárakkal PHP-ben
linktitle: Prezentáció szerkesztésének korlátozása
type: docs
weight: 60
url: /hu/php-java/applying-protection-to-presentation/
keywords:
- szerkesztés megelőzése
- védés a szerkesztéstől
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
description: "Ismerje meg, hogyan lehet zárolni és feloldani az alakzatokat PPTX prezentációkban az Aspose.Slides for PHP via Java segítségével a kiválasztás, mozgatás, átméretezés és csoportosítás korlátozásához."
---
## **Áttekintés**

Az Aspose.Slides for PHP via Java gyakori felhasználása, hogy PowerPoint (PPTX) bemutatókat hozzon létre, frissítsen és mentse egy automatizált munkafolyamat részeként. Amikor a felhasználók megkapják ezeket a bemutatókat, az alakzatok módosításának korlátozása segíthet megőrizni a tervezett elrendezést és tartalmat.

Ez a cikk elmagyarázza, hogyan vannak az alakzatok szervezve a diákon, és hogyan alkalmazhatók és távolíthatók el az alakzatzárak egy PPTX bemutatóban. Ezek a zárak lehetővé teszik, hogy egyes alakzatok specifikus szerkesztési műveleteit korlátozzuk.

## **Dia felépítése**

Egy prezentációs dia olyan összetevőkből áll, mint az automatikus alakzatok, táblázatok, OLE objektumok, csoportosított alakzatok, képkeretek, videókeretek, összekötők és más elemek, amelyeket a bemutató felépítéséhez használnak. Az Aspose.Slides for PHP via Java esetén a dia minden eleme egy olyan objektummal van reprezentálva, amely a [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) osztályból származik.

A különböző alakzattípusok különböző zárolási lehetőségeket biztosítanak. A [BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/) osztály az alakzatzárak alaposztálya. Az Aspose.Slides for PHP via Java a következő zárolási osztályokat biztosítja:

- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/) zárolja az automatikus alakzatokat.  
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) zárolja a csatlakozó alakzatokat.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) zárolja a grafikus objektumokat.  
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/) zárolja a csoportos alakzatokat.  
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) zárolja a képkereteket.  

A zárak alkalmazásához egy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) során iteráljon a diákkal, és állítsa be a megfelelő zárakat minden támogatott alakzaton.

## **Védelem alkalmazása és eltávolítása**

A kompatibilis prezentációs szerkesztők alakzatzárakat használnak az egyedi szerkesztési műveletek korlátozására. A fájl titkosítás és a dokumentumszintű írásvédelme különálló [prezentációvédelmi beállítások](/slides/hu/php-java/password-protected-presentation/).

### **Védelem alkalmazása PPTX alakzatokra**

Az Aspose.Slides for PHP via Java biztosítja a [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) osztályt a dia alakzataival való munkához.

A példa meghívja a [setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked), a [setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked) és a [setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked) metódusokat `true` értékkel az automatikus alakzatoknál, valamint a megfelelő zárakat a csoportos alakzatok, csatlakozók és képkeretek esetén. A csatlakozók a [setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove) metódust használják a mozgatáshoz; a csoportok pedig a [setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) metódust a csoportosítás korlátozásához.

A példa betölt egy meglévő PPTX bemutatót, ellenőrzi az egyes diák alakzatgyűjteményét, és egy másolatot ment el ezekkel a korlátozásokkal. A négy kezelt típuson kívüli alakzatok változatlanok maradnak. A ciklus nem járja be a csoporton belüli gyermekalakzatokat.

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

Az alakzatzár eltávolításához állítsa az értékét `false`-ra. A következő példa betölt egy prezentációt alakzatzárakkal, és törli a kiválasztás, mozgatás és átméretezés korlátozásait a [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/), a [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/), a [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) és a [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) segítségével. A csoportosítás korlátozását is eltávolítja, ha `false`-t ad át a [GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) metódusnak, majd ment egy másolatot a prezentációról. A többi zár beállítás változatlan marad.

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

### **Kép vágásának megőrzése**

Helyezzen egy `photo.jpg` nevű fényképet a munkakönyvtárba. A példa 12%-ot vág le balról és 8%-ot jobbról, majd meghívja a [setCropLocked](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/#setCropLocked) metódust a képkeret zárolásán. `true` átadása korlátozza a további vágást és megőrzi a meglévő vágást.

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

`PictureLocked.pptx` a vágászárat `true` értékként tárolja. PowerPointban a **Vágás** parancs le van tiltva, amikor a fénykép ki van választva.

### **Diagram csoportosítva tartása**

A példa egy téglalapot és egy nyilat csoportosít, majd meghívja a [setUngroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setUngroupingLocked) metódust a csoport zárolásán, hogy a diagram komponensei együtt maradjanak. A többi szerkesztés, például a csoport mozgatása vagy egy komponens kitöltésének módosítása, továbbra is elérhető.

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

`DiagramLocked.pptx` a csoportosítás felbontásának zárolását `true` értékként tárolja. PowerPointban a **Csoport felbontása** parancs le van tiltva, amikor az egész diagram ki van választva.

### **Összefoglalás**

Az Aspose.Slides for PHP via Java lehetővé teszi, hogy egyes alakzatok specifikus szerkesztési műveleteit korlátozza, vagy ugyanazokat a korlátozásokat alkalmazza a diákon át. Válassza ki az egyes alakzattípusok által támogatott zárakat, és állítsa az értéküket `false`-ra, ha el kell távolítani ezeket a korlátozásokat.

## **GYIK**

**Össze tudom-e kombinálni az alakzatzárakat és a jelszóvédelmet ugyanabban a bemutatóban?**

Igen. Az alakzatzárak specifikus szerkesztési műveleteket korlátoznak, míg a [jelszóvédelem](/slides/hu/php-java/password-protected-presentation/) szabályozhatja a bemutató megnyitását vagy módosítását. Mindkettőt használhatja ugyanabban a fájlban.

**Korlátozhatom-e a szerkesztést konkrét diákon anélkül, hogy másokat befolyásolnék?**

Igen. Csak a kiválasztott diákon lévő alakzatokra alkalmazza a zárakat. Ez nem módosítja a többi dia zárbeállításait.

**Hogyan alkalmazhatok zárakat egyes alakzatokra egy csoporton belül?**

Iteráljon a csoport [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) metódusa által visszaadott gyűjteményen, és alkalmazza a megfelelő zárakat minden gyermekalakzatra. Ismételje meg ezt a beágyazott csoportok esetén is. A fenti példák csak a dia alakzatgyűjjtőén dolgozzák fel, ezért nem állítanak be zárakat az egyes csoporttagokra.