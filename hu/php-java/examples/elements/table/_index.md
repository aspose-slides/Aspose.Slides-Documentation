---
title: Táblázat
type: docs
weight: 120
url: /hu/php-java/examples/elements/table/
keywords:
- táblázat
- táblázat hozzáadása
- táblázat elérése
- táblázat eltávolítása
- cellák egyesítése
- kódpéldák
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Táblázatok létrehozása és formázása PHP-ben az Aspose.Slides használatával: adatok beszúrása, cellák egyesítése, szegélyek stílusozása, tartalom igazítása, valamint PPT, PPTX és ODP import/export."
---
Példák táblák hozzáadására, elérésére, eltávolítására és cellák egyesítésére a **Aspose.Slides for PHP via Java** használatával.

## **Táblázat hozzáadása**

Hozzon létre egy egyszerű táblázatot két sorral és két oszloppal.

```php
function addTable() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $widths = [80, 80];
        $heights = [30, 30];
        $table = $slide->getShapes()->addTable(50, 50, $widths, $heights);

        $presentation->save("table.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Táblázat elérése**

Szerezze meg az első táblázat‑alakzatot a dián.

```php
function accessTable() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // A dián lévő első táblázat elérése.
        $firstTable = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Table"))) {
                $firstTable = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Táblázat eltávolítása**

Távolítson el egy táblázatot a diáról.

```php
function removeTable() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Feltételezve, hogy a táblázat az első alakzat a dián.
        $table = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($table);

        $presentation->save("table_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Táblázat celláinak egyesítése**

Egyesítse a táblázat szomszédos celláit egyetlen cellává.

```php
function mergeTableCells() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Feltételezve, hogy a táblázat az első alakzat a dián.
        $table = $slide->getShapes()->get_Item(0);

        $table->mergeCells($table->get_Item(0, 0), $table->get_Item(1, 1), false);

        $presentation->save("cells_merged.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```