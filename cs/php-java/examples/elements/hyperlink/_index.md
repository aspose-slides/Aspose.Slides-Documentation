---
title: Hypertextový odkaz
type: docs
weight: 130
url: /cs/php-java/examples/elements/hyperlink/
keywords:
- hypertextový odkaz
- přidat hypertextový odkaz
- získat hypertextový odkaz
- odstranit hypertextový odkaz
- aktualizovat hypertextový odkaz
- příklady kódu
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Přidávejte, upravujte a odstraňujte hypertextové odkazy v PHP s Aspose.Slides: text odkazu, tvary, snímky, URL a email; nastavujte cíle a akce pro PPT, PPTX a ODP."
---
Ukazuje přidávání, získávání, odstraňování a aktualizaci hypertextových odkazů na tvarech pomocí **Aspose.Slides for PHP via Java**.

## **Přidání hypertextového odkazu**

Vytvořte obdélníkový tvar s hypertextovým odkazem směřujícím na externí webovou stránku.

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

## **Získání hypertextového odkazu**

Načtěte informace o hypertextovém odkazu z textové části tvaru.

```php
function accessHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Předpokládá se, že první tvar obsahuje hypertextový odkaz.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $hyperlink = $portion->getPortionFormat()->getHyperlinkClick();
    } finally {
        $presentation->dispose();
    }
}
```

## **Odstranění hypertextového odkazu**

Odstraňte hypertextový odkaz z textu tvaru.

```php
function removeHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Předpokládá se, že první tvar obsahuje hypertextový odkaz.
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

## **Aktualizace hypertextového odkazu**

Změňte cíl existujícího hypertextového odkazu. Použijte `HyperlinkManager` k úpravě textu, který již obsahuje hypertextový odkaz, což napodobuje způsob, jakým PowerPoint bezpečně aktualizuje hypertextové odkazy.

```php
function updateHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Předpokládá se, že první tvar obsahuje hypertextový odkaz.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);

        // Změna hypertextového odkazu v již existujícím textu by měla být provedena pomocí
        // HyperlinkManageru místo přímého nastavení vlastnosti.
        // Toto napodobuje, jak PowerPoint bezpečně aktualizuje hypertextové odkazy.
        $portion->getPortionFormat()->getHyperlinkManager()->setExternalHyperlinkClick("https://new.example.com");

        $presentation->save("hyperlink_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```