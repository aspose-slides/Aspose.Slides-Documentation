---
title: Mester dia
type: docs
weight: 30
url: /hu/php-java/examples/elements/master-slide/
keywords:
- mester dia
- mester dia hozzáadása
- mester dia elérése
- mester dia eltávolítása
- nem használt mester dia
- kód példák
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Kezelje a mester diákat PHP-ben az Aspose.Slides használatával: hozzon létre, szerkesszen, klónozzon és formázzon témákat, háttérképeket, helyettesítőket, hogy egységesítse a diákat PowerPoint és OpenDocument formátumban."
---
A master slides form the top level of the slide inheritance hierarchy in PowerPoint. A **master slide** defines common design elements such as backgrounds, logos, and text formatting. **Layout slides** inherit from master slides, and **normal slides** inherit from layout slides.

Ez a cikk bemutatja, hogyan hozhatunk létre, módosíthatunk és kezelhetünk master slides using Aspose.Slides for PHP via Java.

## **Mester dia hozzáadása**

Ez a példa bemutatja, hogyan hozhatunk létre egy új master slide az alapértelmezett klónozásával.

```php
function addMasterSlide() {
    $presentation = new Presentation();
    try {
        // Klónozza az alapértelmezett mester diát.
        $defaultMasterSlide = $presentation->getMasters()->get_Item(0);
        $newMasterSlide = $presentation->getMasters()->addClone($defaultMasterSlide);

        $presentation->save("master_slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Tip 1:** A mester diák lehetővé teszik a konzisztens márka vagy közös tervezési elemek alkalmazását az összes diára. Bármelyik változtatás a mesteren automatikusan megjelenik a függő elrendezés és normál diákon.  
> 💡 **Tip 2:** A mester diára hozzáadott bármely alakzat vagy formázás öröklődik az elrendezés diákra, és végül minden, az adott elrendezést használó normál diára.  
> Az alábbi kép azt illusztrálja, hogyan jelenik meg automatikusan egy mester diára hozzáadott szövegdoboz a végső dián.

![Mester öröklési példa](master-slide-banner.png)

## **Mester dia elérése**

A mester diákhoz a `Presentation::getMasters` metódus használatával férhetünk hozzá. Íme, hogyan lehet lekérni és dolgozni velük:

```php
function accessMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // Hozzáférés az első mester diához.
        $firstMasterSlide = $presentation->getMasters()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **Mester dia eltávolítása**

A mester diák eltávolíthatók index vagy referencia alapján.

```php
function removeMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // Távolítsa el index szerint.
        $presentation->getMasters()->removeAt(0);

        // Vagy távolítsa el hivatkozás alapján.
        $firstMasterSlide = $presentation->getMasters()->get_Item(0);
        $presentation->getMasters()->remove($firstMasterSlide);

        $presentation->save("master_slide_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Nem használt mester diák eltávolítása**

Néhány prezentáció olyan mester diákat tartalmaz, amelyek nincsenek használatban. Ezeknek a diáknak az eltávolítása segíthet csökkenteni a fájlméretet.

```php
function removeUnusedMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // Távolítsa el az összes nem használt mester diát (még azokat is, amelyek megőrzésre vannak jelölve).
        $presentation->getMasters()->removeUnused(true);

        $presentation->save("master_slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> ⚙️ **Tip:** Használja a `removeUnused(true)` metódust a nem használt mester diák tisztításához és a prezentáció méretének minimalizálásához.