---
title: ActiveX
type: docs
weight: 200
url: /hu/php-java/examples/elements/activex/
keywords:
- ActiveX
- ActiveX vezérlő
- ActiveX hozzáadása
- ActiveX elérése
- ActiveX eltávolítása
- ActiveX tulajdonságok
- kódpéldák
- PowerPoint
- bemutató
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan találhatja meg, szerkesztheti és távolíthatja el az ActiveX vezérlőket PHP-ban az Aspose.Slides használatával, beleértve a PowerPoint bemutatók tulajdonságainak frissítését."
---
Bemutatja, hogyan adhat hozzá, érhet el, távolíthat el és konfigurálhat ActiveX vezérlőket egy bemutatóban a **Aspose.Slides for PHP via Java** használatával.

## **ActiveX vezérlő hozzáadása**

Új ActiveX vezérlő beszúrása.

```php
function addActiveX() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Új ActiveX vezérlő hozzáadása.
        $control = $slide->getControls()->addControl(ControlType::WindowsMediaPlayer, 50, 50, 100, 50);

        $presentation->save("activex.pptm", SaveFormat::Pptm);
    } finally {
        // A prezentáció eldobása.
        $presentation->dispose();
    }
}
```

## **ActiveX vezérlő elérése**

Olvassa el az első ActiveX vezérlő információit a dián.

```php
function accessActiveX() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Az első ActiveX vezérlő elérése.
        $control = $slide->getControls()->get_Item(0);

        echo "Control Name: " . $control->getName() . PHP_EOL;
    } finally {
        // A prezentáció eldobása.
        $presentation->dispose();
    }
}
```

## **ActiveX vezérlő eltávolítása**

Törölje a meglévő ActiveX vezérlőt a diáról.

```php
function removeActiveX() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        if (java_values($slide->getControls()->size()) > 0) {
            // Az első ActiveX vezérlő eltávolítása.
            $slide->getControls()->removeAt(0);
        }

        $presentation->save("activex_removed.pptm", SaveFormat::Pptm);
    } finally {
        // A prezentáció eldobása.
        $presentation->dispose();
    }
}
```

## **ActiveX tulajdonságok beállítása**

Konfiguráljon több ActiveX tulajdonságot.

```php
function setActiveXProperties() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Feltételezve, hogy az első vezérlő a mi általunk hozzáadott.
        $control = $slide->getControls()->get_Item(0);

        // Tulajdonságok konfigurálása.
        $control->getProperties()->set_Item("Caption", "Click Me");
        $control->getProperties()->set_Item("Enabled", "true");

        $presentation->save("activex_properties.pptm", SaveFormat::Pptm);
    } finally {
        // A prezentáció eldobása.
        $presentation->dispose();
    }
}
```