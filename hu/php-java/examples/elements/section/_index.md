---
title: Szakasz
type: docs
weight: 90
url: /hu/php-java/examples/elements/section/
keywords:
- szakasz
- diászakasz
- szakasz hozzáadása
- szakasz elérése
- szakasz eltávolítása
- szakasz átnevezése
- kódpéldák
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Kezelje a diászakaszokat PHP-ben az Aspose.Slides segítségével: egyszerűen hozhat létre, átnevezhet, újrarendezhet, áthelyezhet diákot a szakaszok között, és vezérelheti a láthatóságot PPT, PPTX és ODP formátumoknál."
---
Példák a bemutató szakaszainak kezelésére—hozzáadás, elérés, eltávolítás és átnevezés programozottan az **Aspose.Slides for PHP via Java** használatával.

## **Szakasz hozzáadása**

Hozzon létre egy szakaszt, amely egy adott dián kezdődik.

```php
function addSection() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Adj meg egy diát, amely a szakasz kezdetét jelöli.
        $presentation->getSections()->addSection("New Section", $slide);

        $presentation->save("section.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Szakasz elérése**

Olvassa el a szakaszinformációkat egy előadásból.

```php
function accessSection() {
    $presentation = new Presentation("section.pptx");
    try {
        // Egy szakasz elérése index alapján.
        $section = $presentation->getSections()->get_Item(0);
        $sectionName = $section->getName();
    } finally {
        $presentation->dispose();
    }
}
```

## **Szakasz eltávolítása**

Törölje a korábban hozzáadott szakaszt.

```php
function removeSection() {
    $presentation = new Presentation("section.pptx");
    try {
        $section = $presentation->getSections()->get_Item(0);

        // A szakasz eltávolítása.
        $presentation->getSections()->removeSection($section);

        $presentation->save("section_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Szakasz átnevezése**

Módosítsa egy meglévő szakasz nevét.

```php
function renameSection() {
    $presentation = new Presentation("section.pptx");
    try {
        $section = $presentation->getSections()->get_Item(0);
        $section->setName("New Name");

        $presentation->save("section_renamed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```