---
title: ActiveX
type: docs
weight: 200
url: /cs/php-java/examples/elements/activex/
keywords:
- ActiveX
- ActiveX ovládací prvek
- přidat ActiveX
- přístup k ActiveX
- odstranit ActiveX
- vlastnosti ActiveX
- příklady kódu
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Naučte se, jak v PHP pomocí Aspose.Slides najít, upravit a odstranit ActiveX ovládací prvky, včetně aktualizací vlastností pro prezentace PowerPoint."
---
Ukazuje, jak přidávat, přistupovat, odebírat a konfigurovat ActiveX ovládací prvky v prezentaci pomocí **Aspose.Slides for PHP via Java**.

## **Přidání ActiveX ovládacího prvku**

Vložte nový ActiveX ovládací prvek.

```php
function addActiveX() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Přidejte nový ActiveX ovládací prvek.
        $control = $slide->getControls()->addControl(ControlType::WindowsMediaPlayer, 50, 50, 100, 50);

        $presentation->save("activex.pptm", SaveFormat::Pptm);
    } finally {
        // Uvolněte prezentaci.
        $presentation->dispose();
    }
}
```

## **Přístup k ActiveX ovládacímu prvku**

Přečtěte informace z prvního ActiveX ovládacího prvku na snímku.

```php
function accessActiveX() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Přístup k prvnímu ActiveX ovládacímu prvku.
        $control = $slide->getControls()->get_Item(0);

        echo "Control Name: " . $control->getName() . PHP_EOL;
    } finally {
        // Uvolněte prezentaci.
        $presentation->dispose();
    }
}
```

## **Odstranění ActiveX ovládacího prvku**

Odstraňte existující ActiveX ovládací prvek ze snímku.

```php
function removeActiveX() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        if (java_values($slide->getControls()->size()) > 0) {
            // Odstraňte první ActiveX ovládací prvek.
            $slide->getControls()->removeAt(0);
        }

        $presentation->save("activex_removed.pptm", SaveFormat::Pptm);
    } finally {
        // Uvolněte prezentaci.
        $presentation->dispose();
    }
}
```

## **Nastavení vlastností ActiveX**

Nakonfigurujte několik vlastností ActiveX.

```php
function setActiveXProperties() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Předpokládáme, že první ovládací prvek je ten, který jsme přidali.
        $control = $slide->getControls()->get_Item(0);

        // Nakonfigurujte vlastnosti.
        $control->getProperties()->set_Item("Caption", "Click Me");
        $control->getProperties()->set_Item("Enabled", "true");

        $presentation->save("activex_properties.pptm", SaveFormat::Pptm);
    } finally {
        // Uvolněte prezentaci.
        $presentation->dispose();
    }
}
```