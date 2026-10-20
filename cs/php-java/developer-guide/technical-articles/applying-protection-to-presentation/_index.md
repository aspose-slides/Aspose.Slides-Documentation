---
title: Omezte úpravy prezentace pomocí zamykání tvarů v PHP
linktitle: Omezte úpravy prezentace
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
description: "Naučte se, jak zamykat a odemykat tvary v PPTX prezentacích pomocí Aspose.Slides pro PHP via Java, aby bylo možné omezit výběr, přesun, změnu velikosti a seskupování."
---
## **Přehled**

Běžné použití Aspose.Slides for PHP via Java je vytváření, aktualizace a ukládání prezentací PowerPoint (PPTX) jako součást automatizovaného pracovního postupu. Když uživatelé obdrží tyto prezentace, omezení změn tvarů může pomoci zachovat zamýšlené rozvržení a obsah.

Tento článek vysvětluje, jak jsou tvary organizovány na snímcích a jak aplikovat a odebrat zamykání tvarů v PPTX prezentaci. Tato zamknutí vám umožňují omezit konkrétní editační operace u jednotlivých tvarů.

## **Složení snímku**

Snímek prezentace se skládá z komponent, jako jsou automatické tvary, tabulky, objekty OLE, seskupené tvary, rámečky obrázků, rámečky videa, konektory a další prvky používané k vytvoření prezentace. V Aspose.Slides for PHP via Java je každý prvek na snímku reprezentován objektem, který dědí z třídy [Tvar](https://reference.aspose.com/slides/php-java/aspose.slides/shape/).

Různé typy tvarů nabízejí různé možnosti zamknutí. Třída [BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/) je základní třídou pro zamykání tvarů. Aspose.Slides for PHP via Java poskytuje následující třídy zamykání:

- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/) uzamyká automatické tvary.  
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) uzamyká konektorové tvary.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) uzamyká grafické objekty.  
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/) uzamyká seskupené tvary.  
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) uzamyká rámečky obrázků.  

Pro aplikaci zamykání napříč [Prezentací](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), projděte její snímky a nastavte příslušná zamknutí na každý podporovaný tvar.

## **Použití a odebrání ochrany**

Zamykání tvarů omezuje operace jako výběr, přesun a změnu velikosti tvarů. Neznamená to, že je celá prezentace needitovatelná.

### **Aplikovat ochranu na PPTX tvary**

Aspose.Slides for PHP via Java poskytuje třídu [Tvar](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) pro práci s tvary na snímku.

Příklad volá [setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked) a [setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked) s hodnotou `true` pro automatické tvary, s ekvivalentními zamknutími pro seskupené tvary, konektory a rámečky obrázků. Konektory používají [setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove) pro přesun; skupiny také používají [setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) k omezení seskupování.

Příklad načte existující PPTX prezentaci, zkontroluje tvary v kolekci tvarů každého snímku a uloží kopii s těmito omezeními aplikovanými. Tvary mimo čtyři zpracovávané typy zůstávají nezměněny. Smyčka neprochází podřízené tvary uvnitř skupiny.

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

Pro odebrání zamknutí tvaru nastavte jeho hodnotu na `false`. Následující příklad načte prezentaci se zamknutými tvary a vymaže omezení výběru, přesunu a změny velikosti pomocí [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) a [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/). Také odebere omezení seskupování předáním `false` metodě [GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) a uloží kopii prezentace. Ostatní nastavení zamknutí zůstávají nezměněna.

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

### **Závěr**

Aspose.Slides for PHP via Java vám umožňuje omezit konkrétní editační operace u jednotlivých tvarů nebo aplikovat stejné omezení napříč snímky. Vyberte zamykání podporované každým typem tvaru a nastavte jejich hodnoty na `false`, když potřebujete tato omezení odstranit.

## **Často kladené otázky**

**Mohu kombinovat zamykání tvarů a ochranu heslem ve stejné prezentaci?**

Ano. Zamykání tvarů omezuje konkrétní editační operace, zatímco [ochrana heslem](/slides/cs/php-java/password-protected-presentation/) může omezit otevření nebo úpravu prezentace. Obě můžete použít ve stejném souboru.

**Mohu omezit úpravy na konkrétních snímcích, aniž by to ovlivnilo ostatní?**

Ano. Aplikujte zamykání pouze na tvary na vybraných snímcích. Tím se nezmění nastavení zamknutí na ostatních snímcích.

**Jak mohu aplikovat zamykání na jednotlivé tvary uvnitř skupiny?**

Projděte kolekci vrácenou metodou [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) skupiny a aplikujte příslušná zamknutí na každý podřízený tvar. Opakujte to pro všechny vnořené skupiny. Příklady výše zpracovávají pouze kolekci tvarů snímku, takže nenastavují zamknutí na jednotlivé členy skupiny.