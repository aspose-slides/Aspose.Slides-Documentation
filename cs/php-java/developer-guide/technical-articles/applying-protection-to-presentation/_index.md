---
title: Omezte úpravy prezentace pomocí zamykání tvarů v PHP
linktitle: Omezit úpravy prezentace
type: docs
weight: 60
url: /cs/php-java/applying-protection-to-presentation/
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
- PHP
- Aspose.Slides
description: "Naučte se, jak zamknout a odemknout tvary v PPTX prezentacích pomocí Aspose.Slides for PHP via Java k omezení výběru, pohybu, změny velikosti a seskupování."
---
## **Přehled**

Běžné využití Aspose.Slides for PHP via Java je vytvářet, aktualizovat a ukládat prezentace PowerPoint (PPTX) jako součást automatizovaného pracovního postupu. Když uživatelé tyto prezentace obdrží, omezení změn tvarů může pomoci zachovat zamýšlené rozložení a obsah.

Tento článek vysvětluje, jak jsou tvary na snímcích organizovány a jak použít a odstranit zamykání tvarů v PPTX prezentaci. Tato zamknutí vám umožní omezit konkrétní operace úprav na jednotlivých tvarech.

## **Složení snímku**

Snímek prezentace se skládá z komponent, jako jsou automatické tvary, tabulky, objekty OLE, seskupené tvary, rámečky obrázků, video rámečky, spojnice a další prvky používané k vytvoření prezentace. V Aspose.Slides for PHP via Java je každý prvek na snímku reprezentován objektem, který dědí ze třídy [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) .

Různé typy tvarů nabízejí různé možnosti zamykání. Třída [BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/) je základní třída pro zamykání tvarů. Aspose.Slides for PHP via Java poskytuje následující třídy zamykání:

- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/) zamyká automatické tvary.  
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) zamyká tvary spojnic.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) zamyká grafické objekty.  
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/) zamyká seskupené tvary.  
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) zamyká rámečky obrázků.  

Pro použití zamykání napříč [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), projděte jeho snímky a nastavte příslušná zamknutí na každém podporovaném tvaru.

## **Použití a odebrání ochrany**

Kompatibilní editory prezentací používají zamykání tvarů k omezení jednotlivých operací úprav. Šifrování souboru a ochrana zápisu na úrovni dokumentu jsou samostatné [nastavení ochrany prezentace](/slides/cs/php-java/password-protected-presentation/).

### **Použití ochrany na tvary PPTX**

Aspose.Slides for PHP via Java poskytuje třídu [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) pro práci s tvary na snímku.

Příklad volá [setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked) a [setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked) s hodnotou `true` pro automatické tvary, s ekvivalentními zamknutími pro seskupené tvary, spojnice a rámečky obrázků. Spojnice používají [setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove) pro pohyb; skupiny také používají [setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) k omezení seskupování.

Příklad načte existující PPTX prezentaci, zkontroluje tvary v kolekci tvarů každého snímku a uloží kopii s těmito uplatněnými omezeními. Tvary mimo čtyři zpracovávané typy zůstanou beze změny. Smyčka neprochází podřízené tvary uvnitř skupiny.

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

### **Odebrání ochrany**

Pro odebrání zamknutí tvaru nastavte jeho hodnotu na `false`. Následující příklad načte prezentaci se zamknutými tvary a vymaže omezení výběru, pohybu a změny velikosti pomocí [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) a [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/). Také odstraní omezení seskupování předáním `false` metodě [GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) a uloží kopii prezentace. Ostatní nastavení zamykání zůstávají beze změny.

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

### **Zachování ořezu obrázku**

Umístěte fotografii pojmenovanou `photo.jpg` do pracovního adresáře. Příklad ořízne 12% z levé strany a 8% z pravé, poté zavolá [setCropLocked](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/#setCropLocked) na zamykání rámečku obrázku. Předání `true` omezuje další ořez a zachovává existující ořez.

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

`PictureLocked.pptx` ukládá zamknutí ořezu jako `true`. V PowerPointu je příkaz **Crop** zakázán, když je fotografie vybrána.

### **Udržet diagram seskupený**

Příklad seskupí obdélník a šipku, poté zavolá [setUngroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setUngroupingLocked) na zamykání skupiny, aby komponenty diagramu zůstaly pohromadě. Ostatní úpravy, jako přesun skupiny nebo změna výplně komponenty, zůstávají dostupné.

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

`DiagramLocked.pptx` ukládá zamknutí rozdělení jako `true`. V PowerPointu je příkaz **Ungroup** zakázán, když je celý diagram vybrán.

### **Závěr**

Aspose.Slides for PHP via Java vám umožní omezit konkrétní operace úprav na jednotlivých tvarech nebo použít stejná omezení napříč snímky. Vyberte zamknutí podporovaná každým typem tvaru a nastavte jejich hodnoty na `false`, když potřebujete tato omezení odstranit.

## **Často kladené otázky**

**Mohu kombinovat zamykání tvarů a ochranu heslem ve stejné prezentaci?**

Ano. Zamykání tvarů omezuje konkrétní operace úprav, zatímco [ochranu heslem](/slides/cs/php-java/password-protected-presentation/) může omezit otevírání nebo úpravu prezentace. Obě můžete použít ve stejném souboru.

**Mohu omezit úpravy na konkrétních snímcích, aniž by to ovlivnilo ostatní?**

Ano. Použijte zamknutí pouze na tvary na vybraných snímcích. Toto nezmění nastavení zamknutí na ostatních snímcích.

**Jak mohu použít zamykání na jednotlivé tvary uvnitř skupiny?**

Projděte kolekci vrácenou metodou [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) skupiny a použijte příslušná zamknutí na každý podřízený tvar. Opakujte to pro všechny vnořené skupiny. Výše uvedené příklady zpracovávají pouze kolekci tvarů snímku, takže nenastavují zamknutí na jednotlivé členy skupiny.