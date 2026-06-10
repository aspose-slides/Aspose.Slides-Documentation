---
title: Hiperhivatkozás
type: docs
weight: 130
url: /hu/php-java/examples/elements/hyperlink/
keywords:
- hiperhivatkozás
- hiperhivatkozás hozzáadása
- hiperhivatkozás elérése
- hiperhivatkozás eltávolítása
- hiperhivatkozás frissítése
- kód példák
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Hiperhivatkozások hozzáadása, szerkesztése és eltávolítása PHP-ben az Aspose.Slides használatával: szöveg, alakzatok, diák, URL-ek és e‑mail hivatkozások; célok és műveletek beállítása PPT, PPTX és ODP esetén."
---
Bemutatja a hiperhivatkozások hozzáadását, elérését, eltávolítását és frissítését alakzatokon az **Aspose.Slides for PHP via Java** segítségével.

## **Hiperhivatkozás hozzáadása**

Hozzon létre egy téglalap alakzatot, amelynek hiperhivatkozása egy külső weboldalra mutat.

```php
function addHyperlink() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
        $shape->getTextFrame()->setText("Aspose");

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://www.aspose.com"));

        $presentation->save("hyperlink.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Hiperhivatkozás elérése**

Olvassa ki a hiperhivatkozás információkat az alakzat szövegrészéből.

```php
function accessHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Feltételezve, hogy az első alakzat tartalmazza a hiperhivatkozást.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $hyperlink = $portion->getPortionFormat()->getHyperlinkClick();
    } finally {
        $presentation->dispose();
    }
}
```

## **Hiperhivatkozás eltávolítása**

Távolítsa el a hiperhivatkozást az alakzat szövegéből.

```php
function removeHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Feltételezve, hogy az első alakzat tartalmazza a hiperhivatkozást.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setHyperlinkClick(null);

        $presentation->save("hyperlink_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Hiperhivatkozás frissítése**

Módosítsa egy meglévő hiperhivatkozás célját. Használja a `HyperlinkManager`-t a már hiperhivatkozást tartalmazó szöveg módosításához, amely a PowerPoint módjának megfelelően biztonságosan frissíti a hiperhivatkozásokat.

```php
function updateHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Feltételezve, hogy az első alakzat tartalmazza a hiperhivatkozást.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);

        // A meglévő szövegben lévő hiperhivatkozás módosítását így kell végrehajtani:
        // HyperlinkManager segítségével, a tulajdonság közvetlen beállítása helyett.
        // Ez a PowerPoint módját utánzásával biztonságosan frissíti a hiperhivatkozásokat.
        $portion->getPortionFormat()->getHyperlinkManager()->setExternalHyperlinkClick("https://new.example.com");

        $presentation->save("hyperlink_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```